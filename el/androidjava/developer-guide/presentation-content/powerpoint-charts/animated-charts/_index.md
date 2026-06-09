---
title: Κινούμενα Διαγράμματα PowerPoint σε Android
linktitle: Κινούμενα Διαγράμματα
type: docs
weight: 80
url: /el/androidjava/animated-charts/
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
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε εντυπωσιακά κινούμενα διαγράμματα σε Java με το Aspose.Slides για Android. Αναβαθμίστε τις παρουσιάσεις με δυναμικές απεικονίσεις σε αρχεία PPT και PPTX—ξεκινήστε τώρα."
---
## **Εισαγωγή**

Το Aspose.Slides for Android μέσω Java υποστηρίζει την κίνηση των στοιχείων του διαγράμματος. **Series**, **Categories**, **Series Elements**, **Categories Elements** μπορούν να κινούνται με τη μέθοδο [ISequence.addEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) και με δύο απαριθμήσεις [EffectChartMajorGroupingType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/EffectChartMajorGroupingType) και [EffectChartMinorGroupingType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/EffectChartMinorGroupingType).

## **Κίνηση Σειράς Διαγράμματος**
Αν θέλετε να κινούμε μια σειρά διαγράμματος, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Λάβετε αναφορά στο αντικείμενο διαγράμματος.
1. Κινητοποίηση της σειράς.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, κινήσαμε τη σειρά διαγράμματος.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο παρουσίασης
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Λήψη αναφοράς στο αντικείμενο διαγράμματος
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Κίνηση της σειράς
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

    // Αποθήκευση της τροποποιημένης παρουσίασης στο δίσκο
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Κίνηση Κατηγορίας Διαγράμματος**
Αν θέλετε να κινηθεί μια κατηγορία διαγράμματος, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Λάβετε αναφορά στο αντικείμενο διαγράμματος.
1. Κινητοποίηση της κατηγορίας.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, κινήσαμε την κατηγορία διαγράμματος.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο παρουσίασης
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

## **Κίνηση σε Στοιχείο Σειράς**
Αν θέλετε να κινήσετε στοιχεία σειράς, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Λάβετε αναφορά στο αντικείμενο διαγράμματος.
1. Κινητοποίηση στοιχείων σειράς.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, έχουμε κινήσει τα στοιχεία της σειράς.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο παρουσίασης
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Λήψη αναφοράς στο αντικείμενο διαγράμματος
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Κινητοποίηση στοιχείων σειράς
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

    // Αποθήκευση του αρχείου παρουσίασης στο δίσκο
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Κίνηση σε Στοιχείο Κατηγορίας**
Αν θέλετε να κινήσετε στοιχεία κατηγοριών, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Λάβετε αναφορά στο αντικείμενο διαγράμματος.
1. Κινητοποίηση στοιχείων κατηγοριών.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, έχουμε κινήσει στοιχεία κατηγοριών.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο παρουσίασης
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Λήψη αναφοράς του αντικειμένου διαγράμματος
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Κινητοποίηση στοιχείων κατηγοριών
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

    // Αποθήκευση του αρχείου παρουσίασης στο δίσκο
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Are different effect types (e.g., entrance, emphasis, exit) supported for charts like for regular shapes?**

Ναι. Ένα διάγραμμα αντιμετωπίζεται ως σχήμα, επομένως υποστηρίζει τους τυπικούς τύπους εφέ κίνησης, συμπεριλαμβανομένων της εισόδου, της έμφασης και της εξόδου, με πλήρη έλεγχο μέσω του χρονοδιαγράμματος της διαφάνειας και των ακολουθιών κίνησης.

**Can I combine chart animation with slide transitions?**

Ναι. [Transitions](/slides/el/androidjava/slide-transition/) εφαρμόζονται στη διαφάνεια, ενώ τα εφέ κίνησης εφαρμόζονται στα αντικείμενα της διαφάνειας. Μπορείτε να τα χρησιμοποιήσετε και τα δύο μαζί στην ίδια παρουσίαση και να τα ελέγχετε ανεξάρτητα.

**Are chart animations preserved when saving to PPTX?**

Ναι. Όταν [save to PPTX](/slides/el/androidjava/save-presentation/), όλα τα εφέ κίνησης και η σειρά τους διατηρούνται επειδή αποτελούν μέρος του εγγενούς μοντέλου κίνησης της παρουσίασης.

**Can I read existing chart animations from a presentation and modify them?**

Ναι. Το API παρέχει πρόσβαση στο χρονοδιάγραμμα της διαφάνειας, στις ακολουθίες και στα εφέ, επιτρέποντάς σας να εξετάσετε τις υπάρχουσες κινήσεις διαγράμματος και να τις προσαρμόσετε χωρίς να ξαναδημιουργήσετε τα πάντα από την αρχή.

**Can I produce a video that includes chart animations using Aspose.Slides?**

Ναι. Μπορείτε να [export a presentation to video](/slides/el/androidjava/convert-powerpoint-to-video/) διατηρώντας τις κινήσεις, ρυθμίζοντας τα χρονικά διαστήματα και άλλες ρυθμίσεις εξαγωγής ώστε το προκύπτον βίντεο να αντικατοπτρίζει την animated playback.