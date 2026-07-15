---
title: تحويل شرائح العرض التقديمي إلى صور في Java
linktitle: شريحة إلى صورة
type: docs
weight: 35
url: /ar/java/convert-slide/
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
- Java
- Aspose.Slides
description: "تحويل الشرائح من PPT و PPTX و ODP إلى صور في Java باستخدام Aspose.Slides—عرض سريع وعالي الجودة مع أمثلة شفرة واضحة."
---
## **المقدمة**

Aspose.Slides for Java يتيح لك بسهولة تحويل شرائح العروض التقديمية PowerPoint و OpenDocument إلى تنسيقات صور مختلفة، بما في ذلك BMP و PNG و JPG (JPEG) و GIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. تحديد إعدادات التحويل المطلوبة واختيار الشرائح التي تريد تصديرها باستخدام:
    - واجهة [ITiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiffoptions/) أو
    - واجهة [IRenderingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/irenderingoptions/) .
2. إنشاء صورة الشريحة عن طريق استدعاء الطريقة [getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) .

في Aspose.Slides for Java، تعتبر [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) واجهة تسمح لك بالعمل مع الصور المعرفة ببيانات البكسل. يمكنك استخدام هذه الواجهة لحفظ الصور في مجموعة واسعة من التنسيقات (BMP، JPG، PNG، إلخ).

## **تحويل الشرائح إلى ملفات Bitmap وحفظ الصور بتنسيق PNG**

يمكنك تحويل شريحة إلى كائن bitmap واستخدامه مباشرةً في تطبيقك. بدلاً من ذلك، يمكنك تحويل الشريحة إلى bitmap ثم حفظ الصورة بصيغة JPEG أو أي صيغة مفضلة أخرى.

يوضح هذا الكود كيفية تحويل الشريحة الأولى من العرض التقديمي إلى كائن bitmap ثم حفظ الصورة بتنسيق PNG:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض إلى صورة bitmap.
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

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام نسخة معلمة من الطريقة [getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-)، يمكنك تحويل الشريحة إلى صورة بأبعاد محددة (العرض والارتفاع).

يوضح هذا المثال البرمجي كيفية القيام بذلك:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض إلى صورة bitmap بالحجم المحدد.
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

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

قد تحتوي بعض الشرائح على ملاحظات وتعليقات.

توفر Aspose.Slides واجهتين—[ITiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiffoptions/) و [IRenderingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/irenderingoptions/)—تسمحان لك بالتحكم في تحويل شرائح العرض إلى صور. تشمل كلتا الواجهتين طريقة `setSlidesLayoutOptions`، التي تمكنك من تكوين عرض الملاحظات والتعليقات على الشريحة عند تحويلها إلى صورة.

باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/notescommentslayoutingoptions/)، يمكنك تحديد الموضع المفضل للملاحظات والتعليقات في الصورة الناتجة.

يوضح هذا الكود كيفية تحويل شريحة تحتوي على ملاحظات وتعليقات:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // تحديد موضع الملاحظات.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // تحديد موضع التعليقات.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // تحديد عرض مساحة التعليقات.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // تحديد لون مساحة التعليقات.

    // إنشاء خيارات التقديم.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // تحويل الشريحة الأولى من العرض إلى صورة.
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
في أي عملية تحويل شريحة إلى صورة، لا يمكن للطريقة [setNotesPosition](https://reference.aspose.com/slides/ar/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) تطبيق `BottomFull` (لتحديد موضع الملاحظة) لأن نص الملاحظة قد يكون كبيرًا جدًا، مما يجعله غير قادر على التناسب مع حجم الصورة المحدد.
{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

توفر واجهة [ITiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiffoptions/) تحكمًا أكبر في صورة TIFF الناتجة من خلال السماح لك بتحديد معلمات مثل الحجم، الدقة، لوحة الألوان، وأكثر.

يوضح هذا الكود عملية تحويل يتم فيها استخدام خيارات TIFF لإنتاج صورة أبيض-أسود بدقة 300 DPI وحجم 2160 × 2800:

```java 
// تحميل ملف عرض تقديمي.
Presentation presentation = new Presentation("sample.pptx");
try {
    // الحصول على الشريحة الأولى من العرض.
    ISlide slide = presentation.getSlides().get_Item(0);

    // تكوين إعدادات صورة TIFF الناتجة.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // تحديد حجم الصورة.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // تحديد تنسيق البكسل (أسود وأبيض).
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

{{% alert title="Note" color="warning" %}} 
دعم TIFF غير مضمون في الإصدارات الأقدم من JDK 9.
{{% /alert %}} 

## **تحويل جميع الشرائح إلى صور**

تتيح لك Aspose.Slides تحويل جميع الشرائح في عرض تقديمي إلى صور، مما يحول العرض بالكامل إلى سلسلة من الصور.

يوضح هذا المثال البرمجي كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تحويل العرض التقديمي إلى صور شريحة بشريحة.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // التحكم في الشرائح المخفية (عدم تقديم الشرائح المخفية).
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

## **عرض إيموجي ملون**

{{% alert title="Note" color="warning" %}} 
لعرض الإيموجي الملون بشكل صحيح عند تحويل شرائح العرض إلى صور، يجب تثبيت خطوط الإيموجي المستخدمة في العرض وتوافرها على النظام الذي يقوم بالتحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وكانت هذه الخطوط غير موجودة، قد تظهر الإيموجي بأحادية اللون في الصور الناتجة.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يدعم Aspose.Slides عرض الشرائح مع الرسوم المتحركة؟**

لا، طريقة `getImage` تحفظ صورة ثابتة فقط للشريحة، بدون رسوم متحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم، يمكن معالجة الشرائح المخفية مثل الشرائح العادية. فقط تأكد من تضمينها في حلقة المعالجة.

**هل يمكن حفظ الصور مع الظلال والتأثيرات؟**

نعم، تدعم Aspose.Slides عرض الظلال، الشفافية، وغيرها من التأثيرات الرسومية عند حفظ الشرائح كصور.