---
title: Διαχείριση Ανώτατου και Κατώτερου Δείκτη στις Παρουσιάσεις σε .NET
linktitle: Ανώτερος και Κατώτερος Δείκτης
type: docs
weight: 80
url: /el/net/superscript-and-subscript/
keywords:
- ανώτατος δείκτης
- κατώτερος δείκτης
- προσθήκη ανώτατου δείκτη
- προσθήκη κατώτερου δείκτη
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Κατακτήστε τον ανώτατο και κατώτερο δείκτη στο Aspose.Slides για .NET και αναβαθμίστε τις παρουσιάσεις σας με επαγγελματική μορφοποίηση κειμένου για μέγιστο αντίκτυπο."
---
## **Επισκόπηση**

Το Aspose.Slides για .NET παρέχει δυνατότητες ενσωμάτωσης κειμένου ανώτατου και κατώτερου δείκτη στις παρουσιάσεις PowerPoint (PPT, PPTX) και OpenDocument (ODP). Είτε χρειάζεστε να τονίσετε χημικούς τύπους, μαθηματικές εξισώσεις ή να σχολιάσετε περιεχόμενο με υποσημειώσεις, αυτές οι εξειδικευμένες επιλογές μορφοποίησης βοηθούν στη διατήρηση της σαφήνειας και της ακρίβειας. Σε αυτό το άρθρο, θα μάθετε πώς να εφαρμόζετε ομαλά στυλ ανώτατου και κατώτερου δείκτη και να εξασφαλίζετε επαγγελματικά αποτελέσματα σε κάθε διαφάνεια.

## **Πρόσθεση Κειμένου Ανώτατου και Κατώτερου Δείκτη**

Μπορείτε να προσθέσετε κείμενο ανώτατου ή κατώτερου δείκτη μέσα σε οποιαδήποτε παράγραφο μιας παρουσίασης. Για να το επιτύχετε με το Aspose.Slides, πρέπει να χρησιμοποιήσετε την ιδιότητα `Escapement` της κλάσης [PortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/portionformat/).

Αυτή η ιδιότητα επιτρέπει τον ορισμό κειμένου ανώτατου ή κατώτερου δείκτη, με τιμές από -100% (κατώτερος δείκτης) έως 100% (ανώτατος δείκτης).

Βήματα υλοποίησης:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) τύπου `Rectangle` στη διαφάνεια.
1. Προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) που σχετίζεται με το [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/).
1. Απαλοποιήστε (clear) τις υπάρχουσες παραγράφους.
1. Δημιουργήστε μια νέα [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph/) για κείμενο ανώτατου δείκτη και προσθέστε τη στη συλλογή παραγράφων του [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/).
1. Δημιουργήστε ένα νέο αντικείμενο κειμενικού τμήματος (text portion).
1. Ορίστε την ιδιότητα `Escapement` για το τμήμα κειμένου μεταξύ 0 και 100 για να εφαρμόσετε ανώτατο δείκτη (0 σημαίνει χωρίς ανώτατο δείκτη).
1. Ορίστε κάποιο κείμενο για το [Portion](https://reference.aspose.com/slides/el/net/aspose.slides/portion/) και προσθέστε το στη συλλογή τμημάτων της παραγράφου.
1. Δημιουργήστε μια νέα [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph/) για κείμενο κατώτερου δείκτη και προσθέστε τη στη συλλογή παραγράφων.
1. Δημιουργήστε ένα νέο αντικείμενο κειμενικού τμήματος.
1. Ορίστε την ιδιότητα `Escapement` για το τμήμα κειμένου μεταξύ 0 και -100 για να εφαρμόσετε κατώτερο δείκτη (0 σημαίνει χωρίς κατώτερο δείκτη).
1. Ορίστε κάποιο κείμενο για το [Portion](https://reference.aspose.com/slides/el/net/aspose.slides/portion/) και προσθέστε το στη συλλογή τμημάτων της παραγράφου.
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C# υλοποιεί αυτά τα βήματα:

```c#
using (Presentation presentation = new Presentation())
{
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Δημιουργήστε ένα πλαίσιο κειμένου.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Δημιουργήστε μια παράγραφο για κείμενο ανώτατου δείκτη.
    IParagraph superPar = new Paragraph();

    // Δημιουργήστε ένα τμήμα κειμένου με κανονικό κείμενο.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Δημιουργήστε ένα τμήμα κειμένου με ανώτατο δείκτη.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Δημιουργήστε μια παράγραφο για κείμενο κατώτερου δείκτη.
    IParagraph paragraph2 = new Paragraph();

    // Δημιουργήστε ένα τμήμα κειμένου με κανονικό κείμενο.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Δημιουργήστε ένα τμήμα κειμένου με κατώτερο δείκτη.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Superscript and Subscript](superscript_and_subscript.png)

## **Συχνές Ερωτήσεις**

**Θα διατηρηθεί ο ανώτατος και ο κατώτερος δείκτης κατά την εξαγωγή σε PDF ή άλλες μορφές;**

Ναι, το Aspose.Slides για .NET διατηρεί σωστά τη μορφοποίηση του ανώτατου και του κατώτερου δείκτη κατά την εξαγωγή των παρουσιάσεων σε PDF, PPT/PPTX, εικόνες και άλλες υποστηριζόμενες μορφές. Η εξειδικευμένη μορφοποίηση παραμένει αμετάβλητη σε όλα τα αρχεία εξόδου.

**Μπορεί ο ανώτατος και ο κατώτερος δείκτης να συνδυαστούν με άλλες μορφές όπως έντονο ή πλάγιο κείμενο;**

Ναι, το Aspose.Slides σας επιτρέπει να συνδυάζετε διάφορα στυλ κειμένου μέσα σε ένα μόνο τμήμα κειμένου. Μπορείτε να ενεργοποιήσετε έντονη, πλάγια, υπογράμμιση και ταυτόχρονα να εφαρμόσετε ανώτατο ή κατώτερο δείκτη διαμορφώνοντας τις αντίστοιχες ιδιότητες στο [PortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/portionformat/).

**Λειτουργεί η μορφοποίηση του ανώτατου και του κατώτερου δείκτη για κείμενο μέσα σε πίνακες, διαγράμματα ή SmartArt;**

Ναι, το Aspose.Slides για .NET υποστηρίζει τη μορφοποίηση στα περισσότερα αντικείμενα, συμπεριλαμβανομένων των πινάκων και των στοιχείων διαγραμμάτων. Όταν εργάζεστε με SmartArt, πρέπει να προσπελάσετε τα κατάλληλα στοιχεία (όπως [SmartArtNode](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/smartartnode/)) και τα περιέχοντα κείμενα, και στη συνέχεια να διαμορφώσετε τις ιδιότητες του [PortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/portionformat/) με παρόμοιο τρόπο.