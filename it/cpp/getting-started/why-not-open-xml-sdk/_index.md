---
title: Perché non Open XML SDK
type: docs
weight: 100
url: /it/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- confronto
- modello di oggetto della presentazione
- conversione ad alta qualità
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri perché Aspose.Slides è una scelta migliore rispetto al gratuito Open XML SDK: confronta le funzionalità, la conversione senza automazione e il vasto supporto per PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega quando gli sviluppatori potrebbero scegliere Open XML SDK o Aspose.Slides per lavorare con documenti di presentazione. Descrive Open XML SDK come una libreria per manipolare pacchetti OOXML e i relativi elementi XML sottostanti, mentre Aspose.Slides è presentato come una libreria di elaborazione delle presentazioni con un modello di oggetti di alto livello e supporto per numerosi compiti legati a PowerPoint.

L'articolo confronta entrambe le opzioni in base ai formati supportati, al modello di programmazione, al rendering, al supporto della piattaforma e ai casi d'uso comuni. Inoltre chiarisce che Open XML SDK può essere adatto per operazioni PPTX di base o per l'accesso diretto agli elementi OOXML, mentre Aspose.Slides è più appropriato per compiti di presentazione complessi, come la gestione di più formati PowerPoint, la copia o clonazione di forme, la sostituzione di testo, l'applicazione di animazioni e la conversione di presentazioni in PDF, TIFF o XPS.

## **Cos'è Open XML SDK?**

A volte sentiamo questa domanda: perché dovremmo usare i prodotti Aspose anziché il gratuito Open XML SDK? La risposta è semplice: caratteristiche e funzionalità. Secondo la[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK è definito come: *The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree and working with XML elements and attributes directly, Open XML SDK provides classes to do that.*

## **Cos'è Aspose.Slides?**

Aspose.Slides è una libreria di classi che consente alla tua applicazione di eseguire le seguenti operazioni di elaborazione delle presentazioni:

- Programmazione con un modello di oggetti **Presentation**.
- Conversioni di alta qualità tra tutti i formati di presentazione PowerPoint più diffusi, inclusa la conversione in PDF e XPS.
- Possibilità di generare miniature delle diapositive in formati noti come PNG, JPEG e BMP, oltre all'esportazione della diapositiva in SVG.
- Possibilità di creare presentazioni da zero o combinandole da uno o più documenti.
- Supporto per l'aggiunta di animazioni, Ole Frames, tabelle, creazione e gestione di grafici.
- Disponibilità di un ampio controllo per la gestione della formattazione del testo a livello di TextFrames, Paragraphs e Portions.

Per ulteriori dettagli sulle funzionalità supportate, visita [Aspose.Slides Features](/slides/it/cpp/product-overview/).

## **Confronta Open XML SDK e Aspose.Slides**

La tabella seguente confronta le funzionalità di Open XML SDK e Aspose.Slides.

|**Caratteristica o Categoria**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formati di presentazione supportati|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversione da PPT a PPTX|No|Sì|
|<p>Programmazione di alto livello con un Presentation Document Object Model (DOM):</p><p>- Trova e sostituisci testo.</p><p>- Assembla diapositive nelle presentazioni.</p>|No|Sì|
|Programmazione dettagliata con un modello di oggetto documento, accesso a singoli elementi e formattazione come TextHolders, TextFrames, Paragraphs e Portions.|Sì|Sì|
|Accesso diretto e completo a basso livello agli elementi XML sottostanti e agli attributi, come identificatori di relazione e di elenco di un documento OOXML.|Sì|No|
|<p>Rendering:</p><p>- Renderizza presentazioni in PDF, PDF Notes, XPS, immagini TIFF.</p><p>- Renderizza miniature delle diapositive in PNG, JPEG, BMP, SVG e TIFF.</p><p>- Specifica risoluzione dell'immagine, qualità, compressione e altre opzioni.</p>|No|Sì|

## **Conclusione**

Open XML SDK e Aspose.Slides non competono testa a testa perché rispondono a esigenze e pubblici diversi. Open XML SDK è una libreria di classi che fornisce un modo tipizzato per lavorare con documenti OOXML. Aspose.Slides è una libreria di elaborazione delle presentazioni molto utile che offre un ottimo supporto per quasi tutti i formati di file Microsoft PowerPoint. Se tutto ciò che devi fare è un'operazione di programmazione piuttosto basica su un documento PPTX, allora Open XML SDK potrebbe essere una scelta adeguata. Con Open XML SDK, sarai abbastanza a tuo agio nell'eseguire compiti semplici come generare un documento PPTX semplice o rimuovere commenti, intestazioni/piè di pagina, estrarre immagini o altri elementi. Alcuni compiti possono essere realizzati con Open XML SDK, ma non con Aspose.Slides. Per esempio, se hai bisogno di accedere direttamente agli elementi e agli attributi XML di un documento OOXML, dovresti usare Open XML SDK. Tuttavia, se devi eseguire operazioni complesse sui documenti, come alcune delle seguenti attività, allora usare Aspose.Slides è la tua migliore opzione:

- Supportare formati PowerPoint più vecchi oltre a PPTX.
- Copiare o clonare forme all'interno delle diapositive in modo da combinare oggetti, stili e altra formattazione in maniera appropriata.
- Sostituire testo formattato o non formattato.
- Applicare animazioni e utilizzare connettori con le forme.
- Convertire un documento in PDF o XPS in modo che appaia esattamente come farebbe Microsoft PowerPoint.
- Sviluppare un'applicazione C++ sia in ambienti desktop che console.