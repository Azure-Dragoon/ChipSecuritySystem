using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {

            List<ColorChip> chips = new List<ColorChip>()
            {
                //insert list of chips here.
              
            };
            ChipOrganizer chipOrganizer = new ChipOrganizer(chips);

            ChipLinker chipLinker = new ChipLinker();

            List<ColorChip> linkedChips = chipLinker.findChain(chips);
            if (linkedChips.Count == 0)
            {
                Console.WriteLine(Constants.ErrorMessage);
            }
            else
            {
                foreach (ColorChip ch in linkedChips)
                {
                    Console.WriteLine(ch.ToString());
                }
            }
            Console.ReadKey();

        }
    }
}
