---
title: Generatore di Diapositive Multilingue con AI
linktitle: Generatore AI
type: docs
weight: 40
url: /it/python-java/ai/generator/
keywords:
- presentazione multilingue
- diapositiva multilingue
- generatore di presentazioni AI
- generatore di diapositive AI
- modello di presentazione
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Genera presentazioni multilingue da testo con Aspose.Slides per Python via Java. Scegli il livello di dettaglio del contenuto, applica un modello e esporta in PowerPoint o PDF."
---
## **Introduzione**

Il generatore di presentazioni AI in Aspose.Slides per Python tramite Java crea presentazioni a partire da descrizioni di argomenti, riassunti, citazioni o punti elenco. Specifica la lingua richiesta nel tuo prompt, scegli la quantità di contenuto e, facoltativamente, fornisci un modello di presentazione per definire layout e design.

Il generatore struttura il contenuto usando blocchi di testo, elenchi puntati e tabelle. Non genera immagini; è possibile aggiungerle alla presentazione risultante in un secondo momento. Rivedi il contenuto e il layout generati prima di condividere la presentazione.

## **Come funziona**

[SlidesAIAgent](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesaiagent/) utilizza un client AI per comunicare con un modello esterno. Gli esempi seguenti usano il [OpenAIWebClient](https://reference.aspose.com/slides/it/python-java/aspose.slides/openaiwebclient/) integrato. Aspose.Slides elabora le risposte del modello e crea una presentazione che puoi modificare o esportare.

Usa [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesaiagent/#generatePresentation) con una descrizione testuale e un valore di [PresentationContentAmountType](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationcontentamounttype/). La sovraccarico con un terzo argomento accetta una presentazione da utilizzare come modello di design.

## **Prerequisiti**

Segui [Installation](/slides/it/python-java/installation/) per configurare Python, Java, JPype e Aspose.Slides. Imposta le variabili d'ambiente `OPENAI_API_KEY` e `OPENAI_MODEL` prima di eseguire gli esempi. Scegli un modello supportato dal client integrato e disponibile per il tuo account API.

{{% alert color="info" title="Note" %}}
Il servizio AI richiede una connessione Internet e un accesso API separato. I prompt vengono inviati al servizio configurato e le relative tariffe di utilizzo si applicano indipendentemente dalla licenza di Aspose.Slides.
{{% /alert %}}

Ogni esempio avvia la JVM solo se non è già in esecuzione e la lascia disponibile per operazioni successive. Consulta la [JVM lifecycle guidance](/slides/it/python-java/limitations-and-api-differences/#import-the-library) quando adatti il codice per notebook.

## **Genera una presentazione da testo**

Questo esempio genera una presentazione in inglese con una quantità di contenuto [Medium](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationcontentamounttype/#Medium) e la salva come file PowerPoint.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Genera una presentazione usando un modello**

Posiziona `masterPresentation.pptx` nella directory di lavoro. Questo esempio lo carica con [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/), genera una presentazione in spagnolo con contenuto [Detailed](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationcontentamounttype/#Detailed) e la esporta in PDF. Sia il modello sia la presentazione generata vengono rilasciati, anche se la generazione o il salvataggio falliscono.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

Se devi configurare un proxy o i timeout di connessione, consulta [Configure the HTTP Connection](/slides/it/python-java/ai/translator/#configure-the-http-connection). Puoi anche passare il client risultante al generatore.

## **Vantaggi principali**

La generazione può ridurre il lavoro di bozza iniziale per materiale di formazione, panoramiche di prodotto, rapporti per clienti e presentazioni interne. I prompt controllano l'argomento e la lingua, mentre un modello consente di riutilizzare un design di presentazione esistente.

## **FAQ**

**Come faccio a controllare la lunghezza della presentazione generata?**

Scegli [Brief](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationcontentamounttype/#Medium) o [Detailed](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationcontentamounttype/#Detailed). Queste impostazioni influenzano sia il numero di diapositive sia il livello di dettaglio di ciascuna diapositiva; non specificano un conteggio esatto di diapositive.

**Posso generare diapositive in un'altra lingua?**

Sì. Includi la lingua richiesta nella descrizione testuale. Il risultato dipende dalle capacità linguistiche del modello selezionato.

**Posso mantenere una versione modificabile esportando in PDF?**

Sì. Prima di eliminare la presentazione generata, salvala anche come PPTX utilizzando l'approccio del primo esempio.