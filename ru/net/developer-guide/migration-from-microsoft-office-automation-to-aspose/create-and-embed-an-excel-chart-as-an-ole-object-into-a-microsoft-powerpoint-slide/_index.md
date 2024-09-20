---
title: Создание и встраивание диаграммы Excel в виде OLE-объекта на слайд Microsoft PowerPoint
type: docs
weight: 70
url: /net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 Диаграммы являются визуальными представлениями ваших данных и широко используются в слайдах презентаций. В этой статье мы покажем вам код для создания и встраивания диаграммы Excel в виде OLE-объекта в слайд PowerPoint программно, используя [VSTO](/slides/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) и [Aspose.Slides для .NET](/slides/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Создание и встраивание диаграммы Excel**
Два примера кода ниже длинные и подробные, поскольку задача, которую они описывают, связана с множеством шагов. Вы создаете рабочую книгу Microsoft Excel, создаете диаграмму, а затем создаете презентацию Microsoft PowerPoint, в которую вы встроите диаграмму. OLE-объекты содержат ссылки на оригинальный документ, поэтому пользователь, дважды щелкнув на встроенном файле, запустит файл и его приложение.
## **Пример VSTO**
С использованием VSTO выполняются следующие шаги:

1. Создайте экземпляр объекта Microsoft Excel ApplicationClass.
1. Создайте новую книгу с одним листом.
1. Добавьте диаграмму на лист.
1. Сохраните книгу.
1. Откройте рабочую книгу Excel, содержащую лист с данными диаграммы.
1. Получите коллекцию ChartObjects для листа.
1. Получите диаграмму для копирования.
1. Создайте презентацию Microsoft PowerPoint.
1. Добавьте пустой слайд в презентацию.
1. Скопируйте диаграмму из рабочей книги Excel в буфер обмена.
1. Вставьте диаграмму в презентацию PowerPoint.
1. Расположите диаграмму на слайде.
1. Сохраните презентацию.

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
    // Объявите переменную для экземпляра Excel ApplicationClass.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Объявите переменные для параметров метода Workbooks.Open.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Объявите переменные для метода Chart.ChartWizard.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Продажи по кварталам";
    object paramCategoryTitle = "Финансовый квартал";
    object paramValueTitle = "Миллиарды";

    try
    {
        // Создайте экземпляр объекта Excel ApplicationClass.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Создайте новую книгу с 1 листом в ней.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Измените имя листа.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Квартальные продажи";

        // Вставьте некоторые данные для диаграммы на лист.
        //              A       B       C       D       E
        //     1                Q1      Q2      Q3      Q4
        //     2    С. Америка  1.5     2       1.5     2.5
        //     3    Ю. Америка  2       1.75    2       2
        //     4    Европа      2.25    2       2.5     2
        //     5    Азия        2.5     2.5     2       2.75

        SetCellValue(targetSheet, "A2", "С. Америка");
        SetCellValue(targetSheet, "A3", "Ю. Америка");
        SetCellValue(targetSheet, "A4", "Европа");
        SetCellValue(targetSheet, "A5", "Азия");

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

        // Получите диапазон, содержащий данные диаграммы.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Получите коллекцию ChartObjects для листа.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Добавьте диаграмму в коллекцию.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Диаграмма продаж";

        // Создайте новую диаграмму данных.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Сохраните книгу.
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
            // Закройте Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Объявите переменные для хранения ссылок на объекты PowerPoint.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Объявите переменные для хранения ссылок на объекты Excel.
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
        // Создайте экземпляр PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // Создайте экземпляр Excel.
        excelApplication = new xlNS.ApplicationClass();

        // Откройте рабочую книгу Excel, содержащую лист с данными диаграммы.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Получите рабочий лист, который содержит диаграмму.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Квартальные продажи"]);

        // Получите коллекцию ChartObjects для листа.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Получите диаграмму для копирования.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Диаграмма продаж"));

        // Создайте презентацию PowerPoint.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Добавьте пустой слайд в презентацию.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Скопируйте диаграмму из рабочей книги Excel в буфер обмена.
        existingChartObject.Copy();

        // Вставьте диаграмму в презентацию PowerPoint.
        shapeRange = pptSlide.Shapes.Paste();

        // Расположите диаграмму на слайде.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Сохраните презентацию.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Освободите объект слайда PowerPoint.
        shapeRange = null;
        pptSlide = null;

        // Закройте и освободите объект Презентации.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Закройте PowerPoint и освободите объект ApplicationClass.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Освободите Excel-объекты.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Закройте и освободите объект рабочей книги Excel.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Закройте Excel и освободите объект ApplicationClass.
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




## **Пример Aspose.Slides для .NET**
С использованием Aspose.Slides для .NET выполняются следующие шаги:

1. Создайте книгу, используя Aspose.Cells для .NET.
1. Создайте диаграмму Microsoft Excel.
1. Установите размер OLE диаграммы Excel.
1. Получите изображение диаграммы.
1. Встроить диаграмму Excel в виде OLE-объекта в презентацию PPTX с использованием Aspose.Slides для .NET.
1. Замените изображение измененного объекта на изображение, полученное на шаге 3, чтобы решить проблему изменения объекта.
1. Запишите выходную презентацию на диск в формате PPTX.



```c#
//Шаг 1: Создайте диаграмму Excel с использованием Aspose.Cells
//--------------------------------------------------
//Создайте книгу
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Добавьте диаграмму Excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Шаг 2: Установите размер OLE для диаграммы, используя Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Шаг 3: Получите изображение диаграммы с помощью Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Сохраните книгу в поток
MemoryStream wbStream = wb.SaveToStream();
//Шаги 4 И 5
//-----------------------------------------------------------
//Шаг 4: Внедрите диаграмму в виде OLE-объекта в презентацию .ppt с использованием Aspose.Slides
//-----------------------------------------------------------
//Шаг 5: Замените изображение измененного объекта на изображение, полученное на шаге 3, чтобы решить проблему изменения объекта
//-----------------------------------------------------------
//Создайте презентацию
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Добавьте книгу на слайд
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Шаг 6: Запишите выходную презентацию на диск
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
static void AddExcelChartInPresentation(Presentation pres, ISlide sld, Stream wbStream, Bitmap imgChart)
{
    float oleWidth = pres.SlideSize.Size.Width;
    float oleHeight = pres.SlideSize.Size.Height;
    int x = 0;
    byte[] chartOleData = new byte[wbStream.Length];
    wbStream.Position = 0;
    wbStream.Read(chartOleData, 0, chartOleData.Length);
    
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oof = null;
    oof = sld.Shapes.AddOleObjectFrame(x, 0, oleWidth, oleHeight, dataInfo);
    oof.SubstitutePictureFormat.Picture.Image = pres.Images.AddImage((System.Drawing.Image)imgChart);
}
```

```c#
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook wb, int chartRows, int chartCols)
{
    //Массив имен ячеек
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Массив данных ячеек
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Добавьте новый рабочий лист, чтобы заполнить ячейки данными
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Заполните DataSheet данными
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Добавьте лист диаграммы
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Добавьте диаграмму на ChartSheet с серией данных из DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Установите ChartSheet как активный лист
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```