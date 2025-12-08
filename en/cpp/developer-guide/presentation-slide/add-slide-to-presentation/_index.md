---
title: Add Slides to Presentations in C++
linktitle: Add Slide
type: docs
weight: 10
url: /cpp/add-slide-to-presentation/
keywords:
- add slide
- create slide
- empty slide
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Easily add slides to your PowerPoint and OpenDocument presentations using Aspose.Slides for C++ — seamless, efficient slide insertion in seconds."
---

## **Add Slide to Presentation**
Before talking about adding slides to the presentation files, let us discuss some facts about the slides. Each PowerPoint presentation file contains Master / Layout slide and other Normal slides. It means that a presentation file contains at least one or more slides. It is important to know that presentation files without slides are not supported by Aspose.Slides for C++. Each slide has unique Id and all the Normal Slides are arranged in an order specified by the zero based index. Aspose.Slides for C++ allows developers to add empty slides to their presentation. To add an empty slide in the presentation, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- Instantiate [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) class by setting a reference to the Slides (collection of content Slide objects) property exposed by the Presentation object.
- Add an empty slide to the presentation at the end of the content slides collection by calling the AddEmptySlide methods exposed by ISlideCollection object
- Do some work with the newly added empty slide.
- Finally, write the presentation file using the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) object.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

