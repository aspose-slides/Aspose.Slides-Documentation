---
title: سفارشی‌سازی نمودارهای دونات در ارائه‌ها با استفاده از جاوا
linktitle: نمودار دونات
type: docs
weight: 30
url: /fa/java/doughnut-chart/
keywords:
- نمودار دونات
- فاصله مرکزی
- اندازه حفره
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید نمودارهای دونات را در Aspose.Slides برای جاوا ایجاد و سفارشی کنید و از فرمت‌های PowerPoint برای ارائه‌های پویا پشتیبانی نمایید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه با نمودار دونات در Aspose.Slides کار کنیم با افزودن نمودار به یک اسلاید، تنظیم اندازهٔ حفرهٔ مرکزی آن و ذخیرهٔ ارائه. این مقاله بر روی متد `setDoughnutHoleSize` تمرکز دارد و گام‌های پایه لازم برای سفارشی‌سازی این نوع نمودار را در کد نشان می‌دهد.

همچنین شامل یک بخش پرسش‌های متداول کوتاه دربارهٔ موقعیت‌های مربوط به نمودارهای دونات است، مانند استفاده از چندین سری برای ایجاد چندین حلقه، کار با نمودارهای دونات منفجر شده، و خروجی نمودار به صورت تصویر رستر یا SVG.

## **مشخص کردن فاصلهٔ مرکزی در نمودار دونات**
{{% alert color="info" %}} 
Aspose.Slides for Java اکنون از تعیین اندازهٔ حفرهٔ نمودار دونات پشتیبانی می‌کند. در این بخش با مثال نشان می‌دهیم چگونه اندازهٔ حفرهٔ نمودار دونات را مشخص کنیم.
{{% /alert %}} 

برای تعیین اندازهٔ حفرهٔ نمودار دونات، لطفاً مراحل زیر را دنبال کنید:

1. ایجاد شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation).
1. افزودن نمودار دونات به اسلاید.
1. تنظیم اندازهٔ حفرهٔ نمودار دونات.
1. نوشتن ارائه روی دیسک.

در مثال زیر، ما اندازهٔ حفرهٔ نمودار دونات را تنظیم کرده‌ایم.

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // ارائه را روی دیسک ذخیره کنید
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

### آیا می‌توانم یک دونات چندسطحی با چندین حلقه ایجاد کنم؟

بله. چندین سری را به یک نمودار دونات اضافه کنید—هر سری تبدیل به یک حلقه جداگانه می‌شود. ترتیب حلقه‌ها توسط ترتیب سری‌ها در مجموعه تعیین می‌شود.

### آیا دونات «منفجر» (قطعات جدا شده) پشتیبانی می‌شود؟

بله. یک نوع نمودار Donut Exploded وجود دارد و ویژگی انفجار بر روی نقاط داده قابل تنظیم است؛ می‌توانید قطعات جداگانه را جدا کنید.

### چگونه می‌توانم تصویری از نمودار دونات (PNG/SVG) برای گزارش دریافت کنم؟

نمودار یک شکل است؛ می‌توانید آن را به یک [raster image](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getImage-int-float-float-) رندر کنید یا نمودار را به یک [SVG image](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) صادر کنید.