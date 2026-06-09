---
title: Ανακτήστε τις Αποτελεσματικές Ιδιότητες Σχήματος από Παρουσιάσεις σε .NET
linktitle: Αποτελεσματικές Ιδιότητες
type: docs
weight: 50
url: /el/net/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- σύστημα φωτισμού
- σχήμα λοξοτομίας
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

Αυτό το θέμα εξηγεί τη διαφορά μεταξύ **τοπικών** και **αποτελεσματικών** ιδιοτήτων. Οι τοπικές τιμές είναι τιμές που ορίζονται άμεσα σε ένα συγκεκριμένο επίπεδο μορφοποίησης, όπως:

1. Ιδιότητες τμήματος σε μια διαφάνεια.  
2. Στυλ κειμένου προτύπου σχήματος σε διάταξη ή κύρια διαφάνεια, όταν το σχήμα πλαισίου κειμένου του τμήματος έχει ένα.  
3. Καθολικές ρυθμίσεις κειμένου σε μια παρουσίαση.

Οι τοπικές τιμές μπορούν να οριστούν ή να παραλειφθούν σε οποιοδήποτε επίπεδο. Όταν το Aspose.Slides χρειάζεται την τελική μορφοποίηση «όπως αποδίδεται», επιλύει την αλυσίδα κληρονομικότητας και επιστρέφει τιμές **αποτελεσματικές**. Μπορείτε να τις λάβετε καλώντας τη μέθοδο `GetEffective` στο τοπικό αντικείμενο μορφοποίησης.

Το παρακάτω παράδειγμα δείχνει πώς να λάβετε τις αποτελεσματικές τιμές. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) με πλαίσιο κειμένου και τουλάχιστον ένα τμήμα.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
Τα δεδομένα αποτελεσματικής μορφοποίησης αντιπροσωπεύουν τη τρέχουσα υπολογισμένη μορφοποίηση μετά την εφαρμογή της κληρονομικότητας. Στην τρέχουσα υλοποίηση, ορισμένα αντικείμενα αποτελεσματικών δεδομένων, όπως το [IPortionFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/iportionformateffectivedata/), μπορεί να αποθηκεύονται προσωρινά εσωτερικά. Η επανάκληση του `GetEffective` μετά την αλλαγή της γονικής ή κληρονομημένης μορφοποίησης μπορεί να ανανεώσει τα προσωρινά δεδομένα, και ένα αντικείμενο που είχε ληφθεί προηγουμένως ίσως να μην αντιπροσωπεύει πλέον την προηγούμενη κατάσταση. Εάν χρειαστεί να διατηρήσετε τις αποτελεσματικές τιμές για μελλοντική χρήση, αντιγράψτε τις απαιτούμενες ιδιότητες, όπως το ύψος γραμματοσειράς, το χρώμα γεμίσματος, το στυλ γραμματοσειράς ή την ευθυγράμμιση, στο δικό σας αντικείμενο δεδομένων.
{{% /alert %}}

## **Λήψη Αποτελεσματικών Ιδιοτήτων Κάμερας**

Το Aspose.Slides σας επιτρέπει να λάβετε αποτελεσματικές ιδιότητες μιας κάμερας. Η διεπαφή [ICameraEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/icameraeffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει αποτελεσματικές ιδιότητες κάμερας. Ένα αντικείμενο [ICameraEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/icameraeffectivedata/) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformateffectivedata/), το οποίο παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες της κάμερας. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει 3D μορφοποίηση.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Λήψη Αποτελεσματικών Ιδιοτήτων Φωτισμού (Light Rig)**

Το Aspose.Slides σας επιτρέπει να λάβετε αποτελεσματικές ιδιότητες ενός light rig. Η διεπαφή [ILightRigEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ilightrigeffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει αποτελεσματικές ιδιότητες του light rig. Ένα αντικείμενο [ILightRigEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ilightrigeffectivedata/) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformateffectivedata/), το οποίο παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες του light rig. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει 3D μορφοποίηση.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Λήψη Αποτελεσματικών Ιδιοτήτων Κόψιματος Σχήματος (Bevel)**

Το Aspose.Slides σας επιτρέπει να λάβετε αποτελεσματικές ιδιότητες ενός bevel σχήματος. Η διεπαφή [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ishapebeveleffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει αποτελεσματικές ιδιότητες ανάπλασης επιφάνειας για ένα σχήμα. Ένα αντικείμενο [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ishapebeveleffectivedata/) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformateffectivedata/), το οποίο παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες του άνω bevel ενός σχήματος. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει 3D μορφοποίηση.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Λήψη Αποτελεσματικών Ιδιοτήτων Πλαισίου Κειμένου**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε αποτελεσματικές ιδιότητες ενός πλαισίου κειμένου. Η διεπαφή [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformateffectivedata/) περιέχει τις αποτελεσματικές ιδιότητες μορφοποίησης πλαισίου κειμένου.

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες μορφοποίησης πλαισίου κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) με πλαίσιο κειμένου.

```csharp
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

## **Λήψη Αποτελεσματικών Ιδιοτήτων Τεχνοτροπίας Κειμένου**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε αποτελεσματικές ιδιότητες μιας τεχνοτροπίας κειμένου. Η διεπαφή [ITextStyleEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/itextstyleeffectivedata/) περιέχει τις αποτελεσματικές ιδιότητες τεχνοτροπίας κειμένου.

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες τεχνοτροπίας κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) με πλαίσιο κειμένου.

```csharp
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

## **Λήψη Τιμής Αποτελεσματικού Ύψους Γραμματοσειράς**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε το αποτελεσματικό ύψος γραμματοσειράς. Το παρακάτω δείγμα κώδικα δείχνει πώς το αποτελεσματικό ύψος γραμματοσειράς ενός τμήματος αλλάζει μετά τον ορισμό τοπικών τιμών ύψους γραμματοσειράς σε διαφορετικά επίπεδα δομής παρουσίασης.

```csharp
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

## **Λήψη Αποτελεσματικής Μορφοποίησης Γέμισης για Πίνακα**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε αποτελεσματική μορφοποίηση γέμισης για διαφορετικά τμήματα πίνακα. Η διεπαφή [IFillFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ifillformateffectivedata/) περιέχει τις αποτελεσματικές ιδιότητες μορφοποίησης γέμισης. Η μορφοποίηση κελιού έχει υψηλότερη προτεραιότητα από τη μορφοποίηση γραμμής, η μορφοποίηση γραμμής έχει υψηλότερη προτεραιότητα από τη μορφοποίηση στήλης, και η μορφοποίηση στήλης έχει υψηλότερη προτεραιότητα από τη μορφοποίηση ολόκληρου του πίνακα.

Ως αποτέλεσμα, οι ιδιότητες [ICellFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/icellformateffectivedata/) χρησιμοποιούνται για τη σχεδίαση του κελιού του πίνακα. Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε την αποτελεσματική μορφοποίηση γέμισης για διαφορετικά τμήματα πίνακα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/).

```csharp
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

## **Συχνές Ερωτήσεις**

**Επιστρέφει η `GetEffective` ένα στιγμιότυπο;**

Δεν συμβαίνει πάντα. Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τη υπολογισμένη μορφοποίηση μετά την εφαρμογή της κληρονομικότητας, αλλά ορισμένα αντικείμενα αποτελεσματικών δεδομένων μπορούν να αποθηκευτούν προσωρινά εσωτερικά. Ένα επόμενο κάλεσμα του `GetEffective` μπορεί να επαναϋπολογίσει τη μορφοποίηση και να ανανεώσει τα προσωρινά δεδομένα, επομένως ένα αντικείμενο που είχε ληφθεί προηγουμένως δεν πρέπει να θεωρείται ως μόνιμο στιγμιότυπο.

**Πότε πρέπει να διαβάσω ξανά τις αποτελεσματικές ιδιότητες;**

Καλέστε τη `GetEffective` ξανά μετά την αλλαγή της τοπικής μορφοποίησης, των γονικών στυλ, της μορφοποίησης διάταξης, της μορφοποίησης κύριας διαφάνειας ή των προεπιλεγμένων ρυθμίσεων σε επίπεδο παρουσίασης. Η επόμενη κλήση επαναξιολογεί την ιεραρχία μορφοποίησης και επιστρέφει το τρέχον αποτελεσματικό αποτέλεσμα.

**Επηρεάζει η αλλαγή ή αφαίρεση μιας διαφάνειας διάταξης/κύριας διαφάνειας τις αποτελεσματικές ιδιότητες που έχουν ήδη ληφθεί;**

Ναι, αλλά η αλλαγή αντανακλάται στην επόμενη κλήση του `GetEffective`. Εάν μια πηγή γονικής μορφοποίησης αλλάξει ή αφαιρεθεί, τα προηγούμενα αποτελεσματικά δεδομένα μπορεί να είναι παλιά. Μόλις κληθεί ξανά η `GetEffective`, το Aspose.Slides επαναξιολογεί το δέντρο μορφοποίησης και οι τελικές γραμματοσειρές, χρώματα, μεγέθη ή άλλες τιμές μπορεί να αλλάξουν.

**Μπορώ να τροποποιήσω τιμές μέσω των αποτελεσματικών δεδομένων;**

Όχι. Τα αποτελεσματικά δεδομένα εκθέτουν υπολογιζόμενες τιμές. Κάντε αλλαγές στα τοπικά αντικείμενα μορφοποίησης και, στη συνέχεια, λάβετε ξανά τις αποτελεσματικές τιμές.

**Τι συμβαίνει αν μια ιδιότητα δεν ορίζεται σε επίπεδο σχήματος, ούτε στη διάταξη/κύρια διαφάνεια, ούτε στις καθολικές ρυθμίσεις;**

Η αποτελεσματική τιμή καθορίζεται από τον μηχανισμό προεπιλογής, που περιλαμβάνει τις προεπιλογές του PowerPoint και του Aspose.Slides. Η τιμή που προκύπτει γίνεται μέρος των τρεχουσών αποτελεσματικών δεδομένων.

**Από μια αποτελεσματική τιμή γραμματοσειράς, μπορώ να καταλάβω ποιο επίπεδο παρείχε το μέγεθος ή την οικογένεια γραμματοσειράς;**

Όχι άμεσα. Τα αποτελεσματικά δεδομένα επιστρέφουν την τελική τιμή. Για να βρείτε την πηγή, ελέγξτε τις τοπικές τιμές στο τμήμα, την παράγραφο, το πλαίσιο κειμένου και τις τεχνοτροπίες κειμένου σε επίπεδα διάταξης, κύριας διαφάνειας και παρουσίασης, ώστε να εντοπίσετε πού εμφανίζεται η πρώτη ρητή ορισμός.

**Γιατί οι αποτελεσματικές τιμές μερικές φορές φαίνονται ίδιες με τις τοπικές;**

Επειδή η τοπική τιμή κατέληξε να είναι η τελική (δεν απαιτήθηκε κληρονομικότητα από ανώτερο επίπεδο). Σε αυτές τις περιπτώσεις, η αποτελεσματική τιμή ταιριάζει με την τοπική.

**Πότε πρέπει να χρησιμοποιώ τις αποτελεσματικές ιδιότητες και πότε να εργάζομαι μόνο με τις τοπικές;**

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα όταν χρειάζεστε το αποτέλεσμα «όπως αποδίδεται» μετά την πλήρη κληρονομικότητα, π.χ. για να ευθυγραμμίσετε χρώματα, εσοχές ή μεγέθη. Εάν χρειάζεται να διατηρήσετε αυτές τις τιμές ανεξάρτητα από μελλοντικές αλλαγές μορφοποίησης, αντιγράψτε τις απαιτούμενες ιδιότητες στο δικό σας αντικείμενο. Εάν χρειάζεται να αλλάξετε τη μορφοποίηση σε συγκεκριμένο επίπεδο, τροποποιήστε τις τοπικές ιδιότητες και, εάν απαιτείται, διαβάστε ξανά τα αποτελεσματικά δεδομένα για να επαληθεύσετε το αποτέλεσμα.