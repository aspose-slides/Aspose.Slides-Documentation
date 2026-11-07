---
title: Διαχείριση πλαισίων κειμένου σε παρουσιάσεις .NET
linktitle: Διαχείριση πλαισίου κειμένου
type: docs
weight: 20
url: /el/net/manage-textbox/
keywords:
- πλαίσιο κειμένου
- πλαίσιο κειμένου
- προσθήκη κειμένου
- ενημέρωση κειμένου
- δημιουργία πλαισίου κειμένου
- έλεγχος πλαισίου κειμένου
- προσθήκη στήλης κειμένου
- προσθήκη υπερσύνδεσμου
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε, εντοπίστε, μορφοποιήστε και ενημερώστε πλαίσια κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για .NET."
---
## **Εισαγωγή**

Στο Aspose.Slides για .NET, το κείμενο της διαφάνειας αποθηκεύεται σε πλαίσια κειμένου που ανήκουν σε σχήματα. Η διεπαφή [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) αντιπροσωπεύει το πιο συνηθισμένο σχήμα που φέρει κείμενο και εκθέτει το κείμενό του μέσω της ιδιότητας [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Note" %}}
Κάθε αυτόματο σχήμα υλοποιεί το [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), αλλά δεν είναι κάθε σχήμα αυτόματο σχήμα ή υποστηρίζει πλαίσιο κειμένου. Κατά την επεξεργασία μιας υπάρχουσας παρουσίασης, ελέγξτε ότι ένα σχήμα υλοποιεί `IAutoShape` πριν αποκτήσετε πρόσβαση στο κείμενό του.
{{% /alert %}}

## **Δημιουργία πλαισίου κειμένου σε διαφάνεια**

Για να δημιουργήσετε ένα πλαίσιο κειμένου, προσθέστε ένα αυτόματο σχήμα σε μια διαφάνεια, προσθέστε κείμενο στο πλαίσιο κειμένου του και αποθηκεύστε την παρουσίαση. Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο πλαίσιο κειμένου:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Οι συντεταγμένες και οι διαστάσεις που περνούν στη μέθοδο [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) μετρώνται σε σημεία. Η μέθοδος [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) αρχικοποιεί το πλαίσιο κειμένου με το παρεχόμενο κείμενο.

## **Έλεγχος για σχήμα πλαισίου κειμένου**

Χρησιμοποιήστε την ιδιότητα [AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) για να προσδιορίσετε εάν ένα αυτόματο σχήμα αντιμετωπίζεται ως πλαίσιο κειμένου. Αυτό είναι χρήσιμο όταν μια παρουσίαση περιέχει τόσο σχήματα που φέρουν κείμενο όσο και καθαρά γραφικά αυτόματα σχήματα.

![Πλαίσιο κειμένου και σχήμα](istextbox.png)

Το παρακάτω παράδειγμα εξετάζει κάθε αυτόματο σχήμα σε μια παρουσίαση:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

Ένα νεοπροστέθηκε αυτόματο σχήμα δεν θεωρείται πλαίσιο κειμένου μέχρι να περιέχει μη κενό κείμενο. Μπορείτε να παρέχετε αυτό το κείμενο μέσω της [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) ή του [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/). Η προσθήκη ή η ανάθεση ενός κενό string αφήνει την ιδιότητα `IsTextBox` στο `false`:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

Οι πρώτες δύο κλήσεις εκτυπώνουν `True`; οι τελευταίες δύο εκτυπώνουν `False`.

## **Εύρεση του σχήματος που κατέχει ένα πλαίσιο κειμένου**

Η γενική κώδικας επεξεργασίας κειμένου μπορεί να λάβει ένα [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) χωρίς να γνωρίζει ποιο αντικείμενο παρουσίασης το περιέχει. Χρησιμοποιήστε την ιδιότητα μόνο για ανάγνωση [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) για να πλοηγηθείτε πίσω στο ιδιοκτητικό [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/).

Για ένα πλαίσιο κειμένου που ανήκει σε αυτόματο σχήμα ή σε κάποιο άλλο σχήμα που φέρει κείμενο, το `ParentShape` περιέχει τον κάτοχο και το [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) είναι `null`. Ελέγξτε την επιστρεφόμενη τιμή πριν την προσπελάσετε. Για την αναγνώριση τόσο των σχημάτων όσο και των ιδιοκτητών κελιών πίνακα, συμπεριλαμβανομένων των σχημάτων που συνδέονται με κόμβους SmartArt, δείτε το [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/net/search-and-replace-text/).

## **Λήψη του ορθογωνίου κειμένου του σχήματος**

Από την έκδοση Aspose.Slides για .NET 26.11, η μέθοδος [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) επιστρέφει την περιοχή κειμένου που ορίζεται από τη γεωμετρία του γονικού σχήματος. Οι συντεταγμένες και οι διαστάσεις της είναι σε σημεία, σε σχέση με την πάνω αριστερή γωνία του σχήματος. Για παράδειγμα, μια έλλειψη έχει μικρότερο ορθογώνιο κειμένου από τα εξωτερικά της όρια.

Αυτό το ορθογώνιο περιγράφει το σχήμα, όχι τους αποδομένους χαρακτήρες. Η αλλαγή του κειμένου ή των περιθωρίων του πλαισίου κειμένου δεν το μετατρέπει σε μέτρηση του καταληφθέντος κειμένου. Χρησιμοποιήστε τα [όρια παραγράφου](/slides/el/net/paragraph-bounds/) ή τα [όρια τμήματος](/slides/el/net/portion-bounds/) για μετρήσεις του αποδομένου κειμένου.

Μετά την [εγκατάσταση Aspose.Slides για .NET](/slides/el/net/installation/) 26.11 ή μεταγενέστερη, εκτελέστε αυτό το παράδειγμα για να σχεδιάσετε το ορθογώνιο κειμένου της γεωμετρίας σε κόκκινο. Τα σχήματα είναι χωρίς περιστροφή και χωρίς ομαδοποίηση, έτσι η προσθήκη της θέσης X/Y τους είναι επαρκής για την τοποθέτηση της επικάλυψης στη διαφάνεια.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

Για τα σχήματα 200 × 100 σημεία που φαίνονται πιο πάνω, το ορθογώνιο επιστρέφει `(0, 0, 200, 100)`· η έλλειψη επιστρέφει περίπου `(29.289, 14.645, 141.421, 70.711)`. Η μέθοδος διαβάζει επίσης το δηλωμένο ορθογώνιο κειμένου μιας προσαρμοσμένης γεωμετρίας. Δεν εφαρμόζει την περιστροφή του διαφάνειας ή τις μετασχηματισμούς ομάδας· λάβετε αυτά υπόψη χωριστά όταν τοποθετείτε μια επικάλυψη. Ένα πλαίσιο κειμένου χωρίς σχήμα γεωμετρίας, όπως ένα πλαίσιο κειμένου κελιού πίνακα, μπορεί να ρίξει `InvalidOperationException`.

## **Προσθήκη στηλών σε πλαίσιο κειμένου**

Η ιδιότητα [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) διαιρεί το πλαίσιο κειμένου σε στήλες, ενώ η [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) ορίζει το κενό μεταξύ των στηλών σε σημεία. Και οι δύο ρυθμίσεις ανήκουν στο [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) και μπορούν να αλλάξουν μέσω του πλαισίου κειμένου ενός υπάρχοντος πλαισίου κειμένου. Το κείμενο αναδιατάσσεται μεταξύ των στηλών στο ίδιο σχήμα· δεν συνεχίζεται σε άλλο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο κειμένου τριών στηλών με 10 σημεία μεταξύ των στηλών, αποθηκεύει την παρουσίαση και διαβάζει τις αποθηκευμένες ρυθμίσεις από το αρχείο εξόδου:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **Εξαγωγή κειμένου από μεμονωμένες στήλες**

Χρησιμοποιήστε το [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) για να αποδώσετε το κείμενο που έχει εκχωρηθεί σε κάθε οπτική στήλη σε ένα υπάρχον πλαίσιο κειμένου. Η μέθοδος επιστρέφει ένα string για κάθε στήλη, με σειρά ανάγνωσης βάσει στηλών. Ένα πλαίσιο κειμένου μίας στήλης παράγει έναν πίνακα με ένα στοιχείο, και μια κενή στήλη αντιπροσωπεύεται από κενό string. Τα strings περιέχουν μόνο απλό κείμενο· η μορφοποίηση επιπέδου τμήματος δεν διατηρείται.

Αυτό είναι χρήσιμο όταν χρειάζεται να:
- Εξαγωγή κειμένου διατηρώντας την σειρά ανάγνωσης βάσει στηλών.
- Καταχώριση ή σύγκριση του περιεχομένου των διαφανειών πολλαπλών στηλών.
- Εξαγωγή κάθε στήλης σε ξεχωριστό αρχείο, πεδίο βάσης δεδομένων ή άλλο προορισμό.
- Επιθεώρηση του πώς το κείμενο αναδιανέμεται μετά την αλλαγή των [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/), της γραμματοσειράς ή του μεγέθους του πλαισίου κειμένου.

Η μέθοδος αναφέρει το κείμενο που διανέμεται εντός του τρέχοντος [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/); δεν ρέει αυτόματα το κείμενο μεταξύ ξεχωριστών σχημάτων ή πλαισίων κειμένου. Η κατανομή στηλών μπορεί να εξαρτάται από τις διαθέσιμες γραμματοσειρές και άλλες ρυθμίσεις διάταξης κειμένου, επομένως βεβαιωθείτε ότι οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες όταν απαιτούνται συνεπή αποτελέσματα.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, βρίσκει το πρώτο αυτόματο σχήμα πολλαπλών στηλών με πλαίσιο κειμένου, διαβάζει τον ρυθμισμένο αριθμό στηλών και γράφει το κείμενο από κάθε στήλη σε ξεχωριστό αρχείο. Τα σχήματα που δεν παρέχουν πλαίσιο κειμένου παραλείπονται.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **Ενημέρωση κειμένου**

Για να ενημερώσετε το κείμενο σε όλη την παρουσίαση, επαναλάβετε τις διαφάνειες και τα σχήματα, επιλέξτε αυτόματα σχήματα και, στη συνέχεια, επεξεργαστείτε τα τμήματά τους. Η εργασία σε επίπεδο τμήματος σας επιτρέπει να αλλάξετε τόσο το κείμενο όσο και τη μορφοποίηση χαρακτήρων.

Το παρακάτω παράδειγμα αντικαθιστά κάθε εμφάνιση του `years` με `months` στο κείμενο των αυτόματων σχημάτων και κάνει κάθε επηρεαζόμενο τμήμα έντονο:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

Αυτή η διασχίση ενημερώνει το κείμενο μόνο σε αυτόματα σχήματα. Το κείμενο που αποθηκεύεται σε πίνακες, γραφήματα, SmartArt ή ομαδοποιημένα σχήματα απαιτεί διασχίση των δικών τους συλλογών.

## **Προσθήκη πλαισίου κειμένου με υπερσύνδεσμο**

Μπορεί να ανατεθεί ένας υπερσύνδεσμος σε ένα συγκεκριμένο τμήμα κειμένου, ώστε μόνο αυτό το κείμενο να λειτουργεί ως κλικ-σύνδεσμος. Χρησιμοποιήστε το [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) για να συσχετίσετε το τμήμα με ένα εξωτερικό URL.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με σύνδεσμο και το αποθηκεύει σε μια παρουσίαση:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου κειμένου και ενός κράτηματος κειμένου σε κύρια ή διαφάνεια διάταξης;**

Ένα [κράτημα](/slides/el/net/manage-placeholder/) μπορεί να κληρονομήσει τη θέση και τη μορφοποίησή του από μια [κύρια διαφάνεια](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) ή μια [διαφάνεια διάταξης](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/). Ένα κανονικό πλαίσιο κειμένου είναι ένα ανεξάρτητο σχήμα στη διαφάνεια όπου δημιουργήθηκε και δεν αποκτά τη συμπεριφορά του κράτηματος όταν αλλάζει η διάταξη.

**Πώς μπορώ να αντικαταστήσω κείμενο χωρίς να αλλάξω το κείμενο σε γραφήματα, πίνακες ή SmartArt;**

Περιορίστε τη διασχίση στα σχήματα που υλοποιούν το [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), όπως φαίνεται στο παράδειγμα Ενημέρωση κειμένου. Τα γραφήματα, οι πίνακες και το SmartArt αποθηκεύουν το κείμενο στα δικά τους μοντέλα αντικειμένων, επομένως δεν τροποποιούνται από αυτόν τον βρόχο.