---
title: Support For Interruptable Library
type: docs
weight: 150
url: /cpp/support-for-interruptable-library/
keywords:
- interruptable library
- interruption token
- cancellation token
- long-running task
- interrupt task
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Make long-running tasks cancelable with Aspose.Slides for C++. Interrupt rendering and conversions for PowerPoint and OpenDocument safely, with examples."
---

## **Overview**

Aspose.Slides provides an interruptible processing mechanism for long-running presentation tasks, such as deserialization, serialization, and rendering. This mechanism is based on the `InterruptionToken` and `InterruptionTokenSource` classes.

An `InterruptionToken` can be assigned to `LoadOptions` and passed to the `Presentation` constructor. When `InterruptionTokenSource::Interrupt()` is called, the associated long-running task is interrupted.

## **Interruptable Library**

In [Aspose.Slides 18.4](https://releases.aspose.com/slides/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/), we introduced the [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) classes. They allow you to interrupt long-running tasks such as deserialization, serialization, and rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) is the source of the token(s) passed to [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/).
- When [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) is set and the [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) instance is passed to the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) constructor, invoking [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) interrupts any long-running task associated with that [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).

The following code snippet demonstrates interrupting a running task:

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/smart_ptr.h>
#include <system/threading/thread.h>
using namespace Aspose::Slides;
using namespace System;

auto tokenSource = MakeObject<InterruptionTokenSource>();
SharedPtr<IInterruptionToken> token = tokenSource->get_Token();

// The conversion runs in a separate thread so that it can be interrupted.
auto threadFunction = Threading::ThreadStart([token]() -> void
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);

    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.ppt", Export::SaveFormat::Ppt);
});

auto thread = MakeObject<Threading::Thread>(threadFunction);
thread->Start();

Threading::Thread::Sleep(10000); // timeout
tokenSource->Interrupt();        // stop the conversion
```

## **FAQ**

### What is the purpose of the Aspose.Slides interrupt library?

It provides a mechanism to interrupt long-running operations—such as loading, saving, or rendering presentations—before they complete. This is useful when processing time must be limited or the task is no longer needed.

### What is the difference between [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?

- `InterruptionToken` is passed to the Aspose.Slides API and checked during long-running operations.
- `InterruptionTokenSource` is used in your code to create tokens and trigger interruptions by calling `Interrupt()`.

### What tasks can be interrupted?

Any Aspose.Slides task that accepts an [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/)—such as loading a presentation with `Presentation(path, loadOptions)` or saving with `Presentation::Save(...)`—can be interrupted.

### Does interruption happen immediately?

No. Interruption is cooperative: the operation periodically checks the token and stops as soon as it detects that [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) has been called.

### What happens if I call [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) after a task has already completed?

Nothing—the call has no effect if the corresponding task has already completed.

### Can I reuse the same [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) for multiple tasks?

Yes—but after you call [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) on that source, all tasks using its tokens will be interrupted. Use separate token sources to manage tasks independently.
