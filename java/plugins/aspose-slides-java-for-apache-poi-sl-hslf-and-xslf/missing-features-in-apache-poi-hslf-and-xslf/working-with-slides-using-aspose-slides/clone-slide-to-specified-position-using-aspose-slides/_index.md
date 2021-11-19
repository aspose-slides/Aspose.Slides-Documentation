---
title: Clone Slide to Specified Position using Aspose.Slides
type: docs
weight: 20
url: /java/clone-slide-to-specified-position-using-aspose-slides/
---

## **Aspose.Slides - Clone Slide to Specified Position**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the InsertClone method:

1. Create an instance of the Presentation class.
1. Instantiate the ISlideCollection class by referencing the Slides collection exposed by thePresentation object.
1. Call the InsertClone method exposed by the ISlideCollection object and pass the slide to be cloned along with the index for the new position as a parameter to the InsertClonemethod.
1. Write the modified presentation as a PPTX file.

**Java**

{{< highlight java >}}

 //Instantiate Presentation class that represents a presentation file

Presentation pres = new Presentation(dataDir + "presentation.pptx");

//Clone the desired slide to the end of the collection of slides in the same presentation

ISlideCollection slds = pres.getSlides();

//Clone the desired slide to the specified index in the same presentation

slds.insertClone(2, pres.getSlides().get_Item(1));

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/slides/cloneslidetospecificposition/AsposeCloneToSpecifiedPosition.java)

{{% alert color="primary" %}} 

For more details, visit [Cloning Slides in Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Cloning+Slides+in+Presentation#CloningSlidesinPresentation-cloneSlide2).

{{% /alert %}}
