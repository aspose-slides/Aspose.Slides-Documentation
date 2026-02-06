---
title: Tabelle
type: docs
weight: 120
url: /de/python-net/examples/elements/table/
keywords:
- Tabelle
- Tabelle hinzufügen
- Tabelle abrufen
- Tabelle entfernen
- Zellen zusammenführen
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen und formatieren Sie Tabellen in Python mit Aspose.Slides: Daten einfügen, Zellen zusammenführen, Rahmen gestalten, Inhalte ausrichten und für PPT, PPTX und ODP importieren/exportieren."
---
Beispiele zum Hinzufügen von Tabellen, Zugreifen darauf, Entfernen und Zusammenführen von Zellen mit **Aspose.Slides for Python via .NET**.

## **Tabelle hinzufügen**

Erstellen Sie eine einfache Tabelle mit zwei Zeilen und zwei Spalten.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Spaltenbreiten und Zeilenhöhen definieren.
        widths = [80, 80]
        heights = [30, 30]

        # Tabellen-Shape zur Folie hinzufügen.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugriff auf eine Tabelle**

Rufen Sie die erste Tabellenshape auf der Folie ab.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Zugriff auf die erste Tabelle auf der Folie.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Tabelle entfernen**

Löschen Sie eine Tabelle von einer Folie.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Angenommen, das erste Shape ist eine Tabelle.
        table = slide.shapes[0]

        # Die Tabelle aus der Folie entfernen.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Tabellenzellen zusammenführen**

Führen Sie benachbarte Zellen einer Tabelle zu einer einzigen Zelle zusammen.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Angenommen, das erste Shape ist eine Tabelle.
        table = slide.shapes[0]

        # Zellen zusammenführen.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```