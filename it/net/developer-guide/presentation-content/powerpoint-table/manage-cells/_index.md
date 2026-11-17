---
title: Gestisci le celle della tabella nelle presentazioni in .NET
linktitle: Gestisci celle
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

Aspose.Slides consente di accedere e modificare le celle di una tabella nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle di tabella unite, rimuovere i bordi delle celle, gestire la numerazione delle celle dopo l’unione o la divisione delle celle, cambiare il colore di sfondo di una cella e aggiungere un’immagine all’interno di una cella di tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione delle celle tramite le proprietà della cella e salvare la presentazione modificata come file PPTX.

Aspose.Slides utilizza indici basati su zero per accedere alle celle della tabella nell'ordine `(colonna, riga)`.

## **Identifica una cella di tabella unita**

L'esempio apre una presentazione esistente e accede alla prima forma nella prima diapositiva come tabella. Presume che la diapositiva e la forma esistano e che la forma sia una tabella. Quindi itera attraverso tutte le righe e le colonne e utilizza [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) per identificare le celle nelle regioni unite. Per ogni corrispondenza, stampa le coordinate della cella nell'ordine `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), e le coordinate iniziali della regione, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) e [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

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

## **Rimuovi i bordi della cella della tabella**

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

## **Aggiungi bordi diagonali alle celle**

Usa [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) per disegnare una linea dall'angolo in alto a sinistra a quello in basso a destra, e [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) per disegnare una linea dall'angolo in basso a sinistra a quello in alto a destra. Una diagonale può indicare un'intestazione d'angolo; entrambe le diagonali possono formare una X per contrassegnare una cella come non applicabile.

Ogni diagonale è un [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). Nella sua [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/), imposta [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) su [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) e scegli un [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/). Imposta la [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) della linea in punti.

L'esempio crea tre celle in una riga: una diagonale rossa verso il basso, una diagonale blu verso l'alto e entrambe le diagonali. Lascia inalterati i bordi superiore, inferiore, sinistro e destro della cella.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

Una diagonale è una proprietà di formattazione, non una divisione della cella. Ogni cella conserva un unico [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/); le regioni ai due lati di una diagonale non possono essere modificate in modo indipendente.

The saved table, rendered in Microsoft PowerPoint:

![Tre celle di tabella che mostrano una diagonale rossa dall'angolo in alto a sinistra a quello in basso a destra, una diagonale blu dall'angolo in basso a sinistra a quello in alto a destra, e entrambe le diagonali che formano una X.](diagonal-cell-borders.png)

*Da sinistra a destra: diagonale verso il basso (rossa, 3 pt), diagonale verso l'alto (blu, 5 pt) e entrambe le diagonali.*

## **Unisci celle della tabella**

Utilizza [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) per combinare un intervallo rettangolare di celle della tabella in una singola cella. Specifica le celle negli angoli in alto a sinistra e in basso a destra dell'intervallo. L'ultimo argomento controlla se l'unione può includere celle al di fuori dell'intervallo specificato; `false` mantiene l'unione all'interno di quell'intervallo.

L'esempio crea una tabella 4x4 con colonne e righe da 70 punti, quindi unisce le quattro celle centrali da `(1, 1)` a `(2, 2)`. La cella risultante occupa due colonne e due righe, mentre la griglia sottostante della tabella mantiene quattro colonne e quattro righe. Per accedere al contenuto o alla formattazione della cella unita, usa la sua posizione in alto a sinistra: `table[1, 1]` in questo esempio. Le altre posizioni nell'intervallo unito rimangono parte della griglia della tabella, quindi gli indici delle celle al di fuori dell'intervallo non cambiano.

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

## **Dividi celle della tabella**

L'unione delle celle nell'esempio precedente mantiene la griglia della tabella. Dividere una cella può introdurre una nuova colonna nella griglia e modificare gli indici di colonna delle celle a destra. Aspose.Slides segue il modello di griglia delle tabelle di PowerPoint.

Questo esempio crea una tabella 4x4 con colonne e righe da 70 punti e chiama [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) sulla cella `(1, 1)`. Metà della larghezza di 70 punti della cella viene utilizzata per creare due celle di larghezza uguale.

Dopo questa divisione, le due metà sono accessibili come `table[1, 1]` e `table[2, 1]`. La griglia della tabella ora ha cinque colonne: le celle originariamente nelle colonne 2 e 3 si spostano rispettivamente alle colonne 3 e 4. Gli indici di riga rimangono invariati. Usa questi indici di colonna aggiornati quando accedi alle celle dopo la divisione.

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

### **Dividi celle unite per estensione di riga o colonna**

Per preparare le celle modello unite per il popolamento dei dati, usa [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) per dividere lungo un confine di riga esistente, o [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) per dividere lungo un confine di colonna.

L'argomento `index` conta le righe nella parte superiore o le colonne nella parte sinistra della divisione; è relativo alla regione unita:

- Divisione di riga: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Divisione di colonna: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

L'esempio si aspetta che una presentazione abbia una tabella come prima forma sulla prima diapositiva, con `(1, 2)` e `(1, 3)` unite verticalmente. Partendo dalla posizione inferiore, utilizza [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) e [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) per localizzare l'origine e verifica entrambe le estensioni. `SplitByRowSpan(1)` separa quindi le righe 2 e 3 per i nomi dei prodotti. Per un'unione orizzontale a due colonne, usa invece `SplitByColSpan(1)`.

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

La griglia della tabella e gli indici delle celle circostanti rimangono invariati. Recupera le celle risultanti mediante le loro coordinate; qui, entrambe hanno estensioni di 1 e [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) stampa `False`. Regioni più grandi possono rimanere parzialmente unite dopo una divisione.

Il testo originale e la sua formattazione rimangono nella cella superiore (o sinistra); la nuova cella è vuota ma eredita la formattazione della cella come riempimento, bordi e margini. Popola le celle dopo la divisione e imposta esplicitamente qualsiasi formattazione del testo richiesta.

La presentazione salvata contiene celle separate "Product A" e "Product B" con la formattazione della cella del modello conservata. Consulta il [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) per i dettagli.

<!-- visual-explanation:manage-cells:start -->
[![La cella unita nella colonna 1, righe 2 e 3 si divide in Product A e Product B con gli stessi indici di griglia.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*La divisione per estensione di riga utilizza il confine esistente. Product A e Product B occupano rispettivamente (1, 2) e (1, 3).*
<!-- visual-explanation:manage-cells:end -->

### **Dividi una cella a un'altezza specifica**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) prende l'altezza della parte superiore in punti. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) prende il numero di righe della griglia esistenti nella parte superiore. Per centrare una cella da 40 punti nella colonna di destra, sottrai 40 dall'altezza reale della cella e dividi lo spazio rimanente equamente sopra e sotto.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

La prima divisione aggiunge una riga alla griglia, lasciando i 90 punti inferiori a `[1, 1]`. La seconda divisione mira a quella cella e aggiunge un'altra riga sotto di essa. La colonna di destra ora contiene `[1, 0]` a 50 punti (`margin`), `[1, 1]` a 40 punti e `[1, 2]` a 50 punti (`margin`). La cella sinistra si estende su tutte e tre le righe con la sua altezza originale di 140 punti.

![La cella sinistra si estende per l'intera altezza della tabella accanto a tre celle con Middle al centro.](split-by-height.png)

## **Cambia il colore di sfondo della cella della tabella**

Questo esempio crea una tabella con colonne da 150 punti e righe da 50 punti. Imposta [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) su solid e [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) su rosso per la cella `(2, 3)`, nella terza colonna e quarta riga.

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

## **Aggiungi un'immagine all'interno di una cella della tabella**

Posiziona l'immagine di input nella directory di lavoro prima di eseguire questo esempio. Carica l'immagine con [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) e la aggiunge alla collezione di immagini della presentazione con [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Quindi assegna l'immagine al riempimento immagine della cella `(0, 0)`, la prima cella nella tabella.

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

**Posso impostare spessori e stili di linea diversi per i lati diversi di una singola cella?**

Sì. I bordi [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) hanno proprietà separate, quindi lo spessore e lo stile di ogni lato possono differire.

**Cosa succede all'immagine se modifico la dimensione della colonna/riga dopo aver impostato un'immagine come sfondo della cella?**

Il comportamento dipende dal [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l'immagine si adatta alla nuova cella; con il tiling, le piastrelle vengono ricalcolate.

**Posso assegnare un collegamento ipertestuale a tutto il contenuto di una cella?**

[Hyperlinks](/slides/it/net/manage-hyperlinks/) sono impostati a livello di testo (porzione) all'interno del text frame della cella o a livello dell'intera tabella/shape. In pratica, assegni il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare caratteri diversi all'interno di una singola cella?**

Sì. Il text frame di una cella supporta le [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (run) con formattazione indipendente — famiglia del carattere, stile, dimensione e colore.