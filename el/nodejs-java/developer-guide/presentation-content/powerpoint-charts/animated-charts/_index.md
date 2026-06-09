---
title: Κινούμενα διαγράμματα PowerPoint σε JavaScript
linktitle: Κινούμενα Διαγράμματα
type: docs
weight: 80
url: /el/nodejs-java/animated-charts/
keywords:
- διάγραμμα
- κινούμενο διάγραμμα
- κίνηση διαγράμματος
- σειρά διαγράμματος
- κατηγορία διαγράμματος
- στοιχείο σειράς
- στοιχείο κατηγορίας
- πρόσθεση εφέ
- τύπος εφέ
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε εκπληκτικά κινούμενα διαγράμματα σε JavaScript με το Aspose.Slides για Node.js. Αναβαθμίστε τις παρουσιάσεις με δυναμικά οπτικά στοιχεία σε αρχεία PPT και PPTX—ξεκινήστε τώρα."
---
## **Εισαγωγή**

Το Aspose.Slides for Node.js μέσω Java υποστηρίζει την κίνηση των στοιχείων του διαγράμματος. **Series**, **Categories**, **Series Elements**, **Categories Elements** μπορούν να εφέσουν κίνηση με τη μέθοδο [Sequence.addEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sequence/#addEffect) και με τα δύο enums [EffectChartMajorGroupingType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effectchartmajorgroupingtype/) και [EffectChartMinorGroupingType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effectchartminorgroupingtype/).

## **Κίνηση Σειράς Διαγράμματος**
Αν θέλετε να δημιουργήσετε κίνηση για μια σειρά διαγράμματος, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε αναφορά στο αντικείμενο του διαγράμματος.
1. Δημιουργήστε κίνηση στη σειρά.
1. Γράψτε το αρχείο παρουσίασης στον δίσκο.

Στο παρακάτω παράδειγμα, δημιουργήσαμε κίνηση στη σειρά του διαγράμματος.

```javascript
// Δημιουργία κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Απόκτηση αναφοράς στο αντικείμενο διαγράμματος
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Κίνηση της σειράς
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Αποθήκευση της τροποποιημένης παρουσίασης στο δίσκο
    pres.save("AnimatingSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Κίνηση Κατηγορίας Διαγράμματος**
Αν θέλετε να δημιουργήσετε κίνηση για μια κατηγορία διαγράμματος, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε αναφορά στο αντικείμενο του διαγράμματος.
1. Δημιουργήστε κίνηση στην Κατηγορία.
1. Γράψτε το αρχείο παρουσίασης στον δίσκο.

Στο παρακάτω παράδειγμα, δημιουργήσαμε κίνηση στην κατηγορία του διαγράμματος.

```javascript
// Δημιουργία κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    pres.save("Sample_Animation_C.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Κίνηση σε Στοιχείο Σειράς**
Αν θέλετε να δημιουργήσετε κίνηση σε στοιχεία σειράς, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε αναφορά στο αντικείμενο του διαγράμματος.
1. Δημιουργήστε κίνηση σε στοιχεία σειράς.
1. Γράψτε το αρχείο παρουσίασης στον δίσκο.

Στο παρακάτω παράδειγμα, δημιουργήσαμε κίνηση στα στοιχεία της σειράς.

```javascript
// Δημιουργία κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Απόκτηση αναφοράς στο αντικείμενο διαγράμματος
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Κίνηση στοιχείων σειράς
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Αποθήκευση του αρχείου παρουσίασης στο δίσκο
    pres.save("AnimatingSeriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Κίνηση σε Στοιχείο Κατηγορίας**
Αν θέλετε να δημιουργήσετε κίνηση σε στοιχεία κατηγοριών, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε αναφορά στο αντικείμενο του διαγράμματος.
1. Δημιουργήστε κίνηση σε στοιχεία κατηγοριών.
1. Γράψτε το αρχείο παρουσίασης στον δίσκο.

Στο παρακάτω παράδειγμα, δημιουργήσαμε κίνηση στα στοιχεία κατηγοριών.

```javascript
// Δημιουργία κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Απόκτηση αναφοράς στο αντικείμενο διαγράμματος
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Κίνηση των στοιχείων κατηγοριών
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Αποθήκευση του αρχείου παρουσίασης στο δίσκο
    pres.save("AnimatingCategoriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Υποστηρίζονται διαφορετικοί τύποι εφέ (π.χ., είσοδο, έμφαση, έξοδο) για τα διαγράμματα όπως και για κανονικά σχήματα;**

Ναι. Ένα διάγραμμα θεωρείται σχήμα, επομένως υποστηρίζει τους τυπικούς τύπους εφέ κίνησης, συμπεριλαμβανομένων της εισόδου, της έμφασης και της εξόδου, με πλήρη έλεγχο μέσω της χρονογραμμής της διαφάνειας και των ακολουθιών κίνησης.

**Μπορώ να συνδυάσω την κίνηση του διαγράμματος με τις μεταβάσεις διαφανειών;**

Ναι. Οι [Transitions](/slides/el/nodejs-java/slide-transition/) εφαρμόζονται στη διαφάνεια, ενώ τα εφέ κίνησης εφαρμόζονται στα αντικείμενα της διαφάνειας. Μπορείτε να χρησιμοποιήσετε και τα δύο μαζί στην ίδια παρουσίαση και να τα ελέγχετε ανεξάρτητα.

**Διατηρούνται οι κινήσεις του διαγράμματος όταν αποθηκεύεται σε PPTX;**

Ναι. Όταν [save to PPTX](/slides/el/nodejs-java/save-presentation/), όλα τα εφέ κίνησης και η σειρά τους διατηρούνται επειδή αποτελούν μέρος του εγγενή μοντέλου κίνησης της παρουσίασης.

**Μπορώ να διαβάσω υπάρχουσες κινήσεις διαγράμματος από μια παρουσίαση και να τις τροποποιήσω;**

Ναι. Το API παρέχει πρόσβαση στη χρονογραμμή της διαφάνειας, στις ακολουθίες και στα εφέ, επιτρέποντάς σας να εξετάσετε τις υπάρχουσες κινήσεις διαγράμματος και να τις προσαρμόσετε χωρίς να χρειάζεται να δημιουργήσετε ξανά τα πάντα από την αρχή.

**Μπορώ να δημιουργήσω ένα βίντεο που περιλαμβάνει κινήσεις διαγράμματος χρησιμοποιώντας το Aspose.Slides;**

Ναι. Μπορείτε να [export a presentation to video](/slides/el/nodejs-java/convert-powerpoint-to-video/) διατηρώντας τις κινήσεις, ρυθμίζοντας τα χρονικά διαστήματα και άλλες ρυθμίσεις εξαγωγής ώστε το αποτέλεσμα να αντικατοπτρίζει την κίνηση της παρουσίασης.