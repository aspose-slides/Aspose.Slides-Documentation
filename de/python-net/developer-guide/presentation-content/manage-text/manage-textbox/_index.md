---
title: TextBox verwalten
type: docs
weight: 20
url: /de/python-net/manage-textbox/
keywords: "Textbox, Textfeld, Textbox hinzufügen, Textbox mit Hyperlink, Python, Aspose.Slides für Python über .NET"
description: "Fügen Sie Textboxen oder Textfelder in PowerPoint-Präsentationen in Python oder .NET hinzu"
---

Texte auf Folien existieren typischerweise in Textfeldern oder Formen. Um also Text zu einer Folie hinzuzufügen, müssen Sie ein Textfeld hinzufügen und dann Text in das Textfeld einfügen. Aspose.Slides für Python über .NET bietet das [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) Interface, das es Ihnen ermöglicht, eine Form hinzuzufügen, die Text enthält.

{{% alert title="Info" color="info" %}}

Aspose.Slides bietet auch das [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) Interface, mit dem Sie Formen zu Folien hinzufügen können. Es können jedoch nicht alle über das `IShape` Interface hinzugefügten Formen Text halten. Aber Formen, die über das [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) Interface hinzugefügt werden, können Text enthalten. 

{{% /alert %}}

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie also mit einer Form umgehen, der Sie Text hinzufügen möchten, sollten Sie überprüfen und bestätigen, dass sie über das `IAutoShape` Interface vererbt wurde. Nur dann können Sie mit dem [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) arbeiten, der eine Eigenschaft unter `IAutoShape` ist. Siehe den Abschnitt [Text aktualisieren](https://docs.aspose.com/slides/python-net/manage-textbox/#update-text) auf dieser Seite. 

{{% /alert %}}

## **Textfeld auf Folie erstellen**

Um ein Textfeld auf einer Folie zu erstellen, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse. 
2. Erhalten Sie eine Referenz zur ersten Folie in der neu erstellten Präsentation. 
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) Objekt mit [ShapeType](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) als `RECTANGLE` an einer bestimmten Position auf der Folie hinzu und erhalten Sie die Referenz für das neu hinzugefügte `IAutoShape` Objekt. 
4. Fügen Sie eine `text_frame` Eigenschaft zum `IAutoShape` Objekt hinzu, die Text enthalten wird. Im folgenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox*
5. Schließlich speichern Sie die PPTX-Datei über das `Presentation` Objekt. 

Dieser Python-Code – eine Implementierung der oben beschriebenen Schritte – zeigt Ihnen, wie Sie Text zu einer Folie hinzufügen:

```py
import aspose.slides as slides

# Instanziiert PresentationEx
with slides.Presentation() as pres:

    # Holt die erste Folie in der Präsentation
    sld = pres.slides[0]

    # Fügt eine AutoShape mit der Art als Rechteck hinzu
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Fügt TextFrame zum Rechteck hinzu
    ashp.add_text_frame(" ")

    # Greift auf das Textfeld zu
    txtFrame = ashp.text_frame

    # Erstellt das Paragraph-Objekt für das Textfeld
    para = txtFrame.paragraphs[0]

    # Erstellt ein Portion-Objekt für den Paragraphen
    portion = para.portions[0]

    # Setzt Text
    portion.text = "Aspose TextBox"

    # Speichert die Präsentation auf der Festplatte
    pres.save("TextBox_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Überprüfen Sie, ob es sich um eine Textfeldform handelt**

Aspose.Slides bietet die `is_text_box` Eigenschaft (aus der [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) Klasse), um Ihnen zu ermöglichen, Formen zu untersuchen und Textfelder zu finden.

![Textfeld und Form](istextbox.png)

Dieser Python-Code zeigt Ihnen, wie Sie überprüfen, ob eine Form als Textfeld erstellt wurde:

```python
from aspose.slides import Presentation, AutoShape

with Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if (type(shape) is AutoShape):
                print("Form ist Textfeld" if shape.is_text_box else "Form ist kein Textfeld")
```

## **Spalte im Textfeld hinzufügen**

Aspose.Slides bietet die [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) und [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) Eigenschaften (aus der [ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) Schnittstelle und der [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) Klasse), die es Ihnen ermöglichen, Spalten zu Textfeldern hinzuzufügen. Sie können die Anzahl der Spalten in einem Textfeld angeben und den Abstand in Punkten zwischen den Spalten festlegen. 

Dieser Code in Python demonstriert die beschriebene Operation:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Holt die erste Folie in der Präsentation
    slide = presentation.slides[0]

    # Fügt eine AutoShape mit der Art als Rechteck hinzu
    aShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

    # Fügt TextFrame zum Rechteck hinzu
    aShape.add_text_frame("Alle diese Spalten sind darauf beschränkt, innerhalb eines einzigen Textcontainers zu bleiben -- " +
    "Sie können Text hinzufügen oder löschen und der neue oder verbleibende Text passt sich automatisch an " +
    "an, um innerhalb des Containers zu fließen. Sie können keinen Text von einem Container " +
    "in einen anderen fließen lassen -- wir haben Ihnen gesagt, dass die Spaltenoptionen von PowerPoint für Text begrenzt sind!")

    # Holt das Textformat des TextFrames
    format = aShape.text_frame.text_frame_format

    # Gibt die Anzahl der Spalten im TextFrame an
    format.column_count = 3

    # Gibt den Abstand zwischen den Spalten an
    format.column_spacing = 10

    # Speichert die Präsentation
    presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Spalte im Textfeld hinzufügen**

Aspose.Slides für Python über .NET bietet die [ColumnCount](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) Eigenschaft (aus der [ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) Schnittstelle), die es Ihnen ermöglicht, Spalten in Textfeldern hinzuzufügen. Über diese Eigenschaft können Sie Ihre bevorzugte Anzahl von Spalten in einem Textfeld angeben. 

Dieser Python-Code zeigt Ihnen, wie Sie eine Spalte innerhalb eines Textfeldes hinzufügen:

```py
import aspose.slides as slides

outPptxFileName = "ColumnsTest.pptx"
with slides.Presentation() as pres:
    shape1 = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)
    format = shape1.text_frame.text_frame_format

    format.column_count = 2
    shape1.text_frame.text = """Alle diese Spalten sind gezwungen, innerhalb eines einzelnen Textcontainers zu bleiben -- 
        Sie können Text hinzufügen oder löschen - und der neue oder verbleibende Text passt sich automatisch 
        an, um innerhalb des Containers zu bleiben. Sie können keinen Text von einem Container 
        in einen anderen überlaufen lassen, da die Spaltenoptionen für Text in PowerPoint begrenzt sind!
        pres.save(outPptxFileName, slides.export.SaveFormat.PPTX)"""

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_spacing = 20
    pres.save(path + outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_count = 3
    format.column_spacing = 15
    pres.save(path + outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)
```

## **Text aktualisieren**

Aspose.Slides ermöglicht es Ihnen, den Text in einem Textfeld oder in allen Texten in einer Präsentation zu ändern oder zu aktualisieren. 

Dieser Python-Code demonstriert eine Operation, bei der alle Texte in einer Präsentation aktualisiert oder geändert werden:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("Jahre", "Monate")
                        portion.portion_format.font_bold = 1
  
    # Speichert die bearbeitete Präsentation
    pres.save("text-changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Textbox mit Hyperlink hinzufügen** 

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, werden die Benutzer aufgefordert, den Link zu öffnen. 

Um ein Textfeld mit einem Link hinzuzufügen, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der `Presentation` Klasse. 
2. Erhalten Sie eine Referenz zur ersten Folie in der neu erstellten Präsentation. 
3. Fügen Sie ein `AutoShape` Objekt mit `ShapeType` als `RECTANGLE` an einer bestimmten Position auf der Folie hinzu und erhalten Sie eine Referenz des neu hinzugefügten AutoShape Objekts.
4. Fügen Sie ein `text_frame` zum `AutoShape` Objekt hinzu, das *Aspose TextBox* als Standardtext enthält. 
5. Instanziieren Sie die `hyperlink_manager` Klasse. 
6. Weisen Sie das `hyperlink_manager` Objekt der [HyperlinkClick](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) Eigenschaft zu, die mit Ihrem bevorzugten Teil des `TextFrame` verbunden ist. 
7. Schließlich speichern Sie die PPTX-Datei über das `Presentation` Objekt. 

Dieser Python-Code - eine Implementierung der oben beschriebenen Schritte - zeigt Ihnen, wie Sie ein Textfeld mit einem Hyperlink zu einer Folie hinzufügen:

```py
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine PPTX darstellt
with slides.Presentation() as pptxPresentation:
    # Holt die erste Folie in der Präsentation
    slide = pptxPresentation.slides[0]

    # Fügt ein AutoShape Objekt mit der Art als Rechteck hinzu
    pptxShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    # Greift auf die ITextFrame-Eigenschaft zu, die mit dem AutoShape verbunden ist
    pptxShape.add_text_frame("")

    textFrame = pptxShape.text_frame

    # Fügt Text zum Rahmen hinzu
    textFrame.paragraphs[0].portions[0].text = "Aspose.Slides"

    # Setzt den Hyperlink für den Textteil
    hm = textFrame.paragraphs[0].portions[0].portion_format.hyperlink_manager
    hm.set_external_hyperlink_click("http://www.aspose.com")
    # Speichert die PPTX-Präsentation
    pptxPresentation.save("hLinkPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```