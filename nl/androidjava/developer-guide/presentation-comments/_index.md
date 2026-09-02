---
title: Beheer presentatie‑commentaren op Android
linktitle: Presentatiecommentaren
type: docs
weight: 100
url: /nl/androidjava/presentation-comments/
keywords:
- commentaar
- modern commentaar
- PowerPoint‑commentaren
- presentatie‑commentaren
- dia‑commentaren
- commentaar toevoegen
- commentaar benaderen
- commentaar bewerken
- commentaar beantwoorden
- commentaar verwijderen
- commentaar wissen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer presentatie‑commentaren met Aspose.Slides voor Android via Java: voeg commentaren toe, lees ze, bewerk ze, beantwoord ze en verwijder commentaren in PowerPoint‑presentaties snel en eenvoudig."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatie‑commentaren kunt beheren met Aspose.Slides voor Android via Java. Het introduceert de belangrijkste commentaar‑gerelateerde types en toont hoe u commentaren aan dia's kunt toevoegen, bestaande commentaren kunt benaderen, met antwoorden en moderne commentaren kunt werken, en commentaren uit een presentatie kunt verwijderen.

De voorbeelden omvatten veelvoorkomende beoordelings‑ en samenwerkingsscenario's in PowerPoint, zoals commentaren toewijzen aan auteurs, commentaartekst en metadata lezen, antwoordketens opbouwen en geselecteerde commentaren of alle commentaren verwijderen.

In PowerPoint verschijnen commentaren als annotaties op dia's. Het selecteren van een commentaar toont de tekst en de bijbehorende discussie.

## **Waarom commentaren aan presentaties toevoegen?**

U kunt commentaren gebruiken om feedback te geven en samen te werken met collega's bij het beoordelen van presentaties.

Aspose.Slides voor Android via Java biedt de volgende API's voor het werken met commentaren:

* De [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse, die toegang biedt tot de commentaarauteurs van de presentatie.
* De [ICommentCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icommentcollection/) interface, die de commentaren vertegenwoordigt die aan een specifieke auteur gekoppeld zijn.
* De [IComment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icomment/) interface, die informatie over een commentaar geeft, waaronder de auteur, aanmaaktijd, positie en tekst.
* De [CommentAuthor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/commentauthor/) klasse, die informatie over een auteur biedt, inclusief naam, initialen en bijbehorende commentaren.

## **Dia‑commentaren toevoegen**

Het volgende voorbeeld laat zien hoe u commentaren aan dia's kunt toevoegen in een PowerPoint‑presentatie:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
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

        ICommentCollection authorComments = firstComment.getAuthor().getComments();
        String commentText = authorComments.get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dia‑commentaren benaderen**

Het volgende voorbeeld laat zien hoe u bestaande commentaren in een PowerPoint‑presentatie kunt benaderen:

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

## **Beantwoorden van commentaren**

Een hoofdcommentaar is het originele commentaar bovenaan een antwoordhiërarchie. De methoden [IComment.getParentComment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icomment/#getParentComment--) en [IComment.setParentComment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) stellen u in staat de ouder van een commentaar op te halen of in te stellen.

Het volgende voorbeeld laat zien hoe u antwoorden kunt toevoegen en de resulterende commentaarihiërarchie kunt inspecteren:

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

    ICommentAuthor author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    IComment comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

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

    comment1.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Wanneer de [IComment.remove](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icomment/#remove--) methode wordt gebruikt om een commentaar te verwijderen, worden ook alle antwoorden op dat commentaar verwijderd.
* Als [IComment.setParentComment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) een circulaire referentie creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxeditexception/) gegooid.
{{% /alert %}}

## **Moderne commentaren toevoegen**

Moderne commentaren kunnen worden gekoppeld aan de dia zelf, aan een specifieke vorm, of aan een tekstreeks binnen een AutoShape. De methode [ICommentCollection.addModernComment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) accepteert een [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) argument naast de dia‑ en commentaar‑marker‑coördinaten.

Wanneer `null` wordt doorgegeven voor het vorm‑argument, is het commentaar een dia‑niveau commentaar. De marker wordt gepositioneerd op basis van de opgegeven coördinaten, maar het is niet gekoppeld aan een specifieke vorm, dus [IModernComment.getShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imoderncomment/#getShape--) retourneert `null`. Wanneer een [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) wordt opgegeven, wordt het commentaar aan die vorm verankerd. De coördinaten bepalen nog steeds de positie van de commentaar‑marker op de dia, terwijl de vormkoppeling kan worden opgehaald via [IModernComment.getShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imoderncomment/#getShape--).

### **Een modern commentaar aan een vorm verankeren**

Het volgende voorbeeld maakt zowel een modern commentaar op dia‑niveau als een modern commentaar verankerd aan een specifieke AutoShape. Vervolgens leest het de gekoppelde vorm uit elk commentaar.

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

### **Commentaren verankeren aan verschillende vormtypen**

Elk dia‑object dat de [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) interface implementeert, kan worden gebruikt als vorm‑anker. Veelvoorkomende voorbeelden zijn [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iconnector/) en [IGraphicalObject](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/igraphicalobject/) instanties zoals grafieken.

Het volgende voorbeeld maakt verschillende veelvoorkomende vormtypen en koppelt een modern commentaar aan elk van hen.

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
import java.util.Base64;
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
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
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

### **Commentaar aan tekst verankeren en de status instellen**

Voor een modern commentaar gekoppeld aan een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/), geven [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) en [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) de startpositie van de geselecteerde tekst in het tekstframe van de vorm terug. [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) en [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) geven de lengte van de selectie terug. Samen koppelen deze waarden het commentaar aan een specifieke tekstreeks binnen de AutoShape.

De methoden [IModernComment.getStatus](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imoderncomment/#getStatus--) en [IModernComment.setStatus](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) geven een waarde uit de [ModernCommentStatus](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/moderncommentstatus/) constanten terug:

- `NotDefined` — geen specifieke modern‑commentaarstatus is gedefinieerd.
- `Active` — het commentaar is actief.
- `Resolved` — het commentaar is opgelost.
- `Closed` — het commentaar is gesloten.

Het volgende voorbeeld maakt een vorm‑verankerd modern commentaar, koppelt het aan een tekstreeks, markeert het als opgelost, slaat de presentatie op en controleert de waarden na het heropenen van het bestand.

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

### **Bestaande moderne commentaren inspecteren**

Om een bestaande presentatie te inspecteren, controleert u welke commentaren de [IModernComment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imoderncomment/) interface implementeren, en bekijkt u vervolgens [IModernComment.getShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) en [IModernComment.getStatus](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imoderncomment/#getStatus--). Een `null` vorm duidt op een commentaar op dia‑niveau. Voor een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) anker identificeren de tekst‑selectiemethoden de bijbehorende reeks in het tekstframe van de vorm.

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

### **Alle commentaren en commentaarauteurs verwijderen**

Het volgende voorbeeld laat zien hoe u alle commentaren en commentaarauteurs uit een presentatie kunt verwijderen:

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

Het volgende voorbeeld laat zien hoe u specifieke commentaren van een dia kunt verwijderen:

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

## **Veelgestelde vragen**

**Ondersteunt Aspose.Slides een opgeloste status voor moderne commentaren?**

Ja. [IModernComment.getStatus](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imoderncomment/#getStatus--) en [IModernComment.setStatus](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) geven een [ModernCommentStatus](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/moderncommentstatus/) waarde terug, inclusief `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw worden uitgelezen nadat het bestand is heropend.

**Worden discussies in threads (antwoordketens) ondersteund, en is er een limiet op de diepte?**

Ja. Elk commentaar kan verwijzen naar zijn [parent comment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icomment/#getParentComment--), waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke limiet voor de diepte van de nesting.

**In welk coördinatensysteem is de positie van een commentaarmarkering op een dia gedefinieerd?**

De marker‑positie wordt gedefinieerd door zwevende‑komma‑coördinaten in het dia‑coördinatensysteem, waardoor u de marker nauwkeurig op de dia kunt plaatsen.