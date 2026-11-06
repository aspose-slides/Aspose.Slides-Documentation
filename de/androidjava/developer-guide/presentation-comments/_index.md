---
title: Verwalten von Präsentationskommentaren auf Android
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

Dieser Artikel erklärt, wie man Präsentationskommentare mit Aspose.Slides für Android über Java verwaltet. Er stellt die wichtigsten kommentarbezogenen Typen vor und zeigt, wie man Kommentare zu Folien hinzufügt, vorhandene Kommentare abruft, mit Antworten und modernen Kommentaren arbeitet und Kommentare aus einer Präsentation entfernt.

Die Beispiele decken gängige Überprüfungs‑ und Zusammenarbeitsszenarien in PowerPoint ab, z. B. das Zuordnen von Kommentaren zu Autoren, das Lesen von Kommentartexten und Metadaten, das Erstellen von Antwortketten und das Entfernen ausgewählter Kommentare oder aller Kommentare.

In PowerPoint erscheinen Kommentare als Anmerkungen auf Folien. Das Auswählen eines Kommentars zeigt dessen Text und die zugehörige Diskussion an.

Um zu steuern, ob Kommentare beim Öffnen einer Präsentation angezeigt oder ausgeblendet werden sollen, ohne die Kommentare selbst zu ändern, siehe [Anzeigen oder Ausblenden von Kommentaren beim Öffnen einer Präsentation](/slides/de/androidjava/presentation-view-properties/).

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie können Kommentare verwenden, um Feedback zu geben und mit Kollegen zusammenzuarbeiten, wenn Sie Präsentationen prüfen.

Aspose.Slides für Android über Java stellt die folgenden APIs für die Arbeit mit Kommentaren bereit:

* Die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse, die Zugriff auf die Kommentarautoren der Präsentation ermöglicht.
* Das [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/)‑Interface, das die Kommentare eines einzelnen Autors repräsentiert.
* Das [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/)‑Interface, das Informationen zu einem Kommentar bereitstellt, einschließlich Autor, Erstellungszeit, Position und Text.
* Die [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentauthor/)‑Klasse, die Informationen zu einem Autor liefert, einschließlich Name, Initialen und zugehöriger Kommentare.

## **Kommentare zu Folien hinzufügen**

Das Beispiel erstellt zwei Folien und registriert einen Kommentarautor mit [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-). Es verwendet [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) , um auf jeder Folie einen Kommentar zu platzieren, und ruft anschließend die Kommentare der ersten Folie für diesen Autor mit [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) ab. Die Konsole gibt den Text des ersten Kommentars zweimal aus, wodurch der Zugriff sowohl über die Folie als auch über den Autor demonstriert wird, und die gespeicherte Präsentation enthält beide Kommentare.

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

## **Einen Kommentarautor finden oder erstellen**

Wenn ein automatisierter Review dieselbe Präsentation wiederholt verarbeitet, sollte die Sammlung, die von [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) zurückgegeben wird, vor dem Hinzufügen eines Autors durchsucht werden. [findByNameAndInitials](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-) prüft sowohl Name als auch Initialen und gibt ein Array passender Autoren zurück oder ein leeres Array, wenn keine Übereinstimmungen existieren. Im Gegensatz dazu sucht [findByName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-) nur nach dem Namen, unabhängig von den Initialen. Das Aufrufen von [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) mit einem bereits vorhandenen Namen und Initialen löst eine Ausnahme aus.

Das Beispiel benötigt eine Präsentationsdatei mit mindestens einer Folie. In jedem der beiden Durchläufe wird der erste passende Autor wiederverwendet oder nur dann ein neuer erstellt, wenn das Ergebnis leer ist. Gibt es mehrere Treffer, wird das erste Array‑Element ausgewählt, ohne die anderen Autoren zu mergen oder zu entfernen. Anschließend wird [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) für den ausgewählten Autor aufgerufen und die Präsentation gespeichert. Der zweite Durchlauf öffnet die Ausgabe des ersten Durchlaufs und wiederholt den Vorgang.

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

Der zweite Durchlauf fügt einen weiteren Kommentar hinzu, ohne einen weiteren Autor zu erzeugen oder vorhandene Kommentare zu entfernen. Die endgültige Datei `review_pass_2.pptx` enthält beide neuen Kommentare neben etwaigen Originalkommentaren. Das Wiederverwenden eines Autors führt nicht zu einer Deduplikation von Kommentaren: Um zu vermeiden, dass derselbe Kommentar wiederholt hinzugefügt wird, sollte vor dem Hinzufügen eine eigene Duplikaterkennung implementiert werden.

## **Zugriff auf Folienkommentare**

Das Beispiel öffnet eine bestehende Präsentation und liest die von [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) zurückgegebene Sammlung. Für jeden Autor wird die von [getComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthor/#getComments--) zurückgegebene Sammlung durchlaufen und die Foliennummer, der Kommentartext, der Autorenname und die Erstellungszeit ausgegeben. Die Eingabedatei muss Kommentare enthalten, damit Konsolenausgaben erzeugt werden.

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

## **Antworten auf Kommentare**

Ein Eltern‑Kommentar ist der ursprüngliche Kommentar an der Spitze einer Antworthierarchie. Die Methoden [IComment.getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) und [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) ermöglichen das Abrufen bzw. Setzen des Elternteils eines Kommentars.

Das Beispiel erstellt Kommentare von zwei Autoren und verwendet [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-), um Antworten zu bauen, einschließlich einer Antwort auf eine andere Antwort. Das Übergeben von `null` an [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) ruft Kommentare aller Autoren ab; die Konsole rückt jeden Eintrag entsprechend seiner Tiefe in der Antworthierarchie ein. Das Beispiel speichert die komplette Diskussion, ruft [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) für den ersten Root‑Kommentar auf und speichert eine zweite Präsentation, in der dieser Kommentar und seine Antworten entfernt wurden.

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
* Wenn die Methode [IComment.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) verwendet wird, um einen Kommentar zu löschen, werden alle Antworten auf diesen Kommentar ebenfalls gelöscht.
* Führt [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) zu einer zirkulären Referenz, wird eine [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/) ausgelöst.
{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Moderne Kommentare können der Folie selbst, einem bestimmten Shape oder einem Textbereich innerhalb einer AutoShape zugeordnet werden. Die Methode [ICommentCollection.addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) akzeptiert ein [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)‑Argument zusätzlich zu Folie und Koordinaten des Kommentar‑Markers.

Wird für das Shape‑Argument `null` übergeben, handelt es sich um einen Folien‑Kommentar. Sein Marker wird anhand der übergebenen Koordinaten positioniert, aber er ist keiner bestimmten Form zugeordnet, sodass [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) `null` zurückgibt. Wird ein [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) übergeben, wird der Kommentar an dieser Form verankert. Die Koordinaten bestimmen weiterhin die Position des Kommentar‑Markers auf der Folie, während die Form‑Zuordnung über [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) abgerufen werden kann.

### **Einen modernen Kommentar an einer Form verankern**

Das Beispiel ruft [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) zweimal auf: einmal mit `null` für einen Folien‑Kommentar und einmal mit einem Rechteck als Anker. Das Auslesen von [getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) gibt `true` für die Null‑Prüfung des Folien‑Kommentars und `Revenue title` für den verankerten Kommentar aus. Beide Kommentare werden mit der Präsentation gespeichert.

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

Jedes Folienobjekt, das [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) implementiert, kann als Formanker verwendet werden. Häufige Beispiele sind [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnector/) und [IGraphicalObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobject/)‑Instanzen wie Diagramme.

Das Beispiel nutzt [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-), um jedem von fünf Formtypen (AutoShape, Bildrahmen, Gruppe, Verbinder und Diagramm) einen Kommentar zuzuordnen. Das Bild verwendet eingebettete Bilddaten, sodass kein externes Bild nötig ist. Jeder Kommentar hat eine eigene Marker‑Position, und die gespeicherte Präsentation behält alle fünf Formzuordnungen bei.

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

### **Einen Kommentar an Text verankern und seinen Status festlegen**

Für einen modernen Kommentar, der einem [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) zugeordnet ist, ermöglichen [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) und [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) den Zugriff auf die Startposition des ausgewählten Textes im Textfeld der Form. [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) und [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) geben die Länge der Auswahl zurück bzw. setzen sie. Zusammen verknüpfen diese Werte den Kommentar mit einem bestimmten Textbereich innerhalb der AutoShape.

Die Methoden [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) und [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) greifen auf einen Wert aus den Konstanten von [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) zu:

- `NotDefined` – kein spezifischer Modern‑Comment‑Status definiert.
- `Active` – der Kommentar ist aktiv.
- `Resolved` – der Kommentar wurde gelöst.
- `Closed` – der Kommentar ist geschlossen.

Das Beispiel verankert einen modernen Kommentar bei den Worten „quarterly revenue“ in einem Rechteck‑Text. Es berechnet den nullbasierten Auswahl‑Start aus dem Text und übergibt ihn an [setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-), verwendet [setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) zur Festlegung der Zeichenanzahl und ruft anschließend [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) mit `Resolved` auf. Nach dem Speichern und erneuten Öffnen der Präsentation sollten die vier Konsolen‑Checks jeweils `true` ausgeben, was bestätigt, dass Formanker, Textbereich und Status erhalten geblieben sind.

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

### **Bestehende moderne Kommentare untersuchen**

Das Beispiel setzt eine vorhandene Präsentation mit modernen Kommentaren voraus und gibt deren Text, Status und Anker‑Details aus. Zur Untersuchung prüft man, welche Kommentare [IModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/) implementieren, und untersucht dann [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) und [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--). Ein `null`‑Shape weist auf einen Folien‑Kommentar hin. Bei einem [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)‑Anker identifizieren die Textauswahl‑Methoden den zugeordneten Bereich im Textfeld der Form.

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

Aspose.Slides für Android über Java ermöglicht das Entfernen aller Kommentare und ihrer Autoren aus einer Präsentation oder das Löschen ausgewählter Kommentare, wobei der Rest erhalten bleibt. Die folgenden Beispiele demonstrieren beide Ansätze und speichern die aktualisierte Präsentation.

### **Alle Kommentare und Kommentarautoren entfernen**

Das Beispiel öffnet eine vorhandene Präsentation und ruft für jeden Autor [ICommentCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#clear--) auf, danach [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#clear--) zum Entfernen der Autoren selbst. Die gespeicherte Präsentation enthält weder Kommentare noch Kommentarautoren. Verwenden Sie eine Präsentation mit Kommentaren, um die Entfernung zu beobachten.

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

Das Beispiel erstellt zwei Kommentare auf einer Folie und nutzt [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) , um Kommentare jedes Autors zu finden. Es sammelt Kommentare, deren Text gleich „comment 1“ ist, bevor [ICommentCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-) aufgerufen wird, um Änderungen an der Sammlung während der Auswahl zu vermeiden. Die gespeicherte Präsentation enthält nur „comment 2“.

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

Ja. [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) und [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) greifen auf einen Wert von [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) zu, einschließlich `Resolved`. Der Status wird in der Präsentation gespeichert und kann nach dem erneuten Öffnen der Datei wieder ausgelesen werden.

**Werden Thread‑Diskussionen (Antwortketten) unterstützt und gibt es ein Verschachtelungs‑Limit?**

Ja. Jeder Kommentar kann auf seinen [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) verweisen, wodurch Antwortketten möglich sind. Die API definiert keinen spezifischen Begrenzungswert für die Verschachtelungstiefe.

**In welchem Koordinatensystem ist die Position eines Kommentar‑Markers auf einer Folie definiert?**

Die Marker‑Position wird durch Fließkomma‑Koordinaten im Folien‑Koordinatensystem definiert, sodass Sie sie präzise auf der Folie platzieren können.