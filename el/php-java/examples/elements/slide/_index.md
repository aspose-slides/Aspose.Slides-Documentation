---
title: Διαφάνεια
type: docs
weight: 10
url: /el/php-java/examples/elements/slide/
keywords:
- διαφάνεια
- προσθήκη διαφάνειας
- πρόσβαση σε διαφάνεια
- δείκτης διαφάνειας
- κλωνοποίηση διαφάνειας
- αναδιάταξη διαφανειών
- αφαίρεση διαφάνειας
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τις διαφάνειες σε PHP με Aspose.Slides: δημιουργία, κλωνοποίηση, αναδιάταξη, απόκρυψη, ορισμός υποβάθρων και μεγέθους, εφαρμογή μεταβάσεων και εξαγωγή για PowerPoint και OpenDocument."
---
Αυτό το άρθρο παρέχει μια σειρά παραδειγμάτων που δείχνουν πώς να εργάζεστε με διαφάνειες χρησιμοποιώντας **Aspose.Slides for PHP via Java**. Θα μάθετε πώς να προσθέτετε, να αποκτάτε πρόσβαση, να κλωνοποιείτε, να αναδιατάσσετε και να αφαιρείτε διαφάνειες χρησιμοποιώντας την κλάση `Presentation`.

Κάθε παρακάτω παράδειγμα περιλαμβάνει μια σύντομη εξήγηση ακολουθούμενη από ένα απόσπασμα κώδικα σε PHP.

## **Προσθήκη διαφάνειας**

Για να προσθέσετε μια νέα διαφάνεια, πρέπει πρώτα να επιλέξετε μια διάταξη. Σε αυτό το παράδειγμα, χρησιμοποιούμε τη διάταξη `Blank` και προσθέτουμε μια κενή διαφάνεια στην παρουσίαση.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // Κάθε διαφάνεια βασίζεται σε μια διάταξη, η οποία με τη σειρά της βασίζεται σε μια κύρια διαφάνεια.
        // Χρησιμοποιήστε τη διάταξη Blank για να δημιουργήσετε μια νέα διαφάνεια.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Προσθέστε μια νέα κενή διαφάνεια χρησιμοποιώντας την επιλεγμένη διάταξη.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Συμβουλή:** Κάθε διάταξη διαφάνειας προέρχεται από μια κύρια διαφάνεια, η οποία ορίζει το συνολικό σχέδιο και τη δομή των placeholders. Η παρακάτω εικόνα απεικονίζει πώς οι κύριες διαφάνειες και οι σχετικές διατάξεις τους οργανώνονται στο PowerPoint.

![Σχέση κύριας διαφάνειας και διάταξης](master-layout-slide.png)

## **Πρόσβαση σε διαφάνειες κατά Δείκτη**

Μπορείτε να έχετε πρόσβαση στις διαφάνειες χρησιμοποιώντας το δείκτη τους.

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Πρόσβαση σε διαφάνεια κατά δείκτη.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Κλωνοποίηση διαφάνειας**

Αυτό το παράδειγμα δείχνει πώς να κλωνοποιήσετε μια υπάρχουσα διαφάνεια. Η κλωνοποιημένη διαφάνεια προστίθεται αυτόματα στο τέλος της συλλογής διαφανειών.

```php
function cloneSlide() {
    // Από προεπιλογή, η παρουσίαση περιέχει μία κενή διαφάνεια.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Κλωνοποιήστε την πρώτη διαφάνεια· θα προστεθεί στο τέλος της παρουσίασης.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // Ο δείκτης της κλωνοποιημένης διαφάνειας είναι 1 (η δεύτερη διαφάνεια στην παρουσίαση).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Αναδιάταξη διαφανειών**

Μπορείτε να αλλάξετε τη σειρά των διαφανειών μετακινώντας μία σε νέο δείκτη. Σε αυτήν την περίπτωση, μετακινούμε μια διαφάνεια στην πρώτη θέση.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // Μετακινήστε τη διαφάνεια στην πρώτη θέση (οι άλλες μετατοπίζονται προς τα κάτω).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Αφαίρεση διαφάνειας**

Για να αφαιρέσετε μια διαφάνεια, απλώς αναφέρετέ την και καλέστε `remove`. Αυτό το παράδειγμα αφαιρεί διαφάνειες κατά δείκτη και κατά αναφορά.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Αφαίρεση διαφάνειας κατά δείκτη.
        $presentation->getSlides()->removeAt(0);

        // Αφαίρεση διαφάνειας κατά αναφορά.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```