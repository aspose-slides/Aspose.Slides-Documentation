---
title: Μετατροπή Παρουσιάσεων PowerPoint σε TIFF με C++
titlelink: PowerPoint σε TIFF
type: docs
weight: 90
url: /el/cpp/convert-powerpoint-to-tiff/
keywords:
- μετατροπή PowerPoint
- μετατροπή OpenDocument
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
- C++
- Aspose.Slides
description: "Μάθετε πώς να μετατρέπετε εύκολα παρουσιάσεις PowerPoint (PPT, PPTX) σε εικόνες TIFF υψηλής ποιότητας χρησιμοποιώντας το Aspose.Slides για C++, με παραδείγματα κώδικα."
---
## **Εισαγωγή**

Το TIFF (Tagged Image File Format) είναι μια ευρέως χρησιμοποιούμενη, χωρίς απώλειες μορφή ράστερ εικόνας που είναι γνωστή για την εξαιρετική της ποιότητα και τη λεπτομερή διατήρηση των γραφικών. Σχεδιαστές, φωτογράφοι και γραφίστες επιλέγουν συχνά το TIFF για να διατηρούν τις στρώσεις, την ακρίβεια των χρωμάτων και τις αρχικές ρυθμίσεις στις εικόνες τους.

Με τη χρήση του Aspose.Slides, μπορείτε με ευκολία να μετατρέψετε τις διαφάνειες PowerPoint (PPT, PPTX) και OpenDocument (ODP) απευθείας σε εικόνες TIFF υψηλής ποιότητας, διασφαλίζοντας ότι οι παρουσιάσεις σας διατηρούν τη μέγιστη οπτική ακεραιότητα.

## **Μετατροπή Παρουσίασης σε TIFF**

Χρησιμοποιώντας τη μέθοδο [Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) που παρέχεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) , μπορείτε γρήγορα να μετατρέψετε ολόκληρη μια παρουσίαση PowerPoint σε TIFF. Οι προκύπτουσες εικόνες TIFF αντιστοιχούν στο προεπιλεγμένο μέγεθος διαφάνειας.

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP, κ.λπ.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Αποθηκεύστε την παρουσίαση ως TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Μετατροπή Παρουσίασης σε Ασπρόμαυρο TIFF**

Η μέθοδος [set_BwConversionMode](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) στην κλάση [TiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/) σάς επιτρέπει να καθορίσετε τον αλγόριθμο που θα χρησιμοποιηθεί κατά τη μετατροπή μιας έγχρωμης διαφάνειας ή εικόνας σε ασπρόμαυρο TIFF. Σημειώστε ότι αυτή η ρύθμιση ισχύει μόνο όταν η μέθοδος [set_CompressionType](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) έχει οριστεί σε `CCITT4` ή `CCITT3`.

Ας υποθέσουμε ότι έχουμε ένα αρχείο "sample.pptx" με την παρακάτω διαφάνεια:

![A presentation slide](slide_black_and_white.png)

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε την έγχρωμη διαφάνεια σε ασπρόμαυρο TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/BlackWhiteConversionMode.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Το αποτέλεσμα:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Μετατροπή Παρουσίασης σε TIFF με Προσαρμοσμένο Μέγεθος**

Εάν χρειάζεστε μια εικόνα TIFF με συγκεκριμένες διαστάσεις, μπορείτε να ορίσετε τις επιθυμητές τιμές χρησιμοποιώντας τις μεθόδους που διατίθενται στην κλάση [TiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/). Για παράδειγμα, η μέθοδος [set_ImageSize](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_imagesize/) σας επιτρέπει να ορίσετε το μέγεθος της προκύπτουσας εικόνας.

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε εικόνες TIFF με προσαρμοσμένο μέγεθος:

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP, κ.λπ.).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Ορίστε τον τύπο συμπίεσης.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Τύποι συμπίεσης:
    Default - Καθορίζει το προεπιλεγμένο σχήμα συμπίεσης (LZW).
    None - Καθορίζει χωρίς συμπίεση.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// Το βάθος εξαρτάται από τον τύπο συμπίεσης και δεν μπορεί να οριστεί χειροκίνητα.

// Ορίστε το DPI της εικόνας.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Ορίστε το μέγεθος της εικόνας.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Αποθηκεύστε την παρουσίαση ως TIFF με το καθορισμένο μέγεθος.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Μετατροπή Παρουσίασης σε TIFF με Προσαρμοσμένη Μορφή Πίξελ Εικόνας**

Χρησιμοποιώντας τη μέθοδο [set_PixelFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) από την κλάση [TiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/) , μπορείτε να καθορίσετε την προτιμώμενη μορφή πίξελ για την προκύπτουσα εικόνα TIFF.

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε εικόνα TIFF με προσαρμοσμένη μορφή πίξελ:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP, κ.λπ.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
Το ImagePixelFormat περιέχει τις παρακάτω τιμές (όπως δηλώνεται στην τεκμηρίωση):
    Format1bppIndexed - 1 bit ανά pixel, με ευρετήριο.
    Format4bppIndexed - 4 bits ανά pixel, με ευρετήριο.
    Format8bppIndexed - 8 bits ανά pixel, με ευρετήριο.
    Format24bppRgb    - 24 bits ανά pixel, RGB.
    Format32bppArgb   - 32 bits ανά pixel, ARGB.
*/

// Αποθηκεύστε την παρουσίαση ως TIFF με το καθορισμένο μέγεθος εικόνας.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}

Δείτε τον ΔΩΡΕΑΝ μετατροπέα PowerPoint σε Αφίσα της Aspose.

{{% /alert %}}

## **Συχνές Ερωτήσεις**

### Μπορώ να μετατρέψω μια μεμονωμένη διαφάνεια αντί για ολόκληρη παρουσίαση PowerPoint σε TIFF;

Ναι. Το Aspose.Slides σάς επιτρέπει να μετατρέψετε μεμονωμένες διαφάνειες από παρουσιάσεις PowerPoint και OpenDocument σε εικόνες TIFF ξεχωριστά.

### Υπάρχει κάποιο όριο στον αριθμό των διαφανειών κατά τη μετατροπή μιας παρουσίασης σε TIFF;

Όχι, το Aspose.Slides δεν επιβάλλει περιορισμούς στον αριθμό των διαφανειών. Μπορείτε να μετατρέψετε παρουσιάσεις οποιουδήποτε μεγέθους σε μορφή TIFF.

### Διατηρούνται οι κινήσεις και τα εφέ μετάβασης του PowerPoint όταν μετατρέπονται οι διαφάνειες σε TIFF;

Όχι, το TIFF είναι μια στατική μορφή εικόνας. Συνεπώς, οι κινήσεις και τα εφέ μετάβασης δεν διατηρούνται· εξάγονται μόνο στατικές στιγμές των διαφανειών.