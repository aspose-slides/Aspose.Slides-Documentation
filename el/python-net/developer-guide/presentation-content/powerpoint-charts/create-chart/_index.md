---
title: Δημιουργία ή ενημέρωση διαγραμμάτων παρουσίασης PowerPoint σε Python
linktitle: Δημιουργία ή ενημέρωση διαγραμμάτων
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
- διάγραμμα γραμμής
- διάγραμμα χάρτη δένδρου
- διάγραμμα μετοχών
- διάγραμμα box και whisker
- διάγραμμα χωνιού
- διάγραμμα ηλιακού εκτυφωτισμού
- διάγραμμα ιστόγραμμα
- διάγραμμα ραντάρ
- διάγραμμα πολλαπλών κατηγοριών
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides for Python via .NET. Προσθέστε, μορφοποιήστε και επεξεργαστείτε διαγράμματα με πρακτικά παραδείγματα κώδικα σε Python."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργήσετε και να προσαρμόσετε διαγράμματα χρησιμοποιώντας το Aspose.Slides for Python via .NET. Θα μάθετε πώς να προσθέτετε προγραμματιστικά ένα γράφημα σε μια διαφάνεια, να το γεμίζετε με δεδομένα και να εφαρμόζετε διάφορες επιλογές μορφοποίησης ώστε να ταιριάζει στις ειδικές σας απαιτήσεις σχεδίασης. Σε όλο το άρθρο, λεπτομερή παραδείγματα κώδικα δείχνουν κάθε βήμα, από την αρχικοποίηση της παρουσίασης και του αντικειμένου γραφήματος μέχρι τη διαμόρφωση σειρών, αξόνων και υπομνήματος. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε σταθερή κατανόηση του πώς να ενσωματώσετε δυναμική δημιουργία γραφημάτων στις εφαρμογές Python, βελτιώνοντας τη διαδικασία δημιουργίας παρουσιάσεων βασισμένων σε δεδομένα.

## **Δημιουργία διαγράμματος**

Τα διαγράμματα βοηθούν τους ανθρώπους να οπτικοποιούν γρήγορα τα δεδομένα και να αποκτούν διορατικότητα που μπορεί να μην είναι άμεσα εμφανής από έναν πίνακα ή λογιστικό φύλλο.

**Γιατί να δημιουργήσετε διαγράμματα;**

Χρησιμοποιώντας διαγράμματα, μπορείτε:

* να συγκεντρώσετε, συμπτύξετε ή συνοψίσετε μεγάλες ποσότητες δεδομένων σε μία διαφάνειά της παρουσίασης·
* να αποκαλύψετε μοτίβα και τάσεις στα δεδομένα·
* να καταλάβετε την κατεύθυνση και την ορμή των δεδομένων με την πάροδο του χρόνου ή ως προς μια συγκεκριμένη μονάδα μέτρησης·
* να εντοπίσετε ακραίες τιμές, αποκλίσεις, σφάλματα και μη λογικά δεδομένα·
* να επικοινωνήσετε ή να παρουσιάσετε σύνθετα δεδομένα.

Στο PowerPoint, μπορείτε να δημιουργήσετε διαγράμματα μέσω της λειτουργίας *Insert*, η οποία προσφέρει πρότυπα για το σχεδιασμό πολλών τύπων διαγραμμάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε τόσο κανονικά διαγράμματα (βασισμένα σε δημοφιλείς τύπους) όσο και προσαρμοσμένα διαγράμματα.

{{% alert color="info" title="Note" %}}
Χρησιμοποιήστε την [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) κατάταξη μέσα στο [aspose.slides.charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/) module. Οι τιμές σε αυτήν την κατάταξη αντιστοιχούν σε διαφορετικούς τύπους διαγραμμάτων.
{{% /alert %}}

### **Δημιουργία διαγραμμάτων ομαδοποιημένων στηλών**

Αυτό το παράδειγμα χρησιμοποιεί το [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) για να δημιουργήσει ένα γράφημα ομαδοποιημένων στηλών που συγκρίνει δύο σειρές σε τρεις κατηγορίες. Οι σειρές χρησιμοποιούν κόκκινη και πράσινη γέμιση, και τα ατομικά ετικέτες εμφανίζουν τα ονόματα κατηγοριών, τα ονόματα σειρών και τις τιμές. Ο δείκτης φύλλου εργασίας 0 αναφέρεται στο πρώτο φύλλο του ενσωματωμένου βιβλίου γραφημάτων.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    chart.chart_data.series.add(series_name_cell, chart.type)
    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    chart.chart_data.series.add(series_name_cell, chart.type)

    category_cell = workbook.get_cell(worksheet_index, 1, 0, "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 2, 0, "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 3, 0, "Category 3")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series[0]

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 20)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 50)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 30)
    series.data_points.add_data_point_for_bar_series(value_cell)

    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    series = chart.chart_data.series[1]

    value_cell = workbook.get_cell(worksheet_index, 1, 2, 30)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 2, 10)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 2, 60)
    series.data_points.add_data_point_for_bar_series(value_cell)

    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Διάγραμμα ομαδοποιημένων στηλών](clustered_column_chart.png)

### **Δημιουργία διαγραμμάτων διασποράς**

Τα διαγράμματα διασποράς (γνωστά επίσης ως διαγράμματα scatter ή γραφήματα x‑y) χρησιμοποιούνται συχνά για να ελέγξουν μοτίβα ή να δείξουν συσχετισμούς μεταξύ δύο μεταβλητών.

Χρησιμοποιήστε διάγραμμα διασποράς όταν:

* Διαθέτετε ζευγαρωμένα αριθμητικά δεδομένα·
* Έχετε δύο μεταβλητές που ταιριάζουν καλά μεταξύ τους·
* Θέλετε να προσδιορίσετε εάν οι δύο μεταβλητές σχετίζονται·
* Διαθέτετε ανεξάρτητη μεταβλητή με πολλαπλές τιμές για μια εξαρτημένη μεταβλητή.

Αυτό το παράδειγμα σχεδιάζει δύο σύνολα τιμών x‑y. Η πρώτη σειρά χρησιμοποιεί ευθείες γραμμές με δείκτες σε σχήμα αστεριού, ενώ η δεύτερη χρησιμοποιεί ομαλές γραμμές με δείκτες σε σχήμα κύκλου· και οι δύο χρησιμοποιούν ένα [size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/size/) των 10. Η ιδιότητα [symbol](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/symbol/) ελέγχει το σχήμα του δείκτη.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()

    series_name_cell = workbook.get_cell(worksheet_index, 1, 1, "Series 1")
    chart.chart_data.series.add(series_name_cell, chart.type)
    series_name_cell = workbook.get_cell(worksheet_index, 1, 3, "Series 2")
    chart.chart_data.series.add(series_name_cell, chart.type)

    series = chart.chart_data.series[0]

    x_value_cell = workbook.get_cell(worksheet_index, 2, 1, 1)
    y_value_cell = workbook.get_cell(worksheet_index, 2, 2, 3)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 3, 1, 2)
    y_value_cell = workbook.get_cell(worksheet_index, 3, 2, 10)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    series = chart.chart_data.series[1]

    x_value_cell = workbook.get_cell(worksheet_index, 2, 3, 5)
    y_value_cell = workbook.get_cell(worksheet_index, 2, 4, 2)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 3, 3, 3)
    y_value_cell = workbook.get_cell(worksheet_index, 3, 4, 1)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 4, 3, 2)
    y_value_cell = workbook.get_cell(worksheet_index, 4, 4, 2)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 5, 3, 5)
    y_value_cell = workbook.get_cell(worksheet_index, 5, 4, 1)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Διάγραμμα διασποράς](scatter_chart.png)

### **Δημιουργία διαγραμμάτων πίτας**

Τα διαγράμματα πίτας είναι ιδανικά για να δείξουν τη σχέση μέρος‑προς‑ολό στην δεδομένα, ειδικά όταν τα δεδομένα περιέχουν κατηγορηματικές ετικέτες με αριθμητικές τιμές. Ωστόσο, εάν τα δεδομένα σας περιέχουν πολλά τμήματα ή ετικέτες, ίσως θέλετε να εξετάσετε τη χρήση γραφήματος ράβδου αντί αυτού.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα πίτας με τρεις τριμηνιαίες τιμές. Κάθε τομή έχει προσαρμοσμένη γέμιση και περιθώριο, και οι ετικέτες εμφανίζουν διαφορετικούς συνδυασμούς τιμών, ποσοστών και πληροφοριών σειράς. Η ιδιότητα [first_slice_angle](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/first_slice_angle/) ορίζει την πρώτη τομή να αρχίζει στις 180 μοίρες.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    category_cell = workbook.get_cell(0, 1, 0, "1st Qtr")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 2, 0, "2nd Qtr")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 3, 0, "3rd Qtr")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 20)
    series.data_points.add_data_point_for_pie_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 50)
    series.data_points.add_data_point_for_pie_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 30)
    series.data_points.add_data_point_for_pie_series(value_cell)

    chart.chart_data.series_groups[0].is_color_varied = True

    first_slice = series.data_points[0]
    first_slice.format.fill.fill_type = slides.FillType.SOLID
    first_slice.format.fill.solid_fill_color.color = draw.Color.cyan

    first_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    first_slice.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    first_slice.format.line.width = 3.0
    first_slice.format.line.style = slides.LineStyle.THIN_THICK
    first_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH

    second_slice = series.data_points[1]
    second_slice.format.fill.fill_type = slides.FillType.SOLID
    second_slice.format.fill.solid_fill_color.color = draw.Color.brown

    second_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    second_slice.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    second_slice.format.line.width = 3.0
    second_slice.format.line.style = slides.LineStyle.SINGLE
    second_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    third_slice = series.data_points[2]
    third_slice.format.fill.fill_type = slides.FillType.SOLID
    third_slice.format.fill.solid_fill_color.color = draw.Color.coral

    third_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    third_slice.format.line.fill_format.solid_fill_color.color = draw.Color.red
    third_slice.format.line.width = 2.0
    third_slice.format.line.style = slides.LineStyle.THIN_THIN
    third_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    first_label = series.data_points[0].label
    first_label.data_label_format.show_value = True

    second_label = series.data_points[1].label
    second_label.data_label_format.show_value = True
    second_label.data_label_format.show_legend_key = True
    second_label.data_label_format.show_percentage = True

    third_label = series.data_points[2].label
    third_label.data_label_format.show_series_name = True
    third_label.data_label_format.show_percentage = True

    series.labels.default_data_label_format.show_leader_lines = True

    chart.chart_data.series_groups[0].first_slice_angle = 180

    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Διάγραμμα πίτας](pie_chart.png)

Για να βελτιώσετε την αναγνωσιμότητα των ετικετών εκτός της πίτας, δείτε το [Format Leader Lines](/slides/el/python-net/chart-data-label/#format-leader-lines) για ένα παράδειγμα που τοποθετεί τις ετικέτες και προσαρμόζει το χρώμα, το πλάτος, τη διαφάνεια και το στυλ διακεκομμένων γραμμών.

### **Δημιουργία διαγραμμάτων γραμμής**

Τα διαγράμματα γραμμής (γνωστά επίσης ως γραφήματα γραμμών) είναι ιδανικά σε καταστάσεις όπου θέλετε να δείξετε αλλαγές τιμών με την πάροδο του χρόνου. Χρησιμοποιώντας ένα γράφημα γραμμής, μπορείτε να συγκρίνετε μεγάλο όγκο δεδομένων ταυτόχρονα, να παρακολουθείτε αλλαγές και τάσεις με την πάροδο του χρόνου, να επισημάνετε ανωμαλίες σε σειρές δεδομένων και πολλά άλλα.

Αυτό το παράδειγμα χρησιμοποιεί το [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) για να δημιουργήσει ένα γράφημα γραμμής με τις προεπιλεγμένες σειρές και κατηγορίες, και στη συνέχεια αποθηκεύει την παρουσίαση ως PPTX.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    presentation.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

Από προεπιλογή, τα σημεία σε ένα γράφημα γραμμής ενώνουνται με ευθείες συνεχείς γραμμές. Εάν θέλετε τα σημεία να ενώνουν με παύλες, ορίστε την ιδιότητα [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) σε μια τιμή από το [LineDashStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/):

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH
```

Το αποτέλεσμα:

![Διάγραμμα γραμμής](line_chart.png)

### **Δημιουργία διαγραμμάτων δένδρου (Tree Map)**

Τα διαγράμματα δένδρου είναι ιδανικά για δεδομένα πωλήσεων όταν θέλετε να δείξετε το σχετικό μέγεθος των κατηγοριών δεδομένων και να τραβήξετε γρήγορα την προσοχή σε στοιχεία που συνεισφέρουν σημαντικά μέσα σε κάθε κατηγορία.

Αυτό το παράδειγμα δημιουργεί ένα δένδρο με οκτώ φύλλα ομαδοποιημένα σε τέσσερις κορμούς και δύο κλαδιά. Η μέθοδος [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) αντιστοιχίζει τους κορμούς στο επίπεδο ομαδοποίησης 1 και τα κλαδιά στο επίπεδο 2. Οι τιμές καθορίζουν το σχετικό μέγεθος των ορθογωνίων, ενώ οι ετικέτες κατηγορίας και οι επικαλυπτόμενες γονικές ετικέτες προσδιορίζουν την ιεραρχία.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Κλαδί 1
    category_cell = workbook.get_cell(0, "C1", "Leaf1")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    category_cell = workbook.get_cell(0, "C2", "Leaf2")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C3", "Leaf3")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    category_cell = workbook.get_cell(0, "C4", "Leaf4")
    chart.chart_data.categories.add(category_cell)

    # Κλαδί 2
    category_cell = workbook.get_cell(0, "C5", "Leaf5")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    category_cell = workbook.get_cell(0, "C6", "Leaf6")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C7", "Leaf7")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    category_cell = workbook.get_cell(0, "C8", "Leaf8")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    value_cell = workbook.get_cell(0, "D1", 4)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D2", 5)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D3", 3)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D4", 6)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D5", 9)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D6", 9)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D7", 4)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D8", 3)
    series.data_points.add_data_point_for_treemap_series(value_cell)

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("Treemap.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Διάγραμμα δένδρου](treemap_chart.png)

### **Δημιουργία διαγραμμάτων καταρράκτη (Waterfall)**

Ένα διάγραμμα καταρράκτη δείχνει πώς οι θετικές και αρνητικές αλλαγές συμβάλλουν στην τελική τιμή. Για παράδειγμα, η ανάλυση κέρδους μπορεί να ξεκινά με έσοδα, να αφαιρεί τα κόστη και να προσθέτει άλλα έσοδα. Οι στήλες αλλαγής αιωρούνται μεταξύ της προηγούμενης και της νέας τρεχούσας τιμής, ενώ οι στήλες συνόλου εκτείνονται από το μηδέν μέχρι την συσσωρευμένη τιμή.

Το παρακάτω παράδειγμα χρησιμοποιεί ποσά σε χιλιάδες δολάρια ΗΠΑ:

| Κατηγορία | Τιμή βιβλίου εργασίας | Τύπος στήλης |
| --- | ---: | --- |
| Έσοδα | 1000 | Αύξηση |
| Κόστος πώλησης | -400 | Μείωση |
| Ακαθάριστο κέρδος | 600 | Ενδιάμεσο σύνολο |
| Λειτουργικά έξοδα | -200 | Μείωση |
| Άλλα έσοδα | 50 | Αύξηση |
| Καθαρό κέρδος | 450 | Τελικό σύνολο |

Για να σημειώσετε ένα σημείο ως ενδιάμεσο ή τελικό σύνολο, ορίστε την ιδιότητά του [set_as_total](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/set_as_total/) σε `True`. Παρέχετε το πραγματικό συσσωρευμένο ποσό στο κελί του βιβλίου εργασίας: `600` για το ακαθάριστο κέρδος (`1000 - 400`) και `450` για το καθαρό κέρδος (`600 - 200 + 50`). Η ιδιότητα σηματοδοτεί τη στήλη ως σύνολο· δεν υπολογίζει ή γεμίζει την τιμή του κελιού. Μην χρησιμοποιείτε το μηδέν ως κράτημα ή προσθέτετε άλλη αλλαγή για σημείο συνόλου. Μια στήλη συνόλου εμφανίζει την συσσωρευμένη τιμή χωρίς να την προσθέτει ξανά στην τρέχουσα τιμή.

Αυτό το πλήρες παράδειγμα C# δημιουργεί ένα γράφημα χρησιμοποιώντας το μέλος `Waterfall` του [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/), καθαρίζει τα προεπιλεγμένα δεδομένα και γεμίζει το ενσωματωμένο βιβλίο εργασίας. Ο δείκτης φύλλου `0` επιλέγει το πρώτο φύλλο; η στήλη A περιέχει ονόματα κατηγοριών και η στήλη B τιμές. Κάθε κελί τιμής προστίθεται με το [add_data_point_for_waterfall_series](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/add_data_point_for_waterfall_series/). Οι μηδενικοί δείκτες σημείων `2` και `5` εντοπίζουν τα ενδιάμεσα και τα τελικά σύνολα. Η ενεργοποίηση του [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) εμφανίζει τα ποσά στις στήλες. Δεν απαιτείται εισαγωγική παρουσίαση ή βιβλίο εργασίας.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.WATERFALL, 20, 20, 680, 200)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Profit breakdown (USD thousands)")
    chart.chart_title.overlay = False
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    workbook.clear(worksheet_index)

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Profit")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.WATERFALL)
    categories = ["Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit"]
    values = [1000, -400, 600, -200, 50, 450]

    for i in range(len(categories)):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, categories[i])
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_waterfall_series(value_cell)

    # Το τρίτο και το έκτο σημείο αντιπροσωπεύουν σύνολα, όχι επιπλέον αλλαγές.
    series.data_points[2].set_as_total = True
    series.data_points[5].set_as_total = True
    series.show_connector_lines = True
    series.labels.default_data_label_format.show_value = True

    presentation.save("WaterfallChart.pptx", slides.export.SaveFormat.PPTX)
```

Ορίστε την ιδιότητα σειράς‑επίπεδου [show_connector_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/show_connector_lines/) σε `True` για να δείξετε γραμμές που συνδέουν διαδοχικές στήλες και να κάνετε πιο εύκολη την παρακολούθηση της τρέχουσας τιμής. Για απόκρυψη αυτών των γραμμών, αντικαταστήστε την ανάθεση στο παράδειγμα με `series.show_connector_lines = False` πριν αποθηκεύσετε. Αυτό αλλάζει μόνο την ορατότητα των γραμμών, όχι τα δεδομένα ή τα σύνολα.

Η αποθηκευμένη παρουσίαση δείχνει ακαθάριστο κέρδος 600 και καθαρό κέρδος 450, με και τα δύο σύνολα να ξεκινούν από το μηδέν:

![Διάγραμμα καταρράκτη με έσοδα, κόστη, ακαθάριστο κέρδος 600 και καθαρό κέρδος 450, με ετικέτες τιμών και γραμμές σύνδεσης](waterfall_chart.png)

### **Δημιουργία διαγραμμάτων μετοχών (Stock)**

Τα διαγράμματα μετοχών χρησιμοποιούνται για την παρουσίαση χρηματοοικονομικών δεδομένων όπως τιμές ανοχής, υψηλής, χαμηλής και κλεισίματος, βοηθώντας στην ανάλυση των τάσεων της αγοράς και της μεταβλητότητας. Προσφέρουν κρίσιμες πληροφορίες για την απόδοση των μετοχών, βοηθώντας επενδυτές και αναλυτές να λαμβάνουν τεκμηριωμένες αποφάσεις.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα ανοίγματος‑υψηλής‑χαμηλής‑κλεισίματος με τέσσερις σειρές με αυτή τη σειρά και τρεις κατηγορίες. Η ιδιότητα [has_up_down_bars](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/has_up_down_bars/) ενεργοποιεί τις μπάρες ανοδικής/πτώσης, και η [hi_low_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/hi_low_lines_format/) ελέγχει τις γραμμές υψηλής‑χαμηλής που δείχνουν το εύρος τιμών, ενώ οι ατομικές γραμμές σειρών και οι μικρές οριζόντιες γραμμές πλέγματος είναι κρυμμένες.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    workbook = chart.chart_data.chart_data_workbook

    category_cell = workbook.get_cell(0, 1, 0, "A")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 2, 0, "B")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 3, 0, "C")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, 0, 1, "Open")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 2, "High")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 3, "Low")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 4, "Close")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)

    series = chart.chart_data.series[0]
    value_cell = workbook.get_cell(0, 1, 1, 72)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 1, 25)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 1, 38)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[1]
    value_cell = workbook.get_cell(0, 1, 2, 172)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 2, 57)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 2, 57)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[2]
    value_cell = workbook.get_cell(0, 1, 3, 12)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 3, 12)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 3, 13)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[3]
    value_cell = workbook.get_cell(0, 1, 4, 25)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 4, 38)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 4, 50)
    series.data_points.add_data_point_for_stock_series(value_cell)

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for stock_series in chart.chart_data.series:
        stock_series.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("Stock-chart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Διάγραμμα μετοχών](stock_chart.png)

### **Δημιουργία διαγραμμάτων box και whisker**

Τα διαγράμματα box και whisker χρησιμοποιούνται για την παρουσίαση της κατανομής των δεδομένων συνοψίζοντας βασικά στατιστικά μέτρα, όπως η διάμεσος, τα τεταρτημόρια και οι πιθανοί εκτός ορίου τιμές. Είναι ιδιαίτερα χρήσιμα στην εξερευνητική ανάλυση δεδομένων και σε στατιστικές μελέτες για γρήγορη κατανόηση της μεταβλητότητας και τον εντοπισμό τυχόν ανωμαλιών.

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα box και whisker από έξι τιμές. Η ιδιότητα [quartile_method](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/quartile_method/) επιλέγει τον αποκλειστικό υπολογισμό τεταρτημορίων. Το παράδειγμα ενεργοποιεί επίσης τις γραμμές μέσου, τους δείκτες μέσου, τα εσωτερικά σημεία και τα σημεία εκτός ορίου.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A1", "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A2", "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A3", "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A4", "Category 4")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A5", "Category 5")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A6", "Category 6")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    value_cell = workbook.get_cell(0, "B1", 15)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B2", 41)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B3", 16)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B4", 10)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B5", 23)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B6", 16)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)

    presentation.save("BoxAndWhisker.pptx", slides.export.SaveFormat.PPTX)
```

### **Δημιουργία διαγραμμάτων χωνίου (Funnel)**

Τα διαγράμματα χωνίου χρησιμοποιούνται για την απεικόνιση διαδικασιών που περιλαμβάνουν διαδοχικά στάδια, όπου ο όγκος των δεδομένων μειώνεται καθώς προχωρά από το ένα βήμα στο επόμενο. Είναι ιδιαίτερα χρήσιμα για την ανάλυση ποσοστών μετατροπής, τον εντοπισμό “στενών σημείων” και την παρακολούθηση της αποδοτικότητας διαδικασιών πώλησης ή μάρκετινγκ.

Αυτό το παράδειγμα χρησιμοποιεί το [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) για να προσθέσει ένα γράφημα χωνίου στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Αντικαθιστά τα προεπιλεγμένα δεδομένα με έξι κατηγορίες και τιμές που κυμαίνονται από 50 έως 500, στη συνέχεια αποθηκεύει την ενημερωμένη παρουσίαση. Η εισαγόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A1", "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A2", "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A3", "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A4", "Category 4")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A5", "Category 5")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A6", "Category 6")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    value_cell = workbook.get_cell(0, "B1", 50)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B2", 100)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B3", 200)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B4", 300)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B5", 400)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B6", 500)
    series.data_points.add_data_point_for_funnel_series(value_cell)

    presentation.save("Funnel.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Διάγραμμα χωνίου](funnel_chart.png)

### **Δημιουργία διαγραμμάτων ηλιακού εκτυφωτισμού (Sunburst)**

Τα διαγράμματα ηλιακού εκτυφωτισμού (sunburst) χρησιμοποιούνται για την απεικόνιση ιεραρχικών δεδομένων, εμφανίζοντας επίπεδα ως κυκλικούς δακτύλιους. Βοηθούν στην απεικόνιση σχέσεων μέρος‑προς‑ολό και είναι ιδανικά για την παρουσίαση ενσωματωμένων κατηγοριών και υπο‑κατηγοριών με σαφή και συμπαγή μορφή.

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα ηλιακού εκτυφωτισμού με οκτώ φύλλα ομαδοποιημένα σε τέσσερις κορμούς και δύο κλαδιά. Η μέθοδος [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) αντιστοιχίζει τους κορμούς στο επίπεδο ομαδοποίησης 1 και τα κλαδιά στο επίπεδο 2. Οι ετικέτες κατηγορίας προσδιορίζουν τα τμήματα, και οι τιμές καθορίζουν τα σχετικά μεγέθη τους.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Κλαδί 1
    category_cell = workbook.get_cell(0, "C1", "Leaf1")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    category_cell = workbook.get_cell(0, "C2", "Leaf2")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C3", "Leaf3")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    category_cell = workbook.get_cell(0, "C4", "Leaf4")
    chart.chart_data.categories.add(category_cell)

    # Κλαδί 2
    category_cell = workbook.get_cell(0, "C5", "Leaf5")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    category_cell = workbook.get_cell(0, "C6", "Leaf6")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C7", "Leaf7")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    category_cell = workbook.get_cell(0, "C8", "Leaf8")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    value_cell = workbook.get_cell(0, "D1", 4)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D2", 5)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D3", 3)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D4", 6)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D5", 9)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D6", 9)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D7", 4)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D8", 3)
    series.data_points.add_data_point_for_sunburst_series(value_cell)

    presentation.save("Sunburst.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Διάγραμμα ηλιακού εκτυφωτισμού](sunburst_chart.png)

### **Δημιουργία διαγραμμάτων ιστόγραμμα (Histogram)**

Τα διαγράμματα ιστόγραμμα δείχνουν πώς οι αριθμητικές τιμές διανέμονται σε διαστήματα (bins). Για μηνιαίες αναφορές χρόνων επεξεργασίας παραγγελιών, χρησιμοποιήστε το ίδιο πλάτος bin και τα ίδια όρια ώστε τα διαστήματα να παραμένουν συνεπή και οι κατανομές εύκολα συγκρίσιμες.

Ορίστε τον οριζόντιο άξονα [aggregation_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/aggregation_type/) σε μια λειτουργία από το [AxisAggregationType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axisaggregationtype/). Η [bin_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/bin_width/) ισχύει μόνο για `BY_BIN_WIDTH`; η [number_of_bins](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_of_bins/) ισχύει μόνο για `BY_NUMBER_OF_BINS`. Χρησιμοποιήστε `AUTOMATIC` για να επιτρέψετε στο γράφημα να επιλέξει τα bins.

#### **Χρήση σταθερού πλάτους bin**

Αυτό το παράδειγμα ομαδοποιεί χρόνους επεξεργασίας σε διαστήματα 10 λεπτών, με ξεχωριστά bins για χρόνους ≤ 10 λεπτών και > 40 λεπτά. Ενεργοποιήστε αυτά τα bins με τις [is_underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_underflow_bin/) και [is_overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_overflow_bin/). Όταν παρέχετε ρητές τιμές για [underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/underflow_bin/) και [overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/overflow_bin/), ορίστε τις [is_automatic_underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_underflow_bin/) και [is_automatic_overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_overflow_bin/) σε `False`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 680, 200)

    chart.has_legend = False
    chart.has_title = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.get_cell(0, i, 0, value)
        series.data_points.add_data_point_for_histogram_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.aggregation_type = charts.AxisAggregationType.BY_BIN_WIDTH
    axis.bin_width = 10
    axis.is_underflow_bin = True
    axis.is_automatic_underflow_bin = False
    axis.underflow_bin = 10
    axis.is_overflow_bin = True
    axis.is_automatic_overflow_bin = False
    axis.overflow_bin = 40

    presentation.save("Histogram-bin-width.pptx", slides.export.SaveFormat.PPTX)
```

Η παρουσίαση που εμφανίζεται στο PowerPoint δείχνει αριθμούς bins **3, 4, 4, 4, και 2**. Το bin υποροής περιλαμβάνει `5, 10, 10`, έτσι το όριο του είναι αποκλειστικό. Το bin υπερροής περιλαμβάνει μόνο `41, 50`, ώστε το όριό του να είναι αποκλειστικό· και οι τιμές ίσες με `40` παραμένουν στο προηγούμενο διάστημα. Τα εσωτερικά bins περιέχουν τιμές μεγαλύτερες από το κατώτερο όριο και μικρότερες ή ίσες με το ανώτερο όριο.

![Ιστόγραμμα με bins 10‑λεπτών και σαφείς όρια υποροής και υπερροής](histogram_bin_width.png)

#### **Καθορισμός αριθμού bins**

Για σταθερό επίπεδο λεπτομέρειας αντί για σταθερά διαστήματα, ζητήστε πέντε bins για τα ίδια δεδομένα. Αυτό το παράδειγμα αφήνει τα bins υποροής και υπερροής απενεργοποιημένα. Το γράφημα καθορίζει το πλάτος από το εύρος των δεδομένων, έτσι τα όρια μπορούν να αλλάξουν μεταξύ των αναφορών.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 680, 200)

    chart.has_legend = False
    chart.has_title = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.get_cell(0, i, 0, value)
        series.data_points.add_data_point_for_histogram_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.aggregation_type = charts.AxisAggregationType.BY_NUMBER_OF_BINS
    axis.number_of_bins = 5

    presentation.save("Histogram-bin-count.pptx", slides.export.SaveFormat.PPTX)
```

Τα πέντε bins έχουν αριθμούς **4, 4, 4, 4, και 1**. Συγκρίνετε αυτήν την κατανομή με το αποτέλεσμα σταθερού πλάτους παραπάνω: τα εισαγόμενα δεδομένα είναι τα ίδια, αλλά τα όρια διαφέρουν.

![Ιστόγραμμα με πέντε bins υπολογισμένα από τα ίδια δεδομένα](histogram_bin_count.png)

### **Δημιουργία διαγραμμάτων ραδιοσυχνότητας (Radar)**

Τα διαγράμματα ραδιοσυχνότητας (radar) χρησιμοποιούνται για την εμφάνιση πολυμεταβλητών δεδομένων σε δισδιάστατη μορφή, επιτρέποντας εύκολη σύγκριση πολλαπλών μεταβλητών ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα για την αναγνώριση προτύπων, δυνάμεων και αδυναμιών σε πολλαπλές μετρήσεις απόδοσης ή χαρακτηριστικά.

Αυτό το παράδειγμα χρησιμοποιεί το [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) για να δημιουργήσει ένα γράφημα radar με τις προεπιλεγμένες σειρές και κατηγορίες, και στη συνέχεια αποθηκεύει την παρουσίαση ως PPTX.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_chart(charts.ChartType.RADAR, 20, 20, 500, 300)

    presentation.save("Radar-chart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Διάγραμμα radar](radar_chart.png)

### **Δημιουργία διαγραμμάτων πολλαπλών κατηγοριών**

Τα διαγράμματα πολλαπλών κατηγοριών χρησιμοποιούνται για την παρουσίαση δεδομένων που περιλαμβάνουν περισσότερες από μία ομαδοποιήσεις, επιτρέποντας τη σύγκριση τιμών σε πολλαπλές διαστάσεις ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα όταν χρειάζεται να αναλύσετε τάσεις και σχέσεις σε σύνθετα, πολυεπίπεδα σύνολα δεδομένων.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα ομαδοποιημένων στηλών με οκτώ κατηγορίες διατεταγμένες σε τέσσερα ζεύγη. Η μέθοδος [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) δίνει σε κάθε ζεύγος μια κοινή ετικέτα στο επίπεδο ομαδοποίησης 1, δημιουργώντας έναν άξονα κατηγορίας με ατομικές και ομαδικές ετικέτες.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category_cell = workbook.get_cell(0, "c2", "A")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group1")
    category_cell = workbook.get_cell(0, "c3", "B")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c4", "C")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group2")
    category_cell = workbook.get_cell(0, "c5", "D")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c6", "E")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group3")
    category_cell = workbook.get_cell(0, "c7", "F")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c8", "G")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group4")
    category_cell = workbook.get_cell(0, "c9", "H")
    category = chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, "D1", "Series 1")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    value_cell = workbook.get_cell(worksheet_index, "D2", 10)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D3", 20)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D4", 30)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D5", 40)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D6", 50)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D7", 60)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D8", 70)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D9", 80)
    series.data_points.add_data_point_for_bar_series(value_cell)

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Διάγραμμα πολλαπλών κατηγοριών](multi_category_chart.png)

### **Δημιουργία διαγραμμάτων χάρτη (Map)**

Τα διαγράμματα χάρτη χρησιμοποιούνται για την απεικόνιση γεωγραφικών δεδομένων χαρτογραφώντας πληροφορίες σε συγκεκριμένες τοποθεσίες όπως χώρες, πολιτείες ή πόλεις. Είναι ιδιαίτερα χρήσιμα για την ανάλυση περιφερειακών τάσεων, δημογραφικών δεδομένων και χωρικών κατανομών με σαφή και ελκυστική οπτική παρουσίαση.

Αυτό το παράδειγμα χρησιμοποιεί το [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) για να δημιουργήσει ένα γράφημα χάρτη με τα προεπιλεγμένα γεωγραφικά δεδομένα και το αποθηκεύει για προβολή στο PowerPoint.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.MAP, 20, 20, 500, 300)

    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Διάγραμμα χάρτη](map_chart.png)

{{% alert color="info" title="Note" %}}
Η παραπάνω εικόνα δείχνει την αποθηκευμένη παρουσίαση ανοιγμένη στο PowerPoint. Το Aspose.Slides γράφει σωστά το διάγραμμα χάρτη και τα δεδομένα του, αλλά δεν σχεδιάζει τα διαγράμματα χάρτη αυτόματα: όταν μια διαφάνεια που περιέχει ένα τέτοιο διάγραμμα αποδίδεται ως εικόνα ή μετατρέπεται σε PDF ή SVG, η περιοχή του διαγράμματος εμφανίζεται κενή. Τα άλλα σχήματα στην ίδια διαφάνεια παραμένουν ακατάληπτα.
{{% /alert %}}

### **Δημιουργία συνδυασμένων διαγραμμάτων**

Ένα συνδυαστικό διάγραμμα (ή combo) συνδυάζει δύο ή περισσότερους τύπους διαγραμμάτων σε ένα γράφημα. Αυτό το γράφημα σας επιτρέπει να φωτίζετε, να συγκρίνετε ή να εξετάζετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας στην αναγνώριση σχέσεων μεταξύ τους.

![Συνδυαστικό διάγραμμα](combination_chart.png)

Αυτό το παράδειγμα συνδυάζει δύο σειρές ομαδοποιημένων στηλών με μια σειρά γραμμής σε τέσσερις κατηγορίες. Οι στήλες χρησιμοποιούν τον κύριο κατακόρυφο άξονα, ενώ το [plot_on_second_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/plot_on_second_axis/) τοποθετεί τη γραμμή σε δευτερεύοντα κατακόρυφο άξονα στα δεξιά. Οι βοηθητικές λειτουργίες ρυθμίζουν τον τίτλο, την υπομνήμη, τις ετικέτες άξονα και τις γραμμές πλέγματος.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

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

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    portion_format = chart.chart_title.text_frame_for_overriding.paragraphs[0].paragraph_format.default_portion_format
    portion_format.font_bold = slides.NullableBool.FALSE
    portion_format.font_height = 18

    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    category_cell = workbook.get_cell(worksheet_index, 1, 0, "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 2, 0, "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 3, 0, "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 4, 0, "Category 4")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 4.3)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 2.5)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 3.5)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 1, 4.5)
    series.data_points.add_data_point_for_bar_series(value_cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    value_cell = workbook.get_cell(worksheet_index, 1, 2, 2.4)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 2, 4.4)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 2, 1.8)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 2, 2.8)
    series.data_points.add_data_point_for_bar_series(value_cell)

def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    value_cell = workbook.get_cell(worksheet_index, 1, 3, 2.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 3, 2.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 3, 3.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 3, 5.0)
    series.data_points.add_data_point_for_line_series(value_cell)

    series.plot_on_second_axis = True

def set_primary_axes_format(chart):
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)

def set_secondary_axes_format(chart):
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12


create_combo_chart()
```

## **Ενημέρωση διαγραμμάτων**

Το Aspose.Slides for Python via .NET σας επιτρέπει να ενημερώσετε διαγράμματα PowerPoint τροποποιώντας δεδομένα γραφήματος, μορφοποίηση και στυλ. Αυτή η λειτουργικότητα απλοποιεί τη διαδικασία διατήρησης των παρουσιάσεων ενημερωμένων με δυναμικό περιεχόμενο και διασφαλίζει ότι τα διαγράμματα αντανακλούν ακριβώς τα τρέχοντα δεδομένα και τα οπτικά πρότυπα.

Αυτό το παράδειγμα ενημερώνει το γράφημα με όνομα "My chart" στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Απαιτεί δύο σειρές στήλης με τρία σημεία δεδομένων η κάθε μία, με ετικέτες κατηγοριών στη στήλη A και ονόματα σειρών στην πρώτη σειρά του πρώτου φύλλου εργασίας. Το παράδειγμα χρησιμοποιεί το [get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) για να αλλάξει τα κελιά του βιβλίου εργασίας, ενημερώνει τις τιμές των σειρών, προσθέτει τρίτη σειρά και αλλάζει το γράφημα σε ομαδοποιημένους κυλίνδρους μέσω του [type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/type/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

chart_name = "My chart"

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            worksheet_index = 0

            workbook = chart.chart_data.chart_data_workbook

            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            series = chart.chart_data.series[0]

            workbook.get_cell(worksheet_index, 0, 1, "New_Series 1")
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            series = chart.chart_data.series[1]

            workbook.get_cell(worksheet_index, 0, 2, "New_Series 2")
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
            series = chart.chart_data.series.add(series_name_cell, chart.type)

            value_cell = workbook.get_cell(worksheet_index, 1, 3, 20)
            series.data_points.add_data_point_for_bar_series(value_cell)
            value_cell = workbook.get_cell(worksheet_index, 2, 3, 50)
            series.data_points.add_data_point_for_bar_series(value_cell)
            value_cell = workbook.get_cell(worksheet_index, 3, 3, 30)
            series.data_points.add_data_point_for_bar_series(value_cell)

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

    presentation.save("AsposeChartModified.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός περιοχής δεδομένων για ένα γράφημα**

Για να ελέγξετε την περιοχή που χρησιμοποιείται ήδη από ένα υπάρχον γράφημα, δείτε το [Retrieve a Chart's Data Range](/slides/el/python-net/chart-workbook/#retrieve-a-charts-data-range).

Το Aspose.Slides for Python via .NET παρέχει την ευελιξία να ορίσετε μια συγκεκριμένη περιοχή δεδομένων από ένα φύλλο εργασίας ως πηγή για τα δεδομένα του γραφήματός σας. Αυτό σημαίνει ότι μπορείτε άμεσα να αντιστοιχίσετε ένα μέρος του φύλλου εργασίας στο γράφημα, ελέγχοντας ποια κελιά συνεισφέρουν στις σειρές και τις κατηγορίες του γραφήματος. Έτσι, μπορείτε εύκολα να ενημερώνετε και να συγχρονίζετε τα διαγράμματά σας με τις τελευταίες αλλαγές δεδομένων στο φύλλο εργασίας, διασφαλίζοντας ότι οι παρουσιάσεις PowerPoint αντανακλούν ακριβείς και ενημερωμένες πληροφορίες.

Αυτό το παράδειγμα χρησιμοποιεί το [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) για να ορίσει την πηγή δεδομένων του γραφήματος με όνομα "My chart" στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης σε `Sheet1!A1:B4`. Το βιβλίο εργασίας του γραφήματος πρέπει να περιέχει αυτό το φύλλο και μια πληθωρισμένη περιοχή με επικεφαλίδα σειράς στην πρώτη γραμμή, ετικέτες κατηγοριών στη στήλη A και τρεις τιμές στη στήλη B.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

chart_name = "My chart"

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("SetDataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **Χρήση προεπιλεγμένων δεικτών σε διαγράμματα**

Όταν χρησιμοποιείτε προεπιλεγμένους δείκτες σε διαγράμματα, κάθε σειρά γραφήματος λαμβάνει αυτόματα διαφορετικό προεπιλεγμένο σύμβολο δεικτή.

Αυτό το παράδειγμα χρησιμοποιεί το [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) για να δημιουργήσει ένα γράφημα με δύο σειρές γραμμής και μια υπομνήμη. Οι ρυθμίσεις [marker](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/marker/) διατηρούν τα αυτόματα εκχωρημένα σύμβολα δεικτών. Η πρώτη σειρά περιλαμβάνει μια αρνητική τιμή και μια ελλιπή τιμή, που αντιπροσωπεύεται από `None`, ενώ η δεύτερη έχει τιμή για κάθε κατηγορία.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series_name_cell = workbook.get_cell(0, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    category_cell = workbook.get_cell(0, 1, 0, "C1")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 1, 1, 24)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 2, 0, "C2")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 2, 1, 23)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 3, 0, "C3")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 3, 1, -10)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 4, 0, "C4")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 4, 1, None)
    series.data_points.add_data_point_for_line_series(value_cell)

    series_name_cell = workbook.get_cell(0, 0, 2, "Series 2")
    second_series = chart.chart_data.series.add(series_name_cell, chart.type)

    value_cell = workbook.get_cell(0, 1, 2, 30)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 2, 10)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 2, 60)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 4, 2, 40)
    second_series.data_points.add_data_point_for_line_series(value_cell)

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές ερωτήσεις (FAQ)**

**Ποιοι τύποι διαγραμμάτων υποστηρίζονται από το Aspose.Slides for Python via .NET;**

Το Aspose.Slides for Python via .NET υποστηρίζει μια ευρεία γκάμα τύπων διαγραμμάτων, συμπεριλαμβανομένων ράβδων, γραμμών, πίτας, περιοχής, διασποράς, ιστόγραμματος, radar και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο διαγράμματος για τις ανάγκες οπτικοποίησης των δεδομένων σας.

**Πώς προσθέτω νέο γράφημα σε μια διαφάνεια;**

Για να προσθέσετε ένα γράφημα, πρώτα δημιουργείτε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), ανακτάτε τη διαφάνεια με τον δείκτη της και, στη συνέχεια, καλείτε τη μέθοδο για προσθήκη γραφήματος, καθορίζοντας τον τύπο γραφήματος και τα αρχικά δεδομένα. Αυτή η διαδικασία ενσωματώνει το γράφημα απευθείας στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που εμφανίζονται σε ένα γράφημα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός γραφήματος αποκτώντας πρόσβαση στο βιβλίο δεδομένων του ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)), καθαρίζοντας τυχόν προεπιλεγμένες σειρές και κατηγορίες, και προσθέτοντας τα προσαρμοσμένα σας δεδομένα. Αυτό σας επιτρέπει να επαναφορτώνετε προγραμματιστικά το γράφημα ώστε να αντικατοπτρίζει τα πιο πρόσφατα δεδομένα.

**Μπορώ να προσαρμόσω την εμφάνιση του γραφήματος;**

Ναι, το Aspose.Slides for Python via .NET παρέχει εκτενείς επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπομνήμες και άλλα στοιχεία μορφοποίησης για να ταιριάξετε την εμφάνιση του γραφήματος με τις συγκεκριμένες απαιτήσεις του σχεδίου σας.