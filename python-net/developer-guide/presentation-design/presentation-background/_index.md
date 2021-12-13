---
title: Presentation Background
type: docs
weight: 20
url: /python-net/presentation-background/
keywords: "PowerPoint background, set background, Python, Aspose.Slides for Python via .NET"
description: "Set background in PowerPoint presentation in Python"
---

## Overview
In this topic, we will see that how can we set the background color of a slide. We know that Aspose.Slides for Python via .NET may contain two types of slides: **Master Slide** & **Normal Slide**. It is possible to change the background colors of both types of slides, which will be explained in this topic.
## **Setting Background Color for Master Slides**
We know that Aspose.Slides for Python via .NET may contain two types of slides: Master Slide & Normal Slide. It is possible to change the background colors of both types of slides. Master Slide is like a template that contains all formatting settings, which are applied on all other normal slides contained inside the presentation. It means that if you change the background color of the master slide, all normal slides in the presentation would receive the same background color settings. Please follow the steps below to change the background color of the master slide:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation) class.
1. Set the Background Type of the Slide to OwnBackground.
1. Set the FillType of the Slide Background to Solid.
1. Set the Background Color of the Master Slide of the presentation to any desired color using the [SolidFillColor.Color](https://apireference.aspose.com/slides/python-net/aspose.slides/fillformat/properties/solidfillcolor) property exposed by [FillFormat](https://apireference.aspose.com/slides/python-net/aspose.slides/fillformat) object.
1. Write the modified presentation as a presentation file.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class that represents the presentation file
with slides.Presentation() as pres:
    # Set the background color of the Master ISlide to Forest Green
    pres.masters[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.masters[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.masters[0].background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Write the presentation to disk
    pres.save("SetSlideBackgroundMaster_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Setting Background Color to Normal Slides**
A Normal Slide is the one which inherits its format settings from the master slide. If you want to modify its background settings, you would have to modify the slide settings. Please follow the steps below to perform this task:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation) class.
- Set the Background Type of the Slide to OwnBackground.
- Set the FillType of the Slide Background to Solid.
- Set the Background Color of the Normal Slide of the presentation to any desired color using the **SolidFillColor.Color** property exposed by FillFormat object.
- Write the modified presentation as a presentation file.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class that represents the presentation file
with slides.Presentation() as pres:
    # Set the background color of the first ISlide to Blue
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.slides[0].background.fill_format.solid_fill_color.color = draw.Color.blue
    pres.save("ContentBG_out.pptx", slides.export.SaveFormat.PPTX)
```


## Setting Gradient Background Color for Slides
**Gradient** is a graphic effect consisting of a gradual change in color. It is great for creating depth and highlights to sections of the images. It is possible to apply gradient effect on the background of a slide using Aspose.Slides for Python via .NET that will be explained in the remaining discussion of this topic.

To apply the simple gradient effect on the background of a slide using Aspose.Slides for Python via .NET, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation) class.
- Set the Background Type of the Slide to OwnBackground.
- Set the FillType of the Slide Background to Gradient.
- Apply any desired gradient effect from the available options provided by GradientFormatEx object.
- Write the modified presentation file.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class that represents the presentation file
with slides.Presentation(path + "SetBackgroundToGradient.pptx") as pres:
    # Apply Gradiant effect to the background
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.GRADIENT
    pres.slides[0].background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    #Write the presentation to disk
    pres.save("ContentBG_Grad_out.pptx", slides.export.SaveFormat.PPTX)
```


## Setting Images as Background for Slides
Sometimes, developers may need to use an image as the background of the slide. To fulfill such development needs, Aspose.Slides for Python via .NET also allows filling the slide background with any image.

To use an image as the background of a slide using Aspose.Slides for Python via .NET, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation) class.
1. Set the Background Type of the Slide to OwnBackground.
1. Set the FillType of the Slide Background FillFormat to Picture.
1. Set the PictureFillMode using the options provided by PictureFillMode enum.
1. Instantiate Image class with an image that can be used as source picture for the Slide Background using PictureFillFormat.Picture.Image.
1. Write the modified presentation file.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class that represents the presentation file
with slides.Presentation(path + "SetImageAsBackground.pptx") as pres:
    # Set the background with Image
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.PICTURE
    pres.slides[0].background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Set the picture
    img = draw.Bitmap(path + "Tulips.jpg")

    # Add image to presentation's images collection
    imgx = pres.images.add_image(img)

    pres.slides[0].background.fill_format.picture_fill_format.picture.image = imgx

    # Write the presentation to disk
    pres.save("ContentBG_Img_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Getting Effective Background Values of Slides**
**Aspose.Slides.IBackgroundEffectiveData** interface and its implementation by **Aspose.Slides.BackgroundEffectiveData** class have been added. They represent effective background of slide and contain information about effective fill format and effective effect format.

**CreateBackgroundEffective** method has been added to **IBaseSlide** interface and **BaseSlide** class. This method allows to get effective values for slides background.

The following code snippet shows how to get effective background values of slide.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class that represents the presentation file
with slides.Presentation(path + "SamplePresentation.pptx") as pres:

    effBackground = pres.slides[0].background.get_effective()

    if effBackground.fill_format.fill_type == slides.FillType.SOLID:
        print("Fill color: " + str(effBackground.fill_format.solid_fill_color))
    else:
        print("Fill type: " + str(effBackground.fill_format.fill_type))
```

