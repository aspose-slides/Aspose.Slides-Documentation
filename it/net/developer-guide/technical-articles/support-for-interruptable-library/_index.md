---
title: Supporto per la libreria interruttibile
type: docs
weight: 150
url: /it/net/support-for-interruptable-library/
keywords:
- libreria interruttibile
- token di interruzione
- token di cancellazione
- operazione a lunga durata
- interrompere attività
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Rendi le operazioni a lunga durata annullabili con Aspose.Slides per .NET. Interrompi in modo sicuro il rendering e le conversioni per PowerPoint e OpenDocument, con esempi."
---
## **Panoramica**

Aspose.Slides for .NET fornisce un meccanismo di elaborazione interrompibile per operazioni di presentazione a lunga durata, come deserializzazione, serializzazione e rendering. Questo meccanismo si basa sulle classi `InterruptionToken` e `InterruptionTokenSource`.

Un `InterruptionToken` può essere assegnato a `LoadOptions` e passato al costruttore di `Presentation`. Quando si chiama `InterruptionTokenSource.Interrupt()`, l'operazione a lunga durata associata viene interrotta. L'articolo mostra anche come utilizzare questo meccanismo insieme al `CancellationToken` standard di .NET monitorando le richieste di cancellazione e chiamando `Interrupt()` quando la cancellazione è richiesta.

## **Libreria Interrompibile**

In [Aspose.Slides 18.4](https://releases.aspose.com/slides/it/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/), abbiamo introdotto le classi [InterruptionToken](https://reference.aspose.com/slides/it/net/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/it/net/aspose.slides/interruptiontokensource/). Esse consentono di interrompere operazioni a lunga durata come deserializzazione, serializzazione e rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/it/net/aspose.slides/interruptiontokensource/) è la sorgente del token (o dei token) passato a [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/it/net/aspose.slides/iloadoptions/interruptiontoken/).
- Quando [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/it/net/aspose.slides/iloadoptions/interruptiontoken/) è impostato e l'istanza di [LoadOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/) viene passata al costruttore di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/), chiamare [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/it/net/aspose.slides/interruptiontokensource/interrupt/) interrompe qualsiasi operazione a lunga durata associata a quella [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).

Il seguente frammento di codice dimostra come interrompere un'operazione in esecuzione:

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
    Run(action, tokenSource.Token); // esegui l'azione in un thread separato
    Thread.Sleep(10000);            // tempo di attesa
    tokenSource.Interrupt();        // interrompi la conversione
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken e Libreria Interrompibile**

Quando è necessario utilizzare un [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) insieme alla libreria Interrompibile di Aspose.Slides, avvolgere l'elaborazione di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e interrompere il [InterruptionToken](https://reference.aspose.com/slides/it/net/aspose.slides/interruptiontoken/) quando [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) è `true`.

Questo codice C# dimostra l'operazione:

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
    Task task = Run(action, tokenSource.Token); // esegui l'azione in un thread separato

    while (!task.Wait(500)) // attendi e monitora se cancellationToken.IsCancellationRequested è impostato
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // interrompi l'elaborazione della Presentazione
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

**Qual è lo scopo della libreria di interruzione di Aspose.Slides?**

Fornisce un meccanismo per interrompere operazioni a lunga durata — come caricamento, salvataggio o rendering di presentazioni — prima che terminino. È utile quando il tempo di elaborazione deve essere limitato o l'operazione non è più necessaria.

**Qual è la differenza tra [InterruptionToken](https://reference.aspose.com/slides/it/net/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/it/net/aspose.slides/iinterruptiontokensource/)?**

- `InterruptionToken` viene passato all'API Aspose.Slides e verificato durante le operazioni a lunga durata.
- `InterruptionTokenSource` è usato nel tuo codice per creare token e attivare interruzioni chiamando `Interrupt()`.

**Posso usare .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) con la libreria di interruzione?**

Sì. Puoi monitorare il [CancellationToken] nella logica della tua applicazione e chiamare [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/it/net/aspose.slides/iinterruptiontokensource/interrupt/) quando viene richiesto l'annullamento. Questo consente ad Aspose.Slides di integrarsi con i flussi di lavoro di cancellazione standard di .NET.

**Quali attività possono essere interrotte?**

Qualsiasi attività di Aspose.Slides che accetta un [InterruptionToken] — ad esempio il caricamento di una presentazione con `Presentation(path, loadOptions)` o il salvataggio con `Presentation.Save(...)` — può essere interrotta.

**L'interruzione avviene immediatamente?**

No. L'interruzione è cooperativa: l'operazione controlla periodicamente il token e si arresta non appena rileva che [Interrupt()](https://reference.aspose.com/slides/it/net/aspose.slides/iinterruptiontokensource/interrupt/) è stato chiamato.

**Cosa succede se chiamo [Interrupt()](https://reference.aspose.com/slides/it/net/aspose.slides/iinterruptiontokensource/interrupt/) dopo che un'attività è già terminata?**

Niente — la chiamata non ha effetto se l'attività corrispondente è già terminata.

**Posso riutilizzare lo stesso [InterruptionTokenSource](https://reference.aspose.com/slides/it/net/aspose.slides/iinterruptiontokensource/) per più attività?**

Sì — ma dopo aver chiamato [Interrupt()](https://reference.aspose.com/slides/it/net/aspose.slides/iinterruptiontokensource/interrupt/) su quella sorgente, tutte le attività che utilizzano i suoi token verranno interrotte. Usa sorgenti di token separate per gestire le attività in modo indipendente.