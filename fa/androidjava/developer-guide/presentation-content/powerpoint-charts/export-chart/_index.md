---
title: صادرات نمودارهای ارائه در Android
linktitle: صدور نمودار
type: docs
weight: 90
url: /fa/androidjava/export-chart/
keywords:
- نمودار
- نمودار به تصویر
- نمودار به‌عنوان تصویر
- استخراج تصویر نمودار
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارهای ارائه را با Aspose.Slides برای Android از طریق Java صادر کنید، از فرمت‌های PPT و PPTX پشتیبانی می‌کند و گزارش‌دهی را به هر جریان کاری ساده می‌سازد."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد یک نمودار را از یک ارائه به عنوان تصویر استخراج کنید. این مقاله نشان می‌دهد چگونه تصویر یک نمودار را بدست آورده و ذخیره کنید، که زمانی که نیاز به استفاده مجدد از نمایش‌های نمودار خارج از ارائه PowerPoint دارید، مفید است.

علاوه بر جریان کار پایه‌ای استخراج تصویر، این مقاله به پرسش‌های رایج مربوط به استخراج نیز می‌پردازد، از جمله ذخیره محتوای نمودار به SVG، کنترل اندازه خروجی از طریق گزینه‌های رندرینگ، بارگذاری فونت‌ها برای حفظ ظاهر برچسب‌ها و افسانه، و حفظ قالب‌بندی اصلی ارائه مانند تم‌ها، سبک‌ها، پرکننده‌ها و افکت‌ها در هنگام رندرینگ.

## **دریافت تصویر نمودار**
Aspose.Slides برای Android از طریق Java پشتیبانی از استخراج تصویر یک نمودار خاص را فراهم می‌کند. مثال نمونه زیر ارائه شده است.

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

## **سوالات متداول**

**آیا می‌توانم یک نمودار را به‌جای تصویر رستر به‌عنوان بردار (SVG) استخراج کنم؟**  
بله. یک نمودار یک شکل است و محتویات آن می‌تواند با استفاده از [روش ذخیره‌سازی شکل به SVG](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) به SVG ذخیره شود.

**چگونه می‌توانم اندازه دقیق نمودار استخراج‌شده را بر حسب پیکسل تنظیم کنم؟**  
از overloadهای رندرینگ تصویر استفاده کنید که به شما اجازه می‌دهد اندازه یا مقیاس را تعیین کنید—کتابخانه از رندرینگ اشیاء با ابعاد/مقیاس مشخص پشتیبانی می‌کند.

**اگر پس از استخراج، فونت‌های برچسب‌ها و افسانه به‌درستی نمایش داده نشوند، چه کار کنم؟**  
[فونت‌های مورد نیاز را بارگذاری کنید](/slides/fa/androidjava/custom-font/) از طریق [FontsLoader](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/) تا رندر نمودار معیارها و ظاهر متن را حفظ کند.

**آیا استخراج قالب PowerPoint، سبک‌ها و افکت‌ها را رعایت می‌کند؟**  
بله. رندرر Aspose.Slides قالب‌بندی ارائه (تم‌ها، سبک‌ها، پرکننده‌ها، افکت‌ها) را دنبال می‌کند، بنابراین ظاهر نمودار حفظ می‌شود.

**کجا می‌توانم قابلیت‌های رندرینگ/استخراج موجود فراتر از تصاویر نمودار را پیدا کنم؟**  
به [API](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/)/[مستندات](/slides/fa/androidjava/convert-powerpoint/) برای هدف‌های خروجی (مانند [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/)، [SVG](/slides/fa/androidjava/render-a-slide-as-an-svg-image/)، [XPS](/slides/fa/androidjava/convert-powerpoint-to-xps/)، [HTML](/slides/fa/androidjava/convert-powerpoint-to-html/)، و غیره) و گزینه‌های رندرینگ مرتبط مراجعه کنید.