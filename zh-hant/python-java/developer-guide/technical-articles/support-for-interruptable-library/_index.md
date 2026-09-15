---
title: 支援可中斷的函式庫
type: docs
weight: 120
url: /zh-hant/python-java/support-for-interruptable-library/
keywords:
- 可中斷函式庫
- 中斷令牌
- 取消令牌
- 長時間執行任務
- 中斷任務
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 讓長時間執行的任務可取消。安全地中斷 PowerPoint 和 OpenDocument 的渲染與轉換，並提供範例。"
---
## **概觀**

Aspose.Slides 提供可中斷的處理機制，用於長時間執行的簡報任務，如反序列化、序列化和渲染。此機制基於 [InterruptionToken](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontoken/) 與 [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontokensource/) 類別。

可將 [InterruptionToken](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontoken/) 指派給 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/) 並傳遞至 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 建構函式。呼叫 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontokensource/#interrupt) 時，相關的長時間執行任務將被中斷。

## **可中斷的函式庫**

Aspose.Slides for Python via Java 提供 [InterruptionToken](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontoken/) 與 [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontokensource/) 類別。它們允許您中斷長時間執行的任務，例如反序列化、序列化和渲染。

- [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontokensource/) 是傳遞給 [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setInterruptionToken) 的 token（或 token 群組）的來源。
- 當呼叫 [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setInterruptionToken) 並將 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/) 實例傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 建構函式時，執行 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontokensource/#interrupt) 會中斷與該 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 相關的任何長時間執行任務。

以下程式碼片段示範如何中斷正在執行的任務：

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
    conversion_task = executor.submit(convert_presentation)  # 在單獨的執行緒中執行操作。
    time.sleep(10)  # 超時。
    token_source.interrupt()  # 停止轉換。
    conversion_task.result()
```

## **常見問答**

**Aspose.Slides 可中斷函式庫的目的為何？**

它提供一種機制，可在長時間執行的操作（如載入、儲存或渲染簡報）完成之前中斷它們。當必須限制處理時間或任務已不再需要時，這非常有用。

**[InterruptionToken](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontoken/) 和 [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontokensource/) 有何差異？**

- [InterruptionToken](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontoken/) 會傳遞給 Aspose.Slides API，並在長時間執行的操作期間檢查。
- [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontokensource/) 用於您的程式碼中以建立 token，並透過呼叫 [interrupt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontokensource/#interrupt) 觸發中斷。

**可以中斷哪些任務？**

任何接受 [InterruptionToken](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontoken/) 的 Aspose.Slides 任務——例如使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 載入簡報或使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 儲存——皆可被中斷。

**中斷會立即發生嗎？**

不會。中斷是合作式的：操作會定期檢查 token，並在偵測到已呼叫 [interrupt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontokensource/#interrupt) 時立即停止。

**如果在任務已完成後呼叫 [interrupt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontokensource/#interrupt) 會發生什麼？**

不會有任何作用——如果對應的任務已完成，呼叫將不會產生影響。

**我可以在多個任務中重複使用相同的 [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontokensource/) 嗎？**

可以——但在對該來源呼叫 [interrupt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/interruptiontokensource/#interrupt) 後，所有使用其 token 的任務都會被中斷。請使用獨立的 token 來源以獨立管理任務。