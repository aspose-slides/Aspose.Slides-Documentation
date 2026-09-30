---
title: إدارة الصفوف والأعمدة في جداول PowerPoint باستخدام PHP
linktitle: الصفوف والأعمدة
type: docs
weight: 20
url: /ar/php-java/manage-rows-and-columns/
keywords:
- صف جدول
- عمود جدول
- الصف الأول
- رأس الجدول
- استنساخ صف
- استنساخ عمود
- نسخ صف
- نسخ عمود
- إزالة صف
- إزالة عمود
- تنسيق نص الصف
- تنسيق نص العمود
- نمط الجدول
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة صفوف وأعمدة الجداول في PowerPoint باستخدام Aspose.Slides للـ PHP عبر Java وتسريع تحرير العروض التقديمية وتحديثات البيانات."
---
## **المقدمة**

Aspose.Slides for PHP via Java يتيح لك إدارة بنية الجداول وتنسيقها في عروض PowerPoint من خلال الفئة [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) . يمكنك تعيين صف رأس، استنساخ أو إزالة الصفوف والأعمدة، وتطبيق تنسيق النص على صف أو عمود كامل.

تشرح هذه المقالة هذه العمليات باستخدام أمثلة PHP. كما تُظهر كيفية استرجاع إعداد نمط الجدول لتتمكن من إعادة استخدامه. مؤشرات الصفوف والأعمدة في الجدول تبدأ من الصفر.

## **التحكم في ارتفاع الصف**

استخدم [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) لتعيين الحد الأدنى لارتفاع الصف بالنقاط. هو حد أدنى، ليس ارتفاعًا ثابتًا. تُعيد [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) الارتفاع الفعلي. يمكن الوصول إلى الصف عبر [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/).

يحمِّل المثال [row-height-input.pptx](row-height-input.pptx)، والذي يحتوي على جدول كأول شكل في الشريحة الأولى. يبدأ صفه الأول عند 70 نقطة. تستخدم الخلايا نصًا Arial بحجم 18 نقطة، مع التفاف وهوامش علوية وسفلية بمقدار 6 نقاط؛ النص الأطول في العمود الثاني يلتف إلى عدة أسطر. يزيد المثال الحد الأدنى إلى 100 نقطة، ثم يخفضه إلى 20 نقطة، ويطبع الارتفاع الفعلي بعد كل تعديل، ويحفظ النتيجتين.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

مع العرض المقدم، يؤدي زيادة الحد الأدنى إلى إضافة مساحة للصف. يقلل خفضه من تلك المساحة الزائدة، لكن الارتفاع الفعلي يبقى أكبر من 20 نقطة لأن النص وهوامش الخلية تحتاج إلى مساحة أكبر. لا يمكن للحد الأدنى المنخفض وحده أن يجبر الصف على أن يكون أقل من المساحة المطلوبة لمحتواه.

عدة عوامل تؤثر على الارتفاع الفعلي:

- **النص وحجم الخط:** النص الأطول، الفواصل الصريحة، أو الخط الأكبر يمكن أن يتطلب مساحة رأسية أكبر.
- **الالتفاف وعرض العمود:** مع تمكين الالتفاف، يمكن لتقليل عرض العمود باستخدام [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) إنتاج المزيد من الأسطر. العمود الأوسع يمكن أن يقلل المساحة المطلوبة عمودياً.
- **هوامش الخلية:** تضيف [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) و[Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) مساحة رأسية. تقلل [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) و[Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) العرض المتاح للنص ويمكن أن تتسبب في التفاف إضافي.

في هذا الجدول بدون خلايا مدمجة، الخلية التي تحتاج إلى أكبر مساحة رأسية تحدد الحد الأدنى للمحتوى للصف بالكامل. لجعل الصف أقصر، قد تحتاج أيضاً إلى تقصير النص، أو تقليل حجم الخط أو الهوامش، أو توسيع عمود.

تُظهر الصور أدناه نفس الجدول بنفس المقياس. في النتائج الموضحة، كانت الارتفاعات الفعلية 70، 100، و55.2 نقطة: ظل الصف النهائي أطول من الحد الأدنى البالغ 20 نقطة. قد تختلف قياسات النص الدقيقة حسب الخطوط المتوفرة في بيئتك. حمّل النتائج المحفوظة: [الحد الأدنى المتزايد](row-height-increased.pptx) و[الحد الأدنى المنخفض](row-height-decreased.pptx).

| الأصلي: الحد الأدنى 70 نقطة، الفعلي 70 نقطة | الزيادة: الحد الأدنى 100 نقطة، الفعلي 100 نقطة | التقليل: الحد الأدنى 20 نقطة، الفعلي 55.2 نقطة |
| --- | --- | --- |
| ![جدول أصلي بصف أول 70 نقطة.](row-height-before.png) | ![الجدول بعد زيادة الحد الأدنى للصف الأول إلى 100 نقطة.](row-height-increased.png) | ![الجدول بعد خفض الحد الأدنى للصف الأول إلى 20 نقطة؛ يبقي النص الملتف الصف أطول من الحد الأدنى.](row-height-decreased.png) |

## **تعيين الصف الأول كرأس**

استخدم الطريقة [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) لتحديد الصف الأول لتنسيق الرأس. مظهره يعتمد على نمط الجدول المطبق على الجدول.

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. ادخل إلى الشريحة الأولى.
3. ادخل إلى الجدول المخزن كأول شكل في الشريحة.
4. فعّل تنسيق الرأس للصف الأول.
5. احفظ العرض المعدَّل.

يتطلب المثال الملف `table.pptx` مع جدول كأول شكل في الشريحة الأولى. يُفعِّل تنسيق الرأس للصف الأول ويحفظه كـ `First_row_header.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **استنساخ صف أو عمود جدول**

استنساخ الصفوف أو الأعمدة لإعادة استخدام محتواها وتنسيقها. يمكنك إلحاق نسخة في نهاية الجدول أو إدراجها في موضع محدد.

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. ادخل إلى الشريحة الأولى.
3. حدّد عروض الأعمدة وارتفاعات الصفوف.
4. أضف جدولًا باستخدام الطريقة [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. استنسخ الصفوف المطلوبة.
6. استنسخ الأعمدة المطلوبة.
7. احفظ العرض المعدَّل.

يتطلب المثال الملف `Test.pptx` مع شريحة واحدة على الأقل. ينشئ جدولًا بثلاثة أعمدة وخمسة صفوف، بأبعاد محددة بالنقاط. يلحق نسخًا من الصف والعمود الأول، ثم يُدرج نسخًا من الصف والعمود الثاني عند الفهرس 3 (الموضع الرابع). يصبح الجدول الناتج مكوّنًا من سبعة صفوف وخمسة أعمدة. تعطّل الوسيطة `false` استنساخ الصفوف أو الأعمدة المدمجة المجاورة؛ هذا الجدول لا يحتوي على خلايا مدمجة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **إزالة صف أو عمود من جدول**

إزالة الصفوف أو الأعمدة التي لم تعد مطلوبة في جدول. يؤدي حذف عنصر إلى تعديل مؤشرات الصفوف أو الأعمدة التي تليه.

1. أنشئ عرضًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. ادخل إلى الشريحة الأولى.
3. حدّد عروض الأعمدة وارتفاعات الصفوف.
4. أضف جدولًا باستخدام الطريقة [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. احذف الصف الثاني والعمود الثاني.
6. احفظ العرض المعدَّل.

يُنشئ هذا المثال جدولًا ثلاثي × ثلاثي ويزيل الصف والعمود عند الفهرس 1، ما يُبقي جدولًا ثنائي × ثنائي في `TestTable_out.pptx`. الأبعاد بالنقاط. تعطل الوسيطة `false` حذف الصفوف أو الأعمدة المدمجة المجاورة؛ هذا الجدول لا يحتوي على خلايا مدمجة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعيين تنسيق النص على مستوى صف الجدول**

تطبيق تنسيق النص على صف كامل للحفاظ على اتساق خلاياه. يمكنك ضبط خصائص الخط، تنسيق الفقرة، واتجاه النص دون تنسيق كل خلية على حدة.

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. ادخل إلى الجدول في الشريحة الأولى.
3. استخدم [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) للصف الأول.
4. استخدم [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) و[setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) للصف الأول.
5. استخدم [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) للصف الثاني.
6. احفظ العرض المعدَّل.

يتطلب المثال الملف `table.pptx` مع جدول كأول شكل في الشريحة الأولى وعلى الأقل صفين. يُطبق نصًا بحجم 25 نقطة، محاذاة إلى اليمين، وهوامش فقرة يمينية بمقدار 20 نقطة للصف الأول، ثم يضبط النص عموديًا في الصف الثاني.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعيين تنسيق النص على مستوى عمود الجدول**

تطبيق تنسيق النص على عمود كامل للحفاظ على اتساق خلاياه. يمكنك ضبط خصائص الخط، تنسيق الفقرة، واتجاه النص دون تنسيق كل خلية على حدة.

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. ادخل إلى الجدول في الشريحة الأولى.
3. استخدم [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) للعمود الأول.
4. استخدم [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) و[setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) للعمود الأول.
5. استخدم [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) للعمود الثاني.
6. احفظ العرض المعدَّل.

يتطلب المثال الملف `table.pptx` مع جدول كأول شكل في الشريحة الأولى وعلى الأقل عمودين. يُطبق نصًا بحجم 25 نقطة، محاذاة إلى اليمين، وهوامش فقرة يمينية بمقدار 20 نقطة للعمود الأول، ثم يضبط النص عموديًا في العمود الثاني.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الحصول على خصائص نمط الجدول**

استخدم الطريقة [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) لاسترجاع الإعداد المطبق على جدول وإعادة استخدامه في جدول آخر. هذا يحدد الإعداد بدلاً من تجاوز تنسيقات الخلايا الفردية.

ينشئ المثال جدولًا، يطبق [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1)، ويقرأ الإعداد مرة أخرى. يطبع القيمة العددية المقابلة لـ `DarkStyle1` ويحفظ الجدول في `table.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة المتكررة**

**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاؤه بالفعل؟**

نعم. يرث الجدول سمة الشريحة/التخطيط/الماستر، ولا يزال بإمكانك تجاوز التعبئات والحدود وألوان النص فوق تلك السمة.

**هل يمكنني فرز صفوف الجدول مثل Excel؟**

لا، لا تحتوي جداول Aspose.Slides على فرز أو فلاتر مدمجة. قم بفرز البيانات في الذاكرة أولاً، ثم أعد ملء صفوف الجدول وفقًا لذلك الترتيب.

**هل يمكنني الحصول على أعمدة مخططة (مقيدة) مع الحفاظ على ألوان مخصصة لخلايا معينة؟**

نعم. فعّل الأعمدة المخططة، ثم تجاوز خلايا معينة بالتنسيق المحلي؛ يكون تنسيق الخلية هو المتفوق على نمط الجدول.