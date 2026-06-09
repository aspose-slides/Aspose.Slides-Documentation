---
title: Δημιουργία κινούμενων γραφημάτων PowerPoint σε PHP
linktitle: Κινούμενα Γραφήματα
type: docs
weight: 80
url: /el/php-java/animated-charts/
keywords:
- γράφημα
- κινούμενο γράφημα
- κίνηση γραφήματος
- σειρά γραφήματος
- κατηγορία γραφήματος
- στοιχείο σειράς
- στοιχείο κατηγορίας
- προσθήκη εφέ
- τύπος εφέ
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε εντυπωσιακά κινούμενα γραφήματα με το Aspose.Slides για PHP μέσω Java. Ενισχύστε τις παρουσιάσεις με δυναμικά οπτικά στοιχεία σε αρχεία PPT και PPTX — ξεκινήστε τώρα."
---
## **Εισαγωγή**

Το Aspose.Slides για PHP μέσω Java υποστηρίζει την κίνηση των στοιχείων γραφήματος. **Series**, **Categories**, **Series Elements**, **Categories Elements** μπορούν να κινούνται με τη μέθοδο [Sequence::addEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/sequence/#addEffect) και δύο enums [EffectChartMajorGroupingType](https://reference.aspose.com/slides/el/php-java/aspose.slides/EffectChartMajorGroupingType) και [EffectChartMinorGroupingType](https://reference.aspose.com/slides/el/php-java/aspose.slides/EffectChartMinorGroupingType).

## **Κίνηση Σειράς Γραφήματος**
Εάν θέλετε να δημιουργήσετε κίνηση για μια σειρά γραφήματος, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε την παραπομπή του αντικειμένου γραφήματος.
1. Κινητοποιήστε τη σειρά.
1. Γράψτε το αρχείο παρουσίασης στον δίσκο.

Στο παρακάτω παράδειγμα, δημιουργήσαμε κίνηση σε σειρά γραφήματος.

```php
  # Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Απόκτηση αναφοράς του αντικειμένου γραφήματος
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Κινητοποίηση της σειράς
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Αποθήκευση της τροποποιημένης παρουσίασης στο δίσκο
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Κίνηση Κατηγορίας Γραφήματος**
Εάν θέλετε να δημιουργήσετε κίνηση για μια κατηγορία γραφήματος, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε την παραπομπή του αντικειμένου γραφήματος.
1. Κινητοποιήστε την Κατηγορία.
1. Γράψτε το αρχείο παρουσίασης στον δίσκο.

Στο παρακάτω παράδειγμα, δημιουργήσαμε κίνηση σε κατηγορία γραφήματος.

```php
  # Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Κίνηση σε Στοιχείο Σειράς**
Εάν θέλετε να δημιουργήσετε κίνηση σε στοιχεία σειράς, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε την παραπομπή του αντικειμένου γραφήματος.
1. Κινητοποιήστε τα στοιχεία της σειράς.
1. Γράψτε το αρχείο παρουσίασης στον δίσκο.

Στο παρακάτω παράδειγμα, έχουμε δημιουργήσει κίνηση στα στοιχεία της σειράς.

```php
  # Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Απόκτηση αναφοράς του αντικειμένου γραφήματος
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Κινητοποίηση στοιχείων σειράς
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Αποθήκευση του αρχείου παρουσίασης στο δίσκο
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Κίνηση σε Στοιχείο Κατηγορίας**
Εάν θέλετε να δημιουργήσετε κίνηση σε στοιχεία κατηγοριών, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε την παραπομπή του αντικειμένου γραφήματος.
1. Κινητοποιήστε τα στοιχεία των κατηγοριών.
1. Γράψτε το αρχείο παρουσίασης στον δίσκο.

Στο παρακάτω παράδειγμα, έχουμε δημιουργήσει κίνηση στα στοιχεία των κατηγοριών.

```php
  # Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Απόκτηση αναφοράς του αντικειμένου γραφήματος
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Κινητοποίηση στοιχείων κατηγοριών
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Αποθήκευση του αρχείου παρουσίασης στο δίσκο
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζονται διαφορετικοί τύποι εφέ (π.χ., είσοδος, έμφαση, έξοδος) για γραφήματα όπως και για κανονικά σχήματα;**

Ναι. Ένα γράφημα αντιμετωπίζεται ως σχήμα, επομένως υποστηρίζει τους τυπικούς τύπους εφέ κίνησης, συμπεριλαμβανομένων εισόδου, έμφασης και εξόδου, με πλήρη έλεγχο μέσω της χρονογραμμής της διαφάνειας και των ακολουθιών κίνησης.

**Μπορώ να συνδυάσω κίνηση γραφήματος με μεταβάσεις διαφανειών;**

Ναι. Οι [Transitions](/slides/el/php-java/slide-transition/) εφαρμόζονται στη διαφάνεια, ενώ τα εφέ κίνησης εφαρμόζονται σε αντικείμενα στη διαφάνεια. Μπορείτε να χρησιμοποιήσετε και τα δύο μαζί στην ίδια παρουσίαση και να τα ελέγχετε ανεξάρτητα.

**Διατηρούνται οι κινήσεις γραφήματος όταν αποθηκεύεται σε PPTX;**

Ναι. Όταν [αποθηκεύετε σε PPTX](/slides/el/php-java/save-presentation/), όλα τα εφέ κίνησης και η σειρά τους διατηρούνται επειδή αποτελούν μέρος του εγγενούς μοντέλου κίνησης της παρουσίασης.

**Μπορώ να διαβάσω υπάρχουσες κινήσεις γραφήματος από μια παρουσίαση και να τις τροποποιήσω;**

Ναι. Το API παρέχει πρόσβαση στη χρονογραμμή της διαφάνειας, τις ακολουθίες και τα εφέ, επιτρέποντάς σας να εξετάζετε υπάρχουσες κινήσεις γραφήματος και να τις προσαρμόζετε χωρίς να δημιουργείτε ξανά όλα από την αρχή.

**Μπορώ να δημιουργήσω βίντεο που περιλαμβάνει κινήσεις γραφήματος χρησιμοποιώντας το Aspose.Slides;**

Ναι. Μπορείτε να [εξάγετε μια παρουσίαση σε βίντεο](/slides/el/php-java/convert-powerpoint-to-video/) διατηρώντας τις κινήσεις, ρυθμίζοντας τα χρονικά διαστήματα και άλλες ρυθμίσεις εξαγωγής ώστε το τελικό κλιπ να αντικατοπτρίζει την κινούμενη προβολή.