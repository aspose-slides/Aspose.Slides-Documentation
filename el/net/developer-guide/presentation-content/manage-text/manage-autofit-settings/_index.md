---
title: Βελτιώστε τις Παρουσιάσεις σας με το AutoFit στο .NET
linktitle: Ρυθμίσεις Autofit
type: docs
weight: 30
url: /el/net/manage-autofit-settings/
keywords:
- πεδίο κειμένου
- αυτόματη προσαρμογή
- μη αυτόματη προσαρμογή
- προσαρμογή κειμένου
- συρρίκνωση κειμένου
- αναδίπλωση κειμένου
- αλλαγή μεγέθους σχήματος
- PowerPoint
- παρουσίαση
- C#
- .NET
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις ρυθμίσεις AutoFit στο Aspose.Slides για .NET ώστε να βελτιστοποιήσετε την προβολή κειμένου στις παρουσιάσεις PowerPoint και OpenDocument και να βελτιώσετε την αναγνωσιμότητα του περιεχομένου."
---
## **Εισαγωγή**

Από προεπιλογή, όταν προσθέτετε ένα πεδίο κειμένου, το Microsoft PowerPoint χρησιμοποιεί τη ρύθμιση **Resize shape to fit text**· το πεδίο κειμένου προσαρμόζεται αυτόματα ώστε το κείμενο του να χωράει πάντα.

![Ένα πεδίο κειμένου στο PowerPoint](textbox-in-powerpoint.png)

* Όταν το κείμενο στο πεδίο κειμένου γίνεται πιο μακρύ ή μεγαλύτερο, το PowerPoint αυξάνει αυτόματα το ύψος του πεδίου κειμένου ώστε να χωρέσει περισσότερο κείμενο.
* Όταν το κείμενο στο πεδίο κειμένου γίνεται πιο σύντομο ή μικρότερο, το PowerPoint μειώνει αυτόματα το ύψος του πεδίου κειμένου για να αφαιρέσει περιττό χώρο.

Στο PowerPoint, αυτές είναι οι τέσσερις σημαντικές παράμετροι ή επιλογές που ελέγχουν τη συμπεριφορά autofit για ένα πεδίο κειμένου:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![Επιλογές Autofit στο PowerPoint](autofit-options-powerpoint.png)

Το Aspose.Slides for .NET παρέχει παρόμοιες επιλογές—ιδιότητες στην κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat)—που σας επιτρέπουν να ελέγχετε τη συμπεριφορά autofit για πεδία κειμένου σε παρουσιάσεις.

## **Resize a Shape to Fit Text**

Αν θέλετε το κείμενο σε ένα πλαίσιο να ταιριάζει πάντα στο πλαίσιο μετά από αλλαγές, πρέπει να χρησιμοποιήσετε την επιλογή **Resize shape to fit text**. Για να καθορίσετε αυτήν τη ρύθμιση, ορίστε την ιδιότητα `AutofitType` της κλάσης [TextFrameFormat](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat) σε `Shape`.

![Resize shape to fit text](alwaysfit-setting-powerpoint.png)

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε ότι το κείμενο πρέπει πάντα να ταιριάζει στο πλαίσιο του σε μια παρουσίαση PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

Αν το κείμενο γίνει πιο μακρύ ή μεγαλύτερο, το πεδίο κειμένου θα προσαρμοστεί αυτόματα (αύξηση ύψους) ώστε όλο το κείμενο να χωράει. Αν το κείμενο γίνει πιο σύντομο, συμβαίνει το αντίστροφο.

## **Do Not Autofit**

Αν θέλετε ένα πεδίο κειμένου ή σχήμα να διατηρεί τις διαστάσεις του ανεξάρτητα από τις αλλαγές στο κείμενο, πρέπει να χρησιμοποιήσετε την επιλογή **Do not Autofit**. Για να καθορίσετε αυτήν τη ρύθμιση, ορίστε την ιδιότητα `AutofitType` της κλάσης [TextFrameFormat](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat) σε `None`.

!["Do not Autofit" setting in PowerPoint](donotautofit-setting-powerpoint.png)

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε ότι ένα πεδίο κειμένου πρέπει πάντα να διατηρεί τις διαστάσεις του σε μια παρουσίαση PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

Όταν το κείμενο γίνει πολύ μακρύ για το πλαίσιο του, θα υπερχειλίσει.

## **Shrink Text on Overflow**

Αν το κείμενο γίνει πολύ μακρύ για το πλαίσιο, με την επιλογή **Shrink text on overflow** μπορείτε να ορίσετε ότι το μέγεθος και το διάστημα του κειμένου πρέπει να μειωθούν ώστε να ταιριάζει. Για να καθορίσετε αυτήν τη ρύθμιση, ορίστε την ιδιότητα `AutofitType` της κλάσης [TextFrameFormat](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat) σε `Normal`.

!["Shrink text on overflow" setting in PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε ότι το κείμενο πρέπει να μειώνεται όταν υπερχειλίζει σε μια παρουσίαση PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Info" color="info" %}}
Όταν χρησιμοποιείται η επιλογή **Shrink text on overflow**, η ρύθμιση εφαρμόζεται μόνο όταν το κείμενο γίνει πολύ μακρύ για το πλαίσιο του.
{{% /alert %}}

## **Wrap Text**

Αν θέλετε το κείμενο σε ένα σχήμα να αναδιπλώνεται μέσα στο σχήμα όταν το κείμενο ξεπερνά το πλάτος του σχήματος, πρέπει να χρησιμοποιήσετε την παράμετρο **Wrap text in shape**. Για να καθορίσετε αυτήν τη ρύθμιση, ορίστε την ιδιότητα `WrapText` της κλάσης [TextFrameFormat](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat) σε `NullableBool.True`.

Αυτός ο κώδικας C# δείχνει πώς να χρησιμοποιήσετε τη ρύθμιση Wrap Text σε μια παρουσίαση PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}} 
Αν ορίσετε την ιδιότητα `WrapText` σε `NullableBool.False` για ένα σχήμα, όταν το κείμενο μέσα στο σχήμα γίνει πιο μακρύ από το πλάτος του, το κείμενο θα εκτείνεται πέρα από τα όρια του σχήματος σε μια ενιαία γραμμή.
{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Επηρεάζουν τα εσωτερικά περιθώρια του πλαισίου κειμένου το AutoFit;**

Ναι. Το padding (εσωτερικά περιθώρια) μειώνει την περιοχή χρήσιμη για κείμενο, επομένως το AutoFit ενεργοποιείται νωρίτερα—σμικρύνοντας τη γραμματοσειρά ή αλλάζοντας το μέγεθος του σχήματος νωρίτερα. Ελέγξτε και προσαρμόστε τα περιθώρια πριν ρυθμίσετε το AutoFit.

**Πώς αλληλεπιδρά το AutoFit με χειροκίνητες και απαλές αλλαγές γραμμής;**

Οι υποχρεωτικές αλλαγές γραμμής παραμένουν, και το AutoFit προσαρμόζει το μέγεθος γραμματοσειράς και το διάστημα γύρω τους. Η αφαίρεση περιττών αλλαγών γραμμής συχνά μειώνει το πόσο έντονα το AutoFit πρέπει να σμικρύνει το κείμενο.

**Επηρεάζει η αλλαγή της γραμματοσειράς θέματος ή η αντικατάσταση γραμματοσειράς τα αποτελέσματα του AutoFit;**

Ναι. Η αντικατάσταση με γραμματοσειρά που έχει διαφορετικά χαρακτηριστικά γλύφων αλλάζει το πλάτος/ύψος του κειμένου, κάτι που μπορεί να αλλάξει το τελικό μέγεθος γραμματοσειράς και τη διάταξη των γραμμών. Μετά από κάθε αλλαγή ή αντικατάσταση γραμματοσειράς, ελέγξτε ξανά τις διαφάνειες.