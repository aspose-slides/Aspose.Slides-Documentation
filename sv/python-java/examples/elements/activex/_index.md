---
title: ActiveX
type: docs
weight: 200
url: /sv/python-java/examples/elements/activex/
keywords:
- kodexempel
- ActiveX
- ActiveX-kontroll
- ActiveX-egenskaper
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Använd Aspose.Slides för Python via Java för att lägga till, komma åt, ta bort och konfigurera ActiveX-kontroller i PowerPoint-presentationer med praktiska kodexempel."
---
Den här artikeln visar hur man lägger till, får åtkomst till, tar bort och konfigurerar ActiveX‑kontroller i en presentation med **Aspose.Slides for Python via Java**.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar sedan API:et när JVM körs. Exempel på åtkomst och borttagning använder `add_activex.pptm`, som skapats av det första exemplet.

## **Lägg till en ActiveX‑kontroll**

Infoga en Windows Media Player‑kontroll på den första bilden och spara presentationen som en PPTM‑fil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en Windows Media Player-kontroll.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Få åtkomst till en ActiveX‑kontroll**

Läs namn och inställning för automatisk uppspelning för den första ActiveX‑kontrollen på bilden.

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
            # Åtkomst till den första ActiveX-kontrollen.
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

## **Ta bort en ActiveX‑kontroll**

Ta bort den första ActiveX‑kontrollen från bilden och spara den modifierade presentationen.

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
            # Ta bort den första ActiveX-kontrollen.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Ställ in ActiveX‑egenskaper**

Lägg till en Windows Media Player‑kontroll, inaktivera automatisk uppspelning och dölj dess uppspelningskontroller. Använd [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/sv/python-java/aspose.slides/controlpropertiescollection/#set_Item) för att tilldela egenskapsvärden som strängar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en Windows Media Player-kontroll och konfigurera dess egenskaper.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```