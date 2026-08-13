---
title: راه حل عملی برای تغییر اندازه ورق کاری
type: docs
weight: 20
url: /fa/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- تصویر پیش‌نمایش
- تغییر اندازه تصویر
- Excel
- ورق کاری
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "رفع مشکل تغییر اندازه OLE ورق کاری Excel در ارائه‌ها: دو راه برای حفظ سازگاری قاب‌ها — مقیاس‌بندی قاب یا برگه — در فرمت‌های PPT و PPTX."
---
{{% alert color="info" %}}

مشاهده شده است که ورق‌های کاری Excel که به عنوان اشیای OLE در یک ارائه PowerPoint از طریق اجزای Aspose جاسازی می‌شوند، پس از اولین فعال‌سازی به مقیاسی نامشخص تغییر اندازه می‌دهند. این رفتار اختلاف بصری قابل‌توجهی بین حالت قبل و بعد از فعال‌سازی شی OLE در ارائه ایجاد می‌کند. ما این مشکل را به‌صورت جزئی بررسی کرده و راه‌حلی ارائه داده‌ایم که در این مقاله پوشش داده شده است.

{{% /alert %}}

## **Background**

در مقاله [Manage OLE](/slides/fa/androidjava/manage-ole/) توضیح دادیم که چطور یک قاب OLE را به یک ارائه PowerPoint با استفاده از Aspose.Slides برای Android via Java اضافه کنیم. برای رفع [object preview issue](/slides/fa/androidjava/object-preview-issue-when-adding-oleobjectframe/) تصویر ناحیه انتخاب‌شده از ورق کاری را به قاب شی OLE اختصاص دادیم. در ارائه خروجی، وقتی بر روی قاب شی OLE که تصویر ورق کاری را نشان می‌دهد دو بار کلیک می‌کنید، کتاب‌کار Excel فعال می‌شود. کاربران نهایی می‌توانند هر تغییری را در کتاب‌کار واقعی Excel اعمال کنند و سپس با کلیک خارج از کتاب‌کار فعال شده به اسلاید بازگردند. اندازهٔ قاب شی OLE هنگام بازگشت کاربر به اسلاید تغییر خواهد کرد. عامل تغییر اندازه بسته به اندازهٔ قاب شی OLE و کتاب‌کار Excel جاسازی‌شده متفاوت است.

## **Cause of Resizing**

از آنجایی که کتاب‌کار Excel دارای اندازهٔ پنجرهٔ خاص خود است، سعی می‌کند پس از اولین فعال‌سازی اندازهٔ اصلی خود را حفظ کند. از سوی دیگر، قاب شی OLE اندازهٔ خود را دارد. بر اساس گفتهٔ مایکروسافت، هنگام فعال‌سازی کتاب‌کار Excel، Excel و PowerPoint برای اطمینان از حفظ نسبت‌های صحیح در فرآیند جاسازی، اندازه را مذاکره می‌کنند. تغییر اندازه بر اساس تفاوت بین اندازهٔ پنجرهٔ Excel و اندازه و موقعیت قاب شی OLE اتفاق می‌افتد.

## **Working Solution**

دو راه‌حل ممکن برای جلوگیری از اثر تغییر اندازه وجود دارد.

- مقیاس‌بندی اندازهٔ قاب OLE در ارائه PowerPoint برای مطابقت با ارتفاع و عرض تعداد ردیف‌ها و ستون‌های موردنظر در قاب OLE.
- ثابت نگه داشتن اندازهٔ قاب OLE و مقیاس‌بندی اندازهٔ ردیف‌ها و ستون‌های مشارکتی برای سازگار شدن با اندازهٔ انتخاب‌شدهٔ قاب OLE.

### **Scale the OLE Frame Size**

در این روش، نحوه تنظیم اندازهٔ قاب OLE کتاب‌کار Excel جاسازی‌شده را طوری که با اندازهٔ تجمعی ردیف‌ها و ستون‌های مشارکتی در ورق کاری مطابقت داشته باشد، یاد می‌گیریم.

فرض کنید یک شیت قالب Excel داریم و می‌خواهیم آن را به عنوان یک قاب OLE به ارائه اضافه کنیم. در این سناریو، اندازهٔ قاب شی OLE ابتدا بر اساس مجموع ارتفاع ردیف‌ها و عرض ستون‌های مشارکتی در کتاب‌کار محاسبه می‌شود. سپس اندازهٔ قاب OLE را به این مقدار محاسبه‌شده تنظیم می‌کنیم. برای جلوگیری از پیام قرمز «EMBEDDED OLE OBJECT» برای قاب OLE در PowerPoint، تصویری از بخش‌های موردنظر ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و آن را به عنوان تصویر قاب OLE تنظیم می‌کنیم.

```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// اندازهٔ نمایش داده‌شده را زمانی که فایل کتاب‌کار به عنوان شی OLE در PowerPoint استفاده می‌شود، تنظیم می‌کند.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// عرض و ارتفاع تصویر OLE را به‌واحد نقاط (points) به‌دست می‌آورد.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// ما باید از کتاب‌کار تغییر یافته استفاده کنیم.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// تصویر OLE را به منابع ارائه اضافه می‌کنیم.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// قاب شی OLE را ایجاد می‌کنیم.
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

### **Scale the Cell Range Size**

در این روش، نحوه مقیاس‌بندی ارتفاع ردیف‌های مشارکتی و عرض ستون‌های مشارکتی برای مطابقت با یک اندازهٔ سفارشی قاب OLE را می‌آموزیم.

فرض کنید یک شیت قالب Excel داریم و می‌خواهیم آن را به عنوان یک قاب OLE به ارائه اضافه کنیم. در این سناریو، اندازهٔ قاب OLE را تنظیم می‌کنیم و اندازهٔ ردیف‌ها و ستون‌هایی که در ناحیهٔ قاب OLE مشارکت دارند را مقیاس‌بندی می‌کنیم. سپس کتاب‌کار را به یک استریم ذخیره می‌کنیم تا تغییرات اعمال شود و به یک آرایه بایت تبدیل می‌کنیم تا به قاب OLE اضافه شود. برای جلوگیری از پیام قرمز «EMBEDDED OLE OBJECT» برای قاب OLE در PowerPoint، تصویری از بخش‌های مطلوب ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و آن را به عنوان تصویر قاب OLE تنظیم می‌کنیم.

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

// اندازهٔ نمایش داده‌شده را زمانی که فایل کتاب‌کار به عنوان شی OLE در PowerPoint استفاده می‌شود، تنظیم می‌کند.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// محدودهٔ سلول‌ها را برای مطابقت با اندازهٔ قاب مقیاس‌بندی می‌کند.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// ما باید از کتاب‌کار تغییر یافته استفاده کنیم.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// تصویر OLE را به منابع ارائه اضافه می‌کنیم.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// قاب شی OLE را ایجاد می‌کنیم.
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
 * @param width     عرض مورد انتظار محدودهٔ سلول‌ها در واحد نقاط.
 * @param height    ارتفاع مورد انتظار محدودهٔ سلول‌ها در واحد نقاط.
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

## **Conclusion**

{{% alert color="info" %}} 

دو رویکرد برای رفع مشکل تغییر اندازه ورق کاری وجود دارد. انتخاب رویکرد مناسب بستگی به نیازها و موارد استفاده خاص دارد. هر دو رویکرد به‌طور مشابه کار می‌کنند، چه ارائه‌ها از قالب ساخته شوند چه از صفر. علاوه بر این، در این راه‌حل محدودیتی برای اندازهٔ قاب OLE وجود ندارد.

{{% /alert %}}

## **FAQ**

### چرا یک ورق کاری Excel جاسازی‌شده پس از اولین فعال‌سازی در PowerPoint اندازه تغییر می‌دهد؟

این به این دلیل است که Excel سعی می‌کند اندازهٔ پنجرهٔ اصلی خود را هنگام فعال‌سازی حفظ کند، در حالی که قاب شی OLE در PowerPoint ابعاد خاص خود را دارد. PowerPoint و Excel برای حفظ نسبت ابعاد، اندازه را مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

### آیا می‌توان این مشکل تغییر اندازه را به‌طور کامل جلوگیری کرد؟

بله. با مقیاس‌بندی قاب OLE به اندازهٔ محدودهٔ سلول‌های Excel یا مقیاس‌بندی محدودهٔ سلول‌ها به اندازهٔ دلخواه قاب OLE، می‌توانید از تغییر اندازه ناخواسته جلوگیری کنید.

### کدام روش مقیاس‌بندی را باید استفاده کنم، مقیاس‌بندی قاب OLE یا مقیاس‌بندی محدودهٔ سلول؟

اگر می‌خواهید اندازهٔ ردیف‌ها و ستون‌های اصلی Excel را حفظ کنید، **مقیاس‌بندی قاب OLE** را انتخاب کنید. اگر به یک اندازهٔ ثابت برای قاب OLE در ارائه نیاز دارید، **مقیاس‌بندی محدودهٔ سلول** را انتخاب کنید.

### آیا این راه‌حل‌ها در صورتی که ارائه من بر پایه یک قالب باشد، کار می‌کند؟

بله. هر دو راه‌حل برای ارائه‌های ساخته‌شده از قالب‌ها و همچنین از صفر کار می‌کنند.

### آیا محدودیتی برای اندازهٔ قاب OLE هنگام استفاده از این روش‌ها وجود دارد؟

خیر. می‌توانید قاب شی OLE را به هر اندازه‌ای تنظیم کنید تا زمانی که مقیاس را به‌طور مناسب تنظیم کنید.

### آیا راهی برای حذف متن جای‌گیر «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟

بله. با گرفتن یک تصویر از محدودهٔ سلول هدف Excel و تنظیم آن به‌عنوان تصویر جای‌گیر قاب OLE، می‌توانید به‌جای متن پیش‌فرض، یک تصویر پیش‌نمایش سفارشی نمایش دهید.