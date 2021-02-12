---
title: Presentation Background
type: docs
weight: 20
url: /java/presentation-background/
keywords: "PowerPoint background in Java"
description: "PowerPoint background in Java"
---

## **Overview**
{{% alert color="primary" %}} 

In this topic, we will see that how can we set the background color of a slide. We know that Aspose.Slides for Java may contain two types of slides: **Master Slide** & **Normal Slide**. It is possible to change the background colors of both types of slides, which will be explained in this topic.

{{% /alert %}} 
## **Set Background Color to Master Slide**
We have discussed in previous topics that a **Master Slide** is like a template that contains all formatting settings, which are applied on all other normal slides contained inside the presentation. It means that if you change the background color of the master slide, all normal slides in the presentation would receive the same background color settings. Please follow the steps below to change the background color of the master slide:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Set the Background Type of the Slide to OwnBackground.
- Set the FillType of the Slide Background to Solid.
- Set the Background Color of the Master Slide of the presentation to any desired color using the SolidFillColor.Color property exposed by FillFormat object.
- Write the modified presentation as a presentation file.


{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Background-SettingTheBackgroundColorOfAMasterSlide-SettingTheBackgroundColorOfAMasterSlide.java" >}}

|![todo:image_alt_text](http://i.imgur.com/5lgAcw3.jpg)|
| :- |
|**Figure: Background of the Master Slide changed to Forest Green**|
## **Set Background Color to Normal Slide**
A **Normal Slide** is that one that inherits its format settings from the master slide. If you want to modify its background settings, you would have to modify the slide settings. Please follow the steps below to perform this task:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Set the Background Type of the Slide to OwnBackground.
- Set the FillType of the Slide Background to Solid.
- Set the Background Color of the Normal Slide of the presentation to any desired color using the SolidFillColor.Color property exposed by FillFormat object.
- Write the modified presentation as a presentation file.



{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Background-SettingTheBackgroundColorOfANormalSlide-SettingTheBackgroundColorOfANormalSlide.java" >}}

|![todo:image_alt_text](http://i.imgur.com/8mRnA2W.jpg)|
| :- |
|**Figure: Background of the Normal Slide changed to blue**|

## **Set Gradient Background Color to Slide**
{{% alert color="primary" %}} 

**Gradient** is a graphic effect consisting of a gradual change in color. It is great for creating depth and highlights to sections of the images. It is possible to apply gradient effect on the background of a slide using Aspose.Slides for Java that will be explained in the remaining discussion of this topic.

{{% /alert %}} 

To apply the simple gradient effect on the background of a slide using Aspose.Slides for Java, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Set the Background Type of the Slide to OwnBackground.
- Set the FillType of the Slide Background to Gradient.
- Apply any desired gradient effect from the available options provided by GradientFormatEx object.
- Write the modified presentation file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Background-SettingTheBackgroundColorToAGradientToSlides-SettingTheBackgroundColorToAGradientToSlides.java" >}}

|![todo:image_alt_text](http://i.imgur.com/kHXkBIc.jpg)|
| :- |
|**Figure : Background of the Slide changed to gradient**|

## **Set Image Background to Slide**
{{% alert color="primary" %}} 

Sometimes, developers may need to use an image as the background of the slide. To fulfil such development needs, Aspose.Slides for Java also allows filling the slide background with any image. Please refer to the details given below to use this feature.

{{% /alert %}} 

To use an image as the background of a slide using Aspose.Slides for Java, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Set the Background Type of the Slide to OwnBackground.
- Set the FillType of the Slide Background FillFormat to Picture.
- Set the PictureFillMode using the options provided by PictureFillMode enum.
- Instantiate Image class with an image that can be used as source picture for the Slide Background using PictureFillFormat.Picture.Image
- Write the modified presentation file

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Background-SettingTheImageAsBackgroundToSlides-SettingTheImageAsBackgroundToSlides.java" >}}


## **Get Effective Background Values of Slide**
**Aspose.Slides.IBackgroundEffectiveData** interface and its implementation by **Aspose.Slides.BackgroundEffectiveData** class have been added. They represent effective background of slide and contain information about effective fill format and effective effect format.

**CreateBackgroundEffective** method has been added to **IBaseSlide** interface and **BaseSlide** class. This method allows to get effective values for slides background.

The following code snippet shows how to get effective background values of slide.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Background-GetBackgroundEffectiveValues-GetBackgroundEffectiveValues.java" >}}
