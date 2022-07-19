---
title: Multithreading in Aspose.Slides
type: docs
weight: 310
url: /java/multithreading/
---

{{% alert color="primary" %}} 

While parallel work with presentations is possible (besides parsing/loading/cloning) and everything goes well (most times), there is a small chance you might get incorrect results when you use the library in multiple threads.

We strongly recommend that you do **not** use a single [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) instance in a multi-threading environment because it might result in unpredictable errors or failures that are not easily detected. 

It is **not** safe to load, save, and/or clone an instance of a [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class in multiple threads. Such operations are **not** supported.  If you need to perform such tasks, you have to parallel the operations using several single-threaded processes—and each of these processes should use its own presentation instance. 

