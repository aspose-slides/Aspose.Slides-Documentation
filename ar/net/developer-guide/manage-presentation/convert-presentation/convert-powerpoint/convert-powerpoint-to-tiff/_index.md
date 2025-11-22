---
title: تحويل عروض PowerPoint إلى TIFF باستخدام C#
titlelink: PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/net/convert-powerpoint-to-tiff/
keywords:
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل عرض تقديمي
- تحويل شريحة
- PowerPoint إلى TIFF
- OpenDocument إلى TIFF
- عرض تقديمي إلى TIFF
- شريحة إلى TIFF
- PPT إلى TIFF
- PPTX إلى TIFF
- ODP إلى TIFF
- C#
- .NET
- Aspose.Slides
description: "تعلم كيفية تحويل عروض PowerPoint (PPT، PPTX) وOpenDocument (ODP) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides للـ .NET. دليل خطوة بخطوة مع أمثلة على الشيفرة متضمنة."
---

## **نظرة عامة**

TIFF (**Tagged Image File Format**) هو تنسيق صور نقطية غير فقدان يستخدم على نطاق واسع ويشتهر بجودته الاستثنائية والحفاظ المفصل على الرسومات. غالبًا ما يختار المصممون والمصورون والناشرون المكتبيون TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في الصور.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) مباشرةً إلى صور TIFF ذات جودة عالية، مما يضمن أن عروضك التقديمية تحتفظ بأقصى درجة من الدقة البصرية. 

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) المقدمة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض تقديمي كامل إلى TIFF. الصور الناتجة تتطابق مع حجم الشريحة الافتراضي.

هذا الكود C# يوضح كيفية تحويل عرض تقديمي PowerPoint إلى TIFF:
```cs
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // احفظ العرض التقديمي كصورة TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```


## **تحويل عرض تقديمي إلى TIFF بالأبيض والأسود**

الخاصية [BwConversionMode](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/bwconversionmode/) في فئة [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) تتيح لك تحديد الخوارزمية المستخدمة عند تحويل شريحة ملونة أو صورة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون الخاصية [CompressionType](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) مضبوطة على `CCITT4` أو `CCITT3`.

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![A presentation slide](slide_black_and_white.png)

هذا الكود C# يوضح كيفية تحويل الشريحة الملونة إلى TIFF بالأبيض والأسود:
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

![Black-and-White TIFF](TIFF_black_and_white.png)

## **تحويل عرض تقديمي إلى TIFF بحجم مخصص**

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك تعيين القيم المطلوبة باستخدام الخصائص المتاحة في [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/). على سبيل المثال، الخاصية [ImageSize](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) تتيح لك تعريف حجم الصورة الناتجة.

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
        Default - يحدد نظام الضغط الافتراضي (LZW).
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

    // حفظ العرض التقديمي كملف TIFF بالحجم المحدد.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```


## **تحويل عرض تقديمي إلى TIFF بصيغة بكسل مخصصة**

باستخدام الخاصية [PixelFormat](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) من فئة [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions) يمكنك تحديد صيغة البكسل المفضلة للصورة الناتجة.

هذا الكود C# يوضح كيفية تحويل عرض تقديمي PowerPoint إلى صورة TIFF بصيغة بكسل مخصصة:
```cs
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat يحتوي على القيم التالية (كما هو مذكور في الوثائق):
        Format1bppIndexed - 1 بت لكل بكسل، مفهرس.
        Format4bppIndexed - 4 بت لكل بكسل، مفهرس.
        Format8bppIndexed - 8 بت لكل بكسل، مفهرس.
        Format24bppRgb    - 24 بت لكل بكسل، RGB.
        Format32bppArgb   - 32 بت لكل بكسل، ARGB.
    */

    // احفظ العرض التقديمي كملف TIFF بالحجم المحدد للصورة.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```


{{% alert title="Tip" color="primary" %}}

تحقق من أداة Aspose المجانية لتحويل PowerPoint إلى ملصق [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تحويل شريحة واحدة بدلاً من عرض تقديمي كامل إلى TIFF؟**

نعم. يتيح لك Aspose.Slides تحويل شرائح فردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا، لا تفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بأي حجم إلى تنسيق TIFF.

**هل يتم الحفاظ على الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذلك لا يتم حفظ الرسوم المتحركة أو تأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.