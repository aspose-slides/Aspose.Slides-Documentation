---
title: FAQ
type: docs
weight: 340
url: /it/cpp/faqs/
keywords:
- FAQ
- formato presentazione
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
- C++
- Aspose.Slides
description: "Ottieni risposte alle FAQ su Aspose.Slides per C++, includendo il supporto per PowerPoint e OpenDocument, indicazioni sull'installazione, licenze e risoluzione dei problemi."
---
## **Panoramica**

Questa FAQ fornisce risposte alle domande più comuni su Aspose.Slides. Copre i formati di file supportati, la gestione delle eccezioni quando si lavora con presentazioni di grandi dimensioni, la modifica delle dimensioni delle diapositive, l’anteprima delle diapositive, il recupero del testo dalle presentazioni, la formattazione dei bordi delle tabelle, il posizionamento delle immagini e la risoluzione dei problemi relativi ai caratteri durante la conversione delle presentazioni in PDF o immagini.

## **Formati di file supportati**

**Q:** Quali formati di file supporta Aspose.Slides per C++?

**A:** Aspose.Slides per C++ supporta i formati di file descritti in [Supported File Formats](/slides/it/cpp/supported-file-formats/).

## **Eccezioni**

**Q:** Ottengo un’eccezione out of memory durante il caricamento di un file PPT grande con immagini. Esiste una limitazione in Aspose.Slides riguardo alle dimensioni del file?

**A:** Non esiste una formula specifica per calcolare la dimensione della presentazione supportata da Aspose.Slides. Deve esserci spazio sufficiente per contenere l’intera struttura della presentazione e le immagini in memoria. Normalmente, le immagini in memoria occupano più spazio rispetto al disco fisso, soprattutto quando le immagini hanno effetti aggiuntivi.

In generale, Aspose.Slides per C++ può gestire facilmente file di presentazione di circa 300 MB su un server con 4 GB di RAM.

## **Lavorare con le diapositive**

**Q:** Posso modificare le dimensioni delle diapositive in una presentazione?

**A:** È possibile utilizzare il metodo `get_SlideSize` esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) per definire le dimensioni delle diapositive in una presentazione.

**Q:** Esiste un modo per definire diapositive di dimensioni diverse nella stessa presentazione?

**A:** Poiché le dimensioni delle diapositive sono definite a livello di presentazione nei documenti Microsoft PowerPoint, non è possibile farlo.

**Q:** Aspose.Slides per C++ supporta l’anteprima di una diapositiva prima del salvataggio?

**A:** È possibile renderizzare le diapositive della presentazione in immagini e utilizzare queste immagini per l’anteprima delle diapositive.

## **Lavorare con il testo**

**Q:** È possibile recuperare tutto il testo da una presentazione?

**A:** Aspose.Slides per C++ fornisce la classe [SlideUtil](https://reference.aspose.com/slides/it/cpp/aspose.slides.util/slideutil/) nello spazio dei nomi `Aspose::Slides::Util` che offre vari metodi per recuperare l’intero testo dalle presentazioni.

**Q:** Perché le dimensioni dei paragrafi sono diverse su sistemi operativi Windows e Linux?

**A:** Il calcolo delle dimensioni dei paragrafi si basa sul calcolo della dimensione del testo che rappresenta il paragrafo dato. Il calcolo della dimensione del testo è basato sulle metriche del carattere specificato nella presentazione PowerPoint. Se il carattere specificato è assente, viene sostituito con il carattere più simile, ma questo carattere ha metriche diverse da quelle originali. Di conseguenza, il calcolo delle dimensioni dei paragrafi su sistemi diversi produce risultati differenti a seconda del set di caratteri installati. Per ottenere lo stesso risultato su sistemi operativi diversi, è necessario installare gli stessi caratteri sui sistemi o caricarli a runtime come [external fonts](/slides/it/cpp/custom-font/).

## **Formattazione e immagini**

**Q:** Come posso impostare il colore del bordo di una tabella?

**A:** È possibile cambiare il colore di tutti i bordi della tabella o solo quello intorno all’intera tabella. Per cambiare tutti i bordi, utilizzare il metodo `get_CellFormat` dall’interfaccia [ICell](https://reference.aspose.com/slides/it/cpp/aspose.slides/icell/). Per il bordo dell’intera tabella, è necessario iterare le celle e cambiare il colore dei bordi esterni.

**Q:** Quale unità di misura usa Aspose.Slides per C++ per posizionare le immagini?

**A:** Le coordinate e le dimensioni di tutte le forme sulle diapositive sono misurate in punti (72 dpi).

## **Lavorare con i caratteri**

**Q:** Quando converto PPT in PDF o immagini, perché i caratteri sono diversi nei documenti di output?

**A:** Questo problema potrebbe indicare che i caratteri utilizzati nella presentazione sono assenti dal sistema operativo su cui è stato eseguito il codice. È necessario installare i caratteri sul sistema operativo o caricarli come caratteri esterni utilizzando la classe [FontsLoader](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/) come mostrato di seguito:
```cpp
auto folders = MakeObject<Array<String>>(1, "path_to_a_folder_with_fonts");
FontsLoader::LoadExternalFonts(folders);
```