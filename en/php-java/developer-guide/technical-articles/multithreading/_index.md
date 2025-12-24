---
title: Multithreading in Aspose.Slides for PHP via Java
linktitle: Multithreading
type: docs
weight: 310
url: /php-java/multithreading/
keywords:
- multithreading
- multiple threads
- parallel work
- convert slides
- slides to images
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java multithreading boosts PowerPoint and OpenDocument processing. Discover best practices for efficient presentation workflows."
---

## **Introduction**

While parallel work with presentations is possible (besides parsing/loading/cloning) and everything goes well (most times), there is a small chance you might get incorrect results when you use the library in multiple threads.

We strongly recommend that you do **not** use a single [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) instance in a multi-threading environment because it might result in unpredictable errors or failures that are not easily detected.

It is **not** safe to load, save, and/or clone an instance of a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class in multiple threads. Such operations are **not** supported.  If you need to perform such tasks, you have to parallel the operations using several single-threaded processes—and each of these processes should use its own presentation instance.

We do not guarantee multithreading in PHP when using extensions. If you use them, do so at your own risk.

## **FAQ**

**Do I need to call license setup in every thread?**

No. It’s enough to do it once per process/app domain before threads start. If [license setup](/slides/php-java/licensing/) might be invoked concurrently (for example, during lazy initialization), synchronize that call because the license setup method itself is not thread-safe.

**Can I pass `Presentation` or `Slide` objects between threads?**

Passing "live" presentation objects between threads is not recommended: use independent instances per thread or precreate separate presentations/slide containers for each thread. This approach follows the general recommendation not to share a single presentation instance across threads.

**Is it safe to parallelize export to different formats (PDF, HTML, images) provided each thread has its own `Presentation` instance?**

Yes. With independent instances and separate output paths, such tasks typically parallelize correctly; avoid any shared presentation objects and shared I/O streams.

**What should I do with global font settings (folders, substitutions) in multithreading?**

Initialize all global [font settings](/slides/php-java/powerpoint-fonts/) before starting the threads and do not change them during parallel work. This eliminates races when accessing shared font resources.
