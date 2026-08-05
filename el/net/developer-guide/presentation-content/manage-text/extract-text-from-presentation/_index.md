---
title: Προηγμένη Εξαγωγή Κειμένου από Παρουσιάσεις σε .NET
linktitle: Εξαγωγή Κειμένου
type: docs
weight: 90
url: /el/net/extract-text-from-presentation/
aliases:
  - /net/διαφάνειες-σε-πλατφόρμες-σύννευσης/εξαγωγή-κειμένου/επισκόπηση/
  - /net/διαφάνειες-σύννευ-πλατφόρμες/εξαγωγή-κειμένου/διαφάνειες/
keywords:
- εξαγωγή κειμένου
- εξαγωγή κειμένου από διαφάνεια
- εξαγωγή κειμένου από παρουσίαση
- εξαγωγή κειμένου από PowerPoint
- εξαγωγή κειμένου από OpenDocument
- εξαγωγή κειμένου από PPT
- εξαγωγή κειμένου από PPTX
- εξαγωγή κειμένου από ODP
- ανάκτηση κειμένου
- ανάκτηση κειμένου από διαφάνεια
- ανάκτηση κειμένου από παρουσίαση
- ανάκτηση κειμένου από PowerPoint
- ανάκτηση κειμένου από OpenDocument
- ανάκτηση κειμένου από PPT
- ανάκτηση κειμένου από PPTX
- ανάκτηση κειμένου από ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εξαγάγετε γρήγορα κείμενο από παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για .NET. Ακολουθήστε τον απλό, βήμα-βήμα οδηγό μας για να εξοικονομήσετε χρόνο."
---
## **Επισκόπηση**

Η εξαγωγή κειμένου από παρουσιάσεις είναι μια κοινή αλλά ουσιώδης εργασία για προγραμματιστές που εργάζονται με περιεχόμενο διαφανειών. Είτε ασχολείστε με αρχεία Microsoft PowerPoint σε μορφή PPT ή PPTX, είτε με παρουσιάσεις OpenDocument (ODP), η πρόσβαση και η ανάκτηση κειμενικών δεδομένων μπορεί να είναι κρίσιμη για ανάλυση, αυτοματοποίηση, δεικτοδότηση ή σκοπούς μεταφοράς περιεχομένου.

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό σχετικά με το πώς να εξάγετε αποδοτικά κείμενο από διάφορες μορφές παρουσιάσεων, συμπεριλαμβανομένων των PPT, PPTX και ODP, χρησιμοποιώντας το Aspose.Slides for .NET. Θα μάθετε πώς να διατρέχετε συστηματικά τα στοιχεία της παρουσίασης για να ανακτήσετε με ακρίβεια το κείμενο που χρειάζεστε.

## **Εξαγωγή Κειμένου από Διαφάνεια**

Το Aspose.Slides for .NET παρέχει το χώρο ονομάτων [Aspose.Slides.Util](https://reference.aspose.com/slides/el/net/aspose.slides.util/) που περιλαμβάνει την κλάση [SlideUtil](https://reference.aspose.com/slides/el/net/aspose.slides.util/slideutil/). Αυτή η κλάση εκθέτει αρκετές υπερφορτωμένες στατικές μεθόδους για την εξαγωγή όλου του κειμένου από μια παρουσίαση ή διαφάνεια. Για να εξάγετε κείμενο από μία διαφάνεια σε μια παρουσίαση, χρησιμοποιήστε τη μέθοδο [GetAllTextBoxes](https://reference.aspose.com/slides/el/net/aspose.slides.util/slideutil/getalltextboxes/). Αυτή η μέθοδος δέχεται ένα αντικείμενο τύπου [IBaseSlide](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/) ως παράμετρο. Κατά την εκτέλεση, η μέθοδος σαρώει ολόκληρη τη διαφάνεια για κείμενο και επιστρέφει έναν πίνακα αντικειμένων τύπου [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/), διατηρώντας οποιαδήποτε μορφοποίηση κειμένου.

Το παρακάτω απόσπασμα κώδικα εξάγει όλο το κείμενο από την πρώτη διαφάνεια της παρουσίασης:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Εξαγωγή Κειμένου από Παρουσίαση**

Για να σαρώσετε κείμενο από ολόκληρη την παρουσίαση, χρησιμοποιήστε τη static μέθοδο [GetAllTextFrames](https://reference.aspose.com/slides/el/net/aspose.slides.util/slideutil/getalltextframes/) που εκτίθεται από την κλάση [SlideUtil](https://reference.aspose.com/slides/el/net/aspose.slides.util/slideutil/). Δέχεται δύο παραμέτρους:

1. Πρώτα, ένα αντικείμενο [IPresentation](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/) που αντιπροσωπεύει μια παρουσίαση PowerPoint ή OpenDocument από την οποία θα εξαχθεί το κείμενο.
1. Δεύτερα, μια τιμή `Boolean` που υποδεικνύει αν θα συμπεριληφθούν οι κύριες διαφάνειες (master slides) κατά την σάρωση του κειμένου από την παρουσίαση.

Η μέθοδος επιστρέφει έναν πίνακα αντικειμένων τύπου [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/), περιλαμβάνοντας πληροφορίες μορφοποίησης κειμένου. Ο κώδικας παρακάτω σαρώει το κείμενο και τις λεπτομέρειες μορφοποίησης από μια παρουσίαση, συμπεριλαμβανομένων των κύριων διαφανειών:

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Κατηγοριοποιημένη και Γρήγορη Εξαγωγή Κειμένου**

Η κλάση [PresentationFactory](https://reference.aspose.com/slides/el/net/aspose.slides/presentationfactory/) παρέχει επίσης μεθόδους για την εξαγωγή όλου του κειμένου από παρουσιάσεις:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

Το enum argument [TextExtractionArrangingMode](https://reference.aspose.com/slides/el/net/aspose.slides/textextractionarrangingmode/) υποδεικνύει τη λειτουργία οργάνωσης του αποτελέσματος εξαγωγής κειμένου και μπορεί να οριστεί στις ακόλουθες τιμές:
- `Unarranged` - Το ακατέργαστο κείμενο χωρίς να λαμβάνεται υπόψη η θέση του στη διαφάνεια.
- `Arranged` - Το κείμενο οργανώνεται στην ίδια σειρά όπως εμφανίζεται στη διαφάνεια.

Η λειτουργία Unarranged μπορεί να χρησιμοποιηθεί όταν η ταχύτητα είναι κρίσιμη· είναι γρηγορότερη από τη λειτουργία Arranged.

[IPresentationText](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationtext/) αντιπροσωπεύει το ακατέργαστο κείμενο που εξήχθη από την παρουσίαση. Η ιδιότητα `SlidesText` του επιστρέφει έναν πίνακα αντικειμένων τύπου [ISlideText](https://reference.aspose.com/slides/el/net/aspose.slides/islidetext/). Κάθε αντικείμενο αντιπροσωπεύει το κείμενο της αντίστοιχης διαφάνειας. Το αντικείμενο τύπου [ISlideText](https://reference.aspose.com/slides/el/net/aspose.slides/islidetext/) διαθέτει τις παρακάτω ιδιότητες:

- `Text` - Το κείμενο μέσα στα σχήματα της διαφάνειας.
- `MasterText` - Το κείμενο μέσα στα σχήματα της κύριας (master) διαφάνειας που σχετίζονται με αυτή τη διαφάνεια.
- `LayoutText` - Το κείμενο μέσα στα σχήματα της διαφάνειας διάταξης (layout) που σχετίζονται με αυτή τη διαφάνεια.
- `NotesText` - Το κείμενο μέσα στα σχήματα της διαφάνειας σημειώσεων που σχετίζονται με αυτή τη διαφάνεια.
- `CommentsText` - Το κείμενο μέσα στα σχόλια που σχετίζονται με αυτή τη διαφάνεια.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **Συχνές Ερωτήσεις**

**Πόσο γρήγορα επεξεργάζεται το Aspose.Slides μεγάλες παρουσιάσεις κατά την εξαγωγή κειμένου;**

Το Aspose.Slides έχει βελτιστοποιηθεί για υψηλή απόδοση και μπορεί να επεξεργαστεί ακόμη και [μεγάλες παρουσιάσεις](/slides/el/net/open-presentation/), καθιστώντας το κατάλληλο για σενάρια επεξεργασίας σε πραγματικό χρόνο ή μαζικής επεξεργασίας.

**Μπορεί το Aspose.Slides να εξάγει κείμενο από πίνακες και γραφήματα μέσα σε παρουσιάσεις;**

Ναι. Το Aspose.Slides μπορεί να εξάγει κείμενο από πολλά στοιχεία διαφάνειας, συμπεριλαμβανομένων πινάκων και αντικειμένων που σχετίζονται με γραφήματα, ώστε να μπορείτε να έχετε πρόσβαση και να αναλύετε το κειμενικό περιεχόμενο σε κοινές δομές παρουσίασης.

**Χρειάζομαι ειδική άδεια Aspose.Slides για την εξαγωγή κειμένου από παρουσιάσεις;**

Μπορείτε να εξάγετε κείμενο χρησιμοποιώντας τη δωρεάν δοκιμαστική έκδοση του Aspose.Slides, αν και θα έχει [ορισμένους περιορισμούς](/slides/el/net/licensing/), όπως επεξεργασία μόνο περιορισμένου αριθμού διαφανειών. Για απεριόριστη χρήση και για να διαχειριστείτε μεγαλύτερες παρουσιάσεις, συνιστάται η αγορά πλήρους άδειας.