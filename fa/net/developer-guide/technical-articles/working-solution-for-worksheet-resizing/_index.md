---
title: راه‌حل عملی برای تغییر اندازه کاربرگ
type: docs
weight: 40
url: /fa/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- تصویر پیش‌نمایش
- تغییر اندازه تصویر
- Excel
- کاربرگ
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "رفع تغییر اندازه OLE کاربرگ Excel در ارائه‌ها: دو روش برای حفظ سازگاری فریم‌های شیء—مقیاس‌بندی فریم یا برگه—در فرمت‌های PPT و PPTX."
---
{{% alert color="info" %}} 
مشاهده شده است که برگه‌های Excel که به عنوان اشیاء OLE در یک ارائه PowerPoint از طریق مؤلفه‌های Aspose جاسازی می‌شوند، پس از اولین فعال‌سازی به مقیاسی نامشخص تغییر اندازه می‌دهند. این رفتار تفاوت بصری قابل‌توجهی در ارائه بین وضعیت‌های قبل و بعد از فعال‌سازی شیء OLE ایجاد می‌کند. ما این مشکل را به‌صورت جزئی بررسی کردیم و راهحلی ارائه دادیم که در این مقاله پوشش داده شده است.
{{% /alert %}} 

## **پیش‌زمینه**

در مقاله [مدیریت OLE](/slides/fa/net/manage-ole/)، ما توضیح دادیم که چگونه یک فریم OLE را به یک ارائه PowerPoint با استفاده از Aspose.Slides for .NET اضافه کنیم. برای رفع [مشکل پیش‌نمایش شیء](/slides/fa/net/object-preview-issue-when-adding-oleobjectframe/)، تصویر ناحیه برگه منتخب را به فریم شیء OLE اختصاص دادیم. در ارائه خروجی، وقتی بر روی فریم شیء OLE که تصویر برگه را نشان می‌دهد دوبار کلیک کنید، کتاب‌کار Excel فعال می‌شود. کاربران نهایی می‌توانند هر تغییر دلخواهی را در کتاب‌کار واقعی Excel اعمال کنند و سپس با کلیک خارج از کتاب‌کار فعال‌شده به اسلاید بازگردند. اندازه فریم شیء OLE هنگام بازگشت کاربر به اسلاید تغییر خواهد کرد. عامل تغییر اندازه بسته به اندازه فریم شیء OLE و کتاب‌کار Excel جاسازی‌شده متفاوت خواهد بود. 

## **دلیل تغییر اندازه**

از آنجایی که کتاب‌کار Excel اندازه پنجره خودش را دارد، سعی می‌کند هنگام اولین فعال‌سازی اندازه اصلی خود را حفظ کند. از سوی دیگر، فریم شیء OLE دارای اندازه‌ای مستقل است. بر اساس گفته Microsoft، زمانی که کتاب‌کار Excel فعال می‌شود، Excel و PowerPoint برای اطمینان از حفظ نسبت‌های صحیح در فرآیند جاسازی، درباره اندازه مذاکره می‌کنند. تغییر اندازه بر پایهٔ تفاوت‌های بین اندازه پنجره Excel و اندازه و موقعیت فریم شیء OLE انجام می‌شود. 

## **راه‌حل عملی**

دو راه‌حل ممکن برای جلوگیری از اثر تغییر اندازه وجود دارد.

- اندازه فریم OLE را در ارائه PowerPoint مقیاس‌بندی کنید تا با ارتفاع و عرض تعداد ردیف‌ها و ستون‌های موردنظر در فریم OLE مطابقت داشته باشد.  
- اندازه فریم OLE را ثابت نگه دارید و اندازه ردیف‌ها و ستون‌های شرکت‌کننده را مقیاس‌بندی کنید تا داخل اندازه فریم OLE انتخاب‌شده جای بگیرد.  

### **مقیاس‌بندی اندازه فریم OLE**

در این روش، می‌آموزیم که چگونه اندازه فریم OLE کتاب‌کار Excel جاسازی‌شده را طوری تنظیم کنیم که با اندازهٔ تجمعی ردیف‌ها و ستون‌های شرکت‌کننده در برگه Excel مطابقت داشته باشد.

فرض کنید یک برگه الگو Excel داریم و می‌خواهیم آن را به عنوان فریم OLE به ارائه اضافه کنیم. در این سناریو، ابتدا اندازه فریم شیء OLE بر پایهٔ مجموع ارتفاع ردیف‌ها و عرض ستون‌های شرکت‌کننده در کتاب‌کار محاسبه می‌شود. سپس، اندازه فریم OLE را به این مقدار محاسبه‌شده تنظیم می‌کنیم. برای جلوگیری از نمایش پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، یک تصویر از بخش‌های موردنظر ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و آن را به عنوان تصویر فریم OLE تنظیم می‌کنیم.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// تنظیم اندازهٔ نمایش هنگام استفاده از فایل کتاب‌کار به‌عنوان شیء OLE در PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// دریافت عرض و ارتفاع تصویر OLE به واحد نقطه.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// ما نیاز داریم از کتاب‌کار تغییر یافته استفاده کنیم.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// اضافه کردن تصویر OLE به منابع ارائه.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// ایجاد فریم شیء OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **مقیاس‌بندی اندازه بازه سلولی**

در این روش، می‌آموزیم که چگونه ارتفاع ردیف‌های شرکت‌کننده و عرض ستون‌های شرکت‌کننده را طوری مقیاس‌بندی کنیم که با یک اندازهٔ سفارشی فریم OLE مطابقت داشته باشد.

فرض کنید یک برگه الگو Excel داریم و می‌خواهیم آن را به عنوان فریم OLE به ارائه اضافه کنیم. در این سناریو، اندازه فریم OLE را تنظیم می‌کنیم و اندازه ردیف‌ها و ستون‌هایی که در ناحیه فریم OLE شرکت دارند را مقیاس‌بندی می‌کنیم. سپس کتاب‌کار را به یک جریان (stream) ذخیره می‌کنیم تا تغییرات اعمال شده و آن را به یک آرایهٔ بایتی تبدیل می‌کنیم تا به فریم OLE اضافه شود. برای جلوگیری از نمایش پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، یک تصویر از بخش‌های موردنظر ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و آن را به عنوان تصویر فریم OLE تنظیم می‌کنیم.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// تنظیم اندازهٔ نمایش زمانی که فایل کتاب‌کار به‌عنوان شیء OLE در PowerPoint استفاده می‌شود.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// مقیاس‌بندی بازهٔ سلولی برای تطبیق با اندازهٔ فریم.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// ما نیاز داریم از کتاب‌کار تغییر یافته استفاده کنیم.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// اضافه کردن تصویر OLE به منابع ارائه.
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">پهنای مورد انتظار بازهٔ سلولی بر حسب نقطه.</param>
/// <param name="height">ارتفاع مورد انتظار بازهٔ سلولی بر حسب نقطه.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **نتیجه‌گیری**

{{% alert color="info" %}}
دو رویکرد برای رفع مشکل تغییر اندازه برگه وجود دارد. انتخاب رویکرد مناسب بستگی به نیازها و موارد استفاده خاص دارد. هر دو رویکرد به‌یک‌سان کار می‌کنند، چه ارائه‌ها از یک الگو ساخته شوند و چه از ابتدا. علاوه بر این، در این راه‌حل هیچ محدودیتی برای اندازه فریم شیء OLE وجود ندارد.
{{% /alert %}}

## **پرسش‌های متداول**

### چرا یک برگه Excel جاسازی‌شده هنگام اولین فعال‌سازی در PowerPoint اندازه‌اش تغییر می‌کند؟
این اتفاق به‌این دلیل می‌افتد که Excel سعی می‌کند هنگام فعال‌سازی اندازهٔ اصلی پنجرهٔ خود را حفظ کند، در حالی که فریم شیء OLE در PowerPoint ابعاد مستقلی دارد. PowerPoint و Excel دربارهٔ اندازه مذاکره می‌کنند تا نسبت تصویر را حفظ کنند، که می‌تواند منجر به تغییر اندازه شود.

### آیا می‌توان این مشکل تغییر اندازه را به‌طور کامل جلوگیری کرد؟
بله. با مقیاس‌بندی فریم OLE برای مطابقت با اندازهٔ بازه سلولی Excel یا مقیاس‌بندی بازه سلولی برای مطابقت با اندازهٔ دلخواه فریم OLE، می‌توانید از تغییر اندازه نخواسته جلوگیری کنید.

### کدام روش مقیاس‌بندی را باید انتخاب کنم، مقیاس‌بندی فریم OLE یا مقیاس‌بندی بازه سلولی؟
اگر می‌خواهید اندازه‌های اصلی ردیف‌ها و ستون‌های Excel را حفظ کنید، **مقیاس‌بندی فریم OLE** را انتخاب کنید. اگر می‌خواهید یک اندازهٔ ثابت برای فریم OLE در ارائه داشته باشید، **مقیاس‌بندی بازه سلولی** را انتخاب کنید.

### آیا این راه‌حل‌ها وقتی ارائه من بر پایهٔ یک الگو باشد کار می‌کنند؟
بله. هر دو راه‌حل برای ارائه‌های ساخته‌شده از الگوها و همچنین ارائه‌های ساخته‌شده از ابتدا کار می‌کنند.

### آیا محدودیتی برای اندازه فریم OLE هنگام استفاده از این روش‌ها وجود دارد؟
خیر. می‌توانید فریم شیء OLE را به هر اندازه‌ای که می‌خواهید تنظیم کنید، به‌شرط آن که مقیاس را به‌درستی تنظیم کنید.

### آیا راهی برای جلوگیری از متن جایگزین «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟
بله. با گرفتن یک اسنپ‌شات از بازه سلولی هدف در Excel و تنظیم آن به‌عنوان تصویر جایگزین فریم OLE، می‌توانید یک تصویر پیش‑نمایش سفارشی به‌جای متن پیش‌فرض نمایش دهید.

## **مقالات مرتبط**

[ایجاد نمودار Excel و جاسازی آن در ارائه به‌عنوان شیء OLE](/slides/fa/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[به‌روزرسانی خودکار اشیاء OLE با استفاده از افزودنی MS PowerPoint](/slides/fa/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)