---
title: Διαχείριση Callouts σε Διαγράμματα Παρουσιάσεων με Java
linktitle: Υποσημείωση
type: docs
url: /el/java/callout/
keywords:
- υποσημείωση διαγράμματος
- χρήση υποσημείωσης
- ετικέτα δεδομένων
- μορφή ετικέτας
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε και διαμορφώστε υποσημειώσεις στο Aspose.Slides για Java με σύντομη παραδείγματα κώδικα, συμβατό με PPT και PPTX για αυτοματοποίηση ροών εργασίας παρουσίασης."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με callouts για ετικέτες δεδομένων διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να χρησιμοποιήσετε τη μέθοδο `setShowLabelAsDataCallout` για να εμφανίσετε τις ετικέτες ως callouts, πώς να διαμορφώσετε τις ρυθμίσεις ετικετών που σχετίζονται με callout για ένα διάγραμμα doughnut, και σημειώνει ότι τα callouts και η εμφάνισή τους διατηρούνται όταν οι παρουσιάσεις εξάγονται σε PDF, HTML5, SVG και μορφές raster εικόνων.

## **Χρήση Callouts**
Νέες μέθοδοι [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) και [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) προστέθηκαν στην κλάση [DataLabelFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/datalabelformat) και στη διεπαφή [IDataLabelFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/idatalabelformat). Αυτές οι μέθοδοι καθορίζουν εάν η ετικέτα δεδομένων του συγκεκριμένου διαγράμματος θα εμφανίζεται ως data callout ή ως data label.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400);
    
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    
    pres.save("DisplayCharts.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Callout για Διάγραμμα Doughnut**
Το Aspose.Slides for Java παρέχει υποστήριξη για τον ορισμό του σχήματος callout ετικέτας δεδομένων σειράς για ένα διάγραμμα doughnut. Παρακάτω παρατίθεται ένα παράδειγμα.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, false);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    int seriesIndex = 0;
    while (seriesIndex < 15)
    {
        IChartSeries series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize((byte)20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    int categoryIndex = 0;
    while (categoryIndex < 15)
    {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        int i = 0;
        while (i < chart.getChartData().getSeries().size())
        {
            IChartSeries iCS = chart.getChartData().getSeries().get_Item(i);
            IChartDataPoint dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(LineDashStyle.Solid);
            if (i == chart.getChartData().getSeries().size() - 1)
            {
                IDataLabel lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.LIGHT_GRAY);
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX((float) lbl.getX()+ (float)0.5);
                lbl.setY((float)lbl.getY()+ (float)0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Διατηρούνται τα callouts όταν μετατρέπεται μια παρουσίαση σε PDF, HTML5, SVG ή εικόνες;**

Ναι. Τα callouts είναι μέρος της απόδοσης του διαγράμματος, έτσι όταν εξάγετε σε [PDF](/slides/el/java/convert-powerpoint-to-pdf/), [HTML5](/slides/el/java/export-to-html5/), [SVG](/slides/el/java/render-a-slide-as-an-svg-image/), ή [raster images](/slides/el/java/convert-powerpoint-to-png/), διατηρούνται μαζί με τη μορφοποίηση της διαφάνειας.

**Λειτουργούν οι προσαρμοσμένες γραμματοσειρές στις υποσημειώσεις και μπορεί η εμφάνισή τους να διατηρηθεί κατά την εξαγωγή;**

Ναι. Το Aspose.Slides υποστηρίζει [ενσωμάτωση γραμματοσειρών](/slides/el/java/embedded-font/) στην παρουσίαση και ελέγχει την ενσωμάτωση γραμματοσειρών κατά τις εξαγωγές όπως το [PDF](/slides/el/java/convert-powerpoint-to-pdf/), διασφαλίζοντας ότι τα callouts εμφανίζονται με τον ίδιο τρόπο σε διαφορετικά συστήματα.