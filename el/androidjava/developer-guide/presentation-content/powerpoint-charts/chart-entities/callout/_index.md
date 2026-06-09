---
title: Διαχείριση Σημείων Αναφοράς σε Διαγράμματα Παρουσιάσεων στο Android
linktitle: Σημείο αναφοράς
type: docs
url: /el/androidjava/callout/
keywords:
- σήμα αναφοράς διαγράμματος
- χρήση σημείου αναφοράς
- ετικέτα δεδομένων
- μορφή ετικέτας
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε και μορφοποιήστε σημεία αναφοράς στο Aspose.Slides για Android με σύντομες παραδείγματα κώδικα Java, συμβατά με PPT και PPTX για την αυτοματοποίηση των ροών εργασίας παρουσιάσεων."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με σημεία αναφοράς για ετικέτες δεδομένων διαγράμματος στο Aspose.Slides. Δείχνει πώς να χρησιμοποιήσετε τη μέθοδο `setShowLabelAsDataCallout` για να εμφανίζετε τις ετικέτες ως σημεία αναφοράς, πώς να διαμορφώσετε τις ρυθμίσεις ετικετών σχετικών με τα σημεία αναφοράς για ένα διάγραμμα δακτυλίου, και σημειώνει ότι τα σημεία αναφοράς και η εμφάνισή τους διατηρούνται όταν οι παρουσιάσεις εξάγονται σε PDF, HTML5, SVG και μορφές ράστερ εικόνας.

## **Χρήση Σημείων Αναφοράς**
New methods [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) and [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) have been added to [DataLabelFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/datalabelformat) class and [IDataLabelFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idatalabelformat) interface. These methods determine either specified chart's data label will be displayed as data callout or as data label.

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

## **Ορισμός Σημείου Αναφοράς για Διάγραμμα Δακτυλίου**
Aspose.Slides for Android via Java provides support for setting series data label callout shape for a Doughnut chart. Below sample example is given. 

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

## **Συχνές Ερωτήσεις**

**Διατηρούνται τα σημεία αναφοράς κατά τη μετατροπή παρουσίασης σε PDF, HTML5, SVG ή εικόνες;**

Ναι. Τα σημεία αναφοράς είναι μέρος της απόδοσης του διαγράμματος, επομένως όταν εξάγετε σε [PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/), [HTML5](/slides/el/androidjava/export-to-html5/), [SVG](/slides/el/androidjava/render-a-slide-as-an-svg-image/), ή [raster images](/slides/el/androidjava/convert-powerpoint-to-png/), διατηρούνται μαζί με τη μορφοποίηση της διαφάνειας.

**Λειτουργούν οι προσαρμοσμένες γραμματοσειρές στα σημεία αναφοράς, και μπορεί η εμφάνισή τους να διατηρηθεί κατά την εξαγωγή;**

Ναι. Το Aspose.Slides υποστηρίζει [embedding fonts](/slides/el/androidjava/embedded-font/) στην παρουσίαση και ελέγχει το ενσωματωμένο των γραμματοσειρών κατά τις εξαγωγές όπως [PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/), διασφαλίζοντας ότι τα σημεία αναφοράς φαίνονται το ίδιο σε διαφορετικά συστήματα.