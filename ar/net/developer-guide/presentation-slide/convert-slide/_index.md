---
title: تحويل شرائح PowerPoint إلى صور في C#
linktitle: شريحة إلى صورة
type: docs
weight: 41
url: /ar/net/convert-slide/
keywords:
- تحويل شريحة
- تحويل شريحة إلى صورة
- تصدير شريحة كصورة
- حفظ شريحة كصورة
- شريحة إلى صورة
- شريحة إلى PNG
- شريحة إلى JPEG
- شريحة إلى bitmap
- C#
- Csharp
- .NET
- Aspose.Slides
description: "تعرف على كيفية تحويل شرائح PowerPoint وOpenDocument إلى تنسيقات مختلفة باستخدام Aspose.Slides للـ .NET. صدّر بسهولة شرائح PPTX وODP إلى BMP وPNG وJPEG وTIFF وغيرها مع نتائج عالية الجودة."
---

## **نظرة عامة**

يتيح لك Aspose.Slides for .NET تحويل شرائح عروض PowerPoint وOpenDocument بسهولة إلى صيغ صور مختلفة، بما في ذلك BMP وPNG وJPG (JPEG) وGIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حدد إعدادات التحويل المطلوبة واختر الشرائح التي تريد تصديرها باستخدام:
    - الواجهة [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) ، أو
    - الواجهة [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/) .
2. قم بإنشاء صورة الشريحة عن طريق استدعاء الطريقة [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) .

في .NET، الـ[Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) هو كائن يتيح لك العمل مع الصور المعرفة ببيانات البكسل. يمكنك استخدام نسخة من هذه الفئة لحفظ الصور بمجموعة واسعة من الصيغ (BMP وJPG وPNG، إلخ).

## **تحويل الشرائح إلى Bitmap وحفظ الصور بصيغة PNG**

يمكنك تحويل شريحة إلى كائن bitmap واستخدامه مباشرةً في تطبيقك. بدلاً من ذلك، يمكنك تحويل شريحة إلى bitmap ثم حفظ الصورة بصيغة JPEG أو أي صيغة مفضلة أخرى.

يوضح هذا الشيفرة C# كيفية تحويل الشريحة الأولى من العرض إلى كائن bitmap ثم حفظ الصورة بصيغة PNG:
```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // تحويل الشريحة الأولى في العرض التقديمي إلى bitmap.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // حفظ الصورة بتنسيق PNG.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```


## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام نسخة مُحمّلة من الطريقة [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/)، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (العرض والارتفاع).

يوضح مثال الشيفرة كيف تقوم بذلك:
```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // تحويل الشريحة الأولى في العرض التقديمي إلى bitmap بالحجم المحدد.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // حفظ الصورة بتنسيق JPEG.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```


## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

قد تحتوي بعض الشرائح على ملاحظات وتعليقات.

توفر Aspose.Slides واجهتين—[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) و[IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/)—تتيحان لك التحكم في عرض شرائح العرض إلى صور. كلا الواجهتين تتضمنان الخاصية `SlidesLayoutOptions`، التي تمكنك من تكوين عرض الملاحظات والتعليقات على الشريحة عند تحويلها إلى صورة.

باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/)، يمكنك تحديد الموقع المفضل للملاحظات والتعليقات في الصورة الناتجة.

يوضح هذا الشيفرة C# كيفية تحويل شريحة تحتوي على ملاحظات وتعليقات:
```cs
float scaleX = 2;
float scaleY = scaleX;

// تحميل ملف عرض تقديمي.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // إنشاء خيارات العرض.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // تحديد موضع الملاحظات.
            CommentsPosition = CommentsPositions.Right,      // تحديد موضع التعليقات.
            CommentsAreaWidth = 500,                         // تحديد عرض مساحة التعليقات.
            CommentsAreaColor = Color.AntiqueWhite           // تحديد لون مساحة التعليقات.
        }
    };

    // تحويل الشريحة الأولى من العرض التقديمي إلى صورة.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // حفظ الصورة بتنسيق GIF.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```


{{% alert title="Note" color="warning" %}} 

في أي عملية تحويل شريحة إلى صورة، لا يمكن ضبط الخاصية [NotesPosition](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) على القيمة `BottomFull` (لتحديد موقع الملاحظات) لأن نص الملاحظة قد يكون كبيرًا جدًا، مما يجعلها غير قادرة على التناسب مع حجم الصورة المحدد.

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

توفر الواجهة [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) تحكمًا أكبر في صورة TIFF الناتجة من خلال السماح لك بتحديد معايير مثل الحجم، الدقة، لوحة الألوان، وأكثر.

يوضح هذا الشيفرة C# عملية تحويل حيث تُستخدم خيارات TIFF لإنتاج صورة بالأبيض والأسود بدقة 300 DPI وحجم 2160 × 2800:
```cs
// تحميل ملف عرض تقديمي.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // الحصول على الشريحة الأولى من العرض التقديمي.
    ISlide slide = presentation.Slides[0];

    // تكوين إعدادات صورة TIFF الناتجة.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // ضبط حجم الصورة.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // ضبط تنسيق البكسل (أسود وأبيض).
        DpiX = 300,                                        // ضبط الدقة الأفقية.
        DpiY = 300                                         // ضبط الدقة العمودية.
    };

    // تحويل الشريحة إلى صورة باستخدام الخيارات المحددة.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // حفظ الصورة بصيغة TIFF.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```


## **تحويل جميع الشرائح إلى صور**

يتيح لك Aspose.Slides تحويل جميع الشرائح في عرض تقديمي إلى صور، مما يحول العرض بأكمله إلى سلسلة من الصور.

يوضح مثال الشيفرة كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام C#:
```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // تحويل العرض التقديمي إلى صور شريحة بشريحة.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // التحكم في الشرائح المخفية (عدم عرض الشرائح المخفية).
        if (presentation.Slides[i].Hidden)
            continue;

        // تحويل الشريحة إلى صورة.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // حفظ الصورة بتنسيق JPEG.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```


## **الأسئلة المتكررة**

**1. هل يدعم Aspose.Slides عرض الشرائح مع الرسوم المتحركة؟**

لا، طريقة `GetImage` تحفظ صورة ثابتة فقط للشريحة، بدون رسوم متحركة.

**2. هل يمكن تصدير الشرائح المخفية كصور؟**

نعم، يمكن معالجة الشرائح المخفية مثل العادية. فقط تأكد من تضمينها في دورة المعالجة.

**3. هل يمكن حفظ الصور مع الظلال والتأثيرات؟**

نعم، يدعم Aspose.Slides عرض الظلال والشفافية والتأثيرات الرسومية الأخرى عند حفظ الشرائح كصور.