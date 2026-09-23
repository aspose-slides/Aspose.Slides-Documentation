---
title: Zarządzanie komentarzami prezentacji w Node.js
linktitle: Komentarze prezentacji
type: docs
weight: 100
url: /pl/nodejs-java/presentation-comments/
keywords:
- komentarz
- nowoczesny komentarz
- komentarze PowerPoint
- komentarze prezentacji
- komentarze slajdów
- dodaj komentarz
- pobierz komentarz
- edytuj komentarz
- odpowiedz na komentarz
- usuń komentarz
- skasuj komentarz
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj komentarzami prezentacji przy użyciu Aspose.Slides for Node.js via Java: dodawaj, odczytuj, edytuj, odpowiadaj i usuwaj komentarze w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji za pomocą Aspose.Slides for Node.js via Java. Wprowadza główne typy związane z komentarzami i demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami i nowoczesnymi komentarzami oraz usuwać komentarze z prezentacji.

Przykłady obejmują typowe scenariusze przeglądu i współpracy w PowerPoint, takie jak przypisywanie komentarzy do autorów, odczytywanie tekstu i metadanych komentarza, budowanie łańcuchów odpowiedzi oraz usuwanie wybranych komentarzy lub wszystkich komentarzy.

W PowerPoint komentarze pojawiają się jako adnotacje na slajdach. Wybranie komentarza wyświetla jego tekst oraz powiązaną dyskusję.

Aby żądać wyświetlania lub ukrywania komentarzy przy otwieraniu prezentacji bez zmieniania samych komentarzy, zobacz [Pokaż lub ukryj komentarze przy otwieraniu prezentacji](/slides/pl/nodejs-java/presentation-view-properties/).

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz używać komentarzy, aby przekazywać opinie i współpracować z kolegami podczas przeglądania prezentacji.

Aspose.Slides for Node.js via Java udostępnia następujące API do pracy z komentarzami:

* Klasa [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) zapewnia dostęp do autorów komentarzy prezentacji.
* Klasa [CommentCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/commentcollection/) reprezentuje komentarze powiązane z konkretnym autorem.
* Klasa [Comment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/comment/) dostarcza informacji o komentarzu, w tym jego autora, czas utworzenia, pozycję i tekst.
* Klasa [CommentAuthor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/commentauthor/) dostarcza informacji o autorze, w tym jego imię, inicjały i powiązane komentarze.

## **Dodawanie komentarzy do slajdów**

Poniższy przykład pokazuje, jak dodać komentarze do slajdów w prezentacji PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const authorComments = firstComment.getAuthor().getComments();
        const commentText = authorComments.get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dostęp do komentarzy slajdów**

Poniższy przykład pokazuje, jak uzyskać dostęp do istniejących komentarzy w prezentacji PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Odpowiadanie na komentarze**

Komentarz nadrzędny to oryginalny komentarz znajdujący się na szczycie hierarchii odpowiedzi. Metody [Comment.getParentComment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/comment/getparentcomment/) i [Comment.setParentComment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/comment/setparentcomment/) umożliwiają pobranie lub ustawienie komentarza nadrzędnego.

Poniższy przykład pokazuje, jak dodać odpowiedzi i przeanalizować powstałą hierarchię komentarzy:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    const author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    const reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    const subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    const comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    const reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Gdy metoda [Comment.remove](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/comment/remove/) jest używana do usunięcia komentarza, wszystkie odpowiedzi na ten komentarz są również usuwane.
* Jeśli metoda [Comment.setParentComment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/comment/setparentcomment/) tworzy odniesienie cykliczne, zostaje zgłoszony [PptxEditException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Dodawanie nowoczesnych komentarzy**

Nowoczesne komentarze mogą być powiązane ze slajdem, konkretnym kształtem lub zakresem tekstu wewnątrz [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/). Metoda [CommentCollection.addModernComment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) przyjmuje argument [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/) oprócz koordynatów slajdu i znacznika komentarza.

Gdy `null` jest przekazywane jako argument shape, komentarz jest komentarzem na poziomie slajdu. Jego znacznik jest pozycjonowany wg podanych współrzędnych, ale nie jest powiązany z konkretnym kształtem, więc [ModernComment.getShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/getshape/) zwraca `null`. Gdy podany jest [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/), komentarz jest zakotwiczony do tego kształtu. Współrzędne nadal definiują pozycję znacznika komentarza na slajdzie, a powiązanie z kształtem można odczytać przez [ModernComment.getShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Kotwiczenie nowoczesnego komentarza do kształtu**

Poniższy przykład tworzy zarówno nowoczesny komentarz na poziomie slajdu, jak i nowoczesny komentarz zakotwiczony do konkretnego [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/). Następnie odczytuje powiązany kształt z każdego komentarza.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kotwiczenie komentarzy do różnych typów kształtów**

Każdy obiekt slajdu pochodzący z [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/) może być użyty jako kotwica kształtu. Typowe przykłady to [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/connector/) i instancje [GraphicalObject](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/graphicalobject/) takie jak wykresy.

Poniższy przykład tworzy kilka typowych kształtów i powiązuje z każdym z nich nowoczesny komentarz.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kotwiczenie komentarza do tekstu i ustawienie jego statusu**

Dla nowoczesnego komentarza powiązanego z [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) i [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) uzyskują początkową pozycję zaznaczonego tekstu w ramce tekstowej kształtu. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) i [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) uzyskują długość zaznaczenia. Razem te wartości powiązują komentarz z określonym zakresem tekstu wewnątrz [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/).

Metody [ModernComment.getStatus](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/getstatus/) i [ModernComment.setStatus](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/setstatus/) uzyskują wartość z wyliczenia [ModernCommentStatus](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — nie zdefiniowano konkretnego statusu nowoczesnego komentarza.
- `Active` — komentarz jest aktywny.
- `Resolved` — komentarz został rozwiązany.
- `Closed` — komentarz jest zamknięty.

Poniższy przykład tworzy nowoczesny komentarz zakotwiczony do kształtu, powiązuje go z zaznaczeniem tekstu, oznacza jako rozwiązany, zapisuje prezentację i weryfikuje wartości po ponownym otwarciu pliku.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(aspose.slides.ModernCommentStatus.Resolved);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Sprawdzanie istniejących nowoczesnych komentarzy**

Aby sprawdzić istniejącą prezentację, określ, które komentarze są instancjami [ModernComment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/), a następnie zbadaj [ModernComment.getShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) i [ModernComment.getStatus](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/getstatus/). Kształt `null` wskazuje na komentarz na poziomie slajdu. Dla kotwicy [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) metody wyboru tekstu identyfikują powiązany zakres w ramce tekstowej kształtu.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Usuwanie komentarzy**

### **Usunięcie wszystkich komentarzy i autorów komentarzy**

Poniższy przykład pokazuje, jak usunąć wszystkie komentarze i autorów komentarzy z prezentacji:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Usunięcie konkretnych komentarzy**

Poniższy przykład pokazuje, jak usunąć konkretne komentarze ze slajdu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy Aspose.Slides obsługuje status rozwiązany dla nowoczesnych komentarzy?**

Tak. [ModernComment.getStatus](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/getstatus/) i [ModernComment.setStatus](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/setstatus/) uzyskują wartość z [ModernCommentStatus](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncommentstatus/), w tym `Resolved`. Status jest przechowywany w prezentacji i może być odczytany ponownie po ponownym otwarciu pliku.

**Czy obsługiwane są wątki dyskusji (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżania?**

Tak. Każdy komentarz może odwoływać się do swojego [parent comment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/comment/getparentcomment/), co umożliwia tworzenie łańcuchów odpowiedzi. API nie definiuje konkretnego limitu głębokości zagnieżdzenia.

**W jakim systemie współrzędnych definiowana jest pozycja znacznika komentarza na slajdzie?**

Pozycja znacznika jest definiowana przez współrzędne zmiennoprzecinkowe w systemie współrzędnych slajdu, co pozwala precyzyjnie umieścić go na slajdzie.