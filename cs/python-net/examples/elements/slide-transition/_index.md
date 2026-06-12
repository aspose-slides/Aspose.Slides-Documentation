---
title: Přechod snímku
type: docs
weight: 110
url: /cs/python-net/examples/elements/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- přístup k přechodu snímku
- odebrat přechod snímku
- doba trvání přechodu
- ukázky kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Říďte přechody snímků v Pythonu pomocí Aspose.Slides: vybírejte typy, rychlost, zvuk a časování pro vylepšení prezentací ve formátech PPT, PPTX a ODP."
---
Ukazuje použití efektů a časování přechodů snímků s **Aspose.Slides for Python via .NET**.

## **Přidat přechod snímku**

Použijte efekt postupného přechodu na první snímek.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Použít přechod typu rozplynutí.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k přechodu snímku**

Přečtěte typ přechodu aktuálně přiřazený ke snímku.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Přístup k typu přechodu.
        transition_type = slide.slide_show_transition.type
```

## **Odebrat přechod snímku**

Odstraňte jakýkoli efekt přechodu nastavením typu na `NONE`.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Odebrat přechod nastavením na žádný.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit dobu trvání přechodu**

Určete, jak dlouho bude snímek zobrazen před automatickým přechodem.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # v milisekundách.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```