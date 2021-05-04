---
title: Multithreading in Aspose.Slides
type: docs
weight: 70
url: /net/multithreading/
---

{{% alert color="primary" %}} 

Despite the fact that parallel work with presentation(s) is possible (except for parsing/loading/cloning) and most of the times everything looks right, there’s a small chance to get incorrect result using the the library in multiple threads.

We strongly recommend not to use a single Presentation instance in multi-threading environment, because it can lead to rare but unpredictable artifacts which are not easy to detect. Loading, saving and cloning an instance of a Presentation class in multiple threads is not thread safe and not supported. As an alternative solution you can try to parallel your task using several separated single-threaded processes handling entire presentation inside a single process.