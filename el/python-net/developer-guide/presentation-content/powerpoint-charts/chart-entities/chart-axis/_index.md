---
title: Προσαρμογή Αξόνων Διαγράμματος σε Παρουσιάσεις με Python
linktitle: Άξονας Διαγράμματος
type: docs
url: /el/python-net/chart-axis/
keywords:
- άξονας διαγράμματος
- κατακόρυφος άξονας
- οριζόντιος άξονας
- προσαρμογή άξονα
- χειρισμός άξονα
- διαχείριση άξονα
- ιδιότητες άξονα
- μέγιστη τιμή
- ελάχιστη τιμή
- γραμμή άξονα
- μορφή ημερομηνίας
- τίτλος άξονα
- θέση άξονα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides για Python μέσω .NET για να προσαρμόσετε τους άξονες διαγράμματος σε παρουσιάσεις PowerPoint και OpenDocument για αναφορές και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τους άξονες διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να λαμβάνετε τις πραγματικές τιμές των αξόνων, να ανταλλάξετε δεδομένα μεταξύ των αξόνων, να κρύψετε τον κάθετο ή τον οριζόντιο άξονα για διαγράμματα γραμμής, να αλλάξετε τον τύπο του άξονα κατηγορίας, να ορίσετε τη μορφή ημερομηνίας για τις τιμές του άξονα κατηγορίας, να περιστρέψετε τον τίτλο του άξονα, να ορίσετε τη θέση του άξονα και να εμφανίσετε μια ετικέτα μονάδας στον άξονα τιμών.

## **Λήψη των μέγιστων τιμών στον κατακόρυφο άξονα των διαγραμμάτων**
Το Aspose.Slides για Python μέσω .NET σας επιτρέπει να λάβετε τις ελάχιστες και μέγιστες τιμές σε έναν κατακόρυφο άξονα. Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Προσπελάστε την πρώτη διαφάνεια.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα.
1. Αποκτήστε την πραγματική μέγιστη τιμή στον άξονα.
1. Αποκτήστε την πραγματική ελάχιστη τιμή στον άξονα.
1. Αποκτήστε τη πραγματική κύρια μονάδα του άξονα.
1. Αποκτήστε τη πραγματική δευτερεύουσα μονάδα του άξονα.
1. Αποκτήστε την πραγματική κλίμακα κύριας μονάδας του άξονα.
1. Αποκτήστε την πραγματική κλίμακα δευτερεύουσας μονάδας του άξονα.

Αυτό το δείγμα κώδικα—μια υλοποίηση των παραπάνω βημάτων—σας δείχνει πώς να λάβετε τις απαιτούμενες τιμές σε Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Αποθηκεύει την παρουσίαση
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ανταλλαγή των δεδομένων μεταξύ των αξόνων**
Το Aspose.Slides σας επιτρέπει να ανταλλάξετε γρήγορα τα δεδομένα μεταξύ των αξόνων—τα δεδομένα που απεικονίζονται στον κατακόρυφο άξονα (y‑άξονας) μετακινούνται στον οριζόντιο άξονα (x‑άξονας) και αντίστροφα.

Αυτός ο κώδικας Python σας δείχνει πώς να εκτελέσετε την ανταλλαγή δεδομένων μεταξύ των αξόνων σε ένα διάγραμμα:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Δημιουργεί κενή παρουσίαση
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Αλλάζει σειρές και στήλες
    chart.chart_data.switch_row_column()
            
    # Αποθηκεύει την παρουσίαση
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Απενεργοποίηση του κατακόρυφου άξονα για διαγράμματα γραμμών**

Αυτός ο κώδικας Python σας δείχνει πώς να κρύψετε τον κατακόρυφο άξονα για ένα διάγραμμα γραμμής:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Απενεργοποίηση του οριζόντιου άξονα για διαγράμματα γραμμών**

Αυτός ο κώδικας σας δείχνει πώς να κρύψετε τον οριζόντιο άξονα για ένα διάγραμμα γραμμής:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Αλλαγή του άξονα κατηγορίας**

Χρησιμοποιώντας την ιδιότητα **CategoryAxisType**, μπορείτε να καθορίσετε τον προτιμώμενο τύπο άξονα κατηγορίας (**date** ή **text**). Αυτός ο κώδικας σε Python επιδεικνύει τη λειτουργία:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός μορφής ημερομηνίας για την τιμή του άξονα κατηγορίας**
Το Aspose.Slides για Python μέσω .NET σας επιτρέπει να ορίσετε τη μορφή ημερομηνίας για μια τιμή άξονα κατηγορίας. Η λειτουργία παρουσιάζεται σε αυτόν τον κώδικα Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός γωνίας περιστροφής για τον τίτλο του άξονα διαγράμματος**
Το Aspose.Slides για Python μέσω .NET σας επιτρέπει να ορίσετε τη γωνία περιστροφής για τον τίτλο του άξονα ενός διαγράμματος. Αυτός ο κώδικας Python επιδεικνύει τη λειτουργία:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός θέσης άξονα σε άξονα κατηγορίας ή τιμής**
Το Aspose.Slides για Python μέσω .NET σας επιτρέπει να ορίσετε τη θέση του άξονα σε άξονα κατηγορίας ή τιμής. Αυτός ο κώδικας Python δείχνει πώς να εκτελέσετε την εργασία:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Ενεργοποίηση της ετικέτας μονάδας εμφάνισης στον άξονα τιμών του διαγράμματος**
Το Aspose.Slides για Python μέσω .NET σας επιτρέπει να διαμορφώσετε ένα διάγραμμα ώστε να εμφανίζει μια ετικέτα μονάδας στον άξονα τιμών του διαγράμματος. Αυτός ο κώδικας Python επιδεικνύει τη λειτουργία:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Πώς ορίζω τη τιμή στην οποία ένας άξονας διασχίζει τον άλλον (διασχισμός άξονα);**

Οι άξονες παρέχουν μια [ρύθμιση διασχίσεως](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/axis/cross_type/): μπορείτε να επιλέξετε να διασχίσουν στο μηδέν, στο μέγιστο της κατηγορίας/τιμής ή σε συγκεκριμένη αριθμητική τιμή. Αυτό είναι χρήσιμο για τη μετακίνηση του άξονα X πάνω ή κάτω ή για την ανάδειξη μιας γραμμής βάσης.

**Πώς μπορώ να τοποθετήσω τις ετικέτες του κροταφόρου σε σχέση με τον άξονα (πλαϊνά, έξω, μέσα);**

Ορίστε τη [θέση ετικέτας](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/axis/major_tick_mark/) σε "cross", "outside" ή "inside". Αυτό επηρεάζει την αναγνωσιμότητα και βοηθά στην εξοικονόμηση χώρου, ειδικά σε μικρά διαγράμματα.