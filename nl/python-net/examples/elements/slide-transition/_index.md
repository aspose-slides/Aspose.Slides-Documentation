---
title: Diaovergang
type: docs
weight: 110
url: /nl/python-net/examples/elements/slide-transition/
keywords:
- diaovergang
- diaovergang toevoegen
- diaovergang benaderen
- diaovergang verwijderen
- overgangsduur
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer diaovergangen in Python met Aspose.Slides: kies typen, snelheid, geluid en timing om presentaties in PPT, PPTX en ODP te verfijnen."
---
Toont het toepassen van diaovergangseffecten en -tijden met **Aspose.Slides for Python via .NET**.

## **Diaovergang toevoegen**

Pas een vervagingsovergang toe op de eerste dia.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Pas een vervagingsovergang toe.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Diaovergang benaderen**

Lees het overgangstype dat momenteel aan een dia is toegewezen.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Toegang tot het overgangstype.
        transition_type = slide.slide_show_transition.type
```

## **Diaovergang verwijderen**

Verwijder elk overgangseffect door het type in te stellen op `NONE`.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Verwijder overgang door none in te stellen.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Duur van overgang instellen**

Geef op hoe lang de dia wordt weergegeven voordat deze automatisch wordt doorgeschoven.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # in milliseconden.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```