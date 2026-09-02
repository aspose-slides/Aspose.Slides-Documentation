---
title: ایجاد تصویرهای بندانگشتی از شکل‌های ارائه در اندروید
linktitle: تصویرهای بندانگشتی شکل
type: docs
weight: 70
url: /fa/androidjava/create-shape-thumbnails/
keywords:
- تصویر بندانگشتی شکل
- تصویر شکل
- رندر شکل
- رندرینگ شکل
- مرزهای بصری
- مرزهای شکل
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "تصویرهای بندانگشتی با کیفیت بالا از شکل‌های اسلایدهای PowerPoint با Aspose.Slides برای Android از طریق Java تولید کنید – به‌راحتی تصویرهای بندانگشتی ارائه را ایجاد و استخراج کنید."
---
## **مقدمه**

Aspose.Slides for Android via Java می‌تواند برای ایجاد فایل‌های ارائه استفاده شود که در آن هر صفحه متناظر با یک اسلاید است. اسلایدها را می‌توان با باز کردن فایل‌های ارائه با Microsoft PowerPoint مشاهده کرد. اما گاهی اوقات توسعه‌دهندگان نیاز دارند تصاویر شکل‌ها را به‌صورت جداگانه در یک برنامهٔ مشاهده‌کننده تصویر ببینند. در چنین مواردی، Aspose.Slides for Android via Java به آن‌ها کمک می‌کند تا تصاویر بندانگشتی از شکل‌های اسلاید تولید کنند.

در این مطلب، نحوهٔ تولید تصویرهای بندانگشتی اسلاید در شرایط مختلف را نشان می‌دهیم:

- تولید تصویر بندانگشتی یک شکل در داخل اسلاید.
- تولید تصویر بندانگشتی یک شکل اسلاید با ابعاد تعریف‌شده توسط کاربر.
- تولید تصویر بندانگشتی یک شکل در محدودهٔ ظاهر شکل.

## **تولید تصویر بندانگشتی شکل از یک اسلاید**
برای تولید تصویر بندانگشتی یک شکل از هر اسلاید با استفاده از Aspose.Slides for Android via Java، این کار را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلاید را با استفاده از شناسه یا ایندکس آن به‌دست آورید.
1. [دریافت تصویر بندانگشتی شکل](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#getImage--) از اسلاید مرجع با مقیاس پیش‌فرض.
1. تصویر بندانگشتی را در قالب تصویر موردنظر خود ذخیره کنید.

این نمونه کد نشان می‌دهد چگونه تصویر بندانگشتی یک شکل را از یک اسلاید تولید کنید:

```java
// یک شیء از کلاس Presentation بسازید که نمایانگر فایل ارائه است
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل بسازید
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // تصویر را در قالب PNG روی دیسک ذخیره کنید
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **تولید تصویر بندانگشتی با مقیاس‌ساز تعریف‌شده توسط کاربر**
برای تولید تصویر بندانگشتی شکل یک اسلاید با استفاده از Aspose.Slides for Android via Java، این کار را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلاید را با استفاده از شناسه یا ایندکس آن به‌دست آورید.
1. [دریافت تصویر بندانگشتی شکل](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) از اسلاید مرجع با ابعاد تعریف‌شده توسط کاربر.
1. تصویر بندانگشتی را در قالب تصویر موردنظر خود ذخیره کنید.

این نمونه کد نشان می‌دهد چگونه تصویر بندانگشتی یک شکل را بر اساس یک عامل مقیاس‌ساز تعریف‌شده تولید کنید:

```java
// یک شیء از کلاس Presentation بسازید که نمایانگر فایل ارائه است
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل بسازید
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // تصویر را در قالب PNG روی دیسک ذخیره کنید
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **ایجاد تصویر بندانگشتی ظاهر شکل مبتنی بر محدوده**
این روش ایجاد تصویرهای بندانگشتی از شکل‌ها به توسعه‌دهندگان اجازه می‌دهد تا تصویری بندانگشتی در محدودهٔ ظاهر شکل تولید کنند. تمام اثرات شکل در نظر گرفته می‌شود. تصویر بندانگشتی تولید‌شده توسط محدودهٔ اسلاید محدود می‌شود. برای تولید تصویر بندانگشتی یک شکل اسلاید در محدودهٔ ظاهر آن، این کار را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلاید را با استفاده از شناسه یا ایندکس آن به‌دست آورید.
1. تصویر بندانگشتی اسلاید مرجع را با مرزهای شکل به‌عنوان ظاهر دریافت کنید.
1. تصویر بندانگشتی را در قالب تصویر موردنظر خود ذخیره کنید.

این نمونه کد بر پایهٔ مراحل فوق است:

```java
// یک شیء از کلاس Presentation بسازید که نمایانگر فایل ارائه است
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل بسازید
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // تصویر را در قالب PNG روی دیسک ذخیره کنید
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **دریافت مرزهای بصری واقعی یک شکل**
ویژگی‌های چارچوب [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/)—متدهای `getX()`, `getY()`, `getWidth()`, و `getHeight()` آن—مستطیلی را که در مدل ارائه ذخیره شده توصیف می‌کنند. محتوای واقعاً رندر شده می‌تواند فراتر از آن چارچوب گسترش یابد یا مستطیل محور محور متفاوتی را اشغال کند. چرخش، خطوط پیرامونی، سرپنجه‌ها، چینش و سرریز متن، هندسهٔ تولید شدهٔ SmartArt و سایر اثرات رندر می‌توانند تماماً ناحیهٔ اشغالی را تغییر دهند.

از [Shape.getVisualBounds](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getVisualBounds--) برای محاسبهٔ آن ناحیهٔ اشغالی بدون ایجاد تصویر استفاده کنید. این متد یک [RectF](https://developer.android.com/reference/android/graphics/RectF) در مختصات اسلاید برمی‌گرداند. مستطیل برگشتی به اسلاید قطع نمی‌شود، بنابراین مختصات آن می‌تواند منفی باشد وقتی محتوا فراتر از مبدأ اسلاید گسترش یابد.

در حال حاضر [Shape.getVisualBounds](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getVisualBounds--) توسط رابط [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) اعلام نشده است. بنابراین، شکل به‌دست‌آمده از مجموعهٔ شکل‌های اسلاید را به‌عنوان مقدار رابط نگه دارید و تنها هنگام فراخوانی متد آن را تبدیل (cast) کنید.

مثال زیر چارچوب و مرزهای بصری را دریافت و مقایسه می‌کند:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

همان [RectF](https://developer.android.com/reference/android/graphics/RectF) می‌تواند برای هم‌ترازی شکل‌های نزدیک به لبهٔ چپ، راست، بالا یا پایین آن استفاده شود؛ فضای کافی در یک چیدمان تولیدشده حفظ کند؛ یا محتوا را خارج از ناحیهٔ مجاز شناسایی کند. مرزهای بصری به‌ویژه برای SmartArt، جعبه‌های متن، پیکان‌ها، تصاویر، شکل‌های چرخان و گروهی مفید هستند، جایی که چارچوب ذخیره‌شده ممکن است نمای کامل رندر شده را نشان ندهد.

از [Shape.getVisualBounds](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getVisualBounds--) زمانی که به مختصات برای چیدمان یا اعتبارسنجی نیاز دارید و به bitmap نیازی ندارید، استفاده کنید. از [IShape.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getImage--) وقتی که نیاز به رندر شکل دارید، استفاده کنید. با [ShapeThumbnailBounds](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapethumbnailbounds/)، `ShapeThumbnailBounds.Shape` تصویر را از مرزهای شکل، شامل تنظیمات خطوط پیرامونی، اندازه‌گیری می‌کند، در حالی که `ShapeThumbnailBounds.Appearance` آن را از ظاهر شکل اندازه‌گیری می‌کند و نتیجه را به مرزهای اسلاید محدود می‌کند. برعکس، [Shape.getVisualBounds](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getVisualBounds--) فقط مستطیل محاسبه‌شده را برمی‌گرداند و آن را به اسلاید قطع نمی‌کند.

## **پرسش‌های متداول**

**چه قالب‌های تصویری می‌توانند هنگام ذخیرهٔ تصویرهای بندانگشتی شکل استفاده شوند؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imageformat/)، و سایرین. همچنین می‌توان شکل‌ها را به‌صورت [SVG برداری صادر کرد](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) با ذخیرهٔ محتویات شکل به‌صورت SVG.

**تفاوت بین مرزهای Shape و Appearance هنگام رندر تصویر بندانگشتی چیست؟**

`Shape` از هندسهٔ شکل استفاده می‌کند؛ `Appearance` اثرات بصری [visual effects](/slides/fa/androidjava/shape-effect/) (سایه‌ها، تابش‌ها و غیره) را در نظر می‌گیرد.

**اگر یک شکل به‌عنوان مخفی علامت‌گذاری شود، چه اتفاقی می‌افتد؟ آیا همچنان به‌عنوان تصویر بندانگشتی رندر می‌شود؟**

یک شکل مخفی همچنان بخشی از مدل باقی می‌ماند و می‌تواند رندر شود؛ پرچم مخفی بودن بر نمایش اسلایدشو تأثیر می‌گذارد اما جلوی تولید تصویر شکل را نمی‌گیرد.

**آیا شکل‌های گروهی، نمودارها، SmartArt و سایر اشیای پیچیده پشتیبانی می‌شوند؟**

بله. هر شیئی که به‌صورت [Shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/) نمایان شده باشد (از جمله [GroupShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chart/)، و [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/smartart/)) می‌تواند به‌عنوان تصویر بندانگشتی یا به‌صورت SVG ذخیره شود.

**آیا فونت‌های نصب‌شده در سیستم بر کیفیت تصویرهای بندانگشتی برای شکل‌های متنی تأثیر می‌گذارند؟**

بله. باید [فونت‌های موردنیاز را فراهم کنید](/slides/fa/androidjava/custom-font/) (یا [جایگزینی فونت‌ها را پیکربندی کنید](/slides/fa/androidjava/font-substitution/)) تا از واگذاری‌های ناخواسته و دوباره‌چیدمان متن جلوگیری شود.