---
title: Gestire le celle della tabella nelle presentazioni in .NET
linktitle: Gestire le celle
type: docs
weight: 30
url: /it/net/manage-cells/
keywords:
- cella della tabella
- unire celle
- rimuovere bordo
- dividere cella
- immagine nella cella
- colore di sfondo
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci le celle delle tabelle PowerPoint in C#: identifica le celle unite, rimuovi i bordi, dividi le celle e imposta colori di sfondo e immagini con Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides consente di accedere e modificare le celle delle tabelle nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle unite delle tabelle, rimuovere i bordi delle celle, gestire la numerazione delle celle dopo l'unione o la divisione delle celle, cambiare il colore di sfondo di una cella e aggiungere un'immagine all'interno di una cella della tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione delle celle tramite le proprietà della cella e salvare la presentazione modificata come file PPTX.

Aspose.Slides utilizza indici a base zero per accedere alle celle delle tabelle nell'ordine `(colonna, riga)`.

## **Identificare una cella di tabella unita**

L'esempio apre una presentazione esistente e accede alla prima forma nella prima diapositiva come tabella. Presume che la diapositiva e la forma esistano e che la forma sia una tabella. Quindi itera attraverso tutte le righe e le colonne e utilizza [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) per identificare le celle nelle regioni unite. Per ogni corrispondenza, stampa le coordinate della cella nell'ordine `riga;colonna`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), e le coordinate di inizio della regione, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) e [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **Rimuovere i bordi delle celle della tabella**

Crea una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) e aggiungi una tabella alla sua prima diapositiva con [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Le larghezze delle colonne, le altezze delle righe e la posizione della tabella sono specificate in punti. L'esempio imposta tutti e quattro i bordi della cella su [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), rendendoli invisibili.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Unire le celle della tabella**

Utilizza [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) per combinare un intervallo rettangolare di celle della tabella in un'unica cella. Specifica le celle negli angoli in alto a sinistra e in basso a destra dell'intervallo. L'ultimo argomento controlla se l'unione può includere celle al di fuori dell'intervallo specificato; `false` mantiene l'unione all'interno di quell'intervallo.

L'esempio crea una tabella 4x4 con colonne e righe da 70 punti, quindi unisce le quattro celle centrali da `(1, 1)` a `(2, 2)`. La cella risultante occupa due colonne e due righe, mentre la griglia sottostante della tabella mantiene quattro colonne e quattro righe. Per accedere al contenuto o alla formattazione della cella unita, utilizza la sua posizione in alto a sinistra: `table[1, 1]` in questo esempio. Le altre posizioni nell'intervallo unito rimangono parte della griglia della tabella, quindi gli indici delle celle al di fuori dell'intervallo non cambiano.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **Dividere le celle della tabella**

L'unione delle celle nell'esempio precedente conserva la griglia della tabella. Dividere una cella può introdurre una nuova colonna nella griglia e modificare gli indici di colonna delle celle a destra. Aspose.Slides segue il modello di griglia delle tabelle di PowerPoint.

Questo esempio crea una tabella 4x4 con colonne e righe da 70 punti e chiama [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) sulla cella `(1, 1)`. Metà della larghezza di 70 punti della cella viene passata per creare due celle di larghezza uguale.

Dopo questa divisione, le due metà sono accessibili come `table[1, 1]` e `table[2, 1]`. La griglia della tabella ora ha cinque colonne: le celle originariamente nelle colonne 2 e 3 si spostano rispettivamente alle colonne 3 e 4. Gli indici delle righe rimangono invariati. Usa questi indici di colonna aggiornati quando accedi alle celle dopo la divisione.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **Dividere le celle unite per intervallo di riga o colonna**

Per preparare le celle modello unite per il popolamento dei dati, utilizza [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) per dividere lungo un confine di riga esistente, o [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) per dividere lungo un confine di colonna.

L'argomento `index` conta le righe nella parte superiore o le colonne nella parte sinistra della divisione; è relativo alla regione unita:

- Divisione di riga: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Divisione di colonna: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

L'esempio prevede che una presentazione abbia una tabella come prima forma nella prima diapositiva, con `(1, 2)` e `(1, 3)` unite verticalmente. Partendo dalla posizione inferiore, utilizza [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) e [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) per individuare l'origine e verifica entrambi gli intervalli. `SplitByRowSpan(1)` separa quindi le righe 2 e 3 per i nomi dei prodotti. Per un'unione orizzontale a due colonne, utilizza invece `SplitByColSpan(1)`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // Recupera le celle risultanti dalla tabella dopo la divisione.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

La griglia della tabella e gli indici delle celle circostanti rimangono invariati. Recupera le celle risultanti tramite le loro coordinate; in questo caso, entrambe hanno un intervallo di 1 e [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) restituisce `False`. Regioni più grandi possono rimanere parzialmente unite dopo una divisione.

Il testo originale e la sua formattazione rimangono nella cella superiore (o sinistra); la nuova cella è vuota ma eredita la formattazione della cella, come riempimento, bordi e margini. Popola le celle dopo la divisione e imposta esplicitamente qualsiasi formattazione del testo necessaria.

La presentazione salvata contiene celle separate "Product A" e "Product B" con la formattazione della cella del modello conservata. Consulta la [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) per ulteriori dettagli.

## **Modificare il colore di sfondo della cella della tabella**

Questo esempio crea una tabella con colonne da 150 punti e righe da 50 punti. Imposta [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) su solido e [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) su rosso per la cella `(2, 3)`, nella terza colonna e quarta riga.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **Aggiungere un'immagine all'interno di una cella della tabella**

Posiziona l'immagine di input nella directory di lavoro prima di eseguire questo esempio. Carica l'immagine con [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) e la aggiunge alla collezione di immagini della presentazione con [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Quindi assegna l'immagine al riempimento immagine della cella `(0, 0)`, la prima cella della tabella.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) allunga l'immagine per riempire la cella, il che può modificare il suo rapporto d'aspetto. Le larghezze delle colonne e le altezze delle righe sono in punti. L'immagine caricata viene eliminata automaticamente dalla sua dichiarazione using.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Posso impostare spessori e stili di linea diversi per i diversi lati di una singola cella?**

Sì. I bordi [superiore](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/), [inferiore](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/), [sinistro](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/), [destro](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) hanno proprietà separate, quindi lo spessore e lo stile di ogni lato possono differire.

**Cosa succede all'immagine se modifico la dimensione della colonna/riga dopo aver impostato un'immagine come sfondo della cella?**

Il comportamento dipende dalla [modalità di riempimento](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l'immagine si adatta alla nuova cella; con il tiling, le piastrelle vengono ricalcolate.

**Posso assegnare un collegamento ipertestuale a tutto il contenuto di una cella?**

[Collegamenti](/slides/it/net/manage-hyperlinks/) sono impostati a livello di testo (porzione) all'interno del riquadro di testo della cella o a livello dell'intera tabella/forma. In pratica, assegni il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare font diversi all'interno di una singola cella?**

Sì. Il riquadro di testo di una cella supporta [porzioni](https://reference.aspose.com/slides/net/aspose.slides/portion/) (run) con formattazione indipendente—famiglia del font, stile, dimensione e colore.