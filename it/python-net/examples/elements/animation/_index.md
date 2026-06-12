---
title: Animazione
type: docs
weight: 100
url: /it/python-net/examples/elements/animation/
keywords:
- animazione
- aggiungi animazione
- accedi animazione
- rimuovi animazione
- sequenza animazione
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci le animazioni delle diapositive in Python con Aspose.Slides: aggiungi, modifica e rimuovi effetti, tempistiche e trigger per creare presentazioni dinamiche in PPT, PPTX e ODP."
---
Mostra come creare animazioni semplici e gestire la loro sequenza utilizzando **Aspose.Slides for Python via .NET**.

## **Aggiungi un'animazione**

Crea una forma rettangolare e applica un effetto dissolvenza attivato al clic.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Aggiungi un effetto di dissolvenza.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi a un'animazione**

Recupera il primo effetto di animazione dalla timeline della diapositiva.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Accedi al primo effetto di animazione.
        effect = slide.timeline.main_sequence[0]
```

## **Rimuovi un'animazione**

Rimuovi un effetto di animazione dalla sequenza.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la sequenza principale contenga almeno un effetto.
        effect = slide.timeline.main_sequence[0]

        # Rimuovi l'effetto.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sequenza di animazioni**

Aggiungi più effetti e dimostra l'ordine in cui avvengono le animazioni.

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