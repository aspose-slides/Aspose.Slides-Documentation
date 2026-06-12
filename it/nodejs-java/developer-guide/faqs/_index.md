---
title: FAQ
type: docs
weight: 340
url: /it/nodejs-java/faqs/
keywords:
- FAQ
- formato presentazione
- errore out of memory
- dimensione diapositiva
- estrarre testo
- recuperare testo
- dimensione paragrafo
- formattazione tabelle
- font
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Ottieni risposte alle FAQ su Aspose.Slides per Node.js via Java, coprendo il supporto per PowerPoint e OpenDocument, indicazioni sull'installazione, licenza e risoluzione dei problemi."
---
## **Panoramica**

Questa FAQ fornisce risposte alle domande più comuni su Aspose.Slides. Copre i formati di file supportati, la gestione delle eccezioni quando si lavora con presentazioni di grandi dimensioni, la modifica delle dimensioni delle diapositive, l'anteprima delle diapositive, il recupero del testo dalle presentazioni, la formattazione dei bordi delle tabelle, l'inserimento di immagini e la risoluzione di problemi relativi ai font durante la conversione delle presentazioni in PDF o immagini.

## **Formati di file supportati**

**Q: Quali formati di file supporta Aspose.Slides per Node.js via Java?**

**A**: Aspose.Slides per Node.js via Java supporta i formati di file descritti in [Formati di file supportati](/slides/it/nodejs-java/supported-file-formats/).

## **Eccezioni**

**Q: Ottengo un'eccezione di out of memory durante il caricamento di un grande file PPT con immagini. Esiste una limitazione in Aspose.Slides riguardo alle dimensioni del file?**

**A**: Non esiste una formula specifica per calcolare la dimensione della presentazione supportata da Aspose.Slides. Deve esserci spazio sufficiente per contenere l'intera struttura della presentazione e le immagini in memoria. Normalmente, le immagini in memoria occupano più spazio rispetto al disco rigido, soprattutto quando le immagini hanno effetti aggiuntivi.

In generale, Aspose.Slides per Node.js via Java può gestire facilmente file di presentazione di circa 300 MB su un server con 4 GB di RAM.

## **Lavorare con le diapositive**

**Q: Posso modificare le dimensioni delle diapositive in una presentazione?**

**A**: È possibile utilizzare il metodo `getSlideSize` esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) per definire le dimensioni delle diapositive in una presentazione.

**Q: È possibile definire diapositive di dimensioni diverse in una presentazione?**

**A**: Poiché le dimensioni delle diapositive sono definite a livello di presentazione nei documenti Microsoft PowerPoint, non è possibile farlo.

**Q: Aspose.Slides per Node.js via Java supporta l'anteprima di una diapositiva prima del salvataggio?**

**A**: È possibile renderizzare le diapositive della presentazione in immagini e utilizzare queste immagini per l'anteprima delle diapositive.

## **Lavorare con il testo**

**Q: È possibile recuperare tutto il testo da una presentazione?**

**A**: Aspose.Slides per Node.js via Java fornisce la classe [SlideUtil](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideutil/) che offre vari metodi per recuperare l'intero testo dalle presentazioni.

**Q: Perché le dimensioni dei paragrafi sono diverse sui sistemi operativi Windows e Linux?**

**A**: Il calcolo delle dimensioni dei paragrafi si basa sul calcolo della dimensione del testo che rappresenta il relativo paragrafo. Il calcolo della dimensione del testo è basato sulle metriche del font specificato nella presentazione PowerPoint. Se il font specificato è mancante, viene sostituito con il font più simile, ma questo font ha metriche diverse da quelle originali. Di conseguenza, il calcolo delle dimensioni dei paragrafi su sistemi diversi produrrà risultati differenti a seconda del set di font installati. Per ottenere lo stesso risultato su diversi sistemi operativi, è necessario installare gli stessi font sui sistemi o caricarli a runtime come [font esterni](/slides/it/nodejs-java/custom-font/).

## **Formattazione e immagini**

**Q: Come posso impostare il colore del bordo di una tabella?**

**A**: È possibile modificare il colore di tutti i bordi della tabella o solo del bordo che circonda l'intera tabella. Per cambiare tutti i bordi, utilizzare il metodo `getCellFormat` della classe [Cell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cell/). Per il bordo dell'intera tabella, è necessario iterare le celle e modificare il colore dei bordi esterni.

**Q: Quale unità di misura utilizza Aspose.Slides per Node.js via Java per posizionare le immagini?**

**A**: Le coordinate e le dimensioni di tutte le forme sulle diapositive sono misurate in punti (72 dpi).

## **Lavorare con i font**

**Q: Durante la conversione da PPT a PDF o immagini, perché i font sono diversi nei documenti di output?**

**A**: Questo problema potrebbe indicare che i font utilizzati nella presentazione sono assenti dal sistema operativo su cui è stato eseguito il codice. È necessario installare i font sul sistema operativo o caricarli come font esterni utilizzando la classe [FontsLoader](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/) come mostrato di seguito:
```javascript
var folders = java.newArray("java.lang.String", ["path_to_a_folder_with_fonts"]));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", folders);
```