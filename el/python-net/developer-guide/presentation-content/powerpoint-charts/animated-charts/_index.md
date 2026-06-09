---
title: Κινούμενα Διαγράμματα PowerPoint με Python
linktitle: Κινούμενα Διαγράμματα
type: docs
weight: 80
url: /el/python-net/animated-charts/
keywords:
- διάγραμμα
- κινούμενο διάγραμμα
- κίνηση διαγράμματος
- σειρά διαγράμματος
- κατηγορία διαγράμματος
- στοιχείο σειράς
- στοιχείο κατηγορίας
- προσθήκη εφέ
- τύπος εφέ
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε εντυπωσιακά κινούμενα διαγράμματα σε Python με το Aspose.Slides. Ενισχύστε τις παρουσιάσεις με δυναμικά οπτικά στοιχεία σε αρχεία PPT, PPTX και ODP — ξεκινήστε τώρα."
---
## **Εισαγωγή**

Το Aspose.Slides for Python via .NET υποστηρίζει την κίνηση των στοιχείων του διαγράμματος. **Series**, **Categories**, **Series Elements**, **Categories Elements** μπορούν να κινηθούν με τη μέθοδο [ISequence.add_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/isequence/) και δύο καταχωρίσεις [EffectChartMajorGroupingType](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effectchartmajorgroupingtype/) και [EffectChartMinorGroupingType](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effectchartminorgroupingtype/).

## **Κίνηση Σειράς Διαγράμματος**
Αν θέλετε να κινήσετε μια σειρά διαγράμματος, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Λάβετε αναφορά στο αντικείμενο διαγράμματος.
1. Κινήστε τη σειρά.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, κινήσαμε τη σειρά του διαγράμματος.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Δημιουργία κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης 
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Λήψη αναφοράς στο αντικείμενο διαγράμματος
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Κίνηση της σειράς
    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectType.FADE, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectChartMajorGroupingType.BY_SERIES, 0, 
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 1,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 2,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 3,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Αποθήκευση της τροποποιημένης παρουσίασης στον δίσκο 
    presentation.save("AnimatingSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κίνηση Κατηγορίας Διαγράμματος**
Αν θέλετε να κινήσετε μια κατηγορία διαγράμματος, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Λάβετε αναφορά στο αντικείμενο διαγράμματος.
1. Κινήστε την Κατηγορία.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, κινήσαμε την κατηγορία του διαγράμματος.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Λάβετε αναφορά στο αντικείμενο διαγράμματος
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Κίνηση των στοιχείων των κατηγοριών
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Αποθήκευση του αρχείου παρουσίασης στον δίσκο
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κίνηση σε Στοιχείο Σειράς**
Αν θέλετε να κινήσετε στοιχεία σειράς, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Λάβετε αναφορά στο αντικείμενο διαγράμματος.
1. Κινήστε στοιχεία σειράς.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, έχουμε κινηθεί τα στοιχεία της σειράς.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Φορτώστε μια παρουσίαση
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Λάβετε αναφορά στο αντικείμενο διαγράμματος
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Κίνηση των στοιχείων σειράς
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Αποθήκευση του αρχείου παρουσίασης στον δίσκο 
    presentation.save("AnimatingSeriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κίνηση σε Στοιχείο Κατηγορίας**
Αν θέλετε να κινήσετε στοιχεία κατηγοριών, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Λάβετε αναφορά στο αντικείμενο διαγράμματος.
1. Κινήστε στοιχεία κατηγοριών.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, έχουμε κινηθεί τα στοιχεία των κατηγοριών.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Λάβετε αναφορά στο αντικείμενο διαγράμματος
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Κίνηση των στοιχείων των κατηγοριών
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Αποθήκευση του αρχείου παρουσίασης στον δίσκο
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Υποστηρίζονται διαφορετικοί τύποι εφέ (π.χ., εισαγωγή, έμφαση, έξοδος) για διαγράμματα όπως και για κανονικά σχήματα;**

Ναι. Ένα διάγραμμα θεωρείται σχήμα, επομένως υποστηρίζει τους τυπικούς τύπους εφέ κίνησης, συμπεριλαμβανομένων των εισαγωγικών, έμφασης και εξόδου, με πλήρη έλεγχο μέσω της χρονογραμμή της διαφάνειας και των ακολουθιών κίνησης.

**Μπορώ να συνδυάσω την κίνηση του διαγράμματος με τις μεταβάσεις διαφάνειας;**

Ναι. Οι [Transitions](/slides/el/python-net/slide-transition/) εφαρμόζονται στη διαφάνεια, ενώ τα εφέ κίνησης εφαρμόζονται στα αντικείμενα της διαφάνειας. Μπορείτε να χρησιμοποιήσετε και τα δύο μαζί στην ίδια παρουσίαση και να τα ελέγχετε ανεξάρτητα.

**Διατηρούνται οι κινήσεις των διαγραμμάτων κατά την αποθήκευση σε PPTX;**

Ναι. Όταν [αποθηκεύετε σε PPTX](/slides/el/python-net/save-presentation/), όλα τα εφέ κίνησης και η σειρά τους διατηρούνται επειδή αποτελούν μέρος του εγγενή μοντέλου κίνησης της παρουσίασης.

**Μπορώ να διαβάσω υπάρχουσες κινήσεις διαγράμματος από μια παρουσίαση και να τις τροποποιήσω;**

Ναι. Το [API](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/) παρέχει πρόσβαση στη χρονογραμμή της διαφάνειας, στις ακολουθίες και στα εφέ, επιτρέποντάς σας να εξετάσετε τις υπάρχουσες κινήσεις διαγράμματος και να τις προσαρμόσετε χωρίς να ξαναδημιουργήσετε τα πάντα από την αρχή.

**Μπορώ να δημιουργήσω βίντεο που περιλαμβάνει κινήσεις διαγράμματος χρησιμοποιώντας το Aspose.Slides for Python via .NET;**

Ναι. Μπορείτε να [εξάγετε μια παρουσίαση σε βίντεο](/slides/el/python-net/convert-powerpoint-to-video/) διατηρώντας τις κινήσεις, ρυθμίζοντας τους χρόνους και άλλες ρυθμίσεις εξαγωγής ώστε το τελικό κλιπ να αντανακλά την κινούμενη αναπαραγωγή.