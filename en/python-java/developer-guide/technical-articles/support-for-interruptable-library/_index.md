---
title: Interrupt Long-Running Presentation Operations in Python
linktitle: Interrupt Presentation Operations
type: docs
weight: 120
url: /python-java/support-for-interruptable-library/
keywords:
- interruptible operations
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
description: "Learn how to cancel long-running presentation operations in Aspose.Slides for Python via Java and return a partial result when exporting slides in a loop."
---

## **Overview**

Aspose.Slides for Python via Java can interrupt long-running operations such as loading, saving, and rendering presentations. Your application can use the same interruption token to stop a loop before it starts processing the next slide.

## **Interrupt a Presentation Operation**

Create an [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), obtain its token with [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken), and pass the token to [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Pass the load options to the [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). To request cancellation, call [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) on the source. An interruptible operation stops when it observes the request. Use `jpype.JClass` to catch the Java exception `com.aspose.slides.exceptions.OperationCanceledException` in Python.

The example converts `sample.pptx` to `sample.ppt` on a background thread. The calling thread waits up to 10 seconds for the conversion to finish. If the conversion is still running, it requests cancellation and waits for the worker to exit.

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **Connect a Python Timeout to Aspose.Slides**

To set a time limit on a presentation operation, use a [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) to call [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) when the timeout expires. The example allows 20 seconds to load `sample.pptx` and export it to `sample.pdf`. If the export finishes early, the application cancels the scheduled request.

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **Stop Before Processing the Next Slide**

Use the same [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) for the presentation and the loop that exports its slides. Check [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) before each export. If the caller can use a partial result, return the slide numbers for the exports that completed successfully.

Use a presentation named `sample.pptx` with at least two slides. The [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) overload that takes a Java `int[]` uses slide numbers starting at 1. Use `jpype.JArray(jpype.JInt)` to build that array in Python. The example saves each slide to a separate PDF and requests cancellation immediately after it records the first successful export.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

The example writes `slide-1.pdf` and prints `Starting slide 1` followed by `Completed: [1]`. The loop observes the request before starting slide 2. If cancellation arrives during a save, the loop exits before it records that slide as complete.

If the caller needs to handle cancellation, replace the check and its `break` at the top of the loop with `token.throwIfInterruptionRequested()`. Remove the `try`/`except` around the save so cancellation during an export also reaches the caller. With the same input, the example prints only `Starting slide 1` and writes `slide-1.pdf`. At the start of the second iteration, [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) raises `com.aspose.slides.exceptions.OperationCanceledException` before the next export begins. The exception propagates to the caller before the function can return the list.

## **FAQ**

**When should I request cancellation?**

Request cancellation when an operation exceeds your time limit or when your application no longer needs the result.

**What is the difference between [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

The source lets your application request cancellation. The token lets Aspose.Slides and your application check for that request.

**Can I cancel an operation from a Python timer?**

Yes. Schedule a call to [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) on the source associated with the presentation.

**Which operations can I interrupt?**

You can interrupt loading, saving, and rendering. Pass the token to the [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) through [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). The presentation can then observe cancellation during subsequent operations such as saving to PDF.

**Does an operation stop immediately?**

Cancellation is cooperative. An operation checks the token periodically and stops when it observes the request.

**What happens if I call [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) after an operation finishes?**

The completed operation keeps its result.

**Can multiple operations share an [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

Yes. Calling [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) requests cancellation for every operation that uses a token from that source. Use a separate source for each operation you want to cancel independently.
