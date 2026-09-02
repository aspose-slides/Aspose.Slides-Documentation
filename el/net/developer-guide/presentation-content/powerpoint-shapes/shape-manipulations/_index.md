---
title: Διαχείριση Σχημάτων Παρουσίασης σε .NET
linktitle: Διαχείριση Σχημάτων
type: docs
weight: 40
url: /el/net/shape-manipulations/
keywords:
- σχήμα PowerPoint
- σχήμα παρουσίασης
- σχήμα στη διαφάνεια
- εύρεση σχήματος
- κλωνοποίηση σχήματος
- κατάργηση σχήματος
- απόκρυψη σχήματος
- αλλαγή σειράς σχήματος
- λήψη ID σχήματος interop
- εναλλακτικό κείμενο σχήματος
- σημείο προσαρμογής σχήματος
- προεπιλεγμένη προσαρμογή σχήματος
- γεωμετρία σχήματος
- μορφές διάταξης σχήματος
- σχήμα ως SVG
- σχήμα σε SVG
- στοίχιση σχήματος
- αναστροφή σχήματος
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να ταυτοποιείτε, να ρυθμίζετε, να κλωνοποιείτε, να καταργείτε, να αποκρύπτετε, να αναδιατάσσετε, να εξάγετε, να στοιχίζετε και να αναστρέφετε σχήματα παρουσίασης με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Το Aspose.Slides για .NET αναπαριστά τα σχήματα σε μια διαφάνεια ως μια διατεταγμένη [IShapeCollection](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/). Η συλλογή είναι ταυτόχρονα το σημείο όπου βρίσκετε και τροποποιείτε τα σχήματα και η πηγή της σειράς στοίβας: ο δείκτης `0` είναι το πιο πίσω σχήμα, ενώ ο τελευταίος δείκτης είναι το πιο εμπρός σχήμα.

Αυτό το άρθρο ακολουθεί αυτό το μοντέλο. Πρώτα εξηγεί πώς να αναγνωρίζετε ένα σκέυος αξιόπιστα και να τροποποιείτε τις προκαθορισμένες ρυθμίσεις προσαρμογής σχήματος, στη συνέχεια δείχνει πώς να κλωνοποιείτε, να καταργείτε, να κρύβετε και να αναδιατάσσετε σχήματα. Τα τελικά τμήματα καλύπτουν μορφοποίηση σε επίπεδο διάταξης, εξαγωγή SVG, στοίχιση και ρυθμίσεις αναστροφής. Κάθε παράδειγμα είναι ανεξάρτητο, ώστε να μπορείτε να χρησιμοποιήσετε μόνο τις ενέργειες που απαιτεί η ροή εργασίας σας.

## **Αναγνώριση και Εύρεση Σχημάτων**

Οι δείκτες της συλλογής είναι βολικοί κατά την επεξεργασία ενός γνωστού αρχείου, αλλά δεν αποτελούν σταθερά αναγνωριστικά. Η προσθήκη, η κατάργηση ή η αναδιάταξη ενός σχήματος μπορεί να αλλάξει τον δείκτη του. Επιλέξτε ένα αναγνωριστικό ανάλογα με το πώς δημιουργείται και συντηρείται η παρουσίαση:

- [Name](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/name/) είναι χρήσιμο για πρότυπα ελεγχόμενα από προγραμματιστές και είναι εύκολο να το επιθεωρήσετε στον Πίνακα Επιλογής του PowerPoint. Τα ονόματα μπορούν να επεξεργαστούν και δεν εγγυούνται μοναδικότητα, επομένως καθιερώστε μια σύμβαση ονοματοδοσίας εάν ο κώδικας εξαρτάται από αυτά.
- [AlternativeText](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/alternativetext/) είναι χρήσιμο όταν μια περιγραφή προσβασιμότητας ή μια ετικέτα που έδωσε ο δημιουργός ήδη ταυτοποιεί το σχήμα. Είναι ορατό στους χρήστες, μπορεί να μεταφραστεί ή να ξαναγραφεί για προσβασιμότητα και δεν εγγυάται μοναδικότητα. Μην επαναχρησιμοποιείτε σιωπηλά σημαντικό κείμενο προσβασιμότητας ως κλειδί βάσης δεδομένων.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/officeinteropshapeid/) είναι ένα μόνο‑ανάγνωση αναγνωριστικό που είναι μοναδικό σε μια διαφάνεια και αντιστοιχεί στο ID σχήματος που χρησιμοποιεί το PowerPoint interop. Χρησιμοποιήστε το όταν ενσωματώνετε με το PowerPoint ή όταν χρειάζεστε μια ασαφή αναφορά κατά τη διάρκεια της ζωής ενός σχήματος. Ένα κλωνοποιημένο ή επαναδημιουργημένο σχήμα είναι διαφορετικό σχήμα και λαμβάνει το δικό του ID.

Η σχετική ιδιότητα [UniqueId](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/uniqueid/) έχει εμβέλεια παρουσίασης, αλλά προορίζεται για πρόσθετα και μπορεί να επανεκχωρηθεί. Δεν θα πρέπει να θεωρείται μόνιμο εξωτερικό κλειδί. Εάν η μακροπρόθεσμη ταυτότητα είναι ουσιαστική, διατηρήστε την αντιστοίχιση σε δεδομένα εφαρμογής και επαληθεύστε ότι το αναμενόμενο σχήμα υπάρχει ακόμη.

Το παρακάτω παράδειγμα αναζητεί με βάση το `Name` με ορθογραφική σύγκριση και αναφέρει το ID interop περιορισμένο στη διαφάνεια. Όταν το πρότυπο δεν περιέχει το αναμενόμενο σχήμα, ο κώδικας αναφέρει το αποτέλεσμα αυτό αντί να συνεχίσει με το λανθασμένο αντικείμενο.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

Όταν μια λειτουργία είναι συγκεκριμένη για έναν τύπο σχήματος, ελέγξτε τη διεπαφή πριν χρησιμοποιήσετε μέλη τύπου‑συγκεκριμένα. Αυτό το παράδειγμα ενημερώνει το κείμενο και το εναλλακτικό κείμενο μόνο εάν το ονομασμένο αντικείμενο είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **Αναγνώριση και Τροποποίηση Προκαθορισμένων Ρυθμίσεων Σχήματος**

Τα σχήματα γεωμετρίας προεπιλογής μπορούν να εκθέσουν σημεία ρύθμισης που ελέγχουν λειτουργίες όπως το μέγεθος γωνίας, τις αναλογίες βέλους ή τις γωνίες τόξου. Έχετε πρόσβαση σε αυτά μέσω της μόνο‑ανάγνωσης συλλογής [IGeometryShape.Adjustments](https://reference.aspose.com/slides/el/net/aspose.slides/igeometryshape/adjustments/). Η συλλογή παρέχεται από το σχήμα, αλλά κάθε [IAdjustValue](https://reference.aspose.com/slides/el/net/aspose.slides/iadjustvalue/) περιέχει μια τιμή που μπορεί να αλλάξει.

Μην βασίζεστε μόνο σε έναν σταθερό δείκτη συλλογής. Διατρέξτε τις ρυθμίσεις και ελέγξτε την μόνο‑ανάγνωσης ιδιότητα [Type](https://reference.aspose.com/slides/el/net/aspose.slides/adjustvalue/type/), της οποίας η τιμή [ShapeAdjustmentType](https://reference.aspose.com/slides/el/net/aspose.slides/shapeadjustmenttype/) περιγράφει τι ελέγχει η ρύθμιση. Η μόνο‑ανάγνωσης ιδιότητα [Name](https://reference.aspose.com/slides/el/net/aspose.slides/adjustvalue/name/) παρέχει πρόσθετες πληροφορίες ταυτοποίησης και είναι ιδιαίτερα χρήσιμη όταν μια προεπιλογή περιέχει περισσότερες από μία ρυθμίσεις με τον ίδιο σημασιολογικό τύπο.

Χρησιμοποιήστε την ιδιότητα τιμής που ταιριάζει με το νόημα της ρύθμισης:

| Τύπος ρύθμισης | Σκοπός | Τιμή προς αλλαγή |
|---|---|---|
| `CornerSize` | Μέγεθος στρογγυλεμένων γωνιών | [RawValue](https://reference.aspose.com/slides/el/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Πάχος ουράς βέλους | `RawValue` |
| `ArrowheadLength` | Μήκος κεφαλής βέλους | `RawValue` |
| `ArrowheadWidth` | Πλάτος κεφαλής βέλους | `RawValue` |
| `StartAngle` | Αρχική γωνία πίτας ή τόξου | [AngleValue](https://reference.aspose.com/slides/el/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Τελική γωνία πίτας ή τόξου | `AngleValue` |

`Type` και `Name` δεν μπορούν να εκχωρηθούν. `RawValue` είναι ακέραιος ανάγνωσης/εγγραφής στις εγγενείς μονάδες γεωμετρίας της προεπιλογής, ενώ `AngleValue` είναι γωνία ανάγνωσης/εγγραφής σε μοίρες. Ο αριθμός, η σειρά, το νόημα και το έγκυρο εύρος των ρυθμίσεων εξαρτώνται από τον προεπιλεγμένο [ShapeType](https://reference.aspose.com/slides/el/net/aspose.slides/igeometryshape/shapetype/). Μία τιμή που είναι έγκυρη για μια προεπιλογή μπορεί να είναι άκυρη ή να έχει διαφορετικό αποτέλεσμα για άλλη.

Όταν `Type` είναι `ShapeAdjustmentType.Custom`, το API δεν αναγνωρίζει τυπικό σημασιολογικό νόημα. Επιθεωρήστε το `Name`, τον τύπο προεπιλογής και την υπάρχουσα τιμή, και αφήστε τη ρύθμιση αμετάβλητη εκτός εάν γνωρίζετε το αναμενόμενο νόημα και εύρος. Ακόμη και για αναγνωρισμένους τύπους, ελέγξτε αν ο ίδιος τύπος εμφανίζεται περισσότερες από μία φορές πριν επιλέξετε τιμή. Το άρθρο [Connector](/slides/el/net/connector/) δείχνει αυτή την κατάσταση με προσαρμογές κάμψης συνδέσμου.

Το παρακάτω πλήρες παράδειγμα δημιουργεί προεπιλεγμένες και τροποποιημένες εκδόσεις τριών προεπιλεγμένων σχημάτων. Διατρέχει κάθε ρύθμιση, αναφέρει το `Name` και το `Type`, αλλάζει τιμές σχετικές με το μέγεθος μέσω `RawValue`, αλλάζει γωνίες μέσω `AngleValue`, και αποθηκεύει το αποτέλεσμα. Στην αριστερή στήλη παραμένει η προεπιλεγμένη γεωμετρία· στη δεξιά στήλη εμφανίζεται το προσαρμοσμένο στρογγυλεμένο ορθογώνιο, το τετράπλευρο βέλος και η πίτα.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Προσθέτει κεφαλίδες για τις στήλες προεπιλεγμένου και προσαρμοσμένου σχήματος.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

Ο έλεγχος του σημασιολογικού τύπου πριν την αλλαγή μιας τιμής κάνει τον κώδικα σαφή ως προς το σκοπό του και αποτρέπει την υπόθεση ότι ένας συγκεκριμένος δείκτης συλλογής έχει το ίδιο νόημα σε διαφορετικά προεπιλεγμένα σχήματα.

## **Τροποποίηση της Συλλογής Σχημάτων**

Οι μέθοδοι προσθήκης, κλωνοποίησης, κατάργησης και αναδιάταξης λειτουργούν άμεσα στη συλλογή. Εάν μια λειτουργία αλλάζει τον αριθμό ή τη σειρά των σχημάτων, μην συνεχίσετε να βασίζεστε σε δείκτες που καταγράφηκαν πριν από εκείνη τη λειτουργία.

### **Κλωνοποίηση Σχήματος**

[AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addclone/) δημιουργεί ανεξάρτητο αντίγραφο και το προσθέτει στο στόχο συλλογής. [InsertClone](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/insertclone/) επίσης δημιουργεί αντίγραφο αλλά το τοποθετεί σε έναν καθορισμένο δείκτη z‑order. Οι υπερφορτώσεις που δέχονται συντεταγμένες μετακινούν το κλώνο χωρίς να αλλάζουν το μέγεθός του· οι υπερφορτώσεις με πλάτος και ύψος μπορούν επίσης να το επαναμεγεθύνουν.

Το παράδειγμα δημιουργεί μια προοριζόμενη διαφάνεια, κλωνοποιεί ένα ορθογώνιο με ετικέτα προς τα εμπρός, και εισάγει ένα δεύτερο κλώνο στο πίσω μέρος. Οι αλλαγές σε οποιονδήποτε κλώνο δεν τροποποιούν το σχήμα προέλευσης.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

Η κλωνοποίηση αντιγράφει το περιεχόμενο και τη μορφοποίηση του σχήματος, συμπεριλαμβανομένων του ονόματος και του εναλλακτικού κειμένου. Αναθέστε νέες λογικές ταυτοποιήσεις στο κλώνο όταν αυτές οι τιμές πρέπει να είναι μοναδικές. Οι πόροι που χρησιμοποιούν σύνθετα σχήματα διαχειρίζονται από την παρουσίαση, αλλά ένα κλώνο παραμένει νέο στοιχείο της συλλογής με νέα ταυτότητα σχήματος.

### **Κατάργηση Σχημάτων**

[Remove](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/remove/) διαγράφει ένα συγκεκριμένο αντικείμενο σχήματος από τη συλλογή του. Όταν καταργείτε πολλαπλές αντιστοιχίες κατά τη διάρκεια επαναληπτικού δείκτη, διασχίστε τη συλλογή από το τέλος ώστε κάθε εναπομείναν δείκτης να παραμείνει έγκυρος.

Αυτό το παράδειγμα καταργεί κάθε σχήμα με καθορισμένο όνομα. Διαβάζει `slide.Shapes[i]`, όχι ένα σταθερό στοιχείο συλλογής, και δεν κάνει περιττό cast του σχήματος.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

Μετά την κατάργηση, ο αριθμός σχημάτων και οι δείκτες των μεταγενέστερων σχημάτων αλλάζουν. Οι αναφορές σε μη επηρεασμένα σχήματα παραμένουν πιο αξιόπιστες από τις αποθηκευμένες τιμές δείκτη. Λάβετε επίσης υπόψη συνδέσμους, κινούμενα γραφικά και άλλες δυνατότητες παρουσίασης που μπορεί να αναφέρονται στο καταργημένο αντικείμενο· η αφαίρεση ενός ορατού σχήματος μπορεί να αλλάξει περισσότερο από την εμφάνιση της διαφάνειας.

### **Απόκρυψη Σχήματος**

Ορίζοντας το [Hidden](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/hidden/) σε `true` διατηρεί το σχήμα στη συλλογή αλλά αποτρέπει την εμφάνισή του στην κανονική παρουσίαση. Ο δείκτης, η μορφοποίηση και το περιεχόμενό του παραμένουν διαθέσιμα στον κώδικα, οπότε η απόκρυψη είναι κατάλληλη για προαιρετικά στοιχεία που μπορεί να επαναφερθούν αργότερα.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

Η απόκρυψη δεν είναι διαγραφή ούτε ασφάλεια. Το αντικείμενο μπορεί ακόμη να εντοπιστεί και να εμφανιστεί ξανά από χρήστη ή κώδικα, και παραμένει μέρος του αρχείου παρουσίασης.

### **Αλλαγή του Z‑Order**

Τα επικαλυπτόμενα σχήματα ζωγραφίζονται με τη σειρά της συλλογής. [Reorder](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/reorder/) μετακινεί ένα υπάρχον σχήμα σε έναν στόχο δείκτη χωρίς κλωνοποίηση. Ο δείκτης `0` είναι το πίσω μέρος· `Count - 1` είναι το εμπρός μέρος.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

Το ορθογώνιο δημιουργείται πρώτα και αρχικά βρίσκεται πίσω από την έλλειψη. Η μετακίνησή του στον τελικό δείκτη το βάζει εμπρός. Ολοκληρώστε το z‑order μετά την προσθήκη ή κλωνοποίηση όλων των σχετικών σχημάτων, επειδή αυτές οι λειτουργίες προσθέτουν ή εισάγουν νέα στοιχεία στη συλλογή και μπορούν να αλλάξουν τη στοίβα που προοριζόταν.

## **Επιθεώρηση Σχημάτων σε Διαφάνειες Διάταξης**

Οι κανονικές διαφάνειες, οι διαφάνειες διάταξης και οι κύριες διαφάνειες έχουν ξεχωριστές συλλογές σχημάτων. Ένα σχήμα σε συλλογή διάταξης δεν είναι το ίδιο αντικείμενο με ένα παρόμοιο σχήμα σε κανονική διαφάνεια. Επιθεωρήστε τα σχήματα διάταξης όταν χρειάζεται να κατανοήσετε ή να αλλάξετε τη μορφοποίηση που παρέχεται από μια διάταξη.

Το παρακάτω παράδειγμα διαβάζει το [FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/fillformat/) και το [LineFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/lineformat/) κάθε σχήματος διάταξης χωρίς να υποθέτει ότι κάθε σχήμα είναι ένα `AutoShape`.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

Η επεξεργασία μιας διάταξης μπορεί να επηρεάσει πολλές διαφάνειες που τη χρησιμοποιούν. Πριν αλλάξετε ένα σχήμα διάταξης, προσδιορίστε εάν μια κανονική διαφάνεια κληρονομεί το αντικείμενο ή περιέχει τοπική παράκαμψη, και δοκιμάστε κάθε διαφάνεια που χρησιμοποιεί αυτή τη διάταξη.

## **Εξαγωγή Σχήματος σε SVG**

[WriteAsSvg](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/writeassvg/) γράφει το αποδομένο περιεχόμενο ενός σχήματος σε ροή. Το αποτέλεσμα περιλαμβάνει το σχήμα, όχι το συνολικό φόντο της διαφάνειας ή τα γειτονικά σχήματα.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

Διατηρήστε την παρουσίαση ανοιχτή κατά τη διάρκεια της απόδοσης. Η έξοδος εξαρτάται από τη μορφοποίηση του σχήματος και από πόρους όπως γραμματοσειρές και εικόνες. Εάν χρειάζεστε ολόκληρη την σύνθεση, εξάγετε τη διαφάνεια αντί για μεμονωμένο σχήμα. Ο καλούντας διαχειρίζεται τη ροή και πρέπει να την απελευθερώσει.

## **Στοίχιση Σχημάτων**

Οι υπερφορτώσεις του [SlideUtil.AlignShapes](https://reference.aspose.com/slides/el/net/aspose.slides.util/slideutil/alignshapes/) στολίζουν είτε όλα τα σχήματα είτε επιλεγμένους δείκτες συλλογής. Το [ShapesAlignmentType](https://reference.aspose.com/slides/el/net/aspose.slides/shapesalignmenttype/) προσδιορίζει την άκρη, την κεντρική γραμμή ή τη λειτουργία διανομής. Ορίστε `alignToSlide` σε `true` για χρήση των άκρων της διαφάνειας· ορίστε το σε `false` για στοίχιση των επιλεγμένων σχημάτων μεταξύ τους.

Αυτό το παράδειγμα στοιχίζει τρία σχήματα στην άνω άκρη της διαφάνειας. Οι επιστρεφόμενες αναφορές σχήματος μετατρέπονται σε τρέχοντες δείκτες αμέσως πριν το στοίχιση.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

Η στοίχιση αλλάζει τις θέσεις, όχι το z‑order. Η σχετική στοίχιση συνήθως απαιτεί τουλάχιστον δύο σχήματα, ενώ η οριζόντια ή κάθετη κατανομή χρειάζεται αρκετά σχήματα για να καθορίσει το διάστημα. Υπολογίστε εκ νέου τους δείκτες εάν τροποποιήσετε τη συλλογή πριν καλέσετε τη μέθοδο.

## **Αναστροφή Σχήματος**

Η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/net/aspose.slides/shapeframe/) αποθηκεύει θέση, μέγεθος, οριζόντιες και κατακόρυφες ρυθμίσεις αναστροφής, και περιστροφή. Οι τιμές `FlipH` και `FlipV` χρησιμοποιούν το [NullableBool](https://reference.aspose.com/slides/el/net/aspose.slides/nullablebool/): `True` ενεργοποιεί την αναστροφή, `False` την απενεργοποιεί και `NotDefined` διατηρεί την ακαθόριστη/προεπιλεγμένη κατάσταση.

Η παρουσίαση εισόδου παρακάτω περιέχει ένα μη αναστραμμένο σχήμα.

![Η μορφή πριν από την αντιστροφή](shape_to_be_flipped.png)

Το παράδειγμα διατηρεί όλες τις άλλες τιμές του πλαισίου και αντικαθιστά μόνο τις δύο ρυθμίσεις αναστροφής. Αυτό είναι σημαντικό επειδή η ανάθεση ενός νέου [Frame](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/frame/) αντικαθιστά ολόκληρο το πλαίσιο.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

Το αποθηκευμένο σχήμα είναι κατοπτρισμένο οριζόντια και κάθετα διατηρώντας τη θέση, το μέγεθος και την περιστροφή του.

![Η μορφή μετά από την αντιστροφή](flipped_shape.png)

## **Συχνές Ερωτήσεις**

**Θα πρέπει να χρησιμοποιήσω ένα δείκτη συλλογής ως αναγνωριστικό σχήματος;**

Μόνο για βραχυπρόθεσμη επεξεργασία όταν η συλλογή δεν θα αλλάξει πριν από τη χρήση του δείκτη. Προτιμήστε μια επικυρωμένη σύμβαση `Name` ή `AlternativeText` για πρότυπα που έχουν δημιουργηθεί, ή `OfficeInteropShapeId` για εργασία interop περιορισμένη στη διαφάνεια.

**Αφαιρεί η απόκρυψη σχήματος το σχήμα από το z‑order;**

Όχι. Ένα κρυμμένο σχήμα παραμένει στη συλλογή στην ίδια θέση. Μπορεί να βρεθεί, να επαναδιαταχθεί, να επεξεργαστεί ή να γίνει ξανά ορατό.

**Γιατί ένα κλωνοποιημένο σχήμα εμφανίστηκε μπροστά από άλλο σχήμα;**

Το `AddClone` προσθέτει το κλώνο στο τέλος της συλλογής, που είναι το εμπρός μέρος του z‑order. Χρησιμοποιήστε `InsertClone` για να επιλέξετε τον αρχικό δείκτη ή `Reorder` μετά την προσθήκη όλων των σχημάτων.

**Μπορώ να χρησιμοποιήσω έναν σταθερό δείκτη για την ταυτοποίηση μιας προεπιλεγμένης ρύθμισης σχήματος;**

Μόνο μετά την επικύρωση της ακριβούς προεπιλογής και της διάταξης της συλλογής. Προτιμήστε την επανάληψη μέσω `IGeometryShape.Adjustments` και τον έλεγχο του `IAdjustValue.Type`; χρησιμοποιήστε το `IAdjustValue.Name` ως επιπλέον πληροφορία όταν εμφανίζεται ο ίδιος σημασιολογικός τύπος περισσότερες από μία φορές.