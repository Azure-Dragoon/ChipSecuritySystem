using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    internal class ChipLinker
    {


        private Color getNextColor(ColorChip chip)
        {
            return chip.EndColor;
        }



        public List<ColorChip> findChain(List<ColorChip> allChips)
        {
            ChipOrganizer chipOrganizer = new ChipOrganizer(allChips);
            chipOrganizer.SeperateEndChips();
            ColorChip lastChip = null;
            List<ColorChip> currentChain = new List<ColorChip>();
            List<ColorChip> longestChain = new List<ColorChip>();

            //If no blue starters or green enders skip linking logic
            if (chipOrganizer.IsValidCollection())
            {

                foreach (var chip in chipOrganizer.allBlueStartChips)
                {

                    currentChain.Clear();
                    //start with blue chip and work through all blue chips to get the longer paths.
                    //Assuming can have multple blue start chips but colors won't repeat on the same chip due to being bi-colored 
                    currentChain.Add(chip);
                    lastChip = chip;

                    for (int i = 0; i < chipOrganizer.allOtherChips.Count; i++)
                    {

                        //using last chip to checking waht is the next color and getting the correct piece from all non blue and non green pieces
                        if (getNextColor(lastChip).Equals(chipOrganizer.allOtherChips[i].StartColor))
                        {
                            currentChain.Add(chipOrganizer.allOtherChips[i]);
                            lastChip = chipOrganizer.allOtherChips[i];
                        }

                    }
                    //no more other peices can be added just lets add our last piece(which should end with Green)
                    if (chipOrganizer.allGreenEndChips.Any(c => c.StartColor.Equals(getNextColor(lastChip))))
                    {
                        currentChain.Add(chipOrganizer.allGreenEndChips.FirstOrDefault(c => c.StartColor.Equals(getNextColor(lastChip))));

                    }
                    //sequence must end in green
                    else
                    {
                        currentChain.Clear();
                    }


                    if (currentChain.Count > longestChain.Count)
                    {
                        longestChain.Clear();
                        longestChain.AddRange(currentChain);
                    }


                }
            }
            return longestChain;
        }
    }
}
