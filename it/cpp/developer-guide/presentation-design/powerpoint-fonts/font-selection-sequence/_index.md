---
title: Sequenza di selezione dei font in Aspose.Slides per C++
linktitle: Selezione dei font
type: docs
weight: 80
url: /it/cpp/font-selection-sequence/
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
- C++
- Aspose.Slides
description: "Scopri come Aspose.Slides per C++ seleziona i font, garantendo una presentazione nitida e coerente di file PPT, PPTX e ODP—migliora le tue diapositive ora."
---
## **Panoramica**

Quando una presentazione viene caricata, renderizzata o convertita in un altro formato, Aspose.Slides verifica se i font utilizzati nella presentazione sono disponibili nel sistema operativo. Se un font richiesto è mancante, Aspose.Slides seleziona un font di sostituzione il più simile possibile a quello che userebbe PowerPoint.

Aspose.Slides prima cerca il font selezionato nel sistema operativo. Se il font viene trovato, viene utilizzato. Se non viene trovato, viene applicata una sostituzione adeguata. Quando le regole di sostituzione dei font sono definite tramite `FontSubstRule`, anche queste regole vengono prese in considerazione.

È inoltre possibile aggiungere font durante l'esecuzione dell'applicazione, usare font incorporati da una presentazione o caricare font esterni per documenti di output come i file PDF.

## **Selezione dei font**

Alcune regole si applicano ai font di una presentazione quando la presentazione viene caricata, renderizzata o convertita in un altro formato. Ad esempio, quando si tenta di convertire una presentazione (le sue diapositive) in immagini, i font della presentazione vengono controllati per verificare che i font scelti siano disponibili nel sistema operativo. Se i font risultano mancanti, vengono sostituiti — vedi [**Sostituzione dei font**](https://docs.aspose.com/slides/it/cpp/font-replacement/) e [**Sostituzione dei font**](https://docs.aspose.com/slides/it/cpp/font-substitution/).

Questo è il processo seguito da Aspose.Slides nella gestione dei font:

1. Aspose.Slides cerca i font nel sistema operativo per trovare il font che corrisponde al font scelto nella presentazione.  
2. Se il font scelto viene trovato, Aspose.Slides lo utilizza. Altrimenti, Aspose.Slides utilizza un font di sostituzione il più simile possibile a quello che userebbe PowerPoint.  
3. Se sono state impostate regole di sostituzione dei font tramite [FontSubstRule](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsubstrule/), vengono applicate.  

Aspose.Slides consente di aggiungere font all'esecuzione dell'applicazione e poi usarli. Vedi [**Font personalizzati**](https://docs.aspose.com/slides/it/cpp/custom-font/).

Quando font aggiuntivi vengono inseriti all'interno di una presentazione, vengono chiamati [**Font incorporati**](https://docs.aspose.com/slides/it/cpp/embedded-font/).

Aspose.Slides permette di aggiungere font che vengono applicati *solo* ai documenti di output. Ad esempio, se una presentazione che si desidera convertire in PDF contiene font mancanti dal proprio sistema e font incorporati, è possibile aggiungere o caricare i font necessari come **font esterni**.  

{{% alert title="Note" color="primary" %}} 
Non distribuiamo alcun font, né a pagamento né gratuito. La nostra API consente di caricare font esterni e incorporarli nei documenti, ma lo fate con font a vostra discrezione e responsabilità.
{{% /alert %}}

## **FAQ**

**Come posso determinare quali font sono effettivamente utilizzati in una presentazione prima della conversione?**

Aspose.Slides consente di ispezionare i font utilizzati tramite il [gestore dei font](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_fontsmanager/), così da decidere se [incorporare](/slides/it/cpp/embedded-font/), [sostituire](/slides/it/cpp/font-replacement/) o aggiungere [font esterni](/slides/it/cpp/custom-font/). Questo aiuta a prevenire sostituzioni indesiderate durante il rendering e l'esportazione.

**Posso aggiungere directory di font aggiuntive senza installarle nel sistema operativo?**

Sì. È possibile registrare [font esterni](/slides/it/cpp/custom-font/) come cartelle o stream in memoria per il rendering e l'esportazione. Questo elimina la dipendenza dai font del sistema host e mantiene il layout prevedibile.

**Come evito un fallback silenzioso a un font inadatto quando un glifo è mancante?**

Definisci in anticipo [sostituzioni dei font](/slides/it/cpp/font-replacement/) e [regole di fallback dei font](/slides/it/cpp/fallback-font/). Analizzando i font usati e impostando una priorità controllata per i sostituti, garantisci una tipografia coerente ed eviti risultati inattesi.