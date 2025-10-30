---
title: Tabellenzellen in Präsentationen mit Python verwalten
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/python-net/manage-cells/
keywords:
- Tabellenzelle
- Zellen zusammenführen
- Rand entfernen
- Zelle teilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie mühelos Tabellenzellen in PowerPoint und OpenDocument mit Aspose.Slides für Python über .NET. Lernen Sie den schnellen Zugriff, das Ändern und Stylen von Zellen für nahtlose Folienautomatisierung."
---

## **Übersicht**

Dieser Artikel zeigt, wie man mit Tabellenzellen in Präsentationen mithilfe von Aspose.Slides arbeitet. Sie lernen, zusammengeführte Zellen zu erkennen, Zellränder zu löschen oder anzupassen, und verstehen, wie PowerPoint Zellen nach Merge‑ und Split‑Operationen nummeriert, sodass Sie die Indizierung in komplexen Layouts vorhersagen können. Der Artikel demonstriert außerdem gängige Formatierungsaufgaben – wie das Ändern der Hintergrundfüllung einer Zelle – und zeigt, wie man ein Bild direkt in eine Tabellenzelle mit Bildefüllungs‑Einstellungen einfügt. Jeder Anwendungsfall wird von prägnanten Python‑Beispielen begleitet, die Tabellen erstellen oder bearbeiten und die aktualisierte Präsentation speichern, sodass Sie die Snippets schnell an Ihre eigenen Folien anpassen können.

## **Zusammengeführte Tabellenzellen identifizieren**

Tabellen enthalten häufig zusammengeführte Zellen für Überschriften oder zur Gruppierung verwandter Daten. In diesem Abschnitt sehen Sie, wie Sie feststellen können, ob eine bestimmte Zelle zu einem zusammengeführten Bereich gehört und wie Sie die Master‑Zelle (oben‑links) referenzieren, um den gesamten Block einheitlich zu lesen oder zu formatieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie die Tabelle von der ersten Folie.  
1. Durchlaufen Sie die Zeilen und Spalten der Tabelle, um zusammengeführte Zellen zu finden.  
1. Geben Sie eine Meldung aus, wenn zusammengeführte Zellen gefunden werden.

Der folgende Python‑Code identifiziert zusammengeführte Tabellenzellen in einer Präsentation:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Angenommen, das erste Shape auf der ersten Folie ist eine Tabelle.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **Tabellenzellränder entfernen**

Manchmal lenken Tabellenränder vom Inhalt ab oder erzeugen visuelles Durcheinander. Dieser Abschnitt zeigt, wie Sie die Ränder ausgewählter Zellen – oder einzelner Seiten einer Zelle – entfernen, um ein klareres Layout zu erzielen und besser zum Design Ihrer Folie zu passen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie die Folie über ihren Index.  
1. Definieren Sie ein Array von Spaltenbreiten.  
1. Definieren Sie ein Array von Zeilenhöhen.  
1. Fügen Sie der Folie mit der [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/)‑Methode eine Tabelle hinzu.  
1. Durchlaufen Sie jede Zelle, um die oberen, unteren, linken und rechten Ränder zu entfernen.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Python‑Code zeigt, wie Sie die Ränder von Tabellenzellen entfernen:

```python
import aspose.slides as slides

# Instanziiert die Presentation‑Klasse, die eine PPTX‑Datei darstellt.
with slides.Presentation() as presentation:
    # Greift auf die erste Folie zu.
    slide = presentation.slides[0]

    # Definiert Spalten mit Breiten und Zeilen mit Höhen.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Fügt der Folie ein Tabellenshape hinzu.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Entfernt die Randfüllung für jede Zelle.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Speichert die PPTX‑Datei auf dem Datenträger.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Nummerierung in zusammengeführten Zellen**

Wenn Sie zwei Zellpaare zusammenführen – zum Beispiel (1, 1) × (2, 1) und (1, 2) × (2, 2) – behält die resultierende Tabelle dieselbe Zellnummerierung wie die Tabelle ohne Zusammenführung. Der folgende Python‑Code demonstriert dieses Verhalten:

```python
import aspose.slides as slides

# Instanziiert die Presentation‑Klasse, die eine PPTX‑Datei darstellt.
with slides.Presentation() as presentation:
    # Greift auf die erste Folie zu.
    slide = presentation.slides[0]

    # Definiert Spalten mit Breiten und Zeilen mit Höhen.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Fügt der Folie ein Tabellenshape hinzu.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Fügt die Zellen (1,1) und (2,1) zusammen.
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Fügt die Zellen (1,2) und (2,2) zusammen.
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Gibt die Zellindizes aus.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Speichert die PPTX‑Datei auf dem Datenträger.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

Ausgabe:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Nummerierung in geteilten Zellen**

Im vorherigen Beispiel änderte das Zusammenführen von Zellen die Nummerierung der übrigen Zellen nicht. Dieses Mal erstellen wir eine reguläre Tabelle (ohne zusammengeführte Zellen) und teilen dann die Zelle (1, 1), um eine spezielle Tabelle zu erzeugen. Achten Sie auf die Nummerierung dieser Tabelle – sie kann ungewöhnlich aussehen. Das ist jedoch das Verhalten von Microsoft PowerPoint, und Aspose.Slides folgt exakt diesem Verhalten.

Der folgende Python‑Code demonstriert dieses Verhalten:

```python
import aspose.slides as slides

# Instanziiert die Presentation‑Klasse, die eine PPTX‑Datei darstellt.
with slides.Presentation() as presentation:
    # Greift auf die erste Folie zu.
    slide = presentation.slides[0]

    # Definiert Spaltenbreiten und Zeilenhöhen.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Fügt der Folie ein Tabellenshape hinzu.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Teilt die Zelle (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Gibt die Zellindizes aus.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Speichert die PPTX‑Datei auf dem Datenträger.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

Ausgabe:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Hintergrundfarbe einer Tabellenzelle ändern**

Das folgende Python‑Beispiel demonstriert, wie Sie die Hintergrundfarbe einer Tabellenzelle ändern:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Erstellt eine neue Tabelle.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Setzt die Hintergrundfarbe für eine Zelle.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Bilder in Tabellenzellen einfügen**

Dieser Abschnitt zeigt, wie Sie ein Bild in eine Tabellenzelle in Aspose.Slides einfügen. Er behandelt das Anwenden einer Bildefüllung auf die Zielzelle und das Konfigurieren von Anzeigeoptionen wie Dehnen oder Kacheln.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie eine Folienreferenz über ihren Index.  
1. Definieren Sie ein Array von Spaltenbreiten.  
1. Definieren Sie ein Array von Zeilenhöhen.  
1. Fügen Sie der Folie mit der [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/)‑Methode eine Tabelle hinzu.  
1. Laden Sie das Bild aus einer Datei.  
1. Fügen Sie das Bild den Präsentations‑Images hinzu, um ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) zu erhalten.  
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) der Tabellenzelle auf `PICTURE`.  
1. Wenden Sie das Bild auf die Tabellenzelle an und wählen Sie einen Füllmodus (z. B. `STRETCH`).  
1. Speichern Sie die Präsentation als PPTX‑Datei.

Der folgende Python‑Code zeigt, wie Sie ein Bild in einer Tabellenzelle platzieren, wenn Sie eine Tabelle erstellen:

```python
import aspose.slides as slides

# Instanziiert ein Presentation‑Objekt.
with slides.Presentation() as presentation:
    # Greift auf die erste Folie zu.
    slide = presentation.slides[0]

    # Definiert Spaltenbreiten und Zeilenhöhen.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Fügt der Folie ein Tabellenshape hinzu.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Lädt das Bild und fügt es der Präsentation hinzu, um ein PPImage zu erhalten.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Wendet das Bild auf die erste Tabellenzelle an.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Speichert die Präsentation auf dem Datenträger.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich unterschiedliche Linienstärken und -stile für die einzelnen Seiten einer einzelnen Zelle festlegen?**

Ja. Die [oben](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[unten](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[links](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[rechts](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/)‑Ränder besitzen separate Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein können. Dies folgt logisch aus der per‑Seite‑Rand‑Steuerung für eine Zelle, die im Artikel demonstriert wird.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilengröße ändere, nachdem ich ein Bild als Hintergrund der Zelle festgelegt habe?**

Das Verhalten hängt vom [Füllmodus](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Dehnen passt sich das Bild an die neue Zelle an; beim Kacheln werden die Kacheln neu berechnet. Der Artikel erwähnt die Anzeige‑Modi eines Bildes in einer Zelle.

**Kann ich einem Hyperlink den gesamten Inhalt einer Zelle zuweisen?**

[Hyperlinks](/slides/de/python-net/manage-hyperlinks/) werden auf Ebene des Text‑(Portion‑)Elements innerhalb des Textframes der Zelle oder auf Ebene der gesamten Tabelle/des gesamten Shapes festgelegt. In der Praxis weisen Sie den Link einem Textabschnitt oder dem gesamten Text in der Zelle zu.

**Kann ich innerhalb einer einzelnen Zelle unterschiedliche Schriftarten festlegen?**

Ja. Der Text‑Frame einer Zelle unterstützt [Portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (Runs) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.