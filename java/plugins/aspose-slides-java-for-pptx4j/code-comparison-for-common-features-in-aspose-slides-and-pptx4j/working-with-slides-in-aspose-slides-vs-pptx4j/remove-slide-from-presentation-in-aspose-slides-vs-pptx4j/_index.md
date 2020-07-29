---
title: Remove Slide from Presentation in Aspose.Slides vs pptx4j
type: docs
weight: 60
url: /java/remove-slide-from-presentation-in-aspose-slides-vs-pptx4j/
---

## **Aspose.Slides - Remove Slide from Presentation**
Sometimes, developers may need to remove a slide from the presentation due to any reason. Aspose.Slides for Java offers few methods to do so. 

We know that **Presentation** class in Aspose.Slides for Java represents a presentation file. **Presentation** class encapsulates a **ISlideCollection** that acts as a repository of all slides that are the part of the presentation. Developers can remove a slide from this **Slides** collection in two ways:

- Using Slide Reference
- Using Slide Index

**Java**

{{< highlight java >}}

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(dataDir + "presentation.pptx");

//Accessing a slide using its index in the slides collection

ISlide slide = pres.getSlides().get_Item(1);

//Removing a slide using its reference

pres.getSlides().remove(slide);

//Removing a slide using its slide index

pres.getSlides().removeAt(0);

{{< /highlight >}}
## **pptx4j - Remove Slide from Presentation**
Slides can be removed using MainPresentationPart.removeSlide(Relationship).

**Java**

{{< highlight java >}}

 String inputfilepath = dataDir + "presentation.pptx";

PresentationMLPackage presentationMLPackage =

	(PresentationMLPackage)OpcPackage.load(new java.io.File(inputfilepath));

MainPresentationPart mpp = presentationMLPackage.getMainPresentationPart();

//mpp.removeSlide(10);

Relationship rel = mpp.getRelationshipsPart().getRelationshipByID("rId2");

mpp.removeSlide(rel);

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Removing Slides from a Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Removing+Slides+from+a+Presentation).

{{% /alert %}}
