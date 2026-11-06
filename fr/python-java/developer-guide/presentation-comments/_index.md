---
title: Gérer les commentaires de présentation en Python via Java
linktitle: Commentaires de présentation
type: docs
weight: 100
url: /fr/python-java/presentation-comments/
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
- Java
- Aspose.Slides
description: "Gérez les commentaires de présentation avec Aspose.Slides pour Python via Java : ajoutez, lisez, modifiez, répondez et supprimez les commentaires dans les présentations PowerPoint rapidement et facilement."
---
## **Vue d'ensemble**

Cet article explique comment gérer les commentaires de présentation avec Aspose.Slides pour Python via Java. Il présente les principaux types liés aux commentaires et montre comment ajouter des commentaires aux diapositives, accéder aux commentaires existants, travailler avec les réponses et les commentaires modernes, et supprimer les commentaires d'une présentation.

Les exemples couvrent des scénarios courants d'examen et de collaboration dans PowerPoint, tels que l'affectation de commentaires aux auteurs, la lecture du texte et des métadonnées des commentaires, la construction de chaînes de réponses et la suppression de commentaires sélectionnés ou de tous les commentaires.

Dans PowerPoint, les commentaires apparaissent comme des annotations sur les diapositives. Sélectionner un commentaire affiche son texte et la discussion associée.

Pour demander que les commentaires soient affichés ou masqués lors de l'ouverture d'une présentation sans modifier les commentaires eux‑mêmes, voir [Afficher ou masquer les commentaires lors de l'ouverture d'une présentation](/slides/fr/python-java/presentation-view-properties/).

## **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez utiliser les commentaires pour fournir des retours et collaborer avec des collègues lors de la révision de présentations.

Aspose.Slides pour Python via Java fournit les API suivantes pour travailler avec les commentaires :

* La classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) qui fournit l'accès aux auteurs de commentaires de la présentation.
* La classe [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/) qui représente les commentaires associés à un auteur individuel.
* La classe [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/) qui fournit des informations sur un commentaire, incluant son auteur, son heure de création, sa position et son texte.
* La classe [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/) qui fournit des informations sur un auteur, incluant son nom, ses initiales et les commentaires associés.

## **Ajouter des commentaires aux diapositives**

L'exemple crée deux diapositives et enregistre un auteur de commentaire avec [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor). Il utilise [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) pour placer un commentaire sur chaque diapositive, puis récupère les commentaires de la première diapositive pour cet auteur avec [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments). La console affiche le texte du premier commentaire deux fois, démontrant l'accès à la fois via la diapositive et l'auteur, et la présentation enregistrée contient les deux commentaires.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0))

    author = presentation.getCommentAuthors().addAuthor("Jawad", "MF")
    position = Point2DFloat(0.2, 0.2)
    created_time = Date()

    author.getComments().addComment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.getComments().addComment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.getSlideComments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.getText())

        author_comments = first_comment.getAuthor().getComments()
        comment_text = author_comments.get_Item(0).getText()
        print(comment_text)

    presentation.save("Comments_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Trouver ou créer un auteur de commentaire**

Lorsque qu'une révision automatisée traite la même présentation à plusieurs reprises, recherchez dans la collection retournée par [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) avant d'ajouter un auteur. [findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials) correspond à la fois au nom et aux initiales et renvoie un tableau d'auteurs correspondants, ou un tableau vide s'il n'y a aucune correspondance. En revanche, [findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName) recherche uniquement par nom, quel que soit les initiales. Appeler [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) avec un nom et des initiales déjà présents dans la collection lève une exception.

L'exemple nécessite un fichier de présentation contenant au moins une diapositive. À chaque passage (deux passages), il réutilise le premier auteur correspondant, ou en crée un uniquement si le résultat est vide. S'il existe plusieurs correspondances, il sélectionne le premier élément du tableau sans fusionner ni supprimer les autres auteurs. Il appelle ensuite [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) pour l'auteur sélectionné et enregistre la présentation. Le deuxième passage ouvre la sortie du premier passage et répète l'opération.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = Point2DFloat(20, 20)

for pass_number in range(1, 3):
    presentation = Presentation(input_file)
    try:
        matches = presentation.getCommentAuthors().findByNameAndInitials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.getCommentAuthors().addAuthor(author_name, author_initials)
        created_time = Date()
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, created_time)

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, SaveFormat.Pptx)
        input_file = output_file
    finally:
        presentation.dispose()
```

Le deuxième passage ajoute un autre commentaire sans ajouter un nouvel auteur ni supprimer les commentaires existants. Le fichier final, `review_pass_2.pptx`, contient les deux nouveaux commentaires ainsi que les commentaires d'origine. Réutiliser un auteur ne déduplique pas les commentaires : pour éviter d'ajouter à plusieurs reprises le même commentaire, implémentez une détection de doublons distincte avant de l'ajouter.

## **Accéder aux commentaires des diapositives**

L'exemple ouvre une présentation existante et lit la collection retournée par [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors). Pour chaque auteur, il parcourt la collection retournée par [getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments) et affiche le numéro de la diapositive, le texte du commentaire, le nom de l'auteur et l'heure de création. La présentation d'entrée doit contenir des commentaires pour produire une sortie console.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Comments1.pptx")
try:
    for author in presentation.getCommentAuthors():
        for comment in author.getComments():
            print("Slide: ", comment.getSlide().getSlideNumber())
            print("Comment: ", comment.getText())
            print("Author: ", comment.getAuthor().getName())
            print("Posted at: ", comment.getCreatedTime())
            print()
finally:
    presentation.dispose()
```

## **Répondre aux commentaires**

Un commentaire parent est le commentaire original au sommet d'une hiérarchie de réponses. Les méthodes [Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) et [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) vous permettent d'obtenir ou de définir le parent d'un commentaire.

L'exemple crée des commentaires de deux auteurs et utilise [setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) pour construire des réponses, y compris une réponse à une autre réponse. Passer `None` à [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) récupère les commentaires de tous les auteurs ; la console indente chaque entrée selon sa profondeur dans la hiérarchie de réponses. L'exemple enregistre la discussion complète, appelle [remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) sur le premier commentaire racine, et enregistre une seconde présentation avec ce commentaire et ses réponses supprimés.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    position = Point2DFloat(10, 10)
    created_time = Date()

    thread_author = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.")
    root_comment = thread_author.getComments().addComment("comment 1", slide, position, created_time)

    responding_author = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.")
    direct_reply = responding_author.getComments().addComment("reply 1 for comment 1", slide, position, created_time)
    direct_reply.setParentComment(root_comment)

    branch_reply = responding_author.getComments().addComment("reply 2 for comment 1", slide, position, created_time)
    branch_reply.setParentComment(root_comment)

    nested_reply = thread_author.getComments().addComment("subreply 3 for reply 2", slide, position, created_time)
    nested_reply.setParentComment(branch_reply)

    responding_author.getComments().addComment("comment 2", slide, position, created_time)
    separate_thread_comment = responding_author.getComments().addComment("comment 3", slide, position, created_time)

    separate_thread_reply = thread_author.getComments().addComment("reply 4 for comment 3", slide, position, created_time)
    separate_thread_reply.setParentComment(separate_thread_comment)

    comments = slide.getSlideComments(None)
    for i in range(len(comments)):
        comment = comments[i]
        while comment.getParentComment() is not None:
            print("\t", end="")
            comment = comment.getParentComment()

        print(f"{comments[i].getAuthor().getName()}: {comments[i].getText()}")

    presentation.save("parent_comment.pptx", SaveFormat.Pptx)

    root_comment.remove()
    presentation.save("remove_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
* Lorsque la méthode [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) est utilisée pour supprimer un commentaire, toutes les réponses à ce commentaire sont également supprimées.
* Si [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) crée une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/) est levée.
{{% /alert %}}

## **Ajouter des commentaires modernes**

Les commentaires modernes peuvent être associés à la diapositive elle‑même, à une forme spécifique ou à une plage de texte à l’intérieur d'un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). La méthode [CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) accepte un argument [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) en plus de la diapositive et des coordonnées du marqueur de commentaire.

Lorsque `None` est passé pour l’argument shape, le commentaire est un commentaire au niveau de la diapositive. Son marqueur est positionné par les coordonnées fournies, mais il n'est pas associé à une forme particulière, ainsi [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) renvoie `None`. Lorsqu’une [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) est fournie, le commentaire est ancré à cette forme. Les coordonnées définissent toujours la position du marqueur de commentaire sur la diapositive, tandis que l'association à la forme peut être récupérée via [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape).

### **Ancrer un commentaire moderne à une forme**

L'exemple appelle [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) deux fois : une fois avec une forme `None` pour un commentaire au niveau de la diapositive et une fois avec un rectangle comme ancre. La lecture de [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) affiche `True` pour le test `None` du commentaire au niveau de la diapositive et `Revenue title` pour le commentaire ancré. Les deux commentaires sont enregistrés avec la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80)
    shape.setName("Revenue title")
    shape.getTextFrame().setText("Quarterly revenue")

    created_time = Date()
    slide_comment_position = Point2DFloat(20, 20)
    shape_comment_position = Point2DFloat(60, 60)
    slide_comment = author.getComments().addModernComment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.getComments().addModernComment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.getShape() is None)
    print(shape_comment.getShape().getName())

    presentation.save("modern_comments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ancrer des commentaires à différents types de forme**

Toute objet de diapositive qui hérite de [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) peut être utilisé comme ancre de forme. Les exemples courants incluent les instances de [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/) et [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/) comme les graphiques.

L'exemple utilise [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) pour associer un commentaire à chacun des cinq types de forme : un AutoShape, un cadre d’image, un groupe, un connecteur et un graphique. L’image utilise des données d’image incorporées, aucune image externe n'est donc requise. Chaque commentaire possède sa propre position de marqueur, et la présentation enregistrée conserve les cinq associations de forme.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")
Base64 = jpype.JClass("java.util.Base64")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    created_time = Date()

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60)
    auto_shape.getTextFrame().setText("AutoShape")

    auto_shape_comment_position = Point2DFloat(30, 30)
    author.getComments().addModernComment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = Base64.getDecoder().decode(image_base64)
    image = presentation.getImages().addImage(image_data)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image)
    picture_comment_position = Point2DFloat(230, 30)
    author.getComments().addModernComment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.getShapes().addGroupShape()
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40)
    group_shape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40)
    group_comment_position = Point2DFloat(40, 150)
    author.getComments().addModernComment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40)
    connector_comment_position = Point2DFloat(240, 150)
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180)
    chart_comment_position = Point2DFloat(420, 40)
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ancrer un commentaire à du texte et définir son statut**

Pour un commentaire moderne associé à un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart) et [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) accèdent à la position de départ du texte sélectionné dans le cadre de texte de la forme. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) et [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) accèdent à la longueur de la sélection. Ensemble, ces valeurs associent le commentaire à une plage de texte spécifique à l'intérieur de l'AutoShape.

Les méthodes [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) et [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) accèdent à une valeur parmi les constantes [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) :

- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — aucun statut de commentaire moderne spécifique n'est défini.
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — le commentaire est actif.
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — le commentaire a été résolu.
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — le commentaire est fermé.

L'exemple ancre un commentaire moderne aux mots "quarterly revenue" dans le texte d'un rectangle. Il calcule le début de la sélection (indexé à zéro) à partir du texte et le transmet à [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) et utilise [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) pour définir le nombre de caractères sélectionnés. Après avoir appelé [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) avec `Resolved`, il enregistre et rouvre la présentation. Les quatre vérifications console doivent chacune afficher `True`, confirmant que l'ancre de forme, la plage de texte et le statut ont été préservés.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ModernComment, ModernCommentStatus, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.find(selected_text)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    shape.setName("Forecast text")
    shape.getTextFrame().setText(shape_text)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    comment_position = Point2DFloat(60, 60)
    created_time = Date()
    comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, comment_position, created_time)
    comment.setTextSelectionStart(expected_selection_start)
    comment.setTextSelectionLength(len(selected_text))
    comment.setStatus(ModernCommentStatus.Resolved)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_comments = reopened_slide.getSlideComments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, ModernComment):
            continue

        modern_comment = reopened_comment
        shape_matches = modern_comment.getShape() is not None and modern_comment.getShape().getName() == "Forecast text"
        selection_start_matches = modern_comment.getTextSelectionStart() == expected_selection_start
        selection_length_matches = modern_comment.getTextSelectionLength() == len(selected_text)
        status_matches = modern_comment.getStatus() == ModernCommentStatus.Resolved

        print("Shape anchor preserved: ", shape_matches)
        print("Text selection start preserved: ", selection_start_matches)
        print("Text selection length preserved: ", selection_length_matches)
        print("Resolved status preserved: ", status_matches)
finally:
    reopened_presentation.dispose()
```

### **Inspecter les commentaires modernes existants**

L'exemple nécessite une présentation existante contenant des commentaires modernes et imprime leur texte, statut et détails d'ancrage. Pour l'inspecter, vérifiez quels commentaires sont des instances de [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/), puis examinez [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) et [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus). Une forme `None` indique un commentaire au niveau de la diapositive. Pour une ancre [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), les méthodes de sélection de texte identifient la plage associée dans le cadre de texte de la forme.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ModernComment, Presentation

presentation = Presentation("comments.pptx")
try:
    for slide in presentation.getSlides():
        comments = slide.getSlideComments(None)
        for comment in comments:
            if not isinstance(comment, ModernComment):
                continue

            modern_comment = comment
            print("Slide: ", slide.getSlideNumber())
            print("Text: ", modern_comment.getText())
            print("Status: ", modern_comment.getStatus())

            shape = modern_comment.getShape()
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: ", shape.getName())
                print("Anchor type: ", shape.getClass().getSimpleName())

                if isinstance(shape, AutoShape):
                    print("Text selection start: ", modern_comment.getTextSelectionStart())
                    print("Text selection length: ", modern_comment.getTextSelectionLength())

            print()
finally:
    presentation.dispose()
```

## **Supprimer les commentaires**

Aspose.Slides pour Python via Java vous permet de supprimer tous les commentaires et leurs auteurs d'une présentation ou de supprimer des commentaires sélectionnés tout en conservant le reste. Les exemples suivants démontrent les deux approches et enregistrent la présentation mise à jour.

### **Supprimer tous les commentaires et les auteurs de commentaires**

L'exemple ouvre une présentation existante et appelle [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear) pour chaque auteur, puis appelle [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear) pour supprimer les auteurs eux‑même. La présentation enregistrée ne contient ni commentaires ni auteurs de commentaires. Utilisez une présentation contenant des commentaires pour observer la suppression.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("example.pptx")
try:
    for author in presentation.getCommentAuthors():
        author.getComments().clear()

    presentation.getCommentAuthors().clear()

    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Supprimer des commentaires spécifiques**

L'exemple crée deux commentaires sur une diapositive et utilise [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) pour trouver les commentaires de chaque auteur. Il recueille les commentaires dont le texte est égal à "comment 1" avant d'appeler [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove), évitant ainsi les modifications de la collection pendant la sélection. La présentation enregistrée ne conserve que "comment 2".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Author", "A")
    created_time = Date()

    first_comment_position = Point2DFloat(0.2, 0.2)
    second_comment_position = Point2DFloat(0.3, 0.2)
    author.getComments().addComment("comment 1", slide, first_comment_position, created_time)
    author.getComments().addComment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.getCommentAuthors():
        comments_to_remove = []
        comments = slide.getSlideComments(comment_author)

        for comment in comments:
            if comment.getText() == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.getComments().remove(comment)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Aspose.Slides prend‑t‑il en charge un statut résolu pour les commentaires modernes ?**

Oui. [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) et [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) accèdent à une valeur [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/), y compris `Resolved`. Le statut est stocké dans la présentation et peut être relu après que le fichier a été rouvert.

**Les discussions en fil (chaînes de réponses) sont‑elles prises en charge, et existe‑t‑il une limite de profondeur ?**

Oui. Chaque commentaire peut référencer son [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment), ce qui permet les chaînes de réponses. L'API ne définit pas de limite spécifique de profondeur d'imbrication.

**Dans quel système de coordonnées la position d’un marqueur de commentaire est‑elle définie sur une diapositive ?**

La position du marqueur est définie par des coordonnées à virgule flottante dans le système de coordonnées de la diapositive, ce qui vous permet de le placer avec précision sur la diapositive.