---
title: Διαχείριση ενοτήτων διαφανειών σε παρουσιάσεις με C++
linktitle: Ενότητα Διαφάνειας
type: docs
weight: 100
url: /el/cpp/slide-section/
keywords:
- δημιουργία ενότητας
- προσθήκη ενότητας
- επεξεργασία ενότητας
- αλλαγή ενότητας
- όνομα ενότητας
- ανάκτηση διαφανειών ενότητας
- επεξεργασία διαφανειών ενότητας
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε τις ενότητες διαφανειών με το Aspose.Slides για C++: δημιουργία, μετονομασία, επαναδιάταξη, ανάκτηση και επεξεργασία διαφανειών ενότητας σε παρουσιάσεις PPTX."
---
## **Εισαγωγή**

Οι ενότητες οργανώνουν διαδοχικές διαφάνειες σε ονομασμένες ομάδες χωρίς να αλλάζουν το περιεχόμενο της διαφάνειας. Με το Aspose.Slides για C++, μπορείτε να δημιουργήσετε, να αλλάξετε τη σειρά, να μετονομάσετε, να ελέγξετε και να διαγράψετε ενότητες μέσω της μεθόδου [Presentation::get_Sections](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_sections/) .

Οι ενότητες είναι ιδιαίτερα χρήσιμες όταν:

- μια μεγάλη παρουσίαση χρειάζεται να χωριστεί σε λογικά θέματα ή κεφάλαια·
- διαφορετικές ομάδες διαφανειών ανατίθενται σε διαφορετικούς συνεργάτες·
- οι διαφάνειες χρειάζεται να υποβληθούν σε επεξεργασία, μετακίνηση ή συνένωση ως ομάδες.

Επιλέξτε σύντομα ονόματα ενοτήτων που περιγράφουν τον σκοπό των ομαδοποιημένων διαφανειών. Επειδή οι ενότητες αποτελούν μέρος της δομής της παρουσίασης, χρησιμοποιήστε τα API ενοτήτων για να καθορίσετε τη συμμετοχή αντί να την προκύπτει από τις θέσεις των διαφανειών.

## **Δημιουργία και Διαχείριση Ενοτήτων**

Χρησιμοποιήστε το [ISectionCollection::AddSection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isectioncollection/addsection/) για να δημιουργήσετε μια ενότητα καθορίζοντας το όνομά της και τη διαφάνεια εκκίνησης. Το Aspose.Slides καθορίζει ποιες διαφάνειες ανήκουν στην ενότητα από την τρέχουσα δομή ενοτήτων της παρουσίασης.

Το ίδιο [ISectionCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isectioncollection/) σας επιτρέπει επίσης:

- να μετακινήσετε μια ενότητα μαζί με τις διαφάνειές της χρησιμοποιώντας το [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides/isectioncollection/reordersectionwithslides/) ;
- να αφαιρέσετε μόνο τον ορισμό της ενότητας με το [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isectioncollection/removesection/) , το οποίο διατηρεί τις διαφάνειές της ;
- να αφαιρέσετε μια ενότητα και τις διαφάνειές της με το [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides/isectioncollection/removesectionwithslides/) ;
- να προσθέσετε μια κενή ενότητα στο τέλος με το [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isectioncollection/appendemptysection/) .

Το παρακάτω παράδειγμα δημιουργεί δύο ενότητες, μετακινεί μία από αυτές, την αφαιρεί μαζί με τις διαφάνειές της και προσθέτει μια κενή ενότητα:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

Μετά από αυτές τις ενέργειες, η παρουσίαση περιέχει την ενότητα `Introduction` με τις διαφάνειές της και μια κενή ενότητα `Appendix`. Η ενότητα `Results` και οι διαφάνειές της έχουν αφαιρεθεί.

## **Μετονομασία Ενοτήτων**

Για να μετονομάσετε μια ενότητα, καλέστε το [ISection::set_Name](https://reference.aspose.com/slides/el/cpp/aspose.slides/isection/set_name/). Οι διαφάνειες και η θέση της ενότητας παραμένουν αμετάβλητες.

Το παρακάτω παράδειγμα δημιουργεί μια ενότητα και αλλάζει το όνομά της:

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **Ανάκτηση Διαφανειών από Ενότητες**

Η μέθοδος [Presentation::get_Sections](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_sections/) επιστρέφει ένα [ISectionCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isectioncollection/) , το οποίο μπορείτε να επαναλάβετε. Για κάθε [ISection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isection/) , καλέστε το [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isection/getslideslistofsection/) ώστε να λάβετε τις διαφάνειες που ανήκουν προς το παρόν σε αυτήν. Η μέθοδος επιστρέφει ένα [ISectionSlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isectionslidecollection/) , το οποίο παρέχει αριθμό, πρόσβαση με ευρετήριο και επανάληψη.

Το παρακάτω παράδειγμα δημιουργεί δύο γεμάτες ενότητες και μια κενή ενότητα, στη συνέχεια εκτυπώνει το [name](https://reference.aspose.com/slides/el/cpp/aspose.slides/isection/get_name/) , το [identifier](https://reference.aspose.com/slides/el/cpp/aspose.slides/isection/get_sectionid/) , τη [starting slide](https://reference.aspose.com/slides/el/cpp/aspose.slides/isection/get_startedfromslide/) , τον αριθμό διαφανειών και τους αριθμούς διαφανειών για κάθε ενότητα. Χρησιμοποιεί πρόσβαση με ευρετήριο για να διαβάσει την πρώτη διαφάνεια και έναν βρόχο `for` βασισμένο σε εύρος για να επεξεργαστεί κάθε διαφάνεια. Για την κενή ενότητα, η επιστρεφόμενη συλλογή έχει αριθμό μηδέν, δεν χρησιμοποιείται πρόσβαση με ευρετήριο και η επανάληψη δεν εκτελεί καμία επανάληψη.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

Η συμμετοχή στην ενότητα καθορίζεται από τη δομή ενοτήτων της παρουσίασης. Μην υπολογίζετε χειροκίνητα το εύρος μιας ενότητας από το [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/isection/get_startedfromslide/) , τους δείκτες διαφανειών και τη διαφάνεια εκκίνησης της επόμενης ενότητας.

Δομικές αλλαγές μπορούν να τροποποιήσουν τόσο τις διαφάνειες που επιστρέφονται για μια ενότητα όσο και τους αριθμούς τους. Αυτό περιλαμβάνει την αλλαγή σειράς διαφανειών, την κλωνοποίηση μιας διαφάνειας σε ενότητα, τη μετακίνηση μιας ενότητας μαζί με τις διαφάνειές της, την αφαίρεση διαφανειών και την αφαίρεση ενοτήτων. Το επόμενο παράδειγμα καλεί το [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isection/getslideslistofsection/) μετά από κάθε τέτοια αλλαγή αντί να διατηρεί υποθέσεις για τα πρώην όρια της ενότητας.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

Καλέστε το [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isection/getslideslistofsection/) ξανά όποτε διαφάνειες ή ενότητες επανατοποθετούνται, κλωνοποιούνται, μετακινούνται ή αφαιρούνται. Αυτό κρατά την επεξεργασία σύμφωνη με τη τρέχουσα δομή της παρουσίασης.

Η μορφή PPT (PowerPoint 97–2003) δεν διατηρεί τα μεταδεδομένα ενοτήτων. Χρησιμοποιήστε αυτήν τη ροή εργασίας με μια μορφή που υποστηρίζει ενότητες, όπως το PPTX· η μετατροπή σε PPT αφαιρεί τη δομή ενοτήτων που απαιτείται για μεταγενέστερη επανάληψη.

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι ενότητες κατά την αποθήκευση σε μορφή PPT (PowerPoint 97–2003);**

Όχι. Η μορφή PPT δεν υποστηρίζει μεταδεδομένα ενοτήτων, έτσι η ομαδοποίηση ενοτήτων χάνονται κατά την αποθήκευση σε .ppt.

**Μπορεί μια ολόκληρη ενότητα να "κρυφτεί";**

Όχι. Μια ενότητα δεν έχει κατάσταση ορατότητας. Για να κρύψετε τα περιεχόμενά της, καλέστε το [ISlide::set_Hidden](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/set_hidden/) για κάθε διαφάνεια στην ενότητα.

**Πώς μπορώ να βρω την ενότητα που περιέχει μια διαφάνεια;**

Επαναλάβετε το [Presentation::get_Sections](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_sections/) , καλέστε το [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isection/getslideslistofsection/) για κάθε ενότητα και συγκρίνετε τις επιστρεφόμενες διαφάνειες με τη διαφάνεια-στόχο. Για μια μη-κενή ενότητα, το [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/isection/get_startedfromslide/) επιστρέφει την πρώτη της διαφάνεια· για μια κενή ενότητα, επιστρέφει `nullptr`.