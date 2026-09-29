---
title: Perché non Open XML SDK
type: docs
weight: 180
url: /it/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- confronto
- modello di oggetto di presentazione
- conversione di alta qualità
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri perché Aspose.Slides è una scelta migliore rispetto al gratuito Open XML SDK: confronta le funzionalità, la conversione senza automazione e il supporto esteso per PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega quando gli sviluppatori potrebbero scegliere Open XML SDK o Aspose.Slides per lavorare con documenti di presentazione. Descrive Open XML SDK come una libreria per la manipolazione di pacchetti OOXML e dei relativi elementi XML, mentre Aspose.Slides è presentato come una libreria di elaborazione delle presentazioni con un modello ad oggetti di alto livello e supporto per molte attività legate a PowerPoint.

L'articolo confronta entrambe le opzioni per formati supportati, modello di programmazione, rendering, supporto della piattaforma e casi d'uso comuni. Chiarisce inoltre che Open XML SDK può essere adatto per operazioni PPTX di base o per l'accesso diretto agli elementi OOXML, mentre Aspose.Slides è più appropriato per compiti complessi come la gestione di più formati PowerPoint, la copia o clonazione di forme, la sostituzione di testo, l'applicazione di animazioni e la conversione di presentazioni in PDF, TIFF o XPS.

## **Che cos'è Open XML SDK?**
Secondo la [Libreria MSDN](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK è definito come:

> L'Open XML SDK 2.0 semplifica il compito di manipolare pacchetti Open XML e gli elementi dello schema Open XML sottostanti all'interno di un pacchetto. L'Open XML SDK 2.0 incapsula molte attività comuni che gli sviluppatori eseguono sui pacchetti Open XML, così da poter eseguire operazioni complesse con poche righe di codice.
>
> I documenti OOXML sono essenzialmente file XML compressi e Open XML SDK è una raccolta di classi che consente di lavorare con il contenuto dei documenti OOXML in modo fortemente tipizzato. Invece di decomprimere un file per estrarre XML, caricare quel XML in un albero DOM e lavorare direttamente con gli elementi e gli attributi XML, Open XML SDK fornisce classi per fare ciò.

## **Che cos'è Aspose.Slides?**
Aspose.Slides è una libreria di classi che consente alla tua applicazione di eseguire le seguenti attività di elaborazione delle presentazioni:

- Programmazione con un modello di oggetti **Presentation**.
- Conversioni di alta qualità tra tutti i formati di presentazione PowerPoint supportati, inclusa la conversione in PDF, XPS e TIFF.
- Capacità di generare miniature delle diapositive in formati noti come PNG, JPEG e BMP, oltre all'esportazione della diapositiva in SVG.
- Capacità di creare presentazioni da zero o combinando una o più documenti.
- Supporto per l'aggiunta di animazioni, Ole Frames, Tabelle, creazione e gestione di grafici.
- Disponibilità di un controllo esteso per la gestione della formattazione del testo su TextFrames, Paragraphs e Portions.

Per ulteriori dettagli sulle funzionalità supportate, visita [Aspose.Slides Features](/slides/it/java/product-overview/).

## **Confronta Open XML SDK con Aspose.Slides**
{{% alert color="info" title="Note" %}}
La seguente tabella confronta le funzionalità di Open XML SDK e Aspose.Slides.
{{% /alert %}}

|**Funzione o Categoria di Funzione**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formati di presentazione supportati|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversione da PPT a PPTX|No|Sì|
|<p>Programmazione di alto livello con un Presentation Document Object Model (DOM):</p><p>- Trova e sostituisci testo.</p><p>- Assembla diapositive in presentazioni.</p>|No|Sì|
|Programmazione dettagliata con un modello di oggetti documento, accesso a singoli elementi e formattazione come TextHolders, TextFrames, Paragraphs e Portions.|Sì|Sì|
|Accesso diretto e completo a basso livello agli elementi XML e agli attributi sottostanti, come identificatori di relazione e identificatori di elenco di un documento OOXML.|Sì|No|
|<p>Rendering:</p><p>- Renderizza presentazioni in PDF, PDF Notes, XPS, immagini TIFF.</p><p>- Renderizza miniature diapositive in PNG, JPEG, BMP, SVG e TIFF.</p><p>- Specifica risoluzione immagine, qualità, compressione e altre opzioni.</p>|No|Sì |
|Piattaforme supportate|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Conclusione**
{{% alert color="info" title="Note" %}}
Open XML SDK e Aspose.Slides non sono in concorrenza diretta perché rispondono a esigenze e pubblici molto diversi. Open XML SDK è una libreria di classi che fornisce un modo fortemente tipizzato per lavorare con documenti OOXML. Aspose.Slides è una libreria di elaborazione delle presentazioni molto utile che offre un eccellente supporto per quasi tutti i formati di file Microsoft PowerPoint.

Se tutto ciò di cui hai bisogno è un'operazione di programmazione abbastanza basica su un documento PPTX, allora Open XML SDK potrebbe essere la scelta adeguata. Con Open XML SDK sarai a tuo agio per compiti semplici come generare un documento PPTX basilare, rimuovere commenti, intestazioni/piedi di pagina, estrarre immagini o simili. Alcuni compiti possono essere realizzati con Open XML SDK, ma non con Aspose.Slides. Per esempio, se devi accedere direttamente agli elementi XML e agli attributi di un documento OOXML, dovresti usare Open XML SDK. Tuttavia, se devi eseguire operazioni complesse sui documenti, come alcune delle seguenti attività, allora usare Aspose.Slides è la tua migliore opzione:

- Supportare formati PowerPoint più vecchi oltre a PPTX.
- Copiare o clonare forme all'interno delle diapositive in modo da combinare oggetti, stili e altre formattazioni in maniera appropriata.
- Sostituire testo formattato o non formattato.
- Applicare animazioni e utilizzare connettori con le forme.
- Convertire un documento in PDF, TIFF o XPS affinché appaia esattamente come farebbe Microsoft PowerPoint.
- Sviluppare un'applicazione .NET o Java sia in ambienti desktop che basati sul web.
{{% /alert %}}