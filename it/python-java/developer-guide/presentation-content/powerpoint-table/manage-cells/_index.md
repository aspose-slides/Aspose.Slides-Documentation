---
title: Gestisci le celle della tabella nelle presentazioni con Python
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
description: "Gestisci le celle della tabella PowerPoint in Python: identifica le celle unite, rimuovi i bordi, dividi le celle e imposta colori di sfondo e immagini con Aspose.Slides per Python via Java."
---
## **Panoramica**

Aspose.Slides consente di accedere e modificare le celle di tabella nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle di tabella unite, rimuovere i bordi delle celle, gestire la numerazione delle celle dopo l’unione o la divisione, cambiare il colore di sfondo di una cella e aggiungere un’immagine all’interno di una cella di tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione delle celle tramite le proprietà delle celle e salvare la presentazione modificata come file PPTX.

Aspose.Slides utilizza indici basati su zero per accedere alle celle di tabella nell'ordine `(column, row)`.

## **Identificare una cella di tabella unita**

L'esempio apre una presentazione esistente e accede alla prima forma nella prima diapositiva come tabella. Presume che la diapositiva e la forma esistano e che la forma sia una tabella. Quindi itera su tutte le righe e le colonne e utilizza [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) per identificare le celle in regioni unite. Per ogni corrispondenza, stampa le coordinate della cella in ordine `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan), e le coordinate di inizio della regione, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) e [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

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

Creare una [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) e aggiungere una tabella alla sua prima diapositiva con [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Le larghezze delle colonne, le altezze delle righe e la posizione della tabella sono specificate in punti. L'esempio imposta tutti e quattro i bordi della cella su [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), rendendoli invisibili.

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
## **Unire le celle della tabella**

Utilizzare [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) per combinare un intervallo rettangolare di celle della tabella in una singola cella. Specificare le celle negli angoli in alto a sinistra e in basso a destra dell'intervallo. L'ultimo argomento controlla se l'unione può includere celle al di fuori dell'intervallo specificato; `False` mantiene l'unione all'interno di quell'intervallo.

L'esempio crea una tabella 4 × 4 con colonne e righe da 70 point, quindi unisce le quattro celle centrali da `(1, 1)` a `(2, 2)`. La cella risultante occupa due colonne e due righe, mentre la griglia sottostante della tabella mantiene quattro colonne e quattro righe. Per accedere al contenuto o alla formattazione della cella unita, utilizzare la sua posizione in alto a sinistra: `table.get_Item(1, 1)` in questo esempio. Le altre posizioni nell'intervallo unito rimangono parte della griglia della tabella, quindi gli indici delle celle al di fuori dell'intervallo non cambiano.

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

L'unione delle celle nell'esempio precedente preserva la griglia della tabella. Dividere una cella può introdurre una nuova colonna nella griglia e modificare gli indici di colonna delle celle a destra. Aspose.Slides segue il modello di griglia delle tabelle di PowerPoint.

Questo esempio crea una tabella 4 × 4 con colonne e righe da 70 point e chiama [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) sulla cella `(1, 1)`. Metà della larghezza di 70 point della cella viene passata per creare due celle di larghezza uguale.

Dopo questa divisione, le due metà sono accessibili come `table.get_Item(1, 1)` e `table.get_Item(2, 1)`. La griglia della tabella ora ha cinque colonne: le celle originariamente nelle colonne 2 e 3 si spostano rispettivamente alle colonne 3 e 4. Gli indici di riga rimangono invariati. Utilizzare questi indici di colonna aggiornati quando si accede alle celle dopo la divisione.

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
### **Dividere le celle unite per intervallo di riga o colonna**

Per preparare le celle modello unite alla popolazione dei dati, utilizzare [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) per dividere lungo un confine di riga esistente, oppure [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) per dividere lungo un confine di colonna.

L'argomento `index` conta le righe nella parte superiore o le colonne nella parte sinistra della divisione; è relativo alla regione unita:

- Divisione per riga: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Divisione per colonna: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

L'esempio presuppone che una presentazione contenga una tabella come prima forma nella prima diapositiva, con `(1, 2)` e `(1, 3)` unite verticalmente. Partendo dalla posizione inferiore, utilizza [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) e [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) per individuare l'origine e controlla entrambi gli intervalli. `splitByRowSpan(1)` separa quindi le righe 2 e 3 per i nomi dei prodotti. Per un'unione orizzontale a due colonne, usare invece `splitByColSpan(1)`.

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

La griglia della tabella e gli indici delle celle circostanti rimangono invariati. Recuperare le celle risultanti tramite le loro coordinate; qui entrambe hanno intervalli di 1 e [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) restituisce `False`. Regioni più ampie possono rimanere parzialmente unite dopo una divisione.

Il testo originale e la sua formattazione rimangono nella cella superiore (o sinistra); la nuova cella è vuota ma eredita la formattazione della cella, come riempimento, bordi e margini. Popolare le celle dopo la divisione e impostare esplicitamente qualsiasi formattazione del testo necessaria.

La presentazione salvata contiene celle separate "Product A" e "Product B" con la formattazione della cella del modello mantenuta. Vedi il [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) per i dettagli.

## **Modificare il colore di sfondo della cella della tabella**

Questo esempio crea una tabella con colonne da 150 point e righe da 50 point. Utilizza [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) per selezionare un riempimento solido e imposta il colore restituito da [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) su rosso per la cella `(2, 3)`, nella terza colonna e quarta riga.

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

Posizionare l'immagine di input nella directory di lavoro prima di eseguire questo esempio. L'immagine viene caricata con [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) e aggiunta alla raccolta immagini della presentazione con [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Successivamente viene assegnata l'immagine al riempimento immagine della cella `(0, 0)`, la prima cella della tabella.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) allunga l'immagine per riempire la cella, il che può modificare il suo rapporto d'aspetto. Le larghezze delle colonne e le altezze delle righe sono in punti. L'immagine caricata viene eliminata in un blocco `finally` dopo essere stata aggiunta alla presentazione.

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

**Posso impostare spessori e stili di linea diversi per i diversi lati di una singola cella?**

Sì. I bordi [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) hanno proprietà separate, quindi lo spessore e lo stile di ciascun lato possono differire.

**Cosa succede all'immagine se modifico la dimensione della colonna/riga dopo aver impostato un'immagine come sfondo della cella?**

Il comportamento dipende dalla [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l'immagine si adatta alla nuova cella; con il tiling, le piastrelle vengono ricalcolate.

**Posso assegnare un hyperlink a tutto il contenuto di una cella?**

[Hyperlinks](/slides/it/python-java/manage-hyperlinks/) sono impostati a livello di testo (porzione) all'interno del riquadro di testo della cella o a livello dell'intera tabella/forma. In pratica, si assegna il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare font diversi all'interno di una singola cella?**

Sì. Il riquadro di testo di una cella supporta [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (runs) con formattazione indipendente — famiglia di font, stile, dimensione e colore.