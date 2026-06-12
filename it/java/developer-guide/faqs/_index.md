---
title: FAQ
type: docs
weight: 340
url: /it/java/faqs/
keywords:
- FAQ
- formato di presentazione
- errore di memoria insufficiente
- dimensione diapositiva
- estrarre testo
- recuperare testo
- dimensione paragrafo
- formattazione tabelle
- carattere
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Ottieni risposte alle domande frequenti su Aspose.Slides per Java, comprese le informazioni su supporto PowerPoint e OpenDocument, indicazioni di installazione, licenza e risoluzione dei problemi."
---
## **Panoramica**

Questa FAQ fornisce risposte alle domande più frequenti su Aspose.Slides. Copre i formati di file supportati, la gestione delle eccezioni quando si lavora con presentazioni di grandi dimensioni, la modifica delle dimensioni delle diapositive, l'anteprima delle diapositive, il recupero del testo dalle presentazioni, la formattazione dei bordi delle tabelle, l'inserimento di immagini e la risoluzione dei problemi relativi ai caratteri durante la conversione delle presentazioni in PDF o immagini.

## **Formati di file supportati**

**D:** Quali formati di file supporta Aspose.Slides per Java?

**R:** Aspose.Slides per Java supporta i formati di file descritti in [Formati di file supportati](/slides/it/java/supported-file-formats/).

## **Eccezioni**

**D:** Sto ottenendo un'eccezione OutOfMemoryException durante il caricamento di un grande file PPT con immagini. Esiste una limitazione in Aspose.Slides riguardo alla dimensione del file?

**R:** Non esiste una formula specifica per calcolare la dimensione della presentazione supportata da Aspose.Slides. Deve esserci spazio sufficiente per ospitare l'intera struttura della presentazione e le immagini in memoria. Normalmente, le immagini in memoria occupano più spazio rispetto al disco rigido, soprattutto quando le immagini hanno effetti aggiuntivi.

In generale, Aspose.Slides per Java può gestire facilmente file di presentazione di circa 300 MB su un server con 4 GB di RAM.

## **Lavorare con le diapositive**

**D:** Posso modificare la dimensione delle diapositive in una presentazione?

**R:** È possibile utilizzare il metodo `getSlideSize` esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) per definire la dimensione delle diapositive in una presentazione.

**D:** È possibile definire diapositive di dimensioni diverse all'interno della stessa presentazione?

**R:** Poiché la dimensione delle diapositive è definita a livello di presentazione nei documenti Microsoft PowerPoint, non è possibile farlo.

**D:** Aspose.Slides per Java supporta l'anteprima di una diapositiva prima del salvataggio?

**R:** È possibile renderizzare le diapositive della presentazione in immagini e utilizzare queste immagini per l'anteprima delle diapositive.

## **Lavorare con il testo**

**D:** È possibile recuperare tutto il testo da una presentazione?

**R:** Aspose.Slides per Java fornisce la classe [SlideUtil](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideutil/) che offre vari metodi per recuperare l'intero testo dalle presentazioni.

**D:** Perché le dimensioni dei paragrafi differiscono tra i sistemi operativi Windows e Linux?

**R:** Il calcolo delle dimensioni dei paragrafi si basa sul calcolo della dimensione del testo che rappresenta il paragrafo dato. Il calcolo della dimensione del testo si fonda sulle metriche del carattere specificato nella presentazione PowerPoint. Se il carattere specificato è mancante, viene sostituito con il carattere più simile, ma questo carattere ha metriche diverse da quelle originali. Di conseguenza, il calcolo delle dimensioni dei paragrafi su sistemi diversi produrrà risultati differenti a seconda del set di caratteri installati. Per ottenere lo stesso risultato su sistemi operativi diversi, è necessario installare gli stessi caratteri sui sistemi o caricarli a runtime come [caratteri esterni](/slides/it/java/custom-font/).

## **Formattazione e immagini**

**D:** Come posso impostare il colore del bordo di una tabella?

**R:** È possibile modificare il colore di tutti i bordi della tabella oppure solo il bordo attorno all'intera tabella. Per modificare tutti i bordi, utilizzare il metodo `getCellFormat` dell'interfaccia [ICell](https://reference.aspose.com/slides/it/java/com.aspose.slides/icell/). Per il bordo dell'intera tabella, è necessario iterare le celle e cambiare il colore dei bordi esterni.

**D:** Quale unità di misura utilizza Aspose.Slides per Java per posizionare le immagini?

**R:** Le coordinate e le dimensioni di tutte le forme sulle diapositive sono misurate in punti (72 dpi).

## **Lavorare con i caratteri**

**D:** Quando converto un PPT in PDF o immagini, perché i caratteri risultano diversi nei documenti di output?

**R:** Questo problema potrebbe indicare che i caratteri utilizzati nella presentazione sono assenti dal sistema operativo su cui è stato eseguito il codice. È necessario installare i caratteri sul sistema operativo o caricarli come caratteri esterni utilizzando la classe [FontsLoader](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/) come mostrato di seguito:
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```