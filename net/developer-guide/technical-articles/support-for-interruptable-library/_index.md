---
title: Support For Interruptable Library
type: docs
weight: 150
url: /net/support-for-interruptable-library/
---

## **Interruptable Library**
Now in Aspose.Slides InterruptionToken struct and InterruptionTokenSource class have been added. These types support interruption of long-running tasks, such as deserialization, serialization or rendering. InterruptionTokenSource represents the source of the token or multiple tokens passed to **ILoadOptions.InterruptionToken**. When ILoadOptions.InterruptionToken is set and this LoadOptions instance passed to the Presentation constructor, any long-running task related to this Presentation will be interrupted when InterruptionTokenSource.Interrupt method will be invoked.

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

