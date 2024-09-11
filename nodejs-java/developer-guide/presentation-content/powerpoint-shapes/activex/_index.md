---
title: ActiveX
type: docs
weight: 80
url: /nodejs-java/activex/
---


{{% alert color="primary" %}} 

ActiveX controls are used in presentations. Aspose.Slides for Node.js via Java allows you to add and manage ActiveX controls, but they are a bit trickier to manage when compared to normal presentation shapes. We implemented support for adding Media Player Active control in Aspose.Slides. Note that ActiveX controls are not shapes; they are not part of the presentation's [IShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interfaces/IShapeCollection). They are part of the separate [IControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interfaces/IControlCollection) instead. In this topic, we will show you how to work with them.

{{% /alert %}} 

## **Adding Media Player ActiveX Control to Slide**
To add an ActiveX Media Player control, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class and generate an empty presentation instance.
1. Access the target slide in [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Add the Media Player ActiveX control using the [addControl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IControlCollection#addControl-int-float-float-float-float-) method exposed by [IControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interfaces/IControlCollection).
1. Access the Media Player ActiveX control and set the video path by using its properties.
1. Save the presentation as a PPTX file.

This sample code, based on the steps above, shows to how to add Media Player ActiveX Control to a slide:

```javascript
    // Create empty presentation instance
    var pres = new  aspose.slides.Presentation();
    try {
        // Adding the Media Player ActiveX control
        pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
        // Access the Media Player ActiveX control and set the video path
        pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
        // Save the Presentation
        pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Modifying ActiveX Control**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java 7.1.0 and newer versions are equipped with components for managing ActiveX controls. You can access the already added ActiveX control in your presentation and modify or delete it through its properties.

{{% /alert %}} 

To manage a simple ActiveX control like a text box and simple command button on a slide, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class and load the presentation with ActiveX controls in it.
1. Obtain a slide reference by its index.
1. Access the ActiveX controls in the slide by accessing the [IControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interfaces/IControlCollection).
1. Access the TextBox1 ActiveX control using the [IControl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interfaces/IControl) object.
1. Change the properties of the TextBox1 ActiveX control that include text, font, font height, and frame position.
1. Access the second access control called CommandButton1.
1. Change the button caption, font, and position.
1. Shift the position of the ActiveX controls frames.
1. Write the modified presentation to a PPTX file.

This sample code, based on the steps above, shows how to manage a simple ActiveX control: 

```javascript
    // Accessing the presentation with ActiveX controls
    var pres = new  aspose.slides.Presentation("ActiveX.pptm");
    try {
        // Accessing the first slide in presentation
        var slide = pres.getSlides().get_Item(0);
        // changing TextBox text
        var control = slide.getControls().get_Item(0);
        if (control.getName().equalsIgnoreCase("TextBox1") && (control.getProperties() != null)) {
            var newText = "Changed text";
            control.getProperties().set_Item("Value", newText);
            // Changing substitute image. PowerPoint will replace this image during activeX activation,
            // so sometime it's OK to leave image unchanged.
            var image = java.newInstanceSync("BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
            var graphics = image.getGraphics();
            graphics.setColor(SystemColor);
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
            var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
            graphics.setColor(SystemColor);
            graphics.setFont(font);
            graphics.drawString(newText, 10, 20);
            graphics.setColor(SystemColor);
            graphics.drawLine(0, image.getHeight() - 1, 0, 0);
            graphics.drawLine(0, 0, image.getWidth() - 1, 0);
            graphics.setColor(SystemColor);
            graphics.drawLine(1, image.getHeight() - 2, 1, 1);
            graphics.drawLine(1, 1, image.getWidth() - 2, 1);
            graphics.setColor(SystemColor);
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
            graphics.setColor(SystemColor);
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
            graphics.dispose();
            var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
            java.callStaticMethodSync("javax.imageio.ImageIO", "write", image, "PNG", baos);
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
        }
        // Changing Button caption
        control = pres.getSlides().get_Item(0).getControls().get_Item(1);
        if (control.getName().equalsIgnoreCase("CommandButton1") && (control.getProperties() != null)) {
            var newCaption = "Show MessageBox";
            control.getProperties().set_Item("Caption", newCaption);
            // Changing substitute
            var image = java.newInstanceSync("BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
            var graphics = image.getGraphics();
            graphics.setColor(SystemColor);
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
            var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
            graphics.setColor(SystemColor);
            graphics.setFont(font);
            var metrics = graphics.getFontMetrics(font);
            graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);
            graphics.setColor(SystemColor);
            graphics.drawLine(0, image.getHeight() - 1, 0, 0);
            graphics.drawLine(0, 0, image.getWidth() - 1, 0);
            graphics.setColor(SystemColor);
            graphics.drawLine(1, image.getHeight() - 2, 1, 1);
            graphics.drawLine(1, 1, image.getWidth() - 2, 1);
            graphics.setColor(SystemColor);
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
            graphics.setColor(SystemColor);
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
            graphics.dispose();
            var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
            java.callStaticMethodSync("javax.imageio.ImageIO", "write", image, "PNG", baos);
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
        }
        // moving 100 points down
        pres.getSlides().get_Item(0).getControls().forEach(function(ctl) {
            var frame = ctl.getFrame();
            ctl.setFrame(new  aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
        });
        pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
        // removing controls
        pres.getSlides().get_Item(0).getControls().clear();
        pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
    } catch (e) {console.log(e);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
