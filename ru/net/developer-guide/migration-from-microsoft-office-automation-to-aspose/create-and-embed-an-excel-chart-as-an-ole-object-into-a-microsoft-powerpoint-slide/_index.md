---
title: Создание и внедрение диаграмм Excel в виде OLE-объектов с использованием VSTO и Aspose.Slides for .NET
linktitle: Создание и внедрение диаграмм Excel в виде OLE-объектов
type: docs
weight: 70
url: /ru/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- создать диаграмму
- встроить диаграмму Excel
- OLE-объект
- миграция
- VSTO
- автоматизация Office
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Перейдите от автоматизации Microsoft Office к Aspose.Slides for .NET и внедрите диаграммы Excel в виде OLE-объектов в слайды PowerPoint (PPT, PPTX) на C#."
---

{{% alert color="primary" %}} 

 Диаграммы — это визуальные представления ваших данных, широко используемые в презентационных слайдах. В этой статье показан код для создания и внедрения диаграммы Excel в качестве OLE‑объекта в слайд PowerPoint программно с использованием [VSTO](/slides/ru/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) и [Aspose.Slides for .NET](/slides/ru/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Создание и внедрение диаграммы Excel**
Два примера кода ниже длинные и подробные, потому что описываемая задача комплексна. Вы создаёте книгу Microsoft Excel, создаёте диаграмму, а затем создаёте презентацию Microsoft PowerPoint, в которую внедрите диаграмму. OLE‑объекты содержат ссылки на оригинальный документ, поэтому пользователь, дважды щёлкнув встраиваемый файл, запустит файл и его приложение.
## **Пример VSTO**
При работе с VSTO выполняются следующие шаги:

1. Создайте экземпляр объекта Microsoft Excel ApplicationClass.
1. Создайте новую книгу с одним листом.
1. Добавьте диаграмму на лист.
1. Сохраните книгу.
1. Откройте книгу Excel, содержащую лист с данными диаграммы.
1. Получите коллекцию ChartObjects для листа.
1. Получите диаграмму для копирования.
1. Создайте презентацию Microsoft PowerPoint.
1. Добавьте пустой слайд в презентацию.
1. Скопируйте диаграмму с листа Excel в буфер обмена.
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
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Создайте экземпляр объекта Excel ApplicationClass.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Создайте новую книгу с 1 листом.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Переименуйте лист.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // Вставьте некоторые данные для диаграммы в лист.
        //              A       B       C       D       E
        //     1                Q1      Q2      Q3      Q4
        //     2    Северная Америка  1.5     2       1.5     2.5
        //     3    Южная Америка  2       1.75    2       2
        //     4    Европа      2.25    2       2.5     2
        //     5    Азия        2.5     2.5     2       2.75

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

        // Получите диапазон, содержащий данные диаграммы.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Получите коллекцию ChartObjects для листа.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Добавьте диаграмму в коллекцию.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // Создайте новую диаграмму на основе данных.
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

        // Откройте книгу Excel, содержащую лист с данными для диаграммы.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Получите лист, содержащий диаграмму.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // Получите коллекцию ChartObjects для листа.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Получите диаграмму для копирования.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // Создайте презентацию PowerPoint.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Добавьте пустой слайд в презентацию.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Скопируйте диаграмму с листа Excel в буфер обмена.
        existingChartObject.Copy();

        // Вставьте диаграмму в презентацию PowerPoint.
        shapeRange = pptSlide.Shapes.Paste();

        // Разместите диаграмму на слайде.
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

        // Закройте и освободите объект Presentation.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Завершите работу PowerPoint и освободите объект ApplicationClass.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Освободите объекты Excel.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Закройте и освободите объект книги Excel.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Завершите работу Excel и освободите объект ApplicationClass.
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





## **Пример Aspose.Slides for .NET**
При работе с Aspose.Slides for .NET выполняются следующие шаги:

1. Создайте книгу с помощью Aspose.Cells for .NET.
1. Создайте диаграмму Microsoft Excel.
1. Задайте размер OLE‑объекта диаграммы Excel.
1. Получите изображение диаграммы.
1. Внедрите диаграмму Excel в качестве OLE‑объекта в презентацию PPTX с помощью Aspose.Slides for .NET.
1. Замените изменённое изображение объекта полученным на шаге 3, чтобы решить проблему изменения объекта.
1. Запишите полученную презентацию на диск в формате PPTX.
```c#
//Шаг - 1: Создать диаграмму Excel с помощью Aspose.Cells
//--------------------------------------------------
//Создать книгу
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Добавить диаграмму Excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Шаг - 2: Установить размер OLE диаграммы с помощью Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Шаг - 3: Получить изображение диаграммы с помощью Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Сохранить книгу в поток
MemoryStream wbStream = wb.SaveToStream();
//Шаг - 4 И 5
//-----------------------------------------------------------
//Шаг - 4: Встроить диаграмму как OLE объект в презентацию .ppt с использованием Aspose.Slides
//-----------------------------------------------------------
//Шаг - 5: Заменить изображение изменённого объекта полученным на шаге 3, чтобы решить проблему изменения объекта
//-----------------------------------------------------------
//Создать презентацию
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Добавить книгу на слайд
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Шаг - 6: Записать полученную презентацию на диск
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
    //Массив имён ячеек
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
    //Добавить новый лист для заполнения ячеек данными
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Заполнить лист DataSheet данными
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Добавить лист с диаграммой
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Добавить диаграмму на лист ChartSheet с рядами данных из листа DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Установить лист ChartSheet активным листом
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```
