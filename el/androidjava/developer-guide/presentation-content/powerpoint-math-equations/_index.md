---
title: Προσθήκη μαθηματικών εξισώσεων σε παρουσιάσεις PowerPoint στο Android
linktitle: Μαθηματικές εξισώσεις PowerPoint
type: docs
weight: 80
url: /el/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "Εισαγωγή και επεξεργασία μαθηματικών εξισώσεων σε PowerPoint PPT και PPTX με το Aspose.Slides για Android, υποστηρίζοντας OMML, ελέγχους μορφοποίησης και σαφή παραδείγματα κώδικα Java."
---
## **Επισκόπηση**

Το PowerPoint αποθηκεύει τις εξισώσεις ως Office Math Markup Language (OMML). Με το Aspose.Slides για Android μέσω Java, μπορείτε να δημιουργήσετε το ίδιο είδος μαθηματικού περιεχομένου προγραμματιστικά: κλάσματα, ριζικά, συναρτήσεις, όρια, N-ary τελεστές, πίνακες, ακολουθίες και μορφοποιημένα μαθηματικά μπλοκ.

Στο PowerPoint, οι χρήστες συνήθως προσθέτουν εξισώσεις από **Insert > Equation**:

![Καρτέλα Insert του PowerPoint με την εντολή Equation επιλεγμένη](powerpoint-math-equations_1.png)

Το αποτέλεσμα είναι επεξεργάσιμο μαθηματικό κείμενο στη διαφάνεια:

![Διαφάνεια PowerPoint που περιέχει επεξεργάσιμη μαθηματική εξίσωση](powerpoint-math-equations_2.png)

Το Aspose.Slides δημιουργεί αυτό το μαθηματικό κείμενο μέσω τριών κύριων αντικειμένων:

- Ένα μαθηματικό σχήμα, δημιουργημένο με [addMathShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/), είναι το σχήμα που περιέχει την εξίσωση.
- Το [MathPortion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mathportion/) αποθηκεύει μαθηματικό περιεχόμενο μέσα στο πλαίσιο κειμένου του σχήματος.
- Το [MathParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mathparagraph/) περιέχει ένα ή περισσότερα αντικείμενα [MathBlock](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mathblock/).

Οι περισσότερα παραδείγματα παρακάτω χρησιμοποιούν το [MathematicalText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mathematicaltext/) και τις αλυσιδωτές μεθόδους από το [IMathElement](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/) ώστε ο κώδικας να παραμείνει σύντομος και ευανάγνωστος.

Δείτε την ενότητα [Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις στο Android](/slides/el/androidjava/exporting-math-equations/).

## **Δημιουργία εξίσωσης**

Αυτό το παράδειγμα δημιουργεί ένα μαθηματικό σχήμα και προσθέτει το Πυθαγόρειο θεώρημα:

![Η εξίσωση c² = a² + b²](powerpoint-math-equations_3.png)

```java
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

{{% alert color="primary" %}}
`addMathShape` δημιουργεί ένα σχήμα που περιέχει ήδη μια μαθηματική παράγραφο. Προσπελάστε το πρώτο `MathPortion`, πάρτε το `MathParagraph` του, και προσθέστε μαθηματικά μπλοκ ή μαθηματικά στοιχεία.{{% /alert %}}

## **Προσθήκη κλασμάτων**

Χρησιμοποιήστε τη `divide` για να δημιουργήσετε ένα κλάσμα. Μπορείτε να επιλέξετε στυλ κλάσματος με το [MathFractionTypes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mathfractiontypes/).

![Κλίση μαθηματικού κλάσματος που δείχνει 1 διαιρεμένο με x](powerpoint-math-equations_4.png)

```java
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

Για ένα στοιβαγμένο κλάσμα, χρησιμοποιήστε το `MathFractionTypes.Bar`:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Προσθήκη ριζικών**

Χρησιμοποιήστε τη `radical` για να δημιουργήσετε τετραγωνική ρίζα, κυβική ρίζα ή άλλη ρίζα. Το τρέχον στοιχείο γίνεται η βάση, και το όρισμα γίνεται ο βαθμός.

![Έκφραση n-ης ρίζας με x κάτω από το σύμβολο ρίζας](powerpoint-math-equations_5.png)

```java
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

Χρησιμοποιήστε `asArgumentOfFunction` ή `function` για συναρτήσεις όπως `sin(x)`, `log(x)`, ή προσαρμοσμένα ονόματα συναρτήσεων. Για όρια, τοποθετήστε το `lim` σε ένα [MathLimit](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mathlimit/) ή χρησιμοποιήστε το `setLowerLimit`.

![Το όριο του x καθώς το x τείνει στο άπειρο](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x→∞")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για προσαρμοσμένο όνομα συνάρτησης, κάντε το όνομα της συνάρτησης το τρέχον στοιχείο:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **Προσθήκη N-ary τελεστών και ολοκληρωμάτων**

Χρησιμοποιήστε τη `nary` για αθροίσεις, ένωση, τομές και άλλους μεγάλους τελεστές. Χρησιμοποιήστε τη `integral` για ολοκληρώματα. Και οι δύο μέθοδοι επιτρέπουν τον καθορισμό των κατώτερων και ανώτερων ορίων.

![Αθροιστικό με κάτω και πάνω όρια](powerpoint-math-equations_7.png)

```java
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

Οι N-ary τελεστές προορίζονται για μεγάλους τελεστές με προαιρετικά όρια. Οι απλοί τελεστές όπως `+`, `-`, και `=` συνήθως προστίθενται ως `MathematicalText` και συνενώνονται στην έκφραση.

Για ένα ολοκλήρωμα, χρησιμοποιήστε τη `integral`:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Προσθήκη πινάκων**

Χρησιμοποιήστε το [MathMatrix](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mathmatrix/) για γραμμές και στήλες. Οι πίνακες δεν περιλαμβάνουν αγκύλες από προεπιλογή, γι’ αυτό περικλείστε τον πίνακα όταν χρειάζεστε παρενθέσεις, αγκύλες ή άγκιστρα.

![Μαθηματικός πίνακας δύο γραμμών με ένα κενό κελί](powerpoint-math-equations_10.png)

```java
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

Χρησιμοποιήστε τη `toMathArray` όταν χρειάζεστε ευθυγραμμισμένες εξισώσεις ή κατακόρυφο στοίβαγμα εκφράσεων.

![Κατακόρυφη μαθηματική ακολουθία με x πάνω από y](powerpoint-math-equations_11.png)

```java
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

## **Προσθήκη τριγωνομετρικών συναρτήσεων**

Χρησιμοποιήστε τη `asArgumentOfFunction` όταν το όρισμα είναι το τρέχον στοιχείο και το όνομα της συνάρτησης είναι γνωστό.

![Η τριγωνομετρική συνάρτηση cos εφαρμοσμένη στο 2x](powerpoint-math-equations_6.png)

```java
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

Χρησιμοποιήστε τις βοηθητικές συναρτήσεις δείκτη και εκθέτη για δείκτες και δυνάμεις. Όταν οι δείκτες πρέπει να εμφανίζονται αριστερά της βάσης, χρησιμοποιήστε το `setSubSuperscriptOnTheLeft`.

![Ένα κεφαλαίο Y με αριστερό δείκτη 1 και εκθέτη n](powerpoint-math-equations_9.png)

```java
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

## **Προσθήκη οριοθετητών**

Χρησιμοποιήστε τη `enclose` για να τοποθετήσετε μια έκφραση μέσα σε οριοθέτες. Μπορείτε επίσης να ορίσετε χαρακτήρα διαχωριστή για εκφράσεις οριοθετών που περιέχουν πολλά στοιχεία.

![Μια έκφραση οριοθέτη που περιέχει x, y και z χωρισμένα με κάθετες γραμμές](powerpoint-math-equations_13.png)

```java
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

## **Προσθήκη πλαισίου περιγράμματος**

Χρησιμοποιήστε τη `toBorderBox` όταν η ίδια η εξίσωση πρέπει να περιφραχθεί σε πλαίσιο.

![Μια εξίσωση σε πλαίσιο που δείχνει a² = b² + c²](powerpoint-math-equations_12.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBorderBox boxedEquation = new MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new MathBlock(boxedEquation));

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ομαδοποίηση όρων**

Χρησιμοποιήστε τη `group` για να τοποθετήσετε έναν χαρακτήρα ομαδοποίησης πάνω ή κάτω από μια έκφραση. Προσθέστε όριο για να χαρακτηρίσετε τους ομαδοποιημένους όρους.

![Η έκφραση x + y ομαδοποιημένη με ετικέτα κείμενο κάτω από αυτήν](powerpoint-math-equations_15.png)

```java
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

## **Μορφοποίηση μαθηματικών στοιχείων**

Χρησιμοποιήστε βοηθητικές μορφοποιήσεις μόνο όταν διευκρινίζουν τον τύπο. Για παράδειγμα, το `overbar` τοποθετεί μια γραμμή πάνω από ένα μαθηματικό στοιχείο.

![Μαθηματική έκφραση ABC με γραμμή επάνω](powerpoint-math-equations_14.png)

```java
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

## **Σύντομη αναφορά**

| Εργασία | Κύριο API |
| --- | --- |
| Δημιουργία μαθηματικού κειμένου | [MathematicalText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mathematicaltext/) |
| Συνδυασμός στοιχείων | [IMathElement.join](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/) |
| Δημιουργία κλασμάτων | [IMathElement.divide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη εκθέτη ή δείκτη | [setSuperscript](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη συναρτήσεων | [function](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη ριζικών | [IMathElement.radical](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη ορίων | [setLowerLimit](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη δεικτών αριστερά | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη αθροισμάτων και ολοκληρωμάτων | [nary](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη πινάκων | [MathMatrix](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mathmatrix/) |
| Προσθήκη ακολουθιών εξισώσεων | [toMathArray](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη οριοθετητών | [enclose](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη γραμμών και περιγραμμάτων | [overbar](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/) |
| Ομαδοποίηση όρων | [group](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imathelement/) |

## **Συχνές ερωτήσεις**

**Μπορώ να επεξεργαστώ μια υπάρχουσα εξίσωση PowerPoint;**

Ναι. Ανοίξτε την παρουσίαση, βρείτε το σχήμα που περιέχει ένα `MathPortion`, πάρτε το `MathParagraph` του και ενημερώστε τα μαθηματικά μπλοκ σε εκείνη την παράγραφο.

**Αποθηκεύονται οι εξισώσεις ως επεξεργάσιμο μαθηματικό περιεχόμενο PowerPoint;**

Ναι. Όταν αποθηκεύετε σε PPTX, το Aspose.Slides γράφει την εξίσωση ως επεξεργάσιμο περιεχόμενο Office math.

**Μπορώ να εξάγω εξισώσεις σε LaTeX;**

Το Aspose.Slides εξάγει τις μαθηματικές εξώσεις σε MathML. Αν χρειάζεστε LaTeX, εξάγετε πρώτα σε MathML και, στη συνέχεια, μετατρέψτε το MathML με ένα εργαλείο που υποστηρίζει τη ζητούμενη διάλεκτο LaTeX.