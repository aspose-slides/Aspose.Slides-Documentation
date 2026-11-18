---
title: Προσθήκη Μαθηματικών Εξισώσεων σε Παρουσιάσεις PowerPoint σε Python
linktitle: Μαθηματικές Εξισώσεις PowerPoint
type: docs
weight: 80
url: /el/python-java/powerpoint-math-equations/
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
- Python
- Java
- Aspose.Slides
description: "Εισαγωγή και επεξεργασία μαθηματικών εξισώσεων σε PowerPoint PPT και PPTX με το Aspose.Slides για Python μέσω Java, υποστηρίζοντας OMML, ελέγχους μορφοποίησης και καθαρά παραδείγματα κώδικα Python."
---
## **Επισκόπηση**

Το PowerPoint αποθηκεύει τις εξισώσεις ως Office Math Markup Language (OMML). Με το Aspose.Slides για Python μέσω Java, μπορείτε να δημιουργήσετε προγραμματιστικά το ίδιο είδος μαθηματικού περιεχομένου: κλάσματα, ρίζες, συναρτήσεις, όρια, τελεστές N-ary, πίνακες, διατάξεις και μορφοποιημένα μαθηματικά μπλοκ.

Στο PowerPoint, οι χρήστες συνήθως προσθέτουν εξισώσεις από **Insert > Equation**:

![Καρτέλα Εισαγωγή του PowerPoint με την εντολή Εξίσωση επιλεγμένη](powerpoint-math-equations_1.png)

Το αποτέλεσμα είναι επεξεργάσιμο μαθηματικό κείμενο στη διαφάνεια:

![Διαφάνεια PowerPoint που περιέχει μια επεξεργáσιμη μαθηματική εξίσωση](powerpoint-math-equations_2.png)

Το Aspose.Slides δημιουργεί αυτό το μαθηματικό κείμενο μέσω τριών κύριων αντικειμένων:

- Ένα μαθηματικό σχήμα, δημιουργημένο με [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape), είναι το σχήμα που περιέχει την εξίσωση.
- Το [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) αποθηκεύει το μαθηματικό περιεχόμενο μέσα στο πλαίσιο κειμένου του σχήματος.
- Το [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) περιέχει ένα ή περισσότερα αντικείμενα [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/).

Οι περισσότερα παραδείγματα παρακάτω χρησιμοποιούν το [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) και τις αλυσιδωτές μεθόδους από το [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) για να διατηρήσουν τον κώδικα σύντομο και ευανάγνωστο.

Για σενάρια εξαγωγής MathML, δείτε το [Export Math Equations from Presentations in Python](/slides/el/python-java/exporting-math-equations/).

## **Δημιουργία Εξίσωσης**

Αυτό το παράδειγμα χρησιμοποιεί το [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) για να δημιουργήσει ένα μαθηματικό σχήμα και προσθέτει το θεώρημα του Πυθαγόρα:

![Η εξίσωση c² = a² + b²](powerpoint-math-equations_3.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    equation = MathematicalText("c").setSuperscript("2").join("=").join(a_squared).join("+").join(b_squared)

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Σημείωση" %}}

[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) δημιουργεί ένα σχήμα που περιέχει ήδη μια μαθηματική παράγραφο. Πρόσβαση στο πρώτο [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), κλήση του [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) και προσθήκη μαθηματικών μπλοκ ή στοιχείων σε αυτό.

{{% /alert %}}

## **Προσθήκη Κλασμάτων**

Χρησιμοποιήστε το [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) για να δημιουργήσετε ένα κλάσμα. Μπορείτε να επιλέξετε στυλ κλάσματος με το [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/).

![Ένα πλαγιασμένο μαθηματικό κλάσμα που δείχνει 1 δια x](powerpoint-math-equations_4.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFractionTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    fraction = MathematicalText("1").divide("x", MathFractionTypes.Skewed)

    math_block = MathBlock(fraction)
    math_paragraph.add(math_block)

    presentation.save("fraction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Για στοίβαγμα κλάσματος, χρησιμοποιήστε το [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **Προσθήκη Ριζών**

Χρησιμοποιήστε το [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) για να δημιουργήσετε τετραγωνική ρίζα, κύβο ή άλλη ρίζα. Το τρέχον στοιχείο γίνεται η βάση, και το όρισμα γίνεται ο βαθμός.

![Μια n‑οστή ρίζα με x κάτω από το σύμβολο ριζας](powerpoint-math-equations_5.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    radical = MathematicalText("x").radical("n")

    math_block = MathBlock(radical)
    math_paragraph.add(math_block)

    presentation.save("radical.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Εμφάνιση ή Απόκρυψη του Βαθμού μιας Τετραγωνικής Ρίζας**

Μια τετραγωνική ρίζα μπορεί να εμφανίζει τον αριθμό 2 ρητά ή να χρησιμοποιεί τη συμβατική σημειολογία √x. Η μέθοδος [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree) του [MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/) ελέγχει ποια μορφή εμφανίζεται. Και οι δύο μορφές διατηρούν τον βαθμό 2 και το radicand x στην επεξεργάσιμη εξίσωση.

![Η ίδια τετραγωνική ρίζα με τον βαθμό ορατό στα αριστερά και κρυφό στα δεξιά](square-root-degree.png)

Το παράδειγμα αποθηκεύει την ίδια τετραγωνική ρίζα δύο φορές. Στο `visible-degree.pptx`, το 2 είναι ορατό. Στο `hidden-degree.pptx`, είναι κρυφό.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    radical = MathematicalText("x").radical("2")
    math_block = MathBlock(radical)

    math_shape = slide.getShapes().addMathShape(20, 20, 200, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()
    math_paragraph.add(math_block)

    radical.setHideDegree(False)
    presentation.save("visible-degree.pptx", SaveFormat.Pptx)

    radical.setHideDegree(True)
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Προσθήκη Συναρτήσεων και Ορίων**

Χρησιμοποιήστε το [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) ή το [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) για συναρτήσεις όπως `sin(x)`, `log(x)` ή προσαρμοσμένα ονόματα συναρτήσεων. Για όρια, τοποθετήστε το `lim` σε ένα [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) ή χρησιμοποιήστε το [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit).

![Το όριο του x καθώς το x τείνει στο άπειρο](powerpoint-math-equations_8.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    limit = MathematicalText("lim").setLowerLimit("x\u2192\u221E").function("x")

    math_block = MathBlock(limit)
    math_paragraph.add(math_block)

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Για προσαρμοσμένο όνομα συνάρτησης, κάντε το όνομα της συνάρτησης το τρέχον στοιχείο και καλέστε το [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) με το όρισμά του:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **Προσθήκη N‑ary Τελεστών και Ολοκληρωμάτων**

Χρησιμοποιήστε το [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) για αθροίσεις, ενώσεις, τομές και άλλους μεγάλους τελεστές. Χρησιμοποιήστε το [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) για ολοκληρώματα. Και οι δύο μέθοδοι επιτρέπουν ορισμό κατώτερων και ανώτερων ορίων.

![Μια άθροιση με κατώτερο και ανώτερο όριο](powerpoint-math-equations_7.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathNaryOperatorTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_power = MathematicalText("a").setSuperscript("n-k")
    summation_base = MathematicalText("x").setSuperscript("k").join(a_power)

    summation = summation_base.nary(MathNaryOperatorTypes.Summation, "k=0", "n")

    math_block = MathBlock(summation)
    math_paragraph.add(math_block)

    presentation.save("nary-operators.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Οι N‑ary τελεστές προορίζονται για μεγάλους τελεστές με προαιρετικά όρια. Απλοί τελεστές όπως `+`, `-` και `=` συνήθως προστίθενται ως [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) και ενσωματώνονται στην έκφραση.

Για ολοκληρώματα, χρησιμοποιήστε το [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathIntegralTypes, MathematicalText

differential = MathematicalText("dx").toBox()
integral_base = MathematicalText("x").join(differential)
integral = integral_base.integral(MathIntegralTypes.Simple, "0", "1")
```

## **Προσθήκη Πινάκων**

Χρησιμοποιήστε το [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) για γραμμές και στήλες. Οι πίνακες δεν περιλαμβάνουν αγκύλες από προεπιλογή, οπότε τυλίξτε τον πίνακα όταν χρειάζεστε παρενθέσεις, αγκύλες ή άγκιστρα.

![Δύο γραμμές μαθηματικού πίνακα με ένα κενό κελί](powerpoint-math-equations_10.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathMatrix, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    matrix = MathMatrix(2, 3)
    cell_0_0 = MathematicalText("1")
    matrix.set_Item(0, 0, cell_0_0)
    cell_0_1 = MathematicalText("x")
    matrix.set_Item(0, 1, cell_0_1)
    cell_1_0 = MathematicalText("x")
    matrix.set_Item(1, 0, cell_1_0)
    cell_1_1 = MathematicalText("2")
    matrix.set_Item(1, 1, cell_1_1)
    cell_1_2 = MathematicalText("y")
    matrix.set_Item(1, 2, cell_1_2)

    math_block = MathBlock(matrix)
    math_paragraph.add(math_block)

    presentation.save("matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Επεξεργασία Υπαρχόντος Πίνακα**

Έστω ότι ένα μάθημα γραμμικής άλγεβρας ξεκινά με τον πίνακα συντελεστών στο `matrix.pptx`, αποθηκευμένο από το προηγούμενο παράδειγμα. Για την επόμενη άσκηση, κρατήστε την πρώτη εξίσωση, αντικαταστήστε τη δεύτερη με δύο νέες εξισώσεις και αναθεωρήστε το σύνολο των μεταβλητών. Ανοίξτε τον υπάρχοντα πίνακα μέσω του [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) για να διατηρήσετε τους συντελεστές που εξακολουθούν να ισχύουν.

![Αρχικός πίνακας συντελεστών δύο γραμμών με καταχωρήσεις 1, x, και ένα κενό κελί στην πρώτη γραμμή και x, 2, και y στη δεύτερη](matrix-before-edit.png)

Οι δείκτες γραμμών και στηλών ξεκινούν από το μηδέν και αναφέρονται στον πίνακα όπως υπάρχει σε κάθε κλήση. Η εισαγωγή γραμμής πριν τον δείκτη 1 μετακινεί την αρχική δεύτερη γραμμή στο δείκτη 2. Η εισαγωγή μετά το δείκτη 2 προσθέτει μια γραμμή. Η διαγραφή της γραμμής 2 αφαιρεί την αρχική δεύτερη εξίσωση και μετακινεί τη γραμμή που προστέθηκε μία θέση επάνω. Οι στήλες μετατοπίζονται με τον ίδιο τρόπο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathHorizontalAlignment, MathematicalText, Presentation, SaveFormat

presentation = Presentation("matrix.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    matrix = portion.getMathParagraph().get_Item(0).get_Item(0)

    matrix.insertRowBefore(1)
    matrix.insertRowAfter(2)
    matrix.deleteRow(2)

    matrix.insertColumnBefore(1)
    matrix.insertColumnAfter(3)
    matrix.deleteColumn(3)

    # Οι νέες κυψέλες είναι αρχικά κενές. Θέστε πρώτα τους μη μηδενικούς συντελεστές.
    matrix.set_Item(1, 0, MathematicalText("12"))
    matrix.set_Item(1, 1, MathematicalText("1"))
    matrix.set_Item(2, 2, MathematicalText("10"))
    matrix.set_Item(2, 3, MathematicalText("1"))
    for row in range(matrix.getRowCount()):
        for column in range(matrix.getColumnCount()):
            if matrix.get_Item(row, column) is None:
                matrix.set_Item(row, column, MathematicalText("0"))

    matrix.setColumnAlignment(0, MathHorizontalAlignment.Left)
    matrix.setColumnsAlignment(1, 3, MathHorizontalAlignment.Right)
    
    presentation.save("updated-matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το [setColumnAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnAlignment) ευθυγραμμίζει την πρώτη στήλη αριστερά. Το [setColumnsAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnsAlignment) ευθυγραμμίζει τις υπόλοιπες τρεις στήλες δεξιά, ξεκινώντας από το δείκτη 1. Στο `updated-matrix.pptx`, ο πίνακας έχει τρεις εξισώσεις και τέσσερις μεταβλητές. Οι αρχικοί συντελεστές πρώτης γραμμής `1` και `x` εμφανίζονται τώρα στις στήλες 1 και 3.

![Ενημερωμένος πίνακας τριών γραμμών που δείχνει τις γραμμές 1, 0, x, 0· 12, 1, 0, 0· και 0, 0, 10, 1](matrix-after-edit.png)

## **Πρόσθεση Πινακων Εξισώσεων**

Χρησιμοποιήστε το [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) όταν χρειάζεστε ευθυγραμμισμένες εξισώσεις ή κατακόρυφη στοίβα εκφράσεων.

![Κατακόρυφη μαθηματική διάταξη με x πάνω από y](powerpoint-math-equations_11.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 140)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    equation_array = MathematicalText("x").join("y").toMathArray()

    math_block = MathBlock(equation_array)
    math_paragraph.add(math_block)

    presentation.save("equation-array.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Στοίχιση Πίνακα με Γειτονικά Στοιχεία**

Η μέθοδος [setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) ελέγχει την κατακόρυφη στοίχιση ενός πίνακα σε σχέση με τα μαθηματικά στοιχεία δίπλα του. Το παρακάτω παράδειγμα συγκρίνει τη στοίχιση με την πρώτη γραμμή, το κέντρο του πίνακα και την τελευταία γραμμή.

Το παρακάτω παράδειγμα δημιουργεί τρεις πανομοιότυπους πίνακες, καθένας με τρεις γραμμές και τα γειτονικά στοιχεία `A=` και `=B`. Όλο το μαθηματικό κείμενο χρησιμοποιεί Cambria Math σε 24 σημεία. Μόνο η στοίχιση του πίνακα αλλάζει.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathVerticalAlignment, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)
    
    alignments = (("Top", MathVerticalAlignment.Top), ("Center", MathVerticalAlignment.Center), ("Bottom", MathVerticalAlignment.Bottom))
    for index, (name, alignment) in enumerate(alignments):
        x = 20 + index * 260
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 10, 240, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(16)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        math_shape = slide.getShapes().addMathShape(x, 60, 240, 130)
        math_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(alignment)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η παρακάτω σύγκριση δείχνει την αποθηκευμένη παρουσίαση στο PowerPoint. Παρατηρήστε τη θέση του `A=` και `=B` δίπλα σε κάθε πίνακα.

![Πίνακες εξισώσεων στο PowerPoint με Στοίχιση Επάνω, Κέντρο και Κάτω και πανομοιότυπα γειτονικά στοιχεία](equation-array-alignment.png)

### **Διαμόρφωση Αποστάσεων Γραμμών**

Η μέθοδος [setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) επιλέγει τον κανόνα αποστάσεων για τις γραμμές εντός του πίνακα. Η [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) παρέχει αριθμητική τιμή για έναν ρητό κανόνα αποστάσεων και αγνοείται από τις προεπιλεγμένες ρυθμίσεις.

Για ακριβή απόσταση, η τιμή μετράται σε σημεία. Για αναλογική απόσταση, μετράται σε μισές γραμμές: η τιμή `3` στο παράδειγμα σημαίνει 1,5 γραμμές. Ορίστε και τις δύο ιδιότητες όταν καθορίζετε ρητή τιμή· η αλλαγή μόνο της αριθμητικής τιμής δεν επιλέγει κανόνα αποστάσεων.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathRowSpacingRule, MathVerticalAlignment, Presentation, SaveFormat

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


settings = (("SingleLineGap", MathRowSpacingRule.SingleLineGap, 0), ("OneAndAHalfLineGap", MathRowSpacingRule.OneAndAHalfLineGap, 0), ("TwoLineGap", MathRowSpacingRule.TwoLineGap, 0), ("Exactly", MathRowSpacingRule.Exactly, 20), ("Multiple", MathRowSpacingRule.Multiple, 3))
for name, rule, spacing in settings:
    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        math_shape = slide.getShapes().addMathShape(20, 20, 600, 300)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(MathVerticalAlignment.Center)
        equation_array.setRowSpacingRule(rule)
        equation_array.setRowSpacing(spacing)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

        presentation.save(f"equation-array-{name}.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Η απόσταση των γραμμών του πίνακα είναι ανεξάρτητη από την απόσταση παραγράφων. Οι μέθοδοι [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) και [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) προσθέτουν χώρο γύρω από την παράγραφο που περιέχει τον πίνακα, όχι μεταξύ των γραμμών του πίνακα. Ο ίδιος ισχύει για τη μέθοδο [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification), η οποία τοποθετεί ολόκληρη τη μαθηματική παράγραφο οριζόντια· δεν αντικαθιστά τη ρύθμιση κατακόρυφης στοίχισης του πίνακα.

## **Προσθήκη Τριγωνομετρικών Συναρτήσεων**

Χρησιμοποιήστε το [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) όταν το όρισμα είναι το τρέχον στοιχείο και το όνομα της συνάρτησης είναι γνωστό.

![Η τριγωνομετρική συνάρτηση cos εφαρμόζεται στο 2x](powerpoint-math-equations_6.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFunctionsOfOneArgument, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    cosine = MathematicalText("2x").asArgumentOfFunction(MathFunctionsOfOneArgument.Cos)

    math_block = MathBlock(cosine)
    math_paragraph.add(math_block)

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Προσθήκη Δεικτών και Εκθέτων**

Χρησιμοποιήστε τους βοηθούς δείκτη και εκθέτη για δείκτες και δυνάμεις. Όταν οι δείκτες πρέπει να εμφανίζονται στην αριστερή πλευρά της βάσης, χρησιμοποιήστε το [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Κεφαλαίο Y με αριστερό δείκτη 1 και εκθέτη n](powerpoint-math-equations_9.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    scripts = MathematicalText("Y").setSubSuperscriptOnTheLeft("1", "n")

    math_block = MathBlock(scripts)
    math_paragraph.add(math_block)

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Προσθήκη Οριοθέτη**

Χρησιμοποιήστε το [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) για να τοποθετήσετε μια έκφραση μέσα σε οριοθέτες. Μπορείτε επίσης να ορίσετε χαρακτήρα διαχωριστικού για εκφράσεις οριοθέτη που περιέχουν πολλά στοιχεία.

![Μια έκφραση οριοθέτη που περιέχει x, y και z χωρισμένα με κατακόρυφες γραμμές](powerpoint-math-equations_13.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    delimiter = MathematicalText("x").join("y").join("z").enclose('<', '>')
    delimiter.setSeparatorCharacter('|')

    math_block = MathBlock(delimiter)
    math_paragraph.add(math_block)

    presentation.save("delimiters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Μέγεθος και Στοίχιση Οριοθέτη**

Προσδώστε την τιμή `True` στο [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) για να επιτρέψετε στις παρενθέσεις να μεγαλώσουν γύρω από ένα ψηλό όρο, ή τη τιμή `False` για να διατηρηθούν στο κανονικό τους μέγεθος. Χρησιμοποιήστε το [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) με μία από τις δύο τιμές του [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/). Η τιμή `Centered` κεντράρει τις παρενθέσεις στον άξονα των μαθηματικών, που διέρχεται από το μέσο του ίσου. Η τιμή `Match` τις ευθυγραμμίζει με το περιεχόμενο που περιβάλλουν. Και οι δύο ρυθμίσεις επηρεάζουν μόνο τους οριοθέτες. Η έκφραση μέσα παραμένει η ίδια.

Το παράδειγμα τοποθετεί ένα κλάσμα σε εκθέτη του `x` ώστε η έκφραση να εκτείνεται περισσότερο πάνω από τη βασική γραμμή παρά κάτω. Και οι τέσσερις εξισώσεις χρησιμοποιούν τις ίδιες παρενθέσεις και ρυθμίσεις γραμματοσειράς.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathDelimiterShape, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    for row, grow in enumerate((True, False)):
        for column, shape in enumerate((MathDelimiterShape.Centered, MathDelimiterShape.Match)):
            fraction = MathematicalText("a + b").divide("c + d")
            power = MathematicalText("x").setSuperscript(fraction)
            delimiter = power.enclose("(", ")")
            delimiter.setGrowToMatchOperandHeight(grow)
            delimiter.setDelimiterShape(shape)

            math_shape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100)
            portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            portion.getPortionFormat().setFontHeight(32)
            equation = MathematicalText("y = ").join(delimiter)
            portion.getMathParagraph().add(equation)

    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Στο PowerPoint, συγκρίνετε τις γραμμές για να δείτε το αποτέλεσμα της επέκτασης. Στην επάνω γραμμή, οι παρενθέσεις μεγαλώνουν για να περιβάλουν τον εκθέτη και φαίνονται όμοιες και για τα δύο σχήματα. Στην κάτω γραμμή, η επέκταση είναι απενεργοποιημένη. Οι μικρότερες παρενθέσεις στα αριστερά (`Centered`) ευθυγραμμίζονται με το ίσον, ενώ οι δεξιές (`Match`) κάθονται υψηλότερα γύρω από την έκφραση.

![Τέσσερις εξισώσεις στο PowerPoint με ενεργοποιημένη επέκταση οριοθέτη επάνω και απενεργοποιημένη από κάτω, και Centered στα αριστερά και Match στα δεξιά](delimiter-sizing.png)

## **Προσθήκη Πλαισίου Περιγράμματος**

Καλέστε το [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) σε ένα κλάσμα για να περικλείσετε ολόκληρη την έκφραση. Το επιστρεφόμενο [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) εμφανίζει όλα τα τέσσερα πλευρά από προεπιλογή. Χρησιμοποιήστε τις [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) και [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) για να αφαιρέσετε μεμονωμένα πλευρά.

Το παράδειγμα τοποθετεί έξι αντίγραφα του ίδιου κλάσματος σε μία διαφάνεια. Για να δείξετε ακύρωση, κρύψτε όλες τις πλευρές και δώστε την τιμή `True` στο [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) για διαγώνιο που ανεβαίνει (↗) ή στο [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) για διαγώνιο που κατεβαίνει (↘). Μπορείτε επίσης να χρησιμοποιήσετε το [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) ή το [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) με οποιονδήποτε συνδυασμό ορατών πλευρών.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    def add_fraction(x, y, hide_border):
        fraction = MathematicalText("x+1").divide("y+2")
        box = fraction.toBorderBox()
        box.setHideTop(hide_border)
        box.setHideBottom(hide_border)
        box.setHideLeft(hide_border)
        box.setHideRight(hide_border)

        shape = slide.getShapes().addMathShape(x, y, 160, 90)
        portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        portion.getPortionFormat().setFontHeight(28)
        math_block = MathBlock(box)
        portion.getMathParagraph().add(math_block)
        return box

    add_fraction(10, 10, False)

    partial = add_fraction(190, 10, False)
    partial.setHideTop(True)
    partial.setHideRight(True)

    add_fraction(370, 10, True).setStrikethroughBottomLeftToTopRight(True)
    add_fraction(10, 120, True).setStrikethroughTopLeftToBottomRight(True)
    add_fraction(190, 120, True).setStrikethroughHorizontal(True)
    add_fraction(370, 120, False).setStrikethroughVertical(True)

    presentation.save("border-box.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Έξι επεξεργάσιμα κλάσματα στο PowerPoint. Επάνω γραμμή: πλήρες περίγραμμα, κάτω και αριστερή πλευρά, διαγώνιο που ανεβαίνει. Κάτω γραμμή: διαγώνιο που κατεβαίνει, οριζόντια γραμμή, κάθετη γραμμή με πλήρες περίγραμμα](border-box-fractions.png)

Στο κλάσμα αυτό, η οριζόντια γραμμή διαπερνά τη μπάρα του κλάσματος. Η κάθετη γραμμή διασχίζει τόσο το αριθμητή όσο και τον παρονομαστή, ενώ το περιβάλλον περίγραμμα παραμένει ορατό. Αυτές οι γραμμές διακοσμούν ολόκληρη την έκφραση. Η τυπική διαγράμμιση κειμένου εφαρμόζεται σε χαρακτήρες ενός τμήματος κειμένου. Αφού επαναανοίξετε την παρουσίαση στο PowerPoint, μπορείτε ακόμη να επεξεργαστείτε ανεξάρτητα τον αριθμητή και τον παρονομαστή.

## **Έλεγχος Ορατότητας και Διάταξης με Φανταστικά Στοιχεία**

Τυλίξτε μια έκφραση σε [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) για να ελέγξετε την ορατότητά της και το χώρο που συνεισφέρει σε μια εξίσωση ανεξάρτητα. Οι μέθοδοι του [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) ελέγχουν τα παρακάτω:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | Δώστε `False` για να κρύψετε την έκφραση. Οι διαστάσεις της εξακολουθούν να συμβάλλουν στη διάταξη, εκτός εάν οι αντίστοιχες μέθοδοι παρακάτω λάβουν `True`. |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | Θεωρήστε το οριζόντιο πλάτος της έκφρασης ως μηδέν, επιτρέποντας στα γειτονικά στοιχεία να φτάσουν πιο κοντά. |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | Θεωρήστε το ανύψωμά της ως μηδέν. Αυτό μπορεί να μειώσει το χώρο που διατηρείται πάνω από τα γειτονικά στοιχεία. |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | Θεωρήστε το βάθος της ως μηδέν. Αυτό μπορεί να φέρει πιο κοντά το πλήκτρο του κλάσματος ή άλλο περιεχόμενο κάτω από την έκφραση. |

Η βασική γραμμή είναι η γραμμή αναφοράς πάνω στην οποία ξεκουράζονται τα κανονικά μαθηματικά γράμματα. Η απόκρυψη περιεχομένου δεν αφαιρεί τις διαστάσεις του, και η αντιμετώπιση μιας διάστασης ως μηδέν δεν διαγράφει την έκφραση. Η υποκείμενη έκφραση παραμένει διαθέσιμη μέσω του [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase). Δώστε `True` στο [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) για να την εμφανίσετε ξανά· οι ρυθμίσεις διάστασης παραμένουν αμετάβλητες.

Το παρακάτω παράδειγμα δημιουργεί πέντε παραλλαγές πλάι-πλάι: ένα ορατό κλάσμα, ένα κρυφό κλάσμα που διατηρεί χώρο, και τρία κρυφά κλάσματα με μία διάσταση αντιμετωπισμένη ως μηδέν. Κάθε παραλλαγή χρησιμοποιεί την ίδια περιβάλλουσα έκφραση και Cambria Math σε 24 σημεία. Όλες οι διαφάνειες εξίσωσης έχουν την ίδια θέση κορυφής, σημειωμένη από τον γκρι οδηγό. Η τοποθέτηση του phantom στον αριθμητή ενός εξωτερικού κλάσματος κάνει τις κατακόρυφες αλλαγές διάταξης πιο εμφανείς.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathBlock, MathFraction, MathematicalText, MathPhantom, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color


def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    labels = ("Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc")

    guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0)
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)

    for index, name in enumerate(labels):
        left = 10 + index * 200
        
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(14)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = MathFraction(fraction_numerator, fraction_denominator)
        phantom = MathPhantom(fraction)
        phantom.setShow(index == 0)
        phantom.setZeroWidth(index == 2)
        phantom.setZeroAsc(index == 3)
        phantom.setZeroDesc(index == 4)

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = MathFraction(numerator, denominator)

        shape = slide.getShapes().addMathShape(left, 60, 190, 100)
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        math_portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        math_paragraph = math_portion.getMathParagraph()
        math_block = MathBlock(equation)
        math_paragraph.add(math_block)

    presentation.save("math-phantom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Πέντε εξισώσεις στο PowerPoint που συγκρίνουν ένα ορατό κλάσμα, ένα κρυφό κλάσμα που διατηρεί χώρο και κρυφά κλάσματα με ZeroWidth, ZeroAsc ή ZeroDesc ενεργοποιημένα](math-phantom.png)

## **Ομαδοποίηση Όρων**

Χρησιμοποιήστε το [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) για να τοποθετήσετε έναν χαρακτήρα ομαδοποίησης πάνω ή κάτω από μια έκφραση. Προσθέστε ένα όριο για να επισημάνετε τους ομαδοποιημένους όρους.

![Η έκφραση x + y ομαδοποιημένη με την ετικέτα any text κάτω από αυτήν](powerpoint-math-equations_15.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathTopBotPositions, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    grouped = MathematicalText("x + y").group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top).setLowerLimit("any text")

    math_block = MathBlock(grouped)
    math_paragraph.add(math_block)

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Μορφοποίηση Μαθηματικών Στοιχείων**

Χρησιμοποιήστε βοηθητικά στοιχεία μορφοποίησης μόνο όπου διευκρινίζουν τον τύπο. Για παράδειγμα, το [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) τοποθετεί μια μπάρα πάνω από ένα μαθηματικό στοιχείο.

![Μια μαθηματική έκφραση ABC με μια μπάρα επάνω](powerpoint-math-equations_14.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    overbar = MathematicalText("ABC").overbar()

    math_block = MathBlock(overbar)
    math_paragraph.add(math_block)

    presentation.save("overbar.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Μορφοποίηση Κειμένου σε Υπάρχουσα Εξίσωση**

Για να μορφοποιήσετε κείμενο σε όλη μια υπάρχουσα εξίσωση, διασχίστε το δέντρο στοιχείων κάθε μαθηματικού μπλοκ. Η μέθοδος [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) επιστρέφει μόνο τα άμεσά παιδιά, οπότε καλέστε την αναδρομικά για να φτάσετε στο κείμενο μέσα σε κλάσματα, εκθέτες, ρίζες και άλλες ένθετες δομές. Ελέγξτε το τρέχον στοιχείο καθώς και τα παιδιά του ώστε να συμπεριλάβετε το αρχικό στοιχείο όταν αυτό είναι [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/).

Αυτό το παράδειγμα θεωρεί ότι το `input.pptx` περιέχει μια εξίσωση όπως `z = xᵢ / ∛y`, με κλάσμα που περιέχει δείκτη στον αριθμητή και ρίζα στον παρονομαστή. Η επεξεργασία μόνο των κορυφαίων στοιχείων του μπλοκ θα παρέλεινε το κείμενο μέσα στο κλάσμα. Το παράδειγμα εντοπίζει μαθηματικές περιοχές σε πλαίσια κειμένου διαφανειών, προσπελαύνει τα μπλοκ τους μέσω του [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) και χρησιμοποιεί το [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) για να ορίσει το μέγεθος γραμματοσειράς σε 28 σημεία σε κάθε στοιχείο κειμένου μέσω της μεθόδου [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathematicalText, MathPortion, Presentation, SaveFormat


def format_math_text(element):
    if isinstance(element, MathematicalText):
        element.getFormat().setFontHeight(28)

    for child in element.getChildren():
        format_math_text(child)


presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    if isinstance(portion, MathPortion):
                        for block in portion.getMathParagraph():
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η αποθηκευμένη παρουσίαση περιέχει την ενημερωμένη μορφοποίηση κειμένου σε κάθε επίπεδο κάθε επεξεργασμένης εξίσωσης, διατηρώντας το περιεχόμενο κειμένου και τη μαθηματική δομή.

## **Σύντομη Αναφορά**

| Εργασία | Κύριο API |
| --- | --- |
| Δημιουργία μαθηματικού κειμένου | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| Συνδυασμός στοιχείων | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| Δημιουργία κλασμάτων | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| Προσθήκη εκθέτη ή δείκτη | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| Προσθήκη συναρτήσεων | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| Προσθήκη ριζών | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| Προσθήκη ορίων | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| Προσθήκη εκθέτη στην αριστερή πλευρά | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| Προσθήκη αθροίσεων και ολοκληρωμάτων | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| Προσθήκη πινάκων | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| Προσθήκη πινάκων εξισώσεων | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| Προσθήκη οριοθέτη | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| Προσθήκη μπάρας και περιγράμματος | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| Ομαδοποίηση όρων | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **Συχνές Ερωτήσεις**

**Μπορώ να επεξεργαστώ μια υπάρχουσα εξίσωση PowerPoint;**

Ναι. Ανοίξτε την παρουσίαση, εντοπίστε το σχήμα που περιέχει ένα [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), καλέστε το [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) και ενημερώστε τα μαθηματικά μπλοκ σε αυτήν την παράγραφο.

**Αποθηκεύονται οι εξισώσεις ως επεξεργάσιμα μαθηματικά του PowerPoint;**

Ναι. Όταν αποθηκεύετε σε PPTX, το Aspose.Slides γράφει την εξίσωση ως επεξεργάσιμο περιεχόμενο Office math.

**Μπορώ να εξάγω εξισώσεις σε LaTeX;**

Ναι. Πάρετε το [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) της [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) και καλέστε το [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) για άμεση εξαγωγή. Για πλήρες παράδειγμα, δείτε το [Export Math Equations from Presentations in Python](/slides/el/python-java/exporting-math-equations/#export-math-equations-to-latex).