---
title: "Automatizzare la localizzazione delle presentazioni in C++"
linktitle: "Localizzazione delle presentazioni"
type: docs
weight: 100
url: /it/cpp/presentation-localization/
keywords:
- "cambio lingua"
- "correzione ortografica"
- "ID lingua"
- "PowerPoint"
- "OpenDocument"
- "presentazione"
- "C++"
- "Aspose.Slides"
description: "Automatizza la localizzazione di diapositive PowerPoint e OpenDocument in C++ con Aspose.Slides, usando esempi di codice pratici e consigli per una distribuzione globale più rapida."
---
## **Panoramica**

Questo articolo spiega come impostare il `LanguageId` per il testo in una presentazione utilizzando Aspose.Slides. Mostra come aprire una presentazione, aggiungere una forma con testo, assegnare un identificatore di lingua a una porzione di testo e salvare il risultato come file PPTX.

## **Modifica lingua per una presentazione e testo della forma**
- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) .
- Ottieni il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungi un AutoShape di tipo Rettangolo alla diapositiva.
- Aggiungi del testo al TextFrame.
- Imposta Language Id al testo.
- Scrivi la presentazione come file PPTX.

L'implementazione dei passaggi sopra è mostrata di seguito in un esempio.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **FAQ**

**Il Language ID attiva la traduzione automatica del testo?**

No. Il [Language ID](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_languageid/) in Aspose.Slides memorizza la lingua per il controllo ortografico e la correzione grammaticale, ma non traduce né modifica il contenuto del testo. È un metadato che PowerPoint comprende per la correzione.

**Il Language ID influenza la sillabazione e le interruzioni di riga durante il rendering?**

In Aspose.Slides, il [Language ID](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_languageid/) è per la correzione. La qualità della sillabazione e l'interruzione automatica delle linee dipendono principalmente dalla disponibilità di [font corretti](/slides/it/cpp/powerpoint-fonts/) e dalle impostazioni di layout/interruzione di riga per il sistema di scrittura. Per garantire un rendering corretto, rendi disponibili i font necessari, configura le [regole di sostituzione dei font](/slides/it/cpp/font-substitution/) e/o [incorpora i font](/slides/it/cpp/embedded-font/) nella presentazione.

**Posso impostare lingue diverse all'interno di un singolo paragrafo?**

Sì. Il [Language ID](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_languageid/) viene applicato a livello di porzione di testo, quindi un singolo paragrafo può mescolare più lingue con impostazioni di correzione distinte.