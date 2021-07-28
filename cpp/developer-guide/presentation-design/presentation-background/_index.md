---
title: Presentation Background
type: docs
weight: 20
url: /cpp/presentation-background/
keywords: "PowerPoint presentation background"
description: "PowerPoint presentation background design with Aspose.Slides."
---


In this topic, we will see that how can we set the background color of a slide. We know that Aspose.Slides for C++ may contain two types of slides: **Master Slide** & **Normal Slide**. It is possible to change the background colors of both types of slides, which will be explained in this topic.

## **Set Background Color of Master Slide**
We know that Aspose.Slides for C++ may contain two types of slides: Master Slide & Normal Slide. It is possible to change the background colors of both types of slides. Master Slide is like a template that contains all formatting settings, which are applied on all other normal slides contained inside the presentation. It means that if you change the background color of the master slide, all normal slides in the presentation would receive the same background color settings. Please follow the steps below to change the background color of the master slide:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Set the Background Type of the Slide to OwnBackground.
1. Set the FillType of the Slide Background to Solid.
1. Set the Background Color of the Master Slide of the presentation to any desired color using the [get_SolidFillColor()->get_Color()](https://apireference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a1f535fba3591ce3d22392b613c575a95)method exposed by [FillFormat](https://apireference.aspose.com/slides/cpp/class/aspose.slides.fill_format) object.
1. Write the modified presentation as a presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetBackground-SetSlideBackgroundMaster.cpp" >}}

## **Set Background Color of Normal Slide**
A Normal Slide is the one which inherits its format settings from the master slide. If you want to modify its background settings, you would have to modify the slide settings. Please follow the steps below to perform this task:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Set the Background Type of the Slide to OwnBackground.
- Set the FillType of the Slide Background to Solid.
- Set the Background Color of the Normal Slide of the presentation to any desired color using the **SolidFillColor.Color** property exposed by FillFormat object.
- Write the modified presentation as a presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetBackground-SetSlideBackgroundNormal.cpp" >}}

## **Set Gradient Background Color to Slide**
**Gradient** is a graphic effect consisting of a gradual change in color. It is great for creating depth and highlights to sections of the images. It is possible to apply gradient effect on the background of a slide using Aspose.Slides for C++ that will be explained in the remaining discussion of this topic.

To apply the simple gradient effect on the background of a slide using Aspose.Slides for C++, please follow the steps below:

1. Create an instance of Presentation class.
1. Set the Background Type of the Slide to OwnBackground.
1. Set the FillType of the Slide Background to Gradient.
1. Apply any desired gradient effect from the available options provided by GradientFormatEx object.
1. Write the modified presentation file.

``` cpp
// Instantiate the Presentation class that represents the presentation file
auto pres = System::MakeObject<Presentation>(u"SetBackgroundToGradient.pptx");

// Apply Gradient effect to the Background
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Write the presentation to disk
pres->Save(u"ContentBG_Grad_out.pptx", SaveFormat::Pptx);
```

## **Set Simple Gradient Effect to Slide Background**
To apply the simple gradient effect on the background of a slide using Aspose.Slides for C++, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Set the Background Type of the Slide to OwnBackground.
- Set the FillType of the Slide Background to Gradient.
- Apply any desired gradient effect from the available options provided by GradientFormatEx object.
- Write the modified presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetBackground-SetBackgroundToGradient.cpp" >}}

## **Set Image Background to Slide**
To use an image as the background of a slide using Aspose.Slides for C++, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Set the Background Type of the Slide to OwnBackground.
1. Set the FillType of the Slide Background FillFormat to Picture.
1. Set the PictureFillMode using the options provided by PictureFillMode enum.
1. Instantiate Image class with an image that can be used as source picture for the Slide Background using PictureFillFormat.Picture.Image.
1. Write the modified presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetBackground-SetImageAsBackground.cpp" >}}
## **Get Effective Background Values of Slide**
**Aspose.Slides.IBackgroundEffectiveData** interface and its implementation by **Aspose.Slides.BackgroundEffectiveData** class have been added. They represent effective background of slide and contain information about effective fill format and effective effect format.

**CreateBackgroundEffective** method has been added to **IBaseSlide** interface and **BaseSlide** class. This method allows to get effective values for slides background.

The following code snippet shows how to get effective background values of slide.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetBackgroundEffectiveValues-GetBackgroundEffectiveValues.cpp" >}}
