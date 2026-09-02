---
title: "Hantera presentationskommentarer på Android"
linktitle: "Presentationskommentarer"
type: docs
weight: 100
url: /sv/androidjava/presentation-comments/
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
- Android
- Java
- Aspose.Slides
description: "Hantera presentationskommentarer med Aspose.Slides för Android via Java: lägg till, läs, redigera, svara på och ta bort kommentarer i PowerPoint-presentationer snabbt och enkelt."
---
## **Översikt**

Den här artikeln förklarar hur du hanterar presentationskommentarer med Aspose.Slides för Android via Java. Den introducerar de viktigaste typerna som rör kommentarer och visar hur du lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar och moderna kommentarer samt tar bort kommentarer från en presentation.

Exemplen täcker vanliga gransknings- och samarbets scenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentartext och metadata, bygga svarskedjor och ta bort valda kommentarer eller alla kommentarer.

I PowerPoint visas kommentarer som anteckningar på bilder. När du markerar en kommentar visas dess text och tillhörande diskussion.

## **Varför lägga till kommentarer i presentationer?**

Du kan använda kommentarer för att ge återkoppling och samarbeta med kollegor när du granskar presentationer.

Aspose.Slides för Android via Java tillhandahåller följande API:er för att arbeta med kommentarer:

* Klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) som ger åtkomst till presentationens kommentarförfattare.
* Gränssnittet [ICommentCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icommentcollection/) som representerar kommentarerna som är kopplade till en enskild författare.
* Gränssnittet [IComment](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icomment/) som ger information om en kommentar, inklusive dess författare, tidpunkt för skapande, position och text.
* Klassen [CommentAuthor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/commentauthor/) som ger information om en författare, inklusive namn, initialer och tillhörande kommentarer.

## **Lägg till bildkommentarer**

Följande exempel visar hur du lägger till kommentarer på bilder i en PowerPoint‑presentation:

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

## **Få åtkomst till bildkommentarer**

Följande exempel visar hur du får åtkomst till befintliga kommentarer i en PowerPoint‑presentation:

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

En föräldrakommentar är den ursprungliga kommentaren högst upp i en svarshierarki. Metoderna [IComment.getParentComment](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icomment/#getParentComment--) och [IComment.setParentComment](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) låter dig hämta eller ange föräldern för en kommentar.

Följande exempel visar hur du lägger till svar och undersöker den resulterande kommentarhierarkin:

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

* När metoden [IComment.remove](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icomment/#remove--) används för att ta bort en kommentar, tas alla svar på den kommentaren också bort.
* Om [IComment.setParentComment](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) skapar en cirkulär referens, kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxeditexception/).

{{% /alert %}}

## **Lägg till moderna kommentarer**

Moderna kommentarer kan vara kopplade till själva bilden, till en specifik form eller till ett textintervall i en AutoShape. Metoden [ICommentCollection.addModernComment](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) accepterar ett [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/)‑argument utöver bilden och koordinater för kommentarmarkören.

När `null` skickas för shape‑argumentet är kommentaren en bildnivå‑kommentar. Dess markör placeras enligt de angivna koordinaterna, men den är inte knuten till någon specifik form, så [IModernComment.getShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imoderncomment/#getShape--) returnerar `null`. När en [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/) tillhandahålls, förankras kommentaren till den formen. Koordinaterna definierar fortfarande positionen för kommentarmarkören på bilden, medan formkopplingen kan hämtas via [IModernComment.getShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imoderncomment/#getShape--).

### **Förankra en modern kommentar till en form**

Följande exempel skapar både en bildnivå‑modern kommentar och en modern kommentar förankrad till en specifik AutoShape. Det läser sedan den kopplade formen från varje kommentar.

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

### **Förankra kommentarer till olika formtyper**

Alla bildobjekt som implementerar [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/) kan användas som formankare. Vanliga exempel inkluderar [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iconnector/) och [IGraphicalObject](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/igraphicalobject/)-instanser såsom diagram.

Följande exempel skapar flera vanliga formtyper och kopplar en modern kommentar till var och en.

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

### **Förankra en kommentar till text och ange dess status**

För en modern kommentar som är kopplad till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/), ger [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) och [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) åtkomst till startpositionen för den markerade texten i formens textram. [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) och [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) ger åtkomst till urvalets längd. Tillsammans associerar dessa värden kommentaren med ett specifikt textintervall i AutoShape.

Metoderna [IModernComment.getStatus](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imoderncomment/#getStatus--) och [IModernComment.setStatus](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) ger åtkomst till ett värde från konstanten [ModernCommentStatus](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — ingen specifik modern kommentarsstatus är definierad.
- `Active` — kommentaren är aktiv.
- `Resolved` — kommentaren har markerats som löst.
- `Closed` — kommentaren är stängd.

Följande exempel skapar en formförankrad modern kommentar, kopplar den till ett texturval, markerar den som löst, sparar presentationen och verifierar värdena efter att filen har öppnats igen.

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

### **Inspektera befintliga moderna kommentarer**

För att inspektera en befintlig presentation, kontrollera vilka kommentarer som implementerar [IModernComment](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imoderncomment/), granska sedan [IModernComment.getShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) och [IModernComment.getStatus](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imoderncomment/#getStatus--). En `null`‑form indikerar en bildnivå‑kommentar. För ett [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/)-ankare identifierar texturvals‑metoderna det associerade intervallet i formens textram.

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

### **Ta bort alla kommentarer och kommentarförfattare**

Följande exempel visar hur du tar bort alla kommentarer och kommentarförfattare från en presentation:

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

Följande exempel visar hur du tar bort specifika kommentarer från en bild:

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

**Stöder Aspose.Slides ett löst‑status för moderna kommentarer?**

Ja. [IModernComment.getStatus](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imoderncomment/#getStatus--) och [IModernComment.setStatus](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) ger åtkomst till ett [ModernCommentStatus](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/moderncommentstatus/)-värde, inklusive `Resolved`. Statusen lagras i presentationen och kan läsas igen efter att filen har öppnats på nytt.

**Stöds trådade diskussioner (svarskedjor), och finns det någon begränsning för nästlingsdjup?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icomment/#getParentComment--), vilket möjliggör svarskedjor. API:et definierar ingen specifik gräns för nästlingsdjup.

**I vilket koordinatsystem definieras en kommentarmarkörs position på en bild?**

Markörens position definieras av flyttal‑koordinater i bildens koordinatsystem, vilket gör att du kan placera den exakt där du vill på bilden.