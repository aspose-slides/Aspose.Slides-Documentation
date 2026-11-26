---
title: Manage ActiveX Controls in Presentations Using Python
linktitle: ActiveX
type: docs
weight: 80
url: /python-java/activex/
keywords:
- ActiveX
- ActiveX control
- manage ActiveX
- add ActiveX
- modify ActiveX
- media player
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Edit ActiveX text boxes and buttons, update control previews, and reuse a Windows Media Player control in PowerPoint presentations with Aspose.Slides for Python via Java."
---

## **Introduction**

ActiveX controls give a PowerPoint slide interactive elements such as text boxes, command buttons, and media players. Aspose.Slides for Python via Java exposes a slide's controls through [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls). Use this collection to edit a control, move it on the slide, or remove it.

## **List ActiveX Controls and Their Stored Properties**

To inspect an unfamiliar template, open it for reading and iterate through the controls on each slide. The example reports the slide number, control name, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId), and each key-value pair in [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties). It reads the presentation without activating controls, invoking events or macros, changing values, or saving the file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
```

Selected output from `ActiveX.pptm` shows a text box and a command button.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

An empty property collection appears as `[]`. For controls that use binary storage, [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) can return `None`, shown as `Properties unavailable`. If you need only the names, use [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) after checking that the collection is available. The report lists the properties available from the presentation. A control may support additional properties at runtime.

## **Modify ActiveX Controls**

The example expects a macro-enabled presentation with a text box named `TextBox1` and a command button named `CommandButton1` on the first slide. It uses the [control properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) to change the text box value and the button caption. Each control also has a static preview that PowerPoint can display before activation. Supply a PNG for each control showing its updated text and appearance. The example assigns these images through [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat).

The example moves every control on the first slide down by 100 points by setting its frame with [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). It saves the edited presentation in PPTM format, then uses [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) to save a second copy with all ActiveX controls removed from that slide.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **Add an ActiveX Media Player Control**

To reuse a configured Windows Media Player control, start with a template whose first slide contains a player named `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) copies the entire slide into a new presentation. The example sets the player's `URL` in its [properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) and saves the cloned slide as the only slide in the output. The video stays external, so choose a path the player can access during playback.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **FAQ**

**Can Aspose.Slides preserve ActiveX controls without running them?**

Yes. Aspose.Slides can read and save controls, including their properties and positions, without activating them.

**How do ActiveX controls differ from OLE objects?**

ActiveX controls let users interact with a slide, for example by entering text or clicking a button. An [OLE object](/slides/python-java/manage-ole/) lets a slide contain or link to content managed by another application, such as an Excel worksheet.

**Will ActiveX events still trigger VBA macros after I save a presentation with Aspose.Slides?**

Save the presentation in a macro-enabled format such as PPTM to retain its VBA project. PowerPoint for Windows can run the existing event handlers when its security settings allow both ActiveX controls and macros.
