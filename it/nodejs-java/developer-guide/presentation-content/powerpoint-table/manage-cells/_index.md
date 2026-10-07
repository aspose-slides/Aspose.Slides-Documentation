---
title: Gestire le celle della tabella nelle presentazioni con JavaScript
linktitle: Gestire le celle
type: docs
weight: 30
url: /it/nodejs-java/manage-cells/
keywords:
- cella della tabella
- unire celle
- rimuovere bordo
- dividere cella
- immagine nella cella
- colore di sfondo
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestire le celle delle tabelle PowerPoint in JavaScript: individuare le celle unite, rimuovere i bordi, dividere le celle e impostare colori di sfondo e immagini con Aspose.Slides per Node.js via Java."
---
## **Panoramica**

Aspose.Slides consente di accedere e modificare le celle delle tabelle nelle presentazioni PowerPoint. Questo articolo spiega come individuare le celle di tabella unite, rimuovere i bordi delle celle, gestire la numerazione delle celle dopo l’unione o la divisione delle celle, cambiare il colore di sfondo di una cella e aggiungere un’immagine all’interno di una cella di tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione delle celle tramite le proprietà della cella e salvare la presentazione modificata come file PPTX.

Aspose.Slides utilizza indici basati su zero per accedere alle celle della tabella nell'ordine `(colonna, riga)`.

## **Identificare una cella di tabella unita**

L'esempio apre una presentazione esistente e accede alla prima forma nella prima diapositiva come tabella. Assume che la diapositiva e la forma esistano e che la forma sia una tabella. Quindi itera attraverso tutte le righe e colonne e utilizza [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) per individuare le celle nelle regioni unite. Per ogni corrispondenza, stampa le coordinate della cella nell'ordine `row;column`, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), e le coordinate iniziali della regione, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) e [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Rimuovere i bordi delle celle della tabella**

Creare una [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) e aggiungere una tabella alla sua prima diapositiva con [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). Le larghezze delle colonne, le altezze delle righe e la posizione della tabella sono specificate in punti. L'esempio imposta tutti e quattro i bordi della cella su [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), rendendoli invisibili.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Unire le celle della tabella**

Usare [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) per combinare un intervallo rettangolare di celle della tabella in una singola cella. Specificare le celle negli angoli superiore sinistro e inferiore destro dell'intervallo. L'ultimo argomento controlla se l'unione possa includere celle al di fuori dell'intervallo specificato; `false` mantiene l'unione all'interno di quell'intervallo.

L'esempio crea una tabella 4x4 con colonne e righe da 70 punti, quindi unisce le quattro celle centrali da `(1, 1)` a `(2, 2)`. La cella risultante occupa due colonne e due righe, mentre la griglia sottostante della tabella mantiene quattro colonne e quattro righe. Per accedere al contenuto o alla formattazione della cella unita, utilizzare la sua posizione superiore sinistra: `table.get_Item(1, 1)` in questo esempio. Le altre posizioni nell'intervallo unito rimangono parte della griglia della tabella, quindi gli indici delle celle al di fuori dell'intervallo non cambiano.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dividere le celle della tabella**

Unire le celle nell'esempio precedente conserva la griglia della tabella. Dividere una cella può introdurre una nuova colonna nella griglia e modificare gli indici di colonna delle celle alla sua destra. Aspose.Slides segue il modello di griglia delle tabelle di PowerPoint.

Questo esempio crea una tabella 4x4 con colonne e righe da 70 punti e chiama [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) sulla cella `(1, 1)`. Metà della larghezza di 70 punti della cella viene passata per creare due celle di larghezza uguale.

Dopo questa divisione, le due metà sono accessibili come `table.get_Item(1, 1)` e `table.get_Item(2, 1)`. La griglia della tabella ora ha cinque colonne: le celle originariamente nelle colonne 2 e 3 si spostano rispettivamente alle colonne 3 e 4. Gli indici delle righe rimangono invariati. Utilizzare questi indici di colonna aggiornati quando si accede alle celle dopo la divisione.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Dividi le celle unite per estensione di riga o colonna**

Per preparare le celle modello unite per la popolazione dei dati, utilizzare [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) per dividere lungo un confine di riga esistente, oppure [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) per dividere lungo un confine di colonna.

L'argomento `index` conta le righe nella parte superiore o le colonne nella parte sinistra della divisione; è relativo alla regione unita:

- Divisione per riga: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Divisione per colonna: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

L'esempio prevede che una presentazione abbia una tabella come prima forma nella prima diapositiva, con `(1, 2)` e `(1, 3)` uniti verticalmente. Partendo dalla posizione inferiore, utilizza [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) e [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) per individuare l'origine e verifica entrambe le estensioni. `splitByRowSpan(1)` separa quindi le righe 2 e 3 per i nomi dei prodotti. Per un'unione orizzontale di due colonne, utilizzare invece `splitByColSpan(1)`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // Recupera le celle risultanti dalla tabella dopo la divisione.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

La griglia della tabella e gli indici delle celle circostanti rimangono invariati. Recuperare le celle risultanti tramite le loro coordinate; in questo caso, entrambe hanno estensioni pari a 1 e [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) stampa `false`. Regioni più ampie possono rimanere parzialmente unite dopo una singola divisione.

Il testo originale e la sua formattazione rimangono nella cella superiore (o sinistra); la nuova cella è vuota ma eredita la formattazione della cella come riempimento, bordi e margini. Popolare le celle dopo la divisione e impostare esplicitamente qualsiasi formattazione del testo richiesta.

La presentazione salvata contiene celle separate "Product A" e "Product B" con la formattazione delle celle del modello mantenuta. Vedere il [Riferimento API Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) per i dettagli.

## **Modificare il colore di sfondo della cella della tabella**

Questo esempio crea una tabella con colonne da 150 punti e righe da 50 punti. Utilizza [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) per selezionare un riempimento solido e imposta il colore restituito da [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) su rosso per la cella `(2, 3)`, nella terza colonna e quarta riga.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aggiungere un'immagine all'interno di una cella della tabella**

Posizionare l'immagine di input nella directory di lavoro prima di eseguire questo esempio. Carica l'immagine con [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) e la aggiunge alla collezione di immagini della presentazione con [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). Quindi assegna l'immagine al riempimento immagine della cella `(0, 0)`, la prima cella della tabella.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) allunga l'immagine per riempire la cella, il che può modificare il suo rapporto d'aspetto. Le larghezze delle colonne e le altezze delle righe sono in punti. L'immagine caricata viene eliminata in un blocco `finally` dopo essere stata aggiunta alla presentazione.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso impostare spessori e stili di linea diversi per i diversi lati di una singola cella?**

Sì. I bordi [superiore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[inferiore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[sinistra](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[destra](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) hanno proprietà separate, quindi lo spessore e lo stile di ciascun lato possono differire.

**Cosa succede all'immagine se modifico la dimensione della colonna/riga dopo aver impostato un'immagine come sfondo della cella?**

Il comportamento dipende dal [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l'immagine si adatta alla nuova cella; con il tiling, le tessere vengono ricalcolate.

**Posso assegnare un hyperlink a tutto il contenuto di una cella?**

[Collegamenti ipertestuali](/slides/it/nodejs-java/manage-hyperlinks/) sono impostati a livello di testo (porzione) all'interno del frame di testo della cella o a livello dell'intera tabella/forma. In pratica, si assegna il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare caratteri diversi all'interno di una singola cella?**

Sì. Il frame di testo di una cella supporta le [porzioni](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (run) con formattazione indipendente—famiglia di caratteri, stile, dimensione e colore.