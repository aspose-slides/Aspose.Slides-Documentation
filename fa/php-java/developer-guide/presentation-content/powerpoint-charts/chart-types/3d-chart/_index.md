---
title: سفارشی‌سازی نمودارهای 3بعدی در ارائه‌ها با استفاده از PHP
linktitle: نمودار 3بعدی
type: docs
url: /fa/php-java/3d-chart/
keywords:
- نمودار 3بعدی
- چرخش
- عمق
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "نمودارهای 3بعدی را در ارائه‌های PowerPoint با Aspose.Slides برای PHP از طریق Java ایجاد کنید. چرخش، نسبت‌های ارتفاع، عمق نمودار و فاصله بین سری‌ها را با مثال‌های PHP تنظیم کنید."
---
## **نمای کلی**

Aspose.Slides for PHP via Java به شما امکان می‌دهد نمای یک نمودار 3بعدی را از طریق متد [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) سفارشی کنید. این مقاله نشان می‌دهد چگونه دوران، نسبت‌های ارتفاع، عمق، محورها با زاویهٔ راست و فاصلهٔ بین سری‌ها را تنظیم کنید و سپس ارائه را در قالب PPTX ذخیره نمایید.

## **تنظیم چرخش و عمق یک نمودار 3بعدی**

مثال زیر یک [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد می‌کند و با استفاده از [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) یک نمودار ستونی 3بعدی انباشته را به اسلاید اول آن اضافه می‌نماید. این مثال سری‌ها و دسته‌بندی‌های پیش‌فرض را با دو سری که هر کدام شامل سه مقدار هستند جایگزین می‌کند. شاخص صفحه‌کار `0` صفحه‌کار دادهٔ اول نمودار را شناسایی می‌کند؛ ردیف `0` نام‌های سری‌ها را نگه می‌دارد و ستون `0` برچسب‌های دسته‌بندی را داراست.

متدهای [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) و [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) به ترتیب چرخش نمودار را به 40 و 270 درجه تنظیم می‌کنند. متد [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) عمق آن را به 150٪ از عرضش تنظیم می‌سازد، در حالی که [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) محورها را به حالت زاویهٔ راست به جای پرسپکتیو فعال می‌کند. ارائهٔ حاصل حاوی نمودار پر شده با این تنظیمات نمای 3بعدی است.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم نسبت ارتفاع یک نمودار 3بعدی**

از [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) برای تنظیم ارتفاع یک نمودار 3بعدی به عنوان درصدی از عرض آن استفاده کنید. این کار نسبت‌های صحنهٔ 3بعدی را بدون تغییر اندازهٔ شیء نمودار روی اسلاید تغییر می‌دهد.

مثال زیر یک نمودار [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) با دادهٔ پیش‌فرض ایجاد می‌کند: سه سری و چهار دسته‌بندی. این مثال سه ارائهٔ مختلف با نسبت‌های ارتفاع 50٪، 100٪ و 200٪ ذخیره می‌کند. موقعیت، عرض و ارتفاع نمودار ثابت می‌مانند. داده، چرخش، عمق، فاصلهٔ بین سری‌ها و قالب‌بندی در هر سه فایل یکسان است؛ تنها درصد ارتفاع تغییر می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

تصاویر زیر همان تنظیمات ارتفاع را در مثال معادل .NET نشان می‌دهند و با استفاده از Microsoft PowerPoint استخراج شده‌اند. درصد کمتر صحنهٔ صاف‌تری می‌سازد، در حالی که درصد بزرگتر صحنهٔ بلندتری در همان شیء نمودار ایجاد می‌کند. PowerPoint ممکن است فواصل تیک‌های محور و جایگذاری برچسب‌ها را برای تطبیق صحنه تنظیم کند.

| ارتفاع: 50% | ارتفاع: 100% | ارتفاع: 200% |
| --- | --- | --- |
| ![نمودار 3بعدی ستونی با ارتفاع تنظیم شده به 50 درصد از عرض آن](height_percent_50.png) | ![نمودار 3بعدی ستونی با ارتفاع تنظیم شده به 100 درصد از عرض آن](height_percent_100.png) | ![نمودار 3بعدی ستونی با ارتفاع تنظیم شده به 200 درصد از عرض آن](height_percent_200.png) |

این متدها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| روش | اثر |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | ارتفاع صحنهٔ 3بعدی به صورت درصدی از عرض آن. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | ارتفاع شیء نمودار روی اسلاید، بر حسب نقطه. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | عمق صحنهٔ 3بعدی به صورت درصدی از عرض آن. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | فاصلهٔ بین سری‌ها در محور عمق، به صورت درصدی از عرض مارکر. |

تنظیم ارتفاع بر نمودارهای ستونی و میله‌ای 3بعدی، شامل انواع استوانه‌ای، مخروطی و هرمی، و همچنین نمودارهای خطی، مساحت، دایره‌ای و سطحی 3بعدی تأثیر می‌گذارد. مقایسهٔ بالا از نوع تایید شدهٔ `Column3D` استفاده می‌کند. این تنظیم ظاهر نمودار دو‑بعدی `ClusteredColumn` یا نمودار `BubbleWith3D` را تغییر نمی‌دهد؛ این نام‌ها اعضای کلاس [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) هستند. برای سایر تنظیمات ظاهر نمودار، به [Chart Formatting](/slides/fa/php-java/chart-formatting/) مراجعه کنید.

## **تنظیم فاصله بین سری‌ها**

از [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) برای کنترل فاصلهٔ بین سری‌های داده در محور عمق یک نمودار 3بعدی، به صورت درصدی از عرض مارکر، استفاده کنید. مقادیر **از 0 تا 500**، شامل: `0` فاصله را حذف می‌کند، در حالی‌که مقادیر بالاتر فاصله را افزایش می‌دهند. با عمق ثابت نمودار، افزایش فاصله باعث باریک‌تر شدن مارکرها در محور عمق می‌شود.

دسته را از طریق [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) دسترسی پیدا کنید. این تنظیم برای هر سری در آن گروه اعمال می‌شود، نه فقط سری‌ای که برای دسترسی استفاده شده است. متد [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) عمق فاصله را بازمی‌گرداند و تنظیمات گروه والد را منعکس می‌کند.

این تنظیم بر نمودارهای ستونی و میله‌ای 3بعدی، شامل انواع استوانه‌ای، مخروطی و هرمی آن‌ها، و همچنین نمودارهای خطی و مساحتی 3بعدی تأثیر می‌گذارد. ظاهر بسته به این است که سری‌ها در عمق، خوشه‌ای یا انباشته مرتب شوند. برای مقایسهٔ واضح فاصله‌ها بین سری‌های جداگانه، از `ChartType::Column3D` موجود در کلاس [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) استفاده کنید.

این متدها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| روش | اثر |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | فاصلهٔ بین سری‌ها در محور عمق، به صورت درصدی از عرض مارکر. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | فاصلهٔ بین خوشه‌های میله یا ستون مجاور، به صورت درصدی از عرض میله یا ستون. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | عمق کلی نمودار، به صورت درصدی از عرض نمودار. |

مثال زیر به‌صورت خودکفا از دادهٔ پیش‌فرض نمودار استفاده می‌کند که شامل سه سری و چهار دسته‌بندی است. این مثال دو ارائهٔ دارای داده، چرخش، عرض فاصله و عمق نمودار یکسان ذخیره می‌کند؛ فقط عمق فاصله تغییر می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

تصاویر زیر همان تنظیمات عمق فاصله را در مثال معادل .NET نشان می‌دهند و با استفاده از Microsoft PowerPoint استخراج شده‌اند.

| عمق فاصله: 0% | عمق فاصله: 500% |
| --- | --- |
| ![نمودار 3بعدی ستونی بدون هیچ فاصله‌ای بین سری‌ها در محور عمق](gap_depth_0.png) | ![نمودار 3بعدی ستونی با فاصلهٔ 500 درصدی بین سری‌ها در محور عمق](gap_depth_500.png) |

## **تغییر نوع سری 3بعدی و شکل میله**

در یک نمودار استوانه‌ای خوشه‌ای، سری اول با شکل میلهٔ استوانه‌ای آغاز می‌شود. مثال مقادیر عددی برگشتی از [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) و [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) را قبل و بعد از هر تغییر چاپ می‌کند. جدول نام ثابت‌های متناظر را ارائه می‌دهد.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| تغییر به اولین سری | نوع سری | شکل میله |
| --- | --- | --- |
| ایجاد نمودار | `ClusteredCylinder` | `Cylinder` |
| تنظیم نوع سری به `ClusteredCone` | `ClusteredCone` | `Cone` |
| تنظیم شکل میله به `Box` | `ClusteredColumn3D` | `Box` |

تنظیم شکل به `Box` همچنین نوع سری را به `ClusteredColumn3D` تغییر می‌دهد. اگر کد شما بر اساس نوع سری شاخه‌بندی می‌شود، پس از تغییر شکل حتماً [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) را فراخوانی کنید. مقدار ذخیره‌شده قبل از انتساب همچنان شاخهٔ `ClusteredCone` را انتخاب می‌کند.

![مقایسهٔ PowerPoint نشان‌دهندهٔ اولین سری به‌صورت استوانه، مخروط و ستون‌های مستطیلی از چپ به راست](series-shapes.png)

## **پرسش‌های متداول**

**کدام انواع نمودارها در Aspose.Slides از حالت 3بعدی پشتیبانی می‌کنند؟**

Aspose.Slides انواع 3بعدی نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D، به‌همراه انواع 3بعدی مرتبط که از طریق کلاس [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) نمایش داده می‌شوند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) را در سند API نسخهٔ نصب‌شده خود بررسی کنید.

**آیا می‌توانم تصویر رASTER از یک نمودار 3بعدی برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید نمودار را با استفاده از [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) به تصویر تبدیل کنید یا کل اسلاید را به فرمت‌هایی مانند PNG یا JPEG رندر کنید ([render the entire slide](/slides/fa/php-java/convert-powerpoint-to-png/)). این کار وقتی نیاز به پیش‌نمایش رASTER دارید یا می‌خواهید نمودار را در اسناد، داشبوردها یا صفحات وب بدون نیاز به PowerPoint جاسازی کنید، مفید است.

**کارایی ساخت و رندر نمودارهای بزرگ 3بعدی چقدر است؟**

کارایی به حجم داده‌ها و پیچیدگی بصری بستگی دارد. برای بهترین نتایج، اثرات 3بعدی را به حداقل برسانید، از بافت‌های سنگین روی دیوارها و نواحی نمودار خودداری کنید، تعداد نقاط دادهٔ هر سری را در صورت امکان محدود کنید و خروجی را با وضوح و ابعاد مناسب برای نمایش یا چاپ هدف تنظیم کنید.