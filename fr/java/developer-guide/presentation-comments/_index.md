---
title: Gérer les commentaires de présentation en Java
linktitle: Commentaires de présentation
type: docs
weight: 100
url: /fr/java/presentation-comments/
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
- Java
- Aspose.Slides
description: "Gérez les commentaires de présentation avec Aspose.Slides for Java : ajoutez, lisez, modifiez, répondez et supprimez les commentaires dans les présentations PowerPoint rapidement et facilement."
---
## **Vue d'ensemble**

Cet article explique comment gérer les commentaires de présentation avec Aspose.Slides for Java. Il présente les principaux types liés aux commentaires et montre comment ajouter des commentaires aux diapositives, accéder aux commentaires existants, travailler avec les réponses et les commentaires modernes, et supprimer des commentaires d’une présentation.

Les exemples couvrent des scénarios courants de révision et de collaboration dans PowerPoint, tels que l’attribution de commentaires aux auteurs, la lecture du texte des commentaires et des métadonnées, la construction de chaînes de réponses, et la suppression de commentaires sélectionnés ou de tous les commentaires.

Dans PowerPoint, les commentaires apparaissent comme des annotations sur les diapositives. Sélectionner un commentaire affiche son texte et la discussion associée.

## **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez utiliser les commentaires pour fournir des retours et collaborer avec des collègues lors de la révision des présentations.

Aspose.Slides for Java fournit les API suivantes pour travailler avec les commentaires :

* La classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) qui donne accès aux auteurs de commentaires de la présentation.
* L’interface [ICommentCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icommentcollection/) qui représente les commentaires associés à un auteur individuel.
* L’interface [IComment](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icomment/) qui fournit des informations sur un commentaire, y compris son auteur, l’heure de création, la position et le texte.
* La classe [CommentAuthor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/commentauthor/) qui fournit des informations sur un auteur, y compris son nom, ses initiales et les commentaires associés.

## **Ajouter des commentaires aux diapositives**

L’exemple suivant montre comment ajouter des commentaires aux diapositives d’une présentation PowerPoint :

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    Point2D.Float position = new Point2D.Float(0.2f, 0.2f);
    Date createdTime = new Date();

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    IComment[] comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        IComment firstComment = comments[0];
        System.out.println(firstComment.getText());

        ICommentCollection authorComments = firstComment.getAuthor().getComments();
        String commentText = authorComments.get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Accéder aux commentaires des diapositives**

L’exemple suivant montre comment accéder aux commentaires existants dans une présentation PowerPoint :

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        for (IComment comment : author.getComments()) {
            System.out.println("Slide: " + comment.getSlide().getSlideNumber());
            System.out.println("Comment: " + comment.getText());
            System.out.println("Author: " + comment.getAuthor().getName());
            System.out.println("Posted at: " + comment.getCreatedTime());
            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Répondre aux commentaires**

Un commentaire parent est le commentaire original au sommet d’une hiérarchie de réponses. Les méthodes [IComment.getParentComment](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icomment/#getParentComment--) et [IComment.setParentComment](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) vous permettent d’obtenir ou de définir le parent d’un commentaire.

L’exemple suivant montre comment ajouter des réponses et examiner la hiérarchie de commentaires résultante :

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Point2D.Float position = new Point2D.Float(10, 10);
    Date createdTime = new Date();

    ICommentAuthor author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    IComment comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++) {
        IComment comment = comments[i];
        while (comment.getParentComment() != null) {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() + ": " + comments[i].getText());
    }

    presentation.save("parent_comment.pptx", SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Avertissement" %}}
* Lorsque la méthode [IComment.remove](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icomment/#remove--) est utilisée pour supprimer un commentaire, toutes les réponses à ce commentaire sont également supprimées.
* Si [IComment.setParentComment](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) crée une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pptxeditexception/) est levée.
{{% /alert %}}

## **Ajouter des commentaires modernes**

Les commentaires modernes peuvent être associés à la diapositive elle‑même, à une forme spécifique ou à une plage de texte à l’intérieur d’une AutoShape. La méthode [ICommentCollection.addModernComment](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) accepte un argument [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/) en plus de la diapositive et des coordonnées du marqueur de commentaire.

Lorsque `null` est passé pour l’argument de forme, le commentaire est un commentaire au niveau de la diapositive. Son marqueur est positionné à l’aide des coordonnées fournies, mais il n’est associé à aucune forme particulière, ainsi [IModernComment.getShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imoderncomment/#getShape--) renvoie `null`. Lorsqu’une [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/) est fournie, le commentaire est ancré à cette forme. Les coordonnées définissent toujours la position du marqueur de commentaire sur la diapositive, tandis que l’association à la forme peut être récupérée via [IModernComment.getShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imoderncomment/#getShape--).

### **Ancrer un commentaire moderne à une forme**

L’exemple suivant crée à la fois un commentaire moderne au niveau de la diapositive et un commentaire moderne ancré à une AutoShape spécifique. Il lit ensuite la forme associée à chaque commentaire.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    Point2D.Float slideCommentPosition = new Point2D.Float(20, 20);
    Point2D.Float shapeCommentPosition = new Point2D.Float(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ancrer des commentaires à différents types de formes**

Tout objet de diapositive implémentant [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/) peut être utilisé comme ancre de forme. Les exemples courants incluent les instances de [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iconnector/) et [IGraphicalObject](https://reference.aspose.com/slides/fr/java/com.aspose.slides/igraphicalobject/) telles que les graphiques.

L’exemple suivant crée plusieurs types de formes courants et associe un commentaire moderne à chacun d’eux.

```java
import com.aspose.slides.ChartType;
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IChart;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IConnector;
import com.aspose.slides.IGroupShape;
import com.aspose.slides.IPPImage;
import com.aspose.slides.IPictureFrame;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    Point2D.Float autoShapeCommentPosition = new Point2D.Float(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    Point2D.Float pictureCommentPosition = new Point2D.Float(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    Point2D.Float groupCommentPosition = new Point2D.Float(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    Point2D.Float connectorCommentPosition = new Point2D.Float(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    Point2D.Float chartCommentPosition = new Point2D.Float(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ancrer un commentaire à du texte et définir son statut**

Pour un commentaire moderne associé à une [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/), les méthodes [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) et [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) accèdent à la position de départ du texte sélectionné dans le cadre de texte de la forme. Les méthodes [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) et [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) accèdent à la longueur de la sélection. Ensemble, ces valeurs associent le commentaire à une plage de texte spécifique à l’intérieur de l’AutoShape.

Les méthodes [IModernComment.getStatus](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imoderncomment/#getStatus--) et [IModernComment.setStatus](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imoderncomment/#setStatus-byte--) accèdent à une valeur des constantes [ModernCommentStatus](https://reference.aspose.com/slides/fr/java/com.aspose.slides/moderncommentstatus/) :
- `NotDefined` — aucun statut de commentaire moderne spécifique n’est défini.
- `Active` — le commentaire est actif.
- `Resolved` — le commentaire a été résolu.
- `Closed` — le commentaire est fermé.

L’exemple suivant crée un commentaire moderne ancré à une forme, l’associe à une sélection de texte, le marque comme résolu, enregistre la présentation et vérifie les valeurs après réouverture du fichier.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.ModernCommentStatus;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Date;

String outputFile = "modern_comment_text_anchor.pptx";
String shapeText = "Review the quarterly revenue forecast.";
String selectedText = "quarterly revenue";
int expectedSelectionStart = shapeText.indexOf(selectedText);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Point2D.Float commentPosition = new Point2D.Float(60, 60);
    IModernComment comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, new Date());
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length());
    comment.setStatus(ModernCommentStatus.Resolved);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IComment[] reopenedComments = reopenedSlide.getSlideComments(null);

    for (IComment reopenedComment : reopenedComments) {
        if (!(reopenedComment instanceof IModernComment)) {
            continue;
        }

        IModernComment modernComment = (IModernComment) reopenedComment;
        boolean shapeMatches = modernComment.getShape() != null && "Forecast text".equals(modernComment.getShape().getName());
        boolean selectionStartMatches = modernComment.getTextSelectionStart() == expectedSelectionStart;
        boolean selectionLengthMatches = modernComment.getTextSelectionLength() == selectedText.length();
        boolean statusMatches = modernComment.getStatus() == ModernCommentStatus.Resolved;

        System.out.println("Shape anchor preserved: " + shapeMatches);
        System.out.println("Text selection start preserved: " + selectionStartMatches);
        System.out.println("Text selection length preserved: " + selectionLengthMatches);
        System.out.println("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Inspecter les commentaires modernes existants**

Pour inspecter une présentation existante, vérifiez quels commentaires implémentent [IModernComment](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imoderncomment/), puis examinez [IModernComment.getShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) et [IModernComment.getStatus](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imoderncomment/#getStatus--). Une forme `null` indique un commentaire au niveau de la diapositive. Pour une ancre [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/), les méthodes de sélection de texte identifient la plage associée dans le cadre de texte de la forme.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.IModernComment;
import com.aspose.slides.IShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("comments.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        IComment[] comments = slide.getSlideComments(null);
        for (IComment comment : comments) {
            if (!(comment instanceof IModernComment)) {
                continue;
            }

            IModernComment modernComment = (IModernComment) comment;
            System.out.println("Slide: " + slide.getSlideNumber());
            System.out.println("Text: " + modernComment.getText());
            System.out.println("Status: " + modernComment.getStatus());

            IShape shape = modernComment.getShape();
            if (shape == null) {
                System.out.println("Anchor: slide level");
            } else {
                System.out.println("Anchor shape: " + shape.getName());
                System.out.println("Anchor type: " + shape.getClass().getSimpleName());

                if (shape instanceof IAutoShape) {
                    System.out.println("Text selection start: " + modernComment.getTextSelectionStart());
                    System.out.println("Text selection length: " + modernComment.getTextSelectionLength());
                }
            }

            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Supprimer des commentaires**

### **Supprimer tous les commentaires et les auteurs de commentaires**

L’exemple suivant montre comment supprimer tous les commentaires et les auteurs de commentaires d’une présentation :

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("example.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        author.getComments().clear();
    }

    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Supprimer des commentaires spécifiques**

L’exemple suivant montre comment supprimer des commentaires spécifiques d’une diapositive :

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    Point2D.Float firstCommentPosition = new Point2D.Float(0.2f, 0.2f);
    Point2D.Float secondCommentPosition = new Point2D.Float(0.3f, 0.2f);
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors()) {
        List<IComment> commentsToRemove = new ArrayList<IComment>();
        IComment[] comments = slide.getSlideComments(commentAuthor);

        for (IComment comment : comments) {
            if ("comment 1".equals(comment.getText())) {
                commentsToRemove.add(comment);
            }
        }

        for (IComment comment : commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Aspose.Slides prend‑il en charge un statut résolu pour les commentaires modernes ?**

Oui. Les méthodes [IModernComment.getStatus](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imoderncomment/#getStatus--) et [IModernComment.setStatus](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imoderncomment/#setStatus-byte--) accèdent à une valeur de [ModernCommentStatus](https://reference.aspose.com/slides/fr/java/com.aspose.slides/moderncommentstatus/), y compris `Resolved`. Le statut est stocké dans la présentation et peut être lu à nouveau après la réouverture du fichier.

**Les discussions en fil (chaînes de réponses) sont‑elles prises en charge, et existe‑t‑il une limite de profondeur ?**

Oui. Chaque commentaire peut référencer son [parent comment](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icomment/#getParentComment--), ce qui permet des chaînes de réponses. L’API ne définit pas de limite spécifique de profondeur d’imbrication.

**Dans quel système de coordonnées la position du marqueur de commentaire est‑elle définie sur une diapositive ?**

La position du marqueur est définée par des coordonnées à virgule flottante dans le système de coordonnées de la diapositive, ce qui vous permet de le placer avec précision sur la diapositive.