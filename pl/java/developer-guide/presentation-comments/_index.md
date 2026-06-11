---
title: Zarządzanie komentarzami prezentacji w Javie
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
- kasuj komentarz
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Mistrzowskie zarządzanie komentarzami prezentacji przy użyciu Aspose.Slides for Java: dodawaj, odczytuj, edytuj i usuwaj komentarze w plikach PowerPoint szybko i łatwo."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji w Aspose.Slides. Pokazuje główne typy związane z komentarzami oraz demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami, używać nowoczesnych komentarzy i usuwać komentarze z prezentacji.

Przykłady koncentrują się na typowych scenariuszach przeglądu i współpracy w PowerPoint, takich jak przypisywanie komentarzy do autorów, odczytywanie treści i metadanych komentarzy, budowanie łańcuchów odpowiedzi oraz czyszczenie wszystkich komentarzy lub usuwanie wybranych.

W PowerPoint komentarz pojawia się jako notatka lub adnotacja na slajdzie. Po kliknięciu komentarza jego zawartość lub wiadomości są wyświetlane.

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz chcieć używać komentarzy, aby przekazywać opinie lub komunikować się z kolegami podczas przeglądania prezentacji.

Aby umożliwić używanie komentarzy w prezentacjach PowerPoint, Aspose.Slides for Java udostępnia

* Klasa [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation), która zawiera kolekcje autorów (z interfejsu [ICommentAuthorCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICommentAuthorCollection)). Autorzy dodają komentarze do slajdów. 
* Interfejs [ICommentCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICommentCollection), który zawiera kolekcję komentarzy dla poszczególnych autorów. 
* Klasa [IComment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IComment), zawierająca informacje o autorach i ich komentarzach: kto dodał komentarz, kiedy został dodany, pozycja komentarza itp. 
* Klasa [CommentAuthor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/CommentAuthor), zawierająca informacje o poszczególnych autorach: imię i nazwisko autora, jego inicjały, komentarze powiązane z nazwą autora itp. 

## **Dodawanie komentarzy do slajdu**
Ten kod Java pokazuje, jak dodać komentarz do slajdu w prezentacji PowerPoint:

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Dodaje pusty slajd
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Dodaje autora
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Ustawia pozycję dla komentarzy
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Dodaje komentarz slajdu dla autora na slajdzie 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Dodaje komentarz slajdu dla autora na slajdzie 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Uzyskuje dostęp do ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // Gdy jako argument zostanie przekazane null, komentarze od wszystkich autorów są pobierane do wybranego slajdu
    IComment[] Comments = slide.getSlideComments(author);

    // Uzyskuje dostęp do komentarza o indeksie 0 dla slajdu 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Wybiera kolekcję komentarzy autora o indeksie 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dostęp do komentarzy slajdu**
Ten kod Java pokazuje, jak uzyskać dostęp do istniejącego komentarza na slajdzie w prezentacji PowerPoint:

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Odpowiadanie na komentarze**
Komentarz nadrzędny to górny lub pierwotny komentarz w hierarchii komentarzy lub odpowiedzi. Używając metod [getParentComment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IComment#getParentComment--) lub [setParentComment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (z interfejsu [IComment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IComment)), możesz ustawić lub pobrać komentarz nadrzędny.

Ten kod Java pokazuje, jak dodawać komentarze i pobierać odpowiedzi na nie:

```java
Presentation pres = new Presentation();
try {
    // Dodaje komentarz
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Dodaje odpowiedź do comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Dodaje kolejną odpowiedź do comment1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Dodaje odpowiedź do istniejącej odpowiedzi
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Wyświetla hierarchię komentarzy w konsoli
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // Usuwa comment1 i wszystkie odpowiedzi do niego
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 
* Gdy metoda [Remove](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IComment#remove--) (z interfejsu [IComment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IComment)) jest używana do usunięcia komentarza, odpowiedzi na ten komentarz również są usuwane. 
* Jeśli ustawienie [setParentComment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) powoduje odniesienie cykliczne, zostanie zgłoszony [PptxEditException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/PptxEditException). 
{{% /alert %}}

## **Dodawanie nowoczesnych komentarzy**

W 2021 roku Microsoft wprowadził *nowoczesne komentarze* w PowerPoint. Funkcja nowoczesnych komentarzy znacznie usprawnia współpracę w PowerPoint. Dzięki nowoczesnym komentarzom użytkownicy PowerPoint mogą rozwiązywać komentarze, przypinać komentarze do obiektów i tekstów oraz prowadzić interakcje znacznie łatwiej niż wcześniej. 

W [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/pl/java/aspose-slides-for-java-21-11-release-notes/) wprowadziliśmy obsługę nowoczesnych komentarzy, dodając klasę [ModernComment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ModernComment). Metody [addModernComment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) i [insertModernComment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) zostały dodane do klasy [CommentCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/CommentCollection). 

Ten kod Java pokazuje, jak dodać nowoczesny komentarz do slajdu w prezentacji PowerPoint: 

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Usuwanie komentarzy**

### **Usuwanie wszystkich komentarzy i autorów**

Ten kod Java pokazuje, jak usunąć wszystkie komentarze i autorów w prezentacji:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Usuwa wszystkie komentarze z prezentacji
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Usuwa wszystkich autorów
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Usuwanie wybranych komentarzy**

Ten kod Java pokazuje, jak usunąć wybrane komentarze na slajdzie:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // dodaj komentarze...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // usuń wszystkie komentarze, które zawierają tekst "comment 1"
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Czy Aspose.Slides obsługuje status taki jak „rozwiązany” dla nowoczesnych komentarzy?**

Tak. [Nowoczesne komentarze](https://reference.aspose.com/slides/pl/java/com.aspose.slides/moderncomment/) udostępniają metodę [setStatus](https://reference.aspose.com/slides/pl/java/com.aspose.slides/moderncomment/#setStatus-byte-); możesz zapisać [stan komentarza](https://reference.aspose.com/slides/pl/java/com.aspose.slides/moderncommentstatus/) (na przykład oznaczyć go jako rozwiązany), a stan ten jest zapisywany w pliku i rozpoznawany przez PowerPoint.

**Czy obsługiwane są dyskusje wątkowe (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżania?**

Tak. Każdy komentarz może odwoływać się do swojego [komentarza nadrzędnego](https://reference.aspose.com/slides/pl/java/com.aspose.slides/comment/#getParentComment--), umożliwiając dowolne łańcuchy odpowiedzi. API nie określa konkretnego limitu głębokości zagnieżdżenia.

**W jakim systemie współrzędnych definiowana jest pozycja znacznika komentarza na slajdzie?**

Pozycja jest przechowywana jako punkt zmiennoprzecinkowy w systemie współrzędnych slajdu. Umożliwia to precyzyjne umieszczenie znacznika komentarza w wybranym miejscu.