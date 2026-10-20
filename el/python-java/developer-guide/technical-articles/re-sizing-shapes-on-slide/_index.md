---
title: Αλλαγή μεγέθους σχημάτων σε διαφάνειες παρουσίασης με Python μέσω Java
type: docs
weight: 110
url: /el/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/re-sizing-shapes-on-slide/
  - /el/python-java/re-sizing-shapes-on-slide/
keywords:
- αλλαγή μεγέθους σχήματος
- αλλαγή μεγέθους σχήματος
- παρουσίαση
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Απλά αλλάξτε το μέγεθος των σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω Java—αυτοματοποιήστε τις ρυθμίσεις διάταξης διαφανειών και αυξήστε την παραγωγικότητα."
---
## **Επισκόπηση**

Όταν αλλάζετε το μέγεθος των διαφανειών μιας παρουσίασης, μπορεί επίσης να χρειαστεί να αλλάξετε το μέγεθος και τη θέση των σχημάτων της ώστε να ταιριάζουν με τις νέες διαστάσεις. Αυτό το άρθρο δείχνει πώς να κλιμακώνετε τα σχήματα χειροκίνητα και πώς να διαχειρίζεστε πίνακες στις διαφάνειες, στα master και στα layout.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να διατηρήσετε τη σχετική θέση και το μέγεθος κάθε σχήματος, πολλαπλασιάστε τις οριζόντιες συντεταγμένες και το πλάτος του με το λόγο του νέου πλάτους της διαφάνειας προς το αρχικό πλάτος. Εφαρμόστε τον αντίστοιχο λόγο ύψους στις κάθετες συντεταγμένες και στο ύψος του.

Το πρώτο παράδειγμα φορτώνει μια παρουσίαση των οποίων οι διαφάνειες δεν περιέχουν πίνακες, αλλάζει το μέγεθος της διαφάνειας σε A4 και αποθηκεύει το αποτέλεσμα. Χρησιμοποιεί [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) με [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) ώστε η επόμενη βρόχος να ελέγχει την κλίμακα. Οι λόγοι είναι χωρίς μονάδα· οι θέσεις και οι διαστάσεις των σχημάτων μετρώνται σε σημείο. Διαφορετικοί λόγοι πλάτους και ύψους μπορούν να παραμορφώσουν τα σχήματα, και η αλλαγή διαστάσεων ενός σχήματος δεν κλιμακώνει τα μεγέθη γραμματοσειράς.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Υπολογίστε ανεξάρτητους οριζόντιους και κατακόρυφους συντελεστές κλίμακας.
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
Οι πίνακες απαιτούν ξεχωριστή διαχείριση: κλιμακώνετε το πλάτος των στηλών τους και το ύψος των γραμμών αντί να ορίζετε το συνολικό πλάτος και ύψος του πίνακα. Τα ύψη των γραμμών μπορεί να παραμείνουν μεγαλύτερα από το ζητούμενο εάν το περιεχόμενο των κελιών απαιτεί περισσότερο χώρο.
{{% /alert %}}

Το δεύτερο παράδειγμα υποστηρίζει πίνακες και επεξεργάζεται σχήματα στα master και στα layout, καθώς και σε μεμονωμένες διαφάνειες, προτού αποθηκεύσει την αλλαγμένη παρουσίαση. Ο βοηθός του χειρίζεται κάθε [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) κλιμακώνοντας το πλάτος των στηλών με [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) και το ελάχιστο ύψος των γραμμών με [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Στη συνέχεια κλιμακώνει τη θέση του πίνακα χωρίς να κλιμακώνει ξεχωριστά τις συνολικές διαστάσεις του.

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
    # Υπολογίστε ανεξάρτητα οριζόντιους και κατακόρυφους συντελεστές κλίμακας.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Αλλάξτε το μέγεθος των σχημάτων που ορίζονται σε master και layout, καθώς και σε μονές διαφάνειες.
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

## **Συχνές ερωτήσεις**

**Γιατί παραμορφώνονται ή κόβονται τα σχήματα μετά την αλλαγή του μεγέθους μιας διαφάνειας;**

Αν αλλάξετε το μέγεθος της διαφάνειας χωρίς να κλιμακώσετε τα σχήματα, αυτά διατηρούν τις αρχικές θέσεις και διαστάσεις τους και μπορεί να εκτείνονται πέρα από τη διαφάνεια. Η κλιμάκωση του πλάτους και του ύψους με διαφορετικές αναλογίες μπορεί επίσης να παραμορφώσει τα σχήματα.

**Λειτουργεί ο παρεχόμενος κώδικας για όλους τους τύπους σχημάτων;**

Το πρώτο παράδειγμα αλλάζει τα όρια του σχήματος απευθείας και προορίζεται για διαφάνειες χωρίς πίνακες. Το δεύτερο παράδειγμα διαχειρίζεται τους πίνακες ξεχωριστά. Ελέγξτε τη διαρρύθμιση που προκύπτει, ιδιαίτερα το κείμενο και τους πίνακες, καθώς αυτά τα παραδείγματα δεν κλιμακώνουν τα μεγέθη γραμματοσειράς και το περιεχόμενο των πινάκων μπορεί να περιορίζει τα ύψη των γραμμών.

**Πώς αλλάζω το μέγεθος των πινάκων όταν αλλάζω το μέγεθος μιας διαφάνειας;**

Κλιμακώστε το πλάτος των στηλών με τον λόγο πλάτους και το ελάχιστο ύψος των γραμμών με τον λόγο ύψους, στη συνέχεια κλιμακώστε τη θέση του πίνακα, όπως φαίνεται στο δεύτερο παράδειγμα.

**Θα λειτουργήσει αυτή η αλλαγή μεγέθους για master διαφάνειες και διαφάνειες layout;**

Ναι. Το δεύτερο παράδειγμα διατρέχει τις [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) και για κάθε master τις [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) και εφαρμόζει την ίδια λογική αλλαγής μεγέθους στα σχήματά τους.

**Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (πορτραίτο/τοπίο) μαζί με την αλλαγή μεγέθους;**

Ναι. Καλείτε το [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) μετά την αλλαγή του μεγέθους της διαφάνειας και πριν διαβάσετε τις στοχευμένες διαστάσεις, ώστε οι συντελεστές κλιμάκωσης να αντικατοπτρίζουν τον τελικό προσανατολισμό.

**Υπάρχει όριο στο μέγεθος της διαφάνειας που μπορώ να ορίσω;**

Μπορείτε να ορίσετε προσαρμοσμένες διαστάσεις διαφάνειας με το [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). Οι υποστηριζόμενες διαστάσεις εξαρτώνται επίσης από τη μορφή της παρουσίασης και την εφαρμογή που χρησιμοποιείται για το άνοιγμα του αρχείου.

**Πώς μπορώ να αποτρέψω τα σχήματα με σταθερό λόγο διαστάσεων να παραμορφώνονται;**

Χρησιμοποιήστε τον ίδιο συντελεστή κλίμακας για το πλάτος και το ύψος. Για να ταιριάξετε την αρχική διάταξη μέσα στις νέες διαστάσεις της διαφάνειας, χρησιμοποιήστε το μικρότερο από το λόγο πλάτους και το λόγο ύψους για και τις δύο διαστάσεις και θέσεις. Αυτό διατηρεί τις αναλογίες αλλά μπορεί να αφήσει αχρησιμοποίητο χώρο σε μια άκρη.