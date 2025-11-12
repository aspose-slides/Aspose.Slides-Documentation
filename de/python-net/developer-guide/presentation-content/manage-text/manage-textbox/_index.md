---
title: Textfelder in Präsentationen mit Python verwalten
linktitle: Textfeld verwalten
type: docs
weight: 20
url: /de/python-net/manage-textbox/
keywords:
- Textfeld
- Textbereich
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
description: "Aspose.Slides für Python via .NET ermöglicht das einfache Erstellen, Bearbeiten und Klonen von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert die Automatisierung Ihrer Präsentationen."
---

## **Übersicht**

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher müssen Sie, um Text zu einer Folie hinzuzufügen, zunächst ein Textfeld hinzufügen und dann Text in das Textfeld einfügen. Aspose.Slides für Python bietet die AutoShape-Klasse, mit der Sie eine Form mit Text hinzufügen können.

{{% alert title="Info" color="info" %}}
Aspose.Slides bietet außerdem die Shape-Klasse. Allerdings können nicht alle Formen Text enthalten.
{{% /alert %}}

{{% alert title="Hinweis" color="warning" %}}
Daher sollten Sie, wenn Sie mit einer Form arbeiten, der Sie Text hinzufügen möchten, prüfen und bestätigen, dass sie über die AutoShape-Klasse gecastet wurde. Nur dann können Sie mit TextFrame arbeiten, das eine Eigenschaft der AutoShape ist. Siehe den Abschnitt Text aktualisieren auf dieser Seite.
{{% /alert %}}

## **Textfelder auf Folien erstellen**

1. Erstellen Sie eine Instanz der Presentation-Klasse.
2. Holen Sie eine Referenz zur ersten Folie.
3. Fügen Sie ein AutoShape vom Typ ShapeType.RECTANGLE an der gewünschten Position auf der Folie hinzu.
4. Setzen Sie den Text im TextFrame der Form.
5. Speichern Sie die Präsentation als PPTX-Datei.

Der folgende Python‑Beispielcode implementiert diese Schritte:

```py
import aspose.slides as slides

# Instanziiert die Presentation-Klasse.
with slides.Presentation() as presentation:

    # Holt die erste Folie in der Präsentation.
    slide = presentation.slides[0]

    # Fügt ein AutoShape vom Typ RECTANGLE hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Speichert die Präsentation auf dem Datenträger.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Prüfen, ob eine Form ein Textfeld ist**

Aspose.Slides stellt die is_text_box-Eigenschaft in der AutoShape-Klasse bereit, mit der Sie ermitteln können, ob eine Form ein Textfeld ist.

![Text box and shape](istextbox.png)

Dieses Python‑Beispiel zeigt, wie man prüft, ob eine Form als Textfeld erstellt wurde:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Beachten Sie, dass wenn Sie ein AutoShape mit der ShapeCollection-Klasse hinzufügen, die `is_text_box`-Eigenschaft der Form `False` zurückgibt. Nachdem Sie jedoch Text hinzugefügt haben – entweder mit der `add_text_frame`‑Methode oder durch Setzen der `text`‑Eigenschaft – gibt `is_text_box` `True` zurück.

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

Aspose.Slides stellt die Eigenschaften column_count und column_spacing in der TextFrameFormat‑Klasse bereit, um Spalten zu Textfeldern hinzuzufügen. Sie können die Anzahl der Spalten festlegen und den Abstand (in Punkten) zwischen den Spalten bestimmen.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Holt die erste Folie in der Präsentation.
	slide = presentation.slides[0]

	# Fügt ein AutoShape vom Typ RECTANGLE hinzu.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Fügt dem Rechteck ein TextFrame hinzu.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Ruft das Textformat des TextFrames ab.
	format = shape.text_frame.text_frame_format

	# Gibt die Anzahl der Spalten im TextFrame an.
	format.column_count = 3

	# Gibt den Abstand zwischen den Spalten an.
	format.column_spacing = 10

	# Speichert die Präsentation.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Text aktualisieren**

Aspose.Slides ermöglicht das Aktualisieren des Texts in einem einzelnen Textfeld oder in der gesamten Präsentation.

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

Sie können in ein Textfeld einen Link einfügen. Wenn das Textfeld angeklickt wird, öffnet sich der Link.

Um ein Textfeld mit einem Hyperlink hinzuzufügen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Presentation-Klasse.
2. Holen Sie eine Referenz zur ersten Folie.
3. Fügen Sie ein AutoShape mit ShapeType.RECTANGLE an der gewünschten Position auf der Folie hinzu.
4. Setzen Sie den Text im TextFrame der Form.
5. Holen Sie eine Referenz zum HyperlinkManager.
6. Verwenden Sie die hyperlink_manager‑Eigenschaft, um einen externen Klick‑Hyperlink festzulegen.
7. Speichern Sie die Präsentation als PPTX-Datei.

Dieses Python‑Beispiel zeigt, wie man ein Textfeld mit einem Hyperlink zu einer Folie hinzufügt:

```py
import aspose.slides as slides

# Instanziiert die Presentation-Klasse.
with slides.Presentation() as presentation:

    # Holt die erste Folie in der Präsentation.
    slide = presentation.slides[0]

    # Fügt ein AutoShape vom Typ RECTANGLE hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Fügt dem Frame Text hinzu.
    text_portion.text = "Aspose.Slides"

    # Setzt einen Hyperlink für den Abschnittstext.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Speichert die Präsentation als PPTX-Datei.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Textplatzhalter bei der Arbeit mit Masterfolien?**

Ein Platzhalter übernimmt Stil/Position vom Master und kann in Layouts überschrieben werden, während ein normales Textfeld ein unabhängiges Objekt auf einer bestimmten Folie ist und sich beim Wechseln von Layouts nicht ändert.

**Wie kann ich einen massiven Textaustausch in der gesamten Präsentation durchführen, ohne Text in Diagrammen, Tabellen und SmartArt zu verändern?**

Begrenzen Sie Ihre Iteration auf AutoShapes, die TextFrames besitzen, und schließen Sie eingebettete Objekte (Diagramme, Tabellen, SmartArt) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.