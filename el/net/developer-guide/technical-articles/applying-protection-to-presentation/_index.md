---
title: Περιορισμός Επεξεργασιών Παρουσίασης με Κλειδώσεις Σχημάτων σε .NET
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
description: "Μάθετε πώς να κλειδώνετε και να ξεκλειδώνετε σχήματα σε παρουσιάσεις PPTX με το Aspose.Slides για .NET ώστε να περιορίζετε την επιλογή, τη μετακίνηση, την αλλαγή μεγέθους και την ομαδοποίηση."
---
## **Ιστορικό**

Μια συνηθισμένη χρήση του Aspose.Slides for .NET είναι η δημιουργία, ενημέρωση και αποθήκευση παρουσιάσεων PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Όταν οι χρήστες λαμβάνουν αυτές τις παρουσιάσεις, ο περιορισμός των αλλαγών στα σχήματα μπορεί να βοηθήσει στη διατήρηση της προαναγγελισμένης διάταξης και του περιεχομένου.

Αυτό το άρθρο εξηγεί πώς οργανώνονται τα σχήματα στις διαφάνειες και πώς να εφαρμόζετε και να αφαιρείτε τις κλειδώσεις σχήματος σε μια παρουσίαση PPTX. Αυτές οι κλειδώσεις σάς επιτρέπουν να περιορίζετε συγκεκριμένες ενέργειες επεξεργασίας σε μεμονωμένα σχήματα.

## **Σύνθεση Διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από συστατικά όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνας, πλαίσια βίντεο, συνδέσμους και άλλα στοιχεία που χρησιμοποιούνται για τη δημιουργία μιας παρουσίασης. Στο Aspose.Slides for .NET, κάθε στοιχείο σε μία διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που υλοποιεί τη διεπαφή [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) ή κληρονομεί από μια κλάση που το κάνει.

Διαφορετικοί τύποι σχήματος εκθέτουν διαφορετικές επιλογές κλειδώματος. Η διεπαφή [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) είναι η βασική διεπαφή για κλειδώσεις σχήματος. Το Aspose.Slides for .NET παρέχει τις παρακάτω διεπαφές κλειδώματος:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) κλειδώνει τα αυτόματα σχήματα.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) κλειδώνει τα σχήματα συνδέσμων.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) κλειδώνει τα γραφικά αντικείμενα.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) κλειδώνει τα ομαδοποιημένα σχήματα.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) κλειδώνει τα πλαίσια εικόνας.  

Για να εφαρμόσετε κλειδώσεις σε όλη τη [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), επαναλάβετε τις διαφάνειες της και ορίστε τις κατάλληλες κλειδώσεις σε κάθε υποστηριζόμενο σχήμα.

## **Εφαρμογή και Κατάργηση Προστασίας**

Συμβατοί επεξεργαστές παρουσίασης χρησιμοποιούν κλειδώσεις σχήματος για να περιορίζουν τις μεμονωμένες ενέργειες επεξεργασίας. Η κρυπτογράφηση αρχείου και η προστασία εγγραφής σε επίπεδο εγγράφου είναι ξεχωριστές [ρυθμίσεις προστασίας παρουσίασης](/slides/el/net/password-protected-presentation/).

### **Εφαρμογή Προστασίας σε Σχήματα PPTX**

Το Aspose.Slides for .NET παρέχει τη διεπαφή [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) για εργασία με σχήματα σε μία διαφάνεια.

Το παράδειγμα ορίζει τα [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/), και [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) σε `true` για τα αυτόματα σχήματα, με ισοδύναμες κλειδώσεις για ομαδοποιημένα σχήματα, συνδέσμους και πλαίσια εικόνας. Οι σύνδεσμοι χρησιμοποιούν το [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) για κίνηση· οι ομάδες επίσης χρησιμοποιούν το [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) για περιορισμό ομαδοποίησης.

Το παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση PPTX, ελέγχει τα σχήματα σε κάθε συλλογή σχημάτων της διαφάνειας και αποθηκεύει ένα αντίγραφο με αυτές τις περιοριστικές ρυθμίσεις εφαρμοσμένες. Τα σχήματα εκτός των τεσσάρων επεξεργαζόμενων τύπων παραμένουν αμετάβλητα. Ο βρόχος δεν διασχίζει τα παιδικά σχήματα μέσα σε μια ομάδα.

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

### **Κατάργηση Προστασίας**

Για να αφαιρέσετε μια κλήδωση σχήματος, ορίστε την τιμή της σε `false`. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση με κλειδώσεις σχήματος και αφαιρεί τους περιορισμούς επιλογής, κίνησης και αλλαγής μεγέθους μέσω των [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), και [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Επιπλέον, αφαιρεί το [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) και αποθηκεύει ένα αντίγραφο της παρουσίασης. Οι άλλες ρυθμίσεις κλειδώματος παραμένουν αμετάβλητες.

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

### **Διατήρηση Περικοπής Εικόνας**

Τοποθετήστε μια φωτογραφία με όνομα `photo.jpg` στον φάκελο εργασίας. Το παράδειγμα περικόπτει το 12% από την αριστερή πλευρά και το 8% από τη δεξιά, μετά ορίζει το [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) στο πλαίσιο εικόνας. Αυτή η σημαία περιορίζει περαιτέρω περικοπές και διατηρεί την υπάρχουσα περικοπή.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` αποθηκεύει το κλείδωμα περικοπής ως `true`. Στο PowerPoint, η εντολή **Crop** είναι απενεργοποιημένη όταν η φωτογραφία είναι επιλεγμένη.

### **Διατήρηση Διαγράμματος Ομαδοποιημένου**

Το παράδειγμα ομαδοποιεί ένα ορθογώνιο και ένα βέλος, μετά ορίζει το [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) στην ίδια την ομάδα για να διατηρήσει τα στοιχεία του διαγράμματος μαζί. Άλλες επεξεργασίες, όπως η μετακίνηση της ομάδας ή η αλλαγή γεμίσματος ενός στοιχείου, παραμένουν διαθέσιμες.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` αποθηκεύει το κλείδωμα αποομαδοποίησης ως `true`. Στο PowerPoint, η εντολή **Ungroup** είναι απενεργοποιημένη όταν ολόκληρο το διάγραμμα είναι επιλεγμένο.

## **Συμπέρασμα**

Το Aspose.Slides for .NET σας επιτρέπει να περιορίζετε συγκεκριμένες ενέργειες επεξεργασίας σε μεμονωμένα σχήματα ή να εφαρμόζετε τους ίδιους περιορισμούς σε όλες τις διαφάνειες. Επιλέξτε τις κλειδώσεις που υποστηρίζονται από κάθε τύπο σχήματος και ορίστε τις τιμές τους σε `false` όταν χρειάζεται να αφαιρέσετε αυτούς τους περιορισμούς.

## **Συχνές Ερωτήσεις**

**Μπορώ να συνδυάσω τις κλειδώσεις σχήματος και την προστασία με κωδικό στην ίδια παρουσίαση;**

Ναι. Οι κλειδώσεις σχήματος περιορίζουν συγκεκριμένες ενέργειες επεξεργασίας, ενώ η [προστασία με κωδικό](/slides/el/net/password-protected-presentation/) μπορεί να περιορίσει το άνοιγμα ή την τροποποίηση της παρουσίασης. Μπορείτε να χρησιμοποιήσετε και τις δύο στο ίδιο αρχείο.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώσεις μόνο στα σχήματα των επιλεγμένων διαφανειών. Αυτό δεν αλλάζει τις ρυθμίσεις κλειδώματος στις άλλες διαφάνειες.

**Πώς μπορώ να εφαρμόσω κλειδώσεις σε μεμονωμένα σχήματα μέσα σε μια ομάδα;**

Περάστε μέσω της συλλογής [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) της ομάδας και εφαρμόστε τις κατάλληλες κλειδώσεις σε κάθε παιδικό σχήμα. Επαναλάβετε αυτή τη διαδικασία για τυχόν ένθετες ομάδες. Τα παραπάνω παραδείγματα επεξεργάζονται μόνο τη συλλογή σχημάτων της διαφάνειας, έτσι δεν ορίζουν κλειδώσεις σε μεμονωμένα μέλη της ομάδας.