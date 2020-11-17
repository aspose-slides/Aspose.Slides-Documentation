---
title: Presentation Background
type: docs
weight: 20
url: /net/presentation-background/
keywords: "PowerPoint presentation background"
description: "PowerPoint presentation background design with Aspose.Slides."
---

## Overview
In this topic, we will see that how can we set the background color of a slide. We know that Aspose.Slides for .NET may contain two types of slides: **Master Slide** & **Normal Slide**. It is possible to change the background colors of both types of slides, which will be explained in this topic.
## **Set Background Color to Master Slide**
We know that Aspose.Slides for .NET may contain two types of slides: Master Slide & Normal Slide. It is possible to change the background colors of both types of slides. Master Slide is like a template that contains all formatting settings, which are applied on all other normal slides contained inside the presentation. It means that if you change the background color of the master slide, all normal slides in the presentation would receive the same background color settings. Please follow the steps below to change the background color of the master slide:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Set the Background Type of the Slide to OwnBackground.
1. Set the FillType of the Slide Background to Solid.
1. Set the Background Color of the Master Slide of the presentation to any desired color using the [SolidFillColor.Color](https://apireference.aspose.com/net/slides/aspose.slides/fillformat/properties/solidfillcolor) property exposed by [FillFormat](https://apireference.aspose.com/net/slides/aspose.slides/fillformat) object.
1. Write the modified presentation as a presentation file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Background-SetSlideBackgroundMaster-SetSlideBackgroundMaster.cs" >}}
## **Set Background Color to Normal Slide**
A Normal Slide is the one which inherits its format settings from the master slide. If you want to modify its background settings, you would have to modify the slide settings. Please follow the steps below to perform this task:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Set the Background Type of the Slide to OwnBackground.
- Set the FillType of the Slide Background to Solid.
- Set the Background Color of the Normal Slide of the presentation to any desired color using the **SolidFillColor.Color** property exposed by FillFormat object.
- Write the modified presentation as a presentation file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Background-SetSlideBackgroundNormal-SetSlideBackgroundNormal.cs" >}}
## Set Gradient Background Color to Slide
**Gradient** is a graphic effect consisting of a gradual change in color. It is great for creating depth and highlights to sections of the images. It is possible to apply gradient effect on the background of a slide using Aspose.Slides for .NET that will be explained in the remaining discussion of this topic.

To apply the simple gradient effect on the background of a slide using Aspose.Slides for .NET, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Set the Background Type of the Slide to OwnBackground.
- Set the FillType of the Slide Background to Gradient.
- Apply any desired gradient effect from the available options provided by GradientFormatEx object.
- Write the modified presentation file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Background-SetBackgroundToGradient-SetBackgroundToGradient.cs" >}}
## Set Image as Background to Slide
Sometimes, developers may need to use an image as the background of the slide. To fulfill such development needs, Aspose.Slides for .NET also allows filling the slide background with any image.

To use an image as the background of a slide using Aspose.Slides for .NET, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Set the Background Type of the Slide to OwnBackground.
1. Set the FillType of the Slide Background FillFormat to Picture.
1. Set the PictureFillMode using the options provided by PictureFillMode enum.
1. Instantiate Image class with an image that can be used as source picture for the Slide Background using PictureFillFormat.Picture.Image.
1. Write the modified presentation file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Background-SetImageAsBackground-SetImageAsBackground.cs" >}}
## **Get Effective Background Values of Slide**
**Aspose.Slides.IBackgroundEffectiveData** interface and its implementation by **Aspose.Slides.BackgroundEffectiveData** class have been added. They represent effective background of slide and contain information about effective fill format and effective effect format.

**CreateBackgroundEffective** method has been added to **IBaseSlide** interface and **BaseSlide** class. This method allows to get effective values for slides background.

The following code snippet shows how to get effective background values of slide.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Slides-Background-GetBackgroundEffectiveValues-GetBackgroundEffectiveValues.cs" >}}
