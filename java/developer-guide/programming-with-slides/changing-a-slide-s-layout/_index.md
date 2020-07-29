---
title: Changing a Slide's Layout
type: docs
weight: 30
url: /java/changing-a-slide-s-layout/
---

{{% alert color="primary" %}} 

Aspose.Slides also offer to add Layout slides in presentation. There are cases when there is missing Layout slide in presentation and once can now add the Layout Slides in presentation. Each slide has unique Id and Layout slides are maintained inside presentation Masters. One can access the Layout slide either by Type or by Name.

{{% /alert %}} 
## **Adding a Layout Slide to the Presentation**
Aspose.Slides for Java allows developers to add new Layout slides in presentation. To add a Layout Slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Access the Master Slide collection.
- Try to find existing Layout slides to see if the required one is already available in Layout Slide collection or not.
- Add a new Layout slide if the desired layout is unavailable.
- Add an empty slide with newly added Layout slide.
- Finally, write the presentation file using the Presentation object.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Layout-AddingLayoutSlidesToPresentation-AddingLayoutSlidesToPresentation.java" >}}
## **Working With Slide Size and Layout**
{{% alert color="primary" %}} 

In this topic, we will introduce the possible ways to set size and type of a slide from a presentation file. Also, we will discuss how to set the page size when presentation is converted to PDF file.

{{% /alert %}} 

Aspose.Slides for Java provides the feature of setting the size and type of any slide as it is in the source presentation. Developers can set these properties while cloning the slides from different presentation files:
### **Setting the Size and Type of a slide**
**SlideSize.Type** and **SlideSize.Size** are the properties of presentation class which could be set or get as shown below in the example.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Layout-SettingTheSizeAndTypeOfASlide-SettingTheSizeAndTypeOfASlide.java" >}}
### **Compare two slides**
Equals method has been added to IBaseSlide interface and BaseSlide class. It returns true for the slides / layout slides / master slides which identical by its structure and static content. Two slides are equal if all shapes, styles, texts, animation and other settings. etc. are equal. The comparison doesn't take into account unique identifier values, e.g. SlideId and dynamic content, e.g. current date value in Date Placeholder.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Layout-CheckSlidesComparison-CheckSlidesComparison.java" >}}
### **Setting the Size Scale of a slide**
**SlideSize.Size** is the property of presentation class which could be set as shown below in the example.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Layout-SettingTheSizeAndTypeOfASlide-SettingTheSizeAndTypeOfASlide.java" >}}
### **Setting the page size when generating PDF**
Slides in presentation could be set as different paper sizes. The **SlideSize.Type** property can be used to set the slide size. Developers can set size of slide as shown below in the example.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Layout-SettingThePageSizeWhenGeneratingPDF-SettingThePageSizeWhenGeneratingPDF.java" >}}



