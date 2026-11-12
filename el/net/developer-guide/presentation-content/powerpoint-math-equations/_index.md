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
description: "Εισαγωγή και επεξεργασία μαθηματικών εξισώσεων σε PowerPoint PPT και PPTX με το Aspose.Slides για .NET, υποστηρίζοντας OMML, εργαλεία μορφοποίησης και σαφή παραδείγματα κώδικα C#."
---
## **Επισκόπηση**

Το PowerPoint αποθηκεύει εξισώσεις ως Office Math Markup Language (OMML). Με το Aspose.Slides για .NET, μπορείτε να δημιουργήσετε το ίδιο είδος μαθηματικού περιεχομένου προγραμματιστικά: κλάσματα, ρίζες, συναρτήσεις, όρια, N‑ary τελεστές, πίνακες, σειρές και μορφοποιημένα μαθηματικά μπλοκ.

In PowerPoint, users normally add equations from **Insert > Equation**:

![Καρτέλα Insert του PowerPoint με την εντολή Equation επιλεγμένη](powerpoint-math-equations_1.png)

The result is editable math text on the slide:

![Διαφάνεια PowerPoint που περιέχει επεξεργάσιμη μαθηματική εξίσωση](powerpoint-math-equations_2.png)

Aspose.Slides builds that math text through three main objects:

- Ένα μαθηματικό σχήμα, δημιουργημένο με [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), είναι το σχήμα που περιέχει την εξίσωση.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) αποθηκεύει το μαθηματικό περιεχόμενο μέσα στο πλαίσιο κειμένου του σχήματος.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) περιέχει ένα ή περισσότερα αντικείμενα [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/).

Τα περισσότερα παραδείγματα παρακάτω χρησιμοποιούν το [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) και τις αλυσιδωτές μεθόδους από το [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) ώστε ο κώδικας να παραμένει σύντομος και ευανάγνωστος.

Για MathML export scenarios, see [Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις σε .NET](/slides/el/net/exporting-math-equations/).

## **Δημιουργία εξίσωσης**

Αυτό το παράδειγμα χρησιμοποιεί το [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) για να δημιουργήσει ένα μαθηματικό σχήμα και προσθέτει το Πυθαγόρειο θεώρημα:

![Η εξίσωση c στο τετράγωνο ισούται με a στο τετράγωνο συν b στο τετράγωνο](powerpoint-math-equations_3.png)

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) δημιουργεί ένα σχήμα που ήδη περιέχει μια μαθηματική παράγραφο. Πρόσβαση στην πρώτη [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), λήψη του [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), και προσθήκη μαθηματικών μπλοκ ή στοιχείων σε αυτήν.
{{% /alert %}}

## **Προσθήκη κλασμάτων**

Χρησιμοποιήστε το [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) για τη δημιουργία ενός κλάσματος. Μπορείτε να επιλέξετε ένα στυλ κλάσματος με το [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

![Ένα λοξό μαθηματικό κλάσμα που δείχνει το ένα διαιρεμένο με x](powerpoint-math-equations_4.png)

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

## **Προσθήκη ριζών**

Χρησιμοποιήστε το [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) για τη δημιουργία τετραγωνικής ρίζας, κυβικής ρίζας ή άλλης ρίζας. Το τρέχον στοιχείο γίνεται η βάση και το όρισμα γίνεται ο εκθέτης.

![Μια έκφραση n‑ης ρίζας με x κάτω από το σύμβολο ρίζας](powerpoint-math-equations_5.png)

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

## **Προσθήκη συναρτήσεων και ορίων**

Χρησιμοποιήστε το [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) ή το [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) για συναρτήσεις όπως `sin(x)`, `log(x)`, ή προσαρμοσμένα ονόματα συναρτήσεων. Για όρια, τοποθετήστε `lim` σε ένα [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) ή χρησιμοποιήστε το [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![Το όριο του x όταν το x τείνει στο άπειρο](powerpoint-math-equations_8.png)

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

Για προσαρμοσμένο όνομα συνάρτησης, θέστε το όνομα της συνάρτησης ως τρέχον στοιχείο και καλέστε το [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) με το όρισμα του:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Προσθήκη N-ary τελεστών και ολοκληρωμάτων**

Χρησιμοποιήστε το [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) για άθροισμα, ένωση, τομή και άλλους μεγάλους τελεστές. Χρησιμοποιήστε το [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) για ολοκληρώματα. Και οι δύο μέθοδοι επιτρέπουν τον ορισμό κατώτερου και ανώτερου ορίου.

![Μία άθροιση με κατώτερο και ανώτερο όριο](powerpoint-math-equations_7.png)

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

Οι N-ary τελεστές προορίζονται για μεγάλους τελεστές με προαιρετικά όρια. Απλοί τελεστές όπως `+`, `-`, και `=` συνήθως προστίθενται ως [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) και ενώνται στην έκφραση.

Για ένα ολοκλήρωμα, χρησιμοποιήστε το [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Προσθήκη πινάκων**

Χρησιμοποιήστε το [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) για γραμμές και στήλες. Τα πλέγματα (πίνακες) δεν περιλαμβάνουν αγκύλες κατά προεπιλογή, οπότε τυλίξτε τον πίνακα όταν χρειάζεστε παρενθέσεις, αγκύλες ή άγκιστρα.

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

## **Προσθήκη πινάκων εξισώσεων**

Χρησιμοποιήστε το [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) όταν χρειάζεστε ευθυγραμμισμένες εξισώσεις ή κάθετο σύνολο εκφράσεων.

![Μία κάθετη μαθηματική διάταξη με x πάνω από y](powerpoint-math-equations_11.png)

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

## **Προσθήκη τριγωνομετρικών συναρτήσεων**

Χρησιμοποιήστε το [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) όταν το όρισμα είναι το τρέχον στοιχείο και το όνομα της συνάρτησης είναι γνωστό.

![Η τριγωνομετρική συνάρτηση cos που εφαρμόζεται στο 2x](powerpoint-math-equations_6.png)

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

## **Προσθήκη δεικτών και εκθετών**

Χρησιμοποιήστε τις βοηθητικές συναρτήσεις για δείκτες και εκθέτες. Όταν οι δείκτες πρέπει να εμφανίζονται στην αριστερή πλευρά της βάσης, χρησιμοποιήστε το [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![Ένα κεφαλαίο Y με αριστερό δείκτη 1 και εκθέτη n](powerpoint-math-equations_9.png)

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

## **Προσθήκη οριοθετητών**

Χρησιμοποιήστε το [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) για να τοποθετήσετε μια έκφραση μέσα σε οριοθετητές. Μπορείτε επίσης να ορίσετε χαρακτήρα διαχωριστή για εκφράσεις οριοθετητών που περιέχουν πολλά στοιχεία.

![Μία έκφραση οριοθετητών που περιέχει x, y και z χωρισμένα με κάθετες γραμμές](powerpoint-math-equations_13.png)

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

### **Μέγεθος και Στοίχιση Οριοθετητών**

Ορίστε το [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) σε `true` ώστε οι παρενθέσεις να μεγαλώνουν γύρω από ένα ψηλό όργανο, ή σε `false` ώστε να παραμείνουν στο κανονικό μέγεθος. Το [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) δέχεται μία από τις δύο τιμές [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/). `Centered` κεντράρει τις παρενθέσεις στον μαθηματικό άξονα, που περνάει από το μέσο του συμβόλου ισότητας. `Match` τις στοιχίζει με το περιεχόμενο. Και οι δύο ρυθμίσεις επηρεάζουν μόνο τους οριοθετητές. Η έκφραση μέσα παραμένει η ίδια.

Το παράδειγμα τοποθετεί ένα κλάσμα στον εκθέτη του `x` ώστε η έκφραση να εκτείνεται περισσότερο πάνω από τη γραμμή βάσης απ’ότι κάτω της. Οι τέσσερις εξισώσεις χρησιμοποιούν τις ίδιες παρενθέσεις και ρυθμίσεις γραμματοσειράς.

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

Στο PowerPoint, συγκρίνετε τις σειρές για να δείτε το αποτέλεσμα της μεγέθυνσης. Στην πρώτη σειρά, οι παρενθέσεις μεγαλώνουν ώστε να περικλείουν τον εκθέτη και φαίνονται όμοιες για τα δύο σχήματα. Στη δεύτερη σειρά, η μεγέθυνση είναι ανενεργή. Οι μικρότερες παρενθέσεις στα αριστερά (`Centered`) ευθυγραμμίζονται με το σύμβολο ισότητας, ενώ αυτές στα δεξιά (`Match`) είναι ψηλότερες γύρω από την έκφραση.

![Τέσσερις εξισώσεις στο PowerPoint με ενεργή τη μεγέθυνση οριοθετητών πάνω και ανενεργή κάτω, και Centered στα αριστερά και Match στα δεξιά](delimiter-sizing.png)

## **Προσθήκη πλαισίου**

Χρησιμοποιήστε το [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) όταν η ίδια η εξίσωση πρέπει να περιβάλλεται από πλαίσιο.

![Μια εξίσωση σε πλαίσιο που δείχνει a στο τετράγωνο ίσο με b στο τετράγωνο συν c στο τετράγωνο](powerpoint-math-equations_12.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var boxedEquation = new MathematicalText("a")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("b").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("c").SetSuperscript("2"))
    .ToBorderBox();

mathParagraph.Add(new MathBlock(boxedEquation));

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

## **Ομαδοποίηση όρων**

Χρησιμοποιήστε το [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) για να τοποθετήσετε ένα χαρακτήρα ομαδοποίησης πάνω ή κάτω από μια έκφραση. Προσθέστε ένα όριο για να επισημάνετε τους ομαδοποιημένους όρους.

![Η έκφραση x συν y ομαδοποιημένη με την ετικέτα οποιοδήποτε κείμενο κάτω από αυτή](powerpoint-math-equations_15.png)

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

## **Μορφοποίηση μαθηματικών στοιχείων**

Χρησιμοποιήστε τις βοηθητικές μορφοποιήσεις μόνο όπου διευκρινίζουν τον τύπο. Για παράδειγμα, το [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) τοποθετεί μια μπάρα πάνω από ένα μαθηματικό στοιχείο.

![Μία μαθηματική έκφραση ABC με μπάρα από πάνω](powerpoint-math-equations_14.png)

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

### **Μορφοποίηση κειμένου σε υπάρχουσα εξίσωση**

Για να μορφοποιήσετε κείμενο σε μια υπάρχουσα εξίσωση, διασχίστε το δέντρο στοιχείων κάθε μαθηματικού μπλοκ. Η μέθοδος [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) επιστρέφει μόνο τα άμεσα παιδιά, επομένως καλέστε την αναδρομικά για να φτάσετε στο κείμενο μέσα σε κλάσματα, εκθέτες, ρίζες και άλλα ένθετα δομές. Ελέγξτε τόσο το τρέχον στοιχείο όσο και τα παιδιά του ώστε να συμπεριλάβετε το αρχικό στοιχείο όταν είναι [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/).

Αυτό το παράδειγμα υποθέτει ότι μια παρουσίαση περιέχει μια εξίσωση όπως `z = xᵢ / ∛y`, με ένα κλάσμα που έχει δείκτη στον αριθμητή του και ρίζα στον παρονομαστή του. Η επεξεργασία μόνο των στοιχείων κορυφής του μπλοκ θα παρείχε παραβίαση του κειμένου μέσα στο κλάσμα. Το παράδειγμα βρίσκει μαθηματικές περιοχές σε πλαίσια κειμένου διαφανειών, προσπελάζει τα μπλοκ τους μέσω του [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), και ορίζει το [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) στα 28 points μέσω της ιδιότητας [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) κάθε στοιχείου κειμένου.

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

Η αποθηκευμένη παρουσίαση περιέχει την ενημερωμένη μορφοποίηση κειμένου σε κάθε επίπεδο κάθε επεξεργασμένης εξίσωσης, διατηρώντας το περιεχόμενο κειμένου και τη μαθηματική δομή.

## **Σύντομη Αναφορά**

| Καθήκον | Κύριο API |
| --- | --- |
| Δημιουργία μαθηματικού κειμένου | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Συνδυασμός στοιχείων | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Δημιουργία κλασμάτων | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Προσθήκη εκθέτη ή δείκτη | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Προσθήκη συναρτήσεων | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Προσθήκη ριζών | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Προσθήκη ορίων | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Προσθήκη δεικτών αριστερά | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Προσθήκη αθροίσεων και ολοκληρωμάτων | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Προσθήκη πινάκων | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Προσθήκη πινάκων εξισώσεων | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Προσθήκη οριοθετητών | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Προσθήκη μπαρών και πλαισίων | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Ομαδοποίηση όρων | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **Συχνές Ερωτήσεις**

**Μπορώ να επεξεργαστώ μια υπάρχουσα εξίσωση PowerPoint;**

Ναι. Ανοίξτε την παρουσίαση, εντοπίστε το σχήμα που περιέχει ένα [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), λάβετε το [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), και ενημερώστε τα μαθηματικά μπλοκ σε αυτήν την παράγραφο.

**Αποθηκεύονται οι εξισώσεις ως επεξεργάσιμα μαθηματικά PowerPoint;**

Ναι. Όταν αποθηκεύετε σε PPTX, το Aspose.Slides γράφει την εξίσωση ως επεξεργάσιμο περιεχόμενο Office math.

**Μπορώ να εξάγω εξισώσεις σε LaTeX;**

Ναι. Λάβετε το [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) της εξίσωσης από το [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), και καλέστε το [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) για να τη εξάγετε απευθείας. Για ένα πλήρες παράδειγμα, δείτε το [Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις σε .NET](/slides/el/net/exporting-math-equations/#export-math-equations-to-latex).