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

            int[] defaultGoodsIncludedIDs = {
    230, 240, 270, 271, 272, 274, 275, 280, 290, 291, 292, 293, 294, 296, 297, 310, 311, 312, 313, 330, 350, 370,
    373, 374, 375, 376, 380, 381, 382, 383, 400, 401, 402, 403, 404, 405, 406, 407, 408, 409, 500, 501, 700, 701,
    702, 703, 704, 705, 706, 707, 708, 709, 710, 711, 1000, 1010, 1020, 1030, 1040, 1050, 1060, 1070, 1080, 1090,
    1100, 1110, 1120, 1130
};

            int[] arrowsWeaponIncludedIDs = {
    2000000, 2001000, 2002000, 2003000, 2004000, 2005000, 2006000, 2007000, 2008000, 2100000, 2101000,
    2102000, 2103000, 2104000
};

            int[] magicGoodsIncludedIDs = {
    3000, 3010, 3020, 3030, 3040, 3050, 3060, 3070, 3100, 3110, 3120, 3300, 3310, 3400, 3410, 3500, 3510, 3520,
    3530, 3540, 3550, 3810, 3700, 3710, 3720, 3730, 3740, 4000, 4010, 4020, 4030, 4040, 4050, 4060, 4100, 4110,
    4200, 4210, 4220, 4300, 4310, 4360, 4400, 4500, 4510, 4520, 4530, 5000, 5010, 5020, 5030, 5040, 5050, 5100,
    5110, 5210, 5300, 5310, 5320, 5400, 5500, 5510, 5520, 5600, 5610, 5700, 5800, 5810, 5900, 5910
 };

            int[] standardWeaponIncludedIDs = {
    100000, 101000, 102000, 103000, 104000, 200000, 201000, 202000, 203000, 204000, 205000, 206000, 207000,
    208000, 209000, 210000, 211000, 212000, 300000, 301000, 302000, 303000, 304000, 306000, 307000, 309000,
    310000, 311000, 314000, 350000, 351000, 352000, 354000, 355000, 400000, 401000, 402000, 403000, 405000,
    406000, 450000, 451000, 453000, 500000, 501000, 502000, 503000, 600000, 601000, 602000, 603000, 604000,
    700000, 701000, 702000, 703000, 704000, 705000, 750000, 751000, 752000, 753000, 800000, 801000, 802000,
    803000, 804000, 809000, 810000, 811000, 812000, 850000, 851000, 852000, 854000, 855000, 856000, 901000,
    902000, 903000, 904000, 1000000, 1001000, 1002000, 1003000, 1004000, 1050000, 1051000, 1052000, 1100000,
    1101000, 1102000, 1103000, 1105000, 1106000, 1107000, 1150000, 1151000, 1200000, 1201000, 1202000,
    1203000, 1204000, 1205000, 1250000, 1252000, 1253000, 1300000, 1301000, 1302000, 1303000, 1304000,
    1305000, 1306000, 1307000, 1308000, 1330000, 1332000, 1360000, 1361000, 1362000, 1363000, 1365000,
    1366000, 1367000, 1396000, 1400000, 1401000, 1402000, 1403000, 1404000, 1405000, 1406000, 1408000,
    1409000, 1410000, 1411000, 1450000, 1451000, 1452000, 1453000, 1454000, 1455000, 1456000, 1457000,
    1460000, 1462000, 1470000, 1471000, 1472000, 1473000, 1474000, 1475000, 1476000, 1477000, 1478000,
    1500000, 1501000, 1502000, 1503000, 1505000, 1506000, 1507000, 1600000, 1601000, 9000000, 9001000,
    9002000, 9003000, 9010000, 9011000, 9012000, 9014000, 9015000, 9016000, 9017000, 9018000, 9019000,
    9020000, 9021000
};

            int[] armorIDsRange = { 10000, 703000 }; //inclusive

            bool randomize = false, randomizeArmor = false;

            List<ItemEntry> randomItemCategoriesAndIDs = new List<ItemEntry>();

            Console.WriteLine("Dark Souls: Breakable Object Loot Mod v2.0\n");

            #region Game Check

            try
            {
                EMEVD fileCheck = EMEVD.Read("../event/common.emevd.dcx");
            }
            catch
            {
                Console.Write("Could not find essential files for installation. Please ensure this mod's folder is inside you game's \"DATA\" directory and that your game is unpacked using UDSFM.\n" +
                    "Press enter to exit ");
                Console.Read();
                return;
            }

            #endregion

            consoleInput = "";
            string[] acceptedInputs = { "1", "2", "3", "4", "5" };
            while (!acceptedInputs.Contains(consoleInput))
            {
                Console.WriteLine("Please type a number to select your installation preference:\n" +
                    "[1] = Regular Install\n" +
                    "[2] = Randomizer Install (items included)\n" +
                    "[3] = Randomizer Install (items and weapons included)\n" +
                    "[4] = Randomizer Install (items, weapons, and armor included\n" +
                    "[5] = Exit\n");
                Console.Write("Type a number to select your option then press ENTER: ");
                consoleInput = Console.ReadLine();
            }
            if (consoleInput == "5") return;
            


            switch (consoleInput)
            {
                case "1":
                    break;
                case "2":
                    randomize = true;
                    foreach (int id in defaultGoodsIncludedIDs)
                    {
                        randomItemCategoriesAndIDs.Add(new ItemEntry(1073741824, id));
                    }
                    foreach (int id in arrowsWeaponIncludedIDs)
                    {
                        randomItemCategoriesAndIDs.Add(new ItemEntry(0, id));
                    }
                    break;
                case "3":
                    randomize = true;
                    foreach (int id in defaultGoodsIncludedIDs)
                    {
                        randomItemCategoriesAndIDs.Add(new ItemEntry(1073741824, id));
                    }
                    foreach (int id in arrowsWeaponIncludedIDs)
                    {
                        randomItemCategoriesAndIDs.Add(new ItemEntry(0, id));
                    }
                    foreach (int id in standardWeaponIncludedIDs)
                    {
                        randomItemCategoriesAndIDs.Add(new ItemEntry(0, id));
                    }
                    break;
                case "4":
                    randomize = true;
                    foreach (int id in defaultGoodsIncludedIDs)
                    {
                        randomItemCategoriesAndIDs.Add(new ItemEntry(1073741824, id));
                    }
                    foreach (int id in arrowsWeaponIncludedIDs)
                    {
                        randomItemCategoriesAndIDs.Add(new ItemEntry(0, id));
                    }
                    foreach (int id in standardWeaponIncludedIDs)
                    {
                        randomItemCategoriesAndIDs.Add(new ItemEntry(0, id));
                    }
                    randomizeArmor = true;
                    break;
                default:
                    break;
            }

            #region Compatibility Check and File Declaration

            PARAM defaultModParams = PARAM.Read("resources/ItemLotParam.param");
            PARAMDEF itemParamDefs = PARAMDEF.Read(BND3.Read("../paramdef/paramdef.paramdefbnd.dcx").Files.Find(n => n.Name.Contains("ItemLotParam.paramdef")).Bytes);
            PARAMDEF pcAttackParamDefs = PARAMDEF.Read(BND3.Read("../paramdef/paramdef.paramdefbnd.dcx").Files.Find(n => n.Name.Contains("AtkParam.paramdef")).Bytes);
            BND3 gameParamBND = BND3.Read("../param/GameParam/GameParam.parambnd.dcx");
            PARAM gameItemParams = PARAM.Read(gameParamBND.Files.Find(n => n.Name.Contains("ItemLotParam.param")).Bytes);
            PARAM gamePCAttackParams = PARAM.Read(gameParamBND.Files.Find(n => n.Name.Contains("AtkParam_Pc.param")).Bytes);

            EMEVD defaultEventFile = EMEVD.Read("resources/eventfile.emevd");
            EMEVD gameEventFile = EMEVD.Read("../event/common.emevd.dcx");

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
                    consoleInput = Console.ReadLine();
                }
                if (consoleInput == "N" || consoleInput == "n")
                {
                    return;
                }
            }

            #endregion

            #region Param Installation

            if (randomizeArmor)
            {
                PARAM gameArmorParams = PARAM.Read(gameParamBND.Files.Find(n => n.Name.Contains("EquipParamProtector.param")).Bytes);
                List<int> armorIDs = new List<int>();
                int currentArmorIndex = armorIDsRange[0];
                while (currentArmorIndex >= armorIDsRange[0] && currentArmorIndex <= armorIDsRange[1])
                {
                    if (gameArmorParams.Rows.Exists(r => r.ID == currentArmorIndex))
                    {
                        armorIDs.Add(currentArmorIndex);
                    }
                    currentArmorIndex += 1000;
                }
                foreach (int id in armorIDs)
                {
                    randomItemCategoriesAndIDs.Add(new ItemEntry(268435456, id));
                }
            }

            Random rn = new Random();
            //apply itemlotparams
            for (int i = 0; i < itemLotIDs.Length; i++)
            {
                int checkRow = gameItemParams.Rows.FindIndex(r => r.ID == itemLotIDs[i]);
                PARAM.Row currentRow = defaultModParams.Rows.Find(r => r.ID == itemLotIDs[i]);
                if (randomize)
                {
                    
                    List<ItemEntry> closedSet = new List<ItemEntry>();
                    for (int j = 0; j < 6; j++)
                    {
                        
                        ItemEntry currentItemEntry = randomItemCategoriesAndIDs[rn.Next(0, randomItemCategoriesAndIDs.Count)];
                        while (closedSet.Contains(currentItemEntry))
                        {
                            currentItemEntry = randomItemCategoriesAndIDs[rn.Next(0, randomItemCategoriesAndIDs.Count)];
                        }
                        currentRow.Cells[0 + j].Value = currentItemEntry.itemID;
                        currentRow.Cells[8 + j].Value = currentItemEntry.category;
                        currentRow.Cells[44 + j].Value = 1;

                    }
                }
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
            gameParamBND.Write("../param/GameParam/GameParam.parambnd.dcx", DCX.Type.DCX_DFLT_10000_24_9);
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

            gameEventFile.Write("../event/common.emevd.dcx", DCX.Type.DCX_DFLT_10000_24_9);
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
                currentMSB.Write(msbPath + key);
            }
            Console.WriteLine("MSB modified...");
            #endregion

            Console.Write("Done. Press enter to exit.");
            Console.Read();
        }



    }
    
    class ItemEntry
    {
        public int category;
        public int itemID;
        public ItemEntry(int _category, int _itemID)
        {
            category = _category;
            itemID = _itemID;
        }
    }
}
