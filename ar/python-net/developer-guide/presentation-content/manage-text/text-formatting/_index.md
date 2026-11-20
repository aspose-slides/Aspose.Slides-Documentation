---
title: تنسيق نص العرض التقديمي في Python
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
- خاصية الضبط التلقائي
- مرساة إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- العرض التقديمي
- Python
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر .NET. خصّص الخطوط والألوان والمحاذاة وغيرها."
---
## **نظرة عامة**

تُظهر هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر .NET. تشمل المواضيع ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الضبط التلقائي، تثبيت النص، نقاط التبويب، وإعدادات اللغة.

ما لم يُذكر خلاف ذلك، تستخدم الأمثلة الملف [sample.pptx](sample.pptx). الشكل الأول في الشريحة الأولى هو مربع نص، وفقرةه الأولى تحتوي على النص المعروض أدناه. كل من فهارس الشرائح والأشكال تبدأ من الصفر. الأمثلة التي تحدد أجزاء غامقة تستخدم التنسيق الفعَّال، بما في ذلك التنسيق الغامق الموروث:

![نص عينة](sample_text.png)

للعثور على نص حرفي أو مطابقة تعبير عادي وتظليله، راجع [بحث واستبدال النص](/slides/ar/python-net/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) لأجزاء النص الفردية.

المثال التالي يضبط تظليل رمادي فاتح كافتراضي للفقرة الأولى. تُعرَف ألوان التظليل الصريحة على الأجزاء الفردية أولوية على هذا الافتراضي:

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

![الفقرة الرمادية](gray_paragraph.png)

المثال البرمجي أدناه يوضح كيفية ضبط لون الخلفية **لأجزاء النص ذات الخط الغامق**:

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

![أجزاء النص الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزة، مُحاذاة إلى اليسار، إلى اليمين، مبررة، وما إلى ذلك.

المثال البرمجي التالي يوضح كيفية محاذاة الفقرة إلى **المركز**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تعيين محاذاة الفقرة إلى المركز.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الفقرة المحاذاة](aligned_paragraph.png)

## **محاذاة الخطوط داخل السطر**

استخدم [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) لمحاذاة أجزاء النص ذات أحجام الخط المختلفة رأسياً داخل السطر. يُطبق هذا الإعداد على الفقرة بأكملها ويتحكم في المحاذاة داخل كل سطر فيها.

المثال التالي يُنشئ أربعة مربعات نص مُسماة على شريحة واحدة. كل فقرة تحتوي على نفس النص بحجم 18، 36، و54 نقطة، مع محاذاة خط مختلفة. يستخدم الخط Arial، ويعطل الضبط التلقائي واللفات، ويُبقي إطارات النص كبيرة بما يكفي لسطر واحد.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![مقارنة محاذاة Baseline, Top, Center, وBottom مع أحجام خطوط مختلطة](font_alignment.png)

تستخدم محاذاة الخط مقاييس الخط، لذا قد لا تتطابق حواف الحروف الفردية بالضبط. يتضمن المثال حرفاً كبيراً وحرفًا منخفضًا لتوضيح الفرق بين محاذاة القاعدة والسفلي. تؤثر توفر الخطوط والاستبدال، الأحرف المستخدمة، واختلاف أحجام الخطوط على النتيجة. كما تؤثر أبعاد الإطار، الهوامش، تباعد الأسطر، اللف، والضبط التلقائي على التخطيط؛ استخدم نفس الخطوط وإعدادات التخطيط عند مقارنة الأوضاع.

يختلف هذا الإعداد عن [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/)، الذي يتحكم في المحاذاة الأفقية للفقرة، و[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/)، الذي يضع كتلة النص عمودياً داخل الشكل. يغيّر تنسيق الفوقية والسفلية عبر [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) أجزاء النص بالنسبة للقاعدة بدلاً من ضبط محاذاة الخط لسطر الفقرة.

## **تعيين شفافية النص**

تُتحكم شفافية النص عبر مكوّن ألفا للون المعيّن إلى [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا ARGB على مقياس 0–255، وليس نسبة شفافية.

المثال البرمجي التالي يُظهر كيفية تطبيق الشفافية على **الفقرة بأكملها**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تعيين تعبئة سوداء نصف شفافة للنص.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

المثال التالي يُظهر كيفية تطبيق الشفافية على **أجزاء النص ذات الخط الغامق**:

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

![أجزاء النص الشفافة](transparent_text_portions.png)

## **تعيين تباعد الأحرف للنص**

استخدم [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) لتوسيع أو تضييق التباعد بين الأحرف في مربع نص. تُضيف الأمثلة 3 نقاط تباعد؛ القيم السالبة تضيق النص.

المثال البرمجي التالي يُظهر كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ملاحظة: استخدم القيم السالبة لضغط تباعد الأحرف.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

المثال البرمجي أدناه يُظهر كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط الغامق**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # ملاحظة: استخدم القيم السالبة لضغط تباعد الأحرف.
            portion.portion_format.spacing = 3  # توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **تعطيل التكرن (Kerning) للخطوط المحددة**

في بعض الحالات قد يبدو النص المُصدَّر بواسطة Aspose.Slides أكثر تضيقًا قليلًا مقارنةً بالنص نفسه في PowerPoint. يمكن أن يحدث ذلك لأن PowerPoint قد يتجاهل بيانات التكرن لبعض الخطوط، حتى وإن كان الخط يحتوي على معلومات تكرن صحيحة وتم تمكين التكرن في إعدادات PowerPoint.

لجعل النتيجة المُصدَّرة أقرب إلى ما يقدمه PowerPoint في مثل هذه الحالات، يمكنك تعطيل التكرن لأجزاء النص التي تستخدم الخط المتأثر. اضبط [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) إلى قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال وجود ملف "presentation.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى. يتحقق من أسماء الخطوط الفعَّالة، بما في ذلك الخطوط الموروثة، ويضبط عتبة 100 نقطة للأجزاء التي تستخدم خط Roboto. هذا يعطل التكرن للأجزاء المطابقة ذات حجم الخط أقل من 100 نقطة:

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

بالنسبة للنص المطابق الذي يقل عن العتبة، يمنع هذا الإعداد التكرن ويمكن أن يساعد في مواءمة عرض Aspose.Slides مع مظهر PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) أو على الأجزاء الفردية عبر [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

المثال التالي يضبط الخط الافتراضي للفقرة الأولى إلى Times New Roman بحجم 12 نقطة مع تنسيق غامق، مائل، وتسطير نقطي. يَأخذ التنسيق الصريح للأجزاء الفردية أولوية على هذه القيم الافتراضية:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تعيين خصائص الخط للفقرة.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![خصائص الخط للفقرة](font_properties_for_paragraph.png)

المثال التالي يطبق حجم 13 نقطة من Times New Roman، تنسيق مائل، وتسطير نقطي على الأجزاء التي يكون تنسيقها الفعَّال غامقًا:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

## **التحكم في ضبط ارتفاع النص**

استخدم [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) عند إعادة إنتاج طباعة القالب أو فحص الفروقات في ارتفاع الأحرف. في PowerPoint، يُمكِّن الضبط المعياري من تمديد أو ضغط الأحرف عموديًا لتظهر بارتفاع مرئي موحد داخل جزء النص. لا يضمن ذلك تساوي ارتفاعات النص عبر خطوط مختلفة.

اضبط الخاصية إلى [NullableBool.TRUE أو FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) لتمكين أو تعطيل الضبط صراحةً. `NullableBool.NOT_DEFINED` يترك الإعداد المحلي غير محدد بحيث يرث الجزء قيمته، مثلاً من [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) الخاص بالفقرة. لا يعني ذلك `False`. استخدم [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) وقراءة [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) للحصول على القيمة المنطقية المُحلَّة.

المثال التالي يتطلب تثبيت **Arial**. يُنشئ كتلتين نصيتين يحتويان على نفس الحروف الكبيرة والصغيرة، الحروف المنخفضة، والرموز المشكَّلة بحجم 54 نقطة. تُفعَّل الضبط المعياري في الفقرتين افتراضيًا. الجزء العلوي يعطل الضبط صراحةً؛ الجزء السفلي يرث الإعداد. أبعاد الإطارات، الهوامش، وتباعد الفقرات متماثلة، مع تعطيل اللف والضبط التلقائي للحفاظ على المقارنة. يطبع المثال `FALSE: False` و`NOT_DEFINED: True`، ثم يحفظ الملف "text_height_normalization.pptx".

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

المقارنة أدناه تم تصديرها من العرض المحفوظ. الصف العلوي به ضبط مرفوض (`FALSE`)؛ الصف السفلي يرث الضبط المُمكّن (`NOT_DEFINED` → `True`). احرص على تثبيت Arial لإعادة إنتاج هذا الشكل.

![نص Arial بحجم 54 نقطة مع ضبط مرفوض أعلاه وضبط ممكّن مُورث أدناه](text_height_normalization.png)

يغيّر الضبط المعياري ارتفاع الأحرف دون تغيير قيمة [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) المعينة، التي تحدد حجم الخط بالنقاط. يتحكم [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) في الفقرة في تباعد الأسطر، بينما يتحكم [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) لإطار النص في كيفية تعديل النص أو حاويته لتلائم المساحة. تخدم هذه الإعدادات أغراضًا مختلفة ويمكن أن تؤثر على التخطيط العام بشكل مستقل. للمزيد حول تنسيق الفقرات والوراثة، راجع [إدارة الفقرات](/slides/ar/python-net/manage-paragraph/).

## **تطبيق وإزالة الخط المشطوب**

استخدم [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) على جزء نص لإظهار تصحيحات أو إلغاءات أو أسعار سابقة دون حذف النص الأصلي. عيّنها إلى [TextStrikethroughType.SINGLE أو DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) لسطر أو سطرين مشطوبين عبر النص.

لإزالة الخط المشطوب، عيّن `TextStrikethroughType.NONE`. هذا يُعطل التأثير صراحةً، حتى لو كان التنسيق المحيط يُحدِّد خطًا مشطوبًا. بالمقابل، `TextStrikethroughType.NOT_DEFINED` يترك الإعداد المحلي غير معرف، مما يسمح للجزء بوراثة التنسيق، مثلاً من الفقرة. لا يضمن ذلك إزالة الخط المشطوب. استخدم [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) لقراءة التنسيق الناتج، بما في ذلك القيم الموروثة.

المثال التالي يُنشئ ثلاث مقارنات سعرية. كل فقرة تتضمن أجزاءً منفصلة للعلامة، السعر السابق، والسعر الحالي، بحيث يتأثر السعر السابق فقط. الصف الأول يطبق الخط المشطوب ثم يزيله؛ الصفوف الأخرى تحافظ على الخط المشطوب الفردي والمزدوج. تغيير هذه الخاصية يحافظ على النص وتنسيقه الآخر، بما في ذلك الغامق للسعر السابق.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # تطبيق الخط المشطوب، ثم إزالته صراحةً من السعر السابق الأول.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة، من الأعلى إلى الأسفل: بدون خط مشطوب، خط مشطوب أحادي، وخط مشطوب مزدوج.

![الأسعار السابقة بدون خط مشطوب، بخط مشطوب أحادي، وبخط مشطوب مزدوج](strikethrough.png)

## **تعيين دوران النص**

استخدم [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) لتعيين اتجاه نص مسبق داخل شكل.

المثال التالي يعيّن اتجاه النص في الشكل إلى [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/)، والذي يدور النص **90 درجة عكس عقرب الساعة**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![دوران النص](text_rotation.png)

## **تعيين دوران مخصص لإطارات النص**

استخدم [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) لتحديد زاوية دوران مخصصة لـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

المثال البرمجي أدناه يدور إطار النص 3 درجات باتجاه عقرب الساعة داخل الشكل:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الدوران المخصص للنص](custom_text_rotation.png)

## **تعيين تباعد الأسطر للفقرات**

توفر Aspose.Slides الخصائص [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/)، [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/)، و[ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) للتحكم في تباعد الفقرات. تُستخدم هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد الأسطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد الأسطر بالنقاط.

المثال التالي يضبط التباعد داخل الفقرة الأولى إلى 200 % من ارتفاع السطر (تباعد مزدوج):

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

![تباعد الأسطر داخل الفقرة](line_spacing.png)

## **التحكم في كسر السطر**

قواعد كسر سطر الفقرة مفيدة في كتل نصية ضيّقة وعروض تقديمية تمزج بين النص اللاتيني والآسيوي الشرقي. الخصائص التالية تتبع [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/)، لذا فهي تنطبق على الفقرة بأكملها:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) يتحكم في قواعد كسر السطر للخط اللاتيني. في النص المختلط، قد يغيّر ذلك موضع التفاف النص الآسيوي الشرقي وعلامات الترقيم المجاورة.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) يتحكم في قواعد كسر السطر للآسيوي الشرقي، بما في ذلك القيود على الأحرف في بداية ونهاية السطر.

هذه القواعد لا تستبدل [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)، التي تُفعِّل الالتفاف التلقائي داخل إطار النص. إنها تؤثر على التخطيط عندما يحدث الالتفاف؛ لا تُدرج أحرف كسر السطر. كسر سطر صريح يفرض سطرًا جديدًا داخل الفقرة مستقلاً عن العرض المتاح.

المثال التالي يُنشئ كتلة نصية ضيقة تحتوي على نص صيني ولاتيني. يضبط كلا خاصيتي كسر السطر صراحةً ويحفظ الملف "line_breaking.pptx". لتجربة أي قاعدة، غيّر قيمة الخاصية مع إبقاء الأخرى ثابتة. يستخدم المثال خط Arial بحجم 24 نقطة وSimSun مع عرض إطار 160 نقطة وهوامش أفقية صفرية. يُعيّن [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) إلى [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) بحيث يبقى حجم النص وأبعاد الإطار ثابتين.

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

## **التحكم في علامات الترقيم المعلقة**

يتيح [ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) للعلامات الترقيمية المؤهلة أن تمتد خارج الحافة اليمنى لسطر النص بدلاً من أن تحتل السطر التالي. ينطبق على الفقرة بأكملها ويختلف عن المسافة المتداولة (hanging indent).

المثال التالي يمكّن علامات الترقيم المعلقة في إطار نص بعرض 100 نقطة ويحفظ الملف "hanging_punctuation.pptx". مع Arial بحجم 24 نقطة وهوامش أفقية صفرية، يبقى النقطة النهائية بعد كلمة "sentence" وتمتد إلى ما وراء الحافة اليمنى للنص. عيّن الخاصية إلى [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) للمقارنة: مع هذه الإعدادات، تشغل النقطة سطرًا منفصلاً. يُفعَّل اللف وتُعطل الضبط التلقائي للحفاظ على عرض ثابت.

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

ليس كل علامة ترقيم يمكن أن تُعلق. النتيجة المرئية تعتمد على [الخط وظروف التخطيط](#control-line-breaking): تغيير الخط أو العرض المتاح أو الهوامش أو إعدادات الضبط التلقائي يمكن أن يُزيل الاختلاف الظاهر.

## **تعيين نوع الضبط التلقائي لإطارات النص**

يحدد [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) كيفية تصرف النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص يتقَلص، يفيض، أو يغير حجم الشكل تلقائيًا. المثال التالي يضبط الشكل لإعادة حجمه ليلائم النص ويحفظ النتيجة في "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

لحساب عدد الأسطر بعد الالتفاف التلقائي ورؤية كيفية تغير عرض النص أو الشكل، راجع [عد الأسطر المُصدَّرة](/slides/ar/python-net/manage-paragraph/). عدد الأسطر وحده لا يُظهر ما إذا كان النص يفيض حاويته.

## **تعيين مرساة إطارات النص**

يعرّف [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) كيف يُوضع النص عموديًا داخل الشكل، مثلًا في الأعلى أو الوسط أو الأسفل. المثال التالي يَرْسِي النص إلى أسفل الشكل الأول ويحفظ النتيجة في "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تبويب النص**

استخدم [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) و[ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) لتكوين نقاط التبويب في الفقرة. المثال التالي يضبط الفاصل الافتراضي للتاب إلى 100 نقطة ويضيف نقطة تبويب مُحاذاة لليسار عند 30 نقطة. تؤثر هذه الإعدادات على النص الذي يحتوي على أحرف تبويب.

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

![تبويبات الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides الخاصية [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/)، التي تتيح لك تعيين لغة التدقيق لجزء نص. تحدد لغة التدقيق اللغة المستخدمة لتصحيح الإملاء والقواعد في PowerPoint.

المثال التالي يتطلب ملف "presentation.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتويات الفقرة الأولى بـ "1。" ويضبط SimSun كخط لها، ويُعيّن لغة التدقيق الصينية المبسطة (`zh-CN`). يحفظ النتيجة في "proofing_language.pptx":

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

### **نسخ بيانات اللغة الوصفية**

عند نسخ نص متعدد اللغات من قالب، حافظ على كل من [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) و[BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/). المثال التالي يُنشئ جزءًا مصدرًا بلغته الإنجليزية (US) واللغة البديلة الفرنسية، وينسخ النص والمعرفات إلى جزء في عرض جديد.

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # إذا لم يكن للمصدر لغة بديلة، فإن None يمسح قيمة الوجهة.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

لتجربة مصدر بدون لغة بديلة، احذف تعيين `"fr-FR"`. يصبح المعرف البديل `None`، ويحافظ بيان النسخ نفسه على عدم وجوده دون إدخال قيمة افتراضية، حتى إذا كان الوجهة قد عيّنت لغة بديلة مسبقًا.

هذه المعرفات تخزن بيانات لغة وصفية. حفظها لا يحدِّد أي قاموس سيختاره PowerPoint للتدقيق الإملائي أو النحوي.

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) لتحديد اللغة الافتراضية للنص المُنشأ أثناء تحميل أو إنشاء عرض تقديمي. المثال التالي يُنشئ عرضًا بلغته الإنجليزية (US) كلغة نص افتراضية، يضيف مربع نص، ويطبع `en-US` للجزء النصي الأول.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # إضافة شكل مستطيل جديد مع النص.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # تحقق من لغة الجزء الأول.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

المثال التالي يضبط خطًا غامقًا بحجم 14 نقطة كافتراضي للفقرات العليا في عرض جديد ويحفظه في "default_text_style.pptx". يمكن للنص أن يرث هذه القيم الافتراضية ما لم يتجاوزها تنسيق أكثر تخصيصًا.

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

## **استخراج النص بتأثير الحروف الكبيرة جميعًا**

في PowerPoint، يجعل تطبيق تأثير الخط **All Caps** النص يظهر بأحرف كبيرة على الشريحة حتى وإن كُتب أصلاً بأحرف صغيرة. عند استرداد جزء نص كهذا باستخدام Aspose.Slides، تُعيد المكتبة النص كما كُتب بالضبط. لمطابقة النص المعروض، تفقد [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) وحوِّل السلسلة التي تُرجَع إلى أحرف كبيرة عندما تكون القيمة `ALL`.

المثال التالي يتطلب ملف "sample2.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى. يحتوي الجزء الأول من الفقرة الأولى على "Hello, Aspose!" مع تطبيق تأثير All Caps، كما هو موضح أدناه.

![تأثير All Caps](all_caps_effect.png)

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

الإخراج:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة الشائعة**

**كيف يمكن تعديل النص في جدول داخل شريحة؟**

لتعديل النص في جدول داخل شريحة، استخدم [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). استعرض الخلايا وقم بتحديث كل خلية عبر [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) وتنسيق الفقرة عبر [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**كيف يمكن تطبيق لون تدرج على النص في شريحة PowerPoint؟**

لتطبيق لون تدرج على النص، استخدم [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). عيّن [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) إلى [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) ثم اضبط نقاط التدرج، الاتجاه، والشفافية.

الميزة المرتبطة: [تنسيق النص داخل الشرائح](/slides/ar/features/text-formatting/).