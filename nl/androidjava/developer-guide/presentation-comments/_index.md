---
title: Beheer presentatieopmerkingen op Android
linktitle: Presentatieopmerkingen
type: docs
weight: 100
url: /nl/androidjava/presentation-comments/
keywords:
- opmerking
- moderne opmerking
- PowerPoint-opmerkingen
- presentatieopmerkingen
- dia-opmerkingen
- opmerking toevoegen
- opmerking benaderen
- opmerking bewerken
- opmerking beantwoorden
- opmerking verwijderen
- opmerking wissen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer presentatieopmerkingen met Aspose.Slides voor Android via Java: voeg toe, lees, bewerk, beantwoord en verwijder opmerkingen in PowerPoint‑presentaties snel en eenvoudig."
---
## **Overzicht**

Dit artikel legt uit hoe u opmerking­annotaties in een presentatie kunt beheren met Aspose.Slides voor Android via Java. Het introduceert de belangrijkste commentaargerelateerde types en toont hoe u opmerkingen aan dia's kunt toevoegen, bestaande opmerkingen kunt benaderen, met antwoorden en moderne opmerkingen kunt werken, en opmerkingen uit een presentatie kunt verwijderen.

De voorbeelden omvatten veelvoorkomende beoordelings‑ en samenwerkingsscenario’s in PowerPoint, zoals het toewijzen van opmerkingen aan auteurs, het lezen van de opmerkingstekst en metadata, het opbouwen van antwoordketens, en het verwijderen van geselecteerde opmerkingen of alle opmerkingen.

In PowerPoint verschijnen opmerkingen als annotaties op dia's. Het selecteren van een opmerking toont de tekst en de bijbehorende discussie.

Om aan te geven dat opmerkingen moeten worden getoond of verborgen wanneer een presentatie wordt geopend zonder de opmerkingen zelf te wijzigen, zie [Opmerkingen weergeven of verbergen bij het openen van een presentatie](/slides/nl/androidjava/presentation-view-properties/)​.

## **Waarom opmerkingen aan presentaties toevoegen?**

U kunt opmerkingen gebruiken om feedback te geven en samen te werken met collega’s bij het beoordelen van presentaties.

Aspose.Slides voor Android via Java biedt de volgende API’s voor het werken met opmerkingen:

* De klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) die toegang geeft tot de commentaurauteurs van de presentatie.
* De interface [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/) die de opmerkingen vertegenwoordigt die aan een individuele auteur zijn gekoppeld.
* De interface [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/) die informatie over een opmerking biedt, inclusief auteur, aanmaaktijd, positie en tekst.
* De klasse [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentauthor/) die informatie over een auteur geeft, inclusief naam, initialen en gekoppelde opmerkingen.

## **Opmerkingen aan dia's toevoegen**

Het voorbeeld maakt twee dia's aan en registreert een commentaurauteur met [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-). Het gebruikt [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) om één opmerking op elke dia te plaatsen, waarna de eerste dia‑opmerkingen voor die auteur worden opgehaald met [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-). De console geeft de tekst van de eerste opmerking twee keer weer, wat aantoont dat men zowel via de dia als via de auteur toegang heeft, en de opgeslagen presentatie bevat beide opmerkingen.

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    PointF position = new PointF(0.2f, 0.2f);
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

## **Een commentaurauteur zoeken of aanmaken**

Wanneer een geautomatiseerde beoordeling dezelfde presentatie herhaaldelijk verwerkt, doorzoek dan de collectie die wordt geretourneerd door [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) vóór het toevoegen van een auteur. [findByNameAndInitials](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-) vergelijkt zowel de naam als de initialen en retourneert een array met overeenkomende auteurs, of een lege array als er geen overeenkomsten zijn. In tegenstelling hiermee zoekt [findByName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-) alleen op naam, ongeacht de initialen. Het aanroepen van [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) met een naam en initialen die al in de collectie aanwezig zijn, veroorzaakt een uitzondering.

Het voorbeeld vereist een presentatiebestand met minstens één dia. Tijdens elk van de twee doorlopen wordt de eerst gevonden auteur hergebruikt, of alleen aangemaakt wanneer het resultaat leeg is. Als er meerdere overeenkomsten zijn, wordt het eerste array‑element gekozen zonder de andere auteurs samen te voegen of te verwijderen. Vervolgens wordt [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) aangeroepen voor de geselecteerde auteur en wordt de presentatie opgeslagen. De tweede doorloop opent de uitvoer van de eerste doorloop en herhaalt de bewerking.

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

final String authorName = "Reviewer";
final String authorInitials = "RV";

String inputFile = "input.pptx";
PointF position = new PointF(20, 20);

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

De tweede doorloop voegt een extra opmerking toe zonder een extra auteur toe te voegen of bestaande opmerkingen te verwijderen. Het uiteindelijke bestand, `review_pass_2.pptx`, bevat beide nieuwe opmerkingen naast eventuele oorspronkelijke opmerkingen. Het hergebruiken van een auteur leidt niet tot deduplicatie van opmerkingen: implementeer een aparte duplicaatdetectie vóór het toevoegen om te voorkomen dat dezelfde opmerking herhaaldelijk wordt toegevoegd.

## **Dia‑opmerkingen benaderen**

Het voorbeeld opent een bestaande presentatie en leest de collectie die wordt geretourneerd door [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--). Voor elke auteur loopt het door de collectie die wordt geretourneerd door [getComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthor/#getComments--) en print het dia‑nummer, de opmerkingstekst, de auteursnaam en de aanmaaktijd. De invoerpresentatie moet opmerkingen bevatten om console‑output te genereren.

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

## **Antwoorden op opmerkingen**

Een bovenliggende opmerking is de oorspronkelijke opmerking bovenaan een antwoordhiërarchie. De methoden [IComment.getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) en [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) stellen u in staat respectievelijk de bovenliggende opmerking op te halen of in te stellen.

Het voorbeeld maakt opmerkingen van twee auteurs en gebruikt [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) om antwoorden te bouwen, inclusief een antwoord op een ander antwoord. Het doorgeven van `null` aan [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) haalt opmerkingen op van alle auteurs; de console geeft elke vermelding een inspringing volgens de diepte in de antwoordhiërarchie. Het voorbeeld slaat de volledige discussie op, roept [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) aan op de eerste wortelopmerking, en slaat een tweede presentatie op waarbij die opmerking en zijn antwoorden verwijderd zijn.

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    PointF position = new PointF(10, 10);
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

* Wanneer de methode [IComment.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) wordt gebruikt om een opmerking te verwijderen, worden ook alle antwoorden op die opmerking verwijderd.
* Als [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) een circulaire verwijzing creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/) gegooid.

{{% /alert %}}

## **Moderne opmerkingen toevoegen**

Moderne opmerkingen kunnen worden gekoppeld aan de dia zelf, aan een specifiek vormobject, of aan een tekstreeks binnen een AutoShape. De methode [ICommentCollection.addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) accepteert een argument van het type [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) naast de dia‑ en markeer‑coördinaten.

Wanneer `null` wordt doorgegeven voor het vorm‑argument, betreft de opmerking een dia‑niveau opmerking. De marker wordt gepositioneerd op basis van de opgegeven coördinaten, maar is niet gekoppeld aan een specifieke vorm, zodat [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) `null` retourneert. Wanneer er een [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) wordt opgegeven, wordt de opmerking verankerd aan die vorm. De coördinaten bepalen nog steeds de positie van de opmerkingmarker op de dia, terwijl de vormkoppeling kan worden opgehaald via [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--).

### **Een moderne opmerking aan een vorm verankeren**

Het voorbeeld roept [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) twee keer aan: eenmaal met een `null` vorm voor een dia‑niveau opmerking en eenmaal met een rechthoek als anker. Het uitlezen van [getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) print `true` voor de null‑check van de dia‑niveau opmerking en `Revenue title` voor de verankerde opmerking. Beide opmerkingen worden samen met de presentatie opgeslagen.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    PointF slideCommentPosition = new PointF(20, 20);
    PointF shapeCommentPosition = new PointF(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Opmerkingen aan verschillende vormtypen verankeren**

Elk dia‑object dat [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) implementeert, kan worden gebruikt als anker. Veelvoorkomende voorbeelden zijn [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnector/) en [IGraphicalObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobject/) zoals grafieken.

Het voorbeeld gebruikt [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) om een opmerking te koppelen aan elk van vijf vormtypen: een AutoShape, een afbeelding, een groep, een connector en een grafiek. De afbeelding maakt gebruik van ingebedde beeldgegevens, zodat er geen extern beeld nodig is. Elke opmerking heeft een eigen marker‑positie, en de opgeslagen presentatie behoudt alle vijf vormkoppelingen.

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
import android.graphics.PointF;
import android.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");

    PointF autoShapeCommentPosition = new PointF(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.decode(imageBase64, Base64.DEFAULT);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    PointF pictureCommentPosition = new PointF(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    PointF groupCommentPosition = new PointF(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    PointF connectorCommentPosition = new PointF(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    PointF chartCommentPosition = new PointF(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Een opmerking aan tekst verankeren en de status instellen**

Voor een moderne opmerking gekoppeld aan een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/), geven [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) en [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) de startpositie van de geselecteerde tekst in het tekstvak van de vorm terug. [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) en [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) geven de lengte van de selectie terug. Samen koppelen deze waarden de opmerking aan een specifiek tekstbereik binnen de AutoShape.

De methoden [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) en [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) benaderen een waarde uit de constanten van [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — er is geen specifieke moderne‑opmerkingsstatus gedefinieerd.
- `Active` — de opmerking is actief.
- `Resolved` — de opmerking is opgelost.
- `Closed` — de opmerking is gesloten.

Het voorbeeld verankert een moderne opmerking aan de woorden “quarterly revenue” in de tekst van een rechthoek. Het berekent de null‑gebaseerde startpositie uit de tekst en geeft die door aan [setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-), en gebruikt [setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) om het aantal geselecteerde tekens in te stellen. Na het aanroepen van [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) met `Resolved`, wordt de presentatie opgeslagen en opnieuw geopend. De vier console‑controles zouden elk `true` moeten afdrukken, waarmee wordt bevestigd dat de vormverankering, het tekstbereik en de status behouden zijn.

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
import android.graphics.PointF;
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
    PointF commentPosition = new PointF(60, 60);
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

### **Bestaande moderne opmerkingen inspecteren**

Het voorbeeld vereist een bestaande presentatie met moderne opmerkingen en drukt hun tekst, status en anker‑details af. Om dit te inspecteren, controleert u welke opmerkingen [IModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/) implementeren, en bekijkt vervolgens [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--), en [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--). Een `null` vorm duidt op een dia‑niveau opmerking. Voor een anker aan een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) identificeert de tekst‑selectiemethode het bijbehorende bereik in het tekstvak van de vorm.

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

## **Opmerkingen verwijderen**

Aspose.Slides voor Android via Java laat u alle opmerkingen en hun auteurs uit een presentatie verwijderen of geselecteerde opmerkingen verwijderen terwijl de rest behouden blijft. De volgende voorbeelden tonen beide benaderingen en slaan de bijgewerkte presentatie op.

### **Alle opmerkingen en commentaurauteurs verwijderen**

Het voorbeeld opent een bestaande presentatie en roept [ICommentCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#clear--) aan voor elke auteur, waarna [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#clear--) wordt aangeroepen om de auteurs zelf te verwijderen. De opgeslagen presentatie bevat geen opmerkingen en geen commentaurauteurs meer. Gebruik een presentatie met opmerkingen om de verwijdering te observeren.

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

### **Specifieke opmerkingen verwijderen**

Het voorbeeld maakt twee opmerkingen op één dia en gebruikt [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) om opmerkingen per auteur te vinden. Het verzamelt de opmerkingen waarvan de tekst gelijk is aan “comment 1” voordat [ICommentCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-) wordt aangeroepen, waardoor wijzigingen in de collectie tijdens de selectie worden vermeden. De opgeslagen presentatie bevat alleen “comment 2”.

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    PointF firstCommentPosition = new PointF(0.2f, 0.2f);
    PointF secondCommentPosition = new PointF(0.3f, 0.2f);
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

**Ondersteunt Aspose.Slides een opgeloste status voor moderne opmerkingen?**

Ja. [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) en [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) benaderen een [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/)‑waarde, inclusief `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw worden uitgelezen nadat het bestand opnieuw is geopend.

**Worden discussies met antwoorden (reply‑chains) ondersteund, en is er een limiet voor nesting?**

Ja. Elke opmerking kan naar zijn [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) verwijzen, waardoor antwoordketens mogelijk zijn. De API definieert geen specifiek limiet voor de diepte van de nesting.

**In welk coördinatensysteem wordt de positie van een opmerkingmarker op een dia gedefinieerd?**

De markerpositie wordt gedefinieerd door zwevende‑komma‑coördinaten in het dia‑coördinatensysteem, zodat u de marker nauwkeurig op de dia kunt plaatsen.