using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpClone
{
    internal static class Settings
    {
        public static int WidthOfFild { get; private set; }
        public static int HeightOfFild { get; private set; }
        public static int WidthOfPad_defoult { get; private set; }
        public static int HeightOfPad_defoult {  get; private set; }
        public static int WidthOfPlayerCharacter_defoult { get; private set; }
        public static int HeightOfPlayerCharacter_defoult { get; private set; }

        public static void SetSettings(
            int widthOfFild,
            int heightOfFild,
            int widthOfFPad,
            int heightOfFPad,
            int widthOfPlayerCharacter,
            int heightOfPlayerCharacter) 
        {
            WidthOfFild = widthOfFild;
            HeightOfFild = heightOfFild; 
            WidthOfPad_defoult = widthOfFPad;
            HeightOfPad_defoult = heightOfFPad;
            WidthOfPlayerCharacter_defoult = widthOfPlayerCharacter;
            HeightOfPlayerCharacter_defoult = heightOfPlayerCharacter;
        }

    }
}
