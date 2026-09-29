---
title: مدیریت سری‌های داده نمودار در ارائه‌ها با PHP
linktitle: سری داده
type: docs
url: /fa/php-java/chart-series/
keywords:
- سری نمودار
- پوشش سری
- رنگ سری
- نام سری
- نقطه داده
- سلول کاربرگ
- فاصله سری
- مقدار منفی
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کاربرگ، قالب‌بندی، پوشش، عرض فاصله و مقادیر منفی را در ارائه‌ها با PHP مدیریت کنید."
---
## **نمای کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کاربرگ داده‌های نمودار ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/) نمایانگر یک مجموعه از مقادیر مرتبط است و هر [ChartDataPoint](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/) در این مجموعه به یک یا چند سلول کاربرگ اشاره می‌کند. اشیاء [ChartCategory](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی را که توسط مجموعه‌ها به اشتراک گذاشته می‌شوند، فراهم می‌آورند. به همین دلیل نام مجموعه، دسته‌بندی‌ها و مقادیر نقاط به اشیاء [ChartDataCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/) متصل هستند نه اینکه فقط به عنوان متن نمایشی ذخیره شوند.

برای یک نمودار دسته‌ای معمولی، کاربرگ پیش‌فرض از ردیف 0 برای نام‌های مجموعه، ستون 0 برای نام‌های دسته و سلول‌های باقی مانده برای مقادیر مجموعه استفاده می‌کند. شاخص‌های کاربرگ، ردیف و ستون که به [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#getCell) پاس می‌شوند، صفر‑مبنا هستند. این قالب‌بندی زمانی مفید است که نمودار را با داده‌های پیش‌فرض ایجاد می‌کنید، اما فرض نکنید هر نمودار موجود از آن استفاده می‌کند. برای ارائه‌ای که بارگذاری شده است، سلول‌های مرجع توسط مجموعه‌ها، دسته‌ها و نقاط داده را پیش از تغییر مقادیر کاربرگ بررسی کنید.

تنظیمات نمودار سه حوزه متفاوت دارند:

- تنظیمات در سطح مجموعه، مانند [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getFormat)، ظاهر پیش‌فرض تمام نقاط در یک مجموعه را فراهم می‌کنند.
- تنظیمات در سطح نقطه داده، مانند [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#getFormat)، ظاهر مجموعه را برای یک نقطه خاص لغو می‌کند.
- تنظیمات گروهی برای مجموعه‌های سازگاری که به همان [ChartSeriesGroup](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند پوشش (overlap) یا عرض فاصله (gap width) از [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getParentSeriesGroup) استفاده کنید.

زمانی که پر کردن صریح نقطه یا مجموعه‌ای تعیین نشده باشد، استایل و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هر دو قالب‌بندی مجموعه و نقطه موجود باشد، قالب‌بندی نقطه برای آن نقطه اولویت دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم پوشش مجموعه نمودار**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getOverlap) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار دو بعدی تا چه حد هم‌پوشانی دارند، از ‑۱۰۰ تا ۱۰۰ درصد. این یک پیش‌بینی فقط‑خواندنی از تنظیمات در گروه مجموعه والد است. برای به‌روزرسانی همه مجموعه‌های سازگار در آن گروه از [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/#setOverlap) استفاده کنید. این گزینه برای انواع نمودارهایی که نوارها یا ستون‌های گروهی نمایش می‌دهند اعمال می‌شود؛ بر گروه‌های مجموعه نامرتبط در یک نمودار ترکیبی تاثیری ندارد.

مثال زیر پوشش (overlap) را برای گروهی که شامل اولین مجموعه است، تنظیم می‌کند:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // نمودار جدید شامل سری‌های نمونه، دسته‌ها و مقادیر است.
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

![The series overlap](series_overlap.png)

## **تغییر رنگ پر کردن مجموعه**

از [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getFormat) برای تنظیم پر کردن پیش‌فرض یک مجموعه کامل استفاده کنید. اگر یک نقطه قبلاً پر کردن صریح داشته باشد، تنظیم [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#getFormat) آن، پر کردن مجموعه را برای آن نقطه لغو می‌کند.

مثال زیر یک پر کردن آبی صلب را برای اولین مجموعه اعمال می‌کند:

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

![The color of the series](series_color.png)

## **تغییر نام مجموعه**

نام مجموعه در کاربرگ داده‌های نمودار ذخیره می‌شود و معمولاً در نشان‌گر (legend) نمایش داده می‌شود. در کاربرگ پیش‌فرض ایجاد شده برای یک نمودار ستونی خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین مجموعه را در خود دارد. متغیرهای نام‌گذاری شده در مثال زیر این ساختار را به وضوح نشان می‌دهند:

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

همچنین می‌توانید سلول مرجعی که توسط [ChartSeries.getName](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getName) استفاده می‌شود، به‌روزرسانی کنید. این رویکرد از فرض کردن ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

![The series name](series_name.png)

## **دریافت رنگ پر کردن خودکار مجموعه**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) رنگی را برمی‌گرداند که از اندیس مجموعه و استایل نمودار محاسبه می‌شود. این همان رنگی است که هنگامی که پر کردن مجموعه صریحاً تعریف نشده باشد، استفاده می‌شود. فراخوانی این متد رنگ محاسبه‌شده را می‌خواند؛ رنگ جدیدی را اختصاص نمی‌دهد.

مثال زیر رنگ خودکار هر مجموعه پیش‌فرض را چاپ می‌کند:

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

رنگ‌های دقیق به استایل و تم نمودار بستگی دارد.

## **تنظیم رنگ پر کردن معکوس برای یک مجموعه نمودار**

برای مجموعه‌های نوار، ستون و حباب، می‌توان با استفاده از [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#setInvertIfNegative) مقادیر منفی را با پر کردن متفاوت نمایش داد. پر کردن معمولی مجموعه را به حالت صلب تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) اختصاص دهید. اعداد منفی در کاربرگ دست نخورده می‌مانند؛ فقط رنگ نمایش آنها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 کاربرگ نام مجموعه را دارد، ستون 0 نام دسته‌ها را دارد و ستون 1 مقادیر را شامل می‌شود:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

می‌توانید برای یک نقطه خاص معکوس‌سازی را از طریق [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) فعال کنید. در مثال زیر معکوس‌سازی برای مجموعه غیرفعال و فقط برای نقطه انتخاب‌شده فعال شده است. این نقطه نیز مقدار منفی دریافت می‌کند تا اثر قابل مشاهده باشد:

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

## **پاک کردن مقدار یک نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف دیگر نقاط، سلول کاربرگ پشتیبان آن را به `null` تنظیم کنید. برای نمودار ستونی، مقدار ترسیم‌شده از طریق [ChartDataPoint.getValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#getValue) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را به عنوان خالی بر اساس تنظیمات خالی‑مقدار نمودار در نظر می‌گیرد.

مثال زیر فقط دومین نقطه در اولین مجموعه را پاک می‌کند:

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

نمودارهای پراکنده (scatter) از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حبابی نیز از یک سلول اندازه استفاده می‌کنند. فقط سلولی را که نمایانگر مقداری است که می‌خواهید حذف کنید، پاک کنید. هنگام نیاز به حفظ نقاط دیگر، از فراخوانی [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapointcollection/#clear) خودداری کنید، زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که حاوی مقادیر هستند، مورد متفاوتی نسبت به سلول‌های خالی محسوب می‌شوند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی کاربرگ، به بخش [Include Data from Hidden Rows and Columns](/slides/fa/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول کاربرگ خالی نمایانگر داده‌های گمشده است؛ یک سلول حاوی `0` نمایانگر مقدار عددی شناخته‌شده‌ای است. برای خالی کردن یک سلول، با `null` به [ChartDataCell::setValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setValue) فراخوانی کنید. مقدار عددی صفر بدون در نظر گرفتن تنظیم خالی‑سلول صفر می‌ماند.

از [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/#setDisplayBlanksAs) برای انتخاب نحوه نمایش سلول‌های خالی در نمودار استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود. این تنظیم نحوه ترسیم خالی‌ها را تغییر می‌دهد، بدون این که سلول کاربرگ خالی را با صفر یا مقدار درون‌خطی پر کند.

مثال خود‑محافظ زیر یک نمودار خطی با یک مجموعه ایجاد می‌کند، مقدار روز ۳ را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌نماید. نیازی به فایل ورودی نیست. [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) از کاربرگ 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را در خود دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

    // روز ۳ را واقعاً خالی بگذارید، در حالی که دسته‌بندی و نقطه داده آن را حفظ می‌کنید.
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

هر فایل خروجی حالت تعیین‌شده قبل از ذخیره‌سازی را نشان می‌دهد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ تنها یک نسخه، حالت دلخواه را تعیین کنید و یک‌بار ارائه را ذخیره کنید به جای تکرار بر روی حالت‌ها.

مقایسهٔ زیر همان داده‌ها را در هر سه فایل نشان می‌دهد. روز ۳ در کاربرگ در تمام موارد خالی است:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی سه حالت را به راحتی مقایسه می‌کند. نمودارهای نوار و ستونی خطی برای اتصال بین دسته‌های گمشده ندارند، بنابراین `Span` نمی‌تواند بخش اتصال نشان داده‌شده در بالا را تولید کند؛ یک ستون گمشده و یک ستون با ارتفاع صفر نیز می‌توانند مشابه به نظر برسند. به همان ترتیب، یک نمودار پراکنده فقط با نشانگرها خطی برای اتصال ندارند. انتظار نتایج سه‌گانه متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصله مجموعه**

عرض فاصله (gap width) فضای بین خوشه‌های نوار یا ستون مجاور را نشان می‌دهد و به صورت درصدی از عرض نوار یا ستون بیان می‌شود. همانند پوشش، این تنظیم متعلق به گروه مجموعه والد است نه به یک مجموعه منفرد. یکبار برای گروه، [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/#setGapWidth) را فراخوانی کنید. مقدار بزرگ‌تر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آنها را متراکم‌تر می‌سازد.

مثال زیر عرض فاصله را تغییر می‌دهد و فقط ارائه نهایی را ذخیره می‌کند:

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

![The gap width](gap_width.png)

## **سوالات متداول**

**کدام انواع نمودار از سری داده پشتیبانی می‌کنند؟**

همهٔ انواع نمودارهایی که توسط شمارشگر [ChartType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/) نمایان می‌شوند، از داده‌های نمودار استفاده می‌کنند، اما سری‌های آنها همه ساختار مقدار یا تنظیمات یکسانی ندارند. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حبابی اندازه حباب را اضافه می‌کنند. از روش ایجاد نقطه داده‌ای استفاده کنید که با نوع سری سازگار باشد. گزینه‌هایی مانند پوشش و عرض فاصله تنها برای گروه‌های نوار یا ستونی سازگار اعمال می‌شوند.

**یک گروه سری نمودار چیست؟**

یک [ChartSeriesGroup](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات رسم در سطح گروه را به اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک سری به آن دسترسی پیدا می‌کنید، لزوماً همهٔ سری‌ها را در نمودار تغییر نمی‌دهد.

**آیا نمودار تازه ساخته‌شده داده‌های پیش‌فرض دارد؟**

بله. به‌طور پیش‌فرض، [ShapeCollection.addChart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addChart) نمونه‌ای از سری‌ها، دسته‌ها و مقادیر ایجاد می‌کند. می‌توانید آن سلول‌ها را ویرایش کنید یا قبل از افزودن یک مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعه سری و دسته را پاک کنید. یک overload نیز می‌تواند نموداری بدون دادهٔ پیش‌فرض ایجاد کند.

**اشیای نمودار چگونه به سلول‌های کاربرگ متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) ارجاع می‌دهد. تغییر یک سلول مرجع، عنصر مربوط به نمودار را به‌روزرسانی می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر سری را طوری تنظیم کنید که هر نقطه زیر دستهٔ مورد نظر ترسیم شود.

**چگونه یک نقطه را به‌جای پاک کردن کل سری پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به عنوان نقطهٔ خالی حفظ شود. از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapointcollection/#clear) فقط زمانی استفاده کنید که قصد حذف تمام نقاط آن سری را داشته باشید. اگر دسته‌ها را نیز حذف می‌کنید، هر سری را به‌روزرسانی کنید تا مقادیر آنها با مجموعهٔ دسته‌ها هم‌خط شوند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقدار تنظیم‌شده از طریق [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/#setDisplayBlanksAs) بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌عنوان فاصله، به‌عنوان مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنای داده‌های گمشده در ارائهٔ شما را بازتاب دهد. برای مثال کامل و مقایسهٔ بصری به بخش [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های نوار، ستون و حباب پشتیبانی‌شده، از [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#setInvertIfNegative) فراخوانی کنید و رنگی که توسط [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) برگردانده می‌شود را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ فردی با [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) بازنویسی کنید. این متدها صرفاً قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**زمانی که هم مجموعه و هم نقطه قالب‌بندی شوند، کدام یک برتر است؟**

قالب‌بندی صریح نقطه داده برای آن نقطه اولویت دارد. نقاط دیگر به قالب‌بندی صریح مجموعه ادامه می‌دهند یا، اگر قالب‌بندی مجموعه تعریف نشده باشد، از استایل و تم خودکار نمودار استفاده می‌شود. تنظیمات گروهی مانند پوشش و عرض فاصله بر چیدمان کنترل می‌کنند و بازنویسی‌های قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان рендеринг و خوانایی نمودار تعیین‌کنندهٔ حد عملی هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد نزدیک یا دور از یکدیگر هستند؟**

در گروه مجموعهٔ والد مناسب، [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/#setGapWidth) را فراخوانی کنید. مقدار را برای افزایش فاصله بین خوشه‌ها افزایش دهید یا برای نزدیک‌تر کردن خوشه‌ها کاهش دهید.