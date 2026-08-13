---
title: سفارشی‌سازی نمودارهای دونات در ارائه‌ها بر روی اندروید
linktitle: نمودار دونات
type: docs
weight: 30
url: /fa/androidjava/doughnut-chart/
keywords:
- نمودار دونات
- فاصله مرکزی
- اندازه سوراخ
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "کشف کنید چگونه نمودارهای دونات را در Aspose.Slides برای اندروید از طریق Java ایجاد و سفارشی کنید، با پشتیبانی از قالب‌های PowerPoint برای ارائه‌های پویا."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه با یک نمودار دونات در Aspose.Slides کار کنید، با افزودن نمودار به یک اسلاید، تنظیم اندازهٔ سوراخ مرکزی آن و ذخیره‌سازی ارائه. این مقاله بر روی متد `setDoughnutHoleSize` تمرکز دارد و گام‌های پایه‌ای مورد نیاز برای سفارشی‌سازی این نوع نمودار را در کد نشان می‌دهد.

همچنین شامل یک بخش پرسش‌های متداول کوتاه است که سناریوهای مربوط به نمودارهای دونات را پوشش می‌دهد، مانند استفاده از چندین سری برای ایجاد چندین حلقه، کار با نمودارهای دونات منفجر شده و صادرات نمودار به عنوان تصویر رستری یا SVG.

## **مشخص کردن فاصلهٔ مرکزی در یک نمودار دونات**
{{% alert color="info" %}} 

Aspose.Slides برای Android از طریق Java اکنون پشتیبانی می‌کند از تعیین اندازهٔ سوراخ در یک نمودار دونات. در این مطلب با مثال مشاهده می‌کنیم چگونه اندازهٔ سوراخ در یک نمودار دونات را تعیین کنیم.

{{% /alert %}} 

به منظور تعیین اندازهٔ سوراخ در یک نمودار دونات، لطفاً مراحل زیر را دنبال کنید:

1. یک شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
2. نمودار دونات را بر روی اسلاید اضافه کنید.
3. اندازهٔ سوراخ در نمودار دونات را مشخص کنید.
4. ارائه را بر روی دیسک ذخیره کنید.

در مثال زیر، ما اندازهٔ سوراخ در یک نمودار دونات را تنظیم کرده‌ایم.

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

## **پرسش‌های متداول**

### آیا می‌توانم یک دونات چندسطحی با چندین حلقه ایجاد کنم؟

بله. چندین سری به یک نمودار دونات اضافه کنید—هر سری یک حلقه جداگانه می‌شود. ترتیب حلقه‌ها توسط ترتیب سری‌ها در مجموعه تعیین می‌شود.

### آیا دونات «منفجر شده» (قاشق‌های جدا شده) پشتیبانی می‌شود؟

بله. یک نوع نمودار Exploded Doughnut وجود دارد [نوع نمودار](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/charttype/) و یک ویژگی انفجار برای نقاط داده؛ می‌توانید قطعات جداگانه را جدا کنید.

### چگونه می‌توانم تصویر یک نمودار دونات (PNG/SVG) برای گزارش دریافت کنم؟

یک نمودار یک شکل است؛ می‌توانید آن را به یک [تصویر رستری](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) رندر کنید یا نمودار را به یک [تصویر SVG](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) صادر کنید.