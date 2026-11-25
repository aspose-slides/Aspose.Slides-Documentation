---
title: 在 Java 中中断长时间运行的演示文稿操作
linktitle: 中断演示文稿操作
type: docs
weight: 120
url: /zh/java/support-for-interruptable-library/
keywords:
- 可中断操作
- 中断令牌
- 取消令牌
- 长时间运行的任务
- 中断任务
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中取消长时间运行的演示文稿操作，以及在循环导出幻灯片时返回部分结果。"
---
## **概述**

Aspose.Slides for Java 可中断长时间运行的操作，例如加载、保存和呈现演示文稿。您的应用程序可以使用相同的中断令牌在循环开始处理下一张幻灯片之前停止循环。

## **中断演示文稿操作**

创建一个[InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)，使用[getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--) 获取其令牌，并将该令牌传递给[LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-)。将加载选项传递给[Presentation 构造函数](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-)。若要请求取消，请在源上调用[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--)。可中断的操作在检测到请求后停止。

示例在后台线程中将 `sample.pptx` 转换为 `sample.ppt`。调用线程最多等待 10 秒以完成转换。如果转换仍在运行，它会请求取消并等待工作线程退出。

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

## **将 Java 超时连接到 Aspose.Slides**

要为演示文稿操作设置时间限制，可使用[ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html)在超时到期时调用[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--)。示例允许 20 秒加载 `sample.pptx` 并将其导出为 `sample.pdf`。如果导出提前完成，应用程序会取消已计划的请求。

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

## **在处理下一张幻灯片前停止**

对演示文稿及其导出幻灯片的循环使用相同的[IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/)。在每次导出前检查[isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--)。如果调用方可以使用部分结果，则返回已成功导出的幻灯片编号。

使用名为 `sample.pptx`、至少包含两张幻灯片的演示文稿。接受幻灯片编号数组的[Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) 重载的计数从 1 开始。示例将每张幻灯片保存为单独的 PDF，并在记录第一个成功导出后立即请求取消。

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

示例写入 `slide-1.pdf` 并打印 `Starting slide 1`，随后打印 `Completed: [1]`。循环在启动第 2 张幻灯片前检测到请求。如果在保存过程中收到取消，循环将在记录该幻灯片完成之前退出。

如果调用方需要处理取消，请将循环顶部的检查及其 `break` 替换为 `token.throwIfInterruptionRequested()`。删除保存周围的 `try`/`catch`，使导出期间的取消也能传递给调用方。使用相同的输入，示例仅打印 `Starting slide 1` 并写入 `slide-1.pdf`。在第二次迭代开始时，[throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) 抛出 `com.aspose.slides.exceptions.OperationCanceledException`，在下一个导出开始前。该方法不返回列表。

## **常见问题**

**何时应请求取消？**

当操作超出您的时间限制或您的应用程序不再需要结果时，请请求取消。

**What is the difference between [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

源允许您的应用程序请求取消。令牌允许 Aspose.Slides 和您的应用程序检查该请求。

**我可以从 Java 定时器取消操作吗？**

可以。安排对与演示文稿关联的源调用[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--)。

**我可以中断哪些操作？**

您可以中断加载、保存和渲染。通过[LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) 将令牌传递给[Presentation 构造函数](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-)。随后，演示文稿在后续操作（例如保存为 PDF）期间可以检测到取消。

**操作会立即停止吗？**

取消是协作式的。操作会定期检查令牌，并在检测到请求时停止。

**如果在操作完成后调用[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--)会发生什么？**

已完成的操作保留其结果。

**可以多个操作共享一个[InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

可以。调用[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) 会请求取消所有使用该源令牌的操作。对于希望独立取消的每个操作，请使用单独的源。