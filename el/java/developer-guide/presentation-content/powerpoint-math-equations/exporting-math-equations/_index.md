---
title: Εξαγωγή Μαθηματικών Εξισώσεων από Παρουσιάσεις σε Java
linktitle: Εξαγωγή Εξισώσεων
type: docs
weight: 30
url: /el/java/exporting-math-equations/
keywords:
- εξαγωγή μαθηματικών εξισώσεων
- MathML
- LaTeX
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Απελευθερώστε ομαλή εξαγωγή μαθηματικών εξισώσεων από το PowerPoint σε MathML με τη χρήση Aspose.Slides για Java—διατηρήστε τη μορφοποίηση και ενισχύστε τη συμβατότητα."
---
## **Εισαγωγή**

Το Aspose.Slides σας επιτρέπει να εξάγετε μαθηματικές εξισώσεις από παρουσιάσεις. Για παράδειγμα, μπορεί να χρειαστεί να εξαγάγετε τις μαθηματικές εξισώσεις στις διαφάνειες (από μια συγκεκριμένη παρουσίαση) και να τις χρησιμοποιήσετε σε άλλο πρόγραμμα ή πλατφόρμα.

{{% alert color="primary" %}} 
Μπορείτε να εξάγετε εξισώσεις σε MathML, μια δημοφιλής μορφή ή πρότυπο για μαθηματικές εξισώσεις και παρόμοιο περιεχόμενο που εμφανίζεται στο διαδίκτυο και σε πολλές εφαρμογές. 
{{% /alert %}}

## **Αποθήκευση Μαθηματικών Εξισώσεων ως MathML**

Ενώ οι άνθρωποι γράφουν εύκολα τον κώδικα για ορισμένες μορφές εξισώσεων όπως το LaTeX, δυσκολεύονται να γράψουν τον κώδικα για το MathML, επειδή το τελευταίο προορίζεται να δημιουργείται αυτόματα από εφαρμογές. Τα προγράμματα διαβάζουν και αναλύουν το MathML εύκολα επειδή ο κώδικάς του είναι σε XML, έτσι το MathML χρησιμοποιείται συνήθως ως μορφή εξόδου και εκτύπωσης σε πολλούς τομείς. 

Αυτό το δείγμα κώδικα σας δείχνει πώς να εξάγετε μια μαθηματική εξίσωση από μια παρουσίαση σε MathML:

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

## **Συχνές Ερωτήσεις**

**Τι εξάγεται ακριβώς σε MathML—μια παράγραφος ή ένα επιμέρους μπλοκ τύπου;**

Μπορείτε να εξάγετε είτε ολόκληρη μαθηματική παράγραφο ([MathParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/mathparagraph/)) είτε ένα μεμονωμένο μπλοκ ([MathBlock](https://reference.aspose.com/slides/el/java/com.aspose.slides/mathblock/)) σε MathML. Και οι δύο τύποι παρέχουν μέθοδο για εγγραφή σε MathML.

**Πώς μπορώ να καταλάβω αν ένα αντικείμενο σε μια διαφάνεια είναι μαθηματικός τύπος και όχι κανονικό κείμενο ή εικόνα;**

Ένας τύπος βρίσκεται σε ένα [MathPortion](https://reference.aspose.com/slides/el/java/com.aspose.slides/mathportion/) και έχει ένα [MathParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/mathparagraph/). Οι εικόνες και τα κανονικά τμήματα κειμένου χωρίς ένα [MathParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/mathparagraph/) δεν είναι εξαγώγιμοι τύποι.

**Από πού προέρχεται το MathML σε μια παρουσίαση—είναι ειδικό για το PowerPoint ή πρότυπο;**

Η εξαγωγή στοχεύει στο τυπικό MathML (XML). Η Aspose χρησιμοποιεί το Presentation MathML—το υποσύνολο παρουσίασης του προτύπου—που χρησιμοποιείται ευρέως σε εφαρμογές και στο διαδίκτυο.

**Υποστηρίζεται η εξαγωγή τύπων μέσα σε πίνακες, SmartArt, ομάδες κ.λπ.;**

Ναι, εάν αυτά τα αντικείμενα περιέχουν τμήματα κειμένου με ένα [MathParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/mathparagraph/) (δηλαδή γνήσιους τύπους PowerPoint), εξάγονται. Εάν ένας τύπος είναι ενσωματωμένος ως εικόνα, δεν εξάγεται.

**Τροποποιεί η εξαγωγή σε MathML την αρχική παρουσίαση;**

Όχι. Η εγγραφή MathML είναι μια σειριοποίηση του περιεχομένου του τύπου· δεν τροποποιεί το αρχείο της παρουσίασης.