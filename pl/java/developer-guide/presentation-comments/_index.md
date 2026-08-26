---
title: Zarządzanie komentarzami w prezentacji w Javie
linktitle: Komentarze prezentacji
type: docs
weight: 100
url: /pl/java/presentation-comments/
keywords:
- komentarz
- nowoczesny komentarz
- komentarze PowerPoint
- komentarze prezentacji
- komentarze slajdów
- dodaj komentarz
- dostęp do komentarza
- edytuj komentarz
- odpowiedz na komentarz
- usuń komentarz
- skasuj komentarz
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Zarządzaj komentarzami w prezentacji przy użyciu Aspose.Slides dla Javy: dodawaj, odczytuj, edytuj, odpowiadaj i usuwaj komentarze w prezentacjach PowerPoint szybko i łatwo."
---
## **Omówienie**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji przy użyciu Aspose.Slides for Java. Przedstawia główne typy związane z komentarzami i demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami i nowoczesnymi komentarzami oraz usuwać komentarze z prezentacji.

Przykłady obejmują typowe scenariusze przeglądu i współpracy w PowerPoint, takie jak przypisywanie komentarzy do autorów, odczytywanie tekstu i metadanych komentarzy, budowanie łańcuchów odpowiedzi oraz usuwanie wybranych komentarzy lub wszystkich komentarzy.

W PowerPoint komentarze są wyświetlane jako adnotacje na slajdach. Wybranie komentarza wyświetla jego tekst i powiązaną dyskusję.

## **Dlaczego warto dodawać komentarze do prezentacji?**

Można używać komentarzy, aby przekazywać opinie i współpracować z kolegami podczas przeglądania prezentacji.

Aspose.Slides for Java udostępnia następujące API do pracy z komentarzami:

* Klasa [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/), która zapewnia dostęp do autorów komentarzy w prezentacji.
* Interfejs [ICommentCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icommentcollection/), który reprezentuje komentarze powiązane z poszczególnym autorem.
* Interfejs [IComment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icomment/), który dostarcza informacji o komentarzu, w tym autora, czas utworzenia, pozycję i tekst.
* Klasa [CommentAuthor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/commentauthor/), która zawiera informacje o autorze, takie jak imię, inicjały i powiązane komentarze.

## **Dodawanie komentarzy do slajdów**

Poniższy przykład pokazuje, jak dodać komentarze do slajdów w prezentacji PowerPoint:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
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

        ICommentCollection authorComments = firstComment.getAuthor().getComments();
        String commentText = authorComments.get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dostęp do komentarzy slajdu**

Poniższy przykład pokazuje, jak uzyskać dostęp do istniejących komentarzy w prezentacji PowerPoint:

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

## **Odpowiadanie na komentarze**

Komentarz nadrzędny to oryginalny komentarz na szczycie hierarchii odpowiedzi. Metody [IComment.getParentComment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icomment/#getParentComment--) i [IComment.setParentComment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) umożliwiają pobranie lub ustawienie komentarza nadrzędnego.

Poniższy przykład pokazuje, jak dodawać odpowiedzi i przeglądać powstałą hierarchię komentarzy:

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

{{% alert color="warning" title="Ostrzeżenie" %}}
* Gdy metoda [IComment.remove](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icomment/#remove--) zostanie użyta do usunięcia komentarza, wszystkie odpowiedzi na ten komentarz zostaną również usunięte.
* Jeśli [IComment.setParentComment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) utworzy odwołanie cykliczne, zostanie rzucony wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Dodawanie nowoczesnych komentarzy**

Nowoczesne komentarze mogą być powiązane z samym slajdem, z określonym kształtem lub z zakresem tekstu wewnątrz AutoShape. Metoda [ICommentCollection.addModernComment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) przyjmuje dodatkowy argument typu [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/) oprócz slajdu i współrzędnych znacznika komentarza.

Gdy dla argumentu shape zostanie przekazane `null`, komentarz jest komentarzem na poziomie slajdu. Jego znacznik jest pozycjonowany według podanych współrzędnych, ale nie jest powiązany z konkretnym kształtem, więc [IModernComment.getShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imoderncomment/#getShape--) zwraca `null`. Gdy zostanie dostarczony [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/), komentarz jest zakotwiczony do tego kształtu. Współrzędne nadal określają pozycję znacznika komentarza na slajdzie, a powiązanie z kształtem można odczytać za pomocą [IModernComment.getShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imoderncomment/#getShape--).

### **Zakotwiczenie nowoczesnego komentarza w kształcie**

Poniższy przykład tworzy zarówno nowoczesny komentarz na poziomie slajdu, jak i nowoczesny komentarz zakotwiczony w konkretnym AutoShape. Następnie odczytuje powiązany kształt z każdego komentarza.

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

### **Zakotwiczenie komentarzy do różnych typów kształtów**

Każdy obiekt slajdu implementujący [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/) może być użyty jako kotwica kształtu. Typowe przykłady to [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iconnector/) oraz instancje [IGraphicalObject](https://reference.aspose.com/slides/pl/java/com.aspose.slides/igraphicalobject/) takie jak wykresy.

Poniższy przykład tworzy kilka popularnych typów kształtów i powiązuje z każdym z nich nowoczesny komentarz.

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

### **Zakotwiczenie komentarza w tekście i ustawienie jego statusu**

Dla nowoczesnego komentarza powiązanego z [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/), metody [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) i [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) umożliwiają dostęp do początkowej pozycji zaznaczonego tekstu w ramce tekstowej kształtu. Metody [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) i [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) udostępniają długość zaznaczenia. Razem te wartości wiążą komentarz z określonym zakresem tekstu wewnątrz AutoShape.

Metody [IModernComment.getStatus](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imoderncomment/#getStatus--) i [IModernComment.setStatus](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imoderncomment/#setStatus-byte-) odczytują wartość z wyliczenia [ModernCommentStatus](https://reference.aspose.com/slides/pl/java/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — nie określono konkretnego statusu nowoczesnego komentarza.
- `Active` — komentarz jest aktywny.
- `Resolved` — komentarz został rozwiązany.
- `Closed` — komentarz jest zamknięty.

Poniższy przykład tworzy nowoczesny komentarz zakotwiczony w kształcie, powiązuje go z zaznaczeniem tekstu, oznacza jako rozwiązany, zapisuje prezentację i weryfikuje wartości po ponownym otwarciu pliku.

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

### **Przegląd istniejących nowoczesnych komentarzy**

Aby przejrzeć istniejącą prezentację, sprawdź, które komentarze implementują [IModernComment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imoderncomment/), a następnie zbadaj [IModernComment.getShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--), oraz [IModernComment.getStatus](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imoderncomment/#getStatus--). Kształt `null` wskazuje na komentarz na poziomie slajdu. Dla kotwicy typu [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) metody wyboru tekstu identyfikują powiązany zakres w ramce tekstowej kształtu.

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

## **Usuwanie komentarzy**

### **Usuwanie wszystkich komentarzy i ich autorów**

Poniższy przykład pokazuje, jak usunąć wszystkie komentarze i ich autorów z prezentacji:

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

### **Usuwanie wybranych komentarzy**

Poniższy przykład pokazuje, jak usunąć wybrane komentarze ze slajdu:

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

**Czy Aspose.Slides obsługuje status rozwiązany dla nowoczesnych komentarzy?**

Tak. Metody [IModernComment.getStatus](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imoderncomment/#getStatus--) i [IModernComment.setStatus](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imoderncomment/#setStatus-byte-) umożliwiają dostęp do wartości [ModernCommentStatus](https://reference.aspose.com/slides/pl/java/com.aspose.slides/moderncommentstatus/), w tym `Resolved`. Status jest przechowywany w prezentacji i może być odczytany po ponownym otwarciu pliku.

**Czy obsługiwane są dyskusje wątkowe (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżenia?**

Tak. Każdy komentarz może odwoływać się do swojego [parent comment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icomment/#getParentComment--), umożliwiając tworzenie łańcuchów odpowiedzi. API nie definiuje konkretnego limitu głębokości zagnieżdżenia.

**W jakim systemie współrzędnych definiowana jest pozycja znacznika komentarza na slajdzie?**

Pozycja znacznika jest określana przez współrzędne zmiennoprzecinkowe w systemie współrzędnych slajdu, co pozwala precyzyjnie umieścić go na slajdzie.