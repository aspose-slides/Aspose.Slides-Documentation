---
title: Gestire i commenti della presentazione in PHP
linktitle: Commenti della presentazione
type: docs
weight: 100
url: /it/php-java/presentation-comments/
keywords:
- commento
- commento moderno
- commenti PowerPoint
- commenti della presentazione
- commenti diapositiva
- aggiungi commento
- accedi al commento
- modifica commento
- rispondi al commento
- rimuovi commento
- elimina commento
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci i commenti della presentazione con Aspose.Slides per PHP via Java: aggiungi, leggi, modifica ed elimina i commenti nei file PowerPoint in modo rapido e semplice."
---
## **Panoramica**

Questo articolo spiega come gestire i commenti di presentazione in Aspose.Slides. Mostra i principali tipi correlati ai commenti e dimostra come aggiungere commenti alle diapositive, accedere ai commenti esistenti, lavorare con le risposte, utilizzare i commenti moderni e rimuovere i commenti da una presentazione.

Gli esempi si concentrano su scenari comuni di revisione e collaborazione in PowerPoint, come assegnare i commenti agli autori, leggere il contenuto e i metadati dei commenti, costruire catene di risposte e cancellare tutti i commenti o eliminarne di selezionati.

In PowerPoint, un commento appare come una nota o un'annotazione su una diapositiva. Quando si fa clic su un commento, il suo contenuto o i suoi messaggi vengono visualizzati.

## **Perché aggiungere commenti alle presentazioni?**

Potresti voler utilizzare i commenti per fornire feedback o comunicare con i colleghi durante la revisione delle presentazioni.

Per consentirti di utilizzare i commenti nelle presentazioni PowerPoint, Aspose.Slides for PHP via Java fornisce

* La classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) che contiene le collezioni di autori (dalla classe [CommentAuthorCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/commentauthorcollection/)). Gli autori aggiungono commenti alle diapositive.
* La classe [CommentCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/commentcollection/) che contiene la raccolta di commenti per singoli autori.
* La classe [Comment](https://reference.aspose.com/slides/it/php-java/aspose.slides/comment/) che contiene informazioni su autori e i loro commenti: chi ha aggiunto il commento, l'ora in cui è stato aggiunto, la posizione del commento, ecc.
* La classe [CommentAuthor](https://reference.aspose.com/slides/it/php-java/aspose.slides/commentauthor/) che contiene informazioni su singoli autori: il nome dell'autore, le sue iniziali, i commenti associati al nome dell'autore, ecc.

## **Aggiungere commenti alle diapositive**
Questo codice PHP mostra come aggiungere un commento a una diapositiva in una presentazione PowerPoint:

```php
  # Istanzia la classe Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Aggiunge una diapositiva vuota
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Aggiunge un autore
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Imposta la posizione per i commenti
    $point = new Point2DFloat(0.2, 0.2);
    # Aggiunge un commento alla diapositiva per un autore sulla diapositiva 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Aggiunge un commento alla diapositiva per un autore sulla diapositiva 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Accede a ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # Quando null viene passato come argomento, i commenti di tutti gli autori vengono riportati alla diapositiva selezionata
    $Comments = $slide->getSlideComments($author);
    # Accede al commento all'indice 0 per la diapositiva 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Seleziona la collezione di commenti dell'Autore all'indice 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Accedere ai commenti delle diapositive**
Questo codice PHP mostra come accedere a un commento esistente su una diapositiva in una presentazione PowerPoint:

```php
  # Istanzia la classe Presentation
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

## **Rispondere ai commenti**
Un commento principale è il commento originale o più alto in una gerarchia di commenti o risposte. Utilizzando i metodi [getParentComment](https://reference.aspose.com/slides/it/php-java/aspose.slides/comment/getparentcomment/) o [setParentComment](https://reference.aspose.com/slides/it/php-java/aspose.slides/comment/setparentcomment/) (dalla classe [Comment](https://reference.aspose.com/slides/it/php-java/aspose.slides/comment/)), è possibile impostare o ottenere un commento principale.

Questo codice PHP mostra come aggiungere commenti e recuperare le risposte:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Aggiunge un commento
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Aggiunge una risposta al comment1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Aggiunge un'altra risposta al comment1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Aggiunge una risposta a una risposta esistente
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Visualizza la gerarchia dei commenti sulla console
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
    # Rimuove comment1 e tutte le risposte ad esso
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Attention" %}} 
* Quando si utilizza il metodo [remove](https://reference.aspose.com/slides/it/php-java/aspose.slides/comment/remove/) (dalla classe [Comment](https://reference.aspose.com/slides/it/php-java/aspose.slides/comment/)) per eliminare un commento, anche le risposte al commento vengono eliminate.
* Se l'impostazione [setParentComment](https://reference.aspose.com/slides/it/php-java/aspose.slides/comment/setparentcomment/) genera un riferimento circolare, verrà sollevata l'eccezione [PptxEditException](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Aggiungere commenti moderni**

Nel 2021, Microsoft ha introdotto i *commenti moderni* in PowerPoint. La funzionalità dei commenti moderni migliora notevolmente la collaborazione in PowerPoint. Attraverso i commenti moderni, gli utenti di PowerPoint possono risolvere i commenti, ancorare i commenti a oggetti e testi e interagire in modo molto più semplice rispetto al passato.

Aspose Slides supporta i commenti moderni tramite la classe [ModernComment](https://reference.aspose.com/slides/it/php-java/aspose.slides/moderncomment/). I metodi [addModernComment](https://reference.aspose.com/slides/it/php-java/aspose.slides/commentcollection/addmoderncomment/) e [insertModernComment](https://reference.aspose.com/slides/it/php-java/aspose.slides/commentcollection/insertmoderncomment/) sono stati aggiunti alla classe [CommentCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/commentcollection/).

Questo codice PHP mostra come aggiungere un commento moderno a una diapositiva in una presentazione PowerPoint:

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

## **Rimuovere i commenti**

### **Eliminare tutti i commenti e gli autori**

Questo codice PHP mostra come rimuovere tutti i commenti e gli autori in una presentazione:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Elimina tutti i commenti dalla presentazione
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Elimina tutti gli autori
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Eliminare commenti specifici**

Questo codice PHP mostra come eliminare commenti specifici su una diapositiva:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # aggiunge commenti...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # rimuove tutti i commenti che contengono il testo "comment 1"
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

**Aspose.Slides supporta uno stato come “risolto” per i commenti moderni?**

Sì. I [commenti moderni](https://reference.aspose.com/slides/it/php-java/aspose.slides/moderncomment/) espongono un metodo [setStatus](https://reference.aspose.com/slides/it/php-java/aspose.slides/moderncomment/setstatus/); è possibile impostare lo [stato del commento](https://reference.aspose.com/slides/it/php-java/aspose.slides/moderncommentstatus/) (ad esempio, marcarlo come risolto) e questo stato viene salvato nel file e riconosciuto da PowerPoint.

**Le discussioni a thread (catene di risposte) sono supportate e c’è un limite di nidificazione?**

Sì. Ogni commento può fare riferimento al suo [commento genitore](https://reference.aspose.com/slides/it/php-java/aspose.slides/comment/getparentcomment/), consentendo catene di risposte arbitrarie. L'API non dichiara un limite specifico di profondità di nidificazione.

**In quale sistema di coordinate è definita la posizione del marcatore di un commento su una diapositiva?**

La posizione è memorizzata come punto a virgola mobile nel sistema di coordinate della diapositiva. Questo consente di posizionare il marcatore del commento esattamente dove è necessario.