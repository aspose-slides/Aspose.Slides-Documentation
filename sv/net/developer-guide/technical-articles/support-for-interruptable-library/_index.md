---
title: Avbryt långvariga presentationsoperationer i .NET
linktitle: Avbryt presentationsoperationer
type: docs
weight: 150
url: /sv/net/support-for-interruptable-library/
keywords:
- avbrytbara operationer
- avbrottstoken
- avbrytningstoken
- långvarig uppgift
- avbryt uppgift
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du avbryter långvariga presentationsoperationer i Aspose.Slides för .NET och returnerar ett partiellt resultat vid export av bilder i en loop."
---
## **Översikt**

Aspose.Slides för .NET kan avbryta långvariga operationer såsom inläsning, sparande och rendering av presentationer. Din applikation kan använda samma avbrottstoken för att stoppa en loop innan den påbörjar bearbetning av nästa bild.

## **Avbryt en presentationsoperation**

Skapa en [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), tilldela dess [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) till [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/), och skicka inlastningsalternativen till [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). För att begära avbrytning, anropa [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) på källan. En avbrytbar operation stoppas när den observerar begäran.

Exemplet startar konverteringen av `sample.pptx` till `sample.ppt` i en bakgrundsuppgift och begär avbrytning efter 10 sekunder. Om konverteringen slutförs tidigare, är resultatet redan komplett.

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
    Run(action, tokenSource.Token); // kör åtgärden i en separat tråd
    Thread.Sleep(10000);            // tidsgräns
    tokenSource.Interrupt();        // stoppa konverteringen
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **Koppla .NET‑avbrytning till Aspose.Slides**

Om din applikation använder en .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken), vidarebefordra dess avbrytningsbegäran till Aspose.Slides. Exemplet startar export av `sample.pptx` till `sample.pdf` och sätter en tidsgräns på 20 sekunder. Medan exporten körs, kontrollerar den [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) var 500 millisekunder. När egenskapen blir `true` anropas [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/).

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
    Task task = Run(action, tokenSource.Token); // kör åtgärden i en separat tråd

    while (!task.Wait(500)) // vänta och övervaka om cancellationToken.IsCancellationRequested är satt
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // avbryt presentationsbearbetning
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

## **Stoppa innan nästa bild bearbetas**

Använd samma [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) för både presentationen och loopen som exporterar dess bilder. Kontrollera [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) innan varje export startas. Om anroparen kan använda ett partiellt resultat, returnera bildnumren för de exporter som slutförts framgångsrikt.

Använd en presentation med namnet `sample.pptx` som har minst två bilder. Exemplet begär avbrytning omedelbart efter att det registrerat den första lyckade exporten.

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

Exemplet skriver `slide-1.pdf` och skriver ut `Starting slide 1` följt av `Completed: [1]`. Loopen ser begäran innan den påbörjar bild 2. Om avbrytning istället avbryter [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) under en export, lämnar `catch`‑blocket loopen innan koden registrerar den aktuella bilden som slutförd.

Om anroparen behöver hantera avbrytning, ersätt `if`‑kontrollen och dess `break` högst upp i loopen med ett anrop till [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) på tokenen. Ta bort `try`/`catch`‑blocket runt exporten så att avbrytning under en sparning också når anroparen. Med samma indata skriver exemplet endast ut `Starting slide 1` och skriver `slide-1.pdf`. I början av den andra iterationen får anroparen ett [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) innan exporten påbörjas. Metoden returnerar ingen lista.

## **Vanliga frågor**

**När bör jag begära avbrytning?**

Begär avbrytning när en operation överskrider din tidsgräns eller när din applikation inte längre behöver resultatet.

**Vad är skillnaden mellan [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) och [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Källan låter din applikation begära avbrytning. Tokenen låter Aspose.Slides och din applikation kontrollera den begäran.

**Kan jag använda en .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) med Aspose.Slides?**

Ja. När din .NET‑token signalerar avbrytning, anropa [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) på källan som är associerad med presentationen.

**Vilka operationer kan jag avbryta?**

Du kan avbryta inläsning, sparning och rendering. Skicka tokenen till [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) via [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/). Presentationen kan sedan observera avbrytning under efterföljande operationer såsom [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/).

**Stannar en operation omedelbart?**

Avbrytning är samarbetsbaserad. En operation kontrollerar tokenen periodiskt och stoppar när den observerar begäran.

**Vad händer om jag anropar [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) efter att en operation har avslutats?**

Den avslutade operationen behåller sitt resultat.

**Kan flera operationer dela en [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Ja. Att anropa [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) begär avbrytning för varje operation som använder en token från den källan. Använd en separat källa för varje operation du vill avbryta oberoende.