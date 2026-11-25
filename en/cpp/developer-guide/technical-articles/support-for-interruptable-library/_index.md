---
title: Interrupt Long-Running Presentation Operations in C++
linktitle: Interrupt Presentation Operations
type: docs
weight: 150
url: /cpp/support-for-interruptable-library/
keywords:
- interruptible operations
- interruption token
- cancellation token
- long-running task
- interrupt task
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Learn how to cancel long-running presentation operations in Aspose.Slides for C++ and return a partial result when exporting slides in a loop."
---

## **Overview**

Aspose.Slides for C++ can interrupt long-running operations such as loading, saving, and rendering presentations. Your application can use the same interruption token to stop a loop before it starts processing the next slide.

## **Interrupt a Presentation Operation**

Create an [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), retrieve its token with [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/), pass the token to [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/), and pass the load options to the [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). To request cancellation, call [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) on the source. An interruptible operation stops when it observes the request.

The example starts converting `sample.pptx` to `sample.ppt` in a background task and requests cancellation if the task is still running after 10 seconds. If the conversion finishes earlier, the output is already complete.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.ppt", Export::SaveFormat::Ppt);
});

if (conversion.wait_for(std::chrono::seconds(10)) == std::future_status::timeout)
    source->Interrupt();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
```

## **Connect Application Cancellation to Aspose.Slides**

If your application uses a [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/), use [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) to forward cancellation requests to [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/). The example exports `sample.pptx` to `sample.pdf` in a background task. If the export is still running after 20 seconds, the application calls [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/), which invokes the registered callback.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <system/threading/cancellation_token.h>
#include <system/threading/cancellation_token_source.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto cancellation = MakeObject<Threading::CancellationTokenSource>();
auto cancellationToken = cancellation->get_Token();
auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto interrupt = Action<>([source]() { source->Interrupt(); });
auto registration = cancellationToken.Register(interrupt);

auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.pdf", Export::SaveFormat::Pdf);
});

if (conversion.wait_for(std::chrono::seconds(20)) == std::future_status::timeout)
    cancellation->Cancel();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
registration.Dispose();
```

## **Stop Before Processing the Next Slide**

Use the same [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) for both the presentation and the loop that exports its slides. Check [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) before starting each export. If the caller can use a partial result, return the slide numbers for the exports that completed successfully.

Use a presentation named `sample.pptx` with at least two slides. The example requests cancellation immediately after it records the first successful export.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <DOM/ISlideCollection.h>
#include <system/array.h>
#include <iostream>
#include <vector>

using namespace Aspose::Slides;
using namespace System;

auto exportSlides = [](String path, SharedPtr<InterruptionTokenSource> source)
{
    std::vector<int32_t> completed;
    auto token = source->get_Token();
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(path, options);
    auto slideCount = presentation->get_Slides()->get_Count();

    for (auto number = 1; number <= slideCount; ++number)
    {
        if (token->get_IsInterruptionRequested())
            break;

        std::cout << "Starting slide " << number << '\n';
        auto filename = String::Format(u"slide-{0}.pdf", number);
        auto slides = MakeArray<int32_t>({number});
        try
        {
            presentation->Save(filename, slides, Export::SaveFormat::Pdf);
        }
        catch (const OperationCanceledException&)
        {
            if (!token->get_IsInterruptionRequested())
                throw;
            break;
        }

        completed.push_back(number);
        if (number == 1)
            source->Interrupt();
    }
    return completed;
};

auto source = MakeObject<InterruptionTokenSource>();
auto completed = exportSlides(u"sample.pptx", source);
std::cout << "Completed: [";
for (size_t i = 0; i < completed.size(); ++i)
    std::cout << (i == 0 ? "" : ", ") << completed[i];
std::cout << "]\n";
```

The example writes `slide-1.pdf` and prints `Starting slide 1` followed by `Completed: [1]`. The loop sees the request before it starts slide 2. If cancellation instead interrupts [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) during an export, the `catch` block exits the loop before the code records the current slide as complete.

If the caller needs to handle cancellation, replace the `if` check and its `break` at the top of the loop with a call to [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) on the token. Remove the `try`/`catch` around the export so cancellation during a save also reaches the caller. With the same input, the example prints only `Starting slide 1` and writes `slide-1.pdf`. At the start of the second iteration, the caller receives an [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) before the export begins. The caller receives no list of completed slides.

## **FAQ**

**When should I request cancellation?**

Request cancellation when an operation exceeds your time limit or when your application no longer needs the result.

**What is the difference between [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

The source lets your application request cancellation. The token lets Aspose.Slides and your application check for that request.

**Can I use a [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) with Aspose.Slides?**

Yes. When your application token signals cancellation, call [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) on the source associated with the presentation.

**Which operations can I interrupt?**

You can interrupt loading, saving, and rendering. Pass the token to the [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) through [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/). The presentation can then observe cancellation during subsequent operations such as [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

**Does an operation stop immediately?**

Cancellation is cooperative. An operation checks the token periodically and stops when it observes the request.

**What happens if I call [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) after an operation finishes?**

The completed operation keeps its result.

**Can multiple operations share an [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Yes. Calling [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) requests cancellation for every operation that uses a token from that source. Use a separate source for each operation you want to cancel independently.
