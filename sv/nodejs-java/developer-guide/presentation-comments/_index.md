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
- åtkomst till kommentar
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

Den här artikeln förklarar hur du hanterar presentationskommentarer med Aspose.Slides för Node.js via Java. Den introducerar de viktigaste kommentarrelaterade typerna och demonstrerar hur du lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar och moderna kommentarer samt tar bort kommentarer från en presentation.

Exemplen täcker vanliga gransknings- och samarbets scenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentartext och metadata, bygga svarskedjor och ta bort valda kommentarer eller alla kommentarer.

I PowerPoint visas kommentarer som annoteringar på bilder. När du markerar en kommentar visas dess text och relaterade diskussion.

## **Varför lägga till kommentarer i presentationer?**

Du kan använda kommentarer för att ge feedback och samarbeta med kollegor när du granskar presentationer.

Aspose.Slides för Node.js via Java tillhandahåller följande API: för att arbeta med kommentarer:

* Klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) ger åtkomst till presentationens kommentarförfattare.
* Klassen [CommentCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/commentcollection/) representerar kommentarerna som är kopplade till en enskild författare.
* Klassen [Comment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/comment/) ger information om en kommentar, inklusive författare, skapandetid, position och text.
* Klassen [CommentAuthor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/commentauthor/) ger information om en författare, inklusive namn, initialer och tillhörande kommentarer.

## **Lägg till bildkommentarer**

Följande exempel visar hur du lägger till kommentarer på bilder i en PowerPoint-presentation:

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

        const authorComments = firstComment.getAuthor().getComments();
        const commentText = authorComments.get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Få åtkomst till bildkommentarer**

Följande exempel visar hur du får åtkomst till befintliga kommentarer i en PowerPoint-presentation:

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

En föräldrakommentar är den ursprungliga kommentaren högst upp i en svarshierarki. Metoderna [Comment.getParentComment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/comment/getparentcomment/) och [Comment.setParentComment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/comment/setparentcomment/) låter dig hämta eller ange föräldern för en kommentar.

Följande exempel visar hur du lägger till svar och inspekterar den resulterande kommentarshierarkin:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    const author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    const reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    const subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    const comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    const reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

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

    comment1.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* När metoden [Comment.remove](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/comment/remove/) används för att ta bort en kommentar, tas även alla svar till den kommentaren bort.
* Om [Comment.setParentComment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/comment/setparentcomment/) skapar en cirkulär referens, kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Lägg till moderna kommentarer**

Moderna kommentarer kan associeras med själva bilden, med en specifik form eller med ett textområde inuti en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/). Metoden [CommentCollection.addModernComment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) accepterar ett [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/)‑argument utöver bilden och kommentar‑markörens koordinater.

När `null` skickas som shape‑argument är kommentaren en bildnivåkommentar. Dess markör placeras enligt de angivna koordinaterna, men den är inte kopplad till någon specifik form, så [ModernComment.getShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/getshape/) returnerar `null`. När en [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/) tillhandahålls är kommentaren förankrad i den formen. Koordinaterna definierar fortfarande positionen för kommentarens markör på bilden, medan formkopplingen kan hämtas via [ModernComment.getShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Förankra en modern kommentar till en form**

Följande exempel skapar både en modern kommentar på bildnivå och en modern kommentar förankrad till en specifik [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/). Det läser sedan den associerade formen från varje kommentar.

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

Alla bildobjekt som härstammar från [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/) kan användas som formankare. Vanliga exempel inkluderar [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/connector/) och [GraphicalObject](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/graphicalobject/)-instanser såsom diagram.

Följande exempel skapar flera vanliga formtyper och associerar en modern kommentar med var och en.

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

För en modern kommentar som är kopplad till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) ger [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) och [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) åtkomst till startpositionen för den markerade texten i formens textruta. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) och [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) ger åtkomst till längden på markeringen. Tillsammans associerar dessa värden kommentaren med ett specifikt textområde i [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/).

[ModernComment.getStatus](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/getstatus/) och [ModernComment.setStatus](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/setstatus/) metoder ger åtkomst till ett [ModernCommentStatus](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncommentstatus/)‑värde:

- `NotDefined` — ingen specifik modern‑kommentarstatus är definierad.
- `Active` — kommentaren är aktiv.
- `Resolved` — kommentaren har lösts.
- `Closed` — kommentaren är stängd.

Följande exempel skapar en formförankrad modern kommentar, associerar den med en textmarkering, markerar den som löst, sparar presentationen och verifierar värdena efter att filen har öppnats igen.

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
    comment.setStatus(aspose.slides.ModernCommentStatus.Resolved);

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

För att inspektera en befintlig presentation, kontrollera vilka kommentarer som är [ModernComment]-instanser, och undersök sedan [ModernComment.getShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/gettex tselectionlength/) och [ModernComment.getStatus](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/getstatus/). En `null`‑form indikerar en kommentar på bildnivå. För ett [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/)-ankare identifierar textmarkeringsmetoderna det associerade området i formens textruta.

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

### **Ta bort alla kommentarer och kommentar‑författare**

Följande exempel visar hur du tar bort alla kommentarer och kommentar‑författare från en presentation:

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

Följande exempel visar hur du tar bort specifika kommentarer från en bild:

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

**Stöder Aspose.Slides ett löst status för moderna kommentarer?**

Ja. [ModernComment.getStatus](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/getstatus/) och [ModernComment.setStatus](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncomment/setstatus/) ger åtkomst till ett [ModernCommentStatus](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/moderncommentstatus/)‑värde, inklusive `Resolved`. Statusen sparas i presentationen och kan läsas igen efter att filen har öppnats på nytt.

**Stöds trådade diskussioner (svarskedjor), och finns det någon begränsning för nästlingsdjup?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/comment/getparentcomment/), vilket möjliggör svarskedjor. API:et definierar ingen specifik begränsning för nästlingsdjup.

**I vilket koordinatsystem definieras en kommentarmarkörs position på en bild?**

Markörens position definieras av flyttalskoordinator i bildens koordinatsystem, vilket gör att du kan placera den exakt på bilden.