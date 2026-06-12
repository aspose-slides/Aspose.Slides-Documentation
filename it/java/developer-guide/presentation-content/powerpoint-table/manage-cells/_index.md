---
title: Gestisci le celle della tabella nelle presentazioni usando Java
linktitle: Gestisci Celle
type: docs
weight: 30
url: /it/java/manage-cells/
keywords:
- cella della tabella
- unire celle
- rimuovere bordo
- dividere cella
- immagine nella cella
- colore di sfondo
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Gestisci facilmente le celle della tabella in PowerPoint con Aspose.Slides per Java. Impara ad accedere, modificare e formattare le celle rapidamente per un'automazione fluida delle diapositive."
---
## **Panoramica**

Aspose.Slides ti consente di accedere e modificare le celle delle tabelle nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle di tabella unite, rimuovere i bordi delle celle, lavorare con la numerazione delle celle dopo l'unione o la divisione delle celle, cambiare il colore di sfondo di una cella e aggiungere un'immagine all'interno di una cella di tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione delle celle tramite le proprietà della cella e salvare la presentazione modificata come file PPTX.

## **Identificare una cella di tabella unita**
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Ottieni la tabella dalla prima diapositiva. 
3. Scorri le righe e le colonne della tabella per trovare le celle unite.
4. Stampa un messaggio quando vengono trovate celle unite.

Questo codice Java mostra come identificare le celle di tabella unite in una presentazione:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // presumendo che Slide#0.Shape#0 sia una tabella
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rimuovere i bordi delle celle della tabella**
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Definisci un array di colonne con larghezza.
4. Definisci un array di righe con altezza.
5. Aggiungi una tabella alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Scorri ogni cella per cancellare i bordi superiore, inferiore, destro e sinistro.
7. Salva la presentazione modificata come file PPTX.

Questo codice Java mostra come rimuovere i bordi dalle celle della tabella:

```java
// Istanzia la classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accede alla prima diapositiva
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Definisce colonne con larghezze e righe con altezze
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Aggiunge la forma tabella alla diapositiva
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Imposta il formato del bordo per ogni cella
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // Scrive il PPTX su disco
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numerazione nelle celle unite**
Se uniamo 2 coppie di celle (1, 1) x (2, 1) e (1, 2) x (2, 2), la tabella risultante sarà numerata. Questo codice Java dimostra il processo:

```java
// Istanzia la classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accede alla prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Definisce colonne con larghezze e righe con altezze
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Aggiunge una forma tabella alla diapositiva
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Imposta il formato del bordo per ogni cella
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Unisce le celle (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Unisce le celle (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Quindi uniamo ulteriormente le celle unendo (1, 1) e (1, 2). Il risultato è una tabella che contiene una grande cella unita al centro:

```java
// Istanzia la classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accede alla prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Definisce colonne con larghezze e righe con altezze
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Aggiunge una forma tabella alla diapositiva
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Imposta il formato del bordo per ogni cella
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
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
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numerazione in una cella divisa**
Negli esempi precedenti, quando le celle della tabella venivano unite, la numerazione o il sistema numerico nelle altre celle non cambiava.

Questa volta prendiamo una tabella regolare (una tabella senza celle unite) e proviamo a dividere la cella (1,1) per ottenere una tabella speciale. Potresti voler prestare attenzione alla numerazione di questa tabella, che può apparire strana. Tuttavia, è così che Microsoft PowerPoint numera le celle delle tabelle e Aspose.Slides fa lo stesso.

Questo codice Java dimostra il processo descritto:

```java
// Istanzia la classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accede alla prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Definisce colonne con larghezze e righe con altezze
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Aggiunge una forma tabella alla diapositiva
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Imposta il formato del bordo per ogni cella
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Unisce le celle (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Unisce le celle (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Divide la cella (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    //Scrive il file PPTX su disco
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modificare il colore di sfondo della cella della tabella**

Questo codice Java mostra come cambiare il colore di sfondo di una cella della tabella:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    //    crea una nuova tabella
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    //    imposta il colore di sfondo per una cella 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Aggiungere un'immagine all'interno di una cella di tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Ottieni il riferimento a una diapositiva tramite il suo indice.
3. Definisci un array di colonne con larghezza.
4. Definisci un array di righe con altezza.
5. Aggiungi una tabella alla diapositiva tramite il metodo [AddTable](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Crea un oggetto `Images` per contenere il file immagine.
7. Aggiungi l'immagine `IImage` all'oggetto `IPPImage`.
8. Imposta il `FillFormat` per la cella della tabella su `Picture`.
9. Aggiungi l'immagine alla prima cella della tabella.
10. Salva la presentazione modificata come file PPTX

Questo codice Java mostra come inserire un'immagine all'interno di una cella di tabella durante la creazione di una tabella:

```java
// Istanzia la classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accede alla prima diapositiva
    ISlide islide = pres.getSlides().get_Item(0);

    // Definisce colonne con larghezze e righe con altezze
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Aggiunge una forma tabella alla diapositiva
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Crea un oggetto IPPImage usando il file immagine
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Aggiunge l'immagine alla prima cella della tabella
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Salva il file PPTX su disco
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso impostare spessori e stili di linea differenti per i lati di una singola cella?**

Sì. I bordi [top](https://reference.aspose.com/slides/it/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/it/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/it/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/it/java/com.aspose.slides/cellformat/#getBorderRight--) hanno proprietà separate, quindi lo spessore e lo stile di ciascun lato possono differire. Questo segue logicamente dal controllo dei bordi per lato di una cella dimostrato nell'articolo.

**Cosa succede all'immagine se modifico la dimensione della colonna/riga dopo aver impostato un'immagine come sfondo della cella?**

Il comportamento dipende dalla [modalità di riempimento](https://reference.aspose.com/slides/it/java/com.aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l'immagine si adatta alla nuova cella; con il tiling, le tessere vengono ricalcolate. L'articolo menziona le modalità di visualizzazione dell'immagine in una cella.

**Posso assegnare un collegamento ipertestuale a tutto il contenuto di una cella?**

I [Hyperlinks](/slides/it/java/manage-hyperlinks/) vengono impostati a livello di testo (porzione) all'interno del frame di testo della cella o a livello dell'intera tabella/forma. In pratica, assegni il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare font differenti all'interno di una singola cella?**

Sì. Il frame di testo di una cella supporta le [porzioni](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/) (run) con formattazione indipendente—famiglia di font, stile, dimensione e colore.