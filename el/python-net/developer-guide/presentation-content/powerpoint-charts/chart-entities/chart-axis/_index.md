---
title: Προσαρμογή Αξόνων Διαγραμμάτων στις Παρουσιάσεις με Python
linktitle: Άξονας Διαγράμματος
type: docs
url: /el/python-net/chart-axis/
keywords:
- άξονας διαγράμματος
- κάθετος άξονας
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

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τους άξονες διαγράμματος με το Aspose.Slides for Python μέσω .NET. Καλύπτει τις υπολογιζόμενες τιμές άξονα, την εναλλαγή σειρών και στηλών διαγράμματος, την ορατότητα άξονα, τα διαστήματα ετικετών κατηγορίας και δεικτών, τις ημερομηνίες κατηγοριών και τη μορφοποίηση, την περιστροφή τίτλου, τη θέση άξονα, τις μονάδες εμφάνισης και την λογαριθμική κλιμάκωση.

## **Λήψη των Μέγιστων Τιμών στον Κάθετο Άξονα σε Διαγράμματα**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) και προσθέστε ένα γράφημα περιοχής με προεπιλεγμένα δεδομένα. Κλήστε το [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) πριν διαβάσετε τις υπολογιζόμενες τιμές άξονα ώστε η διάταξη του διαγράμματος να είναι ενημερωμένη.

Διαβάστε το [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) και το [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) για τα όρια του άξονα και τα [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) και [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) για τα διαστήματα των δεικτών. Τα [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) και [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) παρέχουν κλίμακες μονάδας χρόνου, οι οποίες είναι σχετικές με άξονες ημερομηνίας. Το παράδειγμα αποθηκεύει αυτές τις τιμές σε τοπικές μεταβλητές και αποθηκεύει το γράφημα.

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

## **Ανταλλαγή των Δεδομένων μεταξύ των Άξονων**

Χρησιμοποιήστε το [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) για να ανταλλάξετε τους ρόλους των σειρών και των κατηγοριών στα δεδομένα του διαγράμματος. Κάθε πρώην κατηγορία γίνεται σειρά, και κάθε πρώην σειρά γίνεται κατηγορία. Αυτό αλλάζει τον τρόπο ομαδοποίησης των δεδομένων· δεν ανταλλάσσει τους οριζόντιους και κάθετους άξονες. Το παράδειγμα χρησιμοποιεί το [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) για να συνδέσει τα προεπιλεγμένα δεδομένα με `Sheet1!A1:D5`, συμπεριλαμβανομένης της γραμμής κεφαλίδας και της στήλης κατηγορίας, πριν την εναλλαγή σειρών και στηλών. Αποθηκεύει ένα γράφημα με τέσσερις σειρές και τρεις κατηγορίες.

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

## **Απενεργοποίηση του Κάθετου Άξονα για Γραμμικά Διαγράμματα**

Ορίστε το [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) σε `False` για τον κάθετο άξονα ώστε να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γραμμικό διάγραμμα με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον κάθετο άξονα κρυφτό.

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

Ορίστε το [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) σε `False` για τον οριζόντιο άξονα ώστε να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γραμμικό διάγραμμα με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον οριζόντιο άξονα κρυφτό.

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

Ορίστε το [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) για να επιλέξετε έναν άξονα κατηγορίας ημερομηνίας ή κειμένου. Αυτό το παράδειγμα απαιτεί το `ExistingChart.pptx`, με ένα γράφημα ως το πρώτο σχήμα στην πρώτη διαφάνεια και κελιά κατηγορίας που περιέχουν αριθμητικές τιμές ημερομηνίας Excel. Αλλάζει τον οριζόντιο άξονα σε άξονα ημερομηνίας. Ορίζοντας το [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) σε `False`, το [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) σε `1` και το [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) σε μήνες τοποθετεί τα κύρια σημεία σε διαστήματα ενός μήνα.

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

Όταν ένα γράφημα έχει πολλές κατηγορίες, μειώστε τον αριθμό των ορατών ετικετών άξονα χωρίς να αφαιρέσετε κατηγορίες ή σημεία δεδομένων. Ορίστε το [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) σε `False`, στη συνέχεια ορίστε το [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) στο επιθυμητό διάστημα κατηγορίας. Για κατηγορίες κειμένου με τη φυσική τους σειρά, η αρίθμηση ξεκινά από την πρώτη κατηγορία:

| Διάστημα | Ετικέτες που εμφανίζονται στο παράδειγμα |
| --- | --- |
| `1` | Κατηγορία 1, Κατηγορία 2, Κατηγορία 3, ... Κατηγορία 24 |
| `2` | Κατηγορία 1, Κατηγορία 3, Κατηγορία 5, ... Κατηγορία 23 |
| `3` | Κατηγορία 1, Κατηγορία 4, Κατηγορία 7, ... Κατηγορία 22 |

Ένα διάστημα `3` εμφανίζει κάθε τρίτη ετικέτα, αφήνοντας δύο ετικέτες κρυφές μεταξύ των εμφανιζόμενων. Δεν αφαιρεί τις αντίστοιχες στήλες. Η αυτόματη απόσταση επιλέγει ένα διάστημα βάσει του διαθέσιμου χώρου· δεν εμφανίζει απαραίτητα κάθε ετικέτα.

Τα σημεία σήμανσης έχουν ξεχωριστό έλεγχο. Ορίστε το [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) σε `False` και χρησιμοποιήστε το [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) για να ορίσετε το διάστημά τους. Για παράδειγμα, `1` διατηρεί ένα σημείο σήμανσης σε κάθε διάστημα κατηγορίας ενώ οι ετικέτες εμφανίζονται μόνο κάθε τρίτη κατηγορία. Ορίστε το [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) σε ένα ορατό στυλ ώστε να δείτε το αποτέλεσμα. Επαναφέροντας οποιαδήποτε ιδιότητα αυτόματου διαστήματος σε `True` επιτρέπει στο γράφημα να επιλέξει ξανά αυτό το διάστημα.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί 24 κατηγορίες και μία σειρά, στη συνέχεια αποθηκεύει τρεις διαφάνειες στο `CategoryAxisIntervals.pptx`: αυτόματη τοποθέτηση, χειροκίνητη τοποθέτηση ετικετών με ανεξάρτητα σημεία σήμανσης, και αποκατάσταση της αυτόματης τοποθέτησης. Τα δύο αντίγραφα διατηρούν τα αρχικά δεδομένα του διαγράμματος. Δεν απαιτείται εισαγωγική παρουσίαση. Το κείμενο ετικέτας οριζόντια καθιστά τη διαφορά στην πυκνότητα εύκολα ορατή.

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

    # Διαφάνεια 2: δείξτε κάθε τρίτη ετικέτα, αλλά διατηρήστε ένα σημείο σήμανσης για κάθε κατηγορία.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Διαφάνεια 3: αφήστε το γράφημα να επιλέξει ξανά και τα δύο διαστήματα.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Αυτόματη τοποθέτηση (διαφάνεια 1):** Σε αυτή την απόδοση, κάθε δεύτερη ετικέτα κατηγορίας εμφανίζεται και περικλείεται σε δύο γραμμές. Το αυτόματο αποτέλεσμα μπορεί να διαφέρει ανάλογα με το μέγεθος του διαγράμματος, τις γραμματοσειρές και τον renderer.

![Αυτόματη τοποθέτηση ετικετών κατηγορίας με όλες τις 24 στήλες ορατές](category-axis-automatic.png)

**Χειροκίνητη τοποθέτηση (διαφάνεια 2):** Κάθε τρίτη ετικέτα εμφανίζεται σε μία γραμμή, ενώ τα σημεία σήμανσης παραμένουν σε κάθε διάστημα κατηγορίας. Όλες οι 24 στήλες, συμπεριλαμβανομένων εκείνων χωρίς ετικέτες, παραμένουν ορατές με τις ίδιες τιμές. Η διαφάνεια 3 αποκαθιστά την αυτόματη εμφάνιση που φαίνεται παραπάνω.

![Χειροκίνητο διάστημα ετικετών κατηγορίας τριών με όλες τις 24 στήλες ορατές](category-axis-manual.png)

### **Επιλέξτε τον Κατάλληλο Άξονα και Διάστημα**

Χρησιμοποιήστε αυτό το διάστημα αριθμού κατηγορίας για έναν άξονα κατηγορίας κειμένου, όπως ο άξονας κατηγορίας ενός ράβδου, γραμμικού, περιοχής ή ραβδογράφηματος. Σε ένα γράφημα στήλης, είναι ο οριζόντιος άξονας. Σε ένα οριζόντιο ραβδόγραμμα, ο άξονας κατηγορίας είναι κάθετος, οπότε εφαρμόστε αυτές τις ρυθμίσεις στο [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Το διάστημα σημείων σήμανσης ισχύει επίσης για έναν άξονα σειράς σε διαγράμματα που έχουν τέτοιο.

Μην χρησιμοποιείτε την απόσταση ετικετών κατηγορίας για να ορίσετε την αριθμητική κλίμακα ενός άξονα τιμής. Σε έναν άξονα τιμής, το [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) καθορίζει τη διαφορά τιμών: για παράδειγμα, μια κύρια μονάδα `10` δημιουργεί σημεία σε 0, 10, 20 κ.λπ. όταν ο άξονας ξεκινάει από το μηδέν. Ένα διάστημα ετικέτας κατηγορίας `3` μετράει αντίθετα τις θέσεις κατηγορίας, ανεξάρτητα από τις τιμές των δεδομένων. Τα διαγράμματα διασποράς και φυσαλίδων χρησιμοποιούν άξονες τιμής αντί για άξονα κατηγορίας κειμένου. Για άξονα ημερομηνίας, χρησιμοποιήστε μονάδες και κλίμακες βασισμένες στο χρόνο όπως περιγράφεται στην [Change a Category Axis](#change-a-category-axis).

## **Ορισμός Μορφής Ημερομηνίας για Τιμές Άξονα Κατηγορίας**

Το παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα του διαγράμματος με τέσσερις ετήσιες τιμές. Οι ημερομηνίες αποθηκεύονται ως σειριακοί αριθμοί OLE Automation στο πρώτο φύλλο εργασίας (δείκτης `0`). Ορίστε το [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) σε άξονα ημερομηνίας, απενεργοποιήστε το [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/), και αναθέστε `yyyy` στο [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) ώστε οι ετικέτες κατηγορίας να εμφανίζουν έτη τετραψήφια ανεξάρτητα από τη μορφοποίηση των κελιών.

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

Ενεργοποιήστε το [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) στον κάθετο άξονα, παρέχετε το κείμενο του τίτλου και ορίστε το [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) για να περιστρέψετε τον τίτλο. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα αποθηκεύει ένα γράφημα στήλης με τον τίτλο του άξονα τιμής περιστραμμένο κατά 90 μοίρες.

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

Χρησιμοποιήστε το [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) για να ελέγξετε αν ο άξονας τιμής διασχίζει τον άξονα κατηγορίας μεταξύ των κατηγοριών ή στα σημεία σήμανσης της κατηγορίας. Αυτή η ιδιότητα ισχύει για άξονες κατηγορίας. Το παράδειγμα το ορίζει σε `True` στον οριζόντιο άξονα κατηγορίας ενός γραφήματος στήλης και αποθηκεύει το αποτέλεσμα.

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

Ορίστε το [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) για να κλιμακώσετε τις ετικέτες σε έναν άξονα τιμής χωρίς να αλλάξετε τα υποκείμενα δεδομένα. Με το [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) ορισμένο σε `MILLIONS`, μια τιμή των 60.000.000 εμφανίζεται ως 60. Το παράδειγμα δημιουργεί ένα γράφημα στήλης και εφαρμόζει τη μονάδα εμφάνισης εκατομμυρίων στον κάθετο άξονα του.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαμόρφωση Λογαριθμικού Άξονα Τιμής**

Ένας λογαριθμικός άξονας τιμής είναι χρήσιμος όταν οι θετικές τιμές καλύπτουν πολλές τάξεις μεγέθους. Για παράδειγμα, μια υπηρεσία μπορεί να λαμβάνει 10, 100, 1.000, 10.000 και 100.000 αιτήματα κατά τη διάρκεια πέντε περιόδων. Σε γραμμική κλίμακα, οι μικρότερες τιμές εμφανίζονται κοντά μεταξύ τους κοντά στο μηδέν. Μια λογαριθμική κλίμακα κάνει την σχετική τους αύξηση πιο εύκολη στη σύγκριση: ίσες αποστάσεις αντιπροσωπευουν ίσους λόγους αντί για ίσες διαφορές.

Ορίστε το [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) σε `True` στον άξονα τιμής και χρησιμοποιήστε το [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) για να επιλέξετε τη βάση. Αυτό αλλάζει τον τρόπο εμφάνισης των υπαρχουσών τιμών· δεν αλλάζει τα δεδομένα ούτε προσθέτει μια λογαριθμική γραμμή τάσης. Μια γραμμή τάσης αντιπροσωπεύει μια προσαρμοσμένη σχέση στα δεδομένα και είναι ξεχωριστό χαρακτηριστικό.

### **Επιλέξτε τον Άξονα Τιμής και τη Βάση**

Για γράφημα γραμμής ή στήλης, ο άξονας τιμής είναι το [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Για οριζόντιο ραβδόγραμμα, είναι το [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Τα διαγράμματα διασποράς και φυσαλίδων έχουν δύο άξονες τιμής, οπότε επιλέξτε τον οριζόντιο άξονα για τιμές X, τον κάθετο άξονα για τιμές Y ή και τους δύο. Μην εφαρμόζετε λογαριθμική κλιμάκωση σε άξονα κατηγορίας.

Η προεπιλεγμένη λογαριθμική βάση είναι `10`. Για διαγράμματα PPTX, χρησιμοποιήστε βάση από `2` έως `1000`, συμπεριλαμβανομένου· υποστηρίζονται επίσης κλασματικές βάσεις όπως `2.5`. Με βάση `10`, οι διαδοχικές δυνάμεις όπως 10, 100, 1.000 και 10.000 είναι εξίσου αρθρωτές.

### **Σύγκριση Γραμμικής και Λογαριθμικής Κλιμάκωσης**

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα γράφημα γραμμής με τις πέντε μετρήσεις αιτημάτων στην πρώτη διαφάνεια, στη συνέχεια κλωνοποιεί αυτή τη διαφάνεια και ενεργοποιεί έναν λογαριθμικό άξονα τιμής βάσης 10 στη δεύτερη. Και οι δύο διαφάνειες διατηρούν τα ίδια δεδομένα.

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

    # Διατηρήστε την πρώτη διαφάνεια γραμμική και αλλάξτε μόνο τη κλίμακα του άξονα τιμής του αντίγραφου.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Γραμμική κλίμακα (διαφάνεια 1):** Ίσα κάθετα απόσταση αντιπροσωπεύουν ίσες διαφορές στις μετρήσεις αιτημάτων. Η μεγαλύτερη τιμή κυριαρχεί στο γράφημα, καθιστώντας τις μικρότερες τιμές δύσκολο να διακριθούν.

![Γραμμικό διάγραμμα σε PowerPoint που εμφανίζει πέντε μετρήσεις αιτημάτων σε γραμμικό άξονα τιμής](value-axis-linear.png)

**Λογαριθμική κλίμακα (διαφάνεια 2):** Ίσες κάθετες αποστάσεις αντιπροσωπεύουν ίσους λόγους. Κάθε περίοδος έχει δέκα φορές περισσότερα αιτήματα από την προηγούμενη, έτσι τα σημεία σχηματίζουν μια ευθεία ανερχόμενη γραμμή στη βάση-10 κλίμακα. Οι ετικέτες άξονα εξακολουθούν να εμφανίζουν τις αρχικές μετρήσεις αιτημάτων.

![Οι ίδιες πέντε μετρήσεις αιτημάτων σε PowerPoint σε λογαριθμικό άξονα τιμής βάσης 10](value-axis-logarithmic.png)

### **Διαχείριση Μηδενικών και Αρνητικών Τιμών**

Μια λογαριθμική κλίμακα μπορεί να εμφανίσει μόνο αυστηρά θετικές τιμές. Ελέγξτε τα δεδομένα πριν την ενεργοποιήσετε. Εάν μηδενικές ή αρνητικές τιμές είναι σημαντικές, διατηρήστε μια γραμμική κλίμακα ή εμφανίστε τις ξεχωριστά. Εάν η εξαίρεση αυτών των τιμών είναι κατάλληλη για την ανάλυση, εξηγήστε την παράλειψη. Μην τις αντικαθιστάτε σιωπηλά με μικρούς θετικούς αριθμούς, καθώς αυτό αλλάζει το νόημα των δεδομένων. Οποιοσδήποτε χειροκίνητα ρυθμισμένος ελάχιστος ή μέγιστος για έναν λογαριθμικό άξονα πρέπει επίσης να είναι θετικός.

## **Συχνές Ερωτήσεις**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασταύρωση άξονα);**

Χρησιμοποιήστε το [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) για να επιλέξετε τη συμπεριφορά διασταύρωσης. Για να καθορίσετε μια αριθμητική τιμή διασταύρωσης, ορίστε το [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Αυτές οι ρυθμίσεις σας επιτρέπουν να μετακινήσετε τη διασταύρωση άξονα σε ένα κατάλληλο σημείο βάσης.

**Πώς μπορώ να τοποθετήσω τις ετικέτες δεικτών σε σχέση με τον άξονα;**

Ορίστε το [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) χρησιμοποιώντας το [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` ή `NONE`. Για να ελέγξετε τα ίδια τα σημεία σήμανσης, χρησιμοποιήστε το [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) ή το [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); αυτά είναι ξεχωριστά από τη θέση των ετικετών.