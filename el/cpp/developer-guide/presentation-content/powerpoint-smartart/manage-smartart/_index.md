---
title: Διαχείριση SmartArt σε παρουσιάσεις PowerPoint χρησιμοποιώντας C++
linktitle: Διαχείριση SmartArt
type: docs
weight: 10
url: /el/cpp/manage-smartart/
keywords:
- SmartArt
- Κείμενο SmartArt
- Τύπος διάταξης
- Κρυφή ιδιότητα
- Διάγραμμα οργανωτικού τύπου
- Διάγραμμα οργανωτικού τύπου εικόνας
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να επεξεργάζεστε SmartArt PowerPoint με το Aspose.Slides για C++ χρησιμοποιώντας σαφή παραδείγματα κώδικα που επιταχύνουν το σχεδιασμό και την αυτοματοποίηση των διαφανειών."
---
## **Επισκόπηση**

Το SmartArt είναι ένα διάγραμμα PowerPoint που αποτελείται από κόμβους, σχήματα κόμβων και διάταξη. Με το Aspose.Slides για C++, μπορείτε να δημιουργήσετε SmartArt, να διαβάσετε κείμενο από τους κόμβους του, να αλλάξετε τη διάταξή του, να ελέγξετε κρυφούς κόμβους, να ρυθμίσετε διατάξεις διαγραμμάτων οργανωτικού τύπου και να δημιουργήσετε διαγράμματα οργανωτικού τύπου εικόνας.

## **Λήψη κειμένου από αντικείμενο SmartArt**

Ένας κόμβος SmartArt μπορεί να περιέχει ένα ή περισσότερα σχήματα. Για να διαβάσετε κείμενο από τα σχήματα του κόμβου, επαναλάβετε μέσω του [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/), στη συνέχεια διαβάστε το [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) που επιστρέφεται από το [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/).

Το παράδειγμα απαιτεί μια παρουσίαση με τουλάχιστον μία διαφάνεια και ένα αντικείμενο SmartArt ως το πρώτο σχήμα σε αυτή τη διαφάνεια. Εκτυπώνει κάθε διαθέσιμο πλαίσιο κειμένου στην κονσόλα.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **Αλλαγή τύπου διάταξης αντικειμένου SmartArt**

Η διάταξη SmartArt ελέγχει πώς διατάσσονται και συνδέονται οι κόμβοι. Το παρακάτω παράδειγμα δημιουργεί ένα αντικείμενο SmartArt με την τιμή `BasicBlockList` του [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/), το αλλάζει στην τιμή `BasicProcess` και αποθηκεύει την παρουσίαση. Η θέση και το μέγεθος που περνούν στο [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) μετρώνται σε μονάδες σημείου. Χρησιμοποιήστε το [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) για να αλλάξετε τη διάταξη.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Έλεγχος αν ένας κόμβος SmartArt είναι κρυμμένος**

Το [ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) υποδεικνύει αν ο κόμβος είναι κρυμμένος στο μοντέλο δεδομένων SmartArt. Οι κρυφοί κόμβοι μπορούν να υπάρχουν στη δομή ακόμη και όταν η επιλεγμένη διάταξη δεν τους εμφανίζει ως ορατά στοιχεία διαγράμματος.

Το παρακάτω παράδειγμα προσθέτει έναν κόμβο σε ένα αντικείμενο SmartArt που χρησιμοποιεί την τιμή `RadialCycle` του [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/), και ελέγχει την κρυφή κατάσταση του προστεθέντος κόμβου. Εκτυπώνει ένα μήνυμα εάν ο κόμβος είναι κρυμμένος και αποθηκεύει το διάγραμμα.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Λήψη ή ορισμός διάταξης οργανωτικού διαγράμματος**

Για διαγράμματα SmartArt που χρησιμοποιούν διάταξη οργανωτικού διαγράμματος, τα [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) και [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) ορίζουν πώς τα υποκόμβια διατάσσονται κάτω από έναν γονικό κόμβο. Για παράδειγμα, μπορείτε να ορίσετε τα υποκόμβια να κρέμονται από τα αριστερά, τα δεξιά ή και τις δύο πλευρές, ανάλογα με το επιλεγμένο [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/).

Το παρακάτω παράδειγμα δημιουργεί ένα οργανωτικό διάγραμμα και ορίζει τη διάταξη για τον πρώτο κόμβο στην τιμή `LeftHanging` του [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/). Ο δείκτης μηδενικής βάσης `0` επιλέγει τον πρώτο κόμβο πρώτου επιπέδου· τα υποκόμβια του χρησιμοποιούν τη επιλεγμένη διάταξη. Η τροποποιημένη παρουσίαση αποθηκεύεται στη συνέχεια.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Δημιουργία διαγράμματος οργανωτικού τύπου εικόνας**

Ένα διάγραμμα οργανωτικού τύπου εικόνας είναι μια διάταξη SmartArt σχεδιασμένη για διαγράμματα ιεραρχίας που περιλαμβάνουν δεσμευτικά θέσης εικόνας. Χρησιμοποιήστε την τιμή `PictureOrganizationChart` του [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) όταν προσθέτετε το αντικείμενο SmartArt σε μια διαφάνεια. Αυτό το παράδειγμα αποθηκεύει ένα διάγραμμα με δεσμευτικά θέσης εικόνας· δεν γεμίζει τα δεσμευτικά θέσης με εικόνες.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Μετατροπή παλαιών διαγραμμάτων σε ομάδες σχημάτων**

Κατά τη σύγχρονη αναβάθμιση μιας υπάρχουσας παρουσίασης, ίσως χρειαστεί να ενημερώσετε ένα οργανωτικό διάγραμμα που δημιουργήθηκε αρχικά σε PowerPoint 97–2003. Το Aspose.Slides αντιπροσωπεύει αυτά τα παλιά διαγράμματα ως αντικείμενα [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/). Χρησιμοποιήστε το [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/) για να μετατρέψετε ένα διάγραμμα σε ομάδα σχημάτων ώστε να μπορείτε να επεξεργαστείτε μεμονωμένα οπτικά στοιχεία. Δείτε την [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/) για λεπτομέρειες.

Η μετατροπή προσθέτει μια νέα ομάδα στη συλλογή σχημάτων χωρίς να αφαιρεί το αρχικό διάγραμμα. Μετά την επιτυχή μετατροπή, αφαιρέστε το αρχικό με το [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) ώστε να αποφύγετε διπλό περιεχόμενο. Συλλέξτε τα παλιά διαγράμματα σε ένα διάνυσμα πριν τα μετατρέψετε, ώστε η προσθήκη και αφαίρεση σχημάτων να μην διακόπτει την επανάληψη.

Το παρακάτω παράδειγμα ανοίγει μια παρουσίαση, ψάχνει σε κάθε διαφάνεια, μετατρέπει τα διαγράμματα σε ομάδες σχημάτων και αποθηκεύει την ενημερωμένη παρουσίαση ως PPTX.

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η αποθηκευμένη παρουσίαση περιέχει επεξεργάσιμες ομάδες σχημάτων στη θέση των μετατρεπόμενων παλαιών διαγραμμάτων, χωρίς να παραμένουν τα αρχικά διαγράμματα. Ανοίξτε το PPTX στο PowerPoint για να επεξεργαστείτε μεμονωμένα στοιχεία μέσα σε κάθε ομάδα, όπως το κείμενο, το γέμισμα ή τη θέση τους.

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Υποστηρίζει το SmartArt καθρεπτισμό ή αντιστροφή για γλώσσες RTL;**

Ναι. Η μέθοδος [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) αλλάζει την κατεύθυνση του διαγράμματος από αριστερά προς δεξιά σε δεξιά προς αριστερά, ή το αντίστροφο, όταν η επιλεγμένη διάταξη SmartArt υποστηρίζει αντιστροφή.

**Πώς μπορώ να αντιγράψω το SmartArt στην ίδια διαφάνεια ή σε άλλη παρουσίαση διατηρώντας τη μορφοποίηση;**

Μπορείτε να [κλωνοποιήσετε το σχήμα SmartArt](/slides/el/cpp/shape-manipulations/) με το [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) ή να [κλωνοποιήσετε ολόκληρη τη διαφάνεια](/slides/el/cpp/clone-slides/) που περιέχει το SmartArt. Και οι δύο προσεγγίσεις διατηρούν το μέγεθος, τη θέση και τη μορφοποίηση.

**Πώς αποδίδω το SmartArt σε εικονογραφική εικόνα για προεπισκόπηση ή εξαγωγή στο web;**

[Αποδώστε τη διαφάνεια](/slides/el/cpp/convert-powerpoint-to-png/) ή ολόκληρη την παρουσίαση σε PNG ή JPEG. Το SmartArt αποδίδεται ως μέρος της διαφάνειας.

**Πώς μπορώ να βρω ένα συγκεκριμένο αντικείμενο SmartArt σε μια διαφάνεια εάν υπάρχουν πολλά;**

Ορίστε μια διακριτική τιμή [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) ή [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) στο σχήμα SmartArt, αναζητήστε εκείνη την τιμή στο [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/), και στη συνέχεια ελέγξτε ότι το αντίστοιχο σχήμα είναι ένα [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/).