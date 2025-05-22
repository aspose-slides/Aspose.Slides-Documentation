---
title: Manage Presentation Backgrounds in Python
linktitle: Slide Background
type: docs
weight: 20
url: /python-net/presentation-background/
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
- Python
- Aspose.Slides
description: "Learn how to set dynamic backgrounds in PowerPoint and OpenDocument files using Aspose.Slides for Python via .NET, with code tips to boost your presentations."
---

Solid colors, gradient colors, and pictures are often used as background images for slides. You can set the background either for a **normal slide** (single slide) or **master slide** (several slides at once).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Set Solid Color as Background for Normal Slide**

Aspose.Slides allows you to set a solid color as the background for a specific slide in a presentation (even if that presentation contains a master slide). The background change affects only the selected slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Set the [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) enum for the slide to `OwnBackground`.
3. Set the [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) enum for the slide background to `Solid`.
4. Use the [SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) property exposed by [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) to specify a solid color for the background.
5. Save the modified presentation.

This Python code shows you how to set a solid color (blue) as the background for a normal slide:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as pres:
    # Sets the background color for the first ISlide to Blue
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.slides[0].background.fill_format.solid_fill_color.color = draw.Color.blue
    # Writes the presentation to disk
    pres.save("ContentBG_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Solid Color as Background for Master Slide**

Aspose.Slides allows you to set a solid color as the background for the master slide in a presentation. The master slide acts as a template that contains and controls formatting settings for all slides. Therefore, when you select a solid color as the background for the master slide, that new background will be used for all slides.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Set the [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) enum for the master slide (`Masters`) to `OwnBackground`.
3. Set the [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) enum for the master slide background to `Solid`.
4. Use the [SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) property exposed by [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) to specify a solid color for the background.
5. Save the modified presentation.

This Python code shows you how to set a solid color (forest green) as the background for a master slide in a presentation:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as pres:
    # Sets the background color for the Master ISlide to Forest Green
    pres.masters[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.masters[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.masters[0].background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Writes the presentation to disk
    pres.save("SetSlideBackgroundMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Gradient Color as Background for Slide**

A gradient is a graphical effect based on a gradual change in color. Gradient colors, when used as backgrounds for slides, make presentations looks artistic and professional. Aspose.Slides allows you to set a gradient color as the background for slides in presentations.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Set the [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) enum for the slide to `OwnBackground`.
3. Set the [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) enum for the master slide background to `Gradient`.
4. Use the [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) property exposed by [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) to specify your preferred gradient setting.
5. Save the modified presentation.

This Python code shows you how to set a gradient color as the background for a slide:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation(path + "SetBackgroundToGradient.pptx") as pres:
    # Apply Gradient effect to the Background
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.GRADIENT
    pres.slides[0].background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    #Writes the presentation to disk
    pres.save("ContentBG_Grad_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Image as Background for Slide**

Besides solid colors and gradient colors, Aspose.Slides also allows you to set images as the background for slides in presentations.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Set the [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) enum for the slide to `OwnBackground`.
3. Set the [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) enum for the master slide background to `Picture`.
4. Load the image you want to use as the slide background.
5. Add the image to the presentation's image collection.
6. Use the [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) property exposed by [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) to set the image as the background.
7. Save the modified presentation.

This Python code shows you how to set an image as the background for a slide:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation(path + "SetImageAsBackground.pptx") as pres:
    # Sets conditions for background image
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.PICTURE
    pres.slides[0].background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Loads the image
    img = draw.Bitmap(path + "Tulips.jpg")

    # Adds image to presentation's images collection
    imgx = pres.images.add_image(img)

    pres.slides[0].background.fill_format.picture_fill_format.picture.image = imgx

    # Writes the presentation to disk
    pres.save("ContentBG_Img_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Change Transparency of Background Image**

You may want to adjust the transparency of a slide's background image to make the contents of the slide stand out. This Python code shows you how to change the transparency for a slide background image:

```python
transparencyValue = 30 # for example

# Gets a collection of picture transform operations
imageTransform = pres.slides[0].background.fill_format.picture_fill_format.picture.image_transform

transparencyOperation = None
# Finds a transparency effect with fixed percentage.
for operation in imageTransform:
    if type(operation) is slides.AlphaModulateFixed:
        transparencyOperation = operation
        break

# Sets the new transparency value.
if transparencyOperation is None:
    imageTransform.add_alpha_modulate_fixed_effect(100 - transparencyValue)
else:
    transparencyOperation.amount = (100 - transparencyValue)
```

## **Get Value of Slide Background**

Aspose.Slides provides the [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) interface to allow you to get the effective values of slide backgrounds. This interface contains information on the effective [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties) and effective [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties).

Using the [Background](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/#properties) property from the [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) class, you can get the effective value for a slide background.

This Python code shows you how to get a slide's effective background value:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation(path + "SamplePresentation.pptx") as pres:

    effBackground = pres.slides[0].background.get_effective()

    if effBackground.fill_format.fill_type == slides.FillType.SOLID:
        print("Fill color: " + str(effBackground.fill_format.solid_fill_color))
    else:
        print("Fill type: " + str(effBackground.fill_format.fill_type))
```

