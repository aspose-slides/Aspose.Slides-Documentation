---
title: Λειτουργίες Παρουσίασης Low‑Code σε C++
linktitle: API Low‑Code
type: docs
weight: 50
url: /el/cpp/low-code-presentation-operations/
keywords:
- API παρουσίασης low‑code
- μετατροπή παρουσίασης
- συγχώνευση παρουσιάσεων
- επανάληψη διαφανειών
- επανάληψη σχημάτων
- επανάληψη κειμένου
- συλλογή σχημάτων
- συμπίεση παρουσίασης
- αφαίρεση αχρησιμοποίητων master διαφανειών
- αφαίρεση αχρησιμοποίητων διαφανειών διάταξης
- συμπίεση ενσωματωμένων γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Χρησιμοποιήστε το low‑code API του Aspose.Slides σε C++ για να μετατρέψετε και να συγχωνεύσετε παρουσιάσεις, να επαναλάβετε το περιεχόμενο, να συλλέξετε σχήματα και να μειώσετε το μέγεθος της παρουσίασης."
---
## **Επισκόπηση**

Ο χώρος ονομάτων [Aspose::Slides::LowCode](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/) παρέχει στατικές βοηθητικές κλάσεις για κοινές λειτουργίες παρουσίασης. Αυτοί οι βοηθοί περιτυλίγουν συχνά χρησιμοποιούμενες ροές εργασίας του μοντέλου αντικειμένων σε εστιασμένες μεθόδους, ώστε να μπορείτε να μετατρέπετε ή να συγχωνεύετε αρχεία, να επεξεργάζεστε στοιχεία παρουσίασης, να συλλέγετε σχήματα και να αφαιρείτε αχρήσιμο περιεχόμενο με λιγότερο κώδικα.

Οι βοηθοί χαμηλού κώδικα είναι πιο χρήσιμοι όταν η λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και η προεπιλεγμένη ροή εργασίας ταιριάζει στις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων [Aspose.Slides](https://reference.aspose.com/slides/el/cpp/aspose.slides/) όταν χρειάζεστε ακριβή έλεγχο σε μεμονωμένες διαφάνειες, master, διατάξεις, σχήματα, ρυθμίσεις εξαγωγής ή σχέσεις μεταξύ των στοιχείων παρουσίασης.

Ο παρακάτω πίνακας συνοψίζει τους διαθέσιμους βοηθούς:

| Βοηθός | Για τι χρησιμοποιείται |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/convert/) | Μετατροπή μιας παρουσίασης σε άλλη μορφή με άμεση κλήση αρχείου‑σε‑αρχείο. |
| [Merger](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/merger/) | Συνένωση πλήρων αρχείων παρουσίασης της ίδιας μορφής. |
| [ForEach](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/) | Εκτέλεση ενέργειας για κάθε διαφάνεια, σχήμα, παράγραφο ή τμήμα κειμένου. |
| [Collect](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναλαμβανόμενη επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/) | Αφαίρεση αχρησιμοποίητων master και διατάξεων και μείωση των ενσωματωμένων δεδομένων γραμματοσειρών. |

## **Convert a Presentation**

Χρησιμοποιήστε το [Convert::AutoByExtension](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/convert/autobyextension/) όταν η επέκταση του αρχείου εξόδου είναι επαρκής για την επιλογή της μορφής εξαγωγής. Η μέθοδος ανοίγει την πηγή παρουσίασης, καθορίζει τη ζητούμενη μορφή από τη διαδρομή εξόδου και γράφει το αποτέλεσμα.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

Η κλάση [Convert](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/convert/) παρέχει επίσης εξειδικευμένες μεθόδους για έξοδο PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν πρέπει να ελέγξετε ή να τροποποιήσετε την παρουσίαση πριν από την εξαγωγή ή να διαμορφώσετε μια επιλογή εξαγωγής που δεν εκτίθεται από τον επιλεγμένο βοηθό. Δείτε το [Convert Presentation](/slides/el/cpp/convert-presentation/) για ροές εργασίας και επιλογές συγκεκριμένων μορφών.

## **Merge Presentations**

Χρησιμοποιήστε το [Merger::Process](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/merger/process/) για να συνδυάσετε πλήρη αρχεία παρουσίασης με μία κλήση. Οι εισερχόμενες παρουσιάσεις πρέπει να έχουν την ίδια μορφή αρχείου.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

Ο βοηθός είναι κατάλληλος όταν όλες οι διαφάνειες πρέπει να προστεθούν σε ένα αποτέλεσμα χωρίς να επιλέγονται ή να αντιστοιχίζονται μεμονωμένα. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να συγχωνεύσετε επιλεγμένες διαφάνειες, να εφαρμόσετε προορισμένο master ή διάταξη, να διατηρήσετε τμήματα ρητά ή να εναρμονίσετε διαφορετικά μεγέθη διαφανειών. Δείτε το [Merge Presentations](/slides/el/cpp/merge-presentation/) για αυτές τις περιπτώσεις.

## **Iterate Through Presentation Elements**

Η κλάση [ForEach](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/) καλεί μια συνάρτηση επανάκλησης για κάθε ζητούμενο τύπο στοιχείου παρουσίασης. Αποφεύγει ενσωματωμένους βρόχους συλλογής και είναι βολική για ελέγχους ή αλλαγές διαμόρφωσης σε όλη την παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί [ForEach::Slide](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/paragraph/) και [ForEach::Portion](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/portion/) για να ελέγξει τα αντίστοιχα στοιχεία:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

Από προεπιλογή, η περιήγηση σχήματος και κειμένου σε όλη την παρουσίαση περιλαμβάνει κανονικές, master και layout διαφάνειες. Οι υπερφορτώσεις με παράμετρο `includeNotes` μπορούν επίσης να επεξεργαστούν διαφάνειες σημειώσεων. Χρησιμοποιήστε άμεσους βρόχους συλλογής όταν η σειρά περιήγησης, η πρόωρη έξοδος, το φιλτράρισμα πριν από την κλήση της συνάρτησης επανάκλησης ή ο λεπτομερής έλεγχος γονέα‑παιδιού είναι σημαντικά.

## **Collect Shapes**

Χρησιμοποιήστε το [Collect::Shapes](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/collect/shapes/) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση αντί για κλήση επανάκλησης για κάθε σχήμα. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτραριστεί, μετρηθεί ή επεξεργαστεί περισσότερες από μία φορές.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Χρησιμοποιήστε το [ForEach::Shape](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/shape/) αντ' αυτού όταν κάθε σχήμα μπορεί να επεξεργαστεί άμεσα και δεν χρειάζεται να διατηρήσετε το συλλεχθέν αποτέλεσμα.

## **Compress Presentation Content**

Η κλάση [Compress](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/) μπορεί να αφαιρέσει αχρησιμοποίητα δομικά στοιχεία και να μειώσει τα ενσωματωμένα δεδομένα γραμματοσειρών:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) αφαιρεί διαφάνειες διάταξης που δεν αναφέρονται από καμία κανονική διαφάνεια.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) αφαιρεί master διαφάνειες που δεν χρησιμοποιούνται πλέον.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) αφαιρεί αχρησιμοποίητους χαρακτήρες από τις ενσωματωμένες γραμματοσειρές.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Αφαιρέστε πρώτα τις αχρησιμοποίητες διατάξεις πριν τις αχρησιμοποίητες master, ώστε μια master που γίνει ακαταλήπτη μετά τον καθαρισμό των διατάξεων να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε νέο αρχείο εάν μπορεί να χρειαστείτε αργότερα τους αρχικούς masters, διατάξεις ή τα πλήρη ενσωματωμένα δεδομένα γραμματοσειρών. Για περισσότερες λεπτομέρειες, δείτε το [Slide Master](/slides/el/cpp/slide-master/) και το [Embedded Font](/slides/el/cpp/embedded-font/).

## **FAQ**

**Πότε πρέπει να χρησιμοποιήσω το low‑code API αντί για το πλήρες μοντέλο αντικειμένων;**

Χρησιμοποιήστε τους βοηθούς low‑code όταν μια τυπική λειτουργία εφαρμόζεται σε ολοκληρωμένο αρχείο ή παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο σε μεμονωμένα στοιχεία. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να επιλέξετε συγκεκριμένες διαφάνειες, να ελέγξετε σχέσεις master‑layout, να ελέγξετε ενδιάμεση κατάσταση ή να ρυθμίσετε συμπεριφορά που δεν εκτίθεται από τον βοηθό.

**Μπορεί ο Merger να συνδυάσει παρουσιάσεις σε διαφορετικές μορφές αρχείου;**

Όχι. Το [Merger::Process](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/merger/process/) απαιτεί οι εισερχόμενες παρουσιάσεις να είναι της ίδιας μορφής. Μετατρέψτε πρώτα τα αρχεία εισόδου σε κοινή μορφή, π.χ. με το [Convert::AutoByExtension](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/convert/autobyextension/), και, στη συνέχεια, συγχωνεύστε τα μετατρεπόμενα αρχεία.

**Το ForEach επεξεργάζεται master, layout και notes διαφάνειες;**

Το [ForEach::Slide](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/slide/) επαναλαμβάνει τις κανονικές διαφάνειες παρουσίασης. Η λειτουργία [ForEach::Shape](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/paragraph/) και [ForEach::Portion](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/portion/) σε όλη την παρουσίαση περιλαμβάνει εξ προεπιλογή τις κανονικές, master και layout διαφάνειες. Χρησιμοποιήστε τις υπερφορτώσεις τους με `includeNotes` ορισμένο σε `true` για να συμπεριλάβετε και τις notes διαφάνειες.

**Ποια είναι η διαφορά μεταξύ ForEach::Shape και Collect::Shapes;**

Χρησιμοποιήστε το [ForEach::Shape](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/shape/) για άμεση επεξεργασία κάθε σχήματος μέσω κλήσης επανάκλησης. Χρησιμοποιήστε το [Collect::Shapes](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/collect/shapes/) όταν χρειάζεστε ένα επαναχρησιμοποιήσιμο αποτέλεσμα που μπορεί να διατηρηθεί, φιλτραριστεί, μετρηθεί ή περιηγηθεί πολλές φορές.

**Το Compress μειώνει πάντα το μέγεθος του αρχείου παρουσίασης;**

Όχι απαραίτητα. Το αποτέλεσμα εξαρτάται από το εάν η παρουσίαση περιέχει αχρησιμοποίητες διατάξεις, αχρησιμοποίητους masters ή ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες. Εάν δεν υπάρχουν, οι αντίστοιχες λειτουργίες [Compress](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/) μπορεί να μην μειώσουν το μέγεθος του αρχείου.

**Αποθηκεύονται αυτόματα οι αλλαγές που κάνει το ForEach ή το Compress;**

Όχι. Οι βοηθοί αυτοί λειτουργούν στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) στη μνήμη. Μετά την αλλαγή στοιχείων σε μια κλήση επανάκλησης [ForEach] ή την εκτέλεση του [Compress], καλέστε το [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Convert Presentation](/slides/el/cpp/convert-presentation/)
- [Merge Presentations](/slides/el/cpp/merge-presentation/)
- [Slide Master](/slides/el/cpp/slide-master/)
- [Manage Text Box](/slides/el/cpp/manage-textbox/)
- [Embedded Font](/slides/el/cpp/embedded-font/)