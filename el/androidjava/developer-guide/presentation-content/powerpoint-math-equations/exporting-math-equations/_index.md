---
title: Εξαγωγή Μαθηματικών Εξισώσεων από Παρουσιάσεις σε Android
linktitle: Εξαγωγή Εξισώσεων
type: docs
weight: 30
url: /el/androidjava/exporting-math-equations/
keywords:
- εξαγωγή μαθηματικών εξισώσεων
- εξαγωγή εξισώσεων σε LaTeX
- PowerPoint σε LaTeX
- MathML
- LaTeX
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Εξάγετε μαθηματικές εξισώσεις από παρουσιάσεις PowerPoint σε LaTeX ή MathML απευθείας με Aspose.Slides για Android μέσω Java."
---
## **Εισαγωγή**

Το Aspose.Slides για Android μέσω Java σας επιτρέπει να εξάγετε μαθηματικές εξισώσεις από παρουσιάσεις. Για παράδειγμα, ίσως χρειαστεί να εξάγετε τις μαθηματικές εξισώσεις σε διαφάνειες (από μια συγκεκριμένη παρουσίαση) και να τις χρησιμοποιήσετε σε κάποιο άλλο πρόγραμμα ή πλατφόρμα.

{{% alert color="info" %}} 
Μπορείτε να εξάγετε τις εξισώσεις απευθείας σε LaTeX ή σε MathML, ένα δημοφιλές πρότυπο για μαθηματικό περιεχόμενο που χρησιμοποιείται στο διαδίκτυο και σε πολλές εφαρμογές.
{{% /alert %}}

## **Εξαγωγή Μαθηματικών Εξισώσεων σε LaTeX**

Το Aspose.Slides μπορεί να μετατρέψει μια μαθηματική εξίσωση PowerPoint απευθείας σε LaTeX· δεν απαιτείται ενδιάμεσο αρχείο MathML ή εξωτερικός μετατροπέας. Μια μαθηματική εξίσωση αποθηκεύεται σε ένα πλαίσιο κειμένου ως ένα [IMathPortion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathportion/). Χρησιμοποιήστε το [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) για να λάβετε ένα [IMathParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathparagraph/), και, στη συνέχεια, καλέστε το [IMathParagraph.toLatex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathparagraph/#toLatex--). Η μέθοδος επιστρέφει μια συμβολοσειρά που μπορείτε να αποθηκεύσετε, να εμφανίσετε, να στείλετε σε άλλη εφαρμογή ή να επεξεργαστείτε περαιτέρω.

Το παρακάτω παράδειγμα εξετάζει κάθε πλαίσιο κειμένου σε κάθε διαφάνεια, βρίσκει όλες τις μαθηματικές περιοχές και γράφει κάθε εξίσωση σε ξεχωριστό αρχείο `.tex`:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.nio.charset.StandardCharsets;

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
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Το [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) επιστρέφει όλα τα πλαίσια κειμένου που βρέθηκαν σε μια διαφάνεια. Η έλεγχος τύπου [IMathPortion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathportion/) διαχωρίζει τις πραγματικές επεξεργάσιμες εξισώσεις από το συνηθισμένο κείμενο και τις εικόνες.

Οι μηχανές LaTeX και τα πρότυπα εγγράφων δεν υποστηρίζουν όλες τις ίδιες εντολές, πακέτα ή χαρακτήρες Unicode. Δοκιμάστε τη επιστρεφόμενη συμβολοσειρά με τη μηχανή LaTeX που χρησιμοποιεί η εφαρμογή σας. Εάν ένα σύμβολο ή στοιχείο Office Math δεν έχει κατάλληλη αναπαράσταση σε αυτό το περιβάλλον, αντικαταστήστε το στη συμβολοσειρά με μια εντολή ειδική για το έργο ή παραλείψτε την εξίσωση και καταγράψτε το ζήτημα για ανασκόπηση.

## **Αποθήκευση Μαθηματικών Εξισώσεων ως MathML**

Ενώ οι άνθρωποι μπορούν εύκολα να γράψουν κώδικα για ορισμένες μορφές εξισώσεων όπως το LaTeX, δυσκολεύονται να γράψουν κώδικα για το MathML, επειδή αυτό προορίζεται να δημιουργείται αυτόματα από εφαρμογές. Τα προγράμματα διαβάζουν και αναλύουν το MathML εύκολα επειδή ο κώδικάς του είναι σε XML, έτσι το MathML χρησιμοποιείται κοινά ως μορφή εξαγωγής και εκτύπωσης σε πολλούς τομείς.

Αυτό το παράδειγμα κώδικα δείχνει πώς να εξάγετε μια μαθηματική εξίσωση από μια παρουσίαση σε MathML:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

## **Συχνές Ερωτήσεις**

**Τι ακριβώς εξάγεται σε MathML—μια παράγραφος ή ένα μεμονωμένο μπλοκ τύπου;**

Μπορείτε να εξάγετε είτε ολόκληρη τη μαθηματική παράγραφο ([MathParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mathparagraph/)) είτε ένα μεμονωμένο μπλοκ ([MathBlock](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mathblock/)) σε MathML. Και οι δύο τύποι παρέχουν μια μέθοδο για εγγραφή σε MathML.

**Πώς μπορώ να διακρίνω ότι ένα αντικείμενο σε μια διαφάνεια είναι μαθηματικός τύπος και όχι κανονικό κείμενο ή εικόνα;**

Ένας τύπος βρίσκεται σε ένα [MathPortion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mathportion/) και έχει ένα [MathParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mathparagraph/). Οι εικόνες και τα κανονικά τμήματα κειμένου χωρίς [MathParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mathparagraph/) δεν είναι εξαγώγιμοι τύποι.

**Από πού προέρχεται το MathML σε μια παρουσίαση—είναι ειδικό για το PowerPoint ή πρότυπο;**

Η εξαγωγή στοχεύει στο πρότυπο MathML (XML). Η Aspose χρησιμοποιεί το Presentation MathML—το υποσύνολο παρουσίασης του προτύπου—που χρησιμοποιείται ευρέως σε εφαρμογές και στο διαδίκτυο.

**Υποστηρίζεται η εξαγωγή τύπων μέσα σε πίνακες, SmartArt, ομάδες κ.λπ.;**

Ναι, εάν αυτά τα αντικείμενα περιέχουν τμήματα κειμένου με ένα [MathParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mathparagraph/) (δηλαδή πραγματικούς τύπους PowerPoint), εξάγονται. Εάν ένας τύπος είναι ενσωματωμένος ως εικόνα, δεν εξάγεται.

**Τροποποιεί η εξαγωγή σε MathML την αρχική παρουσίαση;**

Όχι. Η εγγραφή MathML είναι μια σειριοποίηση του περιεχομένου του τύπου· δεν τροποποιεί το αρχείο της παρουσίασης.