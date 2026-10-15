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
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides για Python μέσω .NET για να προσαρμόσετε τους άξονες διαγράμματος σε παρουσιάσεις PowerPoint και OpenDocument για αναφορές και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τους άξονες των διαγραμμάτων με το Aspose.Slides για Python μέσω .NET. Καλύπτει υπολογιζόμενες τιμές άξονα, την εναλλαγή γραμμών και στηλών του διαγράμματος, την ορατότητα του άξονα, τα διαστήματα ετικετών κατηγορίας και σημείων-γραμμής, τις κατηγορίες ημερομηνίας και τη μορφοποίηση, την περιστροφή του τίτλου, τη θέση του άξονα, τις μονάδες εμφάνισης και την λογαριθμική κλιμάκωση.

## **Λήψη των Μέγιστων Τιμών στον Κατακόρυφο Άξονα σε Διαγράμματα**

Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) και προσθέστε ένα διάγραμμα περιοχής με προεπιλεγμένα δεδομένα. Καλέστε το [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) πριν διαβάσετε τις υπολογιζόμενες τιμές άξονα ώστε η διάταξη του διαγράμματος να είναι ενημερωμένη.

Διαβάστε τις [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) και [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) για τα όρια του άξονα, και τις [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) και [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) για τα διαστήματα σημείων. Οι [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) και [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) παρέχουν κλίμακες μονάδας χρόνου, που είναι σχετικές με άξονες ημερομηνίας. Το παράδειγμα αποθηκεύει αυτές τις τιμές σε τοπικές μεταβλητές και αποθηκεύει το διάγραμμα.

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

## **Αντιμετάθεση των Δεδομένων μεταξύ των Αξόνων**

Χρησιμοποιήστε το [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) για να ανταλλάξετε τους ρόλους των σειρών και των κατηγοριών στα δεδομένα διαγράμματος. Κάθε παλιά κατηγορία γίνεται σειρά, και κάθε παλιά σειρά γίνεται κατηγορία. Αυτό αλλάζει τον τρόπο ομαδοποίησης των δεδομένων· δεν ανταλλάσσει τους οριζόντιους και κατακόρυφους άξονες. Το παράδειγμα χρησιμοποιεί το [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) για να συνδέσει τα προεπιλεγμένα δεδομένα με `Sheet1!A1:D5`, συμπεριλαμβανομένης της γραμμής κεφαλίδας και της στήλης κατηγορίας, πριν την ανταλλαγή γραμμών και στηλών. Αποθηκεύει ένα διάγραμμα με τέσσερις σειρές και τρεις κατηγορίες.

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

## **Αντιστροφή της Σειράς Σχεδίασης ενός Άξονα**

Χρησιμοποιήστε το [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) για να αντιστρέψετε έναν άξονα κατηγορίας ή τιμής. Για παράδειγμα, ένα οριζόντιο ραβδοδιάγραμμα μπορεί να εμφανίζει τα στάδια του έργου από πάνω προς τα κάτω με την ίδια σειρά όπως στο φύλλο εργασίας: Planning, Development, Testing. Η αντιστροφή ενός άξονα αλλάζει την κατεύθυνση σχεδίασης· δεν ταξινομεί ή αναδιατάσσει τα δεδομένα του βιβλίου εργασίας. Σε σύγκριση, το [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) ανταλλάσσει τους ρόλους των σειρών και των κατηγοριών.

Το παρακάτω παράδειγμα δημιουργεί ένα οριζόντιο ραβδοδιάγραμμα με τρία στάδια και μία σειρά. Αποθηκεύει μια παρουσίαση με τρεις διαφάνειες: κανονική σειρά, αντιστραμμένες κατηγορίες και αντιστραμμένες τιμές. Κάθε αντίγραφο χρησιμοποιεί το ίδιο σύνολο δεδομένων, και μόνο ένας άξονας αντιστρέφεται σε κάθε αντίγραφο.

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
    # Κρατήστε τον οριζόντιο άξονα τιμών στο κάτω μέρος.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Διαφάνεια 3: αντιστροφή μόνο της οριζόντιας αριθμητικής κλίμακας.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Η αντιστροφή ενός άξονα μπορεί επίσης να μετακινήσει τον κάθετο άξονα στην απέναντι πλευρά του διαγράμματος. Το [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) ελέγχει πού διασχίζει ο άλλος άξονας τον άξονα που ρυθμίζεται. Στη διαφάνεια 2, ορίζοντας το σε `MAXIMUM` στον αντιστραμμένο άξονα κατηγορίας διατηρεί τον οριζόντιο άξονα τιμών στο κάτω μέρος. Για ένα συγκεκριμένο σημείο διασταύρωσης, χρησιμοποιήστε το [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Ελέγξτε τις ρυθμίσεις διασταύρωσης όταν αλλάζετε κατεύθυνση, ειδικά εάν το διάγραμμα έχει ήδη προσαρμοσμένο σημείο διασταύρωσης. Ορίστε το `is_plot_order_reversed` πάλι σε `False` για να επαναφέρετε την κανονική κατεύθυνση σχεδίασης· οι ρυθμίσεις διασταύρωσης είναι ξεχωριστές.

| Κανονική σειρά (διαφάνεια 1) | Αντιστραμμένες κατηγορίες (διαφάνεια 2) | Αντιστραμμένες τιμές (διαφάνεια 3) |
| --- | --- | --- |
| ![Οριζόντιο ραβδοδιάγραμμα με κανονική σειρά άξονα κατηγορίας και τιμής](axis-order-normal.png) | ![Οριζόντιο ραβδοδιάγραμμα με κατηγορίες που εμφανίζονται από πάνω προς τα κάτω](axis-order-categories-reversed.png) | ![Οριζόντιο ραβδοδιάγραμμα με αντιστραμμένο άξονα τιμής και μηδέν στα δεξιά](axis-order-values-reversed.png) |
| Οι κατηγορίες τρέχουν από κάτω προς τα πάνω· οι τιμές αυξάνονται από αριστερά προς δεξιά. | Planning, Development και Testing τρέχουν από πάνω προς τα κάτω. Οι τιμές και η σειρά γραμμών του βιβλίου εργασίας παραμένουν αμετάβλητες. | Οι κατηγορίες διατηρούν την κανονική τους σειρά· οι τιμές αυξάνονται από δεξιά προς αριστερά. Ο άξονας κατηγορίας διασχίζει στο μηδέν στα δεξιά. |

## **Απενεργοποίηση του Κατακόρυφου Άξονα για Γραμμικά Διαγράμματα**

Ορίστε το [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) σε `False` στον κατακόρυφο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γραμμικό διάγραμμα με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον κατακόρυφο άξονα κρυφό.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Απενεργοποίηση του Οριζόντιου Άξονα για Γραμμικά Διαγράμματα**

Ορίστε το [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) σε `False` στον οριζόντιο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γραμμικό διάγραμμα με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον οριζόντιο άξονα κρυφό.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Αλλαγή Άξονα Κατηγορίας**

Ορίστε το [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) για να επιλέξετε έναν άξονα ημερομηνίας ή κειμένου. Αυτό το παράδειγμα απαιτεί το `ExistingChart.pptx`, με ένα διάγραμμα ως το πρώτο σχήμα στην πρώτη διαφάνεια και κελιά κατηγορίας που περιέχουν αριθμητικές τιμές ημερομηνίας Excel. Αλλάζει τον οριζόντιο άξονα σε άξονα ημερομηνίας. Ορίζοντας το [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) σε `False`, το [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) σε `1` και το [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) σε μήνες, τοποθετεί τα κύρια σημεία σε διαστήματα ενός μήνα.

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

## **Έλεγχος Διαστημάτων Ετικετών Άξονα Κατηγορίας**

Όταν ένα διάγραμμα έχει πολλές κατηγορίες, μειώστε τον αριθμό των ορατών ετικετών άξονα χωρίς να αφαιρέσετε κατηγορίες ή σημεία δεδομένων. Ορίστε το [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) σε `False`, στη συνέχεια ορίστε το [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) στο επιθυμητό διάστημα κατηγορίας. Για κειμενικές κατηγορίες με τη φυσική τους σειρά, η αρίθμηση ξεκινά από την πρώτη κατηγορία:

| Διάστημα | Ετικέτες που εμφανίζονται στο παράδειγμα |
| --- | --- |
| `1` | Κατηγορία 1, Κατηγορία 2, Κατηγορία 3, … Κατηγορία 24 |
| `2` | Κατηγορία 1, Κατηγορία 3, Κατηγορία 5, … Κατηγορία 23 |
| `3` | Κατηγορία 1, Κατηγορία 4, Κατηγορία 7, … Κατηγορία 22 |

Ένα διάστημα `3` εμφανίζει κάθε τρίτη ετικέτα, αφήνοντας δύο ετικέτες κρυμμένες μεταξύ των εμφανιζόμενων. Δεν αφαιρεί τις αντίστοιχες στήλες. Η αυτόματη διάταση επιλέγει ένα διάστημα βάσει του διαθέσιμου χώρου· δεν εμφανίζει απαραίτητα κάθε ετικέτα.

Τα σημεία-γραμμή έχουν ξεχωριστούς ελέγχους. Ορίστε το [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) σε `False` και χρησιμοποιήστε το [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) για να θέσετε το διάστημα τους. Για παράδειγμα, το `1` διατηρεί ένα σημείο-γραμμή σε κάθε διάστημα κατηγορίας ενώ οι ετικέτες εμφανίζονται μόνο κάθε τρίτη κατηγορία. Ορίστε το [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) σε ένα ορατό στυλ ώστε να δείτε το αποτέλεσμα. Επαναφέροντας οποιαδήποτε ιδιότητα αυτόματης διάτασης σε `True` επιτρέπει στο διάγραμμα να επιλέξει εκ νέου αυτό το διάστημα.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί 24 κατηγορίες και μία σειρά, στη συνέχεια αποθηκεύει τρεις διαφάνειες στο `CategoryAxisIntervals.pptx`: αυτόματη διάταξη, χειροκίνητη διάταξη ετικετών με ανεξάρτητα σημεία-γραμμή, και επαναφορά της αυτόματης διάταξης. Τα δύο αντίγραφα διατηρούν τα αρχικά δεδομένα του διαγράμματος. Δεν απαιτείται εισαγωγική παρουσίαση. Το οριζόντιο κείμενο ετικέτας κάνει τη διαφορά στην πυκνότητα ευκολότερη στην παρατήρηση.

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

    # Διαφάνεια 2: εμφάνιση κάθε τρίτης ετικέτας, αλλά διατήρηση σημείου-γραμμής για κάθε κατηγορία.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Διαφάνεια 3: άφησε το διάγραμμα να επιλέξει ξανά και τα δύο διαστήματα.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Αυτόματη διάταξη (διαφάνεια 1):** Σε αυτήν την απόδοση, κάθε δεύτερη ετικέτα κατηγορίας εμφανίζεται και αναδιπλώνεται σε δύο γραμμές. Το αυτόματο αποτέλεσμα μπορεί να διαφέρει ανάλογα με το μέγεθος του διαγράμματος, τις γραμματοσειρές και τον κινητήρα απόδοσης.

![Αυτόματη διάταξη ετικετών κατηγορίας με όλες τις 24 στήλες ορατές](category-axis-automatic.png)

**Χειροκίνητη διάταξη (διαφάνεια 2):** Κάθε τρίτη ετικέτα εμφανίζεται σε μία γραμμή, ενώ τα σημεία-γραμμή παραμένουν σε κάθε διάστημα κατηγορίας. Όλες οι 24 στήλες, συμπεριλαμβανομένων εκείνων χωρίς ετικέτες, παραμένουν ορατές με τις ίδιες τιμές. Η διαφάνεια 3 επαναφέρει την αυτόματη εμφάνιση που φαίνεται παραπάνω.

![Χειροκίνητο διάστημα ετικετών κατηγορίας τριών με όλες τις 24 στήλες ορατές](category-axis-manual.png)

### **Επιλογή του Σωστού Άξονα και Διαστημάτων**

Χρησιμοποιήστε αυτό το διάστημα καταμέτρησης κατηγοριών για έναν άξονα κειμένου, όπως ο άξονας κατηγορίας ενός ραβδοδιαγράμματος, διαγράμματος στήλης, γραμμικού ή περιοχής. Σε διάγραμμα στήλης, είναι ο οριζόντιος άξονας. Σε οριζόντιο ραβδοδιάγραμμα, ο άξονας κατηγορίας είναι κατακόρυφος, έτσι εφαρμόστε αυτές τις ρυθμίσεις στο [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Η διάταξη σημείων-γραμμής ισχύει επίσης για άξονα σειράς σε διαγράμματα που το διαθέτουν.

Μην χρησιμοποιείτε τη διάταξη ετικετών κατηγορίας για να ορίσετε την αριθμητική κλίμακα ενός άξονα τιμής. Σε άξονα τιμής, το [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) καθορίζει μια διαφορά στις τιμές: για παράδειγμα, μια κύρια μονάδα `10` δημιουργεί σημεία σε 0, 10, 20 κ.λπ. όταν ο άξονας ξεκινά από το μηδέν. Ένα διάστημα ετικέτας κατηγορίας `3` μετράει τις θέσεις κατηγορίας, ανεξάρτητα από τις τιμές δεδομένων. Τα διαγράμματα διασποράς και φούσκας χρησιμοποιούν άξονες τιμών αντί για άξονα κειμένου. Για άξονα ημερομηνίας, χρησιμοποιήστε μονάδες και κλίμακες βασισμένες στο χρόνο όπως περιγράφεται στην ενότητα [Change a Category Axis](#change-a-category-axis).

## **Ορισμός Μορφής Ημερομηνίας για Τιμές Άξονα Κατηγορίας**

Το παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα του διαγράμματος με τέσσερις ετήσιες τιμές. Οι ημερομηνίες αποθηκεύονται ως σειριακοί αριθμοί OLE Automation στο πρώτο φύλλο εργασίας (δείκτης `0`). Ορίστε το [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) σε άξονα ημερομηνίας, απενεργοποιήστε το [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) και αντιστοιχίστε το `yyyy` στο [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) ώστε οι ετικέτες κατηγορίας να εμφανίζουν έτη τετραψήφια ανεξάρτητα από τη μορφοποίηση των κελιών.

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

## **Ορισμός Γωνίας Περιστροφής για Τίτλο Άξονα Διαγράμματος**

Ενεργοποιήστε το [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) στον κατακόρυφο άξονα, δώστε κείμενο τίτλου, και ορίστε το [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) για να περιστρέψετε τον τίτλο. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα αποθηκεύει ένα διάγραμμα στήλης με τον τίτλο του άξονα τιμών περιστρεφόμενο κατά 90 μοίρες.

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

## **Ορισμός Θέσης Άξονα σε Άξονα Κατηγορίας ή Τιμής**

Χρησιμοποιήστε το [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) για να ελέγξετε αν ο άξονας τιμής διασχίζει τον άξονα κατηγορίας μεταξύ των κατηγοριών ή στα σημεία-γραμμή κατηγορίας. Αυτή η ιδιότητα εφαρμόζεται σε άξονες κατηγορίας. Το παράδειγμα το θέτει σε `True` στον οριζόντιο άξονα κατηγορίας ενός διαγράμματος στήλης και αποθηκεύει το αποτέλεσμα.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Μονάδας Εμφάνισης σε Άξονα Τιμής Διαγράμματος**

Ορίστε το [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) για να κλιμακώσετε τις ετικέτες σε άξονα τιμής χωρίς να αλλάξετε τα υποκείμενα δεδομένα. Με το [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) ορισμένο σε `MILLIONS`, μια τιμή των 60.000.000 εμφανίζεται ως 60. Το παράδειγμα δημιουργεί ένα διάγραμμα στήλης και εφαρμόζει τη μονάδα εμφάνισης εκατομμυρίων στον κατακόρυφο άξονά του.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαμόρφωση Λογαριθμικού Άξονας Τιμής**

Ένας λογαριθμικός άξονας τιμής είναι χρήσιμος όταν οι θετικές τιμές καλύπτουν πολλές τάξεις μεγέθους. Για παράδειγμα, μια υπηρεσία μπορεί να λαμβάνει 10, 100, 1.000, 10.000 και 100.000 αιτήματα σε πέντε περιόδους. Σε γραμμική κλίμακα, οι μικρότερες τιμές εμφανίζονται κοντά η μία στην άλλη κοντά στο μηδέν. Μια λογαριθμική κλίμακα καθιστά την σχετική τους αύξηση πιο συγκρίσιμη: ίσες αποστάσεις αντιπροσωπεύουν ίσους λόγους αντί για ίσες διαφορές.

Ορίστε το [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) σε `True` στον άξονα τιμής και χρησιμοποιήστε το [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) για να επιλέξετε τη βάση. Αυτό αλλάζει τον τρόπο εμφάνισης των υπαρχόντων τιμών· δεν αλλάζει τα δεδομένα ή προσθέτει μια λογαριθμική γραμμή τάσης. Μια γραμμή τάσης αντιπροσωπεύει μια προσαρμοσμένη σχέση στα δεδομένα και είναι ξεχωριστή λειτουργία.

### **Επιλογή Άξονα Τιμής και Βάσης**

Για ένα γραμμικό ή στήλης διάγραμμα, ο άξονας τιμής είναι το [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Για ένα οριζόντιο ραβδοδιάγραμμα, είναι το [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Τα διαγράμματα διασποράς και φούσκας έχουν δύο άξονες τιμής, οπότε επιλέξτε τον οριζόντιο άξονα για τις τιμές X, τον κατακόρυφο άξονα για τις τιμές Y ή και τους δύο. Μην εφαρμόζετε λογαριθμική κλιμάκωση σε άξονα κατηγορίας.

Η προεπιλεγμένη λογαριθμική βάση είναι `10`. Για διαγράμματα PPTX, χρησιμοποιήστε βάση από `2` έως `1000`, συμπεριλαμβανομένων· υποστηρίζονται επίσης κλασματικές βάσεις όπως `2.5`. Με βάση `10`, οι διαδοχικές δυνάμεις όπως 10, 100, 1.000 και 10.000 είναι εξίσου αποσταμένες.

### **Σύγκριση Γραμμικής και Λογαριθμικής Κλιμάκωσης**

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα γραμμικό διάγραμμα με τις πέντε μετρήσεις αιτήσεων στην πρώτη διαφάνεια, στη συνέχεια κλωνοποιεί αυτή τη διαφάνεια και ενεργοποιεί έναν λογαριθμικό άξονα τιμής βάσης-10 στη δεύτερη. Και οι δύο διαφάνειες διατηρούν τα ίδια δεδομένα.

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

**Γραμμική κλίμακα (διαφάνεια 1):** Ίσες κάθετες αποστάσεις αντιπροσωπεύουν ίσες διαφορές στις μετρήσεις των αιτήσεων. Η μεγαλύτερη τιμή κυριαρχεί στο διάγραμμα, καθιστώντας τις μικρότερες τιμές δύσκολο να διακριθούν.

![Γραμμικό διάγραμμα στο PowerPoint που εμφανίζει πέντε μετρήσεις αιτήσεων σε γραμμικό άξονα τιμής](value-axis-linear.png)

**Λογαριθμική κλίμακα (διαφάνεια 2):** Ίσες κάθετες αποστάσεις αντιπροσωπεύουν ίσους λόγους. Κάθε περίοδος έχει δέκα φορές περισσότερα αιτήματα από την προηγούμενη, έτσι τα σημεία σχηματίζουν μια ευθεία ανερχόμενη γραμμή στη βάση-10 κλίμακα. Οι ετικέτες άξονα εξακολουθούν να εμφανίζουν τις αρχικές μετρήσεις αιτήσεων.

![Οι ίδιες πέντε μετρήσεις αιτήσεων στο PowerPoint σε λογαριθμικό άξονα τιμής βάσης-10](value-axis-logarithmic.png)

### **Διαχείριση Μηδενικών και Αρνητικών Τιμών**

Μια λογαριθμική κλίμακα μπορεί να εμφανίσει μόνο αυστηρώς θετικές τιμές. Ελέγξτε τα δεδομένα πριν την ενεργοποιήσετε. Εάν οι μηδενικές ή αρνητικές τιμές έχουν νόημα, διατηρήστε μια γραμμική κλίμακα ή εμφανίστε τις ξεχωριστά. Εάν η εξαίρεση αυτών των τιμών είναι κατάλληλη για την ανάλυση, εξηγήστε την παράλειψη. Μην αντικαθιστάτε σιωπηρά τις τιμές με μικρούς θετικούς αριθμούς, καθώς αυτό αλλάζει το νόημα των δεδομένων. Οποιοδήποτε χειροκίνητα ρυθμισμένο ελάχιστο ή μέγιστο για έναν λογαριθμικό άξονα πρέπει επίσης να είναι θετικό.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασταύρωση άξονα);**

Χρησιμοποιήστε το [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) για να επιλέξετε τη συμπεριφορά διασταύρωσης. Για να ορίσετε μια αριθμητική τιμή διασταύρωσης, ορίστε το [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Αυτές οι ρυθμίσεις σας επιτρέπουν να μετακινήσετε τη διασταύρωση του άξονα σε μια κατάλληλη βασική γραμμή.

**Πώς μπορώ να τοποθετήσω τις ετικέτες σημείων-γραμμής σε σχέση με τον άξονα;**

Ορίστε το [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) χρησιμοποιώντας το [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` ή `NONE`. Για να ελέγξετε τα ίδια τα σημεία-γραμμή, χρησιμοποιήστε το [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) ή το [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); αυτά είναι ξεχωριστά από τη θέση των ετικετών.