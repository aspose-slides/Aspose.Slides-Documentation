---
title: Προσθήκη μαθηματικών εξισώσεων σε παρουσιάσεις PowerPoint με JavaScript
linktitle: Μαθηματικές εξισώσεις PowerPoint
type: docs
weight: 80
url: /el/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Εισαγωγή και επεξεργασία μαθηματικών εξισώσεων σε PowerPoint PPT και PPTX με Aspose.Slides για Node.js μέσω Java, με υποστήριξη OMML, ελέγχων μορφοποίησης και σαφών παραδειγμάτων κώδικα JavaScript."
---
## **Επισκόπηση**

Το PowerPoint αποθηκεύει εξισώσεις ως Office Math Markup Language (OMML). Με το Aspose.Slides για Node.js μέσω Java, μπορείτε να δημιουργήσετε προγραμματιστικά το ίδιο είδος μαθηματικού περιεχομένου: κλάσματα, ρίζες, συναρτήσεις, όρια, τελεστές N‑ary, πίνακες, σύνολα (arrays) και μορφοποιημένα μαθηματικά μπλοκ.

Στο PowerPoint, οι χρήστες συνήθως προσθέτουν εξισώσεις από **Insert > Equation**:

![Καρτέλα Insert του PowerPoint με την εντολή Equation επιλεγμένη](powerpoint-math-equations_1.png)

Το αποτέλεσμα είναι επεξεργάσιμο μαθηματικό κείμενο στη διαφάνεια:

![Διαφάνεια PowerPoint που περιέχει επεξεργάσιμη μαθηματική εξίσωση](powerpoint-math-equations_2.png)

Το Aspose.Slides δημιουργεί αυτό το μαθηματικό κείμενο μέσω τριών κύριων αντικειμένων:

- Ένα μαθηματικό σχήμα, δημιουργημένο με [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape), είναι το σχήμα που περιέχει την εξίσωση.
- Το [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) αποθηκεύει το μαθηματικό περιεχόμενο μέσα στο πλαίσιο κειμένου του σχήματος.
- Το [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) περιέχει ένα ή περισσότερα αντικείμενα [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/).

Τα περισσότερα παραδείγματα παρακάτω χρησιμοποιούν το [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) και τις fluent μεθόδους από το [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) για να κρατήσουν τον κώδικα σύντομο και ευανάγνωστο.

Για σενάρια εξαγωγής MathML, δείτε την ενότητα [Export Math Equations from Presentations in Node.js via Java](/slides/el/nodejs-java/exporting-math-equations/).

## **Δημιουργία εξίσωσης**

Αυτό το παράδειγμα χρησιμοποιεί το [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) για να δημιουργήσει ένα μαθηματικό σχήμα και προσθέτει το θεώρημα του Πυθαγόρα:

![Η εξίσωση c² = a² + b²](powerpoint-math-equations_3.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equation = new aspose.slides.MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Σημείωση" %}}
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) δημιουργεί ένα σχήμα που ήδη περιέχει μια μαθηματική παράγραφο. Πρόσβαση στην πρώτη [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), κλήση του [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) και προσθήκη μαθηματικών μπλοκ ή μαθηματικών στοιχείων σε αυτήν.
{{% /alert %}}

## **Προσθήκη κλασμάτων**

Χρησιμοποιήστε το [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) για να δημιουργήσετε ένα κλάσμα. Μπορείτε να επιλέξετε στυλ κλάσματος με το [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/).

![Καμπύλο μαθηματικό κλάσμα που δείχνει το 1 ÷ x](powerpoint-math-equations_4.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let fraction = new aspose.slides.MathematicalText("1")
            .divide("x", aspose.slides.MathFractionTypes.Skewed);

    mathParagraph.add(new aspose.slides.MathBlock(fraction));

    presentation.save("fraction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για στοίβα κλάσματος, χρησιμοποιήστε το [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Προσθήκη ριζών**

Χρησιμοποιήστε το [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) για να δημιουργήσετε τετραγωνική ρίζα, κύβο ή άλλη ρίζα. Το τρέχον στοιχείο γίνεται η βάση, και το όρισμα το εκθέτη.

![Έκφραση ριζικού n‑οστού με x κάτω από το σύμβολο ρίζας](powerpoint-math-equations_5.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let radical = new aspose.slides.MathematicalText("x")
            .radical("n");

    mathParagraph.add(new aspose.slides.MathBlock(radical));

    presentation.save("radical.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη συναρτήσεων και ορίων**

Χρησιμοποιήστε το [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) ή το [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) για συναρτήσεις όπως `sin(x)`, `log(x)` ή προσαρμοσμένα ονόματα συναρτήσεων. Για όρια, τοποθετήστε το `lim` σε ένα [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) ή χρησιμοποιήστε το [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit).

![Το όριο του x καθώς το x τείνει προς το άπειρο](powerpoint-math-equations_8.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let limit = new aspose.slides.MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new aspose.slides.MathBlock(limit));

    presentation.save("functions-and-limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για προσαρμοσμένο όνομα συνάρτησης, κάντε το όνομα της συνάρτησης τρέχον στοιχείο και καλέστε το [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) με το όρισμά του:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Προσθήκη τελεστών N‑ary και ολοκληρωμάτων**

Χρησιμοποιήστε το [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) για αθροίσεις, ενώσεις, τομές και άλλους μεγάλους τελεστές. Χρησιμοποιήστε το [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) για ολοκληρώματα. Και οι δύο μέθοδοι επιτρέπουν ορισμό κάτω και πάνω ορίων.

![Αθροισμός με κάτω και πάνω όρια](powerpoint-math-equations_7.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let summationBase = new aspose.slides.MathematicalText("x")
            .setSuperscript("k")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("n-k"));

    let summation = summationBase.nary(aspose.slides.MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new aspose.slides.MathBlock(summation));

    presentation.save("nary-operators.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Οι τελεστές N‑ary είναι για μεγάλους τελεστές με προαιρετικά όρια. Οι απλοί τελεστές όπως `+`, `-` και `=` προστίθενται συνήθως ως [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) και ενσωματώνονται στην έκφραση.

Για ολοκλήρωμα, χρησιμοποιήστε το [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Προσθήκη πινάκων**

Χρησιμοποιήστε το [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) για γραμμές και στήλες. Οι πίνακες δεν περιλαμβάνουν αγκύλες από προεπιλογή, έτσι τοποθετήστε τον πίνακα μέσα σε παρενθέσεις, αγκύλες ή άγκιστρα όταν χρειάζεται.

![Μαθηματικός πίνακας δύο σειρών με ένα κενό κελί](powerpoint-math-equations_10.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let matrix = new aspose.slides.MathMatrix(2, 3);
    matrix.set_Item(0, 0, new aspose.slides.MathematicalText("1"));
    matrix.set_Item(0, 1, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 0, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 1, new aspose.slides.MathematicalText("2"));
    matrix.set_Item(1, 2, new aspose.slides.MathematicalText("y"));

    mathParagraph.add(new aspose.slides.MathBlock(matrix));

    presentation.save("matrix.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη συνόλων εξισώσεων**

Χρησιμοποιήστε το [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) όταν χρειάζεστε ευθυγραμμισμένες εξισώσεις ή κάθετη στοίβα εκφράσεων.

![Κάθετη μαθηματική σειρά με x πάνω από y](powerpoint-math-equations_11.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equationArray = new aspose.slides.MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new aspose.slides.MathBlock(equationArray));

    presentation.save("equation-array.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Στοίχιση σειράς με τα γύρω στοιχεία**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) ελέγχει την κατακόρυφη στοίχιση μιας σειράς σε σχέση με τα μαθηματικά στοιχεία δίπλα της. Το παρακάτω παράδειγμα συγκρίνει τη στοίχιση με την πρώτη γραμμή, το κέντρο της σειράς και την τελευταία γραμμή.

Το επόμενο παράδειγμα δημιουργεί τρεις ίδιες σειρές, καθεμία με τρεις γραμμές και τα γειτονικά στοιχεία `A=` και `=B`. Όλο το μαθηματικό κείμενο χρησιμοποιεί Cambria Math σε μέγεθος 24 σημεία. Μόνο η στοίχιση της σειράς αλλάζει.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [slides.MathVerticalAlignment.Top, slides.MathVerticalAlignment.Center, slides.MathVerticalAlignment.Bottom];
    const alignmentNames = ["Top", "Center", "Bottom"];

    for (let i = 0; i < alignments.length; i++) {
        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(alignmentNames[i]);
        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));
        const mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η ακόλουθη σύγκριση δείχνει την αποθηκευμένη παρουσίαση στο PowerPoint. Παρατηρήστε τη θέση των `A=` και `=B` δίπλα σε κάθε σειρά.

![Σειρές εξισώσεων στο PowerPoint με στοίχιση Πάνω, Κέντρο και Κάτω και ίδια γειτονικά στοιχεία](equation-array-alignment.png)

### **Διαμόρφωση απόστασης γραμμών**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) επιλέγει τον κανόνα απόστασης για τις γραμμές εντός της σειράς. [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) παρέχει αριθμητική τιμή για ρητό κανόνα απόστασης και αγνοείται από τους προκαθορισμένους κανόνες.

Για ακριβή απόσταση, η τιμή μετράται σε σημεία. Για αναλογική απόσταση, μετράται σε μισές γραμμές: η τιμή `3` στο παράδειγμα αντιστοιχεί σε 1,5 γραμμές. Θέστε και τις δύο ιδιότητες όταν ορίζετε ρητή τιμή· η αλλαγή μόνο της αριθμητικής τιμής δεν επιλέγει κανόνα απόστασης.

Το παράδειγμα παρακάτω αποθηκεύει πέντε παρουσιάσεις με τις ίδιες εξισώσεις, στοίχηση και ρυθμίσεις γραμματοσειράς. Οι πρώτες τρεις χρησιμοποιούν προκαθορισμένα σύνολα· οι τελευταίες δύο δείχνουν ρητές τιμές.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const rules = [slides.MathRowSpacingRule.SingleLineGap, slides.MathRowSpacingRule.OneAndAHalfLineGap, slides.MathRowSpacingRule.TwoLineGap, slides.MathRowSpacingRule.Exactly, slides.MathRowSpacingRule.Multiple];
const spacingValues = [0, 0, 0, 20, 3];
const ruleNames = ["SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple"];

for (let i = 0; i < rules.length; i++) {
    const fileName = "equation-array-" + ruleNames[i] + ".pptx";
    const presentation = new slides.Presentation();
    try {
        const mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        const paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        const mathParagraph = paragraph.getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(slides.MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(java.newLong(spacingValues[i]));
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

Η απόσταση γραμμών της σειράς είναι ξεχωριστή από την απόσταση παραγράφου. Τα [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) και [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) προσθέτουν χώρο γύρω από την περιέχουσα παράγραφο, όχι μεταξύ των γραμμών της σειράς. Αντίστροφα, η μέθοδος [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) τοποθετεί ολόκληρη τη μαθηματική παράγραφο οριζόντια· δεν αντικαθιστά τη ρύθμιση κάθετης στοίχισης της σειράς.

## **Προσθήκη τριγωνομετρικών συναρτήσεων**

Χρησιμοποιήστε το [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) όταν το όρισμα είναι το τρέχον στοιχείο και το όνομα της συνάρτησης είναι γνωστό.

![Η τριγωνομετρική συνάρτηση cos εφαρμοσμένη στο 2x](powerpoint-math-equations_6.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let cosine = new aspose.slides.MathematicalText("2x")
            .asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new aspose.slides.MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη δεικτών και εκθέτες**

Χρησιμοποιήστε τις βοηθητικές συναρτήσεις δείκτη και εκθέτη για δείκτες και δυνάμεις. Όταν οι δείκτες πρέπει να εμφανίζονται στην αριστερή πλευρά της βάσης, χρησιμοποιήστε το [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Ένα κεφαλαίο Y με αριστερό δείκτη 1 και εκθέτη n](powerpoint-math-equations_9.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let scripts = new aspose.slides.MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new aspose.slides.MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη οριοθετών**

Χρησιμοποιήστε το [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) για να τοποθετήσετε μια έκφραση μέσα σε οριοθέτες. Μπορείτε επίσης να ορίσετε χαρακτήρα διαχωριστή για εκφράσεις οριοθετών που περιέχουν πολλά στοιχεία.

![Έκφραση οριοθέτη που περιέχει x, y και z χωρισμένα με κάθετες γραμμές](powerpoint-math-equations_13.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let delimiter = new aspose.slides.MathematicalText("x")
            .join("y")
            .join("z")
            .enclose(java.newChar('<'), java.newChar('>'));
    delimiter.setSeparatorCharacter(java.newChar('|'));

    mathParagraph.add(new aspose.slides.MathBlock(delimiter));

    presentation.save("delimiters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Μέγεθος και στοίχιση οριοθετών**

Περάστε `true` στο [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) ώστε οι παρενθέσεις μεγαλώνουν γύρω από ένα ψηλό τελεστή, ή `false` για να διατηρηθούν στο κανονικό τους μέγεθος. Χρησιμοποιήστε το [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) με μία από τις δύο τιμές του [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/). Το `Centered` κεντράρει τις παρενθέσεις στον μαθηματικό άξονα, που διέρχεται από το κέντρο του συμβόλου ίσου. Το `Match` τις ευθυγραμμίζει με το περιεχόμενο που περιβάλλουν. Και οι δύο ρυθμίσεις επηρεάζουν μόνο τους οριοθέτες. Η έκφραση μέσα παραμένει η ίδια.

Το παράδειγμα τοποθετεί ένα κλάσμα σε εκθέτη του `x` ώστε η έκφραση να εκτείνεται περισσότερο πάνω από τη βάση απ’ ό,τι κάτω. Οι τέσσερις εξισώσεις χρησιμοποιούν τις ίδιες παρενθέσεις και ρυθμίσεις γραμματοσειράς.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    for (let row = 0; row < 2; row++) {
        for (let column = 0; column < 2; column++) {
            const fraction = new slides.MathematicalText("a + b").divide("c + d");
            const power = new slides.MathematicalText("x").setSuperscript(fraction);
            const delimiter = power.enclose(java.newChar('('), java.newChar(')'));
            delimiter.setGrowToMatchOperandHeight(row === 0);
            delimiter.setDelimiterShape(column === 0 ? slides.MathDelimiterShape.Centered : slides.MathDelimiterShape.Match);

            const mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            const portion = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            const equation = new slides.MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Στο PowerPoint, συγκρίνετε τις γραμμές για να δείτε το αποτέλεσμα της ανάπτυξης. Στην πρώτη γραμμή, οι παρενθέσεις μεγαλώνουν για να περικλείσουν τον εκθέτη και φαίνονται παρόμοιες για τα δύο σχήματα. Στη δεύτερη γραμμή, η ανάπτυξη είναι ανενεργή. Οι μικρότερες παρενθέσεις στα αριστερά (`Centered`) ευθυγραμμίζονται με το σύμβολο ίσου, ενώ εκείνες στα δεξιά (`Match`) ανυψώνονται γύρω από την έκφραση.

![Τέσσερις εξισώσεις στο PowerPoint με ενεργή ανάπτυξη οριοθέτη παραπάνω και ανενεργή παρακάτω, και Centered αριστερά και Match δεξιά](delimiter-sizing.png)

## **Προσθήκη πλαισίου περιγράμματος**

Καλέστε το [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) σε ένα κλάσμα για να περικλείσετε ολόκληρη την έκφραση. Το επιστρεφόμενο [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) εμφανίζει όλες τις τέσσερις πλευρές από προεπιλογή. Χρησιμοποιήστε τα [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) και [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) για να αφαιρέσετε μεμονωμένες πλευρές.

Το παράδειγμα τοποθετεί έξι αντίγραφα του ίδιου κλάσματος σε μία διαφάνεια. Για να δείξετε ακύρωση, κρύψτε όλες τις τέσσερις πλευρές και περάστε `true` στο [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) για μια ανηφορική διαγώνιο (↗) ή στο [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) για μια καθοδική διαγώνιο (↘). Μπορείτε επίσης να χρησιμοποιήσετε το [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) ή το [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) με οποιονδήποτε συνδυασμό ορατών πλευρών.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    function addFraction(x, y, hideBorder) {
        const fraction = new slides.MathematicalText("x+1").divide("y+2");
        const box = fraction.toBorderBox();
        box.setHideTop(hideBorder);
        box.setHideBottom(hideBorder);
        box.setHideLeft(hideBorder);
        box.setHideRight(hideBorder);

        const shape = slide.getShapes().addMathShape(x, y, 160, 90);
        const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        portion.getPortionFormat().setFontHeight(28);
        const block = new slides.MathBlock(box);
        portion.getMathParagraph().add(block);
        return box;
    }

    addFraction(10, 10, false);

    const partial = addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    addFraction(190, 120, true).setStrikethroughHorizontal(true);
    addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Έξι επεξεργάσιμα κλάσματα στο PowerPoint. Πάνω σειρά: πλήρες περίγραμμα, κάτω και αριστερή πλευρά, ανηφορική διαγώνιο. Κάτω σειρά: καθοδική διαγώνιο, οριζόντια γραμμή, κάθετη γραμμή με πλήρες περίγραμμα](border-box-fractions.png)

Σε αυτό το κλάσμα, η οριζόντια γραμμή επικάθεται με τη γραμμή κλάσματος. Η κάθετη γραμμή διασχίζει τόσο τον αριθμητή όσο και τον παρονομαστή ενώ το περιβάλλον περίγραμμα παραμένει ορατό. Αυτές οι γραμμές διακοσμούν ολόκληρη την έκφραση. Η συνηθισμένη γραφή διαγράμμισης κειμένου ισχύει για χαρακτήρες σε τμήμα κειμένου. Αφού ανοίξετε ξανά την παρουσίαση στο PowerPoint, μπορείτε ακόμη να επεξεργαστείτε ανεξάρτητα τον αριθμητή και τον παρονομαστή.

## **Ομαδοποίηση όρων**

Χρησιμοποιήστε το [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) για να τοποθετήσετε έναν χαρακτήρα ομαδοποίησης πάνω ή κάτω από μια έκφραση. Προσθέστε όριο για να ετικετοποιήσετε τους ομαδοποιημένους όρους.

![Η έκφραση x + y ομαδοποιημένη με ετικέτα οποιοδήποτε κείμενο κάτω από αυτήν](powerpoint-math-equations_15.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let grouped = new aspose.slides.MathematicalText("x + y")
            .group(java.newChar('\u23DF'), aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new aspose.slides.MathBlock(grouped));

    presentation.save("grouped-terms.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Μορφοποίηση μαθηματικών στοιχείων**

Χρησιμοποιήστε βοηθητικές συναρτήσεις μορφοποίησης μόνο όταν διευκρινίζουν τον τύπο. Για παράδειγμα, το [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) τοποθετεί μια μπάρα πάνω από ένα μαθηματικό στοιχείο.

![Μαθηματική έκφραση ABC με μπάρα πάνω](powerpoint-math-equations_14.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let overbar = new aspose.slides.MathematicalText("ABC").overbar();

    mathParagraph.add(new aspose.slides.MathBlock(overbar));

    presentation.save("overbar.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Μορφοποίηση κειμένου σε υπάρχουσα εξίσωση**

Για να μορφοποιήσετε κείμενο σε μια υπάρχουσα εξίσωση, περιηγηθείτε στο δέντρο στοιχείων κάθε μαθηματικού μπλοκ. Η μέθοδος [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) επιστρέφει μόνο τα άμεσα παιδιά, έτσι καλέστε την αναδρομικά για να φτάσετε σε κείμενο μέσα σε κλάσματα, εκθέτες, ρίζες και άλλες ένθετες δομές. Ελέγξτε τόσο το τρέχον στοιχείο όσο και τα παιδιά του ώστε να συμπεριλάβετε το αρχικό στοιχείο όταν είναι [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/).

Αυτό το παράδειγμα υποθέτει ότι το `input.pptx` περιέχει μια εξίσωση όπως `z = xᵢ / ∛y`, με κλάσμα που έχει υποδείκτη στον αριθμητή και ρίζα στον παρονομαστή. Η επεξεργασία μόνο των στοιχείων ανώτερου επιπέδου του μπλοκ θα χάσει το κείμενο μέσα στο κλάσμα. Το παράδειγμα εντοπίζει μαθηματικά τμήματα σε πλαίσια κειμένου διαφανειών, προσπελαύνει τα μπλοκ τους μέσω του [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) και χρησιμοποιεί το [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) για να ορίσει το μέγεθος γραμματοσειράς στα 28 σημεία σε κάθε στοιχείο κειμένου μέσω της μεθόδου [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatMathText(element) {
    if (java.instanceOf(element, "com.aspose.slides.MathematicalText")) {
        element.getFormat().setFontHeight(28);
    }

    let children = element.getChildren();
    for (let i = 0; i < children.length; i++) {
        formatMathText(children[i]);
    }
}

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }

            let textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let k = 0; k < textFrame.getParagraphs().getCount(); k++) {
                let paragraph = textFrame.getParagraphs().get_Item(k);
                for (let l = 0; l < paragraph.getPortions().getCount(); l++) {
                    let portion = paragraph.getPortions().get_Item(l);
                    if (java.instanceOf(portion, "com.aspose.slides.IMathPortion")) {
                        let mathParagraph = portion.getMathParagraph();
                        for (let m = 0; m < mathParagraph.getCount(); m++) {
                            formatMathText(mathParagraph.get_Item(m));
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αποθηκευμένη παρουσίαση περιέχει την ενημερωμένη μορφοποίηση κειμένου σε κάθε επίπεδο κάθε επεξεργασμένης εξίσωσης, διατηρώντας το κείμενο και τη μαθηματική δομή της.

## **Γρήγορος οδηγός**

| Καθήκον | Κύριο API |
| --- | --- |
| Δημιουργία μαθηματικού κειμένου | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| Συνένωση στοιχείων | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Δημιουργία κλασμάτων | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη εκθέτη ή δείκτη | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη συναρτήσεων | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη ριζών | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη ορίων | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη αριστεράς δέσμευσης | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη αθροίσεων και ολοκληρωμάτων | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη πινάκων | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| Προσθήκη σειρών εξισώσεων | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη οριοθετών | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη μπαρών και περιγραμμάτων | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Ομαδοποίηση όρων | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **Συχνές ερωτήσεις**

**Μπορώ να επεξεργαστώ μια υπάρχουσα εξίσωση PowerPoint;**

Ναι. Ανοίξτε την παρουσίαση, βρείτε το σχήμα που περιέχει ένα [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), καλέστε το [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) και ενημερώστε τα μαθηματικά μπλοκ σε αυτήν την παράγραφο.

**Αποθηκεύονται οι εξισώσεις ως επεξεργάσιμο μαθηματικό PowerPoint;**

Ναι. Όταν αποθηκεύετε σε PPTX, το Aspose.Slides γράφει την εξίσωση ως επεξεργάσιμο περιεχόμενο Office Math.

**Μπορώ να εξάγω εξισώσεις σε LaTeX;**

Ναι. Λάβετε το [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) από το [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) και καλέστε το [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) για άμεση εξαγωγή. Για πλήρες παράδειγμα, δείτε την ενότητα [Export Math Equations from Presentations in Node.js via Java](/slides/el/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).