---
title: إدارة بيانات سلاسل المخططات في العروض التقديمية بلغة PHP
linktitle: سلاسل البيانات
type: docs
url: /ar/php-java/chart-series/
keywords:
- سلاسل المخطط
- تداخل السلسلة
- لون السلسلة
- اسم السلسلة
- نقطة البيانات
- خلية دفتر العمل
- فجوة السلسلة
- قيمة سلبية
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا دفتر العمل، التنسيق، التداخل، عرض الفجوة، والقيم السلبية في العروض التقديمية باستخدام PHP."
---
## **نظرة عامة**

يخزن المخطط بياناته المرسومة في دفتر بيانات المخطط. تمثل [ChartSeries](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/) مجموعة واحدة من القيم المرتبطة، وتشير كل [ChartDataPoint](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/) في السلسلة إلى خلية أو أكثر في دفتر العمل. توفر كائنات [ChartCategory](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. وبالتالي يتم ربط اسم السلسلة والفئات وقيم النقاط بـ [ChartDataCell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/) بدلاً من تخزينها كنص عرض فقط.

بالنسبة إلى مخطط فئات نموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، وتُملأ الخلايا المتبقية قيم السلاسل. الفهارس الخاصة بورقة العمل والصف والعمود التي تُمرّر إلى [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/#getCell) تبدأ من الصفر. هذا التخطيط مفيد عند إنشاء مخطط ببيانات افتراضية، لكن لا يجب افتراض أن كل مخطط موجود يستخدمه. بالنسبة إلى عرض تقديمي تم تحميله، افحص الخلايا التي تشير إليها السلاسل والفئات ونقاط البيانات قبل تعديل قيم دفتر العمل.

إعدادات المخطط لها ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [ChartSeries.getFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getFormat)، توفّر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات نقطة البيانات، مثل [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/#getFormat)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تنطبق على السلاسل المتوافقة التي تنتمي إلى نفس [ChartSeriesGroup](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseriesgroup/). يمكن الوصول إلى المجموعة عبر [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getParentSeriesGroup) عندما تحتاج إلى ضبط خيارات مثل التداخل أو عرض الفجوة.

عند عدم تعيين تعبئة صريحة للنقطة أو للسلسلة، يحدد نمط المخطط والموضوع المظهر التلقائي. عندما تكون كل من تنسيقات السلسلة والنقطة موجودة، تتفوّق تنسيق النقطة لتلك النقطة.

![سلسلة المخطط في PowerPoint](chart-series-powerpoint.png)

## **تعيين تداخل سلسلة المخطط**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getOverlap) يُظهر مقدار تداخل الأشرطة أو الأعمدة في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمئة. هو إسقاط للقراءة فقط للإعداد على مجموعة السلسلة الأصلية. استخدم [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseriesgroup/#setOverlap) لتحديث كل السلاسل المتوافقة في تلك المجموعة. ينطبق هذا الخيار على أنواع المخططات التي تُظهر أشرطة أو أعمدة مُجَمّعة؛ ولا يؤثر على مجموعات السلاسل غير المرتبطة في مخطط مركب.

المثال التالي يحدد التداخل للمجموعة التي تحتوي على السلسلة الأولى:

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

استخدم [ChartSeries.getFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getFormat) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كانت النقطة لديها تعبئة صريحة، فإن إعداد [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/#getFormat) يتجاوز تعبئة السلسلة لتلك النقطة.

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

يُخزن اسم السلسلة في دفتر بيانات المخطط ويُعرض عادةً في المفتاح. في دفتر العمل الافتراضي المُنشأ لمخطط عمود مُجمّع، تكون الخلية B1 في الصف 0 والعمود 1 وتحتوي على اسم السلسلة الأولى. المتغيّرات المسماة في المثال التالي تجعل هذا الهيكل واضحًا:

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

يمكنك أيضًا تحديث الخلية التي يشير إليها [ChartSeries.getName](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getName). يمنع هذا النهج الافتراض بوجود صف أو عمود معين في مخطط موجود:

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

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) يُعيد اللون المُحسوب بناءً على فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا تُحدَّد تعبئة السلسلة صراحةً. استدعاء الطريقة يقرأ اللون المحسوب؛ لا يُعيّن تعبئة جديدة.

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

مثال على الإخراج للنمط الافتراضي للمخطط:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين عكس لون التعبئة لسلسلة المخطط**

بالنسبة إلى سلاسل الأشرطة، الأعمدة، والفقاعات، يمكن لـ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#setInvertIfNegative) عرض القيم السالبة بتعبئة مختلفة. عيّن تعبئة السلسلة العادية إلى صلبة، فعّل العكس، وعيّن لون القيمة السالبة عبر [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). تظل الأرقام السالبة دون تغيير في دفتر العمل؛ يتغيّر فقط لون العرض.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. يحتوي صف ورقة العمل 0 على اسم السلسلة، والعمود 0 على أسماء الفئات، والعمود 1 على القيم:

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

![لون التعبئة الصلب المعكوس](inverted_solid_fill_color.png)

يمكنك تفعيل العكس لنقطة واحدة عبر [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). في المثال التالي يتم إلغاء العكس للسلسلة وتفعيله فقط للنقطة المحددة. تُعطى النقطة أيضًا قيمة سالبة لتظهر التأثير:

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

لجعل نقطة واحدة فارغة دون إزالة باقي النقاط، عيّن خلية دفتر العمل الداعمة لها إلى `null`. بالنسبة إلى مخطط عمودي، القيمة المرسومة متاحة عبر [ChartDataPoint.getValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/#getValue). تظل نقطة البيانات في نفس موقع الفئة، لكن المخطط يتعامل مع قيمتها كفراغ وفقًا لإعدادات القيم الفارغة للمخطط.

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

تستخدم مخططات المتناثرة خلايا X وY منفصلة، وتضيف مخططات الفقاعات خلية الحجم. امسح فقط الخلية التي تمثل القيمة التي تريد إزالتها. لا تستدعِ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapointcollection/#clear) عندما تريد الحفاظ على باقي النقاط، لأن هذه الطريقة تزيل جميع نقاط البيانات من المجموعة.

## **التحكم في عرض الخلايا الفارغة**

خلية دفتر العمل الفارغة تمثّل بيانات مفقودة؛ الخلية التي تحتوي على `0` تمثّل قيمة عددية معروفة. استدعِ [ChartDataCell::setValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/#setValue) مع `null` لجعل الخلية فارغة. الصفر الرقمي يظل صفرًا بغض النظر عن إعداد الخلية الفارغة.

استخدم [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/#setDisplayBlanksAs) لتحديد كيفية عرض المخطط للخلايا الفارغة. ينطبق هذا الإعداد على المخطط بأكمله. وهو يغيّر طريقة رسم الفواصل دون ملء الخلية الفارغة بصفر أو قيمة مُقربة.

المثال الذاتي التالي ينشئ مخطط خط بسلسلة واحدة، يمسح القيمة لليوم 3، ويحفظ المخطط نفسه بكل وضع. لا حاجة إلى ملف إدخال. يستخدم [ChartDataWorkbook](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/) ورقة العمل 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحتفظ باسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

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

    // اترك اليوم 3 فارغًا فعليًا، مع الحفاظ على فئته ونقطة البيانات الخاصة به.
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

كل ملف ناتج يُخزّن الوضع المحدد قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و `empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض التقديمي مرة واحدة بدلًا من التكرار على الأوضاع.

المقارنة أدناه تُظهر نفس البيانات في جميع الملفات الثلاثة. اليوم 3 فارغ في دفتر العمل في كل حالة:

![مخططات الخط ذات البيانات المتطابقة: الفجوة تقطع الخط في اليوم 3، الصفر يُسقط الخط إلى الصفر، والامتداد يربط اليوم 2 باليوم 4.](display_blanks_as.png)

التأثير المرئي يعتمد على نوع المخطط. مخطط الخط يجعل مقارنة الأوضاع الثلاثة سهلة. مخططات الأشرطة والأعمدة لا تحتوي على خط لتوصيل الفواصل، لذا لا يمكن لـ `Span` إنتاج الجزء المتصل المعروض أعلاه؛ كما أن العمود المفقود والعمود صفر الارتفاع قد يظهران متشابهي اللون. بالمثل، مخطط المتناثر مع العلامات فقط لا يحتوي على خط موصل. لا تتوقع ثلاث نتائج متميزة لكل نوع مخطط؛ تحقق من الناتج للنوع الذي تستخدمه.

## **تعيين عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأشرطة أو الأعمدة المتجاورة، تُعبر كنسبة مئوية من عرض الشريط أو العمود. مثل التداخل، يخص مجموعة السلسلة الأصلية وليس سلسلة واحدة. استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseriesgroup/#setGapWidth) مرة واحدة للمجموعة. قيمة أكبر تُنشئ مساحة أكبر بين المجموعات؛ وقيمة أصغر تجعلها أكثر كثافة.

المثال التالي يُغيّر عرض الفجوة ويحفظ العرض التقديمي النهائي فقط:

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

## **أسئلة شائعة**

**ما أنواع المخططات التي تدعم سلاسل البيانات؟**

جميع أنواع المخططات المُمثلة في تعداد [ChartType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/charttype/) تُستخدم بيانات المخطط، لكن سلاسلها لا تشترك جميعًا في هيكل القيم أو الإعدادات نفسها. على سبيل المثال، مخططات الفئات تستخدم الفئات والقيم، ومخططات المتناثر تستخدم قيم X وY، ومخططات الفقاعات تُضيف أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. خيارات مثل التداخل وعرض الفجوة تنطبق فقط على مجموعات الأشرطة أو الأعمدة المتوافقة.

**ما هو مجموعة سلسلة المخطط؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseriesgroup/) يحتوي على سلاسل متوافقة تشترك في إعدادات الرسم على مستوى المجموعة. يمكن لمخطط مركب أن يحتوي على أكثر من مجموعة، لذا تغيير المجموعة عبر سلسلة واحدة لا يغيّر بالضرورة كل السلاسل في المخطط.

**هل يحتوي المخطط الجديد على بيانات افتراضية؟**

نعم. بشكل افتراضي، يُنشئ [ShapeCollection.addChart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/#addChart) سلاسل، فئات، وقيم نموذجية. يمكنك تعديل تلك الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة بالكامل. يمكن أيضًا استدعاء نسخة متجاوزة لإنشاء مخطط دون بيانات افتراضية.

**كيف يتم ربط كائنات المخطط بخلايا دفتر العمل؟**

أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات تشير إلى خلايا في [ChartDataWorkbook](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/). تعديل خلية مُشار إليها يحدّث العنصر المقابل في المخطط. عند بناء بيانات مخصّصة، احرص على محاذاة صفوف الفئات وصفوف قيم السلاسل بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أمسح نقطة واحدة بدلًا من السلسلة بالكامل؟**

عيّن خلية القيمة ذات الصلة إلى `null` لتبقى النقطة في موقع فئتها كنقطة فارغة. استخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapointcollection/#clear) فقط عندما تريد إزالة جميع النقاط من تلك السلسلة. إذا قمت أيضًا بإزالة الفئات، حدِّث كل السلاسل بحيث تظل قيمها مُحاذاة مع مجموعة الفئات.

**كيف يُعرض النقاط الفارغة؟**

النتيجة تعتمد على نوع المخطط والقيمة المُعَدَّة عبر [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/#setDisplayBlanksAs). يمكن للمخططات المدعومة عرض الفراغات كفجوات أو كقيمة صفرية أو بربط النقاط المجاورة. اختر الإعداد الذي يتماشى مع معنى البيانات المفقودة في عرضك. راجع [التحكم في عرض الخلايا الفارغة](#control-the-display-of-empty-cells) للحصول على مثال كامل ومقارنة مرئية.

**كيف يتم تنسيق القيم السالبة؟**

بالنسبة إلى سلاسل الأشرطة، الأعمدة، والفقاعات المدعومة، استدعِ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#setInvertIfNegative) واستخدم اللون المُرتجع من [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). يمكنك تجاوز السلوك لنقطة فردية عبر [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). هذه الطرق تؤثر على التنسيق فقط، ولا تُغيّر القيم الرقمية المخزّنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

التنسيق الصريح للنقطة يتفوّق لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، إذا لم يُحدَّد تنسيق السلسلة، النمط والموضوع التلقائي للمخطط. إعدادات المجموعة مثل التداخل وعرض الفجوة تتحكم في التخطيط ولا تُعتبر تجاوزًا لتنسيق النقطة.

**هل هناك حد لعدد السلاسل التي يمكن للمخطط احتواؤها؟**

Aspose.Slides لا يفرض حدًا ثابتًا منفصلًا لعدد السلاسل. عمليًا، تُحدّد قيود ملف العرض، الذاكرة المتاحة، زمن المعالجة، وقابلية قراءة المخطط حدًا عمليًا.

**ماذا أفعل عندما تكون الأعمدة متقاربة جدًا أو متباعدة جدًا؟**

استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartseriesgroup/#setGapWidth) على مجموعة السلسلة الأصلية المناسبة. زد القيمة لتوسيع الفجوة بين المجموعات، أو قللها لتقريب المجموعات من بعضها.