---
title: Sequenza di selezione dei font in Aspose.Slides per Python tramite Java
linktitle: Selezione dei font
type: docs
weight: 80
url: /it/python-java/font-selection-sequence/
keywords:
- selezione dei font
- sostituzione dei font
- sostituzione dei font
- regola di sostituzione
- font disponibile
- font mancante
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come Aspose.Slides per Python tramite Java seleziona i font, garantendo una presentazione nitida e coerente di file PPT, PPTX e ODP — migliora le tue diapositive ora."
---
## **Panoramica**

Quando una presentazione viene caricata, renderizzata o convertita in un altro formato, Aspose.Slides verifica se i font utilizzati nella presentazione sono disponibili nel sistema operativo. Se un font richiesto è mancante, Aspose.Slides seleziona un font sostitutivo il più vicino possibile a quello che userebbe PowerPoint.

Aspose.Slides prima cerca il font selezionato nel sistema operativo. Se il font viene trovato, viene utilizzato. Se non viene trovato, viene applicato un sostituto adeguato. Quando le regole di sostituzione dei font sono definite tramite [FontSubstRule](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsubstrule/), queste regole vengono inoltre considerate.

È inoltre possibile aggiungere font durante l'esecuzione dell'applicazione, utilizzare font incorporati da una presentazione o caricare font esterni per i documenti di output come i file PDF.

## **Selezione dei font**

Alcune regole si applicano ai font di una presentazione quando la presentazione viene caricata, renderizzata o convertita in un altro formato. Ad esempio, quando si tenta di convertire una presentazione (le sue diapositive) in immagini, i font della presentazione vengono verificati per assicurarsi che i font scelti siano disponibili nel sistema operativo. Se i font risultano mancanti, vengono sostituiti — vedere [Sostituzione dei font](/slides/it/python-java/font-replacement/) e [Sostituzione dei font](/slides/it/python-java/font-substitution/).

Questo è il processo che Aspose.Slides segue nella gestione dei font:

1. Aspose.Slides ricerca i font nel sistema operativo per trovare il font che corrisponde al font scelto nella presentazione.  
2. Se il font scelto viene trovato, Aspose.Slides lo utilizza. Altrimenti, Aspose.Slides utilizza un font sostitutivo il più vicino possibile a quello che userebbe PowerPoint.  
3. Se le regole di sostituzione dei font sono state impostate tramite [FontSubstRule](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsubstrule/), esse vengono applicate.

Aspose.Slides consente di aggiungere font durante l'esecuzione dell'applicazione e quindi di utilizzare tali font. Vedere [Font personalizzati](/slides/it/python-java/custom-font/).

Quando font aggiuntivi sono inseriti all'interno di una presentazione, vengono chiamati [Font incorporati](/slides/it/python-java/embedded-font/).

Aspose.Slides consente di aggiungere font che vengono applicati *solo* ai documenti di output. Ad esempio, se una presentazione che si desidera convertire in PDF utilizza font che non sono installati sul sistema né incorporati nella presentazione, è possibile aggiungere o caricare i font necessari come **font esterni**.

{{% alert title="Note" color="info" %}}
We do not distribute any fonts, either paid or free. Our API allows you to load external fonts and embed them in documents, but you do so at your own discretion and responsibility.
{{% /alert %}}

## **FAQ**

**Come posso determinare quali font sono effettivamente usati in una presentazione prima della conversione?**

Aspose.Slides consente di ispezionare i font utilizzati tramite il [gestore dei font](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/), così da poter decidere se [incorporare](/slides/it/python-java/embedded-font/), [sostituire](/slides/it/python-java/font-replacement/) o aggiungere [font esterni](/slides/it/python-java/custom-font/). Questo ti aiuta a prevenire sostituzioni indesiderate durante il rendering e l'esportazione.

**Posso aggiungere directory di font aggiuntive senza installarle sul sistema operativo?**

Sì. È possibile registrare [font esterni](/slides/it/python-java/custom-font/) come cartelle o stream in memoria per il rendering e l'esportazione. Ciò elimina la dipendenza dai font del sistema host e mantiene il layout prevedibile.

**Come posso impedire un ricorso silenzioso a un font inadatto quando un glifo è mancante?**

Definisci in anticipo una [sostituzione dei font](/slides/it/python-java/font-replacement/) esplicita e le [regole di fallback](/slides/it/python-java/fallback-font/) dei font. Analizzando i font utilizzati e impostando una priorità controllata per i sostituti, garantisci una tipografia coerente ed eviti risultati inattesi.