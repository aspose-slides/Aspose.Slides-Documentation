---
title: Manage SmartArt Graphics in Presentations on Android
linktitle: SmartArt Graphics
type: docs
weight: 20
url: /androidjava/manage-smartart-shape/
keywords:
- SmartArt object
- SmartArt graphic
- SmartArt style
- SmartArt color
- create SmartArt
- add SmartArt
- edit SmartArt
- change SmartArt
- access SmartArt
- SmartArt layout type
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Automate PowerPoint SmartArt creation, editing, and styling using Aspose.Slides for Android, featuring concise Java code examples and performance-focused guidance."
---


## **Create a SmartArt Shape**
Aspose.Slides for Android via Java has provided an API to create SmartArt shapes. To create a SmartArt shape in a slide, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. [Add a SmartArt shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) by setting it [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType).
1. Save the modified presentation as a PPTX file.

```java
// Instantiate Presentation Class
Presentation pres = new Presentation();
try {
    // Get first slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Add Smart Art Shape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Saving presentation
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: SmartArt shape added to the slide**|

## **Access a SmartArt Shape on a Slide**
The following code will be used to access the SmartArt shapes added in presentation slide. In sample code we will traverse through every shape inside the slide and check if it is a [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) shape. If shape is of SmartArt type then we will typecast that to [**SmartArt**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) instance.

```java
// Load the desired the presentation
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Traverse through every shape inside first slide
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Check if shape is of SmartArt type
        if (shape instanceof ISmartArt)
        {
            // Typecast shape to SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Access a SmartArt Shape with a Particular Layout Type**
The following sample code will help to access the [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) shape with particular LayoutType. Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) shape is added.

1. Create an instance of [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) type and Typecast selected shape to SmartArt if it is SmartArt.
1. Check the SmartArt shape with particular LayoutType and perform what is required to be done afterwards.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Traverse through every shape inside first slide
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Check if shape is of SmartArt type
        if (shape instanceof ISmartArt)
        {
            // Typecast shape to SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Checking SmartArt Layout
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change a SmartArt Shape Style**
In this example, we will learn to change the quick style for any SmartArt shape.

1. Create an instance of [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) type and Typecast selected shape to SmartArt if it is SmartArt.
1. Find the SmartArt shape with particular Style.
1. Set the new Style for the SmartArt shape.
1. Save the Presentation.

```java
// Instantiate Presentation Class
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Get first slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Traverse through every shape inside first slide
    for (IShape shape : slide.getShapes()) 
    {
        // Check if shape is of SmartArt type
        if (shape instanceof ISmartArt) 
        {
            // Typecast shape to SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Checking SmartArt style
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Changing SmartArt Style
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Saving presentation
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: SmartArt shape with changed Style**|

## **Change a SmartArt Shape Color Style**
In this example, we will learn to change the color style for any SmartArt shape. In the following sample code will access the SmartArt shape with particular color style and will change its style.

1. Create an instance of [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) type and Typecast selected shape to SmartArt if it is SmartArt.
1. Find the SmartArt shape with particular Color Style.
1. Set the new Color Style for the SmartArt shape.
1. Save the Presentation.

```java
// Instantiate Presentation Class
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Get first slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Traverse through every shape inside first slide
    for (IShape shape : slide.getShapes()) 
    {
        // Check if shape is of SmartArt type
        if (shape instanceof ISmartArt) 
        {
            // Typecast shape to SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Checking SmartArt color type
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Changing SmartArt color type
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Saving presentation
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure: SmartArt shape with changed Color Style**|

## **FAQ**

**Can I animate SmartArt as a single object?**

Yes. SmartArt is a shape, so you can apply [standard animations](/slides/androidjava/powerpoint-animation/) via the animations API (entrance, exit, emphasis, motion paths) just like for other shapes.

**How can I find a specific SmartArt on a slide if I don’t know its internal ID?**

Set and use the Alternative Text (AltText) and search for the shape by that value—this is a recommended way to locate the target shape.

**Can I group SmartArt with other shapes?**

Yes. You can group SmartArt with other shapes (pictures, tables, etc.) and then [manipulate the group](/slides/androidjava/group/).

**How do I get an image of a specific SmartArt (e.g., for a preview or report)?**

Export a thumbnail/image of the shape; the library can [render individual shapes](/slides/androidjava/create-shape-thumbnails/) to raster files (PNG/JPG/TIFF).

**Will the SmartArt appearance be preserved when converting the whole presentation to PDF?**

Yes. The rendering engine targets high fidelity for [PDF export](/slides/androidjava/convert-powerpoint-to-pdf/), with a range of quality and compatibility options.
