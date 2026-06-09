---
title: Διαφάνεια Διάταξης
type: docs
weight: 20
url: /el/python-net/examples/elements/layout-slide/
keywords:
- διαφάνεια διάταξης
- προσθήκη διαφάνειας διάταξης
- πρόσβαση σε διαφάνεια διάταξης
- αφαίρεση διαφάνειας διάταξης
- αχρησιμοποίητη διαφάνεια διάταξης
- κλωνοποίηση διαφάνειας διάταξης
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Χρησιμοποιήστε την Python για να διαχειριστείτε τις διαφάνειες διάταξης με το Aspose.Slides: δημιουργία, εφαρμογή, κλωνοποίηση, μετονομασία και προσαρμογή των δεσμευτικών θέσεων και θεμάτων σε παρουσιάσεις για PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να εργάζεστε με **Διαφάνειες Διάταξης** στο Aspose.Slides for Python μέσω .NET. Μια διαφάνεια διάταξης ορίζει το σχεδιασμό και τη μορφοποίηση που κληρονομείται από τις κανονικές διαφάνειες. Μπορείτε να προσθέσετε, να προσπελάσετε, να κλωνοποιήσετε και να αφαιρέσετε διαφάνειες διάταξης, καθώς και να καθαρίσετε τις αχρησιμοποίητες για να μειώσετε το μέγεθος της παρουσίασης.

## **Προσθήκη Διαφάνειας Διάταξης**

Μπορείτε να δημιουργήσετε μια προσαρμοσμένη διαφάνεια διάταξης για να ορίσετε επαναχρησιμοποιήσιμη μορφοποίηση.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # Δημιουργήστε μια διαφάνεια διάταξης με τον καθορισμένο τύπο και όνομα.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** Οι διαφάνειες διάταξης λειτουργούν ως πρότυπα για μεμονωμένες διαφάνειες. Μπορείτε να ορίσετε κοινά στοιχεία μία φορά και να τα επαναχρησιμοποιήσετε σε πολλές διαφάνειες.

> 💡 **Tip 2:** Όταν προσθέτετε σχήματα ή κείμενο σε μια διαφάνεια διάταξης, όλες οι διαφάνειες που βασίζονται σε αυτή τη διάταξη θα εμφανίσουν αυτό το κοινό περιεχόμενο αυτόματα.
> Το στιγμιότυπο οθόνης παρακάτω δείχνει δύο διαφάνειες, η καθεμία από τις οποίες κληρονομεί ένα πλαίσιο κειμένου από την ίδια διαφάνεια διάταξης.

![Διαφάνειες που κληρονομούν περιεχόμενο διάταξης](layout-slide-result.png)


## **Πρόσβαση σε Διαφάνεια Διάταξης**

Οι διαφάνειες διάταξης μπορούν να προσπελαστούν κατά δείκτη ή κατά τύπο διάταξης (π.χ., `Blank`, `Title`, `SectionHeader`, κ.λπ.).

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Πρόσβαση με δείκτη.
        first_layout_slide = presentation.layout_slides[0]

        # Πρόσβαση με τύπο διάταξης.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **Αφαίρεση Διαφάνειας Διάταξης**

Μπορείτε να αφαιρέσετε μια συγκεκριμένη διαφάνεια διάταξης εφόσον δεν χρειάζεται πλέον.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Λάβετε μια διαφάνεια διάταξης κατά τύπο και αφαιρέστε την.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Αφαίρεση Μη Χρησμένων Διαφανειών Διάταξης**

Για να μειώσετε το μέγεθος της παρουσίασης, ίσως θελήσετε να αφαιρέσετε διαφάνειες διάταξης που δεν χρησιμοποιούνται από καμία κανονική διαφάνεια.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Αφαιρεί αυτόματα όλες τις διαφάνειες διάταξης που δεν αναφέρονται από καμία διαφάνεια.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση Διαφάνειας Διάταξης**

Μπορείτε να αντιγράψετε μια διαφάνεια διάταξης χρησιμοποιώντας τη μέθοδο `AddClone`.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Λάβετε μια υπάρχουσα διαφάνεια διάταξης κατά τύπο.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Κλωνοποιήστε τη διαφάνεια διάταξης στο τέλος της συλλογής διαφανειών διάταξης.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Summary:** Οι διαφάνειες διάταξης είναι ισχυρά εργαλεία για τη διαχείριση συνεπούς μορφοποίησης σε όλες τις διαφάνειες. Το Aspose.Slides παρέχει πλήρη έλεγχο στη δημιουργία, τη διαχείριση και τη βελτιστοποίηση διαφανειών διάταξης.