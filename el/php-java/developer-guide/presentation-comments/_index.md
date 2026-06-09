---
title: Διαχείριση Σχολίων Παρουσίασης σε PHP
linktitle: Σχόλια Παρουσίασης
type: docs
weight: 100
url: /el/php-java/presentation-comments/
keywords:
- σχόλιο
- σύγχρονο σχόλιο
- σχόλια PowerPoint
- σχόλια παρουσίασης
- σχόλια διαφάνειας
- προσθήκη σχολίου
- πρόσβαση σχολίου
- επεξεργασία σχολίου
- απάντηση σε σχόλιο
- αφαίρεση σχολίου
- διαγραφή σχολίου
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τα σχόλια παρουσίασης με το Aspose.Slides για PHP μέσω Java: προσθέστε, διαβάστε, επεξεργαστείτε και διαγράψτε σχόλια σε αρχεία PowerPoint γρήγορα και εύκολα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειριστείτε τα σχόλια παρουσίασης στο Aspose.Slides. Δείχνει τους κύριους τύπους σχετικού με τα σχόλια και παρουσιάζει πώς να προσθέσετε σχόλια σε διαφάνειες, να έχετε πρόσβαση σε υπάρχοντα σχόλια, να εργαστείτε με απαντήσεις, να χρησιμοποιήσετε σύγχρονα σχόλια και να αφαιρέσετε σχόλια από μια παρουσίαση.

Τα παραδείγματα εστιάζουν σε κοινά σενάρια ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση περιεχομένου σχολίων και μεταδεδομένων, η δημιουργία αλυσίδων απαντήσεων και η εκκαθάριση όλων των σχολίων ή η διαγραφή επιλεγμένων.

Στο PowerPoint, ένα σχόλιο εμφανίζεται ως σημείωμα ή ανάρτηση σε μια διαφάνεια. Όταν το σχόλιο γίνεται κλικ, αποκαλύπτεται το περιεχόμενό του ή τα μηνύματά του. 

## **Γιατί να Προσθέσετε Σχόλια στις Παρουσιάσεις;**

Μπορεί να θέλετε να χρησιμοποιήσετε σχόλια για να δώσετε ανάδραση ή να επικοινωνήσετε με τους συναδέλφους σας όταν ελέγχετε παρουσιάσεις.

Για να σας επιτρέψει η χρήση σχολίων σε παρουσιάσεις PowerPoint, το Aspose.Slides for PHP via Java παρέχει

* Την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) που περιέχει τις συλλογές συγγραφέων (από την κλάση [CommentAuthorCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/commentauthorcollection/)). Οι συγγραφείς προσθέτουν σχόλια στις διαφάνειες.
* Την κλάση [CommentCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/commentcollection/) που περιέχει τη συλλογή σχολίων για μεμονωμένους συγγραφείς.
* Την κλάση [Comment](https://reference.aspose.com/slides/el/php-java/aspose.slides/comment/) που περιέχει πληροφορίες για συγγραφείς και τα σχόλιά τους: ποιος πρόσθεσε το σχόλιο, η ώρα προσθήκης, η θέση του σχολίου κ.λπ.
* Την κλάση [CommentAuthor](https://reference.aspose.com/slides/el/php-java/aspose.slides/commentauthor/) που περιέχει πληροφορίες για μεμονωμένους συγγραφείς: το όνομα του συγγραφέα, τα αρχικά του, τα σχόλια που σχετίζονται με το όνομα του κ.λπ.

## **Προσθήκη Σχολίων Διαφάνειας**
Αυτός ο κώδικας PHP σας δείχνει πώς να προσθέσετε ένα σχόλιο σε μια διαφάνεια σε παρουσίαση PowerPoint:

```php
  # Δημιουργεί ένα αντικείμενο της κλάσης Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Προσθέτει μια κενή διαφάνεια
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Προσθέτει έναν συγγραφέα
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Ορίζει τη θέση για τα σχόλια
    $point = new Point2DFloat(0.2, 0.2);
    # Προσθέτει σχόλιο διαφάνειας για έναν συγγραφέα στη διαφάνεια 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Προσθέτει σχόλιο διαφάνειας για έναν συγγραφέα στη διαφάνεια 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Πρόσβαση στην ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # Όταν το null περάσει ως όρισμα, τα σχόλια από όλους τους συγγραφείς φέρνονται στη συγκεκριμένη διαφάνεια
    $Comments = $slide->getSlideComments($author);
    # Πρόσβαση στο σχόλιο στη θέση 0 για τη διαφάνεια 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Επιλέγει τη συλλογή σχολίων του συγγραφέα στη θέση 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Πρόσβαση σε Σχόλια Διαφάνειας**
Αυτός ο κώδικας PHP σας δείχνει πώς να έχετε πρόσβαση σε ένα υπάρχον σχόλιο σε μια διαφάνεια σε παρουσίαση PowerPoint:

```php
  # Δημιουργεί την κλάση Presentation
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

## **Απάντηση στα Σχόλια**
Ένα γονικό σχόλιο είναι το ανώτερο ή αρχικό σχόλιο σε μια ιεραρχία σχολίων ή απαντήσεων. Χρησιμοποιώντας τις μεθόδους [getParentComment](https://reference.aspose.com/slides/el/php-java/aspose.slides/comment/getparentcomment/) ή [setParentComment](https://reference.aspose.com/slides/el/php-java/aspose.slides/comment/setparentcomment/) (από την κλάση [Comment](https://reference.aspose.com/slides/el/php-java/aspose.slides/comment/)), μπορείτε να ορίσετε ή να λάβετε ένα γονικό σχόλιο.

Αυτός ο κώδικας PHP σας δείχνει πώς να προσθέσετε σχόλια και να λάβετε τις απαντήσεις τους:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Προσθέτει ένα σχόλιο
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Προσθέτει μια απάντηση στο comment1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Προσθέτει μια άλλη απάντηση στο comment1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Προσθέτει μια απάντηση σε υπάρχουσα απάντηση
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Προβάλει την ιεραρχία των σχολίων στην κονσόλα
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
    # Αφαιρεί το comment1 και όλες τις απαντήσεις του
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Attention" %}} 

* Όταν η μέθοδος [remove](https://reference.aspose.com/slides/el/php-java/aspose.slides/comment/remove/) (από την κλάση [Comment](https://reference.aspose.com/slides/el/php-java/aspose.slides/comment/)) χρησιμοποιείται για διαγραφή ενός σχολίου, διαγράφονται επίσης και οι απαντήσεις στο σχόλιο.
* Αν η ρύθμιση [setParentComment](https://reference.aspose.com/slides/el/php-java/aspose.slides/comment/setparentcomment/) προκαλέσει κυκλική αναφορά, θα εξαχθεί η [PptxEditException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxeditexception/).

{{% /alert %}}

## **Προσθήκη Σύγχρονων Σχολίων**

Το 2021, η Microsoft εισήγαγε *σύγχρονα σχόλια* στο PowerPoint. Η δυνατότητα σύγχρονων σχολίων βελτιώνει σημαντικά τη συνεργασία στο PowerPoint. Μέσω των σύγχρονων σχολίων, οι χρήστες του PowerPoint μπορούν να επιλύουν σχόλια, να συνδέουν σχόλια με αντικείμενα και κείμενα και να συμμετέχουν σε αλληλεπιδράσεις πολύ πιο εύκολα από πριν. 

Το Aspose Slides υποστηρίζει σύγχρονα σχόλια με την κλάση [ModernComment](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/). Οι μέθοδοι [addModernComment](https://reference.aspose.com/slides/el/php-java/aspose.slides/commentcollection/addmoderncomment/) και [insertModernComment](https://reference.aspose.com/slides/el/php-java/aspose.slides/commentcollection/insertmoderncomment/) προστέθηκαν στην κλάση [CommentCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/commentcollection/).

Αυτός ο κώδικας PHP σας δείχνει πώς να προσθέσετε ένα σύγχρονο σχόλιο σε μια διαφάνεια σε παρουσίαση PowerPoint:

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

## **Κατάργηση Σχολίων**

### **Διαγραφή Όλων των Σχολίων και Συγγραφέων**

Αυτός ο κώδικας PHP σας δείχνει πώς να αφαιρέσετε όλα τα σχόλια και τους συγγραφείς σε μια παρουσίαση:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Διαγράφει όλα τα σχόλια από την παρουσίαση
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Διαγράφει όλους τους συγγραφείς
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Διαγραφή Συγκεκριμένων Σχολίων**

Αυτός ο κώδικας PHP σας δείχνει πώς να διαγράψετε συγκεκριμένα σχόλια σε μια διαφάνεια:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # προσθέτει σχόλια...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # αφαιρεί όλα τα σχόλια που περιέχουν το κείμενο "comment 1"
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

**Η Aspose.Slides υποστηρίζει κατάσταση όπως «επιλυμένο» για τα σύγχρονα σχόλια;**

Ναι. Τα [σύγχρονα σχόλια](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/) παρέχουν τη μέθοδο [setStatus](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/setstatus/); μπορείτε να ορίσετε την [κατάσταση του σχολίου](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncommentstatus/) (π.χ. να το σημειώσετε ως επιλυμένο) και αυτή η κατάσταση αποθηκεύεται στο αρχείο και αναγνωρίζεται από το PowerPoint.

**Υποστηρίζονται οι διαδραστικές συζητήσεις (αλυσίδες απαντήσεων) και υπάρχει όριο εμφωλευμού;**

Ναι. Κάθε σχόλιο μπορεί να αναφερθεί στο [γονικό του σχόλιο](https://reference.aspose.com/slides/el/php-java/aspose.slides/comment/getparentcomment/), επιτρέποντας αυθαίρετες αλυσίδες απαντήσεων. Η API δεν δηλώνει κάποιο συγκεκριμένο όριο βάθους εμφωλευμού.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση αποθηκεύεται ως σημείο κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας. Αυτό σας επιτρέπει να τοποθετήσετε ακριβώς τον δείκτη σχολίου εκεί που το χρειάζεστε.