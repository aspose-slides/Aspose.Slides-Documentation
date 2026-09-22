---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε C++
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/cpp/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- προσαρμογή κάθετης γραμμής διαχωρισμού
- απλή προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides για C++ για να προσαρμόσετε μορφές διαφανειών PPT, PPTX και ODP — να ρυθμίσετε διατάξεις, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: την ίδια τη διαφάνεια, μια πλευρική περιοχή περιεχομένου και μια κάτω περιοχή περιεχομένου. Ιδιότητες που αφορούν την τοποθέτηση των διαφόρων περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση προβολής της σε αρχείο, ώστε όταν ανοίξει ξανά η προβολή να βρίσκεται στην ίδια κατάσταση με την τελευταία αποθήκευση της παρουσίασης.

Η μέθοδος [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες κανονικής προβολής μιας παρουσίασης. 

Οι διεπαφές [INormalViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/inormalviewrestoredproperties/) και οι απογόνους τους, καθώς και η enum [SplitterBarStateType](https://reference.aspose.com/slides/el/cpp/aspose.slides/splitterbarstatetype/) προστέθηκαν.

## **Σχετικά με το INormalViewProperties**

Αναπαριστά τις ιδιότητες της κανονικής προβολής.

Η ιδιότητα **ShowOutlineIcons** καθορίζει εάν η εφαρμογή πρέπει να εμφανίζει εικονίδια όταν εμφανίζει το περίγραμμα περιεχομένου σε οποιαδήποτε από τις περιοχές περιεχομένου της κατάστασης κανονικής προβολής.

Η ιδιότητα **SnapVerticalSplitter** καθορίζει εάν η κάθετη γραμμή διαχωρισμού πρέπει να «προσαρμοστεί» σε μειωμένη κατάσταση όταν η πλευρική περιοχή είναι αρκετά μικρή.

Η ιδιότητα **PreferSingleView** καθορίζει εάν ο χρήστης προτιμά να βλέπει μια πλήρη περιοχή περιεχομένου σε όλο το παράθυρο αντί για την τυπική κανονική προβολή με τρεις περιοχές περιεχομένου. Εάν είναι ενεργοποιημένη, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι ιδιότητες **VerticalBarState** και **HorizontalBarState** καθορίζουν την κατάσταση στην οποία πρέπει να εμφανίζεται η οριζόντια ή κάθετη γραμμή διαχωρισμού. Μια οριζόντια γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, ενώ η κάθετη γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** και **SplitterBarStateType.Restored**.

Οι ιδιότητες **RestoredLeft** και **RestoredTop** καθορίζουν το μέγεθος της πάνω ή πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή **SplitterBarStateType.Restored** έχει εφαρμοστεί αντίστοιχα στην **VerticalBarState** και **HorizontalBarState**.

## **Σχετικά με την Επαναφορά του INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του RestoredTop, ύψος όταν είναι παιδί του RestoredLeft) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό αποκατεστημένο μέγεθος (ούτε μειωμένο ούτε μεγιστοποιημένο). 

Η ιδιότητα **DimensionSize** καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του restoredTop, ύψος όταν είναι παιδί του restoredLeft).

Η ιδιότητα **AutoAdjust** καθορίζει εάν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να προσαρμόζεται αυτόματα στο νέο μέγεθος κατά την αλλαγή μεγέθους του παραθύρου που περιέχει τη προβολή εντός της εφαρμογής.

Ένα παράδειγμα παρατίθεται παρακάτω που δείχνει πώς μπορείτε να αποκτήσετε πρόσβαση στις ιδιότητες **ViewProperties.NormalViewProperties** για μια παρουσίαση.

``` cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Επαναφορά των ιδιοτήτων προβολής της παρουσίασης
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Ορισμός της προεπιλεγμένης τιμής ζουμ**

Το Aspose.Slides for C++ υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής ζουμ για μια παρουσίαση, ώστε όταν ανοίξει η παρουσίαση το ζουμ να είναι ήδη ρυθμισμένο. Αυτό μπορεί να γίνει ορίζοντας τα [ViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/) μιας παρουσίασης. Οι Ιδιότητες Προβολής Διαφάνειας καθώς και το [get_NotesViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/get_notesviewproperties/) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με παράδειγμα πώς να ορίσουμε τις Ιδιότητες Προβολής μιας Παρουσίασης στο Aspose.Slides.

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Ορίστε τις [Properties](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/) προβολής της Παρουσίασης.
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, ορίσαμε την τιμή ζουμ τόσο για την προβολή διαφάνειας όσο και για την προβολή σημειώσεων.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Ορισμός των ιδιοτήτων προβολής της παρουσίασης
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Τιμή ζουμ σε ποσοστά για προβολή διαφάνειας
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Τιμή ζουμ σε ποσοστά για προβολή σημειώσεων 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Ορισμός του διαστήματος του πλέγματος**

Χρησιμοποιήστε το [Presentation::get_ViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_viewproperties/) για να αποκτήσετε πρόσβαση στις ρυθμίσεις προβολής για ολόκληρη την παρουσίαση. Οι μέθοδοι [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/el/cpp/aspose.slides/iviewproperties/get_gridspacing/) και [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/el/cpp/aspose.slides/iviewproperties/set_gridspacing/) διαβάζουν ή αλλάζουν το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρη την παρουσίαση, όχι σε μεμονωμένη διαφάνεια. Το διάστημα του πλέγματος ορίζεται σε σημεία, όπου 72 σημεία ισούται με ένα ίντσα. Χρησιμοποιήστε μια θετική τιμή, όπως απαιτεί η τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον `demo.pptx`, εκτυπώνει το τρέχον διάστημα του πλέγματος, ορίζει ένα διάστημα τετάρτου ίντσας και αποθηκεύει το αποτέλεσμα.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Το πλέγμα διαφέρει από τις [drawing guides](/slides/el/cpp/drawing-guides/). Το διάστημα του πλέγματος ελέγχει ένα κανονικό διάστημα, ενώ οι οδηγίες σχεδίασης είναι ατομικά τοποθετημένες οριζόντιες ή κάθετες γραμμές ευθυγράμμισης. Η προσθήκη, μετακίνηση ή διαγραφή οδηγών σχεδίασης δεν αλλάζει το διάστημα του πλέγματος.

Τanto το πλέγμα όσο και οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας. Δεν αποδίδονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση του διαστήματος του πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα: η ορατότητά του εξαρτάται επίσης από τις προτιμήσεις του προγράμματος προβολής ή επεξεργαστή.

## **Συχνές ερωτήσεις**

**Γιατί το πλέγμα δεν είναι ορατό αφού ανοίξω ξανά την παρουσίαση;**

Το αρχείο αποθηκεύει το διάστημα του πλέγματος, αλλά ο επεξεργαστής ελέγχει εάν το πλέγμα θα εμφανιστεί. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αλλάζει η διαγραφή οδηγών σχεδίασης το διάστημα του πλέγματος;**

Όχι. Οι οδηγίες σχεδίασης και το διάστημα του πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η διαγραφή των οδηγών αφήνει αμετάβλητο το αποθηκευμένο διάστημα του πλέγματος.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [View settings](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_viewproperties/) ορίζονται στο επίπεδο της παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), όχι ανά ενότητα, επομένως ένα ενιαίο σύνολο παραμέτρων εφαρμόζεται σε ολόκληρο το έγγραφο όταν ανοίγει.

**Μπορώ να προ-ορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και είναι κοινές. Οι εφαρμογές προβολής μπορούν να σεβαστούν τις προτιμήσεις των χρηστών, αλλά το ίδιο το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να ετοιμάσω ένα πρότυπο με προ-ορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [view properties](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_viewproperties/) αποθηκεύονται στο επίπεδο της παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.