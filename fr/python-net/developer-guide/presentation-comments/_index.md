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
- ajouter un commentaire
- accéder au commentaire
- modifier le commentaire
- répondre au commentaire
- supprimer le commentaire
- effacer le commentaire
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Gérez les commentaires de présentation avec Aspose.Slides for Python via .NET : ajoutez, lisez, modifiez, répondez et supprimez les commentaires dans les présentations PowerPoint."
---
## **Vue d'ensemble**

Cet article explique comment gérer les commentaires de présentation avec Aspose.Slides for Python via .NET. Il présente les principaux types liés aux commentaires et montre comment ajouter des commentaires aux diapositives, accéder aux commentaires existants, travailler avec les réponses et les commentaires modernes, et supprimer les commentaires d'une présentation.

Les exemples couvrent des scénarios courants de révision et de collaboration dans PowerPoint, tels que l’attribution de commentaires aux auteurs, la lecture du texte et des métadonnées des commentaires, la création de chaînes de réponses et la suppression de commentaires sélectionnés ou de tous les commentaires.

Dans PowerPoint, les commentaires apparaissent comme des annotations sur les diapositives. Sélectionner un commentaire affiche son texte et la discussion associée.

## **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez utiliser les commentaires pour fournir des retours et collaborer avec des collègues lors de la révision des présentations.

Aspose.Slides for Python via .NET fournit les API suivantes pour travailler avec les commentaires :

* The [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) classe, qui donne accès aux auteurs de commentaires de la présentation.
* The [CommentCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/commentcollection/) classe, qui représente les commentaires associés à un auteur individuel.
* The [Comment](https://reference.aspose.com/slides/fr/python-net/aspose.slides/comment/) classe, qui fournit des informations sur un commentaire, notamment son auteur, son heure de création, sa position et son texte.
* The [CommentAuthor](https://reference.aspose.com/slides/fr/python-net/aspose.slides/commentauthor/) classe, qui fournit des informations sur un auteur, y compris son nom, ses initiales et les commentaires associés.

## **Ajouter des commentaires aux diapositives**

L'exemple suivant montre comment ajouter des commentaires aux diapositives d'une présentation PowerPoint :

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
    created_time = datetime.now()

    author.comments.add_comment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.comments.add_comment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.get_slide_comments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.text)

        comment_text = first_comment.author.comments[0].text
        print(comment_text)

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder aux commentaires des diapositives**

L'exemple suivant montre comment accéder aux commentaires existants dans une présentation PowerPoint :

```python
import aspose.slides as slides

with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("Slide: " + str(comment.slide.slide_number))
            print("Comment: " + comment.text)
            print("Author: " + comment.author.name)
            print("Posted at: " + str(comment.created_time))
            print()
```

## **Répondre aux commentaires**

Un commentaire parent est le commentaire original au sommet d'une hiérarchie de réponses. La propriété [parent_comment](https://reference.aspose.com/slides/fr/python-net/aspose.slides/comment/parent_comment/) de la classe [Comment](https://reference.aspose.com/slides/fr/python-net/aspose.slides/comment/) vous permet d'obtenir ou de définir le parent d'un commentaire.

L'exemple suivant montre comment ajouter des réponses et inspecter la hiérarchie de commentaires résultante :

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* Lorsque la méthode [remove](https://reference.aspose.com/slides/fr/python-net/aspose.slides/comment/remove/) de la classe [Comment] est utilisée pour supprimer un commentaire, toutes les réponses à ce commentaire sont également supprimées.
* Si la propriété [parent_comment](https://reference.aspose.com/slides/fr/python-net/aspose.slides/comment/parent_comment/) crée une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pptxeditexception/) est levée.
{{% /alert %}}

## **Ajouter des commentaires modernes**

Les commentaires modernes peuvent être associés à la diapositive elle-même, à une forme spécifique ou à une plage de texte à l'intérieur d'un AutoShape. La méthode [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/fr/python-net/aspose.slides/commentcollection/add_modern_comment/) accepte un argument [Shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/) en plus de la diapositive et des coordonnées du marqueur de commentaire.

Lorsque `None` est passé pour l'argument shape, le commentaire est un commentaire au niveau de la diapositive. Son marqueur est positionné selon les coordonnées fournies, mais il n'est pas associé à une forme particulière, ainsi [ModernComment.shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/moderncomment/shape/) renvoie `None`. Lorsqu'une [Shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/) est fournie, le commentaire est ancré à cette forme. Les coordonnées définissent toujours la position du marqueur de commentaire sur la diapositive, tandis que l'association à la forme peut être récupérée via [ModernComment.shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/moderncomment/shape/).

### **Ancrer un commentaire moderne à une forme**

L'exemple suivant crée à la fois un commentaire moderne au niveau de la diapositive et un commentaire moderne ancré à un AutoShape spécifique. Il lit ensuite la forme associée à chaque commentaire.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Ancrer des commentaires à différents types de forme**

Tout objet de diapositive dérivé de [Shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/) peut être utilisé comme ancre de forme. Des exemples courants incluent les instances [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/fr/python-net/aspose.slides/connector/) et [GraphicalObject](https://reference.aspose.com/slides/fr/python-net/aspose.slides/graphicalobject/) telles que les graphiques.

L'exemple suivant crée plusieurs types de formes courantes et associe un commentaire moderne à chacune d'elles.

```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Ancrer un commentaire à du texte et définir son statut**

Pour un commentaire moderne associé à un [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/fr/python-net/aspose.slides/moderncomment/text_selection_start/) spécifie la position de départ du texte sélectionné dans le cadre de texte de la forme, tandis que [ModernComment.text_selection_length](https://reference.aspose.com/slides/fr/python-net/aspose.slides/moderncomment/text_selection_length/) indique la longueur de la sélection. Ensemble, ces propriétés associent le commentaire à une plage de texte spécifique à l'intérieur de l'AutoShape.

La propriété [ModernComment.status](https://reference.aspose.com/slides/fr/python-net/aspose.slides/moderncomment/status/) peut être lue ou mise à jour avec une valeur de l'énumération [ModernCommentStatus](https://reference.aspose.com/slides/fr/python-net/aspose.slides/moderncommentstatus/) :

- `NOT_DEFINED` — aucun statut de commentaire moderne spécifique n'est défini.
- `ACTIVE` — le commentaire est actif.
- `RESOLVED` — le commentaire a été résolu.
- `CLOSED` — le commentaire est fermé.

L'exemple suivant crée un commentaire moderne ancré à une forme, l'associe à une sélection de texte, le marque comme résolu, enregistre la présentation et vérifie les valeurs après avoir rouvert le fichier.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.index(selected_text)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 100)
    shape.name = "Forecast text"
    shape.text_frame.text = shape_text

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    comment_position = draw.PointF(60, 60)
    comment = author.comments.add_modern_comment("Verify this forecast wording.", slide, shape, comment_position, datetime.now())
    comment.text_selection_start = expected_selection_start
    comment.text_selection_length = len(selected_text)
    comment.status = slides.ModernCommentStatus.RESOLVED

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_comments = reopened_slide.get_slide_comments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, slides.ModernComment):
            continue

        shape_matches = reopened_comment.shape.name == "Forecast text"
        selection_start_matches = reopened_comment.text_selection_start == expected_selection_start
        selection_length_matches = reopened_comment.text_selection_length == len(selected_text)
        status_matches = reopened_comment.status == slides.ModernCommentStatus.RESOLVED

        print("Shape anchor preserved: " + str(shape_matches))
        print("Text selection start preserved: " + str(selection_start_matches))
        print("Text selection length preserved: " + str(selection_length_matches))
        print("Resolved status preserved: " + str(status_matches))
```

### **Inspecter les commentaires modernes existants**

Pour examiner une présentation existante, vérifiez quels commentaires sont des instances de [ModernComment](https://reference.aspose.com/slides/fr/python-net/aspose.slides/moderncomment/), puis examinez [ModernComment.shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/fr/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/fr/python-net/aspose.slides/moderncomment/text_selection_length/) et [ModernComment.status](https://reference.aspose.com/slides/fr/python-net/aspose.slides/moderncomment/status/). Une forme `None` indique un commentaire au niveau de la diapositive. Pour une ancre [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/), les propriétés de sélection de texte identifient la plage associée dans le cadre de texte de la forme.

```python
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    for slide in presentation.slides:
        comments = slide.get_slide_comments(None)
        for comment in comments:
            if not isinstance(comment, slides.ModernComment):
                continue

            print("Slide: " + str(slide.slide_number))
            print("Text: " + comment.text)
            print("Status: " + str(comment.status))

            shape = comment.shape
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: " + shape.name)
                print("Anchor type: " + type(shape).__name__)

                if isinstance(shape, slides.AutoShape):
                    print("Text selection start: " + str(comment.text_selection_start))
                    print("Text selection length: " + str(comment.text_selection_length))

            print()
```

## **Supprimer les commentaires**

### **Supprimer tous les commentaires et auteurs de commentaires**

L'exemple suivant montre comment supprimer tous les commentaires et auteurs de commentaires d'une présentation :

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Supprimer des commentaires spécifiques**

L'exemple suivant montre comment supprimer des commentaires spécifiques d'une diapositive :

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
    author.comments.add_comment("comment 1", slide, first_comment_position, created_time)
    author.comments.add_comment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.comment_authors:
        comments_to_remove = []
        comments = slide.get_slide_comments(comment_author)

        for comment in comments:
            if comment.text == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.comments.remove(comment)

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides prend‑il en charge un statut résolu pour les commentaires modernes ?**

Oui. [ModernComment.status](https://reference.aspose.com/slides/fr/python-net/aspose.slides/moderncomment/status/) peut être lu et défini avec une valeur [ModernCommentStatus](https://reference.aspose.com/slides/fr/python-net/aspose.slides/moderncommentstatus/), y compris `RESOLVED`. Le statut est stocké dans la présentation et peut être relu après la réouverture du fichier.

**Les discussions en fil (chaînes de réponses) sont‑elles prises en charge, et existe‑t‑il une limite de profondeur ?**

Oui. Chaque commentaire peut référencer son [parent comment](https://reference.aspose.com/slides/fr/python-net/aspose.slides/comment/parent_comment/), permettant des chaînes de réponses. L'API ne définit pas de limite spécifique de profondeur d'imbrication.

**Dans quel système de coordonnées la position d'un marqueur de commentaire est‑elle définie sur une diapositive ?**

La position du marqueur est définonnée par des coordonnées à virgule flottante dans le système de coordonnées de la diapositive, ce qui vous permet de le placer avec précision sur la diapositive.