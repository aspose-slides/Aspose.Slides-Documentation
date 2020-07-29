---
title: PowerPoint Word Art
type: docs
weight: 50
url: /net/powerpoint-word-art/
keywords: "Word Art Powerpoint presentation"
description: "Word Art Powerpoint presentation with Aspose.Slides."
---

Aspose.Slides for .NET provides 
[**IOuterShadow**](https://apireference.aspose.com/net/slides/aspose.slides.effects/ioutershadow) and
 [**IInnerShadow**](https://apireference.aspose.com/net/slides/aspose.slides.effects/iinnershadow) classes 
 in order to apply shadow effects on the text carried by TextFrame. These classes are available in the [**Aspose.Slides.Effects**](https://apireference.aspose.com/net/slides/aspose.slides.effects/) namespace and provides a number of properties for handling the shadow effects.
## **Apply Outer Shadow to WordArt**
Please follow the steps below to apply shadow effects on the text in a [PPTX](https://wiki.fileformat.com/presentation/pptx/) presentation using Aspose.Slides for .NET :

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Rectangle type to the slide.
- Access the TextFrame associated with the AutoShape.
- Set the FillType of the AutoShape to NoFill.
- Instantiate OuterShadow class
- Set the BlurRadius of the shadow.
- Set the Direction of the shadow
- Set the Distance of the shadow.
- Set the RectanglelAlign to TopLeft.
- Set the PresetColor of the shadow to Black.
- Write the presentation as a PPTX file.

The implementation of the above steps is given below.



{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-ShadowEffects-ShadowEffects.cs" >}}
## **Apply Inner Shadow to WordArt**
Aspose.Slides for .NET could be used to apply WordArt Effects on Text. Every WordArt effect has a scheme, for example Accent1, Accent3. In this topic, we will see with examples for how to work with WordArt in Aspose.Slides. In order to apply the scheme of any WordArt. Please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Get reference of a slide.
- Add an AutoShape of Rectangle type.
- Enable InnerShadowEffect.
- Set all necessary parameters.
- Set ColorType as Scheme.
- Set Scheme Color.
- Write the presentation as a [PPTX](https://wiki.fileformat.com/presentation/pptx/) file.

In the example given below, we have added a connector between two shapes.



{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-ApplyOuterShadow-ApplyOuterShadow.cs" >}}
