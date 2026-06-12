---
title: Gestire le tabelle della presentazione in JavaScript
linktitle: Gestisci tabella
type: docs
weight: 10
url: /it/nodejs-java/manage-table/
keywords:
- aggiungere tabella
- creare tabella
- accedere alla tabella
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

Una tabella in PowerPoint è un modo efficiente per visualizzare e rappresentare le informazioni. Le informazioni in una griglia di celle (disposte in righe e colonne) sono chiare e facili da capire.

Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) , la classe [Cell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cell/) e altri tipi per consentire di creare, aggiornare e gestire tabelle in tutti i tipi di presentazioni.

## **Creare una tabella da zero**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Definisci un array di `columnWidth`.
4. Definisci un array di `rowHeight`.
5. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Itera attraverso ciascuna [Cell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cell/) per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.
7. Unisci le prime due celle della prima riga della tabella. 
8. Accedi al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) di una [Cell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cell/).
9. Aggiungi del testo al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/).
10. Salva la presentazione modificata.

Questo codice JavaScript mostra come creare una tabella in una presentazione:

```javascript
// Istanzia una classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Definisce le colonne con larghezze e le righe con altezze
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Aggiunge una forma di tabella alla diapositiva
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
    // Unisce le celle 1 e 2 della riga 1
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

## **Numerazione in una tabella standard**

In una tabella standard, la numerazione delle celle è semplice e parte da zero. La prima cella di una tabella ha indice 0,0 (colonna 0, riga 0). 

Ad esempio, le celle in una tabella con 4 colonne e 4 righe sono numerate così:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Questo codice JavaScript mostra come specificare la numerazione per le celle in una tabella:

```javascript
// Istanzia una classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Definisce le colonne con larghezze e le righe con altezze
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Aggiunge una forma di tabella alla diapositiva
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Imposta il formato del bordo per ogni cella
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

## **Accedere a una tabella esistente**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni un riferimento alla diapositiva che contiene la tabella tramite il suo indice. 
3. Crea un oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) e impostalo a null.
4. Itera attraverso tutti gli oggetti [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/) fino a trovare la tabella.  

Se pensi che la diapositiva in questione contenga una sola tabella, puoi semplicemente controllare tutte le forme che contiene. Quando una forma viene identificata come una tabella, puoi castarla come oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table). Tuttavia, se la diapositiva contiene più tabelle, è più opportuno cercare la tabella desiderata tramite il suo metodo [setAlternativeText(String value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. Utilizza l'oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) per lavorare con la tabella. Nell'esempio seguente, abbiamo aggiunto una nuova riga alla tabella.
6. Salva la presentazione modificata.

Questo codice JavaScript mostra come accedere e lavorare con una tabella esistente:

```javascript
// Istanzia la classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Accede alla prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Inizializza TableEx a null
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

## **Allineare il testo nella tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) alla diapositiva.
4. Accedi a un oggetto [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) dalla tabella.
5. Accedi al [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/) del [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/).
6. Allinea il testo verticalmente.
7. Salva la presentazione modificata.

Questo codice JavaScript mostra come allineare il testo in una tabella:

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Ottiene la prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Definisce le colonne con larghezze e le righe con altezze
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Aggiunge la forma della tabella alla diapositiva
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
    // Allinea il testo verticalmente
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Salva la presentazione su disco
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Impostare la formattazione del testo a livello di tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Accedi a un oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) dalla diapositiva.
4. Imposta il [setFontHeight(float value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) per il testo.
5. Imposta i metodi [setAlignment(int value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) e [setMarginRight(float value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Imposta il [setTextVerticalType(byte value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Salva la presentazione modificata. 

Questo codice JavaScript mostra come applicare le opzioni di formattazione preferite al testo in una tabella:

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Supponiamo che la prima forma della prima diapositiva sia una tabella
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Imposta l'altezza del font delle celle della tabella
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Imposta l'allineamento del testo e il margine destro delle celle della tabella in un'unica chiamata
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Imposta il tipo di orientamento verticale del testo delle celle della tabella
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ottenere le proprietà di stile della tabella**

Aspose.Slides consente di recuperare le proprietà di stile di una tabella in modo da poter utilizzare tali dettagli per un'altra tabella o altrove. Questo codice JavaScript mostra come ottenere le proprietà di stile da uno stile predefinito di tabella:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// cambia il tema predefinito dello stile preset
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bloccare il rapporto d'aspetto della tabella**

Il rapporto d'aspetto di una forma geometrica è il rapporto tra le sue dimensioni in diverse dimensioni. Aspose.Slides fornisce la proprietà [**setAspectRatioLocked**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) per consentire di bloccare l'impostazione del rapporto d'aspetto per tabelle e altre forme.

Questo codice JavaScript mostra come bloccare il rapporto d'aspetto per una tabella:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
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

Sì. La tabella espone il metodo [setRightToLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/table/setrighttoleft/), e i paragrafi hanno [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). L'uso di entrambi garantisce l'ordine RTL corretto e il rendering all'interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Usa i blocchi di forma per disabilitare lo spostamento, il ridimensionamento, la selezione, ecc. Questi blocchi si applicano anche alle tabelle.

**È supportata l'inserimento di un'immagine all'interno di una cella come sfondo?**

Sì. È possibile impostare un [picture fill](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/) per una cella; l'immagine coprirà l'area della cella secondo la modalità scelta (stretch o tile).