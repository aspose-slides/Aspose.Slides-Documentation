---
title: Sequenza di selezione dei caratteri in Aspose.Slides per Java
linktitle: Selezione dei caratteri
type: docs
weight: 80
url: /it/java/font-selection-sequence/
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
- Java
- Aspose.Slides
description: "Scopri come Aspose.Slides per Java seleziona i caratteri, garantendo una presentazione nitida e coerente di file PPT, PPTX e ODP—migliora le tue diapositive ora."
---
## **Panoramica**

Quando una presentazione viene caricata, renderizzata o convertita in un altro formato, Aspose.Slides verifica se i caratteri utilizzati nella presentazione sono disponibili nel sistema operativo. Se un carattere richiesto è mancante, Aspose.Slides seleziona un carattere sostitutivo il più vicino possibile a quello che userebbe PowerPoint.

Aspose.Slides prima cerca il carattere selezionato nel sistema operativo. Se il carattere viene trovato, viene utilizzato. Se non viene trovato, viene applicato un sostituto adeguato. Quando le regole di sostituzione dei caratteri sono definite tramite `FontSubstRule`, anche queste regole vengono prese in considerazione.

È inoltre possibile aggiungere caratteri a runtime dell’applicazione, utilizzare caratteri incorporati da una presentazione o caricare caratteri esterni per documenti di output come file PDF.

## **Selezione dei caratteri**

Alcune regole si applicano ai caratteri di una presentazione quando la presentazione viene caricata, renderizzata o convertita in un altro formato. Ad esempio, quando si tenta di convertire una presentazione (le sue diapositive) in immagini, i caratteri della presentazione sono controllati per verificare che i caratteri scelti siano disponibili nel sistema operativo. Se i caratteri vengono confermati come mancanti, vengono sostituiti — vedi [**Sostituzione dei caratteri**](https://docs.aspose.com/slides/it/java/font-replacement/) e [**Sostituzione dei caratteri**](https://docs.aspose.com/slides/it/java/font-substitution/).

Questo è il processo seguito da Aspose.Slides nella gestione dei caratteri:

1. Aspose.Slides ricerca i caratteri nel sistema operativo per trovare il carattere che corrisponde a quello scelto nella presentazione. 
2. Se il carattere scelto viene trovato, Aspose.Slides lo utilizza. Altrimenti, Aspose.Slides utilizza un carattere sostitutivo il più vicino possibile a quello che userebbe PowerPoint.
3. Se sono state impostate regole di sostituzione dei caratteri tramite [FontSubstRule](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsubstrule/), vengono applicate. 

Aspose.Slides consente di aggiungere caratteri a runtime dell’applicazione e poi di usarli. Vedi [**Caratteri personalizzati**](https://docs.aspose.com/slides/it/java/custom-font/). 

Quando i caratteri aggiuntivi sono inseriti all’interno di una presentazione, vengono chiamati [**Caratteri incorporati**](https://docs.aspose.com/slides/it/java/embedded-font/).

Aspose.Slides permette di aggiungere caratteri che vengono applicati *solo* ai documenti di output. Ad esempio, se una presentazione che si desidera convertire in PDF contiene caratteri mancanti sia dal sistema sia dai caratteri incorporati, è possibile aggiungere o caricare i caratteri necessari come **caratteri esterni**. 

{{% alert title="Nota" color="info" %}} 
Non distribuiamo alcun carattere, né a pagamento né gratuito. La nostra API consente di caricare caratteri esterni e di incorporarli nei documenti, ma lo si fa con i caratteri a propria discrezione e responsabilità.
{{% /alert %}}

## **FAQ**

### Come posso determinare quali caratteri sono effettivamente utilizzati in una presentazione prima della conversione?

Aspose.Slides consente di ispezionare i caratteri utilizzati tramite il [font manager](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsmanager/), così da decidere se [incorporare](/slides/it/java/embedded-font/), [sostituire](/slides/it/java/font-replacement/) o aggiungere [font esterni](/slides/it/java/custom-font/). Questo aiuta a prevenire sostituzioni indesiderate durante il rendering e l’esportazione.

### Posso aggiungere directory di font aggiuntive senza installarle nel sistema operativo?

Sì. È possibile registrare [font esterni](/slides/it/java/custom-font/) come cartelle o flussi in memoria per il rendering e l’esportazione. Questo rimuove la dipendenza dai font del sistema host e mantiene il layout prevedibile.

### Come evito un fallback silenzioso a un carattere inadatto quando un glifo è mancante?

Definisci in anticipo [sostituzioni dei caratteri](/slides/it/java/font-replacement/) e regole di [fallback dei caratteri](/slides/it/java/fallback-font/). Analizzando i caratteri usati e impostando una priorità controllata per i sostituti, garantisci una tipografia coerente ed eviti risultati inaspettati.