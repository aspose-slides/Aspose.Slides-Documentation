---
title: Slide Layout
type: docs
weight: 60
url: /net/slide-layout/
---


## **Add Slide Layout to Presentation**
Aspose.Slides also offer to add Layout slides in presentation. There are cases when there is missing Layout slide in presentation and once can now add the Layout Slides in presentation. Each slide has unique Id and Layout slides are maintained inside presentation Masters. One can access the Layout slide either by Type or by Name. Aspose.Slides for .NET allows developers to add new Layout slides in presentation. To add a Layout Slide, please follow the steps below:

1. Create an instance of Presentation class.
1. Access the Master Slide collection.
1. Try to find existing Layout slides to see if the required one is already available in Layout Slide collection or not.
1. Add a new Layout slide if the desired layout is unavailable.
1. Add an empty slide with a newly added Layout slide.
1. Finally, write the presentation file using the Presentation object.

In the example given below, we have added Layout Slides to Presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Layout-AddLayoutSlides-AddLayoutSlides.cs" >}}


## **Set Size and Type of Slide**
[SlideSize.Type](https://apireference.aspose.com/net/slides/aspose.slides/slidesize/properties/type) and [SlideSize.Size](https://apireference.aspose.com/net/slides/aspose.slides/slidesize/properties/size) are the properties of presentation class which could be set or get as shown below in the example.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Layout-SetSizeAndType-SetSizeAndType.cs" >}}
## **Set Footer Visibility Inside Slide**
To set footer in a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain a slide by its reference index.
1. Set Footer visible by making slide footer placeholder visible.
1. Set date-time placeholder visible by using the SetDateTime method.
1. Write the modified presentation file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Layout-HeaderFooterManager-HeaderFooterManager.cs" >}}

## **Set Child Footer Visibility Inside Slide**
To set footer and child footer a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain the master slide by using its index.
1. Set Footer and child footer visibility by making a master slide and all child footer placeholder visible.
1. Set text to master slide and all child footer placeholder by using [SetFooterAndChildFootersText ](https://apireference.aspose.com/net/slides/aspose.slides/imasterslideheaderfootermanager/methods/setfooterandchildfootersvisibility)method.
1. Set text to master slide and all child date-time placeholder by using SetDateTimeAndChildDateTimesText method.
1. Write the modified presentation file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Layout-SetChildFooter-SetChildFooter.cs" >}}

## **Set Slide Size with Respect to Content Scaling**
You can also set the slide size by using it with different ways of content scaling.[SlideSize.Type](https://apireference.aspose.com/net/slides/aspose.slides/slidesize/properties/type) and [SlideSize.Size](https://apireference.aspose.com/net/slides/aspose.slides/slidesize/properties/size) are the properties of presentation class which could be set or get as shown below in the example.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Layout-SetSlideSizeScale-SetSlideSizeScale.cs" >}}

## **Set Page Size when Generating PDF**
Slides in presentation could be set as different paper sizes. The [SlideSize.Type](https://apireference.aspose.com/net/slides/aspose.slides/slidesize/properties/type) property can be used to set the slide size. Developers can set the size of a slide as shown below in the example.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Layout-SetPDFPageSize-SetPDFPageSize.cs" >}}
