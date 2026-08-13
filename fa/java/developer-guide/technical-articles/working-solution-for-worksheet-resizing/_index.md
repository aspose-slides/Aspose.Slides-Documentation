---
title: راه‌حل عملی برای تغییر اندازه برگه کاری
type: docs
weight: 20
url: /fa/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- تصویر پیش‌نمایش
- تغییر اندازه تصویر
- Excel
- برگه کاری
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "رفع مشکل تغییر اندازه OLE برگه Excel در ارائه‌ها: دو روش برای حفظ ثابت بودن فریم‌های شی—مقیاس‌گذاری فریم یا برگه—در فرمت‌های PPT و PPTX."
---
{{% alert color="info" %}}
در هنگام جاسازی برگه‌های Excel به‌عنوان اشیای OLE در یک ارائه PowerPoint توسط مؤلفه‌های Aspose، پس از اولین فعال‌سازی اندازه آنها به مقیاسی نامشخص تغییر می‌یابد. این رفتار تفاوت بصری قابل‌توجهی بین وضعیت قبل و بعد از فعال‌سازی شی OLE در ارائه ایجاد می‌کند. ما این مشکل را به‌صورت جزئی بررسی کرده و راه‌حلی ارائه داده‌ایم که در این مقاله آمده است.
{{% /alert %}}

## **پس‌زمینه**

در مقاله [مدیریت OLE](/slides/fa/java/manage-ole/) توضیح دادیم که چگونه یک فریم OLE را با استفاده از Aspose.Slides for Java به یک ارائه PowerPoint اضافه کنیم. برای رفع [مشکل پیش‌نمایش شی](/slides/fa/java/object-preview-issue-when-adding-oleobjectframe/) یک تصویر از ناحیه برگه انتخاب‌شده به فریم شی OLE اختصاص دادیم. در ارائه خروجی، هنگامی که دو بار روی فریم شی OLE که تصویر برگه را نشان می‌دهد کلیک می‌کنید، کتاب‌کاری Excel فعال می‌شود. کاربران می‌توانند هر تغییری که می‌خواهند در کتاب‌کار واقعی Excel اعمال کنند و سپس با کلیک خارج از کتاب‌کار فعال‌شده به اسلاید بازگردند. هنگام بازگشت کاربر به اسلاید، اندازه فریم شی OLE تغییر خواهد کرد. عامل تغییر اندازه بسته به اندازه فریم شی OLE و کتاب‌کار Excel جاسازی‌شده متفاوت است.

## **دلیل تغییر اندازه**

از آنجا که کتاب‌کار Excel اندازه پنجره خودش را دارد، سعی می‌کند پس از اولین فعال‌سازی همان اندازه اصلی را حفظ کند. در مقابل، فریم شی OLE اندازه مستقلی دارد. بر اساس توضیحات مایکروسافت، هنگام فعال شدن کتاب‌کار Excel، Excel و PowerPoint برای حفظ نسبت‌های صحیح در فرایند جاسازی، درباره اندازه مذاکره می‌کنند. تغییر اندازه بر اساس تفاوت‌های بین اندازه پنجره Excel و اندازه و موقعیت فریم شی OLE رخ می‌دهد.

## **راه‌حل کاری**

دو راه‌حل برای جلوگیری از اثر تغییر اندازه وجود دارد.

- مقیاس‌گذاری اندازه فریم OLE در ارائه PowerPoint به‌گونه‌ای که با ارتفاع و عرض تعداد ردیف‌ها و ستون‌های موردنظر در فریم OLE مطابقت داشته باشد.
- ثابت نگه داشتن اندازه فریم OLE و مقیاس‌گذاری اندازه ردیف‌ها و ستون‌های مشارکت‌کننده برای جا شدن در اندازه فریم OLE انتخاب‌شده.

### **مقیاس‌گذاری اندازه فریم OLE**

در این رویکرد می‌آموزیم چگونه اندازه فریم OLE کتاب‌کار Excel جاسازی‌شده را طوری تنظیم کنیم که با اندازه تجمعی ردیف‌ها و ستون‌های مشارکت‌کننده در برگه Excel برابر باشد.

فرض کنید یک برگه الگو Excel داریم و می‌خواهیم آن را به عنوان فریم OLE به ارائه اضافه کنیم. در این حالت، ابتدا اندازه فریم شی OLE بر پایه مجموع ارتفاع ردیف‌ها و عرض ستون‌های مشارکت‌کننده در کتاب‌کار محاسبه می‌شود. سپس این مقدار محاسبه‌شده را به عنوان اندازه فریم OLE تنظیم می‌کنیم. برای جلوگیری از نمایش پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، همچنین یک تصویر از قسمت‌های دلخواه ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و آن را به عنوان تصویر فریم OLE تنظیم می‌کنیم.

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// تنظیم اندازه نمایش زمانی که فایل کتاب‌کار به‌عنوان شی OLE در PowerPoint استفاده می‌شود.
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
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

### **مقیاس‌گذاری اندازه محدوده سلول‌ها**

در این رویکرد می‌آموزیم چگونه ارتفاع ردیف‌های مشارکت‌کننده و عرض ستون‌های مشارکت‌کننده را طوری مقیاس‌گذاری کنیم که با یک اندازه سفارشی فریم OLE مطابقت داشته باشد.

فرض کنید یک برگه الگو Excel داریم و می‌خواهیم آن را به عنوان فریم OLE به ارائه اضافه کنیم. در این حالت، اندازه فریم OLE را تنظیم می‌کنیم و اندازه ردیف‌ها و ستون‌هایی که در ناحیه فریم OLE مشارکت دارند مقیاس می‌دهیم. سپس کتاب‌کار را به یک جریان (stream) ذخیره می‌کنیم تا تغییرات اعمال شود و آن را به یک آرایه بایت تبدیل می‌کنیم تا به فریم OLE اضافه شود. برای جلوگیری از نمایش پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، همچنین یک تصویر از قسمت‌های دلخواه ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و آن را به عنوان تصویر فریم OLE تنظیم می‌کنیم.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// تنظیم اندازه نمایش هنگام استفاده از فایل کتاب‌کار به‌عنوان شی OLE در PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// مقیاس‌گذاری محدوده سلول‌ها برای متناسب شدن با اندازه فریم.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// ما باید از کتاب‌کار اصلاح‌شده استفاده کنیم.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// افزودن تصویر OLE به منابع ارائه.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// ایجاد فریم شی OLE.
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
 * @param width     عرض مورد انتظار بازه سلول بر حسب نقطه.
 * @param height    ارتفاع مورد انتظار بازه سلول بر حسب نقطه.
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
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

{{% alert color="info" %}} 
دو رویکرد برای رفع مشکل تغییر اندازه برگه وجود دارد. انتخاب رویکرد مناسب بستگی به نیازهای خاص و مورد استفاده دارد. هر دو رویکرد به‌صورت یکسان عمل می‌کنند، چه ارائه‌ها از یک الگو ساخته شوند و چه از ابتدا. علاوه بر این، در این راه‌حل هیچ محدودیتی برای اندازه فریم شی OLE وجود ندارد.
{{% /alert %}}

## **سؤال‌های متداول**

### چرا پس از اولین فعال‌سازی در PowerPoint یک برگه Excel جاسازی‌شده اندازه‌اش تغییر می‌کند؟

این به این دلیل است که Excel سعی می‌کند اندازه پنجره اصلی خود را هنگام فعال‌سازی حفظ کند، در حالی که فریم شی OLE در PowerPoint ابعاد مستقلی دارد. PowerPoint و Excel درباره اندازه مذاکره می‌کنند تا نسبت ابعاد حفظ شود که می‌تواند منجر به تغییر اندازه شود.

### آیا می‌توان این مشکل تغییر اندازه را به‌طور کامل جلوگیری کرد؟

بله. با مقیاس‌گذاری فریم OLE برای متناسب شدن با اندازه محدوده سلول‌های Excel یا مقیاس‌گذاری محدوده سلول‌ها برای متناسب شدن با اندازه دلخواه فریم OLE، می‌توانید از تغییر اندازه ناخواسته جلوگیری کنید.

### کدام روش مقیاس‌گذاری را باید انتخاب کنم، مقیاس‌گذاری فریم OLE یا مقیاس‌گذاری محدوده سلول؟

اگر می‌خواهید اندازه ردیف‌ها و ستون‌های اصلی Excel را حفظ کنید، **مقیاس‌گذاری فریم OLE** را انتخاب کنید. اگر می‌خواهید اندازه فریم OLE در ارائه ثابت باشد، **مقیاس‌گذاری محدوده سلول** را انتخاب کنید.

### آیا این راه‌حل‌ها در صورتی که ارائه من بر پایه یک الگو باشد کار می‌کند؟

بله. هر دو راه‌حل برای ارائه‌هایی که از قالب‌ها ساخته شده‌اند و همچنین برای ارائه‌های از ابتدا ساخته‌شده کار می‌کنند.

### آیا برای اندازه فریم OLE در این روش‌ها محدودیتی وجود دارد؟

خیر. می‌توانید فریم شی OLE را به هر اندازه‌ای که می‌خواهید تنظیم کنید، به‌شرط این‌که مقیاس را به‌طور مناسب تنظیم کنید.

### آیا راهی برای حذف متن جای‌نگهدار «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟

بله. با گرفتن یک تصویر از محدوده سلول هدف در Excel و تنظیم آن به‌عنوان تصویر جای‌نگهدار فریم OLE، می‌توانید به‌جای متن پیش‌فرض، یک پیش‌نمایش سفارشی نمایش دهید.

## **مقالات مرتبط**

[ایجاد یک نمودار Excel و جاسازی آن در ارائه به‌عنوان شی OLE](/slides/fa/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[به‌روزرسانی خودکار اشیای OLE با استفاده از افزودنی MS PowerPoint](/slides/fa/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)