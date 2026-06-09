---
title: Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις σε PHP
linktitle: Εξαγωγή εξισώσεων
type: docs
weight: 30
url: /el/php-java/exporting-math-equations/
keywords:
- εξαγωγή μαθηματικών εξισώσεων
- MathML
- LaTeX
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Επιτρέψτε απρόσκοπτη εξαγωγή μαθηματικών εξισώσεων από PowerPoint σε MathML χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java — διατηρήστε τη μορφοποίηση και βελτιώστε τη συμβατότητα."
---
## **Εισαγωγή**

Το Aspose.Slides for PHP μέσω Java σας επιτρέπει να εξάγετε μαθηματικές εξισώσεις από παρουσιάσεις. Για παράδειγμα, ίσως χρειαστεί να εξάγετε τις μαθηματικές εξισώσεις στις διαφάνειες (από μια συγκεκριμένη παρουσίαση) και να τις χρησιμοποιήσετε σε άλλο πρόγραμμα ή πλατφόρμα.

{{% alert color="primary" %}} 
Μπορείτε να εξάγετε εξισώσεις σε MathML, μια δημοφιλή μορφή ή πρότυπο για μαθηματικές εξισώσεις και παρόμοιο περιεχόμενο που εμφανίζεται στο διαδίκτυο και σε πολλές εφαρμογές. 
{{% /alert %}}

## **Αποθήκευση μαθηματικών εξισώσεων ως MathML**

Ενώ οι άνθρωποι γράφουν εύκολα τον κώδικα για ορισμένες μορφές εξίσωσης όπως LaTeX, δυσκολεύονται να γράψουν τον κώδικα για MathML, επειδή το τελευταίο προορίζεται να δημιουργείται αυτόματα από εφαρμογές. Τα προγράμματα διαβάζουν και αναλύουν το MathML εύκολα επειδή ο κώδικάς του είναι σε XML, έτσι το MathML χρησιμοποιείται συνήθως ως μορφή εξόδου και εκτύπωσης σε πολλούς τομείς. 

Αυτό το δείγμα κώδικα σας δείχνει πώς να εξάγετε μια μαθηματική εξίσωση από μια παρουσίαση σε MathML:

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

## **Συχνές ερωτήσεις**

**Τι ακριβώς εξάγεται σε MathML—μια παράγραφος ή ένα μεμονωμένο μπλοκ τύπου;**

Μπορείτε να εξάγετε είτε ολόκληρη μια μαθηματική παράγραφο ([MathParagraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathparagraph/)) είτε ένα μεμονωμένο μπλοκ ([MathBlock](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathblock/)) σε MathML. Και οι δύο τύποι παρέχουν μέθοδο για εγγραφή σε MathML.

**Πώς μπορώ να καταλάβω ότι ένα αντικείμενο σε μια διαφάνεια είναι μαθηματικός τύπος και όχι απλό κείμενο ή εικόνα;**

Ένας τύπος βρίσκεται σε ένα [MathPortion](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathportion/) και έχει ένα [MathParagraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathparagraph/). Οι εικόνες και τα συνηθισμένα τμήματα κειμένου χωρίς ένα [MathParagraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathparagraph/) δεν είναι εξαγώγιμοι τύποι.

**Από πού προέρχεται το MathML σε μια παρουσίαση—είναι ειδικό για το PowerPoint ή πρότυπο;**

Η εξαγωγή στοχεύει στο πρότυπο MathML (XML). Η Aspose χρησιμοποιεί το Presentation MathML—το υποσύνολο παρουσίασης του προτύπου—που χρησιμοποιείται ευρέως σε εφαρμογές και στον ιστό.

**Υποστηρίζεται η εξαγωγή τύπων μέσα σε πίνακες, SmartArt, ομάδες κ.λπ.;**

Ναι, εάν αυτά τα αντικείμενα περιέχουν τμήματα κειμένου με ένα [MathParagraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathparagraph/) (δηλαδή αυθεντικούς τύπους PowerPoint), εξάγονται. Εάν ένας τύπος είναι ενσωματωμένος ως εικόνα, δεν εξάγεται.

**Τροποποιεί η εξαγωγή σε MathML την αρχική παρουσίαση;**

Όχι. Η δημιουργία MathML είναι μια σειριοποίηση του περιεχομένου του τύπου· δεν τροποποιεί το αρχείο της παρουσίασης.