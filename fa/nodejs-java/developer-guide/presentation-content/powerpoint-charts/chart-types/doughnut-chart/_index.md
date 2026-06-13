---
title: سفارشی‌سازی نمودارهای دونات در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: نمودار دونات
type: docs
weight: 30
url: /fa/nodejs-java/doughnut-chart/
keywords:
- نمودار دونات
- فاصله مرکز
- اندازه حفره
- PowerPoint
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید نمودارهای دونات را با جاوااسکریپت و Aspose.Slides برای Node.js ایجاد و سفارشی کنید، با پشتیبانی از فرمت‌های PowerPoint برای ارائه‌های پویا."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه با یک نمودار دونات در Aspose.Slides کار کنید؛ با افزودن نمودار به یک اسلاید، تنظیم اندازهٔ حفرهٔ مرکز و ذخیرهٔ ارائه. تمرکز بر روش `setDoughnutHoleSize` است و مراحل پایه لازم برای سفارشی‌سازی این نوع نمودار را در کد نشان می‌دهد.

همچنین شامل یک بخش پرسش‌های متداول کوتاه دربارهٔ سناریوهای مربوط به نمودار دونات است، مانند استفاده از چندین سری برای ایجاد چند حلقه، کار با نمودارهای دونات انفجار یافته و صادرات نمودار به تصویر رستر یا SVG.

## **تغییر فاصلهٔ مرکز در نمودار دونات**

برای تعیین اندازهٔ حفرهٔ مرکزی در یک نمودار دونات، لطفاً مراحل زیر را دنبال کنید:

1. یک شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) را ایجاد کنید.
1. نمودار دونات را به اسلاید اضافه کنید.
1. اندازهٔ حفرهٔ مرکزی در نمودار دونات را مشخص کنید.
1. ارائه را روی دیسک بنویسید.

در مثال زیر، اندازهٔ حفرهٔ مرکزی در نمودار دونات تنظیم شده است.

```javascript
// یک نمونه از کلاس Presentation ایجاد کنید
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // ارائه را روی دیسک ذخیره کنید
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **پرسش‌های متداول**

**آیا می‌توانم دونات چندسطحی با چند حلقه ایجاد کنم؟**

بله. چندین سری را به یک نمودار دونات اضافه کنید—هر سری تبدیل به یک حلقهٔ جداگانه می‌شود. ترتیب حلقه‌ها توسط ترتیب سری‌ها در مجموعه تعیین می‌شود.

**آیا دونات «انفجار یافته» (قاب‌های جدا شده) پشتیبانی می‌شود؟**

بله. یک [chart type](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/) به نام Exploded Doughnut وجود دارد و یک ویژگی انفجار بر روی نقاط داده؛ می‌توانید قاب‌های جداگانه را تقسیم کنید.

**چگونه می‌توانم یک تصویر از نمودار دونات (PNG/SVG) برای گزارش دریافت کنم؟**

نمودار یک شکل است؛ می‌توانید آن را به یک [raster image](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getImage) رندر کنید یا نمودار را به یک [SVG image](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/writeassvg/) صادر کنید.