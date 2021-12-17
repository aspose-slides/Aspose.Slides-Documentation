---
title: Remove Slide from Presentation
type: docs
weight: 30
url: /cpp/remove-slide-from-presentation/
---


Sometimes, developers may need to remove a slide from the presentation due to any reason. Aspose.Slides for C++ offers few methods to do so. In this topic, we will explore these methods to accomplish this task. We know that [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class in Aspose.Slides for C++ represents a presentation file. `Presentation` class encapsulates a [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) that acts as a repository of all slides that are the part of the presentation. Developers can remove a slide from this Slides collection in two ways:

1. Using Slide Reference
1. Using Slide Index

## **Remove Slide by Reference**
To remove a slide using its reference, please follow the steps below:

1. Create an instance of `Presentation` class.
1. Obtain the reference of a slide by using its Id or Index.
1. Remove the referenced slide from the presentation.
1. Write the modified presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSlides-RemoveSlideUsingReference.cpp" >}}

## **Remove Slide by Index**
To remove a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of `Presentation` class.
1. Remove the slide from the presentation by using its index position.
1. Write the modified presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSlides-RemoveSlideUsingIndex.cpp" >}}

