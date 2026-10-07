---
title: Gestire le celle della tabella nelle presentazioni con Java
linktitle: Gestire le celle
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
description: "Gestisci le celle delle tabelle PowerPoint in Java: identifica le celle unite, rimuovi i bordi, dividi le celle e imposta colori di sfondo e immagini con Aspose.Slides per Java."
---
## **Panoramica**

Aspose.Slides consente di accedere e modificare le celle di una tabella nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle di tabella unite, rimuovere i bordi delle celle, gestire la numerazione delle celle dopo l'unione o la divisione delle celle, modificare il colore di sfondo di una cella e aggiungere un'immagine all'interno di una cella di tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione delle celle tramite le proprietà della cella e salvare la presentazione modificata come file PPTX.

Aspose.Slides utilizza indici a base zero per accedere alle celle della tabella nell'ordine `(column, row)`.

## **Identificare una cella di tabella unita**

L'esempio apre una presentazione esistente e accede alla prima forma nella prima diapositiva come tabella. Si presume che la diapositiva e la forma esistano e che la forma sia una tabella. Poi itera attraverso tutte le righe e le colonne e utilizza [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) per identificare le celle nelle regioni unite. Per ogni corrispondenza, stampa le coordinate della cella nell'ordine `row;column`, [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--), e le coordinate iniziali della regione, [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) e [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Rimuovere i bordi delle celle della tabella**

Crea una [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) e aggiungi una tabella alla sua prima diapositiva con [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Le larghezze delle colonne, le altezze delle righe e la posizione della tabella sono specificate in punti. L'esempio imposta tutti e quattro i bordi della cella su [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/), rendendoli invisibili.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Unire le celle della tabella**

Usa [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) per combinare un intervallo rettangolare di celle della tabella in una singola cella. Specifica le celle negli angoli in alto a sinistra e in basso a destra dell'intervallo. L'ultimo argomento controlla se l'unione può includere celle al di fuori dell'intervallo specificato; `false` mantiene l'unione all'interno di quell'intervallo.

L'esempio crea una tabella 4x4 con colonne e righe di 70 punti, quindi unisce le quattro celle centrali da `(1, 1)` a `(2, 2)`. La cella risultante occupa due colonne e due righe, mentre la griglia sottostante della tabella mantiene quattro colonne e quattro righe. Per accedere al contenuto o alla formattazione della cella unita, usa la sua posizione in alto a sinistra: `table.get_Item(1, 1)` in questo esempio. Le altre posizioni nell'intervallo unito rimangono parte della griglia della tabella, quindi gli indici delle celle al di fuori dell'intervallo non cambiano.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dividere le celle della tabella**

L'unione delle celle nell'esempio precedente preserva la griglia della tabella. Dividere una cella può introdurre una nuova colonna nella griglia e modificare gli indici di colonna delle celle a destra. Aspose.Slides segue il modello di griglia delle tabelle di PowerPoint.

Questo esempio crea una tabella 4x4 con colonne e righe di 70 punti e chiama [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) sulla cella `(1, 1)`. Metà della larghezza di 70 punti della cella viene passata per creare due celle di larghezza uguale.

Dopo questa divisione, le due metà sono accessibili come `table.get_Item(1, 1)` e `table.get_Item(2, 1)`. La griglia della tabella ora ha cinque colonne: le celle originariamente nelle colonne 2 e 3 si spostano rispettivamente nelle colonne 3 e 4. Gli indici delle righe rimangono invariati. Usa questi indici di colonna aggiornati quando accedi alle celle dopo la divisione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Dividere le celle unite per intervallo di riga o colonna**

Per preparare le celle modello unite per il popolamento dei dati, usa [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) per dividere lungo una linea di suddivisione di riga esistente, oppure [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) per dividere lungo una linea di colonna.

L'argomento `index` conta le righe nella parte superiore o le colonne nella parte sinistra della divisione; è relativo alla regione unita:

- Divisione di riga: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- Divisione di colonna: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

L'esempio presuppone che una presentazione contenga una tabella come prima forma nella prima diapositiva, con `(1, 2)` e `(1, 3)` unite verticalmente. Partendo dalla posizione inferiore, utilizza [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) e [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) per individuare l'origine e verifica entrambi gli span. `splitByRowSpan(1)` separa quindi le righe 2 e 3 per i nomi dei prodotti. Per un'unione orizzontale di due colonne, usa invece `splitByColSpan(1)`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // Recupera le celle risultanti dalla tabella dopo la divisione.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

La griglia della tabella e gli indici delle celle circostanti rimangono invariati. Recupera le celle risultanti tramite le loro coordinate; qui entrambe hanno span di 1 e [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) stampa `false`. Regioni più grandi possono rimanere parzialmente unite dopo una divisione.

Il testo originale e la sua formattazione rimangono nella cella superiore (o sinistra); la nuova cella è vuota ma eredita la formattazione della cella come riempimento, bordi e margini. Popola le celle dopo la divisione e imposta esplicitamente qualsiasi formattazione del testo necessaria.

La presentazione salvata contiene celle separate "Product A" e "Product B" con la formattazione della cella del modello mantenuta. Consulta la [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) per i dettagli.

## **Modificare il colore di sfondo della cella della tabella**

Questo esempio crea una tabella con colonne di 150 punti e righe di 50 punti. Utilizza [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) per selezionare un riempimento solido e imposta il colore restituito da [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) su rosso per la cella `(2, 3)`, nella terza colonna e quarta riga.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aggiungere un'immagine all'interno di una cella della tabella**

Posiziona l'immagine di input nella directory di lavoro prima di eseguire questo esempio. Carica l'immagine con [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) e la aggiunge alla collezione di immagini della presentazione con [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Quindi assegna l'immagine al riempimento immagine della cella `(0, 0)`, la prima cella nella tabella.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) allunga l'immagine per riempire la cella, il che può modificare il suo rapporto d'aspetto. Le larghezze delle colonne e le altezze delle righe sono in punti. L'immagine caricata viene rilasciata in un blocco `finally` dopo essere stata aggiunta alla presentazione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso impostare spessori e stili di linea diversi per i diversi lati di una singola cella?**

Sì. I bordi [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) hanno proprietà separate, quindi lo spessore e lo stile di ciascun lato possono differire.

**Cosa succede all'immagine se modifico le dimensioni della colonna/riga dopo aver impostato un'immagine come sfondo della cella?**

Il comportamento dipende dal [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l'immagine si adatta alla nuova cella; con il tiling, le piastrelle vengono ricalcolate.

**Posso assegnare un collegamento ipertestuale a tutto il contenuto di una cella?**

[Hyperlinks](/slides/it/java/manage-hyperlinks/) vengono impostati a livello di testo (porzione) all'interno del frame di testo della cella o a livello dell'intera tabella/forma. In pratica, assegni il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare caratteri diversi all'interno di una singola cella?**

Sì. Il frame di testo di una cella supporta le [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (run) con formattazione indipendente — famiglia di caratteri, stile, dimensione e colore.