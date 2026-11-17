---
title: Gestire le celle delle tabelle nelle presentazioni usando Python
linktitle: Gestisci celle
type: docs
weight: 30
url: /it/python-java/manage-cells/
keywords:
- cella della tabella
- unire celle
- rimuovere bordo
- dividere cella
- immagine nella cella
- colore di sfondo
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Gestisci le celle delle tabelle PowerPoint in Python: identifica le celle unite, rimuovi i bordi, dividi le celle e imposta colori di sfondo e immagini con Aspose.Slides per Python via Java."
---
## **Panoramica**

Aspose.Slides consente di accedere e modificare le celle di una tabella nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle di tabella unite, rimuovere i bordi delle celle, gestire la numerazione delle celle dopo l'unione o la divisione, cambiare il colore di sfondo di una cella e aggiungere un'immagine all'interno di una cella di tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione della cella tramite le proprietà della cella e salvare la presentazione modificata come file PPTX.

Aspose.Slides utilizza indici basati su zero per accedere alle celle della tabella nell'ordine `(column, row)`.

## **Identificare una cella di tabella unita**

La soluzione apre una presentazione esistente e accede alla prima forma nella prima diapositiva come tabella. Si presume che la diapositiva e la forma esistano e che la forma sia una tabella. Poi itera su tutte le righe e colonne e utilizza [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) per identificare le celle nelle aree unite. Per ogni corrispondenza, stampa le coordinate della cella nell'ordine `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan), e le coordinate di inizio della regione, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) e [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **Rimuovere i bordi delle celle della tabella**

Crea una [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) e aggiungi una tabella alla sua prima diapositiva con [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Larghezze delle colonne, altezze delle righe e la posizione della tabella sono specificate in punti. L'esempio imposta tutti e quattro i bordi della cella su [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), rendendoli invisibili.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aggiungere bordi diagonali alla cella**

Usa [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown) per disegnare una linea dall'angolo in alto a sinistra a quello in basso a destra, e [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) per disegnare una linea dall'angolo in basso a sinistra a quello in alto a destra. Una diagonale può indicare un'intestazione di angolo. Entrambe le diagonali possono formare una X per indicare che la cella non è applicabile.

Ogni diagonale è un [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/). Nel suo [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat), usa [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) per selezionare [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) e scegli un colore tramite [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor). Imposta la larghezza della linea in punti con [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth).

L'esempio crea tre celle in una riga: una diagonale rossa verso il basso, una diagonale blu verso l'alto e entrambe le diagonali. Lascia invariati i bordi superiore, inferiore, sinistro e destro della cella.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Una diagonale è una proprietà di formattazione, non una divisione della cella. Ogni cella mantiene un unico frame di testo, accessibile tramite [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame). Le regioni su entrambi i lati di una diagonale non possono essere modificate indipendentemente.

La tabella salvata, visualizzata in Microsoft PowerPoint:

![Tre celle di tabella che mostrano una diagonale rossa dall'angolo in alto a sinistra a quello in basso a destra, una diagonale blu dall'angolo in basso a sinistra a quello in alto a destra, e entrambe le diagonali che formano una X.](diagonal-cell-borders.png)

*Da sinistra a destra: diagonale verso il basso (rossa, 3 pt), diagonale verso l'alto (blu, 5 pt) e entrambe le diagonali.*

## **Unire le celle della tabella**

Usa [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) per combinare un intervallo rettangolare di celle della tabella in una singola cella. Specifica le celle negli angoli in alto a sinistra e in basso a destra dell'intervallo. L'ultimo argomento controlla se l'unione può includere celle al di fuori dell'intervallo specificato; `False` mantiene l'unione all'interno di quell'intervallo.

L'esempio crea una tabella 4 × 4 con colonne e righe da 70 punti, quindi unisce le quattro celle centrali da `(1, 1)` a `(2, 2)`. La cella risultante occupa due colonne e due righe, mentre la griglia sottostante della tabella mantiene quattro colonne e quattro righe. Per accedere al contenuto o alla formattazione della cella unita, usa la sua posizione in alto a sinistra: `table.get_Item(1, 1)` in questo esempio. Le altre posizioni nell'intervallo unito rimangono parte della griglia della tabella, quindi gli indici delle celle al di fuori dell'intervallo non cambiano.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dividere le celle della tabella**

L'unione delle celle nell'esempio precedente preserva la griglia della tabella. Dividere una cella può introdurre una nuova colonna nella griglia e cambiare gli indici di colonna delle celle a destra. Aspose.Slides segue il modello di griglia delle tabelle di PowerPoint.

Questo esempio crea una tabella 4 × 4 con colonne e righe da 70 punti e chiama [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) sulla cella `(1, 1)`. Metà della larghezza di 70 punti della cella viene passata per creare due celle di uguale larghezza.

Dopo questa divisione, le due metà sono accessibili come `table.get_Item(1, 1)` e `table.get_Item(2, 1)`. La griglia della tabella ora ha cinque colonne: le celle originariamente nelle colonne 2 e 3 si spostano rispettivamente alle colonne 3 e 4. Gli indici di riga rimangono invariati. Usa questi indici di colonna aggiornati quando accedi alle celle dopo la divisione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

<!-- visual-explanation:manage-cells:start -->
[![Una cella non unita di 70 punti si divide in due celle di 35 punti, aggiungendo una quinta colonna della griglia e spostando gli indici a destra.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*La divisione della larghezza influisce sulla cella (1, 1), usando indici basati su zero (colonna, riga). Le altre righe mantengono una cella che si estende su entrambe le nuove posizioni di colonna.*
<!-- visual-explanation:manage-cells:end -->

### **Dividere le celle unite per estensione di riga o colonna**

Per preparare le celle modello unite alla popolazione dei dati, usa [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) per dividere lungo un confine di riga esistente, o [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) per dividere lungo un confine di colonna.

L'argomento `index` conta le righe nella parte superiore o le colonne nella parte sinistra della divisione; è relativo alla regione unita:

- Divisione di riga: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Divisione di colonna: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

L'esempio prevede che una presentazione abbia una tabella come prima forma nella prima diapositiva, con `(1, 2)` e `(1, 3)` uniti verticalmente. Partendo dalla posizione inferiore, usa [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) e [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) per individuare l'origine e controlla entrambe le estensioni. `splitByRowSpan(1)` separa quindi le righe 2 e 3 per i nomi dei prodotti. Per un'unione orizzontale a due colonne, usa invece `splitByColSpan(1)`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # Recupera le celle risultanti dalla tabella dopo la divisione.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

La griglia della tabella e gli indici delle celle circostanti rimangono invariati. Recupera le celle risultanti tramite le loro coordinate; qui entrambe hanno estensioni pari a 1 e [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) restituisce `False`. Regioni più grandi possono rimanere parzialmente unite dopo una divisione.

Il testo originale e la sua formattazione rimangono nella cella superiore (o sinistra); la nuova cella è vuota ma eredita la formattazione della cella, come riempimento, bordi e margini. Popola le celle dopo la divisione e imposta esplicitamente qualsiasi formattazione del testo necessaria.

La presentazione salvata contiene celle separate “Product A” e “Product B” con la formattazione della cella modello mantenuta. Vedi il [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) per i dettagli.

### **Dividere una cella a un'altezza specifica**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) prende l'altezza della parte superiore in punti. [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) prende il numero di righe della griglia esistenti nella parte superiore. Per centrare una cella da 40 punti nella colonna destra, sottrai 40 dall'altezza reale della cella e dividi lo spazio rimanente equamente sopra e sotto di essa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La prima divisione aggiunge una riga alla griglia e lascia i 90 punti inferiori nella cella `(1, 1)`. La seconda divisione suddivide quella cella in una cella centrale da 40 punti e una cella inferiore da 50 punti. La colonna destra ora ha tre celle con altezze di 50, 40 e 50 punti dall'alto verso il basso. La cella sinistra si estende per tutte e tre le righe e mantiene la sua altezza originale di 140 punti.

![La cella sinistra si estende per l'intera altezza della tabella accanto a tre celle con "Middle" al centro.](split-by-height.png)

## **Modificare il colore di sfondo della cella della tabella**

Questo esempio crea una tabella con colonne da 150 punti e righe da 50 punti. Usa [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) per selezionare un riempimento solido e imposta il colore restituito da [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) su rosso per la cella `(2, 3)`, nella terza colonna e quarta riga.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aggiungere un'immagine all'interno di una cella di tabella**

Posiziona l'immagine di input nella directory di lavoro prima di eseguire questo esempio. Carica l'immagine con [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) e la aggiunge alla collezione di immagini della presentazione con [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Quindi assegna l'immagine al riempimento immagine della cella `(0, 0)`, la prima cella della tabella.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) allunga l'immagine per riempire la cella, il che può modificare il suo rapporto d'aspetto. Larghezze delle colonne e altezze delle righe sono in punti. L'immagine caricata viene eliminata in un blocco `finally` dopo che è stata aggiunta alla presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso impostare spessori e stili di linea diversi per i vari lati di una singola cella?**

Sì. I bordi [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) hanno proprietà separate, quindi lo spessore e lo stile di ciascun lato possono differire.

**Cosa succede all'immagine se modifico la dimensione della colonna/riga dopo aver impostato un'immagine come sfondo della cella?**

Il comportamento dipende dal [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l'immagine si adatta alla nuova cella; con il tiling, le tessere vengono ricalcolate.

**Posso assegnare un collegamento ipertestuale a tutto il contenuto di una cella?**

[Hyperlinks](/slides/it/python-java/manage-hyperlinks/) vengono impostati a livello di testo (portion) all'interno del frame di testo della cella o a livello dell'intera tabella/forma. In pratica, assegni il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare caratteri diversi all'interno di una singola cella?**

Sì. Il frame di testo di una cella supporta [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (run) con formattazione indipendente—famiglia di caratteri, stile, dimensione e colore.