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
- تباعد السطر
- خاصية الملاءمة التلقائية
- تثبيت إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر .NET. خصّص الخطوط والألوان والمحاذاة وغيرها."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر .NET. تغطي الألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، مواضع علامات التبويب، وإعدادات اللغة.

ما لم يُذكر خلاف ذلك، تستخدم الأمثلة ملف [sample.pptx](sample.pptx). الشكل الأول في الشريحة الأولى هو مربع نص، والفقرة الأولى فيه تحتوي على النص الموضح أدناه. كل من مؤشرات الشرائح والأشكال تبدأ من الصفر. الأمثلة التي تحدد أجزاءً غامقة تستخدم التنسيق الفعّال، بما في ذلك التنسيق الغامق الموروث:

![نص العينة](sample_text.png)

للعثور على نص حرفي أو تطابقات تعبير عادي وتظليلها، راجع [Search and Replace Text](/slides/ar/python-net/search-and-replace-text/).

## **Set Text Background Color**

استخدم [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) لأجزاء النص الفردية.

المثال التالي يحدد تظليل رمادي فاتح كإعداد افتراضي للفقرة الأولى. الألوان الصريحة للتظليل على الأجزاء الفردية لها أولوية أعلى من هذا الافتراضي:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # اضبط لون التظليل للفقرة بأكملها.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

المثال البرمجي أدناه يوضح كيفية تعيين لون الخلفية **لأجزاء النص ذات الخط الغامق**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # اضبط لون التظليل لجزء النص.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![أجزاء النص الرمادية](gray_text_portions.png)

## **Align Text Paragraphs**

استخدم [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) لتحديد محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة centered أو left-aligned أو right-aligned أو justified وغيرها.

المثال البرمجي التالي يوضح كيفية محاذاة الفقرة إلى **المركز**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # اضبط محاذاة الفقرة إلى المركز.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الفقرة المحاذاة](aligned_paragraph.png)

## **Align Fonts Within a Line**

استخدم [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) لموازاة أجزاء النص ذات أحجام الخط المختلفة عمودياً داخل سطر. ينطبق هذا الإعداد على الفقرة بأكملها ويتحكم في المحاذاة داخل كل سطر منها.

المثال المستقل التالي ينشئ أربعة مربعات نصية معنونة على شريحة واحدة. كل فقرة تحتوي على النص نفسه بحجم 18 و36 و54 نقطة، مع محاذاة خط مختلفة. يستخدم الخط Arial، ويعطل الملاءمة التلقائية واللف، ويحافظ على أن أطر النص كافية لسطر واحد.

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

![مقارنة بين محاذاة Baseline وTop وCenter وBottom مع أحجام خطوط مختلطة](font_alignment.png)

محاذاة الخط تستخدم مقاييس الخط، لذا قد لا تتطابق حواف الأحرف الفردية بالضبط. يتضمن المثال حرفاً كبيراً وحرفاً ذا نقطة أسفلية لتوضيح الفرق بين محاذاة القاعدة والمحاذاة السفلية. توفر الخطوط والاستبدال، الأحرف المستخدمة، والفرق في أحجام الخط يؤثر على النتيجة. أبعاد الإطار، الهوامش، تباعد السطر، اللف، والملاءمة التلقائية تؤثر أيضاً على التخطيط؛ استخدم نفس الخطوط وإعدادات التخطيط عند مقارنة الأنماط.

هذا الإعداد يختلف عن [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/)، الذي يتحكم في المحاذاة الأفقية للفقرة، وعن [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/)، الذي يحدد موضع كتلة النص عمودياً داخل الشكل. يغيّر تنسيق السوبر سكربت والسب سكربت عبر [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) موقع الأجزاء الفردية بالنسبة للقاعدة بدلاً من ضبط محاذاة الخط لسطر الفقرة.

## **Set Transparency for Text**

تتحكم شفافية النص عبر مكوّن ألفا للون المعين إلى [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا بنظام ARGB على مقياس 0–255، وليس نسبة شفافية.

المثال البرمجي أدناه يوضح كيفية تطبيق الشفافية على **الفقرة بأكملها**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # اضبط تعبئة سوداء نصف شفافة للنص.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

المثال البرمجي التالي يوضح كيفية تطبيق الشفافية على **أجزاء النص ذات الخط الغامق**:

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
            # اضبط شفافية جزء النص.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![أجزاء النص الشفافة](transparent_text_portions.png)

## **Set Character Spacing for Text**

استخدم [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) لتوسيع أو تضييق المسافات بين الأحرف داخل مربع نص. تُضيف الأمثلة 3 نقاط من التباعد؛ القيم السالبة تضيق النص.

الكود التالي يوضح كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ملاحظة: استخدم قيم سلبية لضغط تباعد الأحرف.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # وسّع تباعد الأحرف.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

المثال البرمجي أدناه يوضح كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط الغامق**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # ملاحظة: استخدم قيم سلبية لضغط تباعد الأحرف.
            portion.portion_format.spacing = 3  # وسّع تباعد الأحرف.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **Disable Kerning for Specific Fonts**

في بعض الحالات، قد يبدو النص المعروض بواسطة Aspose.Slides ضيقاً قليلاً مقارنةً بالنص نفسه في PowerPoint. يمكن أن يحدث ذلك لأن PowerPoint يتجاهل بيانات kerning لبعض الخطوط، حتى وإن كان الخط يحتوي على معلومات kerning صحيحة وتم تمكينها في إعدادات PowerPoint.

لجعل المخرجات أقرب إلى ما في PowerPoint، يمكنك تعطيل kerning لأجزاء النص التي تستخدم الخط المتأثر. اضبط [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) على قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال ملف "presentation.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى. يتحقق من أسماء الخطوط الفعّالة، بما في ذلك الخطوط الموروثة، ويحدد عتبة 100 نقطة للأجزاء التي تستخدم Roboto. هذا يعطل kerning للأجزاء المطابقة التي يقل حجم الخط عنها 100 نقطة:

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

بالنسبة للنص المطابق تحت العتبة، يمنع هذا الإعداد kerning ويمكن أن يساعد في مطابقة مخرجات Aspose.Slides مع العرض البصري في PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **Manage Text Font Properties**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) أو على الأجزاء الفردية عبر [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

المثال التالي يحدد الخط الافتراضي للفقرة الأولى إلى Times New Roman بحجم 12 نقطة مع تنسيق غامق ومائل وتسطير نقطي. يتفوق التنسيق الصريح على الأجزاء الفردية على هذه القيم الافتراضية.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # عيّن خصائص الخط للفقرة.
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

المثال التالي يطبق حجم 13 نقطة من Times New Roman، وتنسيق مائل، وتسطير نقطي على الأجزاء التي يكون تنسيقها الفعّال غامقًا:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # عيّن خصائص الخط لجزء النص.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![خصائص الخط لأجزاء النص](font_properties_for_text_portions.png)

## **Control Text Height Normalization**

استخدم [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) عند إعادة إنشاء تخطيطات القوالب أو دراسة الفروقات في ارتفاع الأحرف. في PowerPoint، تمكين التسوية يمدد أو يضغط الأحرف الفردية رأسياً لإعطائها ارتفاعًا مرئيًا موحدًا داخل جزء النص. لا يضمن ذلك تساوي ارتفاع النص بين الخطوط المختلفة.

عيّن الخاصية إلى [NullableBool.TRUE أو FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) لتفعيل أو تعطيل التسوية صراحةً. `NullableBool.NOT_DEFINED` يترك الإعداد المحلي غير مُحدَّد بحيث يرث الجزء قيمته، مثلاً من [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) للفقرة. وهذا لا يعني `False`. استخدم [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) وقراءة [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) للحصول على القيمة المنطقية المحلولة.

المثال المستقل التالي يتطلب تثبيت **Arial**. ينشئ كتلتين نصيتين تحتويان على نفس الأحرف الكبيرة والصغيرة، والنقاط السفلية، والحروف ذات النكهات، بحجم 54 نقطة. تُمكّن الفقرتان التسوية افتراضيًا. الجزء العلوي يعطلها صراحةً؛ الجزء السفلي يرثها. أحجام الإطار، الهوامش، وتباعد الفقرات متطابقة، مع تعطيل اللف والملاءمة التلقائية للحفاظ على المقارنة ثابتة. يطبع المثال `FALSE: False` و `NOT_DEFINED: True`، ثم يحفظ الملف "text_height_normalization.pptx".

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

المقارنة أدناه تم تصديرها من العرض المحفوظ. الصف العلوي لديه تسوية معطلة (`FALSE`); الصف السفلي يرث الإعداد المفعّل (`NOT_DEFINED` → `True`). تأكّد من تثبيت Arial لإعادة إنتاج هذا الشكل.

![نص Arial بحجم 54 نقطة مع تسوية معطلة أعلاه وتساوي مُستَعار أدناه](text_height_normalization.png)

تغيّر التسوية ارتفاع الأحرف دون تعديل قيمة [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) المعينة، التي تحدد حجم الخط بالنقاط. يتحكم [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) في الفقرة في تباعد السطر، بينما يتحكم [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) لإطار النص في كيفية تعديل النص أو حاويته لتلائم المساحة. لهذه الإعدادات أغراض مختلفة ويمكن أن تؤثر على التخطيط العام بشكل مستقل. لمزيد من التفاصيل حول تنسيق الفقرة والوراثة، راجع [Manage Paragraph](/slides/ar/python-net/manage-paragraph/).

## **Apply and Remove Strikethrough**

استخدم [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) على جزء نص لعرض تصحيحات أو مصطلحات ملغاة أو أسعار سابقة دون حذف النص الأصلي. عيّنه إلى [TextStrikethroughType.SINGLE أو DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) لسطر أو سطرين عبر النص.

لإزالة الخط المشطوب، عيّنه إلى `TextStrikethroughType.NONE`. هذا يعطل التأثير صراحةً، حتى إن كان التنسيق المحيط يحدده كخط مشطوب. بالمقابل، `TextStrikethroughType.NOT_DEFINED` يترك الإعداد المحلي غير مُعرَّف، مما يسمح للجزء وراثة التنسيق، مثلاً من الفقرة. لا يضمن ذلك إزالة الخط المشطوب. استخدم [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) لقراءة التنسيق الناتج، بما في ذلك القيم الموروثة.

المثال المستقل التالي ينشئ ثلاث مقارنات أسعار. كل فقرة تحتوي على أجزاء منفصلة للعلامة، السعر السابق، والسعر الحالي، لذا يتأثر السعر السابق فقط. الصف الأول يطّبق ثم يزيل الخط المشطوب؛ الصفوف الأخرى تحتفظ بخط مشطوب واحد أو مزدوج. تعديل هذه الخاصية يحافظ على النص وتنسيقه الآخر، بما في ذلك اللون الغامق للسعر السابق.

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

النتيجة، من الأعلى إلى الأسفل: بلا خط مشطوب، خط مشطوب واحد، وخط مشطوب مزدوج.

![الأسعار السابقة بدون خط مشطوب، مع خط مشطوب واحد، ومع خط مشطوب مزدوج](strikethrough.png)

## **Set Text Rotation**

استخدم [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) لتعيين اتجاه نص مسبق داخل شكل.

المثال البرمجي التالي يحدد اتجاه النص في الشكل إلى [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/)، مما يدور النص **90 درجة عكس اتجاه عقرب الساعة**:

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

## **Display Digits Side by Side in Vertical Text**

لإبقاء رقم مكوّن من رقمين معاً في تسمية يابانية رأسية، ضع الرقمين في جزء نص واحد وعيّن [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/) لذلك الجزء. يُنشئ المثال تسميتين في عرض جديد باستخدام [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) وخط MS Gothic بحجم 40 نقطة. تختلف قيمة الـ [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) المعينة للجزء الرقمي فقط.

```python
import aspose.slides as slides


def add_label(slide, x, kumimoji):
    label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 48, 120, 420)
    label.fill_format.fill_type = slides.FillType.NO_FILL
    label.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    frame = label.add_text_frame("")
    frame.text_frame_format.text_vertical_type = slides.TextVerticalType.EAST_ASIAN_VERTICAL

    paragraph = frame.paragraphs[0]
    portion_format = paragraph.paragraph_format.default_portion_format
    font = slides.FontData("MS Gothic")
    portion_format.latin_font = font
    portion_format.east_asian_font = font
    portion_format.font_height = 40
    portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion_format.fill_format.solid_fill_color.color = "black"

    digits = slides.Portion("12")
    digits.portion_format.kumimoji = kumimoji

    paragraph.portions.clear()
    paragraph.portions.add(slides.Portion("令和"))
    paragraph.portions.add(digits)
    paragraph.portions.add(slides.Portion("年"))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    add_label(slide, 120, slides.NullableBool.TRUE)
    add_label(slide, 360, slides.NullableBool.FALSE)
    
    presentation.save("vertical_date.pptx", slides.export.SaveFormat.PPTX)
```

في PowerPoint، تُظهر التسمية اليسرى (`TRUE`) الأرقام بشكل عمودي ومتجاور بين 和 و 年. في التسمية اليمنى (`FALSE`)، يتم دوران الرقمين 90 درجة مع اتجاه عقرب الساعة. تظل الأحرف اليابانية المحيطة عمودية في كلتا التسميتين.

![مقارنة PowerPoint لتسميات التاريخ العمودية مع أرقام عمودية في اليسار وأرقام مدوَّرة في اليمين.](vertical_date.png)

## **Set Custom Rotation for Text Frames**

استخدم [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) لتعيين زاوية دوران مخصصة لإطار نصي عبر [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

المثال البرمجي أدناه يدور إطار النص بزاوية 3 درجات مع اتجاه عقرب الساعة داخل الشكل:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![دوران النص المخصص](custom_text_rotation.png)

## **Set Line Spacing of Paragraphs**

توفر Aspose.Slides الخصائص [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/)، [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/)، و[ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) للتحكم في تباعد الفقرات. تُستخدم هذه الخصائص كالتالي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد التباعد بالنقاط.

المثال التالي يحدد التباعد داخل الفقرة الأولى إلى 200٪ من ارتفاع السطر (تباعد مزدوج):

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

![تباعد السطر داخل الفقرة](line_spacing.png)

## **Control Line Breaking**

قواعد كسر السطر للفقرة مفيدة في كتل نصية ضيقة وعروض تقديمية تُدمج بين النص اللاتيني والآسيوي الشرقي. الخصائص التالية تنتمي إلى [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/)، لذا فهي تُطبق على الفقرة بأكملها:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) يتحكم في قواعد كسر السطر للغتين اللاتينية. في النص المختلط، قد يغيّر ذلك أيضاً موضع النص الآسيوي الشرقي وعلامات الترقيم المجاورة.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) يتحكم في قواعد كسر السطر للآسيوي الشرقي، بما في ذلك القيود على الأحرف في بداية ونهاية السطر.

هذه القواعد لا تُستبدل بـ [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)، الذي يُمكّن اللف التلقائي داخل إطار النص. إنها تؤثر على التخطيط عندما يحدث اللف؛ لا تُضيف أحرف كسر السطر. كسر سطر صريح يُجبر سطرًا جديدًا داخل الفقرة بغض النظر عن العرض المتاح.

المثال المستقل التالي ينشئ كتلة نصية ضيقة تحتوي على نص صيني ولاتيني. يضبط كلتا الخاصيتين لكسر السطر صراحةً ويحفظ الملف "line_breaking.pptx". لتجربة أي قاعدة، غيّر قيمة الخاصية مع إبقاء الأخرى ثابتة. يستخدم المثال خط Arial وSimSun بحجم 24 نقطة وعرض إطار 160 نقطة وهامش أفقي صفري. يُضبط [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) إلى [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) للحفاظ على حجم النص وإطار الشكل ثابتين.

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

## **Control Hanging Punctuation**

تتيح الخاصية [ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) للعلامات الترقيم المؤهلة أن تمتد إلى ما بعد الطرف الأيمن لسطر النص بدلًا من الانتقال إلى السطر التالي. تنطبق على الفقرة بأكملها وتختلف عن المسافة المتدلية.

المثال المستقل التالي يُفعِّل العلامة المعلقة في إطار نص عرضه 100 نقطة ويحفظ الملف "hanging_punctuation.pptx". مع Arial بحجم 24 نقطة وهامش أفقي صفري، يبقى النقطة النهائية بعد كلمة "sentence" وتتمدّ إلى ما بعد الطرف الأيمن للنص. عيّن الخاصية إلى [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) للمقارنة: مع هذه الإعدادات، تحتل النقطة سطرًا منفصلًا. يُفعَّل اللف ويُعطَّل الملاءمة التلقائية للحفاظ على عرض ثابت.

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

ليس كل علامة ترقيم يمكن أن تُعلق. النتيجة المرئية تعتمد على [الخط وظروف التخطيط](#control-line-breaking): تغيير الخط، العرض المتاح، الهوامش، أو إعدادات الملاءمة يمكن أن يُزيل الاختلاف المرئي.

## **Set Autofit Type for Text Frames**

يحدد [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) كيفية تصرف النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص يُصغر، يفيض، أو يُعيد تحجيم الشكل تلقائيًا. المثال التالي يضبط الشكل لإعادة التحجيم ليتناسب مع النص ويحفظ النتيجة إلى "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

لحساب عدد الأسطر بعد اللف التلقائي ورؤية كيف يتغيّر عرض النص أو الشكل، راجع [Count Rendered Lines](/slides/ar/python-net/manage-paragraph/). عدد الأسطر وحده لا يدل على ما إذا كان النص يفيض عن حاويته.

## **Set Anchor of Text Frames**

تُعرّف [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) كيفية وضع النص عموديًا داخل الشكل، مثلًا في الأعلى أو الوسط أو الأسفل. المثال التالي يثبت النص في أسفل الشكل الأول ويحفظ النتيجة إلى "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Tabulation**

استخدم [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) و[ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) لتكوين مواضع علامات التبويب في الفقرة. المثال التالي يحدد الفاصل الافتراضي للعلامة إلى 100 نقطة ويضيف علامة تبويب محاذاة إلى اليسار عند 30 نقطة. تؤثر هذه الإعدادات على النص الذي يحتوي على أحرف تبويب.

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

![علامات التبويب في الفقرة](paragraph_tabs.png)

## **Set Proofing Language**

توفر Aspose.Slides الخاصية [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/)، التي تسمح لك بتعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة لتصحيح الأخطاء الإملائية والنحوية في PowerPoint.

المثال التالي يتطلب ملف "presentation.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتويات الفقرة الأولى بـ "1。"، يعيّن SimSun كخط لها، ويحدد لغة التدقيق الصينية المبسطة (`zh-CN`). يحفظ النتيجة إلى "proofing_language.pptx":

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

    # اضبط لغة التدقيق إلى الصينية المبسطة.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Copy Language Metadata**

عند نسخ نص متعدد اللغات من قالب، احفظ كلًا من [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) و[BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/). المثال المستقل التالي ينشئ جزء مصدر بلغة الإنجليزية (US) كلغتها الأساسية والفرنسية كلغتها البديلة، وينسخ النص والمعرفات إلى جزء في عرض جديد.

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

لتجربة مصدر بدون لغة بديلة، احذف تعيين `"fr-FR"`. يصبح المعرف البديل `None`، ويُحافظ بيان النسخ نفسه على غيابه دون إضافة قيمة افتراضية، حتى إذا كان الوجهة يحتوي مسبقًا على لغة بديلة مُعيّنة.

هذه المعرفات تخزن بيانات لغة. حفظها لا يحدد أي قاموس ستختاره PowerPoint للتدقيق الإملائي أو النحوي.

## **Set Default Language**

استخدم [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) لتحديد اللغة الافتراضية للنص المُنشأ أثناء تحميل أو إنشاء عرض تقديمي. المثال التالي ينشئ عرضًا بلغته الافتراضية الإنجليزية (US)، يضيف مربع نص، ويطبع `en-US` للجزء النصي الأول.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # أضف شكل مستطيل جديد مع نص.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # تحقّق من لغة الجزء الأول.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Set Default Text Style**

لتطبيق تنسيق نص افتراضي على مستوى العرض، استخدم [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

المثال التالي يحدد خطًا غامقًا بحجم 14 نقطة كإعداد افتراضي للفقرات العليا في عرض جديد ويحفظه إلى "default_text_style.pptx". يمكن للنص وراثة هذه الإعدادات ما لم يتجاوزها تنسيق أكثر تحديدًا.

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

## **Extract Text with the All-Caps Effect**

في PowerPoint، يَظهر تطبيق تأثير **All Caps** للخط النص بأحرف كبيرة على الشريحة حتى لو كُتب أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي عبر Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمطابقة النص المعروض، افحص [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) وحوِّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `ALL`.

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

## **FAQ**

**How do I modify text in a table on a slide?**

لتعديل النص في جدول على شريحة، استخدم [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). استعرض الخلايا وحدث كل خلية عبر [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) وتنسيق الفقرة عبر [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**How do I apply a gradient color to text on a PowerPoint slide?**

لتطبيق لون متدرج على النص، استخدم [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). عيّن [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) إلى [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) وركّب نقاط التدرج، الاتجاه، والشفافية.

ميزة ذات صلة: [Format text within slides](/slides/ar/features/text-formatting/).