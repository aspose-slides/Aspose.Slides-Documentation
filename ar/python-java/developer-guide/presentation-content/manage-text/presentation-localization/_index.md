---
title: أتمتة توطين العروض التقديمية في بايثون عبر جافا
linktitle: توطين العروض التقديمية
type: docs
weight: 100
url: /ar/python-java/presentation-localization/
keywords:
- تغيير اللغة
- فحص الإملاء
- كتم فحص الإملاء
- لغة المراجعة
- معرف اللغة
- نص متعدد اللغات
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعيين لغات المراجعة لنصوص العروض التقديمية PowerPoint وOpenDocument في بايثون عبر جافا باستخدام Aspose.Slides، بما في ذلك الإعدادات الافتراضية والفقرات متعددة اللغات."
---
## **نظرة عامة**

Aspose.Slides for Python via Java يتيح لك تكوين بيانات تعريف المراجعة لأجزاء النص الفردية. استخدم [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setLanguageId) لتحديد لغة المراجعة، و[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setSpellCheck) للسماح بفحص الإملاء أو كتمه، و[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setProofDisabled) للتحكم في حالة عدم المراجعة العامة. بما أن هذه الإعدادات تُطبق على مستوى الجزء، يمكن لفقرة واحدة أن تحتوي على لغات متعددة وقواعد مراجعة مختلفة.

توضح هذه المقالة كيفية تعيين لغة لنص محدد، وتحديد اللغة الافتراضية للنص الجديد باستخدام [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage)، وبناء فقرات متعددة اللغات، واختيار بين [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setSpellCheck) و[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setProofDisabled)، والحفاظ على الإعدادات المقصودة عند استخدام [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). هذه الخصائص تخزن بيانات تعريف للمراجعة لتطبيقات العروض التقديمية؛ ولا تقوم بترجمة النص أو إجراء فحص إملائي معتمد على القاموس أو إرجاع الكلمات المخطئة.

## **تعيين لغة المراجعة للنص**

أنشئ أو حمل [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/)، واطّلع على جزء النص المطلوب عبر [Portion.getPortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#getPortionFormat)، ثم عيّن معرف اللغة الخاص به. المثال التالي يُنشئ شكلاً، ويحدد اللغة الإنجليزية البريطانية كلغة مراجعة، ويحفظ النتيجة باستخدام [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تحديد اللغة الافتراضية للنص الجديد**

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) لتحديد لغة المراجعة التي يطبقها Aspose.Slides على النص المُنشأ حديثًا. هذا الإعداد مفيد عندما يستخدم معظم أو كل النص الجديد في العرض نفس اللغة. لا يغيّر بيانات تعريف اللغة للنص الذي لديه بالفعل لغة صريحة.

المثال التالي يُنشئ عرضًا يكون فيه النص الجديد يستخدم قواعد المراجعة الألمانية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استخدام لغات متعددة في فقرة واحدة**

[Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) يحتوي على مجموعة من أجزاء النص. أنشئ [Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/) منفصلة لكل لغة واضبط [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setLanguageId) لكل منها بشكل مستقل.

هذا المثال يُنشئ فقرة واحدة تحتوي على أجزاء إنجليزية وفرنسية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تمكين أو كتم فحص الإملاء لأجزاء محددة**

[PortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/) يرث خصائص النص العامة المعرفة في [BasePortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/). احصل على تنسيق الجزء عبر [Portion.getPortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#getPortionFormat) واستخدم [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setSpellCheck) للتحكم فيما إذا كان تطبيق العرض قد يتحقق من الإملاء لهذا الجزء. القيمة الافتراضية هي `False`: `True` يسمح بفحص الإملاء، بينما `False` يكتمه.

ينطبق الإعداد على أجزاء النص الفردية. لذلك يمكن لأجزاء مختلفة في نفس الفقرة استخدام قيم مختلفة. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setLanguageId) و[setSpellCheck](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setSpellCheck) يخدمان أغراضًا مكملة: الأول يحدد لغة المراجعة، والثاني يحدد ما إذا كان فحص الإملاء مسموحًا به لهذا الجزء.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setProofDisabled) يتحكم أيضًا في المراجعة، لكنه يمثل حالة "عدم المراجعة" الأوسع كـ [NullableBool](https://reference.aspose.com/slides/ar/python-java/aspose.slides/nullablebool/). استخدم [setSpellCheck](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setSpellCheck) عندما تحتاج إلى مقنع منطقي مباشر لفحص الإملاء. استخدم [setProofDisabled](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setProofDisabled) عندما تحتاج إلى الحفاظ على أو التحكم صراحةً في بيانات "عدم المراجعة" للعرض، بما في ذلك حالتها [NullableBool.NotDefined](https://reference.aspose.com/slides/ar/python-java/aspose.slides/nullablebool/#NotDefined). إذا قمت بتعيين الخاصيتين، احرص على تناسق قيمهما؛ لا تجمع بين [setSpellCheck](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setSpellCheck) مضبوطًا على `True` و[setProofDisabled](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setProofDisabled) مضبوطًا على حالة [NullableBool.True](https://reference.aspose.com/slides/ar/python-java/aspose.slides/nullablebool/#True).

هذه الخصائص تُكوّن بيانات تعريف المراجعة المستخدمة من قبل PowerPoint وتطبيقات العروض الأخرى. لا يستخدمها Aspose.Slides لتشغيل فحص إملائي معتمد على القاموس أو لإرجاع قائمة بالكلمات المخطئة.

المثال الكامل التالي يُنشئ عرضًا إدخاليًا، يحملّه، يعيّن إعدادات فحص إملائي ولغات مراجعة مختلفة لجزأين في نفس الفقرة، يحفظ النتيجة، يعيد فتحها، ويتحقق من القيم المخزنة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) يجمع الأجزاء المتجاورة التي لها نفس التنسيق. اختلاف في [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setSpellCheck) وحده لا يبقي هذه الأجزاء منفصلة؛ بعد دمجها، يحتفظ الجزء الناتج بقيمة [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setSpellCheck) للجزء الأول. إذا احتاجت الأجزاء إعدادات فحص إملائي مختلفة، استدعِ [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) قبل تعيين هذه الإعدادات، أو افحص حدود الجزء الناتج وأعد تطبيق الإعدادات لاحقًا. تبقى الأجزاء التي لها قيم مختلفة في [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setLanguageId) منفصلة لأن تنسيق لغة المراجعة يختلف بينها.

## **الأسئلة الشائعة**

**هل يترجم معرف اللغة النص؟**

لا. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setLanguageId) يخزن بيانات تعريف للمراجعة للإملاء والقواعد؛ ولا يغيّر محتوى النص. ترجّم النص منفصلًا، ثم عيّن المعرف اللغوي المناسب لكل جزء مترجم.

**هل تتحكم لغة المراجعة في الخطوط أو التجزيء أو التفاف السطر؟**

لا. المعرف اللغوي مخصص للمراجعة. يعتمد عرض النص وتخطيطه أساسًا على الخطوط المتوفرة [الخطوط](/slides/ar/python-java/powerpoint-fonts/)، ونظام الكتابة، وإعدادات إطار النص. لضمان عرض موثوق، قدّم الخطوط المطلوبة، واضبط [استبدال الخط](/slides/ar/python-java/font-substitution/)، أو [ضمن الخطوط](/slides/ar/python-java/embedded-font/) في العرض.

**هل يمكن لفقرة واحدة أن تستخدم عدة لغات مراجعة؟**

نعم. عيّن كل لغة إلى جزء منفصل، كما هو موضح في مثال الفقرة متعددة اللغات.

**هل يجب أن أستخدم [setDefaultTextLanguage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) أم [setLanguageId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setLanguageId)؟**

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) عندما تريد قيمة افتراضية للنص الذي يُنشأ حديثًا. استخدم [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setLanguageId) عندما يحتاج جزء محدد إلى لغة مراجعة صريحة أو عندما تحتوي الفقرة على لغات متعددة.