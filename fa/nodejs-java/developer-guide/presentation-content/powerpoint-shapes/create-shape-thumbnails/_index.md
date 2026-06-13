---
title: ایجاد تصویرهای بندانگشتی از اشکال ارائه در جاوااسکریپت
linktitle: بندانگشت‌های شکل
type: docs
weight: 70
url: /fa/nodejs-java/create-shape-thumbnails/
keywords:
- بندانگشت شکل
- تصویر شکل
- رندر شکل
- رندرینگ شکل
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "تصاویر بندانگشتی با کیفیت بالا از اشکال اسلایدهای PowerPoint را با JavaScript و Aspose.Slides برای Node.js تولید کنید – به‌راحتی تصویرهای بندانگشت ارائه را ایجاد و صادر کنید."
---
## **مقدمه**

Aspose.Slides برای ایجاد فایل‌های ارائه استفاده می‌شود که هر صفحه‌ای یک اسلاید است. این اسلایدها می‌توانند با باز کردن فایل‌های ارائه با Microsoft PowerPoint مشاهده شوند. اما گاهی اوقات، توسعه‌دهندگان ممکن است نیاز داشته باشند تصاویر اشکال را به‌صورت جداگانه در یک نمایشگر تصویر ببینند. در چنین مواردی، Aspose.Slides به شما کمک می‌کند تا تصاویر بندانگشتی اشکال اسلاید را تولید کنید. نحوه استفاده از این ویژگی در این مقاله توضیح داده شده است.

این مقاله توضیح می‌دهد که چگونه می‌توان تصویر بندانگشتی اسلایدها را به روش‌های مختلف تولید کرد:

- تولید تصویر بندانگشتی یک شکل درون یک اسلاید.
- تولید تصویر بندانگشتی یک شکل اسلاید با ابعاد تعریف‌شده توسط کاربر.
- تولید تصویر بندانگشتی یک شکل در محدوده ظاهر شکل.

## **تولید تصویر بندانگشتی شکل‌ها از اسلایدها**

برای تولید تصویر بندانگشتی یک شکل از هر اسلاید با استفاده از Aspose.Slides برای Node.js از طریق Java، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلایدی را با استفاده از شناسه یا اندی‌کس آن به‌دست آورید.
1. [دریافت تصویر بندانگشتی شکل](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getImage--) مربوط به اسلاید مرجع را با مقیاس پیش‌فرض دریافت کنید.
1. تصویر بندانگشتی را در قالب تصویری مورد نظر خود ذخیره کنید.

این کد نمونه نشان می‌دهد چگونه می‌توانید تصویر بندانگشتی یک شکل را از یک اسلاید تولید کنید:

```javascript
// یک شیء از کلاس Presentation که نمایانگر فایل ارائه است ایجاد کنید
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل ایجاد کنید
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // تصویر را به‌صورت PNG در دیسک ذخیره کنید
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
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

## **تولید تصویر بندانگشتی شکل‌ها با عامل مقیاس‌بندی تعریف‌شده توسط کاربر**

برای تولید تصویر بندانگشتی شکل یک اسلاید با استفاده از Aspose.Slides برای Node.js از طریق Java، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلایدی را با استفاده از شناسه یا اندی‌کس آن به‌دست آورید.
1. [دریافت تصویر بندانگشتی شکل](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) مربوط به اسلاید مرجع را با ابعاد تعریف‌شده توسط کاربر دریافت کنید.
1. تصویر بندانگشتی را در قالب تصویری مورد نظر خود ذخیره کنید.

این کد نمونه نشان می‌دهد چگونه می‌توانید تصویر بندانگشتی یک شکل را بر اساس عامل مقیاس‌بندی تعریف‌شده تولید کنید:

```javascript
// یک شیء از کلاس Presentation که نمایانگر فایل ارائه است ایجاد کنید
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل ایجاد کنید
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // تصویر را به‌صورت PNG در دیسک ذخیره کنید
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
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

## **تولید تصویر بندانگشتی شکل در محدوده**

این روش ایجاد تصویرهای بندانگشتی برای اشکال به توسعه‌دهندگان امکان می‌دهد تا یک تصویر بندانگشت را در محدوده ظاهر شکل تولید کنند. تمام اثرات شکل در نظر گرفته می‌شود. تصویر بندانگشتی تولید شده توسط محدوده اسلاید محدود می‌شود. برای تولید تصویر بندانگشتی یک شکل اسلاید در محدوده ظاهر آن، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلایدی را با استفاده از شناسه یا اندی‌کس آن به‌دست آورید.
1. تصویر بندانگشتی اسلاید مرجع را با استفاده از مرزهای شکل به‌عنوان ظاهر دریافت کنید.
1. تصویر بندانگشتی را در قالب تصویری مورد نظر خود ذخیره کنید.

این کد نمونه بر مبنای مراحل فوق است:

```javascript
// یک شیء از کلاس Presentation که نمایانگر فایل ارائه است ایجاد کنید
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل ایجاد کنید
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // تصویر را به‌صورت PNG در دیسک ذخیره کنید
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
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

## **سؤالات متداول**

**چه قالب‌های تصویری می‌توان هنگام ذخیره تصویر بندانگشتی شکل استفاده کرد؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imageformat/)، و سایر قالب‌ها. اشکال می‌توانند همچنین [صادرات به صورت SVG برداری](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/writeassvg/) با ذخیره محتوای شکل به‌صورت SVG.

**تفاوت بین محدوده Shape و Appearance هنگام رندر تصویر بندانگشتی چیست؟**

`Shape` از هندسه شکل استفاده می‌کند؛ `Appearance` اثرات [تاثیرات بصری](/slides/fa/nodejs-java/shape-effect/) (سایه‌ها، نورها و غیره) را در نظر می‌گیرد.

**اگر یک شکل به‌عنوان hidden علامت‌گذاری شود چه اتفاقی می‌افتد؟ آیا همچنان به‌عنوان تصویر بندانگشتی رندر می‌شود؟**

یک شکل مخفی همچنان بخشی از مدل باقی می‌ماند و می‌تواند رندر شود؛ پرچم hidden فقط نمایش اسلاید شو را تحت تأثیر قرار می‌دهد اما مانع تولید تصویر شکل نمی‌شود.

**آیا اشکال گروهی، نمودارها، SmartArt و سایر اشیاء پیچیده پشتیبانی می‌شوند؟**

بله. هر شیئی که به‌صورت [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) نمایش داده می‌شود (از جمله [GroupShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/)، و [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartart/)) می‌تواند به‌صورت تصویر بندانگشتی یا SVG ذخیره شود.

**آیا فونت‌های نصب‌شده در سیستم بر کیفیت تصویر بندانگشتی برای اشکال متن تأثیر می‌گذارند؟**

بله. شما باید [فراهم کردن فونت‌های مورد نیاز](/slides/fa/nodejs-java/custom-font/) (یا [پیکربندی جایگزینی فونت‌ها](/slides/fa/nodejs-java/font-substitution/)) را انجام دهید تا از fallbackهای ناخواسته و بازچیدگی متن جلوگیری کنید.