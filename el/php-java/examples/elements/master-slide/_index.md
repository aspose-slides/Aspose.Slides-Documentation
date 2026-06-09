---
title: Κύρια Διαφάνεια
type: docs
weight: 30
url: /el/php-java/examples/elements/master-slide/
keywords:
- κύρια διαφάνεια
- προσθήκη κύριας διαφάνειας
- πρόσβαση σε κύρια διαφάνεια
- αφαίρεση κύριας διαφάνειας
- αχρησιμοποίητη κύρια διαφάνεια
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τις κύριες διαφάνειες σε PHP με το Aspose.Slides: δημιουργήστε, επεξεργαστείτε, κλωνοποιήστε και μορφοποιήστε θεματικές, φόντα, σύμβολα κράτησης για να ενοποιήσετε τις διαφάνειες στο PowerPoint και το OpenDocument."
---
Οι κύριες διαφάνειες σχηματίζουν το υψηλότερο επίπεδο της ιεραρχίας κληρονόμησης διαφανειών στο PowerPoint. Μια **master slide** ορίζει κοινά στοιχεία σχεδίασης όπως φόντα, λογότυπα και μορφοποίηση κειμένου. Οι **layout slides** κληρονομούν από τις master slides, και οι **normal slides** κληρονομούν από τις layout slides.

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε, τροποποιήσετε και διαχειριστείτε κύριες διαφάνειες χρησιμοποιώντας το Aspose.Slides for PHP via Java.

## **Add a Master Slide**

Αυτό το παράδειγμα δείχνει πώς να δημιουργήσετε μια νέα κύρια διαφάνεια κλωνοποιώντας την προεπιλεγμένη.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // Κλωνοποιήστε την προεπιλεγμένη κύρια διαφάνεια.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** Οι κύριες διαφάνειες παρέχουν έναν τρόπο να εφαρμόζετε συνεπή εμπορική ταυτότητα ή κοινά στοιχεία σχεδίασης σε όλες τις διαφάνειες. Οποιαδήποτε αλλαγή γίνει στην κύρια διαφάνεια θα αντικατοπτρίζεται αυτόματα στις εξαρτώμενες διαφάνειες διάταξης και τις κανονικές διαφάνειες.  
> 
> 💡 **Tip 2:** Οποιοδήποτε σχήμα ή μορφοποίηση προστεθεί σε μια κύρια διαφάνεια κληρονομείται από τις διαφάνειες διάταξης και, με τη σειρά τους, από όλες τις κανονικές διαφάνειες που χρησιμοποιούν αυτές τις διατάξεις.  
> Η εικόνα παρακάτω δείχνει πώς ένα πλαίσιο κειμένου που προστέθηκε σε μια κύρια διαφάνεια αποδίδεται αυτόματα στην τελική διαφάνεια.

![Παράδειγμα Κληρονομικότητας Πατρικής Διαφάνειας](master-slide-banner.png)

## **Access a Master Slide**

Μπορείτε να αποκτήσετε πρόσβαση στις κύριες διαφάνειες χρησιμοποιώντας τη μέθοδο `Presentation::getMasters`. Δείτε πώς να τις ανακτήσετε και να εργαστείτε με αυτές:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Πρόσβαση στην πρώτη κύρια διαφάνεια.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a Master Slide**

Οι κύριες διαφάνειες μπορούν να αφαιρεθούν είτε με βάση τον δείκτη είτε με αναφορά.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Αφαίρεση με δείκτη.
        $presentation->getMasters()->removeAt(0);

        // Ή αφαίρεση με αναφορά.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove Unused Master Slides**

Ορισμένες παρουσιάσεις περιέχουν κύριες διαφάνειες που δεν χρησιμοποιούνται. Η αφαίρεση αυτών των διαφανειών μπορεί να βοηθήσει στη μείωση του μεγέθους του αρχείου.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Αφαίρεση όλων των αχρησιμοποίητων κύριων διαφανειών (ακόμη και εκείνων που έχουν σημειωθεί ως Preserve).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Tip:** Χρησιμοποιήστε το `removeUnused(true)` για να καθαρίσετε τις αχρησιμοποίητες κύριες διαφάνειες και να ελαχιστοποιήσετε το μέγεθος της παρουσίασης.