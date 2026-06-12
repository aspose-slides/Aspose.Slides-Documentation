---
title: Sequenza di selezione dei font in Aspose.Slides per .NET
linktitle: Selezione dei font
type: docs
weight: 80
url: /it/net/font-selection-sequence/
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
- .NET
- C#
- Aspose.Slides
description: "Scopri come Aspose.Slides per .NET seleziona i font, garantendo una presentazione nitida e coerente di file PPT, PPTX e ODP—migliora subito le tue diapositive."
---
## **Panoramica**

Quando una presentazione viene caricata, resa o convertita in un altro formato, Aspose.Slides verifica se i caratteri utilizzati nella presentazione sono disponibili nel sistema operativo. Se un carattere richiesto è mancante, Aspose.Slides seleziona un carattere di sostituzione il più vicino possibile a quello che userebbe PowerPoint.

Aspose.Slides prima cerca il carattere selezionato nel sistema operativo. Se il carattere viene trovato, viene utilizzato. Se non viene trovato, viene applicata una sostituzione appropriata. Quando le regole di sostituzione dei caratteri sono definite tramite `FontSubstRule`, anche queste regole vengono considerate.

È inoltre possibile aggiungere caratteri durante l'esecuzione dell'applicazione, utilizzare caratteri incorporati da una presentazione o caricare caratteri esterni per documenti di output come file PDF.

## **Selezione dei font**

Alcune regole si applicano ai caratteri di una presentazione quando la presentazione viene caricata, resa o convertita in un altro formato. Per esempio, quando si tenta di convertire una presentazione (le sue diapositive) in immagini, i caratteri della presentazione vengono controllati per verificare che i caratteri scelti siano disponibili nel sistema operativo. Se i caratteri risultano mancanti, vengono sostituiti — vedere [**Sostituzione dei font**](https://docs.aspose.com/slides/it/net/font-replacement/) e [**Sostituzione dei font**](https://docs.aspose.com/slides/it/net/font-substitution/).

Questo è il processo che Aspose.Slides segue quando gestisce i caratteri:

1. Aspose.Slides ricerca i caratteri nel sistema operativo per trovare il carattere che corrisponde a quello scelto nella presentazione. 
2. Se il carattere scelto viene trovato, Aspose.Slides lo utilizza. Altrimenti, Aspose.Slides utilizza un carattere di sostituzione il più vicino possibile a quello che userebbe PowerPoint. 
3. Se le regole di sostituzione dei caratteri sono state impostate tramite [FontSubstRule](https://reference.aspose.com/slides/it/net/aspose.slides/fontsubstrule/), vengono applicate. 

Aspose.Slides consente di aggiungere caratteri al runtime dell'applicazione e quindi di utilizzare tali caratteri. Vedi [**Caratteri personalizzati**](https://docs.aspose.com/slides/it/net/custom-font/). 

Quando caratteri aggiuntivi sono inseriti all'interno di una presentazione, vengono chiamati [**Caratteri incorporati**](https://docs.aspose.com/slides/it/net/embedded-font/).

Aspose.Slides consente di aggiungere caratteri che vengono applicati *solo* ai documenti di output. Per esempio, se una presentazione che si desidera convertire in PDF contiene caratteri assenti dal proprio sistema e caratteri incorporati, è possibile aggiungere o caricare i caratteri necessari come **caratteri esterni**. 

{{% alert title="Note" color="primary" %}} 
Non distribuiamo alcun carattere, né a pagamento né gratuito. La nostra API consente di caricare caratteri esterni e di incorporarli nei documenti, ma lo si fa con i caratteri a propria discrezione e responsabilità.
{{% /alert %}}

## **Domande frequenti**

**Come posso determinare quali caratteri sono effettivamente usati in una presentazione prima della conversione?**

Aspose.Slides consente di ispezionare i caratteri utilizzati tramite il [font manager](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/fontsmanager/), così da poter decidere se [incorporare](/slides/it/net/embedded-font/), [sostituire](/slides/it/net/font-replacement/) o aggiungere [font esterni](/slides/it/net/custom-font/). Questo ti aiuta a prevenire sostituzioni indesiderate durante il rendering e l'esportazione.

**Posso aggiungere directory di caratteri extra senza installarle sul sistema operativo?**

Sì. È possibile registrare [font esterni](/slides/it/net/custom-font/) come cartelle o flussi in memoria per il rendering e l'esportazione. Questo rimuove la dipendenza dai caratteri del sistema host e mantiene il layout prevedibile.

**Come posso evitare un fallback silenzioso a un carattere non appropriato quando un glifo è mancante?**

Definisci in anticipo [sostituzioni dei caratteri](/slides/it/net/font-replacement/) e [regole di fallback dei caratteri](/slides/it/net/fallback-font/). Analizzando i caratteri utilizzati e impostando una priorità controllata per i sostituti, garantisci una tipografia coerente ed eviti risultati inattesi.