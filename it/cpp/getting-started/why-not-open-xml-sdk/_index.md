---
title: Perché non Open XML SDK
type: docs
weight: 100
url: /it/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- confronto
- modello oggetto presentazione
- conversione ad alta qualità
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri perché Aspose.Slides è una scelta migliore rispetto al gratuito Open XML SDK: confronta le funzionalità, la conversione senza automazione e l'ampio supporto per PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega quando gli sviluppatori potrebbero scegliere Open XML SDK o Aspose.Slides per lavorare con documenti di presentazione. Descrive Open XML SDK come una libreria per manipolare pacchetti OOXML e i relativi elementi XML, mentre Aspose.Slides è presentato come una libreria di elaborazione delle presentazioni con un modello di oggetti di alto livello e supporto per molte attività legate a PowerPoint.

L'articolo confronta entrambe le opzioni per formati supportati, modello di programmazione, capacità di rendering e stampa, supporto della piattaforma e casi d'uso comuni. Chiarisce inoltre che Open XML SDK può essere adatto per operazioni PPTX di base o accesso diretto agli elementi OOXML, mentre Aspose.Slides è più appropriato per compiti di presentazione complessi come lavorare con più formati PowerPoint, copiare o clonare forme, sostituire testo, applicare animazioni e convertire presentazioni in PDF, TIFF o XPS.

## **Che cos'è Open XML SDK?**
A volte sentiamo questa domanda: Perché dovremmo usare i prodotti Aspose invece del gratuito Open XML SDK? Questa domanda è facile da rispondere: funzionalità e caratteristiche. Secondo la[Libreria MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK è definito come: The Open XML SDK 2.0 semplifica il compito di manipolare pacchetti Open XML e gli elementi di schema Open XML sottostanti all'interno di un pacchetto. L'Open XML SDK 2.0 incapsula molte attività comuni che gli sviluppatori eseguono sui pacchetti Open XML, in modo da poter eseguire operazioni complesse con poche righe di codice. I documenti OOXML sono essenzialmente file XML compressi e Open XML SDK è una raccolta di classi che consente di lavorare con il contenuto dei documenti OOXML in modo fortemente tipizzato. Invece di decomprimere un file per estrarre XML, caricare quel XML in un albero DOM e lavorare direttamente con elementi e attributi XML, Open XML SDK fornisce classi per farlo.

## **Che cos'è Aspose.Slides?**
Aspose.Slides è una libreria di classi che consente alla tua applicazione di eseguire le seguenti attività di elaborazione delle presentazioni:

- Programmazione con un modello di oggetti **Presentation**.
- Conversioni di alta qualità tra tutti i formati di presentazione PowerPoint supportati, inclusa la conversione in PDF e XPS.
- Possibilità di generare miniature di diapositive in formati noti come PNG, JPEG e BMP insieme all'esportazione della diapositiva in SVG.
- Possibilità di creare presentazioni da zero o combinandole da uno o più documenti.
- Supporto per aggiungere animazioni, Ole Frame, tabelle, creare e gestire grafici.
- Disponibilità di un controllo esteso per la gestione della formattazione del testo su livelli TextFrames, Paragraph e Portion.
  Per maggiori dettagli sulle funzionalità supportate, visita [Funzionalità di Aspose.Slides](/slides/it/cpp/product-overview/).

## **Confronta Open XML SDK e Aspose.Slides**
La tabella seguente confronta le funzionalità di Open XML SDK e Aspose.Slides.

|**Funzionalità o Categoria di Funzionalità**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formati di presentazione supportati|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversione da PPT a PPTX|No|Sì|
|<p>Programmazione ad alto livello con un Presentation Document Object Model (DOM):</p><p>- Trova e sostituisci testo.</p><p>- Assembla diapositive nelle presentazioni.</p>|No|Sì|
|Programmazione dettagliata con un modello di oggetto documento, accesso a elementi individuali e formattazione come TextHolders, TextFrames, Paragraphs e Portions.|Sì|Sì|
|Accesso diretto e completo a basso livello agli elementi XML sottostanti e agli attributi come identificatori di relazione, identificatori di elenco di un documento OOXML.|Sì|No|
|<p>Rendering:</p><p>- Renderizza presentazioni in PDF, PDF Notes, XPS, immagini TIFF.</p><p>- Renderizza miniature diapositive in PNG, JPEG, BMP, SVG e TIFF.</p><p>- Specifica risoluzione immagine, qualità, compressione e altre opzioni.</p>|No|Sì|

## **Conclusione**
Open XML SDK e Aspose.Slides non competono direttamente perché rispondono a esigenze e pubblici molto diversi. Open XML SDK è una libreria di classi che fornisce un modo fortemente tipizzato per lavorare con documenti OOXML. Aspose.Slides è una libreria di elaborazione delle presentazioni molto utile che offre un ottimo supporto per quasi tutti i formati di file Microsoft PowerPoint. Se tutto ciò che devi fare è un'operazione di programmazione piuttosto basilare su un documento PPTX, allora Open XML SDK potrebbe essere una scelta adeguata. Con Open XML SDK, sarai abbastanza a tuo agio nell'eseguire attività semplici come generare un documento PPTX semplice o rimuovere commenti, intestazioni/piè di pagina, estrarre immagini o altri elementi. Alcune attività possono essere realizzate con Open XML SDK, ma non con Aspose.Slides. Per esempio, se hai bisogno di accedere direttamente agli elementi XML e agli attributi di un documento OOXML, dovresti usare Open XML SDK. Tuttavia, se devi eseguire operazioni complesse sui documenti, come alcune delle seguenti attività, allora usare Aspose.Slides è la tua migliore opzione:

- Supportare formati PowerPoint più vecchi oltre a PPTX.
- Copiare o clonare forme all'interno delle diapositive in modo da combinare oggetti, stili e altra formattazione in maniera appropriata.
- Sostituire testo formattato o non formattato.
- Applicare animazioni e utilizzare connettori con le forme.
- Convertire un documento in PDF o XPS in modo che appaia esattamente come farebbe Microsoft PowerPoint.
- Sviluppare un'applicazione C++ sia in ambienti desktop sia console.