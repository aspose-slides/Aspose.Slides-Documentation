---
title: تحويل شرائح العرض التقديمي إلى صور SVG في بايثون
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض التقديمي إلى SVG
- الشريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- خيارات تصدير SVG
- PowerPoint
- العرض التقديمي
- بايثون
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG في بايثون والتحكم بالخطوط والنصوص والصور باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صورة قائم على XML وقابل للتوسّع يعمل جيدًا للنشر على الويب، وعارض الشرائح، وسير عمل إمكانية الوصول، والمعالجة اللاحقة الآلية. تقوم Aspose.Slides بتصدير كل شريحة إلى ملف SVG منفصل وتتيح لك التحكم في كيفية كتابة النصوص، الخطوط، الصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgoptions/) عندما يجب أن يكون الـ SVG المصدر مضغوطًا، أو متوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/)، حدّد شريحة، واكتبها إلى تدفق. المثال التالي يصدر كل شريحة في عرض تقديمي كملف SVG منفصل.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

يستخدم اسم الملف الخاصية [Slide.slide_number](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/slide_number/) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [Shape.write_as_svg](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/write_as_svg/) عندما يحتاج عارض الشرائح أو صفحة ويب إلى ذلك الشكل فقط.

## **تكوين إخراج SVG**

[SVGOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgoptions/) يتحكم في تصيير SVG. بالنسبة لإطارات النص، تشمل [SVGOptions.use_frame_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgoptions/use_frame_size/) إطار النص في منطقة التصيير، وتحدّد [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) ما إذا كان سيتم تطبيق تدوير الإطار. اضبط [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) إلى `True` عندما يجب عرض النص دون روابط حروف.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **التحكم في النصوص والخطوط**

### **تحويل كل النص إلى رسومات متجهة**

اضبط [SVGOptions.vectorize_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgoptions/vectorize_text/) إلى `True` لكتابة كل نص الشريحة كرسومات متجهة. هذا يلغي الاعتماد على الخطوط ويجعل النتيجة البصرية أكثر اتساقًا عبر المتصفحات، لكن النص لن يكون قابلًا للتحديد أو البحث كنص SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **اختر طريقة معالجة الخطوط الخارجية**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgexternalfontshandling/) للخطوط التي تُحمَّل خارجيًا. اختر `ADD_LINKS_TO_FONT_FILES` للإشارة إلى ملفات خطوط منفصلة، أو `EMBED` لتضمين بيانات الخط داخل SVG، أو `VECTORIZE` لتصنيع النصوص التي تستخدم خطوطًا خارجية كرسومات. تحقق من ترخيص الخط قبل تضمينه.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **تقليل حجم الصور المضمنة**

استخدم [SVGOptions.pictures_compression](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgoptions/pictures_compression/) لتقليل دقة الصور المضمنة، و[SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) لحذف المناطق المقتصة من المصدر، و[SVGOptions.jpeg_quality](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgoptions/jpeg_quality/) للتحكم في جودة ترميز JPEG. هذه الإعدادات تقلل حجم الملف على حساب دقة الصورة أو الاحتفاظ ببيانات الصورة.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **الأسئلة الشائعة**

**متى يجب أن أستخدم [SVGOptions.vectorize_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgoptions/vectorize_text/) بدلاً من [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgexternalfontshandling/)?**

استخدم [SVGOptions.vectorize_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgoptions/vectorize_text/) عندما يجب أن يكون كل النص مستقلاً عن الخطوط. استخدم [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgexternalfontshandling/) عندما ينبغي تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لتصغير حجم SVG؟**

ابدأ بضغط الصور المضمنة، حذف المناطق المقصوصة من الصور، واختيار ملفات خطوط مرتبطة عندما يكون بيئة الهدف قادرة على تقديمها. اختبر النتيجة لأن خفض دقة الصورة، خفض جودة JPEG، وتحويل النص إلى متجهات كل منها يؤثر على الجودة وحجم الملف بطرق مختلفة.