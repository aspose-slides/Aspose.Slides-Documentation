---
title: ActiveX
type: docs
weight: 200
url: /sv/python-net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX‑kontroll
- lägga till ActiveX
- komma åt ActiveX
- ta bort ActiveX
- ActiveX‑egenskaper
- kodexempel
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du hittar, redigerar och tar bort ActiveX‑kontroller i Python med Aspose.Slides, inklusive egenskapsuppdateringar för PowerPoint‑presentationer."
---
Visar hur man lägger till, får åtkomst till, tar bort och konfigurerar ActiveX‑kontroller i en presentation med **Aspose.Slides for Python via .NET**.

## **Lägg till en ActiveX‑kontroll**

Infoga en ny ActiveX‑kontroll.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Lägg till en ny ActiveX‑kontroll (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **Få åtkomst till en ActiveX‑kontroll**

Läs information från den första ActiveX‑kontrollen på bilden.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Åtkomst till den första ActiveX‑kontrollen.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # Skriv ut kontrollnamn.
            print(f"Control Name: {control.name}")
```

## **Ta bort en ActiveX‑kontroll**

Radera en befintlig ActiveX‑kontroll från bilden.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # Ta bort den första ActiveX‑kontrollen.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **Ställ in ActiveX‑egenskaper**

Konfigurera flera ActiveX‑egenskaper.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Förutsatt att kontrollsamlingen innehåller minst en kontroll.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```