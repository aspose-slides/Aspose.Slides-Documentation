---
title: Προσθήκη Μαθηματικών Εξισώσεων σε Παρουσιάσεις PowerPoint σε PHP
linktitle: Μαθηματικές Εξισώσεις PowerPoint
type: docs
weight: 80
url: /el/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "Εισαγωγή και επεξεργασία μαθηματικών εξισώσεων σε PowerPoint PPT και PPTX με το Aspose.Slides για PHP μέσω Java, υποστηρίζοντας OMML, εργαλεία μορφοποίησης και σαφή παραδείγματα κώδικα PHP."
---
## **Επισκόπηση**

Το PowerPoint αποθηκεύει εξισώσεις ως Office Math Markup Language (OMML). Με το Aspose.Slides για PHP μέσω Java, μπορείτε να δημιουργείτε το ίδιο είδος μαθηματικού περιεχομένου προγραμματιστικά: κλάσματα, ρίζες, συναρτήσεις, όρια, N‑ary τελεστές, πίνακες, διατάξεις και μορφοποιημένα μαθηματικά μπλοκ.

Στο PowerPoint, οι χρήστες συνήθως προσθέτουν εξισώσεις από **Insert > Equation**:

![Καρτέλα Insert του PowerPoint με την εντολή Equation επιλεγμένη](powerpoint-math-equations_1.png)

Το αποτέλεσμα είναι επεξεργάσιμο μαθηματικό κείμενο στη διαφάνεια:

![Διαφάνεια PowerPoint που περιέχει επεξεργάσιμο μαθηματικό τύπο](powerpoint-math-equations_2.png)

Το Aspose.Slides δημιουργεί αυτό το μαθηματικό κείμενο μέσω τριών κύριων αντικειμένων:

- Ένα μαθηματικό σχήμα, δημιουργημένο με [addMathShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/#addMathShape), είναι το σχήμα που περιέχει την εξίσωση.
- [MathPortion](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathportion/) αποθηκεύει μαθηματικό περιεχόμενο μέσα στο πλαίσιο κειμένου του σχήματος.
- [MathParagraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathparagraph/) περιέχει ένα ή περισσότερα αντικείμενα [MathBlock](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathblock/).

Τα περισσότερα παραδείγματα παρακάτω χρησιμοποιούν το [MathematicalText](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathematicaltext/) και τις αλυσίδες μεθόδων από το [MathElementBase](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) για να παραμείνει ο κώδικας σύντομος και ευανάγνωστος.

Για σενάρια εξαγωγής MathML, δείτε την [Export Math Equations from Presentations in PHP via Java](/slides/el/php-java/exporting-math-equations/).

## **Δημιουργία Εξίσωσης**

Αυτό το παράδειγμα δημιουργεί ένα μαθηματικό σχήμα και προσθέτει το θεώρημα του Πυθαγόρα:

![Η εξίσωση c² = a² + b²](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="primary" %}}
`addMathShape` δημιουργεί ένα σχήμα που ήδη περιέχει μια μαθηματική παράγραφο. Πρόσβαση στο πρώτο `MathPortion`, λήψη του `MathParagraph` του, και προσθήκη μαθηματικών μπλοκ ή στοιχείων σε αυτό.
{{% /alert %}}

## **Προσθήκη Κλασμάτων**

Χρησιμοποιήστε [`divide`](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) για να δημιουργήσετε ένα κλάσμα. Μπορείτε να επιλέξετε στυλ κλάσματος με το [MathFractionTypes](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathfractiontypes/).

![Κλάσμα με κλίση που δείχνει 1 διαιρεμένο με x](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Για στοίβα κλάσματος, χρησιμοποιήστε `MathFractionTypes::Bar`:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Προσθήκη Ριζών**

Χρησιμοποιήστε [`radical`](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) για να δημιουργήσετε τετραγωνική ρίζα, κυβική ρίζα ή άλλη ρίζα. Το τρέχον στοιχείο γίνεται η βάση, το όρισμα είναι ο εκθέτης.

![Έκφραση n‑οστή ρίζας με x κάτω από το σύμβολο ρίζας](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Προσθήκη Συναρτήσεων και Ορίων**

Χρησιμοποιήστε [`asArgumentOfFunction`](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) ή [`function`](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) για συναρτήσεις όπως `sin(x)`, `log(x)` ή προσαρμοσμένα ονόματα συναρτήσεων. Για όρια, τοποθετήστε `lim` σε ένα [MathLimit](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathlimit/) ή χρησιμοποιήστε το [`setLowerLimit`](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/).

![Το όριο του x καθώς το x τείνει στο άπειρο](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Για προσαρμοσμένο όνομα συνάρτησης, κάντε το όνομα της συνάρτησης το τρέχον στοιχείο:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Προσθήκη N‑ary Τελεστών και Ολοκληρωμάτων**

Χρησιμοποιήστε [`nary`](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) για αθροίσεις, ενώσεις, τομές και άλλους μεγάλους τελεστές. Χρησιμοποιήστε [`integral`](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) για ολοκληρώματα. Και οι δύο μέθοδοι επιτρέπουν ορισμό κάτω και άνω ορίων.

![Αθροιστικό σύμβολο με κάτω και άνω όρια](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Οι N‑ary τελεστές είναι για μεγάλους τελεστές με προαιρετικά όρια. Απλοί τελεστές όπως `+`, `-` και `=` συνήθως προστίθενται ως `MathematicalText` και ενσωματώνονται στην έκφραση.

Για ολοκλήρωση, χρησιμοποιήστε `integral`:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Προσθήκη Πινακών**

Χρησιμοποιήστε [MathMatrix](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathmatrix/) για γραμμές και στήλες. Οι πίνακες δεν περιλαμβάνουν παρενθέσεις εξ ορισμού, γι' αυτό περικλείστε τον πίνακα όταν χρειάζονται παρενθέσεις, αγκύλες ή άγκιστρα.

![Πίνακας με δύο γραμμές και ένα κενό κελί](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Προσθήκη Διατάξεων Εξισώσεων**

Χρησιμοποιήστε [`toMathArray`](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) όταν χρειάζεστε ευθυγραμμισμένες εξισώσεις ή κάθετη στοίβα εκφράσεων.

![Κάθετη διάταξη μαθηματικών με x πάνω από y](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Προσθήκη Τριγωνομετρικών Συναρτήσεων**

Χρησιμοποιήστε [`asArgumentOfFunction`](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) όταν το όρισμα είναι το τρέχον στοιχείο και το όνομα της συνάρτησης είναι γνωστό.

![Η τριγωνομετρική συνάρτηση cos εφαρμοσμένη στο 2x](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Προσθήκη Δεικτών και Εκθετών**

Χρησιμοποιήστε τις βοηθητικές μεθόδους για δείκτες και εκθέτες. Όταν οι δείκτες πρέπει να εμφανιστούν αριστερά της βάσης, χρησιμοποιήστε [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/).

![Κεφαλαίο Y με αριστερό δείκτη 1 και εκθέτη n](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Προσθήκη Διαχωριστών**

Χρησιμοποιήστε [`enclose`](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) για να βάλτε μια έκφραση μέσα σε διαχωριστές. Μπορείτε επίσης να ορίσετε χαρακτήρα διαχωριστή για εκφράσεις διαχωριστών που περιέχουν πολλά στοιχεία.

![Έκφραση διαχωριστή που περιέχει x, y και z χωρισμένα με κάθετες γραμμές](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Προσθήκη Πλαισίου Περιγράμματος**

Χρησιμοποιήστε [`toBorderBox`](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) όταν η ίδια η εξίσωση πρέπει να περιβάλλεται από πλαίσιο.

![Εξίσωση σε πλαίσιο που δείχνει c² = b² + a²](powerpoint-math-equations_12.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $boxedEquation = (new MathematicalText("a"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("b"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("c"))->setSuperscript("2"))
        - >toBorderBox();

    $mathParagraph->add(new MathBlock($boxedEquation));

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Ομαδοποίηση Όρων**

Χρησιμοποιήστε [`group`](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) για να τοποθετήσετε χαρακτήρα ομαδοποίησης πάνω ή κάτω από μια έκφραση. Προσθέστε όριο για να επισημάνετε τους ομαδοποιημένους όρους.

![Η έκφραση x + y ομαδοποιημένη με ετικέτα κείμενο κάτω από αυτήν](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Μορφοποίηση Μαθηματικών Στοιχείων**

Χρησιμοποιήστε βοηθητικές μεθόδους μορφοποίησης μόνο όπου διευκρινίζουν τον τύπο. Για παράδειγμα, το [`overbar`](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) τοποθετεί μια μπάρα πάνω από ένα μαθηματικό στοιχείο.

![Μαθηματική έκφραση ABC με μπάρα πάνω](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Γρήγορη Αναφορά**

| Εργασία | Κύριο API |
| --- | --- |
| Δημιουργία μαθηματικού κειμένου | [MathematicalText](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathematicaltext/) |
| Συνδυασμός στοιχείων | [join](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) |
| Δημιουργία κλασμάτων | [divide](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) |
| Προσθήκη εκθέτη ή δείκτη | [setSuperscript](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) |
| Προσθήκη συναρτήσεων | [function](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) |
| Προσθήκη ριζών | [radical](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) |
| Προσθήκη ορίων | [setLowerLimit](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) |
| Προσθήκη αριστερών δεξιών δεικτών | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) |
| Προσθήκη αθροίσεων και ολοκληρωμάτων | [nary](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) |
| Προσθήκη πινάκων | [MathMatrix](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathmatrix/) |
| Προσθήκη διατάξεων εξίσωσης | [toMathArray](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) |
| Προσθήκη διαχωριστών | [enclose](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) |
| Προσθήκη μπαρών και περιγραμμάτων | [overbar](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) |
| Ομαδοποίηση όρων | [group](https://reference.aspose.com/slides/el/php-java/aspose.slides/mathelementbase/) |

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να επεξεργαστώ μια υπάρχουσα εξίσωση PowerPoint;**

Ναι. Ανοίξτε την παρουσίαση, βρείτε το σχήμα που περιέχει ένα `MathPortion`, λάβετε το `MathParagraph` του και ενημερώστε τα μαθηματικά μπλοκ σε αυτήν την παράγραφο.

**Αποθηκεύονται οι εξισώσεις ως επεξεργάσιμο μαθηματικό περιεχόμενο PowerPoint;**

Ναι. Όταν αποθηκεύετε σε PPTX, το Aspose.Slides γράφει την εξίσωση ως επεξεργάσιμο περιεχόμενο Office Math.

**Μπορώ να εξάγω εξισώσεις σε LaTeX;**

Το Aspose.Slides εξάγει μαθηματικές εξισώσεις σε MathML. Εάν χρειάζεστε LaTeX, εξάγετε πρώτα σε MathML και στη συνέχεια μετατρέψτε το MathML με ένα εργαλείο που υποστηρίζει το επιθυμητό LaTeX.