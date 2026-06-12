---
title: Generatore di diapositive multilingue con IA
linktitle: Generatore con IA
type: docs
weight: 40
url: /it/python-net/ai/generator/
keywords:
- presentazione multilingue
- diapositiva multilingue
- generatore di presentazioni IA
- generatore di diapositive IA
- funzionalità basata su IA
- agente IA
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Genera diapositive multilingue da testo con Aspose.Slides per Python. Applica il tuo modello ed esporta deck rifiniti in PowerPoint e OpenDocument. Scopri di più."
---
## **Introduzione**

Aspose.Slides introduce una nuova funzionalità basata sull'IA, il Presentation Generator, che consente agli sviluppatori di creare automaticamente presentazioni PowerPoint ben strutturate a partire da semplici input testuali come descrizioni di argomenti, riepiloghi, citazioni o elenchi puntati.

Gli utenti possono regolare il livello di dettaglio del contenuto e, facoltativamente, applicare un modello di presentazione personalizzato per definire il design visivo.

Attualmente, l'AI Presentation Generator struttura il contenuto utilizzando blocchi di testo, elenchi puntati e tabelle. La generazione di immagini non è ancora supportata; tuttavia, le immagini possono essere aggiunte facilmente in un secondo momento utilizzando gli strumenti di Aspose.Slides o manualmente.

L'output è una presentazione PowerPoint completa che può essere utilizzata così com'è o esportata in qualsiasi formato supportato dall'API di Aspose.Slides. Sebbene il generatore produca risultati di alta qualità, potrebbe essere necessario un leggero post-editing per soddisfare requisiti specifici.

## **Come funziona**

Aspose.Slides non include modelli IA integrati; invece, si integra con servizi IA esterni tramite Internet. Questa integrazione è gestita dalla classe [SlidesAIAgent](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/slidesaiagent/) che utilizza un'implementazione della classe [IAIWebClient](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/iaiwebclient/) per comunicare con il modello IA.

È possibile utilizzare il [OpenAIWebClient](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/openaiwebclient/) integrato, che si connette all'API di OpenAI, oppure fornire un'implementazione personalizzata di [IAIWebClient](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/iaiwebclient/) per lavorare con un altro provider IA o modello linguistico. Aspose.Slides gestisce tutta la comunicazione con il servizio IA e elabora le risposte dell'IA per generare le diapositive. Si noti che l'API di OpenAI è un servizio a pagamento, quindi è necessario un account e una chiave API quando si utilizza il [OpenAIWebClient](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/openaiwebclient/) integrato.

## **Scriviamo il codice**

### **Esempio 1**

Questo esempio dimostra come generare una presentazione sull'argomento Aspose.Slides utilizzando il [OpenAIWebClient](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/openaiwebclient/) integrato.

```py
# Crea un'istanza di OpenAIWebClient, l'implementazione integrata del client web OpenAI.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # Crea un'istanza di SlidesAIAgent, che fornisce l'accesso alle funzionalità basate su IA.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Definisci l'istruzione per generare la presentazione.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Genera una presentazione con una quantità media di contenuto basata sull'istruzione.
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # Salva la presentazione generata sul disco locale come file PowerPoint (.pptx) file.
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **Esempio 2**

Il seguente esempio dimostra le sovraccariche del metodo [generate_presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation). In questo caso, viene utilizzata la `master presentation` dell'utente.

```py
# Passa l'HttpClient al costruttore di OpenAIWebClient.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # Crea un'istanza di SlidesAIAgent.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Definisci l'istruzione per generare la presentazione.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Carica una presentazione master dal disco locale da utilizzare come modello di design.
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # Genera una presentazione dettagliata utilizzando l'istruzione e il modello master.
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # Salva la presentazione generata come PDF.
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **Benefici principali**

Il nuovo AI Presentation Generator in Aspose.Slides offre un modo rapido e flessibile per produrre deck di diapositive strutturati a partire da semplici prompt testuali. Con il supporto per template personalizzati, può essere integrato senza soluzione di continuità in una vasta gamma di applicazioni.

I casi d'uso tipici includono la creazione di presentazioni di marketing, materiale educativo, report per i clienti e deck di diapositive interne. Sebbene la generazione di immagini non sia ancora supportata, lo strumento offre già una solida base per automatizzare la creazione di presentazioni, con ulteriori miglioramenti previsti in futuro.