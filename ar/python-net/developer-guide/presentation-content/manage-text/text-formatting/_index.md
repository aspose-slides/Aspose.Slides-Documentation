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
- جدولة النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تنسيق وتطبيق أنماط على النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. خصّص الخطوط، الألوان، المحاذاة، وغيرها."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. تغطي ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، مواضع التاب، وإعدادات اللغة.

في الأمثلة أدناه، سنستخدم ملفًا اسمه "sample.pptx"، يحتوي على صندوق نص واحد في الشريحة الأولى بالنص التالي:

![نص العينة](sample_text.png)

للعثور على النص الحرفي أو تطابقات التعبير النمطي وتحديده، راجع[Search and Replace Text](/slides/ar/python-net/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/default_portion_format/) لتعيين لون التمييز الافتراضي لفقرة، أو استخدم [PortionFormat.highlight_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/highlight_color/) لأجزاء النص الفردية.

الكود التالي يوضح كيفية تعيين لون الخلفية لل**الفقرة بالكامل**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تعيين لون التمييز للفقرة بأكملها.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

الكود أدناه يوضح كيفية تعيين لون الخلفية لـ**أجزاء النص ذات الخط الغامق**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # تعيين لون التمييز لجزء النص.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![أجزاء النص الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [ParagraphFormat.alignment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/alignment/) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيم متمركزة، محاذية إلى اليسار، محاذية إلى اليمين، مبررة، وما إلى ذلك.

الكود التالي يوضح كيفية محاذاة الفقرة إلى **الوسط**:

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

تتحكم شفافية النص من خلال المكوّن ألفا للون المعيّن إلى [PortionFormat.fill_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/fill_format/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا بنظام ARGB على مقياس 0-255، وليس نسبة شفافية.

الكود التالي يوضح كيفية تطبيق الشفافية على **الفقرة بالكامل**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تعيين لون تعبئة النص إلى لون شفاف.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

الكود التالي يوضح كيفية تطبيق الشفافية على **أجزاء النص ذات الخط الغامق**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # تعيين شفافية جزء النص.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![أجزاء النص الشفافة](transparent_text_portions.png)

## **تعيين تباعد الأحرف للنص**

استخدم [BasePortionFormat.spacing](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/spacing/) لتوسيع أو تضييق التباعد بين الأحرف في صندوق النص.

الكود التالي يوضح كيفية توسيع تباعد الأحرف في **الفقرة بالكامل**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ملاحظة: استخدم قيمًا سلبية لضغط تباعد الأحرف.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

الكود أدناه يوضح كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط الغامق**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # ملاحظة: استخدم قيمًا سلبية لضغط تباعد الأحرف.
            portion.portion_format.spacing = 3  # توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **تعطيل Kerning للخطوط المحددة**

في بعض الحالات، قد يبدو النص المصدّر بواسطة Aspose.Slides أدق قليلاً من النص نفسه المعروض في PowerPoint. يحدث هذا لأن PowerPoint قد يتجاهل بيانات kerning لبعض الخطوط، حتى عندما يحتوي الخط على معلومات kerning صالحة وتكون kerning مفعلة في إعدادات PowerPoint.

لجعل المخرجات المصدّرة أقرب إلى مظهر PowerPoint في هذه الحالات، يمكنك تعطيل kerning لأجزاء النص التي تستخدم الخط المتأثر. قم بتعيين [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) إلى قيمة أكبر بكثير من حجم الخط الفعلي:

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

هذه الإعدادات تمنع تطبيق kerning على أجزاء النص المطابقة ويمكن أن تساعد في مواءمة عرض Aspose.Slides مع مظهر PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بالـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة من خلال [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/default_portion_format/) أو على أجزاء فردية عبر [PortionFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/).

الكود التالي يعيّن الخط ونمط النص للفقرة بالكامل: يطبق حجم الخط، الغامق، المائل، خط سفلي منقط، وخط Times New Roman على جميع الأجزاء في الفقرة.

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

الكود أدناه يطبق خصائص مشابهة على **أجزاء النص ذات الخط الغامق**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # تعيين خصائص الخط لجزء النص.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![خصائص الخط لأجزاء النص](font_properties_for_text_portions.png)

## **تعيين دوران النص**

استخدم [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/text_vertical_type/) لتعيين اتجاه نص مسبق داخل الشكل.

الكود التالي يعيّن اتجاه النص في الشكل إلى `VERTICAL270`، مما يدور النص **90 درجة عكس اتجاه عقارب الساعة**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![دوران النص](text_rotation.png)

## **تعيين دوران مخصّص لإطارات النص**

استخدم [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/rotation_angle/) لتعيين زاوية دوران مخصّصة لـ [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).

الكود أدناه يدور إطار النص بمقدار 3 درجات باتجاه عقارب الساعة داخل الشكل:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الدوران المخصّص للنص](custom_text_rotation.png)

## **تعيين تباعد الأسطر للفقرات**

توفر Aspose.Slides الخصائص [ParagraphFormat.space_after](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/space_after/)، [ParagraphFormat.space_before](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/space_before/)، و[ParagraphFormat.space_within](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/space_within/) للتحكم في تباعد الفقرات. تُستخدم هذه الخصائص كما يلي:

* استخدم قيمة إيجابية لتحديد تباعد الأسطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سلبية لتحديد تباعد الأسطر بالنقاط.

الكود التالي يوضح كيفية تحديد تباعد الأسطر داخل الفقرة:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تباعد الأسطر داخل الفقرة](line_spacing.png)

## **تحديد نوع الملاءمة التلقائية لإطارات النص**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/autofit_type/) يحدّد كيف يتعامل النص عندما يتجاوز حدود الحاوية. استخدمه للتحكم فيما إذا كان النص سيصغّر، سيتجاوز، أو سيعيد تحجيم الشكل تلقائيًا.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **تحديد موضع تثبيت إطارات النص**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/anchoring_type/) يعرّف كيفية تموضع النص عموديًا داخل الشكل، مثلاً في الأعلى، الوسط، أو الأسفل.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين جدولة التاب للنص**

استخدم [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/default_tab_size/) و[ParagraphFormat.tabs](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/tabs/) لتكوين مواضع التاب في الفقرة.

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

توفر Aspose.Slides الخاصية [PortionFormat.language_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/language_id/)، والتي تسمح لك بتعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة لتصحيح الإملاء والنحو في PowerPoint.

الكود التالي يوضح كيفية تعيين لغة التدقيق لجزء نص:

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

استخدم [LoadOptions.default_text_language](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/default_text_language/) لتحديد اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # إضافة شكل مستطيل جديد مع نص.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # تحقق من لغة الجزء الأول.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **تعيين النمط النصي الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض، استخدم [Presentation.default_text_style](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/default_text_style/).

الكود التالي يوضح كيفية تعيين خط غامق افتراضي بحجم 14 نقطة لجميع النصوص عبر الشرائح في عرض تقديمي جديد.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # الحصول على تنسيق الفقرة في المستوى الأعلى.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج النص مع تأثير الأحرف الكبيرة بالكامل**

في PowerPoint، يجعل تطبيق تأثير **All Caps** الخط يظهر النص بأحرف كبيرة على الشريحة حتى وإن تم كتابته أصلاً بأحرف صغيرة. عندما تسترجع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما أدخل بالضبط. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textcaptype/) وحوّل السلسلة المرجعة إلى أحرف كبيرة عندما تكون القيمة `ALL`.

لنفترض أن لدينا صندوق النص التالي في الشريحة الأولى من ملف sample2.pptx.

![تأثير الأحرف الكبيرة بالكامل](all_caps_effect.png)

الكود التالي يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:

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

الناتج:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة الشائعة**

**كيف يمكن تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [Table](https://reference.aspose.com/slides/ar/python-net/aspose.slides/table/). استعرض الخلايا وحدث كل خلية عبر [Cell.text_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/cell/text_frame/) وتنسيق الفقرة عبر [Paragraph.paragraph_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/paragraph_format/).

**كيف يتم تطبيق لون متدرج للنص في شريحة PowerPoint؟**

لتطبيق لون متدرج للنص، استخدم [PortionFormat.fill_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/fill_format/). عيّن [FillFormat.fill_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fillformat/fill_type/) إلى [FillType.GRADIENT](https://reference.aspose.com/slides/ar/python-net/aspose.slides/filltype/) وكمّن نقاط التدرج، الاتجاه، والشفافية.