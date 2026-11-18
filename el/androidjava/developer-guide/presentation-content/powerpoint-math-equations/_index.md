---
title: Προσθήκη Μαθηματικών Εξισώσεων σε Παρουσιάσεις PowerPoint σε Android
linktitle: Μαθηματικές Εξισώσεις PowerPoint
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
description: "Εισαγωγή και επεξεργασία μαθηματικών εξισώσεων σε PowerPoint PPT και PPTX με Aspose.Slides για Android, υποστηρίζοντας OMML, ελέγχους μορφοποίησης και σαφή παραδείγματα κώδικα Java."
---
## **Επισκόπηση**

Το PowerPoint αποθηκεύει εξισώσεις ως Office Math Markup Language (OMML). Με το Aspose.Slides για Android μέσω Java, μπορείτε να δημιουργήσετε το ίδιο είδος μαθηματικού περιεχομένου προγραμματιστικά: κλάσματα, ρίζες, συναρτήσεις, όρια, N‑αριους τελεστές, μήτρες, πίνακες και μορφοποιημένα μαθηματικά μπλοκ.

Στο PowerPoint, οι χρήστες συνήθως προσθέτουν εξισώσεις από **Insert > Equation**:

![Καρτέλα Insert του PowerPoint με την εντολή Equation επιλεγμένη](powerpoint-math-equations_1.png)

Το αποτέλεσμα είναι επεξεργάσιμο μαθηματικό κείμενο στη διαφάνεια:

![Διαφάνεια PowerPoint που περιέχει μια επεξεργάσιμη μαθηματική εξίσωση](powerpoint-math-equations_2.png)

Το Aspose.Slides δημιουργεί αυτό το μαθηματικό κείμενο μέσω τριών κύριων αντικειμένων:

- Ένα μαθηματικό σχήμα, δημιουργημένο με [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/), είναι το σχήμα που περιέχει την εξίσωση.
- [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) αποθηκεύει μαθηματικό περιεχόμενο μέσα στο πλαίσιο κειμένου του σχήματος.
- [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) περιέχει ένα ή περισσότερα αντικείμενα [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/).

Τα περισσότερα παραδείγματα παρακάτω χρησιμοποιούν [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) και τις αλυσιδωτές μεθόδους από το [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) για να διατηρήσουν τον κώδικα σύντομο και ευανάγνωστο.

Για σενάρια εξαγωγής MathML, δείτε [Εξαγωγή Μαθηματικών Εξισώσεων από Παρουσιάσεις σε Android](/slides/el/androidjava/exporting-math-equations/).

## **Δημιουργία Εξίσωσης**

Αυτό το παράδειγμα χρησιμοποιεί [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) για να δημιουργήσει ένα μαθηματικό σχήμα και προσθέτει το θεώρημα του Πυθαγόρα:

![Η εξίσωση c² = a² + b²](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) δημιουργεί ένα σχήμα που ήδη περιέχει μια μαθηματική παράγραφο. Πρόσβαση στην πρώτη [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/), κλήση του [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--), και προσθήκη μαθηματικών μπλοκ ή μαθηματικών στοιχείων σε αυτήν.
{{% /alert %}}

## **Προσθήκη Κλασμάτων**

Χρησιμοποιήστε τη [divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) για να δημιουργήσετε ένα κλάσμα. Μπορείτε να επιλέξετε στυλ κλασμάτων με τη [MathFractionTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/).

![Ένα κεκλιμένο μαθηματικό κλάσμα που δείχνει 1 δια x](powerpoint-math-equations_4.png)

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

Για ένα στοιβαγμένο κλάσμα, χρησιμοποιήστε [MathFractionTypes.Bar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/#Bar):

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Προσθήκη Ριζών**

Χρησιμοποιήστε τη [radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) για να δημιουργήσετε τετραγωνική ρίζα, κυβική ρίζα ή άλλη ριζα. Το τρέχον στοιχείο γίνεται η βάση, και το όρισμα γίνεται ο εκθέτης.

![Μια έκφραση n‑οστής ρίζας με x κάτω από το σύμβολο ρίζας](powerpoint-math-equations_5.png)

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

### **Εμφάνιση ή Απόκρυψη του Εκθέτη μιας Τετραγωνικής Ρίζας**

Μια τετραγωνική ρίζα μπορεί να εμφανίζει έναν εμφανή 2 ή να χρησιμοποιεί τη συμβατική σημειογραφία √x. Η μέθοδος [setHideDegree](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathradical/#setHideDegree-boolean-) του [IMathRadical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathradical/) ελέγχει ποια μορφή εμφανίζεται. Και οι δύο μορφές διατηρούν τον εκθέτη 2 και το ριζικό x στη επεξεργάσιμη εξίσωση.

![Η ίδια τετραγωνική ρίζα με τον εκθέτη ορατό στα αριστερά και κρυφό στα δεξιά](square-root-degree.png)

Το παράδειγμα αποθηκεύει την ίδια τετραγωνική ρίζα δύο φορές. Στο `visible-degree.pptx`, ο 2 είναι ορατός. Στο `hidden-degree.pptx`, είναι κρυμμένος.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IMathRadical radical = new MathematicalText("x").radical("2");

    IAutoShape shape = slide.getShapes().addMathShape(20, 20, 200, 100);
    IMathPortion portion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getMathParagraph().add(new MathBlock(radical));

    radical.setHideDegree(false);
    presentation.save("visible-degree.pptx", SaveFormat.Pptx);

    radical.setHideDegree(true);
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Συναρτήσεων και Ορίων**

Χρησιμοποιήστε το [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) ή το [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) για συναρτήσεις όπως `sin(x)`, `log(x)`, ή προσαρμοσμένα ονόματα συναρτήσεων. Για όρια, τοποθετήστε το `lim` σε ένα [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathlimit/) ή χρησιμοποιήστε το [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-).

![Το όριο του x καθώς το x τείνει στο άπειρο](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

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

Για ένα προσαρμοσμένο όνομα συνάρτησης, κάντε το όνομα της συνάρτησης το τρέχον στοιχείο και καλέστε το [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) με το όρισμά του:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **Προσθήκη N-ary Τελεστών και Ολοκληρωμάτων**

Χρησιμοποιήστε το [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) για αθροίσεις, ένωση, τομή και άλλους μεγάλους τελεστές. Χρησιμοποιήστε το [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) για ολοκληρώματα. Και οι δύο μέθοδοι σας επιτρέπουν να ορίσετε κάτω και άνω όρια.

![Άθροισμα με κάτω και πάνω όρια](powerpoint-math-equations_7.png)

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

Οι N-ary τελεστές προορίζονται για μεγάλους τελεστές με προαιρετικά όρια. Απλοί τελεστές όπως `+`, `-`, και `=` προστίθενται συνήθως ως [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) και ενσωματώνονται στην έκφραση.

Για ένα ολοκλήρωμα, χρησιμοποιήστε το [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-):

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Προσθήκη Μητρώων**

Χρησιμοποιήστε το [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) για γραμμές και στήλες. Οι μήτρες δεν περιλαμβάνουν αγκύλες από προεπιλογή, επομένως τυλίξτε τη μήτρα όταν χρειάζεστε παρενθέσεις, αγκύλες ή άγκιστρα.

![Μήτρα μαθηματικών με δύο γραμμές και ένα κενό κελί](powerpoint-math-equations_10.png)

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

### **Επεξεργασία Υπάρχουσας Μήτρας**

Υποθέστε ότι ένα μάθημα γραμμικής άλγεβρας ξεκινά με τη μήτρα συντελεστών στο `matrix.pptx`, αποθηκευμένη από το προηγούμενο παράδειγμα. Για την επόμενη άσκηση, διατηρήστε την πρώτη εξίσωση, αντικαταστήστε τη δεύτερη με δύο νέες εξισώσεις και αναθεωρήστε το σύνολο των μεταβλητών. Ανοίξτε τη υπάρχουσα μήτρα μέσω του [IMathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/) για να διατηρήσετε τους συντελεστές που εξακολουθούν να ισχύουν.

![Αρχική μήτρα συντελεστών δύο γραμμών με καταχωρήσεις 1, x, και ένα κενό κελί στην πρώτη σειρά και x, 2, και y στη δεύτερη](matrix-before-edit.png)

Οι δείκτες γραμμής και στήλης αρχίζουν από το μηδέν και αναφέρονται στη μήτρα όπως υπάρχει σε κάθε κλήση. Η εισαγωγή μιας γραμμής πριν από το δείκτη 1 μεταφέρει την αρχική δεύτερη γραμμή στον δείκτη 2. Η εισαγωγή μετά το δείκτη 2 προσθέτει μια νέα γραμμή. Η διαγραφή της γραμμής 2 αφαιρεί την αρχική δεύτερη εξίσωση και μετακινεί τη νέα γραμμή μία θέση πάνω. Οι στήλες μετακινούνται με τον ίδιο τρόπο.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("matrix.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IMathPortion portion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IMathMatrix matrix = (IMathMatrix) portion.getMathParagraph().get_Item(0).get_Item(0);

    matrix.insertRowBefore(1);
    matrix.insertRowAfter(2);
    matrix.deleteRow(2);

    matrix.insertColumnBefore(1);
    matrix.insertColumnAfter(3);
    matrix.deleteColumn(3);

    // Νέα κελιά αρχικοποιούνται ως null. Ορίστε πρώτα τους μη μηδενικούς συντελεστές.
    matrix.set_Item(1, 0, new MathematicalText("12"));
    matrix.set_Item(1, 1, new MathematicalText("1"));
    matrix.set_Item(2, 2, new MathematicalText("10"));
    matrix.set_Item(2, 3, new MathematicalText("1"));
    for (int row = 0; row < matrix.getRowCount(); row++) {
        for (int column = 0; column < matrix.getColumnCount(); column++) {
            if (matrix.get_Item(row, column) == null) {
                matrix.set_Item(row, column, new MathematicalText("0"));
            }
        }
    }

    matrix.setColumnAlignment(0, MathHorizontalAlignment.Left);
    matrix.setColumnsAlignment(1, 3, MathHorizontalAlignment.Right);

    presentation.save("updated-matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/#setColumnAlignment-int-int-) ευθυγραμμίζει την πρώτη στήλη στα αριστερά. [setColumnsAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/#setColumnsAlignment-int-long-int-) ευθυγραμμίζει τρεις διαδοχικές στήλες στα δεξιά, ξεκινώντας από το δείκτη 1. Στο `updated-matrix.pptx`, η μήτρα έχει τρεις εξισώσεις και τέσσερις μεταβλητές. Οι αρχικοί συντελεστές της πρώτης γραμμής `1` και `x` εμφανίζονται τώρα στην πρώτη και τρίτη στήλη.

![Ενημερωμένη μήτρα τριών γραμμών που δείχνει τις σειρές 1, 0, x, 0· 12, 1, 0, 0· και 0, 0, 10, 1](matrix-after-edit.png)

## **Προσθήκη Πινάκων Εξισώσεων**

Χρησιμοποιήστε το [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toMathArray--) όταν χρειάζεστε ευθυγραμμισμένες εξισώσεις ή μια κατακόρυφη στοίβα εκφράσεων.

![Κατακόρυφος μαθηματικός πίνακας με x πάνω από y](powerpoint-math-equations_11.png)

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

### **Στοίχιση Πίνακα με Γειτονικά Στοιχεία**

[setBaseJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setBaseJustification-int-) ελέγχει τη κατακόρυφη στοίχιση ενός πίνακα σχετικά με τα μαθηματικά στοιχεία δίπλα του. Το παρακάτω παράδειγμα συγκρίνει τη στοίχιση με την πρώτη σειρά, το κέντρο του πίνακα και την τελευταία σειρά.

Το παρακάτω παράδειγμα δημιουργεί τρεις ίδιες πίνακες, καθένας με τρεις σειρές και τα γειτονικά στοιχεία `A=` και `=B`. Όλο το μαθηματικό κείμενο χρησιμοποιεί Cambria Math σε 24 σημεία. Μόνο η στοίχιση του πίνακα αλλάζει.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Η παρακάτω σύγκριση δείχνει την αποθηκευμένη παρουσίαση στο PowerPoint. Παρατηρήστε τη θέση των `A=` και `=B` δίπλα σε κάθε πίνακα.

![Πίνακες εξισώσεων στο PowerPoint με στοίχιση Πάνω, Κέντρο και Κάτω και τα ίδια γειτονικά στοιχεία](equation-array-alignment.png)

### **Διαμόρφωση Απόστασης Γραμμών**

[setRowSpacingRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacingRule-int-) επιλέγει τον κανόνα απόστασης για τις σειρές μέσα στον πίνακα. [setRowSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacing-long-) δίνει αριθμητική τιμή για έναν σαφή κανόνα απόστασης και αγνοείται από τις προκαθορισμένες ρυθμίσεις.

Για ακριβή απόσταση, η τιμή μετράται σε σημεία. Για ποσοστιαία απόσταση, μετράται σε μισές γραμμές: η τιμή `3` στο παράδειγμα ορίζει 1.5 γραμμές. Ορίστε και τις δύο ιδιότητες όταν καθορίζετε σαφή τιμή· η αλλαγή μόνο της αριθμητικής τιμής δεν επιλέγει κανόνα απόστασης.

Το παρακάτω παράδειγμα αποθηκεύει πέντε παρουσιάσεις με τις ίδιες εξισώσεις, στοίχιση και ρυθμίσεις γραμματοσειράς. Οι πρώτες τρεις χρησιμοποιούν προκαθορισμένα στυλ· οι τελευταίες δύο δείχνουν σαφείς τιμές.

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

Η απόσταση γραμμών του πίνακα είναι ξεχωριστή από την απόσταση παραγράφου. Τα [setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) και [setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) προσθέτουν χώρο γύρω από την περιέχουσα παράγραφο, όχι μεταξύ των σειρών του πίνακα. Ομοίως, το [IMathParagraph.setJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#setJustification-int-) τοποθετεί ολόκληρη τη μαθηματική παράγραφο οριζόντια· δεν αντικαθιστά τη ρύθμιση κατακόρυφης στοίχισης του πίνακα.

## **Προσθήκη Τριγωνομετρικών Συναρτήσεων**

Χρησιμοποιήστε το [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) όταν το όρισμα είναι το τρέχον στοιχείο και το όνομα της συνάρτησης είναι γνωστό.

![Η τριγωνομετρική συνάρτηση cos εφαρμοσμένη στο 2x](powerpoint-math-equations_6.png)

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

## **Προσθήκη Δεικτών και Εκθέσεων**

Χρησιμοποιήστε τους βοηθούς δείκτη και εκθέτη για δείκτες και δυνάμεις. Όταν οι δείκτες πρέπει να εμφανιστούν στην αριστερή πλευρά της βάσης, χρησιμοποιήστε το [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-).

![Κεφαλαίο Y με αριστερό δείκτη 1 και εκθέτη n](powerpoint-math-equations_9.png)

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

## **Προσθήκη Οριοθετών**

Χρησιμοποιήστε το [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#enclose-char-char-) για να τοποθετήσετε μια έκφραση μέσα σε οριοθέτες. Μπορείτε επίσης να ορίσετε χαρακτήρα διαχωρισμού για εκφράσεις οριοθέτη που περιέχουν πολλά στοιχεία.

![Μια έκφραση οριοθετημένου χαρακτήρα που περιέχει x, y και z χωρισμένα με κάθετες γραμμές](powerpoint-math-equations_13.png)

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

### **Μέγεθος και Στοίχιση Οριοθετών**

Περάστε `true` στη [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) για να επιτρέψετε στις παρενθέσεις να μεγαλώσουν γύρω από μεγάλο τελεστή, ή περάστε `false` για να τις διατηρήσετε στο κανονικό τους μέγεθος. Χρησιμοποιήστε τη [setDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) με μία από τις δύο τιμές του [MathDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathdelimitershape/). Το `Centered` κεντράρει τις παρενθέσεις στον άξονα των μαθηματικών, ο οποίος διέρχεται από το μέσον του συμβόλου ίσον. Το `Match` τις ευθυγραμμίζει με το περιεχόμενο που περιβάλλουν. Και οι δύο ρυθμίσεις επηρεάζουν μόνο τους οριοθετές. Η έκφραση μέσα παραμένει η ίδια.

Το παράδειγμα τοποθετεί ένα κλάσμα στον εκθέτη του `x` ώστε η έκφραση να εκτείνεται περισσότερο πάνω από τη γραμμή βάσης απ' ό,τι κάτω από αυτήν. Και οι τέσσερις εξισώσεις χρησιμοποιούν τις ίδιες παρενθέσεις και ρυθμίσεις γραμματοσειράς.

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

Στο PowerPoint, συγκρίνετε τις σειρές για να δείτε το αποτέλεσμα της ανάπτυξης. Στην επάνω σειρά, οι παρενθέσεις μεγαλώνουν για να περιβάλλουν τον εκθέτη και φαίνονται ίδια για τα δύο σχήματα. Στη κάτω σειρά, η ανάπτυξη είναι απενεργοποιημένη. Οι μικρότερες παρενθέσεις στα αριστερά (`Centered`) ευθυγραμμίζονται με το σύμβολο ίσον, ενώ αυτές στα δεξιά (`Match`) κρέμονται ψηλότερα γύρω από την έκφραση.

![Τέσσερις εξισώσεις στο PowerPoint με ενεργή ανάπτυξη οριοθετών πάνω και απενεργοποιημένη κάτω, και Centered στα αριστερά και Match στα δεξιά](delimiter-sizing.png)

## **Προσθήκη Πλαισίου Περιγράμματος**

Καλέστε το [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toBorderBox--) σε ένα κλάσμα για να πλαισιώσετε ολόκληρη την έκφραση. Το επιστρεφόμενο [IMathBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/) εμφανίζει όλες τις τέσσερις πλευρές από προεπιλογή. Χρησιμοποιήστε τις [setHideTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), και [setHideRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideRight-boolean-) για να αφαιρέσετε μεμονωμένες πλευρές.

Το παράδειγμα τοποθετεί έξι αντίγραφα του ίδιου κλάσματος σε μία διαφάνεια. Για να δείξετε ακύρωση, κρύψτε όλες τις τέσσερις πλευρές και περάστε `true` στη [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) για μια ανερχόμενη διαγώνια (↗) ή στη [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) για μια καθοδική διαγώνια (↘). Μπορείτε επίσης να χρησιμοποιήσετε το [setStrikethroughHorizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) ή το [setStrikethroughVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) με οποιονδήποτε συνδυασμό ορατών πλευρών.

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

![Έξι επεξεργάσιμα κλάσματα στο PowerPoint. Πάνω σειρά: πλήρες περίγραμμα, κάτω και αριστερές πλευρές, ανερχόμενη διαγώνια. Κάτω σειρά: καθοδική διαγώνια, οριζόντια διαγράμμιση, κάθετη διαγράμμιση με πλήρες περίγραμμα](border-box-fractions.png)

Σε αυτό το κλάσμα, η οριζόντια γραμμή διαγράμμισης καλύπτει τη γραμμή του κλάσματος. Η κάθετη γραμμή διαγράμμισης διασχίζει τόσο τον αριθμητή όσο και τον παρονομαστή ενώ το περιβάλλον περίγραμμα παραμένει ορατό. Αυτές οι γραμμές διακοσμούν ολόκληρη την έκφραση. Η κανονική διαγράμμιση κειμένου εφαρμόζεται σε χαρακτήρες μέσα σε ένα τμήμα κειμένου. Μετά το επαναάνοιγμα της παρουσίασης στο PowerPoint, μπορείτε ακόμη να επεξεργαστείτε ανεξάρτητα τον αριθμητή και τον παρονομαστή.

## **Έλεγχος Ορατότητας και Διάταξης με Στοιχεία Phantom**

Τυλίξτε μια έκφραση στο [MathPhantom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathphantom/) για να ελέγξετε την ορατότητά της και το χώρο που συνεισφέρει σε μια εξίσωση ανεξάρτητα. Οι μέθοδοι του [IMathPhantom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/) ελέγχουν τα εξής:

| Μέθοδος | Επίδραση |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setShow-boolean-) | Περάστε `false` για να κρύψετε την έκφραση. Οι διαστάσεις της εξακολουθούν να συνεισφέρουν στη διάταξη, εκτός εάν οι αντίστοιχες μέθοδοι παρακάτω λάβουν `true`. |
| [setZeroWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroWidth-boolean-) | Θεωρεί το οριζόντιο πλάτος της έκφρασης ως μηδέν, επιτρέποντας στα γειτονικά στοιχεία να πλησιάσουν περισσότερο. |
| [setZeroAsc](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroAsc-boolean-) | Θεωρεί την άνοδο της, το ύψος πάνω από τη γραμμή βάσης, ως μηδέν. Αυτό μπορεί να μειώσει τον χώρο που διατηρείται πάνω από τα γειτονικά στοιχεία. |
| [setZeroDesc](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroDesc-boolean-) | Θεωρεί την κάθοδο της, το βάθος κάτω από τη γραμμή βάσης, ως μηδέν. Αυτό μπορεί να φέρει πιο κοντά μια γραμμή κλάσματος ή άλλο περιεχόμενο κάτω από την έκφραση. |

Η γραμμή βάσης είναι η αναφορά στην οποία κάθεται το κανονικό μαθηματικό γράμμα. Η απόκρυψη περιεχομένου δεν αφαιρεί τις διαστάσεις του, και η αντιμετώπιση μιας διάστασης ως μηδέν δεν διαγράφει την έκφραση. Η υποκείμενη έκφραση παραμένει διαθέσιμη μέσω του [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#getBase--). Περάστε `true` στο [setShow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setShow-boolean-) για να την εμφανίσετε ξανά· οι ρυθμίσεις διάστασης παραμένουν αμετάβλητες.

Το παράδειγμα παρακάτω δημιουργεί πέντε παραλλαγές δίπλα-δίπλα: ένα ορατό κλάσμα, ένα κρυφό κλάσμα που διατηρεί χώρο, και τρία κρυφά κλάσματα με μία διάσταση που αντιμετωπίζεται ως μηδέν. Κάθε παραλλαγή χρησιμοποιεί την ίδια περιβάλλουσα έκφραση και Cambria Math στα 24 σημεία. Όλα τα σχήματα εξίσωσης έχουν την ίδια θέση κορυφής, σημειωμένη από τον γκρι οδηγό. Η τοποθέτηση του phantom στον αριθμητή ενός εξωτερικού κλάσματος κάνει τις κάθετες αλλαγές διάταξης πιο εύκολα εμφανείς.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    String[] labels = { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

    IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LTGRAY);

    for (int i = 0; i < labels.length; i++) {
        int left = 10 + i * 200;

        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        label.getTextFrame().setText(labels[i]);

        IPortionFormat labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(14);
        labelFormat.getFillFormat().setFillType(FillType.Solid);
        labelFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        MathematicalText fractionNumerator = factory.createText("a+b");
        MathematicalText fractionDenominator = factory.createText("c+d");
        MathFraction fraction = new MathFraction(fractionNumerator, fractionDenominator);
        MathPhantom phantom = new MathPhantom(fraction);
        phantom.setShow(i == 0);
        phantom.setZeroWidth(i == 2);
        phantom.setZeroAsc(i == 3);
        phantom.setZeroDesc(i == 4);

        MathematicalText leftText = factory.createText("x+");
        MathematicalText rightText = factory.createText("+y");
        IMathBlock numerator = new MathBlock(leftText).join(phantom).join(rightText);
        MathematicalText denominator = factory.createText("z");
        MathFraction equation = new MathFraction(numerator, denominator);

        IAutoShape shape = slide.getShapes().addMathShape(left, 60, 190, 100);
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top);

        IMathPortion mathPortion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IMathParagraph mathParagraph = mathPortion.getMathParagraph();
        mathParagraph.add(new MathBlock(equation));
    }

    presentation.save("math-phantom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Πέντε εξισώσεις στο PowerPoint που συγκρίνουν ένα ορατό κλάσμα, ένα κρυφό κλάσμα που διατηρεί χώρο, και κρυφά κλάσματα με ZeroWidth, ZeroAsc ή ZeroDesc ενεργοποιημένα](math-phantom.png)

## **Ομαδοποίηση Όρων**

Χρησιμοποιήστε το [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#group-char-int-int-) για να τοποθετήσετε έναν χαρακτήρα ομαδοποίησης πάνω ή κάτω από μια έκφραση. Προσθέστε ένα όριο για να ετικετοποιήσετε τους ομαδοποιημένους όρους.

![Η έκφραση x + y ομαδοποιημένη με την ετικέτα οποιοδήποτε κείμενο κάτω από αυτήν](powerpoint-math-equations_15.png)

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

## **Μορφοποίηση Μαθηματικών Στοιχείων**

Χρησιμοποιήστε βοηθητικά εργαλεία μορφοποίησης μόνο όπου διευκρινίζουν τον τύπο. Για παράδειγμα, το [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#overbar--) τοποθετεί μια γραμμή πάνω από ένα μαθηματικό στοιχείο.

![Μια μαθηματική έκφραση ABC με μια γραμμή πάνω](powerpoint-math-equations_14.png)

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

### **Μορφοποίηση Κειμένου σε Υπάρχουσα Εξίσωση**

Για να μορφοποιήσετε κείμενο σε όλη μια υπάρχουσα εξίσωση, διασχίστε το δένδρο στοιχείων κάθε μαθηματικού μπλοκ. Το [IMathElement.getChildren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#getChildren--) επιστρέφει μόνο τα άμεσα παιδιά, οπότε καλέστε το αναδρομικά για να φτάσετε στο κείμενο μέσα σε κλάσματα, δεικτικούς, ρίζες και άλλες ένθετες δομές. Ελέγξτε το τρέχον στοιχείο καθώς και τα παιδιά του για να συμπεριλάβετε το αρχικό στοιχείο όταν είναι [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/).

Αυτό το παράδειγμα υποθέτει ότι το `input.pptx` περιέχει μια εξίσωση όπως `z = xᵢ / ∛y`, με ένα κλάσμα που περιέχει δείκτη στον αριθμητή του και ρίζα στον παρονομαστή. Η επεξεργασία μόνο των στοιχείων ανώτερου επιπέδου του μπλοκ θα χάσει το κείμενο μέσα στο κλάσμα. Το παράδειγμα εντοπίζει μαθηματικά τμήματα σε πλαίσια κειμένου διαφανειών, προσπελαύνει τα μπλοκ τους μέσω του [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--), και χρησιμοποιεί το [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) για να ορίσει το μέγεθος γραμματοσειράς στα 28 σημεία μέσω της μεθόδου [getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/#getFormat--) του κάθε στοιχείου κειμένου.

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

Η αποθηκευμένη παρουσίαση περιέχει την ενημερωμένη μορφοποίηση κειμένου σε κάθε επίπεδο κάθε επεξεργασμένης εξίσωσης, ενώ διατηρεί το περιεχόμενο κειμένου και τη μαθηματική δομή.

## **Συνοπτική Αναφορά**

| Καθήκον | Κύριο API |
| --- | --- |
| Δημιουργία μαθηματικού κειμένου | [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) |
| Συνδυασμός στοιχείων | [IMathElement.join](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Δημιουργία κλασμάτων | [IMathElement.divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη εκθέτη ή δείκτη | [setSuperscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη συναρτήσεων | [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη ριζών | [IMathElement.radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη ορίων | [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη δεικτών στην αριστερή πλευρά | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη αθροίσεων και ολοκληρωμάτων | [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη μητρώων | [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) |
| Προσθήκη πινάκων εξισώσεων | [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη οριοθετών | [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Προσθήκη γραμμών και περιγραμμάτων | [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Ομαδοποίηση όρων | [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να επεξεργαστώ μια υπάρχουσα εξίσωση στο PowerPoint;**

Ναι. Ανοίξτε την παρουσίαση, βρείτε το σχήμα που περιέχει μια [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/), καλέστε το [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--), και ενημερώστε τα μαθηματικά μπλοκ σε εκείνη την παράγραφο.

**Αποθηκεύονται οι εξισώσεις ως επεξεργάσιμα μαθηματικά του PowerPoint;**

Ναι. Όταν αποθηκεύετε σε PPTX, το Aspose.Slides γράφει την εξίσωση ως επεξεργάσιμο περιεχόμενο Office math.

**Μπορώ να εξάγω εξισώσεις σε LaTeX;**

Ναι. Πάρτε το [IMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/) της εξίσωσης από το [IMathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/), και καλέστε το [IMathParagraph.toLatex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#toLatex--) για άμεση εξαγωγή. Για ολοκληρωμένο παράδειγμα, δείτε [Export Math Equations from Presentations in Android via Java](/slides/el/androidjava/exporting-math-equations/#export-math-equations-to-latex).