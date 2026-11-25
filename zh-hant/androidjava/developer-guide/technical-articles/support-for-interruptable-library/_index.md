---
title: 在 Android 上中斷長時間執行的簡報作業
linktitle: 中斷簡報作業
type: docs
weight: 120
url: /zh-hant/androidjava/support-for-interruptable-library/
keywords:
- 可中斷的作業
- 中斷令牌
- 取消令牌
- 長時間執行的工作
- 中斷工作
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Android via Java 中取消長時間執行的簡報作業，並在迴圈匯出投影片時返回部分結果。"
---
## **概述**

Aspose.Slides for Android via Java 能夠中斷長時間執行的操作，例如載入、儲存和算繪簡報。您的應用程式可以使用相同的 interruption token 來在迴圈開始處理下一張投影片之前停止它。

## **中斷簡報作業**

建立一個 [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)，使用 [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--) 取得其 token，並將 token 傳遞給 [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-)。將載入選項傳遞給 [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-)。若要請求取消，對來源呼叫 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--)。可中斷的作業會在偵測到請求時停止。

此範例在背景執行緒中將 `sample.pptx` 轉換為 `sample.ppt`。呼叫執行緒最多等候 10 秒讓轉換完成。若轉換仍在執行，則請求取消並等待工作執行緒結束。

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // 從背景執行緒呼叫，並傳入包含 sample.pptx 的 context.getFilesDir()。
    public static void run(File directory) throws InterruptedException {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.ppt");
        InterruptionTokenSource source = new InterruptionTokenSource();
        Thread worker = new Thread(() -> {
            LoadOptions options = new LoadOptions();
            options.setInterruptionToken(source.getToken());
            try {
                Presentation presentation = new Presentation(input.getAbsolutePath(), options);
                try {
                    presentation.save(output.getAbsolutePath(), SaveFormat.Ppt);
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
    }
}
```

## **將 Java 超時連接至 Aspose.Slides**

若要為簡報作業設定時間限制，請使用 [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) 在逾時時呼叫 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--)。此範例允許 20 秒載入 `sample.pptx` 並匯出為 `sample.pdf`。如果匯出提前完成，應用程式會取消已排程的請求。

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // 從背景執行緒呼叫，並傳入包含 sample.pptx 的 context.getFilesDir()。
    public static void run(File directory) {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.pdf");
        InterruptionTokenSource source = new InterruptionTokenSource();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(source.getToken());

        ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
        ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
        try {
            Presentation presentation = new Presentation(input.getAbsolutePath(), options);
            try {
                presentation.save(output.getAbsolutePath(), SaveFormat.Pdf);
            } finally {
                presentation.dispose();
            }
        } catch (OperationCanceledException canceled) {
            System.out.println("Presentation processing was canceled");
        } finally {
            timeout.cancel(false);
            timer.shutdown();
        }
    }
}
```

## **在處理下一張投影片前停止**

對簡報與匯出投影片的迴圈使用相同的 [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/)。在每次匯出前檢查 [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--)。若呼叫端能使用部分結果，則回傳成功匯出的投影片編號。

使用名為 `sample.pptx`、至少包含兩張投影片的簡報。[Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) 接受投影片編號陣列的重載會以 1 為起始編號。此範例將每張投影片儲存為單獨的 PDF，並在記錄第一個成功匯出後立即請求取消。

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;
import java.io.File;

public class SlideExporter {
    private static List<Integer> exportSlides(File directory, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        File input = new File(directory, "sample.pptx");
        Presentation presentation = new Presentation(input.getAbsolutePath(), options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    File output = new File(directory, "slide-" + number + ".pdf");
                    presentation.save(output.getAbsolutePath(), new int[] { number }, SaveFormat.Pdf);
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

    // 從背景執行緒呼叫，並傳入包含 sample.pptx 的 context.getFilesDir()。
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

此範例寫入 `slide-1.pdf`，並列印 `Starting slide 1` 後接 `Completed: [1]`。迴圈在開始第 2 張投影片前偵測到請求。若取消在儲存期間到達，迴圈會在記錄該投影片完成之前退出。

如果呼叫端需要處理取消，請將迴圈頂部的檢查及其 `break` 改為 `token.throwIfInterruptionRequested()`。移除儲存周圍的 `try`/`catch`，讓匯出期間的取消也能傳遞給呼叫端。使用相同的輸入，範例只會列印 `Starting slide 1` 並寫入 `slide-1.pdf`。在第二次迭代開始時，[throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) 會拋出 `com.aspose.slides.exceptions.OperationCanceledException`，在下一個匯出開始前。此方法不會返回任何清單。

## **常見問題**

**何時應該請求取消？**

當作業超過您的時間限制或您的應用程式不再需要結果時，請求取消。

**[InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) 與 [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) 有何差異？**

來源允許您的應用程式請求取消。Token 允許 Aspose.Slides 與您的應用程式檢查該請求。

**我可以從 Java 計時器取消作業嗎？**

可以。排程在與簡報關聯的來源上呼叫 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--)。

**我可以中斷哪些作業？**

您可以中斷載入、儲存和算繪。透過 [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) 將 token 傳遞給 [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-)。之後簡報在執行後續作業（例如儲存為 PDF）時即可偵測取消。

**作業會立即停止嗎？**

取消是合作式的。作業會定期檢查 token，並在偵測到請求時停止。

**如果在作業完成後呼叫 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--)，會發生什麼？**

已完成的作業會保留其結果。

**多個作業可以共用同一個 [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)嗎？**

可以。呼叫 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) 會為所有使用該來源 token 的作業請求取消。若要獨立取消每個作業，請為每個作業使用不同的來源。