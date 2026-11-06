---
title: إدارة تسميات بيانات المخطط في العروض التقديمية باستخدام PHP
linktitle: تسمية البيانات
type: docs
url: /ar/php-java/chart-data-label/
keywords:
- مخطط
- تسمية البيانات
- دقة البيانات
- نسبة مئوية
- مسافة التسمية
- موضع التسمية
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق تسميات بيانات المخطط في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java لإنشاء شرائح أكثر جاذبية."
---
## **المقدمة**

تظهر تسميات البيانات معلومات حول سلاسل المخطط ونقاط البيانات الفردية، مما يساعد القراء على تحديد القيم وفهم المخطط. تشرح هذه المقالة كيفية تنسيق القيم، وعرض النسب المئوية، وقراءة نص التسمية، والتحكم في التسميات التي تتجاوز الحد الأقصى للمحور، وضبط تباعد تسميات محور الفئة، وتحديد موقع تسميات المخطط الدائري.

## **عدد تسميات البيانات الظاهرة**

استخدم [getCountOfVisibleDataLabels](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getcountofvisibledatalabels/) للتحقق من عدد تسميات البيانات التي تم تمكينها للعرض قبل نشر العرض التقديمي. على عكس [getCount](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getcount/)، الذي يُرجع العدد الإجمالي للتسميات في المجموعة، فإنه يأخذ قيم الافتراضيات الخاصة بالسلسلة وإعدادات كل تسمية على حدة في الاعتبار. إن هذا المثال يُنشئ مخططًا عموديًا بسلسلة واحدة وثلاث نقاط بيانات. يصل إلى مجموعة تسميات السلسلة عبر [getLabels](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getlabels/) ويطبع عدد التسميات الظاهرة مع تغير الإعدادات: **0, 3, 2, 3**. ويظل العدد الإجمالي **3**.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesCell = $workbook->getCell(0, 0, 1, "Values");
    $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

    for ($i = 0; $i < 3; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, ($i + 1) * 10);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $labels = $series->getLabels();
    echo "Total: " . java_values($labels->getCount()) . "; visible: " . java_values($labels->getCountOfVisibleDataLabels()) . PHP_EOL; // الإجمالي: 3; الظاهر: 0

    $labels->getDefaultDataLabelFormat()->setShowValue(true);
    echo "Visible: " . java_values($labels->getCountOfVisibleDataLabels()) . PHP_EOL; // الظاهر: 3

    $labels->get_Item(1)->getDataLabelFormat()->setShowValue(false);
    echo "Visible: " . java_values($labels->getCountOfVisibleDataLabels()) . PHP_EOL; // الظاهر: 2

    $labels->get_Item(1)->getDataLabelFormat()->setShowLegendKey(true);
    echo "Visible: " . java_values($labels->getCountOfVisibleDataLabels()) . PHP_EOL; // الظاهر: 3
} finally {
    $presentation->dispose();
}
```
توفر [getDefaultDataLabelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getdefaultdatalabelformat/) للسلسلة الإعدادات الافتراضية. تمرير `true` إلى [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) يعرض القيم لجميع التسميات الثلاث. تمرير `false` عبر [getDataLabelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getdatalabelformat/) لتسمية واحدة يتجاوز ذلك الإعداد للتسمية المحددة. تمرير `true` إلى [setShowLegendKey](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowlegendkey/) يجعل تلك التسمية تُحسب مرة أخرى كظاهرة، رغم أن قيمتها لا تزال مخفية. يعكس عدد التسميات الظاهرة إعدادات الإظهار. ولا يقيس ما إذا كانت التسميات متداخلة أو مقصوصة أو مقروءة في المخطط المُصنّع.

## **ضبط دقة البيانات في تسميات مخطط البيانات**

استخدم [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setnumberformatofvalues/) لتنسيق قيم السلسلة. ينشئ هذا المثال مخططًا خطيًا ببيانات افتراضية، يعرض جدول البيانات الخاص به، ويفعل تسميات القيم للسلسلة الأولى. يعرض التنسيق `#,##0.00` فاصل آلاف ومكانين عشريين دون تغيير القيم الأساسية. ```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->setNumberFormatOfValues("#,##0.00");
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("PrecisionOfDatalabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
``` لتنسيق الخلايا الرقمية في دفتر عمل مدمج بالمخطط، راجع [تعيين تنسيقات أرقام مخصصة لخلايا دفتر العمل](/slides/ar/php-java/chart-workbook/#set-custom-number-formats-for-workbook-cells). يُظهر ذلك المثال أيضًا تسميات القيم التي تتبع تنسيقات الخلايا المصدر مع الحفاظ على القيم الرقمية المخزنة.

## **عرض النسبة المئوية كوسوم**

في مخطط عمودي مكدس، احسب كل قيمة كنسبة مئوية من إجمالي الفئة الخاصة بها وعيّن النص إلى إطار النص الذي تُعيده [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/). يستخدم هذا المثال بيانات المخطط الافتراضية ويعرض النسب المئوية بمكانين عشريين باستخدام خط بحجم 8 نقاط. يتم تخطي الفئات التي إجماليها صفر لتجنب القسمة على الصفر. أعد حساب نص التسمية المخصص إذا تغيرت بيانات المخطط. ```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\Portion;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);

    $categoryCount = java_values($chart->getChartData()->getCategories()->size());
    $categoryTotals = array_fill(0, $categoryCount, 0.0);
    for ($k = 0; $k < $categoryCount; $k++) {
        for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
            $series = $chart->getChartData()->getSeries()->get_Item($i);
            $pointValue = java_values($series->getDataPoints()->get_Item($k)->getValue()->getData());
            $categoryTotals[$k] += $pointValue;
        }
    }

    for ($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()); $x++) {
        $series = $chart->getChartData()->getSeries()->get_Item($x);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);

        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $label = $series->getDataPoints()->get_Item($j)->getLabel();
            if ($categoryTotals[$j] == 0) {
                continue;
            }

            $pointValue = java_values($series->getDataPoints()->get_Item($j)->getValue()->getData());
            $dataPointPercent = ($pointValue / $categoryTotals[$j]) * 100;

            $portion = new Portion();
            $portion->setText(sprintf("%.2F %%", $dataPointPercent));
            $portion->getPortionFormat()->setFontHeight(8);

            $label->getTextFrameForOverriding()->setText("");
            $paragraph = $label->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
            $paragraph->getPortions()->add($portion);

            $label->getDataLabelFormat()->setShowValue(true);
            $label->getDataLabelFormat()->setShowSeriesName(false);
            $label->getDataLabelFormat()->setShowPercentage(false);
            $label->getDataLabelFormat()->setShowLegendKey(false);
            $label->getDataLabelFormat()->setShowCategoryName(false);
            $label->getDataLabelFormat()->setShowBubbleSize(false);
        }
    }

    $presentation->save("DisplayPercentageAsLabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **إضافة علامة النسبة المئوية لتسميات المخطط**

عندما يتم تخزين القيم ككسور، استخدم [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) لعرض النسب المئوية. مرّر `false` إلى [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) لتطبيق تنسيق التسمية بصورة مستقلة عن خلايا المصدر. ينشئ هذا المثال مخطط عمودي مكدس 100% مع سلاسل حمراء وزرقاء عبر أربع فئات. كل زوج من القيم يضيف إلى 1. يعرض تنسيق التسمية `0.0%` القيمة 0.30 كـ 30.0%، بينما يستخدم المحور العمودي مكانين عشريين. كلا السلسلتين يستخدمان نص تسمية أبيض بحجم 10 نقاط. ```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    for ($i = 0; $i < 4; $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    $colors = java("java.awt.Color");
    $seriesNames = [ "Reds", "Blues" ];
    $seriesColors = [ $colors->RED, $colors->BLUE ];
    $values = [ [ 0.30, 0.50, 0.80, 0.65 ], [ 0.70, 0.50, 0.20, 0.35 ] ];

    for ($i = 0; $i < count($seriesNames); $i++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $i + 1, $seriesNames[$i]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());
        for ($j = 0; $j < 4; $j++) {
            $valueCell = $workbook->getCell($worksheetIndex, $j + 1, $i + 1, $values[$i][$j]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        $series->getFormat()->getFill()->setFillType(FillType::Solid);
        $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColors[$i]);

        $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(false);
        $labelFormat->setNumberFormat("0.0%");
        $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(10);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($colors->WHITE);
    }

    $presentation->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **قراءة النص الفعلي لتسميات البيانات**

استخدم [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) لاسترداد النص الناتج عن إعدادات تسمية البيانات. هذا مفيد عند استخراج التسميات للتقارير، أو البحث في محتوى العروض التقديمية، أو التحقق من صحة المخططات المُنشأة. في المثال أدناه، يجمع تنسيق [تنسيق تسمية البيانات](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/) الافتراضي كل من اسم الفئة، واسم السلسلة، والقيمة. نقطة واحدة تنسق قيمتها كنسبة مئوية، وأخرى تستخدم نصًا مخصصًا من [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/). ```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $firstCategoryCell = $workbook->getCell(0, 1, 0, "Q1");
    $chart->getChartData()->getCategories()->add($firstCategoryCell);
    $secondCategoryCell = $workbook->getCell(0, 2, 0, "Q2");
    $chart->getChartData()->getCategories()->add($secondCategoryCell);

    $northSeriesCell = $workbook->getCell(0, 0, 1, "North");
    $north = $chart->getChartData()->getSeries()->add($northSeriesCell, $chart->getType());
    $northFirstValueCell = $workbook->getCell(0, 1, 1, 0.25);
    $north->getDataPoints()->addDataPointForBarSeries($northFirstValueCell);
    $northSecondValueCell = $workbook->getCell(0, 2, 1, 0.75);
    $north->getDataPoints()->addDataPointForBarSeries($northSecondValueCell);

    $southSeriesCell = $workbook->getCell(0, 0, 2, "South");
    $south = $chart->getChartData()->getSeries()->add($southSeriesCell, $chart->getType());
    $southFirstValueCell = $workbook->getCell(0, 1, 2, 0.40);
    $south->getDataPoints()->addDataPointForBarSeries($southFirstValueCell);
    $southSecondValueCell = $workbook->getCell(0, 2, 2, 0.60);
    $south->getDataPoints()->addDataPointForBarSeries($southSecondValueCell);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        $format = $series->getLabels()->getDefaultDataLabelFormat();
        $format->setShowCategoryName(true);
        $format->setShowSeriesName(true);
        $format->setShowValue(true);
    }

    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormat("0%");
    $south->getLabels()->get_Item(0)->getTextFrameForOverriding()->setText("Reviewed");

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $point = $series->getDataPoints()->get_Item($j);
            $label = $point->getLabel();
            if (!java_values($label->isVisible())) {
                continue;
            }

            echo "Value: " . java_values($point->getValue()->getData()) . "; label: " . java_values($label->getActualLabelText()) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
``` يبقى الرقم المخزن في نقطة البيانات `0.75`، حتى عندما تُظهر تسميتها `75%` مع أسماء الفئة والسلسلة. النص المخصص يستبدل نص التسمية المُولد. [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) تُعيد سلسلة التسمية الناتجة في كلتا الحالتين. تحقّق من [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/isvisible/) بشكل منفصل، كما هو موضح أعلاه، عندما تريد استخراج التسميات الظاهرة فقط.

## **التحكم في تسميات البيانات التي تتجاوز الحد الأقصى للمحور**

عند تحديد مجال المحور يدويًا، قد تتجاوز بعض نقاط البيانات قيمته القصوى. استخدم [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setshowdatalabelsovermaximum/) للتحكم فيما إذا كانت تسميات بياناتها تُظهر. هذا الإعداد يغيّر إظهار التسمية؛ لكنه لا يغيّر نطاق المحور أو قيم البيانات الأساسية. ينشئ المثال أدناه مخططًا عموديًا مجموعًا ثنائي الأبعاد بقيم 60 و120. يمرّر `false` إلى [setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmaxvalue/) ويضبط الحد الأقصى إلى 100 باستخدام [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmaxvalue/) على المحور العمودي. الشريحة الأولى تسمح بالتسميات التي تتجاوز الحد الأقصى؛ نسخة من تلك الشريحة تعطلها. كلا الشريحتين تم حفظهما في `DataLabelsOverMaximum.pptx`. فعّل تسميات القيم باستخدام [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/). إعداد مستوى المخطط لا يُفعّل عرض القيم بحد ذاته ولا يتجاوز إلغاء عرض القيمة لتسمية فردية. يمكّن هذا المثال القيم لكامل السلسلة ويستخدم [setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setposition/) لوضع التسميات في الطرف الخارجي لكل عمود. ```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $firstCategory = $workbook->getCell(0, 1, 0, "Within range");
    $secondCategory = $workbook->getCell(0, 2, 0, "Above maximum");

    $chart->getChartData()->getCategories()->add($firstCategory);
    $chart->getChartData()->getCategories()->add($secondCategory);

    $seriesName = $workbook->getCell(0, 0, 1, "Values");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());

    $firstValue = $workbook->getCell(0, 1, 1, 60);
    $secondValue = $workbook->getCell(0, 2, 1, 120);

    $series->getDataPoints()->addDataPointForBarSeries($firstValue);
    $series->getDataPoints()->addDataPointForBarSeries($secondValue);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);

    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(100);
    $chart->setShowDataLabelsOverMaximum(true);

    $secondSlide = $presentation->getSlides()->addClone($slide);
    $secondChart = $secondSlide->getShapes()->get_Item(0);
    $secondChart->setShowDataLabelsOverMaximum(false);

    $presentation->save("DataLabelsOverMaximum.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
``` تُظهر الصور التالية الشرائح المحفوظة التي تم عرضها بواسطة Microsoft PowerPoint. عند استخدام `true`، تكون التسمية **120** مرئية عند الحد العلوي؛ وعند استخدام `false`، تكون مخفية. تظل التسمية **60** مرئية، ويبقى الحد الأقصى للمحور عند **100**، وتظل نقطة البيانات الثانية **120** في كلتا الحالتين.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
يستخدم هذا المثال مخططًا عموديًا ثنائي الأبعاد مع محور قيم. المخططات التي لا تحتوي على محور قيم، مثل المخططات الدائرية ومخططات الدونات، لا تملك حدًا أقصى للمحور لتقييده بهذه الطريقة.
{{% /alert %}}

## **تحديد مسافة التسمية عن المحور**

استخدم [setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlabeloffset/) للتحكم في المسافة بين تسميات محور الفئة والمحور. القيمة هي نسبة مئوية من الحد الأقصى لحجم خط تسميات المحور. ينشئ هذا المثال مخططًا عموديًا مجموعًا ويضبط إزاحة تسميات المحور الأفقي إلى 500. يؤثر هذا الإعداد على تسميات محور الفئة بدلاً من التسميات المرتبطة بنقاط البيانات الفردية. ```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $chart->getAxes()->getHorizontalAxis()->setLabelOffset(500);

    $presentation->save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ضبط موقع التسمية**

في مخطط دائري، اضبط مواضع تسميات البيانات لتحسين التباعد وإتاحة مساحة لخطوط الربط. يعرض هذا المثال قيمة نقطة البيانات الأولى، يضع تسميتها خارج الشريحة، ويضبط إزاحتها الأفقية والعمودية باستخدام [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) و[setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/). هذه الإزاحات نسبية إلى عرض المخطط وارتفاعه على التوالي. ```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();

    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
![مخطط دائري مع موضع تسمية بيانات معدل](pie-chart-adjusted-label.png)

## **تنسيق خطوط الربط**

عندما تكون تسميات المخطط الدائري خارج الشرائح، تساعد خطوط الربط القارئ على مطابقة كل قيمة مع الشريحة الصحيحة. يمكن للون المتباين وخط سميك قليلاً أن يجعل هذه الروابط أسهل في المتابعة، بينما الشفافية والنمط المتقطع يجعلان الخطوط غير ملحوظة بصريًا. استخدم [getLeaderLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getleaderlinesformat/) لتنسيق خطوط الربط على مستوى مجموعة تسميات البيانات للسلسلة. الإعدادات في `$series->getLabels()->getLeaderLinesFormat()->getLine()` تُطبق على المجموعة، بدلاً من تسمية فردية. ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية، يعرض القيم خارج الشرائح، ويفعل [setShowLeaderLines](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowleaderlines/). ينقل التسميتين بعيدًا عن الشرائح باستخدام إزاحات [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) و[setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/)، معبرًا عنها كسُكّات من عرض وارتفاع المخطط. لا يتطلب تقديم عرض تقديمي كمدخل. تحدد [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) للخط لونًا أزرق صلبًا بقيمة ألفا 191 من 255، مما يمنح شفافية تقريبية بنسبة 25%. [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) يضبط السمك إلى 2 نقطة، و[setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) يجعل الخط متقطعًا. ```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 80, 50, 560, 400);
    $chart->setLegend(false);

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
    $labelFormat->setShowValue(true);
    $labelFormat->setPosition(LegendDataLabelPosition::OutsideEnd);
    $labelFormat->setShowLeaderLines(true);

    // نقل تسميتين بعيدًا أكثر عن شرائحهما.
    $series->getLabels()->get_Item(0)->setX(0.10);
    $series->getLabels()->get_Item(0)->setY(-0.05);
    $series->getLabels()->get_Item(1)->setX(-0.10);
    $series->getLabels()->get_Item(1)->setY(0.05);

    $line = $series->getLabels()->getLeaderLinesFormat()->getLine();
    $line->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 30, 90, 160, 191);
    $line->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $line->setWidth(2);
    $line->setDashStyle(LineDashStyle::Dash);

    $presentation->save("FormattedLeaderLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
``` تفعيل خطوط الربط لا يضمن ظهور خط لكل تسمية. الإظهار يعتمد على وضعية التسمية وسلوك تخطيط المخطط. في هذا المثال، لدى التسميتين المنقولتين خطوط ربط مرئية؛ التسميات التي تبقى قريبة من شرائحها لا تحتاجها. الصورة التالية تُظهر ملف `FormattedLeaderLines.pptx` المحفوظ المُصوَّر باستخدام Aspose.Slides: ![مخطط دائري بخطوط ربط زرقاء، شبه شفافة ومقطعة، تربط تسميتين خارجيتين بشرائحهما](formatted-leader-lines.png)

## **إضافة عدة صفوف من تسميات البيانات فوق مخطط عمودي**

ينشئ هذا المثال مخططًا عموديًا مع صفين من تسميات البيانات فوق مساحة الرسم. السلسلة A تعرض الأعمدة الظاهرة، بينما السلسلتان B وC توفران التسميات الإضافية. أعمدتهم مخفية بعملية إزالة التعبئة والحد. طريقة [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) تُحاذِ الـ3 سلاسل إلى نفس مراكز الفئات. إعدادات [ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) تحجز مساحة لصفوف التسميات. بعد أن تحسب [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) المواضع الافتراضية، تحتفظ [DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) و[DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) بالمحاذاة الأفقية وتطبق إزاحات رأسية لترتيب التسميات في صفين. تظل الأرقام تسميات بيانات مرتبطة بقيم السلسلة؛ فقط عناوين الصفوف هي أشكال نصية منفصلة. ```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\LayoutTargetType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$colors = java("java.awt.Color");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 40, 40, 640, 200);
    $chart->setTitle(false);
    $chart->setLegend(false);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(12);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categories = [ "North", "South", "East", "West" ];
    $seriesNames = [ "Series A", "Series B", "Series C" ];
    $seriesValues = [
        [ 35, 42, 28, 47 ],
        [ 22, 31, 19, 26 ],
        [ 12, 16, 14, 18 ]
    ];
    
    for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
        $categoryCell = $workbook->getCell(0, $categoryIndex + 1, 0, $categories[$categoryIndex]);
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $seriesCell = $workbook->getCell(0, 0, $seriesIndex + 1, $seriesNames[$seriesIndex]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, ChartType::ClusteredColumn);

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $valueCell = $workbook->getCell(0, $categoryIndex + 1, $seriesIndex + 1, $seriesValues[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        if ($seriesIndex > 0) {
            // إخفاء أعمدة B و C، مع الحفاظ على تسميات البيانات الخاصة بهما.
            $series->getFormat()->getFill()->setFillType(FillType::NoFill);
            $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
            $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
            $labelFormat->setShowValue(true);
            $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(12);
            $labelFill = $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
            $labelFill->setFillType(FillType::Solid);
            $labelFill->getSolidFillColor()->setColor($colors->BLACK);
            $labelFormat->setPosition(LegendDataLabelPosition::InsideBase);
        }
    }

    // محاذاة السلاسل الثلاثة مع مراكز الفئات نفسها.
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // استخدام خطوط شبكية أقل لهذا المثال المدمج.
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // حجز مساحة فوق منطقة الرسم لصفين من تسميات البيانات.
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $chart->getPlotArea()->setX(0.15);
    $chart->getPlotArea()->setY(0.32);
    $chart->getPlotArea()->setWidth(0.80);
    $chart->getPlotArea()->setHeight(0.48);
    $chart->validateChartLayout();

    $chartX = java_values($chart->getX());
    $chartY = java_values($chart->getY());
    $chartHeight = java_values($chart->getHeight());
    for ($seriesIndex = 1; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $rowTop = $seriesIndex == 1 ? 0.15 : 0.03;

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $dataLabel = $series->getDataPoints()->get_Item($categoryIndex)->getLabel();
            // الاحتفاظ بالموضع الأفقي الافتراضي. Y هو إزاحة من
            // موضع التسمية الافتراضي، معبرًا عنه ككسر من ارتفاع المخطط.
            $actualY = java_values($dataLabel->getActualY());
            $dataLabel->setX(0);
            $dataLabel->setY($rowTop - $actualY / $chartHeight);
        }

        // فقط عنوان الصف هو شكل نص منفصل.
        $rowHeading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $chartX, $chartY + $rowTop * $chartHeight, 85, 18);
        $rowHeading->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->addTextFrame($seriesNames[$seriesIndex]);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginTop(0);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginBottom(0);
        $headingFormat = $rowHeading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $headingFormat->setFontHeight(12);
        $headingFormat->getFillFormat()->setFillType(FillType::Solid);
        $headingFormat->getFillFormat()->getSolidFillColor()->setColor($colors->BLACK);
    }

    $presentation->save("multiple-rows-of-labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
![مخطط عمودي مع صفين من تسميات البيانات فوق مساحة الرسم](multiple-rows-of-labels.png)

## **الأسئلة المتكررة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات الكثيفة؟**  
اجمع بين وضعية التسميات التلقائية، وخطوط الربط، وتقليل حجم الخط؛ إذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض التسميات فقط للقيم المتطرفة أو النقاط الرئيسية.

**كيف يمكنني تعطيل التسميات للقيم الصفرية أو السلبية أو الفارغة فقط؟**  
قم بترشيح نقاط البيانات قبل تمكين التسميات وأوقف العرض للقيم الصفرية أو السلبية أو القيم المفقودة وفق قاعدة محددة.

**كيف يمكنني ضمان نمط تسمية موحد عند التصدير إلى PDF/صور؟**  
حدد صراحةً عائلة الخط وحجمه وتأكد من توفر الخط في بيئة التصيير لتجنب الاعتماد على خط بديل.