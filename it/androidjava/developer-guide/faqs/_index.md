---
title: FAQ
type: docs
weight: 340
url: /it/androidjava/faqs/
keywords:
- FAQ
- formato presentazione
- errore di memoria
- dimensione diapositiva
- estrarre testo
- recuperare testo
- dimensione paragrafo
- formattazione tabelle
- font
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Ottieni le risposte alle FAQ su Aspose.Slides per Android tramite Java, coprendo il supporto per PowerPoint e OpenDocument, le indicazioni per l'installazione, la licenza e la risoluzione dei problemi."
---
## **Panoramica**

Questa FAQ fornisce risposte alle domande comuni su Aspose.Slides. Copre i formati file supportati, la gestione delle eccezioni durante il lavoro con presentazioni di grandi dimensioni, la modifica delle dimensioni delle diapositive, l'anteprima delle diapositive, il recupero del testo dalle presentazioni, la formattazione dei bordi delle tabelle, l'inserimento di immagini e la risoluzione dei problemi relativi ai font durante la conversione delle presentazioni in PDF o immagini.

## **Formati file supportati**

**Q:** Quali formati file supporta Aspose.Slides per Android via Java?

**A:** Aspose.Slides per Android via Java supporta i formati file descritti in [Formati file supportati](/slides/it/androidjava/supported-file-formats/).

## **Eccezioni**

**Q:** Sto ricevendo un'eccezione di memoria insufficiente durante il caricamento di un grande file PPT con immagini. Esiste una limitazione in Aspose.Slides riguardo alla dimensione del file?

**A:** Non esiste una formula specifica per calcolare la dimensione della presentazione supportata da Aspose.Slides. Deve esserci spazio sufficiente per ospitare l'intera struttura della presentazione e le immagini in memoria. Normalmente, le immagini in memoria occupano più spazio rispetto al disco rigido, specialmente quando le immagini hanno effetti aggiuntivi.

In generale, Aspose.Slides per Android via Java può gestire facilmente file di presentazione di circa 300 MB su un server con 4 GB di RAM.

## **Lavorare con le diapositive**

**Q:** Posso cambiare le dimensioni delle diapositive in una presentazione?

**A:** Puoi utilizzare il metodo `getSlideSize` esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) per definire le dimensioni delle diapositive in una presentazione.

**Q:** Esiste un modo per definire diapositive di dimensioni diverse in una presentazione?

**A:** Poiché la dimensione delle diapositive è definita a livello di presentazione nei documenti Microsoft PowerPoint, non è possibile farlo.

**Q:** Aspose.Slides per Android via Java supporta l'anteprima di una diapositiva prima del salvataggio?

**A:** Puoi renderizzare le diapositive della presentazione in immagini e utilizzare queste immagini per l'anteprima delle diapositive.

## **Lavorare con il testo**

**Q:** È possibile recuperare tutto il testo da una presentazione?

**A:** Aspose.Slides per Android via Java fornisce la classe [SlideUtil](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideutil/) che offre vari metodi per recuperare l'intero testo dalle presentazioni.

**Q:** Perché le dimensioni dei paragrafi sono diverse su PC e Android?

**A:** La calcolazione delle dimensioni dei paragrafi si basa sul calcolo della dimensione del testo che rappresenta il dato paragrafo. Il calcolo della dimensione del testo si basa sulle metriche del font specificato nella presentazione PowerPoint. Se il font specificato è mancante, viene sostituito con il font più simile, ma questo font ha metriche diverse da quelle originali. Di conseguenza, il calcolo delle dimensioni dei paragrafi su sistemi diversi porterà a risultati differenti a seconda del set di font installati. Per ottenere lo stesso risultato su diversi sistemi operativi, è necessario installare gli stessi font sui sistemi o caricarli a runtime come [font esterni](/slides/it/androidjava/custom-font/).

## **Formattazione e immagini**

**Q:** Come posso impostare il colore di un bordo della tabella?

**A:** Puoi cambiare il colore di tutti i bordi della tabella o solo il bordo attorno all'intera tabella. Per cambiare tutti i bordi, usa il metodo `getCellFormat` dell'interfaccia [ICell](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icell/). Per il bordo dell'intera tabella, dovresti iterare le celle e cambiare il colore dei bordi esterni.

**Q:** Quale unità di misura utilizza Aspose.Slides per Android via Java per posizionare le immagini?

**A:** Le coordinate e le dimensioni di tutte le forme sulle diapositive sono misurate in punti (72 dpi).

## **Lavorare con i font**

**Q:** Quando si converte un PPT in PDF o immagini, perché i font sono diversi nei documenti di output?

**A:** Questo problema potrebbe indicare che i font utilizzati nella presentazione sono mancanti sul sistema operativo su cui è stato eseguito il codice. Dovresti installare i font sul sistema operativo o caricarli come font esterni utilizzando la classe [FontsLoader](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/) come mostrato di seguito:
```java
String[] folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```