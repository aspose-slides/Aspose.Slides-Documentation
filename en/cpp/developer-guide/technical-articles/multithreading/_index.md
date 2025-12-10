---
title: Multithreading in Aspose.Slides for C++
linktitle: Multithreading
type: docs
weight: 200
url: /cpp/multithreading/
keywords:
- multithreading
- multiple threads
- parallel work
- convert slides
- slides to images
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ multithreading boosts PowerPoint and OpenDocument processing. Discover best practices for efficient presentation workflows."
---

## **Introduction**

While parallel work with presentations is possible (besides parsing/loading/cloning) and everything goes well (most times), there is a small chance you might get incorrect results when you use the library in multiple threads.

We strongly recommend that you do **not** use a single [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) instance in a multi-threading environment because it might result in unpredictable errors or failures that are not easily detected. 

It is **not** safe to load, save, and/or clone an instance of a [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class in multiple threads. Such operations are **not** supported.  If you need to perform such tasks, you have to parallel the operations using several single-threaded processes—and each of these processes should use its own presentation instance. 

## **Convert Presentation Slides to Images in Parallel**

Let's say we want to convert all the slides from a PowerPoint presentation to PNG images in parallel. Since it is unsafe to use a single `Presentation` instance in multiple threads, we split the presentation slides into separate presentations and convert the slides to images in parallel, using each presentation in a separate thread. The following code example shows how to do this.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Extract slide i into a separate presentation.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Convert the slide to an image in a separate task.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// Wait for all tasks to complete.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **FAQ**

**Do I need to call license setup in every thread?**

No. It’s enough to do it once per process/app domain before threads start. If [license setup](/slides/cpp/licensing/) might be invoked concurrently (for example, during lazy initialization), synchronize that call because the license setup method itself is not thread-safe.

**Can I pass `Presentation` or `Slide` objects between threads?**

Passing "live" presentation objects between threads is not recommended: use independent instances per thread or precreate separate presentations/slide containers for each thread. This approach follows the general recommendation not to share a single presentation instance across threads.

**Is it safe to parallelize export to different formats (PDF, HTML, images) provided each thread has its own `Presentation` instance?**

Yes. With independent instances and separate output paths, such tasks typically parallelize correctly; avoid any shared presentation objects and shared I/O streams.

**What should I do with global font settings (folders, substitutions) in multithreading?**

Initialize all global font settings before starting the threads and do not change them during parallel work. This eliminates races when accessing shared font resources.
