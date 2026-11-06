---
title: Hantera presentationskommentarer i Node.js
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
- åtkomst kommentar
- redigera kommentar
- svara på kommentar
- ta bort kommentar
- radera kommentar
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera presentationskommentarer med Aspose.Slides för Node.js via Java: lägg till, läs, redigera, svara på och ta bort kommentarer i PowerPoint-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur du hanterar presentationskommentarer med Aspose.Slides för Node.js via Java. Den introducerar de viktigaste kommentarrelaterade typerna och visar hur du lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar och moderna kommentarer samt tar bort kommentarer från en presentation.

Exemplen täcker vanliga gransknings- och samarbetscenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentartext och metadata, bygga svarskedjor och ta bort markerade kommentarer eller alla kommentarer.

I PowerPoint visas kommentarer som anteckningar på bilder. När du markerar en kommentar visas dess text och relaterade diskussion.

För att begära att kommentarer visas eller döljs när en presentation öppnas utan att ändra själva kommentarerna, se [Visa eller dölja kommentarer när en presentation öppnas](/slides/sv/nodejs-java/presentation-view-properties/).

## **Varför lägga till kommentarer i presentationer?**

Du kan använda kommentarer för att ge återkoppling och samarbeta med kollegor när du granskar presentationer.

Aspose.Slides för Node.js via Java tillhandahåller följande API:er för att arbeta med kommentarer:

* Klassen [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ger åtkomst till presentationens kommentar‑författare.
* Klassen [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) representerar kommentarer som är associerade med en enskild författare.
* Klassen [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) ger information om en kommentar, inklusive dess författare, skapningstid, position och text.
* Klassen [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) ger information om en författare, inklusive namn, initialer och associerade kommentarer.

## **Lägg till bildkommentarer**

Exemplet skapar två bilder och registrerar en kommentar‑författare med [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/). Det använder [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) för att placera en kommentar på varje bild, och hämtar sedan den första bildens kommentarer för den författaren med [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/). Konsolen visar den första kommentarens text två gånger, vilket demonstrerar åtkomst via både bilden och författaren, och den sparade presentationen innehåller båda kommentarerna.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));

    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hitta eller skapa en kommentar‑författare**

När en automatiserad granskning bearbetar samma presentation upprepade gånger, sök i samlingen som returneras av [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) innan du lägger till en författare. [findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) matchar både namn och initialer och returnerar en array med matchande författare, eller en tom array om inga matchningar finns. I kontrast söker [findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) enbart efter namn, oavsett initialer. Att anropa [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) med ett namn och initialer som redan finns i samlingen kastar ett undantag.

Exemplet kräver en presentationsfil med minst en bild. På var och en av två genomgångar återanvänder det den första matchande författaren, eller skapar en endast när resultatet är tomt. Om det finns flera matchningar väljs det första array‑elementet utan att slå ihop eller ta bort de andra författarna. Därefter anropas [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) för den valda författaren och presentationen sparas. Den andra genomgången öppnar resultatet från den första genomgången och upprepar operationen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const authorName = "Reviewer";
const authorInitials = "RV";

let inputFile = "input.pptx";
const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));

for (let pass = 1; pass <= 2; pass++) {
    const presentation = new aspose.slides.Presentation(inputFile);
    try {
        const matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        const author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        const createdTime = java.newInstanceSync("java.util.Date");
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, createdTime);

        const outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

Den andra genomgången lägger till en ytterligare kommentar utan att lägga till en ny författare eller ta bort befintliga kommentarer. Slutfilen, `review_pass_2.pptx`, innehåller båda de nya kommentarerna tillsammans med eventuella ursprungliga kommentarer. Att återanvända en författare deduplicerar inte kommentarer: för att undvika att upprepade gånger lägga till samma kommentar, implementera en separat dubblett‑detektering innan du lägger till den.

## **Få åtkomst till bildkommentarer**

Exemplet öppnar en befintlig presentation och läser samlingen som returneras av [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/). För varje författare itererar det genom samlingen som returneras av [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/) och skriver ut bildnummer, kommentartext, författarnamn och skapningstid. Inmatningspresentationen måste innehålla kommentarer för att producera konsolutdata.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Svara på kommentarer**

En föräldrakommentar är den ursprungliga kommentaren högst upp i en svarshierarki. Metoderna [Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) och [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) låter dig hämta eller sätta föräldern för en kommentar.

Exemplet skapar kommentarer från två författare och använder [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) för att bygga svar, inklusive ett svar på ett annat svar. Att skicka `null` till [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) hämtar kommentarer från alla författare; konsolen indenterar varje post enligt dess djup i svarshierarkin. Exemplet sparar hela diskussionen, anropar [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) på den första rotkommentaren och sparar en andra presentation med den kommentaren och dess svar borttagna.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    const reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    const secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    const subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    const separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    const separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    rootComment.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* När metoden [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) används för att radera en kommentar, tas alla svar på den kommentaren också bort.
* Om [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) skapar en cirkulär referens, kastas ett [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Lägg till moderna kommentarer**

Moderna kommentarer kan associeras med själva bilden, med en specifik form eller med ett textintervall i en AutoShape. Metoden [CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) accepterar ett [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)‑argument utöver bilden och kommentar‑markörens koordinater.

När `null` skickas för shape‑argumentet blir kommentaren en bildnivå‑kommentar. Dess markör placeras enligt de angivna koordinaterna, men den är inte associerad med någon specifik form, så [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) returnerar `null`. När en [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) tillhandahålls förankras kommentaren till den formen. Koordinaterna definierar fortfarande positionen för kommentar‑markören på bilden, medan form‑associationen kan hämtas via [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Förankra en modern kommentar till en form**

Exemplet anropar [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) två gånger: en gång med en `null`‑form för en bildnivå‑kommentar och en gång med en rektangel som förankring. Att läsa [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) skriver ut `true` för bildnivå‑kommentarens null‑kontroll och `Revenue title` för den förankrade kommentaren. Båda kommentarerna sparas ihop med presentationen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Förankra kommentarer till olika formtyper**

Alla bildobjekt som är avledda från [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) kan användas som en form‑förankring. Vanliga exempel inkluderar [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) och [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/)‑instanser såsom diagram.

Exemplet använder [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) för att associera en kommentar med var och en av fem formtyper: en AutoShape, en bildram, en grupp, en connector och ett diagram. Bilden använder inbäddad bilddata, så ingen extern bild behövs. Varje kommentar har sin egen markörposition, och den sparade presentationen behåller alla fem form‑associationer.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");

    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Förankra en kommentar till text och sätt dess status**

För en modern kommentar som är associerad med en [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), får [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) och [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) åtkomst till startpositionen för den markerade texten i formens textruta. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) och [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) ger åtkomst till urvals‑längden. Tillsammans associerar dessa värden kommentaren med ett specifikt textintervall i AutoShape.

Metoderna [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) och [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) får åtkomst till ett värde från uppräkningen [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/):
- `NotDefined` — ingen specifik modern‑kommentarstatus är definierad.
- `Active` — kommentaren är aktiv.
- `Resolved` — kommentaren har lösts.
- `Closed` — kommentaren är stängd.

Exemplet förankrar en modern kommentar till orden "quarterly revenue" i en rektangels text. Det beräknar den nollbaserade startpositionen för urvalet från texten och skickar den till [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) och använder [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) för att ange antalet valda tecken. Efter att ha anropat [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) med `Resolved` sparas och öppnas presentationen igen. De fyra konsollkontrollerna bör alla skriva ut `true`, vilket bekräftar att form‑förankringen, textintervallet och statusen bevarades.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(java.newByte(aspose.slides.ModernCommentStatus.Resolved));

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Inspektera befintliga moderna kommentarer**

Exemplet kräver en befintlig presentation som innehåller moderna kommentarer och skriver ut deras text, status och förankringsdetaljer. För att inspektera den, kontrollera vilka kommentarer som är instanser av [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/), och undersök sedan [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), och [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/). En `null`‑form indikerar en bildnivå‑kommentar. För en [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)-förankring identifierar text‑urvalsmetoderna det associerade intervallet i formens textruta.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ta bort kommentarer**

Aspose.Slides för Node.js via Java låter dig ta bort alla kommentarer och deras författare från en presentation eller radera valda kommentarer medan resten behålls. Följande exempel demonstrerar båda tillvägagångssätten och sparar den uppdaterade presentationen.

### **Ta bort alla kommentarer och kommentar‑författare**

Exemplet öppnar en befintlig presentation och anropar [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/) för varje författare, därefter anropas [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) för att ta bort själva författarna. Den sparade presentationen innehåller varken kommentarer eller kommentar‑författare. Använd en presentation som innehåller kommentarer för att observera borttagningen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();

    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ta bort specifika kommentarer**

Exemplet skapar två kommentarer på en bild och använder [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) för att hitta kommentarer per författare. Det samlar kommentarer vars text är "comment 1" innan [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/) anropas, vilket undviker förändringar av samlingen under urvalet. Den sparade presentationen behåller endast "comment 2".

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Stöder Aspose.Slides en löst status för moderna kommentarer?**

Ja. [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) och [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) får åtkomst till ett [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/)‑värde, inklusive `Resolved`. Statusen lagras i presentationen och kan läsas igen efter att filen har öppnats på nytt.

**Stöds trådade diskussioner (svars­kedjor), och finns det en begränsning för djupet?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/), vilket möjliggör svars­kedjor. API:et definierar ingen specifik begränsning för inbäddningsdjupet.

**I vilket koordinatsystem definieras en kommentarmarkörs position på en bild?**

Markörens position definieras av flyttalskoordinater i bildens koordinatsystem, vilket gör att du kan placera den exakt på bilden.