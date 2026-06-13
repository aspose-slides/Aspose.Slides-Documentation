---
title: "سفارشی‌سازی نمودارهای سه‌بعدی در ارائه‌ها در اندروید"
linktitle: "نمودار سه‌بعدی"
type: docs
url: /fa/androidjava/3d-chart/
keywords:
- "نمودار سه‌بعدی"
- "چرخش"
- "عمق"
- "پاورپوینت"
- "ارائه"
- "اندروید"
- "جاوا"
- "Aspose.Slides"
description: "یاد بگیرید چگونه نمودارهای سه‌بعدی را در Aspose.Slides برای اندروید از طریق جاوا ایجاد و سفارشی کنید، با پشتیبانی از فایل‌های PPT و PPTX—امروز ارائه‌های خود را ارتقا دهید."
---
## **Overview**

این مقاله توضیح می‌دهد چگونه یک نمودار سه‌بعدی در Aspose.Slides را با پیکربندی تنظیمات `Rotation3D` مانند `RotationX`، `RotationY`، `DepthPercents` و `RightAngleAxes` سفارشی کنیم. مراحل ایجاد یک ارائه، افزودن یک نمودار سه‌بعدی با داده‌های پیش‌فرض، اعمال تنظیمات نمای سه‌بعدی مورد نیاز و ذخیره ارائه تغییر یافته به عنوان فایل PPTX را قدم به قدم نشان می‌دهد.

## **Set RotationX, RotationY and DepthPercents Properties of a 3D Chart**
Aspose.Slides for Android via Java یک API ساده برای تنظیم این خواص فراهم می‌کند. این مقاله به شما کمک می‌کند تا خواص مختلفی مانند **X,Y Rotation, DepthPercents** و غیره را تنظیم کنید. کد نمونه تنظیم خواص ذکر شده در بالا را اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. نمودار را با داده‌های پیش‌فرض اضافه کنید.
1. خواص Rotation3D را تنظیم کنید.
1. ارائهٔ تغییر یافته را در یک فایل PPTX بنویسید.

```java
Presentation pres = new Presentation();
try {
    // دسترسی به اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // افزودن نمودار با داده‌های پیش‌فرض
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // تنظیم شاخص صفحه داده‌های نمودار
    int defaultWorksheetIndex = 0;
    
    // دریافت برگه کاری داده‌های نمودار
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // افزودن سری
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // افزودن دسته‌بندی‌ها
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // تنظیم خواص Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // دریافت سری دوم نمودار
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // در حال پر کردن داده‌های سری
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // تنظیم مقدار OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // نوشتن ارائه روی دیسک
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Which chart types support 3D mode in Aspose.Slides?**

Aspose.Slides انواع سه‌بعدی نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D، به‌همراه انواع سه‌بعدی مرتبط که از طریق کلاس [ChartType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/charttype/) در دسترس هستند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/charttype/) را در مرجع API نسخهٔ نصب شدهٔ خود بررسی کنید.

**Can I get a raster image of a 3D chart for a report or the web?**

بله. می‌توانید یک نمودار را از طریق [chart API](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) به تصویر تبدیل کنید یا کل اسلاید را به قالب‌هایی مانند PNG یا JPEG رندر کنید [/slides/fa/androidjava/convert-powerpoint-to-png/]. این کار برای دریافت پیش‌نمایش پیکسلی دقیق یا درج نمودار در اسناد، داشبوردها یا صفحات وب بدون نیاز به PowerPoint مفید است.

**How performant is building and rendering large 3D charts?**

عملکرد به حجم داده‌ها و پیچیدگی بصری بستگی دارد. برای بهترین نتایج، اثرات سه‌بعدی را به حداقل برسانید، از بافت‌های سنگین روی دیوارها و نواحی نمودار پرهیز کنید، در صورت امکان تعداد نقاط داده در هر سری را محدود کنید و به‌صورت خروجی با اندازهٔ مناسب (وضوح و ابعاد) رندر کنید تا با نمایشگر یا نیازهای چاپ مطابقت داشته باشد.