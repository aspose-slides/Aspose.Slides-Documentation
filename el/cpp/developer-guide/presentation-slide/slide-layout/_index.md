---
title: Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας σε C++
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/cpp/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- δεσμευτική θέση
- σχεδίαση παρουσίασης
- σχεδίαση διαφάνειας
- αχρησιμοποίητη διάταξη
- ορατότητα υποσέλιδου
- διαφάνεια τίτλου
- τίτλος και περιεχόμενο
- κεφαλίδα ενότητας
- δύο περιεχόμενα
- σύγκριση
- μόνο τίτλος
- κενή διάταξη
- περιεχόμενο με λεζάντα
- εικόνα με λεζάντα
- τίτλος και κατακόρυφο κείμενο
- κατακόρυφος τίτλος και κείμενο
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εφαρμόστε, δημιουργήστε και τροποποιήστε διατάξεις διαφάνειας στο Aspose.Slides για C++, προσθέστε δεσμευτικές θέσεις, αφαιρέστε αχρησιμοποίητες διατάξεις και ελέγξτε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Μια διάταξη διαφάνειας ορίζει τις θέσεις και τη μορφοποίηση των δεσμευτικών θέσεων όπως τίτλοι, κείμενο, εικόνες, διαγράμματα και πίνακες. Η εφαρμογή μιας διάταξης παρέχει στις διαφάνειες μια συνεπής δομή, ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Οι πιο συχνές διατάξεις περιλαμβάνουν:

- **Title Slide**: Περιέχει δεσμευτικές θέσεις τίτλου και υποτίτλου.
- **Title and Content**: Περιέχει μια δεσμευτική θέση τίτλου και μια γενική δεσμευτική θέση περιεχομένου.
- **Blank**: Δεν περιέχει δεσμευτικές θέσεις περιεχομένου και είναι χρήσιμη όταν κάθε σχήμα θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση Κληρονομικότητας Διατάξεων**

Μια παρουσίαση έχει τρία σχετιζόμενα επίπεδα:

1. Ένα [master slide](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslide/) καθορίζει το θέμα, τη κοινή μορφοποίηση, τα παρασκήνια και τα κοινά αντικείμενα.
2. Ένα [layout slide](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/) ανήκει σε ένα master και καθορίζει μια συγκεκριμένη διάταξη δεσμευτικών θέσεων.
3. Μια [normal slide](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/) χρησιμοποιεί μία διάταξη και αποθηκεύει το περιεχόμενο που εισήχθη για εκείνη τη διαφάνεια.

Μια κανονική διαφάνεια κληρονομεί το θέμα και τη μορφοποίηση από τη διάταξή της, ενώ η διάταξη κληρονομεί από το master της. Μια τιμή που ορίζεται απευθείας σε μια κανονική διαφάνεια αντικαθιστά την κληρονομημένη τιμή σε αυτό το επίπεδο. Όταν δημιουργείται μια κανονική διαφάνεια, τα σχήματα των δεσμευτικών θέσεων δημιουργούνται από την επιλεγμένη διάταξη, ενώ το περιεχόμενο που εισάγεται σε αυτές τις δεσμευτικές θέσεις ανήκει στη κανονική διαφάνεια.

Προσθέστε τις απαιτούμενες δεσμευτικές θέσεις σε μια διάταξη πριν δημιουργήσετε διαφάνειες από αυτήν. Η προσθήκη μιας επιπλέον δεσμευτικής θέσης σε μια διάταξη αργότερα δεν προσθέτει αυτόματα το αντίστοιχο σχήμα δεσμευτικής θέσης στις υπάρχουσες κανονικές διαφάνειες.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Η αλλαγή κληρονομημένης μορφοποίησης ή της γεωμετρίας των υπαρχουσών δεσμευτικών θέσεων σε μια διάταξη μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτήν. Πριν επεξεργαστείτε μια διάταξη που ήδη χρησιμοποιείται, ελέγξτε τις εξαρτημένες διαφάνειες και επανεξετάστε την παράγόμενη παρουσίαση.
- Μια διάταξη που εξακολουθεί να χρησιμοποιείται από μία διαφάνεια δεν μπορεί να αφαιρεθεί. Αναθέστε πρώτα τις εξαρτημένες διαφάνειες σε άλλη διάταξη ή αφαιρέστε μόνο τις αχρησιμοποίητες διατάξεις.

Για περισσότερες πληροφορίες σχετικά με το υψηλότερο επίπεδο αυτής της ιεραρχίας, δείτε [Slide Master](/slides/el/cpp/slide-master/).

Για να αποκρύψετε κληρονομημένα λογότυπα ή διακοσμητικά σχήματα master σε μια διαφάνεια ή μέσω κοινής διάταξης, δείτε [Control the Visibility of Master Graphics](/slides/el/cpp/slide-master/). Το παράδειγμα συγκρίνει δύο διαφάνειες που χρησιμοποιούν το ίδιο master.

## **Επιλογή και Εφαρμογή Διάταξης Διαφάνειας**

Χρησιμοποιήστε έναν τύπο διάταξης όταν η παρουσίαση ακολουθεί τις τυπικές ορισμούς διάταξης του PowerPoint. Τα ονόματα των διατάξεων μπορούν να επεξεργαστούν από τον χρήστη και να μεταφραστούν, επομένως η επιλογή με βάση το όνομα είναι λιγότερο αξιόπιστη εκτός αν ελέγχετε το πρότυπο προέλευσης.

Το παρακάτω παράδειγμα ψάχνει για **Title and Content** στο πρώτο master. Αν αυτή η διάταξη δεν είναι διαθέσιμη, επιστρέφει σκόπιμα στην **Blank**. Ο δεύτερος έλεγχος null είναι απαραίτητος επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένες διατάξεις. Η επιλεγμένη διάταξη εφαρμόζεται στη πρώτη κανονική διαφάνεια μέσω της [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/set_layoutslide/) μεθόδου.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η αλλαγή της διάταξης μιας διαφάνειας δεν αφαιρεί τα απλά σχήματα που προστέθηκαν απευθείας στη διαφάνεια. Ωστόσο, οι θέσεις των δεσμευτικών θέσεων, η κληρονομημένη μορφοποίηση και η αντιστοιχία μεταξύ των υπαρχουσών δεσμευτικών θέσεων και της νέας διάταξης μπορεί να αλλάξουν, επομένως ελέγξτε το αποτέλεσμα όταν εναλλάσσετε μεταξύ σημαντικά διαφορετικών διατάξεων.

## **Προσθήκη Διάταξης Διαφάνειας**

Η επιλογή και η δημιουργία είναι ξεχωριστές λειτουργίες. Το προηγούμενο παράδειγμα επιλέγει μια υπάρχουσα διάταξη· δεν τη δημιουργεί. Για να δημιουργήσετε μια διάταξη, καλέστε τη μέθοδο [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterlayoutslidecollection/add/) στη συλλογή διατάξεων του στοχευόμενου master.

Το παρακάτω παράδειγμα προσθέτει πάντα μια νέα διάταξη **Title and Content** με όνομα `Report Title and Content`, στη συνέχεια προσθέτει μια κανονική διαφάνεια βασισμένη σε αυτήν. Τα ονόματα των διατάξεων πρέπει να είναι μοναδικά μέσα στη συλλογή.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Προσθέστε μια διάταξη μόνο όταν το πρότυπο πραγματικά χρειάζεται μια επιπλέον επαναχρησιμοποιήσιμη δομή. Αν υπάρχει ήδη κατάλληλη διάταξη, επιλέξτε και χρησιμοποιήστε την ξανά αντί να δημιουργήσετε αντίγραφο.

## **Προσθήκη Δεσμευτικών Θέσεων σε Διάταξη Διαφάνειας**

Η [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) μέθοδος παρέχει έναν [ILayoutPlaceholderManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/) για την προσθήκη σχημάτων δεσμευτικών θέσεων σε μια διάταξη.

| Δεσμευτική Θέση PowerPoint | `ILayoutPlaceholderManager` Method |
| --------------------------- | ---------------------------------- |
| ![Περιεχόμενο](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Περιεχόμενο (Κατακόρυφο)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Κείμενο](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Κείμενο (Κατακόρυφο)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Εικόνα](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Διάγραμμα](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Πίνακας](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Μέσα](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Το παρακάτω παράδειγμα ελέγχει ότι η **Blank** διάταξη υπάρχει, προσθέτει τέσσερις δεσμευτικές θέσεις σε αυτήν, και στη συνέχεια δημιουργεί μια κανονική διαφάνεια που χρησιμοποιεί τη τροποποιημένη διάταξη. Η σειρά είναι σκόπιμη: οι δεσμευτικές θέσεις προστίθενται πριν δημιουργηθεί η κανονική διαφάνεια, ώστε το Aspose.Slides να μπορεί να δημιουργήσει τα αντίστοιχα σχήματα δεσμευτικής θέσης σε εκείνη τη διαφάνεια.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι δεσμευτικές θέσεις στη διάταξη διαφάνειας](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Η αλλαγή κληρονομημένης μορφοποίησης ή της γεωμετρίας των υπαρχουσών δεσμευτικών θέσεων σε μια διάταξη μπορεί να επηρεάσει τις εξαρτημένες διαφάνειες. Μια νεοπροστέθηκε δεσμευτική θέση στη διάταξη δεν προστίθεται αυτόματα σε υπάρχουσες κανονικές διαφάνειες. Δοκιμάστε τις αλλαγές διάταξης σε αντίγραφο της παρουσίασης και ελέγξτε κάθε εξαρτημένη διαφάνεια.
{{% /alert %}}

## **Αφαίρεση Μη Χρησιμοποιημένων Διατάξεων Διαφάνειας**

Χρησιμοποιήστε τη μέθοδο [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) για να αφαιρέσετε διατάξεις που δεν αναφέρονται από καμία κανονική διαφάνεια. Η μέθοδος αφήνει αμετάβλητες τις διατάξεις που είναι ακόμη σε χρήση.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Για να αφαιρέσετε μια συγκεκριμένη διάταξη, πρώτα χρησιμοποιήστε τη μέθοδο [get_HasDependingSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) ή τη μέθοδο [GetDependingSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/getdependingslides/). Αναθέστε τυχόν εξαρτημένες διαφάνειες πριν καλέσετε το [ILayoutSlide::Remove](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/remove/). Η προσπάθεια αφαίρεσης μιας χρήσης διάταξης προκαλεί ένα [PptxEditException](https://reference.aspose.com/slides/el/cpp/aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδου σε Διάταξη Διαφάνειας**

Μια διάταξη έχει το δικό της υποσέλιδο, αριθμό διαφάνειας και δεσμευτικές θέσεις ημερομηνίας‑ώρας. Χρησιμοποιήστε τη μέθοδο [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) για να ελέγξετε αυτές τις δεσμευτικές θέσεις για μία διάταξη. Αυτό είναι χρήσιμο όταν, για παράδειγμα, οι διατάξεις περιεχομένου πρέπει να εμφανίζουν υποσέλιδα ενώ οι διατάξεις τίτλου όχι.

Το παρακάτω παράδειγμα επιλέγει με ασφάλεια μια διάταξη και κάνει τα στοιχεία του υποσέλιδου ορατά:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Έλεγχος Ορατότητας Υποσέλιδου σε Master και στα Παιδικά του Διατάξεις**

Για να εφαρμόσετε σταθερές ρυθμίσεις υποσέλιδου σε όλη τη ιεραρχία ενός master, χρησιμοποιήστε τη μέθοδο [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Οι μέθοδοι διάδοσης του [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslideheaderfootermanager/) λειτουργούν στο master και στις εξαρτημένες διατάξεις και τις κανονικές διαφάνειες· δεν στοχεύουν μόνο σε μια κανονική διαφάνεια.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Ποια είναι η Διαφορά μεταξύ Master Slide και Layout Slide;**

Ένα master slide ορίζει το θέμα και τη κοινή μορφοποίηση της παρουσίασης. Μια layout slide ανήκει σε ένα master και καθορίζει μία επαναχρησιμοποιήσιμη διάταξη δεσμευτικών θέσεων. Οι κανονικές διαφάνειες χρησιμοποιούν αυτές τις διατάξεις και αποθηκεύουν το περιεχόμενο της συγκεκριμένης διαφάνειας.

**Μπορώ να Αντιγράψω μια Layout Slide από μία Παρουσίαση σε Άλλη;**

Ναι. Προσθέστε ένα αντίγραφο στη συλλογή προορισμού με τη μέθοδο [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Κατά την αντιγραφή μεταξύ παρουσιάσεων, ελέγξτε επίσης γραμματοσειρές, θέματα, εικόνες και άλλους πόρους που χρησιμοποιεί η πηγή διάταξης.

**Τι Συμβαίνει όταν Τροποποιήσω μια Διάταξη που Είναι Ήδη σε Χρήση;**

Οι εξαρτημένες διαφάνειες κληρονομούν τις αλλαγές στη διάταξη, εκτός αν έχουν παρακάμψει τη μορφοποίηση ή τα αντικείμενα τοπικά. Η γεωμετρία των δεσμευτικών θέσεων και η κληρονομημένη μορφοποίηση μπορούν επομένως να αλλάξουν σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήστε το [GetDependingSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/getdependingslides/) για να εντοπίσετε τις επηρεαζόμενες διαφάνειες πριν επεξεργαστείτε τη διάταξη.

**Τι Συμβαίνει αν Αφαιρέσω μια Διάταξη που Είναι Ακόμη σε Χρήση;**

Το Aspose.Slides ρίχνει ένα [PptxEditException](https://reference.aspose.com/slides/el/cpp/aspose.slides/pptxeditexception/). Αναθέστε πρώτα τις εξαρτημένες διαφάνειες ή χρησιμοποιήστε το [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) για να αφαιρέσετε μόνο τις αχρησιμοποίητες διατάξεις.