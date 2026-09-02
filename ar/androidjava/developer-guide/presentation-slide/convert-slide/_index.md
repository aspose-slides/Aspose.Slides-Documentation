---
title: تحويل شرائح العرض التقديمي إلى صور على Android
linktitle: شريحة إلى صورة
type: docs
weight: 35
url: /ar/androidjava/convert-slide/
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
- Android
- Java
- Aspose.Slides
description: "تحويل الشرائح من PPT وPPTX وODP إلى صور باستخدام Aspose.Slides لنظام Android—عروض سريعة وعالية الجودة مع أمثلة واضحة لكود Java."
---
## **المقدمة**

تتيح لك Aspose.Slides لنظام Android عبر Java تحويل شرائح العروض التقديمية PowerPoint وOpenDocument بسهولة إلى صيغ صور مختلفة، بما في ذلك BMP وPNG وJPG (JPEG) وGIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حدد إعدادات التحويل المطلوبة واختر الشرائح التي تريد تصديرها باستخدام:
    - الواجهة [ITiffOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiffoptions/)، أو
    - الواجهة [IRenderingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/irenderingoptions/) .
2. قم بإنشاء صورة الشريحة عن طريق استدعاء طريقة [getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#getImage--) .

في Aspose.Slides لنظام Android عبر Java، تعتبر [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) واجهةً تُتيح لك العمل مع الصور المُعرَّفة ببيانات البكسل. يمكنك استخدام هذه الواجهة لحفظ الصور بمجموعة واسعة من الصيغ (BMP وJPG وPNG، إلخ).

## **تحويل الشرائح إلى صور بتنسيق Bitmap وحفظ الصور بصيغة PNG**

يمكنك تحويل شريحة إلى كائن bitmap واستخدامه مباشرةً في تطبيقك. بدلاً من ذلك، يمكنك تحويل الشريحة إلى bitmap ثم حفظ الصورة بصيغة JPEG أو أي صيغة أخرى تفضّلها.

هذا الشيفرة توضح كيفية تحويل الشريحة الأولى من العرض التقديمي إلى كائن bitmap ثم حفظ الصورة بصيغة PNG:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض التقديمي إلى bitmap.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // حفظ الصورة بصيغة PNG.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام نسخة من طريقة [getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-)، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (العرض والارتفاع).

هذا المثال يوضح كيفية القيام بذلك:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض التقديمي إلى bitmap بالحجم المحدد.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // حفظ الصورة بصيغة JPEG.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تحويل الشرائح التي تحتوي على ملاحظات وتعليقات إلى صور**

قد تحتوي بعض الشرائح على ملاحظات وتعليقات.

توفر Aspose.Slides واجهتين—[ITiffOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiffoptions/) و[IRenderingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/irenderingoptions/)—تتيحان لك التحكم في تحويل شرائح العرض إلى صور. تشمل كلتا الواجهتين الطريقة `setSlidesLayoutOptions` التي تمكنك من تكوين طريقة عرض الملاحظات والتعليقات على الشريحة عند تحويلها إلى صورة.

باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/notescommentslayoutingoptions/) يمكنك تحديد الموضع المفضّل للملاحظات والتعليقات في الصورة الناتجة.

هذا الشيفرة توضح كيفية تحويل شريحة تحتوي على ملاحظات وتعليقات:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // تحديد موضع الملاحظات.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // تحديد موضع التعليقات.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // تحديد عرض منطقة التعليقات.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // تحديد لون منطقة التعليقات.

    // إنشاء خيارات التقديم.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // تحويل الشريحة الأولى في العرض التقديمي إلى صورة.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // حفظ الصورة بصيغة GIF.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

في أي عملية تحويل شريحة إلى صورة، لا يمكن للطريقة [setNotesPosition](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) تطبيق `BottomFull` (لتحديد موضع الملاحظات) لأن نص الملاحظة قد يكون كبيرًا جدًا، مما يجعله غير قادر على التناسب مع حجم الصورة المحدد.

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

توفر الواجهة [ITiffOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiffoptions/) تحكمًا أكبر في صورة TIFF الناتجة من خلال السماح لك بتحديد معايير مثل الحجم، الدقة، لوحة الألوان، وغير ذلك.

هذا الشيفرة يوضح عملية تحويل حيث تُستخدم خيارات TIFF لإنتاج صورة أبيض-أسود بدقة 300 DPI وحجم 2160 × 2800:

```java 
// تحميل ملف عرض تقديمي.
Presentation presentation = new Presentation("sample.pptx");
try {
    // الحصول على الشريحة الأولى من العرض التقديمي.
    ISlide slide = presentation.getSlides().get_Item(0);

    // تكوين إعدادات صورة TIFF الناتجة.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // تحديد حجم الصورة.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // تحديد تنسيق البكسل (أبيض وأسود).
    tiffOptions.setDpiX(300);                                        // تحديد الدقة الأفقية.
    tiffOptions.setDpiY(300);                                        // تحديد الدقة العمودية.

    // تحويل الشريحة إلى صورة باستخدام الخيارات المحددة.
    IImage image = slide.getImage(tiffOptions);

    try {
        // حفظ الصورة بصيغة TIFF.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تحويل جميع الشرائح إلى صور**

تتيح لك Aspose.Slides تحويل جميع الشرائح في عرض تقديمي إلى صور، مما يحول العرض بالكامل إلى سلسلة من الصور.

هذا المثال يوضح كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تحويل العرض التقديمي إلى صور شريحة بشريحة.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // التحكم في الشرائح المخفية (عدم تحويل الشرائح المخفية).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // تحويل الشريحة إلى صورة.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // حفظ الصورة بصيغة JPEG.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **عرض الرموز التعبيرية الملونة**

{{% alert title="Note" color="warning" %}} 
لعرض الرموز التعبيرية الملونة بشكل صحيح عند تحويل شرائح العرض التقديمي إلى صور، يجب أن تكون خطوط الرموز التعبيرية المستخدمة في العرض مُثبتة ومتوفرة على النظام الذي يجري عملية التحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وكان هذا الخط غير موجود، قد تظهر الرموز التعبيرية بالأبيض والأسود في الصور الناتجة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides عرض الشرائح مع الرسوم المتحركة؟**

لا، طريقة `getImage` تحفظ صورة ثابتة فقط للشريحة، دون الرسوم المتحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم، يمكن معالجة الشرائح المخفية مثل الشرائح العادية. فقط تأكد من تضمينها في حلقة المعالجة.

**هل يمكن حفظ الصور مع الظلال والتأثيرات؟**

نعم، يدعم Aspose.Slides عرض الظلال والشفافية وغيرها من التأثيرات الرسومية عند حفظ الشرائح كصور.