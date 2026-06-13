---
title: صادر کردن نمودارهای ارائه در جاوا
linktitle: صادر کردن نمودار
type: docs
weight: 90
url: /fa/java/export-chart/
keywords:
- نمودار
- نمودار به تصویر
- نمودار به‌عنوان تصویر
- استخراج تصویر نمودار
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارهای ارائه را با Aspose.Slides برای جاوا صادر کنید، از فرمت‌های PPT و PPTX پشتیبانی می‌کند و گزارش‌دهی را در هر جریان کاری ساده می‌سازد."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد یک نمودار را از یک ارائه به‌صورت تصویر استخراج کنید. این مقاله نشان می‌دهد چگونه از یک نمودار تصویر دریافت کرده و آن را ذخیره کنید، که زمانی مفید است که بخواهید نمودارها را خارج از ارائه PowerPoint دوباره استفاده کنید.

علاوه بر روند پایه‌ای استخراج تصویر، این مقاله به سؤالات رایج مرتبط با استخراج نیز می‌پردازد، از جمله ذخیره محتوای نمودار به SVG، کنترل اندازه خروجی از طریق گزینه‌های رندرینگ، بارگذاری قلم‌ها برای حفظ ظاهر برچسب‌ها و افسانه، و نگه داشتن قالب‌بندی اصلی ارائه مانند تم‌ها، سبک‌ها، پرکنندگان و افکت‌ها در هنگام رندرینگ.

## **دریافت تصویر نمودار**
Aspose.Slides برای Java پشتیبانی از استخراج تصویر نمودار خاص را فراهم می‌کند. نمونه کد زیر ارائه شده است.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم یک نمودار را به‌جای تصویر شطرنجی (رستر) به‌صورت برداری (SVG) استخراج کنم؟**  
بله. یک نمودار یک شکل است و محتوای آن می‌تواند با استفاده از [روش ذخیره‌سازی shape-to-SVG](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) به SVG ذخیره شود.

**چگونه می‌توانم اندازه دقیق نمودار استخراج‌شده را بر حسب پیکسل تنظیم کنم؟**  
از overloadهای رندر تصویر استفاده کنید که امکان مشخص کردن اندازه یا مقیاس را می‌دهند—کتابخانه از رندر اشیا با ابعاد/مقیاس مشخص پشتیبانی می‌کند.

**اگر قلم‌ها در برچسب‌ها و افسانه پس از استخراج به‌درستی نمایش داده نشدند چه کاری باید انجام دهم؟**  
[بارگذاری قلم‌های مورد نیاز](/slides/fa/java/custom-font/) از طریق [FontsLoader](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/) تا رندر نمودار معیارها و ظاهر متن را حفظ کند.

**آیا استخراج قالب، سبک‌ها و افکت‌های PowerPoint را حفظ می‌کند؟**  
بله. رندر کننده Aspose.Slides قالب‌بندی ارائه (تم‌ها، سبک‌ها، پرکنندگان، افکت‌ها) را دنبال می‌کند، بنابراین ظاهر نمودار حفظ می‌شود.

**کجا می‌توانم قابلیت‌های رندر/استخراج موجود فراتر از تصاویر نمودار را پیدا کنم؟**  
به [API](https://reference.aspose.com/slides/fa/java/com.aspose.slides/)/[مستندات](/slides/fa/java/convert-powerpoint/) برای اهداف خروجی مراجعه کنید ([PDF](/slides/fa/java/convert-powerpoint-to-pdf/), [SVG](/slides/fa/java/render-a-slide-as-an-svg-image/), [XPS](/slides/fa/java/convert-powerpoint-to-xps/), [HTML](/slides/fa/java/convert-powerpoint-to-html/)، و غیره) و گزینه‌های رندر مرتبط.