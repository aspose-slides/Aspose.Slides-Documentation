---
title: ActiveX
type: docs
weight: 200
url: /nl/python-java/examples/elements/activex/
keywords:
- codevoorbeeld
- ActiveX
- ActiveX-besturingselement
- ActiveX-eigenschappen
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Gebruik Aspose.Slides voor Python via Java om ActiveX-besturingselementen toe te voegen, te benaderen, te verwijderen en te configureren in PowerPoint-presentaties met praktische codevoorbeelden."
---
Dit artikel laat zien hoe u ActiveX‑besturingselementen kunt toevoegen, benaderen, verwijderen en configureren in een presentatie met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart, en importeert daarna de API nadat de JVM draait. De voorbeelden voor benaderen en verwijderen gebruiken `add_activex.pptm`, die door het eerste voorbeeld is aangemaakt.

## **ActiveX-besturingselement toevoegen**

Voeg een Windows Media Player‑besturingselement toe op de eerste dia en sla de presentatie op als een PPTM‑bestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Voeg een Windows Media Player‑besturingselement toe.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **ActiveX-besturingselement benaderen**

Lees de naam en de instelling voor automatisch afspelen van het eerste ActiveX‑besturingselement op de dia.

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
            # Toegang tot het eerste ActiveX‑besturingselement.
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

## **ActiveX-besturingselement verwijderen**

Verwijder het eerste ActiveX‑besturingselement van de dia en sla de aangepaste presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Verwijder het eerste ActiveX-besturingselement.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **ActiveX-eigenschappen instellen**

Voeg een Windows Media Player‑besturingselement toe, schakel automatisch afspelen uit en verberg de afspeelbedieningselementen. Gebruik [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/nl/python-java/aspose.slides/controlpropertiescollection/#set_Item) om eigenschapswaarden als tekenreeksen toe te wijzen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Voeg een Windows Media Player-besturingselement toe en configureer de eigenschappen.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```