---
title: Αλλαγή Μεγέθους και Προσανατολισμού Σελίδας Σημειώσεων σε JavaScript
linktitle: Μέγεθος Σελίδας Σημειώσεων
type: docs
weight: 10
url: /el/nodejs-java/notes-size/
keywords:
- μέγεθος σελίδας σημειώσεων
- προσανατολισμός σημειώσεων
- σημειώσεις τοπίου
- σημειώσεις σε πορτραίτο
- μέγεθος φυλλαδίου
- PowerPoint
- παρουσίαση
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαβάστε και αλλάξτε τις διαστάσεις της σελίδας σημειώσεων στο Aspose.Slides για Node.js μέσω Java, αλλάξτε τον προσανατολισμό, επαληθεύστε τα αποθηκευμένα μεγέθη και εξάγετε σημειώσεις ή φυλλάδια σε PDF και εικόνες."
---
## **Επισκόπηση**

Χρησιμοποιήστε [Presentation.getNotesSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getnotessize/) για να αποκτήσετε πρόσβαση στις ρυθμίσεις σελίδας σημειώσεων της παρουσίασης. Επιστρέφει ένα αντικείμενο [NotesSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notessize/) του οποίου η μέθοδος [setSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notessize/setsize/) ορίζει τις διαστάσεις της σελίδας. Αν και το αντικείμενο ρυθμίσεων δεν μπορεί να αντικατασταθεί, μπορείτε να ορίσετε νέες διαστάσεις μέσω αυτής της μεθόδου.

Το πλάτος και το ύψος καθορίζονται σε **σημεία**, με 72 σημεία ανά ίντσα. Για παράδειγμα, 900 × 600 σημεία ισοδυναμούν με 12,5 × 8⅓ ίντσες. Αυτές οι ρυθμίσεις εφαρμόζονται στην παρουσίαση, όχι σε μεμονωμένη σελίδα σημειώσεων μιας διαφάνειας.

| Ρύθμιση | Σκοπός |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getnotessize/) | Ελέγχει τις διαστάσεις της σελίδας σημειώσεων και τις διαστάσεις σελίδας που χρησιμοποιούνται για εξαγωγή φυλλαδίου. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getslidesize/) | Ελέγχει τις κανονικές διαστάσεις διαφάνειας της παρουσίασης μέσω του [SlideSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidesize/). |

Η αλλαγή της μιας ρύθμισης δεν αλλάζει αυτόματα την άλλη. Η αλλαγή του προσανατολισμού της σελίδας σημειώσεων επίσης δεν περιστρέφει τις κανονικές διαφάνειες. Δείτε το [Slide Size](/slides/el/nodejs-java/slide-size/) για να αλλάξετε το μέγεθος των κανονικών διαφανειών.

Τα παραδείγματα παρακάτω χρησιμοποιούν ένα υπάρχον `sample.pptx`. Για τα παραδείγματα εξαγωγής, χρησιμοποιήστε μια παρουσίαση με τουλάχιστον μία διαφάνεια που περιέχει σημειώσεις ομιλητή. Κάθε παράδειγμα μπορεί να εκτελεστεί ανεξάρτητα.

## **Ανάγνωση του Μεγέθους και του Προσανατολισμού της Σελίδας Σημειώσεων**

Διαβάστε το πλάτος και το ύψος και συγκρίνετέ τα για να προσδιορίσετε τον προσανατολισμό: μια ευρύτερη σελίδα είναι τοπίο, μια πιο ψηλή σελίδα είναι πορτραίτο, και ίσες διαστάσεις περιγράφουν τετράγωνη σελίδα. Αυτό το παράδειγμα εκτυπώνει τις πραγματικές διαστάσεις σε σημεία, χωρίς να υποθέτει ένα τυπικό μέγεθος χαρτιού.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Αλλαγή σε Τοπίο Χωρίς Αλλαγή του Μεγέθους Χαρτιού**

Για να αλλάξετε μόνο τον προσανατολισμό, ανταλλάξτε το υπάρχον πλάτος και ύψος. Έτσι διατηρούνται τα μήκη και των δύο πλευρών, συμπεριλαμβανομένων εκείνων ενός προσαρμοσμένου μεγέθους χαρτιού. Η παρακάτω συνθήκη αποτρέπει την αλλαγή μιας ήδη τοπιοειδούς σελίδας πίσω σε πορτραίτο και αφήνει αμετάβλητη μια τετράγωνη σελίδα.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για προσανατολισμό πορτραίτου, χρησιμοποιήστε την ίδια εκχώρηση όταν `size.getWidth() > size.getHeight()`. Μην αντικαταστήσετε τις διαστάσεις A4 ή Letter εκτός αν θέλετε επίσης να αλλάξετε το μέγεθος χαρτιού.

## **Ορισμός και Επαλήθευση Προσαρμοσμένου Μεγέθους Σελίδας Σημειώσεων**

Ορίστε και τις δύο διαστάσεις μαζί, έπειτα χρησιμοποιήστε [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/save/) για να αποθηκεύσετε την παρουσίαση. Το παράδειγμα αυτό ορίζει μια σελίδα τοπίο 900 × 600 σημείων, την αποθηκεύει ως PPTX και ξανά ανοίγει το αποθηκευμένο αρχείο για να ελέγξει τις διατηρημένες τιμές. Η σύγκριση επιτρέπει ανοχή 0,01 σημείου για τιμές κινητής υποδιαστολής· δεν αποτελεί εγγύηση ακριβούς στρογγυλοποίησης για κάθε μορφή αρχείου.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Το αναμενόμενο αποτέλεσμα είναι `900 x 600 points` και `Size preserved: true`. Ο έλεγχος μιας νεοανοιγμένης παρουσίασης επαληθεύει το αποθηκευμένο αρχείο, όχι μόνο τις ρυθμίσεις στη μνήμη.

## **Εξαγωγή Σημειώσεων και Φυλλαδίων**

Οι διαστάσεις της σελίδας ορίζουν τη διαθέσιμη περιοχή για διατάξεις σημειώσεων ή φυλλαδίου. Δεν ενεργοποιούν αυτές τις διατάξεις από μόνες τους: διαμορφώστε επίσης τις επιλογές εξαγωγής. Η εξαγωγή κανονικών διαφανειών συνεχίζει να χρησιμοποιεί τις διαστάσεις της διαφάνειας.

### **Εξαγωγή Σημειώσεων σε PDF και PNG**

Αναθέστε [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notescommentslayoutingoptions/) στο [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) για να συμπεριλάβετε σημειώσεις στο PDF. Αυτό το παράδειγμα επίσης αποδίδει την πρώτη διαφάνεια με σημειώσεις σε PNG χρησιμοποιώντας [Slide.getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#getImage) και [RenderingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/renderingoptions/).

Η λειτουργία [BottomTruncated](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notespositions/) διατηρεί τις σημειώσεις σε μία σελίδα· σημειώσεις που δεν χωρούν μπορούν να περικοπούν. Το PDF χρησιμοποιεί σελίδες 900 × 600 σημείων. Στην κλίμακα εικόνας 1 × 1 που χρησιμοποιείται παρακάτω, το PNG είναι 900 × 600 εικονοστοιχεία. Τα σημεία περιγράφουν τη γεωμετρία της σελίδας· τα εικονοστοιχεία περιγράφουν την εξαγόμενη raster εικόνα, των οποίων οι διαστάσεις εξαρτώνται επίσης από την κλίμακα απόδοσης.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Για εξαγωγή PDF με μεγάλες σημειώσεις, το [BottomFull](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notespositions/) επιτρέπει πρόσθετες σελίδες όπως απαιτείται. Μην χρησιμοποιήσετε αυτή τη λειτουργία με την κλήση εικόνας μιας μόνο διαφάνειας που φαίνεται παραπάνω, η οποία δεν την υποστηρίζει. Μετά την αλλαγή μεγέθους, ελέγξτε το αποτέλεσμα για αποκομμένες σημειώσεις και τη θέση των υπαρχόντων αντικειμένων notes‑master· η αλλαγή μόνο των διαστάσεων της σελίδας δεν πρέπει να θεωρηθεί εγγύηση ότι όλο το περιεχόμενο θα χωράει. Δείτε το [Convert PowerPoint to PDF with Notes](/slides/el/nodejs-java/convert-powerpoint-to-pdf-with-notes/) για περισσότερα σχετικά με την εξαγωγή σημειώσεων.

### **Εξαγωγή Φυλλαδίων σε PDF**

Χρησιμοποιήστε [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/handoutlayoutingoptions/) για πολλαπλές μικρογραφίες διαφανειών σε μία σελίδα. Το παρακάτω παράδειγμα ορίζει μια σελίδα 900 × 600 σημείων και χρησιμοποιεί [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/handouttype/) για να οργανώσει μέχρι τέσσερις διαφάνειες ανά σελίδα. Η οριζόντια προεπιλογή ελέγχει τη σειρά των διαφανειών· ο προσανατολισμός της σελίδας προέρχεται από το πλάτος και το ύψος της.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Η αλλαγή του μεγέθους της σελίδας αλλάζει την περιοχή που είναι διαθέσιμη για το πλέγμα του φυλλαδίου χωρίς να αλλάζει τις διαστάσεις των πηγής διαφανειών. Για εικόνες φυλλαδίου, χρησιμοποιήστε [Presentation.getImages](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getimages/) με τη διάταξη φυλλαδίου, αντί για τη μέθοδο εικόνας μιας μεμονωμένης διαφάνειας. Στο Aspose.Slides, η απόδοση φυλλαδίου σε επίπεδο παρουσίασης χρησιμοποιεί τις διαστάσεις σελίδας σημειώσεων, ενώ η κλήση εικόνας μεμονωμένης διαφάνειας δεν παράγει τη σελίδα φυλλαδίου. Δείτε το [Handout Mode](/slides/el/nodejs-java/convert-powerpoint-in-handout-mode/) για επιλογές διάταξης.

## **Μέγεθος Σελίδας σε Προγράμματα Προβολής, Εξαγωγή και Εκτύπωση**

Διατηρήστε ξεχωριστά το αποθηκευμένο μέγεθος παρουσίασης, το εξαγόμενο μέγεθος σελίδας και το εκτυπωμένο μέγεθος χαρτιού:

- **Προβολείς παρουσίασης:** Ένας προβολέας μπορεί να εμφανίσει ή να εκτυπώσει σημειώσεις χρησιμοποιώντας τους δικούς του κανόνες διάταξης. Αν μια άλλη εφαρμογή αποθηκεύσει το αρχείο, ανοίξτε το ξανά και ελέγξτε ξανά τις διαστάσεις· η μετατροπή μορφής αυτής της εφαρμογής μπορεί να τα κανονικοποιήσει.
- **Μορφές εξαγωγής:** Τα παραδείγματα PDF για σημειώσεις και φυλλάδια παραπάνω χρησιμοποιούν τις διαμορφωμένες διαστάσεις σελίδας. Οι raster εικόνες χρησιμοποιούν ακέραιες διαστάσεις εικονοστοιχείων και κλίμακα απόδοσης, επομένως οι κλασματικές τιμές σημείων μπορεί να στρογγυλοποιηθούν στην έξοδο εικόνας. Η εξαγωγή κανονικών διαφανειών δεν εφαρμόζει το μέγεθος σελίδας σημειώσεων.
- **Οδηγοί εκτυπωτών:** Η επιλογή χαρτιού, η αυτόματη περιστροφή και οι ρυθμίσεις προσαρμογής σελίδας μπορούν να αλλάξουν το φυσικό αποτέλεσμα χωρίς να αλλάξουν τις διαστάσεις που αποθηκεύονται στην παρουσίαση ή στο PDF. Για συγκεκριμένο μέγεθος χαρτιού, ταιριάξτε τις ρυθμίσεις του εκτυπωτή και ελέγξτε την προεπισκόπηση εκτύπωσης.

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω το μέγεθος σημειώσεων μόνο για μία διαφάνεια;**

Το μέγεθος σελίδας σημειώσεων είναι ρύθμιση σε επίπεδο παρουσίασης. Οι μεμονωμένες διαφάνειες μπορούν να έχουν διαφορετικό περιεχόμενο σημειώσεων, αλλά αυτή η ιδιότητα δεν παρέχει ξεχωριστό μέγεθος σελίδας για κάθε διαφάνεια.

**Γιατί η αλλαγή του προσανατολισμού των σημειώσεων δεν άλλαξε τις διαφάνειές μου;**

Οι σελίδες σημειώσεων και οι κανονικές διαφάνειες έχουν ανεξάρτητες διαστάσεις. Χρησιμοποιήστε τις ρυθμίσεις διαστάσεων κανονικής διαφάνειας όταν θέλετε να αλλάξετε το μέγεθος των ίδιων των διαφανειών.

**Γιατί το αποθηκευμένο ή εκτυπωμένο αποτέλεσμα έχει διαφορετικό μέγεθος;**

Αρχικά ανοίξτε ξανά την αποθηκευμένη παρουσίαση και συγκρίνετε τις διαστάσεις των σημειώσεων. Αν αυτές έχουν αλλάξει, ελέγξτε αν η αποθήκευση ή η μετατροπή του αρχείου σε άλλη εφαρμογή άλλαξε τις ρυθμίσεις σελίδας. Αν όχι, ελέγξτε τη διάταξη εξαγωγής, την κλίμακα εικόνας, τις ρυθμίσεις προβολέα και την επιλογή χαρτιού του εκτυπωτή.