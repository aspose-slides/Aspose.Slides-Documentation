---
title: Gestire le tabelle di presentazione in .NET
linktitle: Gestisci tabella
type: docs
weight: 10
url: /it/net/manage-table/
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
- .NET
- C#
- Aspose.Slides
description: "Crea e modifica tabelle nelle diapositive PowerPoint con Aspose.Slides per .NET. Scopri semplici esempi di codice C# per ottimizzare i flussi di lavoro con le tabelle."
---
## **Introduzione**

Una tabella in PowerPoint è un modo efficiente per visualizzare e presentare informazioni. Le informazioni in una griglia di celle (disposte in righe e colonne) sono semplici e facili da comprendere.

Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/it/net/aspose.slides/table/) , l'interfaccia [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/) , la classe [Cell](https://reference.aspose.com/slides/it/net/aspose.slides/cell/) , l'interfaccia [ICell](https://reference.aspose.com/slides/it/net/aspose.slides/icell/) e altri tipi per consentire di creare, aggiornare e gestire le tabelle in ogni tipo di presentazione. 

## **Crea una tabella da zero**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
2. Ottieni un riferimento alla diapositiva tramite il suo indice. 
3. Definisci un array di `columnWidth`.
4. Definisci un array di `rowHeight`.
5. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/) alla diapositiva tramite il metodo [AddTable](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addtable/) .
6. Itera su ogni [ICell](https://reference.aspose.com/slides/it/net/aspose.slides/icell/) per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.
7. Unisci le prime due celle della prima riga della tabella. 
8. Accedi al [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) di un [ICell](https://reference.aspose.com/slides/it/net/aspose.slides/icell/) .
9. Aggiungi del testo al [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) .
10. Salva la presentazione modificata.

Questo codice C# mostra come creare una tabella in una presentazione:

```c#
// Crea un'istanza della classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();

// Accede alla prima diapositiva
ISlide sld = pres.Slides[0];

// Definisce le colonne con larghezze e le righe con altezze
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Aggiunge una forma tabella alla diapositiva
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Imposta il formato del bordo per ogni cella
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// Unisce le celle 1 e 2 della riga 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Aggiunge del testo alla cella unita
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Salva la presentazione su disco
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Numerazione in una tabella standard**

In una tabella standard, la numerazione delle celle è semplice e parte da zero. La prima cella di una tabella è indicizzata come 0,0 (colonna 0, riga 0). 

Ad esempio, le celle in una tabella con 4 colonne e 4 righe sono numerate in questo modo:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Questo codice C# mostra come specificare la numerazione delle celle in una tabella:

```c#
// Crea un'istanza della classe Presentation che rappresenta un file PPTX
using (Presentation pres = new Presentation())
{

    // Accede alla prima diapositiva
    ISlide sld = pres.Slides[0];

    // Definisce colonne con larghezze e righe con altezze
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Aggiunge una forma tabella alla diapositiva
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Imposta il formato del bordo per ogni cella
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
			cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderTop.Width = 5;

			cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderBottom.Width = 5;

			cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderLeft.Width = 5;

			cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Salva la presentazione su disco
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Accedi a una tabella esistente**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
2. Ottieni un riferimento alla diapositiva che contiene la tabella tramite il suo indice. 
3. Crea un oggetto [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/) e impostalo a null.
4. Itera su tutti gli oggetti [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/) finché non trovi la tabella.

   Se sospetti che la diapositiva in questione contenga una sola tabella, puoi semplicemente verificare tutte le forme che contiene. Quando una forma è identificata come una tabella, puoi effettuare un cast a oggetto [Table](https://reference.aspose.com/slides/it/net/aspose.slides/table/) . Ma se la diapositiva contiene diverse tabelle, è consigliabile cercare la tabella desiderata tramite il suo [AlternativeText](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/alternativetext/) .
5. Utilizza l'oggetto [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/) per lavorare con la tabella. Nell'esempio sotto, abbiamo aggiunto una nuova riga alla tabella.
6. Salva la presentazione modificata.

Questo codice C# mostra come accedere e lavorare con una tabella esistente:

```c#
// Crea un'istanza della classe Presentation che rappresenta un file PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Accede alla prima diapositiva
    ISlide sld = pres.Slides[0];

    // Inizializza TableEx nullo
    ITable tbl = null;

    // Itera tra le forme e imposta un riferimento alla tabella trovata
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Imposta il testo per la prima colonna della seconda riga
    tbl[0, 1].TextFrame.Text = "New";

    // Salva la presentazione modificata su disco
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Allinea il testo in una tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
2. Ottieni un riferimento alla diapositiva tramite il suo indice. 
3. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/) alla diapositiva. 
4. Accedi a un oggetto [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) dalla tabella. 
5. Accedi all'[IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/) dell'[ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) .
6. Allinea il testo verticalmente.
7. Salva la presentazione modificata.

Questo codice C# mostra come allineare il testo in una tabella:

```c#
// Creates an instance of the Presentation class
Presentation presentation = new Presentation();

// Gets the first slide 
ISlide slide = presentation.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Adds the table shape to the slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Accesses the text frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Creates the Paragraph object for the text frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Creates the Portion object for paragraph
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligns the text vertically
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Saves the presentation to disk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Imposta la formattazione del testo a livello di tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) .
2. Ottieni un riferimento alla diapositiva tramite il suo indice. 
3. Accedi a un oggetto [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/) dalla diapositiva.
4. Imposta il [FontHeight](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/fontheight/) per il testo. 
5. Imposta l'[Alignment](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/alignment/) e il [MarginRight](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/marginright/) .
6. Imposta il [TextVerticalType](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat/textverticaltype/) .
7. Salva la presentazione modificata. 

Questo codice C# mostra come applicare le opzioni di formattazione preferite al testo in una tabella:

```c#
// Crea un'istanza della classe Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Supponiamo che la prima forma nella prima diapositiva sia una tabella

// Imposta l'altezza del carattere delle celle della tabella
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Imposta l'allineamento del testo e il margine destro delle celle della tabella in un'unica chiamata
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Imposta il tipo di orientamento verticale del testo delle celle della tabella
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Ottieni le proprietà di stile della tabella**

Aspose.Slides consente di recuperare le proprietà di stile di una tabella in modo da poter utilizzare questi dettagli per un'altra tabella o altrove. Questo codice C# mostra come ottenere le proprietà di stile da uno stile predefinito di tabella: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // cambia il tema predefinito dello stile preimpostato
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Blocca le proporzioni di una tabella**

Il rapporto d'aspetto di una forma geometrica è il rapporto tra le sue dimensioni in diverse direzioni. Aspose.Slides fornisce la proprietà `AspectRatioLocked` per consentire di bloccare l'impostazione del rapporto d'aspetto per tabelle e altre forme. 

Questo codice C# mostra come bloccare il rapporto d'aspetto per una tabella:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // inverti

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un'intera tabella e il testo nelle sue celle?**

Sì. La tabella espone la proprietà [RightToLeft](https://reference.aspose.com/slides/it/net/aspose.slides/table/righttoleft/) e i paragrafi hanno [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/it/net/aspose.slides/paragraphformat/righttoleft/). L'utilizzo di entrambe garantisce l'ordine RTL corretto e il rendering all'interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Utilizza i [shape locks](/slides/it/net/applying-protection-to-presentation/) per disabilitare lo spostamento, il ridimensionamento, la selezione, ecc. questi blocchi si applicano anche alle tabelle.

**L'inserimento di un'immagine all'interno di una cella come sfondo è supportato?**

Sì. È possibile impostare un [picture fill](https://reference.aspose.com/slides/it/net/aspose.slides/picturefillformat/) per una cella; l'immagine coprirà l'area della cella in base alla modalità scelta (stretch o tile).