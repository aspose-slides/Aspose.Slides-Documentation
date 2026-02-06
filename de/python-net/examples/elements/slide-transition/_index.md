---
title: Folienübergang
type: docs
weight: 110
url: /de/python-net/examples/elements/slide-transition/
keywords:
- Folienübergang
- Folienübergang hinzufügen
- Folienübergang abrufen
- Folienübergang entfernen
- Übergangsdauer
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Steuern Sie Folienübergänge in Python mit Aspose.Slides: Wählen Sie Typen, Geschwindigkeit, Sound und Timing, um Präsentationen in PPT, PPTX und ODP zu verfeinern."
---
Demonstriert die Anwendung von Folienübergangseffekten und Timings mit **Aspose.Slides for Python via .NET**.

## **Folienübergang hinzufügen**

Wenden Sie einen Fade-Übergangseffekt auf die erste Folie an.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Fade-Übergang anwenden.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Folienübergang abrufen**

Lesen Sie den aktuell einer Folie zugewiesenen Übergangstyp.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Übergangstyp abrufen.
        transition_type = slide.slide_show_transition.type
```

## **Folienübergang entfernen**

Löschen Sie jeden Übergangseffekt, indem Sie den Typ auf `NONE` setzen.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Übergang entfernen, indem NONE gesetzt wird.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Übergangsdauer festlegen**

Geben Sie an, wie lange die Folie angezeigt wird, bevor sie automatisch weitergeht.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # in Millisekunden.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```