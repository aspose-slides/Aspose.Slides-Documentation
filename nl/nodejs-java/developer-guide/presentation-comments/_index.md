---
title: Beheer presentatiecommentaren in Node.js
linktitle: Presentatiecommentaren
type: docs
weight: 100
url: /nl/nodejs-java/presentation-comments/
keywords:
- commentaar
- modern commentaar
- PowerPoint-commentaren
- presentatiecommentaren
- dia-commentaren
- commentaar toevoegen
- commentaar benaderen
- commentaar bewerken
- commentaar beantwoorden
- commentaar verwijderen
- commentaar verwijderen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer presentatiecommentaren met Aspose.Slides for Node.js via Java: voeg commentaren toe, lees ze, bewerk ze, beantwoord ze en verwijder ze in PowerPoint‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatie‑commentaren kunt beheren met Aspose.Slides for Node.js via Java. Het introduceert de belangrijkste commentaar‑gerelateerde typen en laat zien hoe u commentaren aan dia’s toevoegt, bestaande commentaren benadert, werkt met antwoorden en moderne commentaren, en commentaren uit een presentatie verwijdert.

De voorbeelden behandelen veelvoorkomende beoordelings‑ en samenwerkingsscenario’s in PowerPoint, zoals het toewijzen van commentaren aan auteurs, het lezen van commentaartekst en metadata, het opbouwen van antwoordketens, en het verwijderen van geselecteerde commentaren of alle commentaren.

In PowerPoint verschijnen commentaren als annotaties op dia’s. Het selecteren van een commentaar toont de tekst en de bijbehorende discussie.

Om aan te geven dat commentaren getoond of verborgen moeten worden wanneer een presentatie wordt geopend zonder de commentaren zelf te wijzigen, zie [Show or Hide Comments When Opening a Presentation](/slides/nl/nodejs-java/presentation-view-properties/).

## **Waarom commentaren aan presentaties toevoegen?**

U kunt commentaren gebruiken om feedback te geven en samen te werken met collega's bij het beoordelen van presentaties.

Aspose.Slides for Node.js via Java biedt de volgende API’s voor het werken met commentaren:

* De [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse, die toegang geeft tot de auteurs van commentaren in de presentatie.
* De [CommentCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/commentcollection/)‑klasse, die de commentaren vertegenwoordigt die aan een individuele auteur zijn gekoppeld.
* De [Comment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/comment/)‑klasse, die informatie over een commentaar biedt, inclusief auteur, aanmaaktijd, positie en tekst.
* De [CommentAuthor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/commentauthor/)‑klasse, die informatie over een auteur bevat, inclusief hun naam, initialen en gekoppelde commentaren.

## **Dia‑commentaren toevoegen**

Het volgende voorbeeld laat zien hoe u commentaren aan dia’s in een PowerPoint‑presentatie toevoegt:

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

## **Dia‑commentaren benaderen**

Het volgende voorbeeld laat zien hoe u bestaande commentaren in een PowerPoint‑presentatie benadert:

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

## **Antwoorden op commentaren**

Een bovenliggend commentaar is het oorspronkelijke commentaar bovenaan een antwoordhiërarchie. De methoden [Comment.getParentComment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/comment/getparentcomment/) en [Comment.setParentComment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/comment/setparentcomment/) stellen u in staat het bovenliggende commentaar van een commentaar op te halen of in te stellen.

Het volgende voorbeeld laat zien hoe u antwoorden toevoegt en de resulterende commentaariharchie inspecteert:

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
* Wanneer de methode [Comment.remove](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/comment/remove/) wordt gebruikt om een commentaar te verwijderen, worden ook alle antwoorden op dat commentaar verwijderd.
* Als [Comment.setParentComment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/comment/setparentcomment/) een circulaire referentie creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxeditexception/) gegooid.
{{% /alert %}}

## **Moderne commentaren toevoegen**

Moderne commentaren kunnen worden gekoppeld aan de dia zelf, aan een specifieke vorm, of aan een tekstreeks binnen een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/). De methode [CommentCollection.addModernComment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) accepteert een [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/)‑argument naast de dia‑ en commentarmarker‑coördinaten.

Wanneer `null` wordt doorgegeven voor het vorm‑argument, is het commentaar een dia‑niveau commentaar. De marker wordt geplaatst op basis van de meegeleverde coördinaten, maar is niet gekoppeld aan een specifieke vorm, dus [ModernComment.getShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/getshape/) retourneert `null`. Wanneer een [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/) wordt opgegeven, wordt het commentaar verankerd aan die vorm. De coördinaten bepalen nog steeds de positie van de commentarmarker op de dia, terwijl de vormkoppeling kan worden opgehaald via [ModernComment.getShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Een modern commentaar aan een vorm verankeren**

Het volgende voorbeeld maakt zowel een dia‑niveau modern commentaar als een modern commentaar verankerd aan een specifieke [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/). Vervolgens leest het de gekoppelde vorm van elk commentaar.

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

### **Commentaren aan verschillende vormtypen verankeren**

Elk dia‑object dat is afgeleid van [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/) kan worden gebruikt als anker. Veelvoorkomende voorbeelden zijn [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/connector/) en [GraphicalObject](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/graphicalobject/)‑instanties zoals grafieken.

Het volgende voorbeeld maakt verschillende veelvoorkomende vormtypen en koppelt een modern commentaar aan elk van hen.

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

### **Een commentaar aan tekst verankeren en de status instellen**

Voor een modern commentaar gekoppeld aan een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/), geven [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) en [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) de startpositie van de geselecteerde tekst in het tekstvak van de vorm terug. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) en [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) geven de lengte van de selectie terug. Samen koppelen deze waarden het commentaar aan een specifiek tekstreeks binnen de [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/).

De methoden [ModernComment.getStatus](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/getstatus/) en [ModernComment.setStatus](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/setstatus/) geven een waarde uit de enumeratie [ModernCommentStatus](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncommentstatus/) terug:

- `NotDefined` — er is geen specifieke modern‑commentaarstatus gedefinieerd.
- `Active` — het commentaar is actief.
- `Resolved` — het commentaar is opgelost.
- `Closed` — het commentaar is gesloten.

Het volgende voorbeeld maakt een vorm‑verankerd modern commentaar, koppelt het aan een tekstreeks, markeert het als opgelost, slaat de presentatie op en controleert de waarden na het heropenen van het bestand.

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

### **Bestaande moderne commentaren inspecteren**

Om een bestaande presentatie te inspecteren, controleer welke commentaren [ModernComment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/)‑instanties zijn, en bekijk vervolgens [ModernComment.getShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) en [ModernComment.getStatus](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/getstatus/). Een `null` vorm duidt op een commentaar op dia‑niveau. Voor een anker op een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) identificeren de tekst‑selectiemethoden het gekoppelde bereik in het tekstvak van de vorm.

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

## **Commentaren verwijderen**

### **Alle commentaren en commentauteur​s verwijderen**

Het volgende voorbeeld laat zien hoe u alle commentaren en commentauteur​s uit een presentatie verwijdert:

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

### **Specifieke commentaren verwijderen**

Het volgende voorbeeld laat zien hoe u specifieke commentaren van een dia verwijdert:

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

**Ondersteunt Aspose.Slides een ‘opgelost’-status voor moderne commentaren?**

Ja. [ModernComment.getStatus](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/getstatus/) en [ModernComment.setStatus](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/setstatus/) geven een [ModernCommentStatus](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncommentstatus/)‑waarde terug, inclusief `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw worden uitgelezen nadat het bestand is heropend.

**Worden gearchiveerde discussies (antwoordketens) ondersteund en is er een limiet voor nesting?**

Ja. Elk commentaar kan verwijzen naar zijn [parent comment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/comment/getparentcomment/), waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke limiet voor de diepte van nesting.

**In welk coördinatensysteem wordt de positie van een commentarmarker op een dia gedefinieerd?**

De markerpositie wordt gedefinieerd door zwevende‑kommagetallen in het dia‑coördinatensysteem, zodat u de marker nauwkeurig op de dia kunt plaatsen.