---
title: Zarządzanie komentarzami prezentacji w JavaScript
linktitle: Komentarze prezentacji
type: docs
weight: 100
url: /pl/nodejs-java/presentation-comments/
keywords:
- komentarz
- nowoczesny komentarz
- komentarze PowerPoint
- komentarze prezentacji
- komentarze slajdu
- dodaj komentarz
- dostęp do komentarza
- edytuj komentarz
- odpowiedz na komentarz
- usuń komentarz
- usuń komentarz
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Opanuj komentarze prezentacji z Aspose.Slides dla Node.js: dodawaj, odczytuj, edytuj i usuwaj komentarze w plikach PowerPoint przy użyciu JavaScript szybko i łatwo."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami prezentacji w Aspose.Slides. Pokazuje główne typy związane z komentarzami oraz demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami, używać nowoczesnych komentarzy i usuwać komentarze z prezentacji.

Przykłady koncentrują się na typowych scenariuszach recenzji i współpracy w PowerPoint, takich jak przypisywanie komentarzy do autorów, odczytywanie treści i metadanych komentarzy, budowanie łańcuchów odpowiedzi oraz czyszczenie wszystkich komentarzy lub usuwanie wybranych.

W PowerPoint komentarz pojawia się jako notatka lub adnotacja na slajdzie. Po kliknięciu komentarza jego zawartość lub wiadomości są wyświetlane.

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz chcieć używać komentarzy, aby przekazać uwagi lub komunikować się ze współpracownikami podczas przeglądania prezentacji.

Aby umożliwić używanie komentarzy w prezentacjach PowerPoint, Aspose.Slides dla Node.js via Java udostępnia

* Klasa [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), która zawiera kolekcje autorów (z klasy [CommentAuthorCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/CommentAuthorCollection)). Autorzy dodają komentarze do slajdów.
* Klasa [CommentCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/CommentCollection), która zawiera kolekcję komentarzy dla poszczególnych autorów.
* Klasa [Comment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Comment), która zawiera informacje o autorach i ich komentarzach: kto dodał komentarz, kiedy został dodany, pozycję komentarza itp.
* Klasa [CommentAuthor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/CommentAuthor), która zawiera informacje o poszczególnych autorach: imię autora, jego inicjały, komentarze powiązane z nazwą autora itp.

## **Dodawanie komentarza do slajdu**
Ten kod JavaScript pokazuje, jak dodać komentarz do slajdu w prezentacji PowerPoint:

```javascript
// Tworzy instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Dodaje pusty slajd
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // Dodaje autora
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // Ustawia pozycję dla komentarzy
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // Dodaje komentarz slajdu dla autora na slajdzie 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // Dodaje komentarz slajdu dla autora na slajdzie 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // Uzyskuje dostęp do ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // Gdy jako argument zostanie przekazane null, komentarze od wszystkich autorów są pobierane dla wybranego slajdu
    var Comments = slide.getSlideComments(author);
    // Uzyskuje dostęp do komentarza o indeksie 0 dla slajdu 1
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // Wybiera kolekcję komentarzy autora o indeksie 0
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dostęp do komentarzy slajdu**
Ten kod JavaScript pokazuje, jak uzyskać dostęp do istniejącego komentarza na slajdzie w prezentacji PowerPoint:

```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Odpowiedzi na komentarze**
Komentarz nadrzędny to górny lub oryginalny komentarz w hierarchii komentarzy lub odpowiedzi. Korzystając z metod [getParentComment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Comment#getParentComment--) lub [setParentComment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (z klasy [Comment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Comment)), możesz ustawić lub pobrać komentarz nadrzędny.

Ten kod JavaScript pokazuje, jak dodać komentarze i pobrać odpowiedzi do nich:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Dodaje komentarz
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // Dodaje odpowiedź do comment1
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // Dodaje kolejną odpowiedź do comment1
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // Dodaje odpowiedź do istniejącej odpowiedzi
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // Wyświetla hierarchię komentarzy w konsoli
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // Usuwa comment1 i wszystkie odpowiedzi do niego
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Uwaga" %}} 

* Gdy metoda [Remove](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Comment#remove--) (z klasy [Comment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Comment)) jest używana do usunięcia komentarza, również usuwane są odpowiedzi do tego komentarza.
* Jeśli ustawienie [setParentComment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) prowadzi do cyklicznego odwołania, zostanie rzucony wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PptxEditException).

{{% /alert %}}

## **Dodawanie nowoczesnego komentarza**

W 2021 roku Microsoft wprowadził *nowoczesne komentarze* w PowerPoint. Funkcja nowoczesnych komentarzy znacznie poprawia współpracę w PowerPoint. Dzięki nowoczesnym komentarzom użytkownicy PowerPoint mogą rozwiązywać komentarze, przypinać je do obiektów i tekstów oraz prowadzić interakcje znacznie łatwiej niż wcześniej.

Aspose.Slides obsługuje nowoczesne komentarze za pomocą klasy [ModernComment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ModernComment). Do klasy [CommentCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/CommentCollection) dodano metody [addModernComment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) i [insertModernComment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-).

Ten kod JavaScript pokazuje, jak dodać nowoczesny komentarz do slajdu w prezentacji PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Usuwanie komentarza**

### **Usunięcie wszystkich komentarzy i autorów**

Ten kod JavaScript pokazuje, jak usunąć wszystkie komentarze i autorów w prezentacji:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Usuwa wszystkie komentarze z prezentacji
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // Usuwa wszystkich autorów
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Usunięcie wybranych komentarzy**

Ten kod JavaScript pokazuje, jak usunąć wybrane komentarze na slajdzie:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // dodaj komentarze...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // usuń wszystkie komentarze zawierające tekst "comment 1"
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Czy Aspose.Slides obsługuje status taki jak „rozwiązany” dla nowoczesnych komentarzy?**

Tak. [Modern comments](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/) udostępniają metody [getStatus](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/getstatus/) i [setStatus](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncomment/setStatus/); możesz odczytać i ustawić [stan komentarza](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/moderncommentstatus/) (na przykład oznaczyć go jako rozwiązany), a stan ten jest zapisywany w pliku i rozpoznawany przez PowerPoint.

**Czy obsługiwane są dyskusje wątki (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżenia?**

Tak. Każdy komentarz może odwoływać się do swojego [parent comment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/comment/getparentcomment/), umożliwiając dowolne łańcuchy odpowiedzi. API nie określa konkretnego limitu głębokości zagnieżdżenia.

**W jakim systemie współrzędnych definiowana jest pozycja znacznika komentarza na slajdzie?**

Pozycja jest przechowywana jako punkt zmiennoprzecinkowy w systemie współrzędnych slajdu. Dzięki temu możesz precyzyjnie umieścić znacznik komentarza w wybranym miejscu.