---
title: Beheer presentatie‑opmerkingen in PHP
linktitle: Presentatie‑opmerkingen
type: docs
weight: 100
url: /nl/php-java/presentation-comments/
keywords:
- opmerking
- moderne opmerking
- PowerPoint‑opmerkingen
- presentatie‑opmerkingen
- dia‑opmerkingen
- opmerking toevoegen
- opmerking benaderen
- opmerking bewerken
- opmerking beantwoorden
- opmerking verwijderen
- opmerking verwijderen
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer presentatie‑opmerkingen met Aspose.Slides for PHP via Java: voeg opmerkingen toe, lees, bewerk en verwijder opmerkingen in PowerPoint‑bestanden snel en eenvoudig."
---
## **Overzicht**

Dit artikel legt uit hoe u opmerkingen in een presentatie kunt beheren met Aspose.Slides. Het toont de belangrijkste typen die met opmerkingen te maken hebben en laat zien hoe u opmerkingen aan dia's toevoegt, bestaande opmerkingen benadert, met reacties werkt, moderne opmerkingen gebruikt en opmerkingen uit een presentatie verwijdert.

De voorbeelden richten zich op veelvoorkomende beoordelings- en samenwerkingsscenario's in PowerPoint, zoals het toewijzen van opmerkingen aan auteurs, het lezen van de inhoud en metadata van opmerkingen, het opbouwen van reactieketens en het wissen van alle opmerkingen of het verwijderen van geselecteerde opmerkingen.

In PowerPoint verschijnt een opmerking als een notitie of annotatie op een dia. Wanneer op een opmerking wordt geklikt, wordt de inhoud of de berichten getoond.

## **Waarom opmerkingen aan presentaties toevoegen?**

U wilt mogelijk opmerkingen gebruiken om feedback te geven of te communiceren met uw collega's wanneer u presentaties beoordeelt.

Om u toe te staan opmerkingen te gebruiken in PowerPoint‑presentaties, biedt Aspose.Slides for PHP via Java

* De [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse, die de collecties van auteurs bevat (vanuit de [CommentAuthorCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commentauthorcollection/)‑klasse). De auteurs voegen opmerkingen toe aan dia's.
* De [CommentCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commentcollection/)‑klasse, die de verzameling van opmerkingen voor individuele auteurs bevat.
* De [Comment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/)‑klasse, die informatie bevat over auteurs en hun opmerkingen: wie de opmerking heeft toegevoegd, het tijdstip van toevoeging, de positie van de opmerking, enz.
* De [CommentAuthor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commentauthor/)‑klasse, die informatie bevat over individuele auteurs: de naam van de auteur, zijn initialen, opmerkingen die aan de naam van de auteur zijn gekoppeld, enz.

## **Opmerkingen aan dia toevoegen**
Deze PHP‑code laat zien hoe u een opmerking aan een dia in een PowerPoint‑presentatie kunt toevoegen:

```php
  # Instantieert de Presentation‑klasse
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Voegt een lege dia toe
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Voegt een auteur toe
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Stelt de positie voor opmerkingen in
    $point = new Point2DFloat(0.2, 0.2);
    # Voegt een dia‑opmerking toe voor een auteur op dia 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Voegt een dia‑opmerking toe voor een auteur op dia 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Benadert ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # Wanneer null als argument wordt doorgegeven, worden opmerkingen van alle auteurs naar de geselecteerde dia gehaald
    $Comments = $slide->getSlideComments($author);
    # Accesses the comment at index 0 for slide 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Selecteert de opmerkingenverzameling van de auteur op index 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Opmerkingen op dia benaderen**
Deze PHP‑code laat zien hoe u een bestaande opmerking op een dia in een PowerPoint‑presentatie kunt benaderen:

```php
  # Instantieert de Presentation-klasse
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

## **Reacties op opmerkingen**
Een bovenliggende opmerking is de bovenste of oorspronkelijke opmerking in een hiërarchie van opmerkingen of reacties. Met de [getParentComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/getparentcomment/)‑ of [setParentComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/setparentcomment/)‑methoden (van de [Comment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/)‑klasse) kunt u een bovenliggende opmerking instellen of opvragen.

Deze PHP‑code laat zien hoe u opmerkingen kunt toevoegen en reacties daarop kunt opvragen:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Voegt een opmerking toe
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Voegt een reactie toe aan comment1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Voegt een andere reactie toe aan comment1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Voegt een reactie toe aan een bestaande reactie
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Toont de hiërarchie van opmerkingen op de console
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
    # Verwijdert comment1 en alle reacties daarop
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Let op" %}} 
* Wanneer de [remove](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/remove/)‑methode (van de [Comment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/)‑klasse) wordt gebruikt om een opmerking te verwijderen, worden ook de reacties op die opmerking verwijderd.
* Als de instelling met [setParentComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/setparentcomment/) resulteert in een circulaire verwijzing, wordt er een [PptxEditException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxeditexception/) opgeworpen.
{{% /alert %}}

## **Moderne opmerkingen toevoegen**

In 2021 heeft Microsoft *moderne opmerkingen* geïntroduceerd in PowerPoint. De functie voor moderne opmerkingen verbetert de samenwerking in PowerPoint aanzienlijk. Met moderne opmerkingen kunnen PowerPoint‑gebruikers opmerkingen oplossen, opmerkingen verankeren aan objecten en tekst, en veel makkelijker interacties aangaan dan voorheen.

Aspose Slides ondersteunt moderne opmerkingen via de [ModernComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/)‑klasse. De methoden [addModernComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commentcollection/addmoderncomment/) en [insertModernComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commentcollection/insertmoderncomment/) zijn toegevoegd aan de [CommentCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commentcollection/)‑klasse.

Deze PHP‑code laat zien hoe u een moderne opmerking aan een dia in een PowerPoint‑presentatie kunt toevoegen:

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

## **Opmerkingen verwijderen**

### **Alle opmerkingen en auteurs verwijderen**
Deze PHP‑code laat zien hoe u alle opmerkingen en auteurs in een presentatie kunt verwijderen:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Verwijdert alle opmerkingen uit de presentatie
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Verwijdert alle auteurs
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Specifieke opmerkingen verwijderen**
Deze PHP‑code laat zien hoe u specifieke opmerkingen op een dia kunt verwijderen:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # voeg opmerkingen toe...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # verwijder alle opmerkingen die de tekst "comment 1" bevatten
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

**Ondersteunt Aspose.Slides een status zoals 'opgelost' voor moderne opmerkingen?**

Ja. [Modern comments](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/) bieden een [setStatus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/setstatus/)‑methode; u kunt de [status van een opmerking](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncommentstatus/) (bijvoorbeeld markeren als opgelost) vastleggen, en deze status wordt opgeslagen in het bestand en herkend door PowerPoint.

**Worden threaddiscussies (reactieketens) ondersteund, en is er een limiet op de diepte?**

Ja. Elke opmerking kan zijn [bovenliggende opmerking](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/getparentcomment/) refereren, waardoor willekeurige reactieketens mogelijk zijn. De API geeft geen specifieke limiet voor de nestingsdiepte aan.

**In welk coördinatensysteem wordt de positie van een opmerkingmarker op een dia gedefinieerd?**

De positie wordt opgeslagen als een drijvend‑punt in het coördinatensysteem van de dia. Hierdoor kunt u de opmerkingmarker precies plaatsen waar u dat nodig heeft.