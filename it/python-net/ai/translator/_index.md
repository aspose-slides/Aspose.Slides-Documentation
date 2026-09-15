---
title: Traduttore di presentazioni con AI
linktitle: Traduttore con AI
type: docs
weight: 20
url: /it/python-net/ai/translator/
keywords:
- Traduttore di presentazioni AI
- Traduttore di diapositive AI
- Funzionalità potenziata da AI
- Presentazione multilingue
- Diapositiva multilingue
- Traduzione di presentazioni
- Traduzione di diapositive
- Funzionalità guidate da AI
- Capacità AI
- Agente AI
- Client web
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Traduci le diapositive PowerPoint con AI usando Aspose.Slides per Python. Localizza PPT, PPTX e ODP mantenendo il layout—veloce e facile per gli sviluppatori. Provalo."
---
## **Introduzione**

Aspose.Slides è un'API potente per gestire programmaticamente presentazioni PowerPoint. Oltre a creare, modificare e convertire le diapositive, offre funzionalità basate su AI, come l'[Presentation Translation API](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/) per contenuti multilingue delle diapositive.

## **Come funziona**

Aspose.Slides non include capacità AI integrate ma si integra con modelli AI esterni tramite Internet. Questa funzionalità è esposta tramite la classe [SlidesAIAgent](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/slidesaiagent/) che utilizza le sottoclassi [IAIWebClient](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/iaiwebclient/) per comunicare con i servizi AI.

Puoi utilizzare l'[OpenAIWebClient](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/openaiwebclient/) integrato per connetterti all'API di OpenAI oppure implementare il tuo [IAIWebClient](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/iaiwebclient/) per usare un provider AI diverso o un modello linguistico differente.

Aspose.Slides gestisce la comunicazione, analizza le risposte AI e inserisce in modo intelligente i contenuti tradotti preservando il layout e la formattazione originali delle diapositive.

{{% alert color="info" %}}

Nota che l'API di OpenAI è un servizio a pagamento, quindi dovrai creare un account e fornire la tua chiave API quando utilizzi l'[OpenAIWebClient](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/openaiwebclient/).

{{% /alert %}}

## **Esempio**

In questo esempio traduciamo una presentazione PowerPoint in giapponese utilizzando l'[OpenAIWebClient](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/openaiwebclient/) integrato con un [modello](https://platform.openai.com/docs/models) OpenAI specificato.

```py
import aspose.slides as slides

# Carica una presentazione da tradurre.
with slides.Presentation("sample.pptx") as presentation:

    # Crea un client AI con OpenAIWebClient, specificando il tuo modello e la chiave API.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # Inizializza SlidesAIAgent con il client AI.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Traduci la presentazione in giapponese.
        ai_agent.translate(presentation, "japanese")

        # Salva la presentazione tradotta come PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Esempio Azure OpenAI**

Dalla versione **26.7.0**, Aspose.Slides per Python via .NET supporta provider compatibili con OpenAI, incluso Azure OpenAI. Puoi configurare il traduttore per usare la tua distribuzione Azure interna con l'[OpenAICompatibleWebClient](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/openaicompatiblewebclient/).

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

Questo frammento dimostra come tradurre una presentazione usando il tuo endpoint Azure OpenAI. Sostituisci i valori segnaposto con il nome della distribuzione, la chiave API e l'URL dell'endpoint.

## **Vantaggi principali**

L'[Presentation Translation API](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/) di Aspose.Slides offre una soluzione basata su AI per fornire presentazioni PowerPoint multilingue. Automatizzando la traduzione e preservando layout e design, consente di risparmiare tempo e ridurre errori rispetto ai flussi di lavoro manuali. Che tu sia sviluppatore, educatore o professionista aziendale, questa API ti permette di creare presentazioni coinvolgenti e localizzate per un pubblico globale, ampliando la tua portata e migliorando la comunicazione.