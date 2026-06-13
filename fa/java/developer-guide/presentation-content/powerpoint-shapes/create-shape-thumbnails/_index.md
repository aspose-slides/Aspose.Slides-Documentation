---
title: ایجاد تصویرهای بندانگشتی از اشکال ارائه در جاوا
linktitle: بندانگشتی‌های شکل
type: docs
weight: 70
url: /fa/java/create-shape-thumbnails/
keywords:
- بندانگشتی شکل
- تصویر شکل
- رندر شکل
- رندرینگ شکل
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "تصاویر بندانگشتی با کیفیت بالا از اشکال اسلایدهای PowerPoint با Aspose.Slides برای Java ایجاد کنید – به راحتی تصاویر بندانگشتی ارائه را بسازید و صادر کنید."
---
## **معرفی**

Aspose.Slides برای Java می‌تواند برای ایجاد فایل‌های ارائه استفاده شود که در آن هر صفحه معادل یک اسلاید است. اسلایدها با باز کردن فایل‌های ارائه با Microsoft PowerPoint قابل مشاهده هستند. اما گاهی‌اوقات توسعه‌دهندگان نیاز به مشاهده تصاویر اشکال به صورت جداگانه در یک نمایشگر تصویر دارند. در چنین مواردی، Aspose.Slides برای Java به آن‌ها کمک می‌کند تا تصاویر بندانگشتی از اشکال اسلاید ایجاد کنند.

این مقاله توضیح می‌دهد که چگونه می‌توان تصاویر بندانگشتی اسلاید را به طرق مختلف ایجاد کرد:

- تولید تصویر بندانگشتی یک شکل داخل اسلاید.
- تولید تصویر بندانگشتی یک شکل برای یک شکل اسلاید با ابعاد تعریف‌شده توسط کاربر.
- تولید تصویر بندانگشتی یک شکل در مرزهای ظاهر شکل.

## **تولید تصویر بندانگشتی یک شکل از اسلاید**
برای تولید تصویر بندانگشتی یک شکل از هر اسلاید با استفاده از Aspose.Slides برای Java، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلاید را با استفاده از شناسه یا اندیس آن به دست آورید.
1. با استفاده از [دریافت تصویر بندانگشتی شکل](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape#getImage--) تصویر بندانگشتی شکل اسلاید مرجع را در مقیاس پیش‌فرض دریافت کنید.
1. تصویر بندانگشتی را در قالب تصویری مورد نظرتان ذخیره کنید.

این کد نمونه نشان می‌دهد چگونه تصویر بندانگشتی یک شکل را از یک اسلاید تولید کنید:

```java
// یک شی از کلاس Presentation که نمایانگر فایل ارائه است را ایجاد کنید
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل ایجاد کنید
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // تصویر را در فرمت PNG روی دیسک ذخیره کنید
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **تولید تصویر بندانگشتی با ضریب مقیاس کاربر تعریف‌شده**
برای تولید تصویر بندانگشتی شکل یک اسلاید با استفاده از Aspose.Slides برای Java، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلاید را با استفاده از شناسه یا اندیس آن به دست آورید.
1. با استفاده از [دریافت تصویر بندانگشتی شکل](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape#getImage-int-float-float-) تصویر بندانگشتی شکل اسلاید مرجع را با ابعاد تعریف‌شده توسط کاربر دریافت کنید.
1. تصویر بندانگشتی را در قالب تصویری مورد نظرتان ذخیره کنید.

این کد نمونه نشان می‌دهد چگونه تصویر بندانگشتی یک شکل را بر اساس ضریب مقیاس تعریف‌شده تولید کنید:

```java
// یک نمونه از کلاس Presentation که فایل ارائه را نمایندگی می‌کند ایجاد کنید
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل ایجاد کنید
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // تصویر را با فرمت PNG روی دیسک ذخیره کنید
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **ایجاد تصویر بندانگشتی ظاهر شکل بر اساس مرزها**
این روش ایجاد تصاویر بندانگشتی اشکال به توسعه‌دهندگان امکان می‌دهد تصویر بندانگشتی را در مرزهای ظاهر شکل تولید کنند. تمام اثرات شکل در نظر گرفته می‌شود. تصویر بندانگشتی تولید شده توسط مرزهای اسلاید محدود می‌شود. برای تولید تصویر بندانگشتی یک شکل اسلاید در مرز ظاهر آن، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلاید را با استفاده از شناسه یا اندیس آن به دست آورید.
1. تصویر بندانگشتی اسلاید مرجع را با مرزهای شکل به عنوان ظاهر دریافت کنید.
1. تصویر بندانگشتی را در قالب تصویری مورد نظرتان ذخیره کنید.

این کد نمونه بر پایهٔ مراحل فوق است:

```java
// یک نمونه از کلاس Presentation که نمایانگر فایل ارائه است، ایجاد کنید
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل ایجاد کنید
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // تصویر را با فرمت PNG روی دیسک ذخیره کنید
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**چه فرمت‌های تصویری می‌توان هنگام ذخیرهٔ تصویر بندانگشتی شکل استفاده کرد؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imageformat/)، و دیگران. شکل‌ها همچنین می‌توانند [صادر شده به‌عنوان SVG برداری](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) باشند با ذخیره محتوای شکل به صورت SVG.

**تفاوت مرزهای Shape و Appearance هنگام رندر تصویر بندانگشتی چیست؟**

`Shape` از هندسهٔ شکل استفاده می‌کند؛ `Appearance` اثرات بصری را در نظر می‌گیرد [اثرهای بصری](/slides/fa/java/shape-effect/) (سایه‌ها، درخشندگی‌ها و غیره).

**اگر یک شکل به‌عنوان مخفی علامت‌گذاری شود چه اتفاقی می‌افتد؟ آیا همچنان به‌عنوان تصویر بندانگشتی رندر می‌شود؟**

یک شکل مخفی همچنان بخشی از مدل است و می‌تواند رندر شود؛ پرچم مخفی فقط نمایش اسلایدشو را تحت تأثیر قرار می‌دهد اما از تولید تصویر شکل جلوگیری نمی‌کند.

**آیا اشکال گروهی، نمودارها، SmartArt و سایر اشیاء پیچیده پشتیبانی می‌شوند؟**

بله. هر شیئی که به‌عنوان [Shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/) (از جمله [GroupShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chart/)، و [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/smartart/)) نمایش داده می‌شود، می‌تواند به‌صورت تصویر بندانگشتی یا SVG ذخیره شود.

**آیا قلم‌های نصب‌شده در سیستم بر کیفیت تصاویر بندانگشتی اشکال متنی تاثیر می‌گذارند؟**

بله. باید [قلم‌های مورد نیاز را فراهم کنید](/slides/fa/java/custom-font/) (یا [جایگزینی قلم‌ها را پیکربندی کنید](/slides/fa/java/font-substitution/)) تا از بازگشت‌های ناخواسته و جابجایی متن جلوگیری شود.