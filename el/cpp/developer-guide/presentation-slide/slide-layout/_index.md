---
title: Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας σε C++
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/cpp/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- αντικατάσταση
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
description: "Εφαρμόστε, δημιουργήστε και τροποποιήστε διατάξεις διαφάνειας στο Aspose.Slides για C++, προσθέστε αντικαταστάσεις, αφαιρέστε αχρησιμοποίητες διατάξεις και ελέγξτε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Μια διάταξη διαφάνειας ορίζει τις θέσεις και τη μορφοποίηση των αντικαταστάσεων όπως τίτλοι, κείμενο, εικόνες, διαγράμματα και πίνακες. Η εφαρμογή μιας διάταξης παρέχει στις διαφάνειες μια συνεπή δομή ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Οι πιο συνηθισμένες διατάξεις περιλαμβάνουν:

- **Διαφάνεια Τίτλου**: Περιέχει αντικαταστάσεις τίτλου και υποτίτλου.
- **Τίτλος και Περιεχόμενο**: Περιέχει αντικατάσταση τίτλου και μια γενικού σκοπού αντικατάσταση περιεχομένου.
- **Κενό**: Δεν περιέχει αντικαταστάσεις περιεχομένου και είναι χρήσιμο όταν κάθε σχήμα θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση Κληρονομικότητας Διάταξης**

Μια παρουσίαση έχει τρία συναφή επίπεδα:

1. Μια [κύρια διαφάνεια](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslide/) ορίζει το θέμα, τη κοινή μορφοποίηση, τα υπόβαθρα και τα κοινά αντικείμενα.
1. Μια [διάταξη διαφάνειας](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/) ανήκει σε μια κύρια και ορίζει μια συγκεκριμένη διάταξη των αντικαταστάσεων.
1. Μια [κανονική διαφάνεια](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/) χρησιμοποιεί μία διάταξη και αποθηκεύει το περιεχόμενο που εισήχθη για αυτή τη διαφάνεια.

Μια κανονική διαφάνεια κληρονομεί το θέμα και τη μορφοποίηση από τη διάταξη της, και η διάταξη κληρονομεί από την κύρια. Μια τιμή που ορίζεται άμεσα σε μια κανονική διαφάνεια παρακάμπτει την κληρονομούμενη τιμή σε αυτό το επίπεδο. Όταν δημιουργείται μια κανονική διαφάνεια, τα σχήματα αντικατάστασης της παράγονται από την επιλεγμένη διάταξη, ενώ το περιεχόμενο που εισάγεται σε αυτές τις αντικαταστάσεις ανήκει στη κανονική διαφάνεια.

Προσθέστε τις απαιτούμενες αντικαταστάσεις σε μια διάταξη πριν δημιουργήσετε διαφάνειες από αυτήν. Η προσθήκη μιας επιπλέον αντικατάστασης σε μια διάταξη αργότερα δεν προσθέτει αυτόματα το αντίστοιχο σχήμα αντικατάστασης στις υπάρχουσες κανονικές διαφάνειες.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Η αλλαγή της κληρονομημένης μορφοποίησης ή της υπάρχουσας γεωμετρίας των αντικαταστάσεων σε μια διάταξη μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτήν. Πριν επεξεργαστείτε μια διάταξη που ήδη χρησιμοποιείται, εξετάστε τις εξαρτώμενες διαφάνειες και ελέγξτε την τελική παρουσίαση.
- Μια διάταξη που χρησιμοποιείται ακόμη από μια διαφάνεια δεν μπορεί να αφαιρεθεί. Αναθέστε πρώτα τις εξαρτώμενες διαφάνειες της σε άλλη διάταξη ή αφαιρέστε μόνο τις αχρησιμοποίητες διατάξεις.

Για περισσότερες πληροφορίες σχετικά με το υψηλότερο επίπεδο αυτής της ιεραρχίας, δείτε το [Κύρια Διαφάνεια](/slides/el/cpp/slide-master/).

## **Επιλογή και Εφαρμογή Διάταξης Διαφάνειας**

Χρησιμοποιήστε έναν τύπο διάταξης όταν η παρουσίαση ακολουθεί τις τυπικές ορισμούς διάταξης του PowerPoint. Τα ονόματα των διατάξεων μπορούν να επεξεργαστούν από τον χρήστη και να εντοπιστούν, έτσι η επιλογή βάσει ονόματος είναι λιγότερο αξιόπιστη εκτός εάν ελέγχετε το πρότυπο προέλευσης.

Το παρακάτω παράδειγμα ψάχνει για **Τίτλος και Περιεχόμενο** στην πρώτη κύρια. Εάν αυτή η διάταξη δεν είναι διαθέσιμη, επιστρέφει σκόπιμα στην **Κενό**. Ο δεύτερος έλεγχος null είναι απαραίτητος επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένες διατάξεις. Η επιλεγμένη διάταξη εφαρμόζεται στην πρώτη κανονική διαφάνεια μέσω της μεθόδου [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/set_layoutslide/).

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

Η αλλαγή της διάταξης μιας διαφάνειας δεν αφαιρεί τα συνηθισμένα σχήματα που προστέθηκαν απευθείας στη διαφάνεια. Ωστόσο, οι θέσεις των αντικαταστάσεων, η κληρονομημένη μορφοποίηση και η αντιστοιχία μεταξύ των υπαρχουσών αντικαταστάσεων και της νέας διάταξης μπορούν να αλλάξουν, γι' αυτό ελέγξτε το αποτέλεσμα όταν εναλλάσσετε μεταξύ σημαντικά διαφορετικών διατάξεων.

## **Προσθήκη Διάταξης Διαφάνειας**

Η επιλογή και η δημιουργία είναι ξεχωριστές λειτουργίες. Το προηγούμενο παράδειγμα επιλέγει μια υπάρχουσα διάταξη· δεν δημιουργεί μία. Για να δημιουργήσετε μια διάταξη, καλέστε τη μέθοδο [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterlayoutslidecollection/add/) στη συλλογή διατάξεων της επιλεγμένης κύριας.

Το παρακάτω παράδειγμα προσθέτει πάντα μια νέα διάταξη **Τίτλος και Περιεχόμενο** με όνομα `Report Title and Content`, στη συνέχεια προσθέτει μια κανονική διαφάνεια βασισμένη σε αυτήν. Τα ονόματα των διατάξεων πρέπει να είναι μοναδικά εντός της συλλογής.

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

Προσθέστε μια διάταξη μόνο όταν το πρότυπο πραγματικά χρειάζεται μια ακόμη επαναχρησιμοποιήσιμη δομή. Εάν υπάρχει ήδη μια κατάλληλη διάταξη, επιλέξτε την και επαναχρησιμοποιήστε την αντί να δημιουργήσετε αντίγραφο.

## **Προσθήκη Αντικαταστάσεων σε Διάταξη Διαφάνειας**

Η μέθοδος [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) παρέχει ένα [ILayoutPlaceholderManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/) για την προσθήκη σχημάτων αντικατάστασης σε μια διάταξη.

| Αντικατάσταση PowerPoint | `ILayoutPlaceholderManager` Μέθοδος |
| ------------------------- | ----------------------------------- |
| ![Περιεχόμενο](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Περιεχόμενο (Κατακόρυφα)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Κείμενο](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Κείμενο (Κατακόρυφα)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Εικόνα](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Διάγραμμα](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Πίνακας](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Μέσα](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Εικόνα Διαδικτύου](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Το παρακάτω παράδειγμα ελέγχει αν η διάταξη **Κενό** υπάρχει, προσθέτει τέσσερις αντικαταστάσεις σε αυτήν και, στη συνέχεια, δημιουργεί μια κανονική διαφάνεια που χρησιμοποιεί τη τροποποιημένη διάταξη. Η σειρά είναι σκόπιμη: οι αντικαταστάσεις προστίθενται πριν δημιουργηθεί η κανονική διαφάνεια, ώστε το Aspose.Slides να μπορεί να δημιουργήσει τα αντίστοιχα σχήματα αντικατάστασης σε αυτή τη διαφάνεια.

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

![Οι αντικαταστάσεις στη διάταξη διαφάνειας](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υπαρχουσών αντικαταστάσεων διάταξης μπορεί να επηρεάσει τις εξαρτώμενες διαφάνειες. Μία νεοπροστέθειμένη αντικατάσταση διάταξης δεν προστίθεται αυτόματα στις υπάρχουσες κανονικές διαφάνειες. Δοκιμάστε τις αλλαγές διάταξης σε αντίγραφο της παρουσίασης και εξετάστε κάθε εξαρτημένη διαφάνεια.
{{% /alert %}}

## **Αφαίρεση Μη Χρησιμοποιούμενων Διατάξεων Διαφάνειας**

Χρησιμοποιήστε τη μέθοδο [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) για να αφαιρέσετε διατάξεις που δεν αναφέρονται από καμία κανονική διαφάνεια. Η μέθοδος διατηρεί αμετάβλητες τις διατάξεις που είναι ακόμη σε χρήση.

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

Για να αφαιρέσετε μια συγκεκριμένη διάταξη, χρησιμοποιήστε πρώτα τη μέθοδο [get_HasDependingSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) ή τη μέθοδο [GetDependingSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/getdependingslides/). Αναθέστε εκ των προτέρων τις εξαρτώμενες διαφάνειες πριν καλέσετε τη [ILayoutSlide::Remove](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/remove/). Η προσπάθεια αφαίρεσης μιας χρησιμοποιούμενης διάταξης προκαλεί μια [PptxEditException](https://reference.aspose.com/slides/el/cpp/aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδου σε Διάταξη Διαφάνειας**

Μια διάταξη διαθέτει τα δικά της αντικαταστάσεις υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας-ώρας. Χρησιμοποιήστε τη μέθοδο [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) για να ελέγξετε αυτές τις αντικαταστάσεις για μία διάταξη. Αυτό είναι χρήσιμο όταν, για παράδειγμα, οι διατάξεις περιεχομένου πρέπει να εμφανίζουν υποσέλιδα ενώ οι διατάξεις τίτλου όχι.

Το παρακάτω παράδειγμα επιλέγει με ασφάλεια μια διάταξη και κάνει ορατά τα στοιχεία του υποσέλιδου της:

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

## **Έλεγχος Ορατότητας Υποσέλιδου σε Κύρια και τις Παράγωγές της Διατάξεις**

Για να εφαρμόσετε συνεπείς ρυθμίσεις υποσέλιδου σε όλη τη ιεραρχία μιας κύριας, χρησιμοποιήστε τη μέθοδο [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Οι μέθοδοι διάδοσης του [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslideheaderfootermanager/) λειτουργούν στην κύρια και στις εξαρτώμενες διατάξεις διαφανειών και στις κανονικές διαφάνειες· δεν στοχεύουν μόνο σε μία κανονική διαφάνεια.

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

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ μιας κύριας διαφάνειας και μιας διάταξης διαφάνειας;**

Μια κύρια διαφάνεια ορίζει το θέμα της παρουσίασης και τη κοινή μορφοποίηση. Μια διάταξη διαφάνειας ανήκει σε μια κύρια και καθορίζει μία επαναχρησιμοποιήσιμη διάταξη αντικαταστάσεων. Οι κανονικές διαφάνειες χρησιμοποιούν αυτές τις διατάξεις και αποθηκεύουν περιεχόμενο ειδικό για τη διαφάνεια.

**Μπορώ να αντιγράψω μια διάταξη διαφάνειας από μια παρουσίαση σε άλλη;**

Ναι. Προσθέστε ένα αντίγραφο στη συλλογή προορισμού με τη μέθοδο [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Κατά την αντιγραφή μεταξύ παρουσιάσεων, ελέγξτε επίσης τις γραμματοσειρές, τα θέματα, τις εικόνες και άλλους πόρους που χρησιμοποιεί η διάταξη προέλευσης.

**Τι συμβαίνει όταν τροποποιώ μια διάταξη που χρησιμοποιείται ήδη;**

Οι εξαρτώμενες διαφάνειες κληρονομούν τις αλλαγές στη διάταξη εκτός εάν παρακάμψουν το επηρεασμένο στυλ ή τα αντικείμενα τοπικά. Η γεωμετρία των αντικαταστάσεων και η κληρονομική μορφοποίηση μπορούν έτσι να αλλάξουν σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήστε τη [GetDependingSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/getdependingslides/) για να εντοπίσετε τις επηρεαζόμενες διαφάνειες πριν επεξεργαστείτε τη διάταξη.

**Τι συμβαίνει αν αφαιρέσω μια διάταξη που είναι ακόμη σε χρήση;**

Το Aspose.Slides προκαλεί μια [PptxEditException](https://reference.aspose.com/slides/el/cpp/aspose.slides/pptxeditexception/). Αναθέστε πρώτα τις εξαρτώμενες διαφάνειες, ή χρησιμοποιήστε τη [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) για να αφαιρέσετε μόνο τις ακατάστατες διατάξεις.