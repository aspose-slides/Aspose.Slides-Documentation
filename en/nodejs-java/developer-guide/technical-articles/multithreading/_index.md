---
title: Multithreading in Aspose.Slides for Node.js via Java
linktitle: Multithreading
type: docs
weight: 310
url: /nodejs-java/multithreading/
keywords:
- multithreading
- multiple threads
- parallel work
- convert slides
- slides to images
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java multithreading boosts PowerPoint and OpenDocument processing. Discover best practices for efficient presentation workflows."
---

## **Introduction**

While parallel work with presentations is possible (besides parsing/loading/cloning) and everything goes well (most times), there is a small chance you might get incorrect results when you use the library in multiple threads.

We strongly recommend that you do **not** use a single [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) instance in a multi-threading environment because it might result in unpredictable errors or failures that are not easily detected.

It is **not** safe to load, save, and/or clone an instance of a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class in multiple threads. Such operations are **not** supported.  If you need to perform such tasks, you have to parallel the operations using several single-threaded processes—and each of these processes should use its own presentation instance.

## **Convert Presentation Slides to Images in Parallel**

Let's say we want to convert all the slides from a PowerPoint presentation to PNG images in parallel. Since it is unsafe to use a single `Presentation` instance in multiple threads, we split the presentation slides into separate presentations and convert the slides to images in parallel, using each presentation in a separate thread. The following code example shows how to do this.

```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // Extract slide i into a separate presentation.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // Wait for all tasks to complete.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```

## **FAQ**

**Do I need to call license setup in every thread?**

No. It’s enough to do it once per process/app domain before threads start. If [license setup](/slides/nodejs-java/licensing/) might be invoked concurrently (for example, during lazy initialization), synchronize that call because the license setup method itself is not thread-safe.

**Can I pass `Presentation` or `Slide` objects between threads?**

Passing "live" presentation objects between threads is not recommended: use independent instances per thread or precreate separate presentations/slide containers for each thread. This approach follows the general recommendation not to share a single presentation instance across threads.

**Is it safe to parallelize export to different formats (PDF, HTML, images) provided each thread has its own `Presentation` instance?**

Yes. With independent instances and separate output paths, such tasks typically parallelize correctly; avoid any shared presentation objects and shared I/O streams.

**What should I do with global font settings (folders, substitutions) in multithreading?**

Initialize all global font settings before starting the threads and do not change them during parallel work. This eliminates races when accessing shared font resources.
