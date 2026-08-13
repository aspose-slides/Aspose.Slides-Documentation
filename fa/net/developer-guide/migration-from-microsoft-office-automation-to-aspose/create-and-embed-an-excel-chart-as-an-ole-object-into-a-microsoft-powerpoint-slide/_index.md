---
title: ایجاد و جاسازی نمودارهای Excel به عنوان اشیاء OLE با استفاده از VSTO و Aspose.Slides برای .NET
linktitle: ایجاد و جاسازی نمودارهای Excel به عنوان اشیاء OLE
type: docs
weight: 70
url: /fa/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- ایجاد نمودار
- جاسازی نمودار Excel
- شیء OLE
- مهاجرت
- VSTO
- اتوماسیون Office
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "از اتوماسیون Microsoft Office به Aspose.Slides برای .NET مهاجرت کنید و نمودارهای Excel را به عنوان اشیاء OLE در اسلایدهای PowerPoint (PPT، PPTX) با C# جاسازی نمایید."
---
{{% alert color="info" %}} 
نمودارها نمایه‌های تصویری داده‌های شما هستند و به‌طور گسترده‌ای در اسلایدهای ارائه استفاده می‌شوند. این مقاله کد ایجاد و جاسازی یک نمودار Excel به عنوان یک شیء OLE در اسلاید PowerPoint را به‌صورت برنامه‌نویسی با استفاده از [VSTO](/slides/fa/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) و [Aspose.Slides for .NET](/slides/fa/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) نشان می‌دهد.
{{% /alert %}} 
## **ایجاد و جاسازی یک نمودار Excel**
دو مثال کد زیر طولانی و جزئی هستند زیرا کاری که توصیف می‌کنند پیچیده است. شما یک کتاب کار Microsoft Excel ایجاد می‌کنید، یک نمودار می‌سازید و سپس ارائه Microsoft PowerPoint که نمودار را در آن جاسازی می‌کنید، می‌سازید. اشیاء OLE شامل لینک‌هایی به سند اصلی هستند، بنابراین کاربری که بر روی فایل جاسازی شده دوبار کلیک کند، فایل و برنامهٔ آن را اجرا می‌کند.
## **مثال VSTO**
Using VSTO, the following steps are performed:

1. یک نمونه از شیء Microsoft Excel ApplicationClass ایجاد کنید.
1. یک کتاب کار جدید با یک صفحه درون آن ایجاد کنید.
1. نمودار را به صفحه اضافه کنید.
1. کتاب کار را ذخیره کنید.
1. کتاب کار Excel حاوی صفحه کاری که داده‌های نمودار در آن هستند را باز کنید.
1. مجموعه ChartObjects را برای صفحه دریافت کنید.
1. نموداری را که می‌خواهید کپی کنید، دریافت کنید.
1. یک ارائه Microsoft PowerPoint ایجاد کنید.
1. یک اسلاید خالی به ارائه اضافه کنید.
1. نمودار را از صفحهٔ کاری Excel به کلیپ‌بورد کپی کنید.
1. نمودار را در ارائه PowerPoint بچسبانید.
1. نمودار را بر روی اسلاید قرار دهید.
1. ارائه را ذخیره کنید.

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
    // یک متغیر برای نمونهٔ Excel ApplicationClass اعلام کنید.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // متغیرهای مربوط به پارامترهای متد Workbooks.Open را اعلام کنید.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // متغیرهای مربوط به متد Chart.ChartWizard را اعلام کنید.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // یک نمونه از شیء Excel ApplicationClass ایجاد کنید.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // یک کتاب‌کار جدید با یک شیت ایجاد کنید.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // نام شیت را تغییر دهید.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // برخی داده‌ها را برای نمودار در شیت وارد کنید.
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

        // دامنه‌ای که داده‌های نمودار را در بر دارد، دریافت کنید.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // مجموعهٔ ChartObjects را برای شیت دریافت کنید.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // یک نمودار به مجموعه اضافه کنید.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // یک نمودار جدید از داده‌ها ایجاد کنید.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // کتاب‌کار را ذخیره کنید.
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
            // Excel را ببندید.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // متغیرهایی را برای نگه‌داری مراجع به اشیاء PowerPoint اعلام کنید.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // متغیرهایی را برای نگه‌داری مراجع به اشیاء Excel اعلام کنید.
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
        // یک نمونه از PowerPoint ایجاد کنید.
        powerpointApplication = new pptNS.ApplicationClass();

        // یک نمونه از Excel ایجاد کنید.
        excelApplication = new xlNS.ApplicationClass();

        // کتاب‌کار Excel حاوی شیتی که داده‌های نمودار در آن هستند را باز کنید.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // شیتی که شامل نمودار است را دریافت کنید.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // مجموعهٔ ChartObjects را برای شیت دریافت کنید.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // نموداری که می‌خواهید کپی کنید را دریافت کنید.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // یک ارائه PowerPoint ایجاد کنید.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // یک اسلاید خالی به ارائه اضافه کنید.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // نمودار را از شیت Excel به کلیپ‌بورد کپی کنید.
        existingChartObject.Copy();

        // نمودار را در ارائه PowerPoint بچسبانید.
        shapeRange = pptSlide.Shapes.Paste();

        // نمودار را بر روی اسلاید قرار دهید.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // ارائه را ذخیره کنید.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // شیء اسلاید PowerPoint را آزاد کنید.
        shapeRange = null;
        pptSlide = null;

        // شیء Presentation را ببندید و آزاد کنید.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // PowerPoint را ببندید و شیء ApplicationClass را آزاد کنید.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // اشیاء Excel را آزاد کنید.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // شیء Workbook Excel را ببندید و آزاد کنید.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Excel را ببندید و شیء ApplicationClass را آزاد کنید.
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

## **مثال Aspose.Slides for .NET**
Using Aspose.Slides for .NET, the following steps are performed:

1. یک کتاب کار با استفاده از Aspose.Cells for .NET ایجاد کنید.
1. یک نمودار Microsoft Excel ایجاد کنید.
1. اندازه OLE نمودار Excel را تنظیم کنید.
1. یک تصویر از نمودار دریافت کنید.
1. نمودار Excel را به‌عنوان یک شیء OLE داخل ارائهٔ PPTX با استفاده از Aspose.Slides for .NET جاسازی کنید.
1. تصویر تغییر یافتهٔ شیء را با تصویری که در گام 3 به‌دست آمده است جایگزین کنید تا مشکل تغییر شیء رفع شود.
1. ارائهٔ خروجی را به‌صورت فایل PPTX بر روی دیسک بنویسید.



```c#
using System.Drawing;
using Aspose.Slides;

//مرحله - 1: ایجاد یک نمودار اکسل با استفاده از Aspose.Cells
//--------------------------------------------------
//یک کتاب‌کار ایجاد کنید
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//یک نمودار اکسل اضافه کنید
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//مرحله - 2: تنظیم اندازه OLE نمودار با استفاده از Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//مرحله - 3: دریافت تصویر نمودار با Aspose.Cells
//-----------------------------------------------------------
MemoryStream chartImageStream = new MemoryStream();
wb.Worksheets[chartSheetIndex].Charts[0].ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
Bitmap imgChart = new Bitmap(chartImageStream);
//کتاب‌کار را به استریم ذخیره کنید
MemoryStream wbStream = wb.SaveToStream();
//مرحله - 4 و 5
//-----------------------------------------------------------
//مرحله - 4: جاسازی نمودار به عنوان شیء OLE داخل ارائه .ppt با استفاده از Aspose.Slides
//-----------------------------------------------------------
//مرحله - 5: جایگزینی تصویر تغییر یافتهٔ شیء با تصویری که در مرحله 3 به‌دست آمده برای رفع مشکل Object Changed
//-----------------------------------------------------------
//یک ارائه ایجاد کنید
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//کتاب‌کار را به اسلاید اضافه کنید
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//مرحله - 6: نوشتن ارائه خروجی بر روی دیسک
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

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
    // آرایه‌ای از نام‌های سلول
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    // آرایه‌ای از مقادیر سلول‌ها
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    // یک شیت جدید اضافه کنید تا سلول‌ها را با داده‌ها پر کنید
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    // پر کردن DataSheet با داده‌ها
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    // افزودن شیت نمودار
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    // اضافه کردن نمودار در ChartSheet با سری داده‌ها از DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    // تنظیم ChartSheet به عنوان شیت فعال
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```