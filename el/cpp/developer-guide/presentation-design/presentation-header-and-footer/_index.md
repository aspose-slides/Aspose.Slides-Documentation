---
title: Διαχείριση Κεφαλίδων και Υποσέλιδων Παρουσίασης σε C++
linktitle: Κεφαλίδα και Υποσέλιδο
type: docs
weight: 140
url: /el/cpp/presentation-header-and-footer/
keywords:
- κεφαλίδα
- κείμενο κεφαλίδας
- υποσέλιδο
- κείμενο υποσέλιδου
- ορισμός κεφαλίδας
- ορισμός υποσέλιδου
- φυλλάδιο
- σημειώσεις
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τα σύμβολα κράτησης θέσης υποσέλιδου, ημερομηνίας-ώρας, αριθμού διαφάνειας και κεφαλίδας σε διαφάνειες, σελίδες σημειώσεων και φυλλάδια με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Το PowerPoint χρησιμοποιεί διαφορετικά σύμβολα κράτησης θέσης κεφαλίδας και υποσέλιδου ανάλογα με τον τύπο της σελίδας. Το Aspose.Slides για C++ σας επιτρέπει να ελέγχετε το κείμενο και την ορατότητα αυτών των συμβόλων κράτησης θέσης μέσω των διεπαφών διαχειριστή κεφαλίδας/υποσέλιδου.

Τα διαθέσιμα σύμβολα κράτησης θέσης εξαρτώνται από το πεδίο:

| Πεδίο | Κεφαλίδα | Υποσέλιδο | Ημερομηνία/Ώρα | Αριθμός διαφάνειας/σελίδας |
|---|---|---|---|---|
| Κανονική διαφάνεια | Όχι | Ναι | Ναι | Ναι |
| Υπόδειγμα σημειώσεων | Ναι | Ναι | Ναι | Ναι |
| Διαφάνεια σημειώσεων | Ναι | Ναι | Ναι | Ναι |
| Υπόδειγμα φυλλαδίου | Ναι | Ναι | Ναι | Ναι |

Μια κανονική διαφάνεια παρουσίασης δεν έχει σύμβολο κράτησης θέσης κεφαλίδας. Οι κεφαλίδες είναι διαθέσιμες σε σελίδες σημειώσεων και φυλλάδια. Για κανονικές διαφάνειες, χρησιμοποιήστε τα σύμβολα κράτησης θέσης υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας αντί για αυτό.

Το πεδίο μιας αλλαγής εξαρτάται από τον διαχειριστή που χρησιμοποιείτε. Η διεπαφή [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideheaderfootermanager/) ελέγχει μια κανονική διαφάνεια. Η διεπαφή [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/cpp/aspose.slides/inotesslideheaderfootermanager/) ελέγχει μια διαφάνεια σημειώσεων. Οι διαχειριστές master και layout μπορούν επίσης να διαδίδουν τις ρυθμίσεις σε εξαρτημένες διαφάνειες, ενώ η διεπαφή [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) ελέγχει το υπόδειγμα φυλλαδίου.

## **Ορισμός Υποσέλιδου, Ημερομηνίας/Ώρας και Αριθμών Διαφάνειας σε Κανονικές Διαφάνειες**

Για τις κανονικές διαφάνειες, η βασική ροή εργασίας είναι να αποκτήσετε πρόσβαση στο διαχειριστή κεφαλίδας/υποσέλιδου της κάθε διαφάνειας, να ορίσετε το κείμενο υποσέλιδου και ημερομηνίας/ώρας, να ενεργοποιήσετε τα απαιτούμενα σύμβολα κράτησης θέσης και να αποθηκεύσετε την παρουσίαση. Οι αριθμοί διαφανειών δημιουργούνται από την παρουσίαση, έτσι χρειάζεται μόνο να ελέγξετε την ορατότητά τους.

Χρησιμοποιήστε το [`SetFooterText`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) και το [`SetDateTimeText`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) για να ορίσετε το κείμενο, και χρησιμοποιήστε τα [`SetFooterVisibility`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/), και [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) για να εμφανίσετε τα αντίστοιχα σύμβολα κράτησης θέσης.

Το παρακάτω παράδειγμα από άκρο σε άκρο εφαρμόζει το ίδιο υποσέλιδο, κείμενο ημερομηνίας/ώρας και ορατότητα αριθμού διαφάνειας σε όλες τις κανονικές διαφάνειες:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

Αν χρειάζεται να ενημερώσετε μόνο μία διαφάνεια, αποκτήστε πρόσβαση σε αυτήν απευθείας μέσω του [`Presentation::get_Slide`](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_slide/) αντί να διατρέχετε ολόκληρη τη συλλογή διαφανειών.

## **Ορισμός Κεφαλίδων και Υποσέλιδων στο Υπόδειγμα Σημειώσεων**

Το υπόδειγμα σημειώσεων ορίζει κοινή μορφοποίηση και συμπεριφορά συμβόλων κράτησης θέσης για τις σελίδες σημειώσεων. Χρησιμοποιήστε τη διεπαφή [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasternotesslideheaderfootermanager/) όταν θέλετε να αλλάξετε μόνο το ίδιο το υπόδειγμα σημειώσεων.

Το παρακάτω παράδειγμα ορίζει την κεφαλίδα, το υποσέλιδο και το κείμενο ημερομηνίας/ώρας στο υπόδειγμα σημειώσεων και κάνει όλα τα υποστηριζόμενα σύμβολα κράτησης θέσης ορατά σε αυτό το υπόδειγμα:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

Η μέθοδος [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) επιστρέφει `nullptr` όταν η παρουσίαση δεν περιέχει υπόδειγμα σημειώσεων.

## **Εφαρμογή Ρυθμίσεων Υποδείγματος Σημειώσεων σε Υποδιαφάνειες Σημειώσεων**

Ένα υπόδειγμα σημειώσεων μπορεί να εφαρμόσει τις ρυθμίσεις κεφαλίδας και υποσέλιδου στον εαυτό του και σε όλες τις εξαρτημένες διαφάνειες σημειώσεων. Χρησιμοποιήστε τις ειδικές μεθόδους διάδοσης στη διεπαφή [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasternotesslideheaderfootermanager/) όταν οι ίδιες ρυθμίσεις πρέπει να εφαρμοστούν σε ολόκληρη τη ιεραρχία σημειώσεων.

Για παράδειγμα, τα [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) και [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) ενημερώνουν την κεφαλίδα του υποδείγματος σημειώσεων και όλες τις υποκεφαλίδες. Ισοδύναμες μέθοδοι είναι διαθέσιμες για υποσέλιδα, ημερομηνία/ώρα και αριθμούς διαφανειών.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

Οι μέθοδοι διάδοσης που χρησιμοποιήθηκαν παραπάνω είναι [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), και [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Ορισμός Κεφαλίδων και Υποσέλιδων σε Ατομική Διαφάνεια Σημειώσεων**

Μια διαφάνεια σημειώσεων ανήκει σε μια συγκεκριμένη κανονική διαφάνεια. Χρησιμοποιήστε τη διεπαφή της [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/cpp/aspose.slides/inotesslideheaderfootermanager/) όταν θέλετε να προσαρμόσετε μόνο αυτήν τη σελίδα σημειώσεων.

Η μέθοδος [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/el/cpp/aspose.slides/inotesslidemanager/addnotesslide/) επιστρέφει τη διαφάνεια σημειώσεων για τη τρέχουσα διαφάνεια και δημιουργεί μία εάν δεν υπάρχει ήδη. Το παρακάτω παράδειγμα διαμορφώνει τη σελίδα σημειώσεων που σχετίζεται με την πρώτη διαφάνεια της παρουσίασης:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

Αν πρώτα διαδώσετε τις ρυθμίσεις από το υπόδειγμα σημειώσεων και στη συνέχεια αλλάξετε μια ατομική διαφάνεια σημειώσεων, οι μεταγενέστερες ρυθμίσεις ανά διαφάνεια σας επιτρέπουν να προσαρμόσετε αυτήν τη σελίδα σημειώσεων αυτόνομα.

## **Ορισμός Κεφαλίδων και Υποσέλιδων στο Υπόδειγμα Φυλλαδίου**

Οι σελίδες φυλλαδίου χρησιμοποιούν το υπόδειγμα φυλλαδίου για τα σύμβολα κράτησης θέσης κεφαλίδας, υποσέλιδου, ημερομηνίας/ώρας και αριθμού σελίδας. Αντίθετα με τις σελίδες σημειώσεων, οι ρυθμίσεις του φυλλαδίου διαχειρίζονται μέσω του υποδείγματος φυλλαδίου και όχι μέσω ατομικών διαφανειών φυλλαδίου.

Χρησιμοποιήστε το [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) για να αποκτήσετε πρόσβαση στο υπόδειγμα φυλλαδίου. Εάν δεν είναι παρόν, καλέστε το [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) για να δημιουργήσετε το προεπιλεγμένο υπόδειγμα φυλλαδίου.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **Κατανόηση Πεδίου και Κληρονομικότητας**

Επιλέξτε τον διαχειριστή κεφαλίδας/υποσέλιδου που ταιριάζει με το πεδίο που θέλετε να αλλάξετε:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideheaderfootermanager/) αλλάζει τις ρυθμίσεις υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας για μία κανονική διαφάνεια.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslideheaderfootermanager/) ελέγχει μια διαφάνεια διάταξης και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτημένες διαφάνειες.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslideheaderfootermanager/) ελέγχει ένα κανονικό μάστερ διαφάνειας και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτημένες διαφάνειες.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasternotesslideheaderfootermanager/) ελέγχει το υπόδειγμα σημειώσεων και μπορεί να διαδώσει τις ρυθμίσεις σε όλες τις εξαρτημένες διαφάνειες σημειώσεων.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/cpp/aspose.slides/inotesslideheaderfootermanager/) αλλάζει μία διαφάνεια σημειώσεων και υποστηρίζει σύμβολο κράτησης θέσης κεφαλίδας επιπλέον του υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) αλλάζει το υπόδειγμα φυλλαδίου και υποστηρίζει όλους τους τέσσερις τύπους συμβόλων κράτησης θέσης.

Χρησιμοποιήστε τη διάδοση από ένα μάστερ ή διάταξη όταν η ίδια ρύθμιση πρέπει να ισχύει σε όλη τη ιεραρχία του. Χρησιμοποιήστε έναν ατομικό διαχειριστή διαφάνειας ή διαφάνειας σημειώσεων όταν χρειάζεστε τοπική ρύθμιση για μία σελίδα.

## **ΣΥΝΕΧΕΤΙΚΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να προσθέσω κεφαλίδα σε κανονική διαφάνεια;**

Όχι. Το PowerPoint δεν ορίζει σύμβολο κράτησης θέσης κεφαλίδας για τις κανονικές διαφάνειες. Σε κανονικές διαφάνειες, χρησιμοποιήστε τα σύμβολα κράτησης θέσης υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας. Τα σύμβολα κεφαλίδας είναι διαθέσιμα σε σελίδες σημειώσεων και φυλλάδια.

**Τι γίνεται αν ένα σύμβολο κράτησης θέσης υποσέλιδου, ημερομηνίας/ώρας ή αριθμού διαφάνειας δεν είναι ορατό;**

Χρησιμοποιήστε τον αντίστοιχο διαχειριστή κεφαλίδας/υποσέλιδου για να ελέγξετε την ορατότητά του και να τον ενεργοποιήσετε όταν χρειάζεται. Για παράδειγμα, το [`get_IsFooterVisible`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) αναφέρει αν υπάρχει σύμβολο υποσέλιδου, και το [`SetFooterVisibility`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) αλλάζει την ορατότητά του.

**Πώς μπορώ να ξεκινήσω την αρίθμηση των διαφανείων από τιμή διαφορετική από το 1;**

Χρησιμοποιήστε το [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/set_firstslidenumber/) για να ορίσετε τον πρώτο αριθμό διαφάνειας. Στη συνέχεια, τα σύμβολα αριθμού διαφάνειας θα χρησιμοποιούν τη νέα ακολουθία αρίθμησης.

**Τι συμβαίνει με τις κεφαλίδες και τα υποσέλιδα κατά την εξαγωγή σε PDF, εικόνες ή HTML;**

Τα ορατά στοιχεία κεφαλίδας και υποσέλιδου αποδίδονται μαζί με το υπόλοιπο περιεχόμενο της παρουσίασης στη μορφή εξόδου. Η εμφάνισή τους εξαρτάται από τον τύπο σελίδας που εξάγεται και τις αντίστοιχες ρυθμίσεις ορατότητας των συμβόλων κράτησης θέσης.