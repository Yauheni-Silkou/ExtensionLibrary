using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Threading;

namespace WpfExtensions.AudioExtension
{
    public static class Player
    {
        public static void PlaySound(byte[] buffer)
        {
            ThreadPool.QueueUserWorkItem(ignoredState =>
            {
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    using (SoundPlayer player = new SoundPlayer(ms))
                    {
                        player.LoadAsync();
                        player.Play();
                    }
                }
            });
        }

        public static void PlaySound(string path)
        {
            ThreadPool.QueueUserWorkItem(ignoredState =>
            {
                using (SoundPlayer player = new SoundPlayer(path))
                {
                    player.LoadAsync();
                    player.Play();
                }
            });
        }
    }
}
