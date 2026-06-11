---
title: Zarządzanie komentarzami w prezentacji w PHP
linktitle: Komentarze w prezentacji
type: docs
weight: 100
url: /pl/php-java/presentation-comments/
keywords:
- komentarz
- nowoczesny komentarz
- komentarze PowerPoint
- komentarze prezentacji
- komentarze slajdów
- dodaj komentarz
- uzyskaj dostęp do komentarza
- edytuj komentarz
- odpowiedz na komentarz
- usuń komentarz
- skasuj komentarz
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Opanuj komentarze w prezentacjach przy użyciu Aspose.Slides for PHP via Java: dodawaj, odczytuj, edytuj i usuwaj komentarze w plikach PowerPoint szybko i łatwo."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji w Aspose.Slides. Pokazuje główne typy związane z komentarzami oraz demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami, używać nowoczesnych komentarzy i usuwać komentarze z prezentacji.

Przykłady koncentrują się na typowych scenariuszach przeglądu i współpracy w programie PowerPoint, takich jak przypisywanie komentarzy do autorów, odczytywanie treści i metadanych komentarzy, budowanie łańcuchów odpowiedzi oraz czyszczenie wszystkich komentarzy lub usuwanie wybranych.

W programie PowerPoint komentarz pojawia się jako notatka lub adnotacja na slajdzie. Po kliknięciu komentarza jego zawartość lub wiadomości są wyświetlane. 

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz chcieć używać komentarzy, aby przekazywać informacje zwrotne lub komunikować się z kolegami podczas przeglądania prezentacji.

Aby umożliwić używanie komentarzy w prezentacjach PowerPoint, Aspose.Slides for PHP via Java udostępnia

* Klasa [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) , która zawiera kolekcje autorów (z klasy [CommentAuthorCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/commentauthorcollection/)). Autorzy dodają komentarze do slajdów.
* Klasa [CommentCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/commentcollection/) , która zawiera kolekcję komentarzy dla poszczególnych autorów.
* Klasa [Comment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/comment/) , która zawiera informacje o autorach i ich komentarzach: kto dodał komentarz, kiedy został dodany, pozycję komentarza itd.
* Klasa [CommentAuthor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/commentauthor/) , która zawiera informacje o poszczególnych autorach: imię i nazwisko autora, jego inicjały, komentarze powiązane z nazwą autora itd.

## **Dodawanie komentarzy do slajdów**
Ten kod PHP pokazuje, jak dodać komentarz do slajdu w prezentacji PowerPoint:

```php
  # Tworzy instancję klasy Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Dodaje pusty slajd
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Dodaje autora
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Ustawia pozycję komentarzy
    $point = new Point2DFloat(0.2, 0.2);
    # Dodaje komentarz slajdu dla autora na slajdzie 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Dodaje komentarz slajdu dla autora na slajdzie 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Uzyskuje dostęp do ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # Gdy jako argument przekazany jest null, komentarze od wszystkich autorów są pobierane dla wybranego slajdu
    $Comments = $slide->getSlideComments($author);
    # Uzyskuje dostęp do komentarza o indeksie 0 dla slajdu 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Wybiera kolekcję komentarzy autora o indeksie 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Uzyskiwanie dostępu do komentarzy slajdu**
Ten kod PHP pokazuje, jak uzyskać dostęp do istniejącego komentarza na slajdzie w prezentacji PowerPoint:

```php
  # Instancjonuje klasę Presentation
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " has comment: " . $comment->getText() . " with Author: " . $comment->getAuthor()->getName() . " posted on time :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Odpowiadanie na komentarze**
Komentarz nadrzędny jest górnym lub oryginalnym komentarzem w hierarchii komentarzy lub odpowiedzi. Używając metod [getParentComment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/comment/getparentcomment/) lub [setParentComment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/comment/setparentcomment/) (z klasy [Comment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/comment/) ), możesz ustawić lub pobrać komentarz nadrzędny.

Ten kod PHP pokazuje, jak dodać komentarze i uzyskać odpowiedzi na nie:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Dodaje komentarz
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Dodaje odpowiedź do comment1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Dodaje kolejną odpowiedź do comment1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Dodaje odpowiedź do istniejącej odpowiedzi
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Wyświetla hierarchię komentarzy w konsoli
    $slide = $pres->getSlides()->get_Item(0);
    $comments = $slide->getSlideComments(null);
    for($i = 0; $i < java_values($Array->getLength($comments)) ; $i++) {
      $comment = $comments[$i];
      while (!java_is_null($comment->getParentComment())) {
        System->out->print("\t");
        $comment = $comment->getParentComment();
      } 
      echo($comments[$i]->getAuthor()->getName() . " : " . $comments[$i]->getText());
      echo();
    }
    $pres->save("parent_comment.pptx", SaveFormat::Pptx);
    # Usuwa comment1 i wszystkie odpowiedzi do niego
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Uwaga" %}} 
* Gdy metoda [remove](https://reference.aspose.com/slides/pl/php-java/aspose.slides/comment/remove/) (z klasy [Comment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/comment/) ) jest używana do usunięcia komentarza, odpowiedzi na ten komentarz również zostają usunięte.
* Jeśli ustawienie [setParentComment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/comment/setparentcomment/) spowoduje odwołanie cykliczne, zostanie rzucony wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Dodawanie nowoczesnych komentarzy**

W 2021 roku Microsoft wprowadził *nowoczesne komentarze* w programie PowerPoint. Funkcja nowoczesnych komentarzy znacząco usprawnia współpracę w PowerPoint. Dzięki nowoczesnym komentarzom użytkownicy PowerPoint mogą rozwiązywać komentarze, przypinać je do obiektów i tekstów oraz prowadzić interakcje znacznie łatwiej niż wcześniej. 

Aspose Slides obsługuje nowoczesne komentarze za pomocą klasy [ModernComment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/). Metody [addModernComment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/commentcollection/addmoderncomment/) i [insertModernComment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/commentcollection/insertmoderncomment/) zostały dodane do klasy [CommentCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/commentcollection/).

Ten kod PHP pokazuje, jak dodać nowoczesny komentarz do slajdu w prezentacji PowerPoint:

```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Some Author", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("This is a modern comment", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Usuwanie komentarzy**

### **Usuwanie wszystkich komentarzy i autorów**

Ten kod PHP pokazuje, jak usunąć wszystkie komentarze i autorów w prezentacji:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Usuwa wszystkie komentarze z prezentacji
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Usuwa wszystkich autorów
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Usuwanie konkretnych komentarzy**

Ten kod PHP pokazuje, jak usunąć określone komentarze na slajdzie:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # dodaj komentarze...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # usuń wszystkie komentarze, które zawierają tekst "comment 1"
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("comment 1")) {
          $toRemove->add($comment);
        }
      }
      foreach($toRemove as $comment) {
        $commentAuthor->getComments()->remove($comment);
      }
    }
    $presentation->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **FAQ**

**Czy Aspose.Slides obsługuje status taki jak „rozwiązany” dla nowoczesnych komentarzy?**

Tak. [Modern comments](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/) udostępniają metodę [setStatus](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/setstatus/). Możesz ustawić stan komentarza (na przykład oznaczyć go jako rozwiązany), a stan ten jest zapisywany w pliku i rozpoznawany przez PowerPoint.

**Czy obsługiwane są dyskusje wątka (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżania?**

Tak. Każdy komentarz może odwoływać się do swojego komentarza nadrzędnego, co umożliwia dowolne łańcuchy odpowiedzi. API nie określa konkretnego limitu głębokości zagnieżdżenia.

**W jakim układzie współrzędnych określona jest pozycja znacznika komentarza na slajdzie?**

Pozycja jest przechowywana jako punkt zmiennoprzecinkowy w układzie współrzędnych slajdu. Dzięki temu możesz umieścić znacznik komentarza dokładnie tam, gdzie jest potrzebny.