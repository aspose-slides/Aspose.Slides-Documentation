---
title: Clone PPT Slide using Aspose.Slides
type: docs
weight: 10
url: /java/clone-ppt-slide-using-aspose-slides/
---

## **Aspose.Slides - Clone PPT Slide**
There are several possible ways to clone a slide:

- Cloning a slide from one position to the end of the slides within the same presentation.
- Cloning a slide from one position to another position within the same presentation.
- Cloning a slide from one presentation to another one at the end of the existing collection of slides.
- Cloning a slide from one presentation to another one at a specified position.
- In Another presentation with a master slide from the source presentation at the end of the existing slides.

In Aspose.Slides for Java, SlideCollection (a collection of Slide objects) exposed by the Presentation object provides the AddClone and InsertClone methods to perform the above types of slide cloning.

**Java**

{{< highlight java >}}

 //Instantiate Presentation class that represents a PPTX file

Presentation pres = new Presentation(dataDir + "presentation.pptx");

//Clone the desired slide to the end of the collection of slides in the same PPTX

ISlideCollection slds = pres.getSlides();

slds.addClone(pres.getSlides().get_Item(0));

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/slides/cloneslide/AsposeCloneToEnd.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/slides/cloneslide/AsposeCloneToEnd.java)

{{% alert color="primary" %}} 

For more details, visit [Cloning Slides in Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Cloning+Slides+in+Presentation).

{{% /alert %}}
