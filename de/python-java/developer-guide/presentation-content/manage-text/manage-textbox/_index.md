---
title: Manage Text Boxes in Presentations Using Python via Java
linktitle: Manage Text Box
type: docs
weight: 20
url: /de/python-java/manage-textbox/
keywords:
- Textfeld
- Textrahmen
- Text hinzufügen
- Text aktualisieren
- Textfeld erstellen
- Textfeld prüfen
- Textspalte hinzufügen
- Hyperlink hinzufügen
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Textfelder in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via Java erstellen, identifizieren, formatieren und aktualisieren."
---
## **Einleitung**

In Aspose.Slides for Python via Java wird der Folientext in Textrahmen gespeichert, die zu Formen gehören. Die [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/)‑Klasse stellt die häufigste Text‑tragende Form dar und gibt ihren Text über die [AutoShape.getTextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/#getTextFrame)‑Methode frei.

{{% alert color="info" title="Hinweis" %}}

Jede AutoShape erbt von [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/), aber nicht jede Form ist eine AutoShape oder unterstützt einen Textrahmen. Beim Verarbeiten einer bestehenden Präsentation sollte geprüft werden, ob eine Form eine Instanz von [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) ist, bevor auf deren Text zugegriffen wird.

{{% /alert %}}

## **Erstellen eines Textfelds auf einer Folie**

Um ein Textfeld zu erstellen, fügen Sie einer Folie eine AutoShape hinzu, fügen Sie dem Textrahmen Text hinzu und speichern Sie die Präsentation. Das folgende Beispiel erzeugt ein rechteckiges Textfeld:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die an [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addAutoShape) übergebenen Koordinaten und Abmessungen werden in Punkten gemessen. [AutoShape.addTextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/#addTextFrame) initialisiert den Textrahmen mit dem angegebenen Text.

## **Überprüfen, ob eine Form ein Textfeld ist**

Verwenden Sie die [AutoShape.isTextBox](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/#isTextBox)‑Methode, um festzustellen, ob eine AutoShape als Textfeld behandelt wird. Dies ist nützlich, wenn eine Präsentation sowohl Text‑tragende als auch rein grafische AutoShapes enthält.

![Ein Textfeld und eine Form](istextbox.png)

Das folgende Beispiel untersucht jede AutoShape in einer Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

Eine neu hinzugefügte AutoShape wird erst dann als Textfeld angesehen, wenn sie nicht leeren Text enthält. Sie können diesen Text über [AutoShape.addTextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/#addTextFrame) oder [TextFrame.setText](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#setText) bereitstellen. Das Hinzufügen oder Zuweisen eines leeren Strings lässt [AutoShape.isTextBox](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/#isTextBox) `False` zurückgeben:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

Die ersten beiden Aufrufe geben `True` aus; die letzten beiden geben `False` aus.

## **Finden Sie die Form, die einen Textrahmen besitzt**

Generischer Textverarbeitungscode kann ein [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) erhalten, ohne zu wissen, welches Präsentationsobjekt es enthält. Verwenden Sie die schreibgeschützte [TextFrame.getParentShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#getParentShape)‑Methode, um zum übergeordneten [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/) zurückzukehren.

Für einen Textrahmen, der einer AutoShape oder einer anderen Text‑tragenden Form gehört, gibt [TextFrame.getParentShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#getParentShape) den Eigentümer zurück und [TextFrame.getParentCell](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#getParentCell) gibt `None` zurück. Prüfen Sie den zurückgegebenen Wert, bevor Sie darauf zugreifen. Um sowohl Form‑ als auch Tabellenzellen‑Eigentümer zu identifizieren, einschließlich Formen, die mit SmartArt‑Knoten verbunden sind, siehe [Search and Replace Text](/slides/de/python-java/search-and-replace-text/).

## **Spalten zu einem Textfeld hinzufügen**

Die Methode [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setColumnCount) teilt den Textrahmen in Spalten, während [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setColumnSpacing) den Abstand zwischen den Spalten in Punkten festlegt. Beide Einstellungen gehören zu [TextFrameFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/) und können über den Textrahmen eines bestehenden Textfelds geändert werden. Der Text fließt zwischen den Spalten innerhalb derselben Form um; er wird nicht in eine andere Form fortgesetzt.

Das folgende Beispiel erzeugt ein dreispaltiges Textfeld mit 10 Punkten Abstand zwischen den Spalten, speichert die Präsentation und liest die gespeicherten Einstellungen aus der Ausgabedatei zurück:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **Text aus einzelnen Spalten extrahieren**

Verwenden Sie [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#splitTextByColumns), um den Text abzurufen, der jedem visuellen Spaltenbereich in einem bestehenden Textrahmen zugewiesen ist. Die Methode liefert für jede Spalte einen String in spaltenbasierter Lesereihenfolge. Ein einspaltiger Textrahmen erzeugt ein Array mit einem Element, und eine leere Spalte wird durch einen leeren String dargestellt. Die Strings enthalten ausschließlich Klartext; Formatierungen auf Portionsebene werden nicht beibehalten.

Dies ist nützlich, wenn Sie:

- Text extrahieren und dabei die spaltenbasierte Lesereihenfolge beibehalten.
- Den Inhalt von Folien mit mehreren Spalten indizieren oder vergleichen.
- Jede Spalte in eine separate Datei, Datenbankfeld oder ein anderes Ziel exportieren.
- Untersuchen, wie sich Text nach dem Ändern der Spaltenanzahl mit [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setColumnCount), des Abstands mit [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setColumnSpacing), der Schriftart oder der Größe des Textrahmens neu verteilt.

Die Methode gibt den Text zurück, der innerhalb des aktuellen [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) verteilt ist; sie fließt Text nicht automatisch zwischen separaten Formen oder Textfeldern. Die Spaltenverteilung kann von verfügbaren Schriftarten und anderen Textlayout‑Einstellungen abhängen, daher sollten die erforderlichen Schriftarten zur Verfügung stehen, wenn konsistente Ergebnisse wichtig sind.

Das folgende Beispiel lädt eine Präsentation, findet die erste mehrspaltige AutoShape mit einem Textrahmen, liest die konfigurierte Spaltenanzahl und schreibt den Text jeder Spalte in eine separate Datei. Formen, die keinen Textrahmen bereitstellen, werden übersprungen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **Text aktualisieren**

Um Text in einer gesamten Präsentation zu aktualisieren, iterieren Sie über die Folien und Formen, wählen AutoShapes aus und bearbeiten anschließend deren Textabschnitte. Das Arbeiten auf Portionsebene ermöglicht das Ändern von Text und Zeichenformatierung.

Das folgende Beispiel ersetzt jedes Vorkommen von `years` durch `months` im Text von AutoShapes und macht jeden betroffenen Abschnitt fett:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Diese Durchquerung aktualisiert Text nur in AutoShapes. Text, der in Tabellen, Diagrammen, SmartArt oder Gruppierungen gespeichert ist, erfordert die Durchquerung der jeweiligen Objekt‑Sammlungen.

## **Ein Textfeld mit Hyperlink hinzufügen**

Ein Hyperlink kann einem bestimmten Textabschnitt zugewiesen werden, sodass nur dieser Text als anklickbarer Link fungiert. Verwenden Sie [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), um den Abschnitt mit einer externen URL zu verknüpfen.

Das folgende Beispiel erstellt verlinkten Text und speichert ihn in einer Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Textplatzhalter auf einer Master‑ oder Layout‑Folien?**

Ein [placeholder](/slides/de/python-java/manage-placeholder/) kann seine Position und Formatierung von einer [master slide](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/) oder [layout slide](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/) übernehmen. Ein reguläres Textfeld ist eine eigenständige Form auf der Folie, auf der es erstellt wurde, und übernimmt kein Platzhalter‑Verhalten, wenn sich das Layout ändert.

**Wie kann ich Text ersetzen, ohne den Text in Diagrammen, Tabellen oder SmartArt zu ändern?**

Beschränken Sie die Durchquerung auf Formen, die Instanzen von [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) sind, wie im Beispiel Text aktualisieren gezeigt. Diagramme, Tabellen und SmartArt speichern Text in eigenen Objektmodellen, sodass sie von dieser Schleife nicht verändert werden.