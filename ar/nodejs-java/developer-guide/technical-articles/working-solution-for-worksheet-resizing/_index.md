---
title: حل عملي لإعادة تحجيم ورقة العمل
type: docs
weight: 20
url: /ar/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة معاينة
- إعادة تحجيم الصورة
- Excel
- ورقة عمل
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إصلاح مشكلة إعادة تحجيم OLE لورقة عمل Excel في العروض التقديمية: طريقتان للحفاظ على ثبات إطارات الكائن—إما تحجيم الإطار أو الورقة—عبر صيغ PPT و PPTX."
---
{{% alert color="info" title="Note" %}}
قد يتم تغيير حجم أوراق عمل Excel المدمجة ككائنات OLE في عرض تقديمي لبرنامج PowerPoint باستخدام مكونات Aspose بشكل غير متوقع بعد تفعيلها الأول. يُنشئ هذا السلوك فرقًا بصريًا واضحًا بين كائن OLE قبل وبعد التفعيل. يشرح هذا المقال المشكلة ويصف طريقتين لمعالجتها.
{{% /alert %}}

## **الخلفية**

في المقالة [Manage OLE](/slides/ar/nodejs-java/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض تقديمي لبرنامج PowerPoint باستخدام Aspose.Slides لـ Node.js عبر Java. لمعالجة [object preview issue](/slides/ar/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة للمنطقة المحددة من ورقة العمل إلى إطار كائن OLE. في العرض التقديمي الناتج، عند النقر المزدوج على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تفعيل مصنف Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة على مصنف Excel الفعلي ثم العودة إلى الشريحة بالنقر خارج المصنف المفعل. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. سيتفاوت عامل إعادة التحجيم اعتمادًا على حجم إطار كائن OLE ومصنف Excel المدمج.

## **سبب إعادة التحجيم**

نظرًا لأن مصنف Excel له حجم نافذة خاص به، فإنه يحاول الحفاظ على حجمه الأصلي عند التفعيل الأول. من ناحية أخرى، يمتلك إطار كائن OLE حجمه الخاص. وفقًا لـ Microsoft، عندما يتم تفعيل مصنف Excel، يتفاوض Excel وPowerPoint على الحجم لضمان الحفاظ على النسب الصحيحة كجزء من عملية الدمج. يحدث إعادة التحجيم بناءً على الفروقات بين حجم نافذة Excel وحجم وموقع إطار كائن OLE.

## **الحل العملي**

هناك حلّان محتملان لتجنب تأثير إعادة التحجيم.

- تحجيم إطار OLE في عرض PowerPoint ليتطابق مع الارتفاع والعرض الكلي للصفوف والأعمدة المحددة.
- الحفاظ على حجم إطار OLE ثابت وتحجيم الصفوف والأعمدة المحددة لتناسب الإطار.

### **تحجيم حجم إطار OLE**

تقوم هذه الطريقة بتعيين حجم إطار OLE ليتطابق مع الارتفاع والعرض الكلي للصفوف والأعمدة المحددة في ورقة عمل Excel المدمجة.

يقوم المثال بتحميل مصنف Excel موجود واختيار الصفوف العشرة الأولى و13 عمودًا من ورقته الأولى باستخدام فهارس تبدأ من الصفر. يحدد [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) النطاق المعروض. يتم إنشاء المعاينة بدقة 96 DPI، وتُحوَّل أبعادها بالبيكسل إلى نقاط باستخدام 72 نقطة لكل بوصة. تقوم [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) بدمج المصنف المعدل في إطار بهذه الأبعاد. تُعيَّن المعاينة من خلال [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) لاستبدال عنصر نائب "EMBEDDED OLE OBJECT" في العرض التقديمي المحفوظ.

قم بتثبيت الحزم `aspose.cells`، `aspose.slides.via.java`، و `java` وضع الملف `sample.xlsx` في دليل العمل. لكل نهج، شغّل أولاً برنامج الإعداد، ثم برنامج الإدراج في عملية Node.js منفصلة في نفس الدليل. تقوم الحزمتان من Aspose بتهيئة جسر Java بشكل منفصل.

احفظ برنامج الإعداد هذا باسم `prepare-frame-scaled.js` وشغّله باستخدام `node prepare-frame-scaled.js`. سيكتب الملفين `frame-scaled.xlsx` و `frame-scaled.png`.

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// كل العمل المتزامن اكتمل؛ أوقف عملية جسر Java.
process.exit(0);
```

احفظ برنامج الإدراج هذا باسم `embed-frame-scaled.js` وشغّله باستخدام `node embed-frame-scaled.js`. سيقرأ تلك الملفات ويكتب `frame-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// كل العمل المتزامن اكتمل؛ أوقف عملية جسر Java.
process.exit(0);
```

يقوم المساعد الخاص بالمعاينة بتعيين [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) إلى النطاق المحدد وإزالة الهوامش والرؤوس والتذييلات. مع تمكين [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea)، تقوم [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) بإنشاء النطاق كصورة PNG. يحفظ المساعد صورة PNG إلى ملف لاستخدامها في العرض التقديمي.

### **تحجيم حجم نطاق الخلايا**

تقوم هذه الطريقة بتحجيم ارتفاعات الصفوف المحددة وعرض الأعمدة المحددة لتتناسب مع حجم إطار OLE مخصص.

يقوم المثال بتحميل مصنف Excel موجود واختيار الصفوف العشرة الأولى و13 عمودًا من ورقته الأولى باستخدام فهارس تبدأ من الصفر. يحدد [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) النطاق المعروض، ويقوم المساعد بتحجيم ذلك النطاق ليتناسب مع إطار بعرض 400 نقطة وارتفاع 100 نقطة. بعد حفظ المصنف المعدل إلى ملف، تقوم [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) بدمجه بالحجم المحدد. تُعيَّن معاينة تم إنشاؤها بدقة 96 DPI عبر [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) بحيث يعرض العرض التقديمي المحفوظ الخلايا المحددة بدلاً من العنصر النائب الافتراضي.

احفظ برنامج الإعداد هذا باسم `prepare-cells-scaled.js` وشغّله باستخدام `node prepare-cells-scaled.js`. سيكتب الملفين `cells-scaled.xlsx` و `cells-scaled.png`.

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// كل العمل المتزامن اكتمل؛ أوقف عملية جسر Java.
process.exit(cellsPrepared ? 0 : 1);
```

احفظ برنامج الإدراج هذا باسم `embed-cells-scaled.js` وشغّله باستخدام `node embed-cells-scaled.js`. سيقرأ تلك الملفات ويكتب `cells-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// كل العمل المتزامن اكتمل؛ أوقف عملية جسر Java.
process.exit(0);
```

يقوم المساعد المتعلق بالتحجيم بحساب نسب العرض والارتفاع المنفصلة للنطاق المحدد، مع الحفاظ على نسب عرض الأعمدة وارتفاع الصفوف النسبية. يحول الأبعاد المحسوبة من نقاط إلى إنشات قبل تطبيقها باستخدام [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) و[Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch). يجب أن يمتلك النطاق المحدد عرضًا وارتفاعًا غير صفرين.

يقوم هذا المساعد للمعاينة بإنشاء النطاق المعاد تحجيمه باستخدام [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). يحدّ [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) إلى ذلك النطاق، يزيل الهوامش والرؤوس والتذييلات، ويحفظ صورة PNG إلى ملف.

## **الخلاصة**
{{% alert color="info" title="Note" %}}
هناك طريقتان لحل مشكلة تغيير حجم ورقة العمل. اختر النهج الذي يتناسب بشكل أفضل مع متطلباتك وحالتك العملية. كلا النهجين يعملان بنفس الطريقة، سواء تم إنشاء العروض من قالب أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.
{{% /alert %}}

## **الأسئلة المتكررة**

**لماذا يتغير حجم ورقة عمل Excel المدمجة عند تفعيلها لأول مرة في PowerPoint؟**  
يحدث ذلك لأن Excel يحاول الحفاظ على حجم النافذة الأصلي عند التفعيل، بينما يمتلك إطار كائن OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يتسبب في إعادة التحجيم.

**هل من الممكن منع مشكلة إعادة التحجيم هذه تمامًا؟**  
نعم. عن طريق تحجيم إطار OLE ليتناسب مع حجم نطاق خلايا Excel أو تحجيم نطاق الخلايا ليتناسب مع حجم إطار OLE المطلوب، يمكنك منع إعادة التحجيم غير المرغوبة.

**أي طريقة تحجيم يجب أن أستخدمها، تحجيم إطار OLE أم تحجيم نطاق الخلايا؟**  
اختر **تحجيم إطار OLE** إذا كنت تريد الحفاظ على أحجام الصفوف والأعمدة الأصلية في Excel. اختر **تحجيم نطاق الخلايا** إذا كنت تريد حجمًا ثابتًا لإطار OLE في عرضك التقديمي.

**هل ستعمل هذه الحلول إذا كان عرضي التقديمي مبنيًا على قالب؟**  
نعم. كلا الحلين يعملان على العروض التقديمية التي تم إنشاؤها من قوالب أو من الصفر.

**هل هناك حد لحجم إطار OLE عند استخدام هذه الطرق؟**  
لا. يمكنك جعل إطار كائن OLE بأي حجم طالما قمت بضبط التحجيم بشكل مناسب.

**هل هناك طريقة لتجنب نص العنصر النائب "EMBEDDED OLE OBJECT" في PowerPoint؟**  
نعم. عن طريق أخذ لقطة لنطاق خلايا Excel المستهدف وتعيينها كصورة عنصر نائب لإطار OLE، يمكنك عرض صورة معاينة مخصصة بدلاً من العنصر النائب الافتراضي.

## **مقالات ذات صلة**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/ar/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)