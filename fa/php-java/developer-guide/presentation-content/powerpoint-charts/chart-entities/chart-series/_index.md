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
- سلول کتاب‌کار
- فاصله مجموعه
- مقدار منفی
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "آموزش مدیریت مجموعه‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی در ارائه‌ها با PHP."
---
## **نمای کلی**

یک نمودار داده‌های ترسیم شده خود را در یک کتاب‌کار دادهٔ نمودار (chart data workbook) ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) نشان‌دهندهٔ یک مجموعهٔ مقادیر مرتبط است و هر [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) در این مجموعه به یک یا چند سلول کتاب‌کار ارجاع می‌دهد. اشیای [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین مجموعه‌ها را فراهم می‌کنند. بنابراین نام مجموعه، دسته‌ها و مقادیر نقاط به جای اینکه صرفاً به‌عنوان متن نمایش داده شوند، به اشیای [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) مرتبط می‌شوند.

در یک نمودار دسته‌ای معمولی، کتاب‌کار پیش‌فرض از ردیف ۰ برای نام مجموعه‌ها، ستون ۰ برای نام دسته‌ها و سلول‌های باقیمانده برای مقادیر مجموعه‌ها استفاده می‌کند. شاخص‌های worksheet، row و column که به [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCell) پاس می‌شوند، از صفر شروع می‌شوند. این چیدمان زمانی مفید است که نمودار را با دادهٔ پیش‌فرض ایجاد می‌کنید، اما فرض نکنید که هر نمودار موجود از این روش استفاده می‌کند. برای یک ارائهٔ بارگذاری‌شده، قبل از تغییر مقادیر کتاب‌کار سلول‌هایی که توسط مجموعه‌ها، دسته‌ها و نقاط داده ارجاع داده شده‌اند را بررسی کنید.

تنظیمات نمودار دارای سه حوزهٔ متفاوت هستند:

- تنظیمات در سطح مجموعه، مانند [ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat)، ظاهر پیش‌فرض همهٔ نقاط در یک مجموعه را فراهم می‌کند.
- تنظیمات در سطح نقطهٔ داده، مانند [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat)، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی برای مجموعه‌های سازگاری که به یک [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند overlap یا gap width، گروه را از طریق [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) دریافت کنید.

زمانی که پر کردن صریح برای نقطه یا مجموعه تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات مجموعه و هم تنظیمات نقطه وجود داشته باشد، تنظیمات نقطه برای آن نقطه برتری دارد.

![نمودار-سری-پاورپوینت](chart-series-powerpoint.png)

## **تنظیم Overlap مجموعهٔ نمودار**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getOverlap) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار ۲‑بعدی تا چه میزان (از ‑۱۰۰ تا ۱۰۰ درصد) روی هم می‌افتند. این مقدار تنها یک پیش‌بینی فقط‑خواندنی از تنظیمات گروه مجموعهٔ والد است. برای به‌روزرسانی همهٔ مجموعه‌های سازگار در آن گروه از [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setOverlap) استفاده کنید. این گزینه برای انواع نمودارهایی که نوارها یا ستون‌های گروهی نشان می‌دهند کاربرد دارد؛ برای گروه‌های مجموعهٔ نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر overlap گروهی که شامل اولین مجموعه است را تنظیم می‌کند:

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

![Overlap مجموعه‌ها](series_overlap.png)

## **تغییر رنگ پر کردن مجموعه**

از [ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat) برای تنظیم پر کردن پیش‌فرض کل یک مجموعه استفاده کنید. اگر یک نقطه پر کردن صریح داشته باشد، تنظیمات [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat) آن نقطه را بازنویسی می‌کند.

مثال زیر یک پر کردن ثابت آبی به اولین مجموعه اعمال می‌کند:

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

نام یک مجموعه در کتاب‌کار دادهٔ نمودار ذخیره می‌شود و به‌طور معمول در legend نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ایجاد شده برای یک نمودار ستونی خوشه‌ای، سلول B1 در ردیف ۰، ستون ۱ قرار دارد و نام اولین مجموعه را دارد. متغیرهای نام‌گذاری شده در مثال زیر این ساختار را صریح می‌کنند:

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

همچنین می‌توانید سلولی را که قبلاً توسط [ChartSeries.getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getName) ارجاع داده شده به‌روزرسانی کنید. این رویکرد از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

### **ایجاد مجموعه‌ای با نام از چند سلول**

یک نام ترکیبی برای مجموعه زمانی مفید است که نام محصول و دورهٔ گزارش در سلول‌های جداگانهٔ کتاب‌کار ذخیره شده باشند. برای مثال می‌توانید `Product A` در B1 و `2026` در C1 را به یک نام مجموعه ترکیب کنید در حالی که هر دو بخش به سلول‌های منبع خود پیوستگی دارند.

از [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCellCollection) برای دریافت بازهٔ نام استفاده کنید، سپس آن مجموعه را به [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/#add) پاس دهید. آرگومان `skipHiddenCells` کنترل می‌کند که آیا سلول‌های مخفی شامل شوند یا نه: `true` آنها را مستثنی می‌کند، در حالی که `false` شامل می‌شود. این مثال از `false` برای شامل‌کردن همهٔ سلول‌های بازهٔ نام استفاده می‌کند.

مثال زیر یک ارائه با یک مجموعه و دو نقطه داده ایجاد می‌کند. سلول‌های B1:C1 فقط نام مجموعه را فراهم می‌کنند؛ A2:A3 برچسب‌های دسته را فراهم می‌کنند و B2:B3 مقادیر عددی را فراهم می‌کنند.

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

    // این دو سلول نام مجموعه را فراهم می‌کنند.
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

نام مجموعهٔ تولیدی `Product A 2026` است، با یک فاصله بین دو مقدار سلولی. legend این را به عنوان یک ورودی برای هر دو ستون نشان می‌دهد. تصویر زیر نتیجه را نشان می‌دهد:

![نمودار ستونی با مقادیر شمال و جنوب و نام ترکیبی مجموعه Product A 2026 در legend](composite_series_name.png)

## **دریافت رنگ پر کردن خودکار مجموعه**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) رنگی را برمی‌گرداند که از اندیس مجموعه و سبک نمودار محاسبه می‌شود. این همان رنگی است که وقتی پر کردن مجموعه صریحاً تعریف نشده باشد، استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی را اختصاص نمی‌دهد.

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

خروجی نمونه برای سبک پیش‌فرض نمودار:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

رنگ‌های دقیق بسته به سبک و تم نمودار متفاوت هستند.

## **تنظیم رنگ پر کردن معکوس برای یک مجموعهٔ نمودار**

برای مجموعه‌های بار، ستون و حباب، می‌توانید با استفاده از [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) مقادیر منفی را با پر کردن متفاوت نمایش دهید. پر کردن معمولی مجموعه را به حالت ثابت (solid) تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) اختصاص دهید. اعداد منفی در کتاب‌کار دست‌نخورده می‌مانند؛ تنها رنگ نمایش آنها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف ۰ worksheet نام مجموعه را دارد، ستون ۰ نام دسته‌ها و ستون ۱ مقادیر را دارد:

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

![رنگ پر کردن ثابت معکوس](inverted_solid_fill_color.png)

می‌توانید برای یک نقطه خاص معکوس‌سازی را از طریق [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) فعال کنید. در مثال زیر معکوس‌سازی برای مجموعه غیرفعال و تنها برای نقطهٔ انتخاب‌شده فعال می‌شود. این نقطه همچنین مقدار منفی دریافت می‌کند تا اثر قابل رؤیت باشد:

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

برای خالی کردن یک نقطه بدون حذف سایر نقاط، سلول کتاب‌کار پشتیبان آن را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [ChartDataPoint.getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getValue) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را مطابق تنظیمات خالی (blank‑value) به‌عنوان خالی در نظر می‌گیرد.

مثال زیر فقط نقطه دوم در اولین مجموعه را پاک می‌کند:

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

نمودارهای پراکنده از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حباب نیز یک سلول اندازه دارند. فقط سلولی را که نمایانگر مقدار مورد نظر شما برای حذف است، پاک کنید. هنگام نیاز به حفظ سایر نقاط، به‌جای فراخوانی [ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) از این روش استفاده نکنید؛ زیرا این متد همهٔ نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که حاوی مقادیر هستند موردی جدا از سلول‌های خالی هستند. برای شامل یا مستثنی کردن داده‌ها از ردیف‌ها و ستون‌های مخفی worksheet، به [Include Data from Hidden Rows and Columns](/slides/fa/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول کتاب‌کار خالی نشان‌دهندهٔ دادهٔ گم‌شده است؛ سلولی که مقدار `0` دارد نشان‌دهندهٔ مقدار عددی شناخته‌شده است. برای خالی کردن سلول، [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setValue) را با `null` فراخوانی کنید. صفر عددی همچنان صفر می‌ماند، صرف‌نظر از تنظیم خالی‑سلول.

از [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs) برای انتخاب نحوهٔ نمایش سلول‌های خالی استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود و نحوهٔ رسم خالی‌ها را بدون پر کردن سلول خالی با صفر یا مقدار درونی تغییر می‌دهد.

مثال خودکفا زیر یک نمودار خطی با یک مجموعه ایجاد می‌کند، مقدار روز ۳ را پاک می‌کند و هر حالت را به‌صورت فایل ذخیره می‌کند. نیازی به فایل ورودی نیست. [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) از worksheet ۰، ستون ۰ برای برچسب‌های دسته و ستون ۱ برای مقادیر استفاده می‌کند؛ ردیف ۰ نام مجموعه را دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

    // روز ۳ را واقعا خالی بگذارید، در حالی که دسته‌بندی و نقطهٔ دادهٔ آن را نگه می‌دارید.
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

هر فایل خروجی حالت اختصاص داده‌شده پیش از ذخیره را نشان می‌دهد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ فقط یک نسخه، حالت دلخواه را تنظیم کنید و یکبار ارائه را ذخیره کنید به جای اینکه بر تمام حالت‌ها حلقه بزنید.

مقایسهٔ زیر همان داده‌ها را در سه فایل نشان می‌دهد. روز ۳ در کتاب‌کار خالی است:

![نمودارهای خطی با دادهٔ یکسان: Gap خط را در روز ۳ شکسته، Zero خط را به صفر می‌کاهد و Span روز ۲ را به روز ۴ متصل می‌کند.](display_blanks_as.png)

اثر قابل رؤیت به نوع نمودار بستگی دارد. یک نمودار خطی سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای بار و ستون خطی برای اتصال بین دسته‌های گم‌شده ندارند، بنابراین `Span` نمی‌تواند قطعهٔ اتصال نشان داده‌شده را تولید کند؛ یک ستون گم‌شده و یک ستون صفر‑ارتفاع نیز ممکن است مشابه به‌نظر برسند. به‌طور مشابه، یک نمودار پراکنده تنها با مارکرها خط متصل ندارد. انتظار نتایج متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض شکاف مجموعه**

عرض شکاف (gap width) فاصله بین خوشه‌های نوار یا ستون مجاور است که به‌عنوان درصدی از عرض نوار یا ستون بیان می‌شود. مشابه overlap، این تنظیم به گروه مجموعهٔ والد تعلق دارد نه به یک مجموعهٔ منفرد. یک بار برای گروه فراخوانی [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را متراکم‌تر می‌کند.

مثال زیر عرض شکاف را تغییر می‌دهد و فقط ارائهٔ نهایی را ذخیره می‌کند:

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

![عرض شکاف](gap_width.png)

## **سوالات متداول**

**کدام انواع نمودار از مجموعه‌های داده پشتیبانی می‌کنند؟**

تمام انواع نمودارهایی که توسط شمارش‌گر [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) تعریف شده‌اند، از دادهٔ نمودار استفاده می‌کنند، اما مجموعه‌های آنها همه ساختار یا تنظیمات یکسانی ندارند. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حباب از اندازهٔ حباب بهره می‌برند. متد ایجاد نقطهٔ داده‌ای را انتخاب کنید که با نوع مجموعه مطابقت داشته باشد. گزینه‌هایی مانند overlap و gap width فقط برای گروه‌های بار یا ستون سازگار اعمال می‌شوند.

**یک گروه مجموعهٔ نمودار چیست؟**

یک [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) شامل مجموعه‌های سازگاری است که تنظیمات رسم در سطح گروه را به اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه به آن دست پیدا می‌کنید، لزوماً تمام مجموعه‌های موجود در نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه‌ساخته شامل داده‌های پیش‌فرض است؟**

بله. به‌صورت پیش‌فرض، [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) مجموعه‌ها، دسته‌ها و مقادیر نمونه‌ای ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا هم مجموعه‌ها و هم دسته‌ها را پیش از افزودن مجموعهٔ دادهٔ کاملاً سفارشی پاک کنید. یک overload نیز می‌تواند نمودار را بدون دادهٔ پیش‌فرض ایجاد کند.

**چگونه اشیای نمودار به سلول‌های کتاب‌کار متصل می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطهٔ داده به سلول‌های یک [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) ارجاع می‌دهند. تغییر سلول ارجاع‌شده، عنصر مربوطه در نمودار را به‌روزرسانی می‌کند. هنگام ساخت دادهٔ سفارشی، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را هم‌تراز نگه دارید تا هر نقطه تحت دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را به‌جای کل مجموعه پاک کنم؟**

سلول مقدار مرتبط را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی باقی بماند. فقط زمانی که قصد حذف تمام نقاط یک مجموعه را دارید، از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) استفاده کنید. اگر همزمان دسته‌ها را حذف می‌کنید، هر مجموعه را به‌روزرسانی کنید تا مقادیر با مجموعهٔ دسته هم‌راستا بمانند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و تنظیمی که از طریق [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs) انتخاب می‌کنید، بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به عنوان فواصل، مقادیر صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنای دادهٔ گم‌شده در ارائهٔ شما را بازتاب دهد. برای مثال کامل و مقایسهٔ بصری به بخش [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های بار، ستون و حباب پشتیبانی‌شده، متد [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) را فراخوانی کنید و رنگی که توسط [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) بازگردانده می‌شود، تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**وقتی هم مجموعه و هم نقطه قالب‌بندی شده باشند، کدام یک برتری دارد؟**

قالب‌بندی صریح نقطهٔ داده بر نقطهٔ موردنظر ارجحیت دارد. نقاط دیگر همچنان از قالب صریح مجموعه یا، زمانی که قالب مجموعه تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند overlap و gap width بر چینش کلی تأثیر می‌گذارند و بازنویسی قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیتی ثابت برای تعداد مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندر و قابلیت خوانایی نمودار تعیین‌کنندهٔ حد قابل استفاده هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها خیلی نزدیک یا خیلی دور از هم هستند؟**

از [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) بر روی گروه مجموعهٔ والد مربوطه استفاده کنید. مقدار را افزایش دهید تا فاصله بین خوشه‌ها زیاد شود یا کاهش دهید تا خوشه‌ها به هم نزدیک‌تر شوند.