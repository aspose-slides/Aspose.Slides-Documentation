---
title: صادرات نمودارهای ارائه در جاوا اسکریپت
linktitle: صادرات نمودار
type: docs
weight: 90
url: /fa/nodejs-java/export-chart/
keywords:
- نمودار
- نمودار به تصویر
- نمودار به عنوان تصویر
- استخراج تصویر نمودار
- PowerPoint
- ارائه
- Node.js
- جاوا اسکریپت
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارهای ارائه را با Aspose.Slides برای Node.js از طریق Java صادر کنید، که از فرمت‌های PPT و PPTX پشتیبانی می‌کند و گزارش‌گیری را در هر جریان کاری ساده می‌سازد."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد یک نمودار را از یک ارائه به عنوان تصویر صادر کنید. این مقاله نشان می‌دهد چگونه تصویر یک نمودار را به‌دست آورده و ذخیره کنید، که هنگام نیاز به استفاده مجدد از تصاویر نمودار خارج از ارائه PowerPoint مفید است.

## **دریافت تصویر نمودار**
Aspose.Slides برای Node.js از طریق Java پشتیبانی از استخراج تصویر یک نمودار خاص را فراهم می‌کند. نمونه‌ای زیر ارائه شده است.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سؤال‌های متداول**

**آیا می‌توانم یک نمودار را به‌جای تصویر رستر به صورت برداری (SVG) صادر کنم؟**

بله. یک نمودار یک شکل است و محتوای آن می‌تواند با استفاده از [روش ذخیره‌سازی shape-to-SVG](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/writeassvg/) به SVG ذخیره شود.

**چگونه می‌توانم اندازه دقیق نمودار صادرشده را به پیکسل تعیین کنم؟**

از overloadهای image-rendering استفاده کنید که به شما امکان مشخص کردن اندازه یا مقیاس را می‌دهند—کتابخانه از رندر اشیاء با ابعاد/مقیاس مشخص پشتیبانی می‌کند.

**اگر پس از صادرات، قلم‌های برچسب‌ها و راهنما به‌درستی ظاهر نشوند چه کار کنم؟**

[بارگذاری قلم‌های مورد نیاز](/slides/fa/nodejs-java/custom-font/) از طریق [FontsLoader](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/) تا رندر نمودار معیارها و ظاهر متن را حفظ کند.

**آیا صادرات، تم، سبک‌ها و اثرات PowerPoint را رعایت می‌کند؟**

بله. رندرکننده Aspose.Slides فرمت‌بندی ارائه (تم‌ها، سبک‌ها، پرکننده‌ها، اثرات) را دنبال می‌کند، بنابراین ظاهر نمودار حفظ می‌شود.

**کجا می‌توانم قابلیت‌های رندر/صادرات موجود فراتر از تصاویر نمودار را پیدا کنم؟**

به [API](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/)/[مستندات](/slides/fa/nodejs-java/convert-powerpoint/) برای اهداف خروجی ([PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/fa/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/fa/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/)، و غیره) و گزینه‌های رندر مرتبط مراجعه کنید.