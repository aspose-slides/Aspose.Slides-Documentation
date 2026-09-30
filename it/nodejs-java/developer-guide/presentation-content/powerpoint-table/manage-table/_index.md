---
title: Gestisci le tabelle delle presentazioni in JavaScript
linktitle: Gestisci tabella
type: docs
weight: 10
url: /it/nodejs-java/manage-table/
keywords:
- aggiungi tabella
- creare tabella
- accedere tabella
- rapporto d'aspetto
- allineare testo
- formattazione del testo
- stile della tabella
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea e modifica tabelle nelle diapositive PowerPoint con JavaScript e Aspose.Slides per Node.js. Scopri esempi di codice semplici per ottimizzare i tuoi flussi di lavoro con le tabelle."
---
## **Introduzione**

Le tabelle in PowerPoint organizzano le informazioni in righe e colonne, facilitando la lettura e il confronto dei valori.

Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) , la classe [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) e altri tipi per consentirti di creare, aggiornare e gestire le tabelle nelle presentazioni.

## **Crea una tabella da zero**

Crea una tabella specificando la sua posizione, le larghezze delle colonne e le altezze delle righe. Dopo averla aggiunta a una diapositiva, puoi formattare i bordi delle celle, unire le celle e inserire testo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Definisci un array di larghezze delle colonne in punti.
4. Definisci un array di altezze delle righe in punti.
5. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) alla diapositiva attraverso il metodo [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) .
6. Itera attraverso ogni [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.
7. Unisci le prime due celle della prima riga della tabella.
8. Accedi alla cella unita tramite il suo metodo [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) .
9. Imposta il testo nella cella unita.
10. Salva la presentazione modificata.

L'esempio seguente crea una tabella con tre colonne e cinque righe a (100, 50) punti. Applica bordi rossi con una larghezza di 5 punti, unisce le prime due celle nella prima riga e salva il risultato come `table.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Numerazione in una tabella standard**

In una tabella standard, gli indici delle celle partono da zero e usano l'ordine (colonna, riga). La prima cella ha indice (0, 0).

Ad esempio, le celle in una tabella con 4 colonne e 4 righe sono numerate in questo modo:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Questo esempio crea la tabella 4 × 4 illustrata sopra, con larghezze delle colonne e altezze delle righe di 70 punti e bordi delle celle rossi con una larghezza di 5 punti. Le coordinate illustrano gli indici delle celle; l'esempio lascia le celle vuote e salva la tabella come `StandardTables_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Accedi a una tabella esistente**

Le tabelle sono memorizzate nella raccolta di forme di una diapositiva. Itera tra le forme per individuare una tabella, quindi usa la classe [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) per leggere o aggiornare le sue celle.

1. Carica la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Ottieni un riferimento alla diapositiva che contiene la tabella tramite il suo indice.
3. Itera attraverso gli oggetti [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) e fermati quando trovi una tabella. Se la diapositiva contiene diverse tabelle, usa [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) per identificare quella di cui hai bisogno.
4. Aggiorna il testo nella cella target.
5. Salva la presentazione modificata.

L'esempio seguente apre `UpdateExistingTable.pptx` e trova la prima tabella sulla prima diapositiva. Imposta la cella nella colonna 0, riga 1 a `New` e salva il risultato come `table1_out.pptx`. L'input deve contenere almeno una diapositiva, e la prima tabella su quella diapositiva deve avere almeno una colonna e due righe.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Per ridimensionare una riga in una tabella esistente e capire perché la sua altezza reale può superare il minimo richiesto, vedi [Controlla l'altezza della riga](/slides/it/nodejs-java/manage-rows-and-columns/#control-row-height).

## **Trova la cella che possiede un TextFrame**

Quando del codice generico di elaborazione del testo riceve un [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) da una tabella, usa il metodo [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) per recuperare la [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) proprietaria. Per un TextFrame di una cella di tabella, [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) restituisce il proprietario e [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) restituisce `null`, anche se la tabella stessa è una forma.

Le coordinate della cella sono disponibili attraverso i metodi di sola lettura [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) e [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) . [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) fornisce anche una navigazione di sola lettura: restituisce il proprietario ma non cambia la proprietà. Verifica sempre se la cella restituita è `null` prima di usarla.

Per un esempio completo che identifica i proprietari delle celle di tabella e delle forme, incluse le forme associate ai nodi SmartArt, vedi [Cerca e sostituisci testo](/slides/it/nodejs-java/search-and-replace-text/).

## **Allinea il testo in una tabella**

Puoi controllare l'ancoraggio verticale e la direzione del testo delle singole celle della tabella. L'esempio in questa sezione centra il testo nella prima cella e lo ruota di 270 gradi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) alla diapositiva.
4. Accedi a un oggetto [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) dalla tabella.
5. Accedi al primo [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) e imposta il suo testo e colore.
6. Imposta l'ancoraggio verticale della cella e la direzione del testo usando [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) e [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-) .
7. Salva la presentazione modificata.

Questo esempio crea una tabella 4 × 4 con larghezze delle colonne di 120 punti e altezze delle righe di 100 punti. Formattta il testo nella cella (0, 0), aggiunge valori alle restanti celle della prima riga e salva il risultato come `Vertical_Align_Text_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta la formattazione del testo a livello di tabella**

Usa [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) per applicare la formattazione del testo a tutte le celle di una tabella. Le sue overload accettano la formattazione di porzione, paragrafo e TextFrame, così puoi impostare queste proprietà senza iterare attraverso le singole celle.

1. Carica la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Accedi a un oggetto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) dalla diapositiva.
4. Imposta la dimensione del carattere usando [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) per il testo.
5. Imposta l'allineamento del paragrafo e il margine destro usando [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) e [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) .
6. Imposta la direzione del testo usando [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. Salva la presentazione modificata.

L'esempio seguente apre `table.pptx`, che deve contenere almeno una diapositiva con una tabella come prima forma. Imposta la dimensione del carattere a 25 punti, allinea a destra i paragrafi con un margine destro di 20 punti e rende il testo verticale. La presentazione formattata è salvata come `result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ottieni le proprietà dello stile della tabella**

Usa [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) per leggere lo stile predefinito di una tabella e [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) per assegnarlo. Questo esempio applica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) a una tabella, stampa il valore del preset e assegna lo stesso preset a una seconda tabella. Entrambe le tabelle sono salvate in `table-style.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Blocca il rapporto di aspetto di una tabella**

Il rapporto di aspetto di una tabella è il rapporto tra la sua larghezza e la sua altezza. Usa [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) per bloccare questo rapporto per una tabella.

L'esempio seguente apre `pres.pptx`, che deve contenere almeno una diapositiva con una tabella come prima forma. Stampa lo stato di blocco attuale, abilita il blocco del rapporto di aspetto, stampa lo stato aggiornato (`true`) e salva il risultato come `pres-out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un'intera tabella e il testo nelle sue celle?**

Sì. La tabella espone un metodo [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-), e i paragrafi hanno [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-). Usando entrambi si garantisce l'ordine RTL corretto e il rendering all'interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Usa [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) per disabilitare lo spostamento, il ridimensionamento, la selezione, ecc. Queste protezioni si applicano anche alle tabelle.

**È supportato l'inserimento di un'immagine all'interno di una cella come sfondo?**

Sì. Puoi impostare un [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) per una cella; l'immagine coprirà l'area della cella secondo la modalità scelta (allungamento o riempimento a tessere).