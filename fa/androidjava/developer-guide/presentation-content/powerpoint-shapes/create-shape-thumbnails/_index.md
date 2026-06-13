---
title: ایجاد تصویرهای بندانگشتی اشکال ارائه در اندروید
linktitle: تصاویر بندانگشتی شکل‌ها
type: docs
weight: 70
url: /fa/androidjava/create-shape-thumbnails/
keywords:
- تصویر بندانگشتی شکل
- تصویر شکل
- رندر شکل
- رندرینگ شکل
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "با Aspose.Slides برای اندروید از طریق جاوا، تصویرهای بندانگشتی با کیفیت بالا از اشکال اسلایدهای پاورپوینت تولید کنید – به راحتی تصویرهای بندانگشتی ارائه را ایجاد و صادر کنید."
---
## **مقدمه**

Aspose.Slides for Android via Java می‌تواند برای ایجاد فایل‌های ارائه استفاده شود که در آن هر صفحه معادل یک اسلاید است. اسلایدها می‌توانند با باز کردن فایل‌های ارائه با Microsoft PowerPoint مشاهده شوند. با این حال، گاهی توسعه‌دهندگان نیاز دارند تصاویر شکل‌ها را به‌طور جداگانه در یک نمایشگر تصویر ببینند. در این موارد، Aspose.Slides for Android via Java به آن‌ها کمک می‌کند تا تصاویر بندانگشتی از شکل‌های اسلاید تولید کنند.

در این مطلب، نحوه تولید تصویر بندانگشتی اسلاید در موقعیت‌های مختلف را نشان خواهیم داد:

- تولید تصویر بندانگشتی یک شکل داخل اسلاید.
- تولید تصویر بندانگشتی یک شکل اسلاید با ابعاد تعریف‌شده توسط کاربر.
- تولید تصویر بندانگشتی یک شکل در مرزهای ظاهر شکل.

## **تولید تصویر بندانگشتی یک شکل از اسلاید**
برای تولید تصویر بندانگشتی یک شکل از هر اسلاید با استفاده از Aspose.Slides for Android via Java، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
2. مرجع هر اسلایدی را با استفاده از شناسه یا نمایه آن به دست آورید.
3. از اسلاید مرجع با استفاده از [Get the shape thumbnail image](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#getImage--) تصویر بندانگشت شکل را با مقیاس پیش‌فرض دریافت کنید.
4. تصویر بندانگشتی را در قالب تصویر مورد نظر خود ذخیره کنید.

این کد نمونه نشان می‌دهد چگونه یک تصویر بندانگشتی شکل را از یک اسلاید تولید کنید:

```java
// یک نمونه از کلاس Presentation ایجاد کنید که نمایانگر فایل ارائه است
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل ایجاد کنید
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // تصویر را به صورت PNG در دیسک ذخیره کنید
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **تولید تصویر بندانگشتی با مقیاس کاربر-تعریف‌شده**
برای تولید تصویر بندانگشتی شکل یک اسلاید با استفاده از Aspose.Slides for Android via Java، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
2. مرجع هر اسلایدی را با استفاده از شناسه یا نمایه آن به دست آورید.
3. با استفاده از [Get the shape thumbnail image](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) از اسلاید مرجع، تصویر بندانگشت شکل را با ابعاد تعریف‌شده توسط کاربر دریافت کنید.
4. تصویر بندانگشتی را در قالب تصویر مورد نظر خود ذخیره کنید.

این کد نمونه نشان می‌دهد چگونه یک تصویر بندانگشت شکل را بر اساس یک عامل مقیاس تعریف‌شده تولید کنید:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر فایل ارائه است
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل ایجاد کنید
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // تصویر را به صورت PNG در دیسک ذخیره کنید
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **ایجاد تصویر بندانگشت ظاهر شکل بر پایه مرزها**
این روش ایجاد تصویر بندانگشتی برای شکل‌ها به توسعه‌دهندگان امکان می‌دهد تا تصویر بندانگشتی را در مرزهای ظاهر شکل تولید کنند. تمام افکت‌های شکل را در نظر می‌گیرد. تصویر بندانگشتی شکل تولید شده توسط مرزهای اسلاید محدود می‌شود. برای تولید تصویر بندانگشتی یک شکل اسلاید در مرز ظاهر آن، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
2. مرجع هر اسلایدی را با استفاده از شناسه یا نمایه آن به دست آورید.
3. تصویر بندانگشتی اسلاید مرجع را با مرزهای شکل به‌عنوان ظاهر دریافت کنید.
4. تصویر بندانگشتی را در قالب تصویر مورد نظر خود ذخیره کنید.

این کد نمونه بر پایه مراحل بالا است:

```java
// یک نمونه از کلاس Presentation که نمایانگر فایل ارائه است
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل ایجاد کنید
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // تصویر را به صورت PNG در دیسک ذخیره کنید
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**چه قالب‌های تصویری می‌توانند هنگام ذخیره تصویر بندانگشتی شکل استفاده شوند؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imageformat/)، و سایر فرمت‌ها. شکل‌ها همچنین می‌توانند با ذخیره محتوای شکل به‌صورت SVG، به‌صورت [exported as vector SVG](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) صادر شوند.

**تفاوت بین مرزهای Shape و Appearance هنگام رندر تصویر بندانگشتی چیست؟**

`Shape` از ژئومتری شکل استفاده می‌کند؛ `Appearance` اثرات بصری را که در [visual effects](/slides/fa/androidjava/shape-effect/) (سایه‌ها، درخشندگی‌ها و غیره) آمده است، در نظر می‌گیرد.

**اگر یک شکل به‌عنوان hidden علامت‌گذاری شود چه اتفاقی می‌افتد؟ آیا همچنان به‌عنوان تصویر بندانگشتی رندر می‌شود؟**

یک شکل مخفی بخشی از مدل باقی می‌ماند و می‌تواند رندر شود؛ پرچم hidden نمایش اسلایدشو را تحت تأثیر قرار می‌دهد اما از تولید تصویر شکل جلوگیری نمی‌کند.

**آیا شکل‌های گروهی، نمودارها، SmartArt و سایر اشیاء پیچیده پشتیبانی می‌شوند؟**

بله. هر شیئی که به‌عنوان [Shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/) نمایش داده می‌شود (از جمله [GroupShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chart/)، و [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/smartart/)) می‌تواند به‌صورت تصویر بندانگشت یا SVG ذخیره شود.

**آیا قلم‌های نصب‌شده در سیستم بر کیفیت تصویر بندانگشتی شکل‌های متنی تأثیر می‌گذارند؟**

بله. شما باید [provide the required fonts](/slides/fa/androidjava/custom-font/) (یا [configure font substitutions](/slides/fa/androidjava/font-substitution/)) را فراهم کنید تا از فراخوانی‌های ناخواسته و بازچیدمان متن جلوگیری شود.