---
title: PHP-ban a prezentációs megjegyzések kezelése
linktitle: Prezentációs megjegyzések
type: docs
weight: 100
url: /hu/php-java/presentation-comments/
keywords:
- megjegyzés
- modern megjegyzés
- PowerPoint megjegyzések
- prezentációs megjegyzések
- dia megjegyzések
- megjegyzés hozzáadása
- megjegyzés elérése
- megjegyzés szerkesztése
- megjegyzésre válasz
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Kezeld a prezentációs megjegyzéseket az Aspose.Slides for PHP via Java segítségével: gyorsan és egyszerűen adj hozzá, olvass, szerkessz és törölj megjegyzéseket PowerPoint fájlokban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a prezentációs megjegyzések az Aspose.Slides-ban. Bemutatja a fő megjegyzésekkel kapcsolatos típusokat, és demonstrálja, hogyan lehet megjegyzéseket hozzáadni a diákhoz, elérni a meglévő megjegyzéseket, válaszokkal dolgozni, modern megjegyzéseket használni, és a megjegyzéseket eltávolítani egy prezentációból.

Az példák a PowerPoint gyakori felülvizsgálati és együttműködési forgatókönyveire összpontosítanak, például a megjegyzések szerzőkhöz rendelésére, a megjegyzés tartalmának és metaadatainak olvasására, válaszláncok felépítésére, valamint az összes megjegyzés törlésére vagy a kijelölt megjegyzések eltávolítására.

A PowerPointban a megjegyzés jegyzetként vagy annotációként jelenik meg egy dián. Amikor egy megjegyzésre kattintanak, annak tartalma vagy üzenetei megjelennek.

## **Miért adjunk megjegyzéseket a prezentációkhoz?**

Érdemes megjegyzéseket használni visszajelzés nyújtására vagy a kollégákkal való kommunikációra a prezentációk felülvizsgálata során.

Annak érdekében, hogy megjegyzéseket használhass a PowerPoint prezentációkban, az Aspose.Slides for PHP via Java a következőket biztosítja
* A [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztály, amely tartalmazza a szerzők gyűjteményét (a [CommentAuthorCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/commentauthorcollection/) osztályból). A szerzők megjegyzéseket adnak a diákhoz.
* The  [CommentCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/commentcollection/) osztály, amely az egyes szerzők megjegyzéseinek gyűjteményét tartalmazza.
* The  [Comment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/comment/) osztály, amely információkat tartalmaz a szerzőkről és a megjegyzéseikről: ki adta a megjegyzést, mikor adták hozzá, a megjegyzés pozíciója, stb.
* A [CommentAuthor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/commentauthor/) osztály, amely az egyes szerzőkről tartalmaz információkat: a szerző neve, monogramja, a szerző nevéhez kapcsolódó megjegyzések, stb.

## **Dia Megjegyzések hozzáadása**
Ez a PHP kód bemutatja, hogyan adhatunk megjegyzést egy diára egy PowerPoint prezentációban:

```php
  # Példányosítja a Presentation osztályt
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Üres diát ad hozzá
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Szerzőt ad hozzá
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Beállítja a megjegyzések pozícióját
    $point = new Point2DFloat(0.2, 0.2);
    # Dia megjegyzést ad hozzá egy szerzőnek az 1. dián
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Dia megjegyzést ad hozzá egy szerzőnek a 2. dián
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Az ISlide 1-hez fér hozzá
    $slide = $pres->getSlides()->get_Item(0);
    # Ha null értéket adunk meg argumentumként, akkor az összes szerző megjegyzései a kiválasztott diára kerülnek
    $Comments = $slide->getSlideComments($author);
    # Eléri a 0. indexű megjegyzést az 1. dián
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Kiválasztja a szerző megjegyzésgyűjteményét a 0. indexen
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dia Megjegyzések elérése**
Ez a PHP kód bemutatja, hogyan érhetünk el egy meglévő megjegyzést egy dián egy PowerPoint prezentációban:

```php
  # Példányosítja a Presentation osztályt
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

## **Megjegyzések válaszolása**
A szülő megjegyzés a hierarchia legfelső vagy eredeti megjegyzése a megjegyzések vagy válaszok sorában. A [getParentComment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/comment/getparentcomment/) vagy a [setParentComment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/comment/setparentcomment/) metódusok (a [Comment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/comment/) osztályból) használatával beállíthat vagy lekérdezhet egy szülő megjegyzést.

Ez a PHP kód bemutatja, hogyan adhatunk megjegyzéseket és hogyan kaphatunk válaszokat rájuk:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Hozzáad egy megjegyzést
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Hozzáad egy választ a comment1-hez
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Hozzáad egy másik választ a comment1-hez
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Hozzáad egy választ egy meglévő válaszhoz
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Kiírja a megjegyzések hierarchiáját a konzolra
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
    # Eltávolítja a comment1-et és az összes hozzá tartozó válaszát
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Attention" %}} 
* Amikor a [remove](https://reference.aspose.com/slides/hu/php-java/aspose.slides/comment/remove/) metódust (a [Comment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/comment/) osztályból) használják egy megjegyzés törlésére, a megjegyzésre adott válaszok is törlésre kerülnek.
* Ha a [setParentComment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/comment/setparentcomment/) beállítás körkörös hivatkozást eredményez, akkor [PptxEditException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxeditexception/) lesz dobva.

{{% /alert %}}

## **Modern megjegyzések hozzáadása**

2021-ben a Microsoft bevezette a *modern megjegyzéseket* a PowerPointban. A modern megjegyzések funkció jelentősen javítja az együttműködést a PowerPointban. A modern megjegyzésekkel a PowerPoint felhasználók könnyebben oldhatják fel a megjegyzéseket, rögzíthetik azokat objektumokhoz és szövegekhez, és sokkal egyszerűbben vegyenek részt a kommunikációban.  

Az Aspose Slides a [ModernComment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/) osztállyal támogatja a modern megjegyzéseket. A [addModernComment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/commentcollection/addmoderncomment/) és a [insertModernComment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/commentcollection/insertmoderncomment/) metódusokat hozzáadták a [CommentCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/commentcollection/) osztályhoz.

Ez a PHP kód bemutatja, hogyan adhatunk modern megjegyzést egy diára egy PowerPoint prezentációban:

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

## **Megjegyzések eltávolítása**

### **Az összes megjegyzés és szerző törlése**

Ez a PHP kód bemutatja, hogyan lehet eltávolítani az összes megjegyzést és szerzőt egy prezentációból:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Törli az összes megjegyzést a prezentációból
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Törli az összes szerzőt
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Adott megjegyzések törlése**

Ez a PHP kód bemutatja, hogyan törölhetünk adott megjegyzéseket egy dián:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # kommentek hozzáadása...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # eltávolítja az összes olyan megjegyzést, amely tartalmazza a "comment 1" szöveget
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

## **GYIK**

**Támogatja az Aspose.Slides a 'megoldott' státuszt a modern megjegyzéseknél?**

Igen. A [Modern comments](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/) rendelkezik egy [setStatus](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/setstatus/) metódussal; a [comment’s state](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncommentstatus/) (például megjelölheted megoldottként) beírható, és ez az állapot a fájlban mentésre kerül, valamint a PowerPoint felismeri.

**Támogatottak a szálas beszélgetések (válaszláncok), és van-e beágyazási korlát?**

Igen. Minden megjegyzés hivatkozhat a saját [parent comment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/comment/getparentcomment/), ezáltal tetszőleges válaszláncok jöhetnek létre. Az API nem határoz meg konkrét beágyazási mélységkorlátot.

**Milyen koordináta-rendszerben van meghatározva egy megjegyzésjelző pozíciója a dián?**

A pozíció a diák koordináta-rendszerében lebegőpontos pontként van tárolva. Ez lehetővé teszi, hogy a megjegyzésjelzőt pontosan oda helyezd, ahová szükséged van.