---
title: سفارشی‌سازی نمودارهای 3بعدی در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: نمودار 3بعدی
type: docs
url: /fa/nodejs-java/3d-chart/
keywords:
- نمودار 3بعدی
- چرخش
- عمق
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارهای 3بعدی را در Aspose.Slides برای Node.js از طریق Java ایجاد و سفارشی کنید، با پشتیبانی از فایل‌های PPT و PPTX—امروزه ارائه‌های خود را بهبود دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه یک نمودار 3بعدی در Aspose.Slides را با تنظیم ویژگی‌های `Rotation3D` مانند `RotationX`، `RotationY`، `DepthPercents` و `RightAngleAxes` سفارشی کنید. مراحل ایجاد یک ارائه، افزودن نمودار 3بعدی با داده‌های پیش‌فرض، اعمال تنظیمات نمای 3بعدی مورد نیاز و ذخیره ارائه اصلاح‌شده به صورت فایل PPTX بیان می‌شود.

## **تنظیم خصوصیات RotationX، RotationY و DepthPercents نمودار 3بعدی**

Aspose.Slides for Node.js via Java یک API ساده برای تنظیم این خصوصیات فراهم می‌کند. مقاله زیر به شما کمک می‌کند تا خصوصیات مختلفی مانند **X,Y Rotation، DepthPercents** و غیره را تنظیم کنید. کد نمونه تنظیم خصوصیات ذکر شده را اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بسازید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. نموداری با داده‌های پیش‌فرض اضافه کنید.
1. خصوصیات Rotation3D را تنظیم کنید.
1. ارائه اصلاح‌شده را به یک فایل PPTX بنویسید.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اولین اسلاید
    var slide = pres.getSlides().get_Item(0);
    // افزودن نمودار با داده‌های پیش‌فرض
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
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
    // تنظیم ویژگی‌های Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // دریافت سری دوم نمودار
    var series = chart.getChartData().getSeries().get_Item(1);
    // اکنون داده‌های سری را پر می‌کنیم
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // تنظیم مقدار OverLap
    series.getParentSeriesGroup().setOverlap(100);
    // نوشتن ارائه بر روی دیسک
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**کدام انواع نمودار در Aspose.Slides حالت 3بعدی را پشتیبانی می‌کنند؟**

Aspose.Slides انواع 3بعدی نمودارهای ستونی شامل Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D را به‌همراه انواع 3بعدی مرتبط که از طریق enumeration [ChartType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/) قابل دسترسی هستند، پشتیبانی می‌کند. برای فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/) را در مرجع API نسخه نصب‌شده خود بررسی کنید.

**آیا می‌توانم تصویر رستر از یک نمودار 3بعدی برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید یک نمودار را از طریق [chart API](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getImage) به تصویر صادر کنید یا کل اسلاید را به فرمت‌هایی مانند PNG یا JPEG رندر کنید [/slides/fa/nodejs-java/convert-powerpoint-to-png/]. این روش برای پیش‌نمایش دقیق پیکسل یا قراردادن نمودار در اسناد، داشبوردها یا صفحات وب بدون نیاز به PowerPoint مفید است.

**کارایی ساخت و رندر نمودارهای بزرگ 3بعدی چقدر است؟**

کارایی به حجم داده‌ها و پیچیدگی بصری بستگی دارد. برای دریافت نتایج بهینه، اثرات 3بعدی را به حداقل برسانید، از بافت‌های سنگین در دیوارها و نواحی نمودار خودداری کنید، تعداد نقاط داده در هر سری را در صورت امکان محدود کنید و خروجی را با اندازه (وضوح و ابعاد) مناسب برای نمایش یا چاپ هدف رندر کنید.