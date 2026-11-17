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
description: "إدارة خلايا جدول PowerPoint في PHP: تحديد الخلايا المدمجة، إزالة الحدود، تقسيم الخلايا، وتعيين ألوان الخلفية والصور باستخدام Aspose.Slides لـ PHP عبر Java."
---
## **نظرة عامة**

تتيح لك Aspose.Slides الوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint. يوضح هذا المقال كيفية تحديد الخلايا المدمجة في الجدول، وإزالة حدود الخلية، والعمل مع ترقيم الخلايا بعد دمجها أو تقسيمها، وتغيير لون خلفية الخلية، وإضافة صورة داخل خلية جدول. تُظهر الأمثلة كيفية إنشاء أو فتح عرض تقديمي، الحصول على جدول من شريحة، تحديث تنسيق الخلية عبر خصائص الخلية، وحفظ العرض المعدل كملف PPTX.

تستخدم Aspose.Slides مؤشرات تبدأ من الصفر للوصول إلى خلايا الجدول بترتيب `(column, row)`.

## **تحديد خلية جدول مدمجة**

يفتح المثال عرض تقديمي موجود ويصل إلى الشكل الأول في الشريحة الأولى كجدول. يفترض أن الشريحة والشكل موجودان وأن الشكل جدول. ثم يت循环 عبر جميع الصفوف والأعمدة ويستخدم [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) لتحديد الخلايا في المناطق المدمجة. لكل تطابق، يطبع إحداثيات الخلية بترتيب `row;column`، [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)، [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/)، وإحداثيات بداية المنطقة، [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) و[getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

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

إنشاء [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وإضافة جدول إلى الشريحة الأولى باستخدام [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). يتم تحديد عرض الأعمدة، ارتفاع الصفوف، وموقع الجدول بالنقاط. يضبط المثال جميع حدود الخلية الأربعة إلى [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/)، مما يجعلها غير مرئية.

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

## **إضافة حدود قطرية للخلية**

استخدم [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/) لرسم خط من الزاوية العليا اليسرى إلى الزاوية السفلى اليمنى، و[getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) لرسم خط من الزاوية السفلى اليسرى إلى الزاوية العليا اليمنى. يمكن للخط القطرى أن يُشير إلى رأس زاوية؛ يمكن للخطين القطرين أن يشكلا شكل X لتحديد الخلية على أنها غير صالحة.

لكل قطر خاصية [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/). في [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/)، استخدم [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) لاختيار [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) وتحديد لون عبر [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/). اضبط عرض الخط بالنقاط باستخدام [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/).

ينشئ المثال ثلاث خلايا في صف واحد: قطر أسفل إلى أسفل أحمر، قطر أعلى إلى أعلى أزرق، وكلا القطرين. يترك حدود الخلية العليا، السفلي، اليسار، واليمين دون تغيير.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

يغيّر القطر فقط تنسيق الخلية. تحتفظ كل خلية بإطار نص واحد، يُستَخدم عبر [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/). لا يمكن تعديل المناطق على جانبي القطر بشكل مستقل.

الجدول المحفوظ، معروض في Microsoft PowerPoint:

![ثلاث خلايا جدول تظهر_diagonal-cell-borders.png](diagonal-cell-borders.png)

*من اليسار إلى اليمين: قطر أسفل إلى أسفل (أحمر، 3 نقطة)، قطر أعلى إلى أعلى (أزرق، 5 نقطة)، وكلا القطرين.*

## **دمج خلايا الجدول**

استخدم [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) لدمج نطاق مستطيل من خلايا الجدول في خلية واحدة. حدد الخلايا في الزاويتين العليا اليسرى والسفلى اليمنى للنطاق. يتحكم الوسيط الأخير فيما إذا كان الدمج قد يشمل خلايا خارج النطاق المحدد؛ `false` يبقي الدمج داخل ذلك النطاق.

ينشئ المثال جدولًا 4×4 بأعمدة وصفوف عرضها 70 نقطة، ثم يدمج أربع خلايا مركزية من `(1, 1)` إلى `(2, 2)`. الخلية الناتجة تمتد عمودين وصفين، بينما يبقى شبكة الجدول الأساسية بأربعة أعمدة وأربعة صفوف. للوصول إلى محتوى الخلية المدمجة أو تنسيقها، استخدم موقعها العلوي الأيسر: `$table->get_Item(1, 1)` في هذا المثال. تبقى المواقع الأخرى في النطاق المدمج جزءًا من شبكة الجدول، لذا لا تتغير مؤشرات الخلايا خارج النطاق.

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

يحافظ دمج الخلايا في المثال السابق على شبكة الجدول. قد يُضيف تقسيم خلية عمودًا جديدًا إلى الشبكة ويغيّر مؤشرات الأعمدة للخلايا الموجودة إلى يمينه. تتبع Aspose.Slides نموذج شبكة جدول PowerPoint.

ينشئ هذا المثال جدولًا 4×4 بأعمدة وصفوف عرضها 70 نقطة ويستدعي [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) على الخلية `(1, 1)`. يُمرّر نصف عرض الخلية البالغ 70 نقطة لإنشاء خليتين عرضهما متساوٍ.

بعد هذا التقسيم، تُستَخدم النصفان كـ `$table->get_Item(1, 1)` و`$table->get_Item(2, 1)`. أصبحت شبكة الجدول الآن تحتوي على خمسة أعمدة: تنتقل الخلايا الأصلية في العمودين 2 و3 إلى العمودين 3 و4، على التوالي. تبقى مؤشرات الصفوف دون تغيير. استخدم مؤشرات الأعمدة المحدثة عند الوصول إلى الخلايا بعد التقسيم.

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


<!-- visual-explanation:manage-cells:start -->
[![خلية غير مدمجة عرضها 70 نقطة تنقسم إلى خليتين عرض كل منهما 35 نقطة، مما يضيف عمود شبكة خامس ويُزاح المؤشرات إلى يمينه.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*تقسيم العرض يؤثر على الخلية (1, 1)، باستخدام مؤشرات (column, row) التي تبدأ من الصفر. تبقى الخلايا في الصفوف الأخرى ذات خلية تمتد على موضعي العمود الجديد.*
<!-- visual-explanation:manage-cells:end -->

### **تقسيم الخلايا المدمجة حسب امتداد الصف أو العمود**

لتحضير خلايا القالب المدمجة لتعبئة البيانات، استخدم [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) للتقسيم على حد صف موجود، أو [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) للتقسيم على حد عمود.

الوسيط `index` يعدّ الصفوف في الجزء العلوي أو الأعمدة في الجزء الأيسر من التقسيم؛ وهو نسبي إلى المنطقة المدمجة:

- تقسيم الصف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- تقسيم العمود: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

يفترض المثال وجود عرض تقديمي يحتوي على جدول كأول شكل في أول شريحة، مع دمج رأسي للخلية `(1, 2)` و`(1, 3)`. يبدأ من الموضع السفلي، يستخدم [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) و[getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) لتحديد الأصل ويفحص كلا الامتدادين. ثم `splitByRowSpan(1)` يفصل الصفين 2 و3 لأسماء المنتجات. للدمج الأفقي ذو عمودين، استخدم `splitByColSpan(1)` بدلاً من ذلك.

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

تبقى شبكة الجدول ومؤشرات الخلايا المحيطة دون تغيير. استرجع الخلايا الناتجة عبر إحداثياتها؛ هنا، كل منهما يمتد بـ 1 وتعيد [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) القيمة `false`. يمكن أن تظل المناطق الأكبر مدمجة جزئيًا بعد تقسيم واحد.

يبقى النص الأصلي وتنسيقه في الخلية العليا (أو اليسرى)؛ الخلية الجديدة فارغة لكنها ورثت تنسيق الخلية مثل التعبئة، الحدود، والهوامش. عبئ الخلايا بعد التقسيم وحدد أي تنسيق نصي مطلوب صراحة.

العرض المحفوظ يحتوي على خلايا "Product A" و"Product B" منفصلتين مع الحفاظ على تنسيق خلية القالب. راجع [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) للمزيد من التفاصيل.

### **تقسيم خلية بارتفاع محدد**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) يستقبل ارتفاع الجزء العلوي بالنقاط. [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) يستقبل عدد صفوف الشبكة العليا الموجودة. لتوسيط خلية بارتفاع 40 نقطة في العمود الأيمن، اطرح 40 من الارتفاع الفعلي للخلية وقسّم المسافة المتبقية بالتساوي فوقها وتحتها.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

يضيف التقسيم الأول صفًا إلى الشبكة ويترك 90 نقطة في الخلية `(1, 1)`. التقسيم الثاني يقسم تلك الخلية إلى خلية وسط بارتفاع 40 نقطة وخلية سفلية بارتفاع 50 نقطة. الآن يحتوي العمود الأيمن على ثلاث خلايا بارتفاعات 50، 40، و50 نقطة من الأعلى إلى الأسفل. الخلية اليسرى تمتد على جميع الصفوف الثلاث وتحتفظ بارتفاعها الأصلي 140 نقطة.

![الخلية اليسرى تمتد على كامل ارتفاع الجدول بجانب ثلاث خلايا مع وسط في المنتصف.](split-by-height.png)

## **تغيير لون خلفية خلية الجدول**

ينشئ هذا المثال جدولًا بأعمدة 150 نقطة وصفوف 50 نقطة. يستخدم [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) لاختيار تعبئة صلبة ويضبط اللون الذي تُرجعه [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) إلى الأحمر للخلية `(2, 3)`, في العمود الثالث والصف الرابع.

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

ضع الصورة المدخلة في دليل العمل قبل تشغيل هذا المثال. يتم تحميل الصورة عبر [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) وإضافتها إلى مجموعة صور العرض عبر [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). ثم تُعيّن الصورة إلى ملء الصورة للخلية `(0, 0)`, الخلية الأولى في الجدول.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) يمدد الصورة لملء الخلية، ما قد يغير نسبة العرض إلى الارتفاع. عرض الأعمدة وارتفاع الصفوف بالنقاط. يتم تحرير الصورة المحمّلة في كتلة `finally` بعد إضافتها إلى العرض.

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

## **الأسئلة الشائعة**

**هل يمكنني تحديد سماكات وأنماط خطوط مختلفة للجوانب المختلفة لخلية واحدة؟**

نعم. حدود [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) لها خصائص منفصلة، لذا يمكن أن يختلف السماك والنمط لكل جانب.

**ماذا يحدث للصورة إذا قمت بتغيير حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). عند التمدد، تتكيف الصورة مع الخلية الجديدة؛ عند التبليط، تُعاد حساب البلاط.

**هل يمكنني ربط جميع محتويات الخلية برابط تشعبي؟**

[Hyperlinks](/slides/ar/php-java/manage-hyperlinks/) تُضبط على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بأكمله. عمليًا، تُعيّن الرابط إلى جزء أو إلى كل النص داخل الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (مقاطع) بتنسيق مستقل—عائلة الخط، النمط، الحجم، واللون.