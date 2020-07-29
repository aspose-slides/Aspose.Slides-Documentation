---
title: Adding and Editing Slides
type: docs
weight: 10
url: /net/adding-and-editing-slides/
---

## **Adding Slides to Presentation**
Before talking about adding slides to the presentation files, let us discuss some facts about the slides. Each PowerPoint presentation file contains Master / Layout slide and other Normal slides. It means that a presentation file contains at least one or more slides. It is important to know that presentation files without slides are not supported by Aspose.Slides for .NET. Each slide has a unique Id and all the Normal Slides are arranged in an order specified by the zero based index. Aspose.Slides for .NET allows developers to add empty slides to their presentation. To add an empty slide in the presentation, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Instantiate [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) class by setting a reference to the Slides (collection of content Slide objects) property exposed by the Presentation object.
- Add an empty slide to the presentation at the end of the content slides collection by calling the AddEmptySlide methods exposed by ISlideCollection object
- Do some work with the newly added empty slide.
- Finally, write the presentation file using the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) object.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}
### **Adding or Removing section**
Aspose.Slides for .NET now allows developers to add a section or remove the section where a group of slides can be added or removed. Developers can also add a section on any desired location in the presentation. The code snippet below demonstrates how to use this feature.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-CRUD-ISectionCollection-ISectionCollection.cs" >}}
## **Accessing Slides of a Presentation**
In this topic, we will introduce the possible ways to access a slide from a presentation file. Each slide in a presentation has a unique Id. On the other hand, all the slides in the presentation are arranged in the order of the slide position starting from 0, that is, slide at position 1 will be accessible through 0 index of [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) associated with a [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) object.

Aspose.Slides for .NET provides a [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class that can be used to find and access any desired slide present in the presentation. Currently, developers can access a slide in the following two ways.

1. Access Slide by Index.
1. Access Slide by ID.
### **Access Slide by Index**
[Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class represents a presentation file and exposes all slides in it as a [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) collection (that is a collection of [ISlide](https://apireference.aspose.com/net/slides/aspose.slides/islide) objects). All of these slides can be accessed from this Slides collection using a slide index as shown below in the example.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-CRUD-AccessSlidebyIndex-AccessSlidebyIndex.cs" >}}
### **Access Slide by ID**
Every slide in the presentation has a unique ID associated with it. The [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class exposes the [GetSlideById(id)](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/getslidebyid) method that can be used to access the slide by ID. All you need to do is to provide the valid slide ID and access that slide using [GetSlideById(id)](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/getslidebyid) method as shown below in the example.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-CRUD-AccessSlidebyID-AccessSlidebyID.cs" >}}
## **Removing Slides from a Presentation**
Sometimes, developers may need to remove a slide from the presentation due to any reason. Aspose.Slides for .NET offers few methods to do so. In this topic, we will explore these methods to accomplish this task. We know that [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class in Aspose.Slides for .NET represents a presentation file. [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class encapsulates a [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) that acts as a repository of all slides that are the part of the presentation. Developers can remove a slide from this Slides collection in two ways:

1. Using Slide Reference
1. Using Slide Index
### **Using Slide Reference**
To remove a slide using its reference, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Id or Index.
1. Remove the referenced slide from the presentation.
1. Write the modified presentation file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-CRUD-RemoveSlideUsingReference-RemoveSlideUsingReference.cs" >}}
### **Using Slide Index**
To remove a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Remove the slide from the presentation by using its index position.
1. Write the modified presentation file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-CRUD-RemoveSlideUsingIndex-RemoveSlideUsingIndex.cs" >}}
## **Working With Slide Size and Layout**
In this topic, we will introduce the possible ways to set size and type of a slide from a presentation file. Also, we will discuss how to set the page size when the presentation is converted to PDF file. Aspose.Slides for .NET provides the feature of setting the size and type of any slide as it is in the source presentation. Developers can set these properties while cloning the slides from different presentation files:

- Setting Slide Size and Type.
- Setting the page size when generating PDF.
### **Setting the Size and Type of a slide**
[SlideSize.Type](https://apireference.aspose.com/net/slides/aspose.slides/slidesize/properties/type) and [SlideSize.Size](https://apireference.aspose.com/net/slides/aspose.slides/slidesize/properties/size) are the properties of presentation class which could be set or get as shown below in the example.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Layout-SetSizeAndType-SetSizeAndType.cs" >}}
### **Setting Footer Visibility Inside Slide**
To set footer in a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain a slide by its reference index.
1. Set Footer visible by making slide footer placeholder visible.
1. Set date-time placeholder visible by using the SetDateTime method.
1. Write the modified presentation file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Layout-HeaderFooterManager-HeaderFooterManager.cs" >}}
### **Setting Child Footer Visibility Inside Slide**
To set footer and child footer a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain the master slide by using its index.
1. Set Footer and child footer visibility by making a master slide and all child footer placeholder visible.
1. Set text to master slide and all child footer placeholder by using [SetFooterAndChildFootersText ](https://apireference.aspose.com/net/slides/aspose.slides/imasterslideheaderfootermanager/methods/setfooterandchildfootersvisibility)method.
1. Set text to master slide and all child date-time placeholder by using SetDateTimeAndChildDateTimesText method.
1. Write the modified presentation file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Layout-SetChildFooter-SetChildFooter.cs" >}}
### **Compare two slides**
Equals method has been added to [IBaseSlide](https://apireference.aspose.com/net/slides/aspose.slides/ibaseslide) interface and [BaseSlide](https://apireference.aspose.com/net/slides/aspose.slides/baseslide) class. It returns true for the slides/layout and slides/master slides which identical by its structure and static content.

Two slides are equal if all shapes, styles, texts, animation and other settings. etc. The comparison doesn't take into account unique identifier values, e.g. SlideId and dynamic content, e.g. current date value in Date Placeholder.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Layout-CheckSlidesComparison-CheckSlidesComparison.cs" >}}
### **Setting the Slide Size with respect to Content Scaling**
You can also set the slide size by using it with different ways of content scaling.[SlideSize.Type](https://apireference.aspose.com/net/slides/aspose.slides/slidesize/properties/type) and [SlideSize.Size](https://apireference.aspose.com/net/slides/aspose.slides/slidesize/properties/size) are the properties of presentation class which could be set or get as shown below in the example.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Layout-SetSlideSizeScale-SetSlideSizeScale.cs" >}}
### **Setting the page size when generating PDF**
Slides in presentation could be set as different paper sizes. The [SlideSize.Type](https://apireference.aspose.com/net/slides/aspose.slides/slidesize/properties/type) property can be used to set the slide size. Developers can set the size of a slide as shown below in the example.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Layout-SetPDFPageSize-SetPDFPageSize.cs" >}}
## **Changing the Position of a Slide**
If you create a presentation using MS PowerPoint, you would have experienced that whenever you add a new slide to your presentation, it is appended at the end of the presentation by default. Using MS PowerPoint, you can drag a selected slide to any other position of the presentation. Aspose.Slides for .NET also allows developers to change the position of a slide within the presentation. It is very simple to change the position of a slide in the presentation. Just follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Change the SlideNumber of the referenced slide.
1. Write the modified presentation file.

The example given below moves the slide (that was at position 1 to the second position and the slide that was at the second position, is moved to the first position and so on). In this way, all slides are adjusted automatically by Aspose.Slides for .NET.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-CRUD-ChangePosition-ChangePosition.cs" >}}
