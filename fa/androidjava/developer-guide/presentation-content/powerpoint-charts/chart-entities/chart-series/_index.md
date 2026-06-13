---
title: مدیریت سری‌های داده نمودار در ارائه‌ها بر روی اندروید
linktitle: سری‌های داده
type: docs
url: /fa/androidjava/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
- رنگ سری
- رنگ دسته‌بندی
- نام سری
- نقطه داده
- فاصله سری
- PowerPoint
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار را در اندروید برای PowerPoint (PPT/PPTX) مدیریت کنید، با مثال‌های عملی کد جاوا و بهترین شیوه‌ها برای بهبود ارائه‌های داده‌ای خود."
---
## **نمای کلی**

این مقاله نقش [ChartSeries](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartseries/) را در Aspose.Slides توضیح می‌دهد و بر چگونگی ساختاردهی و تجسم داده‌ها در ارائه‌ها تمرکز می‌کند. این اشیاء عناصر پایه‌ای را فراهم می‌کنند که مجموعه‌های جداگانه‌ای از نقاط داده، دسته‌ها و پارامترهای ظاهر در یک نمودار را تعریف می‌کنند. با کار با [ChartSeries](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartseries/)، توسعه‌دهندگان می‌توانند به‌راحتی منابع داده‌ پایه را یکپارچه کرده و کنترل کامل بر نمایش اطلاعات داشته باشند و در نتیجه ارائه‌های پویا و مبتنی بر داده تولید کنند که بینش‌ها و تحلیل‌ها را به‌ وضوح منتقل می‌کنند.

یک سری، ردیف یا ستونی از اعداد است که در یک نمودار ترسیم می‌شود.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری نمودار**

با متد [IChartSeries.getOverlap](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getOverlap--) می‌توانید مقدار همپوشانی میله‌ها و ستون‌ها را در یک نمودار دو‌بعدی تعیین کنید (محدوده: -100 تا 100). این ویژگی برای تمام سری‌های گروه سری والد اعمال می‌شود: این یک نمایش از ویژگی گروه مناسب است. بنابراین، این ویژگی فقط-خواندنی است.

از متد `getParentSeriesGroup().setOverlap()` برای تنظیم مقدار دلخواه همپوشانی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
1. یک نمودار ستونی خوشه‌ای به یک اسلاید اضافه کنید.  
1. به اولین سری نمودار دسترسی پیدا کنید.  
1. به `ParentSeriesGroup` سری نمودار دسترسی پیدا کنید و مقدار همپوشانی دلخواه خود را تنظیم کنید.  
1. ارائهٔ اصلاح‌شده را در یک فایل PPTX بنویسید.

این کد جاوا نشان می‌دهد چگونه همپوشانی یک سری نمودار را تنظیم کنید:

```java
Presentation pres = new Presentation();
try {
    // افزودن نمودار
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // تنظیم همپوشانی سری
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // ذخیرهٔ فایل ارائه روی دیسک
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغییر رنگ سری**

Aspose.Slides for Android via Java به شما امکان می‌دهد رنگ یک سری را به این شکل تغییر دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
1. یک نمودار به اسلاید اضافه کنید.  
1. سری‌ای که می‌خواهید رنگ آن را تغییر دهید، دسترسی پیدا کنید.  
1. نوع پر کردن و رنگ پر کردن دلخواه خود را تنظیم کنید.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد جاوا نشان می‌دهد چگونه رنگ یک سری را تغییر دهید:

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغییر رنگ دسته‌بندی سری**

Aspose.Slides for Android via Java به شما امکان می‌دهد رنگ دسته‌بندی یک سری را به این شکل تغییر دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
1. یک نمودار به اسلاید اضافه کنید.  
1. دسته‌بندی سری‌ای که می‌خواهید رنگ آن را تغییر دهید، دسترسی پیدا کنید.  
1. نوع پر کردن و رنگ پر کردن دلخواه خود را تنظیم کنید.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد جاوا نشان می‌دهد چگونه رنگ یک دسته‌بندی سری را تغییر دهید:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغییر نام سری**

به‌طور پیش‌فرض، نام‌های افسانه (legend) برای یک نمودار محتوای سلول‌های بالای هر ستون یا ردیف داده هستند.

در مثال ما (تصویر نمونه)،  

* ستون‌ها *Series 1, Series 2,* و *Series 3* هستند؛  
* ردیف‌ها *Category 1, Category 2, Category 3,* و *Category 4* هستند.

Aspose.Slides for Android via Java به شما امکان می‌دهد نام یک سری را در داده‌های نمودار و افسانهٔ آن به‌روزرسانی یا تغییر دهید.

این کد جاوا نشان می‌دهد چگونه نام یک سری را در `ChartDataWorkbook` داده‌های نمودار تغییر دهید:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

این کد جاوا نشان می‌دهد چگونه نام یک سری را از طریق `Series` در افسانه تغییر دهید:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم رنگ پر خودکار برای سری نمودار**

Aspose.Slides for Android via Java به شما امکان می‌دهد رنگ پر خودکار را برای سری‌های نمودار داخل ناحیهٔ رسم به این شکل تنظیم کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
1. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض بر اساس نوع دلخواه خود اضافه کنید (در مثال زیر از `ChartType.ClusteredColumn` استفاده کردیم).  
1. به سری نمودار دسترسی پیدا کنید و رنگ پر را به Automatic تنظیم کنید.  
1. ارائه را در یک فایل PPTX ذخیره کنید.

این کد جاوا نشان می‌دهد چگونه رنگ پر خودکار را برای یک سری نمودار تنظیم کنید:

```java
Presentation pres = new Presentation();
try {
    // یک نمودار ستونی خوشه‌ای ایجاد می‌کند
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // قالب پر کردن سری را به حالت خودکار تنظیم می‌کند
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // فایل ارائه را روی دیسک می‌نویسد
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم رنگ پر معکوس برای سری نمودار**

Aspose.Slides به شما امکان می‌دهد رنگ پر معکوس را برای سری‌های نمودار داخل ناحیهٔ رسم به این شکل تنظیم کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
1. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض بر اساس نوع دلخواه خود اضافه کنید (در مثال زیر از `ChartType.ClusteredColumn` استفاده کردیم).  
1. به سری نمودار دسترسی پیدا کنید و رنگ پر را به invert تنظیم کنید.  
1. ارائه را در یک فایل PPTX ذخیره کنید.

این کد جاوا عملیات را نشان می‌دهد:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // سری‌ها و دسته‌بندی‌های جدید را اضافه می‌کند
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // سری اول نمودار را گرفته و داده‌های سری آن را پر می‌کند.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم معکوس شدن سری وقتی مقدار منفی است**

Aspose.Slides به شما امکان می‌دهد معکوس شدن را از طریق ویژگی‌های `IChartDataPoint.InvertIfNegative` و `ChartDataPoint.InvertIfNegative` تنظیم کنید. وقتی معکوس با استفاده از این ویژگی‌ها تنظیم شود، نقطه داده رنگ‌های خود را در صورت دریافت مقدار منفی معکوس می‌کند.

این کد جاوا عملیات را نشان می‌دهد:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پاک‌سازی داده‌های نقطه خاص**

Aspose.Slides for Android via Java به شما امکان می‌دهد داده‌های `DataPoints` یک سری نمودار خاص را به این شکل پاک کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. مرجع یک نمودار را از طریق ایندکس آن دریافت کنید.  
4. تمام `DataPoints` نمودار را پیمایش کرده و `XValue` و `YValue` را به null تنظیم کنید.  
5. تمام `DataPoints` برای سری نمودار خاص را پاک کنید.  
6. ارائهٔ اصلاح‌شده را در یک فایل PPTX بنویسید.

این کد جاوا عملیات را نشان می‌دهد:

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم عرض فاصله بین سری‌ها (Gap Width)**

Aspose.Slides for Android via Java به شما امکان می‌دهد عرض فاصله بین سری‌ها را از طریق ویژگی **`GapWidth`** به این شکل تنظیم کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
1. اولین اسلاید را دسترسی پیدا کنید.  
1. نمودار با داده‌های پیش‌فرض اضافه کنید.  
1. به هر سری نمودار دسترسی پیدا کنید.  
1. ویژگی `GapWidth` را تنظیم کنید.  
1. ارائهٔ اصلاح‌شده را در یک فایل PPTX بنویسید.

این کد جاوا نشان می‌دهد چگونه عرض فاصله بین سری‌ها را تنظیم کنید:

```java
// یک ارائه خالی ایجاد می‌کند 
Presentation pres = new Presentation();
try {
    // به اسلاید اول ارائه دسترسی پیدا می‌کند
    ISlide slide = pres.getSlides().get_Item(0);
    
    // یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // ایندکس شیت داده‌های نمودار را تنظیم می‌کند
    int defaultWorksheetIndex = 0;
    
    // شیت داده‌های نمودار را دریافت می‌کند
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // سری‌ها را اضافه می‌کند
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // دسته‌بندی‌ها را اضافه می‌کند
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // سری دوم نمودار را می‌گیرد
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // داده‌های سری را پر می‌کند
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // مقدار GapWidth را تنظیم می‌کند
    series.getParentSeriesGroup().setGapWidth(50);
    
    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا محدودیتی برای تعداد سری‌هایی که یک نمودار می‌تواند داشته باشد وجود دارد؟**

Aspose.Slides محدودیت ثابت خاصی برای تعداد سری‌های اضافه‌شده اعمال نمی‌کند. سقف عملی توسط قابلیت خواندن نمودار و حافظه موجود برای برنامه شما تعیین می‌شود.

**اگر ستون‌های داخل یک خوشه خیلی نزدیک یا خیلی دور از هم باشند چه کاری باید انجام داد؟**

تنظیم `GapWidth` برای آن سری (یا گروه سری والد آن) را تغییر دهید. افزایش مقدار، فضای بین ستون‌ها را widen می‌کند، در حالی که کاهش مقدار آن‌ها را به‑یکدیگر نزدیک می‌کند.