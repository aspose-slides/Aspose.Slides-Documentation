---
title: عرض شرائح العرض التقديمي كصور SVG في Python
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض التقديمي إلى SVG
- شريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- خيارات تصدير SVG
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG في Python والتحكم في الخطوط والنصوص والصور باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صورة مبني على XML وقابل للتدرج يعمل بشكل جيد للنشر على الويب، وعارض الشرائح، وسير العمل المتعلق بإمكانية الوصول، والمعالجة التلقائية بعد الإنشاء. تقوم Aspose.Slides بتصدير كل شريحة إلى ملف SVG منفصل وتتيح لك التحكم في كيفية كتابة النصوص، الخطوط، الصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) عندما يجب أن يكون ملف SVG المُصدَّر مضغوطًا، ومتوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، اختر شريحة، واكتبها إلى تدفق. المثال التالي يُصدِّر كل شريحة في عرض تقديمي كملف SVG منفصل.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

يستخدم اسم الملف [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) بدلًا من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) عندما يحتاج عارض الشرائح أو صفحة الويب إلى ذلك الشكل فقط.

## **تهيئة مخرجات SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) يتحكم في تجسيد SVG. بالنسبة لإطارات النص، [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) يضمن تضمين إطار النص في مساحة التجسيد، و[SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) يحدد ما إذا كان يتم تطبيق دوران الإطار. اضبط [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) إلى `True` عندما يجب أن يُعرض النص بدون الروابط الحرفية.

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

## **التحكم في النص والخطوط**

عند تصدير الشرائح إلى SVG، يمكنك التحكم فيما إذا كان النص يبقى كنص أو يتحول إلى رسومات متجهة، وكيفية تضمين الخطوط الخارجية أو الإشارة إليها. تساعدك الخيارات التالية في موازنة التناسق البصري، واختيار النص، واعتمادات الخطوط في ملف SVG المُصدَّر.

### **تحويل كل النص إلى متجه**

اضبط [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) إلى `True` لكتابة كل نص الشريحة كرسومات متجهة. يؤدي ذلك إلى إلغاء اعتمادية الخطوط ويجعل النتيجة البصرية أكثر تناسقًا عبر المتصفحات، ولكن النص لن يكون قابلًا للتحديد أو البحث كنص SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **اختر طريقة معالجة الخطوط الخارجية**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) للخطوط التي يتم تحميلها خارجيًا. اختر `ADD_LINKS_TO_FONT_FILES` للإشارة إلى ملفات خطوط منفصلة، `EMBED` لتضمين بيانات الخط داخل SVG، أو `VECTORIZE` لتجسيد النص الذي يستخدم خطوطًا خارجية كرسومات فقط. تحقق من ترخيص الخط قبل تضمين الخطوط.

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

## **تقليل حجم الصورة المضمنة**

استخدم [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) لتقليل دقة الصور المضمنة، و[SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) لحذف مناطق الصور المقصوصة، و[SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) للتحكم في جودة ترميز JPEG. تقلل هذه الإعدادات من حجم الملف على حساب جودة الصورة أو البيانات المحتفظ بها.

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

## **التحكم في دقة تمثيل الميتافايل**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) يحدد الحد الأدنى للدقة عند تحويل الميتافايلات إلى نقطية أثناء تصدير SVG. استخدمه لموازنة التفصيل وحجم الملف عندما يتم نقطية صورة EMF أو WMF. لا يحدد DPI عالميًا للـ SVG ولا يجبر كل كائن على الشريحة على أن يصبح صورة نقطية.

نزّل [metafile-rasterization.pptx](metafile-rasterization.pptx)، الذي يحتوي على صورة EMF بخطوط قطرية متقاربة. المثال التالي يصدر الشريحة الأولى منه بثلاث دقات نقطية عبر [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). تبقى جميع إعدادات التصدير الأخرى متطابقة بحيث يمكن مقارنة النتائج.

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

في النتيجة، تحولت صورة EMF إلى PNG مضمّن واحد في كل ملف SVG. القياسات التالية تخص العرض التقديمي المرفق؛ ليست صيغة عامة لتحويل DPI إلى أبعاد بكسل.

| دقة تمثيل الميتافايل DPI | أبعاد PNG المضمّن | حجم ملف SVG (بايت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

المقارنة أدناه تُظهر المنطقة نفسها من الصورة النقطية المضمّنة بنفس حجم العرض المكبر. تُظهر الخطوط القطرية بكسلة واضحة عند 72 DPI وحواف أكثر سلاسة عند دقات أعلى، بينما يزداد حجم ملف SVG. زيادة القيمة لا تحسن بالضرورة كل تفاصيل أو تغير كل صورة مُصدَّرة.

![تفاصيل الخط القطري المكبر عند 72 و150 و300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) يتحكم في تقليل دقة الصورة ويمكنه إخفاء تأثير تغيير دقة تمثيل الميتافايل. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) يتحكم في جودة ترميز JPEG، وليس في دقة تمثيل الميتافايل.

## **الأسئلة الشائعة**

**متى يجب علي استخدام [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) بدلاً من [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

استخدم [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) عندما يجب أن يكون كل النص مستقلاً عن الخطوط. استخدم [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) عندما يجب تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لتصغير حجم SVG؟**

ابدأ بضغط الصور المضمنة، حذف مناطق الصور المقصوصة، واختيار ملفات الخطوط المرتبطة عندما يستطيع البيئة المستهدفة تقديمها. اختبر النتيجة لأن تقليل دقة الصورة، جودة JPEG المنخفضة، والنص المتجه كل منها له مقايضات مختلفة بين الجودة والحجم.