---
title: سفارشی‌سازی نمودارهای دایره‌ای در ارائه‌ها با استفاده از JavaScript
linktitle: نمودار دایره‌ای
type: docs
url: /fa/nodejs-java/pie-chart/
keywords:
- نمودار دایره‌ای
- مدیریت نمودار
- سفارشی‌سازی نمودار
- گزینه‌های نمودار
- تنظیمات نمودار
- گزینه‌های طرح
- رنگ برش
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارهای دایره‌ای را با JavaScript و Aspose.Slides برای Node.js ایجاد و سفارشی کنید، به‌صورت قابل استخراج به PowerPoint، و در چنده ثانیه داستان‌گویی داده‌های خود را ارتقا دهید."
---
## **مرور کلی**

این مقاله نحوه کار با نمودارهای دایره‌ای در Aspose.Slides را توضیح می‌دهد. در آن نشان داده می‌شود چگونه گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie را پیکربندی کنید و چگونه رنگ‌گذاری خودکار برش‌ها را برای یک نمودار دایره‌ای استاندارد فعال کنید.

مثال‌ها بر روی گام‌های عملی سفارشی‌سازی نمودار تمرکز دارند، مانند اضافه کردن نمودار به یک اسلاید، تنظیم سری‌ها و برچسب‌ها، جایگزینی داده‌های پیش‌فرض نمودار با دسته‌ها و مقادیر سفارشی، و ذخیره ارائه بروز شده.

## **گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie**
Aspose.Slides for Node.js via Java اکنون از گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie یا Bar of Pie پشتیبانی می‌کند. در این بخش نشان می‌دهیم چگونه این گزینه‌ها را با استفاده از Aspose.Slides مشخص کنید. برای تعیین ویژگی‌ها، مراحل زیر را انجام دهید:

1. نمونه‌ای از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
1. نمودار را به اسلاید اضافه کنید.
1. گزینه‌های نمودار ثانویه را مشخص کنید.
1. ارائه را روی دیسک بنویسید.

در مثال زیر، ویژگی‌های مختلف نمودار Pie of Pie را تنظیم کرده‌ایم.

```javascript
// ایجاد یک نمونه از کلاس Presentation
var pres = new aspose.slides.Presentation();
try {
    // افزودن نمودار به اسلاید
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // تنظیم ویژگی‌های مختلف
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // نوشتن ارائه روی دیسک
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم خودکار رنگ‌های برش‌های نمودار دایره‌ای**
Aspose.Slides for Node.js via Java یک API ساده برای تنظیم خودکار رنگ‌های برش‌های نمودار دایره‌ای ارائه می‌دهد. کد نمونه تنظیم ویژگی‌های مذکور را اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. نمودار را با داده‌های پیش‌فرض اضافه کنید.
1. عنوان نمودار را تنظیم کنید.
1. سری اول را برای نمایش مقادیر تنظیم کنید.
1. اندیس صفحه‌کار داده‌های نمودار را تنظیم کنید.
1. دریافت صفحه‌کار داده‌های نمودار.
1. حذف سری‌ها و دسته‌های تولید شده پیش‌فرض.
1. دسته‌های جدید را اضافه کنید.
1. سری جدید اضافه کنید.

ارائه اصلاح‌شده را به یک فایل PPTX بنویسید.

```javascript
// یک نمونه از کلاس Presentation ایجاد کنید
var pres = new aspose.slides.Presentation();
try {
    // افزودن نمودار با داده‌های پیش‌فرض
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // تنظیم عنوان نمودار
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // تنظیم سری اول برای نمایش مقادیر
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // تنظیم اندیس صفحه‌کار داده‌های نمودار
    var defaultWorksheetIndex = 0;
    // دریافت صفحه‌کار داده‌های نمودار
    var fact = chart.getChartData().getChartDataWorkbook();
    // حذف سری‌ها و دسته‌های تولید شده پیش‌فرض
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // افزودن دسته‌های جدید
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // افزودن سری جدید
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // اکنون پر کردن داده‌های سری
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **پرسش‌های متداول**

**آیا انواع 'Pie of Pie' و 'Bar of Pie' پشتیبانی می‌شوند؟**

بله، کتابخانه [از](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/) نمودار ثانویه برای نمودارهای دایره‌ای، از جمله انواع 'Pie of Pie' و 'Bar of Pie' پشتیبانی می‌کند.

**آیا می‌توانم فقط نمودار را به عنوان تصویر (مثلاً PNG) استخراج کنم؟**

بله، می‌توانید [نمودار را به عنوان تصویر استخراج کنید](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getImage) (مانند PNG) بدون استخراج کل ارائه.