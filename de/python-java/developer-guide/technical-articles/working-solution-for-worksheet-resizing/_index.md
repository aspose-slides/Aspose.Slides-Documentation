---
title: Funktionsfähige Lösung für die Größenänderung von Arbeitsblättern
type: docs
weight: 20
url: /de/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- Vorschaubild
- Bildskalierung
- Excel
- Arbeitsblatt
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Beheben Sie die OLE-Größenänderung von Excel-Arbeitsblättern in Präsentationen: zwei Methoden, um Objekt-Frames konsistent zu halten – entweder den Frame oder das Blatt skalieren – in den Formaten PPT und PPTX."
---
{{% alert color="info" title="Hinweis" %}}
Es wurde beobachtet, dass in einer PowerPoint‑Präsentation eingebettete Excel‑Arbeitsblätter als OLE‑Objekte durch Aspose‑Komponenten nach der ersten Aktivierung auf eine nicht festgelegte Skalierung geändert werden. Dieses Verhalten führt zu einem sichtbaren Unterschied in der Präsentation zwischen dem Zustand vor und nach der Aktivierung des OLE‑Objekts. Wir haben das Problem ausführlich untersucht und eine Lösung bereitgestellt, die in diesem Artikel beschrieben wird.
{{% /alert %}}

## **Hintergrund**

Im Artikel [Manage OLE](/slides/de/python-java/manage-ole/) haben wir erklärt, wie man mit Aspose.Slides for Python via Java einen OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [object preview issue](/slides/de/python-java/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Objekt‑Rahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. Im Ergebnis‑Präsentationsdatei wird beim Doppelklick auf den OLE‑Rahmen, der das Arbeitsblatt‑Bild anzeigt, die Excel‑Arbeitsmappe aktiviert. Endbenutzer können beliebige Änderungen an der eigentlichen Excel‑Arbeitsmappe vornehmen und anschließend zur Folie zurückkehren, indem sie außerhalb der aktivierten Excel‑Arbeitsmappe klicken. Die Größe des OLE‑Rahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor variiert abhängig von der Größe des OLE‑Rahmens und der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Größenänderung**

Da die Excel‑Arbeitsmappe ihr eigenes Fenster hat, versucht sie beim ersten Aktivieren, ihre ursprüngliche Größe beizubehalten. Der OLE‑Rahmen hingegen hat seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint beim Aktivieren der Arbeitsmappe die Größe, um das korrekte Seitenverhältnis im Einbettungsprozess zu erhalten. Die Größenänderung entsteht durch die Unterschiede zwischen der Fenstergröße von Excel und der Größe sowie Position des OLE‑Rahmens.

## **Lösungsansatz**

Es gibt zwei mögliche Lösungen, um den Skalierungseffekt zu vermeiden.

- Skalieren Sie die OLE‑Rahmengröße in der PowerPoint‑Präsentation, sodass sie Höhe und Breite der gewünschten Anzahl von Zeilen und Spalten im OLE‑Rahmen entspricht.
- Halten Sie die OLE‑Rahmengröße konstant und skalieren Sie die Größe der beteiligten Zeilen und Spalten, damit sie in die gewählte OLE‑Rahmengröße passen.

### **OLE‑Rahmengröße skalieren**

In diesem Ansatz lernen wir, wie man die OLE‑Rahmengröße der eingebetteten Excel‑Arbeitsmappe so einstellt, dass sie der kumulativen Größe der beteiligten Zeilen und Spalten im Excel‑Arbeitsblatt entspricht.

Angenommen, wir haben ein Excel‑Vorlagenblatt und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario wird die Größe des OLE‑Objekt‑Rahmens zunächst anhand der kumulierten Zeilenhöhen und Spaltenbreiten der beteiligten Zeilen und Spalten der Arbeitsmappe berechnet. Anschließend setzen wir die Größe des OLE‑Rahmens auf diesen berechneten Wert. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir zudem ein Bild der gewünschten Abschnitte der Zeilen und Spalten in der Arbeitsmappe und setzen es als Bild des OLE‑Rahmens ein.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Festlegen der angezeigten Größe, wenn die Arbeitsmappe als OLE‑Objekt in PowerPoint verwendet wird.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Ermitteln der Breite und Höhe des OLE‑Bildes in Punkten.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Verwenden der modifizierten Arbeitsmappe.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # OLE‑Bild zu den Präsentationsressourcen hinzufügen.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # OLE‑Objekt‑Rahmen erstellen.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **Zellbereichsgröße skalieren**

In diesem Ansatz lernen wir, wie man die Höhen der beteiligten Zeilen und die Breiten der beteiligten Spalten so skaliert, dass sie zu einer benutzerdefinierten OLE‑Rahmengröße passen.

Angenommen, wir haben ein Excel‑Vorlagenblatt und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario setzen wir die Größe des OLE‑Rahmens und skalieren die Größe der Zeilen und Spalten, die im OLE‑Rahmenbereich enthalten sind. Anschließend speichern wir die Arbeitsmappe in einen Stream, um die Änderungen anzuwenden, und konvertieren sie in ein Byte‑Array, das dem OLE‑Rahmen hinzugefügt wird. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir zudem ein Bild der gewünschten Abschnitte der Zeilen und Spalten in der Arbeitsmappe und setzen es als Bild des OLE‑Rahmens ein.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # Die erwartete Breite und Höhe des Zellbereichs sind in Punkten angegeben.
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Festlegen der angezeigten Größe, wenn die Arbeitsmappe als OLE‑Objekt in PowerPoint verwendet wird.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Skalieren des Zellbereichs, um in die Rahmengröße zu passen.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Verwenden der modifizierten Arbeitsmappe.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # OLE‑Bild zu den Präsentationsressourcen hinzufügen.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # OLE‑Objekt‑Rahmen erstellen.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **Fazit**

{{% alert color="info" title="Hinweis" %}} 
Es gibt zwei Ansätze, um das Problem der Größenänderung des Arbeitsblatts zu beheben. Die Wahl des geeigneten Ansatzes hängt von den konkreten Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren gleich, unabhängig davon, ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Außerdem gibt es in dieser Lösung keine Begrenzung für die Größe des OLE‑Objekt‑Rahmens.
{{% /alert %}}

## **FAQ**

**Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?**

Dies geschieht, weil Excel versucht, beim Aktivieren die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Rahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu erhalten, was die Größenänderung verursachen kann.

**Lässt sich das Skalierungsproblem vollständig verhindern?**

Ja. Durch Skalieren des OLE‑Rahmens auf die Größe des Excel‑Zellbereichs oder durch Skalieren des Zellbereichs auf die gewünschte OLE‑Rahmengröße kann unerwünschtes Skalieren verhindert werden.

**Welche Skalierungsmethode sollte ich verwenden, OLE‑Rahmenskalierung oder Zellbereichsskalierung?**

Wählen Sie **OLE‑Rahmenskalierung**, wenn Sie die ursprünglichen Zeilen‑ und Spaltengrößen von Excel beibehalten möchten. Wählen Sie **Zellbereichsskalierung**, wenn Sie eine feste Größe für den OLE‑Rahmen in Ihrer Präsentation benötigen.

**Funktionieren diese Lösungen, wenn meine Präsentation auf einer Vorlage basiert?**

Ja. Beide Lösungen funktionieren sowohl für aus Vorlagen als auch für von Grund auf erstellte Präsentationen.

**Gibt es eine Begrenzung für die Größe des OLE‑Rahmens bei Verwendung dieser Methoden?**

Nein. Der OLE‑Objekt‑Rahmen kann beliebig groß sein, solange die Skalierung entsprechend gesetzt wird.

**Gibt es eine Möglichkeit, den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint zu vermeiden?**

Ja. Durch Aufnehmen eines Schnappschusses des Ziel‑Excel‑Zellbereichs und Setzen dieses Bildes als Platzhalterbild des OLE‑Rahmens können Sie ein benutzerdefiniertes Vorschaubild anstelle des Standardplatzhalters anzeigen.

## **Verwandte Artikel**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/de/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)