---
title: Προσθήκη Μαθηματικών Εξισώσεων στις Παρουσιάσεις PowerPoint σε JavaScript
linktitle: Μαθηματικές Εξισώσεις PowerPoint
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

Το PowerPoint αποθηκεύει εξισώσεις ως Office Math Markup Language (OMML). Με το Aspose.Slides για Node.js μέσω Java, μπορείτε να δημιουργήσετε προγραμματιστικά το ίδιο είδος μαθηματικού περιεχομένου: κλάσματα, ριζάκια, συναρτήσεις, όρια, N-ary τελεστές, μητρώες, πίνακες και μορφοποιημένα μαθηματικά μπλοκ.

Στο PowerPoint, οι χρήστες συνήθως προσθέτουν εξισώσεις από **Insert > Equation**:

![Καρτέλα Insert του PowerPoint με την εντολή Equation επιλεγμένη](powerpoint-math-equations_1.png)

Το αποτέλεσμα είναι επεξεργάσιμο μαθηματικό κείμενο στη διαφάνεια:

![Διαφάνεια PowerPoint που περιέχει μια επεξεργάσιμη μαθηματική εξίσωση](powerpoint-math-equations_2.png)

Το Aspose.Slides δημιουργεί αυτό το μαθηματικό κείμενο μέσω τριών βασικών αντικειμένων:

- Ένα μαθηματικό σχήμα, δημιουργημένο με [addMathShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/#addMathShape), είναι το σχήμα που περιέχει την εξίσωση.
- [MathPortion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathportion/) αποθηκεύει μαθηματικό περιεχόμενο μέσα στο πλαίσιο κειμένου του σχήματος.
- [MathParagraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathparagraph/) περιέχει ένα ή περισσότερα αντικείμενα [MathBlock](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathblock/).

Τα περισσότερα παραδείγματα παρακάτω χρησιμοποιούν το [MathematicalText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathematicaltext/) και τις αλυσιδωτές μεθόδους από το [MathElementBase](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) ώστε ο κώδικας να είναι σύντομος και ευανάγνωστος.

Για σενάρια εξαγωγής MathML, δείτε [Εξαγωγή Μαθηματικών Εξισώσεων από Παρουσιάσεις σε Node.js μέσω Java](/slides/el/nodejs-java/exporting-math-equations/).

## **Δημιουργία Εξίσωσης**

Αυτό το παράδειγμα δημιουργεί ένα μαθηματικό σχήμα και προσθέτει το Πυθαγόρειο θεώρημα:

![Η εξίσωση c² = a² + b²](powerpoint-math-equations_3.png)

```javascript
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

{{% alert color="primary" %}}
`addMathShape` δημιουργεί ένα σχήμα που ήδη περιέχει μια μαθηματική παράγραφο. Πρόσβαση στο πρώτο `MathPortion`, λήψη του `MathParagraph` του, και προσθήκη μαθηματικών μπλοκ ή μαθηματικών στοιχείων σε αυτό.
{{% /alert %}}

## **Προσθήκη Κλασμάτων**

Χρησιμοποιήστε [`divide`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) για να δημιουργήσετε ένα κλάσμα. Μπορείτε να επιλέξετε στυλ κλασμάτων με [MathFractionTypes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathfractiontypes/).

![Κλάσμα που δείχνει 1 διαιρεμένο δια x](powerpoint-math-equations_4.png)

```javascript
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

Για κατακόρυφο κλάσμα, χρησιμοποιήστε `MathFractionTypes.Bar`:

```javascript
let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Προσθήκη Ριζών**

Χρησιμοποιήστε [`radical`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) για να δημιουργήσετε τετραγωνική ρίζα, κυβική ρίζα ή άλλη ρίζα. Το τρέχον στοιχείο γίνεται η βάση, και το όρισμα γίνεται ο βαθμός.

![Μια έκφραση n‑ης ρίζας με x κάτω από το σύμβολο ρίζας](powerpoint-math-equations_5.png)

```javascript
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

## **Προσθήκη Συναρτήσεων και Ορίων**

Χρησιμοποιήστε [`asArgumentOfFunction`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) ή [`function`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) για συναρτήσεις όπως `sin(x)`, `log(x)`, ή προσαρμοσμένα ονόματα συναρτήσεων. Για όρια, βάλτε `lim` σε ένα [MathLimit](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathlimit/) ή χρησιμοποιήστε [`setLowerLimit`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/).

![Το όριο του x καθώς το x τείνει στο άπειρο](powerpoint-math-equations_8.png)

```javascript
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

Για προσαρμοσμένο όνομα συνάρτησης, κάντε το όνομα της συνάρτησης το τρέχον στοιχείο:

```javascript
let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Προσθήκη N-ary Τελεστών και Ολοκληρωμάτων**

Χρησιμοποιήστε [`nary`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) για αθροίσεις, ενώσεις, τομές και άλλους μεγάλους τελεστές. Χρησιμοποιήστε [`integral`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) για ολοκληρώματα. Και οι δύο μέθοδοι σας επιτρέπουν να ορίσετε το κάτω και το άνω όριο.

![Μια άθροιση με κάτω και άνω όρια](powerpoint-math-equations_7.png)

```javascript
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

Οι N-ary τελεστές προορίζονται για μεγάλους τελεστές με προαιρετικά όρια. Απλοί τελεστές όπως `+`, `-` και `=` συνήθως προστίθενται ως `MathematicalText` και ενσωματώνονται στην έκφραση.

Για ολοκλήρωμα, χρησιμοποιήστε `integral`:

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Προσθήκη Μητρών**

Χρησιμοποιήστε [MathMatrix](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathmatrix/) για γραμμές και στήλες. Οι μητρώες δεν περιλαμβάνουν αγκύλες εξ ορισμού, οπότε περιβάλλετε τη μητρώα όταν χρειάζονται παρενθέσεις, αγκύλες ή άγκιστρα.

![Μητρώα μαθηματικών δύο γραμμών με ένα κενό κελί](powerpoint-math-equations_10.png)

```javascript
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

## **Προσθήκη Πινάκων Εξισώσεων**

Χρησιμοποιήστε [`toMathArray`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) όταν χρειάζεστε ευθυγραμμισμένες εξισώσεις ή κάθετη στοίβα εκφράσεων.

![Κατακόρυφος μαθηματικός πίνακας με x πάνω από y](powerpoint-math-equations_11.png)

```javascript
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

## **Προσθήκη Τριγωνομετρικών Συναρτήσεων**

Χρησιμοποιήστε [`asArgumentOfFunction`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) όταν το όρισμα είναι το τρέχον στοιχείο και το όνομα της συνάρτησης είναι γνωστό.

![Η τριγωνομετρική συνάρτηση cos που εφαρμόζεται στο 2x](powerpoint-math-equations_6.png)

```javascript
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

## **Προσθήκη Δεικτών και Εκθέτων**

Χρησιμοποιήστε τις βοηθητικές μεθόδους δείκτη και εκθέτη για δείκτες και δυνάμεις. Όταν οι δείκτες πρέπει να εμφανιστούν στην αριστερή πλευρά της βάσης, χρησιμοποιήστε [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/).

![Ένα κεφαλαίο Y με αριστερό δείκτη 1 και εκθέτη n](powerpoint-math-equations_9.png)

```javascript
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

## **Προσθήκη Οριοθέσεων**

Χρησιμοποιήστε [`enclose`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) για να τοποθετήσετε μια έκφραση μέσα σε οριοθέσεις. Μπορείτε επίσης να ορίσετε χαρακτήρα διαχωριστή για εκφράσεις οριοθέσεων που περιέχουν πολλά στοιχεία.

![Μια έκφραση οριοθέτη που περιέχει x, y και z χωρισμένα με κατακόρυφες γραμμές](powerpoint-math-equations_13.png)

```javascript
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

## **Προσθήκη Πλαισίου Περιγράμματος**

Χρησιμοποιήστε [`toBorderBox`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) όταν η ίδια η εξίσωση πρέπει να περιτυλιχθεί σε πλαίσιο.

![Μια εξίσωση σε πλαίσιο που δείχνει a² = b² + c²](powerpoint-math-equations_12.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let boxedEquation = new aspose.slides.MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new aspose.slides.MathBlock(boxedEquation));

    presentation.save("border-box.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ομαδοποίηση Όρων**

Χρησιμοποιήστε [`group`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) για να τοποθετήσετε έναν χαρακτήρα ομαδοποίησης πάνω ή κάτω από μια έκφραση. Προσθέστε όριο για να ετικετοποιήσετε τους ομαδοποιημένους όρους.

![Η έκφραση x + y ομαδοποιημένη με την ετικέτα οποιοδήποτε κείμενο από κάτω](powerpoint-math-equations_15.png)

```javascript
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

## **Μορφοποίηση Μαθηματικών Στοιχείων**

Χρησιμοποιήστε βοηθούς μορφοποίησης μόνο όταν διευκρινίζουν τον τύπο. Για παράδειγμα, [`overbar`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) τοποθετεί μια γραμμή πάνω από ένα μαθηματικό στοιχείο.

![Μαθηματική έκφραση ABC με μια γραμμή επάνω](powerpoint-math-equations_14.png)

```javascript
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

## **Σύντομη Αναφορά**

| Ενέργεια | Κύριο API |
| --- | --- |
| Δημιουργία μαθηματικού κειμένου | [MathematicalText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathematicaltext/) |
| Συνδυασμός στοιχείων | [join](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) |
| Δημιουργία κλασμάτων | [divide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη εκθέτη ή δείκτη | [setSuperscript](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη συναρτήσεων | [function](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη ριζών | [radical](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη ορίων | [setLowerLimit](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη δεικτών στην αριστερή πλευρά | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη αθροίσεων και ολοκληρωμάτων | [nary](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη μητρών | [MathMatrix](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathmatrix/) |
| Προσθήκη πινάκων εξισώσεων | [toMathArray](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη οριοθέσεων | [enclose](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) |
| Προσθήκη γραμμών και πλαισίων | [overbar](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) |
| Ομαδοποίηση όρων | [group](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mathelementbase/) |

## **Συχνές Ερωτήσεις**

**Μπορώ να επεξεργαστώ μια υπάρχουσα εξίσωση PowerPoint;**

Ναι. Ανοίξτε την παρουσίαση, εντοπίστε το σχήμα που περιέχει ένα `MathPortion`, λάβετε το `MathParagraph` του και ενημερώστε τα μαθηματικά μπλοκ σε αυτήν την παράγραφο.

**Αποθηκεύονται οι εξισώσεις ως επεξεργάσιμος μαθηματικός κώδικας PowerPoint;**

Ναι. Όταν αποθηκεύετε σε PPTX, το Aspose.Slides γράφει την εξίσωση ως επεξεργάσιμο περιεχόμενο Office math.

**Μπορώ να εξάγω εξισώσεις σε LaTeX;**

Το Aspose.Slides εξάγει μαθηματικές εξισώσεις σε MathML. Εάν χρειάζεστε LaTeX, εξάγετε πρώτα σε MathML και μετά μετατρέψτε το MathML με ένα εργαλείο που υποστηρίζει τη στοχευόμενη σύνταξη LaTeX.