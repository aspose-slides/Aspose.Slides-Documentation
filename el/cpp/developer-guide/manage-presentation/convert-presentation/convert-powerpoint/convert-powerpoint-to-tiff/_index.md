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

Το TIFF (**Tagged Image File Format**) είναι μια ευρέως χρησιμοποιούμενη, χωρίς απώλειες μορφή raster εικόνας που είναι γνωστή για την εξαιρετική ποιότητα και την λεπτομερή διατήρηση των γραφικών. Σχεδιαστές, φωτογράφοι και εκδότες επιφάνειας εργασίας συχνά επιλέγουν το TIFF για να διατηρούν τα στρώματα, την ακρίβεια των χρωμάτων και τις αρχικές ρυθμίσεις στις εικόνες τους.

Χρησιμοποιώντας το Aspose.Slides, μπορείτε εύκολα να μετατρέψετε τις διαφάνειες PowerPoint (PPT, PPTX) και τις διαφάνειες OpenDocument (ODP) απευθείας σε εικόνες TIFF υψηλής ποιότητας, διασφαλίζοντας ότι οι παρουσιάσεις σας διατηρούν τη μέγιστη οπτική πιστότητα.

## **Μετατροπή Παρουσίασης σε TIFF**

Χρησιμοποιώντας τη μέθοδο [Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) που παρέχεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/), μπορείτε γρήγορα να μετατρέψετε ολόκληρη μια παρουσίαση PowerPoint σε TIFF. Οι παραγόμενες εικόνες TIFF αντιστοιχούν στο προεπιλεγμένο μέγεθος διαφάνειας.

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει αρχείο παρουσίασης (PPT, PPTX, ODP κλπ).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Αποθήκευση της παρουσίασης ως TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Μετατροπή Παρουσίασης σε Μαύρο-Άσπρο TIFF**

Η μέθοδος [set_BwConversionMode](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) στην κλάση [TiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/) σας επιτρέπει να καθορίσετε τον αλγόριθμο που χρησιμοποιείται κατά τη μετατροπή μιας έγχρωμης διαφάνειας ή εικόνας σε μαύρο-άσπρο TIFF. Σημειώστε ότι αυτή η ρύθμιση εφαρμόζεται μόνο όταν η μέθοδος [set_CompressionType](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) ορίζεται σε `CCITT4` ή `CCITT3`.

{{% alert color="info" title="Σημείωση" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) είναι μια ρύθμιση επιπέδου εξαγωγής που επιλέγει αλγόριθμο μετατροπής εικονοστοιχείου για ολόκληρη την εικόνα TIFF. Για να ορίσετε πώς πρέπει να εμφανίζεται ένα μεμονωμένο σχήμα όταν είναι ενεργή η λειτουργία μαύρο‑άσπρο, χρησιμοποιήστε [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/set_blackwhitemode/). Δείτε το [Έλεγχος Μαύρου-Άσπρου Rendering για Σχήματα](/slides/el/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) για παραδείγματα.
{{% /alert %}}

Ας υποθέσουμε ότι έχουμε ένα αρχείο "sample.pptx" με την ακόλουθη διαφάνεια:

![A presentation slide](slide_black_and_white.png)

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε την έγχρωμη διαφάνεια σε μαύρο-άσπρο TIFF:

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

![Μαύρο‑Άσπρο TIFF](TIFF_black_and_white.png)

## **Μετατροπή Παρουσίασης σε TIFF με Προσαρμοσμένο Μέγεθος**

Εάν χρειάζεστε μια εικόνα TIFF με συγκεκριμένες διαστάσεις, μπορείτε να ορίσετε τις επιθυμητές τιμές χρησιμοποιώντας τις μεθόδους που διαθέτει η κλάση [TiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/). Για παράδειγμα, η μέθοδος [set_ImageSize](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_imagesize/) σας επιτρέπει να καθορίσετε το μέγεθος της παραγόμενης εικόνας.

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

// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει αρχείο παρουσίασης (PPT, PPTX, ODP κλπ).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Ορισμός τύπου συμπίεσης.
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

// Η βάθος εξαρτάται από τον τύπο συμπίεσης και δεν μπορεί να ρυθμιστεί χειροκίνητα.

// Ορισμός DPI εικόνας.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Ορισμός μεγέθους εικόνας.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Αποθήκευση της παρουσίασης ως TIFF με το καθορισμένο μέγεθος.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Μετατροπή Παρουσίασης σε TIFF με Προσαρμοσμένη Μορφή Πιξελ Εικόνας**

Χρησιμοποιώντας τη μέθοδο [set_PixelFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) από την κλάση [TiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/), μπορείτε να καθορίσετε την προτιμώμενη μορφή πιξελ για την παραγόμενη εικόνα TIFF.

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε εικόνα TIFF με προσαρμοσμένη μορφή πιξελ:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει αρχείο παρουσίασης (PPT, PPTX, ODP κλπ).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
Το ImagePixelFormat περιέχει τις ακόλουθες τιμές (όπως αναφέρεται στην τεκμηρίωση):
    Format1bppIndexed - 1 δυαδικό ανά εικονοστοιχείο, με ευρετήριο.
    Format4bppIndexed - 4 δυαδικά ανά εικονοστοιχείο, με ευρετήριο.
    Format8bppIndexed - 8 δυαδικά ανά εικονοστοιχείο, με ευρετήριο.
    Format24bppRgb    - 24 δυαδικά ανά εικονοστοιχείο, RGB.
    Format32bppArgb   - 32 δυαδικά ανά εικονοστοιχείο, ARGB.
*/

// Αποθήκευση της παρουσίασης ως TIFF με το καθορισμένο μέγεθος εικόνας.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Συμβουλή" color="info" %}}
Δείτε τον [ΔΩΡΕΑΝ μετατροπέα PowerPoint σε Αφίσα](https://products.aspose.app/slides/el/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω μια μεμονωμένη διαφάνεια αντί για ολόκληρη παρουσίαση PowerPoint σε TIFF;**

Ναι. Το Aspose.Slides σας επιτρέπει να μετατρέπετε μεμονωμένες διαφάνειες από παρουσιάσεις PowerPoint και OpenDocument σε εικόνες TIFF ξεχωριστά.

**Υπάρχει κάποιο όριο στον αριθμό των διαφανειών κατά τη μετατροπή μιας παρουσίασης σε TIFF;**

Όχι, το Aspose.Slides δεν επιβάλλει κανέναν περιορισμό στον αριθμό των διαφανειών. Μπορείτε να μετατρέψετε παρουσιάσεις οποιουδήποτε μεγέθους σε μορφή TIFF.

**Διατηρούνται τα εφέ κίνησης και μετάβασης του PowerPoint κατά τη μετατροπή των διαφανειών σε TIFF;**

Όχι, το TIFF είναι μορφή στατικής εικόνας. Συνεπώς, τα εφέ κίνησης και μετάβασης δεν διατηρούνται· εξάγονται μόνο στατικές φωτογραφίες των διαφανειών.