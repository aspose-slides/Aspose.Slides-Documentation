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
- dostęp do komentarza
- edytuj komentarz
- odpowiedz na komentarz
- usuń komentarz
- usuń komentarz
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj komentarzami prezentacji za pomocą Aspose.Slides dla Node.js przez Java: dodawaj, odczytuj, edytuj, odpowiadaj na i usuwaj komentarze w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji przy użyciu Aspose.Slides dla Node.js przez Java. Wprowadza główne typy związane z komentarzami i demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami i nowoczesnymi komentarzami oraz usuwać komentarze z prezentacji.

Przykłady obejmują typowe scenariusze przeglądu i współpracy w programie PowerPoint, takie jak przypisywanie komentarzy do autorów, odczytywanie tekstu i metadanych komentarzy, budowanie łańcuchów odpowiedzi oraz usuwanie wybranych komentarzy lub wszystkich komentarzy.

W programie PowerPoint komentarze pojawiają się jako adnotacje na slajdach. Wybranie komentarza wyświetla jego tekst i powiązaną dyskusję.

Aby poprosić o wyświetlenie lub ukrycie komentarzy podczas otwierania prezentacji bez zmiany samych komentarzy, zobacz [Pokaż lub ukryj komentarze podczas otwierania prezentacji](/slides/pl/nodejs-java/presentation-view-properties/).

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz używać komentarzy, aby przekazywać opinie i współpracować z kolegami podczas przeglądania prezentacji.

Aspose.Slides for Node.js via Java udostępnia następujące API do pracy z komentarzami:

* The [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class, która zapewnia dostęp do autorów komentarzy prezentacji.
* The [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) class, która reprezentuje komentarze powiązane z pojedynczym autorem.
* The [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) class, która dostarcza informacji o komentarzu, w tym jego autora, czas utworzenia, pozycję i tekst.
* The [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) class, która dostarcza informacji o autorze, w tym jego imię i nazwisko, inicjały oraz powiązane komentarze.

## **Dodawanie komentarzy do slajdów**

Przykład tworzy dwa slajdy i rejestruje autora komentarza przy użyciu [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/). Używa [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) do umieszczenia jednego komentarza na każdym slajdzie, a następnie pobiera komentarze pierwszego slajdu dla tego autora przy pomocy [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/). Konsola wyświetla tekst pierwszego komentarza dwukrotnie, demonstrując dostęp zarówno przez slajd, jak i autora, a zapisana prezentacja zawiera oba komentarze.

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

        const commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Znajdź lub utwórz autora komentarza**

Gdy automatyczna recenzja przetwarza tę samą prezentację wielokrotnie, przeszukaj kolekcję zwróconą przez [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) przed dodaniem autora. [findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) dopasowuje zarówno nazwę, jak i inicjały i zwraca tablicę pasujących autorów lub pustą tablicę, jeśli nie ma dopasowań. Natomiast [findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) wyszukuje tylko po nazwie, niezależnie od inicjałów. Wywołanie [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) z nazwą i inicjałami już istniejącymi w kolekcji powoduje wyrzucenie wyjątku.

Przykład wymaga pliku prezentacji z co najmniej jednym slajdem. W każdym z dwóch przebiegów ponownie używa pierwszego pasującego autora lub tworzy nowego tylko wtedy, gdy wynik jest pusty. Jeśli istnieje wiele dopasowań, wybiera pierwszy element tablicy bez łączenia ani usuwania pozostałych autorów. Następnie wywołuje [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) dla wybranego autora i zapisuje prezentację. Drugi przebieg otwiera wynik pierwszego przebiegu i powtarza operację.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const authorName = "Reviewer";
const authorInitials = "RV";

let inputFile = "input.pptx";
const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));

for (let pass = 1; pass <= 2; pass++) {
    const presentation = new aspose.slides.Presentation(inputFile);
    try {
        const matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        const author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        const createdTime = java.newInstanceSync("java.util.Date");
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, createdTime);

        const outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

Drugi przebieg dodaje kolejny komentarz bez dodawania nowego autora ani usuwania istniejących komentarzy. Końcowy plik `review_pass_2.pptx` zawiera oba nowe komentarze obok wszelkich oryginalnych komentarzy. Ponowne użycie autora nie deduplikuje komentarzy: aby uniknąć wielokrotnego dodawania tego samego komentarza, należy przed dodaniem wprowadzić własną logikę wykrywania duplikatów.

## **Dostęp do komentarzy slajdu**

Przykład otwiera istniejącą prezentację i odczytuje kolekcję zwróconą przez [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/). Dla każdego autora iteruje po kolekcji zwróconej przez [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/) i wypisuje numer slajdu, tekst komentarza, nazwę autora oraz czas utworzenia. Wejściowa prezentacja musi zawierać komentarze, aby uzyskać wyjście w konsoli.

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

Komentarz nadrzędny to oryginalny komentarz na szczycie hierarchii odpowiedzi. Metody [Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) i [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) pozwalają pobrać lub ustawić rodzica komentarza.

Przykład tworzy komentarze od dwóch autorów i używa [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) do budowania odpowiedzi, w tym odpowiedzi na inną odpowiedź. Przekazanie `null` do [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) pobiera komentarze od wszystkich autorów; konsola wcięła każdy wpis zgodnie z jego głębokością w hierarchii odpowiedzi. Przykład zapisuje pełną dyskusję, wywołuje [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) na pierwszym komentarzu głównym i zapisuje drugą prezentację z usuniętym tym komentarzem i jego odpowiedziami.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    const reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    const secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    const subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    const separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    const separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

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

    rootComment.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Gdy metoda [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) jest używana do usunięcia komentarza, wszystkie odpowiedzi na ten komentarz są również usuwane.
* Jeśli [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) tworzy odwołanie cykliczne, zgłaszany jest [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Dodawanie nowoczesnych komentarzy**

Nowoczesne komentarze mogą być powiązane z samym slajdem, konkretnym kształtem lub zakresem tekstu wewnątrz AutoShape. Metoda [CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) przyjmuje dodatkowy argument [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) oprócz slajdu i współrzędnych znacznika komentarza.

Gdy dla argumentu shape przekazany jest `null`, komentarz jest komentarzem na poziomie slajdu. Jego znacznik jest pozycjonowany według podanych współrzędnych, ale nie jest powiązany z konkretnym kształtem, więc [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) zwraca `null`. Gdy podana jest [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), komentarz jest zakotwiczony do tego kształtu. Współrzędne nadal definiują pozycję znacznika komentarza na slajdzie, a powiązanie kształtu można odczytać przez [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Zakotwiczanie nowoczesnego komentarza do kształtu**

Przykład wywołuje [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) dwukrotnie: raz z `null` jako kształtem dla komentarza na poziomie slajdu i raz z prostokątem jako kotwicą. Odczytanie [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) wypisuje `true` dla sprawdzenia null w komentarzu na poziomie slajdu i `Revenue title` dla zakotwiczonego komentarza. Oba komentarze są zapisywane wraz z prezentacją.

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

### **Zakotwiczanie komentarzy do różnych typów kształtów**

Każdy obiekt slajdu pochodzący od [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) może być użyty jako kotwica kształtu. Typowe przykłady to [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) oraz instancje [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/) takie jak wykresy.

Przykład używa [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) do powiązania komentarza z każdym z pięciu typów kształtów: AutoShape, ramką obrazu, grupą, łącznikiem i wykresem. Obraz w ramce jest osadzony jako dane binarne, więc nie wymaga zewnętrznego pliku obrazu. Każdy komentarz ma własną pozycję znacznika, a zapisana prezentacja zachowuje wszystkie pięć powiązań kształtów.

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

### **Zakotwiczanie komentarza do tekstu i ustawianie jego statusu**

Dla nowoczesnego komentarza powiązanego z [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), metody [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) i [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) uzyskują początkową pozycję wybranego tekstu w ramce tekstowej kształtu. Metody [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) i [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) określają długość zaznaczenia. Razem wartości te powiązują komentarz z określonym zakresem tekstu wewnątrz AutoShape.

Metody [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) i [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) zwracają wartość z wyliczenia [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — nie zdefiniowano specyficznego statusu nowoczesnego komentarza.
- `Active` — komentarz jest aktywny.
- `Resolved` — komentarz został rozwiązany.
- `Closed` — komentarz jest zamknięty.

Przykład zakotwicza nowoczesny komentarz do słów „quarterly revenue” w tekście prostokąta. Oblicza zerowo‑indeksowane rozpoczęcie zaznaczenia z tekstu i przekazuje je do [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/), a następnie używa [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) do ustawienia liczby zaznaczonych znaków. Po wywołaniu [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) z wartością `Resolved` zapisuje i ponownie otwiera prezentację. Cztery sprawdzenia w konsoli powinny kolejno wypisać `true`, potwierdzając zachowanie kotwicy kształtu, zakresu tekstu i statusu.

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
    comment.setStatus(java.newByte(aspose.slides.ModernCommentStatus.Resolved));

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

### **Inspekcja istniejących nowoczesnych komentarzy**

Przykład wymaga istniejącej prezentacji zawierającej nowoczesne komentarze i wypisuje ich tekst, status oraz szczegóły kotwicy. Aby je zbadać, sprawdź, które komentarze są instancjami [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/), a następnie przeanalizuj [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) oraz [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/). `null` dla shape wskazuje na komentarz na poziomie slajdu. Dla kotwicy typu [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) metody wyboru tekstu identyfikują powiązany zakres w ramce tekstowej kształtu.

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

Aspose.Slides for Node.js via Java umożliwia usunięcie wszystkich komentarzy i ich autorów z prezentacji lub usunięcie wybranych komentarzy przy zachowaniu pozostałych. Poniższe przykłady demonstrują oba podejścia i zapisują zaktualizowaną prezentację.

### **Usuwanie wszystkich komentarzy i autorów komentarzy**

Przykład otwiera istniejącą prezentację i wywołuje [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/) dla każdego autora, a następnie wywołuje [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) w celu usunięcia samych autorów. Zapisana prezentacja nie zawiera ani komentarzy, ani autorów komentarzy. Użyj prezentacji z komentarzami, aby zobaczyć efekt usunięcia.

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

### **Usuwanie wybranych komentarzy**

Przykład tworzy dwa komentarze na jednym slajdzie i używa [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) do znalezienia komentarzy każdego autora. Zbiera komentarze, których tekst równa się „comment 1”, przed wywołaniem [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/), aby uniknąć modyfikacji kolekcji w trakcie wyboru. Zapisana prezentacja zachowuje tylko „comment 2”.

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

Tak. [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) i [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) zwracają wartość z wyliczenia [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/), w tym `Resolved`. Status jest przechowywany w prezentacji i może być odczytany po ponownym otwarciu pliku.

**Czy obsługiwane są wątki dyskusji (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżenia?**

Tak. Każdy komentarz może odnosić się do swojego [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/), umożliwiając tworzenie łańcuchów odpowiedzi. API nie definiuje konkretnego limitu głębokości zagnieżdżenia.

**W jakim systemie współrzędnych definiowana jest pozycja znacznika komentarza na slajdzie?**

Pozycja znacznika jest definiowana przez współrzędne zmiennoprzecinkowe w systemie współrzędnych slajdu, co pozwala precyzyjnie umieścić go na slajdzie.