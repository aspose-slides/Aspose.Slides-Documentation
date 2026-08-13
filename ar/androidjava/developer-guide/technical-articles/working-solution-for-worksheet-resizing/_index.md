---
title: حل عملي لمشكلة تغيير حجم ورقة العمل
type: docs
weight: 20
url: /ar/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة المعاينة
- تغيير حجم الصورة
- Excel
- ورقة عمل
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إصلاح تغيير حجم OLE لورقة عمل Excel في العروض التقديمية: طريقتان للحفاظ على اتساق إطارات الكائن— إما تعديل حجم الإطار أو تعديل حجم الورقة— عبر صيغ PPT و PPTX."
---
{{% alert color="info" %}}

تم ملاحظة أن أوراق عمل Excel المدمجة ككائنات OLE في عرض PowerPoint عبر مكونات Aspose يتم تغيير حجمها إلى مقياس غير معروف بعد التفعيل الأول. يخلق هذا السلوك فرقًا بصريًا ملحوظًا في العرض بين حالات الكائن OLE قبل وبعد التفعيل. لقد حققنا في هذه المشكلة بالتفصيل وقدمنا حلاً مغطى في هذه المقالة.

{{% /alert %}}

## **الخلفية**

في المقالة [Manage OLE](/slides/ar/androidjava/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض PowerPoint باستخدام Aspose.Slides لـ Android عبر Java. لمعالجة [object preview issue](/slides/ar/androidjava/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة لمنطقة ورقة العمل المحددة إلى إطار كائن OLE. في العرض الناتج، عند النقر المزدوج على إطار OLE الذي يعرض صورة ورقة العمل، يتم تنشيط مصنف Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة على مصنف Excel الفعلي ثم العودة إلى الشريحة بالنقر خارج مصنف Excel النشط. سيتغير حجم إطار OLE عندما يعود المستخدم إلى الشريحة. سيتفاوت عامل إعادة التغيير بناءً على حجم إطار OLE ومصنف Excel المدمج.

## **سبب تغيير الحجم**

نظرًا لأن مصنف Excel له حجم نافذة خاص به، فإنه يحاول الاحتفاظ بحجمه الأصلي عند التفعيل الأول. من ناحية أخرى، يمتلك إطار كائن OLE حجمه الخاص. وفقًا لمايكروسوفت، عندما يتم تنشيط مصنف Excel، يتفاوض Excel وPowerPoint على الحجم لضمان الحفاظ على النسب الصحيحة كجزء من عملية الإدماج. يحدث تغيير الحجم بناءً على الفروق بين حجم نافذة Excel وحجم وموضع إطار كائن OLE.

## **الحل العملي**

هناك حلان محتملان لتجنب تأثير تغيير الحجم.

- ضبط حجم إطار OLE في عرض PowerPoint ليتطابق مع ارتفاع وعرض عدد الصفوف والأعمدة المطلوب في إطار OLE.
- الحفاظ على حجم إطار OLE ثابتًا وتغيير حجم الصفوف والأعمدة المشاركة ليتناسب مع حجم إطار OLE المختار.

### **تغيير حجم إطار OLE**

في هذا النهج، سوف نتعلم كيفية تعيين حجم إطار OLE للمصنف المدمج ليتطابق مع الحجم التجميعي للصفوف والأعمدة المشاركة في ورقة عمل Excel.

لنفترض أن لدينا ورقة Excel نموذجية ونريد إضافتها إلى عرض كإطار OLE. في هذا السيناريو، سيتم حساب حجم إطار كائن OLE أولاً بناءً على ارتفاعات الصفوف التجميعية وعروض الأعمدة التجميعية للصفوف والأعمدة المشاركة في المصنف. ثم سنقوم بتعيين حجم إطار OLE إلى هذه القيمة المحسوبة. لتجنب رسالة "EMBEDDED OLE OBJECT" الحمراء لإطار OLE في PowerPoint، سنلتقط أيضًا صورة للأجزاء المطلوبة من الصفوف والأعمدة في المصنف ونستخدمها كصورة لإطار OLE.

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

// الحصول على العرض والارتفاع لصورة OLE بالنقاط.
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

### **تغيير حجم نطاق الخلايا**

في هذا النهج، سنتعلم كيفية تعديل ارتفاعات الصفوف المشاركة وعرض الأعمدة المشاركة لتتطابق مع حجم إطار OLE مخصص.

لنفترض أن لدينا ورقة Excel نموذجية ونريد إضافتها إلى عرض كإطار OLE. في هذا السيناريو، سنقوم بتعيين حجم إطار OLE وتعديل حجم الصفوف والأعمدة التي تشارك في منطقة إطار OLE. ثم سنحفظ المصنف إلى تدفق لتطبيق التغييرات ونحوّله إلى مصفوفة بايت لإضافته إلى إطار OLE. لتجنب رسالة "EMBEDDED OLE OBJECT" الحمراء لإطار OLE في PowerPoint، سنلتقط أيضًا صورة للأجزاء المطلوبة من الصفوف والأعمدة في المصنف ونستخدمها كصورة لإطار OLE.

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

// تقييس نطاق الخلايا ليتناسب مع حجم الإطار.
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

{{% alert color="info" %}} 

هناك نهجان لإصلاح مشكلة تغيير حجم ورقة العمل. يعتمد اختيار النهج المناسب على المتطلبات المحددة وحالة الاستخدام. يعمل النهجان بنفس الطريقة، سواء تم إنشاء العروض من قالب أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.

{{% /alert %}}

## **الأسئلة المتكررة**

### لماذا يتغير حجم ورقة عمل Excel المدمجة عند تفعيلها لأول مرة في PowerPoint؟

يحدث ذلك لأن Excel يحاول الحفاظ على حجم النافذة الأصلي عند تفعيلها، بينما يمتلك إطار كائن OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يتسبب في تغيير الحجم.

### هل من الممكن منع هذه المشكلة بالكامل؟

نعم. من خلال تعديل حجم إطار OLE ليتناسب مع حجم نطاق خلايا Excel أو تعديل نطاق الخلايا ليتناسب مع حجم إطار OLE المطلوب، يمكنك منع تغيير الحجم غير المرغوب فيه.

### أي طريقة تعديل يجب أن أستخدمها، تعديل إطار OLE أم تعديل نطاق الخلايا؟

اختر **OLE frame scaling** إذا كنت تريد الحفاظ على أحجام الصفوف والأعمدة الأصلية في Excel. اختر **cell range scaling** إذا كنت تريد حجمًا ثابتًا لإطار OLE في عرضك.

### هل ستعمل هذه الحلول إذا كان عرضي مبنيًا على قالب؟

نعم. كلا الحلين يعملان للعروض التي تم إنشاؤها من القوالب أو من الصفر.

### هل هناك حد لحجم إطار OLE عند استخدام هذه الطرق؟

لا. يمكنك جعل إطار كائن OLE بأي حجم ما دمت تحدد المقياس بشكل مناسب.

### هل هناك طريقة لتجنب نص العنصر النائب "EMBEDDED OLE OBJECT" في PowerPoint؟

نعم. من خلال التقاط لقطة لنطاق خلايا Excel المستهدف وتعيينها كصورة نائبة لإطار OLE، يمكنك عرض صورة معاينة مخصصة بدلاً من العنصر النائب الافتراضي.