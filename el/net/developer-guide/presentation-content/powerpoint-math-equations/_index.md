---
title: Προσθήκη Μαθηματικών Εξισώσεων σε Παρουσιάσεις PowerPoint σε .NET
linktitle: Μαθηματικές Εξισώσεις PowerPoint
type: docs
weight: 80
url: /el/net/powerpoint-math-equations/
keywords:
- μαθηματική εξίσωση
- μαθηματικό σύμβολο
- μαθηματικός τύπος
- μαθηματικό κείμενο
- προσθήκη μαθηματικής εξίσωσης
- προσθήκη μαθηματικού συμβόλου
- προσθήκη μαθηματικού τύπου
- προσθήκη μαθηματικού κειμένου
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εισαγωγή και επεξεργασία μαθηματικών εξισώσεων σε PowerPoint PPT και PPTX με Aspose.Slides για .NET, υποστηρίζοντας OMML, εργαλεία μορφοποίησης και σαφή παραδείγματα κώδικα C#."
---
## **Επισκόπηση**

Το PowerPoint αποθηκεύει εξισώσεις ως Office Math Markup Language (OMML). Με το Aspose.Slides για .NET, μπορείτε να δημιουργήσετε το ίδιο είδος μαθηματικού περιεχομένου προγραμματικά: κλάσματα, ριζικές, συναρτήσεις, όρια, τελεστές N‑ary, πίνακες, πίνακες (arrays) και μορφοποιημένα μαθηματικά μπλοκ.

Στο PowerPoint, οι χρήστες συνήθως προσθέτουν εξισώσεις από **Insert > Equation**:

![Καρτέλα Εισαγωγή του PowerPoint με την εντολή Εξίσωση επιλεγμένη](powerpoint-math-equations_1.png)

Η ίδια διαφάνεια PowerPoint που περιέχει μια επεξεργάσιμη μαθηματική εξίσωση:

![Διαφάνεια PowerPoint που περιέχει μια επεξεργάσιμη μαθηματική εξίσωση](powerpoint-math-equations_2.png)

Aspose.Slides δημιουργεί αυτό το μαθηματικό κείμενο μέσω τριών κύριων αντικειμένων:

- Ένα σχήμα μαθηματικού τύπου, δημιουργημένο με [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), είναι το σχήμα που περιέχει την εξίσωση.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) αποθηκεύει το μαθηματικό περιεχόμενο μέσα στο πλαίσιο κειμένου του σχήματος.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) περιέχει ένα ή περισσότερα αντικείμενα [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/).

Οι περισσότερες παραδείγματα παρακάτω χρησιμοποιούν το [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) και τις αλυσιδωτές μεθόδους από το [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) για να διατηρήσουν τον κώδικα σύντομο και ευανάγνωστο.

Για σενάρια εξαγωγής MathML, δείτε το [Εξαγωγή Μαθηματικών Εξισώσεων από Παρουσιάσεις στο .NET](/slides/el/net/exporting-math-equations/).

## **Δημιουργία Εξίσωσης**

Αυτό το παράδειγμα χρησιμοποιεί το [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) για να δημιουργήσει ένα σχήμα μαθηματικού τύπου και προσθέτει το θεώρημα του Πυθαγόρα:

![Η εξίσωση c στο τετράγωνο ίση με a στο τετράγωνο συν b στο τετράγωνο](powerpoint-math-equations_3.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equation = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(equation);

presentation.Save("pythagorean-theorem.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) δημιουργεί ένα σχήμα που περιέχει ήδη μια μαθηματική παράγραφο. Πρόσβαση στην πρώτη [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), λήψη του [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), και προσθήκη μαθηματικών μπλοκ ή στοιχείων σε αυτήν.
{{% /alert %}}

## **Προσθήκη Κλασμάτων**

Χρησιμοποιήστε το [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) για να δημιουργήσετε ένα κλάσμα. Μπορείτε να επιλέξετε ένα στυλ κλάσματος με το [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

![Ένα κλίεν όμοιο κλάσμα που δείχνει το 1 διαιρεμένο με x](powerpoint-math-equations_4.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

Για ένα στοιβαγμένο κλάσμα, χρησιμοποιήστε το [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Προσθήκη Ριζικών**

Χρησιμοποιήστε το [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) για να δημιουργήσετε τετραγωνική ρίζα, κυβική ρίζα ή άλλη ρίζα. Το τρέχον στοιχείο γίνεται η βάση, και το όρισμα γίνεται ο βαθμός.

![Μια έκφραση ρίζας ν‑του βαθμού με x κάτω από το σύμβολο ρίζας](powerpoint-math-equations_5.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

### **Εμφάνιση ή Απόκρυψη του Βαθμού μιας Τετραγωνικής Ρίζας**

Μια τετραγωνική ρίζα μπορεί να εμφανίζει έναν εμφανή 2 ή να χρησιμοποιεί τη συμβατική σημειογραφία √x. Η ιδιότητα [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) του [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) ελέγχει ποια μορφή εμφανίζεται. Και οι δύο μορφές διατηρούν τον βαθμό 2 και την ρίζα x στην επεξεργάσιμη εξίσωση.

![Η ίδια τετραγωνική ρίζα με το HideDegree ορισμένο σε false στα αριστερά και true στα δεξιά](square-root-degree.png)

Το παράδειγμα αποθηκεύει την ίδια τετραγωνική ρίζα δύο φορές. Στο `visible-degree.pptx` ο 2 είναι ορατός. Στο `hidden-degree.pptx` είναι κρυμμένος.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var radical = new MathematicalText("x").Radical("2");

var shape = slide.Shapes.AddMathShape(20, 20, 200, 100);
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
portion.MathParagraph.Add(new MathBlock(radical));

radical.HideDegree = false;
presentation.Save("visible-degree.pptx", SaveFormat.Pptx);

radical.HideDegree = true;
presentation.Save("hidden-degree.pptx", SaveFormat.Pptx);
```

## **Προσθήκη Συναρτήσεων και Ορίων**

Χρησιμοποιήστε το [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) ή το [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) για συναρτήσεις όπως `sin(x)`, `log(x)`, ή προσαρμοσμένα ονόματα συναρτήσεων. Για όρια, τοποθετήστε `lim` σε ένα [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) ή χρησιμοποιήστε το [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![Το όριο του x καθώς το x προσεγγίζει το άπειρο](powerpoint-math-equations_8.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var limit = new MathematicalText("lim")
    .SetLowerLimit("x→∞")
    .Function("x");

mathParagraph.Add(new MathBlock(limit));

presentation.Save("functions-and-limits.pptx", SaveFormat.Pptx);
```

Για προσαρμοσμένο όνομα συνάρτησης, κάντε το όνομα της συνάρτησης τρέχον στοιχείο και καλέστε το [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) με το όρισμά της:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Προσθήκη N‑ary Τελεστών και Ολοκληρωμάτων**

Χρησιμοποιήστε το [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) για αθροίσεις, ενώσεις, τέμνοι και άλλους μεγάλους τελεστές. Χρησιμοποιήστε το [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) για ολοκληρώματα. Και οι δύο μέθοδοι επιτρέπουν τον καθορισμό κατώτερων και ανώτερων ορίων.

![Μια άθροιση με κατώτερο και ανώτερο όριο](powerpoint-math-equations_7.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var summationBase = new MathematicalText("x")
    .SetSuperscript("k")
    .Join(new MathematicalText("a").SetSuperscript("n-k"));

var summation = summationBase.Nary(MathNaryOperatorTypes.Summation, "k=0", "n");

mathParagraph.Add(new MathBlock(summation));

presentation.Save("nary-operators.pptx", SaveFormat.Pptx);
```

Οι N‑ary τελεστές προορίζονται για μεγάλους τελεστές με προαιρετικά όρια. Απλοί τελεστές όπως `+`, `-`, και `=` προστίθενται συνήθως ως [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) και συγχωνεύονται στην έκφραση.

Για ολοκλήρωμα, χρησιμοποιήστε το [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Προσθήκη Πινάκων**

Χρησιμοποιήστε το [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) για γραμμές και στήλες. Οι πίνακες δεν περιλαμβάνουν παρενθέσεις από προεπιλογή, επομένως εγκυμίστε τον πίνακα όταν χρειάζονται παρενθέσεις, αγκύλες ή άγκιστρα.

![Ένας μαθηματικός πίνακας δύο γραμμών με ένα κενό κελί](powerpoint-math-equations_10.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var matrix = new MathMatrix(2, 3);
matrix[0, 0] = new MathematicalText("1");
matrix[0, 1] = new MathematicalText("x");
matrix[1, 0] = new MathematicalText("x");
matrix[1, 1] = new MathematicalText("2");
matrix[1, 2] = new MathematicalText("y");

mathParagraph.Add(new MathBlock(matrix));

presentation.Save("matrix.pptx", SaveFormat.Pptx);
```

### **Επεξεργασία Υπάρχοντος Πίνακα**

Θεωρήστε ότι ένα μάθημα γραμμικής άλγεβρας ξεκινά με τον πίνακα συντελεστών στο `matrix.pptx`, αποθηκευμένο από το προηγούμενο παράδειγμα. Για την επόμενη άσκηση, διατηρήστε την πρώτη εξίσωση, αντικαταστήστε τη δεύτερη με δύο νέες εξισώσεις και ανανεώστε το σύνολο των μεταβλητών. Ανοίξτε τον υπάρχοντα πίνακα μέσω του [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/) για να διατηρήσετε τους συντελεστές που εξακολουθούν να ισχύουν.

![Αρχικός πίνακας συντελεστών δύο γραμμών με καταχωρίσεις 1, x, και ένα κενό κελί στην πρώτη γραμμή και x, 2, και y στη δεύτερη](matrix-before-edit.png)

Οι δείκτες γραμμής και στήλης ξεκινούν από το μηδέν και αναφέρονται στον πίνακα όπως υπάρχει σε κάθε κλήση. Η εισαγωγή γραμμής πριν τον δείκτη 1 μετακινεί την αρχική δεύτερη γραμμή στο δείκτη 2. Η εισαγωγή μετά το δείκτη 2 προσθέτει μια γραμμή. Η διαγραφή της γραμμής 2 αφαιρεί την αρχική δεύτερη εξίσωση και μετακινεί τη προστιθέμενη γραμμή μία θέση πάνω. Οι στήλες μετατοπίζονται με τον ίδιο τρόπο.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("matrix.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
var matrix = (IMathMatrix)portion.MathParagraph[0][0];

matrix.InsertRowBefore(1);
matrix.InsertRowAfter(2);
matrix.DeleteRow(2);

matrix.InsertColumnBefore(1);
matrix.InsertColumnAfter(3);
matrix.DeleteColumn(3);

// Νέα κελιά είναι αρχικά null. Ορίστε πρώτα τους μη μηδενικούς συντελεστές.
matrix[1, 0] = new MathematicalText("12");
matrix[1, 1] = new MathematicalText("1");
matrix[2, 2] = new MathematicalText("10");
matrix[2, 3] = new MathematicalText("1");
for (var row = 0; row < matrix.RowCount; row++)
{
    for (var column = 0; column < matrix.ColumnCount; column++)
    {
        matrix[row, column] ??= new MathematicalText("0");
    }
}

matrix.SetColumnAlignment(0, MathHorizontalAlignment.Left);
matrix.SetColumnsAlignment(1, 3, MathHorizontalAlignment.Right);

presentation.Save("updated-matrix.pptx", SaveFormat.Pptx);
```

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) ευθυγραμμίζει την πρώτη στήλη αριστερά. [SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) ευθυγραμμίζει τρεις συνεχόμενες στήλες δεξιά, ξεκινώντας από το δείκτη 1. Στο `updated-matrix.pptx`, ο πίνακας έχει τρεις εξισώσεις και τέσσερις μεταβλητές. Οι αρχικοί συντελεστές πρώτης γραμμής `1` και `x` εμφανίζονται τώρα στην πρώτη και τρίτη στήλη.

![Ενημερωμένος πίνακας τριών γραμμών που δείχνει τις γραμμές 1, 0, x, 0· 12, 1, 0, 0· και 0, 0, 10, 1](matrix-after-edit.png)

## **Προσθήκη Δομών Εξισώσεων**

Χρησιμοποιήστε το [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) όταν χρειάζεστε ευθυγραμμισμένες εξισώσεις ή κατακόρυφο σωρό εκφράσεων.

![Ένας κάθετος μαθηματικός πίνακας με x πάνω από y](powerpoint-math-equations_11.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 140);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equationArray = new MathematicalText("x")
    .Join("y")
    .ToMathArray();

mathParagraph.Add(new MathBlock(equationArray));

presentation.Save("equation-array.pptx", SaveFormat.Pptx);
```

### **Στοίχιση Πίνακα με Συνεγγιστικά Στοιχεία**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) ελέγχει την κάθετη στοίχιση ενός πίνακα σε σχέση με τα μαθηματικά στοιχεία δίπλα του. Το παράδειγμα παρακάτω συγκρίνει τη στοίχιση με την πρώτη γραμμή, το κέντρο του πίνακα και την τελευταία γραμμή.

Το παρακάτω παράδειγμα δημιουργεί τρεις ταυτόσημους πίνακες, καθένας με τρεις γραμμές και τα γειτονικά στοιχεία `A=` και `=B`. Όλο το μαθηματικό κείμενο χρησιμοποιεί Cambria Math σε 24 σημεία. Μόνο η στοίχιση του πίνακα αλλάζει.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(780, 200, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var alignments = new[] { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };

for (int i = 0; i < alignments.Length; i++)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = alignments[i].ToString();
    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 16;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var mathShape = slide.Shapes.AddMathShape(20 + i * 260, 60, 240, 130);
    mathShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    var mathParagraph = ((IMathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Justification = MathJustification.LeftJustified;

    var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
    var equationArray = new MathArray(rows);
    equationArray.BaseJustification = alignments[i];
    var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
    mathParagraph.Add(equation);
}

presentation.Save("equation-array-alignment.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

Η παρακάτω σύγκριση εμφανίζει την αποθηκευμένη παρουσίαση στο PowerPoint. Παρατηρήστε τη θέση του `A=` και του `=B` δίπλα σε κάθε πίνακα.

![Δομές εξισώσεων στο PowerPoint με στοίχιση Πάνω, Κέντρο και Κάτω και ταυτόσημα γειτονικά στοιχεία](equation-array-alignment.png)

### **Ρύθμιση Απόστασης Γραμμών**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) επιλέγει τον κανόνα απόστασης για τις γραμμές μέσα στον πίνακα. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) παρέχει αριθμητική τιμή για έναν ρητό κανόνα και αγνοείται από τους προεπιλεγμένους κανόνες.

Για ακριβή απόσταση, η τιμή μετράται σε σημεία. Για αναλογική απόσταση, μετριέται σε μισές γραμμές: η τιμή `3` στο παράδειγμα σημαίνει 1,5 γραμμές. Ορίστε και τις δύο ιδιότητες όταν καθορίζετε μια ρητή τιμή· η αλλαγή μόνο της αριθμητικής τιμής δεν επιλέγει κανόνα απόστασης.

Το παρακάτω παράδειγμα αποθηκεύει πέντε παρουσιάσεις με τις ίδιες εξισώσεις, στοίχιση και ρυθμίσεις γραμματοσειράς. Οι πρώτες τρεις χρησιμοποιούν προεπιλογές· οι τελευταίες δύο δείχνουν ρητές τιμές.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

var settings = new (MathRowSpacingRule Rule, uint Spacing)[]
{
    (MathRowSpacingRule.SingleLineGap, 0),
    (MathRowSpacingRule.OneAndAHalfLineGap, 0),
    (MathRowSpacingRule.TwoLineGap, 0),
    (MathRowSpacingRule.Exactly, 20),
    (MathRowSpacingRule.Multiple, 3)
};

foreach (var setting in settings)
{
    var fileName = $"equation-array-{setting.Rule}.pptx";
    using (var presentation = new Presentation())
    {
        var mathShape = presentation.Slides[0].Shapes.AddMathShape(20, 20, 600, 300);
        var paragraph = mathShape.TextFrame.Paragraphs[0];
        paragraph.ParagraphFormat.SpaceBefore = 0;
        paragraph.ParagraphFormat.SpaceAfter = 0;
        var mathParagraph = ((IMathPortion)paragraph.Portions[0]).MathParagraph;
        mathParagraph.Justification = MathJustification.LeftJustified;

        var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
        var equationArray = new MathArray(rows);
        equationArray.BaseJustification = MathVerticalAlignment.Center;
        equationArray.RowSpacingRule = setting.Rule;
        equationArray.RowSpacing = setting.Spacing;
        var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
        mathParagraph.Add(equation);

        presentation.Save(fileName, SaveFormat.Pptx);
    }

}

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

Η απόσταση γραμμών του πίνακα είναι ξεχωριστή από την απόσταση παραγράφων. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) και [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) προσθέτουν χώρο γύρω από την περιέχουσα παράγραφο, όχι μεταξύ των γραμμών του πίνακα. Ομοίως, το [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) τοποθετεί ολόκληρη τη μαθηματική παράγραφο οριζόντια· δεν αντικαθιστά τη ρύθμιση κάθετης στοίχισης του πίνακα.

## **Προσθήκη Τριγωνομετρικών Συναρτήσεων**

Χρησιμοποιήστε το [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) όταν το όρισμα είναι το τρέχον στοιχείο και το όνομα της συνάρτησης είναι γνωστό.

![Η τριγωνομετρική συνάρτηση cos εφαρμοσμένη στο 2x](powerpoint-math-equations_6.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **Προσθήκη Δεικτών και Εκθέτων**

Χρησιμοποιήστε τους βοηθούς δεικτών και εκθετών για δείκτες και δυνάμεις. Όταν οι δείκτες πρέπει να εμφανίζονται στην αριστερή πλευρά της βάσης, χρησιμοποιήστε το [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![Ένα κεφαλαίο Y με δεικτικό 1 στα αριστερά και εκθέτη n](powerpoint-math-equations_9.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **Προσθήκη Οριοθετών**

Χρησιμοποιήστε το [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) για να τοποθετήσετε μια έκφραση μέσα σε οριοθέτες. Μπορείτε επίσης να ορίσετε χαρακτήρα διαχωριστή για εκφράσεις οριοθέτη που περιέχουν πολλά στοιχεία.

![Μια έκφραση οριοθέτη που περιέχει x, y και z χωρισμένα με κάθετες γραμμές](powerpoint-math-equations_13.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var delimiter = new MathematicalText("x")
    .Join("y")
    .Join("z")
    .Enclose('<', '>');
delimiter.SeparatorCharacter = '|';

mathParagraph.Add(new MathBlock(delimiter));

presentation.Save("delimiters.pptx", SaveFormat.Pptx);
```

### **Μέγεθος και Στοίχιση Οριοθετών**

Ορισμός του [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) σε `true` ώστε οι παρενθέσεις μεγαλώνουν γύρω από ένα ψηλό όργανο, ή σε `false` για να παραμείνουν στο κανονικό μέγεθός τους. Το [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) δέχεται μία από τις δύο τιμές του [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/). Το `Centered` κεντράρει τις παρενθέσεις στον άξονα των μαθηματικών, που περνάει από το κέντρο του συμβόλου `=`. Το `Match` τις ευθυγραμμίζει με το περιεχόμενο. Και οι δύο ρυθμίσεις επηρεάζουν μόνο τους οριοθέτες. Η έκφραση μέσα παραμένει η ίδια.

Το παράδειγμα τοποθετεί ένα κλάσμα στον εκθέτη του `x` ώστε η έκφραση να εκτείνεται πιο πολύ πάνω από τη γραμμή βάσης παρά κάτω. Και οι τέσσερις εξισώσεις χρησιμοποιούν τις ίδιες παρενθέσεις και ρυθμίσεις γραμματοσειράς.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

void AddExpression(float left, float top, bool grow, MathDelimiterShape shape)
{
    var fraction = new MathematicalText("a + b").Divide("c + d");
    var power = new MathematicalText("x").SetSuperscript(fraction);
    var delimiter = power.Enclose('(', ')');
    delimiter.GrowToMatchOperandHeight = grow;
    delimiter.DelimiterShape = shape;

    var mathShape = slide.Shapes.AddMathShape(left, top, 300, 100);
    var portion = (MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 32;
    var equation = new MathematicalText("y = ").Join(delimiter);
    portion.MathParagraph.Add(equation);
}

AddExpression(20, 20, true, MathDelimiterShape.Centered);
AddExpression(350, 20, true, MathDelimiterShape.Match);
AddExpression(20, 140, false, MathDelimiterShape.Centered);
AddExpression(350, 140, false, MathDelimiterShape.Match);

presentation.Save("delimiter-sizing.pptx", SaveFormat.Pptx);
```

Στο PowerPoint, συγκρίνετε τις γραμμές για να δείτε το αποτέλεσμα της ανάπτυξης. Στην άνω γραμμή, οι παρενθέσεις μεγαλώνουν για να περιβάλλουν τον εκθέτη και είναι παρόμοιες για τα δύο σχήματα. Στην κάτω γραμμή, η ανάπτυξη είναι απενεργοποιημένη. Οι μικρότερες παρενθέσεις στα αριστερά (`Centered`) ευθυγραμμίζονται με το σύμβολο `=`· ενώ οι δεξιές (`Match`) κάθονται πιο ψηλά γύρω από την έκφραση.

![Τέσσερις εξισώσεις στο PowerPoint με ενεργή ανάπτυξη οριοθέτη πάνω και απενεργοποιημένη κάτω, και Centered στα αριστερά και Match στα δεξιά](delimiter-sizing.png)

## **Προσθήκη Πλαισίου Περιγράμματος**

Καλείτε το [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) σε ένα κλάσμα για να περιβλήσετε ολόκληρη την έκφραση. Το επιστρεφόμενο [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) εμφανίζει όλες τις τέσσερις πλευρές από προεπιλογή. Χρησιμοποιήστε το [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), το [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), το [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/) και το [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) για να αφαιρέσετε μεμονωμένες πλευρές.

Το παράδειγμα τοποθετεί έξι αντίγραφα του ίδιου κλάσματος σε μια διαφάνεια. Για να δείξει ακύρωση, κρύψτε όλες τις τέσσερις πλευρές και ορίστε το [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) για διαγώνιο ανερχόμενο (↗) ή το [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) για διαγώνιο κυρτό (↘). Μπορείτε επίσης να χρησιμοποιήσετε το [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) ή το [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) με οποιοδήποτε συνδυασμό ορατών πλευρών.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(540, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

IMathBorderBox AddFraction(float x, float y, bool hideBorder = false)
{
    var fraction = new MathematicalText("x+1").Divide("y+2");
    var box = fraction.ToBorderBox();
    box.HideTop = box.HideBottom = box.HideLeft = box.HideRight = hideBorder;

    var shape = slide.Shapes.AddMathShape(x, y, 160, 90);
    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 28;
    portion.MathParagraph.Add(new MathBlock(box));
    return box;
}

AddFraction(10, 10);

var partial = AddFraction(190, 10);
partial.HideTop = true;
partial.HideRight = true;

AddFraction(370, 10, hideBorder: true).StrikethroughBottomLeftToTopRight = true;
AddFraction(10, 120, hideBorder: true).StrikethroughTopLeftToBottomRight = true;
AddFraction(190, 120, hideBorder: true).StrikethroughHorizontal = true;
AddFraction(370, 120).StrikethroughVertical = true;

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

![Έξι επεξεργάσιμα κλάσματα στο PowerPoint. Πάνω σειρά: πλήρες περίγραμμα, κάτω και αριστερά πλευρές, ανερχόμενη διαγώνιο. Κάτω σειρά: κυρτή διαγώνιο, οριζόντια διαγώνωση, κάθετη διαγώνωση με πλήρες περίγραμμα](border-box-fractions.png)

Στο κλάσμα αυτό, η οριζόντια διαγώνωση αλληλεπικαλύπτεται με τη γραμμή του κλάσματος. Η κάθετη διαγώνωση διασχίζει τόσο τον αριθμητή όσο και τον παρονομαστή, ενώ το περίγραμμα παραμένει ορατό. Αυτές οι γραμμές διακοσμούν ολόκληρη την έκφραση. Η κανονική διαγράμμιση κειμένου εφαρμόζεται σε χαρακτήρες ενός τμήματος κειμένου. Αφού ξαναανοίξετε την παρουσίαση στο PowerPoint, μπορείτε ακόμη να επεξεργαστείτε ανεξάρτητα τον αριθμητή και τον παρονομαστή.

## **Έλεγχος Ορατότητας και Διάταξης με Στοιχεία Φαντάσματος**

Τυλίξτε μια έκφραση μέσα στο [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) για να ελέγξετε την ορατότητά της και το χώρο που καταλαμβάνει σε μια εξίσωση ανεξάρτητα. Οι ιδιότητες του [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) ελέγχουν τα ακόλουθα:

| Ιδιότητα | Αποτέλεσμα |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | Ορίστε σε `false` για να κρύψετε την έκφραση. Οι διαστάσεις της εξακολουθούν να συμβάλλουν στη διάταξη εκτός αν οι αντίστοιχες ιδιότητες παρακάτω είναι `true`. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | Θεωρεί το οριζόντιο πλάτος της έκφρασης ως μηδέν, επιτρέποντας στα γειτονικά στοιχεία να πλησιάσουν πιο κοντά. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | Θεωρεί την ανύψωση της ως μηδέν, μειώνοντας το χώρο που κρατιέται πάνω από τα γειτονικά στοιχεία. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | Θεωρεί την κατάβαση της ως μηδέν, φέρνοντας μια γραμμή κλάσματος ή άλλο περιεχόμενο κάτω από την έκφραση πιο κοντά στα γειτονικά στοιχεία. |

Η γραμμή βάσης είναι η αναφορά στην οποία τοποθετούνται τα κανονικά μαθηματικά γράμματα. Η απόκρυψη περιεχομένου δεν αφαιρεί τις διαστάσεις του, και η μεταχείριση μιας διάστασης ως μηδέν δεν διαγράφει την έκφραση. Η υποκείμενη έκφραση παραμένει διαθέσιμη μέσω του [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/). Ορίστε ξανά το [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) σε `true` για να εμφανιστεί ξανά· οι ρυθμίσεις διάστασης παραμένουν αμετάβλητες.

Το παρακάτω παράδειγμα δημιουργεί πέντε παραλλαγές δίπλα-δίπλα: ένα ορατό κλάσμα, ένα κρυφό κλάσμα που κρατά χώρο, και τρία κρυφά κλάσματα με μία διάσταση να θεωρείται μηδέν. Κάθε παραλλαγή χρησιμοποιεί την ίδια περιβάλλουσα έκφραση και Cambria Math σε 24 σημεία. Όλες οι μορφές εξίσωσης έχουν την ίδια θέση κορυφής, σημειωμένη από τον γκρίζο οδηγό. Η τοποθέτηση του φαντάσματος στον αριθμητή ενός εξωτερικού κλάσματος κάνει τις κατακόρυφες αλλαγές διάταξης πιο ορατές.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(1000, 180, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var labels = new[] { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

var guide = slide.Shapes.AddAutoShape(ShapeType.Line, 10, 60, 980, 0);
guide.LineFormat.FillFormat.FillType = FillType.Solid;
guide.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;

for (var i = 0; i < labels.Length; i++)
{
    var left = 10 + i * 200;
    
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = labels[i];

    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 14;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var fraction = new MathFraction(CreateText("a+b"), CreateText("c+d"));
    var phantom = new MathPhantom(fraction);
    phantom.Show = i == 0;
    phantom.ZeroWidth = i == 2;
    phantom.ZeroAsc = i == 3;
    phantom.ZeroDesc = i == 4;

    var numerator = new MathBlock(CreateText("x+")).Join(phantom).Join(CreateText("+y"));
    var equation = new MathFraction(numerator, CreateText("z"));

    var shape = slide.Shapes.AddMathShape(left, 60, 190, 100);
    shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;

    var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Add(new MathBlock(equation));
}

presentation.Save("math-phantom.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

![Πέντε εξισώσεις στο PowerPoint που συγκρίνονται: ένα ορατό κλάσμα, ένα κρυφό κλάσμα που κρατά χώρο, και κρυφά κλάσματα με ZeroWidth, ZeroAsc ή ZeroDesc ενεργοποιημένα](math-phantom.png)

## **Ομαδοποίηση Όρων**

Χρησιμοποιήστε το [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) για να τοποθετήσετε έναν χαρακτήρα ομαδοποίησης πάνω ή κάτω από μια έκφραση. Προσθέστε ένα όριο για να επισημάνετε τους ομαδοποιημένους όρους.

![Η έκφραση x συν y ομαδοποιημένη με την ετικέτα οποιοδήποτε κείμενο κάτω από αυτήν](powerpoint-math-equations_15.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var grouped = new MathematicalText("x + y")
    .Group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
    .SetLowerLimit("any text");

mathParagraph.Add(new MathBlock(grouped));

presentation.Save("grouped-terms.pptx", SaveFormat.Pptx);
```

## **Μορφοποίηση Μαθηματικών Στοιχείων**

Χρησιμοποιήστε βοηθούς μορφοποίησης μόνο όπου διευκρινίζουν τον τύπο. Για παράδειγμα, το [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) τοποθετεί μια γραμμή πάνω από ένα μαθηματικό στοιχείο.

![Μια μαθηματική έκφραση ABC με υπέρβαρο](powerpoint-math-equations_14.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

### **Μορφοποίηση Κειμένου σε Υπάρχουσα Εξίσωση**

Για να μορφοποιήσετε κείμενο σε μια υπάρχουσα εξίσωση, διασχίστε το δέντρο στοιχείων κάθε μαθηματικού μπλοκ. Η μέθοδος [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) επιστρέφει μόνο τα άμεσα παιδιά· έτσι καλέστε την αναδρομικά για να φτάσετε στο κείμενο μέσα σε κλάσματα, εκθέτες, ριζικές και άλλες ενσωματωμένες δομές. Ελέγξτε το τρέχον στοιχείο καθώς και τα παιδιά του ώστε να συμπεριλάβετε το αρχικό στοιχείο όταν είναι [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/).

Αυτό το παράδειγμα υποθέτει ότι μια παρουσίαση περιέχει μια εξίσωση όπως `z = xᵢ / ∛y`, με ένα κλάσμα που περιέχει δείκτη στον αριθμητή και ριζική στον παρονομαστή. Η επεξεργασία μόνο των στοιχείων κορυφής του μπλοκ θα χάσει το κείμενο μέσα στο κλάσμα. Το παράδειγμα εντοπίζει μαθηματικές περιοχές στα πλαίσια κειμένου των διαφανειών, προσπελαύνει τα μπλοκ μέσω του [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), και ορίζει το [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) σε 28 σημεία για κάθε στοιχείο κειμένου μέσω της ιδιότητας [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape || autoShape.TextFrame == null)
            continue;

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is IMathPortion mathPortion)
                {
                    foreach (var block in mathPortion.MathParagraph)
                        FormatMathText(block);
                }
            }
        }
    }
}

presentation.Save("formatted-equations.pptx", SaveFormat.Pptx);

void FormatMathText(IMathElement element)
{
    if (element is MathematicalText text)
        text.Format.FontHeight = 28;

    foreach (var child in element.GetChildren())
        FormatMathText(child);
}
```

Η αποθηκευμένη παρουσίαση περιέχει την ενημερωμένη μορφοποίηση κειμένου σε κάθε επίπεδο κάθε επεξεργασμένης εξίσωσης, διατηρώντας το κείμενο και τη μαθηματική δομή.

## **Γρήγορη Αναφορά**

| Εργασία | Κύριο API |
| --- | --- |
| Δημιουργία μαθηματικού κειμένου | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Συνδυασμός στοιχείων | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Δημιουργία κλασμάτων | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Προσθήκη εκθέτη ή δείκτη | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Προσθήκη συναρτήσεων | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Προσθήκη ριζικών | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Προσθήκη ορίων | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Προσθήκη αριστερών εκθέσεων | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Προσθήκη αθροίσεων και ολοκληρωμάτων | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Προσθήκη πινάκων | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Προσθήκη πινάκων εξισώσεων | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Προσθήκη οριοθετών | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Προσθήκη γραμμών και περιγραμμάτων | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Ομαδοποίηση όρων | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **Συχνές Ερωτήσεις**

**Μπορώ να επεξεργαστώ μια υπάρχουσα εξίσωση PowerPoint;**

Ναι. Ανοίξτε την παρουσίαση, βρείτε το σχήμα που περιέχει ένα [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), πάρτε το [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), και ενημερώστε τα μαθηματικά μπλοκ σε αυτήν την παράγραφο.

**Αποθηκεύονται οι εξισώσεις ως επεξεργάσιμα μαθηματικά του PowerPoint;**

Ναι. Όταν αποθηκεύετε σε PPTX, το Aspose.Slides γράφει την εξίσωση ως επεξεργάσιμη Office math περιεχόμενο.

**Μπορώ να εξάγω τις εξισώσεις σε LaTeX;**

Ναι. Λάβετε το [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) της εξίσωσης από το [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), και καλέστε το [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) για να το εξάγετε άμεσα. Για ένα πλήρες παράδειγμα, δείτε το [Export Math Equations from Presentations in .NET](/slides/el/net/exporting-math-equations/#export-math-equations-to-latex).