---
title: "Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε C++"
linktitle: "Ιδιότητες Προβολής"
type: docs
weight: 80
url: /el/cpp/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- συγκόλληση κάθετου διαχωριστή
- μονή προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένη μεγέθυνση
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides για C++ για να διαμορφώσετε τη διάταξη της κανονικής προβολής, τη μεγέθυνση διαφάνειας και σημειώσεων, την απόσταση πλέγματος και τη διαφάνεια σχολίων σε παρουσιάσεις PowerPoint."
---
## **Εισαγωγή**

Στην κανονική προβολή του PowerPoint, η διαφάνεια εμφανίζεται μεταξύ ενός πλευρικού πλαισίου για μικρογραφίες ή περίγραμμα και ενός πλαισίου σημειώσεων από κάτω. Το Aspose.Slides για C++ αποκαλύπτει τις αποθηκευμένες προτιμήσεις επεξεργασίας της παρουσίασης μέσω [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/). Αυτές περιλαμβάνουν τη διάταξη των πλαισίων, τα επίπεδα μεγέθυνσης, την απόσταση του πλέγματος και τη διαφάνεια σχολίων.

## **Σχετικά με INormalViewProperties**

Χρησιμοποιήστε [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) για πρόσβαση στην διεπαφή [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/). Το [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) ελέγχει αν εμφανίζονται εικονίδια δίπλα στους τίτλους των διαφανειών στο περίγραμμα. Το [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) επιτρέπει στο πλευρικό πλαίσιο να «κλειδώνει» στην ελαχιστοποιημένη του κατάσταση όταν ο χρήστης το σμικρύνει. Το [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) δηλώνει προτίμηση για εμφάνιση ενός μόνο πλαισίου σε όλο το παράθυρο.

Το [set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) ελέγχει το διαχωριστικό μεταξύ του πλευρικού πλαισίου και της διαφάνειας. Το [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) ελέγχει το διαχωριστικό πάνω από το πλαίσιο σημειώσεων. Και τα δύο δέχονται μια τιμή του τύπου [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) — `Minimized`, `Maximized` ή `Restored`.

## **Σχετικά με την Επαναφορά INormalViewProperties**

Όταν ένα διαχωριστικό επανέλθει στην προηγούμενη κατάσταση, το [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) παρέχει το αποθηκευμένο μέγεθος του πλευρικού πλαισίου και το [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) παρέχει το αποθηκευμένο μέγεθος της πάνω περιοχής της διαφάνειας. Και τα δύο εκθέτουν το [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/). Η μέθοδος [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) δέχεται ένα ποσοστό από 0 έως 100, και το [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) ελέγχει αν ο επεξεργαστής προσαρμόζει το μέγεθος όταν το παράθυρο αλλάζει διαστάσεις.

Αυτό το παράδειγμα ενημερώνει μια υπάρχουσα παρουσίαση. Επαναφέρει το οριζόντιο διαχωριστικό, ορίζει το μέγεθος της πάνω περιοχής της διαφάνειας που παρέχεται από το [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) στο 80 % με ενεργοποιημένη την αυτόματη προσαρμογή, και μεγιστοποιεί το κάθετο διαχωριστικό. Επίσης ενεργοποιεί τα εικονίδια περιγράμματος με το [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) για την προβολή περίγραμμα.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Ορισμός Προεπιλεγμένης Τιμής Μεγέθυνσης**

Τα [get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) και [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) αποθηκεύουν ανεξάρτητες ρυθμίσεις μεγέθυνσης για τον επεξεργαστή. Αυτές οι ρυθμίσεις δεν επηρεάζουν τις διαστάσεις της διαφάνειας, την αναπαραγωγή της παρουσίασης ή την ανάλυση εξαγόμενων εικόνων.

Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και ενεργοποιεί την αυτόματη κλιμάκωση με το [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) ώστε η διαφάνεια να προσαρμόζεται στο παράθυρο επεξεργασίας. Για τη σελίδα σημειώσεων, απενεργοποιεί την αυτόματη κλιμάκωση και χρησιμοποιεί το [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) για να ορίσει σταθερή μεγέθυνση 80 %.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **Ορισμός Απόστασης Πλέγματος**

Το [set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) ορίζει την απόσταση μεταξύ των γραμμών επεξεργασίας του πλέγματος σε όλη την παρουσίαση. Δέχεται θετική τιμή σε σημεία, με 72 σημεία ανά ίντσα. Αυτό το παράδειγμα εκτυπώνει την τρέχουσα απόσταση σε μια υπάρχουσα παρουσίαση και αποθηκεύει ένα πλέγμα τετάρτης ίντσας ορίζοντας το διάστημα στα 18 σημεία.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Το πλέγμα επαναλαμβάνεται σε σταθερό διάστημα. Οι [Drawing guides](/slides/el/cpp/drawing-guides/) σημειώνουν μεμονωμένες οριζόντιες ή κάθετες θέσεις. Και τα δύο είναι βοηθήματα επεξεργασίας και εμφανίζονται μόνο σε επεξεργαστές που τα προβάλλουν. Οι παρουσιάσεις και οι εξαγωγές σε PDF, εικόνες ή SVG τα παραλείπουν.

## **Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης**

Το [set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) αποθηκεύει μια προτίμηση που οι συμβατοί επεξεργαστές χρησιμοποιούν όταν ανοίγουν την παρουσίαση. Για μια υπάρχουσα παρουσίαση με σχόλια, αυτό το παράδειγμα εκτυπώνει την τρέχουσα ρύθμιση και αποθηκεύει ένα αντίγραφο με τα σχόλια κρυμμένα. Επιπλέον, καλεί το [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) με το [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) ώστε το αντίγραφο να ανοίγει στην προβολή διαφάνειας.

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

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Η απόκρυψη των σχολίων διατηρεί το κείμενο, τους συγγραφείς, τις θέσεις, τις απαντήσεις και τις καταστάσεις τους. Για αλλαγή των ίδιων των σχολίων, δείτε την ενότητα [Presentation Comments](/slides/el/cpp/presentation-comments/). Οι ρυθμίσεις εξαγωγής ελέγχουν αν τα σχόλια εμφανίζονται σε PDF, HTML, εικόνες, σημειώσεις ή φυλλάδια.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Γιατί το πλέγμα είναι κρυφό όταν ανοίγω ξανά την παρουσίαση;**

Η παρουσίαση αποθηκεύει το διάστημα του πλέγματος. Για να δείτε το πλέγμα, ενεργοποιήστε τη διαφάνεια του πλέγματος στον επεξεργαστή.

**Αλλάζει η απόσταση του πλέγματος όταν καθαρίζω τις οδηγίες σχεδίασης;**

Όχι. Η προσθήκη, η μετακίνηση ή η διαγραφή μιας οδηγίας δεν αλλάζει το διάστημα του πλέγματος.

**Μπορούν διαφορετικές ενότητες μιας παρουσίασης να έχουν διαφορετικές ρυθμίσεις προβολής;**

Όχι. Το [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) ισχύει για ολόκληρη την παρουσίαση.

**Μπορώ να αποθηκεύσω διαφορετικές ρυθμίσεις προβολής για διαφορετικούς χρήστες;**

Το αρχείο αποθηκεύει ένα σύνολο ιδιοτήτων προβολής για όλους. Ένας επεξεργαστής μπορεί επίσης να εφαρμόσει τις τοπικές προτιμήσεις ενός χρήστη.

**Μπορώ να αποθηκεύσω ρυθμίσεις προβολής σε πρότυπο;**

Ναι. Οι παρουσιάσεις που δημιουργούνται από το πρότυπο κληρονομούν τις αποθηκευμένες ρυθμίσεις προβολής.