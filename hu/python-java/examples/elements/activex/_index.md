---
title: ActiveX
type: docs
weight: 200
url: /hu/python-java/examples/elements/activex/
keywords:
- kódpélda
- ActiveX
- ActiveX vezérlő
- ActiveX tulajdonságok
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Python via Java használatával adjon hozzá, érjen el, távolítson el és konfiguráljon ActiveX vezérlőket PowerPoint prezentációkban, gyakorlati kódpéldákkal."
---
Ez a cikk bemutatja, hogyan lehet hozzáadni, elérni, eltávolítani és konfigurálni az ActiveX vezérlőket egy prezentációban az **Aspose.Slides for Python via Java** használatával.

Telepítse a csomagot a [Installation](/slides/hu/python-java/installation/) útmutató szerint. Minden példa a JVM indítása előtt importálja a `asposeslides`-t, majd a JVM futása után importálja az API-t. A hozzáférési és eltávolítási példák az `add_activex.pptm` fájlt használják, amelyet az első példa hozott létre.

## **ActiveX vezérlő hozzáadása**

Helyezzen be egy Windows Media Player vezérlőt az első diára, és mentse a prezentációt PPTM fájlként.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Windows Media Player vezérlő hozzáadása.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **ActiveX vezérlő elérése**

Olvassa el az első ActiveX vezérlő nevét és az automatikus lejátszás beállítását a dián.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Az első ActiveX vezérlő elérése.
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

## **ActiveX vezérlő eltávolítása**

Törölje az első ActiveX vezérlőt a diáról, és mentse a módosított prezentációt.

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
            # Az első ActiveX vezérlő eltávolítása.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **ActiveX tulajdonságok beállítása**

Hozzon létre egy Windows Media Player vezérlőt, tiltsa le az automatikus lejátszást, és rejtse el a lejátszási vezérlőket. Használja a [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/hu/python-java/aspose.slides/controlpropertiescollection/#set_Item) metódust a tulajdonságértékek karakterláncként történő beállításához.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Windows Media Player vezérlő hozzáadása és a tulajdonságainak beállítása.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```