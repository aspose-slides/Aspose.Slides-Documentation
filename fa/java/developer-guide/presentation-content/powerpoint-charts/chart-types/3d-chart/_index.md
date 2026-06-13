---
title: سفارشی‌سازی نمودارهای سه‌بعدی در ارائه‌ها با جاوا
linktitle: نمودار سه‌بعدی
type: docs
url: /fa/java/3d-chart/
keywords:
- نمودار سه‌بعدی
- چرخش
- عمق
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارهای 3‑بعدی را در Aspose.Slides برای جاوا ایجاد و سفارشی کنید، با پشتیبانی از فایل‌های PPT و PPTX — امروز ارائه‌های خود را ارتقا دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه نمودار سه‌بعدی را در Aspose.Slides با پیکربندی تنظیمات `Rotation3D` مانند `RotationX`، `RotationY`، `DepthPercents` و `RightAngleAxes` سفارشی‌سازی کنیم. این راهنما ایجاد یک ارائه، افزودن نمودار سه‌بعدی با داده‌های پیش‌فرض، اعمال تنظیمات نمای سه‌بعدی مورد نیاز و ذخیره ارائه تغییر یافته به‌عنوان فایل PPTX را قدم‌به‑قدم نشان می‌دهد.

## **تنظیم ویژگی‌های RotationX، RotationY و DepthPercents یک نمودار سه‌بعدی**

Aspose.Slides برای Java یک API ساده برای تنظیم این ویژگی‌ها فراهم می‌کند. مقاله زیر به شما کمک می‌کند تا ویژگی‌های مختلفی مانند **X,Y Rotation, DepthPercents** و غیره را تنظیم کنید. کد نمونه تنظیم ویژگی‌های مذکور را اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.  
2. اولین اسلاید را دریافت کنید.  
3. نمودار را با داده‌های پیش‌فرض اضافه کنید.  
4. ویژگی‌های Rotation3D را تنظیم کنید.  
5. ارائه تغییر یافته را به یک فایل PPTX بنویسید.

```java
Presentation pres = new Presentation();
try {
    // دسترسی به اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // افزودن نمودار با داده‌های پیش‌فرض
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // تنظیم ایندکس شیت داده‌های نمودار
    int defaultWorksheetIndex = 0;
    
    // دریافت کاربرگ داده‌های نمودار
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // افزودن سری‌ها
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // افزودن دسته‌ها
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // تنظیم ویژگی‌های Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // دریافت سری دوم نمودار
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // اکنون پر کردن داده‌های سری
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // تنظیم مقدار OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // نوشتن ارائه بر روی دیسک
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**کدام انواع نمودارها از حالت سه‌بعدی در Aspose.Slides پشتیبانی می‌کنند؟**

Aspose.Slides انواع سه‌بعدی نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D، به همراه انواع سه‌بعدی مرتبط که از طریق کلاس [ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/) در دسترس هستند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/) را در مرجع API نسخه نصب شده خود بررسی کنید.

**آیا می‌توانم تصویر رستری از یک نمودار سه‌بعدی برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید یک نمودار را از طریق [chart API](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getImage-int-float-float-) به تصویر صادر کنید یا کل اسلاید را به فرمت‌هایی مانند PNG یا JPEG با استفاده از [render the entire slide](/slides/fa/java/convert-powerpoint-to-png/) تبدیل کنید. این کار زمانی مفید است که به پیش‌نمایش پیکسل‑محور نیاز داشته باشید یا می‌خواهید نمودار را بدون نیاز به PowerPoint در اسناد، داشبوردها یا صفحات وب جاسازی کنید.

**عملکرد ساخت و رندر نمودارهای بزرگ سه‌بعدی چقدر است؟**

عملکرد به حجم داده‌ها و پیچیدگی بصری بستگی دارد. برای بهترین نتایج، اثرات سه‌بعدی را به‌حداقل برسانید، از استفاده از بافت‌های سنگین روی دیوارها و نواحی نمودار خودداری کنید، در صورت امکان تعداد نقاط داده در هر سری را محدود کنید و خروجی را با ابعاد و وضوح مناسب برای نمایش یا چاپ هدف رندر کنید.