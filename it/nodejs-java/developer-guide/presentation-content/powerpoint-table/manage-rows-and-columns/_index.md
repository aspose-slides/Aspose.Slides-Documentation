---
title: Gestire righe e colonne nelle tabelle PowerPoint usando JavaScript
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
description: "Gestisci righe e colonne delle tabelle in PowerPoint con JavaScript e Aspose.Slides per Node.js tramite Java e velocizza la modifica delle presentazioni e l'aggiornamento dei dati."
---
## **Introduzione**

Per consentire di gestire le righe e le colonne di una tabella in una presentazione PowerPoint, Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/table/) e altri tipi.

## **Imposta la prima riga come intestazione**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e carica la presentazione.  
2. Ottieni il riferimento di una slide tramite il suo indice.  
3. Crea un oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) e impostalo a null.  
4. Scorri tutti gli oggetti [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/) per trovare la tabella pertinente.  
5. Imposta la prima riga della tabella come intestazione.  

Questo codice JavaScript mostra come impostare la prima riga di una tabella come intestazione:

```javascript
// Istanzia la classe Presentation
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // Accede alla prima slide
    var sld = pres.getSlides().get_Item(0);
    // Inizializza il TableEx a null
    var tbl = null;
    // Itera tra le forme e imposta un riferimento alla tabella
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Imposta la prima riga di una tabella come intestazione
            tbl.setFirstRow(true);
        }
    }
    // Salva la presentazione su disco
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Clona la riga o la colonna di una tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e carica la presentazione,  
2. Ottieni il riferimento di una slide tramite il suo indice.  
3. Definisci un array di `columnWidth`.  
4. Definisci un array di `rowHeight`.  
5. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) alla slide tramite il metodo [addTable](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Clona la riga della tabella.  
7. Clona la colonna della tabella.  
8. Salva la presentazione modificata.  

Questo codice JavaScript mostra come clonare una riga o una colonna di una tabella PowerPoint:

```javascript
// Istanzia la classe Presentation
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // Accede alla prima slide
    var sld = pres.getSlides().get_Item(0);
    // Definisce colonne con larghezze e righe con altezze
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Aggiunge una forma di tabella alla slide
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Aggiunge del testo alla riga 1 cella 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // Aggiunge del testo alla riga 1 cella 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // Clona la riga 1 alla fine della tabella
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // Aggiunge del testo alla riga 2 cella 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // Aggiunge del testo alla riga 2 cella 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // Clona la riga 2 come quarta riga della tabella
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // Clona la prima colonna alla fine
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // Clona la seconda colonna all'indice della quarta colonna
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // Salva la presentazione su disco
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rimuovi una riga o una colonna da una tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e carica la presentazione,  
2. Ottieni il riferimento di una slide tramite il suo indice.  
3. Definisci un array di `columnWidth`.  
4. Definisci un array di `rowHeight`.  
5. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) alla slide tramite il metodo [addTable](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Rimuovi la riga della tabella.  
7. Rimuovi la colonna della tabella.  
8. Salva la presentazione modificata.  

Questo codice JavaScript mostra come rimuovere una riga o una colonna da una tabella:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Imposta la formattazione del testo a livello di riga della tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e carica la presentazione,  
2. Ottieni il riferimento di una slide tramite il suo indice.  
3. Accedi all'oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) pertinente dalla slide.  
4. Imposta i caratteri delle celle della prima riga con [setFontHeight(float value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Imposta l'allineamento delle celle della prima riga con [setAlignment(int value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) e [setMarginRight(float value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Imposta l'orientamento verticale del testo delle celle della seconda riga con [setTextVerticalType(byte value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Salva la presentazione modificata.  

Questo codice JavaScript dimostra l'operazione.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Supponiamo che la prima forma nella prima slide sia una tabella
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Imposta l'altezza del carattere delle celle della prima riga
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // Imposta l'allineamento del testo e il margine destro delle celle della prima riga
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // Imposta il tipo verticale del testo delle celle della seconda riga
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // Salva la presentazione su disco
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Imposta la formattazione del testo a livello di colonna della tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e carica la presentazione,  
2. Ottieni il riferimento di una slide tramite il suo indice.  
3. Accedi all'oggetto [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Table) pertinente dalla slide.  
4. Imposta i caratteri delle celle della prima colonna con [setFontHeight(float value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Imposta l'allineamento delle celle della prima colonna con [setAlignment(int value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) e [setMarginRight(float value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Imposta l'orientamento verticale del testo delle celle della seconda colonna con [setTextVerticalType(byte value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Salva la presentazione modificata.  

Questo codice JavaScript dimostra l'operazione:

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Supponiamo che la prima forma nella prima slide sia una tabella
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Imposta l'altezza del carattere delle celle della prima colonna
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // Imposta l'allineamento del testo e il margine destro delle celle della prima colonna in una sola chiamata
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // Imposta il tipo verticale del testo delle celle della seconda colonna
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ottieni le proprietà di stile della tabella**

Aspose.Slides consente di recuperare le proprietà di stile di una tabella in modo da poter utilizzare tali dettagli per un'altra tabella o altrove. Questo codice JavaScript mostra come ottenere le proprietà di stile da uno stile predefinito della tabella:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// cambia il tema predefinito dello stile preimpostato
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso applicare i temi/stili di PowerPoint a una tabella già creata?**

Sì. La tabella eredita il tema della slide/layout/master e puoi comunque sovrascrivere riempimenti, bordi e colori del testo sopra quel tema.

**Posso ordinare le righe della tabella come in Excel?**

No, le tabelle di Aspose.Slides non hanno ordinamento o filtri integrati. Ordina i dati in memoria prima, quindi ripopolare le righe della tabella in quell'ordine.

**Posso avere colonne a bande (a righe alternate) mantenendo colori personalizzati su celle specifiche?**

Sì. Attiva le colonne a bande, poi sovrascrivi le celle specifiche con formattazione locale; la formattazione a livello di cella ha la precedenza sullo stile della tabella.