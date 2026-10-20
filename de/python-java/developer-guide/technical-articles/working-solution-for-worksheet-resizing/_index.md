---
title: Funktionsfähige Lösung für die Größenänderung von Arbeitsblättern
type: docs
weight: 20
url: /de/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- Vorschaubild
- Bildgrößenanpassung
- Excel
- Arbeitsblatt
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Beheben Sie die OLE-Größenänderung von Excel-Arbeitsblättern in Präsentationen: zwei Methoden, um Objekt-Frames konsistent zu halten - den Rahmen oder das Blatt skalieren - für die PPT- und PPTX-Formate."
---
{{% alert color="info" title="Hinweis" %}}

Excel‑Arbeitsblätter, die als OLE‑Objekte in einer PowerPoint‑Präsentation mithilfe von Aspose‑Komponenten eingebettet sind, können sich nach ihrer ersten Aktivierung unerwartet in der Größe ändern. Dieses Verhalten erzeugt einen deutlichen visuellen Unterschied zwischen dem OLE‑Objekt vor und nach der Aktivierung. Dieser Artikel erklärt das Problem und beschreibt zwei Möglichkeiten, es zu beheben.

{{% /alert %}}

## **Hintergrund**

Im Artikel [OLE verwalten](/slides/de/python-java/manage-ole/) haben wir erklärt, wie man mithilfe von Aspose.Slides für Python via Java einen OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [Vorschauproblem für Objekte](/slides/de/python-java/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Objektrahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. In der erzeugten Präsentation wird das Excel‑Arbeitsbuch aktiviert, wenn Sie den OLE‑Objektrahmen, der das Arbeitsblatt‑Bild anzeigt, doppelklicken. Endbenutzer können beliebige Änderungen am eigentlichen Excel‑Arbeitsbuch vornehmen und dann durch Klicken außerhalb des aktivierten Excel‑Arbeitsbuchs zur Folie zurückkehren. Die Größe des OLE‑Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Resize‑Faktor variiert je nach Größe des OLE‑Objektrahmens und des eingebetteten Excel‑Arbeitsbuchs.

## **Ursache der Größenänderung**

Da das Excel‑Arbeitsbuch seine eigene Fenstergröße hat, versucht es, bei der ersten Aktivierung seine ursprüngliche Größe beizubehalten. Der OLE‑Objektrahmen hingegen hat seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung des Excel‑Arbeitsbuchs die Größe, um sicherzustellen, dass die korrekten Proportionen im Rahmen des Einbettungsprozesses erhalten bleiben. Die Größenänderung entsteht durch die Unterschiede zwischen der Fenstergröße von Excel und der Größe sowie Position des OLE‑Objektrahmens.

## **Lösungsansatz**

Es gibt zwei mögliche Lösungen, um den Größenänderungseffekt zu vermeiden.

- Skalieren Sie den OLE‑Rahmen in der PowerPoint‑Präsentation, sodass er der Gesamthöhe und -breite der ausgewählten Zeilen und Spalten entspricht.
- Behalten Sie die Größe des OLE‑Rahmens bei und skalieren Sie die ausgewählten Zeilen und Spalten, damit sie hinein passen.

### **OLE‑Rahmengröße skalieren**

Dieser Ansatz setzt die OLE‑Rahmengröße so, dass sie der Gesamthöhe und -breite der ausgewählten Zeilen und Spalten im eingebetteten Excel‑Arbeitsblatt entspricht.

Das Beispiel lädt ein vorhandenes Excel‑Arbeitsbuch und wählt mithilfe nullbasierter Indizes die ersten 10 Zeilen und 13 Spalten des ersten Arbeitsblatts aus. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) definiert den angezeigten Bereich. Die Vorschau wird mit 96 DPI gerendert und ihre Pixeldimensionen werden mithilfe von 72 Punkten pro Zoll in Punkte umgerechnet. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) bettet das modifizierte Arbeitsbuch in einen Rahmen mit diesen Abmessungen ein. Die Vorschau wird über [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) zugewiesen, um den Platzhalter „EMBEDDED OLE OBJECT“ in der gespeicherten Präsentation zu ersetzen.

Der Vorschau‑Helper setzt [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) auf den ausgewählten Bereich und entfernt Ränder, Kopf‑ und Fußzeilen. Mit aktivierten [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) rendert [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) den Bereich als PNG‑Bild. Der Helper gibt einen neuen Eingabestream zurück, der das PNG‑Bild enthält und am Anfang positioniert ist, um in der Präsentation verwendet zu werden.

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

    # Festlegen der angezeigten Größe, wenn die Arbeitsmappe als OLE-Objekt in PowerPoint verwendet wird.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Abrufen von Breite und Höhe des OLE-Bildes in Punkten.
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

            # OLE-Bild zu den Präsentationsressourcen hinzufügen.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # OLE-Objektrahmen erstellen.
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

Dieser Ansatz skaliert die Höhen der ausgewählten Zeilen und die Breiten der ausgewählten Spalten, sodass sie einer benutzerdefinierten OLE‑Rahmengröße entsprechen.

Das Beispiel lädt ein vorhandenes Excel‑Arbeitsbuch und wählt mithilfe nullbasierter Indizes die ersten 10 Zeilen und 13 Spalten des ersten Arbeitsblatts aus. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) definiert den angezeigten Bereich, und der Helper scale_cell_range skaliert diesen Bereich, sodass er in einen Rahmen von 400 Punkten Breite und 100 Punkten Höhe passt. Nach dem Speichern des modifizierten Arbeitsbuchs in einen Stream bettet [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) es mit der angegebenen Größe ein. Eine mit 96 DPI gerenderte Vorschau wird über [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) zugewiesen, sodass die gespeicherte Präsentation die ausgewählten Zellen anstelle des Standard‑Platzhalters anzeigt.

Der Skalierungs‑Helper berechnet getrennte Breiten‑ und Höhen‑Verhältnisse für den ausgewählten Bereich und bewahrt dabei die relativen Spaltenbreiten und Zeilenhöhen. Er wandelt die berechneten Abmessungen von Punkten in Zoll um, bevor er sie mit [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) und [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch) anwendet. Der ausgewählte Bereich muss eine nicht null Breite und Höhe besitzen.

Dieser Vorschau‑Helper rendert den verkleinerten Bereich mithilfe von [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage). Er begrenzt [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) auf diesen Bereich, entfernt Ränder, Kopf‑ und Fußzeilen und gibt einen PNG‑Stream zurück, der am Anfang positioniert ist.

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
    # Die erwartete Breite und Höhe des Zellbereichs sind in Punkten.
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

    # Festlegen der angezeigten Größe, wenn die Arbeitsmappe als OLE-Objekt in PowerPoint verwendet wird.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Skaliere den Zellbereich, um in die Rahmengröße zu passen.
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

            # OLE-Bild zu den Präsentationsressourcen hinzufügen.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # OLE-Objektrahmen erstellen.
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

Es gibt zwei Ansätze, um das Problem der Arbeitsblatt‑Größenänderung zu beheben. Wählen Sie den Ansatz, der am besten zu Ihren Anforderungen und Ihrem Anwendungsfall passt. Beide Ansätze funktionieren gleichermaßen, egal ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Zusätzlich gibt es in dieser Lösung keine Begrenzung für die Größe des OLE‑Objektrahmens.

{{% /alert %}}

## **FAQ**

**Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?**

Dies geschieht, weil Excel bei der Aktivierung versucht, die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Objektrahmen in PowerPoint seine eigenen Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu erhalten, was die Größenänderung verursachen kann.

**Ist es möglich, dieses Größenänderungsproblem vollständig zu verhindern?**

Ja. Durch Skalieren des OLE‑Rahmens, um die Größe des Excel‑Zellbereichs anzupassen, oder durch Skalieren des Zellbereichs, um die gewünschte OLE‑Rahmengröße zu erreichen, kann eine unerwünschte Größenänderung verhindert werden.

**Welche Skalierungsmethode sollte ich verwenden, OLE‑Rahmen‑Skalierung oder Zellbereichs‑Skalierung?**

Wählen Sie **OLE‑Rahmen‑Skalierung**, wenn Sie die ursprünglichen Zeilen‑ und Spaltengrößen von Excel beibehalten möchten. Wählen Sie **Zellbereichs‑Skalierung**, wenn Sie eine feste Größe für den OLE‑Rahmen in Ihrer Präsentation wünschen.

**Werden diese Lösungen funktionieren, wenn meine Präsentation auf einer Vorlage basiert?**

Ja. Beide Lösungen funktionieren sowohl für aus Vorlagen erstellte als auch für von Grund auf neu erstellte Präsentationen.

**Gibt es eine Begrenzung für die Größe des OLE‑Rahmens bei Verwendung dieser Methoden?**

Nein. Der OLE‑Objektrahmen kann beliebig groß sein, solange die Skalierung entsprechend eingestellt wird.

**Gibt es eine Möglichkeit, den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint zu vermeiden?**

Ja. Durch das Erstellen eines Schnappschusses des gewünschten Excel‑Zellbereichs und das Festlegen dieses Bildes als Platzhalterbild des OLE‑Rahmens können Sie ein benutzerdefiniertes Vorschau‑Bild anstelle des Standard‑Platzhalters anzeigen.

## **Verwandte Artikel**

[Erstellen eines Excel‑Diagramms und Einbetten in eine Präsentation als OLE‑Objekt](/slides/de/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑Objekte automatisch aktualisieren mit einem MS PowerPoint‑Add‑In](/slides/de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)