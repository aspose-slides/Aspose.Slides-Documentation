---
title: 支持可中断库
type: docs
weight: 120
url: /zh/python-java/support-for-interruptable-library/
keywords:
- 可中断库
- 中断令牌
- 取消令牌
- 长期任务
- 中断任务
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 将长期任务设为可取消。安全地中断 PowerPoint 和 OpenDocument 的渲染和转换，并提供示例。"
---
## **概述**

Aspose.Slides 提供可中断的处理机制，用于诸如反序列化、序列化和渲染等长期运行的演示文稿任务。此机制基于[InterruptionToken](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontoken/)和[InterruptionTokenSource](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontokensource/)类。

[InterruptionToken](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontoken/) 可以分配给[LoadOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/)，并传递给[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)构造函数。当调用[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontokensource/#interrupt)时，相关的长期任务会被中断。

## **可中断库**

Aspose.Slides for Python via Java 提供[InterruptionToken](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontoken/)和[InterruptionTokenSource](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontokensource/)类。它们允许您中断如反序列化、序列化和渲染等长期运行的任务。

- [InterruptionTokenSource](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontokensource/) 是传递给[LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setInterruptionToken)的令牌来源。
- 当调用[LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setInterruptionToken)且将[LoadOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/)实例传递给[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)构造函数时，调用[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontokensource/#interrupt)会中断与该[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)相关的任何长期任务。

下面的代码片段演示了如何中断正在运行的任务：

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
    conversion_task = executor.submit(convert_presentation)  # 在单独的线程中运行该操作。
    time.sleep(10)  # 超时。
    token_source.interrupt()  # 停止转换。
    conversion_task.result()
```

## **常见问题**

**Aspose.Slides 中断库的用途是什么？**

它提供一种机制，可在加载、保存或渲染演示文稿等长期操作完成之前中断这些操作。当处理时间需要受限或任务不再需要时，这非常有用。

**[InterruptionToken](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontoken/) 与 [InterruptionTokenSource](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontokensource/) 有何区别？**

- [InterruptionToken](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontoken/) 被传递给 Aspose.Slides API 并在长期操作期间进行检查。
- [InterruptionTokenSource](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontokensource/) 用于您的代码中创建令牌并通过调用[interrupt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontokensource/#interrupt)触发中断。

**哪些任务可以被中断？**

任何接受 [InterruptionToken](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontoken/) 的 Aspose.Slides 任务——例如使用[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)加载演示文稿或使用[Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save)保存——都可以被中断。

**中断会立即发生吗？**

不会。中断是协作式的：操作会定期检查令牌，并在检测到已调用[interrupt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontokensource/#interrupt)时立即停止。

**如果在任务已完成后调用 [interrupt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontokensource/#interrupt) 会怎么样？**

什么也不会发生——如果相应的任务已经完成，调用没有任何影响。

**我可以在多个任务中复用同一个 [InterruptionTokenSource](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontokensource/) 吗？**

可以——但在对该源调用[interrupt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/interruptiontokensource/#interrupt)后，所有使用其令牌的任务都会被中断。请使用独立的令牌源来独立管理任务。