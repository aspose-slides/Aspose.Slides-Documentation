---
title: Gestire le tabelle delle presentazioni in JavaScript
linktitle: Gestisci tabella
type: docs
weight: 10
url: /it/nodejs-java/manage-table/
keywords:
- aggiungere tabella
- creare tabella
- accedere tabella
- rapporto d'aspetto
- allineare testo
- formattazione testo
- stile tabella
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea e modifica tabelle nelle diapositive PowerPoint con JavaScript e Aspose.Slides per Node.js. Scopri semplici esempi di codice per snellire il tuo flusso di lavoro con le tabelle."
---
## **Introduzione**

Una tabella in PowerPoint è un modo efficiente per visualizzare e rappresentare le informazioni. Le informazioni in una griglia di celle (disposte in righe e colonne) sono semplici e facili da capire.

Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table), la classe [Cell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cell/) e altri tipi per consentire di creare, aggiornare e gestire tabelle in tutti i tipi di presentazioni.

## **Crea Tabella da Zero**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Definisci un array di `columnWidth`.
4. Definisci un array di `rowHeight`.
5. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Itera attraverso ogni [Cell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cell/) per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.
7. Unisci le quattro celle nell'angolo in alto a sinistra della tabella (le prime due colonne delle prime due righe) in un'unica cella. 
8. Accedi al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) di una [Cell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cell/).
9. Aggiungi del testo al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/).
10. Salva la presentazione modificata.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanzia una classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Definisce le colonne con larghezze e le righe con altezze
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Aggiunge una forma tabella alla diapositiva
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Imposta il formato del bordo per ogni cella
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Unisce il blocco 2x2 in alto a sinistra di celle in un'unica cella
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Aggiunge del testo alla cella unita
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Salva la presentazione su disco
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Numerazione in Tabella Standard**

In una tabella standard, la numerazione delle celle è semplice e parte da zero. La prima cella in una tabella ha indice 0,0 (colonna 0, riga 0). 

Ad esempio, le celle in una tabella con 4 colonne e 4 righe sono numerate in questo modo:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Questo codice JavaScript mostra come specificare la numerazione per le celle in una tabella:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanzia una classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Definisce le colonne con larghezze e le righe con altezze
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Aggiunge una forma tabella alla diapositiva
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Imposta il formato del bordo per ciascuna cella
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Salva la presentazione su disco
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Accedi a Tabella Esistente**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).

2. Ottieni un riferimento alla diapositiva che contiene la tabella tramite il suo indice. 

3. Crea un oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) e impostalo a null.

4. Itera attraverso tutti gli oggetti [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/) finché la tabella non viene trovata.

   Se sospetti che la diapositiva in questione contenga una singola tabella, puoi semplicemente controllare tutte le forme che contiene. Quando una forma è identificata come una tabella, puoi effettuare il cast a un oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table). Ma se la diapositiva contiene più tabelle, è preferibile cercare la tabella desiderata tramite il suo [setAlternativeText(String value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. Utilizza l'oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) per lavorare con la tabella. Nell'esempio seguente, impostiamo il testo di una cella nella tabella.

6. Salva la presentazione modificata.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanzia la classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Accede alla prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Inizializza TableEx null
    var tbl = null;
    // Itera attraverso le forme e imposta un riferimento alla tabella trovata
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Imposta il testo per la prima colonna della seconda riga
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Salva la presentazione modificata su disco
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Trova la Cella che Possiede un Text Frame**

Quando del codice generico di elaborazione del testo riceve un [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) da una tabella, utilizza il metodo [TextFrame.getParentCell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getParentCell--) per recuperare la [Cell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cell/) proprietaria. Per un text frame di cella di tabella, [TextFrame.getParentCell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getParentCell--) restituisce il proprietario e [TextFrame.getParentShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getParentShape--) restituisce `null`, anche se la tabella stessa è una forma.

Le coordinate della cella sono disponibili tramite i metodi di sola lettura [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) e [Cell.getFirstRowIndex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cell/#getFirstRowIndex--). [TextFrame.getParentCell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getParentCell--) fornisce inoltre una navigazione di sola lettura: restituisce il proprietario ma non ne modifica la proprietà. Controlla sempre che la cella restituita non sia `null` prima di usarla.

Per un esempio completo che identifica i proprietari di celle di tabella e di forme, incluse le forme associate ai nodi SmartArt, vedi [Search and Replace Text](/slides/it/nodejs-java/search-and-replace-text/).

## **Allinea Testo nella Tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) alla diapositiva.
4. Accedi a un oggetto [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) dalla tabella.
5. Accedi al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/).
6. Allinea il testo verticalmente.
7. Salva la presentazione modificata.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Ottiene la prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Definisce le colonne con larghezze e le righe con altezze
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Aggiunge la forma tabella alla diapositiva
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Accede al frame di testo
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Crea l'oggetto Paragraph per il frame di testo
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Crea l'oggetto Portion per il paragrafo
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Allinea verticalmente il testo
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // Salva la presentazione su disco
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Imposta Formattazione del Testo a Livello di Tabella**

1. Crea un'istanza della [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) class.
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Accedi a un oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) dalla diapositiva.
4. Imposta [setFontHeight(float value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) per il testo.
5. Imposta [setAlignment(int value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) e [setMarginRight(float value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Imposta [setTextVerticalType(byte value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Salva la presentazione modificata. 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Supponiamo che la prima forma nella prima diapositiva sia una tabella
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Imposta l'altezza del carattere delle celle della tabella
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Imposta l'allineamento del testo e il margine destro delle celle della tabella in una singola chiamata
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Imposta il tipo verticale del testo delle celle della tabella
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Imposta Preset di Stile Tabella**

Aspose.Slides fornisce gli stili di tabella integrati di PowerPoint come enumerazione [TableStylePreset](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tablestylepreset/), così puoi applicare lo stesso aspetto a qualsiasi tabella. Questo codice JavaScript mostra come sostituire lo stile predefinito di una tabella con uno stile preset:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// cambia il tema predefinito del preset di stile
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Blocca Rapporto d'Aspetto della Tabella**

Il rapporto d'aspetto di una forma geometrica è il rapporto delle sue dimensioni in diverse dimensioni. Aspose.Slides fornisce la proprietà [**setAspectRatioLocked**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) per consentire di bloccare l'impostazione del rapporto d'aspetto per tabelle e altre forme.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// inverti
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un'intera tabella e il testo nelle sue celle?**

Sì. La tabella espone il metodo [setRightToLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/table/setrighttoleft/) e i paragrafi hanno [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). L'uso di entrambi garantisce l'ordine RTL corretto e il rendering all'interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Utilizza i blocchi di forma per disabilitare lo spostamento, il ridimensionamento, la selezione, ecc. Questi blocchi si applicano anche alle tabelle.

**È supportato l'inserimento di un'immagine all'interno di una cella come sfondo?**

Sì. È possibile impostare un [picture fill](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/) per una cella; l'immagine coprirà l'area della cella secondo la modalità scelta (allungamento o ripetizione).