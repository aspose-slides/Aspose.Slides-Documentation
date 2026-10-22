---
title: مدیریت داده‌های سری نمودار در ارائه‌ها با PHP
linktitle: داده‌های سری
type: docs
url: /fa/php-java/chart-series/
keywords:
- سری نمودار
- هم‌پوشانی سری
- رنگ سری
- نام سری
- نقطه داده
- سلول کتاب کاری
- فاصله سری
- مقدار منفی
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "چگونگی مدیریت سری‌های نمودار، نقاط داده، سلول‌های کتاب کاری، قالب‌بندی، هم‌پوشانی، عرض فاصله و مقادیر منفی در ارائه‌ها با PHP را بیاموزید."
---
## **مرور کلی**

یک نمودار می‌تواند مقادیر ترسیم‌شده خود را در سلول‌های کتاب کاری یا به‌صورت مستقیم به‌عنوان ثابت‌های عددی ذخیره کند. یک [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) یک مجموعه از مقادیر مرتبط را نشان می‌دهد و هر [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) یک نقطه در آن سری است. اشیاء [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی را که توسط سری‌ها مشترک هستند فراهم می‌کنند. در نمودارهایی که با داده‌های پیش‌فرض ساخته می‌شوند، نام‌های سری، دسته‌ها و مقادیر نقطه‌ها از اشیاء [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) کتاب کاری نمودار استفاده می‌کنند.

برای یک نمودار دسته‌ای معمولی، کتاب کاری پیش‌فرض از ردیف 0 برای نام‌های سری، ستون 0 برای نام‌های دسته و بقیه سلول‌ها برای مقادیر سری استفاده می‌کند. مقادیر شماره‌گذاری شدهٔ کاربرگ، ردیف و ستون که به [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) پاس داده می‌شوند، از صفر شروع می‌شوند. این طرح‌بندی زمانی مفید است که نمودار را با داده‌های پیش‌فرض ایجاد می‌کنید، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائهٔ بارگذاری‌شده، قبل از تغییر مقادیر کتاب کاری، سلول‌های ارجاع‌شده توسط سری‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه محدودهٔ متفاوت هستند:

- تنظیمات در سطح سری، مانند [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/)، ظاهر پیش‌فرض همهٔ نقاط یک سری را تعیین می‌کند.
- تنظیمات در سطح نقطهٔ داده، مانند [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/)، ظاهر سری را برای یک نقطهٔ خاص بازنویسی می‌کند.
- تنظیمات گروهی بر سری‌های سازگاری که به یک [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) تعلق دارند، اعمال می‌شود. برای تنظیم گزینه‌هایی نظیر پوشش یا عرض فاصله، از [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) استفاده کنید.

وقتی پر کردن صریح برای نقطه یا سری تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. هنگامی که هر دو قالب‌بندی سری و نقطه موجود باشد، قالب‌بندی نقطه در اولویت است.

![نمودار-سری-پاورپوینت](chart-series-powerpoint.png)

## **تنظیم مقادیر سری با ثابت‌های عددی**

زمانی که مقادیر سری از داده‌های برنامه یا محاسبات می‌آیند و نیازی به ارجاع به سلول‌های کاربرگ ندارند، از ثابت‌های عددی استفاده کنید. قبل از اختصاص نتیجهٔ هر نقطه با [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) از طریق [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/)، متد [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) را با [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) فراخوانی کنید.

تنظیم مجموعه کنترل‌کنندهٔ نوع منبع همهٔ مقادیر نقطه در آن سری است. هر متد [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) مقدار انتخاب‌شده را گزارش می‌کند؛ آن را از طریق تنظیم مجموعه تغییر دهید. با `Worksheet` از [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) برای دسترسی به سلول ارجاع‌شده استفاده کنید. با `DoubleLiterals` از [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) یا `setAsLiteralDouble` برای خواندن یا نوشتن مستقیم عدد استفاده کنید.

مثال زیر یک نمودار ستونی با سری‌ها و دسته‌های پیش‌فرض ایجاد می‌کند، سپس مقادیر محاسبه‌شدهٔ ۱۰، ۲۰ و ... را به نقاط موجود سری اول اختصاص می‌دهد. سپس ارائه را ذخیره، دوباره باز می‌کند و مقادیر ذخیره‌شده را چاپ می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

نوع منبع مقدار نقطه جدا از [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) است که پیکربندی کتاب کاری داخلی یا خارجی نمودار را شناسایی می‌کند. استفاده از ثابت‌های عددی به‌تنهایی کتاب کاری توکار را حذف نمی‌کند. در این مثال، کتاب کاری برای برچسب‌های دسته، نام‌های سری و سایر سری‌ها در دسترس می‌ماند. برای مدیریت کتاب کاری به [Chart Workbook](/slides/fa/php-java/chart-workbook/) مراجعه کنید.

برای نمودارهای پراکنده و حبابی، از [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) و [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) برای انتخاب منبع‌های [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) و [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/) استفاده کنید. نمودارهای حبابی همچنین از [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) برای [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/) بهره می‌برند. پیش از اختصاص اعداد، هر منبع قابل‌استعمال را به `DoubleLiterals` تنظیم کنید.

## **تنظیم هم‌پوشانی سری‌های نمودار**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) میزان هم‌پوشانی میله‌ها یا ستون‌ها را در یک نمودار دوبعدی، از ‑۱۰۰ تا ۱۰۰ درصد، گزارش می‌دهد. این یک پیش‌بینی فقط‑خواندنی از تنظیمات گروه سری والد است. برای به‌روزرسانی همهٔ سری‌های سازگار در آن گروه، از [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) استفاده کنید. این گزینه برای انواع نموداری که میله‌ها یا ستون‌های گروهی را نمایش می‌دهند اعمال می‌شود؛ در یک نمودار ترکیبی بر روی گروه‌های سری نامرتبط تأثیری ندارد.

مثال زیر هم‌پوشانی گروهی که شامل سری اول است را تنظیم می‌کند:

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

![هم‌پوشانی‌سری‌ها](series_overlap.png)

## **تغییر رنگ پر کردن سری**

از [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) برای تنظیم پر کردن پیش‌فرض یک سری کامل استفاده کنید. اگر یک نقطه پیش‌اپش صریح داشته باشد، تنظیم [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) آن، پر کردن سری را برای آن نقطه بازنویسی می‌کند.

مثال زیر پر کردن آبی ثابت را به سری اول اعمال می‌کند:

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

![رنگ‌سری](series_color.png)

## **تغییر نام سری**

نام سری در کتاب کاری داده‌های نمودار ذخیره می‌شود و معمولاً در افسانه نمایش داده می‌شود. در کتاب کاری پیش‌فرض ایجاد شده برای یک نمودار ستونی خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین سری را دارد. متغیرهای نام‌گذاری‌شده در مثال زیر این ساختار را صریح می‌کنند:

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

همچنین می‌توانید سلول ارجاع‌شده توسط [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/) را به‌روزرسانی کنید. این روش از فرض کردن ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

![نام‌سری](series_name.png)

### **ایجاد سری با نامی ترکیبی از چند سلول**

یک نام سری ترکیبی زمانی مفید است که نام محصول و دورهٔ گزارش در سلول‌های جداگانهٔ کتاب کاری ذخیره شوند. به عنوان مثال می‌توانید `Product A` در B1 و `2026` در C1 را به یک نام سری ترکیب کنید در حالی که هر دو بخش به سلول‌های مبدأشان پیوند دارند.

از [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) برای دریافت محدودهٔ نام استفاده کنید، سپس آن مجموعه را به [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/) پاس دهید. آرگومان `skipHiddenCells` تعیین می‌کند که آیا سلول‌های پنهان شامل شوند یا نه: `true` آنها را حذف می‌کند، `false` شامل می‌شود. این مثال از `false` برای شامل‌کردن تمام سلول‌های محدودهٔ نام استفاده می‌کند.

مثال زیر یک ارائه با یک سری و دو نقطهٔ داده ایجاد می‌کند. سلول‌های B1:C1 فقط نام سری را تأمین می‌کنند؛ A2:A3 برچسب‌های دسته را، و B2:B3 مقادیر عددی را فراهم می‌آورند.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // این دو سلول نام سری را فراهم می‌کنند.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // سلول‌های جداگانه دسته‌ها و نقاط داده عددی را فراهم می‌کنند.
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نام سری حاصل `Product A 2026` است، با یک فاصله بین دو مقدار سلولی. افسانه این را به‌عنوان یک ورودی برای هر دو ستون نمایش می‌دهد. تصویر زیر نتیجه را نشان می‌دهد:

![نمودار ستونی با مقادیر شمال و جنوب و نام ترکیبی سری Product A 2026 در افسانه](composite_series_name.png)

## **دریافت رنگ پر کردن خودکار سری**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) رنگی را برمی‌گرداند که از اندیس سری و سبک نمودار محاسبه می‌شود. این رنگ هنگام عدم تعریف صریح پر کردن سری استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی اعمال نمی‌کند.

مثال زیر رنگ خودکار هر سری پیش‌فرض را چاپ می‌کند:

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

خروجی نمونه برای سبک پیش‌فرض نمودار:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

رنگ‌های دقیق به سبک و تم نمودار وابسته‌اند.

## **تنظیم رنگ پر کردن معکوس برای یک سری نمودار**

برای سری‌های میله، ستون و حباب، [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) می‌تواند مقادیر منفی را با رنگ پر کردن متفاوتی نمایش دهد. پر کردن معمولی سری را به حالت ثابت تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ منفی را از طریق [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) اختصاص دهید. اعداد منفی در کتاب کاری دست‌نخورده می‌مانند؛ تنها رنگ نمایش تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 کاربرگ نام سری را دارد، ستون 0 نام‌های دسته و ستون 1 مقادیر را دارد:

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

![پرتاب‑صلیب‑معکوس](inverted_solid_fill_color.png)

می‌توانید معکوس‌سازی را برای یک نقطهٔ منفرد از طریق [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) فعال کنید. در مثال زیر معکوس‌سازی برای سری غیرفعال و تنها برای نقطهٔ انتخاب‌شده فعال می‌شود. نقطه همچنین مقدار منفی دریافت می‌کند تا اثر مشاهده شود:

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

## **پاک‌سازی مقدار یک نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول کتاب کاری پشت آن را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) در دسترس است. نقطه در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات مقدار خالی نمودار خالی در نظر می‌گیرد.

مثال زیر فقط نقطهٔ دوم در سری اول را پاک می‌کند:

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

نمودارهای پراکنده از سلول‌های جداگانهٔ X و Y استفاده می‌کنند و نمودارهای حبابی نیز از سلول اندازه استفاده می‌کنند. فقط سلولی را که می‌خواهید حذف کنید، پاک کنید. هنگام تمایل به نگه داشتن سایر نقاط، از فراخوانی [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) خودداری کنید، زیرا آن متد تمام نقاط را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که مقادیر دارند موردی متفاوت نسبت به سلول‌های خالی هستند. برای شامل یا مستثنی‌کردن داده‌ها از ردیف‌ها و ستون‌های مخفی کاربرگ، به [Include Data from Hidden Rows and Columns](/slides/fa/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول کتاب کاری خالی نمایانگر دادهٔ گمشده است؛ سلولی که `0` دارد نمایانگر مقدار عددی شناخته‌شده است. برای خالی کردن سلول، متد [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) را با `null` فراخوانی کنید. صفر عددی همچنان صفر می‌ماند صرف‌نظر از تنظیم خالی‑سلول.

از [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) برای انتخاب نحوهٔ نمایش سلول‌های خالی در نمودار استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود. نحوهٔ ترسیم خالی‌ها را تغییر می‌دهد بدون اینکه سلول خالی کتاب کاری با صفر یا مقدار درون‌یابی شده پر شود.

مثال زیر یک نمودار خطی با یک سری ایجاد می‌کند، مقدار روز ۳ را پاک می‌کند و هر حالت را ذخیره می‌کند. نیازی به فایل ورودی نیست. [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) از کاربرگ 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام سری را دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

    // روز 3 را به‌طور واقعی خالی بگذارید، در حالی که دسته‌بندی و نقطه دادهٔ آن را حفظ می‌کنید.
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

هر فایل خروجی حالت تعیین‌شده پیش از ذخیره را ذخیره می‌کند: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ یک نسخهٔ تنها، حالت مطلوب را تنظیم کنید و یک‌بار ارائه را ذخیره کنید.

مقایسهٔ زیر همان داده را در سه فایل نشان می‌دهد. روز ۳ در کتاب کاری در هر سه حالت خالی است:

![نمودارهای خطی با دادهٔ یکسان: Gap خط را در روز ۳ قطع می‌کند، Zero خط را به صفر می‌کشاند، و Span روز ۲ را به روز ۴ متصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده بسته به نوع نمودار متفاوت است. یک نمودار خطی سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای میله و ستون خطی برای اتصال بین دستهٔ گمشده ندارند، بنابراین `Span` نمی‌تواند بخش اتصال نشان‌داده‌شده در بالا را تولید کند؛ یک ستون گمشده و یک ستون با ارتفاع صفر می‌توانند مشابه به‌نظر برسند. به‌طور مشابه، یک نمودار پراکنده فقط با نشانگرها خطی برای اتصال ندارد. انتظار نتایج سه‌گانهٔ متفاوت برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصلهٔ سری‌ها**

عرض فاصلهٔ خالی، فاصلهٔ بین خوشه‌های میله یا ستون مجاور است که به صورت درصدی از عرض میله یا ستون بیان می‌شود. مشابه هم‌پوشانی، این تنظیم به گروه سری والد تعلق دارد نه به یک سری منفرد. برای گروه یک بار [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) را فراخوانی کنید. مقدار بزرگ‌تر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچک‌تر آن‌ها را متراکم می‌سازد.

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

![عرض‑فاصله](gap_width.png)

## **سؤالات متداول**

**کدام نوع نمودار از سری‌های داده پشتیبانی می‌کند؟**

تمام انواع نمودارهایی که توسط شمارش [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) نمایان می‌شوند از داده‌های نمودار استفاده می‌کنند، اما سری‌های آن‌ها همگی ساختار یا تنظیمات ارزش یکسانی ندارند. به عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حبابی از اندازه حباب‌ها بهره می‌برند. از روش ایجاد نقطهٔ داده‌ای استفاده کنید که با نوع سری مطابقت دارد. گزینه‌هایی مثل هم‌پوشانی و عرض فاصله فقط برای گروه‌های میله یا ستون سازگار اعمال می‌شوند.

**یک گروه سری نموداری چیست؟**

یک [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات رسم در سطح گروه را به اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک سری دسترسی پیدا می‌کنید، لزوماً همهٔ سری‌های نمودار را تحت تأثیر قرار نمی‌دهد.

**آیا یک نمودار تازه‌ساخته داده‌های پیش‌فرض دارد؟**

بله. به‌صورت پیش‌فرض، [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) سری‌ها، دسته‌ها و مقادیر نمونه ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعهٔ دادهٔ کاملاً سفارشی، هر دو مجموعهٔ سری و دسته را پاک کنید. یک overload نیز می‌تواند نموداری بدون دادهٔ پیش‌فرض ایجاد کند.

**چگونه اشیاء نمودار به سلول‌های کتاب کاری متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقطهٔ داده به سلول‌های یک [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده، عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقدار سری را هم‌راستا نگه دارید تا هر نقطه زیر دستهٔ مورد نظر رسم شود.

**چگونه یک نقطه را به‌جای حذف کل سری پاک‌کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. از [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) فقط زمانی استفاده کنید که قصد حذف تمام نقاط یک سری را دارید. اگر دسته‌ها را نیز حذف می‌کنید، هر سری را به‌روزرسانی کنید تا مقادیر با مجموعهٔ دسته هم‌راستا بمانند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقدار تنظیم‌شده از طریق [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت شکاف، مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنای دادهٔ گمشده در ارائهٔ شما را منعکس کند. برای مثال کامل و مقایسهٔ تصویری به [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های میله، ستون و حباب پشتیبانی‌شده، [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) را فراخوانی کنید و رنگی که از [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) باز می‌گردد تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**وقتی هم سری و هم نقطه قالب‌بندی شوند، کدام برتری دارد؟**

قالب‌بندی صریح نقطهٔ داده برای آن نقطه اولویت دارد. سایر نقاط همچنان از قالب‌بندی صریح سری یا، اگر قالب‌بندی سری تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند هم‌پوشانی و عرض فاصله فقط طرح‌بندی را کنترل می‌کنند و بازنویسی قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ یک حد مفید هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد نزدیک یا دور هستند؟**

[ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) را بر روی گروه سری والد مربوطه فراخوانی کنید. مقدار را برای باز کردن فواصل بین خوشه‌ها افزایش دهید یا برای نزدیک‌تر کردن خوشه‌ها کاهش دهید.