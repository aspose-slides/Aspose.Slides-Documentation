---
title: Move Slide to New Position using Apache POI and Aspose.Slides
type: docs
weight: 50
url: /java/slides-poi/move-slide-to-new-position/
---

## **Aspose.Slides - Move Slide to New Position**
If you create a presentation using **MS PowerPoint**, you would have experienced that whenever you add a new slide to your presentation, it is appended at the end of the presentation by default. Using **MS PowerPoint**, you can drag a selected slide to any other position of the presentation. Aspose.Slides for Java also allows developers to change the position of a slide within the presentation.

It's very simple to change the position of a slide in the presentation. Just follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class
- Obtain the reference of a slide by using its Index
- Change the SlideNumber of the referenced slide
- Write the modified presentation file

```java
//Instantiate a Presentation object that represents a PPT file
Presentation pres = new Presentation("presentation.ppt");

//Accessing a slide using its slide position
ISlide slide = pres.getSlides().get_Item(0);

//Change the position of the selected slide
slide.setSlideNumber(2);
```

## **Apache POI SL - HSLF XSLF - Move Slide to New Position**
Slide can be reordered using setSlideOrder method of XMLSlideShow while using Apache POI SL.

```java
XMLSlideShow ppt = new XMLSlideShow(new FileInputStream("presentation.pptx"));

//add slides

...

// Moving slide to new position
XSLFSlide[] slides = ppt.getSlides();

ppt.setSlideOrder(slides[0], 4);
```

## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)

## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/slides/moveslide)

{{% alert color="primary" %}} 

For more details, visit [Changing the Position of a Slide](https://docs.aspose.com/slides/java/access-slide-in-presentation/#change-slide-position).

{{% /alert %}}
