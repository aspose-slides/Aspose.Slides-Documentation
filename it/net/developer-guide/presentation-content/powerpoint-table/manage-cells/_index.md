---
title: Gestire le celle delle tabelle nelle presentazioni in .NET
linktitle: Gestisci le celle
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
description: "Gestisci facilmente le celle delle tabelle in PowerPoint con Aspose.Slides per .NET. Impara ad accedere, modificare e formattare le celle rapidamente per un'automazione delle diapositive senza intoppi."
---
## **Panoramica**

Aspose.Slides consente di accedere e modificare le celle di una tabella nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle di tabella unite, rimuovere i bordi delle celle, gestire la numerazione delle celle dopo l'unione o la divisione, cambiare il colore di sfondo di una cella e aggiungere un'immagine all'interno di una cella di tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione delle celle tramite le proprietà della cella e salvare la presentazione modificata come file PPTX.

## **Identificare una cella di tabella unita**

1. Crea un'istanza della [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) class.
2. Ottieni la tabella dalla prima diapositiva. 
3. Itera sulle righe e colonne della tabella per trovare le celle unite.
4. Stampa un messaggio quando vengono trovate celle unite.

Questo codice C# mostra come identificare le celle di tabella unite in una presentazione:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // presumendo che Slide#0.Shape#0 sia una tabella
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **Rimuovere i bordi delle celle della tabella**
1. Crea un'istanza della classe `Presentation`.
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Definisci un array di colonne con larghezza.
4. Definisci un array di righe con altezza.
5. Aggiungi una tabella alla diapositiva tramite il metodo `AddTable`.
6. Itera su ogni cella per cancellare i bordi superiore, inferiore, destro e sinistro.
7. Salva la presentazione modificata come file PPTX.

Questo codice C# mostra come rimuovere i bordi dalle celle di una tabella:

```c#
// Istanzia la classe Presentation che rappresenta un file PPTX
using (Presentation pres = new Presentation())
{
   // Accede alla prima diapositiva
    Slide sld = (Slide)pres.Slides[0];

    // Definisce colonne con larghezze e righe con altezze
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Aggiunge la forma della tabella alla diapositiva
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Imposta il formato del bordo per ogni cella
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Scrive il file PPTX su disco
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Numerazione nelle celle unite**
Se uniamo 2 coppie di celle (1, 1) x (2, 1) e (1, 2) x (2, 2), la tabella risultante sarà numerata. Questo codice C# dimostra il processo:

```c#
 // Istanzia la classe Presentation che rappresenta un file PPTX
using (Presentation presentation = new Presentation())
{
    // Accede alla prima diapositiva
    ISlide sld = presentation.Slides[0];

    // Definisce colonne con larghezze e righe con altezze
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Aggiunge una forma di tabella alla diapositiva
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

    // Unisce le celle (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Unisce le celle (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

Successivamente uniamo ulteriormente le celle unendo (1, 1) e (1, 2). Il risultato è una tabella contenente una grande cella unita al centro:

```c#
 // Istanzia la classe Presentation che rappresenta un file PPTX
using (Presentation presentation = new Presentation())
{
    // Accede alla prima diapositiva
    ISlide slide = presentation.Slides[0];

    // Definisce colonne con larghezze e righe con altezze
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Aggiunge una forma di tabella alla diapositiva
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Imposta il formato del bordo per ogni cella
    foreach (IRow row in table.Rows)
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

    // Unisce le celle (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Unisce le celle (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Unisce le celle (1, 2) x (2, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    // Scrive il file PPTX su disco
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **Numerazione in una cella divisa**
Negli esempi precedenti, quando le celle di tabella erano unite, la numerazione o il sistema numerico nelle altre celle non cambiava.

Questa volta prendiamo una tabella regolare (una tabella senza celle unite) e proviamo a dividere la cella (1,1) per ottenere una tabella speciale. Prestate attenzione alla numerazione di questa tabella, che può apparire strana. Tuttavia, così Microsoft PowerPoint numerizza le celle delle tabelle e Aspose.Slides fa lo stesso.

Questo codice C# dimostra il processo descritto:

```c#
 // Istanzia la classe Presentation che rappresenta un file PPTX
using (Presentation presentation = new Presentation())
{
    // Accede alla prima diapositiva
    ISlide slide = presentation.Slides[0];

    // Definisce colonne con larghezze e righe con altezze
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Aggiunge una forma di tabella alla diapositiva
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Imposta il formato del bordo per ogni cella
    foreach (IRow row in table.Rows)
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

    // Unisce le celle (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Unisce le celle (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Divide la cella (1, 1). 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // Scrive il file PPTX su disco
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **Modificare il colore di sfondo della cella della tabella**

Questo codice C# mostra come cambiare il colore di sfondo di una cella di tabella:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // crea una nuova tabella
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // imposta il colore di sfondo per una cella 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Aggiungere un'immagine all'interno di una cella della tabella**

1. Crea un'istanza della classe `Presentation`.
2. Ottieni il riferimento di una diapositiva tramite il suo indice.
3. Definisci un array di colonne con larghezza.
4. Definisci un array di righe con altezza.
5. Aggiungi una tabella alla diapositiva tramite il metodo `AddTable`. 
6. Crea un oggetto `Bitmap` per contenere il file immagine.
7. Aggiungi l'immagine bitmap all'oggetto `IPPImage`.
8. Imposta il `FillFormat` per la cella della tabella su `Picture`.
9. Aggiungi l'immagine alla prima cella della tabella.
10. Salva la presentazione modificata come file PPTX

Questo codice C# mostra come inserire un'immagine all'interno di una cella di tabella durante la creazione della tabella:

```c#
 // Instantiates the Presentation class that represents a PPTX file
using (Presentation presentation = new Presentation())
{
    // Accesses the first slide
    ISlide slide = presentation.Slides[0];

    // Defines columns with widths and rows with heights
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Adds a table shape to the slide
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Loads an image from a file and adds it to the presentation resources
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Adds the image to the first table cell
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Saves the PPTX file to disk
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Posso impostare spessori e stili di linea diversi per i vari lati di una singola cella?**

Sì. I bordi [top](https://reference.aspose.com/slides/it/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/it/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/it/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/it/net/aspose.slides/cellformat/borderright/) hanno proprietà separate, quindi lo spessore e lo stile di ciascun lato possono differire. Questo segue logicamente dal controllo dei bordi per lato di una cella mostrato nell'articolo.

**Cosa succede all'immagine se modifico la dimensione della colonna/riga dopo aver impostato un'immagine come sfondo della cella?**

Il comportamento dipende dalla [fill mode](https://reference.aspose.com/slides/it/net/aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l'immagine si adatta alla nuova cella; con il tiling, le tessere vengono ricalcolate. L'articolo menziona le modalità di visualizzazione dell'immagine in una cella.

**Posso assegnare un collegamento ipertestuale a tutto il contenuto di una cella?**

[Hyperlinks](/slides/it/net/manage-hyperlinks/) sono impostati a livello di testo (portion) all'interno del frame di testo della cella o a livello dell'intera tabella/forma. In pratica, il collegamento si assegna a una porzione o a tutto il testo nella cella.

**Posso impostare caratteri diversi all'interno di una singola cella?**

Sì. Il frame di testo di una cella supporta le [portions](https://reference.aspose.com/slides/it/net/aspose.slides/portion/) (run) con formattazione indipendente—famiglia di caratteri, stile, dimensione e colore.