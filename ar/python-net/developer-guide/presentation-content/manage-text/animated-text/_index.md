---
title: نص متحرك
type: docs
weight: 60
url: /python-net/animated-text/
keywords: "نص متحرك، تأثيرات الرسوم المتحركة، عرض باوربوينت، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "إضافة نصوص متحركة وتأثيرات إلى عرض باوربوينت في بايثون"
---

## إضافة تأثيرات الرسوم المتحركة إلى الفقرات

لقد أضفنا طريقة [**add_effect()**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) إلى فئات [**Sequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) و[**ISequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/isequence/). تتيح لك هذه الطريقة إضافة تأثيرات الرسوم المتحركة إلى فقرة واحدة. يظهر لك هذا الرمز المثال كيفية إضافة تأثير الرسوم المتحركة إلى فقرة واحدة:

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as presentation:
    # حدد الفقرة لإضافة التأثير
    autoShape = presentation.slides[0].shapes[0]
    paragraph = autoShape.text_frame.paragraphs[0]

    # أضف تأثير الرسوم المتحركة Fly إلى الفقرة المحددة
    effect = presentation.slides[0].timeline.main_sequence.add_effect(paragraph, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.LEFT, slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("AnimationEffectinParagraph.pptx", slides.export.SaveFormat.PPTX)
```



## الحصول على تأثيرات الرسوم المتحركة في الفقرات

قد تقرر معرفة تأثيرات الرسوم المتحركة المضافة إلى فقرة - على سبيل المثال، في سيناريو معين، ترغب في الحصول على تأثيرات الرسوم المتحركة في فقرة لأنك تخطط لتطبيق تلك التأثيرات على فقرة أو شكل آخر.

تتيح لك Aspose.Slides لـ بايثون عبر .NET الحصول على جميع تأثيرات الرسوم المتحركة المطبقة على الفقرات المحتواة في إطار نص (شكل). يظهر لك هذا الرمز المثال كيفية الحصول على تأثيرات الرسوم المتحركة في فقرة:

```py
import aspose.slides as slides

with slides.Presentation("AnimationEffectinParagraph.pptx") as pres:
    sequence = pres.slides[0].timeline.main_sequence
    autoShape = pres.slides[0].shapes[0]
    for paragraph in autoShape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print("الفقرة \"" + paragraph.text + "\" تحتوي على تأثير من نوع " + str(effects[0].type) + ".")
```