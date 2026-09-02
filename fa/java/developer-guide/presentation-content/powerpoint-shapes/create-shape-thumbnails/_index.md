---
title: "ایجاد تصویرهای بندانگشتی برای اشکال ارائه در جاوا"
linktitle: "بندانگشت‌های شکل"
type: docs
weight: 70
url: /fa/java/create-shape-thumbnails/
keywords:
- "بندانگشت شکل"
- "تصویر شکل"
- "رندر شکل"
- "رندرینگ شکل"
- "حدود بصری"
- "حدود شکل"
- "PowerPoint"
- "ارائه"
- "Java"
- "Aspose.Slides"
description: "بندانگشت‌های شکل با کیفیت بالا را از اسلایدهای PowerPoint با Aspose.Slides برای جاوا تولید کنید – به راحتی تصویرهای بندانگشتی ارائه را ایجاد و صادر کنید."
---
## **معرفی**

Aspose.Slides for Java می‌تواند برای ایجاد فایل‌های ارائه‌ای استفاده شود که در آن هر صفحه معادل یک اسلاید است. اسلایدها با باز کردن فایل‌های ارائه با Microsoft PowerPoint قابل مشاهده هستند. با این حال، بعضی اوقات توسعه‌دهندگان نیاز دارند تصاویر اشکال را به‌صورت جداگانه در یک نمایشگر تصویر ببینند. در چنین مواردی، Aspose.Slides for Java به آن‌ها کمک می‌کند تا تصاویر بندانگشتی از اشکال اسلاید تولید کنند.

این مقاله توضیح می‌دهد که چگونه می‌توان بندانگشتی‌های اسلاید را به طرق مختلف تولید کرد:

- تولید تصویر بندانگشتی یک شکل داخل اسلاید.
- تولید تصویر بندانگشتی یک شکل برای شکل اسلاید با ابعاد تعریف‌شده توسط کاربر.
- تولید تصویر بندانگشتی یک شکل در محدوده ظاهر شکل.

## **تولید تصویر بندانگشتی یک شکل از اسلاید**

برای تولید تصویر بندانگشتی یک شکل از هر اسلاید با استفاده از Aspose.Slides for Java، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. مرجع هر اسلایدی را با استفاده از شناسه یا ایندکس آن دریافت کنید.
3. [دریافت تصویر بندانگشتی شکل](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getImage--) از اسلاید مرجع با مقیاس پیش‌فرض دریافت کنید.
4. تصویر بندانگشتی را در قالب تصویر مورد نظر خود ذخیره کنید.

```java
// یک شیء از کلاس Presentation ایجاد کنید که فایل ارائه را نشان می‌دهد
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل ایجاد کنید
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

## **تولید تصویر بندانگشتی با ضریب مقیاس‌گذاری تعریف‌شده توسط کاربر**

برای تولید تصویر بندانگشتی شکل یک اسلاید با استفاده از Aspose.Slides for Java، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. مرجع هر اسلایدی را با استفاده از شناسه یا ایندکس آن دریافت کنید.
3. [دریافت تصویر بندانگشتی شکل](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getImage-int-float-float-) از اسلاید مرجع با ابعاد تعریف‌شده توسط کاربر دریافت کنید.
4. تصویر بندانگشتی را در قالب تصویر مورد نظر خود ذخیره کنید.

```java
// یک شیء از کلاس Presentation ایجاد کنید که فایل ارائه را نمایان می‌کند
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل ایجاد کنید
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

این روش ایجاد بندانگشتی‌های اشکال به توسعه‌دهندگان امکان می‌دهد تا تصویر بندانگشتی را در محدودهٔ ظاهر شکل تولید کنند. تمام اثرات شکل در نظر گرفته می‌شود. تصویر بندانگشتی تولید شده توسط محدودهٔ اسلاید محدود می‌شود. برای تولید بندانگشتی یک شکل اسلاید در محدودهٔ ظاهر آن، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. مرجع هر اسلایدی را با استفاده از شناسه یا ایندکس آن دریافت کنید.
3. تصویر بندانگشتی اسلاید مرجع را با محدودهٔ شکل به عنوان ظاهر دریافت کنید.
4. تصویر بندانگشتی را در قالب تصویر مورد نظر خود ذخیره کنید.

```java
// یک شیء از کلاس Presentation ایجاد کنید که فایل ارائه را نشان می‌دهد
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // یک تصویر با مقیاس کامل ایجاد کنید
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

## **دریافت حدود بصری واقعی یک شکل**

ویژگی‌های چارچوب [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/)—متدهای `getX()`, `getY()`, `getWidth()`, و `getHeight()`—مستطیل ذخیره‌شده در مدل ارائه را توصیف می‌کنند. محتوایی که واقعاً رندر می‌شود می‌تواند فراتر از آن چارچوب گسترش یابد یا مستطیل محور‑محور متفاوتی را اشغال کند. چرخش، خطوط مرزی، سرهای پیکان، چینش متن و سرریز، هندسهٔ SmartArt تولیدشده و سایر اثرات رندر می‌توانند تماماً مساحت اشغالی را تغییر دهند.

از [Shape.getVisualBounds](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getVisualBounds--) برای محاسبهٔ آن ناحیهٔ اشغالی بدون ایجاد تصویر استفاده کنید. این متد یک [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) به‌عنوان مختصات اسلاید برمی‌گرداند. مستطیل بازگردانده‌شده به اسلاید کلیپ نمی‌شود، بنابراین مختصات آن می‌تواند در زمانیکه محتوا فراتر از مبدأ اسلاید گسترش یابد، منفی باشد.

[Shape.getVisualBounds](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getVisualBounds--) در حال حاضر توسط رابط [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) اعلام نشده است. بنابراین، شکل دریافت‌شده از مجموعهٔ اشکال اسلاید را به‌عنوان مقدار رابط نگه دارید و فقط هنگام فراخوانی متد آن را کست کنید.

مثال زیر حدود چارچوب و حدود بصری را دریافت و مقایسه می‌کند:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

همان [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) می‌تواند برای تراز کردن اشکال نزدیک به سمت چپ، راست، بالا یا پایین آن استفاده شود؛ فضای کافی در یک چیدمان تولیدی اختصاص دهد؛ یا محتوای خارج از ناحیهٔ مجاز را شناسایی کند. حدود بصری به‌ویژه برای SmartArt، جعبه‌های متن، پیکان‌ها، تصاویر، اشکال چرخانده‌شده و گروه‌اشکال مفید هستند، جایی که چارچوب ذخیره‌شده ممکن است نتیجهٔ رندر کامل را نشان ندهد.

از [Shape.getVisualBounds](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getVisualBounds--) وقتی به مختصات برای چیدمان یا اعتبارسنجی نیاز دارید و نیازی به bitmap ندارید استفاده کنید. وقتی نیاز به رندر کردن شکل دارید، از [IShape.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getImage--) استفاده کنید. با [ShapeThumbnailBounds](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapethumbnailbounds/)، `ShapeThumbnailBounds.Shape` تصویر را از حدود شکل، شامل تنظیمات خط مرزی، اندازه می‌دهد، در حالی که `ShapeThumbnailBounds.Appearance` آن را از ظاهر شکل اندازه می‌کند و نتیجه را به حدود اسلاید محدود می‌سازد. در مقابل، [Shape.getVisualBounds](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getVisualBounds--) فقط مستطیل محاسبه‌شده را برمی‌گرداند و آن را به اسلاید کلیپ نمی‌کند.

## **سوالات رایج**

**چه قالب‌های تصویری می‌توان هنگام ذخیره‌سازی تصویر بندانگشتی شکل استفاده کرد؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imageformat/)، و سایر فرم‌ها. اشکال همچنین می‌توانند [به‌صورت SVG برداری صادر شوند](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) با ذخیره‌سازی محتوای شکل به‌عنوان SVG.

**تفاوت حدود Shape و Appearance هنگام رندر یک بندانگشتی چیست؟**

`Shape` از هندسهٔ شکل استفاده می‌کند؛ `Appearance` اثرات بصری [/slides/fa/java/shape-effect/](/slides/fa/java/shape-effect/) (سایه‌ها، درخشندگی‌ها و غیره) را در نظر می‌گیرد.

**اگر یک شکل به‌عنوان hidden علامت‌گذاری شود چه اتفاقی می‌افتد؟ آیا هنوز به‌صورت بندانگشتی رندر می‌شود؟**

یک شکل مخفی همچنان بخشی از مدل می‌ماند و می‌تواند رندر شود؛ پرچم hidden فقط نمایش اسلایدشو را تحت تأثیر قرار می‌دهد اما مانع تولید تصویر شکل نمی‌شود.

**آیا شکل‌های گروهی، نمودارها، SmartArt و سایر اشیاء پیچیده پشتیبانی می‌شوند؟**

بله. هر شیئی که به‌عنوان [Shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/) نمایش داده می‌شود (از جمله [GroupShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chart/)، و [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/smartart/)) می‌تواند به‌عنوان بندانگشتی یا به‌صورت SVG ذخیره شود.

**آیا فونت‌های نصب‌شده در سیستم بر کیفیت بندانگشتی‌های متنی تأثیر می‌گذارند؟**

بله. برای جلوگیری از استفاده ناخواسته از فونت‌های جایگزین و بازچیدمان متن باید [فونت‌های مورد نیاز را فراهم کنید](/slides/fa/java/custom-font/) (یا [پیکربندی جایگزینی فونت‌ها](/slides/fa/java/font-substitution/)).

