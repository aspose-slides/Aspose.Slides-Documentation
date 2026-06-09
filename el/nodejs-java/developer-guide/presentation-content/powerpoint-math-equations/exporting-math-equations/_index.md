---
title: Export Math Equations from Presentations in JavaScript
linktitle: Export Equations
type: docs
weight: 30
url: /el/nodejs-java/exporting-math-equations/
keywords:
- εξαγωγή μαθηματικών εξισώσεων
- MathML
- LaTeX
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Αποκτήστε αδιάσπαστη εξαγωγή μαθηματικών εξισώσεων από το PowerPoint σε MathML χρησιμοποιώντας JavaScript και Aspose.Slides για Node.js—διατηρήστε τη μορφοποίηση και βελτιώστε τη συμβατότητα."
---
## **Εισαγωγή**

Το Aspose.Slides σάς επιτρέπει να εξάγετε μαθηματικές εξισώσεις από παρουσιάσεις. Για παράδειγμα, ενδέχεται να χρειαστεί να εξάγετε τις μαθηματικές εξισώσεις από διαφάνειες (από μια συγκεκριμένη παρουσίαση) και να τις χρησιμοποιήσετε σε άλλο πρόγραμμα ή πλατφόρμα.

{{% alert color="primary" %}} 
Μπορείτε να εξάγετε εξισώσεις σε MathML, μια δημοφιλής μορφή ή πρότυπο για μαθηματικές εξισώσεις και παρόμοιο περιεχόμενο που εμφανίζεται στον ιστό και σε πολλές εφαρμογές. 
{{% /alert %}}

## **Αποθήκευση μαθηματικών εξισώσεων ως MathML**

Ενώ οι άνθρωποι γράφουν εύκολα τον κώδικα για ορισμένες μορφές εξισώσεων όπως LaTeX, δυσκολεύονται να γράψουν τον κώδικα για MathML, επειδή το τελευταίο προορίζεται να δημιουργείται αυτόματα από εφαρμογές. Τα προγράμματα διαβάζουν και αναλύουν εύκολα το MathML επειδή ο κώδικάς του είναι σε XML, έτσι το MathML χρησιμοποιείται συχνά ως μορφή εξόδου και εκτύπωσης σε πολλούς τομείς. 

Αυτό το δείγμα κώδικα σας δείχνει πώς να εξάγετε μια μαθηματική εξίσωση από μια παρουσίαση σε MathML:

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

## **FAQ**

**Τι ακριβώς εξάγεται σε MathML—μια παράγραφος ή ένα μεμονωμένο μπλοκ τύπου;**

Μπορείτε να εξάγετε είτε ολόκληρη μαθηματική παράγραφο ([MathParagraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathparagraph/)) είτε ένα μεμονωμένο μπλοκ ([MathBlock](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathblock/)) σε MathML. Και οι δύο τύποι παρέχουν μέθοδο για εγγραφή σε MathML.

**Πώς μπορώ να διακρίνω ότι ένα αντικείμενο σε μια διαφάνεια είναι μαθηματικός τύπος και όχι απλό κείμενο ή εικόνα;**

Ένας τύπος βρίσκεται σε ένα [MathPortion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathportion/) και έχει ένα [MathParagraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathparagraph/). Οι εικόνες και τα κανονικά τμήματα κειμένου χωρίς ένα [MathParagraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathparagraph/) δεν είναι εξαγώγιμοι τύποι.

**Από πού προέρχεται το MathML σε μια παρουσίαση—είναι ειδικό του PowerPoint ή πρότυπο;**

Η εξαγωγή στοχεύει στο πρότυπο MathML (XML). Το Aspose χρησιμοποιεί το Presentation MathML—το υποσύνολο παρουσίασης του προτύπου—που χρησιμοποιείται ευρέως σε εφαρμογές και στο διαδίκτυο.

**Υποστηρίζεται η εξαγωγή τύπων που βρίσκονται μέσα σε πίνακες, SmartArt, ομάδες κ.λπ.;**

Ναι, εάν αυτά τα αντικείμενα περιέχουν τμήματα κειμένου με ένα [MathParagraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathparagraph/) (δηλαδή αυθεντικούς τύπους PowerPoint), εξάγονται. Εάν ένας τύπος είναι ενσωματωμένος ως εικόνα, δεν εξάγεται.

**Τροποποιεί η εξαγωγή σε MathML την αρχική παρουσίαση;**

Όχι. Η δημιουργία MathML είναι μια σειριοποίηση του περιεχομένου του τύπου· δεν τροποποιεί το αρχείο παρουσίασης.