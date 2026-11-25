---
title: 在 Python 中中断长时间运行的演示文稿操作
linktitle: 中断演示文稿操作
type: docs
weight: 120
url: /zh/python-java/support-for-interruptable-library/
keywords:
- 可中断的操作
- 中断令牌
- 取消令牌
- 长时间运行任务
- 中断任务
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via Java 中取消长时间运行的演示文稿操作，并在循环导出幻灯片时返回部分结果。"
---
## **概览**

Aspose.Slides for Python via Java 可以中断诸如加载、保存和呈现演示文稿等长时间运行的操作。您的应用程序可以使用相同的中断令牌在循环开始处理下一张幻灯片之前停止循环。

## **中断演示文稿操作**

创建一个 [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)，使用 [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken) 获取其令牌，并将令牌传递给 [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken)。将加载选项传递给 [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)。若要请求取消，请在源上调用 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt)。可中断的操作在检测到请求后停止。使用 `jpype.JClass` 在 Python 中捕获 Java 异常 `com.aspose.slides.exceptions.OperationCanceledException`。

示例在后台线程中将 `sample.pptx` 转换为 `sample.ppt`。调用线程最多等待 10 秒以完成转换。如果转换仍在运行，它会请求取消并等待工作线程退出。

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

## **将 Python 超时连接到 Aspose.Slides**

要为演示文稿操作设置时间限制，请使用 [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) 在超时到期时调用 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt)。示例允许在 20 秒内加载 `sample.pptx` 并导出为 `sample.pdf`。如果导出提前完成，应用程序会取消已安排的请求。

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

## **在处理下一张幻灯片之前停止**

对演示文稿和导出其幻灯片的循环使用相同的 [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/)。在每次导出前检查 [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested)。如果调用方可以使用部分结果，则返回已成功完成导出的幻灯片编号。

使用名为 `sample.pptx`、至少包含两张幻灯片的演示文稿。接受 Java `int[]` 的 [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 重载使用从 1 开始的幻灯片编号。使用 `jpype.JArray(jpype.JInt)` 在 Python 中构建该数组。示例将每张幻灯片保存为单独的 PDF，并在记录第一次成功导出后立即请求取消。

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

示例写入 `slide-1.pdf` 并打印 `Starting slide 1`，随后是 `Completed: [1]`。循环在启动第 2 张幻灯片前检测到请求。如果在保存过程中收到取消请求，循环将在记录该幻灯片为完成之前退出。

如果调用方需要处理取消，请将循环顶部的检查及其 `break` 替换为 `token.throwIfInterruptionRequested()`。移除保存周围的 `try`/`except`，使导出期间的取消也能传递给调用方。使用相同的输入，示例仅打印 `Starting slide 1` 并写入 `slide-1.pdf`。在第二次迭代开始时，[throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) 在下一个导出开始前抛出 `com.aspose.slides.exceptions.OperationCanceledException`。该异常在函数返回列表之前传播到调用方。

## **常见问题**

**何时应请求取消？**

当操作超过您的时间限制或您的应用程序不再需要结果时请求取消。

**[InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) 与 [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) 有何区别？**

源允许您的应用程序请求取消。令牌允许 Aspose.Slides 和您的应用程序检查该请求。

**我能从 Python 定时器取消操作吗？**

可以。安排对与演示文稿关联的源调用 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt)。

**我可以中断哪些操作？**

您可以中断加载、保存和渲染。通过 [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken) 将令牌传递给 [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)。随后演示文稿在后续操作（例如保存为 PDF）中即可检测到取消。

**操作会立即停止吗？**

取消是合作式的。操作会定期检查令牌，并在检测到请求后停止。

**如果在操作完成后调用 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) 会怎样？**

已完成的操作会保留其结果。

**多个操作可以共享一个 [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) 吗？**

可以。调用 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) 会请求取消所有使用该源令牌的操作。对于希望独立取消的每个操作，请使用单独的源。