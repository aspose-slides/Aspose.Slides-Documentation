---
title: "Textfelder in Präsentationen mit Python verwalten"
linktitle: "Textfeld verwalten"
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
description: "Aspose.Slides für Python via .NET ermöglicht das einfache Erstellen, Bearbeiten und Kopieren von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert Ihre Präsentationsautomatisierung."
---

## **Übersicht**

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher müssen Sie, um Text zu einer Folie hinzuzufügen, ein Textfeld hinzufügen und dann Text in das Textfeld einfügen. Aspose.Slides für Python stellt die [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) Klasse bereit, die es Ihnen ermöglicht, eine Form mit Text hinzuzufügen.

{{% alert title="Info" color="info" %}}
Aspose.Slides bietet außerdem die [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) Klasse an. Allerdings können nicht alle Formen Text enthalten.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Daher sollten Sie, wenn Sie mit einer Form arbeiten, der Sie Text hinzufügen möchten, überprüfen und bestätigen, dass sie durch die [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) Klasse gecastet wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), das eine Eigenschaft von [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ist, arbeiten. Siehe den Abschnitt [Update Text](/slides/de/python-net/manage-textbox/#update-text) auf dieser Seite.
{{% /alert %}}

## **Textfelder auf Folien erstellen**

Um ein Textfeld auf einer Folie zu erstellen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie eine Referenz zur ersten Folie.
3. Fügen Sie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) mit `ShapeType.RECTANGLE` an der gewünschten Position auf der Folie hinzu.
4. Setzen Sie den Text im [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der Form.
5. Speichern Sie die Präsentation als PPTX-Datei.

Das folgende Python-Beispiel implementiert diese Schritte:
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie aus der Präsentation.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape vom Typ RECTANGLE hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```


## **Überprüfen, ob eine Form ein Textfeld ist**

Aspose.Slides stellt die [is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/) Eigenschaft auf der [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) Klasse bereit, mit der Sie bestimmen können, ob eine Form ein Textfeld ist.

![Textfeld und Form](istextbox.png)

Dieses Python-Beispiel zeigt, wie man prüft, ob eine Form als Textfeld erstellt wurde:
```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```


Beachten Sie, dass wenn Sie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) mit der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) Klasse hinzufügen, die `is_text_box` Eigenschaft der Form `False` zurückgibt. Nachdem Sie jedoch Text hinzugefügt haben – entweder mit der `add_text_frame` Methode oder durch Setzen der `text` Eigenschaft – gibt `is_text_box` `True` zurück.
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box ist falsch
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box ist wahr

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box ist falsch
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box ist wahr

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box ist falsch
    shape3.add_text_frame("")
    # shape3.is_text_box ist falsch

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box ist falsch
    shape4.text_frame.text = ""
    # shape4.is_text_box ist falsch
```


## **Spalten zu Textfeldern hinzufügen**

Aspose.Slides stellt die [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/) und [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/) Eigenschaften auf der [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) Klasse zur Verfügung, um Spalten zu Textfeldern hinzuzufügen. Sie können die Anzahl der Spalten angeben und den Abstand (in Punkten) zwischen den Spalten festlegen.

Der folgende Python-Code demonstriert diesen Vorgang:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Holen Sie die erste Folie aus der Präsentation.
	slide = presentation.slides[0]

	# Fügen Sie eine AutoShape vom Typ RECTANGLE hinzu.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Fügen Sie dem Rechteck ein TextFrame hinzu.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Holen Sie das Textformat des TextFrames.
	format = shape.text_frame.text_frame_format

	# Geben Sie die Anzahl der Spalten im TextFrame an.
	format.column_count = 3

	# Geben Sie den Abstand zwischen den Spalten an.
	format.column_spacing = 10

	# Speichern Sie die Präsentation.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```


## **Text aktualisieren**

Aspose.Slides ermöglicht es Ihnen, den Text in einem einzelnen Textfeld oder in einer gesamten Präsentation zu aktualisieren.

Das folgende Python-Beispiel zeigt, wie man den gesamten Text in einer Präsentation aktualisiert:
```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # Speichern Sie die geänderte Präsentation.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```


## **Textfelder mit Hyperlinks hinzufügen**

Sie können in einem Textfeld einen Link einfügen. Wenn das Textfeld angeklickt wird, öffnet sich der Link.

Um ein Textfeld mit einem Hyperlink hinzuzufügen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie eine Referenz zur ersten Folie.
3. Fügen Sie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) mit `ShapeType.RECTANGLE` an der gewünschten Position auf der Folie hinzu.
4. Setzen Sie den Text im [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der Form.
5. Holen Sie eine Referenz zum [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/).
6. Verwenden Sie die `hyperlink_manager` Eigenschaft, um einen externen Klick-Hyperlink festzulegen.
7. Speichern Sie die Präsentation als PPTX-Datei.

Dieses Python-Beispiel zeigt, wie man ein Textfeld mit einem Hyperlink zu einer Folie hinzufügt:
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie aus der Präsentation.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape vom Typ RECTANGLE hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Text zum Frame hinzufügen.
    text_portion.text = "Aspose.Slides"

    # Setzen Sie einen Hyperlink für den Portion-Text.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Speichern Sie die Präsentation als PPTX-Datei.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Textplatzhalter bei der Arbeit mit Masterfolien?**

Ein [Platzhalter](/slides/de/python-net/manage-placeholder/) erbt Stil/Position vom [Master](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) und kann auf [Layouts](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) überschrieben werden, während ein reguläres Textfeld ein unabhängiges Objekt auf einer bestimmten Folie ist und sich nicht ändert, wenn Sie das Layout wechseln.

**Wie kann ich einen massiven Textaustausch in der gesamten Präsentation durchführen, ohne den Text in Diagrammen, Tabellen und SmartArt zu verändern?**

Beschränken Sie die Iteration auf AutoShapes, die Textframes besitzen, und schließen Sie eingebettete Objekte ([Diagramme](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), [Tabellen](https://reference.aspose.com/slides/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.