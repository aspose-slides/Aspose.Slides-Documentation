---
title: تبدیل اسلایدهای PowerPoint به PNG در JavaScript
linktitle: PowerPoint به PNG
type: docs
weight: 30
url: /fa/nodejs-java/convert-powerpoint-to-png/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به PNG
- ارائه به PNG
- اسلاید به PNG
- PPT به PNG
- PPTX به PNG
- ذخیره PPT به صورت PNG
- ذخیره PPTX به صورت PNG
- صادرات PPT به PNG
- صادرات PPTX به PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به تصاویر PNG با کیفیت بالا در JavaScript به‌سرعت با Aspose.Slides برای Node.js، تضمین کننده نتایج دقیق و خودکار."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به تصاویر PNG تبدیل کنیم. این مقاله نشان می‌دهد چگونه فایل‌های ارائه را در قالب‌هایی مانند PPT، PPTX و ODP بارگذاری، اسلایدها را به عنوان تصویر رندر و نتایج را در قالب PNG ذخیره کنیم.

همچنین مقاله نشان می‌دهد چگونه می‌توان تصاویر PNG تولید شده را با تنظیم مقادیر مقیاس یا مشخص کردن عرض و ارتفاع دلخواه سفارشی کرد.

## **تبدیل PowerPoint به PNG**

این مراحل را دنبال کنید:

1. نمونه‌ای از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. شی اسلاید را از مجموعه‌ای که توسط متد [Presentation.getSlides()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) برگردانده می‌شود، تحت کلاس [Slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Slide) دریافت کنید.
3. از متد [Slide.getImage()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Slide) برای دریافت تصویر کوچک (thumbnail) هر اسلاید استفاده کنید.
4. از متد [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/#save) برای ذخیره تصویر کوچک اسلاید در قالب PNG استفاده کنید.

این کد JavaScript نشان می‌دهد چگونه یک ارائه PowerPoint را به PNG تبدیل کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تبدیل PowerPoint به PNG با ابعاد سفارشی**

اگر می‌خواهید فایل‌های PNG را با مقیاس خاصی به‌دست آورید، می‌توانید مقادیر `desiredX` و `desiredY` را تنظیم کنید که ابعاد تصویر کوچک تولید شده را تعیین می‌کند.

این کد JavaScript عمل شرح‌داده‌شده را نشان می‌دهد:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تبدیل PowerPoint به PNG با اندازه سفارشی**

اگر می‌خواهید فایل‌های PNG را با اندازه خاصی به‌دست آورید، می‌توانید آرگومان‌های `width` و `height` موردنظر خود را برای `ImageSize` منتقل کنید.

این کد نشان می‌دهد چگونه یک PowerPoint را به PNG تبدیل کنید در حالی که اندازه تصاویر را مشخص می‌کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**چگونه می‌توانم فقط یک شکل خاص (مثلاً نمودار یا تصویر) را به‌جای کل اسلاید صادر کنم؟**

Aspose.Slides از [ایجاد تصویر کوچک برای اشکال جداگانه](/slides/fa/nodejs-java/create-shape-thumbnails/) پشتیبانی می‌کند؛ می‌توانید یک شکل را به تصویر PNG رندر کنید.

**آیا تبدیل همزمان در یک سرور پشتیبانی می‌شود؟**

بله، اما [نشر نکنید](/slides/fa/nodejs-java/multithreading/) یک نمونه ارائه را بین رشته‌ها. برای هر رشته یا فرآیند یک نمونه جداگانه استفاده کنید.

**محدودیت‌های نسخه آزمایشی هنگام صادر کردن به PNG چیست؟**

در حالت ارزیابی یک واترمارک به تصاویر خروجی اضافه می‌شود و [قیدهای دیگر](/slides/fa/nodejs-java/licensing/) تا زمانی که یک لایسنس اعمال شود، اعمال می‌شود.