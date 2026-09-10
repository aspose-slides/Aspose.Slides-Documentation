---
title: ایجاد یا به‌روزرسانی نمودارهای ارائه PowerPoint در JavaScript
linktitle: ایجاد یا به‌روزرسانی نمودارها
type: docs
weight: 10
url: /fa/nodejs-java/create-chart/
keywords:
- افزودن نمودار
- ایجاد نمودار
- ویرایش نمودار
- تغییر نمودار
- به‌روزرسانی نمودار
- نمودار پراکنده
- نمودار دایره‌ای
- نمودار خطی
- نمودار درختی
- نمودار سهام
- نمودار جعبه‌ای و ویسکر
- نمودار قیفی
- نمودار خورشیدی
- نمودار هیستوگرام
- نمودار رادار
- نمودار چنددسته‌ای
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "نمودارها را در ارائه‌های PowerPoint با Aspose.Slides برای Node.js ایجاد و سفارشی‌سازی کنید. نمودارها را اضافه، قالب‌بندی و ویرایش کنید با مثال‌های کد عملی در JavaScript."
---
## **نمای کلی**

این مقاله راهنمای جامعی برای ایجاد و سفارشی‌سازی نمودارها با Aspose.Slides ارائه می‌دهد. شما می‌توانید نحوه افزودن برنامه‌نویسی یک نمودار به اسلاید، پر کردن آن با داده‌ها و اعمال گزینه‌های قالب‌بندی مختلف برای مطابقت با نیازهای طراحی خاص خود را بیاموزید. در طول مقاله، مثال‌های کد دقیق هر گام را نشان می‌دهند، از مقداردهی اولیه به پرزنتیشن و شیء نمودار تا پیکربندی سری‌ها، محورها و لگندها. با دنبال کردن این راهنما، درک solidی از چگونگی ادغام تولید نمودار پویا در برنامه‌های خود به دست می‌آورید و فرآیند ایجاد ارائه‌های مبتنی بر داده را ساده می‌کنید.

## **ایجاد نمودار**

نمودارها به افراد کمک می‌کنند تا به سرعت داده‌ها را بصری‌سازی کنند و بینش‌هایی به دست آورند که ممکن است از یک جدول یا صفحه‌گسترده واضح نباشد.

**چرا نمودار ایجاد کنیم؟**

با استفاده از نمودارها می‌توانید:

* مقادیر بزرگ داده را در یک اسلاید جمع‌آوری، فشرده یا خلاصه کنید
* الگوها و روندهای داده را افشا کنید
* جهت و سرعت داده‌ها را در طول زمان یا نسبت به یک واحد اندازه‌گیری خاص استنتاج کنید
* ناهنجاری‌ها، انحرافات، خطاها، داده‌های بی‌معنی و غیره را شناسایی کنید
* داده‌های پیچیده را ارتباط یا ارائه دهید

در PowerPoint می‌توانید نمودارها را از طریق عملکرد *Insert* ایجاد کنید که قالب‌های متنوعی برای طراحی انواع نمودارها فراهم می‌کند. با Aspose.Slides می‌توانید هم نمودارهای معمولی (بر پایه انواع نمودارهای محبوب) و هم نمودارهای سفارشی ایجاد کنید.

{{% alert color="info" title="Note" %}}
برای ایجاد نمودارها، از کلاس [ChartType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/) استفاده کنید. فیلدهای این کلاس به انواع مختلف نمودارها مربوط می‌شوند.
{{% /alert %}}

### **ایجاد نمودارهای ستونی خوشه‌ای**

این بخش نحوه ایجاد نمودارهای ستونی خوشه‌ای با Aspose.Slides را توضیح می‌دهد. شما یاد می‌گیرید که یک پرزنتیشن را مقداردهی اولیه کنید، یک نمودار اضافه کنید و عناصر آن مانند عنوان، داده‌ها، سری‌ها، دسته‌ها و استایل را سفارشی کنید. مراحل زیر را دنبال کنید تا نحوه تولید یک نمودار ستونی خوشه‌ای استاندارد را ببینید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
1. یک نمودار با برخی داده‌ها اضافه کنید و نوع `ChartType.ClusteredColumn` را مشخص کنید.
1. یک عنوان به نمودار اضافه کنید.
1. به کاربرگ داده‌های نمودار دسترسی پیدا کنید.
1. تمام سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
1. سری‌ها و دسته‌های جدید اضافه کنید.
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.
1. رنگ پر را به سری‌های نمودار اعمال کنید.
1. برچسب‌ها را به سری‌های نمودار اضافه کنید.
1. پرزنتیشن تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد که چگونه یک نمودار ستونی خوشه‌ای ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// یک شیٔ ارائه (Presentation) که نمایانگر فایل PPTX است ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    var sld = pres.getSlides().get_Item(0);
    // یک نمودار با داده‌های پیش‌فرض آن اضافه می‌کند
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // عنوان نمودار را تنظیم می‌کند
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    // اولین سری را برای نمایش مقادیر تنظیم می‌کند
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // شاخص کاربرگ داده‌های نمودار را تنظیم می‌کند
    var defaultWorksheetIndex = 0;
    // کاربرگ داده‌های نمودار را دریافت می‌کند
    var fact = chart.getChartData().getChartDataWorkbook();
    // سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // سری‌های جدید را اضافه می‌کند
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // دسته‌های جدید را اضافه می‌کند
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // سری اول نمودار را می‌گیرد
    var series = chart.getChartData().getSeries().get_Item(0);
    // اکنون داده‌های سری را پر می‌کند
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // رنگ پر کردن سری را تنظیم می‌کند
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // سری دوم نمودار را می‌گیرد
    series = chart.getChartData().getSeries().get_Item(1);
    // داده‌های سری را پر می‌کند
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // رنگ پر کردن سری را تنظیم می‌کند
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // برچسب‌های سفارشی برای هر دسته برای سری جدید ایجاد می‌کند
    // اولین برچسب را برای نمایش نام دسته تنظیم می‌کند
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // مقدار را برای برچسب سوم نشان می‌دهد
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // ارائه را همراه با نمودار ذخیره می‌کند
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ایجاد نمودارهای پراکنده**

نمودارهای پراکنده (که به عنوان scatter plot یا نمودار x‑y نیز شناخته می‌شوند) اغلب برای بررسی الگوها یا نشان دادن همبستگی بین دو متغیر استفاده می‌شوند.

از نمودار پراکنده زمانی استفاده کنید که:

* داده‌های عددی جفت‌دار دارید
* دو متغیر دارید که به‌خوبی با هم جفت می‌شوند
* می‌خواهید تعیین کنید آیا دو متغیر مرتبط هستند یا نه
* یک متغیر مستقل دارید که برای یک متغیر وابسته مقادیر متعددی دارد

1. مراحل موجود در [Create Clustered Column Charts](#create-clustered-column-charts) را دنبال کنید.
2. برای مرحلهٔ سوم، یک نمودار با برخی داده‌ها اضافه کنید و نوع نمودار خود را به یکی از موارد زیر تنظیم کنید:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _نمودار پراکنده را نشان می‌دهد._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _نمودار پراکنده متصل به‌وسیلهٔ منحنی‌ها با نشانگرهای داده._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _نمودار پراکنده متصل به‌وسیلهٔ منحنی‌ها بدون نشانگرهای داده._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _نمودار پراکنده متصل به‌وسیلهٔ خطوط مستقیم با نشانگرهای داده._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _نمودار پراکنده متصل به‌وسیلهٔ خطوط مستقیم بدون نشانگرهای داده._

این کد JavaScript نشان می‌دهد که چگونه یک نمودار پراکنده با نشانگرهای مختلف برای هر سری ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// یک شیٔ ارائه (Presentation) که نمایانگر فایل PPTX است ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // به اولین اسلاید دسترسی می‌یابد
    var slide = pres.getSlides().get_Item(0);
    // نمودار پیش‌فرض را ایجاد می‌کند
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // شاخص کاربرگ داده‌های پیش‌فرض نمودار را دریافت می‌کند
    var defaultWorksheetIndex = 0;
    // کاربرگ داده‌های نمودار را دریافت می‌کند
    var fact = chart.getChartData().getChartDataWorkbook();
    // سری‌های نمایشی را حذف می‌کند
    chart.getChartData().getSeries().clear();
    // سری‌های جدید را اضافه می‌کند
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // اولین سری نمودار را می‌گیرد
    var series = chart.getChartData().getSeries().get_Item(0);
    // نقطه جدید (1:3) را به سری اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // نقطه جدید (2:10) را اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // نوع سری را تغییر می‌دهد
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // نشانگر سری نمودار را تغییر می‌دهد
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // سری دوم نمودار را می‌گیرد
    series = chart.getChartData().getSeries().get_Item(1);
    // نقطه جدید (5:2) را در آن اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // نقطه جدید (3:1) را اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // نقطه جدید (2:2) را اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // نقطه جدید (5:1) را اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // نشانگر سری نمودار را تغییر می‌دهد
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ایجاد نمودارهای دایره‌ای**

نمودارهای دایره‌ای بهترین استفاده را برای نشان دادن رابطهٔ بخش‑به‑کل در داده‌ها دارند، به‌ویژه زمانی که داده‌ها شامل برچسب‌های دسته‌ای با مقادیر عددی باشند. اما اگر داده‌های شما شامل بخش‌ها یا برچسب‌های زیادی باشد، ممکن است بهتر باشد به جای آن از نمودار میله‌ای استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Pie](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#Pie) را مشخص کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. نقاط جدید برای نمودار اضافه کنید و رنگ‌های سفارشی برای بخش‌های دایره‌ای اعمال کنید.
9. برچسب‌ها را برای سری‌ها تنظیم کنید.
10. خطوط رهبر (leader lines) را برای برچسب‌های سری فعال کنید.
11. زاویهٔ چرخش برای بخش‌های دایره‌ای را تنظیم کنید.
12. پرزنتیشن تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه یک نمودار دایره‌ای ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// یک کلاس ارائه (Presentation) که نمایانگر فایل PPTX است ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // به اولین اسلاید دسترسی می‌یابد
    var slides = pres.getSlides().get_Item(0);
    // یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // عنوان نمودار را تنظیم می‌کند
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // اولین سری را برای نمایش مقادیر تنظیم می‌کند
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // شاخص کاربرگ داده‌های نمودار را تنظیم می‌کند
    var defaultWorksheetIndex = 0;
    // کاربرگ داده‌های نمودار را دریافت می‌کند
    var fact = chart.getChartData().getChartDataWorkbook();
    // سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // دسته‌های جدید را اضافه می‌کند
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // سری‌های جدید را اضافه می‌کند
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // داده‌های سری را پر می‌کند
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // در نسخهٔ جدید کار نمی‌کند
    // افزودن نقاط جدید و تنظیم رنگ بخش
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // حد خطوط بخش را تنظیم می‌کند
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    point.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // حد خطوط بخش را تنظیم می‌کند
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    point1.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // حد خطوط بخش را تنظیم می‌کند
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    point2.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));
    // برچسب‌های سفارشی برای هر دسته از سری جدید ایجاد می‌کند
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // خطوط راهنما را برای نمودار نمایش می‌دهد
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // زاویهٔ چرخش بخش‌های نمودار دایره‌ای را تنظیم می‌کند
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // ارائه را همراه با نمودار ذخیره می‌کند
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ایجاد نمودارهای خطی**

نمودارهای خطی (که به عنوان line graphs نیز شناخته می‌شوند) بهترین استفاده را در موقعیت‌هایی دارند که می‌خواهید تغییرات مقدار در طول زمان را نشان دهید. با استفاده از یک نمودار خطی می‌توانید مقدار زیادی داده را به‌طور همزمان مقایسه کنید، تغییرات و روندها را در طول زمان دنبال کنید، ناهنجاری‌ها را در سری‌های داده برجسته کنید و غیره.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Line](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#Line) را مشخص کنید.
1. به کاربرگ داده‌های نمودار ([ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/)) دسترسی پیدا کنید.
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
1. سری‌ها و دسته‌های جدید اضافه کنید.
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.
1. پرزنتیشن تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه یک نمودار خطی ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

به‌صورت پیش‌فرض، نقاط یک نمودار خطی توسط خطوط پیوسته مستقیم به یکدیگر متصل می‌شوند. اگر می‌خواهید نقاط به‌جای خطوط پیوسته توسط خط تیره متصل شوند، می‌توانید نوع dash دلخواه خود را به‌صورت زیر مشخص کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ایجاد نمودارهای درختی (Tree Map)**

نمودارهای درختی بهترین استفاده را برای داده‌های فروش دارند زمانی که می‌خواهید اندازه نسبی دسته‌های داده را نشان دهید و سریعاً به آیتم‌های بزرگ‌سهم در هر دسته توجه کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Treemap](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#Treemap) را مشخص کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. پرزنتیشن تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه یک نمودار درختی ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // شاخه 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // شاخه 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ایجاد نمودارهای سهام (Stock)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#OpenHighLowClose) را مشخص کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. قالب خطوط بالا‑پایین (high‑low lines) را مشخص کنید.
9. پرزنتیشن تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه یک نمودار سهام ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));
    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));
    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));
    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));
    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ایجاد نمودارهای جعبه‌ای و ویسکر (Box and Whisker)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#BoxAndWhisker) را مشخص کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. پرزنتیشن تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه یک نمودار جعبه‌ای و ویسکر ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ایجاد نمودارهای قیفی (Funnel)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Funnel](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#Funnel) را مشخص کنید.
4. پرزنتیشن تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه یک نمودار قیفی ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ایجاد نمودارهای خورشیدی (Sunburst)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Sunburst](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#Sunburst) را مشخص کنید.
4. پرزنتیشن تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه یک نمودار خورشیدی ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // شاخه 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // شاخه 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ایجاد نمودارهای هیستوگرام (Histogram)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Histogram](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#Histogram) را مشخص کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. پرزنتیشن تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه یک نمودار هیستوگرام ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **ایجاد نمودارهای رادار (Radar)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با برخی داده‌ها اضافه کنید و نوع دلخواه خود را (در اینجا [ChartType.Radar](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#Radar)) مشخص کنید.
4. پرزنتیشن تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه یک نمودار رادار ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ایجاد نمودارهای چنددسته‌ای (Multi-Category)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.ClusteredColumn](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#ClusteredColumn) را مشخص کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. پرزنتیشن تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه یک نمودار چنددسته‌ای ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // افزودن سری
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // ذخیره ارائه با نمودار
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ایجاد نمودارهای نقشه (Map)**

نمودارهای نقشه داده‌های جغرافیایی را به تصویر می‌کشند و به مقایسه مقادیر در مناطق مختلف کمک می‌کنند.

این کد JavaScript نشان می‌دهد که چگونه یک نمودار نقشه ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ایجاد نمودارهای ترکیبی (Combination)**

یک نمودار ترکیبی (یا combo chart) دو یا چند نوع نمودار را در یک گراف ترکیب می‌کند. این نمودار به شما امکان می‌دهد تا تفاوت‌ها یا روابط بین دو یا چند مجموعه داده را برجسته، مقایسه یا بررسی کنید.

![نمودار ترکیبی](combination_chart.png)

کد JavaScript زیر نشان می‌دهد که چگونه نمودار ترکیبی نمایش داده شده در بالا را در یک ارائه PowerPoint ایجاد کنید:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // عنوان نمودار را تنظیم می‌کند.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // لجند نمودار را تنظیم می‌کند.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // دسته‌های جدید را اضافه می‌کند.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // سری اول را اضافه می‌کند.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // محور افقی را تنظیم می‌کند.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // محور عمودی را تنظیم می‌کند.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // رنگ خطوط اصلی شبکه‌ی عمودی را تنظیم می‌کند.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // محور افقی ثانویه را تنظیم می‌کند.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // محور عمودی ثانویه را تنظیم می‌کند.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **به‌روزرسانی نمودارها**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید که نمایانگر پرزنتیشنی است که نمودار مورد نظر برای به‌روزرسانی در آن موجود است.
2. با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
3. تمام اشکال را مرور کنید تا نمودار مورد نظر را بیابید.
4. به کاربرگ داده‌های نمودار دسترسی پیدا کنید.
5. داده‌های سری نمودار را با تغییر مقدارهای سری تغییر دهید.
6. یک سری جدید اضافه کنید و داده‌های آن را پر کنید.
7. پرزنتیشن تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه یک نمودار را به‌روزرسانی کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // دسترسی به اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // دریافت نمودار با داده‌های پیش‌فرض
    var chart = sld.getShapes().get_Item(0);
    // تنظیم شاخص شیت داده‌های نمودار
    var defaultWorksheetIndex = 0;
    // دریافت کاربرگ داده‌های نمودار
    var fact = chart.getChartData().getChartDataWorkbook();
    // تغییر نام دسته‌بندی نمودار
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // دریافت اولین سری نمودار
    var series = chart.getChartData().getSeries().get_Item(0);
    // اکنون داده‌های سری را به‌روز می‌کند
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // اصلاح نام سری
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // دریافت سری دوم نمودار
    series = chart.getChartData().getSeries().get_Item(1);
    // اکنون داده‌های سری را به‌روز می‌کند
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // اصلاح نام سری
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // اکنون، افزودن یک سری جدید
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // دریافت سومین سری نمودار
    series = chart.getChartData().getSeries().get_Item(2);
    // اکنون داده‌های سری را پر می‌کند
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // ذخیره ارائه همراه با نمودار
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم محدوده داده برای یک نمودار**

برای تنظیم محدوده داده برای یک نمودار، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید که نمایانگر پرزنتیشنی است که نمودار در آن قرار دارد.
2. با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
3. تمام اشکال را مرور کنید تا نمودار مورد نظر را بیابید.
4. به داده‌های نمودار دسترسی پیدا کنید و محدوده را تنظیم کنید.
5. پرزنتیشن تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه محدوده داده برای یک نمودار تنظیم شود:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **استفاده از نشانگرهای پیش‌فرض در نمودارها**

زمانی که از نشانگرهای پیش‌فرض در نمودارها استفاده می‌کنید، هر سری نمودار به‌صورت خودکار یک نماد نشانگر متفاوت دریافت می‌کند.

این کد JavaScript نشان می‌دهد که چگونه نشانگر سری نمودار را به‌صورت خودکار تنظیم کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // دریافت سری دوم نمودار
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // اکنون داده‌های سری را پر می‌کند
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**کدام نوع نمودارها توسط Aspose.Slides پشتیبانی می‌شوند؟**

Aspose.Slides مجموعه وسیعی از [chart types](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/) را پشتیبانی می‌کند، از جمله بار، خط، دایره، ناحیه، پراکنده، هیستوگرام، رادار و بسیاری دیگر. این انعطاف‌پذیری به شما امکان می‌دهد تا مناسب‌ترین نوع نمودار را برای نیازهای بصری‌سازی داده خود انتخاب کنید.

**چگونه یک نمودار جدید به اسلاید اضافه کنم؟**

برای افزودن یک نمودار، ابتدا یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید، اسلاید مورد نظر را با استفاده از ایندکس دریافت کنید و سپس متدی را فراخوانی کنید که نمودار را اضافه می‌کند، نوع نمودار و داده‌های اولیه را مشخص کنید. این فرآیند نمودار را به‌طور مستقیم در پرزنتیشن شما ادغام می‌کند.

**چگونه می‌توان داده‌های نمایش‌داده‌شده در یک نمودار را به‌روزرسانی کرد؟**

می‌توانید داده‌های یک نمودار را با دسترسی به کاربرگ داده‌های آن ([ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/))، پاک کردن سری‌ها و دسته‌های پیش‌فرض و سپس افزودن داده‌های سفارشی خود، به‌روزرسانی کنید. این امکان به شما اجازه می‌دهد تا نمودار را به‌صورت برنامه‌نویسی تازه‌سازی کنید و آخرین داده‌ها را نشان دهید.

**آیا امکان سفارشی‌سازی ظاهر نمودار وجود دارد؟**

بله، Aspose.Slides گزینه‌های سفارشی‌سازی گسترده‌ای ارائه می‌دهد. می‌توانید رنگ‌ها، قلم‌ها، برچسب‌ها، لگندها و سایر [formatting elements](/slides/fa/nodejs-java/chart-entities/) را تغییر دهید تا ظاهر نمودار را متناسب با الزامات طراحی خاص خود تنظیم کنید.