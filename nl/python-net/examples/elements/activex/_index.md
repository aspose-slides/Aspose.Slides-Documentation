---
title: ActiveX
type: docs
weight: 200
url: /nl/python-net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX-besturingselement
- ActiveX toevoegen
- ActiveX benaderen
- ActiveX verwijderen
- ActiveX-eigenschappen
- codevoorbeelden
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u ActiveX-besturingselementen kunt vinden, bewerken en verwijderen in Python met Aspose.Slides, inclusief het bijwerken van eigenschappen voor PowerPoint-presentaties."
---
Toont hoe u ActiveX-besturingselementen kunt toevoegen, benaderen, verwijderen en configureren in een presentatie met **Aspose.Slides for Python via .NET**.

## **ActiveX-besturingselement toevoegen**

Voeg een nieuw ActiveX-besturingselement toe.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Voeg een nieuw ActiveX-besturingselement toe (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX-besturingselement benaderen**

Lees de informatie van het eerste ActiveX-besturingselement op de dia.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Toegang tot het eerste ActiveX-besturingselement.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # Print de naam van het besturingselement.
            print(f"Control Name: {control.name}")
```

## **ActiveX-besturingselement verwijderen**

Verwijder een bestaand ActiveX-besturingselement van de dia.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # Verwijder het eerste ActiveX-besturingselement.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX-eigenschappen instellen**

Configureer verschillende ActiveX-eigenschappen.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Aangenomen dat de Control-collectie ten minste één Control bevat.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```