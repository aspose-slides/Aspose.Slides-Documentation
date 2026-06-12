---
title: Komentář
type: docs
weight: 230
url: /cs/python-net/examples/elements/comment/
keywords:
- komentář
- moderní komentář
- přidat komentář
- přístup ke komentáři
- odstranit komentář
- odpovědět na komentář
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Spravujte komentáře snímků v Pythonu s Aspose.Slides: přidávejte, čtěte, odpovídejte, upravujte, mažte a pracujte s vlákny komentářů pro PowerPoint a OpenDocument."
---
Ukazuje přidávání, čtení, odstraňování a odpovídání na moderní komentáře pomocí **Aspose.Slides for Python via .NET**.

## **Přidat moderní komentář**

Vytvořte komentář vytvořený uživatelem a uložte prezentaci.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Přidat autora komentáře.
        author = presentation.comment_authors.add_author("User", "U1")

        # Přidat moderní komentář.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k modernímu komentáři**

Přečtěte moderní komentář z existující prezentace.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # Přístup k prvnímu modernímu komentáři.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **Odstranit moderní komentář**

Odstraňte komentář a uložte aktualizovaný soubor.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # Odebrat komentář.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Odpovědět na moderní komentář**

Přidejte odpovědi k nadřazenému modernímu komentáři.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # Přidat nadřazený komentář.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # Přidat první odpověď.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # Přidat druhou odpověď.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```