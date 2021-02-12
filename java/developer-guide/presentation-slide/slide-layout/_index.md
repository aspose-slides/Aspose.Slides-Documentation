---
title: Slide Layout
type: docs
weight: 60
url: /java/slide-layout/
---


## **Overview**
Aspose.Slides also offer to add Layout slides in presentation. 
There are cases when there is missing Layout slide in presentation and once can now 
add the Layout Slides in presentation. Each slide has unique Id and Layout slides are 
maintained inside presentation Masters. One can access the Layout slide either by Type or by Name.
We will introduce the possible ways to set size and type of a slide from a presentation file. 
Also, we will discuss how to set the page size when presentation is converted to PDF file.

Aspose.Slides for Java provides the feature of setting the size and type of any slide as it is in the source 
presentation. Developers can set these properties while cloning the slides from different presentation files:


## **Add Slide Layout to Presentation**
Aspose.Slides for Java allows developers to add new Layout slides in presentation. To add a Layout Slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Access the Master Slide collection.
- Try to find existing Layout slides to see if the required one is already available in Layout Slide collection or not.
- Add a new Layout slide if the desired layout is unavailable.
- Add an empty slide with newly added Layout slide.
- Finally, write the presentation file using the Presentation object.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Layout-AddingLayoutSlidesToPresentation-AddingLayoutSlidesToPresentation.java" >}}

## **Set Size and Type of Slide**
**SlideSize.Type** and **SlideSize.Size** are the properties of presentation class which could be set or get as shown below in the example.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Layout-SettingTheSizeAndTypeOfASlide-SettingTheSizeAndTypeOfASlide.java" >}}


## **Set Footer Visibility inside Slide**
Aspose.Slides for Java provides the feature for Setting footer visibility inside slide. To set footer in a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide by its reference index.
1. Set Footer visible by making slide footer placeholder visible.
1. Set date-time placeholder visible by using SetDateTime method.
1. Write the modified presentation file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Layout-HeaderFooterManager-HeaderFooterManager.java" >}}


## **Set Child Footer Visibility inside Slide**
Aspose.Slides for Java provides the feature for Setting footer visibility inside slide. To set footer and child footer inside a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the master slide by using its index.
1. Set Footer and child footer visibility by making master slide and all child footer placeholder visible.
1. Set text to master slide and all child footer placeholder by using SetFooterAndChildFootersText method.
1. Set text to master slide and all child date-time placeholder by using SetDateTimeAndChildDateTimesText method.
1. Write the modified presentation file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Layout-SetChildFooterVisible-SetChildFooterVisible.java" >}}

