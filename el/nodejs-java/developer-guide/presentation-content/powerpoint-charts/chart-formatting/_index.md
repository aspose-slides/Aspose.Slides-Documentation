---
title: Μορφοποίηση Διαγραμμάτων Παρουσίασης σε JavaScript
linktitle: Μορφοποίηση Διαγράμματος
type: docs
weight: 60
url: /el/nodejs-java/chart-formatting/
keywords:
- μορφοποίηση διαγράμματος
- μορφοποίηση διαγράμματος
- στοιχείο διαγράμματος
- ιδιότητες διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές διαγράμματος
- ιδιότητες γραμματοσειράς
- στρογγυλεμένο περίγραμμα
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε τη μορφοποίηση διαγραμμάτων στο Aspose.Slides για Node.js σε JavaScript και αναβαθμίστε την παρουσίαση PowerPoint σας με επαγγελματικό, εντυπωσιακό στυλ."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μορφοποιήσετε διαγράμματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να προσαρμόζετε βασικά στοιχεία διαγράμματος όπως άξονες, γραμμές πλέγματος, τίτλους, υπομνήματα, την περιοχή σχεδίασης και τα γεμίσματα τοίχου για να βελτιώσετε την εμφάνιση και την αναγνωσιμότητα των δεδομένων του διαγράμματος.

Επίσης, δείχνει πώς να ορίσετε ιδιότητες γραμματοσειράς για το κείμενο του διαγράμματος, να εφαρμόσετε προεπιλεγμένες και προσαρμοσμένες αριθμητικές μορφές στα δεδομένα του διαγράμματος και να ενεργοποιήσετε στρογγυλεμένες γωνίες για την περιοχή του διαγράμματος. Μαζί, αυτά τα παραδείγματα δείχνουν πώς να ελέγχετε τόσο το οπτικό στυλ όσο και την παρουσίαση των δεδομένων των διαγραμμάτων σε μια παρουσίαση.

## **Μορφοποίηση Στοιχείων Διαγράμματος**

Το Aspose.Slides για Node.js μέσω Java επιτρέπει στους προγραμματιστές να προσθέτουν προσαρμοσμένα διαγράμματα στις διαφάνειες τους από το μηδέν. Αυτό το άρθρο εξηγεί πώς να μορφοποιήσετε διαφορετικά στοιχεία διαγράμματος, συμπεριλαμβανομένων των αξόνων κατηγορίας και τιμής του διαγράμματος.

Το Aspose.Slides για Node.js μέσω Java παρέχει ένα απλό API για τη διαχείριση διαφορετικών στοιχείων διαγράμματος και τη μορφοποίησή τους χρησιμοποιώντας προσαρμοσμένες τιμές:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [**Presentation**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια κατά τον δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και οποιοδήποτε επιθυμητό τύπο (σε αυτό το παράδειγμα θα χρησιμοποιήσουμε ChartType.LineWithMarkers).
1. Προσπελάστε τον άξονα Τιμής του διαγράμματος και ορίστε τις ακόλουθες ιδιότητες:
   1. Ορισμός **Line format** για τις κύριες γραμμές πλέγματος του άξονα Τιμής
   1. Ορισμός **Line format** για τις δευτερεύουσες γραμμές πλέγματος του άξονα Τιμής
   1. Ορισμός **Number Format** για τον άξονα Τιμής
   1. Ορισμός **Min, Max, Major and Minor units** για τον άξονα Τιμής
   1. Ορισμός **Text Properties** για τα δεδομένα του άξονα Τιμής
   1. Ορισμός **Title** για τον άξονα Τιμής
   1. Ορισμός **Line Format** για τον άξονα Τιμής
1. Προσπελάστε τον άξονα Κατηγορίας του διαγράμματος και ορίστε τις ακόλουθες ιδιότητες:
   1. Ορισμός **Line format** για τις κύριες γραμμές πλέγματος του άξονα Κατηγορίας
   1. Ορισμός **Line format** για τις δευτερεύουσες γραμμές πλέγματος του άξονα Κατηγορίας
   1. Ορισμός **Text Properties** για τα δεδομένα του άξονα Κατηγορίας
   1. Ορισμός **Title** για τον άξονα Κατηγορίας
   1. Ορισμός **Label Positioning** για τον άξονα Κατηγορίας
   1. Ορισμός **Rotation Angle** για τις ετικέτες του άξονα Κατηγορίας
1. Προσπελάστε το Υπομνήμα του διαγράμματος και ορίστε τις **Text Properties** για αυτό.
1. Ορίστε την εμφάνιση των Υπομνημάτων του διαγράμματος χωρίς να επικαλύπτονται το διάγραμμα.
1. Προσπελάστε τον **Secondary Value Axis** του διαγράμματος και ορίστε τις ακόλουθες ιδιότητες:
   1. Ενεργοποίηση του Δευτερεύοντος **Value Axis**
   1. Ορισμός **Line Format** για τον Δευτερεύοντα Άξονα Τιμής
   1. Ορισμός **Number Format** για τον Δευτερεύοντα Άξονα Τιμής
   1. Ορισμός **Min, Max, Major and Minor units** για τον Δευτερεύοντα Άξονα Τιμής
1. Τώρα σχεδιάστε τη πρώτη σειρά διαγράμματος στον Δευτερεύοντα Άξονα Τιμής
1. Ορίστε το χρώμα γεμίσματος του πίσω τοίχου του διαγράμματος
1. Ορίστε το χρώμα γεμίσματος της περιοχής σχεδίασης του διαγράμματος
1. Γράψτε την τροποποιημένη παρουσίαση σε ένα αρχείο PPTX

```javascript
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var slide = pres.getSlides().get_Item(0);
    // Προσθήκη του δείγματος διαγράμματος
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // Ορισμός Τίτλου Διαγράμματος
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Ορισμός μορφής κύριων γραμμών πλέγματος για τον άξονα τιμών
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Ορισμός μορφής δευτερευουσών γραμμών πλέγματος για τον άξονα τιμών
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Ορισμός μορφής αριθμού για τον άξονα τιμών
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // Ορισμός μέγιστων και ελάχιστων τιμών διαγράμματος
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // Ορισμός Ιδιοτήτων Κειμένου για τον Άξονα Τιμών
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Ορισμός τίτλου του άξονα τιμών
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Ορισμός μορφής κύριων γραμμών πλέγματος για τον άξονα κατηγορίας
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // Ορισμός μορφής δευτερευουσών γραμμών πλέγματος για τον άξονα κατηγορίας
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setFillFormat(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Ορισμός Ιδιοτήτων Κειμένου για τον Άξονα Κατηγορίας
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // Ορισμός Τίτλου Κατηγορίας
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Ορισμός θέσης ετικετών άξονα κατηγορίας
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // Ορισμός γωνίας περιστροφής ετικετών άξονα κατηγορίας
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // Ορισμός Ιδιοτήτων Κειμένου Υπομνημάτων
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // Ορισμός εμφάνισης υπομνημάτων διαγράμματος χωρίς επικάλυψη του διαγράμματος
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Ορισμός δευτερεύοντος άξονα τιμών
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // Ορισμός μορφής αριθμού για τον δευτερεύοντα άξονα τιμών
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // Ορισμός μέγιστων και ελάχιστων τιμών διαγράμματος
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // Ορισμός χρώματος πίσω τοίχου διαγράμματος
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Ορισμός χρώματος περιοχής σχεδίασης
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // Αποθήκευση Παρουσίασης
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Ιδιοτήτων Γραμματοσειράς για το Διάγραμμα**

Το Aspose.Slides για Node.js μέσω Java παρέχει υποστήριξη για τον ορισμό ιδιοτήτων γραμματοσειράς που σχετίζονται με το διάγραμμα. Παρακαλούμε ακολουθήστε τα παρακάτω βήματα για τον ορισμό των ιδιοτήτων γραμματοσειράς για το διάγραμμα.

- Δημιουργήστε ένα αντικείμενο κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
- Προσθέστε διάγραμμα στη διαφάνεια.
- Ορίστε το ύψος γραμματοσειράς.
- Αποθηκεύστε την τροποποιημένη παρουσίαση.

Παρατίθεται το παρακάτω παράδειγμα.

```javascript
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Μορφής Αριθμητικών**

Το Aspose.Slides για Node.js μέσω Java παρέχει ένα απλό API για τη διαχείριση μορφής δεδομένων διαγράμματος:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια κατά τον δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και οποιοδήποτε επιθυμητό τύπο (αυτό το παράδειγμα χρησιμοποιεί **ChartType.ClusteredColumn**).
1. Ορίστε τη προεπιλεγμένη μορφή αριθμού από τις διαθέσιμες προεπιλεγμένες τιμές.
1. Διασχίστε τα κελιά δεδομένων του διαγράμματος σε κάθε σειρά και ορίστε τη μορφή αριθμού των δεδομένων.
1. Αποθηκεύστε την παρουσίαση.
1. Ορίστε την προσαρμοσμένη μορφή αριθμού.
1. Διασχίστε τα κελιά δεδομένων του διαγράμματος σε κάθε σειρά και ορίστε διαφορετική μορφή αριθμού για τα δεδομένα.
1. Αποθηκεύστε την παρουσίαση.

```javascript
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης
    var slide = pres.getSlides().get_Item(0);
    // Προσθήκη προεπιλεγμένου διαγράμματος ομάδων στηλών
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // Πρόσβαση στη συλλογή σειρών του διαγράμματος
    var series = chart.getChartData().getSeries();
    // Διαπέραση όλων των σειρών του διαγράμματος
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Διαπέραση όλων των κελών δεδομένων στη σειρά
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // Ορισμός μορφής αριθμού
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0,00%
        }
    }
    // Αποθήκευση παρουσίασης
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Οι δυνατές προεπιλεγμένες τιμές μορφής αριθμών μαζί με τον αντίστοιχο δείκτη και που μπορούν να χρησιμοποιηθούν εμφανίζονται παρακάτω:

|**0**|Γενικό|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Ορισμός Στρογγυλεμένων Άκρων Περιοχής Διαγράμματος**

Το Aspose.Slides για Node.js μέσω Java παρέχει υποστήριξη για τον ορισμό της περιοχής διαγράμματος. Μέθοδοι [**hasRoundedCorners**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) και [**setRoundedCorners**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) έχουν προστεθεί στην κλάση [Chart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Chart).

1. Δημιουργήστε ένα αντικείμενο κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Προσθέστε διάγραμμα στη διαφάνεια.
1. Ορίστε τον τύπο γεμίσματος και το χρώμα γεμίσματος του διαγράμματος.
1. Ορίστε την ιδιότητα στρογγυλεμένων γωνιών σε True.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Παρατίθεται το παρακάτω παράδειγμα.

```javascript
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω ημιδιαφανείς γεμίσεις για στήλες/περιοχές ενώ διατηρώ το περίγραμμα αδιαφανές;**

Ναι. Η διαφάνεια του γεμίσματος και το περίγραμμα ρυθμίζονται ξεχωριστά. Αυτό είναι χρήσιμο για τη βελτίωση της αναγνωσιμότητας του πλέγματος και των δεδομένων σε πυκνές απεικονίσεις.

**Πώς μπορώ να αντιμετωπίσω τις ετικέτες δεδομένων όταν επικαλύπτονται;**

Μειώστε το μέγεθος της γραμματοσειράς, απενεργοποιήστε μη απαραίτητα στοιχεία ετικετών (π.χ. κατηγορίες), ορίστε την απόσταση/θέση της ετικέτας, εμφανίστε ετικέτες μόνο για επιλεγμένα σημεία εάν χρειάζεται, ή αλλάξτε τη μορφή σε «value + legend».

**Μπορώ να εφαρμόσω γεμίσεις διαβάθμισης ή μοτίβου σε σειρές;**

Ναι. Συνήθως είναι διαθέσιμες τόσο οι συμπαγείς όσο και οι γεμίσεις διαβάθμισης/μοτίβου. Στην πράξη, χρησιμοποιήστε τις διαβάθμιση με μέτρο και αποφύγετε συνδυασμούς που μειώνουν την αντίθεση με το πλέγμα και το κείμενο.