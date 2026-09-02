---
title: تحويل عروض PowerPoint إلى TIFF في Python
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
description: "تعلم كيفية تحويل عروض PowerPoint (PPT، PPTX) وOpenDocument (ODP) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides لبايثون عبر .NET. دليل خطوة بخطوة مع أمثلة على الشيفرة مضمّن."
---
## **المقدمة**

TIFF (**Tagged Image File Format**) هو تنسيق صورة نقطية غير مضغوط واسع الاستخدام يُعرف بجودته الاستثنائية وحفظه التفصيلي للرسومات. غالبًا ما يختار المصممون والمصورون والناشرون المكتبيون TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) مباشرةً إلى صور TIFF عالية الجودة، مما يضمن احتفاظ عروضك التقديمية بأقصى درجات الدقة البصرية.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/#methods) المقدمة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/)، يمكنك بسرعة تحويل ملف PowerPoint كامل إلى TIFF. تتطابق صور TIFF الناتجة مع حجم الشريحة الافتراضي.

يظهر هذا الكود بايثون كيفية تحويل عرض تقديمي PowerPoint إلى TIFF:

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
with slides.Presentation("presentation.pptx") as presentation:
    # حفظ العرض التقديمي كملف TIFF.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **تحويل عرض تقديمي إلى TIFF بالأبيض والأسود**

خاصية [bw_conversion_mode](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) في الفئة [TiffOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/) تتيح لك تحديد الخوارزمية المستخدمة عند تحويل شريحة أو صورة ملونة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون خاصية [compression_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/compression_type/) مضبوطة على `CCITT4` أو `CCITT3`.

{{% alert color="info" title="ملاحظة" %}}
[TiffOptions.bw_conversion_mode](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) هو إعداد على مستوى التصدير يختار خوارزمية تحويل البكسل للصورة TIFF الكاملة. لتحديد كيف يجب أن يظهر شكل فردي عندما يكون وضع العرض بالأبيض والأسود مفعلاً، استخدم [Shape.black_white_mode](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/black_white_mode/). راجع [Control Black-and-White Rendering for Shapes](/python-net/shape-formatting/#control-black-and-white-rendering-for-shapes) للأمثلة.
{{% /alert %}}

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![شريحة عرض تقديمي](slide_black_and_white.png)

هذا الكود بايثون يوضح كيفية تحويل الشريحة الملونة إلى TIFF بالأبيض والأسود:

```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

النتيجة:

![TIFF بالأبيض والأسود](TIFF_black_and_white.png)

## **تحويل عرض تقديمي إلى TIFF بحجم مخصص**

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك ضبط القيم المطلوبة باستخدام الخصائص المتاحة في [TiffOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/). على سبيل المثال، خاصية [image_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/image_size/) تسمح لك بتحديد حجم الصورة الناتجة.

هذا الكود بايثون يوضح كيفية تحويل عرض تقديمي PowerPoint إلى صور TIFF بحجم مخصص:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
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

## **تحويل عرض تقديمي إلى TIFF بصيغة بكسل مخصصة**

باستخدام خاصية [pixel_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/pixel_format/) من الفئة [TiffOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/)، يمكنك تحديد صيغة البكسل المفضلة للصورة TIFF الناتجة.

هذا الكود بايثون يوضح كيفية تحويل عرض تقديمي PowerPoint إلى صورة TIFF بصيغة بكسل مخصصة:

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
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

    # حفظ العرض التقديمي كملف TIFF بصيغة البكسل المحددة.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="نصيحة" color="info" %}}
اطلع على [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online) من Aspose.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل شريحة فردية بدلاً من عرض PowerPoint كامل إلى TIFF؟**

نعم. يتيح لك Aspose.Slides تحويل شرائح فردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا، لا تفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بأي حجم إلى تنسيق TIFF.

**هل يتم الحفاظ على الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذلك لا يتم حفظ الرسوم المتحركة وتأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.