---
title: تبدیل اسلایدهای PowerPoint به PNG در Java
linktitle: PowerPoint به PNG
type: docs
weight: 30
url: /fa/java/convert-powerpoint-to-png/
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
- ذخیره PPT به عنوان PNG
- ذخیره PPTX به عنوان PNG
- صادرات PPT به PNG
- صادرات PPTX به PNG
- Java
- Aspose.Slides
description: ارائه‌های PowerPoint را به سرعت به تصاویر PNG با کیفیت بالا تبدیل کنید با Aspose.Slides برای Java، به‌طوری که نتایج دقیق و خودکار باشد.
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را به تصاویر PNG با استفاده از Aspose.Slides تبدیل کنیم. این مقاله نشان می‌دهد چگونه فایل‌های ارائه را در قالب‌هایی مانند PPT، PPTX و ODP بارگذاری کنیم، اسلایدها را به‌صورت تصویر رندر کنیم و نتایج را در قالب PNG ذخیره کنیم.

همچنین مقاله نشان می‌دهد چگونه می‌توان تصاویر PNG تولید شده را با تنظیم مقادیر مقیاس یا تعیین عرض و ارتفاع موردنظر سفارشی کرد.

## **تبدیل PowerPoint به PNG**

این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. شی اسلاید را از مجموعه [Presentation.getSlides()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) که تحت رابط [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide) قرار دارد، دریافت کنید. 
3. از متد [ISlide.getImage()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide) برای دریافت تصویر کوچک هر اسلاید استفاده کنید.
4. از متد [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) برای ذخیره تصویر کوچک اسلاید در قالب PNG استفاده کنید.

این کد Java نشان می‌دهد چگونه یک ارائه PowerPoint را به PNG تبدیل کنیم:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **تبدیل PowerPoint به PNG با ابعاد سفارشی**

اگر می‌خواهید فایل‌های PNG با مقیاس خاصی دریافت کنید، می‌توانید مقادیر `desiredX` و `desiredY` را تنظیم کنید که ابعاد تصویر کوچک حاصل را تعیین می‌کنند. 

این کد در Java عملیات توضیح داده شده را نشان می‌دهد:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **تبدیل PowerPoint به PNG با اندازه سفارشی**

اگر می‌خواهید فایل‌های PNG با اندازه خاصی دریافت کنید، می‌توانید آرگومان‌های `width` و `height` موردنظر خود را برای `ImageSize` ارسال کنید. 

این کد نشان می‌دهد چگونه یک PowerPoint را به PNG تبدیل کنید در حالی که اندازه تصاویر را مشخص می‌کنید: 

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

**چگونه می‌توانم فقط یک شکل خاص (مثلاً نمودار یا تصویر) را به‌جای کل اسلاید صادر کنم؟**

Aspose.Slides از [ایجاد تصویر کوچک برای اشکال منفرد](/slides/fa/java/create-shape-thumbnails/) پشتیبانی می‌کند؛ می‌توانید یک شکل را به تصویر PNG رندر کنید.

**آیا تبدیل موازی در سرور پشتیبانی می‌شود؟**

بله، اما [به‌اشتراک نگذارید](/slides/fa/java/multithreading/) یک نمونهٔ ارائه را بین رشته‌ها. برای هر رشته یا فرآیند یک نمونه جداگانه استفاده کنید.

**محدودیت‌های نسخه آزمایشی هنگام خروجی گرفتن به PNG چیست؟**

حالت ارزیابی یک واترمارک به تصاویر خروجی اضافه می‌کند و [محدودیت‌های دیگر](/slides/fa/java/licensing/) را تا اعمال یک لایسنس اعمال می‌نماید.