---
title: Przejście slajdu
type: docs
weight: 110
url: /pl/python-net/examples/elements/slide-transition/
keywords:
- przejście slajdu
- dodaj przejście slajdu
- dostęp do przejścia slajdu
- usuń przejście slajdu
- czas trwania przejścia
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Kontroluj przejścia slajdów w Pythonie za pomocą Aspose.Slides: wybieraj typy, prędkość, dźwięk i czas, aby dopracować prezentacje w formatach PPT, PPTX i ODP."
---
Prezentuje zastosowanie efektów przejść slajdów oraz ich synchronizacji z **Aspose.Slides for Python via .NET**.

## **Add a Slide Transition**

Zastosuj efekt płynnego przejścia (fade) do pierwszego slajdu.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Zastosuj przejście zanikania.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Slide Transition**

Odczytaj typ przejścia aktualnie przypisany do slajdu.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Uzyskaj typ przejścia.
        transition_type = slide.slide_show_transition.type
```

## **Remove a Slide Transition**

Wyczyść wszystkie efekty przejścia, ustawiając typ na `NONE`.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Usuń przejście przez ustawienie NONE.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Transition Duration**

Określ, jak długo slajd jest wyświetlany przed automatycznym przejściem.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # w milisekundach.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```