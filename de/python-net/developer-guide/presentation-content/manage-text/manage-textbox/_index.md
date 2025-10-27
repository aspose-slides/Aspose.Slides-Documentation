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
description: "Aspose.Slides für Python via .NET ermöglicht das einfache Erstellen, Bearbeiten und Klonen von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert Ihre Präsentationsautomatisierung."
---

## **Übersicht**

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher müssen Sie, um Text zu einer Folie hinzuzufügen, ein Textfeld hinzufügen und dann Text in das Textfeld einfügen. Aspose.Slides für Python stellt die [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Klasse bereit, mit der Sie eine Form mit Text hinzufügen können.

{{% alert title="Info" color="info" %}}
Aspose.Slides bietet außerdem die [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)‑Klasse. Allerdings können nicht alle Formen Text enthalten.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Daher sollten Sie, wenn Sie mit einer Form arbeiten, der Sie Text hinzufügen möchten, prüfen und bestätigen, dass sie über die [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Klasse gecastet wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) arbeiten, das eine Eigenschaft der [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ist. Siehe den Abschnitt [Update Text](/slides/de/python-net/manage-textbox/#update-text) auf dieser Seite.
{{% /alert %}}

## **Textfelder auf Folien erstellen**

Um ein Textfeld auf einer Folie zu erstellen:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Referenz zur ersten Folie.  
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) mit `ShapeType.RECTANGLE` an der gewünschten Position auf der Folie hinzu.  
4. Setzen Sie den Text im [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der Form.  
5. Speichern Sie die Präsentation als PPTX‑Datei.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide in the presentation.
    slide = presentation.slides[0]

    # Add an AutoShape of type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Save the presentation to disk.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Prüfen, ob eine Form ein Textfeld ist**

Aspose.Slides stellt die [is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/)‑Eigenschaft auf der [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Klasse bereit, mit der Sie bestimmen können, ob eine Form ein Textfeld ist.

![Textfeld und Form](istextbox.png)

Dieses Python‑Beispiel zeigt, wie Sie prüfen können, ob eine Form als Textfeld erstellt wurde:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Beachten Sie, dass beim Hinzufügen eines [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) über die [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Klasse die Eigenschaft `is_text_box` den Wert `False` zurückgibt. Nachdem Sie jedoch Text hinzugefügt haben – entweder mit der Methode `add_text_frame` oder durch Setzen der Eigenschaft `text` – liefert `is_text_box` `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box is false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box is true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box is false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box is true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box is false
    shape3.add_text_frame("")
    # shape3.is_text_box is false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box is false
    shape4.text_frame.text = ""
    # shape4.is_text_box is false
```

## **Spalten zu Textfeldern hinzufügen**

Aspose.Slides stellt die [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/)‑ und [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/)‑Eigenschaften auf der [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)-Klasse bereit, um Spalten zu Textfeldern hinzuzufügen. Sie können die Anzahl der Spalten festlegen und den Abstand (in Punkten) zwischen den Spalten bestimmen.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Get the first slide in the presentation.
	slide = presentation.slides[0]

	# Add an AutoShape of type RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Add a TextFrame to the rectangle.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Get the text format of the TextFrame.
	format = shape.text_frame.text_frame_format

	# Specify the number of columns in the TextFrame.
	format.column_count = 3

	# Specify the spacing between columns.
	format.column_spacing = 10

	# Save the presentation.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Text aktualisieren**

Aspose.Slides ermöglicht das Aktualisieren des Textes in einem einzelnen Textfeld oder in der gesamten Präsentation.

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
  
    # Save the modified presentation.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Textfelder mit Hyperlinks hinzufügen**

Sie können einen Link in ein Textfeld einfügen. Beim Anklicken des Textfeldes öffnet sich der Link.

Um ein Textfeld mit einem Hyperlink hinzuzufügen, gehen Sie wie folgt vor:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Referenz zur ersten Folie.  
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) mit `ShapeType.RECTANGLE` an der gewünschten Position auf der Folie hinzu.  
4. Setzen Sie den Text im [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der Form.  
5. Holen Sie sich eine Referenz zum [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/).  
6. Verwenden Sie die Eigenschaft `hyperlink_manager`, um einen externen Klick‑Hyperlink festzulegen.  
7. Speichern Sie die Präsentation als PPTX‑Datei.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide in the presentation.
    slide = presentation.slides[0]

    # Add an AutoShape of type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Add text to the frame.
    text_portion.text = "Aspose.Slides"

    # Set a hyperlink for the portion text.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Save the presentation as a PPTX file.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Text‑Platzhalter bei der Arbeit mit Master‑Folien?**

Ein [Platzhalter](/slides/de/python-net/manage-placeholder/) erbt Stil/Position vom [Master](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) und kann auf [Layouts](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) überschrieben werden, während ein reguläres Textfeld ein unabhängiges Objekt auf einer konkreten Folie ist und sich nicht ändert, wenn Sie das Layout wechseln.

**Wie kann ich einen umfangreichen Textaustausch in der gesamten Präsentation durchführen, ohne Text in Diagrammen, Tabellen und SmartArt zu ändern?**

Beschränken Sie Ihre Iteration auf AutoShapes, die TextFrames besitzen, und schließen Sie eingebettete Objekte ([Diagramme](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), [Tabellen](https://reference.aspose.com/slides/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.