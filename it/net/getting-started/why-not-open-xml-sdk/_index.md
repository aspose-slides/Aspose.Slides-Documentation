---
title: Perché non Open XML SDK
type: docs
weight: 50
url: /it/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- confronto
- modello di oggetto di presentazione
- conversione di alta qualità
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri perché Aspose.Slides è una scelta migliore rispetto al gratuito Open XML SDK: confronta le funzionalità, la conversione senza automazione e l'ampio supporto per PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega quando gli sviluppatori potrebbero scegliere Open XML SDK o Aspose.Slides per lavorare con documenti di presentazione. Descrive Open XML SDK come una libreria per manipolare pacchetti OOXML e i relativi elementi XML sottostanti, mentre Aspose.Slides è presentato come una libreria di elaborazione delle presentazioni con un modello di oggetti di alto livello e supporto per molte attività correlate a PowerPoint.

L'articolo confronta entrambe le opzioni per formati supportati, modello di programmazione, capacità di rendering e stampa, supporto della piattaforma e casi d'uso comuni. Chiarisce inoltre che Open XML SDK può essere adatto per operazioni PPTX di base o per l'accesso diretto agli elementi OOXML, mentre Aspose.Slides è più appropriato per attività di presentazione complesse come la gestione di più formati PowerPoint, la copia o clonazione di forme, la sostituzione di testo, l'applicazione di animazioni e la conversione di presentazioni in PDF, TIFF o XPS.

## **Che cos'è Open XML SDK?**
A volte riceviamo questa domanda: *Perché dovremmo utilizzare i prodotti Aspose invece del gratuito Open XML SDK?*

Ci risulta semplice rispondere a questa domanda in termini di funzionalità e caratteristiche.

Secondo la [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK è definito in questo modo:

> "Open XML SDK 2.0 semplifica il compito di manipolare pacchetti Open XML e gli elementi dello schema Open XML sottostanti all'interno di un pacchetto. Open XML SDK 2.0 incapsula molte attività comuni che gli sviluppatori eseguono sui pacchetti Open XML, in modo da poter svolgere operazioni complesse con poche righe di codice. I documenti OOXML sono essenzialmente file XML compressi e Open XML SDK è una raccolta di classi che consente di lavorare con il contenuto dei documenti OOXML in modo fortemente tipizzato. Invece di decomprimere un file per estrarre XML, caricare quell'XML in un albero DOM e lavorare direttamente con gli elementi e gli attributi XML, Open XML SDK fornisce classi per farlo."

## **Che cos'è Aspose.Slides?**
Aspose.Slides è una libreria di classi che consente alle applicazioni di eseguire queste attività di elaborazione delle presentazioni:

- Programmazione con un modello di oggetti di presentazione.
- Conversioni di alta qualità che coinvolgono tutti i popolari formati di presentazione PowerPoint supportati, inclusa la conversione in PDF, XPS, TIFF e la stampa.
- Generazione di miniatura delle diapositive in formati noti come PNG, JPEG e BMP insieme all'esportazione delle diapositive in SVG.
- Creazione di presentazioni da zero o combinando elementi da uno o più documenti.
- Aggiunta di animazioni, OLE Frame, tabelle, creazione e gestione di grafici.
- Controllo (controllo estensivo) e gestione della formattazione del testo a livello di TextFrames, Paragraphs e Portions. 

Per ulteriori dettagli sulle funzionalità disponibili, consultare la pagina [Aspose.Slides Features](/slides/it/net/product-overview/).

## **Confronta Open XML SDK con Aspose.Slides**
Questo tavolo confronta le capacità e le funzionalità di Open XML SDK con quelle di Aspose.Slides.

|**Caratteristica o Categoria**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formati di presentazione supportati|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversione da PPT a PPTX|No|Yes|
|<p>Programmazione di alto livello con un Presentation Document Object Model (DOM): </p><p>- Trova e sostituisci testi.</p><p>- Assembla diapositive nelle presentazioni.</p>|No|Yes|
|Programmazione dettagliata con un modello di oggetti documento; accesso a singoli elementi e formattazione come TextHolders, TextFrames, Paragraphs e Portions.|Yes|Yes|
|Accesso diretto e completo di basso livello agli elementi XML sottostanti e agli attributi, come identificatori di relazione, identificatori di elenco di un documento OOXML.|Yes|No|
|<p>Rendering e Stampa:</p><p>- Renderizzare le presentazioni in PDF, PDF Notes, XPS, immagini TIFF.</p><p>- Renderizzare le miniature delle diapositive in PNG, JPEG, BMP, SVG e TIFF.</p><p>- Specificare risoluzione dell'immagine, qualità, compressione e altre opzioni.</p><p>- Stampare le presentazioni utilizzando l'infrastruttura di stampa .NET. Il componente dispone di un metodo di stampa integrato per stampare le presentazioni come mostrato nell'anteprima di stampa di MS PowerPoint.</p>|No|Yes|
|Piattaforme supportate|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Conclusione**
Open XML SDK e Aspose.Slides non competono direttamente perché rispondono a esigenze notevolmente diverse e si rivolgono a pubblici differenti.

{{% alert color="info" %}} 
Open XML SDK è una libreria di classi che fornisce un modo tipizzato per lavorare con i documenti OOXML mentre Aspose.Slides è una libreria di elaborazione delle presentazioni estremamente utile che offre un ottimo supporto per quasi tutti i formati di file Microsoft PowerPoint. 
{{% /alert %}} 

Se il tuo flusso di lavoro è un'operazione di programmazione di base su un documento PPTX, allora Open XML SDK potrebbe essere una buona scelta. Con Open XML SDK dovresti sentirti a tuo agio nell'eseguire compiti semplici come generare un documento PPTX semplice o rimuovere commenti, intestazioni/piè di pagina, estrarre immagini o altri elementi. Alcuni compiti possono essere effettuati con Open XML SDK ma non possono essere effettuati con Aspose.Slides. Per esempio, se hai bisogno di accedere direttamente agli elementi XML e agli attributi di un documento OOXML, dovresti usare Open XML SDK. 

Se devi eseguire compiti complessi sui documenti—come le attività nella lista seguente—allora Aspose.Slides è la tua migliore opzione. 

- Operazioni che coinvolgono formati PowerPoint più vecchi (e anche PPTX).  
- Copia o clonazione di forme all'interno delle diapositive in modo che combini oggetti, stili e altri elementi di formattazione in maniera appropriata.  
- Sostituzione di testo formattato o non formattato.  
- Applicazione di animazioni e utilizzo di connettori con le forme.  
- Conversione di un documento in PDF, TIFF o XPS in modo che appaia come se Microsoft PowerPoint avesse effettuato la conversione.  
- Sviluppare un'applicazione .NET o Java sia in ambienti desktop che basati sul web.