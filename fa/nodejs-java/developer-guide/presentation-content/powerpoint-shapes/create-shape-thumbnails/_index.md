---
title: ایجاد بندانگشتی‌های اشکال ارائه در JavaScript
linktitle: بندانگشتی شکل
type: docs
weight: 70
url: /fa/nodejs-java/create-shape-thumbnails/
keywords:
- بندانگشتی شکل
- تصویر شکل
- رندر شکل
- رندرینگ شکل
- مرزهای بصری
- مرزهای شکل
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "تولید بندانگشتی‌های با کیفیت بالا برای اشکال اسلایدهای PowerPoint با استفاده از JavaScript و Aspose.Slides برای Node.js – به‌راحتی بندانگشتی‌های ارائه را ایجاد و صادرات کنید."
---
## **معرفی**

Aspose.Slides برای ایجاد فایل‌های ارائه استفاده می‌شود که در هر صفحه یک اسلاید است. این اسلایدها با باز کردن فایل‌های ارائه با Microsoft PowerPoint قابل مشاهده هستند. اما گاهی توسعه‌دهندگان ممکن است نیاز داشته باشند تصاویر اشکال را به‌صورت جداگانه در یک نمایشگر تصویر مشاهده کنند. در چنین مواردی، Aspose.Slides به شما کمک می‌کند تا تصاویر بندانگشتی از اشکال اسلاید تولید کنید. نحوه استفاده از این ویژگی در این مقاله توضیح داده شده است.

این مقاله توضیح می‌دهد چگونه می‌توان بندانگشتی‌های اسلاید را به روش‌های مختلف تولید کرد:

- تولید بندانگشتی یک شکل داخل اسلاید.
- تولید بندانگشتی یک شکل برای شکل اسلاید با ابعاد تعریف‌شده توسط کاربر.
- تولید بندانگشتی یک شکل در مرزهای ظاهر شکل.

## **تولید بندانگشتی شکل از اسلایدها**

برای تولید یک بندانگشتی شکل از هر اسلاید با استفاده از Aspose.Slides برای Node.js از طریق Java، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلایدی را با استفاده از شناسه یا ایندکس آن به دست آورید.
1. [دریافت تصویر بندانگشتی شکل](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getImage--) از اسلاید مرجع با مقیاس پیش‌فرض.
1. تصویر بندانگشت را در قالب تصویر دلخواه خود ذخیره کنید.

این کد نمونه نشان می‌دهد چگونه یک بندانگشتی شکل را از یک اسلاید تولید کنید:

```javascript
// یک شیء از کلاس Presentation ایجاد کنید که فایل ارائه را نشان می‌دهد
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل ایجاد کنید
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // تصویر را به‌صورت فرمت PNG در دیسک ذخیره کنید
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

## **تولید بندانگشتی شکل با عامل مقیاس‌گذاری تعریف‌شده توسط کاربر**

برای تولید بندانگشتی شکل یک اسلاید با استفاده از Aspose.Slides برای Node.js از طریق Java، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلایدی را با استفاده از شناسه یا ایندکس آن به دست آورید.
1. [دریافت تصویر بندانگشتی شکل](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) از اسلاید مرجع با ابعاد تعریف‌شده توسط کاربر.
1. تصویر بندانگشت را در قالب تصویر دلخواه خود ذخیره کنید.

این کد نمونه نشان می‌دهد چگونه یک بندانگشتی شکل را بر اساس عامل مقیاس‌گذاری تعریف‌شده تولید کنید:

```javascript
// یک شیء از کلاس Presentation ایجاد کنید که فایل ارائه را نشان می‌دهد
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل ایجاد کنید
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // تصویر را به‌صورت فرمت PNG در دیسک ذخیره کنید
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

## **تولید بندانگشتی شکل در مرزها**

این روش ایجاد بندانگشتی‌های اشکال به توسعه‌دهندگان امکان می‌دهد تا یک بندانگشتی را در مرزهای ظاهر شکل تولید کنند. این روش تمام اثرات شکل را در نظر می‌گیرد. بندانگشتی شکل تولید شده توسط مرزهای اسلاید محدود می‌شود. برای تولید یک بندانگشتی از یک شکل اسلاید در مرز ظاهر آن، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلایدی را با استفاده از شناسه یا ایندکس آن به دست آورید.
1. تصویر بندانگشتی اسلاید مرجع را با مرزهای شکل به‌عنوان ظاهر دریافت کنید.
1. تصویر بندانگشت را در قالب تصویر دلخواه خود ذخیره کنید.

این کد نمونه بر اساس مراحل فوق است:

```javascript
// یک شیء از کلاس Presentation ایجاد کنید که فایل ارائه را نشان می‌دهد
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل ایجاد کنید
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // تصویر را به‌صورت فرمت PNG در دیسک ذخیره کنید
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

## **دریافت مرزهای بصری واقعی یک شکل**

ویژگی‌های چارچوب یک [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) — متدهای `getX()`، `getY()`، `getWidth()` و `getHeight()` — مستطیل ذخیره‌شده در مدل ارائه را توصیف می‌کنند. محتوایی که واقعاً رندر می‌شود می‌تواند فراتر از آن چارچوب گسترش یابد یا مستطیل دیگری با محورهای هم‌راستا اشغال کند. چرخش، خطوط پیرامونی، سرهای پیکان، چینش متن و سرریز، هندسهٔ تولیدشدهٔ SmartArt و سایر اثرات رندر می‌توانند تماماً ناحیهٔ اشغال‌شده را تغییر دهند.

از [Shape.getVisualBounds](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getVisualBounds--) برای محاسبهٔ آن ناحیهٔ اشغال‌شده بدون ایجاد تصویر استفاده کنید. این متد یک شیء [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) را در مختصات اسلاید باز می‌گرداند. مستطیل بازگشتی به اسلاید برش نمی‌خورد، به‌طوری‌که مختصات آن می‌تواند منفی باشد وقتی محتوا فراتر از مبدا اسلاید گسترش می‌یابد.

مثال زیر چارچوب و مرزهای بصری را دریافت و مقایسه می‌کند:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

همان مستطیل می‌تواند برای تراز کردن اشکال نزدیک به لبهٔ چپ، راست، بالا یا پایین آن؛ رزرو فضای کافی در یک چیدمان تولید شده؛ یا تشخیص محتوا خارج از ناحیهٔ مجاز استفاده شود. مرزهای بصری به‌ویژه برای SmartArt، جعبه‌های متن، پیکان‌ها، تصاویر، اشکال چرخانده‌شده و گروه اشکال مفید هستند، جایی که چارچوب ذخیره‌شده ممکن است نتیجهٔ رندر کامل را نشان ندهد.

از [Shape.getVisualBounds](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getVisualBounds--) زمانی که به مختصات برای چیدمان یا اعتبارسنجی نیاز دارید و به تصویر بیت‌مپ نیازی ندارید استفاده کنید. برای رندر کردن شکل، از [Shape.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getImage--) استفاده کنید. با [ShapeThumbnailBounds](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapethumbnailbounds/)، `ShapeThumbnailBounds.Shape` اندازهٔ تصویر را از مرزهای شکل، شامل تنظیمات خطوط پیرامونی، گرفته و `ShapeThumbnailBounds.Appearance` اندازهٔ آن را از ظاهر شکل می‌گیرد و نتیجه را به مرزهای اسلاید محدود می‌کند. در مقابل، [Shape.getVisualBounds](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getVisualBounds--) فقط مستطیل محاسبه‌شده را باز می‌گرداند و آن را به اسلاید برش نمی‌دهد.

## **سوالات متداول**

**چه فرمت‌های تصویری می‌توان هنگام ذخیره‌سازی بندانگشتی‌های شکل استفاده کرد؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imageformat/)، و سایر فرمت‌ها. اشکال همچنین می‌توانند به عنوان SVG برداری [صادر شوند](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/writeassvg/) با ذخیره‌سازی محتوای شکل به صورت SVG.

**تفاوت بین مرزهای Shape و Appearance هنگام رندر کردن یک بندانگشتی چیست؟**

`Shape` از هندسهٔ شکل استفاده می‌کند؛ `Appearance` اثرات بصری [visual effects](/slides/fa/nodejs-java/shape-effect/) (سایه‌ها، تابش‌ها و غیره) را در نظر می‌گیرد.

**اگر یک شکل به‌عنوان مخفی علامت‌گذاری شود چه اتفاقی می‌افتد؟ آیا هنوز به‌عنوان بندانگشتی رندر می‌شود؟**

یک شکل مخفی همچنان بخشی از مدل است و می‌تواند رندر شود؛ پرچم مخفی فقط نمایش اسلایدشو را تحت تأثیر قرار می‌دهد اما از تولید تصویر شکل جلوگیری نمی‌کند.

**آیا اشکال گروهی، نمودارها، SmartArt و سایر اشیاء پیچیده پشتیبانی می‌شوند؟**

بله. هر شیئی که به عنوان [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) نمایان شود (از جمله [GroupShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/)، و [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartart/)) می‌تواند به‌عنوان بندانگشتی یا به‌صورت SVG ذخیره شود.

**آیا فونت‌های نصب‌شده در سیستم بر کیفیت بندانگشتی‌های اشکال متنی تأثیر می‌گذارند؟**

بله. باید [فونت‌های مورد نیاز](/slides/fa/nodejs-java/custom-font/) (یا [جایگزینی‌های فونت](/slides/fa/nodejs-java/font-substitution/)) را فراهم کنید تا از بازگشت‌های ناخواسته و بازچیدمان متن جلوگیری شود.