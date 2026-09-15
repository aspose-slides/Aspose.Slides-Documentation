---
title: Traduttore di Presentazioni Basato su IA
linktitle: Traduttore Basato su IA
type: docs
weight: 20
url: /it/nodejs-java/ai/translator/
keywords:
- Traduttore di presentazioni IA
- Traduttore di diapositive IA
- Funzionalità basata su IA
- Presentazione multilingue
- Diapositiva multilingue
- Traduzione di presentazioni
- Traduzione di diapositive
- Funzionalità guidate dall'IA
- Capacità IA
- Agente IA
- Client Web
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Traduci le diapositive PowerPoint con IA usando Aspose.Slides per Node.js. Localizza PPT, PPTX e ODP preservando il layout—veloce e facile per gli sviluppatori. Provalo."
---
## **Introduzione**

Aspose.Slides è un potente API per gestire programmaticamente presentazioni PowerPoint. Oltre a creare, modificare e convertire diapositive, offre funzionalità basate su IA, come l’API di Traduzione delle Presentazioni per contenuti multilingue.

## **Come funziona**

Aspose.Slides non include capacità IA integrate, ma si integra con modelli IA esterni tramite internet. Questa funzionalità è esposta tramite la classe [SlidesAIAgent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesaiagent/) per comunicare con i servizi di IA.

È possibile usare il built‑in [OpenAIWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaiwebclient/) per connettersi all’API di OpenAI.

Aspose.Slides gestisce la comunicazione, analizza le risposte dell’IA e inserisce in modo intelligente i contenuti tradotti preservando il layout e la formattazione originali delle diapositive.

{{% alert color="info" title="Nota" %}}
Nota che l’API di OpenAI è un servizio a pagamento, quindi dovrai creare un account e fornire la tua chiave API quando utilizzi il built‑in [OpenAIWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Esempio**

In questo esempio, traduciamo una presentazione PowerPoint in giapponese utilizzando il built‑in [OpenAIWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaiwebclient/) con un [modello](https://platform.openai.com/docs/models) OpenAI specificato.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Carica una presentazione da tradurre.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inizializza SlidesAIAgent con il client IA.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Traduci la presentazione in giapponese.
    aiAgent.translate(presentation, "japanese");

    // Salva la presentazione tradotta come PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Per impostazione predefinita, il built‑in [OpenAIWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaiwebclient/) crea e gestisce la propria istanza interna di [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), gestendo automaticamente il suo ciclo di vita. Tuttavia, se preferisci gestire tu stesso la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — ad esempio per configurare impostazioni essenziali come un proxy, o per utilizzare una [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o un diverso [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) per una migliore gestione delle risorse e delle prestazioni — puoi fornire la tua istanza `HttpURLConnection` quando costruisci il [OpenAIWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaiwebclient/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Crea e pre-configura un'istanza HttpURLConnection (ad es., con timeout personalizzati, impostazioni proxy, ecc.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Esempio Azure OpenAI**

Puoi configurare il traduttore per usare la tua distribuzione Azure OpenAI con l’[OpenAICompatibleWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaicompatiblewebclient/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Questo frammento dimostra come tradurre una presentazione utilizzando il tuo endpoint Azure OpenAI. Sostituisci i valori segnaposto con il nome della tua distribuzione, la chiave API e l’URL dell’endpoint.

## **Vantaggi principali**

L’API di Traduzione delle Presentazioni di Aspose.Slides offre una soluzione potenziata dall’IA per fornire presentazioni PowerPoint multilingue. Automatizzando la traduzione e preservando layout e design, consente di risparmiare tempo e di ridurre gli errori rispetto ai flussi di lavoro manuali. Che tu sia uno sviluppatore, un educatore o un professionista aziendale, questa API ti permette di creare presentazioni coinvolgenti e localizzate per audience globali, ampliando la tua portata e migliorando la comunicazione.