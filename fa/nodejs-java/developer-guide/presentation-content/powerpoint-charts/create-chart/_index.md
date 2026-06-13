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
description: "ایجاد و سفارشی‌سازی نمودارها در ارائه‌های PowerPoint با Aspose.Slides برای Node.js. افزودن، قالب‌بندی و ویرایش نمودارها با مثال‌های کد عملی در JavaScript."
---
## **بررسی کلی**

این مقاله راهنمای جامعی برای نحوه ایجاد و سفارشی‌سازی نمودارها با Aspose.Slides ارائه می‌دهد. شما می‌آموزید چگونه به‌صورت برنامه‌نویسی یک نمودار را به اسلاید اضافه کنید، آن را با داده‌ها پر کنید و گزینه‌های قالب‌بندی مختلف را برای برآورده کردن نیازهای طراحی خاص خود اعمال کنید. در تمام مقاله، نمونه‌های کد دقیق هر گام را نشان می‌دهند؛ از مقداردهی اولیه ارائه و شیء نمودار تا پیکربندی س series، محور‌ها و افسانه‌ها. با دنبال کردن این راهنما، درک solidی از نحوه ادغام تولید دینامیک نمودار در برنامه‌های خود کسب می‌کنید و فرآیند ایجاد ارائه‌های مبتنی بر داده را تسهیل می‌کنید.

## **ایجاد نمودار**
نمودارها به افراد کمک می‌کنند تا به‌سرعت داده‌ها را تجسم کرده و بینش‌هایی به دست آورند که ممکن است از یک جدول یا صفحه‌کاری به‌صورت واضح نشان داده نشوند. 


**چرا نمودارها را ایجاد کنیم؟**

با استفاده از نمودارها می‌توانید:

* مقادیر بزرگ داده را در یک اسلاید جمع‌آوری، فشرده یا خلاصه کنید
* الگوها و روندهای داده را آشکار کنید
* جهت و شتاب داده را در طول زمان یا نسبت به یک واحد اندازه‌گیری خاص استنتاج کنید
* نقاط دوراز، انحرافات، خطاها، داده‌های بی‌معنی و غیره را شناسایی کنید
* داده‌های پیچیده را ارتباط یا ارائه کنید

در PowerPoint می‌توانید از طریق عملکرد Insert نمودارها را ایجاد کنید؛ این عملکرد قالب‌های متنوعی برای طراحی انواع نمودارها فراهم می‌کند. با Aspose.Slides می‌توانید نمودارهای معمولی (بر پایه انواع نمودارهای رایج) و نمودارهای سفارشی ایجاد کنید. 

{{% alert color="primary" %}} 

برای ایجاد نمودارها، Aspose.Slides کلاس [ChartType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartType) را فراهم می‌کند. فیلدهای این کلاس به انواع مختلف نمودارها مربوط می‌شوند.

{{% /alert %}} 

### **ایجاد نمودارهای معمولی**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>مراحل:</em> ایجاد نمودار PowerPoint در JavaScript</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>مراحل:</em> ایجاد نمودار ارائه در JavaScript</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>مراحل:</em> ایجاد نمودار ارائه PowerPoint در JavaScript</strong></a>

_Code Steps:_

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک نمودار با برخی داده‌ها اضافه کنید و نوع نمودار موردنظر خود را مشخص کنید. 
4. عنوانی برای نمودار اضافه کنید. 
5. به کاربرگ داده‌های نمودار دسترسی پیدا کنید.
6. تمام سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.
7. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.
8. داده‌های جدید برای سری نمودار اضافه کنید.
9. رنگ پر برای سری نمودار اضافه کنید.
10. برچسب‌ها برای سری نمودار اضافه کنید. 
11. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک نمودار معمولی ایجاد کنید:

```javascript
// یک کلاس ارائه را نمونه‌سازی می‌کند که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    var sld = pres.getSlides().get_Item(0);
    // نمودار را با داده‌های پیش‌فرضش اضافه می‌کند
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // عنوان نمودار را تنظیم می‌کند
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // اولین سری را برای نشان دادن مقدارها تنظیم می‌کند
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // ایندکس شیت داده‌های نمودار را تنظیم می‌کند
    var defaultWorksheetIndex = 0;
    // شیت کاری داده‌های نمودار را دریافت می‌کند
    var fact = chart.getChartData().getChartDataWorkbook();
    // سری‌ها و دسته‌بندی‌های پیش‌فرض تولید شده را حذف می‌کند
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // سری‌های جدید اضافه می‌کند
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // دسته‌بندی‌های جدید اضافه می‌کند
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // اولین سری نمودار را می‌گیرد
    var series = chart.getChartData().getSeries().get_Item(0);
    // حالا داده‌های سری را پر می‌کند
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // رنگ پر برای سری را تنظیم می‌کند
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // دومین سری نمودار را می‌گیرد
    series = chart.getChartData().getSeries().get_Item(1);
    // داده‌های سری را پر می‌کند
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // رنگ پر برای این سری را تنظیم می‌کند
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // برچسب‌های سفارشی برای هر دسته برای سری جدید ایجاد می‌کند
    // اولین برچسب را برای نمایش نام دسته تنظیم می‌کند
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // مقدار را برای برچسب سوم نمایش می‌دهد
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
نمودارهای پراکنده (که به‌عنوان scatter plots یا نمودارهای x‑y نیز شناخته می‌شوند) اغلب برای بررسی الگوها یا نشان دادن همبستگی بین دو متغیر استفاده می‌شوند. 

ممکن است زمانی که:

* داده‌های عددی جفت‌سازی شده دارید
* دو متغیر که به‌خوبی با هم جفت می‌شوند
* بخواهید تعیین کنید آیا دو متغیر مرتبط هستند یا خیر
* متغیر مستقلی دارید که برای یک متغیر وابسته مقادیر متعددی دارد

از یک نمودار پراکنده استفاده کنید.

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>مراحل:</em> ایجاد نمودار پراکنده در JavaScript</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>مراحل:</em> ایجاد نمودار پراکنده PowerPoint در JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>مراحل:</em> ایجاد نمودار پراکنده ارائه PowerPoint در JavaScript</strong></a>

1. لطفاً مراحل ذکر شده در [ایجاد نمودارهای معمولی](#creating-normal-charts) را دنبال کنید
2. برای گام سوم، یک نمودار با برخی داده‌ها اضافه کنید و نوع نمودار خود را به‌عنوان یکی از موارد زیر تعیین کنید
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _نمودار پراکنده با نشانگرها._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _نمودار پراکنده متصل به‌وسیله منحنی‌ها با نشانگرهای داده._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _نمودار پراکنده متصل به‌وسیله منحنی‌ها بدون نشانگرهای داده._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _نمودار پراکنده متصل به‌وسیله خطوط مستقیم با نشانگرهای داده._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _نمودار پراکنده متصل به‌وسیله خطوط مستقیم بدون نشانگرهای داده._

این کد JavaScript نشان می‌دهد چگونه نمودارهای پراکنده با سری‌های مختلف نشانگرها ایجاد کنید:

```javascript
// یک کلاس ارائه را نمونه‌سازی می‌کند که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    var slide = pres.getSlides().get_Item(0);
    // نمودار پیش‌فرض را ایجاد می‌کند
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // ایندکس کاربرگ داده‌های پیش‌فرض نمودار را دریافت می‌کند
    var defaultWorksheetIndex = 0;
    // کاربرگ داده‌های نمودار را دریافت می‌کند
    var fact = chart.getChartData().getChartDataWorkbook();
    // سری دمویی را حذف می‌کند
    chart.getChartData().getSeries().clear();
    // سری‌های جدید را اضافه می‌کند
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // اولین سری نمودار را می‌گیرد
    var series = chart.getChartData().getSeries().get_Item(0);
    // یک نقطه جدید (1:3) به سری اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // یک نقطه جدید (2:10) اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // نوع سری را تغییر می‌دهد
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // نشانگر سری نمودار را تغییر می‌دهد
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // دومین سری نمودار را می‌گیرد
    series = chart.getChartData().getSeries().get_Item(1);
    // یک نقطه جدید (5:2) در آن اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // یک نقطه جدید (3:1) اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // یک نقطه جدید (2:2) اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // یک نقطه جدید (5:1) اضافه می‌کند
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

نمودارهای دایره‌ای برای نمایش رابطهٔ بخش‑به‑کل در داده‌ها مناسب هستند، به‌ویژه وقتی داده‌ها شامل برچسب‌های دسته‌ای با مقادیر عددی باشند. اما اگر داده‌های شما شامل بخش‌ها یا برچسب‌های زیادی باشد، ممکن است بهتر باشد از نمودار ستونی استفاده کنید.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>مراحل:</em> ایجاد نمودار دایره‌ای در JavaScript</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>مراحل:</em> ایجاد نمودار دایره‌ای PowerPoint در JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>مراحل:</em> ایجاد نمودار دایره‌ای ارائه PowerPoint در JavaScript</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع اسلاید را با ایندکس آن به دست آورید.
3. یک نمودار با داده‌های پیش‌فرض همراه با نوع موردنظر (در این مثال، [ChartType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartType).Pie) اضافه کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataWorkbook) دسترسی پیدا کنید.
5. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.
7. داده‌های جدید برای سری نمودار اضافه کنید.
8. نقاط جدید برای نمودارها اضافه کنید و رنگ‌های سفارشی برای بخش‌های نمودار دایره‌ای تعیین کنید.
9. برچسب‌ها برای سری‌ها تنظیم کنید.
10. خطوط رهنما برای برچسب‌های سری تنظیم کنید.
11. زاویهٔ چرخش اسلایدهای نمودار دایره‌ای را تنظیم کنید.
12. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک نمودار دایره‌ای ایجاد کنید:

```javascript
// یک کلاس ارائه را نمونه‌سازی می‌کند که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    var slides = pres.getSlides().get_Item(0);
    // نمودار را با داده‌های پیش‌فرض اضافه می‌کند
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // عنوان نمودار را تنظیم می‌کند
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // اولین سری را برای نمایش مقدارها تنظیم می‌کند
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // ایندکس شیت داده‌های نمودار را تنظیم می‌کند
    var defaultWorksheetIndex = 0;
    // شیت کاری داده‌های نمودار را دریافت می‌کند
    var fact = chart.getChartData().getChartDataWorkbook();
    // سری‌ها و دسته‌بندی‌های پیش‌فرض تولید شده را حذف می‌کند
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // دسته‌بندی‌های جدید اضافه می‌کند
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // سری‌های جدید اضافه می‌کند
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // داده‌های سری را پر می‌کند
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // در نسخه جدید کار نمی‌کند
    // اضافه‌کردن نقاط جدید و تنظیم رنگ بخش
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // حاشیهٔ بخش را تنظیم می‌کند
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // حاشیهٔ بخش را تنظیم می‌کند
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // حاشیهٔ بخش را تنظیم می‌کند
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // برچسب‌های سفارشی برای هر دسته برای سری جدید ایجاد می‌کند
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

نمودارهای خطی (که به‌عنوان گرافیک‌های خطی نیز شناخته می‌شوند) برای موقعیت‌هایی مناسب هستند که می‌خواهید تغییرات مقدار را در طول زمان نشان دهید. با استفاده از نمودار خطی می‌توانید داده‌های زیادی را به‌طور همزمان مقایسه کنید، تغییرات و روندها را در طول زمان پیگیری کنید، ناهنجاری‌ها را در سری‌های داده برجسته کنید و غیره.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
1. مرجع یک اسلاید را از طریق ایندکس آن به‌دست آورید.
1. یک نمودار با داده‌های پیش‌فرض همراه با نوع موردنظر (در این مثال، `ChartType.Line`) اضافه کنید.
1. به داده‌های نمودار IChartDataWorkbook دسترسی پیدا کنید.
1. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.
1. داده‌های جدید برای سری نمودار اضافه کنید.
1. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک نمودار خطی ایجاد کنید:

```javascript
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

به‌صورت پیش‌فرض، نقاط یک نمودار خطی با خطوط پیوستهٔ مستقیم به‌هم متصل می‌شوند. اگر می‌خواهید به‌جای آن نقاط با خط‌های نقطه‌دار به‌هم متصل شوند، می‌توانید نوع خط نقطه‌دار دلخواه خود را به‌این شکل مشخص کنید:

```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```

### **ایجاد نمودارهای درختی (Tree Map)**

نمودارهای درختی برای داده‌های فروش مناسب هستند زمانی که می‌خواهید اندازه نسبی دسته‌های داده را نشان دهید و همزمان به‌سرعت توجه را به آیتم‌های بزرگ‌سهم هر دسته جلب کنید. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>مراحل:</em> ایجاد نمودار Tree Map در JavaScript</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>مراحل:</em> ایجاد نمودار Tree Map PowerPoint در JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>مراحل:</em> ایجاد نمودار Tree Map ارائه PowerPoint در JavaScript</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک نمودار با داده‌های پیش‌فرض همراه با نوع موردنظر (در این مثال، [ChartType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartType).TreeMap) اضافه کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataWorkbook) دسترسی پیدا کنید.
5. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.
7. داده‌های جدید برای سری نمودار اضافه کنید.
8. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک نمودار Tree Map ایجاد کنید:

```javascript
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

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>مراحل:</em> ایجاد نمودار سهام در JavaScript</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>مراحل:</em> ایجاد نمودار سهام PowerPoint در JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>مراحل:</em> ایجاد نمودار سهام ارائه PowerPoint در JavaScript</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع اسلاید را با ایندکس آن به‌دست آورید.
3. یک نمودار با داده‌های پیش‌فرض همراه با نوع موردنظر ([ChartType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartType).OpenHighLowClose) اضافه کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataWorkbook) دسترسی پیدا کنید.
5. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.
7. داده‌های جدید برای سری نمودار اضافه کنید.
8. قالب HiLowLines را تعیین کنید.
9. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

نمونه کد JavaScript برای ایجاد نمودار سهام:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
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

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>مراحل:</em> ایجاد نمودار Box and Whisker در JavaScript</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>مراحل:</em> ایجاد نمودار Box and Whisker PowerPoint در JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>مراحل:</em> ایجاد نمودار Box and Whisker ارائه PowerPoint در JavaScript</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک نمودار با داده‌های پیش‌فرض همراه با نوع موردنظر ([ChartType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartType).BoxAndWhisker) اضافه کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataWorkbook) دسترسی پیدا کنید.
5. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.
7. داده‌های جدید برای سری نمودار اضافه کنید.
8. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک نمودار Box and Whisker ایجاد کنید:

```javascript
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

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>مراحل:</em> ایجاد نمودار Funnel در JavaScript</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>مراحل:</em> ایجاد نمودار Funnel PowerPoint در JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>مراحل:</em> ایجاد نمودار Funnel ارائه PowerPoint در JavaScript</strong></a>


1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع اسلاید را از طریق ایندکس آن به‌دست آورید.
3. یک نمودار با داده‌های پیش‌فرض همراه با نوع موردنظر ([ChartType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartType).Funnel) اضافه کنید.
4. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

کد JavaScript نشان می‌دهد چگونه یک نمودار Funnel ایجاد کنید:

```javascript
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

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>مراحل:</em> ایجاد نمودار Sunburst در JavaScript</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>مراحل:</em> ایجاد نمودار Sunburst PowerPoint در JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>مراحل:</em> ایجاد نمودار Sunburst ارائه PowerPoint در JavaScript</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک نمودار با داده‌های پیش‌فرض همراه با نوع موردنظر (در این مثال، [ChartType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartType).sunburst) اضافه کنید.
4. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک نمودار Sunburst ایجاد کنید:

```javascript
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

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>مراحل:</em> ایجاد نمودار Histogram در JavaScript</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>مراحل:</em> ایجاد نمودار Histogram PowerPoint در JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>مراحل:</em> ایجاد نمودار Histogram ارائه PowerPoint در JavaScript</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع اسلاید را از طریق ایندکس آن به‌دست آورید.
3. یک نمودار با داده‌های پیش‌فرض همراه با نوع موردنظر ([ChartType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartType).Histogram) اضافه کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataWorkbook) دسترسی پیدا کنید.
5. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.
7. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک نمودار هیستوگرام ایجاد کنید:

```javascript
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

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>مراحل:</em> ایجاد نمودار Radar در JavaScript</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>مراحل:</em> ایجاد نمودار Radar PowerPoint در JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>مراحل:</em> ایجاد نمودار Radar ارائه PowerPoint در JavaScript</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید. 
3. یک نمودار با برخی داده‌ها اضافه کنید و نوع نمودار دلخواه خود را (`ChartType.Radar` در این مورد) مشخص کنید.
4. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک نمودار Radar ایجاد کنید:

```javascript
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

### **ایجاد نمودارهای چنددسته‌ای (Multi Category)**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>مراحل:</em> ایجاد نمودار Multi Category در JavaScript</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>مراحل:</em> ایجاد نمودار Multi Category PowerPoint در JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>مراحل:</em> ایجاد نمودار Multi Category ارائه PowerPoint در JavaScript</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید. 
3. یک نمودار با داده‌های پیش‌فرض همراه با نوع موردنظر ([ChartType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartType).ClusteredColumn) اضافه کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataWorkbook) دسترسی پیدا کنید.
5. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.
7. داده‌های جدید برای سری نمودار اضافه کنید.
8. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک نمودار Multi Category ایجاد کنید:

```javascript
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
    // افزودن سری‌ها
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

نمودار نقشه، تصویری از یک منطقه حاوی داده‌هاست. نمودارهای نقشه برای مقایسه داده‌ها یا مقادیر در مناطق جغرافیایی مختلف مناسب هستند.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>مراحل:</em> ایجاد نمودار Map در JavaScript</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>مراحل:</em> ایجاد نمودار Map PowerPoint در JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>مراحل:</em> ایجاد نمودار Map ارائه PowerPoint در JavaScript</strong></a>

این کد JavaScript نشان می‌دهد چگونه یک نمودار Map ایجاد کنید:

```javascript
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

یک نمودار ترکیبی (یا combo chart) دو یا چند نوع نمودار را در یک گراف ترکیب می‌کند. این نمودار به شما امکان می‌دهد تا تفاوت‌ها یا شباهت‌های بین دو یا چند مجموعه داده را برجسته، مقایسه یا بررسی کنید و به‌این‌وسایل روابط بین آن‌ها را شناسایی نمایید.

![The combination chart](combination_chart.png)

کد JavaScript زیر نشان می‌دهد چگونه نمودار ترکیبی نمایش داده‌شده در بالا را در یک ارائه PowerPoint ایجاد کنید:

```js
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

    // افسانه نمودار را تنظیم می‌کند.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // سری‌ها و دسته‌بندی‌های پیش‌فرض تولید شده را حذف می‌کند.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // دسته‌بندی‌های جدید را اضافه می‌کند.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // اولین سری را اضافه می‌کند.
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

    // رنگ خطوط اصلی شبکه عمودی را تنظیم می‌کند.
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>مراحل:</em> به‌روزرسانی نمودار PowerPoint در JavaScript</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>مراحل:</em> به‌روزرسانی نمودار ارائه در JavaScript</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>مراحل:</em> به‌روزرسانی نمودار ارائه PowerPoint در JavaScript</strong></a>

1. یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) که نشان‌دهنده ارائه حاوی نموداری است که می‌خواهید به‌روزرسانی کنید، ایجاد کنید.
2. مرجع اسلاید را با استفاده از ایندکس آن به‌دست آورید.
3. تمام اشکال را مرور کنید تا نمودار موردنظر را پیدا کنید.
4. به کاربرگ داده‌های نمودار دسترسی پیدا کنید.
5. داده‌های سری نمودار را با تغییر مقادیر سری‌ها اصلاح کنید.
6. یک سری جدید اضافه کنید و داده‌های آن را پر کنید.
7. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک نمودار را به‌روزرسانی کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // دریافت نمودار با داده‌های پیش‌فرض
    var chart = sld.getShapes().get_Item(0);
    // تنظیم ایندکس شیت داده‌های نمودار
    var defaultWorksheetIndex = 0;
    // دریافت شیت کاری داده‌های نمودار
    var fact = chart.getChartData().getChartDataWorkbook();
    // تغییر نام دسته‌بندی نمودار
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // گرفتن اولین سری نمودار
    var series = chart.getChartData().getSeries().get_Item(0);
    // اکنون در حال به‌روزرسانی داده‌های سری
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// تغییر نام سری
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // گرفتن سری دوم نمودار
    series = chart.getChartData().getSeries().get_Item(1);
    // اکنون در حال به‌روزرسانی داده‌های سری
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// تغییر نام سری
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // اکنون، افزودن یک سری جدید
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // گرفتن سومین سری نمودار
    series = chart.getChartData().getSeries().get_Item(2);
    // اکنون در حال پر کردن داده‌های سری
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

## **تنظیم بازهٔ داده برای نمودارها**

برای تنظیم بازهٔ داده برای یک نمودار، این مراحل را انجام دهید:

1. یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) که نشان‌دهنده ارائه حاوی نمودار است، ایجاد کنید.
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.
3. تمام اشکال را مرور کنید تا نمودار موردنظر را پیدا کنید.
4. به داده‌های نمودار دسترسی پیدا کنید و بازه را تنظیم کنید.
5. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه بازهٔ داده برای یک نمودار تنظیم شود:

```javascript
var pres = new aspose.slides.Presentation();
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
وقتی از یک نشانگر پیش‌فرض در نمودارها استفاده می‌کنید، هر سری نمودار به‌صورت خودکار نماد نشانگر پیش‌فرض متفاوتی دریافت می‌کند.

این کد JavaScript نشان می‌دهد چگونه یک نشانگر سری نمودار به‌صورت خودکار تنظیم شود:

```javascript
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
    // گرفتن سری دوم نمودار
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // اکنون در حال پر کردن داده‌های سری
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

## **پرسش‌های متداول**

**کدام انواع نمودارها توسط Aspose.Slides پشتیبانی می‌شوند؟**

Aspose.Slides انواع گسترده‌ای از نمودارها، از جمله ستونی، خطی، دایره‌ای، مساحتی، پراکنده، هیستوگرام، رادار و بسیاری دیگر را پشتیبانی می‌کند. این انعطاف‌پذیری به شما امکان می‌دهد مناسب‌ترین نوع نمودار را برای نیازهای تجسم داده خود انتخاب کنید.

**چگونه می‌توان یک نمودار جدید به اسلاید اضافه کرد؟**

برای اضافه کردن نمودار، ابتدا یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد می‌کنید، اسلاید موردنظر را با استفاده از ایندکس آن بازیابی می‌کنید و سپس متد افزودن نمودار را صدا می‌زنید؛ در این مرحله نوع نمودار و داده‌های اولیه را مشخص می‌کنید. این فرآیند نمودار را مستقیماً در ارائه شما ادغام می‌کند.

**چگونه می‌توان داده‌های نمایش داده‌شده در یک نمودار را به‌روزرسانی کرد؟**

می‌توانید داده‌های یک نمودار را با دسترسی به کاربرگ داده‌های آن ([ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/))، پاک کردن سری‌ها و دسته‌بندی‌های پیش‌فرض و سپس افزودن داده‌های سفارشی خود، به‌روزرسانی کنید. این امکان به‌روزرسانی برنامه‌نویسی شدهٔ نمودار برای بازتاب جدیدترین داده‌ها را فراهم می‌کند.

**آیا می‌توان ظاهر نمودار را سفارشی کرد؟**

بله، Aspose.Slides گزینه‌های سفارشی‌سازی گسترده‌ای ارائه می‌دهد. می‌توانید رنگ‌ها، قلم‌ها، برچسب‌ها، افسانه‌ها و سایر عناصر قالب‌بندی را برای تطبیق ظاهر نمودار با الزامات طراحی خاص خود تغییر دهید.