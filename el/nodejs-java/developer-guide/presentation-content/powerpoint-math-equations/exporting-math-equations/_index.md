---
title: Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις σε JavaScript
linktitle: Εξαγωγή Εξισώσεων
type: docs
weight: 30
url: /el/nodejs-java/exporting-math-equations/
keywords:
- εξαγωγή μαθηματικών εξισώσεων
- εξαγωγή εξισώσεων σε LaTeX
- PowerPoint σε LaTeX
- MathML
- LaTeX
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις PowerPoint σε LaTeX ή MathML απευθείας με Aspose.Slides για Node.js μέσω Java."
---
## **Εισαγωγή**

Το Aspose.Slides σάς επιτρέπει να εξάγετε μαθηματικές εξισώσεις από παρουσιάσεις. Για παράδειγμα, μπορεί να χρειαστεί να εξάγετε τις μαθηματικές εξισώσεις στις διαφάνειες (από μια συγκεκριμένη παρουσίαση) και να τις χρησιμοποιήσετε σε άλλο πρόγραμμα ή πλατφόρμα. 

{{% alert color="primary" %}} 

Μπορείτε να εξάγετε τις εξισώσεις απευθείας σε LaTeX ή σε MathML, ένα δημοφιλές πρότυπο για μαθηματικό περιεχόμενο που χρησιμοποιείται στο διαδίκτυο και σε πολλές εφαρμογές.

{{% /alert %}}

## **Εξαγωγή Μαθηματικών Εξισώσεων σε LaTeX**

Το Aspose.Slides μπορεί να μετατρέψει μια μαθηματική εξίσωση PowerPoint απευθείας σε LaTeX· δεν απαιτείται ενδιάμεσικό αρχείο MathML ή εξωτερικός μετατροπέας. Μια μαθηματική εξίσωση αποθηκεύεται σε ένα πλαίσιο κειμένου ως ένα [MathPortion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathportion/). Χρησιμοποιήστε το [MathPortion.getMathParagraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) για να λάβετε ένα [MathParagraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathparagraph/), και έπειτα καλέστε το [MathParagraph.toLatex](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathparagraph/#toLatex--). Η μέθοδος επιστρέφει μια συμβολοσειρά που μπορείτε να αποθηκεύσετε, να εμφανίσετε, να στείλετε σε άλλη εφαρμογή ή να επεξεργαστείτε περαιτέρω.

Το παρακάτω παράδειγμα εξετάει κάθε πλαίσιο κειμένου σε κάθε διαφάνεια, εντοπίζει όλες τις μαθηματικές περιοχές και γράφει κάθε εξίσωση σε ξεχωριστό αρχείο `.tex`:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Το [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) επιστρέφει όλα τα πλαίσια κειμένου που βρίσκονται σε μια διαφάνεια. Ο έλεγχος τύπου [MathPortion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathportion/) διαχωρίζει τις πραγματικές επεξεργάσιμες εξισώσεις από το συνηθισμένο κείμενο και τις εικόνες.

Οι μηχανές LaTeX και τα πρότυπα εγγράφων δεν υποστηρίζουν όλα τις ίδιες εντολές, πακέτα ή χαρακτήρες Unicode. Δοκιμάστε τη επιστρεφόμενη συμβολοσειρά με τη μηχανή LaTeX που χρησιμοποιεί η εφαρμογή σας. Εάν ένα σύμβολο ή στοιχείο Office Math δεν έχει κατάλληλη αναπαράσταση σε αυτό το περιβάλλον, αντικαταστήστε το στη συμβολοσειρά με μια εντολή ειδική για το έργο ή παραλείψτε την εξίσωση και καταγράψτε το ζήτημα για ανασκόπηση.

## **Αποθήκευση Μαθηματικών Εξισώσεων ως MathML**

Ενώ οι άνθρωποι γράφουν εύκολα τον κώδικα για κάποιες μορφές εξίσωσης όπως LaTeX, δυσκολεύονται να γράψουν τον κώδικα για MathML επειδή αυτό προορίζεται να δημιουργείται αυτόματα από εφαρμογές. Τα προγράμματα διαβάζουν και αναλύουν το MathML εύκολα επειδή ο κώδικάς του είναι σε XML, έτσι το MathML χρησιμοποιείται συχνά ως μορφή εξόδου και εκτύπωσης σε πολλούς τομείς. 

Αυτό το δείγμα κώδικα δείχνει πώς να εξάγετε μια μαθηματική εξίσωση από μια παρουσίαση σε MathML:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Τι ακριβώς εξάγεται σε MathML—μια παράγραφος ή ένα μεμονωμένο τμήμα τύπου;**

Μπορείτε να εξάγετε είτε ολόκληρη μαθηματική παράγραφο ([MathParagraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathparagraph/)) είτε ένα μεμονωμένο τμήμα ([MathBlock](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathblock/)) σε MathML. Και οι δύο τύποι προσφέρουν μέθοδο για εγγραφή σε MathML.

**Πώς μπορώ να καταλάβω ότι ένα αντικείμενο σε μια διαφάνεια είναι μαθηματικός τύπος και όχι απλό κείμενο ή εικόνα;**

Ένας τύπος βρίσκεται σε ένα [MathPortion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathportion/) και έχει ένα [MathParagraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathparagraph/). Οι εικόνες και τα κοινά τμήματα κειμένου χωρίς [MathParagraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathparagraph/) δεν είναι εξαγώγιμοι τύποι.

**Από πού προέρχεται το MathML σε μια παρουσίαση—είναι ειδικό για το PowerPoint ή πρότυπο;**

Η εξαγωγή στοχεύει στο πρότυπο MathML (XML). Το Aspose χρησιμοποιεί το Presentation MathML—το υποσύνολο παρουσίασης του προτύπου—το οποίο χρησιμοποιείται εκτενώς σε εφαρμογές και στον ιστό.

**Υποστηρίζεται η εξαγωγή τύπων μέσα σε πίνακες, SmartArt, ομάδες κ.λπ.;**

Ναι, εάν αυτά τα αντικείμενα περιέχουν τμήματα κειμένου με [MathParagraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathparagraph/) (δηλαδή αληθινούς τύπους PowerPoint), εξάγονται. Εάν ένας τύπος είναι ενσωματωμένος ως εικόνα, δεν εξάγεται.

**Τροποποιεί η εξαγωγή σε MathML την αρχική παρουσίαση;**

Όχι. Η εγγραφή MathML είναι μια σειριοποίηση του περιεχομένου του τύπου· δεν τροποποιεί το αρχείο της παρουσίασης.