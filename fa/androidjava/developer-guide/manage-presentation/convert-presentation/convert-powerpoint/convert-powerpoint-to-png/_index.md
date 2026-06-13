---
title: تبدیل اسلایدهای PowerPoint به PNG در Android
linktitle: PowerPoint به PNG
type: docs
weight: 30
url: /fa/androidjava/convert-powerpoint-to-png/
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
- Android
- Java
- Aspose.Slides
description: "ارائه‌های PowerPoint را به سرعت به تصاویر PNG با کیفیت بالا تبدیل کنید با Aspose.Slides برای Android از طریق Java، به‌طوری‌که نتایج دقیق و خودکار به دست آید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چطور ارائه‌های PowerPoint را با استفاده از Aspose.Slides به تصاویر PNG تبدیل کنید. این مقاله نشان می‌دهد چگونه فایل‌های ارائه را در قالب‌های PPT، PPTX و ODP بارگذاری کنید، اسلایدها را به عنوان تصویر رندر کنید و نتایج را در قالب PNG ذخیره نمایید.

همچنین مقاله نشان می‌دهد چگونه می‌توان تصاویر PNG تولید شده را با تنظیم مقادیر مقیاس یا مشخص کردن عرض و ارتفاع موردنظر سفارشی کرد.

## **تبدیل PowerPoint به PNG**

این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. شی اسلاید را از مجموعه [Presentation.getSlides()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) تحت رابط [ISlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlide) دریافت کنید.
3. از متد [ISlide.getImage()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlide) برای دریافت تصویر کوچک هر اسلاید استفاده کنید.
4. از متد [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) برای ذخیره تصویر کوچک اسلاید در قالب PNG استفاده کنید.

این کد Java نشان می‌دهد چگونه یک ارائه PowerPoint را به PNG تبدیل کنید:

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

اگر می‌خواهید فایل‌های PNG را در مقیاس خاصی به‌دست آورید، می‌توانید مقادیر `desiredX` و `desiredY` را تنظیم کنید که ابعاد تصویر کوچک حاصل را تعیین می‌کند.

این کد در Java عملیات شرح داده شده را نشان می‌دهد:

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

اگر می‌خواهید فایل‌های PNG را در اندازه خاصی به‌دست آورید، می‌توانید آرگومان‌های `width` و `height` موردنظر خود را برای `ImageSize` ارسال کنید.

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

**چگونه می‌توانم فقط یک شکل خاص (مانند نمودار یا تصویر) را به‌جای کل اسلاید صادر کنم؟**

Aspose.Slides از [تولید تصویر کوچک برای اشکال منفرد](/slides/fa/androidjava/create-shape-thumbnails/) پشتیبانی می‌کند؛ می‌توانید یک شکل را به تصویر PNG رندر کنید.

**آیا تبدیل موازی بر روی سرور پشتیبانی می‌شود؟**

بله، اما [نشر یک‌باره](/slides/fa/androidjava/multithreading/) یک نمونه ارائه بین رشته‌ها را انجام ندهید. برای هر رشته یا فرآیند یک نمونه جداگانه استفاده کنید.

**محدودیت‌های نسخه آزمایشی هنگام خروجی گرفتن به PNG چیست؟**

حالت ارزیابی یک واترمارک به تصاویر خروجی اضافه می‌کند و تا زمان اعمال لایسنس، [محدودیت‌های دیگری](/slides/fa/androidjava/licensing/) را اعمال می‌نماید.