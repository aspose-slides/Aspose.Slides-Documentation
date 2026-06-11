---
title: Animacja
type: docs
weight: 100
url: /pl/python-net/examples/elements/animation/
keywords:
- animacja
- dodaj animację
- uzyskaj dostęp do animacji
- usuń animację
- sekwencja animacji
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Opanuj animacje slajdów w Pythonie z Aspose.Slides: dodawaj, edytuj i usuwaj efekty, czasy oraz wyzwalacze, aby tworzyć dynamiczne prezentacje w formatach PPT, PPTX i ODP."
---
Pokazuje, jak tworzyć proste animacje i zarządzać ich kolejnością przy użyciu **Aspose.Slides for Python via .NET**.

## **Dodaj animację**

Utwórz prostokątny kształt i zastosuj efekt zanikania wyzwalany po kliknięciu.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Dodaj efekt zanikania.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Uzyskaj dostęp do animacji**

Pobierz pierwszy efekt animacji z osi czasu slajdu.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Uzyskaj dostęp do pierwszego efektu animacji.
        effect = slide.timeline.main_sequence[0]
```

## **Usuń animację**

Usuń efekt animacji z kolejności.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że główna sekwencja zawiera przynajmniej jeden efekt.
        effect = slide.timeline.main_sequence[0]

        # Usuń efekt.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sekwencja animacji**

Dodaj wiele efektów i pokaż kolejność, w jakiej występują animacje.

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