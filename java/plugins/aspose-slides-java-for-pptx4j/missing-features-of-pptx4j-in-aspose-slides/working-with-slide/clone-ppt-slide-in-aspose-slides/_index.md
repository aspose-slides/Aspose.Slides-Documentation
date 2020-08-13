---
title: Clone PPT Slide in Aspose.Slides
type: docs
weight: 10
url: /java/clone-ppt-slide-in-aspose-slides/
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

``` java

 //Instantiate Presentation class that represents a PPTX file

Presentation pres = new Presentation(dataDir + "presentation.pptx");

//Clone the desired slide to the end of the collection of slides in the same PPTX

ISlideCollection slds = pres.getSlides();

slds.addClone(pres.getSlides().get_Item(0));

```
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Cloning Slides in Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Cloning+Slides+in+Presentation).

{{% /alert %}}
