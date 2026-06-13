---
title: ایجاد نمودارهای Excel و جاسازی آن‌ها به‌عنوان اشیای OLE در ارائه‌ها
type: docs
weight: 50
url: /fa/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- نمودار Excel
- جاسازی نمودار
- شیء OLE
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ایجاد نمودارهای Excel و جاسازی آن‌ها به‌عنوان اشیای OLE در ارائه‌های PowerPoint و OpenDocument با C#/.NET. راهنمای گام به گام با نمونه‌های کد."
---
## **پیش‌زمینه**

در PowerPoint، استفاده از نمودارهای قابل ویرایش برای نمایش داده‌ها به صورت گرافیکی یک روش متداول است. Aspose از ایجاد نمودارهای Excel با Aspose.Cells برای .NET پشتیبانی می‌کند و این نمودارها می‌توانند به‌عنوان اشیای OLE در اسلایدهای PowerPoint از طریق Aspose.Slides برای .NET جاسازی شوند. این مقاله گام‌های لازم را پوشش می‌دهد و نمونه‌های کد C# را برای ایجاد یک نمودار Excel و جاسازی آن به‌عنوان شیء OLE در یک ارائه PowerPoint با استفاده از Aspose.Cells و Aspose.Slides ارائه می‌کند.

## **مراحل مورد نیاز**

1. یک نمودار Excel را با استفاده از Aspose.Cells ایجاد کنید.
1. اندازه OLE نمودار Excel را با استفاده از Aspose.Cells تنظیم کنید.
1. یک تصویر از نمودار Excel با Aspose.Cells دریافت کنید.
1. نمودار Excel را به‌عنوان شیء OLE در یک ارائه PPTX با استفاده از Aspose.Slides جاسازی کنید.
1. تصویر «EMBEDDED OLE OBJECT» را با تصویری که در گام 3 به‌دست آمده است جایگزین کنید تا به مشکل [مشکل پیش‌نمایش شیء](/slides/fa/net/object-preview-issue-when-adding-oleobjectframe/) پرداخته شود.
1. ارائه را به‌صورت فایل PPTX بر روی دیسک ذخیره کنید.

## **پیاده‌سازی مراحل مورد نیاز**

پیاده‌سازی C# مراحل فوق به شرح زیر است:

```cs
// مرحله - 1: ایجاد یک نمودار Excel با استفاده از Aspose.Cells.
// ---------------------------------------------------
// یک کتاب کار ایجاد کنید.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// یک نمودار Excel اضافه کنید.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// مرحله - 2: تنظیم اندازه OLE نمودار با استفاده از Aspose.Cells.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// مرحله - 3: دریافت تصویر نمودار با Aspose.Cells.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// کتاب کار را به یک جریان ذخیره کنید.
MemoryStream workbookStream = workbook.SaveToStream();

// مرحله - 4 و 5
// ==============
// مرحله - 4: جاسازی نمودار به‌عنوان شیء OLE داخل ارائه .ppt با استفاده از Aspose.Slides.
// ------------------------------------------------------------------------------------------
// مرحله - 5: تصویر "EMBEDDED OLE OBJECT" را با تصویری که در مرحله 3 به‌دست آمده است جایگزین کنید تا مشکل پیش‌نمایش شیء رفع شود.
// --------------------------------------------------------------------------------------------------------------------
 // یک ارائه ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // کتاب کار را به اسلاید اضافه کنید.
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // مرحله - 6: ذخیره ارائه خروجی در دیسک.
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // آرایه‌ای از نام‌های سلول.
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // آرایه‌ای از داده‌های سلول.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // اضافه کردن یک برگه کاری جدید برای پر کردن سلول‌ها با داده‌ها.
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // پر کردن برگه داده‌ها با داده‌ها.
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // افزودن یک برگه نمودار.
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // افزودن یک نمودار به برگه نمودار با سری داده‌ها از برگه داده.
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // تنظیم برگه نمودار به عنوان برگه فعال.
    workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
    return chartSheetIndex;
}
```

```cs
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] oleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(oleData, 0, oleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	    imageStream.Position = 0;
        IPPImage ppImage = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

ارائه‌ای که با روش بالا ایجاد می‌شود، شامل نمودار Excel به‌عنوان شیء OLE خواهد بود که می‌توان با دوبار کلیک بر روی فریم شیء OLE آن را فعال کرد.

## **نتیجه‌گیری**

با استفاده از Aspose.Cells برای .NET همراه با Aspose.Slides برای .NET، می‌توان هر نمودار Excel که توسط Aspose.Cells پشتیبانی می‌شود را ایجاد کرده و به‌عنوان شیء OLE در یک اسلاید PowerPoint جاسازی کرد. اندازه OLE نمودار Excel نیز می‌تواند تعریف شود. کاربران نهایی می‌توانند سپس نمودار Excel را همانند هر شیء OLE دیگری ویرایش کنند.

## **بخش‌های مرتبط**

- [راه‌حل کارآمد برای تغییر اندازه نمودار در PPTX](/slides/fa/net/working-solution-for-chart-resizing-in-pptx/)
- [مشکل پیش‌نمایش شیء هنگام افزودن OleObjectFrame](/slides/fa/net/object-preview-issue-when-adding-oleobjectframe/)
- [به‌روزرسانی خودکار اشیای OLE با استفاده از افزودنی PowerPoint](/slides/fa/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)