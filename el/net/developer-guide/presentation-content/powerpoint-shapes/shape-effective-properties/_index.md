---
title: Λήψη Αποτελεσματικών Ιδιοτήτων Σχήματος από Παρουσιάσεις στο .NET
linktitle: Αποτελεσματικές Ιδιότητες
type: docs
weight: 50
url: /el/net/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- σύστημα φωτισμού
- σχήμα ανόρθωσης
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφή γεμίσματος
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να χρησιμοποιείτε το Aspose.Slides για .NET για να διακρίνετε τη τοπική, κληρονομημένη και αποτελεσματική μορφοποίηση σχήματος σε παρουσιάσεις PowerPoint."
---
## **Κατανόηση Τοπικών, Κληρονομημένων και Αποτελεσματικών Ιδιοτήτων**

Η μορφοποίηση του PowerPoint μπορεί να προέρχεται από πολλές πηγές. Η τιμή που αποθηκεύεται απευθείας σε ένα αντικείμενο είναι η **τοπική τιμή**. Εάν αυτή η τιμή δεν έχει οριστεί, το PowerPoint κοιτάζει τις πηγές μορφοποίησης γονέων, όπως η προεπιλογή παραγράφου, ένα στυλ κειμένου, μια διάταξη ή διαφάνεια προτύπου, ένα θέμα ή προεπιλογές σε επίπεδο παρουσίασης. Αυτές οι τιμές είναι **κληρονομημένες τιμές**. Η τιμή που απομένει αφού επιλυθεί ολόκληρη η ιεραρχία είναι η **αποτελεσματική τιμή**—η τιμή που χρησιμοποιείται για την απόδοση του αντικειμένου.

Για παράδειγμα, ένα τμήμα κειμένου ενδέχεται να μην ορίζει το δικό του ύψος γραμματοσειράς. Η τοπική του [FontHeight](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/fontheight/) είναι τότε `float.NaN`, που σημαίνει «δεν ορίστηκε εδώ». Το τμήμα μπορεί να κληρονομήσει ύψος από την παράγραφο, το προεπιλεγμένο στυλ κειμένου της παρουσίασης ή άλλη σχετική πηγή. Η κλήση του [GetEffective](https://reference.aspose.com/slides/el/net/aspose.slides/iportionformat/geteffective/) στη μορφή του τμήματος επιστρέφει το τελικό επιλυμένο ύψος.

Χρησιμοποιήστε τα δύο είδη δεδομένων μορφοποίησης για διαφορετικούς σκοπούς:

- Αναγνώστε ή αλλάξτε ένα τοπικό αντικείμενο μορφής, όπως το [IPortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iportionformat/), όταν χρειάζεται να ελέγξετε πού ορίζεται μια τιμή.
- Αναγνώστε ένα αντικείμενο αποτελεσματικών δεδομένων, όπως το [IPortionFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/iportionformateffectivedata/), όταν χρειάζεστε το τελικό, αποδοθέν αποτέλεσμα. Τα αποτελεσματικά δεδομένα είναι μόνο για ανάγνωση.

## **Σύγκριση Τοπικών, Κληρονομημένων και Αποτελεσματικών Τιμών**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα σχήμα και εφαρμόζει ύψη γραμματοσειράς στα επίπεδα παρουσίασης, παραγράφου και τμήματος. Κάθε βήμα εκτυπώνει τις τιμές που ορίζονται σε αυτά τα επίπεδα και την προκύπτουσα αποτελεσματική τιμή για το ίδιο τμήμα κειμένου. Επίσης, δείχνει γιατί πρέπει να διαβάζετε ξανά τα αποτελεσματικά δεδομένα μετά από αλλαγές μορφοποίησης.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// Ορίστε κληρονομημένες τιμές σε δύο διαφορετικά επίπεδα.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// Μια τοπική τιμή στο τμήμα αντικαθιστά και τις δύο κληρονομημένες τιμές.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Η αλλαγή μιας κληρονομημένης τιμής δεν αντικαθιστά μια υπάρχουσα τοπική τιμή.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Καθαρίστε την τοπική τιμή. Το τμήμα τώρα κληρονομεί ξανά από την παράγραφο.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Καθαρίστε την τιμή της παραγράφου. Η προεπιλογή της παρουσίασης παρέχει τώρα το αποτέλεσμα.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Διαβάστε τα αποτελεσματικά δεδομένα μετά τις προηγούμενες αλλαγές.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

Η προτεραιότητα σε αυτό το παράδειγμα είναι η τοπική μορφοποίηση του τμήματος, στη συνέχεια η μορφοποίηση της παραγράφου, και τέλος η προεπιλογή της παρουσίασης. Άλλα αντικείμενα μπορεί να έχουν διαφορετικές αλυσίδες κληρονομικότητας, αλλά η αρχή είναι η ίδια: μια πιο συγκεκριμένη ρητή τιμή κερδίζει, και το [GetEffective](https://reference.aspose.com/slides/el/net/aspose.slides/iportionformat/geteffective/) επιστρέφει το τελικό αποτέλεσμα.

## **Λήψη Αποτελεσματικών Ιδιοτήτων Κειμένου**

Η μορφοποίηση του κειμένου χωρίζεται σε διάφορα αντικείμενα:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/geteffective/) επιλύει τις ιδιότητες του πλαισίου κειμένου όπως περιθώρια, αγκύρωση, αυτόματη προσαρμογή και κατακόρυφη κατεύθυνση κειμένου.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/el/net/aspose.slides/itextstyle/geteffective/) επιλύει τη μορφοποίηση παραγράφου για κάθε επίπεδο στυλ κειμένου.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/geteffective/) επιλύει τις ιδιότητες της παραγράφου όπως ευθυγράμμιση, εσοχή και σημεία.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/el/net/aspose.slides/iportionformat/geteffective/) επιλύει τις ιδιότητες χαρακτήρων όπως ύψος γραμματοσειράς, τύπος γραμματοσειράς, χρώμα, έντονη και πλάγια γραφή.

Για το επόμενο παράδειγμα, το `text-formatting.pptx` πρέπει να περιέχει τουλάχιστον μία διαφάνεια και ένα [AutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/) με μη κενό πλαίσιο κειμένου. Το AutoShape μπορεί να εμφανίζεται σε οποιαδήποτε θέση στη συλλογή σχημάτων· ο κώδικας αναζητά ένα κατάλληλο αντικείμενο και το επαληθεύει πριν τη χρήση.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **Λήψη Αποτελεσματικών Ιδιοτήτων 3Δ**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/geteffective/) επιστρέφει ένα αντικείμενο [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformateffectivedata/) που ομαδοποιεί όλες τις επιλυμένες ρυθμίσεις 3Δ. Οι ιδιότητες του [Camera](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformateffectivedata/beveltop/) και [BevelBottom](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) εκθέτουν τα αντίστοιχα αποτελεσματικά δεδομένα. Η ανάγνωση αυτών των σχετικών ρυθμίσεων μαζί κάνει πιο εύκολη την κατανόηση της τελικής 3Δ εμφάνισης ενός σχήματος.

Για αυτό το παράδειγμα, το `shape-3d.pptx` πρέπει να περιέχει τουλάχιστον ένα σχήμα στην πρώτη του διαφάνεια. Εφαρμόστε 3Δ κάμερα, φωτισμό ή ρυθμίσεις ανόρθωσης σε αυτό το σχήμα εάν θέλετε το αποτέλεσμα να περιλαμβάνει τιμές διαφορετικές από τις προεπιλογές.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **Λήψη Αποτελεσματικής Μορφοποίησης Πίνακα**

Η μορφοποίηση πίνακα μπορεί να προέρχεται από το στυλ πίνακα και από μορφές που εφαρμόζονται σε ολόκληρο τον πίνακα, στήλη, γραμμή ή μεμονωμένο κελί. Σε συγκρούσεις μεταξύ ρητών ορισμών γεμίσματος, η προτεραιότητα είναι κελί, γραμμή, στήλη και μετά ολόκληρος ο πίνακας. Η αποτελεσματική μορφή ενός κελιού είναι η τελική μορφή που χρησιμοποιείται για τη σχεδίασή του.

Για αυτό το παράδειγμα, το `table-formatting.pptx` πρέπει να περιέχει τουλάχιστον έναν πίνακα στην πρώτη του διαφάνεια. Ο πίνακας πρέπει να έχει τουλάχιστον μια γραμμή και μια στήλη. Ο κώδικας αναζητά ένα [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) αντί να υποθέτει ότι το `Shapes[0]` είναι πίνακας.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

Εάν χρειάζεστε το χρώμα αντί μόνο του τύπου γεμίσματος, πρώτα ελέγξτε το αποτελεσματικό [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/ifillformateffectivedata/filltype/) και στη συνέχεια διαβάστε την ιδιότητα που εφαρμόζεται σε αυτόν τον τύπο—π.χ., το [SolidFillColor](https://reference.aspose.com/slides/el/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) για στερεό γέμισμα.

## **Επανάληψη Ανάγνωσης Αποτελεσματικών Δεδομένων Μετά από Αλλαγές**

Τα αποτελεσματικά δεδομένα περιγράφουν την ιεραρχία μορφοποίησης τη στιγμή που επιλύονται. Καλέστε ξανά το `GetEffective` μετά από αλλαγή οτιδήποτε που μπορεί να συμμετέχει σε αυτήν την ιεραρχία, συμπεριλαμβανομένου:

- της τοπικής μορφοποίησης του αντικειμένου·
- των προεπιλογών παραγράφου ή πλαισίου κειμένου·
- ενός στυλ πίνακα, πίνακα, στήλης, γραμμής ή μορφής κελιού·
- της μορφοποίησης διάταξης ή διαφάνειας προτύπου·
- των δεδομένων θέματος ή προεπιλογών σε επίπεδο παρουσίασης·
- της διάταξης ή προτύπου που έχει εκχωρηθεί σε μια διαφάνεια.

Μην διατηρείτε ένα αντικείμενο αποτελεσματικών δεδομένων ως μόνιμο στιγμιότυπο. Το Aspose.Slides μπορεί να αποθηκεύει προσωρινά κάποια αποτελεσματικά δεδομένα εσωτερικά, και μια μεταγενέστερη κλήση `GetEffective` μπορεί να ανανεώσει αυτά τα δεδομένα. Εάν χρειάζεται να συγκρίνετε τιμές πριν και μετά από μια αλλαγή, αντιγράψτε τις απαραίτητες ακέραιες τιμές—όπως ύψος γραμματοσειράς, χρώμα, ευθυγράμμιση ή πλάτος ανόρθωσης—σε δικές σας μεταβλητές πριν κάνετε την αλλαγή.

Για να αλλάξετε μια τιμή, ενημερώστε το κατάλληλο τοπικό αντικείμενο μορφής και στη συνέχεια καλέστε το `GetEffective` για να επαληθεύσετε το αποτέλεσμα. Τα αντικείμενα αποτελεσματικών δεδομένων είναι μόνο για ανάγνωση.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να προσδιορίσω ποιο επίπεδο παρείχε μια αποτελεσματική τιμή;**

Τα αποτελεσματικά δεδομένα περιέχουν την τελική τιμή, όχι την πηγή της. Εξετάστε τα σχετικά τοπικά αντικείμενα ξεκινώντας από το πιο συγκεκριμένο επίπεδο προς τα έξω. Για το κείμενο, αυτό μπορεί να περιλαμβάνει το τμήμα, την παράγραφο, το πλαίσιο κειμένου, τη διάταξη, το πρότυπο, το θέμα και τις προεπιλογές της παρουσίασης. Απροσδιόριστες τιμές όπως `float.NaN` ή `null` υποδεικνύουν ότι η αναζήτηση συνεχίζεται σε άλλο επίπεδο.

**Τι συμβαίνει όταν κανένα επίπεδο δεν ορίζει μια ιδιότητα;**

Το Aspose.Slides επιλύει την κατάλληλη προεπιλογή του PowerPoint ή της βιβλιοθήκης. Αυτή η επιλυμένη τιμή εμφανίζεται στα αποτελεσματικά δεδομένα ακόμη και αν κανένα τοπικό αντικείμενο δεν την ορίζει ρητά.

**Γιατί μια αποτελεσματική τιμή μερικές φορές ισούται με την τοπική τιμή;**

Η τοπική τιμή κέρδισε τον υπολογισμό κληρονομικότητας. Αυτό είναι αναμενόμενο όταν η ιδιότητα ορίζεται ρητά στο αντικείμενο και κανένας πιο συγκεκριμένος κανόνας δεν την υπερισχύει.

**Πότε πρέπει να χρησιμοποιήσω τοπικά δεδομένα αντί για αποτελεσματικά δεδομένα;**

Χρησιμοποιήστε τοπικά δεδομένα για να εξετάσετε ή να επεξεργαστείτε ένα συγκεκριμένο επίπεδο μορφοποίησης. Χρησιμοποιήστε αποτελεσματικά δεδομένα όταν χρειάζεστε την τελική εμφάνιση μετά από κληρονομικότητα, κανόνες θέματος και εφαρμοσμένα στυλ. Το [complete comparison example](#compare-local-inherited-and-effective-values) δείχνει και τα δύο στην ίδια ροή εργασίας.