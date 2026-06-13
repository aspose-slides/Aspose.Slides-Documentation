---
title: سفارشی‌سازی نمودارهای دایره‌ای در پرزنتیشن‌ها با استفاده از جاوا
linktitle: نمودار دایره‌ای
type: docs
url: /fa/java/pie-chart/
keywords:
- نمودار دایره‌ای
- مدیریت نمودار
- سفارشی‌سازی نمودار
- گزینه‌های نمودار
- تنظیمات نمودار
- گزینه‌های ترسیم
- رنگ برش
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارهای دایره‌ای را در جاوا با Aspose.Slides ایجاد و سفارشی‌سازی کنید، قابل صادرات به PowerPoint، و روایت داده‌های خود را در چند ثانیه تقویت کنید."
---
## **Overview**

این مقاله توضیح می‌دهد چگونه با نمودارهای دایره‌ای در Aspose.Slides کار کنید. این مقاله نحوه پیکربندی گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie را نشان می‌دهد و همچنین چگونگی فعال‌سازی رنگ‌آمیزی خودکار برش‌های یک نمودار دایره‌ای استاندارد را بررسی می‌کند.

مثال‌ها بر روی مراحل عملی سفارشی‌سازی نمودار متمرکز هستند؛ از افزودن نمودار به یک اسلاید، تنظیم سری و برچسب‌ها، جایگزینی داده‌های پیش‌فرض نمودار با دسته‌ها و مقادیر سفارشی، تا ذخیره ارائه به‌روز شده.

## **Second Plot Options for Pie of Pie and Bar of Pie Charts**
Aspose.Slides for Java اکنون از گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie یا Bar of Pie پشتیبانی می‌کند. در این بخش، نحوه تعیین این گزینه‌ها با استفاده از Aspose.Slides را نشان می‌دهیم. برای تعیین خصوصیات، مراحل زیر را دنبال کنید:

1. نمونه‌سازی کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation).
1. افزودن نمودار به اسلاید.
1. تعیین گزینه‌های نمودار ثانویه.
1. نوشتن ارائه به دیسک.

در مثال زیر، خصوصیات مختلف نمودار Pie of Pie را تنظیم کرده‌ایم.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    // نمودار را به اسلاید اضافه کنید
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // تنظیم ویژگی‌های مختلف
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // ارائه را بر روی دیسک ذخیره کنید
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Automatic Pie Chart Slice Colors**
Aspose.Slides for Java یک API ساده برای تنظیم خودکار رنگ برش‌های نمودار دایره‌ای ارائه می‌دهد. کد نمونه تنظیمات مذکور را اعمال می‌کند.

1. ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation).
1. دسترسی به اولین اسلاید.
1. افزودن نمودار با داده‌های پیش‌فرض.
1. تنظیم عنوان نمودار.
1. تنظیم اولین سری برای نمایش مقادیر.
1. تعیین اندیس برگه داده‌های نمودار.
1. دریافت برگه کاری داده‌های نمودار.
1. حذف سری‌ها و دسته‌های پیش‌فرض تولید شده.
1. افزودن دسته‌های جدید.
1. افزودن سری جدید.

نوشتهٔ ارائه اصلاح‌شده را به فایل PPTX ذخیره کنید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    // نمودار را با داده‌های پیش‌فرض اضافه کنید
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // تنظیم عنوان نمودار
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // اولین سری را برای نمایش مقادیر تنظیم کنید
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // تنظیم ایندکس برگه داده‌های نمودار
    int defaultWorksheetIndex = 0;

    // دریافت برگه کاری داده‌های نمودار
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // حذف سری‌ها و دسته‌های پیش‌فرض تولید شده
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // افزودن دسته‌های جدید
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // افزودن سری جدید
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // اکنون داده‌های سری را پر می‌کنیم
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**آیا انواع 'Pie of Pie' و 'Bar of Pie' پشتیبانی می‌شوند؟**

بله، کتابخانه [پشتیبانی می‌کند](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/) از نمودار ثانویه برای نمودارهای دایره‌ای، شامل انواع 'Pie of Pie' و 'Bar of Pie'.

**آیا می‌توانم تنها نمودار را به عنوان تصویر (مثلاً PNG) خروجی بگیرم؟**

بله، می‌توانید [نمودار را به عنوان تصویر خروجی بگیرید](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getImage-int-float-float-) (مانند PNG) بدون ذخیره کل ارائه.