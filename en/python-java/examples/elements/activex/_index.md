---
title: ActiveX
type: docs
weight: 200
url: /python-java/examples/elements/activex/
keywords:
- code example
- ActiveX
- ActiveX control
- ActiveX properties
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Use Aspose.Slides for Python via Java to add, access, remove, and configure ActiveX controls in PowerPoint presentations with practical code examples."
---

This article demonstrates how to add, access, remove, and configure ActiveX controls in a presentation using **Aspose.Slides for Python via Java**.

Install the package as described in [Installation](/slides/python-java/installation/). Each example imports `asposeslides` before starting the JVM, then imports the API after the JVM is running. The access and removal examples use `add_activex.pptm`, created by the first example.

## **Add an ActiveX Control**

Insert a Windows Media Player control on the first slide and save the presentation as a PPTM file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Add a Windows Media Player control.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Access an ActiveX Control**

Read the name and automatic playback setting of the first ActiveX control on the slide.

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
            # Access the first ActiveX control.
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

## **Remove an ActiveX Control**

Delete the first ActiveX control from the slide and save the modified presentation.

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
            # Remove the first ActiveX control.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Set ActiveX Properties**

Add a Windows Media Player control, disable automatic playback, and hide its playback controls. Use [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#set_Item) to assign property values as strings.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Add a Windows Media Player control and configure its properties.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```
