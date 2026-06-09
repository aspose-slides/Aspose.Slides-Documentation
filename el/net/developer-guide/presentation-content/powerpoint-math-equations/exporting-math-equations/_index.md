---
title: Εξαγωγή Μαθηματικών Εξισώσεων από Παρουσιάσεις σε .NET
linktitle: Εξαγωγή Εξισώσεων
type: docs
weight: 30
url: /el/net/exporting-math-equations/
keywords:
- εξαγωγή μαθηματικών εξισώσεων
- MathML
- LaTeX
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Απελευθερώστε την αδιάσκοπη εξαγωγή μαθηματικών εξισώσεων από το PowerPoint σε MathML χρησιμοποιώντας το Aspose.Slides για .NET—διατηρήστε τη μορφοποίηση και βελτιώστε τη συμβατότητα."
---
## **Εισαγωγή**

Το Aspose.Slides για .NET σάς επιτρέπει να εξάγετε μαθηματικές εξισώσεις από παρουσιάσεις. Για παράδειγμα, ίσως χρειαστεί να εξάγετε τις μαθηματικές εξισώσεις στις διαφάνειες (από μια συγκεκριμένη παρουσίαση) και να τις χρησιμοποιήσετε σε άλλο πρόγραμμα ή πλατφόρμα. 

{{% alert color="primary" %}} 

Μπορείτε να εξάγετε εξισώσεις σε MathML, μια δημοφιλής μορφή ή πρότυπο για μαθηματικές εξισώσεις και παρόμοιο περιεχόμενο που εμφανίζεται στον ιστό και σε πολλές εφαρμογές. 

{{% /alert %}}

## **Αποθήκευση Μαθηματικών Εξισώσεων ως MathML**

Ενώ οι άνθρωποι γράφουν εύκολα τον κώδικα για ορισμένες μορφές εξισώσεων όπως LaTeX, δυσκολεύονται να γράψουν τον κώδικα για MathML, επειδή αυτό προορίζεται να δημιουργείται αυτόματα από εφαρμογές. Τα προγράμματα διαβάζουν και αναλύουν το MathML εύκολα επειδή ο κώδικάς του είναι σε XML, έτσι το MathML χρησιμοποιείται συνήθως ως μορφή εξόδου και εκτύπωσης σε πολλούς τομείς. 

Αυτό το δείγμα κώδικα σας δείχνει πώς να εξάγετε μια μαθηματική εξίσωση από μια παρουσίαση σε MathML:

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

## **Συχνές Ερωτήσεις**

**What exactly is exported to MathML—a paragraph or an individual formula block?**

Μπορείτε να εξάγετε είτε ολόκληρη μαθηματική παράγραφο([MathParagraph](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/mathparagraph/)) είτε ένα μεμονωμένο μπλοκ([MathBlock](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/mathblock/)) σε MathML. Και οι δύο τύποι παρέχουν μέθοδο για εγγραφή σε MathML.

**How can I tell that an object on a slide is a math formula rather than regular text or an image?**

Ένας τύπος βρίσκεται σε ένα [MathPortion](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/mathportion/) και έχει ένα [MathParagraph](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/mathparagraph/). Οι εικόνες και τα κανονικά τμήματα κειμένου χωρίς ένα [MathParagraph](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/mathparagraph/) δεν είναι εξαγώγιμοι τύποι.

**Where does the MathML come from in a presentation—is it PowerPoint-specific or a standard?**

Η εξαγωγή στοχεύει στο πρότυπο MathML (XML). Το Aspose χρησιμοποιεί το Presentation MathML—το υποσύνολο παρουσίασης του προτύπου—που χρησιμοποιείται ευρέως σε εφαρμογές και στο διαδίκτυο.

**Is exporting formulas inside tables, SmartArt, groups, etc., supported?**

Ναι, εάν αυτά τα αντικείμενα περιέχουν τμήματα κειμένου με ένα [MathParagraph](https://reference.aspose.com/slides/el/net/aspose.slides.mathtext/mathparagraph/) (δηλαδή αυθεντικούς τύπους PowerPoint), εξάγονται. Εάν ένας τύπος είναι ενσωματωμένος ως εικόνα, δεν εξάγεται.

**Does exporting to MathML modify the original presentation?**

Όχι. Η εγγραφή MathML είναι μια σειριοποίηση του περιεχομένου του τύπου· δεν τροποποιεί το αρχείο παρουσίασης.