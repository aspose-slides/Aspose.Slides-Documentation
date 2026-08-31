---
title: Perché non Open XML SDK
type: docs
weight: 120
url: /it/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- confronto
- modello oggetto presentazione
- conversione ad alta qualità
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri perché Aspose.Slides è una scelta migliore rispetto al gratuito Open XML SDK: confronta le funzionalità, la conversione senza automazione e l'ampio supporto per PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega quando gli sviluppatori potrebbero scegliere Open XML SDK o Aspose.Slides per lavorare con documenti di presentazione. Descrive Open XML SDK come una libreria per manipolare pacchetti OOXML e i relativi elementi XML sottostanti, mentre Aspose.Slides è presentato come una libreria di elaborazione delle presentazioni con un modello di oggetto di alto livello e supporto per molte attività legate a PowerPoint.

L'articolo confronta entrambe le opzioni per formati supportati, modello di programmazione, rendering, supporto piattaforme e casi d'uso comuni. Inoltre chiarisce che Open XML SDK può essere adatto per operazioni PPTX di base o per l'accesso diretto agli elementi OOXML, mentre Aspose.Slides è più appropriato per attività di presentazione complesse come la gestione di più formati PowerPoint, la copia o clonazione di forme, la sostituzione di testo, l'applicazione di animazioni e la conversione delle presentazioni in PDF, TIFF o XPS.

## **Che cos'è Open XML SDK?**
Secondo la [Libreria MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK è definito così: 

Il Open XML SDK 2.0 semplifica il compito di manipolare pacchetti Open XML e gli elementi dello schema Open XML sottostanti a un pacchetto. Il Open XML SDK 2.0 incapsula molte attività comuni che gli sviluppatori eseguono sui pacchetti Open XML, in modo da poter eseguire operazioni complesse con poche righe di codice.

I documenti OOXML sono essenzialmente file XML compressi e Open XML SDK è una raccolta di classi che permette di lavorare con il contenuto dei documenti OOXML in modo tipizzato. Invece di decomprimere un file per estrarre XML, caricare quell'XML in un albero DOM e lavorare direttamente con elementi e attributi XML, Open XML SDK fornisce classi per farlo.

## **Che cos'è Aspose.Slides?**
Aspose.Slides è una libreria di classi che consente alla tua applicazione di eseguire le seguenti attività di elaborazione delle presentazioni:

- Programmazione con un modello di oggetto **Presentation**.
- Conversioni di alta qualità tra tutti i formati di presentazione PowerPoint supportati, inclusa la conversione in PDF, XPS e TIFF.
- Possibilità di generare miniature delle diapositive in formati ben noti come PNG, JPEG e BMP insieme all'esportazione della diapositiva in SVG.
- Possibilità di creare presentazioni da zero o combinando una o più documenti.
- Supporto per l'aggiunta di animazioni, Ole Frames, Tabelle, creazione e gestione di grafici.
- Disponibilità di un controllo esteso per la gestione della formattazione del testo su TextFrames, Paragraphs e Portions.

Per maggiori dettagli sulle funzionalità supportate, visita [Caratteristiche di Aspose.Slides](/slides/it/java/product-overview/).

## **Confronta Open XML SDK con Aspose.Slides**
{{% alert color="info" %}} 

La tabella seguente confronta le funzionalità di Open XML SDK e Aspose.Slides.

{{% /alert %}} 

|**Caratteristica o Categoria**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formati di presentazione supportati|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversione da PPT a PPTX|No|Sì|
|<p>Programmazione di alto livello con un modello di oggetto documento di presentazione (DOM):</p><p>- Trova e sostituisci testo.</p><p>- Assembla diapositive in presentazioni.</p>|No|Sì|
|Programmazione dettagliata con un modello di oggetto documento, accesso a elementi individuali e formattazione come TextHolders, TextFrames, Paragraphs e Portions.|Sì|Sì|
|Accesso diretto e completo a basso livello agli elementi XML e agli attributi sottostanti, come identificatori di relazione, identificatori di elenco di un documento OOXML.|Sì|No|
|<p>Rendering:</p><p>- Renderizza presentazioni in PDF, PDF Notes, XPS, immagini TIFF.</p><p>- Renderizza miniature di diapositive in PNG, JPEG, BMP, SVG e TIFF.</p><p>- Specifica risoluzione immagine, qualità, compressione e altre opzioni.</p>|No|Sì |
|Piattaforme supportate|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Conclusione**
{{% alert color="info" %}} 

Open XML SDK e Aspose.Slides non competono direttamente perché rispondono a esigenze e pubblici molto diversi. Open XML SDK è una libreria di classi che fornisce un modo tipizzato per lavorare con i documenti OOXML. Aspose.Slides è una libreria di elaborazione delle presentazioni molto utile che offre un ampio supporto per quasi tutti i formati di file Microsoft PowerPoint.

Se tutto ciò che devi fare è un'operazione di programmazione piuttosto elementare su un documento PPTX, allora Open XML SDK potrebbe essere una scelta adeguata. Con Open XML SDK potrai eseguire comodamente compiti semplici come generare un documento PPTX di base o rimuovere commenti, intestazioni/piedi di pagina, estrarre immagini o altro. Alcune attività possono essere realizzate con Open XML SDK, ma non con Aspose.Slides. Per esempio, se devi accedere direttamente agli elementi e agli attributi XML di un documento OOXML, dovresti usare Open XML SDK. Tuttavia, se devi eseguire operazioni complesse sui documenti, come alcune delle seguenti attività, allora Aspose.Slides è l'opzione migliore:

- Supportare formati PowerPoint più vecchi oltre a PPTX.
- Copiare o clonare forme all'interno delle diapositive in modo che combinino oggetti, stili e altra formattazione in maniera appropriata.
- Sostituire testo formattato o non formattato.
- Applicare animazioni e utilizzare connettori con le forme.
- Convertire un documento in PDF, TIFF o XPS in modo che appaia esattamente come verrebbe convertito da Microsoft PowerPoint.
- Sviluppare un'applicazione .NET o Java sia in ambienti desktop che web.

{{% /alert %}}