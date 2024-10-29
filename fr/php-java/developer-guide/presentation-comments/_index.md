---
title: Commentaires de présentation
type: docs
weight: 100
url: /fr/php-java/presentation-comments/
keywords: "Commentaires, commentaires PowerPoint, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Ajouter des commentaires et des réponses dans une présentation PowerPoint"
---

Dans PowerPoint, un commentaire apparaît comme une note ou une annotation sur une diapositive. Lorsque vous cliquez sur un commentaire, son contenu ou ses messages sont révélés.

### **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez utiliser des commentaires pour fournir des retours ou communiquer avec vos collègues lors de la révision de présentations.

Pour vous permettre d'utiliser des commentaires dans les présentations PowerPoint, Aspose.Slides pour PHP via Java fournit

* La classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), qui contient les collections d'auteurs (de l'interface [ICommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentAuthorCollection)). Les auteurs ajoutent des commentaires aux diapositives.
* L'interface [ICommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentCollection), qui contient la collection de commentaires pour des auteurs individuels.
* La classe [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment), qui contient des informations sur les auteurs et leurs commentaires : qui a ajouté le commentaire, le moment où le commentaire a été ajouté, la position du commentaire, etc.
* La classe [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/CommentAuthor), qui contient des informations sur des auteurs individuels : le nom de l'auteur, ses initiales, les commentaires associés au nom de l'auteur, etc.

## **Ajouter un commentaire de diapositive**
Ce code PHP vous montre comment ajouter un commentaire à une diapositive dans une présentation PowerPoint :

```php
  # Instancie la classe Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Ajoute une diapositive vide
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Ajoute un auteur
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Définit la position pour les commentaires
    $point = new Point2DFloat(0.2, 0.2);
    # Ajoute un commentaire de diapositive pour un auteur sur la diapositive 1
    $author->getComments()->addComment("Bonjour Jawad, ceci est un commentaire de diapositive", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Ajoute un commentaire de diapositive pour un auteur sur la diapositive 2
    $author->getComments()->addComment("Bonjour Jawad, ceci est le deuxième commentaire de diapositive", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Accède à la diapositive 1
    $slide = $pres->getSlides()->get_Item(0);
    # Lorsque null est passé en argument, les commentaires de tous les auteurs sont récupérés pour la diapositive sélectionnée
    $Comments = $slide->getSlideComments($author);
    # Accède au commentaire à l'index 0 pour la diapositive 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Sélectionne la collection de commentaires de l'auteur à l'index 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Accéder aux commentaires de diapositive**
Ce code PHP vous montre comment accéder à un commentaire existant sur une diapositive dans une présentation PowerPoint :

```php
  # Instancie la classe Presentation
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " a le commentaire : " . $comment->getText() . " avec l'auteur : " . $comment->getAuthor()->getName() . " publié à l'heure :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Répondre aux commentaires**
Un commentaire parent est le commentaire principal ou original dans une hiérarchie de commentaires ou de réponses. En utilisant les méthodes [getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#getParentComment--) ou [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (de l'interface [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)), vous pouvez définir ou obtenir un commentaire parent.

Ce code PHP vous montre comment ajouter des commentaires et obtenir des réponses à ceux-ci :

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Ajoute un commentaire
    $author1 = $pres->getCommentAuthors()->addAuthor("Auteur_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("commentaire1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Ajoute une réponse au commentaire1
    $author2 = $pres->getCommentAuthors()->addAuthor("Auteur_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("réponse 1 pour commentaire 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Ajoute une autre réponse au commentaire1
    $reply2 = $author2->getComments()->addComment("réponse 2 pour commentaire 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Ajoute une réponse à une réponse existante
    $subReply = $author1->getComments()->addComment("sous-réponse 3 pour réponse 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("commentaire 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("commentaire 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("réponse 4 pour commentaire 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Affiche la hiérarchie des commentaires dans la console
    $slide = $pres->getSlides()->get_Item(0);
    $comments = $slide->getSlideComments(null);
    for($i = 0; $i < java_values($Array->getLength($comments)); $i++) {
      $comment = $comments[$i];
      while (!java_is_null($comment->getParentComment())) {
        System->out->print("\t");
        $comment = $comment->getParentComment();
      } 
      echo($comments[$i]->getAuthor()->getName() . " : " . $comments[$i]->getText());
      echo();
    }
    $pres->save("parent_comment.pptx", SaveFormat::Pptx);
    # Supprime le commentaire1 et toutes les réponses à celui-ci
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Attention" %}} 

* Lorsque la méthode [Remove](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#remove--) (de l'interface [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)) est utilisée pour supprimer un commentaire, les réponses au commentaire sont également supprimées.
* Si le paramètre [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) entraîne une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException) sera levée.

{{% /alert %}}

## **Ajouter un commentaire moderne**

En 2021, Microsoft a introduit des *commentaires modernes* dans PowerPoint. La fonctionnalité des commentaires modernes améliore considérablement la collaboration dans PowerPoint. Grâce aux commentaires modernes, les utilisateurs de PowerPoint peuvent résoudre des commentaires, ancrer des commentaires à des objets et des textes, et interagir beaucoup plus facilement qu'auparavant.

Dans [Aspose Slides pour Java 21.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-11-release-notes/), nous avons mis en œuvre le support des commentaires modernes en ajoutant la classe [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/ModernComment). Les méthodes [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) et [insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) ont été ajoutées à la classe [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection).

Ce code PHP vous montre comment ajouter un commentaire moderne à une diapositive dans une présentation PowerPoint :

```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Certains Auteur", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("Ceci est un commentaire moderne", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Supprimer un commentaire**

### **Supprimer tous les commentaires et auteurs**

Ce code PHP vous montre comment supprimer tous les commentaires et auteurs dans une présentation :

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Supprime tous les commentaires de la présentation
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Supprime tous les auteurs
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Supprimer des commentaires spécifiques**

Ce code PHP vous montre comment supprimer des commentaires spécifiques sur une diapositive :

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # ajouter des commentaires...
    $author = $presentation->getCommentAuthors()->addAuthor("Auteur", "A");
    $author->getComments()->addComment("commentaire 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("commentaire 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # supprime tous les commentaires contenant le texte "commentaire 1"
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("commentaire 1")) {
          $toRemove->add($comment);
        }
      }
      foreach($toRemove as $comment) {
        $commentAuthor->getComments()->remove($comment);
      }
    }
    $presentation->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```