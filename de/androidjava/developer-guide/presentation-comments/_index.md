---
title: Präsentationskommentare auf Android verwalten
linktitle: Präsentationskommentare
type: docs
weight: 100
url: /de/androidjava/presentation-comments/
keywords:
- Kommentar
- moderner Kommentar
- PowerPoint-Kommentare
- Präsentationskommentare
- Folienkommentare
- Kommentar hinzufügen
- Kommentar abrufen
- Kommentar bearbeiten
- Kommentar beantworten
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie Präsentationskommentare mit Aspose.Slides für Android über Java: Kommentare in PowerPoint-Präsentationen schnell und einfach hinzufügen, lesen, bearbeiten, beantworten und entfernen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Kommentare in einer Präsentation mit Aspose.Slides für Android über Java verwaltet werden. Er stellt die wichtigsten kommentarbezogenen Typen vor und demonstriert, wie Kommentare zu Folien hinzugefügt, vorhandene Kommentare abgerufen, mit Antworten und modernen Kommentaren gearbeitet und Kommentare aus einer Präsentation entfernt werden.

Die Beispiele decken gängige Überprüfungs‑ und Zusammenarbeitsszenarien in PowerPoint ab, z. B. das Zuweisen von Kommentaren zu Autoren, das Lesen von Kommentartexten und Metadaten, das Erstellen von Antwortketten sowie das Entfernen ausgewählter Kommentare oder aller Kommentare.

In PowerPoint erscheinen Kommentare als Anmerkungen auf Folien. Das Auswählen eines Kommentars zeigt dessen Text und die zugehörige Diskussion an.

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie können Kommentare verwenden, um Feedback zu geben und mit Kollegen zusammenzuarbeiten, wenn Sie Präsentationen prüfen.

Aspose.Slides für Android über Java stellt die folgenden APIs für die Arbeit mit Kommentaren bereit:

* Die [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Klasse, die Zugriff auf die Kommentarautoren der Präsentation bietet.
* Das [ICommentCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icommentcollection/)‑Interface, das die Kommentare eines einzelnen Autors repräsentiert.
* Das [IComment](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icomment/)‑Interface, das Informationen zu einem Kommentar bereitstellt, einschließlich Autor, Erstellungszeit, Position und Text.
* Die [CommentAuthor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/commentauthor/)‑Klasse, die Informationen zu einem Autor liefert, darunter Name, Initialen und zugehörige Kommentare.

## **Folienkommentare hinzufügen**

Das folgende Beispiel zeigt, wie Kommentare zu Folien in einer PowerPoint‑Präsentation hinzugefügt werden:

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

## **Zugriff auf Folienkommentare**

Das folgende Beispiel zeigt, wie vorhandene Kommentare in einer PowerPoint‑Präsentation abgerufen werden:

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

## **Antworten zu Kommentaren**

Ein übergeordneter Kommentar ist der ursprüngliche Kommentar an der Spitze einer Antwort‑Hierarchie. Die Methoden [IComment.getParentComment](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icomment/#getParentComment--) und [IComment.setParentComment](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) ermöglichen das Abrufen bzw. Festlegen des übergeordneten Kommentars.

Das folgende Beispiel zeigt, wie Antworten hinzugefügt und die resultierende Kommentar‑Hierarchie untersucht werden:

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

* Wenn die Methode [IComment.remove](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icomment/#remove--) verwendet wird, um einen Kommentar zu löschen, werden auch alle Antworten auf diesen Kommentar gelöscht.
* Wenn [IComment.setParentComment](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) eine zirkuläre Referenz erzeugt, wird eine [PptxEditException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxeditexception/) ausgelöst.

{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Moderne Kommentare können der Folie selbst, einer bestimmten Form oder einem Textbereich innerhalb einer AutoShape zugeordnet werden. Die Methode [ICommentCollection.addModernComment](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) akzeptiert ein [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/)-Argument zusätzlich zu den Folien‑ und Marker‑Koordinaten.

Wird für das Shape‑Argument `null` übergeben, handelt es sich um einen Folien‑Kommentar. Sein Marker wird anhand der übergebenen Koordinaten positioniert, ist jedoch keiner bestimmten Form zugeordnet, sodass [IModernComment.getShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imoderncomment/#getShape--) `null` zurückgibt. Wird ein [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/) angegeben, ist der Kommentar an diese Form verankert. Die Koordinaten bestimmen weiterhin die Position des Kommentar‑Markers auf der Folie, während die Form‑Zuordnung über [IModernComment.getShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imoderncomment/#getShape--) abgerufen werden kann.

### **Einen modernen Kommentar an einer Form verankern**

Das folgende Beispiel erstellt sowohl einen Folien‑Kommentar als auch einen an einer bestimmten AutoShape verankerten modernen Kommentar und liest anschließend die zugehörige Form jedes Kommentars aus:

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

### **Kommentare an verschiedenen Formtypen verankern**

Jedes Folienobjekt, das [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/) implementiert, kann als Anker verwendet werden. Übliche Beispiele sind [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iconnector/) und [IGraphicalObject](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/igraphicalobject/)-Instanzen wie Diagramme.

Das folgende Beispiel erstellt mehrere gängige Formtypen und weist jedem einen modernen Kommentar zu:

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

### **Einen Kommentar an Text verankern und dessen Status festlegen**

Für einen modernen Kommentar, der einer [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) zugeordnet ist, ermöglichen [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) und [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) den Zugriff auf die Startposition des ausgewählten Textes im Textfeld der Form. [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) und [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) geben die Länge der Auswahl zurück. Zusammen verknüpfen diese Werte den Kommentar mit einem bestimmten Textbereich innerhalb der AutoShape.

Die Methoden [IModernComment.getStatus](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imoderncomment/#getStatus--) und [IModernComment.setStatus](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) greifen auf einen Wert der Konstanten [ModernCommentStatus](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/moderncommentstatus/) zu:

- `NotDefined` — kein spezifischer moderner Kommentar‑Status ist definiert.
- `Active` — der Kommentar ist aktiv.
- `Resolved` — der Kommentar wurde gelöst.
- `Closed` — der Kommentar ist geschlossen.

Das folgende Beispiel erstellt einen an einer Form verankerten modernen Kommentar, ordnet ihn einer Textauswahl zu, markiert ihn als gelöst, speichert die Präsentation und prüft die Werte nach dem erneuten Öffnen der Datei:

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

### **Vorhandene moderne Kommentare untersuchen**

Um eine vorhandene Präsentation zu untersuchen, prüfen Sie, welche Kommentare das Interface [IModernComment](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imoderncomment/) implementieren, und betrachten Sie dann [IModernComment.getShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) sowie [IModernComment.getStatus](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imoderncomment/#getStatus--). Ein `null`‑Shape bedeutet einen Folien‑Kommentar. Bei einem [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/)-Anker identifizieren die Textauswahl‑Methoden den zugehörigen Bereich im Textfeld der Form.

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

## **Kommentare entfernen**

### **Alle Kommentare und Kommentarautoren entfernen**

Das folgende Beispiel zeigt, wie alle Kommentare und Kommentarautoren aus einer Präsentation entfernt werden:

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

### **Bestimmte Kommentare entfernen**

Das folgende Beispiel zeigt, wie bestimmte Kommentare von einer Folie entfernt werden:

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

**Unterstützt Aspose.Slides einen gelösten Status für moderne Kommentare?**

Ja. Die Methoden [IModernComment.getStatus](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imoderncomment/#getStatus--) und [IModernComment.setStatus](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) greifen auf einen Wert von [ModernCommentStatus](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/moderncommentstatus/) zu, einschließlich `Resolved`. Der Status wird in der Präsentation gespeichert und kann nach erneutem Öffnen der Datei wieder ausgelesen werden.

**Werden verschachtelte Diskussionen (Antwortketten) unterstützt und gibt es ein Begrenzungsniveau?**

Ja. Jeder Kommentar kann auf seinen [parent comment](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icomment/#getParentComment--) verweisen, wodurch Antwortketten möglich sind. Die API definiert kein spezifisches Begrenzungsniveau für die Verschachtelungstiefe.

**In welchem Koordinatensystem ist die Position eines Kommentar‑Markers auf einer Folie definiert?**

Die Marker‑Position wird durch Gleitkomma‑Koordinaten im Folien‑Koordinatensystem definiert, sodass Sie sie präzise auf der Folie positionieren können.