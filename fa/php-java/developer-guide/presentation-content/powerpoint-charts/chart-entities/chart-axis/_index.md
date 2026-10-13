---
title: سفارشی‌سازی محورهای نمودار در ارائه‌ها با استفاده از PHP
linktitle: محور نمودار
type: docs
url: /fa/php-java/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دست‌کاری محور
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
description: "کشف کنید چگونه می‌توانید از Aspose.Slides برای PHP از طریق Java برای سفارشی‌سازی محورها در نمودارهای ارائه‌های PowerPoint برای گزارش‌ها و نمایش‌های تصویری استفاده کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه محورها را در نمودارها با Aspose.Slides برای PHP از طریق Java سفارشی کنید. این مقاله به مقادیر محاسبه‌شده محور، تعویض ردیف‌ها و ستون‌های نمودار، قابلیت مشاهده محور، فواصل برچسب دسته و علامت‌گذاری، دسته‌بندی‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت محور، واحدهای نمایش و مقیاس لگاریتمی می‌پردازد.

## **دریافت حداکثر مقادیر محور عمودی در نمودارها**

یک [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید و یک نمودار مساحتی با داده پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) را فراخوانی کنید تا طرح‌بندی نمودار به‌روز باشد.

محدودیت‌های محور را با استفاده از [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) و [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) بخوانید و فواصل تیک را با [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) و [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) به‌دست آورید. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) و [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) مقیاس‌های واحد زمان را فراهم می‌کنند که برای محورهای تاریخ مرتبط هستند. مثال این مقادیر را در متغیرهای محلی ذخیره کرده و نمودار را ذخیره می‌کند.

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

## **جابه‌جایی داده‌ها بین محورها**

از [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته قبلی به یک سری تبدیل می‌شود و هر سری قبلی به یک دسته. این تغییر نحوه گروه‌بندی داده‌ها را تحت تأثیر قرار می‌دهد؛ محورها افقی و عمودی را تعویض نمی‌کند. مثال از [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) برای اتصال داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل ردیف سرآیند و ستون دسته، قبل از تعویض ردیف‌ها و ستون‌ها استفاده می‌کند. یک نمودار با چهار سری و سه دسته ذخیره می‌شود.

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

## **غیرفعال‌سازی محور عمودی برای نمودارهای خطی**

با فراخوانی [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) با مقدار `false` بر روی محور عمودی آن را مخفی کنید. مثال یک نمودار خطی با داده پیش‌فرض ایجاد کرده و آن را با مخفی شدن محور عمودی ذخیره می‌کند.

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

## **غیرفعال‌سازی محور افقی برای نمودارهای خطی**

با فراخوانی [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) با مقدار `false` بر روی محور افقی آن را مخفی کنید. مثال یک نمودار خطی با داده پیش‌فرض ایجاد کرده و آن را با مخفی شدن محور افقی ذخیره می‌کند.

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

## **تغییر محور دسته‌بندی**

از [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) برای انتخاب محور دسته‌بندی تاریخ یا متن استفاده کنید. این مثال به `ExistingChart.pptx` نیاز دارد، که شامل یک نمودار به‌عنوان اولین شکل در اولین اسلاید است و سلول‌های دسته شامل مقادیر عددی تاریخ اکسل هستند. محور افقی را به محور تاریخ تغییر می‌دهد. فراخوانی [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) با `false`، [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) با `1` و [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) با `TimeUnitType::Months` تیک‌های اصلی را در فواصل یک‌ماهه قرار می‌دهد.

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

## **کنترل فاصله برچسب‌های محور دسته‌بندی**

وقتی یک نمودار دارای دسته‌های زیاد است، می‌توانید تعداد برچسب‌های قابل مشاهده محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) را با `false` فراخوانی کنید و سپس فاصله دستهٔ موردنظر را به [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/) پاس دهید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته آغاز می‌شود:

| فاصله | برچسب‌های نمایش‌داده‌شده در مثال |
| --- | --- |
| `1` | دسته 1, دسته 2, دسته 3, ... دسته 24 |
| `2` | دسته 1, دسته 3, دسته 5, ... دسته 23 |
| `3` | دسته 1, دسته 4, دسته 7, ... دسته 22 |

فاصلهٔ `3` هر برچسب سوم را نمایش می‌دهد و دو برچسب بین برچسب‌های نمایش‌داده‌شده را پنهان می‌کند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصلهٔ خودکار بر اساس فضای موجود یک فاصله را انتخاب می‌کند؛ لزوماً همه برچسب‌ها را نمایش نمی‌دهد.

علامت‌های تیک کنترل‌های جداگانه‌ای دارند. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) را با `false` فراخوانی کنید و از [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) برای تنظیم فاصلهٔ آن‌ها استفاده کنید. به عنوان مثال، `1` یک علامت تیک را در هر فاصلهٔ دسته حفظ می‌کند در حالی که برچسب‌ها تنها هر سومین دسته ظاهر می‌شوند. با استفاده از [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) با یک سبک قابل مشاهده می‌توانید نتیجه را ببینید. فراخوانی هر یک از تنظیم‌کننده‌های فاصلهٔ خودکار با `true` مجدداً اجازه می‌دهد که نمودار همان فاصله را انتخاب کند.

مثال خودکفای زیر ۲۴ دسته و یک سری ایجاد می‌کند، سپس سه اسلاید را در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصلهٔ خودکار، فاصلهٔ برچسب دستی با علامت‌های تیک مستقل، و بازگرداندن فاصلهٔ خودکار. دو نسخهٔ کپی داده‌های اصلی نمودار را حفظ می‌کنند. ارائهٔ ورودی مورد نیاز نیست. متن برچسب افقی تفاوت چگالی را به‌راحتی نشان می‌دهد.

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

    // اسلاید ۲: هر برچسب سوم را نشان دهید، اما برای هر دسته یک علامت تیک حفظ کنید.
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

**فاصلهٔ خودکار (اسلاید 1):** در این رندر، هر برچسب دوم دسته نمایش داده می‌شود و به دو خط می‌پیچد. نتیجهٔ خودکار می‌تواند با اندازهٔ نمودار، قلم‌ها و رندرر متفاوت باشد.

![فاصلهٔ خودکار برچسب‌های دسته با نمایش تمام ۲۴ ستون](category-axis-automatic.png)

**فاصلهٔ دستی (اسلاید 2):** هر برچسب سوم در یک خط نمایش داده می‌شود، در حالی که علامت‌های تیک در هر فاصلهٔ دسته باقی می‌مانند. تمام ۲۴ ستون، از جمله آن‌هایی که برچسب ندارند، با همان مقادیر قابل مشاهده هستند. اسلاید ۳ ظاهر خودکار نشان داده شده در بالا را بازمی‌گرداند.

![فاصلهٔ برچسب دسته به صورت دستی با سه ستون، با نمایش تمام ۲۴ ستون](category-axis-manual.png)

### **انتخاب محور و فاصلهٔ صحیح**

از این فاصلهٔ شمارش دسته برای محور دسته‌بندی متنی استفاده کنید، مانند محور دسته‌بندی یک نمودار ستونی، خطی، مساحتی یا میله‌ای. در یک نمودار ستونی، این محور افقی است. در یک نمودار میله‌ای افقی، محور دسته‌بندی عمودی است، بنابراین این تنظیمات را به محوری که توسط [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) برگردانده می‌شود اعمال کنید. فاصلهٔ علامت‌گذاری تیک همچنین برای محور سری در نمودارهایی که دارای آن هستند اعمال می‌شود.

از فاصلهٔ برچسب دسته برای تنظیم مقیاس عددی یک محور مقدار استفاده نکنید. در یک محور مقدار، [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) اختلافی در مقادیر را مشخص می‌کند: به عنوان مثال، واحد اصلی `10` تیک‌های 0، 10، 20 و ... را تولید می‌کند وقتی محور از صفر شروع می‌شود. یک فاصلهٔ برچسب دسته‌ای `3` به جای آن موقعیت‌های دسته را می‌شمارد، بدون توجه به مقادیر داده‌ها. نمودارهای پراکندگی و حبابی از محورها مقدار استفاده می‌کنند نه از محور دسته‌بندی متنی. برای یک محور تاریخ، از واحدهای اصلی مبتنی بر زمان و مقیاس‌ها همان‌طور که در [تغییر محور دسته‌بندی](#change-a-category-axis) توضیح داده شده استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌بندی**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌عنوان شماره سریالی OLE Automation در اولین ورق کاری (اندیس `0`) ذخیره می‌شوند که به‌صورت تعداد روزها از 30 دسامبر 1899 برای این تاریخ‌ها محاسبه می‌شود. از [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) با `CategoryAxisType::Date` استفاده کنید، [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) را با `false` فراخوانی کنید و `yyyy` را به [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) پاس دهید تا برچسب‌های دسته سال‌های چهار رقمی را به‌صورت مستقل از قالب‌بندی سلول نمایش دهند.

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

## **تنظیم زاویهٔ چرخش برای عنوان محور نمودار**

با فراخوانی [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) با مقدار `true` بر روی محور عمودی، متن عنوان را فراهم کنید و از [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) برای چرخاندن عنوان استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی را با عنوان محور مقدار که به‌صورت 90 درجه چرخیده ذخیره می‌کند.

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

## **تنظیم موقعیت محور در محور دسته یا مقدار**

از [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) برای کنترل اینکه آیا محور مقدار محور دسته‌بندی را بین دسته‌ها یا در علامت‌گذاری‌های دسته عبور دهد استفاده کنید. این تنظیم برای محورها دسته‌بندی اعمال می‌شود. مثال این مقدار را بر روی محور دسته‌بندی افقی یک نمودار ستونی به `true` تنظیم کرده و نتیجه را ذخیره می‌کند.

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

## **تنظیم واحد نمایش بر روی محور مقدار نمودار**

از [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) برای مقیاس‌بندی برچسب‌های یک محور مقدار بدون تغییر داده‌های زیرین استفاده کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) به `Millions`، مقدار 60,000,000 به‌صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد کرده و واحد نمایش میلیون‌ها را بر روی محور عمودی آن اعمال می‌کند.

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

یک محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت در چندین مرتبهٔ بزرگگی متفاوت شوند. به عنوان مثال، یک سرویس ممکن است در طول پنج دوره 10، 100، 1,000، 10,000 و 100,000 درخواست دریافت کند. در مقیاس خطی، مقادیر کوچکتر نزدیک به صفر یکدیگر قرار می‌گیرند. مقیاس لگاریتمی رشد نسبی آن‌ها را برای مقایسه آسان‌تر می‌کند: فواصل برابر نشان‌دهندهٔ نسبت‌های برابر هستند نه اختلافات برابر.

با فراخوانی [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) با مقدار `true` بر روی محور مقدار و استفاده از [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) پایه را انتخاب کنید. این کار نحوهٔ نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد یا خط روند لگاریتمی اضافه نمی‌کند. یک خط روند رابطهٔ برازش‌شده در داده‌ها را نشان می‌دهد و یک ویژگی جداگانه است.

### **انتخاب محور مقدار و پایه**

برای یک نمودار خطی یا ستونی، محور مقدار توسط [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) بازگردانده می‌شود. برای یک نمودار میله‌ای افقی، توسط [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/) بازگردانده می‌شود. نمودارهای پراکندگی و حبابی دو محور مقدار دارند، بنابراین برای مقادیر X محور افقی، برای مقادیر Y محور عمودی یا هر دو را انتخاب کنید. مقیاس لگاریتمی را بر روی محور دسته‌بندی اعمال نکنید.

پایهٔ پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX، می‌توانید پایه‌ای بین `2` تا `1000`، شامل این مقادیر، استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایهٔ `10`، توان‌های پی در پی مانند 10، 100، 1,000 و 10,000 به‌صورت مساوی فاصله دارند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال خودکفای زیر یک نمودار خطی با پنج تعداد درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی کرده و محور مقدار لگاریتمی با پایهٔ 10 را در اسلاید دوم فعال می‌کند. هر دو اسلاید داده‌های یکسان را نگه می‌دارند.

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

    // اسلاید اول را خطی نگه دارید و فقط مقیاس محور مقدار نسخه‌ی کپی‌شده را تغییر دهید.
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

**مقیاس خطی (اسلاید 1):** فواصل عمودی برابر نشان‌دهندهٔ اختلافات برابر در تعداد درخواست‌ها هستند. بزرگ‌ترین مقدار نمودار را تسلط می‌کند و مقادیر کوچکتر را تشخیص دشوار می‌سازد.

![نمودار خطی در پاورپوینت که پنج تعداد درخواست را بر روی محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید 2):** فواصل عمودی برابر نشان‌دهندهٔ نسبت‌های برابر هستند. هر دوره ده برابر تعداد درخواست‌های دورهٔ قبلی دارد، بنابراین نقاط یک خط صعودی مستقیم بر روی مقیاس پایهٔ 10 تشکیل می‌دهند. برچسب‌های محور هنوز تعداد درخواست‌های اصلی را نمایش می‌دهند.

![پنج تعداد درخواست یکسان در پاورپوینت بر روی محور مقدار لگاریتمی پایهٔ 10](value-axis-logarithmic.png)

### **مدیریت مقادیر صفر و منفی**

یک مقیاس لگاریتمی تنها می‌تواند مقادیر کاملاً مثبت را نمایش دهد. قبل از فعال‌سازی داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنی‌دار هستند، مقیاس خطی را حفظ کنید یا آن‌ها را جداگانه نشان دهید. اگر حذف این مقادیر برای تحلیل مناسب است، حذف را توضیح دهید. مقادیر را به‌صورت سکوتی با اعداد کوچک مثبت جایگزین نکنید، زیرا این کار معنی داده‌ها را تغییر می‌دهد. هر حداقل یا حداکثر به‌صورت دستی تنظیم‌شده برای یک محور لگاریتمی نیز باید مثبت باشد.

## **سئوالات متداول**

**چگونه می‌توانم مقداری که یک محور دومین محور را قطع می‌کند (تقاطع محور) را تنظیم کنم؟**

از [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) برای انتخاب رفتار تقاطع استفاده کنید. برای تعیین مقدار عددی تقاطع، از [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) استفاده کنید. این تنظیمات به شما اجازه می‌دهند تقاطع محور را به یک خط پایه مناسب جابه‌جا کنید.

**چگونه می‌توانم برچسب‌های تیک را نسبت به محور موقعیت‌دهی کنم؟**

[setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) را با استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo` یا `None` فراخوانی کنید. برای کنترل خود علامت‌های تیک، از [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) یا [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/) استفاده کنید؛ این‌ها جدا از موقعیت‌دهنی برچسب‌ها هستند.