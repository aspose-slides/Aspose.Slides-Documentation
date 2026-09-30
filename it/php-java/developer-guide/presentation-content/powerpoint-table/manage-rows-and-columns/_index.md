---
title: Gestisci righe e colonne nelle tabelle PowerPoint usando PHP
linktitle: Righe e colonne
type: docs
weight: 20
url: /it/php-java/manage-rows-and-columns/
keywords:
- riga della tabella
- colonna della tabella
- prima riga
- intestazione della tabella
- clona riga
- clona colonna
- copia riga
- copia colonna
- rimuovi riga
- rimuovi colonna
- formattazione testo riga
- formattazione testo colonna
- stile tabella
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci righe e colonne delle tabelle in PowerPoint con Aspose.Slides per PHP tramite Java e velocizza la modifica delle presentazioni e gli aggiornamenti dei dati."
---
## **Introduzione**

Aspose.Slides per PHP tramite Java ti consente di gestire la struttura e la formattazione delle tabelle nelle presentazioni PowerPoint tramite la classe [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Puoi designare una riga di intestazione, clonare o rimuovere righe e colonne e applicare la formattazione del testo a un'intera riga o colonna.

Questo articolo spiega queste operazioni con esempi PHP. Mostra anche come recuperare il preset di stile di una tabella in modo da riutilizzarlo. Gli indici di righe e colonne della tabella partono da zero.

## **Controllo altezza riga**

Usa [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) per impostare l'altezza minima di una riga in punti. È un limite inferiore, non un'altezza fissa. [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) restituisce l'altezza effettiva. Accedi alla riga tramite [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/).

L'esempio carica [row-height-input.pptx](row-height-input.pptx), che contiene una tabella come prima forma nella prima diapositiva. La sua prima riga inizia a 70 punti. Le celle usano testo Arial da 18 punti, con a capo automatico e margini superiore e inferiore di 6 punti; il testo più lungo nella seconda colonna va a capo su più righe. L'esempio aumenta il minimo a 100 punti, poi lo diminuisce a 20 punti, stampa l'altezza reale dopo ogni modifica e salva entrambi i risultati.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Con la presentazione fornita, aumentare il minimo aggiunge spazio alla riga. Diminuirlo rimuove quello spazio extra, ma l'altezza reale rimane superiore a 20 punti perché testo e margini delle celle richiedono più spazio. Ridurre solo il minimo non può forzare la riga al di sotto dello spazio necessario al suo contenuto.

Diversi fattori influenzano l'altezza reale:

- **Testo e dimensione carattere:** testo più lungo, interruzioni di riga esplicite o un carattere più grande possono richiedere più spazio verticale.
- **A capo e larghezza colonna:** con l'a capo abilitato, ridurre la larghezza della colonna con [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) può produrre più righe. Una colonna più larga può ridurre lo spazio richiesto verticalmente.
- **Margini celle:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) e [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) aggiungono spazio verticale. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) e [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) riducono la larghezza disponibile per il testo e possono causare ulteriori a capo.

Per questa tabella senza celle unite, la cella che necessita del maggior spazio verticale determina il limite inferiore basato sul contenuto per l'intera riga. Per rendere la riga più corta, potrebbe essere necessario abbreviare il testo, ridurre la dimensione del carattere o i margini, o allargare una colonna.

Le immagini seguenti mostrano la stessa tabella alla stessa scala. Nei risultati illustrati, le altezze reali erano 70, 100 e 55,2 punti: la riga finale è rimasta più alta del suo minimo di 20 punti. Le misurazioni testuali precise possono variare con i caratteri disponibili nell'ambiente. Scarica i risultati salvati: [minimum aumentato](row-height-increased.pptx) e [minimum diminuito](row-height-decreased.pptx).

| Originale: minimum 70 pt, reale 70 pt | Aumentato: minimum 100 pt, reale 100 pt | Diminuito: minimum 20 pt, reale 55,2 pt |
| --- | --- | --- |
| ![Tabella originale con prima riga di 70 punti.](row-height-before.png) | ![Tabella dopo aver aumentato il minimum della prima riga a 100 punti.](row-height-increased.png) | ![Tabella dopo aver diminuito il minimum della prima riga a 20 punti; il testo a capo mantiene la riga più alta del minimum.](row-height-decreased.png) |

## **Imposta la prima riga come intestazione**

Usa il metodo [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) per contrassegnare la prima riga per la formattazione dell'intestazione. Il suo aspetto dipende dallo stile della tabella applicato.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Accedi alla tabella memorizzata come prima forma sulla diapositiva.
4. Abilita la formattazione dell'intestazione per la sua prima riga.
5. Salva la presentazione modificata.

L'esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva. Abilita la formattazione dell'intestazione per la prima riga e salva `First_row_header.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Clona una riga o colonna di tabella**

Clona righe o colonne per riutilizzare il loro contenuto e la loro formattazione. Puoi aggiungere una copia alla fine della tabella o inserirla in una posizione specifica.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Definisci le larghezze delle colonne e le altezze delle righe.
4. Aggiungi una tabella con il metodo [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Clona le righe necessarie.
6. Clona le colonne necessarie.
7. Salva la presentazione modificata.

L'esempio richiede `Test.pptx` con almeno una diapositiva. Crea una tabella con tre colonne e cinque righe, con dimensioni specificate in punti. Aggiunge copie della prima riga e della prima colonna, poi inserisce copie della seconda riga e della seconda colonna all'indice 3 (quarta posizione). La tabella risultante ha sette righe e cinque colonne. L'argomento `false` disabilita la clonazione in righe o colonne unite adiacenti; questa tabella non ha celle unite.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Rimuovi una riga o colonna da una tabella**

Rimuovi righe o colonne che non sono più necessarie in una tabella. La rimozione di un elemento sposta gli indici delle righe o colonne che lo seguono.

1. Crea una presentazione con la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Definisci le larghezze delle colonne e le altezze delle righe.
4. Aggiungi una tabella con il metodo [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Rimuovi la seconda riga e la seconda colonna.
6. Salva la presentazione modificata.

Questo esempio crea una tabella 3×3 e rimuove la riga e la colonna all'indice 1, lasciando una tabella 2×2 in `TestTable_out.pptx`. Le dimensioni sono in punti. L'argomento `false` disabilita la rimozione di righe o colonne unite adiacenti; questa tabella non ha celle unite.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Imposta la formattazione del testo a livello di riga della tabella**

Applica la formattazione del testo a un'intera riga per mantenere le celle coerenti. Puoi impostare le proprietà del carattere, la formattazione del paragrafo e la direzione del testo senza formattare ogni cella singolarmente.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accedi alla tabella nella prima diapositiva.
3. Usa [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) per la prima riga.
4. Usa [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) e [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) per la prima riga.
5. Usa [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) per la seconda riga.
6. Salva la presentazione modificata.

L'esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva e almeno due righe. Applica testo da 25 punti, allineamento a destra e un margine di paragrafo destro di 20 punti alla prima riga, poi imposta il testo verticale nella seconda riga.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Imposta la formattazione del testo a livello di colonna della tabella**

Applica la formattazione del testo a un'intera colonna per mantenere le celle coerenti. Puoi impostare le proprietà del carattere, la formattazione del paragrafo e la direzione del testo senza formattare ogni cella singolarmente.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accedi alla tabella nella prima diapositiva.
3. Usa [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) per la prima colonna.
4. Usa [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) e [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) per la prima colonna.
5. Usa [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) per la seconda colonna.
6. Salva la presentazione modificata.

L'esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva e almeno due colonne. Applica testo da 25 punti, allineamento a destra e un margine di paragrafo destro di 20 punti alla prima colonna, poi imposta il testo verticale nella seconda colonna.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ottieni le proprietà dello stile della tabella**

Usa il metodo [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) per recuperare il preset applicato a una tabella e riutilizzarlo su un'altra tabella. Questo identifica il preset piuttosto che le singole sovrascritture di formattazione delle celle.

L'esempio crea una tabella, applica [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1) e legge nuovamente il preset. Stampa il valore intero corrispondente a `DarkStyle1` e salva la tabella in `table.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Posso applicare temi/stili di PowerPoint a una tabella già creata?**

Sì. La tabella eredita il tema della diapositiva/layout/master e puoi comunque sovrascrivere riempimenti, bordi e colori del testo sopra quel tema.

**Posso ordinare le righe della tabella come in Excel?**

No, le tabelle Aspose.Slides non hanno ordinamento o filtri integrati. Ordina i dati in memoria prima, poi ripopola le righe della tabella in quell'ordine.

**Posso avere colonne a bande (a righe) mantenendo colori personalizzati su celle specifiche?**

Sì. Attiva le colonne a bande, poi sovrascrivi le celle specifiche con formattazione locale; la formattazione a livello di cella ha precedenza sullo stile della tabella.