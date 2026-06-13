---
title: سفارشی‌سازی نمودارهای دونات در ارائه‌ها با استفاده از جاوا
linktitle: نمودار دونات
type: docs
weight: 30
url: /fa/java/doughnut-chart/
keywords:
- نمودار دونات
- فاصله مرکزی
- اندازه سوراخ
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "کشف کنید چگونه می‌توان نمودارهای دونات را در Aspose.Slides برای جاوا ایجاد و سفارشی‌سازی کرد، با پشتیبانی از فرمت‌های PowerPoint برای ارائه‌های پویا."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه با یک نمودار دونات در Aspose.Slides کار کنیم؛ با افزودن نمودار به اسلاید، تنظیم اندازهٔ سوراخ مرکزی و ذخیره‌سازی ارائه. تمرکز بر روی متد `setDoughnutHoleSize` است و گام‌های پایه مورد نیاز برای شخصی‌سازی این نوع نمودار را در کد نشان می‌دهد.

همچنین شامل یک بخش کوتاه پرسش‌های متداول دربارهٔ سناریوهای مرتبط با نمودارهای دونات است، مانند استفاده از چند سری برای ایجاد چند حلقه، کار با نمودارهای دونات انفجار یافته، و استخراج نمودار به صورت تصویر رستر یا SVG.

## **مشخص کردن فضای مرکزی در نمودار دونات**
{{% alert color="primary" %}} 

Aspose.Slides برای Java اکنون امکان مشخص کردن اندازهٔ سوراخ در یک نمودار دونات را فراهم می‌کند. در این موضوع، با مثال نشان می‌دهیم چگونه اندازهٔ سوراخ در یک نمودار دونات را مشخص کنیم.

{{% /alert %}} 

برای مشخص کردن اندازهٔ سوراخ در یک نمودار دونات، لطفاً مراحل زیر را دنبال کنید:

1. نمونه‌ای از شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. نمودار دونات را به اسلاید اضافه کنید.
1. اندازهٔ سوراخ در نمودار دونات را مشخص کنید.
1. پرزنتیشن را روی دیسک ذخیره کنید.

در مثال زیر، ما اندازهٔ سوراخ در یک نمودار دونات را تنظیم کرده‌ایم.

```java
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

**آیا می‌توانم یک دونات چند سطحی با چند حلقه ایجاد کنم؟**

بله. چندین سری را به یک نمودار دونات اضافه کنید؛ هر سری تبدیل به یک حلقه جداگانه می‌شود. ترتیب حلقه‌ها بر اساس ترتیب سری‌ها در مجموعه تعیین می‌شود.

**آیا یک دونات «انفجار یافته» (برش‌های جدا شده) پشتیبانی می‌شود؟**

بله. یک نوع نمودار Donut Exploded وجود دارد و ویژگی انفجار روی نقاط داده قابل تنظیم است؛ می‌توانید برش‌های منفرد را جدا کنید.

**چگونه می‌توانم تصویر یک نمودار دونات (PNG/SVG) برای گزارش دریافت کنم؟**

یک نمودار یک شکل است؛ می‌توانید آن را به یک [raster image](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getImage-int-float-float-) تبدیل کنید یا نمودار را به یک [SVG image](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) صادر کنید.