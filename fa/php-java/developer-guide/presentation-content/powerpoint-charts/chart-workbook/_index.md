---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با PHP
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/php-java/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده‌های نمودار
- سلول کتاب‌کار
- برچسب داده
- برگه‌کار
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "Aspose.Slides برای PHP از طریق Java را کشف کنید: به‌راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **مروری کلی**

این مقاله نحوه کار با کتاب‌کارهای نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به‌عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های برگه‌ها دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به‌عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را بازیابی کنید و هنگامی که کتاب‌کار در دسترس باشد، داده‌های نمودار را ویرایش کنید.

برای سلول‌های کتاب‌کار که نشان‌دهنده داده‌های گمشده هستند، به [Control the Display of Empty Cells](/slides/fa/php-java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر و مقایسهٔ نمودار خطی برای حالت‌های نمایش موجود را ببینید.

## **دریافت داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) برای کنترل اینکه آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی برگهٔ کار بگیرد یا نه استفاده کنید. مقدار `true` باعث می‌شود تنها سلول‌های قابل مشاهده رسم شوند و مقدار `false` هر دو سلول قابل مشاهده و مخفی را شامل می‌شود. این تنظیم فقط نحوهٔ رسم نمودار را کنترل می‌کند؛ ردیف‌ها یا ستون‌های برگهٔ کار را مخفی یا آشکار نمی‌کند.

[sample presentation](hidden-source-data.pptx) یک نمودار ستونی به‌عنوان اولین شکل در اولین اسلاید خود دارد. برگهٔ کار تعبیه‌شده، `Sheet1`، دارای بازهٔ منبع `A1:C4` است. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آنها همچنان مقدار دارند.

| ردیف برگه | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) دسترسی پیدا کنید و با [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) وضعیت مخفی بودن آنها را بررسی کنید. این روش وضعیت مخفی را بدون تغییر آن گزارش می‌کند. در این فایل، B2 قابل مشاهده است، B3 به ردیف مخفی تعلق دارد و C2 به ستون مخفی؛ مثال به ترتیب `false`، `true` و `true` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم رسم، داده‌های نمودار را تازه کنید: کتاب‌کار تعبیه‌شده را با [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) حفظ کنید و با [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) دوباره بارگذاری کنید. هنگام شامل کردن تمام سلول‌ها، از [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) نیز برای بازگرداندن بازهٔ کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. فقط تغییر پرچم کافی نیست تا داده‌های کش‌شدهٔ نمونهٔ این نمودار و برچسب‌های دسته به‌روز شوند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // داده‌های نمودار را از کتاب‌کار تعبیه‌شده تازه کنید.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // بازهٔ منبع کامل را بازیابی کنید، شامل دسته‌های مخفی.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

مثال دو نسخهٔ ارائه را ذخیره می‌کند: یکی فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20) و دیگری با تمام شش مقدار. تصاویر زیر دو حالت رسم را نشان می‌دهند. ردیف 3 و ستون C در هر دو کتاب‌کار تعبیه‌شده مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | تمام سلول‌ها (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی حاوی مقدار با یک سلول خالی متفاوت است. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) نحوهٔ نمایش مقادیر گمشده را کنترل می‌کند؛ این روش داده‌های منبع مخفی را شامل یا مستثنی نمی‌کند. برای مثال به [Control the Display of Empty Cells](/slides/fa/php-java/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **دریافت بازهٔ دادهٔ نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائهٔ موجود، بازه‌های منبع را بررسی کنید تا مشخص کنید هر نمودار از کدام سلول‌های برگهٔ کار استفاده می‌کند. متد [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) بازهٔ دادهٔ فعلی را به‌صورت فرمولی که شامل نام برگهٔ کار است، مانند `Sheet1!$A$1:$D$5` برمی‌گرداند. در اینجا `Sheet1` نام برگهٔ کار است، `!` آن را از بازهٔ سلول‌ها جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را به‌صورت شامل شمول مشخص می‌کند. علامت دلار نشانگر ارجاع مطلق به ردیف و ستون است.

این متد بازهٔ فعلی را بدون تغییر نمودار یا کتاب‌کار می‌خواند. اگر نمودار از کتاب‌کاری به‌عنوان منبع داده استفاده نکند، استثنایی پرتاب می‌شود. برای اطلاعات بیشتر به [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و برای هر اسلاید شکل‌های موجود را برای نمودارها بررسی می‌کند. نام هر نمودار و بازهٔ منبع آن را چاپ می‌کند. اگر نمودار از کتاب‌کار استفاده نکند، پیام مربوطه را چاپ کرده و به نمودار بعدی ادامه می‌دهد.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **خواندن و نوشتن دادهٔ نمودار از کتاب‌کار**

Aspose.Slides for PHP via Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) و [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) را فراهم می‌کند که امکان خواندن و نوشتن کتاب‌کارهای دادهٔ نمودار (شامل داده‌های ویرایش‌شده با Aspose.Cells) را می‌دهند. **توجه** داشته باشید که دادهٔ نمودار باید به همان شکل یا ساختاری مشابه منبع سازماندهی شود.

این مثال از ارائه‌ای با یک نمودار به‌عنوان اولین شکل در اولین اسلاید استفاده می‌کند. کتاب‌کار تعبیه‌شده را به‌صورت آرایهٔ بایتی می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را بازمی‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **اعتبارسنجی چیدمان نمودار پس از تغییر کتاب‌کار**

وقتی کتاب‌کار تعبیه‌شده را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شکست [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) با خطای شاخص‑بیرون‑از‑محدودیت شود. قبل از نوشتن کتاب‌کار به‌روز شده، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل در اولین اسلاید است استفاده می‌کند. نظرات نشان می‌دهند که ویرایش کتاب‌کار در کجا اتفاق می‌افتد؛ مثال اجرایی کتاب‌کار اصلی را بازمی‌نویسد و چیدمان را در حافظه اعتبارسنجی می‌کند.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // در اینجا بایت‌های کتاب‌کار را اصلاح کنید، برای مثال با استفاده از Aspose.Cells.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

پاک کردن مجموعه‌ها قبل از نوشتن کتاب‌کار، مراجع داده‌های منقضی‌شده را حذف می‌کند. قبل از استفاده از نمودار، هر سری و نگاشت دستهٔ موردنیاز را برای کتاب‌کار به‌روزرسانی‌شده بازسازی کنید.

## **تنظیم قالب‌های عددی سفارشی برای سلول‌های کتاب‌کار**

از [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) برای کنترل نحوهٔ نمایش مقادیر عددی در کتاب‌کار تعبیه‌شدهٔ یک نمودار استفاده کنید. برای مثال، یک گزارش ممکن است نیاز داشته باشد نرخ تبدیل به‌صورت درصد با چهار رقم اعشار و ضریب با پنج رقم اعشار نمایش داده شود. هر دو مقدار را عددی نگه دارید تا برای محاسبات و رسم نمودار در دسترس باشند.

یک قالب عددی صرفاً نمایش را تغییر می‌دهد، نه مقدار ذخیره‌شده. قالب `0.0000%` عدد `0.125` را به‌صورت `12.5000%` نشان می‌دهد؛ عدد ذخیره‌شده همچنان `0.125` است. به‌طور مشابه، `0.00000` عدد `0.1234567` را به‌صورت `0.12346` نمایش می‌دهد بدون اینکه مقدار ذخیره‌شده گرد شود. اگر قالب سفارشی یک رشتهٔ خالی (`""`) باشد، قالب بازگردانده‌شده توسط [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) استفاده می‌شود.

مثال زیر یک نمودار ستونی ایجاد می‌کند و سلول‌های آن را از طریق [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) دسترسی می‌دهد. در برگهٔ 0، B2 حاوی نرخ تبدیل و C2 حاوی ضریب است. هر دو سلول مقادیر نمودار را تأمین می‌کنند. مثال همچنین برچسب‌های مقدار را که به قالب‌های منبع پیوند دارند، فعال می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

قالب‌های سلول کتاب‌کار جدا از قالب‌های دیگری هستند که مستقیماً بر محورهای نمودار یا برچسب‌های داده تنظیم می‌شوند. در این مثال، هر برچسب مقدار سلول منبع خود را نشان می‌دهد زیرا [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) روی `true` تنظیم شده و [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) نیز روی `true` است. پس از ذخیره و بازگشایی ارائه، برچسب‌ها `12.5000%` و `0.12346` را نشان می‌دهند، همان‌طور که در زیر می‌بینید. محور عمودی قالب عددی خود را دارد که با [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) به `0.00` تنظیم شده و [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) روی `false` است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم پیوند به منبع آن را به `false` تنظیم کنید و با [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) قالبی اختصاص دهید. این کار قالب سلول کتاب‌کار را تغییر نمی‌دهد. برای مثال، قالب مستقل `0.00` مقدار اول را به `0.13` نمایش می‌دهد، در حالی که B2 همچنان `12.5000%` را نشان می‌دهد. برای قالب‌بندی مستقیم برچسب‌ها به [Chart Data Labels](/slides/fa/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) مراجعه کنید.

تصویر زیر پس از بازگشایی ارائه ذخیره‌شده رندر شده است:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **تخصیص یک سلول کتاب‌کار به‌عنوان برچسب دادهٔ نمودار**

می‌توانید متن سلول‌های کتاب‌کار را به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اولین اسلاید یک ارائهٔ موجود اضافه می‌کند. از سلول‌های A10:A12 در برگهٔ 0 برای سه برچسب اول در سری اول استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌سازد و ارائه به‌روزرسانی‌شده را ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **مدیریت برگه‌ها**

متد [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) دسترسی به برگه‌های موجود در یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر برگه را در کنسول چاپ می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **مشخص کردن نوع منبع داده**

مقدارهای نقاط سری می‌توانند به‌صورت مستقیم به‌عنوان مقادیر عددی literal ذخیره شوند. برای مثال کامل به [Set Series Values Using Numeric Literals](/slides/fa/php-java/chart-series/#set-series-values-using-numeric-literals) مراجعه کنید. نوع منبع مقادیر نقطه‌ای جدا از پیکربندی کتاب‌کار داخلی یا خارجی نمودار است؛ استفاده از عددهای literal به‌تنهایی کتاب‌کار تعبیه‌شده را حذف نمی‌کند.

این مثال یک نمودار ستونی 3‑بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده متفاوت تنظیم می‌کند. نام اول از یک literal رشته‌ای استفاده می‌کند؛ نام دوم از سلول C1 در برگهٔ 0 می‌گیرد. شمارش [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روزرسانی‌شده ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تشخیص فرمت‌های پشتیبانی‌نشدهٔ کتاب‌کار تعبیه‌شده**

Aspose.Slides از فرمت کتاب‌کار باینری اکسل (.xlsb) که ممکن است در برخی نمودارها تعبیه شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد `getEmbeddedWorkbookType` روی [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) فرمت‌های پشتیبانی‌نشده را شناسایی کنید و آن نمودارها را عبور دهید. این مثال شکل‌های اولین اسلاید یک ارائهٔ موجود را بررسی می‌کند، اشکال غیرنموداری را عبور می‌دهد و برای هر نموداری که کتاب‌کار .xlsb تعبیه دارد، پیام تشخیصی چاپ می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // در اینجا دادهٔ کتاب‌کار پشتیبانی‌شدهٔ نمودار را بخوانید یا اصلاح کنید.
    }
} finally {
    $presentation->dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به‌عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) و [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) برای خروجی‌گیری کتاب‌کار نمودار تعبیه‌شده به یک فایل و پیوند نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را صادر می‌کند. پس از نوشتن کامل فایل، کتاب‌کار خارجی را به‌عنوان منبع دادهٔ نمودار اختصاص می‌دهد و سپس ارائهٔ پیوندشده را ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **تنظیم یک کتاب‌کار خارجی**

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) می‌توانید یک کتاب‌کار خارجی را به‌عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد می‌تواند مسیر کتاب‌کار خارجی را به‌روزرسانی کند (اگر کتاب‌کار جابه‌جا شده باشد).

اگرچه نمی‌توانید داده‌های کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع را ویرایش کنید، همچنان می‌توانید از این کتاب‌کارها به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که برگهٔ کاری به نام `Sheet1` شامل یک نام سری در B1، نام دسته‌ها در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را پیوند می‌دهد و با استفاده از [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) بازهٔ A1:B4 را به یک سری و سه دسته نگاشت می‌کند. سپس ارائه با نمودار پیوندشده را ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

پارامتر `updateChartData` متد [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) تعیین می‌کند که آیا کتاب‌کار بارگذاری شود یا نه.

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود. دادهٔ نمودار از کتاب‌کار هدف بارگذاری یا به‌روز نمی‌شود، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `true` باشد، دادهٔ نمودار از کتاب‌کار هدف به‌روز می‌شود.

مثال زیر یک URL جایگزین با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای را حفظ می‌کند و ارائه را بدون بارگذاری کتاب‌کار در دسترس نیست ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **دریافت مسیر کتاب‌کار منبع دادهٔ خارجی یک نمودار**

برای شناسایی کتاب‌کار پیوندشده به یک نمودار، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را دریافت کنید.

این مثال اولین شکل در اولین اسلاید یک ارائهٔ دارای کتاب‌کار خارجی پیوندشده را بررسی می‌کند. اگر نمودار پیوندی به کتاب‌کار خارجی باشد، [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) را در کنسول چاپ می‌کند. سپس یک نسخهٔ کپی از ارائه را ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **ویرایش دادهٔ نمودار**

می‌توانید داده‌های کتاب‌کارهای خارجی را همان‌گونه که تغییرات در محتویات کتاب‌کارهای داخلی انجام می‌دهید، ویرایش کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، استثنایی پرتاب می‌شود.

این مثال از یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی قابل دسترس پیوند دارد استفاده می‌کند. مقدار پشتیبانی‌شده توسط سلول اولین نقطهٔ داده در اولین سری را به 100 تنظیم می‌کند و ارائه به‌روزرسانی‌شده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوندشده را به‌روزرسانی کند؛ بنابراین برای حفظ کتاب‌کار اصلی از یک کپی استفاده کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **بازیابی کتاب‌کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی که مفقود یا در دسترس نیست استفاده می‌کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، یک [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) ایجاد کنید، [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) را فراخوانی کنید و [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) را به `true` تنظیم کنید.

مثال PHP زیر داده‌های کتاب‌کار را برای یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی در دسترس نیست، بازیابی می‌کند. داده‌های بازیابی‌شده را از طریق [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) و [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) دسترسی می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // در اینجا داده‌های کتاب‌کار بازیابی‌شده را بخوانید یا اصلاح کنید.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنایی پرتاب می‌کند. بازیابی را فقط وقتی که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ مقبول است فعال کنید، زیرا ممکن است کش شامل تغییرات انجام‌شده در کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **سوالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به کتاب‌کار خارجی یا تعبیه‌شده پیوند دارد؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) و یک [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) است؛ اگر منبع کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی تعیین کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که در منابع شبکه‌ای/به‌اشتراک‌گذاری قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای دوردست از طریق Aspose.Slides پشتیبانی نمی‌شود — فقط می‌توان آنها را منبع استفاده کرد.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) را ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبانی‌شده توسط سلول می‌تواند فایل XLSX محلی پیوندشده را نیز به‌روزرسانی کند. اگر نسخهٔ اصلی باید دست‌نخورده بماند، یک کپی از کتاب‌کار استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شود، باید چه کاری انجام دهم؟**

Aspose.Slides هنگام پیوند، رمز عبور را قبول نمی‌کند. یک روش معمول این است که پیش از پیوند، حفاظت را حذف کنید یا یک کپی رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/java/)) آماده کنید و به آن پیوند دهید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی یکسان پیوند داشته باشند؟**

بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار منعکس خواهد شد.