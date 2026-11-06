---
title: Beheer presentatie‑opmerkingen in Node.js
linktitle: Presentatie‑opmerkingen
type: docs
weight: 100
url: /nl/nodejs-java/presentation-comments/
keywords:
- opmerking
- moderne opmerking
- PowerPoint‑opmerkingen
- presentatie‑opmerkingen
- dia‑opmerkingen
- opmerking toevoegen
- opmerking benaderen
- opmerking bewerken
- opmerking beantwoorden
- opmerking verwijderen
- opmerking wissen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer presentatie‑opmerkingen met Aspose.Slides voor Node.js via Java: voeg toe, lees, bewerk, beantwoord en verwijder opmerkingen in PowerPoint‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatie‑opmerkingen kunt beheren met Aspose.Slides voor Node.js via Java. Het introduceert de belangrijkste commentaar‑gerelateerde typen en laat zien hoe u opmerkingen aan dia’s kunt toevoegen, bestaande opmerkingen kunt benaderen, kunt werken met antwoorden en moderne opmerkingen, en opmerkingen uit een presentatie kunt verwijderen.

De voorbeelden dekken veelvoorkomende review‑ en collaboratiescenario’s in PowerPoint, zoals het toewijzen van opmerkingen aan auteurs, het lezen van opmerkingstekst en metadata, het opbouwen van antwoordketens, en het verwijderen van geselecteerde opmerkingen of alle opmerkingen.

In PowerPoint verschijnen opmerkingen als annotaties op dia’s. Het selecteren van een opmerking toont de tekst en de bijbehorende discussie.

Om te vragen dat opmerkingen getoond of verborgen worden wanneer een presentatie wordt geopend zonder de opmerkingen zelf te wijzigen, zie [Show or Hide Comments When Opening a Presentation](/slides/nl/nodejs-java/presentation-view-properties/).

## **Waarom opmerkingen aan presentaties toevoegen?**

U kunt opmerkingen gebruiken om feedback te geven en samen te werken met collega’s bij het beoordelen van presentaties.

Aspose.Slides voor Node.js via Java biedt de volgende API’s voor het werken met opmerkingen:

* De [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class, die toegang geeft tot de commenta‑auteurs van de presentatie.
* De [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) class, die de opmerkingen vertegenwoordigt die aan één auteur zijn gekoppeld.
* De [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) class, die informatie over een opmerking biedt, inclusief auteur, aanmaak‑tijd, positie en tekst.
* De [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) class, die informatie over een auteur biedt, inclusief naam, initialen en gekoppelde opmerkingen.

## **Dia‑opmerkingen toevoegen**

Het voorbeeld maakt twee dia’s aan en registreert een commentaurauteur met [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/). Het gebruikt [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) om één opmerking op elke dia te plaatsen, haalt vervolgens de opmerkingen van de eerste dia op voor die auteur met [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/). De console toont de tekst van de eerste opmerking tweemaal, wat aantoont dat de toegang via zowel de dia als de auteur werkt, en de opgeslagen presentatie bevat beide opmerkingen.

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

## **Een commentaurauteur vinden of maken**

Wanneer een geautomatiseerde review dezelfde presentatie herhaaldelijk verwerkt, doorzoek dan de collectie die wordt geretourneerd door [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) voordat u een auteur toevoegt. [findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) vergelijkt zowel naam als initialen en retourneert een array van overeenkomende auteurs, of een lege array als er geen overeenkomsten zijn. Daarentegen zoekt [findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) alleen op naam, ongeacht initialen. Het aanroepen van [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) met een naam en initialen die al in de collectie aanwezig zijn, resulteert in een exceptie.

Het voorbeeld vereist een presentatiebestand met ten minste één dia. Tijdens twee passes wordt de eerst gevonden auteur opnieuw gebruikt, of wordt er één aangemaakt alleen wanneer het resultaat leeg is. Als er meerdere overeenkomsten zijn, wordt het eerste array‑element geselecteerd zonder de andere auteurs te combineren of te verwijderen. Vervolgens wordt [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) aangeroepen voor de geselecteerde auteur en wordt de presentatie opgeslagen. De tweede pass opent de output van de eerste pass en herhaalt de bewerking.

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

De tweede pass voegt een extra opmerking toe zonder een extra auteur toe te voegen of bestaande opmerkingen te verwijderen. Het eindbestand, `review_pass_2.pptx`, bevat beide nieuwe opmerkingen naast eventuele oorspronkelijke opmerkingen. Het hergebruiken van een auteur dedupliceert opmerkingen niet: om te voorkomen dat dezelfde opmerking steeds opnieuw wordt toegevoegd, moet u vooraf een eigen duplicaatdetectie implementeren.

## **Dia‑opmerkingen benaderen**

Het voorbeeld opent een bestaande presentatie en leest de collectie die wordt geretourneerd door [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/). Voor elke auteur wordt door de collectie gelopen die wordt geretourneerd door [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/) en worden het dia‑nummer, de opmerkingstekst, de naam van de auteur en de aanmaak‑tijd afgedrukt. De invoerpresentatie moet opmerkingen bevatten om console‑output te genereren.

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

## **Antwoorden op opmerkingen**

Een hoofdopmerking is de oorspronkelijke opmerking bovenaan een antwoorden‑hiërarchie. De methoden [Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) en [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) laten u de ouder van een opmerking ophalen of instellen.

Het voorbeeld maakt opmerkingen van twee auteurs en gebruikt [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) om antwoorden op te bouwen, inclusief een antwoord op een ander antwoord. Door `null` door te geven aan [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) worden opmerkingen van alle auteurs opgehaald; de console inspringt elke ingang volgens de diepte in de antwoorden‑hiërarchie. Het voorbeeld slaat de volledige discussie op, roept [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) aan op de eerste root‑opmerking, en slaat een tweede presentatie op waarin die opmerking en haar antwoorden zijn verwijderd.

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
* Wanneer de methode [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) wordt gebruikt om een opmerking te verwijderen, worden alle antwoorden op die opmerking ook verwijderd.
* Als [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) een circulaire referentie creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/) gegooid.
{{% /alert %}}

## **Moderne opmerkingen toevoegen**

Moderne opmerkingen kunnen worden gekoppeld aan de dia zelf, aan een specifieke vorm, of aan een tekstreeks binnen een AutoShape. De methode [CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) accepteert een [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)‑argument naast de dia‑ en opmerking‑marker‑coördinaten.

Wanneer `null` wordt doorgegeven voor het vorm‑argument, is de opmerking een dia‑niveau‑opmerking. De marker wordt gepositioneerd volgens de opgegeven coördinaten, maar is niet gekoppeld aan een specifieke vorm, zodat [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) `null` retourneert. Wanneer een [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) wordt verstrekt, wordt de opmerking aan die vorm verankerd. De coördinaten bepalen nog steeds de positie van de opmerking‑marker op de dia, terwijl de vormkoppeling kan worden opgehaald via [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Een moderne opmerking aan een vorm verankeren**

Het voorbeeld roept [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) twee keer aan: eenmaal met een `null` vorm voor een dia‑niveau‑opmerking en eenmaal met een rechthoek als anker. Het lezen van [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) drukt `true` af voor de null‑controle van de dia‑niveau‑opmerking en `Revenue title` voor de verankerde opmerking. Beide opmerkingen worden opgeslagen met de presentatie.

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

### **Opmerkingen aan verschillende vormtypen verankeren**

Elk dia‑object dat is afgeleid van [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) kan worden gebruikt als anker. Veelvoorkomende voorbeelden zijn [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) en [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/)‑instanties zoals diagrammen.

Het voorbeeld gebruikt [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) om een opmerking te koppelen aan elk van vijf vormtypen: een AutoShape, een afbeelding, een groep, een connector en een diagram. De afbeelding maakt gebruik van ingebedde beeldgegevens, dus er is geen externe afbeelding nodig. Elke opmerking heeft zijn eigen marker‑positie, en de opgeslagen presentatie behoudt alle vijf vormkoppelingen.

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

### **Een opmerking aan tekst verankeren en de status instellen**

Voor een moderne opmerking gekoppeld aan een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) geven [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) en [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) de startpositie van de geselecteerde tekst in het tekstvak van de vorm terug. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) en [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) geven de lengte van de selectie terug. Samen koppelen deze waarden de opmerking aan een specifieke tekstreeks binnen de AutoShape.

De methoden [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) en [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) geven een waarde terug uit de enumeratie [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — er is geen specifieke modern‑comment status gedefinieerd.
- `Active` — de opmerking is actief.
- `Resolved` — de opmerking is opgelost.
- `Closed` — de opmerking is gesloten.

Het voorbeeld verankert een moderne opmerking aan de woorden “quarterly revenue” in de tekst van een rechthoek. Het bepaalt de nul‑gebaseerde startpositie uit de tekst en geeft deze door aan [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) en gebruikt [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) om het aantal geselecteerde tekens in te stellen. Na het aanroepen van [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) met `Resolved`, slaat het de presentatie op en opent deze opnieuw. De vier console‑controles moeten elk `true` afdrukken, wat bevestigt dat de vorm‑anker, tekstreeks en status bewaard zijn gebleven.

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

### **Bestaande moderne opmerkingen inspecteren**

Het voorbeeld vereist een bestaande presentatie met moderne opmerkingen en drukt hun tekst, status en anker‑details af. Om dit te inspecteren, controleert u welke opmerkingen instanties zijn van [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/), bekijkt vervolgens [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) en [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/). Een `null` vorm duidt op een dia‑niveau‑opmerking. Voor een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)‑anker identificeren de tekst‑selectie‑methoden het gekoppelde bereik in het tekstvak van de vorm.

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

## **Opmerkingen verwijderen**

Aspose.Slides voor Node.js via Java maakt het mogelijk om alle opmerkingen en hun auteurs uit een presentatie te verwijderen of geselecteerde opmerkingen te wissen terwijl de rest behouden blijft. De onderstaande voorbeelden tonen beide benaderingen en slaan de bijgewerkte presentatie op.

### **Alle opmerkingen en commentaurauteurs verwijderen**

Het voorbeeld opent een bestaande presentatie en roept [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/) aan voor elke auteur, waarna [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) wordt aangeroepen om de auteurs zelf te verwijderen. De opgeslagen presentatie bevat geen opmerkingen en geen commentaurauteurs. Gebruik een presentatie met opmerkingen om de verwijdering te observeren.

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

### **Specifieke opmerkingen verwijderen**

Het voorbeeld maakt twee opmerkingen op één dia en gebruikt [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) om de opmerkingen per auteur te vinden. Het verzamelt de opmerkingen waarvan de tekst gelijk is aan “comment 1” voordat [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/) wordt aangeroepen, om wijzigingen in de collectie tijdens de selectie te vermijden. De opgeslagen presentatie bevat alleen “comment 2”.

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

**Ondersteunt Aspose.Slides een 'resolved' status voor moderne opmerkingen?**

Ja. [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) en [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) geven een waarde uit de [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) terug, inclusief `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw worden uitgelezen nadat het bestand opnieuw is geopend.

**Worden discussies met meerdere niveaus (antwoordketens) ondersteund en is er een limiet voor nesting?**

Ja. Elke opmerking kan verwijzen naar zijn [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/), waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke limiet voor de diepte van de nesting.

**In welk coördinatensysteem wordt de positie van een opmerking‑marker op een dia gedefinieerd?**

De marker‑positie wordt gedefinieerd door zwevende‑komma‑coördinaten in het dia‑coördinatensysteem, waardoor u de marker nauwkeurig op de dia kunt plaatsen.