---
title: Gestire le celle di tabella nelle presentazioni con Python
linktitle: Gestire le celle
type: docs
weight: 30
url: /it/python-net/manage-cells/
keywords:
- cella di tabella
- unire celle
- rimuovere bordo
- dividere cella
- immagine nella cella
- colore di sfondo
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci facilmente le celle di tabella in PowerPoint e OpenDocument con Aspose.Slides per Python tramite .NET. Padroneggia l'accesso, la modifica e lo styling delle celle rapidamente per un'automazione fluida delle diapositive."
---
## **Panoramica**

Aspose.Slides ti consente di accedere e modificare le celle delle tabelle nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle unite, rimuovere i bordi delle celle, gestire la numerazione delle celle dopo l’unione o la divisione, cambiare il colore di sfondo di una cella e aggiungere un’immagine all’interno di una cella di tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione delle celle tramite le proprietà della cella e salvare la presentazione modificata come file PPTX.

## **Identificare celle di tabella unite**

Le tabelle contengono spesso celle unite per intestazioni o per raggruppare dati correlati. In questa sezione vedrai come determinare se una cella specifica appartiene a un’area unita e come fare riferimento alla cella master (in alto a sinistra) per leggere o formattare l’intero blocco in modo coerente.

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni la tabella dalla prima diapositiva.
1. Scorri le righe e le colonne della tabella per trovare le celle unite.
1. Stampa un messaggio quando vengono trovate celle unite.

Il seguente codice Python identifica le celle di tabella unite in una presentazione:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Supponendo che la prima forma nella prima diapositiva sia una tabella.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **Rimuovere i bordi delle celle di tabella**

A volte i bordi della tabella distraggono dal contenuto o creano confusione visiva. Questa sezione mostra come rimuovere i bordi dalle celle selezionate — o da lati specifici di una cella — per ottenere un layout più pulito e allineato al design della diapositiva.

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni la diapositiva per indice.
1. Definisci un array di larghezze delle colonne.
1. Definisci un array di altezze delle righe.
1. Aggiungi una tabella alla diapositiva usando il metodo [add_table](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_table/).
1. Scorri ogni cella per cancellare i bordi superiore, inferiore, sinistro e destro.
1. Salva la presentazione modificata come file PPTX.

Il seguente codice Python mostra come rimuovere i bordi dalle celle di tabella:

```python
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta un file PPTX.
with slides.Presentation() as presentation:
    # Accedere alla prima diapositiva.
    slide = presentation.slides[0]

    # Definire le colonne con larghezze e le righe con altezze.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Aggiungere una forma tabella alla diapositiva.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Cancellare il riempimento del bordo per ogni cella.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Salvare il file PPTX su disco.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numerazione nelle celle unite**

Se unisci due coppie di celle — ad esempio, (1, 1) × (2, 1) e (1, 2) × (2, 2) — la tabella risultante mantiene la stessa numerazione delle celle di una tabella senza unioni. Il seguente codice Python dimostra questo comportamento:

```python
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta un file PPTX.
with slides.Presentation() as presentation:
    # Accedere alla prima diapositiva.
    slide = presentation.slides[0]

    # Definire colonne con larghezze e righe con altezze.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Aggiungere una forma tabella alla diapositiva.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Unire le celle (1,1) e (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Unire le celle (1, 2) e (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Stampare gli indici delle celle.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Salvare il file PPTX su disco.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

Output:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Numerazione nelle celle divise**

Nell’esempio precedente, quando le celle della tabella erano unite, la numerazione nelle altre celle non cambiava. Questa volta creiamo una tabella regolare (senza celle unite) e poi dividiamo la cella (1, 1) per ottenere una tabella speciale. Presta attenzione alla numerazione di questa tabella — può sembrare insolita. Tuttavia, è così che Microsoft PowerPoint numera le celle delle tabelle e Aspose.Slides segue lo stesso comportamento.

Il seguente codice Python dimostra questo comportamento:

```python
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta un file PPTX.
with slides.Presentation() as presentation:
    # Accedere alla prima diapositiva.
    slide = presentation.slides[0]

    # Definire le larghezze delle colonne e le altezze delle righe.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Aggiungere una forma tabella alla diapositiva.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Dividere la cella (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Stampare gli indici delle celle.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Salvare il file PPTX su disco.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

Output:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Modificare il colore di sfondo di una cella di tabella**

Il seguente esempio Python dimostra come cambiare il colore di sfondo di una cella di tabella:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Crea una nuova tabella.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Imposta il colore di sfondo per una cella.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Inserire immagini nelle celle di tabella**

Questa sezione mostra come inserire un’immagine in una cella di tabella con Aspose.Slides. Copre l’applicazione di un riempimento immagine alla cella target e la configurazione delle opzioni di visualizzazione come stretch o tile.

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva per indice.
1. Definisci un array di larghezze delle colonne.
1. Definisci un array di altezze delle righe.
1. Aggiungi una tabella alla diapositiva con il metodo [add_table](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_table/).
1. Carica l’immagine da un file.
1. Aggiungi l’immagine alle immagini della presentazione per ottenere un [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/).
1. Imposta il [FillType](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) della cella di tabella su `PICTURE`.
1. Applica l’immagine alla cella di tabella e scegli una modalità di riempimento (ad esempio `STRETCH`).
1. Salva la presentazione come file PPTX.

Il seguente codice Python mostra come posizionare un’immagine all’interno di una cella di tabella durante la creazione della tabella:

```python
import aspose.slides as slides

# Istanziare un oggetto Presentation.
with slides.Presentation() as presentation:
    # Accedere alla prima diapositiva.
    slide = presentation.slides[0]

    # Definire le larghezze delle colonne e le altezze delle righe.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Aggiungere una forma tabella alla diapositiva.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Caricare l'immagine e aggiungerla alla presentazione per ottenere un PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Applicare l'immagine alla prima cella della tabella.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Salvare la presentazione su disco.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso impostare spessori e stili di linea diversi per i lati di una singola cella?**

Sì. I bordi [top](https://reference.aspose.com/slides/it/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/it/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/it/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/it/python-net/aspose.slides/cellformat/border_right/) hanno proprietà separate, quindi lo spessore e lo stile di ciascun lato possono differire. Questo deriva logicamente dal controllo dei bordi per lato di una cella mostrato nell’articolo.

**Cosa succede all’immagine se modifico la dimensione della colonna/riga dopo aver impostato un’immagine come sfondo della cella?**

Il comportamento dipende dalla [fill mode](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l’immagine si adatta alla nuova cella; con il tiling, le tessere vengono ricalcolate. L’articolo descrive le modalità di visualizzazione dell’immagine in una cella.

**Posso assegnare un collegamento ipertestuale a tutto il contenuto di una cella?**

[I Link ipertestuali](/slides/it/python-net/manage-hyperlinks/) sono impostati a livello di porzione di testo all’interno del frame di testo della cella o a livello dell’intera tabella/forma. In pratica, assegni il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare caratteri diversi all’interno di una singola cella?**

Sì. Il frame di testo di una cella supporta le [portions](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/) (segmenti) con formattazione indipendente — famiglia del carattere, stile, dimensione e colore.