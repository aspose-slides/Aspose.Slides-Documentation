---
title: Beheer presentatiecommentaren in Java
linktitle: Presentatiecommentaren
type: docs
weight: 100
url: /nl/java/presentation-comments/
keywords:
- commentaar
- modern commentaar
- PowerPoint-commentaren
- presentatie-commentaren
- dia-commentaren
- commentaar toevoegen
- commentaar benaderen
- commentaar bewerken
- commentaar beantwoorden
- commentaar verwijderen
- commentaar wissen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Beheer presentatie-commentaren met Aspose.Slides for Java: voeg commentaren toe, lees ze, bewerk ze, beantwoord ze en verwijder commentaren in PowerPoint-presentaties snel en eenvoudig."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatie‑commentaren beheert met Aspose.Slides for Java. Het introduceert de belangrijkste commentaar‑gerelateerde types en laat zien hoe u commentaren aan dia's toevoegt, bestaande commentaren benadert, werkt met antwoorden en moderne commentaren, en commentaren uit een presentatie verwijdert.

De voorbeelden behandelen veelvoorkomende beoordelings‑ en samenwerkingsscenario's in PowerPoint, zoals commentaren toewijzen aan auteurs, commentaartekst en metadata lezen, antwoordketens opbouwen, en geselecteerde commentaren of alle commentaren verwijderen.

In PowerPoint verschijnen commentaren als annotaties op dia's. Het selecteren van een commentaar toont de tekst en de bijbehorende discussie.

Om commentaren weer te geven of te verbergen bij het openen van een presentatie zonder de commentaren zelf te wijzigen, zie [Commentaren weergeven of verbergen bij het openen van een presentatie](/slides/nl/java/presentation-view-properties/).

## **Waarom commentaren toevoegen aan presentaties?**

U kunt commentaren gebruiken om feedback te geven en samen te werken met collega's bij het beoordelen van presentaties.

Aspose.Slides for Java biedt de volgende API's voor het werken met commentaren:

* De [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) klasse, die toegang biedt tot de commentaarauteurs van de presentatie.
* De [ICommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/) interface, die de commentaren vertegenwoordigt die aan een individuele auteur zijn gekoppeld.
* De [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/) interface, die informatie over een commentaar geeft, inclusief auteur, aanmaakdatum, positie en tekst.
* De [CommentAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/commentauthor/) klasse, die informatie over een auteur geeft, inclusief naam, initialen en bijbehorende commentaren.

## **Dia‑commentaren toevoegen**

Het voorbeeld maakt twee dia's en registreert een commentaarauteur met [addAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-). Het gebruikt [addComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-java.awt.geom.Point2D.Float-java.util.Date-) om één commentaar op elke dia te plaatsen, haalt daarna de commentaren van de eerste dia op voor die auteur met [getSlideComments](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-). De console toont de tekst van het eerste commentaar twee keer, waarmee toegang via zowel de dia als de auteur wordt gedemonstreerd, en de opgeslagen presentatie bevat beide commentaren.

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    Point2D.Float position = new Point2D.Float(0.2f, 0.2f);
    Date createdTime = new Date();

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    IComment[] comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        IComment firstComment = comments[0];
        System.out.println(firstComment.getText());

        String commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zoek of maak een commentaarauteur**

Wanneer een geautomatiseerde beoordeling dezelfde presentatie herhaaldelijk verwerkt, doorzoek dan de collectie die wordt geretourneerd door [getCommentAuthors](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getCommentAuthors--) voordat u een auteur toevoegt. [findByNameAndInitials](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-) komt zowel overeen met de naam als de initialen en retourneert een array met overeenkomende auteurs, of een lege array als er geen overeenkomsten zijn. In contrast zoekt [findByName](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-) alleen op naam, ongeacht de initialen. Het aanroepen van [addAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) met een naam en initialen die reeds in de collectie aanwezig zijn, veroorzaakt een uitzondering.

Het voorbeeld vereist een presentatie‑bestand met ten minste één dia. Op elk van twee doorlopen hergebruikt het de eerste overeenkomende auteur, of maakt er één aan wanneer het resultaat leeg is. Als er meerdere overeenkomsten zijn, kiest het het eerste array‑element zonder de andere auteurs samen te voegen of te verwijderen. Vervolgens wordt [addComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-java.awt.geom.Point2D.Float-java.util.Date-) aangeroepen voor de geselecteerde auteur en wordt de presentatie opgeslagen. De tweede doorloop opent de uitvoer van de eerste doorloop en herhaalt de bewerking.

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

final String authorName = "Reviewer";
final String authorInitials = "RV";

String inputFile = "input.pptx";
Point2D.Float position = new Point2D.Float(20, 20);

for (int pass = 1; pass <= 2; pass++) {
    Presentation presentation = new Presentation(inputFile);
    try {
        ICommentAuthor[] matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        ICommentAuthor author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, new Date());

        String outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

De tweede doorloop voegt een extra commentaar toe zonder een extra auteur toe te voegen of bestaande commentaren te verwijderen. Het uiteindelijke bestand, `review_pass_2.pptx`, bevat beide nieuwe commentaren naast eventuele originele commentaren. Het hergebruiken van een auteur dedupliceert commentaren niet: om te voorkomen dat telkens hetzelfde commentaar wordt toegevoegd, implementeert u een aparte detectie van duplicaten vóór het toevoegen.

## **Dia‑commentaren benaderen**

Het voorbeeld opent een bestaande presentatie en leest de collectie die wordt geretourneerd door [getCommentAuthors](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getCommentAuthors--). Voor elke auteur itereren we door de collectie die wordt geretourneerd door [getComments](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthor/#getComments--) en printen we het dia‑nummer, de commentaartekst, de naam van de auteur en de aanmaaktijd. De invoerpresentatie moet commentaren bevatten om console‑output te produceren.

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        for (IComment comment : author.getComments()) {
            System.out.println("Slide: " + comment.getSlide().getSlideNumber());
            System.out.println("Comment: " + comment.getText());
            System.out.println("Author: " + comment.getAuthor().getName());
            System.out.println("Posted at: " + comment.getCreatedTime());
            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Antwoorden op commentaren**

Een bovenliggend commentaar is het oorspronkelijke commentaar bovenaan een antwoordhiërarchie. De [IComment.getParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#getParentComment--) en [IComment.setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) methoden laten u het bovenliggende commentaar ophalen of instellen.

Het voorbeeld maakt commentaren aan van twee auteurs en gebruikt [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) om antwoorden te bouwen, inclusief een antwoord op een ander antwoord. Het doorgeven van `null` aan [getSlideComments](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) haalt commentaren op van alle auteurs; de console vordert elke regel volgens de diepte in de antwoordhiërarchie. Het voorbeeld slaat de volledige discussie op, roept [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#remove--) aan op het eerste wortel‑commentaar, en slaat een tweede presentatie op waarbij dat commentaar en de antwoorden zijn verwijderd.

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Point2D.Float position = new Point2D.Float(10, 10);
    Date createdTime = new Date();

    ICommentAuthor originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    IComment secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    IComment subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    IComment separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    IComment separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++) {
        IComment comment = comments[i];
        while (comment.getParentComment() != null) {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() + ": " + comments[i].getText());
    }

    presentation.save("parent_comment.pptx", SaveFormat.Pptx);

    rootComment.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Wanneer de [IComment.remove](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#remove--) methode wordt gebruikt om een commentaar te verwijderen, worden ook alle antwoorden op dat commentaar verwijderd.
* Als [IComment.setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) een circulaire referentie creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxeditexception/) opgegooid.
{{% /alert %}}

## **Moderne commentaren toevoegen**

Moderne commentaren kunnen gekoppeld worden aan de dia zelf, aan een specifieke vorm, of aan een tekstreeks binnen een AutoShape. De [ICommentCollection.addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) methode accepteert een [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) argument naast de dia en de coördinaten van het commentaar‑marker.

Wanneer `null` wordt doorgegeven voor het vorm‑argument, is het commentaar een dia‑niveau commentaar. De marker wordt gepositioneerd op basis van de opgegeven coördinaten, maar is niet gekoppeld aan een specifieke vorm, zodat [IModernComment.getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--) `null` retourneert. Wanneer een [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) wordt opgegeven, wordt het commentaar aan die vorm verankerd. De coördinaten bepalen nog steeds de positie van de marker op de dia, terwijl de vormkoppeling kan worden opgevraagd via [IModernComment.getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--).

### **Een modern commentaar aan een vorm verankeren**

Het voorbeeld roept [addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) twee keer aan: eenmaal met een `null` vorm voor een dia‑niveau commentaar en eenmaal met een rechthoek als anker. Het uitlezen van [getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--) print `true` voor de null‑controle van het dia‑niveau commentaar en `Revenue title` voor het verankerde commentaar. Beide commentaren worden opgeslagen met de presentatie.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    Point2D.Float slideCommentPosition = new Point2D.Float(20, 20);
    Point2D.Float shapeCommentPosition = new Point2D.Float(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Commentaren verankeren aan verschillende vormtypes**

Elk dia‑object dat [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) implementeert, kan worden gebruikt als anker. Veelvoorkomende voorbeelden zijn [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/java/com.aspose.slides/iconnector/), en [IGraphicalObject](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobject/) instanties zoals grafieken.

Het voorbeeld gebruikt [addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) om een commentaar te koppelen aan elk van vijf vormtypes: een AutoShape, een afbeelding, een groep, een connector en een grafiek. De afbeelding gebruikt ingebedde afbeeldingsgegevens, dus er is geen externe afbeelding nodig. Elk commentaar heeft zijn eigen marker‑positie, en de opgeslagen presentatie behoudt alle vijf vormkoppelingen.

```java
import com.aspose.slides.ChartType;
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IChart;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IConnector;
import com.aspose.slides.IGroupShape;
import com.aspose.slides.IPPImage;
import com.aspose.slides.IPictureFrame;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");

    Point2D.Float autoShapeCommentPosition = new Point2D.Float(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    Point2D.Float pictureCommentPosition = new Point2D.Float(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    Point2D.Float groupCommentPosition = new Point2D.Float(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    Point2D.Float connectorCommentPosition = new Point2D.Float(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    Point2D.Float chartCommentPosition = new Point2D.Float(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Een commentaar aan tekst verankeren en de status instellen**

Voor een modern commentaar gekoppeld aan een [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/), geven [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) en [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) de startpositie van de geselecteerde tekst in het tekstvak van de vorm. [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) en [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) geven de lengte van de selectie. Samen koppelen deze waarden het commentaar aan een specifiek tekstbereik binnen de AutoShape.

De [IModernComment.getStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getStatus--) en [IModernComment.setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setStatus-byte-) methoden benaderen een waarde uit de [ModernCommentStatus](https://reference.aspose.com/slides/java/com.aspose.slides/moderncommentstatus/) constanten:

- `NotDefined` — er is geen specifieke moderne‑commentaarstatus gedefinieerd.
- `Active` — het commentaar is actief.
- `Resolved` — het commentaar is opgelost.
- `Closed` — het commentaar is gesloten.

Het voorbeeld verankert een modern commentaar aan de woorden “quarterly revenue” in de tekst van een rechthoek. Het berekent de nul‑gebaseerde startpositie uit de tekst en geeft deze door aan [setTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) en gebruikt [setTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) om het aantal geselecteerde tekens in te stellen. Na het aanroepen van [setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setStatus-byte-) met `Resolved` slaat het de presentatie op en opent deze opnieuw. De vier console‑controles moeten elk `true` afdrukken, waardoor wordt bevestigd dat het vorm‑anker, het tekstbereik en de status zijn behouden.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.ModernCommentStatus;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Date;

String outputFile = "modern_comment_text_anchor.pptx";
String shapeText = "Review the quarterly revenue forecast.";
String selectedText = "quarterly revenue";
int expectedSelectionStart = shapeText.indexOf(selectedText);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Point2F

loat commentPosition = new Point2D.Float(60, 60);
    IModernComment comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, new Date());
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length());
    comment.setStatus(ModernCommentStatus.Resolved);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IComment[] reopenedComments = reopenedSlide.getSlideComments(null);

    for (IComment reopenedComment : reopenedComments) {
        if (!(reopenedComment instanceof IModernComment)) {
            continue;
        }

        IModernComment modernComment = (IModernComment) reopenedComment;
        boolean shapeMatches = modernComment.getShape() != null && "Forecast text".equals(modernComment.getShape().getName());
        boolean selectionStartMatches = modernComment.getTextSelectionStart() == expectedSelectionStart;
        boolean selectionLengthMatches = modernComment.getTextSelectionLength() == selectedText.length();
        boolean statusMatches = modernComment.getStatus() == ModernCommentStatus.Resolved;

        System.out.println("Shape anchor preserved: " + shapeMatches);
        System.out.println("Text selection start preserved: " + selectionStartMatches);
        System.out.println("Text selection length preserved: " + selectionLengthMatches);
        System.out.println("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Bestaande moderne commentaren inspecteren**

Het voorbeeld vereist een bestaande presentatie met moderne commentaren en print hun tekst, status en anker‑details. Om dit te inspecteren, controleer welke commentaren [IModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/) implementeren, bekijk vervolgens [IModernComment.getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--), en [IModernComment.getStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getStatus--). Een `null` vorm duidt op een dia‑niveau commentaar. Voor een [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) anker identificeren de tekst‑selectiemethoden het bijbehorende bereik in het tekstvak van de vorm.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.IModernComment;
import com.aspose.slides.IShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("comments.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        IComment[] comments = slide.getSlideComments(null);
        for (IComment comment : comments) {
            if (!(comment instanceof IModernComment)) {
                continue;
            }

            IModernComment modernComment = (IModernComment) comment;
            System.out.println("Slide: " + slide.getSlideNumber());
            System.out.println("Text: " + modernComment.getText());
            System.out.println("Status: " + modernComment.getStatus());

            IShape shape = modernComment.getShape();
            if (shape == null) {
                System.out.println("Anchor: slide level");
            } else {
                System.out.println("Anchor shape: " + shape.getName());
                System.out.println("Anchor type: " + shape.getClass().getSimpleName());

                if (shape instanceof IAutoShape) {
                    System.out.println("Text selection start: " + modernComment.getTextSelectionStart());
                    System.out.println("Text selection length: " + modernComment.getTextSelectionLength());
                }
            }

            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Commentaren verwijderen**

Aspose.Slides for Java stelt u in staat om alle commentaren en hun auteurs uit een presentatie te verwijderen of geselecteerde commentaren te verwijderen terwijl de rest behouden blijft. De volgende voorbeelden tonen beide benaderingen en slaan de bijgewerkte presentatie op.

### **Alle commentaren en commentaarauteurs verwijderen**

Het voorbeeld opent een bestaande presentatie en roept [ICommentCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#clear--) aan voor elke auteur, daarna [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#clear--) om de auteurs zelf te verwijderen. De opgeslagen presentatie bevat geen commentaren en geen commentaarauteurs. Gebruik een presentatie met commentaren om de verwijdering te observeren.

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("example.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        author.getComments().clear();
    }

    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Specifieke commentaren verwijderen**

Het voorbeeld maakt twee commentaren op één dia en gebruikt [getSlideComments](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) om commentaren per auteur te vinden. Het verzamelt commentaren waarvan de tekst gelijk is aan “comment 1” voordat [ICommentCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-) wordt aangeroepen, om wijzigingen in de collectie tijdens de selectie te vermijden. De opgeslagen presentatie behoudt alleen “comment 2”.

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    Point2D.Float firstCommentPosition = new Point2D.Float(0.2f, 0.2f);
    Point2D.Float secondCommentPosition = new Point2D.Float(0.3f, 0.2f);
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors()) {
        List<IComment> commentsToRemove = new ArrayList<IComment>();
        IComment[] comments = slide.getSlideComments(commentAuthor);

        for (IComment comment : comments) {
            if ("comment 1".equals(comment.getText())) {
                commentsToRemove.add(comment);
            }
        }

        for (IComment comment : commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Ondersteunt Aspose.Slides een opgeloste status voor moderne commentaren?**

Ja. [IModernComment.getStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getStatus--) en [IModernComment.setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setStatus-byte-) benaderen een [ModernCommentStatus](https://reference.aspose.com/slides/java/com.aspose.slides/moderncommentstatus/) waarde, inclusief `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw worden gelezen nadat het bestand is heropend.

**Worden draden discussies (antwoordketens) ondersteund, en is er een limiet op de nesting?**

Ja. Elk commentaar kan zijn [parent comment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#getParentComment--) refereren, waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke limiet voor de diepte van de nesting.

**In welk coördinatensysteem is de positie van een commentaarmarker gedefinieerd op een dia?**

De marker‑positie wordt gedefinieerd door zwevend‑kommagetallen in het dia‑coördinatensysteem, waardoor u deze precies op de dia kunt plaatsen.