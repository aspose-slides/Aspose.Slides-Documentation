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
description: "Gérer les commentaires de présentation avec Aspose.Slides pour Python via .NET : ajouter, lire, modifier, répondre et supprimer les commentaires dans les présentations PowerPoint."
---
## **Vue d'ensemble**

Cet article explique comment gérer les commentaires de présentation avec Aspose.Slides pour Python via .NET. Il présente les principaux types liés aux commentaires et montre comment ajouter des commentaires aux diapositives, accéder aux commentaires existants, travailler avec les réponses et les commentaires modernes, et supprimer des commentaires d'une présentation.

Les exemples couvrent des scénarios courants de révision et de collaboration dans PowerPoint, tels que l'attribution de commentaires aux auteurs, la lecture du texte et des métadonnées des commentaires, la création de chaînes de réponses et la suppression de commentaires sélectionnés ou de tous les commentaires.

Dans PowerPoint, les commentaires apparaissent comme des annotations sur les diapositives. Sélectionner un commentaire affiche son texte et la discussion associée.

Pour demander que les commentaires soient affichés ou masqués lors de l'ouverture d'une présentation sans modifier les commentaires eux‑mêmes, consultez [Afficher ou masquer les commentaires lors de l'ouverture d'une présentation](/slides/fr/python-net/presentation-view-properties/).

## **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez utiliser les commentaires pour fournir des retours et collaborer avec des collègues lors de la révision de présentations.

Aspose.Slides pour Python via .NET fournit les API suivantes pour travailler avec les commentaires :

* La [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) classe, qui donne accès aux auteurs de commentaires de la présentation.
* La [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) classe, qui représente les commentaires associés à un auteur individuel.
* La [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) classe, qui fournit des informations sur un commentaire, y compris son auteur, son heure de création, sa position et son texte.
* La [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) classe, qui fournit des informations sur un auteur, y compris son nom, ses initiales et les commentaires associés.

## **Ajouter des commentaires aux diapositives**

L'exemple crée deux diapositives et enregistre un auteur de commentaire avec [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/). Il utilise [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) pour placer un commentaire sur chaque diapositive, puis récupère les commentaires de la première diapositive pour cet auteur avec [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/). La console affiche le texte du premier commentaire deux fois, montrant l'accès à la fois via la diapositive et l'auteur, et la présentation enregistrée contient les deux commentaires.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = slides.PointF(0.2, 0.2)
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

## **Trouver ou créer un auteur de commentaire**

Lorsque une révision automatisée traite la même présentation de façon répétée, recherchez dans sa collection [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) avant d'ajouter un auteur. [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) correspond à la fois au nom et aux initiales et renvoie un tableau d'auteurs correspondants, ou un tableau vide s'il n'y a aucune correspondance. En revanche, [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) recherche uniquement par nom, quelles que soient les initiales. Appeler [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) avec un nom et des initiales déjà présents dans la collection lève une exception.

L'exemple nécessite un fichier de présentation contenant au moins une diapositive. Au cours de deux passes, il réutilise le premier auteur correspondant, ou en crée un uniquement si le résultat est vide. S'il existe plusieurs correspondances, il sélectionne le premier élément du tableau sans fusionner ni supprimer les autres auteurs. Il appelle ensuite [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) pour l'auteur sélectionné et enregistre la présentation. La deuxième passe ouvre la sortie de la première passe et répète l'opération.

```python
from datetime import datetime

import aspose.slides as slides

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = slides.PointF(20, 20)

for pass_number in range(1, 3):
    with slides.Presentation(input_file) as presentation:
        matches = presentation.comment_authors.find_by_name_and_initials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.comment_authors.add_author(author_name, author_initials)
        author.comments.add_comment("Please review this slide.", presentation.slides[0], position, datetime.now())

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, slides.export.SaveFormat.PPTX)
        input_file = output_file
```

La deuxième passe ajoute un autre commentaire sans ajouter un nouvel auteur ni supprimer les commentaires existants. Le fichier final, `review_pass_2.pptx`, contient les deux nouveaux commentaires ainsi que les commentaires originaux. Réutiliser un auteur ne dédoublonne pas les commentaires : pour éviter d'ajouter plusieurs fois le même commentaire, implémentez une détection de doublons séparée avant de l'ajouter.

## **Accéder aux commentaires des diapositives**

L'exemple ouvre une présentation existante et lit sa collection [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/). Pour chaque auteur, il parcourt les [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) et affiche le numéro de la diapositive, le texte du commentaire, le nom de l'auteur et l'heure de création. La présentation d'entrée doit contenir des commentaires pour générer une sortie console.

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

Un commentaire parent est le commentaire original au sommet d'une hiérarchie de réponses. La propriété [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) de la classe [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) vous permet d'obtenir ou de définir le parent d'un commentaire.

L'exemple crée des commentaires de deux auteurs et utilise [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) pour construire des réponses, y compris une réponse à une autre réponse. Passer `None` à [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) récupère les commentaires de tous les auteurs ; la console indente chaque entrée selon sa profondeur dans la hiérarchie des réponses. L'exemple enregistre la discussion complète, appelle [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) sur le premier commentaire racine, et enregistre une seconde présentation avec ce commentaire et ses réponses supprimés.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    position = slides.PointF(10, 10)
    created_time = datetime.now()

    original_author = presentation.comment_authors.add_author("Author_1", "A.A.")
    root_comment = original_author.comments.add_comment("comment 1", slide, position, created_time)

    reviewer = presentation.comment_authors.add_author("Author_2", "B.B.")
    first_reply = reviewer.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    first_reply.parent_comment = root_comment

    second_reply = reviewer.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    second_reply.parent_comment = root_comment

    sub_reply = original_author.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = second_reply

    reviewer.comments.add_comment("comment 2", slide, position, created_time)
    separate_comment = reviewer.comments.add_comment("comment 3", slide, position, created_time)

    separate_reply = original_author.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    separate_reply.parent_comment = separate_comment

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    root_comment.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* Lorsque la méthode [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) de la classe [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) est utilisée pour supprimer un commentaire, toutes les réponses à ce commentaire sont également supprimées.
* Si la propriété [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) crée une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) est levée.
{{% /alert %}}

## **Ajouter des commentaires modernes**

Les commentaires modernes peuvent être associés à la diapositive elle‑même, à une forme spécifique ou à une plage de texte à l'intérieur d'une AutoShape. La méthode [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) accepte un argument [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) en plus de la diapositive et des coordonnées du marqueur de commentaire.

Lorsque `None` est passé pour l'argument shape, le commentaire est un commentaire de niveau diapositive. Son marqueur est positionné par les coordonnées fournies, mais il n'est associé à aucune forme particulière, ainsi [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) renvoie `None`. Lorsqu'une [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) est fournie, le commentaire est ancré à cette forme. Les coordonnées définissent toujours la position du marqueur de commentaire sur la diapositive, tandis que l'association à la forme peut être récupérée via [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/).

### **Ancrer un commentaire moderne à une forme**

L'exemple appelle [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) deux fois : une fois avec une forme `None` pour un commentaire de niveau diapositive et une fois avec un rectangle comme ancre. La lecture de [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) affiche `True` pour la vérification de null du commentaire de niveau diapositive et `Revenue title` pour le commentaire ancré. Les deux commentaires sont enregistrés avec la présentation.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = slides.PointF(20, 20)
    shape_comment_position = slides.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Ancrer des commentaires à différents types de forme**

Toute objet de diapositive dérivé de [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) peut être utilisé comme ancre de forme. Les exemples courants incluent [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/), et les instances [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) telles que les graphiques.

L'exemple utilise [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) pour associer un commentaire à chacun des cinq types de forme : une AutoShape, un picture frame, un groupe, un connector et un graphique. L'image utilise des données d'image intégrées, aucune image externe n'est donc requise. Chaque commentaire possède sa propre position de marqueur, et la présentation enregistrée conserve les cinq associations de forme.

```python
import base64
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"

    auto_shape_comment_position = slides.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = slides.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = slides.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = slides.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = slides.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Ancrer un commentaire à du texte et définir son statut**

Pour un commentaire moderne associé à une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) indique la position de départ du texte sélectionné dans le cadre de texte de la forme, tandis que [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) indique la longueur de la sélection. Ensemble, ces propriétés associent le commentaire à une plage de texte spécifique à l'intérieur de l'AutoShape.

La propriété [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) peut être lue ou mise à jour avec une valeur de l'énumération [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) :

- `NOT_DEFINED` — aucun statut de commentaire moderne spécifique n'est défini.
- `ACTIVE` — le commentaire est actif.
- `RESOLVED` — le commentaire a été résolu.
- `CLOSED` — le commentaire est fermé.

L'exemple ancre un commentaire moderne aux mots "quarterly revenue" dans le texte d'un rectangle. Il calcule le [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) à indice zéro à partir du texte et définit [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) au nombre de caractères sélectionnés. Après avoir défini [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) à `RESOLVED`, il enregistre et rouvre la présentation. Les quatre vérifications console doivent chacune afficher `True`, confirmant que l'ancre de forme, la plage de texte et le statut ont été conservés.

```python
from datetime import datetime

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
    comment_position = slides.PointF(60, 60)
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

L'exemple nécessite une présentation existante contenant des commentaires modernes et affiche leur texte, statut et détails d'ancrage. Pour l'inspecter, vérifiez quels commentaires sont des instances de [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/), puis examinez [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) et [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/). Une forme `None` indique un commentaire de niveau diapositive. Pour une ancre [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), les propriétés de sélection de texte identifient la plage associée dans le cadre de texte de la forme.

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

Aspose.Slides pour Python via .NET vous permet de supprimer tous les commentaires et leurs auteurs d'une présentation ou de supprimer des commentaires sélectionnés tout en conservant les autres. Les exemples suivants montrent les deux approches et enregistrent la présentation mise à jour.

### **Supprimer tous les commentaires et leurs auteurs**

L'exemple ouvre une présentation existante et appelle [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) pour chaque auteur, puis appelle [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) pour supprimer les auteurs eux‑mêmes. La présentation enregistrée ne contient ni commentaires ni auteurs de commentaires. Utilisez une présentation contenant des commentaires pour observer la suppression.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Supprimer des commentaires spécifiques**

L'exemple crée deux commentaires sur une diapositive et utilise [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) pour trouver les commentaires de chaque auteur. Il collecte les commentaires dont le texte est égal à "comment 1" avant d'appeler [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/), évitant ainsi les modifications de la collection pendant la sélection. La présentation enregistrée ne conserve que le commentaire "comment 2".

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = slides.PointF(0.2, 0.2)
    second_comment_position = slides.PointF(0.3, 0.2)
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

Oui. [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) peut être lu et défini avec une valeur [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/), y compris `RESOLVED`. Le statut est stocké dans la présentation et peut être relu après la réouverture du fichier.

**Les discussions imbriquées (chaînes de réponses) sont‑elles prises en charge, et existe‑t‑il une limite de profondeur ?**

Oui. Chaque commentaire peut référencer son [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/), ce qui permet les chaînes de réponses. L'API ne définit pas de limite spécifique de profondeur d'imbrication.

**Dans quel système de coordonnées la position du marqueur de commentaire est‑elle définie sur une diapositive ?**

La position du marqueur est définie par des coordonnées à virgule flottante dans le système de coordonnées de la diapositive, ce qui vous permet de le placer précisément sur la diapositive.