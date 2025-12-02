---
title: Lösungsansatz für die Größenanpassung von Arbeitsblättern
type: docs
weight: 40
url: /de/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- Vorschaubild
- Bildskalierung
- Excel
- Arbeitsblatt
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Excel-Arbeitsblatt OLE Größenanpassung in Präsentationen beheben: zwei Wege, um Objektrahmen konsistent zu halten – den Rahmen oder das Blatt skalieren – in den PPT- und PPTX-Formaten."
---

{{% alert color="primary" %}} 

Es wurde beobachtet, dass Excel‑Arbeitsblätter, die als OLE‑Objekte in einer PowerPoint‑Präsentation über Aspose‑Komponenten eingebettet sind, nach der ersten Aktivierung auf eine nicht identifizierte Skalierung geändert werden. Dieses Verhalten führt zu einem deutlichen visuellen Unterschied in der Präsentation zwischen dem Vor‑ und Nachaktivierungszustand des OLE‑Objekts. Wir haben dieses Problem ausführlich untersucht und eine Lösung bereitgestellt, die in diesem Artikel behandelt wird.

{{% /alert %}} 

## **Hintergrund**

In dem Artikel [OLE verwalten](/slides/de/python-net/manage-ole/), haben wir erklärt, wie man mit Aspose.Slides for Python via .NET ein OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [Vorschauproblem des Objekts](/slides/de/python-net/object-preview-issue-when-adding-oleobjectframe/) zu adressieren, haben wir dem OLE‑Objekt‑Rahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. In der Ausgabepäsentation wird beim Doppelklick auf den OLE‑Objekt‑Rahmen, der das Arbeitsblatt‑Bild anzeigt, die Excel‑Arbeitsmappe aktiviert. Endbenutzer können beliebige Änderungen an der tatsächlichen Excel‑Arbeitsmappe vornehmen und dann zur Folie zurückkehren, indem sie außerhalb der aktivierten Excel‑Arbeitsmappe klicken. Die Größe des OLE‑Objekt‑Rahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor variiert je nach Größe des OLE‑Objekt‑Rahmens und der eingebetteten Excel‑Arbeitsmappe. 

## **Ursache der Größenänderung**

Da die Excel‑Arbeitsmappe ihr eigenes Fenster hat, versucht sie, beim ersten Aktivieren ihre ursprüngliche Größe beizubehalten. Andererseits hat der OLE‑Objekt‑Rahmen seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Excel‑Arbeitsmappe die Größe, um sicherzustellen, dass die korrekten Proportionen im Einbettungsprozess erhalten bleiben. Die Größenänderung erfolgt aufgrund der Unterschiede zwischen der Excel‑Fenstergröße und der Größe sowie Position des OLE‑Objekt‑Rahmens.

## **Lösungsansatz**

Es gibt zwei mögliche Lösungen, um den Skalierungseffekt zu vermeiden.

- Skalieren Sie die OLE‑Rahmengröße in der PowerPoint‑Präsentation, sodass sie der Höhe und Breite der gewünschten Anzahl von Zeilen und Spalten im OLE‑Rahmen entspricht.  
- Halten Sie die OLE‑Rahmengröße konstant und skalieren Sie die Größe der beteiligten Zeilen und Spalten, sodass sie in die ausgewählte OLE‑Rahmengröße passen.  

### **OLE‑Rahmengröße skalieren**

In diesem Ansatz lernen wir, wie man die OLE‑Rahmengröße der eingebetteten Excel‑Arbeitsmappe so einstellt, dass sie der kumulativen Größe der beteiligten Zeilen und Spalten im Excel‑Arbeitsblatt entspricht.

Angenommen, wir haben ein Excel‑Vorlagenblatt und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario wird die Größe des OLE‑Objekt‑Rahmens zunächst basierend auf den kumulierten Zeilenhöhen und Spaltenbreiten der beteiligten Zeilen und Spalten in der Arbeitsmappe berechnet. Anschließend setzen wir die Größe des OLE‑Rahmens auf diesen berechneten Wert. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir zudem ein Bild der gewünschten Teile der Zeilen und Spalten in der Arbeitsmappe und setzen es als OLE‑Rahmenbild.  
```py
def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Setze die angezeigte Größe, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Erhalte die Breite und Höhe des OLE-Bildes in Punkten.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Wir müssen die modifizierte Arbeitsmappe verwenden.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Füge das OLE-Bild zu den Präsentationsressourcen hinzu.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Erstelle den OLE-Objektrahmen.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


### **Zellbereichsgröße skalieren**

In diesem Ansatz lernen wir, wie man die Höhen der beteiligten Zeilen und die Breite der beteiligten Spalten so skaliert, dass sie einer benutzerdefinierten OLE‑Rahmengröße entsprechen.

Angenommen, wir haben ein Excel‑Vorlagenblatt und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario setzen wir die Größe des OLE‑Rahmens und skalieren die Größe der Zeilen und Spalten, die im OLE‑Rahmenbereich beteiligt sind. Anschließend speichern wir die Arbeitsmappe in einen Stream, um die Änderungen anzuwenden, und konvertieren sie in ein Byte‑Array, um sie dem OLE‑Rahmen hinzuzufügen. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir zudem ein Bild der gewünschten Teile der Zeilen und Spalten in der Arbeitsmappe und setzen es als OLE‑Rahmenbild.  
```py
# <param name="width">Die erwartete Breite des Zellbereichs in Punkten.</param>
# <param name="height">Die erwartete Höhe des Zellbereichs in Punkten.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

```py
def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Setzen Sie die angezeigte Größe, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Skalieren Sie den Zellbereich, um in die Rahmengröße zu passen.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Wir müssen die modifizierte Arbeitsmappe verwenden.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Fügen Sie das OLE-Bild zu den Präsentationsressourcen hinzu.
            ole_image = presentation.images.add_image(image_stream)

            # Erstellen Sie den OLE-Objektrahmen.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Fazit**

{{% alert color="primary" %}}

Es gibt zwei Ansätze, um das Problem der Größenänderung des Arbeitsblatts zu beheben. Die Wahl des geeigneten Ansatzes hängt von den spezifischen Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren auf dieselbe Weise, unabhängig davon, ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Zusätzlich gibt es in dieser Lösung keine Begrenzung der Größe des OLE‑Objekt‑Rahmens.

{{% /alert %}}