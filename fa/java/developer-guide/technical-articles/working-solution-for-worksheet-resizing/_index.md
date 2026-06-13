---
title: راه‌حل عملی برای تغییر اندازه کاربرگ
type: docs
weight: 20
url: /fa/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- تصویر پیش‌نمایش
- تغییر اندازه تصویر
- Excel
- کاربرگ
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "رفع تغییر اندازه OLE کاربرگ Excel در ارائه‌ها: دو روش برای حفظ یکسانی فریم‌های شیء—مقیاس‌گذاری فریم یا شیت—در فرمت‌های PPT و PPTX."
---
{{% alert color="primary" %}}

مشاهده شده است که کاربرگ‌های Excel که به‌عنوان اشیاء OLE در یک ارائه PowerPoint از طریق مؤلفه‌های Aspose جاسازی می‌شوند، پس از اولین فعال‌سازی به مقیاسی نامشخص تغییر اندازه می‌دهند. این رفتار اختلاف بصری قابل‌توجهی بین وضعیت قبل و بعد از فعال‌سازی شیء OLE در ارائه ایجاد می‌کند. ما این مسئله را به‌طور جزئی بررسی کرده و راه‌حلی ارائه کرده‌ایم که در این مقاله پوشش داده شده است.

{{% /alert %}}

## **Background**

در مقاله [Manage OLE](/slides/fa/java/manage-ole/) توضیح دادیم که چگونه یک فریم OLE را به یک ارائه PowerPoint با استفاده از Aspose.Slides for Java اضافه کنیم. برای رفع [object preview issue](/slides/fa/java/object-preview-issue-when-adding-oleobjectframe/) تصویری از محدودهٔ کاربرگ انتخاب‌شده را به فریم شیء OLE اختصاص دادیم. در ارائه خروجی، وقتی بر روی فریم شیء OLE که تصویر کاربرگ را نشان می‌دهد دوبار کلیک کنید، کتاب‌کار Excel فعال می‌شود. کاربران می‌توانند تغییرات دلخواه خود را در کتاب‌کار واقعی اعمال کنند و سپس با کلیک بیرون از کتاب‌کار فعال‌شده به اسلاید بازگردند. اندازهٔ فریم شیء OLE هنگام بازگشت کاربر به اسلاید تغییر می‌کند. عامل تغییر اندازه بسته به اندازهٔ فریم شیء OLE و کتاب‌کار Excel جاسازی‌شده متفاوت خواهد بود.

## **Cause of Resizing**

از آنجا که کتاب‌کار Excel اندازهٔ پنجرهٔ خود را دارد، سعی می‌کند پس از اولین فعال‌سازی اندازهٔ اولیهٔ خود را حفظ کند. از طرف دیگر، فریم شیء OLE اندازهٔ خاص خود را دارد. طبق گفته مایکروسافت، زمانی که کتاب‌کار Excel فعال می‌شود، Excel و PowerPoint برای اطمینان از حفظ نسبت‌های صحیح، اندازهٔ آن را بر اساس فرآیند جاسازی تنظیم می‌کنند. تغییر اندازه بر پایهٔ اختلافات بین اندازهٔ پنجرهٔ Excel و اندازه و موقعیت فریم شیء OLE رخ می‌دهد.

## **Working Solution**

دو راه‌حل ممکن برای جلوگیری از اثر تغییر اندازه وجود دارد.

- مقیاس اندازهٔ فریم OLE در ارائه PowerPoint را طوری تنظیم کنید که با ارتفاع و عرض تعداد ردیف‌ها و ستون‌های موردنظر در فریم OLE تطابق داشته باشد.
- اندازهٔ فریم OLE را ثابت نگه داشته و اندازهٔ ردیف‌ها و ستون‌های مشارکت‌کننده را طوری مقیاس‌دهی کنید که در اندازهٔ فریم OLE انتخاب‌شده جای بگیرد.

### **Scale the OLE Frame Size**

در این رویکرد، نحوهٔ تنظیم اندازهٔ فریم OLE کتاب‌کار Excel جاسازی‌شده را طوری یاد می‌گیریم که با اندازهٔ تجمعی ردیف‌ها و ستون‌های مشارکت‌کننده در کاربرگ Excel مطابقت داشته باشد.

فرض کنید یک شیت الگو Excel داریم و می‌خواهیم آن را به‌عنوان فریم OLE به یک ارائه اضافه کنیم. در این حالت، ابتدا اندازهٔ فریم شیء OLE بر پایهٔ مجموع ارتفاع ردیف‌ها و عرض ستون‌های مشارکت‌کننده در کتاب‌کار محاسبه می‌شود. سپس اندازهٔ فریم OLE را به این مقدار محاسبه‌شده تنظیم می‌کنیم. برای جلوگیری از نمایش پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، تصویری از بخش‌های دلخواه ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و به‌عنوان تصویر فریم OLE تنظیم می‌کنیم.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// اندازه نمایش داده‌شده را زمانی که فایل کتاب‌کار به‌عنوان شیء OLE در PowerPoint استفاده می‌شود تنظیم کنید.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// We need to use the modified workbook.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
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

### **Scale the Cell Range Size**

در این رویکرد، نحوهٔ مقیاس‌دهی ارتفاع ردیف‌های مشارکت‌کننده و عرض ستون‌های مشارکت‌کننده را طوری یاد می‌گیریم که با یک اندازهٔ سفارشی فریم OLE منطبق شود.

فرض کنید یک شیت الگو Excel داریم و می‌خواهیم آن را به‌عنوان فریم OLE به یک ارائه اضافه کنیم. در این حالت، اندازهٔ فریم OLE را تنظیم می‌کنیم و سپس اندازهٔ ردیف‌ها و ستون‌های مشارکت‌کننده در ناحیهٔ فریم OLE را مقیاس می‌دهیم. سپس کتاب‌کار را در یک جریان (stream) ذخیره می‌کنیم تا تغییرات اعمال شود و آن را به آرایهٔ بایت تبدیل می‌کنیم تا به فریم OLE اضافه شود. برای جلوگیری از پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، تصویری از بخش‌های دلخواه ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و به‌عنوان تصویر فریم OLE تنظیم می‌کنیم.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// اندازه نمایش داده‌شده را زمانی که فایل کتاب‌کار به‌عنوان شیء OLE در PowerPoint استفاده می‌شود تنظیم کنید.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// محدوده سلول را برای متناسب شدن با اندازه فریم مقیاس‌دهی کنید.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// ما باید از کتاب‌کار تغییر یافته استفاده کنیم.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// تصویر OLE را به منابع ارائه اضافه کنید.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// فریم شیء OLE را ایجاد کنید.
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
 * @param width     عرض مورد انتظار محدودهٔ سلول بر حسب پوینت.
 * @param height    ارتفاع مورد انتظار محدودهٔ سلول بر حسب پوینت.
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

## **Conclusion**

{{% alert color="primary" %}} 

دو روش برای رفع مشکل تغییر اندازه کاربرگ وجود دارد. انتخاب روش مناسب بستگی به نیازها و موارد استفاده خاص دارد. هر دو روش به‌یک‌سان کار می‌کنند، چه ارائه‌ها از یک الگو ساخته شوند و چه از صفر. علاوه بر این، در این راه‌حل محدودیتی برای اندازهٔ فریم شیء OLE وجود ندارد.

{{% /alert %}}

## **FAQ**

**چرا یک کاربرگ Excel جاسازی‌شده پس از اولین فعال‌سازی در PowerPoint تغییر اندازه می‌دهد؟**

این به این دلیل است که Excel سعی می‌کند اندازهٔ پنجرهٔ اصلی خود را هنگام فعال‌سازی حفظ کند، در حالی که فریم شیء OLE در PowerPoint ابعاد خاص خود را دارد. PowerPoint و Excel برای حفظ نسبت تصویر با هم مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

**آیا می‌توان این مشکل تغییر اندازه را به‌طور کامل جلوگیری کرد؟**

بله. با مقیاس‌دهی فریم OLE به اندازهٔ محدودهٔ سلول‌های Excel یا مقیاس‌دهی محدوده سلول‌ها به اندازهٔ دلخواه فریم OLE می‌توانید از تغییر اندازه ناخواسته جلوگیری کنید.

**کدام روش مقیاس‌دهی را باید استفاده کنم، مقیاس‌دهی فریم OLE یا مقیاس‌دهی محدوده سلول؟**

اگر می‌خواهید اندازهٔ ردیف‌ها و ستون‌های اصلی Excel حفظ شود، **مقیاس‌دهی فریم OLE** را انتخاب کنید. اگر نیاز به یک اندازهٔ ثابت برای فریم OLE در ارائه دارید، **مقیاس‌دهی محدوده سلول** را انتخاب کنید.

**آیا این راه‌حل‌ها در صورت استفاده از قالب (template) برای ارائه کار می‌کنند؟**

بله. هر دو راه‌حل برای ارائه‌های ساخته‌شده از قالب و همچنین از ابتدا کار می‌کنند.

**آیا محدودیتی برای اندازهٔ فریم OLE هنگام استفاده از این روش‌ها وجود دارد؟**

خیر. می‌توانید فریم شیء OLE را به هر اندازه‌ای که بخواهید تنظیم کنید، به شرط آن‌که مقیاس را به‌درستی تنظیم کنید.

**آیا راهی برای جلوگیری از متن جایگزین «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟**

بله. با گرفتن یک اسنپ‌شات از محدودهٔ سلول هدف در Excel و تنظیم آن به‌عنوان تصویر جایگزین فریم OLE، می‌توانید به‌جای متن پیش‌فرض، یک تصویر پیش‌نمایش سفارشی نمایش دهید.

## **Related Articles**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/fa/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/fa/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)