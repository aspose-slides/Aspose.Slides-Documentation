---
title: سفارشی‌سازی نمودارهای دایره‌ای در ارائه‌ها با PHP
linktitle: نمودار دایره‌ای
type: docs
url: /fa/php-java/pie-chart/
keywords:
- نمودار دایره‌ای
- مدیریت نمودار
- سفارشی‌سازی نمودار
- گزینه‌های نمودار
- تنظیمات نمودار
- گزینه‌های ترسیم
- رنگ برش
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "نمودارهای دایره‌ای را در PHP با Aspose.Slides ایجاد و سفارشی‌سازی کنید. نمودارهای ثانویه را پیکربندی کنید، برچسب‌های داده را نمایش دهید و رنگ‌های خودکار برش‌ها را در PowerPoint اعمال کنید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با نمودارهای دایره‌ای در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه گزینه‌های نمودار ثانویه را برای نمودارهای Pie of Pie و Bar of Pie پیکربندی کنید و همچنین چگونه رنگ‌رنگی خودکار برش‌ها را برای یک نمودار دایره‌ای استاندارد فعال کنید.

مثال‌ها بر وظایف سفارشی‌سازی نمودار متمرکز هستند، از جمله افزودن نمودار به یک اسلاید، تنظیم سری‌ها و برچسب‌ها، جایگزینی داده‌های پیش‌فرض نمودار با دسته‌ها و مقادیر سفارشی، و ذخیرهٔ ارائه به‌روزشده.

## **گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie**

Aspose.Slides for PHP via Java گزینه‌های نمودار ثانویه را برای نمودارهای Pie of Pie و Bar of Pie پشتیبانی می‌کند. این گزینه‌ها اندازهٔ نمودار ثانویه و نحوهٔ تقسیم نقاط داده بین دو نمودار را کنترل می‌کنند.

مثال زیر یک نمودار Pie of Pie را در یک ارائهٔ جدید ایجاد می‌کند و مقادیر نقاط داده را به‌صورت برچسب نمایش می‌دهد. متد [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) اندازهٔ نمودار ثانویه را برابر 149٪ نمودار اصلی تنظیم می‌کند. [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) تقسیم بر پایهٔ درصد را انتخاب می‌کند و [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) آستانه را بر 53٪ تنظیم می‌نماید.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // مقدارها را نمایش داده و نمودار ثانویه را پیکربندی کنید.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **انتخاب دسته‌ها برای نمودار ثانویه**

از تقسیم سفارشی استفاده کنید وقتی می‌خواهید دسته‌های خاصی را در نمودار ثانویه گروه‌بندی کنید بدون توجه به مقادیر درصدی آن‌ها. برای مثال، یک گزارش فروش ممکن است Online و Events را با هم نمایش دهد تا خوانندگان بتوانند این دو کانال را مقایسه کنند، حتی اگر این دو 35٪ و 10٪ از کل فروش را تشکیل دهند.

متد [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) را با [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) صدا بزنید و نقاط را از طریق [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) انتخاب کنید. متد [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) این مجموعه یک شاخص صفر‑پایه در سری می‌پذیرد؛ برای افزودن یک شیء نقطه داده از [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) استفاده کنید. در این مثال، شاخص 1 Online را انتخاب می‌کند و نقطهٔ شاخص 3 Events را انتخاب می‌کند. Partners نیز به‌صورت موقت اضافه می‌شود و سپس با استفاده از [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem) حذف می‌گردد.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // داده‌های پیش‌فرض را با فروش بر حسب کانال جایگزین کنید.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // Online را با شاخص صفرپایه و Events را با شیء نقطه داده انتخاب کنید.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // Partners را از انتخاب حذف کنید بدون حذف داده منبع آن.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online (35) و Events (10) به‌صورت برش‌های جداگانه در نمودار ثانویه ظاهر می‌شوند. در نمودار اصلی، آن‌ها با یک برش ترکیب‌شده با مقدار 45 نمایش داده می‌شوند، به‌همراه Retail (40) و Partners (15). حذف Partners از انتخاب سفارشی آن را در نمودار اصلی نگه می‌دارد؛ این عمل دسته یا مقدار آن را از دادهٔ منبع نمودار حذف نمی‌کند.

تصویر زیر ارائهٔ ذخیره‌شده را در PowerPoint نشان می‌دهد:

![نمودار Pie of Pie با Online و Events در نمودار ثانویه و مقدار ترکیبی 45 آن‌ها در نمودار اصلی](pie_of_pie_custom.png)

## **تنظیم رنگ‌های خودکار برش‌های نمودار دایره‌ای**

Aspose.Slides for PHP via Java می‌تواند به‌صورت خودکار برای هر برش نمودار دایره‌ای رنگ متفاوتی اختصاص دهد. مثال زیر یک نمودار دایره‌ای با عنوان مرکزی ایجاد می‌کند و داده‌های پیش‌فرض را با سه دستهٔ فصلی و مقادیر مربوطه جایگزین می‌نماید. متد [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) مقادیر 20، 50 و 30 را به‌صورت برچسب نشان می‌دهد، در حالی که [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) رنگ متمایز برای هر برش را فعال می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // یک عنوان نمودار مرکز‌گذاری‌شده اضافه کنید.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // داده‌های پیش‌فرض را با استفاده از اولین شیت کار جایگزین کنید.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // مقدارها را نمایش دهید و رنگ‌های مختلفی به برش‌ها اختصاص دهید.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**آیا انواع Pie of Pie و Bar of Pie پشتیبانی می‌شوند؟**

بله، کتابخانه [پشتیبانی می‌کند](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) یک نمودار ثانویه برای نمودارهای دایره‌ای، از جمله انواع Pie of Pie و Bar of Pie.

**آیا می‌توانم فقط نمودار را به‌عنوان تصویر (برای مثال PNG) استخراج کنم؟**

بله، می‌توانید [صادرات نمودار به‌عنوان تصویر](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (مانند PNG) را بدون استخراج کل ارائه انجام دهید.