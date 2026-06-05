---
title: تنسيق نص العرض التقديمي في بايثون
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/python-net/text-formatting/
keywords:
- تمييز النص
- تعبير نمطي
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
- خاصية الملائمة التلقائية
- تثبيت إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. قم بتخصيص الخطوط، الألوان، المحاذاة، والمزيد."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ Python عبر .NET. تشمل الموضوعات التمييز، ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملائمة التلقائية، تثبيت النص، علامات التبويب، وإعدادات اللغة.

في الأمثلة أدناه، سنستخدم ملفًا باسم "sample.pptx" يحتوي على صندوق نص واحد في الشريحة الأولى بالنص التالي:

![نص عينة](sample_text.png)

## **تمييز النص**

استخدم طريقة [TextFrame.highlight_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/highlight_text/) عندما تحتاج إلى تمييز النص الذي يطابق عيّنة معينة داخل إطار نص. تطبق الطريقة لون تمييز على أجزاء النص المتطابقة ويمكن استخدامها مع [TextSearchOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/) للتحكم في طريقة البحث، على سبيل المثال لتطابق الكلمات بالكامل فقط.

يُظهر مثال الشيفرة أدناه كل تكرارات الأحرف **"try"** ثم يميز الكلمة الكاملة **"to"** فقط.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # الحصول على الشكل الأول من الشريحة الأولى.
    shape = presentation.slides[0].shapes[0]

    # تمييز الكلمة "try" في الشكل.
    shape.text_frame.highlight_text("try", draw.Color.light_blue)

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True

    # تمييز الكلمة "to" في الشكل.
    shape.text_frame.highlight_text("to", draw.Color.violet, search_options, None)

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![النص المميز](highlighted_text.png)

## **تمييز النص باستخدام التعابير النمطية**

طريقة [TextFrame.highlight_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/highlight_regex/) تميز النصوص التي يطابقها تعبير نمطي. في Python، يُعرَض هذا API على [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).

مثال الشيفرة أدناه يميز جميع الكلمات التي تحتوي على **سبعة أحرف أو أكثر**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    regex = r"\b[^\s]{7,}\b"

    # تمييز جميع الكلمات التي تتألف من سبعة أحرف أو أكثر.
    shape.text_frame.highlight_regex(regex, draw.Color.yellow, None)

    presentation.save("highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![النص المميز باستخدام التعابير النمطية](highlighted_text_using_regex.png)

## **تعيين لون خلفية النص**

استخدم [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/default_portion_format/) لتعيين لون تمييز افتراضي لفقرة، أو استخدم [PortionFormat.highlight_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/highlight_color/) لأجزاء نص فردية.

مثال الشيفرة التالي يوضح كيفية تعيين لون الخلفية لل**فقرة كاملة**:

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

مثال الشيفرة أدناه يوضح كيفية تعيين لون الخلفية لأجزاء النص ذات الخط **عريض**:

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

![الأجزاء النصية الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [ParagraphFormat.alignment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/alignment/) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة متمركزة، محاذاة إلى اليسار، إلى اليمين، مبررة، وغيرها.

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

![الفقرة المحاذاة للوسط](aligned_paragraph.png)

## **تعيين الشفافية للنص**

تُتحكم شفافية النص من خلال مكوّن ألفا للون المعيّن إلى [PortionFormat.fill_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/fill_format/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا ARGB على مقياس 0‑255، وليس نسبة الشفافية.

مثال الشيفرة التالي يوضح كيفية تطبيق الشفافية على **الفقرة كاملة**:

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

مثال الشيفرة التالي يوضح كيفية تطبيق الشفافية على **أجزاء النص ذات الخط العريض**:

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

![الأجزاء النصية الشفافة](transparent_text_portions.png)

## **تعيين تباعد الأحرف للنص**

استخدم [BasePortionFormat.spacing](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/spacing/) لتوسيع أو تقليص التباعد بين الأحرف في صندوق النص.

مثال الشيفرة التالي يوضح توسيع تباعد الأحرف في **الفقرة كاملة**:

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

مثال الشيفرة أدناه يوضح توسيع تباعد الأحرف في **أجزاء النص ذات الخط العريض**:

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

![تباعد الأحرف في الأجزاء النصية](character_spacing_in_text_portions.png)

### **تعطيل التباعد الحرفي للخطوط المحددة**

في بعض الحالات، قد يبدو النص المرسوم بواسطة Aspose.Slides ضيقًا قليلاً مقارنةً بالنص نفسه المعروض في PowerPoint. يمكن أن يحدث هذا لأن PowerPoint قد يتجاهل بيانات التباعد الحرفي لبعض الخطوط، حتى عندما يحتوي الخط على معلومات تباعد صحيحة وتكون التباعد مفعَّلة في إعدادات PowerPoint.

لجعل الإخراج المرسوم أقرب إلى ما يقدّمه PowerPoint في مثل هذه الحالات، يمكنك تعطيل التباعد الحرفي لأجزاء النص التي تستخدم الخط المتأثر. عيّن [PortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) إلى قيمة أكبر بكثير من حجم الخط الفعلي:

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

هذا الإعداد يمنع تطبيق التباعد الحرفي على أجزاء النص المتطابقة ويمكن أن يساعد في مواءمة عرض Aspose.Slides مع المخرجات البصرية لـ PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/default_portion_format/) أو على أجزاء فردية عبر [PortionFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/).

مثال الشيفرة التالي يضبط الخط ونمط النص للفقرة كاملة: يطبق حجم الخط، العريض، المائل، خط سفلي منقط، وخط Times New Roman على جميع الأجزاء في الفقرة.

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

مثال الشيفرة أدناه يطبق خصائص مماثلة على **أجزاء النص ذات الخط العريض**:

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

![خصائص الخط للأجزاء النصية](font_properties_for_text_portions.png)

## **تعيين دوران النص**

استخدم [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/text_vertical_type/) لتعيين اتجاه نص محدد مسبقًا داخل الشكل.

مثال الشيفرة التالي يعيّن اتجاه النص داخل الشكل إلى `VERTICAL270`، مما يدير النص **90 درجة عكس عقارب الساعة**:

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

مثال الشيفرة أدناه يدور إطار النص بمقدار 3 درجات باتجاه عقارب الساعة داخل الشكل:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![دوران النص المخصص](custom_text_rotation.png)

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

## **تعيين نوع الملائمة التلقائية لإطارات النص**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/autofit_type/) يحدّد كيفية تصرف النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص يُصغّر، يفيض، أو يُعيد تحجيم الشكل تلقائيًا.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تثبيت إطارات النص**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/anchoring_type/) يُعرّف كيفية تموضع النص عموديًا داخل الشكل، مثلًا في الأعلى أو الوسط أو الأسفل.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين علامات الجدولة للنص**

استخدم [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/default_tab_size/) و[ParagraphFormat.tabs](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/tabs/) لضبط علامات التبويب في الفقرة.

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

![علامات التبويب في الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides الخاصية [PortionFormat.language_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/language_id/) التي تسمح لك بتعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة لتدقيق الإملاء والقواعد في PowerPoint.

مثال الشيفرة التالي يوضح كيفية تعيين لغة التدقيق لجزء نص:

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

    text_portion.text = "1."
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions.default_text_language](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/default_text_language/) لتحديد اللغة الافتراضية للنص المُنشئ أثناء تحميل أو إنشاء عرض تقديمي.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # إضافة شكل مستطيل جديد مع النص.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # التحقق من لغة الجزء الأول.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [Presentation.default_text_style](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/default_text_style/).

مثال الشيفرة التالي يوضح كيفية تعيين خط عريض بحجم 14 نقطة كخط افتراضي لجميع النصوص عبر الشرائح في عرض تقديمي جديد.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # الحصول على تنسيق الفقرة من المستوى الأعلى.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج النص مع تأثير الأحرف الكبيرة**

في PowerPoint، يجعل تطبيق تأثير **All Caps** (الأحرف الكبيرة) النص يظهر بأحرف كبيرة على الشريحة حتى وإن كُتب أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي بـ Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textcaptype/) وحوّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `ALL`.

لنفترض أن لدينا صندوق النص التالي في الشريحة الأولى من ملف sample2.pptx.

![تأثير الأحرف الكبيرة](all_caps_effect.png)

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

## **الأسئلة الشائعة**

**كيف يمكن تعديل النص داخل جدول في شريحة؟**

لتعديل النص داخل جدول في شريحة، استخدم [Table](https://reference.aspose.com/slides/ar/python-net/aspose.slides/table/). تجول عبر الخلايا وقم بتحديث كل خلية عبر [Cell.text_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/cell/text_frame/) وتنسيق الفقرة عبر [Paragraph.paragraph_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/paragraph_format/).

**كيف يمكن تطبيق لون تدرج على النص في شريحة PowerPoint؟**

لتطبيق لون تدرج على النص، استخدم [PortionFormat.fill_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/fill_format/). عيّن [FillFormat.fill_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fillformat/fill_type/) إلى [FillType.GRADIENT](https://reference.aspose.com/slides/ar/python-net/aspose.slides/filltype/) وقم بتكوين نقاط التدرج والاتجاه والشفافية.