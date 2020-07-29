---
title: Formatting Slides
type: docs
weight: 40
url: /cpp/formatting-slides/
---

## **Changing the Position of a Slide**
If you create a presentation using MS PowerPoint, you would have experienced that whenever you add a new slide to your presentation, it is appended at the end of the presentation by default. Using MS PowerPoint, you can drag a selected slide to any other position of the presentation. Aspose.Slides for C++ also allows developers to change the position of a slide within the presentation. It's very simple to change the position of a slide in the presentation. Just follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Change the SlideNumber of the referenced slide.
1. Write the modified presentation file.

The example given below moves the slide (that was at position 1 to the second position and the slide that was at second position, is moved to the first position and so on). In this way, all slides are adjusted automatically by Aspose.Slides for C++.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangePosition-ChangePosition.cpp" >}}
## **Generating an SVG Image from a Slide**
Aspose.Slides for C++ is used to create presentation files, complete with slides. These slides can be viewed by opening presentations using Microsoft PowerPoint. But sometimes, developers may also need to view slides as SVG images in their favorite image viewer. In such cases, Aspose.Slides for C++ lets you export an individual slide to an SVG image. This article describes how to use this feature. To generate an SVG image from any desired slide with Aspose.Slides.Pptx for C++, please follow the steps below:

- Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the desired slide's reference by using its ID or index.
- Get the SVG image in a memory stream.
- Save the memory stream to file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSlidesSVGImage-CreateSlidesSVGImage.cpp" >}}
## **Generating an SVG With Custom Shape IDS**
Now Aspose.Slides for C++ can be used to generate SVG from slide with custom shape ID. These slides can be viewed by opening presentations using Microsoft PowerPoint. But sometimes, developers may also need to view slides as SVG images in their favorite image viewer. In such cases, Aspose.Slides for C++ lets you export an individual slide to an SVG image.For that purpose ID property has been added to ISvgShape to support custom IDs of shapes in generated SVG.  To implement this feature a CustomSvgShapeFormattingController has been introduced that you can use to set shape ID.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GeneratingSVGWithCustomShapeIDS-GeneratingSVGWithCustomShapeIDS.cpp" >}}

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomSvgShapeFormattingController-CustomSvgShapeFormattingController.cpp" >}}
## **Creating Slides Thumbnail Image**
Aspose.Slides for C++ is used to create presentation files containing slides. These slides can be viewed by opening presentation files using Microsoft PowerPoint. But sometimes, developers may need to view slides as images using their favorite image viewer. In such cases, Aspose.Slides for C++ help you generate thumbnail images of the slides. To generate the thumbnail of any desired slide using Aspose.Slides for C++:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RenderSlides-ThumbnailFromSlide.cpp" >}}
### **Creating Thumbnail With User Defined Dimensions**
1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ThumbnailWithUserDefinedDimensions-ThumbnailWithUserDefinedDimensions.cpp" >}}
### **Creating thumbnail from a slide in Notes Slides view**
To generate the thumbnail of any desired slide in Notes Slide View using Aspose.Slides for C++:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale in Notes Slide view.
1. Save the thumbnail image in any desired image format.

The code snippet below produces a thumbnail of the first slide of a presentation in Notes Slide View.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ThumbnailFromSlideInNotes-ThumbnailFromSlideInNotes.cpp" >}}
## **Managing Slides Transitions**
Aspose.Slides for C++ also allows developers to manage or customize the slide transition effects of the slides. In this topic, we will discuss how can we control slide transitions with a great ease using Aspose.Slides for C++.
### **Managing Simple Slide Transitions**
To make it easier to understand, we have demonstrated the use of Aspose.Slides for C++ to manage simple slide transitions. Developers can not only apply different slide transition effects on the slides, but also customize the behavior of these transition effects.To create a simple slide transition effect, follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for C++ through TransitionType enum.
1. Write the modified presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}
### **Managing Better Slide Transitions**
In the above section, we just applied a simple transition effect on the slide. Now, to make that simple transition effect even better and controlled, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for C++.
1. You can also set the transition to Advance On Click, after a specific time period or both.
1. If the slide transition is enabled to Advance On Click, the transition will only advance when someone will click the mouse. Moreover, if the Advance After Time property is set, the transition will advance automatically after the specified advance time will be passed.
1. Write the modified presentation as a presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}
### **Setting the transition effects**
Aspose.Slides for C++ supports setting the transition effects like, from black, from left, from right etc. In order to set the Transition Effect. Please follow the steps below:

- Create an instance of Presentation class.
- Get reference of the slide.
- Setting the transition effect.
- Write the presentation as a PPTX file.

In the example given below, we have set the transition effects.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}
