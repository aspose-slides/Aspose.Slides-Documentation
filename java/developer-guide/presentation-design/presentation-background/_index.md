---
title: Presentation Background
type: docs
weight: 20
url: /java/presentation-background/
keywords: "PowerPoint background in Java"
description: "PowerPoint background in Java"
---


## Overview
In this topic, we will see that how can we set the background color of a slide. We know that Aspose.Slides for Java may contain two types of slides: **Master Slide** & **Normal Slide**. It is possible to change the background colors of both types of slides, which will be explained in this topic.

## **Set Background Color to Master Slide**
We know that Aspose.Slides for Java may contain two types of slides: Master Slide & Normal Slide. It is possible to change the background colors of both types of slides. Master Slide is like a template that contains all formatting settings, which are applied on all other normal slides contained inside the presentation. It means that if you change the background color of the master slide, all normal slides in the presentation would receive the same background color settings. Please follow the steps below to change the background color of the master slide:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Set the Background Type of the Slide to OwnBackground.
1. Set the FillType of the Slide Background to Solid.
1. Set the Background Color of the Master Slide of the presentation to any desired color using the [getSolidFillColor](https://apireference.aspose.com/slides/java/com.aspose.slides/FillFormat#getSolidFillColor--).[setColor](https://apireference.aspose.com/slides/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) method exposed by [FillFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/FillFormat) object.
1. Write the modified presentation as a presentation file.

```java
// Instantiate the Presentation class that represents the presentation file
Presentation pres = new Presentation();
try {
    // Set the background color of the Master ISlide to Green
    pres.getMasters().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    
    // Write the presentation to disk
    pres.save("MasterBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Background Color to Normal Slide**
A Normal Slide is the one which inherits its format settings from the master slide. If you want to modify its background settings, you would have to modify the slide settings. Please follow the steps below to perform this task:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Set the Background Type of the Slide to OwnBackground.
- Set the FillType of the Slide Background to Solid.
- Set the Background Color of the Normal Slide of the presentation to any desired color using the [**getSolidFillColor**](https://apireference.aspose.com/slides/java/com.aspose.slides/FillFormat#getSolidFillColor--).[setColor](https://apireference.aspose.com/slides/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) method exposed by [FillFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/FillFormat) object.
- Write the modified presentation as a presentation file.

```java
// Instantiate the PFresentation class that represents the presentation file
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // Set the background color of the first ISlide to Blue
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("ContentBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Set Gradient Background Color to Slide
**Gradient** is a graphic effect consisting of a gradual change in color. It is great for creating depth and highlights to sections of the images. It is possible to apply gradient effect on the background of a slide using Aspose.Slides for Java that will be explained in the remaining discussion of this topic.

To apply the simple gradient effect on the background of a slide using Aspose.Slides for Java, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Set the Background Type of the Slide to OwnBackground.
- Set the FillType of the Slide Background to Gradient.
- Apply any desired gradient effect from the available options provided by [GradientFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/IGradientFormat) object.
- Write the modified presentation file.

```java
// Instantiate the Presentation class that represents the presentation file
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // Apply Gradient effect to the Background
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Gradient);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);
    
    // Write the presentation to disk
    pres.save("ContentBG_Grad.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Set Image as Background to Slide
Sometimes, developers may need to use an image as the background of the slide. To fulfill such development needs, Aspose.Slides for Java also allows filling the slide background with any image.

To use an image as the background of a slide using Aspose.Slides for Java, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Set the Background Type of the Slide to OwnBackground.
1. Set the FillType of the Slide Background FillFormat to Picture.
1. Set the PictureFillMode using the options provided by PictureFillMode enum.
1. Instantiate Image class with an image that can be used as source picture for the Slide Background using PictureFillFormat.Picture.Image.
1. Write the modified presentation file.

```java
// Instantiate the Presentation class that represents the presentation file
Presentation pres = new Presentation();
try {
    // Set the background with Image
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Picture);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat()
            .setPictureFillMode(PictureFillMode.Stretch);
    
    // Set the picture
    IPPImage imgx = pres.getImages().addImage(Files.readAllBytes(Paths.get("Desert.jpg")));
    
    // Add image to presentation's images collection
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(imgx);
    
    // Write the presentation to disk
    pres.save("ContentBG_Img.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Get Effective Background Values of Slide**
[**IBackgroundEffectiveData**](https://apireference.aspose.com/slides/java/com.aspose.slides/IBackgroundEffectiveData) interface and its implementation by [**BackgroundEffectiveData**](https://apireference.aspose.com/slides/java/com.aspose.slides/BackgroundEffectiveData) class have been added. They represent effective background of slide and contain information about effective fill format and effective effect format.

[**getBackground()**](https://apireference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--).[**getEffective()**](https://apireference.aspose.com/slides/java/com.aspose.slides/IBackground#getEffective--) method has been added to [**IBaseSlide**](https://apireference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) interface and [**BaseSlide**](https://apireference.aspose.com/slides/java/com.aspose.slides/BaseSlide) class. This method allows to get effective values for slides background.

The following code snippet shows how to get effective background values of slide.

```java
// Instantiate the Presentation class that represents the presentation file
Presentation pres = new Presentation("SamplePresentation.pptx");
try {
    IBackgroundEffectiveData effBackground = pres.getSlides().get_Item(0).getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    if (pres != null) pres.dispose();
}
```