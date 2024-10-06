---
title: Commentaires de Présentation
type: docs
weight: 100
url: /python-net/presentation-comments/
keywords: "Commentaires, commentaires PowerPoint, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Ajoutez des commentaires et des réponses dans une présentation PowerPoint en Python"
---

Dans PowerPoint, un commentaire apparaît comme une note ou une annotation sur une diapositive. Lorsqu'un commentaire est cliqué, son contenu ou ses messages sont révélés.

### **Pourquoi Ajouter des Commentaires aux Présentations?**

Vous pouvez utiliser des commentaires pour fournir des retours d'information ou communiquer avec vos collègues lorsque vous examinez des présentations.

Pour vous permettre d'utiliser des commentaires dans les présentations PowerPoint, Aspose.Slides pour Python via .NET fournit

* La classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) , qui contient les collections d'auteurs (propriété [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/)). Les auteurs ajoutent des commentaires aux diapositives.
* L'interface [ICommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icommentcollection/), qui contient la collection de commentaires pour des auteurs individuels.
* La classe [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/), qui contient des informations sur les auteurs et leurs commentaires : qui a ajouté le commentaire, le moment où le commentaire a été ajouté, la position du commentaire, etc.
* La classe [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/), qui contient des informations sur des auteurs individuels : le nom de l'auteur, ses initiales, les commentaires associés au nom de l'auteur, etc.

## **Ajouter un Commentaire de Diapositive**
Ce code Python vous montre comment ajouter un commentaire à une diapositive dans une présentation PowerPoint :

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Instantiates the Presentation class
with slides.Presentation() as presentation:
    # Adds an empty slide
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Adds an author
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Sets the position for comments
    point = draw.PointF(0.2, 0.2)

    # Adds slide comment for an author on slide 1
    author.comments.add_comment("Bonjour Jawad, ceci est un commentaire de diapositive", presentation.slides[0], point, datetime.date.today())

    # Adds slide comment for an author on slide 2
    author.comments.add_comment("Bonjour Jawad, ceci est le deuxième commentaire de diapositive", presentation.slides[1], point, datetime.date.today())

    # Accessing ISlide 1
    slide = presentation.slides[0]

    # When null is passed as an argument, comments from all authors are brought to the selected slide
    comments = slide.get_slide_comments(author)

    # Accesses the comment at index 0 for slide 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Selects the Author's comments collection at index 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **Accéder aux Commentaires de Diapositive**
Ce code Python vous montre comment accéder à un commentaire existant sur une diapositive dans une présentation PowerPoint :

```python
import aspose.slides as slides

# Instantiates the Presentation class
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " a un commentaire : " + comment.text + 
            " avec l'Auteur : " + comment.author.name + 
            " publié à : " + str(comment.created_time) + "\n")
```

## **Répondre aux Commentaires**
Un commentaire parent est le commentaire supérieur ou original dans une hiérarchie de commentaires ou de réponses. En utilisant la propriété `parent_comment` (de l'interface [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/)), vous pouvez définir ou obtenir un commentaire parent.

Ce code Python vous montre comment ajouter des commentaires et obtenir leurs réponses :

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Adds a comment
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("commentaire1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Adds a reply to comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("réponse 1 pour le commentaire 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Adds another reply to comment1
    reply2 = author2.comments.add_comment("réponse 2 pour le commentaire 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Adds a reply to existing reply
    subReply = author1.comments.add_comment("sous-réponse 3 pour la réponse 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("commentaire 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("commentaire 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("réponse 4 pour le commentaire 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Displays the comments hierarchy on console
    slide = pres.slides[0]
    comments = slide.get_slide_comments(None)
    for i in range(comments.length):
        comment = comments[i]
        while comment.parent_comment is not None:
            print("\t")
            comment = comment.parent_comment

        print(comments[i].author.name + " : " + comments[i].text)
        print("\r\n")

    pres.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    # Removes comment1 and all replies to it
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Attention" %}}

* Lorsque la méthode `Remove` (de l'interface [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/)) est utilisée pour supprimer un commentaire, les réponses au commentaire sont également supprimées.
* Si le paramètre `parent_comment` aboutit à une référence circulaire, une `PptxEditException` sera lancée.

{{% /alert %}}

## **Ajouter un Commentaire Moderne**

En 2021, Microsoft a introduit des *commentaires modernes* dans PowerPoint. La fonctionnalité des commentaires modernes améliore considérablement la collaboration dans PowerPoint. Grâce aux commentaires modernes, les utilisateurs de PowerPoint peuvent résoudre des commentaires, ancrer des commentaires à des objets et des textes, et engager des interactions de manière beaucoup plus facile qu'auparavant.

Nous avons implémenté la prise en charge des commentaires modernes en ajoutant la classe [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/). Les méthodes `add_modern_comment` et `insert_modern_comment` ont été ajoutées à la classe [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/).

Ce code Python vous montre comment ajouter un commentaire moderne à une diapositive dans une présentation PowerPoint :

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Un Auteur", "SA")
    modernComment = newAuthor.comments.add_modern_comment("Ceci est un commentaire moderne", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Supprimer un Commentaire**

### **Supprimer Tous les Commentaires et Auteurs**

Ce code Python vous montre comment supprimer tous les commentaires et auteurs dans une présentation :

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Deletes all comments from the presentation
    for author in presentation.comment_authors:
        author.comments.clear()

    # Deletes all authors
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Supprimer des Commentaires Spécifiques**

Ce code Python vous montre comment supprimer des commentaires spécifiques sur une diapositive :

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # add comments...
    author = presentation.comment_authors.add_author("Auteur", "A")
    author.comments.add_comment("commentaire 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("commentaire 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # remove all comments that contain "comment 1" text
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "commentaire 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```