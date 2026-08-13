---
title: ایجاد یا به‌روزرسانی نمودارهای ارائه PowerPoint در Java
linktitle: ایجاد یا به‌روزرسانی نمودارها
type: docs
weight: 10
url: /fa/java/create-chart/
keywords:
- افزودن نمودار
- ایجاد نمودار
- ویرایش نمودار
- تغییر نمودار
- به‌روزرسانی نمودار
- نمودار پراکندگی
- نمودار دایره‌ای
- نمودار خطی
- نمودار درخت‌نقشه‌ای
- نمودار سهام
- نمودار جعبه‌ای و ویسکر
- نمودار قیفی
- نمودار خورشیدی
- نمودار هیستوگرام
- نمودار رادار
- نمودار چنددسته‌ای
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی نمودارها در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Java. افزودن، قالب‌بندی و ویرایش نمودارها با مثال‌های کد عملی در Java."
---
## **بررسی کلی**

این مقاله راهنمای کاملی برای ایجاد و سفارشی‌سازی نمودارها با استفاده از Aspose.Slides فراهم می‌کند. شما یاد خواهید گرفت که چگونه به‌صورت برنامه‌نویسی یک نمودار را به اسلاید اضافه کنید، آن را با داده‌ها پر کنید و گزینه‌های قالب‌بندی مختلف را برای برآورده کردن نیازهای طراحی خاص خود اعمال کنید. در سراسر مقاله، مثال‌های کد تفصیلی هر مرحله را نشان می‌دهند، از مقداردهی اولیهٔ ارائه و شیء نمودار تا پیکربندی سری‌ها، محورها و افسانه‌ها. با پیروی از این راهنما، درک محکمی از چگونگی ادغام تولید نمودار پویا در برنامه‌های خود به دست می‌آورید و فرایند ایجاد ارائه‌های مبتنی بر داده را ساده می‌کنید.

## **ایجاد نمودار**

نمودارها به افراد کمک می‌کنند تا به سرعت داده‌ها را بصری‌سازی کنند و بینش‌هایی به دست آورند که ممکن است از یک جدول یا صفحه‌گسترده به‌سرعت واضح نباشد.

**چرا ایجاد نمودارها؟**

با استفاده از نمودارها می‌توانید

* تجمیع، فشرده‌سازی یا خلاصه‌سازی حجم بالایی از داده‌ها در یک اسلاید ارائه
* نمایش الگوها و روندهای داده
* استنتاج جهت و سرعت داده‌ها در طول زمان یا نسبت به یک واحد اندازه‌گیری خاص
* شناسایی مقادیر دور از حد، انحرافات، خطاها، داده‌های بی‌معنی و غیره
* ارتباط یا ارائه داده‌های پیچیده

در PowerPoint می‌توانید نمودارها را از طریق عملکرد Insert ایجاد کنید که قالب‌های مختلفی برای طراحی انواع نمودارها فراهم می‌کند. با استفاده از Aspose.Slides می‌توانید نمودارهای معمولی (بر پایه انواع نمودارهای محبوب) و نمودارهای سفارشی ایجاد کنید.

{{% alert color="info" %}} 
برای اینکه بتوانید نمودارها را ایجاد کنید، Aspose.Slides کلاس [ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ChartType) را ارائه می‌دهد. فیلدهای این کلاس مربوط به انواع مختلف نمودار هستند.
{{% /alert %}}

### **ایجاد نمودارهای عادی**

_مراحل: ایجاد نمودار_

- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>مراحل:</em> ایجاد نمودار PowerPoint در Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>مراحل:</em> ایجاد نمودار ارائه در Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>مراحل:</em> ایجاد نمودار ارائه PowerPoint در Java</strong></a>

مراحل کد:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. یک نمودار با برخی داده‌ها اضافه کنید و نوع نمودار دلخواه خود را مشخص کنید.  
4. عنوانی برای نمودار اضافه کنید.  
5. به برگه‌کاری داده‌های نمودار دسترسی پیدا کنید.  
6. تمام سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
7. سری‌ها و دسته‌های جدید اضافه کنید.  
8. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
9. یک رنگ پر برای سری‌های نمودار اضافه کنید.  
10. برچسب‌هایی برای سری‌های نمودار اضافه کنید.  
11. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک نمودار عادی ایجاد کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// نمونه‌ای از کلاس ارائه که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید اول
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک نمودار با داده‌های پیش‌فرض آن اضافه می‌کند
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // عنوان نمودار را تنظیم می‌کند
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // تنظیم شاخص برگه دادهٔ نمودار
    int defaultWorksheetIndex = 0;
    
    // برگه کار دادهٔ نمودار را دریافت می‌کند
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
    
    // سلسلهٔ اول نمودار را می‌گیرد
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // اکنون داده‌های سری را پر می‌کند
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // رنگ پر کردن سری را تنظیم می‌کند
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // سلسلهٔ دوم نمودار را می‌گیرد
    series = chart.getChartData().getSeries().get_Item(1);
    
    // داده‌های سری را پر می‌کند
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // رنگ پر کردن سری را تنظیم می‌کند
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Create custom labels for each categories for the new series
    // برچسب اول را برای نمایش نام دسته تنظیم می‌کند
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // مقدار را برای برچسب سوم نشان می‌دهد
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // ارائه را به همراه نمودار ذخیره می‌کند
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای پراکندگی**

نمودارهای پراکندگی (که به نام نمودارهای پخش یا گراف‌های x-y نیز شناخته می‌شوند) معمولاً برای بررسی الگوها یا نشان دادن همبستگی بین دو متغیر استفاده می‌شوند.

ممکن است بخواهید از یک نمودار پراکندگی استفاده کنید وقتی که

* داده‌های عددی جفت‌خورده دارید
* دو متغیر دارید که به‌خوبی با هم جفت می‌شوند
* می‌خواهید تعیین کنید آیا دو متغیر مرتبط هستند یا نه
* یک متغیر مستقل دارید که برای یک متغیر وابسته مقادیر متعددی دارد

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>مراحل:</em> ایجاد نمودار پراکندگی در Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>مراحل:</em> ایجاد نمودار پراکندگی PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>مراحل:</em> ایجاد نمودار پراکندگی ارائه PowerPoint در Java</strong></a>

1. لطفاً مراحل ذکر شده در [Creating Normal Charts](#creating-normal-charts) را دنبال کنید.  
2. برای گام سوم، یک نمودار با برخی داده‌ها اضافه کنید و نوع نمودار خود را به‌عنوان یکی از موارد زیر مشخص کنید  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _نمایش‌دهندهٔ نمودار پراکندگی._  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _نمایش‌دهندهٔ نمودار پراکندگی متصل به‌وسیلهٔ منحنی‌ها، با نشانگرهای داده._  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _نمایش‌دهندهٔ نمودار پراکندگی متصل به‌وسیلهٔ منحنی‌ها، بدون نشانگرهای داده._  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) – _نمایش‌دهندهٔ نمودار پراکندگی متصل به‌وسیلهٔ خطوط مستقیم، با نشانگرهای داده._  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#ScatterWithStraightLines) – _نمایش‌دهندهٔ نمودار پراکندگی متصل به‌وسیلهٔ خطوط مستقیم، بدون نشانگرهای داده._

این کد Java نشان می‌دهد چگونه یک نمودار پراکندگی با سری‌های مختلف نشانگرها ایجاد کنید:

```java
import com.aspose.slides.*;

// نمونه‌ای از کلاس ارائه که نمایانگر یک فایل PPTX است
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
    
    // سری نمونه را حذف می‌کند
    chart.getChartData().getSeries().clear();
    
    // سری‌های جدید را اضافه می‌کند
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
    
    // علامت (مارکر) سری نمودار را تغییر می‌دهد
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
    
    // علامت (مارکر) سری نمودار را تغییر می‌دهد
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای دایره‌ای**

نمودارهای دایره‌ای برای نشان دادن نسبت بخش به کل در داده‌ها، به‌ویژه زمانی که داده‌ها شامل برچسب‌های دسته‌ای با مقادیر عددی هستند، بهترین استفاده را دارند. اما اگر داده‌های شما شامل بخش‌ها یا برچسب‌های زیادی باشد، ممکن است بهتر باشد به‌جای آن از نمودار میله‌ای استفاده کنید.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>مراحل:</em> ایجاد نمودار دایره‌ای در Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>مراحل:</em> ایجاد نمودار دایره‌ای PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>مراحل:</em> ایجاد نمودار دایره‌ای ارائه PowerPoint در Java</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن به‌دست آورید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر (در این مورد، [ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ChartType).Pie) اضافه کنید.  
4. به داده‌های نمودار [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataWorkbook) دسترسی پیدا کنید.  
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
6. سری‌ها و دسته‌های جدید اضافه کنید.  
7. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.  
8. نقاط جدیدی برای نمودارها اضافه کنید و رنگ‌های سفارشی برای بخش‌های نمودار دایره‌ای تعیین کنید.  
9. برچسب‌ها را برای سری‌ها تنظیم کنید.  
10. خطوط راهنما برای برچسب‌های سری تنظیم کنید.  
11. زاویه چرخش اسلایدهای نمودار دایره‌ای را تنظیم کنید.  
12. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک نمودار دایره‌ای ایجاد کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس ارائه ایجاد می‌کند که یک فایل PPTX را نشان می‌دهد
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
    
    // شاخص برگه داده‌های نمودار را تنظیم می‌کند
    int defaultWorksheetIndex = 0;
    
    // برگه کار داده‌های نمودار را دریافت می‌کند
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
	
    // حاشیهٔ بخش را تنظیم می‌کند
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // حاشیهٔ بخش را تنظیم می‌کند
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // حاشیهٔ بخش را تنظیم می‌کند
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // برچسب‌های سفارشی برای هر دسته در سری جدید ایجاد می‌کند
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
    
    // ارائه را با یک نمودار ذخیره می‌کند
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای خطی**

نمودارهای خطی (که به‌عنوان نمودارهای خط نیز شناخته می‌شوند) بهترین استفاده را در شرایطی دارند که بخواهید تغییرات مقدار را در طول زمان نشان دهید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر (در این مورد، `ChartType.Line`) اضافه کنید.  
4. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک نمودار خطی ایجاد کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

به‌صورت پیش‌فرض، نقاط در یک نمودار خطی با خطوط مستقیم متصل می‌شوند. اگر می‌خواهید نقاط به‌جای خطوط پیوسته با خط‌های نقطه‌داری متصل شوند، می‌توانید نوع خط دلخواه خود را به این شکل مشخص کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای درخت‌نقشه‌ای**

نمودارهای درخت‌نقشه‌ای برای داده‌های فروش بهترین استفاده را دارند زمانی که می‌خواهید اندازه نسبی دسته‌های داده را نشان دهید و (در همان زمان) به سرعت توجه را به آیتم‌های بزرگ‌مهم هر دسته جلب کنید.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>مراحل:</em> ایجاد نمودار درخت‌نقشه‌ای در Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>مراحل:</em> ایجاد نمودار درخت‌نقشه‌ای PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>مراحل:</em> ایجاد نمودار درخت‌نقشه‌ای ارائه PowerPoint در Java</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر (در این مورد، [ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ChartType).TreeMap) اضافه کنید.  
4. به داده‌های نمودار [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataWorkbook) دسترسی پیدا کنید.  
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
6. سری‌ها و دسته‌های جدید اضافه کنید.  
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
8. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک نمودار درخت‌نقشه‌ای ایجاد کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //شاخه 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //شاخه 2
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

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن به‌دست آورید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر ([ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ChartType).OpenHighLowClose) اضافه کنید.  
4. به داده‌های نمودار [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataWorkbook) دسترسی پیدا کنید.  
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
6. سری‌ها و دسته‌های جدید اضافه کنید.  
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
8. فرمت خطوط HiLowLines را مشخص کنید.  
9. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد Java نمونه برای ایجاد یک نمودار سهام است:

```java
import com.aspose.slides.*;

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

### **ایجاد نمودارهای جعبه‌ای و ویسکر**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>مراحل:</em> ایجاد نمودار جعبه‌ای و ویسکر در Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>مراحل:</em> ایجاد نمودار جعبه‌ای و ویسکر PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>مراحل:</em> ایجاد نمودار جعبه‌ای و ویسکر ارائه PowerPoint در Java</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر ([ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ChartType).BoxAndWhisker) اضافه کنید.  
4. به داده‌های نمودار [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataWorkbook) دسترسی پیدا کنید.  
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
6. سری‌ها و دسته‌های جدید اضافه کنید.  
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
8. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک نمودار جعبه‌ای و ویسکر ایجاد کنید:

```java
import com.aspose.slides.*;

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

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر ([ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ChartType).Funnel) اضافه کنید.  
4. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

کد Java نشان می‌دهد چگونه یک نمودار قیفی ایجاد کنید:

```java
import com.aspose.slides.*;

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

### **ایجاد نمودارهای خورشیدی**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>مراحل:</em> ایجاد نمودار خورشیدی در Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>مراحل:</em> ایجاد نمودار خورشیدی PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>مراحل:</em> ایجاد نمودار خورشیدی ارائه PowerPoint در Java</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر (در این مورد، [ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ChartType).sunburst) اضافه کنید.  
4. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک نمودار خورشیدی ایجاد کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //شاخه 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //شاخه 2
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

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر ([ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ChartType).Histogram) اضافه کنید.  
4. به داده‌های نمودار [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataWorkbook) دسترسی پیدا کنید.  
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
6. سری‌ها و دسته‌های جدید اضافه کنید.  
7. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک نمودار هیستوگرام ایجاد کنید:

```java
import com.aspose.slides.*;

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

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای رادار**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>مراحل:</em> ایجاد نمودار رادار در Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>مراحل:</em> ایجاد نمودار رادار PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>مراحل:</em> ایجاد نمودار رادار ارائه PowerPoint در Java</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. یک نمودار با برخی داده‌ها اضافه کنید و نوع نمودار دلخواه خود را (`ChartType.Radar` در این مورد) مشخص کنید.  
4. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک نمودار رادار ایجاد کنید:

```java
import com.aspose.slides.*;

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

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر ([ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ChartType).ClusteredColumn) اضافه کنید.  
4. به داده‌های نمودار [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataWorkbook) دسترسی پیدا کنید.  
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
6. سری‌ها و دسته‌های جدید اضافه کنید.  
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
8. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک نمودار چنددسته‌ای ایجاد کنید:

```java
import com.aspose.slides.*;

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

    // افزودن سری‌ها
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
    
    // ذخیرهٔ ارائه با نمودار
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای نقشه‌ای**

نقشه‌نمودار یک تجسم از یک ناحیه حاوی داده‌هاست. نمودارهای نقشه‌ای برای مقایسه داده‌ها یا مقادیر در سراسر مناطق جغرافیایی بهترین استفاده را دارند.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>مراحل:</em> ایجاد نمودار نقشه‌ای در Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>مراحل:</em> ایجاد نمودار نقشه‌ای PowerPoint در Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>مراحل:</em> ایجاد نمودار نقشه‌ای ارائه PowerPoint در Java</strong></a>

این کد Java نشان می‌دهد چگونه یک نمودار نقشه‌ای ایجاد کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای ترکیبی**

نمودار ترکیبی (یا combo chart) دو یا چند نوع نمودار را در یک گراف ترکیب می‌کند. این نمودار به شما امکان می‌دهد تا نکات برجسته، مقایسه یا بررسی اختلافات بین دو یا چند مجموعه داده را انجام دهید و روابط بین آن‌ها را شناسایی کنید.

![نمودار ترکیبی](combination_chart.png)

کد Java زیر نشان می‌دهد چگونه نمودار ترکیبی نشان داده شده در بالا را در یک ارائهٔ PowerPoint ایجاد کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // تنظیم عنوان نمودار.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // تنظیم افسانه نمودار.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // حذف سری‌ها و دسته‌های پیش‌فرض تولید شده.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // افزودن دسته‌های جدید.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // افزودن سری اول.
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
    // تنظیم محور افقی.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // تنظیم محور عمودی.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // تنظیم رنگ خطوط شبکه اصلی عمودی.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // تنظیم محور افقی ثانوي.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // تنظیم محور عمودی ثانوي.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().setFillType(FillType.NoFill);

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

1. نمونه‌ای از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) که ارائه حاوی نمودار موردنظر را نمایان می‌کند، ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن به‌دست آورید.  
3. از میان تمام اشکال عبور کنید تا نمودار موردنظر را پیدا کنید.  
4. به برگه‌کاری داده‌های نمودار دسترسی پیدا کنید.  
5. داده‌های سری نمودار را با تغییر مقادیر سری اصلاح کنید.  
6. یک سری جدید اضافه کنید و داده‌های آن را پر کنید.  
7. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک نمودار را به‌روزرسانی کنید:

```java
import com.aspose.slides.*;

// ارائه‌ای را که شامل نمودار برای به‌روزرسانی است باز می‌کند
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // دسترسی به اسلاید اول
    ISlide sld = pres.getSlides().get_Item(0);

    // دریافت نمودار از اسلاید
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // تنظیم شاخص شیت داده‌های نمودار
    int defaultWorksheetIndex = 0;

    // دریافت شیت کاری داده‌های نمودار
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // تغییر نام دسته‌بندی نمودار
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // گرفتن سری اول نمودار
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // اکنون داده‌های سری را به‌روزرسانی می‌کنیم
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // تغییر نام سری
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // گرفتن سری دوم نمودار
    series = chart.getChartData().getSeries().get_Item(1);

    // اکنون داده‌های سری را به‌روزرسانی می‌کنیم
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // تغییر نام سری
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // اکنون، افزودن یک سری جدید
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // گرفتن سری سوم نمودار
    series = chart.getChartData().getSeries().get_Item(2);

    // اکنون داده‌های سری را پر می‌کنیم
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // ذخیرهٔ ارائه با نمودار
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم بازه داده برای یک نمودار**

برای تنظیم بازه داده برای یک نمودار، این کارها را انجام دهید:

1. نمونه‌ای از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) که ارائه حاوی نمودار را نمایان می‌کند، ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. از میان تمام اشکال عبور کنید تا نمودار موردنظر را پیدا کنید.  
4. به داده‌های نمودار دسترسی پیدا کنید و بازه را تنظیم کنید.  
5. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه بازه دادهٔ یک نمودار را تنظیم کنید:

```java
import com.aspose.slides.*;

// ارائه‌ای را که شامل نمودار است باز می‌کند
Presentation pres = new Presentation("ExistingChart.pptx");
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

هنگامی که از یک نشانگر پیش‌فرض در نمودارها استفاده می‌کنید، هر سری نمودار به‌طور خودکار نماد نشانگر پیش‌فرض متفاوتی دریافت می‌کند.

این کد Java نشان می‌دهد چگونه به‌طور خودکار نشانگر سری نمودار را تنظیم کنید:

```java
import com.aspose.slides.*;

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

    // اکنون داده‌های سری را پر می‌کنیم
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

### چه نوع نمودارهایی توسط Aspose.Slides پشتیبانی می‌شوند؟

Aspose.Slides انواع گسترده‌ای از [chart types](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/) را پشتیبانی می‌کند، از جمله نوار، خط، دایره‌ای، مساحت، پراکندگی، هیستوگرام، رادار و بسیاری دیگر. این انعطاف‌پذیری به شما اجازه می‌دهد تا مناسب‌ترین نوع نمودار را برای نیازهای تجسم دادهٔ خود انتخاب کنید.

### چگونه یک نمودار جدید را به یک اسلاید اضافه کنم؟

برای افزودن یک نمودار، ابتدا یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید، اسلاید موردنظر را با استفاده از ایندکس آن دریافت کنید و سپس متد افزودن نمودار را صدا بزنید و نوع نمودار و داده‌های اولیه را تعیین کنید. این فرایند نمودار را مستقیماً در ارائهٔ شما ادغام می‌کند.

### چگونه می‌توانم داده‌های نمایش داده‌شده در یک نمودار را به‌روز کنم؟

می‌توانید داده‌های یک نمودار را با دسترسی به کتاب‌کار داده‌های آن ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/))، پاک کردن سری‌ها و دسته‌های پیش‌فرض، و سپس افزودن داده‌های سفارشی خود به‌روز کنید. این امکان به شما اجازه می‌دهد تا نمودار را برای نمایش جدیدترین داده‌ها تازه‌سازی کنید.

### آیا امکان سفارشی‌سازی ظاهر نمودار وجود دارد؟

بله، Aspose.Slides گزینه‌های سفارشی‌سازی گسترده‌ای ارائه می‌دهد. می‌توانید رنگ‌ها، فونت‌ها، برچسب‌ها، افسانه‌ها و سایر [formatting elements](/slides/fa/java/chart-entities/) را تغییر دهید تا ظاهر نمودار را مطابق با نیازهای طراحی خاص خود تنظیم کنید.