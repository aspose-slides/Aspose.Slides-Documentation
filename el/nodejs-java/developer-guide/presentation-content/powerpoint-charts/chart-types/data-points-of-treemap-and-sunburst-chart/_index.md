---
title: Προσαρμογή Σημείων Δεδομένων σε Διαγράμματα Treemap και Sunburst χρησιμοποιώντας JavaScript
linktitle: Σημεία Δεδομένων σε Διαγράμματα Treemap και Sunburst
type: docs
url: /el/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- διάγραμμα treemap
- διάγραμμα sunburst
- σημείο δεδομένων
- χρώμα ετικέτας
- χρώμα κλαδίου
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε σημεία δεδομένων σε διαγράμματα treemap και sunburst με JavaScript και Aspose.Slides για Node.js μέσω Java, συμβατό με μορφές PowerPoint."
---
## **Εισαγωγή**

Μεταξύ άλλων τύπων διαγραμμάτων PowerPoint, υπάρχουν δύο «ιεραρχικοί» τύποι - **Treemap** και **Sunburst** διάγραμμα (γνωστά επίσης ως Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph ή Multi Level Pie Chart). Αυτά τα διαγράμματα εμφανίζουν ιεραρχικά δεδομένα οργανωμένα ως δέντρο - από τα φύλλα μέχρι την κορυφή του κλαδιού. Τα φύλλα ορίζονται από τα σημεία δεδομένων της σειράς, και κάθε επόμενο ένθετο επίπεδο ομαδοποίησης ορίζεται από την αντίστοιχη κατηγορία. Aspose.Slides for Node.js μέσω Java επιτρέπει τη μορφοποίηση των σημείων δεδομένων του διαγράμματος Sunburst και Treemap σε JavaScript.

Ακολουθεί ένα διάγραμμα Sunburst, όπου τα δεδομένα στη στήλη Series1 ορίζουν τα φύλλα, ενώ οι άλλες στήλες ορίζουν ιεραρχικά σημεία δεδομένων:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Ας ξεκινήσουμε με την προσθήκη ενός νέου διαγράμματος Sunburst στην παρουσίαση:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="Δείτε επίσης" %}} 
- [**Δημιουργία ή ενημέρωση διαγραμμάτων παρουσίασης PowerPoint σε JavaScript**](/slides/el/nodejs-java/create-chart/)
{{% /alert %}}

Εάν υπάρχει ανάγκη μορφοποίησης των σημείων δεδομένων του διαγράμματος, πρέπει να χρησιμοποιήσουμε τα ακόλουθα:

Η [**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartDataPointLevelsManager), η [ChartDataPointLevel](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartDataPointLevel) κλάσεις και η μέθοδος [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) παρέχουν πρόσβαση στη μορφοποίηση των σημείων δεδομένων των διαγραμμάτων Treemap και Sunburst. Η [**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartDataPointLevelsManager) χρησιμοποιείται για την πρόσβαση σε πολυ‑επίπεδες κατηγορίες – αντιπροσωπεύει το κοντέινερ των αντικειμένων [**ChartDataPointLevel**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartDataPointLevel). Βασικά είναι ένας περιτύλιξη για το [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartCategoryLevelsManager) με ιδιότητες που προστέθηκαν ειδικά για τα σημεία δεδομένων. Η κλάση [**ChartDataPointLevel**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartDataPointLevel) έχει δύο μεθόδους: [**getFormat**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) και [**getDataLabel**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) που παρέχουν πρόσβαση στις αντίστοιχες ρυθμίσεις.

## **Εμφάνιση Τιμής Σημείου Δεδομένων**

Εμφάνιση τιμής του σημείου δεδομένων "Leaf 4":

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Ορισμός Ετικέτας και Χρώματος Σημείου Δεδομένων**

Ορίστε την ετικέτα του σημείου δεδομένων "Branch 1" ώστε να εμφανίζει το όνομα σειράς ("Series1") αντί του ονόματος κατηγορίας. Στη συνέχεια ορίστε το χρώμα κειμένου σε κίτρινο:

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Ορισμός Χρώματος Κλαδιού Σημείου Δεδομένων**

Αλλαγή χρώματος του κλαδιού "Steam 4":

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Συχνές Ερωτήσεις**

**Μπορώ να αλλάξω τη σειρά (ταξινόμηση) των τμημάτων σε Sunburst/Treemap;**

Όχι. Το PowerPoint ταξινομεί τα τμήματα αυτόματα (συνήθως κατά φθίνουσες τιμές, δεξιόστροφα). Το Aspose.Slides αντικατοπτρίζει αυτή τη συμπεριφορά: δεν μπορείτε να αλλάξετε τη σειρά απευθείας· την επιτυγχάνετε μέσω προεπεξεργασίας των δεδομένων.

**Πώς το θέμα της παρουσίασης επηρεάζει τα χρώματα των τμημάτων και των ετικετών;**

Τα χρώματα του διαγράμματος κληρονομούν το [theme/palette](/slides/el/nodejs-java/presentation-theme/) της παρουσίασης, εκτός εάν ορίσετε ρητά γεμίσεις/γραμματοσειρές. Για συνεπή αποτελέσματα, ορίστε σταθερές γεμίσεις και μορφοποίηση κειμένου στα απαιτούμενα επίπεδα.

**Θα διατηρήσει η εξαγωγή σε PDF/PNG τα προσαρμοσμένα χρώματα κλάδων και τις ρυθμίσεις ετικετών;**

Ναι. Κατά την εξαγωγή της παρουσίασης, οι ρυθμίσεις του διαγράμματος (γεμίσεις, ετικέτες) διατηρούνται στα μορφότυπα εξόδου, επειδή το Aspose.Slides αποδίδει με την εφαρμόμενη μορφοποίηση του διαγράμματος.

**Μπορώ να υπολογίσω τις πραγματικές συντεταγμένες μιας ετικέτας/στοιχείου για την προσαρμοσμένη τοποθέτηση επικάλυψης πάνω στο διάγραμμα;**

Ναι. Μετά την επικύρωση της διάταξης του διαγράμματος, τα πραγματικά X και Y είναι διαθέσιμα για τα στοιχεία (για παράδειγμα, ένα [DataLabel](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/datalabel/)), κάτι που βοηθά στην ακριβή τοποθέτηση των επικαλύψεων.