---
title: Διαχείριση ετικετών δεδομένων γραφήματος σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Ετικέτα δεδομένων
type: docs
url: /el/nodejs-java/chart-data-label/
keywords:
- γράφημα
- ετικέτα δεδομένων
- ακρίβεια δεδομένων
- ποσοστό
- απόσταση ετικέτας
- τοποθεσία ετικέτας
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να μορφοποιείτε ετικέτες δεδομένων γραφήματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας JavaScript και Aspose.Slides για Node.js μέσω Java, για πιο ελκυστικές διαφάνειες."
---
## **Εισαγωγή**

Οι ετικέτες δεδομένων σε ένα γράφημα εμφανίζουν λεπτομέρειες για τις σειρές δεδομένων του γραφήματος ή για μεμονωμένα σημεία δεδομένων. Επιτρέπουν στους αναγνώστες να αναγνωρίζουν γρήγορα τις σειρές δεδομένων και κάνουν τα γραφήματα πιο εύκολα στην κατανόηση.

## **Ορισμός ακρίβειας δεδομένων στις ετικέτες δεδομένων του γραφήματος**

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε την ακρίβεια των δεδομένων σε μια ετικέτα δεδομένων γραφήματος:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Εμφάνιση ποσοστού ως ετικέτες**

Το Aspose.Slides για Node.js μέσω Java σάς επιτρέπει να ορίσετε ετικέτες ποσοστών σε εμφανιζόμενα γραφήματα. Αυτός ο κώδικας JavaScript επιδεικνύει τη λειτουργία:

```javascript
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);
    var series;
    var total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (var k = 0; k < chart.getChartData().getCategories().size(); k++) {
        var cat = chart.getChartData().getCategories().get_Item(k);
        for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData();
        }
    }
    var dataPontPercent = 0.0;
    for (var x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
        for (var j = 0; j < series.getDataPoints().size(); j++) {
            var lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (series.getDataPoints().get_Item(j).getValue().getData() / total_for_Cat[j]) * 100;
            var port = new aspose.slides.Portion();
            port.setText(java.callStaticMethodSync("java.lang.String", "format", "{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8.0);
            lbl.getTextFrameForOverriding().setText("");
            var para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    // Αποθηκεύει την παρουσίαση που περιέχει το γράφημα
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός σημείου ποσοστού στις ετικέτες δεδομένων του γραφήματος**

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε το σύμβολο ποσοστού για μια ετικέτα δεδομένων γραφήματος:

```javascript
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Λαμβάνει την αναφορά μιας διαφάνειας μέσω του δείκτη της
    var slide = pres.getSlides().get_Item(0);
    // Δημιουργεί το γράφημα PercentsStackedColumn στη διαφάνεια
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    // Ορίζει το NumberFormatLinkedToSource σε false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    chart.getChartData().getSeries().clear();
    var defaultWorksheetIndex = 0;
    // Λαμβάνει το φύλλο εργασίας δεδομένων γραφήματος
    var workbook = chart.getChartData().getChartDataWorkbook();
    // Προσθέτει νέα σειρά
    var series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    // Ορίζει το χρώμα γεμίσματος της σειράς
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Ορίζει τις ιδιότητες LabelFormat
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Προσθέτει νέα σειρά
    var series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.7));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.5));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.2));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    // Ορίζει τύπο γεμίσματος και χρώμα
    series2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    // Γράφει την παρουσίαση στο δίσκο
    pres.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός απόστασης ετικετών από τον άξονα**

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε την απόσταση της ετικέτας από έναν άξονα κατηγορίας όταν εργάζεστε με γράφημα που σχεδιάζεται από άξονες:

```javascript
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Λαμβάνει την αναφορά μιας διαφάνειας
    var sld = pres.getSlides().get_Item(0);
    // Δημιουργεί ένα γράφημα στη διαφάνεια
    var ch = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    // Ορίζει την απόσταση της ετικέτας από έναν άξονα
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    // Γράφει την παρουσίαση στο δίσκο
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ρύθμιση θέσης ετικετών**

Όταν δημιουργείτε ένα γράφημα που δεν βασίζεται σε κανέναν άξονα, όπως ένα διάγραμμα πίτας, οι ετικέτες δεδομένων του γραφήματος μπορεί να βρίσκονται πολύ κοντά στην άκρη του. Σε μια τέτοια περίπτωση, πρέπει να ρυθμίσετε τη θέση της ετικέτας δεδομένων ώστε οι γραμμές οδηγού να εμφανίζονται καθαρά.

Αυτός ο κώδικας JavaScript δείχνει πώς να προσαρμόσετε τη θέση της ετικέτας σε ένα διάγραμμα πίτας:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    var series = chart.getChartData().getSeries();
    var label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71);
    label.setY(0.04);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **Συχνές ερωτήσεις**

**Πώς μπορώ να αποτρέψω την επικάλυψη των ετικετών δεδομένων σε πυκνά γραφήματα;**

Συνδυάστε αυτόματη τοποθέτηση ετικετών, γραμμές οδηγού και μειωμένο μέγεθος γραμματοσειράς· εάν χρειαστεί, αποκρύψτε μερικά πεδία (π.χ. την κατηγορία) ή εμφανίστε ετικέτες μόνο για ακραία/κρίσιμα σημεία.

**Πώς μπορώ να απενεργοποιήσω τις ετικέτες μόνο για τιμές μηδέν, αρνητικές ή κενές;**

Φιλτράρετε τα σημεία δεδομένων πριν ενεργοποιήσετε τις ετικέτες και απενεργοποιήστε την εμφάνιση για τιμές 0, αρνητικές τιμές ή ελλιπείς τιμές σύμφωνα με έναν καθορισμένο κανόνα.

**Πώς μπορώ να εξασφαλίσω συνεπή στυλ ετικετών κατά την εξαγωγή σε PDF/εικόνες;**

Ορίστε ρητά τις γραμματοσειρές (συμμετρικό, μέγεθος) και βεβαιωθείτε ότι η γραμματοσειρά είναι διαθέσιμη στην πλευρά απόδοσης ώστε να αποφύγετε την εναλλακτική επιλογή.