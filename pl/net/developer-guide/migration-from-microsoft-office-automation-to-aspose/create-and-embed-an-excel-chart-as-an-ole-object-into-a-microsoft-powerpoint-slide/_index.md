---
title: Tworzenie i osadzanie wykresów Excel jako obiektów OLE przy użyciu VSTO i Aspose.Slides for .NET
linktitle: Tworzenie i osadzanie wykresów Excel jako obiektów OLE
type: docs
weight: 70
url: /pl/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- tworzenie wykresu
- osadzanie wykresu Excel
- obiekt OLE
- migracja
- VSTO
- automatyzacja Office
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Migruj z automatyzacji Microsoft Office do Aspose.Slides for .NET i osadzaj wykresy Excel jako obiekty OLE w slajdach PowerPoint (PPT, PPTX) w C#."
---
{{% alert color="primary" %}} 

Wykresy są wizualną reprezentacją Twoich danych i są szeroko stosowane w slajdach prezentacji. Ten artykuł pokaże Ci kod tworzący i osadzający wykres Excel jako obiekt OLE w slajdzie PowerPoint, programowo, przy użyciu [VSTO](/slides/pl/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) oraz [Aspose.Slides for .NET](/slides/pl/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Tworzenie i osadzanie wykresu Excel**
Dwa poniższe przykłady kodu są długie i szczegółowe, ponieważ opisują skomplikowane zadanie. Tworzysz skoroszyt Microsoft Excel, tworzysz wykres, a następnie tworzysz prezentację Microsoft PowerPoint, do której osadzisz wykres. Obiekty OLE zawierają odnośniki do oryginalnego dokumentu, więc użytkownik, który dwukrotnie kliknie osadzony plik, uruchomi plik i jego aplikację.
## **Przykład VSTO**
Korzystając z VSTO, wykonuje się następujące kroki:

1. Utwórz instancję obiektu Microsoft Excel ApplicationClass.
1. Utwórz nowy skoroszyt z jedną arkuszem.
1. Dodaj wykres do arkusza.
1. Zapisz skoroszyt.
1. Otwórz skoroszyt Excel zawierający arkusz z danymi wykresu.
1. Pobierz kolekcję ChartObjects dla arkusza.
1. Pobierz wykres do skopiowania.
1. Utwórz prezentację Microsoft PowerPoint.
1. Dodaj pusty slajd do prezentacji.
1. Skopiuj wykres z arkusza Excel do schowka.
1. Wklej wykres do prezentacji PowerPoint.
1. Umieść wykres na slajdzie.
1. Zapisz prezentację.

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
    // Zadeklaruj zmienną dla instancji klasy Excel ApplicationClass.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Zadeklaruj zmienne dla parametrów metody Workbooks.Open.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Zadeklaruj zmienne dla metody Chart.ChartWizard.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Utwórz instancję obiektu Excel ApplicationClass.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Utwórz nowy skoroszyt z 1 arkuszem.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Zmień nazwę arkusza.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // Wstaw nieco danych dla wykresu do arkusza.
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

        // Pobierz zakres zawierający dane wykresu.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Pobierz kolekcję ChartObjects dla arkusza.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Dodaj wykres do kolekcji.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // Utwórz nowy wykres z danych.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Zapisz skoroszyt.
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
            // Zamknij Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Zadeklaruj zmienne przechowujące referencje do obiektów PowerPoint.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Zadeklaruj zmienne przechowujące referencje do obiektów Excel.
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
        // Utwórz instancję PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // Utwórz instancję Excel.
        excelApplication = new xlNS.ApplicationClass();

        // Otwórz skoroszyt Excel zawierający arkusz z danymi wykresu.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Pobierz arkusz, który zawiera wykres.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // Pobierz kolekcję ChartObjects dla arkusza.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Pobierz wykres do skopiowania.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // Utwórz prezentację PowerPoint.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Dodaj pusty slajd do prezentacji.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Skopiuj wykres z arkusza Excel do schowka.
        existingChartObject.Copy();

        // Wklej wykres do prezentacji PowerPoint.
        shapeRange = pptSlide.Shapes.Paste();

        // Ustaw pozycję wykresu na slajdzie.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Zapisz prezentację.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Zwolnij obiekt slajdu PowerPoint.
        shapeRange = null;
        pptSlide = null;

        // Zamknij i zwolnij obiekt Presentation.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Zamknij PowerPoint i zwolnij obiekt ApplicationClass.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Zwolnij obiekty Excel.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Zamknij i zwolnij obiekt skoroszytu Excel.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Zamknij Excel i zwolnij obiekt ApplicationClass.
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




## **Przykład Aspose.Slides for .NET**
Korzystając z Aspose.Slides for .NET, wykonuje się następujące kroki:

1. Utwórz skoroszyt przy użyciu Aspose.Cells for .NET.
1. Utwórz wykres Microsoft Excel.
1. Ustaw rozmiar OLE wykresu Excel.
1. Uzyskaj obraz wykresu.
1. Osadź wykres Excel jako obiekt OLE w prezentacji PPTX przy użyciu Aspose.Slides for .NET.
1. Zastąp zmieniony obraz obiektu obrazem uzyskanym w kroku 3, aby rozwiązać problem zmiany obiektu.
1. Zapisz wynikową prezentację na dysk w formacie PPTX.



```c#
//Krok - 1: Utwórz wykres Excel przy użyciu Aspose.Cells
//--------------------------------------------------
//Utwórz skoroszyt
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Dodaj wykres Excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Krok - 2: Ustaw rozmiar OLE wykresu. przy użyciu Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Krok - 3: Pobierz obraz wykresu przy użyciu Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Zapisz skoroszyt do strumienia
MemoryStream wbStream = wb.SaveToStream();
//Krok - 4  I 5
//-----------------------------------------------------------
//Krok - 4: Osadź wykres jako obiekt OLE w prezentacji .ppt przy użyciu Aspose.Slides
//-----------------------------------------------------------
//Krok - 5: Zamień zmieniony obraz obiektu na obraz uzyskany w kroku 3, aby rozwiązać problem zmiany obiektu
//-----------------------------------------------------------
//Utwórz prezentację
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Dodaj skoroszyt na slajd
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Krok - 6: Zapisz wynikową prezentację na dysku
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
    //Tablica nazw komórek
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Tablica danych komórek
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Dodaj nowy arkusz, aby wypełnić komórki danymi
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Wypełnij DataSheet danymi
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Dodaj arkusz wykresu
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Dodaj wykres w ChartSheet z seriami danych z DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Ustaw ChartSheet jako aktywny arkusz
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```