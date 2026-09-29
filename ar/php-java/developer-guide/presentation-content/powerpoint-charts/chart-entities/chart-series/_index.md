---
title: "إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام PHP"
linktitle: "سلسلة البيانات"
type: docs
url: /ar/php-java/chart-series/
keywords:
- "سلسلة المخطط"
- "تداخل السلسلة"
- "لون السلسلة"
- "اسم السلسلة"
- "نقطة البيانات"
- "خلية دفتر العمل"
- "فجوة السلسلة"
- "قيمة سلبية"
- "PowerPoint"
- "عرض تقديمي"
- "PHP"
- "Aspose.Slides"
description: "تعرف على كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا دفتر العمل، التنسيق، التداخل، عرض الفجوة، والقيم السلبية في العروض التقديمية باستخدام PHP."
---
## **نظرة عامة**

يخزن المخطط بياناته المرسومة في دفتر بيانات المخطط. يمثل [ChartSeries](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/) مجموعة واحدة من القيم ذات الصلة، وكل [ChartDataPoint](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/) في السلسلة يشير إلى خلية أو أكثر في دفتر العمل. توفر كائنات [ChartCategory](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. لذلك يتم ربط اسم السلسلة والفئات وقيم النقاط بـ كائنات [ChartDataCell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/) بدلاً من تخزينها كنص عرض فقط.

في مخطط الفئات النموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، وبقية الخلايا لقيم السلاسل. فهارس ورقة العمل والصف والعمود التي تُمرَّر إلى [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/#getCell) تبدأ من الصفر. هذا التخطيط مفيد عندما تنشئ مخططًا ببيانات افتراضية، ولكن لا تفترض أن كل مخطط موجود يستخدمه. بالنسبة لعروض تقديمية محمَّلة، قم بفحص الخلايا المشار إليها من قبل السلاسل والفئات ونقاط البيانات قبل تعديل قيم دفتر العمل.

لإعدادات المخطط ثلاثة نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [ChartSeries.getFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getFormat)، توفر الشكل الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات نقطة البيانات، مثل [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/#getFormat)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تنطبق على السلاسل المتوافقة التي تنتمي إلى نفس [ChartSeriesGroup](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseriesgroup/). يمكنك الوصول إلى المجموعة عبر [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getParentSeriesGroup) عندما تحتاج إلى ضبط خيارات مثل التداخل أو عرض الفجوة.

عند عدم تحديد تعبئة صريحة للنقطة أو للسلسلة، يحدد نمط المخطط والموضوع المظهر التلقائي. عندما يكون كل من تنسيق السلسلة وتنسيق النقطة موجودين، يتفوق تنسيق النقطة لتلك النقطة.

![سلسلة المخطط في PowerPoint](chart-series-powerpoint.png)

## **تعيين تداخل سلسلة المخطط**

يقوم [ChartSeries.getOverlap](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getOverlap) بالإبلاغ عن مقدار تداخل الأعمدة أو الشرائح في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمئة. هو عرض للقراءة فقط للإعداد على مجموعة السلسلة الأم. استخدم [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseriesgroup/#setOverlap) لتحديث كل السلاسل المتوافقة في تلك المجموعة. ينطبق هذا الخيار على أنواع المخططات التي تعرض أعمدة أو شرائح مجمعة؛ ولا يؤثر على مجموعات السلاسل غير المرتبطة في مخطط مركب.

المثال التالي يعيّن التداخل للمجموعة التي تحتوي على السلسلة الأولى:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // المخطط الجديد يحتوي على سلاسل وعناصر فئة وقيم تجريبية.
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

النتيجة:

![تداخل السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [ChartSeries.getFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getFormat) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كانت النقطة لها تعبئة صريحة بالفعل، فإن إعداد [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/#getFormat) يتجاوز تعبئة السلسلة لتلك النقطة.

المثال التالي يطبق تعبئة صلبة زرقاء على السلسلة الأولى:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

النتيجة:

![لون السلسلة](series_color.png)

## **تغيير اسم السلسلة**

يتم تخزين اسم السلسلة في دفتر بيانات المخطط وعادةً ما يُعرض في الأسطورة. في دفتر العمل الافتراضي الذي يُنشأ لمخطط عمودي مُجمّع، الخلية B1 تقع في الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. المتغيرات المسماة في المثال التالي تجعل هذا الهيكل واضحًا:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

يمكنك أيضًا تحديث الخلية التي يشير إليها بالفعل [ChartSeries.getName](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getName). يَتَجنّب هذا النهج الافتراض بخصوص صف أو عمود معين في مخطط موجود:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

النتيجة:

![اسم السلسلة](series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

تُرجع [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) اللون المحسوب استنادًا إلى فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا يتم تعريف تعبئة السلسلة صراحة. استدعاء الطريقة يقرأ اللون المحسوب؛ لا يعيّن تعبئة جديدة.

المثال التالي يطبع اللون التلقائي لكل سلسلة افتراضية:

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

مخرجات المثال للنمط الافتراضي للمخطط:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين لون تعبئة معكوس لسلسلة المخطط**

للسلاسل العمودية، العمودية العمودية (bars) والسلسلة الفقاعية، يمكن لـ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#setInvertIfNegative) عرض القيم السالبة بتعبئة مختلفة. عيّن تعبئة السلسلة العادية إلى صلبة، فعّل الانعكاس، وعيّن لون القيمة السالبة عبر [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). تظل الأعداد السالبة غير متغيرة في دفتر العمل؛ يتغير فقط لون عرضها.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. الصف 0 في ورقة العمل يحتوي على اسم السلسلة، العمود 0 يحتوي على أسماء الفئات، والعمود 1 يحتوي على القيم:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

النتيجة:

![لون التعبئة الصلبة المعكوس](inverted_solid_fill_color.png)

يمكنك تمكين الانعكاس لنقطة واحدة عبر [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). في المثال التالي، تم إلغاء تفعيل الانعكاس للسلسلة وتفعيلها فقط للنقطة المختارة. كما تُعطى النقطة قيمة سالبة لتظهر التأثير:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **مسح قيمة نقطة بيانات محددة**

لجعل نقطة واحدة فارغة دون إزالة باقي النقاط، عيّن الخلية الداعمة في دفتر العمل إلى `null`. بالنسبة لمخطط عمود، القيمة المرسومة متاحة عبر [ChartDataPoint.getValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/#getValue). تظل نقطة البيانات في نفس موقع الفئة، لكن المخطط يتعامل مع قيمتها كفراغ وفقًا لإعدادات القيم الفارغة للمخطط.

المثال التالي يمسح فقط النقطة الثانية في السلسلة الأولى:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

تستخدم المخططات المبعثرة خلايا X وY منفصلة، وتستخدم مخططات الفقاعات أيضًا خلية الحجم. امسح فقط الخلية التي تمثل القيمة التي تريد إزالتها. لا تستدعِ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapointcollection/#clear) عندما تريد الحفاظ على باقي النقاط، لأن هذه الطريقة تزيل كل نقاط البيانات من المجموعة.

## **التحكم في عرض الخلايا الفارغة**

الخلايا المخفية التي تحتوي على قيم هي حالة منفصلة عن الخلايا الفارغة. لتضمين أو استبعاد البيانات من الصفوف والأعمدة المخفية في ورقة العمل، راجع [Include Data from Hidden Rows and Columns](/slides/ar/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

الخلية الفارغة في دفتر العمل تمثل بيانات مفقودة؛ الخلية التي تحتوي على `0` تمثل قيمة رقمية معروفة. استدعِ [ChartDataCell::setValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/#setValue) مع `null` لجعل الخلية فارغة. الصفر الرقمي يظل صفرًا بغض النظر عن إعداد الخلية الفارغة.

استخدم [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/#setDisplayBlanksAs) لاختيار طريقة عرض الخلايا الفارغة في المخططات. ينطبق هذا الإعداد على المخطط بالكامل. يغيّر طريقة رسم الفراغات دون ملء الخلية الفارغة في دفتر العمل بالصفر أو قيمة مُقَربة.

المثال المستقل التالي ينشئ مخطط خط بسلسلة واحدة، يمسح القيمة للّ يوم 3، ويحفظ المخطط نفسه بكل وضع. لا يلزم ملف إدخال. يستخدم [ChartDataWorkbook](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/) ورقة عمل 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // اترك اليوم 3 فارغًا فعليًا، مع الاحتفاظ بفئته ونقطة البيانات الخاصة به.
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

كل ملف إخراج يخزن الوضع المحدد قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و`empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض مرة واحدة بدلاً من التكرار على الأوضاع.

المقارنة أدناه تُظهر نفس البيانات في الملفات الثلاثة. اليوم 3 فارغ في دفتر العمل في كل الحالات:

![مخططات خطية ببيانات متطابقة: الفجوة تقطع الخط في اليوم 3، الصفر يُسقط الخط إلى الصفر، والامتداد يربط اليوم 2 باليوم 4.](display_blanks_as.png)

التأثير الظاهر يعتمد على نوع المخطط. يجعل مخطط الخط الثلاثة أوضاع سهلة للمقارنة. لا تمتلك مخططات الأعمدة والشرائح خطًا للربط عبر فئة مفقودة، لذلك لا يمكن لـ `Span` إنتاج الجزء المتصل المعروض أعلاه؛ قد يبدو العمود المفقود وعمود الصفر المتاح متشابهين. بالمثل، مخطط المبعثر مع العلامات فقط لا يملك خطًا موصولًا. لا تتوقع ثلاث نتائج متميزة لكل نوع مخطط؛ تحقق من النتيجة للنوع الذي تستخدمه.

## **تعيين عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأعمدة أو الشرائح المتجاورة، ويُعبَّر عنه كنسبة مئوية من عرض العمود أو الشريحة. مثل التداخل، يخص مجموعة السلسلة الأم وليس سلسلة واحدة. استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseriesgroup/#setGapWidth) مرة واحدة للمجموعة. القيمة الأكبر تُنشئ مساحة أكبر بين المجموعات؛ والقيمة الأصغر تجعلها أكثر كثافة.

المثال التالي يغيّر عرض الفجوة ويحفظ العرض النهائي فقط:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

النتيجة:

![عرض الفجوة](gap_width.png)

## **الأسئلة المتكررة**

**أي أنواع المخططات تدعم سلاسل البيانات؟**

جميع أنواع المخططات الممثلة في تعداد [ChartType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تشترك جميعها في نفس هيكل القيم أو الإعدادات. على سبيل المثال، تستخدم مخططات الفئات الفئات والقيم، وتستخدم مخططات المبعثر قيم X وY، وتضيف مخططات الفقاعات أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. الخيارات مثل التداخل وعرض الفجوة تنطبق فقط على مجموعات الأعمدة أو الشرائح المتوافقة.

**ما هي مجموعة سلاسل المخطط؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseriesgroup/) يحتوي على سلاسل متوافقة تشترك في إعدادات رسم على مستوى المجموعة. يمكن لمخطط مركب أن يحتوي على أكثر من مجموعة، لذا تعديل المجموعة التي يتم الوصول إليها عبر سلسلة واحدة لا يعني بالضرورة تعديل كل السلاسل في المخطط.

**هل يحتوي المخطط المُنشأ حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، تقوم [ShapeCollection.addChart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/#addChart) بإنشاء سلاسل وعناصر فئة وقيم تجريبية. يمكنك تعديل تلك الخلايا أو مسح كل من مجموعتي السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة تمامًا. يمكن لتجاوز الدالة أيضًا إنشاء مخطط بدون بيانات افتراضية.

**كيف يتم ربط كائنات المخطط بخلايا دفتر العمل؟**

أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات تشير إلى خلايا في [ChartDataWorkbook](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/). تعديل خلية مشار إليها يحدث تحديثًا للعنصر المقابل في المخطط. عند بناء بيانات مخصصة، حافظ على محاذاة صفوف الفئات وصفوف قيم السلاسل بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أقوم بمسح نقطة واحدة بدلاً من مسح السلسلة بالكامل؟**

عيّن خلية القيمة المعنية إلى `null` لتبقى نقطة البيانات في موضع الفئة كقيمة فارغة. استخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapointcollection/#clear) فقط عندما ترغب في إزالة جميع النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل بحيث تبقى قيمها محاذية مع مجموعة الفئات.

**كيف تُعرض النقاط الفارغة؟**

النتيجة تعتمد على نوع المخطط والقيمة المُكوَّنة عبر [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/#setDisplayBlanksAs). يمكن للمخططات المدعومة عرض الفراغات كفجوات، كقيم صفرية، أو بربط النقاط المجاورة. اختر الإعداد الذي يتوافق مع معنى البيانات المفقودة في عرضك. راجع **التحكم في عرض الخلايا الفارغة** للحصول على مثال كامل ومقارنة بصرية.

**كيف يتم تنسيق القيم السالبة؟**

للسلاسل العمودية، العمودية، والفقاعية المدعومة، استدعِ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#setInvertIfNegative) وعيّن اللون الذي تُرجعه [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). يمكنك تجاوز السلوك لنقطة فردية عبر [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). هذه الطرق تؤثر على التنسيق فقط، لا على القيم الرقمية المخزنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

يتفوق تنسيق نقطة البيانات الصريح لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، عندما لا يكون تنسيق السلسلة معرفًا، نمط المخطط والموضوع التلقائي. إعدادات المجموعة مثل التداخل وعرض الفجوة تتحكم في التخطيط وليست تجاوزات تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

Aspose.Slides لا يفرض حدًا ثابتًا منفصلًا لعدد السلاسل. في الواقع، تحدد قيود ملف العرض، الذاكرة المتاحة، وقت التصيير، وقابلية قراءة المخطط حدًا عمليًا.

**ما الذي يجب تغييره عندما تكون الأعمدة قريبة جدًا من بعضها أو متباعدة جدًا؟**

استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseriesgroup/#setGapWidth) على مجموعة السلاسل الأم المناسبة. زد القيمة لتوسيع المسافة بين المجموعات، أو قللها لتقريب المجموعات من بعضها.