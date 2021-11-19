---
title: Managing Slide Transitions using Aspose.Slides
type: docs
weight: 30
url: /java/managing-slide-transitions-using-aspose-slides/
---

## **Aspose.Slides - Managing Slide Transitions**
To make it easier to understand, we have demonstrated the use of Aspose.Slides for Java to manage simple slide transitions. Developers can not only apply different slide transition effects on the slides, but also customize the behavior of these transition effects.To create a simple slide transition effect, follow the steps below:

- Create an instance of Presentation class
- Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for Java through **TransitionType** enum
- Write the modified presentation file

**Java**

{{< highlight java >}}

 //Instantiate Presentation class that represents a presentation file

Presentation pres = new Presentation(dataDir + "presentation.pptx");

//Apply circle type transition on slide 1

pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

//Apply comb type transition on slide 2

pres.getSlides().get_Item(1).getSlideShowTransition().setType( TransitionType.Comb);

//Apply zoom type transition on slide 3

pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);

//Write the presentation to disk

pres.save(dataDir + "AsposeTransition.pptx",SaveFormat.Pptx);

System.out.println("First Transition File is saved.");

//==============================================================

//Instantiate a Presentation object that represents a PPT file

Presentation presentation = new Presentation(dataDir + "presentation.pptx");

//Apply circle type transition on slide 1

presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);


//Set the transition time of 3 seconds

//Set the transition time of 5 seconds

presentation.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick( true);

presentation.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime (3000);

//Apply comb type transition on slide 2

presentation.getSlides().get_Item(1).getSlideShowTransition().setType( TransitionType.Comb);


//Set the transition time of 5 seconds

presentation.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick( true);

presentation.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime (5000);

//Apply zoom type transition on slide 3

presentation.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);

//Set the transition time of 7 seconds

presentation.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick( true);

presentation.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime (7000);

//Write the presentation to disk

presentation.save(dataDir + "AsposeTransition2.pptx",SaveFormat.Pptx);

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/slides/slidetransitions/AsposeTransitions.java)

{{% alert color="primary" %}} 

For more details, visit [Managing Slides Transitions](http://docs.aspose.com:8082/docs/display/slidesjava/Managing+Slides+Transitions).

{{% /alert %}}
