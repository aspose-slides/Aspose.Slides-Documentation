---
title: Διαχείριση SmartArt σε Παρουσιάσεις PowerPoint με C++
linktitle: Διαχείριση SmartArt
type: docs
weight: 10
url: /el/cpp/manage-smartart/
keywords:
- SmartArt
- Κείμενο SmartArt
- τύπος διάταξης
- ιδιότητα κρυφής
- οργανογράφημα
- οργανογράφημα με εικόνα
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε να δημιουργείτε και να επεξεργάζεστε SmartArt του PowerPoint με το Aspose.Slides για C++ χρησιμοποιώντας σαφή παραδείγματα κώδικα που επιταχύνουν το σχεδιασμό και την αυτοματοποίηση των διαφανειών."
---
## **Επισκόπηση**

Το SmartArt είναι ένα διάγραμμα PowerPoint που δημιουργείται από κόμβους, σχήματα κόμβων και μια διάταξη. Με το Aspose.Slides for C++, μπορείτε να δημιουργήσετε SmartArt, να διαβάσετε κείμενο από τους κόμβους του, να αλλάξετε τη διάταξή του, να εξετάσετε κρυφούς κόμβους, να διαμορφώσετε διατάξεις οργανωτικού διαγράμματος και να δημιουργήσετε διαγράμματα οργανωτικού με εικόνα.

## **Ανάγνωση Κειμένου από Αντικείμενο SmartArt**

Ένας κόμβος SmartArt μπορεί να περιέχει ένα ή περισσότερα σχήματα. Για να διαβάσετε το ορατό κείμενο, επαναλάβετε μέσω του [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/smartart/get_allnodes/), στη συνέχεια διαβάστε το [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) που επιστρέφεται από το [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/smartartshape/get_textframe/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```
## **Αλλαγή του Τύπου Διάταξης ενός Αντικειμένου SmartArt**

Η διάταξη SmartArt ελέγχει πώς διατάσσονται και συνδέονται οι κόμβοι. Το ακόλουθο παράδειγμα δημιουργεί ένα αντικείμενο SmartArt με την τιμή `BasicBlockList` του [SmartArtLayoutType](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/smartartlayouttype/), την αλλάζει στην τιμή `BasicProcess` και αποθηκεύει την παρουσίαση.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```
## **Έλεγχος Εάν ένας Κόμβος SmartArt Είναι Κρυμμένος**

Η μέθοδος [ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) υποδεικνύει εάν ο κόμβος είναι κρυμμένος στο μοντέλο δεδομένων SmartArt. Οι κρυφοί κόμβοι μπορούν να υπάρχουν στη δομή ακόμη και όταν η επιλεγμένη διάταξη δεν τους εμφανίζει ως ορατά στοιχεία διαγράμματος.

Το ακόλουθο παράδειγμα προσθέτει έναν κόμβο σε ένα αντικείμενο SmartArt που χρησιμοποιεί την τιμή `RadialCycle` του [SmartArtLayoutType](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/smartartlayouttype/), και ελέγχει την κρυφή κατάσταση του κόμβου.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```
## **Ανάκτηση ή Ορισμός της Διάταξης Οργανογράμματος**

Για διαγράμματα SmartArt που χρησιμοποιούν διάταξη οργανογράμματος, οι μέθοδοι [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) και [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) ορίζουν πώς διατάσσονται οι υποκόμβοι κάτω από έναν γονικό κόμβο. Για παράδειγμα, μπορείτε να ορίσετε οι υποκόμβοι να κρέμονται από αριστερά, δεξιά ή και από τις δύο πλευρές, ανάλογα με την επιλεγμένη [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/organizationchartlayouttype/).

Το ακόλουθο παράδειγμα δημιουργεί ένα οργανογράφημα και ορίζει τη διάταξη για τον πρώτο κόμβο στην τιμή `LeftHanging` του [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/organizationchartlayouttype/).

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```
## **Δημιουργία Εικόνας Οργανωτικού Διαγράμματος**

Το διάγραμμα οργανογράμματος με εικόνα είναι μια διάταξη SmartArt σχεδιασμένη για διαγράμματα ιεραρχίας που περιλαμβάνουν θέσεις εικόνας. Χρησιμοποιήστε την τιμή `PictureOrganizationChart` του [SmartArtLayoutType](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/smartartlayouttype/) όταν προσθέτετε το αντικείμενο SmartArt σε μια διαφάνεια.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```
## **Συχνές Ερωτήσεις**

**Υποστηρίζει το SmartArt την ανάστροφη ή την καθρέφτισή του για γλώσσες RTL;**

Ναι. Η μέθοδος [SmartArt::set_IsReversed](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/smartart/set_isreversed/) αλλάζει την κατεύθυνση του διαγράμματος από αριστερά προς δεξιά σε δεξιά προς αριστερά, ή το αντίστροφο, όταν η επιλεγμένη διάταξη SmartArt υποστηρίζει την αντιστροφή.

**Πώς μπορώ να αντιγράψω το SmartArt στην ίδια διαφάνεια ή σε άλλη παρουσίαση ενώ διατηρώ τη μορφοποίηση;**

Μπορείτε να [κλωνοποιήσετε το σχήμα SmartArt](/slides/el/cpp/shape-manipulations/) με το [ShapeCollection::AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/shapecollection/addclone/) ή να [κλωνοποιήσετε ολόκληρη τη διαφάνεια](/slides/el/cpp/clone-slides/) που περιέχει το SmartArt. Και οι δύο προσεγγίσεις διατηρούν το μέγεθος, τη θέση και τη μορφοποίηση.

**Πώς μπορώ να αποδώσω το SmartArt σε εικόνα raster για προεπισκόπηση ή εξαγωγή στο web;**

Μπορείτε να [αποδώσετε τη διαφάνεια](/slides/el/cpp/convert-powerpoint-to-png/) ή ολόκληρη την παρουσίαση σε PNG ή JPEG. Το SmartArt αποδίδεται ως μέρος της διαφάνειας.

**Πώς μπορώ να βρω ένα συγκεκριμένο αντικείμενο SmartArt σε μια διαφάνεια εάν υπάρχουν πολλά;**

Ορίστε μια χαρακτηριστική τιμή στο [Shape::set_AlternativeText](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/set_alternativetext/) ή στο [Shape::set_Name](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/set_name/) του σχήματος SmartArt, αναζητήστε αυτήν την τιμή στο [BaseSlide::get_Shapes](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseslide/get_shapes/), και στη συνέχεια ελέγξτε ότι το αντίστοιχο σχήμα είναι ένα [ISmartArt](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/ismartart/).