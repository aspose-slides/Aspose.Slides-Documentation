---
title: Create Presentation Header Footer using Apache POI and Aspose.Slides
type: docs
weight: 10
url: /java/slides-poi/create-presentation-header-footer/
---

## **Aspose.Slides - Create Presentation Header Footer**
The method [getHeaderFooterManager()](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#getHeaderFooterManager--) gives you access to Headers and Footers using Aspose.Slides API.

```java
//Show date time placeholder
sourcePres.getHeaderFooterManager().setAllDateTimesVisibility(true);

//Show the footer place holder
sourcePres.getHeaderFooterManager().setAllFootersVisibility(true);

//Show Slide Number
sourcePres.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

//Set the  header footer visibility on Title Slide
sourcePres.getHeaderFooterManager().setVisibilityOnAllTitleSlides(true);

sourcePres.getHeaderFooterManager().setAllFootersText("Aspose Slides");
```

## **Apache POI SL - HSLF XSLF - Create Presentation Header Footer**
HeadersFooters class getters to access header and footer using Apache POI SL - HSLF XSLF

```java
//presentation-scope headers / footers
HeadersFooters hf = ppt.getSlideHeadersFooters();
hf.setSlideNumberVisible(true);
hf.setFootersText("Created by POI-HSLF");
```

## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)

## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/presentation/createheaderfooter)

{{% alert color="primary" %}} 

For more details, visit [How to Add Header Footer in a Presentation](https://docs.aspose.com/slides/java/presentation-header-and-footer/).

{{% /alert %}}
