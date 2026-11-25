---
title: 在 Java 中中斷長時間執行的簡報操作
linktitle: 中斷簡報操作
type: docs
weight: 120
url: /zh-hant/java/support-for-interruptable-library/
keywords:
- 可中斷的操作
- 中斷令牌
- 取消令牌
- 長時間執行的任務
- 中斷任務
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中取消長時間執行的簡報操作，並在迴圈匯出投影片時返回部分結果。"
---
## **概述**

Aspose.Slides for Java 能夠中斷長時間執行的操作，例如載入、儲存和算繪投影片。您的應用程式可以使用相同的 interruption token 於下個投影片處理之前停止迴圈。

## **中斷投影片操作**

建立一個[InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)，使用[getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--)取得其 token，並將 token 傳遞給[LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-)。將載入選項傳遞給[Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-)。若要請求取消，對來源呼叫[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--)。可中斷的操作會在偵測到請求時停止。

此範例在背景執行緒中將 `sample.pptx` 轉換為 `sample.ppt`。呼叫執行緒最多等待 10 秒以完成轉換。如果轉換仍在執行，則請求取消並等待工作執行緒結束。

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;

InterruptionTokenSource source = new InterruptionTokenSource();
Thread worker = new Thread(() -> {
    LoadOptions options = new LoadOptions();
    options.setInterruptionToken(source.getToken());
    try {
        Presentation presentation = new Presentation("sample.pptx", options);
        try {
            presentation.save("sample.ppt", SaveFormat.Ppt);
        } finally {
            presentation.dispose();
        }
    } catch (OperationCanceledException canceled) {
        System.out.println("Conversion canceled");
    }
});

worker.start();
worker.join(10000);
if (worker.isAlive()) {
    source.interrupt();
    worker.join();
}
```

## **將 Java 超時連接至 Aspose.Slides**

若要為投影片操作設定時間上限，請使用[ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html)在逾時時呼叫[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--)。此範例允許 20 秒載入 `sample.pptx` 並匯出為 `sample.pdf`。若匯出提前完成，應用程式會取消已排程的請求。

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;

InterruptionTokenSource source = new InterruptionTokenSource();
LoadOptions options = new LoadOptions();
options.setInterruptionToken(source.getToken());

ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
try {
    Presentation presentation = new Presentation("sample.pptx", options);
    try {
        presentation.save("sample.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
    }
} catch (OperationCanceledException canceled) {
    System.out.println("Presentation processing was canceled");
} finally {
    timeout.cancel(false);
    timer.shutdown();
}
```

## **在處理下一張投影片前停止**

對投影片與匯出其投影片的迴圈使用相同的[IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/)。在每次匯出前檢查[isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--)。如果呼叫端可以接受部分結果，則回傳已成功匯出的投影片編號。

使用名為 `sample.pptx` 且至少包含兩張投影片的簡報。[Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-)接受投影片編號陣列的重載以 1 為起始編號。此範例將每張投影片儲存為單獨的 PDF，並在記錄第一個成功匯出後立即請求取消。

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;

class SlideExporter {
    List<Integer> exportSlides(String path, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        Presentation presentation = new Presentation(path, options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    presentation.save("slide-" + number + ".pdf", new int[] { number }, SaveFormat.Pdf);
                } catch (OperationCanceledException canceled) {
                    if (token.isInterruptionRequested()) {
                        break;
                    }
                    throw canceled;
                }

                completed.add(number);
                if (number == 1) {
                    source.interrupt();
                }
            }
            return completed;
        } finally {
            presentation.dispose();
        }
    }
}

InterruptionTokenSource source = new InterruptionTokenSource();
SlideExporter exporter = new SlideExporter();
List<Integer> completed = exporter.exportSlides("sample.pptx", source);
System.out.println("Completed: " + completed);
```

此範例寫入 `slide-1.pdf`，並印出 `Starting slide 1`，接著是 `Completed: [1]`。迴圈在開始投影片 2 前偵測到請求。如果在儲存期間收到取消，迴圈會在將該投影片標記為完成之前退出。

如果呼叫端需要處理取消，請將迴圈頂部的檢查及其 `break` 改為 `token.throwIfInterruptionRequested()`。移除儲存周圍的 `try`/`catch`，使匯出期間的取消也能傳遞給呼叫端。使用相同的輸入，範例只會印出 `Starting slide 1` 並寫入 `slide-1.pdf`。在第二次迭代開始時，[throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) 會拋出 `com.aspose.slides.exceptions.OperationCanceledException`，在下一次匯出開始前。此方法不會返回列表。

## **常見問題**

**何時應該請求取消？**

當操作超過您的時間限制或您的應用程式不再需要結果時，請求取消。

**[InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) 與 [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) 之間的差異是什麼？**

來源允許您的應用程式請求取消。token 讓 Aspose.Slides 與您的應用程式檢查此請求。

**我可以從 Java 計時器取消操作嗎？**

可以。排程對與簡報關聯的來源呼叫[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--)。

**我可以中斷哪些操作？**

您可以中斷載入、儲存與算繪。透過[LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-)將 token 傳遞給[Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-)。之後的操作（例如儲存為 PDF）中，簡報即可偵測到取消。

**操作會立即停止嗎？**

取消是合作式的。操作會定期檢查 token，並在偵測到請求時停止。

**如果在操作完成後呼叫[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--)會發生什麼？**

已完成的操作會保留其結果。

**多個操作可以共用一個 [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) 嗎？**

可以。呼叫[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) 會為所有使用該來源 token 的操作請求取消。若想獨立取消每個操作，請為每個操作使用獨立的來源。