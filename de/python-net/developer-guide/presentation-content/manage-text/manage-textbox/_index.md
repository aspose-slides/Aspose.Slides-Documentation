---
title: Textfelder in Präsentationen mit Python verwalten
linktitle: Textfeld verwalten
type: docs
weight: 20
url: /de/python-net/manage-textbox/
keywords:
- textfeld
- textrahmen
- text hinzufügen
- text aktualisieren
- textfeld erstellen
- textfeld prüfen
- textspalte hinzufügen
- hyperlink hinzufügen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Aspose.Slides für Python via .NET erleichtert das Erstellen, Bearbeiten und Kopieren von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert so die Automatisierung Ihrer Präsentationen."
---

## **Übersicht**

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher muss zum Hinzufügen von Text zu einer Folie zunächst ein Textfeld eingefügt und anschließend Text darin platziert werden. Aspose.Slides für Python stellt die Klasse [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) bereit, mit der Sie eine Form mit Text hinzufügen können.

{{% alert title="Info" color="info" %}}
Aspose.Slides bietet außerdem die Klasse [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/). Nicht alle Formen können jedoch Text enthalten.
{{% /alert %}}

{{% alert title="Hinweis" color="warning" %}}
Wenn Sie einer Form Text hinzufügen möchten, sollten Sie prüfen, ob sie mittels der Klasse [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) erstellt wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) arbeiten, das eine Eigenschaft von [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ist. Siehe den Abschnitt [Text aktualisieren](/slides/de/python-net/manage-textbox/#update-text) auf dieser Seite.
{{% /alert %}}

## **Textfelder auf Folien erstellen**

So erstellen Sie ein Textfeld auf einer Folie:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich einen Verweis auf die erste Folie.
3. Fügen Sie an der gewünschten Position auf der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) mit `ShapeType.RECTANGLE` hinzu.
4. Setzen Sie den Text im [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der Form.
5. Speichern Sie die Präsentation als PPTX-Datei.

Das folgende Python‑Beispiel implementiert diese Schritte:

```py
import aspose.slides as slides

# Instanziieren der Presentation‑Klasse.
with slides.Presentation() as presentation:

    # Erste Folie der Präsentation holen.
    slide = presentation.slides[0]

    # AutoShape vom Typ RECTANGLE hinzufügen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Präsentation auf dem Datenträger speichern.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Prüfen, ob eine Form ein Textfeld ist**

Aspose.Slides stellt die Eigenschaft [is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/) in der Klasse [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) bereit, mit der Sie ermitteln können, ob eine Form ein Textfeld ist.

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

Beachten Sie, dass das `is_text_box`‑Attribut `False` zurückgibt, wenn Sie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) über die Klasse [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) hinzufügen. Nachdem Sie jedoch Text hinzugefügt haben – entweder mit der Methode `add_text_frame` oder durch Setzen der Eigenschaft `text` – gibt `is_text_box` `True` zurück.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box ist false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box ist true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box ist false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box ist true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box ist false
    shape3.add_text_frame("")
    # shape3.is_text_box ist false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box ist false
    shape4.text_frame.text = ""
    # shape4.is_text_box ist false
```

## **Spalten zu Textfeldern hinzufügen**

Aspose.Slides stellt die Eigenschaften [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/) und [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/) in der Klasse [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) bereit, um Spalten zu Textfeldern hinzuzufügen. Sie können die Anzahl der Spalten festlegen und den Abstand (in Punkten) zwischen den Spalten bestimmen.

Der folgende Python‑Code demonstriert diesen Vorgang:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Erste Folie der Präsentation holen.
	slide = presentation.slides[0]

	# AutoShape vom Typ RECTANGLE hinzufügen.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Ein TextFrame zum Rechteck hinzufügen.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Textformat des TextFrames holen.
	format = shape.text_frame.text_frame_format

	# Anzahl der Spalten im TextFrame festlegen.
	format.column_count = 3

	# Abstand zwischen den Spalten festlegen.
	format.column_spacing = 10

	# Präsentation speichern.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Text aktualisieren**

Aspose.Slides ermöglicht das Aktualisieren des Textes in einem einzelnen Textfeld oder in der gesamten Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie den gesamten Text einer Präsentation aktualisieren:

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
  
    # Geänderte Präsentation speichern.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Textfelder mit Hyperlinks hinzufügen** 

Sie können einen Link in einem Textfeld einfügen. Beim Klicken auf das Textfeld wird der Link geöffnet.

So fügen Sie ein Textfeld mit einem Hyperlink hinzu:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich einen Verweis auf die erste Folie.
3. Fügen Sie an der gewünschten Position auf der Folie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) mit `ShapeType.RECTANGLE` hinzu.
4. Setzen Sie den Text im [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der Form.
5. Holen Sie sich einen Verweis auf den [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/).
6. Verwenden Sie die Eigenschaft `hyperlink_manager`, um einen externen Klick‑Hyperlink zu setzen.
7. Speichern Sie die Präsentation als PPTX‑Datei.

Dieses Python‑Beispiel zeigt, wie Sie einem Folien‑Textfeld einen Hyperlink hinzufügen:

```py
import aspose.slides as slides

# Instanziieren der Presentation‑Klasse.
with slides.Presentation() as presentation:

    # Erste Folie der Präsentation holen.
    slide = presentation.slides[0]

    # AutoShape vom Typ RECTANGLE hinzufügen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Text zum Frame hinzufügen.
    text_portion.text = "Aspose.Slides"

    # Hyperlink für den Portion‑Text setzen.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Präsentation als PPTX-Datei speichern.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Text‑Platzhalter bei der Arbeit mit Master‑Folien?**

Ein [Platzhalter](/slides/de/python-net/manage-placeholder/) erbt Stil/Position vom [Master](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) und kann in [Layouts](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) überschrieben werden, während ein normales Textfeld ein unabhängiges Objekt auf einer bestimmten Folie ist und sich beim Wechseln von Layouts nicht ändert.

**Wie kann ich einen massiven Text‑Austausch in der gesamten Präsentation durchführen, ohne Texte in Diagrammen, Tabellen und SmartArt zu berühren?**

Beschränken Sie die Iteration auf AutoShapes, die TextFrames besitzen, und schließen Sie eingebettete Objekte ([Diagramme](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), [Tabellen](https://reference.aspose.com/slides/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.