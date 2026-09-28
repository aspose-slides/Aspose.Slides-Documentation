---
title: Μορφοποίηση κειμένου παρουσίασης σε .NET
linktitle: Μορφοποίηση κειμένου
type: docs
weight: 50
url: /el/net/text-formatting/
keywords:
- στοίχιση παραγράφου
- στυλ κειμένου
- φόντο κειμένου
- διαφάνεια κειμένου
- διάστημα χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστημα γραμμών
- ιδιότητα αυτόματης προσαρμογής
- άγκυρα πλαισίου κειμένου
- στηλοθέτηση κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μορφοποίηση και στυλιζάρισμα κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για .NET. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχιση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για .NET. Καλύπτει τα χρώματα φόντου, τη διαφάνεια, το διάστημα χαρακτήρων, τις ιδιότητες γραμματοσειράς, την περιστροφή, το διάστημα παραγράφων, τη συμπεριφορά αυτόματης προσαρμογής, την αγκύρωση κειμένου, τις θέσεις στηλοθέτη και τις ρυθμίσεις γλώσσας.

Εκτός αν αναφερθεί διαφορετικά, τα παραδείγματα χρησιμοποιούν το [sample.pptx](sample.pptx). Το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα πλαίσιο κειμένου και η πρώτη του παράγραφος περιέχει το κείμενο που φαίνεται παρακάτω. Οι δείκτες των διαφανειών και των σχημάτων είναι μηδενικής βάσης. Τα παραδείγματα που επιλέγουν έντονες περιοχές χρησιμοποιούν αποτελεσματική μορφοποίηση, συμπεριλαμβανομένης της κληρονομημένης έντονης μορφοποίησης:

![Δείγμα κειμένου](sample_text.png)

Για να βρείτε και να επισήμαντε κυριολεκτικό κείμενο ή αντιστοιχίες κανονικής έκφρασης, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/net/search-and-replace-text/).

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/defaultportionformat/) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο, ή χρησιμοποιήστε το [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/highlightcolor/) για επιμέρους τμήματα κειμένου.

Το παρακάτω παράδειγμα ορίζει μια ανοιχτό-γκρι επισήμανση ως προεπιλεγμένη για την πρώτη παράγραφο. Τα ρητά χρώματα επισήμανσης στα επιμέρους τμήματα έχουν προτεραιότητα έναντι αυτής της προεπιλογής:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ορίστε το χρώμα επισήμανσης για ολόκληρη την παράγραφο.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η γκρι παράγραφος](gray_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **τμήματα κειμένου με έντονη γραμματοσειρά**:

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
        // Ορίστε το χρώμα επισήμανσης για το τμήμα κειμένου.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Τα γκρι τμήματα κειμένου](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.Alignment](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/alignment/) για να ορίσετε την στοίχιση παραγράφου μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερά στοιχισμένη, δεξιά στοιχισμένη, ευθυγραμμισμένη και ούτω καθεξής.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να στοιχίσετε την παράγραφο στο **κέντρο**:

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

![Η ευθυγραμμισμένη παράγραφος](aligned_paragraph.png)

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια κειμένου ελέγχεται μέσω του άλφα συστατικού του χρώματος που έχει οριστεί στο [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/fillformat/). Στα παρακάτω παραδείγματα, `alpha = 50` είναι μια τιμή του καναλιού άλφα ARGB στην κλίμακα 0–255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **ολόκληρη την παράγραφο**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ορίστε ημιδιαφανές μαύρο γέμισμα για το κείμενο.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η διαφανής παράγραφος](transparent_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

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
        // Ορίστε τη διαφάνεια του τμήματος κειμένου.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Τα διαφανή τμήματα κειμένου](transparent_text_portions.png)

## **Ορισμός Διαστήματος Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε το [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/spacing/) για να αυξήσετε ή να περιορίσετε το διάστημα μεταξύ των χαρακτήρων σε ένα πλαίσιο κειμένου. Τα παραδείγματα προσθέτουν 3 μονάδες διάστημα· οι αρνητικές τιμές περιορίζουν το κείμενο.

Ο παρακάτω κώδικας C# δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων στην **ολόκληρη την παράγραφο**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Αυξήστε το διάστημα χαρακτήρων.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

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
        // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
        portion.PortionFormat.Spacing = 3;  // Αυξήστε το διάστημα χαρακτήρων.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στα τμήματα κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδεται από το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο πυκνό από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβαίνει επειδή το PowerPoint μπορεί να αγνοεί τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να φέρετε το παραγόμενο αποτέλεσμα πιο κοντά στο PowerPoint σε τέτοιες περιπτώσεις, μπορείτε να απενεργοποιήσετε το kerning για τμήματα κειμένου που χρησιμοποιούν τη συσχετιζόμενη γραμματοσειρά. Ορίστε το [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/kerningminimalsize/) σε μια τιμή μεγαλύτερη από το πραγματικό μέγεθος γραμματοσωμής. Το παράδειγμα απαιτεί το "presentation.pptx" με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Ελέγχει τα αποτελεσματικά ονόματα γραμματοσειρών, συμπεριλαμβανομένων των κληρονομημένων, και θέτει ένα όριο 100 σημείων για τμήματα που χρησιμοποιούν το Roboto. Αυτό απενεργοποιεί το kerning για τμήματα που ταιριάζουν με μέγεθος γραμματοσειράς κάτω των 100 σημείων:

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

Για κείμενο που ταιριάζει κάτω από το όριο, αυτή η ρύθμιση αποτρέπει το kerning και μπορεί να βοηθήσει στην ευθυγράμμιση της απόδοσης του Aspose.Slides με το οπτικό αποτέλεσμα του PowerPoint για γραμματοσειρές που επηρεάζονται από αυτή τη συμπεριφορά ειδική του PowerPoint.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες της γραμματοσειράς μπορούν να ορισθούν σε επίπεδο παραγράφου μέσω του [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/defaultportionformat/) ή σε μεμονωμένα τμήματα μέσω του [IPortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iportionformat/).

Το παρακάτω παράδειγμα ορίζει τη προεπιλεγμένη γραμματοσειρά της πρώτης παραγράφου σε Times New Roman 12 σημείων με έντονη, πλάγια και υπογράμμιση με τελείες. Η ρητή μορφοποίηση στα επιμέρους τμήματα έχει προτεραιότητα έναντι αυτών των προεπιλογών:

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

Το παρακάτω παράδειγμα εφαρμόζει Times New Roman 13 σημείων, πλάγια μορφοποίηση και υπογράμμιση με τελείες σε τμήματα των οποίων η αποτελεσματική μορφοποίηση είναι έντονη:

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
        // Ορίστε τις ιδιότητες γραμματοσειράς για το τμήμα κειμένου.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για τα τμήματα κειμένου](font_properties_for_text_portions.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε το [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/textverticaltype/) για να ορίσετε μια προ-καθορισμένη προσανατολισμό κειμένου μέσα σε ένα σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό κειμένου στο σχήμα σε [TextVerticalType.Vertical270](https://reference.aspose.com/slides/el/net/aspose.slides/textverticaltype/), που περιστρέφει το κείμενο **90 μοίρες αριστερά**:

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

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαίσια Κειμένου**

Χρησιμοποιήστε το [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/rotationangle/) για να ορίσετε μια προσαρμοσμένη γωνία περιστροφής για ένα [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/).

Το παρακάτω παράδειγμα κώδικα περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιώς μέσα στο σχήμα:

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

## **Ορισμός Διαστήματος Γραμμών για Παραγράφους**

Το Aspose.Slides παρέχει τα [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/spacebefore/) και [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/spacewithin/) για τον έλεγχο του διαστήματος παραγράφων. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να ορίσετε το διάστημα γραμμής ως ποσοστό του ύψους γραμμής.
* Χρησιμοποιήστε αρνητική τιμή για να ορίσετε το διάστημα γραμμής σε μονάδες.

Το παρακάτω παράδειγμα ορίζει το εσωτερικό διάστημα στην πρώτη παράγραφο στο 200% του ύψους γραμμής (διπλό διάστημα):

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

![Το διάστημα γραμμής μέσα στην παράγραφο](line_spacing.png)

## **Έλεγχος Αλλαγής Γραμμής**

Οι κανόνες αλλαγής γραμμής παραγράφου είναι χρήσιμοι σε στενά μπλοκ κειμένου και παρουσιάσεις που συνδυάζουν Λατινικό και Ανατολικοασιατικό κείμενο. Οι παρακάτω ιδιότητες ανήκουν στο [IParagraphFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/), οπότε εφαρμόζονται σε ολόκληρη την παράγραφο:

- Το [LatinLineBreak](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/latinlinebreak/) ελέγχει τους κανόνες αλλαγής γραμμής για το Λατινικό κείμενο. Σε μεικτό κείμενο, η αλλαγή του μπορεί επίσης να αλλάξει πού τυλίγονται τα γειτονικά Ανατολικοασιατικά κείμενα και σημεία στίξης.
- Το [EastAsianLineBreak](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/eastasianlinebreak/) ελέγχει τους κανόνες αλλαγής γραμμής για το Ανατολικοασιατικό κείμενο, συμπεριλαμβανομένων των περιορισμών στους χαρακτήρες στην αρχή και το τέλος μιας γραμμής.

Αυτοί οι κανόνες δεν αντικαθιστούν το [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/wraptext/), που ενεργοποιεί την αυτόματη αναδίπλωση μέσα σε ένα πλαίσιο κειμένου. Επηρεάζουν τη διάταξη όταν γίνεται αναδίπλωση· δεν εισάγουν χαρακτήρες αλλαγής γραμμής. Μία ρητή αλλαγή γραμμής εξαναγκάζει νέα γραμμή μέσα στην παράγραφο ανεξάρτητα από το διαθέσιμο πλάτος.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα στενό μπλοκ κειμένου που περιέχει Κινέζικο και Λατινικό κείμενο. Ορίζει και τις δύο ιδιότητες αλλαγής γραμμής ρητά και αποθηκεύει το "line_breaking.pptx". Για να πειραματιστείτε με κάποιον κανόνα, αλλάξτε την τιμή αυτής της ιδιότητας κρατώντας τις άλλες ρυθμίσεις σταθερές. Το παράδειγμα χρησιμοποιεί Arial 24 σημείων και SimSun με πλάτος πλαισίου 160 σημείων και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου. Το [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/autofittype/) ορίζεται σε [TextAutofitType.None](https://reference.aspose.com/slides/el/net/aspose.slides/textautofittype/) ώστε το μέγεθος κειμένου και διαστάσεις πλαισίου να παραμείνουν σταθερά.

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

## **Έλεγχος Κρεμαστού Στίγματος**

Το [IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/hangingpunctuation/) επιτρέπει σε επιλέξιμα σημεία στίξης να εκτεινόμενοι πέρα από τη δεξιά άκρη της γραμμής κειμένου αντί να καταλαμβάνουν την επόμενη γραμμή. Εφαρμόζεται σε ολόκληρη την παράγραφο και διαφέρει από ένα κρεμαστό εσοχή.

Το παρακάτω αυτόνομο παράδειγμα ενεργοποιεί το κρεμαστό στίγμα σε ένα πλαίσιο κειμένου πλάτους 100 σημείων και αποθηκεύει το "hanging_punctuation.pptx". Με Arial 24 σημείων και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου, η τελική τελεία παραμένει μετά τη λέξη "sentence" και εκτείνεται πέρα από τη δεξιά άκρη του κειμένου. Ορίστε την ιδιότητα σε [NullableBool.False](https://reference.aspose.com/slides/el/net/aspose.slides/nullablebool/) για σύγκριση: με αυτές τις ρυθμίσεις, η τελεία καταλαμβάνει ξεχωριστή γραμμή. Η αναδίπλωση είναι ενεργοποιημένη και η αυτόματη προσαρμογή είναι απενεργοποιημένη ώστε το διαθέσιμο πλάτος να παραμείνει σταθερό.

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

Δεν μπορεί να κρεμάσει κάθε σημείο στίξης. Οι [συνθήκες γραμματοσειράς και διάταξης που περιγράφησαν παραπάνω](#conditions-and-limitations) ισχύουν επίσης για αυτή τη σύγκριση: η αλλαγή της γραμματοσειράς, του διαθέσιμου πλάτους, των περιθωρίων ή των ρυθμίσεων αυτόματης προσαρμογής μπορεί να αφαιρέσει τη οπτική διαφορά.

## **Ορισμός Τύπου Αυτόματης Προσαρμογής για Πλαίσια Κειμένου**

Το [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/autofittype/) καθορίζει πώς συμπεριφέρεται το κείμενο όταν υπερβαίνει τα όρια του περιέκτη του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο θα μειώνεται, θα υπερέχει ή θα αλλάζει αυτόματα το μέγεθος του σχήματος. Το παρακάτω παράδειγμα διαμορφώνει το σχήμα ώστε να αλλάζει μέγεθος ώστε να ταιριάζει στο κείμενό του και αποθηκεύει το αποτέλεσμα στο "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Για να μετρήσετε τις γραμμές μετά την αυτόματη αναδίπλωση και να δείτε πώς το κείμενο ή το πλάτος του σχήματος αλλάζει το αποτέλεσμα, δείτε το [Count Rendered Lines](/slides/el/net/manage-paragraph/). Ο μόνος ο αριθμός γραμμών δεν δείχνει εάν το κείμενο υπερβαίνει το περιεχόμενό του.

## **Ορισμός Άγκωνας Πλαισίων Κειμένου**

Το [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/anchoringtype/) ορίζει πώς τοποθετείται κάθετα το κείμενο μέσα σε ένα σχήμα, π.χ. στην κορυφή, στη μέση ή στο κάτω μέρος. Το παρακάτω παράδειγμα αγκυροβολεί το κείμενο στο κάτω μέρος του πρώτου σχήματος και αποθηκεύει το αποτέλεσμα στο "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Ορισμός Στηλοθέτησης Κειμένου**

Χρησιμοποιήστε τα [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/defaulttabsize/) και [IParagraphFormat.Tabs](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/tabs/) για να ρυθμίσετε τα μέσα στήλης σε μια παράγραφο. Το παρακάτω παράδειγμα ορίζει το προεπιλεγμένο διάστημα στηλοθέτη στα 100 σημεία και προσθέτει μια αριστερά στοιχισμένη θέση στηλοθέτη στα 30 σημεία. Αυτές οι ρυθμίσεις επηρεάζουν το κείμενο που περιέχει χαρακτήρες στηλοθέτη.

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

![Τα στηλοθέτες της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Ελέγχου Ορθογραφίας**

Το Aspose.Slides παρέχει το [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/languageid/), που σας επιτρέπει να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα τμήμα κειμένου. Η γλώσσα ελέγχου ορθογραφίας καθορίζει τη γλώσσα που χρησιμοποιείται για ορθογραφικούς και γραμματικούς ελέγχους στο PowerPoint.

Το παρακάτω παράδειγμα απαιτεί το "presentation.pptx" με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον μία παράγραφο. Αντικαθιστά το περιεχόμενο της πρώτης παραγράφου με "1。", ορίζει το SimSun ως γραμματοσειρά της και ορίζει τη γλώσσα ελέγχου ορθογραφίας Απλοποιημένου κινέζου (`zh-CN`). Αποθηκεύει το αποτέλεσμα στο "proofing_language.pptx":

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

// Ορίστε τη γλώσσα ελέγχου ορθογραφίας σε απλοποιημένα κινέζικα.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε το [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/defaulttextlanguage/) για να ορίσετε τη προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή τη δημιουργία μιας παρουσίασης. Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με αγγλικά ΗΠΑ ως προεπιλεγμένη γλώσσα κειμένου, προσθέτει ένα πλαίσιο κειμένου και εμφανίζει `en-US` για το πρώτο τμήμα κειμένου.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Προσθέστε ένα νέο ορθογώνιο σχήμα με κείμενο.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Ελέγξτε τη γλώσσα του πρώτου τμήματος.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Ορισμός Προεπιλεγμένου Στυλ Κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε το [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/defaulttextstyle/).

Το παρακάτω παράδειγμα ορίζει μια έντονη γραμματοσειρά 14 σημείων ως προεπιλογή για παραγράφους ανώτερου επιπέδου σε μια νέα παρουσίαση και το αποθηκεύει στο "default_text_style.pptx". Το κείμενο μπορεί να κληρονομήσει αυτές τις προεπιλογές εκτός εάν κάποια πιο συγκεκριμένη μορφοποίηση τις αντικαταστήσει.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Λάβετε τη μορφοποίηση παραγράφου του ανώτερου επιπέδου.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Εξαγωγή Κειμένου με το Εφέ Όλων Σε Κεφαλαία**

Στο PowerPoint, η εφαρμογή του εφέ **All Caps** στην γραμματοσειρά κάνει το κείμενο να εμφανίζεται με κεφαλαία γράμματα στη διαφάνεια ακόμη και αν αρχικά πληκτρολογήθηκε με πεζά. Όταν εξάγετε ένα τέτοιο τμήμα κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθη. Για να ταιριάξετε το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/el/net/aspose.slides/textcaptype/) και μετατρέψτε το επιστρεφόμενο string σε κεφαλαία όταν η τιμή είναι `All`.

Το παράδειγμα απαιτεί το "sample2.pptx" με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Το πρώτο τμήμα της πρώτης παραγράφου περιέχει το "Hello, Aspose!" με το εφέ All Caps εφαρμόσμένο, όπως φαίνεται παρακάτω.

![Το εφέ All Caps](all_caps_effect.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε το κείμενο με το εφέ **All Caps** εφαρμοσμένο:

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

Αποτέλεσμα:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Πώς μπορώ να τροποποιήσω κείμενο σε πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε κείμενο σε πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/). Διατρέξτε τα κελιά και ενημερώστε κάθε κελί μέσω του [ICell.TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/icell/textframe/) και τη μορφοποίηση παραγράφων μέσω του [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/paragraphformat/).

**Πώς μπορώ να εφαρμόσω διαβάθμιση χρώματος σε κείμενο σε μια διαφάνεια PowerPoint;**

Για να εφαρμόσετε χρώμα διαβάθμισης σε κείμενο, χρησιμοποιήστε το [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/fillformat/). Ορίστε το [IFillFormat.FillType](https://reference.aspose.com/slides/el/net/aspose.slides/ifillformat/filltype/) σε [FillType.Gradient](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) και διαμορφώστε τα σημεία διαβάθμισης, την κατεύθυνση και τη διαφάνεια.