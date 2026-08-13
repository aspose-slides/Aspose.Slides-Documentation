---
title: مدیریت سری‌های داده نمودار در ارائه‌ها با PHP
linktitle: سری داده
type: docs
url: /fa/php-java/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
- رنگ سری
- نام سری
- نقطه داده
- سلول کتاب‌کار
- فاصله سری
- مقدار منفی
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با PHP مدیریت کنید."
---
## **نمای کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کتاب‌کار داده‌های نمودار ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/) یک مجموعه از مقادیر مرتبط را نشان می‌دهد و هر [ChartDataPoint](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/) در این سری به یک یا چند سلول کتاب‌کار ارجاع می‌دهد. اشیاء [ChartCategory](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین سری‌ها را فراهم می‌کنند. بنابراین نام سری، دسته‌ها و مقادیر نقطه به اشیاء [ChartDataCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/) متصل هستند نه اینکه فقط به‌عنوان متن نمایشی ذخیره شوند.

برای یک نمودار دسته‌ای معمولی، کتاب‌کار پیش‌فرض از ردیف 0 برای نام‌های سری، ستون 0 برای نام‌های دسته و سلول‌های باقی‌مانده برای مقادیر سری استفاده می‌کند. شاخص‌های ورق‌کار، ردیف و ستون که به [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#getCell) پاس می‌شوند، صفر‑مبنایی هستند. این طرح‌بندی زمانی مفید است که نموداری را با داده‌های پیش‌فرض ایجاد می‌کنید، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب‌کار، سلول‌های ارجاع‌شده توسط سری‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار در سه سطح متفاوت وجود دارد:

- تنظیمات در سطح سری، مانند [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getFormat)، ظاهر پیش‌فرض همهٔ نقاط در یک سری را فراهم می‌کند.
- تنظیمات نقطه داده، مانند [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#getFormat)، ظاهر سری را برای یک نقطه خاص بازنویسی می‌کند.
- تنظیمات گروهی برای سری‌های سازگار که به همان [ChartSeriesGroup](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند هم‌پوشانی یا عرض فاصله، از [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getParentSeriesGroup) استفاده کنید.

وقتی پر کردن صریح برای نقطه یا سری تنظیم نشود، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم پر کردن سری و هم پر کردن نقطه موجود باشد، پر کردن نقطه برای آن نقطه برتری دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم هم‌پوشانی سری نمودار**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getOverlap) میزان هم‌پوشانی نوارها یا ستون‌ها را در یک نمودار دو‑بعدی از -100 تا 100 درصد گزارش می‌دهد. این مقدار یک پیش‌نمایش فقط‑خواندنی از تنظیمات گروه سری والد است. برای به‌روزرسانی تمام سری‌های سازگار در آن گروه از [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/#setOverlap) استفاده کنید. این گزینه برای انواع نموداری که نوارها یا ستون‌های گروهی را نمایش می‌دهند اعمال می‌شود؛ برای گروه‌های سری نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر هم‌پوشانی گروهی که شامل اولین سری است را تنظیم می‌کند:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // نمودار جدید شامل نمونه سری‌ها، دسته‌ها و مقادیر است.
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

## **تغییر رنگ پر کردن سری**

از [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getFormat) برای تنظیم پر کردن پیش‌فرض یک سری کامل استفاده کنید. اگر یک نقطه قبلاً پر کردن صریح داشته باشد، تنظیمات [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#getFormat) آن، پر کردن سری را برای آن نقطه بازنویسی می‌کند.

مثال زیر پر کردن آبی ثابت را به اولین سری اعمال می‌کند:

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

## **تغییر نام سری**

نام یک سری در کتاب‌کار داده‌های نمودار ذخیره می‌شود و معمولاً در افسانه (legend) نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ایجاد شده برای یک نمودار ستونی خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین سری را شامل می‌شود. متغیرهای نام‌گذاری‌شده در مثال زیر این ساختار را صریح می‌کنند:

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

همچنین می‌توانید سلولی را که توسط [ChartSeries.getName](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getName) ارجاع شده است به‌روزرسانی کنید. این روش از فرض کردن ردیف و ستون خاصی در نمودار موجود جلوگیری می‌کند:

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

## **دریافت رنگ پر کردن خودکار سری**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) رنگی را برمی‌گرداند که بر اساس شاخص سری و سبک نمودار محاسبه شده است. این همان رنگی است که وقتی پر کردن سری صریح تعریف نشده باشد استفاده می‌شود. فراخوانی این متد تنها رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی اختصاص نمی‌دهد.

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

رنگ‌های دقیق به سبک و تم نمودار بستگی دارند.

## **تنظیم رنگ پر کردن معکوس برای یک سری نمودار**

برای سری‌های نوار، ستون و حباب، [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#setInvertIfNegative) می‌تواند مقادیر منفی را با پر کردن متفاوت نمایش دهد. پر کردن معمولی سری را به حالت ثابت تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) اختصاص دهید. اعداد منفی در کتاب‌کار تغییر نمی‌کنند؛ فقط رنگ نمایش آن‌ها تغییر می‌یابد.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 ورق‌کار نام سری را دارد، ستون 0 نام‌های دسته و ستون 1 مقادیر را شامل می‌شود:

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

می‌توانید معکوس‌سازی را برای یک نقطه از طریق [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) فعال کنید. در مثال زیر معکوس‌سازی برای سری غیرفعال و تنها برای نقطهٔ انتخاب‌شده فعال می‌شود. همچنین مقدار منفی به نقطه اختصاص داده شده تا اثر قابل مشاهده باشد:

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

## **پاک کردن مقدار خاص یک نقطه داده**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشتیبان کتاب‌کار آن را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [ChartDataPoint.getValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#getValue) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را به‌عنوان خالی طبق تنظیمات مقادیر خالی نمودار در نظر می‌گیرد.

مثال زیر تنها نقطهٔ دوم در اولین سری را پاک می‌کند:

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

نمودارهای پراکنده از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حباب نیز از یک سلول اندازه بهره می‌گیرند. فقط سلولی را که نمایانگر مقداری است که می‌خواهید حذف کنید، پاک کنید. هنگام نیاز به نگه داشتن نقاط دیگر، از فراخوانی [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapointcollection/#clear) خودداری کنید؛ این متد تمام نقاط را از مجموعه حذف می‌کند.

## **تنظیم عرض فاصله سری**

عرض فاصله (Gap width) فاصله بین خوشه‌های نوار یا ستون مجاور است که به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. مشابه هم‌پوشانی، این مقدار به گروه سری والد تعلق دارد نه به یک سری منفرد. برای گروه، یک‌بار [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/#setGapWidth) را صدا بزنید. مقدار بزرگتر فضا بین خوشه‌ها را افزایش می‌دهد؛ مقدار کوچکتر آن‌ها را متراکم‌تر می‌کند.

مثال زیر عرض فاصله را تغییر می‌دهد و تنها ارائهٔ نهایی را ذخیره می‌کند:

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

## **سؤالات متداول**

**کدام انواع نمودار از سری داده پشتیبانی می‌کنند؟**

تمامی انواع نمودار که توسط enumeration [ChartType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/) نمایان شده‌اند از داده‌های نمودار استفاده می‌کنند، اما سری‌های آن‌ها ساختار یا تنظیمات مقدار یکسانی ندارند. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حباب از اندازه حباب نیز بهره می‌برند. روش ایجاد نقطه داده‌ای که با نوع سری مطابقت دارد، به‌کار ببرید. گزینه‌هایی مانند هم‌پوشانی و عرض فاصله فقط برای گروه‌های نوار یا ستون سازگار اعمال می‌شوند.

**یک گروه سری نمودار چیست؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات رسم سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک سری به دست می‌آید لزوماً تمام سری‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه ساخته‌شده شامل داده‌های پیش‌فرض است؟**

بله. به‌طور پیش‌فرض، [ShapeCollection.addChart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addChart) سری‌ها، دسته‌ها و مقادیر نمونه را ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعه سری و دسته را پاک کنید. یک overload نیز می‌تواند نموداری بدون دادهٔ پیش‌فرض ایجاد کند.

**اشیاء نمودار چگونه به سلول‌های کتاب‌کار متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده عنصر مربوط به نمودار را به‌روزرسانی می‌کند. هنگامی که داده‌های سفارشی می‌سازید، ردیف‌های دسته و ردیف‌های مقادیر سری را هم‌راستا نگه دارید تا هر نقطه زیر دستهٔ موردنظر ترسیم شود.

**چگونه یک نقطه را به‌جای تمام سری پاک کنم؟**

سلول مقدار مرتبط را به `null` تنظیم کنید تا موقعیت دسته نقطه به‌عنوان نقطهٔ خالی حفظ شود. فقط زمانی از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapointcollection/#clear) استفاده کنید که قصد حذف تمام نقاط آن سری را دارید. اگر دسته‌ها را نیز حذف می‌کنید، هر سری را به‌روزرسانی کنید تا مقادیرشان با مجموعهٔ دسته‌ها هم‌راستا بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقداری که از طریق [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/#setDisplayBlanksAs) پیکربندی شده، بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌عنوان فاصله، به‌عنوان مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که با معنای داده‌ٔ مفقود در ارائهٔ شما منطبق باشد.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های نوار، ستون و حباب پشتیبانی‌شده، [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#setInvertIfNegative) را فراخوانی کنید و رنگی که از [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) برمی‌گردد را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ فردی با [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) بازنویسی کنید. این روش‌ها تنها قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**زمانی که هم سری و هم نقطه قالب‌بندی شده باشند، کدام‌یک غالب می‌شود؟**

قالب‌بندی صریح نقطه داده برای آن نقطه برتری دارد. نقاط دیگر همچنان از قالب صریح سری یا، اگر قالب سری تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند هم‌پوشانی و عرض فاصله بر چیدمان کنترل می‌شوند و بازنویسی‌های قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیتی جدای برای شمار سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندر و قابلیت خواندن نمودار تعیین‌کنندهٔ حد معقول هستند.

**زمانی که ستون‌ها بیش از حد به‌هم نزدیک یا از هم دور باشند، چه کاری باید انجام دهم؟**

بر روی گروه سری والد مناسب [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/#setGapWidth) را صدا بزنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها عریض‌تر شود یا مقدار را کاهش دهید تا خوشه‌ها به هم نزدیک‌تر شوند.