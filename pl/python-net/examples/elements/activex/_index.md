---
title: ActiveX
type: docs
weight: 200
url: /pl/python-net/examples/elements/activex/
keywords:
- ActiveX
- kontrolka ActiveX
- dodaj ActiveX
- uzyskaj dostęp do ActiveX
- usuń ActiveX
- właściwości ActiveX
- przykłady kodu
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak znajdować, edytować i usuwać kontrolki ActiveX w języku Python przy użyciu Aspose.Slides, w tym aktualizować właściwości w prezentacjach PowerPoint."
---
Pokazuje, jak dodać, uzyskać dostęp, usunąć i skonfigurować kontrolki ActiveX w prezentacji przy użyciu **Aspose.Slides for Python via .NET**.

## **Dodaj kontrolkę ActiveX**

Wstaw nową kontrolkę ActiveX.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Dodaj nową kontrolkę ActiveX (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **Uzyskaj dostęp do kontrolki ActiveX**

Odczytaj informacje z pierwszej kontrolki ActiveX na slajdzie.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Uzyskaj dostęp do pierwszej kontrolki ActiveX.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # Wypisz nazwę kontrolki.
            print(f"Control Name: {control.name}")
```

## **Usuń kontrolkę ActiveX**

Usuń istniejącą kontrolkę ActiveX ze slajdu.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # Usuń pierwszą kontrolkę ActiveX.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **Ustaw właściwości ActiveX**

Skonfiguruj kilka właściwości ActiveX.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że kolekcja Control zawiera co najmniej jedną kontrolkę.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```