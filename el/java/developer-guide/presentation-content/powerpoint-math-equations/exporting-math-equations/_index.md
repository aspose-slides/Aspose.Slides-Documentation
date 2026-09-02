---
title: Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις σε Java
linktitle: Εξαγωγή εξισώσεων
type: docs
weight: 30
url: /el/java/exporting-math-equations/
keywords:
- εξαγωγή μαθηματικών εξισώσεων
- εξαγωγή εξισώσεων σε LaTeX
- PowerPoint σε LaTeX
- MathML
- LaTeX
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις PowerPoint σε LaTeX ή MathML απευθείας με Aspose.Slides για Java."
---
## **Εισαγωγή**

Το Aspose.Slides σας επιτρέπει να εξάγετε μαθηματικές εξισώσεις από παρουσιάσεις. Για παράδειγμα, ίσως χρειαστεί να εξάγετε τις μαθηματικές εξισώσεις στις διαφάνειες (από μια συγκεκριμένη παρουσίαση) και να τις χρησιμοποιήσετε σε άλλο πρόγραμμα ή πλατφόρμα.

{{% alert color="primary" %}} 
Μπορείτε να εξάγετε τις εξισώσεις απευθείας σε LaTeX ή σε MathML, ένα δημοφιλές πρότυπο για μαθηματικό περιεχόμενο που χρησιμοποιείται στο διαδίκτυο και σε πολλές εφαρμογές.
{{% /alert %}}

## **Εξαγωγή μαθηματικών εξισώσεων σε LaTeX**

Το Aspose.Slides μπορεί να μετατρέπει μια μαθηματική εξίσωση PowerPoint απευθείας σε LaTeX· δεν απαιτείται ενδιάμεσο αρχείο MathML ή εξωτερικός μετατροπέας. Μια μαθηματική εξίσωση αποθηκεύεται σε ένα πλαίσιο κειμένου ως [IMathPortion](https://reference.aspose.com/slides/el/java/com.aspose.slides/imathportion/). Χρησιμοποιήστε [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/imathportion/#getMathParagraph--) για να λάβετε ένα [IMathParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/imathparagraph/), και στη συνέχεια καλέστε [IMathParagraph.toLatex](https://reference.aspose.com/slides/el/java/com.aspose.slides/imathparagraph/#toLatex--). Η μέθοδος επιστρέφει ένα κείμενο που μπορείτε να αποθηκεύσετε, εμφανίσετε, στείλετε σε άλλη εφαρμογή ή να επεξεργαστείτε περαιτέρω.

Το παρακάτω παράδειγμα εξετάζει κάθε πλαίσιο κειμένου σε κάθε διαφάνεια, βρίσκει όλα τα math portions και γράφει κάθε εξίσωση σε ξεχωριστό αρχείο `.tex`:

```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    Path latexPath = Paths.get(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    Files.write(latexPath, latexBytes);
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/el/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) επιστρέφει όλα τα πλαίσια κειμένου που βρέθηκαν σε μια διαφάνεια. Ο έλεγχος τύπου [IMathPortion](https://reference.aspose.com/slides/el/java/com.aspose.slides/imathportion/) διαχωρίζει τις αληθινές επεξεργάσιμες εξισώσεις από το κοινό κείμενο και τις εικόνες.

Οι μηχανές LaTeX και τα πρότυπα εγγράφων δεν υποστηρίζουν όλες τις ίδιες εντολές, πακέτα ή χαρακτήρες Unicode. Δοκιμάστε το επιστρεφόμενο κείμενο με τη μηχανή LaTeX που χρησιμοποιεί η εφαρμογή σας. Εάν ένα σύμβολο ή στοιχείο Office Math δεν έχει κατάλληλη αναπαράσταση σε αυτό το περιβάλλον, αντικαταστήστε το στο επιστρεφόμενο κείμενο με μια εντολή ειδική για το έργο ή παραλείψτε την εξίσωση και καταγράψτε το ζήτημα για έλεγχο.

## **Αποθήκευση μαθηματικών εξισώσεων ως MathML**

Ενώ οι άνθρωποι γράφουν εύκολα τον κώδικα για ορισμένες μορφές εξισώσεων όπως το LaTeX, δυσκολεύονται να γράψουν τον κώδικα για το MathML επειδή αυτό προορίζεται να δημιουργείται αυτόματα από εφαρμογές. Τα προγράμματα διαβάζουν και αναλύουν το MathML εύκολα επειδή ο κώδικάς του είναι σε XML, έτσι το MathML χρησιμοποιείται συχνά ως μορφή εξόδου και εκτύπωσης σε πολλούς τομείς.

Αυτό το δείγμα κώδικα δείχνει πώς να εξάγετε μια μαθηματική εξίσωση από μια παρουσίαση σε MathML:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Τι εξάγεται ακριβώς σε MathML—ένα παράγραφο ή ένα μεμονωμένο μπλοκ τύπου;**

Μπορείτε να εξάγετε είτε ολόκληρη μαθηματική παράγραφο ([MathParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/mathparagraph/)) είτε ένα μεμονωμένο μπλοκ ([MathBlock](https://reference.aspose.com/slides/el/java/com.aspose.slides/mathblock/)) σε MathML. Και οι δύο τύποι παρέχουν μέθοδο για εγγραφή σε MathML.

**Πώς μπορώ να καταλάβω ότι ένα αντικείμενο σε μια διαφάνεια είναι μαθηματικός τύπος και όχι απλό κείμενο ή εικόνα;**

Ένας τύπος βρίσκεται σε ένα [MathPortion](https://reference.aspose.com/slides/el/java/com.aspose.slides/mathportion/) και έχει ένα [MathParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/mathparagraph/). Εικόνες και κοινά τμήματα κειμένου χωρίς [MathParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/mathparagraph/) δεν είναι εξαγώγιμοι τύποι.

**Από που προέρχεται το MathML σε μια παρουσίαση—είναι ειδικό για το PowerPoint ή πρότυπο;**

Η εξαγωγή στοχεύει στο τυπικό MathML (XML). Το Aspose χρησιμοποιεί Presentation MathML—το υποσύνολο παρουσίασης του προτύπου—που χρησιμοποιείται ευρέως σε εφαρμογές και στο διαδίκτυο.

**Υποστηρίζεται η εξαγωγή τύπων εντός πινάκων, SmartArt, ομάδων κ.λπ.;**

Ναι, εάν εκείνα τα αντικείμενα περιέχουν τμήματα κειμένου με [MathParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/mathparagraph/) (δηλαδή αληθινούς τύπους PowerPoint), εξάγονται. Εάν ένας τύπος είναι ενσωματωμένος ως εικόνα, δεν εξάγεται.

**Τροποποιεί η εξαγωγή σε MathML την αρχική παρουσίαση;**

Όχι. Η εγγραφή MathML είναι μια σειροποίηση του περιεχομένου του τύπου· δεν τροποποιεί το αρχείο παρουσίασης.