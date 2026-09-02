---
title: Αποτελεσματική Συγχώνευση Παρουσιάσεων σε C++
linktitle: Συγχώνευση Παρουσιάσεων
type: docs
weight: 40
url: /el/cpp/merge-presentation/
keywords:
- συγχώνευση PowerPoint
- συγχώνευση παρουσιάσεων
- συγχώνευση διαφανειών
- συγχώνευση PPT
- συγχώνευση PPTX
- συγχώνευση ODP
- συνδυασμός PowerPoint
- συνδυασμός παρουσιάσεων
- συνδυασμός διαφανειών
- συνδυασμός PPT
- συνδυασμός PPTX
- συνδυασμός ODP
- C++
- Aspose.Slides
description: "Μάθετε πώς να συγχωνεύετε παρουσιάσεις PowerPoint και OpenDocument σε C++ κλωνοποιώντας διαφάνειες, ελέγχοντας masters και layouts, αλλάζοντας το μέγεθος του περιεχομένου των διαφανειών, διατηρώντας τις ενότητες και διαχειριζόμενοι προστατευμένα ή μεγάλα αρχεία."
---
## **Επισκόπηση**

Aspose.Slides for C++ συγχωνεύει παρουσιάσεις κλωνοποιώντας διαφάνειες από μία [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) σε άλλη. Η κύρια λειτουργία είναι το [ISlideCollection::AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/), το οποίο μπορεί να διατηρήσει τη μορφοποίηση της πηγής ή να προσαρτήσει τη κλωνοποιημένη διαφάνεια σε ένα master ή layout στην προορισμένη παρουσίαση.

Αυτό το άρθρο καλύπτει τις πιο συνηθισμένες ροές εργασίας συγχώνευσης:

- συγχώνευση όλων των διαφανειών διατηρώντας τη μορφοποίηση της πηγής·
- συγχώνευση επιλεγμένων διαφανειών·
- εφαρμογή master από την προορισμένη παρουσίαση·
- εφαρμογή συγκεκριμένου layout από την προορισμένη παρουσίαση·
- ομαλοποίηση διαφορετικών μεγεθών διαφανειών πριν από τη συγχώνευση·
- προσθήκη κλωνοποιημένων διαφανειών σε ενότητα·
- συγχώνευση πολλαπλών παρουσιάσεων σε μία ολοκληρωμένη ροή εργασίας·
- διαχείριση masters, πόρων, σημειώσεων, σχολίων, πολυμέσων, γραμματοσειρών, κωδικών πρόσβασης, μεγάλων αρχείων και ζητημάτων πολυνηματισμού.

## **Πώς η Κλωνοποίηση Διαφανειών Επηρεάζει Masters και Layouts**

Μια διαφάνεια κληρονομεί μεγάλο μέρος της εμφάνισης της από το layout και το master της. Για αυτόν τον λόγο, η υπερφόρτωση κλωνοποίησης που θα επιλέξετε καθορίζει πώς ενσωματώνεται η συγχωνευμένη διαφάνεια στην προορισμένη παρουσίαση.

Χρησιμοποιήστε το [ISlideCollection::AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) με έναν από τους παρακάτω τρόπους:

- `AddClone(sourceSlide)` — διατηρεί το layout και τη μορφοποίηση της πηγής. Όταν απαιτείται, το master της πηγής μπορεί να κλωνοποιηθεί αυτόματα στην προορισμένη παρουσίαση. Το Aspose.Slides παρακολουθεί αυτόματα κλωνοποιημένα masters ώστε επαναλαμβανόμενες διαφάνειες που χρησιμοποιούν το ίδιο master δεν προκαλούν επαναλαμβανόμενο κλωνοποίηση του master.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — προσαρτά τη κλωνοποιημένη διαφάνεια σε ένα συγκεκριμένο προορισμένο [IMasterSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslide/). Το Aspose.Slides ψάχνει για ένα αντίστοιχο layout κάτω από αυτό το master βάσει τύπου ή ονόματος layout.
- `AddClone(sourceSlide, destinationLayout)` — προσαρτά τη κλωνοποιημένη διαφάνεια απευθείας σε ένα συγκεκριμένο προορισμένο [ILayoutSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/).

Το master ή το layout που περνιέται σε μία υπερφόρτωση `AddClone` πρέπει να ανήκει στην **προορισμένη** παρουσίαση, όχι στην πηγή.

## **Συγχώνευση Ολόκληρων Παρουσιάσεων και Διατήρηση Μορφοποίησης Πηγής**

Η πιο απλή συγχώνευση αντιγράφει κάθε διαφάνεια από την πηγή στην προορισμένη παρουσίαση. Αυτή είναι η κατάλληλη επιλογή όταν οι εισαγόμενες διαφάνειες πρέπει να διατηρήσουν το αρχικό θέμα, το master και τις σχέσεις layout.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

Η παραγόμενη παρουσίαση μπορεί να περιέχει πολλαπλά masters όταν η πηγή και ο προορισμός χρησιμοποιούν διαφορετικά σχέδια. Αυτό είναι αναμενόμενο όταν η μορφοποίηση της πηγής διατηρείται σκόπιμα.

## **Συγχώνευση Επιλεγμένων Διαφανειών**

Δεν χρειάζεται να κλωνοποιήσετε κάθε διαφάνεια. Το παρακάτω παράδειγμα εισάγει μόνο επιλεγμένα δείκτες διαφανειών από την παρουσίαση πηγής.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

Επικυρώστε τους δείκτες διαφανειών πριν από την κλωνοποίηση όταν προέρχονται από είσοδο χρήστη ή εξωτερική ρύθμιση.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Master Προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) όταν οι εισαγόμενες διαφάνειες πρέπει να ακολουθούν ένα master που ήδη ανήκει στην προορισμένη παρουσίαση.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Το Aspose.Slides επιλέγει ένα κατάλληλο layout κάτω από το καθορισμένο master ταιριάζοντας με τον τύπο ή το όνομα του layout της πηγής. Αν δεν υπάρχει κατάλληλο layout και το `allowCloneMissingLayout` είναι `true`, το layout της πηγής κλωνοποιείται ώστε η διαφάνεια να προστεθεί. Αν είναι `false`, θα ριχθεί ένα [PptxEditException](https://reference.aspose.com/slides/el/cpp/aspose.slides/details_pptxeditexception/).

Χρησιμοποιήστε `false` όταν θέλετε η συγχώνευση να αποτύχει αντί να εισάγει ένα πρόσθετο layout στο master προορισμού.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Συγκεκριμένο Layout Προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) όταν γνωρίζετε ακριβώς ποιο layout προορισμού πρέπει να χρησιμοποιούν οι εισαγόμενες διαφάνειες.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

Η εφαρμογή ενός layout προορισμού αλλάζει τη σχέση κληρονομούμενου layout· δεν αλλάζει το περιεχόμενο της πηγαίας διαφάνειας. Αν τα layout πηγής και προορισμού έχουν διαφορετικές δομές placeholders, ελέγξτε το αποτέλεσμα για να βεβαιωθείτε ότι η κληρονομημένη μορφοποίηση και η συμπεριφορά placeholders είναι κατάλληλη.

## **Συγχώνευση Παρουσιάσεων με Διαφορετικά Μεγέθη Διαφανειών**

Παρουσιάσεις με διαφορετικές διαστάσεις διαφανειών μπορούν να συγχωνευτούν, αλλά η κλωνοποίηση μιας διαφάνειας σε παρουσίαση με άλλο μέγεθος δεν επανασχεδιάζει αυτόματα το περιεχόμενό της για το νέο καμβά. Τα σχήματα μπορεί να εμφανιστούν μετατοπισμένα, κλιματισμένα απρόσμενα ή έξω από την ορατή περιοχή της διαφάνειας.

Μια πρακτική προσέγγιση είναι η αλλαγή μεγέθους της πηγής πριν από την κλωνοποίηση. Η μέθοδος [SlideSize::SetSize](https://reference.aspose.com/slides/el/cpp/aspose.slides/slidesize/setsize/) μπορεί να κλιματώσει το υπάρχον περιεχόμενο ενώ αλλάζει τις διαστάσεις της διαφάνειας. Το [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/el/cpp/aspose.slides/slidesizescaletype/) κλιματώνει το περιεχόμενο ώστε να ταιριάζει στο ζητούμενο μέγεθος.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

Η αλλαγή μεγέθους μεταβάλλει το αντικείμενο της πηγής μνήμης. Αν χρειάζεστε την αρχική πηγή αμετάβλητη για άλλες λειτουργίες, ανοίξτε μια ξεχωριστή παρουσίαση για τη συγχώνευση.

## **Συγχώνευση Διαφανειών σε Ενότητα Παρουσίασης**

Ο βασικός βρόχος κλωνοποίησης διαφανειών δεν αναδημιουργεί την ιεραρχία ενοτήτων της πηγαίας παρουσίασης. Αν οι ενότητες έχουν σημασία στο τελικό αποτέλεσμα, δημιουργήστε ή επιλέξτε ενότητες στην προορισμένη παρουσίαση και κλωνοποιήστε τις διαφάνειες σε αυτές ρητά με το [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/).

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

Οι κλωνοποιημένες διαφάνειες προσαρτώνται στην καθορισμένη ενότητα προορισμού. Για να διατηρήσετε πολλές πηγικές ενότητες, επαναλάβετε το [Presentation::get_Sections](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_sections/), λάβετε τις τρέχουσες διαφάνειες κάθε ενότητας με το [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isection/getslideslistofsection/), δημιουργήστε ξανά τις ενότητες στον προορισμό και κλωνοποιήστε κάθε επιστρεφόμενη διαφάνεια στην αντίστοιχη ενότητα προορισμού. Δείτε το [Manage Slide Sections](/slides/el/cpp/slide-section/) για ένα πλήρες παράδειγμα επαναλήψης ενοτήτων, συμπεριλαμβανομένων κενών ενοτήτων και δομικών αλλαγών.

## **Ασφαλής Συγχώνευση Πολλών Παρουσιάσεων**

Το παρακάτω παράδειγμα ολοκληρωμένης ροής χρησιμοποιεί την πρώτη παρουσίαση ως προορισμό, ομαλοποιεί το μέγεθος διαφάνειας κάθε πρόσθετης πηγής, κρατά κάθε πηγή ανοιχτή μόνο κατά τη διάρκεια της αντιγραφής και αποθηκεύει το τελικό αρχείο μία φορά.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

Αυτό αποτελεί ένα χρήσιμο σημείο εκκίνησης για τη διατήρηση της μορφοποίησης της πηγής των εισαγόμενων διαφανειών. Αν το τελικό σας αποτέλεσμα πρέπει να χρησιμοποιεί ένα ενιαίο θέμα προορισμού, αντικαταστήστε την απλή κλήση `AddClone(slide)` με την κατάλληλη υπερφόρτωση master ή layout προορισμού που παρουσιάστηκε νωρίτερα.

## **Πρακτικές Σκέψεις**

### **Masters, Layouts και Πιστότητα Μορφοποίησης**

Η προεπιλεγμένη κλωνοποίηση διαφανειών μπορεί αυτόματα να φέρει ένα απαιτούμενο master πηγής στην προορισμένη παρουσίαση. Το Aspose.Slides διατηρεί ένα εσωτερικό μητρώο για αυτόματα κλωνοποιημένα masters ώστε να αποφεύγεται η επαναλαμβανόμενη κλωνοποίηση του ίδιου master. Τα χειροκίνητα κλωνοποιημένα masters δεν παρακολουθούνται από αυτό το μητρώο, οπότε αποφύγετε την προ-κλωνοποίηση masters εκτός αν χρειάζεστε άμεσο έλεγχο της δομής του master.

Μην υποθέτετε ότι δύο masters ή layouts με το ίδιο όνομα είναι οπτικά ισοδύναμα. Αν ένα εταιρικό πρότυπο πρέπει να ελέγχει την τελική εμφάνιση, επιλέξτε ρητά ένα master ή layout προορισμού και επαληθεύστε το αποτέλεσμα μετά τη συγχώνευση.

### **Σημειώσεις και Σχόλια**

Οι σημειώσεις ομιλητή και τα σχόλια διαφάνειας συνδέονται με το περιεχόμενο της διαφάνειας και αντιγράφονται όταν κλωνοποιείται η διαφάνεια. Το Aspose.Slides παρέχει επίσης εξειδικευμένα API για [presentation notes](/slides/el/cpp/presentation-notes/) και [presentation comments](/slides/el/cpp/presentation-comments/).

Αν η μορφοποίηση της σελίδας σημειώσεων είναι σημαντική, ελέγξτε τη συγχωνευμένη παρουσίαση επειδή τα notes masters είναι αντικείμενα επιπέδου παρουσίασης και μπορεί να διαφέρουν μεταξύ των πηγών. Για ροές ελέγχου, επαληθεύστε επίσης τους συγγραφείς σχολίων και τα νημάτια σχολίων μετά τον συνδυασμό αρχείων από διαφορετικούς συγγραφείς ή πρότυπα.

### **Εικόνες, Ήχος, Βίντεο, Αντικείμενα OLE και Εξωτερικούς Συνδέσμους**

Οι διαφάνειες μπορούν να αναφέρονται σε πόρους επιπέδου παρουσίασης όπως εικόνες, ενσωματωμένο ήχο, ενσωματωμένο βίντεο και δεδομένα OLE. Κλωνοποιήστε τη διαφάνεια ολοκληρωτικά αντί να αντιγράψετε μόνο τα ορατά σχήματα ώστε το Aspose.Slides να διατηρήσει τις σχέσεις της διαφάνειας με τους πόρους της.

Οι ενσωματωμένοι και οι συνδεδεμένοι πόροι πρέπει να αντιμετωπίζονται διαφορετικά. Ένας συνδεδεμένος ήχος, βίντεο, αντικείμενο OLE ή υπερσύνδεσμος παραμένει εξαρτημένος από τον εξωτερικό του προορισμό· η κλωνοποίηση μιας διαφάνειας δεν μετατρέπει έναν εξωτερικό σύνδεσμο σε ενσωματωμένο περιεχόμενο. Δοκιμάστε τις διαδρομές και τις URL των συνδεδεμένων πόρων στο περιβάλλον όπου θα ανοιχτεί η συγχωνευμένη παρουσίαση.

Το Aspose.Slides παρακολουθεί αυτόματα κλωνοποιημένα masters, αλλά αυτό δεν πρέπει να θεωρείται γενική εγγύηση ότι τα ίδια δυαδικά αρχεία από μη σχετικές πηγές θα αφαιρεθούν πάντα. Αν το μέγεθος του αρχείου εξόδου είναι κρίσιμο, εξετάστε το τελικό πακέτο και μετρήστε το αποτέλεσμα αντί να βασίζεστε στην έμμεση αφαιρετικότητα.

### **Ενσωματωμένες Γραμματοσειρές και Διαθεσιμότητα Γραμματοσειρών**

Οι γραμματοσειρές διαχειρίζονται σε επίπεδο παρουσίασης. Αν η τυπογραφία πρέπει να παραμείνει συνεπής σε διαφορετικούς υπολογιστές, μην υποθέτετε ότι η κλωνοποίηση διαφανειών εξασφαλίζει ότι κάθε απαιτούμενη γραμματοσειρά είναι διαθέσιμη στο περιβάλλον προορισμού. Μπορείτε να ελέγξετε τις ενσωματωμένες γραμματοσειρές με το [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/getembeddedfonts/) και να διαχειριστείτε την ενσωμάτωση όπως περιγράφεται στα [Embed Fonts in Presentations](/slides/el/cpp/embedded-font/).

Επίσης, βεβαιωθείτε ότι έχετε άδεια να ενσωματώσετε τις γραμματοσειρές που χρησιμοποιούν τα αρχεία πηγής. Οι άδειες γραμματοσειρών μπορεί να περιορίζουν την ενσωμάτωση.

### **Παρουσιάσεις με Προστασία Κωδικού Πρόσβασης**

Μια πηγή με κωδικό πρόσβασης πρέπει να ανοίξει επιτυχώς πριν μπορούν να κλωνοποιηθούν οι διαφάνειές της. Πληκτρολογήστε τον κωδικό μέσω του [LoadOptions::set_Password](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Το άνοιγμα μιας κωδικοποιημένης πηγής δεν εφαρμόζει αυτόματα την ίδια προστασία στην προορισμένη παρουσίαση. Διαμορφώστε την προστασία εξόδου ξεχωριστά όταν απαιτείται.

### **Μεγάλες Παρουσιάσεις και Χρήση Μνήμης**

Μεγάλες παρουσιάσεις που περιέχουν εικόνες υψηλής ανάλυσης, ήχους, βίντεο ή άλλα μεγάλα δυαδικά αντικείμενα μπορούν να καταναλώσουν σημαντική μνήμη. Το [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) παρέχει ελέγχους για τη διαχείριση BLOB και τη χρήση προσωρινών αρχείων. Δείτε το [Manage Presentation BLOBs](/slides/el/cpp/manage-blob/) για στρατηγικές μεγάλων αρχείων.

Για μεγάλα αρχεία, προτιμήστε τη φόρτωση από διαδρομές αρχείων όταν είναι δυνατόν, απελευθερώστε κάθε πηγή παρουσίασης μόλις ολοκληρωθεί η συγχώνευση και αποφύγετε την επαναλαμβανόμενη αποθήκευση ενδιάμεσων αποτελεσμάτων εκτός αν η ροή εργασίας απαιτεί σημεία ελέγχου.

### **Ασφάλεια Πολυνηματισμού**

Μην φορτώνετε, τροποποιείτε, αποθηκεύετε ή κλωνοποιείτε το ίδιο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) ταυτόχρονα από πολλαπλά νήματα. Κρατήστε κάθε παρουσίαση περιορισμένη σε μία λειτουργία συγχώνευσης. Αν παραλληλοποιείτε ανεξάρτητες εργασίες, χρησιμοποιήστε ανεξάρτητα αντικείμενα παρουσίασης και ακολουθήστε τις οδηγίες [Aspose.Slides multithreading guidance](/slides/el/cpp/multithreading/).

## **FAQ**

**Πώς μπορώ να διατηρήσω το αρχικό σχέδιο κάθε πηγής παρουσίασης;**

Χρησιμοποιήστε το [AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) χωρίς να προσθέσετε master ή layout προορισμού. Το Aspose.Slides μπορεί αυτόματα να κλωνοποιήσει το master πηγής όταν χρειάζεται από την εισαγόμενη διαφάνεια.

**Πώς μπορώ να κάνω τις εισαγόμενες διαφάνειες να χρησιμοποιούν το θέμα προορισμού;**

Χρησιμοποιήστε την υπερφόρτωση που δέχεται ένα master προορισμού. Περάστε ένα master από την προορισμένη παρουσίαση, όχι από την πηγή. Το Aspose.Slides θα προσπαθήσει να αντιστοιχίσει κάθε διαφάνεια πηγής σε ένα κατάλληλο layout κάτω από αυτό το master.

**Πότε πρέπει να χρησιμοποιήσω συγκεκριμένο layout προορισμού αντί για master προορισμού;**

Χρησιμοποιήστε συγκεκριμένο layout όταν κάθε εισαγόμενη διαφάνεια πρέπει να χρησιμοποιεί ένα γνωστό layout. Χρησιμοποιήστε master όταν θέλετε το Aspose.Slides να επιλέξει ανάμεσα στα layouts του master βάσει του τύπου ή του ονόματος του layout πηγής.

**Μπορούν να συγχωνευτούν παρουσιάσεις με διαφορετικά μεγέθη διαφανειών;**

Ναι, αλλά το περιεχόμενο της διαφάνειας δεν επανασχεδιάζεται αυτόματα για τις διαστάσεις προορισμού. Αλλάξτε το μέγεθος της πηγής πρώτα όταν χρειάζεται προβλεπόμενη τοποθέτηση, για παράδειγμα με το [SlideSize::SetSize](https://reference.aspose.com/slides/el/cpp/aspose.slides/slidesize/setsize/) και το [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/el/cpp/aspose.slides/slidesizescaletype/).


**Μπορώ να συγχωνεύσω αρχεία PPT, PPTX και ODP σε ένα αρχείο;**

Ναι. Φορτώστε κάθε πηγή παρουσίασης, κλωνοποιήστε τις απαιτούμενες διαφάνειες σε έναν προορισμό και αποθηκεύστε τον προορισμό σε μια υποστηριζόμενη μορφή εξόδου. Επειδή τα μορφότυπα παρουσίασης δεν υποστηρίζουν ακριβώς το ίδιο σύνολο λειτουργιών, επαληθεύστε το πολύπλοκο περιεχόμενο μετά από συγχωνεύσεις μεταξύ διαφορετικών μορφότυπων. Δείτε τα [Supported File Formats](/slides/el/cpp/supported-file-formats/).

**Διατηρούνται αυτόματα οι ενότητες πηγής;**

Όχι από έναν βασικό βρόχο που κλωνοποιεί μόνο διαφάνειες. Αναδημιουργήστε τις απαιτούμενες ενότητες στον προορισμό και χρησιμοποιήστε την υπερφόρτωση ενότητας του [AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) όταν η δομή ενοτήτων πρέπει να διατηρηθεί.

**Διατηρούνται οι σημειώσεις ομιλητή και τα σχόλια;**

Αντιγράφονται με τη κλωνοποιημένη διαφάνεια. Για ροές που εξαρτώνται από το στυλ του notes‑master, τους συγγραφείς σχολίων ή τα νημάτια ανασκοπήσεων, επαληθεύστε το συγχωνευμένο αποτέλεσμα επειδή αυτά τα σενάρια περιλαμβάνουν δομές επιπέδου παρουσίασης καθώς και περιεχόμενο διαφάνειας.

**Τι γίνεται με ήχο, βίντεο, αντικείμενα OLE και υπερσυνδέσμους;**

Το ενσωματωμένο περιεχόμενο μεταφέρεται ως μέρος των σχέσεων πόρων της κλωνοποιημένης διαφάνειας. Οι εξωτερικοί σύνδεσμοι παραμένουν εξωτερικοί, οπότε τα αρχεία ή οι URL προορισμού τους πρέπει να είναι διαθέσιμα μετά τη συγχώνευση.

**Εγγυάται η παρουσίαση ενσωματωμένων γραμματοσειρών από όλες τις πηγές;**

Μην βασίζεστε μόνο στην κλωνοποίηση διαφανειών για την υλοποίηση γραμματοσειρών. Εξετάστε τις ενσωματωμένες γραμματοσειρές του προορισμού και διαχειριστείτε ρητά την ενσωμάτωση ή τη διαθεσιμότητα εξωτερικών γραμματοσειρών όταν η τυπογραφία είναι σημαντική.

**Πώς συγχωνεύω ένα αρχείο με προστασία κωδικού;**

Ανοίξτε το με το σωστό [LoadOptions::set_Password](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_password/), στη συνέχεια κλωνοποιήστε τις διαφάνειές του κανονικά. Η προστασία εξόδου ρυθμίζεται ξεχωριστά.

**Πώς να διαχειριστώ πολύ μεγάλες παρουσιάσεις;**

Χρησιμοποιήστε τη διαχείριση BLOB όταν μεγάλες δυαδικές αντικειμενικές καταναλώνουν μνήμη, προτιμήστε τη φόρτωση από διαδρομές αρχείων για πολύ μεγάλα αρχεία, απελευθερώστε γρήγορα τις πηγές και αποθηκεύστε το τελικό αποτέλεσμα μόνο όταν είναι απαραίτητο.

**Μπορώ να κλωνοποιήσω διαφάνειες από πολλαπλά νήματα;**

Μην χρησιμοποιείτε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) ταυτόχρονα από πολλά νήματα. Κρατήστε κάθε λειτουργία συγχώνευσης απομονωμένη σε δικά της αντικείμενα παρουσίασης.