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
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Gérez les commentaires de présentation avec Aspose.Slides for Java : ajouter, lire, modifier et supprimer les commentaires dans les fichiers PowerPoint rapidement et facilement."
---

Dans PowerPoint, un commentaire apparaît comme une note ou une annotation sur une diapositive. Lorsqu'un commentaire est cliqué, son contenu ou ses messages sont révélés. 

## **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez souhaiter utiliser les commentaires pour fournir des retours ou communiquer avec vos collègues lors de la révision des présentations.

Pour vous permettre d’utiliser les commentaires dans les présentations PowerPoint, Aspose.Slides for Java fournit :

* La classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) qui contient les collections d’auteurs (à partir de l’interface [ICommentAuthorCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentAuthorCollection)). Les auteurs ajoutent des commentaires aux diapositives. 
* L’interface [ICommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentCollection) qui contient la collection de commentaires pour chaque auteur. 
* La classe [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment) qui contient les informations sur les auteurs et leurs commentaires : qui a ajouté le commentaire, l’heure à laquelle le commentaire a été ajouté, la position du commentaire, etc. 
* La classe [CommentAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/CommentAuthor) qui contient les informations sur chaque auteur : le nom de l’auteur, ses initiales, les commentaires associés au nom de l’auteur, etc. 

## **Ajouter des commentaires à une diapositive**
Ce code Java montre comment ajouter un commentaire à une diapositive dans une présentation PowerPoint :
```java
// Instancie la classe Presentation
Presentation pres = new Presentation();
try {
    // Ajoute une diapositive vide
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Ajoute un auteur
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Définit la position des commentaires
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Ajoute un commentaire de diapositive pour un auteur sur la diapositive 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Ajoute un commentaire de diapositive pour un auteur sur la diapositive 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Accède à ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // Lorsque null est passé en argument, les commentaires de tous les auteurs sont récupérés pour la diapositive sélectionnée
    IComment[] Comments = slide.getSlideComments(author);

    // Accède au commentaire à l'index 0 pour la diapositive 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Sélectionne la collection de commentaires de l'Auteur à l'index 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Accéder aux commentaires de diapositive**
Ce code Java montre comment accéder à un commentaire existant sur une diapositive dans une présentation PowerPoint :
```java
// Instancie la classe Presentation
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Répondre aux commentaires**
Un commentaire parent est le commentaire principal ou original dans une hiérarchie de commentaires ou de réponses. En utilisant les méthodes [getParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#getParentComment--) ou [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (de l’interface [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment)), vous pouvez définir ou obtenir un commentaire parent. 

Ce code Java montre comment ajouter des commentaires et obtenir leurs réponses :
```java
Presentation pres = new Presentation();
try {
    // Ajoute un commentaire
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Ajoute une réponse au commentaire 1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Ajoute une autre réponse au commentaire 1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Ajoute une réponse à une réponse existante
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Affiche la hiérarchie des commentaires dans la console
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // Supprime le commentaire 1 et toutes ses réponses
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" title="Attention" %}} 

* Lorsque la méthode [Remove](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#remove--) (de l’interface [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment)) est utilisée pour supprimer un commentaire, les réponses au commentaire sont également supprimées. 
* Si le paramètre [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) entraîne une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/PptxEditException) sera levée.

{{% /alert %}}

## **Ajouter des commentaires modernes**

En 2021, Microsoft a introduit les *commentaires modernes* dans PowerPoint. Cette fonctionnalité améliore considérablement la collaboration dans PowerPoint. Grâce aux commentaires modernes, les utilisateurs de PowerPoint peuvent résoudre des commentaires, ancrer les commentaires à des objets et des textes, et interagir beaucoup plus facilement qu’auparavant. 

Dans [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-11-release-notes/), nous avons implémenté la prise en charge des commentaires modernes en ajoutant la classe [ModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/ModernComment). Les méthodes [addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) et [insertModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) ont été ajoutées à la classe [CommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection). 

Ce code Java montre comment ajouter un commentaire moderne à une diapositive dans une présentation PowerPoint :
```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Supprimer les commentaires**

### **Supprimer tous les commentaires et auteurs**
Ce code Java montre comment supprimer tous les commentaires et auteurs d'une présentation :
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Supprime tous les commentaires de la présentation
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Supprime tous les auteurs
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


### **Supprimer des commentaires spécifiques**
Ce code Java montre comment supprimer des commentaires spécifiques sur une diapositive :
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ajoute des commentaires...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // supprime tous les commentaires contenant le texte "comment 1"
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**Aspose.Slides prend‑t‑il en charge un statut tel que « résolu » pour les commentaires modernes ?**  
Oui. Les [commentaires modernes](https://reference.aspose.com/slides/java/com.aspose.slides/moderncomment/) exposent une méthode [setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/moderncomment/#setStatus-byte-). Vous pouvez définir l'« état » d'un commentaire (par exemple, le marquer comme résolu), et cet état est enregistré dans le fichier et reconnu par PowerPoint.

**Les discussions en fil (chaînes de réponses) sont‑elles prises en charge, et existe‑t‑il une limite de profondeur ?**  
Oui. Chaque commentaire peut référencer son [parent comment](https://reference.aspose.com/slides/java/com.aspose.slides/comment/#getParentComment--), ce qui permet des chaînes de réponses arbitraires. L'API ne déclare aucune limite spécifique de profondeur d’imbrication.

**Dans quel système de coordonnées la position d’un marqueur de commentaire est‑elle définie sur une diapositive ?**  
La position est stockée sous forme de point à virgule flottante dans le système de coordonnées de la diapositive. Cela vous permet de placer le marqueur de commentaire précisément à l’endroit souhaité.