---
title: Διαχείριση Επεξηγήσεων σε Διαγράμματα Παρουσίασης με Python
linktitle: Επεξήγηση
type: docs
url: /el/python-net/callout/
keywords:
- επεξήγηση διαγράμματος
- χρήση επεξήγησης
- ετικέτα δεδομένων
- μορφή ετικέτας
- Python
- Aspose.Slides
description: "Δημιουργήστε και μορφοποιήστε επεξηγήσεις στο Aspose.Slides for Python .NET με σύντομες παραδείγματα κώδικα, συμβατό με PPT, PPTX και ODP για αυτοματοποίηση ροών εργασίας παρουσίασης."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με επεξηγήσεις για ετικέτες δεδομένων διαγράμματος στο Aspose.Slides. Δείχνει πώς να χρησιμοποιείτε την ιδιότητα `show_label_as_data_callout` για να εμφανίζετε τις ετικέτες ως επεξηγήσεις, πώς να ρυθμίσετε τις ρυθμίσεις ετικετών σχετικές με τις επεξηγήσεις για διάγραμμα δακτυλίου, και σημειώνει ότι οι επεξηγήσεις και η εμφάνισή τους διατηρούνται όταν οι παρουσιάσεις εξάγονται σε PDF, HTML5, SVG και μορφές ραστερ εικόνων.

## **Χρήση Επεξηγήσεων**
Η νέα ιδιότητα **show_label_as_data_callout** προστέθηκε στην κλάση **DataLabelFormat**, η οποία καθορίζει αν η ετικέτα δεδομένων του συγκεκριμένου διαγράμματος θα εμφανίζεται ως επεξήγηση ή ως ετικέτα δεδομένων. Στο παρακάτω παράδειγμα, έχουμε ορίσει τις Επεξηγήσεις.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Επεξήγησης για Διάγραμμα Δακτυλίου**
Το Aspose.Slides for Python μέσω .NET παρέχει υποστήριξη για τον ορισμό του σχήματος επεξήγησης ετικέτας δεδομένων σειράς για ένα διάγραμμα δακτυλίου. Δίνεται το παρακάτω παράδειγμα.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.DOUGHNUT, 10, 10, 500, 500, False)
    workBook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = False
    seriesIndex = 0
    while seriesIndex < 15:
        series = chart.chart_data.series.add(workBook.get_cell(0, 0, seriesIndex + 1, "SERIES " + str(seriesIndex)), chart.type)
        series.explosion = 0
        series.parent_series_group.doughnut_hole_size = 20
        series.parent_series_group.first_slice_angle = 351
        seriesIndex += 1
    categoryIndex = 0
    while categoryIndex < 15:
        chart.chart_data.categories.add(workBook.get_cell(0, categoryIndex + 1, 0, "CATEGORY " + str(categoryIndex)))
        i = 0
        while i < len(chart.chart_data.series):
            iCS = chart.chart_data.series[i]
            dataPoint = iCS.data_points.add_data_point_for_doughnut_series(workBook.get_cell(0, categoryIndex + 1, i + 1, 1))
            dataPoint.format.fill.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.solid_fill_color.color = draw.Color.white
            dataPoint.format.line.width = 1
            dataPoint.format.line.style = slides.LineStyle.SINGLE
            dataPoint.format.line.dash_style = slides.LineDashStyle.SOLID
            if i == len(chart.chart_data.series) - 1:
                lbl = dataPoint.label
                lbl.text_format.text_block_format.autofit_type = slides.TextAutofitType.SHAPE
                lbl.data_label_format.text_format.portion_format.font_bold = 1
                lbl.data_label_format.text_format.portion_format.latin_font = slides.FontData("DINPro-Bold")
                lbl.data_label_format.text_format.portion_format.font_height = 12
                lbl.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
                lbl.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.light_gray
                lbl.data_label_format.format.line.fill_format.solid_fill_color.color = draw.Color.white
                lbl.data_label_format.show_value = False
                lbl.data_label_format.show_category_name = True
                lbl.data_label_format.show_series_name = False
                lbl.data_label_format.show_leader_lines = True
                lbl.data_label_format.show_label_as_data_callout = False
                chart.validate_chart_layout()
                lbl.as_i_layoutable.x += 0.5
                lbl.as_i_layoutable.y += 0.5
            i += 1
        categoryIndex +=1 
    pres.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι επεξηγήσεις όταν μετατρέπεται μια παρουσίαση σε PDF, HTML5, SVG ή εικόνες;**

Ναι. Οι επεξηγήσεις αποτελούν μέρος της απόδοσης του διαγράμματος, έτσι όταν εξάγετε σε [PDF](/slides/el/python-net/convert-powerpoint-to-pdf/),[HTML5](/slides/el/python-net/export-to-html5/),[SVG](/slides/el/python-net/render-a-slide-as-an-svg-image/), ή [raster images](/slides/el/python-net/convert-powerpoint-to-png/), διατηρούνται μαζί με τη μορφοποίηση της διαφάνειας.

**Λειτουργούν προσαρμοσμένες γραμματοσειρές στις επεξηγήσεις και μπορεί η εμφάνισή τους να διατηρηθεί κατά την εξαγωγή;**

Ναι. Το Aspose.Slides υποστηρίζει την [ενσωμάτωση γραμματοσειρών](/slides/el/python-net/embedded-font/) στο έγγραφο παρουσίασης και ελέγχει την ενσωμάτωση γραμματοσειρών κατά τις εξαγωγές όπως το [PDF](/slides/el/python-net/convert-powerpoint-to-pdf/), διασφαλίζοντας ότι οι επεξηγήσεις φαίνονται με τον ίδιο τρόπο σε διαφορετικά συστήματα.