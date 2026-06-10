---
title: Excel-diagramok létrehozása és beágyazása OLE-objektumként VSTO és Aspose.Slides for .NET használatával
linktitle: Excel-diagramok létrehozása és beágyazása OLE-objektumként
type: docs
weight: 70
url: /hu/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- diagram létrehozása
- Excel-diagram beágyazása
- OLE-objektum
- migráció
- VSTO
- Office automatizálás
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Migráljon a Microsoft Office automatizálásról az Aspose.Slides for .NET-re, és ágyazza be az Excel-diagramokat OLE-objektumként a PowerPoint (PPT, PPTX) diákba C#-ban."
---
{{% alert color="primary" %}} 

A diagramok az adataid vizuális ábrázolásai, és széles körben használják őket a prezentációs diákban. Ez a cikk bemutatja a kódot, amely programozott módon létrehozza és beágyazza egy Excel-diagramot OLE‑objektumként a PowerPoint-diára a [VSTO](/slides/hu/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) és a [Aspose.Slides for .NET](/slides/hu/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) használatával.

{{% /alert %}} 
## **Excel-diagram létrehozása és beágyazása**
Az alábbi két kódpélda hosszú és részletes, mert a feladat, amelyet leírnak, összetett. Létrehoz egy Microsoft Excel munkafüzetet, egy diagramot, majd egy Microsoft PowerPoint prezentációt, amelybe beágyazza a diagramot. Az OLE‑objektumok hivatkozásokat tartalmaznak az eredeti dokumentumra, így a beágyazott fájlt duplán kattintva a felhasználó elindítja a fájlt és annak alkalmazását.
## **VSTO példa**
A VSTO használatával a következő lépések hajtódnak végre:

1. Hozzon létre egy példányt a Microsoft Excel ApplicationClass objektumból.
1. Hozzon létre egy új munkafüzetet egy munkalappal.
1. Adjon hozzá diagramot a munkalaphoz.
1. Mentse a munkafüzetet.
1. Nyissa meg azt az Excel-munkafüzetet, amely tartalmazza a diagramadatokkal rendelkező munkalapot.
1. Szerezze meg a ChartObjects gyűjteményt a munkalaphoz.
1. Szerezze meg a másolni kívánt diagramot.
1. Hozzon létre egy Microsoft PowerPoint prezentációt.
1. Adjon hozzá egy üres diát a prezentációhoz.
1. Másolja a diagramot az Excel-munkalapról a vágólapra.
1. Illessze be a diagramot a PowerPoint-prezentációba.
1. Pozicionálja a diagramot a dián.
1. Mentse a prezentációt.

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
    // Deklaráljon egy változót az Excel ApplicationClass példányához.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Deklaráljon változókat a Workbooks.Open metódus paramétereihez.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Deklaráljon változókat a Chart.ChartWizard metódushoz.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Hozzon létre egy példányt az Excel ApplicationClass objektumból.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Hozzon létre egy új munkafüzetet 1 munkalappal.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Módosítsa a munkalap nevét.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // Szúrjon be adatokat a diagramhoz a munkalapra.
        //              A       B       C       D       E
        //     1                Q1      Q2      Q3      Q4
        //     2    Észak-Amerika  1.5     2       1.5     2.5
        //     3    Dél-Amerika  2       1.75    2       2
        //     4    Európa      2.25    2       2.5     2
        //     5    Ázsia        2.5     2.5     2       2.75

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

        // Szerezze meg a diagram adatokat tartalmazó tartományt.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Szerezze meg a ChartObjects gyűjteményt a munkalaphoz.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Adjon hozzá egy diagramot a gyűjteményhez.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // Hozzon létre egy új diagramot az adatokból.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Mentse el a munkafüzetet.
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
            // Zárja be az Excelt.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Deklaráljon változókat, amelyek a PowerPoint objektumokra mutató hivatkozásokat tárolják.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Deklaráljon változókat, amelyek az Excel objektumokra mutató hivatkozásokat tárolják.
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
        // Hozzon létre egy PowerPoint példányt.
        powerpointApplication = new pptNS.ApplicationClass();

        // Hozzon létre egy Excel példányt.
        excelApplication = new xlNS.ApplicationClass();

        // Nyissa meg az Excel munkafüzetet, amely a diagram adatokat tartalmazó munkalapot tartalmazza.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Szerezze meg a diagramot tartalmazó munkalapot.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // Szerezze meg a munkalap ChartObjects gyűjteményét.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Szerezze meg a másolni kívánt diagramot.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // Hozzon létre egy PowerPoint prezentációt.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Adjon hozzá egy üres diát a prezentációhoz.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Másolja a diagramot az Excel munkalapról a vágólapra.
        existingChartObject.Copy();

        // Illessze be a diagramot a PowerPoint prezentációba.
        shapeRange = pptSlide.Shapes.Paste();

        // Pozicionálja a diagramot a dián.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Mentse el a prezentációt.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Szabadítsa fel a PowerPoint dia objektumot.
        shapeRange = null;
        pptSlide = null;

        // Zárja be és szabadítsa fel a Presentation objektumot.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Zárja be a PowerPoint-ot és szabadítsa fel az ApplicationClass objektumot.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Szabadítsa fel az Excel objektumokat.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Zárja be és szabadítsa fel az Excel Workbook objektumot.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Zárja be az Excelt és szabadítsa fel az ApplicationClass objektumot.
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




## **Aspose.Slides for .NET példa**
Az Aspose.Slides for .NET használatával a következő lépések hajtódnak végre:

1. Hozzon létre egy munkafüzetet az Aspose.Cells for .NET használatával.
1. Hozzon létre egy Microsoft Excel diagramot.
1. Állítsa be az Excel-diagram OLE méretét.
1. Szerezzen képet a diagramról.
1. Ágyazza be az Excel-diagramot OLE‑objektumként egy PPTX prezentációba az Aspose.Slides for .NET használatával.
1. Cserélje le a megváltozott objektum képét a 3. lépésben kapott képre, hogy megoldja az objektum megváltozott problémáját.
1. Írja a kimeneti prezentációt lemezre PPTX formátumban.



```c#
//1. lépés: Excel-diagram létrehozása az Aspose.Cells használatával
//--------------------------------------------------
//Munkafüzet létrehozása
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Excel-diagram hozzáadása
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//2. lépés: A diagram OLE-méretének beállítása az Aspose.Cells használatával
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//3. lépés: A diagram képének lekérése az Aspose.Cells segítségével
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Munkafüzet mentése folyamathoz
MemoryStream wbStream = wb.SaveToStream();
//4. és 5. lépés
//-----------------------------------------------------------
//4. lépés: A diagram beágyazása OLE-objektumként .ppt prezentációba az Aspose.Slides használatával
//-----------------------------------------------------------
//5. lépés: Az objektumváltás problémájának megoldásához cserélje ki a módosított objektum képét a 3. lépésben kapott képre
//-----------------------------------------------------------
//Prezentáció létrehozása
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Munkafüzet hozzáadása a diára
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//6. lépés: A kimeneti prezentáció írása lemezre
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
    //Cellanevek tömbje
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Cellaadatok tömbje
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Új munkalap hozzáadása a cellák adatainak feltöltéséhez
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Adatok feltöltése a DataSheet munkalapra
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Diagrammunkalap hozzáadása
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Diagram hozzáadása a ChartSheet munkalapra a DataSheet sorozataival
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //ChartSheet beállítása aktív munkalapként
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```