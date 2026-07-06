---
title: Λήψη ορίων τμήματος κειμένου από παρουσιάσεις σε Android
linktitle: Όρια Περιοχής
type: docs
weight: 47
url: /el/androidjava/portion-bounds/
keywords:
- όρια τμήματος κειμένου
- τμήμα κειμένου
- μέρος κειμένου
- συντεταγμένες κειμένου
- θέση κειμένου
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια τμήματος κειμένου σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Μια περιοχή κειμένου αντιπροσωπεύει ένα συγκεκριμένο τμήμα κειμένου μέσα σε μια παράγραφο και σας επιτρέπει να εργάζεστε με αυτό το τμήμα ανεξάρτητα από το περιβάλλον κείμενο. Στο Aspose.Slides, οι περιοχές μπορούν να χρησιμοποιηθούν όταν χρειάζεται να ανακτήσετε τα όρια ενός τμήματος κειμένου, να εφαρμόσετε μορφοποίηση μόνο σε μέρος μιας παραγράφου ή να ελέγχετε τη συμπεριφορά του κειμένου σε πιο λεπτομερές επίπεδο.

Αυτό το άρθρο δείχνει πώς να λάβετε το ορθογώνιο περιβάλλον μιας περιοχής χρησιμοποιώντας [IPortion.getRect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPortion#getRect--). Επίσης δείχνει πώς να λάβετε τις συντεταγμένες της αρχής μιας περιοχής χρησιμοποιώντας [IPortion.getCoordinates](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPortion#getCoordinates--). Επιπλέον, τονίζει κοινά σενάρια σχετιζόμενα με περιοχές, όπως η εφαρμογή υπερσυνδέσμου σε ένα μοναδικό τμήμα κειμένου, η κατανόηση του πώς η μορφοποίηση επιλύεται μέσω της περιοχής, της παραγράφου, του πλαισίου κειμένου και της κληρονομικότητας θέματος, και η διαχείριση περιπτώσεων όπου η καθορισμένη γραμματοσειρά δεν είναι διαθέσιμη.

## **Λήψη Ορίων Μιας Περιοχής Κειμένου**

Χρησιμοποιήστε [IPortion.getRect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPortion#getRect--) για να ανακτήσετε το ορθογώνιο περιβάλλον μιας περιοχής κειμένου:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Λήψη Συντεταγμένων Μιας Περιοχής Κειμένου**

Χρησιμοποιήστε [IPortion.getCoordinates](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPortion#getCoordinates--) για να ανακτήσετε τις συντεταγμένες της αρχής μιας περιοχής κειμένου:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω υπερσύνδεσμο μόνο σε μέρος του κειμένου μέσα σε μια μόνο παράγραφο;**

Ναι, μπορείτε να [αναθέσετε έναν υπερσύνδεσμο](/slides/el/androidjava/manage-hyperlinks/) σε μια μεμονωμένη περιοχή· μόνο αυτό το τμήμα θα είναι κλικ‑δυνατό, όχι ολόκληρη η παράγραφο.

**Πώς λειτουργεί η κληρονομικότητα στυλ: τι παραβιάζει μια περιοχή και τι λαμβάνεται από μια παράγραφο ή πλαίσιο κειμένου;**

Οι ιδιότητες σε επίπεδο περιοχής έχουν την υψηλότερη προτεραιότητα. Εάν μια ιδιότητα δεν οριστεί στο [IPortion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/), το Aspose.Slides την λαμβάνει από το [IParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/). Εάν δεν οριστεί ούτε εκεί, το Aspose.Slides χρησιμοποιεί το στυλ του [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) ή του [theme](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/theme/).

**Τι συμβαίνει αν η γραμματοσειρά που καθορίζεται για μια περιοχή λείπει στο στοχευμένο μηχάνημα ή διακομιστή;**

Εφαρμόζονται οι [κανόνες αντικατάστασης γραμματοσειρών](/slides/el/androidjava/font-selection-sequence/). Το κείμενο μπορεί να ρεφλουάρει: οι μετρικές, η συλλαβισμός και το πλάτος μπορεί να αλλάξουν, κάτι που έχει σημασία για ακριβή τοποθέτηση.

**Μπορώ να ορίσω διαφάνεια γέμισης κειμένου ή διαβάθμιση ειδικά για μια περιοχή, ανεξάρτητα από το υπόλοιπο της παραγράφου;**

Ναι, το χρώμα κειμένου, η γεμιστική περιοχή και η διαφάνεια στο επίπεδο του [IPortion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/) μπορούν να διαφέρουν από τα γειτονικά τμήματα.