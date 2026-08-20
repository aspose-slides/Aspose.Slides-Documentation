---
title: Διαχείριση Σχημάτων Παρουσίασης σε .NET
linktitle: Διαχείριση Σχημάτων
type: docs
weight: 40
url: /el/net/shape-manipulations/
keywords:
- Σχήμα PowerPoint
- σχήμα παρουσίασης
- σχήμα σε διαφάνεια
- εύρεση σχήματος
- κλωνοποίηση σχήματος
- αφαίρεση σχήματος
- απόκρυψη σχήματος
- αλλαγή σειράς σχήματος
- λήψη ID σχήματος interop
- εναλλακτικό κείμενο σχήματος
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
description: "Μάθετε πώς να προσδιορίζετε, κλωνοποιείτε, αφαιρείτε, κρύβετε, αλλάζετε σειρά, εξάγετε, στοιχίζετε και αναστρέφετε σχήματα παρουσίασης με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Το Aspose.Slides για .NET αντιπροσωπεύει τα σχήματα σε μια διαφάνεια ως μια διατεταγμένη [IShapeCollection](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/). Η συλλογή είναι τόσο το μέρος όπου βρίσκετε και τροποποιείτε σχήματα όσο και η πηγή της σειράς στρώσεώς τους: το ευρετήριο `0` είναι το πιο πίσω σχήμα, ενώ το τελευταίο ευρετήριο είναι το πιο μπροστά σχήμα.

Αυτό το άρθρο ακολουθεί αυτό το μοντέλο. Πρώτα εξηγεί πώς να αναγνωρίσετε ένα σχήμα αξιόπιστα, μετά δείχνει πώς να κλωνοποιήσετε, να αφαιρέσετε, να κρύψετε και να αλλάξετε τη σειρά των σχημάτων. Τα τελικά τμήματα καλύπτουν μορφοποίηση επιπέδου διάταξης, εξαγωγή SVG, στοίχιση και ρυθμίσεις αναστροφής. Κάθε παράδειγμα είναι ανεξάρτητο, ώστε να χρησιμοποιήσετε μόνο τις λειτουργίες που απαιτούνται από τη ροή εργασίας σας.

## **Αναγνώριση και Εύρεση Σχημάτων**

Τα ευρετήρια της συλλογής είναι βολικά κατά την επεξεργασία γνωστού αρχείου, αλλά δεν είναι σταθερά αναγνωριστικά. Η προσθήκη, η αφαίρεση ή η αλλαγή σειράς ενός σχήματος μπορεί να αλλάξει το ευρετήριό του. Επιλέξτε ένα αναγνωριστικό ανάλογα με το πώς έχει δημιουργηθεί και συντηρείται η παρουσίαση:

- [Name](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/name/) είναι χρήσιμο για πρότυπα ελεγχόμενα από προγραμματιστές και είναι εύκολο να επιθεωρηθεί στο Παράθυρο Επιλογής του PowerPoint. Τα ονόματα μπορούν να επεξεργαστούν και δεν εγγυάται ότι είναι μοναδικά, γι’ αυτό καθιερώστε μια σύμβαση ονοματοδοσίας αν ο κώδικας εξαρτάται από αυτά.
- [AlternativeText](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/alternativetext/) είναι χρήσιμο όταν μια περιγραφή προσβασιμότητας ή μια ετικέτα που έχει προσθέσει ο συγγραφέας ήδη αναγνωρίζει το σχήμα. Είναι ορατό στους χρήστες, μπορεί να μεταφραστεί ή να επανεγγραφεί για προσβασιμότητα, και δεν είναι εγγυημένο ότι είναι μοναδικό. Μην επαναχρησιμοποιείτε σιωπηρά το σημαντικό κείμενο προσβασιμότητας ως κλειδί βάσης δεδομένων.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/officeinteropshapeid/) είναι ένα αναγνωριστικό μόνο για ανάγνωση που είναι μοναδικό μέσα σε μια διαφάνεια και αντιστοιχεί στο ID σχήματος που χρησιμοποιείται από το PowerPoint interop. Χρησιμοποιήστε το όταν ενσωματώνετε με το PowerPoint ή όταν χρειάζεστε μια ασαφή αναφορά κατά τη διάρκεια της ζωής ενός σχήματος. Ένα κλωνοποιημένο ή επαναδημιουργημένο σχήμα είναι διαφορετικό σχήμα και λαμβάνει το δικό του ID.

Η σχετική ιδιότητα [UniqueId](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/uniqueid/) έχει εμβέλεια παρουσίασης, αλλά προορίζεται για πρόσθετα και μπορεί να επαναχρηστοποιηθεί. Δεν πρέπει να θεωρείται μόνιμο εξωτερικό κλειδί. Αν η μακροπρόθεσμη ταυτοποίηση είναι ουσιώδης, κρατήστε την αντιστοίχιση σε δεδομένα εφαρμογής και επικυρώστε ότι το αναμενόμενο σχήμα υπάρχει ακόμη.

Το ακόλουθο παράδειγμα αναζητά με βάση το `Name` χρησιμοποιώντας συγκριτική διάκριση και αναφέρει το ID interop που ανήκει στη διαφάνεια. Όταν το πρότυπο δεν περιέχει το αναμενόμενο σχήμα, ο κώδικας αναφέρει αυτό το αποτέλεσμα αντί να συνεχίσει με το λανθασμένο αντικείμενο.

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

Όταν μια λειτουργία είναι ειδική για έναν τύπο σχήματος, ελέγξτε τη διεπαφή πριν χρησιμοποιήσετε μέλη συγκεκριμένα για τον τύπο. Αυτό το παράδειγμα ενημερώνει το κείμενο και το εναλλακτικό κείμενο μόνο εάν το ονομασμένο αντικείμενο είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/).

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

## **Τροποποίηση της Συλλογής Σχημάτων**

Οι μέθοδοι προσθήκης, κλωνοποίησης, αφαίρεσης και αλλαγής σειράς λειτουργούν αμέσως στη συλλογή. Αν μια λειτουργία αλλάζει τον αριθμό ή τη σειρά των σχημάτων, μην συνεχίσετε να βασίζεστε σε ευρετήρια που καταγράφηκαν πριν από αυτή τη λειτουργία.

### **Κλωνοποίηση Σχήματος**

[AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addclone/) δημιουργεί ανεξάρτητο αντίγραφο και το προσθέτει στο στόχο της συλλογής. [InsertClone](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/insertclone/) επίσης δημιουργεί αντίγραφο αλλά το τοποθετεί σε συγκεκριμένο δείκτη z‑order. Οι υπερφορτώσεις που δέχονται συντεταγμένες μετακινούν το κλώνο χωρίς να αλλάζουν το μέγεθός του· οι υπερφορτώσεις με πλάτος και ύψος μπορούν επίσης να το αλλάξουν.

Το παράδειγμα δημιουργεί μια διαφάνεια προορισμού, κλωνοποιεί ένα ορθογώνιο με ετικέτα προς το εμπρός μέρος και εισάγει ένα δεύτερο κλώνο στο πίσω μέρος. Οι αλλαγές σε οποιονδήποτε κλώνο δεν τροποποιούν το σχήμα προέλευσης.

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

Η κλωνοποίηση αντιγράφει το περιεχόμενο και τη μορφοποίηση του σχήματος, συμπεριλαμβανομένων του ονόματος και του εναλλακτικού κειμένου. Αναθέστε νέα λογικά αναγνωριστικά στο κλώνο όταν αυτές οι τιμές πρέπει να είναι μοναδικές. Οι πόροι που χρησιμοποιούνται από σύνθετα σχήματα διαχειρίζονται από την παρουσίαση, αλλά ένα κλώνο παραμένει νέο στοιχείο της συλλογής με νέα ταυτότητα σχήματος.

### **Απομάκρυνση Σχημάτων**

[Remove](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/remove/) διαγράφει ένα συγκεκριμένο αντικείμενο σχήματος από τη συλλογή του. Όταν αφαιρείτε πολλαπλές αντιστοιχίες κατά τη διάρκεια επανάληψης με δείκτες, διασχίστε τη συλλογή από το τέλος ώστε κάθε υπόλοιπο ευρετήριο να παραμένει έγκυρο.

Αυτό το παράδειγμα αφαιρεί κάθε σχήμα με ένα καθορισμένο όνομα. Διαβάζει `slide.Shapes[i]`, όχι ένα σταθερό στοιχείο της συλλογής, και δεν κάνει άσκοπη μετατροπή τύπου.

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

Μετά την αφαίρεση, ο αριθμός σχημάτων και τα ευρετήρια των επόμενων σχημάτων αλλάζουν. Οι αναφορές σε αμετάβλητα σχήματα παραμένουν πιο αξιόπιστες από αποθηκευμένα ευρετήρια. Επίσης, λάβετε υπόψη συνδέσμους, κινούμενα σχέδια και άλλες δυνατότητες παρουσίασης που μπορεί να αναφέρονται στο αφαιρεθέν αντικείμενο· η αφαίρεση ενός ορατού σχήματος μπορεί να αλλάξει περισσότερα από την εμφάνιση της διαφάνειας.

### **Απόκρυψη Σχήματος**

Η ρύθμιση του [Hidden](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/hidden/) σε `true` διατηρεί το σχήμα στη συλλογή αλλά αποτρέπει την εμφάνισή του στην κανονική προβολή διαφάνειας. Το ευρετήριό του, η μορφοποίηση και το περιεχόμενό του παραμένουν διαθέσιμα στον κώδικα, επομένως η απόκρυψη είναι κατάλληλη για προαιρετικά στοιχεία που μπορεί να επαναφερθούν αργότερα.

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

Η απόκρυψη δεν είναι διαγραφή ή ασφάλεια. Το αντικείμενο μπορεί ακόμη να εντοπιστεί και να εμφανιστεί ξανά από χρήστη ή κώδικα, και παραμένει μέρος του αρχείου παρουσίασης.

### **Αλλαγή της Σειράς Z**

Τα επικαλυπτόμενα σχήματα ζωγραφίζονται με τη σειρά της συλλογής. [Reorder](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/reorder/) μετακινεί ένα υπάρχον σχήμα σε έναν στόχο ευρετήριο χωρίς κλωνοποίηση. Το ευρετήριο `0` είναι το πίσω μέρος· `Count - 1` είναι το μπροστινό μέρος.

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

Το ορθογώνιο δημιουργείται πρώτα και αρχικά βρίσκεται πίσω από την έλλειψη. Η μετακίνηση του στο τελικό ευρετήριο το φέρνει μπροστά. Ολοκληρώστε τη σειρά z μετά την προσθήκη ή κλωνοποίηση όλων των σχετικών σχημάτων, επειδή αυτές οι λειτουργίες προσθέτουν ή εισάγουν νέα στοιχεία στη συλλογή και μπορούν να αλλάξουν τη στοίβα.

## **Επιθεώρηση Σχημάτων σε Διαφάνειες Διάταξης**

Οι κανονικές διαφάνειες, οι διαφάνειες διάταξης και οι κύριες διαφάνειες έχουν ξεχωριστές συλλογές σχημάτων. Ένα σχήμα σε μια συλλογή διάταξης δεν είναι το ίδιο αντικείμενο με ένα σχήμα παρόμοιας θέσης σε κανονική διαφάνεια. Επιθεωρήστε τα σχήματα διάταξης όταν πρέπει να καταλάβετε ή να αλλάξετε τη μορφοποίηση που παρέχεται από μια διάταξη.

Το παρακάτω παράδειγμα διαβάζει το [FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/fillformat/) και το [LineFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/lineformat/) κάθε σχήματος διάταξης χωρίς να υποθέτει ότι κάθε σχήμα είναι `AutoShape`.

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

Η επεξεργασία μιας διάταξης μπορεί να επηρεάσει πολλαπλές διαφάνειες που τη χρησιμοποιούν. Πριν αλλάξετε ένα σχήμα διάταξης, προσδιορίστε αν μια κανονική διαφάνεια κληρονομεί το αντικείμενο ή περιέχει τοπική παράκαμψη, και δοκιμάστε κάθε διαφάνεια που χρησιμοποιεί εκείνη τη διάταξη.

## **Εξαγωγή Σχήματος σε SVG**

[WriteAsSvg](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/writeassvg/) γράφει το απόδοση ενός σχήματος σε μια ροή. Το αποτέλεσμα περιέχει μόνο το σχήμα, όχι το φόντο ολόκληρης της διαφάνειας ή τα γειτονικά σχήματα.

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

Διατηρήστε την παρουσίαση ανοιχτή κατά τη διάρκεια της απόδοσης. Η έξοδος εξαρτάται από τη μορφοποίηση του σχήματος και από πόρους όπως γραμματοσειρές και εικόνες. Αν χρειάζεστε ολόκληρη τη σύνθεση, εξάγετε τη διαφάνεια αντί για μόνο το σχήμα. Ο καλούντας κατέχει τη ροή και πρέπει να την αποδεσμεύσει.

## **Στοίχιση Σχημάτων**

Οι υπερφορτώσεις του [SlideUtil.AlignShapes](https://reference.aspose.com/slides/el/net/aspose.slides.util/slideutil/alignshapes/) στοιχίζουν είτε όλα τα σχήματα είτε επιλεγμένα ευρετήρια της συλλογής. Το [ShapesAlignmentType](https://reference.aspose.com/slides/el/net/aspose.slides/shapesalignmenttype/) καθορίζει την άκρη, το κέντρο ή τη λειτουργία διανομής. Ορίστε `alignToSlide` σε `true` για χρήση των άκρων της διαφάνειας· θέστε το σε `false` για στοίχιση των επιλεγμένων σχημάτων μεταξύ τους.

Αυτό το παράδειγμα στοιχίζει τρία σχήματα στην άνω άκρη της διαφάνειας. Οι αναφορές στα σχήματα που επιστρέφονται μετατρέπονται αμέσως στα τρέχοντα ευρετήρια τους πριν τη στοίχιση.

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

Η στοίχιση αλλάζει τις θέσεις, όχι τη σειρά z. Η σχετική στοίχιση συνήθως απαιτεί τουλάχιστον δύο σχήματα, ενώ η οριζόντια ή κατακόρυφη κατανομή χρειάζεται αρκετά σχήματα για να ορίσει την απόσταση. Υπολογίστε ξανά τα ευρετήρια αν τροποποιήσετε τη συλλογή πριν καλέσετε τη μέθοδο.

## **Αναστροφή Σχήματος**

Η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/net/aspose.slides/shapeframe/) αποθηκεύει θέση, μέγεθος, οριζόντιες και κάθετες ρυθμίσεις αναστροφής, και περιστροφή. Οι τιμές `FlipH` και `FlipV` χρησιμοποιούν το [NullableBool](https://reference.aspose.com/slides/el/net/aspose.slides/nullablebool/): `True` ενεργοποιεί την αναστροφή, `False` την απενεργοποιεί, και `NotDefined` διατηρεί την ακαθόριστη/προεπιλεγμένη κατάσταση.

Η παρακάτω παρουσίαση περιέχει ένα σχήμα χωρίς αναστροφή.

![Το σχήμα πριν την αναστροφή](shape_to_be_flipped.png)

Το παράδειγμα διατηρεί κάθε άλλη τιμή του πλαισίου και αντικαθιστά μόνο τις δύο ρυθμίσεις αναστροφής. Αυτό είναι σημαντικό επειδή η ανάθεση ενός νέου [Frame](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/frame/) αντικαθιστά ολόκληρο το πλαίσιο.

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

Το αποθηκευμένο σχήμα αντανακλάται οριζόντια και κατακόρυφα ενώ διατηρεί τη θέση, το μέγεθος και την περιστροφή του.

![Το σχήμα μετά την αναστροφή](flipped_shape.png)

## **Συχνές Ερωτήσεις**

**Should I use a collection index as a shape identifier?**  
Μόνο για βραχυπρόθεσμη επεξεργασία όταν η συλλογή δεν θα αλλάξει πριν χρησιμοποιηθεί το ευρετήριο. Προτιμήστε ένα επικυρωμένο `Name` ή σύμβαση `AlternativeText` για πρότυπα που έχουν δημιουργηθεί, ή `OfficeInteropShapeId` για εργασίες interop περιορισμένες στη διαφάνεια.

**Does hiding a shape remove it from the z-order?**  
Όχι. Ένα κρυμμένο σχήμα παραμένει στη συλλογή με το ίδιο ευρετήριο. Μπορεί να βρεθεί, να επανατοποθετηθεί, να επεξεργαστεί ή να γίνει ξανά ορατό.

**Why did a cloned shape appear in front of another shape?**  
Το `AddClone` προσθέτει το κλώνο στο τέλος της συλλογής, που είναι το μπροστινό μέρος της σειράς z. Χρησιμοποιήστε `InsertClone` για να επιλέξετε το αρχικό ευρετήριο ή `Reorder` μετά την προσθήκη όλων των σχημάτων.