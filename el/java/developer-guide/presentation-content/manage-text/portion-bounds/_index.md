---
title: Ανάκτηση Ορίων Τμημάτων Κειμένου από Παρουσιάσεις σε Java
linktitle: Όρια Τμήματος
type: docs
weight: 47
url: /el/java/portion-bounds/
keywords:
- όρια τμήματος κειμένου
- τμήμα κειμένου
- μέρος κειμένου
- συντεταγμένες κειμένου
- θέση κειμένου
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια τμημάτων κειμένου σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Java."
---
## **Επισκόπηση**

Ένα τμήμα κειμένου αντιπροσωπεύει ένα συγκεκριμένο απόσπασμα κειμένου μέσα σε μια παράγραφο και σάς επιτρέπει να δουλέψετε με αυτό το απόσπασμα ανεξάρτητα από το περιεχόμενο γύρω του. Στο Aspose.Slides, τα τμήματα μπορούν να χρησιμοποιηθούν όταν χρειάζεται να ανακτήσετε τα όρια ενός αποσπάσματος κειμένου, να εφαρμόσετε μορφοποίηση μόνο σε μέρος μιας παραγράφου ή να ελέγξετε τη συμπεριφορά του κειμένου σε πιο λεπτομερή επίπεδο.

Αυτό το άρθρο δείχνει πώς να λάβετε το ορθογώνιο περιορισμού ενός τμήματος χρησιμοποιώντας [IPortion.getRect](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPortion#getRect--). Επίσης, δείχνει πώς να λάβετε τις συντεταγμένες της αρχής ενός τμήματος χρησιμοποιώντας [IPortion.getCoordinates](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPortion#getCoordinates--). Επιπλέον, τονίζει κοινά σενάρια που σχετίζονται με τμήματα, όπως η εφαρμογή υπερσυνδέσμου σε ένα μόνο απόσπασμα κειμένου, η κατανόηση του πώς η μορφοποίηση επιλύεται μέσω τμήματος, παραγράφου, πλαισίου κειμένου και κληρονομικότητας θέματος, και η διαχείριση περιπτώσεων όπου μια καθορισμένη γραμματοσειρά δεν είναι διαθέσιμη.

## **Λήψη Ορίων Τμήματος Κειμένου**

Χρησιμοποιήστε [IPortion.getRect](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPortion#getRect--) για να ανακτήσετε το ορθογώνιο περιορισμού ενός τμήματος κειμένου:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Λήψη Συντεταγμένων Τμήματος Κειμένου**

Χρησιμοποιήστε [IPortion.getCoordinates](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPortion#getCoordinates--) για να ανακτήσετε τις συντεταγμένες της αρχής ενός τμήματος κειμένου:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω υπερσύνδεσμο μόνο σε μέρος του κειμένου μέσα σε μία παράγραφο;**

Ναι, μπορείτε να [αναθέσετε έναν υπερσύνδεσμο](/slides/el/java/manage-hyperlinks/) σε ένα μεμονωμένο τμήμα· μόνο αυτό το απόσπασμα θα είναι κλικ‑able, όχι ολόκληρη η παράγραφος.

**Πώς λειτουργεί η κληρονομία στυλ: τι παρακάμπτει ένα τμήμα και τι λαμβάνει από μια παράγραφο ή πλαίσιο κειμένου;**

Οι ιδιότητες σε επίπεδο τμήματος έχουν την υψηλότερη προτεραιότητα. Εάν μια ιδιότητα δεν οριστεί στο [IPortion](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportion/), το Aspose.Slides την λαμβάνει από το [IParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraph/). Εάν δεν οριστεί ούτε εκεί, το Aspose.Slides χρησιμοποιεί το στυλ του [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/) ή του [theme](https://reference.aspose.com/slides/el/java/com.aspose.slides/theme/).

**Τι συμβαίνει αν η γραμματοσειρά που έχει οριστεί για ένα τμήμα λείπει από τον προορισμό ή τον διακομιστή;**

Εφαρμόζονται οι [κανόνες αντικατάστασης γραμματοσειρών](/slides/el/java/font-selection-sequence/). Το κείμενο μπορεί να αναδιαταχθεί: μετρικές, συλλαβισμός και πλάτος μπορούν να αλλάξουν, κάτι που είναι σημαντικό για ακριβή τοποθέτηση.

**Μπορώ να ορίσω διαφάνεια ή διαβάθμιση γέμισης κειμένου ειδικά για ένα τμήμα ανεξάρτητα από το υπόλοιπο της παραγράφου;**

Ναι, το χρώμα κειμένου, το γέμισμα και η διαφάνειά του σε επίπεδο [IPortion](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportion/) μπορεί να διαφέρει από τα γειτονικά αποσπάσματα.