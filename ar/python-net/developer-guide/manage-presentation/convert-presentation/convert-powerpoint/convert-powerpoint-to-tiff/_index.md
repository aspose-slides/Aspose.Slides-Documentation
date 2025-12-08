---
title: تحويل عروض PowerPoint إلى TIFF باستخدام Python
titlelink: PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/python-net/convert-powerpoint-to-tiff/
keywords:
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض التقديمي
- تحويل الشريحة
- PowerPoint إلى TIFF
- OpenDocument إلى TIFF
- العرض التقديمي إلى TIFF
- الشريحة إلى TIFF
- PPT إلى TIFF
- PPTX إلى TIFF
- ODP إلى TIFF
- Python
- Aspose.Slides
description: "تعرف على كيفية تحويل عروض PowerPoint (PPT، PPTX) و OpenDocument (ODP) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides للغة Python عبر .NET. دليل خطوة بخطوة مع أمثلة على الشيفرة متضمنة."
---

## **نظرة عامة**

TIFF (**Tagged Image File Format**) هو تنسيق صور نقطية غير فقدان يُستخدم على نطاق واسع ويتمتع بجودة استثنائية وحفظ تفصيلي للرسومات. يختار المصممون والمصورون وناشرو الكتب المكتبية غالبًا TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) مباشرة إلى صور TIFF عالية الجودة، لضمان بقاء عروضك التقديمية بأقصى درجات الدقة البصرية.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods) المقدمة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض PowerPoint كامل إلى TIFF. تتطابق صور TIFF الناتجة مع حجم الشريحة الافتراضي.

يعرض هذا الكود Python كيفية تحويل عرض PowerPoint إلى TIFF:
```py
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation الذي يمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
with slides.Presentation("presentation.pptx") as presentation:
    # حفظ العرض التقديمي كملف TIFF.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```


## **تحويل عرض تقديمي إلى TIFF بالأبيض والأسود**

تتيح الخاصية [bw_conversion_mode](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) في فئة [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) تحديد الخوارزمية المستخدمة عند تحويل شريحة أو صورة ملونة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد ينطبق فقط عندما تكون الخاصية [compression_type](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/compression_type/) مضبوطة على `CCITT4` أو `CCITT3`.

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![A presentation slide](slide_black_and_white.png)

يعرض هذا الكود Python كيفية تحويل الشريحة الملونة إلى TIFF بالأبيض والأسود:
```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```


النتيجة:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **تحويل عرض تقديمي إلى TIFF بحجم مخصص**

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك ضبط القيم المطلوبة باستخدام الخصائص المتوفرة في [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/). على سبيل المثال، تتيح الخاصية [image_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/image_size/) تحديد حجم الصورة الناتجة.

يعرض هذا الكود Python كيفية تحويل عرض PowerPoint إلى صور TIFF بحجم مخصص:
```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# إنشاء كائن من الفئة Presentation الذي يمثل ملف عرض تقديمي (PPT, PPTX, ODP, إلخ).
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # تعيين نوع الضغط.
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    Compression types:
        Default - Specifies the default compression scheme (LZW).
        None - Specifies no compression.
        CCITT3
        CCITT4
        LZW
        RLE
    """

    # تعيين DPI للصورة.
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # تعيين حجم الصورة.
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # حفظ العرض التقديمي كملف TIFF بالحجم المحدد.
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```


## **تحويل عرض تقديمي إلى TIFF بصيغة بكسل مخصصة للصورة**

باستخدام الخاصية [pixel_format](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/pixel_format/) من فئة [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/)، يمكنك تحديد صيغة البكسل المفضلة للصورة TIFF الناتجة.

يعرض هذا الكود Python كيفية تحويل عرض PowerPoint إلى صورة TIFF بصيغة بكسل مخصصة:
```py
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation الذي يمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat contains the following values (as stated in the documentation):
        FORMAT_1BPP_INDEXED - 1 bit per pixel, indexed.
        FORMAT_4BPP_INDEXED - 4 bits per pixel, indexed.
        FORMAT_8BPP_INDEXED - 8 bits per pixel, indexed.
        FORMAT_24BPP_RGB    - 24 bits per pixel, RGB.
        FORMAT_32BPP_ARGB   - 32 bits per pixel, ARGB.
    """

    # حفظ العرض التقديمي كملف TIFF بالحجم المحدد للصورة.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```


{{% alert title="Tip" color="primary" %}}
تحقق من أداة التحويل المجانية من PowerPoint إلى ملصق من Aspose [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تحويل شريحة فردية بدلاً من العرض التقديمي كامل إلى TIFF؟**

نعم. يتيح Aspose.Slides تحويل الشرائح الفردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك أي حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا، لا يفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بأي حجم إلى تنسيق TIFF.

**هل يتم الاحتفاظ بالرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذلك لا يتم حفظ الرسوم المتحركة أو تأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.