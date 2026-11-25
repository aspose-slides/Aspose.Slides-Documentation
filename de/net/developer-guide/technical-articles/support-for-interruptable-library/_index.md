---
title: Unterbrechung lang laufender Präsentationsvorgänge in .NET
linktitle: Präsentationsvorgänge unterbrechen
type: docs
weight: 150
url: /de/net/support-for-interruptable-library/
keywords:
- unterbrechbare Vorgänge
- Unterbrechungs-Token
- Abbruch-Token
- lang laufende Aufgabe
- Aufgabe unterbrechen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie lang laufende Präsentationsvorgänge in Aspose.Slides für .NET abbrechen und beim Export von Folien in einer Schleife ein partielles Ergebnis zurückgeben."
---
## **Übersicht**

Aspose.Slides für .NET kann lang laufende Vorgänge wie das Laden, Speichern und Rendern von Präsentationen unterbrechen. Ihre Anwendung kann dasselbe Unterbrechungs‑Token verwenden, um eine Schleife zu stoppen, bevor sie die nächste Folie verarbeitet.

## **Unterbrechung eines Präsentationsvorgangs**

Erstellen Sie eine [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), weisen Sie dessen [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) dem [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/) zu und übergeben Sie die Ladeoptionen an den [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Um eine Abbruchanforderung zu stellen, rufen Sie [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) auf der Quelle auf. Ein unterbrechbarer Vorgang stoppt, wenn er die Anforderung bemerkt.

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
    Run(action, tokenSource.Token); // führe die Aktion in einem separaten Thread aus
    Thread.Sleep(10000);            // Zeitüberschreitung
    tokenSource.Interrupt();        // Konvertierung stoppen
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET-Abbruch mit Aspose.Slides verknüpfen**

Wenn Ihre Anwendung ein .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) verwendet, leiten Sie dessen Abbruchanforderung an Aspose.Slides weiter. Das Beispiel startet den Export von `sample.pptx` nach `sample.pdf` und setzt ein Zeitlimit von 20 Sekunden. Während der Export läuft, prüft es alle 500 Millisekunden [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested). Wird die Eigenschaft auf `true` gesetzt, wird [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) aufgerufen.

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
    Task task = Run(action, tokenSource.Token); // Aktion in einem separaten Thread ausführen

    while (!task.Wait(500)) // warten und überwachen, ob cancellationToken.IsCancellationRequested gesetzt ist
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // Presentation-Verarbeitung unterbrechen
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

## **Vor der Verarbeitung der nächsten Folie stoppen**

Verwenden Sie dasselbe [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) für die Präsentation und für die Schleife, die deren Folien exportiert. Prüfen Sie [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) bevor Sie jeden Export starten. Wenn der Aufrufer ein partielles Ergebnis verwenden kann, geben Sie die Foliennummern der erfolgreich abgeschlossenen Exporte zurück.

Verwenden Sie eine Präsentation namens `sample.pptx` mit mindestens zwei Folien. Das Beispiel fordert die Abbruchanforderung sofort an, nachdem der erste erfolgreiche Export protokolliert wurde.

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

Das Beispiel schreibt `slide-1.pdf` und gibt `Starting slide 1` gefolgt von `Completed: [1]` aus. Die Schleife sieht die Anforderung, bevor sie Folie 2 startet. Wenn die Abbruchanforderung stattdessen [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) während eines Exports unterbricht, beendet der `catch`‑Block die Schleife, bevor der aktuelle Folienstatus als abgeschlossen vermerkt wird.

Wenn der Aufrufer den Abbruch selbst behandeln muss, ersetzen Sie die `if`‑Prüfung und das zugehörige `break` am Anfang der Schleife durch einen Aufruf von [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) auf dem Token. Entfernen Sie das `try`/`catch`‑Konstrukt rund um den Export, damit ein Abbruch während eines Speichervorgangs ebenfalls zum Aufrufer durchdringt. Mit denselben Eingaben gibt das Beispiel nur `Starting slide 1` aus und schreibt `slide-1.pdf`. Zu Beginn der zweiten Iteration erhält der Aufrufer eine [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception), bevor der Export beginnt. Die Methode liefert keine Liste zurück.

## **FAQ**

**Wann sollte ich eine Abbruchanforderung stellen?**

Stellen Sie eine Abbruchanforderung, wenn ein Vorgang Ihr Zeitlimit überschreitet oder wenn Ihre Anwendung das Ergebnis nicht mehr benötigt.

**Was ist der Unterschied zwischen [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) und [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Die Quelle ermöglicht Ihrer Anwendung, einen Abbruch anzufordern. Das Token ermöglicht Aspose.Slides und Ihrer Anwendung, diese Anforderung zu prüfen.

**Kann ich ein .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) mit Aspose.Slides verwenden?**

Ja. Wenn Ihr .NET‑Token einen Abbruch signalisiert, rufen Sie [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) auf der mit der Präsentation verbundenen Quelle auf.

**Welche Vorgänge kann ich unterbrechen?**

Sie können das Laden, Speichern und Rendern unterbrechen. Übergeben Sie das Token dem [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) über [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/). Die Präsentation kann dann während nachfolgender Vorgänge wie [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) den Abbruch beobachten.

**Hält ein Vorgang sofort an?**

Der Abbruch ist kooperativ. Ein Vorgang prüft das Token periodisch und stoppt, sobald er die Anforderung bemerkt.

**Was passiert, wenn ich [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) nach Abschluss eines Vorgangs aufrufe?**

Der bereits abgeschlossene Vorgang behält sein Ergebnis bei.

**Können mehrere Vorgänge ein gemeinsames [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) verwenden?**

Ja. Das Aufrufen von [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) fordert den Abbruch für jeden Vorgang an, der ein Token dieser Quelle verwendet. Verwenden Sie für jeden Vorgang, den Sie unabhängig abbrechen möchten, eine separate Quelle.