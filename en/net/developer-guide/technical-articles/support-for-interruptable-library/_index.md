---
title: Support For Interruptable Library
type: docs
weight: 150
url: /net/support-for-interruptable-library/
keywords:
- interruptable library
- interruption token
- cancellation token
- long-running task
- interrupt task
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Make long-running tasks cancelable with Aspose.Slides for .NET. Interrupt rendering and conversions for PowerPoint and OpenDocument safely, with examples."
---

## **Interruptable Library**

In [Aspose.Slides 18.4](https://releases.aspose.com/slides/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/), we introduced the [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) classes. They allow you to interrupt long-running tasks such as deserialization, serialization, and rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) is the source of the token(s) passed to [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/).
- When [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/) is set and the [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) instance is passed to the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) constructor, invoking [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) interrupts any long-running task associated with that [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).

The following code snippet demonstrates interrupting a running task:

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
    Run(action, tokenSource.Token); // run the action in a separate thread
    Thread.Sleep(10000);            // timeout
    tokenSource.Interrupt();        // stop the conversion
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken and Interruptable Library**

When you need to use a [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) alongside the Aspose.Slides Interruptible library, wrap the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) processing and interrupt the [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) when [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) is `true`.

This C# code demonstrates the operation:

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
    Task task = Run(action, tokenSource.Token); // run the action in a separate thread

    while (!task.Wait(500)) // wait and monitor whether cancellationToken.IsCancellationRequested is set
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // interrupt Presentation processing
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

## **FAQ**

**Q: What is the purpose of the Aspose.Slides interrupt library?**

It provides a mechanism to interrupt long-running operations—such as loading, saving, or rendering presentations—before they complete. This is useful when processing time must be limited or the task is no longer needed.

**Q: What is the difference between [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/)?**

- `InterruptionToken` is passed to the Aspose.Slides API and checked during long-running operations.
- `InterruptionTokenSource` is used in your code to create tokens and trigger interruptions by calling `Interrupt()`.

**Q: Can I use .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) with the interrupt library?**

Yes. You can monitor the [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) in your application logic and call [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) when cancellation is requested. This enables Aspose.Slides to integrate with standard .NET cancellation workflows.

**Q: What tasks can be interrupted?**

Any Aspose.Slides task that accepts an [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/)—such as loading a presentation with `Presentation(path, loadOptions)` or saving with `Presentation.Save(...)`—can be interrupted.

**Q: Does interruption happen immediately?**

No. Interruption is cooperative: the operation periodically checks the token and stops as soon as it detects that [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) has been called.

**Q: What happens if I call [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) after a task has already completed?**

Nothing—the call has no effect if the corresponding task has already completed.

**Q: Can I reuse the same [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/) for multiple tasks?**

Yes—but after you call [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) on that source, all tasks using its tokens will be interrupted. Use separate token sources to manage tasks independently.
