---
title: Interrompere le operazioni di presentazione a lunga durata in .NET
linktitle: Interrompi operazioni di presentazione
type: docs
weight: 150
url: /it/net/support-for-interruptable-library/
keywords:
- operazioni interrompibili
- token di interruzione
- token di cancellazione
- attività a lunga esecuzione
- interrompi attività
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come annullare le operazioni di presentazione a lunga durata in Aspose.Slides per .NET e restituire un risultato parziale durante l'esportazione delle diapositive in un ciclo."
---
## **Panoramica**

Aspose.Slides per .NET può interrompere operazioni a lunga esecuzione come il caricamento, il salvataggio e il rendering di presentazioni. La tua applicazione può usare lo stesso token di interruzione per fermare un ciclo prima che inizi l'elaborazione della diapositiva successiva.

## **Interrompere un'operazione di presentazione**

Crea un [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), assegna il suo [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) a [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/), e passa le opzioni di caricamento al [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Per richiedere la cancellazione, chiama [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) sulla sorgente. Un'operazione interrompibile si arresta quando osserva la richiesta.

L'esempio avvia la conversione di `sample.pptx` in `sample.ppt` in un'attività in background e richiede la cancellazione dopo 10 secondi. Se la conversione termina prima, l'output è già completo.

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
    Run(action, tokenSource.Token); // esegui l'azione in un thread separato
    Thread.Sleep(10000);            // tempo di attesa
    tokenSource.Interrupt();        // ferma la conversione
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **Collegare la cancellazione .NET ad Aspose.Slides**

Se la tua applicazione utilizza un .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken), inoltra la sua richiesta di cancellazione ad Aspose.Slides. L'esempio avvia l'esportazione di `sample.pptx` in `sample.pdf` e imposta un timeout di 20 secondi. Mentre l'esportazione è in corso, controlla [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) ogni 500 millisecondi. Quando la proprietà diventa `true`, chiama [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/).

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
    Task task = Run(action, tokenSource.Token); // esegui l'azione in un thread separato

    while (!task.Wait(500)) // attendi e monitora se cancellationToken.IsCancellationRequested è impostato
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // interrompi l'elaborazione della presentazione
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

## **Interrompere prima di elaborare la diapositiva successiva**

Usa lo stesso [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) sia per la presentazione sia per il ciclo che esporta le sue diapositive. Controlla [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) prima di avviare ogni esportazione. Se il chiamante può utilizzare un risultato parziale, restituisci i numeri delle diapositive delle esportazioni completate con successo.

Utilizza una presentazione denominata `sample.pptx` con almeno due diapositive. L'esempio richiede la cancellazione subito dopo aver registrato la prima esportazione riuscita.

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

L'esempio scrive `slide-1.pdf` e stampa `Starting slide 1` seguito da `Completed: [1]`. Il ciclo rileva la richiesta prima di avviare la diapositiva 2. Se la cancellazione interrompe invece [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) durante un'esportazione, il blocco `catch` esce dal ciclo prima che il codice registri la diapositiva corrente come completata.

Se il chiamante deve gestire la cancellazione, sostituisci il controllo `if` e il suo `break` all'inizio del ciclo con una chiamata a [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) sul token. Rimuovi il blocco `try`/`catch` intorno all'esportazione affinché la cancellazione durante un salvataggio raggiunga anche il chiamante. Con lo stesso input, l'esempio stampa solo `Starting slide 1` e scrive `slide-1.pdf`. All'inizio della seconda iterazione, il chiamante riceve un [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) prima che l'esportazione inizi. Il metodo non restituisce alcun elenco.

## **FAQ**

**Quando dovrei richiedere la cancellazione?**

Richiedi la cancellazione quando un'operazione supera il tuo limite di tempo o quando la tua applicazione non ha più bisogno del risultato.

**Qual è la differenza tra [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

La sorgente consente alla tua applicazione di richiedere la cancellazione. Il token consente ad Aspose.Slides e alla tua applicazione di verificare tale richiesta.

**Posso usare un .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) con Aspose.Slides?**

Sì. Quando il tuo token .NET segnala la cancellazione, chiama [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) sulla sorgente associata alla presentazione.

**Quali operazioni posso interrompere?**

Puoi interrompere il caricamento, il salvataggio e il rendering. Passa il token al costruttore [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) tramite [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/). La presentazione può quindi osservare la cancellazione durante le operazioni successive, come [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/).

**Un'operazione si arresta immediatamente?**

La cancellazione è cooperativa. Un'operazione controlla periodicamente il token e si arresta quando osserva la richiesta.

**Cosa succede se chiamo [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) dopo che un'operazione è terminata?**

L'operazione completata conserva il suo risultato.

**Possono più operazioni condividere un [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Sì. Chiamare [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) richiede la cancellazione per ogni operazione che utilizza un token di quella sorgente. Usa una sorgente separata per ogni operazione che desideri annullare in modo indipendente.