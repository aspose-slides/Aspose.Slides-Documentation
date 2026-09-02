---
title: Verwalten von Präsentationskommentaren in Python
linktitle: Präsentationskommentare
type: docs
weight: 100
url: /de/python-net/presentation-comments/
keywords:
- Kommentar
- moderner Kommentar
- PowerPoint-Kommentare
- Präsentationskommentare
- Folienkommentare
- Kommentar hinzufügen
- Kommentar abrufen
- Kommentar bearbeiten
- Kommentar antworten
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie Präsentationskommentare mit Aspose.Slides für Python via .NET: Kommentare in PowerPoint‑Präsentationen hinzufügen, lesen, bearbeiten, beantworten und entfernen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Präsentationskommentare mit Aspose.Slides für Python via .NET verwaltet. Er stellt die wichtigsten kommentarbezogenen Typen vor und zeigt, wie man Kommentare zu Folien hinzufügt, vorhandene Kommentare abruft, mit Antworten und modernen Kommentaren arbeitet und Kommentare aus einer Präsentation entfernt.

Die Beispiele decken gängige Überprüfungs‑ und Zusammenarbeitsszenarien in PowerPoint ab, wie das Zuweisen von Kommentaren zu Autoren, das Lesen von Kommentartexten und Metadaten, das Erstellen von Antwortketten und das Entfernen ausgewählter Kommentare oder aller Kommentare.

In PowerPoint werden Kommentare als Anmerkungen auf Folien angezeigt. Das Auswählen eines Kommentars zeigt dessen Text und die zugehörige Diskussion an.

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie können Kommentare verwenden, um Feedback zu geben und bei der Durchsicht von Präsentationen mit Kollegen zusammenzuarbeiten.

Aspose.Slides für Python via .NET bietet die folgenden APIs zur Arbeit mit Kommentaren:

* Die [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Klasse, die Zugriff auf die Kommentarautoren der Präsentation bietet.
* Die [CommentCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/commentcollection/) Klasse, die die mit einem einzelnen Autor verknüpften Kommentare darstellt.
* Die [Comment](https://reference.aspose.com/slides/de/python-net/aspose.slides/comment/) Klasse, die Informationen zu einem Kommentar liefert, einschließlich Autor, Erstellungszeit, Position und Text.
* Die [CommentAuthor](https://reference.aspose.com/slides/de/python-net/aspose.slides/commentauthor/) Klasse, die Informationen zu einem Autor liefert, einschließlich Name, Initialen und zugehöriger Kommentare.

## **Folienkommentare hinzufügen**

Das folgende Beispiel zeigt, wie man Kommentare zu Folien in einer PowerPoint‑Präsentation hinzufügt:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
    created_time = datetime.now()

    author.comments.add_comment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.comments.add_comment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.get_slide_comments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.text)

        comment_text = first_comment.author.comments[0].text
        print(comment_text)

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Folienkommentare abrufen**

Das folgende Beispiel zeigt, wie man vorhandene Kommentare in einer PowerPoint‑Präsentation abruft:

```python
import aspose.slides as slides

with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("Slide: " + str(comment.slide.slide_number))
            print("Comment: " + comment.text)
            print("Author: " + comment.author.name)
            print("Posted at: " + str(comment.created_time))
            print()
```

## **Auf Kommentare antworten**

Ein Elternkommentar ist der ursprüngliche Kommentar an der Spitze einer Antworthierarchie. Die [parent_comment](https://reference.aspose.com/slides/de/python-net/aspose.slides/comment/parent_comment/) Eigenschaft der [Comment](https://reference.aspose.com/slides/de/python-net/aspose.slides/comment/) Klasse ermöglicht das Abrufen oder Festlegen des übergeordneten Kommentars.

Das folgende Beispiel zeigt, wie man Antworten hinzufügt und die resultierende Kommentarhierarchie untersucht:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* Wenn die [remove](https://reference.aspose.com/slides/de/python-net/aspose.slides/comment/remove/) Methode der [Comment](https://reference.aspose.com/slides/de/python-net/aspose.slides/comment/) Klasse verwendet wird, um einen Kommentar zu löschen, werden alle Antworten auf diesen Kommentar ebenfalls gelöscht.
* Wenn die [parent_comment](https://reference.aspose.com/slides/de/python-net/aspose.slides/comment/parent_comment/) Eigenschaft eine zirkuläre Referenz erzeugt, wird eine [PptxEditException](https://reference.aspose.com/slides/de/python-net/aspose.slides/pptxeditexception/) ausgelöst.
{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Moderne Kommentare können der Folie selbst, einer bestimmten Form oder einem Textbereich innerhalb einer AutoShape zugeordnet werden. Die Methode [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/de/python-net/aspose.slides/commentcollection/add_modern_comment/) akzeptiert ein [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/) Argument zusätzlich zu den Folien‑ und Kommentar‑Marker‑Koordinaten.

Wenn `None` für das Shape‑Argument übergeben wird, handelt es sich bei dem Kommentar um einen Folien‑Ebene‑Kommentar. Sein Marker wird anhand der übergebenen Koordinaten positioniert, ist jedoch keiner bestimmten Form zugeordnet, sodass [ModernComment.shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/moderncomment/shape/) `None` zurückgibt. Wird ein [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/) angegeben, wird der Kommentar an diese Form verankert. Die Koordinaten definieren weiterhin die Position des Kommentar‑Markers auf der Folie, während die Formzugehörigkeit über [ModernComment.shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/moderncomment/shape/) abgerufen werden kann.

### **Einen modernen Kommentar an einer Form verankern**

Das folgende Beispiel erstellt sowohl einen Folien‑Ebene‑modernen Kommentar als auch einen modernen Kommentar, der an einer bestimmten AutoShape verankert ist. Anschließend wird die zugehörige Form aus jedem Kommentar gelesen.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Kommentare an verschiedenen Formtypen verankern**

Jedes Folienobjekt, das von [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/) abgeleitet ist, kann als Formanker verwendet werden. Häufige Beispiele sind [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/de/python-net/aspose.slides/connector/) und [GraphicalObject](https://reference.aspose.com/slides/de/python-net/aspose.slides/graphicalobject/) Instanzen wie Diagramme.

Das folgende Beispiel erstellt mehrere gängige Formtypen und verknüpft einen modernen Kommentar mit jedem von ihnen.

```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Einen Kommentar an Text verankern und seinen Status festlegen**

Bei einem modernen Kommentar, der mit einer [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) verknüpft ist, gibt [ModernComment.text_selection_start](https://reference.aspose.com/slides/de/python-net/aspose.slides/moderncomment/text_selection_start/) die Startposition des ausgewählten Textes im Textfeld der Form an, während [ModernComment.text_selection_length](https://reference.aspose.com/slides/de/python-net/aspose.slides/moderncomment/text_selection_length/) die Länge der Auswahl bestimmt. Zusammen verknüpfen diese Eigenschaften den Kommentar mit einem bestimmten Textbereich innerhalb der AutoShape.

Die [ModernComment.status](https://reference.aspose.com/slides/de/python-net/aspose.slides/moderncomment/status/) Eigenschaft kann gelesen oder mit einem Wert aus der Aufzählung [ModernCommentStatus](https://reference.aspose.com/slides/de/python-net/aspose.slides/moderncommentstatus/) aktualisiert werden:
- `NOT_DEFINED` — kein spezifischer Moderner‑Kommentar‑Status definiert.
- `ACTIVE` — der Kommentar ist aktiv.
- `RESOLVED` — der Kommentar wurde gelöst.
- `CLOSED` — der Kommentar ist geschlossen.

Das folgende Beispiel erstellt einen an einer Form verankerten modernen Kommentar, verknüpft ihn mit einer Textauswahl, markiert ihn als gelöst, speichert die Präsentation und prüft die Werte nach dem erneuten Öffnen der Datei.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.index(selected_text)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 100)
    shape.name = "Forecast text"
    shape.text_frame.text = shape_text

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    comment_position = draw.PointF(60, 60)
    comment = author.comments.add_modern_comment("Verify this forecast wording.", slide, shape, comment_position, datetime.now())
    comment.text_selection_start = expected_selection_start
    comment.text_selection_length = len(selected_text)
    comment.status = slides.ModernCommentStatus.RESOLVED

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_comments = reopened_slide.get_slide_comments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, slides.ModernComment):
            continue

        shape_matches = reopened_comment.shape.name == "Forecast text"
        selection_start_matches = reopened_comment.text_selection_start == expected_selection_start
        selection_length_matches = reopened_comment.text_selection_length == len(selected_text)
        status_matches = reopened_comment.status == slides.ModernCommentStatus.RESOLVED

        print("Shape anchor preserved: " + str(shape_matches))
        print("Text selection start preserved: " + str(selection_start_matches))
        print("Text selection length preserved: " + str(selection_length_matches))
        print("Resolved status preserved: " + str(status_matches))
```

### **Vorhandene moderne Kommentare untersuchen**

Um eine vorhandene Präsentation zu untersuchen, prüfen Sie, welche Kommentare [ModernComment](https://reference.aspose.com/slides/de/python-net/aspose.slides/moderncomment/) Instanzen sind, und untersuchen Sie dann [ModernComment.shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/de/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/de/python-net/aspose.slides/moderncomment/text_selection_length/) und [ModernComment.status](https://reference.aspose.com/slides/de/python-net/aspose.slides/moderncomment/status/). Eine `None` Form weist auf einen Folien‑Ebene‑Kommentar hin. Bei einem [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) Anker geben die Textauswahl‑Eigenschaften den zugehörigen Bereich im Textfeld der Form an.

```python
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    for slide in presentation.slides:
        comments = slide.get_slide_comments(None)
        for comment in comments:
            if not isinstance(comment, slides.ModernComment):
                continue

            print("Slide: " + str(slide.slide_number))
            print("Text: " + comment.text)
            print("Status: " + str(comment.status))

            shape = comment.shape
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: " + shape.name)
                print("Anchor type: " + type(shape).__name__)

                if isinstance(shape, slides.AutoShape):
                    print("Text selection start: " + str(comment.text_selection_start))
                    print("Text selection length: " + str(comment.text_selection_length))

            print()
```

## **Kommentare entfernen**

### **Alle Kommentare und Kommentarautoren entfernen**

Das folgende Beispiel zeigt, wie man alle Kommentare und Kommentarautoren aus einer Präsentation entfernt:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Bestimmte Kommentare entfernen**

Das folgende Beispiel zeigt, wie man bestimmte Kommentare von einer Folie entfernt:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
    author.comments.add_comment("comment 1", slide, first_comment_position, created_time)
    author.comments.add_comment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.comment_authors:
        comments_to_remove = []
        comments = slide.get_slide_comments(comment_author)

        for comment in comments:
            if comment.text == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.comments.remove(comment)

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Unterstützt Aspose.Slides einen gelösten Status für moderne Kommentare?**

Ja. [ModernComment.status](https://reference.aspose.com/slides/de/python-net/aspose.slides/moderncomment/status/) kann gelesen und mit einem [ModernCommentStatus](https://reference.aspose.com/slides/de/python-net/aspose.slides/moderncommentstatus/) Wert, einschließlich `RESOLVED`, gesetzt werden. Der Status wird in der Präsentation gespeichert und kann nach dem erneuten Öffnen der Datei wieder gelesen werden.

**Werden verschachtelte Diskussionen (Antwortketten) unterstützt und gibt es eine Begrenzung der Verschachtelungstiefe?**

Ja. Jeder Kommentar kann auf seinen [parent comment](https://reference.aspose.com/slides/de/python-net/aspose.slides/comment/parent_comment/) verweisen, was Antwortketten ermöglicht. Die API definiert keine spezifische Begrenzung der Verschachtelungstiefe.

**In welchem Koordinatensystem ist die Position eines Kommentar‑Markers auf einer Folie definiert?**

Die Marker‑Position wird durch Gleitkomma‑Koordinaten im Folien‑Koordinatensystem definiert, sodass Sie sie präzise auf der Folie platzieren können.