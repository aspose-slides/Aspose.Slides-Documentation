---
title: Kommentar
type: docs
weight: 230
url: /sv/python-net/examples/elements/comment/
keywords:
- kommentar
- modern kommentar
- lägg till kommentar
- åtkomst till kommentar
- ta bort kommentar
- svara på kommentar
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Hantera bildkommentarer i Python med Aspose.Slides: lägg till, läs, svara, redigera, ta bort och arbeta med trådade kommentarer för PowerPoint och OpenDocument."
---
Visar hur man lägger till, läser, tar bort och svarar på moderna kommentarer med **Aspose.Slides for Python via .NET**.

## **Lägg till en modern kommentar**

Skapa en kommentar skriven av en användare och spara presentationen.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Lägg till en kommentarförfattare.
        author = presentation.comment_authors.add_author("User", "U1")

        # Lägg till en modern kommentar.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **Åtkomst till en modern kommentar**

Läs en modern kommentar från en befintlig presentation.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # Åtkomst till den första moderna kommentaren.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **Ta bort en modern kommentar**

Ta bort en kommentar och spara den uppdaterade filen.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # Ta bort kommentaren.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Svara på en modern kommentar**

Lägg till svar på en överordnad modern kommentar.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # Lägg till föräldrakommentar.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # Lägg till första svaret.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # Lägg till andra svaret.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```