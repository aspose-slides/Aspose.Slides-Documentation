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
description: "تعرف على كيفية تحويل عروض PowerPoint (PPT، PPTX) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides لـ .NET. أمثلة كود C#."
---
## **المقدمة**

TIFF (**تنسيق ملف الصورة الموسومة**) هو تنسيق صور نقطية غير مضغوط يُستخدم على نطاق واسع ويشتهر بجودته الاستثنائية والحفاظ الدقيق على الرسومات. يختار المصممون ومصورو الفوتوغرافيا والناشرون المكتبيون غالبًا TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) مباشرة إلى صور TIFF عالية الجودة، مما يضمن احتفاظ عروضك التقديمية بأقصى قدر من الدقة البصرية.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) المقدمة من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/)، يمكنك بسرعة تحويل كامل عرض PowerPoint إلى TIFF. تتطابق صور TIFF الناتجة مع حجم الشريحة الافتراضي.

يعرض هذا الكود بلغة C# كيفية تحويل عرض PowerPoint إلى TIFF:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // حفظ العرض التقديمي كملف TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **تحويل عرض تقديمي إلى TIFF بالأبيض والأسود**

تتيح الخاصية [BwConversionMode](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/bwconversionmode/) في فئة [TiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/) لك تحديد الخوارزمية المستخدمة عند تحويل شريحة ملونة أو صورة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد ينطبق فقط عندما تكون الخاصية [CompressionType](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/compressiontype/) مضبوطة على `CCITT4` أو `CCITT3`.

{{% alert color="info" title="ملاحظة" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/bwconversionmode/) هو إعداد على مستوى التصدير يحدد خوارزمية تحويل البكسل للصور TIFF بالكامل. لتحديد كيفية ظهور شكل منفرد عندما يكون وضع العرض بالأبيض والأسود مفعّلاً، استخدم [IShape.BlackWhiteMode](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/blackwhitemode/). راجع [Control Black-and-White Rendering for Shapes](/slides/ar/net/shape-formatting/#control-black-and-white-rendering-for-shapes) للحصول على أمثلة.
{{% /alert %}}

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![شريحة عرض تقديمي](slide_black_and_white.png)

يعرض هذا الكود بلغة C# كيفية تحويل الشريحة الملونة إلى TIFF بالأبيض والأسود:

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

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك ضبط القيم المطلوبة باستخدام الخصائص المتوفرة في [TiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/). على سبيل المثال، تسمح الخاصية [ImageSize](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/imagesize/) لك بتعريف حجم الصورة الناتجة.

يعرض هذا الكود بلغة C# كيفية تحويل عرض PowerPoint إلى صور TIFF بحجم مخصص:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // ضبط نوع الضغط.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    أنواع الضغط:
        Default - يحدد مخطط الضغط الافتراضي (LZW).
        None - يحدد عدم وجود ضغط.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // يعتمد العمق على نوع الضغط ولا يمكن ضبطه يدويًا.

    // ضبط DPI الصورة.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // ضبط حجم الصورة.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // حفظ العرض التقديمي كملف TIFF بالحجم المحدد.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **تحويل عرض تقديمي إلى TIFF بصيغة بيكسل مخصصة**

باستخدام الخاصية [PixelFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/pixelformat/) من فئة [TiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions) يمكنك تحديد صيغة البيكسل المفضلة للصورة TIFF الناتجة.

يعرض هذا الكود بلغة C# كيفية تحويل عرض PowerPoint إلى صورة TIFF بصيغة بيكسل مخصصة:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat يحتوي على القيم التالية (كما هو مذكور في الوثائق):
        Format1bppIndexed - 1 بت لكل بكسل، مُفهرس.
        Format4bppIndexed - 4 بتات لكل بكسل، مُفهرس.
        Format8bppIndexed - 8 بتات لكل بكسل، مُفهرس.
        Format24bppRgb    - 24 بت لكل بكسل، RGB.
        Format32bppArgb   - 32 بت لكل بكسل، ARGB.
    */

    // حفظ العرض التقديمي كملف TIFF بالحجم المحدد للصورة.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="نصيحة" color="info" %}}
تحقق من أداة Aspose المجانية لتحويل PowerPoint إلى ملصق [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل شريحة فردية بدلاً من تحويل العرض التقديمي بالكامل إلى TIFF؟**

نعم. يتيح Aspose.Slides لك تحويل شرائح فردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

 لا، لا يفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بأي حجم إلى تنسيق TIFF.

**هل يتم الحفاظ على رسوميات PowerPoint والانتقالات عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذلك لا يتم الحفاظ على الرسوم المتحركة أو تأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.