---
title: تحويل شرائح العرض التقديمي إلى صور في .NET
linktitle: الشرائح إلى صورة
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
- شريحة إلى bitmap
- شريحة إلى TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحويل الشرائح من PPT و PPTX و ODP إلى صور باستخدام C# و Aspose.Slides للـ .NET—أداء سريع وجودة عالية مع أمثلة شفرة واضحة."
---

## **نظرة عامة**

يتيح لك Aspose.Slides for .NET تحويل شرائح عروض PowerPoint و OpenDocument بسهولة إلى صيغ صور مختلفة، بما في ذلك BMP و PNG و JPG (JPEG) و GIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حدد إعدادات التحويل المطلوبة واختر الشرائح التي تريد تصديرها باستخدام:
    - واجهة [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/)، أو
    - واجهة [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/) .
2. أنشئ صورة الشريحة عن طريق استدعاء الطريقة [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) .

في .NET، تُعد فئة [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) كائنًا يتيح لك التعامل مع الصور المعتمدة على بيانات البكسل. يمكنك استخدام مثيل من هذه الفئة لحفظ الصور في مجموعة واسعة من الصيغ (BMP، JPG، PNG، إلخ).

## **تحويل الشرائح إلى صور Bitmap وحفظ الصور بصيغة PNG**

يمكنك تحويل شريحة إلى كائن bitmap واستخدامه مباشرة في تطبيقك. بدلاً من ذلك، يمكنك تحويل شريحة إلى bitmap ثم حفظ الصورة بصيغة JPEG أو أي صيغة مفضلة أخرى.

هذا الكود C# يُظهر كيفية تحويل الشريحة الأولى في عرض تقديمي إلى كائن bitmap ثم حفظ الصورة بصيغة PNG:
```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // تحويل الشريحة الأولى في العرض التقديمي إلى bitmap.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // حفظ الصورة بصيغة PNG.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```


## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة ذات حجم معين. باستخدام أحد التحميلات المزدوجة للطريقة [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/)، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (العرض والارتفاع).

هذا مثال الكود يوضح كيفية القيام بذلك:
```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // تحويل الشريحة الأولى في العرض التقديمي إلى bitmap بالحجم المحدد.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // حفظ الصورة بصيغة JPEG.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```


## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

قد تحتوي بعض الشرائح على ملاحظات وتعليقات.

توفر Aspose.Slides واجهتين—[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) و[IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/)—تتيحان لك التحكم في عملية تصيير شرائح العروض التقديمية إلى صور. تضم كلتا الواجهتين الخاصية `SlidesLayoutOptions`، التي تمكنك من تكوين تصيير الملاحظات والتعليقات على الشريحة عند تحويلها إلى صورة.

باستخدام فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/)، يمكنك تحديد الموقع المفضل للملاحظات والتعليقات في الصورة الناتجة.

هذا الكود C# يُظهر كيفية تحويل شريحة تحتوي على ملاحظات وتعليقات:
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
            NotesPosition = NotesPositions.BottomTruncated,  // تحديد موضع الملاحظات.
            CommentsPosition = CommentsPositions.Right,      // تحديد موضع التعليقات.
            CommentsAreaWidth = 500,                         // تحديد عرض منطقة التعليقات.
            CommentsAreaColor = Color.AntiqueWhite           // تحديد لون منطقة التعليقات.
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


{{% alert title="ملاحظة" color="warning" %}} 

في أي عملية تحويل من شريحة إلى صورة، لا يمكن تعيين الخاصية [NotesPosition](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) إلى `BottomFull` (لتحديد موقع الملاحظات) لأن نص الملاحظة قد يكون كبيرًا جدًا، مما يجعله غير قادر على التناسب مع حجم الصورة المحدد.

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

توفر واجهة [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) تحكمًا أكبر في صورة TIFF الناتجة من خلال السماح لك بتحديد معلمات مثل الحجم، والدقة، ولوحة الألوان، وأكثر.

هذا الكود C# يوضح عملية تحويل تستخدم خيارات TIFF لإنتاج صورة بالأبيض والأسود بدقة 300 DPI وحجم 2160 × 2800:
```cs
// تحميل ملف عرض تقديمي.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // احصل على الشريحة الأولى من العرض التقديمي.
    ISlide slide = presentation.Slides[0];

    // إعداد إعدادات صورة TIFF الناتجة.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // تحديد حجم الصورة.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // تحديد تنسيق البكسل (أسود وأبيض).
        DpiX = 300,                                        // تحديد الدقة الأفقية.
        DpiY = 300                                         // تحديد الدقة العمودية.
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

يتيح لك Aspose.Slides تحويل جميع الشرائح في عرض تقديمي إلى صور، مما يؤدي إلى تحويل العرض بأكمله إلى سلسلة من الصور.

هذا مثال الكود يوضح كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام C#:
```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // تحويل العرض التقديمي إلى صور شريحة بشريحة.
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


## **FAQ**

**1. هل يدعم Aspose.Slides تصيير الشرائح مع الحركات؟**

لا، طريقة `GetImage` تحفظ صورة ثابتة فقط للشريحة، دون الحركات.

**2. هل يمكن تصدير الشرائح المخفية كصور؟**

نعم، يمكن معالجة الشرائح المخفية كأي شرائح أخرى. فقط تأكد من تضمينها في حلقة المعالجة.

**3. هل يمكن حفظ الصور بظل وتأثيرات؟**

نعم، يدعم Aspose.Slides تصيير الظلال والشفافية وغيرها من المؤثرات الرسومية عند حفظ الشرائح كصور.