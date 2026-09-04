---
title: ActiveX
type: docs
weight: 200
url: /cs/python-java/examples/elements/activex/
keywords:
- příklad kódu
- ActiveX
- ActiveX ovládací prvek
- ActiveX vlastnosti
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Pomocí Aspose.Slides pro Python přes Java přidejte, přistupujte, odstraňujte a konfigurujte ActiveX ovládací prvky v prezentacích PowerPoint s praktickými příklady kódu."
---
Tento článek ukazuje, jak přidávat, přistupovat, odstraňovat a konfigurovat ActiveX ovládací prvky v prezentaci pomocí **Aspose.Slides for Python via Java**.

Nainstalujte balíček podle popisu v [Installation](/slides/cs/python-java/installation/). Každý příklad nejprve importuje `asposeslides` před spuštěním JVM, poté importuje API po spuštění JVM. Příklady pro přístup a odstraňování používají `add_activex.pptm`, který byl vytvořen prvním příkladem.

## **Přidání ActiveX ovládacího prvku**

Vložte ovládací prvek Windows Media Player na první snímek a uložte prezentaci jako soubor PPTM.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Přidejte ovládací prvek Windows Media Player.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Přístup k ActiveX ovládacímu prvku**

Načtěte název a nastavení automatického přehrávání prvního ActiveX ovládacího prvku na snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Přistupte k prvnímu ActiveX ovládacímu prvku.
            control = slide.getControls().get_Item(0)
            print("Control Name:", control.getName())
            print("autoStart:", control.getProperties().get_Item("autoStart"))
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

## **Odstranění ActiveX ovládacího prvku**

Odstraňte první ActiveX ovládací prvek ze snímku a uložte upravenou prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Odstraňte první ActiveX ovládací prvek.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Nastavení vlastností ActiveX**

Přidejte ovládací prvek Windows Media Player, zakážte automatické přehrávání a skryjte jeho ovládací prvky přehrávání. Použijte [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/cs/python-java/aspose.slides/controlpropertiescollection/#set_Item) k přiřazení hodnot vlastností jako řetězců.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Přidejte ovládací prvek Windows Media Player a nakonfigurujte jeho vlastnosti.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```