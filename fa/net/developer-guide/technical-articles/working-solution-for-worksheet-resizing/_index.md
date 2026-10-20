---
title: راه‌حل عملی برای تغییر اندازه برگه کاری
type: docs
weight: 40
url: /fa/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- تصویر پیش‌نمایش
- تغییر اندازه تصویر
- Excel
- برگه کاری
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "رفع مشکل تغییر اندازه OLE برگه Excel در ارائه‌ها: دو روش برای حفظ ثابت‌ بودن فریم‌های شیء—مقیاس‌گذاری فریم یا برگه—در فرمت‌های PPT و PPTX."
---
{{% alert color="info" title="Note" %}}
برگه‌های Excel که به‌عنوان شیء OLE در ارائه PowerPoint با استفاده از مؤلفه‌های Aspose جاسازی می‌شوند، ممکن است پس از اولین فعال‌سازی به‌طور غیرمنتظره‌ای اندازه‌شان تغییر کند. این رفتار تفاوت بصری قابل‌توجهی بین شیء OLE قبل و بعد از فعال‌سازی ایجاد می‌کند. این مقاله به توضیح مشکل می‌پردازد و دو روش برای رفع آن را توصیف می‌کند.
{{% /alert %}} 

## **Background**

در مقاله [Manage OLE](/slides/fa/net/manage-ole/)، ما نحوه افزودن یک فریم OLE به ارائه PowerPoint با استفاده از Aspose.Slides for .NET را توضیح دادیم. برای رفع [object preview issue](/slides/fa/net/object-preview-issue-when-adding-oleobjectframe/)، تصویری از ناحیه انتخاب‌شده برگه کار را به فریم شیء OLE اختصاص دادیم. در ارائه خروجی، هنگامی که روی فریم شیء OLE که تصویر برگه کار را نشان می‌دهد دوبار کلیک کنید، کتابخانه Excel فعال می‌شود. کاربران می‌توانند هر تغییر دلخواهی در کتابخانه Excel واقعی اعمال کنند و سپس با کلیک خارج از کتابخانه فعال شده به اسلاید بازگردند. اندازه فریم شیء OLE هنگام بازگشت کاربر به اسلاید تغییر خواهد کرد. ضریب تغییر اندازه بسته به اندازه فریم OLE و کتابخانه Excel جاسازی‌شده متفاوت است.

## **Cause of Resizing**

از آنجا که کتابخانه Excel اندازه پنجره خود را دارد، سعی می‌کند اندازه اصلی خود را پس از اولین فعال‌سازی حفظ کند. از سوی دیگر، فریم شیء OLE دارای اندازه خاص خود است. بر اساس گفته مایکروسافت، وقتی کتابخانه Excel فعال می‌شود، Excel و PowerPoint برای حفظ نسبت‌های صحیح به عنوان بخشی از فرآیند جاسازی، درباره اندازه مذاکره می‌کنند. تغییر اندازه بر اساس تفاوت‌های بین اندازه پنجره Excel و اندازه و موقعیت فریم شیء OLE رخ می‌دهد.

## **Working Solution**

دو راه‌حل ممکن برای جلوگیری از اثر تغییر اندازه وجود دارد.

- اندازه فریم OLE را در ارائه PowerPoint طوری مقیاس دهید که ارتفاع و عرض کل ردیف‌ها و ستون‌های انتخاب‌شده را مطابقت دهد.
- اندازه فریم OLE را ثابت نگه داشته و ردیف‌ها و ستون‌های انتخاب‌شده را طوری مقیاس دهید که در داخل آن جا بگیرند.

### **Scale the OLE Frame Size**

این روش اندازه فریم OLE را طوری تنظیم می‌کند که ارتفاع و عرض کل ردیف‌ها و ستون‌های انتخاب‌شده در برگه کار Excel جاسازی‌شده را مطابقت دهد.

مثال یک کتابخانه Excel موجود را بارگیری می‌کند و با استفاده از اندیس‌های صفر-پایه، اولین 10 ردیف و 13 ستون از برگه اول آن را انتخاب می‌کند. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) محدوده نمایش داده‌شده را تعریف می‌کند. پیش‌نمایش با 96 DPI رندر می‌شود و ابعاد پیکسل آن با استفاده از 72 نقطه در اینچ به نقاط تبدیل می‌شود. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) کتابخانه تغییر یافته را در چهارچوبی با آن ابعاد جاسازی می‌کند. پیش‌نمایش از طریق [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) اختصاص داده می‌شود تا جایگزین متن جایگزین «EMBEDDED OLE OBJECT» در ارائه ذخیره‌شده شود.

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

// تنظیم اندازه نمایش داده شده زمانی که فایل کتاب کار به عنوان شیء OLE در PowerPoint استفاده می‌شود.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// We need to use the modified workbook.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Add the OLE image to the presentation resources.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

کمک‌کننده پیش‌نمایش [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) را به محدوده انتخاب‌شده تنظیم می‌کند و حاشیه‌ها، سرصفحه‌ها و پاورقی‌ها را حذف می‌نماید. با فعال‌سازی [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/)، [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) محدوده را به‌صورت تصویر PNG رندر می‌کند. کمک‌کننده قبل از برگرداندن برای استفاده در ارائه، جریان تصویر را به ابتدای آن باز می‌گرداند.

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

### **Scale the Cell Range Size**

این روش ارتفاع ردیف‌های انتخاب‌شده و عرض ستون‌های انتخاب‌شده را طوری مقیاس می‌دهد که با یک اندازه سفارشی فریم OLE مطابقت داشته باشد.

مثال یک کتابخانه Excel موجود را بارگیری می‌کند و با استفاده از اندیس‌های صفر-پایه، اولین 10 ردیف و 13 ستون از برگه اول آن را انتخاب می‌کند. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) محدوده نمایش داده‌شده را تعریف می‌کند و کمک‌کننده زیر آن محدوده را طوری مقیاس می‌دهد که در قاب 400 نقطه عرض و 100 نقطه ارتفاع جا بگیرد. پس از ذخیره کتابخانه تغییر یافته در یک جریان، [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) آن را با اندازه مشخص جاسازی می‌کند. پیش‌نمایشی که با 96 DPI رندر شده است، از طریق [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) اختصاص می‌یابد تا ارائه ذخیره‌شده به‌جای جایگزین پیش‌فرض، سلول‌های انتخاب‌شده را نمایش دهد.

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

// تنظیم اندازه نمایش داده شده زمانی که فایل کتاب کار به عنوان شیء OLE در PowerPoint استفاده می‌شود.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// مقیاس‌گذاری محدوده سلول‌ها برای جا شدن در اندازه قاب.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// ما نیاز داریم کتاب کار اصلاح‌شده را استفاده کنیم.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// افزودن تصویر OLE به منابع ارائه.
var oleImage = presentation.Images.AddImage(imageStream);

// ایجاد فریم شیء OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

کمک‌کننده مقیاس‌گذاری نسبت‌های جداگانه عرض و ارتفاع برای محدوده انتخاب‌شده را محاسبه می‌کند و عرض نسبی ستون‌ها و ارتفاع نسبی ردیف‌ها را حفظ می‌نماید. قبل از اعمال آنها با [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) و [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/)، ابعاد محاسبه‌شده را از نقاط به اینچ تبدیل می‌کند. محدوده انتخاب‌شده باید عرض و ارتفاع غیرصفر داشته باشد.

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

این کمک‌کننده پیش‌نمایش محدوده تغییر سایز داده‌شده را با استفاده از [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) رندر می‌کند. [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) را به همان محدوده محدود می‌نماید، حاشیه‌ها، سرصفحه‌ها و پاورقی‌ها را حذف می‌کند و یک جریان PNG را که در ابتدای آن موقعیت دارد برمی‌گرداند.

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

## **Conclusion**
{{% alert color="info" title="Note" %}}
دو روش برای رفع مشکل تغییر اندازه برگه کار وجود دارد. روشی را انتخاب کنید که بهترین تطبیق را با نیازها و موارد استفاده شما داشته باشد. هر دو روش به‌ همان شکل کار می‌کنند، چه ارائه‌ها از یک الگو ایجاد شوند و چه از صفر. به‌علاوه، در این راه‌حل هیچ محدودیتی برای اندازه فریم شیء OLE وجود ندارد.
{{% /alert %}}

## **FAQ**

**چرا یک برگه کار Excel جاسازی‌شده هنگام اولین فعال‌سازی در PowerPoint اندازه‌اش تغییر می‌کند؟**

این به‌این دلیل رخ می‌دهد که Excel سعی می‌کند اندازه اصلی پنجره را هنگام فعال‌سازی حفظ کند، در حالی که فریم شیء OLE در PowerPoint دارای ابعاد خاص خود است. PowerPoint و Excel درباره اندازه مذاکره می‌کنند تا نسبت ابعاد را حفظ کنند، که می‌تواند منجر به تغییر اندازه شود.

**آیا می‌توان این مشکل تغییر اندازه را به‌طور کامل جلوگیری کرد؟**

بله. با مقیاس‌دادن فریم OLE به اندازه محدوده سلول‌های Excel یا مقیاس‌دادن محدوده سلول‌ها به اندازه فریم OLE موردنظر، می‌توانید از تغییر اندازه ناخواسته جلوگیری کنید.

**کدام روش مقیاس‌گذاری را باید استفاده کنم، مقیاس‌گذاری فریم OLE یا مقیاس‌گذاری محدوده سلول؟**

اگر می‌خواهید اندازه اصلی ردیف‌ها و ستون‌های Excel را حفظ کنید، **مقیاس‌گذاری فریم OLE** را انتخاب کنید. اگر می‌خواهید یک اندازه ثابت برای فریم OLE در ارائه خود داشته باشید، **مقیاس‌گذاری محدوده سلول** را انتخاب کنید.

**آیا این راه‌حل‌ها اگر ارائه من بر پایه یک الگو باشد کار می‌کنند؟**

بله. هر دو راه‌حل برای ارائه‌های ایجاد شده از الگوها و از صفر کار می‌کنند.

**آیا محدودیتی برای اندازه فریم OLE هنگام استفاده از این روش‌ها وجود دارد؟**

خیر. می‌توانید فریم شیء OLE را به هر اندازه‌ای ایجاد کنید به‌شرط اینکه مقیاس را به‌درستی تنظیم کنید.

**آیا راهی برای جلوگیری از متن جایگزین «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟**

بله. با گرفتن یک اسنپ‌شات از محدوده سلول هدف در Excel و تنظیم آن به‌عنوان تصویر جایگزین فریم OLE، می‌توانید یک تصویر پیش‌نمایش سفارشی به‌جای جایگزین پیش‌فرض نمایش دهید.

## **Related Articles**

[ایجاد یک نمودار Excel و جاسازی آن در ارائه به‌عنوان شیء OLE](/slides/fa/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[به‌روزرسانی خودکار اشیای OLE با استفاده از افزونه MS PowerPoint](/slides/fa/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)