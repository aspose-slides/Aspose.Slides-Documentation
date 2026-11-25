---
title: 中斷 Python 中長時間執行的簡報操作
linktitle: 中斷簡報操作
type: docs
weight: 120
url: /zh-hant/python-java/support-for-interruptable-library/
keywords:
- 可中斷的操作
- 中斷令牌
- 取消令牌
- 長時間執行的任務
- 中斷任務
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "瞭解如何在 Aspose.Slides for Python via Java 中取消長時間執行的簡報操作，並在迴圈匯出投影片時返回部分結果。"
---
## **概述**

Aspose.Slides for Python via Java 可以中斷長時間執行的操作，例如載入、儲存和呈現簡報。您的應用程式可以使用相同的中斷令牌，在迴圈開始處理下一張投影片之前停止它。

## **中斷簡報操作**

建立一個[InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)，使用[getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken)取得其令牌，並將令牌傳遞給[LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken)。將載入選項傳遞給[Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)。若要請求取消，對來源呼叫[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt)。可中斷的操作會在偵測到請求時停止。使用`jpype.JClass`來捕獲 Python 中的 Java 例外`com.aspose.slides.exceptions.OperationCanceledException`。

此範例在背景執行緒上將 `sample.pptx` 轉換為 `sample.ppt`。呼叫執行緒最多等待 10 秒以完成轉換。若轉換仍在執行，則請求取消並等待工作執行緒結束。

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

## **將 Python 逾時連接到 Aspose.Slides**

若要在簡報操作上設定時間限制，請使用[threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer)在逾時到期時呼叫[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt)。此範例允許在 20 秒內載入 `sample.pptx` 並匯出為 `sample.pdf`。如果匯出提前完成，應用程式會取消已排程的請求。

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

## **在處理下一張投影片前停止**

對簡報以及匯出其投影片的迴圈使用相同的[InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/)。在每次匯出之前檢查[isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested)。如果呼叫端可以接受部分結果，則回傳成功匯出的投影片編號。

使用名為 `sample.pptx` 且至少包含兩張投影片的簡報。接收 Java `int[]` 的[Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 重載會使用從 1 開始的投影片編號。使用`jpype.JArray(jpype.JInt)`在 Python 中建立此陣列。此範例將每張投影片另存為個別的 PDF，並在記錄第一個成功匯出後立即請求取消。

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

此範例寫入 `slide-1.pdf` 並列印 `Starting slide 1`，接著是 `Completed: [1]`。迴圈在開始第 2 張投影片前偵測到請求。若取消在儲存期間到達，迴圈會在將該投影片標記為完成之前退出。

如果呼叫端需要處理取消，請將迴圈頂部的檢查與 `break` 改為 `token.throwIfInterruptionRequested()`。移除儲存周圍的 `try`/`except`，讓匯出期間的取消同樣傳遞給呼叫端。使用相同的輸入時，範例僅列印 `Starting slide 1` 並寫入 `slide-1.pdf`。在第二次迭代開始時，[throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) 會在下一個匯出開始前拋出 `com.aspose.slides.exceptions.OperationCanceledException`。例外會在函式返回清單之前傳遞給呼叫端。

## **常見問題**

**何時應該請求取消？**

當操作超過您的時間限制或您的應用程式不再需要結果時，請求取消。

**[InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) 與 [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) 之間有何差異？**

來源允許您的應用程式請求取消。令牌則讓 Aspose.Slides 與您的應用程式檢查此請求。

**我可以從 Python 計時器取消操作嗎？**

可以。安排對與簡報關聯的來源呼叫[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt)。

**我可以中斷哪些操作？**

您可以中斷載入、儲存與渲染。將令牌透過[LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken) 傳遞給[Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)。簡報此後在執行如儲存為 PDF 等操作時即可偵測取消。

**操作會立即停止嗎？**

取消是合作式的。操作會定期檢查令牌，並在偵測到請求時停止。

**如果在操作完成後呼叫[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) 會發生什麼？**

已完成的操作會保留其結果。

**多個操作可以共用同一個[InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)嗎？**

可以。呼叫[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt)會對所有使用該來源令牌的操作提出取消請求。若希望個別取消，每個操作請使用不同的來源。