---
title: "تحويل شرائح العرض التقديمي إلى صور على Android"
linktitle: "شريحة إلى صورة"
type: docs
weight: 35
url: /ar/androidjava/convert-slide/
keywords:
- تحويل الشريحة
- تصدير الشريحة
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
description: "تحويل الشرائح من PPT وPPTX وODP إلى صور باستخدام Aspose.Slides للـ Android — تصيير سريع وعالي الجودة مع أمثلة شفافة لكود Java."
---

## **نظرة عامة**

يتيح لك Aspose.Slides لنظام Android عبر Java إمكانية تحويل شرائح عروض PowerPoint وOpenDocument بسهولة إلى صيغ صور متعددة، بما في ذلك BMP وPNG وJPG (JPEG) وGIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حدد إعدادات التحويل المطلوبة واختر الشرائح التي تريد تصديرها باستخدام:
    - واجهة [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) ، أو
    - واجهة [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/) .
2. توليد صورة الشريحة عن طريق استدعاء طريقة [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) .

في Aspose.Slides لنظام Android عبر Java، تُعد [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) واجهة تُتيح لك التعامل مع الصور المعرفة ببيانات البكسل. يمكنك استخدام هذه الواجهة لحفظ الصور بمجموعة واسعة من الصيغ (BMP، JPG، PNG، إلخ).

## **تحويل الشرائح إلى صور نقطية وحفظ الصور بصيغة PNG**

يمكنك تحويل شريحة إلى كائن bitmap واستخدامه مباشرةً في تطبيقك. أو يمكنك تحويل شريحة إلى bitmap ثم حفظ الصورة بصيغة JPEG أو أي صيغة أخرى مفضلة.

يوضح هذا الشيفرة كيفية تحويل الشريحة الأولى من عرض تقديمي إلى كائن bitmap ثم حفظ الصورة بصيغة PNG:
```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض التقديمي إلى كائن bitmap.
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

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام أحد التحميلات الزائدة من طريقة [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-)، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (العرض والارتفاع). 

يُظهر مثال الشيفرة التالي كيفية القيام بذلك:
```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض التقديمي إلى كائن bitmap بالحجم المحدد.
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

توفر Aspose.Slides واجهتين—[ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) و[IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/)—تسمحان لك بالتحكم في تحويل شرائح العرض التقديمي إلى صور. تشمل كلتا الواجهتين طريقة `setSlidesLayoutOptions`، التي تمكّنك من ضبط تحويل الملاحظات والتعليقات على شريحة عند تحويلها إلى صورة.

باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/)، يمكنك تحديد الموضع المفضل للملاحظات والتعليقات في الصورة الناتجة.

يوضح هذا الشيفرة كيفية تحويل شريحة تحتوي على ملاحظات وتعليقات:
```java
float scaleX = 2;
float scaleY = scaleX;

// تحميل ملف عرض تقديمي.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // تعيين موضع الملاحظات.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // تعيين موضع التعليقات.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // تعيين عرض منطقة التعليقات.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // تعيين لون منطقة التعليقات.

    // إنشاء خيارات التصيير.
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

في أي عملية تحويل شريحة إلى صورة، لا يمكن لطريقة [setNotesPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) تطبيق `BottomFull` (لتحديد موضع الملاحظات) لأن نص الملاحظة قد يكون كبيرًا جدًا، مما يمنعه من الملاءمة داخل حجم الصورة المحدد.

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

توفر واجهة [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) تحكمًا أكبر في صورة TIFF الناتجة من خلال السماح لك بتحديد معلمات مثل الحجم، الدقة، لوحة الألوان، وغير ذلك.

يوضح هذا الشيفرة عملية تحويل يتم فيها استخدام خيارات TIFF لإنتاج صورة بالأبيض والأسود بدقة 300 DPI وحجم 2160 × 2800:
```java 
// تحميل ملف عرض تقديمي.
Presentation presentation = new Presentation("sample.pptx");
try {
    // الحصول على الشريحة الأولى من العرض التقديمي.
    ISlide slide = presentation.getSlides().get_Item(0);

    // تكوين إعدادات صورة TIFF الناتجة.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // تعيين حجم الصورة.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // تعيين تنسيق البكسل (أسود وأبيض).
    tiffOptions.setDpiX(300);                                        // تعيين الدقة الأفقية.
    tiffOptions.setDpiY(300);                                        // تعيين الدقة العمودية.

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

يسمح لك Aspose.Slides بتحويل جميع الشرائح في عرض تقديمي إلى صور، مما يحوّل العرض بأكمله إلى سلسلة من الصور.

يعرض مثال الشيفرة التالي طريقة تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام Java:
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


## **الأسئلة المتكررة**

**هل تدعم Aspose.Slides تحويل الشرائح مع الرسوم المتحركة؟**

لا، طريقة `getImage` تحفظ صورة ثابتة فقط للشريحة، دون رسومات متحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم، يمكن معالجة الشرائح المخفية مثل الشرائح العادية. فقط تأكد من إدراجها في حلقة المعالجة.

**هل يمكن حفظ الصور مع الظلال والتأثيرات؟**

نعم، تدعم Aspose.Slides تطبيق الظلال والشفافية وغيرها من التأثيرات الرسومية عند حفظ الشرائح كصور.