---
title: Create Slides with Different Layouts using Apache POI and Aspose.Slides
type: docs
weight: 40
url: /java/slides-poi/create-slides-with-different-layouts/
---

## **Aspose.Slides - Create Slides with Different Layouts**
Aspose.Slides also offer to add Layout slides in presentation. There are cases when there is missing Layout slide in presentation and once can now add the Layout Slides in presentation. Each slide has unique Id and Layout slides are maintained inside presentation Masters. One can access the Layout slide either by Type or by Name.

```java
//Instantiate Presentation class that represents the presentation file
Presentation pres = new Presentation("presentation.pptx");

//Instantiate SlideCollection calss
ISlideCollection slds = pres.getSlides();

for (int i = 0; i < pres.getLayoutSlides().size(); i++)
{
    //Add an empty slide to the Slides collection
    slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
}
```

## **Apache POI SL - HSLF XSLF - Create Slides with Different Layouts**
Below example shows how different predefined layouts can be added to presentation slides using Apache POI SL.

```java
XMLSlideShow ppt = new XMLSlideShow(new FileInputStream("presentation.pptx"));

// blank slide
ppt.createSlide();

// there can be multiple masters each referencing a number of layouts
// for demonstration purposes we use the first (default) slide master
XSLFSlideMaster defaultMaster = ppt.getSlideMasters()[0];

// title slide
XSLFSlideLayout titleLayout = defaultMaster.getLayout(SlideLayout.TITLE);

// fill the placeholders
XSLFSlide slide1 = ppt.createSlide(titleLayout);

// title and content
XSLFSlideLayout titleBodyLayout = defaultMaster.getLayout(SlideLayout.TITLE_AND_CONTENT);

XSLFSlide slide2 = ppt.createSlide(titleBodyLayout);
```

## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)

## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/slides/createslideswithdifferentlayout)

{{% alert color="primary" %}} 

For more details, visit [Adding Layout Slides to Presentation](https://docs.aspose.com/slides/java/slide-layout/).

{{% /alert %}}
