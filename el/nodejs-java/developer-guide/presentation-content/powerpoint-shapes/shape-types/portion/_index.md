---
title: Διαχείριση Τμημάτων Κειμένου σε Παρουσιάσεις Χρησιμοποιώντας JavaScript
linktitle: Τμήμα Κειμένου
type: docs
weight: 70
url: /el/nodejs-java/portion/
keywords:
- τμήμα κειμένου
- μέρος κειμένου
- συντεταγμένες κειμένου
- θέση κειμένου
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τμήματα κειμένου σε παρουσιάσεις PowerPoint χρησιμοποιώντας JavaScript και Aspose.Slides για Node.js μέσω Java, βελτιώνοντας την απόδοση και την προσαρμογή."
---
## **Επισκόπηση**

Ένα τμήμα κειμένου αντιπροσωπεύει ένα συγκεκριμένο απόσπασμα κειμένου μέσα σε μια παράγραφο και σας επιτρέπει να δουλεύετε με αυτό το απόσπασμα ανεξάρτητα από το περιβάλλον περιεχόμενο. Στο Aspose.Slides, τα τμήματα μπορούν να χρησιμοποιηθούν όταν χρειάζεται να ανακτήσετε τη θέση ενός αποσπάσματος κειμένου, να εφαρμόσετε μορφοποίηση μόνο σε μέρος μιας παραγράφου ή να ελέγξετε τη συμπεριφορά του κειμένου σε πιο λεπτομερές επίπεδο.

Αυτό το άρθρο δείχνει πώς να λάβετε τις συντεταγμένες της αρχής ενός τμήματος χρησιμοποιώντας τη μέθοδο `getCoordinates()`. Επισημαίνει επίσης κοινές περιπτώσεις που αφορούν τμήματα, όπως η εφαρμογή υπερσυνδέσμου σε ένα μόνο απόσπασμα κειμένου, η κατανόηση του πώς η μορφοποίηση επιλύεται μέσω του τμήματος, της παραγράφου, του πλαισίου κειμένου και της κληρονόμησης θέματος, και η αντιμετώπιση περιπτώσεων όπου μια καθορισμένη γραμματοσειρά δεν είναι διαθέσιμη. Επιπλέον, σημειώνει ότι η γέμιση κειμένου, το χρώμα και η διαφάνεια μπορούν να οριστούν διαφορετικά για μεμονωμένα τμήματα μέσα στην ίδια παράγραφο.

## **Λήψη Συντεταγμένων Θέσης Τμήματος**
[**getCoordinates()**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Portion#getCoordinates--) Η μέθοδος προστέθηκε στην κλάση [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/) που επιτρέπει την ανάκτηση των συντεταγμένων της αρχής του τμήματος.

```javascript
// Δημιουργία κλάσης Presentation που αντιπροσωπεύει το PPTX
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Επανασχηματισμός του πλαισίου της παρουσίασης
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω υπερσύνδεσμο μόνο σε μέρος του κειμένου μέσα σε μία παράγραφο;**

Ναι, μπορείτε να [αναθέσετε έναν υπερσύνδεσμο](/slides/el/nodejs-java/manage-hyperlinks/) σε ένα μεμονωμένο τμήμα· μόνο αυτό το απόσπασμα θα είναι κλικαρίσιμο, όχι ολόκληρη η παράγραφος.

**Πώς λειτουργεί η κληρονομικότητα στυλ: τι παρακάμπτει ένα Portion και τι λαμβάνεται από το Paragraph/TextFrame;**

Οι ιδιότητες σε επίπεδο Portion έχουν την υψηλότερη προτεραιότητα. Εάν μια ιδιότητα δεν οριστεί στο [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/), η μηχανή την παίρνει από το [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/); εάν δεν οριστεί ούτε εκεί, από το [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) ή το στυλ του [theme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/theme/).

**Τι συμβαίνει αν η γραμματοσειρά που έχει καθοριστεί για ένα Portion λείπει στο στοχευόμενο μηχάνημα/διακομιστή;**

[Κανόνες αντικατάστασης γραμματοσειράς](/slides/el/nodejs-java/font-selection-sequence/) εφαρμόζονται. Το κείμενο μπορεί να ξανασυσχετιστεί: τα μετρικά, η συλλαβισμός και το πλάτος μπορούν να αλλάξουν, κάτι που έχει σημασία για την ακριβή τοποθέτηση.

**Μπορώ να ορίσω διαφάνεια ή διαβάθμιση γεμίσματος κειμένου ειδικά για ένα Portion, ανεξάρτητα από το υπόλοιπο της παραγράφου;**

Ναι, το χρώμα κειμένου, το γέμισμα και η διαφάνεια στο επίπεδο του [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/) μπορούν να διαφέρουν από τα γειτονικά αποσπάσματα.