---
title: Bildövergång
type: docs
weight: 110
url: /sv/python-net/examples/elements/slide-transition/
keywords:
- bildövergång
- lägg till bildövergång
- åtkomst till bildövergång
- ta bort bildövergång
- övergångstid
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Styr bildövergångar i Python med Aspose.Slides: välj typer, hastighet, ljud och tidpunkt för att finputsa presentationer i PPT, PPTX och ODP."
---
Visar hur du tillämpar bildövergångseffekter och tidsinställningar med **Aspose.Slides for Python via .NET**.

## **Add a Slide Transition**
Lägg till en bildövergång

Apply a fade transition effect to the first slide.
Applicera en fade-övergångseffekt på den första bilden.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Tillämpa en fade-övergång.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Slide Transition**
Kom åt en bildövergång

Read the transition type currently assigned to a slide.
Läs av övergångstypen som för närvarande är tilldelad en bild.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Åtkomst till övergångstypen.
        transition_type = slide.slide_show_transition.type
```

## **Remove a Slide Transition**
Ta bort en bildövergång

Clear any transition effect by setting the type to `NONE`.
Rensa alla övergångseffekter genom att sätta typen till `NONE`.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Ta bort övergång genom att sätta ingen.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Transition Duration**
Ange övergångens varaktighet

Specify how long the slide is displayed before advancing automatically.
Ange hur länge bilden visas innan den automatiskt går vidare.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # i millisekunder.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```