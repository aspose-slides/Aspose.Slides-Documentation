---
title: Διαχείριση τμημάτων κειμένου σε παρουσιάσεις χρησιμοποιώντας Java
linktitle: Τμήμα κειμένου
type: docs
weight: 70
url: /el/java/portion/
keywords:
- τμήμα κειμένου
- μέρος κειμένου
- συντεταγμένες κειμένου
- θέση κειμένου
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τμήματα κειμένου σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Java, βελτιώνοντας την απόδοση και την προσαρμογή."
---
## **Επισκόπηση**

Ένα τμήμα κειμένου αντιπροσωπεύει ένα συγκεκριμένο απόσπασμα κειμένου μέσα σε μια παράγραφο και σας επιτρέπει να εργαστείτε με αυτό το απόσπασμα ανεξάρτητα από το περιεχόμενο γύρω του. Στο Aspose.Slides, τα τμήματα μπορούν να χρησιμοποιηθούν όταν χρειάζεται να ανακτήσετε τη θέση ενός αποσπάσματος κειμένου, να εφαρμόσετε μορφοποίηση μόνο σε μέρος μιας παραγράφου ή να ελέγξετε τη συμπεριφορά του κειμένου σε πιο λεπτομερή επίπεδο.

Αυτό το άρθρο δείχνει πώς να λάβετε τις συντεταγμένες της αρχής ενός τμήματος χρησιμοποιώντας τη μέθοδο `getCoordinates()`. Επίσης επισημαίνει κοινά σενάρια σχετικά με τα τμήματα, όπως η εφαρμογή υπερσυνδέσμου σε ένα μόνο απόσπασμα κειμένου, η κατανόηση του πώς η μορφοποίηση επιλύεται μέσω του τμήματος, της παραγράφου, του πλαισίου κειμένου και της κληρονομικότητας του θέματος, και η διαχείριση περιπτώσεων όπου μια καθορισμένη γραμματοσειρά δεν είναι διαθέσιμη. Επιπλέον, σημειώνει ότι η γεμιστική, το χρώμα και η διαφάνεια του κειμένου μπορούν να οριστούν διαφορετικά για μεμονωμένα τμήματα μέσα στην ίδια παράγραφο.

## **Λήψη Συντεταγμένων ενός Τμήματος Κειμένου**
Η μέθοδος [**getCoordinates()**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPortion#getCoordinates--) προστέθηκε στις κλάσεις [IPortion](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportion/) και [Portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/portion/) που επιτρέπουν την ανάκτηση των συντεταγμένων της αρχής του τμήματος.

```java
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Ανασχηματισμός του πλαισίου της παρουσίασης
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω έναν υπερσύνδεσμο μόνο σε μέρος του κειμένου σε μία μόνο παράγραφο;**

Ναι, μπορείτε να [αναθέσετε έναν υπερσύνδεσμο](/slides/el/java/manage-hyperlinks/) σε ένα μεμονωμένο τμήμα· μόνο αυτό το απόσπασμα θα είναι κλικαρίσιμο, όχι ολόκληρη η παράγραφος.

**Πώς λειτουργεί η κληρονομικότητα του στυλ: τι αντικαθιστά ένα Portion και τι λαμβάνεται από την Paragraph/TextFrame;**

Τα χαρακτηριστικά σε επίπεδο Portion έχουν την υψηλότερη προτεραιότητα. Εάν ένα χαρακτηριστικό δεν οριστεί στο [Portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/portion/), η μηχανή το λαμβάνει από την [Paragraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/paragraph/); εάν δεν οριστεί και εκεί, το παίρνει από το [TextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/textframe/) ή το στυλ του [theme](https://reference.aspose.com/slides/el/java/com.aspose.slides/theme/).

**Τι συμβαίνει αν η γραμματοσειρά που έχει καθοριστεί για ένα Portion λείπει στο στόχο μηχανή/διακομιστή;**

Εφαρμόζονται οι [κανόνες αντικατάστασης γραμματοσειράς](/slides/el/java/font-selection-sequence/). Το κείμενο μπορεί να αναδιαταχθεί: τα μετρικά, η συλλαβοποίηση και το πλάτος μπορεί να αλλάξουν, κάτι που έχει σημασία για την ακριβή τοποθέτηση.

**Μπορώ να ορίσω διαφάνεια ή διαβάθμιση γεμίσματος κειμένου ειδικά για ένα Portion, ανεξάρτητα από το υπόλοιπο της παραγράφου;**

Ναι, το χρώμα κειμένου, το γέμισμα και η διαφάνεια σε επίπεδο [Portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/portion/) μπορούν να διαφέρουν από τα γειτονικά τμήματα.