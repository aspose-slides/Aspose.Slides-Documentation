---
title: حل عملي لتغيير حجم ورقة العمل
type: docs
weight: 20
url: /ar/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة المعاينة
- تغيير حجم الصورة
- Excel
- ورقة عمل
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إصلاح مشكلة تغيير حجم OLE لورقة عمل Excel في العروض التقديمية: طريقتان للحفاظ على إطارات الكائن متسقة—تغيير حجم الإطار أو الورقة—عبر صيغ PPT و PPTX."
---
{{% alert color="info" title="Note" %}}

قد يتم تغيير حجم أوراق عمل Excel المدمجة ككائنات OLE في عرض تقديمي PowerPoint باستخدام مكوّنات Aspose بشكل غير متوقع بعد أول تفعيل لها. يُنشئ هذا السلوك فرقًا بصريًا واضحًا بين كائن OLE قبل التفعيل وبعده. تُوضح هذه المقالة المشكلة وتصف طريقتين لمعالجتها.

{{% /alert %}}

## **الخلفية**

في المقالة [إدارة OLE](/slides/ar/java/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض تقديمي PowerPoint باستخدام Aspose.Slides for Java. لمعالجة [مشكلة معاينة العنصر](/slides/ar/java/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة للمنطقة المحددة من ورقة العمل إلى إطار كائن OLE. في العرض الناتج، عندما تنقر مزدوجًا على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تفعيل مصنف Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة على المصنف الفعلي ثم العودة إلى الشريحة بالنقر خارج المصنف النشط. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. سيتفاوت عامل تغيير الحجم تبعًا لحجم إطار كائن OLE ومصنف Excel المدمج.

## **سبب تغيير الحجم**

نظرًا لأن مصنف Excel له حجم نافذته الخاص، فإنه يحاول الحفاظ على حجمه الأصلي عند أول تفعيل. من ناحية أخرى، يمتلك إطار كائن OLE حجمه الخاص. وفقًا لـ Microsoft، عندما يتم تفعيل المصنف، يتفاوض Excel وPowerPoint على الحجم لضمان الحفاظ على النسبة الصحيحة كجزء من عملية الإدمج. يحدث تغيير الحجم بناءً على الفروقات بين حجم نافذة Excel وحجم وموقع إطار كائن OLE.

## **الحل العملي**

هناك حلّان محتملان لتجنب تأثير تغيير الحجم.

- تعديل حجم إطار OLE في عرض PowerPoint ليتطابق مع الارتفاع والعرض الكلي للصفوف والأعمدة المحددة.
- إبقاء حجم إطار OLE ثابتًا وتعديل حجم الصفوف والأعمدة المحددة لتناسب الإطار.

### **تعديل حجم إطار OLE**

تضبط هذه الطريقة حجم إطار OLE ليتطابق مع الارتفاع والعرض الكلي للصفوف والأعمدة المحددة في ورقة Excel المدمجة.

يحمّل المثال مصنف Excel موجود ويختار أول 10 صفوف و13 عمودًا من ورقته الأولى باستخدام فهارس بدءًا من الصفر. تُعرّف [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) النطاق المعروض. يتم عرض المعاينة بدقة 96 DPI، وتُحوَّل أبعادها بالبكسل إلى نقاط باستخدام 72 نقطة لكل بوصة. تُدرج [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) المصنف المعدل في إطار بهذه الأبعاد. تُعيّن المعاينة من خلال [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) لاستبدال العنصر النائب "EMBEDDED OLE OBJECT" في العرض المحفوظ.

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

// تعيين الحجم المعروض عندما يُستخدم ملف المصنف ككائن OLE في PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// الحصول على عرض وارتفاع صورة OLE بالنقاط.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// نحتاج إلى استخدام المصنف المعدل.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// إضافة صورة OLE إلى موارد العرض التقديمي.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// إنشاء إطار كائن OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

يحدد المساعد للمعاينة [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) للنطاق المختار ويزيل الهوامش والرؤوس والتذييلات. مع تفعيل [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-)، تُحوَّل [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) النطاق إلى صورة PNG. يرجع المساعد تدفق إدخال جديد يحتوي على صورة PNG، موضعه في بدايته للاستخدام في العرض.

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

### **تعديل حجم نطاق الخلايا**

تقوم هذه الطريقة بتعديل ارتفاع الصفوف المحددة وعرض الأعمدة المحددة لتتناسب مع حجم إطار OLE مخصص.

يحمّل المثال مصنف Excel موجود ويختار أول 10 صفوف و13 عمودًا من ورقته الأولى باستخدام فهارس بدءًا من الصفر. تُعرّف [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) النطاق المعروض، ويُعدل المساعد أدناه هذا النطاق ليتناسب مع إطار عرضه 400 نقطة وارتفاعه 100 نقطة. بعد حفظ المصنف المعدل إلى تدفق، تُدرج [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-)ه بالحجم المحدد. تُعيّن معاينة بدقة 96 DPI من خلال [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--)، بحيث يعرض العرض المحفوظ الخلايا المحددة بدلاً من العنصر النائب الافتراضي.

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

// تعيين الحجم المعروض عندما يُستخدم ملف المصنف ككائن OLE في PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// تحجيم نطاق الخلايا ليتناسب مع حجم الإطار.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// نحتاج إلى استخدام المصنف المعدل.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// إضافة صورة OLE إلى موارد العرض التقديمي.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// إنشاء إطار كائن OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

يحسب المساعد للتوسيع نسب العرض والارتفاع المنفصلة للنطاق المختار، محافظًا على نسب عرض الأعمدة وارتفاع الصفوف النسبية. يُحوِّل الأبعاد المحسوبة من النقاط إلى بوصات قبل تطبيقها عبر [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) و[Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). يجب أن يكون للنطاق المختار عرض وارتفاع غير صفريين.

```java
/**
 * @param width     العرض المتوقع لنطاق الخلايا بالنقاط.
 * @param height    الارتفاع المتوقع لنطاق الخلايا بالنقاط.
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

يقوم هذا المساعد للمعاينة بتحويل النطاق الموسع باستخدام [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). يحدّ [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) إلى ذلك النطاق، ويزيل الهوامش والرؤوس والتذييلات، ويُعيد تدفق PNG موضعه في بدايته.

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

## **الخاتمة**

{{% alert color="info" title="Note" %}}

هناك طريقتان لإصلاح مشكلة تغيير حجم ورقة العمل. اختر الطريقة التي تتناسب مع متطلباتك وحالة الاستخدام. كلا الطريقتين تعملان بنفس الطريقة، سواء تم إنشاء العروض من قالب أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.

{{% /alert %}}

## **الأسئلة المتكررة**

**لماذا يتغير حجم ورقة Excel المدمجة عند أول تفعيل لها في PowerPoint؟**

يحدث ذلك لأن Excel يحاول الحفاظ على حجم نافذته الأصلي عند التفعيل، بينما يمتلك إطار كائن OLE في PowerPoint أبعادًا خاصة به. يتفاوض PowerPoint وExcel على الحجم للحفاظ على النسبة، ما قد يؤدي إلى تغيير الحجم.

**هل يمكن منع مشكلة تغيير الحجم تمامًا؟**

نعم. من خلال تعديل إطار OLE ليتناسب مع حجم نطاق خلايا Excel أو تعديل نطاق الخلايا ليتناسب مع حجم إطار OLE المطلوب، يمكنك منع تغيير الحجم غير المرغوب فيه.

**أي طريقة تعديل أحجم يجب أن أستخدم، تعديل إطار OLE أم تعديل نطاق الخلايا؟**

اختر **تعديل إطار OLE** إذا أردت الحفاظ على أحجام الصفوف والأعمدة الأصلية في Excel. اختر **تعديل نطاق الخلايا** إذا رغبت في الحصول على حجم ثابت لإطار OLE في العرض.

**هل ستعمل هذه الحلول إذا كان العرض مبنيًا على قالب؟**

نعم. كلا الحلين يعملان للعروض التي تم إنشاؤها من قوالب أو من الصفر.

**هل هناك حد لحجم إطار OLE عند استخدام هذه الطرق؟**

لا. يمكنك جعل إطار كائن OLE بأي حجم طالما ضبطت المقياس بشكل مناسب.

**هل هناك طريقة لتجنب نص العنصر النائب "EMBEDDED OLE OBJECT" في PowerPoint؟**

نعم. من خلال التقاط صورة للنطاق المستهدف في Excel وتعيينها كصورة بديلة لإطار OLE، يمكنك عرض صورة معاينة مخصصة بدلاً من النص العنصر النائب الافتراضي.

## **مقالات ذات صلة**

[إنشاء مخطط Excel وتضمينه في عرض تقديمي ككائن OLE](/slides/ar/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[تحديث كائنات OLE تلقائيًا باستخدام إضافة MS PowerPoint](/slides/ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)