---
title: Tabella
type: docs
weight: 120
url: /it/python-net/examples/elements/table/
keywords:
- tabella
- aggiungere tabella
- accedere alla tabella
- rimuovere tabella
- unire celle
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Crea e formatta tabelle in Python con Aspose.Slides: inserisci dati, unisci celle, formatta i bordi, allinea il contenuto e importa/esporta per PPT, PPTX e ODP."
---
Esempi di aggiunta di tabelle, accesso, rimozione e unione di celle usando **Aspose.Slides for Python via .NET**.

## **Aggiungere una tabella**

Crea una tabella semplice con due righe e due colonne.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Definire le larghezze delle colonne e le altezze delle righe.
        widths = [80, 80]
        heights = [30, 30]

        # Aggiungere una forma di tabella alla diapositiva.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedere a una tabella**

Recupera la prima forma di tabella nella diapositiva.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Accedere alla prima tabella sulla diapositiva.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Rimuovere una tabella**

Elimina una tabella da una diapositiva.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia una tabella.
        table = slide.shapes[0]

        # Rimuovere la tabella dalla diapositiva.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Unire celle della tabella**

Unisci le celle adiacenti di una tabella in un'unica cella.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia una tabella.
        table = slide.shapes[0]

        # Unire le celle.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```