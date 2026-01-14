---
title: Gérer les commentaires de présentation en Python
linktitle: Commentaires de présentation
type: docs
weight: 100
url: /fr/python-net/presentation-comments/
keywords:
- commentaire
- commentaire moderne
- commentaires PowerPoint
- commentaires de présentation
- commentaires de diapositive
- ajouter commentaire
- accéder commentaire
- modifier commentaire
- répondre commentaire
- supprimer commentaire
- effacer commentaire
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Maîtrisez les commentaires de présentation avec Aspose.Slides pour Python via .NET : ajoutez, lisez, modifiez et supprimez les commentaires dans les fichiers PowerPoint rapidement et facilement."
---

Dans PowerPoint, un commentaire apparaît comme une note ou une annotation sur une diapositive. Lorsqu’un commentaire est cliqué, son contenu ou ses messages sont révélés. 

## **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez vouloir utiliser les commentaires pour fournir des retours ou communiquer avec vos collègues lors de la révision de présentations.

Pour vous permettre d’utiliser les commentaires dans les présentations PowerPoint, Aspose.Slides for Python via .NET fournit

* The [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class, qui contient les collections d’auteurs (provenant de la propriété [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/)). Les auteurs ajoutent des commentaires aux diapositives. 
* The [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) class, qui contient la collection de commentaires pour chaque auteur. 
* The [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) class, qui contient des informations sur les auteurs et leurs commentaires : qui a ajouté le commentaire, l’heure à laquelle il a été ajouté, la position du commentaire, etc. 
* The [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) class, qui contient des informations sur chaque auteur : le nom de l’auteur, ses initiales, les commentaires associés au nom de l’auteur, etc. 

## **Ajouter un commentaire à la diapositive**
Ce code Python montre comment ajouter un commentaire à une diapositive dans une présentation PowerPoint :
```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Instancie la classe Presentation
with slides.Presentation() as presentation:
    # Ajoute une diapositive vide
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Ajoute un auteur
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Définit la position des commentaires
    point = draw.PointF(0.2, 0.2)

    # Ajoute un commentaire de diapositive pour un auteur sur la diapositive 1
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # Ajoute un commentaire de diapositive pour un auteur sur la diapositive 2
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # Accès à ISlide 1
    slide = presentation.slides[0]

    # Lorsque null est passé en argument, les commentaires de tous les auteurs sont récupérés pour la diapositive sélectionnée
    comments = slide.get_slide_comments(author)

    # Accède au commentaire à l'index 0 pour la diapositive 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Sélectionne la collection de commentaires de l'auteur à l'index 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```




## **Accéder aux commentaires de la diapositive**
Ce code Python montre comment accéder à un commentaire existant sur une diapositive dans une présentation PowerPoint :
```python
import aspose.slides as slides

# Instancie la classe Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```



## **Répondre aux commentaires**
Un commentaire parent est le commentaire principal ou original dans une hiérarchie de commentaires ou de réponses. En utilisant la propriété `parent_comment` (de la classe [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/)), vous pouvez définir ou obtenir un commentaire parent. 

Ce code Python montre comment ajouter des commentaires et récupérer leurs réponses :
```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Ajoute un commentaire
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Ajoute une réponse à comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Ajoute une autre réponse à comment1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Ajoute une réponse à la réponse existante
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Affiche la hiérarchie des commentaires sur la console
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

    # Supprime comment1 et toutes les réponses associées
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="warning" title="Attention" %}} 
* Lorsque la méthode `remove` (de la classe [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/)) est utilisée pour supprimer un commentaire, les réponses au commentaire sont également supprimées. 
* Si le paramètre `parent_comment` entraîne une référence circulaire, une `PptxEditException` sera levée.
{{% /alert %}}

## **Ajouter un commentaire moderne**

En 2021, Microsoft a introduit les *commentaires modernes* dans PowerPoint. La fonction de commentaires modernes améliore considérablement la collaboration dans PowerPoint. Grâce aux commentaires modernes, les utilisateurs de PowerPoint peuvent résoudre les commentaires, ancrer les commentaires à des objets et du texte, et interagir beaucoup plus facilement qu’auparavant. 

Nous avons implémenté la prise en charge des commentaires modernes en ajoutant la classe [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/). Les méthodes `add_modern_comment` et `insert_modern_comment` ont été ajoutées à la classe [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/). 

Ce code Python montre comment ajouter un commentaire moderne à une diapositive dans une présentation PowerPoint :
```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```


## **Supprimer un commentaire**

### **Supprimer tous les commentaires et auteurs**

Ce code Python montre comment supprimer tous les commentaires et auteurs d’une présentation :
```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Supprime tous les commentaires de la présentation
    for author in presentation.comment_authors:
        author.comments.clear()

    # Supprime tous les auteurs
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```


### **Supprimer des commentaires spécifiques**

Ce code Python montre comment supprimer des commentaires spécifiques sur une diapositive :
```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # ajouter des commentaires...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # supprime tous les commentaires contenant le texte "comment 1"
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Aspose.Slides prend‑il en charge un état comme « résolu » pour les commentaires modernes ?**

Oui. Les [commentaires modernes](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) exposent une propriété [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) ; vous pouvez lire et définir l’état d’un [commentaire](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) (par exemple, le marquer comme résolu), et cet état est enregistré dans le fichier et reconnu par PowerPoint.

**Les discussions en fil (chaînes de réponses) sont‑elles prises en charge, et existe‑t‑il une limite de profondeur ?**

Oui. Chaque commentaire peut référencer son [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/parent_comment/), ce qui permet des chaînes de réponses arbitraires. L’API ne spécifie pas de limite de profondeur d’imbrication.

**Dans quel système de coordonnées la position du marqueur de commentaire est‑elle définie sur une diapositive ?**

La position est stockée sous forme de point à virgule flottante dans le système de coordonnées de la diapositive. Cela vous permet de placer le marqueur de commentaire exactement où vous le souhaitez.