---
title: Animação
type: docs
weight: 100
url: /pt/python-net/examples/elements/animation/
keywords:
- animação
- adicionar animação
- acessar animação
- remover animação
- sequência de animação
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Domine animações de slide em Python com Aspose.Slides: adicione, edite e remova efeitos, temporizações e gatilhos para criar apresentações dinâmicas em PPT, PPTX e ODP."
---
Mostra como criar animações simples e gerenciar sua sequência usando **Aspose.Slides for Python via .NET**.

## **Adicionar uma Animação**

Crie uma forma retangular e aplique um efeito de fade acionado ao clicar.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Adicionar um efeito de fade.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar uma Animação**

Recupere o primeiro efeito de animação da linha do tempo do slide.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Acessar o primeiro efeito de animação.
        effect = slide.timeline.main_sequence[0]
```

## **Remover uma Animação**

Remova um efeito de animação da sequência.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Pressupondo que a sequência principal contenha ao menos um efeito.
        effect = slide.timeline.main_sequence[0]

        # Remover o efeito.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sequenciar Animações**

Adicione vários efeitos e demonstre a ordem em que as animações ocorrem.

```py
def sequence_animations():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 200, 50, 100, 100)

        sequence = slide.timeline.main_sequence
        sequence.add_effect(
            shape1,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)
        sequence.add_effect(
            shape2,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation_sequence.pptx", slides.export.SaveFormat.PPTX)
```