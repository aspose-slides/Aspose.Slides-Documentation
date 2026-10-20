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
description: "رفع مشکل تغییر اندازه OLE کاربرگ اکسل در ارائه‌ها: دو روش برای حفظ سازگاری چارچوب‌های شی—مقیاس‌بندی چارچوب یا صفحه—در قالب‌های PPT و PPTX."
---
{{% alert color="info" title="Note" %}}
کاربرگ‌های اکسل که به عنوان اشیاء OLE در یک ارائه PowerPoint با استفاده از اجزای Aspose جاسازی می‌شوند ممکن است پس از اولین فعال‌سازی به‌صورت غیرمنتظره‌‎ای اندازه‌شان تغییر کند. این رفتار تفاوت بصری قابل‌توجهی بین شی OLE قبل و بعد از فعال‌سازی ایجاد می‌کند. این مقاله به توضیح مشکل می‌پردازد و دو روش برای رفع آن شرح می‌دهد.
{{% /alert %}}

## **پیش‌زمینه**

در مقاله [مدیریت OLE](/slides/fa/java/manage-ole/) ما توضیح دادیم که چگونه یک چارچوب OLE را به یک ارائه PowerPoint با استفاده از Aspose.Slides for Java اضافه کنیم. برای رفع [مشکل پیش‌نمایش شی](/slides/fa/java/object-preview-issue-when-adding-oleobjectframe/) یک تصویر از ناحیه کاربرگ انتخاب‌شده را به چارچوب شی OLE اختصاص دادیم. در ارائه خروجی، وقتی دو بار روی چارچوب شی OLE که تصویر کاربرگ را نمایش می‌دهد کلیک کنید، دفترکار اکسل فعال می‌شود. کاربران نهایی می‌توانند هر تغییر دلخواهی را در دفترکار واقعی اکسل اعمال کرده و سپس با کلیک خارج از دفترکار فعال شده به اسلاید بازگردند. اندازه چارچوب شی OLE هنگام بازگشت کاربر به اسلاید تغییر خواهد کرد. ضریب تغییر اندازه بسته به اندازه چارچوب شی OLE و دفترکار اکسل جاسازی‌شده متفاوت خواهد بود.

## **دلیل تغییر اندازه**

از آنجا که دفترکار اکسل دارای اندازه پنجره خود است، سعی می‌کند اندازه اصلی خود را در اولین فعال‌سازی حفظ کند. از سوی دیگر، چارچوب شی OLE اندازه خاص خود را دارد. طبق گفته مایکروسافت، هنگامی که دفترکار اکسل فعال می‌شود، اکسل و PowerPoint برای تعیین اندازه مذاکره می‌کنند تا نسبت‌های صحیح را در فرآیند جاسازی حفظ کنند. تغییر اندازه بر اساس تفاوت‌های بین اندازه پنجره اکسل و اندازه و موقعیت چارچوب شی OLE انجام می‌شود.

## **راه‌حل عملی**

دو راه‌حل ممکن برای جلوگیری از اثر تغییر اندازه وجود دارد.

- اندازه چارچوب OLE را در ارائه PowerPoint به‌طوری مقیاس‌بندی کنید که با ارتفاع و عرض کل ردیف‌ها و ستون‌های انتخاب‌شده مطابقت داشته باشد.
- اندازه چارچوب OLE را ثابت نگه داشته و ردیف‌ها و ستون‌های انتخاب‌شده را مقیاس‌بندی کنید تا درون آن جا شوند.

### **مقیاس‌بندی اندازه چارچوب OLE**

این رویکرد اندازه چارچوب OLE را به‌طوری تنظیم می‌کند که با ارتفاع و عرض کل ردیف‌ها و ستون‌های انتخاب‌شده در کاربرگ اکسل جاسازی‌شده مطابقت داشته باشد.

در این مثال یک دفترکار اکسل موجود بارگذاری می‌شود و اولین 10 ردیف و 13 ستون از اولین کاربرگ آن با استفاده از شاخص‌های صفر‑پایه انتخاب می‌شوند. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) محدوده نمایش داده‌شده را تعریف می‌کند. پیش‌نمایش با 96 DPI رندر می‌شود و ابعاد پیکسل آن با استفاده از 72 پوینت در اینچ به پوینت تبدیل می‌شوند. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) دفترکار اصلاح‌شده را در یک چارچوب با آن ابعاد جاسازی می‌کند. پیش‌نمایش از طریق [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) برای جایگزینی متن محفوظ «EMBEDDED OLE OBJECT» در ارائه ذخیره‌شده اختصاص داده می‌شود.

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

// تنظیم اندازه نمایش داده شده زمانی که فایل کارپوشه به عنوان شی OLE در PowerPoint استفاده می‌شود.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// دریافت عرض و ارتفاع تصویر OLE به واحد پوینت.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// ما نیاز به استفاده از کتاب‌کار تغییر یافته داریم.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// افزودن تصویر OLE به منابع ارائه.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// ایجاد چارچوب شی OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

کمک‌گیرنده پیش‌نمایش [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) را به محدوده انتخاب‌شده تنظیم می‌کند و حاشیه‌ها، سرصفحه و پاورقی‌ها را حذف می‌نماید. با فعال بودن [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-)، [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) محدوده را به‌صورت تصویر PNG رندر می‌کند. این کمک‌گیرنده یک جریان ورودی جدید حاوی تصویر PNG برمی‌گرداند که در ابتدای آن قرار دارد تا در ارائه استفاده شود.

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

### **مقیاس‌بندی اندازه محدوده سلول**

این رویکرد ارتفاع ردیف‌های انتخاب‌شده و عرض ستون‌های انتخاب‌شده را مقیاس می‌دهد تا با یک اندازه سفارشی چارچوب OLE مطابقت داشته باشد.

در این مثال یک دفترکار اکسل موجود بارگذاری می‌شود و اولین 10 ردیف و 13 ستون از اولین کاربرگ آن با استفاده از شاخص‌های صفر‑پایه انتخاب می‌شوند. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) محدوده نمایش داده‌شده را تعریف می‌کند و کمک‌گیرنده زیر آن محدوده را به‌طوری مقیاس می‌دهد که در چارچوبی به عرض 400 پوینت و ارتفاع 100 پوینت جای بگیرد. پس از ذخیره دفترکار اصلاح‌شده در یک جریان، [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) آن را با اندازه مشخص جاسازی می‌کند. پیش‌نمایشی که با 96 DPI رندر شده از طریق [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) اختصاص داده می‌شود، به‌طوری که ارائه ذخیره‌شده سلول‌های انتخاب‌شده را به‌جای متن محفوظ پیش‌فرض نشان دهد.

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

// تنظیم اندازه نمایش داده شده هنگام استفاده از فایل کتاب‌کار به عنوان شی OLE در PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// مقیاس‌بندی محدوده سلولی برای متناسب شدن با اندازه چارچوب.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// ما نیاز داریم از کتاب‌کار اصلاح‌شده استفاده کنیم.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// افزودن تصویر OLE به منابع ارائه.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// ایجاد چارچوب شی OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

کمک‌گیرنده مقیاس‌گذاری نسبت‌های عرض و ارتفاع جداگانه‌ای برای محدوده انتخاب‌شده محاسبه می‌کند و عرض نسبی ستون‌ها و ارتفاع نسبی ردیف‌ها را حفظ می‌نماید. ابعاد محاسبه‌شده را قبل از اعمال با [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) و [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-) از پوینت به اینچ تبدیل می‌کند. محدوده انتخاب‌شده باید عرض و ارتفاع غیر صفر داشته باشد.

```java
/**
 * @param width     عرض مورد انتظار محدوده سلولی به پوینت.
 * @param height    ارتفاع مورد انتظار محدوده سلولی به پوینت.
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

این کمک‌گیرنده پیش‌نمایش محدوده تغییر سایز یافته را با استفاده از [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) رندر می‌کند. [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) را به آن محدوده محدود می‌سازد، حاشیه‌ها، سرصفحه و پاورقی‌ها را حذف می‌کند و یک جریان PNG را که در ابتدای آن قرار دارد بازمی‌گرداند.

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
دو رویکرد برای رفع مشکل تغییر اندازه کاربرگ وجود دارد. رویکردی را انتخاب کنید که با نیازها و مورد استفاده شما بیشترین تطابق را داشته باشد. هر دو رویکرد به‌یک‌سان کار می‌کنند، چه ارائه‌ها از قالب ساخته شوند و چه از ابتدا. علاوه بر این، در این راه‌حل هیچ محدودیتی برای اندازه چارچوب شی OLE وجود ندارد.
{{% /alert %}}

## **سوالات متداول**

**چرا یک کاربرگ اکسل جاسازی‌شده هنگام اولین فعال‌سازی در PowerPoint اندازه‌اش تغییر می‌کند؟**

این به این دلیل رخ می‌دهد که اکسل سعی می‌کند اندازه اصلی پنجره خود را هنگام فعال‌سازی حفظ کند، در حالی که چارچوب شی OLE در PowerPoint ابعاد خود را دارد. PowerPoint و اکسل برای حفظ نسبت تصویر اندازه را مذاکره می‌کنند که می‌تواند باعث تغییر اندازه شود.

**آیا می‌توان این مشکل تغییر اندازه را به طور کامل جلوگیری کرد؟**

بله. با مقیاس‌بندی چارچوب OLE به اندازه محدوده سلول‌های اکسل یا مقیاس‌بندی محدوده سلولی به اندازه چارچوب OLE مورد نظر، می‌توانید از تغییر اندازه ناخواسته جلوگیری کنید.

**کدام روش مقیاس‌بندی را باید استفاده کنم، مقیاس‌گذاری چارچوب OLE یا مقیاس‌گذاری محدوده سلول؟**

اگر می‌خواهید اندازه‌های اصلی ردیف‌ها و ستون‌های اکسل حفظ شود، **مقیاس‌گذاری چارچوب OLE** را انتخاب کنید. اگر می‌خواهید یک اندازه ثابت برای چارچوب OLE در ارائه‌تان داشته باشید، **مقیاس‌گذاری محدوده سلول** را انتخاب کنید.

**آیا این راه‌حل‌ها در صورتی که ارائه من بر پایه یک قالب باشد کار می‌کنند؟**

بله. هر دو راه‌حل برای ارائه‌های ساخته‌شده از قالب‌ها و از ابتدا کار می‌کنند.

**آیا محدودیتی برای اندازه چارچوب OLE هنگام استفاده از این روش‌ها وجود دارد؟**

خیر. می‌توانید چارچوب شی OLE را به هر اندازه‌ای تنظیم کنید تا زمانی که مقیاس را به‌درستی تنظیم نمایید.

**آیا راهی برای جلوگیری از متن جای‌دار «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟**

بله. با گرفتن یک snapshot از محدوده سلول هدف در اکسل و تنظیم آن به‌عنوان تصویر جای‌دار چارچوب OLE، می‌توانید یک تصویر پیش‌نمایش سفارشی به‌جای جای‌دار پیش‌فرض نمایش دهید.

## **مقالات مرتبط**

[ایجاد نمودار اکسل و جاسازی آن در یک ارائه به‌عنوان شی OLE](/slides/fa/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[به‌روزرسانی خودکار اشیاء OLE با استفاده از یک افزونه MS PowerPoint](/slides/fa/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)