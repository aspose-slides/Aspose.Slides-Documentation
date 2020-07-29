---
title: Add Slides to Presentation using Apache POI and Aspose.Slides
type: docs
weight: 10
url: /java/add-slides-to-presentation-using-apache-poi-and-aspose-slides/
---

## **Aspose.Slides - Add Slides to Presentation**
Aspose.Slides for Java allows developers to add empty slides to their presentation. To add an empty slide in the presentation, please follow the steps below:

- Create an instance of Presentation class
- Instantiate ISlideCollection class by setting a reference to the Slides (collection of content Slide objects) property exposed by the Presentation object.
- Add an empty slide to the presentation at the end of the content slides collection by calling the AddEmptySlide methods exposed by ISlideCollection object
- Do some work with the newly added empty slide
- Finally, write the presentation file using the Presentation object

**Java**

{{< highlight java >}}

 //Instantiate a PresentationEx object that represents a PPTX file

Presentation pres = new Presentation(dataDir + "presentation.pptx");

//Add Slide

ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));


{{< /highlight >}}
## **Apache POI SL - HSLF XSLF - Add Slides to Presentation**
New slide can be added to presentation by SlideShow.createSlide method using Apache POI SL - HSLF and XSLF.

**Java**

{{< highlight java >}}

 //create a new empty slide show

SlideShow ppt = new SlideShow();

//add first slide

Slide s1 = ppt.createSlide();

//add second slide

Slide s2 = ppt.createSlide();


{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/featurescomparison/presentation/addslides/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/presentation/addslides)

{{% alert color="primary" %}} 

For more details, visit [Adding Slides to Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Adding+Slides+to+Presentation).

{{% /alert %}}
