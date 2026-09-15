---
title: Multithreading in Aspose.Slides for Python via Java
linktitle: Multithreading
type: docs
weight: 310
url: /python-java/multithreading/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java multithreading boosts PowerPoint and OpenDocument processing. Discover best practices for efficient presentation workflows."
---

## **Introduction**

Although parallel work with presentations is possible (except for parsing, loading, and cloning) and usually works well, there is a small chance of incorrect results when you use the library in multiple threads.

We strongly recommend that you do **not** use a single [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) instance in a multithreaded environment because it might result in unpredictable errors or failures that are not easily detected.

It is **not** safe to load, save, and/or clone a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) instance in multiple threads. Such operations are **not** supported. If you need to perform such tasks, you have to parallelize the operations using several single-threaded processes—and each of these processes should use its own presentation instance.

## **Convert Presentation Slides to Images in Parallel**

Let's say we want to convert all the slides from a PowerPoint presentation to PNG images in parallel. Since it is unsafe to use a single [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) instance in multiple threads, we split the presentation slides into separate presentations and convert the slides to images in parallel, using each presentation in a separate thread. The following code example shows how to do this.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # Extract the slide into a separate presentation.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Convert the slide to an image in a separate task.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Wait for all tasks to complete.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **FAQ**

**Do I need to call license setup in every thread?**

No. It is enough to do it once per process before threads start. If [license setup](/slides/python-java/licensing/) might be invoked concurrently (for example, during lazy initialization), synchronize that call because the license setup method itself is not thread-safe.

**Can I pass [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) or [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) objects between threads?**

Passing "live" presentation objects between threads is not recommended: use independent instances per thread or create separate presentations or slide containers for each thread in advance. This approach follows the general recommendation not to share a single presentation instance across threads.

**Is it safe to parallelize export to different formats (PDF, HTML, images) provided each thread has its own [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) instance?**

Yes. With independent instances and separate output paths, such tasks typically parallelize correctly; avoid any shared presentation objects and shared I/O streams.

**What should I do with global font settings (folders, substitutions) in multithreading?**

Initialize all global [font settings](/slides/python-java/powerpoint-fonts/) before starting the threads and do not change them during parallel work. This eliminates races when accessing shared font resources.
