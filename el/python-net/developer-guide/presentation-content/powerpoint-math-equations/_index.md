---
title: Προσθήκη μαθηματικών εξισώσεων σε παρουσιάσεις PowerPoint με Python
linktitle: Μαθηματικές εξισώσεις PowerPoint
type: docs
weight: 80
url: /el/python-net/powerpoint-math-equations/
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
- Aspose.Slides
description: "Εισαγωγή και επεξεργασία μαθηματικών εξισώσεων σε PowerPoint PPT και PPTX με το Aspose.Slides για Python μέσω .NET, υποστηρίζοντας OMML, ελέγχους μορφοποίησης και σαφή παραδείγματα κώδικα Python."
---
## **Επισκόπηση**

Το PowerPoint αποθηκεύει εξισώσεις ως Office Math Markup Language (OMML). Με το Aspose.Slides for Python μέσω .NET, μπορείτε να δημιουργήσετε το ίδιο είδος μαθηματικού περιεχομένου προγραμματιστικά: κλάσματα, ριζικά, συναρτήσεις, όρια, τελεστές N-ary, πίνακες, πίνακες (arrays) και μορφοποιημένα μαθηματικά μπλοκ.

Στο PowerPoint, οι χρήστες συνήθως προσθέτουν εξισώσεις από **Insert > Equation**:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

Το αποτέλεσμα είναι επεξεργάσιμο μαθηματικό κείμενο στη διαφάνεια:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Το Aspose.Slides δημιουργεί αυτό το μαθηματικό κείμενο μέσω τριών κύριων αντικειμένων:

- Ένα μαθηματικό σχήμα, που δημιουργείται με [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), είναι το σχήμα που περιέχει την εξίσωση.
- Το [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) αποθηκεύει το μαθηματικό περιεχόμενο μέσα στο πλαίσιο κειμένου του σχήματος.
- Το [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) περιέχει ένα ή περισσότερα αντικείμενα [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

Τα περισσότερα παραδείγματα παρακάτω χρησιμοποιούν το [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) και τις αερογραμμικές μεθόδους του [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) για να κρατήσουν τον κώδικα σύντομο και ευανάγνωστο.

Για σενάρια εξαγωγής MathML, δείτε το [Export Math Equations from Presentations in Python via .NET](/slides/el/python-net/exporting-math-equations/).

## **Δημιουργία εξίσωσης**

Αυτό το παράδειγμα χρησιμοποιεί το [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) για να δημιουργήσει ένα μαθηματικό σχήμα και προσθέτει το πυθαγόρειο θεώρημα:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation = (
        math.MathematicalText("c")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("a").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("b").set_superscript("2"))
    )

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Σημείωση" %}}

[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) δημιουργεί ένα σχήμα που περιέχει ήδη μια μαθηματική παράγραφο. Πρόσβαση στο πρώτο [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), λήψη του [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), και προσθήκη μαθηματικών μπλοκ ή στοιχείων σε αυτό.

{{% /alert %}}

## **Προσθήκη κλασμάτων**

Χρησιμοποιήστε το [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) για να δημιουργήσετε ένα κλάσμα. Μπορείτε να επιλέξετε στυλ κλάσματος με το [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/).

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("1").divide("x", math.MathFractionTypes.SKEWED)

    math_paragraph.add(math.MathBlock(fraction))

    presentation.save("fraction.pptx", slides.export.SaveFormat.PPTX)
```

Για ένα στοιβαγμένο κλάσμα, χρησιμοποιήστε το [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/):

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Προσθήκη ριζικών**

Χρησιμοποιήστε το [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) για να δημιουργήσετε τετραγωνική ρίζα, κύβο ή άλλη ρίζα. Το τρέχον στοιχείο γίνεται η βάση, και το όρισμα το βαθμό.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    radical = math.MathematicalText("x").radical("n")

    math_paragraph.add(math.MathBlock(radical))

    presentation.save("radical.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσθήκη συναρτήσεων και ορίων**

Χρησιμοποιήστε το [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) ή το [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) για συναρτήσεις όπως `sin(x)`, `log(x)`, ή προσαρμοσμένα ονόματα συναρτήσεων. Για όρια, τοποθετήστε το `lim` σε ένα [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) ή χρησιμοποιήστε το [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    limit = (
        math.MathematicalText("lim")
        .set_lower_limit("x\u2192\u221E")
        .function("x")
    )

    math_paragraph.add(math.MathBlock(limit))

    presentation.save("functions-and-limits.pptx", slides.export.SaveFormat.PPTX)
```

Για προσαρμοσμένο όνομα συνάρτησης, θέστε το όνομα της συνάρτησης ως τρέχον στοιχείο και καλέστε το [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) με το όρισμά του:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **Προσθήκη τελεστών N-ary και ολοκληρωτών**

Χρησιμοποιήστε το [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) για αθροίσματα, ενώσεις, τομές και άλλους μεγάλους τελεστές. Χρησιμοποιήστε το [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) για ολοκληρώματα. Και οι δύο μέθοδοι επιτρέπουν τον καθορισμό κατώτερων και ανώτερων ορίων.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    summation_base = (
        math.MathematicalText("x")
        .set_superscript("k")
        .join(math.MathematicalText("a").set_superscript("n-k"))
    )

    summation = summation_base.nary(math.MathNaryOperatorTypes.SUMMATION, "k=0", "n")

    math_paragraph.add(math.MathBlock(summation))

    presentation.save("nary-operators.pptx", slides.export.SaveFormat.PPTX)
```

Οι τελεστές N-ary είναι για μεγάλους τελεστές με προαιρετικά όρια. Απλοί τελεστές όπως `+`, `-`, και `=` προστίθενται συνήθως ως [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) και ενσωματώνονται στην έκφραση.

Για ολοκληρωμό, χρησιμοποιήστε το [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/):

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Προσθήκη πινάκων**

Χρησιμοποιήστε το [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) για γραμμές και στήλες. Οι πίνακες δεν περιλαμβάνουν αγκύλες από προεπιλογή, έτσι περιβάλτε τον πίνακα όταν χρειάζεστε παρενθέσεις, αγκύλες ή αγκίστρες.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # Ένας πίνακας δεν έχει δικές του αγκύλες, γι' αυτό περικλείστε τον σε παρενθέσεις.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Προειδοποίηση" %}}

`MathMatrix` δημιουργεί το πλέγμα γραμμών και στηλών, ορίζει τα κενά μεταξύ τους και ευθυγραμμίζει τις στήλες, αλλά το Aspose.Slides for Python μέσω .NET δεν εκθέτει πρόσβαση σε ξεχωριστά κελιά πίνακα. Ένας πίνακας που δημιουργείται σε κώδικα διατηρεί κενά κελιά· τα κελιά πίνακα που προέρχονται από υπάρχουσα παρουσίαση μπορούν να διαβαστούν με `get_children`. Χρησιμοποιήστε έναν πίνακα εξίσωσης όταν χρειάζεται να γεμίσετε γραμμές από κώδικα.

{{% /alert %}}

## **Προσθήκη πινάκων εξίσωσης**

Χρησιμοποιήστε το [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) όταν χρειάζεστε ευθυγραμμισμένες εξισώσεις ή κατακόρυφο στοίβαγμα εκφράσεων.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 140)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation_array = (
        math.MathematicalText("x")
        .join("y")
        .to_math_array()
    )

    math_paragraph.add(math.MathBlock(equation_array))

    presentation.save("equation-array.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσθήκη τριγωνομετρικών συναρτήσεων**

Χρησιμοποιήστε το [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) όταν το όρισμα είναι το τρέχον στοιχείο και το όνομα της συνάρτησης είναι γνωστό.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    cosine = math.MathematicalText("2x").as_argument_of_function(
        math.MathFunctionsOfOneArgument.COS
    )

    math_paragraph.add(math.MathBlock(cosine))

    presentation.save("trigonometric-function.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσθήκη υποδείκτων και εκθέτων**

Χρησιμοποιήστε τις βοηθητικές λειτουργίες υποδεικτών και εκθετών για δείκτες και δυνάμεις. Όταν οι δείκτες πρέπει να εμφανιστούν στην αριστερή πλευρά της βάσης, χρησιμοποιήστε το [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    scripts = math.MathematicalText("Y").set_sub_superscript_on_the_left("1", "n")

    math_paragraph.add(math.MathBlock(scripts))

    presentation.save("subscript-superscript.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσθήκη οριοθετητών**

Χρησιμοποιήστε το [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) για να τοποθετήσετε μια έκφραση μέσα σε οριοθετητές. Μπορείτε επίσης να ορίσετε χαρακτήρα διαχωριστή για οριοθετητές που περιέχουν πολλά στοιχεία.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    delimiter = (
        math.MathematicalText("x")
        .join("y")
        .join("z")
        .enclose("<", ">")
    )
    delimiter.separator_character = "|"

    math_paragraph.add(math.MathBlock(delimiter))

    presentation.save("delimiters.pptx", slides.export.SaveFormat.PPTX)
```

### **Μέγεθος και ευθυγράμμιση οριοθετητών**

Ορίστε το [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) σε `True` για να επιτρέψετε στις παρενθέσεις να μεγαλώσουν γύρω από ένα ψηλό όργανο, ή σε `False` για να παραμείνουν στο κανονικό μέγεθός τους. Το [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) δέχεται μία από τις δύο τιμές του [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/). Το `CENTERED` κεντράρει τις παρενθέσεις στον μαθηματικό άξονα, ο οποίος περνάει από το μέσο του ίσου. Το `MATCH` τις ευθυγραμμίζει με το περιεχόμενο που περικλείεται. Και οι δύο ρυθμίσεις επηρεάζουν μόνο τους οριοθετητές. Η έκφραση μέσα παραμένει η ίδια.

Το παράδειγμα τοποθετεί ένα κλάσμα στον εκθέτη του `x` ώστε η έκφραση να εκτείνεται περισσότερο πάνω από τη γραμμή βάσης απ' ό,τι κάτω από αυτή. Οι τέσσερις εξισώσεις χρησιμοποιούν τις ίδιες παρενθέσεις και ρυθμίσεις γραμματοσειράς.

```python
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_expression(slide, left, top, grow, shape):
    fraction = math.MathematicalText("a + b").divide("c + d")
    power = math.MathematicalText("x").set_superscript(fraction)
    delimiter = power.enclose("(", ")")
    delimiter.grow_to_match_operand_height = grow
    delimiter.delimiter_shape = shape

    math_shape = slide.shapes.add_math_shape(left, top, 300, 100)
    portion = math_shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 32
    equation = math.MathematicalText("y = ").join(delimiter)
    portion.math_paragraph.add(equation)


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    add_expression(slide, 20, 20, True, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 20, True, math.MathDelimiterShape.MATCH)
    add_expression(slide, 20, 140, False, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 140, False, math.MathDelimiterShape.MATCH)

    presentation.save("delimiter-sizing.pptx", slides.export.SaveFormat.PPTX)
```

Στο PowerPoint, συγκρίνετε τις σειρές για να δείτε το αποτέλεσμα της ανάπτυξης. Στην κορυφαία σειρά, οι παρενθέσεις μεγαλώνουν για να περικλείσουν τον εκθέτη και φαίνονται όμοιες για τα δύο σχήματα. Στη κάτω σειρά, η ανάπτυξη είναι απενεργοποιημένη. Οι μικρότερες παρενθέσεις στα αριστερά (`CENTERED`) ευθυγραμμίζονται με το σύμβολο ίσου, ενώ οι δεξιές (`MATCH`) στούν υψηλότερα γύρω από την έκφραση.

![Four equations in PowerPoint with delimiter growth enabled above and disabled below, and Centered on the left and Match on the right](delimiter-sizing.png)

## **Προσθήκη πλαισίου περιγράμματος**

Καλέστε το [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) σε ένα κλάσμα για να περικλείσετε ολόκληρη την έκφραση. Το επιστρεφόμενο [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) εμφανίζει όλα τα τέσσερα πλευρά από προεπιλογή. Χρησιμοποιήστε τα [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/), και [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) για να αφαιρέσετε μεμονωμένες πλευρές.

Το παράδειγμα τοποθετεί έξι αντίγραφα του ίδιου κλάσματος σε μία διαφάνεια. Για να δείξετε ακύρωση, κρύψτε όλες τις πλευρές και ορίστε το [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) για διαγώνιο που ανεβαίνει (↗) ή το [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) για διαγώνιο που κατεβαίνει (↘). Μπορείτε επίσης να χρησιμοποιήσετε το [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) ή το [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) με οποιοδήποτε συνδυασμό εμφανιζόμενων πλευρών.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_fraction(slide, x, y, hide_border=False):
    fraction = math.MathematicalText("x+1").divide("y+2")
    box = fraction.to_border_box()
    box.hide_top = box.hide_bottom = box.hide_left = box.hide_right = hide_border

    shape = slide.shapes.add_math_shape(x, y, 160, 90)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 28
    portion.math_paragraph.add(math.MathBlock(box))
    return box


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(540, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    add_fraction(slide, 10, 10)

    partial = add_fraction(slide, 190, 10)
    partial.hide_top = True
    partial.hide_right = True

    add_fraction(slide, 370, 10, hide_border=True).strikethrough_bottom_left_to_top_right = True
    add_fraction(slide, 10, 120, hide_border=True).strikethrough_top_left_to_bottom_right = True
    add_fraction(slide, 190, 120, hide_border=True).strikethrough_horizontal = True
    add_fraction(slide, 370, 120).strikethrough_vertical = True

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

![Six editable fractions in PowerPoint. Top row: full border, bottom and left sides, rising diagonal. Bottom row: falling diagonal, horizontal strike, vertical strike with a full border.](border-box-fractions.png)

Σε αυτό το κλάσμα, η οριζόντια γραμμή διαγράφησης επικαλύπτει τη γραμμή του κλάσματος. Η κάθετη γραμμή διαγράφησης διασχίζει τόσο τον αριθμητή όσο και τον παρονομαστή, ενώ το περιβλήσιμο πλαίσιο παραμένει ορατό. Αυτές οι γραμμές διακοσμούν ολόκληρη την έκφραση. Η συνηθισμένη διαγράφητη κειμένου εφαρμόζεται σε χαρακτήρες μέσα σε ένα τμήμα κειμένου. Μετά το άνοιγμα ξανά της παρουσίασης στο PowerPoint, μπορείτε ακόμη να επεξεργαστείτε ανεξάρτητα τον αριθμητή και τον παρονομαστή.

## **Ομαδοποίηση όρων**

Χρησιμοποιήστε το [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) για να τοποθετήσετε έναν χαρακτήρα ομαδοποίησης πάνω ή κάτω από μια έκφραση. Προσθέστε όριο για να επισημάνετε τους ομαδοποιημένους όρους.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    grouped = (
        math.MathematicalText("x + y")
        .group(chr(0x23DF), math.MathTopBotPositions.BOTTOM, math.MathTopBotPositions.TOP)
        .set_lower_limit("any text")
    )

    math_paragraph.add(math.MathBlock(grouped))

    presentation.save("grouped-terms.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαμόρφωση μαθηματικών στοιχείων**

Χρησιμοποιήστε βοηθητικές λειτουργίες μορφοποίησης μόνο όταν ξεκαθαρίζουν τον τύπο. Για παράδειγμα, το [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) τοποθετεί μια μπάρα πάνω από ένα μαθηματικό στοιχείο.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    overbar = math.MathematicalText("ABC").overbar()

    math_paragraph.add(math.MathBlock(overbar))

    presentation.save("overbar.pptx", slides.export.SaveFormat.PPTX)
```

### **Διαμόρφωση κειμένου σε υπάρχουσα εξίσωση**

Για να μορφοποιήσετε κείμενο σε όλη την υπάρχουσα εξίσωση, διασχίστε το δέντρο στοιχείων κάθε μαθηματικού μπλοκ. Η μέθοδος [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) επιστρέφει μόνο τα άμεσα παιδιά, επομένως καλέστε την αναδρομικά για να φτάσετε σε κείμενο μέσα σε κλάσματα, εκθέτες, ριζικά και άλλες έντονες δομές. Ελέγξτε το τρέχον στοιχείο καθώς και τα παιδιά του ώστε να συμπεριλάβετε το αρχικό στοιχείο όταν είναι [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Αυτό το παράδειγμα υποθέτει ότι το `input.pptx` περιέχει μια εξίσωση όπως `z = xᵢ / ∛y`, με ένα κλάσμα που περιέχει υποδείκτη στον αριθμητή και ριζικό στον παρονομαστή. Η επεξεργασία μόνο των στοιχείων της κορυφαίας επιπέδου του μπλοκ θα μετέλεινε το κείμενο μέσα στο κλάσμα. Το παράδειγμα βρίσκει μαθηματικά τμήματα σε πλαίσια κειμένου διαφανειών, προσπελαύνει τα μπλοκ τους μέσω του [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), και ορίζει το [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) σε 28 σημεία για κάθε στοιχείο κειμένου μέσω της ιδιότητας [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/).

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def format_math_text(element):
    if isinstance(element, math.MathematicalText):
        element.format.font_height = 28

    for child in element.get_children():
        format_math_text(child)


with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if isinstance(portion, math.MathPortion):
                        for block in portion.math_paragraph:
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", slides.export.SaveFormat.PPTX)
```

Η αποθηκευμένη παρουσίαση περιέχει την ενημερωμένη μορφοποίηση κειμένου σε κάθε επίπεδο κάθε επεξεργασμένης εξίσωσης, διατηρώντας ταυτόχρονα το περιεχόμενο κειμένου και τη μαθηματική δομή.

## **Γρήγορη αναφορά**

| Εργασία | Κύριο API |
| --- | --- |
| Δημιουργία μαθηματικού κειμένου | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Συνένωση στοιχείων | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| Δημιουργία κλασμάτων | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Προσθήκη εκθέτη ή υποδείκτη | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Προσθήκη συναρτήσεων | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Προσθήκη ριζικών | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Προσθήκη ορίων | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Προσθήκη αριστερών εκθέτων | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Προσθήκη αθροίσεων και ολοκληρωμάτων | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Προσθήκη πινάκων | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Προσθήκη πινάκων εξίσωσης | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Προσθήκη οριοθετητών | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Προσθήκη ράβδων και πλαισίων | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Ομαδοποίηση όρων | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **Συχνές ερωτήσεις**

**Μπορώ να επεξεργαστώ μια υπάρχουσα εξίσωση PowerPoint;**

Ναι. Ανοίξτε την παρουσίαση, εντοπίστε το σχήμα που περιέχει ένα [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), πάρτε το [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), και ενημερώστε τα μαθηματικά μπλοκ σε αυτήν την παράγραφο.

**Αποθηκεύονται οι εξισώσεις ως επεξεργάσιμο μαθηματικό PowerPoint;**

Ναι. Όταν αποθηκεύετε σε PPTX, το Aspose.Slides γράφει την εξίσωση ως επεξεργάσιμο περιεχόμενο Office Math.

**Μπορώ να εξάγω εξισώσεις σε LaTeX;**

Ναι. Πάρτε το [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) από το [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), και καλέστε το [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) για να το εξάγετε απευθείας. Για ένα πλήρες παράδειγμα, δείτε το [Export Math Equations from Presentations in Python via .NET](/slides/el/python-net/exporting-math-equations/#export-math-equations-to-latex).