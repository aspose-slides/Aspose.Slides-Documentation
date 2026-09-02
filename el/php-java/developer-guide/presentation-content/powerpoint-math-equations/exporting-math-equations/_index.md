---
title: Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις σε PHP
linktitle: Εξαγωγή εξισώσεων
type: docs
weight: 30
url: /el/php-java/exporting-math-equations/
keywords:
- εξαγωγή μαθηματικών εξισώσεων
- εξαγωγή εξισώσεων σε LaTeX
- PowerPoint σε LaTeX
- MathML
- LaTeX
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εξάγετε μαθηματικές εξισώσεις από παρουσιάσεις PowerPoint σε LaTeX ή MathML απευθείας με Aspose.Slides για PHP μέσω Java."
---
## **Εισαγωγή**

Aspose.Slides for PHP via Java σας επιτρέπει να εξάγετε μαθηματικές εξισώσεις από παρουσιάσεις. Για παράδειγμα, μπορεί να χρειαστεί να εξάγετε τις μαθηματικές εξισώσεις στις διαφάνειες (από μια συγκεκριμένη παρουσίαση) και να τις χρησιμοποιήσετε σε άλλο πρόγραμμα ή πλατφόρμα.

{{% alert color="primary" %}} 

Μπορείτε να εξάγετε τις εξισώσεις απευθείας σε LaTeX ή σε MathML, ένα δημοφιλές πρότυπο για μαθηματικό περιεχόμενο που χρησιμοποιείται στο web και σε πολλές εφαρμογές.

{{% /alert %}}

## **Εξαγωγή Μαθηματικών Εξισώσεων σε LaTeX**

Aspose.Slides μπορεί να μετατρέψει μια εξίσωση PowerPoint math απευθείας σε LaTeX· δεν απαιτείται ενδιάμεσο αρχείο MathML ή εξωτερικός μετατροπέας. Μια μαθηματική εξίσωση αποθηκεύεται σε ένα πλαίσιο κειμένου ως [MathPortion](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathportion/). Χρησιμοποιήστε [MathPortion::getMathParagraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathportion/#getMathParagraph) για να λάβετε ένα [MathParagraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathparagraph/), και στη συνέχεια καλέστε [MathParagraph::toLatex](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathparagraph/#toLatex). Η μέθοδος επιστρέφει μια συμβολοσειρά που μπορείτε να αποθηκεύσετε, να εμφανίσετε, να στείλετε σε άλλη εφαρμογή ή να επεξεργαστείτε περαιτέρω.

Το παρακάτω παράδειγμα εξετάζει κάθε πλαίσιο κειμένου σε κάθε διαφάνεια, βρίσκει όλα τα math portions και γράφει κάθε εξίσωση σε ξεχωριστό αρχείο `.tex`:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideutil/#getAllTextBoxes) επιστρέφει όλα τα πλαίσια κειμένου που βρέθηκαν σε μια διαφάνεια. Ο έλεγχος τύπου [MathPortion](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathportion/) διαχωρίζει τις πραγματικές επεξεργάσιμες εξισώσεις από το κοινό κείμενο και τις εικόνες.

Οι μηχανές LaTeX και τα πρότυπα εγγράφων δεν υποστηρίζουν όλα τις ίδιες εντολές, πακέτα ή χαρακτήρες Unicode. Δοκιμάστε τη συμβολοσειρά που επιστράφηκε με τη μηχανή LaTeX που χρησιμοποιεί η εφαρμογή σας. Εάν ένα σύμβολο ή στοιχείο Office Math δεν έχει κατάλληλη αναπαράσταση σε αυτό το περιβάλλον, αντικαταστήστε το στη συμβολοσειρά με μια εντολή ειδική για το έργο σας ή παραλείψτε την εξίσωση και καταγράψτε το ζήτημα για επανεξέταση.

## **Αποθήκευση Μαθηματικών Εξισώσεων ως MathML**

Ενώ οι άνθρωποι γράφουν εύκολα τον κώδικα για κάποιες μορφές εξισώσεων όπως το LaTeX, δυσκολεύονται να γράψουν τον κώδικα για MathML επειδή αυτό το τελευταίο προορίζεται να δημιουργείται αυτόματα από εφαρμογές. Τα προγράμματα διαβάζουν και αναλύουν το MathML εύκολα επειδή ο κώδικάς του είναι σε XML, έτσι το MathML χρησιμοποιείται συνήθως ως μορφή εξόδου και εκτύπωσης σε πολλούς τομείς.

Αυτό το δείγμα κώδικα δείχνει πώς να εξάγετε μια μαθηματική εξίσωση από παρουσίαση σε MathML:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Τι ακριβώς εξάγεται σε MathML—ένα παράγραφο ή ένα μεμονωμένο μπλοκ τύπου;**

Μπορείτε να εξάγετε είτε ολόκληρη τη μαθηματική παράγραφο ([MathParagraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathparagraph/)) είτε ένα μεμονωμένο μπλοκ ([MathBlock](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathblock/)) σε MathML. Και οι δύο τύποι παρέχουν μέθοδο για εγγραφή σε MathML.

**Πώς μπορώ να διακρίνω ότι ένα αντικείμενο σε μια διαφάνεια είναι μαθηματικός τύπος και όχι απλό κείμενο ή εικόνα;**

Ένας τύπος βρίσκεται σε ένα [MathPortion](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathportion/) και έχει ένα [MathParagraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathparagraph/). Εικόνες και κανονικά τμήματα κειμένου χωρίς [MathParagraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathparagraph/) δεν είναι εξαγώγιμες εξισώσεις.

**Από πού προέρχεται το MathML σε μια παρουσίαση—είναι ειδικό για το PowerPoint ή πρότυπο;**

Η εξαγωγή στοχεύει στο πρότυπο MathML (XML). Το Aspose χρησιμοποιεί το Presentation MathML—το υποσύνολο παρουσίασης του προτύπου—που χρησιμοποιείται ευρέως σε εφαρμογές και στο web.

**Υποστηρίζεται η εξαγωγή τύπων μέσα σε πίνακες, SmartArt, ομάδες κ.λπ.;**

Ναι, εάν αυτά τα αντικείμενα περιέχουν τμήματα κειμένου με [MathParagraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathparagraph/) (δηλαδή γνήσιοι τύποι PowerPoint), εξάγονται. Εάν ένας τύπος είναι ενσωματωμένος ως εικόνα, δεν εξάγεται.

**Τροποποιεί η εξαγωγή σε MathML την αρχική παρουσίαση;**

Όχι. Η εγγραφή MathML είναι μια σειριοποίηση του περιεχομένου της εξίσωσης· δεν τροποποιεί το αρχείο παρουσίασης.