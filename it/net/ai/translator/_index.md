---
title: Traduttore di Presentazioni potenziato dall'IA
linktitle: Traduttore potenziato dall'IA
type: docs
weight: 20
url: /it/net/ai/translator/
keywords:
- traduttore di presentazioni IA
- traduttore di diapositive IA
- funzionalità potenziata dall'IA
- presentazione multilingue
- diapositiva multilingue
- traduzione di presentazioni
- traduzione di diapositive
- funzionalità guidate dall'IA
- capacità IA
- agente IA
- client web
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Traduci le diapositive PowerPoint con l'IA usando Aspose.Slides per .NET. Localizza PPT, PPTX e ODP mantenendo il layout—veloce e per sviluppatori. Provalo."
---
## **Introduzione**

Aspose.Slides è una potente API per gestire programmaticamente le presentazioni PowerPoint. Oltre a creare, modificare e convertire le diapositive, offre funzionalità basate sull'IA, come l'[API di traduzione delle presentazioni](https://reference.aspose.com/slides/it/net/aspose.slides.ai/) per contenuti multilingue.

## **Come funziona**

Aspose.Slides non include capacità di IA integrate, ma si integra con modelli di IA esterni tramite Internet. Questa funzionalità è esposta tramite la classe [SlidesAIAgent](https://reference.aspose.com/slides/it/net/aspose.slides.ai/slidesaiagent), che utilizza un'implementazione dell'interfaccia [IAIWebClient](https://reference.aspose.com/slides/it/net/aspose.slides.ai/iaiwebclient/) per comunicare con i servizi di IA.

Puoi usare il [OpenAIWebClient](https://reference.aspose.com/slides/it/net/aspose.slides.ai/openaiwebclient/) incorporato per connetterti all'API di OpenAI oppure implementare il tuo [IAIWebClient](https://reference.aspose.com/slides/it/net/aspose.slides.ai/iaiwebclient/) per utilizzare un provider di IA diverso o un modello linguistico diverso.

Aspose.Slides gestisce la comunicazione, analizza le risposte dell'IA e inserisce in modo intelligente i contenuti tradotti preservando il layout e la formattazione originali delle diapositive.

{{% alert color="info" title="Note" %}}
Nota che l'API OpenAI è un servizio a pagamento, quindi dovrai creare un account e fornire la tua chiave API quando utilizzi il [OpenAIWebClient](https://reference.aspose.com/slides/it/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Esempio**

In questo esempio traduciamo una presentazione PowerPoint in giapponese usando il [OpenAIWebClient](https://reference.aspose.com/slides/it/net/aspose.slides.ai/openaiwebclient/) incorporato con un modello OpenAI specificato.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Carica una presentazione da tradurre.
using var presentation = new Presentation("sample.pptx");

// Crea un client AI con OpenAIWebClient, specificando il tuo modello e la chiave API.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Inizializza SlidesAIAgent con il client AI.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Traduci la presentazione in giapponese.
await aiAgent.TranslateAsync(presentation, "japanese");

// Salva la presentazione tradotta come PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Per impostazione predefinita, il [OpenAIWebClient](https://reference.aspose.com/slides/it/net/aspose.slides.ai/openaiwebclient/) crea e gestisce la propria istanza interna di [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), gestendone il ciclo di vita e la disposizione automaticamente. Tuttavia, se preferisci gestire tu stesso l'[HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) — ad esempio quando utilizzi un [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) per una migliore gestione delle risorse e prestazioni — puoi fornire la tua istanza `HttpClient` quando costruisci il [OpenAIWebClient](https://reference.aspose.com/slides/it/net/aspose.slides.ai/openaiwebclient/).

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Usa un HttpClient che gestisci tu stesso - ad esempio, uno creato da un IHttpClientFactory
// iniettato tramite l'iniezione delle dipendenze.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides è comunemente usato in ambienti sincroni. Per supportare questo, la classe [SlidesAIAgent](https://reference.aspose.com/slides/it/net/aspose.slides.ai/slidesaiagent/) offre sia metodi sincroni che asincroni, consentendoti di scegliere l'approccio più adatto al flusso di lavoro della tua applicazione.

### **Esempio Azure OpenAI**

Aspose.Slides per .NET supporta provider compatibili con OpenAI, inclusi Azure OpenAI. Puoi configurare il traduttore per utilizzare la tua distribuzione Azure interna con il [OpenAICompatibleWebClient](https://reference.aspose.com/slides/it/net/aspose.slides.ai/openaicompatiblewebclient/).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

Questo snippet dimostra come tradurre una presentazione utilizzando il tuo endpoint Azure OpenAI. Sostituisci i valori segnaposto con il nome della tua distribuzione, la chiave API e l'URL del endpoint.

## **Vantaggi principali**

L'[API di traduzione delle presentazioni](https://reference.aspose.com/slides/it/net/aspose.slides.ai/) di Aspose.Slides offre una soluzione potenziata dall'IA per fornire presentazioni PowerPoint multilingue. Automatizzando la traduzione e preservando layout e design, consente di risparmiare tempo e ridurre gli errori rispetto ai flussi di lavoro manuali. Che tu sia uno sviluppatore, un educatore o un professionista aziendale, questa API ti permette di creare presentazioni coinvolgenti e localizzate per pubblici globali, ampliando la tua portata e migliorando la comunicazione.