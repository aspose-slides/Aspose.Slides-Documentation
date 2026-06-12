---
title: Opmerking
type: docs
weight: 230
url: /nl/python-net/examples/elements/comment/
keywords:
- opmerking
- moderne opmerking
- opmerking toevoegen
- opmerking lezen
- opmerking verwijderen
- reageren op opmerking
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer diaopmerkingen in Python met Aspose.Slides: toevoegen, lezen, reageren, bewerken, verwijderen en werken met geneste opmerkingen voor PowerPoint en OpenDocument."
---
Toont het toevoegen, lezen, verwijderen en beantwoorden van moderne opmerkingen met **Aspose.Slides for Python via .NET**.

## **Voeg een moderne opmerking toe**

Maak een opmerking aan die door een gebruiker is geschreven en sla de presentatie op.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Voeg een opmerking-auteur toe.
        author = presentation.comment_authors.add_author("User", "U1")

        # Voeg een moderne opmerking toe.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **Toegang tot een moderne opmerking**

Lees een moderne opmerking uit een bestaande presentatie.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # Toegang tot de eerste moderne opmerking.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **Een moderne opmerking verwijderen**

Verwijder een opmerking en sla het bijgewerkte bestand op.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # Verwijder de opmerking.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Antwoorden op een moderne opmerking**

Voeg antwoorden toe op een bovenliggende moderne opmerking.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # Voeg bovenliggende opmerking toe.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # Voeg eerste antwoord toe.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # Voeg tweede antwoord toe.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```