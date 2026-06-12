---
title: Gestire righe e colonne nelle tabelle PowerPoint in .NET
linktitle: Righe e colonne
type: docs
weight: 20
url: /it/net/manage-rows-and-columns/
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
- .NET
- C#
- Aspose.Slides
description: "Gestisci le righe e le colonne delle tabelle in PowerPoint con Aspose.Slides per .NET e velocizza la modifica delle presentazioni e l'aggiornamento dei dati."
---
## **Introduzione**

Per consentirti di gestire le righe e le colonne di una tabella in una presentazione PowerPoint, Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/it/net/aspose.slides/table/), l’interfaccia [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/) e molti altri tipi. 

## **Imposta la prima riga come intestazione**

1. Crea un&rsquo;istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) e carica la presentazione. 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Crea un oggetto [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/) e impostalo a null. 
4. Itera su tutti gli oggetti [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/) per trovare la tabella pertinente. 
5. Imposta la prima riga della tabella come intestazione. 

Questo codice C# mostra come impostare la prima riga di una tabella come intestazione:

```c#
// Istanzia la classe Presentation
Presentation pres = new Presentation("table.pptx");

// Accede alla prima diapositiva
ISlide sld = pres.Slides[0];

// Inizializza la TableEx nulla
ITable tbl = null;

// Itera attraverso le forme e imposta un riferimento alla tabella
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Imposta la prima riga di una tabella come intestazione
tbl.FirstRow = true;

// Salva la presentazione su disco
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **Clona una riga o colonna di una tabella**

1. Crea un&rsquo;istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) e carica la presentazione, 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Definisci un array di `columnWidth`. 
4. Definisci un array di `rowHeight`. 
5. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/) alla diapositiva tramite il metodo [AddTable](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addtable/). 
6. Clona la riga della tabella. 
7. Clona la colonna della tabella. 
8. Salva la presentazione modificata. 

Questo codice C# mostra come clonare una riga o colonna di una tabella PowerPoint:

```c#
 // Istanzia la classe Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Accede alla prima diapositiva
    ISlide sld = presentation.Slides[0];

    // Definisce le colonne con larghezze e le righe con altezze
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Aggiunge una forma di tabella alla diapositiva
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Aggiunge del testo alla cella 1 della riga 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Aggiunge del testo alla cella 2 della riga 1
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Clona la riga 1 alla fine della tabella
    table.Rows.AddClone(table.Rows[0], false);

    // Aggiunge del testo alla cella 1 della riga 2
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Aggiunge del testo alla cella 2 della riga 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Clona la riga 2 come quarta riga della tabella
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Clona la prima colonna alla fine
    table.Columns.AddClone(table.Columns[0], false);

    // Clona la seconda colonna all'indice della quarta colonna
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Salva la presentazione su disco 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Rimuovi una riga o colonna da una tabella**

1. Crea un&rsquo;istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) e carica la presentazione, 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Definisci un array di `columnWidth`. 
4. Definisci un array di `rowHeight`. 
5. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/) alla diapositiva tramite il metodo [AddTable](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addtable/). 
6. Rimuovi la riga della tabella. 
7. Rimuovi la colonna della tabella. 
8. Salva la presentazione modificata. 

Questo codice C# mostra come rimuovere una riga o colonna da una tabella:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Imposta la formattazione del testo a livello di riga della tabella**

1. Crea un&rsquo;istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) e carica la presentazione, 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Accedi all&rsquo;oggetto [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/) pertinente dalla diapositiva. 
4. Imposta la proprietà [FontHeight](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/fontheight/) delle celle della prima riga. 
5. Imposta le proprietà [Alignment](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/alignment/) e [MarginRight](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/marginright/) delle celle della prima riga. 
6. Imposta la proprietà [TextVerticalType](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat/textverticaltype/) delle celle della seconda riga. 
7. Salva la presentazione modificata. 

Questo codice C# dimostra l&rsquo;operazione.

```c#
// Crea un'istanza della classe Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Supponiamo che la prima forma sulla prima diapositiva sia una tabella

// Imposta l'altezza del carattere delle celle della prima riga
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Imposta l'allineamento del testo e il margine destro delle celle della prima riga
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Imposta il tipo di orientamento verticale del testo delle celle della seconda riga
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Salva la presentazione su disco
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Imposta la formattazione del testo a livello di colonna della tabella**

1. Crea un&rsquo;istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) e carica la presentazione, 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Accedi all&rsquo;oggetto [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/) pertinente dalla diapositiva. 
4. Imposta la proprietà [FontHeight](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/fontheight/) delle celle della prima colonna. 
5. Imposta le proprietà [Alignment](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/alignment/) e [MarginRight](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/marginright/) delle celle della prima colonna. 
6. Imposta la proprietà [TextVerticalType](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat/textverticaltype/) delle celle della seconda colonna. 
7. Salva la presentazione modificata. 

Questo codice C# dimostra l&rsquo;operazione: 

```c#
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Supponiamo che la prima forma sulla prima diapositiva sia una tabella

// Imposta l'altezza del carattere delle celle della prima colonna
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Imposta l'allineamento del testo e il margine destro delle celle della prima colonna in una chiamata
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Imposta il tipo di orientamento verticale del testo delle celle della seconda colonna
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Salva la presentazione su disco
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **Recupera le proprietà di stile della tabella**

Aspose.Slides consente di recuperare le proprietà di stile di una tabella in modo da poter utilizzare tali dettagli per un&rsquo;altra tabella o in altro contesto. Questo codice C# mostra come ottenere le proprietà di stile da uno stile predefinito di una tabella: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // cambia il tema predefinito dello stile preimpostato
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Posso applicare temi/stili di PowerPoint a una tabella già creata?**

Sì. La tabella eredita il tema della diapositiva/layout/master e puoi comunque sovrascrivere riempimenti, bordi e colori del testo sopra quel tema.

**Posso ordinare le righe della tabella come in Excel?**

No, le tabelle di Aspose.Slides non hanno ordinamento o filtri integrati. Ordina i dati in memoria prima, quindi ricrea le righe della tabella in quell&rsquo;ordine.

**Posso avere colonne a bande (a strisce) mantenendo colori personalizzati su celle specifiche?**

Sì. Attiva le colonne a bande, quindi sovrascrivi le celle specifiche con una formattazione locale; la formattazione a livello di cella ha precedenza sullo stile della tabella.