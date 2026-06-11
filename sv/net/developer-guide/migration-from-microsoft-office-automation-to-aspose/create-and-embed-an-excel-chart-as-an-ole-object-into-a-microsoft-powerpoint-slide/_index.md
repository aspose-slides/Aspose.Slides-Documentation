---
title: Skapa och bädda in Excel-diagram som OLE-objekt med VSTO och Aspose.Slides för .NET
linktitle: Skapa och bädda in Excel-diagram som OLE-objekt
type: docs
weight: 70
url: /sv/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- skapa diagram
- bädda in Excel-diagram
- OLE-objekt
- migration
- VSTO
- Office-automatisering
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Migrera från Microsoft Office-automatisering till Aspose.Slides för .NET och bädda in Excel-diagram som OLE-objekt i PowerPoint (PPT, PPTX)-bilder i C#."
---
{{% alert color="primary" %}} 

Diagram är visuella representationer av dina data och används ofta i presentationsbilder. Den här artikeln visar dig koden för att skapa och bädda in ett Excel-diagram som ett OLE-objekt i en PowerPoint-bild programmässigt genom att använda [VSTO](/slides/sv/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) och [Aspose.Slides for .NET](/slides/sv/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Skapa och bädda in ett Excel-diagram**
De två kodexemplen nedanför är långa och detaljerade eftersom uppgiften de beskriver är omfattande. Du skapar en Microsoft Excel-arbetsbok, skapar ett diagram och sedan skapar du Microsoft PowerPoint-presentationen som du ska bädda in diagrammet i. OLE-objekt innehåller länkar till det ursprungliga dokumentet så en användare som dubbelklickar på den inbäddade filen kommer att starta filen och dess program.

## **VSTO-exempel**
Med VSTO utförs följande steg:

1. Skapa en instans av Microsoft Excel ApplicationClass-objektet.
1. Skapa en ny arbetsbok med ett blad i.
1. Lägg till ett diagram på bladet.
1. Spara arbetsboken.
1. Öppna Excel‑arbetsboken som innehåller arbetsbladet med diagramdata.
1. Hämta ChartObjects‑samlingen för bladet.
1. Hämta diagrammet som ska kopieras.
1. Skapa en Microsoft PowerPoint-presentation.
1. Lägg till en tom bild i presentationen.
1. Kopiera diagrammet från Excel‑arbetsbladet till urklipp.
1. Klistra in diagrammet i PowerPoint-presentationen.
1. Placera diagrammet på bilden.
1. Spara presentationen.

```c#
CreateNewChartInExcel();
UseCopyPaste();
```

```c#
static void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)
{
    targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);
}
```

```c#
static void CreateNewChartInExcel()
{
    // Deklarera en variabel för Excel ApplicationClass-instansen.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Deklarera variabler för parametrarna till Workbooks.Open-metoden.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Deklarera variabler för Chart.ChartWizard-metoden.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Skapa en instans av Excel ApplicationClass-objektet.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Skapa en ny arbetsbok med ett blad i.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Ändra bladets namn.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // Infoga lite data för diagrammet i bladet.
        //              A       B       C       D       E
        //     1                Q1      Q2      Q3      Q4
        //     2    N. America  1.5     2       1.5     2.5
        //     3    S. America  2       1.75    2       2
        //     4    Europe      2.25    2       2.5     2
        //     5    Asia        2.5     2.5     2       2.75

        SetCellValue(targetSheet, "A2", "N. America");
        SetCellValue(targetSheet, "A3", "S. America");
        SetCellValue(targetSheet, "A4", "Europe");
        SetCellValue(targetSheet, "A5", "Asia");

        SetCellValue(targetSheet, "B1", "Q1");
        SetCellValue(targetSheet, "B2", 1.5);
        SetCellValue(targetSheet, "B3", 2);
        SetCellValue(targetSheet, "B4", 2.25);
        SetCellValue(targetSheet, "B5", 2.5);

        SetCellValue(targetSheet, "C1", "Q2");
        SetCellValue(targetSheet, "C2", 2);
        SetCellValue(targetSheet, "C3", 1.75);
        SetCellValue(targetSheet, "C4", 2);
        SetCellValue(targetSheet, "C5", 2.5);

        SetCellValue(targetSheet, "D1", "Q3");
        SetCellValue(targetSheet, "D2", 1.5);
        SetCellValue(targetSheet, "D3", 2);
        SetCellValue(targetSheet, "D4", 2.5);
        SetCellValue(targetSheet, "D5", 2);

        SetCellValue(targetSheet, "E1", "Q4");
        SetCellValue(targetSheet, "E2", 2.5);
        SetCellValue(targetSheet, "E3", 2);
        SetCellValue(targetSheet, "E4", 2);
        SetCellValue(targetSheet, "E5", 2.75);

        // Hämta intervallet som innehåller diagramdata.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Hämta ChartObjects-samlingen för bladet.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Lägg till ett diagram i samlingen.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // Skapa ett nytt diagram av data.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Spara arbetsboken.
        newWorkbook.SaveAs(paramWorkbookPath, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, xlNS.XlSaveAsAccessMode.xlNoChange, paramMissing, paramMissing, paramMissing, paramMissing, paramMissing);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        if (excelApplication != null)
        {
            // Stäng Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Deklarera variabler för att hålla referenser till PowerPoint-objekt.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Deklarera variabler för att hålla referenser till Excel-objekt.
    xlNS.ApplicationClass excelApplication = null;
    xlNS.Workbook excelWorkBook = null;
    xlNS.Worksheet targetSheet = null;
    xlNS.ChartObjects chartObjects = null;
    xlNS.ChartObject existingChartObject = null;

    string paramPresentationPath = Application.StartupPath + @"\ChartTest.pptx";
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    try
    {
        // Skapa en instans av PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // Skapa en instans av Excel.
        excelApplication = new xlNS.ApplicationClass();

        // Öppna Excel-arbetsboken som innehåller arbetsbladet med diagramdata.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Hämta arbetsbladet som innehåller diagrammet.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // Hämta ChartObjects-samlingen för bladet.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Hämta diagrammet som ska kopieras.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // Skapa en PowerPoint-presentation.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Lägg till en tom bild i presentationen.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Kopiera diagrammet från Excel-arbetsbladet till urklipp.
        existingChartObject.Copy();

        // Klistra in diagrammet i PowerPoint-presentationen.
        shapeRange = pptSlide.Shapes.Paste();

        // Placera diagrammet på bilden.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Spara presentationen.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Frigör PowerPoint-bildobjektet.
        shapeRange = null;
        pptSlide = null;

        // Stäng och frigör Presentation-objektet.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Avsluta PowerPoint och frigör ApplicationClass-objektet.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Frigör Excel-objekten.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Stäng och frigör Excel-arbetsbok-objektet.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Avsluta Excel och frigör ApplicationClass-objektet.
        if (excelApplication != null)
        {
            excelApplication.Quit();
            excelApplication = null;
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
```




## **Aspose.Slides for .NET‑exempel**
Med Aspose.Slides for .NET utförs följande steg:

1. Skapa en arbetsbok med Aspose.Cells for .NET.
1. Skapa ett Microsoft Excel-diagram.
1. Ange OLE‑storleken för Excel-diagrammet.
1. Hämta en bild av diagrammet.
1. Bädda in Excel-diagrammet som ett OLE‑objekt i PPTX-presentationen med Aspose.Slides for .NET.
1. Ersätt den förändrade objektbilden med bilden som erhölls i steg 3 för att hantera problemet med ändrat objekt.
1. Skriv utdata‑presentationen till disk i PPTX‑format.

```c#
//Steg - 1: Skapa ett excel diagram med Aspose.Cells
//--------------------------------------------------
//Skapa en arbetsbok
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Lägg till ett excel diagram
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Steg - 2: Ställ in OLE storleken för diagrammet med Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Steg - 3: Hämta bilden av diagrammet med Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Spara arbetsboken till en ström
MemoryStream wbStream = wb.SaveToStream();
//Steg - 4  OCH 5
//-----------------------------------------------------------
//Steg - 4: Bädda in diagrammet som ett OLE objekt i .ppt presentation med Aspose.Slides
//-----------------------------------------------------------
//Steg - 5: Ersätt den ändrade objektbilden med bilden erhållen i steg 3 för att hantera Object Changed Issue
//-----------------------------------------------------------
//Skapa en presentation
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Lägg till arbetsboken på bilden
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Steg - 6: Skriv utdata presentation till disk
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] chartOleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(chartOleData, 0, chartOleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	imageStream.Position = 0;
        IPPImage image = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = image;
    }
}
```

```c#
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook wb, int chartRows, int chartCols)
{
    //Array med cellnamn
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Array med celldata
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Lägg till ett nytt arbetsblad för att fylla celler med data
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Fyll DataSheet med data
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Lägg till ett diagramark
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Lägg till ett diagram i ChartSheet med dataserier från DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Ställ in ChartSheet som aktivt blad
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```