---
title: مدیریت مجموعه داده‌های نمودار در ارائه‌ها با PHP
linktitle: مجموعه داده
type: docs
url: /fa/php-java/chart-series/
keywords:
- مجموعه نمودار
- همپوشانی مجموعه
- رنگ مجموعه
- نام مجموعه
- نقطه داده
- سلول کتاب کار
- فاصله مجموعه
- مقدار منفی
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه مجموعه‌های نمودار، نقاط داده، سلول‌های کتاب کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با PHP مدیریت کنید."
---
## **مرور کلی**

یک نمودار داده‌های رسم‌شدهٔ خود را در یک کتاب کار داده‌های نمودار ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/) نمایانگر یک مجموعهٔ مقادیر مرتبط است و هر [ChartDataPoint](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/) در این مجموعه به یک یا چند سلول کتاب کار ارجاع می‌دهد. اشیاء [ChartCategory](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی‌شدهٔ مشترک بین مجموعه‌ها را فراهم می‌کنند. بنابراین نام مجموعه، دسته‌ها و مقادیر نقاط به جای اینکه فقط به‌عنوان متن نمایش داده شوند، به اشیای [ChartDataCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/) متصل می‌شوند.

برای یک نمودار دسته‌ای معمولی، کتاب کار پیش‌فرض از ردیف 0 برای نام‌های مجموعه، ستون 0 برای نام‌های دسته و بقیهٔ سلول‌ها برای مقادیر مجموعه استفاده می‌کند. شاخص‌های برگه، ردیف و ستون که به [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#getCell) پاس داده می‌شوند، صفر‑پایه هستند. این طرح‌بندی زمانی مفید است که یک نمودار را با داده‌های پیش‌فرض ایجاد می‌کنید، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائهٔ بارگذاری‌شده، قبل از تغییر مقادیر کتاب کار، سلول‌های مورد اشارهٔ مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار در سه حوزهٔ متفاوت قرار می‌گیرند:

- تنظیمات سطح مجموعه، مانند [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getFormat)، ظاهر پیش‌فرض تمام نقاط در یک مجموعه را تعیین می‌کنند.
- تنظیمات نقطهٔ داده، مانند [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#getFormat)، ظاهر مجموعه را برای یک نقطه خاص بازنویسی می‌کنند.
- تنظیمات گروهی به مجموعه‌های سازگاری که به یک [ChartSeriesGroup](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/) تعلق دارند، اعمال می‌شود. برای تنظیم گزینه‌هایی مانند هم‌پوشانی یا عرض فاصله، از [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getParentSeriesGroup) دسترسی پیدا کنید.

زمانی که پر رنگ explicit برای نقطه یا مجموعه تنظیم نشده باشد، استایل و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات مجموعه و هم نقطه موجود باشد، تنظیمات نقطه برای آن نقطه اولویت دارد.

![نمودار‑سری‑پاورپوینت](chart-series-powerpoint.png)

## **تنظیم همپوشانی مجموعهٔ نمودار**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getOverlap) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار دو‑بعدی تا چه حد (از ‎‑100‎ تا ‎100‎ درصد) همپوشانی دارند. این یک تصویر فقط‑خواندنی از تنظیمات گروه مجموعه والد است. برای به‌روزرسانی تمام مجموعه‌های سازگار در آن گروه، از [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/#setOverlap) استفاده کنید. این گزینه برای انواع نموداری که نوارها یا ستون‌های گروهی نمایش می‌دهند اعمال می‌شود؛ بر گروه‌های مجموعهٔ نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر همپوشانی گروه حاوی اولین مجموعه را تنظیم می‌کند:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // نمودار جدید شامل مجموعه‌های نمونه، دسته‌ها و مقادیر است.
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

نتیجه:

![همپوشانی مجموعه‌ها](series_overlap.png)

## **تغییر رنگ پر کردن مجموعه**

از [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getFormat) برای تنظیم پر رنگ پیش‌فرض یک مجموعهٔ کامل استفاده کنید. اگر یک نقطه قبلاً پر رنگ صریح داشته باشد، تنظیم [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#getFormat) آن، پر رنگ مجموعه را برای آن نقطه بازنویسی می‌کند.

مثال زیر پر رنگ آبی صاف را به اولین مجموعه اعمال می‌کند:

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

نتیجه:

![رنگ مجموعه](series_color.png)

## **تغییر نام مجموعه**

نام یک مجموعه در کتاب کار داده‌های نمودار ذخیره می‌شود و معمولاً در راهنما نمایش داده می‌شود. در کتاب کار پیش‌فرض ساخته‌شده برای یک نمودار ستونی خوشه‌ای، سلول B1 (ردیف 0، ستون 1) شامل نام اولین مجموعه است. متغیرهای نامگذاری شده در مثال زیر این ساختار را صریح می‌کند:

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

همچنین می‌توانید سلولی که توسط [ChartSeries.getName](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getName) ارجاع داده شده است، به‌روز کنید. این روش از فرض یک ردیف و ستون خاص در یک نمودار موجود جلوگیری می‌کند:

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

نتیجه:

![نام مجموعه](series_name.png)

## **دریافت رنگ پر خودکار مجموعه**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) رنگی را برمی‌گرداند که از شاخص مجموعه و استایل نمودار محاسبه می‌شود. این همان رنگی است که وقتی پر رنگ مجموعه به‌طور صریح تعریف نشده باشد، استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پر رنگ جدیدی اختصاص نمی‌دهد.

مثال زیر رنگ خودکار هر مجموعهٔ پیش‌فرض را چاپ می‌کند:

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

خروجی نمونه برای استایل پیش‌فرض نمودار:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

رنگ‌های دقیق بسته به استایل و تم نمودار متفاوت هستند.

## **تنظیم رنگ پر معکوس برای یک مجموعه نمودار**

برای مجموعه‌های نوار، ستون و حبابی، می‌توان با استفاده از [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#setInvertIfNegative) مقادیر منفی را با پر رنگ متفاوتی نمایش داد. پر رنگ معمولی مجموعه را به حالت صاف تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) اختصاص دهید. اعداد منفی در کتاب کار همان‌طور می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 برگه شامل نام مجموعه، ستون 0 شامل نام‌های دسته و ستون 1 شامل مقادیر است:

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

نتیجه:

![رنگ پر معکوس صاف](inverted_solid_fill_color.png)

می‌توانید برای یک نقطهٔ خاص معکوس‌سازی را از طریق [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) فعال کنید. در مثال زیر معکوس‌سازی برای مجموعه غیرفعال و تنها برای نقطهٔ انتخاب‌شده فعال می‌شود. این نقطه همچنین مقدار منفی دریافت می‌کند تا اثر قابل مشاهده باشد:

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

## **پاک کردن مقدار یک نقطهٔ دادهٔ خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول مربوطه در کتاب کار را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار رسم‌شده از طریق [ChartDataPoint.getValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#getValue) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را به‌عنوان خالی طبق تنظیمات مقدار خالی نمودار درنظر می‌گیرد.

مثال زیر فقط نقطهٔ دوم در اولین مجموعه را پاک می‌کند:

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

نمودارهای پراکندگی از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حبابی همچنین از سلول اندازه بهره می‌برند. فقط سلولی را که نمایانگر مقدار موردنظر برای حذف است پاک کنید. هنگام تمایل به حفظ نقاط دیگر، از فراخوانی [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapointcollection/#clear) خودداری کنید؛ این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

یک سلول خالی در کتاب کار نمایانگر دادهٔ گم‌شده است؛ یک سلول حاوی `0` نمایانگر مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، [ChartDataCell::setValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setValue) را با `null` صدا بزنید. عدد صفر عددی صفر باقی می‌ماند صرف‌نظر از تنظیمات سلول خالی.

از [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/#setDisplayBlanksAs) برای انتخاب نحوهٔ نمایش سلول‌های خالی توسط نمودار استفاده کنید. این تنظیم برای تمام نمودار اعمال می‌شود. این تنظیم نحوهٔ رسم خالی‌ها را تغییر می‌دهد بدون اینکه سلول خالی کتاب کار را با صفر یا مقدار درون‌خطی پر کند.

مثال خودمحافظ زیر یک نمودار خطی با یک مجموعه ایجاد می‌کند، مقدار روز ۳ را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) از برگه 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را نگه می‌دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

    // روز 3 را به‌صورت واقعی خالی بگذارید، در حالی که دسته و نقطه دادهٔ آن را حفظ می‌کنید.
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

هر فایل خروجی حالت تعیین‌شده پیش از ذخیره را ذخیره می‌کند: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ یک نسخه تنها، حالت موردنظر را تنظیم کنید و ارائه را یک بار ذخیره کنید به‌جای تکرار بر روی حالت‌ها.

مقایسهٔ زیر همان داده را در هر سه فایل نشان می‌دهد. روز ۳ در کتاب کار در همهٔ موارد خالی است:

![نمودارهای خطی با دادهٔ یکسان: Gap خط را در روز ۳ قطع می‌کند، Zero خط را به صفر می‌کشاند، و Span روز ۲ را به روز ۴ متصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار وابسته است. یک نمودار خطی سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای نوار و ستونی خطی برای اتصال بین دستهٔ گم‌شده ندارند، بنابراین `Span` نمی‌تواند قطعهٔ متصل شدهٔ بالا را تولید کند؛ یک ستون گم‌شده و یک ستون با ارتفاع صفر نیز می‌توانند مشابه به نظر برسند. به‌طور مشابه، یک نمودار پراکندگی که فقط نشانگر دارد خطی برای اتصال ندارد. انتظار نتایج سه‌گانهٔ متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصلهٔ مجموعه**

عرض فاصله فاصلهٔ بین خوشه‌های نوار یا ستونی مجاور است که به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. مشابه همپوشانی، این تنظیم متعلق به گروه مجموعهٔ والد است نه به یک مجموعهٔ منفرد. برای گروه یک‌بار [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/#setGapWidth) را صدا بزنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را متراکم‌تر می‌سازد.

مثال زیر عرض فاصله را تغییر می‌دهد و فقط ارائهٔ نهایی را ذخیره می‌کند:

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

نتیجه:

![عرض فاصله](gap_width.png)

## **سوالات متداول**

**کدام انواع نمودار از مجموعه داده پشتیبانی می‌کنند؟**

تمام انواع نمودارهای نمایان‌شده توسط شمارش‌گر [ChartType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/) از داده‌های نمودار استفاده می‌کنند، اما مجموعه‌های آن‌ها همه دارای ساختار یا تنظیمات مقدار یکسان نیستند. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حبابی اندازهٔ حباب را اضافه می‌کنند. از روش ایجاد نقطهٔ داده‌ای استفاده کنید که با نوع مجموعه سازگار باشد. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های نوار یا ستونی سازگار اعمال می‌شوند.

**یک گروه مجموعهٔ نمودار چیست؟**

یک [ChartSeriesGroup](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/) شامل مجموعه‌های سازگاری است که تنظیمات رسم سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه دسترسی پیدا می‌کنید لزوماً تمام مجموعه‌های نمودار را تغییر نخواهد داد.

**آیا یک نمودار تازه‌ساخته داده‌های پیش‌فرض دارد؟**

بله. به‌صورت پیش‌فرض، [ShapeCollection.addChart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addChart) مجموعه‌های نمونه، دسته‌ها و مقادیر را ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن یک مجموعهٔ دادهٔ کاملاً سفارشی، هر دو مجموعه و دسته‌ها را پاک کنید. یک overload نیز می‌تواند نموداری بدون دادهٔ پیش‌فرض ایجاد کند.

**آبجکت‌های نمودار چگونه به سلول‌های کتاب کار متصل می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطهٔ داده به سلول‌های یک [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده، عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را طوری هماهنگ کنید که هر نقطه تحت دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را به‌جای تمام مجموعه پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. فقط زمانی از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapointcollection/#clear) استفاده کنید که قصد حذف تمام نقاط آن مجموعه را داشته باشید. اگر دسته‌ها را نیز حذف می‌کنید، تمام مجموعه‌ها را به‌روز کنید تا مقادیر آن‌ها با مجموعهٔ دسته‌ها هم‌راستا بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقدار پیکربندی‌شده از طریق [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/#setDisplayBlanksAs) بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، به‌عنوان مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که با معنای دادهٔ گم‌شده در ارائهٔ شما سازگار باشد. برای مثال کامل و مقایسهٔ تصویری، به بخش **کنترل نمایش سلول‌های خالی** مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های نوار، ستون و حبابی پشتیبانی‌شده، [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#setInvertIfNegative) را فراخوانی کنید و رنگی که توسط [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) بازگردانده می‌شود را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**وقتی هم مجموعه و هم نقطه قالب‌بندی شوند، کدام قالب‌بندی برنده است؟**

قالب‌بندی صریح نقطهٔ داده برای آن نقطه اولویت دارد. نقاط دیگر همچنان از قالب‌بندی صریح مجموعه یا، زمانی که قالب‌بندی مجموعه تعریف نشده باشد، از استایل و تم خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند همپوشانی و عرض فاصله بر چیدمان تأثیر می‌گذارند و بازنویسی قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندر و خوانایی نمودار عوامل محدودکننده‌ای هستند.

**وقتی ستون‌ها خیلی نزدیک یا خیلی دور هستند، چه کاری باید انجام دهم؟**

بر روی گروه مجموعهٔ والد مناسب [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/#setGapWidth) را صدا بزنید. مقدار را برای افزایش فاصله بین خوشه‌ها افزایش دهید یا برای نزدیک‌تر کردن خوشه‌ها آن را کاهش دهید.