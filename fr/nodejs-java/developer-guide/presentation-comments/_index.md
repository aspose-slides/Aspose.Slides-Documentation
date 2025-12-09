---
title: Commentaires de présentation
type: docs
weight: 100
url: /fr/nodejs-java/presentation-comments/
keywords: "Commentaires, commentaires PowerPoint, présentation PowerPoint, Java, Aspose.Slides for Node.js via Java"
description: "Ajouter des commentaires et des réponses dans une présentation PowerPoint en JavaScript"
---

Dans PowerPoint, un commentaire apparaît comme une note ou une annotation sur une diapositive. Lorsqu'un commentaire est cliqué, son contenu ou ses messages sont révélés.

## **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez vouloir utiliser des commentaires pour fournir des retours ou communiquer avec vos collègues lors de la révision des présentations.

Pour vous permettre d'utiliser des commentaires dans les présentations PowerPoint, Aspose.Slides for Node.js via Java fournit

* La classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) qui contient les collections d'auteurs (à partir de la classe [CommentAuthorCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthorCollection)). Les auteurs ajoutent des commentaires aux diapositives.
* La classe [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection) qui contient la collection de commentaires pour chaque auteur.
* La classe [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) qui contient des informations sur les auteurs et leurs commentaires : qui a ajouté le commentaire, l'heure d'ajout, la position du commentaire, etc.
* La classe [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthor) qui contient des informations sur chaque auteur : le nom de l'auteur, ses initiales, les commentaires associés à son nom, etc.

## **Ajouter un commentaire à une diapositive**
Ce code JavaScript vous montre comment ajouter un commentaire à une diapositive dans une présentation PowerPoint :
```javascript
// Instancie la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Ajoute une diapositive vide
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // Ajoute un auteur
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // Définit la position des commentaires
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // Ajoute un commentaire de diapositive pour un auteur sur la diapositive 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // Ajoute un commentaire de diapositive pour un auteur sur la diapositive 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // Accède à ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // Lorsque null est passé en argument, les commentaires de tous les auteurs sont récupérés pour la diapositive sélectionnée
    var Comments = slide.getSlideComments(author);
    // Accède au commentaire à l'index 0 pour la diapositive 1
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // Sélectionne la collection de commentaires de l'auteur à l'index 0
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Accéder aux commentaires d’une diapositive**
Ce code JavaScript vous montre comment accéder à un commentaire existant sur une diapositive dans une présentation PowerPoint :
```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Répondre aux commentaires**
Un commentaire parent est le commentaire principal ou original dans une hiérarchie de commentaires ou de réponses. En utilisant les méthodes [getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#getParentComment--) ou [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (de la classe [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment)), vous pouvez définir ou obtenir un commentaire parent.

Ce code JavaScript vous montre comment ajouter des commentaires et obtenir leurs réponses :
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ajoute un commentaire
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // Ajoute une réponse au commentaire 1
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // Ajoute une autre réponse au commentaire 1
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // Ajoute une réponse à une réponse existante
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // Affiche la hiérarchie des commentaires dans la console
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // Supprime le commentaire 1 et toutes ses réponses
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" title="Attention" %}} 

* Lorsque la méthode [Remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#remove--) (de la classe [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment)) est utilisée pour supprimer un commentaire, les réponses au commentaire sont également supprimées.
* Si le paramètre [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) entraîne une référence circulaire, [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException) sera levée.

{{% /alert %}}

## **Ajouter un commentaire moderne**

En 2021, Microsoft a introduit les *commentaires modernes* dans PowerPoint. La fonctionnalité de commentaires modernes améliore considérablement la collaboration dans PowerPoint. Grâce aux commentaires modernes, les utilisateurs de PowerPoint peuvent résoudre des commentaires, ancrer des commentaires à des objets et du texte, et interagir beaucoup plus facilement qu'auparavant. 

Dans [Aspose.Slides for Node.js via Java 21.11](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-21-11-release-notes/), nous avons implémenté la prise en charge des commentaires modernes en ajoutant la classe [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ModernComment). Les méthodes [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) et [insertModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) ont été ajoutées à la classe [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection).

Ce code JavaScript vous montre comment ajouter un commentaire moderne à une diapositive dans une présentation PowerPoint :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Supprimer un commentaire**

### **Supprimer tous les commentaires et les auteurs**
Ce code JavaScript vous montre comment supprimer tous les commentaires et auteurs dans une présentation :
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Supprime tous les commentaires de la présentation
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // Supprime tous les auteurs
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


### **Supprimer des commentaires spécifiques**
Ce code JavaScript vous montre comment supprimer des commentaires spécifiques sur une diapositive :
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // ajouter des commentaires...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // supprimer tous les commentaires contenant le texte "comment 1"
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**Aspose.Slides prend‑t‑il en charge un statut tel que « résolu » pour les commentaires modernes ?**  
Oui. Les [commentaires modernes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/) exposent les méthodes [getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) et [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setStatus/) ; vous pouvez lire et définir l'[état d'un commentaire](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) (par exemple, le marquer comme résolu), et cet état est enregistré dans le fichier et reconnu par PowerPoint.

**Les discussions en fil (chaînes de réponses) sont‑elles prises en charge, et y a‑t‑il une limite de profondeur ?**  
Oui. Chaque commentaire peut référencer son [commentaire parent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/), ce qui permet des chaînes de réponses arbitraires. L’API ne déclare pas de limite de profondeur spécifique.

**Dans quel système de coordonnées la position d’un marqueur de commentaire est‑elle définie sur une diapositive ?**  
La position est stockée sous forme d’un point à virgule flottante dans le système de coordonnées de la diapositive. Cela vous permet de placer le marqueur de commentaire exactement où vous le souhaitez.