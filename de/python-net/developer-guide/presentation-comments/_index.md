---
title: Präsentationskommentare in Python verwalten
linktitle: Präsentationskommentare
type: docs
weight: 100
url: /de/python-net/presentation-comments/
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
- Aspose.Slides
description: "Verwalten Sie Präsentationskommentare mit Aspose.Slides for Python via .NET: Kommentare in PowerPoint-Präsentationen hinzufügen, lesen, bearbeiten, beantworten und entfernen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Präsentationskommentare mit Aspose.Slides for Python via .NET verwaltet. Er führt die wichtigsten kommentarbezogenen Typen ein und zeigt, wie man Kommentare zu Folien hinzufügt, vorhandene Kommentare abruft, mit Antworten und modernen Kommentaren arbeitet und Kommentare aus einer Präsentation entfernt.

Die Beispiele decken gängige Prüf‑ und Zusammenarbeitsszenarien in PowerPoint ab, wie das Zuordnen von Kommentaren zu Autoren, das Lesen von Kommentartexten und Metadaten, das Erstellen von Antwortketten und das Entfernen ausgewählter Kommentare oder aller Kommentare.

In PowerPoint erscheinen Kommentare als Anmerkungen auf Folien. Das Auswählen eines Kommentars zeigt dessen Text und die zugehörige Diskussion an.

Um festzulegen, dass Kommentare beim Öffnen einer Präsentation angezeigt oder ausgeblendet werden sollen, ohne die Kommentare selbst zu ändern, siehe [Kommentare beim Öffnen einer Präsentation anzeigen oder ausblenden](/slides/de/python-net/presentation-view-properties/).

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie können Kommentare verwenden, um Feedback zu geben und mit Kollegen bei der Durchsicht von Präsentationen zusammenzuarbeiten.

Aspose.Slides for Python via .NET bietet die folgenden APIs für die Arbeit mit Kommentaren:

* Die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse, die Zugriff auf die Kommentar‑Autoren der Präsentation bietet.
* Die [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/)‑Klasse, die die Kommentare eines einzelnen Autors repräsentiert.
* Die [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/)‑Klasse, die Informationen zu einem Kommentar bereitstellt, einschließlich Autor, Erstellungszeit, Position und Text.
* Die [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/)‑Klasse, die Informationen zu einem Autor liefert, einschließlich Name, Initialen und zugehöriger Kommentare.

## **Folienkommentare hinzufügen**

Das Beispiel erstellt zwei Folien und registriert einen Kommentar‑Autor mit [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/). Es verwendet [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/), um jeweils einen Kommentar auf jeder Folie zu platzieren, und ruft dann die Kommentare der ersten Folie für diesen Autor mit [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) ab. Die Konsole gibt den Text des ersten Kommentars zweimal aus und demonstriert den Zugriff sowohl über die Folie als auch über den Autor; die gespeicherte Präsentation enthält beide Kommentare.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = slides.PointF(0.2, 0.2)
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

## **Einen Kommentar‑Autor finden oder erstellen**

Wenn ein automatisierter Review dieselbe Präsentation wiederholt verarbeitet, durchsucht man vor dem Hinzufügen eines Autors die [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/)-Sammlung. [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) vergleicht sowohl Name als auch Initialen und gibt ein Array passender Autoren zurück, oder ein leeres Array, wenn keine Übereinstimmungen existieren. Im Gegensatz dazu sucht [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) nur nach dem Namen, unabhängig von den Initialen. Das Aufrufen von [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) mit einem bereits in der Sammlung vorhandenen Namen und Initialen wirft eine Ausnahme.

Das Beispiel erfordert eine Präsentationsdatei mit mindestens einer Folie. In jedem der beiden Durchläufe wird der zuerst passende Autor wiederverwendet oder nur dann ein neuer erstellt, wenn das Ergebnis leer ist. Gibt es mehrere Treffer, wird das erste Element des Arrays ausgewählt, ohne die anderen Autoren zu mergen oder zu entfernen. Anschließend wird [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) für den ausgewählten Autor aufgerufen und die Präsentation gespeichert. Der zweite Durchlauf öffnet die Ausgabe des ersten Durchlaufs und wiederholt den Vorgang.

```python
from datetime import datetime

import aspose.slides as slides

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = slides.PointF(20, 20)

for pass_number in range(1, 3):
    with slides.Presentation(input_file) as presentation:
        matches = presentation.comment_authors.find_by_name_and_initials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.comment_authors.add_author(author_name, author_initials)
        author.comments.add_comment("Please review this slide.", presentation.slides[0], position, datetime.now())

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, slides.export.SaveFormat.PPTX)
        input_file = output_file
```

Der zweite Durchlauf fügt einen weiteren Kommentar hinzu, ohne einen weiteren Autor anzulegen oder vorhandene Kommentare zu entfernen. Die endgültige Datei `review_pass_2.pptx` enthält beide neuen Kommentare neben etwaigen Originalkommentaren. Das Wiederverwenden eines Autors dedupliziert Kommentare nicht: Um das wiederholte Hinzufügen desselben Kommentars zu vermeiden, implementieren Sie eine separate Duplikaterkennung, bevor Sie ihn hinzufügen.

## **Auf Folienkommentare zugreifen**

Das Beispiel öffnet eine vorhandene Präsentation und liest deren [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/)-Sammlung. Für jeden Autor iteriert es über [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) und gibt Foliennummer, Kommentartext, Autorname und Erstellungszeit aus. Die Eingabepräsentation muss Kommentare enthalten, damit Konsolenausgaben erzeugt werden.

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

Ein übergeordneter Kommentar ist der ursprüngliche Kommentar an der Spitze einer Antwort‑Hierarchie. Die [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/)-Eigenschaft der [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/)-Klasse ermöglicht das Abrufen oder Festlegen des übergeordneten Kommentars.

Das Beispiel erstellt Kommentare von zwei Autoren und verwendet [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/), um Antworten zu bauen, einschließlich einer Antwort auf eine andere Antwort. Das Übergeben von `None` an [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) ruft Kommentare aller Autoren ab; die Konsole rückt jeden Eintrag gemäß seiner Tiefe in der Antwort‑Hierarchie ein. Das Beispiel speichert die vollständige Diskussion, ruft [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) für den ersten Wurzel‑Kommentar auf und speichert eine zweite Präsentation, in der dieser Kommentar und seine Antworten entfernt wurden.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    position = slides.PointF(10, 10)
    created_time = datetime.now()

    original_author = presentation.comment_authors.add_author("Author_1", "A.A.")
    root_comment = original_author.comments.add_comment("comment 1", slide, position, created_time)

    reviewer = presentation.comment_authors.add_author("Author_2", "B.B.")
    first_reply = reviewer.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    first_reply.parent_comment = root_comment

    second_reply = reviewer.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    second_reply.parent_comment = root_comment

    sub_reply = original_author.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = second_reply

    reviewer.comments.add_comment("comment 2", slide, position, created_time)
    separate_comment = reviewer.comments.add_comment("comment 3", slide, position, created_time)

    separate_reply = original_author.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    separate_reply.parent_comment = separate_comment

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    root_comment.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* Wenn die [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/)‑Methode der [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/)-Klasse verwendet wird, um einen Kommentar zu löschen, werden alle Antworten auf diesen Kommentar ebenfalls gelöscht.
* Wenn die [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/)‑Eigenschaft eine zyklische Referenz erzeugt, wird eine [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) ausgelöst.
{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Moderne Kommentare können der Folie selbst, einer bestimmten Form oder einem Textbereich innerhalb einer AutoShape zugeordnet werden. Die Methode [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) akzeptiert ein [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)-Argument zusätzlich zu den Folien‑ und Kommentar‑Marker‑Koordinaten.

Wird `None` für das Shape‑Argument übergeben, handelt es sich um einen Folien‑Kommentar. Sein Marker wird durch die übergebenen Koordinaten positioniert, ist jedoch keiner bestimmten Form zugeordnet, sodass [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) `None` zurückgibt. Wird ein [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) angegeben, ist der Kommentar an diese Form verankert. Die Koordinaten definieren weiterhin die Position des Kommentar‑Markers auf der Folie, während die Formzuordnung über [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) abgerufen werden kann.

### **Einen modernen Kommentar an einer Form verankern**

Das Beispiel ruft [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) zweimal auf: einmal mit einem `None`‑Shape für einen Folien‑Kommentar und einmal mit einem Rechteck als Anker. Das Auslesen von [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) gibt für den Folien‑Kommentar `True` (Null‑Prüfung) und für den verankerten Kommentar `Revenue title` aus. Beide Kommentare werden mit der Präsentation gespeichert.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = slides.PointF(20, 20)
    shape_comment_position = slides.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Kommentare an verschiedene Formtypen verankern**

Jedes Folienobjekt, das von [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) abgeleitet ist, kann als Form‑Anker verwendet werden. Häufige Beispiele sind [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) und [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/)-Instanzen wie Diagramme.

Das Beispiel verwendet [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/), um einen Kommentar jedem von fünf Formtypen zuzuordnen: einer AutoShape, einem Bildrahmen, einer Gruppe, einem Verbinder und einem Diagramm. Das Bild verwendet eingebettete Bilddaten, sodass kein externes Bild erforderlich ist. Jeder Kommentar hat seine eigene Marker‑Position, und die gespeicherte Präsentation behält alle fünf Formzuordnungen bei.

```python
import base64
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"

    auto_shape_comment_position = slides.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = slides.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = slides.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = slides.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = slides.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Einen Kommentar an Text anheften und den Status setzen**

Für einen modernen Kommentar, der einer [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) zugeordnet ist, gibt [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) die Startposition des ausgewählten Textes im Textfeld der Form an, während [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) die Länge der Auswahl definiert. Zusammen verknüpfen diese Eigenschaften den Kommentar mit einem bestimmten Textbereich innerhalb der AutoShape.

Die [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/)-Eigenschaft kann gelesen oder mit einem Wert aus der Aufzählung [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) aktualisiert werden:

- `NOT_DEFINED` — kein spezieller Moderner‑Kommentar‑Status ist definiert.
- `ACTIVE` — der Kommentar ist aktiv.
- `RESOLVED` — der Kommentar wurde gelöst.
- `CLOSED` — der Kommentar ist geschlossen.

Das Beispiel verankert einen modernen Kommentar an den Wörtern „quarterly revenue“ in einem Rechteck‑Text. Es berechnet den nullbasierten [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) aus dem Text und setzt [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) auf die Anzahl ausgewählter Zeichen. Nach dem Setzen von [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) auf `RESOLVED` wird die Präsentation gespeichert und erneut geöffnet. Die vier Konsolenprüfungen sollten jeweils `True` ausgeben und bestätigen, dass Anker, Textbereich und Status erhalten geblieben sind.

```python
from datetime import datetime

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
    comment_position = slides.PointF(60, 60)
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

Das Beispiel erfordert eine vorhandene Präsentation mit modernen Kommentaren und gibt deren Text, Status und Ankerdetails aus. Zur Untersuchung prüft es, welche Kommentare Instanzen von [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) sind, und untersucht dann [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) und [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/). Ein `None`‑Shape weist auf einen Folien‑Kommentar hin. Bei einem [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Anker identifizieren die Textauswahl‑Eigenschaften den zugehörigen Bereich im Textfeld der Form.

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

Aspose.Slides for Python via .NET ermöglicht das Entfernen aller Kommentare und ihrer Autoren aus einer Präsentation oder das Löschen ausgewählter Kommentare bei gleichzeitiger Beibehaltung der übrigen. Die folgenden Beispiele demonstrieren beide Ansätze und speichern die aktualisierte Präsentation.

### **Alle Kommentare und Kommentar‑Autoren entfernen**

Das Beispiel öffnet eine vorhandene Präsentation und ruft für jeden Autor [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) auf, anschließend [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) zum Entfernen der Autoren selbst. Die gespeicherte Präsentation enthält weder Kommentare noch Kommentar‑Autoren. Verwenden Sie eine Präsentation mit Kommentaren, um die Entfernung zu beobachten.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Bestimmte Kommentare entfernen**

Das Beispiel erstellt zwei Kommentare auf einer Folie und verwendet [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/), um Kommentare jedes Autors zu finden. Es sammelt Kommentare, deren Text gleich „comment 1“ ist, bevor [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/) aufgerufen wird, um Änderungen an der Sammlung während der Auswahl zu vermeiden. Die gespeicherte Präsentation enthält nur „comment 2“.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = slides.PointF(0.2, 0.2)
    second_comment_position = slides.PointF(0.3, 0.2)
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

Ja. [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) kann gelesen und mit einem Wert aus [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) gesetzt werden, einschließlich `RESOLVED`. Der Status wird in der Präsentation gespeichert und kann nach erneutem Öffnen der Datei erneut ausgelesen werden.

**Werden verschachtelte Diskussionen (Antwortketten) unterstützt und gibt es ein Begrenzung für die Tiefe?**

Ja. Jeder Kommentar kann auf seinen [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) verweisen, was Antwortketten ermöglicht. Die API definiert kein spezifisches Limit für die Verschachtelungstiefe.

**In welchem Koordinatensystem ist die Position eines Kommentar‑Markers auf einer Folie definiert?**

Die Marker‑Position wird durch Gleitkomma‑Koordinaten im Folien‑Koordinatensystem definiert, sodass Sie sie exakt auf der Folie platzieren können.