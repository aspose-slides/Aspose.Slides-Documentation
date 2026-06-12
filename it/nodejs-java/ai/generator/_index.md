---
title: Generatore di Diapositive Multilingue Alimentato da IA
linktitle: Generatore Alimentato da IA
type: docs
weight: 40
url: /it/nodejs-java/ai/generator/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Genera diapositive multilingue dal testo con Aspose.Slides per Node.js. Applica il tuo modello ed esporta deck raffinati in PowerPoint e OpenDocument. Scopri di più."
---
## **Introduzione**

Aspose.Slides introduce una nuova funzionalità basata sull'IA, il Generatore di Presentazioni, che consente agli sviluppatori di creare automaticamente presentazioni PowerPoint ben strutturate a partire da semplici input di testo come descrizioni di argomenti, riepiloghi, citazioni o elenchi puntati.

Gli utenti possono regolare il livello di dettaglio del contenuto e, facoltativamente, applicare un modello di presentazione personalizzato per definire il design visivo.

Attualmente, il Generatore di Presentazioni IA struttura il contenuto utilizzando blocchi di testo, elenchi puntati e tabelle. La generazione di immagini non è ancora supportata; tuttavia, le immagini possono essere aggiunte facilmente in seguito utilizzando gli strumenti di Aspose.Slides o manualmente.

Il risultato è una presentazione PowerPoint completa che può essere usata così com'è o esportata in qualsiasi formato supportato dall'API di Aspose.Slides. Sebbene il generatore produca risultati di alta qualità, potrebbe essere necessario un leggero post-editing per soddisfare requisiti specifici.

## **Come funziona**

Aspose.Slides non include modelli IA integrati; invece, si integra con servizi IA esterni tramite Internet. Questa integrazione è gestita dalla classe [SlidesAIAgent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesaiagent/).

È possibile utilizzare il [OpenAIWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaiwebclient/) integrato, che si connette all'API di OpenAI. Aspose.Slides gestisce tutta la comunicazione con il servizio IA ed elabora le risposte dell'IA per generare le diapositive. Si noti che l'API OpenAI è un servizio a pagamento, quindi è necessario un account e una chiave API quando si utilizza il [OpenAIWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaiwebclient/).

## **Scriviamo il codice**

### **Esempio 1**

Questo esempio dimostra come generare una presentazione sull'argomento Aspose.Slides utilizzando il [OpenAIWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaiwebclient/) integrato.

```js
// Crea un'istanza di OpenAIWebClient, l'implementazione integrata del client web OpenAI.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Crea un'istanza di SlidesAIAgent, che fornisce l'accesso alle funzionalità alimentate da IA.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Definisci l'istruzione per generare la presentazione.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Genera una presentazione con una quantità di contenuto media basata sull'istruzione.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // Salva la presentazione generata sul disco locale come file PowerPoint (.pptx).
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Esempio 2**

L'esempio seguente dimostra le sovraccarichi del metodo [generatePresentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation). In questo caso, viene utilizzata un'istanza di [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) gestita esternamente e la `master presentation` dell'utente.

Per impostazione predefinita, il [OpenAIWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaiwebclient/) integrato crea e gestisce la propria istanza interna di [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), gestendone automaticamente il ciclo di vita. Tuttavia, se si preferisce gestire manualmente la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) - ad esempio, quando si utilizza un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) per migliorare la gestione delle risorse e le prestazioni - è possibile fornire la propria istanza di [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) durante la costruzione del [OpenAIWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Passa l'HttpURLConnection al costruttore di OpenAIWebClient.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Crea un'istanza di SlidesAIAgent.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Definisci l'istruzione per generare la presentazione.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Carica una presentazione master dal disco locale per usarla come modello di design.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // Genera una presentazione dettagliata usando l'istruzione e il modello master.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Salva la presentazione generata come PDF.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Vantaggi principali**

Il nuovo Generatore di Presentazioni IA in Aspose.Slides offre un modo rapido e flessibile per produrre deck di diapositive strutturati a partire da semplici prompt testuali. Con il supporto per modelli personalizzati e istanze di [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) gestite esternamente, può essere integrato senza problemi in una vasta gamma di applicazioni.

I casi d'uso tipici includono la creazione di presentazioni di marketing, materiali educativi, report per i clienti e deck interni. Sebbene la generazione di immagini non sia ancora supportata, lo strumento offre già una solida base per automatizzare la creazione di presentazioni, con ulteriori miglioramenti previsti in futuro.