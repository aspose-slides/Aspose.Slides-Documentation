---
title: Diaátmenet
type: docs
weight: 110
url: /hu/python-net/examples/elements/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet elérése
- diaátmenet eltávolítása
- átmenet időtartama
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Az Aspose.Slides segítségével Pythonban szabályozhatja a diaátmeneteket: válasszon típusokat, sebességet, hangot és időzítést a PPT, PPTX és ODP prezentációk finomhangolásához."
---
Bemutatja a diákátmenet-effektek és időzítések alkalmazását az **Aspose.Slides for Python via .NET** használatával.

## **Diákátmenet hozzáadása**

Alkalmazzon fokozatos (fade) átmenetet az első diára.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Alkalmazzon egy fade átmenetet.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Diákátmenet elérése**

Olvassa ki a diára jelenleg beállított átmenettípust.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Hozzáférés az átmenettípushoz.
        transition_type = slide.slide_show_transition.type
```

## **Diákátmenet eltávolítása**

Törölje az átmenet-effektust a típus `NONE`-ra állítva.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Átmenet eltávolítása a NONE beállításával.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Átmenet időtartamának beállítása**

Adja meg, mennyi ideig jelenjen meg a dia, mielőtt automatikusan továbblép.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # ezredmásodpercben.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```