using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCNNImages
{
    class Event
    {
        public string csvIndex { get; set; }

        public string matchId { get; set; }

        public string id { get; set; }

        public string index { get; set; }

        public string period { get; set; }

        public string minute { get; set; }

        public string second { get; set; }

        public string locationX { get; set; }

        public string locationY { get; set; }

        public string passEndLocX { get; set; }

        public string passEndLocY { get; set; }

        public string carryEndLoc { get; set; }

        public string carryEndLocX { get; set; }

        public string carryEngLocY { get; set; }

        public string shotEndLocX { get; set; }

        public string shotEndLocY { get; set; }

        public string possession { get; set; }

        public string typeName { get; set; }

        public string poseessionTeamName { get; set; }

        public string playPattern { get; set; }

        public string teamName { get; set; }


        public string passHeight { get; set; }

        public string underPressure { get; set; }

        public string dribbleOutcome { get; set; }

        public string counterPress { get; set; }

        public string duelType { get; set; }

        public string duelOutcome { get; set; }

        public string passOutcome { get; set; }

        public string clearanceBodyPart { get; set; }




        public static List<List<Event>> ReadExcelFile(string fileName, string sheetName)
        {
            List<Event> eventList = new List<Event>();
            List<List<Event>> eventSortedList = new List<List<Event>>();
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
            {
                SharedStringTable sharedStringTable = spreadsheetDocument.WorkbookPart.SharedStringTablePart.SharedStringTable;

                string cellText = null;

                //Return the excel sheet
                WorksheetPart worksheetPart = GetWorksheetPartByName(spreadsheetDocument, sheetName);

                foreach (SheetData sheetData in worksheetPart.Worksheet.Elements<SheetData>())
                {
                    if (sheetData.HasChildren)
                    {
                        int rowCnt = 0;
                        foreach (Row row in sheetData.Elements<Row>())
                        {
                            if (rowCnt > 0 && rowCnt < 1000)
                            {

                                Event eventInfo = new Event();
                                int cIdx = 0;
                                foreach (Cell cell in row.Elements<Cell>())
                                {
                                    if (cell.DataType != null && cell.DataType == "s")
                                    {
                                        cellText = sharedStringTable.ElementAt(Int32.Parse(cell.CellValue.Text)).InnerText;
                                    }
                                    //else if (cell.CellValue != null && Convert.ToDouble(cell.CellValue.InnerText) > 300)
                                    //{
                                    //    string dateString = DateTime.FromOADate(Convert.ToDouble(cell.CellValue.InnerText)).ToString();
                                    //    string[] stringSplit = dateString.Split(' ');
                                    //    cellText = stringSplit.First();
                                    //}
                                    else
                                    {
                                        cellText = Convert.ToDouble(cell.CellValue.InnerText).ToString();
                                    }
                                PopulatePlayerInformation(eventInfo, cIdx, cellText);
                                    cIdx += 1;
                                }
                                eventList.Add(eventInfo);

                            }
                            rowCnt += 1;

                        }
                    }
                }

                eventSortedList = eventList.GroupBy(x => new { x.matchId, x.possession}).Select(g => g.ToList()).ToList();
            }

            return eventSortedList;
        }

        private static WorksheetPart GetWorksheetPartByName(SpreadsheetDocument document, string sheetName)
        {
            IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().Where(p => p.Name == sheetName);

            string relationshipId = sheets.First().Id.Value;
            WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(relationshipId);
            return worksheetPart;
        }

        private static void PopulatePlayerInformation(Event eventInfo, int cIdx, string cellText)
        {
            if (cIdx == 0)
            {
                eventInfo.csvIndex = cellText;
            }

            if (cIdx == 1)
            {
                eventInfo.id = cellText;
            }

            if (cIdx == 2)
            {
                eventInfo.index = cellText;
            }

            if (cIdx == 3)
            {
                eventInfo.period = cellText;
            }

            if (cIdx == 4)
            {
                eventInfo.minute = cellText;
            }

            if (cIdx == 5)
            {
                eventInfo.second = cellText;
            }

            if (cIdx == 6)
            {
                eventInfo.possession = cellText;
            }

            if (cIdx == 7)
            {
                eventInfo.typeName = cellText;
            }

            if (cIdx == 8)
            {
                eventInfo.poseessionTeamName = cellText;
            }

            if (cIdx == 9)
            {
                eventInfo.playPattern = cellText;
            }

            if (cIdx == 10)
            {
                eventInfo.teamName = cellText;
            }

            if (cIdx == 11)
            {
                string[] locations = cellText.Split(',');
                string xloc = locations[0].Replace("[", "");
                if (locations.Count() > 1)
                {
                    string yloc = locations[1].Replace("]", "");
                    eventInfo.locationY = yloc;
                }
                eventInfo.locationX = xloc;

            }

            if (cIdx == 12)
            {
                eventInfo.passHeight = cellText;
            }

            if (cIdx == 13)
            {
                string[] locations = cellText.Split(',');
                string xloc = locations[0].Replace("[", "");
                if (locations.Count() > 1)
                {
                    string yloc = locations[1].Replace("]", "");
                    eventInfo.passEndLocY = yloc;
                }
                eventInfo.passEndLocX = xloc;
            }

            if (cIdx == 14)
            {
                string[] locations = cellText.Split(',');
                string xloc = locations[0].Replace("[", "");
                if (locations.Count() > 1)
                {
                    string yloc = locations[1].Replace("]", "");
                    eventInfo.carryEngLocY = yloc;
                }
                eventInfo.carryEndLocX = xloc;
            }

            if (cIdx == 15)
            {
                string[] locations = cellText.Split(',');
                string xloc = locations[0].Replace("[", "");
                if (locations.Count() > 1)
                {
                    string yloc = locations[1].Replace("]", "");
                    eventInfo.shotEndLocY = yloc;
                }
                eventInfo.shotEndLocX = xloc;
            }

            if (cIdx == 16)
            {
                eventInfo.matchId = cellText;
            }

        }

    }
}
