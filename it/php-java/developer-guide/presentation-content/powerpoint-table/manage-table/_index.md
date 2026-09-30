---
title: Gestire le tabelle delle presentazioni in PHP
linktitle: Gestisci tabella
type: docs
weight: 10
url: /it/php-java/manage-table/
keywords:
- aggiungere tabella
- creare tabella
- accedere tabella
- rapporto d'aspetto
- allineare testo
- formattazione del testo
- stile della tabella
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Crea e modifica tabelle nelle diapositive PowerPoint con Aspose.Slides per PHP tramite Java. Scopri semplici esempi di codice per ottimizzare i tuoi flussi di lavoro con le tabelle."
---
## **Introduzione**

Le tabelle in PowerPoint organizzano le informazioni in righe e colonne, facilitando la lettura e il confronto dei valori.

Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) , la classe [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) e altri tipi per consentire di creare, aggiornare e gestire le tabelle nelle presentazioni.

## **Crea una tabella da zero**

Creare una tabella specificando la sua posizione, le larghezze delle colonne e le altezze delle righe. Dopo averla aggiunta a una diapositiva, è possibile formattare i bordi delle celle, unire le celle e inserire testo.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Ottenere un riferimento alla diapositiva tramite il suo indice.
3. Definire un array di larghezze di colonna in punti.
4. Definire un array di altezze di riga in punti.
5. Aggiungere un oggetto [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) .
6. Iterare su ogni [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.
7. Unire le prime due celle della prima riga della tabella.
8. Accedere alla cella unita tramite il suo metodo [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) .
9. Impostare il testo nella cella unita.
10. Salvare la presentazione modificata.

L'esempio seguente crea una tabella con tre colonne e cinque righe alle coordinate (100, 50) punti. Applica bordi rossi con una larghezza di 5 punti, unisce le prime due celle nella prima riga e salva il risultato come `table.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Numerazione in una tabella standard**

In una tabella standard, gli indici delle celle partono da zero e utilizzano l'ordine (colonna, riga). La prima cella ha indice (0, 0).

Ad esempio, le celle in una tabella con 4 colonne e 4 righe sono numerate in questo modo:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Questo esempio crea la tabella 4 × 4 illustrata sopra, con larghezze delle colonne e altezze delle righe di 70 punti e bordi rossi delle celle con una larghezza di 5 punti. Le coordinate illustrano gli indici delle celle; l'esempio lascia le celle vuote e salva la tabella come `StandardTables_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Accedi a una tabella esistente**

Le tabelle sono memorizzate nella raccolta di forme di una diapositiva. Iterare attraverso le forme per individuare una tabella, quindi utilizzare la classe [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) per leggere o aggiornare le sue celle.

1. Caricare la presentazione utilizzando la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Ottenere un riferimento alla diapositiva che contiene la tabella tramite il suo indice.
3. Iterare attraverso gli oggetti [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) e fermarsi quando viene trovata una tabella. Se la diapositiva contiene più tabelle, usare [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) per identificare quella necessaria.
4. Aggiornare il testo nella cella target.
5. Salvare la presentazione modificata.

L'esempio seguente apre `UpdateExistingTable.pptx` e trova la prima tabella nella prima diapositiva. Imposta la cella alla colonna 0, riga 1 a `New` e salva il risultato come `table1_out.pptx`. L'input deve contenere almeno una diapositiva, e la prima tabella su quella diapositiva deve avere almeno una colonna e due righe.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Per ridimensionare una riga in una tabella esistente e capire perché la sua altezza reale può superare il minimo richiesto, vedere [Controllo dell'altezza della riga](/slides/it/php-java/manage-rows-and-columns/#control-row-height).

## **Trova la cella che possiede un TextFrame**

Quando del codice generico di elaborazione del testo riceve un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) da una tabella, utilizzare il metodo [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) per recuperare la [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) proprietaria. Per un TextFrame di cella di tabella, [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) restituisce il proprietario e [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) restituisce `null`, anche se la tabella stessa è una forma.

Le coordinate della cella sono disponibili attraverso i metodi di sola lettura [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) e [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) . [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) fornisce anche una navigazione di sola lettura: restituisce il proprietario ma non ne modifica la proprietà. Verificare sempre la cella restituita con `java_is_null` prima di utilizzarla.

Per un esempio completo che identifica i proprietari di celle di tabella e di forme, incluse le forme associate ai nodi SmartArt, vedere [Ricerca e sostituzione del testo](/slides/it/php-java/search-and-replace-text/).

## **Allinea il testo in una tabella**

È possibile controllare l'ancoraggio verticale e la direzione del testo delle singole celle di una tabella. L'esempio in questa sezione centra il testo nella prima cella e lo ruota di 270 gradi.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Ottenere un riferimento alla diapositiva tramite il suo indice.
3. Aggiungere un oggetto [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) alla diapositiva.
4. Accedere a un oggetto [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) dalla tabella.
5. Accedere al primo [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) e impostare il suo testo e colore.
6. Im­postare l'ancoraggio verticale della cella e la direzione del testo utilizzando [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) e [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/) .
7. Salvare la presentazione modificata.

Questo esempio crea una tabella 4 × 4 con larghezze di colonna di 120 punti e altezze di riga di 100 punti. Formatta il testo nella cella (0, 0), aggiunge valori alle altre celle della prima riga e salva il risultato come `Vertical_Align_Text_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Imposta la formattazione del testo a livello di tabella**

Utilizzare [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) per applicare la formattazione del testo a tutte le celle di una tabella. Le sue sovraccariche accettano la formattazione della porzione, del paragrafo e del frame di testo, così è possibile impostare queste proprietà senza iterare tra le singole celle.

1. Caricare la presentazione utilizzando la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Ottenere un riferimento alla diapositiva tramite il suo indice.
3. Accedere a un oggetto [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) dalla diapositiva.
4. Impostare la dimensione del carattere usando [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) per il testo.
5. Impostare l'allineamento del paragrafo e il margine destro usando [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) e [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) .
6. Impostare la direzione del testo usando [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) .
7. Salvare la presentazione modificata.

L'esempio seguente apre `table.pptx`, che deve contenere almeno una diapositiva con una tabella come prima forma. Imposta la dimensione del carattere a 25 punti, allinea a destra i paragrafi con un margine destro di 20 punti e rende il testo verticale. La presentazione formattata viene salvata come `result.pptx`.

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ottieni le proprietà dello stile della tabella**

Utilizzare [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) per leggere lo stile predefinito di una tabella e [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) per assegnarlo. Questo esempio applica [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) a una tabella, stampa il valore predefinito e assegna lo stesso stile a una seconda tabella. Entrambe le tabelle sono salvate in `table-style.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Blocca il rapporto d'aspetto di una tabella**

Il rapporto d'aspetto di una tabella è il rapporto tra la sua larghezza e la sua altezza. Utilizzare [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) per bloccare questo rapporto per una tabella.

L'esempio seguente apre `pres.pptx`, che deve contenere almeno una diapositiva con una tabella come prima forma. Stampa lo stato di blocco corrente, abilita il blocco del rapporto d'aspetto, stampa lo stato aggiornato (`true`) e salva il risultato come `pres-out.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un'intera tabella e per il testo nelle sue celle?**

Sì. La tabella espone un metodo [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) , e i paragrafi hanno [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/) . L'uso di entrambi garantisce l'ordine RTL corretto e il rendering all'interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Utilizzare i [blocchi forma](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) per disabilitare lo spostamento, il ridimensionamento, la selezione, ecc. Questi blocchi si applicano anche alle tabelle.

**È supportata l'inserimento di un'immagine all'interno di una cella come sfondo?**

Sì. È possibile impostare un [riempimento immagine](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) per una cella; l'immagine coprirà l'area della cella secondo la modalità scelta (estensione o mosaico).