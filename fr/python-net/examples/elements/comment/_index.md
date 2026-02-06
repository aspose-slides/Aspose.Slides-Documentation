---
title: Commentaire
type: docs
weight: 230
url: /fr/python-net/examples/elements/comment/
keywords:
- commentaire
- commentaire moderne
- ajouter un commentaire
- accéder au commentaire
- supprimer le commentaire
- répondre au commentaire
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Gérez les commentaires de diapositives en Python avec Aspose.Slides : ajoutez, lisez, répondez, modifiez, supprimez et travaillez avec les commentaires en fil de discussion pour PowerPoint et OpenDocument."
---
Démontre comment ajouter, lire, supprimer et répondre aux commentaires modernes en utilisant **Aspose.Slides for Python via .NET**.

## **Ajouter un commentaire moderne**

Créez un commentaire rédigé par un utilisateur et enregistrez la présentation.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Ajouter un auteur de commentaire.
        author = presentation.comment_authors.add_author("User", "U1")

        # Ajouter un commentaire moderne.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à un commentaire moderne**

Lisez un commentaire moderne à partir d'une présentation existante.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # Accéder au premier commentaire moderne.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **Supprimer un commentaire moderne**

Supprimez un commentaire et enregistrez le fichier mis à jour.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # Supprimer le commentaire.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Répondre à un commentaire moderne**

Ajoutez des réponses à un commentaire moderne parent.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # Ajouter le commentaire parent.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # Ajouter la première réponse.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # Ajouter la deuxième réponse.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```