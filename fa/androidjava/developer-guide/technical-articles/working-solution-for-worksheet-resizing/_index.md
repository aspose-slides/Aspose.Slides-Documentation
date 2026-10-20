---
title: راه‌حل عملی برای تغییر اندازه برگه کاری
type: docs
weight: 20
url: /fa/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- تصویر پیش‌نمایش
- تغییر اندازه تصویر
- Excel
- برگه کاری
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "رفع تغییر اندازه OLE برگه Excel در ارائه‌ها: دو روش برای حفظ سازگاری فریم‌های شی—مقیاس‌گذاری فریم یا برگه—در قالب‌های PPT و PPTX."
---
{{% alert color="info" title="Note" %}}

برگه‌های Excel که به‌عنوان اشیاء OLE در یک ارائه PowerPoint با استفاده از مؤلفه‌های Aspose جاسازی می‌شوند، ممکن است پس از اولین فعال‌سازی به‌طور غیرمنتظره‌ای تغییر اندازه دهند. این رفتار تفاوت بصری قابل‌توجهی بین شی OLE قبل و بعد از فعال‌سازی ایجاد می‌کند. این مقاله مسئله را توضیح می‌دهد و دو راه برای رفع آن را بیان می‌کند.

{{% /alert %}}

## **پس‌زمینه**

در مقاله [مدیریت OLE](/slides/fa/androidjava/manage-ole/)، نحوه افزودن یک فریم OLE به یک ارائه PowerPoint با استفاده از Aspose.Slides برای Android از طریق Java را شرح دادیم. برای رفع [مشکل پیش‌نمایش شی](/slides/fa/androidjava/object-preview-issue-when-adding-oleobjectframe/)، یک تصویر از ناحیه انتخاب‌شده برگه کار را به فریم OLE اختصاص دادیم. در ارائهٔ خروجی، وقتی فریم OLE که نمایشگر تصویر برگه است را دوبار کلیک می‌کنید، کتاب‌کار Excel فعال می‌شود. کاربران نهایی می‌توانند هر تغییر دلخواهی را در کتاب‌کار واقعی Excel اعمال کرده و سپس با کلیک خارج از کتاب‌کار فعال به اسلاید بازگردند. اندازهٔ فریم OLE پس از بازگشت کاربر به اسلاید تغییر خواهد کرد. عامل تغییر اندازه بسته به اندازهٔ فریم OLE و کتاب‌کار Excel جاسازی‌شده متفاوت است.

## **علت تغییر اندازه**

از آنجا که کتاب‌کار Excel دارای اندازهٔ پنجرهٔ خود است، سعی می‌کند هنگام اولین فعال‌سازی اندازهٔ اصلی خود را حفظ کند. از سوی دیگر، فریم OLE دارای اندازهٔ خاص خود است. بر اساس گفتهٔ مایکروسافت، هنگام فعال‌سازی کتاب‌کار Excel، Excel و PowerPoint برای حفظ نسبت‌های صحیح در فرآیند جاسازی، دربارهٔ اندازه مذاکره می‌کنند. تغییر اندازه بر پایهٔ تفاوت‌های بین اندازهٔ پنجرهٔ Excel و اندازه و موقعیت فریم OLE اتفاق می‌افتد.

## **راه‌حل عملی**

دو راه‌حل برای جلوگیری از اثر تغییر اندازه وجود دارد.

- مقیاس‌گذاری فریم OLE در ارائه PowerPoint به‌طوری که ارتفاع و عرض کل ردیف‌ها و ستون‌های انتخاب‌شده را پوشش دهد.
- ثابت نگه داشتن اندازهٔ فریم OLE و مقیاس‌گذاری ردیف‌ها و ستون‌های انتخاب‌شده برای جای‌گیری در آن.

### **مقیاس‌گذاری اندازه فریم OLE**

این رویکرد اندازهٔ فریم OLE را طوری تنظیم می‌کند که ارتفاع و عرض کل ردیف‌ها و ستون‌های انتخاب‌شده در برگه Excel جاسازی‌شده را پوشش دهد.

مثال یک کتاب‌کار Excel موجود را بارگذاری می‌کند و اولین ۱۰ ردیف و ۱۳ ستون برگهٔ اول آن را با استفاده از ایندکس‌های صفر‑پایه انتخاب می‌کند. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) محدودهٔ نمایش داده‌شده را تعریف می‌کند. پیش‌نمایش با ۹۶ DPI رندر می‌شود و ابعاد پیکسل آن با استفاده از ۷۲ پونت در اینچ به پونت تبدیل می‌شود. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) کتاب‌کار تغییر یافته را در فریمی با این ابعاد جاسازی می‌کند. پیش‌نمایش از طریق [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) اختصاص داده می‌شود تا متن جایگزین «EMBEDDED OLE OBJECT» در ارائهٔ ذخیره‌شده را جایگزین کند.

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

// اندازهٔ نمایش داده‌شده را تنظیم کنید هنگامی که فایل کتاب‌کار به‌عنوان شی OLE در PowerPoint استفاده می‌شود.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// عرض و ارتفاع تصویر OLE را به پونت دریافت کنید.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// ما باید از کتاب‌کار اصلاح‌شده استفاده کنیم.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// تصویر OLE را به منابع ارائه اضافه کنید.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// فریم شی OLE را ایجاد کنید.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

کمک‌کنندهٔ پیش‌نمایش [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) را به محدودهٔ انتخاب‌شده تنظیم می‌کند و حاشیه‌ها، سرصفحه‌ها و پاورقی‌ها را حذف می‌نماید. با فعال‌سازی [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-)، [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) محدوده را به‌عنوان تصویر PNG رندر می‌کند. این کمک‌کننده یک جریان ورودی جدید شامل تصویر PNG را برمی‌گرداند که در ابتدای خود قرار دارد تا در ارائه مورد استفاده قرار گیرد.

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

### **مقیاس‌گذاری اندازه محدوده سلول**

این رویکرد ارتفاع ردیف‌های انتخاب‌شده و عرض ستون‌های انتخاب‌شده را طوری مقیاس می‌دهد که اندازهٔ سفارشی فریم OLE را برآورده کند.

مثال یک کتاب‌کار Excel موجود را بارگذاری می‌کند و اولین ۱۰ ردیف و ۱۳ ستون برگهٔ اول آن را با ایندکس‌های صفر‑پایه انتخاب می‌کند. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) محدودهٔ نمایش داده‌شده را تعریف می‌کند و کمک‌کنندهٔ زیر آن محدوده را طوری مقیاس می‌کند که در فریمی به عرض ۴۰۰ پونت و ارتفاع ۱۰۰ پونت جای بگیرد. پس از ذخیرهٔ کتاب‌کار تغییر یافته در یک جریان، [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) آن را با اندازهٔ مشخص‌شده جاسازی می‌کند. پیش‌نمایش رندر شده با ۹۶ DPI از طریق [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) اختصاص داده می‌شود، بنابراین ارائهٔ ذخیره‌شده به‌جای متن پیش‌فرض، سلول‌های انتخاب‌شده را نمایش می‌دهد.

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

// اندازهٔ نمایش داده‌شده را تنظیم کنید هنگامی که فایل کتاب‌کار به‌عنوان شی OLE در PowerPoint استفاده می‌شود.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// محدودهٔ سلولی را برای متناسب شدن با اندازهٔ فریم مقیاس‌گذاری کنید.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// ما باید از کتاب‌کار اصلاح‌شده استفاده کنیم.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// تصویر OLE را به منابع ارائه اضافه کنید.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// فریم شی OLE را ایجاد کنید.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

کمک‌کنندهٔ مقیاس‌گذاری نسبت‌های عرض و ارتفاع جداگانه‌ای برای محدودهٔ انتخاب‌شده محاسبه می‌کند و عرض نسبی ستون‌ها و ارتفاع نسبی ردیف‌ها را حفظ می‌کند. ابعاد محاسبه‌شده ابتدا از پونت به اینچ تبدیل می‌شوند و سپس با استفاده از [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) و [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-) اعمال می‌شوند. محدودهٔ انتخاب‌شده باید عرض و ارتفاع غیر صفر داشته باشد.

```java
/**
 * @param width     عرض مورد انتظار محدودهٔ سلول برحسب پونت.
 * @param height    ارتفاع مورد انتظار محدودهٔ سلول برحسب پونت.
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

این کمک‌کنندهٔ پیش‌نمایش محدودهٔ تغییر اندازه را با استفاده از [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) رندر می‌کند. [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) را به همان محدوده محدود می‌کند، حاشیه‌ها، سرصفحه‌ها و پاورقی‌ها را حذف می‌نماید و یک جریان PNG در ابتدای خود برمی‌گرداند.

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

{{% alert color="info" title="Note" %}}

دو رویکرد برای رفع مشکل تغییر اندازهٔ برگه وجود دارد. رویکردی را انتخاب کنید که بهتر با نیازها و موارد استفاده‌تان سازگار باشد. هر دو رویکرد به‌یک شکل عمل می‌کنند، چه ارائه‌ها از الگو ساخته شوند و چه از ابتدا. علاوه بر این، در این راه‌حل محدودیتی برای اندازهٔ فریم OLE وجود ندارد.

{{% /alert %}}

## **سوالات متداول**

**چرا یک برگهٔ Excel جاسازی‌شده پس از اولین فعال‌سازی در PowerPoint اندازهٔ خود را تغییر می‌دهد؟**

این به‌این دلیل است که Excel سعی می‌کند اندازهٔ اصلی پنجرهٔ خود را حفظ کند، در حالی که فریم OLE در PowerPoint ابعاد خاص خود را دارد. PowerPoint و Excel برای حفظ نسبت‌ ابعادی مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

**آیا می‌توان این مشکل تغییر اندازه را کاملاً جلوگیری کرد؟**

بله. با مقیاس‌گذاری فریم OLE برای متناسب شدن با اندازهٔ محدودهٔ سلول‌های Excel یا مقیاس‌گذاری محدودهٔ سلول‌ها برای متناسب شدن با اندازهٔ دلخواه فریم OLE، می‌توانید از تغییر اندازه ناخواسته جلوگیری کنید.

**کدام روش مقیاس‌گذاری را باید انتخاب کنم، مقیاس‌گذاری فریم OLE یا مقیاس‌گذاری محدوده سلول؟**

اگر می‌خواهید اندازهٔ اصلی ردیف‌ها و ستون‌های Excel حفظ شود، **مقیاس‌گذاری فریم OLE** را انتخاب کنید. اگر نیاز به اندازهٔ ثابت برای فریم OLE در ارائه دارید، **مقیاس‌گذاری محدوده سلول** را برگزینید.

**آیا این راه‌حل‌ها اگر ارائه من بر اساس یک الگو باشد کار می‌کنند؟**

بله. هر دو راه‌حل برای ارائه‌های ساخته‌شده از الگوها و یا از ابتدا عمل می‌کنند.

**آیا محدودیتی برای اندازهٔ فریم OLE هنگام استفاده از این روش‌ها وجود دارد؟**

خیر. می‌توانید فریم OLE را به هر اندازه‌ای تنظیم کنید به شرطی که مقیاس را به‌طور مناسب تنظیم کنید.

**آیا راهی برای جلوگیری از متن جایگزین «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟**

بله. با گرفتن یک تصویر از محدودهٔ سلول‌های هدف Excel و تنظیم آن به‌عنوان تصویر جایگزین فریم OLE، می‌توانید یک تصویر پیش‌نمایش سفارشی به جای متن پیش‌فرض نمایش دهید.

## **مقالات مرتبط**

[ایجاد نمودار Excel و جاسازی آن در ارائه به‌عنوان شی OLE](/slides/fa/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[به‌روزرسانی خودکار اشیاء OLE با استفاده از افزونهٔ MS PowerPoint](/slides/fa/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)