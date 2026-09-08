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
description: "Gérez les commentaires de présentation avec Aspose.Slides for Python via Java : ajoutez, lisez, modifiez, répondez et supprimez les commentaires dans les présentations PowerPoint rapidement et facilement."
---
## **Overview**

Cet article explique comment gérer les commentaires de présentation avec Aspose.Slides for Python via Java. Il présente les principaux types liés aux commentaires et montre comment ajouter des commentaires aux diapositives, accéder aux commentaires existants, travailler avec les réponses et les commentaires modernes, et supprimer des commentaires d’une présentation.

Les exemples couvrent des scénarios courants de révision et de collaboration dans PowerPoint, tels que l’affectation de commentaires à des auteurs, la lecture du texte et des métadonnées des commentaires, la création de chaînes de réponses, et la suppression de commentaires sélectionnés ou de tous les commentaires.

Dans PowerPoint, les commentaires apparaissent comme des annotations sur les diapositives. Sélectionner un commentaire affiche son texte et la discussion associée.

## **Why Add Comments to Presentations?**

Vous pouvez utiliser les commentaires pour fournir des retours et collaborer avec des collègues lors de la révision de présentations.

Aspose.Slides for Python via Java propose les API suivantes pour travailler avec les commentaires :

* La classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) qui donne accès aux auteurs de commentaires de la présentation.
* La classe [CommentCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/commentcollection/) qui représente les commentaires associés à un auteur individuel.
* La classe [Comment](https://reference.aspose.com/slides/fr/python-java/aspose.slides/comment/) qui fournit des informations sur un commentaire, y compris son auteur, sa date de création, sa position et son texte.
* La classe [CommentAuthor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/commentauthor/) qui fournit des informations sur un auteur, y compris son nom, ses initiales et les commentaires associés.

## **Add Slide Comments**

L’exemple suivant montre comment ajouter des commentaires aux diapositives d’une présentation PowerPoint :

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

## **Access Slide Comments**

L’exemple suivant montre comment accéder aux commentaires existants dans une présentation PowerPoint :

```python
import jpime
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

## **Reply to Comments**

Un commentaire parent est le commentaire original au sommet d’une hiérarchie de réponses. Les méthodes [Comment.getParentComment](https://reference.aspose.com/slides/fr/python-java/aspose.slides/comment/#getParentComment) et [Comment.setParentComment](https://reference.aspose.com/slides/fr/python-java/aspose.slides/comment/#setParentComment) vous permettent d’obtenir ou de définir le commentaire parent.

L’exemple suivant montre comment ajouter des réponses et inspecter la hiérarchie de commentaires résultante :

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

{{% alert color="warning" title="Avertissement" %}}
* Lorsque la méthode [Comment.remove](https://reference.aspose.com/slides/fr/python-java/aspose.slides/comment/#remove) est utilisée pour supprimer un commentaire, toutes les réponses à ce commentaire sont également supprimées.
* Si [Comment.setParentComment](https://reference.aspose.com/slides/fr/python-java/aspose.slides/comment/#setParentComment) crée une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pptxeditexception/) est levée.
{{% /alert %}}

## **Add Modern Comments**

Les commentaires modernes peuvent être associés à la diapositive elle‑même, à une forme spécifique ou à une plage de texte à l’intérieur d’un [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/). La méthode [CommentCollection.addModernComment](https://reference.aspose.com/slides/fr/python-java/aspose.slides/commentcollection/#addModernComment) accepte un argument [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/) en plus de la diapositive et des coordonnées du marqueur de commentaire.

Lorsque `None` est passé pour l’argument shape, le commentaire est un commentaire de niveau diapositive. Son marqueur est positionné selon les coordonnées fournies, mais il n’est pas associé à une forme particulière, ainsi [ModernComment.getShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncomment/#getShape) renvoie `None`. Lorsqu’une [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/) est fournie, le commentaire est ancré à cette forme. Les coordonnées définissent toujours la position du marqueur de commentaire sur la diapositive, tandis que l’association à la forme peut être récupérée via [ModernComment.getShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncomment/#getShape).

### **Anchor a Modern Comment to a Shape**

L’exemple suivant crée à la fois un commentaire moderne de niveau diapositive et un commentaire moderne ancré à un [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) spécifique. Il lit ensuite la forme associée à chaque commentaire.

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

### **Anchor Comments to Different Shape Types**

Tout objet de diapositive qui hérite de [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/) peut être utilisé comme ancre de forme. Des exemples courants incluent [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/fr/python-java/aspose.slides/connector/) et des instances de [GraphicalObject](https://reference.aspose.com/slides/fr/python-java/aspose.slides/graphicalobject/) comme les graphiques.

L’exemple suivant crée plusieurs types de formes courants et associe un commentaire moderne à chacun d’eux.

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

### **Anchor a Comment to Text and Set Its Status**

Pour un commentaire moderne associé à un [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/), les méthodes [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncomment/#getTextSelectionStart) et [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncomment/#setTextSelectionStart) accèdent à la position de départ du texte sélectionné dans le cadre de texte de la forme. Les méthodes [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncomment/#getTextSelectionLength) et [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncomment/#setTextSelectionLength) accèdent à la longueur de la sélection. Ensemble, ces valeurs associent le commentaire à une plage de texte spécifique à l’intérieur de l’AutoShape.

Les méthodes [ModernComment.getStatus](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncomment/#getStatus) et [ModernComment.setStatus](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncomment/#setStatus) récupèrent une valeur parmi les constantes [ModernCommentStatus](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncommentstatus/) :

- [NotDefined](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncommentstatus/#NotDefined) — aucun statut de commentaire moderne spécifié.
- [Active](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncommentstatus/#Active) — le commentaire est actif.
- [Resolved](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncommentstatus/#Resolved) — le commentaire a été résolu.
- [Closed](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncommentstatus/#Closed) — le commentaire est fermé.

L’exemple suivant crée un commentaire moderne ancré à une forme, l’associe à une sélection de texte, le marque comme résolu, enregistre la présentation et vérifie les valeurs après réouverture du fichier.

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

### **Inspect Existing Modern Comments**

Pour inspecter une présentation existante, vérifiez quels commentaires sont des instances de [ModernComment](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncomment/), puis examinez [ModernComment.getShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncomment/#getTextSelectionLength) et [ModernComment.getStatus](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncomment/#getStatus). Une forme `None` indique un commentaire de niveau diapositive. Pour une ancre [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/), les méthodes de sélection de texte identifient la plage associée dans le cadre de texte de la forme.

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

## **Remove Comments**

### **Remove All Comments and Comment Authors**

L’exemple suivant montre comment supprimer tous les commentaires et tous les auteurs de commentaires d’une présentation :

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

### **Remove Specific Comments**

L’exemple suivant montre comment supprimer des commentaires spécifiques d’une diapositive :

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

**Does Aspose.Slides support a resolved status for modern comments?**

Oui. Les méthodes [ModernComment.getStatus](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncomment/#getStatus) et [ModernComment.setStatus](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncomment/#setStatus) accèdent à une valeur [ModernCommentStatus](https://reference.aspose.com/slides/fr/python-java/aspose.slides/moderncommentstatus/), y compris `Resolved`. Le statut est stocké dans la présentation et peut être lu de nouveau après la réouverture du fichier.

**Are threaded discussions (reply chains) supported, and is there a nesting limit?**

Oui. Chaque commentaire peut référencer son [parent comment](https://reference.aspose.com/slides/fr/python-java/aspose.slides/comment/#getParentComment), ce qui permet des chaînes de réponses. L’API ne définit pas de limite spécifique de profondeur d’imbrication.

**In what coordinate system is a comment marker's position defined on a slide?**

La position du marqueur est définie par des coordonnées en virgule flottante dans le système de coordonnées de la diapositive, ce qui vous permet de le placer précisément sur la diapositive.