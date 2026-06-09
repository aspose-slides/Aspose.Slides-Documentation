---
title: Προσαρμογή διαγραμμάτων φυσαλίδων σε παρουσιάσεις σε Android
linktitle: Διάγραμμα Φυσαλίδας
type: docs
url: /el/androidjava/bubble-chart/
keywords:
- διάγραμμα φυσαλίδας
- μέγεθος φυσαλίδας
- κλιμάκωση μεγέθους
- παρουσίαση μεγέθους
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε ισχυρά διαγράμματα φυσαλίδων στο PowerPoint με το Aspose.Slides for Android μέσω Java για να βελτιώσετε εύκολα την απεικόνιση των δεδομένων σας."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εργάζεστε με διαγράμματα φυσαλίδων στο Aspose.Slides. Καλύπτει δύο συγκεκριμένες επιλογές προσαρμογής: την κλιμάκωση του μεγέθους των φυσαλίδων μέσω της μεθόδου `setBubbleSizeScale` και τον έλεγχο του τρόπου παρουσίασης των τιμών μεγέθους των φυσαλίδων μέσω της μεθόδου `setBubbleSizeRepresentation`.

Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ένα γράφημα φυσαλίδων, να προσαρμόσετε την κλιμάκωση του μεγέθους του και να αλλάξετε την παρουσίαση του μεγέθους της φυσαλίδας ώστε να χρησιμοποιείται το πλάτος. Το άρθρο περιλαμβάνει επίσης μια σύντομη ενότητα FAQ που διευκρινίζει την υποστήριξη του τύπου διαγράμματος “Bubble with 3‑D”, σημειώνει ότι τα πρακτικά όρια του διαγράμματος εξαρτώνται από τις επιδόσεις και την έκδοση του PowerPoint-στόχου, και εξηγεί ότι η εξαγωγή διατηρεί την εμφάνιση του διαγράμματος μέσω της μηχανής απόδοσης του Aspose.Slides.

## **Κλιμάκωση Μεγέθους Διαγράμματος Φυσαλίδων**
Aspose.Slides for Android via Java παρέχει υποστήριξη για κλιμάκωση μεγέθους διαγράμματος φυσαλίδων. Στο Aspose.Slides for Android via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) και [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) έχουν προστεθεί. Παρατίθεται παρακάτω ένα δείγμα κώδικα.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Παρουσίαση Δεδομένων ως Μεγέθη Διαγράμματος Φυσαλίδων**
Οι μέθοδοι [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) και [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) έχουν προστεθεί στα interfaces [IChartSeries](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChartSeriesGroup) και στις σχετικές κλάσεις. **BubbleSizeRepresentation** καθορίζει πώς τα μεγέθη των φυσαλίδων αντιπροσωπεύονται στο γράφημα φυσαλίδων. Πιθανές τιμές είναι: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) και [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). Συνεπώς, έχει προστεθεί η παρεμφερή enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/BubbleSizeRepresentationType) για τον καθορισμό των δυνατών τρόπων παρουσίασης των δεδομένων ως μεγέθη διαγράμματος φυσαλίδων. Δείγμα κώδικα παρατίθεται παρακάτω.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Υποστηρίζεται το “διάγραμμα φυσαλίδας με 3‑D εφέ” και πώς διαφέρει από ένα κανονικό;**

Ναι. Υπάρχει ξεχωριστός τύπος διαγράμματος, “Bubble with 3‑D”. Εφαρμόζει 3‑D στυλ στις φυσαλίδες, αλλά δεν προσθέτει πρόσθετο άξονα· τα δεδομένα παραμένουν X‑Y‑S (μέγεθος). Ο τύπος αυτός είναι διαθέσιμος στην κλάση [chart type](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/).

**Υπάρχει όριο στον αριθμό σειρών και σημείων σε ένα διάγραμμα φυσαλίδας;**

Δεν υπάρχει σκληρό όριο σε επίπεδο API· οι περιορισμοί καθορίζονται από τις επιδόσεις και την έκδοση του PowerPoint-στόχου. Συνιστάται να διατηρείτε τον αριθμό των σημείων λογικό για την αναγνωσιμότητα και την ταχύτητα απόδοσης.

**Πώς επηρεάζει η εξαγωγή την εμφάνιση ενός διαγράμματος φυσαλίδας (PDF, εικόνες);**

Η εξαγωγή σε υποστηριζόμενες μορφές διατηρεί την εμφάνιση του διαγράμματος· η απόδοση πραγματοποιείται από τη μηχανή Aspose.Slides. Για μορφές raster/vector, ισχύουν οι γενικοί κανόνες απόδοσης γραφικών (ανάλυση, anti‑aliasing), επομένως θα πρέπει να επιλέξετε επαρκή DPI για εκτύπωση.