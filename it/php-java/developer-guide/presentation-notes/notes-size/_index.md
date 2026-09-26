---
title: Modifica dimensione e orientamento della pagina delle note in PHP
linktitle: Dimensione pagina note
type: docs
weight: 10
url: /it/php-java/notes-size/
keywords:
- dimensione pagina note
- orientamento note
- note orizzontali
- note verticali
- dimensione volantino
- PowerPoint
- presentazione
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Leggi e modifica le dimensioni della pagina delle note in Aspose.Slides per PHP via Java, cambia orientamento, verifica le dimensioni salvate e esporta note o volantini in PDF e immagini."
---
## **Panoramica**

Utilizza [Presentation::getNotesSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getnotessize/) per accedere alle impostazioni della pagina delle note della presentazione. Restituisce un oggetto [NotesSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/notessize/) il cui metodo [setSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/notessize/setsize/) imposta le dimensioni della pagina. Sebbene l'oggetto delle impostazioni non possa essere sostituito, è possibile assegnare nuove dimensioni tramite questo metodo.

Larghezza e altezza sono specificate in **punti**, con 72 punti per pollice. Ad esempio, 900 × 600 punti corrispondono a 12,5 × 8⅓ pollici. Queste impostazioni si applicano alla presentazione, non alle note di una singola diapositiva.

| Impostazione | Scopo |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getnotessize/) | Controlla le dimensioni della pagina delle note e le dimensioni della pagina utilizzate per l'esportazione dei volantini. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getslidesize/) | Controlla le dimensioni delle diapositive della presentazione standard tramite [SlideSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesize/). |

Modificare una delle impostazioni non cambia automaticamente l'altra. Cambiare l'orientamento della pagina delle note non ruota nemmeno le diapositive regolari. Vedi [Slide Size](/slides/it/php-java/slide-size/) per ridimensionare le diapositive regolari.

Gli esempi seguenti utilizzano un file `sample.pptx` esistente. Per gli esempi di esportazione, usa una presentazione con almeno una diapositiva contenente note del relatore. Ogni esempio può essere eseguito in modo indipendente dopo aver caricato il PHP/Java Bridge e il wrapper PHP di Aspose.Slides. I valori numerici restituiti da Java vengono convertiti in valori PHP con `java_values` prima del confronto o del calcolo.

## **Leggi le Dimensioni e l'Orientamento della Pagina delle Note**

Leggi la larghezza e l'altezza e confrontale per determinare l'orientamento: una pagina più larga è orizzontale, una più alta è verticale, e dimensioni uguali descrivono una pagina quadrata. Questo esempio stampa le dimensioni effettive in punti, senza assumere una dimensione di carta standard.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Passa a Orizzontale Senza Cambiare le Dimensioni della Carta**

Per cambiare solo l'orientamento, scambia larghezza e altezza esistenti. Questo preserva le lunghezze di entrambi i lati, comprese quelle di una dimensione di carta personalizzata. La condizione qui sotto impedisce che una pagina già orizzontale venga trasformata nuovamente in verticale e mantiene invariata una pagina quadrata.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Per l'orientamento verticale, usa la stessa assegnazione quando `java_values($size->getWidth()) > java_values($size->getHeight())`. Non sostituire le dimensioni A4 o Letter a meno che tu non voglia anche cambiare le dimensioni della carta.

## **Imposta e Verifica una Dimensione Personalizzata della Pagina delle Note**

Assegna entrambe le dimensioni contemporaneamente, quindi usa [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/save/) per scrivere la presentazione. Questo esempio imposta una pagina orizzontale di 900 × 600 punti, la salva come PPTX e riapre il file salvato per verificare i valori persistiti. Il confronto consente una tolleranza di 0,01 punti per i valori in virgola mobile; non è una garanzia di precisione per tutti i formati di file.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Il risultato atteso è `900 x 600 points` e `Size preserved: true`. Controllare una presentazione appena aperta verifica il file salvato, piuttosto che solo le impostazioni in memoria.

## **Esporta Note e Volantini**

Le dimensioni della pagina definiscono l'area disponibile per i layout di note o di volantini. Non abilitano tali layout da sole: è necessario configurare anche le opzioni di esportazione. L'esportazione delle diapositive regolari continua a utilizzare le dimensioni delle diapositive.

### **Esporta Note in PDF e PNG**

Assegna [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/notescommentslayoutingoptions/) a [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) per includere le note nel PDF. Questo esempio rende anche la prima diapositiva con note in PNG utilizzando [Slide::getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage) e [RenderingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/renderingoptions/).

La modalità [BottomTruncated](https://reference.aspose.com/slides/it/php-java/aspose.slides/notespositions/) mantiene le note su una singola pagina; le note che non rientrano possono essere troncate. Il PDF utilizza pagine di 900 × 600 punti. Con la scala dell'immagine di 1 × 1 usata di seguito, il PNG è di 900 × 600 pixel. I punti descrivono la geometria della pagina; i pixel descrivono l'output raster, le cui dimensioni dipendono anche dalla scala di rendering.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Per l'esportazione PDF con note lunghe, [BottomFull](https://reference.aspose.com/slides/it/php-java/aspose.slides/notespositions/) consente pagine aggiuntive secondo necessità. Non utilizzare quella modalità con la chiamata immagine di una singola diapositiva sopra, che non la supporta. Dopo il ridimensionamento, ispeziona l'output per note troncate e la posizione degli oggetti master delle note esistenti; cambiare solo le dimensioni della pagina non dovrebbe essere considerato una garanzia che tutto il contenuto si adatti. Vedi [Convert PowerPoint to PDF with Notes](/slides/it/php-java/convert-powerpoint-to-pdf-with-notes/) per ulteriori informazioni sull'esportazione delle note.

### **Esporta Volantini in PDF**

Utilizza [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/handoutlayoutingoptions/) per più miniature di diapositive su una singola pagina. L'esempio seguente imposta una pagina di 900 × 600 punti e usa [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/it/php-java/aspose.slides/handouttype/) per disporre fino a quattro diapositive per pagina. Il preset orizzontale controlla l'ordine delle diapositive; l'orientamento della pagina deriva dalla sua larghezza e altezza.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Modificare le dimensioni della pagina cambia l'area disponibile per la griglia dei volantini senza alterare le dimensioni delle diapositive di origine. Per le immagini dei volantini, utilizza [Presentation::getImages](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getimages/) con il layout dei volantini, anziché il metodo immagine di una singola diapositiva. In Aspose.Slides, il rendering dei volantini a livello di presentazione utilizza le dimensioni della pagina delle note, mentre la chiamata immagine di una diapositiva individuale non produce la pagina del volantino. Vedi [Handout Mode](/slides/it/php-java/convert-powerpoint-in-handout-mode/) per le opzioni di layout.

## **Dimensioni della Pagina in Visualizzatori, Esportazione e Stampa**

Mantieni distinte le dimensioni della presentazione memorizzata, le dimensioni della pagina esportata e le dimensioni della carta stampata:

- **Presentation viewers:** Un visualizzatore può visualizzare o stampare le note usando le proprie regole di layout. Se un'altra applicazione salva il file, riaprilo e controlla di nuovo le dimensioni; la conversione del formato di quell'applicazione potrebbe normalizzarle.
- **Export formats:** I formati di esportazione: gli esempi PDF di note e volantini sopra usano le dimensioni della pagina configurate. Le immagini raster utilizzano dimensioni pixel intere e una scala di rendering, quindi i valori frazionari dei punti possono essere arrotondati nell'output dell'immagine. L'esportazione delle diapositive regolari non applica le dimensioni della pagina delle note.
- **Printer drivers:** I driver della stampante: la selezione della carta, la rotazione automatica e le impostazioni di adatta alla pagina possono modificare l'output fisico senza cambiare le dimensioni memorizzate nella presentazione o nel PDF. Per una dimensione di carta specifica, abbina le impostazioni della stampante e controlla l'anteprima di stampa.

## **FAQ**

**Posso impostare le dimensioni delle note per una sola diapositiva?**

La dimensione della pagina delle note è un'impostazione a livello di presentazione. Le singole diapositive possono avere contenuti di note diversi, ma questa proprietà non fornisce una dimensione di pagina separata per ciascuna diapositiva.

**Perché la modifica dell'orientamento delle note non ha cambiato le mie diapositive?**

Le pagine delle note e le diapositive regolari hanno dimensioni indipendenti. Usa le impostazioni di dimensione delle diapositive regolari quando vuoi ridimensionare le diapositive stesse.

**Perché il risultato salvato o stampato ha una dimensione diversa?**

Prima riapri la presentazione salvata e confronta le sue dimensioni delle note. Se sono cambiate, verifica se il salvataggio o la conversione del file in un'altra applicazione ha modificato le impostazioni della pagina. Se non è così, controlla il layout di esportazione, la scala dell'immagine, le impostazioni del visualizzatore e la selezione della carta della stampante.