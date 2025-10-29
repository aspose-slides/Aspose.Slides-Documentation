---
title: Manage ActiveX Controls in Presentations with Python
linktitle: ActiveX
type: docs
weight: 80
url: /python-net/activex/
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
description: "Learn how Aspose.Slides for Python via .NET leverages ActiveX to automate and enhance PowerPoint presentations, giving developers powerful control over slides."
---

ActiveX controls are used in presentations. Aspose.Slides for Python via .NET lets you manage ActiveX controls, but managing them is bit trickier and different from normal presentation shapes. From Aspose.Slides for Python via .NET 6.9.0, the component supports managing ActiveX controls. At the moment, you can access already added ActiveX control in your presentation and modify or delete it by using its various properties. Remember, ActiveX controls are not shapes and are not part of the presentation's IShapeCollection but the separate IControlCollection. This article shows how to work with them.
## **Modify ActiveX Controls**
To manage a simple ActiveX control like a text box and simple command button on a slide:

1. Create an instance of the Presentation class and load the presentation with ActiveX controls in it.
1. Obtain a slide reference by its index.
1. Access the ActiveX controls in the slide by accessing the IControlCollection.
1. Access the TextBox1 ActiveX control using the ControlEx object.
1. Change the different properties of the TextBox1 ActiveX control including text, font, font height and frame position.
1. Access the second access control called CommandButton1.
1. Change the button caption, font and position.
1. Shift the position of the ActiveX controls frames.
1. Write the modified presentation to a PPTX file.

The code snippet below updates the ActiveX controls on the presentation slides to the slide as shown below.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Accessing the presentation with  ActiveX controls
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Accessing the first slide in presentation
    slide = presentation.slides[0]

    # changing TextBox text
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # changing substitute image. Powerpoint will replace this image during activeX activation, so sometime it's OK to leave image unchanged.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # changing Button caption
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # changing substitute
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # Moving ActiveX frames 100 points down
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # Save the presentation with Edited ActiveX Controls
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Now removing controls
    slide.controls.clear()

    # Saving the presentation with cleared ActiveX controls
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **Add ActiveX Media Player Control**
To add ActiveX Media Player control, please perform following steps:

1. Create an instance of the Presentation class and load the sample presentation with Media Player ActiveX controls in it.
1. Create an instance of target Presentation class and generate empty presentation instance.
1. Clone the slide with Media Player ActiveX control in template presentation to target Presentation.
1. Access the cloned slide in target Presentation.
1. Access the ActiveX controls in the slide by accessing the IControlCollection.
1. Access the Media Player ActiveX control and set the video path by using its properties.
1. Save the presentation to a PPTX file.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents PPTX file
with slides.Presentation(path + "template.pptx") as presentation:

    # Create empty presentation instance
    with slides.Presentation() as newPresentation:

        # Remove default slide
        newPresentation.slides.remove_at(0)

        # Clone slide with Media Player ActiveX Control
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Access the Media Player ActiveX control and set the video path
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Save the Presentation
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Does Aspose.Slides preserve ActiveX controls when reading and re-saving if they cannot be executed in the Python runtime?**

Yes. Aspose.Slides treats them as part of the presentation and can read/modify their properties and frames; executing the controls themselves is not required to preserve them.

**How do ActiveX controls differ from OLE objects in a presentation?**

ActiveX controls are interactive managed controls (buttons, text boxes, media player), whereas [OLE](/slides/python-net/manage-ole/) refers to embedded application objects (for example, an Excel worksheet). They are stored and handled differently and have different property models.

**Do ActiveX events and VBA macros work if the file has been modified by Aspose.Slides?**

Aspose.Slides preserves the existing markup and metadata; however, events and macros run only inside PowerPoint on Windows when security allows it. The library does not execute VBA.
