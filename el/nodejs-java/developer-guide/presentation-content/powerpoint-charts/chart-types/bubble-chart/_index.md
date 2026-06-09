---
title: "Προσαρμογή Διαγραμμάτων Φυσαλίδων σε Παρουσιάσεις Χρησιμοποιώντας JavaScript"
linktitle: "Διάγραμμα Φυσαλίδων"
type: docs
url: /el/nodejs-java/bubble-chart/
keywords:
- διάγραμμα φυσαλίδων
- μέγεθος φυσαλίδας
- κλιμάκωση μεγέθους
- παρουσίαση μεγέθους
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε ισχυρά διαγράμματα φυσαλίδων στο PowerPoint με JavaScript και Aspose.Slides για Node.js μέσω Java, ώστε να ενισχύσετε εύκολα την οπτικοποίηση των δεδομένων σας."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εργαστείτε με διαγράμματα φυσαλίδων στο Aspose.Slides. Καλύπτει δύο συγκεκριμένες επιλογές προσαρμογής: την κλιμάκωση του μεγέθους των φυσαλίδων μέσω της μεθόδου `setBubbleSizeScale` και τον έλεγχο του τρόπου παρουσίασης των τιμών μεγέθους των φυσαλίδων μέσω της μεθόδου `setBubbleSizeRepresentation`.

Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ένα διάγραμμα φυσαλίδων, να προσαρμόσετε την κλιμάκωση του μεγέθους του και να αλλάξετε την παρουσίαση του μεγέθους της φυσαλίδας ώστε να χρησιμοποιεί το πλάτος. Το άρθρο περιλαμβάνει επίσης μια σύντομη ενότητα FAQ που διευκρινίζει την υποστήριξη για τον τύπο διαγράμματος «Bubble with 3-D», σημειώνει ότι τα πρακτικά όρια των διαγραμμάτων εξαρτώνται από την απόδοση και την έκδοση του PowerPoint‑στόχου, και εξηγεί ότι η εξαγωγή διατηρεί την εμφάνιση του διαγράμματος μέσω της μηχανής απόδοσης Aspose.Slides.

## **Κλιμάκωση Μεγέθους Διαγράμματος Φυσαλίδων**
Το Aspose.Slides for Node.js via Java παρέχει υποστήριξη για την κλιμάκωση του μεγέθους διαγράμματος φυσαλίδων. Στο Aspose.Slides for Node.js via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) και [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) έχουν προστεθεί. Παρακάτω δίνεται ένα παράδειγμα.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αναπαράσταση Δεδομένων ως Μεγέθη Διαγράμματος Φυσαλίδων**
Οι μέθοδοι [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) και [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) έχουν προστεθεί στις κλάσεις [ChartSeries](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartSeriesGroup) και σχετικές κλάσεις. **BubbleSizeRepresentation** καθορίζει πώς παρουσιάζονται οι τιμές μεγέθους των φυσαλίδων στο διάγραμμα φυσαλίδων. Πιθανές τιμές είναι: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) και [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). Συνεπώς, το enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/BubbleSizeRepresentationType) προστέθηκε για να προσδιορίσει τους δυνατούς τρόπους αναπαράστασης των δεδομένων ως μεγέθη διαγράμματος φυσαλίδων. Παράδειγμα κώδικα δίνεται παρακάτω.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές ερωτήσεις**

**Υποστηρίζεται το «διάγραμμα φυσαλίδων με 3‑Δ επίδραση» και πώς διαφέρει από ένα κανονικό;**

Ναι. Υπάρχει ένας ξεχωριστός τύπος διαγράμματος, «Bubble with 3-D». Εφαρμόζει στυλ 3‑Δ στις φυσαλίδες αλλά δεν προσθέτει επιπλέον άξονα· τα δεδομένα παραμένουν X‑Y‑S (μέγεθος). Ο τύπος είναι διαθέσιμος στην απαρίθμηση [chart type](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/).

**Υπάρχει όριο στον αριθμό των σειρών και των σημείων σε ένα διάγραμμα φυσαλίδων;**

Δεν υπάρχει σκληρό όριο στο επίπεδο του API· οι περιορισμοί καθορίζονται από την απόδοση και την έκδοση του PowerPoint‑στόχου. Συνιστάται να διατηρείται ο αριθμός των σημείων λογικός για ευανάγνωστη παρουσίαση και ταχύτητα απόδοσης.

**Πώς θα επηρεάσει η εξαγωγή την εμφάνιση ενός διαγράμματος φυσαλίδων (PDF, εικόνες);**

Η εξαγωγή σε υποστηριζόμενες μορφές διατηρεί την εμφάνιση του διαγράμματος· η απόδοση πραγματοποιείται από τη μηχανή Aspose.Slides. Για μορφές raster/vector, εφαρμόζονται οι γενικοί κανόνες απόδοσης γραφικών διαγράμματος (ανάλυση, anti‑aliasing), επομένως επιλέξτε επαρκή DPI για εκτύπωση.