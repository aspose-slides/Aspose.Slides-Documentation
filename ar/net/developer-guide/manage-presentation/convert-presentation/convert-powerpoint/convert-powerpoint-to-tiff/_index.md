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
- حفظ PPT كـ TIFF
- حفظ PPTX كـ TIFF
- تصدير PPT إلى TIFF
- تصدير PPTX إلى TIFF
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تحويل عروض PowerPoint (PPT، PPTX) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides لـ .NET. أمثلة على كود C#."
---

## **نظرة عامة**

TIFF (**Tagged Image File Format**) هو تنسيق صورة نقطية غير مضغوط يُستخدم على نطاق واسع، ويُعرف بجودته الاستثنائية والحفاظ الدقيق على الرسومات. غالبًا ما يختار المصممون والمصورون والناشرون المكتبيون TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) مباشرة إلى صور TIFF عالية الجودة، مما يضمن بقاء عروضك التقديمية بأقصى درجة من الدقة البصرية.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [حفظ](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) المقدمة من فئة [العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/) يمكنك بسرعة تحويل عرض تقديمي كامل إلى TIFF. تتطابق صور TIFF الناتجة مع حجم الشريحة الافتراضي.

هذا الكود C# يوضح كيفية تحويل عرض تقديمي PowerPoint إلى TIFF:
```cs
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // حفظ العرض التقديمي كملف TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```


## **تحويل عرض تقديمي إلى TIFF أبيض وأسود**

تتيح الخاصية [BwConversionMode](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/bwconversionmode/) في فئة [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) تحديد الخوارزمية المستخدمة عند تحويل شريحة أو صورة ملونة إلى TIFF أبيض وأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون خاصية [CompressionType](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) مضبوطة على `CCITT4` أو `CCITT3`.

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![شريحة عرض تقديمي](slide_black_and_white.png)

هذا الكود C# يوضح كيفية تحويل الشريحة الملونة إلى TIFF أبيض وأسود:
```cs
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

![TIFF أبيض وأسود](TIFF_black_and_white.png)

## **تحويل عرض تقديمي إلى TIFF بحجم مخصص**

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك تعيين القيم المطلوبة باستخدام الخصائص المتاحة في [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/). على سبيل المثال، تسمح خاصية [ImageSize](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) بتحديد حجم الصورة الناتجة.

هذا الكود C# يوضح كيفية تحويل عرض تقديمي PowerPoint إلى صور TIFF بحجم مخصص:
```cs
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // تعيين نوع الضغط.
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

    // يعتمد العمق على نوع الضغط ولا يمكن تعيينه يدويًا.

    // تعيين DPI للصورة.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // تعيين حجم الصورة.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // حفظ العرض التقديمي كـ TIFF بالحجم المحدد.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```


## **تحويل عرض تقديمي إلى TIFF بتنسيق بكسل مخصص للصورة**

باستخدام خاصية [PixelFormat](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) من فئة [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions) يمكنك تحديد تنسيق البكسل المفضل للصورة TIFF الناتجة.

هذا الكود C# يوضح كيفية تحويل عرض تقديمي PowerPoint إلى صورة TIFF بتنسيق بكسل مخصص:
```cs
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat يحتوي على القيم التالية (كما هو مذكور في الوثائق):
        Format1bppIndexed - 1 بت لكل بكسل، مفهرسة.
        Format4bppIndexed - 4 بت لكل بكسل، مفهرسة.
        Format8bppIndexed - 8 بت لكل بكسل، مفهرسة.
        Format24bppRgb    - 24 بت لكل بكسل، RGB.
        Format32bppArgb   - 32 بت لكل بكسل، ARGB.
    */

    // حفظ العرض التقديمي كـ TIFF بالحجم المحدد للصورة.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```


{{% alert title="Tip" color="primary" %}}
تحقق من أداة Aspose المجانية لتحويل PowerPoint إلى ملصق [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل شريحة فردية بدلًا من تحويل العرض التقديمي بالكامل إلى TIFF؟**

نعم. يتيح Aspose.Slides تحويل شرائح فردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك أي حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا، لا يفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بأي حجم إلى تنسيق TIFF.

**هل يتم الحفاظ على الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذا لا يتم الحفاظ على الرسوم المتحركة أو تأثيرات الانتقال؛ يتم تصدير لقطة ثابتة فقط من كل شريحة.