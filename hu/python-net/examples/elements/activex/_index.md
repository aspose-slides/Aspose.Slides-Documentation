---
title: ActiveX
type: docs
weight: 200
url: /hu/python-net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX hozzáadása
- ActiveX elérése
- ActiveX eltávolítása
- ActiveX tulajdonságok
- kódpéldák
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan kereshet, szerkeszthet és távolíthat el ActiveX vezérlőket a Pythonban az Aspose.Slides segítségével, beleértve a PowerPoint prezentációk tulajdonságfrissítéseit."
---
Bemutatja, hogyan lehet hozzáadni, elérni, eltávolítani és konfigurálni az ActiveX vezérlőket egy prezentációban a **Aspose.Slides for Python via .NET** használatával.

## **ActiveX vezérlő hozzáadása**

Helyezzen be egy új ActiveX vezérlőt.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Új ActiveX vezérlő (TextBox) hozzáadása.
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX vezérlő elérése**

Olvassa ki az információkat a dián szereplő első ActiveX vezérlőből.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Az első ActiveX vezérlő elérése.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # A vezérlő nevének kiírása.
            print(f"Control Name: {control.name}")
```

## **ActiveX vezérlő eltávolítása**

Távolítson el egy meglévő ActiveX vezérlőt a diáról.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # Az első ActiveX vezérlő eltávolítása.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX tulajdonságok beállítása**

Konfiguráljon több ActiveX tulajdonságot.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy a Control gyűjtemény legalább egy Control elemet tartalmaz.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```