---
title: حل عملي لتغيير حجم ورقة العمل
type: docs
weight: 20
url: /ar/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة معاينة
- تغيير حجم الصورة
- Excel
- ورقة عمل
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إصلاح تغيير حجم OLE لورقة عمل Excel في العروض: طريقتان للحفاظ على تناسق إطارات الكائن—تحجيم الإطار أو الورقة—عبر صيغ PPT و PPTX."
---
{{% alert color="info" title="Note" %}}

قد يتم تغيير حجم أوراق Excel المدمجة ككائنات OLE في عرض تقديمي PowerPoint باستخدام مكونات Aspose بشكل غير متوقع بعد التفعيل الأول لها. يخلق هذا السلوك فرقًا بصريًا ملحوظًا بين كائن OLE قبل وبعد التفعيل. يوضح هذا المقال المشكلة ويصف طريقتين لمعالجتها.

{{% /alert %}}

## **الخلفية**

في المقالة [إدارة OLE](/slides/ar/php-java/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض PowerPoint باستخدام Aspose.Slides للـ PHP عبر Java. لمعالجة [مشكلة معاينة الكائن](/slides/ar/php-java/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة لمنطقة ورقة العمل المحددة إلى إطار كائن OLE. في العرض الناتج، عند النقر مزدوجًا على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تنشيط مصنف Excel. يمكن للمستخدمين إجراء أي تغييرات يرغبون بها على المصنف الفعلي ثم العودة إلى الشريحة بالنقر خارج المصنف النشط. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. سيتفاوت عامل تغيير الحجم اعتمادًا على حجم إطار كائن OLE ومصنف Excel المدمج.

## **سبب تغيير الحجم**

نظرًا لأن مصنف Excel له حجم نافذة خاص به، فإنه يحاول الحفاظ على حجمه الأصلي عند التفعيل الأول. من ناحية أخرى، يمتلك إطار كائن OLE حجمه الخاص. وفقًا لمايكروسوفت، عندما يتم تفعيل مصنف Excel، يتفاوض Excel وPowerPoint على الحجم لضمان الحفاظ على النسب الصحيحة كجزء من عملية الدمج. يحدث تغيير الحجم استنادًا إلى الفروقات بين حجم نافذة Excel وحجم وموقع إطار كائن OLE.

## **الحل العملي**

هناك حلان محتملان لتجنب تأثير تغيير الحجم.

- قم بتحجيم إطار OLE في عرض PowerPoint لمطابقة الارتفاع والعرض الكليين للصفوف والأعمدة المحددة.
- احتفظ بحجم إطار OLE ثابتًا وقم بتحجيم الصفوف والأعمدة المحددة لتناسب الإطار.

### **تحجيم حجم إطار OLE**

يتبع هذا الأسلوب ضبط حجم إطار OLE ليتطابق مع الارتفاع والعرض الكليين للصفوف والأعمدة المحددة في ورقة Excel المدمجة.

يحمِّل المثال مصنف Excel موجود ويختار أول 10 صفوف و13 عمودًا من ورقته الأولى باستخدام فهارس تبدأ من الصفر. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) يحدد النطاق المعروض. يتم إنشاء المعاينة بدقة 96 DPI، وتُحول أبعاد البكسل إلى نقاط باستخدام 72 نقطة لكل بوصة. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) يدمج المصنف المعدل في إطار بهذه الأبعاد. تُعيّن المعاينة عبر [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) لاستبدال العنصر النائب "EMBEDDED OLE OBJECT" في العرض المحفوظ.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // إدراج المصنف المعدل والاحتفاظ بالبيانات الثنائية في مصفوفات البايت الخاصة بجافا.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

يضبط مساعد المعاينة [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) على النطاق المحدد ويزيل الهوامش والرؤوس والتذييلات. مع تمكين [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea)، تقوم [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) بتصدير النطاق كصورة PNG. يُعيد المساعد تدفق إدخال جديد يحتوي على صورة PNG، موضعها في البداية لاستخدامها في العرض.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **تحجيم نطاق الخلايا**

يتبع هذا الأسلوب تحجيم ارتفاعات الصفوف المحددة وعرض الأعمدة المحددة ليتطابق مع حجم إطار OLE مخصص.

يحمِّل المثال مصنف Excel موجود ويختار أول 10 صفوف و13 عمودًا من ورقته الأولى باستخدام فهارس تبدأ من الصفر. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) يحدد النطاق المعروض، ويساعد المساعد أدناه على تحجيم ذلك النطاق ليتناسب مع إطار عرضه 400 نقطة وارتفاعه 100 نقطة. بعد حفظ المصنف المعدل إلى تدفق، يدمج [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) المصنف بالحجم المحدد. تُعيّن معاينة بدقة 96 DPI عبر [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)، بحيث يعرض العرض المحفوظ الخلايا المحددة بدلاً من العنصر النائب الافتراضي.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // إدراج المصنف المعدل والاحتفاظ بالبيانات الثنائية في مصفوفات البايت الخاصة بجافا.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

يحسب مساعد التحجيم نسب العرض والارتفاع المنفصلة للنطاق المحدد، مع الحفاظ على عرض الأعمدة النسبية وارتفاع الصفوف النسبية. يحول الأبعاد المحسوبة من نقاط إلى بوصات قبل تطبيقها باستخدام [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) و[Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch). يجب أن يكون للنطاق المحدد عرض وارتفاع غير صفرين.

```php
use aspose\cells\CellsUnitType;

// العرض والارتفاع هما الأبعاد المتوقعة لنطاق الخلايا بالنقاط.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

يُنشئ هذا المساعد معاينة للنطاق المعاد تحجيمه باستخدام [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage). يحدّ [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) إلى ذلك النطاق، ويزيل الهوامش والرؤوس والتذييلات، ويُعيد تدفق PNG موضعه في البداية.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **الخلاصة**

{{% alert color="info" title="Note" %}}

هناك نهجان لإصلاح مشكلة تغيير حجم ورقة العمل. اختر النهج الذي يناسب متطلباتك وحالة الاستخدام. كلا النهجين يعملان بنفس الطريقة، سواء تم إنشاء العروض التقديمية من قالب أو من الصفر. بالإضافة إلى ذلك، لا توجد حدود لحجم إطار OLE في هذا الحل.

{{% /alert %}}

## **الأسئلة المتكررة**

**لماذا يتغير حجم ورقة Excel المدمجة عندما يتم تفعيلها لأول مرة في PowerPoint؟**

يحدث ذلك لأن Excel يحاول الحفاظ على حجم نافذته الأصلي عند التفعيل، بينما يمتلك إطار OLE في PowerPoint أبعادًا خاصة به. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة الأبعاد، ما قد يؤدي إلى تغيير الحجم.

**هل من الممكن منع هذه المشكلة تمامًا؟**

نعم. من خلال تحجيم إطار OLE ليتناسب مع حجم نطاق خلايا Excel أو تحجيم نطاق الخلايا ليتناسب مع حجم إطار OLE المطلوب، يمكنك منع تغيير الحجم غير المرغوب فيه.

**أي طريقة تحجيم يجب أن أستخدمها، تحجيم إطار OLE أم تحجيم نطاق الخلايا؟**

اختر **OLE frame scaling** إذا كنت ترغب في الحفاظ على أحجام الصفوف والأعمدة الأصلية في Excel. اختر **cell range scaling** إذا كنت تريد حجمًا ثابتًا لإطار OLE في العرض التقديمي.

**هل ستعمل هذه الحلول إذا كان عرضي مبنيًا على قالب؟**

نعم. كلا الحلين يعملان للعروض التي تم إنشاؤها من القوالب أو من الصفر.

**هل هناك حد لحجم إطار OLE عند استخدام هذه الأساليب؟**

لا. يمكنك جعل إطار OLE بأي حجم طالما قمت بضبط التحجيم بشكل مناسب.

**هل هناك طريقة لتجنب نص العنصر النائب "EMBEDDED OLE OBJECT" في PowerPoint؟**

نعم. من خلال التقاط صورة لنطاق خلايا Excel المستهدف وتعيينها كصورة بديلة لإطار OLE، يمكنك عرض صورة معاينة مخصصة بدلاً من العنصر النائب الافتراضي.

## **المقالات ذات الصلة**

[إنشاء مخطط Excel وتضمينه في عرض تقديمي ككائن OLE](/slides/ar/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[تحديث كائنات OLE تلقائيًا باستخدام إضافة MS PowerPoint](/slides/ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)