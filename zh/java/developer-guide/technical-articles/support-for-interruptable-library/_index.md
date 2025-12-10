---
title: 可中断库支持
type: docs
weight: 120
url: /zh/java/support-for-interruptable-library/
keywords:
- 可中断库
- 中断令牌
- 取消令牌
- 长时间运行任务
- 中断任务
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 使长时间运行的任务可取消。安全地中断 PowerPoint 和 OpenDocument 的渲染和转换，并提供示例。"
---

## **可中断库**

在 [Aspose.Slides 18.4](https://releases.aspose.com/slides/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/) 中，我们引入了 [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) 和 [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) 类。它们允许您中断诸如反序列化、序列化和渲染等长时间运行的任务。

- [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) 是传递给 [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) 的令牌的来源。
- 当设置了 [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) 并将 [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) 实例传递给 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 构造函数时，调用 [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) 会中断与该 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 关联的任何长时间运行的任务。

以下代码片段演示了如何中断正在运行的任务：
```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // 在单独的线程中运行操作
Thread.sleep(10000);     // 超时
tokenSource.interrupt(); // 停止转换
```


## **常见问题**

**Aspose.Slides 中断库的目的是什么？**

它提供了一种机制，可在长时间运行的操作（例如加载、保存或渲染演示文稿）完成之前中断它们。当需要限制处理时间或任务不再需要时，这非常有用。

**InterruptionToken 与 InterruptionTokenSource 有何区别？**

- `InterruptionToken` 被传递给 Aspose.Slides API 并在长时间运行的操作期间进行检查。
- `InterruptionTokenSource` 用于您的代码中创建令牌，并通过调用 `Interrupt()` 来触发中断。

**哪些任务可以被中断？**

任何接受 InterruptionToken 的 Aspose.Slides 任务——例如使用 `Presentation(path, loadOptions)` 加载演示文稿或使用 `Presentation.save(...)` 保存——都可以被中断。

**中断会立即发生吗？**

不会。中断是协作式的：操作会定期检查令牌，并在检测到已调用 `Interrupt()` 时立即停止。

**如果在任务已经完成后调用 `Interrupt()` 会怎样？**

不会有任何影响——如果相应的任务已经完成，调用将不产生效果。

**我可以在多个任务中复用同一个 InterruptionTokenSource 吗？**

可以——但在对该源调用 `Interrupt()` 后，使用其令牌的所有任务都会被中断。请使用独立的令牌源来分别管理任务。