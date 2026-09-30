---
title: Präsentationstabellen in Python verwalten
linktitle: Tabelle verwalten
type: docs
weight: 10
url: /de/python-java/manage-table/
keywords:
- Tabelle hinzufügen
- Tabelle erstellen
- Zugriff auf Tabelle
- Seitenverhältnis
- Text ausrichten
- Textformatierung
- Tabellenstil
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Tabellen in PowerPoint‑Folien mit Aspose.Slides für Python über Java erstellen und bearbeiten. Entdecken Sie einfache Codebeispiele, um Ihre Tabellen‑Workflows zu optimieren."
---
## **Einführung**

Tabellen in PowerPoint organisieren Informationen in Zeilen und Spalten, wodurch das Lesen und Vergleichen von Werten erleichtert wird.

Aspose.Slides stellt die [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) und [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) Klassen und weitere Typen bereit, um Tabellen in Präsentationen zu erstellen, zu aktualisieren und zu verwalten.

## **Tabelle von Grund auf erstellen**

Erstellen Sie eine Tabelle, indem Sie ihre Position, Spaltenbreiten und Zeilenhöhen angeben. Nach dem Hinzufügen zur Folie können Sie Zellenränder formatieren, Zellen zusammenführen und Text einfügen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
2. Holen Sie eine Referenz auf die Folie anhand ihres Index.
3. Definieren Sie eine Liste von Spaltenbreiten in Punkten.
4. Definieren Sie eine Liste von Zeilenhöhen in Punkten.
5. Fügen Sie ein [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) Objekt mittels der [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) Methode zur Folie hinzu.
6. Iterieren Sie über jede [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) um Formatierungen für die oberen, unteren, rechten und linken Rahmen anzuwenden.
7. Führen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen.
8. Greifen Sie über die [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) Methode auf die zusammengeführte Zelle zu.
9. Setzen Sie den Text in der zusammengeführten Zelle.
10. Speichern Sie die geänderte Präsentation.

Das nachstehende Beispiel erstellt eine Tabelle mit drei Spalten und fünf Zeilen bei (100, 50) Punkten. Es wendet rote Rahmen mit einer Breite von 5 Punkten an, führt die ersten beiden Zellen in der ersten Zeile zusammen und speichert das Ergebnis als `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nummerierung in einer Standardtabelle**

In einer Standardtabelle sind Zellindizes nullbasiert und verwenden die Reihenfolge (Spalte, Zeile). Die erste Zelle hat den Index (0, 0).

Beispielsweise werden die Zellen in einer Tabelle mit 4 Spalten und 4 Zeilen folgendermaßen nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieses Beispiel erstellt die oben dargestellte 4 × 4‑Tabelle mit Spaltenbreiten und Zeilenhöhen von 70 Punkten und roten Zellenrahmen mit einer Breite von 5 Punkten. Die Koordinaten veranschaulichen Zellindizes; das Beispiel lässt die Zellen leer und speichert die Tabelle als `StandardTables_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zugriff auf eine vorhandene Tabelle**

Tabellen werden in der Shapes‑Sammlung einer Folie gespeichert. Durchlaufen Sie die Shapes, um eine Tabelle zu finden, und verwenden Sie dann die [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) Klasse, um ihre Zellen zu lesen oder zu aktualisieren.

1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
2. Holen Sie eine Referenz auf die Folie, die die Tabelle enthält, anhand ihres Index.
3. Durchlaufen Sie die [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) Objekte und stoppen Sie, wenn eine Tabelle gefunden wird. Enthält die Folie mehrere Tabellen, verwenden Sie [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText), um die gewünschte zu identifizieren.
4. Aktualisieren Sie den Text in der Zielzelle.
5. Speichern Sie die geänderte Präsentation.

Das nachstehende Beispiel öffnet `UpdateExistingTable.pptx` und findet die erste Tabelle auf der ersten Folie. Es setzt die Zelle bei Spalte 0, Zeile 1 auf `New` und speichert das Ergebnis als `table1_out.pptx`. Die Eingabedatei muss mindestens eine Folie enthalten, und die erste Tabelle auf dieser Folie muss mindestens eine Spalte und zwei Zeilen haben.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Um eine Zeile in einer vorhandenen Tabelle zu ändern und zu verstehen, warum ihre tatsächliche Höhe das angeforderte Minimum überschreiten kann, siehe [Control Row Height](/slides/de/python-java/manage-rows-and-columns/#control-row-height).

## **Finden Sie die Zelle, die einen Textrahmen enthält**

Wenn generischer Textverarbeitungscode einen [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) von einer Tabelle erhält, verwenden Sie die [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) Methode, um die zugehörige [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) abzurufen. Für einen Tabellenzellen‑TextFrame liefert [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) den Eigentümer und [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) liefert `None`, obwohl die Tabelle selbst ein Shape ist.

Die Zellenkoordinaten sind über die schreibgeschützten Methoden [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) und [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) verfügbar. [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) bietet ebenfalls eine schreibgeschützte Navigation: Sie gibt den Eigentümer zurück, ändert jedoch nichts an der Zugehörigkeit. Überprüfen Sie immer, ob die zurückgegebene Zelle `None` ist, bevor Sie sie verwenden.

Ein vollständiges Beispiel, das Tabellenzellen‑ und Shape‑Eigentümer identifiziert, einschließlich Shapes, die mit SmartArt‑Knoten verbunden sind, finden Sie unter [Search and Replace Text](/slides/de/python-java/search-and-replace-text/).

## **Text in einer Tabelle ausrichten**

Sie können die vertikale Verankerung und Textausrichtung einzelner Tabellenzellen steuern. Das Beispiel in diesem Abschnitt zentriert den Text in der ersten Zelle und dreht ihn um 270 Grad.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
2. Holen Sie eine Referenz auf die Folie anhand ihres Index.
3. Fügen Sie ein [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) Objekt zur Folie hinzu.
4. Greifen Sie auf ein [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) Objekt der Tabelle zu.
5. Greifen Sie auf den ersten [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) zu und setzen Sie dessen Text und Farbe.
6. Setzen Sie die vertikale Verankerung und die Textausrichtung der Zelle mittels [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) und [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType).
7. Speichern Sie die geänderte Präsentation.

Dieses Beispiel erstellt eine 4 × 4‑Tabelle mit Spaltenbreiten von 120 Punkten und Zeilenhöhen von 100 Punkten. Es formatiert den Text in Zelle (0, 0), fügt Werte zu den übrigen Zellen der ersten Zeile hinzu und speichert das Ergebnis als `Vertical_Align_Text_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Textformatierung auf Tabellenebene festlegen**

Verwenden Sie [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat), um die Textformatierung auf alle Zellen einer Tabelle anzuwenden. Die Überladungen akzeptieren Teil‑, Absatz‑ und TextFrame‑Formatierungen, sodass Sie diese Eigenschaften setzen können, ohne einzelne Zellen zu iterieren.

1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
2. Holen Sie eine Referenz auf die Folie anhand ihres Index.
3. Greifen Sie auf ein [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) Objekt der Folie zu.
4. Setzen Sie die Schriftgröße mit [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) für den Text.
5. Setzen Sie die Absatzausrichtung und den rechten Rand mittels [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) und [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Setzen Sie die Textausrichtung mittels [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Speichern Sie die geänderte Präsentation.

Das nachstehende Beispiel öffnet `table.pptx`, das mindestens eine Folie mit einer Tabelle als erstem Shape enthalten muss. Es setzt die Schriftgröße auf 25 Punkte, richtet Absätze rechtsbündig mit einem rechten Rand von 20 Punkten aus und stellt den Text vertikal dar. Die formatierte Präsentation wird als `result.pptx` gespeichert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tabellenstil‑Eigenschaften abrufen**

Verwenden Sie [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset), um den voreingestellten Stil einer Tabelle zu lesen, und [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset), um ihn zuzuweisen. Dieses Beispiel wendet [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) auf eine Tabelle an, gibt den Vorgabewert aus und weist denselben Vorgabestil einer zweiten Tabelle zu. Beide Tabellen werden in `table-style.pptx` gespeichert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer Tabelle ist das Verhältnis ihrer Breite zur Höhe. Verwenden Sie [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked), um dieses Verhältnis für eine Tabelle zu sperren.

Das nachstehende Beispiel öffnet `pres.pptx`, das mindestens eine Folie mit einer Tabelle als erstem Shape enthalten muss. Es gibt den aktuellen Sperrstatus aus, aktiviert die Sperrung des Seitenverhältnisses, gibt den aktualisierten Status (`True`) aus und speichert das Ergebnis als `pres-out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich die Rechts-nach-Link‑Leserichtung (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die Methode [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft) bereit, und Absätze besitzen [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft). Die Kombination beider sorgt für die korrekte RTL‑Reihenfolge und -Darstellung in den Zellen.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der finalen Datei verschieben oder die Größe ändern?**

Verwenden Sie [shape locks](/slides/de/python-java/applying-protection-to-presentation/), um Verschieben, Größenänderung, Auswahl usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle ein [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) festlegen; das Bild bedeckt die Zellenfläche je nach gewähltem Modus (Strecken oder Kacheln).