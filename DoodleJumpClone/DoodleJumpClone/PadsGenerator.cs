using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpClone
{
    internal static class PadsGenerator
    {
        static Random random = new Random();
        public static List<Pad> GeneratePads(int count)
        {
            var pads = new List<Pad>();
            int step = Settings.StartingHeight / count;

            var x = 0;
            for (int i = 0; i < count; i++)
            {
                x = random.Next(
                    (x - 4 * Settings.WidthOfPad_defoult < 10) ?
                        10 :
                        x - 4 * Settings.WidthOfPad_defoult,
                    (x + 4 * Settings.WidthOfPad_defoult > Settings.WidthOfFild - 10) ?
                        Settings.WidthOfFild - 10 :
                        x + 4 * Settings.WidthOfPad_defoult);
                pads.Add(new Pad(
                    x,
                    i * step + random.Next(0,20)));

                if (random.Next() + 0.1 * i > 0.3)
                {
                    var actX = random.Next(
                        10,
                        Settings.WidthOfFild - 10);
                    if (Math.Abs(actX - x) > 40)
                        pads.Add(new Pad(
                            actX,
                            i * step + random.Next(0, 20)));
                }
            }
            pads.AddLaunchPad();
            return pads;
        }

        private static void AddLaunchPad(this List<Pad> pads)
        {
            pads.Add(new Pad(
                (Settings.WidthOfFild - Settings.WidthOfPad_defoult) / 2,
                Settings.StartingHeight));
        }
        public static void AddGeneratedPad(this List<Pad> pads)
        {
            pads.Add(new Pad(
                random.Next(10, Settings.WidthOfFild - 10),
                random.Next(0, 20)));
        }
    }
}
