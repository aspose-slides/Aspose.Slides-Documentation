---
title: "在 Python 中中斷長時間執行的簡報操作"
linktitle: "中斷簡報操作"
type: docs
weight: 150
url: /zh-hant/python-net/support-for-interruptable-library/
keywords:
- "可中斷的操作"
- "中斷令牌"
- "取消 PDF 匯出"
- "PowerPoint"
- "Python"
- "Aspose.Slides"
description: "了解如何在 Python 中取消簡報轉換，並返回在取消前已完成匯出的投影片清單。"
---
## **概覽**

Aspose.Slides for Python via .NET 支援在長時間執行的操作（例如載入、儲存和算繪簡報）期間的合作取消。當您逐張匯出投影片時，也可以在投影片之間檢查取消，並回傳已完成匯出的投影片編號。

## **取消簡報轉換**

建立一個 [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/)，將其 [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) 指派給 [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/)，並將選項傳遞給 [Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/)。此 token 於簡報的整個生命週期內皆有效。若要從應用程式請求取消，呼叫 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/)。

此範例將 `sample.pptx` 轉換為 `sample.pdf`。一個 [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) 會在 20 秒後呼叫 `source.interrupt`。在開啟檔案之前啟動計時器，可使逾時同時套用於載入與儲存。具有「取消」按鈕的應用程式可從其事件處理常式呼叫相同的方法。

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

在載入完成後進行的明確檢查會在逾時已經發生時跳過匯出。若載入或儲存偵測到取消請求，取消例外會傳遞給呼叫端。若儲存於偵測請求前已完成，則 PDF 會完整產生。

## **在處理下一張投影片前停止**

在每次匯出前檢查 [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/)。[Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 接受從 1 開始的投影片編號清單。僅在其 PDF 成功儲存後，才將編號加入已完成清單。

使用名稱為 `sample.pptx`、至少包含兩張投影片的檔案。為了使結果可重現，範例會在投影片 1 完成後立即請求取消。在應用程式中，請求可以在投影片保存期間由其他執行緒發出。

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

範例會寫入 `slide-1.pdf`，並印出 `Starting slide 1`，接著是 `Completed: [1]`。下一次迭代在開始投影片 2 前會看到取消請求。若取消中斷了儲存，例外處理常式會回傳先前迭代記錄的編號。其他匯出錯誤則傳遞給呼叫端。

如果呼叫端應將取消視為例外處理，請將迴圈頂部的檢查及其 `break` 替換為 [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/)。同時移除圍繞儲存的 `try`/`except`。使用相同的輸入時，投影片 1 會被儲存，而第二次迭代會在開始投影片 2 前拋出取消例外。

## **常見問題**

**取消請求何時生效？**

可中斷的操作會定期檢查其 token。當偵測到請求時即停止。已完成的操作會保留其結果。

**來源與 token 有何差異？**

來源讓您的應用程式可以請求取消。token 則讓簡報及您的程式碼皆能檢查該請求。

**多個操作可以共享同一個來源嗎？**

是的。呼叫 `interrupt` 會對所有使用該來源之 token 的操作請求取消。如果需要獨立取消，請為每個操作提供各自的來源。