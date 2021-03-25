---
title: Slide Layout
type: docs
weight: 60
url: /cpp/slide-layout/
---


## **Add Slide Layout to Presentation**
Aspose.Slides also offer to add Layout slides in a presentation. There are cases when there is missing Layout slide in the presentation and once can now add the Layout Slides in a presentation. Each slide has unique Id and Layout slides are maintained inside presentation Masters. One can access the Layout slide either by Type or by Name. Aspose.Slides for C++ allows developers to add new Layout slides in the presentation. To add a Layout Slide, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access the Master Slide collection.
1. Try to find existing Layout slides to see if the required one is already available in Layout Slide collection or not.
1. Add a new Layout slide if the desired layout is unavailable.
1. Add an empty slide with a newly added Layout slide.
1. Finally, write the presentation file using the Presentation object.

In the example given below, we have added Layout Slides to Presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddLayoutSlides-AddLayoutSlides.cpp" >}}


## **Set Size and Type of Slide**
[SlideSize.Type](http://www.aspose.com/api/net/slides/aspose.slides/slidesize/properties/type) and [SlideSize.Size](http://www.aspose.com/api/net/slides/aspose.slides/slidesize/properties/size) are the properties of presentation class which could be set or get as shown below in the example.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithSetSizeAndType-CloneToAnotherPresentationWithSetSizeAndType.cpp" >}}

## **Set Footer Visibility inside Slide**
To set footer in a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide by its reference index.
1. Set Footer visible by making slide footer placeholder visible.
1. Set date-time placeholder visible by using SetDateTime method.
1. Write the modified presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-HeaderFooterManager-HeaderFooterManager.cpp" >}}

## **Set Footer Visibility inside Slide**
To set footer and child footer a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the master slide by using its index.
1. Set Footer and child footer visibility by making master slide and all child footer placeholder visible.
1. Set text to master slide and all child footer placeholder by using SetFooterAndChildFootersText method.
1. Set text to master slide and all child date-time placeholder by using SetDateTimeAndChildDateTimesText method.
1. Write the modified presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetChildFooter-SetChildFooter.cpp" >}}


## **Set Slide Size with Respect to Content Scaling**
You can also set the slide size by using it with different ways of content scaling.[ SlideSize.Type](http://www.aspose.com/api/net/slides/aspose.slides/slidesize/properties/type) and [SlideSize.Size](http://www.aspose.com/api/net/slides/aspose.slides/slidesize/properties/size) are the properties of presentation class which could be set or get as shown below in the example.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetSlideSizeScale-SetSlideSizeScale.cpp" >}}


## **Set Page Size when Generating PDF**
Slides in presentation could be set as different paper sizes. The [SlideSize.Type](http://www.aspose.com/api/net/slides/aspose.slides/slidesize/properties/type) property and [SlideSizeScaleType ](https://apireference.aspose.com/net/slides/aspose.slides/slidesizescaletype)enumeration can be used to set the slide size. Developers can set size of slide as shown below in the example.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ManageSlideSize-SetPDFPageSize.cpp" >}}
