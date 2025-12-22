---
title: Multithreading in Aspose.Slides for Android via Java
linktitle: Multithreading
type: docs
weight: 310
url: /androidjava/multithreading/
keywords:
- multithreading
- multiple threads
- parallel work
- convert slides
- slides to images
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java multithreading boosts PowerPoint and OpenDocument processing. Discover best practices for efficient presentation workflows."
---

## **Introduction**

While parallel work with presentations is possible (besides parsing/loading/cloning) and everything goes well (most times), there is a small chance you might get incorrect results when you use the library in multiple threads.

We strongly recommend that you do **not** use a single [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) instance in a multi-threading environment because it might result in unpredictable errors or failures that are not easily detected.

It is **not** safe to load, save, and/or clone an instance of a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class in multiple threads. Such operations are **not** supported.  If you need to perform such tasks, you have to parallel the operations using several single-threaded processes—and each of these processes should use its own presentation instance.

## **Convert Presentation Slides to Images in Parallel**

Let's say we want to convert all the slides from a PowerPoint presentation to PNG images in parallel. Since it is unsafe to use a single `Presentation` instance in multiple threads, we split the presentation slides into separate presentations and convert the slides to images in parallel, using each presentation in a separate thread. The following code example shows how to do this.

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// Extract slide i into a separate presentation.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Convert the slide to an image in a separate task.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
			IImage image = null;
			try {
				ISlide slide = slidePresentation.getSlides().get_Item(0);

				image = slide.getImage(imageScale, imageScale);
				String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
				image.save(imageFilePath, ImageFormat.Png);
			} finally {
				if (image != null) image.dispose();
				slidePresentation.dispose();
			}
		}
	}));
}

// Wait for all tasks to complete.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **FAQ**

**Do I need to call license setup in every thread?**

No. It’s enough to do it once per process/app domain before threads start. If [license setup](/slides/androidjava/licensing/) might be invoked concurrently (for example, during lazy initialization), synchronize that call because the license setup method itself is not thread-safe.

**Can I pass `Presentation` or `Slide` objects between threads?**

Passing "live" presentation objects between threads is not recommended: use independent instances per thread or precreate separate presentations/slide containers for each thread. This approach follows the general recommendation not to share a single presentation instance across threads.

**Is it safe to parallelize export to different formats (PDF, HTML, images) provided each thread has its own `Presentation` instance?**

Yes. With independent instances and separate output paths, such tasks typically parallelize correctly; avoid any shared presentation objects and shared I/O streams.

**What should I do with global font settings (folders, substitutions) in multithreading?**

Initialize all global [font settings](/slides/androidjava/powerpoint-fonts/) before starting the threads and do not change them during parallel work. This eliminates races when accessing shared font resources.
