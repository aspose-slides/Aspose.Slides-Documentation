---
title: Βελτιστοποίηση Υπολογισμών Διαγράμματος για Παρουσιάσεις σε Python
linktitle: Υπολογισμοί Διαγράμματος
type: docs
weight: 50
url: /el/python-net/chart-calculations/
keywords:
- υπολογισμοί διαγράμματος
- στοιχεία διαγράμματος
- θέση στοιχείου
- πραγματική θέση
- θυγατρικό στοιχείο
- γονικό στοιχείο
- τιμές διαγράμματος
- πραγματική τιμή
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Κατανοήστε τους υπολογισμούς διαγράμματος, τις ενημερώσεις δεδομένων και τον έλεγχο ακρίβειας στο Aspose.Slides για Python μέσω .NET για PPT, PPTX και ODP, με πρακτικά παραδείγματα κώδικα."
---
## **Επισκόπηση**

Aspose.Slides παρέχει API για εργασία με υπολογισμούς διαγραμμάτων και δεδομένα διάταξης σε παρουσιάσεις. Αυτό το άρθρο δείχνει πώς να ανακτήσετε τις πραγματικές τιμές των στοιχείων του διαγράμματος, συμπεριλαμβανομένης της πραγματικής θέσης και του μεγέθους των στοιχείων που υλοποιούν `ActualLayout` και των πραγματικών τιμών των αξόνων του διαγράμματος. Επίσης εξηγεί ότι αυτές οι τιμές γεμίζουν μετά την επικύρωση της διάταξης του διαγράμματος.

Επιπλέον, το άρθρο δείχνει πώς να λάβετε τη πραγματική θέση των γονικών στοιχείων του διαγράμματος και πώς να αποκρύψετε στοιχεία του διαγράμματος όπως ο τίτλος, οι άξονες, η υπόμνηση και οι γραμμές πλέγματος. Μαζί, αυτά τα παραδείγματα σας βοηθούν να ελέγξετε τις πληροφορίες διάταξης του διαγράμματος και να ελέγξετε την ορατότητα των στοιχείων του διαγράμματος σε παρουσιάσεις PowerPoint προγραμματιστικά.

## **Υπολογίστε τις Πραγματικές Τιμές των Στοιχείων του Διαγράμματος**
Aspose.Slides για Python μέσω .NET παρέχει ένα απλό API για την λήψη αυτών των ιδιοτήτων. Αυτό θα σας βοηθήσει να υπολογίσετε τις πραγματικές τιμές των στοιχείων του διαγράμματος. Οι πραγματικές τιμές περιλαμβάνουν τη θέση των στοιχείων που κληρονομούν την κλάση [IActualLayout](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/iactuallayout/) (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) και τις πραγματικές τιμές των αξόνων (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```

## **Υπολογίστε τη Πραγματική Θέση των Γονικών Στοιχείων του Διαγράμματος**
Aspose.Slides για Python μέσω .NET παρέχει ένα απλό API για την λήψη αυτών των ιδιοτήτων. Οι ιδιότητες του IActualLayout παρέχουν πληροφορίες σχετικά με τη πραγματική θέση του γονικού στοιχείου του διαγράμματος. Είναι απαραίτητο να καλέσετε τη μέθοδο IChart.ValidateChartLayout() προηγουμένως για να γεμίσετε τις ιδιότητες με τις πραγματικές τιμές.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```

## **Απόκρυψη Πληροφοριών από το Διάγραμμα**
Αυτό το θέμα σας βοηθά να καταλάβετε πώς να αποτρέψετε την εμφάνιση πληροφοριών από το διάγραμμα. Χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET μπορείτε να αποκρύψετε **Τίτλο, Κάθετο Άξονα, Οριζόντιο Άξονα** και **Γραμμές Πλέγματος** από το διάγραμμα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να χρησιμοποιήσετε αυτές τις ιδιότητες.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Απόκρυψη τίτλου διαγράμματος
    chart.has_title = False

    # Απόκρυψη άξονα τιμών
    chart.axes.vertical_axis.is_visible = False

    # Ορατότητα άξονα κατηγορίας
    chart.axes.horizontal_axis.is_visible = False

    # Απόκρυψη υπόμνησης
    chart.has_legend = False

    # Απόκρυψη κύριων γραμμών πλέγματος
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Setting series line color
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Λειτουργούν εξωτερικά βιβλία εργασίας Excel ως πηγή δεδομένων και πώς αυτό επηρεάζει τον επαναϋπολογισμό;**

Ναι. Ένα διάγραμμα μπορεί να αναφερθεί σε εξωτερικό βιβλίο εργασίας: όταν συνδέεστε ή ανανεώνετε την εξωτερική πηγή, οι τύποι και οι τιμές λαμβάνονται από αυτό το βιβλίο εργασίας, και το διάγραμμα αντικατοπτρίζει τις ενημερώσεις κατά τις λειτουργίες ανοίγματος/επεξεργασίας. Το API σας επιτρέπει να [ορίσετε το εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/) και να διαχειριστείτε τα συνδεδεμένα δεδομένα.

**Μπορώ να υπολογίσω και να εμφανίσω γραμμές τάσης χωρίς να υλοποιήσω την παλινδρόμηση μόνος μου;**

Ναι. Οι [Γραμμές Τάσης](/slides/el/python-net/trend-line/) (γραμμικές, εκθετικές κ.ά.) προστίθενται και ενημερώνονται από το Aspose.Slides· οι παράμετροι τους επανυπολογίζονται αυτόματα από τα δεδομένα της σειράς, έτσι δεν χρειάζεται να υλοποιήσετε τους δικούς σας υπολογισμούς.

**Εάν μια παρουσίαση έχει πολλαπλά διαγράμματα με εξωτερικούς συνδέσμους, μπορώ να ελέγξω ποιο βιβλίο εργασίας χρησιμοποιεί κάθε διάγραμμα για τις υπολογιζόμενες τιμές;**

Ναι. Κάθε διάγραμμα μπορεί να δείχνει στο δικό του [εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/), ή μπορείτε να δημιουργήσετε/αντικαταστήσετε ένα εξωτερικό βιβλίο εργασίας ανά διάγραμμα ανεξάρτητα από τα άλλα.