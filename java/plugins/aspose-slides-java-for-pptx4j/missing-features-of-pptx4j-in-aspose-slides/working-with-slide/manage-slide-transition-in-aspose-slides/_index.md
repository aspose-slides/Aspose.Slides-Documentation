---
title: Manage Slide Transition in Aspose.Slides
type: docs
weight: 30
url: /java/manage-slide-transition-in-aspose-slides/
---

## **Aspose.Slides - Manage Slide Transition**
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

//===============================================

//Apply circle type transition on slide 4

pres.getSlides().get_Item(3).getSlideShowTransition().setType(TransitionType.Circle);

//Set the transition time of 3 seconds

presentation.getSlides().get_Item(3).getSlideShowTransition().setAdvanceOnClick( true);

presentation.getSlides().get_Item(3).getSlideShowTransition().setAdvanceAfterTime (3000);

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Managing Slides Transitions](http://docs.aspose.com:8082/docs/display/slidesjava/Managing+Slides+Transitions).

{{% /alert %}}
