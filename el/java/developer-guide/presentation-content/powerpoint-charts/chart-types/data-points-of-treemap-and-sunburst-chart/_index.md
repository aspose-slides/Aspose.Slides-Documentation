---
title: Προσαρμογή Σημείων Δεδομένων σε Διαγράμματα Treemap και Sunburst με Java
linktitle: Σημεία Δεδομένων σε Διαγράμματα Treemap και Sunburst
type: docs
url: /el/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- διάγραμμα treemap
- διάγραμμα sunburst
- σημείο δεδομένων
- χρώμα ετικέτας
- χρώμα κλαδιού
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τα σημεία δεδομένων σε διαγράμματα treemap και sunburst με το Aspose.Slides για Java, συμβατό με μορφές PowerPoint."
---
## **Εισαγωγή**

Μεταξύ άλλων τύπων διαγραμμάτων PowerPoint, υπάρχουν δύο «ιεραρχικοί» τύποι — **Treemap** και **Sunburst** διάγραμμα (γνωστό επίσης ως Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph ή Multi Level Pie Chart). Αυτά τα διαγράμματα εμφανίζουν ιεραρχικά δεδομένα οργανωμένα ως δέντρο — από τα φύλλα μέχρι την κορυφή του κλαδιού. Τα φύλλα ορίζονται από τα σημεία δεδομένων της σειράς, και κάθε επόμενο επίπεδο ομαδοποίησης ορίζεται από την αντίστοιχη κατηγορία. Το Aspose.Slides for Java επιτρέπει τη μορφοποίηση των σημείων δεδομένων του Sunburst Chart και του Treemap σε Java.

Ακολουθεί ένα Sunburst Chart, όπου τα δεδομένα στη στήλη Series1 ορίζουν τους κόμβους φύλλων, ενώ οι άλλες στήλες ορίζουν ιεραρχικά σημεία δεδομένων:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Ας ξεκινήσουμε προσθέτοντας ένα νέο διάγραμμα Sunburst στην παρουσίαση:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="Δείτε επίσης" %}} 
- [**Δημιουργία ή ενημέρωση διαγραμμάτων παρουσίασης PowerPoint σε Java**](/slides/el/java/create-chart/)
{{% /alert %}}

Εάν υπάρχει ανάγκη μορφοποίησης των σημείων δεδομένων του διαγράμματος, θα πρέπει να χρησιμοποιήσουμε τα παρακάτω:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataPointLevelsManager), 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataPointLevel) κλάσεις 
και η μέθοδος [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) 
παρέχουν πρόσβαση στη μορφοποίηση των σημείων δεδομένων των διαγραμμάτων Treemap και Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataPointLevelsManager) 
χρησιμοποιείται για πρόσβαση σε κατηγορίες πολλαπλών επιπέδων – αντιπροσωπεύει το κοντέινερ των 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartCategoryLevelsManager) 
με ιδιότητες που προστέθηκαν ειδικά για σημεία δεδομένων. 
Η κλάση [**IChartDataPointLevel**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataPointLevel) 
έχει δύο μεθόδους: [**getFormat**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataPointLevel#getFormat--) και 
[**getDataLabel**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataPointLevel#getLabel--) που παρέχουν πρόσβαση στις αντίστοιχες ρυθμίσεις.

## **Εμφάνιση Τιμής Σημείου Δεδομένων**
Εμφάνιση τιμής του σημείου δεδομένων "Leaf 4":

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Ορισμός Ετικέτας και Χρώματος Σημείου Δεδομένων**
Ορίστε την ετικέτα δεδομένων "Branch 1" ώστε να εμφανίζει το όνομα σειράς ("Series1") αντί για το όνομα κατηγορίας. Στη συνέχεια ορίστε το χρώμα κειμένου σε κίτρινο:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Ορισμός Χρώματος Κλαδιού Σημείου Δεδομένων**
Αλλάξτε το χρώμα του κλαδιού "Steam 4":

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Συχνές Ερωτήσεις**

**Μπορώ να αλλάξω τη σειρά (ταξινόμηση) των τμημάτων σε Sunburst/Treemap;**

Όχι. Το PowerPoint ταξινομεί αυτόματα τα τμήματα (συνήθως κατά φθίνουσες τιμές, δεξιόστροφα). Το Aspose.Slides αντιγράφει αυτή τη συμπεριφορά: δεν μπορείτε να αλλάξετε τη σειρά άμεσα· την επιτυγχάνετε προεπεξεργάζοντας τα δεδομένα.

**Πώς επηρεάζει το θέμα της παρουσίασης τα χρώματα των τμημάτων και των ετικετών;**

Τα χρώματα του διαγράμματος κληρονομούν το [θέμα/παλέτα](/slides/el/java/presentation-theme/) της παρουσίασης, εκτός εάν ορίσετε ρητά γέμισματα/γραμματοσειρές. Για συνεπή αποτελέσματα, κλειδώστε γεμίσματα συμπαγή και μορφοποίηση κειμένου στα απαιτούμενα επίπεδα.

**Θα διατηρήσει η εξαγωγή σε PDF/PNG τα προσαρμοσμένα χρώματα κλαδιού και τις ρυθμίσεις ετικετών;**

Ναι. Κατά την εξαγωγή της παρουσίασης, οι ρυθμίσεις του διαγράμματος (γέμισματα, ετικέτες) διατηρούνται στα μορφότυπα εξόδου, επειδή το Aspose.Slides αποδίδει με την εφαρμοσμένη μορφοποίηση του διαγράμματος.

**Μπορώ να υπολογίσω τις πραγματικές συντεταγμένες μιας ετικέτας/στοιχείου για προσαρμοσμένη τοποθέτηση επικάλυψης πάνω στο διάγραμμα;**

Ναι. Μετά την επικύρωση της διάταξης του διαγράμματος, τα πραγματικά *x* και *y* είναι διαθέσιμα για τα στοιχεία (π.χ., ένα [DataLabel](https://reference.aspose.com/slides/el/java/com.aspose.slides/datalabel/)), κάτι που βοηθά στην ακριβή τοποθέτηση των επικάλυψεων.