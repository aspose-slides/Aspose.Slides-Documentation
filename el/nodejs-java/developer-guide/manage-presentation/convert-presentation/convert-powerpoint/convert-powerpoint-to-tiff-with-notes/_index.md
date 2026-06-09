---
title: Μετατροπή παρουσιάσεων PowerPoint σε TIFF με σημειώσεις σε JavaScript
linktitle: PowerPoint σε TIFF με σημειώσεις
type: docs
weight: 100
url: /el/nodejs-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε TIFF
- παρουσίαση σε TIFF
- διαφάνεια σε TIFF
- PPT σε TIFF
- PPTX σε TIFF
- αποθήκευση PPT ως TIFF
- αποθήκευση PPTX ως TIFF
- εξαγωγή PPT σε TIFF
- εξαγωγή PPTX σε TIFF
- PowerPoint με σημειώσεις
- παρουσίαση με σημειώσεις
- διαφάνεια με σημειώσεις
- PPT με σημειώσεις
- PPTX με σημειώσεις
- TIFF με σημειώσεις
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint σε TIFF με σημειώσεις σε JavaScript χρησιμοποιώντας το Aspose.Slides για Node.js. Μάθετε πώς να εξάγετε διαφάνειες με σημειώσεις παρουσιαστή αποδοτικά."
---
## **Εισαγωγή**

Το Aspose.Slides for Node.js via Java παρέχει μια απλή λύση για τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument (PPT, PPTX και ODP) με σημειώσεις σε μορφή TIFF. Αυτή η μορφή χρησιμοποιείται ευρέως για αποθήκευση εικόνων υψηλής ποιότητας, εκτύπωση και αρχειοθέτηση εγγράφων. Με το Aspose.Slides, μπορείτε όχι μόνο να εξάγετε ολόκληρες παρουσιάσεις με σημειώσεις παρουσιαστή, αλλά και να δημιουργήσετε μικρογραφίες διαφανειών στην προβολή Notes Slide. Η διαδικασία μετατροπής είναι απλή και αποδοτική, χρησιμοποιώντας τη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) για τη μετατροπή ολόκληρης της παρουσίασης σε σειρά εικόνων TIFF ενώ διατηρεί τις σημειώσεις και τη διάταξη.

## **Μετατροπή Παρουσίασης σε TIFF με Σημειώσεις**

Η αποθήκευση μιας παρουσίασης PowerPoint ή OpenDocument σε TIFF με σημειώσεις χρησιμοποιώντας το Aspose.Slides for Node.js via Java περιλαμβάνει τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντίγραφο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/): Φορτώστε ένα αρχείο PowerPoint ή OpenDocument.  
2. Διαμορφώστε τις επιλογές διάταξης εξόδου: Χρησιμοποιήστε την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notescommentslayoutingoptions/) για να ορίσετε πώς πρέπει να εμφανίζονται οι σημειώσεις και τα σχόλια.  
3. Αποθηκεύστε την παρουσίαση σε TIFF: Με 전달 τις διαμορφωμένες επιλογές στη μέθοδο [save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save).

Ας πούμε ότι έχουμε το αρχείο "speaker_notes.pptx" με την ακόλουθη διαφάνεια:

![Η διαφάνεια της παρουσίασης με σημειώσεις παρουσιαστή](slide_with_notes.png)

Το παρακάτω τμήμα κώδικα δείχνει πώς να μετατρέψετε την παρουσίαση σε εικόνα TIFF στην προβολή Notes Slide χρησιμοποιώντας τη μέθοδο [setSlidesLayoutOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```js
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // Εμφάνιση των σημειώσεων κάτω από τη διαφάνεια.

    // Διαμόρφωση των επιλογών TIFF με διάταξη σημειώσεων.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Αποθήκευση της παρουσίασης σε TIFF με τις σημειώσεις παρουσιαστή.
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η εικόνα TIFF με σημειώσεις παρουσιαστή](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Δείτε το δωρεάν μετατροπέα PowerPoint σε αφίσα της Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/el/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω τη θέση της περιοχής σημειώσεων στο αποτέλεσμα TIFF;**

Ναι. Χρησιμοποιήστε τις [ρυθμίσεις διάταξης σημειώσεων](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) για να επιλέξετε μεταξύ επιλογών όπως `None`, `BottomTruncated` ή `BottomFull`, οι οποίες αντίστοιχα κρύβουν τις σημειώσεις, τις προσαρμόζουν σε μία σελίδα ή επιτρέπουν τη ροή τους σε επιπλέον σελίδες.

**Πώς μπορώ να μειώσω το μέγεθος ενός αρχείου TIFF με σημειώσεις χωρίς ορατή απώλεια ποιότητας;**

Επιλέξτε μια [αποδοτική συμπίεση](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/) (π.χ. `LZW` ή `RLE`), ορίστε ένα λογικό DPI και, αν είναι αποδεκτό, χρησιμοποιήστε χαμηλότερο [μορφό εικονοστοιχείου](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/setpixelformat/) (όπως 8 bpp ή 1 bpp για μονόχρωμη). Η ελαφρά μείωση των [διαστάσεων εικόνας](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/setimagesize/) μπορεί επίσης να βοηθήσει χωρίς να επηρεάσει αισθητά την αναγνωσιμότητα.

**Επηρεάζει η γραμματοσειρά στις σημειώσεις το αποτέλεσμα αν οι αρχικές γραμματοσειρές λείπουν από το σύστημα;**

Ναι. Η απουσία γραμματοσειρών ενεργοποιεί την [αντικατάσταση](/slides/el/nodejs-java/font-selection-sequence/), η οποία μπορεί να αλλάξει τις μετρικές του κειμένου και την εμφάνισή του. Για να το αποφύγετε, [παρέχετε τις απαιτούμενες γραμματοσειρές](/slides/el/nodejs-java/custom-font/) ή ορίστε μια προεπιλεγμένη [εφεδρική γραμματοσειρά](/slides/el/nodejs-java/fallback-font/) ώστε να χρησιμοποιηθούν οι προτιμώμενες γραμματοσειρές.