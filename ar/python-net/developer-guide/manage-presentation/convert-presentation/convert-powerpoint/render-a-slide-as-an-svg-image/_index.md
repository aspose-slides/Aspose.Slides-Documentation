---
title: تحويل شرائح العرض إلى صور SVG في بايثون
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض إلى SVG
- الشريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- خيارات تصدير SVG
- PowerPoint
- عرض
- Python
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG في بايثون والتحكم في الخطوط والنصوص والصور باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صور قائم على XML قابل للتوسيع يعمل بشكل جيد للنشر على الويب، وعرض الشرائح، وسير عمل إمكانية الوصول، والمعالجة اللاحقة الآلية. تقوم Aspose.Slides بتصدير كل شريحة إلى ملف SVG منفصل وتتيح لك التحكم في كيفية كتابة النصوص، الخطوط، الصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) عندما يجب أن يكون SVG المُصدَّر مضغوطًا، ومتوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، حدد شريحة، واكتبها إلى تدفق. المثال التالي يصدر كل شريحة في العرض التقديمي كملف SVG منفصل.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

يستخدم اسم الملف [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) عندما يحتاج عرض الشرائح أو صفحة الويب إلى ذلك الشكل فقط.

## **تكوين مخرجات SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) يتحكم في عرض SVG. بالنسبة لإطارات النص، [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) يضمن إطارة النص في مساحة العرض، و[SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) يحدد ما إذا كان يتم تطبيق تدوير الإطار. اضبط [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) على `True` عندما يجب عرض النص بدون الأحرف المتصلة.

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

## **التحكم في قص طرف الخط عند رؤوس السهام**

ليس لدى SVG 1.1 إعداد لتحديد موضع تقليم العلامة لتحديد أين يجب أن يتوقف الخط تحت رأس السهم. بشكل افتراضي، تقوم Aspose.Slides بتقصير الخط المُصدَّر بحيث لا يبرز خطه عبر العلامة. اضبط [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) على `True` لرسم الخط حتى النهاية الأصلية للخط. هذا الإعداد يؤثر فقط على مخرجات SVG. يبقى الخط في موضعه وطوله على الشريحة.

يرسم المثال رؤوس سهام مثلثية وماسية على خطوط بعرض نقطتين وعشرة نقاط. يصدر الشريحة نفسها مرتين، مع تغيير خيار القص فقط.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

تظهر المقارنة رأس السهم المثلثي على الخط بعرض 10 نقاط. عند تمكين القطع، يصبح الطرف حادًا. عند تعطيل القطع، يبرز الخط عبر جوانب العلامة المائلة ويترك طرفًا مسطحًا.

![مثلث مكوّن من 10 نقاط مكبر مع طرف حاد عندما يكون القطع مفعلاً وطرف مسطح عندما يكون القطع معطَّلاً](line-end-cropping.png)

في الخطوط الأخرى من المثال، يكون الخط البارز أقل وضوحًا على المثلث بعرض نقطتين. يغطي الماس المملوء نهاية الخط في كلا العرضين.

## **التحكم في النص والخطوط**

عند تصدير الشرائح إلى SVG، يمكنك التحكم فيما إذا كان النص يبقى كنص أو يتحول إلى رسومات متجهة، وكيفية تضمين الخطوط الخارجية أو الإشارة إليها. تساعدك الخيارات التالية على موازنة التناسق البصري، واختيار النص، واعتمادية الخطوط في SVG المُصدَّر.

### **تحويل كل النص إلى متجهات**

اضبط [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) على `True` لكتابة كل نص الشريحة كرسومات متجهة. هذا يلغي اعتمادية الخطوط ويجعل النتيجة البصرية أكثر تناسقًا عبر المتصفحات، ولكن النص لن يكون قابلًا للتحديد أو البحث كنص SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **اختر طريقة معالجة الخطوط الخارجية**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) للخطوط التي يتم تحميلها خارجيًا. اختر `ADD_LINKS_TO_FONT_FILES` للإشارة إلى ملفات خطوط منفصلة، أو `EMBED` لتضمين بيانات الخط في SVG، أو `VECTORIZE` لتحويل النص الذي يستخدم خطوطًا خارجية إلى رسومات. تحقق من ترخيص الخط قبل تضمين الخطوط.

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

## **تقليل حجم الصور المدمجة**

استخدم [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) لتقليل دقة الصور المدمجة، و[SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) لحذف المناطق المقصوصة من المصدر، و[SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) للتحكم في جودة ترميز JPEG. تقلل هذه الإعدادات من حجم الملف على حساب دقة الصورة أو البيانات المحتفظ بها.

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

## **التحكم في دقة تحويل ملفات الميتا إلى نقطية**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) يحدد الحد الأدنى للدقة عند تحويل ملفات الميتا إلى نقطية أثناء تصدير SVG. استخدمه لموازنة التفاصيل وحجم الملف عندما يتم تحويل صورة EMF أو WMF إلى نقطية. لا يحدد DPI عالميًا للـ SVG ولا يجبر كل كائن على الشريحة ليصبح صورة نقطية.

قم بتنزيل [metafile-rasterization.pptx](metafile-rasterization.pptx)، الذي يحتوي على صورة EMF بخطوط قطرية متقاربة. المثال التالي يصدر الشريحة الأولى منه بثلاث دقات تحويل مختلفة عبر [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). تبقى جميع إعدادات التصدير الأخرى متماثلة حتى يمكن مقارنة النتائج.

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

في الناتج، تحولت صورة EMF إلى PNG مدمج واحد في كل SVG. القياسات التالية تخص العرض التقديمي المرفق؛ فهي ليست صيغة عامة لتحويل DPI إلى أبعاد بكسل.

| دقة تحويل الميتا إلى نقطية DPI | أبعاد PNG المدمج | حجم ملف SVG (بايت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

تظهر المقارنة أدناه نفس منطقة الصورة النقطية المدمجة بحجم عرض مكبر موحد. تُظهر الخطوط القطرية بكسلة مرئية عند 72 DPI وحوافًا أكثر سلاسة عند دقات أعلى، بينما ينمو حجم ملف SVG. زيادة القيمة لا تحسن بالضرورة كل التفاصيل أو تغير كل صورة مُصدَّرة.

![تفاصيل الخط القطري مكبرة عند 72 و150 و300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) يتحكم في تقليل دقة الصورة ويمكنه إخفاء تأثير تغيير دقة تحويل ملفات الميتا إلى نقطية. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) يتحكم في جودة ترميز JPEG، وليس في دقة تحويل ملفات الميتا إلى نقطية.

## **الأسئلة المتكررة**

**متى يجب عليّ استخدام [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) بدلاً من [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

استخدم [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) عندما يجب أن يكون كل النص مستقلاً عن الخطوط. استخدم [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) عندما ينبغي تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لتصغير حجم SVG؟**

ابدأ بضغط الصور المدمجة، حذف مناطق الصور المقصوصة، واختيار ملفات خطوط مرتبطة عندما يمكن للبيئة المستهدفة تقديمها. اختبر النتيجة لأن تقليل دقة الصورة، جودة JPEG المنخفضة، وتحويل النص إلى متجهات كل منها له مفاضلات مختلفة بين الجودة والحجم.