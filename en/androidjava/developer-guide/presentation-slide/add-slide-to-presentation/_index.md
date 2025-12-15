---
title: Add Slides to Presentations on Android
linktitle: Add Slide
type: docs
weight: 10
url: /androidjava/add-slide-to-presentation/
keywords:
- add slide
- create slide
- empty slide
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Easily add slides to your PowerPoint and OpenDocument presentations using Aspose.Slides for Android via Java—seamless, efficient slide insertion in seconds."
---

## **Add a Slide to a Presentation**
{{% alert color="primary" %}} 

Before talking about adding slides to the presentation files, let us discuss some facts about the slides. Each PowerPoint presentation file contains **Master / Layout** slide and other **Normal** slides. It means that a presentation file contains at least one or more slides. It is important to know that presentation files without slides are not supported by Aspose.Slides for Android via Java. Each slide has a unique Id and all the Normal Slides are arranged in an order specified by the zero-based index.

{{% /alert %}} 

Aspose.Slides for Android via Java allows developers to add empty slides to their presentation. To add an empty slide in the presentation, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
- Instantiate [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) class by setting a reference to the [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) (collection of content Slide objects) property exposed by the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) object.
- Add an empty slide to the presentation at the end of the content slides collection by calling the [**addEmptySlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) methods exposed by [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) object.
- Do some work with the newly added empty slide.
- Finally, write the presentation file using the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) object.

```java
// Instantiate Presentation class that represents the presentation file
Presentation pres = new Presentation();
try {
    // Instantiate SlideCollection calss
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Add an empty slide to the Slides collection
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Do some work on the newly added slide

    // Save the PPTX file to the Disk
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**Can I insert a new slide at a specific position, not just at the end?**

Yes. The library supports slide collections and [insert](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) operations, so you can add a slide at the required index rather than only at the end.

**Are the theme/styles preserved when adding a slide based on a layout?**

Yes. A layout inherits formatting from its master, and the new slide inherits from the selected layout and its associated master.

**Which slide is present in a new "empty" presentation before adding slides?**

A newly created presentation already contains one blank slide with index zero. This is important to consider when calculating insertion indices.

**How do I choose the "right" layout for a new slide if the master has many options?**

Generally choose the [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) that matches the required structure ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidelayouttype/)). If such a layout is missing, you can [add it to the master](/slides/androidjava/slide-layout/) and then use it.
