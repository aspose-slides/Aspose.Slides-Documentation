---
title: Set Slide Title using Apache POI and Aspose.Slides
type: docs
weight: 60
url: /java/slides-poi/set-slide-title/
---

## **Aspose.Slides - Set Slide Title**
Below example shows how title can be set using Aspose.Slides.

```java
//Create a presentation
Presentation pres = new Presentation();

//Add the title slide
ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

//Set the title text
((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame().setText("Slide Title Heading");

//Set the sub title text
((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().setText("Slide Title Sub-Heading");
```

## **Apache POI SL - HSLF XSLF - Set Slide Title**
Title can be set by calling addTitle method of SlideShow class using Apache POI SL.

```java
SlideShow ppt = new SlideShow();

Slide slide = ppt.createSlide();

TextBox title = slide.addTitle();
title.setText("Hello, World!");
```

## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)

## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/slides/setslidetitle)

{{% alert color="primary" %}} 

For more details, visit [Manage TextBox](https://docs.aspose.com/slides/java/manage-textbox/).

{{% /alert %}}
