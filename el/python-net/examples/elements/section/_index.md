---
title: Ενότητα
type: docs
weight: 90
url: /el/python-net/examples/elements/section/
keywords:
- ενότητα
- ενότητα διαφάνειας
- προσθήκη ενότητας
- πρόσβαση ενότητας
- αφαίρεση ενότητας
- μετονομασία ενότητας
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε τις ενότητες διαφάνειας σε Python με Aspose.Slides: δημιουργία, μετονομασία, εύκολη αναδιάταξη, μετακίνηση διαφανειών μεταξύ ενοτήτων και έλεγχο ορατότητας για PPT, PPTX και ODP."
---
Παραδείγματα για τη διαχείριση των ενοτήτων παρουσίασης—προσθήκη, πρόσβαση, αφαίρεση και μετονομασία τους προγραμματιστικά χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

## **Προσθήκη Ενότητας**

Δημιουργήστε μια ενότητα που αρχίζει σε μια συγκεκριμένη διαφάνεια.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Προσθέστε μια νέα ενότητα και καθορίστε τη διαφάνεια που σηματοδοτεί την αρχή της ενότητας.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε μια ενότητα**

Αποκτήστε μια ενότητα από μια παρουσίαση.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Πρόσβαση σε ενότητα με βάση το δείκτη.
        section = presentation.sections[0]
```

## **Αφαίρεση Ενότητας**

Διαγράψτε μια προηγουμένως προστιθέμενη ενότητα.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Αφαίρεση της ενότητας.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Μετονομασία Ενότητας**

Αλλάξτε το όνομα μιας υπάρχουσας ενότητας.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Μετονομασία της ενότητας.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```