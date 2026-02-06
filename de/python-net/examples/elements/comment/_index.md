---
title: Kommentar
type: docs
weight: 230
url: /de/python-net/examples/elements/comment/
keywords:
- Kommentar
- Moderner Kommentar
- Kommentar hinzufügen
- Kommentar abrufen
- Kommentar entfernen
- Auf Kommentar antworten
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie Folienkommentare in Python mit Aspose.Slides: Hinzufügen, Lesen, Antworten, Bearbeiten, Löschen und Arbeiten mit verschachtelten Kommentaren für PowerPoint und OpenDocument."
---
Demonstriert das Hinzufügen, Lesen, Entfernen und Antworten auf moderne Kommentare mit **Aspose.Slides for Python via .NET**.

## **Modernen Kommentar hinzufügen**

Erstellen Sie einen von einem Benutzer verfassten Kommentar und speichern Sie die Präsentation.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Kommentarautor hinzufügen.
        author = presentation.comment_authors.add_author("User", "U1")

        # Moderner Kommentar hinzufügen.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **Einen modernen Kommentar abrufen**

Lesen Sie einen modernen Kommentar aus einer vorhandenen Präsentation.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # Den ersten modernen Kommentar abrufen.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **Einen modernen Kommentar entfernen**

Entfernen Sie einen Kommentar und speichern Sie die aktualisierte Datei.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # Kommentar entfernen.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Auf einen modernen Kommentar antworten**

Fügen Sie Antworten zu einem übergeordneten modernen Kommentar hinzu.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # Elternkommentar hinzufügen.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # Erste Antwort hinzufügen.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # Zweite Antwort hinzufügen.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```