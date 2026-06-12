---
title: Traduttore di Presentazioni con AI
linktitle: Traduttore con AI
type: docs
weight: 20
url: /it/php-java/ai/translator/
keywords:
- Traduttore di presentazioni AI
- Traduttore di diapositive AI
- Funzione alimentata da AI
- Presentazione multilingue
- Diapositiva multilingue
- Traduzione di presentazione
- Traduzione di diapositiva
- Funzioni guidate da AI
- Capacità AI
- Agente AI
- Client Web
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Traduci le diapositive PowerPoint con AI usando Aspose.Slides per PHP. Localizza PPT, PPTX e ODP preservando il layout—veloce e per sviluppatori. Provalo."
---
## **Introduzione**

Aspose.Slides è un'API potente per gestire programmaticamente le presentazioni PowerPoint. Oltre a creare, modificare e convertire le diapositive, offre funzionalità basate sull'IA, come l'API di Traduzione delle Presentazioni per contenuti delle diapositive multilingue.

## **Come funziona**

Aspose.Slides non include capacità di IA integrate, ma si integra con modelli di IA esterni tramite Internet. Questa funzionalità è esposta tramite la classe [SlidesAIAgent](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesaiagent/) per comunicare con i servizi di IA.

È possibile utilizzare il [OpenAIWebClient](https://reference.aspose.com/slides/it/php-java/aspose.slides/openaiwebclient/) integrato per connettersi all'API di OpenAI.

Aspose.Slides gestisce la comunicazione, analizza le risposte dell'IA e inserisce in modo intelligente i contenuti tradotti, preservando il layout e la formattazione originali delle diapositive.

{{% alert color="primary" %}}
Nota che l'API di OpenAI è un servizio a pagamento, quindi dovrai creare un account e fornire la tua chiave API quando utilizzi il [OpenAIWebClient](https://reference.aspose.com/slides/it/php-java/aspose.slides/openaiwebclient/) integrato.
{{% /alert %}}

## **Esempio**

In questo esempio, traduciamo una presentazione PowerPoint in giapponese utilizzando il [OpenAIWebClient](https://reference.aspose.com/slides/it/php-java/aspose.slides/openaiwebclient/) integrato con un [modello](https://platform.openai.com/docs/models) di OpenAI specificato.

```php
// Carica una presentazione da tradurre.
$presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inizializza SlidesAIAgent con il client AI.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Traduci la presentazione in giapponese.
    $aiAgent->translate($presentation, "japanese");

    // Salva la presentazione tradotta come PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

Per impostazione predefinita, il [OpenAIWebClient](https://reference.aspose.com/slides/it/php-java/aspose.slides/openaiwebclient/) integrato crea e gestisce la propria istanza interna di [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), gestendo automaticamente il suo ciclo di vita. Tuttavia, se preferisci gestire tu stesso la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — principalmente per configurare impostazioni essenziali come un proxy, o per utilizzare una [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o un diverso [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) per una migliore gestione delle risorse e prestazioni — puoi fornire la tua istanza `HttpURLConnection` quando costruisci il [OpenAIWebClient](https://reference.aspose.com/slides/it/php-java/aspose.slides/openaiwebclient/).

```php
// Supponi di avere un'istanza HttpURLConnection preconfigurata (ad esempio, con timeout personalizzati, impostazioni proxy, ecc.)
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

## **Benefici principali**

L'API di Traduzione delle Presentazioni di Aspose.Slides offre una soluzione basata sull'IA per fornire presentazioni PowerPoint multilingue. Automatizzando la traduzione e preservando layout e design, consente di risparmiare tempo e ridurre al minimo gli errori rispetto ai flussi di lavoro manuali. Che tu sia uno sviluppatore, un educatore o un professionista aziendale, questa API ti permette di creare presentazioni coinvolgenti e localizzate per un pubblico globale, ampliando la tua portata e migliorando la comunicazione.