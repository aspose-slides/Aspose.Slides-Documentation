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
- تثبيت إطار النص
- جدولة النص
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

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر Java. تغطي الألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، مسافات التبويب، وإعدادات اللغة.

في الأمثلة أدناه، سنستخدم ملفًا يُدعى "sample.pptx"، يحتوي على مربع نص واحد في الشريحة الأولى بالنص التالي:

![نص مثال](sample_text.png)

للعثور على نص حرفي أو مطابقة تعبيرات منتظمة وتظليلها، راجع [Search and Replace Text](/slides/ar/python-java/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) لتحديد لون التظليل الافتراضي لفقرة، أو استخدم [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/) لأجزاء النص الفردية.

يظهر مثال الشيفرة التالي كيفية تعيين لون الخلفية **للفقرة كاملة**:

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

    # تعيين لون التحديد للفقرة بأكملها.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

يوضح مثال الشيفرة أدناه كيفية تعيين لون الخلفية **لأجزاء النص ذات الخط العريض**:

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
            # تعيين لون التحديد لجزء النص.
    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![أجزاء النص الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setAlignment) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيم متمركزة، محاذاة إلى اليسار، محاذاة إلى اليمين، مبررة، وما إلى ذلك.

يظهر مثال الشيفرة التالي كيفية محاذاة الفقرة إلى **الوسط**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # تعيين محاذاة الفقرة إلى المركز.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الفقرة المحاذاة](aligned_paragraph.png)

## **تعيين شفافية النص**

تُتحكم شفافية النص عبر مكوّن ألفا للون المعين إلى [PortionFormat.getFillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا ARGB على مقياس 0–255، وليس نسبة شفافية.

يوضح مثال الشيفرة التالي كيفية تطبيق الشفافية على **الفقرة كاملة**:

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

    # تعيين لون ملء النص إلى لون شفاف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

يظهر مثال الشيفرة التالي كيفية تطبيق الشفافية على **أجزاء النص ذات الخط العريض**:

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

استخدم [PortionFormat.setSpacing](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/) لتوسيع أو تضييق التباعد بين الأحرف في مربع النص.

يظهر الكود التالي في Python كيفية توسيع تباعد الأحرف في **الفقرة كاملة**:

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # ملاحظة: استخدم قيمًا سالبة لضغط تباعد الأحرف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

يوضح مثال الشيفرة أدناه كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط العريض**:

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
            # ملاحظة: استخدم قيمًا سالبة لضغط تباعد الأحرف.
            portion.getPortionFormat().setSpacing(3) # توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **إلغاء تشغيل Kerning لخطوط معينة**

في بعض الحالات، قد يبدو النص الذي تُعيد Aspose.Slides تقديمه أكثر ضغطًا قليلاً مقارنةً بنفس النص المعروض في PowerPoint. يمكن أن يحدث هذا لأن PowerPoint قد يتجاهل بيانات kerning لبعض الخطوط، حتى عندما يحتوي الخط على معلومات kerning صالحة ويتم تمكين kerning في إعدادات PowerPoint.

لجعل الإخراج المُعاد إنتاجه أقرب إلى PowerPoint في هذه الحالات، يمكنك إلغاء تشغيل kerning لأجزاء النص التي تستخدم الخط المتأثر. اضبط [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/) إلى قيمة أكبر بكثير من حجم الخط الفعلي:

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
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يمنع هذا الإعداد تطبيق kerning على أجزاء النص المطابقة ويمكن أن يساعد في محاذاة عرض Aspose.Slides مع الإخراج البصري لـ PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة من خلال [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) أو على أجزاء فردية عبر [PortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/).

يحدد الكود التالي الخط ونمط النص للفقرة كاملة: يطبق حجم الخط، العريض، المائل، خط سفلي منقط، وخط Times New Roman على جميع الأجزاء في الفقرة.

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

يوضح مثال الشيفرة أدناه تطبيق خصائص مشابهة على **أجزاء النص ذات الخط العريض**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

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

## **تعيين دوران النص**

استخدم [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setTextVerticalType) لتعيين توجيه نص مسبق التعريف داخل الشكل.

يحدد مثال الشيفرة التالي توجيه النص في الشكل إلى `Vertical270`، مما يدور النص **90 درجة عكس اتجاه عقارب الساعة**:

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

استخدم [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setRotationAngle) لتعيين زاوية دوران مخصصة لـ [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/).

يدور مثال الشيفرة أدناه إطار النص بمقدار 3 درجات باتجاه عقارب الساعة داخل الشكل:

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

![الدوران المخصص للنص](custom_text_rotation.png)

## **تعيين تباعد السطر للفقرات**

توفر Aspose.Slides [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setSpaceAfter)، [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setSpaceBefore)، و[ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setSpaceWithin) للتحكم في تباعد الفقرة. تُستخدم هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

يُظهر مثال الشيفرة التالي كيفية تحديد تباعد السطر داخل الفقرة:

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

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setAutofitType) يحدد كيفية تصرف النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص سيصغر، سيتجاوز، أو سيعيد تحجيم الشكل تلقائيًا.

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

## **تعيين تثبيت إطارات النص**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setAnchoringType) يحدد كيفية تموضع النص عموديًا داخل الشكل، مثل أعلى، وسط، أو أسفل.

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

## **تعيين جدولة تبويب النص**

استخدم [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) و[ParagraphFormat.getTabs](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#getTabs) لتكوين نقاط التبويب في الفقرة.

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

توفر Aspose.Slides [PortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/) التي تسمح لك بتعيين لغة التدقيق لجزء نصي. تحدد لغة التدقيق اللغة المستخدمة لتصحيح الإملاء والقواعد في PowerPoint.

يُظهر مثال الشيفرة التالي كيفية تعيين لغة التدقيق لجزء نصي:

```python
import jpide
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

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) لتحديد اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي.

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

    # إضافة شكل مستطيل مع نص.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # تحقق من لغة الجزء الأول.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getDefaultTextStyle).

يُظهر مثال الشيفرة التالي كيفية تعيين خط عريض بحجم 14 نقطة كنص افتراضي لجميع النصوص عبر الشرائح في عرض تقديمي جديد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # الحصول على تنسيق الفقرة المستوى الأعلى.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استخراج النص بتأثير الحروف الكبيرة كلها**

في PowerPoint، يؤدي تطبيق تأثير الخط **All Caps** إلى ظهور النص بأحرف كبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textcaptype/) وحوّل السلسلة المرجعية إلى أحرف كبيرة عندما تكون القيمة `All`.

لنفترض أن لدينا مربع النص التالي في الشريحة الأولى من ملف sample2.pptx.

![تأثير الحروف الكبيرة كلها](all_caps_effect.png)

يوضح مثال الشيفرة التالي كيفية استخراج النص مع تطبيق تأثير **All Caps**:

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

الإخراج:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة الشائعة**

**كيف يمكنني تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/). قم بالتكرار عبر الخلايا وحدث كل خلية عبر [Cell.getTextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cell/#getTextFrame) وتنسيق الفقرة عبر [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/#getParagraphFormat).

**كيف يمكنني تطبيق لون تدرج على النص في شريحة PowerPoint؟**

لتطبيق لون تدرج على النص، استخدم [PortionFormat.getFillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/). اضبط [FillFormat.setFillType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/#setFillType) إلى [FillType.Gradient](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filltype/#Gradient) و تكوين نقاط التدرج، الاتجاه، والشفافية.