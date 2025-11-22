---
title: تحويل شرائح PowerPoint إلى صور باستخدام JavaScript
linktitle: شريحة إلى صورة
type: docs
weight: 35
url: /ar/nodejs-java/convert-slide/
keywords:
- تحويل الشريحة
- تحويل الشريحة إلى صورة
- تصدير الشريحة كصورة
- حفظ الشريحة كصورة
- شريحة إلى صورة
- شريحة إلى PNG
- شريحة إلى JPEG
- شريحة إلى bitmap
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية تحويل شرائح PowerPoint وOpenDocument إلى صيغ متعددة باستخدام Aspose.Slides لـ Node.js عبر Java. صدّر بسهولة شرائح PPTX وODP إلى BMP وPNG وJPEG وTIFF وغيرها مع نتائج عالية الجودة."
---

## **نظرة عامة**

Aspose.Slides for Node.js via Java يتيح لك بسهولة تحويل شرائح عروض PowerPoint وOpenDocument إلى صيغ صور مختلفة، بما في ذلك BMP وPNG وJPG (JPEG) وGIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حدد إعدادات التحويل المطلوبة واختر الشرائح التي تريد تصديرها باستخدام:
    - فئة [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) أو
    - فئة [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) .
2. قم بإنشاء صورة الشريحة عن طريق استدعاء طريقة [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).

في Aspose.Slides for Node.js via Java، فإن [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) هي فئة تتيح لك العمل مع الصور المعرفة ببيانات البكسل. يمكنك استخدام هذه الفئة لحفظ الصور في مجموعة واسعة من الصيغ (BMP، JPG، PNG، إلخ).

## **تحويل الشرائح إلى Bitmap وحفظ الصور بصيغة PNG**

يمكنك تحويل شريحة إلى كائن bitmap واستخدامه مباشرة في تطبيقك. بدلاً من ذلك، يمكنك تحويل شريحة إلى bitmap ثم حفظ الصورة بصيغة JPEG أو أي صيغة مفضلة أخرى.

يوضح هذا الكود JavaScript كيفية تحويل الشريحة الأولى من العرض إلى كائن bitmap ثم حفظ الصورة بصيغة PNG:
```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض إلى bitmap.
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

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام نسخة مُحمّلة من [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage)، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (العرض والارتفاع). 

يوضح هذا الكود النموذجي كيفية القيام بذلك:
```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض إلى bitmap بالحجم المحدد.
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

بعض الشرائح قد تحتوي على ملاحظات وتعليقات.

توفر Aspose.Slides فئتين—[TiffOptions] و[RenderingOptions]—تتيحان لك التحكم في تحويل شرائح العرض إلى صور. كلا الفئتين تضم طريقة `setSlidesLayoutOptions`، التي تمكنك من تكوين عرض الملاحظات والتعليقات على الشريحة عند تحويلها إلى صورة.

باستخدام فئة [NotesCommentsLayoutingOptions]، يمكنك تحديد الموضع المفضل للملاحظات والتعليقات في الصورة الناتجة.

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
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // تعيين عرض منطقة التعليقات.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // تعيين لون منطقة التعليقات.

    // إنشاء خيارات العرض.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // تحويل الشريحة الأولى من العرض إلى صورة.
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
في أي عملية تحويل شريحة إلى صورة، لا يمكن لطريقة [setNotesPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) تطبيق `BottomFull` (لتحديد موضع الملاحظات) لأن نص الملاحظة قد يكون كبيرًا جدًا، مما يجعله لا يستطيع الملاءمة ضمن حجم الصورة المحدد.
{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

توفر فئة [TiffOptions] تحكمًا أكبر في صورة TIFF الناتجة من خلال السماح لك بتحديد معلمات مثل الحجم، الدقة، لوحة الألوان، وأكثر.

يوضح هذا الكود JavaScript عملية تحويل حيث تُستخدم خيارات TIFF لإخراج صورة بالأبيض والأسود بدقة 300 DPI وبحجم 2160 × 2800:
```js
// تحميل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // الحصول على الشريحة الأولى من العرض.
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
الدعم لتنسيق Tiff غير مضمون في الإصدارات السابقة لـ JDK 9.
{{% /alert %}} 

## **تحويل جميع الشرائح إلى صور**

تتيح لك Aspose.Slides تحويل جميع الشرائح في عرض تقديمي إلى صور، مما يحول العرض بالكامل إلى سلسلة من الصور.

يوضح هذا الكود النموذجي كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام JavaScript:
```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // تحويل العرض إلى صور شريحة بشريحة.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // التحكم في الشرائح المخفية (عدم عرض الشرائح المخفية).
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


## **FAQ**

**هل تدعم Aspose.Slides عرض الشرائح مع الرسوم المتحركة؟**

لا، طريقة `getImage` تحفظ صورة ثابتة فقط للشريحة، دون رسوم متحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم، يمكن معالجة الشرائح المخفية كما يتم معالجة الشرائح العادية. فقط تأكد من تضمينها في حلقة المعالجة.

**هل يمكن حفظ الصور مع الظلال والمؤثرات؟**

نعم، تدعم Aspose.Slides عرض الظلال، الشفافية، وغيرها من المؤثرات الرسومية عند حفظ الشرائح كصور.