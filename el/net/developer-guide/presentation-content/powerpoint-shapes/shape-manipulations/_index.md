---
title: Διαχείριση Σχημάτων Παρουσίασης σε .NET
linktitle: Διαχείριση Σχημάτων
type: docs
weight: 40
url: /el/net/shape-manipulations/
keywords:
- σχήμα PowerPoint
- σχήμα παρουσίασης
- σχήμα σε διαφάνεια
- εύρεση σχήματος
- κλωνοποίηση σχήματος
- αφαίρεση σχήματος
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
- αντιστροφή σχήματος
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να εντοπίζετε, προσαρμόζετε, κλωνοποιείτε, αφαιρείτε, αποκρύπτετε, επαναδιατάσσετε, εξάγετε, στοιχίζετε και αναστρέφετε σχήματα παρουσίασης με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Το Aspose.Slides for .NET αντιπροσωπεύει τα σχήματα σε μια διαφάνεια ως μια διατεταγμένη [IShapeCollection](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/). Η συλλογή είναι τόσο το σημείο όπου βρίσκετε και τροποποιείτε σχήματα όσο και η πηγή της σειράς στοιβάγματος τους: το δείκτη `0` είναι το πιο πίσω σχήμα, ενώ ο τελευταίος δείκτης είναι το πιο μπροστά σχήμα.

Αυτό το άρθρο ακολουθεί αυτό το μοντέλο. Πρώτα εξηγεί πώς να εντοπίζετε ένα σχήμα αξιόπιστα και να τροποποιείτε προκαθορισμένα σημεία προσαρμογής σχήματος, έπειτα δείχνει πώς να κλωνοποιείτε, να αφαιρείτε, να κρύβετε και να επαναδιατάσσετε σχήματα. Τα τελικά τμήματα καλύπτουν μορφοποίηση επιπέδου διάταξης, εξαγωγή σε SVG, στοίχιση και ρυθμίσεις ανάστροφης προβολής. Κάθε παράδειγμα είναι ανεξάρτητο, ώστε να μπορείτε να χρησιμοποιήσετε μόνο τις λειτουργίες που απαιτούνται από τη ροή εργασίας σας.

## **Εντοπισμός και Εύρεση Σχημάτων**

Οι δείκτες συλλογής είναι βολικοί ενώ επεξεργάζεστε ένα γνωστό αρχείο, αλλά δεν είναι σταθερά αναγνωριστικά. Η προσθήκη, η αφαίρεση ή η επαναδιάταξη ενός σχήματος μπορεί να αλλάξει το δείκτη του. Επιλέξτε ένα αναγνωριστικό ανάλογα με τον τρόπο που δημιουργείται και συντηρείται η παρουσίαση:

- [Name](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/name/) είναι χρήσιμο για πρότυπα ελεγχόμενα από προγραμματιστές και είναι εύκολο να το ελέγξετε στο Πάνελ Επιλογής του PowerPoint. Τα ονόματα μπορούν να επεξεργαστούν και δεν είναι εγγυημένα μοναδικά, έτσι καθιερώστε ένα σύστημα ονοματοδοσίας αν ο κώδικας εξαρτάται από αυτά.
- [AlternativeText](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/alternativetext/) είναι χρήσιμο όταν μια περιγραφή προσβασιμότητας ή μια ετικέτα από το συγγραφέα έχει ήδη ταυτοποιήσει το σχήμα. Είναι ορατό στους χρήστες, μπορεί να μεταφραστεί ή να ξαναγραφτεί για προσβασιμότητα, και δεν είναι εγγυημένα μοναδικό. Μην επαναχρησιμοποιείτε σιωπηλά το σημαντικό κείμενο προσβασιμότητας ως κλειδί βάσης δεδομένων.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/officeinteropshapeid/) είναι ένα μόνο‑ανά‐ανάγνωση αναγνωριστικό που είναι μοναδικό μέσα σε μια διαφάνεια και αντιστοιχεί στο ID σχήματος που χρησιμοποιείται από το PowerPoint interop. Χρησιμοποιήστε το όταν ενσωματώνετε με το PowerPoint ή όταν χρειάζεστε μια σαφή αναφορά κατά τη διάρκεια ζωής ενός σχήματος. Ένα κλωνοποιημένο ή επαναδημιουργηθέν σχήμα είναι διαφορετικό σχήμα και λαμβάνει το δικό του ID.

Η σχετική ιδιότητα [UniqueId](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/uniqueid/) έχει πεδίο παρουσίασης, αλλά προορίζεται για πρόσθετα και μπορεί να επαναανατεθεί. Δεν πρέπει να θεωρείται μόνιμο εξωτερικό κλειδί. Αν η μακροπρόθεσμη ταυτοποίηση είναι απαραίτητη, κρατήστε την αντιστοίχιση στα δεδομένα της εφαρμογής και επικυρώστε ότι το αναμενόμενο σχήμα εξακολουθεί να υπάρχει.

Για ένα πρακτικό παράδειγμα ανάγνωσης και ενημέρωσης τόσο του τίτλου εναλλακτικού κειμένου όσο και της περιγραφής, δείτε το [Manage Alternative Text Titles and Descriptions](/slides/el/net/presentation-accessibility/). Χρησιμοποιήστε εναλλακτικό κείμενο για να εξηγήσετε το νόημα του οπτικού στοιχείου στους αναγνώστες, και κρατήστε το ξεχωριστό από τα ονόματα σχήματος που χρησιμοποιούνται από τον κώδικα για την εύρεση σχημάτων.

Το παρακάτω παράδειγμα αναζητά με βάση το `Name` με οδεσμική σύγκριση και αναφέρει το ID interop με πεδίο διαφάνειας. Όταν το πρότυπο δεν περιέχει το αναμενόμενο σχήμα, ο κώδικας αναφέρει αυτό το αποτέλεσμα αντί να συνεχίσει με το λάθος αντικείμενο.

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

Όταν μια λειτουργία είναι ειδική για τύπο σχήματος, ελέγξτε τη διεπαφή πριν χρησιμοποιήσετε μέλη ειδικά για τον τύπο. Αυτό το παράδειγμα ενημερώνει κείμενο και εναλλακτικό κείμενο μόνο εάν το ονομασμένο αντικείμενο είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/).

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

## **Εντοπισμός και Τροποποίηση Προκαθορισμένων Προσαρμογών Σχήματος**

Τα σχήματα γεωμετρίας προεπιλογής μπορούν να εκθέτουν σημεία προσαρμογής που ελέγχουν λειτουργίες όπως το μέγεθος γωνίας, τις αναλογίες βέλους ή τις γωνίες τόξου. Πρόσβαση σε αυτά γίνεται μέσω της μόνο‑ανά‑ανάγνωση συλλογής [IGeometryShape.Adjustments](https://reference.aspose.com/slides/el/net/aspose.slides/igeometryshape/adjustments/). Η συλλογή παρέχεται από το σχήμα, αλλά κάθε [IAdjustValue](https://reference.aspose.com/slides/el/net/aspose.slides/iadjustvalue/) περιέχει μια τιμή που μπορεί να αλλάξει.

Μην βασίζεστε μόνο σε έναν σταθερό δείκτη συλλογής. Επανάληψη στις προσαρμογές και εξέταση της μόνο‑ανά‑ανάγνωση ιδιότητας [Type](https://reference.aspose.com/slides/el/net/aspose.slides/adjustvalue/type/), της οποίας η τιμή [ShapeAdjustmentType](https://reference.aspose.com/slides/el/net/aspose.slides/shapeadjustmenttype/) περιγράφει τι ελέγχει η προσαρμογή. Η μόνο‑ανά‑ανάγνωση ιδιότητα [Name](https://reference.aspose.com/slides/el/net/aspose.slides/adjustvalue/name/) παρέχει πρόσθετες πληροφορίες ταυτοποίησης και είναι ιδιαίτερα χρήσιμη όταν ένα προεπιλεγμένο σχήμα περιέχει περισσότερες από μία προσαρμογές με τον ίδιο σημασιακό τύπο.

Χρησιμοποιήστε την ιδιότητα τιμής που ταιριάζει με το νόημα της προσαρμογής:

| Τύπος προσαρμογής | Σκοπός | Τιμή προς αλλαγή |
|---|---|---|
| `CornerSize` | Μέγεθος στρογγυλεμένων γωνιών | [RawValue](https://reference.aspose.com/slides/el/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Πάχος ουράς βέλους | `RawValue` |
| `ArrowheadLength` | Μήκος κεφαλής βέλους | `RawValue` |
| `ArrowheadWidth` | Πλάτος κεφαλής βέλους | `RawValue` |
| `StartAngle` | Αρχική γωνία πίτας ή τόξου | [AngleValue](https://reference.aspose.com/slides/el/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Τελική γωνία πίτας ή τόξου | `AngleValue` |

`Type` και `Name` δεν μπορούν να εκχωρηθούν. `RawValue` είναι ένας αναγνώσιμος/εγγράψιμος ακέραιος στις εγγενείς μονάδες γεωμετρίας του προεπιλεγμένου σχήματος, ενώ `AngleValue` είναι μια αναγνώσιμη/εγγράψιμη γωνία σε μοίρες. Ο αριθμός, η σειρά, το νόημα και το έγκυρο εύρος των προσαρμογών εξαρτώνται από το προεπιλεγμένο [ShapeType](https://reference.aspose.com/slides/el/net/aspose.slides/igeometryshape/shapetype/). Μια τιμή που είναι έγκυρη για ένα προεπιλεγμένο σχήμα μπορεί να είναι άκυρη ή να έχει διαφορετική επίδραση για κάποιο άλλο.

Όταν `Type` είναι `ShapeAdjustmentType.Custom`, το API δεν αναγνωρίζει τυπικό σημασιολογικό νόημα. Εξετάστε το `Name`, τον τύπο προεπιλογής και την υπάρχουσα τιμή, και αφήστε την προσαρμογή αμετάβλητη εκτός εάν το αναμενόμενο νόημα και το εύρος είναι γνωστά. Ακόμη και για αναγνωρισμένους τύπους, ελέγξτε αν ο ίδιος τύπος εμφανίζεται περισσότερες από μία φορές πριν επιλέξετε τιμή. Το άρθρο [Connector](/slides/el/net/connector/) παρουσιάζει αυτή την κατάσταση με προσαρμογές κάμψης συνδετήρων.

Το παρακάτω πλήρες παράδειγμα δημιουργεί προεπιλεγμένες και τροποποιημένες εκδόσεις τριών προεπιλεγμένων σχημάτων. Επανάληψη σε κάθε προσαρμογή, αναφορά του `Name` και του `Type`, αλλαγή τιμών σχετικών με το μέγεθος μέσω `RawValue`, αλλαγή γωνιών μέσω `AngleValue`, και αποθήκευση του αποτελέσματος. Η αριστερή στήλη διατηρεί την προεπιλεγμένη γεωμετρία· η δεξιά στήλη εμφανίζει το προσαρμοσμένο στρογγυλεμένο ορθογώνιο, το τετραπλό βέλος και την πίτα.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Προσθέτει επικεφαλίδες για τις στήλες προεπιλεγμένου και προσαρμοσμένου σχήματος.
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

Ο έλεγχος του σημασιολογικού τύπου πριν από την αλλαγή τιμής κάνει τον κώδικα σαφή ως προς την πρόθεσή του και αποτρέπει την υπόθεση ότι ένας συγκεκριμένος δείκτης συλλογής έχει το ίδιο νόημα σε διαφορετικά προεπιλεγμένα σχήματα.

## **Τροποποίηση της Συλλογής Σχημάτων**

Οι μέθοδοι προσθήκης, κλωνοποίησης, αφαίρεσης και επαναδιαταγής λειτουργούν αμέσως στη συλλογή. Εάν μια λειτουργία αλλάζει τον αριθμό ή τη σειρά των σχημάτων, μην συνεχίζετε να βασίζεστε σε δείκτες που καταγράφηκαν πριν από αυτήν τη λειτουργία.

### **Κλωνοποίηση Σχήματος**

[AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addclone/) δημιουργεί ένα ανεξάρτητο αντίγραφο και το προσθέτει στο στόχο συλλογής. [InsertClone](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/insertclone/) επίσης δημιουργεί αντίγραφο αλλά το τοποθετεί σε έναν καθορισμένο δείκτη z‑order. Οι υπερφορτώσεις που δέχονται συντεταγμένες μετακινούν το κλώνο χωρίς αλλαγή μεγέθους· οι υπερφορτώσεις με πλάτος και ύψος μπορούν επίσης να αλλάξουν το μέγεθός του.

Το παράδειγμα δημιουργεί μια διαφάνεια προορισμού, κλωνοποιεί ένα επισημασμένο ορθογώνιο στο εμπρός μέρος και εισάγει ένα δεύτερο κλώνο στο πίσω μέρος. Οι αλλαγές σε οποιονδήποτε κλώνο δεν τροποποιούν το σχήμα προέλευσης.

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

Η κλωνοποίηση αντιγράφει το περιεχόμενο και τη μορφοποίηση του σχήματος, συμπεριλαμβανομένου του ονόματος και του εναλλακτικού κειμένου. Εκχωρήστε νέες λογικές ταυτοποιήσεις στον κλώνο όταν αυτές οι τιμές πρέπει να είναι μοναδικές. Οι πόροι που χρησιμοποιούν σύνθετα σχήματα διαχειρίζονται από την παρουσίαση, αλλά ένας κλώνος παραμένει νέο στοιχείο της συλλογής με νέα ταυτότητα σχήματος.

### **Αφαίρεση Σχημάτων**

[Remove](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/remove/) διαγράφει ένα συγκεκριμένο αντικείμενο σχήματος από τη συλλογή του. Κατά την αφαίρεση πολλαπλών αντιστοιχίσεων κατά την επανάληψη με δείκτες, προχωρήστε από το τέλος ώστε κάθε υπόλοιπος δείκτης να παραμένει έγκυρος.

Αυτό το παράδειγμα αφαιρεί κάθε σχήμα με καθορισμένο όνομα. Διαβάζει `slide.Shapes[i]`, όχι ένα σταθερό στοιχείο συλλογής, και δεν κάνει αχρείαστη μετατροπή τύπου του σχήματος.

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

Μετά την αφαίρεση, ο αριθμός σχημάτων και οι δείκτες των μεταγενέστερων σχημάτων αλλάζουν. Αναφορές σε αμετάβλητα σχήματα παραμένουν πιο αξιόπιστες από αποθηκευμένους δείκτες. Επίσης λάβετε υπόψη συνδέσμους, κινούμενα γραφικά και άλλα χαρακτηριστικά που μπορεί να αναφέρονται στο αφαιρεθέν αντικείμενο· η αφαίρεση ενός ορατού σχήματος μπορεί να αλλάξει περισσότερο από την εμφάνιση της διαφάνειας.

### **Απόκρυψη Σχήματος**

Ορίζοντας το [Hidden](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/hidden/) σε `true` διατηρεί το σχήμα στη συλλογή αλλά αποτρέπει την εμφάνισή του στην κανονική παρουσίαση. Ο δείκτης, η μορφοποίηση και το περιεχόμενο παραμένουν διαθέσιμα στον κώδικα, επομένως η απόκρυψη είναι κατάλληλη για προαιρετικά στοιχεία που μπορεί να επαναφερθούν αργότερα.

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

Η απόκρυψη δεν είναι διαγραφή ή ασφάλεια. Το αντικείμενο μπορεί ακόμη να εντοπισθεί και να εμφανιστεί ξανά από χρήστη ή κώδικα, και παραμένει μέρος του αρχείου παρουσίασης.

### **Αλλαγή του Z‑Order**

Τα επικαλυπτόμενα σχήματα ζωγραφίζονται με σειρά της συλλογής. [Reorder](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/reorder/) μετακινεί ένα υπάρχον σχήμα σε έναν στόχο δείκτη χωρίς κλωνοποίηση. Ο δείκτης `0` είναι το πίσω μέρος· `Count - 1` είναι το μπροστά μέρος.

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

Το ορθογώνιο δημιουργείται πρώτα και αρχικά βρίσκεται πίσω από την έλλειψη. Η μετακίνησή του στο τελικό δείκτη το τοποθετεί μπροστά. Ολοκληρώστε το z‑order μετά την προσθήκη ή κλωνοποίηση όλων των σχετικών σχημάτων, επειδή αυτές οι λειτουργίες προσθέτουν ή εισάγουν νέα στοιχεία στη συλλογή και μπορούν να αλλάξουν τη στοίβα.

## **Επιθεώρηση Σχημάτων σε Διαφάνειες Διάταξης**

Κανονικές διαφάνειες, διαφάνειες διάταξης και διαφάνειες προτύπου έχουν ξεχωριστές συλλογές σχημάτων. Ένα σχήμα σε συλλογή διάταξης δεν είναι το ίδιο αντικείμενο με ένα παρόμοιο σχήμα σε κανονική διαφάνεια. Επιθεωρήστε τα σχήματα διάταξης όταν χρειάζεται να κατανοήσετε ή να αλλάξετε τη μορφοποίηση που παρέχεται από μια διάταξη.

Το ακόλουθο παράδειγμα διαβάζει το [FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/fillformat/) και το [LineFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/lineformat/) κάθε σχήματος διάταξης χωρίς να υποθέτει ότι κάθε σχήμα είναι ένα `AutoShape`.

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

Η επεξεργασία μιας διάταξης μπορεί να επηρεάσει πολλές διαφάνειες που τη χρησιμοποιούν. Πριν αλλάξετε ένα σχήμα διάταξης, καθορίστε εάν μια κανονική διαφάνεια κληρονομεί το αντικείμενο ή περιέχει τοπική υπερβλήση, και δοκιμάστε κάθε διαφάνεια που χρησιμοποιεί αυτή τη διάταξη.

## **Εξαγωγή Σχήματος σε SVG**

[WriteAsSvg](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/writeassvg/) γράφει το αποδιδόμενο περιεχόμενο ενός σχήματος σε ένα ρεύμα. Το αποτέλεσμα περιλαμβάνει το σχήμα, όχι ολόκληρο το φόντο της διαφάνειας ή τα γειτονικά σχήματα.

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

Διατηρήστε την παρουσίαση ανοιχτή κατά τη διάρκεια της απόδοσης. Η έξοδος εξαρτάται από τη μορφοποίηση του σχήματος και από πόρους όπως γραμματοσειρές και εικόνες. Εάν χρειάζεστε ολόκληρη τη σύνθεση, εξάγετε τη διαφάνεια αντί για μεμονωμένο σχήμα. Ο καλών την ροή ελέγχει το ρεύμα και πρέπει να το αποδεσμεύσει.

## **Στοίχιση Σχημάτων**

Οι υπερφορτώσεις του [SlideUtil.AlignShapes](https://reference.aspose.com/slides/el/net/aspose.slides.util/slideutil/alignshapes/) ευθυγραμμίζουν είτε όλα τα σχήματα είτε επιλεγμένους δείκτες συλλογής. Το [ShapesAlignmentType](https://reference.aspose.com/slides/el/net/aspose.slides/shapesalignmenttype/) ορίζει την άκρη, τη κεντρική γραμμή ή τη λειτουργία κατανομής. Ορίστε `alignToSlide` σε `true` για χρήση των άκρων της διαφάνειας· ορίστε το σε `false` για στοίχιση των επιλεγμένων σχημάτων μεταξύ τους.

Αυτό το παράδειγμα ευθυγραμμίζει τρία σχήματα στην πάνω άκρη της διαφάνειας. Οι αναφορές σχήματος που επιστρέφονται μετατρέπονται αμέσως στους τρέχοντες δείκτες τους πριν την ευθυγράμμιση.

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

Η στοίχιση αλλάζει θέσεις, όχι το z‑order. Η σχετική στοίχιση συνήθως χρειάζεται τουλάχιστον δύο σχήματα, ενώ η οριζόντια ή κατακόρυφη κατανομή χρειάζεται αρκετά σχήματα ώστε να ορίσει την απόσταση. Επαναϋπολογίστε τους δείκτες εάν τροποποιήσετε τη συλλογή πριν καλέσετε τη μέθοδο.

## **Αναστροφή Σχήματος**

Η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/net/aspose.slides/shapeframe/) αποθηκεύει θέση, μέγεθος, ρυθμίσεις οριζόντιας και κάθετης ανάστροφης, και στροφή. Οι τιμές `FlipH` και `FlipV` χρησιμοποιούν [NullableBool](https://reference.aspose.com/slides/el/net/aspose.slides/nullablebool/): `True` ενεργοποιεί την ανάστροφη, `False` την απενεργοποιεί, και `NotDefined` διατηρεί την ακαθόριστη/προεπιλεγμένη κατάσταση.

Η παρακάτω παρουσίαση περιέχει ένα σχήμα χωρίς ανάστροφη.

![The shape before flipping](shape_to_be_flipped.png)

Το παράδειγμα διατηρεί κάθε άλλη τιμή του frame και αντικαθιστά μόνο τις δύο ρυθμίσεις ανάστροφης. Αυτό είναι σημαντικό επειδή η εκχώρηση ενός νέου [Frame](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/frame/) αντικαθιστά ολόκληρο το frame.

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

Το αποθηκευμένο σχήμα είναι κατοπτρισμένο οριζόντια και κάθετα, διατηρώντας τη θέση, το μέγεθος και τη στροφή του.

![The shape after flipping](flipped_shape.png)

## **Συχνές Ερωτήσεις**

**Πρέπει να χρησιμοποιήσω δείκτη συλλογής ως αναγνωριστικό σχήματος;**

Μόνο για βραχύβια επεξεργασία όταν η συλλογή δεν θα αλλάξει πριν χρησιμοποιηθεί ο δείκτης. Προτιμήστε ένα επικυρωμένο `Name` ή μια σύμβαση `AlternativeText` για πρότυπα που δημιουργήθηκαν, ή `OfficeInteropShapeId` για εργασίες interop με διαφάνειες.

**Η απόκρυψη σχήματος το αφαιρεί από το z‑order;**

Όχι. Ένα κρυφό σχήμα παραμένει στη συλλογή με τον ίδιο δείκτη. Μπορεί να βρεθεί, να επαναδιαταχθεί, να επεξεργασθεί ή να γίνει ξανά ορατό.

**Γιατί ένα κλωνοποιημένο σχήμα εμφανίζεται μπροστά από άλλο σχήμα;**

Το `AddClone` προσθέτει το κλώνο στο τέλος της συλλογής, που είναι το μπροστινό μέρος του z‑order. Χρησιμοποιήστε `InsertClone` για να επιλέξετε τον αρχικό δείκτη ή `Reorder` μετά την προσθήκη όλων των σχημάτων.

**Μπορώ να χρησιμοποιήσω σταθερό δείκτη για την ταυτοποίηση μιας προεπιλεγμένης προσαρμογής σχήματος;**

Μόνο μετά την επικύρωση του ακριβούς προεπιλεγμένου σχήματος και της διάταξης της συλλογής. Προτιμήστε την επανάληψη μέσω `IGeometryShape.Adjustments` και τον έλεγχο του `IAdjustValue.Type`; χρησιμοποιήστε το `IAdjustValue.Name` ως πρόσθετη πληροφορία όταν εμφανίζεται ο ίδιος σημασιολογικός τύπος πιο από μία φορά.