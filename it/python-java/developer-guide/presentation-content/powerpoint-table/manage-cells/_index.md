---
title: Gestisci le celle della tabella nelle presentazioni usando Python
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
description: "Gestisci le celle della tabella in PowerPoint con Aspose.Slides per Python via Java in modo semplice. Padroneggia l'accesso, la modifica e lo styling delle celle rapidamente per un'automazione fluida delle diapositive."
---
## **Panoramica**

Aspose.Slides ti consente di accedere e modificare le celle delle tabelle nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle di tabella unite, rimuovere i bordi delle celle, lavorare con la numerazione delle celle dopo l’unione o la divisione, cambiare il colore di sfondo di una cella e aggiungere un’immagine all’interno di una cella di tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione della cella tramite le proprietà della cella e salvare la presentazione modificata come file PPTX.

## **Identificare una cella di tabella unita**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Ottieni la tabella dalla prima diapositiva.
3. Itera le righe e le colonne della tabella per trovare le celle unite.
4. Stampa un messaggio quando vengono trovate celle unite.

Questo codice Python ti mostra come identificare le celle di tabella unite in una presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # Supponi che la prima forma nella prima diapositiva sia una tabella.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Rimuovere i bordi delle celle della tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Definisci un elenco di larghezze delle colonne.
4. Definisci un elenco di altezze delle righe.
5. Aggiungi una tabella alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addTable).
6. Itera ogni cella per cancellare i bordi superiore, inferiore, destro e sinistro.
7. Salva la presentazione modificata come file PPTX.

Questo codice Python ti mostra come rimuovere i bordi dalle celle della tabella:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # Accedi alla prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Definisci le larghezze delle colonne e le altezze delle righe.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Aggiungi una tabella alla diapositiva.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Imposta il formato del bordo per ogni cella.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Salva la presentazione come file PPTX.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numerazione nelle celle unite**

Se uniamo due coppie di celle, (1, 1) e (2, 1), e (1, 2) e (2, 2), la tabella risultante conserva la numerazione delle celle. Questo codice Python dimostra il processo:

```python
import jpype
import asposeslides

if not jpame.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Accedi alla prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Definisci le larghezze delle colonne e le altezze delle righe.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Aggiungi una tabella alla diapositiva.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Imposta il formato del bordo per ogni cella.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Unisci le celle (1, 1) e (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Unisci le celle (1, 2) e (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Salva la presentazione come file PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Successivamente uniamo ulteriormente le celle unendo (1, 1) e (1, 2). Il risultato è una tabella contenente una grande cella unita al centro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Accedi alla prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Definisci le larghezze delle colonne e le altezze delle righe.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Aggiungi una tabella alla diapositiva.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Imposta il formato del bordo per ogni cella.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Unisci le celle (1, 1) e (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Unisci le celle (1, 2) e (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Unisci le celle (1, 1) e (1, 2).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # Salva la presentazione come file PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numerazione in una cella divisa**

Negli esempi precedenti, l’unione delle celle della tabella non ha modificato la numerazione delle altre celle.

Questa volta prendiamo una tabella regolare (una tabella senza celle unite) e poi proviamo a dividere la cella (1, 1) per ottenere una tabella speciale. Potresti notare una numerazione della tabella che può apparire strana. Tuttavia, questo è il modo in cui Microsoft PowerPoint numera le celle della tabella e Aspose.Slides si comporta allo stesso modo.

Questo codice Python dimostra il processo descritto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Accedi alla prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Definisci le larghezze delle colonne e le altezze delle righe.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Aggiungi una tabella alla diapositiva.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Imposta il formato del bordo per ogni cella.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Dividi la cella (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # Salva la presentazione come file PPTX.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modificare il colore di sfondo della cella della tabella**

Questo codice Python ti mostra come cambiare il colore di sfondo di una cella della tabella:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Accedi alla prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Definisci le larghezze delle colonne e le altezze delle righe.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Aggiungi una tabella alla diapositiva.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Imposta il colore di sfondo per una cella.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Salva la presentazione come file PPTX.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aggiungere un'immagine all'interno di una cella di tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Definisci un elenco di larghezze delle colonne.
4. Definisci un elenco di altezze delle righe.
5. Aggiungi una tabella alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addTable).
6. Carica il file immagine usando [Images.fromFile](https://reference.aspose.com/slides/it/python-java/aspose.slides/images/#fromFile).
7. Aggiungi l’immagine alla presentazione per creare un oggetto [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/).
8. Imposta il tipo di riempimento della cella tramite la proprietà [FillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/) su [FillType.Picture](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/#Picture).
9. Aggiungi l’immagine alla prima cella della tabella.
10. Salva la presentazione modificata come file PPTX.

Questo codice Python ti mostra come inserire un'immagine all'interno di una cella della tabella durante la creazione della tabella:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # Accedi alla prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Definisci le larghezze delle colonne e le altezze delle righe.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Aggiungi una tabella alla diapositiva.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Crea un'immagine della presentazione dal file immagine.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Aggiungi l'immagine alla prima cella della tabella.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Salva la presentazione come file PPTX.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso impostare spessori e stili di linea diversi per i lati di una singola cella?**

Sì. I bordi [top](https://reference.aspose.com/slides/it/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/it/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/it/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/it/python-java/aspose.slides/cellformat/#getBorderRight) hanno proprietà separate, quindi lo spessore e lo stile di ciascun lato possono differire. Questo deriva logicamente dal controllo dei bordi per lato di una cella mostrato nell'articolo.

**Cosa succede all'immagine se modifico la dimensione della colonna/riga dopo aver impostato un'immagine come sfondo della cella?**

Il comportamento dipende dalla [fill mode](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l'immagine si adatta alla nuova cella; con il tiling, le tessere vengono ricalcolate. L'articolo menziona le modalità di visualizzazione dell'immagine in una cella.

**Posso assegnare un collegamento ipertestuale a tutto il contenuto di una cella?**

[Hyperlinks](/slides/it/python-java/manage-hyperlinks/) vengono impostati a livello di porzione di testo all'interno del frame di testo della cella o a livello dell'intera tabella/forma. In pratica, assegni il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare caratteri diversi all'interno di una singola cella?**

Sì. Il frame di testo di una cella supporta le [portions](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/) (run) con formattazione indipendente—famiglia di caratteri, stile, dimensione e colore.