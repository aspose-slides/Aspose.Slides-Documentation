---
title: Unterstützung für die Interruptable Bibliothek
type: docs
weight: 150
url: /de/net/support-for-interruptable-library/
keywords:
- Interruptable Bibliothek
- Interruptions-Token
- Abbruch-Token
- langlaufende Aufgabe
- Aufgabe unterbrechen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Machen Sie langlaufende Aufgaben mit Aspose.Slides für .NET abbrechbar. Unterbrechen Sie das Rendern und die Konvertierung für PowerPoint und OpenDocument sicher, mit Beispielen."
---

## **Interruptable Bibliothek**

In [Aspose.Slides 18.4](https://releases.aspose.com/slides/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/), haben wir die Klassen [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) und [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) eingeführt. Sie ermöglichen das Unterbrechen von langlaufenden Vorgängen wie Deserialisierung, Serialisierung und Rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) ist die Quelle des/der Token(s), die an [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/) übergeben werden.
- Wenn [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/) festgelegt ist und die Instanz von [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) an den Konstruktor von [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) übergeben wird, unterbricht das Aufrufen von [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) jede langlaufende Aufgabe, die mit dieser [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) verknüpft ist.

Das folgende Code‑Snippet demonstriert das Unterbrechen einer laufenden Aufgabe:
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
    Run(action, tokenSource.Token); // führt die Aktion in einem separaten Thread aus
    Thread.Sleep(10000);            // Zeitüberschreitung
    tokenSource.Interrupt();        // stoppt die Konvertierung
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```


## **.NET CancellationToken und Interruptable Bibliothek**

Wenn Sie einen [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) zusammen mit der Aspose.Slides Interruptible‑Bibliothek verwenden müssen, wickeln Sie die Verarbeitung der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ein und unterbrechen Sie das [InterruptionToken], wenn [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) `true` ist.

Dieser C#‑Code demonstriert die Vorgehensweise:
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
    Task task = Run(action, tokenSource.Token); // führt die Aktion in einem separaten Thread aus

    while (!task.Wait(500)) // wartet und überwacht, ob cancellationToken.IsCancellationRequested gesetzt ist
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // unterbricht die Präsentationsverarbeitung
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

**Welchen Zweck hat die Aspose.Slides Interrupt-Bibliothek?**

Sie bietet einen Mechanismus zum Unterbrechen von langlaufenden Vorgängen – wie dem Laden, Speichern oder Rendern von Präsentationen – bevor sie abgeschlossen sind. Das ist nützlich, wenn die Verarbeitungszeit begrenzt werden muss oder die Aufgabe nicht mehr benötigt wird.

**Was ist der Unterschied zwischen [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) und [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/)?**

- `InterruptionToken` wird an die Aspose.Slides‑API übergeben und während langlaufender Vorgänge überprüft.
- `InterruptionTokenSource` wird in Ihrem Code verwendet, um Token zu erstellen und Unterbrechungen auszulösen, indem `Interrupt()` aufgerufen wird.

**Kann ich .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) mit der Interrupt‑Bibliothek verwenden?**

Ja. Sie können den [CancellationToken] in Ihrer Anwendungslogik überwachen und [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) aufrufen, wenn eine Abbruchanforderung vorliegt. Dadurch kann Aspose.Slides in standardmäßige .NET‑Abbruch‑Workflows integriert werden.

**Welche Vorgänge können unterbrochen werden?**

Jeder Aspose.Slides‑Vorgang, der ein [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) akzeptiert – z. B. das Laden einer Präsentation mit `Presentation(path, loadOptions)` oder das Speichern mit `Presentation.Save(...)` – kann unterbrochen werden.

**Findet die Unterbrechung sofort statt?**

Nein. Die Unterbrechung ist kooperativ: Der Vorgang prüft periodisch das Token und stoppt, sobald er erkennt, dass [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) aufgerufen wurde.

**Was passiert, wenn ich [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) aufrufe, nachdem ein Vorgang bereits abgeschlossen ist?**

Nichts – der Aufruf hat keine Wirkung, wenn der betreffende Vorgang bereits abgeschlossen ist.

**Kann ich dieselbe [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/) für mehrere Vorgänge wiederverwenden?**

Ja – aber nachdem Sie [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) für diese Quelle aufgerufen haben, werden alle Vorgänge, die deren Token verwenden, unterbrochen. Verwenden Sie separate Token‑Quellen, um Vorgänge unabhängig zu verwalten.