---
title: Απόκτηση ορίων τμήματος κειμένου από παρουσιάσεις σε JavaScript
linktitle: Όρια Τμήματος
type: docs
weight: 47
url: /el/nodejs-java/portion-bounds/
keywords:
- όρια τμήματος κειμένου
- τμήμα κειμένου
- μέρος κειμένου
- συντεταγμένες κειμένου
- θέση κειμένου
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια τμημάτων κειμένου σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Ένα τμήμα κειμένου αντιπροσωπεύει ένα συγκεκριμένο απόσπασμα κειμένου μέσα σε μια παράγραφο και σας επιτρέπει να εργαστείτε με αυτό το απόσπασμα ανεξάρτητα από το περιεχόμενο γύρω του. Στο Aspose.Slides, τα τμήματα μπορούν να χρησιμοποιηθούν όταν χρειάζεται να ανακτήσετε τα όρια ενός αποσπάσματος κειμένου, να εφαρμόσετε μορφοποίηση μόνο σε μέρος μιας παραγράφου ή να ελέγξετε τη συμπεριφορά του κειμένου σε πιο λεπτομερές επίπεδο.

Αυτό το άρθρο δείχνει πώς να λάβετε το οριοθετημένο ορθογώνιο ενός τμήματος χρησιμοποιώντας [Portion.getRect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/getrect/). Επίσης δείχνει πώς να λάβετε τις συντεταγμένες της αρχής ενός τμήματος χρησιμοποιώντας [Portion.getCoordinates](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/getcoordinates/). Επιπλέον, επισημαίνει κοινά σενάρια που σχετίζονται με τμήματα, όπως η εφαρμογή υπερσυνδέσμου σε ένα μόνο απόσπασμα κειμένου, η κατανόηση του τρόπου με τον οποίο η μορφοποίηση επιλύεται μέσω τμήματος, παραγράφου, πλαισίου κειμένου και κληρονομικότητας θέματος, και η διαχείριση περιπτώσεων όπου μια καθορισμένη γραμματοσειρά δεν είναι διαθέσιμη.

## **Λήψη ορίων ενός τμήματος κειμένου**

Χρησιμοποιήστε το [Portion.getRect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/getrect/) για να ανακτήσετε το οριοθετημένο ορθογώνιο ενός τμήματος κειμένου:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Λήψη συντεταγμένων ενός τμήματος κειμένου**

Χρησιμοποιήστε το [Portion.getCoordinates](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/getcoordinates/) για να ανακτήσετε τις συντεταγμένες της αρχής ενός τμήματος κειμένου:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να εφαρμόσω υπερσύνδεσμο μόνο σε μέρος του κειμένου μέσα σε μία ενιαία παράγραφο;**

Ναι, μπορείτε να [επιβάλλετε έναν υπερσύνδεσμο](/slides/el/nodejs-java/manage-hyperlinks/) σε ένα μεμονωμένο τμήμα· μόνο εκείνο το απόσπασμα θα είναι κλικαρέ, όχι ολόκληρη η παράγραφος.

**Πώς λειτουργεί η κληρονομικότητα στυλ: τι παρακάμπτει ένα τμήμα και τι κληρονομείται από παράγραφο ή πλαίσιο κειμένου;**

Οι ιδιότητες σε επίπεδο τμήματος έχουν την υψηλότερη προτεραιότητα. Εάν μια ιδιότητα δεν οριστεί στο [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/), το Aspose.Slides την παίρνει από την [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/). Εάν δεν οριστεί και εκεί, το Aspose.Slides χρησιμοποιεί το στυλ του [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) ή του [theme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/theme/).

**Τι συμβαίνει αν η γραμματοσειρά που έχει οριστεί για ένα τμήμα λείπει στη στόχο μηχανή ή διακομιστή;**

Ισχύουν οι [κανόνες αντικατάστασης γραμματοσειρών](/slides/el/nodejs-java/font-selection-sequence/). Το κείμενο μπορεί να αναδιαταχθεί: οι μετρικές, η συλλαβιστική και το πλάτος μπορεί να αλλάξουν, κάτι που έχει σημασία για την ακριβή τοποθέτηση.

**Μπορώ να ορίσω διαφάνεια ή διαβάθμιση γεμίσματος κειμένου ειδικά για τμήμα, ανεξάρτητα από το υπόλοιπο της παραγράφου;**

Ναι, το χρώμα κειμένου, το γέμισμα και η διαφάνεια σε επίπεδο [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/) μπορούν να διαφέρουν από τα γειτονικά αποσπάσματα.