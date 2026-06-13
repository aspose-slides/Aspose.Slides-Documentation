---
title: مدیریت سری‌های داده نمودار در ارائه‌ها با استفاده از جاوا
linktitle: سری‌های داده
type: docs
url: /fa/java/chart-series/
keywords:
- سری‌های نمودار
- همپوشانی سری
- رنگ سری
- رنگ دسته‌بندی
- نام سری
- نقطه داده
- فاصله سری
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار را در جاوا برای پاورپوینت (PPT/PPTX) مدیریت کنید، با مثال‌های کد عملی و بهترین روش‌ها برای ارتقاء ارائه‌های داده‌ای خود."
---
## **بررسی کلی**

این مقاله نقش [ChartSeries](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartseries/) را در Aspose.Slides توصیف می‌کند و بر نحوه ساختاردهی و بصری‌سازی داده‌ها در ارائه‌ها متمرکز است. این اشیاء عناصر بنیادی را فراهم می‌کنند که مجموعه‌های فردی نقاط داده، دسته‌ها و پارامترهای ظاهر را در یک نمودار تعریف می‌کنند. با کار با [ChartSeries](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartseries/)، توسعه‌دهندگان می‌توانند به‌صورت یکپارچه منابع داده زیرین را ادغام کرده و کنترل کامل بر نحوه نمایش اطلاعات داشته باشند و در نتیجه ارائه‌های پویا و مبتنی بر داده ایجاد کنند که به وضوح بینش‌ها و تحلیل‌ها را منتقل می‌کنند.

یک سری ردیف یا ستونی از اعداد است که در یک نمودار ترسیم می‌شود.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری نمودار**

با ویژگی [IChartSeriesOverlap](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/properties/overlap) می‌توانید مقدار همپوشانی نوارها و ستون‌ها در یک نمودار دو‑بعدی را تعیین کنید (محدوده: -100 تا 100). این ویژگی برای تمام سری‌های گروه سری والد اعمال می‌شود: این یک پروجکشن از ویژگی مناسب گروه است. بنابراین، این ویژگی فقط‑خواندنی است.

از ویژگی `ParentSeriesGroup.Overlap` با قابلیت خواندن/نوشتن برای تنظیم مقدار دلخواه خود برای `Overlap` استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
1. یک نمودار ستونی کلاستری را به یک اسلاید اضافه کنید.  
1. به اولین سری نمودار دسترسی پیدا کنید.  
1. به ویژگی `ParentSeriesGroup` سری نمودار دسترسی پیدا کنید و مقدار همپوشانی دلخواه خود را برای سری تنظیم کنید.  
1. ارائه اصلاح‌شده را به یک فایل PPTX ذخیره کنید.

این کد جاوا نشان می‌دهد چگونه همپوشانی یک سری نمودار را تنظیم کنید:

```java
Presentation pres = new Presentation();
try {
    // نمودار را اضافه می‌کند
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // همپوشانی سری را تنظیم می‌کند
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // فایل ارائه را روی دیسک می‌نویسد
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغییر رنگ سری**

Aspose.Slides برای جاوا به شما امکان می‌دهد رنگ یک سری را به این شکل تغییر دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
1. یک نمودار را به اسلاید اضافه کنید.  
1. سری‌ای که می‌خواهید رنگ آن را تغییر دهید، دسترسی پیدا کنید.  
1. نوع پرکننده و رنگ دلخواه خود را تنظیم کنید.  
1. ارائه اصلاح‌شده را ذخیره کنید.

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

Aspose.Slides برای جاوا به شما امکان می‌دهد رنگ دسته‌بندی یک سری را به این شکل تغییر دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
1. یک نمودار را به اسلاید اضافه کنید.  
1. دسته‌بندی سری‌ای که می‌خواهید رنگ آن را تغییر دهید، دسترسی پیدا کنید.  
1. نوع پرکننده و رنگ دلخواه خود را تنظیم کنید.  
1. ارائه اصلاح‌شده را ذخیره کنید.

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

به‌طور پیش‌فرض، نام‌های راهنما برای یک نمودار محتوای سلول‌های بالای هر ستون یا ردیف داده هستند.

در مثال ما (تصویر نمونه)،  

* ستون‌ها *Series 1, Series 2,* و *Series 3*؛  
* ردیف‌ها *Category 1, Category 2, Category 3,* و *Category 4* هستند.

Aspose.Slides برای جاوا به شما امکان می‌دهد نام یک سری را در داده‌های نمودار و راهنما به‌روزرسانی یا تغییر دهید.

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

این کد جاوا نشان می‌دهد چگونه نام یک سری را از طریق `Series` در راهنما تغییر دهید:

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

## **تنظیم رنگ پرکننده خودکار برای سری نمودار**

Aspose.Slides برای جاوا به شما امکان می‌دهد رنگ پرکننده خودکار برای سری‌های نمودار داخل ناحیه رسم را به این شکل تنظیم کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
1. مرجع یک اسلاید را با استفاده از شاخص آن به دست آورید.  
1. یک نمودار با داده‌های پیش‌فرض بر اساس نوع دلخواه خود اضافه کنید (در مثال زیر از `ChartType.ClusteredColumn` استفاده کردیم).  
1. به سری نمودار دسترسی پیدا کنید و رنگ پرکننده را به Automatic تنظیم کنید.  
1. ارائه را به یک فایل PPTX ذخیره کنید.

این کد جاوا نشان می‌دهد چگونه رنگ پرکننده خودکار برای یک سری نمودار تنظیم شود:

```java
Presentation pres = new Presentation();
try {
    // یک نمودار ستونی کلاستر شده ایجاد می‌کند
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

## **تنظیم رنگ پرکننده معکوس برای یک سری نمودار**

Aspose.Slides به شما امکان می‌دهد رنگ پرکننده معکوس برای سری‌های نمودار داخل ناحیه رسم را به این شکل تنظیم کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
1. مرجع یک اسلاید را با استفاده از شاخص آن به دست آورید.  
1. یک نمودار با داده‌های پیش‌فرض بر اساس نوع دلخواه خود اضافه کنید (در مثال زیر از `ChartType.ClusteredColumn` استفاده کردیم).  
1. به سری نمودار دسترسی پیدا کنید و رنگ پرکننده را به Invert تنظیم کنید.  
1. ارائه را به یک فایل PPTX ذخیره کنید.

این کد جاوا عملیات را نشان می‌دهد:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // سری‌ها و دسته‌های جدید را اضافه می‌کند
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // اولین سری نمودار را می‌گیرد و داده‌های سری آن را پر می‌کند.
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

## **تنظیم معکوس شدن سری هنگام مقدار منفی**

Aspose.Slides به شما امکان می‌دهد معکوس شدن را از طریق ویژگی‌های `IChartDataPoint.InvertIfNegative` و `ChartDataPoint.InvertIfNegative` تنظیم کنید. وقتی معکوس شدن با این ویژگی‌ها تنظیم شود، نقطه داده رنگ‌های خود را هنگام دریافت مقدار منفی معکوس می‌کند.

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

## **پاک کردن داده‌های نقطه خاص**

Aspose.Slides برای جاوا به شما امکان می‌دهد داده‌های `DataPoints` یک سری نمودار خاص را به این شکل پاک کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن به دست آورید.  
3. مرجع یک نمودار را از طریق شاخص آن به دست آورید.  
4. بر تمام `DataPoints` نمودار مرور کنید و `XValue` و `YValue` را به null تنظیم کنید.  
5. تمام `DataPoints` برای سری نمودار خاص را پاک کنید.  
6. ارائه اصلاح‌شده را به یک فایل PPTX ذخیره کنید.

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

## **تنظیم عرض فاصله بین سری‌ها**

Aspose.Slides برای جاوا به شما امکان می‌دهد عرض فاصله (`GapWidth`) یک سری را از طریق ویژگی **`GapWidth`** به این شکل تنظیم کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
1. به اولین اسلاید دسترسی پیدا کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید.  
1. به هر سری نمودار دسترسی پیدا کنید.  
1. ویژگی `GapWidth` را تنظیم کنید.  
1. ارائه اصلاح‌شده را به یک فایل PPTX ذخیره کنید.

این کد جاوا نشان می‌دهد چگونه عرض فاصله یک سری تنظیم شود:

```java
// یک ارائه خالی ایجاد می‌کند 
Presentation pres = new Presentation();
try {
    // به اسلاید اول ارائه دسترسی می‌یابد
    ISlide slide = pres.getSlides().get_Item(0);
    
    // یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // اندیس شیت داده‌های نمودار را تنظیم می‌کند
    int defaultWorksheetIndex = 0;
    
    // برگه کاری داده‌های نمودار را دریافت می‌کند
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // سری‌ها را اضافه می‌کند
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // دسته‌ها را اضافه می‌کند
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

## **سؤالات متداول**

**آیا محدودیتی برای تعداد سری‌هایی که یک نمودار می‌تواند داشته باشد وجود دارد؟**

Aspose.Slides محدودیتی ثابت برای تعداد سری‌هایی که اضافه می‌کنید اعمال نمی‌کند. سقف عملی توسط قابلیت خوانایی نمودار و حافظه موجود برای برنامه شما تعیین می‌شود.

**اگر ستون‌های داخل یک خوشه بیش از حد نزدیک یا بیش از حد دور باشند چه کار باید کرد؟**

تنظیم ویژگی `GapWidth` برای آن سری (یا گروه سری والد) را انجام دهید. افزایش مقدار، فضای بین ستون‌ها را عریض‌تر می‌کند، در حالی که کاهش مقدار، آن‌ها را نزدیک‌تر می‌سازد.