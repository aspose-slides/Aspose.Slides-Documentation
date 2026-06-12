---
title: Commento
type: docs
weight: 230
url: /it/python-net/examples/elements/comment/
keywords:
- commento
- commento moderno
- aggiungi commento
- accedi commento
- rimuovi commento
- rispondi al commento
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci i commenti delle diapositive in Python con Aspose.Slides: aggiungi, leggi, rispondi, modifica, elimina e lavora con i commenti a thread per PowerPoint e OpenDocument."
---
Dimostra come aggiungere, leggere, rimuovere e rispondere ai commenti moderni utilizzando **Aspose.Slides for Python via .NET**.

## **Aggiungi un commento moderno**

Crea un commento scritto da un utente e salva la presentazione.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Aggiungi un autore del commento.
        author = presentation.comment_authors.add_author("User", "U1")

        # Aggiungi un commento moderno.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi a un commento moderno**

Leggi un commento moderno da una presentazione esistente.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # Accedi al primo commento moderno.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **Rimuovi un commento moderno**

Rimuovi un commento e salva il file aggiornato.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # Rimuovi il commento.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Rispondi a un commento moderno**

Aggiungi risposte a un commento moderno genitore.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # Aggiungi commento genitore.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # Aggiungi prima risposta.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # Aggiungi seconda risposta.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```