---
title: Δημιουργία ή Ενημέρωση Διαγραμμάτων Παρουσίασης PowerPoint σε Python
linktitle: Δημιουργία ή Ενημέρωση Διαγραμμάτων
type: docs
weight: 10
url: /el/python-net/create-chart/
keywords:
- προσθήκη διαγράμματος
- δημιουργία διαγράμματος
- επεξεργασία διαγράμματος
- αλλαγή διαγράμματος
- ενημέρωση διαγράμματος
- διάγραμμα διασποράς
- διάγραμμα πίτας
- γραμμικό διάγραμμα
- διάγραμμα δένδρου χάρτη
- χρηματιστηριακό διάγραμμα
- διάγραμμα κουτιού‑καρπού
- διάγραμμα χωνίου
- ηλιακό διάγραμμα
- ιστόγραμμα
- ραδιογραφικό διάγραμμα
- πολυκατηγορικό διάγραμμα
- παρουσίαση PowerPoint
- Python
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides for Python via .NET. Καλύπτει την προσθήκη, τη μορφοποίηση και την επεξεργασία διαγραμμάτων σε παρουσιάσεις με πρακτικά παραδείγματα κώδικα σε Python."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα χρησιμοποιώντας το Aspose.Slides for Python via .NET. Θα μάθετε πώς να προσθέσετε ένα διάγραμμα σε μια διαφάνεια, να το γεμίσετε με δεδομένα και να το μορφοποιήσετε ώστε να ταιριάζει στις απαιτήσεις σχεδίασής σας. Τα παραδείγματα κώδικα καλύπτουν τη δημιουργία παρουσιάσεων και διαγραμμάτων, τη διαμόρφωση σειρών, αξόνων και υπομνήματος, καθώς και την ενσωμάτωση δημιουργίας διαγραμμάτων στις εφαρμογές σας.

## **Δημιουργία Διαγράμματος**

Τα διαγράμματα βοηθούν τους ανθρώπους να οπτικοποιούν γρήγορα τα δεδομένα και να εξάγουν συμπεράσματα που ίσως να μην είναι άμεσα εμφανή από έναν πίνακα ή υπολογιστικό φύλλο.

**Γιατί να δημιουργήσετε διαγράμματα;**

Με τα διαγράμματα μπορείτε:

* να συγκεντρώσετε, συμπιέσετε ή συνοψίσετε μεγάλες ποσότητες δεδομένων σε μία διαφάνεια μιας παρουσίασης·  
* να αποκαλύψετε μοτίβα και τάσεις στα δεδομένα·  
* να καταλάβετε την κατεύθυνση και την ορμή των δεδομένων στον χρόνο ή σε σχέση με μια συγκεκριμένη μονάδα μέτρησης·  
* να εντοπίσετε αποκλίσεις, ανωμαλίες, σφάλματα και άσυλα δεδομένα·  
* να επικοινωνήσετε ή να παρουσιάσετε σύνθετα δεδομένα.

Στο PowerPoint μπορείτε να δημιουργήσετε διαγράμματα μέσω της λειτουργίας *Insert*, η οποία προσφέρει πρότυπα για τη σχεδίαση πολλών τύπων διαγραμμάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε τόσο κανονικά διαγράμματα (βάσει δημοφιλών τύπων) όσο και προσαρμοσμένα διαγράμματα.

{{% alert color="info" title="Σημείωση" %}}

Χρησιμοποιήστε την απαρίθμηση [ChartType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/charttype/) στο namespace [Aspose.Slides.Charts](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/). Οι τιμές σε αυτήν την απαρίθμηση αντιστοιχούν σε διαφορετικούς τύπους διαγραμμάτων.

{{% /alert %}}

### **Δημιουργία Στοιχισμένων Γραμμικών Στηλών**

Αυτή η ενότητα εξηγεί πώς να δημιουργήσετε στοιχισμένα γραμμικά στήλες χρησιμοποιώντας το Aspose.Slides for Python via .NET. Θα μάθετε πώς να αρχικοποιήσετε μια παρουσίαση, να προσθέσετε ένα διάγραμμα και να προσαρμόσετε τα στοιχεία του όπως τίτλο, δεδομένα, σειρές, κατηγορίες και στυλ. Ακολουθήστε τα παρακάτω βήματα για να δείτε πώς δημιουργείται ένα τυπικό στοιχισμένο διάγραμμα στήλης:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).  
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας τον δείκτη της.  
1. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο `ChartType.CLUSTERED_COLUMN`.  
1. Προσθέστε τίτλο στο διάγραμμα.  
1. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.  
1. Καθαρίστε όλες τις προεπιλεγμένες σειρές και κατηγορίες.  
1. Προσθέστε νέες σειρές και κατηγορίες.  
1. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.  
1. Εφαρμόστε χρώμα γεμίσματος στις σειρές.  
1. Προσθέστε ετικέτες στις σειρές.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα στοιχισμένο διάγραμμα στήλης:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη στοιχισμένου διαγράμματος στήλης με τα προεπιλεγμένα δεδομένα.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Ορισμός του τίτλου του διαγράμματος.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος.
    worksheet_index = 0

    # Λήψη του βιβλίου εργασίας δεδομένων του διαγράμματος.
    workbook = chart.chart_data.chart_data_workbook

    # Διαγραφή των προεπιλεγμένων σειρών και κατηγοριών.
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

    # Συμπλήρωση των δεδομένων της σειράς.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Ορισμός του χρώματος γεμίσματος για τη σειρά.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Λήψη της δεύτερης σειράς του διαγράμματος.
    series = chart.chart_data.series[1]

    # Συμπλήρωση των δεδομένων της σειράς.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # Ορισμός του χρώματος γεμίσματος για τη σειρά.
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
                
    # Αποθήκευση της παρουσίασης στο δίσκο ως αρχείο PPTX.
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The clustered column chart](clustered_column_chart.png)

### **Δημιουργία Διάγραμμα Διασποράς**

Τα διαγράμματα διασποράς (γνωστά και ως scatter plots ή γραφήματα x‑y) χρησιμοποιούνται συχνά για τον έλεγχο μοτίβων ή την επίδειξη συσχετίσεων μεταξύ δύο μεταβλητών.

Χρησιμοποιήστε διάγραμμα διασποράς όταν:

* Διαθέτετε ζευγαρωμένα αριθμητικά δεδομένα.  
* Έχετε δύο μεταβλητές που συνδυάζονται καλά.  
* Θέλετε να προσδιορίσετε εάν οι δύο μεταβλητές σχετίζονται.  
* Έχετε μια ανεξάρτητη μεταβλητή με πολλαπλές τιμές για μια εξαρτημένη μεταβλητή.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα διασποράς με διαφορετικούς δείκτες για κάθε σειρά:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε την κλάση Presentation.
with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Δημιουργία του προεπιλεγμένου διαγράμματος διασποράς.
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

    # Προσθήκη νέου σημείου (1:3) στη σειρά.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # Προσθήκη νέου σημείου (2:10).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # Αλλαγή τύπου σειράς.
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Αλλαγή δείκτη σειράς διαγράμματος.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # Λήψη της δεύτερης σειράς του διαγράμματος.
    series = chart.chart_data.series[1]

    # Προσθήκη νέου σημείου (5:2) στη σειρά διαγράμματος.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # Προσθήκη νέου σημείου (3:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # Προσθήκη νέου σημείου (2:2).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # Προσθήκη νέου σημείου (5:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # Αλλαγή δείκτη σειράς διαγράμματος.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The scatter chart](scatter_chart.png)

### **Δημιουργία Πίτας**

Τα διαγράμματα πίτας είναι ιδανικά για την εμφάνιση της σχέσης μέρος‑στο‑σύνολο στα δεδομένα, ειδικά όταν τα δεδομένα περιέχουν κατηγορηματικές ετικέτες με αριθμητικές τιμές. Ωστόσο, αν τα δεδομένα σας περιέχουν πολλά μέρη ή ετικέτες, ίσως προτιμήσετε ένα διάγραμμα ράβδων.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).  
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας τον δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.PIE`.  
1. Πρόσβαση στο φύλλο εργασίας δεδομένων του διαγράμματος ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.  
1. Προσθέστε νέες σειρές και κατηγορίες.  
1. Προσθέστε νέα δεδομένα για τις σειρές.  
1. Προσθέστε νέες περιοχές στο διάγραμμα και εφαρμόστε προσαρμοσμένα χρώματα στους τομείς της πίτας.  
1. Ορίστε ετικέτες για τις σειρές.  
1. Ενεργοποιήστε τις γραμμές οδηγούς (leader lines) για τις ετικέτες σειρών.  
1. Ορίστε τη γωνία περιστροφής για το διάγραμμα πίτας.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα πίτας:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη διαγράμματος με τα προεπιλεγμένα δεδομένα.
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # Ορισμός του τίτλου του διαγράμματος.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος.
    worksheet_index = 0

    # Λήψη του βιβλίου εργασίας δεδομένων του διαγράμματος.
    workbook = chart.chart_data.chart_data_workbook

    # Διαγραφή των προεπιλεγμένων σειρών και κατηγοριών.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Προσθήκη νέων κατηγοριών.
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # Προσθήκη νέας σειράς.
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Συμπλήρωση των δεδομένων της σειράς.
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Ορισμός του χρώματος του τομέα.
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # Ορισμός του περιγράμματος του τομέα.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Ορισμός του περιγράμματος του τομέα.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Ορισμός του περιγράμματος του τομέα.
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

    # Ορισμός της γωνίας περιστροφής για τους τομείς του διαγράμματος πίτας.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Αποθήκευση της παρουσίασης στο δίσκο ως αρχείο PPTX.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The pie chart](pie_chart.png)

### **Δημιουργία Γραμμικού Διαγράμματος**

Τα γραμμικά διαγράμματα (γνωστά και ως line graphs) είναι ιδανικά όταν θέλετε να παρουσιάσετε αλλαγές σε τιμές με την πάροδο του χρόνου. Με ένα γραμμικό διάγραμμα, μπορείτε να συγκρίνετε μεγάλο όγκο δεδομένων ταυτόχρονα, να παρακολουθείτε αλλαγές και τάσεις, να τονίζετε ανωμαλίες στις σειρές κ.ά.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).  
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας τον δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.LINE`.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα γραμμικό διάγραμμα:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

Από προεπιλογή, τα σημεία σε ένα γραμμικό διάγραμμα συνδέονται με συνεχείς ευθείες γραμμές. Αν θέλετε τα σημεία να συνδέονται με παύλες, μπορείτε να ορίσετε τον τύπο παύλας ως εξής:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH

    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The line chart](line_chart.png)

### **Δημιουργία Διάγραμματος Δέντρο‑Χάρτη**

Τα διαγράμματα δέντρο‑χάρτη είναι ιδανικά για δεδομένα πωλήσεων όταν θέλετε να δείξετε το σχετικό μέγεθος των κατηγοριών και να εστιάσετε σε στοιχεία που συμβάλλουν σημαντικά σε κάθε κατηγορία.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).  
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας τον δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.TREEMAP`.  
1. Πρόσβαση στο φύλλο εργασίας δεδομένων του διαγράμματος ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.  
1. Προσθέστε νέες σειρές και κατηγορίες.  
1. Προσθέστε νέα δεδομένα για τις σειρές.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα δέντρο‑χάρτη:

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

![The treemap chart](treemap_chart.png)

### **Δημιουργία Χρηματιστηριακού Διαγράμματος**

Τα χρηματιστηριακά διαγράμματα χρησιμοποιούνται για την εμφάνιση οικονομικών δεδομένων όπως τιμές ανοίγματος, υψηλές, χαμηλές και κλεισίματος, βοηθώντας στην ανάλυση τάσεων αγοράς και μεταβλητότητας. Παρέχουν ουσιώδεις πληροφορίες για την απόδοση μετοχών, βοηθώντας επενδυτές και αναλυτές να λαμβάνουν ενημερωμένες αποφάσεις.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).  
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας τον δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.OPEN_HIGH_LOW_CLOSE`.  
1. Πρόσβαση στο φύλλο εργασίας δεδομένων του διαγράμματος ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.  
1. Προσθέστε νέες σειρές και κατηγορίες.  
1. Προσθέστε νέα δεδομένα για τις σειρές.  
1. Ορίστε τη μορφή των γραμμών υψηλής‑χαμηλής τιμής.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα χρηματιστηριακό διάγραμμα:

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

![The stock chart](stock_chart.png)

### **Δημιουργία Διαγράμματος Κουτιού‑Καρπού**

Τα διαγράμματα κουτιού‑καρπού χρησιμοποιούνται για την παρουσίαση της κατανομής δεδομένων συνοψίζοντας βασικά στατιστικά μέτρα, όπως η διάμεσος, τα τεταρτημόρια και τυχόν εξωτερικές τιμές. Είναι ιδιαίτερα χρήσιμα στην εξερευνητική ανάλυση δεδομένων και σε στατιστικές μελέτες για γρήγορη κατανόηση της διασποράς και την ανίχνευση ανωμαλιών.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).  
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας τον δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.BOX_AND_WHISKER`.  
1. Πρόσβαση στο φύλλο εργασίας δεδομένων του διαγράμματος ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.  
1. Προσθέστε νέες σειρές και κατηγορίες.  
1. Προσθέστε νέα δεδομένα για τις σειρές.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα κουτιού‑καρπού:

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

### **Δημιουργία Διάγραμμα Χωνιού**

Τα διαγράμματα χωνίου χρησιμοποιούνται για την οπτικοποίηση διαδικασιών που περιλαμβάνουν διαδοχικά στάδια, όπου ο όγκος των δεδομένων μειώνεται καθώς προχωρά από το ένα βήμα στο επόμενο. Είναι ιδιαίτερα χρήσιμα για την ανάλυση ποσοστών μετατροπής, τον εντοπισμό bottleneck και την παρακολούθηση της αποδοτικότητας διαδικασιών πωλήσεων ή μάρκετινγκ.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).  
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας τον δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.FUNNEL`.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα χωνίου:

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

![The funnel chart](funnel_chart.png)

### **Δημιουργία Ηλιακού Διάγραμμα (Sunburst)**

Τα ηλιακά διαγράμματα χρησιμοποιούνται για την οπτικοποίηση ιεραρχικών δεδομένων, εμφανίζοντας τα επίπεδα ως συγκεντρικούς δακτυλίους. Βοηθούν στην απεικόνιση σχέσεων μέρος‑στο‑σύνολο και είναι ιδανικά για την παρουσίαση ένθετων κατηγοριών και υποκατηγοριών με σαφή, συμπαγή μορφή.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).  
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας τον δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.SUNBURST`.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα ηλιακό διάγραμμα:

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

![The sunburst chart](sunburst_chart.png)

### **Δημιουργία Ιστόγραμμα**

Τα ιστόγραμμα χρησιμοποιούνται για την αναπαράσταση της κατανομής αριθμητικών δεδομένων, ομαδοποιώντας τις τιμές σε εύρη ή “κτίβες”. Είναι ιδιαίτερα χρήσιμα για την αναγνώριση προτύπων όπως συχνότητα, σκλισμό και διάσπαση, καθώς και για την εντολή εξωτερικών τιμών σε ένα σύνολο δεδομένων.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).  
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας τον δείκτη της.  
1. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο `ChartType.HISTOGRAM`.  
1. Πρόσβαση στο φύλλο εργασίας δεδομένων του διαγράμματος ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.  
1. Προσθέστε μια νέα σειρά και γεμίστε την με σημεία δεδομένων. Ένα ιστόγραμμα δεν έχει κατηγορίες· οι κτίβοι υπολογίζονται από τις τιμές.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα ιστόγραμμα:

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

![The histogram chart](histogram_chart.png)

### **Δημιουργία Ραδιογραφικού (Radar) Διαγράμματος**

Τα ραδιογραφικά διαγράμματα χρησιμοποιούνται για την παρουσίαση πολυμεταβλητών δεδομένων σε δισδιάστατη μορφή, επιτρέποντας εύκολη σύγκριση πολλών μεταβλητών ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα για την αναγνώριση προτύπων, δυνάμεων και αδυναμιών σε πολλαπλούς δείκτες ή χαρακτηριστικά.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).  
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας τον δείκτη της.  
1. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο `ChartType.RADAR`.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα ραδιογραφικό διάγραμμα:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The radar chart](radar_chart.png)

### **Δημιουργία Πολυ‑Κατηγορικών Διαγραμμάτων**

Τα πολυ‑κατηγορικά διαγράμματα χρησιμοποιούνται για την παρουσίαση δεδομένων που περιλαμβάνουν περισσότερες από μία κατηγορηματικές ομαδοποιήσεις, επιτρέποντας τη σύγκριση τιμών σε πολλαπλές διαστάσεις ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα όταν χρειάζεται να αναλύσετε τάσεις και σχέσεις σε σύνθετα, πολυεπίπεδα σύνολα δεδομένων.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).  
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας τον δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.CLUSTERED_COLUMN`.  
1. Πρόσβαση στο φύλλο εργασίας δεδομένων του διαγράμματος ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.  
1. Προσθέστε νέες σειρές και κατηγορίες.  
1. Προσθέστε νέα δεδομένα για τις σειρές.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα πολυ‑κατηγορικό διάγραμμα:

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

![The multi-category chart](multi_category_chart.png)

### **Δημιουργία Χάρτη**

Τα διαγράμματα χάρτη χρησιμοποιούνται για την οπτικοποίηση γεωγραφικών δεδομένων χαρτογραφώντας πληροφορίες σε συγκεκριμένες τοποθεσίες όπως χώρες, πολιτείες ή πόλεις. Είναι ιδιαίτερα χρήσιμα για την ανάλυση περιφερειακών τάσεων, δημογραφικών δεδομένων και χωρικής κατανομής με σαφή και ελκυστική οπτική παρουσίαση.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα χάρτη:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The map chart](map_chart.png)

### **Δημιουργία Συνδυαστικών Διαγραμμάτων**

Ένα συνδυαστικό διάγραμμα (ή combo chart) συνδυάζει δύο ή περισσότερους τύπους διαγραμμάτων σε ένα γράφημα. Αυτό το διάγραμμα σας επιτρέπει να τονίσετε, συγκρίνετε ή εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας στην αναγνώριση σχέσεων μεταξύ τους.

![The combination chart](combination_chart.png)

Ο παρακάτω κώδικας Python δείχνει πώς να δημιουργήσετε το συνδυαστικό διάγραμμα που φαίνεται παραπάνω σε μια παρουσίαση PowerPoint:

```python
import aspose.slides.charts as charts
import aspose.pydrawing as draw
import aspose.slides as slides

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

    # Ορισμός του τίτλου του διαγράμματος.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    title_paragraph = chart.chart_title.text_frame_for_overriding.paragraphs[0]
    title_format = title_paragraph.paragraph_format.default_portion_format

    title_format.font_bold = slides.NullableBool.FALSE
    title_format.font_height = 18

    # Ορισμός του υπομνήματος του διαγράμματος.
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    # Διαγραφή των προεπιλεγμένων σειρών και κατηγοριών.
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

    # Ορισμός του κάθετου άξονα.
    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12.0
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    # Ορισμός του χρώματος των κύριων γραμμών πλέγματος του κάθετου άξονα.
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # Ορισμός του δευτερεύοντος οριζόντιου άξονα.
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # Ορισμός του δευτερεύοντος κάθετου άξονα.
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

Το Aspose.Slides for Python via .NET σάς επιτρέπει να ενημερώνετε τα δεδομένα, τη μορφοποίηση και το στυλ των διαγραμμάτων ώστε να διατηρείτε τις παρουσιάσεις PowerPoint ενημερωμένες.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για να ανοίξετε την παρουσίαση που περιέχει το διάγραμμα.  
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας τον δείκτη της.  
1. Περιηγηθείτε σε όλα τα σχήματα για να βρείτε το διάγραμμα.  
1. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.  
1. Τροποποιήστε τις σειρές δεδομένων του διαγράμματος αλλάζοντας τις τιμές τους.  
1. Προσθέστε μια νέα σειρά και γεμίστε την με δεδομένα.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να ενημερώσετε ένα διάγραμμα:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
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
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # Τροποποίηση του ονόματος της σειράς.
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # Λήψη της δεύτερης σειράς του διαγράμματος.
            series = chart.chart_data.series[1]

            # Ενημέρωση των δεδομένων της σειράς.
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # Τροποποίηση του ονόματος της σειράς.
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # Προσθήκη μιας νέας σειράς.
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # Συμπλήρωση των δεδομένων της σειράς.
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # Αποθήκευση της παρουσίασης με το διάγραμμα.
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Περιοχής Δεδομένων για Διάγραμμα**

Το Aspose.Slides for Python via .NET σάς επιτρέπει να χρησιμοποιήσετε μια συγκεκριμένη περιοχή φύλλου εργασίας ως πηγή δεδομένων για ένα διάγραμμα. Αυτό ελέγχει ποιες κελιά τροφοδοτούν τις σειρές και τις κατηγορίες του διαγράμματος και σας επιτρέπει να ενημερώνετε το διάγραμμα ώστε να αντανακλά αλλαγές στο φύλλο εργασίας.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για να ανοίξετε την παρουσίαση που περιέχει το διάγραμμα.  
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας τον δείκτη της.  
1. Περιηγηθείτε σε όλα τα σχήματα για να βρείτε το διάγραμμα.  
1. Πρόσβαση στα δεδομένα του διαγράμματος και ορίστε την περιοχή.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε την περιοχή δεδομένων για ένα διάγραμμα:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
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

Όταν χρησιμοποιείτε προεπιλεγμένους δείκτες σε διαγράμματα, κάθε σειρά διαγράμματος λαμβάνει αυτόματα διαφορετικό σύμβολο δείκτη.

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε αυτόματα δείκτη σειράς διαγράμματος:

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

    # Συμπλήρωση των δεδομένων της σειράς.
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις (FAQ)**

**Ποιοι τύποι διαγραμμάτων υποστηρίζονται από το Aspose.Slides for Python via .NET;**

Το Aspose.Slides for Python via .NET υποστηρίζει ευρύ φάσμα τύπων διαγραμμάτων, συμπεριλαμβανομένων των ράβδων, γραμμών, πίτας, περιοχής, διασποράς, ιστόγραμματος, ραδιογραφικού και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο για τις ανάγκες οπτικοποίησης των δεδομένων σας.

**Πώς προσθέτω νέο διάγραμμα σε μια διαφάνεια;**

Για να προσθέσετε διάγραμμα, πρώτα δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/), ανακτήστε τη διαφάνεια που θέλετε χρησιμοποιώντας τον δείκτη της και, στη συνέχεια, καλέστε τη μέθοδο για προσθήκη διαγράμματος, καθορίζοντας τον τύπο διαγράμματος και τα αρχικά δεδομένα. Αυτή η διαδικασία ενσωματώνει το διάγραμμα απευθείας στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που εμφανίζονται σε ένα διάγραμμα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός διαγράμματος αποκτώντας πρόσβαση στο βιβλίο εργασίας δεδομένων του ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/)), καθαρίζοντας τυχόν προεπιλεγμένες σειρές και κατηγορίες και, στη συνέχεια, προσθέτοντας τα δικά σας προσαρμοσμένα δεδομένα. Αυτό επιτρέπει την προγραμματιστική ανανέωση του διαγράμματος ώστε να αντανακλά τις πιο πρόσφατες πληροφορίες.

**Μπορώ να προσαρμόσω την εμφάνιση του διαγράμματος;**

Ναι, το Aspose.Slides for Python via .NET παρέχει εκτεταμένες δυνατότητες προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπομνήματα και άλλα στοιχεία μορφοποίησης ώστε να προσαρμόσετε την εμφάνιση του διαγράμματος στις συγκεκριμένες απαιτήσεις σχεδίασής σας.