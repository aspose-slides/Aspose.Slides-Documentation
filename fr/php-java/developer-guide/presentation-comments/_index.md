---
title: Gérer les commentaires de présentation en PHP
linktitle: Commentaires de présentation
type: docs
weight: 100
url: /fr/php-java/presentation-comments/
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
- PHP
- Aspose.Slides
description: "Gérez les commentaires de présentation avec Aspose.Slides for PHP via Java : ajoutez, lisez, modifiez, répondez et supprimez les commentaires dans les présentations PowerPoint rapidement et facilement."
---
## **Vue d'ensemble**

Cet article explique comment gérer les commentaires de présentation avec Aspose.Slides for PHP via Java. Il présente les principaux types liés aux commentaires et montre comment ajouter des commentaires aux diapositives, accéder aux commentaires existants, travailler avec les réponses et les commentaires modernes, et supprimer des commentaires d’une présentation.

Les exemples couvrent des scénarios courants de révision et de collaboration dans PowerPoint, tels que l’attribution de commentaires aux auteurs, la lecture du texte et des métadonnées des commentaires, la construction de chaînes de réponses et la suppression de commentaires sélectionnés ou de tous les commentaires.

Dans PowerPoint, les commentaires apparaissent comme des annotations sur les diapositives. Sélectionner un commentaire affiche son texte et la discussion associée.

## **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez utiliser les commentaires pour fournir des retours et collaborer avec des collègues lors de la révision de présentations.

* La classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) qui donne accès aux auteurs de commentaires de la présentation.
* La classe [CommentCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/commentcollection/) qui représente les commentaires associés à un auteur individuel.
* La classe [Comment](https://reference.aspose.com/slides/fr/php-java/aspose.slides/comment/) qui fournit des informations sur un commentaire, notamment son auteur, sa date de création, sa position et son texte.
* La classe [CommentAuthor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/commentauthor/) qui fournit des informations sur un auteur, y compris son nom, ses initiales et les commentaires associés.

## **Ajouter des commentaires de diapositive**

L’exemple suivant montre comment ajouter des commentaires aux diapositives d’une présentation PowerPoint :

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($presentation->getLayoutSlides()->get_Item(0));
    $author = $presentation->getCommentAuthors()->addAuthor("Jawad", "MF");
    $position = new Point2DFloat(0.2, 0.2);
    $createdTime = new Java("java.util.Date");

    $author->getComments()->addComment("Hello Jawad, this is a slide comment", $firstSlide, $position, $createdTime);
    $author->getComments()->addComment("Hello Jawad, this is the second slide comment", $secondSlide, $position, $createdTime);

    $comments = $firstSlide->getSlideComments($author);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    if ($commentCount > 0) {
        $firstComment = $comments[0];
        echo java_values($firstComment->getText()) . PHP_EOL;

        $authorComments = $firstComment->getAuthor()->getComments();
        $commentText = $authorComments->get_Item(0)->getText();
        echo java_values($commentText) . PHP_EOL;
    }

    $presentation->save("Comments_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Accéder aux commentaires de diapositive**

L’exemple suivant montre comment accéder aux commentaires existants dans une présentation PowerPoint :

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Comments1.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        foreach ($author->getComments() as $comment) {
            echo "Slide: " . java_values($comment->getSlide()->getSlideNumber()) . PHP_EOL;
            echo "Comment: " . java_values($comment->getText()) . PHP_EOL;
            echo "Author: " . java_values($comment->getAuthor()->getName()) . PHP_EOL;
            echo "Posted at: " . java_values($comment->getCreatedTime()->toString()) . PHP_EOL;
            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Répondre aux commentaires**

Un commentaire parent est le commentaire original au sommet d’une hiérarchie de réponses. Les méthodes [Comment::getParentComment](https://reference.aspose.com/slides/fr/php-java/aspose.slides/comment/getparentcomment/) et [Comment::setParentComment](https://reference.aspose.com/slides/fr/php-java/aspose.slides/comment/setparentcomment/) vous permettent d’obtenir ou de définir le parent d’un commentaire.

L’exemple suivant montre comment ajouter des réponses et inspecter la hiérarchie de commentaires résultante :

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $position = new Point2DFloat(10, 10);
    $createdTime = new Java("java.util.Date");

    $author1 = $presentation->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment 1", $slide, $position, $createdTime);

    $author2 = $presentation->getCommentAuthors()->addAuthor("Author_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $slide, $position, $createdTime);
    $reply1->setParentComment($comment1);

    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $slide, $position, $createdTime);
    $reply2->setParentComment($comment1);

    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $slide, $position, $createdTime);
    $subReply->setParentComment($reply2);

    $author2->getComments()->addComment("comment 2", $slide, $position, $createdTime);
    $comment3 = $author2->getComments()->addComment("comment 3", $slide, $position, $createdTime);

    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $slide, $position, $createdTime);
    $reply3->setParentComment($comment3);

    $comments = $slide->getSlideComments(null);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    for ($i = 0; $i < $commentCount; $i++) {
        $comment = $comments[$i];
        while (!java_is_null($comment->getParentComment())) {
            echo "\t";
            $comment = $comment->getParentComment();
        }

        echo java_values($comments[$i]->getAuthor()->getName()) . ": " . java_values($comments[$i]->getText()) . PHP_EOL;
    }

    $presentation->save("parent_comment.pptx", SaveFormat::Pptx);

    $comment1->remove();
    $presentation->save("remove_comment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Lorsque la méthode [Comment::remove](https://reference.aspose.com/slides/fr/php-java/aspose.slides/comment/remove/) est utilisée pour supprimer un commentaire, toutes les réponses à ce commentaire sont également supprimées.
* Si [Comment::setParentComment](https://reference.aspose.com/slides/fr/php-java/aspose.slides/comment/setparentcomment/) crée une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxeditexception/) est levée.
{{% /alert %}}

## **Ajouter des commentaires modernes**

Les commentaires modernes peuvent être associés à la diapositive elle‑elle-même, à une forme spécifique ou à une plage de texte à l’intérieur d’une AutoShape. La méthode [CommentCollection::addModernComment](https://reference.aspose.com/slides/fr/php-java/aspose.slides/commentcollection/addmoderncomment/) accepte un argument [Shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/) en plus de la diapositive et des coordonnées du marqueur de commentaire.

Lorsque `null` est passé pour l’argument shape, le commentaire est un commentaire au niveau de la diapositive. Son marqueur est positionné selon les coordonnées fournies, mais il n’est associé à aucune forme particulière, donc [ModernComment::getShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncomment/getshape/) renvoie `null`. Lorsqu’une [Shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/) est fournie, le commentaire est ancré à cette forme. Les coordonnées définissent toujours la position du marqueur de commentaire sur la diapositive, tandis que l’association à la forme peut être récupérée via [ModernComment::getShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncomment/getshape/).

### **Ancrer un commentaire moderne à une forme**

L’exemple suivant crée à la fois un commentaire moderne au niveau de la diapositive et un commentaire moderne ancré à une AutoShape spécifique. Il lit ensuite la forme associée à chaque commentaire.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 300, 80);
    $shape->setName("Revenue title");
    $shape->getTextFrame()->setText("Quarterly revenue");

    $createdTime = new Java("java.util.Date");
    $slideCommentPosition = new Point2DFloat(20, 20);
    $shapeCommentPosition = new Point2DFloat(60, 60);
    $slideComment = $author->getComments()->addModernComment("Review the overall slide layout.", $slide, null, $slideCommentPosition, $createdTime);
    $shapeComment = $author->getComments()->addModernComment("Check this title.", $slide, $shape, $shapeCommentPosition, $createdTime);

    echo (java_is_null($slideComment->getShape()) ? "true" : "false") . PHP_EOL;
    echo java_values($shapeComment->getShape()->getName()) . PHP_EOL;

    $presentation->save("modern_comments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ancrer des commentaires à différents types de formes**

Tout objet de diapositive représenté par la classe [Shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/) peut être utilisé comme ancre de forme. Les exemples courants incluent les instances [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/fr/php-java/aspose.slides/connector/) et [GraphicalObject](https://reference.aspose.com/slides/fr/php-java/aspose.slides/graphicalobject/) telles que les graphiques.

L’exemple suivant crée plusieurs types de formes courants et associe un commentaire moderne à chacun d’eux.

```php
use aspose\slides\ChartType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $createdTime = new Java("java.util.Date");

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 180, 60);
    $autoShape->getTextFrame()->setText("AutoShape");
    $autoShapeCommentPosition = new Point2DFloat(30, 30);
    $author->getComments()->addModernComment("Comment on an AutoShape.", $slide, $autoShape, $autoShapeCommentPosition, $createdTime);

    $imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    $base64Class = new JavaClass("java.util.Base64");
    $imageData = $base64Class->getDecoder()->decode($imageBase64);
    $image = $presentation->getImages()->addImage($imageData);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 120, 80, $image);
    $pictureCommentPosition = new Point2DFloat(230, 30);
    $author->getComments()->addModernComment("Comment on a picture.", $slide, $pictureFrame, $pictureCommentPosition, $createdTime);

    $groupShape = $slide->getShapes()->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 80, 40);
    $groupShape->getShapes()->addAutoShape(ShapeType::Ellipse, 100, 0, 80, 40);
    $groupCommentPosition = new Point2DFloat(40, 150);
    $author->getComments()->addModernComment("Comment on a group.", $slide, $groupShape, $groupCommentPosition, $createdTime);

    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 220, 150, 140, 40);
    $connectorCommentPosition = new Point2DFloat(240, 150);
    $author->getComments()->addModernComment("Comment on a connector.", $slide, $connector, $connectorCommentPosition, $createdTime);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 400, 20, 250, 180);
    $chartCommentPosition = new Point2DFloat(420, 40);
    $author->getComments()->addModernComment("Comment on a graphical object.", $slide, $chart, $chartCommentPosition, $createdTime);

    $presentation->save("modern_comment_shape_types.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ancrer un commentaire à du texte et définir son statut**

Pour un commentaire moderne associé à une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/), les méthodes [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncomment/gettextselectionstart/) et [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncomment/settextselectionstart/) permettent d’obtenir la position de départ du texte sélectionné dans le cadre de texte de la forme. Les méthodes [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncomment/gettextselectionlength/) et [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncomment/settextselectionlength/) donnent la longueur de la sélection. Ensemble, ces valeurs associent le commentaire à une plage de texte spécifique à l’intérieur de l’AutoShape.

Les méthodes [ModernComment::getStatus](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncomment/getstatus/) et [ModernComment::setStatus](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncomment/setstatus/) accèdent à une valeur parmi les constantes [ModernCommentStatus](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncommentstatus/) :

- `NotDefined` — aucun statut de commentaire moderne spécifique n’est défini.
- `Active` — le commentaire est actif.
- `Resolved` — le commentaire a été résolu.
- `Closed` — le commentaire est fermé.

L’exemple suivant crée un commentaire moderne ancré à une forme, l’associe à une sélection de texte, le marque comme résolu, enregistre la présentation et vérifie les valeurs après avoir rouvert le fichier.

```php
use aspose\slides\ModernCommentStatus;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$outputFile = "modern_comment_text_anchor.pptx";
$shapeText = "Review the quarterly revenue forecast.";
$selectedText = "quarterly revenue";
$expectedSelectionStart = strpos($shapeText, $selectedText);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->setName("Forecast text");
    $shape->getTextFrame()->setText($shapeText);

    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $commentPosition = new Point2DFloat(60, 60);
    $comment = $author->getComments()->addModernComment("Verify this forecast wording.", $slide, $shape, $commentPosition, new Java("java.util.Date"));
    $comment->setTextSelectionStart($expectedSelectionStart);
    $comment->setTextSelectionLength(strlen($selectedText));
    $comment->setStatus(ModernCommentStatus::Resolved);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedComments = $reopenedSlide->getSlideComments(null);
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");

    foreach ($reopenedComments as $reopenedComment) {
        if (!java_instanceof($reopenedComment, $modernCommentClass)) {
            continue;
        }

        $shape = $reopenedComment->getShape();
        $shapeMatches = !java_is_null($shape) && java_values($shape->getName()) === "Forecast text";
        $selectionStartMatches = java_values($reopenedComment->getTextSelectionStart()) === $expectedSelectionStart;
        $selectionLengthMatches = java_values($reopenedComment->getTextSelectionLength()) === strlen($selectedText);
        $statusMatches = java_values($reopenedComment->getStatus()) === ModernCommentStatus::Resolved;

        echo "Shape anchor preserved: " . ($shapeMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection start preserved: " . ($selectionStartMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection length preserved: " . ($selectionLengthMatches ? "true" : "false") . PHP_EOL;
        echo "Resolved status preserved: " . ($statusMatches ? "true" : "false") . PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

### **Inspecter les commentaires modernes existants**

Pour inspecter une présentation existante, vérifiez si chaque commentaire est un [ModernComment](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncomment/), puis examinez [ModernComment::getShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncomment/gettextselectionlength/) et [ModernComment::getStatus](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncomment/getstatus/). Une forme `null` indique un commentaire au niveau de la diapositive. Pour une ancre [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/), les méthodes de sélection de texte identifient la plage associée dans le cadre de texte de la forme.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("comments.pptx");
try {
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    foreach ($presentation->getSlides() as $slide) {
        $comments = $slide->getSlideComments(null);
        foreach ($comments as $comment) {
            if (!java_instanceof($comment, $modernCommentClass)) {
                continue;
            }

            echo "Slide: " . java_values($slide->getSlideNumber()) . PHP_EOL;
            echo "Text: " . java_values($comment->getText()) . PHP_EOL;
            echo "Status: " . java_values($comment->getStatus()) . PHP_EOL;

            $shape = $comment->getShape();
            if (java_is_null($shape)) {
                echo "Anchor: slide level" . PHP_EOL;
            } else {
                echo "Anchor shape: " . java_values($shape->getName()) . PHP_EOL;
                echo "Anchor type: " . java_values($shape->getClass()->getSimpleName()) . PHP_EOL;

                if (java_instanceof($shape, $autoShapeClass)) {
                    echo "Text selection start: " . java_values($comment->getTextSelectionStart()) . PHP_EOL;
                    echo "Text selection length: " . java_values($comment->getTextSelectionLength()) . PHP_EOL;
                }
            }

            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Supprimer les commentaires**

### **Supprimer tous les commentaires et auteurs de commentaires**

L’exemple suivant montre comment supprimer tous les commentaires et tous les auteurs de commentaires d’une présentation :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("example.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        $author->getComments()->clear();
    }

    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Supprimer des commentaires spécifiques**

L’exemple suivant montre comment supprimer des commentaires spécifiques d’une diapositive :

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $createdTime = new Java("java.util.Date");

    $firstCommentPosition = new Point2DFloat(0.2, 0.2);
    $secondCommentPosition = new Point2DFloat(0.3, 0.2);
    $author->getComments()->addComment("comment 1", $slide, $firstCommentPosition, $createdTime);
    $author->getComments()->addComment("comment 2", $slide, $secondCommentPosition, $createdTime);

    foreach ($presentation->getCommentAuthors() as $commentAuthor) {
        $commentsToRemove = new Java("java.util.ArrayList");
        $comments = $slide->getSlideComments($commentAuthor);

        foreach ($comments as $comment) {
            if ($comment->getText()->equals("comment 1")) {
                $commentsToRemove->add($comment);
            }
        }

        foreach ($commentsToRemove as $comment) {
            $commentAuthor->getComments()->remove($comment);
        }
    }

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Aspose.Slides prend‑il en charge un statut résolu pour les commentaires modernes ?**

Oui. [ModernComment::getStatus](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncomment/getstatus/) et [ModernComment::setStatus](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncomment/setstatus/) accèdent à une valeur [ModernCommentStatus](https://reference.aspose.com/slides/fr/php-java/aspose.slides/moderncommentstatus/), y compris `Resolved`. Le statut est stocké dans la présentation et peut être relu après la réouverture du fichier.

**Les discussions en thread (chaînes de réponses) sont‑elles prises en charge, et y a‑t‑il une limite de profondeur ?**

Oui. Chaque commentaire peut référencer son [parent comment](https://reference.aspose.com/slides/fr/php-java/aspose.slides/comment/getparentcomment/), permettant les chaînes de réponses. L’API ne définit pas de limite spécifique de profondeur d’imbrication.

**Dans quel système de coordonnées la position du marqueur de commentaire est‑elle définie sur une diapositive ?**

La position du marqueur est définie par des coordonnées à virgule flottante dans le système de coordonnées de la diapositive, ce qui vous permet de le placer précisément sur la diapositive.