---
title: Μετατροπή Διαφανειών Παρουσίασης σε Εικόνες σε C++
linktitle: Διαφάνεια σε Εικόνα
type: docs
weight: 41
url: /el/cpp/convert-slide/
keywords:
- μετατροπή διαφάνειας
- εξαγωγή διαφάνειας
- διαφάνεια σε εικόνα
- αποθήκευση διαφάνειας ως εικόνα
- διαφάνεια σε EMF
- διαφάνεια σε PNG
- διαφάνεια σε JPEG
- διαφάνεια σε bitmap
- διαφάνεια σε TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες από παρουσιάσεις PPT, PPTX και ODP σε PNG, JPEG, GIF, TIFF, EMF και άλλες μορφές εικόνας σε C++ με το Aspose.Slides για C++."
---
## **Εισαγωγή**

Η Aspose.Slides για C++ μπορεί να αποδίδει μεμονωμένες διαφάνειες από παρουσιάσεις PowerPoint και OpenDocument ως PNG, JPEG, GIF, TIFF και άλλες μορφές εικόνας.

Για να μετατρέψετε μια διαφάνεια σε εικόνα, ακολουθήστε τα ακόλουθα βήματα:

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Επιλέξτε τη διαφάνεια που θέλετε να αποδώσετε.
3. Εάν είναι απαραίτητο, διαμορφώστε την απόδοση με την κλάση [RenderingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/renderingoptions/) ή [TiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/).
4. Καλέστε τη μέθοδο [ISlide::GetImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/getimage/). Επιστρέφει ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/).
5. Καλέστε τη μέθοδο [IImage::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/save/) και καθορίστε τη μορφή εξόδου με μια τιμή [ImageFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/imageformat/).

## **Μετατροπή μιας Διαφάνειας σε Εικόνα PNG**

Η πιο απλή μετατροπή χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις απόδοσης. Το προκύπτον αντικείμενο [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) μπορεί να υποβληθεί σε επεξεργασία στη μνήμη ή να αποθηκευτεί σε αρχείο.

Το παρακάτω παράδειγμα C++ αποδίδει την πρώτη διαφάνεια και την αποθηκεύει ως εικόνα PNG:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Μετατροπή Διαφανειών σε Εικόνες με Προσαρμοσμένα Μεγέθη**

Χρησιμοποιήστε την υπερφόρτωση της μεθόδου [ISlide::GetImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/getimage/) που δέχεται μια τιμή [Size](https://reference.aspose.com/slides/el/cpp/system.drawing/size/) για να αποδώσετε μια διαφάνεια με ακριβείς διαστάσεις σε εικονοστοιχεία.

Το παρακάτω παράδειγμα δημιουργεί μια εικόνα JPEG 1820 × 1040:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Μετατροπή Διαφανειών με Σημειώσεις και Σχόλια σε Εικόνες**

Από προεπιλογή, οι εικόνες των διαφανειών δεν περιλαμβάνουν σημειώσεις ή σχόλια. Αναθέστε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/notescommentslayoutingoptions/) στη μέθοδο [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) για να ελέγξετε πού εμφανίζονται οι σημειώσεις και τα σχόλια.

Το παρακάτω παράδειγμα τοποθετεί περικομμένες σημειώσεις κάτω από τη διαφάνεια και σχόλια στα δεξιά της:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Προειδοποίηση" color="warning" %}}
Για τη μετατροπή διαφάνειας‑σειράς σε εικόνα, μην ορίσετε τη μέθοδο [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) σε [BottomFull](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/notespositions/). Οι σημειώσεις μπορούν να περιέχουν περισσότερο κείμενο από ό,τι μπορεί να χωρέσει το σταθερό μέγεθος της εικόνας. Χρησιμοποιήστε αντί αυτού το [BottomTruncated](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Μετατροπή Διαφανειών σε Εικόνες Χρησιμοποιώντας τις Ρυθμίσεις TIFF**

Η κλάση [TiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/) σας επιτρέπει να ελέγξετε το μέγεθος, την ανάλυση και άλλες ιδιότητες της αποδομένης εικόνας TIFF.

Το παρακάτω παράδειγμα αποδίδει την πρώτη διαφάνεια ως εικόνα TIFF 2160 × 2880 με ανάλυση 300 DPI:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Μετατροπή Όλων των Διαφανειών σε Εικόνες**

Διατρέξτε τη συλλογή διαφανειών για να μετατρέψετε ολόκληρη την παρουσίαση σε σειρά εικόνων. Οι κρυμμένες διαφάνειες περιλαμβάνονται εκτός εάν τις παραλείψετε ρητά.

Το παρακάτω παράδειγμα αποδίδει κάθε διαφάνεια ως εικόνα JPEG με οριζόντιους και κάθετους συντελεστές κλίμακας 2:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Δημιουργία Εξόδου Enhanced Metafile**

Το Enhanced Metafile (EMF) είναι χρήσιμο όταν γραφικά βασισμένα σε διανύσματα πρέπει να ανταλλαχθούν με το Microsoft Office ή άλλες εφαρμογές των Windows που υποστηρίζουν μετααρχεία Windows. Σε αντίθεση με μια εικόνα βασισμένη σε εικονοστοιχεία, ένα EMF μπορεί να διατηρήσει τις ενέργειες σχεδίασης διανυσμάτων που κλιμακώνονται χωρίς την ίδια απώλεια ευκρίνειας. Ωστόσο, το EMF είναι κυρίως μια μορφή συμβατότητας για εφαρμογές με υποστήριξη μετααρχείων Windows, όχι μια καθολική μορφή ανταλλαγής. Επιπλέον, πολύπλοκο περιεχόμενο διαφάνειας, όπως εικόνες bitmap και ορισμένα εφέ, μπορεί να αποθηκευτεί ως στοιχεία rasterized μέσα στο δοχείο του διανυσματικού μετααρχείου.

### **Εξαγωγή μιας Διαφάνειας σε EMF**

Η μέθοδος [ISlide::WriteAsEmf](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/writeasemf/) γράφει ένα [ISlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/) σε ένα στόχο ροής σε μορφή EMF. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, επιλέγει την πρώτη διαφάνεια και τη γράφει σε ροή αρχείου EMF:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

Ο καλών έχει την ιδιοκτησία της ροής που περνιέται στη [ISlide::WriteAsEmf](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/writeasemf/) και πρέπει να την κλείσει ή να την αποδεσμεύσει. Η Aspose.Slides γράφει στη ροή στην τρέχουσα θέση της και τη αφήνει ανοιχτή.

### **Μετατροπή μιας Εικόνας SVG σε EMF και Προσθήκη στην Παρουσίαση**

Χρησιμοποιήστε το [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/el/cpp/aspose.slides/isvgimage/writeasemf/) για να μετατρέψετε το περιεχόμενο SVG σε EMF. Τα προκύπτοντα bytes μπορούν να προστεθούν στην παρουσίαση μέσω του [IImageCollection::AddImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimagecollection/addimage/) και να τοποθετηθούν σε μια διαφάνεια με την [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addpictureframe/).

Το παρακάτω παράδειγμα δημιουργεί ένα [SvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/svgimage/) από σήμανση SVG, το μετατρέπει σε EMF στη μνήμη, εισάγει το μετααρχείο στην πρώτη διαφάνεια και αποθηκεύει την παρουσίαση:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

Η [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/el/cpp/aspose.slides/isvgimage/writeasemf/) δεν αναλαμβάνει την ιδιοκτησία της ροής προορισμού. Μετά τη γραφή, η θέση της ροής είναι στο τέλος των παραγόμενων δεδομένων. Το παράδειγμα καλεί το [MemoryStream::ToArray](https://reference.aspose.com/slides/el/cpp/system.io/memorystream/toarray/) για να λάβει το πλήρες buffer ανεξάρτητα από την τρέχουσα θέση της ροής, και στη συνέχεια περνά αυτόν τον πίνακα byte στη [IImageCollection::AddImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimagecollection/addimage/). Διατηρήστε τη ροή ανοιχτή μέχρι να ολοκληρωθεί η ανάγνωση από τον καταναλωτή, και κλείστε την μετά.

Η δημιουργία EMF είναι διαθέσιμη στα λειτουργικά συστήματα που υποστηρίζονται από το Aspose.Slides for C++, αλλά η απόδοση μπορεί να διαφέρει μεταξύ πλατφορμών όταν λείπουν οι γραμματοσειρές ή οι εγγενείς εξαρτήσεις γραφικών. Εγκαταστήστε τις γραμματοσειρές που χρησιμοποιούνται από το πηγαίο περιεχόμενο ή διαμορφώστε κατάλληλες αντικαταστάσεις, ακολουθήστε τις [απαιτήσεις πλατφόρμας](/slides/el/cpp/system-requirements/) για το Aspose.Slides for C++ και επικυρώστε το αποτέλεσμα στην εφαρμογή-προορισμό που καταναλώνει EMF. Οι εφαρμογές Linux και macOS συχνά έχουν περιορισμένη ή ασυνεπή υποστήριξη για προβολή και επεξεργασία μετααρχείων των Windows.

## **Απόδοση Έγχρωμων Emoji**

{{% alert title="Σημείωση" color="info" %}}
Για να αποδίδονται σωστά τα έγχρωμα emoji κατά τη μετατροπή των διαφανειών της παρουσίασης σε εικόνες, οι γραμματοσειρές emoji που χρησιμοποιούνται στην παρουσίαση πρέπει να είναι εγκατεστημένες και διαθέσιμες στο σύστημα που εκτελεί τη μετατροπή. Για παράδειγμα, εάν η παρουσίαση χρησιμοποιεί τη **Segoe UI Emoji** και αυτή η γραμματοσειρά λείπει, τα emoji μπορεί να εμφανίζονται μονοχρωματικά στις εικόνες εξόδου.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το Aspose.Slides την απόδοση διαφανειών με κινούμενα γραφικά;**

Όχι. Η μέθοδος [ISlide::GetImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/getimage/) αποδίδει μια στατική εικόνα της διαφάνειας και δεν εξάγει τις κινούμενες εικόνες.

**Μπορούν οι κρυμμένες διαφάνειες να εξαχθούν ως εικόνες;**

Ναι. Οι κρυμμένες διαφάνειες μπορούν να αποδοθούν όπως οι κανονικές διαφάνειες. Συμπεριλάβετε τις στη βρόχο επεξεργασίας, όπως φαίνεται στο παραπάνω παράδειγμα.

**Διατηρούνται οι σκιές και άλλα εφέ στις εικόνες των διαφανειών;**

Ναι. Η Aspose.Slides αποδίδει σκιές, διαφάνειες και άλλα υποστηριζόμενα γραφικά εφέ στις εικόνες των διαφανειών.