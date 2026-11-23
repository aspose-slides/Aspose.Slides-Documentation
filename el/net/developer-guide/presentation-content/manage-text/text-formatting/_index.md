---
title: Μορφοποίηση Κειμένου Παρουσίασης σε .NET
linktitle: Μορφοποίηση Κειμένου
type: docs
weight: 50
url: /el/net/text-formatting/
keywords:
- στοίχιση παραγράφου
- στυλ κειμένου
- φόντο κειμένου
- διαφάνεια κειμένου
- απόσταση χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστημα γραμμής
- ιδιότητα autofit
- άγκυρα πλαισίου κειμένου
- ταμπλοποίηση κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μορφοποιήστε και εφαρμόστε στυλ σε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για .NET. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχιση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για .NET. Καλύπτει χρώματα φόντου, διαφάνεια, απόσταση χαρακτήρων, ιδιότητες γραμματοσειράς, περιστροφή, απόσταση παραγράφων, συμπεριφορά autofit, αγκύρωση κειμένου, στάσεις στηλών και ρυθμίσεις γλώσσας.

Εκτός αν δηλώνεται διαφορετικά, τα παραδείγματα χρησιμοποιούν το [sample.pptx](sample.pptx). Το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα πλαίσιο κειμένου και η πρώτη παράγραφος του περιέχει το κείμενο που φαίνεται παρακάτω. Οι δείκτες διαφάνειας και σχήματος είναι μηδενικής βάσης. Τα παραδείγματα που επιλέγουν έντονες περιοχές χρησιμοποιούν αποτελεσματική μορφοποίηση, συμπεριλαμβανομένης της κληρονομημένης έντονης μορφοποίησης:

![Δείγμα κειμένου](sample_text.png)

Για να βρείτε και να τονίσετε κυριολεκτικό κείμενο ή αντιστοιχίες κανονικής έκφρασης, δείτε το [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/net/search-and-replace-text/).

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο ή το [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) για μεμονωμένες περιοχές κειμένου.

Το παρακάτω παράδειγμα ορίζει ένα ανοιχτό γκρι χρώμα επισήμανσης ως προεπιλογή για την πρώτη παράγραφο. Οι ρητές χρωματικές επιλογές σε μεμονωμένες περιοχές έχουν προτεραιότητα πάνω από αυτήν την προεπιλογή:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ορισμός του χρώματος επισήμανσης για ολόκληρη την παράγραφο.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η γκρι παράγραφος](gray_paragraph.png)

Το παρακάτω παράδειγμα κώδικα επιδεικνύει πώς να ορίσετε το χρώμα φόντου για **περιοχές κειμένου με έντονη γραμματοσειρά**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Ορισμός του χρώματος επισήμανσης για την περιοχή κειμένου.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Οι γκρι περιοχές κειμένου](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) για να ορίσετε τη στοίχιση παραγράφου μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερή, δεξιά, πλήρης κ.ά.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να στοιχίσετε την παράγραφο **στο κέντρο**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ορίστε τη στοίχιση της παραγράφου στο κέντρο.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η στοιχισμένη παράγραφος](aligned_paragraph.png)

## **Στοίχιση Γραμματοσειρών Μέσα σε Γραμμή**

Χρησιμοποιήστε το [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) για κάθετη στοίχιση περιοχών κειμένου διαφορετικών μεγεθών γραμματοσειράς μέσα σε μια γραμμή. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρη την παράγραφο και ελέγχει τη στοίχιση σε κάθε μία από τις γραμμές της.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί τέσσερα ετικεταρισμένα πλαίσια κειμένου σε μια διαφάνεια. Κάθε παράγραφος περιέχει το ίδιο κείμενο με μεγέθη 18, 36 και 54 σημεία, με διαφορετική στοίχιση γραμματοσειράς. Χρησιμοποιεί Arial, απενεργοποιεί το autofit και τη συσπασή, και διατηρεί τα πλαίσια κειμένου αρκετά μεγάλα για μια μόνο γραμμή.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Σύγκριση Στοίχισης Baseline, Top, Center και Bottom με μικτές γραμματοσειρές](font_alignment.png)

Η στοίχιση γραμματοσειράς χρησιμοποιεί μετρικές γραμματοσειράς, έτσι οι ορατές άκρες των μεμονωμένων γραμμάτων δεν ευθυγραμμίζονται απαραίτητα ακριβώς. Το παράδειγμα περιλαμβάνει τόσο κεφαλαίο γράμμα όσο και καθιζόμενο για να δείξει τη διαφορά μεταξύ στοίχισης βάσης και κάτω. Η διαθεσιμότητα και η αντικατάσταση γραμματοσειρών, οι χαρακτήρες που χρησιμοποιούνται και η διαφορά στο μέγεθος γραμματοσειράς επηρεάζουν το αποτέλεσμα. Οι διαστάσεις του πλαισίου, τα περιθώρια, η απόσταση γραμμής, η συσπασία και το autofit επηρεάζουν επίσης τη διάταξη· χρησιμοποιήστε τις ίδιες γραμματοσειρές και ρυθμίσεις διάταξης όταν συγκρίνετε τις λειτουργίες.

Αυτή η ρύθμιση διαφέρει από το [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), το οποίο ελέγχει την οριζόντια στοίχιση παραγραφής, και το [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), το οποίο τοποθετεί το μπλοκ κειμένου κάθετα μέσα στο σχήμα του. Η υπερ- και υπο-σκοπή με τη χρήση του [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) μετατοπίζει μεμονωμένες περιοχές σε σχέση με τη βάση αντί να ορίζει τη στοίχιση γραμματοσειράς για τις γραμμές της παραγράφου.

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του αλφα-συστατικού του χρώματος που έχει ανατεθεί στο [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Στα παραδείγματα παρακάτω, `alpha = 50` είναι μια τιμή αλφα-καναλιού ARGB στην κλίμακα 0–255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια στην **ολόκληρη την παράγραφο**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ορίστε ημιδιαφανή μαύρη γέμιση για το κείμενο.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η διαφανής παράγραφος](transparent_paragraph.png)

Το ακόλουθο παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **περιοχές κειμένου με έντονη γραμματοσειρά**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Ορίστε τη διαφάνεια της περιοχής κειμένου.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Οι διαφανείς περιοχές κειμένου](transparent_text_portions.png)

## **Ορισμός Απόστασης Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε το [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) για να αυξήσετε ή να μειώσετε την απόσταση μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου. Τα παραδείγματα προσθέτουν 3 σημεία απόστασης· οι αρνητικές τιμές μειώνουν το κείμενο.

Το παρακάτω παράδειγμα C# δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων στην **ολόκληρη την παράγραφο**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε την απόσταση χαρακτήρων.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Αυξήστε την απόσταση χαρακτήρων.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η απόσταση χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Το παράδειγμα κώδικα παρακάτω δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων σε **περιοχές κειμένου με έντονη γραμματοσειρά**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε την απόσταση χαρακτήρων.
        portion.PortionFormat.Spacing = 3;  // Αυξήστε την απόσταση χαρακτήρων.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η απόστασης χαρακτήρων στις περιοχές κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδει το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο σφιχτό από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβαίνει επειδή το PowerPoint αγνοεί τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρα δεδομένα kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να προσεγγίσετε το αποτέλεσμα του PowerPoint σε τέτοιες περιπτώσεις, μπορείτε να απενεργοποιήσετε το kerning για περιοχές κειμένου που χρησιμοποιούν την επηρεασμένη γραμματοσειρά. Ορίστε το [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) σε τιμή μεγαλύτερη από το πραγματικό μέγεθος της γραμματοσειράς. Αυτό το παράδειγμα απαιτεί το «presentation.pptx» με πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Ελέγχει τα αποτελεσματικά ονόματα γραμματοσειρών, συμπεριλαμβανομένων των κληρονομημένων, και ορίζει ένα όριο 100 σημεία για περιοχές που χρησιμοποιούν Roboto. Αυτό απενεργοποιεί το kerning για τις περιοχές που έχουν μέγεθος γραμματοσειράς κάτω από 100 σημεία:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Για κείμενο που ταιριάζει κάτω από το όριο, αυτή η ρύθμιση αποτρέπει το kerning και μπορεί να βοηθήσει την απόδοση του Aspose.Slides να ταιριάζει με την οπτική έξοδο του PowerPoint για γραμματοσειρές που επηρεάζονται από αυτήν τη συμπεριφορά του PowerPoint.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν στο επίπεδο παραγράφου μέσω του [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) ή σε μεμονωμένες περιοχές μέσω του [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

Το παρακάτω παράδειγμα ορίζει τη προεπιλεγμένη γραμματοσειρά της πρώτης παραγράφου σε Times New Roman 12 σημεία με έντονη, πλάγια και υπογραμμισμένη με τελείες μορφοποίηση. Η ρητή μορφοποίηση σε μεμονωμένες περιοχές έχει προτεραιότητα πάνω από αυτές τις προεπιλογές:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ορίστε τις ιδιότητες γραμματοσειράς για την παράγραφο.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για την παράγραφο](font_properties_for_paragraph.png)

Το παρακάτω παράδειγμα εφαρμόζει Times New Roman 13 σημεία, πλάγια μορφοποίηση και υπογράμμιση με τελείες σε περιοχές των οποίων η αποτελεσματική μορφοποίηση είναι έντονη:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Ορίστε τις ιδιότητες γραμματοσειράς για την περιοχή κειμένου.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για τις περιοχές κειμένου](font_properties_for_text_portions.png)

## **Έλεγχος Κανονικοποίησης Ύψους Κειμένου**

Χρησιμοποιήστε το [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) όταν αναπαράγετε τυπογραφία προτύπου ή ερευνάτε διαφορές στο ύψος χαρακτήρων. Στο PowerPoint, η ενεργοποίηση της κανονικοποίησης τεντώνει ή συμπιέζει κάθε χαρακτήρα κάθετα ώστε να έχει ομοιόμορφο ορατό ύψος μέσα στην περιοχή κειμένου. Αυτό δεν εγγυάται ίσο ύψος κειμένου μεταξύ διαφορετικών γραμματοσειρών.

Ορίστε την ιδιότητα σε [NullableBool.True ή False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) για ρητή ενεργοποίηση ή απενεργοποίηση της κανονικοποίησης. Το `NullableBool.NotDefined` αφήνει την τοπική ρύθμιση ακαθόριστη ώστε η περιοχή να κληρονομήσει την τιμή της, π.χ., από το [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) της παραγράφου. Δεν σημαίνει `False`. Χρησιμοποιήστε το [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) και διαβάστε το [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) για την επιλυμένη Boolean τιμή.

Το παρακάτω αυτόνομο παράδειγμα απαιτεί την εγκατάσταση του **Arial**. Δημιουργεί δύο μπλοκ κειμένου που περιέχουν τα ίδια κεφαλαία γράμματα, πεζά γράμματα, καθιζόμενα και τονισμένους χαρακτήρες σε 54 σημεία. Και οι δύο παράγραφοι ενεργοποιούν την κανονικοποίηση εξ ορισμού. Η επάνω περιοχή την απενεργοποιεί ρητά· η κάτω κληρονομεί. Οι διαστάσεις του πλαισίου, τα περιθώρια και η απόσταση παραγράφων είναι ίδιες, με τη συσπασία και το autofit απενεργοποιημένα για να διατηρηθεί η σύγκριση συνεπής. Το παράδειγμα εκτυπώνει `False: False` και `NotDefined: True`, έπειτα αποθηκεύει το «text_height_normalization.pptx».

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

Η σύγκριση παρακάτω εξήχθη από την αποθηκευμένη παρουσίαση. Η επάνω σειρά έχει την κανονικοποίηση απενεργοποιημένη (`False`); η κάτω κληρονομεί τη ρυθμισμένη τιμή (`NotDefined` → `True`). Διατηρήστε το Arial εγκατεστημένο για να αναπαράγετε αυτήν την εμφάνιση.

![Κείμενο Arial 54 σημείων με κανονικοποίηση απενεργοποιημένη επάνω και κληρονομημένη ενεργοποιημένη κάτω](text_height_normalization.png)

Η κανονικοποίηση αλλάζει το ύψος του χαρακτήρα χωρίς να αλλάζει την τιμή του [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) που καθορίζει το μέγεθος γραμματοσειράς σε σημεία. Το [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) της παραγράφου ελέγχει την απόσταση γραμμής, ενώ το [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) του πλαισίου κειμένου ελέγχει πώς το κείμενο ή το κοντέινερ του προσαρμόζονται. Αυτές οι ρυθμίσεις εξυπηρετούν διαφορετικούς σκοπούς και μπορούν ανεξάρτητα να επηρεάσουν τη συνολική διάταξη. Για περισσότερα σχετικά με τη μορφοποίηση παραγράφων και την κληρονομικότητα, δείτε το [Διαχείριση Παραγράφου](/slides/el/net/manage-paragraph/).

## **Εφαρμογή και Αφαίρεση Διαγράμματος (Strikethrough)**

Χρησιμοποιήστε το [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) σε μια περιοχή κειμένου για να εμφανίσετε διορθώσεις, ακυρωμένες εκφράσεις ή προγενέστερες τιμές χωρίς να διαγράψετε το αρχικό κείμενο. Ορίστε το σε [TextStrikethroughType.Single ή Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) για μία ή δύο γραμμές διαγράμματος.

Για να αφαιρέσετε το διαγράμμα, ορίστε `TextStrikethroughType.None`. Αυτό απενεργοποιεί ρητά το εφέ, ακόμη και αν η περιβάλλουσα μορφοποίηση το ορίζει. Αντίθετα, το `TextStrikethroughType.NotDefined` αφήνει την τοπική ρύθμιση ακαθόριστη, επιτρέποντας στην περιοχή να κληρονομήσει τη μορφοποίηση, π.χ., από την παράγραφο. Δεν εγγυάται ότι το διαγράμμα έχει αφαιρεθεί. Χρησιμοποιήστε το [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) για να διαβάσετε τη μορφοποίηση που προκύπτει, συμπεριλαμβανομένων των κληρονομημένων τιμών.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί τρεις συγκρίσεις τιμών. Κάθε παράγραφος έχει ξεχωριστές περιοχές για την ετικέτα, την προηγούμενη τιμή και την τρέχουσα τιμή, οπότε μόνο η προηγούμενη τιμή επηρεάζεται. Η πρώτη σειρά εφαρμόζει και στη συνέχεια αφαιρεί το διαγράμμα· οι άλλες σειρές διατηρούν μονό ή διπλό διαγράμμα. Η αλλαγή αυτής της ιδιότητας διατηρεί το κείμενο και τις άλλες μορφοποιήσεις του, συμπεριλαμβανομένης της έντονης προηγούμενης τιμής.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// Εφαρμόστε διαγράμμιση, έπειτα αφαιρέστε τη ρητά από την πρώτη προηγούμενη τιμή.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα, από πάνω προς τα κάτω: χωρίς διαγράμμα, μονό διαγράμμα και διπλό διαγράμμα.

![Προηγούμενες τιμές χωρίς διαγράμμα, με μονό διαγράμμα και με διπλό διαγράμμα](strikethrough.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε το [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) για να ορίσετε μια προκαθορισμένη προσανατολισμό κειμένου μέσα σε ένα σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό κειμένου στο σχήμα σε [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), που περιστρέφει το κείμενο **90 μοίρες αριστερά**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η περιστροφή κειμένου](text_rotation.png)

## **Εμφάνιση Ψηφίων Δίπλα-Δίπλα σε Κάθετο Κείμενο**

Για να διατηρήσετε έναν διψήφιο αριθμό μαζί σε μια κάθετη ιαπωνική ετικέτα, τοποθετήστε και τα δύο ψηφία σε μία περιοχή κειμένου και ορίστε το [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) σε αυτήν την περιοχή. Το παράδειγμα χρησιμοποιεί το [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) και γραμματοσειρά MS Gothic 40 σημείων για και τις δύο ετικέτες. Μόνο η τιμή του [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) που έχει αντιστοιχιστεί στην αριθμητική περιοχή διαφέρει.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

Στο PowerPoint, η αριστερή ετικέτα (`True`) εμφανίζει τα ψηφία όρθια και δίπλα-δίπλα μεταξύ των χαρακτήρων 和 και 年. Η δεξιά ετικέτα (`False`) περιστρέφει το ζεύγος 90 μοίρες δεξιά. Οι γύρω ιαπωνικοί χαρακτήρες παραμένουν όρθιοι και στις δύο ετικέτες.

![Σύγκριση ετικετών ημερομηνίας σε κάθετο κείμενο PowerPoint με ψηφία όρθια στα αριστερά και περιστραμμένα στα δεξιά.](vertical_date.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαίσια Κειμένου**

Χρησιμοποιήστε το [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) για να ορίσετε προσαρμοσμένη γωνία περιστροφής για ένα [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

Το παρακάτω παράδειγμα κώδικα περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιά μέσα στο σχήμα:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η προσαρμοσμένη περιστροφή κειμένου](custom_text_rotation.png)

## **Ορισμός Απόστασης Γραμμής Παραγράφων**

Το Aspose.Slides παρέχει τα [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) και [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) για τον έλεγχο της απόστασης παραγράφου. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε μια θετική τιμή για να καθορίσετε την απόσταση γραμμής ως ποσοστό του ύψους της γραμμής.
* Χρησιμοποιήστε μια αρνητική τιμή για να καθορίσετε την απόσταση γραμμής σε σημεία.

Το παρακάτω παράδειγμα ορίζει την απόσταση εντός της πρώτης παραγράφου σε 200 % του ύψους της γραμμής (διπλή απόσταση):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η απόσταση γραμμής εντός της παραγράφου](line_spacing.png)

## **Έλεγχος Σπασίματος Γραμμής**

Οι κανόνες σπασίματος γραμμής της παραγράφου είναι χρήσιμοι σε στενά μπλοκ κειμένου και παρουσιάσεις που συνδυάζουν Λατινικό και Ανατολικό Ασιατικό κείμενο. Οι παρακάτω ιδιότητες ανήκουν στο [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), οπότε εφαρμόζονται σε ολόκληρη την παράγραφο:

- Το [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) ελέγχει τους κανόνες σπασίματος Λατινικού κειμένου. Σε ανάμιξη κειμένων, η αλλαγή του μπορεί επίσης να αλλάξει το σημείο όπου το γειτονικό Ανατολικό Ασιατικό κείμενο και η στίξη σπώνουν.
- Το [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) ελέγχει τους κανόνες σπασίματος Ανατολικού Ασιατικού κειμένου, συμπεριλαμβανομένων των περιορισμών χαρακτήρων στην αρχή και στο τέλος μιας γραμμής.

Αυτοί οι κανόνες δεν αντικαθιστούν το [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), που ενεργοποιεί αυτόματη συσπασία μέσα σε ένα πλαίσιο κειμένου. Επηρεάζουν τη διάταξη όταν η συσπασία συμβαίνει· δεν εισάγουν χαρακτήρες νέας γραμμής. Ένα ρητό διάλειμμα γραμμής αναγκάζει μια νέα γραμμή στην παράγραφο ανεξάρτητα από το διαθέσιμο πλάτος.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα στενό μπλοκ κειμένου που περιέχει Κινέζικο και Λατινικό κείμενο. Ορίζει και τις δύο ιδιότητες σπασίματος γραμμής ρητά και αποθηκεύει το «line_breaking.pptx». Για πειραματισμό με οποιονδήποτε κανόνα, αλλάξτε την τιμή της ιδιότητας ενώ διατηρείτε τις άλλες ρυθμίσεις σταθερές. Το παράδειγμα χρησιμοποιεί Arial 24 σημεία και SimSun με πλάτος πλαισίου 160 σημείων και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου. Το [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) του πλαισίου κειμένου ορίζεται σε [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) ώστε το μέγεθος κειμένου και οι διαστάσεις του πλαισίου να παραμείνουν σταθερά.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **Έλεγχος Κρεμαστής Στίξης**

Το [IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) επιτρέπει σε επιλέξιμη στίξη να εκτείνεται πέρα από το δεξιό άκρο της γραμμής κειμένου αντί να καταλαμβάνει την επόμενη γραμμή. Εφαρμόζεται σε όλη την παράγραφο και διαφέρει από το κρεμαστικό εσοχή.

Το παρακάτω αυτόνομο παράδειγμα ενεργοποιεί κρεμαστική στίξη σε πλαίσιο κειμένου πλάτους 100 σημεία και αποθηκεύει το «hanging_punctuation.pptx». Με Arial 24 σημεία και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου, η τελική τελεία παραμένει μετά τη λέξη «sentence» και εκτείνεται πέρα από το δεξιό άκρο του κειμένου. Ορίστε την ιδιότητα σε [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) για σύγκριση: με αυτές τις ρυθμίσεις, η τελεία καταλαμβάνει ξεχωριστή γραμμή. Η συσπασία είναι ενεργοποιημένη και το autofit απενεργοποιημένο για να διατηρηθεί το διαθέσιμο πλάτος σταθερό.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

Δεν μπορεί να κρεμάσει κάθε σημάδι στίξης. Οι [συνθήκες γραμματοσειράς και διάταξης που περιγράφονται παραπάνω](#control-line-breaking) ισχύουν επίσης για αυτή τη σύγκριση: η αλλαγή της γραμματοσειράς, του διαθέσιμου πλάτους, των περιθωρίων ή των ρυθμίσεων autofit μπορεί να αφαιρέσει τη διακριτή διαφορά.

## **Ορισμός Τύπου Autofit για Πλαίσια Κειμένου**

Το [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) καθορίζει πώς συμπεριφέρεται το κείμενο όταν ξεπερνά τα όρια του περιέκτη του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο μειώνεται, εκρέει ή το σχήμα προσαρμόζεται αυτόματα. Το παρακάτω παράδειγμα διαμορφώνει το σχήμα ώστε να επεκταθεί για να χωρέσει το κείμενό του και αποθηκεύει το αποτέλεσμα σε «autofit_type.pptx».

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Για να μετρήσετε τις γραμμές μετά την αυτόματη συσπασία και να δείτε πώς η αλλαγή του πλάτους κειμένου ή σχήματος επηρεάζει το αποτέλεσμα, δείτε το [Αρίθμηση Σχεδιασμένων Γραμμών](/slides/el/net/manage-paragraph/). Η αρίθμηση των γραμμών από μόνη της δεν δείχνει εάν το κείμενο ξεχειλίζει από τον περιέκτη του.

## **Ορισμός Άγκυρας Πλαισίων Κειμένου**

Το [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) ορίζει πώς το κείμενο τοποθετείται κάθετα μέσα σε ένα σχήμα, π.χ., στην κορυφή, στη μέση ή στο κάτω μέρος. Το παρακάτω παράδειγμα αγκυρώνει το κείμενο στο κάτω μέρος του πρώτου σχήματος και αποθηκεύει το αποτέλεσμα σε «text_anchor.pptx».

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Ορισμός Ταμπλώσεων Κειμένου**

Χρησιμοποιήστε τα [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) και [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) για να ρυθμίσετε τα ταμπλοκ σε μια παράγραφο. Το παρακάτω παράδειγμα ορίζει το προεπιλεγμένο διάστημα ταμπλό σε 100 σημεία και προσθέτει μια αριστερά στοίχιση ταμπλό στα 30 σημεία. Αυτές οι ρυθμίσεις επηρεάζουν το κείμενο που περιέχει χαρακτήρες ταμπλό.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Τα ταμπλα της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Ελέγχου (Proofing Language)**

Το Aspose.Slides παρέχει το [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), που σας επιτρέπει να ορίσετε τη γλώσσα ελέγχου για μια περιοχή κειμένου. Η γλώσσα ελέγχου καθορίζει τη γλώσσα που χρησιμοποιείται για ορθογραφικό και γραμματικό έλεγχο στο PowerPoint.

Το παρακάτω παράδειγμα απαιτεί το «presentation.pptx» με πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον μία παράγραφο. Αντικαθιστά τα περιεχόμενα της πρώτης παραγράφου με «1。», ορίζει το SimSun ως γραμματοσειρά της και εκχωρεί τη γλώσσα ελέγχου Απλουστευμένου Κινέζικου (`zh-CN`). Αποθηκεύει το αποτέλεσμα σε «proofing_language.pptx»:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// Ορίστε τη γλώσσα ελέγχου σε απλοποιημένα κινέζικα.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **Αντιγραφή Μεταδεδομένων Γλώσσας**

Κατά την αντιγραφή πολύγλωσσου κειμένου από ένα πρότυπο, διατηρήστε τόσο το [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) όσο και το [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/). Το παρακάτω αυτόνομο παράδειγμα δημιουργεί μια πηγή με γλώσσα US English και εναλλακτική γλώσσα Γαλλικά και αντιγράφει το κείμενο και τους ταυτοποιητές σε μια περιοχή σε μια νέα παρουσίαση.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
    // Αν η πηγή δεν έχει εναλλακτική γλώσσα, το null διαγράφει την τιμή στον προορισμό.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Για να δοκιμάσετε πηγή χωρίς εναλλακτική γλώσσα, παραλείψτε την εκχώρηση του `"fr-FR"`. Ο εναλλακτικός ταυτοποιητής γίνεται τότε `null`, και η ίδια δήλωση αντιγραφής διατηρεί την απουσία του χωρίς να εισάγει προεπιλεγμένη τιμή, ακόμη και αν ο προορισμός είχε προηγουμένως ορισμένη εναλλακτική γλώσσα.

Αυτοί οι ταυτοποιητές αποθηκεύουν μεταδεδομένα γλώσσας. Η διατήρησή τους δεν καθορίζει ποιο λεξικό θα επιλέξει το PowerPoint για ορθογραφικό ή γραμματικό έλεγχο.

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε το [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) για να ορίσετε τη προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή δημιουργία μιας παρουσίασης. Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με US English ως προεπιλεγμένη γλώσσα κειμένου, προσθέτει ένα πλαίσιο κειμένου και εκτυπώνει `en-US` για την πρώτη περιοχή κειμένου.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Προσθέστε ένα νέο σχήμα παραλληλογράμμου με κείμενο.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Ελέγξτε τη γλώσσα της πρώτης περιοχής κειμένου.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Ορισμός Προεπιλεγμένου Στυλ Κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε το [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

Το παρακάτω παράδειγμα ορίζει μια γραμματοσειρά 14 σημείων, έντονη, ως προεπιλογή για παραγράφους κορυφής σε μια νέα παρουσίαση και το αποθηκεύει σε «default_text_style.pptx». Το κείμενο μπορεί να κληρονομήσει αυτές τις προεπιλογές εκτός εάν πιο ειδικές μορφοποιήσεις τις παρακάμπτουν.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Λάβετε τη μορφοποίηση παραγράφου πρώτου επιπέδου.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Εξαγωγή Κειμένου με Επίδραση Όλων Κεφαλαίων (All‑Caps)**

Στο PowerPoint, η εφαρμογή του εφέ **All Caps** κάνει το κείμενο να εμφανίζεται σε κεφαλαία στην διαφάνεια ακόμη και αν αρχικά είχε πληκτρολογηθεί με πεζά. Όταν ανακτάτε μια τέτοια περιοχή κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθη. Για να ταιριάζει το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) και μετατρέψτε τη συμβολοσειρά σε κεφαλαία όταν η τιμή είναι `All`.

Αυτό το παράδειγμα απαιτεί το «sample2.pptx» με πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη παράγραφος της πρώτης περιοχής της περιέχει το κείμενο «Hello, Aspose!» με το εφέ All Caps εφαρμοσμένο, όπως φαίνεται παρακάτω.

![Το εφέ All Caps](all_caps_effect.png)

Το παράδειγμα κώδικα παρακάτω δείχνει πώς να εξαγάγετε το κείμενο με το εφέ **All Caps** εφαρμόσμένο:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

Απόδοση:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Συχνές Ερωτήσεις (FAQ)**

**Πώς τροποποιώ το κείμενο σε πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε το κείμενο σε πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Περάστε από τα κελιά και ενημερώστε κάθε κελί μέσω του [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) και τη μορφοποίηση παραγράφου μέσω του [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Πώς εφαρμόζω χρώμα διαβάσματος σε κείμενο σε διαφάνεια PowerPoint;**

Για να εφαρμόσετε χρώμα διαβάσματος σε κείμενο, χρησιμοποιήστε το [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Ορίστε το [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) σε [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) και διαμορφώστε τις στάθμες διαβάσματος, την κατεύθυνση και τη διαφάνεια.

Σχετικό χαρακτηριστικό: [Format text within slides](/slides/el/features/text-formatting/).