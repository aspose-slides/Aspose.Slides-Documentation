---
title: Περιορισμός Επεξεργασιών Παρουσίασης με Κλειδώματα Σχημάτων σε .NET
linktitle: Περιορισμός Επεξεργασιών Παρουσίασης
type: docs
weight: 70
url: /el/net/applying-protection-to-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να κλειδώνετε και να ξεκλειδώνετε σχήματα σε παρουσιάσεις PPTX με το Aspose.Slides for .NET ώστε να περιορίζετε την επιλογή, τη μετακίνηση, την αλλαγή μεγέθους και την ομαδοποίηση."
---
## **Ιστορικό**

Μία κοινή χρήση του Aspose.Slides for .NET είναι η δημιουργία, ενημέρωση και αποθήκευση παρουσιάσεων PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Όταν οι χρήστες λαμβάνουν αυτές τις παρουσιάσεις, ο περιορισμός των αλλαγών στα σχήματα μπορεί να βοηθήσει στη διατήρηση της προνοημένης διάταξης και του περιεχομένου.

Αυτό το άρθρο εξηγεί πώς οργανώνονται τα σχήματα σε διαφάνειες και πώς να εφαρμόσετε και να αφαιρέσετε κλειδώματα σχημάτων σε μια παρουσίαση PPTX. Αυτά τα κλειδώματα σας επιτρέπουν να περιορίσετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα.

## **Σύνθεση μιας Διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνων, πλαίσια βίντεο, συνδέσμους και άλλα στοιχεία που χρησιμοποιούνται για τη δημιουργία μιας παρουσίασης. Στο Aspose.Slides for .NET, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που υλοποιεί τη διεπαφή [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) ή κληρονομεί από μια κλάση που το κάνει.

Διαφορετικοί τύποι σχημάτων εκθέτουν διαφορετικές επιλογές κλειδώματος. Η διεπαφή [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) είναι η βασική διεπαφή για τα κλειδώματα σχημάτων. Το Aspose.Slides for .NET παρέχει τις παρακάτω διεπαφές κλειδώματος:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) κλειδώνει τα αυτόματα σχήματα.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) κλειδώνει τα σχήματα συνδέσμου.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) κλειδώνει τα γραφικά αντικείμενα.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) κλειδώνει τα ομαδοποιημένα σχήματα.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) κλειδώνει τα πλαίσια εικόνας.  

Για να εφαρμόσετε κλειδώματα σε ολόκληρη μια [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), επαναλάβετε τις διαφάνειες της και ορίστε τα κατάλληλα κλειδώματα σε κάθε υποστηριζόμενο σχήμα.

## **Εφαρμογή και Αφαίρεση Προστασίας**

Τα κλειδώματα σχημάτων περιορίζουν ενέργειες όπως η επιλογή, η μετακίνηση και η αλλαγή μεγέθους των σχημάτων. Δεν καθιστούν ολόκληρη την παρουσίαση μη επεξεργάσιμη.

### **Εφαρμογή Προστασίας σε Σχήματα PPTX**

Το Aspose.Slides for .NET παρέχει τη διεπαφή [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) για εργασία με σχήματα σε μια διαφάνεια.

Το παράδειγμα ορίζει τα [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) και [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) σε `true` για αυτόματα σχήματα, με αντίστοιχα κλειδώματα για ομαδοποιημένα σχήματα, συνδέσμους και πλαίσια εικόνας. Οι σύνδεσμοι χρησιμοποιούν το [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) για μετακίνηση· οι ομάδες χρησιμοποιούν επίσης το [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) για περιορισμό της ομαδοποίησης.

Το παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση PPTX, ελέγχει τα σχήματα στη συλλογή σχημάτων κάθε διαφάνειας και αποθηκεύει ένα αντίγραφο με αυτές τις περιορισμούς εφαρμοσμένους. Τα σχήματα εκτός των τεσσάρων επεξεργασμένων τύπων αφήνονται αμετάβλητα. Η επανάληψη δεν διασχίζει τα παιδικά σχήματα μέσα σε μια ομάδα.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Αφαίρεση Προστασίας**

Για να αφαιρέσετε ένα κλείδωμα σχήματος, ορίστε την τιμή του σε `false`. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση με κλειδώματα σχημάτων και αφαιρεί τους περιορισμούς επιλογής, μετακίνησης και αλλαγής μεγέθους μέσω των [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) και [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Επίσης αφαιρεί το [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) και αποθηκεύει ένα αντίγραφο της παρουσίασης. Οι άλλες ρυθμίσεις κλειδώματος παραμένουν αμετάβλητες.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Συμπέρασμα**

Το Aspose.Slides for .NET σας επιτρέπει να περιορίζετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα ή να εφαρμόζετε τους ίδιους περιορισμούς σε όλες τις διαφάνειες. Επιλέξτε τα κλειδώματα που υποστηρίζονται από κάθε τύπο σχήματος και θέστε τις τιμές τους σε `false` όταν χρειάζεται να αφαιρέσετε αυτούς τους περιορισμούς.

## **Συχνές ερωτήσεις**

**Μπορώ να συνδυάσω κλειδώματα σχημάτων και προστασία κωδικού στην ίδια παρουσίαση;**

Ναι. Τα κλειδώματα σχημάτων περιορίζουν συγκεκριμένες λειτουργίες επεξεργασίας, ενώ η [προστασία κωδικού](/slides/el/net/password-protected-presentation/) μπορεί να περιορίσει το άνοιγμα ή την τροποποίηση της παρουσίασης. Μπορείτε να χρησιμοποιήσετε και τα δύο στο ίδιο αρχείο.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα μόνο στα σχήματα των επιλεγμένων διαφανειών. Αυτό δεν αλλάζει τις ρυθμίσεις κλειδώματος στις άλλες διαφάνειες.

**Πώς μπορώ να εφαρμόσω κλειδώματα σε μεμονωμένα σχήματα μέσα σε μια ομάδα;**

Διασχίστε τη συλλογή [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) της ομάδας και εφαρμόστε τα κατάλληλα κλειδώματα σε κάθε παιδικό σ_shape. Επαναλάβετε αυτό για τυχόν ένθετες ομάδες. Τα παραπάνω παραδείγματα επεξεργάζονται μόνο τη συλλογή σχημάτων της διαφάνειας, οπότε δεν ορίζουν κλειδώματα σε επιμέρους μέλη της ομάδας.