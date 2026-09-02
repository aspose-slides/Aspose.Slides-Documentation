---
title: أتمتة تعريب العروض التقديمية باستخدام بايثون
linktitle: تعريب العروض التقديمية
type: docs
weight: 100
url: /ar/python-net/presentation-localization/
keywords:
- تغيير اللغة
- تدقيق إملائي
- كتم التدقيق الإملائي
- لغة المراجعة
- معرف اللغة
- نص متعدد اللغات
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "ضبط لغات المراجعة لنص عرض PowerPoint وعرض OpenDocument باستخدام بايثون مع Aspose.Slides، بما في ذلك الإعدادات الافتراضية والفقرات متعددة اللغات."
---
## **نظرة عامة**

يسمح Aspose.Slides for Python via .NET لك بإعداد بيانات التعريف الخاصة بالمراجعة للجزء النصي الفردي. استخدم [BasePortionFormat.language_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/language_id/) لتحديد لغة المراجعة، و[BasePortionFormat.spell_check](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/spell_check/) للسماح أو كتم فحص الإملاء، و[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/proof_disabled/) للتحكم في حالة عدم المراجعة العامة. نظرًا لتطبيق هذه الإعدادات على مستوى الجزء، يمكن لفقرة واحدة أن تحتوي على لغات متعددة وقواعد مراجعة مختلفة.

تشرح هذه المقالة كيفية تعيين لغة لنص معين، وتحديد اللغة الافتراضية للنص الجديد عبر [LoadOptions.default_text_language](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/default_text_language/)، وإنشاء فقرات متعددة اللغات، والاختيار بين `spell_check` و `proof_disabled`، والحفاظ على الإعدادات المقصودة عند استخدام [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/join_portions_with_same_formatting/). تُخزن هذه الخصائص بيانات التعريف لتطبيقات العروض التقديمية؛ فهي لا تُترجم النص، ولا تُجري فحص إملائي قائم على القاموس، ولا تُعيد الكلمات غير الصحيحة.

## **تعيين لغة المراجعة للنص**

أنشئ أو حمّل [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/)، وعرّف الجزء النصي المطلوب عبر [Portion.portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/portion_format/)، ثم عيّن مُعرّف اللغة الخاص به. المثال التالي يُنشئ شكلاً، ويضبط اللغة البريطانية كلغة مراجعة، ويحفظ النتيجة عبر [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **تحديد اللغة الافتراضية للنص الجديد**

استخدم [LoadOptions.default_text_language](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/default_text_language/) لتحديد لغة المراجعة التي يضيفها Aspose.Slides إلى النص المُنشأ حديثًا. يكون هذا الإعداد مفيدًا عندما يستخدم معظم أو كل النص الجديد في العرض اللغة نفسها. لا يغيّر هذا الإعداد بيانات تعريف اللغة للنص الذي يمتلك لغة صريحة مسبقًا.

المثال التالي يُنشئ عرضًا تقديميًا يكون فيه النص الجديد وفق قواعد اللغة الألمانية:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **استخدام لغات متعددة في فقرة واحدة**

تحتوي [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) على مجموعة من أجزاء النص. أنشئ [Portion](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/) منفصل لكل لغة واضبط خاصية `language_id` الخاصة به بصورة مستقلة.

هذا المثال يُنشئ فقرة واحدة تحتوي على أجزاء بالإنجليزية والفرنسية:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **تمكين أو كتم فحص الإملاء للأجزاء الفردية**

ترث [PortionFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/) الخصائص النصية العامة المحددة بواسطة [BasePortionFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/). احصل على تنسيق الجزء عبر [Portion.portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/portion_format/) واضبط [BasePortionFormat.spell_check](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/spell_check/) للتحكم فيما إذا كان تطبيق العرض قد يتحقق من إملاء ذلك الجزء. القيمة الافتراضية هي `False`: `True` يسمح بفحص الإملاء، بينما `False` يكتمه.

يُطبق هذا الإعداد على أجزاء النص الفردية. لذلك يمكن لأجزاء مختلفة ضمن الفقرة ذاتها أن تستخدم قيمًا مختلفة. تُعد كل من [BasePortionFormat.language_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/language_id/) و `spell_check` مكملة لبعضها: تُحدد `language_id` لغة المراجعة، بينما تحدد `spell_check` ما إذا كان يُسمح بفحص الإملاء للجزء.

كما يتحكم [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/proof_disabled/) في المراجعة، لكنه يُعبّر عن حالة "عدم المراجعة" الأوسع كـ [NullableBool](https://reference.aspose.com/slides/ar/python-net/aspose.slides/nullablebool/). استخدم `spell_check` عندما تحتاج إلى مفتاح منطقي مباشر لفحص الإملاء. استخدم `proof_disabled` عندما تحتاج إلى حفظ أو التحكم صراحة في بيانات عدم المراجعة للعرض، بما في ذلك حالتها `NOT_DEFINED`. إذا قمت بتعيين الخصيصتين معًا، احرص على جعل القيم متسقة؛ لا تُدمج `spell_check = True` مع `proof_disabled = slides.NullableBool.TRUE`.

تُكوّن هذه الخصائص بيانات التعريف الخاصة بالمراجعة التي تستخدمها PowerPoint وتطبيقات العروض الأخرى. لا يستخدم Aspose.Slides هذه الخصائص لتشغيل فحص إملائي قائم على القاموس أو لإرجاع قائمة بالكلمات الخاطئة.

المثال الكامل التالي يُنشئ عرضًا إدخاليًا، يحمّله، يُعيّن إعدادات فحص إملائي ولغات مراجعة مختلفة لجزأين في الفقرة نفسها، يحفظ النتيجة، يفتحها مرة أخرى، ويتحقق من القيم المخزنة:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) يجمع الأجزاء المتجاورة التي لها نفس التنسيق. اختلاف `spell_check` وحده لا يكفي للحفاظ على فصلاً بين هذه الأجزاء؛ بعد دمجها، يحتفظ الجزء الناتج بقيمة `spell_check` للجزء الأول. إذا احتاجت الأجزاء إلى إعدادات فحص إملائي مختلفة، استدعِ `join_portions_with_same_formatting` قبل تعيين تلك الإعدادات، أو تفقد حدود الجزء الناتج وأعد تطبيق الإعدادات لاحقًا. تبقى الأجزاء ذات قيم `language_id` مختلفة منفصلة لأن تنسيق لغة المراجعة يختلف بينها.

## **الأسئلة الشائعة**

**هل يترجم مُعرّف اللغة النص؟**

لا. [BasePortionFormat.language_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/language_id/) يخزن بيانات تعريف المراجعة للإملاء والقواعد؛ لا يغيّر محتوى النص. قم بترجمة النص منفصلًا، ثم عيّن مُعرّف اللغة المناسب لكل جزء مترجم.

**هل تتحكم لغة المراجعة في الخطوط أو الفواصل أو تغليف السطر؟**

لا. مُعرّف اللغة يخص المراجعة فقط. يعتمد عرض النص وتنسيقه أساسًا على [الخطوط](/slides/ar/python-net/powerpoint-fonts/) المتاحة، ونظام الكتابة، وإعدادات إطار النص. لضمان عرض موثوق، قدّم الخطوط المطلوبة، واضبط [استبدال الخطوط](/slides/ar/python-net/font-substitution/)، أو [ضمن الخطوط](/slides/ar/python-net/embedded-font/) في العرض.

**هل يمكن لفقرة واحدة استخدام عدة لغات مراجعة؟**

نعم. عيّن كل لغة إلى جزء منفصل، كما هو موضح في مثال الفقرة متعددة اللغات.

**هل يجب استخدام `default_text_language` أم `language_id`؟**

استخدم [LoadOptions.default_text_language](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/default_text_language/) عندما تريد قيمة افتراضية للنص المُنشأ حديثًا. استخدم [BasePortionFormat.language_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/language_id/) عندما يحتاج جزء محدد إلى لغة مراجعة صريحة أو عندما تحتوي الفقرة على لغات متعددة.