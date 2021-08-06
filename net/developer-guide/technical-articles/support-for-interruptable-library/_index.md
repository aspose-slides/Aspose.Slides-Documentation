---
title: Support For Interruptable Library
type: docs
weight: 150
url: /net/support-for-interruptable-library/
---

## **Interruptable Library**
Now in Aspose.Slides [InterruptionToken](https://apireference.aspose.com/slides/net/aspose.slides/interruptiontoken) struct and InterruptionTokenSource class have been added. These types support interruption of long-running tasks, such as deserialization, serialization or rendering. InterruptionTokenSource represents the source of the token or multiple tokens passed to **ILoadOptions.InterruptionToken**. When ILoadOptions.InterruptionToken is set and this LoadOptions instance passed to the Presentation constructor, any long-running task related to this Presentation will be interrupted when InterruptionTokenSource.Interrupt method will be invoked.

Code snippet below demonstrates interruption of running task.

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

In case you have [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) and need to use it with Slides Interruptable Library, you can wrap Presentation processing and interrupt [InterruptionToken](https://apireference.aspose.com/slides/net/aspose.slides/interruptiontoken) if [cancellationToken.IsCancellationRequested](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested0 is set:

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