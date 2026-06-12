---
title: ActiveX
type: docs
weight: 200
url: /it/python-net/examples/elements/activex/
keywords:
- ActiveX
- controllo ActiveX
- aggiungere ActiveX
- accedere a ActiveX
- rimuovere ActiveX
- proprietà ActiveX
- esempi di codice
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come trovare, modificare e rimuovere i controlli ActiveX in Python con Aspose.Slides, inclusi gli aggiornamenti delle proprietà per le presentazioni PowerPoint."
---
Dimostra come aggiungere, accedere, rimuovere e configurare i controlli ActiveX in una presentazione utilizzando **Aspose.Slides for Python via .NET**.

## **Aggiungi un controllo ActiveX**

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Aggiungi un nuovo controllo ActiveX (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **Accedi a un controllo ActiveX**

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Accedi al primo controllo ActiveX.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # Stampa il nome del controllo.
            print(f"Control Name: {control.name}")
```

## **Rimuovi un controllo ActiveX**

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # Rimuovi il primo controllo ActiveX.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **Imposta le proprietà ActiveX**

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la collezione di controlli contenga almeno un controllo.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```