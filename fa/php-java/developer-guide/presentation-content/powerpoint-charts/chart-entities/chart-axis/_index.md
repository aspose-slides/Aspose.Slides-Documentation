---
title: سفارشی‌سازی محورها در ارائه‌ها با استفاده از PHP
linktitle: محور نمودار
type: docs
url: /fa/php-java/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دستکاری محور
- مدیریت محور
- ویژگی‌های محور
- حداکثر مقدار
- حداقل مقدار
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید از Aspose.Slides برای PHP از طریق Java استفاده کنید تا محورها را در نمودارهای ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها سفارشی کنید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان محورها را در نمودارها با Aspose.Slides برای PHP از طریق Java سفارشی کرد. مواردی چون مقادیر محاسبه‌شده محور، جابجایی ردیف‌ها و ستون‌ها، نمایانی محور، فاصله برچسب‌های دسته و نشانگرهای تیک، دسته‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت محور، واحدهای نمایش و مقیاس لگاریتمی پوشش داده می‌شوند.

## **دریافت حداکثر مقادیر در محور عمودی در نمودارها**

یک [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید و یک نمودار مساحتی با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، برای به‌روز بودن طرح نمودار، [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) را صدا بزنید.

برای محدودهای محور، [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) و [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) را بخوانید، و برای فاصله نشانگرهای تیک، [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) و [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) را استفاده کنید. مقیاس‌های واحد زمان را می‌توان از [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) و [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) دریافت کرد که برای محوری‌های تاریخ مرتبط هستند. مثال این مقادیر را در متغیرهای محلی ذخیره کرده و نمودار را ذخیره می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تبادل داده بین محورها**

از [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) برای تعویض نقش‌های سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته قبلی یک سری می‌شود و هر سری قبلی یک دسته. این تغییر فقط نحوه گروه‌بندی داده‌ها را تحت تأثیر قرار می‌دهد؛ محورها را جابه‌جا نمی‌کند. مثال برای بایند کردن داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل ردیف سرعنوان و ستون دسته، از [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) استفاده می‌کند و سپس ردیف‌ها و ستون‌ها را جابجا می‌کند. یک نمودار با چهار سری و سه دسته را ذخیره می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **معکوس کردن ترتیب رسم محور**

از [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) برای معکوس کردن یک محور دسته یا مقدار استفاده کنید. به عنوان مثال، یک نمودار میله‌ای افقی می‌تواند مراحل پروژه را از بالا به پایین به همان ترتیبی که در کاربرگ هستند نشان دهد: برنامه‌ریزی، توسعه، آزمون. معکوس کردن محور جهت رسم را تغییر می‌دهد؛ داده‌های کاربرگ را مرتب یا جابه‌جا نمی‌کند. برای مقایسه، [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) نقش‌های سری و دسته را تعویض می‌کند.

مثال زیر یک نمودار میله‌ای افقی با سه مرحله و یک سری ایجاد می‌کند. ارائه‌ای با سه اسلاید ذخیره می‌شود: ترتیب عادی، دسته‌های معکوس، و مقادیر معکوس. هر کپی از همان مجموعه داده استفاده می‌کند و فقط یک محور در هر کپی معکوس می‌شود.

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // اسلاید ۲: نمایش اولین دسته در بالا.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // محور مقدار افقی را در پایین نگه دارید.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // اسلاید ۳: فقط مقیاس عددی افقی را معکوس کنید.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

معکوس کردن یک محور می‌تواند محور عمود را به طرف opposite طرف نمودار حرکت دهد. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) تعیین می‌کند که محور دیگر در کجا محور تنظیم‌شده را قطع می‌کند. در اسلاید ۲، صدا کردن آن با `CrossesType::Maximum` روی محور دسته معکوس، محور مقدار افقی را در پایین حفظ می‌کند. برای یک نقطه عبور خاص، از [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) استفاده کنید. هنگام تغییر جهت، تنظیمات عبور را بررسی کنید، به‌ویژه اگر نمودار قبلاً یک نقطه عبور سفارشی داشته باشد. برای بازگرداندن جهت رسم عادی، `setPlotOrderReversed` را با `false` صدا بزنید؛ تنظیمات عبور جداگانه‌اند.

| ترتیب عادی (اسلاید 1) | دسته‌های معکوس (اسلاید 2) | مقادیر معکوس (اسلاید 3) |
| --- | --- | --- |
| ![نمودار میله‌ای افقی با ترتیب محور دسته و مقدار عادی](axis-order-normal.png) | ![نمودار میله‌ای افقی با دسته‌های نمایش داده‌شده از بالا به پایین](axis-order-categories-reversed.png) | ![نمودار میله‌ای افقی با محور مقدار معکوس و صفر در سمت راست](axis-order-values-reversed.png) |
| دسته‌ها از پایین به بالا می‌روند؛ مقادیر از چپ به راست افزایش می‌یابند. | برنامه‌ریزی، توسعه و آزمون از بالا به پایین می‌روند. مقادیر و ترتیب ردیف‌های کاربرگ بدون تغییر می‌مانند. | دسته‌ها ترتیب عادی خود را حفظ می‌کنند؛ مقادیر از راست به چپ افزایش می‌یابند. محور دسته در صفر سمت راست قطع می‌شود. |

## **غیرقابل نمایش کردن محور عمودی برای نمودارهای خطی**

با صدا زدن [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) و مقدار `false` روی محور عمودی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور عمودی مخفی ذخیره می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **غیرقابل نمایش کردن محور افقی برای نمودارهای خطی**

با صدا زدن [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) و مقدار `false` روی محور افقی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور افقی مخفی ذخیره می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **نمایش یا مخفی کردن خطوط شبکه نمودار**

با صدا زدن [getShowMajorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowmajorgridlines/) و [getShowMinorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowminorgridlines/) می‌توانید بررسی کنید که کدام خطوط شبکه محور نمایش می‌دهد. برای نمایش خطوط شبکه فرعی، از [getMinorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getminorgridlinesformat/) استفاده کنید و پر کردن خط را به رنگ ثابت و قابل رؤیت تنظیم کنید. برای مخفی کردن آن‌ها، پر کردن را به [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) تغییر دهید. برای خطوط شبکه اصلی نیز می‌توانید از [getMajorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getmajorgridlinesformat/) به همان روش استفاده کنید. تغییر پر کردن، نمایانی محور و نشانگرهای تیک را حفظ می‌کند.

محور عمودی این نمودار ستون خوشه‌ای در ابتدا فقط خطوط شبکه اصلی را نشان می‌دهد. مثال خطوط شبکه فرعی را با رنگ نارنجی تیره نمایش می‌دهد، سپس دوباره مخفی می‌کند و سپس ارائه را ذخیره می‌کند. در هر مرحله، قابلیت نمایش خطوط شبکه چاپ می‌شود.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
    $axis = $chart->getAxes()->getVerticalAxis();
    printf("Initial: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill = $axis->getMinorGridLinesFormat()->getLine()->getFillFormat();
    $minorFill->setFillType(FillType::Solid);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $minorFill->getSolidFillColor()->setColor($darkOrange);
    printf("Enabled: minor=%s\n", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill->setFillType(FillType::NoFill);
    printf("Hidden: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $presentation->save("ChartGridlines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| خطوط شبکه فرعی فعال | خطوط شبکه فرعی مخفی |
| --- | --- |
| ![خطوط شبکه فرعی نارنجی بین خطوط شبکه اصلی روی محور عمودی](minor-gridlines-enabled.png) | ![همان نمودار ستونی فقط با خطوط شبکه اصلی قابل رؤیت](minor-gridlines-hidden.png) |

## **تغییر یک محور دسته**

از [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) برای انتخاب یک محور دسته تاریخ یا متن استفاده کنید. این مثال به `ExistingChart.pptx` نیاز دارد، که در اسلاید اول اولین شکل نمودار است و سلول‌های دسته مقادیر عددی تاریخ Excel را دارند. محور افقی را به یک محور تاریخ تغییر می‌دهد. با صدا زدن [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) با `false`، [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) با `1` و [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) با `TimeUnitType::Months`، تیک‌های اصلی را در فواصل یک ماه تنظیم می‌کند.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **تشخیص نوع محور دسته از داده‌ها**

پس از پر کردن دسته‌ها، [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistypeautomatically/) را صدا بزنید و سپس [getCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getcategoryaxistype/) را بخوانید تا انتخاب را بررسی کنید. این روش زمانی مفید است که همان نمودار یا متن برچسب‌ها یا مقادیر عددی تاریخ دریافت کند. این متد نوع را هنگام فراخوانی تعیین می‌کند؛ حالت پایداری که بعداً تغییرات داده را دوباره ارزیابی کند فعال نمی‌کند. پس از جایگزینی دسته‌ها، دوباره آن را صدا بزنید.

مثال زیر یک نمودار با دسته‌های متنی ایجاد می‌کند و وقتی نوع انتخاب‌شده `CategoryAxisType::Text` باشد `true` چاپ می‌کند. سپس مقادیر سلول دسته را با تاریخ‌ها جایگزین می‌کند و متد را دوباره صدا می‌زند؛ وقتی نوع انتخاب‌شده `CategoryAxisType::Date` باشد `true` چاپ می‌کند. تاریخ‌ها به شکل مقادیر عددی OLE Automation ذخیره می‌شوند که به عنوان تعداد روزها از 30 دسامبر 1899 محاسبه می‌شوند، نه به صورت رشته تاریخ. [setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) تعیین می‌کند این مقادیر چگونه نمایش داده شوند؛ متنی را به تاریخ عددی تبدیل نمی‌کند. برای اطلاعات بیشتر درباره سلول‌های دسته، به [Chart Workbook](/slides/fa/php-java/chart-workbook/) مراجعه کنید.

از تشخیص خودکار زمانی استفاده کنید که ورودی می‌داند شامل دسته‌های متنی یا تاریخ‌های عددی باشد، همان‌طور که در این مثال نشان داده شده است. برای برچسب‌های عددی معمولی، دسته‌های مختلط یا داده‌های خالی، صراحتاً [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) را صدا بزنید تا معنای مورد نظر مطابقت داشته باشد. مقادیر عددی به تنهایی نشان نمی‌دهند که دسته‌ها نمایانگر تاریخ هستند.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $seriesName = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());
    $labels = ["First", "Second", "Third"];

    for ($i = 0; $i < count($labels); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $labels[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, ($i + 1) * 10);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Text ? "true" : "false") . PHP_EOL;

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);
    $dates = [gmmktime(0, 0, 0, 1, 1, 2026), gmmktime(0, 0, 0, 1, 2, 2026), gmmktime(0, 0, 0, 2, 1, 2026)];

    for ($i = 0; $i < count($dates); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0);
        $categoryCell->setValue((float)(($dates[$i] - $baseDate) / 86400));
        $categoryCell->setCustomNumberFormat("yyyy-mm-dd");
    }

    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Date ? "true" : "false") . PHP_EOL;

    $presentation->save("AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **کنترل فاصله‌های برچسب محور دسته**

هنگامی که نمودار دارای دسته‌های زیادی باشد، تعداد برچسب‌های محوری نمایش داده‌شده را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. ابتدا [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) را با `false` صدا بزنید، سپس فاصله دلخواه دسته را به [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/) پاس دهید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته آغاز می‌شود:

| فاصله | برچسب‌های نمایش داده‌شده در مثال |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

فاصله `3` هر برچسب سوم را نمایش می‌دهد و دو برچسب بین هر دو برچسب نمایش‌داده‌شده مخفی می‌مانند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصله بندی خودکار بر اساس فضای موجود یک فاصله مناسب انتخاب می‌کند؛ لزوماً تمام برچسب‌ها را نشان نمی‌دهد.

نشانگرهای تیک نیز کنترل‌های جداگانه‌ای دارند. ابتدا [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) را با `false` صدا بزنید و سپس با [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) فاصله آن‌ها را تنظیم کنید. به عنوان مثال، `1` یک نشانگر تیک در هر فاصله دسته حفظ می‌کند در حالی که برچسب‌ها فقط هر سومین دسته نمایش داده می‌شوند. با استفاده از [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) یک سبک قابل رؤیت انتخاب کنید تا نتیجه را ببینید. صدا زدن مجدد هر یک از تنظیم‌کننده‌های فاصله خودکار با `true` به نمودار اجازه می‌دهد تا همان فاصله را دوباره انتخاب کند.

مثال خودمحافظ زیر 24 دسته و یک سری ایجاد می‌کند، سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصله‌بندی خودکار، فاصله‌بندی دستی با نشانگرهای تیک مستقل، و بازگرداندن فاصله‌بندی خودکار. دو کپی داده‌های اصلی نمودار را حفظ می‌کنند. هیچ ارائه ورودی لازم نیست. متن برچسب افقی باعث می‌شود تفاوت چگالی به وضوح دیده شود.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // اسلاید ۲: هر برچسب سوم را نمایش دهید، اما برای هر دسته یک نشانگر تیک نگه دارید.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // اسلاید ۳: اجازه دهید نمودار دوباره هر دو فاصله را انتخاب کند.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**فاصله‌بندی خودکار (اسلاید 1):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و در دو خط می‌پیچد. نتیجه خودکار ممکن است بسته به اندازه نمودار، قلم‌ها و رندر کننده متفاوت باشد.

![فاصله‌بندی خودکار برچسب دسته با تمام 24 ستون قابل مشاهده](category-axis-automatic.png)

**فاصله‌بندی دستی (اسلاید 2):** هر سومین برچسب در یک خط نمایش داده می‌شود، در حالی که نشانگرهای تیک در هر فاصله دسته باقی می‌مانند. تمام 24 ستون، از جمله آن‌هایی که برچسب ندارند، با همان مقادیر قابل رؤیت هستند. اسلاید 3 ظاهر خودکار نشان داده در بالا را بازمی‌گرداند.

![فاصله‌بندی دستی برچسب دسته به مقدار سه با تمام 24 ستون قابل مشاهده](category-axis-manual.png)

### **انتخاب محور و فاصله صحیح**

از این فاصله شمارش دسته برای یک محور دسته متنی استفاده کنید، مانند محور دسته یک نمودار ستون، خط، مساحت یا میله. در یک نمودار ستون، این محور افقی است. در یک نمودار میله افقی، محور دسته عمودی است، بنابراین این تنظیمات را به محوری که توسط [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) برگردانده می‌شود اعمال کنید. فاصله‌بندی نشانگرهای تیک همچنین برای محور سری در نمودارهایی که دارای آن هستند اعمال می‌شود.

از فاصله‌بندی برچسب دسته برای تنظیم مقیاس عددی محور مقدار استفاده نکنید. در یک محور مقدار، [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) اختلاف مقادیر را مشخص می‌کند: به عنوان مثال، واحد اصلی `10` تیک‌ها را در 0، 10، 20 و غیره قرار می‌دهد وقتی محور از صفر شروع می‌شود. فاصله برچسب دسته `3` به جای مقدار، موقعیت‌های دسته‌ای را می‌شمارد، صرف‌نظر از مقادیر داده‌ای آنها. نمودارهای پراکندگی و حباب از محورهای مقدار به جای محور دسته متنی استفاده می‌کنند. برای محور تاریخ، از واحدهای اصلی مبتنی بر زمان و مقیاس‌های توصیف‌شده در [تغییر یک محور دسته](#change-a-category-axis) استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به عنوان عددهای سریال OLE Automation در اولین کاربرگ (اندیس `0`) ذخیره می‌شوند که به‌عنوان تعداد روزها از 30 دسامبر 1899 محاسبه می‌شود. با استفاده از [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) همراه با `CategoryAxisType::Date`، سپس [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) با `false` و در نهایت `yyyy` به [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) پاس دهید تا برچسب‌های دسته سال‌های چهاررقمی را به‌صورت مستقل از قالب سلول نمایش دهند.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم زاویه چرخش برای عنوان محور نمودار**

با صدا زدن [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) و مقدار `true` روی محور عمودی، متن عنوان را فراهم کنید و با [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) زاویه چرخش را تنظیم کنید. زاویه بر اساس درجه سنجیده می‌شود؛ این مثال یک نمودار ستون را با عنوان محور مقدار چرخیده به‌صورت 90 درجه ذخیره می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم موقعیت محور روی محور دسته یا مقدار**

از [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) برای کنترل این که آیا محور مقدار محور دسته را بین دسته‌ها یا در نشانگرهای تیک دسته قطع می‌کند، استفاده کنید. این تنظیم به محورهاى دسته اعمال می‌شود. مثال آن را روی محور دسته افقی یک نمودار ستون با مقدار `true` تنظیم می‌کند و نتیجه را ذخیره می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم واحد نمایش روی محور مقدار نمودار**

از [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) برای مقیاس‌گذاری برچسب‌های محور مقدار بدون تغییر داده‌های پایه استفاده کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) به `Millions`، مقدار 60,000,000 به صورت 60 نمایش داده می‌شود. مثال یک نمودار ستون ایجاد می‌کند و واحد نمایش میلیون‌ها را بر محور عمودی آن اعمال می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **پیکربندی یک محور مقدار لگاریتمی**

یک محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت در چندین مرتبه جدول قدرتمند پراکنده باشند. برای مثال، سرویسی ممکن است 10، 100، 1,000، 10,000 و 100,000 درخواست در پنج دوره دریافت کند. در مقیاس خطی، مقادیر کوچکتر به‌طور نزدیک به صفر ظاهر می‌شوند. مقیاس لگاریتمی رشد نسبی آن‌ها را راحت‌تر مقایسه می‌کند: فواصل برابر نمایانگر نسبت‌های برابر نه اختلاف‌های برابر هستند.

با صدا زدن [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) و مقدار `true` روی محور مقدار و استفاده از [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) پایه را انتخاب کنید. این کار نحوه نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خط روند لگاریتمی اضافه نمی‌کند. خط روند یک ویژگی جداگانه است.

### **انتخاب محور مقدار و پایه**

برای یک نمودار خطی یا ستونی، محور مقدار توسط [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) بازگردانده می‌شود. برای یک نمودار میله‌ای افقی، توسط [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/) بازگردانده می‌شود. نمودارهای پراکندگی و حباب دو محور مقدار دارند، بنابراین برای مقادیر X محور افقی، برای مقادیر Y محور عمودی یا هر دو را انتخاب کنید. لگاریتم‌بندی را بر روی محور دسته اعمال نکنید.

پایه پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX، می‌توانید پایه‌ای بین `2` تا `1000` (شامل) استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایه `10`، توان‌های متوالی مانند 10، 100، 1,000 و 10,000 به‌صورت مساوی فاصله‌دار هستند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال خودمحافظ زیر یک نمودار خطی با پنج مقدار درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی کرده و در اسلاید دوم محور مقدار لگاریتمی پایه‑10 را فعال می‌کند. هر دو اسلاید همان داده‌ها را حفظ می‌کنند.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // اسلاید اول را خطی نگه دارید و فقط مقیاس محور مقدار نسخه‌ی کپی شده را تغییر دهید.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**مقیاس خطی (اسلاید 1):** فواصل عمودی برابر نشان‌دهندۀ تفاوت‌های برابر در تعداد درخواست‌ها هستند. بزرگ‌ترین مقدار نمودار را به‌دست می‌آورد و مقادیر کوچکتر را تشخیص دشوار می‌کند.

![نمودار خطی در PowerPoint که پنج تعداد درخواست را بر روی محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید 2):** فواصل عمودی برابر نشان‌دهندۀ نسبت‌های برابر هستند. هر دوره ده برابر دوره قبلی درخواست داشته، بنابراین نقاط روی مقیاس پایه‑10 یک خط صعودی مستقیم می‌سازند. برچسب‌های محور هنوز مقادیر اصلی درخواست را نشان می‌دهند.

![همان پنج تعداد درخواست در PowerPoint بر روی محور مقدار لگاریتمی پایه‑10](value-axis-logarithmic.png)

### **مدیریت مقادیر صفر و منفی**

یک مقیاس لگاریتمی فقط می‌تواند مقادیر مثبت مطلق را نمایش دهد. قبل از فعال‌سازی آن، داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنا دارند، مقیاس خطی را حفظ کنید یا آن‌ها را جداگانه نمایش دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلیل حذف را توضیح دهید. به‌طور خاموش آنها را با عدد مثبت کوچک جایگزین نکنید، زیرا معنی داده‌ها را تغییر می‌دهد. هر حداقل یا حداکثر دستی تنظیم‌شده برای یک محور لگاریتمی نیز باید مثبت باشد.

## **سؤالات متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر (crossing) را تنظیم کنم؟**

از [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) برای انتخاب رفتار تقاطع استفاده کنید. برای تعیین مقدار عددی تقاطع، از [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) بهره ببرید. این تنظیمات به شما اجازه می‌دهند نقطه تقاطع محور را به یک مبنای مناسب منتقل کنید.

**چگونه می‌توانم موقعیت برچسب‌های تیک را نسبت به محور تنظیم کنم؟**

با صدا زدن [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) و استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo` یا `None` موقعیت را تنظیم کنید. برای کنترل خود نشانگرهای تیک، از [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) یا [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/) استفاده کنید؛ این تنظیمات جدا از موقعیت برچسب‌ها هستند.