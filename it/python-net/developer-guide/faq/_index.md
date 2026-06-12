---
title: FAQ
type: docs
weight: 340
url: /it/python-net/faq/
keywords:
- FAQ
- formato della presentazione
- errore di memoria insufficiente
- dimensione diapositiva
- estrarre testo
- recuperare testo
- dimensione paragrafo
- formattazione tabelle
- font
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Ottieni risposte alle domande frequenti su Aspose.Slides per Python via .NET, coprendo il supporto a PowerPoint e OpenDocument, indicazioni d'installazione, licenze e risoluzione dei problemi."
---
## **Panoramica**

Questa FAQ fornisce risposte alle domande più comuni su Aspose.Slides. Copre i formati di file supportati, la gestione delle eccezioni quando si lavora con presentazioni di grandi dimensioni, la modifica delle dimensioni delle diapositive, l'anteprima delle diapositive, il recupero del testo dalle presentazioni, la formattazione dei bordi delle tabelle, l'inserimento delle immagini e la risoluzione dei problemi relativi ai font durante la conversione delle presentazioni in PDF o immagini.

## **Formati di file supportati**

**Q:** Quali formati di file supporta Aspose.Slides per Python via .NET?

**A:** Aspose.Slides per Python via .NET supporta i formati di file descritti in [Formati di file supportati](/slides/it/python-net/supported-file-formats/).

## **Eccezioni**

**Q:** Sto ricevendo un'eccezione di memoria insufficiente durante il caricamento di un grande file PPT con immagini. Esiste una limitazione in Aspose.Slides riguardo alle dimensioni del file?

**A:** Non esiste una formula specifica per calcolare la dimensione della presentazione supportata da Aspose.Slides. Deve esserci spazio sufficiente per contenere l'intera struttura della presentazione e le immagini in memoria. Normalmente, le immagini in memoria occupano più spazio rispetto al disco rigido, soprattutto quando le immagini hanno effetti aggiuntivi.

In generale, Aspose.Slides per Python via .NET può gestire facilmente file di presentazione di circa 300 MB su un server con 4 GB di RAM.

## **Lavorare con le diapositive**

**Q:** Posso modificare le dimensioni delle diapositive in una presentazione?

**A:** È possibile utilizzare la proprietà `slide_size` esposta dalla classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per definire le dimensioni delle diapositive in una presentazione.

**Q:** È possibile definire diapositive di dimensioni diverse in una presentazione?

**A:** Poiché le dimensioni delle diapositive sono definite a livello di presentazione nei documenti Microsoft PowerPoint, non è possibile farlo.

**Q:** Aspose.Slides per Python via .NET supporta l'anteprima di una diapositiva prima del salvataggio?

**A:** È possibile rendere le diapositive della presentazione in immagini e utilizzare queste immagini per l'anteprima delle diapositive.

## **Lavorare con il testo**

**Q:** È possibile recuperare tutto il testo da una presentazione?

**A:** Aspose.Slides per Python via .NET fornisce la classe [SlideUtil](https://reference.aspose.com/slides/it/python-net/aspose.slides.util/slideutil/) nello spazio dei nomi `aspose.slides.util` che offre vari metodi per recuperare l'intero testo dalle presentazioni.

**Q:** Perché le dimensioni dei paragrafi sono diverse su sistemi operativi Windows e Linux?

**A:** Il calcolo delle dimensioni dei paragrafi si basa sul calcolo della dimensione del testo che rappresenta il paragrafo dato. Il calcolo della dimensione del testo si basa sulle metriche del font specificato nella presentazione PowerPoint. Se il font specificato è mancante, viene sostituito con il font più simile, ma questo font ha metriche diverse da quelle originali. Di conseguenza, il calcolo delle dimensioni dei paragrafi su sistemi diversi porterà a risultati differenti a seconda del set di font installati. Per ottenere lo stesso risultato su sistemi operativi diversi, è necessario installare gli stessi font sui sistemi o caricarli a runtime come [font esterni](/slides/it/python-net/custom-font/).

## **Formattazione e immagini**

**Q:** Come posso impostare il colore del bordo di una tabella?

**A:** È possibile cambiare il colore di tutti i bordi della tabella o solo del bordo intorno all'intera tabella. Per cambiare tutti i bordi, utilizzare la proprietà `cell_format` della classe [Cell](https://reference.aspose.com/slides/it/python-net/aspose.slides/cell/). Per il bordo dell'intera tabella, è necessario iterare le celle e cambiare il colore dei bordi esterni.

**Q:** Quale unità di misura usa Aspose.Slides per Python via .NET per posizionare le immagini?

**A:** Le coordinate e le dimensioni di tutte le forme nelle diapositive sono misurate in punti (72 dpi).

## **Lavorare con i font**

**Q:** Durante la conversione da PPT a PDF o immagini, perché i font sono diversi nei documenti di output?

**A:** Questo problema potrebbe indicare che i font utilizzati nella presentazione mancano dal sistema operativo su cui è stato eseguito il codice. È necessario installare i font sul sistema operativo o caricarli come font esterni utilizzando la classe [FontsLoader](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsloader/) come mostrato di seguito:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```