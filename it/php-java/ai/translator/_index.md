---
title: "Traduttore di Presentazioni Potenziato dall'IA"
linktitle: "Traduttore Potenziato dall'IA"
type: docs
weight: 20
url: /it/php-java/ai/translator/
keywords:
- traduttore di presentazioni AI
- traduttore di diapositive AI
- funzionalità potenziata da AI
- presentazione multilingue
- diapositiva multilingue
- traduzione della presentazione
- traduzione della diapositiva
- funzionalità guidate da AI
- capacità AI
- agente AI
- client Web
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Traduci le diapositive PowerPoint con l'IA usando Aspose.Slides per PHP. Localizza PPT, PPTX e ODP mantenendo il layout - veloce e adatto agli sviluppatori. Provalo."
---
## **Introduzione**

Aspose.Slides è un'API potente per gestire programmaticamente presentazioni PowerPoint. Oltre a creare, modificare e convertire le diapositive, offre funzionalità basate sull'IA, come l'API di Traduzione della Presentazione per contenuti multilingue.

## **Come funziona**

Aspose.Slides non include capacità IA integrate, ma si integra con modelli IA esterni tramite Internet. Questa funzionalità è esposta tramite la classe [SlidesAIAgent](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesaiagent/) per comunicare con i servizi IA.

È possibile utilizzare il client integrato [OpenAIWebClient](https://reference.aspose.com/slides/it/php-java/aspose.slides/openaiwebclient/) per connettersi all'API di OpenAI.

Aspose.Slides gestisce la comunicazione, analizza le risposte dell'IA e inserisce in modo intelligente i contenuti tradotti mantenendo il layout e la formattazione originali delle diapositive.

{{% alert color="info" title="Nota" %}}

Nota che l'API di OpenAI è un servizio a pagamento, quindi è necessario creare un account e fornire la propria chiave API quando si utilizza il client integrato [OpenAIWebClient](https://reference.aspose.com/slides/it/php-java/aspose.slides/openaiwebclient/).

{{% /alert %}}

## **Esempio**

In questo esempio, traduciamo una presentazione PowerPoint in giapponese utilizzando il client integrato [OpenAIWebClient](https://reference.aspose.com/slides/it/php-java/aspose.slides/openaiwebclient/) con un specificato modello OpenAI [model](https://platform.openai.com/docs/models).

```php
// Carica una presentazione da tradurre.
$presentation = new Presentation("sample.pptx");

// Crea un client IA con OpenAIWebClient, specificando il tuo modello e la chiave API.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inizializza SlidesAIAgent con il client IA.
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

Per impostazione predefinita, il client integrato [OpenAIWebClient](https://reference.aspose.com/slides/it/php-java/aspose.slides/openaiwebclient/) crea e gestisce la propria istanza interna di [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), gestendone automaticamente il ciclo di vita. Tuttavia, se si preferisce gestire manualmente l'[HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — principalmente per configurare impostazioni essenziali come un proxy, o per utilizzare un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o un diverso [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) per una migliore gestione delle risorse e prestazioni — è possibile fornire la propria istanza `HttpURLConnection` durante la costruzione del [OpenAIWebClient](https://reference.aspose.com/slides/it/php-java/aspose.slides/openaiwebclient/).

```php
// Crea e preconfigura la tua istanza HttpURLConnection (timeout personalizzati, impostazioni proxy, ecc.).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// Passa la connessione al client IA.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Esempio Azure OpenAI**

È possibile configurare il traduttore per utilizzare la distribuzione Azure OpenAI con il [OpenAICompatibleWebClient](https://reference.aspose.com/slides/it/php-java/aspose.slides/openaicompatiblewebclient/).

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

Questo frammento dimostra la traduzione di una presentazione utilizzando il proprio endpoint Azure OpenAI. Sostituire i valori segnaposto con il nome della distribuzione, la chiave API e l'URL dell'endpoint.

## **Vantaggi principali**

L'API di Traduzione della Presentazione di Aspose.Slides offre una soluzione potenziata dall'IA per fornire presentazioni PowerPoint multilingue. Automatizzando la traduzione e mantenendo layout e design, consente di risparmiare tempo e ridurre gli errori rispetto ai flussi di lavoro manuali. Sia che siate sviluppatori, educatori o professionisti aziendali, questa API vi permette di creare presentazioni localizzate e coinvolgenti per un pubblico globale, ampliando la vostra portata e migliorando la comunicazione.