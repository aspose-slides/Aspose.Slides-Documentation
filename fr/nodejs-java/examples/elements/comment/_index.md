---
title: Commentaire
type: docs
weight: 230
url: /fr/nodejs-java/examples/elements/comment/
keywords:
- exemple de code
- commentaire
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Travaillez avec les commentaires de diapositives dans Aspose.Slides pour Node.js: ajoutez, répondez, modifiez, résolvez et exportez les commentaires dans les présentations PPT, PPTX et ODP avec des exemples de code."
---
Cet article montre comment ajouter, lire, supprimer et répondre aux commentaires modernes à l'aide de **Aspose.Slides for Node.js via Java**.

## **Ajouter un commentaire moderne**

Créez un commentaire rédigé par un utilisateur et enregistrez la présentation.

```js
function addModernComment() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let author = presentation.getCommentAuthors().addAuthor("Jhon Smith", "JS");
        let position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100));
        let date = java.newInstanceSync("java.util.Date");

        author.getComments().addModernComment("This is a modern comment", slide, null, position, date);

        presentation.save("modern_comment.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à un commentaire moderne**

Lisez un commentaire moderne à partir d'une présentation existante.

```js
function accessModernComment() {
    let presentation = new aspose.slides.Presentation("modern_comment.pptx");
    try {
        let author = presentation.getCommentAuthors().get_Item(0);
        let comment = author.getComments().get_Item(0);
        
        console.log("Author: " + author.getName() + ", Comment: " + comment.getText());
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer un commentaire moderne**

Supprimez un commentaire et enregistrez le fichier mis à jour.

```js
function removeModernComment() {
    let presentation = new aspose.slides.Presentation("modern_comment.pptx");
    try {
        let author = presentation.getCommentAuthors().get_Item(0);

        let comment = author.getComments().get_Item(0);
        comment.remove();

        presentation.save("modern_comment_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Répondre à un commentaire moderne**

Ajoutez des réponses à un commentaire moderne parent.

```js
function replyToModernComment() {
    let presentation = new aspose.slides.Presentation("modern_comment.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let author = presentation.getCommentAuthors().get_Item(0);
        let comment = author.getComments().get_Item(0);

        let position1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(110), java.newFloat(100));
        let date1 = java.newInstanceSync("java.util.Date");
        let reply1 = author.getComments().addModernComment("Reply 1", slide, null, position1, date1);

        let position2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(120), java.newFloat(100));
        let date2 = java.newInstanceSync("java.util.Date");
        let reply2 = author.getComments().addModernComment("Reply 2", slide, null, position2, date2);

        reply1.setParentComment(comment);
        reply2.setParentComment(comment);

        presentation.save("modern_comment_replies.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```