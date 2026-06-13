---
title: سفارشی‌سازی جداول دادهٔ نمودار در ارائه‌ها با استفاده از جاوا
linktitle: جدول داده
type: docs
url: /fa/java/chart-data-table/
keywords:
- داده نمودار
- جدول داده
- ویژگی‌های قلم
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "جداول دادهٔ نمودار را در جاوا برای فایل‌های PPT و PPTX با Aspose.Slides سفارشی کنید تا کارایی و جذابیت ارائه‌ها را افزایش دهید."
---
## **بررسی کلی**

این مقاله نحوه کار با جداول دادهٔ نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه یک جدول داده برای نمودار نمایش داده شود و قالب‌بندی متن آن با تنظیم ویژگی‌های قلم مانند حالت بولد و ارتفاع قلم سفارشی شود. مثال بارگذاری یک ارائه، افزودن نمودار، فعال‌سازی جدول دادهٔ نمودار، اعمال تنظیمات قلم و ذخیرهٔ ارائهٔ به‌روزرسانی‌شده را نشان می‌دهد.

همچنین پاسخ‌های کوتاهی به سوالات رایج درباره نشان دادن کلیدهای راهنما در جدول دادهٔ نمودار، حفظ جدول داده هنگام خروجی‌گیری، کار با نمودارهای بارگذاری‌شده از ارائه‌ها یا قالب‌های موجود، و شناسایی نمودارهایی که جدول داده برای آن‌ها فعال است، ارائه می‌کند.

## **تنظیم ویژگی‌های قلم برای جدول دادهٔ نمودار**
Aspose.Slides for Java امکان تغییر رنگ دسته‌ها در یک سری رنگی را فراهم می‌کند.

1. ایجاد شیء کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation).
1. افزودن نمودار به اسلاید.
1. تنظیم جدول نمودار.
1. تنظیم ارتفاع قلم.
1. ذخیرهٔ ارائهٔ تغییر یافته.

نمونهٔ کد زیر ارائه شده است.

```java
// ایجاد ارائه خالی
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم کلیدهای کوچک راهنما را در کنار مقادیر در جدول دادهٔ نمودار نمایش دهم؟**

بله. جدول داده از [کلیدهای راهنما](https://reference.aspose.com/slides/fa/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) پشتیبانی می‌کند و می‌توانید آن را روشن یا خاموش کنید.

**آیا جدول داده هنگام خروجی‌گیری ارائه به PDF، HTML یا تصویر حفظ می‌شود؟**

بله. Aspose.Slides نمودار را به عنوان بخشی از اسلاید رندر می‌کند، بنابراین [PDF](/slides/fa/java/convert-powerpoint-to-pdf/), [HTML](/slides/fa/java/convert-powerpoint-to-html/) و [image](/slides/fa/java/convert-powerpoint-to-png/) صادر شده شامل نمودار همراه با جدول دادهٔ آن می‌شود.

**آیا جداول داده برای نمودارهایی که از فایل قالب بارگذاری می‌شوند، پشتیبانی می‌شوند؟**

بله. برای هر نموداری که از یک ارائه یا قالب موجود بارگذاری می‌شود، می‌توانید با استفاده از خواص نمودار بررسی و تغییر دهید که آیا جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chart/#hasDataTable--) یا خیر.

**چگونه می‌توانم به سرعت تشخیص دهم کدام نمودارها در یک فایل جدول داده را فعال داشته‌اند؟**

خواص هر نمودار را که نشان می‌دهد آیا جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chart/#hasDataTable--) را بررسی کنید و در اسلایدها پیمایش کنید تا نمودارهایی که این ویژگی فعال است را شناسایی کنید.