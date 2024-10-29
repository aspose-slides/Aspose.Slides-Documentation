---
title: Анимированный текст
type: docs
weight: 60
url: /ru/python-net/animated-text/
keywords: "Анимированный текст, Эффекты анимации, Презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Добавьте анимированный текст и эффекты в презентацию PowerPoint на Python"
---

## Добавление эффектов анимации к абзацам

Мы добавили метод [**add_effect()**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) в классы [**Sequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) и [**ISequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/isequence/). Этот метод позволяет добавлять эффекты анимации к одному абзацу. Этот пример кода показывает, как добавить эффект анимации к одному абзацу:

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as presentation:
    # выберите абзац для добавления эффекта
    autoShape = presentation.slides[0].shapes[0]
    paragraph = autoShape.text_frame.paragraphs[0]

    # добавьте эффект анимации "Вылет" к выбранному абзацу
    effect = presentation.slides[0].timeline.main_sequence.add_effect(paragraph, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.LEFT, slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("AnimationEffectinParagraph.pptx", slides.export.SaveFormat.PPTX)
```



## Получение эффектов анимации в абзацах

Вы можете решить узнать, какие эффекты анимации добавлены к абзацу — например, в одном сценарии вы хотите получить эффекты анимации в абзаце, потому что планируете применить эти эффекты к другому абзацу или форме.

Aspose.Slides для Python через .NET позволяет вам получить все эффекты анимации, примененные к абзацам, содержащимся в текстовом кадре (форме). Этот пример кода показывает, как получить эффекты анимации в абзаце:

```py
import aspose.slides as slides

with slides.Presentation("AnimationEffectinParagraph.pptx") as pres:
    sequence = pres.slides[0].timeline.main_sequence
    autoShape = pres.slides[0].shapes[0]
    for paragraph in autoShape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print("Абзац \"" + paragraph.text + "\" имеет эффект " + str(effects[0].type) + ".")
```