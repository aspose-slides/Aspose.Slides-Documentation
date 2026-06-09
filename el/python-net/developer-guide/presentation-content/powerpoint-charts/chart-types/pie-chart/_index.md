---
title: Προσαρμογή Διαγραμμάτων Πίτας σε Παρουσιάσεις με Python
linktitle: Διάγραμμα Πίτας
type: docs
url: /el/python-net/pie-chart/
keywords:
- διάγραμμα πίτας
- διαχείριση διαγράμματος
- προσαρμογή διαγράμματος
- επιλογές διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές σχεδίου
- χρώμα φέτας
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα πίτας σε Python με το Aspose.Slides, εξαγώγιμα σε PowerPoint και OpenDocument, ενισχύοντας την αφήγηση των δεδομένων σας σε δευτερόλεπτα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με διαγράμματα πίτας στο Aspose.Slides. Δείχνει πώς να διαμορφώσετε τις επιλογές δευτερεύοντος διαγράμματος για διαγράμματα Pie of Pie και Bar of Pie, καθώς και πώς να ενεργοποιήσετε αυτόματο χρωματισμό των φετών για ένα τυπικό διάγραμμα πίτας.

Τα παραδείγματα εστιάζουν σε πρακτικά βήματα προσαρμογής του διαγράμματος, όπως η προσθήκη διαγράμματος σε μια διαφάνεια, η προσαρμογή ρυθμίσεων σειράς και ετικέτας, η αντικατάσταση των προεπιλεγμένων δεδομένων διαγράμματος με προσαρμοσμένες κατηγορίες και τιμές, και η αποθήκευση της ενημερωμένης παρουσίασης.

## **Επιλογές Δευτερεύοντος Διαγράμματος για Pie of Pie και Bar of Pie**

Το Aspose.Slides for Python via .NET υποστηρίζει τώρα επιλογές δευτερεύοντος διαγράμματος για τα διαγράμματα Pie of Pie ή Bar of Pie. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να καθορίσουμε αυτές τις επιλογές χρησιμοποιώντας το Aspose.Slides. Για να καθορίσετε τις ιδιότητες, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Προσθέστε διάγραμμα στη διαφάνεια.
3. Καθορίστε τις επιλογές δευτερεύοντος διαγράμματος του διαγράμματος.
4. Αποθηκεύστε την παρουσίαση στο δίσκο.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
with slides.Presentation() as presentation:
    # Προσθέστε διάγραμμα στη διαφάνεια
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Ορίστε διαφορετικές ιδιότητες
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Αποθηκεύστε την παρουσίαση στο δίσκο
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Αυτόματων Χρωμάτων Φετών Διαγράμματος Πίτας**

Το Aspose.Slides for Python via .NET παρέχει ένα απλό API για τον ορισμό αυτόματων χρωμάτων φέτας σε διάγραμμα πίτας. Ο κώδικας παραδείγματος εφαρμόζει την ρύθμιση των παραπάνω ιδιοτήτων.

1. Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
2. Προσπελάστε την πρώτη διαφάνεια.
3. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα.
4. Ορίστε τίτλο διαγράμματος.
5. Ορίστε την πρώτη σειρά να Εμφανίζει Τιμές.
6. Ορίστε το δείκτη του φύλλου δεδομένων διαγράμματος.
7. Αποκτήστε το φύλλο εργασίας δεδομένων διαγράμματος.
8. Διαγράψτε τις προεπιλεγμένες παραγόμενες σειρές και κατηγορίες.
9. Προσθέστε νέες κατηγορίες.
10. Προσθέστε νέες σειρές.

Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει το αρχείο PPTX
with slides.Presentation() as presentation:
	# Προσπελάστε την πρώτη διαφάνεια
	slide = presentation.slides[0]

	# Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Ορισμός τίτλου διαγράμματος
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Ορίστε την πρώτη σειρά να Εμφανίζει Τιμές
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Ορισμός του δείκτη φύλλου δεδομένων διαγράμματος
	defaultWorksheetIndex = 0

	# Ανάκτηση του φύλλου εργασίας δεδομένων διαγράμματος
	fact = chart.chart_data.chart_data_workbook

	# Διαγραφή των προεπιλεγμένων δημιουργημένων σειρών και κατηγοριών
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Προσθήκη νέων κατηγοριών
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Προσθήκη νέας σειράς
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Τώρα γεμίζονται τα δεδομένα της σειράς
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζονται οι παραλλαγές 'Pie of Pie' και 'Bar of Pie';**

Ναι, η βιβλιοθήκη [υποστηρίζει](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/charttype/) ένα δευτερεύον διάγραμμα για διαγράμματα πίτας, συμπεριλαμβανομένων των τύπων 'Pie of Pie' και 'Bar of Pie'.

**Μπορώ να εξάγω μόνο το διάγραμμα ως εικόνα (π.χ., PNG);**

Ναι, μπορείτε να [εξάγετε το ίδιο το διάγραμμα ως εικόνα](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/get_image/) (όπως PNG) χωρίς ολόκληρη την παρουσίαση.