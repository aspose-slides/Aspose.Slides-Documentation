---
title: Vytvoření a vložení grafů Excelu jako OLE objektů pomocí VSTO a Aspose.Slides pro .NET
linktitle: Vytvoření a vložení grafů Excelu jako OLE objektů
type: docs
weight: 70
url: /cs/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- vytvořit graf
- vložit graf Excelu
- OLE objekt
- migrace
- VSTO
- automatizace Office
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přesuňte se z automatizace Microsoft Office na Aspose.Slides pro .NET a vložte grafy Excelu jako OLE objekty do snímků PowerPoint (PPT, PPTX) v C#."
---
{{% alert color="primary" %}} 
Grafy jsou vizuálními reprezentacemi vašich dat a jsou široce používány v prezentačních snímcích. Tento článek vám ukáže kód pro vytvoření a vložení grafu Excelu jako OLE objektu do snímku PowerPointu programově pomocí [VSTO](/slides/cs/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) a [Aspose.Slides for .NET](/slides/cs/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).
{{% /alert %}} 
## **Vytvoření a vložení grafu Excelu**
Dva níže uvedené příklady kódu jsou dlouhé a podrobné, protože úloha, kterou popisují, je složitá. Vytvoříte sešit Microsoft Excel, vytvoříte graf a poté vytvoříte prezentaci Microsoft PowerPoint, do které graf vložíte. OLE objekty obsahují odkazy na originální dokument, takže uživatel, který dvakrát klikne na vložený soubor, spustí soubor a jeho aplikaci.
## **Příklad VSTO**
Pomocí VSTO jsou provedeny následující kroky:

1. Vytvořte instanci objektu Microsoft Excel ApplicationClass.
1. Vytvořte nový sešit s jedním listem.
1. Přidejte graf do listu.
1. Uložte sešit.
1. Otevřete sešit Excelu obsahující list s daty grafu.
1. Získejte kolekci ChartObjects pro list.
1. Získejte graf, který se má kopírovat.
1. Vytvořte prezentaci Microsoft PowerPoint.
1. Přidejte prázdný snímek do prezentace.
1. Zkopírujte graf z listu Excelu do schránky.
1. Vložte graf do prezentace PowerPoint.
1. Umístěte graf na snímek.
1. Uložte prezentaci.

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
    // Deklarujte proměnnou pro instanci třídy Excel ApplicationClass.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Deklarujte proměnné pro parametry metody Workbooks.Open.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Deklarujte proměnné pro metodu Chart.ChartWizard.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Vytvořte instanci objektu Excel ApplicationClass.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Vytvořte nový sešit s 1 listem.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Změňte název listu.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // Vložte některá data pro graf do listu.
        //              A       B       C       D       E
        //     1                Q1      Q2      Q3      Q4
        //     2    Severní Amerika  1.5     2       1.5     2.5
        //     3    Jižní Amerika  2       1.75    2       2
        //     4    Evropa      2.25    2       2.5     2
        //     5    Asie        2.5     2.5     2       2.75

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

        // Získejte oblast obsahující data grafu.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Získejte kolekci ChartObjects pro list.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Přidejte graf do kolekce.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // Vytvořte nový graf z dat.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Uložte sešit.
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
            // Uzavřete Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Deklarujte proměnné pro uchování referencí na objekty PowerPoint.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Deklarujte proměnné pro uchování referencí na objekty Excel.
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
        // Vytvořte instanci PowerPointu.
        powerpointApplication = new pptNS.ApplicationClass();

        // Vytvořte instanci Excelu.
        excelApplication = new xlNS.ApplicationClass();

        // Otevřete sešit Excelu obsahující list s daty grafu.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Získejte list, který obsahuje graf.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // Získejte kolekci ChartObjects pro list.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Získejte graf ke kopírování.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // Vytvořte prezentaci PowerPoint.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Přidejte prázdný snímek do prezentace.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Zkopírujte graf z listu Excelu do schránky.
        existingChartObject.Copy();

        // Vložte graf do prezentace PowerPoint.
        shapeRange = pptSlide.Shapes.Paste();

        // Umístěte graf na snímek.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Uložte prezentaci.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Uvolněte objekt snímku PowerPoint.
        shapeRange = null;
        pptSlide = null;

        // Uzavřete a uvolněte objekt Presentation.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Ukončete PowerPoint a uvolněte objekt ApplicationClass.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Uvolněte objekty Excel.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Uzavřete a uvolněte objekt Workbook Excelu.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Ukončete Excel a uvolněte objekt ApplicationClass.
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

## **Příklad Aspose.Slides pro .NET**
Pomocí Aspose.Slides pro .NET jsou provedeny následující kroky:

1. Vytvořte sešit pomocí Aspose.Cells pro .NET.
1. Vytvořte graf Microsoft Excel.
1. Nastavte velikost OLE grafu Excel.
1. Získejte obrázek grafu.
1. Vložte graf Excelu jako OLE objekt do prezentace PPTX pomocí Aspose.Slides pro .NET.
1. Nahraďte obrázek změněného objektu obrázkem získaným ve kroku 3, aby se vyřešil problém se změněným objektem.
1. Zapište výstupní prezentaci na disk ve formátu PPTX.

```c#
//Krok - 1: Vytvořte graf v Excelu pomocí Aspose.Cells
//--------------------------------------------------
//Vytvořte sešit
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Přidejte graf Excelu
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Krok - 2: Nastavte velikost OLE grafu. pomocí Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Krok - 3: Získejte obrázek grafu pomocí Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Uložte sešit do proudu
MemoryStream wbStream = wb.SaveToStream();
//Krok - 4 a 5
//-----------------------------------------------------------
//Krok - 4: Vložte graf jako OLE objekt do prezentace .ppt pomocí Aspose.Slides
//-----------------------------------------------------------
//Krok - 5: Nahraďte obrázek změněného objektu obrázkem získaným ve kroku 3, aby se vyřešil problém se změněným objektem
//-----------------------------------------------------------
//Vytvořte prezentaci
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Přidejte sešit na snímek
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Krok - 6: Zapište výstupní prezentaci na disk
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
    //Pole názvů buněk
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Pole dat buněk
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Přidejte nový list pro naplnění buněk daty
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Naplněte DataSheet daty
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Přidejte list s grafem
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Přidejte graf do ChartSheet s datovými sériemi z DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Nastavte ChartSheet jako aktivní list
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```