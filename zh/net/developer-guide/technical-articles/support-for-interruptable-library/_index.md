---
title: 中断 .NET 中的长时间运行的演示文稿操作
linktitle: 中断演示文稿操作
type: docs
weight: 150
url: /zh/net/support-for-interruptable-library/
keywords:
- 可中断的操作
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
description: "了解如何在 Aspose.Slides for .NET 中取消长时间运行的演示文稿操作，并在循环导出幻灯片时返回部分结果。"
---
## **概述**

Aspose.Slides for .NET can interrupt long-running operations such as loading, saving, and rendering presentations. Your application can use the same interruption token to stop a loop before it starts processing the next slide.

## **中断演示文稿操作**

Create an [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), assign its [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) to [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/), and pass the load options to the [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). To request cancellation, call [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) on the source. An interruptible operation stops when it observes the request.

The example starts converting `sample.pptx` to `sample.ppt` in a background task and requests cancellation after 10 seconds. If the conversion finishes earlier, the output is already complete.

```c#
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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
    Run(action, tokenSource.Token); // 在单独的线程中运行操作
    Thread.Sleep(10000);            // 超时
    tokenSource.Interrupt();        // 停止转换
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **将 .NET 取消令牌连接到 Aspose.Slides**

If your application uses a .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken), forward its cancellation request to Aspose.Slides. The example starts exporting `sample.pptx` to `sample.pdf` and sets a 20-second timeout. While the export is running, it checks [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) every 500 milliseconds. When the property becomes `true`, it calls [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/).

```cs
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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
    Task task = Run(action, tokenSource.Token); // 在单独的线程中运行操作

    while (!task.Wait(500)) // 等待并监控 cancellationToken.IsCancellationRequested 是否已设置
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

## **在处理下一张幻灯片前停止**

Use the same [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) for both the presentation and the loop that exports its slides. Check [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) before starting each export. If the caller can use a partial result, return the slide numbers for the exports that completed successfully.

Use a presentation named `sample.pptx` with at least two slides. The example requests cancellation immediately after it records the first successful export.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new InterruptionTokenSource();
var completed = ExportSlides("sample.pptx", source);
Console.WriteLine($"Completed: [{string.Join(", ", completed)}]");

static List<int> ExportSlides(string path, IInterruptionTokenSource source)
{
    var completed = new List<int>();
    IInterruptionToken token = source.Token;
    var options = new LoadOptions { InterruptionToken = token };
    using var presentation = new Presentation(path, options);

    for (var number = 1; number <= presentation.Slides.Count; number++)
    {
        if (token.IsInterruptionRequested)
            break;

        Console.WriteLine($"Starting slide {number}");
        try
        {
            presentation.Save($"slide-{number}.pdf", new[] { number }, SaveFormat.Pdf);
        }
        catch (OperationCanceledException) when (token.IsInterruptionRequested)
        {
            break;
        }

        completed.Add(number);
        if (number == 1)
            source.Interrupt();
    }

    return completed;
}
```

The example writes `slide-1.pdf` and prints `Starting slide 1` followed by `Completed: [1]`. The loop sees the request before it starts slide 2. If cancellation instead interrupts [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) during an export, the `catch` block exits the loop before the code records the current slide as complete.

If the caller needs to handle cancellation, replace the `if` check and its `break` at the top of the loop with a call to [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) on the token. Remove the `try`/`catch` around the export so cancellation during a save also reaches the caller. With the same input, the example prints only `Starting slide 1` and writes `slide-1.pdf`. At the start of the second iteration, the caller receives an [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) before the export begins. The method returns no list.

## **常见问题**

**何时应请求取消？**

Request cancellation when an operation exceeds your time limit or when your application no longer needs the result.

**[InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) 与 [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) 有何区别？**

The source lets your application request cancellation. The token lets Aspose.Slides and your application check for that request.

**我能在 Aspose.Slides 中使用 .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) 吗？**

Yes. When your .NET token signals cancellation, call [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) on the source associated with the presentation.

**我可以中断哪些操作？**

You can interrupt loading, saving, and rendering. Pass the token to the [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) through [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/). The presentation can then observe cancellation during subsequent operations such as [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/).

**操作会立即停止吗？**

Cancellation is cooperative. An operation checks the token periodically and stops when it observes the request.

**如果在操作完成后调用 [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) 会怎样？**

The completed operation keeps its result.

**多个操作可以共享同一个 [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Yes. Calling [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) requests cancellation for every operation that uses a token from that source. Use a separate source for each operation you want to cancel independently.