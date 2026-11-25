---
title: Interrupt Long-Running Presentation Operations in Python
linktitle: Interrupt Presentation Operations
type: docs
weight: 150
url: /python-net/support-for-interruptable-library/
keywords:
- interruptible operations
- interruption token
- cancel PDF export
- PowerPoint
- Python
- Aspose.Slides
description: "Learn how to cancel a presentation conversion in Python and return the list of slides that finished exporting before cancellation."
---

## **Overview**

Aspose.Slides for Python via .NET supports cooperative cancellation during long-running operations such as loading, saving, and rendering presentations. When you export slides individually, you can also check for cancellation between slides and return the numbers of the slides that finished exporting.

## **Cancel a Presentation Conversion**

Create an [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), assign its [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) to [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/), and pass the options to the [Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). The token applies to the presentation throughout its lifetime. To request cancellation from your application, call [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/).

The example converts `sample.pptx` to `sample.pdf`. A [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) calls `source.interrupt` after 20 seconds. Starting the timer before opening the file makes the timeout apply to both loading and saving. An application with a Cancel button can call the same method from its event handler.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

The explicit check after loading skips the export if the timeout has already elapsed. If loading or saving observes the request, the cancellation exception reaches the caller. A save can also finish before it observes the request, in which case the PDF is complete.

## **Stop Before Processing the Next Slide**

Check [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) before each export. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) accepts a list of slide numbers starting at 1. Add a number to the completed list only after its PDF has been saved successfully.

Use a file named `sample.pptx` with at least two slides. To make the result reproducible, the example requests cancellation as soon as slide 1 finishes. In an application, the request can come from another thread while a slide is being saved.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

The example writes `slide-1.pdf` and prints `Starting slide 1` followed by `Completed: [1]`. The next iteration sees the request before starting slide 2. If cancellation interrupts a save, the exception handler returns the numbers recorded by earlier iterations. Other export errors reach the caller.

If the caller should handle cancellation as an exception, replace the check and its `break` at the top of the loop with [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). Also remove the `try`/`except` around the save. With the same input, slide 1 is saved and the second iteration raises a cancellation exception before starting slide 2.

## **FAQ**

**When does a cancellation request take effect?**

An interruptible operation checks its token periodically. It stops when it observes the request. An operation that has already finished keeps its result.

**What is the difference between the source and the token?**

The source lets your application request cancellation. The token lets both the presentation and your own code check for that request.

**Can several operations share a source?**

Yes. Calling `interrupt` requests cancellation for every operation using a token from that source. Give each operation its own source if you need to cancel it independently.
