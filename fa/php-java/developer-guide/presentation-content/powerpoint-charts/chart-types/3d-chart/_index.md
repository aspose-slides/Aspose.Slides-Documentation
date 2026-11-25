---
title: سفارشی‌سازی نمودارهای 3D در ارائه‌ها با استفاده از PHP
linktitle: نمودار 3D
type: docs
url: /fa/php-java/3d-chart/
keywords:
- نمودار 3D
- چرخش
- عمق
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "نمودارهای 3D را در ارائه‌های PowerPoint با Aspose.Slides برای PHP از طریق Java ایجاد کنید. چرخش، نسبت‌های ارتفاع، عمق نمودار و فاصله بین سری‌ها را با مثال‌های PHP تنظیم کنید."
---
## **نمای کلی**

Aspose.Slides for PHP via Java به شما امکان می‌دهد نمای یک نمودار 3D را از طریق متد [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) سفارشی کنید. این مقاله نشان می‌دهد چگونه دوران، نسبت‌های ارتفاع، عمق، محورهای زاویه‌دار، و فاصله بین سری‌ها را تنظیم کنید و سپس ارائه را به فرمت PPTX ذخیره کنید.

## **تنظیم دوران و عمق یک نمودار 3D**

مثال زیر یک [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد می‌کند و از [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) برای افزودن یک نمودار ستونی 3D انباشته به اسلاید اول آن استفاده می‌کند. این مثال سری‌ها و دسته‌های پیش‌فرض را با دو سری که هر کدام شامل سه مقدار هستند، جایگزین می‌کند. اندیس جدول‌کار `0` شیت داده اول نمودار را شناسایی می‌کند؛ ردیف `0` نام‌های سری را نگه می‌دارد و ستون `0` برچسب‌های دسته را.

متدهای [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) و [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) به ترتیب دوران نمودار را به 40 و 270 درجه تنظیم می‌کنند. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) عمق آن را به 150٪ از عرض آن تنظیم می‌کند، در حالی که [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) به جای پرسپکتیو، محورهای زاویه‌دار را فعال می‌کند. ارائه حاصل شامل نمودار پر شده با این تنظیمات نمای 3D است.

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

## **اعمال پر کردن تصویری به سطح یک نمودار 3D**

می‌توانید [دیوار کناری](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/)، [دیوار پشتی](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/)، و [کف](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) یک نمودار 3D را به طور مستقل پر کنید. نوع پر کردن سطح را با [نوع پر کردن](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) به `Picture` تنظیم کنید و یک تصویر اختصاص دهید. هم ‎[حالت پر کردن تصویر](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/)‎ و هم ‎[نوع تصویر](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/)‎ سطح را به `Stretch` تنظیم کنید تا یک نسخه از تصویر بر سراسر سطح کشیده شود.

[arrow.png](arrow.png) را کنار اسکریپت PHP ذخیره کنید. این مثال نمودار را می‌چرخاند و حداکثر مقدار محور عمودی را افزایش می‌دهد تا کف بین ستون‌ها قابل مشاهده باشد. سپس اسلاید را دو بار کپی می‌کند و پیکان را بر سطح متفاوتی در هر اسلاید اعمال می‌کند. هر سه نمودار داده، زاویه نمایش و پس‌زمینه یکسانی دارند.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Microsoft PowerPoint اسلایدهای سه‌گانه را به صورت زیر نشان می‌دهد.

| دیوار کناری | دیوار پشتی | کف |
| --- | --- | --- |
| ![پیکان اشاره به داخل نمودار در امتداد دیوار کناری](side-wall.png) | ![پیکان اشاره به راست در طول دیوار پشتی](back-wall.png) | ![پیکان اشاره به راست در طول کف بین ستون‌ها](floor.png) |

## **تنظیم نسبت‌های ارتفاع یک نمودار 3D**

از [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) برای تنظیم ارتفاع یک نمودار 3D به صورت درصدی از عرض آن استفاده کنید. این کار نسبت‌های صحنه 3D را بدون تغییر اندازه شیء نمودار بر روی اسلاید تغییر می‌دهد.

مثال زیر یک نمودار [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) با داده پیش‌فرض ایجاد می‌کند: سه سری و چهار دسته. این مثال سه ارائه با نسبت‌های ارتفاع 50٪، 100٪ و 200٪ ذخیره می‌کند. موقعیت، عرض و ارتفاع نمودار ثابت می‌مانند. داده‌ها، دوران، عمق، فاصله بین سری‌ها و قالب‌بندی در هر سه فایل یکسان است؛ فقط درصد ارتفاع تغییر می‌کند.

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

تصاویر زیر تنظیمات یکسان ارتفاع را در مثال معادل .NET نشان می‌دهند و با استفاده از Microsoft PowerPoint صادر شده‌اند. درصد کوچکتر صحنه‌ای مسطح‌تر تولید می‌کند، در حالی که درصد بزرگتر صحنه‌ای بلندتر درون همان شیء نمودار ایجاد می‌کند. PowerPoint ممکن است بازه‌های تیک محور و مکان برچسب‌ها را برای سازگار کردن صحنه تنظیم کند.

| ارتفاع: 50% | ارتفاع: 100% | ارتفاع: 200% |
| --- | --- | --- |
| ![نمودار ستونی 3D با ارتفاع تنظیم‌شده به 50 درصد از عرض آن](height_percent_50.png) | ![نمودار ستونی 3D با ارتفاع تنظیم‌شده به 100 درصد از عرض آن](height_percent_100.png) | ![نمودار ستونی 3D با ارتفاع تنظیم‌شده به 200 درصد از عرض آن](height_percent_200.png) |

این متدها جنبه‌های مختلف نمودار را کنترل می‌کنند:

| متد | اثر |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | ارتفاع صحنه 3D به عنوان درصدی از عرض آن. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | ارتفاع شیء نمودار بر روی اسلاید، به پوینت. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | عمق صحنه 3D به عنوان درصدی از عرض آن. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | فاصله بین سری‌ها در امتداد محور عمق، به عنوان درصدی از عرض مارکر. |

تنظیم ارتفاع بر نمودارهای ستونی و میله‌ای 3D، شامل انواع استوانه‌ای، مخروطی و هرمی، و همچنین نمودارهای خطی، ناحیه‌ای، کیکی و سطحی 3D تأثیر می‌گذارد. مقایسه فوق از نوع تأیید‌شده `Column3D` استفاده می‌کند. این تنظیم ظاهر نمودار دو‌بعدی `ClusteredColumn` یا نمودار `BubbleWith3D` را تغییر نمی‌دهد؛ این نام‌ها اعضای کلاس [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) هستند. برای تنظیمات دیگر ظاهر نمودار، به [قالب‌بندی نمودار](/slides/fa/php-java/chart-formatting/) مراجعه کنید.

## **تنظیم فاصله بین سری‌ها**

از [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) برای کنترل فاصله بین سری‌های داده در امتداد محور عمق یک نمودار 3D استفاده کنید؛ مقدار بر حسب درصدی از عرض مارکر بیان می‌شود. از مقادیر **0 تا 500** استفاده کنید: `0` فاصله را حذف می‌کند، در حالی که مقادیر بزرگ‌تر فاصله را افزیش می‌دهند. با عمق ثابت نمودار، افزایش فاصله باعث نازک‌تر شدن مارکرها در محور عمق می‌شود.

به گروه از طریق [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) دسترسی پیدا کنید. این تنظیم برای هر سری‌ای در آن گروه اعمال می‌شود، نه فقط سری‌ای که برای دسترسی استفاده شده است. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) فاصله عمق را بر می‌گرداند و تنظیمات گروه والد را نشان می‌دهد.

این تنظیم بر نمودارهای ستونی و میله‌ای 3D، شامل انواع استوانه‌ای، مخروطی و هرمی، و همچنین نمودارهای خطی و ناحیه‌ای 3D تأثیر می‌گذارد. ظاهر بستگی به این دارد که سری‌ها در عمق، خوشه‌ای یا انباشته چیده شوند. برای مقایسه واضح فاصله‌ها بین سری‌های جداگانه، از `ChartType::Column3D` موجود در کلاس [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) استفاده کنید.

این متدها جنبه‌های مختلف نمودار را کنترل می‌کنند:

| متد | اثر |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | فاصله بین سری‌ها در امتداد محور عمق، به عنوان درصدی از عرض مارکر. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | فاصله بین خوشه‌های میله یا ستون مجاور، به عنوان درصدی از عرض میله یا ستون. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | عمق کلی نمودار، به عنوان درصدی از عرض نمودار. |

مثال زیر به‌صورت خودکفا از داده پیش‌فرض نمودار استفاده می‌کند که شامل سه سری و چهار دسته است. این مثال دو ارائه با داده، دوران، عرض شکاف و عمق نمودار یکسان ذخیره می‌کند؛ تنها عمق شکاف تغییر می‌کند.

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

تصاویر زیر تنظیمات یکسان عمق شکاف را در مثال معادل .NET نشان می‌دهند و با استفاده از Microsoft PowerPoint صادر شده‌اند.

| عمق فاصله: 0% | عمق فاصله: 500% |
| --- | --- |
| ![نمودار ستونی 3D بدون فاصله بین سری‌ها در امتداد محور عمق](gap_depth_0.png) | ![نمودار ستونی 3D با فاصله 500 درصدی بین سری‌ها در امتداد محور عمق](gap_depth_500.png) |

## **تغییر نوع سری 3D و شکل میله**

در یک نمودار استوانه‌ای خوشه‌ای، سری اول با شکل میله استوانه‌ای شروع می‌شود. مثال مقدارهای عددی برگشتی توسط [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) و [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) را قبل و بعد از هر تغییر چاپ می‌کند. جدول نام ثابت‌های مربوطه را نشان می‌دهد.

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

| تغییر به سری اول | نوع سری | شکل میله |
| --- | --- | --- |
| ایجاد نمودار | `ClusteredCylinder` | `Cylinder` |
| تعیین نوع سری به `ClusteredCone` | `ClusteredCone` | `Cone` |
| تعیین شکل میله به `Box` | `ClusteredColumn3D` | `Box` |

تنظیم شکل به `Box` همچنین نوع سری را به `ClusteredColumn3D` تغییر می‌دهد. اگر کد شما بر اساس نوع سری شاخه‌بندی می‌کند، پس از تغییر شکل باید [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) را فراخوانی کنید. مقدار کش‌شده قبل از تخصیص هنوز شاخه `ClusteredCone` را انتخاب می‌کند.

![مقایسه PowerPoint نشان‌دهنده سری اول به صورت استوانه‌ها، مخروط‌ها و ستون‌های مستطیلی از چپ به راست](series-shapes.png)

## **پرسش‌های متداول**

**کدام انواع نمودار در Aspose.Slides حالت 3D را پشتیبانی می‌کنند؟**

Aspose.Slides انواع 3D نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D، به‌همراه انواع 3D مرتبط که از طریق کلاس [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) در دسترس هستند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) را در مرجع API نسخه نصب شده خود بررسی کنید.

**آیا می‌توانم تصویر رستری از یک نمودار 3D برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید یک نمودار را با استفاده از [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) به تصویر صادر کنید یا کل اسلاید را با روش [render the entire slide](/slides/fa/php-java/convert-powerpoint-to-png/) به فرمت‌های PNG یا JPEG تبدیل کنید. این کار هنگامی مفید است که به پیش‌نمایش رستری نیاز دارید یا می‌خواهید نمودار را بدون نیاز به PowerPoint در اسناد، داشبوردها یا صفحات وب جاسازی کنید.

**کارایی ساخت و رندر نمودارهای 3D بزرگ چقدر است؟**

کارایی به حجم داده و پیچیدگی بصری وابسته است. برای بهترین نتایج، اثرات 3D را به حداقل برسانید، از تکستچرهای سنگین بر روی دیوارها و نواحی نمودار خودداری کنید، تعداد نقاط داده در هر سری را در صورت امکان محدود کنید و خروجی را با وضوح و ابعاد مناسب برای نمایش یا چاپ هدف تنظیم کنید.