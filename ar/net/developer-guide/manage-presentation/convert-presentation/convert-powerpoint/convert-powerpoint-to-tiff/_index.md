---
title: تحويل عروض PowerPoint إلى TIFF في .NET
titlelink: PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/net/convert-powerpoint-to-tiff/
keywords:
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى TIFF
- العرض التقديمي إلى TIFF
- الشريحة إلى TIFF
- PPT إلى TIFF
- PPTX إلى TIFF
- حفظ PPT بصيغة TIFF
- حفظ PPTX بصيغة TIFF
- تصدير PPT إلى TIFF
- تصدير PPTX إلى TIFF
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تحويل عروض PowerPoint (PPT, PPTX) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides لـ .NET. أمثلة كود C#."
---
## **مقدمة**

TIFF (**Tagged Image File Format**) هو تنسيق صورة نقطية غير مضغوطة يُستخدم على نطاق واسع، ويُعرف بجودته الاستثنائية والحفاظ المفصل على الرسومات. غالبًا ما يختار المصممون والمصورون وناشرو الصفحات المكتبية TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT, PPTX) وشرائح OpenDocument (ODP) مباشرةً إلى صور TIFF عالية الجودة، مما يضمن احتفاظ عروضك التقديمية بأعلى مستوى من الدقة البصرية. 

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) المقدمة من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض PowerPoint كامل إلى TIFF. الصور الناتجة بصيغة TIFF تتطابق مع حجم الشريحة الافتراضي.

هذا الكود C# يوضح كيفية تحويل عرض PowerPoint إلى TIFF:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // احفظ العرض التقديمي بصيغة TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **تحويل عرض تقديمي إلى TIFF بالأبيض والأسود**

الخاصية [BwConversionMode](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/bwconversionmode/) في فئة [TiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/) تتيح لك تحديد الخوارزمية المستخدمة عند تحويل شريحة أو صورة ملونة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون الخاصية [CompressionType](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/compressiontype/) مُعيَّنة إلى `CCITT4` أو `CCITT3`.

{{% alert color="info" title="ملاحظة" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/bwconversionmode/) هو إعداد على مستوى التصدير يختار خوارزمية تحويل البكسلات للصورة الكاملة بصيغة TIFF. لتحديد كيفية ظهور شكل فردي عندما يكون وضع العرض بالأبيض والأسود فعالاً، استخدم [IShape.BlackWhiteMode](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/blackwhitemode/). راجع [Control Black-and-White Rendering for Shapes](/net/shape-formatting/#control-black-and-white-rendering-for-shapes) للحصول على أمثلة.
{{% /alert %}}

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![شريحة عرض تقديمي](slide_black_and_white.png)

هذا الكود C# يوضح كيفية تحويل الشريحة الملونة إلى TIFF بالأبيض والأسود:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```

النتيجة:

![TIFF بالأبيض والأسود](TIFF_black_and_white.png)

## **تحويل عرض تقديمي إلى TIFF بحجم مخصص**

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك ضبط القيم المطلوبة باستخدام الخصائص المتوفرة في [TiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/). على سبيل المثال، الخاصية [ImageSize](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/imagesize/) تتيح لك تحديد حجم الصورة الناتجة.

هذا الكود C# يوضح كيفية تحويل عرض PowerPoint إلى صور TIFF بحجم مخصص:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // تعيين نوع الضغط.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    أنواع الضغط:
        Default - يحدد نظام الضغط الافتراضي (LZW).
        None - لا ضغط.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // العمق يعتمد على نوع الضغط ولا يمكن تعيينه يدويًا.

    // تعيين DPI الصورة.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // تعيين حجم الصورة.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // حفظ العرض التقديمي بصيغة TIFF بالحجم المحدد.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **تحويل عرض تقديمي إلى TIFF مع تنسيق بكسل صورة مخصص**

باستخدام الخاصية [PixelFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/pixelformat/) من فئة [TiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions)، يمكنك تحديد تنسيق البكسل المفضل للصورة الناتجة بصيغة TIFF.

هذا الكود C# يوضح كيفية تحويل عرض PowerPoint إلى صورة TIFF مع تنسيق بكسل مخصص:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat يحتوي على القيم التالية (كما هو موضح في الوثائق):
        Format1bppIndexed - بت واحد لكل بكسل، مفهرس.
        Format4bppIndexed - 4 بتات لكل بكسل، مفهرس.
        Format8bppIndexed - 8 بتات لكل بكسل، مفهرس.
        Format24bppRgb    - 24 بت لكل بكسل، RGB.
        Format32bppArgb   - 32 بت لكل بكسل، ARGB.
    */

    // حفظ العرض التقديمي بصيغة TIFF بالحجم المحدد للصورة.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="نصيحة" color="info" %}}
تحقق من [محول PowerPoint إلى ملصق مجاني]https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تحويل شريحة فردية بدلًا من تحويل عرض PowerPoint بالكامل إلى TIFF؟**

نعم. يتيح لك Aspose.Slides تحويل شرائح منفردة من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك أي حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا، لا تفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بأي حجم إلى صيغة TIFF.

**هل يتم الحفاظ على الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. وبالتالي لا يتم الحفاظ على الرسوم المتحركة أو تأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.