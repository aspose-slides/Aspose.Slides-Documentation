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
- ajouter commentaire
- accéder commentaire
- modifier commentaire
- répondre commentaire
- supprimer commentaire
- effacer commentaire
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Maîtrisez les commentaires de présentation avec Aspose.Slides pour PHP via Java : ajoutez, lisez, modifiez et supprimez les commentaires dans les fichiers PowerPoint rapidement et facilement."
---

Dans PowerPoint, un commentaire apparaît comme une note ou une annotation sur une diapositive. Lorsqu’un commentaire est cliqué, son contenu ou ses messages sont révélés. 

## **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez vouloir utiliser les commentaires pour fournir des retours ou communiquer avec vos collègues lors de la révision des présentations.

Pour vous permettre d’utiliser les commentaires dans les présentations PowerPoint, Aspose.Slides for PHP via Java fournit

* La classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), qui contient les collections d’auteurs (à partir de l’interface [ICommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentAuthorCollection)). Les auteurs ajoutent des commentaires aux diapositives.
* L’interface [ICommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentCollection), qui contient la collection de commentaires pour chaque auteur.
* La classe [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment), qui contient des informations sur les auteurs et leurs commentaires : qui a ajouté le commentaire, l’heure à laquelle le commentaire a été ajouté, la position du commentaire, etc.
* La classe [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/CommentAuthor), qui contient des informations sur chaque auteur : le nom de l’auteur, ses initiales, les commentaires associés au nom de l’auteur, etc.

## **Ajouter des commentaires à la diapositive**
Ce code PHP montre comment ajouter un commentaire à une diapositive dans une présentation PowerPoint :
```php
  # Instancie la classe Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Ajoute une diapositive vide
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Ajoute un auteur
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Définit la position des commentaires
    $point = new Point2DFloat(0.2, 0.2);
    # Ajoute un commentaire de diapositive pour un auteur sur la diapositive 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Ajoute un commentaire de diapositive pour un auteur sur la diapositive 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Accède à ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # Lorsque null est passé comme argument, les commentaires de tous les auteurs sont récupérés pour la diapositive sélectionnée
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


## **Accéder aux commentaires de la diapositive**
Ce code PHP montre comment accéder à un commentaire existant sur une diapositive dans une présentation PowerPoint :
```php
  # Instancie la classe Presentation
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " has comment: " . $comment->getText() . " with Author: " . $comment->getAuthor()->getName() . " posted on time :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Répondre aux commentaires**

Un commentaire parent est le commentaire principal ou d’origine dans une hiérarchie de commentaires ou de réponses. En utilisant les méthodes [getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#getParentComment--) ou [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (de l’interface [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)), vous pouvez définir ou obtenir un commentaire parent.

Ce code PHP montre comment ajouter des commentaires et récupérer leurs réponses :
```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Ajoute un commentaire
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Ajoute une réponse au comment1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Ajoute une autre réponse au comment1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Ajoute une réponse à une réponse existante
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Affiche la hiérarchie des commentaires dans la console
    $slide = $pres->getSlides()->get_Item(0);
    $comments = $slide->getSlideComments(null);
    for($i = 0; $i < java_values($Array->getLength($comments)) ; $i++) {
      $comment = $comments[$i];
      while (!java_is_null($comment->getParentComment())) {
        System->out->print("\t");
        $comment = $comment->getParentComment();
      } 
      echo($comments[$i]->getAuthor()->getName() . " : " . $comments[$i]->getText());
      echo();
    }
    $pres->save("parent_comment.pptx", SaveFormat::Pptx);
    # Supprime le comment1 et toutes ses réponses
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" title="Attention" %}} 

* Lorsque la méthode [Remove](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#remove--) (de l’interface [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)) est utilisée pour supprimer un commentaire, les réponses au commentaire sont également supprimées.
* Si le paramètre [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) entraîne une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException) sera levée.

{{% /alert %}}

## **Ajouter des commentaires modernes**

En 2021, Microsoft a introduit les *commentaires modernes* dans PowerPoint. La fonctionnalité de commentaires modernes améliore considérablement la collaboration dans PowerPoint. Grâce aux commentaires modernes, les utilisateurs de PowerPoint peuvent résoudre les commentaires, ancrer les commentaires à des objets et du texte, et interagir beaucoup plus facilement qu’auparavant. 

Dans [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-11-release-notes/), nous avons implémenté la prise en charge des commentaires modernes en ajoutant la classe [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/ModernComment). Les méthodes [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) et [insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) ont été ajoutées à la classe [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection).

Ce code PHP montre comment ajouter un commentaire moderne à une diapositive dans une présentation PowerPoint :
```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Some Author", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("This is a modern comment", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Supprimer les commentaires**

### **Supprimer tous les commentaires et auteurs**
Ce code PHP montre comment supprimer tous les commentaires et auteurs dans une présentation :
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
Ce code PHP montre comment supprimer des commentaires spécifiques sur une diapositive :
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # ajoute des commentaires...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # supprime tous les commentaires contenant le texte "comment 1"
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("comment 1")) {
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


## **FAQ**

**Aspose.Slides prend‑t‑il en charge un statut comme « résolu » pour les commentaires modernes ?**

Oui. Les [commentaires modernes](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) exposent une méthode [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) ; vous pouvez définir l’état d’un commentaire (par exemple, le marquer comme résolu), et cet état est enregistré dans le fichier et reconnu par PowerPoint.

**Les discussions en fil (chaînes de réponses) sont‑elles prises en charge, et existe‑t‑il une limite de profondeur ?**

Oui. Chaque commentaire peut référencer son [commentaire parent](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/), permettant des chaînes de réponses arbitraires. L’API ne spécifie pas de limite précise à la profondeur d’imbrication.

**Dans quel système de coordonnées la position d’un marqueur de commentaire est‑elle définie sur une diapositive ?**

La position est enregistrée sous forme de point à virgule flottante dans le système de coordonnées de la diapositive. Cela vous permet de placer le marqueur de commentaire exactement où vous le souhaitez.