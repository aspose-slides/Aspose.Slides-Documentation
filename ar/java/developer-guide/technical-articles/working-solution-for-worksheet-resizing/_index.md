---
title: حل عملي لإعادة تحجيم ورقة العمل
type: docs
weight: 20
url: /ar/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة معاينة
- تحجيم الصورة
- Excel
- ورقة العمل
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إصلاح مشكلة تغيير حجم كائن OLE لورقة عمل Excel في العروض التقديمية: طريقتان للحفاظ على إطارات الكائن موحدة—تحجيم الإطار أو الورقة—عبر صيغ PPT و PPTX."
---
{{% alert color="info" %}}
تم ملاحظة أن أوراق عمل Excel المضمنة ككائنات OLE في عرض PowerPoint من خلال مكونات Aspose يتم تغيير حجمها إلى مقياس غير محدد بعد التفعيل الأول. يخلق هذا السلوك فرقًا بصريًا ملحوظًا في العرض بين حالتي ما قبل وما بعد تفعيل كائن OLE. لقد قمنا بالتحقق من هذه المشكلة بالتفصيل وتوفير حل، والذي تم تغطيته في هذه المقالة.
{{% /alert %}}

## **الخلفية**

في المقالة [إدارة OLE](/slides/ar/java/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض PowerPoint باستخدام Aspose.Slides for Java. لمعالجة [مشكلة معاينة الكائن](/slides/ar/java/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة لمنطقة ورقة العمل المحددة إلى إطار كائن OLE. في العرض الناتج، عند النقر المزدوج على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تنشيط مصنف Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة على مصنف Excel الفعلي ثم العودة إلى الشريحة بالنقر خارج مصنف Excel المنشط. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. سيختلف عامل تغيير الحجم بناءً على حجم إطار كائن OLE ومصنف Excel المضمن.

## **سبب تغيير الحجم**

نظرًا لأن مصنف Excel له حجم نافذته الخاص، فإنه يحاول الحفاظ على حجمه الأصلي عند التفعيل الأول. من ناحية أخرى، يمتلك إطار كائن OLE حجمه الخاص. وفقًا لمايكروسوفت، عندما يتم تنشيط مصنف Excel، يتفاوض Excel وPowerPoint على الحجم لضمان الحفاظ على النسب الصحيحة كجزء من عملية التضمين. يحدث تغيير الحجم بناءً على الفروق بين حجم نافذة Excel وحجم وموقع إطار كائن OLE.

## **الحل العملي**

هناك حلّان محتملان لتجنب تأثير تغيير الحجم.

- تحجيم حجم إطار OLE في عرض PowerPoint ليتطابق مع ارتفاع وعرض عدد الصفوف والأعمدة المطلوب في إطار OLE.
- الحفاظ على حجم إطار OLE ثابتًا وتحجيم حجم الصفوف والأعمدة المشاركة ليتناسب مع حجم إطار OLE المحدد.

### **تحجيم حجم إطار OLE**

في هذا النهج، سنتعلم كيفية ضبط حجم إطار OLE لمصنف Excel المضمن ليتطابق مع الحجم التراكمي للصفوف والأعمدة المشاركة في ورقة عمل Excel.

لنفترض أن لدينا ورقة Excel قالب ونريد إضافتها إلى عرض تقديمي كإطار OLE. في هذا السيناريو، سيتم حساب حجم إطار كائن OLE أولاً بناءً على ارتفاعات الصفوف التراكمية وعرض الأعمدة التراكمية للصفوف والأعمدة المشاركة في المصنف. ثم سنضبط حجم إطار OLE إلى هذه القيمة المحسوبة. لتجنب ظهور رسالة الأحمر "EMBEDDED OLE OBJECT" لإطار OLE في PowerPoint، سنلتقط أيضًا صورة للأجزاء المطلوبة من الصفوف والأعمدة في المصنف ونعيّنها كصورة لإطار OLE.

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

// تعيين الحجم المعروض عندما يتم استخدام ملف المصنف ككائن OLE في PowerPoint.
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

### **تحجيم حجم نطاق الخلايا**

في هذا النهج، سنتعلم كيفية تحجيم ارتفاعات الصفوف المشاركة وعرض الأعمدة المشاركة لتتناسب مع حجم إطار OLE مخصص.

لنفترض أن لدينا ورقة Excel قالب ونريد إضافتها إلى عرض تقديمي كإطار OLE. في هذا السيناريو، سنضبط حجم إطار OLE ونحجم حجم الصفوف والأعمدة التي تشارك في منطقة إطار OLE. ثم سنحفظ المصنف إلى تدفق لتطبيق التغييرات ونحولها إلى مصفوفة بايت لإضافتها إلى إطار OLE. لتجنب ظهور رسالة الأحمر "EMBEDDED OLE OBJECT" لإطار OLE في PowerPoint، سنلتقط أيضًا صورة للأجزاء المطلوبة من الصفوف والأعمدة في المصنف ونعيّنها كصورة لإطار OLE.

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
هناك نهجان لحل مشكلة تغيير حجم ورقة العمل. يعتمد اختيار النهج المناسب على المتطلبات المحددة وحالة الاستخدام. كلا النهجين يعملان بنفس الطريقة، سواء تم إنشاء العروض من قالب أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.
{{% /alert %}}

## **الأسئلة الشائعة**

### لماذا يتغير حجم ورقة عمل Excel المضمنة عند التفعيل الأول في PowerPoint؟
يحدث ذلك لأن Excel يحاول الحفاظ على حجم النافذة الأصلي عند التفعيل، بينما يمتلك إطار كائن OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يسبب تغيير الحجم.

### هل يمكن منع مشكلة تغيير الحجم تمامًا؟
نعم. من خلال تحجيم إطار OLE ليتناسب مع حجم نطاق خلايا Excel أو تحجيم نطاق الخلايا ليتناسب مع حجم إطار OLE المطلوب، يمكنك منع تغيير الحجم غير المرغوب فيه.

### أي طريقة تحجيم يجب أن أستخدمها، تحجيم إطار OLE أم تحجيم نطاق الخلايا؟
اختر **تحجيم إطار OLE** إذا كنت ترغب في الحفاظ على أحجام الصفوف والأعمدة الأصلية في Excel. اختر **تحجيم نطاق الخلايا** إذا كنت تريد حجمًا ثابتًا لإطار OLE في العرض الخاص بك.

### هل ستعمل هذه الحلول إذا كان عرضي التقديمي مبنيًا على قالب؟
نعم. كلا الحلين يعملان للعروض المقدمة التي تم إنشاؤها من القوالب أو من الصفر.

### هل هناك حد لحجم إطار OLE عند استخدام هذه الطرق؟
لا. يمكنك جعل إطار كائن OLE بأي حجم طالما قمت بضبط التحجيم بشكل مناسب.

### هل هناك طريقة لتجنب نص العنصر النائب "EMBEDDED OLE OBJECT" في PowerPoint؟
نعم. من خلال التقاط صورة لنطاق خلايا Excel المستهدف وتعيينها كصورة عنصر نائب لإطار OLE، يمكنك عرض صورة معاينة مخصصة بدلاً من العنصر النائب الافتراضي.

## **مقالات ذات صلة**

[إنشاء مخطط Excel وتضمينه في عرض تقديمي ككائن OLE](/slides/ar/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[تحديث كائنات OLE تلقائيًا باستخدام إضافة MS PowerPoint](/slides/ar/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)