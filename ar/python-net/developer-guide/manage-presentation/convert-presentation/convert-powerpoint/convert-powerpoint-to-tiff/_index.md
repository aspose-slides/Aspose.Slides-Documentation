---
title: تحويل PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/python-net/convert-powerpoint-to-tiff/
keywords: "تحويل عرض PowerPoint, PowerPoint إلى TIFF, PPT إلى TIFF, PPTX إلى TIFF, بايثون, Aspose.Slides"
description: "تحويل عرض PowerPoint إلى TIFF باستخدام بايثون"
---

**TIFF** (تنسيق ملف الصورة المنقوش) هو تنسيق صورة نقطية بلا فقد وجودة عالية. يستخدم المهنيون TIFF لأغراض التصميم والتصوير والنشر المكتبي. على سبيل المثال، إذا كنت ترغب في الحفاظ على الطبقات والإعدادات في تصميمك أو صورتك، فقد ترغب في حفظ عملك كملف صورة TIFF. 

تتيح لك Aspose.Slides تحويل الشرائح في PowerPoint مباشرةً إلى TIFF. 

{{% alert title="نصيحة" color="primary" %}}

قد ترغب في الاطلاع على [محول PowerPoint إلى بوستر المجاني من Aspose](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **تحويل PowerPoint إلى TIFF**

باستخدام طريقة [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods) المعروضة من قبل [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class، يمكنك بسرعة تحويل عرض PowerPoint كامل إلى TIFF. الصور الناتجة بتنسيق TIFF تتوافق مع الحجم الافتراضي للشرائح. 

يوضح لك كود بايثون هذا كيفية تحويل PowerPoint إلى TIFF:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
presentation = slides.Presentation("pres.pptx")
# حفظ العرض التقديمي كـ TIFF
presentation.save("Tiffoutput_out.tiff", slides.export.SaveFormat.TIFF)
```

## **تحويل PowerPoint إلى TIFF بالأبيض والأسود**

في Aspose.Slides 23.10، أضافت Aspose.Slides خاصية جديدة `bw_conversion_mode` إلى [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) class للسماح لك بتحديد الخوارزمية المتبعة عند تحويل شريحة ملونة أو صورة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما يتم تعيين خاصية `compression_type` إلى `CCITT4` أو `CCITT3`.

يوضح لك كود بايثون هذا كيفية تحويل شريحة أو صورة ملونة إلى TIFF بالأبيض والأسود:

```python
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

presentation = slides.Presentation("sample.pptx")
presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **تحويل PowerPoint إلى TIFF بحجم مخصص**

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك تحديد الأرقام المفضلة لديك من خلال الخصائص المقدمة ضمن [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/). باستخدام خاصية `image_size`، على سبيل المثال، يمكنك تعيين حجم للصورة الناتجة. 

يوضح لك كود بايثون هذا كيفية تحويل PowerPoint إلى صور TIFF بأحجام مخصصة:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
pres = slides.Presentation("pres.pptx")

# إنشاء كائن TiffOptions
opts = slides.export.TiffOptions()

# تعيين نوع الضغط
opts.compression_type = slides.export.TiffCompressionTypes.DEFAULT
opts.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# تعيين DPI للصورة
opts.dpi_x = 200
opts.dpi_y = 100

# تعيين حجم الصورة
opts.image_size = drawing.Size(1728, 1078)

# حفظ العرض التقديمي إلى TIFF بالحجم المحدد
pres.save("TiffWithCustomSize_out.tiff", slides.export.SaveFormat.TIFF, opts)
```


## **تحويل PowerPoint إلى TIFF بتنسيق بكسل صورة مخصص**

باستخدام خاصية `pixel_format` تحت [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) class، يمكنك تحديد تنسيق بكسل الصورة المفضل لديك للصورة الناتجة بتنسيق TIFF. 

يوضح لك كود بايثون هذا كيفية تحويل PowerPoint إلى صورة TIFF بتنسيق بكسل صورة مخصص:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
pres = slides.Presentation("pres.pptx")

# إنشاء كائن TiffOptions
options = slides.export.TiffOptions()

options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED

# حفظ العرض التقديمي إلى TIFF بحجم محدد
pres.save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", slides.export.SaveFormat.TIFF, options)
```