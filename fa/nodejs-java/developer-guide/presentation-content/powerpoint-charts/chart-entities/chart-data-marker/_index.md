---
title: مدیریت نشانگرهای داده نمودار در ارائه‌ها با استفاده از JavaScript
linktitle: نشانگر داده
type: docs
url: /fa/nodejs-java/chart-data-marker/
keywords:
- نمودار
- نقطه داده
- نشانگر
- گزینه‌های نشانگر
- اندازه نشانگر
- نوع پر‌کننده
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "آموزش نحوه سفارشی‌سازی نشانگرهای داده نمودار در Aspose.Slides برای Node.js، برای افزایش تاثیر ارائه در قالب‌های PPT و PPTX با مثال‌های واضح کد."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با نشانگرهای دادهٔ نمودار در Aspose.Slides کار کنیم. نشان می‌دهد چگونه یک نمودار ایجاد کنید، به یک سری و نقاط دادهٔ آن دسترسی داشته باشید، پرکردن تصویر را بر روی نشانگرها در سطح نقطهٔ داده اعمال کنید، اندازهٔ نشانگر را تنظیم کنید و ارائهٔ بروز شده را ذخیره کنید. همچنین ذکر می‌کند که اشکال استاندارد نشانگر از طریق شمارش `MarkerStyleType` در دسترس هستند و ظاهر نشانگر هنگام صادرات نمودارها به فرمت‌های رستر یا SVG حفظ می‌شود.

## **تنظیم گزینه‌های نشانگر نمودار**

نشانگرها می‌توانند بر روی نقاط دادهٔ نمودار در داخل سری‌های خاص تنظیم شوند. برای تنظیم گزینه‌های نشانگر نمودار، لطفاً مراحل زیر را دنبال کنید:

- یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
- ایجاد نمودار پیش‌فرض.
- تنظیم تصویر.
- دریافت اولین سری نمودار.
- اضافه‌کردن نقطهٔ دادهٔ جدید.
- نوشتن ارائه روی دیسک.

در مثال زیر، گزینه‌های نشانگر نمودار را در سطح نقاط داده تنظیم کرده‌ایم.

```javascript
// ایجاد ارائه خالی
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اسلاید اول
    var slide = pres.getSlides().get_Item(0);
    // ایجاد نمودار پیش‌فرض
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // دریافت شاخص کاربرگ داده‌های نمودار پیش‌فرض
    var defaultWorksheetIndex = 0;
    // دریافت کاربرگ داده‌های نمودار
    var fact = chart.getChartData().getChartDataWorkbook();
    // حذف سری نمونه
    chart.getChartData().getSeries().clear();
    // افزودن سری جدید
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // بارگذاری تصویر 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // بارگذاری تصویر 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // دریافت اولین سری نمودار
    var series = chart.getChartData().getSeries().get_Item(0);
    // افزودن نقطه جدید (1:3) در آنجا.
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // تغییر نشانگر سری نمودار
    series.getMarker().setSize(15);
    // ذخیره ارائه همراه با نمودار
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **پرسش‌های متداول**

**کدام اشکال نشانگر به‌صورت پیش‌فرض در دسترس هستند؟**

اشکال استاندارد (دایره، مربع، الماس، مثلث و غیره) در دسترس هستند؛ این فهرست توسط شمارش [MarkerStyleType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markerstyletype/) تعریف شده است. اگر به شکل غیراستاندارد نیاز دارید، می‌توانید از نشانگر با پرکردن تصویر برای شبیه‌سازی ظاهر سفارشی استفاده کنید.

**آیا نشانگرها هنگام صادرات نمودار به تصویر یا SVG حفظ می‌شوند؟**

بله. هنگام رندر نمودارها به [فرمت‌های رستر](/slides/fa/nodejs-java/convert-powerpoint-to-png/) یا ذخیرهٔ [اشکال به‌صورت SVG](/slides/fa/nodejs-java/render-a-slide-as-an-svg-image/)، نشانگرها ظاهر و تنظیمات خود را از جمله اندازه، پرکردن و خط‌مرز حفظ می‌کنند.