---
title: Traduttore di presentazioni con AI
linktitle: Traduttore con AI
type: docs
weight: 20
url: /it/androidjava/ai/translator/
keywords:
- Traduttore di presentazioni AI
- Traduttore di diapositive AI
- Funzionalità AI
- Presentazione multilingue
- Diapositiva multilingue
- Traduzione della presentazione
- Traduzione della diapositiva
- Funzionalità guidate dall'AI
- Capacità AI
- Agente AI
- Client Web
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Traduci le diapositive PowerPoint con l'AI usando Aspose.Slides per Android tramite Java. Localizza PPT, PPTX e ODP preservando il layout—veloce e facile per gli sviluppatori. Provalo."
---
## **Introduzione**

Aspose.Slides è una potente API per la gestione programmata delle presentazioni PowerPoint. Oltre a creare, modificare e convertire le diapositive, offre funzionalità basate sull'IA, come l'API di Traduzione delle Presentazioni per contenuti multilingue delle diapositive.

## **Come funziona**

Aspose.Slides non include capacità AI integrate, ma si integra con modelli AI esterni tramite Internet. Questa funzionalità è esposta tramite la classe [SlidesAIAgent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidesaiagent/) che utilizza un'implementazione dell'interfaccia [IAIWebClient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iaiwebclient/) per comunicare con i servizi AI.  
Puoi utilizzare il [OpenAIWebClient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/openaiwebclient/) integrato per connetterti all'API di OpenAI o implementare il tuo proprio [IAIWebClient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iaiwebclient/) per usare un provider AI diverso o un modello linguistico differente.  
Aspose.Slides gestisce la comunicazione, analizza le risposte AI e inserisce in modo intelligente i contenuti tradotti preservando il layout e la formattazione originali della diapositiva.

{{% alert color="info" %}}
Nota che l'API di OpenAI è un servizio a pagamento, quindi dovrai creare un account e fornire la tua chiave API quando utilizzi il [OpenAIWebClient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/openaiwebclient/) integrato.
{{% /alert %}}

## **Esempio**

In questo esempio, traduciamo una presentazione PowerPoint in giapponese utilizzando il [OpenAIWebClient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/openaiwebclient/) integrato con un [modello](https://platform.openai.com/docs/models) OpenAI specificato.

```java
import com.aspose.slides.*;

// Carica una presentazione da tradurre.
Presentation presentation = new Presentation("sample.pptx");

// Crea un client AI con OpenAIWebClient, specificando il tuo modello e la chiave API.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inizializza SlidesAIAgent con il client AI.
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

Per impostazione predefinita, il [OpenAIWebClient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/openaiwebclient/) integrato crea e gestisce la propria istanza interna di [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), gestendone automaticamente il ciclo di vita. Tuttavia, se preferisci gestire tu stesso la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — principalmente per configurare impostazioni essenziali come un proxy, o per utilizzare un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o un [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) diverso per una migliore gestione delle risorse e prestazioni — puoi fornire la tua istanza di `HttpURLConnection` durante la costruzione del [OpenAIWebClient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Configura un'istanza HttpURLConnection tu stesso (ad esempio con timeout personalizzati, impostazioni proxy, ecc.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Passa la connessione al costruttore OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Vantaggi principali**

L'API di Traduzione delle Presentazioni di Aspose.Slides offre una soluzione basata sull'IA per fornire presentazioni PowerPoint multilingue. Automatizzando la traduzione e preservando layout e design, consente di risparmiare tempo e di ridurre gli errori rispetto ai flussi di lavoro manuali. Che tu sia uno sviluppatore, un educatore o un professionista aziendale, questa API ti consente di creare presentazioni coinvolgenti e localizzate per un pubblico globale, ampliando la tua portata e migliorando la comunicazione.