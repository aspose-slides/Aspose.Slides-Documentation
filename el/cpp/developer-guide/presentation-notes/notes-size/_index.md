---
title: "Αλλαγή Μεγέθους και Προσανατολισμού Σελίδας Σημειώσεων σε C++"
linktitle: "Μέγεθος Σελίδας Σημειώσεων"
type: docs
weight: 10
url: /el/cpp/notes-size/
keywords:
- "μέγεθος σελίδας σημειώσεων"
- "προσανατολισμός σημειώσεων"
- "οριζόντιες σημειώσεις"
- "κατακόρυφες σημειώσεις"
- "μέγεθος φυλλαδίου"
- "PowerPoint"
- "παρουσίαση"
- "PPT"
- "PPTX"
- "C++"
- "Aspose.Slides"
description: "Διαβάστε και αλλάξτε τις διαστάσεις της σελίδας σημειώσεων στο Aspose.Slides για C++, αλλάξτε τον προσανατολισμό, επαληθεύστε τα αποθηκευμένα μεγέθη και εξάγετε σημειώσεις ή φυλλάδια σε PDF και εικόνες."
---
## **Επισκόπηση**

Χρησιμοποιήστε [Presentation::get_NotesSize](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_notessize/) για να αποκτήσετε πρόσβαση στις ρυθμίσεις της σελίδας σημειώσεων της παρουσίασης. Επιστρέφει ένα αντικείμενο [INotesSize](https://reference.aspose.com/slides/el/cpp/aspose.slides/inotessize/) του οποίου η μέθοδος [set_Size](https://reference.aspose.com/slides/el/cpp/aspose.slides/inotessize/set_size/) ορίζει τις διαστάσεις. Παρόλο που το αντικείμενο ρυθμίσεων σημειώσεων δεν μπορεί να αντικατασταθεί, μπορείτε να αλλάξετε το μέγεθός του.

Το πλάτος και το ύψος καθορίζονται σε **points**, με 72 points ανά ίντσα. Για παράδειγμα, 900 × 600 points είναι 12,5 × 8⅓ ίντσες. Αυτές οι ρυθμίσεις εφαρμόζονται στην παρουσίαση, όχι σε σημειώσεις μεμονωμένης διαφάνειας.

| Ρύθμιση | Σκοπός |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_notessize/) | Ελέγχει τις διαστάσεις της σελίδας σημειώσεων και τις διαστάσεις της σελίδας που χρησιμοποιούνται για εξαγωγή φύλλων υπομνήματος. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_slidesize/) | Ελέγχει τις κανονικές διαστάσεις των διαφανειών της παρουσίασης μέσω του [ISlideSize](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidesize/). |

Η αλλαγή της μιας ρύθμισης δεν αλλάζει αυτόματα την άλλη. Η αλλαγή του προσανατολισμού της σελίδας σημειώσεων δεν περιστρέφει επίσης τις κανονικές διαφάνειες. Δείτε τη σελίδα [Μέγεθος διαφάνειας](/slides/el/cpp/slide-size/) για αλλαγή του μεγέθους των κανονικών διαφανειών.

Τα παραδείγματα παρακάτω χρησιμοποιούν ένα υπάρχον `sample.pptx`. Για τα παραδείγματα εξαγωγής, χρησιμοποιήστε μια παρουσίαση με τουλάχιστον μία διαφάνεια που περιέχει σημειώσεις ομιλητή. Κάθε παράδειγμα μπορεί να εκτελεστεί ανεξάρτητα.

## **Ανάγνωση του Μεγέθους και του Προσανατολισμού της Σελίδας Σημειώσεων**

Διαβάστε το πλάτος και το ύψος και συγκρίνετε τα για να προσδιορίσετε τον προσανατολισμό: μια ευρύτερη σελίδα είναι οριζόντια, μια ψηλότερη σελίδα είναι κάθετη, και ίσες διαστάσεις περιγράφουν τετράγωνη σελίδα. Αυτό το παράδειγμα εκτυπώνει τις πραγματικές διαστάσεις σε points, χωρίς να υποθέτει τυπικό μέγεθος χαρτιού.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Αλλαγή σε Οριζόντια Κατεύθυνση χωρίς Αλλαγή του Μεγέθους του Χαρτιού**

Για να αλλάξετε μόνο τον προσανατολισμό, ανταλλάξτε το τρέχον πλάτος και ύψος. Αυτό διατηρεί τα μήκη και των δύο πλευρών, συμπεριλαμβανομένων εκείνων ενός προσαρμοσμένου μεγέθους χαρτιού. Η παρακάτω συνθήκη αποτρέπει το να μετατραπεί ξανά μια ήδη οριζόντια σελίδα σε κάθετη και αφήνει αμετάβλητη μια τετράγωνη σελίδα.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

Για κάθετη κατεύθυνση, χρησιμοποιήστε την ίδια εκχώρηση όταν `size.get_Width() > size.get_Height()`. Μην αντικαταστήσετε διαστάσεις A4 ή Letter εκτός εάν θέλετε επίσης να αλλάξετε το μέγεθος του χαρτιού.

## **Ορισμός και Επαλήθευση Προσαρμοσμένου Μεγέθους Σελίδας Σημειώσεων**

Ορίστε και τις δύο διαστάσεις ταυτόχρονα, στη συνέχεια χρησιμοποιήστε [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) για να αποθηκεύσετε την παρουσίαση. Αυτό το παράδειγμα ορίζει μια οριζόντια σελίδα 900 × 600 points, την αποθηκεύει ως PPTX και ανοίγει ξανά το αποθηκευμένο αρχείο για να ελέγξει τις αποθηκευμένες τιμές. Η σύγκριση επιτρέπει ανοχή 0,01 point για τιμές κινητής υποδιαστολής· δεν αποτελεί εγγύηση ακριβείας για κάθε μορφή αρχείου.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

Το αναμενόμενο αποτέλεσμα είναι `900 x 600 points` και `Size preserved: True`. Ο έλεγχος μιας νεόανοιξης παρουσίασης επαληθεύει το αποθηκευμένο αρχείο, όχι μόνο τις ρυθμίσεις στη μνήμη.

## **Εξαγωγή Σημειώσεων και Φύλλων Υπομνήματος**

Οι διαστάσεις της σελίδας ορίζουν την διαθέσιμη περιοχή για διατάξεις σημειώσεων ή φύλλων υπομνήματος. Δεν ενεργοποιούν αυτές τις διατάξεις από μόνες τους: διαμορφώστε επίσης τις επιλογές εξαγωγής. Η κανονική εξαγωγή διαφανειών συνεχίζει να χρησιμοποιεί τις διαστάσεις της διαφάνειας.

### **Εξαγωγή Σημειώσεων σε PDF και PNG**

Αναθέστε [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/notescommentslayoutingoptions/) στο [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) για να συμπεριλάβετε σημειώσεις στο PDF. Αυτό το παράδειγμα επίσης αποδίδει την πρώτη διαφάνεια με σημειώσεις σε PNG χρησιμοποιώντας το [Slide::GetImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/slide/getimage/) και τις [RenderingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/renderingoptions/).

Η λειτουργία [BottomTruncated](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/notespositions/) διατηρεί τις σημειώσεις σε μία σελίδα· οι σημειώσεις που δεν χωράνε μπορούν να περικοπούν. Το PDF χρησιμοποιεί σελίδες 900 × 600 points. Στην κλίμακα εικόνας 1 × 1 που χρησιμοποιείται παρακάτω, το PNG είναι 900 × 600 pixel. Τα points περιγράφουν τη γεωμετρία της σελίδας· τα pixel περιγράφουν την εξαγόμενη ραστερική εικόνα, της οποίας οι διαστάσεις εξαρτώνται επίσης από την κλίμακα απόδοσης.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

Για εξαγωγή PDF με μακρές σημειώσεις, η λειτουργία [BottomFull](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/notespositions/) επιτρέπει πρόσθετες σελίδες όπως χρειάζεται. Μην χρησιμοποιήσετε αυτή τη λειτουργία με την κλήση εικόνας μιας μόνο διαφάνειας παραπάνω, η οποία δεν την υποστηρίζει. Μετά την αλλαγή μεγέθους, ελέγξτε την έξοδο για περικομμένες σημειώσεις και τη θέση των υπαρκτών αντικειμένων notes‑master· η αλλαγή μόνο των διαστάσεων της σελίδας δεν πρέπει να θεωρείται εγγύηση ότι όλο το περιεχόμενο θα χωρέσει. Δείτε την ενότητα [Convert PowerPoint to PDF with Notes](/slides/el/cpp/convert-powerpoint-to-pdf-with-notes/) για περισσότερες πληροφορίες σχετικά με την εξαγωγή σημειώσεων.

### **Εξαγωγή Φύλλων Υπομνήματος σε PDF**

Χρησιμοποιήστε [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/handoutlayoutingoptions/) για πολλαπλές μικρογραφίες διαφανειών σε μία σελίδα. Το παρακάτω παράδειγμα ορίζει μια σελίδα 900 × 600 points και χρησιμοποιεί το [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/handouttype/) για να τοποθετήσει μέχρι τέσσερις διαφάνειες ανά σελίδα. Η προεπιλογή οριζόντιας διάταξης ελέγχει τη σειρά των διαφανειών· ο προσανατολισμός της σελίδας προέρχεται από το πλάτος και το ύψος της.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Η αλλαγή του μεγέθους της σελίδας αλλάζει την περιοχή που διατίθεται για το πλέγμα του φυλλαδίου χωρίς να αλλάζει τις διαστάσεις των πηγών διαφανειών. Για εικόνες φυλλαδίου, χρησιμοποιήστε το [Presentation::GetImages](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/getimages/) με τη διάταξη του φυλλαδίου, αντί για τη μέθοδο εικόνας μεμονωμένης διαφάνειας. Στο Aspose.Slides, η εξαγωγή φυλλαδίου σε επίπεδο παρουσίασης χρησιμοποιεί τις διαστάσεις της σελίδας σημειώσεων, ενώ η κλήση εικόνας μεμονωμένης διαφάνειας δεν παράγει τη σελίδα φυλλαδίου. Δείτε την ενότητα [Handout Mode](/slides/el/cpp/convert-powerpoint-in-handout-mode/) για επιλογές διάταξης.

## **Μέγεθος Σελίδας σε Προγράμματα Προβολής, Εξαγωγή και Εκτύπωση**

Διατηρήστε το αποθηκευμένο μέγεθος παρουσίασης, το εξαγόμενο μέγεθος σελίδας και το εκτυπωμένο μέγεθος χαρτιού ξεχωριστά:

- **Προγράμματα προβολής παρουσίασης:** Ένας προβολή μπορεί να εμφανίσει ή να εκτυπώσει σημειώσεις χρησιμοποιώντας τους δικούς του κανόνες διάταξης. Εάν μια άλλη εφαρμογή αποθηκεύσει το αρχείο, ανοίξτε το ξανά και ελέγξτε ξανά τις διαστάσεις· η μετατροπή μορφής εκείνης της εφαρμογής μπορεί να τις ομαλοποιήσει.
- **Μορφές εξαγωγής:** Τα παραδείγματα PDF σημειώσεων και φυλλαδίου παραπάνω χρησιμοποιούν τις διαμορφωμένες διαστάσεις σελίδας. Οι ραστερικές εικόνες χρησιμοποιούν ακέραιες διαστάσεις pixel και κλίμακα απόδοσης, έτσι οι κλασματικές τιμές points μπορούν να στρογγυλοποιηθούν στην έξοδο της εικόνας. Η εξαγωγή κανονικών διαφανειών δεν εφαρμόζει το μέγεθος σελίδας σημειώσεων.
- **Οδηγοί εκτυπωτών:** Η επιλογή χαρτιού, η αυτόματη περιστροφή και οι ρυθμίσεις προσαρμογής στη σελίδα μπορούν να αλλάξουν το φυσικό αποτέλεσμα χωρίς να αλλάξουν τις διαστάσεις που αποθηκεύονται στην παρουσίαση ή στο PDF. Για συγκεκριμένο μέγεθος χαρτιού, ταιριάξτε τις ρυθμίσεις του εκτυπωτή και ελέγξτε την προεπισκόπηση εκτύπωσης.

## **Συχνές ερωτήσεις**

**Μπορώ να ορίσω το μέγεθος σημειώσεων μόνο για μία διαφάνεια;**

Το μέγεθος σελίδας σημειώσεων είναι ρύθμιση σε επίπεδο παρουσίασης. Οι μεμονωμένες διαφάνειες μπορούν να έχουν διαφορετικό περιεχόμενο σημειώσεων, αλλά αυτή η ιδιότητα δεν παρέχει ξεχωριστό μέγεθος σελίδας για κάθε διαφάνεια.

**Γιατί η αλλαγή του προσανατολισμού των σημειώσεων δεν άλλαξε τις διαφάνειές μου;**

Οι σελίδες σημειώσεων και οι κανονικές διαφάνειες έχουν ανεξάρτητες διαστάσεις. Χρησιμοποιήστε τις ρυθμίσεις μεγέθους κανονικής διαφάνειας όταν θέλετε να αλλάξετε το μέγεθος των διαφανειών.

**Γιατί το αποθηκευμένο ή εκτυπωμένο αποτέλεσμα έχει διαφορετικό μέγεθος;**

Αρχικά ανοίξτε ξανά την αποθηκευμένη παρουσίαση και συγκρίνετε τις διαστάσεις των σημειώσεων της. Εάν αυτές έχουν αλλάξει, ελέγξτε αν η αποθήκευση ή η μετατροπή του αρχείου σε άλλη εφαρμογή άλλαξε τις ρυθμίσεις σελίδας. Εάν δεν άλλαξαν, ελέγξτε τη διάταξη εξαγωγής, την κλίμακα εικόνας, τις ρυθμίσεις του προγράμματος προβολής και την επιλογή χαρτιού του εκτυπωτή.