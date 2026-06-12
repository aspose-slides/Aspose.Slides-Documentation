---
title: Automatizza la localizzazione delle presentazioni con Python
linktitle: Localizzazione delle presentazioni
type: docs
weight: 100
url: /it/python-net/presentation-localization/
keywords:
- cambio lingua
- controllo ortografico
- ID lingua
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Automatizza la localizzazione di diapositive PowerPoint e OpenDocument in Python con Aspose.Slides, usando esempi di codice pratici e consigli per una distribuzione globale più rapida."
---
## **Panoramica**

Questo articolo spiega come impostare il `language_id` per il testo in una presentazione utilizzando Aspose.Slides. Mostra come aprire una presentazione, aggiungere una forma con testo, assegnare un identificatore di lingua a una porzione di testo e salvare il risultato come file PPTX.

## **Modificare la lingua per la presentazione e il testo della forma**
- Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
- Ottenere il riferimento di una diapositiva usando il suo indice.
- Aggiungere un'AutoShape di tipo Rettangolo alla diapositiva.
- Aggiungere del testo al TextFrame.
- Impostare l'ID lingua al testo.
- Scrivere la presentazione come file PPTX.

L'implementazione dei passaggi sopra è mostrata di seguito in un esempio.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**L'ID lingua attiva la traduzione automatica del testo?**

No. [language_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/language_id/) in Aspose.Slides memorizza la lingua per il controllo ortografico e la revisione grammaticale, ma non traduce né modifica il contenuto del testo. È un metadato che PowerPoint comprende per la revisione.

**L'ID lingua influenza l'iphenazione e le interruzioni di riga durante il rendering?**

In Aspose.Slides, [language_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/language_id/) è destinato alla revisione. La qualità dell'iphenazione e l'adattamento a capo dipendono principalmente dalla disponibilità di [font appropriati](/slides/it/python-net/powerpoint-fonts/) e dalle impostazioni di layout/interruzione di riga per il sistema di scrittura. Per garantire un rendering corretto, rendere disponibili i font necessari, configurare le [regole di sostituzione dei font](/slides/it/python-net/font-substitution/) e/o [incorporare i font](/slides/it/python-net/embedded-font/) nella presentazione.

**Posso impostare lingue diverse all'interno di un singolo paragrafo?**

Sì. [language_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/language_id/) viene applicato a livello di porzione di testo, quindi un singolo paragrafo può mescolare più lingue con impostazioni di revisione distinte.