---
title: تنسيق نص العرض التقديمي في Python عبر Java
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/python-java/text-formatting/
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
- مرساة إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر Java. تخصيص الخطوط، الألوان، المحاذاة، وأكثر."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Python عبر Java. إنها تغطي ألوان الخلفية، والشفافية، وتباعد الأحرف، وخصائص الخط، والدوران، وتباعد الفقرات، وسلوك الملاءمة التلقائية، وتثبيت النص، وإعدادات التبويب، وإعدادات اللغة.

ما لم يُذكر خلاف ذلك، تستخدم الأمثلة الملف [sample.pptx](sample.pptx). الشكل الأول في الشريحة الأولى هو مربع نص، والفقرة الأولى فيه تحتوي على النص المعروض أدناه. كل من فهارس الشرائح والأشكال تبدأ من الصفر. الأمثلة التي تختار أجزاء غامقة تستخدم تنسيقًا فعالًا، بما في ذلك تنسيق الغامق الموروث:

![نص تجريبي](sample_text.png)

للعثور على نص حرفي أو تطابقات تعبير عادي وتحديدها، راجع [بحث واستبدال النص](/slides/ar/python-java/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) لأجزاء النص الفردية.

المثال التالي يضبط تظليلًا رماديًا فاتحًا كقيمة افتراضية للفقرة الأولى. تظليل الأجزاء الفردية يتجاوز هذا الافتراضي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # تعيين لون التظليل للفقرة بأكملها.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

يوضح مثال الشيفرة أدناه كيفية تعيين لون الخلفية **لأجزاء النص ذات الخط الغامق**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # تعيين لون التظليل لجزء النص.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![أجزاء النص الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة متمركزة، أو محاذية إلى اليسار، أو إلى اليمين، أو مبررة، وهكذا.

المثال التالي يوضح كيفية محاذاة الفقرة إلى **الوسط**:

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # تعيين محاذاة الفقرة إلى الوسط.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الفقرة المحاذاة للوسط](aligned_paragraph.png)

## **محاذاة الخطوط داخل السطر**

استخدم [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) لمحاذاة أجزاء النص ذات أحجام الخط المختلفة عموديًا داخل سطر. يطبق هذا الإعداد على الفقرة بأكملها ويتحكم في المحاذاة داخل كل سطر منها.

المثال التالي المستقل ينشئ أربعة مربعات نص مُسماة على شريحة واحدة. كل فقرة تحتوي على نفس النص بـ 18 و36 و54 نقطة، مع محاذاة خط مختلفة. يستخدم الخط Arial، ويعطل الملاءمة التلقائية واللف، ويُبقي إطارات النص كبيرة بما يكفي لسطر واحد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![مقارنة بين محاذاة القاعدة، العلو، الوسط، والسفل مع أحجام خط مختلطة](font_alignment.png)

تستخدم محاذاة الخط مقاييس الخط، لذا قد لا تتطابق حواف الحروف الفردية بالضبط. يتضمن المثال حرفًا كبيرًا وأحد الحروف السفلية لإظهار الفرق بين محاذاة القاعدة والسفل. تتأثر النتيجة بتوفر الخط واستبداله، والحروف المستخدمة، والفرق في أحجام الخط. كما تؤثر أبعاد الإطار وهوامش الفقرة وتباعد الأسطر واللف والملاءمة التلقائية على التخطيط؛ استخدم نفس الخطوط وإعدادات التخطيط عند مقارنة الأنماط.

هذا الإعداد يختلف عن [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) الذي يتحكم في المحاذاة الأفقية للفقرة، وعن [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) الذي يحدد موضع كتلة النص عموديًا داخل الشكل. تنسيق النص فوق والاسفل عبر [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) يزاحم أجزاء النص بالنسبة للقاعدة بدلاً من ضبط محاذاة الخط لسطر الفقرة.

## **تعيين الشفافية للنص**

تُتحكم شفافية النص من خلال مكوّن ألفا للون المعين إلى [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا ARGB على مقياس 0–255، وليس نسبة شفافية.

المثال التالي يوضح كيفية تطبيق الشفافية على **الفقرة بأكملها**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # تعيين لون تعبئة النص إلى لون شفاف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

المثال التالي يوضح كيفية تطبيق الشفافية على **أجزاء النص ذات الخط الغامق**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # تعيين شفافية جزء النص.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![أجزاء النص الشفافة](transparent_text_portions.png)

## **تعيين تباعد الأحرف للنص**

استخدم [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) لتوسيع أو تقليص التباعد بين الأحرف في مربع نص. تضيف الأمثلة 3 نقاط من التباعد؛ القيم السالبة تقرّب النص.

الكود التالي في Python يوضح كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # ملاحظة: استخدم القيم السالبة لضغط تباعد الأحرف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

المثال أدناه يوضح كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط الغامق**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # ملاحظة: استخدم القيم السالبة لضغط تباعد الأحرف.
            portion.getPortionFormat().setSpacing(3) # توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **تعطيل تزيين الأحرف للخطوط المحددة**

في بعض الحالات، قد يبدو النص المولد بواسطة Aspose.Slides أقرب قليلاً من النص نفسه المعروض في PowerPoint. يمكن أن يحدث ذلك لأن PowerPoint قد يتجاهل بيانات تزيين الأحرف لبعض الخطوط، حتى عندما يحتوي الخط على معلومات تزيين صالحة وتكون التزيين مفعّلة في إعدادات PowerPoint.

لجعل الناتج المولد أقرب إلى PowerPoint في مثل هذه الحالات، يمكنك تعطيل تزيين الأحرف لأجزاء النص التي تستخدم الخط المتأثر. اضبط [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) إلى قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال ملف "presentation.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى. يتحقق من أسماء الخطوط الفعالة، بما فيها الخطوط الموروثة، ويحدد عتبة 100 نقطة للأجزاء التي تستخدم Roboto. هذا يعطل التزيين للأجزاء المطابقة التي حجم خطها أقل من 100 نقطة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

بالنسبة للنص المطابق للعتبة، يمنع هذا الإعداد التزيين ويمكن أن يساعد في مواءمة عرض Aspose.Slides مع ناتج PowerPoint البصري للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) أو على الأجزاء الفردية عبر [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/).

المثال التالي يضبط الخط الافتراضي للفقرة الأولى إلى Times New Roman بحجم 12 نقطة مع تنسيق غامق ومائل وتسطير منقط. يسبق التنسيق الصريح للأجزاء الفردية هذه القيم الافتراضية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # تعيين خصائص الخط للفقرة.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![خصائص الخط للفقرة](font_properties_for_paragraph.png)

المثال التالي يطبق Times New Roman بحجم 13 نقطة، وتنسيق مائل، وتسطير منقط على الأجزاء التي تنسيقها الفعلي هو غامق:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # تعيين خصائص الخط لجزء النص.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![خصائص الخط لأجزاء النص](font_properties_for_text_portions.png)

## **التحكم في تطبيع ارتفاع النص**

استخدم [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) عند إعادة إنتاج طباعة القالب أو فحص الفروقات في ارتفاع الحرف. في PowerPoint، تمكين التطبيع يمدد أو يضغط الأحرف الفردية عموديًا لتمنحها ارتفاعًا مرئيًا موحدًا داخل جزء النص. لا يضمن ذلك تساوي ارتفاعات النص عبر خطوط مختلفة.

عيّن الخاصية إلى [NullableBool.True_ أو False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) لتمكين أو تعطيل التطبيع صراحة. `NullableBool.NotDefined` يترك الإعداد المحلي غير محدد بحيث يرث الجزء قيمته، مثلاً من [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) الخاص بالفقرة. لا يعني ذلك `False`. استخدم [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) واقرأ `getNormaliseHeight` على التنسيق الفعلي المسترجع للحصول على القيمة المنطقية المحسوبة.

المثال المستقل التالي يتطلب وجود **Arial** مثبتًا. يُنشئ كتلتين نصيتين يحتويان على نفس الحروف الكبيرة، والحروف الصغيرة، والحروف السفلية، والحروف ذات اللكنات بحجم 54 نقطة. تمكّن الفقرتان التطبيع افتراضيًا. الجزء العلوي يعطل التطبيع صراحةً؛ الجزء السفلي يرث الإعداد. أحجام الإطار، والهوامش، وتباعد الفقرات متماثلة، مع تعطيل اللف والملاءمة التلقائية للحفاظ على المقارنة ثابتة. يطبع المثال `False: False` و `NotDefined: True`، ثم يحفظ "text_height_normalization.pptx".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

المقارنة أدناه تم تصديرها من العرض المحفوظ. الصف العلوي يحتوي على تطبيع معطل (`False`)؛ الصف السفلي يرث الإعداد المفعّل (`NotDefined` → `True`). حافظ على تثبيت Arial لإعادة إنتاج هذا المظهر.

![نص Arial بحجم 54 نقطة مع إيقاف التطبيع أعلاه وتوريث التطبيع مفعَّل أدناه](text_height_normalization.png)

يغيّر التطبيع ارتفاع الحرف دون تعديل قيمة [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight) المعينة، التي تحدد حجم الخط بالنقاط. يتحكم [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) في تباعد الأسطر، بينما يتحكم [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) في كيفية تعديل النص أو حاويته ليتناسب. تخدم هذه الإعدادات أغراضًا مختلفة ويمكن أن تؤثر على التخطيط العام بشكل مستقل. لمزيد من المعلومات حول تنسيق الفقرات والوراثة، راجع [إدارة الفقرة](/slides/ar/python-java/manage-paragraph/).

## **تطبيق وإزالة الخط عبر النص**

استخدم [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) على جزء نص لتظهر تصحيحات أو مصطلحات ملغاة أو أسعار سابقة دون حذف النص الأصلي. اضبطه إلى [TextStrikethroughType.Single أو Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) للحصول على خط واحد أو مزدوج عبر النص.

لإزالة الخط عبر النص، مرّر [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None). هذا يعطل التأثير صراحةً حتى وإن كان التنسيق المحيط يحدد خطًا عبر النص. بالمقابل، يترك [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) الإعداد المحلي غير معرف، مما يسمح للجزء بوراثة التنسيق، مثلاً من الفقرة. لا يضمن ذلك إزالة الخط عبر. استخدم [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) لقراءة التنسيق الناتج، بما في ذلك القيم الموروثة.

المثال المستقل التالي ينشئ ثلاث مقارنات أسعار. كل فقرة لديها أجزاء منفصلة للعلامة، والسعر السابق، والسعر الحالي، لذا يتأثر السعر السابق فقط. الصف الأول يطبق ثم يزيل الخط عبر؛ الصفوف الأخرى تحتفظ بخط عبر واحد أو مزدوج. يضمن تغيير هذا الإعداد الحفاظ على النص وتنسيقه الآخر، بما في ذلك سمك السعر السابق.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # تطبيق خط عبر النص، ثم إزالته صراحةً من السعر السابق الأول.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة، من الأعلى إلى الأسفل: لا خط عبر، خط عبر واحد، وخط عبر مزدوج.

![الأسعار السابقة بدون خط عبر، بخط عبر واحد، وبخط عبر مزدوج](strikethrough.png)

## **تعيين دوران النص**

استخدم [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) لتعيين اتجاه نص محدد مسبقًا داخل الشكل.

المثال التالي يضبط اتجاه النص في الشكل إلى [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/)، والذي يدور النص **90 درجة عكس اتجاه عقرب الساعة**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![دوران النص](text_rotation.png)

## **تعيين دوران مخصص لإطارات النص**

استخدم [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) لتعيين زاوية دوران مخصصة لـ [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).

المثال التالي يدور إطار النص بمقدار 3 درجات باتجاه عقرب الساعة داخل الشكل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![دوران النص المخصص](custom_text_rotation.png)

## **تعيين تباعد الأسطر للفقرات**

توفر Aspose.Slides طرقًا مثل [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter)، [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore)، و[ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) للتحكم في تباعد الفقرات. تُستعمل هذه الخصائص كالتالي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

المثال التالي يضبط التباعد داخل الفقرة الأولى إلى 200٪ من ارتفاع السطر (تباعد مزدوج):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![تباعد السطر داخل الفقرة](line_spacing.png)

## **التحكم في كسر السطر**

قواعد كسر سطر الفقرة مفيدة في كتل النص الضيقة والعروض التي تمزج بين النص اللاتيني والآسيوي الشرقي. الطرق التالية تنتمي إلى [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/)، لذا فإنها تُطبق على الفقرة بأكملها:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) يتحكم في قواعد كسر السطر اللاتيني. في النص المختلط، قد يغير ذلك موضع كسر النص والرموز الترقيمية الآسيوية الشرقية المجاورة.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) يتحكم في قواعد كسر السطر الآسيوي الشرقي، بما في ذلك القيود على الأحرف في بداية ونهاية السطر.

هذه القواعد لا تحل محل [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText)، الذي يفعّل اللف التلقائي داخل إطار النص. هي تؤثر على التخطيط عندما يحدث اللف؛ لا تُدرج أحرف كسر السطر. كسر سطر صريح يُجبر سطرًا جديدًا داخل الفقرة بغض النظر عن العرض المتاح.

المثال المستقل التالي ينشئ كتلة نص ضيقة تحتوي على صيني ولاتيني. يضبط كلا خيارَي كسر السطر صراحةً ويحفظ "line_breaking.pptx". لتجربة أي قاعدة، غيّر القيمة المقابلة مع ترك الإعدادات الأخرى ثابتة. يستخدم المثال Arial بحجم 24 نقطة وSimSun مع عرض إطار 160 نقطة وهامش أفقي صفر. تُستدعى [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) مع [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) لتثبيت حجم النص وأبعاد الإطار.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **التحكم في علامات الترقيم المتدلية**

يتيح [ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) لعلامات الترقيم المؤهلة أن تمتد إلى ما وراء الحافة اليمنى لسطر النص بدلاً من أن تحتل السطر التالي. يطبق على الفقرة بأكملها ويختلف عن الإزاحة المتدلية.

المثال المستقل التالي يُفعّل علامات الترقيم المتدلية في إطار نص بعرض 100 نقطة ويحفظ "hanging_punctuation.pptx". مع Arial بحجم 24 نقطة وهامش أفقي صفري، يبقى النقطة النهائية بعد كلمة "sentence" وتمتد إلى ما وراء حافة النص اليمنى. اضبط الخاصية إلى [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) للمقارنة: بهذه الإعدادات، تشغل النقطة سطرًا منفصلًا. يُفعّل اللف ويُعطل الملاءمة التلقائية للحفاظ على العرض المتاح ثابتًا.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ليس كل علامة ترقيم يمكن أن تتدلى. تُطبق أيضًا [الظروف الخطية وتخطيطية المذكورة أعلاه](#control-line-breaking) على هذه المقارنة: تغيير الخط أو العرض المتاح أو الهوامش أو إعدادات الملاءمة يمكن أن يزيل الاختلاف المرئي.

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

يُحدّد [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) كيفية تصرف النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص يُصغر، أو يتجاوز، أو يُعيد تحجيم الشكل تلقائيًا. المثال التالي يضبط الشكل لإعادة التحجيم ليتناسب مع النص ويحفظ النتيجة إلى "autofit_type.pptx".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

لعد الأسطر بعد اللف التلقائي ورؤية كيفية تغير عرض النص أو الشكل، راجع [عد الأسطر المرسومة](/slides/ar/python-java/manage-paragraph/). عدد الأسطر وحده لا يدل على ما إذا كان النص يتجاوز حاويته.

## **تعيين مرساة إطارات النص**

يُعرّف [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) كيفية تموضع النص عموديًا داخل الشكل، مثلًا في الأعلى أو الوسط أو الأسفل. المثال التالي يرسخ النص إلى أسفل الشكل الأول ويحفظ النتيجة إلى "text_anchor.pptx".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين التبويب للنص**

استخدم [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) و[ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) لتكوين نقاط التبويب في الفقرة. المثال التالي يضبط الفاصل الافتراضي للتاب إلى 100 نقطة ويضيف تبويبًا محاذيًا لليسار عند 30 نقطة. تؤثر هذه الإعدادات على النص الذي يحتوي على أحرف تبويب.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![تبويبات الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId)، التي تسمح لك بتعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة لتصحيح الإملاء والقواعد في PowerPoint.

المثال التالي يتطلب "presentation.pptx" مع مربع نص كأول شكل في الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتوى الفقرة الأولى بـ "1。"، يعيّن SimSun كخط لها، ويُحدّد لغة التدقيق بالصينية المبسطة (`zh-CN`). يحفظ النتيجة إلى "proofing_language.pptx":

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # تعيين معرف لغة التدقيق.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **نسخ بيانات تعريف اللغة**

عند نسخ نص متعدد اللغات من قالب، احفظ كلًا من [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId) و[BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). المثال المستقل التالي ينشئ جزء مصدر بلغة الإنجليزية الأمريكية كلغتها و الفرنسية كلغتها البديلة، وينسخ النص والمعرفات إلى جزء في عرض تقديمي جديد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # إذا لم يكن للمصدر لغة بديلة، فإن None يمسح قيمة الوجهة.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

لتجربة مصدر بدون لغة بديلة، احذف تعيين `"fr-FR"`. يصبح المعرف البديل حينها `None`، ويحافظ بيان النسخ نفسه على غيابه دون إدخال قيمة افتراضية، حتى إذا كان الوجهة قد عيّن لغة بديلة مسبقًا.

تُخزن هذه المعرفات كبيانات تعريف اللغة. الحفاظ عليها لا يُحدّد أي قاموس سيختاره PowerPoint للتدقيق الإملائي أو القواعدي.

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) لتعريف اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي. المثال التالي ينشئ عرضًا بلغة إنجليزية أمريكية افتراضية للنص، يضيف مربع نص، ويطبع `en-US` لأول جزء نص فيه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل مستطيل يحتوي على نص.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # تحقق من لغة الجزء الأول.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض، استخدم [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle).

المثال التالي يضبط خطًا غامقًا بحجم 14 نقطة كافتراضي للفقرات العلوية المستوى في عرض تقديمي جديد ويحفظه إلى "default_text_style.pptx". يمكن للنص أن يرث هذه القيم الافتراضية ما لم يتجاوزها تنسيق أكثر تحديدًا.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # احصل على تنسيق الفقرة المستوى العلوي.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استخراج النص بتأثير الأحرف الكبيرة**

في PowerPoint، يؤدي تطبيق تأثير **All Caps** إلى ظهور النص بأحرف كبيرة على الشريحة حتى لو كُتب أصلاً بأحرف صغيرة. عند استرجاع جزء نص كهذا باستخدام Aspose.Slides، تُعيد المكتبة النص كما كُتب بالضبط. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) وحوّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

هذا المثال يتطلب "sample2.pptx" مع مربع نص كأول شكل في الشريحة الأولى. يحتوي الجزء الأول من الفقرة الأولى على "Hello, Aspose!" مع تطبيق تأثير All Caps، كما هو موضح أدناه.

![تأثير الأحرف الكبيرة](all_caps_effect.png)

المثال التالي يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

المخرجات:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة المتكررة**

**كيف يمكنني تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). استعرض الخلايا وحدّث كل خلية عبر [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) وتنسيق الفقرات عبر [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat).

**كيف يمكنني تطبيق لون متدرج للنص على شريحة PowerPoint؟**

لتطبيق لون متدرج على النص، استخدم [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). عيّن [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) إلى [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) واضبط نقاط التدرج والاتجاه والشفافية.