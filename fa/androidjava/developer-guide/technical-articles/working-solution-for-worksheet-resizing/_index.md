---
title: راه‌حل عملی برای تغییر اندازه ورک‌شیت
type: docs
weight: 20
url: /fa/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- تصویر پیش‌نمایش
- تغییر اندازه تصویر
- Excel
- ورک‌شیت
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "رفع تغییر اندازه OLE ورک‌شیت Excel در ارائه‌ها: دو روش برای حفظ یکپارچگی فریم‌های شیء—مقیاس‌بندی فریم یا شیت—در فرمت‌های PPT و PPTX."
---
{{% alert color="primary" %}}
مشاهده شده است که ورک‌شیت‌های Excel که به عنوان اشیاء OLE در یک ارائه PowerPoint از طریق اجزای Aspose جاسازی می‌شوند، پس از اولین فعال‌سازی به مقیاسی نامشخص تغییر اندازه می‌دهند. این رفتار تفاوت بصری قابل توجهی در ارائه بین وضعیت‌های پیش و پس از فعال‌سازی شیء OLE ایجاد می‌کند. ما این مشکل را به‌طور جامع بررسی کرده و راه حلی ارائه داده‌ایم که در این مقاله پوشش داده شده است.
{{% /alert %}}

## **پیش‌زمینه**

در مقاله [مدیریت OLE](/slides/fa/androidjava/manage-ole/)، ما توضیح دادیم که چگونه یک فریم OLE را به یک ارائه PowerPoint با استفاده از Aspose.Slides برای Android از طریق Java اضافه کنیم. برای رفع [مشکل پیش‌نمایش شیء](/slides/fa/androidjava/object-preview-issue-when-adding-oleobjectframe/)، یک تصویر از ناحیهٔ انتخاب‌شدهٔ ورک‌شیت را به فریم شیء OLE اختصاص دادیم. در ارائه خروجی، وقتی که روی فریم شیء OLE که تصویر ورک‌شیت را نمایش می‌دهد دوبار کلیک کنید، کتاب کاری Excel فعال می‌شود. کاربران نهایی می‌توانند هر تغییری که می‌خواهند در کتاب کاری واقعی Excel اعمال کنند و سپس با کلیک خارج از کتاب کاری فعال‌شده به اسلاید بازگردند. اندازهٔ فریم شیء OLE هنگام بازگشت کاربر به اسلاید تغییر خواهد کرد. ضریب تغییر اندازه بسته به اندازهٔ فریم شیء OLE و کتاب کاری Excel جاسازی‌شده متفاوت خواهد بود.

## **علت تغییر اندازه**

از آنجایی که کتاب کاری Excel اندازهٔ پنجرهٔ مخصوص خود را دارد، سعی می‌کند پس از اولین فعال‌سازی اندازهٔ اصلی خود را حفظ کند. از سوی دیگر، فریم شیء OLE اندازهٔ خاص خود را دارد. بر اساس مایکروسافت، هنگامی که کتاب کاری Excel فعال می‌شود، Excel و PowerPoint برای توافق بر روی اندازه مذاکره می‌کنند تا اطمینان حاصل شود که نسبت‌های صحیح به‌عنوان بخشی از فرآیند جاسازی حفظ می‌شود. تغییر اندازه بر اساس تفاوت‌های بین اندازهٔ پنجرهٔ Excel و اندازه و موقعیت فریم شیء OLE انجام می‌شود.

## **راه‌حل عملی**

دو راه حل ممکن برای جلوگیری از اثر تغییر اندازه وجود دارد.

- مقیاس‌بندی اندازهٔ فریم OLE در ارائه PowerPoint به‌طوری که ارتفاع و عرض تعداد ردیف‌ها و ستون‌های موردنظر در فریم OLE مطابقت داشته باشد.
- ثابت نگه داشتن اندازهٔ فریم OLE و مقیاس‌بندی اندازهٔ ردیف‌ها و ستون‌های شرکت‌کننده برای متناسب شدن با اندازهٔ انتخاب‌شدهٔ فریم OLE.

### **مقیاس‌بندی اندازهٔ فریم OLE**

در این روش، نحوه تنظیم اندازهٔ فریم OLE کتاب کاری Excel جاسازی‌شده برای مطابقت با اندازهٔ تجمعی ردیف‌ها و ستون‌های شرکت‌کننده در ورک‌شیت Excel را می‌آموزیم.

فرض کنید یک شیت الگو Excel داریم و می‌خواهیم آن را به‌عنوان یک فریم OLE به یک ارائه اضافه کنیم. در این سناریو، اندازهٔ فریم شیء OLE ابتدا بر اساس مجموع ارتفاع ردیف‌ها و عرض ستون‌های شرکت‌کننده در کتاب کاری محاسبه می‌شود. سپس اندازهٔ فریم OLE را به این مقدار محاسبه‌شده تنظیم می‌کنیم. برای جلوگیری از نمایش پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، همچنین یک تصویر از بخش‌های موردنظر ردیف‌ها و ستون‌ها در کتاب کاری گرفته و به‌عنوان تصویر فریم OLE تنظیم می‌کنیم.
```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// تنظیم اندازه نمایش زمانی که فایل کتاب کار به عنوان شیء OLE در PowerPoint استفاده می‌شود.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// دریافت عرض و ارتفاع تصویر OLE بر حسب نقطه.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// ما نیاز داریم تا از کتاب کار اصلاح‌شده استفاده کنیم.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// افزودن تصویر OLE به منابع ارائه.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// ایجاد فریم شیء OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```
```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **مقیاس‌بندی اندازهٔ محدودهٔ سلول**

در این روش، نحوه مقیاس‌بندی ارتفاع ردیف‌های شرکت‌کننده و عرض ستون‌های شرکت‌کننده برای مطابقت با یک اندازهٔ سفارشی فریم OLE را می‌آموزیم.

فرض کنید یک شیت الگو Excel داریم و می‌خواهیم آن را به‌عنوان یک فریم OLE به یک ارائه اضافه کنیم. در این سناریو، اندازهٔ فریم OLE را تنظیم می‌کنیم و اندازهٔ ردیف‌ها و ستون‌های شرکت‌کننده در ناحیهٔ فریم OLE را مقیاس‌بندی می‌کنیم. سپس کتاب کاری را به یک جریان (stream) ذخیره می‌کنیم تا تغییرات اعمال شود و آن را به یک آرایه بایت تبدیل می‌کنیم تا به فریم OLE اضافه شود. برای جلوگیری از نمایش پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، همچنین تصویری از بخش‌های موردنظر ردیف‌ها و ستون‌ها در کتاب کاری گرفته و به‌عنوان تصویر فریم OLE تنظیم می‌کنیم.
```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// تنظیم اندازه نمایش زمانی که فایل کتاب کار به عنوان شیء OLE در PowerPoint استفاده می‌شود.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// مقیاس‌بندی محدوده سلول برای متناسب شدن با اندازه فریم.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// ما نیاز داریم تا از کتاب کار اصلاح‌شده استفاده کنیم.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// افزودن تصویر OLE به منابع ارائه.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// ایجاد فریم شیء OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```
```java
/**
 * @param width     عرض مورد انتظار محدوده سلول‌ها بر حسب نقطه.
 * @param height    ارتفاع مورد انتظار محدوده سلول‌ها بر حسب نقطه.
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```
```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **نتیجه‌گیری**
{{% alert color="primary" %}} 
دو روش برای رفع مشکل تغییر اندازه ورک‌شیت وجود دارد. انتخاب روش مناسب به نیازها و موارد استفاده خاص بستگی دارد. هر دو روش به‌صورت یکسان کار می‌کنند، چه ارائه‌ها از یک الگو ساخته شوند و چه از ابتدا. علاوه بر این، در این راه حل هیچ محدودیتی برای اندازهٔ فریم شیء OLE وجود ندارد.
{{% /alert %}}

## **سوالات متداول**

**چرا یک ورک‌شیت Excel جاسازی‌شده هنگام اولین فعال‌سازی در PowerPoint تغییر اندازه می‌دهد؟**

این به این دلیل اتفاق می‌افتد که Excel سعی می‌کند هنگام فعال‌سازی اندازهٔ اصلی پنجره خود را حفظ کند، در حالی که فریم شیء OLE در PowerPoint ابعاد خاص خود را دارد. PowerPoint و Excel برای حفظ نسبت‌های عرض/ارتفاع مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

**آیا می‌توان این مشکل تغییر اندازه را به‌طور کامل جلوگیری کرد؟**

بله. با مقیاس‌بندی فریم OLE برای مطابقت با اندازهٔ محدودهٔ سلول‌های Excel یا مقیاس‌بندی محدودهٔ سلول برای مطابقت با اندازهٔ دلخواه فریم OLE، می‌توانید از تغییر اندازه ناخواسته جلوگیری کنید.

**کدام روش مقیاس‌بندی را باید استفاده کنم، مقیاس‌بندی فریم OLE یا مقیاس‌بندی محدودهٔ سلول؟**

اگر می‌خواهید اندازهٔ اصلی ردیف‌ها و ستون‌های Excel را حفظ کنید، **مقیاس‌بندی فریم OLE** را انتخاب کنید. اگر می‌خواهید یک اندازه ثابت برای فریم OLE در ارائه خود داشته باشید، **مقیاس‌بندی محدودهٔ سلول** را انتخاب کنید.

**آیا این راه حل‌ها در صورتی که ارائه من بر پایه یک الگو باشد کار می‌کنند؟**

بله. هر دو راه حل برای ارائه‌های ساخته شده از الگوها و همچنین از ابتدا کار می‌کنند.

**آیا محدودیتی برای اندازهٔ فریم OLE هنگام استفاده از این روش‌ها وجود دارد؟**

خیر. می‌توانید فریم شیء OLE را به هر اندازه‌ای بسازید به شرط آنکه مقیاس را به‌درستی تنظیم کنید.

**آیا راهی برای جلوگیری از متن جایگزین «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟**

بله. با گرفتن یک اسنپ‌شات از محدودهٔ سلول هدف در Excel و تنظیم آن به‌عنوان تصویر جایگزین فریم OLE، می‌توانید به‌جای پیام پیش‌فرض، یک تصویر پیش‌نمایش سفارشی نمایش دهید.