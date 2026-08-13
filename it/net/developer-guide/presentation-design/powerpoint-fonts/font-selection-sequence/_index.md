---
title: Sequenza di selezione dei font in Aspose.Slides per .NET
linktitle: Selezione del font
type: docs
weight: 80
url: /it/net/font-selection-sequence/
keywords:
- selezione del font
- sostituzione del font
- sostituzione del font
- regola di sostituzione
- font disponibile
- font mancante
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come Aspose.Slides per .NET seleziona i font, garantendo una presentazione nitida e coerente di file PPT, PPTX e ODP—migliora le tue diapositive ora."
---
## **Panoramica**

Quando una presentazione viene caricata, resa o convertita in un altro formato, Aspose.Slides verifica se i caratteri utilizzati nella presentazione sono disponibili nel sistema operativo. Se un carattere richiesto è mancante, Aspose.Slides seleziona un carattere di sostituzione il più vicino possibile a quello che utilizzerebbe PowerPoint.

Aspose.Slides prima ricerca il carattere selezionato nel sistema operativo. Se il carattere viene trovato, viene utilizzato. Se non viene trovato, viene applicata una sostituzione adeguata. Quando le regole di sostituzione dei caratteri sono definite tramite `FontSubstRule`, queste regole vengono anch'esse considerate.

È possibile aggiungere anche i caratteri all'esecuzione dell'applicazione, utilizzare i caratteri incorporati da una presentazione o caricare caratteri esterni per i documenti di output come i file PDF.

## **Selezione del font**

Alcune regole si applicano ai font in una presentazione quando la presentazione viene caricata, resa o convertita in un altro formato. Per esempio, quando si tenta di convertire una presentazione (le sue diapositive) in immagini, i font della presentazione vengono controllati per verificare che i font scelti siano disponibili nel sistema operativo. Se i font risultano mancanti, vengono sostituiti — vedi [**Font Replacement**](https://docs.aspose.com/slides/it/net/font-replacement/) e [**Font Substitution**](https://docs.aspose.com/slides/it/net/font-substitution/).

Questo è il processo che Aspose.Slides segue quando gestisce i font:

1. Aspose.Slides cerca i font nel sistema operativo per trovare il font che corrisponde al font scelto nella presentazione. 
2. Se il font scelto viene trovato, Aspose.Slides lo utilizza. Altrimenti, Aspose.Slides utilizza un font di sostituzione il più vicino possibile a quello che userebbe PowerPoint.
3. Se le regole di sostituzione dei font sono state impostate tramite [FontSubstRule](https://reference.aspose.com/slides/it/net/aspose.slides/fontsubstrule/), vengono applicate. 

Aspose.Slides consente di aggiungere i font all'esecuzione dell'applicazione e quindi di utilizzare tali font. Vedi [**Custom fonts**](https://docs.aspose.com/slides/it/net/custom-font/). 

Quando font aggiuntivi vengono inseriti in una presentazione, sono chiamati [**Embedded fonts**](https://docs.aspose.com/slides/it/net/embedded-font/).

Aspose.Slides consente di aggiungere font che vengono applicati *solo* ai documenti di output. Per esempio, se una presentazione che si desidera convertire in PDF contiene font mancanti dal proprio sistema e font incorporati, è possibile aggiungere o caricare i font necessari come **external fonts**. 

{{% alert title="Note" color="info" %}} 
Non distribuiamo alcun font, né a pagamento né gratuito. La nostra API consente di caricare font esterni e di incorporarli nei documenti, ma lo fate con i font a vostra discrezione e responsabilità.
{{% /alert %}}

## **FAQ**

### Come posso determinare quali font sono effettivamente usati in una presentazione prima della conversione?

Aspose.Slides consente di esaminare i font utilizzati tramite il [font manager](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/fontsmanager/), così puoi decidere se [incorporare](/slides/it/net/embedded-font/), [sostituire](/slides/it/net/font-replacement/) o aggiungere [font esterni](/slides/it/net/custom-font/). Questo ti aiuta a evitare sostituzioni indesiderate durante il rendering e l'esportazione.

### Posso aggiungere directory di font aggiuntive senza installarle sul sistema operativo?

Sì. È possibile registrare [font esterni](/slides/it/net/custom-font/) come cartelle o stream in memoria per il rendering e l'esportazione. Questo elimina la dipendenza dai font del sistema host e mantiene il layout prevedibile.

### Come posso evitare un fallback silenzioso a un font inadeguato quando un glifo è mancante?

Definisci in anticipo [font replacement](/slides/it/net/font-replacement/) e le [regole di fallback dei font](/slides/it/net/fallback-font/). Analizzando i font utilizzati e impostando una priorità controllata per i sostituti, garantisci una tipografia coerente ed eviti risultati inattesi.