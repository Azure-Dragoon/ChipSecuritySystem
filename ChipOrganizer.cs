using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    internal class ChipOrganizer
    {

        public List<ColorChip> allChips;
        public List<ColorChip> allBlueStartChips;
        public List<ColorChip> allGreenEndChips;
        public List<ColorChip> allOtherChips;


        public ChipOrganizer(List<ColorChip> allChips)
        {
            this.allChips = allChips;
            allBlueStartChips = new List<ColorChip>();
            allGreenEndChips = new List<ColorChip>();
            allOtherChips = new List<ColorChip>();
        }

        //pull out all blue(start) chips and all green(end) chips
        public void SeperateEndChips()
        {
            foreach (ColorChip chip in allChips)
            {
                if (chip.StartColor.Equals(Color.Blue))
                {
                    allBlueStartChips.Add(chip);

                }
                else if (chip.EndColor.Equals(Color.Green))
                {
                    allGreenEndChips.Add(chip);

                }
                else
                {
                    allOtherChips.Add(chip);
                }

            }
        }

        //If no chips start with blue or end with green we cannot unlock the system
        public bool IsValidCollection()
        {

            return allBlueStartChips.Count > 0 && allGreenEndChips.Count > 0;
        }




    }
}
