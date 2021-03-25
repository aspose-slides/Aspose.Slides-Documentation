---
title: WordArt
type: docs
weight: 231
url: /cpp/wordart/
---


## **WordArt API**
Aspose.Slides for C++ provides IOuterShadow and InnerShadow classes in order to apply shadow effects on the text carried by TextFrame. These classes are available in the Aspose.Slides.Effects namespace and provides a number of properties for handling the shadow effects.

## **Apply Outer Shadow to WordArt**
Aspose.Slides for C++ could be used to apply WordArt Effects on Text. Every WordArt effect has a scheme, for example Accent1, Accent3. In this topic, we will see with examples for how to work with WordArt in Aspose.Slides. In order to apply the scheme of any WordArt. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Get reference of a slide.
- Add an AutoShape of Rectangle type.
- Enable InnerShadowEffect.
- Set all necessary parameters.
- Set ColorType as Scheme.
- Set Scheme Color.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ApplyOuterShadow-ApplyOuterShadow.cpp" >}}

## **Apply Inner Shadow to WordArt**
In order to apply inner shadow. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Get reference of a slide.
- Add an AutoShape of Rectangle type.
- Add inner shadow and set all necessary parameters.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ApplyInnerShadow-ApplyInnerShadow.cpp" >}}

