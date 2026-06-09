---
title: Μετατροπή Διαφανειών Παρουσίασης σε Εικόνες με JavaScript
linktitle: Διαφάνεια σε Εικόνα
type: docs
weight: 35
url: /el/nodejs-java/convert-slide/
keywords:
- μετατροπή διαφάνειας
- εξαγωγή διαφάνειας
- διαφάνεια σε εικόνα
- αποθήκευση διαφάνειας ως εικόνα
- διαφάνεια σε PNG
- διαφάνεια σε JPEG
- διαφάνεια σε bitmap
- διαφάνεια σε TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατροπή διαφανειών από PPT, PPTX και ODP σε εικόνες με JavaScript χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java — γρήγορη, υψηλής ποιότητας απόδοση με σαφή παραδείγματα κώδικα."
---
## **Εισαγωγή**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να μετατρέπετε εύκολα διαφάνειες παρουσιάσεων PowerPoint και OpenDocument σε διάφορες μορφές εικόνας, συμπεριλαμβανομένων των BMP, PNG, JPG (JPEG), GIF και άλλων.

Για να μετατρέψετε μια διαφάνεια σε εικόνα, ακολουθήστε τα παρακάτω βήματα:

1. Ορίστε τις επιθυμητές ρυθμίσεις μετατροπής και επιλέξτε τις διαφάνειες που θέλετε να εξάγετε χρησιμοποιώντας:
    - Τη κλάση [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/) , ή
    - Τη κλάση [RenderingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/renderingoptions/) .
2. Δημιουργήστε την εικόνα της διαφάνειας καλώντας τη μέθοδο [getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#getImage).

Στο Aspose.Slides για Node.js μέσω Java, ένα [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/) είναι μια κλάση που σας επιτρέπει να εργάζεστε με εικόνες που ορίζονται από δεδομένα εικονοστοιχείων. Μπορείτε να χρησιμοποιήσετε αυτήν την κλάση για να αποθηκεύετε εικόνες σε μια ευρεία γκάμα μορφών (BMP, JPG, PNG κ.λπ.).

## **Μετατροπή Διαφανειών σε Bitmap και Αποθήκευση των Εικόνων σε PNG**

Μπορείτε να μετατρέψετε μια διαφάνεια σε αντικείμενο bitmap και να το χρησιμοποιήσετε απευθείας στην εφαρμογή σας. Εναλλακτικά, μπορείτε να μετατρέψετε μια διαφάνεια σε bitmap και στη συνέχεια να αποθηκεύσετε την εικόνα σε JPEG ή οποιαδήποτε άλλη προτιμώμενη μορφή.

Αυτός ο κώδικας JavaScript δείχνει πώς να μετατρέψετε την πρώτη διαφάνεια μιας παρουσίασης σε αντικείμενο bitmap και στη συνέχεια να αποθηκεύσετε την εικόνα σε μορφή PNG:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Μετατρέψτε την πρώτη διαφάνεια στην παρουσίαση σε bitmap.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // Αποθηκεύστε την εικόνα στη μορφή PNG.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Μετατροπή Διαφανειών σε Εικόνες με Προσαρμοσμένα Μεγέθη**

Ίσως χρειαστεί να λάβετε μια εικόνα συγκεκριμένου μεγέθους. Χρησιμοποιώντας μια υπερφόρτωση της [getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#getImage), μπορείτε να μετατρέψετε μια διαφάνεια σε εικόνα με συγκεκριμένες διαστάσεις (πλάτος και ύψος).

Αυτό το δείγμα κώδικα δείχνει πώς να το κάνετε:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Μετατρέψτε την πρώτη διαφάνεια στην παρουσίαση σε bitmap με το καθορισμένο μέγεθος.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // Αποθηκεύστε την εικόνα στη μορφή JPEG.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Μετατροπή Διαφανειών με Σημειώσεις και Σχόλια σε Εικόνες**

Ορισμένες διαφάνειες μπορεί να περιέχουν σημειώσεις και σχόλια.

Το Aspose.Slides παρέχει δύο κλάσεις —[TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/) και [RenderingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/renderingoptions/)—που σας επιτρέπουν να ελέγχετε τη μετατροπή των διαφανειών παρουσίασης σε εικόνες. Και οι δύο κλάσεις περιλαμβάνουν τη μέθοδο `setSlidesLayoutOptions`, η οποία σας επιτρέπει να διαμορφώσετε τη μετατροπή των σημειώσεων και σχολίων σε μια διαφάνεια κατά τη μετατροπή της σε εικόνα.

Με την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notescommentslayoutingoptions/), μπορείτε να καθορίσετε την προτιμώμενη θέση των σημειώσεων και σχολίων στην τελική εικόνα.

Αυτός ο κώδικας JavaScript δείχνει πώς να μετατρέψετε μια διαφάνεια με σημειώσεις και σχόλια:

```js
const scaleX = 2;
const scaleY = scaleX;

// Φορτώστε ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // Ορίστε τη θέση των σημειώσεων.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // Ορίστε τη θέση των σχολίων.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // Ορίστε το πλάτος της περιοχής σχολίων.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // Ορίστε το χρώμα της περιοχής σχολίων.

    // Δημιουργήστε τις επιλογές απόδοσης.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // Μετατρέψτε την πρώτη διαφάνεια της παρουσίασης σε εικόνα.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // Αποθηκεύστε την εικόνα στη μορφή GIF.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Σε οποιαδήποτε διαδικασία μετατροπής διαφάνειας σε εικόνα, η μέθοδος [setNotesPosition](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) δεν μπορεί να εφαρμόσει το `BottomFull` (για τον καθορισμό της θέσης των σημειώσεων) επειδή το κείμενο μιας σημείωσης μπορεί να είναι πολύ μεγάλο, καθιστώντας αδύνατη την προσαρμογή του στο καθορισμένο μέγεθος εικόνας.
{{% /alert %}} 

## **Μετατροπή Διαφανειών σε Εικόνες Χρησιμοποιώντας TIFF Options**

Η κλάση [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/) παρέχει μεγαλύτερο έλεγχο πάνω στην τελική εικόνα TIFF, επιτρέποντάς σας να ορίσετε παραμέτρους όπως μέγεθος, ανάλυση, παλέτα χρωμάτων και άλλα.

Αυτός ο κώδικας JavaScript δείχνει μια διαδικασία μετατροπής όπου χρησιμοποιούνται επιλογές TIFF για να παραχθεί μια ασπρόμαυρη εικόνα με ανάλυση 300 DPI και μέγεθος 2160 × 2800:

```js
// Φορτώστε ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Λάβετε την πρώτη διαφάνεια από την παρουσίαση.
    let slide = presentation.getSlides().get_Item(0);

    // Διαμορφώστε τις ρυθμίσεις της εξαγόμενης εικόνας TIFF.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Ορίστε το μέγεθος της εικόνας.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Ορίστε τη μορφή εικονοστοιχείων (μαύρο και άσπρο).
    tiffOptions.setDpiX(300);                                                          // Ορίστε την οριζόντια ανάλυση.
    tiffOptions.setDpiY(300);                                                          // Ορίστε την κάθετη ανάλυση.

    // Μετατρέψτε τη διαφάνεια σε εικόνα με τις καθορισμένες επιλογές.
    let image = slide.getImage(tiffOptions);
    try {
        // Αποθηκεύστε την εικόνα σε μορφή TIFF.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Η υποστήριξη TIFF δεν είναι εγγυημένη σε εκδόσεις πριν από το JDK 9.
{{% /alert %}} 

## **Μετατροπή Όλων των Διαφανειών σε Εικόνες**

Το Aspose.Slides σας επιτρέπει να μετατρέψετε όλες τις διαφάνειες μιας παρουσίασης σε εικόνες, μετατρέποντας κατά πρακτικό τρόπο ολόκληρη την παρουσίαση σε μια σειρά εικόνων.

Αυτό το δείγμα κώδικα δείχνει πώς να μετατρέψετε όλες τις διαφάνειες μιας παρουσίασης σε εικόνες με JavaScript:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Αποδώστε την παρουσίαση σε εικόνες διαφάνεια προς διαφάνεια.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // Χειρισμός κρυμμένων διαφανειών (μη απόδοση κρυμμένων διαφανειών).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // Μετατρέψτε τη διαφάνεια σε εικόνα.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // Αποθηκεύστε την εικόνα στη μορφή JPEG.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το Aspose.Slides τη δημιουργία εικόνων διαφανειών με κινούμενα σχέδια;**

Όχι, η μέθοδος `getImage` αποθηκεύει μόνο μια στατική εικόνα της διαφάνειας, χωρίς κινούμενα σχέδια.

**Μπορούν οι κρυμμένες διαφάνειες να εξάγονται ως εικόνες;**

Ναι, οι κρυμμένες διαφάνειες μπορούν να υποβληθούν σε επεξεργασία όπως οι κανονικές. Απλώς βεβαιωθείτε ότι περιλαμβάνονται στον βρόχο επεξεργασίας.

**Μπορούν οι εικόνες να αποθηκεύονται με σκιάσεις και εφέ;**

Ναι, το Aspose.Slides υποστηρίζει τη δημιουργία σκιών, διαφάνειας και άλλων γραφικών εφέ κατά την αποθήκευση των διαφανειών ως εικόνες.