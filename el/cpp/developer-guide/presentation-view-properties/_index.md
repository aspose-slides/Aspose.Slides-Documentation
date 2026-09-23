---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε C++
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/cpp/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περίληψης
- εικονίδια περίληψης
- συγκράτηση κάθετου διαχωριστή
- μονή προβολή
- κατάσταση μπάρας
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides για C++ για την προσαρμογή μορφών διαφανειών PPT, PPTX και ODP — προσαρμόστε διατάξεις, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια ίδια, μία πλευρική περιοχή περιεχομένου και μία κάτω περιοχή περιεχομένου. Ιδιότητες που αφορούν την τοποθέτηση των διαφορετικών περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση προβολής στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να βρίσκεται στην ίδια κατάσταση όπως όταν η παρουσίαση αποθηκεύτηκε για τελευταία φορά.

Method [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) has been added to provide access to normal view properties of presentation. 

[INormalViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/inormalviewrestoredproperties/) interfaces and its descendants, [SplitterBarStateType](https://reference.aspose.com/slides/el/cpp/aspose.slides/splitterbarstatetype/) enum have been added.

## **Σχετικά με INormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Η ιδιότητα **ShowOutlineIcons** καθορίζει εάν η εφαρμογή πρέπει να εμφανίζει εικονίδια όταν εμφανίζει το περιεχόμενο περίληψης σε οποιαδήποτε από τις περιοχές περιεχομένου της κανονικής λειτουργίας προβολής.

Η ιδιότητα **SnapVerticalSplitter** καθορίζει εάν ο κάθετος διαχωριστής πρέπει να «καρφώνεται» σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι αρκετά μικρή.

Η ιδιότητα **PreferSingleView** καθορίζει εάν ο χρήστης προτιμά να δει μία πλήρη περιοχή περιεχομένου σε ολόκληρο το παράθυρο αντί για την τυπική κανονική προβολή με τρία περιεχόμενα. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι ιδιότητες **VerticalBarState** και **HorizontalBarState** καθορίζουν την κατάσταση που πρέπει να εμφανίζεται η οριζόντια ή κάθετη μπάρα διαχωριστή. Μία οριζόντια μπάρα διαχωριστή χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από αυτήν, η κάθετη μπάρα διαχωριστή χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** και **SplitterBarStateType.Restored**.

Οι ιδιότητες **RestoredLeft** και **RestoredTop** καθορίζουν το μέγεθος της άνω ή πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή **SplitterBarStateType.Restored** έχει εφαρμοστεί αντίστοιχα για **VerticalBarState** και **HorizontalBarState**.

## **Σχετικά με την Επαναφορά INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του RestoredTop, ύψος όταν είναι παιδί του RestoredLeft) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό επαναφερθέν μέγεθος (ουδεμία ελαχιστοποίηση ή μεγιστοποίηση). 

Η ιδιότητα **DimensionSize** καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του restoredTop, ύψος όταν είναι παιδί του restoredLeft).

Η ιδιότητα **AutoAdjust** καθορίζει εάν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να προσαρμόζεται αυτόματα στο νέο μέγεθος όταν αλλάζει το μέγεθος του παραθύρου που περιέχει την προβολή στην εφαρμογή.

Ένα παράδειγμα που δίνεται παρακάτω δείχνει πώς μπορείτε να έχετε πρόσβαση στις ιδιότητες **ViewProperties.NormalViewProperties** για μια παρουσίαση.

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

## **Ορίστε την Προεπιλεγμένη Τιμή Μεγέθυνσης**

Το Aspose.Slides for C++ υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής μεγέθυνσης για την παρουσίαση, ώστε όταν ανοίξει η παρουσίαση η μεγέθυνση να είναι ήδη ορισμένη. Αυτό μπορεί να γίνει ορίζοντας τις [ViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/) μιας παρουσίασης. Οι ιδιότητες προβολής διαφάνειας καθώς και [get_NotesViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/get_notesviewproperties/) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσετε τις Ιδιότητες Προβολής μιας Παρουσίασης στο Aspose.Slides.

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/)
1. Ορίστε τις [Properties](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/) προβολής της παρουσίασης
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX

Στο παρακάτω παράδειγμα, ορίσαμε την τιμή μεγέθυνσης τόσο για την προβολή διαφάνειας όσο και για την προβολή σημειώσεων.

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

## **Ορίστε την Απόσταση Πλέγματος**

Χρησιμοποιήστε [Presentation::get_ViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_viewproperties/) για πρόσβαση στις ρυθμίσεις προβολής όλου του εγγράφου. Οι μέθοδοι [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/el/cpp/aspose.slides/iviewproperties/get_gridspacing/) και [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/el/cpp/aspose.slides/iviewproperties/set_gridspacing/) διαβάζουν ή αλλάζουν το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρη την παρουσίαση, όχι σε μεμονωμένη διαφάνεια. Η απόσταση πλέγματος καθορίζεται σε σημεία, όπου 72 σημεία ισοδυναμούν με μία ίντσα. Χρησιμοποιήστε θετική τιμή, όπως απαιτεί η τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον `demo.pptx`, εκτυπώνει την τρέχουσα απόσταση πλέγματος, ορίζει διάστημα ενός τέταρτου ίντσας και αποθηκεύει το αποτέλεσμα.

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

Το πλέγμα διαφέρει από τα [drawing guides](/slides/el/cpp/drawing-guides/). Η απόσταση πλέγματος ελέγχει ένα τακτικό διάστημα, ενώ οι οδηγίες σχεδίασης είναι ατομικά τοποθετημένες οριζόντιες ή κάθετες γραμμές ευθυγράμμισης. Η προσθήκη, μετακίνηση ή διαγραφή των οδηγών σχεδίασης δεν αλλάζει το διάστημα πλέγματος.

Τanto το πλέγμα όσο και οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας. Δεν αποδίδονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση της απόστασης πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα: η ορατότητά του εξαρτάται επίσης από τις προτιμήσεις του προγράμματος προβολής ή επεξεργασίας.

## **Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα μιας Παρουσίασης**

Χρησιμοποιήστε [Presentation::get_ViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_viewproperties/) για πρόσβαση στις ρυθμίσεις προβολής όλου του εγγράφου. Χρησιμοποιήστε [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/el/cpp/aspose.slides/iviewproperties/get_showcomments/) και [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/el/cpp/aspose.slides/iviewproperties/set_showcomments/) για να αποθηκεύσετε μια προτίμηση σχετικά με το αν τα σχόλια πρέπει να εμφανίζονται όταν η παρουσίαση ανοίγει στο PowerPoint ή σε άλλο συμβατό πρόγραμμα.

Αυτή η ρύθμιση ελέγχει μόνο την αποθηκευμένη προτίμηση προβολής. Δεν προσθέτει, αφαιρεί, επεξεργάζεται ή λύνει σχόλια. Η απόκρυψη σχολίων διατηρεί το περιεχόμενο, τους συγγραφείς, τις θέσεις, τις απαντήσεις και τις καταστάσεις τους. Δείτε το [Presentation Comments](/slides/el/cpp/presentation-comments/) για λειτουργίες που αλλάζουν τα ίδια τα σχόλια.

Το παρακάτω παράδειγμα απαιτεί ένα υπάρχον `comments.pptx` που περιέχει σχόλια. Εκτυπώνει την τρέχουσα ρύθμιση ορατότητας, ζητά την απόκρυψη των σχολίων και αποθηκεύει ένα νέο PPTX χωρίς να αφαιρέσει κανένα σχόλιο. Επίσης χρησιμοποιεί [IViewProperties::set_LastView](https://reference.aspose.com/slides/el/cpp/aspose.slides/iviewproperties/set_lastview/) μαζί με [ViewType::SlideView](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewtype/) για να διαμορφώσει την αρχική προβολή επεξεργασίας μαζί με την ορατότητα των σχολίων.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Αυτή η ρύθμιση δεν καθορίζει εάν τα σχόλια περιλαμβάνονται στις εξαγωγές PDF, HTML, εικόνας, σημειώσεων ή φυλλαδίου. Ρυθμίστε ξεχωριστά τις σχετικές επιλογές εξαγωγής.

## **Συχνές Ερωτήσεις**

**Γιατί το πλέγμα δεν είναι ορατό μετά το ξαναάνοιγμα της παρουσίασης;**

Το αρχείο αποθηκεύει την απόσταση πλέγματος, αλλά ο επεξεργαστής ελέγχει αν το πλέγμα εμφανίζεται. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αλλάζει η εκκαθάριση των οδηγών σχεδίασης το διάστημα του πλέγματος;**

Όχι. Οι οδηγίες σχεδίασης και η απόσταση πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η εκκαθάριση των οδηγών δεν αλλάζει το αποθηκευμένο διάστημα πλέγματος.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [View settings](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_viewproperties/) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), όχι ανά ενότητα, επομένως ένα σύνολο παραμέτρων εφαρμόζεται σε ολόκληρο το έγγραφο κατά το άνοιγμά του.

**Μπορώ να προκαθορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και κοινοποιούνται. Οι εφαρμογές προβολής μπορεί να τιμήσουν τις προτιμήσεις του χρήστη, αλλά το αρχείο περιέχει ένα μόνο σύνολο ιδιοτήτων προβολής.

**Μπορώ να ετοιμάσω ένα πρότυπο με προδιαγεγραμμένες Ιδιότητες Προβολής ώστε νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [view properties](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_viewproperties/) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργείτε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.