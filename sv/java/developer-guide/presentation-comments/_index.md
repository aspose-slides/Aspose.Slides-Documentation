---
title: Hantera presentationskommentarer i Java
linktitle: Presentationskommentarer
type: docs
weight: 100
url: /sv/java/presentation-comments/
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
- Java
- Aspose.Slides
description: "Hantera presentationskommentarer med Aspose.Slides för Java: lägg till, läs, redigera, svara på och ta bort kommentarer i PowerPoint-presentationer snabbt och enkelt."
---
## **Översikt**

Den här artikeln förklarar hur man hanterar presentationskommentarer med Aspose.Slides för Java. Den introducerar de viktigaste kommentarrelaterade typerna och demonstrerar hur man lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar och moderna kommentarer samt tar bort kommentarer från en presentation.

Exemplen täcker vanliga gransknings- och samarbets scenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentartext och metadata, bygga svarskedjor och ta bort valda kommentarer eller alla kommentarer.

I PowerPoint visas kommentarer som anteckningar på bilder. När du markerar en kommentar visas dess text och relaterad diskussion.

För att begära att kommentarer visas eller döljs när en presentation öppnas utan att ändra själva kommentarerna, se [Visa eller dölj kommentarer när en presentation öppnas](/slides/sv/java/presentation-view-properties/).

## **Varför lägga till kommentarer i presentationer?**

Du kan använda kommentarer för att ge feedback och samarbeta med kollegor när du granskar presentationer.

Aspose.Slides för Java tillhandahåller följande API:er för att arbeta med kommentarer:

* Klassen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) som ger åtkomst till presentationens kommentarförfattare.
* Gränssnittet [ICommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/) som representerar kommentarerna som är associerade med en enskild författare.
* Gränssnittet [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/) som ger information om en kommentar, inklusive dess författare, skapningstid, position och text.
* Klassen [CommentAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/commentauthor/) som ger information om en författare, inklusive namn, initialer och associerade kommentarer.

## **Lägg till bildkommentarer**

Exemplet skapar två bilder och registrerar en kommentarförfattare med [addAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-). Det använder [addComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-java.awt.geom.Point2D.Float-java.util.Date-) för att placera en kommentar på varje bild, hämtar sedan den första bildens kommentarer för den författaren med [getSlideComments](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-). Konsolen visar den första kommentarens text två gånger, vilket demonstrerar åtkomst både via bilden och författaren, och den sparade presentationen innehåller båda kommentarerna.

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

## **Hitta eller skapa en kommentarförfattare**

När en automatiserad granskning bearbetar samma presentation upprepade gånger, sök i samlingen som returneras av [getCommentAuthors](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getCommentAuthors--) innan du lägger till en författare. [findByNameAndInitials](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-) matchar både namn och initialer och returnerar en array med matchande författare, eller en tom array om inga matchningar finns. I kontrast söker [findByName](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-) bara på namn, oavsett initialer. Att anropa [addAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) med ett namn och initialer som redan finns i samlingen kastar ett undantag.

Exemplet kräver en presentationsfil med minst en bild. På var och en av två genomgångar återanvänder det den första matchande författaren, eller skapar en ny endast när resultatet är tomt. Om det finns flera matchningar väljs det första arrayelementet utan att slå samman eller ta bort de andra författarna. Därefter anropas [addComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-java.awt.geom.Point2D.Float-java.util.Date-) för den valda författaren och presentationen sparas. Den andra genomgången öppnar resultatet från den första och upprepar operationen.

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

Den andra genomgången lägger till en ytterligare kommentar utan att lägga till en ny författare eller ta bort befintliga kommentarer. Den slutliga filen, `review_pass_2.pptx`, innehåller både de nya kommentarerna och eventuella ursprungliga kommentarer. Återanvändning av en författare deduplicerar inte kommentarer: för att undvika att upprepade gånger lägga till samma kommentar, implementera separat dupliceringsdetektering innan du lägger till den.

## **Åtkomst till bildkommentarer**

Exemplet öppnar en befintlig presentation och läser samlingen som returneras av [getCommentAuthors](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getCommentAuthors--). För varje författare itererar det genom samlingen som returneras av [getComments](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthor/#getComments--) och skriver ut bildnummer, kommentartext, författarnamn och skapningstid. Ingångspresentationen måste innehålla kommentarer för att producera konsolutdata.

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

## **Svara på kommentarer**

En föräldrakommentar är den ursprungliga kommentaren högst upp i en svarshierarki. Metoderna [IComment.getParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#getParentComment--) och [IComment.setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) låter dig hämta eller sätta föräldern för en kommentar.

Exemplet skapar kommentarer från två författare och använder [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) för att bygga svar, inklusive ett svar på ett annat svar. Att skicka `null` till [getSlideComments](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) hämtar kommentarer från alla författare; konsolen indenterar varje post enligt dess djup i svarshierarkin. Exemplet sparar den kompletta diskussionen, anropar [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#remove--) på den första rotkommentaren och sparar en andra presentation där den kommentaren och dess svar har tagits bort.

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
* När metoden [IComment.remove](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#remove--) används för att ta bort en kommentar tas även alla svar på den kommentaren bort.
* Om [IComment.setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) skapar en cirkulär referens kastas ett [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxeditexception/) .
{{% /alert %}}

## **Lägg till moderna kommentarer**

Moderna kommentarer kan associeras med själva bilden, med en specifik form eller med ett textområde inne i en AutoShape. Metoden [ICommentCollection.addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) accepterar ett [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)‑argument utöver bilden och koordinaterna för kommentarmarkören.

När `null` skickas för form‑argumentet är kommentaren en bildnivåkommentar. Dess markör placeras enligt de medföljande koordinaterna, men den är inte knuten till någon specifik form, så [IModernComment.getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--) returnerar `null`. När en [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) anges, förankras kommentaren till den formen. Koordinaterna definierar fortfarande positionen för kommentarmarkören på bilden, medan form‑kopplingen kan hämtas via [IModernComment.getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--).

### **Förankra en modern kommentar till en form**

Exemplet anropar [addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) två gånger: en gång med en `null` form för en bildnivåkommentar och en gång med en rektangel som förankring. Läsning av [getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--) skriver ut `true` för bildnivåkommentarens null‑kontroll och `Revenue title` för den förankrade kommentaren. Båda kommentarerna sparas med presentationen.

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

### **Förankra kommentarer till olika formtyper**

Vilket bildobjekt som helst som implementerar [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) kan användas som formförankring. Vanliga exempel inkluderar [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/java/com.aspose.slides/iconnector/) och [IGraphicalObject](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobject/)‑instanser såsom diagram.

Exemplet använder [addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) för att associera en kommentar med var och en av fem formtyper: en AutoShape, en bildram, en grupp, en förbindelse och ett diagram. Bilden använder inbäddad bilddata, så ingen extern bild krävs. Varje kommentar har sin egen markörposition, och den sparade presentationen behåller alla fem formkopplingar.

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

### **Förankra en kommentar till text och ange dess status**

För en modern kommentar som är associerad med en [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/), ger [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) och [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) åtkomst till startpositionen för den markerade texten i formens textruta. [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) och [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) ger åtkomst till längden på markeringen. Tillsammans associerar dessa värden kommentaren med ett specifikt textområde inne i AutoShape.

Metoderna [IModernComment.getStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getStatus--) och [IModernComment.setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setStatus-byte-) ger åtkomst till ett värde från [ModernCommentStatus](https://reference.aspose.com/slides/java/com.aspose.slides/moderncommentstatus/)‑konstanterna:

- `NotDefined` — ingen specifik modern‑kommentarstatus är definierad.
- `Active` — kommentaren är aktiv.
- `Resolved` — kommentaren har lösts.
- `Closed` — kommentaren är stängd.

Exemplet förankrar en modern kommentar till orden "quarterly revenue" i en rektangels text. Det beräknar den nollbaserade startpositionen från texten och skickar den till [setTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) samt använder [setTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) för att sätta antalet markerade tecken. Efter att ha anropat [setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setStatus-byte-) med `Resolved` sparas och öppnas presentationen igen. De fyra konsollkontrollerna bör alla skriva ut `true`, vilket bekräftar att formförankringen, textområdet och statusen bevarades.

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
    Point2D.Float commentPosition = new Point2D.Float(60, 60);
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

### **Inspektera befintliga moderna kommentarer**

Exemplet kräver en befintlig presentation som innehåller moderna kommentarer och skriver ut deras text, status och förankringsdetaljer. För att inspektera den, kontrollera vilka kommentarer som implementerar [IModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/), granska sedan [IModernComment.getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--), och [IModernComment.getStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getStatus--). En `null` form indikerar en bildnivåkommentar. För en [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)‑förankring identifierar textmarkeringsmetoderna det associerade intervallet i formens textruta.

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

## **Ta bort kommentarer**

Aspose.Slides för Java låter dig ta bort alla kommentarer och deras författare från en presentation eller radera valda kommentarer medan resten behålls. Följande exempel demonstrerar båda metoderna och sparar den uppdaterade presentationen.

### **Ta bort alla kommentarer och kommentarförfattare**

Exemplet öppnar en befintlig presentation och anropar [ICommentCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#clear--) för varje författare, och sedan [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#clear--) för att ta bort själva författarna. Den sparade presentationen innehåller varken kommentarer eller kommentarförfattare. Använd en presentation som innehåller kommentarer för att observera borttagandet.

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

### **Ta bort specifika kommentarer**

Exemplet skapar två kommentarer på en bild och använder [getSlideComments](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) för att hitta kommentarer per författare. Det samlar kommentarer vars text är lika med "comment 1" innan [ICommentCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-) anropas, för att undvika förändringar i samlingen under urvalet. Den sparade presentationen behåller endast "comment 2".

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

**Stöder Aspose.Slides ett resolved‑status för moderna kommentarer?**

Ja. [IModernComment.getStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getStatus--) och [IModernComment.setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setStatus-byte-) ger åtkomst till ett [ModernCommentStatus](https://reference.aspose.com/slides/java/com.aspose.slides/moderncommentstatus/)‑värde, inklusive `Resolved`. Statusen lagras i presentationen och kan läsas igen efter att filen har öppnats på nytt.

**Stöds trådade diskussioner (svarskedjor) och finns det någon begränsning för nästlingsdjup?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#getParentComment--), vilket möjliggör svarskedjor. API:et definierar ingen specifik begränsning för hur djupt svaren kan nästla.

**I vilket koordinatsystem är en kommentarmärkas position definierad på en bild?**

Markörens position definieras av flyttal i bildens koordinatsystem, vilket gör det möjligt att placera den exakt på bilden.