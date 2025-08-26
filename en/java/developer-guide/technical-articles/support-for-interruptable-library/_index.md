---
title: Support For Interruptable Library
type: docs
weight: 120
url: /java/support-for-interruptable-library/
keywords:
- interruptable library
- interruption token
- cancellation token
- long-running task
- interrupt task
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Make long-running tasks cancelable with Aspose.Slides for Java. Interrupt rendering and conversions for PowerPoint and OpenDocument safely, with examples."
---

## **Interruptable Library**

In [Aspose.Slides 18.4](https://releases.aspose.com/slides/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/), we introduced the [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) classes. They allow you to interrupt long-running tasks such as deserialization, serialization, and rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) is the source of the token(s) passed to [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-).
- When [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) is set and the [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) instance is passed to the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) constructor, invoking [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) interrupts any long-running task associated with that [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).

The following code snippet demonstrates interrupting a running task:

```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // run the action in a separate thread
Thread.sleep(10000);     // timeout
tokenSource.interrupt(); // stop the conversion
```

## **FAQ**

**Q: What is the purpose of the Aspose.Slides interrupt library?**

It provides a mechanism to interrupt long-running operations—such as loading, saving, or rendering presentations—before they complete. This is useful when processing time must be limited or the task is no longer needed.

**Q: What is the difference between [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` is passed to the Aspose.Slides API and checked during long-running operations.
- `InterruptionTokenSource` is used in your code to create tokens and trigger interruptions by calling `Interrupt()`.

**Q: What tasks can be interrupted?**

Any Aspose.Slides task that accepts an [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/)—such as loading a presentation with `Presentation(path, loadOptions)` or saving with `Presentation.save(...)`—can be interrupted.

**Q: Does interruption happen immediately?**

No. Interruption is cooperative: the operation periodically checks the token and stops as soon as it detects that [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) has been called.

**Q: What happens if I call [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) after a task has already completed?**

Nothing—the call has no effect if the corresponding task has already completed.

**Q: Can I reuse the same [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) for multiple tasks?**

Yes—but after you call [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) on that source, all tasks using its tokens will be interrupted. Use separate token sources to manage tasks independently.
