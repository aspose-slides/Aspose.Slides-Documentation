---
title: Add Slide to Presentation
type: docs
weight: 10
url: /nodejs-java/add-slide-to-presentation/
---

## **Add Slide to Presentation**
{{% alert color="primary" %}} 

Before talking about adding slides to the presentation files, let us discuss some facts about the slides. Each PowerPoint presentation file contains **Master / Layout** slide and other **Normal** slides. It means that a presentation file contains at least one or more slides. It is important to know that presentation files without slides are not supported by Aspose.Slides for Node.js via Java. Each slide has a unique Id and all the Normal Slides are arranged in an order specified by the zero-based index.

{{% /alert %}} 

Aspose.Slides for Node.js via Java allows developers to add empty slides to their presentation. To add an empty slide in the presentation, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
- Instantiate [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) class by setting a reference to the [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) (collection of content Slide objects) property exposed by the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) object.
- Add an empty slide to the presentation at the end of the content slides collection by calling the [**addEmptySlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) methods exposed by [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) object.
- Do some work with the newly added empty slide.
- Finally, write the presentation file using the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) object.

```javascript
// Instantiate Presentation class that represents the presentation file
var pres = new aspose.slides.Presentation();
try {
    // Instantiate SlideCollection calss
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Add an empty slide to the Slides collection
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Do some work on the newly added slide
    // Save the PPTX file to the Disk
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```
