---
title: Προσαρμογή αξόνων διαγράμματος σε παρουσιάσεις με Python
linktitle: Άξονας διαγράμματος
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
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides για Python μέσω .NET για να προσαρμόσετε τους άξονες διαγραμμάτων σε παρουσιάσεις PowerPoint και OpenDocument για αναφορές και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τους άξονες των διαγραμμάτων με το Aspose.Slides για Python μέσω .NET. Καλύπτει υπολογισμένες τιμές άξονα, εναλλαγή γραμμών και στηλών διαγράμματος, ορατότητα άξονα, διαστήματα ετικετών κατηγορίας και σημείων κεντημάτων, κατηγορίες ημερομηνίας και μορφοποίηση, περιστροφή τίτλου, θέση άξονα, μονάδες εμφάνισης και λογαριθμική κλίμακα.

## **Λήψη των μέγιστων τιμών στον κατακόρυφο άξονα σε διαγράμματα**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) και προσθέστε ένα διάγραμμα περιοχής με προεπιλεγμένα δεδομένα. Καλέστε το [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) πριν διαβάσετε τις υπολογισμένες τιμές άξονα ώστε η διάταξη του διαγράμματος να είναι ενημερωμένη.

Διαβάστε τα [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) και [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) για τα όρια του άξονα, καθώς και τα [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) και [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) για τα διαστήματα των σημείων κεντημάτων. Τα [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) και [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) παρέχουν κλίμακες μονάδων χρόνου, οι οποίες είναι σχετικές με τους άξονες ημερομηνίας. Το παράδειγμα αποθηκεύει αυτές τις τιμές σε τοπικές μεταβλητές και αποθηκεύει το διάγραμμα.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ανταλλαγή των δεδομένων μεταξύ αξόνων**

Χρησιμοποιήστε το [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) για να ανταλλάξετε τους ρόλους των σειρών και των κατηγοριών στα δεδομένα του διαγράμματος. Κάθε πρώην κατηγορία γίνεται σειρά, και κάθε πρώην σειρά γίνεται κατηγορία. Αυτό αλλάζει τον τρόπο ομαδοποίησης των δεδομένων· δεν ανταλλάσσει τους οριζόντιους και κατακόρυφους άξονες. Το παράδειγμα χρησιμοποιεί το [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) για να συνδέσει τα προεπιλεγμένα δεδομένα με το `Sheet1!A1:D5`, περιλαμβάνοντας τη γραμμή κεφαλίδας και τη στήλη κατηγορίας, πριν την εναλλαγή γραμμών και στηλών. Αποθηκεύει ένα διάγραμμα με τέσσερις σειρές και τρεις κατηγορίες.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Αντίστροφη σειρά σχεδίασης ενός άξονα**

Χρησιμοποιήστε το [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) για να αντιστρέψετε έναν άξονα κατηγορίας ή τιμής. Για παράδειγμα, ένα οριζόντιο ραβδόγραμμα μπορεί να εμφανίζει τα στάδια ενός έργου από πάνω προς τα κάτω με την ίδια σειρά όπως το φύλλο εργασίας: Σχεδιασμός, Ανάπτυξη, Δοκιμή. Η αντιστροφή ενός άξονα αλλάζει την κατεύθυνση σχεδίασης· δεν ταξινομεί ή αναδιατάσσει τα δεδομένα του βιβλίου εργασίας. Σε σύγκριση, το [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) ανταλλάσσει τους ρόλους των σειρών και των κατηγοριών.

Το ακόλουθο παράδειγμα δημιουργεί ένα οριζόντιο ραβδόγραμμα με τρία στάδια και μία σειρά. Αποθηκεύει μια παρουσίαση με τρία διαφάνειες: κανονική σειρά, αντιστροφή κατηγοριών και αντιστροφή τιμών. Κάθε αντίγραφο χρησιμοποιεί το ίδιο σύνολο δεδομένων, και μόνο ένας άξονας αντιστρέφεται σε κάθε αντίγραφο.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # Διαφάνεια 2: εμφάνιση της πρώτης κατηγορίας στην κορυφή.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # Διατήρηση του οριζόντιου άξονα τιμών στο κάτω μέρος.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Διαφάνεια 3: αντίστροφη μόνο της οριζόντιας αριθμητικής κλίμακας.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Η αντιστροφή ενός άξονα μπορεί επίσης να μετακινήσει τον κάθετο άξονα στην αντίθετη πλευρά του διαγράμματος. Η ιδιότητα [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) ελέγχει πού διασχίζει ο άλλος άξονας τον άξονα που ρυθμίζεται. Στη διαφάνεια 2, η ρύθμιση του σε `MAXIMUM` στον αντιστραμμένο άξονα κατηγορίας διατηρεί τον οριζόντιο άξονα τιμής στο κάτω μέρος. Για συγκεκριμένο σημείο διασχίσεων, χρησιμοποιήστε το [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Ελέγξτε τις ρυθμίσεις διασχίσεων όταν αλλάζετε κατεύθυνση, ειδικά αν το διάγραμμα έχει ήδη προσαρμοσμένο σημείο διασχίσεων. Ορίστε το `is_plot_order_reversed` ξανά σε `False` για να επαναφέρετε την κανονική κατεύθυνση σχεδίασης· οι ρυθμίσεις διασχίσεων είναι ξεχωριστές.

| Κανονική σειρά (διαφ. 1) | Αντίστροφες κατηγορίες (διαφ. 2) | Αντίστροφες τιμές (διαφ. 3) |
| --- | --- | --- |
| ![Οριζόντιο ραβδόγραμμα με κανονική σειρά άξονα κατηγορίας και τιμής](axis-order-normal.png) | ![Οριζόντιο ραβδόγραμμα με κατηγορίες που εμφανίζονται από πάνω προς τα κάτω](axis-order-categories-reversed.png) | ![Οριζόντιο ραβδόγραμμα με αντιστραμμένο άξονα τιμής και μηδέν στα δεξιά](axis-order-values-reversed.png) |
| Οι κατηγορίες τρέχουν από το κάτω μέρος προς το πάνω; οι τιμές αυξάνονται από τα αριστερά προς τα δεξιά. | Σχεδιασμός, Ανάπτυξη και Δοκιμή τρέχουν από πάνω προς τα κάτω. Οι τιμές και η σειρά των γραμμών του βιβλίου εργασίας παραμένουν αμετάβλητες. | Οι κατηγορίες διατηρούν τη φυσική τους σειρά· οι τιμές αυξάνονται από τα δεξιά προς τα αριστερά. Ο άξονας κατηγορίας διασχίζει στο μηδέν στα δεξιά. |

## **Απενεργοποίηση του κατακόρυφου άξονα για γραμμές**

Ορίστε το [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) σε `False` στον κατακόρυφο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον κατακόρυφο άξονα κρυφό.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Απενεργοποίηση του οριζόντιου άξονα για γραμμές**

Ορίστε το [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) σε `False` στον οριζόντιο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον οριζόντιο άξονα κρυφό.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Εμφάνιση ή Απόκρυψη γραμμών πλέγματος διαγράμματος**

Διαβάστε τα [show_major_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_major_grid_lines/) και [show_minor_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_minor_grid_lines/) για να ελέγξετε ποιες γραμμές πλέγματος εμφανίζει ένας άξονας. Και οι δύο ιδιότητες είναι μόνο για ανάγνωση. Για να εμφανίσετε μικρές γραμμές πλέγματος, ορίστε τη γέμιση της γραμμής στο [minor_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_grid_lines_format/) σε γεμάτη γέμιση και επιλέξτε ένα ορατό χρώμα. Για να τις κρύψετε, ορίστε τον τύπο γέμισης σε `FillType.NO_FILL`. Για τις κύριες γραμμές πλέγματος, χρησιμοποιήστε το [major_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_grid_lines_format/)`.line.fill_format`. Η αλλαγή της γέμισης διατηρεί την ορατότητα του άξονα και τα σημεία κεντημάτων.

Ο κατακόρυφος άξονας του συγκεντρωτικού διαγράμματος στηλών ξεκινά με κύριες γραμμές πλέγματος ορατές και μικρές γραμμές κρυφές. Το παράδειγμα εμφανίζει τις μικρές γραμμές πλέγματος σε πορτοκαλί, έπειτα τις κρύβει ξανά πριν αποθηκεύσει την παρουσίαση.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 30, 660, 230)
    axis = chart.axes.vertical_axis
    print(f"Initial: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    minor_fill = axis.minor_grid_lines_format.line.fill_format
    minor_fill.fill_type = slides.FillType.SOLID
    minor_fill.solid_fill_color.color = slides.Color.dark_orange
    print(f"Enabled: minor={axis.show_minor_grid_lines}")

    minor_fill.fill_type = slides.FillType.NO_FILL
    print(f"Hidden: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    presentation.save("ChartGridlines.pptx", slides.export.SaveFormat.PPTX)
```

| Μικρές γραμμές πλέγματος ενεργοποιημένες | Μικρές γραμμές πλέγματος κρυφές |
| --- | --- |
| ![Πορτοκαλί μικρές γραμμές πλέγματος μεταξύ των κύριων γραμμών πλέγματος στον κατακόρυφο άξονα](minor-gridlines-enabled.png) | ![Ίδιο διάγραμμα στηλών με μόνο κύριες γραμμές πλέγματος ορατές](minor-gridlines-hidden.png) |

## **Αλλαγή άξονα κατηγορίας**

Ορίστε το [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) για να επιλέξετε άξονα κατηγορίας ημερομηνίας ή κειμένου. Αυτό το παράδειγμα απαιτεί το `ExistingChart.pptx`, με ένα διάγραμμα ως το πρώτο σχήμα στην πρώτη διαφάνεια και κελιά κατηγορίας που περιέχουν αριθμητικές τιμές ημερομηνίας του Excel. Αλλάζει τον οριζόντιο άξονα σε άξονα ημερομηνίας. Ορίζοντας το [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) σε `False`, το [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) σε `1` και το [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) σε months, τοποθετεί τα κύρια σημεία κεντημάτων σε διαστήματα ενός μήνα.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Καθορισμός τύπου άξονα κατηγορίας από τα δεδομένα**

Καλέστε το [set_category_axis_type_automatically](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/set_category_axis_type_automatically/) μετά τη συμπλήρωση των κατηγοριών, έπειτα διαβάστε το [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) για να ελέγξετε την επιλογή. Αυτό είναι χρήσιμο όταν το ίδιο διάγραμμα λαμβάνει είτε ετικέτες κειμένου είτε αριθμητικές τιμές ημερομηνίας. Η μέθοδος καθορίζει τον τύπο κατά την κλήση· δεν ενεργοποιεί μια μόνιμη λειτουργία που επανεκτιμά μεταγενέστερες αλλαγές δεδομένων. Καλέστε το ξανά μετά την αντικατάσταση των κατηγοριών.

Το ακόλουθο παράδειγμα δημιουργεί ένα διάγραμμα με κειμενικές κατηγορίες και εκτυπώνει `TEXT`. Στη συνέχεια αντικαθιστά τις τιμές των κελιών κατηγορίας με ημερομηνίες και καλεί ξανά τη μέθοδο, η οποία εκτυπώνει `DATE`. Οι ημερομηνίες αποθηκεύονται ως αριθμητικές τιμές OLE Automation, υπολογιζόμενες εδώ ως ο αριθμός ημερών από τις 30 Δεκεμβρίου 1899, αντί για αλφαριθμητικές ημερομηνίες. Το [custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) ελέγχει πώς εμφανίζονται αυτές οι τιμές· δεν μετατρέπει κείμενο σε αριθμητικές ημερομηνίες. Για περισσότερα σχετικά με τα κελιά κατηγορίας, δείτε το [Chart Workbook](/slides/el/python-net/chart-workbook/).

Χρησιμοποιήστε τον αυτόματο καθορισμό όταν η είσοδος περιέχει γνωστές κειμενικές κατηγορίες ή αριθμητικές ημερομηνίες, όπως σε αυτό το παράδειγμα. Για κανονικές αριθμητικές ετικέτες, μεικτές κατηγορίες ή κενά δεδομένα, ορίστε ρητά το [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) ώστε να ταιριάζει με τη σημασία. Μόνο αριθμητικές τιμές δεν καθορίζουν ότι οι κατηγορίες αντιπροσωπεύουν ημερομηνίες.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series_name = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name, chart.type)
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.get_cell(0, i + 1, 0, label)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # ΚΕΙΜΕΝΟ

    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.get_cell(0, i + 1, 0)
        category_cell.value = float((category_date - date(1899, 12, 30)).days)
        category_cell.custom_number_format = "yyyy-mm-dd"

    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # ΗΜΕΡΟΜΗΝΙΑ

    presentation.save("AutomaticCategoryAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Έλεγχος διαστημάτων ετικετών άξονα κατηγορίας**

Όταν ένα διάγραμμα έχει πολλές κατηγορίες, μειώστε τον αριθμό των ορατών ετικετών άξονα χωρίς να αφαιρέσετε τις κατηγορίες ή τα σημεία δεδομένων. Ορίστε το [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) σε `False`, στη συνέχεια ορίστε το [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) στο επιθυμητό διάστημα κατηγορίας. Για κειμενικές κατηγορίες στη φυσική τους σειρά, η αρίθμηση αρχίζει από την πρώτη κατηγορία:

| Διάστημα | Ετικέτες που εμφανίζονται στο παράδειγμα |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

Διάστημα `3` εμφανίζει κάθε τρίτη ετικέτα, αφήντας δύο ετικέτες κρυφές ανάμεσα στις εμφανιζόμενες. Δεν αφαιρεί τις αντίστοιχες στήλες. Η αυτόματη απόσταση επιλέγει διάστημα με βάση τον διαθέσιμο χώρο· δεν εμφανίζει απαραίτητα κάθε ετικέτα.

Τα σημεία κεντημάτων έχουν ξεχωριστούς ελέγχους. Ορίστε το [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) σε `False` και χρησιμοποιήστε το [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) για να ορίσετε το διάστημά τους. Για παράδειγμα, `1` διατηρεί σημείο κεντηματικού σε κάθε διάστημα κατηγορίας ενώ οι ετικέτες εμφανίζονται μόνο κάθε τρίτη κατηγορία. Ορίστε το [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) σε ένα ορατό στυλ ώστε να δείτε το αποτέλεσμα. Επιστρέφοντας οποιαδήποτε αυτόματη ιδιότητα σε `True` επιτρέπει στο διάγραμμα να επιλέξει ξανά αυτό το διάστημα.

Το επόμενο αυτόνομο παράδειγμα δημιουργεί 24 κατηγορίες και μία σειρά, έπειτα αποθηκεύει τρεις διαφάνειες στο `CategoryAxisIntervals.pptx`: αυτόματη απόσταση, χειροκίνητη απόσταση ετικετών με ανεξάρτητα σημεία κεντημάτων, και επαναφορά στην αυτόματη απόσταση. Τα δύο αντίγραφα διατηρούν τα αρχικά δεδομένα του διαγράμματος. Δεν απαιτείται εισαγωγική παρουσίαση. Το κείμενο ετικετών οριζόντια κάνει τη διαφορά στην πυκνότητα εύκολα ορατή.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # Διαφάνεια 2: εμφάνιση κάθε τρίτης ετικέτας, αλλά διατήρηση σημείου κεντηματικού για κάθε κατηγορία.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Διαφάνεια 3: αφήστε το διάγραμμα να επιλέξει ξανά και τα δύο διαστήματα.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Αυτόματη απόσταση (διαφ. 1):** Σε αυτήν την απόδοση, κάθε δεύτερη ετικέτα κατηγορίας εμφανίζεται και περιτυλίγεται σε δύο γραμμές. Το αυτόματο αποτέλεσμα μπορεί να διαφέρει ανάλογα με το μέγεθος του διαγράμματος, τις γραμματοσειρές και τον render.

![Αυτόματη απόσταση ετικετών κατηγορίας με όλες τις 24 στήλες ορατές](category-axis-automatic.png)

**Χειροκίνητη απόσταση (διαφ. 2):** Κάθε τρίτη ετικέτα εμφανίζεται σε μία γραμμή, ενώ τα σημεία κεντημάτων παραμένουν σε κάθε διάστημα κατηγορίας. Όλες οι 24 στήλες, συμπεριλαμβανομένων αυτών χωρίς ετικέτες, παραμένουν ορατές με τις ίδιες τιμές. Η διαφάνεια 3 επαναφέρει την αυτόματη εμφάνιση που φαίνεται παραπάνω.

![Χειροκίνητο διάστημα ετικετών κατηγορίας τριών με όλες τις 24 στήλες ορατές](category-axis-manual.png)

### **Επιλογή του σωστού άξονα και διαστήματος**

Χρησιμοποιήστε αυτό το διάστημα αριθμού κατηγοριών για άξονα κειμενικής κατηγορίας, όπως τον άξονα κατηγορίας ενός διαγράμματος στήλης, γραμμής, περιοχής ή ραβδόγραμμα. Σε διάγραμμα στήλης, είναι ο οριζόντιος άξονας. Σε οριζόντιο ραβδόγραμμα, ο άξονας κατηγορίας είναι κατακόρυφος, οπότε εφαρμογή των ρυθμίσεων στο [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Η απόσταση σημείων κεντημάτων εφαρμόζεται επίσης σε άξονα σειράς σε διαγράμματα που έχουν έναν.

Μην χρησιμοποιείτε την απόσταση ετικετών κατηγορίας για να θέσετε την αριθμητική κλίμακα ενός άξονα τιμής. Σε άξονα τιμής, το [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) καθορίζει τη διαφορά τιμών: π.χ., μονάδα `10` παράγει σημεία σε 0, 10, 20 κλπ όταν ο άξονας ξεκινά στο μηδέν. Διάστημα ετικέτας κατηγορίας `3` μετρά θέσεις κατηγορίας, ανεξάρτητα από τις τιμές των δεδομένων. Τα διαγράμματα scatter και bubble χρησιμοποιούν άξονες τιμής αντί για άξονα κειμενικής κατηγορίας. Για άξονα ημερομηνίας, χρησιμοποιήστε μονάδες χρόνου όπως περιγράφεται στην [Αλλαγή άξονα κατηγορίας](#change-a-category-axis).

## **Ορισμός μορφής ημερομηνίας για τιμές άξονα κατηγορίας**

Το παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα του διαγράμματος με τέσσερις ετήσιες τιμές. Οι ημερομηνίες αποθηκεύονται ως σειριακοί αριθμοί OLE Automation στο πρώτο φύλλο εργασίας (δείκτης `0`). Ορίστε το [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) σε άξονα ημερομηνίας, απενεργοποιήστε το [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) και αναθέστε `yyyy` στο [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) ώστε οι ετικέτες κατηγορίας να εμφανίζουν τέσσερα ψηφία έτους ανεξάρτητα από τη μορφοποίηση των κελιών.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός γωνίας περιστροφής για τον τίτλο άξονα διαγράμματος**

Ενεργοποιήστε το [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) στον κατακόρυφο άξονα, δώστε κείμενο τίτλου και ορίστε το [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) για να περιστρέψετε τον τίτλο. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα αποθηκεύει ένα διάγραμμα στήλης με τον τίτλο του άξονα τιμής περιστραμμένο κατά 90 μοίρες.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός θέσης άξονα σε άξονα κατηγορίας ή τιμής**

Χρησιμοποιήστε το [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) για να ελέγξετε αν ο άξονας τιμής διασχίζει τον άξονα κατηγορίας μεταξύ των κατηγοριών ή στα σημεία κεντημάτων της κατηγορίας. Αυτή η ιδιότητα ισχύει για τους άξονες κατηγορίας. Το παράδειγμα το ορίζει σε `True` στον οριζόντιο άξονα κατηγορίας ενός διαγράμματος στήλης και αποθηκεύει το αποτέλεσμα.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός μονάδας εμφάνισης σε άξονα τιμής διαγράμματος**

Ορίστε το [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) για να κλιμακώσετε τις ετικέτες σε άξονα τιμής χωρίς να αλλάξετε τα υποκείμενα δεδομένα. Με το [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) ορισμένο σε `MILLIONS`, μια τιμή των 60 000 000 εμφανίζεται ως 60. Το παράδειγμα δημιουργεί ένα διάγραμμα στήλης και εφαρμόζει τη μονάδα εμφάνισης εκατομμυρίων στον κατακόρυφο άξονα του.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαμόρφωση λογαριθμικού άξονα τιμής**

Ένας λογαριθμικός άξονας τιμής είναι χρήσιμος όταν οι θετικές τιμές καλύπτουν πολλές τάξεις μεγέθους. Για παράδειγμα, μια υπηρεσία μπορεί να λαμβάνει 10, 100, 1 000, 10 000 και 100 000 αιτήσεις σε πέντε περιόδους. Σε γραμμική κλίμακα, οι μικρότερες τιμές εμφανίζονται κοντά στη μηδενική τιμή. Μια λογαριθμική κλίμακα κάνει την σχετική τους ανάπτυξη πιο συγκρίσιμη: ίσες αποστάσεις αντιπροσωπεύουν ίσες αναλογίες αντί για ίσες διαφορές.

Ορίστε το [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) σε `True` στον άξονα τιμής και χρησιμοποιήστε το [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) για να επιλέξετε τη βάση. Αυτό αλλάζει τον τρόπο προβολής των υφιστάμενων τιμών· δεν αλλάζει τα δεδομένα ή προσθέτει λογαριθμική γραμμή τάσης. Μια γραμμή τάσης αντιπροσωπεύει μια προσαρμοσμένη σχέση στα δεδομένα και είναι ξεχωριστή λειτουργία.

### **Επιλογή άξονα τιμής και βάσης**

Για διάγραμμα γραμμής ή στήλης, ο άξονας τιμής είναι ο [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Για οριζόντιο ραβδόγραμμα, είναι ο [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Τα διαγράμματα scatter και bubble έχουν δύο άξονες τιμής, οπότε επιλέξτε τον οριζόντιο άξονα για τις τιμές X, τον κατακόρυφο για τις τιμές Y, ή και τους δύο. Μην εφαρμόζετε λογαριθμική κλιμάκωση σε άξονα κατηγορίας.

Η προεπιλεγμένη λογαριθμική βάση είναι `10`. Για διαγράμματα PPTX, χρησιμοποιήστε βάση από `2` έως `1000`, συμπεριλαμβανομένου· υποστηρίζονται και κλασματικές βάσεις όπως `2.5`. Με βάση `10`, οι διαδοχικές δυνάμεις όπως 10, 100, 1 000 και 10 000 είναι ισομεγέθεις.

### **Σύγκριση γραμμικής και λογαριθμικής κλίμακας**

Το επόμενο αυτόνομο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με τις πέντε μετρήσεις αιτήσεων στη πρώτη διαφάνεια, έπειτα κλωνοποιεί αυτή τη διαφάνεια και ενεργοποιεί λογαριθμικό άξονα τιμής βάσης‑10 στη δεύτερη. Και οι δύο διαφάνειες διατηρούν τα ίδια δεδομένα.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Διατηρήστε την πρώτη διαφάνεια γραμμική και αλλάξτε μόνο την κλίμακα του άξονα τιμών του αντιγράφου.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Γραμμική κλίμακα (διαφ. 1):** Ίσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσες διαφορές στις μετρήσεις αιτήσεων. Η μεγαλύτερη τιμή κυριαρχεί στο διάγραμμα, καθιστώντας τις μικρότερες τιμές δύσκολο να διακριθούν.

![Διάγραμμα γραμμής σε PowerPoint που δείχνει πέντε μετρήσεις αιτήσεων σε γραμμικό άξονα τιμής](value-axis-linear.png)

**Λογαριθμική κλίμακα (διαφ. 2):** Ίσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσες αναλογίες. Κάθε περίοδος έχει δέκα φορές περισσότερες αιτήσεις από την προηγούμενη, οπότε τα σημεία σχηματίζουν μια ευθεία ανύψωση στην κλίμακα βάσης‑10. Οι ετικέτες του άξονα εξακολουθούν να δείχνουν τις αρχικές μετρήσεις.

![Οι ίδιες πέντε μετρήσεις αιτήσεων σε PowerPoint σε λογαριθμικό άξονα τιμής βάσης‑10](value-axis-logarithmic.png)

### **Διαχείριση μηδέν και αρνητικών τιμών**

Μια λογαριθμική κλίμακα μπορεί να εμφανίσει μόνο θετικές τιμές. Ελέγξτε τα δεδομένα πριν την ενεργοποιήσετε. Εάν μηδέν ή αρνητικές τιμές έχουν νόημα, διατηρήστε την γραμμική κλίμακα ή εμφανίστε τις ξεχωριστά. Εάν η εξαίρεση αυτών των τιμών είναι κατάλληλη για την ανάλυση, εξηγήστε την παράλειψη. Μην αντικαθιστάτε σιωπηλά τις τιμές με μικρούς θετικούς αριθμούς, καθώς αυτό αλλάζει το νόημα των δεδομένων. Οποιαδήποτε χειροκίνητη ελάχιστη ή μέγιστη τιμή για λογαριθμικό άξονα πρέπει επίσης να είναι θετική.

## **Συχνές ερωτήσεις**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασχίσεις άξονα);**

Χρησιμοποιήστε το [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) για να επιλέξετε τη συμπεριφορά διασχίσεων. Για να καθορίσετε αριθμητική τιμή διασχίσεων, ορίστε το [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Αυτές οι ρυθμίσεις σας επιτρέπουν να μετακινήσετε τη διασχίση άξονα σε κατάλληλο βάση.

**Πώς μπορώ να τοποθετήσω τις ετικέτες σημείων κεντημάτων σε σχέση με τον άξονα;**

Ορίστε το [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) χρησιμοποιώντας το [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` ή `NONE`. Για έλεγχο των σημείων κεντημάτων, χρησιμοποιήστε το [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) ή το [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); αυτά είναι ξεχωριστά από τη θέση ετικετών.