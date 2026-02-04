---
title: ActiveX
type: docs
weight: 200
url: /python-net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX control
- add ActiveX
- access ActiveX
- remove ActiveX
- ActiveX properties
- code examples
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Learn how to find, edit, and remove ActiveX controls in Python with Aspose.Slides, including property updates for PowerPoint presentations."
---

Demonstrates how to add, access, remove, and configure ActiveX controls in a presentation using **Aspose.Slides for Python via .NET**.

## **Add an ActiveX Control**

Insert a new ActiveX control.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Add a new ActiveX control (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **Access an ActiveX Control**

Read information from the first ActiveX control on the slide.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Access the first ActiveX control.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # Print control name.
            print(f"Control Name: {control.name}")
```

## **Remove an ActiveX Control**

Delete an existing ActiveX control from the slide.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # Remove the first ActiveX control.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **Set ActiveX Properties**

Configure several ActiveX properties.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Assuming the Control collection contains at least one Control.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```
