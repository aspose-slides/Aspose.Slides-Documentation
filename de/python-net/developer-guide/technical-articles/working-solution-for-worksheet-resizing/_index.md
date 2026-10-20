---
title: Arbeitslösung für die Größenanpassung von Arbeitsblättern
type: docs
weight: 40
url: /de/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- Vorschaubild
- Bildgrößenanpassung
- Excel
- Arbeitsblatt
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Excel‑Arbeitsblatt‑OLE‑Größenänderung in Präsentationen beheben: zwei Möglichkeiten, Objekt‑Frames konsistent zu halten – den Frame oder das Blatt skalieren – für PPT‑ und PPTX‑Formate."
---
{{% alert color="info" title="Note" %}}

Excel‑Arbeitsblätter, die als OLE‑Objekte in einer PowerPoint‑Präsentation mit Aspose‑Komponenten eingebettet sind, können sich nach der ersten Aktivierung unerwartet in der Größe ändern. Dieses Verhalten erzeugt einen deutlichen visuellen Unterschied zwischen dem OLE‑Objekt vor und nach der Aktivierung. Dieser Artikel erklärt das Problem und beschreibt zwei Möglichkeiten, es zu beheben.

{{% /alert %}} 

## **Hintergrund**

In dem Artikel [OLE verwalten](/slides/de/python-net/manage-ole/) haben wir erklärt, wie man mit Aspose.Slides für Python via .NET einen OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [Vorschauproblem für Objekt](/slides/de/python-net/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Objektrahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. In der Ausgabepäsentation wird das Excel‑Arbeitsbuch aktiviert, wenn Sie den OLE‑Objektrahmen, der das Arbeitsblatt‑Bild anzeigt, doppelklicken. Endbenutzer können beliebige Änderungen am tatsächlichen Excel‑Arbeitsbuch vornehmen und anschließend zur Folie zurückkehren, indem sie außerhalb des aktivierten Excel‑Arbeitsbuchs klicken. Die Größe des OLE‑Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor variiert je nach Größe des OLE‑Objektrahmens und des eingebetteten Excel‑Arbeitsbuchs.

## **Ursache der Größenänderung**

Da das Excel‑Arbeitsbuch über eine eigene Fenstergröße verfügt, versucht es, nach der ersten Aktivierung seine ursprüngliche Größe beizubehalten. Der OLE‑Objektrahmen hat hingegen eine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung des Excel‑Arbeitsbuchs die Größe, um sicherzustellen, dass die korrekten Proportionen im Einbettungsprozess erhalten bleiben. Die Größenänderung erfolgt basierend auf den Unterschieden zwischen der Fenstergröße von Excel und der Größe sowie Position des OLE‑Objektrahmens.

## **Funktionierende Lösung**

Es gibt zwei mögliche Lösungen, um den Skalierungseffekt zu vermeiden.

- Den OLE‑Rahmen in der PowerPoint‑Präsentation skalieren, sodass er der Gesamthöhe und -breite der ausgewählten Zeilen und Spalten entspricht.
- Die Größe des OLE‑Rahmens konstant halten und die ausgewählten Zeilen und Spalten skalieren, damit sie hineinpassen.

### **Größe des OLE‑Rahmens skalieren**

Dieser Ansatz setzt die Größe des OLE‑Rahmens so, dass sie der Gesamthöhe und -breite der ausgewählten Zeilen und Spalten im eingebetteten Excel‑Arbeitsblatt entspricht.

Das Beispiel lädt ein vorhandenes Excel‑Arbeitsbuch und wählt die ersten 10 Zeilen und 13 Spalten des ersten Arbeitsblatts mithilfe nullbasierter Indizes aus. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) definiert den angezeigten Bereich. Die Vorschau wird mit 96 DPI gerendert und ihre Pixeldimensionen werden mit 72 Punkten pro Zoll in Punkte umgerechnet. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) bettet das modifizierte Arbeitsbuch in einen Rahmen mit diesen Abmessungen ein. Die Vorschau wird über [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) zugewiesen, um den Platzhalter „EMBEDDED OLE OBJECT“ in der gespeicherten Präsentation zu ersetzen.

Der Vorschau‑Helper setzt [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) auf den ausgewählten Bereich und entfernt Ränder, Kopf‑ und Fußzeilen. Mit aktiviertem [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) rendert [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) den Bereich als PNG‑Bild. Der Helper setzt den Bild‑Stream zurück, bevor er ihn für die Verwendung in der Präsentation zurückgibt.

```py
import io
import aspose.cells as cells

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

Das vollständige Beispiel unten kombiniert die Helfer mit dem Einbetten des Arbeitsbuchs und speichert die Präsentation als `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

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

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Setze die angezeigte Größe, wenn die Arbeitsmappe als OLE-Objekt in PowerPoint verwendet wird.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Ermittle die Breite und Höhe des OLE-Bildes in Punkten.
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

### **Größe des Zellbereichs skalieren**

Dieser Ansatz skaliert die Höhen der ausgewählten Zeilen und die Breiten der ausgewählten Spalten, um einer benutzerdefinierten OLE‑Rahmengröße zu entsprechen.

Das Beispiel lädt ein vorhandenes Excel‑Arbeitsbuch und wählt die ersten 10 Zeilen und 13 Spalten des ersten Arbeitsblatts mithilfe nullbasierter Indizes aus. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) definiert den angezeigten Bereich, und der untenstehende Helper skaliert diesen Bereich, sodass er in einen Rahmen von 400 Punkten Breite und 100 Punkten Höhe passt. Nachdem das modifizierte Arbeitsbuch in einen Stream gespeichert wurde, bettet [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) es mit der angegebenen Größe ein. Eine bei 96 DPI gerenderte Vorschau wird über [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) zugewiesen, sodass die gespeicherte Präsentation die ausgewählten Zellen anstelle des Standard‑Platzhalters anzeigt.

Der Skalierungs‑Helper berechnet separate Breiten‑ und Höhenverhältnisse für den ausgewählten Bereich, wobei die relativen Spaltenbreiten und Zeilenhöhen erhalten bleiben. Er wandelt die berechneten Abmessungen von Punkten in Zoll um, bevor er sie mit [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) und [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/) anwendet. Der ausgewählte Bereich muss eine von null unterschiedliche Breite und Höhe aufweisen.

```py
import aspose.cells as cells

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

Dieser Vorschau‑Helper rendert den skalierten Bereich mit [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/). Er begrenzt [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) auf diesen Bereich, entfernt Ränder, Kopf‑ und Fußzeilen und gibt einen PNG‑Stream zurück, der am Anfang positioniert ist.

```py
import io
import aspose.cells as cells

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

Das vollständige Beispiel unten kombiniert die Helfer mit dem Einbetten des Arbeitsbuchs und speichert die Präsentation als `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

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

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Setze die angezeigte Größe, wenn die Arbeitsmappe als OLE-Objekt in PowerPoint verwendet wird.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Skaliere den Zellbereich, sodass er in die Rahmengröße passt.
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

            # Erstelle den OLE-Objektrahmen.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Fazit**

{{% alert color="info" title="Note" %}}

Es gibt zwei Ansätze, um das Problem der Größenänderung des Arbeitsblatts zu beheben. Wählen Sie den Ansatz, der am besten zu Ihren Anforderungen und Ihrem Anwendungsfall passt. Beide Ansätze funktionieren gleichermaßen, unabhängig davon, ob die Präsentationen aus einer Vorlage oder von Grund auf neu erstellt werden. Zusätzlich gibt es in dieser Lösung keine Begrenzung für die Größe des OLE‑Objektrahmens.

{{% /alert %}}

## **FAQ**

**Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?**

Dies geschieht, weil Excel bei der Aktivierung versucht, die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Objektrahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis beizubehalten, was zu einer Größenänderung führen kann.

**Ist es möglich, dieses Größenänderungsproblem vollständig zu verhindern?**

Ja. Durch das Skalieren des OLE‑Rahmens, sodass er der Größe des Excel‑Zellbereichs entspricht, oder durch das Skalieren des Zellbereichs, sodass er in die gewünschte OLE‑Rahmengröße passt, kann eine unerwünschte Größenänderung verhindert werden.

**Welche Skalierungsmethode sollte ich verwenden, OLE‑Rahmenskalierung oder Zellbereichsskalierung?**

Wählen Sie **OLE‑Rahmenskalierung**, wenn Sie die ursprünglichen Excel‑Zeilen‑ und Spaltengrößen beibehalten möchten. Wählen Sie **Zellbereichsskalierung**, wenn Sie eine feste Größe für den OLE‑Rahmen in Ihrer Präsentation wünschen.

**Funktionieren diese Lösungen, wenn meine Präsentation auf einer Vorlage basiert?**

Ja. Beide Lösungen funktionieren sowohl für aus Vorlagen erstellte Präsentationen als auch für von Grund auf neu erstellte.

**Gibt es eine Begrenzung für die Größe des OLE‑Rahmens bei Verwendung dieser Methoden?**

Nein. Der OLE‑Objektrahmen kann beliebig groß sein, solange die Skalierung entsprechend eingestellt wird.

**Gibt es eine Möglichkeit, den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint zu vermeiden?**

Ja. Indem Sie einen Schnappschuss des gewünschten Excel‑Zellbereichs erstellen und ihn als Platzhalterbild des OLE‑Rahmens festlegen, können Sie ein benutzerdefiniertes Vorschaubild anstelle des Standard‑Platzhalters anzeigen.