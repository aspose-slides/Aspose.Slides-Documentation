---
title: Gestisci le celle della tabella nelle presentazioni usando JavaScript
linktitle: Gestisci Celle
type: docs
weight: 30
url: /it/nodejs-java/manage-cells/
keywords:
- cella di tabella
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
description: "Gestisci le celle delle tabelle in PowerPoint con Aspose.Slides per Node.js. Impara ad accedere, modificare e formattare le celle rapidamente per un'automazione delle diapositive senza interruzioni."
---
## **Panoramica**

Aspose.Slides consente di accedere e modificare le celle delle tabelle nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle della tabella unite, rimuovere i bordi delle celle, gestire la numerazione delle celle dopo l’unione o la separazione, modificare il colore di sfondo di una cella e aggiungere un’immagine all’interno di una cella di una tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione delle celle tramite le proprietà della cella e salvare la presentazione modificata come file PPTX.

## **Identificare le celle unite della tabella**
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni la tabella dalla prima diapositiva. 
3. Itera tra le righe e le colonne della tabella per trovare le celle unite.
4. Stampa un messaggio quando vengono trovate celle unite.

Questo codice JavaScript mostra come identificare le celle unite di una tabella in una presentazione:

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// presumendo che Slide#0.Shape#0 sia una tabella
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rimuovere il bordo delle celle della tabella**
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Definisci un array di colonne con larghezza.
4. Definisci un array di righe con altezza.
5. Aggiungi una tabella alla diapositiva mediante il metodo [addTable](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Itera su ogni cella per cancellare i bordi superiore, inferiore, destro e sinistro.
7. Salva la presentazione modificata come file PPTX.

Questo codice JavaScript mostra come rimuovere i bordi dalle celle di una tabella:

```javascript
// Istanzia la classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Definisce le colonne con larghezze e le righe con altezze
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Aggiunge la forma tabella alla diapositiva
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Imposta il formato del bordo per ogni cella
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // Scrive il PPTX su disco
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Numerazione nelle celle unite**
Se uniamo 2 coppie di celle (1, 1) × (2, 1) e (1, 2) × (2, 2), la tabella risultante sarà numerata. Questo codice JavaScript dimostra il processo:

```javascript
// Istanzia la classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Definisce le colonne con larghezze e le righe con altezze
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Aggiunge una forma tabella alla diapositiva
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
    // Unisce le celle (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Unisce le celle (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Successivamente uniamo ulteriormente le celle unendo (1, 1) e (1, 2). Il risultato è una tabella contenente una grande cella unita al centro:

```javascript
// Istanzia la classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Definisce le colonne con larghezze e le righe con altezze
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Aggiunge una forma tabella alla diapositiva
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
    // Unisce le celle (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Unisce le celle (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Unisce le celle (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // Scrive il file PPTX su disco
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Numerazione nelle celle separate**
Negli esempi precedenti, quando le celle della tabella venivano unite, la numerazione o il sistema numerico nelle altre celle non cambiava.  

Questa volta prendiamo una tabella normale (una tabella senza celle unite) e poi proviamo a dividere la cella (1,1) per ottenere una tabella speciale. Potresti notare che la numerazione di questa tabella può apparire strana. Tuttavia, è il modo in cui Microsoft PowerPoint numera le celle della tabella e Aspose.Slides fa la stessa cosa.  

Questo codice JavaScript dimostra il processo descritto:

```javascript
// Istanzia la classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Definisce le colonne con larghezze e le righe con altezze
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Aggiunge una forma tabella alla diapositiva
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
    // Unisce le celle (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Unisce le celle (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Divide la cella (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // Scrive il file PPTX su disco
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modificare il colore di sfondo di una cella della tabella**

Questo codice JavaScript mostra come modificare il colore di sfondo di una cella della tabella:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // crea una nuova tabella
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // imposta il colore di sfondo per una cella
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Aggiungere un'immagine all'interno di una cella della tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento a una diapositiva tramite il suo indice.
3. Definisci un array di colonne con larghezza.
4. Definisci un array di righe con altezza.
5. Aggiungi una tabella alla diapositiva mediante il metodo [addTable](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Crea un oggetto `Images` per contenere il file immagine.
7. Aggiungi l'immagine `IImage` all'oggetto `PPImage`.
8. Imposta il `FillFormat` per la cella della tabella su `Picture`.
9. Inserisci l'immagine nella prima cella della tabella.
10. Salva la presentazione modificata come file PPTX

Questo codice JavaScript mostra come inserire un'immagine all'interno di una cella della tabella durante la creazione della tabella:

```javascript
// Istanzia la classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var islide = pres.getSlides().get_Item(0);
    // Definisce le colonne con larghezze e le righe con altezze
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // Aggiunge una forma tabella alla diapositiva
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // Crea un oggetto PPImage usando il file immagine
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Aggiunge l'immagine alla prima cella della tabella
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Salva il file PPTX su disco
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso impostare spessori e stili di linea diversi per i lati di una singola cella?**

Sì. I bordi [superiore](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cellformat/getbordertop/)/[inferiore](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[sinistro](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cellformat/getborderleft/)/[destro](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cellformat/getborderright/) hanno proprietà separate, quindi lo spessore e lo stile di ciascun lato possono differire. Ciò segue logicamente il controllo dei bordi per lato di una cella dimostrato nell'articolo.

** Cosa succede all'immagine se modifico la dimensione della colonna/riga dopo aver impostato un'immagine come sfondo della cella?**

Il comportamento dipende dalla [modalità di riempimento](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l'immagine si adatta alla nuova cella; con il tiling, le piastrelle vengono ricalcolate. L'articolo descrive le modalità di visualizzazione dell'immagine in una cella.

**Posso assegnare un collegamento ipertestuale a tutto il contenuto di una cella?**

[Iperlink](/slides/it/nodejs-java/manage-hyperlinks/) vengono impostati a livello di porzione di testo all'interno del riquadro di testo della cella oppure a livello dell'intera tabella/forma. In pratica, assegni il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare font diversi all'interno di una singola cella?**

Sì. Il riquadro di testo di una cella supporta [segmenti](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/) (run) con formattazione indipendente—famiglia del font, stile, dimensione e colore.