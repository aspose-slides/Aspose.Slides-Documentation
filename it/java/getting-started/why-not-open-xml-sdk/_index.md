---
title: Perché non Open XML SDK
type: docs
weight: 120
url: /it/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- confronto
- modello di oggetto di presentazione
- conversione ad alta qualità
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri perché Aspose.Slides è una scelta migliore rispetto al gratuito Open XML SDK: confronta le funzionalità, la conversione senza automazione e il ampio supporto per PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega quando gli sviluppatori potrebbero scegliere Open XML SDK o Aspose.Slides per lavorare con documenti di presentazione. Descrive Open XML SDK come una libreria per manipolare pacchetti OOXML e i relativi elementi XML sottostanti, mentre Aspose.Slides è presentato come una libreria di elaborazione delle presentazioni con un modello ad oggetti di alto livello e supporto per molte attività legate a PowerPoint.

L'articolo confronta entrambe le opzioni per formati supportati, modello di programmazione, capacità di rendering e stampa, supporto della piattaforma e casi d'uso comuni. Inoltre chiarisce che Open XML SDK può essere adatto per operazioni PPTX di base o per l'accesso diretto agli elementi OOXML, mentre Aspose.Slides è più appropriato per attività complesse di presentazione come lavorare con più formati PowerPoint, copiare o clonare forme, sostituire testo, applicare animazioni e convertire le presentazioni in PDF, TIFF o XPS.

## **Che cos'è Open XML SDK?**
Secondo la [Libreria MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK è definito così:

L'Open XML SDK 2.0 semplifica il compito di manipolare pacchetti Open XML e gli elementi dello schema Open XML sottostanti a un pacchetto. L'Open XML SDK 2.0 incapsula molte attività comuni che gli sviluppatori eseguono sui pacchetti Open XML, in modo da poter eseguire operazioni complesse con solo poche righe di codice.

I documenti OOXML sono essenzialmente file XML compressi e Open XML SDK è una raccolta di classi che consente di lavorare con il contenuto dei documenti OOXML in modo tipizzato. Invece di decomprimere un file per estrarre XML, caricare quel XML in un albero DOM e lavorare direttamente con gli elementi e gli attributi XML, Open XML SDK fornisce classi per farlo.

## **Che cos'è Aspose.Slides?**
Aspose.Slides è una libreria di classi che permette alla tua applicazione di eseguire le seguenti attività di elaborazione delle presentazioni:

- Programmazione con un modello a oggetti **Presentation**.
- Conversioni di alta qualità tra tutti i formati di presentazione PowerPoint supportati, inclusa la conversione in PDF, XPS e TIFF.
- Capacità di generare miniature delle diapositive in formati noti come PNG, JPEG e BMP, oltre all'esportazione della diapositiva in SVG.
- Possibilità di creare presentazioni da zero o combinando uno o più documenti.
- Supporto per l'aggiunta di animazioni, Ole Frames, tabelle, creazione e gestione di grafici.
- Disponibilità di un controllo esteso per la gestione della formattazione del testo su TextFrames, Paragraphs e Portions.

Per ulteriori dettagli sulle funzionalità supportate, visita [Funzionalità di Aspose.Slides](/slides/it/java/product-overview/).

## **Confronta Open XML SDK con Aspose.Slides**
{{% alert color="primary" %}} 

La tabella seguente confronta le funzionalità di Open XML SDK e Aspose.Slides.

{{% /alert %}} 

|**Caratteristica o Categoria**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formati di presentazione supportati|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversione da PPT a PPTX|No|Sì|
|<p>Programmazione di alto livello con un modello a oggetti del documento di presentazione (DOM):</p><p>- Trova e sostituisci testo.</p><p>- Assembla diapositive nelle presentazioni.</p>|No|Sì|
|Programmazione dettagliata con un modello a oggetti del documento, accesso a singoli elementi e formattazione come TextHolders, TextFrames, Paragraphs e Portions.|Sì|Sì|
|Accesso diretto e completo a basso livello agli elementi XML sottostanti e agli attributi, come gli identificatori di relazione e gli identificatori di elenco di un documento OOXML.|Sì|No|
|<p>Rendering:</p><p>- Renderizza le presentazioni in PDF, PDF Notes, XPS, immagini TIFF.</p><p>- Renderizza miniature delle diapositive in PNG, JPEG, BMP, SVG e TIFF.</p><p>- Specifica risoluzione dell'immagine, qualità, compressione e altre opzioni.</p>|No|Sì |
|Piattaforme supportate|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Conclusione**
{{% alert color="primary" %}} 

Open XML SDK e Aspose.Slides non competono testa a testa perché rispondono a esigenze e pubblici molto diversi. Open XML SDK è una libreria di classi che fornisce un modo tipizzato per lavorare con i documenti OOXML. Aspose.Slides è una libreria di elaborazione delle presentazioni molto utile che offre un grande supporto per quasi tutti i formati di file Microsoft PowerPoint.

Se tutto ciò che ti serve è un'operazione di programmazione abbastanza basilare su un documento PPTX, allora Open XML SDK potrebbe essere una scelta adeguata. Con Open XML SDK potrai gestire agevolmente attività semplici come generare un documento PPTX semplice o rimuovere commenti, intestazioni/piè di pagina, estrarre immagini o altro. Alcune attività possono essere realizzate con Open XML SDK, ma non con Aspose.Slides. Per esempio, se devi accedere direttamente agli elementi e agli attributi XML di un documento OOXML, dovresti utilizzare Open XML SDK. Tuttavia, se devi eseguire operazioni complesse sui documenti, come alcune delle seguenti attività, allora usare Aspose.Slides è la tua migliore opzione:

- Supporto per i formati PowerPoint più vecchi oltre a PPTX.
- Copiare o clonare forme all'interno delle diapositive in modo che combinino oggetti, stili e altra formattazione in maniera appropriata.
- Sostituire testo formattato o non formattato.
- Applicare animazioni e utilizzare connettori con le forme.
- Convertire un documento in PDF, TIFF o XPS così da apparire esattamente come lo convertirebbe Microsoft PowerPoint.
- Sviluppare un'applicazione .NET o Java sia in ambienti desktop sia web.

{{% /alert %}}