---
title: Κινούμενα Διαγράμματα PowerPoint σε .NET
linktitle: Κινούμενα Διαγράμματα
type: docs
weight: 80
url: /el/net/animated-charts/
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
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε εντυπωσιακά κινούμενα διαγράμματα σε .NET με το Aspose.Slides. Ενισχύστε τις παρουσιάσεις με δυναμικά οπτικά στοιχεία σε αρχεία PPT και PPTX — ξεκινήστε τώρα."
---
## **Εισαγωγή**

Aspose.Slides for .NET υποστηρίζει την κίνηση των στοιχείων του γραφήματος. **Series**, **Categories**, **Series Elements**, **Categories Elements** μπορούν να κινούνται με τη μέθοδο [ISequence.AddEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/methods/addeffect) και με τους δύο απαρχματιστές [EffectChartMajorGroupingType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effectchartmajorgroupingtype) και [EffectChartMinorGroupingType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effectchartminorgroupingtype).

## **Κίνηση Σειράς Γραφήματος**
Αν θέλετε να κινήσετε μια σειρά γραφήματος, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Λάβετε την αναφορά του αντικειμένου γραφήματος.
1. Κινήστε τη σειρά.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, κινήσαμε σειρά γραφήματος.

```c#
 // Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης 
 using (Presentation presentation = new Presentation("ExistingChart.pptx"))
 {
     // Λάβετε την αναφορά του αντικειμένου γραφήματος
     var slide = presentation.Slides[0] as Slide;
     var shapes = slide.Shapes as ShapeCollection;
     var chart = shapes[0] as IChart;

     // Κινηστε τη σειρά
     slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
     EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 0,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 1,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 2,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 3,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     // Γράψτε την τροποποιημένη παρουσίαση στο δίσκο 
     presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
 }
```

## **Κίνηση Κατηγορίας Γραφήματος**
Αν θέλετε να κινήσετε μια κατηγορία γραφήματος, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Λάβετε την αναφορά του αντικειμένου γραφήματος.
1. Κινήστε την Κατηγορία.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, κινήσαμε κατηγορία γραφήματος.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Λάβετε την αναφορά του αντικειμένου γραφήματος
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Κινηστε τα στοιχεία των κατηγοριών
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Γράψτε το αρχείο παρουσίασης στο δίσκο
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **Κίνηση Στοιχείου Σειράς**
Αν θέλετε να κινήσετε στοιχεία σειρών, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Λάβετε την αναφορά του αντικειμένου γραφήματος.
1. Κινήστε στοιχεία σειρών.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, κινήσαμε τα στοιχεία της σειράς.

```c#
 // Φορτώστε μια παρουσίαση
 using (Presentation presentation = new Presentation("ExistingChart.pptx"))
 {
     // Λάβετε την αναφορά του αντικειμένου γραφήματος
     var slide = presentation.Slides[0] as Slide;
     var shapes = slide.Shapes as ShapeCollection;
     var chart = shapes[0] as IChart;

     // Κινηστε στοιχεία σειράς
     slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     // Γράψτε το αρχείο παρουσίασης στο δίσκο 
     presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
```

## **Κίνηση Στοιχείου Κατηγορίας**
Αν θέλετε να κινήσετε στοιχεία κατηγοριών, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Λάβετε την αναφορά του αντικειμένου γραφήματος.
1. Κινήστε στοιχεία κατηγοριών.
1. Γράψτε το αρχείο παρουσίασης στο δίσκο.

Στο παρακάτω παράδειγμα, κινήσαμε τα στοιχεία των κατηγοριών.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Λάβετε την αναφορά του αντικειμένου γραφήματος
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Κινηστε τα στοιχεία των κατηγοριών
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Γράψτε το αρχείο παρουσίασης στο δίσκο
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζονται διαφορετικοί τύποι εφέ (π.χ., είσοδος, έμφαση, έξοδος) για γραφήματα όπως για κανονικά σχήματα;**

Ναι. Ένα γράφημα θεωρείται σχήμα, οπότε υποστηρίζει τους τυπικούς τύπους εφέ κίνησης, συμπεριλαμβανομένων της εισόδου, της έμφασης και της εξόδου, με πλήρη έλεγχο μέσω της χρονογραμμής της διαφάνειας και των ακολουθιών κίνησης.

**Μπορώ να συνδυάσω την κίνηση γραφήματος με μεταβάσεις διαφάνειας;**

Ναι. [Μεταβάσεις](/slides/el/net/slide-transition/) εφαρμόζονται στη διαφάνεια, ενώ τα εφέ κίνησης εφαρμόζονται στα αντικείμενα της διαφάνειας. Μπορείτε να τα χρησιμοποιήσετε και τα δύο μαζί στην ίδια παρουσίαση και να τα ελέγχετε ανεξάρτητα.

**Διατηρούνται οι κινήσεις γραφήματος κατά την αποθήκευση σε PPTX;**

Ναι. Όταν [αποθηκεύετε σε PPTX](/slides/el/net/save-presentation/), όλα τα εφέ κίνησης και η σειρά τους διατηρούνται επειδή αποτελούν μέρος του εγγενή μοντέλου κίνησης της παρουσίασης.

**Μπορώ να διαβάσω υπάρχουσες κινήσεις γραφήματος από μια παρουσίαση και να τις τροποποιήσω;**

Ναι. Το [API](https://reference.aspose.com/slides/el/net/aspose.slides.animation/) παρέχει πρόσβαση στη χρονογραμμή της διαφάνειας, στις ακολουθίες και στα εφέ, επιτρέποντάς σας να εξετάσετε υπάρχουσες κινήσεις γραφήματος και να τις προσαρμόσετε χωρίς να ξαναδημιουργήσετε τα πάντα από μηδέν.

**Μπορώ να δημιουργήσω βίντεο που περιλαμβάνει κινήσεις γραφήματος χρησιμοποιώντας το Aspose.Slides;**

Ναι. Μπορείτε να [εξαγάγετε παρουσίαση σε βίντεο](/slides/el/net/convert-powerpoint-to-video/) διατηρώντας τις κινήσεις, ρυθμίζοντας χρονισμούς και άλλες ρυθμίσεις εξαγωγής ώστε το τελικό κλιπ να αντανακλά την κίνηση.