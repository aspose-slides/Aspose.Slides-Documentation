---
title: تنسيق نص العرض التقديمي في بايثون
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/python-net/text-formatting/
keywords:
- محاذاة الفقرة
- نمط النص
- خلفية النص
- شفافية النص
- تباعد الأحرف
- خصائص الخط
- عائلة الخط
- دوران النص
- زاوية الدوران
- إطار النص
- تباعد الأسطر
- خاصية الملاءمة التلقائية
- تثبيت إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. تخصيص الخطوط، الألوان، المحاذاة، وأكثر."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر .NET. تغطي الألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، التدوير، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، نقاط التبويب، وإعدادات اللغة.

ما لم يُذكر خلاف ذلك، تستخدم الأمثلة ملف [sample.pptx](sample.pptx). الشكل الأول في الشريحة الأولى هو صندوق نص، وتحتوي الفقرة الأولى على النص الموضح أدناه. كل من مؤشرات الشرائح والأشكال تبدأ من الصفر. تستخدم الأمثلة التي تحدد أجزاءً بخط عريض تنسيقًا فعالًا، بما في ذلك تنسيق العريض الموروث:

![Sample text](sample_text.png)

للعثور على نص حرفي أو تطابقات تعبير منتظم وتظليلها، راجع [بحث واستبدال النص](/slides/ar/python-net/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/default_portion_format/) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/highlight_color/) لتحديد ألوان التظليل لأجزاء النص الفردية.

المثال التالي يحدد تظليلًا رماديًا فاتحًا كافتراضي للفقرة الأولى. تُعطي ألوان التظليل الصريحة للأجزاء الفردية أولوية أعلى من هذا الافتراضي:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تعيين لون التظليل للفقرة بأكملها.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The gray paragraph](gray_paragraph.png)

يظهر المثال البرمجي أدناه كيفية تعيين لون الخلفية **لأجزاء النص ذات الخط العريض**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # تعيين لون التظليل لجزء النص.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The gray text portions](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [ParagraphFormat.alignment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/alignment/) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزية أو محاذاة إلى اليسار أو اليمين أو مبررة، وما إلى ذلك.

المثال البرمجي التالي يوضح كيفية محاذاة الفقرة إلى **الوسط**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تعيين محاذاة الفقرة إلى الوسط.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The aligned paragraph](aligned_paragraph.png)

## **تعيين الشفافية للنص**

تتحكم الشفافية في النص عبر مكوّن ألفا للون المعيّن إلى [BasePortionFormat.fill_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/fill_format/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا ARGB على مقياس 0–255، وليس نسبة شفافية.

المثال البرمجي أدناه يوضح كيفية تطبيق الشفافية على **الفقرة بأكملها**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تعيين تعبئة سوداء شبه شفافة للنص.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The transparent paragraph](transparent_paragraph.png)

المثال البرمجي التالي يوضح كيفية تطبيق الشفافية على **أجزاء النص ذات الخط العريض**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # تعيين شفافية جزء النص.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The transparent text portions](transparent_text_portions.png)

## **تعيين تباعد الأحرف للنص**

استخدم [BasePortionFormat.spacing](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/spacing/) لتوسيع أو تقليل التباعد بين الأحرف في صندوق النص. تضيف الأمثلة 3 نقاط تباعد؛ القيم السالبة تقلل النص.

الشفرة البرمجية التالية توضح كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ملاحظة: استخدم قيم سالبة لضغط تباعد الأحرف.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

المثال البرمجي أدناه يوضح كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط العريض**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # ملاحظة: استخدم قيم سالبة لضغط تباعد الأحرف.
            portion.portion_format.spacing = 3  # توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **تعطيل التقريب (Kerning) للخطوط المحددة**

في بعض الحالات، قد يبدو النص المكوّن بواسطة Aspose.Slides أكثر تضييقًا قليلاً من النص المعروض في PowerPoint. يمكن أن يحدث هذا لأن PowerPoint قد يتجاهل بيانات التقريب لبعض الخطوط، حتى عندما يحتوي الخط على معلومات تقريب صالحة ويكون التقريب مفعّلاً في إعدادات PowerPoint.

لجعل النتيجة المكوّنة أقرب إلى ما في PowerPoint في مثل هذه الحالات، يمكنك تعطيل التقريب لأجزاء النص التي تستخدم الخط المتأثر. عيّن [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) إلى قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال ملف "presentation.pptx" يحتوي على صندوق نص كشكل أول في الشريحة الأولى. يتحقق من أسماء الخطوط الفعالة، بما في ذلك الخطوط الموروثة، ويعيّن عتبة 100 نقطة للأجزاء التي تستخدم Roboto. هذا يعطل التقريب للأجزاء التي يكون حجم خطها أقل من 100 نقطة:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

بالنسبة للنص المتطابق تحت العتبة، يمنع هذا الإعداد التقريب ويمكن أن يساعد في تقريب عرض Aspose.Slides للـ PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/default_portion_format/) أو على الأجزاء الفردية عبر [PortionFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/).

المثال التالي يعيّن الخط الافتراضي للفقرة الأولى إلى Times New Roman بحجم 12 نقطة مع تنسيق عريض، مائل، وتسطير منقط. يَسود التنسيق الصريح للأجزاء الفردية هذه الإعدادات الافتراضية.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ضبط خصائص الخط للفقرة.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The font properties for the paragraph](font_properties_for_paragraph.png)

المثال التالي يطبّق Times New Roman بحجم 13 نقطة، تنسيق مائل، وتسطير منقط على الأجزاء التي يكون تنسيقها الفعّال عريضًا:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # ضبط خصائص الخط لجزء النص.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The font properties for text portions](font_properties_for_text_portions.png)

## **تعيين دوران النص**

استخدم [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/text_vertical_type/) لتعيين اتجاه نص مسبق التعريف داخل شكل.

المثال البرمجي التالي يعيّن اتجاه النص في الشكل إلى [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textverticaltype/)، ما يدور النص **90 درجة عكس اتجاه عقارب الساعة**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The text rotation](text_rotation.png)

## **تعيين دوران مخصص لإطارات النص**

استخدم [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/rotation_angle/) لتعيين زاوية دوران مخصصة لإطار نص [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).

المثال البرمجي أدناه يدور إطار النص بمقدار 3 درجات مع اتجاه عقارب الساعة داخل الشكل:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The custom text rotation](custom_text_rotation.png)

## **تعيين تباعد الأسطر للفقرات**

توفر Aspose.Slides الخصائص [ParagraphFormat.space_after](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/space_after/)، [ParagraphFormat.space_before](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/space_before/)، و[ParagraphFormat.space_within](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/space_within/) للتحكم في تباعد الفقرات. تُستَخدم هذه الخصائص كالتالي:

* استخدم قيمة إيجابية لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سلبية لتحديد تباعد السطر بالنقاط.

المثال التالي يعيّن التباعد داخل الفقرة الأولى إلى 200% من ارتفاع السطر (تباعد مزدوج):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The line spacing within the paragraph](line_spacing.png)

## **التحكم في كسر السطر**

قواعد كسر سطر الفقرة مفيدة في كتل نصية ضيقة وعروض تقديمية تجمع بين النص اللاتيني والنص الآسيوي الشرقي. تنتمي الخصائص التالية إلى [ParagraphFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/)، لذا فهي تُطبق على الفقرة بأكملها:

- [latin_line_break](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/latin_line_break/) يتحكم في قواعد كسر سطر اللاتيني. في النص المختلط، قد يغيّر ذلك أيضًا موضع كسر النص الآسيوي الشرقي وعلامات الترقيم المجاورة.
- [east_asian_line_break](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/east_asian_line_break/) يتحكم في قواعد كسر سطر الآسيوي الشرقي، بما في ذلك القيود على الأحرف في بداية أو نهاية السطر.

هذه القواعد لا تحل محل [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/wrap_text/)، الذي يفعّل الالتفاف التلقائي داخل إطار النص. هي تؤثر على التخطيط عندما يحدث الالتفاف؛ لا تُدرج أحرف كسر سطر. يُجبر كسر السطر الصريح على سطر جديد داخل الفقرة بغض النظر عن العرض المتاح.

المثال المستقل التالي ينشئ كتلة نصية ضيقة تحتوي على نص صيني ولاتيني. يعيّن كلا خصائص كسر السطر صراحةً ويحفظ الملف "line_breaking.pptx". لتجربة أي قاعدة، غيّر قيمة تلك الخاصية مع إبقاء الأخرى ثابتة. يستخدم المثال خط Arial بحجم 24 نقطة وSimSun مع عرض إطار 160 نقطة وهوامش أفقية صفرية. يُعيّن [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/autofit_type/) إلى [TextAutofitType.NONE](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textautofittype/) بحيث يبقى حجم النص وأبعاد الإطار ثابتين.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **التحكم في علامات الترقيم المتدلية**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/hanging_punctuation/) يسمح للعلامات الترقيمية المؤهلة بالتمدد خارج الحد الأيمن لسطر النص بدلاً من احتلال السطر التالي. ينطبق على الفقرة بأكملها وهو مختلف عن المسافة المتدلية.

المثال المستقل التالي يفعّل الترميز المتدلي للعلامات في إطار نص عرضه 100 نقطة ويحفظ الملف "hanging_punctuation.pptx". باستخدام Arial بحجم 24 نقطة وهوامش أفقية صفرية، يبقى النقطة النهائية بعد كلمة "sentence" وتمتد خارج حد النص الأيمن. اضبط الخاصية إلى [NullableBool.FALSE](https://reference.aspose.com/slides/ar/python-net/aspose.slides/nullablebool/) للمقارنة: في هذه الإعدادات، تشغل النقطة سطرًا منفصلًا. يتم تفعيل الالتفاف وتعطيل الملاءمة التلقائية للحفاظ على العرض المتاح ثابتًا.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

ليس كل علامة ترقيم يمكن أن تتدلى. النتيجة الظاهرة تعتمد على الخط وظروف التخطيط: تغيير الخط أو العرض المتاح أو الهوامش أو إعدادات الملاءمة التلقائية قد يزيل الاختلاف الظاهر.

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/autofit_type/) يحدّد كيف يتصرف النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص سينكمش، يفيض، أو يعيد تحجيم الشكل تلقائيًا. المثال التالي يُعدّل الشكل ليُعيد تحجيمه ليتناسب مع النص ويُحفظ النتيجة في "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

لحساب عدد الأسطر بعد الالتفاف التلقائي ورؤية كيف يغيّر عرض النص أو الشكل النتيجة، راجع [Count Rendered Lines](/slides/ar/python-net/manage-paragraph/). عدد الأسطر وحده لا يُظهر ما إذا كان النص يفيض عن حاويته.

## **تعيين تثبيت إطارات النص**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/anchoring_type/) يحدد كيف يُوضع النص عموديًا داخل الشكل، مثلًا في الأعلى أو الوسط أو الأسفل. المثال التالي يُثبت النص في أسفل الشكل الأول ويُحفظ النتيجة في "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تبويب النص**

استخدم [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/default_tab_size/) و[ParagraphFormat.tabs](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/tabs/) لتكوين علامات التبويب في الفقرة. يحدد المثال التالي مقدار الفاصل الافتراضي للتاب إلى 100 نقطة ويضيف علامة تبويب محاذاة إلى اليسار عند 30 نقطة. تؤثر هذه الإعدادات على النص الذي يحتوي على أحرف تبويب.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The paragraph tabs](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides الخاصية [BasePortionFormat.language_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/language_id/)، التي تسمح لك بتعيين لغة التدقيق لجزء من النص. تحدد لغة التدقيق اللغة المستخدمة لتصحيح الإملاء والقواعد في PowerPoint.

المثال التالي يتطلب ملف "presentation.pptx" يحتوي على صندوق نص كشكل أول في الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتوى الفقرة الأولى بـ "1。" ويعيّن SimSun كخط لها، ويعيّن لغة التدقيق الصينية المبسطة (`zh-CN`). يحفظ النتيجة في "proofing_language.pptx":

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # تعيين لغة التدقيق إلى الصينية المبسطة.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions.default_text_language](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/default_text_language/) لتحديد اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي. المثال التالي يُنشئ عرضًا تقديميًا باللغة الإنجليزية الأمريكية كلغة نص افتراضية، يضيف صندوق نص، ويطبع `en-US` لأول جزء نص في الصندوق.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # إضافة شكل مستطيل جديد مع نص.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # فحص لغة الجزء الأول.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **تعيين النمط النصي الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [Presentation.default_text_style](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/default_text_style/).

المثال التالي يعيّن خطًا عريضًا بحجم 14 نقطة كافتراضي للفقرات العليا في عرض تقديمي جديد ويحفظه في "default_text_style.pptx". يمكن للنص أن يرث هذه الإعدادات ما لم يتجاوزها تنسيق أكثر تحديدًا.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # الحصول على تنسيق الفقرة المستوى الأعلى.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج النص مع تأثير الأحرف الكبيرة (All-Caps)**

في PowerPoint، يؤدي تطبيق تأثير الخط **All Caps** إلى ظهور النص بأحرف كبيرة على الشريحة حتى لو كُتب أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما كُتب بالضبط. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textcaptype/) وحوّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `ALL`.

يتطلب هذا المثال ملف "sample2.pptx" يحتوي على صندوق نص كشكل أول في الشريحة الأولى. يحتوي الجزء الأول من الفقرة الأولى على "Hello, Aspose!" مع تطبيق تأثير All Caps، كما يظهر أدناه.

![The All Caps effect](all_caps_effect.png)

المثال البرمجي أدناه يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

المخرجات:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة المتكررة**

**كيف يمكنني تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [Table](https://reference.aspose.com/slides/ar/python-net/aspose.slides/table/). رّق عبر الخلايا وحدث كل خلية من خلال [Cell.text_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/cell/text_frame/) وتنسيق الفقرة عبر [Paragraph.paragraph_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/paragraph_format/).

**كيف يمكنني تطبيق لون تدرّج على النص في شريحة PowerPoint؟**

لتطبيق لون تدرّج على النص، استخدم [BasePortionFormat.fill_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/fill_format/). عيّن [FillFormat.fill_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fillformat/fill_type/) إلى [FillType.GRADIENT](https://reference.aspose.com/slides/ar/python-net/aspose.slides/filltype/) و configure الوقفات، الاتجاه، والشفافية.