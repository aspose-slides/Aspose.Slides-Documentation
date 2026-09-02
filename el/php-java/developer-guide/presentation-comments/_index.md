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
- πρόσβαση σε σχόλιο
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

Αυτό το άρθρο εξηγεί πώς να διαχειριστείτε τα σχόλια παρουσίασης με το Aspose.Slides for PHP via Java. Παρουσιάζει τους κύριους τύπους που σχετίζονται με τα σχόλια και δείχνει πώς να προσθέσετε σχόλια σε διαφάνειες, να έχετε πρόσβαση σε υπάρχοντα σχόλια, να εργαστείτε με απαντήσεις και σύγχρονα σχόλια, καθώς και πώς να αφαιρέσετε σχόλια από μια παρουσίαση.

Τα παραδείγματα καλύπτουν κοινά σενάρια ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση κειμένου σχολίων και μεταδεδομένων, η δημιουργία αλυσίδων απαντήσεων και η αφαίρεση επιλεγμένων σχολίων ή όλων των σχολίων.

Στο PowerPoint, τα σχόλια εμφανίζονται ως σημειώσεις στις διαφάνειες. Η επιλογή ενός σχολίου εμφανίζει το κείμενό του και τη σχετική συζήτηση.

## **Γιατί να Προσθέσετε Σχόλια σε Παρουσιάσεις;**

Μπορείτε να χρησιμοποιήσετε τα σχόλια για να παρέχετε ανατροφοδότηση και να συνεργάζεστε με συναδέλφους κατά την ανασκόπηση των παρουσιάσεων.

Aspose.Slides for PHP via Java παρέχει τα παρακάτω API για εργασία με σχόλια:

* Η κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) παρέχει πρόσβαση στους συγγραφείς σχολίων της παρουσίασης.
* Η κλάση [CommentCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/commentcollection/) αντιπροσωπεύει τα σχόλια που συνδέονται με έναν συγκεκριμένο συγγραφέα.
* Η κλάση [Comment](https://reference.aspose.com/slides/el/php-java/aspose.slides/comment/) παρέχει πληροφορίες για ένα σχόλιο, συμπεριλαμβανομένου του συγγραφέα, της ώρας δημιουργίας, της θέσης και του κειμένου.
* Η κλάση [CommentAuthor](https://reference.aspose.com/slides/el/php-java/aspose.slides/commentauthor/) παρέχει πληροφορίες για έναν συγγραφέα, όπως το όνομα, τα αρχικά και τα συνδεδεμένα σχόλια.

## **Προσθήκη Σχολίων στη Διαφάνεια**

Το παρακάτω παράδειγμα δείχνει πώς να προσθέσετε σχόλια σε διαφάνειες σε μια παρουσίαση PowerPoint:

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

## **Πρόσβαση σε Σχόλια Διαφάνειας**

Το παρακάτω παράδειγμα δείχνει πώς να αποκτήσετε πρόσβαση σε υπάρχοντα σχόλια σε μια παρουσίαση PowerPoint:

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

## **Απάντηση σε Σχόλια**

Ένα γονικό σχόλιο είναι το αρχικό σχόλιο στην κορυφή μιας ιεραρχίας απαντήσεων. Οι μέθοδοι [Comment::getParentComment](https://reference.aspose.com/slides/el/php-java/aspose.slides/comment/getparentcomment/) και [Comment::setParentComment](https://reference.aspose.com/slides/el/php-java/aspose.slides/comment/setparentcomment/) σάς επιτρέπουν να λάβετε ή να ορίσετε το γονικό ενός σχολίου.

Το παρακάτω παράδειγμα δείχνει πώς να προσθέσετε απαντήσεις και να ελέγξετε την προκύπτουσα ιεραρχία σχολίων:

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

{{% alert color="warning" title="Προειδοποίηση" %}}
* Όταν χρησιμοποιείται η μέθοδος [Comment::remove](https://reference.aspose.com/slides/el/php-java/aspose.slides/comment/remove/) για τη διαγραφή ενός σχολίου, όλες οι απαντήσεις σε αυτό το σχόλιο διαγράφονται επίσης.
* Εάν η μέθοδος [Comment::setParentComment](https://reference.aspose.com/slides/el/php-java/aspose.slides/comment/setparentcomment/) δημιουργήσει κυκλική αναφορά, θα γίνει ρίψη μιας [PptxEditException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Προσθήκη Σύγχρονων Σχολίων**

Τα σύγχρονα σχόλια μπορούν να συσχετιστούν με την ίδια τη διαφάνεια, με ένα συγκεκριμένο σχήμα ή με ένα εύρος κειμένου μέσα σε AutoShape. Η μέθοδος [CommentCollection::addModernComment](https://reference.aspose.com/slides/el/php-java/aspose.slides/commentcollection/addmoderncomment/) δέχεται ένα όρισμα [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) εκτός από τις συντεταγμένες της διαφάνειας και του δείκτη σχολίου.

Όταν το `null` περνιέται ως όρισμα σχήματος, το σχόλιο είναι σχόλιο επιπέδου διαφάνειας. Ο δείκτης του τοποθετείται με βάση τις δοθείσες συντεταγμένες, αλλά δεν συνδέεται με συγκεκριμένο σχήμα, επομένως η [ModernComment::getShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/getshape/) επιστρέφει `null`. Όταν παρέχεται ένα [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/), το σχόλιο αγκυροβολείται σε αυτό το σχήμα. Οι συντεταγμένες εξακολουθούν να ορίζουν τη θέση του δείκτη σχολίου στη διαφάνεια, ενώ η συσχέτιση με το σχήμα μπορεί να ανακτηθεί μέσω της [ModernComment::getShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/getshape/).

### **Σύνδεση Σύγχρονου Σχολίου σε Σχήμα**

Το παρακάτω παράδειγμα δημιουργεί τόσο ένα σχόλιο επιπέδου διαφάνειας όσο και ένα σύγχρονο σχόλιο αγκυροβολημένο σε ένα συγκεκριμένο AutoShape. Στη συνέχεια διαβάζει το συσχετισμένο σχήμα από κάθε σχόλιο.

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

### **Σύνδεση Σχολίων σε Διάφορους Τύπους Σχημάτων**

Οποιοδήποτε αντικείμενο διαφάνειας που αναπαρίσταται από την κλάση [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) μπορεί να χρησιμοποιηθεί ως άγκυρα σχήματος. Συνηθισμένα παραδείγματα περιλαμβάνουν [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/el/php-java/aspose.slides/connector/) και παραδείγματα [GraphicalObject](https://reference.aspose.com/slides/el/php-java/aspose.slides/graphicalobject/) όπως γραφήματα.

Το παρακάτω παράδειγμα δημιουργεί αρκετούς κοινόχρηστους τύπους σχημάτων και συσχετίζει ένα σύγχρονο σχόλιο με τον καθένα.

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

### **Σύνδεση Σχολίου σε Κείμενο και Ορισμός Κατάστασής του**

Για ένα σύγχρονο σχόλιο που συσχετίζεται με ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/), οι μέθοδοι [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/gettextselectionstart/) και [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/settextselectionstart/) προσπελαύνουν τη θέση έναρξης του επιλεγμένου κειμένου στο πλαίσιο κειμένου του σχήματος. Οι μέθοδοι [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/gettextselectionlength/) και [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/settextselectionlength/) προσπελαύνουν το μήκος της επιλογής. Μαζί, αυτές οι τιμές συσχετίζουν το σχόλιο με ένα συγκεκριμένο εύρος κειμένου μέσα στο AutoShape.

Οι μέθοδοι [ModernComment::getStatus](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/getstatus/) και [ModernComment::setStatus](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/setstatus/) προσπελαύνουν μια τιμή από τις σταθερές [ModernCommentStatus](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — δεν έχει οριστεί συγκεκριμένη κατάσταση σύγχρονου σχολίου.
- `Active` — το σχόλιο είναι ενεργό.
- `Resolved` — το σχόλιο έχει επιλυθεί.
- `Closed` — το σχόλιο είναι κλειστό.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα-αγκυροβολημένο σύγχρονο σχόλιο, το συνδέει με μια επιλογή κειμένου, το σημαίνει ως επιλυμένο, αποθηκεύει την παρουσίαση και επαληθεύει τις τιμές μετά το άνοιγμα του αρχείου ξανά.

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

### **Επιθεώρηση Υπάρχοντων Σύγχρονων Σχολίων**

Για την επιθεώρηση μιας υπάρχουσας παρουσίασης, ελέγξτε αν κάθε σχόλιο είναι ένα [ModernComment](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/), στη συνέχεια εξετάστε τις μεθόδους [ModernComment::getShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/gettextselectionlength/) και [ModernComment::getStatus](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/getstatus/). Ένα σχήμα `null` υποδηλώνει σχόλιο επιπέδου διαφάνειας. Για άγκυρα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/), οι μέθοδοι επιλογής κειμένου προσδιορίζουν το σχετικό εύρος στο πλαίσιο κειμένου του σχήματος.

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

### **Αφαίρεση Όλων των Σχολίων και των Συγγραφέων Σχολίων**

Το παρακάτω παράδειγμα δείχνει πώς να αφαιρέσετε όλα τα σχόλια και τους συγγραφείς σχολίων από μια παρουσίαση:

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

Το παρακάτω παράδειγμα δείχνει πώς να αφαιρέσετε συγκεκριμένα σχόλια από μια διαφάνεια:

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

**Υποστηρίζει το Aspose.Slides κατάσταση «επιλυμένο» για σύγχρονα σχόλια;**

Ναι. Οι μέθοδοι [ModernComment::getStatus](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/getstatus/) και [ModernComment::setStatus](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncomment/setstatus/) προσπελαύνουν μια τιμή [ModernCommentStatus](https://reference.aspose.com/slides/el/php-java/aspose.slides/moderncommentstatus/), συμπεριλαμβανομένου του `Resolved`. Η κατάσταση αποθηκεύεται στην παρουσίαση και μπορεί να αναγνωσθεί ξανά μετά το άνοιγμα του αρχείου.

**Υποστηρίζονται οι ιεραρχικές συζητήσεις (αλυσίδες απαντήσεων) και υπάρχει όριο γέννας;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρει το [parent comment](https://reference.aspose.com/slides/el/php-java/aspose.slides/comment/getparentcomment/), επιτρέποντας αλυσίδες απαντήσεων. Το API δεν ορίζει συγκεκριμένο όριο βάθους γέννας.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση του δείκτη ορίζεται από συντεταγμένες κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας, επιτρέποντάς σας να τοποθετήσετε ακριβώς το δείκτη στη διαφάνεια.