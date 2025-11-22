---
title: Анимация текста PowerPoint в Python
linktitle: Анимированный текст
type: docs
weight: 60
url: /ru/python-net/animated-text/
keywords:
- анимированный текст
- анимация текста
- анимированный абзац
- анимация абзаца
- эффект анимации
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создайте динамический анимированный текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python через .NET, используя простые для понимания, оптимизированные примеры кода."
---

## **Обзор**

В этой статье показано, как анимировать текст в презентациях PowerPoint с помощью Aspose.Slides for Python. Вы узнаете, как добавлять эффекты к отдельным абзацам, настраивать триггеры и считывать существующие последовательности анимации. В конце вы сможете создавать переиспользуемые рабочие процессы анимации текста, которые экспортируются в стандартный PPTX и корректно воспроизводятся в PowerPoint.

## **Добавление анимационных эффектов к абзацу**

Метод [add_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/add_effect/) класса [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) позволяет применить анимационный эффект к отдельному абзацу. Пример кода ниже демонстрирует, как это сделать:
```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # Выберите абзац, к которому нужно добавить эффект.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Добавьте эффект анимации Fly к выбранному абзацу.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```


## **Получение анимационных эффектов абзаца**

Возможно, вам потребуется определить, какие анимационные эффекты применены к абзацу, например, если вы планируете скопировать эти эффекты в другой абзац или форму.

Aspose.Slides for Python позволяет получить все анимационные эффекты, применённые к абзацам в текстовом фрейме (форме). Пример кода ниже показывает, как получить анимационные эффекты абзаца:
```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```


## **FAQ**

**Чем анимация текста отличается от переходов слайдов, и можно ли их комбинировать?**

Анимация текста управляет поведением объектов во времени на слайде, тогда как [transitions](/slides/ru/python-net/slide-transition/) управляют переходом между слайдами. Они независимы и могут использоваться вместе; порядок воспроизведения определяется временной шкалой анимации и настройками перехода.

**Сохраняются ли анимации текста при экспорте в PDF или изображения?**

Нет. PDF и растровые изображения являются статичными, поэтому вы увидите единственное состояние слайда без движения. Чтобы сохранить анимацию, используйте экспорт в [video](/slides/ru/python-net/convert-powerpoint-to-video/) или [HTML](/slides/ru/python-net/export-to-html5/).

**Работают ли анимации текста в шаблонах и мастер‑слайде?**

Эффекты, применённые к объектам шаблона/мастера, наследуются слайдами, но их временные параметры и взаимодействие с анимациями уровня слайда зависят от конечной последовательности на слайде.