---
title: Διαμόρφωση Κειμένου Παρουσίασης σε .NET
linktitle: Μορφοποίηση Κειμένου
type: docs
weight: 50
url: /el/net/text-formatting/
keywords:
- επισήμανση κειμένου
- κανονική έκφραση
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
- άγκυρο πλαισίου κειμένου
- στηλοθέτηση κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαμορφώστε και στιλιζάρετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για .NET. Προσαρμότε γραμματοσειρές, χρώματα, στοίχιση και άλλα."
---
## **Επισκόπηση**

Το άρθρο αυτό δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για .NET. Καλύπτει την επισήμανση, τα χρώματα φόντου, τη διαφάνεια, το διάστημα χαρακτήρων, τις ιδιότητες γραμματοσειράς, την περιστροφή, το διάστημα παραγράφων, τη συμπεριφορά αυτόματης προσαρμογής, την αγκύρωση κειμένου, τις στάσεις στηλοθέτη και τις ρυθμίσεις γλώσσας.

Στα παραδείγματα παρακάτω, θα χρησιμοποιήσουμε ένα αρχείο με όνομα "sample.pptx", το οποίο περιέχει ένα μοναδικό πλαίσιο κειμένου στην πρώτη διαφάνεια με το ακόλουθο κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επισήμανση Κειμένου**

Χρησιμοποιήστε τη μέθοδο [ITextFrame.HighlightText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/highlighttext/) όταν χρειάζεται να επισημάνετε κείμενο που ταιριάζει με ένα συγκεκριμένο δείγμα μέσα σε ένα πλαίσιο κειμένου. Η μέθοδος εφαρμόζει ένα χρώμα επισήμανσης στα τμήματα κειμένου που ταιριάζουν και μπορεί να χρησιμοποιηθεί μαζί με το [TextSearchOptions](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/) για να ελέγξει πώς εκτελείται η αναζήτηση, π.χ. ώστε να ταιριάζει μόνο σε ολόκληρες λέξεις.

Το παρακάτω παράδειγμα κώδικα επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και στη συνέχεια επισημαίνει μόνο τη πλήρη λέξη **"to"**.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Λάβετε το πρώτο σχήμα από την πρώτη διαφάνεια.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Επισημάνετε τη λέξη "try" στο σχήμα.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Επισημάνετε τη λέξη "to" στο σχήμα.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο](highlighted_text.png)

## **Επισήμανση Κειμένου Με Χρήση Κανονικών Εκφράσεων**

Η μέθοδος [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/highlightregex/) επισημαίνει ταιριάσματα κειμένου που βρίσκονται με μια κανονική έκφραση. Στο .NET, αυτό το API εκτίθεται στο [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/).

Το παρακάτω παράδειγμα κώδικα επισημαίνει όλες τις λέξεις που περιέχουν **εφτά ή περισσότερους χαρακτήρες**:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // Επισημάνετε όλες τις λέξεις με επτά ή περισσότερους χαρακτήρες.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο με τη χρήση της κανονικής έκφρασης](highlighted_text_using_regex.png)

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/defaultportionformat/) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο, ή το [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/el/net/aspose.slides/iportionformat/highlightcolor/) για μεμονωμένα τμήματα κειμένου.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **όλη την παράγραφο**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Ορίστε το χρώμα επισήμανσης για ολόκληρη την παράγραφο.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Η γκρι παράγραφος](gray_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **τμήματα κειμένου με έντονη γραμματοσειρά**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Το αποτέλεσμα:

![Τα γκρι τμήματα κειμένου](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Χρησιμοποιήστε το [IParagraphFormat.Alignment](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/alignment/) για να ορίσετε την στοίχιση παραγράφου μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερή, δεξιά, στοίχιση και πληθυνόμενη, κ.λπ.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ευθυγραμμίσετε την παράγραφο στο **κέντρο**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Ορίστε την στοίχιση της παραγράφου στο κέντρο.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Η ευθυγραμμισμένη παράγραφος](aligned_paragraph.png)

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του σκέλους άλφα του χρώματος που έχει εκχωρηθεί στο [IPortionFormat.FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iportionformat/fillformat/). Στα παρακάτω παραδείγματα, `alpha = 50` είναι μια τιμή αλφα-καναλιού ARGB στην κλίμακα 0–255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια στην **ολόκληρη παράγραφο**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Ορίστε το χρώμα γεμίσματος του κειμένου σε διαφανές χρώμα.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Η διαφανής παράγραφος](transparent_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Το αποτέλεσμα:

![Τα διαφανή τμήματα κειμένου](transparent_text_portions.png)

## **Ορισμός Διαστημάτων Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε το [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/spacing/) για να αυξήσετε ή να μειώσετε το διάστημα μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου.

Ο παρακάτω κώδικας C# δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων στην **ολόκληρη παράγραφο**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Αυξήστε το διάστημα χαρακτήρων.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στα τμήματα κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδεται από το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο συμπαγές από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβαίνει επειδή το PowerPoint μπορεί να αγνοήσει τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να κάνει η παραγόμενη έξοδος πιο κοντά στο PowerPoint σε τέτοιες περιπτώσεις, μπορείτε να απενεργοποιήσετε το kerning για τμήματα κειμένου που χρησιμοποιούν την επηρεασμένη γραμματοσειρά. Ορίστε το [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/kerningminimalsize/) σε τιμή σημαντικά μεγαλύτερη από το πραγματικό μέγεθος της γραμματοσειράς:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Αυτή η ρύθμιση αποτρέπει την εφαρμογή του kerning σε τμήματα κειμένου που ταιριάζουν και μπορεί να βοηθήσει στην εναρμόνιση της απόδοσης του Aspose.Slides με την οπτική έξοδο του PowerPoint για γραμματοσειρές που επηρεάζονται από αυτήν τη συμπεριφορά ειδική του PowerPoint.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν σε επίπεδο παραγράφου μέσω του [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/defaultportionformat/) ή σε μεμονωμένα τμήματα μέσω του [IPortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iportionformat/).

Ο παρακάτω κώδικας ορίζει τη γραμματοσειρά και το στυλ κειμένου για ολόκληρη την παράγραφο: εφαρμόζει το μέγεθος γραμματοσειράς, έντονο, πλάγιο, υπογράμμιση με τελείες, και τη γραμματοσειρά Times New Roman σε όλα τα τμήματα της παραγράφου.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Ορίστε τις ιδιότητες γραμματοσειράς για την παράγραφο.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για την παράγραφο](font_properties_for_paragraph.png)

Το παρακάτω παράδειγμα κώδικα εφαρμόζει παρόμοιες ιδιότητες σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για τμήματα κειμένου](font_properties_for_text_portions.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε το [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/textverticaltype/) για να ορίσετε μια προκαθορισμένη κατεύθυνση κειμένου μέσα σε ένα σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει την κατεύθυνση κειμένου στο σχήμα σε `Vertical270`, που περιστρέφει το κείμενο **90 μοίρες αριστερόστροφα**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Η περιστροφή του κειμένου](text_rotation.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαίσια Κειμένου**

Χρησιμοποιήστε το [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/rotationangle/) για να ορίσετε μια προσαρμοσμένη γωνία περιστροφής για ένα [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/).

Το παρακάτω παράδειγμα κώδικα περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιόστροφα μέσα στο σχήμα:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Η προσαρμοσμένη περιστροφή κειμένου](custom_text_rotation.png)

## **Ορισμός Διαστήματος Γραμμών για Παραγράφους**

Το Aspose.Slides παρέχει τα [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/spacebefore/), και [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/spacewithin/) για τον έλεγχο του διαστήματος παραγράφων. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να ορίσετε το διάστημα γραμμής ως ποσοστό του ύψους της γραμμής.  
* Χρησιμοποιήστε αρνητική τιμή για να ορίσετε το διάστημα γραμμής σε μονάδες (points).

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το διάστημα γραμμής μέσα στην παράγραφο:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το διάστημα γραμμής μέσα στην παράγραφο](line_spacing.png)

## **Ορισμός Τύπου Αυτόματης Προσαρμογής για Πλαίσια Κειμένου**

Το [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/autofittype/) καθορίζει πώς συμπεριφέρεται το κείμενο όταν υπερβαίνει τα όρια του περιέκτη του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο μειώνεται, υπερχέλιση, ή προσαρμόζει αυτόματα το σχήμα.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Αγκύρωσης Πλαισίων Κειμένου**

Το [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/anchoringtype/) ορίζει πώς το κείμενο τοποθετείται κατακόρυφα μέσα σε ένα σχήμα, π.χ. στην κορυφή, στο κέντρο ή στο κάτω μέρος.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Στηλοθεσίας Κειμένου**

Χρησιμοποιήστε τα [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/defaulttabsize/) και [IParagraphFormat.Tabs](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/tabs/) για να ρυθμίσετε τις στάσεις στηλοθέτη σε μια παράγραφο.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Οι στάσεις στηλοθέτη της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Ελέγχου**

Το Aspose.Slides παρέχει το [IPortionFormat.LanguageId](https://reference.aspose.com/slides/el/net/aspose.slides/iportionformat/languageid/), το οποίο σας επιτρέπει να ορίσετε τη γλώσσα ελέγχου για ένα τμήμα κειμένου. Η γλώσσα ελέγχου καθορίζει τη γλώσσα που χρησιμοποιείται για ορθογραφικό και γραμματικό έλεγχο στο PowerPoint.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε τη γλώσσα ελέγχου για ένα τμήμα κειμένου:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // Ορίστε το Id της γλώσσας ελέγχου.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε το [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/defaulttextlanguage/) για να ορίσετε τη προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή τη δημιουργία παρουσίασης.

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Προσθέστε ένα νέο σχήμα ορθογωνίου με κείμενο.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Ελέγξτε τη γλώσσα του πρώτου τμήματος.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Ορισμός Προεπιλεγμένου Στυλ Κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε το [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/defaulttextstyle/).

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε προεπιλεγμένη έντονη γραμματοσειρά με μέγεθος 14 pt για όλο το κείμενο σε όλες τις διαφάνειες μιας νέας παρουσίασης.

```cs
using (var presentation = new Presentation())
{
    // Λάβετε τη μορφοποίηση παραγράφου του ανώτερου επιπέδου.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Εξαγωγή Κειμένου με το Εφέ Όλων των Κεφαλαίων**

Στο PowerPoint, η εφαρμογή του εφέ All Caps κάνει το κείμενο να εμφανίζεται με κεφαλαία γράμματα στη διαφάνεια ακόμη και αν γράφτηκε αρχικά με πεζά. Όταν εξάγετε ένα τέτοιο τμήμα κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθη. Για να ταιριάξετε το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/el/net/aspose.slides/textcaptype/) και μετατρέψτε τη επιστρεφόμενη συμβολοσειρά σε κεφαλαία όταν η τιμή είναι `All`.

Ας υποθέσουμε ότι έχουμε το παρακάτω πλαίσιο κειμένου στην πρώτη διαφάνεια του αρχείου sample2.pptx.

![Το εφέ Όλων των Κεφαλαίων](all_caps_effect.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε το κείμενο με το εφαρμοσμένο εφέ All Caps:

```cs
using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Συχνές Ερωτήσεις**

**Πώς να τροποποιήσετε το κείμενο σε έναν πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε το κείμενο σε έναν πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/). Επανάληψη μέσω των κελιών και ενημέρωση κάθε κελιού μέσω του [ICell.TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/icell/textframe/) και μορφοποίηση παραγράφων μέσω του [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/paragraphformat/).

**Πώς να εφαρμόσετε χρώμα διαβάθμισης σε κείμενο σε μια διαφάνεια PowerPoint;**

Για να εφαρμόσετε χρώμα διαβάθμισης σε κείμενο, χρησιμοποιήστε το [IPortionFormat.FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iportionformat/fillformat/). Ορίστε το [IFillFormat.FillType](https://reference.aspose.com/slides/el/net/aspose.slides/ifillformat/filltype/) σε [FillType.Gradient](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) και ρυθμίστε τα σημεία διαβάθμισης, την κατεύθυνση και τη διαφάνεια.