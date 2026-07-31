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
- modello oggetto di presentazione
- conversione ad alta qualità
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri perché Aspose.Slides è una scelta migliore rispetto al gratuito Open XML SDK: confronta le funzionalità, la conversione senza automazione e l'ampio supporto per PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega quando gli sviluppatori potrebbero scegliere Open XML SDK o Aspose.Slides per lavorare con documenti di presentazione. Descrive Open XML SDK come una libreria per manipolare pacchetti OOXML e i loro elementi XML sottostanti, mentre Aspose.Slides è presentato come una libreria di elaborazione di presentazioni con un modello oggetto di alto livello e supporto per molte attività legate a PowerPoint.

L’articolo confronta entrambe le opzioni per formati supportati, modello di programmazione, capacità di rendering e stampa, supporto della piattaforma e casi d’uso comuni. Chiarisce inoltre che Open XML SDK può essere adatto per operazioni PPTX di base o accesso diretto agli elementi OOXML, mentre Aspose.Slides è più appropriato per compiti complessi come lavorare con più formati PowerPoint, copiare o clonare forme, sostituire testo, applicare animazioni e convertire presentazioni in PDF, TIFF o XPS.

## **Cos’è Open XML SDK?**
A volte riceviamo questa domanda: *Perché dovremmo usare i prodotti Aspose invece del gratuito Open XML SDK?* 

Ci risulta semplice rispondere a questa domanda in termini di funzionalità.

Secondo la [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK è definito così: 

> "The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree, and working with XML elements and attributes directly, Open XML SDK provides classes to do that."

## **Cos’è Aspose.Slides?**
Aspose.Slides è una libreria di classi che consente alle applicazioni di eseguire queste attività di elaborazione delle presentazioni: 

- Programmazione con un modello oggetto di presentazione.

- Conversioni di alta qualità che coinvolgono tutti i formati di presentazione PowerPoint più popolari, inclusa la conversione in PDF, XPS, TIFF e la stampa.

- Generazione di miniature diapositive in formati noti come PNG, JPEG e BMP insieme all’esportazione delle diapositive in SVG.

- Creazione di presentazioni da zero o combinando elementi da uno o più documenti.

- Aggiunta di animazioni, OLE Frame, tabelle, creazione e gestione di grafici.

- Controllo (esteso) e gestione della formattazione del testo a livello di TextFrames, Paragraphs e Portions. 

  Per ulteriori dettagli sulle funzionalità disponibili, consultare la pagina [Aspose.Slides Features](/slides/it/net/product-overview/).

## **Confronto tra Open XML SDK e Aspose.Slides**
Questa tabella confronta le capacità e le funzionalità di Open XML SDK con quelle di Aspose.Slides.

|**Funzionalità o Categoria di Funzionalità**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formati di presentazione supportati|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversione da PPT a PPTX|No|Sì|
|<p>Programmazione ad alto livello con un Presentation Document Object Model (DOM): </p><p>- Trova e sostituisci testi.</p><p>- Assembla diapositive nelle presentazioni.</p>|No|Sì|
|Programmazione dettagliata con un modello di oggetto documento; accesso a singoli elementi e formattazione come TextHolders, TextFrames, Paragraphs e Portions.|Sì|Sì|
|Accesso diretto e completo a basso livello agli elementi XML sottostanti e agli attributi, come identificatori di relazione, identificatori di elenco di un documento OOXML.|Sì|No|
|<p>Rendering e stampa:</p><p>- Renderizza presentazioni in PDF, PDF Notes, XPS, immagini TIFF.</p><p>- Renderizza anteprime diapositive in PNG, JPEG, BMP, SVG e TIFF.</p><p>- Specifica risoluzione immagine, qualità, compressione e altre opzioni.</p><p>- Stampa le presentazioni usando l'infrastruttura di stampa .NET. Il componente ha un metodo di stampa integrato per stampare le presentazioni come mostrato nell'anteprima di stampa di MS PowerPoint.</p>|No|Sì|
|Piattaforme supportate|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Conclusione**
Open XML SDK e Aspose.Slides non competono direttamente perché rispondono a esigenze notevolmente diverse e si rivolgono a pubblici differenti. 

{{% alert color="primary" %}} 

Open XML SDK è una libreria di classi che offre un modo tipizzato per lavorare con documenti OOXML, mentre Aspose.Slides è una libreria di elaborazione di presentazioni incredibilmente utile che fornisce un eccellente supporto per quasi tutti i formati di file Microsoft PowerPoint. 

{{% /alert %}} 

Se il tuo flusso di lavoro è un’operazione di programmazione di base su un documento PPTX, allora Open XML SDK potrebbe essere una buona scelta. Con Open XML SDK dovresti sentirti a tuo agio nell’eseguire attività semplici come generare un documento PPTX semplice o rimuovere commenti, intestazioni/piè di pagina, estrarre immagini o altri elementi. Alcune attività possono essere eseguite con Open XML SDK ma non con Aspose.Slides. Per esempio, se hai bisogno di accedere direttamente agli elementi e agli attributi XML di un documento OOXML, dovresti utilizzare Open XML SDK. 

Se hai bisogno di eseguire attività complesse sui documenti—come quelle elencate di seguito—Aspose.Slides è la tua migliore opzione. 

- Operazioni che coinvolgono formati PowerPoint più vecchi (e anche PPTX).  
- Copiare o clonare forme all’interno delle diapositive in modo da combinare oggetti, stili e altri elementi di formattazione in maniera adeguata.  
- Sostituire testo formattato o non formattato.  
- Applicare animazioni e usare connettori con le forme.  
- Convertire un documento in PDF, TIFF o XPS affinché appaia come se Microsoft PowerPoint avesse effettuato la conversione.  
- Sviluppare un’applicazione .NET o Java sia in ambienti desktop che web.