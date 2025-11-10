---
title: Manage Presentation Backgrounds in JavaScript
linktitle: Slide Background
type: docs
weight: 20
url: /nodejs-java/presentation-background/
keywords:
- presentation background
- slide background
- solid color
- gradient color
- image background
- background transparency
- background properties
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Learn how to set dynamic backgrounds in PowerPoint and OpenDocument files using Aspose.Slides for Node.js, with code tips to boost your presentations."
---

## **Overview**

Solid colors, gradients, and images are commonly used for slide backgrounds. You can set the background for a **normal slide** (a single slide) or a **master slide** (applies to multiple slides at once).

![PowerPoint background](powerpoint-background.png)

## **Set a Solid Color Background for a Normal Slide**

Aspose.Slides allows you to set a solid color as the background for a specific slide in a presentation—even if the presentation uses a master slide. The change applies only to the selected slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
2. Set the slide’s [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) to `OwnBackground`.
3. Set the slide background [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) to `Solid`.
4. Use the [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) method on [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) to specify the solid background color.
5. Save the modified presentation.

The following JavaScript example shows how to set a blue solid color as the background for a normal slide:

```js
// Create an instance of the Presentation class.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Set the background color of the slide to blue.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Save the presentation to disk.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set a Solid Color Background for the Master Slide**

Aspose.Slides allows you to set a solid color as the background for the master slide in a presentation. The master slide acts as a template that controls formatting for all slides, so when you choose a solid color for the master slide’s background, it applies to every slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
2. Set the master slide’s [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) (via `getMasters`) to `OwnBackground`.
3. Set the master slide background [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) to `Solid`.
4. Use the [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) method to specify the solid background color.
5. Save the modified presentation.

The following JavaScript example shows how to set a solid color (green) as the background for a master slide:

```js
// Create an instance of the Presentation class.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Set the background color for the Master slide to Forest Green.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Save the presentation to disk.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set a Gradient Background for a Slide**

A gradient is a graphical effect created by a gradual change in color. When used as a slide background, gradients can make presentations look more artistic and professional. Aspose.Slides allows you to set a gradient color as the background for slides.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
2. Set the slide’s [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) to `OwnBackground`.
3. Set the slide background [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) to `Gradient`.
4. Use the [getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat) method on [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) to configure your preferred gradient settings.
5. Save the modified presentation.

The following JavaScript example shows how to set a gradient color as the background for a slide:

```js
// Create an instance of the Presentation class.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Apply a gradient effect to the background.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Save the presentation to disk.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set an Image as a Slide Background**

In addition to solid and gradient fills, Aspose.Slides allows you to use images as slide backgrounds.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
2. Set the slide’s [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) to `OwnBackground`.
3. Set the slide background [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) to `Picture`.
4. Load the image you want to use as the slide background.
5. Add the image to the presentation’s image collection.
6. Use the [getPictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) method on [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) to assign the image as the background.
7. Save the modified presentation.

The following JavaScript example shows how to set an image as the background for a slide:

```js
// Create an instance of the Presentation class.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Set background image properties.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Load the image.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Add the image to the presentation's image collection.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Save the presentation to disk.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The following code sample shows how to set the background fill type to a tiled picture and modify the tiling properties:

```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Set the image used for the background fill.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Set the picture fill mode to Tile and adjust the tile properties.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

Read more: [**Tile Picture As Texture**](/slides/nodejs-java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Change the Background Image Transparency**

You may want to adjust the transparency of a slide's background image to make the contents of the slide stand out. The following JavaScript code shows you how to change the transparency for a slide background image:

```js
var transparencyValue = 30; // For example.

// Get the collection of picture transform operations.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Get the Slide Background Value**

Aspose.Slides provides the `BackgroundEffectiveData` class for retrieving a slide’s effective background values. This class exposes the effective [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) and [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/).

Using the [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/) class’s `getBackground` method, you can obtain the effective background for a slide.

The following JavaScript example shows how to get a slide’s effective background value:

```js
// Create an instance of the Presentation class.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Retrieve the effective background, taking into account master, layout, and theme.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Can I reset a custom background and restore the theme/layout background?**

Yes. Remove the slide’s custom fill, and the background will be inherited again from the corresponding [layout](/slides/nodejs-java/slide-layout/)/[master](/slides/nodejs-java/slide-master/) slide (i.e., the [theme background](/slides/nodejs-java/presentation-theme/)).

**What happens to the background if I change the presentation’s theme later?**

If a slide has its own fill, it will remain unchanged. If the background is inherited from the [layout](/slides/nodejs-java/slide-layout/)/[master](/slides/nodejs-java/slide-master/), it will update to match the [new theme](/slides/nodejs-java/presentation-theme/).
