---
title: Μετατροπή παρουσιάσεων PowerPoint σε TIFF με σημειώσεις σε C++
linktitle: PowerPoint σε TIFF με σημειώσεις
type: docs
weight: 100
url: /el/cpp/convert-powerpoint-to-tiff-with-notes/
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
- C++
- Aspose.Slides
description: Μετατρέψτε τις παρουσιάσεις PowerPoint σε TIFF με σημειώσεις χρησιμοποιώντας το Aspose.Slides για C++. Μάθετε πώς να εξάγετε διαφάνειες με σημειώσεις ομιλητή αποτελεσματικά.
---
## **Εισαγωγή**

Aspose.Slides for C++ παρέχει μια απλή λύση για τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument (PPT, PPTX και ODP) με σημειώσεις στη μορφή TIFF. Αυτή η μορφή χρησιμοποιείται ευρέως για αποθήκευση εικόνων υψηλής ποιότητας, εκτύπωση και αρχειοθέτηση εγγράφων. Με το Aspose.Slides, μπορείτε όχι μόνο να εξάγετε ολόκληρες παρουσιάσεις με σημειώσεις ομιλητή, αλλά και να δημιουργήσετε μικρογραφίες διαφανειών στην προβολή Notes Slide. Η διαδικασία μετατροπής είναι απλή και αποδοτική, χρησιμοποιώντας τη μέθοδο `Save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) για να μετασχηματίσει ολόκληρη την παρουσίαση σε σειρά εικόνων TIFF διατηρώντας τις σημειώσεις και τη διάταξη.

## **Μετατροπή παρουσίασης σε TIFF με σημειώσεις**

Η αποθήκευση μιας παρουσίασης PowerPoint ή OpenDocument σε TIFF με σημειώσεις χρησιμοποιώντας το Aspose.Slides for C++ περιλαμβάνει τα ακόλουθα βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/): Φορτώστε ένα αρχείο PowerPoint ή OpenDocument.  
1. Διαμορφώστε τις επιλογές διάταξης εξόδου: Χρησιμοποιήστε την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/notescommentslayoutingoptions/) για να καθορίσετε πώς θα εμφανίζονται οι σημειώσεις και τα σχόλια.  
1. Αποθηκεύστε την παρουσίαση σε TIFF: Περάστε τις διαμορφωμένες επιλογές στη μέθοδο [Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/).

Ας υποθέσουμε ότι έχουμε ένα αρχείο "speaker_notes.pptx" με την ακόλουθη διαφάνεια:

![Διαφάνεια παρουσίασης με σημειώσεις ομιλητή](slide_with_notes.png)

Το ακόλουθο απόσπασμα κώδικα δείχνει πώς να μετατρέψετε την παρουσίαση σε εικόνα TIFF στην προβολή Notes Slide χρησιμοποιώντας τη μέθοδο [set_SlidesLayoutOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Εμφάνιση των σημειώσεων κάτω από τη διαφάνεια.

// Διαμορφώστε τις επιλογές TIFF με την διάταξη σημειώσεων.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Αποθηκεύστε την παρουσίαση σε TIFF με τις σημειώσεις ομιλητή.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Το αποτέλεσμα:

![Η εικόνα TIFF με σημειώσεις ομιλητή](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Δείτε το Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/el/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

### Μπορώ να ελέγξω τη θέση της περιοχής σημειώσεων στο τελικό TIFF;

Ναι. Χρησιμοποιήστε τις [notes layout settings](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) για να επιλέξετε μεταξύ επιλογών όπως `None`, `BottomTruncated` ή `BottomFull`, που αντίστοιχα κρύβουν τις σημειώσεις, τις προσαρμόζουν σε μία σελίδα, ή επιτρέπουν την ροή τους σε επιπλέον σελίδες.

### Πώς μπορώ να μειώσω το μέγεθος ενός αρχείου TIFF με σημειώσεις χωρίς ορατή απώλεια ποιότητας;

Επιλέξτε μια [αποδοτική συμπίεση](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (π.χ., `LZW` ή `RLE`), ορίστε ένα λογικό DPI και, εάν είναι αποδεκτό, χρησιμοποιήστε χαμηλότερο [pixel format](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (όπως 8 bpp ή 1 bpp για μονόχρωμα). Η ελαφρά μείωση των [image dimensions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_imagesize/) μπορεί επίσης να βοηθήσει χωρίς να επηρεάσει αισθητά την αναγνωσιμότητα.

### Επηρεάζει η γραμματοσειρά στις σημειώσεις το αποτέλεσμα εάν οι αρχικές γραμματοσειρές λείπουν από το σύστημα;

Ναι. Η έλλειψη γραμματοσειρών ενεργοποιεί την [substitution](/slides/el/cpp/font-selection-sequence/), η οποία μπορεί να αλλάξει τις μετρικές κειμένου και την εμφάνιση. Για να το αποφύγετε, [παρέχετε τις απαιτούμενες γραμματοσειρές](/slides/el/cpp/custom-font/) ή ορίστε μια προεπιλεγμένη [fallback font](/slides/el/cpp/fallback-font/) ώστε να χρησιμοποιηθούν οι επιθυμητές γραμματοσειρές.