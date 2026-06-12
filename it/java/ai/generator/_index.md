---
title: Generatore di Slide Multilingue con AI
linktitle: Generatore con AI
type: docs
weight: 40
url: /it/java/ai/generator/
keywords:
- presentazione multilingue
- slide multilingue
- generatore di presentazioni AI
- generatore di slide AI
- funzionalità con AI
- agente AI
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Genera slide multilingue da testo con Aspose.Slides per Java. Applica il tuo modello ed esporta deck raffinati in PowerPoint e OpenDocument. Scopri di più."
---
## **Introduzione**

Aspose.Slides introduce una nuova funzionalità basata sull'IA, il Presentation Generator, che consente agli sviluppatori di creare automaticamente presentazioni PowerPoint ben strutturate a partire da semplici input di testo come descrizioni di argomenti, riassunti, citazioni o elenchi puntati.

Gli utenti possono regolare il livello di dettaglio del contenuto e, facoltativamente, applicare un modello di presentazione personalizzato per definire il design visivo.

Attualmente, il AI Presentation Generator struttura il contenuto utilizzando blocchi di testo, elenchi puntati e tabelle. La generazione di immagini non è ancora supportata; tuttavia, le immagini possono essere aggiunte facilmente in seguito utilizzando gli strumenti di Aspose.Slides o manualmente.

Il risultato è una presentazione PowerPoint completa che può essere utilizzata così com'è o esportata in qualsiasi formato supportato dall'API di Aspose.Slides. Sebbene il generatore produca risultati di alta qualità, potrebbe essere necessario un leggero post-editing per soddisfare requisiti specifici.

## **Come funziona**

Aspose.Slides non include modelli AI integrati; invece, si integra con servizi AI esterni tramite Internet. Questa integrazione è gestita dalla classe [SlidesAIAgent](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidesaiagent/) che utilizza un'implementazione dell'interfaccia [IAIWebClient](https://reference.aspose.com/slides/it/java/com.aspose.slides/iaiwebclient/) per comunicare con il modello AI.

È possibile utilizzare il [OpenAIWebClient](https://reference.aspose.com/slides/it/java/com.aspose.slides/openaiwebclient/) integrato, che si connette all'API di OpenAI, oppure fornire un'implementazione personalizzata di [IAIWebClient](https://reference.aspose.com/slides/it/java/com.aspose.slides/iaiwebclient/) per lavorare con un altro provider AI o modello linguistico. Aspose.Slides gestisce tutta la comunicazione con il servizio AI ed elabora le risposte dell'IA per generare le slide. Si noti che l'API di OpenAI è un servizio a pagamento, quindi è necessario un account e una chiave API quando si utilizza il [OpenAIWebClient](https://reference.aspose.com/slides/it/java/com.aspose.slides/openaiwebclient/) integrato.

## **Scriviamo il codice**

### **Esempio 1**

Questo esempio dimostra come generare una presentazione sull'argomento Aspose.Slides utilizzando il [OpenAIWebClient](https://reference.aspose.com/slides/it/java/com.aspose.slides/openaiwebclient/) integrato.

```java
// Crea un'istanza di OpenAIWebClient, l'implementazione integrata del client web OpenAI.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Crea un'istanza di SlidesAIAgent, che fornisce accesso alle funzionalità potenziate dall'AI.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Definisci l'istruzione per generare la presentazione.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Genera una presentazione con una quantità media di contenuto basata sull'istruzione.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
        // Salva la presentazione generata sul disco locale come file PowerPoint (.pptx).
        presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Esempio 2**

Il seguente esempio dimostra le sovraccarichi del metodo [generatePresentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-). In questo caso, viene utilizzata un'istanza di [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) gestita esternamente e la `master presentation` dell'utente.

In modo predefinito, il [OpenAIWebClient](https://reference.aspose.com/slides/it/java/com.aspose.slides/openaiwebclient/) integrato crea e gestisce la propria istanza interna di [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), gestendone automaticamente il ciclo di vita. Tuttavia, se preferisci gestire tu stesso la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — ad esempio, quando utilizzi un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o un [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) per migliorare la gestione delle risorse e le prestazioni — puoi fornire la tua istanza di [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) durante la costruzione del [OpenAIWebClient](https://reference.aspose.com/slides/it/java/com.aspose.slides/openaiwebclient/).

```java
// Passa l'HttpURLConnection al costruttore OpenAIWebClient.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Crea un'istanza di SlidesAIAgent.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Definisci l'istruzione per generare la presentazione.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Carica una presentazione master dal disco locale da utilizzare come modello di design.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // Genera una presentazione dettagliata usando l'istruzione e il modello master.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Salva la presentazione generata come PDF.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Vantaggi principali**

Il nuovo AI Presentation Generator di Aspose.Slides offre un modo rapido e flessibile per produrre deck di slide strutturati a partire da semplici suggerimenti di testo. Con il supporto per modelli personalizzati e istanze di [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) gestite esternamente, può essere integrato senza problemi in una vasta gamma di applicazioni.

I casi d'uso tipici includono la creazione di presentazioni di marketing, materiali educativi, report per clienti e deck di slide interni. Sebbene la generazione di immagini non sia ancora supportata, lo strumento offre già una solida base per automatizzare la creazione di presentazioni, con ulteriori miglioramenti previsti in futuro.