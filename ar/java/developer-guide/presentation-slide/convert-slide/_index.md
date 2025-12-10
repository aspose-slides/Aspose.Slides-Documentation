---
title: تحويل شرائح العرض التقديمي إلى صور في جافا
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
- شريحة إلى صورة نقطية
- شريحة إلى TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحويل الشرائح من PPT و PPTX و ODP إلى صور في جافا باستخدام Aspose.Slides - سرعة وجودة عالية في التصيير مع أمثلة شفافة للكود."
---

## **نظرة عامة**

تمكّنك Aspose.Slides for Java من تحويل شرائح عروض PowerPoint وOpenDocument بسهولة إلى صيغ صور متعددة، بما في ذلك BMP وPNG وJPG (JPEG) وGIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حدد إعدادات التحويل المطلوبة واختر الشرائح التي تريد تصديرها باستخدام:
    - الواجهة [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/itiffoptions/)، أو
    - الواجهة [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/irenderingoptions/) .
2. أنشئ صورة الشريحة عن طريق استدعاء الطريقة [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) .

في Aspose.Slides for Java، الواجهة [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) تتيح لك العمل مع الصور المعرفة ببيانات البكسل. يمكنك استخدام هذه الواجهة لحفظ الصور بصيغ متعددة (BMP، JPG، PNG، إلخ).

## **تحويل الشرائح إلى صور نقطية وحفظ الصور بصيغة PNG**

يمكنك تحويل شريحة إلى كائن bitmap واستخدامه مباشرة في تطبيقك. بدلاً من ذلك، يمكنك تحويل الشريحة إلى bitmap ثم حفظ الصورة بصيغة JPEG أو أي صيغة أخرى مفضلة.

يعرض هذا الكود كيفية تحويل الشريحة الأولى من عرض تقديمي إلى كائن bitmap ثم حفظ الصورة بصيغة PNG:
```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض إلى صورة نقطية.
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

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام نسخة مُحملة من الطريقة [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-)، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (العرض والارتفاع).

يعرض هذا المثال كيفية القيام بذلك:
```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض التقديمي إلى صورة نقطية بالحجم المحدد.
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

بعض الشرائح قد تحتوي على ملاحظات وتعليقات.

توفر Aspose.Slides واجهتين—[ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/itiffoptions/) و[IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/irenderingoptions/)—تلتحقان لك التحكم في تصيير شرائح العرض إلى صور. كل من الواجهتين تتضمن طريقة `setSlidesLayoutOptions` التي تمكنك من تكوين تصيير الملاحظات والتعليقات على الشريحة عند تحويلها إلى صورة.

باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/)، يمكنك تحديد الموضع المفضل للملاحظات والتعليقات في الصورة الناتجة.

يعرض هذا الكود كيفية تحويل شريحة تحتوي على ملاحظات وتعليقات:
```java 
float scaleX = 2;
float scaleY = scaleX;

// تحميل ملف العرض التقديمي.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // تعيين موضع الملاحظات.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // تعيين موضع التعليقات.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // تعيين عرض مساحة التعليقات.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // تعيين لون مساحة التعليقات.

    // إنشاء خيارات التصيير.
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

في أي عملية تحويل من شريحة إلى صورة، لا يمكن للطريقة [setNotesPosition](https://reference.aspose.com/slides/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) تطبيق `BottomFull` (لتحديد موضع الملاحظات) لأن نص الملاحظة قد يكون كبيرًا جدًا، مما يجعله غير قادر على الاحتواء داخل حجم الصورة المحدد.

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

توفر الواجهة [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/itiffoptions/) تحكمًا أكبر في صورة الـ TIFF الناتجة من خلال إتاحة تحديد معلمات مثل الحجم، الدقة، لوحة الألوان، والمزيد.

يعرض هذا الكود عملية تحويل حيث تُستخدم خيارات TIFF لإنتاج صورة أبيض-أسود بدقة 300 DPI وحجم 2160 × 2800:
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

دعم TIFF غير مضمون في الإصدارات السابقة من JDK 9.

{{% /alert %}} 

## **تحويل جميع الشرائح إلى صور**

تتيح لك Aspose.Slides تحويل جميع الشرائح في عرض تقديمي إلى صور، مما يؤدي إلى تحويل العرض بالكامل إلى سلسلة من الصور.

يعرض هذا المثال كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور في Java:
```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تحويل العرض إلى صور شريحة بشريحة.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // تحكم في الشرائح المخفية (عدم تحويل الشرائح المخفية).
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


## **الأسئلة الشائعة**

**هل تدعم Aspose.Slides تصيير الشرائح مع الرسوم المتحركة؟**

لا، طريقة `getImage` تحفظ صورة ثابتة فقط للشريحة، دون رسوم متحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم، يمكن معالجة الشرائح المخفية كما هي الشرائح العادية. فقط تأكد من تضمينها في حلقة المعالجة.

**هل يمكن حفظ الصور بظلال وتأثيرات؟**

نعم، تدعم Aspose.Slides تصيير الظلال والشفافية وغيرها من التأثيرات الرسومية عند حفظ الشرائح كصور.