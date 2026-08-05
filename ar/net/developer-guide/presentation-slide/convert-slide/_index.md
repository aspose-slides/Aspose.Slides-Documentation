---
title: تحويل شرائح العرض التقديمي إلى صور في .NET
linktitle: شريحة إلى صورة
type: docs
weight: 41
url: /ar/net/convert-slide/
keywords:
- تحويل الشريحة
- تصدير الشريحة
- شريحة إلى صورة
- حفظ الشريحة كصورة
- شريحة إلى PNG
- شريحة إلى JPEG
- شريحة إلى صورة نقطية
- شريحة إلى TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحويل الشرائح من PPT و PPTX و ODP إلى صور في C# باستخدام Aspose.Slides لـ .NET — تصيير سريع وعالي الجودة مع أمثلة شفرة واضحة."
---
## **المقدمة**

Aspose.Slides for .NET تمكنك من تحويل شرائح العروض التقديمية PowerPoint وOpenDocument بسهولة إلى تنسيقات صور مختلفة، بما في ذلك BMP وPNG وJPG (JPEG) وGIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حدد إعدادات التحويل المطلوبة واختر الشرائح التي تريد تصديرها باستخدام:
    - The [ITiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/itiffoptions/) interface, or
    - The [IRenderingOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/irenderingoptions/) interface.
2. إنشاء صورة الشريحة عن طريق استدعاء طريقة [GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/getimage/) .

في .NET، تُعد فئة [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) كائنًا يتيح لك التعامل مع الصور المعرفة ببيانات البكسل. يمكنك استخدام مثيل من هذه الفئة لحفظ الصور في مجموعة واسعة من التنسيقات (BMP ،JPG ،PNG ،إلخ).

## **تحويل الشرائح إلى صور نقطية وحفظها بصيغة PNG**

يمكنك تحويل شريحة إلى كائن صورة نقطية واستخدامه مباشرة في تطبيقك. بدلاً من ذلك، يمكنك تحويل شريحة إلى صورة نقطية ثم حفظها بصيغة JPEG أو أي تنسيق مفضل آخر.

هذا الكود C# يوضح كيفية تحويل الشريحة الأولى من عرض تقديمي إلى كائن صورة نقطية ثم حفظ الصورة بصيغة PNG:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // تحويل الشريحة الأولى في العرض التقديمي إلى صورة نقطية.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // حفظ الصورة بصيغة PNG.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام نسخة مُحمَّلة من طريقة [GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/getimage/)، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (العرض والارتفاع).

هذا مثال يوضح كيفية القيام بذلك:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // تحويل الشريحة الأولى في العرض التقديمي إلى صورة نقطية بالحجم المحدد.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // حفظ الصورة بصيغة JPEG.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

بعض الشرائح قد تحتوي على ملاحظات وتعليقات.

Aspose.Slides يوفر واجهتين—[ITiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/itiffoptions/) و[IRenderingOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/irenderingoptions/)—تتيح لك التحكم في تصيير شرائح العرض إلى صور. كلا الواجهتين تضم خاصية `SlidesLayoutOptions`، التي تمكنك من تكوين تصيير الملاحظات والتعليقات على الشريحة عند تحويلها إلى صورة.

باستخدام فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/notescommentslayoutingoptions/)، يمكنك تحديد الموضع المفضل للملاحظات والتعليقات في الصورة الناتجة.

هذا الكود C# يوضح كيفية تحويل شريحة تحتوي على ملاحظات وتعليقات:

```cs
float scaleX = 2;
float scaleY = scaleX;

// تحميل ملف عرض تقديمي.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // إنشاء خيارات التصيير.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // تعيين موضع الملاحظات.
            CommentsPosition = CommentsPositions.Right,      // تعيين موضع التعليقات.
            CommentsAreaWidth = 500,                         // تعيين عرض مساحة التعليقات.
            CommentsAreaColor = Color.AntiqueWhite           // تعيين لون مساحة التعليقات.
        }
    };

    // تحويل الشريحة الأولى من العرض التقديمي إلى صورة.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // حفظ الصورة بصيغة GIF.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 

في أي عملية تحويل شريحة إلى صورة، لا يمكن ضبط خاصية [NotesPosition](https://reference.aspose.com/slides/ar/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) إلى `BottomFull` (لتحديد موضع الملاحظات) لأن نص الملاحظة قد يكون كبيرًا جدًا، مما يجعله غير قادر على التناسب مع حجم الصورة المحدد.

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

واجهة [ITiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/itiffoptions/) توفر تحكمًا أكبر في صورة TIFF الناتجة من خلال السماح لك بتحديد معلمات مثل الحجم، الدقة، لوحة الألوان، وأكثر.

هذا الكود C# يوضح عملية تحويل حيث تُستخدم خيارات TIFF لإنتاج صورة أبيض-أسود بدقة 300 DPI وحجم 2160 × 2800:

```cs
// تحميل ملف عرض تقديمي.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // الحصول على الشريحة الأولى من العرض التقديمي.
    ISlide slide = presentation.Slides[0];

    // تكوين إعدادات صورة TIFF الناتجة.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // تعيين حجم الصورة.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // تعيين تنسيق البكسل (أبيض وأسود).
        DpiX = 300,                                        // تعيين الدقة الأفقية.
        DpiY = 300                                         // تعيين الدقة العمودية.
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

Aspose.Slides يسمح لك بتحويل جميع الشرائح في عرض تقديمي إلى صور، مما يحول العرض بالكامل إلى سلسلة من الصور.

هذا المثال يوضح كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام C#:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // تصيير العرض إلى صور شريحة بشريحة.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // التحكم في الشرائح المخفية (عدم تصيير الشرائح المخفية).
        if (presentation.Slides[i].Hidden)
            continue;

        // تحويل الشريحة إلى صورة.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // حفظ الصورة بصيغة JPEG.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **عرض الرموز التعبيرية الملونة**

{{% alert title="Note" color="warning" %}} 
لعرض الرموز التعبيرية الملونة بشكل صحيح عند تحويل شرائح العرض إلى صور، يجب أن تكون خطوط الرموز التعبيرية المستخدمة في العرض مثبتة وموجودة على النظام الذي يقوم بالتحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وهذه الخط غير متوفر، قد تظهر الرموز التعبيرية بالأبيض والأسود في الصور الناتجة.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يدعم Aspose.Slides عرض الشرائح مع الرسوم المتحركة؟**

لا، طريقة `GetImage` تحفظ صورة ثابتة فقط للشريحة، بدون رسوم متحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم، يمكن معالجة الشرائح المخفية كما هي الشرائح العادية. فقط تأكد من إضافتها إلى حلقة المعالجة.

**هل يمكن حفظ الصور مع الظلال والتأثيرات؟**

نعم، Aspose.Slides يدعم تصيير الظلال، الشفافية، وغيرها من التأثيرات الرسومية عند حفظ الشرائح كصور.