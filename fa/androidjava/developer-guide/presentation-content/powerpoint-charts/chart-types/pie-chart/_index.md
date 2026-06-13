---
title: سفارشی‌سازی نمودارهای دایره‌ای در ارائه‌ها بر روی اندروید
linktitle: نمودار دایره‌ای
type: docs
url: /fa/androidjava/pie-chart/
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
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارهای دایره‌ای را در جاوا با Aspose.Slides برای اندروید ایجاد و سفارشی‌سازی کنید، به‌صورت قابل‌صادرات به PowerPoint، و در ثانیه‌ها داستان‌سرایی داده‌های خود را تقویت کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با نمودارهای دایره‌ای در Aspose.Slides کار کنیم. همچنین نشان می‌دهد چگونه گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie را پیکربندی کنیم و چگونه رنگ‌آمیزی خودکار برش‌ها را برای یک نمودار دایره‌ای استاندارد فعال کنیم.

مثال‌ها بر روی مراحل عملی سفارشی‌سازی نمودار مانند افزودن یک نمودار به اسلاید، تنظیم سری‌ها و برچسب‌ها، جایگزینی داده‌های پیش‌فرض نمودار با دسته‌ها و مقادیر سفارشی، و ذخیره ارائه به‌روزرسانی‌شده تمرکز دارند.

## **گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie**

Aspose.Slides برای Android از طریق Java اکنون از گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie یا Bar of Pie پشتیبانی می‌کند. در این موضوع، نحوه تعیین این گزینه‌ها با استفاده از Aspose.Slides را نشان می‌دهیم. برای تعیین ویژگی‌ها، این کارها را انجام دهید:

1. یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) را ایجاد کنید.
1. نمودار را بر روی اسلاید اضافه کنید.
1. گزینه‌های نمودار ثانویه را مشخص کنید.
1. ارائه را در دیسک بنویسید.

در مثال زیر، ویژگی‌های مختلف نمودار Pie of Pie را تنظیم کرده‌ایم.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    // نمودار را بر روی اسلاید اضافه کنید
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // ویژگی‌های مختلف را تنظیم کنید
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // ارائه را روی دیسک ذخیره کنید
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم رنگ‌های خودکار برش‌های نمودار دایره‌ای**

Aspose.Slides برای Android از طریق Java یک API ساده برای تنظیم رنگ‌های خودکار برش‌های نمودار دایره‌ای فراهم می‌کند. کد نمونه تنظیم ویژگی‌های مذکور را اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. به اسلاید اول دسترسی پیدا کنید.
1. نمودار را با داده‌های پیش‌فرض اضافه کنید.
1. عنوان نمودار را تنظیم کنید.
1. سری اول را به حالت نمایش مقادیر (Show Values) تنظیم کنید.
1. شاخص صفحه داده نمودار را تنظیم کنید.
1. ورق داده‌های نمودار را دریافت کنید.
1. سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف کنید.
1. دسته‌های جدید اضافه کنید.
1. سری‌های جدید اضافه کنید.

ارائه تغییر یافته را در یک فایل PPTX بنویسید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    // افزودن نمودار با داده‌های پیش‌فرض
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // تنظیم عنوان نمودار
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // تنظیم سری اول برای نمایش مقادیر
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // تنظیم شاخص صفحه داده نمودار
    int defaultWorksheetIndex = 0;

    // دریافت ورق داده‌های نمودار
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

    // حالا پر کردن داده‌های سری
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**آیا انواع 'Pie of Pie' و 'Bar of Pie' پشتیبانی می‌شوند؟**

بله، کتابخانه [پشتیبانی می‌کند](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/charttype/) از یک نمودار ثانویه برای نمودارهای دایره‌ای، از جمله انواع 'Pie of Pie' و 'Bar of Pie'.

**آیا می‌توانم فقط نمودار را به عنوان یک تصویر (مثلاً PNG) صادر کنم؟**

بله، می‌توانید [نمودار را به‌تنهایی به عنوان تصویر صادر کنید](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) (مانند PNG) بدون کل ارائه.