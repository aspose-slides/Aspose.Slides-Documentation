---
title: Δημιουργία ή Ενημέρωση Διαγραμμάτων Παρουσίασης PowerPoint σε Python
linktitle: Δημιουργία ή Ενημέρωση Διαγράμματος
type: docs
weight: 10
url: /el/python-net/create-chart/
keywords:
- προσθήκη διαγράμματος
- δημιουργία διαγράμματος
- επεξεργασία διαγράμματος
- αλλαγή διαγράμματος
- ενημέρωση διαγράμματος
- διάγραμμα διασκορπισμού
- διάγραμμα πίτας
- διάγραμμα γραμμής
- διάγραμμα χάρτη δέντρου
- διάγραμμα μετοχών
- διάγραμμα κουτιού‑ζυγού
- διάγραμμα χωνιού
- διάγραμμα ηλιακής έκρηξης
- διάγραμμα ιστογράμματος
- διάγραμμα ραντάρ
- διάγραμμα πολλαπλών κατηγοριών
- παρουσίαση PowerPoint
- Python
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET. Καλύπτει την προσθήκη, τη μορφοποίηση και την επεξεργασία διαγραμμάτων σε παρουσιάσεις με πρακτικά παραδείγματα κώδικα σε Python."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα χρησιμοποιώντας το Aspose.Slides for Python via .NET. Θα μάθετε πώς να προσθέτετε προγραμματικά ένα διάγραμμα σε μια διαφάνεια, να το γεμίζετε με δεδομένα και να εφαρμόζετε διάφορες επιλογές μορφοποίησης ώστε να ταιριάζει με τις συγκεκριμένες απαιτήσεις σχεδίασής σας. Σ throughout το άρθρο, λεπτομερείς παραδείγματα κώδικα απεικονίζουν κάθε βήμα, από την αρχικοποίηση της παρουσίασης και του αντικειμένου διαγράμματος μέχρι τη ρύθμιση σειρών, αξόνων και υπομνημάτων. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε σταθερή κατανόηση του πώς να ενσωματώνετε δυναμική δημιουργία διαγραμμάτων στις εφαρμογές σας, βελτιστοποιώντας τη δημιουργία παρουσιάσεων που βασίζονται σε δεδομένα.

## **Δημιουργία Διαγράμματος**

Τα διαγράμματα βοηθούν τους ανθρώπους να οπτικοποιούν γρήγορα τα δεδομένα και να εξάγουν συμπεράσματα που μπορεί να μην είναι άμεσα εμφανή από έναν πίνακα ή ένα λογιστικό φύλλο.

**Γιατί να Δημιουργήσετε Διαγράμματα;**

Με τη χρήση διαγραμμάτων, μπορείτε:

* να συγκεντρώσετε, συμπιέσετε ή συνοψίσετε μεγάλες ποσότητες δεδομένων σε μία μόνο διαφάνεια μιας παρουσίασης·
* να αποκαλύψετε μοτίβα και τάσεις στα δεδομένα·
* να εξακριβώσετε την κατεύθυνση και την ορμή των δεδομένων με την πάροδο του χρόνου ή σε σχέση με συγκεκριμένη μονάδα μέτρησης·
* να εντοπίσετε ακραίες τιμές, αποκλίσεις, σφάλματα και ασυμβίβαστα δεδομένα·
* να επικοινωνήσετε ή να παρουσιάσετε πολύπλοκα δεδομένα.

Στο PowerPoint, μπορείτε να δημιουργήσετε διαγράμματα μέσω της λειτουργίας *Insert*, η οποία παρέχει πρότυπα για το σχεδιασμό πολλών τύπων διαγραμμάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε τόσο κανονικά διαγράμματα (βασισμένα σε δημοφιλείς τύπους) όσο και προσαρμοσμένα διαγράμματα.

{{% alert color="primary" %}} 
Χρησιμοποιήστε την απαρίθμηση [ChartType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/charttype/) στο χώρο ονομάτων [Aspose.Slides.Charts](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/). Οι τιμές σε αυτή την απαρίθμηση αντιστοιχούν σε διαφορετικούς τύπους διαγραμμάτων.
{{% /alert %}} 

### **Δημιουργία Στοιβαγμένων Διπλών Στηλών**

Αυτή η ενότητα εξηγεί πώς να δημιουργήσετε στοιβαγμένα διαγράμματα στηλών χρησιμοποιώντας το Aspose.Slides for Python via .NET. Θα μάθετε πώς να αρχικοποιείτε μια παρουσίαση, να προσθέτετε ένα διάγραμμα και να προσαρμόζετε στοιχεία όπως τίτλο, δεδομένα, σειρές, κατηγορίες και στυλ. Ακολουθήστε τα βήματα παρακάτω για να δείτε πώς δημιουργείται ένα τυπικό στοιβαγμένο διάγραμμα στήλης:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο `ChartType.CLUSTERED_COLUMN` .
1. Προσθέστε έναν τίτλο στο διάγραμμα.
1. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.
1. Καθαρίστε όλες τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.
1. Εφαρμόστε χρώμα γεμίσματος στις σειρές.
1. Προσθέστε ετικέτες στις σειρές.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα στοιβαγμένο διάγραμμα στήλης:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη διαγράμματος στοιβάσματος στηλών με τα προεπιλεγμένα δεδομένα.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Ορισμός του τίτλου του διαγράμματος.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Ορισμός της πρώτης σειράς ώστε να εμφανίζει τιμές.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος.
    worksheet_index = 0

    # Λήψη του βιβλίου εργασίας δεδομένων του διαγράμματος.
    workbook = chart.chart_data.chart_data_workbook

    # Διαγραφή των προεπιλεγμένων παραγόμενων σειρών και κατηγοριών.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Προσθήκη νέων σειρών.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # Προσθήκη νέων κατηγοριών.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # Λήψη της πρώτης σειράς του διαγράμματος.
    series = chart.chart_data.series[0]

    # Γέμισμα δεδομένων σειράς.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Ορισμός χρώματος γεμίσματος για τη σειρά.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Λήψη της δεύτερης σειράς του διαγράμματος.
    series = chart.chart_data.series[1]

    # Γέμισμα δεδομένων σειράς.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # Ορισμός χρώματος γεμίσματος για τη σειρά.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # Ορισμός της πρώτης ετικέτας ώστε να εμφανίζει το όνομα κατηγορίας.
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # Ορισμός της σειράς ώστε να εμφανίζει την τιμή για την τρίτη ετικέτα.
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # Αποθήκευση της παρουσίασης στον δίσκο ως αρχείο PPTX.
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το γράφημα Στοιβάσματος Στήλης](clustered_column_chart.png)

### **Δημιουργία Διαγραμμάτων Scatter**

Τα διαγράμματα scatter (γνωστά και ως scatter plots ή γραφήματα x‑y) χρησιμοποιούνται συχνά για να ελέγξουν μοτίβα ή να δείξουν συσχετίσεις μεταξύ δύο μεταβλητών.

Χρησιμοποιήστε διάγραμμα scatter όταν:

* Έχετε αριθμητικά δεδομένα σε ζεύγη·
* Έχετε δύο μεταβλητές που ταιριάζουν καλά μαζί·
* Θέλετε να καθορίσετε εάν οι δύο μεταβλητές σχετίζονται·
* Έχετε μια ανεξάρτητη μεταβλητή που έχει πολλαπλές τιμές για μια εξαρτημένη μεταβλητή.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα scatter με διαφορετική σειρά δεικτών:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργία μιας στιγμής της κλάσης Presentation.
with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Δημιουργία του προεπιλεγμένου διαγράμματος scatter.
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος.
    worksheet_index = 0

    # Λήψη του βιβλίου εργασίας δεδομένων του διαγράμματος.
    workbook = chart.chart_data.chart_data_workbook

    # Διαγραφή των προεπιλεγμένων σειρών.
    chart.chart_data.series.clear()

    # Προσθήκη νέων σειρών.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # Λήψη της πρώτης σειράς του διαγράμματος.
    series = chart.chart_data.series[0]

    # Προσθήκη ενός νέου σημείου (1:3) στη σειρά.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # Προσθήκη ενός νέου σημείου (2:10).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # Αλλαγή τύπου σειράς.
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Αλλαγή του δείκτη (marker) της σειράς διαγράμματος.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # Λήψη της δεύτερης σειράς του διαγράμματος.
    series = chart.chart_data.series[1]

    # Προσθήκη ενός νέου σημείου (5:2) στη σειρά του διαγράμματος.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # Προσθήκη ενός νέου σημείου (3:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # Προσθήκη ενός νέου σημείου (2:2).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # Προσθήκη ενός νέου σημείου (5:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # Αλλαγή του δείκτη (marker) της σειράς διαγράμματος.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το γράφημα Scatter](scatter_chart.png)

### **Δημιουργία Διαγραμμάτων Πίτας**

Τα διαγράμματα πίτας χρησιμοποιούνται κυρίως για να δείξουν τη σχέση μέρος‑συνολικού σε δεδομένα, ειδικά όταν τα δεδομένα περιέχουν κατηγοριοποιημένες ετικέτες με αριθμητικές τιμές. Ωστόσο, εάν τα δεδομένα σας περιέχουν πολλά μέρη ή ετικέτες, ίσως θέλετε να εξετάσετε τη χρήση ενός διαγράμματος ράβδων αντί αυτού.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.PIE` .
1. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.
1. Προσθέστε νέα σημεία στο διάγραμμα και εφαρμόστε προσαρμοσμένα χρώματα στους τομείς του διαγράμματος πίτας.
1. Ορίστε ετικέτες για τις σειρές.
1. Ενεργοποιήστε τις γραμμές οδηγούς για τις ετικέτες των σειρών.
1. Ορίστε τη γωνία περιστροφής του διαγράμματος πίτας.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα πίτας:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργία μιας στιγμής της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη διαγράμματος με τα προεπιλεγμένα δεδομένα.
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # Ορισμός τίτλου διαγράμματος.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Ορισμός της πρώτης σειράς ώστε να εμφανίζει τιμές.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος.
    worksheet_index = 0

    # Λήψη του βιβλίου εργασίας δεδομένων του διαγράμματος.
    workbook = chart.chart_data.chart_data_workbook

    # Διαγραφή των προεπιλεγμένων παραγόμενων σειρών και κατηγοριών.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Προσθήκη νέων κατηγοριών.
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # Προσθήκη νέων σειρών.
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Γέμισμα δεδομένων της σειράς.
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Ορισμός χρώματος τομέα.
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # Ορισμός περιγράμματος τομέα.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Ορισμός περιγράμματος τομέα.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Ορισμός περιγράμματος τομέα.
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # Δημιουργία προσαρμοσμένων ετικετών για κάθε κατηγορία στη νέα σειρά.
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # Ορισμός της σειράς ώστε να εμφανίζει γραμμές οδηγούς για το διάγραμμα.
    series.labels.default_data_label_format.show_leader_lines = True

    # Ορισμός γωνίας περιστροφής για τους τομείς του διαγράμματος πίτας.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Αποθήκευση της παρουσίασης στον δίσκο ως αρχείο PPTX.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το γράφημα Πίτας](pie_chart.png)

### **Δημιουργία Διαγραμμάτων Γραμμής**

Τα διαγράμματα γραμμής (γνωστά και ως line graphs) χρησιμοποιούνται καλύτερα σε καταστάσεις όπου θέλετε να δείξετε αλλαγές στην τιμή με την πάροδο του χρόνου. Με ένα διάγραμμα γραμμής, μπορείτε να συγκρίνετε μεγάλο όγκο δεδομένων ταυτόχρονα, να παρακολουθείτε αλλαγές και τάσεις στο χρόνο, να επισημάνετε ανωμαλίες σε σειρές δεδομένων και πολλά άλλα.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.LINE` .
1. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα γραμμής:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

Από προεπιλογή, τα σημεία σε ένα διάγραμμα γραμμής ενώνουν συνεχείς ευθείες γραμμές. Εάν θέλετε τα σημεία να ενώνουν παύλες, μπορείτε να ορίσετε τον προτιμώμενο τύπο παύλας ως εξής:

```python
line_chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in line_chart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```

Το αποτέλεσμα:

![Το γράφημα Γραμμής](line_chart.png)

### **Δημιουργία Διαγραμμάτων Tree Map**

Τα διαγράμματα tree map χρησιμοποιούνται καλύτερα για δεδομένα πωλήσεων όταν θέλετε να δείξετε το σχετικό μέγεθος των κατηγοριών δεδομένων και να τραβήξετε γρήγορα την προσοχή σε στοιχεία που είναι μεγάλοι συνεισφέροντες σε κάθε κατηγορία.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.TREEMAP` .
1. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα tree map:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Κλαδί 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Κλαδί 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το γράφημα Tree Map](treemap_chart.png)

### **Δημιουργία Διαγραμμάτων Stock**

Τα διαγράμματα stock χρησιμοποιούνται για την προβολή οικονομικών δεδομένων όπως τιμές ανοίγματος, υψηλής, χαμηλής και κλεισίματος, βοηθώντας στην ανάλυση τάσεων αγοράς και αστάθειας. Παρέχουν ουσιώδεις πληροφορίες για την απόδοση των μετοχών, υποστηρίζοντας επενδυτές και αναλυτές στη λήψη ενημερωμένων αποφάσεων.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.OPEN_HIGH_LOW_CLOSE` .
1. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.
1. Ορίστε τη μορφή HiLowLines.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα stock:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("StockChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το γράφημα Stock](stock_chart.png)

### **Δημιουργία Διαγραμμάτων Box and Whisker**

Τα διαγράμματα Box and Whisker χρησιμοποιούνται για την απεικόνιση της κατανομής των δεδομένων συνοψίζοντας βασικές στατιστικές μετρήσεις, όπως η διαμέση, τα τεταρτημόρια και οι πιθανές ακραίες τιμές. Είναι ιδιαίτερα χρήσιμα στην εξερευνητική ανάλυση δεδομένων και σε στατιστικές μελέτες για την γρήγορη κατανόηση της μεταβλητότητας των δεδομένων και την αναγνώριση τυχόν ανωμαλιών.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.BOX_AND_WHISKER` .
1. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα box and whisker:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```

### **Δημιουργία Διαγραμμάτων Funnel**

Τα διαγράμματα funnel χρησιμοποιούνται για την οπτικοποίηση διαδικασιών που περιλαμβάνουν διαδοχικά στάδια, όπου ο όγκος των δεδομένων μειώνεται καθώς προχωρά από το ένα βήμα στο επόμενο. Βοηθούν ιδιαίτερα στην ανάλυση των ποσοστών μετατροπής, στην εντόπιση στενοπαθήσεων και στην παρακολούθηση της αποδοτικότητας των διαδικασιών πωλήσεων ή μάρκετινγκ.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.FUNNEL` .
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα funnel:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το γράφημα Funnel](funnel_chart.png)

### **Δημιουργία Διαγραμμάτων Sunburst**

Τα διαγράμματα sunburst χρησιμοποιούνται για την οπτικοποίηση ιεραρχικών δεδομένων, εμφανίζοντας τα επίπεδα ως κυκλικές εσωτερικές ζώνες. Βοηθούν στην απεικόνιση σχέσεων μέρος‑συνολικού και είναι ιδανικά για την παρουσίαση ενσωματωμένων κατηγοριών και υποκατηγοριών με σαφή και συμπαγή μορφή.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.SUNBURST` .
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα sunburst:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Κλάδος 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Κλάδος 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το γράφημα Sunburst](sunburst_chart.png)

### **Δημιουργία Διαγραμμάτων Ιστογράμματος**

Τα διαγράμματα ιστογράμματος χρησιμοποιούνται για την αναπαράσταση της κατανομής αριθμητικών δεδομένων ομαδοποιώντας τις τιμές σε εύρη ή "bins". Είναι ιδιαίτερα χρήσιμα για την ταυτοποίηση προτύπων δεδομένων όπως συχνότητα, ασύμμετρη κατανομή και διάχυση, καθώς και για την ανίχνευση ακραίων τιμών σε ένα σύνολο.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο `ChartType.HISTOGRAM` .
1. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα ιστογράμματος:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το γράφημα Ιστογράμματος](histogram_chart.png)

### **Δημιουργία Διαγραμμάτων Radar**

Τα διαγράμματα radar χρησιμοποιούνται για την απεικόνιση πολυμεταβλητών δεδομένων σε διπλοδιάστατη μορφή, επιτρέποντας εύκολη σύγκριση πολλαπλών μεταβλητών ταυτοχρόνως. Είναι ιδιαίτερα χρήσιμα για την ταυτοποίηση προτύπων, δυνατών και αδύναμων σημείων σε πολλαπλούς δείκτες απόδοσης ή χαρακτηριστικά.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο `ChartType.RADAR` .
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα radar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarСhart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το γράφημα Radar](radar_chart.png)

### **Δημιουργία Διαγραμμάτων Multi Category**

Τα διαγράμματα Multi Category χρησιμοποιούνται για την απεικόνιση δεδομένων που περιλαμβάνουν περισσότερες από μία κατηγοριολογικές ομάδες, επιτρέποντας τη σύγκριση τιμών σε πολλαπλές διαστάσεις ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα όταν χρειάζεται να αναλύσετε τάσεις και σχέσεις σε σύνθετα, πολυεπίπεδα σύνολα δεδομένων.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.CLUSTERED_COLUMN` .
1. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα multi‑category:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # Προσθήκη σειράς.
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # Αποθήκευση της παρουσίασης με το διάγραμμα.
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το γράφημα Multi Category](multi_category_chart.png)

### **Δημιουργία Διαγραμμάτων Map**

Τα διαγράμματα map χρησιμοποιούνται για την οπτικοποίηση γεωγραφικών δεδομένων χαρτογραφώντας πληροφορίες σε συγκεκριμένες τοποθεσίες όπως χώρες, πολιτείες ή πόλεις. Είναι ιδιαίτερα χρήσιμα για την ανάλυση περιφερειακών τάσεων, δημογραφικών δεδομένων και χωρικών κατανομών με καθαρό και οπτικά ελκυστικό τρόπο.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα map:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το γράφημα Map](map_chart.png)

### **Δημιουργία Συνδυαστικών Διαγραμμάτων**

Ένα συνδυαστικό διάγραμμα (ή combo chart) συνδυάζει δύο ή περισσότερους τύπους διαγραμμάτων σε ένα μόνο γράφημα. Αυτό το διάγραμμα σας επιτρέπει να επισημάνετε, να συγκρίνετε ή να εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας σας να εντοπίσετε σχέσεις μεταξύ τους.

![Το γράφημα Combination](combination_chart.png)

Ο παρακάτω κώδικας Python δείχνει πώς να δημιουργήσετε το συνδυαστικό διάγραμμα που φαίνεται παραπάνω σε μια παρουσίαση PowerPoint:

```python
def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    # Ορισμός τίτλου διαγράμματος.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    title_paragraph = chart.chart_title.text_frame_for_overriding.paragraphs[0]
    title_format = title_paragraph.paragraph_format.default_portion_format

    title_format.font_bold = slides.NullableBool.FALSE
    title_format.font_height = 18

    # Ορισμός υπομνήματος διαγράμματος.
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    # Διαγραφή των προεπιλεγμένων παραγόμενων σειρών και κατηγοριών.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    worksheet_index = 0
    workbook = chart.chart_data.chart_data_workbook

    # Προσθήκη νέων κατηγοριών.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 4, 0, "Category 4"))

    # Προσθήκη της πρώτης σειράς.
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 4.3))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 2.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 3.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 4.5))

    return chart


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 2.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 4.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 1.8))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 2.8))


def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 1, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 2, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 3, 3, 3.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 4, 3, 5.0))

    series.plot_on_second_axis = True


def set_primary_axes_format(chart):
    # Ορισμός του οριζόντιου άξονα.
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12.0
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    # Ορισμός του κατακόρυφου άξονα.
    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12.0
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    # Ορισμός χρώματος των κύριων κατακόρυφων γραμμών πλέγματος.
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # Ορισμός του δευτερού οριζόντιου άξονα.
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # Ορισμός του δευτερού κατακόρυφου άξονα.
    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12.0
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")


def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12.0
```

## **Ενημέρωση Διαγραμμάτων**

Το Aspose.Slides for Python via .NET επιτρέπει την ενημέρωση διαγραμμάτων PowerPoint τροποποιώντας δεδομένα διαγράμματος, μορφοποίηση και στυλ. Αυτή η λειτουργία απλοποιεί τη διαδικασία διατήρησης των παρουσιάσεων ενημερωμένων με δυναμικό περιεχόμενο και διασφαλίζει ότι τα διαγράμματα αντικατοπτρίζουν ακριβώς τα τρέχοντα δεδομένα και τα οπτικά πρότυπα.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) που αντιπροσωπεύει την παρουσίαση που περιέχει ένα διάγραμμα.
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Διασχίστε όλα τα σχήματα για να εντοπίσετε το διάγραμμα.
1. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.
1. Τροποποιήστε τις σειρές δεδομένων του διαγράμματος αλλάζοντας τις τιμές τους.
1. Προσθέστε μια νέα σειρά και γεμίστε τα δεδομένα της.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να ενημερώσετε ένα διάγραμμα:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Δημιουργία μιας στιγμής της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος.
            worksheet_index = 0

            # Λήψη του βιβλίου εργασίας δεδομένων του διαγράμματος.
            workbook = chart.chart_data.chart_data_workbook

            # Αλλαγή των ονομάτων των κατηγοριών του διαγράμματος.
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # Λήψη της πρώτης σειράς του διαγράμματος.
            series = chart.chart_data.series[0]

            # Ενημέρωση των δεδομένων της σειράς.
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # Τροποποίηση του ονόματος σειράς.
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # Λήψη της δεύτερης σειράς του διαγράμματος.
            series = chart.chart_data.series[1]

            # Ενημέρωση των δεδομένων της σειράς.
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # Τροποποίηση του ονόματος σειράς.
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # Προσθήκη νέας σειράς.
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # Γέμισμα των δεδομένων της σειράς.
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # Αποθήκευση της παρουσίασης με το διάγραμμα.
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Πεδίου Δεδομένων για Διαγράμματα**

Το Aspose.Slides for Python via .NET προσφέρει την ευελιξία να ορίζετε ένα συγκεκριμένο εύρος δεδομένων από ένα φύλο εργασίας ως πηγή για τα δεδομένα του διαγράμματος. Αυτό σημαίνει ότι μπορείτε άμεσα να χαρτογραφήσετε ένα τμήμα του φύλλου σας στο διάγραμμα, ελέγχοντας ποιές κελιά συνεισφέρουν στις σειρές και τις κατηγορίες του διαγράμματος. Ως αποτέλεσμα, μπορείτε εύκολα να ενημερώνετε και να συγχρονίζετε τα διαγράμματα σας με τις τελευταίες αλλαγές στα δεδομένα του φύλλου, διασφαλίζοντας ότι οι παρουσιάσεις PowerPoint εμφανίζουν ακριβείς και ενημερωμένες πληροφορίες.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) που αντιπροσωπεύει την παρουσίαση που περιέχει ένα διάγραμμα.
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Διασχίστε όλα τα σχήματα για να εντοπίσετε το διάγραμμα.
1. Πρόσβαση στα δεδομένα του διαγράμματος και ορισμός του εύρους.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε το εύρος δεδομένων για ένα διάγραμμα:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Δημιουργία μιας στιγμής της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **Χρήση Προεπιλεγμένων Δεικτών σε Διαγράμματα**

Όταν χρησιμοποιείτε προεπιλεγμένους δείκτες σε διαγράμματα, κάθε σειρά διαγράμματος λαμβάνει αυτόματα διαφορετικό προεπιλεγμένο σύμβολο δείκτη.

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε αυτόματα έναν δείκτη σειράς διαγράμματος:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # Συμπλήρωση δεδομένων σειράς.
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Τι τύποι διαγραμμάτων υποστηρίζει το Aspose.Slides for Python via .NET;**

Το Aspose.Slides for Python via .NET υποστηρίζει μια ευρεία γκάμα τύπων διαγραμμάτων, συμπεριλαμβανομένων των μπαρ, γραμμής, πίτας, περιοχής, scatter, ιστογράμματος, radar και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο διάγραμμα για τις ανάγκες οπτικοποίησης των δεδομένων σας.

**Πώς προσθέτω ένα νέο διάγραμμα σε μια διαφάνεια;**

Για να προσθέσετε ένα διάγραμμα, αρχικά δημιουργείτε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) , ανακτήσετε τη διαφάνεια που επιθυμείτε χρησιμοποιώντας το δείκτη της και, στη συνέχεια, καλέστε τη μέθοδο για την προσθήκη διαγράμματος, καθορίζοντας τον τύπο διαγράμματος και τα αρχικά δεδομένα. Αυτή η διαδικασία ενσωματώνει το διάγραμμα απευθείας στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που εμφανίζονται σε ένα διάγραμμα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός διαγράμματος προσπελάζοντας το βιβλίο εργασίας δεδομένων του ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/)), καθαρίζοντας τυχόν προεπιλεγμένες σειρές και κατηγορίες και, στη συνέχεια, προσθέτοντας τα προσαρμοσμένα σας δεδομένα. Αυτό σας επιτρέπει να ανανεώνετε προγραμματιστικά το διάγραμμα ώστε να αντανακλά τα τελευταία δεδομένα.

**Μπορεί να προσαρμοστεί η εμφάνιση του διαγράμματος;**

Ναι, το Aspose.Slides for Python via .NET παρέχει εκτενείς επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπομνήματα και άλλα στοιχεία μορφοποίησης ώστε να προσαρμόσετε την εμφάνιση του διαγράμματος στις συγκεκριμένες απαιτήσεις σχεδίασής σας.