---
title: 支持可中断库
type: docs
weight: 150
url: /zh/net/support-for-interruptable-library/
keywords:
- 可中断库
- 中断令牌
- 取消令牌
- 长时间运行的任务
- 中断任务
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 使长时间运行的任务可取消。安全地中断 PowerPoint 和 OpenDocument 的渲染和转换，并提供示例。"
---

## **可中断库**

在 [Aspose.Slides 18.4](https://releases.aspose.com/slides/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/)，我们引入了 [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) 和 [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) 类。它们允许您中断诸如反序列化、序列化和渲染等长时间运行的任务。

- [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) 是传递给 [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/) 的令牌来源。
- 当设置了 [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/) 并将 [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) 实例传递给 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 构造函数时，调用 [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) 会中断与该 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 关联的任何长时间运行的任务。

以下代码片段演示了中断正在运行的任务：
```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("sample.pptx", options))
        {
            presentation.Save("sample.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // 在单独线程中运行该操作
    Thread.Sleep(10000);            // 超时
    tokenSource.Interrupt();        // 停止转换
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```


## **.NET CancellationToken 与可中断库**

当需要在使用 Aspose.Slides 可中断库时同时使用 [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)，请将 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 处理包装起来，并在 [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) 为 `true` 时中断 [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/)。

此 C# 代码演示了该操作：
```cs
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("sample.pptx", "sample.pdf", tokenSource.Token);
}

static void ProcessPresentation(string path, string outPath, CancellationToken cancellationToken)
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions {InterruptionToken = token};
        using (Presentation presentation = new Presentation(path, options))
        {
            presentation.Save(outPath, SaveFormat.Pdf);
        }
    };
    
    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Task task = Run(action, tokenSource.Token); // 在单独线程中运行该操作

    while (!task.Wait(500)) // 等待并监视 cancellationToken.IsCancellationRequested 是否已设置
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // 中断演示文稿处理
        }
    }
}

private static Task Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    return Task.Run(() =>
    {
        action(token);
    });
}
```


## **常见问题**

**What is the purpose of the Aspose.Slides interrupt library?**

它提供了一种机制，用于在长时间运行的操作（如加载、保存或渲染演示文稿）完成之前中断这些操作。当需要限制处理时间或任务已不再需要时，这非常有用。

**What is the difference between [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/)?**

- `InterruptionToken` 被传递给 Aspose.Slides API，并在长时间运行的操作期间检查。
- `InterruptionTokenSource` 用于在代码中创建令牌，并通过调用 `Interrupt()` 触发中断。

**Can I use .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) with the interrupt library?**

可以。您可以在应用程序逻辑中监视 [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)，并在请求取消时调用 [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/)。这使得 Aspose.Slides 能够与标准的 .NET 取消工作流集成。

**What tasks can be interrupted?**

任何接受 [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) 的 Aspose.Slides 任务——例如使用 `Presentation(path, loadOptions)` 加载演示文稿或使用 `Presentation.Save(...)` 保存——都可以被中断。

**Does interruption happen immediately?**

不会。中断是协作式的：操作会定期检查令牌，并在检测到已调用 [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) 时尽快停止。

**What happens if I call [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) after a task has already completed?**

什么也不会发生——如果相应的任务已经完成，调用不会产生任何影响。

**Can I reuse the same [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/) for multiple tasks?**

可以——但是在对该源调用 [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) 后，所有使用其令牌的任务都会被中断。请使用独立的令牌源来独立管理任务。