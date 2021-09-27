---
title: Clone Slide to Specified Position in Aspose.Slides
type: docs
weight: 20
url: /java/clone-slide-to-specified-position-in-aspose-slides/
---

## **Aspose.Slides - Clone Slide to Specified Position**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the InsertClone method:

1. Create an instance of the Presentation class.
1. Instantiate the ISlideCollection class by referencing the Slides collection exposed by thePresentation object.
1. Call the InsertClone method exposed by the ISlideCollection object and pass the slide to be cloned along with the index for the new position as a parameter to the InsertClonemethod.
1. Write the modified presentation as a PPTX file.

**Java**

``` java

 //Instantiate Presentation class that represents a presentation file

Presentation pres = new Presentation(dataDir + "presentation.pptx");

//Clone the desired slide to the end of the collection of slides in the same presentation

ISlideCollection slds = pres.getSlides();

//Clone the desired slide to the specified index in the same presentation

slds.insertClone(2, pres.getSlides().get_Item(1));

```
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://archive.codeplex.com/?p=asposeslidesjavapptx4j)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://archive.codeplex.com/?p=asposeslidesjavapptx4j)

{{% alert color="primary" %}} 

For more details, visit [Cloning Slides in Presentation ](http://docs.aspose.com:8082/docs/display/slidesjava/Cloning+Slides+in+Presentation#CloningSlidesinPresentation-cloneSlide2).

{{% /alert %}}
