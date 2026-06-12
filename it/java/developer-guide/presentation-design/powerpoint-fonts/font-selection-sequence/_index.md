---
title: Sequenza di selezione dei font in Aspose.Slides per Java
linktitle: Selezione dei font
type: docs
weight: 80
url: /it/java/font-selection-sequence/
keywords:
- selezione dei font
- sostituzione dei font
- sostituzione del font
- regola di sostituzione
- font disponibile
- font mancante
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri come Aspose.Slides per Java seleziona i font, garantendo una presentazione nitida e coerente di file PPT, PPTX e ODP—migliora le tue diapositive ora."
---
## **Panoramica**

Quando una presentazione viene caricata, renderizzata o convertita in un altro formato, Aspose.Slides verifica se i font utilizzati nella presentazione sono disponibili nel sistema operativo. Se un font necessario è mancante, Aspose.Slides seleziona un font sostitutivo il più vicino possibile a quello che PowerPoint userebbe.

Aspose.Slides ricerca innanzitutto il font selezionato nel sistema operativo. Se il font viene trovato, viene utilizzato. Se non viene trovato, viene applicato un sostituto adeguato. Quando le regole di sostituzione dei font sono definite tramite `FontSubstRule`, anche queste regole vengono considerate.

È inoltre possibile aggiungere font durante l'esecuzione dell'applicazione, utilizzare font incorporati da una presentazione o caricare font esterni per documenti di output come file PDF.

## **Selezione dei font**

Alcune regole si applicano ai font in una presentazione quando la presentazione viene caricata, renderizzata o convertita in un altro formato. Ad esempio, quando si tenta di convertire una presentazione (le sue diapositive) in immagini, i font della presentazione vengono verificati per assicurarsi che i font scelti siano disponibili nel sistema operativo. Se i font risultano mancanti, vengono sostituiti — vedere [**Sostituzione dei font**](https://docs.aspose.com/slides/it/java/font-replacement/) e [**Sostituzione dei font**](https://docs.aspose.com/slides/it/java/font-substitution/).

Questo è il processo seguito da Aspose.Slides nella gestione dei font:

1. Aspose.Slides ricerca i font nel sistema operativo per trovare il font che corrisponde al font scelto nella presentazione.  
2. Se il font scelto viene trovato, Aspose.Slides lo utilizza. Altrimenti, Aspose.Slides utilizza un font sostitutivo il più vicino possibile a quello che PowerPoint userebbe.  
3. Se sono state impostate regole di sostituzione dei font tramite [FontSubstRule](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsubstrule/), queste vengono applicate.  

Aspose.Slides consente di aggiungere font all'esecuzione dell'applicazione e poi di utilizzare tali font. Vedi [**Font personalizzati**](https://docs.aspose.com/slides/it/java/custom-font/).

Quando font aggiuntivi sono inseriti all'interno di una presentazione, vengono chiamati [**Font incorporati**](https://docs.aspose.com/slides/it/java/embedded-font/).

Aspose.Slides consente di aggiungere font che vengono applicati *solo* ai documenti di output. Ad esempio, se una presentazione che si desidera convertire in PDF contiene font mancanti sia dal sistema che tra i font incorporati, è possibile aggiungere o caricare i font necessari come **font esterni**.

{{% alert title="Nota" color="primary" %}} 
Non distribuiamo alcun font, sia a pagamento che gratuito. La nostra API consente di caricare font esterni e incorporarli nei documenti, ma ciò avviene con i font a vostra discrezione e responsabilità.
{{% /alert %}}

## **FAQ**

**Come posso determinare quali font vengono effettivamente utilizzati in una presentazione prima della conversione?**

Aspose.Slides consente di ispezionare i font utilizzati tramite il [font manager](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsmanager/), così da poter decidere se [incorporare](/slides/it/java/embedded-font/), [sostituire](/slides/it/java/font-replacement/) o aggiungere [font esterni](/slides/it/java/custom-font/). Questo aiuta a prevenire sostituzioni indesiderate durante il rendering e l'esportazione.

**Posso aggiungere directory di font aggiuntive senza installarle sul sistema operativo?**

Sì. È possibile registrare [font esterni](/slides/it/java/custom-font/) come cartelle o stream in memoria per il rendering e l'esportazione. In questo modo si elimina la dipendenza dai font del sistema host e si mantiene la disposizione prevedibile.

**Come posso impedire un ricorso silenzioso a un font inappropriato quando un glifo è mancante?**

Definire in anticipo [sostituzioni dei font](/slides/it/java/font-replacement/) e regole di [fallback dei font](/slides/it/java/fallback-font/). Analizzando i font utilizzati e impostando una priorità controllata per i sostituti, si garantisce una tipografia coerente ed evitare risultati inaspettati.