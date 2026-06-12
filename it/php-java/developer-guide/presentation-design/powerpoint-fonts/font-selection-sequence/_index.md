---
title: Sequenza di selezione dei caratteri in Aspose.Slides per PHP
linktitle: Selezione dei caratteri
type: docs
weight: 80
url: /it/php-java/font-selection-sequence/
keywords:
- selezione dei caratteri
- sostituzione dei caratteri
- sostituzione dei caratteri
- regola di sostituzione
- carattere disponibile
- carattere mancante
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come Aspose.Slides per PHP tramite Java seleziona i caratteri, garantendo una presentazione nitida e coerente di file PPT, PPTX e ODP — migliora le tue diapositive ora."
---
## **Panoramica**

Quando una presentazione viene caricata, renderizzata o convertita in un altro formato, Aspose.Slides verifica se i caratteri utilizzati nella presentazione sono disponibili nel sistema operativo. Se un carattere richiesto è mancante, Aspose.Slides seleziona un carattere sostitutivo il più simile possibile a quello che utilizzerà PowerPoint.

Aspose.Slides cerca prima il carattere selezionato nel sistema operativo. Se il carattere viene trovato, viene utilizzato. Se non viene trovato, viene applicato un sostituto adeguato. Quando le regole di sostituzione dei caratteri sono definite tramite `FontSubstRule`, queste regole vengono altresì considerate.

È inoltre possibile aggiungere caratteri in fase di esecuzione dell'applicazione, utilizzare caratteri incorporati da una presentazione o caricare caratteri esterni per documenti di output come i file PDF.

## **Selezione dei caratteri**

Alcune regole si applicano ai caratteri in una presentazione quando la presentazione viene caricata, renderizzata o convertita in un altro formato. Ad esempio, quando si tenta di convertire una presentazione (le sue diapositive) in immagini, i caratteri della presentazione vengono verificati per accertarsi che i caratteri scelti siano disponibili nel sistema operativo. Se i caratteri risultano mancanti, vengono sostituiti — vedere [**Sostituzione dei caratteri**](https://docs.aspose.com/slides/it/php-java/font-replacement/) e [**Sostituzione dei caratteri**](https://docs.aspose.com/slides/it/php-java/font-substitution/).

Questo è il processo che Aspose.Slides segue quando gestisce i caratteri:

1. Aspose.Slides ricerca i caratteri nel sistema operativo per trovare il carattere che corrisponde a quello scelto nella presentazione. 
2. Se il carattere scelto viene trovato, Aspose.Slides lo utilizza. Altrimenti, Aspose.Slides utilizza un carattere sostitutivo il più simile possibile a quello che userebbe PowerPoint. 
3. Se le regole di sostituzione dei caratteri sono state impostate tramite [FontSubstRule](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsubstrule/), vengono applicate.

Aspose.Slides consente di aggiungere caratteri al runtime di Aspose e quindi di utilizzare tali caratteri. Vedi [**Caratteri personalizzati**](https://docs.aspose.com/slides/it/php-java/custom-font/).

Quando dei caratteri aggiuntivi vengono inseriti in una presentazione, vengono chiamati [**Caratteri incorporati**](https://docs.aspose.com/slides/it/php-java/embedded-font/).

Aspose.Slides consente di aggiungere caratteri che vengono applicati *solo* ai documenti di output. Ad esempio, se una presentazione che si desidera convertire in PDF contiene caratteri mancanti dal proprio sistema e caratteri incorporati, è possibile aggiungere o caricare i caratteri necessari come **Caratteri esterni**. 

## **FAQ**

**Come posso determinare quali caratteri sono effettivamente usati in una presentazione prima della conversione?**

Aspose.Slides consente di ispezionare i caratteri utilizzati tramite il [font manager](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/), così è possibile decidere se [incorporare](/slides/it/php-java/embedded-font/), [sostituire](/slides/it/php-java/font-replacement/) o aggiungere [font esterni](/slides/it/php-java/custom-font/). Questo aiuta a evitare sostituzioni indesiderate durante il rendering e l'esportazione.

**Posso aggiungere directory di caratteri aggiuntive senza installarle sul sistema operativo?**

Sì. È possibile registrare [font esterni](/slides/it/php-java/custom-font/) come cartelle o stream in memoria per il rendering e l'esportazione. Questo elimina la dipendenza dai caratteri del sistema host e mantiene prevedibile il layout.

**Come posso evitare un fallback silenzioso a un carattere inadeguato quando un glifo è mancante?**

Definisci in anticipo [sostituzione dei caratteri](/slides/it/php-java/font-replacement/) e [regole di fallback dei caratteri](/slides/it/php-java/fallback-font/). Analizzando i caratteri utilizzati e impostando una priorità controllata per i sostituti, garantisci una tipografia coerente ed eviti risultati inattesi.