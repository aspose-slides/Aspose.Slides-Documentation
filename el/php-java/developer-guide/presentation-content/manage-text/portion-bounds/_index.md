---
title: Λήψη ορίων τμήματος κειμένου από παρουσιάσεις σε PHP
linktitle: Όρια Τμήματος
type: docs
weight: 47
url: /el/php-java/portion-bounds/
keywords:
- όρια τμήματος κειμένου
- τμήμα κειμένου
- μέρος κειμένου
- συντεταγμένες κειμένου
- θέση κειμένου
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια τμημάτων κειμένου σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Ένα τμήμα κειμένου αντιπροσωπεύει ένα συγκεκριμένο απόσπασμα κειμένου μέσα σε μια παράγραφο και σας επιτρέπει να εργαστείτε με αυτό το απόσπασμα ανεξάρτητα από το περιβάλλον περιεχόμενο. Στο Aspose.Slides, τα τμήματα μπορούν να χρησιμοποιηθούν όταν χρειάζεται να ανακτήσετε τα όρια ενός αποσπάσματος κειμένου, να εφαρμόσετε μορφοποίηση μόνο σε μέρος μιας παραγράφου ή να ελέγξετε τη συμπεριφορά του κειμένου σε λεπτομερέστερο επίπεδο.

Αυτό το άρθρο δείχνει πώς να λάβετε το ορθογώνιο πλαίσιο ενός τμήματος χρησιμοποιώντας [Portion::getRect](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/getrect/). Επίσης δείχνει πώς να λάβετε τις συντεταγμένες της αρχής ενός τμήματος χρησιμοποιώντας [Portion::getCoordinates](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/getcoordinates/). Επιπλέον, τονίζει κοινές περιπτώσεις σχετικά με τμήματα, όπως η εφαρμογή υπερσυνδέσμου σε ένα μόνο απόσπασμα κειμένου, η κατανόηση του τρόπου επίλυσης της μορφοποίησης μέσω του τμήματος, της παραγράφου, του πλαισίου κειμένου και της κληρονόμησης θέματος, και η διαχείριση περιπτώσεων όπου μια καθορισμένη γραμματοσειρά δεν είναι διαθέσιμη.

## **Λήψη ορίων τμήματος κειμένου**

Χρησιμοποιήστε [Portion::getRect](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/getrect/) για να ανακτήσετε το ορθογώνιο πλαίσιο ενός τμήματος κειμένου:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Λήψη συντεταγμένων τμήματος κειμένου**

Χρησιμοποιήστε [Portion::getCoordinates](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/getcoordinates/) για να ανακτήσετε τις συντεταγμένες της αρχής ενός τμήματος κειμένου:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Μπορώ να εφαρμόσω έναν υπερσύνδεσμο μόνο σε μέρος του κειμένου μέσα σε μία ενιαία παράγραφο;**

Ναι, μπορείτε να [ορίσετε έναν υπερσύνδεσμο](/slides/el/php-java/manage-hyperlinks/) σε ένα μεμονωμένο τμήμα· μόνο αυτό το απόσπασμα θα είναι ενεργό, όχι ολόκληρη η παράγραφος.

**Πώς λειτουργεί η κληρονομικότητα στυλ: τι παρακάμπτει ένα τμήμα και τι λαμβάνεται από μια παράγραφο ή ένα πλαίσιο κειμένου;**

Οι ιδιότητες σε επίπεδο τμήματος έχουν την υψηλότερη προτεραιότητα. Εάν μια ιδιότητα δεν έχει οριστεί στο [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/), το Aspose.Slides την ανακτά από το [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/). Εάν δεν έχει οριστεί ούτε εκεί, το Aspose.Slides χρησιμοποιεί το στυλ του [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) ή του [theme](https://reference.aspose.com/slides/el/php-java/aspose.slides/theme/).

**Τι συμβαίνει αν η γραμματοσειρά που έχει οριστεί για ένα τμήμα λείπει στο στόχο μηχάνημα ή διακομιστή;**

Ισχύουν οι [κανόνες αντικατάστασης γραμματοσειρών](/slides/el/php-java/font-selection-sequence/). Το κείμενο μπορεί να επαναδιαταχθεί: οι μετρικές, η συλλαβοδιάσπαση και το πλάτος μπορούν να αλλάξουν, κάτι που έχει σημασία για ακριβή τοποθέτηση.

**Μπορώ να ορίσω διαφάνεια ή διαβάθμιση γεμίσματος κειμένου ειδικά για ένα τμήμα, ανεξάρτητα από το υπόλοιπο της παραγράφου;**

Ναι, το χρώμα κειμένου, το γέμισμα και η διαφάνεια σε επίπεδο [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) μπορούν να διαφέρουν από τα γειτονικά αποσπάσματα.