---
title: Support For Interruptable Library
type: docs
weight: 150
url: /pythonnet/support-for-interruptable-library/

---

## **Interruptable Library**

In [Aspose.Slides 18.4](https://docs.aspose.com/slides/pythonnet/aspose-slides-for-net-18-4-release-notes/), we added the [InterruptionToken](https://apireference.aspose.com/slides/pythonnet/aspose.slides/interruptiontoken) class and [InterruptionTokenSource](https://apireference.aspose.com/slides/pythonnet/aspose.slides/interruptiontokensource) class. They provide support for the interruption of long-running tasks, such as deserialization, serialization, or rendering. 

- InterruptionTokenSource represents the source of the token or multiple tokens passed to **ILoadOptions.InterruptionToken**. 
- When the ILoadOptions.InterruptionToken is set and the LoadOptions instance is passed to the Presentation constructor, invoking the InterruptionTokenSource.Interrupt method causes the interruption of any long-running task related to the Presentation. 

This code snippet below demonstrates the interruption of a running task:

```py
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

When you need to use the [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) alongside Slides Interruptable Library, you can wrap the Presentation processing and interrupt [InterruptionToken](https://apireference.aspose.com/slides/pythonnet/aspose.slides/interruptiontoken) if [cancellationToken.IsCancellationRequested](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) is set to true. 

This Python code demonstrates the described operation:

```py
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