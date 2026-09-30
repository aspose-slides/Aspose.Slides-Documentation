---
title: Gestire righe e colonne nelle tabelle PowerPoint con JavaScript
linktitle: Righe e colonne
type: docs
weight: 20
url: /it/nodejs-java/manage-rows-and-columns/
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
- stile della tabella
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci righe e colonne delle tabelle in PowerPoint con JavaScript e Aspose.Slides per Node.js via Java e velocizza la modifica delle presentazioni e gli aggiornamenti dei dati."
---
## **Introduzione**

Aspose.Slides per Node.js tramite Java ti consente di gestire la struttura e la formattazione delle tabelle nelle presentazioni PowerPoint tramite la classe [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Puoi designare una riga di intestazione, clonare o rimuovere righe e colonne e applicare la formattazione del testo a un'intera riga o colonna.

Questo articolo spiega queste operazioni con esempi JavaScript. Mostra anche come recuperare il preset di stile di una tabella per riutilizzarlo. Gli indici di righe e colonne della tabella partono da zero.

## **Controllare l'altezza della riga**

Usa [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) per impostare l'altezza minima di una riga in punti. È un limite inferiore, non un'altezza fissa. [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) restituisce l'altezza effettiva. Accedi alla riga tramite [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--).

L'esempio carica [row-height-input.pptx](row-height-input.pptx), che contiene una tabella come prima forma nella prima diapositiva. La sua prima riga inizia a 70 punti. Le celle usano testo Arial da 18 punti, a capo automatico e margini superiore e inferiore di 6 punti; il testo più lungo nella seconda colonna si avvolge su più righe. L'esempio aumenta il minimo a 100 punti, poi lo riduce a 20 punti, stampa l'altezza effettiva dopo ciascuna modifica e salva entrambi i risultati.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Con la presentazione fornita, aumentare il minimo aggiunge spazio alla riga. Ridurlo rimuove quello spazio extra, ma l'altezza effettiva rimane superiore a 20 punti perché il testo e i margini delle celle necessitano di più spazio. Ridurre solo il minimo non può forzare la riga al di sotto dello spazio richiesto dal suo contenuto.

Diversi fattori influenzano l'altezza effettiva:

- **Testo e dimensione del carattere:** testo più lungo, interruzioni di riga esplicite o un carattere più grande possono richiedere più spazio verticale.
- **Avvolgimento e larghezza della colonna:** con l'avvolgimento abilitato, ridurre la larghezza della colonna con [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) può produrre più righe. Una colonna più larga può ridurre lo spazio richiesto verticalmente.
- **Margini delle celle:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) e [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) aggiungono spazio verticale. [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) e [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) riducono la larghezza disponibile per il testo e possono causare ulteriori avvolgimenti.

Per questa tabella senza celle unite, la cella che richiede più spazio verticale determina il limite inferiore guidato dal contenuto per l'intera riga. Per rendere la riga più corta, potresti dover anche accorciare il testo, ridurre la dimensione del carattere o i margini, o allargare una colonna.

Le immagini sotto mostrano la stessa tabella alla stessa scala. Nei risultati illustrati, le altezze effettive erano 70, 100 e 55,2 punti: la riga finale è rimasta più alta del minimo di 20 punti. Le misurazioni esatte del testo possono variare a seconda dei caratteri disponibili nel tuo ambiente. Scarica i risultati salvati: [increased minimum](row-height-increased.pptx) e [decreased minimum](row-height-decreased.pptx).

| Originale: minimo 70 pt, effettivo 70 pt | Aumentato: minimo 100 pt, effettivo 100 pt | Ridotto: minimo 20 pt, effettivo 55.2 pt |
| --- | --- | --- |
| ![Tabella originale con una prima riga di 70 punti.](row-height-before.png) | ![Tabella dopo aver aumentato il minimo della prima riga a 100 punti.](row-height-increased.png) | ![Tabella dopo aver ridotto il minimo della prima riga a 20 punti; il testo avvolto mantiene la riga più alta del minimo.](row-height-decreased.png) |

## **Imposta la prima riga come intestazione**

Usa il metodo [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) per contrassegnare la prima riga per la formattazione dell'intestazione. Il suo aspetto dipende dallo stile della tabella applicato.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Accedi alla tabella memorizzata come prima forma sulla diapositiva.
4. Abilita la formattazione dell'intestazione per la sua prima riga.
5. Salva la presentazione modificata.

L'esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva. Abilita la formattazione dell'intestazione per la prima riga e salva `First_row_header.pptx`.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Clona una riga o una colonna della tabella**

Clona righe o colonne per riutilizzare il loro contenuto e la loro formattazione. Puoi aggiungere una copia alla fine della tabella o inserirla in una posizione specifica.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Definisci le larghezze delle colonne e le altezze delle righe.
4. Aggiungi una tabella con il metodo [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Clona le righe richieste.
6. Clona le colonne richieste.
7. Salva la presentazione modificata.

L'esempio richiede `Test.pptx` con almeno una diapositiva. Crea una tabella con tre colonne e cinque righe, con dimensioni specificate in punti. Aggiunge copie della prima riga e della prima colonna, poi inserisce copie della seconda riga e della seconda colonna all'indice 3 (quarta posizione). La tabella risultante ha sette righe e cinque colonne. L'argomento `false` disabilita il cloning in righe o colonne unite adiacenti; questa tabella non contiene celle unite.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rimuovi una riga o una colonna da una tabella**

Rimuovi righe o colonne non più necessarie in una tabella. La rimozione di un elemento sposta gli indici delle righe o colonne successive.

1. Crea una presentazione con la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Definisci le larghezze delle colonne e le altezze delle righe.
4. Aggiungi una tabella con il metodo [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Rimuovi la seconda riga e la seconda colonna.
6. Salva la presentazione modificata.

Questo esempio crea una tabella 3×3 e rimuove la riga e la colonna all'indice 1, lasciando una tabella 2×2 in `TestTable_out.pptx`. Le dimensioni sono in punti. L'argomento `false` disabilita la rimozione di righe o colonne unite adiacenti; questa tabella non contiene celle unite.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta la formattazione del testo a livello di riga della tabella**

Applica la formattazione del testo a un'intera riga per mantenere le celle coerenti. Puoi impostare le proprietà del carattere, la formattazione del paragrafo e la direzione del testo senza formattare singolarmente ogni cella.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accedi alla tabella nella prima diapositiva.
3. Usa [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) per la prima riga.
4. Usa [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) e [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) per la prima riga.
5. Usa [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) per la seconda riga.
6. Salva la presentazione modificata.

L'esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva e almeno due righe. Applica testo da 25 punti, allineamento a destra e un margine destro del paragrafo di 20 punti alla prima riga, quindi imposta il testo verticale nella seconda riga.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta la formattazione del testo a livello di colonna della tabella**

Applica la formattazione del testo a un'intera colonna per mantenere le celle coerenti. Puoi impostare le proprietà del carattere, la formattazione del paragrafo e la direzione del testo senza formattare singolarmente ogni cella.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accedi alla tabella nella prima diapositiva.
3. Usa [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) per la prima colonna.
4. Usa [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) e [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) per la prima colonna.
5. Usa [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) per la seconda colonna.
6. Salva la presentazione modificata.

L'esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva e almeno due colonne. Applica testo da 25 punti, allineamento a destra e un margine destro del paragrafo di 20 punti alla prima colonna, quindi imposta il testo verticale nella seconda colonna.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ottieni le proprietà dello stile della tabella**

Usa il metodo [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) per recuperare il preset applicato a una tabella e riutilizzarlo su un'altra tabella. Questo identifica il preset anziché le singole sovrascritture di formattazione delle celle.

L'esempio crea una tabella, applica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1) e legge nuovamente il preset. Stampa il valore intero corrispondente a `DarkStyle1` e salva la tabella in `table.pptx`.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Domande frequenti**

**Posso applicare temi/stili di PowerPoint a una tabella già creata?**

Sì. La tabella eredita il tema della diapositiva/layout/master e puoi comunque sovrascrivere riempimenti, bordi e colori del testo sopra quel tema.

**Posso ordinare le righe della tabella come in Excel?**

No, le tabelle di Aspose.Slides non hanno funzioni integrate di ordinamento o filtri. Ordina i dati in memoria prima, quindi ripopolare le righe della tabella in quell'ordine.

**Posso avere colonne a bande (striate) mantenendo colori personalizzati su celle specifiche?**

Sì. Attiva le colonne a bande, poi sovrascrivi le celle specifiche con formattazione locale; la formattazione a livello di cella ha la precedenza sullo stile della tabella.