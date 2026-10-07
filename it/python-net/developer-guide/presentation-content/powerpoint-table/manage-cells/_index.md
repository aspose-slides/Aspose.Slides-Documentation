---
title: Gestire le celle della tabella nelle presentazioni con Python
linktitle: Gestisci celle
type: docs
weight: 30
url: /it/python-net/manage-cells/
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
description: "Gestire le celle delle tabelle PowerPoint in Python: identificare le celle unite, rimuovere i bordi, dividere le celle e impostare colori di sfondo e immagini con Aspose.Slides per Python tramite .NET."
---
## **Panoramica**

Aspose.Slides consente di accedere e modificare le celle delle tabelle nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle di tabella unite, rimuovere i bordi delle celle, gestire la numerazione delle celle dopo l’unione o la divisione, cambiare il colore di sfondo di una cella e aggiungere un’immagine all’interno di una cella di tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione delle celle tramite le proprietà della cella e salvare la presentazione modificata come file PPTX.

Aspose.Slides utilizza indici basati su zero. Le coordinate in questo articolo sono scritte come `(colonna, riga)`.

## **Identificare una cella tabella unita**

L’esempio apre una presentazione esistente e accede alla prima forma nella prima diapositiva come tabella. Si presume che la diapositiva e la forma esistano e che la forma sia una tabella. Viene quindi iterato su tutte le righe e colonne e si utilizza [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) per identificare le celle nelle regioni unite. Per ogni corrispondenza, stampa le coordinate della cella in ordine `row;column`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), e le coordinate iniziali della regione, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) e [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **Rimuovere i bordi della cella della tabella**

Crea una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) e aggiungi una tabella alla sua prima diapositiva con [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Larghezze delle colonne, altezze delle righe e posizione della tabella sono specificate in punti. L’esempio imposta tutti e quattro i bordi della cella su [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), rendendoli invisibili.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Unire le celle della tabella**

Usa [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) per combinare un intervallo rettangolare di celle della tabella in un’unica cella. Specifica le celle negli angoli in alto a sinistra e in basso a destra dell’intervallo. L’ultimo argomento controlla se l’unione può includere celle al di fuori dell’intervallo specificato; `False` mantiene l’unione entro quell’intervallo.

L’esempio crea una tabella 4 × 4 con colonne e righe da 70 punti, poi unisce le quattro celle centrali da `(1, 1)` a `(2, 2)`. La cella risultante occupa due colonne e due righe, mentre la griglia sottostante della tabella mantiene quattro colonne e quattro righe. Per accedere al contenuto o alla formattazione della cella unita, usa la sua posizione in alto a sinistra: `table.rows[1][1]` in questo esempio. Le altre posizioni nell’intervallo unito rimangono parte della griglia della tabella, quindi gli indici delle celle al di fuori dell’intervallo non cambiano.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **Dividere le celle della tabella**

Unire celle nell’esempio precedente preserva la griglia della tabella. Dividere una cella può introdurre una nuova colonna nella griglia e modificare gli indici di colonna delle celle a destra. Aspose.Slides segue il modello di griglia delle tabelle di PowerPoint.

Questo esempio crea una tabella 4 × 4 con colonne e righe da 70 punti e chiama [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) sulla cella `(1, 1)`. Metà della larghezza di 70 punti della cella viene passata per creare due celle di larghezza uguale.

Dopo questa divisione, le due metà sono accessibili come `table.rows[1][1]` e `table.rows[1][2]`. La griglia della tabella ora ha cinque colonne: le celle originariamente nelle colonne 2 e 3 si spostano rispettivamente nelle colonne 3 e 4. Gli indici di riga rimangono invariati. Usa questi indici di colonna aggiornati quando accedi alle celle dopo la divisione.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **Dividere le celle unite per estensione di riga o colonna**

Per preparare le celle modello unite alla popolazione dei dati, usa [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) per dividere lungo un confine di riga esistente, o [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) per dividere lungo un confine di colonna.

L’argomento `index` conta le righe nella parte superiore o le colonne nella parte sinistra della divisione; è relativo alla regione unita:

- Divisione di riga: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Divisione di colonna: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

L’esempio presuppone che una presentazione abbia una tabella come prima forma nella prima diapositiva, con `(1, 2)` e `(1, 3)` unite verticalmente. Partendo dalla posizione inferiore, utilizza [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) e [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) per individuare l’origine e verifica entrambe le estensioni. `split_by_row_span` con indice 1 separa quindi le righe 2 e 3 per i nomi dei prodotti. Per un’unione orizzontale a due colonne, usa invece `split_by_col_span` con indice 1.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # Recupera le celle risultanti dalla tabella dopo la divisione.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

La griglia della tabella e gli indici delle celle circostanti rimangono invariati. Recupera le celle risultanti tramite le loro coordinate; qui entrambe hanno estensione 1 e [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) restituisce `False`. Regioni più grandi possono rimanere parzialmente unite dopo una divisione.

Il testo originale e la sua formattazione rimangono nella cella superiore (o sinistra); la nuova cella è vuota ma eredita la formattazione della cella, come riempimento, bordi e margini. Popola le celle dopo la divisione e imposta esplicitamente qualsiasi formattazione del testo richiesta.

La presentazione salvata contiene celle separate “Product A” e “Product B” con la formattazione della cella del modello mantenuta. Consulta la [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) per ulteriori dettagli.

## **Modificare il colore di sfondo della cella della tabella**

Questo esempio crea una tabella con colonne da 150 punti e righe da 50 punti. Imposta [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) su solido e [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) su rosso per la cella `(2, 3)`, nella terza colonna e quarta riga.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungere un'immagine all'interno di una cella della tabella**

Posiziona l’immagine di input nella directory di lavoro prima di eseguire questo esempio. L’immagine viene caricata con [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) e aggiunta alla collezione di immagini della presentazione con [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Viene quindi assegnata all’riempimento immagine della cella `(0, 0)`, la prima cella della tabella.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) allunga l’immagine per riempire la cella, potendo modificare il rapporto d’aspetto. Larghezze delle colonne e altezze delle righe sono in punti. L’immagine caricata viene eliminata automaticamente al termine del blocco `with`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso impostare spessori e stili di linea diversi per i vari lati di una singola cella?**

Sì. I bordi [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) hanno proprietà separate, quindi lo spessore e lo stile di ciascun lato possono differire.

**Cosa succede all’immagine se modifico la dimensione della colonna/riga dopo aver impostato un’immagine come sfondo della cella?**

Il comportamento dipende dalla [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l’immagine si adatta alla nuova cella; con il tiling, le tessere vengono ricalcolate.

**Posso assegnare un collegamento ipertestuale a tutto il contenuto di una cella?**

[Hyperlinks](/slides/it/python-net/manage-hyperlinks/) sono impostati a livello di porzione di testo all’interno del frame di testo della cella o a livello dell’intera tabella/forma. In pratica, assegni il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare caratteri diversi all’interno di una singola cella?**

Sì. Il frame di testo di una cella supporta [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (segmenti) con formattazione indipendente—famiglia, stile, dimensione e colore del carattere.