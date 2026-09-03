---
title: Textfelder in Präsentationen mit Python verwalten
linktitle: Textfeld verwalten
type: docs
weight: 20
url: /de/python-net/manage-textbox/
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
- Aspose.Slides
description: "Erstellen, erkennen, formatieren und aktualisieren Sie Textfelder in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python über .NET."
---
## **Einführung**

In Aspose.Slides for Python via .NET wird der Folientext in Textframes gespeichert, die zu Formen gehören. Die [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) Klasse repräsentiert die am häufigsten vorkommende Text‑tragende Form und stellt ihren Text über die [AutoShape.text_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/text_frame/) Eigenschaft bereit.

{{% alert color="info" title="Hinweis" %}}

Jede AutoShape erbt von [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/), aber nicht jede Form ist eine AutoShape oder unterstützt einen Textframe. Beim Verarbeiten einer bestehenden Präsentation verwenden Sie `isinstance(shape, slides.AutoShape)`, um den Formtyp zu prüfen, bevor Sie auf ihren Text zugreifen.

{{% /alert %}}

## **Eine Textbox auf einer Folie erstellen**

Um eine Textbox zu erstellen, fügen Sie einer Folie eine AutoShape hinzu, fügen Sie ihrem Textframe Text hinzu und speichern Sie die Präsentation. Das folgende Beispiel erzeugt eine rechteckige Textbox:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

Die an [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_auto_shape/) übergebenen Koordinaten und Abmessungen werden in Punkten gemessen. [AutoShape.add_text_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/add_text_frame/) initialisiert den Textframe mit dem angegebenen Text.

## **Überprüfen, ob eine Form eine Textbox ist**

Verwenden Sie die [AutoShape.is_text_box](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/is_text_box/) Eigenschaft, um festzustellen, ob eine AutoShape als Textbox behandelt wird. Dies ist nützlich, wenn eine Präsentation sowohl Text‑tragende als auch rein grafische AutoShapes enthält.

![Eine Textbox und eine Form](istextbox.png)

Das folgende Beispiel untersucht jede AutoShape in einer Präsentation:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

Eine neu hinzugefügte AutoShape wird erst dann als Textbox angesehen, wenn sie nicht‑leeren Text enthält. Sie können diesen Text über [AutoShape.add_text_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/add_text_frame/) oder [TextFrame.text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/text/) zuweisen. Das Hinzufügen oder Zuweisen einer leeren Zeichenkette lässt [is_text_box](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/is_text_box/) auf `False` gesetzt:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

Die ersten beiden Aufrufe geben `True` aus; die letzten beiden geben `False` aus.

## **Die Form finden, die einen Textframe besitzt**

Allgemeiner Textverarbeitungscode kann ein [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) erhalten, ohne zu wissen, welches Präsentationsobjekt es enthält. Verwenden Sie die schreibgeschützte [TextFrame.parent_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/parent_shape/) Eigenschaft, um zurück zur zugehörigen [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/) zu navigieren.

Für einen Textframe, der einer AutoShape oder einer anderen Text‑tragenden Form gehört, enthält [parent_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/parent_shape/) den Besitzer und [TextFrame.parent_cell](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/parent_cell/) ist `None`. Prüfen Sie den zurückgegebenen Wert, bevor Sie darauf zugreifen. Um sowohl Form‑ als auch Tabellenzellen‑Besitzer zu identifizieren, einschließlich Formen, die mit SmartArt‑Knoten verbunden sind, siehe [Search and Replace Text](/slides/de/python-net/search-and-replace-text/).

## **Spalten zu einer Textbox hinzufügen**

Die [TextFrameFormat.column_count](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/column_count/) Eigenschaft teilt den Textframe in Spalten, während [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/column_spacing/) den Abstand zwischen den Spalten in Punkten festlegt. Beide Einstellungen gehören zu [TextFrameFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/) und können über den Textframe einer bestehenden Textbox geändert werden. Der Text fließt zwischen den Spalten innerhalb derselben Form um; er wird nicht in eine andere Form fortgesetzt.

Das folgende Beispiel erstellt eine dreispaltige Textbox mit 10 Punkten Abstand zwischen den Spalten, speichert die Präsentation und liest die gespeicherten Einstellungen aus der Ausgabedatei zurück:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Text aus einzelnen Spalten extrahieren**

Verwenden Sie [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/split_text_by_columns/), um den Text abzurufen, der jedem sichtbaren Spaltenbereich in einem bestehenden Textframe zugewiesen ist. Die Methode gibt für jede Spalte einen String zurück, in spaltenbasierter Lesereihenfolge. Ein einspaltiger Textframe liefert eine Liste mit einem Element, und eine leere Spalte wird durch einen leeren String dargestellt. Die Strings enthalten ausschließlich reinen Text; Formatierungen auf Portion‑Ebene werden nicht erhalten.

Dies ist nützlich, wenn Sie:

- Text extrahieren und dabei seine spaltenbasierte Lesereihenfolge beibehalten.
- Den Inhalt mehrspaltiger Folien indexieren oder vergleichen.
- Jede Spalte in eine separate Datei, ein Datenbankfeld oder ein anderes Ziel exportieren.
- Untersuchen, wie Text nach dem Ändern von [TextFrameFormat.column_count](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/column_count/), [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/column_spacing/), der Schriftart oder der Größe des Textframes umverteilt wird.

Die Methode gibt den Text zurück, der im aktuellen [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) verteilt ist; sie verteilt Text nicht automatisch zwischen separaten Formen oder Textboxen. Die Spaltenverteilung kann von verfügbaren Schriftarten und anderen Text‑Layout‑Einstellungen abhängen, daher sollten die erforderlichen Schriftarten vorhanden sein, wenn konsistente Ergebnisse wichtig sind.

Das folgende Beispiel lädt eine Präsentation, findet die erste mehrspaltige AutoShape mit einem Textframe, liest die konfigurierte Spaltenanzahl aus und schreibt den Text jeder Spalte in eine separate Datei. Formen, die keinen Textframe bereitstellen, werden übersprungen.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Text aktualisieren**

Um Text in einer gesamten Präsentation zu aktualisieren, iterieren Sie über die Folien und Formen, wählen AutoShapes aus und bearbeiten dann deren Textportionen. Das Arbeiten auf Portionsebene ermöglicht das Ändern sowohl des Textes als auch der Zeichenformatierung.

Das folgende Beispiel ersetzt jedes Vorkommen von `years` durch `months` in AutoShape‑Texten und macht jede betroffene Portion fett:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

Dieser Durchlauf aktualisiert nur den Text in AutoShapes. Text, der in Tabellen, Diagrammen, SmartArt oder gruppierten Formen gespeichert ist, erfordert die Traversierung der jeweiligen Objekt‑Sammlungen.

## **Eine Textbox mit Hyperlink hinzufügen**

Einem bestimmten Textabschnitt kann ein Hyperlink zugewiesen werden, sodass nur dieser Text als anklickbarer Link fungiert. Verwenden Sie [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), um den Abschnitt mit einer externen URL zu verknüpfen.

Das folgende Beispiel erstellt verknüpften Text und speichert ihn in einer Präsentation:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Was ist der Unterschied zwischen einer Textbox und einem Textplatzhalter auf einer Master‑ oder Layout‑Folie?**

Ein [Platzhalter](/slides/de/python-net/manage-placeholder/) kann seine Position und Formatierung von einer [Master‑Folie](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslide/) oder [Layout‑Folie](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/) erben. Eine reguläre Textbox ist eine unabhängige Form auf der Folie, auf der sie erstellt wurde, und übernimmt kein Platzhalter‑Verhalten, wenn das Layout geändert wird.

**Wie kann ich Text ersetzen, ohne den Text in Diagrammen, Tabellen oder SmartArt zu ändern?**

Begrenzen Sie die Traversierung auf [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/)‑Instanzen, wie im Beispiel „Text aktualisieren“ gezeigt. Diagramme, Tabellen und SmartArt speichern Text in eigenen Objektmodellen, sodass sie von dieser Schleife nicht geändert werden.