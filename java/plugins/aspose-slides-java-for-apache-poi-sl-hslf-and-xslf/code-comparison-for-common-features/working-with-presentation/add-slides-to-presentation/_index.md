---
title: Add Slides to Presentation using Apache POI and Aspose.Slides
type: docs
weight: 10
url: /java/slides-poi/add-slides-to-presentation/
---

## **Aspose.Slides - Add Slides to Presentation**
Aspose.Slides for Java allows developers to add empty slides to their presentation. To add an empty slide in the presentation, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class
- Instantiate [ISlideCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) class by setting a reference to the Slides (collection of content Slide objects) property exposed by the Presentation object.
- Add an empty slide to the presentation at the end of the content slides collection by calling the [AddEmptySlide](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) method exposed by [ISlideCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) object
- Do some work with the newly added empty slide
- Finally, write the presentation file using the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) object

```java
//Instantiate a PresentationEx object that represents a PPTX file
Presentation pres = new Presentation("presentation.pptx");

//Add Slide
ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
```

## **Apache POI SL - HSLF XSLF - Add Slides to Presentation**
New slide can be added to presentation by SlideShow.createSlide method using Apache POI SL - HSLF and XSLF.

```java
//create a new empty slide show
SlideShow ppt = new SlideShow();

//add first slide
Slide s1 = ppt.createSlide();

//add second slide
Slide s2 = ppt.createSlide();
```

## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)

## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/presentation/addslides)

{{% alert color="primary" %}} 

For more details, visit [Adding Slides to Presentation](https://docs.aspose.com/slides/java/add-slide-to-presentation/).

{{% /alert %}}
