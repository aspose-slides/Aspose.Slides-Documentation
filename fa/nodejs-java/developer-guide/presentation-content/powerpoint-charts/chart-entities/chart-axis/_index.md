---
title: سفارشی‌سازی محورهای نمودار در ارائه‌ها با استفاده از JavaScript
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
- خصوصیات محور
- مقدار حداکثری
- مقدار حداقل
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- پاورپوینت
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "کشف کنید چگونه با JavaScript و Aspose.Slides برای Node.js از طریق Java می‌توانید محورهای نمودار را در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها سفارشی کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه محورهای نمودار را با Aspose.Slides برای Node.js از طریق Java سفارشی کنید. این مقاله به مقادیر محاسبه‌شده محور، تعویض ردیف‌ها و ستون‌های نمودار، نمایش محور، فواصل برچسب‌های دسته‌بندی و علامت‌های تیک، دسته‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت‌گذاری محور و واحدهای نمایش می‌پردازد.

## **دریافت مقادیر حداکثری در محور عمودی نمودارها**

یک [ارائه](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید و یک نمودار ناحیه‌ای با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، متد [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) را فراخوانی کنید تا چیدمان نمودار به‌روز باشد.

برای محدودیت‌های محور، متدهای [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) و [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) را بخوانید، و برای فواصل علامت‌های تیک، متدهای [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) و [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) را بخوانید. متدهای [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) و [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) مقیاس‌های زمان‑واحد را فراهم می‌کنند که برای محورهای تاریخی مرتبط هستند. مثال این مقادیر را در متغیرهای محلی ذخیره کرده و نمودار را ذخیره می‌کند.

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

## **تعویض داده‌ها بین محورها**

از [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته قبلی به یک سری تبدیل می‌شود و هر سری قبلی به یک دسته. این تغییر نحوه گروه‌بندی داده‌ها را تحت تأثیر قرار می‌دهد؛ محورهای افقی و عمودی را تعویض نمی‌کند. مثال از [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) برای اتصال داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل سطر سرعنوان و ستون دسته، قبل از تعویض ردیف‌ها و ستون‌ها استفاده می‌کند. یک نمودار با چهار سری و سه دسته ذخیره می‌کند.

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

## **غیرفعال‌سازی محور عمودی برای نمودارهای خطی**

متد [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) را با مقدار `false` برای محور عمودی فراخوانی کنید تا مخفی شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد کرده و آن را با محور عمودی مخفی ذخیره می‌کند.

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

## **غیرفعال‌سازی محور افقی برای نمودارهای خطی**

متد [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) را با مقدار `false` برای محور افقی فراخوانی کنید تا مخفی شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد کرده و آن را با محور افقی مخفی ذخیره می‌کند.

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

## **تغییر محور دسته‌بندی**

از [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) برای انتخاب محور دسته‌بندی تاریخ یا متن استفاده کنید. این مثال به فایل `ExistingChart.pptx` نیاز دارد که در اسلاید اول شکل اول یک نمودار داشته باشد و سلول‌های دسته شامل مقادیر عددی تاریخ Excel باشند. محور افقی به محور تاریخ تغییر می‌کند. فراخوانی [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) با مقدار `false`، [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) با مقدار `1` و [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) با مقدار `TimeUnitType.Months` علامت‌های اصلی را در فواصل یک‑ماهانه قرار می‌دهد.

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

## **کنترل فواصل برچسب‌های محور دسته‌بندی**

وقتی یک نمودار تعداد زیادی دسته داشته باشد، می‌توانید تعداد برچسب‌های قابل مشاهده محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. متد [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) را با مقدار `false` فراخوانی کنید، سپس فاصله دلخواه دسته را به [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/) پاس دهید. برای دسته‌های متنی به ترتیب عادی، شمارش از اولین دسته شروع می‌شود:

| فاصله | برچسب‌های نمایش‌داده‌شده در مثال |
| --- | --- |
| `1` | دسته 1، دسته 2، دسته 3، … دسته 24 |
| `2` | دسته 1، دسته 3، دسته 5، … دسته 23 |
| `3` | دسته 1، دسته 4، دسته 7، … دسته 22 |

یک فاصلهٔ `3` هر برچسب سوم را نمایش می‌دهد و دو برچسب بین برچسب‌های نمایش‌داده‌شده مخفی می‌ماند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصلهٔ خودکار براساس فضای موجود یک مقدار را انتخاب می‌کند؛ لزوماً همهٔ برچسب‌ها را نشان نمی‌دهد.

علامت‌های تیک کنترل‌های جداگانه‌ای دارند. متد [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) را با مقدار `false` فراخوانی کنید و از [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) برای تعیین فواصل آنها استفاده کنید. برای مثال، `1` یک علامت تیک در هر فاصلهٔ دسته حفظ می‌کند در حالی که برچسب‌ها فقط هر سومین دسته ظاهر می‌شوند. از [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) با سبک قابل مشاهده استفاده کنید تا نتیجه را ببینید. فراخوانی هر یک از تنظیم‌کننده‌های فاصلهٔ خودکار با مقدار `true` دوباره اجازه می‌دهد تا نمودار همان فاصله را انتخاب کند.

مثال خودکفی زیر ۲۴ دسته و یک سری ایجاد می‌کند و سپس سه اسلاید را در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصلهٔ خودکار، فاصلهٔ دستی برچسب با علامت‌های تیک مستقل، و بازگرداندن فاصلهٔ خودکار. دو نسخهٔ کپی داده‌های اصلی نمودار را حفظ می‌کنند. ارائهٔ ورودی لازم نیست. متن برچسب افقی تفاوت چگالی را به راحتی نشان می‌دهد.

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

    // اسلاید ۲: هر سومین برچسب را نمایش بده، اما علامت تیک را برای هر دسته حفظ کن.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // اسلاید ۳: بگذارید نمودار دوباره هر دو فاصله را انتخاب کند.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**فاصله‌گذاری خودکار (اسلاید 1):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و بر روی دو خط می‌پیچد. نتیجهٔ خودکار ممکن است با اندازهٔ نمودار، فونت‌ها و رندرر متفاوت باشد.

![فاصله‌گذاری خودکار برچسب‌های دسته با تمام ۲۴ ستون قابل مشاهده](category-axis-automatic.png)

**فاصله‌گذاری دستی (اسلاید 2):** هر سومین برچسب در یک خط نمایش داده می‌شود، در حالی که علامت‌های تیک در هر فاصلهٔ دسته باقی می‌مانند. تمام ۲۴ ستون، از جمله آن‌هایی که برچسب ندارند، با همان مقادیر قابل مشاهده هستند. اسلاید 3 ظاهر خودکار نشان‑داده‌شده در بالا را بازگردانی می‌کند.

![فاصله‌گذاری دستی برچسب‌های دسته به مقدار سه با تمام ۲۴ ستون قابل مشاهده](category-axis-manual.png)

### **انتخاب محور و فاصله صحیح**

از این فاصلهٔ شمارش‑دسته برای محور دسته‌بندی متن استفاده کنید، مانند محور دسته‌بندی یک نمودار ستونی، خطی، ناحیه‌ای یا میله‌ای. در یک نمودار ستونی، این محور افقی است. در یک نمودار میله‌ای افقی، محور دسته‌بندی عمودی است، بنابراین این تنظیمات را بر روی محوری که توسط [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) برگردانده می‌شود اعمال کنید. فاصلهٔ علامت‌تیک همچنین برای محور سری در نمودارهایی که چنین محوری دارند، اعمال می‌شود.

از فاصلهٔ برچسب دسته برای تنظیم مقیاس عددی یک محور مقدار استفاده نکنید. در یک محور مقدار، متد [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) اختلافی در مقادیر را مشخص می‌کند: برای مثال، یک واحد اصلی `10` علامت‌هایی در 0، 10، 20 و غیره تولید می‌کند وقتی محور از صفر شروع شود. یک فاصلهٔ برچسب دستهٔ `3` به جای آن موقعیت‌های دسته را می‌شمارد، صرف‌نظر از مقادیر داده‌ای آنها. نمودارهای پراکندگی و حباب از محورهای مقدار استفاده می‌کنند نه از محور دسته‌بندی متن. برای یک محور تاریخ، از واحدهای اصلی مبتنی بر زمان و مقیاس‌ها همان‌طور که در [تغییر محور دسته‌بندی](#change-a-category-axis) توضیح داده شده است، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌بندی**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌عنوان شماره‌های سریالی OLE Automation در اولین ورک‌شیت (اندیس `0`) ذخیره می‌شوند و به‌عنوان تعداد روزهای سپری‌شده از 30 دسامبر 1899 محاسبه می‌شوند. محاسبهٔ JavaScript از تایم‌استمپ‌های UTC استفاده می‌کند و اختلاف را بر 86 400 000 میلی‌ثانیه در هر روز تقسیم می‌کند. از [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) با مقدار `CategoryAxisType.Date`، متد [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) با مقدار `false` و `yyyy` به [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) استفاده کنید تا برچسب‌های دسته بدون در نظر گرفتن قالب‌بندی سلول، سال‌های چهاررقمی را نمایش دهند.

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

## **تنظیم زاویه چرخش برای عنوان محور نمودار**

متد [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) را با مقدار `true` برای محور عمودی فراخوانی کنید، متن عنوان را ارائه دهید و از [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) برای چرخاندن عنوان استفاده کنید. زاویه به درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی را با عنوان محور مقدار که به‌صورت 90 درجه چرخیده ذخیره می‌کند.

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

## **تنظیم موقعیت محور بر روی محور دسته یا مقدار**

از [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) برای کنترل این که آیا محور مقدار محور دسته را بین دسته‌ها یا در علامت‌تیک‌های دسته عبور می‌دهد استفاده کنید. این تنظیم برای محورهای دسته‌بندی اعمال می‌شود. مثال این مقدار را بر روی محور دسته‌بندی افقی یک نمودار ستونی به `true` تنظیم می‌کند و نتیجه را ذخیره می‌کند.

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

از [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) برای مقیاس‌بندی برچسب‌های محور مقدار بدون تغییر داده‌های پایه استفاده کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) به `Millions`، مقدار 60 000 000 به صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را بر روی محور عمودی آن اعمال می‌کند.

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

## **پرسش‌های متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر (تقاطع محور) را تنظیم کنم؟**

از [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) برای انتخاب رفتار تقاطع استفاده کنید. برای تعیین یک مقدار عددی تقاطع، از [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) استفاده کنید. این تنظیمات به شما امکان می‌دهند تقاطع محور را به خط پایهٔ مناسب منتقل کنید.

**چگونه می‌توانم برچسب‌های علامت تیک را نسبت به محور موقعیت‌دهی کنم؟**

متد [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) را با استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) فراخوانی کنید: `Low`، `High`، `NextTo` یا `None`. برای کنترل خود علامت‌های تیک، از [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) یا [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/) استفاده کنید؛ این‌ها جدا از موقعیت‌دهی برچسب هستند.