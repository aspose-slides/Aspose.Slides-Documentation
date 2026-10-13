---
title: سفارشی‌سازی محورهای نمودار در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: محور نمودار
type: docs
url: /fa/nodejs-java/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دستکاری محور
- مدیریت محور
- ویژگی‌های محور
- بیشینه مقدار
- حداقل مقدار
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "کشف کنید چگونه می‌توان با استفاده از جاوااسکریپت و Aspose.Slides برای Node.js از طریق جاوا، محورهای نمودار را در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها سفارشی کرد."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه می‌توانید محورهای نمودار را با Aspose.Slides برای Node.js از طریق Java شخصی‌سازی کنید. در آن به مقادیر محاسبه‌شده محور، جابجایی ردیف‌ها و ستون‌های نمودار، نمایش یا عدم نمایش محور، بازه‌های برچسب دسته و تیک‌مارک، دسته‌بندی‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت‌یابی محور، واحدهای نمایش، و مقیاس لگاریتمی پرداخته می‌شود.

## **دریافت بیشترین مقدارها روی محور عمودی در نمودارها**

یک [ارائه](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید و یک نمودار ناحیه‌ای با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) را فراخوانی کنید تا طرح‌بندی نمودار به‌روز باشد.

[getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) و [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) را برای محدودیت‌های محور بخوانید و [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) و [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) را برای بازه‌های تیک استفاده کنید. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) و [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) مقیاس‌های زمان‑واحد را فراهم می‌کنند که برای محورهای تاریخ مهم هستند. مثال این مقادیر را در متغیرهای محلی ذخیره کرده و نمودار را ذخیره می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **جابه‌جایی داده‌ها بین محورها**

از [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته قبلی به یک سری تبدیل می‌شود و هر سری قبلی به یک دسته. این تغییر نحوه گروه‌بندی داده‌ها را تغییر می‌دهد؛ محور افقی و عمودی جابجا نمی‌شوند. مثال از [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) برای بستن داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل سطر سرصفحه و ستون دسته، قبل از جابجایی ردیف‌ها و ستون‌ها استفاده می‌کند. سپس نموداری با چهار سری و سه دسته ذخیره می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **غیرفعال کردن محور عمودی برای نمودارهای خطی**

با فراخوانی [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) با مقدار `false` روی محور عمودی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد کرده و آن را با مخفی شدن محور عمودی ذخیره می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **غیرفعال کردن محور افقی برای نمودارهای خطی**

با فراخوانی [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) با مقدار `false` روی محور افقی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد کرده و آن را با مخفی شدن محور افقی ذخیره می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تغییر یک محور دسته‌ای**

از [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) برای انتخاب یک محور دسته‌ای تاریخ یا متن استفاده کنید. این مثال به فایل `ExistingChart.pptx` نیاز دارد که در اولین اسلاید اولین شکل یک نمودار است و سلول‌های دسته شامل مقادیر عددی تاریخ‌های Excel هستند. محور افقی را به محور تاریخ تغییر می‌دهد. با فراخوانی [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) با `false`، [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) با `1` و [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) با `TimeUnitType.Months` تیک‌های اصلی را در بازه‌های یک‌ماهه قرار می‌دهد.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **کنترل بازه برچسب‌های محور دسته‌ای**

هنگامی که یک نمودار دسته‌های بسیاری دارد، می‌توانید تعداد برچسب‌های محور قابل مشاهده را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) را با `false` فراخوانی کنید، سپس بازهٔ دلخواه دسته را به [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/) بدهید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته آغاز می‌شود:

| بازه | برچسب‌های نمایش داده‌شده در مثال |
| --- | --- |
| `1` | دسته 1، دسته 2، دسته 3، … دسته 24 |
| `2` | دسته 1، دسته 3، دسته 5، … دسته 23 |
| `3` | دسته 1، دسته 4، دسته 7، … دسته 22 |

یک بازهٔ `3` هر برچسب سومی را نمایش می‌دهد و دو برچسب بین برچسب‌های نشان‌داده‌شده مخفی می‌مانند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصله‌گذاری خودکار بر اساس فضای موجود یک بازه انتخاب می‌کند؛ لزوماً تمام برچسب‌ها را نشان نمی‌دهد.

تیک‌مارک‌ها کنترل جداگانه‌ای دارند. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) را با `false` فراخوانی کنید و از [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) برای تنظیم بازهٔ آن‌ها استفاده کنید. برای مثال، مقدار `1` یک تیک‌مارک را در هر بازهٔ دسته حفظ می‌کند در حالی که برچسب‌ها فقط هر سومین دسته ظاهر می‌شوند. با استفاده از [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) یک سبک قابل مشاهده تنظیم کنید تا نتیجه را ببینید. بازگشت به تنظیم خودکار با تعیین `true` مجدداً اجازه می‌دهد نمودار بازه را به‌صورت خودکار انتخاب کند.

مثال زیر یک مثال خودکفایی است که ۲۴ دسته و یک سری ایجاد می‌کند، سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصله‌گذاری خودکار، فاصله‌گذاری دستی برچسب‌ها با تیک‌مارک‌های مستقل، و بازگشت به فاصله‌گذاری خودکار. دو نسخه کپی داده‌های اصلی نمودار را حفظ می‌کنند. ارائهٔ ورودی لازم نیست. متن برچسب‌های افقی تفاوت چگالی را به‌راحتی نشان می‌دهد.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // اسلاید ۲: هر برچسب سوم را نمایش دهید، اما برای هر دسته یک علامت تیک نگه دارید.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // اسلاید ۳: بگذارید نمودار دوباره هر دو بازه را انتخاب کند.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**فاصله‌گذاری خودکار (اسلاید ۱):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و در دو خط می‌پیچد. نتیجهٔ خودکار می‌تواند بسته به اندازهٔ نمودار، قلم‌ها و رندرر متفاوت باشد.

![فاصله‌گذاری خودکار برچسب‌های دسته با همهٔ ۲۴ ستون قابل مشاهده](category-axis-automatic.png)

**فاصله‌گذاری دستی (اسلاید ۲):** هر سومین برچسب در یک خط نمایش داده می‌شود، در حالی که تیک‌مارک‌ها در هر بازهٔ دسته باقی می‌مانند. همهٔ ۲۴ ستون، از جمله ستون‌های بدون برچسب، با همان مقادیر قابل مشاهده‌اند. اسلاید ۳ ظاهر خودکار نشان داده‌شده در بالا را بازگردانی می‌کند.

![فاصله‌گذاری برچسب‌های دسته به‌صورت سه‌تایی با همهٔ ۲۴ ستون قابل مشاهده](category-axis-manual.png)

### **انتخاب محور و بازهٔ صحیح**

از این بازهٔ شمارش دسته برای یک محور دسته‌ای متن استفاده کنید، مانند محور دسته‌ای یک نمودار ستون، خط، ناحیه یا میله. در یک نمودار ستون، این محور افقی است. در یک نمودار میلهٔ افقی، محور دسته‌ای عمودی است، بنابراین این تنظیمات را بر محور بازگشتی از [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) اعمال کنید. فاصله‌گذاری تیک‌مارک همچنین برای محور سری در نمودارهایی که دارای آن هستند، اعمال می‌شود.

از فاصله‌گذاری برچسب دسته برای تنظیم مقیاس عددی یک محور مقدار استفاده نکنید. در یک محور مقدار، [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) یک اختلاف عددی را مشخص می‌کند: به عنوان مثال، واحد اصلی `10` تیک‌ها را در ۰، ۱۰، ۲۰ و غیره تولید می‌کند وقتی محور از صفر شروع می‌شود. یک بازهٔ برچسب دسته‌ای `3` به‌جای مقادیر عددی، موقعیت‌های دسته‌ای را می‌شمارد. نمودارهای پراکندگی و حباب از محورهای مقدار به‌جای یک محور دسته‌ای متن استفاده می‌کنند. برای یک محور تاریخ، از واحدهای اصلی مبتنی بر زمان و مقیاس‌ها همان‌گونه که در [تغییر یک محور دسته‌ای](#change-a-category-axis) توضیح داده شد، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌ای**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌عنوان شماره‌های سریال OLE Automation در اولین کاربرگ (شاخص `0`) ذخیره می‌شوند که به‌عنوان تعداد روزهای گذشته از ۳۰‑دسامبر ۱۸۹۹ محاسبه می‌شوند. محاسبهٔ JavaScript از زمان‌سنجی UTC استفاده می‌کند و اختلاف را بر ۸۶٬۴۰۰٬۰۰۰ میلی‌ثانیه در هر روز تقسیم می‌کند. با استفاده از [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) با مقدار `CategoryAxisType.Date`، [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) را با `false` فراخوانی کنید و `yyyy` را به [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) بدهید تا برچسب‌های دسته سال‌های چهاررقمی را مستقل از قالب‌سازی سلول نمایش دهند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم زاویهٔ چرخش برای عنوان محور نمودار**

بر محور عمودی [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) را با مقدار `true` فراخوانی کنید، متن عنوان را ارائه دهید و با [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) زاویهٔ چرخش را تنظیم کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی را با عنوان محور مقدار که به‌صورت ۹۰ درجه چرخیده ذخیره می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم موقعیت محور روی محور دسته‌ای یا مقدار**

از [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) برای کنترل اینکه آیا محور مقدار در میان دسته‌ها یا روی تیک‌مارک‌های دسته عبور می‌کند استفاده کنید. این تنظیم برای محورهای دسته‌ای اعمال می‌شود. مثال این ویژگی را بر محور دسته‌ای افقی یک نمودار ستونی با مقدار `true` تنظیم می‌کند و نتیجه را ذخیره می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم واحد نمایش بر روی محور مقدار نمودار**

با استفاده از [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) برچسب‌های یک محور مقدار را بدون تغییر داده‌های پایه مقیاس می‌کنید. هنگامی که [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) بر `Millions` تنظیم شود، مقدار ۶۰٬۰۰۰٬۰۰۰ به‌صورت ۶۰ نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را بر محور عمودی آن اعمال می‌نماید.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پیکربندی یک محور مقدار لگاریتمی**

یک محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت در چندین مرتبهٔ بزرگی متفاوت قرار گیرند. به‌عنوان مثال، سرویسی ممکن است در پنج دوره ۱۰، ۱۰۰، ۱٬۰۰۰، ۱۰٬۰۰۰ و ۱۰۰٬۰۰۰ درخواست دریافت کند. در مقیاس خطی، مقادیر کوچکتر نزدیک به صفر و به‌هم‌چسبان ظاهر می‌شوند. مقیاس لگاریتمی رشد نسبی آن‌ها را آسان‌تر مقایسه می‌کند: فواصل برابر نشان‌دهندۀ نسبت‌های برابر هستند نه اختلاف‌های برابر.

با فراخوانی [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) با مقدار `true` بر محور مقدار و استفاده از [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) پایهٔ دلخواه را انتخاب کنید. این کار نحوهٔ نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خط روند لگاریتمی اضافه نمی‌کند. خط روند یک ویژگی جداگانه است که رابطهٔ برازش‌شدهٔ در داده‌ها را نشان می‌دهد.

### **انتخاب محور مقدار و پایه**

برای یک نمودار خطی یا ستونی، محور مقدار توسط [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) بازگردانده می‌شود. برای یک نمودار میله‌ای افقی، توسط [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) بازگردانده می‌شود. نمودارهای پراکندگی و حباب دو محور مقدار دارند، بنابراین برای مقادیر X محور افقی، برای مقادیر Y محور عمودی یا هر دو را انتخاب کنید. از اعمال مقیاس لگاریتمی بر محور دسته‌ای خودداری کنید.

پایهٔ پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX، می‌توانید پایه‌ای بین `2` تا `1000` (شامل) استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایهٔ `10` توان‌های متوالی مانند ۱۰، ۱۰۰، ۱٬۰۰۰ و ۱۰٬۰۰۰ به‌صورت مساوی فاصله دارند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال زیر یک نمودار خطی با پنج شمارش درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی می‌کند و در اسلاید دوم پایهٔ لگاریتمی ۱۰ را فعال می‌سازد. هر دو اسلاید داده‌های یکسانی را حفظ می‌کنند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // اسلاید اول را خطی نگه داشته و فقط مقیاس محور مقدار نسخهٔ کپی شده را تغییر دهید.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**مقیاس خطی (اسلاید ۱):** فواصل عمودی برابر نشان‌دهندۀ اختلاف‌های مساوی در شمارش درخواست‌ها هستند. مقدار بزرگتر به‌صورت غالب در نمودار ظاهر می‌شود و مقادیر کوچکتر تشخیص دشواری دارند.

![نمودار خطی در PowerPoint که پنج شمارش درخواست را بر محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید ۲):** فواصل عمودی برابر نشان‌دهندۀ نسبت‌های مساوی هستند. هر دوره ten‑fold بیشتر از دوره قبل است، بنابراین نقاط در مقیاس لگاریتمی پایه‑۱۰ یک خط مستقیم صعودی شکل می‌دهند. برچسب‌های محور همچنان شمارش درخواست‌های اصلی را نشان می‌دهند.

![همان پنج شمارش درخواست در PowerPoint بر محور مقدار لگاریتمی پایه‑۱۰](value-axis-logarithmic.png)

### **مدیریت مقادیر صفر و منفی**

یک مقیاس لگاریتمی تنها می‌تواند مقادیر مثبت مطلق را نمایش دهد. پیش از فعال‌سازی آن، داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنی‌دار هستند، یا مقیاس خطی را حفظ کنید یا آن‌ها را جداگانه نشان دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلیل حذف را توضیح دهید. به‌صورت خاموش آنها را با عددهای مثبت کوچک جایگزین نکنید، زیرا معنای داده‌ها را تغییر می‌دهد. هر حداقل یا حداکثر به‌صورت دستی تنظیم‌شده برای یک محور لگاریتمی نیز باید مثبت باشد.

## **سؤالات متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر (crossing) را تنظیم کنم؟**

از [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) برای انتخاب رفتار تقاطع استفاده کنید. برای تعیین مقدار عددی تقاطع، [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) را به کار ببرید. این تنظیمات به شما امکان می‌دهند تقاطع محور را به یک خط پایه مناسب منتقل کنید.

**چگونه می‌توانم موقعیت برچسب‌های تیک را نسبت به محور تنظیم کنم؟**

با فراخوانی [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) و استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) مقادیر `Low`، `High`، `NextTo` یا `None` موقعیت برچسب‌ها را تعیین کنید. برای کنترل خود تیک‌مارک‌ها، از [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) یا [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/) استفاده کنید؛ این تنظیمات جدا از موقعیت برچسب‌ها هستند.