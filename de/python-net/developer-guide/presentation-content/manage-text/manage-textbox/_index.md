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
description: "Aspose.Slides für Python via .NET erleichtert das Erstellen, Bearbeiten und Kopieren von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert die Automatisierung Ihrer Präsentationen."
---
## **Einführung**

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher muss man, um einen Text zu einer Folie hinzuzufügen, ein Textfeld einfügen und dann Text in das Textfeld setzen. Aspose.Slides für Python stellt die [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/)‑Klasse bereit, die es ermöglicht, eine Form mit Text hinzuzufügen.

{{% alert title="Info" color="info" %}}
Aspose.Slides stellt außerdem die [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/)‑Klasse bereit. Allerdings können nicht alle Formen Text enthalten.
{{% /alert %}}

{{% alert title="Hinweis" color="warning" %}}
Daher sollte man, wenn man mit einer Form arbeitet, zu der man Text hinzufügen möchte, prüfen und bestätigen, dass sie über die [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/)‑Klasse gecastet wurde. Nur dann kann man mit [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) arbeiten, das eine Eigenschaft von [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) ist. Siehe den Abschnitt [Update Text](/slides/de/python-net/manage-textbox/#update-text) auf dieser Seite.
{{% /alert %}}

## **Textfelder auf Folien erstellen**

Um ein Textfeld auf einer Folie zu erstellen:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich eine Referenz zur ersten Folie.
3. Fügen Sie eine [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) mit `ShapeType.RECTANGLE` an der gewünschten Position auf der Folie hinzu.
4. Setzen Sie den Text im [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) der Form.
5. Speichern Sie die Präsentation als PPTX‑Datei.

Das folgende Python‑Beispiel implementiert diese Schritte:

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse.
with slides.Presentation() as presentation:

    # Erste Folie in der Präsentation holen.
    slide = presentation.slides[0]

    # AutoShape vom Typ RECTANGLE hinzufügen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Präsentation auf Festplatte speichern.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Überprüfen, ob eine Form ein Textfeld ist**

Aspose.Slides bietet die [is_text_box](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/is_text_box/)‑Eigenschaft auf der [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/)‑Klasse, mit der Sie bestimmen können, ob eine Form ein Textfeld ist.

![Textbox and shape](istextbox.png)

Dieses Python‑Beispiel zeigt, wie man prüft, ob eine Form als Textfeld erstellt wurde:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Beachten Sie, dass wenn Sie eine [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) über die [ShapeCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/)‑Klasse hinzufügen, die Eigenschaft `is_text_box` `False` zurückgibt. Nachdem Sie jedoch Text hinzugefügt haben – entweder mit der `add_text_frame`‑Methode oder indem Sie die `text`‑Eigenschaft setzen – gibt `is_text_box` `True` zurück.

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

## **Die Form finden, die einen TextFrame besitzt**

In generischem Textverarbeitungs‑Code erhalten Sie möglicherweise ein [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/), ohne zu wissen, welches Präsentations‑Objekt es enthält. Verwenden Sie die [TextFrame.parent_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/parent_shape/)‑Eigenschaft, um zurück zur Besitz‑[Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/) zu navigieren.

Für einen TextFrame, der zu einer [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) oder einer anderen text‑enthaltenden Form gehört, ist [TextFrame.parent_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/parent_shape/) gesetzt und [TextFrame.parent_cell](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/parent_cell/) ist `None`. Beide Eigenschaften sind schreibgeschützte Navigations‑Properties, sodass das Lesen sie nicht die Besitzverhältnisse ändert. Prüfen Sie stets, ob der zurückgegebene Wert `None` ist, bevor Sie auf die Form zugreifen.

Ein komplettes Beispiel, das Form‑ und Tabellen‑Zell‑Eigentümer identifiziert, einschließlich Formen, die zu SmartArt‑Knoten gehören, finden Sie unter [Search and Replace Text](/slides/de/python-net/search-and-replace-text/).

## **Spalten zu Textfeldern hinzufügen**

Aspose.Slides stellt die [column_count](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/column_count/)‑ und [column_spacing](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/column_spacing/)‑Eigenschaften auf der [TextFrameFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/)‑Klasse bereit, um Spalten zu Textfeldern hinzuzufügen. Sie können die Anzahl der Spalten festlegen und den Abstand (in Punkten) zwischen den Spalten einstellen.

Der folgende Python‑Code demonstriert diese Operation:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Holen Sie die erste Folie in der Präsentation.
	slide = presentation.slides[0]

	# AutoShape vom Typ RECTANGLE hinzufügen.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# TextFrame zum Rechteck hinzufügen.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Das Textformat des TextFrames holen.
	format = shape.text_frame.text_frame_format

	# Anzahl der Spalten im TextFrame angeben.
	format.column_count = 3

	# Abstand zwischen den Spalten angeben.
	format.column_spacing = 10

	# Präsentation speichern.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Text aktualisieren**

Aspose.Slides ermöglicht es Ihnen, den Text in einem einzelnen Textfeld oder in der gesamten Präsentation zu aktualisieren.

Das folgende Python‑Beispiel zeigt, wie man allen Text in einer Präsentation aktualisiert:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # Speichern der modifizierten Präsentation.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Textfelder mit Hyperlinks hinzufügen**

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, öffnet sich der Link.

Um ein Textfeld mit einem Hyperlink hinzuzufügen, führen Sie folgende Schritte aus:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich eine Referenz zur ersten Folie.
3. Fügen Sie eine [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) mit `ShapeType.RECTANGLE` an der gewünschten Position auf der Folie hinzu.
4. Setzen Sie den Text im [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) der Form.
5. Holen Sie sich eine Referenz zum [HyperlinkManager](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkmanager/).
6. Verwenden Sie die `hyperlink_manager`‑Eigenschaft, um einen externen Klick‑Hyperlink festzulegen.
7. Speichern Sie die Präsentation als PPTX‑Datei.

Dieses Python‑Beispiel zeigt, wie man ein Textfeld mit einem Hyperlink zu einer Folie hinzufügt:

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse.
with slides.Presentation() as presentation:

    # Erste Folie der Präsentation holen.
    slide = presentation.slides[0]

    # AutoShape vom Typ RECTANGLE hinzufügen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Text zum Textrahmen hinzufügen.
    text_portion.text = "Aspose.Slides"

    # Hyperlink für den Portion-Text festlegen.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Präsentation als PPTX-Datei speichern.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Textplatzhalter bei der Arbeit mit Master‑Folien?**

Ein [placeholder](/slides/de/python-net/manage-placeholder/) erbt Stil/Position vom [master](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslide/) und kann auf [layouts](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/) überschrieben werden, während ein normales Textfeld ein eigenständiges Objekt auf einer bestimmten Folie ist und sich nicht ändert, wenn Sie das Layout wechseln.

**Wie kann ich einen massenhaften Textaustausch über die gesamte Präsentation hinweg durchführen, ohne Text in Diagrammen, Tabellen und SmartArt zu berühren?**

Beschränken Sie Ihre Iteration auf AutoShapes, die TextFrames besitzen, und schließen Sie eingebettete Objekte ([charts](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/de/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.