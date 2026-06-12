---
title: Generatore di Diapositive Multilingue con IA
linktitle: Generatore con IA
type: docs
weight: 40
url: /it/net/ai/generator/
keywords:
- presentazione multilingue
- diapositiva multilingue
- generatore di presentazioni IA
- generatore di diapositive IA
- funzionalità alimentata da IA
- agente IA
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Genera diapositive multilingue dal testo con Aspose.Slides per .NET. Applica il tuo modello ed esporta presentazioni rifinite in PowerPoint e OpenDocument. Scopri di più."
---
## **Introduzione**

Aspose.Slides introduce una nuova funzionalità basata sull'IA, il **Generatore di Presentazioni**, che consente agli sviluppatori di creare automaticamente presentazioni PowerPoint ben strutturate a partire da semplici input di testo, come descrizioni di argomenti, riassunti, citazioni o elenchi puntati.

Gli utenti possono regolare il livello di dettaglio del contenuto e, facoltativamente, applicare un modello di presentazione personalizzato per definire il design visivo.

Attualmente, l'AI Presentation Generator struttura il contenuto utilizzando blocchi di testo, elenchi puntati e tabelle. La generazione di immagini non è ancora supportata; tuttavia, le immagini possono essere aggiunte facilmente in seguito tramite gli strumenti di Aspose.Slides o manualmente.

L'output è una presentazione PowerPoint completa che può essere utilizzata così com'è o esportata in qualsiasi formato supportato dall'API di Aspose.Slides. Sebbene il generatore produca risultati di alta qualità, potrebbero essere necessarie piccole modifiche post‑produzione per soddisfare requisiti specifici.

## **Come funziona**

Aspose.Slides non include modelli IA integrati; invece, si integra con servizi IA esterni tramite Internet. Questa integrazione è gestita dalla classe [SlidesAIAgent](https://reference.aspose.com/slides/it/net/aspose.slides.ai/slidesaiagent/) che utilizza un'implementazione dell'interfaccia [IAIWebClient](https://reference.aspose.com/slides/it/net/aspose.slides.ai/iaiwebclient/) per comunicare con il modello IA.

Puoi utilizzare il [OpenAIWebClient](https://reference.aspose.com/slides/it/net/aspose.slides.ai/openaiwebclient/) integrato, che si connette all'API di OpenAI, o fornire un'implementazione personalizzata di [IAIWebClient](https://reference.aspose.com/slides/it/net/aspose.slides.ai/iaiwebclient/) per lavorare con un altro provider IA o modello di linguaggio. Aspose.Slides gestisce tutta la comunicazione con il servizio IA ed elabora le risposte dell'IA per generare le diapositive. Nota che l'API di OpenAI è un servizio a pagamento, quindi è necessario un account e una chiave API quando si utilizza il [OpenAIWebClient](https://reference.aspose.com/slides/it/net/aspose.slides.ai/openaiwebclient/).

## **Scriviamo il codice**

### **Esempio 1**

Questo esempio dimostra come generare una presentazione sull'argomento Aspose.Slides utilizzando il [OpenAIWebClient](https://reference.aspose.com/slides/it/net/aspose.slides.ai/openaiwebclient/) integrato.

```csharp
// Crea un'istanza di OpenAIWebClient, l'implementazione integrata del client web OpenAI.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// Crea un'istanza di SlidesAIAgent, che fornisce l'accesso alle funzionalità alimentate da IA.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Definisci l'istruzione per generare la presentazione.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Genera una presentazione con una quantità media di contenuto basata sull'istruzione.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Salva la presentazione generata sul disco locale come file PowerPoint (.pptx) file.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **Esempio 2**

Il seguente esempio dimostra le overload del metodo [GeneratePresentation](https://reference.aspose.com/slides/it/net/aspose.slides.ai/slidesaiagent/generatepresentation/). In questo caso, viene utilizzata un'istanza di [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) gestita esternamente e la `master presentation` dell'utente.

Per impostazione predefinita, il [OpenAIWebClient](https://reference.aspose.com/slides/it/net/aspose.slides.ai/openaiwebclient/) integrato crea e gestisce la propria istanza interna di [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), gestendone automaticamente il ciclo di vita e lo smaltimento. Tuttavia, se preferisci gestire tu stesso il [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) — ad esempio, quando utilizzi un [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) per una migliore gestione delle risorse e delle prestazioni — puoi fornire la tua istanza di [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) durante la costruzione del [OpenAIWebClient](https://reference.aspose.com/slides/it/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Crea un'istanza di HttpClient gestita esternamente.
using var httpClient = new HttpClient();

// Passa l'HttpClient al costruttore di OpenAIWebClient.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Crea un'istanza di SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Definisci l'istruzione per generare la presentazione.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Carica una presentazione master dal disco locale per usarla come modello di design.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Genera una presentazione dettagliata usando l'istruzione e il modello master.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Salva la presentazione generata come PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

Vale la pena notare che molti clienti utilizzano Aspose.Slides in contesti sincroni. Per supportare ciò, la classe [SlidesAIAgent](https://reference.aspose.com/slides/it/net/aspose.slides.ai/slidesaiagent/) fornisce sia metodi sincroni sia asincroni, consentendo di scegliere l'approccio più adatto al flusso di lavoro della tua applicazione.

## **Vantaggi principali**

Il nuovo AI Presentation Generator in Aspose.Slides offre un modo rapido e flessibile per produrre deck di diapositive strutturati a partire da semplici prompt di testo. Con il supporto per modelli personalizzati, istanze di [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) gestite esternamente e flussi di lavoro sia sincroni sia asincroni, può essere integrato senza problemi in una vasta gamma di applicazioni.

I casi d'uso tipici includono la creazione di presentazioni di marketing, materiali educativi, report per i clienti e deck diapositive interni. Sebbene la generazione di immagini non sia ancora supportata, lo strumento offre già una solida base per automatizzare la creazione di presentazioni, con ulteriori miglioramenti previsti in futuro.