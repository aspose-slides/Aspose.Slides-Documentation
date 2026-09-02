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

Questo articolo spiega quando gli sviluppatori potrebbero scegliere Open XML SDK o Aspose.Slides per lavorare con documenti di presentazione. Descrive Open XML SDK come una libreria per manipolare pacchetti OOXML e i relativi elementi XML sottostanti, mentre Aspose.Slides è presentato come una libreria di elaborazione delle presentazioni con un modello di oggetti di alto livello e supporto per molte attività legate a PowerPoint.

L'articolo confronta entrambe le opzioni per formato supportato, modello di programmazione, rendering, supporto piattaforma e casi d'uso comuni. Chiarisce inoltre che Open XML SDK può essere adatto per operazioni PPTX di base o per l'accesso diretto agli elementi OOXML, mentre Aspose.Slides è più indicato per attività di presentazione complesse come la gestione di più formati PowerPoint, la copia o la clonazione di forme, la sostituzione di testo, l'applicazione di animazioni e la conversione di presentazioni in PDF, TIFF o XPS.

## **Che cos'è Open XML SDK?**
A volte riceviamo questa domanda: *Perché dovremmo usare i prodotti Aspose anziché il gratuito Open XML SDK?* 

Ci risulta semplice rispondere a questa domanda in termini di funzionalità.

Secondo la [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK è definito così:

> "The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree, and working with XML elements and attributes directly, Open XML SDK provides classes to do that."

## **Che cos'è Aspose.Slides?**
Aspose.Slides è una libreria di classi che consente alle applicazioni di eseguire queste attività di elaborazione delle presentazioni:

- Programmazione con un modello di oggetti di presentazione.
- Conversioni di alta qualità che coinvolgono tutti i formati di presentazione PowerPoint più popolari, inclusa la conversione in PDF, XPS e TIFF.
- Generazione di miniature diapositive in formati noti come PNG, JPEG e BMP insieme all'esportazione delle diapositive in SVG.
- Creazione di presentazioni da zero o combinando elementi da uno o più documenti.
- Aggiunta di animazioni, OLE Frame, tabelle, creazione e gestione di grafici.
- Controllo (controllo estensivo) e gestione della formattazione del testo su livelli TextFrames, Paragraphs e Portions.

  Per ulteriori dettagli sulle funzionalità disponibili, consultare la pagina [Aspose.Slides Features](/slides/it/net/product-overview/).

## **Confronta Open XML SDK con Aspose.Slides**
Questa tabella confronta le capacità e le funzionalità di Open XML SDK con quelle di Aspose.Slides.

|**Funzionalità o Categoria di Funzionalità**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formati di presentazione supportati|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversione da PPT a PPTX|No|Sì|
|<p>Programmazione ad alto livello con un Presentation Document Object Model (DOM):</p><p>- Trova e sostituisci testi.</p><p>- Assembla diapositive nelle presentazioni.</p>|No|Sì|
|Programmazione dettagliata con un modello di oggetto documento; accesso a elementi individuali e formattazione come TextHolders, TextFrames, Paragraphs e Portions.|Sì|Sì|
|Accesso diretto a basso livello e completo agli elementi XML sottostanti e agli attributi, come identificatori di relazione e identificatori di elenco di un documento OOXML.|Sì|No|
|<p>Rendering della presentazione:</p><p>- Renderizza presentazioni in PDF, PDF Notes, XPS, immagini TIFF.</p><p>- Renderizza miniature diapositive in PNG, JPEG, BMP, SVG e TIFF.</p><p>- Specifica risoluzione immagine, qualità, compressione e altre opzioni.</p>|No|Sì|
|Piattaforme supportate|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Conclusione**
Open XML SDK e Aspose.Slides non competono direttamente perché rispondono a esigenze considerevolmente diverse e si rivolgono a pubblici differenti.

{{% alert color="info" %}} 

Open XML SDK è una libreria di classi che fornisce un modo tipizzato per lavorare con documenti OOXML, mentre Aspose.Slides è una libreria di elaborazione delle presentazioni incredibilmente utile che offre un eccellente supporto per quasi tutti i formati di file Microsoft PowerPoint. 

{{% /alert %}} 

Se il tuo flusso di lavoro è un'operazione di programmazione di base su un documento PPTX, allora Open XML SDK potrebbe essere una buona scelta. Con Open XML SDK dovresti sentirti a tuo agio nell'eseguire compiti semplici come generare un documento PPTX semplice o rimuovere commenti, intestazioni/piè di pagina, estrarre immagini o altri elementi. Alcuni compiti possono essere eseguiti con Open XML SDK ma non con Aspose.Slides. Per esempio, se hai bisogno di accedere direttamente agli elementi XML e agli attributi di un documento OOXML, allora dovresti usare Open XML SDK.

Se devi eseguire compiti complessi sui documenti—come quelli elencati di seguito— allora Aspose.Slides è la tua migliore opzione.

- Operazioni che coinvolgono formati PowerPoint più vecchi (e anche PPTX).
- Copia o clonazione di forme all'interno delle diapositive in modo da combinare oggetti, stili e altri elementi di formattazione in maniera appropriata.
- Sostituzione di testo formattato o non formattato.
- Applicazione di animazioni e utilizzo di connettori con le forme.
- Conversione di un documento in PDF, TIFF o XPS in modo che appaia come se Microsoft PowerPoint avesse eseguito la conversione.
- Sviluppo di un'applicazione .NET o Java sia in ambienti desktop che basati sul web.