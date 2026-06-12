---
title: Gestisci righe e colonne nelle tabelle PowerPoint usando Java
linktitle: Righe e colonne
type: docs
weight: 20
url: /it/java/manage-rows-and-columns/
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
- Java
- Aspose.Slides
description: "Gestisci le righe e le colonne delle tabelle in PowerPoint con Aspose.Slides per Java e accelera la modifica delle presentazioni e l'aggiornamento dei dati."
---
## **Introduzione**

Per consentirti di gestire le righe e le colonne di una tabella in una presentazione PowerPoint, Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/it/java/com.aspose.slides/table/) , l'interfaccia [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITable) e molti altri tipi. 

## **Imposta la prima riga come intestazione**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) e carica la presentazione. 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Crea un oggetto [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITable) e impostalo su null. 
4. Itera attraverso tutti gli oggetti [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/) per trovare la tabella pertinente. 
5. Imposta la prima riga della tabella come intestazione. 

Questo codice Java mostra come impostare la prima riga di una tabella come intestazione:

```java
// Istanzia la classe Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // Accede alla prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Inizializza la TableEx a null
    ITable tbl = null;

    // Itera attraverso le forme e imposta un riferimento alla tabella
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Imposta la prima riga di una tabella come intestazione
            tbl.setFirstRow(true);
        }
    }
    
    // Salva la presentazione su disco
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Clona una riga o una colonna di tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) e carica la presentazione, 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Definisci un array di `columnWidth`. 
4. Definisci un array di `rowHeight`. 
5. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITable) alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. Clona la riga della tabella. 
7. Clona la colonna della tabella. 
8. Salva la presentazione modificata. 

Questo codice Java mostra come clonare una riga o una colonna di una tabella PowerPoint:

```java
 // Istanzia la classe Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // Accede alla prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Definisce le colonne con larghezze e le righe con altezze
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Aggiunge una forma tabella alla diapositiva
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

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
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Salva la presentazione su disco
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rimuovi una riga o una colonna da una tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) e carica la presentazione, 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Definisci un array di `columnWidth`. 
4. Definisci un array di `rowHeight`. 
5. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITable) alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. Rimuovi la riga della tabella. 
7. Rimuovi la colonna della tabella. 
8. Salva la presentazione modificata. 

Questo codice Java mostra come rimuovere una riga o una colonna da una tabella:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta la formattazione del testo a livello di riga della tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) e carica la presentazione, 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Accedi all'oggetto [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITable) pertinente dalla diapositiva. 
4. Imposta le celle della prima riga con [setFontHeight(float value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. Imposta le celle della prima riga con [setAlignment(int value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) e [setMarginRight(float value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Imposta le celle della seconda riga con [setTextVerticalType(byte value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. Salva la presentazione modificata. 

Questo codice Java dimostra l'operazione.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Supponiamo che la prima forma nella prima diapositiva sia una tabella
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Imposta l'altezza del carattere delle celle della prima riga
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Imposta l'allineamento del testo e il margine destro delle celle della prima riga
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Imposta il tipo di testo verticale delle celle della seconda riga
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Salva la presentazione su disco
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta la formattazione del testo a livello di colonna della tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) e carica la presentazione, 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Accedi all'oggetto [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITable) pertinente dalla diapositiva. 
4. Imposta le celle della prima colonna con [setFontHeight(float value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. Imposta le celle della prima colonna con [setAlignment(int value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) e [setMarginRight(float value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Imposta le celle della seconda colonna con [setTextVerticalType(byte value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. Salva la presentazione modificata. 

Questo codice Java dimostra l'operazione: 

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Supponiamo che la prima forma nella prima diapositiva sia una tabella
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Imposta l'altezza del carattere delle celle della prima colonna
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Imposta l'allineamento del testo e il margine destro delle celle della prima colonna in una sola chiamata
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Imposta il tipo di testo verticale delle celle della seconda colonna
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ottieni le proprietà di stile della tabella**

Aspose.Slides ti consente di recuperare le proprietà di stile di una tabella in modo da poter utilizzare tali dettagli per un'altra tabella o altrove. Questo codice Java mostra come ottenere le proprietà di stile da uno stile predefinito di tabella:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // cambia il tema predefinito dello stile preimpostato
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso applicare temi/stili di PowerPoint a una tabella già creata?**

Sì. La tabella eredita il tema della diapositiva/layout/master e puoi comunque sovrascrivere riempimenti, bordi e colori del testo sopra quel tema.

**Posso ordinare le righe della tabella come in Excel?**

No, le tabelle di Aspose.Slides non dispongono di ordinamento o filtri incorporati. Ordina i dati in memoria prima, poi ripopola le righe della tabella in quell'ordine.

**Posso avere colonne a bande (a righe alternate) mantenendo colori personalizzati su celle specifiche?**

Sì. Attiva le colonne a bande, poi sovrascrivi le celle specifiche con formattazione locale; la formattazione a livello di cella ha precedenza sullo stile della tabella.