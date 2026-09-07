---
title: Diaátmenet
type: docs
weight: 110
url: /hu/python-java/examples/elements/slide-transition/
keywords:
- kód példa
- diaátmenet
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Alkalmazzon és távolítson el diaátmeneteket, valamint állítson be automatikus diaelőrehaladási időzítéseket az Aspose.Slides for Python via Java kódpéldákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja a diavetítési áttűnési effektusok és időzítések alkalmazását az **Aspose.Slides for Python via Java** segítségével.

Telepítse a csomagot a [Installation](/slides/hu/python-java/installation/) útmutató szerint. Minden példa a `asposeslides` modult importálja a JVM indítása előtt, majd a JVM futása közben importálja az API-t.

## **Diaváltás hozzáadása**

Alkalmazzon egy halványuló áttűnési hatást az első diára.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Alkalmazzon egy halványuló áttűnést.
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **Diaváltás elérése**

Olvassa el a diára jelenleg hozzárendelt áttűnés típusát.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # Az áttűnés típusának lekérdezése.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Diaváltás eltávolítása**

Törölje az összes áttűnési hatást. A JPype a Java `None` állandót `None_` néven teszi elérhetővé, mivel a `None` a Pythonban kulcsszó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # Távolítsa el az áttűnési hatást.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Áttűnés időtartamának beállítása**

Adja meg, mennyi ideig jelenjen meg a dia, mielőtt automatikusan továbblép. Ebben a példában két másodperc után lép tovább, és lehetővé teszi a továbblépést egérkattintással is. Ez az időzítés a dia előrehaladását szabályozza, nem az áttűnési hatás sebességét.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # Ezredmásodpercben.
finally:
    presentation.dispose()
```