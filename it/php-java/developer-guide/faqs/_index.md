---
title: FAQ
type: docs
weight: 340
url: /it/php-java/faqs/
keywords:
- FAQ
- formato presentazione
- errore memoria esaurita
- dimensione diapositiva
- estrarre testo
- recuperare testo
- dimensione paragrafo
- formattazione tabelle
- font
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Ottieni le risposte alle FAQ su Aspose.Slides per PHP via Java, che coprono il supporto per PowerPoint e OpenDocument, le indicazioni di installazione, la licenza e la risoluzione dei problemi."
---
## **Panoramica**

Questa FAQ fornisce risposte alle domande più comuni su Aspose.Slides. Copre i formati di file supportati, la gestione delle eccezioni quando si lavora con presentazioni di grandi dimensioni, la modifica delle dimensioni delle diapositive, l'anteprima delle diapositive, il recupero del testo dalle presentazioni, la formattazione dei bordi delle tabelle, l'inserimento di immagini e la risoluzione di problemi relativi ai caratteri durante la conversione di presentazioni in PDF o immagini.

## **Formati di file supportati**

**Q: Quali formati di file supporta Aspose.Slides per PHP via Java?**

**A**: Aspose.Slides per PHP via Java supporta i formati di file descritti in [Supported File Formats](/slides/it/php-java/supported-file-formats/).

## **Eccezioni**

**Q: Sto ricevendo un'eccezione out of memory durante il caricamento di un file PPT di grandi dimensioni con immagini. Esiste una limitazione di Aspose.Slides riguardo alla dimensione del file?**

**A**: Non esiste una formula specifica per calcolare la dimensione della presentazione supportata da Aspose.Slides. Deve esserci spazio sufficiente per contenere l'intera struttura della presentazione e le immagini in memoria. Normalmente, le immagini in memoria occupano più spazio rispetto al disco rigido, specialmente quando le immagini hanno effetti aggiuntivi.

In generale, Aspose.Slides per PHP via Java può gestire facilmente file di presentazione di circa 300 MB su un server con 4 GB di RAM.

## **Lavorare con le diapositive**

**Q: Posso modificare le dimensioni delle diapositive in una presentazione?**

**A**: È possibile utilizzare il metodo `getSlideSize` esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) per definire le dimensioni delle diapositive in una presentazione.

**Q: È possibile definire diapositive di dimensioni diverse nella stessa presentazione?**

**A**: Poiché le dimensioni delle diapositive sono definite a livello di presentazione nei documenti Microsoft PowerPoint, non è possibile farlo.

**Q: Aspose.Slides per PHP via Java supporta l'anteprima di una diapositiva prima del salvataggio?**

**A**: È possibile renderizzare le diapositive della presentazione in immagini e utilizzare queste immagini per l'anteprima delle diapositive.

## **Lavorare con il testo**

**Q: È possibile recuperare tutto il testo da una presentazione?**

**A**: Aspose.Slides per PHP via Java fornisce la classe [SlideUtil](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideutil/) che offre vari metodi per recuperare l'intero testo dalle presentazioni.

**Q: Perché le dimensioni dei paragrafi sono diverse su sistemi operativi Windows e Linux?**

**A**: Il calcolo delle dimensioni dei paragrafi si basa sul calcolo della dimensione del testo che rappresenta il paragrafo dato. Il calcolo della dimensione del testo si basa sulle metriche del carattere specificato nella presentazione PowerPoint. Se il carattere specificato è mancante, viene sostituito con il carattere più simile, ma questo carattere ha metriche diverse da quelle originali. Di conseguenza, il calcolo delle dimensioni dei paragrafi su sistemi diversi produrrà risultati differenti a seconda del set di caratteri installati. Per ottenere lo stesso risultato su diversi sistemi operativi, è necessario installare gli stessi caratteri sui sistemi o caricarli a runtime come [external fonts](/slides/it/php-java/custom-font/).

## **Formattazione e immagini**

**Q: Come posso impostare il colore di un bordo di tabella?**

**A**: È possibile cambiare il colore di tutti i bordi della tabella o solo del bordo esterno dell'intera tabella. Per modificare tutti i bordi, utilizzare il metodo `getCellFormat` della classe [Cell](https://reference.aspose.com/slides/it/php-java/aspose.slides/cell/). Per il bordo dell'intera tabella, è necessario iterare le celle e modificare il colore dei bordi esterni.

**Q: Quale unità di misura utilizza Aspose.Slides per PHP via Java per posizionare le immagini?**

**A**: Le coordinate e le dimensioni di tutte le forme sulle diapositive sono misurate in punti (72 dpi).

## **Lavorare con i font**

**Q: Quando converto PPT in PDF o immagini, perché i font risultano diversi nei documenti di output?**

**A**: Questo problema potrebbe indicare che i font utilizzati nella presentazione sono assenti dal sistema operativo su cui è stato eseguito il codice. È necessario installare i font sul sistema operativo o caricarli come font esterni utilizzando la classe [FontsLoader](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsloader/) come mostrato di seguito:
```php
$folders = ["path_to_a_folder_with_fonts"];
FontsLoader::loadExternalFonts($folders);
```