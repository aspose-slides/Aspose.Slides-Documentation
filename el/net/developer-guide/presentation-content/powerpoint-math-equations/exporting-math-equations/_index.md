---
title: Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις σε .NET
linktitle: Εξαγωγή εξισώσεων
type: docs
weight: 30
url: /el/net/exporting-math-equations/
keywords:
- εξαγωγή μαθηματικών εξισώσεων
- εξαγωγή εξισώσεων σε LaTeX
- PowerPoint σε LaTeX
- MathML
- LaTeX
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις PowerPoint σε LaTeX ή MathML απευθείας με Aspose.Slides για .NET."
---
## **Εισαγωγή**

Aspose.Slides for .NET σας επιτρέπει να εξάγετε μαθηματικές εξισώσεις από παρουσιάσεις. Για παράδειγμα, μπορεί να χρειαστεί να εξαγάγετε τις μαθηματικές εξισώσεις από διαφάνειες (από συγκεκριμένη παρουσίαση) και να τις χρησιμοποιήσετε σε άλλο πρόγραμμα ή πλατφόρμα.

{{% alert color="primary" %}} 
Μπορείτε να εξάγετε εξισώσεις απευθείας σε LaTeX ή σε MathML, ένα δημοφιλές πρότυπο για μαθηματικό περιεχόμενο που χρησιμοποιείται στον ιστό και σε πολλές εφαρμογές.
{{% /alert %}}

## **Εξαγωγή μαθηματικών εξισώσεων σε LaTeX**

Aspose.Slides μπορεί να μετατρέψει μια μαθηματική εξίσωση PowerPoint απευθείας σε LaTeX· δεν απαιτείται ενδιάμεσο αρχείο MathML ή εξωτερικός μετατροπέας. Μια μαθηματική εξίσωση αποθηκεύεται σε ένα πλαίσιο κειμένου ως [MathPortion](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/mathportion/). Χρησιμοποιήστε [MathPortion.MathParagraph](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/mathportion/mathparagraph/) για να λάβετε ένα [IMathParagraph](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/imathparagraph/), και στη συνέχεια καλέστε [IMathParagraph.ToLatex](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/imathparagraph/tolatex/). Η μέθοδος επιστρέφει μια συμβολοσειρά που μπορείτε να αποθηκεύσετε, να εμφανίσετε, να στείλετε σε άλλη εφαρμογή ή να επεξεργαστείτε περαιτέρω.

Το παρακάτω παράδειγμα εξετάζει κάθε πλαίσιο κειμένου σε κάθε διαφάνεια, βρίσκει όλα τα math portions και γράφει κάθε εξίσωση σε ξεχωριστό αρχείο `.tex`:

```csharp
using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/el/net/aspose.slides.util/slideutil/getalltextboxes/) επιστρέφει όλα τα πλαίσια κειμένου που βρέθηκαν σε μια διαφάνεια. Ο έλεγχος τύπου [MathPortion](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/mathportion/) διαχωρίζει τις πραγματικές επεξεργάσιμες εξισώσεις από το συνηθισμένο κείμενο και τις εικόνες.

Οι μηχανές LaTeX και τα πρότυπα εγγράφων δεν υποστηρίζουν όλοι τις ίδιες εντολές, πακέτα ή χαρακτήρες Unicode. Δοκιμάστε τη συμβολοσειρά που επιστρέφεται με τη μηχανή LaTeX που χρησιμοποιεί η εφαρμογή σας. Εάν ένα σύμβολο ή στοιχείο Office Math δεν έχει κατάλληλη αναπαράσταση σε αυτό το περιβάλλον, αντικαταστήστε το στη συμβολοσειρά με μια εντολή προσαρμοσμένη στο έργο ή παραλείψτε την εξίσωση και καταγράψτε το ζήτημα για επανεξέταση.

## **Αποθήκευση μαθηματικών εξισώσεων ως MathML**

Ενώ οι άνθρωποι γράφουν εύκολα κώδικα για κάποιες μορφές εξισώσεων όπως LaTeX, δυσκολεύονται να γράψουν κώδικα για MathML, επειδή το δεύτερο προορίζεται να δημιουργείται αυτόματα από εφαρμογές. Τα προγράμματα διαβάζουν και αναλύουν το MathML εύκολα επειδή ο κώδικάς του είναι σε XML, οπότε το MathML χρησιμοποιείται συνήθως ως μορφή εξόδου και εκτύπωσης σε πολλούς τομείς.

Αυτό το δείγμα κώδικα δείχνει πώς να εξάγετε μια μαθηματική εξίσωση από μια παρουσίαση σε MathML:

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **Συχνές ερωτήσεις**

**Τι ακριβώς εξάγεται σε MathML—μια παράγραφος ή ένα μεμονωμένο μπλοκ τύπου;**

Μπορείτε να εξάγετε είτε ολόκληρη παράγραφο μαθηματικών ([MathParagraph](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/mathparagraph/)) είτε ένα μεμονωμένο μπλοκ ([MathBlock](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/mathblock/)) σε MathML. Και οι δύο τύποι παρέχουν μέθοδο για εγγραφή σε MathML.

**Πώς μπορώ να καταλάβω ότι ένα αντικείμενο σε μια διαφάνεια είναι μαθηματικός τύπος και όχι απλό κείμενο ή εικόνα;**

Ένας τύπος βρίσκεται σε ένα [MathPortion](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/mathportion/) και έχει ένα [MathParagraph](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/mathparagraph/). Εικόνες και κανονικές ενότητες κειμένου χωρίς [MathParagraph](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/mathparagraph/) δεν είναι εξαγώγιμοι τύποι.

**Από πού προέρχεται το MathML σε μια παρουσίαση—είναι ειδικό για το PowerPoint ή πρότυπο;**

Η εξαγωγή στοχεύει στο πρότυπο MathML (XML). Η Aspose χρησιμοποιεί Presentation MathML—το υποσύνολο παρουσίασης του προτύπου—το οποίο χρησιμοποιείται ευρέως σε εφαρμογές και στον ιστό.

**Υποστηρίζεται η εξαγωγή τύπων μέσα σε πίνακες, SmartArt, ομάδες κ.λπ.;**

Ναι, εάν τα αντικείμενα περιέχουν τμήματα κειμένου με [MathParagraph](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/mathparagraph/) (δηλαδή αληθινούς τύπους PowerPoint), εξάγονται. Εάν ένας τύπος είναι ενσωματωμένος ως εικόνα, δεν εξάγεται.

**Τροποποιεί η εξαγωγή σε MathML την αρχική παρουσίαση;**

Όχι. Η εγγραφή MathML είναι μια σειριοποίηση του περιεχομένου του τύπου· δεν τροποποιεί το αρχείο παρουσίασης.