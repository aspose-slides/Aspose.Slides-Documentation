---
title: Sequenza di selezione dei font in Aspose.Slides per Python
linktitle: Selezione del font
type: docs
weight: 80
url: /it/python-net/font-selection-sequence/
keywords:
- selezione dei font
- sostituzione dei font
- rimpiazzo dei font
- regola di sostituzione
- font disponibile
- font mancante
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come Aspose.Slides per Python via .NET seleziona i font, garantendo una presentazione nitida e coerente di file PPT, PPTX e ODP - migliora le tue diapositive ora."
---
## **Panoramica**

Quando una presentazione viene caricata, resa o convertita in un altro formato, Aspose.Slides verifica se i caratteri utilizzati nella presentazione sono disponibili nel sistema operativo. Se un carattere richiesto è mancante, Aspose.Slides seleziona un carattere sostitutivo il più vicino possibile a quello che PowerPoint userebbe.

Aspose.Slides cerca prima il carattere selezionato nel sistema operativo. Se il carattere viene trovato, viene utilizzato. Se non viene trovato, viene applicato un sostituto adeguato. Quando le regole di sostituzione dei caratteri sono definite tramite `FontSubstRule`, anche queste regole vengono prese in considerazione.

È inoltre possibile aggiungere caratteri a runtime dell'applicazione, utilizzare caratteri incorporati da una presentazione o caricare caratteri esterni per documenti di output come file PDF.

## **Selezione del carattere**

Alcune regole si applicano ai caratteri in una presentazione quando la presentazione viene caricata, resa o convertita in un altro formato. Ad esempio, quando si tenta di convertire una presentazione (le sue diapositive) in immagini, i caratteri della presentazione vengono controllati per verificare che i caratteri scelti siano disponibili nel sistema operativo. Se i caratteri vengono confermati come mancanti, vengono sostituiti — vedi [**Sostituzione dei caratteri**](https://docs.aspose.com/slides/it/python-net/font-replacement/) e [**Sostituzione del carattere**](https://docs.aspose.com/slides/it/python-net/font-substitution/).

Questo è il processo seguito da Aspose.Slides nella gestione dei caratteri:

1. Aspose.Slides ricerca i caratteri nel sistema operativo per trovare il carattere che corrisponde al carattere scelto nella presentazione. 
2. Se il carattere scelto viene trovato, Aspose.Slides lo utilizza. Altrimenti, Aspose.Slides utilizza un carattere sostitutivo il più vicino possibile a quello che PowerPoint userebbe.
3. Se sono state impostate regole di sostituzione dei caratteri tramite [FontSubstRule](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsubstrule/), vengono applicate. 

Aspose.Slides consente di aggiungere caratteri a runtime dell'applicazione e poi usarli. Vedi [**Caratteri personalizzati**](https://docs.aspose.com/slides/it/python-net/custom-font/). 

Quando i caratteri aggiuntivi sono inseriti in una presentazione, sono chiamati [**Caratteri incorporati**](https://docs.aspose.com/slides/it/python-net/embedded-font/).

Aspose.Slides consente di aggiungere caratteri che vengono applicati *solo* ai documenti di output. Ad esempio, se una presentazione che si desidera convertire in PDF contiene caratteri mancanti nel proprio sistema e caratteri incorporati, è possibile aggiungere o caricare i caratteri necessari come **caratteri esterni**. 

{{% alert title="Note" color="primary" %}} 
Non distribuiamo alcun carattere, né a pagamento né gratuito. La nostra API consente di caricare caratteri esterni e incorporarli nei documenti, ma lo fate a vostra discrezione e responsabilità.
{{% /alert %}}

## **FAQ**

**Come posso determinare quali caratteri sono effettivamente utilizzati in una presentazione prima della conversione?**

Aspose.Slides consente di ispezionare i caratteri utilizzati tramite il [font manager](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/fonts_manager/), così da poter decidere se [incorporare](/slides/it/python-net/embedded-font/), [sostituire](/slides/it/python-net/font-replacement/) o aggiungere [font esterni](/slides/it/python-net/custom-font/). Questo ti aiuta a prevenire sostituzioni indesiderate durante il rendering e l'esportazione.

**Posso aggiungere directory di caratteri extra senza installarle nel sistema operativo?**

Sì. È possibile registrare [font esterni](/slides/it/python-net/custom-font/) come cartelle o stream in memoria per il rendering e l'esportazione. Questo rimuove la dipendenza dai caratteri del sistema host e mantiene il layout prevedibile.

**Come posso evitare un fallback silenzioso a un carattere non adatto quando un glifo è mancante?**

Definisci esplicitamente [sostituzione dei caratteri](/slides/it/python-net/font-replacement/) e regole di [fallback dei caratteri](/slides/it/python-net/fallback-font/) in anticipo. Analizzando i caratteri usati e impostando una priorità controllata per i sostituti, garantisci una tipografia coerente ed eviti risultati inaspettati.