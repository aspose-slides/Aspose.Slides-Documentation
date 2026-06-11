---
title: Komentarz
type: docs
weight: 230
url: /pl/nodejs-java/examples/elements/comment/
keywords:
- przykład kodu
- komentarz
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Pracuj z komentarzami slajdów w Aspose.Slides dla Node.js: dodawaj, odpowiadaj, edytuj, rozwiązuj i eksportuj komentarze w prezentacjach PPT, PPTX i ODP z przykładami kodu."
---
Ten artykuł demonstruje dodawanie, odczytywanie, usuwanie i odpowiadanie na nowoczesne komentarze przy użyciu **Aspose.Slides for Node.js via Java**.

## **Dodaj nowoczesny komentarz**

Utwórz komentarz napisany przez użytkownika i zapisz prezentację.

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

## **Uzyskaj dostęp do nowoczesnego komentarza**

Odczytaj nowoczesny komentarz z istniejącej prezentacji.

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

## **Usuń nowoczesny komentarz**

Usuń komentarz i zapisz zaktualizowany plik.

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

## **Odpowiedz na nowoczesny komentarz**

Dodaj odpowiedzi do nadrzędnego nowoczesnego komentarza.

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