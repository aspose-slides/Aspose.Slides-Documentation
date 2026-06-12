---
title: Perché non Open XML SDK
type: docs
weight: 120
url: /it/php-java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- confronto
- modello di oggetto di presentazione
- conversione ad alta qualità
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Scopri perché Aspose.Slides è una scelta migliore rispetto al gratuito Open XML SDK: confronta le funzionalità, la conversione senza automazione e l'ampio supporto per PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega quando gli sviluppatori potrebbero scegliere Open XML SDK o Aspose.Slides per lavorare con documenti di presentazione. Descrive Open XML SDK come una libreria per manipolare pacchetti OOXML e i relativi elementi XML sottostanti, mentre Aspose.Slides è presentato come una libreria di elaborazione delle presentazioni con un modello di oggetti di alto livello e supporto per molte attività legate a PowerPoint.

L'articolo confronta entrambe le opzioni in base ai formati supportati, al modello di programmazione, alle capacità di rendering e stampa, al supporto delle piattaforme e ai casi d'uso comuni. Chiarisce inoltre che Open XML SDK può essere adatto per operazioni PPTX di base o per l'accesso diretto agli elementi OOXML, mentre Aspose.Slides è più appropriato per compiti di presentazione complessi, come lavorare con più formati PowerPoint, copiare o clonare forme, sostituire testo, applicare animazioni e convertire le presentazioni in PDF, TIFF o XPS.

## **Cos'è Open XML SDK?**
Secondo la [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK è definito come: 

Open XML SDK 2.0 semplifica il compito di manipolare pacchetti Open XML e gli elementi dello schema Open XML sottostanti all'interno di un pacchetto. Open XML SDK 2.0 incapsula molte attività comuni che gli sviluppatori eseguono sui pacchetti Open XML, in modo da poter eseguire operazioni complesse con sole poche righe di codice.

I documenti OOXML sono essenzialmente file XML compressi e Open XML SDK è una raccolta di classi che consente di lavorare con il contenuto dei documenti OOXML in modo fortemente tipizzato. Invece di decomprimere un file per estrarre XML, caricare quell'XML in un albero DOM e lavorare direttamente con gli elementi e gli attributi XML, Open XML SDK fornisce classi per farlo.

## **Cos'è Aspose.Slides?**
Aspose.Slides è una libreria di classi che consente alla tua applicazione di eseguire le seguenti attività di elaborazione delle presentazioni:

- Programmazione con un modello di oggetti **Presentation**.
- Conversioni di alta qualità tra tutti i formati di presentazione PowerPoint supportati, inclusa la conversione in PDF, XPS e TIFF.
- Possibilità di generare miniature delle diapositive in formati noti come PNG, JPEG e BMP insieme all'esportazione della diapositiva in SVG.
- Possibilità di creare presentazioni da zero o combinando uno o più documenti.
- Supporto per aggiungere animazioni, Ole Frames, tabelle, creare e gestire grafici.
- Disponibilità di un controllo esteso per la gestione della formattazione del testo su livelli TextFrames, Paragraph e Portions.

Per ulteriori dettagli sulle funzionalità supportate, visita [Aspose.Slides Features](/slides/it/php-java/product-overview/).

## **Confronta Open XML SDK con Aspose.Slides**
{{% alert color="primary" %}} 

La tabella seguente confronta le funzionalità di Open XML SDK e Aspose.Slides.

{{% /alert %}} 

|**Caratteristica o Categoria**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formati di presentazione supportati|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversione da PPT a PPTX |No|Yes|
|<p>Programmazione di alto livello con un Presentation Document Object Model (DOM):</p><p>- Trova e sostituisci testo.</p><p>- Assembla diapositive nelle presentazioni.</p>|No|Yes|
|Programmazione dettagliata con un modello di oggetti documento, accesso a elementi individuali e formattazione come TextHolders, TextFrames, Paragraphs e Portions.|Yes|Yes|
|Accesso diretto e completo a basso livello agli elementi XML sottostanti e agli attributi, come identificatori di relazione, identificatori di elenco di un documento OOXML.|Yes|No|
|<p>Rendering:</p><p>- Renderizza le presentazioni in PDF, PDF Notes, XPS, immagini TIFF.</p><p>- Renderizza miniature delle diapositive in PNG, JPEG, BMP, SVG e TIFF.</p><p>- Specifica risoluzione dell'immagine, qualità, compressione e altre opzioni. </p>|No|Yes |
|Piattaforme supportate|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Conclusione**
{{% alert color="primary" %}} 

Open XML SDK e Aspose.Slides non competono direttamente perché rispondono a esigenze e pubblici molto diversi. Open XML SDK è una libreria di classi che fornisce un modo fortemente tipizzato per lavorare con i documenti OOXML. Aspose.Slides è una libreria di elaborazione delle presentazioni molto utile che offre un ottimo supporto per quasi tutti i formati di file Microsoft PowerPoint.

Se tutto ciò di cui hai bisogno è un'operazione di programmazione abbastanza semplice su un documento PPTX, allora Open XML SDK potrebbe essere una scelta adatta. Con Open XML SDK sarai abbastanza a tuo agio nell'eseguire compiti semplici come generare un documento PPTX semplice o rimuovere commenti, intestazioni/piedi pagina, estrarre immagini o altro. Alcuni compiti possono essere realizzati con Open XML SDK, ma non possono esserlo con Aspose.Slides. Per esempio, se devi accedere direttamente agli elementi XML e agli attributi di un documento OOXML, dovresti utilizzare Open XML SDK. Tuttavia, se devi eseguire operazioni complesse sui documenti, come alcune delle seguenti attività, allora utilizzare Aspose.Slides è la tua migliore opzione:

- Supportare formati PowerPoint più vecchi oltre a PPTX.
- Copiare o clonare forme nelle diapositive in modo che combinino oggetti, stili e altre formattazioni in maniera appropriata.
- Sostituire testo formattato o non formattato.
- Applicare animazioni e utilizzare connettori con le forme.
- Convertire un documento in PDF, TIFF o XPS in modo che appaia esattamente come farebbe Microsoft PowerPoint.
- Sviluppare un'applicazione .NET o Java sia in ambienti desktop che basati sul web.

{{% /alert %}}