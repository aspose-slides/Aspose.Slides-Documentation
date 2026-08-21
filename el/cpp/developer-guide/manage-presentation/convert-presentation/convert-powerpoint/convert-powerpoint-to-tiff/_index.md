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

Το TIFF (**Tagged Image File Format**) είναι ένα ευρέως χρησιμοποιούμενο, χωρίς απώλειες μορφότυπο ραστερ εικόνας, γνωστό για την εξαίρετη ποιότητά του και τη λεπτομερή διατήρηση των γραφικών. Σχεδιαστές, φωτογράφοι και εκδότες επιφάνειας εργασίας συχνά επιλέγουν το TIFF για να διατηρήσουν τις στρώσεις, την ακρίβεια χρώματος και τις αρχικές ρυθμίσεις στις εικόνες τους.

Με το Aspose.Slides, μπορείτε άψογα να μετατρέψετε τις διαφάνειες PowerPoint (PPT, PPTX) και OpenDocument (ODP) απευθείας σε εικόνες TIFF υψηλής ποιότητας, διασφαλίζοντας ότι οι παρουσιάσεις σας διατηρούν τη μέγιστη οπτική πιστότητα.

## **Μετατροπή Παρουσίασης σε TIFF**

Χρησιμοποιώντας τη μέθοδο [Αποθήκευση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) που παρέχεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/), μπορείτε γρήγορα να μετατρέψετε ολόκληρη μια παρουσίαση PowerPoint σε TIFF. Οι προκύπτουσες εικόνες TIFF αντιστοιχούν στο προεπιλεγμένο μέγεθος διαφάνειας.

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP κλπ).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Αποθηκεύστε την παρουσίαση ως TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Μετατροπή Παρουσίασης σε Μαύρο-Λευκό TIFF**

Η μέθοδος [set_BwConversionMode](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) στην κλάση [TiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/) σας επιτρέπει να καθορίσετε τον αλγόριθμο που χρησιμοποιείται κατά τη μετατροπή μιας έγχρωμης διαφάνειας ή εικόνας σε μαύρο-λευκό TIFF. Σημειώστε ότι αυτή η ρύθμιση εφαρμόζεται μόνο όταν η μέθοδος [set_CompressionType](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) ορίζεται σε `CCITT4` ή `CCITT3`.

{{% alert color="info" title="Σημείωση" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) είναι μια ρύθμιση επιπέδου εξαγωγής που επιλέγει αλγόριθμο μετατροπής pixel για ολόκληρη την εικόνα TIFF. Για να ορίσετε πώς θα εμφανίζεται ένα συγκεκριμένο σχήμα όταν είναι ενεργή η λειτουργία μαύρο-λευκού, χρησιμοποιήστε [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/set_blackwhitemode/). Δείτε το [Έλεγχος Μαύρο-Λευκής Απόδοσης για Σχήματα](/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) για παραδείγματα.
{{% /alert %}}

Ας υποθέσουμε ότι έχουμε ένα αρχείο "sample.pptx" με την παρακάτω διαφάνεια:

![Διαφάνεια παρουσίασης](slide_black_and_white.png)

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε τη χρωματιστή διαφάνεια σε μαύρο-λευκό TIFF:

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

![Μαύρο-Λευκό TIFF](TIFF_black_and_white.png)

## **Μετατροπή Παρουσίασης σε TIFF με Προσαρμοσμένο Μέγεθος**

Αν χρειάζεστε εικόνα TIFF με συγκεκριμένες διαστάσεις, μπορείτε να ορίσετε τις επιθυμητές τιμές χρησιμοποιώντας τις μεθόδους που διατίθενται στην [TiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/). Για παράδειγμα, η μέθοδος [set_ImageSize](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_imagesize/) σας επιτρέπει να καθορίσετε το μέγεθος της προκύπτουσας εικόνας.

Αυτός ο κώδικας C++ δείχνει πώς να μεταφέρετε μια παρουσίαση PowerPoint σε εικόνες TIFF με προσαρμοσμένο μέγεθος:

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

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP κλπ).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Ορίστε τον τύπο συμπίεσης.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Τύποι συμπίεσης:
    Default - Καθορίζει το προεπιλεγμένο σχήμα συμπίεσης (LZW).
    None - Καθορίζει ότι δεν υπάρχει συμπίεση.
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

## **Μετατροπή Παρουσίασης σε TIFF με Προσαρμοσμένη Μορφή Pixel Εικόνας**

Χρησιμοποιώντας τη μέθοδο [set_PixelFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) από την κλάση [TiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/), μπορείτε να καθορίσετε την προτιμώμενη μορφή pixel για την προκύπτουσα εικόνα TIFF.

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε εικόνα TIFF με προσαρμοσμένη μορφή pixel:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP κλπ).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
Το ImagePixelFormat περιέχει τις ακόλουθες τιμές (όπως αναφέρεται στην τεκμηρίωση):
    Format1bppIndexed - 1 bit ανά pixel, ευρετημένο.
    Format4bppIndexed - 4 bits ανά pixel, ευρετημένο.
    Format8bppIndexed - 8 bits ανά pixel, ευρετημένο.
    Format24bppRgb    - 24 bits ανά pixel, RGB.
    Format32bppArgb   - 32 bits ανά pixel, ARGB.
*/

// Αποθηκεύστε την παρουσίαση ως TIFF με το καθορισμένο μέγεθος εικόνας.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Συμβουλή" color="info" %}}
Δείτε τον [ΔΩΡΕΑΝ μετατροπέα PowerPoint σε Αφίσα του Aspose](https://products.aspose.app/slides/el/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω μια μεμονωμένη διαφάνεια αντί για ολόκληρη παρουσίαση PowerPoint σε TIFF;**

Ναι. Το Aspose.Slides σας επιτρέπει να μετατρέψετε μεμονωμένες διαφάνειες από παρουσιάσεις PowerPoint και OpenDocument σε εικόνες TIFF ξεχωριστά.

**Υπάρχει κάποιο όριο στον αριθμό των διαφανειών κατά τη μετατροπή μιας παρουσίασης σε TIFF;**

Όχι, το Aspose.Slides δεν επιβάλλει περιορισμούς στον αριθμό των διαφανειών. Μπορείτε να μετατρέψετε παρουσιάσεις οποιουδήποτε μεγέθους σε μορφή TIFF.

**Διατηρούνται οι κινήσεις και τα εφέ μετάβασης του PowerPoint κατά τη μετατροπή των διαφανειών σε TIFF;**

Όχι, το TIFF είναι μορφότυπο στατικής εικόνας. Συνεπώς, οι κινήσεις και τα εφέ μετάβασης δεν διατηρούνται· εξάγονται μόνο στατικά στιγμιότυπα των διαφανειών.