---
title: Hantera presentationskommentarer i PHP
linktitle: Presentationskommentarer
type: docs
weight: 100
url: /sv/php-java/presentation-comments/
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
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Behärska presentationskommentarer med Aspose.Slides för PHP via Java: lägg till, läs, redigera och radera kommentarer i PowerPoint-filer snabbt och enkelt."
---
## **Översikt**

Den här artikeln förklarar hur du hanterar presentationskommentarer i Aspose.Slides. Den visar de viktigaste typerna som rör kommentarer och demonstrerar hur du lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar, använder moderna kommentarer och tar bort kommentarer från en presentation.

Exemplen fokuserar på vanliga gransknings- och samarbetsscenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentarinnehåll och metadata, bygga svarskedjor samt rensa alla kommentarer eller ta bort utvalda.

I PowerPoint visas en kommentar som en anteckning eller markering på en bild. När en kommentar klickas på visas dess innehåll eller meddelanden. 

## **Varför lägga till kommentarer i presentationer?**

Du kanske vill använda kommentarer för att ge återkoppling eller kommunicera med dina kollegor när du granskar presentationer.

För att du ska kunna använda kommentarer i PowerPoint‑presentationer tillhandahåller Aspose.Slides för PHP via Java

* Klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/), som innehåller samlingarna av författare (från klassen [CommentAuthorCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/commentauthorcollection/)). Författarna lägger till kommentarer på bilder.
* Klassen [CommentCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/commentcollection/), som innehåller samlingen av kommentarer för enskilda författare.
* Klassen [Comment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/comment/), som innehåller information om författare och deras kommentarer: vem som lade till kommentaren, tiden då kommentaren lades till, kommentari​ens position osv.
* Klassen [CommentAuthor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/commentauthor/) som innehåller information om enskilda författare: författarens namn, initialer, kommentarer kopplade till författarens namn osv.

## **Lägg till bildkommentarer**
Den här PHP‑koden visar hur du lägger till en kommentar på en bild i en PowerPoint‑presentation:

```php
  # Instansierar Presentation-klassen
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Lägger till en tom bild
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Lägger till en författare
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Sätter positionen för kommentarer
    $point = new Point2DFloat(0.2, 0.2);
    # Lägger till bildkommentar för en författare på bild 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Lägger till bildkommentar för en författare på bild 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Åtkomst till ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # När null skickas som argument, hämtas kommentarer från alla författare till den valda bilden
    $Comments = $slide->getSlideComments($author);
    # Åtkomst till kommentaren vid index 0 för bild 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Väljer författarens kommentarsamling vid index 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Få åtkomst till bildkommentarer**
Den här PHP‑koden visar hur du får åtkomst till en befintlig kommentar på en bild i en PowerPoint‑presentation:

```php
  # Instansierar Presentation-klassen
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

## **Svara på kommentarer**
En föräldrakommentar är den översta eller ursprungliga kommentaren i en hierarki av kommentarer eller svar. Med metoderna [getParentComment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/comment/getparentcomment/) eller [setParentComment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/comment/setparentcomment/) (från klassen [Comment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/comment/)) kan du hämta eller ange en föräldrakommentar.

Den här PHP‑koden visar hur du lägger till kommentarer och får svar på dem:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Lägger till en kommentar
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Lägger till ett svar på kommentar1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Lägger till ytterligare ett svar på kommentar1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Lägger till ett svar på ett befintligt svar
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Visar kommentarshierarkin i konsolen
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
    # Tar bort kommentar1 och alla svar på den
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Uppmärksamhet" %}} 

* När metoden [remove](https://reference.aspose.com/slides/sv/php-java/aspose.slides/comment/remove/) (från klassen [Comment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/comment/)) används för att ta bort en kommentar, tas även svaren på kommentaren bort.
* Om inställningen [setParentComment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/comment/setparentcomment/) resulterar i en cirkulär referens, kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxeditexception/).

{{% /alert %}}

## **Lägg till moderna kommentarer**

År 2021 introducerade Microsoft *moderna kommentarer* i PowerPoint. Funktionen för moderna kommentarer förbättrar samarbetet i PowerPoint avsevärt. Genom moderna kommentarer kan PowerPoint‑användare lösa kommentarer, fästa kommentarer på objekt och texter samt interagera mycket enklare än tidigare. 

Aspose Slides stöder moderna kommentarer via klassen [ModernComment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/). Metoderna [addModernComment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/commentcollection/addmoderncomment/) och [insertModernComment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/commentcollection/insertmoderncomment/) har lagts till i klassen [CommentCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/commentcollection/).

Den här PHP‑koden visar hur du lägger till en modern kommentar på en bild i en PowerPoint‑presentation:

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

## **Ta bort kommentarer**

### **Radera alla kommentarer och författare**

Den här PHP‑koden visar hur du tar bort alla kommentarer och författare i en presentation:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Tar bort alla kommentarer från presentationen
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Tar bort alla författare
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Radera specifika kommentarer**

Den här PHP‑koden visar hur du raderar specifika kommentarer på en bild:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # lägg till kommentarer...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # ta bort alla kommentarer som innehåller "comment 1" text
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

**Stöder Aspose.Slides ett statusvärde som “resolved” för moderna kommentarer?**

Ja. [Modern comments](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/) erbjuder metoden [setStatus](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/setstatus/); du kan ange en [kommentars status](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncommentstatus/) (till exempel markera den som löst), och detta tillstånd sparas i filen och känns igen av PowerPoint.

**Stöds trådade diskussioner (svarskedjor), och finns det en begränsning för djupet?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/comment/getparentcomment/), vilket möjliggör godtyckliga svarskedjor. API‑et deklarerar ingen specifik gräns för inbäddningsdjup.

**I vilket koordinatsystem är en kommentarmärka‑position definierad på en bild?**

Positionen lagras som ett flyttal‑punkt i bildens koordinatsystem. Detta låter dig placera kommentarmärket exakt där du behöver det.