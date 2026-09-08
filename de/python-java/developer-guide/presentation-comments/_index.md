---
title: Verwalten von Präsentationskommentaren in Python via Java
linktitle: Präsentationskommentare
type: docs
weight: 100
url: /de/python-java/presentation-comments/
keywords:
- Kommentar
- Moderner Kommentar
- PowerPoint-Kommentare
- Präsentationskommentare
- Folienkommentare
- Kommentar hinzufügen
- Kommentar abrufen
- Kommentar bearbeiten
- Kommentar beantworten
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwalten Sie Präsentationskommentare mit Aspose.Slides für Python via Java: Kommentare in PowerPoint-Präsentationen schnell und einfach hinzufügen, lesen, bearbeiten, beantworten und entfernen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Präsentationskommentare mit Aspose.Slides für Python via Java verwaltet. Er führt die wichtigsten kommentarbezogenen Typen ein und zeigt, wie man Kommentare zu Folien hinzufügt, vorhandene Kommentare abruft, mit Antworten und modernen Kommentaren arbeitet und Kommentare aus einer Präsentation entfernt.

Die Beispiele decken gängige Überprüfungs- und Zusammenarbeitsszenarien in PowerPoint ab, wie das Zuordnen von Kommentaren zu Autoren, das Lesen von Kommentartexten und Metadaten, das Erstellen von Antwortketten und das Entfernen ausgewählter Kommentare oder aller Kommentare.

In PowerPoint erscheinen Kommentare als Anmerkungen auf Folien. Das Auswählen eines Kommentars zeigt dessen Text und die zugehörige Diskussion an.

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie können Kommentare verwenden, um Feedback zu geben und mit Kollegen bei der Durchsicht von Präsentationen zusammenzuarbeiten.

Aspose.Slides für Python via Java bietet die folgenden APIs zum Arbeiten mit Kommentaren:

* Die [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse, die Zugriff auf die Kommentarautoren der Präsentation bietet.
* Die [CommentCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/commentcollection/) Klasse, die die mit einem einzelnen Autor verbundenen Kommentare darstellt.
* Die [Comment](https://reference.aspose.com/slides/de/python-java/aspose.slides/comment/) Klasse, die Informationen über einen Kommentar liefert, einschließlich Autor, Erstellungszeit, Position und Text.
* Die [CommentAuthor](https://reference.aspose.com/slides/de/python-java/aspose.slides/commentauthor/) Klasse, die Informationen über einen Autor bereitstellt, einschließlich Name, Initialen und zugehöriger Kommentare.

## **Folienkommentare hinzufügen**

Das folgende Beispiel zeigt, wie man Kommentare zu Folien in einer PowerPoint-Präsentation hinzufügt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0))
    author = presentation.getCommentAuthors().addAuthor("Jawad", "MF")
    position = Point2DFloat(0.2, 0.2)
    created_time = Date()

    author.getComments().addComment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.getComments().addComment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.getSlideComments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.getText())

        author_comments = first_comment.getAuthor().getComments()
        comment_text = author_comments.get_Item(0).getText()
        print(comment_text)

    presentation.save("Comments_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Folienkommentare abrufen**

Das folgende Beispiel zeigt, wie man vorhandene Kommentare in einer PowerPoint-Präsentation abruft:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Comments1.pptx")
try:
    for author in presentation.getCommentAuthors():
        for comment in author.getComments():
            print("Slide: ", comment.getSlide().getSlideNumber())
            print("Comment: ", comment.getText())
            print("Author: ", comment.getAuthor().getName())
            print("Posted at: ", comment.getCreatedTime())
            print()
finally:
    presentation.dispose()
```

## **Auf Kommentare antworten**

Ein übergeordneter Kommentar ist der ursprüngliche Kommentar an der Spitze einer Antworthierarchie. Die Methoden [Comment.getParentComment](https://reference.aspose.com/slides/de/python-java/aspose.slides/comment/#getParentComment) und [Comment.setParentComment](https://reference.aspose.com/slides/de/python-java/aspose.slides/comment/#setParentComment) ermöglichen das Abrufen bzw. Festlegen des übergeordneten Kommentars.

Das folgende Beispiel zeigt, wie man Antworten hinzufügt und die resultierende Kommentarhierarchie untersucht:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    position = Point2DFloat(10, 10)
    created_time = Date()

    thread_author = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.")
    root_comment = thread_author.getComments().addComment("comment 1", slide, position, created_time)

    responding_author = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.")
    direct_reply = responding_author.getComments().addComment("reply 1 for comment 1", slide, position, created_time)
    direct_reply.setParentComment(root_comment)

    branch_reply = responding_author.getComments().addComment("reply 2 for comment 1", slide, position, created_time)
    branch_reply.setParentComment(root_comment)

    nested_reply = thread_author.getComments().addComment("subreply 3 for reply 2", slide, position, created_time)
    nested_reply.setParentComment(branch_reply)

    responding_author.getComments().addComment("comment 2", slide, position, created_time)
    separate_thread_comment = responding_author.getComments().addComment("comment 3", slide, position, created_time)

    separate_thread_reply = thread_author.getComments().addComment("reply 4 for comment 3", slide, position, created_time)
    separate_thread_reply.setParentComment(separate_thread_comment)

    comments = slide.getSlideComments(None)
    for i in range(len(comments)):
        comment = comments[i]
        while comment.getParentComment() is not None:
            print("\t", end="")
            comment = comment.getParentComment()

        print(f"{comments[i].getAuthor().getName()}: {comments[i].getText()}")

    presentation.save("parent_comment.pptx", SaveFormat.Pptx)

    root_comment.remove()
    presentation.save("remove_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warnung" %}}
* Wenn die Methode [Comment.remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/comment/#remove) verwendet wird, um einen Kommentar zu löschen, werden auch alle Antworten auf diesen Kommentar gelöscht.
* Wenn [Comment.setParentComment](https://reference.aspose.com/slides/de/python-java/aspose.slides/comment/#setParentComment) eine zirkuläre Referenz erzeugt, wird eine [PptxEditException](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxeditexception/) ausgelöst.
{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Moderne Kommentare können mit der Folie selbst, einem bestimmten Shape oder einem Textbereich innerhalb einer [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) verknüpft werden. Die Methode [CommentCollection.addModernComment](https://reference.aspose.com/slides/de/python-java/aspose.slides/commentcollection/#addModernComment) akzeptiert ein [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/) Argument zusätzlich zu den Folien‑ und Kommentar‑Marker‑Koordinaten.

When `None` für das Shape‑Argument übergeben wird, handelt es sich um einen Folien‑Kommentar. Sein Marker wird durch die angegebenen Koordinaten positioniert, ist aber keinem bestimmten Shape zugeordnet, sodass [ModernComment.getShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncomment/#getShape) `None` zurückgibt. Wird ein [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/) bereitgestellt, wird der Kommentar an dieses Shape angeheftet. Die Koordinaten definieren weiterhin die Position des Kommentar‑Markers auf der Folie, während die Shape‑Zuordnung über [ModernComment.getShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncomment/#getShape) abgerufen werden kann.

### **Einen modernen Kommentar an ein Shape anheften**

Das folgende Beispiel erstellt sowohl einen Folien‑modernen Kommentar als auch einen modernen Kommentar, der an einer bestimmten [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) angeheftet ist. Anschließend liest es das zugehörige Shape aus jedem Kommentar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80)
    shape.setName("Revenue title")
    shape.getTextFrame().setText("Quarterly revenue")

    created_time = Date()
    slide_comment_position = Point2DFloat(20, 20)
    shape_comment_position = Point2DFloat(60, 60)
    slide_comment = author.getComments().addModernComment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.getComments().addModernComment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.getShape() is None)
    print(shape_comment.getShape().getName())

    presentation.save("modern_comments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kommentare an verschiedene Shape‑Typen anheften**

Jedes Folienobjekt, das von [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/) erbt, kann als Shape‑Anker verwendet werden. Häufige Beispiele sind [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/de/python-java/aspose.slides/connector/) und [GraphicalObject](https://reference.aspose.com/slides/de/python-java/aspose.slides/graphicalobject/) Instanzen, beispielsweise Diagramme.

Das folgende Beispiel erstellt mehrere gängige Shape‑Typen und verknüpft einen modernen Kommentar mit jedem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")
Base64 = jpage.JClass("java.util.Base64")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    created_time = Date()

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60)
    auto_shape.getTextFrame().setText("AutoShape")
    auto_shape_comment_position = Point2DFloat(30, 30)
    author.getComments().addModernComment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = Base64.getDecoder().decode(image_base64)
    image = presentation.getImages().addImage(image_data)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image)
    picture_comment_position = Point2DFloat(230, 30)
    author.getComments().addModernComment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.getShapes().addGroupShape()
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40)
    group_shape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40)
    group_comment_position = Point2DFloat(40, 150)
    author.getComments().addModernComment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40)
    connector_comment_position = Point2DFloat(240, 150)
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180)
    chart_comment_position = Point2DFloat(420, 40)
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Einen Kommentar an Text anheften und seinen Status festlegen**

Für einen modernen Kommentar, der mit einer [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) verknüpft ist, greifen [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncomment/#getTextSelectionStart) und [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncomment/#setTextSelectionStart) auf die Startposition des ausgewählten Textes im Textfeld des Shapes zu. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncomment/#getTextSelectionLength) und [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncomment/#setTextSelectionLength) geben die Länge der Auswahl zurück. Zusammen verknüpfen diese Werte den Kommentar mit einem bestimmten Textbereich innerhalb der AutoShape.

Die Methoden [ModernComment.getStatus](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncomment/#getStatus) und [ModernComment.setStatus](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncomment/#setStatus) greifen auf einen Wert aus den [ModernCommentStatus](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncommentstatus/) Konstanten zu:

- [NotDefined](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncommentstatus/#NotDefined) — kein spezifischer moderner Kommentarstatus ist definiert.
- [Active](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncommentstatus/#Active) — der Kommentar ist aktiv.
- [Resolved](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncommentstatus/#Resolved) — der Kommentar wurde gelöst.
- [Closed](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncommentstatus/#Closed) — der Kommentar ist geschlossen.

Das folgende Beispiel erstellt einen an ein Shape angehefteten modernen Kommentar, verknüpft ihn mit einer Textauswahl, markiert ihn als gelöst, speichert die Präsentation und überprüft die Werte nach dem erneuten Öffnen der Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ModernComment, ModernCommentStatus, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.find(selected_text)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    shape.setName("Forecast text")
    shape.getTextFrame().setText(shape_text)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    comment_position = Point2DFloat(60, 60)
    created_time = Date()
    comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, comment_position, created_time)
    comment.setTextSelectionStart(expected_selection_start)
    comment.setTextSelectionLength(len(selected_text))
    comment.setStatus(ModernCommentStatus.Resolved)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_comments = reopened_slide.getSlideComments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, ModernComment):
            continue

        modern_comment = reopened_comment
        shape_matches = modern_comment.getShape() is not None and modern_comment.getShape().getName() == "Forecast text"
        selection_start_matches = modern_comment.getTextSelectionStart() == expected_selection_start
        selection_length_matches = modern_comment.getTextSelectionLength() == len(selected_text)
        status_matches = modern_comment.getStatus() == ModernCommentStatus.Resolved

        print("Shape anchor preserved: ", shape_matches)
        print("Text selection start preserved: ", selection_start_matches)
        print("Text selection length preserved: ", selection_length_matches)
        print("Resolved status preserved: ", status_matches)
finally:
    reopened_presentation.dispose()
```

### **Bestehende moderne Kommentare untersuchen**

Um eine vorhandene Präsentation zu untersuchen, prüfen Sie, welche Kommentare Instanzen von [ModernComment](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncomment/) sind, und untersuchen Sie dann [ModernComment.getShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncomment/#getTextSelectionLength) und [ModernComment.getStatus](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncomment/#getStatus). Ein `None` Shape weist auf einen Folien‑Kommentar hin. Für einen [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/)‑Anker identifizieren die Textauswahl‑Methoden den zugehörigen Bereich im Textfeld des Shapes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ModernComment, Presentation

presentation = Presentation("comments.pptx")
try:
    for slide in presentation.getSlides():
        comments = slide.getSlideComments(None)
        for comment in comments:
            if not isinstance(comment, ModernComment):
                continue

            modern_comment = comment
            print("Slide: ", slide.getSlideNumber())
            print("Text: ", modern_comment.getText())
            print("Status: ", modern_comment.getStatus())

            shape = modern_comment.getShape()
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: ", shape.getName())
                print("Anchor type: ", shape.getClass().getSimpleName())

                if isinstance(shape, AutoShape):
                    print("Text selection start: ", modern_comment.getTextSelectionStart())
                    print("Text selection length: ", modern_comment.getTextSelectionLength())

            print()
finally:
    presentation.dispose()
```

## **Kommentare entfernen**

### **Alle Kommentare und Kommentarautoren entfernen**

Das folgende Beispiel zeigt, wie man alle Kommentare und Kommentarautoren aus einer Präsentation entfernt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("example.pptx")
try:
    for author in presentation.getCommentAuthors():
        author.getComments().clear()

    presentation.getCommentAuthors().clear()
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Bestimmte Kommentare entfernen**

Das folgende Beispiel zeigt, wie man bestimmte Kommentare von einer Folie entfernt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Author", "A")
    created_time = Date()

    first_comment_position = Point2DFloat(0.2, 0.2)
    second_comment_position = Point2DFloat(0.3, 0.2)
    author.getComments().addComment("comment 1", slide, first_comment_position, created_time)
    author.getComments().addComment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.getCommentAuthors():
        comments_to_remove = []
        comments = slide.getSlideComments(comment_author)

        for comment in comments:
            if comment.getText() == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.getComments().remove(comment)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Unterstützt Aspose.Slides einen gelösten Status für moderne Kommentare?**

Ja. [ModernComment.getStatus](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncomment/#getStatus) und [ModernComment.setStatus](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncomment/#setStatus) greifen auf einen [ModernCommentStatus](https://reference.aspose.com/slides/de/python-java/aspose.slides/moderncommentstatus/) Wert zu, einschließlich `Resolved`. Der Status wird in der Präsentation gespeichert und kann nach dem erneuten Öffnen der Datei wieder ausgelesen werden.

**Werden verschachtelte Diskussionen (Antwortketten) unterstützt und gibt es ein Begrenzung für die Verschachtelungstiefe?**

Ja. Jeder Kommentar kann auf seinen [parent comment](https://reference.aspose.com/slides/de/python-java/aspose.slides/comment/#getParentComment) verweisen, wodurch Antwortketten ermöglicht werden. Die API definiert keine spezifische Begrenzung für die Verschachtelungstiefe.

**In welchem Koordinatensystem ist die Position eines Kommentar‑Markers auf einer Folie definiert?**

Die Marker‑Position wird durch Gleitkomma‑Koordinaten im Folien‑Koordinatensystem definiert, sodass Sie sie exakt auf der Folie platzieren können.