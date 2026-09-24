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
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET. تخصيص الخطوط والألوان والمحاذاة وأكثر."
---
## **نظرة عامة**

هذا المقال يوضح كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Python عبر .NET. يغطي ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، مسافات التبويب، وإعدادات اللغة.

في الأمثلة أدناه، سنستخدم ملفًا اسمه "sample.pptx"، يحتوي على صندوق نص واحد في الشريحة الأولى بالنص التالي:

![نص العينة](sample_text.png)

للعثور على نص حرفي أو مطابقة تعبيرات منتظمة وتحديدها، راجع [البحث واستبدال النص](/slides/ar/python-net/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/default_portion_format/) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [PortionFormat.highlight_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/highlight_color/) لأجزاء النص الفردية.

مثال الشيفرة التالي يوضح كيفية تعيين لون الخلفية لل**فقرة بأكملها**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تعيين لون التظليل للفقرة بأكملها.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

مثال الشيفرة أدناه يوضح كيفية تعيين لون الخلفية لل**أقسام النص بخط عريض**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # تعيين لون التظليل للجزء النصي.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الأقسام النصية الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [ParagraphFormat.alignment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/alignment/) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزة، محاذاة إلى اليسار، إلى اليمين، مبررة، وما إلى ذلك.

مثال الشيفرة التالي يوضح كيفية محاذاة الفقرة إلى **الوسط**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تعيين محاذاة الفقرة إلى الوسط.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الفقرة المحاذاة](aligned_paragraph.png)

## **تعيين الشفافية للنص**

تتحكم شفافية النص عبر مكوّن ألفا للون المعين إلى [PortionFormat.fill_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/fill_format/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا بنظام ARGB على نطاق 0-255، وليس نسبة شفافية.

مثال الشيفرة أدناه يوضح كيفية تطبيق الشفافية على **الفقرة بأكملها**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تعيين لون ملء النص إلى لون شفاف.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

مثال الشيفرة التالي يوضح كيفية تطبيق الشفافية على **الأقسام النصية بخط عريض**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # تعيين شفافية الجزء النصي.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الأقسام النصية الشفافة](transparent_text_portions.png)

## **تعيين تباعد الأحرف للنص**

استخدم [BasePortionFormat.spacing](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/spacing/) لتوسيع أو تضييق التباعد بين الأحرف داخل صندوق النص.

مثال الشيفرة التالي يوضح كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ملاحظة: استخدم القيم السالبة لضغط تباعد الأحرف.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

مثال الشيفرة أدناه يوضح كيفية توسيع تباعد الأحرف في **الأقسام النصية بخط عريض**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # ملاحظة: استخدم القيم السالبة لضغط تباعد الأحرف.
            portion.portion_format.spacing = 3  # توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تباعد الأحرف في الأقسام النصية](character_spacing_in_text_portions.png)

### **تعطيل تدرج الحروف للخطوط المحددة**

في بعض الحالات، قد يظهر النص المكوَّن بواسطة Aspose.Slides أقرب قليلاً من النص نفسه في PowerPoint. يحدث ذلك لأن PowerPoint قد يتجاهل بيانات تدرج الحروف لبعض الخطوط، حتى عندما يحتوي الخط على معلومات تدرج صالحة وتم تفعيل التدرج في إعدادات PowerPoint.

لجعل الناتج المكوَّن أقرب إلى PowerPoint في مثل هذه الحالات، يمكنك تعطيل تدرج الحروف للأقسام النصية التي تستخدم الخط المتأثر. عيّن [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) إلى قيمة أكبر بكثير من حجم الخط الفعلي:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

هذا الإعداد يمنع تطبيق تدرج الحروف على الأقسام النصية المتطابقة ويمكن أن يساعد في مواءمة عرض Aspose.Slides مع مظهر PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/default_portion_format/) أو على أقسام فردية عبر [PortionFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/).

مثال الشيفرة التالي يحدد الخط ونمط النص للفقرة بأكملها: يطبق حجم الخط، العريض، المائل، تسطير منقط، وخط Times New Roman على جميع الأقسام في الفقرة.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تعيين خصائص الخط للفقرة.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![خصائص الخط للفقرة](font_properties_for_paragraph.png)

مثال الشيفرة أدناه يطبق خصائص مماثلة على **الأقسام النصية بخط عريض**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # تعيين خصائص الخط للجزء النصي.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![خصائص الخط للأقسام النصية](font_properties_for_text_portions.png)

## **تعيين دوران النص**

استخدم [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/text_vertical_type/) لتعيين اتجاه نص مسبق داخل الشكل.

مثال الشيفرة التالي يعيّن اتجاه النص في الشكل إلى `VERTICAL270`، وهو ما يدور النص **90 درجة عكس اتجاه عقرب الساعة**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![دوران النص](text_rotation.png)

## **تعيين دوران مخصص لإطارات النص**

استخدم [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/rotation_angle/) لتعيين زاوية دوران مخصصة لـ [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).

مثال الشيفرة أدناه يدور إطار النص بمقدار 3 درجات باتجاه عقرب الساعة داخل الشكل:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الدوران المخصص للنص](custom_text_rotation.png)

## **تعيين تباعد الأسطر للفقرات**

توفر Aspose.Slides الخصائص [ParagraphFormat.space_after](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/space_after/)، [ParagraphFormat.space_before](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/space_before/)، و[ParagraphFormat.space_within](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/space_within/) للتحكم في تباعد الفقرة. تُستخدم هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

مثال الشيفرة التالي يوضح كيفية تحديد تباعد السطر داخل الفقرة:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تباعد السطر داخل الفقرة](line_spacing.png)

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/autofit_type/) يحدد كيفية تصرف النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص يتقلص، يفيض، أو يغير حجم الشكل تلقائيًا.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

لحساب عدد الأسطر بعد الالتفاف التلقائي ورؤية كيف يتغير عرض النص أو الشكل، راجع [Count Rendered Lines](/slides/ar/python-net/manage-paragraph/). عدد الأسطر وحده لا يشير إلى ما إذا كان النص يفيض عن حاويته.

## **تعيين تثبيت إطارات النص**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/anchoring_type/) يحدد كيفية وضع النص عموديًا داخل الشكل، مثلًا في الأعلى أو الوسط أو الأسفل.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تبويبة النص**

استخدم [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/default_tab_size/) و[ParagraphFormat.tabs](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/tabs/) لتكوين مسافات التبويب في الفقرة.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تبويبات الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides الخاصية [PortionFormat.language_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/language_id/)، والتي تسمح لك بتحديد لغة التدقيق لجزء نصي. تحدد لغة التدقيق اللغة المستخدمة للتهجئة والقواعد النحوية في PowerPoint.

مثال الشيفرة التالي يوضح كيفية تعيين لغة التدقيق لجزء نصي:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # تعيين معرف لغة التدقيق.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions.default_text_language](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/default_text_language/) لتحديد اللغة الافتراضية للنص الذي يتم إنشاؤه أثناء تحميل أو إنشاء عرض تقديمي.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # إضافة شكل مستطيل جديد مع نص.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # التحقق من لغة الجزء الأول.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [Presentation.default_text_style](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/default_text_style/).

مثال الشيفرة التالي يوضح كيفية تعيين خط عريض افتراضي بحجم 14 نقطة لجميع النصوص عبر الشرائح في عرض تقديمي جديد.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # احصل على تنسيق الفقرة من المستوى الأعلى.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج النص مع تأثير الحروف الكبيرة بالكامل**

في PowerPoint، تطبيق تأثير **All Caps** يجعل النص يظهر بأحرف كبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textcaptype/) وحوِّل السلسلة المعادة إلى أحرف كبيرة عندما تكون القيمة `ALL`.

لنفترض أن لدينا صندوق نص التالي على الشريحة الأولى من ملف sample2.pptx.

![تأثير الحروف الكبيرة بالكامل](all_caps_effect.png)

مثال الشيفرة أدناه يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

الإخراج:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة المتكررة**

**كيف يمكن تعديل النص في جدول داخل شريحة؟**

لتعديل النص في جدول داخل شريحة، استخدم [Table](https://reference.aspose.com/slides/ar/python-net/aspose.slides/table/). قم بالتكرار عبر الخلايا وحدث كل خلية عبر [Cell.text_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/cell/text_frame/) وتنسيق الفقرة عبر [Paragraph.paragraph_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/paragraph_format/).

**كيف يمكن تطبيق لون متدرج على النص في شريحة PowerPoint؟**

لتطبيق لون متدرج على النص، استخدم [PortionFormat.fill_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/fill_format/). عيّن [FillFormat.fill_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fillformat/fill_type/) إلى [FillType.GRADIENT](https://reference.aspose.com/slides/ar/python-net/aspose.slides/filltype/) وقم بتكوين نقاط التدرج، الاتجاه، والشفافية.