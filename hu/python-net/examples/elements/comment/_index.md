---
title: Megjegyzés
type: docs
weight: 230
url: /hu/python-net/examples/elements/comment/
keywords:
- megjegyzés
- modern megjegyzés
- megjegyzés hozzáadása
- megjegyzés elérése
- megjegyzés eltávolítása
- megjegyzésre válasz
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "A Diavetítési megjegyzéseket kezelje Pythonban az Aspose.Slides segítségével: hozzáadás, olvasás, válaszadás, szerkesztés, törlés és szálas megjegyzések kezelése PowerPoint és OpenDocument esetén."
---
Bemutatja, hogyan lehet hozzáadni, olvasni, eltávolítani és válaszolni a modern megjegyzésekre a **Aspose.Slides for Python via .NET** használatával.

## **Modern megjegyzés hozzáadása**

Hozzon létre egy felhasználó által írt megjegyzést, és mentse el a prezentációt.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Megjegyzés szerzőjének hozzáadása.
        author = presentation.comment_authors.add_author("User", "U1")

        # Modern megjegyzés hozzáadása.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **Modern megjegyzés elérése**

Olvassa ki a modern megjegyzést egy meglévő prezentációból.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # Az első modern megjegyzés elérése.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **Modern megjegyzés eltávolítása**

Távolítson el egy megjegyzést, és mentse el a frissített fájlt.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # A megjegyzés eltávolítása.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Modern megjegyzésre válasz**

Adjon válaszokat egy szülő modern megjegyzéshez.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # Szülő megjegyzés hozzáadása.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # Első válasz hozzáadása.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # Második válasz hozzáadása.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```