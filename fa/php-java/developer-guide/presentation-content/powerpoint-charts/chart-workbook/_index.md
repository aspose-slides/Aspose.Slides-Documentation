---
title: "مدیریت دفترچه کارهای نمودار در ارائه‌ها با استفاده از PHP"
linktitle: "دفترچه کار نمودار"
type: docs
weight: 70
url: /fa/php-java/chart-workbook/
keywords:
- "دفترچه کار نمودار"
- "داده‌های نمودار"
- "سلول دفترچه کار"
- "برچسب داده"
- "کاربرگ"
- "منبع داده"
- "دفترچه کار خارجی"
- "داده خارجی"
- "کش نمودار"
- "بازگردانی دفترچه کار"
- "PowerPoint"
- "ارائه"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides برای PHP از طریق Java را کشف کنید: به‌راحتی دفترچه کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه شما به‌صورت کارآمد سازماندهی شود."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با دفترچه‌های کار نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های دفترچه کار بخوانید و بنویسید، از سلول‌های دفترچه کار به عنوان برچسب داده‌های نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با دفترچه‌های کار خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک دفترچه کار خارجی ایجاد و اختصاص دهید، مسیر یک دفترچه کار خارجی متصل به نمودار را دریافت کنید و داده‌های نمودار را زمانی که دفترچه کار در دسترس باشد ویرایش کنید.

برای سلول‌های دفترچه کاری که داده‌های گمشده را نشان می‌دهند، به [کنترل نمایش سلول‌های خالی](/slides/fa/php-java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر و مقایسه‌ی نمودار خطی بین حالت‌های نمایش موجود را ببینید.

## **شامل کردن داده‌ها از سطرها و ستون‌های مخفی**

از [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) برای کنترل این که آیا نمودار فقط از سلول‌های قابل مشاهده یا از سلول‌های مخفی نیز داده می‌گیرد استفاده کنید. مقدار `true` باعث می‌شود فقط سلول‌های قابل مشاهده رسم شوند و مقدار `false` هر دو نوع سلول را شامل می‌شود. این تنظیم فقط نمودار را تحت تأثیر قرار می‌دهد؛ سطرها یا ستون‌های کاربرگ را مخفی یا آشکار نمی‌کند.

[نمونه ارائه](hidden-source-data.pptx) شامل یک نمودار ستونی به عنوان اولین شکل در اسلاید اول است. کاربرگ جاسازی‌شده، `Sheet1`، دارای بازه منبع `A1:C4` است. سطر 3 و ستون C مخفی هستند، اما سلول‌های آنها هنوز مقدار دارند.

| سطر کاربرگ | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (سطر مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) دسترسی پیدا کنید و با [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) وضعیت مخفی بودن آنها را بررسی کنید. این متد وضعیت مخفی را بدون تغییر آن گزارش می‌دهد. در این فایل، B2 قابل مشاهده است، B3 به سطر مخفی تعلق دارد و C2 به ستون مخفی؛ مثال به ترتیب `false`، `true` و `true` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم رسم، داده‌های نمودار را تازه کنید: دفترچه کار جاسازی‌شده را با [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) نگه دارید و با [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) مجدداً بارگذاری کنید. هنگام شامل کردن همه سلول‌ها، همچنین از [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) برای بازگرداندن بازه کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. فقط تغییر پرچم کافی نیست تا داده‌های کش‌شدهٔ نمونه و برچسب‌های دسته تازه شوند.

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

            // داده‌های نمودار را از دفترچه کار جاسازی‌شده تازه کنید.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // بازگرداندن بازه منبع کامل، شامل دسته‌های مخفی.
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

مثال دو نسخهٔ ارائه را ذخیره می‌کند: یکی فقط با مقادیر قابل مشاهده خرده‌فروشی (10 و 20) و دیگری با تمام شش مقدار. تصاویر زیر حالت‌های رسم را نشان می‌دهند. سطر 3 و ستون C در هر دو دفترچه کار جاسازی‌شده مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | همه سلول‌ها (`false`) |
| --- | --- |
| ![فقط سلول‌های قابل مشاهده: مقادیر خرده‌فروشی 10 و 20 برای ژانویه و مارس.](hidden_cells_True.png) | ![همه سلول‌ها: مقادیر خرده‌فروشی و عمده‌فروشی برای ژانویه، فوریه و مارس.](hidden_cells_False.png) |

یک سلول مخفی حاوی مقدار، متفاوت از یک سلول خالی است. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این تنظیم شامل یا حذف داده‌های منبع مخفی نمی‌شود. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/php-java/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **دریافت بازه داده‌های یک نمودار**

قبل از به‌روزرسانی داده‌های دفترچه کار در یک ارائه موجود، بازه‌های منبع را بررسی کنید تا مشخص کنید هر نمودار از کدام سلول‌های کاربرگ استفاده می‌کند. متد [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) بازه دادهٔ فعلی را به‌صورت فرمولی با مشخصات شیت برمی‌گرداند، مانند `Sheet1!$A$1:$D$5`. در اینجا، `Sheet1` نام کاربرگ است، `!` آن را از بازه سلول‌ها جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را شامل می‌شود. علامت‌ دلار نشان‌دهندهٔ ارجاع مطلق ردیف و ستون است.

این متد بازهٔ فعلی را بدون تغییر نمودار یا دفترچه‌کار می‌خواند. اگر نمودار از دفترچه کاری به عنوان منبع داده استفاده نکند، استثنا پرتاب می‌شود. برای اطلاعات بیشتر به [مرجع API ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌های هر اسلاید را مستقیماً برای نمودارها بررسی می‌کند. نام هر نمودار و بازه منبع آن را چاپ می‌کند. اگر نمودار از دفترچه کار استفاده نکند، پیام مربوطه چاپ شده و به نمودار بعدی ادامه می‌دهد.

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

## **خواندن و نوشتن داده‌های نمودار از دفترچه کار**

Aspose.Slides برای PHP از طریق Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) و [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) را فراهم می‌کند که امکان خواندن و نوشتن دفترچه‌های کار دادهٔ نمودار (که حاوی داده‌های ویرایش شدهٔ Aspose.Cells هستند) را می‌دهد. **توجه** داشته باشید که دادهٔ نمودار باید به همان شکل سازماندهی شده باشد یا ساختاری مشابه منبع داشته باشد.

این مثال از ارائه‌ای با یک نمودار به عنوان اولین شکل در اسلاید اول استفاده می‌کند. دفترچه کار جاسازی‌شده را به‌صورت آرایهٔ بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان دفترچه کار را دوباره می‌نویسد. تغییرات فقط در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

### **اعتبارسنجی طرح‌بندی نمودار پس از اصلاح دفترچه کار**

زمانی که یک دفترچه کار جاسازی‌شده را با نسخه‌ای اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شکست [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) با خطای out‑of‑range شود. قبل از نوشتن دفترچه کار به‌روز شده، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل اسلاید اول است استفاده می‌کند. بخش کامنت نشان می‌دهد که ویرایش دفترچه کار کجا انجام می‌شود؛ مثال اجرایی دفترچه کار اصلی را برمی‌گرداند و طرح‌بندی را در حافظه اعتبارسنجی می‌کند.

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

        // در اینجا بایت‌های دفترچه کار را تغییر دهید، برای مثال با استفاده از Aspose.Cells.

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

پاک‌سازی مجموعه‌ها قبل از نوشتن دفترچه کار، مراجع دادهٔ منقضی‌شده را حذف می‌کند. قبل از استفاده از نمودار، سری‌ها و نگاشت‌های دسته مورد نیاز را برای دفترچه کار به‌روزرسانی‌شده بازسازی کنید.

## **تنظیم قالب‌های عددی سفارشی برای سلول‌های دفترچه کار**

از [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) برای کنترل نحوهٔ نمایش مقادیر عددی در دفترچه کار جاسازی‌شدهٔ نمودار استفاده کنید. برای مثال، یک گزارش ممکن است نرخ تبدیل را به صورت درصد با چهار رقم اعشار و یک ضریب را با پنج رقم اعشار نمایش دهد. هر دو مقدار را عددی نگه دارید تا برای محاسبات و رسم نمودار در دسترس باشند.

یک قالب عددی فقط نمایش را تغییر می‌دهد، مقدار ذخیره‌شده را تغییر نمی‌دهد. قالب `0.0000%` مقدار `0.125` را به `12.5000%` نمایش می‌دهد؛ عدد ذخیره‌شده همچنان `0.125` است. به‌طور مشابه، `0.00000` مقدار `0.1234567` را به `0.12346` نمایش می‌دهد بدون این‌که مقدار ذخیره‌شده گرد شود. اگر قالب سفارشی رشتهٔ خالی (`""`) باشد، قالب بازگشتی توسط [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) استفاده می‌شود.

مثال زیر یک نمودار ستونی می‌سازد و سلول‌های آن را از طریق [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) دسترسی می‌دهد. در کاربرگ 0، B2 حاوی نرخ تبدیل و C2 حاوی ضریب است. هر دو سلول مقادیر نمودار را تأمین می‌کنند. مثال همچنین برچسب‌های مقدار را که به قالب‌های منبع لینک شده‌اند فعال می‌کند.

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

قالب‌های سلول دفترچه کار جدا از قالب‌های تنظیم‌شده مستقیم بر محورها یا برچسب‌های داده هستند. در این مثال، هر برچسب مقدار سلول منبع خود را نشان می‌دهد چون [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) برابر `true` است و به قالب عددی منبع لینک می‌شود چون [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) برابر `true` است. پس از ذخیره و بازگذاری ارائه، برچسب‌ها `12.5000%` و `0.12346` را نشان می‌دهند، همان‌طور که در تصویر زیر مشاهده می‌شود. محور عمودی قالب عددی مخصوص خود را دارد که با [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) به `0.00` تنظیم شده و [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) برابر `false` است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم لینک به منبع را به `false` تنظیم کنید و با [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) قالبی اختصاص دهید. این کار قالب سلول دفترچه کار را تغییر نمی‌دهد. برای مثال، قالب مستقل `0.00` مقدار اول را به `0.13` نمایش می‌دهد در حالی که B2 همچنان `12.5000%` نشان می‌دهد. به [برچسب‌های دادهٔ نمودار](/slides/fa/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) برای قالب‌بندی مستقیم برچسب‌ها مراجعه کنید.

![نمودار ستونی با برچسب‌های لینک‌شده به منبع که 12.5000% و 0.12346 و محوری عددی مستقل قالب‌بندی‌شده را نشان می‌دهد.](custom-cell-formats.png)

## **استفاده از یک سلول دفترچه کار به عنوان برچسب دادهٔ نمودار**

می‌توانید متن سلول‌های دفترچه کار را به عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اسلاید اول یک ارائه موجود اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای سه برچسب اول سری اول استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌سازد و ارائه به‌روزشده را ذخیره می‌کند.

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

## **مدیریت کاربرگ‌ها**

متد [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) دسترسی به کاربرگ‌های موجود در دفترچه کار یک نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض می‌سازد و نام هر کاربرگ را در کنسول چاپ می‌کند.

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

## **مشخص‌کردن نوع منبع داده**

این مثال یک نمودار ستونی 3‑بعدی با داده‌های پیش‌فرض می‌سازد و دو نام سری را با منابع داده متفاوت تنظیم می‌کند. نام اول از یک رشتهٔ متنی استفاده می‌کند؛ نام دوم از سلول C1 در کاربرگ 0 می‌گیرد. شمارش [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روزشده ذخیره می‌کند.

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

## **تشخیص فرمت‌های غیرقابل پشتیبانی دفترچه کار جاسازی‌شده**

Aspose.Slides از فرمت باینری Excel (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد `getEmbeddedWorkbookType` بر روی [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) فرمت‌های غیرقابل پشتیبانی را شناسایی کرده و نمودارهای مربوطه را رد کنید. این مثال شکل‌های اسلاید اول یک ارائه موجود را بررسی می‌کند، شکل‌های غیرنموداری را نادیده می‌گیرد و برای هر نمودار دارای دفترچه کار .xlsb پیامی تشخیصی چاپ می‌کند.

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

        // داده‌های دفترچه کار پشتیبانی‌شده نمودار را اینجا بخوانید یا تغییر دهید.
    }
} finally {
    $presentation->dispose();
}
```

## **دفترچه کار خارجی**

Aspose.Slides از استفاده از دفترچه‌های کار خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک دفترچه کار خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) و [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) برای استخراج دفترچه کار نمودار جاسازی‌شده به یک فایل و لینک نمودار به آن دفترچه کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض می‌سازد و دفترچه کار آن را استخراج می‌کند. نوشتن فایل را تکمیل می‌کند قبل از اینکه دفترچه کار خارجی را به عنوان منبع دادهٔ نمودار اختصاص دهد، سپس ارائهٔ پیوند شده را ذخیره می‌کند.

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

### **تنظیم یک دفترچه کار خارجی**

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) می‌توانید یک دفترچه کار خارجی را به عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد می‌تواند برای به‌روزرسانی مسیر دفترچه کار خارجی (اگر منتقل شده باشد) نیز به‌کار رود.

در حالی که نمی‌توانید داده‌های دفترچه‌های کاری که در مکان‌های از راه دور یا منبع ذخیره شده‌اند را ویرایش کنید، می‌توانید همچنان از چنین دفترچه‌های کاری به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای دفترچه کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک دفترچه کار خارجی استفاده می‌کند که کاربرگ آن به نام `Sheet1` شامل نام سری در B1، نام دسته‌ها در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای می‌سازد، دفترچه کار را لینک می‌کند و با استفاده از [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) بازهٔ A1:B4 را به یک سری و سه دسته انتساب می‌دهد. سپس ارائه را با نمودار لینک‌شده ذخیره می‌کند.

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

پارامتر `updateChartData` متد [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) کنترل می‌کند که آیا دفترچه کار بارگذاری شود یا نه.

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر دفترچه کار به‌روز می‌شود. دادهٔ نمودار از دفترچه کار هدف بارگذاری یا به‌روز نمی‌شود، بنابراین دفترچه کار می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `true` باشد، دادهٔ نمودار از دفترچه کار هدف به‌روز می‌شود.

مثال زیر یک URL جایگزین را با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شود و ارائه بدون بارگذاری دفترچه کار در دسترس ذخیره می‌شود.

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

### **دریافت مسیر دفترچه کار منبع دادهٔ خارجی یک نمودار**

برای شناسایی دفترچه کاری که به یک نمودار لینک شده است، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر دفترچه کار آن را بازیابی کنید.

این مثال اولین شکل اسلاید اول یک ارائه با دفترچه کار خارجی لینک‌شده را بررسی می‌کند. اگر این شکل یک نمودار لینک‌شده به دفترچه کار خارجی باشد، متد [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) را در کنسول چاپ می‌کند. سپس یک نسخهٔ کپی از ارائه را ذخیره می‌کند.

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

می‌توانید داده‌های دفترچه‌های کاری خارجی را همان‌طوری که داده‌های دفترچه‌های داخلی را تغییر می‌دهید، ویرایش کنید. وقتی دفترچه کار خارجی قابل بارگذاری نباشد، استثنا پرتاب می‌شود.

این مثال از یک نمودار که اولین شکل اسلاید اول است و به یک دفترچه کار خارجی قابل دسترسی لینک شده استفاده می‌کند. مقدار سلول‑پشتیبان اولین نقطه داده در اولین سری را به 100 تنظیم می‌کند و ارائه به‌روزشده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی لینک‌شده را به‌روز کند، بنابراین در صورت نیاز به حفظ دفترچه کار اصلی از یک کپی استفاده کنید.

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

### **بازیابی دفترچه کار از کش نمودار**

اگر یک نمودار از دفترچه کار خارجی که موجود نیست یا در دسترس نیست استفاده می‌کند، Aspose.Slides می‌تواند دفترچه کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، یک شیء [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) ایجاد کنید، متد [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) را فراخوانی کنید و [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) را به `true` تنظیم کنید.

مثال PHP زیر داده‌های دفترچه کار را برای یک نمودار که اولین شکل اسلاید اول است و به یک دفترچه کار خارجی ناموجود ارجاع می‌دهد، بازیابی می‌کند. داده‌های بازیابی‌شده از طریق [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) و [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) دسترسی پیدا می‌شود:

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

        // خواندن یا تغییر داده‌های دفترچه کار بازیابی‌شده در اینجا.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

اگر دفترچه کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنا پرتاب می‌کند. فقط زمانی بازیابی را فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار گزینهٔ پذیرفتنی باشد، زیرا کش ممکن است شامل تغییراتی که پس از آخرین به‌روزرسانی ارائه در دفترچه کار خارجی انجام شده‌اند، نباشد.

## **پرسش‌های متداول**

**آیا می‌توانم تعیین کنم آیا یک نمودار خاص به یک دفترچه کار خارجی یا داخلی لینک شده است؟**

بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) و [مسیر به یک دفترچه کار خارجی](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) است؛ اگر منبع یک دفترچه کار خارجی باشد می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به دفترچه‌های کار خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابجا کردن دفترچه کار ممکن است نیاز به به‌روزرسانی لینک داشته باشد.

**آیا می‌توانم از دفترچه‌های کاری که در منابع/سهم‌گذاری‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین دفترچه‌هایی می‌توانند به عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم دفترچه‌های کاری از راه دور توسط Aspose.Slides پشتیبانی نمی‌شود —آنها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) را ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبان سلول می‌تواند فایل XLSX محلی لینک‌شده را نیز به‌روز کند. اگر نسخهٔ اصلی باید دست‌نخورده بماند، از یک کپی دفترچه کار استفاده کنید.

**اگر فایل خارجی رمزعبور‌دار باشد چه باید کرد؟**

Aspose.Slides هنگام لینک کردن رمزعبور را دریافت نمی‌کند. یک راه‌حل معمول حذف پیشاپیش محافظت یا تهیهٔ یک کپی رمزگشایی‌شده (به عنوان مثال با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/java/)) و لینک به آن کپی است.

**آیا چندین نمودار می‌توانند به یک دفترچه کار خارجی یکسان ارجاع دهند؟**

بله. هر نمودار لینک خودش را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر نمودار در بارگذاری بعدی داده‌ها منعکس خواهد شد.