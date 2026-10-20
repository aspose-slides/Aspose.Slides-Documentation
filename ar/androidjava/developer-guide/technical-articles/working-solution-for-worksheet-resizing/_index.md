---
title: حل عملي لتغيير حجم ورقة العمل
type: docs
weight: 20
url: /ar/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة معاينة
- تغيير حجم الصورة
- Excel
- ورقة عمل
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إصلاح تغيير حجم OLE لورقة عمل Excel في العروض التقديمية: طريقتان للحفاظ على إطارات الكائن متسقة — إما قياس الإطار أو قياس الورقة — عبر صيغ PPT و PPTX."
---
{{% alert color="info" title="Note" %}}

قد يتم تغيير حجم أوراق عمل Excel المدمجة ككائنات OLE في عرض PowerPoint باستخدام مكونات Aspose بشكل غير متوقع بعد التنشيط الأول لها. يخلق هذا السلوك فرقًا بصريًا ملحوظًا بين كائن OLE قبل وبعد التنشيط. يشرح هذا المقال المشكلة ويصف طريقتين لمعالجتها.

{{% /alert %}}

## **الخلفية**

في المقالة [إدارة OLE](/slides/ar/androidjava/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض PowerPoint باستخدام Aspose.Slides لنظام Android عبر Java. لمعالجة [مشكلة معاينة الكائن](/slides/ar/androidjava/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة للمنطقة المحددة من ورقة العمل إلى إطار كائن OLE. في العرض الناتج، عند النقر المزدوج على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تنشيط مصنف Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة على المصنف الفعلي ثم العودة إلى الشريحة بالنقر خارج المصنف النشط. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. سيختلف عامل تغيير الحجم وفقًا لحجم إطار كائن OLE ومصنف Excel المدمج.

## **سبب تغيير الحجم**

نظرًا لأن مصنف Excel له حجم نافذة خاص به، فإنه يحاول الحفاظ على حجمه الأصلي عند التنشيط الأول. من ناحية أخرى، يمتلك إطار كائن OLE حجمه الخاص. وفقًا لمايكروسوفت، عندما يتم تنشيط مصنف Excel، يتفاوض Excel وPowerPoint على الحجم لضمان الحفاظ على النسب الصحيحة كجزء من عملية الدمج. يحدث تغيير الحجم بناءً على الاختلافات بين حجم نافذة Excel وحجم وإطار كائن OLE وموقعه.

## **الحل العملي**

هناك حلان ممكنان لتجنب تأثير تغيير الحجم.

- قياس إطار OLE في عرض PowerPoint ليتطابق مع إجمالي الارتفاع والعرض للصفوف والأعمدة المحددة.
- الحفاظ على حجم إطار OLE ثابتًا وتعديل قياس الصفوف والأعمدة المحددة لتناسبه.

### **قياس حجم إطار OLE**

تحدد هذه الطريقة حجم إطار OLE لتتطابق مع إجمالي الارتفاع والعرض للصفوف والأعمدة المحددة في ورقة Excel المدمجة.

المثال يحمل مصنف Excel موجود ويختار أول 10 صفوف و13 عمودًا من ورقته الأولى باستخدام فهارس صفرية. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) يحدد النطاق المعروض. يتم عرض المعاينة بدقة 96 DPI، وتُحوَّل أبعاد البكسل إلى نقاط باستخدام 72 نقطة لكل بوصة. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) يدمج المصنف المعدّل في إطار بهذه الأبعاد. تُعيَّن المعاينة عبر [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) لاستبدال العنصر النائب "EMBEDDED OLE OBJECT" في العرض المحفوظ.

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

// تعيين الحجم المعروض عندما يتم استخدام ملف المصنف ككائن OLE في PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

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

يضبط مساعد المعاينة [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) إلى النطاق المحدد ويزيل الهوامش والرؤوس والتذييلات. مع تمكين [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-)، يُولِّد [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) النطاق كصورة PNG. يُعيد المساعد تدفق إدخال جديد يحتوي على صورة PNG، موضعًا في بدايته للاستخدام في العرض.

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

### **قياس حجم نطاق الخلايا**

تقوم هذه الطريقة بتعديل ارتفاع الصفوف المختارة وعرض الأعمدة المختارة لتتطابق مع إطار OLE مخصص.

المثال يحمل مصنف Excel موجود ويختار أول 10 صفوف و13 عمودًا من ورقته الأولى باستخدام فهارس صفرية. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) يحدد النطاق المعروض، ويقوم المساعد أدناه بتعديل ذلك النطاق ليناسب إطار بعرض 400 نقطة وارتفاع 100 نقطة. بعد حفظ المصنف المعدل إلى تدفق، يدمج [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-)ه في الحجم المحدد. تُعيَّن معاينة تم عرضها بدقة 96 DPI عبر [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--)، لذا يعرض العرض المحفوظ الخلايا المختارة بدلاً من العنصر النائب الافتراضي.

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

// تعيين الحجم المعروض عندما يتم استخدام ملف المصنف ككائن OLE في PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// قياس نطاق الخلايا ليتناسب مع حجم الإطار.
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

يحسب مساعد القياس نسب العرض والارتفاع المنفصلة للنطاق المختار، مع الحفاظ على نسب عرض أعمدته ونسب ارتفاع صفوفه. يحول الأبعاد المحسوبة من نقاط إلى بوصات قبل تطبيقها باستخدام [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) و[Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). يجب أن يكون للنطاق المختار عرض وارتفاع غير صفريين.

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

يُظهر هذا المساعد المعاينة للنطاق المُعاد حجمه باستخدام [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). يقتصر [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) على ذلك النطاق، ويزيل الهوامش والرؤوس والتذييلات، ويُعيد تدفق PNG موضعًا في بدايته.

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

## **الخلاصة**

{{% alert color="info" title="Note" %}}

هناك طريقتان لإصلاح مشكلة تغيير حجم ورقة العمل. اختر الطريقة التي تناسب متطلباتك وحالة الاستخدام الخاصة بك. تعمل الطريقتان بنفس الطريقة، سواء تم إنشاء العروض من قالب أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.

{{% /alert %}}

## **الأسئلة الشائعة**

**لماذا يتغير حجم ورقة Excel المدمجة عندما يتم تنشيطها للمرة الأولى في PowerPoint؟**

يحدث ذلك لأن Excel يحاول الحفاظ على حجم نافذته الأصلي عند التنشيط، بينما يمتلك إطار كائن OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة الأبعاد، مما قد يتسبب في تغيير الحجم.

**هل يمكن منع مشكلة تغيير الحجم هذه تمامًا؟**

نعم. من خلال قياس إطار OLE ليتناسب مع حجم نطاق خلايا Excel أو قياس نطاق الخلايا ليتناسب مع حجم إطار OLE المطلوب، يمكنك منع تغيير الحجم غير المرغوب فيه.

**أي طريقة قياس يجب أن أستخدمها، قياس إطار OLE أم قياس نطاق الخلايا؟**

اختر **قياس إطار OLE** إذا كنت تريد الحفاظ على أحجام الصفوف والأعمدة الأصلية في Excel. اختر **قياس نطاق الخلايا** إذا كنت تريد حجمًا ثابتًا لإطار OLE في عرضك.

**هل ستعمل هذه الحلول إذا كان عرضي مبنيًا على قالب؟**

نعم. كلا الحلين يعملان للعروض التي تم إنشاؤها من القوالب أو من الصفر.

**هل هناك حد لحجم إطار OLE عند استخدام هذه الطرق؟**

لا. يمكنك جعل إطار كائن OLE بأي حجم طالما قمت بضبط القياس بشكل مناسب.

**هل هناك طريقة لتجنب نص العنصر النائب "EMBEDDED OLE OBJECT" في PowerPoint؟**

نعم. من خلال التقاط صورة للنطاق المستهدف في Excel وتعيينها كصورة العنصر النائب لإطار OLE، يمكنك عرض صورة معاينة مخصصة بدلاً من العنصر النائب الافتراضي.

## **المقالات ذات الصلة**

[إنشاء مخطط Excel وتضمينه في عرض تقديمي ككائن OLE](/slides/ar/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[تحديث كائنات OLE تلقائيًا باستخدام إضافة MS PowerPoint](/slides/ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)