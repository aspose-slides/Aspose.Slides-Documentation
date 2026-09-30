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
- formattazione del testo della riga
- formattazione del testo della colonna
- stile della tabella
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci righe e colonne delle tabelle in PowerPoint con Aspose.Slides per .NET e velocizza la modifica delle presentazioni e l'aggiornamento dei dati."
---
## **Introduzione**

Aspose.Slides per .NET consente di gestire la struttura e la formattazione delle tabelle nelle presentazioni PowerPoint tramite la classe [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) e l’interfaccia [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). È possibile designare una riga di intestazione, clonare o rimuovere righe e colonne e applicare la formattazione del testo a un’intera riga o colonna.

Questo articolo spiega queste operazioni con esempi C#. Mostra anche come recuperare lo stile predefinito di una tabella per riutilizzarlo. Gli indici di righe e colonne della tabella partono da zero.

## **Controllare l'Altezza della Riga**

Utilizzare [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) per impostare l’altezza minima di una riga in punti. È un limite inferiore, non un’altezza fissa. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) restituisce l’altezza reale ed è di sola lettura. Accedere alla riga tramite [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/).

L’esempio carica [row-height-input.pptx](row-height-input.pptx), che contiene una tabella come prima forma nella prima diapositiva. La sua prima riga inizia a 70 punti. Le celle usano testo Arial da 18 punti, a capo automatico e margini superiori e inferiori di 6 punti; il testo più lungo nella seconda colonna va a capo su più righe. L’esempio aumenta il minimo a 100 punti, poi lo riduce a 20 punti, stampa l’altezza reale dopo ogni modifica e salva entrambi i risultati.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

Con la presentazione fornita, aumentare il minimo aggiunge spazio alla riga. Ridurlo rimuove quello spazio extra, ma l’altezza reale rimane superiore a 20 punti perché testo e margini delle celle richiedono più spazio. Ridurre solo il minimo non può forzare la riga al di sotto dello spazio richiesto dal contenuto.

Diversi fattori influenzano l’altezza reale:

- **Testo e dimensione del carattere:** testo più lungo, interruzioni di riga esplicite o un carattere più grande possono richiedere più spazio verticale.
- **A capo automatico e larghezza della colonna:** con l’a capo abilitato, una [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) più stretta può produrre più righe. Una colonna più larga può ridurre lo spazio richiesto verticalmente.
- **Margini delle celle:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) e [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) aggiungono spazio verticale. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) e [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) riducono la larghezza disponibile per il testo e possono causare ulteriore a capo automatico.

Per questa tabella senza celle unite, la cella che richiede più spazio verticale determina il limite inferiore dettato dal contenuto per l’intera riga. Per rendere la riga più corta, potrebbe essere necessario accorpare il testo, ridurre la dimensione del carattere o i margini, oppure allargare una colonna.

Le immagini sottostanti mostrano la stessa tabella alla stessa scala. In questo caso, le altezze reali erano 70, 100 e 55,2 punti: la riga finale è rimasta più alta del minimo di 20 punti. Le misurazioni precise del testo possono variare a seconda dei caratteri disponibili nel proprio ambiente. Scarica i risultati salvati: [increased minimum](row-height-increased.pptx) e [decreased minimum](row-height-decreased.pptx).

| Originale: minimo 70 pt, reale 70 pt | Aumentato: minimo 100 pt, reale 100 pt | Ridotto: minimo 20 pt, reale 55,2 pt |
| --- | --- | --- |
| ![Tabella originale con una prima riga di 70 punti.](row-height-before.png) | ![Tabella dopo aver aumentato il minimo della prima riga a 100 punti.](row-height-increased.png) | ![Tabella dopo aver diminuito il minimo della prima riga a 20 punti; il testo a capo mantiene la riga più alta del minimo.](row-height-decreased.png) |

## **Impostare la Prima Riga come Intestazione**

Usare la proprietà [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) per contrassegnare la prima riga per la formattazione dell’intestazione. L’aspetto dipende dallo stile della tabella applicato alla tabella.

1. Caricare la presentazione con la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Accedere alla prima diapositiva.
3. Accedere alla tabella memorizzata come prima forma nella diapositiva.
4. Abilitare la formattazione dell’intestazione per la sua prima riga.
5. Salvare la presentazione modificata.

L’esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva. Abilita la formattazione dell’intestazione per la prima riga e salva `First_row_header.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Clonare una Riga o una Colonna della Tabella**

Clonare righe o colonne per riutilizzare il loro contenuto e la loro formattazione. È possibile aggiungere una copia alla fine della tabella o inserirla in una posizione specifica.

1. Caricare la presentazione con la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Accedere alla prima diapositiva.
3. Definire le larghezze delle colonne e le altezze delle righe.
4. Aggiungere una tabella con il metodo [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Clonare le righe richieste.
6. Clonare le colonne richieste.
7. Salvare la presentazione modificata.

L’esempio richiede `Test.pptx` con almeno una diapositiva. Crea una tabella con tre colonne e cinque righe, con dimensioni specificate in punti. Aggiunge copie della prima riga e della prima colonna, quindi inserisce copie della seconda riga e della seconda colonna all’indice 3 (la quarta posizione). La tabella risultante ha sette righe e cinque colonne. L’argomento `false` disabilita il cloning in righe o colonne unite adiacenti; questa tabella non ha celle unite.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **Rimuovere una Riga o una Colonna da una Tabella**

Rimuovere righe o colonne non più necessarie in una tabella. Rimuovere un elemento sposta gli indici delle righe o colonne successive.

1. Creare una presentazione con la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Accedere alla prima diapositiva.
3. Definire le larghezze delle colonne e le altezze delle righe.
4. Aggiungere una tabella con il metodo [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Rimuovere la seconda riga e la seconda colonna.
6. Salvare la presentazione modificata.

Questo esempio crea una tabella 3×3 e rimuove la riga e la colonna all’indice 1, lasciando una tabella 2×2 in `TestTable_out.pptx`. Le dimensioni sono in punti. L’argomento `false` disabilita la rimozione di righe o colonne unite adiacenti; questa tabella non ha celle unite.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **Impostare la Formattazione del Testo a Livello di Riga della Tabella**

Applicare la formattazione del testo a un’intera riga per mantenere coerenti le celle. È possibile impostare le proprietà del carattere, la formattazione del paragrafo e l’orientamento del testo senza formattare ogni cella singolarmente.

1. Caricare la presentazione con la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Accedere alla tabella nella prima diapositiva.
3. Impostare [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) per la prima riga.
4. Impostare [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) e [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) per la prima riga.
5. Impostare [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) per la seconda riga.
6. Salvare la presentazione modificata.

L’esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva e almeno due righe. Applica testo da 25 punti, allineamento a destra e un margine di paragrafo destro di 20 punti alla prima riga, poi imposta il testo verticale nella seconda riga.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **Impostare la Formattazione del Testo a Livello di Colonna della Tabella**

Applicare la formattazione del testo a un’intera colonna per mantenere coerenti le celle. È possibile impostare le proprietà del carattere, la formattazione del paragrafo e l’orientamento del testo senza formattare ogni cella singolarmente.

1. Caricare la presentazione con la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Accedere alla tabella nella prima diapositiva.
3. Impostare [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) per la prima colonna.
4. Impostare [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) e [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) per la prima colonna.
5. Impostare [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) per la seconda colonna.
6. Salvare la presentazione modificata.

L’esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva e almeno due colonne. Applica testo da 25 punti, allineamento a destra e un margine di paragrafo destro di 20 punti alla prima colonna, poi imposta il testo verticale nella seconda colonna.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **Ottenere le Proprietà di Stile della Tabella**

Utilizzare la proprietà [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) per recuperare il preset applicato a una tabella e riutilizzarlo su un’altra tabella. Questo identifica il preset anziché le sovrascritture di formattazione celle individuali.

L’esempio crea una tabella, applica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/), e legge il preset. Stampa `DarkStyle1` e salva la tabella in `table.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Posso applicare temi/stili di PowerPoint a una tabella già creata?**

Sì. La tabella eredita il tema della diapositiva/layout/master e si possono comunque sovrascrivere riempimenti, bordi e colori del testo sopra quel tema.

**Posso ordinare le righe della tabella come in Excel?**

No, le tabelle di Aspose.Slides non hanno ordinamento o filtri incorporati. Ordina i dati in memoria prima, poi ricopia le righe della tabella in quell’ordine.

**Posso avere colonne a bande (a righe alternate) mantenendo colori personalizzati su celle specifiche?**

Sì. Attiva le colonne a bande, poi sovrascrivi le celle specifiche con formattazione locale; la formattazione a livello di cella ha precedenza sullo stile della tabella.