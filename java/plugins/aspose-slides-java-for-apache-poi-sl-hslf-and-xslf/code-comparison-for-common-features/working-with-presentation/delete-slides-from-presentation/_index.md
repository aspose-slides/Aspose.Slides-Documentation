---
title: Delete Slides from Presentation using Apache POI and Aspose.Slides
type: docs
weight: 40
url: /java/slides-poi/delete-slides-from-presentation/
---

## **Aspose.Slides - Delete Slides from Presentation**
Sometimes, developers may need to remove a slide from the presentation due to any reason. Aspose.Slides for Java offers few methods to do so. 

We know that [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class in Aspose.Slides for Java represents a presentation file. [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class encapsulates a [**ISlideCollection**](https://apireference.aspose.com/slides/java/com.aspose.slides/IPresentation#getSlides--) that acts as a repository of all slides that are the part of the presentation. Developers can remove a slide from this Slides collection in two ways:

- Using Slide Reference
- Using Slide Index

```java
//Instantiate a PresentationEx object that represents a PPTX file
Presentation pres = new Presentation("presentation.pptx");

pres.getSlides().removeAt(1); //Removing a slide using its index

//Accessing a slide using its index in the slides collection
ISlide slide = pres.getSlides().get_Item(0);

pres.getSlides().remove(slide); //Removing a slide using its reference
```

## **Apache POI SL - HSLF XSLF - Delete Slides from Presentation**
Slides can be deleted by calling removeSlide from the presentation and passing the index of the slide to be deleted while using Apache POI SL.

```java
XMLSlideShow ppt = new XMLSlideShow(new FileInputStream("presentation.pptx"));

ppt.removeSlide(0); // 0-based index of a slide to be removed
```

## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)

## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/presentation/deleteslides)

{{% alert color="primary" %}} 

For more details, visit [Removing Slides from a Presentation](https://docs.aspose.com/slides/java/remove-slide-from-presentation/).

{{% /alert %}}
