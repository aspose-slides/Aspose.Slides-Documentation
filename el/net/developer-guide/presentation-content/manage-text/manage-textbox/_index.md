---
title: Διαχείριση πλαισίων κειμένου σε παρουσιάσεις σε .NET
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
description: "Δημιουργία, αναγνώριση, μορφοποίηση και ενημέρωση πλαισίων κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για .NET."
---
## **Εισαγωγή**

Στο Aspose.Slides για .NET, το κείμενο των διαφανειών αποθηκεύεται σε πλαίσια κειμένου που ανήκουν σε σχήματα. Η διεπαφή [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) αντιπροσωπεύει το πιο συνηθισμένο σχήμα που περιέχει κείμενο και εκθέτει το κείμενό του μέσω της ιδιότητας [IAutoShape.TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Note" %}}

Κάθε αυτόματο σχήμα υλοποιεί το [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/), αλλά δεν είναι κάθε σχήμα αυτόματο σχήμα ή υποστηρίζει πλαίσιο κειμένου. Κατά την επεξεργασία μιας υπάρχουσας παρουσίασης, ελέγξτε ότι ένα σχήμα υλοποιεί το `IAutoShape` πριν αποκτήσετε πρόσβαση στο κείμενό του.

{{% /alert %}}

## **Δημιουργία Πλαισίου Κειμένου σε Διαφάνεια**

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

Οι συντεταγμένες και οι διαστάσεις που περνούν στη μέθοδο [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addautoshape/) μετρώνται σε μονάδες σημείου (points). Η μέθοδος [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/addtextframe/) αρχικοποιεί το πλαίσιο κειμένου με το παρεχόμενο κείμενο.

## **Έλεγχος για Σχήμα Πλαισίου Κειμένου**

Χρησιμοποιήστε την ιδιότητα [AutoShape.IsTextBox](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/istextbox/) για να προσδιορίσετε εάν ένα αυτόματο σχήμα θεωρείται πλαίσιο κειμένου. Αυτό είναι χρήσιμο όταν μια παρουσίαση περιέχει τόσο σχήματα που περιέχουν κείμενο όσο και καθαρά γραφικά αυτόματα σχήματα.

![Ένα πλαίσιο κειμένου και ένα σχήμα](istextbox.png)

Το παρακάτω παράδειγμα επιθεωρεί κάθε αυτόματο σχήμα σε μια παρουσίαση:

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

Ένα πρόσφατα προστιθέν αυτοματοποιημένο σχήμα δεν θεωρείται πλαίσιο κειμένου μέχρι να περιέχει μη κενό κείμενο. Μπορείτε να παρέχετε αυτό το κείμενο μέσω της [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/addtextframe/) ή του [ITextFrame.Text](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/text/). Η προσθήκη ή ανάθεση ενός κενό string αφήνει το `IsTextBox` σε `false`:

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

Οι δύο πρώτες κλήσεις εκτυπώνουν `True`; οι δύο τελευταίες εκτυπώνουν `False`.

## **Εύρεση του Σχήματος που Κατέχει Πλαίσιο Κειμένου**

Ο γενικός κώδικας επεξεργασίας κειμένου μπορεί να λάβει ένα [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) χωρίς να γνωρίζει ποιο αντικείμενο παρουσίασης το περιέχει. Χρησιμοποιήστε την μόνο για ανάγνωση ιδιότητα [ITextFrame.ParentShape](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/parentshape/) για να μεταβείτε πίσω στο κτήτοσα [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/).

Για ένα πλαίσιο κειμένου που ανήκει σε αυτόματο σχήμα ή σε άλλο σχήμα που περιέχει κείμενο, το `ParentShape` περιέχει τον ιδιοκτήτη και το [ITextFrame.ParentCell](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/parentcell/) είναι `null`. Ελέγξτε την επιστρεφόμενη τιμή πριν την προσπελάσετε. Για να εντοπίσετε τόσο ιδιοκτήτες σχήματος όσο και κελιών πίνακα, συμπεριλαμβανομένων των σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/net/search-and-replace-text/).

## **Προσθήκη Στηλών σε Πλαίσιο Κειμένου**

Η ιδιότητα [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/columncount/) χωρίζει το πλαίσιο κειμένου σε στήλες, ενώ το [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/columnspacing/) ορίζει το κενό μεταξύ των στηλών σε points. Και οι δύο ρυθμίσεις ανήκουν στο [ITextFrameFormat](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/) και μπορούν να αλλάξουν μέσω του πλαισίου κειμένου ενός υπάρχοντος πλαισίου κειμένου. Το κείμενο αναδιατάσσεται μεταξύ των στηλών εντός του ίδιου σχήματος· δεν συνεχίζεται σε άλλο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο κειμένου τριών στηλών με 10 points μεταξύ των στηλών, αποθηκεύει την παρουσίαση και διαβάζει τις αποθηκευμένες ρυθμίσεις από το αρχείο εξόδου:

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

## **Εξαγωγή Κειμένου από Ατομικές Στήλες**

Χρησιμοποιήστε το [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/splittextbycolumns/) για να ανακτήσετε το κείμενο που έχει ανατεθεί σε κάθε οπτική στήλη σε ένα υπάρχον πλαίσιο κειμένου. Η μέθοδος επιστρέφει ένα string για κάθε στήλη, με σειρά ανάγνωσης βάσει στήλης. Ένα πλαίσιο κειμένου μιας στήλης παράγει έναν πίνακα με ένα στοιχείο, και μια κενή στήλη αντιπροσωπεύεται από κενό string. Τα strings περιέχουν μόνο απλό κείμενο· η μορφοποίηση σε επίπεδο τμήματος δεν διατηρείται.

Αυτό είναι χρήσιμο όταν χρειάζεται να:

- Εξάγετε το κείμενο διατηρώντας τη σειρά ανάγνωσης βάσει στήλης.
- Καταχωρήσετε ή συγκρίνετε το περιεχόμενο διαφανειών πολλαπλών στηλών.
- Εξάγετε κάθε στήλη σε ξεχωριστό αρχείο, πεδίο βάσης δεδομένων ή άλλο προορισμό.
- Εξετάσετε πώς διανέμεται το κείμενο μετά από αλλαγή του [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/columncount/), του [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/columnspacing/), της γραμματοσειράς ή του μεγέθους του πλαισίου κειμένου.

Η μέθοδος αναφέρει το κείμενο που διανέμεται εντός του τρέχοντος [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/); δεν ρέει αυτόματα το κείμενο μεταξύ διαφορετικών σχημάτων ή πλαισίων κειμένου. Η κατανομή των στηλών μπορεί να εξαρτάται από τις διαθέσιμες γραμματοσειρές και άλλες ρυθμίσεις διάταξης κειμένου, επομένως βεβαιωθείτε ότι οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες όταν είναι σημαντικό να υπάρχουν συνεπή αποτελέσματα.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, βρίσκει το πρώτο αυτόματο σχήμα πολλαπλών στηλών με πλαίσιο κειμένου, διαβάζει τον διαμορφωμένο αριθμό στηλών του και γράφει το κείμενο από κάθε στήλη σε ξεχωριστό αρχείο. Σχήματα που δεν παρέχουν πλαίσιο κειμένου παραλείπονται.

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

## **Ενημέρωση Κειμένου**

Για να ενημερώσετε το κείμενο σε όλη την παρουσίαση, επαναλάβετε τις διαφάνειες και τα σχήματα, επιλέξτε τα αυτόματα σχήματα και, στη συνέχεια, επεξεργαστείτε τα τμήματα κειμένου τους. Η εργασία σε επίπεδο τμήματος σας επιτρέπει να αλλάξετε τόσο το κείμενο όσο και τη μορφοποίηση των χαρακτήρων.

Το παρακάτω παράδειγμα αντικαθιστά κάθε εμφανιζόμενο `years` με `months` σε κείμενο αυτόματου σχήματος και κάνει κάθε επηρεασμένο τμήμα έντονο:

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

Αυτή η διέλευση ενημερώνει το κείμενο μόνο σε αυτόματα σχήματα. Το κείμενο που αποθηκεύεται σε πίνακες, διαγράμματα, SmartArt ή ομαδοποιημένα σχήματα απαιτεί διέλευση των συλλογών αυτών των αντικειμένων.

## **Προσθήκη Πλαισίου Κειμένου με Υπερσύνδεσμο**

Μπορεί να ανατεθεί ένας υπερσύνδεσμος σε συγκεκριμένο τμήμα κειμένου, ώστε μόνο αυτό το κείμενο να λειτουργεί ως κλικ‑able σύνδεσμος. Χρησιμοποιήστε το [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) για να συσχετίσετε το τμήμα με μια εξωτερική διεύθυνση URL.

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

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου κειμένου και ενός κράτησης θέσης κειμένου σε κύρια ή διάταξη διαφάνειας;**

Ένα [placeholder](/slides/el/net/manage-placeholder/) μπορεί να κληρονομήσει τη θέση και τη μορφοποίησή του από μια [master slide](https://reference.aspose.com/slides/el/net/aspose.slides/masterslide/) ή μια [layout slide](https://reference.aspose.com/slides/el/net/aspose.slides/layoutslide/). Ένα κανονικό πλαίσιο κειμένου είναι ένα ανεξάρτητο σχήμα στη διαφάνεια όπου δημιουργήθηκε και δεν αποκτά τη συμπεριφορά κράτησης θέσης όταν αλλάζει η διάταξη.

**Πώς μπορώ να αντικαταστήσω κείμενο χωρίς να αλλάξω το κείμενο σε διαγράμματα, πίνακες ή SmartArt;**

Περιορίστε τη διέλευση σε σχήματα που υλοποιούν το [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/), όπως φαίνεται στο παράδειγμα Ενημέρωση Κειμένου. Τα διαγράμματα, οι πίνακες και το SmartArt αποθηκεύουν το κείμενο στα δικά τους μοντέλα αντικειμένων, επομένως δεν τροποποιούνται από αυτόν τον βρόχο.