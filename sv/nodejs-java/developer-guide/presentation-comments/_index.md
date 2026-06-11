---
title: Hantera presentationskommentarer i JavaScript
linktitle: Presentationskommentarer
type: docs
weight: 100
url: /sv/nodejs-java/presentation-comments/
keywords:
- kommentar
- modern kommentar
- PowerPoint-kommentarer
- presentationskommentarer
- bildkommentarer
- lägg till kommentar
- åtkomst till kommentar
- redigera kommentar
- svara på kommentar
- ta bort kommentar
- radera kommentar
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Behärska presentationskommentarer med Aspose.Slides för Node.js: lägg till, läs, redigera och radera kommentarer i PowerPoint‑filer med JavaScript snabbt och enkelt."
---
## **Översikt**

Den här artikeln förklarar hur man hanterar presentationskommentarer i Aspose.Slides. Den visar de viktigaste typerna relaterade till kommentarer och demonstrerar hur man lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar, använder moderna kommentarer och tar bort kommentarer från en presentation.

Exemplen fokuserar på vanliga gransknings- och samarbets scenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentarinnehåll och metadata, bygga svarskedjor och rensa alla kommentarer eller ta bort utvalda.

I PowerPoint visas en kommentar som en anteckning eller annotation på en bild. När en kommentar klickas visas dess innehåll eller meddelanden.

## **Varför lägga till kommentarer i presentationer?**

Du kanske vill använda kommentarer för att ge återkoppling eller kommunicera med dina kollegor när du granskar presentationer.

För att du ska kunna använda kommentarer i PowerPoint-presentationer tillhandahåller Aspose.Slides för Node.js via Java

* Klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som innehåller samlingar av författare (från klassen [CommentAuthorCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/CommentAuthorCollection)). Författarna lägger till kommentarer på bilder.
* Klassen [CommentCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/CommentCollection) som innehåller samlingen av kommentarer för enskilda författare.
* Klassen [Comment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Comment) som innehåller information om författare och deras kommentarer: vem som lade till kommentaren, tiden kommentaren lades till, kommentarens position osv.
* Klassen [CommentAuthor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/CommentAuthor) som innehåller information om enskilda författare: författarens namn, deras initialer, kommentarer kopplade till författarens namn osv.

## **Lägg till bildkommentar**

Denna JavaScript‑kod visar hur du lägger till en kommentar på en bild i en PowerPoint‑presentation:

```javascript
// Instansierar Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    // Lägger till en tom bild
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // Lägger till en författare
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // Ställer in positionen för kommentarer
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // Lägger till bildkommentar för en författare på bild 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // Lägger till bildkommentar för en författare på bild 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // Åtkomst till ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // När null skickas som argument hämtas kommentarer från alla författare till den valda bilden
    var Comments = slide.getSlideComments(author);
    // Åtkomst till kommentaren på index 0 för bild 1
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // Väljer författarens kommentarsamling på index 0
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Få åtkomst till bildkommentarer**

Denna JavaScript‑kod visar hur du får åtkomst till en befintlig kommentar på en bild i en PowerPoint‑presentation:

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

## **Svara på kommentarer**

En föräldrakommentar är den översta eller ursprungliga kommentaren i en hierarki av kommentarer eller svar. Genom att använda metoderna [getParentComment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Comment#getParentComment--) eller [setParentComment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (från klassen [Comment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Comment)), kan du sätta eller hämta en föräldrakommentar.

Denna JavaScript‑kod visar hur du lägger till kommentarer och får svar på dem:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Lägger till en kommentar
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // Lägger till ett svar på kommentar1
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // Lägger till ett annat svar på kommentar1
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // Lägger till ett svar på ett befintligt svar
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // Visar kommentarhierarkin i konsolen
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
    // Tar bort kommentar1 och alla svar på den
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Uppmärksamhet" %}} 

* När metoden [Remove](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Comment#remove--) (från klassen [Comment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Comment)) används för att ta bort en kommentar, tas svaren på kommentaren också bort.
* Om inställningen [setParentComment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) resulterar i en cirkulär referens, kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PptxEditException).

{{% /alert %}}

## **Lägg till modern kommentar**

År 2021 introducerade Microsoft *moderna kommentarer* i PowerPoint. Funktionen för moderna kommentarer förbättrar samarbetet i PowerPoint avsevärt. Genom moderna kommentarer kan PowerPoint‑användare lösa kommentarer, fästa kommentarer vid objekt och texter samt interagera mycket enklare än tidigare.

Aspose.Slides stödjer moderna kommentarer via klassen [ModernComment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ModernComment). Metoderna [addModernComment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) och [insertModernComment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) har lagts till i klassen [CommentCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/CommentCollection).

Denna JavaScript‑kod visar hur du lägger till en modern kommentar på en bild i en PowerPoint‑presentation:

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

## **Ta bort kommentar**

### **Ta bort alla kommentarer och författare**

Denna JavaScript‑kod visar hur du tar bort alla kommentarer och författare i en presentation:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Raderar alla kommentarer från presentationen
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // Raderar alla författare
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Ta bort specifika kommentarer**

Denna JavaScript‑kod visar hur du tar bort specifika kommentarer på en bild:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // lägg till kommentarer...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // ta bort alla kommentarer som innehåller texten "comment 1"
    
    
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

**Stöder Aspose.Slides en status som 'lösta' för moderna kommentarer?**

Ja. [Moderna kommentarer](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/) exponerar metoderna [getStatus](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/getstatus/) och [setStatus](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/setStatus/); du kan läsa och sätta en [kommentarsstatus](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncommentstatus/) (till exempel markera den som löst), och detta tillstånd sparas i filen och känns igen av PowerPoint.

**Stöds trådade diskussioner (svarskedjor) och finns det någon begränsning för nästlingsdjupet?**

Ja. Varje kommentar kan referera till sin [föräldrakommentar](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/comment/getparentcomment/), vilket möjliggör godtyckliga svarskedjor. API:et deklarerar ingen specifik gräns för nästlingsdjupet.

**I vilket koordinatsystem definieras en kommentarmärkares position på en bild?**

Positionen lagras som en flyttalspunkt i bildens koordinatsystem. Detta låter dig placera kommentarmärket exakt där du behöver det.