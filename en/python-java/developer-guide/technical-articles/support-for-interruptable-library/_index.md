---
title: Support for an Interruptible Library
type: docs
weight: 120
url: /python-java/support-for-interruptable-library/
keywords:
- interruptable library
- interruption token
- cancellation token
- long-running task
- interrupt task
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Make long-running tasks cancelable with Aspose.Slides for Python via Java. Interrupt rendering and conversions for PowerPoint and OpenDocument safely, with examples."
---

## **Overview**

Aspose.Slides provides an interruptible processing mechanism for long-running presentation tasks, such as deserialization, serialization, and rendering. This mechanism is based on the [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) classes.

An [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) can be assigned to [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) and passed to the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) constructor. When [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) is called, the associated long-running task is interrupted.

## **Interruptible Library**

Aspose.Slides for Python via Java provides the [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) classes. They allow you to interrupt long-running tasks such as deserialization, serialization, and rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) is the source of the token(s) passed to [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken).
- When [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken) is called and the [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) instance is passed to the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) constructor, invoking [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) interrupts any long-running task associated with that [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).

The following code snippet demonstrates interrupting a running task:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # Run the action in a separate thread.
    time.sleep(10)  # Timeout.
    token_source.interrupt()  # Stop the conversion.
    conversion_task.result()
```

## **FAQ**

**What is the purpose of the Aspose.Slides interrupt library?**

It provides a mechanism to interrupt long-running operations—such as loading, saving, or rendering presentations—before they complete. This is useful when processing time must be limited or the task is no longer needed.

**What is the difference between [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

- [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) is passed to the Aspose.Slides API and checked during long-running operations.
- [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) is used in your code to create tokens and trigger interruptions by calling [interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt).

**What tasks can be interrupted?**

Any Aspose.Slides task that accepts an [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/)—such as loading a presentation with [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) or saving with [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save)—can be interrupted.

**Does interruption happen immediately?**

No. Interruption is cooperative: the operation periodically checks the token and stops as soon as it detects that [interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) has been called.

**What happens if I call [interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) after a task has already completed?**

Nothing—the call has no effect if the corresponding task has already completed.

**Can I reuse the same [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) for multiple tasks?**

Yes—but after you call [interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) on that source, all tasks using its tokens will be interrupted. Use separate token sources to manage tasks independently.
