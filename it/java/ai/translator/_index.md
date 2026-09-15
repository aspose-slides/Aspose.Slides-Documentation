---
title: Traduttore di Presentazioni Alimentato da IA
linktitle: Traduttore Alimentato da IA
type: docs
weight: 20
url: /it/java/ai/translator/
keywords:
- Traduttore di presentazioni IA
- Traduttore di diapositive IA
- Funzionalità alimentata da IA
- Presentazione multilingue
- Diapositiva multilingue
- Traduzione della presentazione
- Traduzione della diapositiva
- Funzionalità guidate dall'IA
- Capacità IA
- Agente IA
- Client Web
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Traduci le diapositive PowerPoint con IA usando Aspose.Slides per Java. Localizza PPT, PPTX e ODP mantenendo il layout—veloce e adatto agli sviluppatori. Provalo."
---
## **Introduzione**

Aspose.Slides è un'API potente per gestire programmaticamente le presentazioni PowerPoint. Oltre a creare, modificare e convertire le diapositive, offre funzionalità basate sull'IA, come l'API di Traduzione delle Presentazioni per contenuti multilingue delle diapositive.

## **Come funziona**

Aspose.Slides non include funzionalità IA incorporate, ma si integra con modelli IA esterni tramite Internet. Questa funzionalità è esposta tramite la classe [SlidesAIAgent](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidesaiagent/) che utilizza un'implementazione dell'interfaccia [IAIWebClient](https://reference.aspose.com/slides/it/java/com.aspose.slides/iaiwebclient/) per comunicare con i servizi IA.

È possibile utilizzare il [OpenAIWebClient](https://reference.aspose.com/slides/it/java/com.aspose.slides/openaiwebclient/) incorporato per connettersi all'API di OpenAI oppure implementare il proprio [IAIWebClient](https://reference.aspose.com/slides/it/java/com.aspose.slides/iaiwebclient/) per utilizzare un provider IA diverso o un modello linguistico differente.

Aspose.Slides gestisce la comunicazione, analizza le risposte dell'IA e inserisce in modo intelligente il contenuto tradotto preservando il layout e la formattazione originali delle diapositive.

{{% alert color="info" title="Nota" %}}
Nota che l'API di OpenAI è un servizio a pagamento, quindi dovrai creare un account e fornire la tua chiave API quando utilizzi il [OpenAIWebClient](https://reference.aspose.com/slides/it/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Esempio**

In questo esempio, traduciamo una presentazione PowerPoint in giapponese utilizzando il [OpenAIWebClient](https://reference.aspose.com/slides/it/java/com.aspose.slides/openaiwebclient/) incorporato con un [model](https://platform.openai.com/docs/models) OpenAI specificato.

```java
import com.aspose.slides.*;

// Carica una presentazione da tradurre.
Presentation presentation = new Presentation("sample.pptx");

// Crea un client AI con OpenAIWebClient, specificando il modello e la chiave API.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inizializza SlidesAIAgent con il client AI.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Traduce la presentazione in giapponese.
    aiAgent.translate(presentation, "japanese");

    // Salva la presentazione tradotta come PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Per impostazione predefinita, il [OpenAIWebClient](https://reference.aspose.com/slides/it/java/com.aspose.slides/openaiwebclient/) crea e gestisce la propria istanza interna di [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), gestendone il ciclo di vita automaticamente. Tuttavia, se preferisci gestire tu stesso la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — ad esempio per configurare impostazioni essenziali come un proxy, o per utilizzare un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o un diverso [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) per una migliore gestione delle risorse e prestazioni — puoi fornire la tua istanza `HttpURLConnection` quando costruisci il [OpenAIWebClient](https://reference.aspose.com/slides/it/java/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Configura un'istanza HttpURLConnection da solo (timeout personalizzati, impostazioni proxy, ecc.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Esempio Azure OpenAI**

Puoi configurare il traduttore per utilizzare il tuo deployment Azure OpenAI con il [OpenAICompatibleWebClient](https://reference.aspose.com/slides/it/java/com.aspose.slides/openaicompatiblewebclient/).

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

Questo frammento dimostra come tradurre una presentazione utilizzando il tuo endpoint Azure OpenAI. Sostituisci i valori segnaposto con il nome del deployment, la chiave API e l'URL dell'endpoint.

## **Vantaggi principali**

L'API di Traduzione delle Presentazioni di Aspose.Slides offre una soluzione potenziata dall'IA per fornire presentazioni PowerPoint multilingue. Automatizzando la traduzione e preservando layout e design, consente di risparmiare tempo e ridurre gli errori rispetto ai flussi di lavoro manuali. Che tu sia uno sviluppatore, un educatore o un professionista aziendale, questa API ti permette di creare presentazioni coinvolgenti e localizzate per un pubblico globale, ampliando la tua portata e migliorando la comunicazione.