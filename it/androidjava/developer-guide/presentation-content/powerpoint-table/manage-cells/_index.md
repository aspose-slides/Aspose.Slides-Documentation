---
title: Gestire le celle delle tabelle nelle presentazioni su Android
linktitle: Gestisci celle
type: docs
weight: 30
url: /it/androidjava/manage-cells/
keywords:
- cella della tabella
- unire celle
- rimuovere bordi
- dividere cella
- immagine nella cella
- colore di sfondo
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Gestisci le celle delle tabelle PowerPoint su Android: identifica le celle unite, rimuovi i bordi, dividi le celle e imposta i colori di sfondo e le immagini con Aspose.Slides per Android tramite Java."
---
## **Panoramica**

Aspose.Slides consente di accedere e modificare le celle delle tabelle nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle di tabella unite, rimuovere i bordi delle celle, gestire la numerazione delle celle dopo l’unione o la divisione, cambiare il colore di sfondo di una cella e aggiungere un’immagine all’interno di una cella di tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione delle celle mediante le proprietà della cella e salvare la presentazione modificata come file PPTX.

Aspose.Slides utilizza indici a base zero per accedere alle celle delle tabelle nell’ordine `(column, row)`.

## **Identificare una cella di tabella unita**

L’esempio apre una presentazione esistente e accede alla prima forma sulla prima diapositiva come tabella. Si presume che la diapositiva e la forma esistano e che la forma sia una tabella. Successivamente itera su tutte le righe e colonne e utilizza [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) per identificare le celle in regioni unite. Per ogni corrispondenza stampa le coordinate della cella in ordine `row;column`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), e le coordinate di inizio della regione, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) e [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

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

Creare una [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) e aggiungere una tabella alla sua prima diapositiva con [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Larghezze delle colonne, altezze delle righe e posizione della tabella sono specificate in punti. L’esempio imposta tutti e quattro i bordi della cella su [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), rendendoli invisibili.

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

## **Aggiungere bordi diagonali alle celle**

Utilizzare [getBorderDiagonalDown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalDown--) per disegnare una linea dall’angolo in alto a sinistra a quello in basso a destra, e [getBorderDiagonalUp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalUp--) per disegnare una linea dall’angolo in basso a sinistra a quello in alto a destra. Una diagonale può contrassegnare un’intestazione di angolo; entrambe le diagonali possono formare una X per indicare che la cella non è applicabile.

Ogni diagonale è un [ILineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/). Nel suo [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--), utilizzare [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) per selezionare [FillType.Solid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) e scegliere un colore tramite [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--). Impostare lo spessore della linea in punti con [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-).

L’esempio crea tre celle in una riga: una diagonale rossa verso il basso, una diagonale blu verso l’alto e entrambe le diagonali. Lascia inalterati i bordi superiore, inferiore, sinistro e destro della cella.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Una diagonale è una proprietà di formattazione, non una divisione della cella. Ogni cella mantiene un unico frame di testo, accessibile tramite [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--); le regioni ai due lati di una diagonale non possono essere modificate indipendentemente.

La tabella salvata, resa in Microsoft PowerPoint:

![Tre celle di tabella che mostrano una diagonale rossa dall’angolo in alto a sinistra a quello in basso a destra, una diagonale blu dall’angolo in basso a sinistra a quello in alto a destra e entrambe le diagonali che formano una X.](diagonal-cell-borders.png)

*Da sinistra a destra: diagonale verso il basso (rossa, 3 pt), diagonale verso l’alto (blu, 5 pt) e entrambe le diagonali.*

## **Unire celle della tabella**

Utilizzare [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) per combinare un intervallo rettangolare di celle della tabella in una singola cella. Specificare le celle negli angoli in alto a sinistra e in basso a destra dell’intervallo. L’ultimo argomento controlla se l’unione può includere celle al di fuori dell’intervallo specificato; `false` mantiene l’unione entro quell’intervallo.

L’esempio crea una tabella 4x4 con colonne e righe da 70 punti, poi unisce le quattro celle centrali da `(1, 1)` a `(2, 2)`. La cella risultante occupa due colonne e due righe, mentre la griglia sottostante della tabella mantiene quattro colonne e quattro righe. Per accedere al contenuto o alla formattazione della cella unita, utilizzare la sua posizione in alto a sinistra: `table.get_Item(1, 1)` in questo esempio. Le altre posizioni nell’intervallo unito rimangono parte della griglia della tabella, quindi gli indici delle celle al di fuori dell’intervallo non cambiano.

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

## **Dividere celle della tabella**

L’unione delle celle nell’esempio precedente conserva la griglia della tabella. Dividere una cella può introdurre una nuova colonna nella griglia e modificare gli indici di colonna delle celle alla sua destra. Aspose.Slides segue il modello di griglia delle tabelle di PowerPoint.

Questo esempio crea una tabella 4x4 con colonne e righe da 70 punti e chiama [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) sulla cella `(1, 1)`. Metà della larghezza della cella, 70 punti, viene passata per creare due celle di larghezza uguale.

Dopo questa divisione, le due metà sono accessibili come `table.get_Item(1, 1)` e `table.get_Item(2, 1)`. La griglia della tabella ora ha cinque colonne: le celle originariamente nelle colonne 2 e 3 si spostano rispettivamente nelle colonne 3 e 4. Gli indici delle righe rimangono invariati. Utilizzare questi indici di colonna aggiornati quando si accede alle celle dopo la divisione.

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

<!-- visual-explanation:manage-cells:start -->
[![Una cella non unita da 70 punti si divide in due celle da 35 punti, aggiungendo una quinta colonna alla griglia e spostando gli indici a destra.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*La divisione della larghezza riguarda la cella (1, 1), usando indici zero‑based (column, row). Le altre righe mantengono una cella che copre entrambe le nuove posizioni di colonna.*
<!-- visual-explanation:manage-cells:end -->

### **Dividere celle unite per riga o colonna**

Per preparare le celle modello unite alla popolazione dei dati, utilizzare [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) per dividere lungo un confine di riga esistente, o [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) per dividere lungo un confine di colonna.

L’argomento `index` conta le righe nella parte superiore o le colonne nella parte sinistra della divisione; è relativo alla regione unita:

- Divisione per riga: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Divisione per colonna: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

L’esempio si aspetta che una presentazione contenga una tabella come prima forma sulla prima diapositiva, con `(1, 2)` e `(1, 3)` uniti verticalmente. Partendo dalla posizione inferiore, utilizza [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) e [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) per individuare l’origine e verifica entrambi gli span. `splitByRowSpan(1)` quindi separa le righe 2 e 3 per i nomi dei prodotti. Per un’unione orizzontale a due colonne, utilizzare `splitByColSpan(1)` invece.

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

La griglia della tabella e gli indici delle celle circostanti rimangono invariati. Recuperare le celle risultanti per coordinate; qui entrambe hanno span 1 e [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) stampa `false`. Regioni più grandi possono rimanere parzialmente unite dopo una divisione.

Il testo originale e la sua formattazione rimangono nella cella superiore (o sinistra); la nuova cella è vuota ma eredita la formattazione della cella come riempimento, bordi e margini. Popolare le celle dopo la divisione e impostare esplicitamente qualsiasi formattazione del testo necessaria.

La presentazione salvata contiene celle separate “Product A” e “Product B” con la formattazione della cella del modello mantenuta. Vedere la [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) per i dettagli.

### **Dividere una cella a un’altezza specifica**

[splitByHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByHeight-double-) prende l’altezza della parte superiore in punti. [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) prende il numero di righe della griglia esistenti nella parte superiore. Per centrare una cella da 40 punti nella colonna destra, sottrarre 40 dall’altezza reale della cella e dividere lo spazio rimanente equamente sopra e sotto di essa.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };

    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La prima divisione aggiunge una riga alla griglia e lascia i 90 punti inferiori nella cella `(1, 1)`. La seconda divisione frammenta quella cella in una cella centrale da 40 punti e una cella inferiore da 50 punti. La colonna destra ora contiene tre celle con altezze di 50, 40 e 50 punti dall’alto verso il basso. La cella sinistra copre tutte e tre le righe e mantiene la sua altezza originale di 140 punti.

![La cella sinistra copre l’intera altezza della tabella accanto a tre celle con “Middle” al centro.](split-by-height.png)

## **Modificare il colore di sfondo della cella della tabella**

Questo esempio crea una tabella con colonne da 150 punti e righe da 50 punti. Utilizza [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) per selezionare un riempimento solido e imposta il colore restituito da [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) a rosso per la cella `(2, 3)`, nella terza colonna e quarta riga.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Aggiungere un’immagine all’interno di una cella della tabella**

Posizionare l’immagine di input nella directory di lavoro prima di eseguire questo esempio. Viene caricata con [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) e aggiunta alla raccolta di immagini della presentazione con [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Viene quindi assegnata l’immagine al riempimento immagine della cella `(0, 0)`, la prima cella della tabella.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) allunga l’immagine per riempire la cella, il che può modificare le proporzioni. Le larghezze delle colonne e le altezze delle righe sono in punti. L’immagine caricata viene eliminata in un blocco `finally` dopo essere stata aggiunta alla presentazione.

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

**Posso impostare spessori e stili di linea diversi per i vari lati di una singola cella?**

Sì. I bordi [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) hanno proprietà separate, quindi lo spessore e lo stile di ogni lato possono differire.

**Cosa succede all’immagine se modifico la dimensione della colonna/riga dopo aver impostato un’immagine come sfondo della cella?**

Il comportamento dipende dalla [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l’immagine si adatta alla nuova cella; con il tiling, le tessere vengono ricalcolate.

**Posso assegnare un collegamento ipertestuale a tutto il contenuto di una cella?**

[Hyperlinks](/slides/it/androidjava/manage-hyperlinks/) sono impostati a livello di testo (porzione) all’interno del frame di testo della cella o a livello dell’intera tabella/forma. In pratica, si assegna il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare caratteri diversi all’interno di una singola cella?**

Sì. Il frame di testo di una cella supporta le [portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (segmenti) con formattazione indipendente—famiglia di carattere, stile, dimensione e colore.