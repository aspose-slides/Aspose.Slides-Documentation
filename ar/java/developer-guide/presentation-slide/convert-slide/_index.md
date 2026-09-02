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
description: "تحويل الشرائح من PPT و PPTX و ODP إلى صور في Java باستخدام Aspose.Slides—سريع، عرض عالي الجودة مع أمثلة شفرة واضحة."
---
## **المقدمة**

تمكنك Aspose.Slides for Java من تحويل شرائح العروض التقديمية PowerPoint و OpenDocument بسهولة إلى صيغ صور مختلفة، بما في ذلك BMP و PNG و JPG (JPEG) و GIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حدد إعدادات التحويل المطلوبة واختر الشرائح التي تريد تصديرها باستخدام:
    - واجهة [ITiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiffoptions/) ، أو
    - واجهة [IRenderingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/irenderingoptions/)
2. قم بإنشاء صورة الشريحة عن طريق استدعاء الطريقة [getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-).

في Aspose.Slides for Java، تُعد [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) واجهة تسمح لك بالعمل مع الصور المعرفة ببيانات البكسل. يمكنك استخدام هذه الواجهة لحفظ الصور بمجموعة واسعة من الصيغ (BMP، JPG، PNG، إلخ).

## **تحويل الشرائح إلى صور نقطية وحفظ الصور بصيغة PNG**

يمكنك تحويل شريحة إلى كائن bitmap واستخدامه مباشرة في تطبيقك. بدلاً من ذلك، يمكنك تحويل الشريحة إلى bitmap ثم حفظ الصورة بصيغة JPEG أو أي صيغة أخرى تفضلها.

هذا المثال يوضح كيفية تحويل الشريحة الأولى من عرض تقديمي إلى كائن bitmap ثم حفظ الصورة بصيغة PNG:

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

## **تحويل الشرائح إلى صور بحجم مخصص**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام أحد الأشكال المتعددة للطريقة [getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-)، يمكنك تحويل الشريحة إلى صورة بأبعاد محددة (العرض والارتفاع).

هذا المثال يوضح كيفية القيام بذلك:

```java 
Dimension imageSize = new Dimension(1820, 1040);

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

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

بعض الشرائح قد تحتوي على ملاحظات وتعليقات.

توفر Aspose.Slides واجهتين—[ITiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiffoptions/) و[IRenderingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/irenderingoptions/)—تسمحان لك بالتحكم في تحويل شرائح العرض إلى صور. تتضمن كلتا الواجهتين طريقة `setSlidesLayoutOptions` التي تتيح لك تكوين طريقة عرض الملاحظات والتعليقات على الشريحة عند تحويلها إلى صورة.

باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/notescommentslayoutingoptions/)، يمكنك تحديد الموقع المفضل للملاحظات والتعليقات في الصورة الناتجة.

هذا المثال يوضح كيفية تحويل شريحة تحتوي على ملاحظات وتعليقات:

```java 
float scaleX = 2;
float scaleY = scaleX;

// تحميل ملف عرض تقديمي.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // تحديد موضع الملاحظات.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // تحديد موضع التعليقات.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // تحديد عرض منطقة التعليقات.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // تحديد لون منطقة التعليقات.

    // إنشاء خيارات العرض.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // تحويل الشريحة الأولى من العرض التقديمي إلى صورة.
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
في أي عملية تحويل من شريحة إلى صورة، لا يمكن للطريقة [setNotesPosition](https://reference.aspose.com/slides/ar/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) تطبيق `BottomFull` (لتحديد موقع الملاحظات) لأن نص الملاحظة قد يكون كبيرًا جدًا، مما يجعله غير قادر على الارت fitting داخل حجم الصورة المحدد.
{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

توفر واجهة [ITiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiffoptions/) تحكمًا أكبر في الصورة TIFF الناتجة من خلال السماح لك بتحديد معلمات مثل الحجم، الدقة، لوحة الألوان، وأكثر.

هذا المثال يوضح عملية تحويل يتم فيها استخدام خيارات TIFF لإنتاج صورة أبيض وأسود بدقة 300 DPI وبحجم 2160 × 2800:

```java 
// تحميل ملف عرض تقديمي.
Presentation presentation = new Presentation("sample.pptx");
try {
    // الحصول على الشريحة الأولى من العرض التقديمي.
    ISlide slide = presentation.getSlides().get_Item(0);

    // تكوين إعدادات صورة TIFF الناتجة.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // تحديد حجم الصورة.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // تحديد صيغة البكسل (أبيض وأسود).
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

تمكنك Aspose.Slides من تحويل جميع الشرائح في عرض تقديمي إلى صور، وبالتالي تحويل العرض بالكامل إلى سلسلة من الصور.

هذا المثال يوضح كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // عرض العرض التقديمي إلى صور شريحة بشريحة.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // تحكم في الشرائح المخفية (لا تعرض الشرائح المخفية).
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
لإظهار الرموز التعبيرية الملونة بشكل صحيح عند تحويل شرائح العرض إلى صور، يجب تثبيت خطوط الرموز التعبيرية المستخدمة في العرض على النظام الذي يجري التحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وكانت هذه الخط غير موجودة، قد تظهر الرموز التعبيرية بالأبيض والأسود في الصور الناتجة.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل تدعم Aspose.Slides عرض الشرائح مع الرسوم المتحركة؟**

لا، طريقة `getImage` تحفظ صورة ثابتة فقط للشريحة دون رسومات متحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم، يمكن معالجة الشرائح المخفية كأي شرائح أخرى. تأكد فقط من تضمينها في حلقة المعالجة.

**هل يمكن حفظ الصور بظلال وتأثيرات؟**

نعم، تدعم Aspose.Slides عرض الظلال والشفافية وغيرها من التأثيرات الرسومية عند حفظ الشرائح كصور.