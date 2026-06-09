---
title: Πίνακας
type: docs
weight: 120
url: /el/python-net/examples/elements/table/
keywords:
- πίνακας
- προσθήκη πίνακα
- πρόσβαση πίνακα
- αφαίρεση πίνακα
- συγχώνευση κελιών
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε και μορφοποιήστε πίνακες σε Python με Aspose.Slides: εισαγάγετε δεδομένα, συγχωνεύστε κελιά, διαμορφώστε τα περιγράμματα, ευθυγραμμίστε το περιεχόμενο και κάντε εισαγωγή/εξαγωγή για PPT, PPTX και ODP."
---
Παραδείγματα για την προσθήκη πινάκων, την πρόσβαση σε αυτούς, την κατάργηση τους και τη συγχώνευση κελιών χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

## **Προσθήκη Πίνακα**

Δημιουργήστε έναν απλό πίνακα με δύο σειρές και δύο στήλες.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Ορισμός πλάτους στηλών και ύψους σειρών.
        widths = [80, 80]
        heights = [30, 30]

        # Προσθήκη σχήματος πίνακα στη διαφάνεια.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε Πίνακα**

Ανακτήστε το πρώτο σχήμα πίνακα στη διαφάνεια.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Πρόσβαση στον πρώτο πίνακα στη διαφάνεια.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Αφαίρεση Πίνακα**

Διαγράψτε έναν πίνακα από μια διαφάνεια.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτουμε ότι το πρώτο σχήμα είναι πίνακας.
        table = slide.shapes[0]

        # Αφαίρεση του πίνακα από τη διαφάνεια.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Συγχώνευση Κελιών Πίνακα**

Συγχωνεύστε τα διπλανά κελιά ενός πίνακα σε ένα ενιαίο κελί.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτουμε ότι το πρώτο σχήμα είναι πίνακας.
        table = slide.shapes[0]

        # Συγχώνευση κελιών.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```