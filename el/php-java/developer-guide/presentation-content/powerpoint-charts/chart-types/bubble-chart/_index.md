---
title: Προσαρμογή Διαγραμμάτων Φυσαλίδων σε Παρουσιάσεις με PHP
linktitle: Διάγραμμα Φυσαλίδων
type: docs
url: /el/php-java/bubble-chart/
keywords:
- διάγραμμα φυσαλίδων
- μέγεθος φυσαλίδας
- κλιμάκωση μεγέθους
- αναπαράσταση μεγέθους
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε ισχυρά διαγράμματα φυσαλίδων στο PowerPoint με Aspose.Slides για PHP μέσω Java, ώστε να βελτιώσετε εύκολα την απεικόνιση των δεδομένων σας."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εργάζεστε με διαγράμματα φυσαλίδων στο Aspose.Slides. Καλύπτει δύο συγκεκριμένες επιλογές προσαρμογής: την κλιμάκωση του μεγέθους των φυσαλίδων μέσω της μεθόδου `setBubbleSizeScale` και τον έλεγχο του πώς οι τιμές του μεγέθους των φυσαλίδων αντιπροσωπεύονται μέσω της μεθόδου `setBubbleSizeRepresentation`.

Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ένα διάγραμμα φυσαλίδων, να προσαρμόσετε την κλιμάκωση του μεγέθους του και να αλλάξετε την αναπαράσταση του μεγέθους της φυσαλίδας ώστε να χρησιμοποιείται το πλάτος. Το άρθρο περιλαμβάνει επίσης μια σύντομη ενότητα Συχνές Ερωτήσεις (FAQ) που διευκρινίζει την υποστήριξη για τον τύπο διαγράμματος «Bubble with 3-D», σημειώνει ότι τα πρακτικά όρια του διαγράμματος εξαρτώνται από την απόδοση και την έκδοση του PowerPoint‑στόχου, και εξηγεί ότι η εξαγωγή διατηρεί την εμφάνιση του διαγράμματος μέσω της μηχανής απόδοσης Aspose.Slides.

## **Κλιμάκωση Μεγέθους Διαγράμματος Φυσαλίδων**
Aspose.Slides for PHP via Java παρέχει υποστήριξη για την κλιμάκωση του μεγέθους των διαγραμμάτων φυσαλίδων. Στην Aspose.Slides for PHP via Java έχουν προστεθεί οι μέθοδοι [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) και [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) . Παρέχεται το παρακάτω παράδειγμα κώδικα.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αναπαράσταση Δεδομένων ως Μεγέθη Διαγράμματος Φυσαλίδων**
Οι μέθοδοι [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) και [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) έχουν προστεθεί στις κλάσεις [ChartSeries](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartseriesgroup/) και στις σχετικές κλάσεις. **BubbleSizeRepresentation** ορίζει πώς οι τιμές του μεγέθους των φυσαλίδων απεικονίζονται στο διάγραμμα φυσαλίδων. Πιθανές τιμές είναι: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/el/php-java/aspose.slides/BubbleSizeRepresentationType#Area) και [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/el/php-java/aspose.slides/BubbleSizeRepresentationType#Width). Συνεπώς, το enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/el/php-java/aspose.slides/BubbleSizeRepresentationType) προστέθηκε για να καθορίζει τους πιθανούς τρόπους αναπαράστασης των δεδομένων ως μεγέθη διαγράμματος φυσαλίδων. Παρατίθεται παρακάτω δείγμα κώδικα.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Υπάρχει όριο στον αριθμό των σειρών και των σημείων σε ένα διάγραμμα φυσαλίδων;**

Δεν υπάρχει σκληρό όριο στο επίπεδο του API· οι περιορισμοί καθορίζονται από την απόδοση και την έκδοση του PowerPoint‑στόχου. Συνιστάται να διατηρείτε τον αριθμό των σημείων σε λογικά επίπεδα για αναγνωσιμότητα και ταχύτητα απόδοσης.

**Πώς θα επηρεάσει η εξαγωγή την εμφάνιση ενός διαγράμματος φυσαλίδων (PDF, εικόνες);**

Η εξαγωγή σε υποστηριζόμενες μορφές διατηρεί την εμφάνιση του διαγράμματος· η απόδοση πραγματοποιείται από τη μηχανή Aspose.Slides. Για μορφές raster/vektor, εφαρμόζονται οι γενικοί κανόνες απόδοσης γραφικών διαγράμματος (ανάλυση, anti-aliasing), έτσι πρέπει να επιλέξετε επαρκή DPI για εκτύπωση.

**Ναι. Υπάρχει ξεχωριστός τύπος διαγράμματος, «Bubble with 3-D». Εφαρμόζει στυλ 3‑Δ στις φυσαλίδες, αλλά δεν προσθέτει επιπλέον άξονα· τα δεδομένα παραμένουν X‑Y‑S (μέγεθος). Ο τύπος αυτός είναι διαθέσιμος στην κλάση [τύπος διαγράμματος](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/).**