---
title: ActiveX
type: docs
weight: 200
url: /cs/python-net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX ovládací prvek
- přidat ActiveX
- přístup k ActiveX
- odstranit ActiveX
- vlastnosti ActiveX
- ukázky kódu
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak najít, upravit a odstranit ovládací prvky ActiveX v Pythonu s Aspose.Slides, včetně aktualizací vlastností pro prezentace PowerPoint."
---
Ukazuje, jak přidávat, přistupovat, odstraňovat a konfigurovat ovládací prvky ActiveX v prezentaci pomocí **Aspose.Slides for Python via .NET**.

## **Přidat ovládací prvek ActiveX**

Vložte nový ovládací prvek ActiveX.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Přidá nový ovládací prvek ActiveX (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **Přístup k ovládacímu prvku ActiveX**

Přečtěte informace z prvního ovládacího prvku ActiveX na snímku.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Přístup k prvnímu ovládacímu prvku ActiveX.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # Vytiskne název ovládacího prvku.
            print(f"Control Name: {control.name}")
```

## **Odstranit ovládací prvek ActiveX**

Odstraňte existující ovládací prvek ActiveX ze snímku.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # Odstranit první ovládací prvek ActiveX.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **Nastavit vlastnosti ActiveX**

Nakonfigurujte několik vlastností ActiveX.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Předpokládá se, že kolekce Control obsahuje alespoň jeden Control.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```