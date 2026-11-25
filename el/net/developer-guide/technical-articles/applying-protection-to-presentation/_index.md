---
title: Περιορισμός Επεξεργασιών Παρουσίασης με Κλειδώματα Σχημάτων στο .NET
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
description: "Μάθετε πώς να κλειδώνετε και να ξεκλειδώνετε σχήματα σε παρουσιάσεις PPTX με το Aspose.Slides για .NET, ώστε να περιορίζετε την επιλογή, κίνηση, αλλαγή μεγέθους και ομαδοποίηση."
---
## **Ιστορικό**

Μία κοινή χρήση του Aspose.Slides for .NET είναι η δημιουργία, ενημέρωση και αποθήκευση παρουσιάσεων PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Όταν οι χρήστες λαμβάνουν αυτές τις παρουσιάσεις, ο περιορισμός των αλλαγών στα σχήματα μπορεί να βοηθήσει στη διατήρηση της προβλεπόμενης διάταξης και του περιεχομένου.

Αυτό το άρθρο εξηγεί πώς οργανώνονται τα σχήματα στις διαφάνειες και πώς να εφαρμόσετε και να αφαιρέσετε κλειδώματα σχήματος σε μια παρουσίαση PPTX. Αυτά τα κλειδώματα σας επιτρέπουν να περιορίζετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα.

## **Σύνθεση μιας Διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνας, πλαίσια βίντεο, συνδέσμους και άλλα στοιχεία που χρησιμοποιούνται για την κατασκευή μιας παρουσίασης. Στο Aspose.Slides for .NET, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που υλοποιεί τη διεπαφή [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) ή κληρονομεί από μια κλάση που το κάνει.

Διάφοροι τύποι σχημάτων εκθέτουν διαφορετικές επιλογές κλειδωμάτων. Η διεπαφή [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) είναι η βασική διεπαφή για κλειδώματα σχημάτων. Το Aspose.Slides for .NET παρέχει τις ακόλουθες διεπαφές κλειδωμάτων:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) κλειδώνει τα αυτόματα σχήματα.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) κλειδώνει τα σχήματα συνδέσμων.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) κλειδώνει τα γραφικά αντικείμενα.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) κλειδώνει τα ομαδοποιημένα σχήματα.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) κλειδώνει τα πλαίσια εικόνας.  

Για να εφαρμόσετε κλειδώματα σε όλη τη [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), κάντε επανάληψη στις διαφάνειες της και ορίστε τα κατάλληλα κλειδώματα σε κάθε υποστηριζόμενο σχήμα.

## **Εφαρμογή και Αφαίρεση Προστασίας**

Συμβατοί επεξεργαστές παρουσιάσεων χρησιμοποιούν κλειδώματα σχήματος για να περιορίσουν μεμονωμένες λειτουργίες επεξεργασίας. Η κρυπτογράφηση αρχείων και η προστασία εγγραφής σε επίπεδο εγγράφου είναι ξεχωριστές [ρυθμίσεις προστασίας παρουσίασης](/slides/el/net/password-protected-presentation/).

### **Εφαρμογή Προστασίας σε Σχήματα PPTX**

Το Aspose.Slides for .NET παρέχει τη διεπαφή [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) για εργασία με σχήματα σε μια διαφάνεια.

Το παράδειγμα ορίζει τα [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) και [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) σε `true` για τα αυτόματα σχήματα, με ισοδύναμα κλειδώματα για ομαδοποιημένα σχήματα, συνδέσμους και πλαίσια εικόνας. Οι σύνδεσμοι χρησιμοποιούν το [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) για κίνηση· οι ομάδες επίσης χρησιμοποιούν το [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) για να περιορίσουν την ομαδοποίηση.

Το παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση PPTX, ελέγχει τα σχήματα στη συλλογή σχημάτων κάθε διαφάνειας και αποθηκεύει ένα αντίγραφο με τις εφαρμοσμένες περιορισμούς. Τα σχήματα εκτός των τεσσάρων επεξεργασμένων τύπων παραμένουν αμετάβλητα. Η βρόχος δεν διασχίζει τα παιδικά σχήματα μέσα σε μια ομάδα.

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

Για να αφαιρέσετε ένα κλείδωμα σχήματος, ορίστε την τιμή του σε `false`. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση με κλειδώματα σχήματος και καθαρίζει τους περιορισμούς επιλογής, κίνησης και αλλαγής μεγέθους μέσω των [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) και [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Καθαρίζει επίσης το [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) και αποθηκεύει ένα αντίγραφο της παρουσίασης. Οι άλλες ρυθμίσεις κλειδωμάτων παραμένουν αμετάβλητες.

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

### **Διατήρηση Κόψιμου Εικόνας**

Τοποθετήστε μια φωτογραφία με όνομα `photo.jpg` στον εργασιακό κατάλογο. Το παράδειγμα κόβει 12% από την αριστερά και 8% από τη δεξιά, έπειτα ορίζει το [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) στο πλαίσιο εικόνας. Αυτή η σημαία περιορίζει περαιτέρω κοπή και διατηρεί το υπάρχον κλάπ.

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

`PictureLocked.pptx` αποθηκεύει το κλείδωμα κόψιμου ως `true`. Στο PowerPoint, η εντολή **Crop** απενεργοποιείται όταν η φωτογραφία είναι επιλεγμένη.

### **Διατήρηση Διαγράμματος Ομαδοποιημένου**

Το παράδειγμα ομαδοποιεί ένα ορθογώνιο και ένα βέλος, έπειτα ορίζει το [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) στην ίδια την ομάδα για να διατηρήσει τα στοιχεία του διαγράμματος μαζί. Άλλες επεξεργασίες, όπως η μετακίνηση της ομάδας ή η αλλαγή γεμίσματος ενός στοιχείου, παραμένουν διαθέσιμες.

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

`DiagramLocked.pptx` αποθηκεύει το κλείδωμα αποομαδοποίησης ως `true`. Στο PowerPoint, η εντολή **Ungroup** απενεργοποιείται όταν ολόκληρο το διάγραμμα είναι επιλεγμένο.

### **Αναφορά Υφιστάμενων Κλειδωμάτων Σχήματος**

Για να ελέγξετε ένα πρότυπο, ανοίξτε το και διαβάστε το αντικείμενο κλειδώματος για κάθε σχήμα. Το [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) είναι `true` όταν όλες οι σημαίες σε αυτό το αντικείμενο είναι απενεργοποιημένες και `false` όταν τουλάχιστον μία είναι ενεργή. Μια ομάδα και τα παιδιά της έχουν ξεχωριστά αντικείμενα κλειδωμάτων, επομένως ελέγξτε τα παιδιά ακόμη και όταν η ομάδα δεν έχει κλειδώματα.

Αυτό το παράδειγμα ελέγχει την κίνηση για αυτόματα σχήματα, πλαίσια εικόνας και ομάδες, την κοπή για εικόνες και την αποομαδοποίηση για ομάδες. Αναφέρει τις σημαίες που αναγνωρίζει και σημειώνει τύπους σχημάτων που δεν εξετάζει.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

Ας υποθέσουμε ότι η διαφάνεια 1 του `Sample.pptx` περιέχει μια ομάδα με όνομα `Layout` με κλείδωμα αποομαδοποίησης, μια εικόνα με όνομα `Photo` μέσα σε αυτήν με κλείδωμα κόψιμου, και ένα μη κλειδωμένο ορθογώνιο με όνομα `Free`. Η αναφορά παραλείπει το `Free` και εκτυπώνει αυτές τις δύο γραμμές:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Η αναφορά διαβάζει τις αποθηκευμένες σημαίες επεξεργασίας επιπέδου σχήματος χωρίς να τις αλλάξει ή να αποθηκεύσει την παρουσίαση. Η προστασία εγγραφής σε επίπεδο εγγράφου είναι ξεχωριστή ρύθμιση, και η επιβολή κάθε σημαίας εξαρτάται από τον επεξεργαστή.

## **Συμπέρασμα**

Το Aspose.Slides for .NET σας επιτρέπει να περιορίζετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα ή να εφαρμόζετε τους ίδιους περιορισμούς σε όλες τις διαφάνειες. Επιλέξτε τα κλειδώματα που υποστηρίζονται από κάθε τύπο σχήματος και ορίστε τις τιμές τους σε `false` όταν χρειάζεται να αφαιρέσετε αυτούς τους περιορισμούς.

## **Συχνές Ερωτήσεις**

**Μπορώ να συνδυάσω κλειδώματα σχήματος και προστασία με κωδικό στην ίδια παρουσίαση;**

Ναι. Τα κλειδώματα σχήματος περιορίζουν συγκεκριμένες λειτουργίες επεξεργασίας, ενώ η [προστασία με κωδικό](/slides/el/net/password-protected-presentation/) μπορεί να περιορίσει το άνοιγμα ή την τροποποίηση της παρουσίασης. Μπορείτε να χρησιμοποιήσετε και τα δύο στο ίδιο αρχείο.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα μόνο στα σχήματα των επιλεγμένων διαφανειών. Αυτό δεν αλλάζει τις ρυθμίσεις κλειδωμάτων σε άλλες διαφάνειες.

**Πώς μπορώ να εφαρμόσω κλειδώματα σε μεμονωμένα σχήματα μέσα σε μια ομάδα;**

Κάντε επανάληψη στη συλλογή [Σχήματα](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) της ομάδας και εφαρμόστε τα κατάλληλα κλειδώματα σε κάθε παιδικό σχήμα. Επαναλάβετε αυτή τη διαδικασία για τυχόν ένθετες ομάδες, ακολουθώντας τη διαδρομή στο παράδειγμα αναφοράς.