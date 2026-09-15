---
title: Traduttore di presentazioni con IA
linktitle: Traduttore con IA
type: docs
weight: 20
url: /it/androidjava/ai/translator/
keywords:
- Traduttore di presentazioni AI
- Traduttore di diapositive AI
- Funzione con IA
- Presentazione multilingue
- Diapositiva multilingue
- Traduzione della presentazione
- Traduzione della diapositiva
- Funzioni guidate dall'IA
- Capacità IA
- Agente IA
- Client web
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Traduci le diapositive PowerPoint con IA usando Aspose.Slides per Android via Java. Localizza PPT, PPTX e ODP preservando il layout — veloce e per sviluppatori. Provalo."
---
## **Introduzione**

Aspose.Slides è un'API potente per gestire programmaticamente le presentazioni PowerPoint. Oltre a creare, modificare e convertire le diapositive, offre funzionalità basate sull'IA, come l'API di Traduzione della Presentazione per contenuti multilingue.

## **Come funziona**

Aspose.Slides non include capacità di IA integrate, ma si integra con modelli di IA esterni tramite Internet. Questa funzionalità è esposta tramite la classe [SlidesAIAgent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidesaiagent/) che utilizza un'implementazione dell'interfaccia [IAIWebClient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iaiwebclient/) per comunicare con i servizi di IA.

Puoi utilizzare il client integrato [OpenAIWebClient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/openaiwebclient/) per connetterti all'API di OpenAI o implementare il tuo proprio [IAIWebClient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iaiwebclient/) per usare un provider di IA diverso o un modello linguistico alternativo.

Aspose.Slides gestisce la comunicazione, analizza le risposte dell'IA e inserisce in modo intelligente i contenuti tradotti mantenendo intatti il layout e la formattazione originali delle diapositive.

{{% alert color="info" title="Note" %}}

Nota che l'API di OpenAI è un servizio a pagamento, quindi dovrai creare un account e fornire la tua chiave API quando utilizzi il client integrato [OpenAIWebClient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/openaiwebclient/).

{{% /alert %}}

## **Esempio**

In questo esempio, traduciamo una presentazione PowerPoint in giapponese utilizzando il client integrato [OpenAIWebClient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/openaiwebclient/) con un [modello](https://platform.openai.com/docs/models) OpenAI specificato.

```java
import com.aspose.slides.*;

// Carica una presentazione da tradurre.
Presentation presentation = new Presentation("sample.pptx");

// Crea un client IA con OpenAIWebClient, specificando il tuo modello e la chiave API.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inizializza SlidesAIAgent con il client IA.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Traduci la presentazione in giapponese.
    aiAgent.translate(presentation, "japanese");

    // Salva la presentazione tradotta come PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Per impostazione predefinita, il client integrato [OpenAIWebClient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/openaiwebclient/) crea e gestisce la propria istanza interna di [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), gestendone il ciclo di vita automaticamente. Tuttavia, se preferisci gestire tu stesso la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — ad esempio per configurare impostazioni essenziali come un proxy, o per utilizzare una [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o un diverso [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) per una migliore gestione delle risorse e prestazioni — puoi fornire la tua istanza `HttpURLConnection` durante la costruzione del client [OpenAIWebClient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Configura un'istanza HttpURLConnection da solo (ad esempio, con timeout personalizzati, impostazioni del proxy, ecc.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Passa la connessione al costruttore OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **Esempio Azure OpenAI**

Puoi configurare il traduttore per utilizzare la tua distribuzione Azure OpenAI con il client [OpenAICompatibleWebClient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/openaicompatiblewebclient/).

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Questo frammento dimostra come tradurre una presentazione usando il tuo endpoint Azure OpenAI. Sostituisci i valori segnaposto con il nome della distribuzione, la chiave API e l'URL dell'endpoint.

## **Principali vantaggi**

L'API di Traduzione della Presentazione di Aspose.Slides offre una soluzione potenziata dall'IA per fornire presentazioni PowerPoint multilingue. Automatizzando la traduzione e mantenendo layout e design, consente di risparmiare tempo e di ridurre gli errori rispetto ai flussi di lavoro manuali. Che tu sia uno sviluppatore, un educatore o un professionista aziendale, questa API ti permette di creare presentazioni coinvolgenti e localizzate per pubblico globale, ampliando la tua portata e migliorando la comunicazione.