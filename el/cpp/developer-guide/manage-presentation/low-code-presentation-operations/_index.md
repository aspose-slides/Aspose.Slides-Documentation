---
title: Λειτουργίες παρουσίασης χαμηλού κώδικα σε C++
linktitle: API χαμηλού κώδικα
type: docs
weight: 50
url: /el/cpp/low-code-presentation-operations/
keywords:
- API παρουσίασης χαμηλού κώδικα
- μετατροπή παρουσίασης
- συγχώνευση παρουσιάσεων
- επανάληψη διαφανειών
- επανάληψη σχημάτων
- επανάληψη κειμένου
- συλλογή σχημάτων
- συμπίεση παρουσίασης
- αφαίρεση αχρησιμοποίητων master διαφανειών
- αφαίρεση αχρησιμοποίητων layout διαφανειών
- συμπίεση ενσωματωμένων γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Χρησιμοποιήστε το API χαμηλού κώδικα του Aspose.Slides σε C++ για να μετατρέψετε και να συγχωνεύσετε παρουσιάσεις, να επαναλάβετε το περιεχόμενο, να συλλέξετε σχήματα και να μειώσετε το μέγεθος της παρουσίασης."
---
## **Επισκόπηση**

Ο χώρος ονομάτων [Aspose::Slides::LowCode] παρέχει στατικές βοηθητικές κλάσεις για κοινές λειτουργίες παρουσίασης. Αυτοί οι βοηθοί περικλείουν συχνά χρησιμοποιούμενες ροές εργασίας του μοντέλου αντικειμένων σε στοχευμένες μεθόδους, ώστε να μπορείτε να μετατρέψετε ή να συγχωνεύσετε αρχεία, να επεξεργαστείτε στοιχεία παρουσίασης, να συλλέξετε σχήματα και να αφαιρέσετε αχρησιμοποίητο περιεχόμενο με λιγότερο κώδικα.

Οι βοηθοί χαμηλού κώδικα είναι πιο χρήσιμοι όταν η λειτουργία αφορά ολόκληρο αρχείο ή παρουσίαση και η προεπιλεγμένη ροή εργασίας ταιριάζει στις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων [Aspose.Slides object model] όταν χρειάζεστε λεπτομερή έλεγχο των επιμέρους διαφανειών, master, διατάξεων, σχημάτων, ρυθμίσεων εξαγωγής ή σχέσεων μεταξύ των στοιχείων παρουσίασης.

Ο παρακάτω πίνακας συνοψίζει τους διαθέσιμους βοηθούς:

| Βοηθός | Χρήση |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/convert/) | Μετατροπή μιας παρουσίασης σε άλλη μορφή με άμεση κλήση αρχείου-προς-αρχείο. |
| [Merger](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/merger/) | Συνδυασμός πλήρων αρχείων παρουσίασης του ίδιου μορφότυπου. |
| [ForEach](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/) | Εκτέλεση ενέργειας για κάθε διαφάνεια, σχήμα, παράγραφο ή τμήμα κειμένου. |
| [Collect](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναλαμβανόμενη επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/) | Αφαίρεση αχρησιμοποίητων master και διατάξεων και μείωση ενσωματωμένων δεδομένων γραμματοσειρών. |

## **Μετατροπή Παρουσίασης**

Χρησιμοποιήστε [Convert::AutoByExtension](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/convert/autobyextension/) όταν η επέκταση του αρχείου εξόδου είναι επαρκής για την επιλογή του μορφότυπου εξαγωγής. Η μέθοδος ανοίγει την αρχική παρουσίαση, προσδιορίζει τον απαιτούμενο μορφότυπο από τη διαδρομή εξόδου και γράφει το αποτέλεσμα.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

Η κλάση [Convert](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/convert/) παρέχει επίσης αφιερωμένες μεθόδους για εξαγωγή σε PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν πρέπει να ελέγξετε ή να τροποποιήσετε την παρουσίαση πριν από την εξαγωγή ή να ρυθμίσετε μια επιλογή εξαγωγής που δεν εκτίθεται από τον επιλεγμένο βοηθό. Δείτε [Convert Presentation](/cpp/convert-presentation/) για μορφο-συγκεκριμένες ροές εργασίας και επιλογές.

## **Συγχώνευση Παρουσιάσεων**

Χρησιμοποιήστε [Merger::Process](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/merger/process/) για να συνδυάσετε πλήρη αρχεία παρουσίασης με μία κλήση. Οι εισερχόμενες παρουσιάσεις πρέπει να έχουν τον ίδιο μορφότυπο αρχείου.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

Ο βοηθός είναι κατάλληλος όταν όλες οι διαφάνειες πρέπει να προσαρτηθούν σε ένα αποτέλεσμα χωρίς να επιλέγονται ή να αντιστοιχίζονται χωριστά. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να συγχωνεύσετε επιλεγμένες διαφάνειες, να εφαρμόσετε master ή διάταξη προορισμού, να διατηρήσετε ενότητες ρητά ή να εναρμονίσετε διαφορετικά μεγέθη διαφανειών. Δείτε [Merge Presentations](/cpp/merge-presentation/) για αυτές τις περιπτώσεις.

## **Επανάληψη Στοιχείων Παρουσίασης**

Η κλάση [ForEach](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/) καλεί μια λειτουργία επανάκλησης για κάθε ζητούμενο τύπο στοιχείου παρουσίασης. Αποφεύγει ένθετους βρόχους συλλογής και είναι βολική για επιθεώρηση ή αλλαγές μορφοποίησης σε όλη την παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί [ForEach::Slide](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/paragraph/), και [ForEach::Portion](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/portion/) για την επιθεώρηση των αντίστοιχων στοιχείων:

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

Από προεπιλογή, η διέλευση σχημάτων και κειμένου σε όλη την παρουσίαση περιλαμβάνει κανονικές, master και layout διαφάνειες. Οι υπερφορτώσεις με παράμετρο `includeNotes` μπορούν επίσης να επεξεργαστούν διαφάνειες σημειώσεων. Χρησιμοποιήστε άμεσους βρόχους συλλογής όταν η σειρά διέλευσης, η πρόωρη έξοδος, το φιλτράρισμα πριν την κλήση επανάκλησης ή ο λεπτομερής έλεγχος γονέα-παιδιού είναι σημαντικοί.

## **Συλλογή Σχημάτων**

Χρησιμοποιήστε [Collect::Shapes](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/collect/shapes/) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση αντί για μια λειτουργία επανάκλησης για κάθε σχήμα. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτραριστεί, θα μετρηθεί ή θα υποστεί επεξεργασία περισσότερες από μία φορές.

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

Χρησιμοποιήστε [ForEach::Shape](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/shape/) αντ' αυτού όταν κάθε σχήμα μπορεί να επεξεργαστεί αμέσως και δεν χρειάζεται να διατηρήσετε το συλλεγμένο αποτέλεσμα.

## **Συμπίεση Περιεχομένου Παρουσίασης**

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

Αφαιρέστε πρώτα τις αχρησιμοποίητες διατάξεις και μετά τα αχρησιμοποίητα master, ώστε ένα master που γίνει ακατάλληλο μετά τον καθαρισμό των διατάξεων να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε νέο αρχείο εάν μπορεί να χρειαστείτε αργότερα τα αρχικά master, διατάξεις ή τα πλήρη δεδομένα ενσωματωμένων γραμματοσειρών. Για περισσότερες λεπτομέρειες, δείτε [Slide Master](/cpp/slide-master/) και [Embedded Font](/cpp/embedded-font/).

## **Συχνές Ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το API χαμηλού κώδικα αντί του πλήρους μοντέλου αντικειμένων;**

Χρησιμοποιήστε τους βοηθούς χαμηλού κώδικα όταν μια τυπική λειτουργία ισχύει για ολόκληρο το αρχείο ή την παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο των επιμέρους στοιχείων. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να επιλέξετε συγκεκριμένες διαφάνειες, να ελέγξετε σχέσεις master και διάταξης, να επιθεωρήσετε ενδιάμεση κατάσταση ή να ρυθμίσετε συμπεριφορά που ο βοηθός δεν εκθέτει.

**Μπορεί το Merger να συνδυάσει παρουσιάσεις σε διαφορετικούς τύπους αρχείων;**

Όχι. Το [Merger::Process](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/merger/process/) απαιτεί οι εισερχόμενες παρουσιάσεις να είναι στον ίδιο μορφότυπο. Μετατρέψτε πρώτα τα αρχεία εισόδου σε κοινό μορφότυπο, για παράδειγμα με [Convert::AutoByExtension](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/convert/autobyextension/), και μετά συγχωνεύστε τα μετατρεπόμενα αρχεία.

**Η ForEach επεξεργάζεται master, layout και notes διαφάνειες;**

Το [ForEach::Slide](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/slide/) επαναλαμβάνει τις κανονικές διαφάνειες παρουσίασης. Η [ForEach::Shape](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/paragraph/) και [ForEach::Portion](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/portion/) περιλαμβάνουν από προεπιλογή κανονικές, master και layout διαφάνειες. Χρησιμοποιήστε τις υπερφορτώσεις τους με `includeNotes` ορισμένο σε `true` για να συμπεριλάβετε και τις διαφάνειες σημειώσεων.

**Ποια είναι η διαφορά μεταξύ ForEach::Shape και Collect::Shapes;**

Χρησιμοποιήστε το [ForEach::Shape](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/shape/) για να επεξεργαστείτε κάθε σχήμα αμέσως μέσω μιας λειτουργίας επανάκλησης. Χρησιμοποιήστε το [Collect::Shapes](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/collect/shapes/) όταν χρειάζεστε ένα συλλεκτικό αποτέλεσμα που μπορεί να διατηρηθεί, φιλτραριστεί, μετρηθεί ή διασχιστεί πολλές φορές.

**Η Compress μειώνει πάντα το μέγεθος του αρχείου παρουσίασης;**

Δεν είναι απαραίτητα. Το αποτέλεσμα εξαρτάται από το αν η παρουσίαση περιέχει αχρησιμοποίητες διατάξεις, αχρησιμοποίητα master ή ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες. Εάν κανένα από αυτά δεν υπάρχει, οι αντίστοιχες λειτουργίες [Compress](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/) ενδέχεται να μην μειώσουν το μέγεθος του αρχείου.

**Αποθηκεύονται αυτόματα οι αλλαγές που γίνονται από τη ForEach ή τη Compress;**

Όχι. Αυτοί οι βοηθοί λειτουργούν πάνω στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) στη μνήμη. Μετά την αλλαγή στοιχείων σε μια λειτουργία επανάκλησης [ForEach](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/foreach/) ή μετά την εκτέλεση της [Compress](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/), καλέστε το [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Μετατροπή Παρουσίασης](/cpp/convert-presentation/)
- [Συγχώνευση Παρουσιάσεων](/cpp/merge-presentation/)
- [Slide Master](/cpp/slide-master/)
- [Διαχείριση Πλαισίου Κειμένου](/cpp/manage-textbox/)
- [Embedded Font](/cpp/embedded-font/)