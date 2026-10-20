---
title: Αλλαγή Μεγέθους Σχημάτων σε Διαφάνειες Παρουσίασης με Python μέσω Java
type: docs
weight: 110
url: /el/python-java/resizing-shapes-on-slide/
aliases:
  - /el/python-java/re-sizing-shapes-on-slide/
  /python-java/re-sizing-shapes-on-slide/
keywords:
  - αλλαγή μεγέθους σχήματος
  - αλλαγή μεγέθους σχήματος
  - PowerPoint
  - OpenDocument
  - παρουσίαση
  - Python
  - Java
  - Aspose.Slides
description: "Διευκολύνετε την αλλαγή μεγέθους των σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω Java—αυτοματοποιήστε τις προσαρμογές διάταξης διαφάνειας και αυξήστε την παραγωγικότητα."
---
## **Επισκόπηση**

Όταν αλλάζετε το μέγεθος διαφάνειας μιας παρουσίασης, μπορεί επίσης να χρειαστεί να αλλάξετε το μέγεθος και τη θέση των σχημάτων της ώστε να ταιριάζουν με τις νέες διαστάσεις. Αυτό το άρθρο δείχνει πώς να κλιμακώσετε τα σχήματα χειροκίνητα και πώς να χειριστείτε πίνακες σε διαφάνειες, κύριες διαφάνειες και διατάξεις.

## **Αναπροσαρμογή Σχημάτων**

Για να διατηρήσετε τη σχετική θέση και το μέγεθος κάθε σχήματος, πολλαπλασιάστε τις οριζόντιες συντεταγμένες του και το πλάτος του με το λόγο του νέου πλάτους διαφάνειας προς το αρχικό πλάτος. Εφαρμόστε το αντίστοιχο λόγο ύψους στις κατακόρυφες συντεταγμένες του και στο ύψος του.

Το πρώτο παράδειγμα φορτώνει μια παρουσίαση της οποίας οι διαφάνειες δεν περιέχουν πίνακες, αλλάζει το μέγεθος διαφάνειας σε A4 και αποθηκεύει το αποτέλεσμα. Χρησιμοποιεί [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) με [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) ώστε το επόμενο βρόχο να ελέγχει την κλιμάκωση. Οι λόγοι είναι χωρίς μονάδες· οι θέσεις και οι διαστάσεις των σχημάτων μετρώνται σε points. Διαφορετικοί λόγοι πλάτους και ύψους μπορούν να παραμορφώσουν τα σχήματα, και η αλλαγή των διαστάσεων ενός σχήματος δεν κλιμακώνει τα μεγέθη γραμματοσειράς.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Υπολογίστε ανεξάρτητους οριζόντιους και κάθετους συντελεστές κλίμακας.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Οι πίνακες απαιτούν ξεχωριστό χειρισμό: κλιμακώστε το πλάτος των στηλών τους και το ύψος των γραμμών αντί να ορίσετε το συνολικό πλάτος και ύψος του πίνακα. Το ύψος των γραμμών μπορεί να παραμείνει μεγαλύτερο από το ζητούμενο εάν το περιεχόμενο των κελιών απαιτεί περισσότερο χώρο.
{{% /alert %}}

Το δεύτερο παράδειγμα υποστηρίζει πίνακες και επεξεργάζεται σχήματα σε κύριες διαφάνειες και διατάξεις καθώς και σε μεμονωμένες διαφάνειες πριν αποθηκευτεί η αλλαγμένη παρουσίαση. Η βοηθητική του λειτουργία διαχειρίζεται κάθε [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) κλιμακώνοντας το πλάτος των στηλών με τη μέθοδο [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) και το ελάχιστο ύψος των γραμμών με τη μέθοδο [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Στη συνέχεια κλιμακώνει τη θέση του πίνακα χωρίς να κλιμακώσει ξεχωριστά τις συνολικές του διαστάσεις.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # Οι διαστάσεις του πίνακα ελέγχονται από το πλάτος των στηλών και το ύψος των γραμμών.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # Υπολογίστε ανεξάρτητους οριζόντιους και κάθετους συντελεστές κλίμακας.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Αλλάξτε το μέγεθος των σχημάτων που ορίζονται σε κύριες διαφάνειες και διατάξεις καθώς και σε μεμονωμένες διαφάνειες.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Γιατί τα σχήματα παραμορφώνονται ή περικλείονται μετά την αλλαγή του μεγέθους μιας διαφάνειας;**

Αν αλλάξετε το μέγεθος της διαφάνειας χωρίς να κλιμακώσετε τα σχήματα, αυτά διατηρούν τις αρχικές τους θέσεις και διαστάσεις και μπορεί να εκτείνεται πέρα από τη διαφάνεια. Η κλιμάκωση του πλάτους και του ύψους με διαφορετικούς λόγους μπορεί επίσης να παραμορφώσει τα σχήματα.

**Λειτουργεί ο παρεχόμενος κώδικας για όλους τους τύπους σχημάτων;**

Το πρώτο παράδειγμα αλλάζει τα όρια των σχημάτων άμεσα και προορίζεται για διαφάνειες χωρίς πίνακες. Το δεύτερο παράδειγμα διαχειρίζεται τους πίνακες ξεχωριστά. Ελέγξτε τη τελική διάταξη, ιδιαίτερα το κείμενο και τους πίνακες, επειδή αυτά τα παραδείγματα δεν κλιμακώνουν τα μεγέθη γραμματοσειράς και το περιεχόμενο των πινάκων μπορεί να περιορίσει το ύψος των γραμμών.

**Πώς μπορώ να αλλάξω το μέγεθος των πινάκων όταν αλλάζω το μέγεθος μιας διαφάνειας;**

Κλιμακώστε το πλάτος των στηλών με τον λόγο πλάτους και το ελάχιστο ύψος των γραμμών με τον λόγο ύψος, μετά κλιμακώστε τη θέση του πίνακα, όπως φαίνεται στο δεύτερο παράδειγμα.

**Θα λειτουργήσει αυτή η αλλαγή μεγέθους για κύριες διαφάνειες και διαφάνειες διάταξης;**

Ναι. Το δεύτερο παράδειγμα διατρέχει τις [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) και τις [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) κάθε κύριας διαφάνειας και εφαρμόζει την ίδια λογική αλλαγής μεγέθους στα σχήματά τους.

**Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (κατακόρυφα/οριζόντια) μαζί με την αλλαγή μεγέθους;**

Ναι. Καλέστε τη μέθοδο [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) μετά την αλλαγή του μεγέθους της διαφάνειας και πριν διαβάσετε τις στοχευμένες διαστάσεις, ώστε οι συντελεστές κλίμακας να αντικατοπτρίζουν τον τελικό προσανατολισμό.

**Υπάρχει κάποιο όριο στο μέγεθος διαφάνειας που μπορώ να ορίσω;**

Μπορείτε να ορίσετε προσαρμοσμένες διαστάσεις διαφάνειας με τη μέθοδο [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). Οι υποστηριζόμενες διαστάσεις εξαρτώνται επίσης από τη μορφή της παρουσίασης και την εφαρμογή που χρησιμοποιείται για το άνοιγμα του αρχείου.

**Πώς μπορώ να αποτρέψω τα σχήματα με σταθερό λόγο διαστάσεων να παραμορφώνονται;**

Χρησιμοποιήστε τον ίδιο συντελεστή κλίμακας για το πλάτος και το ύψος. Για να χωρέσετε την αρχική διάταξη μέσα στις νέες διαστάσεις της διαφάνειας, χρησιμοποιήστε το μικρότερο από τους λόγους πλάτους και ύψους και για τις δύο διαστάσεις και τις θέσεις. Αυτό διατηρεί τις αναλογίες αλλά μπορεί να αφήσει αχρησιμοποίητο χώρο κατά μήκος μιας πλευράς.