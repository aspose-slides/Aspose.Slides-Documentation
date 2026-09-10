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
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی نمودارها در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Java. افزودن، قالب‌بندی و ویرایش نمودارها با مثال‌های کد عملی در Java."
---
## **بررسی کلی**

این مقاله یک راهنمای جامع دربارهٔ ایجاد و سفارشی‌سازی نمودارها با استفاده از Aspose.Slides ارائه می‌دهد. شما یاد خواهید گرفت که چگونه به‌صورت برنامه‌نویسی یک نمودار را به اسلاید اضافه کنید، آن را با داده‌ها پر کنید و گزینه‌های قالب‌بندی مختلفی را برای مطابقت با نیازهای طراحی خاص خود اعمال کنید. در سرتاسر مقاله، مثال‌های کد تفصیلی هر گام را نشان می‌دهند، از مقداردهی اولیهٔ Presentation و شیء نمودار تا پیکربندی سری‌ها، محورها و افسانه‌ها. با دنبال کردن این راهنما، درک محکمی از چگونگی ادغام تولید پویا نمودارها در برنامه‌های خود به دست خواهید آورد و فرآیند ایجاد ارائه‌های مبتنی بر داده را ساده‌تر می‌کنید.

## **ایجاد یک نمودار**

نمودارها به افراد کمک می‌کنند تا داده‌ها را به‌سرعت بصری‌سازی کرده و بینش‌هایی به دست آورند که ممکن است از یک جدول یا صفحه‌گسترده به‌صورت مستقیم واضح نباشند.

**چرا نمودارها ایجاد شوند؟**

* داده‌های حجیم را در یک اسلاید از ارائه جمع‌آوری، فشرده یا خلاصه کنید
* الگوها و روندهای داده‌ها را آشکار کنید
* جهت و شتاب داده‌ها را در طول زمان یا نسبت به یک واحد اندازه‌گیری خاص استخراج کنید
* نقاط دورافتاده، انحرافات، خطاها، داده‌های نامعقول و غیره را شناسایی کنید
* داده‌های پیچیده را انتقال یا ارائه دهید

در PowerPoint می‌توانید از طریق عملکرد *Insert* نمودارها را ایجاد کنید که قالب‌های متعددی برای طراحی انواع مختلف نمودارها فراهم می‌کند. با استفاده از Aspose.Slides می‌توانید هم نمودارهای معمولی (بر پایهٔ انواع محبوب نمودار) و هم نمودارهای سفارشی ایجاد کنید.

{{% alert color="info" title="Note" %}}
برای ایجاد نمودارها، از کلاس [ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/) استفاده کنید. فیلدهای این کلاس به انواع مختلف نمودارها مربوط می‌شوند.
{{% /alert %}}

### **ایجاد نمودارهای ستونی خوشه‌ای**

این بخش نحوه ایجاد نمودارهای ستونی خوشه‌ای با استفاده از Aspose.Slides را توضیح می‌دهد. شما یاد می‌گیرید که یک Presentation را مقداردهی اولیه کنید، یک نمودار اضافه کنید و عناصر آن مانند عنوان، داده‌ها، سری‌ها، دسته‌ها و استایل را سفارشی کنید. برای مشاهده نحوهٔ تولید یک نمودار ستونی خوشه‌ای استاندارد، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
2. با استفاده از شاخص آن، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های اولیه اضافه کنید و نوع `ChartType.ClusteredColumn` را مشخص کنید.
4. یک عنوان به نمودار اضافه کنید.
5. به کاربرگ داده‌های نمودار دسترسی پیدا کنید.
6. تمام سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
7. سری‌ها و دسته‌های جدید اضافه کنید.
8. داده‌های جدید برای سری‌های نمودار اضافه کنید.
9. یک رنگ پر برای سری‌های نمودار اعمال کنید.
10. برچسب‌ها را به سری‌های نمودار اضافه کنید.
11. Presentation اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک نمودار با داده‌های پیش‌فرض آن اضافه می‌کند
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // عنوان نمودار را تنظیم می‌کند
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
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
    
    // اولین سری نمودار را می‌گیرد
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // حالا داده‌های سری را پر می‌کند
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // رنگ پر کردن سری را تنظیم می‌کند
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // دومین سری نمودار را می‌گیرد
    series = chart.getChartData().getSeries().get_Item(1);
    
    // داده‌های سری را پر می‌کند
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // رنگ پر کردن سری را تنظیم می‌کند
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // برچسب‌های سفارشی برای هر دسته برای سری جدید ایجاد می‌کند
    // اولین برچسب را برای نمایش نام دسته تنظیم می‌کند
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

نمودارهای پراکنده (که به عنوان scatter plot یا نمودار x‑y نیز شناخته می‌شوند) معمولاً برای بررسی الگوها یا نشان دادن همبستگی بین دو متغیر استفاده می‌شوند.

از یک نمودار پراکنده زمانی استفاده کنید که:

* داده‌های عددی جفت‌ شده دارید
* دو متغیر دارید که به‌خوبی با هم جفت می‌شوند
* می‌خواهید تعیین کنید آیا دو متغیر مرتبط هستند یا نه
* متغیر مستقل دارید که برای یک متغیر وابسته مقادیر متعددی دارد

1. مراحل موجود در [Create Clustered Column Charts](#create-clustered-column-charts) را دنبال کنید.
2. برای مرحلهٔ سوم، یک نمودار با داده‌های اولیه اضافه کنید و نوع نمودار خود را به یکی از موارد زیر اختصاص دهید:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _نمودار پراکندگی را نمایندگی می‌کند._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _نمودار پراکنده‌ای را که با منحنی‌ها به‌هم متصل است و دارای نشانگرهای داده است، نمایندگی می‌کند._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _نمودار پراکنده‌ای را که با منحنی‌ها به‌هم متصل است ولی نشانگرهای داده ندارد، نمایندگی می‌کند._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _نمودار پراکنده‌ای را که با خطوط مستقیم به‌هم متصل است و دارای نشانگرهای داده است، نمایندگی می‌کند._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _نمودار پراکنده‌ای را که با خطوط مستقیم به‌هم متصل است ولی نشانگرهای داده ندارد، نمایندگی می‌کند._

```java
import com.aspose.slides.*;

// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    ISlide slide = pres.getSlides().get_Item(0);

    // نمودار پیش‌فرض را ایجاد می‌کند
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // شاخص برگه کاری داده‌های پیش‌فرض نمودار را دریافت می‌کند
    int defaultWorksheetIndex = 0;
    
    // برگه کاری داده‌های نمودار را دریافت می‌کند
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // سری‌های نمونه را حذف می‌کند
    chart.getChartData().getSeries().clear();
    
    // سری‌های جدید را اضافه می‌کند
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // اولین سری نمودار را می‌گیرد
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // یک نقطه جدید (1:3) به سری اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // یک نقطه جدید (2:10) اضافه می‌کند
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // نوع سری را تغییر می‌دهد
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // نشانگر سری نمودار را تغییر می‌دهد
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
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
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای دایره‌ای**

نمودارهای دایره‌ای بهترین استفاده را برای نشان دادن رابطهٔ بخش به کل در داده‌ها دارند، به‌ویژه وقتی داده‌ها شامل برچسب‌های دسته‌ای با مقادیر عددی باشند. اما اگر داده‌های شما شامل بخش‌ها یا برچسب‌های زیادی باشد، ممکن است بخواهید به‌جای آن از نمودار میله‌ای استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از شاخص، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Pie](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#Pie) را مشخص کنید.
4. به دفتر کار داده‌های نمودار [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. نقاط جدید برای نمودار اضافه کنید و رنگ‌های سفارشی را برای بخش‌های نمودار دایره‌ای اعمال کنید.
9. برچسب‌ها را برای سری‌ها تنظیم کنید.
10. خطوط راهنما را برای برچسب‌های سری فعال کنید.
11. زاویۀ چرخش برای بخش‌های نمودار دایره‌ای تنظیم کنید.
12. Presentation اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
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
	
    // مرز بخش را تنظیم می‌کند
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // مرز بخش را تنظیم می‌کند
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // مرز بخش را تنظیم می‌کند
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // برچسب‌های سفارشی برای هر دسته برای سری جدید ایجاد می‌کند
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
    
    // ارائه را با نمودار ذخیره می‌کند
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ایجاد نمودارهای خطی**

نمودارهای خطی (که به عنوان نمودارهای خطی نیز شناخته می‌شوند) بهترین استفاده را در موقعیت‌هایی دارند که می‌خواهید تغییر مقدار در طول زمان را نشان دهید. با استفاده از یک نمودار خطی، می‌توانید مقدار زیاد داده را به‌یکباره مقایسه کنید، تغییرات و روندها را در طول زمان پیگیری کنید، ناهنجاری‌های سری‌های داده را برجسته کنید و غیره.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از شاخص، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Line](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#Line) را مشخص کنید.
4. Presentation اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

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

به‌طور پیش‌فرض، نقاط یک نمودار خطی توسط خطوط مستقیم متصل می‌شوند. اگر می‌خواهید به‌جای آن نقاط توسط خطوط نقطه‌دار متصل شوند، می‌توانید نوع خط نقطه‌دار موردنظر خود را به شکل زیر مشخص کنید:

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

### **ایجاد نمودارهای درختی (Tree Map)**

نمودارهای درختی بهترین استفاده را برای داده‌های فروش دارند هنگامی که می‌خواهید نسبت اندازهٔ دسته‌های داده را نشان دهید و به‌سرعت توجه را به مواردی که سهم بزرگی در هر دسته دارند جلب کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از شاخص، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Treemap](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#Treemap) را مشخص کنید.
4. به دفتر کار داده‌های نمودار [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. Presentation اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```java
import com.aspose.slides.*;

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

### **ایجاد نمودارهای سهام (Stock)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از شاخص، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#OpenHighLowClose) را مشخص کنید.
4. به دفتر کار داده‌های نمودار [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. فرمت خطوط بالا‑پایین را مشخص کنید.
9. Presentation اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

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

### **ایجاد نمودارهای جعبه‌ای و ویسکر (Box and Whisker)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از شاخص، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#BoxAndWhisker) را مشخص کنید.
4. به دفتر کار داده‌های نمودار [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. Presentation اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

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

### **ایجاد نمودارهای قیفی (Funnel)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از شاخص، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Funnel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#Funnel) را مشخص کنید.
4. Presentation اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

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

### **ایجاد نمودارهای خورشیدی (Sunburst)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از شاخص، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Sunburst](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#Sunburst) را مشخص کنید.
4. Presentation اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```java
import com.aspose.slides.*;

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

### **ایجاد نمودارهای هیستوگرام (Histogram)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از شاخص، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Histogram](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#Histogram) را مشخص کنید.
4. به دفتر کار داده‌های نمودار [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. Presentation اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

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

### **ایجاد نمودارهای رادار (Radar)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از شاخص، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های اولیه اضافه کنید و نوع نمودار موردنظر خود را (در این مورد [ChartType.Radar](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#Radar)) مشخص کنید.
4. Presentation اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

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

### **ایجاد نمودارهای چنددسته‌ای (Multi-Category)**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از شاخص، به یک اسلاید ارجاع بگیرید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.ClusteredColumn](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/#ClusteredColumn) را مشخص کنید.
4. به دفتر کار داده‌های نمودار [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. Presentation اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

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

### **ایجاد نمودارهای نقشه (Map)**

نقشه‌ها داده‌های جغرافیایی را بصری‌سازی می‌کنند و به مقایسهٔ مقادیر بین مناطق کمک می‌نمایند.

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

### **ایجاد نمودارهای ترکیبی (Combination)**

یک نمودار ترکیبی (یا combo chart) دو یا چند نوع نمودار را در یک گراف ترکیب می‌کند. این نمودار به شما امکان می‌دهد تا تفاوت‌ها بین دو یا چند مجموعه داده را برجسته، مقایسه یا بررسی کنید و روابط بین آن‌ها را شناسایی کنید.

![نمودار ترکیبی](combination_chart.png)

کد زیر در Java نشان می‌دهد چگونه نمودار ترکیبی نمایش‌داده‌شده در بالا را در یک ارائه PowerPoint ایجاد کنید:

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

    // تنظیم رنگ خطوط توری اصلی عمودی.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // تنظیم محور افقی ثانویه.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // تنظیم محور عمودی ثانویه.
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

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید که نمایانگر ارائه‌ای است که نمودار موردنظر را برای به‌روزرسانی دارد.
2. با استفاده از شاخص، به یک اسلاید ارجاع بگیرید.
3. در میان تمام اشکال مرور کنید تا نمودار موردنظر را پیدا کنید.
4. به کاربرگ داده‌های نمودار دسترسی پیدا کنید.
5. سری‌های دادهٔ نمودار را با تغییر مقادیر سری‌ها اصلاح کنید.
6. یک سری جدید اضافه کنید و داده‌های آن را پر کنید.
7. Presentation اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```java
import com.aspose.slides.*;

// نمایش‌ئی که شامل نمودار است را برای به‌روزرسانی باز می‌کند
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // دسترسی به اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // دریافت نمودار از اسلاید
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // تنظیم شاخص برگه داده‌های نمودار
    int defaultWorksheetIndex = 0;

    // دریافت برگه کاری داده‌های نمودار
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // تغییر نام دسته‌بندی نمودار
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // دریافت اولین سری نمودار
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // در حال به‌روزرسانی داده‌های سری
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// تغییر نام سری
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // دریافت دومین سری نمودار
    series = chart.getChartData().getSeries().get_Item(1);

    // در حال به‌روزرسانی داده‌های سری
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// تغییر نام سری
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // اکنون، افزودن یک سری جدید
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // دریافت سومین سری نمودار
    series = chart.getChartData().getSeries().get_Item(2);

    // در حال پر کردن داده‌های سری
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

## **تنظیم محدوده داده برای یک نمودار**

برای تنظیم محدوده داده برای یک نمودار، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید که نمایانگر ارائه‌ای است که نمودار در آن قرار دارد.
2. با استفاده از شاخص، به یک اسلاید ارجاع بگیرید.
3. در میان تمام اشکال مرور کنید تا نمودار موردنظر را پیدا کنید.
4. به داده‌های نمودار دسترسی پیدا کنید و محدوده را تنظیم کنید.
5. Presentation اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```java
import com.aspose.slides.*;

// نمایش‌ئی که شامل نمودار است را باز می‌کند
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

وقتی از نشانگرهای پیش‌فرض در نمودارها استفاده می‌کنید، هر سری نمودار به‌صورت خودکار یک نماد نشانگر متفاوت دریافت می‌کند.

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
    //دریافت دومین سری نمودار
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    //در حال پر کردن داده‌های سری
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

**چه نوع نمودارهایی توسط Aspose.Slides پشتیبانی می‌شوند؟**

Aspose.Slides محدودهٔ وسیعی از [chart types](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/) را پشتیبانی می‌کند، از جمله ستون، خط، دایره‌ای، ناحیه، پراکنده، هیستوگرام، رادار و بسیاری دیگر. این انعطاف‌پذیری به شما امکان می‌دهد تا مناسب‌ترین نوع نمودار را برای نیازهای بصری‌سازی دادهٔ خود انتخاب کنید.

**چگونه یک نمودار جدید به اسلاید اضافه می‌کنم؟**

برای افزودن یک نمودار ابتدا یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد می‌کنید، اسلاید موردنظر را با استفاده از شاخص دریافت می‌کنید و سپس متد افزودن نمودار را صدا می‌زنید، نوع نمودار و دادهٔ اولیه را مشخص می‌کنید. این فرآیند نمودار را مستقیماً به ارائهٔ شما ادغام می‌کند.

**چگونه می‌توان داده‌های نمایش‌داده‌شده در یک نمودار را به‌روز کرد؟**

می‌توانید داده‌های یک نمودار را با دسترسی به دفتر کار داده‌های آن ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/))، پاک‌کردن سری‌ها و دسته‌های پیش‌فرض و سپس افزودن داده‌های سفارشی خود به‌روز کنید. این کار به شما اجازه می‌دهد تا نمودار را برای نمایش آخرین داده‌ها تازه‌سازی کنید.

**آیا می‌توان ظاهر نمودار را سفارشی‌کرد؟**

بله، Aspose.Slides گزینه‌های گسترده‌ای برای سفارشی‌سازی فراهم می‌کند. می‌توانید رنگ‌ها، قلم‌ها، برچسب‌ها، افسانه‌ها و دیگر عناصر [formatting elements](/slides/fa/java/chart-entities/) را تغییر دهید تا ظاهر نمودار را مطابق نیازهای طراحی خود تنظیم کنید.