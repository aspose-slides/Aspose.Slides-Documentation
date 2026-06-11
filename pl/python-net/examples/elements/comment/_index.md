---
title: Komentarz
type: docs
weight: 230
url: /pl/python-net/examples/elements/comment/
keywords:
- komentarz
- nowoczesny komentarz
- dodaj komentarz
- uzyskaj dostęp do komentarza
- usuń komentarz
- odpowiedz na komentarz
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj komentarzami slajdów w Pythonie przy użyciu Aspose.Slides: dodawaj, odczytuj, odpowiadaj, edytuj, usuwaj i pracuj z wątkowanymi komentarzami dla PowerPoint i OpenDocument."
---
Prezentuje dodawanie, odczytywanie, usuwanie i odpowiadanie na nowoczesne komentarze przy użyciu **Aspose.Slides for Python via .NET**.

## **Dodaj nowoczesny komentarz**

Utwórz komentarz napisany przez użytkownika i zapisz prezentację.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Dodaj autora komentarza.
        author = presentation.comment_authors.add_author("User", "U1")

        # Dodaj nowoczesny komentarz.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **Uzyskaj dostęp do nowoczesnego komentarza**

Odczytaj nowoczesny komentarz z istniejącej prezentacji.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # Uzyskaj dostęp do pierwszego nowoczesnego komentarza.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **Usuń nowoczesny komentarz**

Usuń komentarz i zapisz zaktualizowany plik.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # Usuń komentarz.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Odpowiedz na nowoczesny komentarz**

Dodaj odpowiedzi do nadrzędnego nowoczesnego komentarza.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # Dodaj komentarz nadrzędny.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # Dodaj pierwszą odpowiedź.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # Dodaj drugą odpowiedź.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```