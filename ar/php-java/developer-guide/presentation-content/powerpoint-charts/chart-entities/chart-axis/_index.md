---
title: "تخصيص محاور المخطط في العروض التقديمية باستخدام PHP"
linktitle: "محور المخطط"
type: docs
url: /ar/php-java/chart-axis/
keywords:
- "محور المخطط"
- "المحور العمودي"
- "المحور الأفقي"
- "تخصيص المحور"
- "معالجة المحور"
- "إدارة المحور"
- "خصائص المحور"
- "القيمة القصوى"
- "القيمة الدنيا"
- "خط المحور"
- "تنسيق التاريخ"
- "عنوان المحور"
- "موضع المحور"
- PowerPoint
- "عرض تقديمي"
- PHP
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides للـ PHP عبر Java لتخصيص محاور المخطط في عروض PowerPoint التقديمية للتقارير والتصورات."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تخصيص محاور المخطط باستخدام Aspose.Slides for PHP عبر Java. تغطي القيم المحسوبة للمحاور، وتبديل صفوف وأعمدة المخطط، وإظهار المحور، وفواصل تسميات الفئات وعلامات الفواصل، وفئات التاريخ وتنسيقها، وتدوير العنوان، وتموضع المحور، ووحدات العرض، والقياس اللوغاريتمي.

## **الحصول على القيم القصوى على المحور العمودي في المخططات**

إنشاء [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وإضافة مخطط مساحي بالبيانات الافتراضية. استدعِ [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) قبل قراءة القيم المحسوبة للمحاور لضمان تحديث تخطيط المخطط.

اقرأ [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) و [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) للحصول على حدود المحور، و [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) و [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) لفواصل العلامات. توفر [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) و [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) مقاييس وحدة الوقت، والتي ذات صلة بمحاور التاريخ. يخزن المثال هذه القيم في متغيرات محلية ويحفظ المخطط.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تبديل البيانات بين المحاور**

استخدم [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. يغيّر هذا طريقة تجميع البيانات؛ لا يتم تبادل المحاور الأفقية والعمودية. يستخدم المثال [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف العنوان وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ مخططًا بأربع سلاسل وثلاث فئات.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعطيل المحور العمودي لمخططات الخط**

استدعِ [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) مع `false` على المحور العمودي لإخفائه. يُنشئ المثال مخطط خط بالبيانات الافتراضية ويحفظه مع إخفاء المحور العمودي.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعطيل المحور الأفقي لمخططات الخط**

استدعِ [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) مع `false` على المحور الأفقي لإخفائه. يُنشئ المثال مخطط خط بالبيانات الافتراضية ويحفظه مع إخفاء المحور الأفقي.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تغيير محور الفئة**

استخدم [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) لاختيار محور فئة تاريخ أو نص. يتطلب هذا المثال `ExistingChart.pptx`، حيث يكون المخطط هو الشكل الأول في الشريحة الأولى وتحتوي خلايا الفئة على قيم تواريخ رقمية من Excel. يغيّر ذلك المحور الأفقي إلى محور تاريخ. استدعاء [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) مع `false`، و[setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) مع `1`، و[setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) مع `TimeUnitType::Months` يضع الفواصل الرئيسية على فواصل شهرية.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **التحكم في فواصل تسميات محور الفئة**

عند وجود عدد كبير من الفئات في المخطط، قلل عدد تسميات المحور الظاهرة دون حذف الفئات أو نقاط البيانات. استدعِ [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) مع `false`، ثم مرّر الفاصل الفئوي المطلوب إلى [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). بالنسبة للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1، الفئة 2، الفئة 3، ... الفئة 24 |
| `2` | الفئة 1، الفئة 3، الفئة 5، ... الفئة 23 |
| `3` | الفئة 1، الفئة 4، الفئة 7، ... الفئة 22 |

فاصل `3` يعرض كل تسمية ثالثة، مما يترك تسمتين مخفيتين بين كل تسميتين معروضة. لا يزيل هذا الأعمدة المقابلة. الاختيار التلقائي للفاصل يحدده بناءً على المساحة المتاحة؛ ولا يعني بالضرورة عرض كل تسمية.

علامات الفواصل لها تحكم منفصل. استدعِ [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) مع `false` واستخدم [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) لتحديد فاصلها. على سبيل المثال، `1` يحافظ على علامة فاصل عند كل فاصل فئوي بينما تظهر التسميات فقط كل فئة ثالثة. استخدم [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) بنمط مرئي لتتمكن من رؤية النتيجة. استدعاء أي من مُعدِّلات الفواصل التلقائية مع `true` مرة أخرى يسمح للمخطط باختيار ذلك الفاصل مجددًا.

المثال المستقل التالي ينشئ 24 فئة وسلسلة واحدة، ثم يحفظ ثلاثة شرائح في `CategoryAxisIntervals.pptx`: التباعد التلقائي، التباعد اليدوي مع علامات فواصل مستقلة، وإعادة التباعد التلقائي. النسختان تحتفظان ببيانات المخطط الأصلية. لا يلزم تقديم عرض تقديمي مسبق. يجعل نص التسمية الأفقي الفرق في الكثافة واضحًا للعيان.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // الشريحة 2: عرض كل تسمية ثالثة، مع الحفاظ على علامة فاصل لكل فئة.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // الشريحة 3: السماح للمخطط باختيار الفواصل مرة أخرى.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**التباعد التلقائي (الشريحة 1):** في هذا العرض، تُعرض كل تسمية فئوية ثانية وتُحاوط إلى سطرين. قد يختلف النتيجة التلقائية حسب حجم المخطط، الخطوط، وواجهة العرض.

![تباعد تسميات الفئات التلقائي مع جميع الأعمدة الـ 24 مرئية](category-axis-automatic.png)

**التباعد اليدوي (الشرائح 2):** تُعرض كل تسمية ثالثة على سطر واحد، بينما تظل علامات الفواصل عند كل فاصل فئوي. جميع الأعمدة الـ 24، بما في ذلك تلك بدون تسميات، تبقى مرئية بنفس القيم. الشريحة 3 تستعيد المظهر التلقائي المعروض أعلاه.

![فاصل تسميات الفئة يدويًا بثلاثة مع جميع الأعمدة الـ 24 مرئية](category-axis-manual.png)

### **اختر المحور والفاصل الصحيح**

استخدم هذا الفاصل القائم على عدد الفئات لمحور فئة نصية، مثل محور فئة عمود، خط، مساحة، أو شريط. في مخطط العمود، يكون هو المحور الأفقي. في مخطط الشريط الأفقي، يكون محور الفئة عموديًا، لذا ضع هذه الإعدادات على المحور الذي تُرجعه [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). يطبق فاصل علامات الفواصل أيضًا على محور سلسلة في المخططات التي تحتوي على واحد.

لا تستخدم فاصل تسميات الفئة لتعيين مقياس رقمي لمحور القيمة. على محور القيمة، يحدد [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) فرق القيم: على سبيل المثال، وحدة رئيسية قيمتها `10` تنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسمية الفئة `3` بدلاً من ذلك يحسب مواضع الفئات بغض النظر عن قيم البيانات. تستخدم مخططات التشتت والفقاعات محاور قيمة بدلاً من محور فئة نصية. لمحور التاريخ، استخدم وحدات رئيسية ومقاييس زمنية كما هو موضح في [Change a Category Axis](#change-a-category-axis).

## **تعيين تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال البيانات الافتراضية للمخطط بأربع قيم سنوية. تُخزن التواريخ كأرقام سيريلية OLE Automation في الورقة الأولى (المؤشر `0`)، محسوبة كعدد أيام منذ 30 ديسمبر 1899. استخدم [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) مع `CategoryAxisType::Date`، استدعِ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) مع `false`، ومرّر `yyyy` إلى [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) لتظهر تسميات الفئة بالسنوات ذات الأربع أرقام بشكل مستقل عن تنسيق الخلية.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعيين زاوية دوران لعنوان محور المخطط**

استدعِ [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) مع `true` على المحور العمودي، أعطِ نص العنوان، واستخدم [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) لتدوير العنوان. تُقاس الزاوية بالدرجات؛ يحفظ المثال مخطط عمود مع عنوان محور القيمة مدورًا بزاوية 90 درجة.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعيين موضع المحور على محور الفئة أو القيمة**

استخدم [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) للتحكم فيما إذا كان محور القيمة يعبر محور الفئة بين الفئات أو عند علامات الفئة. ينطبق هذا الإعداد على محاور الفئة. يضبط المثال القيمة إلى `true` على محور الفئة الأفقي في مخطط العمود ويحفظ النتيجة.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعيين وحدة العرض على محور قيمة المخطط**

استخدم [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) لتقليل حجم تسميات محور القيمة دون تغيير البيانات الأساسية. مع تعيين [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) إلى `Millions`، تُعرض القيمة 60,000,000 كـ 60. ينشئ المثال مخطط عمود ويطبّق وحدة الملايين على محوره العمودي.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تهيئة محور قيمة لوغاريتمي**

محور قيمة لوغاريتمي مفيد عندما تمتد القيم الموجبة عبر عدة أوامر من الحجم. على سبيل المثال، قد يتلقى خدمة 10، 100، 1,000، 10,000، و100,000 طلبًا على مدار خمس فترات. على مقياس خطي، تظهر القيم الصغيرة متقاربة قرب الصفر. يجعل المقياس اللوغاريتمي نموها النسبي أسهل للمقارنة: المسافات المتساوية تمثل نسبًا متساوية بدلاً من فرقًا متساويًا.

استدعِ [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) مع `true` على محور القيمة واستخدم [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) لاختيار القاعدة. يغيّر هذا طريقة عرض القيم الحالية؛ لا يغيّر البيانات ولا يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة مثبتة في البيانات وهو ميزة منفصلة.

### **اختر محور القيمة والقاعدة**

للمخطط الخطي أو العمود، يُرجع محور القيمة من خلال [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). للمخطط الشريطي الأفقي، يُرجع من خلال [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). تحتوي مخططات التشتت والفقاعات على محورين للقيمة، لذا اختر المحور الأفقي لقيم X، والمحور العمودي لقيم Y، أو كليهما. لا تطبق القياس اللوغاريتمي على محور الفئة.

القاعدة اللوغاريتمية الافتراضية هي `10`. لمخططات PPTX، استخدم قاعدة من `2` إلى `1000` شاملة؛ القواعد الكسرية مثل `2.5` مدعومة أيضًا. مع القاعدة `10`، تكون القويات المتتابعة مثل 10، 100، 1,000، و10,000 متساوية المسافة.

### **قارن بين القياس الخطي واللوغاريتمي**

المثال المستقل التالي ينشئ مخطط خط مع عدد الطلبات الخمسة في الشريحة الأولى، ثم يستنسخ تلك الشريحة ويفعل محور قيمة لوغاريتمي بالقاعدة 10 في الشريحة الثانية. كلا الشريحتين تحتفظان بنفس البيانات.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // احتفظ بالشريحة الأولى خطية وقم بتغيير مقياس محور القيمة للنسخة فقط.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**القياس الخطي (الشريحة 1):** تمثل المسافات الرأسية المتساوية فروقًا متساوية في عدد الطلبات. تهيمن القيمة الأكبر على المخطط، مما يصعب تمييز القيم الصغيرة.

![مخطط خط في PowerPoint يوضح خمسة طلبات على محور قيمة خطي](value-axis-linear.png)

**القياس اللوغاريتمي (الشريحة 2):** تمثل المسافات الرأسية المتساوية نسبًا متساوية. كل فترة لديها عشرة أضعاف الطلبات مقارنةً بالفترة السابقة، لذا تشكل النقاط خطًا صاعدًا مستقيماً على مقياس القاعدة 10. لا تزال تسميات المحور تُظهر عدد الطلبات الأصلي.

![نفس الطلبات الخمسة في PowerPoint على محور قيمة لوغاريتمي بقاعدة 10](value-axis-logarithmic.png)

### **معالجة القيم الصفرية والسالبة**

يمكن للمقياس اللوغاريتمي عرض قيم موجبة صريحة فقط. تحقق من البيانات قبل تمكينه. إذا كانت القيم الصفرية أو السالبة ذات معنى، احتفظ بمقياس خطي أو اعرضها منفصلة. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فسّر سبب الإغفال. لا تستبدلها صمتًا بأرقام إيجابية صغيرة، إذ يغيّر ذلك معنى البيانات. أي حد أدنى أو أقصى مُعَد يدويًا لمحور لوغاريتمي يجب أن يكون إيجابيًا أيضًا.

## **الأسئلة الشائعة**

**كيف أعيّن القيمة التي يتقاطع عندها محور مع الآخر (تقاطع المحاور)؟**

استخدم [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) لتحديد سلوك التقاطع. لتحديد قيمة تقاطع رقمية، استخدم [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). تتيح لك هذه الإعدادات نقل تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني موضع تسميات العلامات بالنسبة للمحور؟**

استدعِ [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo`، أو `None`. للتحكم في علامات الفواصل نفسها، استخدم [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) أو [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); هذه منفصلة عن موضع التسميات.