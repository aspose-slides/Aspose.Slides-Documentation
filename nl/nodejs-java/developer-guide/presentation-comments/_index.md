---
title: Beheer presentatieopmerkingen in JavaScript
linktitle: Presentatieopmerkingen
type: docs
weight: 100
url: /nl/nodejs-java/presentation-comments/
keywords:
- opmerking
- moderne opmerking
- PowerPoint-opmerkingen
- presentatie-opmerkingen
- dia-opmerkingen
- opmerking toevoegen
- opmerking benaderen
- opmerking bewerken
- opmerking beantwoorden
- opmerking verwijderen
- opmerking wissen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheers presentatieopmerkingen met Aspose.Slides voor Node.js: voeg opmerkingen toe, lees, bewerk en verwijder ze in PowerPoint-bestanden met JavaScript, snel en gemakkelijk."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatie‑opmerkingen in Aspose.Slides kunt beheren. Het toont de belangrijkste typen die met opmerkingen te maken hebben en laat zien hoe u opmerkingen aan dia’s kunt toevoegen, bestaande opmerkingen kunt benaderen, met antwoorden kunt werken, moderne opmerkingen kunt gebruiken en opmerkingen uit een presentatie kunt verwijderen.

De voorbeelden richten zich op veelvoorkomende beoordelings‑ en samenwerkingsscenario’s in PowerPoint, zoals opmerkingen aan auteurs toewijzen, de inhoud en metadata van opmerkingen lezen, antwoordketens opbouwen en alle opmerkingen wissen of geselecteerde verwijderen.

In PowerPoint verschijnt een opmerking als een notitie of aantekening op een dia. Wanneer op een opmerking wordt geklikt, worden de inhoud of berichten ervan weergegeven.

## **Waarom opmerkingen aan presentaties toevoegen?**

U wilt mogelijk opmerkingen gebruiken om feedback te geven of te communiceren met uw collega’s tijdens het beoordelen van presentaties.

Om u toe te staan opmerkingen te gebruiken in PowerPoint‑presentaties, biedt Aspose.Slides for Node.js via Java

* De [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse, die de collecties van auteurs bevat (van de [CommentAuthorCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/CommentAuthorCollection)‑klasse). De auteurs voegen opmerkingen toe aan dia’s.
* De [CommentCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/CommentCollection)‑klasse, die de verzameling opmerkingen voor individuele auteurs bevat.
* De [Comment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Comment)‑klasse, die informatie over auteurs en hun opmerkingen bevat: wie de opmerking heeft toegevoegd, het tijdstip van toevoeging, de positie van de opmerking, enz.
* De [CommentAuthor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/CommentAuthor)‑klasse, die informatie over individuele auteurs bevat: de naam van de auteur, zijn initialen, opmerkingen die aan de naam van de auteur zijn gekoppeld, enz.

## **Opmerking aan dia toevoegen**
Deze JavaScript‑code laat zien hoe u een opmerking aan een dia in een PowerPoint‑presentatie toevoegt:

```javascript
// Initialiseert de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    // Voegt een lege dia toe
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // Voegt een auteur toe
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // Stelt de positie voor opmerkingen in
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // Voegt een diaopmerking toe voor een auteur op dia 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // Voegt een diaopmerking toe voor een auteur op dia 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // Benadert ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // Wanneer null als argument wordt doorgegeven, worden de opmerkingen van alle auteurs naar de geselecteerde dia gehaald
    var Comments = slide.getSlideComments(author);
    // Benadert de opmerking op index 0 voor dia 1
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // Selecteert de opmerkingenverzameling van de auteur op index 0
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Opmerkingen op dia benaderen**
Deze JavaScript‑code laat zien hoe u een bestaande opmerking op een dia in een PowerPoint‑presentatie benadert:

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

## **Opmerkingen beantwoorden**
Een bovenliggende opmerking is de eerste of oorspronkelijke opmerking in een hiërarchie van opmerkingen of antwoorden. Met de [getParentComment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Comment#getParentComment--) of [setParentComment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-)‑methoden (van de [Comment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Comment)‑klasse) kunt u een bovenliggende opmerking instellen of ophalen.

Deze JavaScript‑code laat zien hoe u opmerkingen toevoegt en antwoorden erop krijgt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Voegt een opmerking toe
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // Voegt een antwoord toe aan comment1
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // Voegt nog een antwoord toe aan comment1
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // Voeg een antwoord toe aan een bestaand antwoord
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // Toont de hiërarchie van opmerkingen op de console
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
    // Verwijdert comment1 en alle antwoorden daarop
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Attention" %}} 

* Wanneer de [Remove](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Comment#remove--)‑methode (van de [Comment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Comment)‑klasse) wordt gebruikt om een opmerking te verwijderen, worden de antwoorden op die opmerking eveneens verwijderd.
* Als de instelling van [setParentComment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) resulteert in een circulaire verwijzing, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PptxEditException) gegooid.

{{% /alert %}}

## **Moderne opmerking toevoegen**

In 2021 heeft Microsoft *moderne opmerkingen* geïntroduceerd in PowerPoint. De functie moderne opmerkingen verbetert de samenwerking in PowerPoint aanzienlijk. Via moderne opmerkingen kunnen PowerPoint‑gebruikers opmerkingen oplossen, opmerkingen verankeren aan objecten en teksten, en veel gemakkelijker interacties aangaan dan voorheen.

Aspose.Slides ondersteunt moderne opmerkingen via de [ModernComment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ModernComment)‑klasse. De methoden [addModernComment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) en [insertModernComment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) zijn toegevoegd aan de [CommentCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/CommentCollection)‑klasse.

Deze JavaScript‑code laat zien hoe u een moderne opmerking aan een dia in een PowerPoint‑presentatie toevoegt:

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

## **Opmerking verwijderen**

### **Alle opmerkingen en auteurs verwijderen**

Deze JavaScript‑code laat zien hoe u alle opmerkingen en auteurs in een presentatie verwijdert:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Verwijdert alle opmerkingen uit de presentatie
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // Verwijdert alle auteurs
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Specifieke opmerkingen verwijderen**

Deze JavaScript‑code laat zien hoe u specifieke opmerkingen op een dia verwijdert:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // voeg opmerkingen toe...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // verwijder alle opmerkingen die de tekst "comment 1" bevatten
    
    
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

**Ondersteunt Aspose.Slides een status zoals ‘opgelost’ voor moderne opmerkingen?**

Ja. [Moderne opmerkingen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/) bieden een [getStatus](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/getstatus/)‑ en een [setStatus](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncomment/setStatus/)‑methode; u kunt de [status van een opmerking](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/moderncommentstatus/) lezen en instellen (bijvoorbeeld markeren als opgelost), en deze status wordt opgeslagen in het bestand en herkend door PowerPoint.

**Worden discussies met antwoorden (reply chains) ondersteund, en is er een limiet op het aantal niveaus?**

Ja. Elke opmerking kan verwijzen naar zijn [parent comment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/comment/getparentcomment/), waardoor willekeurige antwoordketens mogelijk zijn. De API declareert geen specifieke limiet voor de diepte van geneste antwoorden.

**In welk coördinatensysteem wordt de positie van een opmerkingmarkeringspunt op een dia gedefinieerd?**

De positie wordt opgeslagen als een zwevend‑kommagetalpunt in het coördinatensysteem van de dia. Hierdoor kunt u de markeringspunt precies plaatsen waar u het nodig hebt.