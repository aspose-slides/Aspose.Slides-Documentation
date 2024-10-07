---
title: Unterstützung für unterbrechbare Bibliothek
type: docs
weight: 150
url: /net/support-for-interruptable-library/

---

## **Unterbrechbare Bibliothek**

In [Aspose.Slides 18.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-18-4-release-notes/) haben wir die [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken) Klasse und die [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource) Klasse hinzugefügt. Sie bieten Unterstützung für die Unterbrechung von langlaufenden Aufgaben, wie z.B. Deserialisierung, Serialisierung oder Rendering.

- InterruptionTokenSource stellt die Quelle des Token oder mehrerer Token dar, die an **ILoadOptions.InterruptionToken** übergeben werden.
- Wenn das ILoadOptions.InterruptionToken gesetzt ist und die LoadOptions-Instanz an den Präsentationskonstruktor übergeben wird, führt der Aufruf der Methode InterruptionTokenSource.Interrupt zur Unterbrechung jeder langlaufenden Aufgabe, die mit der Präsentation verbunden ist.

Das folgende Code-Snippet demonstriert die Unterbrechung einer laufenden Aufgabe:

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
    Run(action, tokenSource.Token); // Aktion in einem separaten Thread ausführen
    Thread.Sleep(10000);            // Timeout
    tokenSource.Interrupt();        // Konvertierung stoppen
}
private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken und unterbrechbare Bibliothek**

Wenn Sie das [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) zusammen mit der unterbrechbaren Bibliothek von Slides verwenden müssen, können Sie die Präsentationsverarbeitung einwickeln und [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken) unterbrechen, wenn [cancellationToken.IsCancellationRequested](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) auf true gesetzt ist.

Dieser C#-Code demonstriert die beschriebene Operation:

```csharp
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
    Task task = Run(action, tokenSource.Token); // Aktion in einem separaten Thread ausführen

    while (!task.Wait(500)) // Warten, um zu überwachen, ob cancellationToken.IsCancellationRequested gesetzt ist.
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Die Präsentationsverarbeitung wurde abgebrochen");
            tokenSource.Interrupt(); // Unterbrechung der Präsentationsverarbeitung
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