---
title: Gestisci le tabelle delle presentazioni in .NET
linktitle: Gestisci tabella
type: docs
weight: 10
url: /it/net/manage-table/
keywords:
- aggiungere tabella
- creare tabella
- accedere tabella
- rapporto di aspetto
- allineare testo
- formattazione testo
- stile tabella
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Crea e modifica tabelle nelle diapositive PowerPoint con Aspose.Slides per .NET. Scopri semplici esempi di codice C# per semplificare i tuoi flussi di lavoro con le tabelle."
---
## **Introduzione**

Le tabelle in PowerPoint organizzano le informazioni in righe e colonne, facilitando la lettura e il confronto dei valori.

Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/net/aspose.slides/table/), l’interfaccia [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/), la classe [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/), l’interfaccia [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) e altri tipi per consentire di creare, aggiornare e gestire le tabelle nelle presentazioni.

## **Creare una tabella da zero**

Crea una tabella specificando la sua posizione, le larghezze delle colonne e le altezze delle righe. Dopo averla aggiunta a una diapositiva, è possibile formattare i bordi delle celle, unire le celle e inserire testo.

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Definisci un array di larghezze delle colonne in punti.
4. Definisci un array di altezze delle righe in punti.
5. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) alla diapositiva tramite il metodo [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. Scorri ogni [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.
7. Unisci le prime due celle della prima riga della tabella.
8. Accedi alla cella unita tramite la sua proprietà [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/).
9. Imposta il testo nella cella unita.
10. Salva la presentazione modificata.

L’esempio seguente crea una tabella con tre colonne e cinque righe in (100, 50) punti. Applica bordi rossi con spessore di 5 punti, unisce le prime due celle della prima riga e salva il risultato in `table.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Numerazione in una tabella standard**

In una tabella standard, gli indici delle celle sono basati su zero e usano l’ordine (colonna, riga). La prima cella ha indice (0, 0).

Ad esempio, le celle di una tabella con 4 colonne e 4 righe sono numerate così:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Questo esempio crea la tabella 4 × 4 illustrata sopra, con larghezze delle colonne e altezze delle righe di 70 punti e bordi rossi di 5 punti. Le coordinate illustrano gli indici delle celle; l’esempio lascia le celle vuote e salva la tabella in `StandardTables_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **Accedere a una tabella esistente**

Le tabelle sono archiviate nella raccolta forme di una diapositiva. Scorri le forme per individuare una tabella, quindi usa l’interfaccia [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) per leggere o aggiornare le sue celle.

1. Carica la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva che contiene la tabella tramite il suo indice.
3. Scorri gli oggetti [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) e interrompi quando trovi una tabella. Se la diapositiva contiene più tabelle, usa [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) per identificare quella necessaria.
4. Aggiorna il testo nella cella di destinazione.
5. Salva la presentazione modificata.

L’esempio seguente apre `UpdateExistingTable.pptx` e trova la prima tabella nella prima diapositiva. Imposta la cella alla colonna 0, riga 1 su `New` e salva il risultato in `table1_out.pptx`. L’input deve contenere almeno una diapositiva, e la prima tabella su quella diapositiva deve avere almeno una colonna e due righe.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

Per ridimensionare una riga in una tabella esistente e capire perché la sua altezza reale può superare il minimo richiesto, vedi [Control Row Height](/slides/it/net/manage-rows-and-columns/#control-row-height).

## **Trovare la cella che possiede un Text Frame**

Quando del codice generico di elaborazione del testo riceve un [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) da una tabella, usa la proprietà [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) per recuperare la [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) proprietaria. Per un text frame di cella tabella, [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) è impostato e [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) è `null`, anche se la tabella stessa è una forma.

Le coordinate della cella sono disponibili tramite le proprietà di sola lettura [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) e [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/). [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) è anchessa di sola lettura: fornisce la navigazione al proprietario ma non ne cambia la proprietà. Controlla sempre se la cella restituita è `null` prima di usarla.

Per un esempio completo che identifica i proprietari di celle tabella e di forme, incluse le forme associate ai nodi SmartArt, vedi [Search and Replace Text](/slides/it/net/search-and-replace-text/).

## **Allineare il testo in una tabella**

È possibile controllare l’ancoraggio verticale e la direzione del testo di singole celle tabella. L’esempio in questa sezione centra il testo nella prima cella e lo ruota di 270 gradi.

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) alla diapositiva.
4. Accedi a un oggetto [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) dalla tabella.
5. Accedi al primo [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) e imposta il suo testo e colore.
6. Imposta il tipo di ancoraggio [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) e il tipo verticale [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) della cella.
7. Salva la presentazione modificata.

Questo esempio crea una tabella 4 × 4 con larghezze delle colonne di 120 punti e altezze delle righe di 100 punti. Formatizza il testo nella cella (0, 0), aggiunge valori alle celle rimanenti nella prima riga e salva il risultato in `Vertical_Align_Text_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Impostare la formattazione del testo a livello di tabella**

Usa [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) per applicare la formattazione del testo a tutte le celle di una tabella. I suoi overload accettano la formattazione di porzione, paragrafo e text frame, così è possibile impostare queste proprietà senza scorrere le singole celle.

1. Carica la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Accedi a un oggetto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) dalla diapositiva.
4. Imposta il [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) per il testo.
5. Imposta l’[Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) e il [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. Imposta il [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Salva la presentazione modificata.

L’esempio seguente apre `table.pptx`, che deve contenere almeno una diapositiva con una tabella come prima forma. Imposta la dimensione del carattere a 25 punti, allinea a destra i paragrafi con un margine destro di 20 punti e rende il testo verticale. La presentazione formattata viene salvata in `result.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **Ottenere le proprietà di stile della tabella**

Usa [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) per leggere o assegnare lo stile predefinito di una tabella. Questo esempio applica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) a una tabella, stampa il nome del preset e assegna lo stesso preset a una seconda tabella. Entrambe le tabelle sono salvate in `table-style.pptx`.

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

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **Bloccare il rapporto di aspetto di una tabella**

Il rapporto di aspetto di una tabella è il rapporto tra la sua larghezza e la sua altezza. Usa [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) per bloccare questo rapporto per una tabella.

L’esempio seguente apre `pres.pptx`, che deve contenere almeno una diapositiva con una tabella come prima forma. Stampa lo stato attuale del blocco, abilita il blocco del rapporto di aspetto, stampa lo stato aggiornato (`True`) e salva il risultato in `pres-out.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un’intera tabella e per il testo nelle sue celle?**

Sì. La tabella espone la proprietà [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/), e i paragrafi hanno [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/). L’uso di entrambi garantisce l’ordine RTL corretto e la resa all’interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Usa i [shape locks](/slides/it/net/applying-protection-to-presentation/) per disabilitare lo spostamento, il ridimensionamento, la selezione, ecc. Questi blocchi si applicano anche alle tabelle.

**È supportato l’inserimento di un’immagine all’interno di una cella come sfondo?**

Sì. È possibile impostare un [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) per una cella; l’immagine coprirà l’area della cella secondo la modalità scelta (stretch o tile).