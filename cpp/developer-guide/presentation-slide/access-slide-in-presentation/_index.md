---
title: Access Slide in Presentation
type: docs
weight: 20
url: /cpp/access-slide-in-presentation/
---


## **Access Slide in Presentation**
In this topic, we will introduce the possible ways to access a slide from a presentation file. Each slide in a presentation has a unique Id. On the other hand, all the slides in the presentation are arranged in the order of the slide position starting from 0, that is, slide at position 1 will be accessible through 0 index of [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) associated with a [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) object.

Aspose.Slides for C++ provides `Presentation` class that can be used to find and access any desired slide present in the presentation. Currently, developers can access a slide in following two ways.

1. Access Slide by Index.
1. Access Slide by ID.

### **Access Slide by Index**
`Presentation` class represents a presentation file and exposes all slides in it as a [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) collection (that is a collection of [ISlide](http://www.aspose.com/api/net/slides/aspose.slides/islide) objects). All of these slides can be accessed from this Slides collection using a slide index as shown below in the example.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSlidebyIndex-AccessSlidebyIndex.cpp" >}}

### **Access Slide by ID**
Every slide in presentation has a unique ID associated with it. The `Presentation` class exposes the [GetSlideById(id)](https://apireference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) method that can be used to access the slide by ID. All you need to do is to provide the valid slide ID and access that slide using [GetSlideById(id)](https://apireference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) method as shown below in the example.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSlidebyID-AccessSlidebyID.cpp" >}}


## **Change Slide Position**
If you create a presentation using MS PowerPoint, you would have experienced that whenever you add a new slide to your presentation, it is appended at the end of the presentation by default. Using MS PowerPoint, you can drag a selected slide to any other position of the presentation. Aspose.Slides for C++ also allows developers to change the position of a slide within the presentation. It's very simple to change the position of a slide in the presentation. Just follow the steps below:

1. Create an instance of `Presentation` class.
1. Obtain the reference of a slide by using its Index.
1. Change the SlideNumber of the referenced slide.
1. Write the modified presentation file.

The example given below moves the slide (that was at position 1 to the second position and the slide that was at second position, is moved to the first position and so on). In this way, all slides are adjusted automatically by Aspose.Slides for C++.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangePosition-ChangePosition.cpp" >}}


## **Set Slide Number**
Aspose.Slides for C++ now supports, setting the Slide Number. In this topic, we will see with an example how to get and set the slide number property in Aspose.Slides. The new methods added to `Presentation` allows to get or to set the number of the first slide in a presentation. When a new [FirstSlideNumber](https://apireference.aspose.com/slides/net/aspose.slides/presentation/properties/firstslidenumber) value is specified all slide numbers are recalculated. In order to get or set the Slide Number, please follow the steps below:

1. Create an instance of `Presentation` class.
1. Get the slide number.
1. Set the slide number.
1. Write the presentation as a PPTX file.

In the example given below, we have get and set the slide number.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetSlideNumber-SetSlideNumber.cpp" >}}
