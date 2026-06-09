---
title: Προσαρμογή Διαγραμμάτων Φυσαλίδων σε Παρουσιάσεις Χρησιμοποιώντας Java
linktitle: Διάγραμμα Φυσαλίδων
type: docs
url: /el/java/bubble-chart/
keywords:
- διάγραμμα φυσαλίδων
- μέγεθος φυσαλίδας
- κλιμάκωση μεγέθους
- αναπαράσταση μεγέθους
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε ισχυρά διαγράμματα φυσαλίδων στο PowerPoint με το Aspose.Slides for Java για να ενισχύσετε εύκολα την οπτικοποίηση των δεδομένων σας."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εργάζεστε με διαγράμματα φυσαλίδων στο Aspose.Slides. Καλύπτει δύο συγκεκριμένες επιλογές προσαρμογής: την κλιμάκωση του μεγέθους των φυσαλίδων μέσω της μεθόδου `setBubbleSizeScale` και τον έλεγχο του τρόπου που εμφανίζονται οι τιμές μεγέθους των φυσαλίδων μέσω της μεθόδου `setBubbleSizeRepresentation`.

Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ένα διάγραμμα φυσαλίδων, να προσαρμόσετε την κλιμάκωση του μεγέθους του και να αλλάξετε την αναπαράσταση του μεγέθους της φυσαλίδας ώστε να χρησιμοποιεί το πλάτος. Το άρθρο περιλαμβάνει επίσης μια σύντομη ενότητα FAQ που διευκρινίζει τη στήριξη του τύπου διαγράμματος «Bubble with 3-D», σημειώνει ότι τα πρακτικά όρια του διαγράμματος εξαρτώνται από την απόδοση και την έκδοση του PowerPoint-στόχου, και εξηγεί ότι η εξαγωγή διατηρεί την εμφάνιση του διαγράμματος μέσω της μηχανής απόδοσης Aspose.Slides.

## **Κλιμάκωση Μεγέθους Διαγράμματος Φυσαλίδων**
Το Aspose.Slides for Java παρέχει υποστήριξη για την κλιμάκωση του μεγέθους των διαγραμμάτων φυσαλίδων. Στο Aspose.Slides for Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) και [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) έχουν προστεθεί. Παρακάτω δίνεται ένα παράδειγμα δείγματος. 

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

## **Αναπαράσταση Δεδομένων ως Μεγέθη Διαγράμματος Φυσαλίδων**
Οι μέθοδοι [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) και [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) έχουν προστεθεί στις διεπαφές [IChartSeries](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartSeriesGroup) και στις σχετικές κλάσεις. **BubbleSizeRepresentation** καθορίζει πώς εμφανίζονται οι τιμές μεγέθους των φυσαλίδων στο διάγραμμα φυσαλίδων. Πιθανές τιμές είναι: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/el/java/com.aspose.slides/BubbleSizeRepresentationType#Area) και [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/el/java/com.aspose.slides/BubbleSizeRepresentationType#Width). Συνεπώς, το enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/el/java/com.aspose.slides/BubbleSizeRepresentationType) προστέθηκε για να ορίσει τους πιθανούς τρόπους ανάπαραστασης των δεδομένων ως μεγέθη διαγράμματος φυσαλίδων. Παρακάτω δίνεται ο κώδικας δείγματος.

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

## **Συχνές Ερωτήσεις**

**Υποστηρίζεται το «διάγραμμα φυσαλίδων με 3-D εφέ», και πώς διαφέρει από ένα κανονικό;**

Ναι. Υπάρχει ξεχωριστός τύπος διαγράμματος, «Bubble with 3-D». Εφαρμόζει στυλ 3-D στις φυσαλίδες, αλλά δεν προσθέτει επιπλέον άξονα· τα δεδομένα παραμένουν X‑Y‑S (μέγεθος). Ο τύπος είναι διαθέσιμος στην κλάση [chart type](https://reference.aspose.com/slides/el/java/com.aspose.slides/charttype/).

**Υπάρχει περιορισμός στον αριθμό των σειρών και σημείων σε ένα διάγραμμα φυσαλίδων;**

Δεν υπάρχει σκληρός περιορισμός σε επίπεδο API· οι περιορισμοί καθορίζονται από την απόδοση και την έκδοση του PowerPoint-στόχου. Συνιστάται να διατηρείτε τον αριθμό των σημείων λογικό για την αναγνωσιμότητα και την ταχύτητα απόδοσης.

**Πώς η εξαγωγή θα επηρεάσει την εμφάνιση ενός διαγράµματος φυσαλίδων (PDF, εικόνες);**

Η εξαγωγή σε υποστηριζόμενες μορφές διατηρεί την εμφάνιση του διαγράμματος· η απόδοση γίνεται από τη μηχανή Aspose.Slides. Για μορφές raster/vektor, ισχύουν γενικοί κανόνες απόδοσης γραφικών διαγράμματος (ανάλυση, anti-aliasing), επομένως επιλέξτε επαρκή DPI για εκτύπωση.