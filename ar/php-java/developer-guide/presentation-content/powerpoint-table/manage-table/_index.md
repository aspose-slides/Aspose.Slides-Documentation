---
title: إدارة جداول العروض التقديمية في PHP
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/php-java/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى الجدول
- نسبة الأبعاد
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتعديل الجداول في عروض PowerPoint باستخدام Aspose.Slides لـ PHP عبر Java. اكتشف أمثلة كود بسيطة لتبسيط سير عمل الجداول الخاصة بك."
---
## **المقدمة**

تقوم الجداول في PowerPoint بتنظيم المعلومات في صفوف وأعمدة، مما يجعل من السهل قراءتها ومقارنة القيم.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) والفئة [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) وأنواع أخرى للسماح لك بإنشاء وتحديث وإدارة الجداول في العروض التقديمية.

## **إنشاء جدول من الصفر**

إنشاء جدول عن طريق تحديد موقعه وعرض الأعمدة وارتفاع الصفوف. بعد إضافته إلى شريحة، يمكنك تنسيق حدود الخلايا، دمج الخلايا، وإدراج نص.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة حسب فهرستها.
3. تحديد مصفوفة من عروض الأعمدة بالنقاط.
4. تحديد مصفوفة من ارتفاعات الصفوف بالنقاط.
5. إضافة كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) إلى الشريحة عبر الطريقة [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) .
6. تكرر عبر كل [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) لتطبيق تنسيق على الحدود العليا والسفلى واليمين واليسار.
7. دمج الخليتين الأوليين في الصف الأول من الجدول.
8. الوصول إلى الخلية المدمجة عبر طريقة [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) .
9. تعيين النص في الخلية المدمجة.
10. حفظ العرض التقديمي المعدل.

المثال أدناه ينشئ جدولًا بثلاثة أعمدة وخمس صفوف عند (100, 50) نقطة. يطبق حدودًا حمراء بعرض 5 نقاط، يدمج الخليتين الأوليين في الصف الأول، ويحفظ النتيجة باسم `table.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الترقيم في جدول قياسي**

في جدول قياسي، مؤشرات الخلايا تبدأ من الصفر وتستخدم الترتيب (عمود، صف). الخلية الأولى لها الفهرس (0, 0).

على سبيل المثال، تُرقم الخلايا في جدول يضم 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

هذا المثال ينشئ جدول 4 × 4 الموضح أعلاه، بعروض الأعمدة وارتفاعات الصفوف 70 نقطة، وحدود خلايا حمراء بعرض 5 نقاط. تُظهر الإحداثيات مؤشرات الخلايا؛ يترك المثال الخلايا فارغة ويحفظ الجدول باسم `StandardTables_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الوصول إلى جدول موجود**

يتم تخزين الجداول في مجموعة الأشكال الخاصة بالشريحة. تكرار عبر الأشكال لتحديد موقع جدول، ثم استخدم الفئة [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) لقراءة أو تحديث خلاياه.

1. تحميل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة التي تحتوي على الجدول حسب فهرستها.
3. تكرار عبر كائنات [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) والتوقف عند العثور على جدول. إذا كانت الشريحة تحتوي على عدة جداول، استخدم [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) لتحديد الجدول المطلوب.
4. تحديث النص في الخلية المستهدفة.
5. حفظ العرض التقديمي المعدل.

المثال أدناه يفتح `UpdateExistingTable.pptx` ويجد أول جدول في الشريحة الأولى. يعيّن الخلية في العمود 0، الصف 1 إلى `New` ويحفظ النتيجة باسم `table1_out.pptx`. يجب أن يحتوي الإدخال على شريحة واحدة على الأقل، ويجب أن يحتوي أول جدول في تلك الشريحة على عمود واحد على الأقل وصفين على الأقل.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

لتحجيم صف في جدول موجود وفهم لماذا قد يتجاوز ارتفاعه الفعلي الحد الأدنى المطلوب، راجع [التحكم في ارتفاع الصف](/slides/ar/php-java/manage-rows-and-columns/#control-row-height).

## **العثور على الخلية التي تمتلك إطار نص**

عند تلقي كود معالجة نص عام كائن [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) من جدول، استخدم طريقة [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) لاسترجاع [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) المالكة. بالنسبة لإطار نص خلية جدول، تُعيد [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) المالك وتُعيد [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) `null`، رغم أن الجدول نفسه شكل.

إحداثيات الخلية متاحة عبر الطريقة القراءة‑فقط [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) والطريقة [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) . توفر [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) أيضًا تنقلًا للقراءة‑فقط: تُعيد المالك دون تغيير الملكية. تأكد دائمًا من فحص الخلية المرجعية باستخدام `java_is_null` قبل استخدامها.

للحصول على مثال كامل يحدد مالكي خلايا الجدول والأشكال، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [بحث واستبدال النص](/slides/ar/php-java/search-and-replace-text/).

## **محاذاة النص في جدول**

يمكنك التحكم في تثبيت العمودي واتجاه النص لخلايا الجدول الفردية. المثال في هذا القسم يوسط النص داخل الخلية الأولى ويديره بزاوية 270 درجة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة حسب فهرستها.
3. إضافة كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) إلى الشريحة.
4. الوصول إلى كائن [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) من الجدول.
5. الوصول إلى أول [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) وتعيين نصه ولونه.
6. تعيين تثبيت العمودي للخلية واتجاه النص باستخدام [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) و[setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/) .
7. حفظ العرض التقديمي المعدل.

هذا المثال ينشئ جدولًا 4 × 4 بعروض أعمدة 120 نقطة وارتفاع صفوف 100 نقطة. ينسق النص في الخلية (0, 0)، يضيف قيمًا إلى الخلايا المتبقية في الصف الأول، ويحفظ النتيجة باسم `Vertical_Align_Text_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعيين تنسيق النص على مستوى الجدول**

استخدم [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) لتطبيق تنسيق النص على جميع خلايا الجدول. تدعمه الإصدارات المتعددة لتنسيق الجزء والفقرة وإطار النص، بحيث يمكنك تعيين هذه الخصائص دون الحاجة للتكرار عبر كل خلية.

1. تحميل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة حسب فهرستها.
3. الوصول إلى كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) من الشريحة.
4. تعيين حجم الخط باستخدام [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) للنص.
5. تعيين محاذاة الفقرة والهامش الأيمن باستخدام [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) و[setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) .
6. تعيين اتجاه النص باستخدام [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) .
7. حفظ العرض التقديمي المعدل.

المثال أدناه يفتح `table.pptx`، والذي يجب أن يحتوي على شريحة واحدة على الأقل مع جدول كأول شكل. يعيّن حجم الخط إلى 25 نقطة، يضبط محاذاة الفقرات إلى اليمين مع هامش أيمن 20 نقطة، ويجعل النص عموديًا. يتم حفظ العرض المنسق باسم `result.pptx`.

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الحصول على خصائص نمط الجدول**

استخدم [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) لقراءة النمط المسبق للجدول و[setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) لتعيينه. يطبق هذا المثال [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) على جدول واحد، يطبع قيمة النمط المسبق، ويعين نفس النمط لجدول ثاني. يتم حفظ كلا الجدولين في `table-style.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **قفل نسبة الأبعاد لجدول**

نسبة أبعاد الجدول هي نسبة عرضه إلى ارتفاعه. استخدم [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) لقفل هذه النسبة للجدول.

المثال أدناه يفتح `pres.pptx`، والذي يجب أن يحتوي على شريحة واحدة على الأقل مع جدول كأول شكل. يطبع حالة القفل الحالية، يفعّل قفل نسبة الأبعاد، يطبع الحالة المحدثة (`true`)، ويحفظ النتيجة باسم `pres-out.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة المتكررة**

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. تعرض الجدول طريقة [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) ، وتتوفر الفقرات على طريقة [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). باستخدام الطريقتين يضمن ترتيب RTL الصحيح وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم جدول في الملف النهائي؟**

استخدم [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) لتعطيل التحريك، تغيير الحجم، التحديد، وما إلى ذلك. تنطبق هذه الأقفال على الجداول أيضًا.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) للخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمدد أو تجانب).