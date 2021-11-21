using System;
using System.Collections.Generic;
using System.Linq;
using SoulsFormats;

namespace BreakableObjectLoot
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string[] objectModelNames = { "o8411", "o8410", "o8403", "o8404", "o8402", "o8401", "o8400", "o7690", "o7650", "o7641", "o7640", "o7600", "o6357", "o6456", "o6455", "o6452", "o6451", "o6450", "o5990", "o5983", "o5982", "o5981", "o5980", "o5972", "o5971", "o5970", "o5969", "o5968", "o5967", "o5940", "o5930", "o5920", "o5552", "o5551", "o5550", "o4611", "o4401", "o4400", "o4370", "o4362", "o4411", "o4408", "o4407", "o4406", "o4361", "o4350", "o4215", "o3890", "o3654", "o3653", "o3652", "o3651", "o3650", "o3612", "o3611", "o3610", "o3501", "o3500", "o3312", "o3311", "o3310", "o3301", "o3300", "o2253", "o2252", "o2251", "o2203", "o2202", "o2200", "o1946", "o1945", "o1940", "o1497", "o1496", "o1495", "o1322", "o1321", "o1320", "o1251", "o1176", "o1173", "o1172", "o1170", "o1163", "o1162", "o1156", "o1155", "o1154", "o1153", "o1152", "o1150", "o1146", "o1145", "o1140", "o1136", "o1135", "o1134", "o1133", "o1132", "o1130", "o1129", "o1120", "o1058", "o1056", "o1055", "o1049", "o1002", "o0106" };
            string msbPath = "../map/MapStudio/";
            string consoleInput = "";
            int[] entityIDs = {
                6801000, 6801001, 6801002,
                6801100, 6801200, 6801201,
                6801300, 6801301, 6801302,
                6801400, 6801401, 6801500,
                6801501, 6801600, 6801700,
                6801800, 6801801
            };

            Dictionary<string, int> mapFileEntityIDs = new Dictionary<string, int>{
                { "m10_00_00_00.msb", entityIDs[0] },
                { "m10_01_00_00.msb", entityIDs[1] },
                { "m10_02_00_00.msb", entityIDs[2] },
                { "m11_00_00_00.msb", entityIDs[3] },
                { "m12_00_00_01.msb", entityIDs[4] },
                { "m12_01_00_00.msb", entityIDs[5] },
                { "m13_00_00_00.msb", entityIDs[6] },
                { "m13_01_00_00.msb", entityIDs[7] },
                { "m13_02_00_00.msb", entityIDs[8] },
                { "m14_00_00_00.msb", entityIDs[9] },
                { "m14_01_00_00.msb", entityIDs[10] },
                { "m15_00_00_00.msb", entityIDs[11] },
                { "m15_01_00_00.msb", entityIDs[12] },
                { "m16_00_00_00.msb", entityIDs[13] },
                { "m17_00_00_00.msb", entityIDs[14] },
                { "m18_00_00_00.msb", entityIDs[15] },
                { "m18_01_00_00.msb", entityIDs[16] }
            };

            int[] itemLotIDs = {
                6901000, 6901010, 6901020,
                6901100, 6901200, 6901210,
                6901300, 6901310, 6901320,
                6901400, 6901410, 6901500,
                6901510, 6901600, 6901700,
                6901800, 6901810
            };

            Console.WriteLine("Dark Souls: Breakable Object Loot Mod v2.0\n");

            #region Game Check

            try
            {
                EMEVD fileCheck = EMEVD.Read("../event/common.emevd");
            }
            catch
            {
                Console.Write("Could not find essential files for installation. Please ensure this mod's folder is inside you game's \"DATA\" directory and that your game is unpacked using UDSFM.\n" +
                    "Press enter to exit ");
                Console.Read();
                return;
            }

            #endregion

            #region Compatibility Check and File Declaration

            PARAM defaultModParams = PARAM.Read("resources/ItemLotParam.param");
            PARAMDEF itemParamDefs = PARAMDEF.Read(BND3.Read("../paramdef/paramdef.paramdefbnd").Files.Find(n => n.Name.Contains("ItemLotParam.paramdef")).Bytes);
            PARAMDEF pcAttackParamDefs = PARAMDEF.Read(BND3.Read("../paramdef/paramdef.paramdefbnd").Files.Find(n => n.Name.Contains("AtkParam.paramdef")).Bytes);
            BND3 gameParamBND = BND3.Read("../param/GameParam/GameParam.parambnd");
            PARAM gameItemParams = PARAM.Read(gameParamBND.Files.Find(n => n.Name.Contains("ItemLotParam.param")).Bytes);
            PARAM gamePCAttackParams = PARAM.Read(gameParamBND.Files.Find(n => n.Name.Contains("AtkParam_Pc.param")).Bytes);
            EMEVD defaultEventFile = EMEVD.Read("resources/eventfile.emevd");
            EMEVD gameEventFile = EMEVD.Read("../event/common.emevd");

            defaultModParams.ApplyParamdef(itemParamDefs);
            gameItemParams.ApplyParamdef(itemParamDefs);
            gamePCAttackParams.ApplyParamdef(pcAttackParamDefs);

            bool idsInUse = false;

            foreach (int id in itemLotIDs)
            {
                if (gameItemParams.Rows.Exists(r => r.ID == id))
                {
                    idsInUse = true;
                    break;
                }
            }
            if (gameEventFile.Events.Exists(e => e.ID == 6900000))
            {
                idsInUse = true;
            }

            if (idsInUse)
            {
                Console.WriteLine("Some of the ID values this mod uses are already in use (either by a previous version of this mod or another mod). Continuing will overwrite the values in those entries. Proceed?");
                consoleInput = "";
                while (consoleInput != "Y" && consoleInput != "y" && consoleInput != "N" && consoleInput != "n")
                {
                    Console.Write("Type [Y] to continue, [N] to exit: ");
                    consoleInput = Console.ReadLine().Trim();
                }
                if (consoleInput == "N" || consoleInput == "n")
                {
                    return;
                }
            }

            #endregion

            #region Param Installation

            //apply itemlotparams
            for (int i = 0; i < itemLotIDs.Length; i++)
            {
                int checkRow = gameItemParams.Rows.FindIndex(r => r.ID == itemLotIDs[i]);
                PARAM.Row currentRow = defaultModParams.Rows.Find(r => r.ID == itemLotIDs[i]);
                if (checkRow != -1)
                {
                    gameItemParams.Rows[checkRow] = currentRow;
                }
                else
                {
                    gameItemParams.Rows.Add(currentRow);
                }
            }

            gamePCAttackParams.Rows[4].Cells[38].Value = 10; //make fog attacks break objects

            gameParamBND.Files.Find(n => n.Name.Contains("ItemLotParam.param")).Bytes = gameItemParams.Write();
            gameParamBND.Files.Find(n => n.Name.Contains("AtkParam_Pc.param")).Bytes = gamePCAttackParams.Write();
            gameParamBND.Write("../param/GameParam/GameParam.parambnd");
            Console.WriteLine("Item Params installed...");

            #endregion

            #region Event Installation

            int checkEvent = gameEventFile.Events.FindIndex(e => e.ID == 6900000);
            if (checkEvent != -1)
            {
                gameEventFile.Events[checkEvent] = defaultEventFile.Events[0];
            }
            else
            {
                gameEventFile.Events.Add(defaultEventFile.Events[0]);
            }
            
            for (int i = 0; i < itemLotIDs.Length; i++)
            {
                EMEVD.Instruction currentInitInstruction = new EMEVD.Instruction(2000, 0);
                currentInitInstruction.PackArgs(new object[] { i, 6900000, entityIDs[i], itemLotIDs[i] });
                gameEventFile.Events[0].Instructions.Add(currentInitInstruction);
            }

            gameEventFile.Write("../event/common.emevd", DCX.Type.None);
            Console.WriteLine("Events Written...");

            #endregion

            #region MSB entityID setting

            foreach (string key in mapFileEntityIDs.Keys)
            {
                MSB1 currentMSB = MSB1.Read(msbPath + key);
                foreach (MSB1.Part.Object obj in currentMSB.Parts.Objects)
                {
                    if (objectModelNames.Contains(obj.ModelName))
                    {
                        if (obj.EntityID == -1)
                        {
                            obj.EntityID = mapFileEntityIDs[key];
                        }
                    }

                }
                currentMSB.Write(msbPath + key, DCX.Type.None);
            }
            Console.WriteLine("MSB modified...");
            #endregion

            Console.Write("Done. Press enter to exit.");
            Console.Read();
        }



    }
}
