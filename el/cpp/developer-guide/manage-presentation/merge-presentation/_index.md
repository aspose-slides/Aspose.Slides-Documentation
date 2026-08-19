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
description: "Μάθετε πώς να συγχωνεύετε παρουσιάσεις PowerPoint και OpenDocument σε C++ κλωνοποιώντας διαφάνειες, ελέγχοντας masters και layouts, προσαρμόζοντας το μέγεθος του περιεχομένου των διαφανειών, διατηρώντας ενότητες και διαχειριζόμενοι προστατευμένα ή μεγάλα αρχεία."
---
## **Επισκόπηση**

Το Aspose.Slides for C++ συνενώ���ει παρουσιάσεις κλωνοποιώντας διαφάνειες από μία [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) σε άλλη. Η κύρια λειτουργία είναι το [ISlideCollection::AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/), το οποίο μπορεί να διατηρήσει τη μορφοποίηση της πηγής ή να συνδέσει τη κλωνοποιημένη διαφάνεια με ένα master ή layout στην προορισμένη παρουσίαση.

Αυτό το άρθρο καλύπτει τις πιο συνηθισμένες ροές εργασίας συγχώνευσης:

- συγχώνευση όλων των διαφανειών διατηρώντας τη μορφοποίηση της πηγής·
- συγχώνευση επιλεγμένων διαφανειών·
- εφαρμογή master από την προορισμένη παρουσίαση·
- εφαρμογή συγκεκριμένου layout από την προορισμένη παρουσίαση·
- εξομάλυνση διαφορετικών μεγεθών διαφανειών πριν τη συγχώνευση·
- προσθήκη κλωνοποιημένων διαφανειών σε ενότητα·
- συγχώνευση πολλαπλών παρουσιάσεων σε μία ολική ροή εργασίας·
- διαχείριση masters, πόρων, σημειώσεων, σχολίων, πολυμέσων, γραμματοσειρών, κωδικών πρόσβασης, μεγάλων αρχείων και θεμάτων πολυνηματικότητας.

## **Πώς η Κλωνοποίηση Διαφανειών Επηρεάζει Masters και Layouts**

Μια διαφάνεια κληρονομεί μεγάλο μέρος της εμφάνισής της από το layout και το master της. Για το λόγο αυτό, η υπερφόρτωση κλωνοποίησης που επιλέγετε καθορίζει πώς η συγκερασμένη διαφάνεια ενσωματώνεται στην προορισμένη παρουσίαση.

Χρησιμοποιήστε το [ISlideCollection::AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) με έναν από τους ακόλουθους τρόπους:

- `AddClone(sourceSlide)` — διατηρεί το layout και τη μορφοποίηση της πηγής. Αν χρειαστεί, το master της πηγής μπορεί να κλωνοποιηθεί αυτόματα στην προορισμένη παρουσίαση. Το Aspose.Slides παρακολουθεί αυτόματα κλωνοποιημένα masters ώστε διαδοχικές διαφάνειες που χρησιμοποιούν το ίδιο master πηγής να μην το κλωνοποιούν ξανά.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — συνδέει τη κλωνοποιημένη διαφάνεια με ένα συγκεκριμένο προορισμένο [IMasterSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslide/). Το Aspose.Slides ψάχνει για ένα ταιριαστό layout κάτω από το master αυτό με βάση τον τύπο ή το όνομα του layout.
- `AddClone(sourceSlide, destinationLayout)` — συνδέει τη κλωνοποιημένη διαφάνεια άμεσα με ένα συγκεκριμένο προορισμένο [ILayoutSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/).

Το master ή layout που περνιέται σε μια υπερφόρτωση `AddClone` πρέπει να ανήκει στην **προορισμένη** παρουσίαση, όχι στην πηγή.

## **Συγχώνευση Ολόκληρων Παρουσιάσεων και Διατήρηση Μορφοποίησης Πηγής**

Η απλούστερη συγχώνευση αντιγράφει κάθε διαφάνεια από την πηγή στην προορισμένη παρουσίαση. Αυτή είναι η κατάλληλη επιλογή όταν οι εισαγόμενες διαφάνειες πρέπει να διατηρήσουν το αρχικό τους θέμα, master και σχέσεις layout.

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

Η προκύπτουσα παρουσίαση μπορεί να περιέχει πολλαπλά masters όταν η πηγή και ο προορισμός χρησιμοποιούν διαφορετικά σχέδια. Αυτό είναι αναμενόμενο όταν η μορφοποίηση της πηγής διατηρείται σκόπιμα.

## **Συγχώνευση Επιλεγμένων Διαφανειών**

Δεν χρειάζεται να κλωνοποιήσετε κάθε διαφάνεια. Το παρακάτω παράδειγμα εισάγει μόνο τους επιλεγμένους δείκτες διαφανειών από την πηγή.

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

Επικυρώστε τους δείκτες διαφανειών πριν την κλωνοποίηση όταν προέρχονται από είσοδο χρήστη ή εξωτερική ρύθμιση.

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

Το Aspose.Slides επιλέγει ένα κατάλληλο layout κάτω από το καθορισμένο master αντιστοιχίζοντας τον τύπο ή το όνομα του layout προέλευσης. Αν δεν υπάρχει κατάλληλο layout και το `allowCloneMissingLayout` είναι `true`, το layout προέλευσης κλωνοποιείται ώστε η διαφάνεια να προστεθεί. Αν είναι `false`, πετιέται μια [PptxEditException](https://reference.aspose.com/slides/el/cpp/aspose.slides/details_pptxeditexception/).

Χρησιμοποιήστε `false` όταν θέλετε η συγχώνευση να αποτύχει αντί να προσθέτει ένα επιπλέον layout στο master προορισμού.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Συγκεκριμένο Layout Προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) όταν γνωρίζετε ακριβώς ποιο layout προορισμού πρέπει να χρησιμοποιήσουν οι εισαγόμενες διαφάνειες.

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

Η εφαρμογή ενός layout προορισμού αλλάζει τη σχέση κληρονομικού layout· δεν αλλάζει το περιεχόμενο της πηγής. Αν τα layout πηγής και προορισμού έχουν διαφορετικές δομές placeholders, εξετάστε το αποτέλεσμα για να επιβεβαιώσετε ότι η κληρονομημένη μορφοποίηση και η συμπεριφορά των placeholders είναι κατάλληλες.

## **Συγχώνευση Παρουσιάσεων με Διαφορετικά Μεγέθη Διαφανειών**

Παρουσιάσεις με διαφορετικές διαστάσεις διαφάνειας μπορούν να συγχωνευτούν, αλλά η κλωνοποίηση μιας διαφάνειας σε παρουσίαση με άλλο μέγεθος δεν επανασχεδιάζει αυτόματα το περιεχόμενό της για το νέο καμβά. Τα σχήματα μπορεί να εμφανιστούν μετατοπισμένα, κλιμακωμένα απρόσμενα ή εκτός του ορατού χώρου διαφάνειας.

Μια πρακτική προσέγγιση είναι να αλλάξετε το μέγεθος της πηγής πριν την κλωνοποίηση. Η μέθοδος [SlideSize::SetSize](https://reference.aspose.com/slides/el/cpp/aspose.slides/slidesize/setsize/) μπορεί να κλιμακώσει το υπάρχον περιεχόμενο ενώ αλλάζει τις διαστάσεις της διαφάνειας. Το [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/el/cpp/aspose.slides/slidesizescaletype/) κλιμακώνει το περιεχόμενο ώστε να ταιριάζει στο ζητούμενο μέγεθος.

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

Η αλλαγή μεγέθους τροποποιεί το αντικείμενο της πηγής στη μνήμη. Αν χρειάζεστε την αρχική παρουσίαση αμετάβλητη για άλλες λειτουργίες, ανοίξτε ένα ξεχωριστό αντίτυπο για τη συγχώνευση.

## **Συγχώνευση Διαφανειών σε Ενότητα Παρουσίασης**

Ο βασικός βρόχος κλωνοποίησης διαφανειών δεν δημιουργεί ξανά την ιεραρχία ενότητων της πηγής. Αν οι ενότητες είναι σημαντικές στο τελικό αποτέλεσμα, δημιουργήστε ή επιλέξτε ενότητες στην προορισμένη παρουσίαση και κλωνοποιήστε τις διαφάνειες σε αυτές ρητά με το [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/).

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

Οι κλωνοποιημένες διαφάνειες προστίθενται στην καθορισμένη ενότητα προορισμού. Για να διατηρήσετε πολλές ενότητες πηγής, δημιουργήστε αυτές τις ενότητες στην προορισμένη παρουσίαση και αντιστοιχίστε κάθε διαφάνεια πηγής στην αντίστοιχη ενότητα προορισμού.

## **Συγχώνευση Πολλών Παρουσιάσεων με Ασφάλεια**

Το παρακάτω παράδειγμα πλήρους ροής χρησιμοποιεί την πρώτη παρουσίαση ως προορισμό, εξομαλύνει το μέγεθος διαφάνειας κάθε επιπλέον πηγής, διατηρεί κάθε πηγή ανοιχτή μόνο κατά τη διάρκεια της αντιγραφής και αποθηκεύει το τελικό αρχείο μία φορά.

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

Αυτή είναι μια χρήσιμη βάση για τη διατήρηση της μορφοποίησης της πηγής στις εισαγόμενες διαφάνειες. Αν το αποτέλεσμα πρέπει να χρησιμοποιεί ένα ενιαίο θέμα προορισμού, αντικαταστήστε την απλή κλήση `AddClone(slide)` με την κατάλληλη υπερφόρτωση master ή layout προορισμού που φαίνεται παραπάνω.

## **Πρακτικές Σκέψεις**

### **Masters, Layouts και Πιστότητα Μορφοποίησης**

Η προεπιλεγμένη κλωνοποίηση διαφανειών μπορεί αυτόματα να φέρει ένα απαιτούμενο master πηγής στην προορισμένη παρουσίαση. Το Aspose.Slides διατηρεί ένα εσωτερικό μητρώο για αυτόματα κλωνοποιημένα masters ώστε να αποφεύγεται η επαναληπτική κλωνοποίηση του ίδιου master. Τα χειροκίνητα κλωνοποιημένα masters δεν παρακολουθούνται από αυτό το μητρώο, οπότε αποφύγετε την προ-κλωνοποίηση masters εκτός αν χρειάζεστε άμεσο έλεγχο της δομής του master.

Μην υποθέτετε ότι δύο masters ή layouts με το ίδιο όνομα είναι οπτικά ισοδύναμα. Αν ένα εταιρικό πρότυπο πρέπει να ελέγχει την τελική εμφάνιση, επιλέξτε ρητά ένα master ή layout προορισμού και επαληθεύστε το αποτέλεσμα μετά τη συγχώνευση.

### **Σημειώσεις και Σχόλια**

Οι σημειώσεις ομιλητή και τα σχόλια διαφανειών συνδέονται με το περιεχόμενο της διαφάνειας και αντιγράφονται όταν κλωνοποιείται η διαφάνεια. Το Aspose.Slides προσφέρει επίσης εξειδικευμένα API για [σημειώσεις παρουσίασης](https://docs.aspose.com/slides/el/cpp/presentation-notes/) και [σχόλια παρουσίασης](https://docs.aspose.com/slides/el/cpp/presentation-comments/).

Αν η μορφοποίηση της σελίδας σημειώσεων είναι σημαντική, ελέγξτε τη συγχωνευμένη παρουσίαση επειδή τα masters σημειώσεων είναι αντικείμενα επιπέδου παρουσίασης και μπορεί να διαφέρουν μεταξύ των πηγών. Για ροές ελέγχου, επαληθεύστε επίσης τους συγγραφείς σχολίων και τα νήματα σχολίων μετά την ένωση αρχείων από διαφορετικούς συγγραφείς ή πρότυπα.

### **Εικόνες, Ήχος, Βίντεο, Αντικείμενα OLE και Εξωτερικοί Σύνδεσμοι**

Οι διαφάνειες μπορούν να αναφέρονται σε πόρους επιπέδου παρουσίασης όπως εικόνες, ενσωματωμένο ήχο, ενσωματωμένο βίντεο και δεδομένα OLE. Κλωνοποιήστε τη διαφάνεια ολόκληρη αντί να αντιγράφετε μόνο τα ορατά σχήματα ώστε το Aspose.Slides να διατηρήσει τις σχέσεις της διαφάνειας με τους πόρους της.

Οι ενσωματωμένοι και οι συνδεδεμένοι πόροι πρέπει να αντιμετωπίζονται διαφορετικά. Ένας συνδεδεμένος ήχος, βίντεο, αντικείμενο OLE ή υπερσύνδεσμος παραμένει εξαρτημένος από τον εξωτερικό του προορισμό· η κλωνοποίηση μιας διαφάνειας δεν μετατρέπει έναν εξωτερικό σύνδεσμο σε ενσωματωμένο περιεχόμενο. Ελέγξτε τις διαδρομές και τις URL των συνδεδεμένων πόρων στο περιβάλλον όπου θα ανοιχτεί η συγχωνευμένη παρουσίαση.

Το Aspose.Slides παρακολουθεί αυτόματα τα κλωνοποιημένα masters, αλλά αυτό δεν πρέπει να θεωρείται γενική εγγύηση ότι τα ίδια δυαδικά αρχεία από ανεξάρτητες παρουσιάσεις θα αφαιρεθούν αυτόματα. Αν το μέγεθος του αρχείου εξόδου είναι σημαντικό, εξετάστε το τελικό πακέτο και μετρήστε το αποτέλεσμα αντί να βασίζεστε στην έμμεση αφαίρεση διπλοτύπων.

### **Ενσωματωμένες Γραμματοσειρές και Διαθεσιμότητα Γραμματοσειρών**

Οι γραμματοσειρές διαχειρίζονται σε επίπεδο παρουσίασης. Αν η τυπογραφία πρέπει να παραμείνει συνεπής μεταξύ υπολογιστών, μην υποθέτετε ότι η κλωνοποίηση διαφανειών μόνο εγγυάται ότι κάθε απαιτούμενη γραμματοσειρά είναι διαθέσιμη στο περιβάλλον προορισμού. Μπορείτε να ελέγξετε τις ενσωματωμένες γραμματοσειρές με το [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/getembeddedfonts/) και να διαχειριστείτε την ενσωμάτωση όπως περιγράφεται στο [Ενσωμάτωση Γραμματοσειρών σε Παρουσιάσεις](https://docs.aspose.com/slides/el/cpp/embedded-font/).

Επιβεβαιώστε επίσης ότι έχετε άδεια να ενσωματώσετε τις γραμματοσειρές που χρησιμοποιούνται στα αρχεία πηγής. Οι άδειες γραμματοσειρών ενδέχεται να περιορίζουν την ενσωμάτωση.

### **Παρουσιάσεις με Κωδικό Πρόσβασης**

Μια πηγή με κωδικό πρόσβασης πρέπει να ανοίξει με επιτυχία πριν κλωνοποιηθούν οι διαφάνειές της. Παρέχετε τον κωδικό μέσω του [LoadOptions::set_Password](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Το άνοιγμα ενός κρυπτογραφημένου αρχείου δεν εφαρμόζει αυτόματα την ίδια προστασία στην προορισμένη παρουσίαση. Ρυθμίστε την προστασία εξόδου ξεχωριστά όταν απαιτείται.

### **Μεγάλες Παρουσιάσεις και Χρήση Μνήμης**

Μεγάλες παρουσιάσεις που περιέχουν εικόνες υψηλής ανάλυσης, ήχο, βίντεο ή άλλα μεγάλα δυαδικά αντικείμενα μπορούν να καταναλώσουν σημαντική μνήμη. Το [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) παρέχει ελέγχους για τη διαχείριση BLOB και τη χρήση προσωρινών αρχείων. Δείτε το [Διαχείριση BLOB Παρουσίασης](https://docs.aspose.com/slides/el/cpp/manage-blob/) για στρατηγικές μεγάλων αρχείων.

Για μεγάλα αρχεία, προτιμήστε τη φόρτωση από διαδρομές αρχείων όταν είναι δυνατόν, αποδεσμεύστε κάθε πηγή παρουσίασης μόλις ολοκληρωθεί η συγχώνευση και αποφύγετε την επαναλαμβανόμενη αποθήκευση ενδιάμεσων αποτελεσμάτων εκτός αν η ροή εργασίας απαιτεί σημεία ελέγχου.

### **Ασφάλεια Πολυνηματικότητας**

Μην φορτώνετε, τροποποιείτε, αποθηκεύετε ή κλώνετε το ίδιο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) παράλληλα από πολλαπλά νήματα. Κρατήστε κάθε παρουσίαση περιορισμένη σε μια λειτουργία συγχώνευσης. Αν παράγετε ανεξάρτητες εργασίες παράλληλα, χρησιμοποιήστε ανεξάρτητα αντίτυπα παρουσίασης και ακολουθήστε τις οδηγίες πολυνηματικότητας του [Aspose.Slides](https://docs.aspose.com/slides/el/cpp/multithreading/).

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διατηρήσω το αρχικό σχέδιο κάθε παρουσίασης πηγής;**

Χρησιμοποιήστε το [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) χωρίς να περάσετε master ή layout προορισμού. Το Aspose.Slides μπορεί αυτόματα να κλωνοποιήσει το master πηγής όταν απαιτείται από τη διαφάνεια.

**Πώς κάνω τις εισαγόμενες διαφάνειες να χρησιμοποιούν το θέμα προορισμού;**

Χρησιμοποιήστε την υπερφόρτωση που δέχεται ένα master προορισμού. Περάστε ένα master από την προορισμένη παρουσίαση, όχι από την πηγή. Το Aspose.Slides θα προσπαθήσει να αντιστοιχίσει κάθε διαφάνεια πηγής σε ένα κατάλληλο layout κάτω από αυτό το master.

**Πότε πρέπει να χρησιμοποιήσω συγκεκριμένο layout προορισμού αντί για master;**

Χρησιμοποιήστε ένα συγκεκριμένο layout όταν κάθε εισαγόμενη διαφάνεια πρέπει να χρησιμοποιεί ένα γνωστό layout. Χρησιμοποιήστε master όταν θέλετε το Aspose.Slides να επιλέγει μεταξύ των layout του master βάσει του τύπου ή του ονόματος του layout πηγής.

**Μπορούν να συγχωνευτούν παρουσιάσεις με διαφορετικά μεγέθη διαφάνειας;**

Ναι, αλλά το περιεχόμενο της διαφάνειας δεν επανασχεδιάζεται αυτόματα για τις διαστάσεις προορισμού. Αλλάξτε το μέγεθος της πηγής πρώτα όταν χρειάζεστε προβλέψιμη τοποθέτηση, π.χ. με το [SlideSize::SetSize](https://reference.aspose.com/slides/el/cpp/aspose.slides/slidesize/setsize/) και το [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/el/cpp/aspose.slides/slidesizescaletype/).

**Μπορώ να συγχωνεύσω αρχεία PPT, PPTX και ODP σε ένα αρχείο;**

Ναι. Φορτώστε κάθε παρουσίαση πηγής, κλωνοποιήστε τις απαιτούμενες διαφάνειες σε ένα προορισμό και αποθηκεύστε την προορισμένη παρουσίαση σε μια υποστηριζόμενη μορφή εξόδου. Επειδή οι μορφές παρουσίασης δεν υποστηρίζουν ακριβώς το ίδιο σύνολο λειτουργιών, ελέγξτε το σύνθετο περιεχόμενο μετά από συγχωνεύσεις μεταξύ διαφορετικών μορφών. Δείτε τα [Υποστηριζόμενα Μορφότυπα Αρχείων](https://docs.aspose.com/slides/el/cpp/supported-file-formats/).

**Διατηρούνται αυτόματα οι ενότητες πηγής;**

Όχι, σε έναν βασικό βρόχο που κλωνοποιεί μόνο διαφάνειες. Δημιουργήστε τις απαιτούμενες ενότητες στην προορισμένη παρουσίαση και χρησιμοποιήστε την υπερφόρτωση ενότητας του [AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) όταν η δομή ενότητας πρέπει να διατηρηθεί.

**Διατηρούνται οι σημειώσεις ομιλητή και τα σχόλια;**

Αντιγράφονται με την κλωνοποιημένη διαφάνεια. Για ροές που εξαρτώνται από τη μορφοποίηση του notes-master, τους συγγραφείς σχολίων ή τα νήματα ανασκόπησης, επαληθεύστε το τελικό αποτέλεσμα, καθώς τα σενάρια αυτά αφορούν δομές επιπέδου παρουσίασης καθώς και περιεχόμενο διαφάνειας.

**Τι συμβαίνει με ήχο, βίντεο, αντικείμενα OLE και υπερσυνδέσμους;**

Το ενσωματωμένο περιεχόμενο μεταφέρεται ως μέρος των σχέσεων πόρων της κλωνοποιημένης διαφάνειας. Οι εξωτερικοί σύνδεσμοι παραμένουν εξωτερικοί, επομένως τα αρχεία ή οι URLs προορισμού πρέπει να είναι διαθέσιμα μετά τη συγχώνευση.

**Εγγυάνονται οι ενσωματωμένες γραμματοσειρές από κάθε πηγή στην τελική παρουσίαση;**

Μην βασίζεστε μόνο στην κλωνοποίηση διαφανειών για την υλοποίηση γραμματοσειρών. Ελέγξτε τις ενσωματωμένες γραμματοσειρές του προορισμού και διαχειριστείτε ρητά την ενσωμάτωση ή τη διαθεσιμότητα εξωτερικών γραμματοσειρών όταν η τυπογραφία είναι κρίσιμη.

**Πώς συγχωνεύω ένα αρχείο με κωδικό προστασίας;**

Ανοίξτε το με το κατάλληλο [LoadOptions::set_Password](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_password/), στη συνέχεια κλωνοποιήστε τις διαφάνειες κανονικά. Η προστασία εξόδου ρυθμίζεται ξεχωριστά.

**Πώς πρέπει να διαχειριστώ πολύ μεγάλες παρουσιάσεις;**

Χρησιμοποιήστε διαχείριση BLOB όταν τα μεγάλα δυαδικά αντικείμενα κυριαρχούν στη χρήση μνήμης, προτιμήστε τη φόρτωση από διαδρομές αρχείων για τεράστια αρχεία, απελευθερώστε τις πηγές παρουσίασης άμεσα και αποθηκεύστε το τελικό αποτέλεσμα μόνο όταν είναι απαραίτητο.

**Μπορώ να κλωνοποιήσω διαφάνειες από πολλαπλά νήματα;**

Μην χρησιμοποιείτε το ίδιο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) παράλληλα από πολλά νήματα. Κρατήστε κάθε λειτουργία συγχώνευσης απομονωμένη σε δικά της αντίτυπα παρουσίασης.