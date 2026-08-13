---
title: Sequenza di selezione dei caratteri in Aspose.Slides per Android via Java
linktitle: Selezione dei caratteri
type: docs
weight: 80
url: /it/androidjava/font-selection-sequence/
keywords:
- selezione dei caratteri
- sostituzione dei caratteri
- sostituzione del carattere
- regola di sostituzione
- carattere disponibile
- carattere mancante
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come Aspose.Slides per Android via Java seleziona i caratteri, garantendo una presentazione nitida e coerente di file PPT, PPTX e ODP—migliora le tue diapositive ora."
---
## **Panoramica**

Quando una presentazione viene caricata, renderizzata o convertita in un altro formato, Aspose.Slides verifica se i caratteri usati nella presentazione sono disponibili nel sistema operativo. Se un carattere richiesto è mancante, Aspose.Slides seleziona un carattere sostitutivo il più vicino possibile a quello che userebbe PowerPoint.

Aspose.Slides prima cerca il carattere selezionato nel sistema operativo. Se il carattere viene trovato, viene utilizzato. Se non viene trovato, viene applicato un sostituto adeguato. Quando le regole di sostituzione dei caratteri sono definite tramite `FontSubstRule`, queste regole vengono anch'esse prese in considerazione.

Puoi anche aggiungere caratteri al runtime dell'applicazione, usare caratteri incorporati da una presentazione o caricare caratteri esterni per documenti di output come file PDF.

## **Selezione del carattere**

Alcune regole si applicano ai caratteri in una presentazione quando la presentazione viene caricata, renderizzata o convertita in un altro formato. Ad esempio, quando provi a convertire una presentazione (le sue diapositive) in immagini, i caratteri della presentazione vengono controllati per verificare che i caratteri scelti siano disponibili nel sistema operativo. Se i caratteri risultano mancanti, vengono sostituiti — vedi [**Font Replacement**](https://docs.aspose.com/slides/it/androidjava/font-replacement/) e [**Font Substitution**](https://docs.aspose.com/slides/it/androidjava/font-substitution/).

Questo è il processo seguito da Aspose.Slides nella gestione dei caratteri:

1. Aspose.Slides cerca i caratteri nel sistema operativo per trovare il carattere che corrisponde a quello scelto nella presentazione. 
2. Se il carattere scelto viene trovato, Aspose.Slides lo utilizza. Altrimenti, Aspose.Slides utilizza un carattere sostitutivo il più vicino possibile a quello che userebbe PowerPoint.
3. Se le regole di sostituzione dei caratteri sono state impostate tramite [FontSubstRule](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsubstrule/), vengono applicate.

Aspose.Slides ti consente di aggiungere caratteri al runtime dell'applicazione e poi usarli. Vedi [**Custom fonts**](https://docs.aspose.com/slides/it/androidjava/custom-font/).

Quando vengono inseriti caratteri aggiuntivi all'interno di una presentazione, vengono chiamati [**Embedded fonts**](https://docs.aspose.com/slides/it/androidjava/embedded-font/).

Aspose.Slides ti permette di aggiungere caratteri che vengono applicati *solo* ai documenti di output. Ad esempio, se una presentazione che desideri convertire in PDF contiene caratteri mancanti nel tuo sistema e caratteri incorporati, puoi aggiungere o caricare i caratteri necessari come **external fonts**. 

{{% alert title="Note" color="info" %}}
Non distribuiamo alcun carattere, né a pagamento né gratuito. La nostra API ti consente di caricare caratteri esterni e incorporarli nei documenti, ma lo fai a tua discrezione e responsabilità.
{{% /alert %}}

## **FAQ**

### Come posso determinare quali caratteri sono effettivamente utilizzati in una presentazione prima della conversione?

Aspose.Slides ti consente di ispezionare i caratteri utilizzati tramite il [font manager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsmanager/), così puoi decidere se [incorpora](/slides/it/androidjava/embedded-font/), [sostituisci](/slides/it/androidjava/font-replacement/) o aggiungi [font esterni](/slides/it/androidjava/custom-font/). Questo ti aiuta a prevenire sostituzioni indesiderate durante il rendering e l'esportazione.

### Posso aggiungere directory di caratteri aggiuntive senza installarle nel sistema operativo?

Sì. Puoi registrare [font esterni](/slides/it/androidjava/custom-font/) come cartelle o stream in memoria per il rendering e l'esportazione. Questo elimina la dipendenza dai caratteri del sistema host e mantiene il layout prevedibile.

### Come evito un fallback silenzioso a un carattere inappropriato quando un glifo è mancante?

Definisci in anticipo [font replacement](/slides/it/androidjava/font-replacement/) e regole di [fallback font](/slides/it/androidjava/fallback-font/). Analizzando i caratteri usati e impostando una priorità controllata per i sostituti, garantisci tipografia coerente ed eviti risultati inaspettati.