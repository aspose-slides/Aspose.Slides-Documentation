---
title: Περιορισμός Επεξεργασιών Παρουσίασης με Κλείδωμα Σχημάτων σε C++
linktitle: Περιορισμός Επεξεργασιών Παρουσίασης
type: docs
weight: 10
url: /el/cpp/applying-protection-to-presentation/
keywords:
- αποτροπή επεξεργασιών
- προστασία από επεξεργασία
- κλείδωμα σχήματος
- κλείδωμα θέσης
- κλείδωμα επιλογής
- κλείδωμα αλλαγής μεγέθους
- κλείδωμα ομαδοποίησης
- PowerPoint
- PPTX
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να κλειδώνετε και να ξεκλειδώνετε σχήματα σε παρουσιάσεις PPTX με το Aspose.Slides για C++ ώστε να περιορίσετε την επιλογή, κίνηση, αλλαγή μεγέθους και ομαδοποίηση."
---
## **Ιστορικό**

Μια κοινή χρήση του Aspose.Slides for C++ είναι η δημιουργία, ενημέρωση και αποθήκευση παρουσιάσεων PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Όταν οι χρήστες λαμβάνουν αυτές τις παρουσιάσεις, ο περιορισμός των αλλαγών σε σχήματα μπορεί να βοηθήσει στη διατήρηση της προοριζόμενης διάταξης και του περιεχομένου.

Αυτό το άρθρο εξηγεί πώς οργανώνονται τα σχήματα στις διαφάνειες και πώς να εφαρμόσετε και να αφαιρέσετε κλειδώματα σχήματος σε μια παρουσίαση PPTX. Αυτά τα κλειδώματα σας επιτρέπουν να περιορίσετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα.

## **Σύνθεση μιας Διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνων, πλαίσια βίντεο, συνδέσμους και άλλα στοιχεία που χρησιμοποιούνται για την κατασκευή μιας παρουσίασης. Στο Aspose.Slides for C++, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που υλοποιεί το [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) ή κληρονομεί από μια κλάση που το κάνει.

Διαφορετικοί τύποι σχημάτων εκθέτουν διαφορετικές επιλογές κλειδώματος. Η διεπαφή [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) είναι η βασική διεπαφή για κλειδώματα σχημάτων. Το Aspose.Slides for C++ παρέχει τις ακόλουθες διεπαφές κλειδώματος:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) κλειδώνει αυτόματα σχήματα.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) κλειδώνει σχήματα συνδέσμων.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) κλειδώνει γραφικά αντικείμενα.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) κλειδώνει ομαδοποιημένα σχήματα.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) κλειδώνει πλαίσια εικόνων.

Για να εφαρμόσετε κλειδώματα σε μια [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), διασχίστε τις διαφάνειες της και ορίστε τα κατάλληλα κλειδώματα σε κάθε υποστηριζόμενο σχήμα.

## **Εφαρμογή και Αφαίρεση Προστασίας**

Οι συμβατοί επεξεργαστές παρουσιάσεων χρησιμοποιούν κλειδώματα σχήματος για να περιορίσουν μεμονωμένες λειτουργίες επεξεργασίας. Η κρυπτογράφηση αρχείων και η προστασία εγγράφου σε επίπεδο εγγραφής είναι ξεχωριστές [presentation protection settings](/slides/el/cpp/password-protected-presentation/).

### **Εφαρμογή Προστασίας σε Σχήματα PPTX**

Το Aspose.Slides for C++ παρέχει τη διεπαφή [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) για εργασία με σχήματα σε μια διαφάνεια.

Το παράδειγμα περνά το `true` σε [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) και [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) για αυτόματα σχήματα, με ισοδύναμα κλειδώματα για ομαδοποιημένα σχήματα, συνδέσμους και πλαίσια εικόνων. Οι σύνδεσμοι χρησιμοποιούν το [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) για κίνηση· οι ομάδες επίσης χρησιμοποιούν το [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) για περιορισμό ομαδοποίησης.

Το παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση PPTX, ελέγχει τα σχήματα στη συλλογή σχημάτων κάθε διαφάνειας και αποθηκεύει ένα αντίγραφο με τις περιοριστικές ρυθμίσεις εφαρμοσμένες. Τα σχήματα εκτός των τεσσάρων επεξεργαζόμενων τύπων παραμένουν αμετάβλητα. Η επανάληψη δεν διασχίζει τα παιδικά σχήματα μέσα σε μια ομάδα.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(true);
            autoShapeLock->set_SelectLocked(true);
            autoShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(true);
            groupShapeLock->set_PositionLocked(true);
            groupShapeLock->set_SelectLocked(true);
            groupShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(true);
            connectorShapeLock->set_SelectLocked(true);
            connectorShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(true);
            pictureFrameLock->set_SelectLocked(true);
            pictureFrameLock->set_SizeLocked(true);
        }
    }
}

presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Αφαίρεση Προστασίας**

Για να αφαιρέσετε ένα κλείδωμα σχήματος, ορίστε την τιμή του σε `false`. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση με κλειδώματα σχήματος και καθαρίζει τους περιορισμούς επιλογής, κίνησης και αλλαγής μεγέθους μέσω των [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) και [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Καθαρίζει επίσης το [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) και αποθηκεύει ένα αντίγραφο της παρουσίασης. Οι άλλες ρυθμίσεις κλειδώματος παραμένουν αμετάβλητες.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(false);
            autoShapeLock->set_SelectLocked(false);
            autoShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(false);
            groupShapeLock->set_PositionLocked(false);
            groupShapeLock->set_SelectLocked(false);
            groupShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(false);
            connectorShapeLock->set_SelectLocked(false);
            connectorShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(false);
            pictureFrameLock->set_SelectLocked(false);
            pictureFrameLock->set_SizeLocked(false);
        }
    }
}

presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Διατήρηση Κοπής Εικόνας**

Τοποθετήστε μια φωτογραφία με όνομα `photo.jpg` στον κατάλογο εργασίας. Το παράδειγμα περικόπτει 12 % από αριστερά και 8 % από δεξιά, στη συνέχεια καλεί το [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) στο κλείδωμα πλαισίου εικόνας για να διατηρήσει την περικοπή και να περιορίσει περαιτέρω κόψιμο.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto photoBytes = File::ReadAllBytes(u"photo.jpg");
auto photo = presentation->get_Images()->AddImage(photoBytes);

auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, photo);
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_CropLeft(12);
pictureFormat->set_CropRight(8);

auto pictureFrameLock = pictureFrame->get_PictureFrameLock();
pictureFrameLock->set_AspectRatioLocked(false);
pictureFrameLock->set_CropLocked(true);

presentation->Save(u"PictureLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`PictureLocked.pptx` αποθηκεύει το κλείδωμα κοπής ως `true`. Στο PowerPoint, η εντολή **Crop** είναι ανενεργή όταν η φωτογραφία είναι επιλεγμένη.

### **Διατήρηση Διαγράμματος Ομαδοποιημένου**

Το παράδειγμα ομαδοποιεί ένα ορθογώνιο και ένα βέλος, στη συνέχεια καλεί το [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) στο κλείδωμα της ομάδας για να κρατήσει τα στοιχεία του διαγράμματος μαζί. Άλλες επεξεργασίες, όπως η μετακίνηση της ομάδας ή η αλλαγή γεμίσματος ενός στοιχείου, παραμένουν διαθέσιμες.

```cpp
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto groupShape = shapes->AddGroupShape();
auto groupShapes = groupShape->get_Shapes();
groupShapes->AddAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
groupShapes->AddAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
groupShape->get_GroupShapeLock()->set_UngroupingLocked(true);

presentation->Save(u"DiagramLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`DiagramLocked.pptx` αποθηκεύει το κλείδωμα αποδημπολισμού ως `true`. Στο PowerPoint, η εντολή **Ungroup** είναι ανενεργή όταν ολόκληρο το διάγραμμα είναι επιλεγμένο.

### **Αναφορά Υπάρχοντων Κλειδωμάτων Σχήματος**

Για να εξετάσετε ένα πρότυπο, ανοίξτε το και διαβάστε το αντικείμενο κλειδώματος για κάθε σχήμα. Το [get_NoLocks](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/get_nolocks/) επιστρέφει `true` όταν όλες οι σημαίες σε αυτό το αντικείμενο είναι απενεργοποιημένες και `false` όταν τουλάχιστον μία είναι ενεργή. Μια ομάδα και τα παιδιά της έχουν ξεχωριστά αντικείμενα κλειδώματος, επομένως εξετάστε τα παιδιά ακόμη και όταν η ομάδα δεν έχει κλειδώματα.

Αυτό το παράδειγμα ελέγχει κίνηση για αυτόματα σχήματα, πλαίσια εικόνων και ομάδες, περικοπή για εικόνες και αποδημπολισμό για ομάδες. Αναφέρει τις σημαίες που αναγνωρίζει και σηματοδοτεί τύπους σχημάτων που δεν εξετάζει.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/list.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <functional>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

std::function<void(SharedPtr<IShapeCollection>, int, String)> inspect;
inspect = [&inspect](SharedPtr<IShapeCollection> shapes, int slideNumber, String prefix)
{
    for (auto&& shape : IterateOver(shapes))
    {
        auto path = prefix + shape->get_Name();
        auto label = String::Format(u"Slide {0} | {1} | {2}", slideNumber, path, shape->GetType().get_Name());
        auto flags = MakeObject<List<String>>();
        auto group = AsCast<IGroupShape>(shape);

        if (group)
        {
            auto locks = group->get_GroupShapeLock();
            if (locks->get_UngroupingLocked()) flags->Add(u"UngroupingLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto picture = AsCast<IPictureFrame>(shape))
        {
            auto locks = picture->get_PictureFrameLock();
            if (locks->get_CropLocked()) flags->Add(u"CropLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto autoShape = AsCast<IAutoShape>(shape))
        {
            if (autoShape->get_AutoShapeLock()->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else
        {
            Console::WriteLine(label + u" | Uninspected");
            continue;
        }

        if (!shape->get_ShapeLock()->get_NoLocks())
        {
            auto restrictions = flags->get_Count() ? String::Join(u", ", flags->ToArray()) : String(u"Active flag not identified");
            Console::WriteLine(label + u" | " + restrictions);
        }

        if (group)
            inspect(group->get_Shapes(), slideNumber, path + u"/");
    }
};

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    inspect(slide->get_Shapes(), slide->get_SlideNumber(), u"");
}
presentation->Dispose();
```

Υποθέστε ότι η διαφάνεια 1 του `Sample.pptx` περιέχει μια ομάδα με όνομα `Layout` με κλείδωμα αποδημπολισμού, μια εικόνα με όνομα `Photo` μέσα σε αυτήν με κλείδωμα περικοπής, και ένα μη κλειδωμένο ορθογώνιο με όνομα `Free`. Η αναφορά παραλείπει το `Free` και εκτυπώνει αυτές τις δύο γραμμές:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Η αναφορά διαβάζει τις αποθηκευμένες σημαίες επεξεργασίας σε επίπεδο σχήματος χωρίς να τις αλλάξει ή να αποθηκεύσει την παρουσίαση. Η προστασία εγγραφής σε επίπεδο εγγράφου είναι ξεχωριστή ρύθμιση, και η εφαρμογή κάθε σημαίας εξαρτάται από τον επεξεργαστή.

### **Συμπέρασμα**

Το Aspose.Slides for C++ σας επιτρέπει να περιορίζετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα ή να εφαρμόζετε τους ίδιους περιορισμούς σε πολλές διαφάνειες. Επιλέξτε τα κλειδώματα που υποστηρίζονται από κάθε τύπο σχήματος και ορίστε τις τιμές τους σε `false` όταν χρειάζεται να αφαιρέσετε αυτούς τους περιορισμούς.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να συνδυάσω τα κλειδώματα σχημάτων και την προστασία κωδικού πρόσβασης στην ίδια παρουσίαση;**

Ναι. Τα κλειδώματα σχημάτων περιορίζουν συγκεκριμένες λειτουργίες επεξεργασίας, ενώ η [password protection](/slides/el/cpp/password-protected-presentation/) μπορεί να περιορίσει το άνοιγμα ή την τροποποίηση της παρουσίασης. Μπορείτε να χρησιμοποιήσετε και τα δύο στο ίδιο αρχείο.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα μόνο στα σχήματα των επιλεγμένων διαφανειών. Αυτό δεν αλλάζει τις ρυθμίσεις κλειδώματος στις άλλες διαφάνειες.

**Πώς μπορώ να εφαρμόσω κλειδώματα σε μεμονωμένα σχήματα μέσα σε μια ομάδα;**

Διασχίστε τη συλλογή που επιστρέφει η μέθοδος [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) της ομάδας και εφαρμόστε τα κατάλληλα κλειδώματα σε κάθε παιδικό σχήμα. Επαναλάβετε τη διαδικασία για τυχόν ένθετες ομάδες, ακολουθώντας τη διαδρομή στο παράδειγμα αναφοράς.