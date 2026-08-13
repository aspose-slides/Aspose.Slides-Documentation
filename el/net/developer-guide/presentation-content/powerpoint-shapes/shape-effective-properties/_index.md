---
title: Λήψη αποτελεσματικών ιδιοτήτων σχήματος από παρουσιάσεις στο .NET
linktitle: Αποτελεσματικές ιδιότητες
type: docs
weight: 50
url: /el/net/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- εξοπλισμός φωτισμού
- σχήμα λοξότμησης
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφή γεμίσματος
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανακαλύψτε πώς το Aspose.Slides για .NET υπολογίζει και εφαρμόζει τις αποτελεσματικές ιδιότητες σχήματος για ακριβή απόδοση PowerPoint."
---
## **Επισκόπηση**

Αυτό το θέμα εξηγεί τη διαφορά μεταξύ **τοπικές** και **αποτελεσματικές** ιδιότητες. Οι τοπικές τιμές είναι τιμές που ορίζονται άμεσα σε ένα συγκεκριμένο επίπεδο μορφοποίησης, όπως:

1. Ιδιότητες τμήματος σε μια διαφάνεια.
1. Τεχνοτροπίες κειμένου προτύπου σχήματος σε διάταξη ή κύρια διαφάνεια, όταν το σχήμα πλαισίου κειμένου του τμήματος διαθέτει μία.
1. Καθολικές ρυθμίσεις κειμένου σε μια παρουσίαση.

Οι τοπικές τιμές μπορούν να οριστούν ή να παραλειφθούν σε οποιοδήποτε επίπεδο. Όταν το Aspose.Slides χρειάζεται την τελική μορφοποίηση «όπως αποδίδεται», επιλύει την αλυσίδα κληρονομικότητας και επιστρέφει **αποτελεσματικές** τιμές. Μπορείτε να τις λάβετε καλώντας τη μέθοδο `GetEffective` στο αντικείμενο τοπικής μορφής.

Το παρακάτω παράδειγμα δείχνει πώς να λάβετε αποτελεσματικές τιμές. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) με πλαίσιο κειμένου και τουλάχιστον ένα τμήμα.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
Τα δεδομένα αποτελεσματικής μορφοποίησης αντιπροσωπεύουν τη τρέχουσα υπολογισμένη μορφοποίηση μετά την εφαρμογή της κληρονομικότητας. Στην τρέχουσα υλοποίηση, ορισμένα αντικείμενα δεδομένων αποτελεσματικότητας, όπως [IPortionFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/iportionformateffectivedata/), μπορεί να έχουν αποθηκευτεί στην μνήμη. Η επανάκληση του `GetEffective` μετά από αλλαγή της γονικής ή κληρονομημένης μορφοποίησης μπορεί να ανανεώσει τα αποθηκευμένα δεδομένα, και ένα αντικείμενο που είχε ληφθεί προηγουμένως μπορεί να μην αντιπροσωπεύει πλέον την προηγούμενη κατάσταση. Εάν χρειάζεται να διατηρήσετε τις αποτελεσματικές τιμές για μελλοντική χρήση, αντιγράψτε τις απαιτούμενες ιδιότητες, όπως το ύψος γραμματοσειράς, το χρώμα γεμίσματος, το στυλ γραμματοσειράς ή την στοίχιση, στο δικό σας αντικείμενο δεδομένων.
{{% /alert %}}

## **Λήψη αποτελεσματικών ιδιοτήτων κάμερας**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες μιας κάμερας. Η διεπαφή [ICameraEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/icameraeffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει τις αποτελεσματικές ιδιότητες της κάμερας. Μια παρουσίαση του [ICameraEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/icameraeffectivedata/) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformateffectivedata/), το οποίο παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για την κάμερα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια διαθέτει 3D μορφοποίηση.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Λήψη αποτελεσματικών ιδιοτήτων Light Rig**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες ενός Light Rig. Η διεπαφή [ILightRigEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ilightrigeffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει τις αποτελεσματικές ιδιότητες του Light Rig. Μια παρουσίαση του [ILightRigEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ilightrigeffectivedata/) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformateffectivedata/), το οποίο παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για το Light Rig. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια διαθέτει 3D μορφοποίηση.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Λήψη αποτελεσματικών ιδιοτήτων Bevel Shape**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες μιας Bevel Shape. Η διεπαφή [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ishapebeveleffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει αποτελεσματικές ιδιότητες ανάπλασης για ένα σχήμα. Μια παρουσίαση του [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ishapebeveleffectivedata/) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformateffectivedata/), το οποίο παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για την κορυφαία λοξή άκρη (top bevel) ενός σχήματος. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια διαθέτει 3D μορφοποίηση.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Λήψη αποτελεσματικών ιδιοτήτων πλαισίου κειμένου**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε τις αποτελεσματικές ιδιότητες ενός πλαισίου κειμένου. Η διεπαφή [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformateffectivedata/) περιέχει αποτελεσματικές ιδιότητες μορφοποίησης πλαισίου κειμένου.

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες μορφοποίησης πλαισίου κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) με πλαίσιο κειμένου.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Λήψη αποτελεσματικών ιδιοτήτων στυλ κειμένου**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε τις αποτελεσματικές ιδιότητες ενός στυλ κειμένου. Η διεπαφή [ITextStyleEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/itextstyleeffectivedata/) περιέχει αποτελεσματικές ιδιότητες στυλ κειμένου.

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες στυλ κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) με πλαίσιο κειμένου.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **Λήψη της αποτελεσματικής τιμής ύψους γραμματοσειράς**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε το αποτελεσματικό ύψος γραμματοσειράς. Ο παρακάτω κώδικας δείχνει πώς το αποτελεσματικό ύψος γραμματοσειράς ενός τμήματος αλλάζει μετά τον ορισμό τοπικών τιμών ύψους γραμματοσειράς σε διαφορετικά επίπεδα δομής παρουσίασης.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **Λήψη της αποτελεσματικής μορφοποίησης γεμίσματος για πίνακα**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε την αποτελεσματική μορφοποίηση γεμίσματος για διαφορετικά τμήματα πίνακα. Η διεπαφή [IFillFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ifillformateffectivedata/) περιέχει αποτελεσματικές ιδιότητες μορφοποίησης γεμίσματος. Η μορφοποίηση κελιού έχει προτεραιότητα έναντι της μορφοποίησης γραμμής, η μορφοποίηση γραμμής έναντι της μορφοποίησης στήλης, και η μορφοποίηση στήλης έναντι της μορφοποίησης ολόκληρου του πίνακα.

Ως αποτέλεσμα, οι ιδιότητες [ICellFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/icellformateffectivedata/) χρησιμοποιούνται για τη σχεδίαση του κελιού του πίνακα. Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε την αποτελεσματική μορφοποίηση γεμίσματος για διαφορετικά τμήματα πίνακα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/).

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

### Η `GetEffective` επιστρέφει στιγμιότυπο;

Δεν πάντα. Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τη υπολογισμένη μορφοποίηση μετά την εφαρμογή της κληρονομικότητας, αλλά ορισμένα αντικείμενα αποτελεσματικότητας μπορεί να αποθηκεύονται στην εσωτερική μνήμη. Ένα επακόλουθο κάλεσμα του `GetEffective` μπορεί να επαναϋπολογίσει τη μορφοποίηση και να ανανεώσει τα αποθηκευμένα δεδομένα, επομένως ένα αντικείμενο που λήφθηκε προηγουμένως δεν πρέπει να θεωρηθεί ως μόνιμο στιγμιότυπο.

### Πότε πρέπει να διαβάσω ξανά τις αποτελεσματικές ιδιότητες;

Καλέστε το `GetEffective` ξανά μετά από αλλαγή τοπικής μορφοποίησης, γονικών στυλ, μορφοποίησης διάταξης, μορφοποίησης κύριου θέματος ή προεπιλογών σε επίπεδο παρουσίασης. Η επόμενη κλήση επανεκτιμά τη ιεραρχία μορφοποίησης και επιστρέφει το τρέχον αποτελεσματικό αποτέλεσμα.

### Η αλλαγή ή η αφαίρεση μιας διάταξης/κύριας διαφάνειας επηρεάζει τις αποτελεσματικές ιδιότητες που έχουν ήδη ανακτηθεί;

Ναι, αλλά η αλλαγή αντικατοπτρίζεται στην επόμενη κλήση του `GetEffective`. Εάν μια πηγή μορφοποίησης γονέα αλλάξει ή αφαιρεθεί, τα προηγουμένως ληφθέντα αποτελεσματικά δεδομένα μπορούν να γίνουν παλιά. Μόλις κληθεί ξανά το `GetEffective`, το Aspose.Slides επανεκτιμά το δέντρο μορφοποίησης και οι προκύπτοντες γραμματοσειρές, χρώματα, μεγέθη ή άλλες τιμές μπορεί να αλλάξουν.

### Μπορώ να τροποποιήσω τις τιμές μέσω των αντικειμένων αποτελεσματικών δεδομένων;

Όχι. Τα αντικείμενα αποτελεσματικών δεδομένων εκθέτουν υπολογισμένες τιμές. Κάντε τις αλλαγές στα τοπικά αντικείμενα μορφοποίησης και, στη συνέχεια, λάβετε ξανά τις αποτελεσματικές τιμές.

### Τι συμβαίνει αν μια ιδιότητα δεν έχει οριστεί στο επίπεδο του σχήματος, ούτε στη διάταξη/κύρια, ούτε στις καθολικές ρυθμίσεις;

Η αποτελεσματική τιμή καθορίζεται από τον προεπιλεγμένο μηχανισμό, που περιλαμβάνει προεπιλογές του PowerPoint και του Aspose.Slides. Η τιμή που προκύπτει ενσωματώνεται στα τρέχοντα αποτελεσματικά δεδομένα.

### Από μια αποτελεσματική τιμή γραμματοσειράς, μπορώ να καταλάβω σε ποιο επίπεδο καθορίστηκε το μέγεθος ή η γραμματοσειρά;

Όχι άμεσα. Τα αποτελεσματικά δεδομένα επιστρέφουν τη τελική τιμή. Για να βρείτε την πηγή, ελέγξτε τις τοπικές τιμές στο τμήμα, την παράγραφο, το πλαίσιο κειμένου και τα στυλ κειμένου στα επίπεδα διάταξης, κύριου και παρουσίασης ώστε να εντοπίσετε την πρώτη ρητή οριστική τιμή.

### Γιατί οι αποτελεσματικές τιμές μερικές φορές φαίνονται ίδιες με τις τοπικές;

Επειδή η τοπική τιμή κατέληξε να είναι η τελική (δεν απαιτήθηκε κληρονομικότητα από υψηλότερο επίπεδο). Σε αυτές τις περιπτώσεις, η αποτελεσματική τιμή ταιριάζει με την τοπική.

### Πότε πρέπει να χρησιμοποιήσω τις αποτελεσματικές ιδιότητες και πότε μόνο τις τοπικές;

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα όταν χρειάζεστε το αποτέλεσμα «όπως αποδίδεται» μετά την εφαρμογή όλης της κληρονομικότητας, π.χ. για ευθυγράμμιση χρωμάτων, εσοχών ή μεγεθών. Αν πρέπει να διατηρήσετε αυτές τις τιμές ανεξάρτητα από μεταγενέστερες αλλαγές μορφοποίησης, αντιγράψτε τις απαιτούμενες ιδιότητες σε δικό σας αντικείμενο. Αν θέλετε να αλλάξετε τη μορφοποίηση σε συγκεκριμένο επίπεδο, τροποποιήστε τις τοπικές ιδιότητες και, εφόσον χρειάζεται, διαβάστε ξανά τα αποτελεσματικά δεδομένα για να επαληθεύσετε το αποτέλεσμα.