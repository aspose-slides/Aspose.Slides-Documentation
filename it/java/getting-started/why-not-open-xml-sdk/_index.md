---
title: Perché non Open XML SDK
type: docs
weight: 120
url: /it/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- confronto
- modello oggetto di presentazione
- conversione di alta qualità
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri perché Aspose.Slides è una scelta migliore rispetto al gratuito Open XML SDK: confronta le funzionalità, la conversione senza automazione e il vasto supporto per PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega quando gli sviluppatori potrebbero scegliere Open XML SDK o Aspose.Slides per lavorare con documenti di presentazione. Descrive Open XML SDK come una libreria per manipolare pacchetti OOXML e i relativi elementi XML sottostanti, mentre Aspose.Slides è presentato come una libreria di elaborazione delle presentazioni con un modello oggettuale di alto livello e supporto per molte attività legate a PowerPoint.

L'articolo confronta entrambe le opzioni per formati supportati, modello di programmazione, capacità di rendering e stampa, supporto della piattaforma e casi d'uso comuni. Chiarisce inoltre che Open XML SDK può essere adatto per operazioni PPTX di base o per l'accesso diretto agli elementi OOXML, mentre Aspose.Slides è più appropriato per compiti di presentazione complessi come la gestione di più formati PowerPoint, la copia o clonazione di forme, la sostituzione di testo, l'applicazione di animazioni e la conversione di presentazioni in PDF, TIFF o XPS.

## **Che cos'è Open XML SDK?**
Secondo la [Libreria MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK è definito come: 

Open XML SDK 2.0 semplifica il compito di manipolare pacchetti Open XML e gli elementi dello schema Open XML sottostanti all'interno di un pacchetto. Open XML SDK 2.0 incapsula molte attività comuni che gli sviluppatori eseguono sui pacchetti Open XML, così da poter eseguire operazioni complesse con poche righe di codice.

I documenti OOXML sono essenzialmente file XML compressi e Open XML SDK è una raccolta di classi che consente di lavorare con il contenuto dei documenti OOXML in modo fortemente tipizzato. Invece di decomprimere un file per estrarre l'XML, caricare quell'XML in un albero DOM e lavorare direttamente con gli elementi e gli attributi XML, Open XML SDK fornisce classi per farlo.

## **Che cos'è Aspose.Slides?**
Aspose.Slides è una libreria di classi che permette alla tua applicazione di eseguire le seguenti attività di elaborazione delle presentazioni:

- Programmazione con un modello oggettuale **Presentation**.
- Conversioni di alta qualità tra tutti i formati di presentazione PowerPoint supportati, inclusa la conversione in PDF, XPS e TIFF.
- Capacità di generare miniature diapositive in formati noti come PNG, JPEG e BMP insieme all'esportazione della diapositiva in SVG.
- Capacità di creare presentazioni da zero o combinando uno o più documenti.
- Supporto per aggiungere animazioni, Ole Frames, tabelle, creare e gestire grafici.
- Disponibilità di un ampio controllo per la gestione della formattazione del testo su TextFrames, Paragraphs e Portions.

Per ulteriori dettagli sulle funzionalità supportate, visita [Funzionalità Aspose.Slides](/slides/it/java/product-overview/).
## **Confronta Open XML SDK con Aspose.Slides**
{{% alert color="info" %}} 

The following table compares Open XML SDK and Aspose.Slides features.

{{% /alert %}} 

|**Funzionalità o Categoria di Funzionalità**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formati di presentazione supportati|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversione da PPT a PPTX|No|Sì|
|<p>Programmazione di alto livello con un Presentation Document Object Model (DOM):</p><p>- Trova e sostituisci testo.</p><p>- Assembla diapositive nelle presentazioni.</p>|No|Sì|
|Programmazione dettagliata con un modello oggettuale del documento, accesso a elementi individuali e formattazioni come TextHolders, TextFrames, Paragraphs e Portions.|Sì|Sì|
|Accesso di basso livello, diretto e completo agli elementi XML sottostanti e agli attributi, come identificatori di relazione, identificatori di elenco di un documento OOXML.|Sì|No|
|<p>Rendering:</p><p>- Rendering delle presentazioni in PDF, PDF Notes, XPS, immagini TIFF.</p><p>- Rendering delle miniature diapositive in PNG, JPEG, BMP, SVG e TIFF.</p><p>- Specifica risoluzione immagine, qualità, compressione e altre opzioni.</p>|No|Sì|
|Piattaforme supportate|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|
## **Conclusione**
{{% alert color="info" %}} 

Open XML SDK e Aspose.Slides non competono direttamente perché rispondono a esigenze e pubblici molto diversi. Open XML SDK è una libreria di classi che offre un modo fortemente tipizzato per lavorare con documenti OOXML. Aspose.Slides è una libreria di elaborazione delle presentazioni molto utile che fornisce un ottimo supporto per quasi tutti i formati di file Microsoft PowerPoint.

Se tutto ciò che devi fare è un'operazione di programmazione abbastanza basilare su un documento PPTX, allora Open XML SDK potrebbe essere una scelta adatta. Con Open XML SDK sarai abbastanza a tuo agio nell'eseguire compiti semplici come generare un documento PPTX semplice o rimuovere commenti, intestazioni/piedini, estrarre immagini o altri. Alcuni compiti possono essere realizzati con Open XML SDK, ma non possono esserlo con Aspose.Slides. Ad esempio, se hai bisogno di accedere direttamente agli elementi XML e agli attributi di un documento OOXML, dovresti utilizzare Open XML SDK. Tuttavia, se devi eseguire operazioni complesse sui documenti, come alcuni dei seguenti compiti, allora usare Aspose.Slides è la tua migliore opzione:

- Supportare i formati PowerPoint più vecchi oltre a PPTX.
- Copiare o clonare forme all'interno delle diapositive in modo che combini oggetti, stili e altre formattazioni in maniera appropriata.
- Sostituire testo formattato o non formattato.
- Applicare animazioni e utilizzare connettori con le forme.
- Convertire un documento in PDF, TIFF o XPS affinché appaia esattamente come lo convertirebbe Microsoft PowerPoint.
- Sviluppare un'applicazione .NET o Java sia in ambienti desktop sia basati sul web.

{{% /alert %}}