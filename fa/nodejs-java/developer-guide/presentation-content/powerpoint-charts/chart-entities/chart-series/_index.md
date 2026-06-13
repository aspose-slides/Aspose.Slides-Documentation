---
title: مدیریت سری‌های داده نمودار در ارائه‌ها با استفاده از جاوا اسکریپت
linktitle: سری‌های داده
type: docs
url: /fa/nodejs-java/chart-series/
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
- Node.js
- جاوا اسکریپت
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار را در جاوا اسکریپت برای پاورپوینت (PPT/PPTX) مدیریت کنید با مثال‌های کد عملی و بهترین روش‌ها برای ارتقای ارائه‌های داده‌ای خود."
---
## **مرور کلی**

این مقاله نقش [ChartSeries](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/) را در Aspose.Slides توضیح می‌دهد و بر نحوه ساختاردهی و نمایش داده‌ها در ارائه‌ها تمرکز می‌کند. این اشیا عناصر پایه‌ای را فراهم می‌کنند که مجموعه‌های جداگانه‌ای از نقاط داده، دسته‌ها و پارامترهای ظاهر در یک نمودار را تعریف می‌کند. با کار با [ChartSeries](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/)، توسعه‌دهندگان می‌توانند به راحتی منابع داده زیرین را یکپارچه کرده و کنترل کامل بر نحوه نمایش اطلاعات داشته باشند و در نتیجه ارائه‌های پویا و داده‌محوری تولید کنند که بینش و تحلیل را به وضوح منتقل می‌کند.

یک سری ردیف یا ستونی از اعداد است که در نمودار رسم می‌شود.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری‌های نمودار**

با متد [ChartSeries.getOverlap](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getOverlap) می‌توانید میزان همپوشانی میله‌ها و ستون‌ها را در یک نمودار دو بعدی مشخص کنید (محدوده: -100 تا 100). این ویژگی برای تمام سری‌های گروه سری مادر اعمال می‌شود: این یک پروژکشن از ویژگی گروه مناسب است. بنابراین این ویژگی فقط‑خواندنی است.

از ویژگی `ParentSeriesGroup.getOverlap` که قابلیت خواندن/نوشتن دارد برای تنظیم مقدار دلخواه `Overlap` استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. یک نمودار ستونی خوشه‌ای بر روی یک اسلاید اضافه کنید.  
3. به اولین سری نمودار دسترسی پیدا کنید.  
4. `ParentSeriesGroup` سری نمودار را دسترسی یافته و مقدار همپوشانی دلخواه خود را برای سری تنظیم کنید.  
5. ارائه اصلاح‌شده را به یک فایل PPTX بنویسید.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // اضافه کردن نمودار
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // تنظیم همپوشانی سری
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // نوشتن فایل ارائه بر روی دیسک
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تغییر رنگ سری**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد رنگ یک سری را به این شکل تغییر دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. بر روی اسلاید یک نمودار اضافه کنید.  
3. به سری‌ای که می‌خواهید رنگ آن را تغییر دهید دسترسی پیدا کنید.  
4. نوع پر کردن و رنگ پر کردن دلخواه را تنظیم کنید.  
5. ارائه اصلاح‌شده را ذخیره کنید.  

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تغییر رنگ دسته‌بندی سری**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد رنگ دسته‌بندی یک سری را به این شکل تغییر دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. بر روی اسلاید یک نمودار اضافه کنید.  
3. به دسته‌بندی سری که می‌خواهید رنگ آن را تغییر دهید دسترسی پیدا کنید.  
4. نوع پر کردن و رنگ پر کردن دلخواه را تنظیم کنید.  
5. ارائه اصلاح‌شده را ذخیره کنید.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تغییر نام سری** 

به طور پیش‌فرض، نام‌های لگند برای یک نمودار محتوای سلول‌های بالای هر ستون یا ردیف داده هستند.

در مثال ما (تصویر نمونه)،  

* ستون‌ها *Series 1, Series 2,* و *Series 3* هستند؛  
* ردیف‌ها *Category 1, Category 2, Category 3,* و *Category 4.* هستند.  

Aspose.Slides for Node.js via Java به شما اجازه می‌دهد نام یک سری را در داده‌های نمودار و لگند آن به‌روزرسانی یا تغییر دهید.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم رنگ پر کردن سری نمودار**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد رنگ پر کردن خودکار برای سری‌های نمودار داخل ناحیه رسم را به این شکل تنظیم کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را بر اساس اندیس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض بر اساس نوع دلخواه خود اضافه کنید (در مثال زیر از `ChartType.ClusteredColumn` استفاده کردیم).  
4. به سری نمودار دسترسی پیدا کنید و رنگ پر کردن را به Automatic تنظیم کنید.  
5. ارائه را به یک فایل PPTX ذخیره کنید.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // یک نمودار ستونی خوشه‌ای ایجاد می‌کند
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // قالب پر کردن سری را به حالت خودکار تنظیم می‌کند
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // فایل ارائه را بر روی دیسک می‌نویسد
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم رنگ پر کردن معکوس برای سری نمودار**

Aspose.Slides به شما امکان می‌دهد رنگ پر کردن معکوس برای سری‌های نمودار داخل ناحیه رسم را به این شکل تنظیم کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را بر اساس اندیس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض بر اساس نوع دلخواه خود اضافه کنید (در مثال زیر از `ChartType.ClusteredColumn` استفاده کردیم).  
4. به سری نمودار دسترسی پیدا کنید و رنگ پر کردن را به invert تنظیم کنید.  
5. ارائه را به یک فایل PPTX ذخیره کنید.  

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // افزودن سری‌ها و دسته‌ها
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // دریافت اولین سری نمودار و تکمیل داده‌های سری
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم معکوس شدن سری زمانی که مقدار منفی باشد**

Aspose.Slides به شما اجازه می‌دهد با استفاده از متد `ChartDataPoint.setInvertIfNegative` معکوس شدن را تنظیم کنید. وقتی معکوس از طریق این ویژگی‌ها تنظیم شود، نقطه داده رنگ‌های خود را هنگام دریافت مقدار منفی معکوس می‌کند.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **پاک‌سازی داده‌های نقاط داده خاص**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد داده‌های `DataPoints` برای یک سری نمودار خاص را به این شکل پاک کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.  
3. مرجع یک نمودار را از طریق اندیس آن دریافت کنید.  
4. بر تمام `DataPoints` نمودار پیمایش کنید و `XValue` و `YValue` را به null تنظیم کنید.  
5. تمام `DataPoints` برای سری نمودار خاص را پاک کنید.  
6. ارائه اصلاح‌شده را به یک فایل PPTX بنویسید.  

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم عرض فاصله سری**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد عرض فاصله یک سری را از طریق ویژگی **`GapWidth`** به این شکل تنظیم کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. به اسلاید اول دسترسی پیدا کنید.  
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید.  
4. به هر سری نمودار دسترسی پیدا کنید.  
5. ویژگی `GapWidth` را تنظیم کنید.  
6. ارائه اصلاح‌شده را به یک فایل PPTX بنویسید.  

```javascript
// ایجاد ارائه خالی
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اولین اسلاید ارائه
    var slide = pres.getSlides().get_Item(0);
    // افزودن نمودار با داده‌های پیش‌فرض
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // تنظیم اندیس شیت داده‌های نمودار
    var defaultWorksheetIndex = 0;
    // دریافت ورک‌شیت داده‌های نمودار
    var fact = chart.getChartData().getChartDataWorkbook();
    // افزودن سری‌ها
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // افزودن دسته‌ها
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // دریافت دومین سری نمودار
    var series = chart.getChartData().getSeries().get_Item(1);
    // پر کردن داده‌های سری
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // تنظیم مقدار GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    // ذخیرهٔ ارائه بر روی دیسک
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**آیا محدودیتی برای تعداد سری‌های یک نمودار واحد وجود دارد؟**

Aspose.Slides هیچ سقف ثابت برای تعداد سری‌هایی که اضافه می‌کنید وضع نمی‌کند. محدودیت عملی بر اساس قابلیت خوانایی نمودار و حافظه در دسترس برنامه شما تعیین می‌شود.

**اگر ستون‌های داخل یک خوشه بیش از حد نزدیک یا دور باشند چه می‌شود؟**

تنظیم ویژگی Gap Width برای آن سری (یا گروه سری مادر) را تغییر دهید. افزایش مقدار فضا بین ستون‌ها را گسترده‌تر می‌کند، در حالی که کاهش آن ستون‌ها را به هم نزدیک‌تر می‌کند.