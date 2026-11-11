---
title: Μετατροπή παρουσιάσεων PowerPoint σε PDF με Σημειώσεις σε C++
linktitle: PowerPoint σε PDF με Σημειώσεις
type: docs
weight: 50
url: /el/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε PDF
- παρουσίαση σε PDF
- διαφάνεια σε PDF
- PPT σε PDF
- PPTX σε PDF
- αποθήκευση παρουσίασης ως PDF
- αποθήκευση PPT ως PDF
- αποθήκευση PPTX ως PDF
- εξαγωγή PPT σε PDF
- εξαγωγή PPTX σε PDF
- σημειώσεις ομιλητή
- PDF με σημειώσεις
- C++
- Aspose.Slides
description: "Μετατρέψτε μορφές PPT και PPTX σε PDF με σημειώσεις χρησιμοποιώντας το Aspose.Slides για C++. Διατηρήστε τις διατάξεις και τις σημειώσεις ομιλητή για επαγγελματικές παρουσιάσεις."
---
## **Επισκόπηση**

Σε αυτό το άρθρο, θα μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε μορφή PDF με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides. Αυτός ο οδηγός θα καλύψει τα απαραίτητα βήματα και θα παρέχει παραδείγματα κώδικα ώστε να ολοκληρώσετε αυτήν την εργασία αποδοτικά. Στο τέλος του άρθρου, θα μπορείτε:

- Να υλοποιήσετε τη διαδικασία μετατροπής για να μετατρέψετε διαφάνειες PowerPoint σε έγγραφα PDF διατηρώντας τις σημειώσεις ομιλητή.
- Να προσαρμόσετε το παραγόμενο PDF ώστε οι σημειώσεις ομιλητή να συμπεριλαμβάνονται και να μορφοποιούνται σύμφωνα με τις απαιτήσεις σας.

Για να ορίσετε τις διαστάσεις και τον προσανατολισμό της σελίδας σημειώσεων πριν από την εξαγωγή, δείτε [Notes Page Size](/slides/el/cpp/notes-size/).

## **Μετατροπή PowerPoint σε PDF με Σημειώσεις**

Η μέθοδος `Save` στην κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) μπορεί να χρησιμοποιηθεί για να μετατρέψετε μια παρουσίαση PPT ή PPTX σε PDF με σημειώσεις ομιλητή. Με το Aspose.Slides, απλώς φορτώνετε την παρουσίαση, ρυθμίζετε τις επιλογές διάταξης χρησιμοποιώντας την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/notescommentslayoutingoptions/) για να συμπεριλάβετε τις σημειώσεις ομιλητή και, στη συνέχεια, αποθηκεύετε το αρχείο ως PDF. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να μετατρέψετε ένα δείγμα παρουσίασης σε PDF σε προβολή Σημειώσεων Διαφάνειας.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configure PDF options for rendering speaker notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Απόδοση σημειώσεων ομιλητή κάτω από τη διαφάνεια.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Ίσως θελήσετε να δοκιμάσετε τον Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/el/conversion). 
{{% /alert %}}