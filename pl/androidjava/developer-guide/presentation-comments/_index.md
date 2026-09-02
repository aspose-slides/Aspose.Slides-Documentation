---
title: Zarządzanie komentarzami w prezentacji na Androidzie
linktitle: Komentarze w prezentacji
type: docs
weight: 100
url: /pl/androidjava/presentation-comments/
keywords:
- komentarz
- nowoczesny komentarz
- komentarze PowerPoint
- komentarze w prezentacji
- komentarze slajdu
- dodaj komentarz
- dostęp do komentarza
- edytuj komentarz
- odpowiedź na komentarz
- usuń komentarz
- usuń komentarz
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zarządzaj komentarzami w prezentacji za pomocą Aspose.Slides for Android via Java: dodawaj, czytaj, edytuj, odpowiadaj i usuwaj komentarze w prezentacjach PowerPoint szybko i łatwo."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji przy użyciu Aspose.Slides for Android via Java. Wprowadza główne typy związane z komentarzami i demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami i nowoczesnymi komentarzami oraz usuwać komentarze z prezentacji.

Przykłady obejmują typowe scenariusze przeglądu i współpracy w PowerPoint, takie jak przypisywanie komentarzy do autorów, odczytywanie tekstu i metadanych komentarzy, budowanie łańcuchów odpowiedzi oraz usuwanie wybranych komentarzy lub wszystkich komentarzy.

W PowerPoint komentarze pojawiają się jako adnotacje na slajdach. Wybranie komentarza wyświetla jego tekst i powiązaną dyskusję.

## **Dlaczego warto dodawać komentarze do prezentacji?**

Możesz używać komentarzy do udzielania informacji zwrotnych i współpracy z kolegami podczas przeglądania prezentacji.

Aspose.Slides for Android via Java udostępnia następujące interfejsy API do pracy z komentarzami:

* Klasa [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) zapewnia dostęp do autorów komentarzy w prezentacji.
* Interfejs [ICommentCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icommentcollection/) reprezentuje komentarze powiązane z pojedynczym autorem.
* Interfejs [IComment](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icomment/) dostarcza informacje o komentarzu, w tym autora, czas utworzenia, pozycję i tekst.
* Klasa [CommentAuthor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/commentauthor/) dostarcza informacje o autorze, w tym jego imię i nazwisko, inicjały oraz powiązane komentarze.

## **Dodawanie komentarzy do slajdów**

Poniższy przykład pokazuje, jak dodać komentarze do slajdów w prezentacji PowerPoint:

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

## **Uzyskiwanie dostępu do komentarzy slajdów**

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

Komentarz nadrzędny to pierwotny komentarz na szczycie hierarchii odpowiedzi. Metody [IComment.getParentComment](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icomment/#getParentComment--) oraz [IComment.setParentComment](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) umożliwiają pobranie lub ustawienie komentarza nadrzędnego.

Poniższy przykład pokazuje, jak dodawać odpowiedzi i przeglądać powstałą hierarchię komentarzy:

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

{{% alert color="warning" title="Ostrzeżenie" %}}
* Gdy metoda [IComment.remove](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icomment/#remove--) jest używana do usunięcia komentarza, wszystkie odpowiedzi na ten komentarz są również usuwane.
* Jeśli metoda [IComment.setParentComment](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) tworzy odniesienie cykliczne, zostaje zgłoszony [PptxEditException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Dodawanie nowoczesnych komentarzy**

Nowoczesne komentarze mogą być powiązane z samym slajdem, konkretnym kształtem lub zakresem tekstu wewnątrz AutoShape. Metoda [ICommentCollection.addModernComment](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) przyjmuje argument [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/) oprócz slajdu i współrzędnych znacznika komentarza.

Gdy dla argumentu shape przekazany zostanie `null`, komentarz jest komentarzem na poziomie slajdu. Jego znacznik jest umieszczany według podanych współrzędnych, ale nie jest powiązany z konkretnym kształtem, więc [IModernComment.getShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imoderncomment/#getShape--) zwraca `null`. Gdy podany zostanie [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/), komentarz jest zakotwiczony do tego kształtu. Współrzędne nadal definiują pozycję znacznika komentarza na slajdzie, a powiązanie z kształtem można odczytać przy pomocy [IModernComment.getShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imoderncomment/#getShape--).

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

### **Zakotwiczenie komentarzy do różnych typów kształtów**

Każdy obiekt slajdu implementujący [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/) może być użyty jako kotwica kształtu. Typowe przykłady obejmują [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iconnector/), oraz instancje [IGraphicalObject](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/igraphicalobject/), takie jak wykresy.

Poniższy przykład tworzy kilka typowych kształtów i łączy z każdym z nich nowoczesny komentarz.

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

### **Zakotwiczenie komentarza do tekstu i ustawienie jego statusu**

Dla nowoczesnego komentarza powiązanego z [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/), metody [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) oraz [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int--) uzyskują początkową pozycję zaznaczonego tekstu w ramce tekstowej kształtu. Metody [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) i [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int--) uzyskują długość zaznaczenia. Razem te wartości powiązują komentarz z konkretnym zakresem tekstu w AutoShape.

Metody [IModernComment.getStatus](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imoderncomment/#getStatus--) oraz [IModernComment.setStatus](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte--) odczytują wartość z stałych [ModernCommentStatus](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/moderncommentstatus/):

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

### **Sprawdzanie istniejących nowoczesnych komentarzy**

Aby sprawdzić istniejącą prezentację, należy sprawdzić, które komentarze implementują [IModernComment](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imoderncomment/), a następnie zbadać [IModernComment.getShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--), i [IModernComment.getStatus](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imoderncomment/#getStatus--). Kształt `null` oznacza komentarz na poziomie slajdu. Dla kotwicy [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/), metody zaznaczenia tekstu identyfikują powiązany zakres w ramce tekstowej kształtu.

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

### **Usunięcie wszystkich komentarzy i autorów komentarzy**

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

### **Usunięcie konkretnych komentarzy**

Poniższy przykład pokazuje, jak usunąć konkretne komentarze ze slajdu:

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

**Czy Aspose.Slides obsługuje status rozwiązany dla nowoczesnych komentarzy?**

Tak. Metody [IModernComment.getStatus](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imoderncomment/#getStatus--) i [IModernComment.setStatus](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte--) odczytują wartość z [ModernCommentStatus](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/moderncommentstatus/), w tym `Resolved`. Status jest przechowywany w prezentacji i może być ponownie odczytany po ponownym otwarciu pliku.

**Czy obsługiwane są dyskusje wątkowe (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżania?**

Tak. Każdy komentarz może odwoływać się do swojego [parent comment](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icomment/#getParentComment--), co umożliwia tworzenie łańcuchów odpowiedzi. API nie definiuje konkretnego limitu głębokości zagnieżdżenia.

**W jakim układzie współrzędnych definiowana jest pozycja znacznika komentarza na slajdzie?**

Pozycja znacznika jest definiowana przez współrzędne zmiennoprzecinkowe w układzie współrzędnych slajdu, co pozwala precyzyjnie umieścić go na slajdzie.