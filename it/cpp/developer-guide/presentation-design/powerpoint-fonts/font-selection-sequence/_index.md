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
description: "Scopri come Aspose.Slides per C++ seleziona i caratteri, garantendo una presentazione nitida e coerente di file PPT, PPTX e ODP—migliora le tue diapositive ora."
---
## **Panoramica**

Quando una presentazione viene caricata, resa o convertita in un altro formato, Aspose.Slides verifica se i caratteri utilizzati nella presentazione sono disponibili nel sistema operativo. Se un carattere richiesto è mancante, Aspose.Slides seleziona un carattere sostitutivo il più vicino possibile a quello che userebbe PowerPoint.

Aspose.Slides prima cerca il carattere selezionato nel sistema operativo. Se il carattere è trovato, viene usato. Se non è trovato, viene applicata una sostituzione adeguata. Quando le regole di sostituzione dei caratteri sono definite tramite `FontSubstRule`, anche queste regole vengono considerate.

È inoltre possibile aggiungere caratteri a runtime dell'applicazione, utilizzare caratteri incorporati da una presentazione o caricare caratteri esterni per documenti di output, ad esempio file PDF.

## **Selezione del carattere**

Alcune regole si applicano ai caratteri di una presentazione quando la presentazione viene caricata, resa o convertita in un altro formato. Ad esempio, quando si tenta di convertire una presentazione (le sue diapositive) in immagini, i caratteri della presentazione vengono controllati per verificare che i caratteri scelti siano disponibili nel sistema operativo. Se i caratteri risultano mancanti, vengono sostituiti — vedi [**Sostituzione dei caratteri**](https://docs.aspose.com/slides/it/cpp/font-replacement/) e [**Sostituzione dei caratteri (Font Substitution)**](https://docs.aspose.com/slides/it/cpp/font-substitution/).

Questo è il processo seguito da Aspose.Slides nella gestione dei caratteri:

1. Aspose.Slides cerca i caratteri nel sistema operativo per trovare quello che corrisponde al carattere scelto nella presentazione.  
2. Se il carattere scelto è trovato, Aspose.Slides lo utilizza. Altrimenti, Aspose.Slides utilizza un carattere sostitutivo il più vicino possibile a quello che userebbe PowerPoint.  
3. Se sono state impostate regole di sostituzione dei caratteri tramite [FontSubstRule](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsubstrule/), queste vengono applicate.  

Aspose.Slides consente di aggiungere caratteri a runtime dell'applicazione e poi di usarli. Vedi [**Caratteri personalizzati**](https://docs.aspose.com/slides/it/cpp/custom-font/).  

Quando i caratteri aggiuntivi vengono inseriti all'interno di una presentazione, si chiamano [**Caratteri incorporati**](https://docs.aspose.com/slides/it/cpp/embedded-font/).

Aspose.Slides permette di aggiungere caratteri che vengono applicati *solo* ai documenti di output. Ad esempio, se una presentazione che si desidera convertire in PDF contiene caratteri mancanti nel proprio sistema e caratteri incorporati, è possibile aggiungere o caricare i caratteri necessari come **caratteri esterni**. 

{{% alert title="Note" color="info" %}} 
Non distribuiamo alcun carattere, né a pagamento né gratuito. La nostra API consente di caricare caratteri esterni e incorporarli nei documenti, ma lo si fa con i caratteri a propria discrezione e responsabilità.
{{% /alert %}}

## **FAQ**

### Come posso determinare quali caratteri sono effettivamente utilizzati in una presentazione prima della conversione?

Aspose.Slides consente di ispezionare i caratteri usati tramite il [gestore dei caratteri](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_fontsmanager/), così da poter decidere se [incorporarli](/slides/it/cpp/embedded-font/), [sostituirli](/slides/it/cpp/font-replacement/) o aggiungere [font esterni](/slides/it/cpp/custom-font/). Questo aiuta a prevenire sostituzioni indesiderate durante la resa e l'esportazione.

### Posso aggiungere directory di font extra senza installarle nel sistema operativo?

Sì. È possibile registrare [font esterni](/slides/it/cpp/custom-font/) come cartelle o stream in memoria per la resa e l'esportazione. In questo modo si elimina la dipendenza dai font del sistema host e si mantiene il layout prevedibile.

### Come evito un ricorso silenzioso a un carattere inadatto quando un glifo è mancante?

Definire in anticipo [sostituzioni dei caratteri](/slides/it/cpp/font-replacement/) e regole di [fallback dei caratteri](/slides/it/cpp/fallback-font/). Analizzando i caratteri usati e impostando una priorità controllata per i sostituti, si garantisce una tipografia coerente e si evita risultati inaspettati.