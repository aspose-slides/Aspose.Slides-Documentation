---
title: Αλλαγή Μεγέθους Σχημάτων σε Διαφάνειες Παρουσίασης με Python
type: docs
weight: 130
url: /el/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/re-sizing-shapes-on-slide/
  - /el/python-net/re-sizing-shapes-on-slide/
keywords:
  - αλλαγή μεγέθους σχήματος
  - αλλαγή μεγέθους σχήματος
  - PowerPoint
  - OpenDocument
  - παρουσίαση
  - Python
  - Aspose.Slides
description: "Απλώς αλλάξτε το μέγεθος των σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω .NET—αυτοματοποιήστε τις ρυθμίσεις διάταξης των διαφανειών και ενισχύστε την παραγωγικότητα."
---
## **Επισκόπηση**

Όταν αλλάζετε το μέγεθος διαφάνειας μιας παρουσίασης, ίσως χρειαστεί επίσης να αλλάξετε το μέγεθος και τη θέση των σχημάτων της ώστε να ταιριάζουν στις νέες διαστάσεις. Αυτό το άρθρο δείχνει πώς να κλιμακώνετε τα σχήματα χειροκίνητα και πώς να διαχειρίζεστε πίνακες σε διαφάνειες, κύριες διαφάνειες και διατάξεις.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να διατηρήσετε τη σχετική θέση και το μέγεθος κάθε σχήματος, πολλαπλασιάστε τις οριζόντιες συντεταγμένες και το πλάτος του με το λόγο του νέου πλάτους διαφάνειας προς το αρχικό πλάτος. Εφαρμόστε το αντίστοιχο λόγο ύψους στις κατακόρυφες συντεταγμένες και το ύψος του.

Το πρώτο παράδειγμα φορτώνει μια παρουσίαση της οποίας οι διαφάνειες δεν περιέχουν πίνακες, αλλάζει το μέγεθος της διαφάνειας σε A4 και αποθηκεύει το αποτέλεσμα. Χρησιμοποιεί [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) με [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) ώστε η επόμενη λούπα να ελέγχει την κλιμάκωση. Οι λόγοι είναι χωρίς μονάδα· οι θέσεις και οι διαστάσεις των σχημάτων μετρώνται σε points. Διαφορετικοί λόγοι πλάτους και ύψους μπορούν να παραμορφώσουν τα σχήματα, και η αλλαγή των διαστάσεων ενός σχήματος δεν κλιμακώνει τα μεγέθη γραμματοσειράς.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Υπολογίστε ανεξάρτητους οριζόντιους και κάθετους συντελεστές κλίμακας.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Οι πίνακες απαιτούν ξεχωριστή διαχείριση: κλιμακώστε το πλάτος των στηλών τους και το ύψος των γραμμών αντί να ορίσετε το συνολικό πλάτος και ύψος του πίνακα. Το ύψος των γραμμών μπορεί να παραμείνει μεγαλύτερο από το ζητούμενο εάν το περιεχόμενο των κελιών απαιτεί περισσότερο χώρο.
{{% /alert %}}

Το δεύτερο παράδειγμα υποστηρίζει πίνακες και επεξεργάζεται σχήματα σε κύριες διαφάνειες και διατάξεις καθώς και σε μεμονωμένες διαφάνειες πριν αποθηκεύσει την αλλαγμένη παρουσίαση. Ο βοηθός του διαχειρίζεται κάθε [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) κλιμακώντας το [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) και το [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/). Στη συνέχεια κλιμακώνει τη θέση του πίνακα χωρίς να κλιμακώνει ξεχωριστά τις συνολικές του διαστάσεις.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Οι διαστάσεις του πίνακα ελέγχονται από το πλάτος των στηλών και το ύψος των γραμμών.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # Υπολογίστε ανεξάρτητους οριζόντιους και κάθετους συντελεστές κλίμακας.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Αλλαγή μεγέθους σχημάτων που ορίζονται σε κύριες διαφάνειες και διατάξεις, καθώς και σε μεμονωμένες διαφάνειες.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Γιατί τα σχήματα παραμορφώνονται ή κόβονται μετά την αλλαγή μεγέθους μιας διαφάνειας;**

Εάν αλλάξετε το μέγεθος της διαφάνειας χωρίς να κλιμακώσετε τα σχήματα, θα διατηρήσουν τις αρχικές τους θέσεις και διαστάσεις και μπορεί να εκτείνονται πέρα από τη διαφάνεια. Η κλιμάκωση του πλάτους και του ύψους με διαφορετικούς λόγους μπορεί επίσης να παραμορφώσει τα σχήματα.

**Λειτουργεί ο παρατιθέμενος κώδικας για όλους τους τύπους σχημάτων;**

Το πρώτο παράδειγμα αλλάζει απευθείας τα όρια του σχήματος και προορίζεται για διαφάνειες χωρίς πίνακες. Το δεύτερο παράδειγμα διαχειρίζεται τους πίνακες ξεχωριστά. Ελέγξτε τη διαρραφή που προκύπτει, ιδιαίτερα το κείμενο και τους πίνακες, επειδή αυτά τα παραδείγματα δεν κλιμακώνουν τα μεγέθη γραμματοσειράς και το περιεχόμενο των πινάκων μπορεί να περιορίσει το ύψος των γραμμών.

**Πώς μπορώ να αλλάξω το μέγεθος των πινάκων όταν αλλάζω το μέγεθος μιας διαφάνειας;**

Κλιμακώστε το πλάτος των στηλών με τον λόγο πλάτους και το ελάχιστο ύψος των γραμμών με τον λόγο ύψους, στη συνέχεια κλιμακώστε τη θέση του πίνακα, όπως φαίνεται στο δεύτερο παράδειγμα.

**Θα λειτουργήσει αυτή η αλλαγή μεγέθους για κύριες διαφάνειες και διατάξεις διαφανειών;**

Ναι. Το δεύτερο παράδειγμα διατρέχει τα [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) και κάθε [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) του κυρίου και εφαρμόζει την ίδια λογική αλλαγής μεγέθους στα σχήματά τους.

**Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (κατακόρυφα/οριζόντια) μαζί με την αλλαγή μεγέθους;**

Ναι. Ορίστε το [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) μετά την αλλαγή του μεγέθους της διαφάνειας και πριν την ανάγνωση των στοχευμένων διαστάσεων, ώστε οι συντελεστές κλίμακας να αντανακλούν τον τελικό προσανατολισμό.

**Υπάρχει όριο στο μέγεθος διαφάνειας που μπορώ να ορίσω;**

Μπορείτε να ορίσετε προσαρμοσμένες διαστάσεις διαφάνειας με το [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). Οι υποστηριζόμενες διαστάσεις εξαρτώνται επίσης από τη μορφή της παρουσίασης και την εφαρμογή που χρησιμοποιείται για το άνοιγμα του αρχείου.

**Πώς μπορώ να αποτρέψω τα σχήματα με σταθερή αναλογία διαστάσεων να παραμορφώνονται;**

Χρησιμοποιήστε τον ίδιο συντελεστή κλίμακας για το πλάτος και το ύψος. Για να προσαρμόσετε την αρχική διάταξη μέσα στις νέες διαστάσεις της διαφάνειας, χρησιμοποιήστε το μικρότερο από τους λόγους πλάτους και ύψους και για τις δύο διαστάσεις και θέσεις. Αυτό διατηρεί τις αναλογίες, αλλά μπορεί να αφήσει αχρησιμοποίητο χώρο κατά μήκος μιας άκρης.