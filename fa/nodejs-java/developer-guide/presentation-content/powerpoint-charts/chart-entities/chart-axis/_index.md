---
title: سفارشی‌سازی محورها در نمودارها در ارائه‌ها با استفاده از JavaScript
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
- کمینه مقدار
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "کشف کنید چگونه می‌توان با JavaScript و Aspose.Slides برای Node.js از طریق Java، محورها را در نمودارهای PowerPoint برای گزارش‌ها و تجسم‌ها سفارشی‌سازی کرد."
---
## **بررسی کلی**

این مقاله نحوهٔ سفارشی‌سازی محورها در نمودارها با Aspose.Slides برای Node.js از طریق Java را توضیح می‌دهد. موارد شامل مقادیر محاسبه‌شدهٔ محور، جابجایی سطرها و ستون‌های نمودار، نمایش یا پنهان‌سازی محورها، بازه‌های برچسب دسته‌بندی و تیک‌مارک، دسته‌بندی‌های تاریخ و قالب‌بندی آن‌ها، چرخش عنوان، موقعیت‌گذاری محور، واحدهای نمایش و مقیاس لگاریتمی می‌شود.

## **دریافت حداکثر مقادیر محور عمودی در نمودارها**

یک [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید و یک نمودار مساحتی با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شدهٔ محور، برای به‌روزرسانی طرح نمودار، [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) را فراخوانی کنید.

مقادیر حداکثر و حداقل محور را با استفاده از [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) و [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) بخوانید و بازه‌های تیک را با [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) و [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) دریافت کنید. مقیاس‌های واحد زمانی را که برای محورهای تاریخ مرتبط هستند، می‌توانید با [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) و [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) به دست آورید. مثال این مقادیر را در متغیرهای محلی ذخیره کرده و نمودار را ذخیره می‌کند.

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

از [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) برای تعویض نقش سری‌ها و دسته‌بندی‌ها در داده‌های نمودار استفاده کنید. هر دسته‌بندی قبلی تبدیل به یک سری می‌شود و هر سری قبلی تبدیل به یک دسته‌بندی می‌شود. این تغییر نحوهٔ گروه‌بندی داده‌ها را تحت تأثیر قرار می‌دهد؛ محورها افقی و عمودی را تعویض نمی‌کند. مثال از [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) برای اتصال داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل سطر عنوان و ستون دسته‌بندی، قبل از تعویض سطرها و ستون‌ها استفاده می‌کند. یک نمودار با چهار سری و سه دسته‌بندی ذخیره می‌کند.

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

## **معکوس کردن ترتیب ترسیم یک محور**

از [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) برای معکوس کردن محور دسته‌بندی یا مقدار استفاده کنید. به عنوان مثال، یک نمودار میله‌ای افقی می‌تواند مراحل پروژه را از بالا به پایین در همان ترتیب برگهٔ کاری نشان دهد: Planning, Development, Testing. معکوس کردن یک محور جهت ترسیم را تغییر می‌دهد؛ داده‌های برگهٔ کاری را مرتب یا جابه‌جا نمی‌کند. برای مقایسه، [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) نقش سری‌ها و دسته‌بندی‌ها را تعویض می‌کند.

مثال زیر یک نمودار میله‌ای افقی با سه مرحله و یک سری ایجاد می‌کند. ارائه‌ای با سه اسلاید ذخیره می‌کند: ترتیب عادی، دسته‌بندی‌های معکوس و مقادیر معکوس. هر نسخه از همان داده‌ها استفاده می‌کند و فقط یک محور در هر نسخه معکوس می‌شود.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // اسلاید ۲: نمایش اولین دسته‌بندی در بالا.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // محور مقدار افقی را در پایین نگه دارید.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // اسلاید ۳: فقط مقیاس عددی افقی را معکوس کنید.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

معکوس کردن یک محور می‌تواند محور عمود را به سمت opposite side of the plot منتقل کند. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) تعیین می‌کند که محور دیگر در کجا محور تنظیم‌شده را قطع می‌کند. در اسلاید 2، با استفاده از `aspose.slides.CrossesType.Maximum` روی محور دسته‌بندی معکوس، محور مقدار افقی در پایین باقی می‌ماند. برای یک نقطهٔ قطع خاص، از [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) استفاده کنید. هنگام تغییر جهت، تنظیمات قطع را بررسی کنید، به‌ویژه اگر نمودار قبلاً نقطهٔ قطع سفارشی دارد. برای برگرداندن جهت عادی، `setPlotOrderReversed` را با `false` فراخوانی کنید؛ تنظیمات قطع جداگانه هستند.

| ترتیب عادی (اسلاید 1) | دسته‌بندی‌های معکوس (اسلاید 2) | مقادیر معکوس (اسلاید 3) |
| --- | --- | --- |
| ![نمودار میله‌ای افقی با ترتیب عادی محور دسته‌بندی و مقدار](axis-order-normal.png) | ![نمودار میله‌ای افقی با نمایش دسته‌بندی‌ها از بالا به پایین](axis-order-categories-reversed.png) | ![نمودار میله‌ای افقی با محور مقدار معکوس و صفر در سمت راست](axis-order-values-reversed.png) |
| دسته‌بندی‌ها از پایین به بالا حرکت می‌کنند؛ مقادیر از چپ به راست افزایش می‌یابند. | Planning, Development, و Testing از بالا به پایین حرکت می‌کنند. مقادیر و ترتیب سطرهای برگهٔ کاری تغییر نمی‌کند. | دسته‌بندی‌ها ترتیب عادی خود را حفظ می‌کنند؛ مقادیر از راست به چپ افزایش می‌یابند. محور دسته‌بندی در صفر سمت راست قطع می‌شود. |

## **غیرفعال کردن محور عمودی برای نمودارهای خطی**

با فراخوانی [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) با مقدار `false` روی محور عمودی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد کرده و آن را با محور عمودی مخفی ذخیره می‌کند.

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

با فراخوانی [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) با مقدار `false` روی محور افقی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد کرده و آن را با محور افقی مخفی ذخیره می‌کند.

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

## **نمایش یا مخفی کردن خطوط شبکهٔ نمودار**

با فراخوانی [getShowMajorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowmajorgridlines/) و [getShowMinorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowminorgridlines/) می‌توانید بررسی کنید که کدام خطوط شبکهٔ محور نمایش داده می‌شوند. برای نمایش خطوط شبکهٔ جزئی، از [getMinorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getminorgridlinesformat/) استفاده کنید و پرخط را به رنگ جامد و قابل مشاهده تنظیم کنید. برای مخفی کردن آن‌ها، پرکرده را به [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) تنظیم کنید. برای خطوط شبکهٔ اصلی نیز می‌توانید از [getMajorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getmajorgridlinesformat/) به همان روش استفاده کنید. تغییر پرکردگی، نمایش محورها و تیک‌ها را حفظ می‌کند.

محور عمودی این نمودار میله‌ای خوشه‌ای ابتدا فقط خطوط شبکهٔ اصلی را نشان می‌دهد. مثال خطوط شبکهٔ جزئی را به رنگ نارنجی تیره نمایش می‌دهد، سپس دوباره آن‌ها را مخفی می‌کند و سپس ارائه را ذخیره می‌کند. این مثال در هر مرحله وضعیت نمایش خطوط شبکه را چاپ می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 30, 660, 230);
    var axis = chart.getAxes().getVerticalAxis();
    console.log("Initial: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    var minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    var darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    minorFill.getSolidFillColor().setColor(darkOrange);
    console.log("Enabled: minor=%s", axis.getShowMinorGridLines());

    minorFill.setFillType(java.newByte(aspose.slides.FillType.NoFill));
    console.log("Hidden: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| خطوط شبکهٔ جزئی فعال | خطوط شبکهٔ جزئی مخفی |
| --- | --- |
| ![خطوط شبکهٔ جزئی نارنجی بین خطوط اصلی بر محور عمودی](minor-gridlines-enabled.png) | ![همان نمودار میله‌ای با فقط خطوط شبکهٔ اصلی قابل مشاهده](minor-gridlines-hidden.png) |

## **تغییر محور دسته‌بندی**

از [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) برای انتخاب محور دسته‌بندی تاریخ یا متن استفاده کنید. این مثال به فایل `ExistingChart.pptx` نیاز دارد که در اسلاید اول اولین شکل آن یک نمودار باشد و سلول‌های دسته‌بندی شامل مقادیر عددی تاریخ Excel باشند. محور افقی را به محور تاریخ تغییر می‌دهد. با فراخوانی [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) با مقدار `false`، [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) با مقدار `1` و [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) با `TimeUnitType.Months` تیک‌های اصلی را در فواصل یک‌ماهه تنظیم می‌کند.

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

### **تعیین نوع محور دسته‌بندی از داده‌ها**

پس از پرکردن دسته‌بندی‌ها، [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistypeautomatically/) را فراخوانی کنید، سپس با خواندن [getCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getcategoryaxistype/) نوع انتخاب‌شده را بررسی کنید. این روش زمانی مفید است که همان نمودار یا برچسب‌های متنی یا مقادیر عددی تاریخ را دریافت کند. این متد زمان فراخوانی نوع را تعیین می‌کند؛ حالت پایدار برای ارزیابی مجدد تغییرات بعدی داده‌ها فراهم نمی‌کند. پس از جایگزینی دسته‌بندی‌ها، دوباره آن را فراخوانی کنید.

مثال زیر یک نمودار با دسته‌بندی‌های متنی ایجاد می‌کند و وقتی نوع انتخاب‌شده `CategoryAxisType.Text` باشد `true` چاپ می‌کند. سپس مقادیر سلول دسته‌بندی را با تاریخ‌ها جایگزین می‌کند و دوباره متد را فراخوانی می‌کند و وقتی نوع انتخاب‌شده `CategoryAxisType.Date` باشد `true` چاپ می‌کند. تاریخ‌ها به‌عنوان مقدارهای عددی OLE Automation ذخیره می‌شوند که به‌عنوان تعداد روزها از 30 دسامبر 1899 حساب می‌شوند، نه به‌صورت رشتهٔ تاریخ. محاسبهٔ JavaScript از زمان‌موقعیت‌های UTC استفاده می‌کند و اختلاف را بر 86 400 000 میلیثانیه در روز تقسیم می‌کند؛ ایندکس‌های ماه صفر‑پایه هستند. برای ارسال هر مقدار تاریخ به Java به‌عنوان double از `java.newDouble` استفاده کنید. [setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) کنترل می‌کند که این مقدارها چگونه نمایش داده شوند؛ متن را به تاریخ عددی تبدیل نمی‌کند. برای اطلاعات بیشتر دربارهٔ سلول‌های دسته‌بندی، به [Chart Workbook](/slides/fa/nodejs-java/chart-workbook/) مراجعه کنید.

از تعیین خودکار استفاده کنید وقتی ورودی شامل دسته‌بندی‌های متنی یا تاریخ‌های عددی باشد، همان‌طور که در این مثال نشان داده شده است. برای برچسب‌های عددی معمولی، دسته‌بندی‌های ترکیبی یا داده‌های خالی، به‌صورت صریح از [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) برای مطابقت با معنای موردنظر استفاده کنید. مقادیر عددی به‌تنهایی نشان نمی‌دهند که دسته‌بندی‌ها تاریخ هستند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var seriesName = workbook.getCell(0, 0, 1, "Sales");
    var series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    var labels = ["First", "Second", "Third"];

    for (var i = 0; i < labels.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Text); // درست

    var baseDate = Date.UTC(1899, 11, 30);
    var dates = [Date.UTC(2026, 0, 1), Date.UTC(2026, 0, 2), Date.UTC(2026, 1, 1)];

    for (var i = 0; i < dates.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0);
        var dateValue = java.newDouble((dates[i] - baseDate) / 86400000);
        categoryCell.setValue(dateValue);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Date); // درست

    presentation.save("AutomaticCategoryAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **کنترل بازه‌های برچسب محور دسته‌بندی**

زمانی که یک نمودار دارای تعداد زیادی دسته‌بندی باشد، می‌توانید عدد برچسب‌های محوری قابل مشاهده را بدون حذف دسته‌بندی‌ها یا نقاط داده کاهش دهید. با فراخوانی [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) با مقدار `false`، سپس بازهٔ دلخواه دسته‌بندی را به [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/) می‌دهید. برای دسته‌بندی‌های متنی در ترتیب عادی، شمارش از اولین دسته‌بندی آغاز می‌شود:

| بازه | برچسب‌های نمایش‌داده‌شده در مثال |
| --- | --- |
| `1` | دسته 1, دسته 2, دسته 3, ... دسته 24 |
| `2` | دسته 1, دسته 3, دسته 5, ... دسته 23 |
| `3` | دسته 1, دسته 4, دسته 7, ... دسته 22 |

بازهٔ `3` هر برچسب سوم را نشان می‌دهد و دو برچسب بین برچسب‌های نمایش‌داده‌شده پنهان می‌مانند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصله‌گذاری خودکار بر اساس فضای موجود یک بازه انتخاب می‌کند؛ لزوماً تمام برچسب‌ها را نشان نمی‌دهد.

تیک‌مارک‌ها کنترل جداگانه‌ای دارند. با فراخوانی [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) با مقدار `false` و استفاده از [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) می‌توانید بازهٔ آن‌ها را تنظیم کنید. برای مثال، مقدار `1` یک تیک‌مارک در هر بازهٔ دسته‌بندی حفظ می‌کند در حالی که برچسب‌ها فقط هر سومین دسته‌بندی نمایش می‌یابند. با استفاده از [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) یک سبک قابل مشاهده تنظیم کنید تا نتیجه را ببینید. فراخوانی هرکدام از تنظیم‌کننده‌های خودکار با `true` مجدداً به نمودار اجازه می‌دهد تا بازه را به‌صورت خودکار انتخاب کند.

مثال خودکفای زیر ۲۴ دسته‌بندی و یک سری ایجاد می‌کند، سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصله‌گذاری خودکار، فاصله‌گذاری دستی برچسب‌ها با تیک‌مارک‌های مستقل، و بازگشت به فاصله‌گذاری خودکار. دو نسخهٔ کپی داده‌های اصلی نمودار را حفظ می‌کنند. ارائهٔ ورودی لازم نیست. متنی که بر روی برچسب‌ها افقی قرار می‌گیرد، اختلاف تراکم را به‌راحتی نشان می‌دهد.

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

    // اسلاید ۲: نمایش هر سومین برچسب، اما برای هر دسته‌بندی یک تیک‌مارک نگه دارید.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // اسلاید ۳: اجازه دهید نمودار دوباره هر دو بازه را انتخاب کند.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**فاصله‌گذاری خودکار (اسلاید 1):** در این رندر، هر دومین برچسب دسته‌بندی نمایش داده می‌شود و به دو خط می‌پیچد. نتیجهٔ خودکار می‌تواند بسته به اندازهٔ نمودار، فونت‌ها و رندر کننده متغیر باشد.

![فاصله‌گذاری خودکار برچسب‌های دسته‌بندی با نمایش تمام ۲۴ ستون](category-axis-automatic.png)

**فاصله‌گذاری دستی (اسلاید 2):** هر سومین برچسب در یک خط نمایش داده می‌شود، در حالی که تیک‌مارک‌ها در هر بازهٔ دسته‌بندی باقی می‌مانند. تمام ۲۴ ستون، شامل آن‌هایی که برچسب ندارند، با همان مقادیر قابل مشاهده هستند. اسلاید ۳ ظاهر خودکار نشان داده‌شده در بالا را بازگردانی می‌کند.

![فاصله‌گذاری دستی برچسب‌های دسته‌بندی به‌صورت سه‌تایی با نمایش تمام ۲۴ ستون](category-axis-manual.png)

### **انتخاب محور و بازهٔ صحیح**

از این بازهٔ شمارش دسته‌بندی برای محور دسته‌بندی متنی استفاده کنید، مانند محور دسته‌بندی یک نمودار میله‌ای، خطی، مساحتی یا ستونی. در یک نمودار ستونی، این محور افقی است. در یک نمودار میله‌ای افقی، محور دسته‌بندی عمودی است، بنابراین این تنظیمات را روی محوری که توسط [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) برگردانده می‌شود اعمال کنید. فاصله‌گذاری تیک‌مارک‌ها نیز برای محور سری در نمودارهایی که دارای چنین محوری هستند، اعمال می‌شود.

از فاصله‌گذاری برچسب‌های دسته‌بندی برای تنظیم مقیاس عددی یک محور مقدار استفاده نکنید. در یک محور مقدار، [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) اختلافی در مقادیر مشخص می‌کند: به‌عنوان مثال، واحد اصلی `10` تیک‌مارک‌ها را در 0، 10، 20 و غیره قرار می‌دهد وقتی محور از صفر شروع می‌شود. بازهٔ برچسب‌های دسته‌بندی `3` به‌جای مقدارهای داده‌ای، موقعیت‌های دسته‌بندی را می‌شمارد. نمودارهای پراکنش و حبابی از محورها مقدار استفاده می‌کنند نه محور متنی دسته‌بندی. برای محور تاریخ، از واحدهای اصلی مبتنی بر زمان و مقیاس‌ها همان‌طور که در [تغییر محور دسته‌بندی](#change-a-category-axis) توضیح داده شد، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌بندی**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌عنوان شمارهٔ سریال OLE Automation در اولین برگه کاری (اندیس `0`) ذخیره می‌شوند و به‌عنوان تعداد روزها از 30 دسامبر 1899 محاسبه می‌شوند. محاسبهٔ JavaScript از زمان‌موقعیت‌های UTC استفاده می‌کند و اختلاف را بر 86 400 000 میلیثانیه در روز تقسیم می‌کند. با استفاده از [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) همراه با `CategoryAxisType.Date`، [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) را با مقدار `false` فراخوانی کنید و `yyyy` را به [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) پاس دهید تا برچسب‌های دسته‌بندی سال‌های چهاررقمی را صرف‌نظر از قالب‌بندی سلول نمایش دهد.

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

## **تنظیم زاویهٔ چرخش عنوان محور نمودار**

با فراخوانی [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) با مقدار `true` روی محور عمودی، متن عنوان را فراهم کنید و از [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) برای چرخاندن عنوان استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی را با عنوان محور مقدار که به‌صورت 90 درجه چرخانده شده ذخیره می‌کند.

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

## **تنظیم موقعیت محور در محور دسته‌بندی یا مقدار**

از [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) برای کنترل اینکه آیا محور مقدار بین دسته‌بندی‌ها یا در تیک‌مارک‌های دسته‌بندی محور را قطع می‌کند، استفاده کنید. این تنظیم برای محورها دسته‌بندی اعمال می‌شود. مثال این تنظیم را روی محور دسته‌بندی افقی یک نمودار ستونی به `true` تغییر می‌دهد و نتیجه را ذخیره می‌کند.

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

## **تنظیم واحد نمایش در محور مقدار نمودار**

از [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) برای مقیاس‌بندی برچسب‌های یک محور مقدار بدون تغییر داده‌های زیرین استفاده کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) به `Millions`، مقدار 60 000 000 به‌صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را بر محور عمودی آن اعمال می‌نماید.

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

## **پیکربندی محور مقدار لگاریتمی**

یک محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت در چندین مرتبهٔ قدرتمند متفاوت باشند. به عنوان مثال، سرویسی ممکن است 10، 100، 1 000، 10 000 و 100 000 درخواست در پنج دوره دریافت کند. در مقیاس خطی، مقادیر کوچکتر نزدیک به صفر جمع می‌شوند. مقیاس لگاریتمی رشد نسبی آن‌ها را آسان‌تر مقایسه می‌کند: فواصل مساوی نشان‌دهندهٔ نسبت‌های برابر نه اختلاف‌های عددی برابر هستند.

با فراخوانی [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) با مقدار `true` روی محور مقدار و استفاده از [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) برای انتخاب پایه، این تغییر نحوهٔ نمایش مقادیر موجود را تحت تأثیر قرار می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خط روند لگاریتمی اضافه نمی‌کند. خط روند یک ویژگی جداگانه است.

### **انتخاب محور مقدار و پایه**

در یک نمودار خطی یا ستونی، محور مقدار توسط [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) بازمی‌گردد. در یک نمودار میله‌ای افقی، توسط [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) بازمی‌گردد. نمودارهای پراکنش و حبابی دو محور مقدار دارند، بنابراین برای مقادیر X محور افقی، برای مقادیر Y محور عمودی یا هر دو را انتخاب کنید. مقیاس لگاریتمی را بر محور دسته‌بندی اعمال نکنید.

پایهٔ پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX، می‌توانید پایه‌ای بین `2` تا `1000` (شامل) استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایهٔ `10`، توان‌های متوالی همچون 10، 100، 1 000 و 10 000 به‌صورت برابر فاصله‌گذاری می‌شوند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال خودکفای زیر یک نمودار خطی با پنج شمارش درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی کرده و در اسلاید دوم محور مقدار لگاریتمی پایه‌10 را فعال می‌کند. هر دو اسلاید داده‌های یکسانی را حفظ می‌کنند.

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

    // اسلاید اول را به‌صورت خطی نگه دارید و تنها مقیاس محور مقدار نسخه‌ی کپی را تغییر دهید.
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

**مقیاس خطی (اسلاید 1):** فواصل عمودی برابر نشان‌دهندهٔ اختلاف‌های مساوی در شمارش درخواست‌ها هستند. مقدار بزرگ‌ترین مقدار نمودار را dominate می‌کند و مقادیر کوچکتر را تشخیص دشوار می‌کند.

![نمودار خطی در PowerPoint که پنج شمارش درخواست را بر محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید 2):** فواصل عمودی برابر نشان‌دهندهٔ نسبت‌های مساوی هستند. هر دوره ده برابر درخواست دورهٔ قبلی دارد، بنابراین نقاط روی مقیاس پایه‌10 به‌صورت خط صعودی مستقیم ظاهر می‌شوند. برچسب‌های محور همچنان شمارش اصلی درخواست‌ها را نشان می‌دهند.

![همان پنج شمارش درخواست در PowerPoint بر محور مقدار لگاریتمی پایه‌10](value-axis-logarithmic.png)

### **مدیریت مقدار صفر و منفی**

مقیاس لگاریتمی فقط می‌تواند مقادیر مثبت مطلق را نمایش دهد. قبل از فعال‌سازی آن داده‌ها را بررسی کنید. اگر مقدار صفر یا منفی معنایی داشته باشد، مقیاس خطی را حفظ کنید یا آن‌ها را جداگانه نشان دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلیل حذف را توضیح دهید. به‌صورت خامسیت آنها را با مقادیر مثبت کوچک جایگزین نکنید، زیرا معنای داده را تغییر می‌دهد. هر حداقل یا حداکثر به‌صورت دستی برای یک محور لگاریتمی تنظیم می‌شود باید مثبت باشد.

## **سوالات متداول**

**How do I set the value at which one axis crosses the other (axis crossing)?**

از [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) برای انتخاب رفتار قطع محور استفاده کنید. برای تعیین مقدار عددی قطع، از [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) استفاده کنید. این تنظیمات به شما امکان می‌دهند نقطهٔ قطع محور را به خط پایهٔ مناسب منتقل کنید.

**How can I position tick labels relative to the axis?**

با فراخوانی [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) و استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` یا `None` موقعیت برچسب‌های تیک را تنظیم کنید. برای کنترل خود تیک‌مارک‌ها، می‌توانید از [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) یا [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/) استفاده کنید؛ این تنظیمات جدا از موقعیت برچسب‌ها هستند.