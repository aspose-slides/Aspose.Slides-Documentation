---
title: مدیریت برچسب‌های داده نمودار در ارائه‌ها با استفاده از PHP
linktitle: برچسب داده
type: docs
url: /fa/php-java/chart-data-label/
keywords:
- نمودار
- برچسب داده
- دقت داده
- درصد
- فاصله برچسب
- موقعیت برچسب
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌های داده نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای PHP از طریق Java اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **مقدمه**

برچسب‌های داده اطلاعاتی درباره‌ٔ سری‌های نمودار و نقاط داده‌ی جداگانه نمایش می‌دهند و به خوانندگان کمک می‌کنند تا مقادیر را شناسایی و نمودار را درک کنند. این مقاله توضیح می‌دهد که چگونه مقادیر را قالب‌بندی کنید، درصدها را نمایش دهید، متن برچسب را بخوانید، برچسب‌ها را فراتر از حداکثر محور کنترل کنید، فاصله برچسب‌های محور دسته‌بندی را تنظیم کنید و موقعیت برچسب‌های نمودار دایره‌ای را تعیین کنید.

## **تنظیم دقت داده‌ها در برچسب‌های دادهٔ نمودار**

از [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setnumberformatofvalues/) برای قالب‌بندی مقادیر سری‌ها استفاده کنید. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند، جدول داده‌های آن را نمایش می‌دهد و برچسب‌های مقدار را برای اولین سری فعال می‌کند. قالب `#,##0.00` جداکنندهٔ هزارگان و دو رقم اعشار را بدون تغییر مقادیر پایه نمایش می‌دهد.

```php
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
```

## **نمایش درصد به عنوان برچسب‌ها**

برای یک نمودار ستونی انباشته، هر مقدار را به عنوان درصدی از مجموع دسته‑آن محاسبه کنید و متن را به چارچوب متن برگردانده‌شده توسط [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/) اختصاص دهید. این مثال از داده‌های پیش‌فرض نمودار استفاده می‌کند و درصدها را با دو رقم اعشار در قلم 8 نقطه‌ای نمایش می‌دهد. دسته‌هایی که مجموعشان صفر است برای جلوگیری از تقسیم بر صفر حذف می‌شوند. اگر داده‌های نمودار تغییر کنند متن برچسب سفارشی را دوباره محاسبه کنید.

```php
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

## **تنظیم علامت درصد با برچسب‌های دادهٔ نمودار**

زمانی که مقادیر به صورت کسر ذخیره می‌شوند، از [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) برای نمایش درصدها استفاده کنید. `false` را به [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) بفرستید تا قالب برچسب به‌صورت مستقل از سلول‌های منبع اعمال شود.

این مثال یک نمودار ستونی 100٪ انباشته با سری‌های قرمز و آبی در چهار دسته ایجاد می‌کند. هر جفت مقدار جمعاً برابر 1 است. قالب برچسب `0.0%` مقدار 0.30 را به‌صورت 30.0٪ نمایش می‌دهد، در حالی که محور عمودی از دو رقم اعشار استفاده می‌کند. هر دو سری از متن برچسب سفید با اندازه 10 نقطه استفاده می‌کنند.

```php
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

## **خواندن متن واقعی برچسب‌های داده**

از [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) برای دریافت متنی که تنظیمات یک برچسب داده تولید می‌کند استفاده کنید. این روش زمانی مفید است که برای گزارش‌ها برچسب‌ها استخراج شوند، محتوای ارائه جستجو شود یا نمودارهای تولیدی اعتبارسنجی شوند. در مثال زیر، قالب پیش‌فرض [data label format](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/) نام هر دسته، نام سری و مقدار را ترکیب می‌کند. یک نقطه مقدارش را به‌صورت درصد قالب‌بندی می‌کند و نقطهٔ دیگر از متن سفارشی‌ دریافت‌شده توسط [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/) استفاده می‌کند.

```php
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
```

عدد ذخیره‌شده در یک نقطه داده همان `0.75` می‌ماند، حتی زمانی که برچسب آن `75%` به همراه نام دسته و سری نشان می‌دهد. متن سفارشی متن برچسب تولیدشده را جایگزین می‌کند. [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) در هر دو حالت رشتهٔ برچسب نهایی را برمی‌گرداند. برای استخراج تنها برچسب‌های قابل مشاهده، همان‌طور که در بالا نشان داده شد، [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/isvisible/) را به‌طور جداگانه بررسی کنید.

## **کنترل برچسب‌های داده فراتر از حداکثر محور**

زمانی که محدودهٔ محور را به‌صورت دستی محدود می‌کنید، ممکن است برخی نقاط داده از حداکثر آن فراتر بروند. از [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setshowdatalabelsovermaximum/) برای کنترل اینکه آیا برچسب‌های دادهٔ آن‌ها نمایش داده شوند یا نه استفاده کنید. این تنظیم فقط دیدگاه برچسب را تغییر می‌دهد؛ محدودهٔ محور یا مقادیر داده‌های زیرین را تغییر نمی‌دهد.

مثال زیر یک نمودار ستونی خوشه‌ای دو‑بعدی با مقادیر 60 و 120 ایجاد می‌کند. `false` را به [setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmaxvalue/) می‌فرستید و حداکثر را روی محور عمودی به‌وسیلهٔ [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmaxvalue/) بر روی 100 تنظیم می‌کند. اسلاید اول اجازهٔ نمایش برچسب‌ها فراتر از حداکثر را می‌دهد؛ یک کپی از آن اسلاید این قابلیت را غیرفعال می‌کند. هر دو اسلاید در `DataLabelsOverMaximum.pptx` ذخیره می‌شوند.

برچسب‌های مقدار را با [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) فعال کنید. تنظیم سطح نمودار به‌تنهایی نمایش مقدار را فعال نمی‌کند و نیز برچسب‌های فردی که نمایش مقدارشان غیرفعال شده است، بازنویسی نمی‌کند. این مثال مقادیر را برای تمام سری فعال می‌کند و از [setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setposition/) برای قرار دادن برچسب‌ها در انتهای خارجی هر ستون استفاده می‌کند.

```php
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
```

تصاویر زیر اسلایدهای ذخیره‌شدهٔ رندر شده توسط Microsoft PowerPoint را نشان می‌دهند. با `true` برچسب **120** در مرز بالایی قابل مشاهده است؛ با `false` مخفی می‌شود. برچسب **60** قابل مشاهده می‌ماند، حداکثر محور در **100** ثابت می‌ماند و نقطهٔ دادهٔ دوم در هر دو حالت **120** می‌ماند.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 نشان می‌دهد](data-labels-over-maximum-true.png) | ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 مخفی می‌کند](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
این مثال از یک نمودار ستونی دو‑بعدی با محور مقدار استفاده می‌کند. نمودارهایی که محور مقدار ندارند، مانند نمودارهای دایره‌ای و دونات، حداکثر محوری برای محدود کردن به این شکل ندارند.
{{% /alert %}}

## **تنظیم فاصله برچسب از محور**

از [setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlabeloffset/) برای کنترل فاصله بین برچسب‌های محور دسته‌بندی و محور استفاده کنید. مقدار به‌صورت درصدی از حداکثر اندازهٔ قلم برچسب‌های محور است. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و فاصلهٔ برچسب محور افقی را روی 500 تنظیم می‌کند. این تنظیم برچسب‌های محور دسته‌بندی را تحت تأثیر قرار می‌دهد نه برچسب‌های متصل به نقاط دادهٔ جداگانه.

```php
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

## **تنظیم موقعیت برچسب**

در یک نمودار دایره‌ای، موقعیت برچسب‌های داده را برای بهبود فضا و ایجاد جایگاه برای خطوط راهنما تنظیم کنید.

این مثال مقدار اولین نقطه داده را نمایش می‌دهد، برچسب آن را در خارج از برش قرار می‌دهد و افست‌های افقی و عمودی آن را با استفاده از [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) و [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) تنظیم می‌کند. این افست‌ها به‌ ترتیب نسبت به عرض و ارتفاع نمودار هستند.

```php
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

![نمودار دایره‌ای با موقعیت برچسب داده تنظیم‌شده](pie-chart-adjusted-label.png)

## **قالب‌بندی خطوط راهنما**

زمانی که برچسب‌های نمودار دایره‌ای در خارج از برش‌هایشان قرار می‌گیرند، خطوط راهنما به خوانندگان کمک می‌کند تا هر مقدار را به برش صحیح مربوط کنند. یک رنگ متضاد و خط کمی ضخیم‌تر می‌تواند این ارتباطات را پیگیری‌پذیرتر کند، در حالی که شفافیت و سبک خط چین خطوط را به‌صورت بصری کمتر مشهود می‌سازد.

از [getLeaderLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getleaderlinesformat/) برای قالب‌بندی خطوط راهنما در سطح مجموعهٔ برچسب‌های دادهٔ سری استفاده کنید. تنظیمات موجود در `$series->getLabels()->getLeaderLinesFormat()->getLine()` به مجموعه اعمال می‌شود، نه به یک برچسب منفرد.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند، مقادیر را در خارج از برش‌ها نمایش می‌دهد و [setShowLeaderLines](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowleaderlines/) را فعال می‌کند. دو برچسب را با استفاده از افست‌های [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) و [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) که به‌صورت کسری از عرض و ارتفاع نمودار بیان شده‌اند، دورتر از برش‌هایشان می‌برد. ارائهٔ ورودی موردنیاز نیست.

خط `[getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/)` یک رنگ آبی ثابت با مقدار آلفای 191 از 255 تنظیم می‌کند که تقریباً 25٪ شفافیت دارد. [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) ضخامت را به 2 نقطه تنظیم می‌کند و [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) خط را خط‌چین می‌کند.

```php
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

    // دو برچسب را دورتر از برش‌هایشان جابه‌جا کنید.
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
```

فعال‌سازی خطوط راهنما تضمین نمی‌کند که برای هر برچسب یک خط ظاهر شود. قابل رؤیت بودن بستگی به موقعیت برچسب و رفتار چیدمان نمودار دارد. در این مثال، دو برچسب جابجا شده خطوط راهنمای قابل رؤیتی دارند؛ برچسب‌هایی که نزدیک به برش‌هایشان می‌مانند نیازی به آن‌ها ندارند.

تصویر زیر فایل ذخیره‌شدهٔ `FormattedLeaderLines.pptx` رندر شده با Aspose.Slides را نشان می‌دهد:

![نمودار دایره‌ای با خطوط راهنمای آبی، نیمه‌شفاف و خط‌چین که دو برچسب خارج را به قطعاتشان متصل می‌کند](formatted-leader-lines.png)

## **افزودن چندین ردیف برچسب داده بالا روی نمودار ستونی**

این مثال یک نمودار ستونی با دو ردیف برچسب داده بالا روی ناحیهٔ ترسیم ایجاد می‌کند. سری A ستون‌های قابل مشاهده را نمایش می‌دهد، در حالی که سری B و C برچسب‌های اضافی را فراهم می‌کنند. ستون‌های آن‌ها با حذف پرکردن و حاشیه مخفی می‌شوند. روش [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) تمام سه سری را با مرکزهای دسته‌ای یکسان هم‌راستا می‌کند.

تنظیمات [ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) فضایی برای ردیف‌های برچسب رزرو می‌کند. پس از اینکه [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) موقعیت‌های پیش‌فرض را محاسبه کرد، [DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) و [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) تراز افقی را حفظ می‌کنند و افست‌های عمودی را برای ترتیب برچسب‌ها در دو ردیف اعمال می‌نمایند. اعداد همچنان برچسب‌های دادهٔ پیوندشده به مقادیر سری‌ها باقی می‌مانند؛ فقط سرفصل‌های ردیف به‌صورت شکل‌های متنی جداگانه هستند.

```php
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
            // ستون‌های B و C را مخفی کنید، اما برچسب‌های دادهٔ آن‌ها را نگه دارید.
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

    // همهٔ سه سری را با مراکز دسته‌بندی یکسان تراز کنید.
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // برای این مثال فشرده از خطوط شبکهٔ کمتر استفاده کنید.
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // فضای بالای ناحیهٔ نمودار را برای دو ردیف برچسب داده رزرو کنید.
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
            // موقعیت افقی پیش‌فرض را نگه دارید. Y یک افست از
            // موقعیت پیش‌فرض برچسب است که به‌صورت کسری از ارتفاع نمودار بیان می‌شود.
            $actualY = java_values($dataLabel->getActualY());
            $dataLabel->setX(0);
            $dataLabel->setY($rowTop - $actualY / $chartHeight);
        }

        // فقط عنوان ردیف یک شکل متنی جداگانه است.
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

![نمودار ستونی با دو ردیف برچسب داده بالا روی ناحیهٔ ترسیم](multiple-rows-of-labels.png)

## **سوالات متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای پرتراکم جلوگیری کنم؟**

از ترکیب قرارگیری خودکار برچسب‌ها، خطوط راهنما و کاهش اندازهٔ قلم استفاده کنید؛ در صورت نیاز، برخی فیلدها (به عنوان مثال، دسته‌بندی) را مخفی کنید یا تنها برچسب‌ها را برای مقادیر انتهایی یا نقاط کلیدی نمایش دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

نقاط داده را قبل از فعال‌سازی برچسب‌ها فیلتر کنید و نمایش مقادیر صفر، مقادیر منفی یا مقادیر گمشده را بر اساس قاعده‌ای تعریف‌شده غیرفعال کنید.

**چگونه می‌توانم سبک برچسب را هنگام خروجی گرفتن به PDF/تصاویر ثابت نگه دارم؟**

به‌صورت صریح خانواده و اندازهٔ قلم را تنظیم کنید و اطمینان حاصل کنید که فونت در محیط رندر موجود است تا از استفادهٔ فونت جایگزین جلوگیری شود.