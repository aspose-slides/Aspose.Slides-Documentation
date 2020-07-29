---
title: Delete Slides from Presentation using Apache POI and Aspose.Slides
type: docs
weight: 40
url: /java/delete-slides-from-presentation-using-apache-poi-and-aspose-slides/
---

## **Aspose.Slides - Delete Slides from Presentation**
Sometimes, developers may need to remove a slide from the presentation due to any reason. Aspose.Slides for Java offers few methods to do so. 

We know that **Presentation** class in Aspose.Slides for Java represents a presentation file. **Presentation** class encapsulates a **ISlideCollection** that acts as a repository of all slides that are the part of the presentation. Developers can remove a slide from this **Slides** collection in two ways:

- Using Slide Reference
- Using Slide Index

**Java**

{{< highlight java >}}

 //Instantiate a PresentationEx object that represents a PPTX file

Presentation pres = new Presentation(dataDir + "presentation.pptx");

pres.getSlides().removeAt(1); //Removing a slide using its index

//===========================================================

//Accessing a slide using its index in the slides collection

ISlide slide = pres.getSlides().get_Item(0);

pres.getSlides().remove(slide); //Removing a slide using its reference

{{< /highlight >}}
## **Apache POI SL - HSLF XSLF - Delete Slides from Presentation**
Slides can be deleted by calling removeSlide from the presentation and passing the index of the slide to be deleted while using Apache POI SL.

**Java**

{{< highlight java >}}

 XMLSlideShow ppt = new XMLSlideShow(new FileInputStream(dataDir + "presentation.pptx"));

ppt.removeSlide(0); // 0-based index of a slide to be removed


{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/featurescomparison/presentation/deleteslides/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/presentation/deleteslides)

{{% alert color="primary" %}} 

For more details, visit [Removing Slides from a Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Removing+Slides+from+a+Presentation).

{{% /alert %}}
