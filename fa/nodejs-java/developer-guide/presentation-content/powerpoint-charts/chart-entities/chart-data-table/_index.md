---
title: سفارشی‌سازی جداول داده‌های نمودار در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: جدول داده
type: docs
url: /fa/nodejs-java/chart-data-table/
keywords:
- داده‌های نمودار
- جدول داده
- ویژگی‌های قلم
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "جداول داده‌های نمودار را در جاوااسکریپت برای فایل‌های PPT و PPTX با Aspose.Slides برای Node.js از طریق جاوا سفارشی کنید تا کارایی و جذابیت در ارائه‌ها افزایش یابد."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با جداول داده‌های نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه یک جدول داده برای یک نمودار نمایش داده شود و قالب‌بندی متن آن را با تنظیم ویژگی‌های قلم مانند سبک بولد و ارتفاع قلم سفارشی کنید. مثال بارگذاری یک ارائه، افزودن یک نمودار، فعال‌سازی جدول داده‌های نمودار، اعمال تنظیمات قلم و ذخیره‌سازی ارائه به‌روزرسانی‌شده را نشان می‌دهد.

همچنین پاسخ‌های کوتاهی به سؤالات رایج درباره نمایش کلیدهای لگند در جدول داده‌های نمودار، حفظ جدول داده هنگام خروجی‌گیری، کار با نمودارهایی که از ارائه‌های موجود یا قالب‌ها بارگذاری شده‌اند، و شناسایی نمودارهایی که جدول داده فعال است، شامل می‌شود.

## **تنظیم ویژگی‌های قلم برای جدول داده‌های نمودار**

Aspose.Slides برای Node.js از طریق Java پشتیبانی از تغییر رنگ دسته‌ها در رنگ یک سری را فراهم می‌کند.  

1. شیء کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) را نمونه‌سازی کنید.  
1. نمودار را بر روی اسلاید اضافه کنید.  
1. جدول نمودار را تنظیم کنید.  
1. ارتفاع قلم را تنظیم کنید.  
1. ارائه‌ اصلاح‌شده را ذخیره کنید.  

نمونه مثال زیر ارائه شده است.  

```javascript
// ایجاد ارائه خالی
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **پرسش‌های متداول**

**آیا می‌توانم کلیدهای لگند کوچک را در کنار مقادیر جدول داده‌های نمودار نمایش دهم؟**

بله. جدول داده از [legend keys](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datatable/setshowlegendkey/) پشتیبانی می‌کند و می‌توانید آنها را روشن یا خاموش کنید.

**آیا جدول داده هنگام خروجی‌گیری ارائه به PDF، HTML یا تصاویر حفظ می‌شود؟**

بله. Aspose.Slides نمودار را به‌عنوان بخشی از اسلاید رندر می‌کند، بنابراین [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/)، [HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/)، و [image](/slides/fa/nodejs-java/convert-powerpoint-to-png/) صادر شده شامل نمودار با جدول دادهٔ آن می‌شود.

**آیا جداول داده برای نمودارهایی که از یک فایل قالب می‌آیند پشتیبانی می‌شوند؟**

بله. برای هر نموداری که از یک ارائه یا قالب موجود بارگذاری می‌شود، می‌توانید با استفاده از ویژگی‌های نمودار، بررسی و تغییر دهید که آیا جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/hasdatatable/) یا نه.

**چگونه می‌توانم به‌سرعت تشخیص دهم کدام نمودارها در یک فایل جدول داده فعال دارند؟**

ویژگی هر نمودار که نشان می‌دهد جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/hasdatatable/) را بررسی کنید و از اسلایدها عبور کنید تا نمودارهایی را که این ویژگی فعال است شناسایی کنید.