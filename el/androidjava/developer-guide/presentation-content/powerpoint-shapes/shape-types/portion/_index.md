---
title: Διαχείριση τμημάτων κειμένου σε παρουσιάσεις στο Android
linktitle: Τμήμα κειμένου
type: docs
weight: 70
url: /el/androidjava/portion/
keywords:
- τμήμα κειμένου
- μέρος κειμένου
- συντεταγμένες κειμένου
- θέση κειμένου
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τμήματα κειμένου σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Android μέσω Java, βελτιώνοντας την απόδοση και την προσαρμοστικότητα."
---
## **Εισαγωγή**

Μια ενότητα κειμένου αντιπροσωπεύει ένα συγκεκριμένο απόσπασμα κειμένου μέσα σε μια παράγραφο και σας επιτρέπει να εργάζεστε με αυτό το απόσπασμα ανεξάρτητα από το περιεχόμενο που το περιβάλλει. Στο Aspose.Slides, οι ενότητες μπορούν να χρησιμοποιηθούν όταν χρειάζεται να ανακτήσετε τη θέση ενός αποσπάσματος κειμένου, να εφαρμόσετε μορφοποίηση μόνο σε μέρος μιας παραγράφου ή να ελέγξετε τη συμπεριφορά του κειμένου σε πιο λεπτομερή επίπεδο.

## **Λήψη Συντεταγμένων μιας Ενότητας Κειμένου**
[**getCoordinates()**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPortion#getCoordinates--) η μέθοδος προστέθηκε στις κλάσεις [IPortion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/) και [Portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portion/) που επιτρέπει την ανάκτηση των συντεταγμένων της αρχής της ενότητας.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Ανασχηματισμός του περιβάλλοντος της παρουσίασης
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

**Μπορώ να εφαρμόσω υπερσύνδεσμο μόνο σε μέρος του κειμένου μέσα σε μία παράγραφο;**

Ναι, μπορείτε να [αναθέσετε έναν υπερσύνδεσμο](/slides/el/androidjava/manage-hyperlinks/) σε μια μεμονωμένη ενότητα· μόνο αυτό το απόσπασμα θα είναι κλικαρίσιμο, όχι ολόκληρη η παράγραφος.

**Πώς λειτουργεί η κληρονομικότητα στυλ: τι παρακάμπτει μια Portion και τι λαμβάνεται από το Paragraph/TextFrame;**

Οι ιδιότητες σε επίπεδο Portion έχουν την υψηλότερη προτεραιότητα. Εάν μια ιδιότητα δεν έχει οριστεί στην [Portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portion/), η μηχανή την παίρνει από το [Paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraph/); αν δεν έχει οριστεί και εκεί, την παίρνει από το [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframe/) ή το στυλ του [theme](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/theme/).

**Τι συμβαίνει αν η γραμματοσειρά που έχει οριστεί για μια Portion λείπει στο στόχο μητρώο/εξυπηρετητή;**

[Κανόνες αντικατάστασης γραμματοσειρών](/slides/el/androidjava/font-selection-sequence/) εφαρμόζονται. Το κείμενο μπορεί να ξαναρρέει: τα μετρικά, η συλλαβοποίηση και το πλάτος ενδέχεται να αλλάξουν, κάτι που μετράει για ακριβή τοποθέτηση.

**Μπορώ να ορίσω διαφάνεια ή διαβάθμιση γεμίσματος κειμένου ειδικά για μια Portion, ανεξάρτητα από το υπόλοιπο της παραγράφου;**

Ναι, το χρώμα κειμένου, το γέμισμα και η διαφάνεια σε επίπεδο [Portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portion/) μπορούν να διαφέρουν από τα γειτονικά αποσπάσματα.