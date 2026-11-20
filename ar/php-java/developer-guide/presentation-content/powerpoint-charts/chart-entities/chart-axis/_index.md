---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام PHP
linktitle: محور المخطط
type: docs
url: /ar/php-java/chart-axis/
keywords:
- محور المخطط
- المحور العمودي
- المحور الأفقي
- تخصيص المحور
- تعديل المحور
- إدارة المحور
- خصائص المحور
- القيمة القصوى
- القيمة الدنيا
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "اكتشف كيف تستخدم Aspose.Slides for PHP عبر Java لتخصيص محاور المخططات في عروض PowerPoint التقديمية للتقارير والتصوير البياني."
---
## **نظرة عامة**

هذه المقالة تشرح كيفية تخصيص محاور المخطط باستخدام Aspose.Slides for PHP عبر Java. تغطي القيم المحسوبة للمحور، تبديل صفوف وأعمدة المخطط، إظهار المحور، فواصل تسمية الفئة وعلامات الفواصل، الفئات التاريخية والتنسيق، تدوير العنوان، وضعية المحور، وحدات العرض، والقياس اللوغاريتمي.

## **الحصول على القيم القصوى على المحور العمودي في المخططات**

أنشئ [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وأضف مخطط منطقة بالبيانات الافتراضية. استدعِ [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) قبل قراءة القيم المحسوبة للمحور حتى يكون تخطيط المخطط محدثًا.

اقرأ [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) و[getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) للحصول على حدود المحور، و[getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) و[getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) لفواصل العلامات. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) و[getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) توفِّران مقاييس وحدة زمنية، وهي ذات صلة بالمحاور التاريخية. المثال يخزن هذه القيم في متغيرات محلية ويحفظ المخطط.

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

استخدم [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. هذا يغيّر طريقة تجميع البيانات؛ لا يبدّل المحاور الأفقي والعمودي. المثال يستخدم [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف العنوان وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ مخططًا بأربع سلاسل وثلاث فئات.

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

## **عكس ترتيب الرسم لمحور**

استخدم [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) لعكس فئة أو محور قيم. على سبيل المثال، يمكن لمخطط شريط أفقي إظهار مراحل المشروع من الأعلى إلى الأسفل بنفس ترتيب ورقة العمل: التخطيط، التطوير، الاختبار. عكس المحور يغيّر اتجاه الرسم؛ لا يقوم بفرز أو إعادة ترتيب بيانات المصنف. بالمقارنة، [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) يبدّل أدوار السلاسل والفئات.

المثال التالي ينشئ مخطط شريط أفقي بثلاث مراحل وسلسلة واحدة. يحفظ عرضًا تقديميًا بثلاث شرائح: الترتيب العادي، الفئات المعكوسة، والقيم المعكوسة. كل نسخة تستخدم نفس مجموعة البيانات، ويتم عكس محور واحد فقط في كل نسخة.

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // الشريحة 2: عرض الفئة الأولى في الأعلى.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // الإبقاء على محور القيم الأفقي في الأسفل.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // الشريحة 3: عكس مقياس القيم الرقمي الأفقي فقط.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

يمكن لعكس المحور أيضًا نقل المحور المتقاطع إلى الجانب المقابل من المخطط. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) يتحكم في موضع تقاطع المحور الآخر مع المحور الجاري تكوينه. في الشريحة 2، استدعاؤه بـ `CrossesType::Maximum` على محور الفئة المعكوس يبقي محور القيم الأفقي في الأسفل. لنقطة تقاطع محددة، استخدم [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). تحقق من إعدادات التقاطع عند تغيير الاتجاه، خاصة إذا كان المخطط يحتوي بالفعل على نقطة تقاطع مخصصة. استدعِ `setPlotOrderReversed` بـ `false` لاستعادة اتجاه الرسم الطبيعي؛ إعدادات التقاطع مستقلة.

| الترتيب العادي (الشريحة 1) | الفئات المعكوسة (الشريحة 2) | القيم المعكوسة (الشريحة 3) |
| --- | --- | --- |
| ![مخطط شريط أفقي بترتيب عادي للفئة والمحور القيمي](axis-order-normal.png) | ![مخطط شريط أفقي بالفئات المعروضة من الأعلى إلى الأسفل](axis-order-categories-reversed.png) | ![مخطط شريط أفقي بمحور قيم معكوس والصفر على اليمين](axis-order-values-reversed.png) |
| الفئات تمتد من الأسفل إلى الأعلى؛ القيم تزداد من اليسار إلى اليمين. | التخطيط، التطوير، والاختبار تمتد من الأعلى إلى الأسفل. القيم وترتيب صفوف المصنف لم يتغير. | الفئات تحتفظ بترتيبها الطبيعي؛ القيم تزداد من اليمين إلى اليسار. محور الفئة يتقاطع عند الصفر على اليمين. |

## **إخفاء المحور العمودي لمخططات الخطوط**

استدعِ [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) بـ `false` على المحور العمودي لإخفائه. المثال ينشئ مخطط خط بالبيانات الافتراضية ويحفظه مع إخفاء المحور العمودي.

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

## **إخفاء المحور الأفقي لمخططات الخطوط**

استدعِ [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) بـ `false` على المحور الأفقي لإخفائه. المثال ينشئ مخطط خط بالبيانات الافتراضية ويحفظه مع إخفاء المحور الأفقي.

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

## **عرض أو إخفاء خطوط الشبكة للمخطط**

استدعِ [getShowMajorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowmajorgridlines/) و[getShowMinorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowminorgridlines/) للتحقق أي خطوط شبكة يعرضها المحور. لإظهار خطوط الشبكة الصغرى، استخدم [getMinorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getminorgridlinesformat/) واضبط تعبئة الخط إلى لون صلب ومظهر. لإخفائها، اضبط التعبئة إلى [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/). استخدم [getMajorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getmajorgridlinesformat/) لتغيير تعبئة الخط لخطوط الشبكة الكبرى بنفس الطريقة. تغيير التعبئة يحافظ على إظهار المحور وعلامات الفواصل.

المحور العمودي لهذا المخطط العمودي المتجمع يُظهر في البداية خطوط الشبكة الكبرى فقط. المثال يعرض خطوط الشبكة الصغرى بالبرتقالي الداكن، ثم يخفها مرة أخرى قبل حفظ العرض التقديمي. يطبع حالة رؤية خطوط الشبكة في كل خطوة.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
    $axis = $chart->getAxes()->getVerticalAxis();
    printf("Initial: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill = $axis->getMinorGridLinesFormat()->getLine()->getFillFormat();
    $minorFill->setFillType(FillType::Solid);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $minorFill->getSolidFillColor()->setColor($darkOrange);
    printf("Enabled: minor=%s\n", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill->setFillType(FillType::NoFill);
    printf("Hidden: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $presentation->save("ChartGridlines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| تم تمكين خطوط الشبكة الصغرى | تم إخفاء خطوط الشبكة الصغرى |
| --- | --- |
| ![خطوط شبكة صغرى برتقالية بين الخطوط الكبرى على المحور العمودي](minor-gridlines-enabled.png) | ![نفس مخطط العمود مع ظهور الخطوط الكبرى فقط](minor-gridlines-hidden.png) |

## **تغيير محور الفئة**

استخدم [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) لاختيار محور فئة تاريخية أو نصية. يتطلب هذا المثال وجود `ExistingChart.pptx`، مع مخطط كأول شكل في الشريحة الأولى وخلايا الفئة تحتوي على قيم تاريخ Excel رقمية. يغيّر المحور الأفقي إلى محور تاريخ. استدعِ [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) بـ `false`، و[setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) بـ `1`، و[setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) بـ `TimeUnitType::Months` لتضع علامات رئيسية بفواصل شهرية.

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

### **تحديد نوع محور الفئة من البيانات**

استدعِ [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistypeautomatically/) بعد ملء الفئات، ثم اقرأ [getCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getcategoryaxistype/) لتفقد الاختيار. هذا مفيد عندما يتلقى نفس المخطط إما تسميات نصية أو قيم تاريخ رقمية. الطريقة تحدد النوع عند الاستدعاء؛ لا تمكّن وضعًا مستمرًا يعيد التقييم لاحقًا عند تغيير البيانات. استدعِها مرة أخرى بعد استبدال الفئات.

المثال التالي ينشئ مخططًا بفئات نصية ويطبع `true` عندما يكون النوع المختار هو `CategoryAxisType::Text`. ثم يستبدل قيم خلايا الفئة بالتواريخ ويستدعي الطريقة مرة أخرى، مطبعًا `true` عندما يكون النوع المختار هو `CategoryAxisType::Date`. تُخزن التواريخ كقِيَم رقمية من نوع OLE Automation، تُحسب لعدد الأيام منذ 30 ديسمبر 1899، وليس كسلاسل تاريخية. [setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) يتحكم في طريقة عرض هذه القيم؛ لا يحوّل النص إلى تواريخ رقمية. للمزيد عن خلايا الفئة، راجع [Chart Workbook](/slides/ar/php-java/chart-workbook/).

استخدم التحديد التلقائي عندما يُعرف أن الإدخال يحتوي على فئات نصية أو تواريخ رقمية، كما في هذا المثال. بالنسبة للتسميات الرقمية العادية أو الفئات المختلطة أو البيانات الفارغة، استدعِ صراحةً [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) لتتناسب مع المعنى المقصود. القيم الرقمية وحدها لا تُثبت أن الفئات تمثل تواريخ.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $seriesName = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());
    $labels = ["First", "Second", "Third"];

    for ($i = 0; $i < count($labels); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $labels[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, ($i + 1) * 10);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Text ? "true" : "false") . PHP_EOL;

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);
    $dates = [gmmktime(0, 0, 0, 1, 1, 2026), gmmktime(0, 0, 0, 1, 2, 2026), gmmktime(0, 0, 0, 2, 1, 2026)];

    for ($i = 0; $i < count($dates); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0);
        $categoryCell->setValue((float)(($dates[$i] - $baseDate) / 86400));
        $categoryCell->setCustomNumberFormat("yyyy-mm-dd");
    }

    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Date ? "true" : "false") . PHP_EOL;

    $presentation->save("AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **التحكم بفواصل تسمية محور الفئة**

عند وجود many categories في المخطط، قلل عدد التسميات الظاهرة للمحور دون إزالة الفئات أو نقاط البيانات. استدعِ [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) بـ `false`، ثم مرّر الفاصل الفئوي المطلوب إلى [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات الظاهرة في المثال |
| --- | --- |
| `1` | الفئة 1، الفئة 2، الفئة 3، ... الفئة 24 |
| `2` | الفئة 1، الفئة 3، الفئة 5، ... الفئة 23 |
| `3` | الفئة 1، الفئة 4، الفئة 7، ... الفئة 22 |

فاصل `3` يعرض كل تسمية ثالثة، مع إخفاء تسمينتين بين كل تسميتين معروضة. لا يزيل الأعمدة المقابلة. الفواصل التلقائية تختار فاصلًا بناءً على المساحة المتاحة؛ لا تضمن عرض كل تسمية.

لعلامات الفواصل تحكم منفصل. استدعِ [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) بـ `false` واستخدم [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) لتحديد فاصلها. على سبيل المثال، `1` يبقي علامة فاصل عند كل فاصل فئة بينما تظهر التسميات كل فئة ثالثة فقط. استخدم [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) بنمط ظاهر لتتمكن من رؤية النتيجة. استدعاء أي من محددات الفواصل التلقائية بـ `true` مرة أخرى يسمح للمخطط باختيار ذلك الفاصل مرة أخرى.

المثال التالي المستقل ينشئ 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: الفاصل التلقائي، الفاصل اليدوي مع علامات فواصل مستقلة، وإعادة الفاصل التلقائي. النسختان تحتفظان ببيانات المخطط الأصلية. لا يلزم عرض تقديمي إدخال. نص تسمية المحور الأفقي يُظهر الفرق في الكثافة بسهولة.

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

    // الشريحة 2: عرض كل تسمية ثالثة، ولكن الحفاظ على علامة فاصل لكل فئة.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // الشريحة 3: السماح للمخطط باختيار كلا الفاصلين مرة أخرى.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**الفاصل التلقائي (الشريحة 1):** في هذا العرض، تُعرض كل تسمية فئة ثانية وتُقسم إلى سطرين. النتيجة التلقائية قد تختلف مع حجم المخطط، الخطوط، ومكوّن الرسم.

![فاصل تسمية الفئة التلقائي مع جميع الأعمدة الـ 24 مرئية](category-axis-automatic.png)

**الفاصل اليدوي (الشريحة 2):** تُعرض كل تسمية ثالثة على سطر واحد، بينما تظل علامات الفواصل عند كل فاصل فئة. جميع الأعمدة الـ 24، بما فيها تلك التي لا تحمل تسميات، تظل مرئية بنفس القيم. الشريحة 3 تُعيد المظهر التلقائي الموضح أعلاه.

![فاصل تسمية الفئة اليدوي بثلاثة مع جميع الأعمدة الـ 24 مرئية](category-axis-manual.png)

### **اختر المحور الصحيح والفاصل المناسب**

استخدم هذا الفاصل للعدد الفئوي لمحور فئة نصية، مثل محور الفئة لمخطط عمودي، خطي، مساحي أو شريط. في المخطط العمودي، هو المحور الأفقي. في مخطط الشريط الأفقي، محور الفئة عمودي، لذا طبِّق هذه الإعدادات على المحور المسترجع بواسطة [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). فواصل علامات الفواصل تنطبق أيضًا على محور السلسلة في المخططات التي تمتلك واحدًا.

لا تستخدم فواصل تسمية الفئة لتحديد مقياس عددى لمحور قيم. في محور قيم، [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) يحدد فرق القيم: على سبيل المثال، وحدة رئيسية بقيمة `10` تُنتج فواصل عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسمية فئة بـ `3` يعد مواضع الفئات بغض النظر عن قيم البيانات. مخططات التبعثر والفقاعات تستخدم محاور قيم بدلاً من محور فئة نصية. للمحور التاريخي، استخدم الوحدات الزمنية الكبيرة والمقاييس كما هو موضح في [تغيير محور الفئة](#change-a-category-axis).

## **تعيين تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال بيانات المخطط الافتراضية بأربع قيم سنوية. تُخزن التواريخ كقِيَم تسلسلية OLE Automation في ورقة العمل الأولى (المؤشر `0`)، تُحسب كعدد الأيام منذ 30 ديسمبر 1899 لهذه التواريخ. استخدم [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) بـ `CategoryAxisType::Date`، استدعِ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) بـ `false`، ومرّر `yyyy` إلى [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) لتظهر تسميات الفئة بسنوات رباعية الأرقام بغض النظر عن تنسيق الخلية.

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

## **تعيين زاوية تدوير لعنوان محور المخطط**

استدعِ [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) بـ `true` على المحور العمودي، قدم نص العنوان، واستخدم [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) لتدوير العنوان. الزاوية تُقاس بالدرجات؛ هذا المثال يحفظ مخطط عمودي مع تدوير عنوان محور القيم بــ 90 درجة.

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

## **تعيين موضع المحور على محور فئة أو قيمة**

استخدم [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) للتحكم فيما إذا كان محور القيمة يتقاطع مع محور الفئة بين الفئات أو عند علامات الفئات. هذا الإعداد ينطبق على محاور الفئات. المثال يضبطه على `true` على محور الفئة الأفقي لمخطط عمودي ويحفظ النتيجة.

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

استخدم [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) لتكبير أو تصغير التسميات على محور القيمة دون تغيير البيانات الأساسية. مع [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) مضبوطًا على `Millions`، تُعرض القيمة 60 000 000 كـ 60. المثال ينشئ مخطط عمودي ويطبق وحدة العرض بالملايين على محوره العمودي.

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

## **تكوين محور قيمة لوغاريتمي**

محور قيمة لوغاريتمي مفيد عندما تمتد القيم الموجبة عبر عدة أوامر من الحجم. على سبيل المثال، قد يتلقى خدمة 10، 100، 1 000، 10 000، و100 000 طلبًا عبر خمس فترات. على مقياس خطي، تظهر القيم الأصغر متقاربة قرب الصفر. المقياس اللوغاريتمي يُسهل مقارنة النمو النسبي: المسافات المتساوية تمثل نسبًا متساوية بدلاً من فروق متساوية.

استدعِ [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) بـ `true` على محور القيمة واستخدم [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) لاختيار القاعدة. هذا يغيّر طريقة عرض القيم الحالية؛ لا يغيّر البيانات ولا يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة مُناسبة في البيانات وهو ميزة منفصلة.

### **اختيار محور القيمة والقاعدة**

للمخطط الخطي أو العمودي، يُسترجع محور القيمة عبر [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). للمخطط الشريطي الأفقي، يُسترجع عبر [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). مخططات التبعثر والفقاعات لها محوران للقيمة، لذا اختر المحور الأفقي لقيم X، والمحور العمودي لقيم Y، أو كلاهما. لا تُطبق المقياس اللوغاريتمي على محور الفئة.

القاعدة اللوغاريتمية الافتراضية هي `10`. لمخططات PPTX، استخدم قاعدة من `2` إلى `1000` شاملة؛ القواعد الكسرية مثل `2.5` مدعومة كذلك. مع القاعدة `10`، تكون القوى المتتالية مثل 10، 100، 1 000، و10 000 متباعدة بالتساوي.

### **مقارنة المقياس الخطي واللوغاريتمي**

المثال التالي المستقل ينشئ مخطط خط مع عدد الطلبات الخمسة في الشريحة الأولى، ثم ينسخ تلك الشريحة ويفعل محور قيمة لوغاريتمي بقاعدة 10 في الشريحة الثانية. تحتفظ كلتا الشريحتين بنفس البيانات.

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

    // اجعل الشريحة الأولى خطية وغيّر فقط مقياس محور القيم للنسخة.
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

**المقياس الخطي (الشريحة 1):** المسافات العمودية المتساوية تمثل فروقًا متساوية في عدد الطلبات. القيمة الكبرى تهيمن على المخطط، ما يصعّب تمييز القيم الأصغر.

![مخطط خط في PowerPoint يظهر خمس طلبات على محور قيمة خطي](value-axis-linear.png)

**المقياس اللوغاريتمي (الشريحة 2):** المسافات العمودية المتساوية تمثل نسبًا متساوية. كل فترة لها عدد طلبات يساوي عشرة أضعاف الفترة السابقة، لذا تُكوّن النقاط خطًا مستقيمًا صاعدًا على المقياس اللوغاريتمي بقاعدة 10. لا تزال تسميات المحور تُظهر عدد الطلبات الأصلي.

![نفس خمس طلبات في PowerPoint على محور قيمة لوغاريتمي بقاعدة 10](value-axis-logarithmic.png)

### **معالجة القيم الصفرية والسالبة**

المقياس اللوغاريتمي لا يمكنه عرض سوى القيم الموجبة الصارمة. تحقق من البيانات قبل تفعيله. إذا كانت القيم الصفرية أو السالبة ذات معنى، احتفظ بالمقياس الخطي أو أعرضها بشكل منفصل. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فسِّر الإغفال. لا تستبدلها صامتًا بأعداد موجبة صغيرة، لأن ذلك يغير معنى البيانات. أي حد أدنى أو أقصى مُكوَّن يدويًا لمحور لوغاريتمي يجب أن يكون أيضًا موجبًا.

## **الأسئلة الشائعة**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها محور مع المحور الآخر (تقاطع المحاور)؟**

استخدم [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) لتحديد سلوك التقاطع. لتحديد قيمة تقاطع رقمية، استخدم [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). تسمح لك هذه الإعدادات بنقل تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني موضع تسميات العلامات بالنسبة للمحور؟**

استدعِ [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo` أو `None`. للتحكم في علامات الفواصل نفسها، استخدم [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) أو [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); هذه منفصلة عن موضع التسميات.