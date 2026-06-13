---
title: ایجاد یا به‌روزرسانی نمودارهای ارائه PowerPoint در Android
linktitle: ایجاد یا به‌روزرسانی نمودارها
type: docs
weight: 10
url: /fa/androidjava/create-chart/
keywords:
- اضافه کردن نمودار
- ایجاد نمودار
- ویرایش نمودار
- تغییر نمودار
- به‌روزرسانی نمودار
- نمودار پراکنده
- نمودار دایره‌ای
- نمودار خطی
- نمودار درخت‌نقشه
- نمودار سهام
- نمودار جعبه و ویسکر
- نمودار قیفی
- نمودار خورده‌نقش
- نمودار هیستوگرام
- نمودار رادار
- نمودار چنددسته‌ای
- PowerPoint
- ارائه
- اندروید
- Java
- Aspose.Slides
description: "نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Android ایجاد و سفارشی‌سازی کنید. نمودارها را با مثال‌های کاربردی کد Java اضافه، قالب‌بندی و ویرایش کنید."
---
## **بررسی کلی**

این مقاله راهنمای جامع ایجاد و سفارشی‌سازی نمودارها با Aspose.Slides را ارائه می‌دهد. شما یاد خواهید گرفت چگونه به‌صورت برنامه‌ای یک نمودار را به اسلاید اضافه کنید، داده‌ها را پر کنید و گزینه‌های قالب‌بندی مختلف را برای برآورده‌سازی نیازهای طراحی خود اعمال کنید. در طول مقاله، مثال‌های کد دقیق هر گام را نشان می‌دهند، از مقداردهی اولیه ارائه و شی نمودار تا پیکربندی سری‌ها، محور‌ها و افسانه‌ها. با دنبال کردن این راهنما، درک جامعی از یکپارچه‌سازی تولید دینامیک نمودار در برنامه‌های خود به دست می‌آورید و فرآیند ساخت ارائه‌های مبتنی بر داده را ساده می‌کنید.

## **ایجاد نمودار**
نمودارها به افراد کمک می‌کنند تا به‌سرعت داده‌ها را بصری‌سازی کنند و بینش‌هایی بدست آورند که ممکن است از یک جدول یا صفحه‌گسترده به‌صورت واضح دیده نشوند.

**چرا نمودار ایجاد کنیم؟**

با استفاده از نمودارها می‌توانید:

* حجم زیادی از داده‌ها را در یک اسلاید جمع‌آوری، فشرده یا خلاصه کنید
* الگوها و روندهای داده را نشان دهید
* جهت و شدت داده‌ها را در طول زمان یا نسبت به واحد اندازه‌گیری خاصی استنتاج کنید
* داده‌های نامنظم، انحرافات، خطاها، داده‌های بی‌معنی و غیره را شناسایی کنید
* داده‌های پیچیده را ارتباط یا ارائه کنید

در PowerPoint می‌توانید نمودارها را از طریق عملکرد Insert ایجاد کنید که الگوهایی برای طراحی انواع مختلف نمودارها فراهم می‌آورد. با Aspose.Slides می‌توانید نمودارهای معمولی (بر پایه انواع نمودارهای محبوب) و نمودارهای سفارشی ایجاد کنید.

{{% alert color="primary" %}} 
برای ایجاد نمودارها، Aspose.Slides کلاس [ChartType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ChartType) را فراهم می‌کند. فیلدهای این کلاس مطابق با انواع مختلف نمودار هستند.
{{% /alert %}} 

### **ایجاد نمودارهای معمولی**

_مراحل: ایجاد نمودار_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>مراحل:</em> ایجاد نمودار PowerPoint در Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>مراحل:</em> ایجاد نمودار ارائه در Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>مراحل:</em> ایجاد نمودار ارائه PowerPoint در Java</strong></a>

_مراحل کد:_

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک نمودار با برخی داده‌ها اضافه کنید و نوع نمودار مورد نظر خود را مشخص کنید. 
4. یک عنوان برای نمودار اضافه کنید. 
5. به ورق‌کار داده‌های نمودار دسترسی پیدا کنید.
6. تمام سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
7. سری‌ها و دسته‌های جدید اضافه کنید.
8. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.
9. رنگ پر کردن برای سری‌های نمودار اضافه کنید.
10. برچسب‌هایی برای سری‌های نمودار اضافه کنید. 
11. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه یک نمودار معمولی ایجاد کنید:

```java
// یک شی از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // به اسلاید اول دسترسی پیدا می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // عنوان نمودار را تنظیم می‌کند
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // سری اول را تنظیم می‌کند تا مقادیر را نمایش دهد
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // شاخص برگه داده‌های نمودار را تنظیم می‌کند
    int defaultWorksheetIndex = 0;
    
    // برگه کاری داده‌های نمودار را دریافت می‌کند
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // سری‌های جدید اضافه می‌کند
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // دسته‌های جدید اضافه می‌کند
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // سری اول نمودار را می‌گیرد
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // اکنون داده‌های سری را پر می‌کند
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // رنگ پر کردن سری را تنظیم می‌کند
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // سری دوم نمودار را می‌گیرد
    series = chart.getChartData().getSeries().get_Item(1);
    
    // داده‌های سری را پر می‌کند
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // رنگ پر کردن سری را تنظیم می‌کند
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Create برچسب‌های سفارشی برای هر دسته برای سری جدید
    // تنظیم برچسب اول برای نمایش نام دسته
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // مقدار را برای برچسب سوم نمایش می‌دهد
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // ارائه را با نمودار ذخیره می‌کند
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای پراکنده**
نمودارهای پراکنده (که به‌عنوان نمودارهای Scatter یا گراف‌های x‑y نیز شناخته می‌شوند) معمولاً برای بررسی الگوها یا نشان دادن همبستگی بین دو متغیر استفاده می‌شوند.

ممکن است بخواهید از نمودار پراکنده استفاده کنید وقتی:

* داده‌های عددی جفت‌شده دارید
* دو متغیر دارید که به‌خوبی با هم جفت می‌شوند
* می‌خواهید تعیین کنید آیا دو متغیر مرتبط هستند یا نه
* متغیر مستقلی دارید که برای متغیر وابسته مقادیر متعددی دارد

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>مراحل:</em> ایجاد نمودار پراکنده در Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>مراحل:</em> ایجاد نمودار پراکنده PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>مراحل:</em> ایجاد نمودار پراکنده ارائه PowerPoint در Java</strong></a>

1. لطفاً مراحل مذکور در [ایجاد نمودارهای معمولی](#creating-normal-charts) را دنبال کنید
2. برای گام سوم، یک نمودار با برخی داده‌ها اضافه کنید و نوع نمودار را به‌عنوان یکی از موارد زیر انتخاب کنید
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _نمودار Scatter با نشانگرها._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _نمودار Scatter با خطوط صاف و نشانگرها._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _نمودار Scatter با خطوط صاف بدون نشانگرها._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _نمودار Scatter با خطوط مستقیم و نشانگرها._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _نمودار Scatter با خطوط مستقیم بدون نشانگرها._

این کد Java نشان می‌دهد چگونه یک نمودار پراکنده با سری‌های مختلف نشانگر ایجاد کنید:

```java
// یک شی از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // به اسلاید اول دسترسی می‌یابد
    ISlide slide = pres.getSlides().get_Item(0);

    // نمودار پیش‌فرض را ایجاد می‌کند
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // شاخص برگه کاری داده‌های پیش‌فرض نمودار را دریافت می‌کند
    int defaultWorksheetIndex = 0;
    
    // برگه کاری داده‌های نمودار را دریافت می‌کند
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // سری‌های نمایشی را حذف می‌کند
    chart.getChartData().getSeries().clear();
    
    // سری‌های جدید اضافه می‌کند
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // سری اول نمودار را می‌گیرد
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // یک نقطه جدید (1:3) به سری اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // یک نقطه جدید (2:10) اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // نوع سری را تغییر می‌دهد
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // نماد سری نمودار را تغییر می‌دهد
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // سری دوم نمودار را می‌گیرد
    series = chart.getChartData().getSeries().get_Item(1);
    
    // یک نقطه جدید (5:2) در آن اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // یک نقطه جدید (3:1) اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // یک نقطه جدید (2:2) اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // یک نقطه جدید (5:1) اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // نماد سری نمودار را تغییر می‌دهد
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای دایره‌ای**

نمودارهای دایره‌ای بهترین استفاده را برای نشان دادن نسبت بخشی‑به‑کل داده‌ها دارند، به‌ویژه زمانی که داده‌ها شامل برچسب‌های دسته‌ای با مقادیر عددی باشند. با این حال، اگر داده‌های شما شامل تعداد زیادی بخش یا برچسب باشد، ممکن است بخواهید به‌جای آن از نمودار میله‌ای استفاده کنید.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>مراحل:</em> ایجاد نمودار دایره‌ای در Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>مراحل:</em> ایجاد نمودار دایره‌ای PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>مراحل:</em> ایجاد نمودار دایره‌ای ارائه PowerPoint در Java</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک نمودار با داده‌های پیش‌فرض به‌همراه نوع موردنظر (در این مثال، [ChartType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ChartType).Pie) اضافه کنید.
4. به داده‌های نمودار از طریق [IChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataWorkbook) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.
8. نقاط جدید برای نمودارها اضافه کنید و رنگ‌های سفارشی برای بخش‌های نمودار دایره‌ای تعیین کنید.
9. برچسب‌ها را برای سری‌ها تنظیم کنید.
10. خطوط راهنما برای برچسب‌های سری تنظیم کنید.
11. زاویه چرخش برای اسلایدهای نمودار دایره‌ای تنظیم کنید.
12. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه یک نمودار دایره‌ای ایجاد کنید:

```java
// یک شی از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // به اسلاید اول دسترسی می‌یابد
    ISlide slides = pres.getSlides().get_Item(0);
    
    // یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // عنوان نمودار را تنظیم می‌کند
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // سری اول را تنظیم می‌کند تا مقادیر را نمایش دهد
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // شاخص برگه کاری داده‌های نمودار را تنظیم می‌کند
    int defaultWorksheetIndex = 0;
    
    // برگه کاری داده‌های نمودار را دریافت می‌کند
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // دسته‌های جدید اضافه می‌کند
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // سری‌های جدید اضافه می‌کند
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //داده‌های سری را پر می‌کند
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // در نسخه جدید کار نمی‌کند
    // افزودن نقاط جدید و تنظیم رنگ بخش
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // حاشیه بخش را تنظیم می‌کند
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // حاشیه بخش را تنظیم می‌کند
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // حاشیه بخش را تنظیم می‌کند
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // برچسب‌های سفارشی برای هر دسته از سری جدید ایجاد می‌کند
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // خطوط راهنما را برای نمودار نمایش می‌دهد
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // زاویه چرخش بخش‌های نمودار دایره‌ای را تنظیم می‌کند
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // ارائه را همراه با نمودار ذخیره می‌کند
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای خطی**

نمودارهای خطی (که به‌عنوان گراف‌های خطی نیز شناخته می‌شوند) بهترین استفاده را در موقعیت‌هایی دارند که می‌خواهید تغییرات مقدار را در طول زمان نشان دهید. با استفاده از نمودار خطی می‌توانید داده‌های زیادی را همزمان مقایسه کنید، تغییرات و روندها را در طول زمان پیگیری کنید، ناهنجاری‌ها را در سری‌های داده برجسته کنید و غیره.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
1. یک نمودار با داده‌های پیش‌فرض به‌همراه نوع موردنظر (در این مثال، `ChartType.Line`) اضافه کنید.
1. به داده‌های نمودار از طریق IChartDataWorkbook دسترسی پیدا کنید.
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
1. سری‌ها و دسته‌های جدید اضافه کنید.
1. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.
1. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه یک نمودار خطی ایجاد کنید:

```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

به‌صورت پیش‌فرض، نقاط یک نمودار خطی با خطوط مستقیم پیوسته به‌هم متصل می‌شوند. اگر می‌خواهید نقاط به‌جای خطوط پیوسته با خط تیره متصل شوند، می‌توانید نوع خط تیره موردنظر خود را به‌این شکل مشخص کنید:

```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```

### **ایجاد نمودارهای درخت‌نقشه**

نمودارهای درخت‌نقشه بهترین استفاده را برای داده‌های فروش دارند وقتی می‌خواهید اندازه نسبی دسته‌های داده را نشان دهید و همزمان به‌سرعت توجه را به آیتم‌های بزرگ‌سهم هر دسته جلب کنید.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>مراحل:</em> ایجاد نمودار درخت‌نقشه در Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>مراحل:</em> ایجاد نمودار درخت‌نقشه PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>مراحل:</em> ایجاد نمودار درخت‌نقشه ارائه PowerPoint در Java</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسלاید را از طریق ایندکس آن دریافت کنید.
3. یک نمودار با داده‌های پیش‌فرض به‌همراه نوع موردنظر (در این مثال، [ChartType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ChartType).TreeMap) اضافه کنید.
4. به داده‌های نمودار از طریق [IChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataWorkbook) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.
8. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه یک نمودار درخت‌نقشه ایجاد کنید:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    // شاخه 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
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

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای سهام**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>مراحل:</em> ایجاد نمودار سهام در Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>مراحل:</em> ایجاد نمودار سهام PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>مراحل:</em> ایجاد نمودار سهام ارائه PowerPoint در Java</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک نمودار با داده‌های پیش‌فرض به‌همراه نوع موردنظر ([ChartType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ChartType).OpenHighLowClose) اضافه کنید.
4. به داده‌های نمودار از طریق [IChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataWorkbook) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.
8. قالب خطوط HiLowLines را تعیین کنید.
9. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

نمونه کد Java برای ایجاد نمودار سهام:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای جعبه‌وویسکر**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>مراحل:</em> ایجاد نمودار جعبه‌وویسکر در Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>مراحل:</em> ایجاد نمودار جعبه‌وویسکر PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>مراحل:</em> ایجاد نمودار جعبه‌وویسکر ارائه PowerPoint در Java</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسלاید را از طریق ایندکس آن دریافت کنید.
3. یک نمودار با داده‌های پیش‌فرض به‌همراه نوع موردنظر ([ChartType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ChartType).BoxAndWhisker) اضافه کنید.
4. به داده‌های نمودار از طریق [IChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataWorkbook) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.
8. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه یک نمودار جعبه‌وویسکر ایجاد کنید:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
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

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای قیفی**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>مراحل:</em> ایجاد نمودار قیفی در Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>مراحل:</em> ایجاد نمودار قیفی PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>مراحل:</em> ایجاد نمودار قیفی ارائه PowerPoint در Java</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسלاید را از طریق ایندکس آن دریافت کنید.
3. یک نمودار با داده‌های پیش‌فرض به‌همراه نوع موردنظر ([ChartType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ChartType).Funnel) اضافه کنید.
4. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

کد Java نشان می‌دهد چگونه یک نمودار قیفی ایجاد کنید:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای خورده‌نقش (Sunburst)**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>مراحل:</em> ایجاد نمودار خورده‌نقش در Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>مراحل:</em> ایجاد نمودار خورده‌نقش PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>مراحل:</em> ایجاد نمودار خورده‌نقش ارائه PowerPoint در Java</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسלاید را از طریق ایندکس آن دریافت کنید.
3. یک نمودار با داده‌های پیش‌فرض به‌همراه نوع موردنظر (در این مثال، [ChartType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ChartType).sunburst) اضافه کنید.
4. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه یک نمودار خورده‌نقش ایجاد کنید:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    // شاخه 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
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

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای هیستوگرام**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>مراحل:</em> ایجاد نمودار هیستوگرام در Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>مراحل:</em> ایجاد نمودار هیستوگرام PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>مراحل:</em> ایجاد نمودار هیستوگرام ارائه PowerPoint در Java</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسלاید را از طریق ایندکس آن دریافت کنید.
3. یک نمودار با داده‌های پیش‌فرض به‌همراه نوع موردنظر ([ChartType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ChartType).Histogram) اضافه کنید.
4. به داده‌های نمودار از طریق [IChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataWorkbook) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه یک نمودار هیستوگرام ایجاد کنید:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic;)

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای رادار**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>مراحل:</em> ایجاد نمودار رادار در Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>مراحل:</em> ایجاد نمودار رادار PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>مراحل:</em> ایجاد نمودار رادار ارائه PowerPoint در Java</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسלاید را از طریق ایندکس آن دریافت کنید. 
3. یک نمودار با برخی داده‌ها اضافه کنید و نوع نمودار مورد علاقه خود را (`ChartType.Radar` در این مثال) مشخص کنید.
4. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه یک نمودار رادار ایجاد کنید:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای چنددسته‌ای**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>مراحل:</em> ایجاد نمودار چنددسته‌ای در Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>مراحل:</em> ایجاد نمودار چنددسته‌ای PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>مراحل:</em> ایجاد نمودار چنددسته‌ای ارائه PowerPoint در Java</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسלاید را از طریق ایندکس آن دریافت کنید. 
3. یک نمودار با داده‌های پیش‌فرض به‌همراه نوع موردنظر ([ChartType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ChartType).ClusteredColumn) اضافه کنید.
4. به داده‌های نمودار از طریق [IChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataWorkbook) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.
8. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه یک نمودار چنددسته‌ای ایجاد کنید:

```java
Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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

    // اضافه کردن سری
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // ذخیره ارائه با نمودار
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای نقشه‌ای**

نمودار نقشه‌ای تصویری از یک ناحیه حاوی داده‌هاست. نمودارهای نقشه‌ای بهترین استفاده را برای مقایسه داده‌ها یا مقادیر در مناطق جغرافیایی مختلف دارند.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>مراحل:</em> ایجاد نمودار نقشه‌ای در Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>مراحل:</em> ایجاد نمودار نقشه‌ای PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>مراحل:</em> ایجاد نمودار نقشه‌ای ارائه PowerPoint در Java</strong></a>

این کد Java نشان می‌دهد چگونه یک نمودار نقشه‌ای ایجاد کنید:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای ترکیبی**

نمودار ترکیبی (یا combo chart) دو یا چند نوع نمودار را در یک گراف ترکیب می‌کند. این نمودار به شما امکان می‌دهد تفاوت‌ها یا روابط بین دو یا چند مجموعه داده را برجسته، مقایسه یا بررسی کنید.

![The combination chart](combination_chart.png)

کد Java زیر نشان می‌دهد چگونه نمودار ترکیبی نمایش داده‌شده در بالا را در یک ارائه PowerPoint ایجاد کنید:

```java
static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // عنوان نمودار را تنظیم کنید.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // افسانه نمودار را تنظیم کنید.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف کنید.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // دسته‌های جدید اضافه کنید.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // سری اول را اضافه کنید.
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // محور افقی را تنظیم کنید.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // محور عمودی را تنظیم کنید.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // رنگ خطوط شبکه اصلی عمودی را تنظیم کنید.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // محور افقی ثانویه را تنظیم کنید.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // محور عمودی ثانویه را تنظیم کنید.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```

## **به‌روزرسانی نمودارها**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>مراحل:</em> به‌روزرسانی نمودار PowerPoint در Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>مراحل:</em> به‌روزرسانی نمودار ارائه در Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>مراحل:</em> به‌روزرسانی نمودار ارائه PowerPoint در Java</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) که شامل نمودار موردنظر برای به‌روزرسانی است، ایجاد کنید.
2. مرجع یک اسלاید را با استفاده از ایندکس آن به‌دست آورید.
3. تمام اشکال را پیمایش کنید تا نمودار موردنظر را پیدا کنید.
4. به ورق‌کار داده‌های نمودار دسترسی پیدا کنید.
5. داده‌های سری‌های نمودار را با تغییر مقادیر سری‌ها اصلاح کنید.
6. یک سری جدید اضافه کنید و داده‌های آن را پر کنید.
7. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه یک نمودار را به‌روزرسانی کنید:

```java
Presentation pres = new Presentation();
try {
    // دسترسی به اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // دریافت نمودار با داده‌های پیش‌فرض
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // تنظیم شاخص برگه داده‌های نمودار
    int defaultWorksheetIndex = 0;

    // دریافت برگه کاری داده‌های نمودار
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // تغییر نام دسته‌بندی نمودار
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // دریافت سری اول نمودار
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // در حال به‌روزرسانی داده‌های سری
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// در حال اصلاح نام سری
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // دریافت سری دوم نمودار
    series = chart.getChartData().getSeries().get_Item(1);

    // در حال به‌روزرسانی داده‌های سری
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// در حال اصلاح نام سری
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // در حال افزودن سری جدید
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // دریافت سری سوم نمودار
    series = chart.getChartData().getSeries().get_Item(2);

    // در حال پر کردن داده‌های سری
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // ذخیره ارائه همراه با نمودار
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم بازه داده برای نمودار**

برای تنظیم بازه داده برای یک نمودار، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) که شامل نمودار است، ایجاد کنید.
2. مرجع یک اسלاید را از طریق ایندکس آن دریافت کنید.
3. تمام اشکال را پیمایش کنید تا نمودار موردنظر را پیدا کنید.
4. به داده‌های نمودار دسترسی پیدا کنید و بازه را تنظیم کنید.
5. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه بازه داده برای یک نمودار تنظیم شود:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **استفاده از نشانگرهای پیش‌فرض در نمودارها**
هنگامی که از نشانگر پیش‌فرض در نمودارها استفاده می‌کنید، هر سری نمودار به‌صورت خودکار نماد نشانگر پیش‌فرض متفاوتی دریافت می‌کند.

این کد Java نشان می‌دهد چگونه نشانگر سری نمودار به‌صورت خودکار تنظیم شود:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

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
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // در حال پر کردن داده‌های سری
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**کدام انواع نمودارها توسط Aspose.Slides پشتیبانی می‌شوند؟**

Aspose.Slides طیف گسترده‌ای از [chart types](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/charttype/) را شامل می‌شود، از جمله bar، line، pie، area، scatter، histogram، radar و بسیاری موارد دیگر. این انعطاف‌پذیری به شما امکان می‌دهد مناسب‌ترین نوع نمودار را برای نیازهای تصویری‌سازی داده‌های خود انتخاب کنید.

**چگونه یک نمودار جدید به اسلاید اضافه کنم؟**

برای افزودن نمودار، ابتدا یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد می‌کنید، اسלاید موردنظر را با ایندکس‌اش بازیابی می‌کنید و سپس متد افزودن نمودار را صدا می‌زنید، نوع نمودار و داده‌های اولیه را مشخص می‌کنید. این فرآیند نمودار را مستقیماً به ارائه شما ادغام می‌کند.

**چگونه می‌توان داده‌های نمایش داده‌شده در یک نمودار را به‌روزرسانی کرد؟**

می‌توانید داده‌های یک نمودار را با دسترسی به کتابخانه داده‌های آن ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/))، پاک کردن سری‌ها و دسته‌های پیش‌فرض و سپس افزودن داده‌های سفارشی خود به‌روزرسانی کنید. این امکان باعث می‌شود نمودار جدیدترین داده‌ها را منعکس کند.

**آیا امکان سفارشی‌سازی ظاهر نمودار وجود دارد؟**

بله، Aspose.Slides گزینه‌های سفارشی‌سازی گسترده‌ای ارائه می‌دهد. می‌توانید رنگ‌ها، قلم‌ها، برچسب‌ها، افسانه‌ها و سایر [formatting elements](/slides/fa/androidjava/chart-entities/) را تغییر دهید تا ظاهر نمودار را مطابق با نیازهای طراحی خاص خود تنظیم کنید.