---
title: Maak en embed Excel-grafieken als OLE-objecten met VSTO en Aspose.Slides voor .NET
linktitle: Maak en embed Excel-grafieken als OLE-objecten
type: docs
weight: 70
url: /nl/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- grafiek maken
- Excel-grafiek insluiten
- OLE-object
- migratie
- VSTO
- Office-automatisering
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Migreer van Microsoft Office-automatisering naar Aspose.Slides voor .NET en embed Excel-grafieken als OLE-objecten in PowerPoint (PPT, PPTX)-dia's in C#."
---
{{% alert color="primary" %}} 

Grafieken zijn visuele weergaven van uw gegevens en worden veel gebruikt in presentatieslides. In dit artikel wordt de code getoond om een Excel‑grafiek als OLE‑object in een PowerPoint‑dia in te voegen en te embedden via [VSTO](/slides/nl/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) en [Aspose.Slides for .NET](/slides/nl/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Een Excel‑grafiek maken en insluiten**
De twee code‑voorbeelden hieronder zijn lang en gedetailleerd omdat de beschreven taak complex is. U maakt een Microsoft Excel‑werkmap, maakt een grafiek en maakt vervolgens de Microsoft PowerPoint‑presentatie waarin u de grafiek gaat insluiten. OLE‑objecten bevatten koppelingen naar het oorspronkelijke document, zodat een gebruiker die dubbelklikt op het ingebedde bestand het bestand en de bijbehorende applicatie start.
## **VSTO‑voorbeeld**
Met VSTO worden de volgende stappen uitgevoerd:

1. Maak een instantie van het Microsoft Excel ApplicationClass‑object.
1. Maak een nieuwe werkmap met één blad.
1. Voeg een grafiek toe aan het blad.
1. Sla de werkmap op.
1. Open de Excel‑werkmap die het werkblad met de grafiekgegevens bevat.
1. Haal de ChartObjects‑collectie op voor het blad.
1. Haal de te kopiëren grafiek op.
1. Maak een Microsoft PowerPoint‑presentatie.
1. Voeg een lege dia toe aan de presentatie.
1. Kopieer de grafiek van het Excel‑werkblad naar het klembord.
1. Plak de grafiek in de PowerPoint‑presentatie.
1. Positioneer de grafiek op de dia.
1. Sla de presentatie op.

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
    // Declareer een variabele voor de Excel ApplicationClass-instantie.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Declareer variabelen voor de parameters van de Workbooks.Open-methode.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Declareer variabelen voor de Chart.ChartWizard-methode.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Maak een instantie van het Excel ApplicationClass-object.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Maak een nieuwe werkmap met 1 blad.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Verander de naam van het blad.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // Voeg wat gegevens voor de grafiek toe aan het blad.
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

        // Haal het bereik op dat de grafiekgegevens bevat.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Haal de ChartObjects-collectie op voor het blad.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Voeg een grafiek toe aan de collectie.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // Maak een nieuwe grafiek van de gegevens.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Sla de werkmap op.
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
            // Sluit Excel af.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Declareer variabelen om referenties naar PowerPoint-objecten vast te leggen.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Declareer variabelen om referenties naar Excel-objecten vast te leggen.
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
        // Maak een instantie van PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // Maak een instantie van Excel.
        excelApplication = new xlNS.ApplicationClass();

        // Open de Excel-werkmap die het werkblad met de grafiekgegevens bevat.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Haal het werkblad op dat de grafiek bevat.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // Haal de ChartObjects-collectie op voor het blad.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Haal de te kopiëren grafiek op.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // Maak een PowerPoint-presentatie.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Voeg een lege dia toe aan de presentatie.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Kopieer de grafiek van het Excel-werkblad naar het klembord.
        existingChartObject.Copy();

        // Plak de grafiek in de PowerPoint-presentatie.
        shapeRange = pptSlide.Shapes.Paste();

        // Positioneer de grafiek op de dia.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Sla de presentatie op.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Maak het PowerPoint-dias-object vrij.
        shapeRange = null;
        pptSlide = null;

        // Sluit en maak het Presentation-object vrij.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Sluit PowerPoint en maak het ApplicationClass-object vrij.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Maak de Excel-objecten vrij.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Sluit en maak het Excel-werkmap-object vrij.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Sluit Excel en maak het ApplicationClass-object vrij.
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




## **Aspose.Slides voor .NET‑voorbeeld**
Met Aspose.Slides voor .NET worden de volgende stappen uitgevoerd:

1. Maak een werkmap met Aspose.Cells voor .NET.
1. Maak een Microsoft Excel‑grafiek.
1. Stel de OLE‑grootte van de Excel‑grafiek in.
1. Haal een afbeelding van de grafiek op.
1. Integreer de Excel‑grafiek als OLE‑object in een PPTX‑presentatie met behulp van Aspose.Slides voor .NET.
1. Vervang de afbeelding van het gewijzigde object door de afbeelding die in stap 3 is verkregen om het probleem met gewijzigde objecten op te lossen.
1. Schrijf de uitvoerpresentatie naar schijf in PPTX‑formaat.



```c#
//Stap - 1: Maak een Excel-grafiek met Aspose.Cells
//--------------------------------------------------
//Maak een werkmap
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Voeg een Excel-grafiek toe
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Stap - 2: Stel de OLE-grootte van de grafiek in met Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Stap - 3: Haal de afbeelding van de grafiek op met Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Sla de werkmap op in een stream
MemoryStream wbStream = wb.SaveToStream();
//Stap - 4  EN 5
//-----------------------------------------------------------
//Stap - 4: Embed de grafiek als OLE-object in een .ppt-presentatie met Aspose.Slides
//-----------------------------------------------------------
//Stap - 5: Vervang de afbeelding van het gewijzigde object door de afbeelding die in stap 3 is verkregen om het Object Changed-probleem op te lossen
//-----------------------------------------------------------
//Maak een presentatie
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Voeg de werkmap toe aan de dia
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Stap - 6: Schrijf de uitvoerpresentatie naar schijf
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
    //Array van celnamen
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Array van celgegevens
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Voeg een nieuw werkblad toe om cellen met gegevens te vullen
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Vul DataSheet met gegevens
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Voeg een grafiekblad toe
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Voeg een grafiek toe in ChartSheet met gegevensreeksen van DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Maak ChartSheet het actieve blad
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```