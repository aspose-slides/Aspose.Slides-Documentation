---
title: سفارشی‌سازی جداول داده‌ نمودار در ارائه‌ها برای اندروید
linktitle: جدول داده
type: docs
url: /fa/androidjava/chart-data-table/
keywords:
- داده نمودار
- جدول داده
- ویژگی‌های قلم
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "جداول داده‌ نمودار را در Java برای PPT و PPTX با Aspose.Slides برای Android سفارشی کنید تا کارایی و جذابیت ارائه‌ها را افزایش دهید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با جداول داده‌های نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه جدول داده‌ها را برای یک نمودار نمایش دهید و قالب‌بندی متن آن را با تنظیم ویژگی‌های قلم مانند حالت بولد و ارتفاع قلم سفارشی کنید. مثال بارگذاری یک ارائه، افزودن یک نمودار، فعال‌سازی جدول داده‌های نمودار، اعمال تنظیمات قلم و ذخیره ارائه به‌روزرسانی‌شده را نشان می‌دهد.

## **تنظیم ویژگی‌های قلم برای جدول داده‌های نمودار**
Aspose.Slides برای Android از طریق Java امکان تغییر رنگ دسته‌ها در یک رنگ سری را فراهم می‌کند.  

1. یک شیء کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) را ایجاد کنید.  
1. نمودار را بر روی اسلاید اضافه کنید.  
1. جدول نمودار را تنظیم کنید.  
1. ارتفاع قلم را تنظیم کنید.  
1. ارائه اصلاح‌شده را ذخیره کنید.  

مثال نمونه زیر ارائه شده است.  

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

**آیا می‌توانم کلیدهای نماد کوچک را در کنار مقادیر جدول داده‌های نمودار نشان دهم؟**  
بله. جدول داده‌ها از [کلیدهای نماد](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) پشتیبانی می‌کند و می‌توانید آن‌ها را روشن یا خاموش کنید.

**آیا جدول داده‌ها هنگام استخراج ارائه به PDF, HTML یا تصویر حفظ می‌شود؟**  
بله. Aspose.Slides نمودار را به عنوان بخشی از اسلاید رندر می‌کند، بنابراین استخراج [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/fa/androidjava/convert-powerpoint-to-html/)/[image](/slides/fa/androidjava/convert-powerpoint-to-png/) شامل نمودار همراه با جدول داده‌های آن است.

**آیا جداول داده برای نمودارهایی که از یک فایل قالب آمده‌اند پشتیبانی می‌شوند؟**  
بله. برای هر نموداری که از ارائه یا قالب موجود بارگذاری می‌شود، می‌توانید با استفاده از ویژگی‌های نمودار بررسی و تغییر دهید که آیا جدول داده‌ها [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chart/#hasDataTable--) یا نه.

**چگونه می‌توانم به‌سرعت تشخیص دهم کدام نمودارها در یک فایل جدول داده فعال دارند؟**  
هر ویژگی هر نمودار که نشان می‌دهد آیا جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chart/#hasDataTable--) یا نه را بررسی کنید و از طریق اسلایدها پیمایش کنید تا نمودارهایی که این گزینه فعال است شناسایی شوند.