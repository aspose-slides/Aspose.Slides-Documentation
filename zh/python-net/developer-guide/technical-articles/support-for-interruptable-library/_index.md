---
title: 在 Python 中中断长时间运行的演示文稿操作
linktitle: 中断演示文稿操作
type: docs
weight: 150
url: /zh/python-net/support-for-interruptable-library/
keywords:
- 可中断操作
- 中断令牌
- 取消 PDF 导出
- PowerPoint
- Python
- Aspose.Slides
description: "了解如何在 Python 中取消演示文稿转换，并返回在取消之前已完成导出的幻灯片列表。"
---
## **概述**

Aspose.Slides for Python via .NET 支持在加载、保存和渲染演示文稿等长时间运行的操作期间进行协作取消。当您单独导出幻灯片时，也可以在幻灯片之间检查取消请求，并返回已完成导出的幻灯片编号。

## **取消演示文稿转换**

创建一个[InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/)，将其[token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/)分配给[LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/)，并将这些选项传递给[Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/)。该 token 在整个演示文稿生命周期内生效。若要从应用程序请求取消，请调用[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/)。

示例将 `sample.pptx` 转换为 `sample.pdf`。一个[threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer)在 20 秒后调用 `source.interrupt`。在打开文件之前启动计时器，可使超时同时作用于加载和保存。具有 Cancel 按钮的应用程序可以在其事件处理程序中调用同一方法。

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

在加载后进行显式检查，如果超时已经过去，则跳过导出。如果加载或保存期间检测到请求，取消异常将传递给调用方。保存也可能在检测到请求之前完成，此时 PDF 已完整生成。

## **在处理下一个幻灯片之前停止**

在每次导出之前检查[InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/)。[Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)接受从 1 开始的幻灯片编号列表。仅在其 PDF 成功保存后才将编号添加到已完成列表中。

使用名为 `sample.pptx`、至少包含两个幻灯片的文件。为使结果可复现，示例在第 1 张幻灯片完成后立即请求取消。在应用程序中，请求可以来自另一个线程，而幻灯片正在保存时触发。

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

示例写入 `slide-1.pdf` 并打印 `Starting slide 1`，随后打印 `Completed: [1]`。下一次循环在启动第 2 张幻灯片之前检测到请求。如果取消中断了保存，异常处理程序将返回先前迭代记录的编号。其他导出错误会直接传递给调用方。

如果调用方希望将取消作为异常处理，可将循环顶部的检查及其 `break` 替换为[token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/)。同时移除保存周围的 `try`/`except`。使用相同的输入，第 1 张幻灯片会被保存，第二次迭代在启动第 2 张幻灯片前抛出取消异常。

## **FAQ**

**取消请求何时生效？**

可中断的操作会定期检查其 token。一旦观察到请求即可停止。已经完成的操作会保留其结果。

**源（source）和 token 有何区别？**

源让您的应用程序发出取消请求。token 让演示文稿本身以及您的代码检查该请求。

**多个操作可以共享同一个源吗？**

可以。调用 `interrupt` 会对使用该源的所有 token 的操作发出取消请求。如果需要独立取消每个操作，请为每个操作创建各自的源。