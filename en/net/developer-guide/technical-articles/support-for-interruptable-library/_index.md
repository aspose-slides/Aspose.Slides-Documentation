---
title: Support For Interruptable Library
type: docs
weight: 150
url: /net/support-for-interruptable-library/

---

## **Interruptable Library**

In [Aspose.Slides 18.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-18-4-release-notes/), we added the [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken) class and [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource) class. They provide support for the interruption of long-running tasks, such as deserialization, serialization, or rendering. 

- InterruptionTokenSource represents the source of the token or multiple tokens passed to **ILoadOptions.InterruptionToken**. 
- When the ILoadOptions.InterruptionToken is set and the LoadOptions instance is passed to the Presentation constructor, invoking the InterruptionTokenSource.Interrupt method causes the interruption of any long-running task related to the Presentation. 

This code snippet below demonstrates the interruption of a running task:

```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("pres.pptx", options))
        {
            presentation.Save("pres.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // run action in a separate thread
    Thread.Sleep(10000);            // timeout
    tokenSource.Interrupt();        // stop conversion


}
private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}

```

## **.NET CancellationToken and Interruptable Library**

When you need to use the [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) alongside Slides Interruptable Library, you can wrap the Presentation processing and interrupt [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken) if [cancellationToken.IsCancellationRequested](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) is set to true. 

This C# code demonstrates the described operation:

``` csharp
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("pres.pptx", "pres.pdf", tokenSource.Token);
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
    Task task = Run(action, tokenSource.Token); // run action in a separate thread

    while (!task.Wait(500)) // wait to monitor if cancellationToken.IsCancellationRequested is set. 
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

## FAQ

**Q: What is the purpose of the Aspose.Slides interrupt library?**
It provides a mechanism to stop long-running operations, such as loading, saving, or rendering presentations, before they complete. This is useful in scenarios where processing time must be limited or when the task is no longer required.

**Q: What is the difference between [`InterruptionToken`](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) and [`InterruptionTokenSource`](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/)?**

* **InterruptionToken** is passed to the Slides API and checked during long-running operations.
* **InterruptionTokenSource** is used by your code to create tokens and trigger interruptions by calling `Interrupt()`.

**Q: Can I use .NET [`CancellationToken`](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) with the interrupt library?**
Yes. You can monitor the [`CancellationToken`](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) in your application logic and call [`InterruptionTokenSource.Interrupt()`](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) when a cancellation is requested, allowing Slides interruption to integrate with standard .NET cancellation workflows.

**Q: What tasks can be interrupted?**
Any Slides task that accepts an [`InterruptionToken`](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/), such as loading a presentation with `Presentation(path, loadOptions)` or saving with `Presentation.Save(...)`, can be interrupted.

**Q: Does interruption happen immediately?**
No. Interruption is cooperative. The operation checks the token periodically and stops as soon as it detects a call to [`Interrupt()`](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/).

**Q: What happens if I call [`Interrupt()`](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) after a task has already completed?**
Nothing - the call will have no effect if the corresponding task has already completed.

**Q: Can I reuse the same [`InterruptionTokenSource`](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/) for multiple tasks?** Yes, but after calling [`Interrupt()`](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) on a token source, all tasks using its tokens will be interrupted. Use separate token sources to manage different tasks separately.