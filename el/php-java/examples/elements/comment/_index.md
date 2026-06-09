---
title: Σχόλιο
type: docs
weight: 230
url: /el/php-java/examples/elements/comment/
keywords:
- σχόλιο
- σύγχρονο σχόλιο
- προσθήκη σχολίου
- πρόσβαση σε σχόλιο
- αφαίρεση σχολίου
- απάντηση σε σχόλιο
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τα σχόλια διαφάνειας σε PHP με το Aspose.Slides: προσθέστε, διαβάστε, απαντήστε, επεξεργαστείτε, διαγράψτε και εργαστείτε με νήματα σχολίων για PowerPoint και OpenDocument."
---
Δείχνει την προσθήκη, ανάγνωση, κατάργηση και απάντηση σε σύγχρονα σχόλια χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

## **Προσθήκη σύγχρονου σχολίου**

Δημιουργήστε ένα σχόλιο που γράφτηκε από έναν χρήστη και αποθηκεύστε την παρουσίαση.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Προσθέστε ένα σύγχρονο σχόλιο.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε σύγχρονο σχόλιο**

Διαβάστε ένα σύγχρονο σχόλιο από μια υπάρχουσα παρουσίαση.

```php
function accessModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);
        echo "Author: " . $author->getName() . ", Comment: " . $comment->getText() . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
}
```

## **Κατάργηση σύγχρονου σχολίου**

Καταργήστε ένα σχόλιο και αποθηκεύστε το ενημερωμένο αρχείο.

```php
function removeModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);

        $comment->remove();

        $presentation->save("modern_comment_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Απάντηση σε σύγχρονο σχόλιο**

Προσθέστε απαντήσεις σε ένα γονικό σύγχρονο σχόλιο.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Προσθέστε έναν συγγραφέα σχολίου.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Προσθέστε ένα γονικό σχόλιο και απαντήσεις.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // Ορίστε το γονικό σχόλιο για τις απαντήσεις.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // Αποθηκεύστε την παρουσίαση με τις απαντήσεις.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```