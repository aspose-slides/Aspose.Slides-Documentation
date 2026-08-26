---
title: Gérer les commentaires de présentation dans Node.js
linktitle: Commentaires de présentation
type: docs
weight: 100
url: /fr/nodejs-java/presentation-comments/
keywords:
- commentaire
- commentaire moderne
- commentaires PowerPoint
- commentaires de présentation
- commentaires de diapositive
- ajouter un commentaire
- accéder à un commentaire
- modifier un commentaire
- répondre à un commentaire
- supprimer un commentaire
- supprimer un commentaire
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Gérer les commentaires de présentation avec Aspose.Slides for Node.js via Java : ajouter, lire, modifier, répondre et supprimer les commentaires dans les présentations PowerPoint."
---
## **Vue d'ensemble**

Cet article explique comment gérer les commentaires de présentation avec Aspose.Slides for Node.js via Java. Il présente les principaux types liés aux commentaires et montre comment ajouter des commentaires aux diapositives, accéder aux commentaires existants, travailler avec les réponses et les commentaires modernes, et supprimer des commentaires d'une présentation.

Les exemples couvrent des scénarios courants de révision et de collaboration dans PowerPoint, tels que l'attribution de commentaires aux auteurs, la lecture du texte et des métadonnées des commentaires, la création de chaînes de réponses et la suppression de commentaires sélectionnés ou de tous les commentaires.

Dans PowerPoint, les commentaires apparaissent comme des annotations sur les diapositives. Sélectionner un commentaire affiche son texte et la discussion associée.

## **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez utiliser les commentaires pour fournir des retours et collaborer avec des collègues lors de la révision des présentations.

Aspose.Slides for Node.js via Java fournit les API suivantes pour travailler avec les commentaires :

* La classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) qui donne accès aux auteurs de commentaires de la présentation.
* La classe [CommentCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/commentcollection/) qui représente les commentaires associés à un auteur individuel.
* La classe [Comment](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/comment/) qui fournit des informations sur un commentaire, notamment son auteur, l'heure de création, la position et le texte.
* La classe [CommentAuthor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/commentauthor/) qui fournit des informations sur un auteur, notamment son nom, ses initiales et les commentaires associés.

## **Ajouter des commentaires aux diapositives**

L'exemple suivant montre comment ajouter des commentaires aux diapositives dans une présentation PowerPoint :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const authorComments = firstComment.getAuthor().getComments();
        const commentText = authorComments.get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Accéder aux commentaires des diapositives**

L'exemple suivant montre comment accéder aux commentaires existants dans une présentation PowerPoint :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Répondre aux commentaires**

Un commentaire parent est le commentaire original au sommet d'une hiérarchie de réponses. Les méthodes [Comment.getParentComment](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/comment/getparentcomment/) et [Comment.setParentComment](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/comment/setparentcomment/) vous permettent d'obtenir ou de définir le parent d'un commentaire.

L'exemple suivant montre comment ajouter des réponses et inspecter la hiérarchie de commentaires résultante :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    const author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    const reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    const subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    const comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    const reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Avertissement" %}}
* Lorsque la méthode [Comment.remove](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/comment/remove/) est utilisée pour supprimer un commentaire, toutes les réponses à ce commentaire sont également supprimées.
* Si [Comment.setParentComment](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/comment/setparentcomment/) crée une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxeditexception/) est levée.
{{% /alert %}}

## **Ajouter des commentaires modernes**

Les commentaires modernes peuvent être associés à la diapositive elle-même, à une forme spécifique ou à une plage de texte dans une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/). La méthode [CommentCollection.addModernComment](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) accepte un argument [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/) en plus de la diapositive et des coordonnées du marqueur de commentaire.

Lorsque `null` est passé pour l'argument shape, le commentaire est un commentaire au niveau de la diapositive. Son marqueur est positionné selon les coordonnées fournies, mais il n'est associé à aucune forme particulière, ainsi [ModernComment.getShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncomment/getshape/) renvoie `null`. Lorsqu'une [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/) est fournie, le commentaire est ancré à cette forme. Les coordonnées définissent toujours la position du marqueur de commentaire sur la diapositive, tandis que l'association à la forme peut être récupérée via [ModernComment.getShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Ancrer un commentaire moderne à une forme**

L'exemple suivant crée à la fois un commentaire moderne au niveau de la diapositive et un commentaire moderne ancré à une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) spécifique. Il lit ensuite la forme associée à chaque commentaire.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ancrer des commentaires à différents types de formes**

Tout objet de diapositive dérivé de [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/) peut être utilisé comme ancre de forme. Parmi les exemples courants figurent [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/connector/) et les instances de [GraphicalObject](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/graphicalobject/) telles que les graphiques.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ancrer un commentaire à du texte et définir son statut**

Pour un commentaire moderne associé à une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/), les méthodes [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) et [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) permettent d'accéder à la position de départ du texte sélectionné dans le cadre de texte de la forme. Les méthodes [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) et [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) donnent la longueur de la sélection. Ensemble, ces valeurs associent le commentaire à une plage de texte spécifique à l'intérieur de l'[AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/).

Les méthodes [ModernComment.getStatus](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncomment/getstatus/) et [ModernComment.setStatus](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncomment/setstatus/) accèdent à une valeur de l'énumération [ModernCommentStatus](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncommentstatus/) :

- `NotDefined` — aucun statut de commentaire moderne n'est défini.
- `Active` — le commentaire est actif.
- `Resolved` — le commentaire a été résolu.
- `Closed` — le commentaire est clôturé.

L'exemple suivant crée un commentaire moderne ancré à une forme, l'associe à une sélection de texte, le marque comme résolu, enregistre la présentation et vérifie les valeurs après réouverture du fichier.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(aspose.slides.ModernCommentStatus.Resolved);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Inspecter les commentaires modernes existants**

Pour examiner une présentation existante, vérifiez quels commentaires sont des instances de [ModernComment](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncomment/), puis examinez [ModernComment.getShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) et [ModernComment.getStatus](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncomment/getstatus/). Une forme `null` indique un commentaire au niveau de la diapositive. Pour une ancre [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/), les méthodes de sélection de texte identifient la plage associée dans le cadre de texte de la forme.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Supprimer des commentaires**

### **Supprimer tous les commentaires et les auteurs de commentaires**

L'exemple suivant montre comment supprimer tous les commentaires et les auteurs de commentaires d'une présentation :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Supprimer des commentaires spécifiques**

L'exemple suivant montre comment supprimer des commentaires spécifiques d'une diapositive :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Aspose.Slides prend‑il en charge un statut résolu pour les commentaires modernes ?**

Oui. Les méthodes [ModernComment.getStatus](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncomment/getstatus/) et [ModernComment.setStatus](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncomment/setstatus/) accèdent à une valeur de [ModernCommentStatus](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/moderncommentstatus/), y compris `Resolved`. Le statut est stocké dans la présentation et peut être relu après la réouverture du fichier.

**Les discussions en fil (chaînes de réponses) sont‑elles prises en charge, et existe‑t‑il une limite de profondeur ?**

Oui. Chaque commentaire peut référencer son [parent comment](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/comment/getparentcomment/), ce qui permet les chaînes de réponses. L'API ne définit pas de limite spécifique de profondeur d’imbrication.

**Dans quel système de coordonnées la position du marqueur de commentaire est‑elle définie sur une diapositive ?**

La position du marqueur est définie par des coordonnées à virgule flottante dans le système de coordonnées de la diapositive, ce qui vous permet de le placer précisément sur la diapositive.