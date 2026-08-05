---
title: تحويل شرائح العرض التقديمي إلى صور باستخدام JavaScript
linktitle: الشريحة إلى صورة
type: docs
weight: 35
url: /ar/nodejs-java/convert-slide/
keywords:
- تحويل شريحة
- تصدير شريحة
- شريحة إلى صورة
- حفظ الشريحة كصورة
- شريحة إلى PNG
- شريحة إلى JPEG
- شريحة إلى bitmap
- شريحة إلى TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل الشرائح من PPT وPPTX وODP إلى صور باستخدام JavaScript عبر Aspose.Slides for Node.js via Java - سريع، تصيير عالي الجودة مع أمثلة شفرة واضحة."
---
## **المقدمة**

يتيح لك Aspose.Slides for Node.js عبر Java تحويل شرائح العروض التقديمية PowerPoint وOpenDocument بسهولة إلى تنسيقات صورة متعددة، بما في ذلك BMP وPNG وJPG (JPEG) وGIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. تعريف إعدادات التحويل المطلوبة واختيار الشرائح التي تريد تصديرها باستخدام:
    - الفئة [TiffOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/) ، أو
    - الفئة [RenderingOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/renderingoptions/) .
2. إنشاء صورة الشريحة عن طريق استدعاء طريقة [getImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#getImage).

في Aspose.Slides for Node.js عبر Java، تُعد الفئة [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/) فئةً تتيح لك التعامل مع الصور المعرفة ببيانات البكسل. يمكنك استخدام هذه الفئة لحفظ الصور في مجموعة واسعة من التنسيقات (BMP، JPG، PNG، إلخ).

## **تحويل الشرائح إلى bitmap وحفظ الصور بصيغة PNG**

يمكنك تحويل شريحة إلى كائن bitmap واستخدامه مباشرةً في تطبيقك. بدلاً من ذلك، يمكنك تحويل شريحة إلى bitmap ثم حفظ الصورة بصيغة JPEG أو أي صيغة أخرى مفضلة.

يوضح هذا الكود JavaScript كيفية تحويل الشريحة الأولى من العرض التقديمي إلى كائن bitmap ثم حفظ الصورة بصيغة PNG:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض التقديمي إلى bitmap.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // حفظ الصورة بصيغة PNG.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام أحد التحميلات المتعددة لطريقة [getImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#getImage)، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (العرض والارتفاع).

يوضح مثال الكود التالي كيفية القيام بذلك:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض التقديمي إلى bitmap بالحجم المحدد.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // حفظ الصورة بصيغة JPEG.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

قد تحتوي بعض الشرائح على ملاحظات وتعليقات.

توفر Aspose.Slides فئتين—[TiffOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/) و[RenderingOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/renderingoptions/)—تسمحان لك بالتحكم في تصيير شرائح العرض إلى صور. تضم الفئتين طريقة `setSlidesLayoutOptions` التي تمكّنك من تكوين تصيير الملاحظات والتعليقات على الشريحة عند تحويلها إلى صورة.

باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notescommentslayoutingoptions/)، يمكنك تحديد الموقع المفضل للملاحظات والتعليقات في الصورة الناتجة.

يوضح هذا الكود JavaScript كيفية تحويل شريحة تحتوي على ملاحظات وتعليقات:

```js
const scaleX = 2;
const scaleY = scaleX;

// Load a presentation file.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // تعيين موضع الملاحظات.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // تعيين موضع التعليقات.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // تعيين عرض مساحة التعليقات.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // تعيين لون مساحة التعليقات.

    // إنشاء خيارات التصيير.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // تحويل الشريحة الأولى من العرض التقديمي إلى صورة.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // حفظ الصورة بصيغة GIF.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
في أي عملية تحويل شريحة إلى صورة، لا يمكن لطريقة [setNotesPosition](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) تطبيق `BottomFull` (لتحديد موضع الملاحظات) لأن نص الملاحظة قد يكون كبيرًا جدًا، مما يجعله غير قادر على التناسب مع حجم الصورة المحدد.
{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

توفر الفئة [TiffOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/) سيطرة أكبر على صورة TIFF الناتجة من خلال السماح لك بتحديد معلمات مثل الحجم، الدقة، لوحة الألوان، وأكثر.

يوضح هذا الكود JavaScript عملية تحويل حيث تُستخدم خيارات TIFF لإنتاج صورة بالأبيض والأسود بدقة 300 DPI وحجم 2160 × 2800:

```js
// تحميل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // الحصول على الشريحة الأولى من العرض التقديمي.
    let slide = presentation.getSlides().get_Item(0);

    // تكوين إعدادات صورة TIFF الناتجة.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // تعيين حجم الصورة.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // تعيين تنسيق البكسل (أبيض وأسود).
    tiffOptions.setDpiX(300);                                                          // تعيين الدقة الأفقية.
    tiffOptions.setDpiY(300);                                                          // تعيين الدقة العمودية.

    // تحويل الشريحة إلى صورة باستخدام الخيارات المحددة.
    let image = slide.getImage(tiffOptions);
    try {
        // حفظ الصورة بصيغة TIFF.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
لا يُضمن دعم TIFF في الإصدارات الأقدم من JDK 9.
{{% /alert %}} 

## **تحويل جميع الشرائح إلى صور**

تسمح لك Aspose.Slides بتحويل جميع الشرائح في عرض تقديمي إلى صور، مما يحول العرض بالكامل إلى مجموعة من الصور.

يوضح مثال الكود التالي كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام JavaScript:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // تصيير العرض التقديمي إلى صور شريحة بشريحة.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // التحكم في الشرائح المخفية (عدم تصيير الشرائح المخفية).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // تحويل الشريحة إلى صورة.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // حفظ الصورة بصيغة JPEG.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **تصيير الرموز التعبيرية الملونة**

{{% alert title="Note" color="warning" %}} 
لتصrender الرموز التعبيرية الملونة بشكل صحيح عند تحويل شرائح العرض إلى صور، يجب تثبيت خطوط الرموز التعبيرية المستخدمة في العرض وتوافرها على النظام الذي يقوم بالتحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وكان هذا الخط غير موجود، فقد تظهر الرموز التعبيرية بالأبيض والأسود في الصور الناتجة.
{{% /alert %}} 

## **الأسئلة الشائعة**

**هل تدعم Aspose.Slides تصيير الشرائح مع الرسوم المتحركة؟**

لا، طريقة `getImage` تحفظ صورة ثابتة فقط للشريحة، دون الرسوم المتتحركة.

**هل يمكن معالجة الشرائح المخفية كصور؟**

نعم، يمكن معالجة الشرائح المخفية مثل الشرائح العادية. فقط تأكد من تضمينها في حلقة المعالجة.

**هل يمكن حفظ الصور مع الظلال والتأثيرات؟**

نعم، تدعم Aspose.Slides تصيير الظلال والشفافية وغيرها من التأثيرات الرسومية عند حفظ الشرائح كصور.