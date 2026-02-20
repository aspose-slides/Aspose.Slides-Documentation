---
title: Commentaire
type: docs
weight: 230
url: /fr/php-java/examples/elements/comment/
keywords:
- commentaire
- commentaire moderne
- ajouter un commentaire
- accéder au commentaire
- supprimer le commentaire
- répondre au commentaire
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Gérez les commentaires de diapositives en PHP avec Aspose.Slides : ajoutez, lisez, répondez, modifiez, supprimez et travaillez avec des commentaires en fil de discussion pour PowerPoint et OpenDocument."
---
Démontre comment ajouter, lire, supprimer et répondre aux commentaires modernes en utilisant **Aspose.Slides for PHP via Java**.

## **Ajouter un commentaire moderne**

Créez un commentaire rédigé par un utilisateur et enregistrez la présentation.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Ajouter un commentaire moderne.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accéder à un commentaire moderne**

Lisez un commentaire moderne à partir d'une présentation existante.

```php
function accessModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);
        echo "Author: " . $author->getName() . ", Comment: " . $comment->getText() . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
}
```

## **Supprimer un commentaire moderne**

Supprimez un commentaire et enregistrez le fichier mis à jour.

```php
function removeModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);

        $comment->remove();

        $presentation->save("modern_comment_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Répondre à un commentaire moderne**

Ajoutez des réponses à un commentaire moderne parent.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Ajouter un auteur de commentaire.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Ajouter un commentaire parent et des réponses.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // Définir le commentaire parent pour les réponses.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // Enregistrer la présentation avec les réponses.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```