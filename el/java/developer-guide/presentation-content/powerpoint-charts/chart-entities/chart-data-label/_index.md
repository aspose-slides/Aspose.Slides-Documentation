---
title: Διαχείριση ετικετών δεδομένων διαγράμματος σε παρουσιάσεις χρησιμοποιώντας Java
linktitle: Ετικέτα δεδομένων
type: docs
url: /el/java/chart-data-label/
keywords:
- διάγραμμα
- ετικέτα δεδομένων
- ακρίβεια δεδομένων
- ποσοστό
- απόσταση ετικέτας
- θέση ετικέτας
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να μορφοποιείτε ετικέτες δεδομένων διαγράμματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας Aspose.Slides για Java, ώστε τα slides να είναι πιο ελκυστικά."
---
## **Εισαγωγή**

Οι ετικέτες δεδομένων σε ένα διάγραμμα εμφανίζουν λεπτομέρειες σχετικά με τις σειρές δεδομένων του διαγράμματος ή μεμονωμένα σημεία δεδομένων. Επιτρέπουν στους αναγνώστες να αναγνωρίζουν γρήγορα τις σειρές δεδομένων και κάνουν επίσης τα διαγράμματα πιο ευανάγνωστα.

## **Ορισμός ακρίβειας δεδομένων στις ετικέτες δεδομένων διαγράμματος**

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε την ακρίβεια δεδομένων σε μια ετικέτα δεδομένων διαγράμματος:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");

    pres.save("output.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εμφάνιση ποσοστού ως ετικέτες**

Το Aspose.Slides για Java σας επιτρέπει να ορίσετε ετικέτες ποσοστών σε εμφανιζόμενα διαγράμματα. Αυτός ο κώδικας Java δείχνει τη λειτουργία:

```java
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);
    IChartSeries series;
    double[] total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        IChartCategory cat = chart.getChartData().getCategories().get_Item(k);
    
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + (double) (chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData());
        }
    }
    
    double dataPontPercent = 0f;
    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
    
        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (double) ((series.getDataPoints().get_Item(j).getValue().getData())) / (double) (total_for_Cat[j]) * 100;
    
            IPortion port = new Portion();
            port.setText(String.format("{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8f);
            lbl.getTextFrameForOverriding().setText("");
            IParagraph para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
    
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    
    // Αποθηκεύει την παρουσίαση που περιέχει το διάγραμμα
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός συμβόλου ποσοστού στις ετικέτες δεδομένων διαγράμματος**

Αυτός ο κώδικας Java σας δείχνει πώς να ορίσετε το σύμβολο του ποσοστού για μια ετικέτα δεδομένων διαγράμματος:

```java
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Λαμβάνει την αναφορά μιας διαφάνειας μέσω του δείκτη της
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Δημιουργεί το γράφημα PercentsStackedColumn σε μια διαφάνεια
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    
    // Ορίζει το NumberFormatLinkedToSource σε ψευδές
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    
    chart.getChartData().getSeries().clear();
    int defaultWorksheetIndex = 0;
    
    // Λαμβάνει το φύλλο εργασίας δεδομένων του διαγράμματος
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    
    // Προσθέτει νέα σειρά
    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.80));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    
    // Ορίζει το χρώμα γεμίσματος της σειράς
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Ορίζει τις ιδιότητες του LabelFormat
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Προσθέτει νέα σειρά
    IChartSeries series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.70));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.50));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.20));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    
    // Ορίζει τύπο γεμίσματος και χρώμα
    series2.getFormat().getFill().setFillType(FillType.Solid);
    series2.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // Γράφει την παρουσίαση στο δίσκο
    pres.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός απόστασης ετικέτας από άξονα**

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε την απόσταση της ετικέτας από έναν άξονα κατηγορίας όταν εργάζεστε με διάγραμμα σχεδιασμένο από άξονες:

```java
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Λαμβάνει την αναφορά μιας διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Δημιουργεί ένα διάγραμμα στη διαφάνεια
    IChart ch = sld.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    
    // Ορίζει την απόσταση της ετικέτας από έναν άξονα
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    
    // Γράφει την παρουσίαση στο δίσκο
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ρύθμιση θέσης ετικέτας**

Όταν δημιουργείτε ένα διάγραμμα που δεν βασίζεται σε άξονα, όπως ένα διάγραμμα πίτας, οι ετικέτες δεδομένων του διαγράμματος μπορεί να βρίσκονται πολύ κοντά στην άκρη του. Σε τέτοια περίπτωση, πρέπει να ρυθμίσετε τη θέση της ετικέτας δεδομένων ώστε οι γραμμές σύζευξης να εμφανίζονται καθαρά.

Αυτός ο κώδικας Java δείχνει πώς να ρυθμίσετε τη θέση της ετικέτας σε ένα διάγραμμα πίτας:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.getChartData().getSeries();
    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);

    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![προσαρμοσμένη ετικέτα διαγράμματος πίτας](pie-chart-adjusted-label.png)

## **Συχνές ερωτήσεις**

**Πώς μπορώ να αποτρέψω την επικάλυψη των ετικετών δεδομένων σε πυκνά διαγράμματα;**

Συνδυάστε αυτόματη τοποθέτηση ετικετών, γραμμές σύζευξης και μειωμένο μέγεθος γραμματοσειράς· εάν χρειαστεί, κρύψτε ορισμένα πεδία (π.χ. την κατηγορία) ή εμφανίστε ετικέτες μόνο για ακραία/σημαντικά σημεία.

**Πώς μπορώ να απενεργοποιήσω τις ετικέτες μόνο για μηδενικές, αρνητικές ή κενές τιμές;**

Φιλτράρετε τα σημεία δεδομένων πριν ενεργοποιήσετε τις ετικέτες και απενεργοποιήστε την εμφάνιση για τιμές 0, αρνητικές τιμές ή ελλιπείς τιμές σύμφωνα με έναν ορισμένο κανόνα.

**Πώς μπορώ να εξασφαλίσω μια συνεπή μορφή ετικετών κατά την εξαγωγή σε PDF/εικόνες;**

Ορίστε ρητά τις γραμματοσειρές (οικογένεια, μέγεθος) και επαληθεύστε ότι η γραμματοσειρά είναι διαθέσιμη στην πλευρά απόδοσης για να αποφύγετε την εναλλακτική.