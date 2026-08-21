---
title: Διαχείριση των Οδηγών Σχεδίασης σε Παρουσιάσεις σε C++
linktitle: Οδηγοί Σχεδίασης
type: docs
weight: 85
url: /el/cpp/drawing-guides/
keywords:
- οδηγός σχεδίασης
- οριζόντιος οδηγός
- κάθετος οδηγός
- οδηγός ευθυγράμμισης
- προβολή διαφάνειας
- master διαφάνειας
- διαφάνεια διάταξης
- master σημειώσεων
- master φυλλάδιο
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Προσθέστε, αποκτήστε πρόσβαση και αφαιρέστε οριζόντιους και κάθετους οδηγούς σχεδίασης σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για C++."
---
## **Επισκόπηση**

Οι οδηγίες σχεδίασης είναι ρυθμιζόμενες οριζόντιες και κάθετες γραμμές που βοηθούν τους χρήστες να ευθυγραμμίζουν τα σχήματα σταθερά κατά την επεξεργασία μιας παρουσίασης στο PowerPoint. Είναι ιδιαίτερα χρήσιμες όταν μια εφαρμογή δημιουργεί μια παρουσίαση που θα βελτιωθεί αργότερα με το χέρι: η εφαρμογή μπορεί να αποθηκεύσει τις ίδιες βοηθητικές ευθυγραμμίσεις που πρέπει να ακολουθήσουν οι συγγραφείς κατά την προσθήκη ή τη μετακίνηση του περιεχομένου.

Οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας, όχι περιεχόμενο διαφάνειας. Δεν εμφανίζονται σε παρουσίαση ή σε παραγόμενο αποτέλεσμα. Η Aspose.Slides για C++ τις εκθέτει μέσω της διεπαφής [IDrawingGuidesCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/idrawingguidescollection/) . Μια οδηγία αντιπροσωπεύεται από το [IDrawingGuide](https://reference.aspose.com/slides/el/cpp/aspose.slides/idrawingguide/) και διαθέτει προσανατολισμό, θέση και χρώμα.

Η θέση μετράται σε σημεία από την πάνω-αριστερή γωνία της αντίστοιχης διαφάνειας ή του master. Μια κάθετη οδηγία χρησιμοποιεί οριζόντιο συντεταγμένο, συνήθως μεταξύ του μηδενός και του πλάτους της διαφάνειας. Μια οριζόντια οδηγία χρησιμοποιεί κάθετο συντεταγμένο, συνήθως μεταξύ του μηδενός και του ύψους της διαφάνειας.

## **Προσθήκη Οδηγών στην Προβολή Διαφάνειας**

Χρησιμοποιήστε το [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/el/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) για να διαχειριστείτε τις οδηγίες που εμφανίζονται κατά την επεξεργασία κανονικών διαφανειών. Καλέστε το [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/el/cpp/aspose.slides/idrawingguidescollection/add/) με μια τιμή [Orientation](https://reference.aspose.com/slides/el/cpp/aspose.slides/orientation/) και μια θέση σε σημεία.

Το παρακάτω παράδειγμα προσθέτει μία κάθετη οδηγία στα δεξιά του κέντρου της διαφάνειας και μία οριζόντια οδηγία κάτω από αυτήν:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Πρόσβαση στις Οδηγίες Σχεδίασης**

Η μέθοδος [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/el/cpp/aspose.slides/idrawingguidescollection/get_count/) και η μέθοδος [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/el/cpp/aspose.slides/idrawingguidescollection/idx_get/) παρέχουν πρόσβαση στις υπάρχουσες οδηγίες. Οι μέθοδοι [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/el/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/el/cpp/aspose.slides/idrawingguide/get_position/), και [IDrawingGuide::get_Color](https://reference.aspose.com/slides/el/cpp/aspose.slides/idrawingguide/get_color/) επιστρέφουν τις τρέχουσες ιδιότητες μιας οδηγίας. Οι αντίστοιχες μεθόδους ορισμού τους μπορούν να αλλάξουν αυτές τις ιδιότητες.

Το παρακάτω παράδειγμα διαβάζει τις οδηγίες προβολής διαφάνειας από την παρουσίαση που δημιουργήθηκε παραπάνω:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **Προσθήκη Οδηγών σε Master και Διαφάνειες Διάταξης**

Ένας master slide και καθεμία από τις διαφάνειες διάταξής του μπορούν να έχουν τις δικές τους συλλογές οδηγών σχεδίασης. Χρησιμοποιήστε το [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslide/get_drawingguides/) για έναν master slide και το [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/get_drawingguides/) για μια διαφάνεια διάταξης.

Το παρακάτω παράδειγμα προσθέτει μία κάθετη οδηγία στην πρώτη master διαφάνεια και μία οριζόντια οδηγία στην πρώτη διαφάνεια διάταξης:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Προσθήκη Οδηγών σε Notes και Handout Masters**

Οι masters σημειώσεων και οι masters φυλλαδίου υποστηρίζουν επίσης οδηγίες σχεδίασης. Χρησιμοποιήστε το [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasternotesslide/get_drawingguides/) και το [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) για να αποκτήσετε πρόσβαση στις συλλογές τους. Εάν μια παρουσίαση δεν περιέχει κάποιον από αυτούς τους masters, το [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) ή το [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) δημιουργεί τον προεπιλεγμένο master και τον επιστρέφει.

Το παρακάτω παράδειγμα προσθέτει μία οριζόντια οδηγία σε έναν notes master και μία κάθετη οδηγία σε έναν handout master:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoutMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Καθαρισμός Οδηγών Σχεδίασης**

Κλήστε το [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/el/cpp/aspose.slides/idrawingguidescollection/clear/) για να αφαιρέσετε κάθε οδηγία από μια συγκεκριμένη συλλογή. Ο καθαρισμός μιας συλλογής δεν επηρεάζει τις οδηγίες που αποθηκεύονται σε άλλη εμβέλεια.

Το παρακάτω παράδειγμα καθαρίζει τις οδηγίες προβολής διαφάνειας και όλες τις οδηγίες στους master slide, στις διαφάνειες διάταξης, στον notes master και στον handout master χωρίς να δημιουργήσει ελλιπείς masters:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Συχνές ερωτήσεις**

**Εμφανίζονται οι οδηγίες σχεδίασης σε παρουσίαση ή εξαγώμενες εικόνες;**

Όχι. Οι οδηγίες σχεδίασης είναι βοηθήματα ευθυγράμμισης για την επεξεργασία και δεν αποδίδονται ως περιεχόμενο παρουσίασης.

**Μπορεί να προστεθεί μια οδηγία σχεδίασης απευθείας σε μια κανονική διαφάνεια;**

Οι οδηγίες επεξεργασίας κανονικής διαφάνειας αποθηκεύονται στις ιδιότητες προβολής διαφάνειας της παρουσίασης. Ξεχωριστές συλλογές οδηγών είναι διαθέσιμες για master slide, διαφάνειες διάταξης, notes masters και handout masters.

**Ποιες μονάδες χρησιμοποιούνται για τις θέσεις των οδηγών;**

Οι θέσεις καθορίζονται σε σημεία, όπου 72 σημεία ισοδυναμούν με ένα ίντσα. Οι κάθετες θέσεις μετρώνται από την αριστερή άκρη, και οι οριζόντιες θέσεις μετρώνται από την πάνω άκρη.

**Ο καθαρισμός των οδηγών σχεδίασης αφαιρεί σχήματα ή αλλάζει το περιεχόμενο της διαφάνειας;**

Όχι. Η μέθοδος `Clear` αφαιρεί μόνο τις οδηγίες στην επιλεγμένη συλλογή. Τα σχήματα και το υπόλοιπο περιεχόμενο της διαφάνειας παραμένουν αμετάβλητα.