---
title: Κινούμενα Διαγράμματα PowerPoint σε Java
linktitle: Κινούμενα Διαγράμματα
type: docs
weight: 80
url: /el/java/animated-charts/
keywords:
- διάγραμμα
- κινούμενο διάγραμμα
- animation διαγράμματος
- σειρά διαγράμματος
- κατηγορία διαγράμματος
- στοιχείο σειράς
- στοιχείο κατηγορίας
- προσθήκη εφέ
- τύπος εφέ
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε εκπληκτικά κινούμενα διαγράμματα σε Java με το Aspose.Slides. Ενισχύστε τις παρουσιάσεις σας με δυναμικά οπτικά στοιχεία σε αρχεία PPT και PPTX—ξεκινήστε τώρα."
---
## **Εισαγωγή**

Το Aspose.Slides for Java υποστηρίζει την animation των στοιχείων του διαγράμματος. **Series**, **Categories**, **Series Elements**, **Categories Elements** μπορούν να αναπαραχθούν με τη μέθοδο [ISequence.addEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) και δύο απαριθμήσεις [EffectChartMajorGroupingType](https://reference.aspose.com/slides/el/java/com.aspose.slides/EffectChartMajorGroupingType) και [EffectChartMinorGroupingType](https://reference.aspose.com/slides/el/java/com.aspose.slides/EffectChartMinorGroupingType).

## **Animation Σειρών Διαγράμματος**
Αν θέλετε να δημιουργήσετε animation για μια σειρά διαγράμματος, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε αναφορά στο αντικείμενο του διαγράμματος.
1. Δημιουργήστε animation για τη σειρά.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, δημιουργήσαμε animation για σειρά διαγράμματος.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Λάβετε αναφορά στο αντικείμενο του διαγράμματος
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Δημιουργήστε animation στη σειρά
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Γράψτε την τροποποιημένη παρουσίαση στο δίσκο
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animation Κατηγορίας Διαγράμματος**
Αν θέλετε να δημιουργήσετε animation για μια κατηγορία διαγράμματος, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε αναφορά στο αντικείμενο του διαγράμματος.
1. Δημιουργήστε animation για την Κατηγορία.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, δημιουργήσαμε animation για την κατηγορία του διαγράμματος.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animation σε Στοιχείο Σειράς**
Αν θέλετε να δημιουργήσετε animation για στοιχεία σειράς, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε αναφορά στο αντικείμενο του διαγράμματος.
1. Δημιουργήστε animation για στοιχεία σειράς.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, δημιουργήσαμε animation για τα στοιχεία της σειράς.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Λάβετε αναφορά στο αντικείμενο του διαγράμματος
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Δημιουργία animation στα στοιχεία της σειράς
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Γράψτε το αρχείο παρουσίασης στο δίσκο 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animation σε Στοιχείο Κατηγορίας**
Αν θέλετε να δημιουργήσετε animation για στοιχεία κατηγορίας, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε αναφορά στο αντικείμενο του διαγράμματος.
1. Δημιουργήστε animation για στοιχεία κατηγορίας.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, δημιουργήσαμε animation για τα στοιχεία των κατηγοριών.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Λάβετε αναφορά στο αντικείμενο του διαγράμματος
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Δημιουργία animation των στοιχείων των κατηγοριών
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Γράψτε το αρχείο παρουσίασης στο δίσκο
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζονται διαφορετικοί τύποι εφέ (π.χ., είσοδος, έμφαση, έξοδος) για τα διαγράμματα όπως για τα συνηθισμένα σχήματα;**

Ναι. Ένα διάγραμμα θεωρείται σχήμα, επομένως υποστηρίζει τους τυπικούς τύπους animation εφέ, συμπεριλαμβανομένης της εισόδου, της έμφασης και της εξόδου, με πλήρη έλεγχο μέσω του χρονικού άξονα της διαφάνειας και των ακολουθιών animation.

**Μπορώ να συνδυάσω animation διαγράμματος με μεταβάσεις διαφάνειας;**

Ναι. Τα [Transitions](/slides/el/java/slide-transition/) εφαρμόζονται στη διαφάνεια, ενώ τα εφέ animation εφαρμόζονται στα αντικείμενα της διαφάνειας. Μπορείτε να χρησιμοποιήσετε και τα δύο μαζί στην ίδια παρουσίαση και να τα ελέγχετε ανεξάρτητα.

**Διατηρούνται τα animation του διαγράμματος κατά την αποθήκευση σε PPTX;**

Ναι. Όταν [αποθηκεύετε σε PPTX](/slides/el/java/save-presentation/), όλα τα εφέ animation και η σειρά τους διατηρούνται επειδή αποτελούν μέρος του εγγενούς μοντέλου animation της παρουσίασης.

**Μπορώ να διαβάσω υπάρχοντα animation διαγράμματος από μια παρουσίαση και να τα τροποποιήσω;**

Ναι. Το API παρέχει πρόσβαση στον χρονικό άξονα της διαφάνειας, στις ακολουθίες και στα εφέ, επιτρέποντάς σας να εξετάσετε τα υπάρχοντα animation διαγράμματος και να τα προσαρμόσετε χωρίς να δημιουργήσετε ξανά τα πάντα από την αρχή.

**Μπορώ να δημιουργήσω βίντεο που περιλαμβάνει animation διαγράμματος χρησιμοποιώντας το Aspose.Slides;**

Ναι. Μπορείτε να [εξάγετε μια παρουσίαση σε βίντεο](/slides/el/java/convert-powerpoint-to-video/) διατηρώντας τα animation, ρυθμίζοντας τα χρονικά πλαίσια και άλλες ρυθμίσεις εξαγωγής ώστε το τελικό κλιπ να αντικατοπτρίζει την animation αναπαραγωγή.