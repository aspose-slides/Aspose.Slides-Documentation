---
title: Add Slide to Presentation
type: docs
weight: 10
url: /java/add-slide-to-presentation/
---

## **Add Slide to Presentation**
{{% alert color="primary" %}} 

Before talking about adding slides to the presentation files, let us discuss some facts about the slides. Each PowerPoint presentation file contains **Master / Layout** slide and other **Normal** slides. It means that a presentation file contains at least one or more slides. It is important to know that presentation files without slides are not supported by Aspose.Slides for Java. Each slide has a unique Id and all the Normal Slides are arranged in an order specified by the zero-based index.

{{% /alert %}} 

Aspose.Slides for Java allows developers to add empty slides to their presentation. To add an empty slide in the presentation, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class.
- Instantiate [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) class by setting a reference to the Slides (collection of content Slide objects) property exposed by the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) object.
- Add an empty slide to the presentation at the end of the content slides collection by calling the [**AddEmptySlide**](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) methods exposed by [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) object.
- Do some work with the newly added empty slide.
- Finally, write the presentation file using the Presentation object.


{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-AddingSlidesToPresentation-AddingSlidesToPresentation.java" >}}

