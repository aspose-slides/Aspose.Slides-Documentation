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
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τα σχόλια παρουσίασης με το Aspose.Slides για PHP μέσω Java: προσθέστε, διαβάστε, επεξεργαστείτε, απαντήστε και αφαιρέστε σχόλια σε παρουσιάσεις PowerPoint γρήγορα και εύκολα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειριστείτε τα σχόλια παρουσίασης με το Aspose.Slides for PHP via Java. Παρουσιάζει τους κύριους τύπους που σχετίζονται με σχόλια και δείχνει πώς να προσθέτετε σχόλια σε διαφάνειες, να αποκτάτε πρόσβαση σε υπάρχοντα σχόλια, να εργάζεστε με απαντήσεις και σύγχρονα σχόλια, και να αφαιρείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα καλύπτουν κοινές περιπτώσεις ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση κειμένου και μεταδεδομένων σχολίων, η δημιουργία αλυσίδων απαντήσεων και η αφαίρεση επιλεγμένων ή όλων των σχολίων.

Στο PowerPoint, τα σχόλια εμφανίζονται ως σημειώσεις στις διαφάνειες. Η επιλογή ενός σχολίου εμφανίζει το κείμενό του και τη σχετική συζήτηση.

Για να ζητήσετε τα σχόλια να εμφανίζονται ή να κρύβονται όταν ανοίγει μια παρουσίαση χωρίς να αλλάξετε τα ίδια τα σχόλια, δείτε [Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα μιας Παρουσίασης](/slides/el/php-java/presentation-view-properties/).

## **Γιατί να Προσθέτετε Σχόλια σε Παρουσιάσεις;**

Μπορείτε να χρησιμοποιήσετε τα σχόλια για να παρέχετε ανατροφοδότηση και να συνεργάζεστε με συναδέλφους κατά την ανασκόπηση παρουσιάσεων.

Aspose.Slides for PHP via Java παρέχει τα ακόλουθα API για εργασία με σχόλια:

* Η κλάση [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) παρέχει πρόσβαση στους συντάκτες σχολίων της παρουσίασης.
* Η κλάση [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) αντιπροσωπεύει τα σχόλια που σχετίζονται με έναν συγκεκριμένο συγγραφέα.
* Η κλάση [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) παρέχει πληροφορίες για ένα σχόλιο, συμπεριλαμβανομένου του συγγραφέα, του χρόνου δημιουργίας, της θέσης και του κειμένου.
* Η κλάση [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) παρέχει πληροφορίες για έναν συγγραφέα, όπως το όνομα, τα αρχικά και τα σχετικά σχόλια.

## **Προσθήκη Σχολίων σε Διαφάνειες**

Το παράδειγμα δημιουργεί δύο διαφάνειες και εγγράφει έναν συγγραφέα σχολίων με τη μέθοδο [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/). Χρησιμοποιεί τη μέθοδο [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) για να τοποθετήσει ένα σχόλιο σε κάθε διαφάνεια, στη συνέχεια ανακτά τα σχόλια της πρώτης διαφάνειας για εκείνον τον συγγραφέα με τη μέθοδο [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/). Η κονσόλα εμφανίζει το κείμενο του πρώτου σχολίου δύο φορές, δείχνοντας την πρόσβαση τόσο μέσω της διαφάνειας όσο και μέσω του συγγραφέα, και η αποθηκευμένη παρουσίαση περιέχει και τα δύο σχόλια.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($presentation->getLayoutSlides()->get_Item(0));

    $author = $presentation->getCommentAuthors()->addAuthor("Jawad", "MF");
    $position = new Point2DFloat(0.2, 0.2);
    $createdTime = new Java("java.util.Date");

    $author->getComments()->addComment("Hello Jawad, this is a slide comment", $firstSlide, $position, $createdTime);
    $author->getComments()->addComment("Hello Jawad, this is the second slide comment", $secondSlide, $position, $createdTime);

    $comments = $firstSlide->getSlideComments($author);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    if ($commentCount > 0) {
        $firstComment = $comments[0];
        echo java_values($firstComment->getText()) . PHP_EOL;

        $authorComments = $firstComment->getAuthor()->getComments();
        $commentText = $authorComments->get_Item(0)->getText();
        echo java_values($commentText) . PHP_EOL;
    }

    $presentation->save("Comments_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Εύρεση ή Δημιουργία Συγγραφέα Σχολίου**

Όταν μια αυτοματοποιημένη ανασκόπηση επεξεργάζεται τις ίδιες παρουσιάσεις επανειλημμένα, αναζητήστε στη συλλογή που επιστρέφει η μέθοδος [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) πριν προσθέσετε έναν συγγραφέα. Η μέθοδος [findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) ταιριάζει τόσο με το όνομα όσο και με τα αρχικά και επιστρέφει έναν πίνακα με τους αντίστοιχους συγγραφείς, ή έναν κενό πίνακα εάν δεν βρεθούν αντιστοιχίες. Αντίθετα, η μέθοδος [findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) ψάχνει μόνο κατά όνομα, ανεξάρτητα από τα αρχικά. Η κλήση της [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) με όνομα και αρχικά που ήδη υπάρχουν στη συλλογή προκαλεί εξαίρεση.

Το παράδειγμα απαιτεί ένα αρχείο παρουσίασης με τουλάχιστον μία διαφάνεια. Σε κάθε μία από τις δύο εκτελέσεις, επαναχρησιμοποιεί τον πρώτο ταιριανό συγγραφέα ή δημιουργεί έναν νέο μόνο όταν το αποτέλεσμα είναι κενό. Εάν υπάρχουν πολλές αντιστοιχίες, επιλέγει το πρώτο στοιχείο του πίνακα χωρίς συγχώνευση ή αφαίρεση των άλλων συγγραφέων. Στη συνέχεια καλεί τη μέθοδο [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) για τον επιλεγμένο συγγραφέα και αποθηκεύει την παρουσίαση. Η δεύτερη εκτέλεση ανοίγει το αποτέλεσμα της πρώτης και επαναλαμβάνει τη διαδικασία.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$authorName = "Reviewer";
$authorInitials = "RV";

$inputFile = "input.pptx";
$position = new Point2DFloat(20, 20);
$arrayClass = new JavaClass("java.lang.reflect.Array");

for ($pass = 1; $pass <= 2; $pass++) {
    $presentation = new Presentation($inputFile);
    try {
        $matches = $presentation->getCommentAuthors()->findByNameAndInitials($authorName, $authorInitials);
        $matchCount = java_values($arrayClass->getLength($matches));

        $author = $matchCount > 0 ? $matches[0] : $presentation->getCommentAuthors()->addAuthor($authorName, $authorInitials);
        $createdTime = new Java("java.util.Date");
        $author->getComments()->addComment("Please review this slide.", $presentation->getSlides()->get_Item(0), $position, $createdTime);

        $outputFile = "review_pass_" . $pass . ".pptx";
        $presentation->save($outputFile, SaveFormat::Pptx);
        $inputFile = $outputFile;
    } finally {
        $presentation->dispose();
    }
}
```

Η δεύτερη εκτέλεση προσθέτει ένα ακόμη σχόλιο χωρίς να προσθέσει νέο συγγραφέα ή να αφαιρέσει υπάρχοντα σχόλια. Το τελικό αρχείο, `review_pass_2.pptx`, περιέχει και τα δύο νέα σχόλια μαζί με τυχόν αρχικά σχόλια. Η επαναχρησιμοποίηση ενός συγγραφέα δεν αφαιρεί διπλότυπα σχόλια: για να αποφύγετε την επανειλημμένη προσθήκη του ίδιου σχολίου, υλοποιήστε χωριστό μηχανισμό ανίχνευσης διπλοτύπων πριν το προσθέσετε.

## **Πρόσβαση σε Σχόλια Διαφάνειας**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και διαβάζει τη συλλογή που επιστρέφει η μέθοδος [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/). Για κάθε συγγραφέα, επαναλαμβάνει τη συλλογή που επιστρέφει η μέθοδος [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) και εκτυπώνει τον αριθμό της διαφάνειας, το κείμενο του σχολίου, το όνομα του συγγραφέα και την ώρα δημιουργίας. Η εισερχόμενη παρουσίαση πρέπει να περιέχει σχόλια για να παραχθεί έξοδος στην κονσόλα.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Comments1.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        foreach ($author->getComments() as $comment) {
            echo "Slide: " . java_values($comment->getSlide()->getSlideNumber()) . PHP_EOL;
            echo "Comment: " . java_values($comment->getText()) . PHP_EOL;
            echo "Author: " . java_values($comment->getAuthor()->getName()) . PHP_EOL;
            echo "Posted at: " . java_values($comment->getCreatedTime()->toString()) . PHP_EOL;
            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Απαντήσεις σε Σχόλια**

Ένα γονικό σχόλιο είναι το αρχικό σχόλιο στην κορυφή μιας ιεραρχίας απαντήσεων. Οι μέθοδοι [Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) και [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) επιτρέπουν τη λήψη ή ορισμό του γονικού σχολίου.

Το παράδειγμα δημιουργεί σχόλια από δύο συγγραφείς και χρησιμοποιεί τη μέθοδο [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) για να δημιουργήσει απαντήσεις, συμπεριλαμβανομένης μιας απάντησης σε άλλη απάντηση. Π Passing `null` στη μέθοδο [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) ανακτά σχόλια από όλους τους συγγραφείς· η κονσόλα εσοχίζει κάθε καταχώρηση ανάλογα με το βάθος της στην ιεραρχία απαντήσεων. Το παράδειγμα αποθηκεύει τη πλήρη συζήτηση, καλεί τη μέθοδο [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) στο πρώτο ριζικό σχόλιο και αποθηκεύει μια δεύτερη παρουσίαση με αυτό το σχόλιο και τις απαντήσεις του αφαιρεμένα.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $position = new Point2DFloat(10, 10);
    $createdTime = new Java("java.util.Date");

    $author1 = $presentation->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment 1", $slide, $position, $createdTime);

    $author2 = $presentation->getCommentAuthors()->addAuthor("Author_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $slide, $position, $createdTime);
    $reply1->setParentComment($comment1);

    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $slide, $position, $createdTime);
    $reply2->setParentComment($comment1);

    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $slide, $position, $createdTime);
    $subReply->setParentComment($reply2);

    $author2->getComments()->addComment("comment 2", $slide, $position, $createdTime);
    $comment3 = $author2->getComments()->addComment("comment 3", $slide, $position, $createdTime);

    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $slide, $position, $createdTime);
    $reply3->setParentComment($comment3);

    $comments = $slide->getSlideComments(null);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    for ($i = 0; $i < $commentCount; $i++) {
        $comment = $comments[$i];
        while (!java_is_null($comment->getParentComment())) {
            echo "\t";
            $comment = $comment->getParentComment();
        }

        echo java_values($comments[$i]->getAuthor()->getName()) . ": " . java_values($comments[$i]->getText()) . PHP_EOL;
    }

    $presentation->save("parent_comment.pptx", SaveFormat::Pptx);

    $comment1->remove();
    $presentation->save("remove_comment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Όταν η μέθοδος [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) χρησιμοποιείται για τη διαγραφή ενός σχολίου, όλες οι απαντήσεις σε αυτό το σχόλιο διαγράφονται επίσης.
* Εάν η μέθοδος [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) δημιουργεί μια κυκλική αναφορά, εγείρεται ένα [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Προσθήκη Σύγχρονων Σχολίων**

Τα σύγχρονα σχόλια μπορούν να συνδεθούν με την ίδια τη διαφάνεια, με ένα συγκεκριμένο σχήμα ή με μια περιοχή κειμένου μέσα σε AutoShape. Η μέθοδος [CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) δέχεται ένα όρισμα τύπου [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) εκτός από τη διαφάνεια και τις συντεταγμένες του δείκτη σχολίου.

Όταν περνιέται `null` για το όρισμα του σχήματος, το σχόλιο είναι σχολείο σε επίπεδο διαφάνειας. Ο δείκτης τοποθετείται από τις παρεχόμενες συντεταγμένες, αλλά δεν συνδέεται με συγκεκριμένο σχήμα, οπότε η μέθοδος [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) επιστρέφει `null`. Όταν παρέχεται ένα [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), το σχόλιο αγκιστρώνεται σε αυτό το σχήμα. Οι συντεταγμένες εξακολουθούν να ορίζουν τη θέση του δείκτη του σχολίου στη διαφάνεια, ενώ η σύνδεση με το σχήμα μπορεί να ανακτηθεί μέσω της μεθόδου [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/).

### **Αγκίστρωση Σύγχρονου Σχολίου σε Σχήμα**

Το παράδειγμα καλεί τη μέθοδο [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) δύο φορές: μία με σχήμα `null` για σχόλιο σε επίπεδο διαφάνειας και μία με ένα ορθογώνιο ως αγκίστρωση. Η ανάγνωση της μεθόδου [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) εκτυπώνει `true` για τον έλεγχο `null` του σχολίου σε επίπεδο διαφάνειας και `Revenue title` για το αγκυρισμένο σχόλιο. Και τα δύο σχόλια αποθηκεύονται με την παρουσίαση.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 300, 80);
    $shape->setName("Revenue title");
    $shape->getTextFrame()->setText("Quarterly revenue");

    $createdTime = new Java("java.util.Date");
    $slideCommentPosition = new Point2DFloat(20, 20);
    $shapeCommentPosition = new Point2DFloat(60, 60);
    $slideComment = $author->getComments()->addModernComment("Review the overall slide layout.", $slide, null, $slideCommentPosition, $createdTime);
    $shapeComment = $author->getComments()->addModernComment("Check this title.", $slide, $shape, $shapeCommentPosition, $createdTime);

    echo (java_is_null($slideComment->getShape()) ? "true" : "false") . PHP_EOL;
    echo java_values($shapeComment->getShape()->getName()) . PHP_EOL;

    $presentation->save("modern_comments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Αγκίστρωση Σχολίων σε Διαφορετικούς Τύπους Σχημάτων**

Οποιοδήποτε αντικείμενο διαφάνειας που αντιπροσωπεύεται από την κλάση [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) μπορεί να χρησιμοποιηθεί ως αγκίστρωση σχήματος. Συνήθεις παράδειγμα περιλαμβάνουν [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) και [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/) όπως γραφήματα.

Το παράδειγμα χρησιμοποιεί τη μέθοδο [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) για να συνδέσει ένα σχόλιο με καθέναν από πέντε τύπους σχημάτων: AutoShape, picture frame, group, connector και chart. Η εικόνα χρησιμοποιεί ενσωματωμένα δεδομένα εικόνας, οπότε δεν απαιτείται εξωτερική εικόνα. Κάθε σχόλιο έχει τη δική του θέση δείκτη, και η αποθηκευμένη παρουσίαση διατηρεί όλες τις πέντε συνδέσεις σχήματος.

```php
use aspose\slides\ChartType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $createdTime = new Java("java.util.Date");

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 180, 60);
    $autoShape->getTextFrame()->setText("AutoShape");

    $autoShapeCommentPosition = new Point2DFloat(30, 30);
    $author->getComments()->addModernComment("Comment on an AutoShape.", $slide, $autoShape, $autoShapeCommentPosition, $createdTime);

    $imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    $base64Class = new JavaClass("java.util.Base64");
    $imageData = $base64Class->getDecoder()->decode($imageBase64);
    $image = $presentation->getImages()->addImage($imageData);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 120, 80, $image);
    $pictureCommentPosition = new Point2DFloat(230, 30);
    $author->getComments()->addModernComment("Comment on a picture.", $slide, $pictureFrame, $pictureCommentPosition, $createdTime);

    $groupShape = $slide->getShapes()->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 80, 40);
    $groupShape->getShapes()->addAutoShape(ShapeType::Ellipse, 100, 0, 80, 40);
    $groupCommentPosition = new Point2DFloat(40, 150);
    $author->getComments()->addModernComment("Comment on a group.", $slide, $groupShape, $groupCommentPosition, $createdTime);

    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 220, 150, 140, 40);
    $connectorCommentPosition = new Point2DFloat(240, 150);
    $author->getComments()->addModernComment("Comment on a connector.", $slide, $connector, $connectorCommentPosition, $createdTime);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 400, 20, 250, 180);
    $chartCommentPosition = new Point2DFloat(420, 40);
    $author->getComments()->addModernComment("Comment on a graphical object.", $slide, $chart, $chartCommentPosition, $createdTime);

    $presentation->save("modern_comment_shape_types.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Αγκίστρωση Σχολίου σε Κείμενο και Ορισμός Κατάστασης**

Για ένα σύγχρονο σχόλιο που σχετίζεται με ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), οι μέθοδοι [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) και [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) προσπερνούν τη θέση έναρξης του επιλεγμένου κειμένου στο πλαίσιο κειμένου του σχήματος. Οι μέθοδοι [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) και [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) προσπερνούν το μήκος της επιλογής. Μαζί, αυτές οι τιμές συνδέουν το σχόλιο με μια συγκεκριμένη περιοχή κειμένου μέσα στο AutoShape.

Οι μέθοδοι [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) και [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) προσπερνούν μια τιμή από τις σταθερές του [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — δεν ορίζεται συγκεκριμένη κατάσταση σύγχρονου σχολίου.
- `Active` — το σχόλιο είναι ενεργό.
- `Resolved` — το σχόλιο έχει επιλυθεί.
- `Closed` — το σχόλιο είναι κλειστό.

Το παράδειγμα αγκυρώνει ένα σύγχρονο σχόλιο στις λέξεις «quarterly revenue» στο κείμενο ενός ορθογωνίου. Υπολογίζει τη μηδενική βάση του σημείου εκκίνησης της επιλογής από το κείμενο και το περνά στη μέθοδο [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/), χρησιμοποιώντας τη μέθοδο [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) για να ορίσει τον αριθμό των επιλεγμένων χαρακτήρων. Μετά την κλήση της [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) με `Resolved`, αποθηκεύει και ανοίγει ξανά την παρουσίαση. Οι τέσσερις έλεγχοι στην κονσόλα πρέπει να εκτυπώσουν `true`, επιβεβαιώνοντας ότι η αγκίστρωση σχήματος, η περιοχή κειμένου και η κατάσταση διατηρήθηκαν.

```php
use aspose\slides\ModernCommentStatus;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$outputFile = "modern_comment_text_anchor.pptx";
$shapeText = "Review the quarterly revenue forecast.";
$selectedText = "quarterly revenue";
$expectedSelectionStart = strpos($shapeText, $selectedText);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->setName("Forecast text");
    $shape->getTextFrame()->setText($shapeText);

    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $commentPosition = new Point2DFloat(60, 60);
    $comment = $author->getComments()->addModernComment("Verify this forecast wording.", $slide, $shape, $commentPosition, new Java("java.util.Date"));
    $comment->setTextSelectionStart($expectedSelectionStart);
    $comment->setTextSelectionLength(strlen($selectedText));
    $comment->setStatus(ModernCommentStatus::Resolved);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedComments = $reopenedSlide->getSlideComments(null);
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");

    foreach ($reopenedComments as $reopenedComment) {
        if (!java_instanceof($reopenedComment, $modernCommentClass)) {
            continue;
        }

        $shape = $reopenedComment->getShape();
        $shapeMatches = !java_is_null($shape) && java_values($shape->getName()) === "Forecast text";
        $selectionStartMatches = java_values($reopenedComment->getTextSelectionStart()) === $expectedSelectionStart;
        $selectionLengthMatches = java_values($reopenedComment->getTextSelectionLength()) === strlen($selectedText);
        $statusMatches = java_values($reopenedComment->getStatus()) === ModernCommentStatus::Resolved;

        echo "Shape anchor preserved: " . ($shapeMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection start preserved: " . ($selectionStartMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection length preserved: " . ($selectionLengthMatches ? "true" : "false") . PHP_EOL;
        echo "Resolved status preserved: " . ($statusMatches ? "true" : "false") . PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

### **Έλεγχος Υπάρχοντων Σύγχρονων Σχολίων**

Το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση που περιέχει σύγχρονα σχόλια και εκτυπώνει το κείμενό τους, την κατάσταση και τις λεπτομέρειες αγκίστρωσης. Για να το εξετάσετε, ελέγξτε εάν κάθε σχόλιο είναι ένα [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/), στη συνέχεια εξετάστε τις μεθόδους [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) και [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/). Ένα σχήμα `null` υποδεικνύει σχόλιο σε επίπεδο διαφάνειας. Για μια αγκίστρωση [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), οι μέθοδοι επιλογής κειμένου προσδιορίζουν το σχετικό εύρος στο πλαίσιο κειμένου του σχήματος.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("comments.pptx");
try {
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    foreach ($presentation->getSlides() as $slide) {
        $comments = $slide->getSlideComments(null);
        foreach ($comments as $comment) {
            if (!java_instanceof($comment, $modernCommentClass)) {
                continue;
            }

            echo "Slide: " . java_values($slide->getSlideNumber()) . PHP_EOL;
            echo "Text: " . java_values($comment->getText()) . PHP_EOL;
            echo "Status: " . java_values($comment->getStatus()) . PHP_EOL;

            $shape = $comment->getShape();
            if (java_is_null($shape)) {
                echo "Anchor: slide level" . PHP_EOL;
            } else {
                echo "Anchor shape: " . java_values($shape->getName()) . PHP_EOL;
                echo "Anchor type: " . java_values($shape->getClass()->getSimpleName()) . PHP_EOL;

                if (java_instanceof($shape, $autoShapeClass)) {
                    echo "Text selection start: " . java_values($comment->getTextSelectionStart()) . PHP_EOL;
                    echo "Text selection length: " . java_values($comment->getTextSelectionLength()) . PHP_EOL;
                }
            }

            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Αφαίρεση Σχολίων**

Aspose.Slides for PHP via Java επιτρέπει την αφαίρεση όλων των σχολίων και των συγγραφέων τους από μια παρουσίαση ή τη διαγραφή επιλεγμένων σχολίων διατηρώντας τα υπόλοιπα. Τα ακόλουθα παραδείγματα δείχνουν και τις δύο προσεγγίσεις και αποθηκεύουν την ενημερωμένη παρουσίαση.

### **Αφαίρεση Όλων των Σχολίων και Συγγραφέων Σχολίων**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και καλεί τη μέθοδο [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) για κάθε συγγραφέα, στη συνέχεια καλεί τη μέθοδο [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) για την αφαίρεση των συγγραφέων. Η αποθηκευμένη παρουσίαση δεν περιέχει ούτε σχόλια ούτε συγγραφείς σχολίων. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχόλια για να παρατηρήσετε την αφαίρεση.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("example.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        $author->getComments()->clear();
    }

    $presentation->getCommentAuthors()->clear();

    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Αφαίρεση Συγκεκριμένων Σχολίων**

Το παράδειγμα δημιουργεί δύο σχόλια σε μία διαφάνεια και χρησιμοποιεί τη μέθοδο [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) για να βρει τα σχόλια από κάθε συγγραφέα. Συλλέγει τα σχόλια των οποίων το κείμενο ισούται με «comment 1» πριν καλέσει τη μέθοδο [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/), αποφεύγοντας αλλαγές στη συλλογή κατά την επιλογή. Η αποθηκευμένη παρουσίαση διατηρεί μόνο το «comment 2».

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $createdTime = new Java("java.util.Date");

    $firstCommentPosition = new Point2DFloat(0.2, 0.2);
    $secondCommentPosition = new Point2DFloat(0.3, 0.2);
    $author->getComments()->addComment("comment 1", $slide, $firstCommentPosition, $createdTime);
    $author->getComments()->addComment("comment 2", $slide, $secondCommentPosition, $createdTime);

    foreach ($presentation->getCommentAuthors() as $commentAuthor) {
        $commentsToRemove = new Java("java.util.ArrayList");
        $comments = $slide->getSlideComments($commentAuthor);

        foreach ($comments as $comment) {
            if ($comment->getText()->equals("comment 1")) {
                $commentsToRemove->add($comment);
            }
        }

        foreach ($commentsToRemove as $comment) {
            $commentAuthor->getComments()->remove($comment);
        }
    }

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το Aspose.Slides κατάσταση επιλυμένου σχολίου για σύγχρονα σχόλια;**

Ναι. Οι μέθοδοι [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) και [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) προσπερνούν μια τιμή του [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/), συμπεριλαμβανομένου του `Resolved`. Η κατάσταση αποθηκεύεται στην παρουσίαση και μπορεί να διαβαστεί ξανά μετά το άνοιγμα του αρχείου.

**Υποστηρίζονται οι αλυσιδωτές συζητήσεις (αλυσίδες απαντήσεων) και υπάρχει όριο βάθους;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρει το [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/), επιτρέποντας αλυσίδες απαντήσεων. Το API δεν ορίζει συγκεκριμένο όριο βάθους.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση του δείκτη ορίζεται από συντεταγμένες κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας, επιτρέποντας ακριβή τοποθέτηση.