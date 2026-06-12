---
title: Sequenza di selezione dei caratteri in Aspose.Slides per C++
linktitle: Selezione dei caratteri
type: docs
weight: 80
url: /it/cpp/font-selection-sequence/
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
- C++
- Aspose.Slides
description: "Scopri come Aspose.Slides per C++ seleziona i caratteri, garantendo una presentazione nitida e coerente di file PPT, PPTX e ODP — migliora le tue diapositive ora."
---
## **Panoramica**

Quando una presentazione viene caricata, renderizzata o convertita in un altro formato, Aspose.Slides verifica se i caratteri utilizzati nella presentazione sono disponibili nel sistema operativo. Se un carattere richiesto è mancante, Aspose.Slides seleziona un carattere di sostituzione il più vicino possibile a quello che userebbe PowerPoint.

Aspose.Slides cerca innanzitutto il carattere selezionato nel sistema operativo. Se il carattere viene trovato, viene utilizzato. Se non viene trovato, viene applicata una sostituzione adeguata. Quando le regole di sostituzione dei caratteri sono definite tramite `FontSubstRule`, anche queste regole vengono prese in considerazione.

È inoltre possibile aggiungere caratteri durante l'esecuzione dell'applicazione, utilizzare caratteri incorporati da una presentazione o caricare caratteri esterni per documenti di output, come file PDF.

## **Selezione dei caratteri**

Alcune regole si applicano ai caratteri di una presentazione quando la presentazione viene caricata, renderizzata o convertita in un altro formato. Ad esempio, quando si tenta di convertire una presentazione (le sue diapositive) in immagini, i caratteri della presentazione vengono controllati per verificare che i caratteri scelti siano disponibili nel sistema operativo. Se i caratteri risultano mancanti, vengono sostituiti — vedere [**Sostituzione dei caratteri**](https://docs.aspose.com/slides/it/cpp/font-replacement/) e [**Sostituzione dei caratteri**](https://docs.aspose.com/slides/it/cpp/font-substitution/).

Questo è il processo seguito da Aspose.Slides nella gestione dei caratteri:

1. Aspose.Slides ricerca i caratteri nel sistema operativo per trovare il carattere che corrisponde a quello scelto nella presentazione. 
2. Se il carattere scelto viene trovato, Aspose.Slides lo utilizza. Altrimenti, Aspose.Slides utilizza un carattere di sostituzione il più vicino possibile a quello che userebbe PowerPoint.
3. Se le regole di sostituzione dei caratteri sono state impostate tramite [FontSubstRule](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsubstrule/), vengono applicate. 

Aspose.Slides consente di aggiungere caratteri durante l'esecuzione dell'applicazione e di usarli successivamente. Vedere [**Caratteri personalizzati**](https://docs.aspose.com/slides/it/cpp/custom-font/). 

Quando caratteri aggiuntivi vengono inseriti all'interno di una presentazione, vengono chiamati [**Caratteri incorporati**](https://docs.aspose.com/slides/it/cpp/embedded-font/).

Aspose.Slides consente di aggiungere caratteri che vengono applicati *solo* ai documenti di output. Ad esempio, se una presentazione che si desidera convertire in PDF contiene caratteri mancanti dal proprio sistema e caratteri incorporati, è possibile aggiungere o caricare i caratteri necessari come **caratteri esterni**. 

{{% alert title="Note" color="primary" %}} 
Non distribuiamo alcun carattere, né a pagamento né gratuito. La nostra API consente di caricare caratteri esterni e di incorporarli nei documenti, ma lo si fa con i caratteri a propria discrezione e responsabilità.
{{% /alert %}}

## **FAQ**

**Come posso determinare quali caratteri sono effettivamente utilizzati in una presentazione prima della conversione?**

Aspose.Slides consente di ispezionare i caratteri utilizzati tramite il [gestore dei caratteri](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_fontsmanager/), così è possibile decidere se [incorporare](/slides/it/cpp/embedded-font/), [sostituire](/slides/it/cpp/font-replacement/) o aggiungere [font esterni](/slides/it/cpp/custom-font/). Questo aiuta a prevenire sostituzioni indesiderate durante il rendering e l'esportazione.

**Posso aggiungere directory di font aggiuntive senza installarle sul sistema operativo?**

Sì. È possibile registrare [font esterni](/slides/it/cpp/custom-font/) come cartelle o flussi in memoria per il rendering e l'esportazione. Questo elimina la dipendenza dai font del sistema host e mantiene il layout prevedibile.

**Come faccio a prevenire un fallback silenzioso a un carattere inadeguato quando un glifo è mancante?**

Definisci in anticipo la [sostituzione dei caratteri](/slides/it/cpp/font-replacement/) e le [regole di fallback dei caratteri](/slides/it/cpp/fallback-font/). Analizzando i caratteri utilizzati e impostando una priorità controllata per i sostituti, garantisci una tipografia coerente ed eviti risultati inattesi.