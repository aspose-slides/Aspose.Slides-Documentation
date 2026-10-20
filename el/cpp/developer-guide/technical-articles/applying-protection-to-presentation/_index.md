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
description: "Μάθετε πώς να κλειδώνετε και να ξεκλειδώνετε σχήματα σε παρουσιάσεις PPTX με το Aspose.Slides for C++ για να περιορίσετε την επιλογή, την κίνηση, την αλλαγή μεγέθους και την ομαδοποίηση."
---
## **Ιστορικό**

Μία κοινή χρήση του Aspose.Slides for C++ είναι η δημιουργία, ενημέρωση και αποθήκευση παρουσιάσεων PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Όταν οι χρήστες λαμβάνουν αυτές τις παρουσιάσεις, ο περιορισμός αλλαγών στα σχήματα μπορεί να βοηθήσει στη διατήρηση της προγραμματισμένης διάταξης και του περιεχομένου.

Αυτό το άρθρο εξηγεί πώς οργανώνονται τα σχήματα στις διαφάνειες και πώς να εφαρμόζετε και να αφαιρείτε κλειδώματα σχήματος σε μια παρουσίαση PPTX. Αυτά τα κλειδώματα σας επιτρέπουν να περιορίζετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα.

## **Σύνθεση μιας Διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνας, πλαίσια βίντεο, συνδέσμους και άλλα στοιχεία που χρησιμοποιούνται για την κατασκευή μιας παρουσίασης. Στο Aspose.Slides for C++, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που υλοποιεί τη διεπαφή [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) ή κληρονομεί από μια κλάση που το κάνει.

Διάφοροι τύποι σχημάτων εκθέτουν διαφορετικές επιλογές κλειδώματος. Η διεπαφή [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) είναι η βασική διεπαφή για κλειδώματα σχημάτων. Το Aspose.Slides for C++ παρέχει τις ακόλουθες διεπαφές κλειδωμάτων:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) κλειδώνει αυτόματα σχήματα.  
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) κλειδώνει σχήματα συνδέσμων.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) κλειδώνει γραφικά αντικείμενα.  
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) κλειδώνει ομαδικά σχήματα.  
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) κλειδώνει πλαίσια εικόνας.

Για να εφαρμόσετε κλειδώματα σε ένα [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), επαναλάβετε τη διαδρομή στις διαφάνειές του και ορίστε τα κατάλληλα κλειδώματα σε κάθε υποστηριζόμενο σχήμα.

## **Εφαρμογή και Αφαίρεση Προστασίας**

Τα κλειδώματα σχημάτων περιορίζουν λειτουργίες όπως η επιλογή, η μετακίνηση και η αλλαγή μεγέθους των σχημάτων. Δεν καθιστούν ολόκληρη την παρουσίαση μη επεξεργάσιμη.

### **Εφαρμογή Προστασίας σε Σχήματα PPTX**

Το Aspose.Slides for C++ παρέχει τη διεπαφή [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) για εργασία με σχήματα σε μια διαφάνεια.

Το παράδειγμα περνά `true` στις μεθόδους [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) και [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) για αυτόματα σχήματα, με ισοδύναμα κλειδώματα για ομαδικά σχήματα, συνδέσμους και πλαίσια εικόνας. Οι συνδέσμοι χρησιμοποιούν τη μέθοδο [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) για κίνηση· οι ομάδες χρησιμοποιούν επίσης το [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) για περιορισμό ομαδοποίησης.

Το παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση PPTX, ελέγχει τα σχήματα στη συλλογή σχημάτων κάθε διαφάνειας και αποθηκεύει ένα αντίγραφο με αυτές τις περιοριστικές ρυθμίσεις. Σχήματα εκτός των τεσσάρων επεξεργαζόμενων τύπων παραμένουν αμετάβλητα. Ο βρόχος δεν διασχίζει τα παιδικά σχήματα εντός μίας ομάδας.

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

Για να αφαιρέσετε ένα κλείδωμα σχήματος, ορίστε την τιμή του σε `false`. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση με κλειδώματα σχημάτων και αφαιρεί τους περιορισμούς επιλογής, κίνησης και αλλαγής μεγέθους μέσω των [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) και [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Επίσης αφαιρεί το [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) και αποθηκεύει ένα αντίγραφο της παρουσίασης. Άλλες ρυθμίσεις κλειδώματος παραμένουν αμετάβλητες.

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

### **Συμπέρασμα**

Το Aspose.Slides for C++ σας επιτρέπει να περιορίζετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα ή να εφαρμόζετε τους ίδιους περιορισμούς σε πολλές διαφάνειες. Επιλέξτε τα κλειδώματα που υποστηρίζονται από κάθε τύπο σχήματος και ορίστε τις τιμές τους σε `false` όταν χρειάζεται να αφαιρέσετε αυτούς τους περιορισμούς.

## **Συχνές Ερωτήσεις**

**Μπορώ να συνδυάσω κλειδώματα σχήματος και προστασία με κωδικό στην ίδια παρουσίαση;**

Ναι. Τα κλειδώματα σχήματος περιορίζουν συγκεκριμένες λειτουργίες επεξεργασίας, ενώ η [προστασία με κωδικό](/slides/el/cpp/password-protected-presentation/) μπορεί να περιορίσει το άνοιγμα ή την τροποποίηση της παρουσίασης. Μπορείτε να χρησιμοποιήσετε και τα δύο στο ίδιο αρχείο.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα μόνο στα σχήματα των επιλεγμένων διαφανειών. Αυτό δεν αλλάζει τις ρυθμίσεις κλειδώματος στις υπόλοιπες διαφάνειες.

**Πώς μπορώ να εφαρμόσω κλειδώματα σε μεμονωμένα σχήματα μέσα σε μια ομάδα;**

Περάστε τη συλλογή που επιστρέφει η μέθοδος [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) της ομάδας και εφαρμόστε τα κατάλληλα κλειδώματα σε κάθε παιδικό σχήμα. Επαναλάβετε τη διαδικασία για τυχόν ένθετες ομάδες. Τα παραδείγματα παραπάνω επεξεργάζονται μόνο τη συλλογή σχημάτων της διαφάνειας, οπότε δεν θέτουν κλειδώματα σε μεμονωμένα μέλη της ομάδας.