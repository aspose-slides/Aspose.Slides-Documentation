---
title: FAQ
type: docs
weight: 340
url: /it/net/faqs/
keywords:
- FAQ
- PowerPoint
- formato presentazione
- errore di memoria insufficiente
- dimensione diapositiva
- estrarre testo
- recuperare testo
- dimensione paragrafo
- formattazione tabelle
- font
- .NET
- C#
- Aspose.Slides
description: "Ottieni risposte alle domande frequenti su Aspose.Slides per .NET, includendo il supporto a PowerPoint e OpenDocument, indicazioni sull'installazione, licenze e risoluzione dei problemi."
---
## **Panoramica**

Questa FAQ fornisce risposte alle domande più comuni su Aspose.Slides. Copre i formati file supportati, la gestione delle eccezioni quando si lavora con presentazioni di grandi dimensioni, la modifica delle dimensioni delle diapositive, l'anteprima delle diapositive, il recupero del testo dalle presentazioni, la formattazione dei bordi delle tabelle, l'inserimento di immagini e la risoluzione dei problemi relativi ai font quando si convertono presentazioni in PDF o immagini.

## **Formati file supportati**

**D:** Quali formati file supporta Aspose.Slides per .NET?  

**R:** Aspose.Slides per .NET supporta i formati file descritti in [Supported File Formats](/slides/it/net/supported-file-formats/).

## **Eccezioni**

**D:** Sto ricevendo un'OutOfMemoryException durante il caricamento di un file PPT di grandi dimensioni con immagini. Esiste una limitazione in Aspose.Slides riguardo alla dimensione dei file?  

**R:** Non esiste una formula specifica per calcolare la dimensione della presentazione supportata da Aspose.Slides. Deve esserci spazio sufficiente per contenere l'intera struttura della presentazione e le immagini in memoria. Normalmente, le immagini in memoria occupano più spazio rispetto al disco rigido, specialmente quando le immagini hanno effetti aggiuntivi.  

In generale, Aspose.Slides per .NET può gestire facilmente file di presentazione di circa 300 MB su un server con 4 GB di RAM.

## **Lavorare con le diapositive**

**D:** Posso modificare le dimensioni delle diapositive in una presentazione?  

**R:** È possibile utilizzare la proprietà `SlideSize` esposta dalla classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) per definire le dimensioni delle diapositive in una presentazione.

**D:** Esiste un modo per definire diapositive di dimensioni diverse in una presentazione?  

**R:** Poiché le dimensioni delle diapositive sono definite a livello di presentazione nei documenti Microsoft PowerPoint, non è possibile farlo.

**D:** Aspose.Slides per .NET supporta l'anteprima di una diapositiva prima di salvarla?  

**R:** È possibile renderizzare le diapositive della presentazione in immagini e utilizzare queste immagini per l'anteprima delle diapositive.

## **Lavorare con il testo**

**D:** È possibile recuperare tutto il testo da una presentazione?  

**R:** Aspose.Slides per .NET fornisce la classe [SlideUtil](https://reference.aspose.com/slides/it/net/aspose.slides.util/slideutil/) nello spazio dei nomi `Aspose.Slides.Util` che offre vari metodi per recuperare l'intero testo dalle presentazioni.

**D:** Perché le dimensioni dei paragrafi sono diverse su Windows e Linux?  

**R:** Il calcolo delle dimensioni dei paragrafi si basa sul calcolo della dimensione del testo che rappresenta il paragrafo dato. Il calcolo della dimensione del testo si fonda sulle metriche del font specificato nella presentazione PowerPoint. Se il font specificato è mancante, viene sostituito con il font più simile, ma questo font ha metriche diverse da quelle originali. Di conseguenza, il calcolo delle dimensioni dei paragrafi su sistemi diversi porterà a risultati differenti a seconda del set di font installati. Per ottenere lo stesso risultato su diversi sistemi operativi, è necessario installare gli stessi font sui sistemi o caricarli a runtime come [external fonts](/slides/it/net/custom-font/).

## **Formattazione e immagini**

**D:** Come posso impostare il colore del bordo di una tabella?  

**R:** È possibile modificare il colore di tutti i bordi della tabella o solo del bordo intorno all'intera tabella. Per modificare tutti i bordi, utilizzare la proprietà `CellFormat` dell'interfaccia [ICell](https://reference.aspose.com/slides/it/net/aspose.slides/icell/). Per il bordo dell'intera tabella, occorre iterare le celle e modificare il colore dei bordi esterni.

**D:** Quale unità di misura utilizza Aspose.Slides per .NET per posizionare le immagini?  

**R:** Le coordinate e le dimensioni di tutte le forme sulle diapositive sono misurate in punti (72 dpi).

## **Lavorare con i font**

**D:** Quando si converte un PPT in PDF o immagini, perché i font sono diversi nei documenti di output?  

**R:** Questo problema potrebbe indicare che i font utilizzati nella presentazione sono assenti dal sistema operativo su cui è stato eseguito il codice. È necessario installare i font sul sistema operativo o caricarli come font esterni utilizzando la classe [FontsLoader](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/) come mostrato di seguito:
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```