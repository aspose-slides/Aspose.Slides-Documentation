---
title: Διαχείριση Επεξηγήσεων σε Διαγράμματα Παρουσίασης χρησιμοποιώντας JavaScript
linktitle: Επεξήγηση
type: docs
url: /el/nodejs-java/callout/
keywords:
- επεξήγηση διαγράμματος
- χρήση επεξήγησης
- ετικέτα δεδομένων
- μορφή ετικέτας
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε και μορφοποιήστε επεξηγήσεις στο Aspose.Slides για Node.js μέσω Java με σύντομες παραδείγματα κώδικα, συμβατά με PPT και PPTX για αυτοματοποίηση των ροών εργασίας παρουσίασης."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με τις επεξηγήσεις για τις ετικέτες δεδομένων διαγράμματος στο Aspose.Slides. Δείχνει πώς να χρησιμοποιείτε τη μέθοδο `setShowLabelAsDataCallout` για να εμφανίζετε τις ετικέτες ως επεξηγήσεις, πώς να διαμορφώνετε τις ρυθμίσεις ετικετών που σχετίζονται με τις επεξηγήσεις για ένα διάγραμμα δακτυλίου, και σημειώνει ότι οι επεξηγήσεις και η εμφάνισή τους διατηρούνται όταν οι παρουσιάσεις εξάγονται σε PDF, HTML5, SVG και μορφές ραστών εικόνων.

## **Χρήση Επεξηγήσεων**

Νέες μέθοδοι [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) και [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-) έχουν προστεθεί στην κλάση [DataLabelFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/datalabelformat) και στην κλάση [DataLabelFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/datalabelformat). Αυτές οι μέθοδοι καθορίζουν αν η ετικέτα δεδομένων του συγκεκριμένου διαγράμματος θα εμφανίζεται ως επεξήγηση δεδομένων ή ως ετικέτα δεδομένων.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 500, 400);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    pres.save("DisplayCharts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Επεξήγησης για Διάγραμμα Δακτυλίου**

Το Aspose.Slides για Node.js μέσω Java παρέχει υποστήριξη για τον καθορισμό του σχήματος επεξήγησης ετικέτας δεδομένων σειράς για ένα διάγραμμα δακτυλίου. Παρατίθεται το παρακάτω παράδειγμα κώδικα.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Doughnut, 10, 10, 500, 500, false);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    var seriesIndex = 0;
    while (seriesIndex < 15) {
        var series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize(20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    var categoryIndex = 0;
    while (categoryIndex < 15) {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        var i = 0;
        while (i < chart.getChartData().getSeries().size()) {
            var iCS = chart.getChartData().getSeries().get_Item(i);
            var dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
            if (i == (chart.getChartData().getSeries().size() - 1)) {
                var lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new aspose.slides.FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX(lbl.getX() + 0.5);
                lbl.setY(lbl.getY() + 0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι επεξηγήσεις κατά τη μετατροπή μιας παρουσίασης σε PDF, HTML5, SVG ή εικόνες;**

Ναι. Οι επεξηγήσεις αποτελούν μέρος της απόδοσης του διαγράμματος, έτσι όταν εξάγετε σε [PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/), [HTML5](/slides/el/nodejs-java/export-to-html5/), [SVG](/slides/el/nodejs-java/render-a-slide-as-an-svg-image/), ή [raster images](/slides/el/nodejs-java/convert-powerpoint-to-png/), διατηρούνται μαζί με τη μορφοποίηση της διαφάνειας.

**Λειτουργούν οι προσαρμοσμένες γραμματοσειρές στις επεξηγήσεις και μπορεί η εμφάνισή τους να διατηρηθεί κατά την εξαγωγή;**

Ναι. Το Aspose.Slides υποστηρίζει [embedding fonts](/slides/el/nodejs-java/embedded-font/) στην παρουσίαση και ελέγχει την ενσωμάτωση γραμματοσειρών κατά τις εξαγωγές, όπως το [PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/), εξασφαλίζοντας ότι οι επεξηγήσεις διατηρούν την ίδια εμφάνιση σε διαφορετικά συστήματα.