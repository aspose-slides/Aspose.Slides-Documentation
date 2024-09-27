---
title: Multithreading in Aspose.Slides
type: docs
weight: 310
url: /net/multithreading/
keywords:
- PowerPoint
- presentation
- multithreading
- parallel work
- convert slides
- slides to images
- C#
- .NET
- Aspose.Slides for .NET
---

## **Introduction**

While parallel work with presentations is possible (besides parsing/loading/cloning) and everything goes well (most times), there is a small chance you might get incorrect results when you use the library in multiple threads.

We strongly recommend that you do **not** use a single [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) instance in a multi-threading environment because it might result in unpredictable errors or failures that are not easily detected. 

It is **not** safe to load, save, and/or clone an instance of a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class in multiple threads. Such operations are **not** supported.  If you need to perform such tasks, you have to parallel the operations using several single-threaded processes—and each of these processes should use its own presentation instance. 

## **Convert Presentation Slides to Images in Parallel**

Let's say we want to convert all the slides from a PowerPoint presentation to PNG images in parallel. Since it is unsafe to use a single `Presentation` instance in multiple threads, we split the presentation slides into separate presentations and convert the slides to images in parallel, using each presentation in a separate thread. The following code example shows how to do this.

```cs
using var presentation = new Presentation("sample.pptx");

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);
var imageScale = 2;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // Extract slide i into a separate presentation.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Convert the slide to an image in a separate task.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            image.Save($"slide_{slideNumber}.png", ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```
