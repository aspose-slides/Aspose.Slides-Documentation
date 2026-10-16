---
title: افزودن خطوط روند به نمودارهای ارائه در PHP
linktitle: خط روند
type: docs
url: /fa/php-java/trend-line/
keywords:
- نمودار
- خط روند
- خط روند نمایی
- خط روند خطی
- خط روند لگاریتمی
- خط روند میانگین متحرک
- خط روند چندجمله‌ای
- خط روند توان
- خط روند سفارشی
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "به‌سرعت خطوط روند را در نمودارهای PowerPoint با Aspose.Slides برای PHP از طریق Java اضافه و سفارشی کنید — راهنمایی عملی برای جذب مخاطبان شما."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides خطوط روند را به نمودارهای ارائه اضافه کنید. نشان می‌دهد چگونه یک نمودار ایجاد کرده، خطوط روند را به سری‌های نمودار اضافه کنید و با انواع مختلف خطوط روند کار کنید، از جمله نمایی، خطی، لگاریتمی، میانگین متحرک، چندجمله‌ای و توان.

همچنین توصیف می‌کند چگونه با درج یک شکل خطی، یک خط سفارشی به نمودار اضافه کنید و شامل یک بخش پرسش‌های متداول کوتاه درباره مقادیر پیش‌بینی خط روند به سمت جلو و عقب و این که آیا خطوط روند در هنگام خروجی به PDF یا SVG و هنگام رندر نمودارها به عنوان تصویر حفظ می‌شوند یا نه، می‌باشد.

## **افزودن خط روند**

از [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) برای افزودن خط روند به یک سری نمودار استفاده کنید و نوع آن را با [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/) انتخاب کنید. این مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند و دو خط روند به هر کدام از سه سری آن اضافه می‌کند.

خط روند نمایی معادله و مقدار R‑squared خود را از طریق [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) و [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/) مخفی می‌کند، در حالی که خط روند خطی به رنگ قرمز است. خط روند لگاریتمی از [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) برای برچسب سفارشی استفاده می‌کند. میانگین متحرک از یک [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) سه نقطه داده‌ای و یک [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/) سفارشی بهره می‌برد.

خط روند چندجمله‌ای دارای مرتبه سه است که از طریق [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/) تنظیم می‌شود و یک دسته به سمت جلو گسترش می‌یابد با [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/). خط روند توان یک دسته به سمت عقب گسترش می‌یابد با [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم مقطع خط روند**

از [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) برای ثابت کردن مقدار Y خط روند در X = 0 استفاده کنید. این تنظیم برای خطوط روند خطی، نمایی و چندجمله‌ای پشتیبانی می‌شود.

به عنوان مثال، یک مدل هزینه تولید ممکن است نیاز داشته باشد که از هزینه‌های ثابت شناخته‌شده 100 شروع شود، حتی وقتی اندازه‌گیری‌ها در حجم‌های تولید غیر صفر مبنای متفاوتی نشان می‌دهند. برای یک خط روند خطی، ثابت کردن مقطع معادله `y = ax + b` را به `b = 100` محدود می‌کند؛ شیب تحت این محدودیت به داده‌ها سازگار می‌شود. این کار به سادگی یک خط قبلاً سازگارشده را جابه‌جا نمی‌کند. تنظیمات عبور محور، مکان تقاطع محورهای نمودار را کنترل می‌کند، نه ضریب‌های خط روند سازگارشده.

مثال زیر یک نمودار پراکنده (XY) با حجم‌های تولید از 1 تا 4 و هزینه‌های 170، 200، 230 و 260 ایجاد می‌کند. نمودار را با مقطع خودکار پیش‌فرض ذخیره می‌کند، مقطع را به 100 تنظیم می‌کند و یک فایل PPTX دوم ذخیره می‌کند. دو فایل تنها در تنظیم مقطع متفاوت هستند. خط روند معادله خود را نمایش می‌دهد و به X = 0 بازمی‌گردد.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

با محاسبه خودکار، این داده‌ها `y = 30x + 140` را تولید می‌کنند. تنظیم مقطع به 100 به‌جای آن تقریباً `y = 43.33x + 100` می‌شود: مقدار سازگارشده در صفر با مبنای شناخته‌شده مطابقت دارد، در حالی که خط دیگر از هر نقطه داده عبور نمی‌کند.

| مقطع خودکار | مقطع ثابت 100 |
| --- | --- |
| ![خط روند خطی با یک مقطع محاسبه‌شده خودکار 140](intercept-automatic.png) | ![خط روند خطی با یک مقطع ثابت 100](intercept-fixed.png) |

هر دو تصویر از داده‌ها و مقیاس‌های محور یکسان استفاده می‌کنند. خطوط روند به X = 0 گسترش یافته‌اند تا مقاطع خود را نشان دهند.

به‌صورت پیش‌فرض، [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) مقدار `NaN` را برمی‌گرداند که نمایانگر مقطع نامشخص است نه صفر. سپس مقطع به‌صورت خودکار از داده‌ها محاسبه می‌شود.

## **افزودن خط سفارشی**

یک خط سفارشی شکلی است که بر روی نمودار رسم می‌شود نه یک خط روند محاسبه‌شده از داده‌های سری. این مثال از [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) برای افزودن یک خط افقی به اسلاید بالای نمودار استفاده می‌کند. موقعیت خط در مختصات اسلاید، به‌پویین اندازه‌گیری می‌شود، بنابراین از لبه چپ نمودار شروع می‌شود و تا نیمه ارتفاع نمودار می‌افتد. عرض آن با عرض نمودار منطبق است. [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) به خط یک رنگ قرمز پیوسته می‌دهد.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **پرسش‌های متداول**

**«پیشرو» و «پسرو» برای یک خط روند چه معنایی دارند؟**

آنها طول‌های خط روند هستند که به‌صورت پیشرو/پسرو پروجکشن می‌شوند: برای نمودارهای پراکنده (XY) — به‌واحدهای محور؛ برای نمودارهای غیرپراکنده — به‌تعداد دسته‌ها. فقط مقادیر غیر منفی مجاز هستند.

**آیا خط روند هنگام خروجی ارائه به PDF یا SVG یا هنگام رندر اسلاید به تصویر حفظ می‌شود؟**

بله. Aspose.Slides ارائه‌ها را به [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/) یا [SVG](/slides/fa/php-java/render-a-slide-as-an-svg-image/) تبدیل می‌کند و نمودارها را به تصویر رندر می‌کند؛ خطوط روند، به‌عنوان بخشی از نمودار، در این عملیات‌ها حفظ می‌شوند. همچنین روشی برای [صدور تصویر نمودار](/slides/fa/php-java/create-shape-thumbnails/) وجود دارد.