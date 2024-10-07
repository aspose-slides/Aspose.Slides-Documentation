---
title: تحويل الشريحة
type: docs
weight: 41
url: /net/convert-slide/
keywords: 
- تحويل الشريحة إلى صورة
- تصدير الشريحة كصورة
- حفظ الشريحة كصورة
- الشريحة إلى صورة
- الشريحة إلى PNG
- الشريحة إلى JPEG
- الشريحة إلى بت ماب
- C#
- Csharp
- .NET
- Aspose.Slides لـ .NET
description: "تحويل شرائح PowerPoint إلى صور (بت ماب، PNG، أو JPG) في C# أو .NET"
---

تتيح لك Aspose.Slides لـ .NET تحويل الشرائح (في العروض التقديمية) إلى صور. هذه هي تنسيقات الصور المدعومة: BMP، PNG، JPG (JPEG)، GIF، وغيرها.

لتحويل الشريحة إلى صورة، قم بذلك:

1. أولاً، قم بتعيين معلمات التحويل وكائنات الشريحة التي سيتم تحويلها باستخدام:
   * واجهة [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) أو
   * واجهة [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions).

2. ثانيًا، قم بتحويل الشريحة إلى صورة باستخدام طريقة [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

## **حول بت ماب وتنسيقات الصور الأخرى**

في .NET، كائن [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) هو كائن يسمح لك بالعمل مع الصور المحددة من خلال بيانات البكسل. يمكنك استخدام مثيل من هذه الفئة لحفظ الصور في مجموعة واسعة من التنسيقات (BMP، JPG، PNG، إلخ).

{{% alert title="معلومات" color="info" %}}

طورت Aspose مؤخرًا محول [النص إلى GIF](https://products.aspose.app/slides/text-to-gif) عبر الإنترنت.

{{% /alert %}}

## **تحويل الشرائح إلى بت ماب وحفظ الصور في PNG**

تُظهر لك هذه الشيفرة في C# كيفية تحويل الشريحة الأولى من عرض تقديمي إلى كائن بت ماب ثم كيفية حفظ الصورة في تنسيق PNG:

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // تحويل الشريحة الأولى في العرض التقديمي إلى كائن بت ماب
    using (IImage image = pres.Slides[0].GetImage())
    {
        // حفظ الصورة في تنسيق PNG
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert title="نصيحة" color="primary" %}} 

يمكنك تحويل الشريحة إلى كائن بت ماب ثم استخدام الكائن مباشرة في مكان ما. أو يمكنك تحويل الشريحة إلى بت ماب ثم حفظ الصورة في JPEG أو أي تنسيق آخر تفضله.

{{% /alert %}}  

## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام تحميل زائد من [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/)، يمكنك تحويل الشريحة إلى صورة بأبعاد محددة (طول وعرض).

توضح هذه الشيفرة المثال عملية التحويل المقترحة باستخدام طريقة [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) في C#:

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // تحويل الشريحة الأولى في العرض التقديمي إلى بت ماب بالحجم المحدد
    using (IImage image = pres.Slides[0].GetImage(new Size(1820, 1040)))
    {
        // حفظ الصورة في تنسيق JPEG
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

تحتوي بعض الشرائح على ملاحظات وتعليقات.

توفر Aspose.Slides واجهتين—[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) و[IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions)—التي تتيح لك التحكم في عرض الشرائح التقديمية كصور. تحتوي كلا الواجهتين على واجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) التي تتيح لك إضافة الملاحظات والتعليقات على الشريحة عند تحويل تلك الشريحة إلى صورة.

{{% alert title="معلومات" color="info" %}} 

مع واجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions)، يمكنك تحديد موضعك المفضل للملاحظات والتعليقات في الصورة الناتجة.

{{% /alert %}} 

توضح هذه الشيفرة في C# عملية التحويل لشريحة تحتوي على ملاحظات وتعليقات:

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // إنشاء خيارات العرض
    IRenderingOptions options = new RenderingOptions();

    // تعيين موضع الملاحظات على الصفحة
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // تعيين موضع التعليقات على الصفحة 
    options.NotesCommentsLayouting.CommentsPosition = CommentsPositions.Right;

    // تعيين عرض منطقة إخراج التعليقات
    options.NotesCommentsLayouting.CommentsAreaWidth = 500;

    // تعيين لون منطقة التعليقات
    options.NotesCommentsLayouting.CommentsAreaColor = Color.AntiqueWhite;

    // تحويل الشريحة الأولى من العرض التقديمي إلى كائن بت ماب
    using (IImage image = pres.Slides[0].GetImage(options, 2f, 2f))
        {
        // حفظ الصورة في تنسيق GIF
        image.Save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="ملاحظة" color="warning" %}} 

في أي عملية تحويل شريحة إلى صورة، لا يمكن تعيين خاصية [NotesPositions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/properties/notesposition) إلى BottomFull (لتحديد موضع الملاحظات) لأن نص الملاحظة قد يكون كبيرًا، مما يعني أنه قد لا يتناسب مع حجم الصورة المحدد.

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام ITiffOptions**

تتيح لك واجهة [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) مزيدًا من التحكم (من حيث المعلمات) في الصورة الناتجة. باستخدام هذه الواجهة، يمكنك تحديد الحجم، والدقة، ولوحة الألوان، والمعلمات الأخرى للصورة الناتجة.

توضح هذه الشيفرة في C# عملية تحويل حيث يتم استخدام ITiffOptions لإخراج صورة بالأبيض والأسود بدقة 300dpi وحجم 2160 × 2800:

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // الحصول على الشريحة بواسطة فهرسها
    ISlide slide = pres.Slides[0];

    // إنشاء كائن TiffOptions
    TiffOptions options = new TiffOptions() { ImageSize = new Size(2160, 2880) };

    // تعيين الخط المستخدم في حالة عدم العثور على الخط المصدر
    options.DefaultRegularFont = "Arial Black";

    // تعيين موضع الملاحظات على الصفحة 
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // تعيين تنسيق البكسل (أبيض وأسود)
    options.PixelFormat = ImagePixelFormat.Format1bppIndexed;

    // تعيين الدقة
    options.DpiX = 300;
    options.DpiY = 300;

    // تحويل الشريحة إلى كائن بت ماب
    using (IImage image = slide.GetImage(options))
    {
        // حفظ الصورة في تنسيق BMP
        image.Save("PresentationNotesComments.tiff", ImageFormat.Tiff);
    }
}  
```

## **تحويل جميع الشرائح إلى صور**

تتيح لك Aspose.Slides تحويل جميع الشرائح في عرض تقديمي واحد إلى صور. أساسًا، يمكنك تحويل العرض التقديمي (بكامل طاقته) إلى صور.

تظهر لك هذه الشيفرة المثال كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور في C#:

```csharp
// تحديد المسار إلى دليل الإخراج
string outputDir = @"D:\PresentationImages";

using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // عرض العرض التقديمي كصور مصفوفة شريحة بشريحة
    for (int i = 0; i < pres.Slides.Count; i++)
    {
        // تحديد الإعدادات للشرائح المخفية (عدم عرض الشرائح المخفية)
        if (pres.Slides[i].Hidden)
            continue;

        // تحويل الشريحة إلى كائن بت ماب
        using (IImage image = pres.Slides[i].GetImage(2f, 2f))
        {
            // إنشاء اسم ملف للصورة
            string outputFilePath = Path.Combine(outputDir, "Slide_" + i + ".jpg");

            // حفظ الصورة في تنسيق JPEG
            image.Save(outputFilePath, ImageFormat.Jpeg);
        }
    }
}
```