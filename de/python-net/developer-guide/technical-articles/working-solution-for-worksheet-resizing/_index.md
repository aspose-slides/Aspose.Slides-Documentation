---
title: Funktionsfähige Lösung für die Größenanpassung von Arbeitsblättern
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
description: "Behebt die OLE-Größenanpassung von Excel-Arbeitsblättern in Präsentationen: zwei Möglichkeiten, Objekt-Frames konsistent zu halten – den Frame oder das Blatt skalieren – für PPT- und PPTX-Formate."
---

{{% alert color="primary" %}} 

Es wurde beobachtet, dass Excel-Arbeitsblätter, die als OLE-Objekte in einer PowerPoint‑Präsentation über Aspose‑Komponenten eingebettet sind, nach der ersten Aktivierung auf eine nicht identifizierte Skalierung geändert werden. Dieses Verhalten führt zu einem deutlichen visuellen Unterschied in der Präsentation zwischen dem Vor‑ und Nachaktivierungszustand des OLE‑Objekts. Wir haben dieses Problem ausführlich untersucht und eine Lösung bereitgestellt, die in diesem Artikel behandelt wird.

{{% /alert %}} 

## **Hintergrund**

In dem Artikel [OLE verwalten](/slides/de/python-net/manage-ole/) haben wir erklärt, wie man über Aspose.Slides für Python via .NET einen OLE‑Frame zu einer PowerPoint‑Präsentation hinzufügt. Um das [Vorschauproblem für Objekt](/slides/de/python-net/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Frame ein Bild des ausgewählten Arbeitsblatt‑Bereichs zugewiesen. Im ausgegebenen Dokument wird bei einem Doppelklick auf den OLE‑Frame, der das Arbeitsblatt‑Bild zeigt, die Excel‑Arbeitsmappe aktiviert. Endbenutzer können Änderungen an der echten Excel‑Arbeitsmappe vornehmen und dann durch Klicken außerhalb der aktivierten Excel‑Arbeitsmappe zur Folie zurückkehren. Beim Zurückkehren ändert sich die Größe des OLE‑Frames. Der Skalierungsfaktor variiert je nach Größe des OLE‑Frames und der eingebetteten Excel‑Arbeitsmappe. 

## **Ursache der Größenänderung**

Da die Excel‑Arbeitsmappe ein eigenes Fenster hat, versucht sie, bei der ersten Aktivierung ihre ursprüngliche Größe beizubehalten. Der OLE‑Frame wiederum hat seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Arbeitsmappe die Größe, um die korrekten Proportionen im Einbettungsprozess sicherzustellen. Die Größenänderung entsteht aus den Unterschieden zwischen der Fenstergröße von Excel und der Größe bzw. Position des OLE‑Frames. 

## **Lösungsansatz**

Es gibt zwei mögliche Lösungen, um den Skalierungseffekt zu vermeiden.

- Skaliere die OLE‑Frame‑Größe in der PowerPoint‑Präsentation, sodass sie der Höhe und Breite der gewünschten Anzahl von Zeilen und Spalten im OLE‑Frame entspricht. 
- Halte die OLE‑Frame‑Größe konstant und skaliere die Größe der beteiligten Zeilen und Spalten, sodass sie in die ausgewählte OLE‑Frame‑Größe passen. 

### **OLE‑Frame‑Größe skalieren**

In diesem Ansatz lernen wir, wie die OLE‑Frame‑Größe der eingebetteten Excel‑Arbeitsmappe so eingestellt wird, dass sie der kumulierten Größe der beteiligten Zeilen und Spalten im Excel‑Arbeitsblatt entspricht.

Angenommen, wir haben ein Excel‑Vorlagendokument und möchten es als OLE‑Frame zu einer Präsentation hinzufügen. In diesem Szenario wird die Größe des OLE‑Objekt‑Frames zunächst basierend auf den kumulierten Zeilenhöhen und Spaltenbreiten der beteiligten Zeilen und Spalten in der Arbeitsmappe berechnet. Anschließend setzen wir die Größe des OLE‑Frames auf diesen berechneten Wert. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Frame in PowerPoint zu vermeiden, erfassen wir außerdem ein Bild der gewünschten Zeilen‑ und Spaltenbereiche in der Arbeitsmappe und setzen es als OLE‑Frame‑Bild.
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

    # Legen Sie die angezeigte Größe fest, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Ermitteln Sie die Breite und Höhe des OLE-Bildes in Punkten.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Wir müssen die modifizierte Arbeitsmappe verwenden.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Fügen Sie das OLE-Bild zu den Präsentationsressourcen hinzu.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Erstellen Sie den OLE-Objekt-Frame.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


### **Zellbereichsgröße skalieren**

In diesem Ansatz lernen wir, wie die Höhen der beteiligten Zeilen und die Breite der beteiligten Spalten skaliert werden, um eine benutzerdefinierte OLE‑Frame‑Größe zu erreichen.

Angenommen, wir haben ein Excel‑Vorlagendokument und möchten es als OLE‑Frame zu einer Präsentation hinzufügen. In diesem Szenario setzen wir die Größe des OLE‑Frames und skalieren die Größe der Zeilen und Spalten, die im OLE‑Frame‑Bereich enthalten sind. Anschließend speichern wir die Arbeitsmappe in einen Stream, um die Änderungen anzuwenden, und konvertieren sie in ein Byte‑Array, um sie dem OLE‑Frame hinzuzufügen. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Frame in PowerPoint zu vermeiden, erfassen wir außerdem ein Bild der gewünschten Zeilen‑ und Spaltenbereiche in der Arbeitsmappe und setzen es als OLE‑Frame‑Bild.
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

    # Lege die angezeigte Größe fest, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Skaliere den Zellbereich, um in die Frame-Größe zu passen.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Wir müssen die modifizierte Arbeitsmappe verwenden.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Füge das OLE-Bild zu den Präsentationsressourcen hinzu.
            ole_image = presentation.images.add_image(image_stream)

            # Erstelle den OLE-Objekt-Frame.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Fazit**

{{% alert color="primary" %}}

Es gibt zwei Ansätze, um das Problem der Größenänderung des Arbeitsblatts zu beheben. Die Auswahl des geeigneten Ansatzes hängt von den konkreten Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren gleichermaßen, unabhängig davon, ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Darüber hinaus gibt es in dieser Lösung keine Begrenzung für die Größe des OLE‑Objekt‑Frames.

{{% /alert %}}