---
title: Traduttore di Presentazioni Alimentato da AI
linktitle: Traduttore Alimentato da AI
type: docs
weight: 20
url: /it/nodejs-java/ai/translator/
keywords:
- Traduttore di presentazioni AI
- Traduttore di diapositive AI
- Funzionalità alimentata da AI
- Presentazione multilingue
- Diapositiva multilingue
- Traduzione di presentazioni
- Traduzione di diapositive
- Funzionalità guidate dall'AI
- Capacità AI
- Agente AI
- Client web
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Traduci le diapositive PowerPoint con l'AI usando Aspose.Slides per Node.js. Localizza PPT, PPTX e ODP preservando il layout—veloce e adatto agli sviluppatori. Provalo."
---
## **Introduzione**

Aspose.Slides è un'API potente per gestire programmaticamente le presentazioni PowerPoint. Oltre a creare, modificare e convertire le diapositive, offre funzionalità guidate dall'AI - come l'API di traduzione delle presentazioni per contenuti multilingue delle diapositive.

## **Come funziona**

Aspose.Slides non include capacità AI incorporate, ma si integra con modelli AI esterni tramite Internet. Questa funzionalità è esposta tramite la classe [SlidesAIAgent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesaiagent/) per comunicare con i servizi AI.

È possibile utilizzare il [OpenAIWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaiwebclient/) integrato per connettersi all'API di OpenAI.

Aspose.Slides gestisce la comunicazione, analizza le risposte AI e inserisce in modo intelligente i contenuti tradotti preservando il layout e la formattazione originali delle diapositive.

{{% alert color="primary" %}}
Nota che l'API di OpenAI è un servizio a pagamento, quindi dovrai creare un account e fornire la tua chiave API quando utilizzi il [OpenAIWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaiwebclient/) integrato.
{{% /alert %}}

## **Esempio**

In questo esempio, traduciamo una presentazione PowerPoint in giapponese utilizzando il [OpenAIWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaiwebclient/) integrato con un [modello](https://platform.openai.com/docs/models) OpenAI specificato.

```js
// Carica una presentazione da tradurre.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Crea un client AI con OpenAIWebClient, specificando il modello e la chiave API.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inizializza SlidesAIAgent con il client AI.
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

Per impostazione predefinita, il [OpenAIWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaiwebclient/) integrato crea e gestisce la propria istanza interna di [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), gestendone il ciclo di vita automaticamente. Tuttavia, se preferisci gestire tu stesso l'[HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — principalmente per configurare impostazioni essenziali come un proxy, o per utilizzare un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o un diverso [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) per una migliore gestione delle risorse e delle prestazioni — puoi fornire la tua istanza `HttpURLConnection` quando costruisci l'[OpenAIWebClient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Assumi di avere un'istanza HttpURLConnection preconfigurata (ad es., con timeout personalizzati, impostazioni proxy, ecc.)
let urlConnection = yourPreconfiguredConnection;
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Benefici principali**

L'API di traduzione delle presentazioni di Aspose.Slides offre una soluzione basata sull'AI per fornire presentazioni PowerPoint multilingue. Automatizzando la traduzione e preservando layout e design, consente di risparmiare tempo e ridurre gli errori rispetto ai flussi di lavoro manuali. Che tu sia uno sviluppatore, un educatore o un professionista aziendale, questa API ti permette di creare presentazioni coinvolgenti e localizzate per un pubblico globale, espandendo la tua portata e migliorando la comunicazione.