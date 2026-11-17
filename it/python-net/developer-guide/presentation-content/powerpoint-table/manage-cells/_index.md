---
title: Gestire le celle di tabella nelle presentazioni con Python
linktitle: Gestire celle
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
description: "Gestisci le celle delle tabelle di PowerPoint in Python: identifica le celle unite, rimuovi i bordi, dividi le celle e imposta colori di sfondo e immagini con Aspose.Slides per Python tramite .NET."
---
## **Panoramica**

Aspose.Slides consente di accedere e modificare le celle di una tabella nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle di tabella unite, rimuovere i bordi delle celle, gestire la numerazione delle celle dopo l'unione o la divisione delle celle, modificare il colore di sfondo di una cella e aggiungere un’immagine all'interno di una cella di tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione delle celle tramite le proprietà della cella e salvare la presentazione modificata come file PPTX.

Aspose.Slides utilizza indici a base zero. Le coordinate in questo articolo sono scritte come `(colonna, riga)`.

## **Identificare una cella di tabella unita**

L'esempio apre una presentazione esistente e accede alla prima forma nella prima diapositiva come tabella. Si assume che la diapositiva e la forma esistano e che la forma sia una tabella. Quindi itera attraverso tutte le righe e le colonne e utilizza [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) per identificare le celle nelle regioni unite. Per ogni corrispondenza, stampa le coordinate della cella nell'ordine `row;column`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), e le coordinate di inizio della regione, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) e [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

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

Crea una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) e aggiungi una tabella alla sua prima diapositiva con [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Le larghezze delle colonne, le altezze delle righe e la posizione della tabella sono specificate in punti. L'esempio imposta tutti e quattro i bordi della cella a [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), rendendoli invisibili.

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

## **Aggiungere bordi diagonali alle celle**

Usa [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) per disegnare una linea dall'angolo in alto a sinistra a quello in basso a destra, e [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) per disegnare una linea dall'angolo in basso a sinistra a quello in alto a destra. Una diagonale può indicare un'intestazione d'angolo; entrambe le diagonali possono formare una X per indicare che la cella non è applicabile.

Ogni diagonale è un [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). Nella sua [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/), imposta [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) su [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) e scegli un [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/). Imposta la [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) della linea in punti.

L'esempio crea tre celle in una riga: una diagonale rossa discendente, una diagonale blu ascendente e entrambe le diagonali. Lascia invariati i bordi superiore, inferiore, sinistro e destro della cella.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

Una diagonale è una proprietà di formattazione, non una divisione della cella. Ogni cella mantiene un unico [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/); le regioni su entrambi i lati di una diagonale non possono essere modificate indipendentemente.

La tabella salvata, visualizzata in Microsoft PowerPoint:

![Tre celle di tabella che mostrano una diagonale rossa dall'angolo in alto a sinistra a quello in basso a destra, una diagonale blu dall'angolo in basso a sinistra a quello in alto a destra, e entrambe le diagonali che formano una X.](diagonal-cell-borders.png)

*Da sinistra a destra: diagonale discendente (rossa, 3 pt), diagonale ascendente (blu, 5 pt) e entrambe le diagonali.*

## **Unire le celle della tabella**

Usa [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) per combinare un intervallo rettangolare di celle della tabella in una singola cella. Specifica le celle agli angoli in alto a sinistra e in basso a destra dell'intervallo. L'ultimo argomento controlla se l'unione può includere celle al di fuori dell'intervallo specificato; `False` mantiene l'unione all'interno di quell'intervallo.

L'esempio crea una tabella 4 × 4 con colonne e righe da 70 punti, quindi unisce le quattro celle centrali da `(1, 1)` a `(2, 2)`. La cella risultante occupa due colonne e due righe, mentre la griglia sottostante della tabella mantiene quattro colonne e quattro righe. Per accedere al contenuto o alla formattazione della cella unita, usa la sua posizione in alto a sinistra: `table.rows[1][1]` in questo esempio. Le altre posizioni nell'intervallo unito rimangono parte della griglia della tabella, quindi gli indici delle celle al di fuori dell'intervallo non cambiano.

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

L'unione delle celle nell'esempio precedente conserva la griglia della tabella. Dividere una cella può introdurre una nuova colonna nella griglia e modificare gli indici di colonna delle celle alla sua destra. Aspose.Slides segue il modello di griglia delle tabelle di PowerPoint.

Questo esempio crea una tabella 4 × 4 con colonne e righe da 70 punti e chiama [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) sulla cella `(1, 1)`. Metà della larghezza di 70 punti della cella viene passata per creare due celle di larghezza uguale.

Dopo questa divisione, le due metà sono accessibili come `table.rows[1][1]` e `table.rows[1][2]`. La griglia della tabella ora ha cinque colonne: le celle originariamente nelle colonne 2 e 3 si spostano rispettivamente alle colonne 3 e 4. Gli indici di riga rimangono invariati. Usa questi indici di colonna aggiornati quando accedi alle celle dopo la divisione.

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

<!-- visual-explanation:manage-cells:start -->
[![Una cella da 70 punti non unita si divide in due celle da 35 punti, aggiungendo una quinta colonna nella griglia e spostando gli indici a destra.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*La divisione della larghezza influisce sulla cella (1, 1), usando indici a base zero (colonna, riga). Le altre righe mantengono una cella che si estende su entrambe le nuove posizioni di colonna.*
<!-- visual-explanation:manage-cells:end -->

### **Dividere le celle unite per riga o colonna**

Per preparare le celle modello unite alla popolazione dei dati, usa [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) per dividere lungo un confine di riga esistente, o [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) per dividere lungo un confine di colonna.

L'argomento `index` conta le righe nella parte superiore o le colonne nella parte sinistra della divisione; è relativo alla regione unita:

- Divisione per riga: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Divisione per colonna: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

L'esempio presume che una presentazione abbia una tabella come prima forma sulla prima diapositiva, con `(1, 2)` e `(1, 3)` uniti verticalmente. Partendo dalla posizione inferiore, utilizza [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) e [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) per individuare l'origine e verifica entrambi gli span. `split_by_row_span` con un indice di 1 separa quindi le righe 2 e 3 per i nomi dei prodotti. Per una fusione orizzontale a due colonne, usa invece `split_by_col_span` con un indice di 1.

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

La griglia della tabella e gli indici delle celle circostanti restano invariati. Recupera le celle risultanti tramite le loro coordinate; qui entrambe hanno span 1 e [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) stampa `False`. Regioni più ampie possono rimanere parzialmente unite dopo una divisione.

Il testo originale e la sua formattazione rimangono nella cella superiore (o sinistra); la nuova cella è vuota ma eredita la formattazione della cella come riempimento, bordi e margini. Popola le celle dopo la divisione e imposta esplicitamente eventuali formattazioni di testo necessarie.

La presentazione salvata contiene celle separate "Product A" e "Product B" con la formattazione della cella del modello mantenuta. Consulta il [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) per i dettagli.

### **Dividere una cella a un'altezza specifica**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) prende l'altezza della parte superiore in punti. [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) prende il numero di righe della griglia esistenti nella parte superiore. Per centrare verticalmente una cella da 40 punti nella colonna di destra, sottrai 40 dall'altezza reale della cella e dividi lo spazio rimanente equamente sopra e sotto di essa.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

La prima divisione aggiunge una riga alla griglia, lasciando i 90 punti inferiori in `table.rows[1][1]`. La seconda divisione suddivide quella cella in una cella centrale da 40 punti e una cella inferiore da 50 punti. Le tre celle nella colonna di destra sono ora alte 50, 40 e 50 punti dall'alto al basso. La cella sinistra occupa tutte e tre le righe alla sua altezza originale di 140 punti.

![La cella sinistra si estende per l'intera altezza della tabella accanto a tre celle con 'Middle' al centro.](split-by-height.png)

## **Modificare il colore di sfondo della cella della tabella**

Questo esempio crea una tabella con colonne da 150 punti e righe da 50 punti. Imposta [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) su solido e [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) su rosso per la cella `(2, 3)`, nella terza colonna e quarta riga.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungere un'immagine all'interno di una cella della tabella**

Posiziona l'immagine di input nella directory di lavoro prima di eseguire questo esempio. Carica l'immagine con [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) e la aggiunge alla collezione di immagini della presentazione con [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Quindi assegna l'immagine al riempimento immagine della cella `(0, 0)`, la prima cella della tabella.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) allunga l'immagine per riempire la cella, il che può cambiare il suo rapporto d'aspetto. Le larghezze delle colonne e le altezze delle righe sono in punti. L'immagine caricata viene eliminata automaticamente quando termina il blocco `with`.

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

**Posso impostare diverse spessori e stili di linea per i diversi lati di una singola cella?**

Sì. I bordi [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) hanno proprietà separate, quindi lo spessore e lo stile di ciascun lato possono differire.

**Cosa succede all'immagine se modifico la dimensione della colonna/riga dopo aver impostato un'immagine come sfondo della cella?**

Il comportamento dipende dalla [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l'immagine si adatta alla nuova cella; con il tiling, le piastrelle vengono ricalcolate.

**Posso assegnare un collegamento ipertestuale a tutto il contenuto di una cella?**

[Hyperlinks](/slides/it/python-net/manage-hyperlinks/) sono impostati a livello di testo (porzione) all'interno del frame di testo della cella o a livello dell'intera tabella/forma. In pratica, assegni il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare diversi caratteri all'interno di una singola cella?**

Sì. Il frame di testo di una cella supporta [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (run) con formattazione indipendente—famiglia, stile, dimensione e colore del carattere.