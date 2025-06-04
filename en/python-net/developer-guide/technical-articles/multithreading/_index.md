---
title: Multithreading in Aspose.Slides for Python
linktitle: Multithreading
type: docs
weight: 200
url: /python-net/multithreading/
keywords:
- multithreading
- multiple threads
- parallel work
- convert slides
- slides to images
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET multithreading boosts PowerPoint and OpenDocument processing. Discover best practices for efficient presentation workflows."
---

## **Introduction**

While parallel work with presentations is possible (besides parsing/loading/cloning) and everything goes well (most times), there is a small chance you might get incorrect results when you use the library in multiple threads.

We strongly recommend that you do **not** use a single [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instance in a multi-threading environment because it might result in unpredictable errors or failures that are not easily detected. 

It is **not** safe to load, save, and/or clone an instance of a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class in multiple threads. Such operations are **not** supported.  If you need to perform such tasks, you have to parallel the operations using several single-threaded processes—and each of these processes should use its own presentation instance. 

## **Convert Presentation Slides to Images in Parallel**

Let's say we want to convert all the slides from a PowerPoint presentation to PNG images in parallel. Since it is unsafe to use a single `Presentation` instance in multiple threads, we split the presentation slides into separate presentations and convert the slides to images in parallel, using each presentation in a separate thread. The following code example shows how to do this.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Extract slide i into a separate presentation.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Convert the slide to an image.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Wait for all tasks to complete.
for task in conversion_tasks:
    task.result()

del presentation
```
