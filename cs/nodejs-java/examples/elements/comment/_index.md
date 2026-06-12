---
title: Komentář
type: docs
weight: 230
url: /cs/nodejs-java/examples/elements/comment/
keywords:
- příklad kódu
- komentář
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Pracujte s komentáři snímků v Aspose.Slides pro Node.js: přidávejte, odpovídejte, upravujte, řešte a exportujte komentáře v prezentacích PPT, PPTX a ODP s ukázkovým kódem."
---
Tento článek demonstruje přidávání, čtení, odstraňování a odpovídání na moderní komentáře pomocí **Aspose.Slides for Node.js via Java**.

## **Přidání moderního komentáře**

Vytvořte komentář vytvořený uživatelem a uložte prezentaci.

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

## **Přístup k modernímu komentáři**

Přečtěte moderní komentář z existující prezentace.

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

## **Odstranění moderního komentáře**

Odstraňte komentář a uložte aktualizovaný soubor.

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

## **Odpověď na moderní komentář**

Přidejte odpovědi k nadřazenému modernímu komentáři.

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