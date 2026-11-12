---
title: Προσθήκη Μαθηματικών Εξισώσεων σε Παρουσιάσεις PowerPoint σε Java
linktitle: Μαθηματικές Εξισώσεις PowerPoint
type: docs
weight: 80
url: /el/java/powerpoint-math-equations/
keywords:
- μαθηματική εξίσωση
- μαθηματικό σύμβολο
- μαθηματικός τύπος
- μαθηματικό κείμενο
- προσθήκη μαθηματικής εξίσωσης
- προσθήκη μαθηματικού συμβόλου
- προσθήκη μαθηματικού τύπου
- προσθήκη μαθηματικού κειμένου
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Εισαγωγή και επεξεργασία μαθηματικών εξισώσεων σε PowerPoint PPT και PPTX με το Aspose.Slides για Java, με υποστήριξη OMML, ελέγχων μορφοποίησης και σαφείς παραδείγματα κώδικα Java."
---
## **Επισκόπηση**

Το PowerPoint αποθηκεύει τις εξισώσεις ως Office Math Markup Language (OMML). Με το Aspose.Slides for Java, μπορείτε να δημιουργήσετε το ίδιο είδος μαθηματικού περιεχομένου προγραμματιστικά: κλάσματα, ριζικά, συναρτήσεις, όρια, τελεστές N-ary, πίνακες, ακολουθίες και μορφοποιημένα μαθηματικά μπλοκ.

Στο PowerPoint, οι χρήστες συνήθως προσθέτουν εξισώσεις από **Insert > Equation**:

![Καρτέλα Insert του PowerPoint με την εντολή Equation επιλεγμένη](powerpoint-math-equations_1.png)

Το αποτέλεσμα είναι επεξεργάσιμο μαθηματικό κείμενο στη διαφάνεια:

![Διαφάνεια PowerPoint που περιέχει επεξεργάσιμη μαθηματική εξίσωση](powerpoint-math-equations_2.png)

Το Aspose.Slides δημιουργεί αυτό το μαθηματικό κείμενο μέσω τριών κύριων αντικειμένων:

- Ένα μαθηματικό σχήμα, δημιουργημένο με [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-), είναι το σχήμα που περιέχει την εξίσωση.
- [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) αποθηκεύει το μαθηματικό περιεχόμενο μέσα στο πλαίσιο κειμένου του σχήματος.
- [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) περιέχει ένα ή περισσότερα αντικείμενα [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/).

Τα περισσότερα παραδείγματα παρακάτω χρησιμοποιούν το [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) και τις αμετάβλητες μεθόδους από το [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/) για να διατηρήσουν τον κώδικα σύντομο και ευανάγνωστο.

Για σενάρια εξαγωγής MathML, δείτε [Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις σε Java](/slides/el/java/exporting-math-equations/).

## **Δημιουργία εξίσωσης**

Αυτό το παράδειγμα χρησιμοποιεί το [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) για να δημιουργήσει ένα μαθηματικό σχήμα και προσθέτει το θεώρημα του Πυθαγόρα:

![Η εξίσωση c στο τετράγωνο ίσον a στο τετράγωνο συν b στο τετράγωνο](powerpoint-math-equations_3.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) δημιουργεί ένα σχήμα που ήδη περιέχει μια μαθηματική παραγράφο. Προσπελάστε το πρώτο [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/), καλέστε το [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--), και προσθέστε μαθηματικά μπλοκ ή μαθηματικά στοιχεία σε αυτό.
{{% /alert %}}

## **Προσθήκη κλασμάτων**

Χρησιμοποιήστε το [divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) για να δημιουργήσετε ένα κλάσμα. Μπορείτε να επιλέξετε στυλ κλάσματος με το [MathFractionTypes](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/).

![Ένα λοξό μαθηματικό κλάσμα που δείχνει 1 διά x](powerpoint-math-equations_4.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για ένα στοιβαγμένο κλάσμα, χρησιμοποιήστε το [MathFractionTypes.Bar](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/#Bar):

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Προσθήκη ριζικών**

Χρησιμοποιήστε το [radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) για να δημιουργήσετε τετραγωνική ρίζα, κυβική ρίζα ή άλλη ρίζα. Το τρέχον στοιχείο γίνεται η βάση και το όρισμα γίνεται ο εκθέτης.

![Μία έκφραση n-οστής ρίζας με x κάτω από το σύμβολο της ρίζας](powerpoint-math-equations_5.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη συναρτήσεων και ορίων**

Χρησιμοποιήστε το [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) ή το [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) για συναρτήσεις όπως `sin(x)`, `log(x)`, ή προσαρμοσμένα ονόματα συναρτήσεων. Για όρια, τοποθετήστε το `lim` σε ένα [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/mathlimit/) ή χρησιμοποιήστε το [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-).

![Το όριο του x καθώς το x πλησιάζει το άπειρο](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για προσαρμοσμένο όνομα συνάρτησης, κάντε το όνομα της συνάρτησης το τρέχον στοιχείο και καλέστε το [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) με το όρισμά του:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **Προσθήκη τελεστών N-ary και ολοκληρωμάτων**

Χρησιμοποιήστε το [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) για αθροίσεις, ενώσεις, τομές και άλλους μεγάλους τελεστές. Χρησιμοποιήστε το [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) για ολοκληρώματα. Και οι δύο μέθοδοι επιτρέπουν τον καθορισμό κατώτερου και ανώτερου ορίου.

![Μια άθροιση με κατώτερο και ανώτερο όριο](powerpoint-math-equations_7.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Οι τελεστές N-ary είναι για μεγάλους τελεστές με προαιρετικά όρια. Απλοί τελεστές όπως `+`, `-` και `=` συνήθως προστίθενται ως [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) και ενσωματώνονται στην έκφραση.

Για ολοκλήρωμα, χρησιμοποιήστε το [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-):

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Προσθήκη πινάκων**

Χρησιμοποιήστε το [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) για γραμμές και στήλες. Οι πίνακες δεν περιλαμβάνουν αγκύλες από προεπιλογή, οπότε περιβάλλετε τον πίνακα όταν χρειάζεστε παρενθέσεις, αγκύλες ή άγκινα.

![Μαθηματικός πίνακας δύο γραμμών με ένα κενό κελί](powerpoint-math-equations_10.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη ακολουθιών εξισώσεων**

Χρησιμοποιήστε το [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) όταν χρειάζεστε ευθυγραμμισμένες εξισώσεις ή κατακόρυφο στοίβαγμα εκφράσεων.

![Κατακόρυφη μαθηματική ακολουθία με το x πάνω από το y](powerpoint-math-equations_11.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Στοίχιση ακολουθίας με τα γειτονικά στοιχεία**

[setBaseJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setBaseJustification-int-) ελέγχει την κατακόρυφη στοίχιση μιας ακολουθίας σε σχέση με τα μαθηματικά στοιχεία δίπλα της. Το παρακάτω παράδειγμα συγκρίνει τη στοίχιση με την πρώτη γραμμή, το κέντρο της ακολουθίας και την τελευταία γραμμή.

Το ακόλουθο παράδειγμα δημιουργεί τρεις πανομοιότυπες ακολουθίες, καθεμία με τρεις γραμμές και τα γειτονικά στοιχεία `A=` και `=B`. Όλο το μαθηματικό κείμενο χρησιμοποιεί Cambria Math σε μέγεθος 24 σημεία. Μόνο η στοίχιση της ακολουθίας αλλάζει.

```java
import com.aspose.slides.*;
import java.awt.Color;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);
    
    int[] alignments = { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };
    String[] alignmentNames = { "Top", "Center", "Bottom" };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        label.getTextFrame().setText(alignmentNames[i]);
        IPortionFormat labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(FillType.Solid);
        labelFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        IAutoShape mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        IMathParagraph mathParagraph = ((IMathPortion) mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
        mathParagraph.setJustification(MathJustification.LeftJustified);

        IMathElement[] rows = { factory.createText("x+y=3"), factory.createText("x-y=1"), factory.createText("x=2") };
        MathArray equationArray = new MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        MathematicalText leftText = factory.createText("A=");
        MathematicalText rightText = factory.createText("=B");
        IMathBlock equation = new MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η παρακάτω σύγκριση δείχνει την αποθηκευμένη παρουσίαση στο PowerPoint. Παρατηρήστε τη θέση του `A=` και `=B` δίπλα σε κάθε ακολουθία.

![Ακολουθίες εξισώσεων στο PowerPoint με στοίχιση Πάνω, Κέντρο και Κάτω και πανομοιότυπα γειτονικά στοιχεία](equation-array-alignment.png)

### **Διαμόρφωση απόστασης γραμμών**

[setRowSpacingRule](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacingRule-int-) επιλέγει τον κανόνα απόστασης για τις γραμμές μέσα στην ακολουθία. [setRowSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacing-long-) παρέχει μια αριθμητική τιμή για έναν ρητό κανόνα απόστασης και αγνοείται από τους προκαθορισμένους κανόνες.

Για ακριβή απόσταση, η τιμή μετριέται σε σημεία. Για ανάλογη απόσταση, μετριέται σε μισές γραμμές: η τιμή `3` στο παράδειγμα καθορίζει 1,5 γραμμές. Ορίστε και τις δύο ιδιότητες όταν καθορίζετε ρητή τιμή· η αλλαγή μόνο της αριθμητικής τιμής δεν επιλέγει κανόνα απόστασης.

Το παρακάτω παράδειγμα αποθηκεύει πέντε παρουσιάσεις με τις ίδιες εξισώσεις, στοίχιση και ρυθμίσεις γραμματοσειράς. Τα πρώτα τρία χρησιμοποιούν προεπιλογές· τα τελευταία δύο εμφανίζουν ρητές τιμές.

```java
import com.aspose.slides.*;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
int[] rules = { MathRowSpacingRule.SingleLineGap, MathRowSpacingRule.OneAndAHalfLineGap, MathRowSpacingRule.TwoLineGap, MathRowSpacingRule.Exactly, MathRowSpacingRule.Multiple };
int[] spacingValues = { 0, 0, 0, 20, 3 };
String[] ruleNames = { "SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple" };

for (int i = 0; i < rules.length; i++) {
    String fileName = "equation-array-" + ruleNames[i] + ".pptx";
    Presentation presentation = new Presentation();
    try {
        IAutoShape mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        IMathParagraph mathParagraph = ((IMathPortion) paragraph.getPortions().get_Item(0)).getMathParagraph();
        mathParagraph.setJustification(MathJustification.LeftJustified);

        IMathElement[] rows = { factory.createText("x+y=3"), factory.createText("x-y=1"), factory.createText("x=2") };
        MathArray equationArray = new MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(spacingValues[i]);
        MathematicalText leftText = factory.createText("A=");
        MathematicalText rightText = factory.createText("=B");
        IMathBlock equation = new MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

Η απόσταση γραμμών της ακολουθίας είναι ξεχωριστή από την απόσταση παραγράφου. Τα [setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) και [setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) προσθέτουν χώρο γύρω από την περιέχουσα παράγραφο, όχι μεταξύ των γραμμών της ακολουθίας. Ομοίως, το [IMathParagraph.setJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#setJustification-int-) τοποθετεί οριζόντια ολόκληρη τη μαθηματική παράγραφο· δεν αντικαθιστά τη ρύθμιση κατακόρυφης στοίχισης της ακολουθίας.

## **Προσθήκη τριγωνομετρικών συναρτήσεων**

Χρησιμοποιήστε το [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) όταν το όρισμα είναι το τρέχον στοιχείο και το όνομα της συνάρτησης είναι γνωστό.

![Η τριγωνομετρική συνάρτηση cos εφαρμόζεται στο 2x](powerpoint-math-equations_6.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη δεικτών και εκθέτων**

Χρησιμοποιήστε τις βοηθητικές συναρτήσεις υποδείκτη και υπερδείκτη για δείκτες και εκθέτες. Όταν οι δείκτες πρέπει να εμφανίζονται στα αριστερά της βάσης, χρησιμοποιήστε το [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-).

![Ένα κεφαλαίο Y με αριστερό υποδείκτη 1 και υπερδείκτη n](powerpoint-math-equations_9.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη οριοθετών**

Χρησιμοποιήστε το [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) για να τοποθετήσετε μια έκφραση μέσα σε οριοθέτες. Μπορείτε επίσης να ορίσετε χαρακτήρα διαχωριστή για εκφράσεις οριοθέτη που περιέχουν πολλά στοιχεία.

![Μία έκφραση οριοθέτη που περιέχει x, y και z χωρισμένα με κατακόρυφες γραμμές](powerpoint-math-equations_13.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Μέγεθος και στοίχιση οριοθετών**

Περιγράψτε `true` στο [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) για να επιτρέψετε στα παρενθέσεις να μεγαλώσουν γύρω από ένα ψηλό όπεντ, ή περιγράψτε `false` για να παραμείνουν στο κανονικό τους μέγεθος. Χρησιμοποιήστε το [setDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) με μία από τις δύο τιμές [MathDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/mathdelimitershape/). Το `Centered` κεντράρει τις παρενθέσεις στον άξονα των μαθηματικών, που διέρχεται από το μέσο του συμβόλου ισότητας. Το `Match` τις ευθυγραμμίζει με το περιεχόμενο που περιβάλλεται. Και οι δύο ρυθμίσεις επηρεάζουν μόνο τους οριοθέτες. Η εσωτερική έκφραση παραμένει η ίδια.

Το παράδειγμα τοποθετεί ένα κλάσμα στον εκθέτη του `x` ώστε η έκφραση να εκτείνεται περισσότερο πάνω από τη γραμμή βάσης από ό,τι από κάτω. Όλες οι τέσσερις εξισώσεις χρησιμοποιούν τις ίδιες παρενθέσεις και ρυθμίσεις γραμματοσειράς.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (int row = 0; row < 2; row++) {
        for (int column = 0; column < 2; column++) {
            IMathFraction fraction = new MathematicalText("a + b").divide("c + d");
            IMathSuperscriptElement power = new MathematicalText("x").setSuperscript(fraction);
            IMathDelimiter delimiter = power.enclose('(', ')');
            delimiter.setGrowToMatchOperandHeight(row == 0);
            delimiter.setDelimiterShape(column == 0 ? MathDelimiterShape.Centered : MathDelimiterShape.Match);

            IAutoShape mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            MathPortion portion = (MathPortion) mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            IMathBlock equation = new MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Στο PowerPoint, συγκρίνετε τις γραμμές για να δείτε το αποτέλεσμα της αύξησης. Στην κορυφαία γραμμή, οι παρενθέσεις μεγαλώνουν ώστε να περιβάλουν τον εκθέτη και φαίνονται ίδια για και τις δύο μορφές. Στην κάτω γραμμή, η αύξηση είναι απενεργοποιημένη. Οι μικρότερες παρενθέσεις στα αριστερά (`Centered`) ευθυγραμμίζονται με το σύμβολο ισότητας, ενώ αυτές στα δεξιά (`Match`) βρίσκονται πιο ψηλά γύρω από την έκφραση.

![Τέσσερις εξισώσεις στο PowerPoint με ενεργή ανάπτυξη οριοθέτη πάνω και απενεργοποιημένη κάτω, και Centered στα αριστερά και Match στα δεξιά](delimiter-sizing.png)

## **Προσθήκη πλαισίου περιγράμματος**

Καλέστε το [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) σε ένα κλάσμα για να περιτυλίξετε ολόκληρη την έκφραση. Το επιστραφόμενο [IMathBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/) εμφανίζει όλες τις τέσσερις πλευρές από προεπιλογή. Χρησιμοποιήστε τα [setHideTop](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), και [setHideRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideRight-boolean-) για να αφαιρέσετε μεμονωμένες πλευρές.

Το παράδειγμα τοποθετεί έξι αντίτυπα του ίδιου κλάσματος σε μία διαφάνεια. Για να δείξετε ακύρωση, κρύψτε όλες τις τέσσερις πλευρές και περάστε `true` στο [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) για μια ανιπτή διαγώνιο (↗) ή στο [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) για μια κατιούσα διαγώνιο (↘). Μπορείτε επίσης να χρησιμοποιήσετε τα [setStrikethroughHorizontal](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) ή [setStrikethroughVertical](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) με οποιονδήποτε συνδυασμό ορατών πλευρών.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    class FractionBuilder {
        IMathBorderBox addFraction(float x, float y, boolean hideBorder) {
            IMathFraction fraction = new MathematicalText("x+1").divide("y+2");
            IMathBorderBox box = fraction.toBorderBox();
            box.setHideTop(hideBorder);
            box.setHideBottom(hideBorder);
            box.setHideLeft(hideBorder);
            box.setHideRight(hideBorder);

            IAutoShape shape = slide.getShapes().addMathShape(x, y, 160, 90);
            MathPortion portion = (MathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(28);
            portion.getMathParagraph().add(new MathBlock(box));
            return box;
        }
    }

    FractionBuilder builder = new FractionBuilder();
    builder.addFraction(10, 10, false);

    IMathBorderBox partial = builder.addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    builder.addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    builder.addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    builder.addFraction(190, 120, true).setStrikethroughHorizontal(true);
    builder.addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Έξι επεξεργάσιμα κλάσματα στο PowerPoint. Πρώτη γραμμή: πλήρες περίγραμμα, κάτω και αριστερές πλευρές, ανιπτή διαγώνιο. Δεύτερη γραμμή: κατιούσα διαγώνιο, οριζόντια γραμμή, κάθετη γραμμή με πλήρες περίγραμμα](border-box-fractions.png)

Σε αυτό το κλάσμα, η οριζόντια γραμμή διασχίζει τη γραμμή του κλάσματος. Η κάθετη γραμμή διασχίζει τόσο τον αριθμητή όσο και τον παρονομαστή ενώ το περιβάλλον περίγραμμα παραμένει ορατό. Αυτές οι γραμμές διακοσμούν ολόκληρη την έκφραση. Η κοινή διαγράμμιση κειμένου εφαρμόζεται σε χαρακτήρες σε μια ακολουθία κειμένου. Αφού ξανανοίξετε την παρουσίαση στο PowerPoint, μπορείτε ακόμη να επεξεργαστείτε τον αριθμητή και τον παρονομαστή ανεξάρτητα.

## **Ομαδοποίηση όρων**

Χρησιμοποιήστε το [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) για να τοποθετήσετε έναν χαρακτήρα ομαδοποίησης πάνω ή κάτω από μια έκφραση. Προσθέστε ένα όριο για να ετικετοποιήσετε τους ομαδοποιημένους όρους.

![Η έκφραση x συν y ομαδοποιημένη με ετικέτα οποιοδήποτε κείμενο κάτω από αυτήν](powerpoint-math-equations_15.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Μορφοποίηση στοιχείων μαθηματικών**

Χρησιμοποιήστε βοηθητικές μορφοποιήσεις μόνο όπου διευκρινίζουν τον τύπο. Για παράδειγμα, το [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--) τοποθετεί μια γραμμή πάνω από ένα μαθηματικό στοιχείο.

![Μαθηματική έκφραση ABC με γραμμή πάνω](powerpoint-math-equations_14.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Μορφοποίηση κειμένου σε υπάρχουσα εξίσωση**

Για να μορφοποιήσετε κείμενο σε όλη μια υπάρχουσα εξίσωση, διασχίστε το δέντρο στοιχείων κάθε μαθηματικού μπλοκ. Το [IMathElement.getChildren](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#getChildren--) επιστρέφει μόνο τα άμεσα παιδιά, έτσι καλέστε το αναδρομικά για να φτάσετε στο κείμενο μέσα σε κλάσματα, εκθέτες, ριζικά και άλλες ενσωματωμένες δομές. Ελέγξτε το τρέχον στοιχείο καθώς και τα παιδιά του για να συμπεριλάβετε το αρχικό στοιχείο όταν είναι [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/).

Αυτό το παράδειγμα υποθέτει ότι το `input.pptx` περιέχει μια εξίσωση όπως `z = xᵢ / ∛y`, με ένα κλάσμα που περιέχει υποδείκτη στο αριθμητή του και ριζικό στο παρονομαστή του. Η επεξεργασία μόνο των στοιχείων ανώτερου επιπέδου του μπλοκ θα χάσει το κείμενο μέσα στο κλάσμα. Το παράδειγμα εντοπίζει μαθηματικά τμήματα σε πλαίσια κειμένου διαφάνειας, προσπελαύνει τα μπλοκ τους μέσω του [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--), και χρησιμοποιεί το [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) για να ορίσει το μέγεθος γραμματοσειράς σε 28 σημεία μέσω της μεθόδου [getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/#getFormat--) του κάθε στοιχείου κειμένου.

```java
import com.aspose.slides.*;

class MathTextFormatter {
    void formatMathText(IMathElement element) {
        if (element instanceof MathematicalText) {
            MathematicalText text = (MathematicalText) element;
            text.getFormat().setFontHeight(28);
        }

        for (IMathElement child : element.getChildren()) {
            formatMathText(child);
        }
    }
}

MathTextFormatter formatter = new MathTextFormatter();
Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (portion instanceof IMathPortion) {
                        IMathPortion mathPortion = (IMathPortion) portion;
                        for (IMathBlock block : mathPortion.getMathParagraph()) {
                            formatter.formatMathText(block);
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αποθηκευμένη παρουσίαση περιέχει την ενημερωμένη μορφοποίηση κειμένου σε κάθε επίπεδο κάθε επεξεργασμένης εξίσωσης, διατηρώντας το περιεχόμενο κειμένου και τη μαθηματική δομή.

## **Γρήγορη αναφορά**

| Ενέργεια | Κύριο API |
| --- | --- |
| Δημιουργία μαθηματικού κειμένου | [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) |
| Συνδυασμός στοιχείων | [IMathElement.join](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| Δημιουργία κλασμάτων | [IMathElement.divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| Προσθήκη υπερδείκτη ή υποδείκτη | [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| Προσθήκη συναρτήσεων | [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| Προσθήκη ριζικών | [IMathElement.radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| Προσθήκη ορίων | [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| Προσθήκη δεικτών αριστερά | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Προσθήκη αθροίσεων και ολοκληρωμάτων | [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Προσθήκη πινάκων | [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) |
| Προσθήκη ακολουθιών εξισώσεων | [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) |
| Προσθήκη οριοθετών | [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| Προσθήκη γραμμών και περιγραμμάτων | [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) |
| Ομαδοποίηση όρων | [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **Συχνές ερωτήσεις**

**Μπορώ να επεξεργαστώ μια υπάρχουσα εξίσωση PowerPoint;**

Ναι. Ανοίξτε την παρουσίαση, βρείτε το σ Shape που περιέχει ένα [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/), καλέστε το [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--), και ενημερώστε τα μαθηματικά μπλοκ σε αυτήν την παράγραφο.

**Αποθηκεύονται οι εξισώσεις ως επεξεργάσιμο μαθηματικό PowerPoint;**

Ναι. Όταν αποθηκεύετε σε PPTX, το Aspose.Slides γράφει την εξίσωση ως επεξεργάσιμο περιεχόμενο Office math.

**Μπορώ να εξάγω εξισώσεις σε LaTeX;**

Ναι. Αποκτήστε το [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) της εξίσωσης από το [IMathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/), και καλέστε το [IMathParagraph.toLatex](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#toLatex--) για να το εξαγάγετε απευθείας. Για πλήρες παράδειγμα, δείτε [Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις σε Java](/slides/el/java/exporting-math-equations/#export-math-equations-to-latex).