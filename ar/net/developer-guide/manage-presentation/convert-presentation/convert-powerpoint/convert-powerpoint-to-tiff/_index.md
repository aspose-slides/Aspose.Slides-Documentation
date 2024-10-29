---
title: تحويل PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/net/convert-powerpoint-to-tiff/
keywords: "تحويل عرض PowerPoint, PowerPoint إلى TIFF, PPT إلى TIFF, PPTX إلى TIFF, C#, Csharp, .NET, Aspose.Slides"
description: "تحويل عرض PowerPoint إلى TIFF في C# أو .NET."

---

TIFF (**تنسيق ملف الصورة المرقم**) هو تنسيق صورة نقطية غير مضغوط وعالي الجودة. يستخدم المحترفون TIFF لأغراض التصميم والتصوير والنشر المكتبي. على سبيل المثال، إذا كنت ترغب في الحفاظ على الطبقات والإعدادات في تصميمك أو صورتك، فقد ترغب في حفظ عملك كملف صورة TIFF.

تتيح لك Aspose.Slides تحويل الشرائح في PowerPoint مباشرة إلى TIFF.

{{% alert title="نصيحة" color="primary" %}}

قد ترغب في الاطلاع على [محول PowerPoint إلى ملصق مجاناً](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) من Aspose.

{{% /alert %}}

## **تحويل PowerPoint إلى TIFF**

باستخدام أسلوب [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) المعروض بواسطة فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، يمكنك تحويل عرض PowerPoint بالكامل بسرعة إلى TIFF. الصور الناتجة بتنسيق TIFF تتوافق مع الحجم الافتراضي للشرائح.

يوضح هذا الكود C# كيفية تحويل PowerPoint إلى TIFF:

```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    // يحفظ العرض كمستند TIFF
    presentation.Save("Tiffoutput_out.tiff", SaveFormat.Tiff);
}
```

## **تحويل PowerPoint إلى TIFF بالأبيض والأسود**

في Aspose.Slides 23.10، أضافت Aspose.Slides خاصية جديدة ([BwConversionMode](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/bwconversionmode/)) إلى فئة [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) للسماح لك بتحديد الخوارزمية المتبعة عند تحويل شريحة أو صورة ملونة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون خاصية [CompressionType](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) مضبوطة على `CCITT4` أو `CCITT3`.

يوضح هذا الكود C# كيفية تحويل شريحة أو صورة ملونة إلى TIFF بالأبيض والأسود:

```c#
var tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
```

## **تحويل PowerPoint إلى TIFF بحجم مخصص**

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك تعريف أرقامك المفضلة من خلال الخصائص المتاحة في [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/). باستخدام خاصية [ImageSize](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) على سبيل المثال، يمكنك تعيين حجم للصورة الناتجة.

يوضح هذا الكود C# كيفية تحويل PowerPoint إلى صور TIFF بحجم مخصص:

```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("Convert_Tiff_Custom.pptx"))
{
    // ينشئ فئة TiffOptions
    TiffOptions opts = new TiffOptions();

    // يحدد نوع الضغط
    opts.CompressionType = TiffCompressionTypes.Default;

    INotesCommentsLayoutingOptions notesOptions = opts.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;
    // أنواع الضغط

    // الافتراضي - يحدد مخطط الضغط الافتراضي (LZW).
    // لا شيء - يحدد عدم وجود ضغط.
    // CCITT3
    // CCITT4
    // LZW
    // RLE

    // العمق يعتمد على نوع الضغط ولا يمكن تعيينه يدوياً.
    // وحدة الدقة دائماً تساوي "2" (نقاط لكل بوصة)

    // تعيين DPI الصورة
    opts.DpiX = 200;
    opts.DpiY = 100;

    // تعيين حجم الصورة
    opts.ImageSize = new Size(1728, 1078);

    // حفظ العرض إلى TIFF بالحجم المحدد
    pres.Save("TiffWithCustomSize_out.tiff", SaveFormat.Tiff, opts);
}
```

## **تحويل PowerPoint إلى TIFF بتنسيق بكسل صورة مخصص**

باستخدام خاصية [PixelFormat](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) ضمن فئة [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions)، يمكنك تحديد تنسيق البكسل المفضل لديك لصورة TIFF الناتجة.

يوضح هذا الكود C# كيفية تحويل PowerPoint إلى صورة TIFF بتنسيق بكسل مخصص:

```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    TiffOptions options = new TiffOptions();
   
    options.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    يحتوي ImagePixelFormat على القيم التالية (كما هو مذكور في الوثائق):
    Format1bppIndexed; // 1 بت لكل بكسل، فهرس.
    Format4bppIndexed; // 4 بت لكل بكسل، فهرس.
    Format8bppIndexed; // 8 بت لكل بكسل، فهرس.
    Format24bppRgb; // 24 بت لكل بكسل، RGB.
    Format32bppArgb; // 32 بت لكل بكسل، ARGB.
    */

    // حفظ العرض إلى TIFF بحجم الصورة المحدد
    presentation.Save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat.Tiff, options);
}
```