---
title: إدارة خلايا الجداول في العروض التقديمية باستخدام PHP
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/php-java/manage-cells/
keywords:
- خلية جدول
- دمج الخلايا
- إزالة الحدود
- تقسيم الخلية
- صورة في الخلية
- لون الخلفية
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة خلايا جداول PowerPoint في PHP: تحديد الخلايا المدمجة، إزالة الحدود، تقسيم الخلايا، وتعيين ألوان الخلفية والصور باستخدام Aspose.Slides لـ PHP عبر Java."
---
## **نظرة عامة**

Aspose.Slides يتيح لك الوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint. توضح هذه المقالة كيفية تحديد خلايا الجداول المدمجة، إزالة حدود الخلية، العمل مع ترقيم الخلايا بعد دمجها أو تقسيمها، تغيير لون خلفية الخلية، وإضافة صورة داخل خلية جدول. تظهر الأمثلة كيفية إنشاء أو فتح عرض تقديمي، الحصول على جدول من شريحة، تحديث تنسيق الخلية عبر خصائص الخلية، وحفظ العرض المعدل كملف PPTX.

Aspose.Slides يستخدم مؤشرات صفرية للوصول إلى خلايا الجداول بالترتيب `(column, row)`.

## **تحديد خلية جدول مدمجة**

يفتح المثال عرضًا تقديميًا موجودًا ويصل إلى الشكل الأول في الشريحة الأولى كجدول. يفترض أن الشريحة والشكل موجودان وأن الشكل هو جدول. ثم يتنقل عبر جميع الصفوف والأعمدة ويستخدم [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) لتحديد الخلايا في المناطق المدمجة. لكل تطابق، يطبع إحداثيات الخلية بالترتيب `row;column`، [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)، [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/)، وإحداثيات بداية المنطقة، [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) و[getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **إزالة حدود خلية الجدول**

إنشاء [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وإضافة جدول إلى شريحته الأولى باستخدام [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). تُحدد أعرض الأعمدة، ارتفاعات الصفوف، وموقع الجدول بالنقاط. يضبط المثال جميع الحدود الأربعة للخلية إلى [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/)، مما يجعلها غير مرئية.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **دمج خلايا الجدول**

استخدام [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) لدمج نطاق مستطيل من خلايا الجدول في خلية واحدة. حدد الخلايا في الزاوية العلوية اليسرى واليمنى السفلية للنطاق. يتحكم الوسيط النهائي فيما إذا كان الدمج قد يشمل خلايا خارج النطاق المحدد؛ `false` يبقي الدمج داخل ذلك النطاق.

ينشئ المثال جدولًا 4×4 بأعمدة وصفوف 70 نقطة، ثم يدمج الأربع خلايا المركزية من `(1, 1)` عبر `(2, 2)`. الخلية الناتجة تمتد عمودين وصفين، بينما يظل شبكة الجدول الأساسية بأربعة أعمدة وأربعة صفوف. للوصول إلى محتوى الخلية المدمجة أو تنسيقها، استخدم موضعها العلوي الأيسر: `$table->get_Item(1, 1)` في هذا المثال. تبقى المواضع الأخرى في النطاق المدمج جزءًا من شبكة الجدول، لذا لا تتغير مؤشرات الخلايا خارج النطاق.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تقسيم خلايا الجدول**

يحافظ دمج الخلايا في المثال السابق على شبكة الجدول. قد يؤدي تقسيم خلية إلى إدخال عمود شبكة جديد وتغيير مؤشرات الأعمدة للخلايا التي على يمينها. يتبع Aspose.Slides نموذج شبكة جداول PowerPoint.

ينشئ هذا المثال جدولًا 4×4 بأعمدة وصفوف 70 نقطة ويستدعي [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) على الخلية `(1, 1)`. يتم تمرير نصف عرض الخلية البالغ 70 نقطة لإنشاء خليتين متساويتين العرض.

بعد هذا التقسيم، يتم الوصول إلى النصفين كـ `$table->get_Item(1, 1)` و`$table->get_Item(2, 1)`. أصبحت شبكة الجدول الآن تحتوي على خمسة أعمدة: تنتقل الخلايا التي كانت في الأعمدة 2 و3 إلى الأعمدة 3 و4 على التوالي. تبقى مؤشرات الصفوف دون تغيير. استخدم هذه المؤشرات المحدثة للأعمدة عند الوصول إلى الخلايا بعد التقسيم.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **تقسيم الخلايا المدمجة حسب الصف أو العمود**

لتحضير خلايا القالب المدمجة لتعبئة البيانات، استخدم [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) للتقسيم على طول حد صف موجود، أو [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) للتقسيم على طول حد عمود.

المعامل `index` يُعد الصفوف في الجزء العلوي أو الأعمدة في الجزء الأيسر من التقسيم؛ وهو نسبي إلى المنطقة المدمجة:

- تقسيم الصف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- تقسيم العمود: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

يفترض المثال وجود عرض تقديمي يحتوي على جدول كأول شكل في الشريحة الأولى، مع دمج `(1, 2)` و`(1, 3)` عموديًا. بدءًا من الموضع السفلي، يستخدم [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) و[getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) لتحديد الأصل ويفحص كلا النطاقين. `splitByRowSpan(1)` ثم يفصل الصفين 2 و3 لأسماء المنتجات. لدمج أفقي بعمودين، استخدم `splitByColSpan(1)` بدلاً من ذلك.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // استرجاع الخلايا الناتجة من الجدول بعد التقسيم.
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

تبقى شبكة الجدول ومؤشرات الخلايا المجاورة دون تغيير. استرجع الخلايا الناتجة حسب إحداثياتها؛ هنا، كلاهما يمتلك امتدادات مقدارها 1 و[isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) يُظهر `false`. يمكن أن تبقى المناطق الأكبر مدمجة جزئيًا بعد تقسيم واحد.

النص الأصلي وتنسيقه يبقى في الخلية العليا (أو اليسرى)؛ الخلية الجديدة تكون فارغة لكنها ترث تنسيق الخلية مثل التعبئة، الحدود، والهوامش. قم بملء الخلايا بعد التقسيم وتعيين أي تنسيق نص مطلوب صراحةً.

العرض المحفوظ يحتوي على خلايا "منتج A" و"منتج B" منفصلة مع الحفاظ على تنسيق خلية القالب. راجع [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) للمزيد من التفاصيل.

## **تغيير لون خلفية خلية الجدول**

ينشئ هذا المثال جدولًا بأعمدة 150 نقطة وصفوف 50 نقطة. يستخدم [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) لاختيار تعبئة صلبة ويضبط اللون المرجع من [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) إلى الأحمر للخلية `(2, 3)`, في العمود الثالث والصف الرابع.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **إضافة صورة داخل خلية جدول**

ضع صورة الإدخال في دليل العمل قبل تشغيل هذا المثال. يقوم بتحميل الصورة باستخدام [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) ويضيفها إلى مجموعة صور العرض باستخدام [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). ثم يعين الصورة إلى تعبئة الصورة للخلية `(0, 0)`, الخلية الأولى في الجدول.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) يمد الصورة لملء الخلية، مما قد يغير نسبة أبعادها. أعرض الأعمدة وارتفاعات الصفوف بالنقاط. تُخلص الصورة المحملة في كتلة `finally` بعد إضافتها إلى العرض.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة المتكررة**

**هل يمكنني تعيين سماكات خطوط وأنماط مختلفة لجوانب خلية واحدة؟**

نعم. حدود [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) لها خصائص مستقلة، لذا يمكن أن تختلف السماكة والنمط لكل جانب.

**ماذا يحدث للصورة إذا قمت بتغيير حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (تمتد/تكرار). عند التمدد، تتكيف الصورة مع الخلية الجديدة؛ وعند التكرار، يُعاد حساب البلاط.

**هل يمكنني ربط ارتباط تشعبي بجميع محتوى خلية؟**

[Hyperlinks](/slides/ar/php-java/manage-hyperlinks/) تُحدد على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بالكامل. عمليًا، تقوم بتعيين الرابط إلى جزء أو إلى كل النص داخل الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (تشغيلات) مع تنسيق مستقل—عائلة الخط، النمط، الحجم، واللون.