---
title: ActiveX
type: docs
weight: 70
url: /java/activex/
---


{{% alert color="primary" %}} 

ActiveX controls are used in presentations. Aspose.Slides for Java allows you to add and manage ActiveX controls, but they are a bit trickier to manage when compared to normal presentation shapes. We implemented support for adding Media Player Active control in Aspose.Slides. Note that ActiveX controls are not shapes; they are not part of the presentation's [IShapeCollection](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IShapeCollection). They are part of the separate [IControlCollection](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IControlCollection) instead. In this topic, we will show you how to work with them. 

{{% /alert %}} 

## **Adding Media Player ActiveX Control to Slide**
To add an ActiveX Media Player control, do this:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and generate an empty presentation instance.
1. Access the target slide in [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation).
1. Add the Media Player ActiveX control using the [addControl](https://apireference.aspose.com/slides/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) method exposed by [IControlCollection](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IControlCollection).
1. Access the Media Player ActiveX control and set the video path by using its properties.
1. Save the presentation as a PPTX file.

This sample code, based on the steps above, shows to how to add Media Player ActiveX Control to a slide:

```java
// Create empty presentation instance
Presentation pres = new Presentation();
try {
    // Adding the Media Player ActiveX control
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Access the Media Player ActiveX control and set the video path
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Save the Presentation
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modifying ActiveX Control**
{{% alert color="primary" %}} 

Aspose.Slides for Java 7.1.0 and newer versions are equipped with components for managing ActiveX controls. You can access the already added ActiveX control in your presentation and modify or delete it through its properties.

{{% /alert %}} 

To manage a simple ActiveX control like a text box and simple command button on a slide, do this:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation with ActiveX controls in it.
1. Obtain a slide reference by its index.
1. Access the ActiveX controls in the slide by accessing the [IControlCollection](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IControlCollection).
1. Access the TextBox1 ActiveX control using the [IControl](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IControl) object.
1. Change the properties of the TextBox1 ActiveX control that include text, font, font height, and frame position.
1. Access the second access control called CommandButton1.
1. Change the button caption, font, and position.
1. Shift the position of the ActiveX controls frames.
1. Write the modified presentation to a PPTX file.

This sample code, based on the steps above, shows how to manage a simple ActiveX control: 

```java
// Accessing the presentation with ActiveX controls
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Accessing the first slide in presentation
    ISlide slide = pres.getSlides().get_Item(0);
    
    // changing TextBox text
    IControl control = slide.getControls().get_Item(0);
    
    if (control.getName() == "TextBox1" && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
    
        // Changing substitute image. PowerPoint will replace this image during activeX activation, 
        // so sometime it's OK to leave image unchanged.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
    
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
    
        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
    
        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
    
        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
    
        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
    
        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
    
        graphics.dispose();
        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(image));
    }
    
    // Changing Button caption
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    
    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Changing substitute
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
    
        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);
    
        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
    
        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
    
        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
    
        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
    
        graphics.dispose();
        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(image));
    }
    
    // moving 100 points down
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);
    
    // removing controls
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```
