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
description: "Learn how Aspose.Slides for Python via Java uses ActiveX to automate and enhance PowerPoint presentations, giving developers powerful control over slides."
---

## **Introduction**

ActiveX controls are used in presentations. Aspose.Slides for Python via Java allows you to add and manage ActiveX controls, but they are a bit trickier to manage when compared to normal presentation shapes. Aspose.Slides supports adding Media Player ActiveX controls. Note that ActiveX controls are not shapes; they are not part of the presentation's [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/). They are part of the separate [ControlCollection](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/) instead. In this topic, we will show you how to work with them.

## **Add a Media Player ActiveX Control to a Slide**

To add an ActiveX Media Player control, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and generate an empty presentation instance.
1. Access the target slide in [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Add the Media Player ActiveX control using the [addControl](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#addControl) method exposed by [ControlCollection](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/).
1. Access the Media Player ActiveX control and set the video path by using its properties.
1. Save the presentation as a PPTX file.

This sample code, based on the steps above, shows how to add a Media Player ActiveX control to a slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Create an empty presentation.
presentation = Presentation()
try:
    # Add the Media Player ActiveX control.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Set the video path.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Save the presentation.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modify an ActiveX Control**

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java provides components for managing ActiveX controls. You can access the already added ActiveX control in your presentation and modify or delete it through its properties.

{{% /alert %}}

To manage a simple ActiveX control like a text box and simple command button on a slide, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation with ActiveX controls in it.
1. Obtain a slide reference by its index.
1. Access the ActiveX controls in the slide by accessing the [ControlCollection](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/).
1. Access the TextBox1 ActiveX control using the [Control](https://reference.aspose.com/slides/python-java/aspose.slides/control/) object.
1. Change the properties of the TextBox1 ActiveX control that include text, font, font height, and frame position.
1. Access the second ActiveX control called CommandButton1.
1. Change the button caption, font, and position.
1. Shift the position of the ActiveX controls' frames.
1. Write the modified presentation to a PPTM file.

This sample code, based on the steps above, shows how to manage a simple ActiveX control:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# Load the presentation with ActiveX controls.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # Access the first slide.
        slide = presentation.getSlides().get_Item(0)

        # Change the text box text.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # Change the substitute image. PowerPoint replaces it during ActiveX activation,
            # so it can sometimes be left unchanged.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Change the button caption.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # Change the substitute image.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Move the controls down by 100 points.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # Remove the controls.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **FAQ**

**Does Aspose.Slides preserve ActiveX controls when reading and re-saving if they cannot be executed in the Python runtime?**

Yes. Aspose.Slides treats them as part of the presentation and can read/modify their properties and frames; executing the controls themselves is not required to preserve them.

**How do ActiveX controls differ from OLE objects in a presentation?**

ActiveX controls are interactive managed controls (buttons, text boxes, media player), whereas [OLE](/slides/python-java/manage-ole/) refers to embedded application objects (for example, an Excel worksheet). They are stored and handled differently and have different property models.

**Do ActiveX events and VBA macros work if the file has been modified by Aspose.Slides?**

Aspose.Slides preserves the existing markup and metadata; however, events and macros run only inside PowerPoint on Windows when security allows it. The library does not execute VBA.
