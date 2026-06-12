---
title: TransizioneDiapositiva
type: docs
weight: 110
url: /it/python-net/examples/elements/slide-transition/
keywords:
- transizione diapositiva
- aggiungi transizione diapositiva
- accedi transizione diapositiva
- rimuovi transizione diapositiva
- durata transizione
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Controlla le transizioni delle diapositive in Python con Aspose.Slides: scegli tipi, velocità, suono e tempi per perfezionare le presentazioni in PPT, PPTX e ODP."
---
Dimostra l'applicazione di effetti di transizione delle diapositive e dei tempi con **Aspose.Slides for Python via .NET**.

## **Aggiungi una transizione alla diapositiva**

Applica un effetto di transizione di dissolvenza alla prima diapositiva.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Applica una transizione di dissolvenza.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi a una transizione della diapositiva**

Leggi il tipo di transizione attualmente assegnato a una diapositiva.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Accedi al tipo di transizione.
        transition_type = slide.slide_show_transition.type
```

## **Rimuovi una transizione della diapositiva**

Cancella qualsiasi effetto di transizione impostando il tipo su `NONE`.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Rimuovi la transizione impostando NONE.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la durata della transizione**

Specifica per quanto tempo la diapositiva viene visualizzata prima di avanzare automaticamente.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # in millisecondi.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```