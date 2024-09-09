---
title: Convert PowerPoint to PNG
type: docs
weight: 30
url: /java/convert-powerpoint-to-png/
keywords: PowerPoint to PNG, PPT to PNG, PPTX to PNG, java, Aspose.Slides for Java
description: Convert PowerPoint presentation to PNG
---

## **About PowerPoint to PNG Conversion**

The PNG (Portable Network Graphics) format is not as popular as JPEG (Joint Photographic Experts Group), but it still very popular. 

**Use case:** When you have a complex image and size is not an issue, PNG is a better image format than JPEG. 

{{% alert title="Tip" color="primary" %}} You may want to check out Aspose free **PowerPoint to PNG Converters**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) and [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). They are a live implementation of the process described on this page. {{% /alert %}}

## **Convert PowerPoint to PNG**

Go through these steps:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Get the slide object from the [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) collection under the [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) interface. 
3. Use a [ISlide.getImage()](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) method to get the thumbnail for each slide.
4. Use the  [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) method to save the slide thumbnail to the PNG format.

This Java code shows you how to convert a PowerPoint presentation to PNG:

```javascript
    var pres = new  com.aspose.slides.Presentation("pres.pptx");
    try {
        for (var index = 0; index < pres.getSlides().size(); index++) {
            var slide = pres.getSlides().get_Item(index);
            var slideImage = slide.getImage();
            try {
                slideImage.save(("image_java_" + index) + ".png", com.aspose.slides.ImageFormat.Png);
            } finally {
                if (slideImage != null) {
                    slideImage.dispose();
                }
            }
        }
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Convert PowerPoint to PNG With Custom Dimensions**

If you want to obtain PNG files around a certain scale, you can set the values for `desiredX` and `desiredY`, which determine the dimensions of the resulting thumbnail. 

This code in Java demonstrates the described operation:

```javascript
    var pres = new  com.aspose.slides.Presentation("pres.pptx");
    try {
        var scaleX = 2.0;
        var scaleY = 2.0;
        for (var index = 0; index < pres.getSlides().size(); index++) {
            var slide = pres.getSlides().get_Item(index);
            var slideImage = slide.getImage(scaleX, scaleY);
            try {
                slideImage.save(("image_java_" + index) + ".png", com.aspose.slides.ImageFormat.Png);
            } finally {
                if (slideImage != null) {
                    slideImage.dispose();
                }
            }
        }
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Convert PowerPoint to PNG With Custom Size**

If you want to obtain PNG files around a certain size, you can pass your preferred `width` and `height` arguments for `ImageSize`. 

This code shows you how to convert a PowerPoint to PNG while specifying the size for the images: 

```javascript
    var pres = new  com.aspose.slides.Presentation("pres.pptx");
    try {
        var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
        for (var index = 0; index < pres.getSlides().size(); index++) {
            var slide = pres.getSlides().get_Item(index);
            var slideImage = slide.getImage(size);
            try {
                slideImage.save(("image_java_" + index) + ".png", com.aspose.slides.ImageFormat.Png);
            } finally {
                if (slideImage != null) {
                    slideImage.dispose();
                }
            }
        }
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

