---
title: Spravovat komentáře v prezentaci v PHP
linktitle: Komentáře v prezentaci
type: docs
weight: 100
url: /cs/php-java/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPoint
- komentáře prezentace
- komentáře snímku
- přidat komentář
- přístup k komentáři
- upravit komentář
- odpovědět na komentář
- odstranit komentář
- smazat komentář
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Mistrně spravujte komentáře v prezentacích s Aspose.Slides pro PHP přes Java: přidávejte, čtěte, upravujte a mažte komentáře v souborech PowerPoint rychle a snadno."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře v prezentacích v Aspose.Slides. Ukazuje hlavní typy související s komentáři a demonstruje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi, používat moderní komentáře a odstraňovat komentáře z prezentace.

Příklady se zaměřují na běžné scénáře revize a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení obsahu a metadat komentářů, vytváření řetězců odpovědí a vymazávání všech komentářů nebo mazání vybraných.

V PowerPointu se komentář zobrazuje jako poznámka nebo anotace na snímku. Po kliknutí na komentář se zobrazí jeho obsah nebo zprávy.

## **Proč přidávat komentáře do prezentací?**

Možná budete chtít používat komentáře k poskytování zpětné vazby nebo komunikaci s kolegy při revizi prezentací.

Aby vám umožnily používat komentáře v prezentacích PowerPoint, Aspose.Slides pro PHP prostřednictvím Java poskytuje
* Třída [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) obsahuje kolekce autorů (z třídy [CommentAuthorCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/commentauthorcollection/)). Autoři přidávají komentáře do snímků.
* Třída [CommentCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/commentcollection/) obsahuje kolekci komentářů pro jednotlivé autory.
* Třída [Comment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/comment/) obsahuje informace o autorech a jejich komentářích: kdo komentář přidal, kdy byl komentář přidán, pozice komentáře atd.
* Třída [CommentAuthor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/commentauthor/) obsahuje informace o jednotlivých autorech: jméno autora, jeho iniciály, komentáře přiřazené k jménu autora atd.

## **Přidání komentářů ke snímku**
Tento PHP kód ukazuje, jak přidat komentář ke snímku v prezentaci PowerPoint:

```php
  # Instancuje třídu Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Přidá prázdný snímek
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Přidá autora
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Nastaví pozici pro komentáře
    $point = new Point2DFloat(0.2, 0.2);
    # Přidá komentář ke snímku pro autora na snímku 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Přidá komentář ke snímku pro autora na snímku 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Přistupuje k ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # Když je jako argument předáno null, komentáře od všech autorů jsou přineseny do vybraného snímku
    $Comments = $slide->getSlideComments($author);
    # Přistupuje k komentáři na indexu 0 pro snímek 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Vybere kolekci komentářů autora na indexu 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přístup ke komentářům ke snímku**
Tento PHP kód ukazuje, jak přistupovat k existujícímu komentáři na snímku v prezentaci PowerPoint:

```php
  # Instancuje třídu Presentation
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

## **Odpovědi na komentáře**
Nadřazený komentář je vrcholový nebo původní komentář v hierarchii komentářů či odpovědí. Pomocí metod [getParentComment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/comment/getparentcomment/) nebo [setParentComment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/comment/setparentcomment/) (z třídy [Comment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/comment/)) můžete nastavit nebo získat nadřazený komentář.

Tento PHP kód ukazuje, jak přidávat komentáře a získávat odpovědi na ně:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Přidá komentář
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Přidá odpověď na komentář 1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Přidá další odpověď na komentář 1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Přidá odpověď na existující odpověď
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Zobrazí hierarchii komentářů na konzoli
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
    # Odstraní komentar1 a všechny odpovědi na něj
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Attention" %}} 
* Když je metoda [remove](https://reference.aspose.com/slides/cs/php-java/aspose.slides/comment/remove/) (z třídy [Comment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/comment/)) použita k odstranění komentáře, odpovědi na tento komentář jsou také smazány.
* Pokud nastavení [setParentComment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/comment/setparentcomment/) vede k cyklickému odkazu, bude vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Přidání moderních komentářů**

V roce 2021 společnost Microsoft představila *moderní komentáře* v PowerPointu. Funkce moderních komentářů výrazně zlepšuje spolupráci v PowerPointu. Prostřednictvím moderních komentářů mohou uživatelé PowerPointu řešit komentáře, přiřazovat komentáře k objektům a textům a zapojovat se do interakcí mnohem snadněji než dříve. 

Aspose Slides podporuje moderní komentáře třídou [ModernComment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/). Metody [addModernComment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/commentcollection/addmoderncomment/) a [insertModernComment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/commentcollection/insertmoderncomment/) byly přidány do třídy [CommentCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/commentcollection/).

Tento PHP kód ukazuje, jak přidat moderní komentář ke snímku v prezentaci PowerPoint:

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

## **Odstranění komentářů**

### **Smazat všechny komentáře a autory**
Tento PHP kód ukazuje, jak odstranit všechny komentáře a autory v prezentaci:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Smaže všechny komentáře z prezentace
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Smaže všechny autory
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Smazat konkrétní komentáře**
Tento PHP kód ukazuje, jak smazat konkrétní komentáře na snímku:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # přidat komentáře...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # odstranit všechny komentáře, které obsahují "comment 1" text
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

## **Často kladené otázky**

**Podporuje Aspose.Slides stav jako „vyřešeno“ pro moderní komentáře?**

Ano. [Moderní komentáře](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/) poskytují metodu [setStatus](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/setstatus/). Můžete nastavit [stav komentáře](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncommentstatus/) (například označit jej jako vyřešený) a tento stav je uložen v souboru a rozpoznán PowerPointem.

**Jsou podporována vlákna diskuzí (řetězce odpovědí) a existuje omezení hloubky vnoření?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/comment/getparentcomment/), což umožňuje libovolné řetězce odpovědí. API neuvádí konkrétní limit hloubky vnoření.

**V jakém souřadnicovém systému je definována pozice značky komentáře na snímku?**

Pozice je uložena jako desetinný bod v souřadnicovém systému snímku. To vám umožňuje umístit značku komentáře přesně tam, kde ji potřebujete.