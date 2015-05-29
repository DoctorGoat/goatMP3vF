using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace goatMP3vF
{
    public partial class Form1 : Form
    {
        private static String playMode = "l";
        public static List<song> songList = new List<song>();
        private static DirectSoundOut dsOut = new DirectSoundOut(50);
        private static MediaFoundationReader mfr = null;
        private static VolumeWaveProvider16 volManager = null;
        private static Boolean isPlaying = false;
        public static int songToPlay = 0;
        private static float vol = 1.0f;
        private static String title = "";
        private Boolean sortSong = false;
        private Boolean sortArtist = false;
        private Boolean loop = false;
        private Boolean pop = false;
        private String songName = null;

        public Form1()
        {
            InitializeComponent();

            //initialize DirectSound playback.
            // keep on top
            this.Text = "pygmp3: the tiny mp3 player";
            this.Height = 85;
            this.AllowDrop = true;
            listView1.Refresh();
            titleUpdate.RunWorkerAsync();
            loadCurrent();
        }

        //If the song is stopped and playback is currently active
        //go to the next song. 
        
        //I could be using a function for nextButton and this but
        //it doesn't seem necessary

        //if we need to pop the list
        private void onStop(object sender, StoppedEventArgs e)
        {
            if(dsOut.PlaybackState == PlaybackState.Stopped && isPlaying == true)
            {
                if (pop == true)
                {
                    songPop();
                }
                nextButton(null, null);
            }
        }

        //Toggle between two sizes
        private void playlistManagerOpen(object sender, EventArgs e)
        {
            if (this.Height < 625)
            {
                this.Height = 625;
                updateList();
            }
            else
            {
                this.Height = 85;
            }
        }

       //Manage volume, check if volume manager is null
       //before running setVolume
        private void volBar(object sender, EventArgs e)
        {
            vol = trackPositionBar.Value * 0.01f;
            if (volManager != null)
            {
                setVolume(trackPositionBar.Value);
            }
        }

        private void setVolume(int s)
        {
            vol = s * 0.01f;
            volManager.Volume = s * 0.01f;

        }

        //simple buttons
        //If it's paused, unpause. If there's >0 items, play.
        //Otherwise, play the first song available if it exists.
        private void playButton(object sender, EventArgs e)
        {
            if (dsOut.PlaybackState == PlaybackState.Paused)
            {
                dsOut.Play();
            }
            else if (listView1.SelectedItems.Count != 0)
            {
                dsOut.Play();
            }
            else
            {
                Play(0);
                songToPlay = 0;
            }
        }
        
        //If the DirectSound output is running/paused,
        //stop, set the player to not playing, change the title text,
        //and clear the current playtime.
       private void stopButton(object sender, EventArgs e)
        {
            if (dsOut.PlaybackState != PlaybackState.Stopped)
            {
                dsOut.Stop();
                isPlaying = false;
                mfr.Dispose();
                this.Text = "pygmp3";
                label1.Text = "";
            }
        }

        //Toggle pause/play.
        private void pauseButton(object sender, EventArgs e)
        {
            if (dsOut.PlaybackState == PlaybackState.Playing)
            {
                dsOut.Pause();
            }
            else if (dsOut.PlaybackState == PlaybackState.Paused)
            {
                dsOut.Play();
            }
            else
            { }
        }

        //If the next song is random, jump wherever.
        //Otherwise, increment the song to play and play it.
        private void nextButton(object sender, EventArgs e)
        {
            //On random: Generate random number between 0 and the number of songs
            //in the list. If we're popping, remove the current mp3 before jumping.
            if (playMode == "r")
            {
                if (pop == true && songList.Count > 0)
                {
                    songList.RemoveAt(songToPlay);
                    updateList();
                }
                Random rn = new Random();
                Play(rn.Next(0, (songList.Count+1)));
            }
            //If we reach the end of the list and need to loop, go back to first.
            else if (songList.Count > 0 && loop == true)
            {
                songToPlay = 0;
                Play(0);
            }
            //Otherwise, normally skip.
            //Deselect current selected item, select the song to play,
            //and play it.
            else if (songList.Count > (songToPlay + 1))
            {
                if (pop == true)
                {
                    songPop();
                    Play(songToPlay);
                }
                else
                {
                    if (listView1.SelectedItems.Count != 0)
                    {
                        listView1.SelectedItems[0].Selected = false;
                    }
                    listView1.Items[songToPlay+1].Selected = true;
                    Play(songToPlay + 1);
                }
            }
            //Otherwise just pop the last one.
            else if (pop == true && songList.Count > 0)
            {
                songPop();
            }

        }

        private void songPop()
        {
            //Remove the current song being played. If it's not 0, decrement the song
            //being played to keep the same position in the list. 
            //Select the next song and play it.
            if (songList.Count > 0)
            {
                songList.RemoveAt(songToPlay);
                if (songToPlay != 0)
                {
                    songToPlay--;
                }
                Play(songToPlay);
                if (songList.Count != 0)
                {
                    listView1.Items[songToPlay].Selected = true;
                }
                updateList();
            }
        }

        //Play the song before the current one.
        private void backButton(object sender, EventArgs e)
        {
            if (playMode == "r")
            {
                if (pop == true && songList.Count > 0)
                {
                    songList.RemoveAt(songToPlay);
                    updateList();
                }
                Random rn = new Random();
                Play(rn.Next(0, (songList.Count+1)));
            }
            else if (songToPlay > 0)
            {
                if (pop == true)
                {
                    songPop();
                    listView1.Items[songToPlay].Selected = true;
                }
                else
                {
                    Play(songToPlay - 1);
                    if (listView1.Items.Count > songToPlay)
                    {
                        listView1.Items[songToPlay].Selected = true;
                        listView1.SelectedItems[1].Selected = false;
                    }
                }
            }
            else if (songToPlay == 0 && songList.Count > 0)
            {
                songPop();
            }
        }

        //Refresh the listview. 
        //Clear the items, create a new list using the actual song list.
        private void updateList()
        {
            listView1.Items.Clear();
            foreach (song v in Form1.songList)
            {
                ListViewItem lvi = new ListViewItem(v.artist);
                lvi.SubItems.Add(v.title);
                lvi.SubItems.Add(v.trackNum);
                lvi.SubItems.Add(v.duration);
                listView1.Items.Add(lvi);
            }
        }

        //Adding a song:
        //Open id3v2 tags. Create a new song using them:
        //tag.Artists is deprecated but more functional.

        //If the tags are wrong, set the filename to the file's name and
        //set the artist to the filename without path.
        private void addSong(String s)
        {
            if (Path.GetExtension(s) == ".mp3" || Path.GetExtension(s) == ".m4a")
            {
                song newSong = new song();
                try
                {
                    TagLib.File tags = TagLib.File.Create(s);
                    newSong.title = tags.Tag.Title;
                    newSong.artist = tags.Tag.Artists[0];
                    newSong.fileName = s;
                    newSong.duration = tags.Properties.Duration.ToString();
                    newSong.trackNum = tags.Tag.Track.ToString();
                }

                catch
                {
                    newSong.title = ""; newSong.artist = Path.GetFileName(s); newSong.fileName = s; newSong.duration = ""; newSong.trackNum = "";
                }
                songList.Add(newSong);
            }
        }

        //Self explanatory.
        public void playSong(object sender, EventArgs e)
        {
            Play(listView1.SelectedIndices[0]);
        }

        //Create a file browser and get a folder from it. Run it through the iterator to populate songlist.
        private void folderAddClick(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            DialogResult dr = fb.ShowDialog();
            if (dr == DialogResult.OK)
            {
                crawlFolder(fb.SelectedPath);
            }
            updateList();
        }

        //Create file dialog, allow multiselect, add resulting songs.
        private void fileAddClick(object sender, EventArgs e)
        {
            OpenFileDialog ofb = new OpenFileDialog();
            ofb.Multiselect = true;
            DialogResult dr = ofb.ShowDialog();

            List<String> g = new List<String>();
            if (dr == DialogResult.OK)
            {
                foreach (String s in ofb.FileNames)
                {
                    addSong(s);
                }
            }
            updateList();
        }

        //recursive song search. only allows mp3 and m4a files.
        private void crawlFolder(String s)
        {
            foreach (String fileFind in Directory.GetFiles(s))
            {
                if (Path.GetExtension(fileFind).Contains(".mp3") || Path.GetExtension(fileFind).Contains(".m4a"))
                {
                    try
                    {
                        addSong(fileFind);
                    }
                    catch { MessageBox.Show("File: " + fileFind + " caused an issue.");
                    };
                }
            }
            foreach (String dirFind in Directory.GetDirectories(s))
            {
                crawlFolder(dirFind);
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Save serialized songList.
        private void savePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = false;
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                FileStream save = new FileStream(ofd.FileName, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(save, songList);
                save.Close();
            }
        }

        //deserialize playlist
        private void loadPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    FileStream load = new FileStream(ofd.FileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    List<song> sli = (List<goatMP3vF.song>)bin.Deserialize(load);
                    foreach (song v in sli)
                    {
                        songList.Add(v);
                    }
                    load.Close();
                }
                catch { MessageBox.Show("Error loading playlist."); }
            }
            updateList();
        }

        //Clear the songlist and update.
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.songList.Clear();
            updateList();
        }

        //Random/Linear playback.
        private void button10_Click(object sender, EventArgs e)
        {
            playMode = "r";
            linearToolStripMenuItem.Text = "Linear";
            randomToolStripMenuItem.Text = "* Random";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            playMode = "l";
            randomToolStripMenuItem.Text = "Random";
            linearToolStripMenuItem.Text = "* Linear";
        }

        //Tag files to remove, put them in a list, sort it backwards, and remove files.
        private void removeSong()
        {
            List<int> goat = new List<int>();
            foreach (int a in listView1.SelectedIndices)
            {
                goat.Add(a);
            }
            goat.Sort();
            goat.Reverse();
            foreach (int a in goat)
            {
                songList.RemoveAt(a);
            }
        }

        //Handle adding files from filedrop.
        private void dragFiles(object sender, DragEventArgs e)
        {
            string[] goat = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string s in goat)
            {
                addSong(s);
            }
        }

        //Key handler. Ctrl+A selects all, enter plays current, del
        //deletes the highlighted options.
        //Space pauses (requested)
        private void del(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                removeSong();
                updateList();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (listView1.SelectedIndices.Count > 0)
                {
                    Play(listView1.SelectedIndices[0]);
                }
            }
            else if (e.Control & e.KeyCode == Keys.A)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].Selected = true;
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                pauseButton(null, null);
            }
        }

        //Toggle between always on top and normal window layering.
        private void toggleOnTop(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                toggleButton.Text = "Enable focus";
                this.TopMost = false;
            }
            else
            {
                toggleButton.Text = "Disable focus";
                this.TopMost = true;
            }
        }

        //Sort using LINQ.
        private void sort(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                List<song> SortedList = songList.OrderBy(o => o.artist).ToList();
                if (sortArtist == true)
                {
                    SortedList.Reverse();
                    sortArtist = true;
                }
                else
                {
                    sortArtist = false;
                }
                songList = SortedList;
            }
            else
            {
                List<song> SortedList = songList.OrderBy(o => o.title).ToList();
                if (sortSong == false)
                {
                    sortSong = true;
                }
                else
                {
                    SortedList.Reverse();
                    sortSong = false;
                }
                songList = SortedList;
            }
            updateList();
        }

        //Randomizes songlist order using LINQ.
        private void shuffleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random rn = new Random();
            songList = songList.OrderBy(song => rn.Next()).ToList();
            updateList();
        }
        
        //Remove selected songs.
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                removeSong();
                updateList();
            }
        }

        //Seek through song by reading the PCM stream's bitrate and multiplying it by the trackbar value.
        //Start at the beginning. Make sure to set isPlaying to true.
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            mfr.Seek(mfr.WaveFormat.AverageBytesPerSecond * positionBar.Value, SeekOrigin.Begin);
            isPlaying = true;
        }

        //Change title. Used in the background thread.
        public void updateTitle(String s)
        {
            if (dsOut.PlaybackState == PlaybackState.Playing)
            {
                this.Text = s;
            }
        }

        //background thread
        private void updateWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //Run continuously.
            while (true)
            {
                //But only while the mediafilereader is open.
                while (mfr != null)
                {
                    String Cmins = mfr.CurrentTime.Minutes.ToString();
                    if (Cmins.Length == 1)
                    {
                        Cmins = "0" + Cmins;
                    }

                    String Csecs = mfr.CurrentTime.Seconds.ToString();
                    if (Csecs.Length < 2)
                    {
                        Csecs = "0" + Csecs;
                    }
                    String Tmins = mfr.TotalTime.Minutes.ToString();
                    if (Tmins.Length == 1)
                    {
                        Tmins = "0" + Tmins;
                    }

                    String Tsecs = mfr.TotalTime.Seconds.ToString();
                    if (Tsecs.Length < 2)
                    {
                        Tsecs = "0" + Tsecs;
                    }

                    //Invoke methods from Form1 to update the label and trackbar location.
                    label1.Invoke((MethodInvoker)(() => label1.Text = Cmins + ":" + Csecs + " / " + Tmins + ":" + Tsecs));
                    positionBar.Invoke((MethodInvoker)(() => positionBar.Value = Convert.ToInt32(mfr.CurrentTime.TotalSeconds)));

                    //Scrolling marquee if needed:
                    //Cycle the string and take a part of it to display.
                    String playString = songName;
                    if (songName.Length > 22)
                    {
                        songName = Cycle(songName);
                        playString = songName.Substring(0, 22);
                    }
                    else
                    {
                        playString = songName;
                    }
                    try {
                        //Set the title to the string segment.
                        this.Invoke((MethodInvoker)(() => updateTitle(playString + " " + Cmins + ":" + Csecs + " / " + Tmins + ":" + Tsecs + " ")));
                    }
                    catch
                    {
                        Console.WriteLine("Invoke error:");

                    }
                    //Rest for 150ms.
                        Thread.Sleep(150);
                }
                //Rest for 1s when unneeded.
                Thread.Sleep(1000);
            }
        }


        private String Cycle(string songName)
        {
            String cycled = songName;
            cycled = cycled + songName[0];
            cycled = cycled.Remove(0, 1);
            return cycled;
        }

        //s is the song to play 
        //read file with mediafoundationreader,
        //then pipe it into the volume manager
        //and then read the result with DirectSound
        //then set the current song to play to s
        public void Play(int s)
        {
            if (songList.Count > 0)
            {
                if (dsOut.PlaybackState == PlaybackState.Playing)
                {
                    dsOut.Stop();
                }

                //Initialization: VolumeWaveProvider requires a file piped in.
                //DirectSoundOut requires an input: We're feeding it the volume
                //manager. 
                //Since we're initializing a new dsOut, we need to reset the event
                //associated with it.
                mfr = new MediaFoundationReader(songList[s].fileName);
                volManager = new VolumeWaveProvider16(mfr);
                dsOut = new DirectSoundOut(50);
                dsOut.PlaybackStopped += new EventHandler<StoppedEventArgs>(onStop);
                dsOut.Init(volManager);
                dsOut.Play();


                //Reset initial values for the song.
                //Position in songlist, listview, reading the songname
                //for the background worker, etc
                positionBar.Value = 0;
                volManager.Volume = vol;
                songToPlay = s;
                positionBar.Maximum = Convert.ToInt32(mfr.TotalTime.TotalSeconds);
                isPlaying = true;
                title = songList[s].title;
                try {
                    listView1.Items[songToPlay].Selected = true;
                    listView1.TopItem = listView1.Items[songToPlay];
                }
                catch { }
                songName = " " + songList[songToPlay].artist + ": " + songList[songToPlay].title;

            }
        }


        // add dragged-in songs to list
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        //If a folder is dragged in, crawl it. Otherwise, just add each song.
        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (Directory.Exists(file))
                {
                    crawlFolder(file);
                }
                else
                {
                    addSong(file);
                }
            }
            updateList();
        }


        private void loopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loop = !loop;
            if (loop == true)
            {
                loopToolStripMenuItem.Text = "* Loop";
            }
            else
                loopToolStripMenuItem.Text = "Loop";
        }

        private void popToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pop = !pop;
            if (pop == true)
            {
                popToolStripMenuItem.Text = "* Pop";
            }
            else
                popToolStripMenuItem.Text = "Pop";

        }

        //Automatically save playlist when closing.
        private void storeCurrent(object sender, FormClosingEventArgs e)
        {
            try
            {
                FileStream save = new FileStream("pl.goat", FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(save, songList);
                save.Close();
            }
            catch
            {
                MessageBox.Show("Could not save current playlist.");
            }
        }

        //Automatically load playlist when opening.
        private void loadCurrent()
        {
            try
            {
                FileStream load = new FileStream("pl.goat", FileMode.Open);
                BinaryFormatter bin = new BinaryFormatter();
                List<song> sli = (List<goatMP3vF.song>)bin.Deserialize(load);
                foreach (song v in sli)
                {
                    songList.Add(v);
                }
                load.Close();
            }
            catch { }
        }


        private void opacityChange(object sender, EventArgs e)
        {
            this.Opacity = Convert.ToDouble(opacityUpDown.Value / 100);
        }

        private void sortByFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<song> SortedList = songList.OrderBy(o => o.fileName).ToList();
            songList = SortedList;
            updateList();
        }
    }
}
