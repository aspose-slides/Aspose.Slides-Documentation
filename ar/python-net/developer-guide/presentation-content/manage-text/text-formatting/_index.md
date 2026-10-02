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
- جدولة النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة بايثون عبر .NET. خصّص الخطوط والألوان والمحاذاة والمزيد."
---
## **نظرة عامة**

تُظهر هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر .NET. وتغطي ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، نقاط التبويب، وإعدادات اللغة.

ما لم يُذكر خلاف ذلك، تستخدم الأمثلة الملف [sample.pptx](sample.pptx). الشكل الأول على الشريحة الأولى هو مربع نص، والفقرة الأولى فيه تحتوي على النص المعروض أدناه. كلا من فهارس الشرائح والأشكال تُعدّ صفرية. الأمثلة التي تحدد أجزاءً غليظة تستخدم التنسيق الفعّال، بما في ذلك التنسيق الغليظ الموروث:

![نص عينة](sample_text.png)

للعثور على نص حرفي أو مطابقة تعبير نمطي وتظليلها، راجع [البحث واستبدال النص](/slides/ar/python-net/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) لأجزاء النص الفردية.

المثال التالي يعيّن تظليلاً رمادياً فاتحًا كافتراضي للفقرة الأولى. تُعطى ألوان التظليل الصريحة على الأجزاء الفردية أولوية على هذا الافتراضي:

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

المثال البرمجي أدناه يوضح كيفية تعيين لون خلفية لـ **أجزاء النص ذات الخط الغليظ**:

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

استخدم [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزية، محاذية إلى اليسار، محاذية إلى اليمين، مبررة، وما إلى ذلك.

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

## **محاذاة الخطوط داخل سطر**

استخدم [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) لمحاذاة أعمق أشرطة النص ذات أحجام الخط المختلفة داخل سطر. يُطبّق هذا الإعداد على الفقرة بأكملها ويتحكم في المحاذاة داخل كل سطر منها.

المثال المستقل التالي ينشئ أربعة مربعات نص ذات تسميات على شريحة واحدة. يحتوي كل فقرة على نفس النص بحجم 18، 36، و54 نقطة، مع محاذاة خط مختلفة. يستخدم الخط Arial، ويعطل الملاءمة التلقائية والالتفاف، ويجعل إطارات النص كبيرة بما يكفي لسطر واحد.

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

![مقارنة بين محاذاة القاع، القمة، الوسط، والقاعدة للخطوط المختلطة الأحجام](font_alignment.png)

تستخدم محاذاة الخط مقاييس الخط، لذا فإن حواف الحروف الفردية قد لا تتطابق تمامًا. يتضمن المثال حرفًا كبيرًا وحرفًا ذو انخفاض لتوضيح الفرق بين محاذاة القاعدة والقاع. تتأثر النتيجة بتوفر الخطوط والاستبدال، وبالحروف المستخدمة، وباختلاف أحجام الخطوط. كما تؤثر أبعاد الإطار، الهوامش، تباعد السطر، الالتفاف، والملاءمة التلقائية على التخطيط؛ استخدم نفس الخطوط وإعدادات التخطيط عند مقارنة الأنماط.

هذا الإعداد يختلف عن [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/)، الذي يتحكم في محاذاة الفقرة أفقياً، وعن [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/)، الذي يحدد موضع كتلة النص عمودياً داخل الشكل. يغيّر تنسيق الفهرس الفوقي والسفلي عبر [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) موضع الأجزاء الفردية بالنسبة للقاعدة بدلاً من ضبط محاذاة الخط لأسطر الفقرة.

## **تعيين الشفافية للنص**

تُتحكم شفافية النص عبر مكوّن alpha للون المعيّن إلى [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة alpha من نوع ARGB على مقياس 0–255، ليس نسبة شفافية.

المثال البرمجي أدناه يوضح كيفية تطبيق شفافية على **الفقرة بأكملها**:

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

![الفقرة الشفافة](transparent_paragraph.png)

المثال التالي يوضح كيفية تطبيق شفافية على **أجزاء النص ذات الخط الغليظ**:

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

استخدم [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) لتوسيع أو تقليص التباعد بين الأحرف في مربع نص. تضيف الأمثلة 3 نقاط تباعد؛ القيم السالبة تقصر النص.

الكود التالي يوضح كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ملاحظة: استخدم القيم السلبية لضغط تباعد الأحرف.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

المثال البرمجي أدناه يوضح كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط الغليظ**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # ملاحظة: استخدم القيم السلبية لضغط تباعد الأحرف.
            portion.portion_format.spacing = 3  # توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **تعطيل التخصيب (Kerning) لخطوط محددة**

في بعض الحالات قد يبدو النص المرسوم بـ Aspose.Slides أكثر ضيقًا قليلًا مقارنةً بالنص نفسه في PowerPoint. قد يحدث ذلك لأن PowerPoint قد يتجاهل بيانات التخصيب لبعض الخطوط، حتى وإن كانت الخطوط تحتوي على معلومات تخصيب صالحة وكان التخصيب مفعَّلاً في إعدادات PowerPoint.

لجعل الإخراج المرسوم أقرب إلى ما ينتجه PowerPoint في مثل هذه الحالات، يمكنك تعطيل التخصيب لأجزاء النص التي تستخدم الخط المتأثر. عيّن [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) إلى قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال وجود "presentation.pptx" مع مربع نص كأول شكل على الشريحة الأولى. يتحقق من أسماء الخطوط الفعّالة، بما في ذلك الخطوط الموروثة، ويعيّن عتبة 100 نقطة للأجزاء التي تستخدم خط Roboto. هذا يعطل التخصيب للأجزاء التي يقل حجم خطها عن 100 نقطة:

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

للنص المتطابق تحت العتبة، يمنع هذا الإعداد التخصيب ويمكن أن يساعد في تقريب مظهر Aspose.Slides إلى مظهر PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) أو على الأجزاء الفردية عبر [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

المثال التالي يعيّن الخط الافتراضي للفقرة الأولى إلى Times New Roman بحجم 12 نقطة مع تنسيق غليظ ومائل وتسطير منقط. يَسْتَحْقّق التنسيق الصريح على الأجزاء الفردية أولوية على هذه القيم الافتراضية:

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

المثال التالي يطبق Times New Roman بحجم 13 نقطة، وتنسيق مائل، وتسطير منقط على الأجزاء التي يكون تنسيقها الفعّال غليظًا:

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

## **تعيين دوران النص**

استخدم [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) لتعيين اتجاه نص مسبق التعريف داخل شكل.

المثال البرمجي التالي يعيّن اتجاه النص في الشكل إلى [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/)، مما يدور النص **90 درجة عكس اتجاه العقارب**:

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

استخدم [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) لتعيين زاوية دوران مخصصة لـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

المثال البرمجي أدناه يدور إطار النص 3 درجات مع عقارب الساعة داخل الشكل:

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

## **تعيين تباعد الأسطر للفقرات**

توفر Aspose.Slides الخصائص [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/)، [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/)، و[ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) للتحكم في تباعد الفقرات. تُستخدم هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

المثال التالي يعيّن التباعد داخل الفقرة الأولى إلى 200 % من ارتفاع السطر (تباعد مزدوج):

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

## **التحكم في كسر السطر**

قواعد كسر سطر الفقرة مفيدة في كتل نصية ضيقة وعروض تقديمية تمزج بين النص اللاتيني والآسيوي الشرقي. الخصائص التالية تنتمي إلى [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/)، لذا فهي تُطبق على الفقرة بأكملها:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) يتحكم في قواعد كسر السطر للخط اللاتيني. في النص المختلط، قد يغيّر ذلك أيضًا مكان التفاف النص الآسيوي الشرقي وعلامات الترقيم المجاورة.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) يتحكم في قواعد كسر السطر للآسيوي الشرقي، بما في ذلك القيود على الأحرف في بداية ونهاية السطر.

هذه القواعد لا تحل محل [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)، الذي يفعّل الالتفاف التلقائي داخل إطار النص. إنها تؤثر على التخطيط عند حدوث الالتفاف؛ لا تُدرج أحرف كسر السطر. كسر سطر صريح يُدخل سطرًا جديدًا داخل الفقرة بغض النظر عن العرض المتاح.

المثال المستقل التالي ينشئ كتلة نصية ضيقة تحتوي على نص صيني ولاتيني. يعيّن كلا خصائص كسر السطر صراحةً ويحفظ الملف "line_breaking.pptx". لتجربة أي قاعدة، غيّر قيمة الخاصية مع إبقاء الإعدادات الأخرى ثابتة. يستخدم المثال Arial بحجم 24 نقطة وSimSun مع عرض إطار 160 نقطة وهوامش أفقية صفرية. تُعيّن الخاصية [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) إلى [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) بحيث يبقى حجم النص وأبعاد الإطار ثابتين.

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

يتيح [ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) للعلامات التي تستوفي الشروط أن تمتد إلى ما بعد الحافة اليمنى لسطر النص بدلاً من الانتقال إلى السطر التالي. ينطبق ذلك على الفقرة بأكملها ويختلف عن الهوامش المتدلية.

المثال المستقل التالي يفعّل علامات الترقيم المتدلية في إطار نص بعرض 100 نقطة ويحفظ الملف "hanging_punctuation.pptx". مع Arial بحجم 24 نقطة وهوامش أفقية صفرية، يبقى النقطة النهائية بعد كلمة "sentence" وتمتد إلى ما بعد الحافة اليمنى. عيّن الخاصية إلى [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) للمقارنة: في هذه الحالة تشغل النقطة سطرًا منفصلًا. يُفعَّل الالتفاف وتُعطَّل الملاءمة التلقائية للحفاظ على العرض المتاح ثابتًا.

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

ليس كل علامة ترقيم يمكنها التمدد. يعتمد النتيجة المرئية على [الخط وظروف التخطيط](#control-line-breaking): تغيير الخط أو العرض المتاح أو الهوامش أو إعدادات الملاءمة التلقائية قد يزيل الاختلاف المرئي.

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

يحدد [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) سلوك النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص ينكمش، يفيض، أم يعيد تحجيم الشكل تلقائيًا. المثال التالي يضبط الشكل ليُعاد تحجيمه ليتناسب مع النص ويحفظ النتيجة في "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

لعدّ الأسطر بعد الالتفاف التلقائي وملاحظة كيف يتغيّر عرض النص أو الشكل، راجع [عدّ الأسطر المرسومة](/slides/ar/python-net/manage-paragraph/). عدد الأسطر وحده لا يدل على ما إذا كان النص يتجاوز حاويته.

## **تعيين تثبيت إطارات النص**

يُعرّف [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) كيفية تموضع النص عموديًا داخل الشكل، مثلًا في الأعلى، الوسط، أو الأسفل. المثال التالي يثبت النص في أسفل الشكل الأول ويحفظ النتيجة في "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين جدولة التبويبات للنص**

استخدم [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) و[ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) لتكوين نقاط التبويب في فقرة. المثال التالي يعيّن الفاصل الافتراضي للتبويب إلى 100 نقطة ويضيف نقطة تبويب محاذية إلى اليسار عند 30 نقطة. تؤثر هذه الإعدادات على النص الذي يحتوي على أحرف تبويب.

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

يُقدِّم Aspose.Slides الخاصية [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/)، التي تسمح لك بتعيين لغة التدقيق لجزء نص. تُحدِّد لغة التدقيق اللغة المستخدمة لتدقيق الإملاء والنحو في PowerPoint.

المثال التالي يتطلب ملف "presentation.pptx" يحتوي على مربع نص كأول شكل على الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتويات الفقرة الأولى بـ "1。"، يعيّن SimSun كخط لها، ويعيّن لغة التدقيق الصينية المبسطة (`zh-CN`). يحفظ النتيجة في "proofing_language.pptx":

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

استخدم [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) لتحديد اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي. المثال التالي ينشئ عرضًا تقديميًا باللغة الإنجليزية الأمريكية كلغة نص افتراضية، يضيف مربع نص، ويطبع `en-US` للجزء النصي الأول.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # أضف شكلًا مستطيلًا جديدًا يحتوي على نص.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # تحقق من لغة الجزء الأول.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

المثال التالي يعيّن خطًا غليظًا بحجم 14 نقطة كافتراضي للفقرات العلوية في عرض تقديمي جديد ويحفظه في "default_text_style.pptx". يمكن للنص أن يرث هذه الإعدادات ما لم يتجاوزها تنسيق أكثر تحديدًا.

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

## **استخراج النص مع تأثير الأحرف الكبيرة (All Caps)**

في PowerPoint، تطبيق تأثير الخط **All Caps** يجعل النص يظهر بأحرف كبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمطابقة النص المعروض، تحقّق من [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) وحوِّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `ALL`.

هذا المثال يتطلب ملف "sample2.pptx" يحتوي على مربع نص كأول شكل على الشريحة الأولى. يحتوي الجزء الأول من الفقرة الأولى على "Hello, Aspose!" مع تطبيق تأثير All Caps، كما هو موضح أدناه.

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

الناتج:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة المتكررة**

**كيف يمكنني تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). iterates خلال الخلايا وحدث كل خلية عبر [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) وتنسيق الفقرة عبر [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**كيف يمكنني تطبيق لون متدرج للنص على شريحة PowerPoint؟**

لتطبيق لون متدرج للنص، استخدم [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). عيّن [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) إلى [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) و configure نقاط التدرج، الاتجاه، والشفافية.