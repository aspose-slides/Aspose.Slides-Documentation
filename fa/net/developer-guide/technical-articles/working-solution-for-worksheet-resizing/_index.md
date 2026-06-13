---
title: راه‌حل عملی برای تغییر اندازه صفحه کاری
type: docs
weight: 40
url: /fa/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- تصویر پیش‌نمایش
- تغییر اندازه تصویر
- Excel
- صفحه کاری
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "رفع تغییر اندازه OLE صفحه کاری Excel در ارائه‌ها: دو روش برای حفظ یکسانی قاب‌های شیء—مقیاس‌بندی قاب یا صفحه—در فرمت‌های PPT و PPTX."
---
{{% alert color="primary" %}} 

مشاهده شده است که صفحات کاری Excel که به عنوان اشیاء OLE در یک ارائه PowerPoint از طریق اجزای Aspose جاسازی می‌شوند، پس از اولین فعال‌سازی به مقیاسی نامشخص تغییر اندازه می‌دهند. این رفتار تفاوت بصری واضحی بین حالت‌های قبل و بعد از فعال‌سازی شیء OLE در ارائه ایجاد می‌کند. ما این مشکل را به طور جزئی بررسی کرده و راه‌حلی ارائه داده‌ایم که در این مقاله پوشش داده شده است.

{{% /alert %}} 

## **پیش‌زمینه**

در مقاله [مدیریت OLE](/slides/fa/net/manage-ole/) توضیح دادیم که چگونه می‌توان یک فریم OLE را به ارائه PowerPoint با استفاده از Aspose.Slides for .NET اضافه کرد. برای رفع [مشکل پیش‌نمایش شیء](/slides/fa/net/object-preview-issue-when-adding-oleobjectframe/)، تصویری از ناحیه انتخاب شده صفحه کاری را به فریم شیء OLE اختصاص دادیم. در ارائه خروجی، وقتی فریم شیء OLE که تصویر صفحه کاری را نشان می‌دهد، دوبار کلیک می‌کنید، کتاب‌کار Excel فعال می‌شود. کاربران می‌توانند تغییرات دلخواه خود را در کتاب‌کار واقعی اعمال کرده و سپس با کلیک خارج از کتاب‌کار فعال شده به اسلاید بازگردند. اندازه فریم شیء OLE هنگام بازگشت کاربر به اسلاید تغییر خواهد کرد. عامل تغییر اندازه بسته به اندازه فریم شیء OLE و کتاب‌کار Excel جاسازی‌شده متفاوت است. 

## **علت تغییر اندازه**

از آنجا که کتاب‌کار Excel دارای اندازه پنجره خود است، سعی می‌کند هنگام اولین فعال‌سازی اندازه اصلی خود را حفظ کند. از سوی دیگر، فریم شیء OLE دارای اندازهٔ خودش است. بر اساس گفته مایکروسافت، هنگامی که کتاب‌کار Excel فعال می‌شود، Excel و PowerPoint برای اطمینان از حفظ نسبت‌های صحیح در طول فرایند جاسازی، اندازه را مورد مذاکره قرار می‌دهند. تغییر اندازه بر اساس تفاوت‌های بین اندازه پنجره Excel و اندازه و موقعیت فریم شیء OLE رخ می‌دهد.

## **راه‌حل عملی**

دو راه‌حل ممکن برای جلوگیری از اثر تغییر اندازه وجود دارد.

- مقیاس‌بندی اندازه فریم OLE در ارائه PowerPoint به‌طوری‌که با ارتفاع و عرض تعداد ردیف‌ها و ستون‌های موردنظر در فریم OLE مطابقت داشته باشد.
- ثابت نگه داشتن اندازه فریم OLE و مقیاس‌بندی اندازهٔ ردیف‌ها و ستون‌های مشارکت‌کننده تا درون اندازهٔ فریم OLE انتخاب‌شده جای گیرد.

### **مقیاس‌بندی اندازه فریم OLE**

در این روش، یاد می‌گیریم چگونه اندازه فریم OLE کتاب‌کار Excel جاسازی‌شده را طوری تنظیم کنیم که با اندازهٔ کل‌جمعی ردیف‌ها و ستون‌های مشارکت‌کننده در صفحه کاری Excel مطابقت داشته باشد.

فرض کنید یک صفحه کاری الگو داریم و می‌خواهیم آن را به‌عنوان فریم OLE به یک ارائه اضافه کنیم. در این حالت، ابتدا اندازهٔ فریم شیء OLE بر اساس مجموع ارتفاع ردیف‌ها و عرض ستون‌های مشارکت‌کننده در کتاب‌کار محاسبه می‌شود. سپس اندازهٔ فریم OLE را به این مقدار محاسبه‌شده تنظیم می‌کنیم. برای جلوگیری از نمایش پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، همچنین تصویری از بخش‌های موردنظر ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و به‌عنوان تصویر فریم OLE تنظیم می‌کنیم.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// اندازه نمایش را زمانی که فایل کتاب‌کار به‌عنوان شیء OLE در PowerPoint استفاده می‌شود، تنظیم می‌کند.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// عرض و ارتفاع تصویر OLE را بر حسب نقاط به‌دست می‌آورد.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// ما نیاز داریم تا از کتاب‌کار اصلاح‌شده استفاده کنیم.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// تصویر OLE را به منابع ارائه اضافه می‌کند.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// قاب شیء OLE را ایجاد می‌کند.
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

در این روش، یاد می‌گیریم چگونه ارتفاع ردیف‌های مشارکت‌کننده و عرض ستون‌های مشارکت‌کننده را طوری مقیاس‌بندی کنیم که با یک فریم OLE سفارشی مطابقت داشته باشد.

فرض کنید یک صفحه کاری الگو داریم و می‌خواهیم آن را به‌عنوان فریم OLE به یک ارائه اضافه کنیم. در این حالت، اندازهٔ فریم OLE را تنظیم می‌کنیم و اندازهٔ ردیف‌ها و ستون‌های مشارکت‌کننده در ناحیه فریم OLE را مقیاس می‌دهیم. سپس کتاب‌کار را به یک جریان ذخیره می‌کنیم تا تغییرات اعمال شوند و آن را به آرایهٔ بایتی تبدیل می‌کنیم تا به فریم OLE اضافه شود. برای جلوگیری از نمایش پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، همچنین تصویری از بخش‌های موردنظر ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و به‌عنوان تصویر فریم OLE تنظیم می‌کنیم.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// اندازه نمایش را هنگام استفاده از فایل کتاب‌کار به‌عنوان شیء OLE در PowerPoint تنظیم می‌کند.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// بازه سلولی را برای مطابق شدن با اندازه قاب مقیاس‌بندی می‌کند.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// ما باید از کتاب‌کار اصلاح‌شده استفاده کنیم.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// تصویر OLE را به منابع ارائه اضافه می‌کند.
var oleImage = presentation.Images.AddImage(imageStream);

// قاب شیء OLE را ایجاد می‌کند.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">عرض مورد انتظار محدوده سلول‌ها بر حسب نقاط.</param>
/// <param name="height">ارتفاع مورد انتظار محدوده سلول‌ها بر حسب نقاط.</param>
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

{{% alert color="primary" %}}

دو رویکرد برای رفع مشکل تغییر اندازه صفحه کاری وجود دارد. انتخاب رویکرد مناسب بستگی به الزامات خاص و مورد استفاده دارد. هر دو رویکرد به‌یک‌سان کار می‌کنند، چه ارائه‌ها از یک الگو ایجاد شوند و چه از صفر. علاوه بر این، در این راه‌حل هیچ محدودیتی برای اندازه فریم شیء OLE وجود ندارد.

{{% /alert %}}

## **سوالات متداول**

**چرا یک صفحه کاری Excel جاسازی‌شده هنگام اولین فعال‌سازی در PowerPoint اندازهٔ خود را تغییر می‌دهد؟**  
این به این دلیل است که Excel سعی می‌کند اندازهٔ اصلی پنجره خود را هنگام فعال‌سازی حفظ کند، در حالی که فریم شیء OLE در PowerPoint دارای ابعاد متفاوتی است. PowerPoint و Excel برای حفظ نسبت عرض‑ارتفاع، اندازه را مورد مذاکره قرار می‌دهند که می‌تواند منجر به تغییر اندازه شود.

**آیا می‌توان این مشکل تغییر اندازه را به‌طور کامل جلوگیری کرد؟**  
بله. با مقیاس‌بندی فریم OLE به‌گونه‌ای که با اندازهٔ بازه سلولی Excel مطابقت داشته باشد یا مقیاس‌بندی بازه سلولی برای تطبیق با اندازهٔ دلخواه فریم OLE، می‌توانید از تغییر اندازه ناخواسته جلوگیری کنید.

**کدام روش مقیاس‌بندی را باید انتخاب کنم، مقیاس‌بندی فریم OLE یا مقیاس‌بندی بازه سلولی؟**  
اگر می‌خواهید اندازهٔ اصلی ردیف‌ها و ستون‌های Excel حفظ شود، **مقیاس‌بندی فریم OLE** را انتخاب کنید. اگر به دنبال داشتن اندازهٔ ثابت برای فریم OLE در ارائه‌تان هستید، **مقیاس‌بندی بازه سلولی** را برگزینید.

**آیا این راه‌حل‌ها در صورتی که ارائه‌ام بر پایه یک الگو باشد، کار می‌کنند؟**  
بله. هر دو راه‌حل برای ارائه‌های ایجادشده از الگوها و همچنین از ابتدای صفر کار می‌کنند.

**آیا محدودیتی برای اندازهٔ فریم OLE هنگام استفاده از این روش‌ها وجود دارد؟**  
خیر. می‌توانید فریم شیء OLE را به هر اندازه‌ای تنظیم کنید، به شرطی که مقیاس را به‌درستی تنظیم کنید.

**آیا راهی برای جلوگیری از متن جایگزین «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟**  
بله. با گرفتن یک تصویر از بازه سلولی هدف Excel و تنظیم آن به‌عنوان تصویر جایگزین فریم OLE، می‌توانید یک تصویر پیش‌نمایش سفارشی به‌جای متن پیش‌فرض نمایش دهید.

## **مقالات مرتبط**

[ایجاد نمودار Excel و جاسازی آن در یک ارائه به‌عنوان شیء OLE](/slides/fa/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[به‌روزرسانی خودکار اشیاء OLE با استفاده از افزودنی MS PowerPoint](/slides/fa/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)