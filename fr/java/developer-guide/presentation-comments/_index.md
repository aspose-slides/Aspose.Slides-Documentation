---
title: Commentaires de Présentation
type: docs
weight: 100
url: /fr/java/presentation-comments/
keywords: "Commentaires, commentaires PowerPoint, présentation PowerPoint, Java, Aspose.Slides pour Java"
description: "Ajouter des commentaires et des réponses dans une présentation PowerPoint en Java"
---

Dans PowerPoint, un commentaire apparaît comme une note ou une annotation sur une diapositive. Lorsque vous cliquez sur un commentaire, son contenu ou ses messages sont révélés.

### **Pourquoi Ajouter des Commentaires aux Présentations ?**

Vous souhaiterez peut-être utiliser des commentaires pour fournir des retours ou communiquer avec vos collègues lors de la révision de présentations.

Pour vous permettre d'utiliser des commentaires dans les présentations PowerPoint, Aspose.Slides pour Java fournit

* La classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), qui contient les collections d'auteurs (à partir de l'interface [ICommentAuthorCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentAuthorCollection)). Les auteurs ajoutent des commentaires aux diapositives.
* L'interface [ICommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentCollection), qui contient la collection de commentaires pour des auteurs individuels.
* La classe [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment), qui contient des informations sur les auteurs et leurs commentaires : qui a ajouté le commentaire, le moment où le commentaire a été ajouté, la position du commentaire, etc.
* La classe [CommentAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/CommentAuthor), qui contient des informations sur des auteurs individuels : le nom de l'auteur, ses initiales, les commentaires associés au nom de l'auteur, etc.

## **Ajouter un Commentaire sur une Diapositive**
Ce code Java vous montre comment ajouter un commentaire à une diapositive dans une présentation PowerPoint :

```java
// Instancie la classe Presentation
Presentation pres = new Presentation();
try {
    // Ajoute une diapositive vide
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Ajoute un auteur
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Définit la position pour les commentaires
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Ajoute un commentaire de diapositive pour un auteur sur la diapositive 1
    author.getComments().addComment("Bonjour Jawad, ceci est un commentaire de diapositive", pres.getSlides().get_Item(0), point, new Date());

    // Ajoute un commentaire de diapositive pour un auteur sur la diapositive 2
    author.getComments().addComment("Bonjour Jawad, ceci est le deuxième commentaire de diapositive", pres.getSlides().get_Item(1), point, new Date());

    // Accède à la diapositive ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // Lorsque null est passé comme argument, les commentaires de tous les auteurs sont apportés à la diapositive sélectionnée
    IComment[] Comments = slide.getSlideComments(author);

    // Accède au commentaire à l'index 0 pour la diapositive 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Sélectionne la collection de commentaires de l'auteur à l'index 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accéder aux Commentaires de Diapositive**
Ce code Java vous montre comment accéder à un commentaire existant sur une diapositive dans une présentation PowerPoint :

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
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " a le commentaire : " + comment.getText() +
                    " de l'Auteur : " + comment.getAuthor().getName() + " posté à : " + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Répondre aux Commentaires**
Un commentaire parent est le commentaire principal ou original dans une hiérarchie de commentaires ou de réponses. En utilisant les méthodes [getParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#getParentComment--) ou [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (de l'interface [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment)), vous pouvez définir ou obtenir un commentaire parent.

Ce code Java vous montre comment ajouter des commentaires et obtenir des réponses à ceux-ci :

```java
Presentation pres = new Presentation();
try {
    // Ajoute un commentaire
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Auteur_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("commentaire1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Ajoute une réponse au commentaire1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Auteur_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("réponse 1 pour le commentaire 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Ajoute une autre réponse au commentaire1
    IComment reply2 = author2.getComments().addComment("réponse 2 pour le commentaire 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Ajoute une réponse à une réponse existante
    IComment subReply = author1.getComments().addComment("sous-réponse 3 pour la réponse 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("commentaire 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("commentaire 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("réponse 4 pour le commentaire 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
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

    // Supprime le commentaire1 et toutes les réponses à celui-ci
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 

* Lorsque la méthode [Remove](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#remove--) (de l'interface [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment)) est utilisée pour supprimer un commentaire, les réponses au commentaire sont également supprimées. 
* Si le paramètre [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) entraîne une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/PptxEditException) sera lancée.

{{% /alert %}}

## **Ajouter un Commentaire Moderne**

En 2021, Microsoft a introduit les *commentaires modernes* dans PowerPoint. La fonctionnalité des commentaires modernes améliore considérablement la collaboration dans PowerPoint. Grâce aux commentaires modernes, les utilisateurs de PowerPoint peuvent résoudre des commentaires, ancrer des commentaires à des objets et textes, et s'engager dans des interactions beaucoup plus facilement qu'auparavant.

Dans [Aspose Slides pour Java 21.11](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-11-release-notes/), nous avons mis en œuvre le support des commentaires modernes en ajoutant la classe [ModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/ModernComment). Les méthodes [addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) et [insertModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) ont été ajoutées à la classe [CommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection).

Ce code Java vous montre comment ajouter un commentaire moderne à une diapositive dans une présentation PowerPoint :

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("Ceci est un commentaire moderne", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Supprimer un Commentaire**

### **Supprimer Tous les Commentaires et Auteurs**

Ce code Java vous montre comment supprimer tous les commentaires et auteurs dans une présentation :

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

### **Supprimer des Commentaires Spécifiques**

Ce code Java vous montre comment supprimer des commentaires spécifiques sur une diapositive :

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ajouter des commentaires...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Auteur", "A");
    author.getComments().addComment("commentaire 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("commentaire 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // enlever tous les commentaires contenant le texte "commentaire 1"
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("commentaire 1"))
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