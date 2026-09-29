---
title: Διαχείριση σειρών δεδομένων διαγράμματος σε παρουσιάσεις με Python
linktitle: Σειρές δεδομένων
type: docs
url: /el/python-net/chart-series/
keywords:
- σειρές διαγράμματος
- επικάλυψη σειράς
- χρώμα σειράς
- χρώμα κατηγορίας
- όνομα σειράς
- σημείο δεδομένων
- διάστημα σειράς
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε σειρές διαγράμματος, σημεία δεδομένων, κελιά βιβλίου εργασίας, μορφοποίηση, επικάλυψη, πλάτος κενού και αρνητικές τιμές σε παρουσιάσεις με Python."
---
## **Επισκόπηση**

Ένα διάγραμμα αποθηκεύει τα δεδομένα που σχεδιάζει σε ένα βιβλίο εργασίας δεδομένων διαγράμματος. Ένα [ChartSeries](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/) αντιπροσωπεύει ένα σύνολο σχετικών τιμών, και κάθε [ChartDataPoint](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/) στη σειρά αναφέρεται σε ένα ή περισσότερα κελιά του βιβλίου εργασίας. Τα αντικείμενα [ChartCategory](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται από τις σειρές. Το όνομα της σειράς, οι κατηγορίες και οι τιμές των σημείων είναι έτσι συνδεδεμένα με τα αντικείμενα [ChartDataCell](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatacell/) αντί να αποθηκεύονται μόνο ως κείμενο εμφάνισης.

Για ένα τυπικό διάγραμμα κατηγορίας, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη γραμμή 0 για τα ονόματα σειρών, τη στήλη 0 για τα ονόματα κατηγοριών και τα υπόλοιπα κελιά για τις τιμές των σειρών. Οι δείκτες φύλλου, γραμμής και στήλης που περνιούνται στο [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) είναι μηδενικής βάσης. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα διάγραμμα με προεπιλεγμένα δεδομένα, αλλά δεν υποθέτετε ότι κάθε υπάρχον διάγραμμα το χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, ελέγξτε τα κελιά στα οποία αναφέρονται οι σειρές, οι κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου εργασίας.

Οι ρυθμίσεις του διαγράμματος έχουν τρεις διαφορετικές εμβέλειες:

- Ρυθμίσεις σε επίπεδο σειράς, όπως [ChartSeries.format](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/format/), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία σε μια σειρά.
- Ρυθμίσεις σημείου δεδομένων, όπως [ChartDataPoint.format](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/format/), αντικαθιστούν την εμφάνιση της σειράς για ένα σημείο.
- Οι ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στην ίδια [ChartSeriesGroup](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseriesgroup/). Πρόσβαση στην ομάδα μέσω [ChartSeries.parent_series_group](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/parent_series_group/) όταν χρειάζεται να ορίσετε επιλογές όπως η επικάλυψη ή το πλάτος κενού.

Όταν δεν έχει οριστεί ρητή γεμίσματος σημείου ή σειράς, το στυλ και το θέμα του διαγράμματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχουν τόσο μορφοποίηση σειράς όσο και σημείου, η μορφοποίηση του σημείου έχει προτεραιότητα για εκείνο το σημείο.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ορισμός Επικάλυψης Σειρών Διαγράμματος**

[ChartSeries.overlap](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/overlap/) αναφέρει πόσο επικάλυπται οι μπάρες ή οι στήλες σε 2Δ διάγραμμα, από -100 έως 100 τοις εκατό. Είναι μια μόνο-ανάγνωση προβολή της ρύθμισης στην γονική ομάδα σειρών. Ορίστε [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseriesgroup/overlap/) για να ενημερώσετε κάθε συμβατή σειρά σε εκείνη την ομάδα. Αυτή η επιλογή ισχύει για τύπους διαγραμμάτων που εμφανίζουν ομαδοποιημένες μπάρες ή στήλες· δεν επηρεάζει τις μη σχετικές ομάδες σειρών σε ένα σύνθετο διάγραμμα.

Το παρακάτω παράδειγμα ορίζει την επικάλυψη για την ομάδα που περιέχει την πρώτη σειρά:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Το νέο διάγραμμα περιέχει δείγμα σειρών, κατηγοριών και τιμών.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The series overlap](series_overlap.png)

## **Αλλαγή Χρώματος Γέμισματος Σειράς**

Χρησιμοποιήστε [ChartSeries.format](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/format/) για να ορίσετε το προεπιλεγμένο γέμισμα ολόκληρης μιας σειράς. Εάν ένα σημείο έχει ήδη ρητό γέμισμα, η ρύθμιση [ChartDataPoint.format](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/format/) του παρακάμπτει το γέμισμα της σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει συμπαγές μπλε γέμισμα στην πρώτη σειρά:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The color of the series](series_color.png)

## **Αλλαγή Ονόματος Σειράς**

Το όνομα μιας σειράς αποθηκεύεται στο βιβλίο εργασίας δεδομένων διαγράμματος και εμφανίζεται κανονικά στο υπόμνημα. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα διαγώνιο στήλης, το κελί B1 βρίσκεται στη γραμμή 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι σταθερές ονομασίες στο παρακάτω παράδειγμα κάνουν αυτήν τη δομή σαφή:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη αναφέρεται από το [ChartSeries.name](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/name/). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης γραμμής και στήλης σε υπάρχον διάγραμμα:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The series name](series_name.png)

## **Λήψη Αυτόματου Χρώματος Γέμισματος Σειράς**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) επιστρέφει το χρώμα που υπολογίζεται από τον δείκτη σειράς και το στυλ διαγράμματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν το γέμισμα σειράς δεν έχει οριστεί ρητά. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν αποδίδει νέο γέμισμα.

Το παρακάτω παράδειγμα εκτυπώνει το αυτόματο χρώμα κάθε προεπιλεγμένης σειράς:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

Παράδειγμα εξόδου για το προεπιλεγμένο στυλ διαγράμματος:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Τα ακριβή χρώματα εξαρτώνται από το στυλ και το θέμα του διαγράμματος.

## **Ορισμός Αντιστροφής Γεμίσματος για Σειρά Διαγράμματος**

Για σειρές μπάρων, στηλών και φυσαλίδων, το [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/invert_if_negative/) μπορεί να εμφανίζει αρνητικές τιμές με διαφορετικό γέμισμα. Ορίστε το κανονικό γέμισμα σειράς σε συμπαγές, ενεργοποιήστε την αντιστροφή και καθορίστε το χρώμα αρνητικής τιμής μέσω του [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· μόνο το χρώμα εμφάνισης τους αλλάζει.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα διαγράμματος με μία σειρά. Η γραμμή 0 του φύλλου περιέχει το όνομα της σειράς, η στήλη 0 περιέχει τα ονόματα κατηγοριών και η στήλη 1 τις τιμές:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The inverted solid fill color](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω του [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Στο παρακάτω παράδειγμα η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιείται μόνο για το επιλεγμένο σημείο. Το σημείο λαμβάνει επίσης αρνητική τιμή ώστε το εφέ να είναι ορατό:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Καθαρισμός Συγκεκριμένης Τιμής Σημείου Δεδομένων**

Για να κάνετε ένα σημείο κενό χωρίς να αφαιρέσετε τα άλλα, ορίστε το αντίστοιχο κελί βιβλίου εργασίας σε `None`. Για ένα διάγραμμα στηλών, η σχεδιασμένη τιμή είναι διαθέσιμη μέσω του [ChartDataPoint.value](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/value/). Το σημείο παραμένει στην ίδια θέση κατηγορίας, αλλά το διάγραμμα το θεωρεί κενό σύμφωνα με τις ρυθμίσεις κενών τιμών του διαγράμματος.

Το παρακάτω παράδειγμα καθαρίζει μόνο το δεύτερο σημείο στην πρώτη σειρά:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

Τα διαγράμματα scatter χρησιμοποιούν ξεχωριστά κελιά X και Y, ενώ τα διαγράμματα φυσαλίδων χρησιμοποιούν επίσης κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει την τιμή που θέλετε να αφαιρέσετε. Μην καλέσετε το [ChartDataPointCollection.clear](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapointcollection/clear/) όταν θέλετε να κρατήσετε τα άλλα σημεία, διότι αυτή η μέθοδος αφαιρεί όλα τα σημεία δεδομένων από τη συλλογή.

## **Έλεγχος Εμφάνισης Κενών Κελιών**

Κρυμμένα κελιά που περιέχουν τιμές αποτελούν ξεχωριστή περίπτωση από τα κενά κελιά. Για να συμπεριλάβετε ή να εξαιρέσετε δεδομένα από κρυμμένες γραμμές και στήλες του φύλλου, δείτε το [Include Data from Hidden Rows and Columns](/slides/el/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Ένα κενό κελί βιβλίου εργασίας αντιπροσωπεύει δεδομένα που λείπουν· ένα κελί που περιέχει `0` αντιπροσωπεύει γνωστή αριθμητική τιμή. Ορίστε το [ChartDataCell.value](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatacell/value/) σε `None` για να κάνετε το κελί κενό. Ένας μηδενικός αριθμός παραμένει μηδενικός ανεξάρτητα από τη ρύθμιση κενών κελιών.

Χρησιμοποιήστε το [Chart.display_blanks_as](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/display_blanks_as/) για να επιλέξετε πώς το διάγραμμα εμφανίζει κενά κελιά. Αυτή η ρύθμιση ισχύει για ολόκληρο το διάγραμμα. Αλλάζει τον τρόπο κατά τον οποίο τα κενά σχεδιάζονται, χωρίς να γεμίζει το κενό κελί με μηδέν ή παρεμβολή.

Το παρακάτω αυτό-συμπεριλαμβανόμενο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με μία σειρά, αφαιρεί την τιμή για την Ημέρα 3 και αποθηκεύει το ίδιο διάγραμμα με κάθε λειτουργία. Δεν απαιτείται αρχείο εισόδου. Το [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/) χρησιμοποιεί το φύλλο 0, στήλη 0 για ετικέτες κατηγοριών και στήλη 1 για τιμές· η γραμμή 0 περιέχει το όνομα της σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Αφήστε την Ημέρα 3 πραγματικά κενή, διατηρώντας την κατηγορία και το σημείο δεδομένων.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Κάθε αρχείο εξόδου αποθηκεύει τη λειτουργία που είχε οριστεί πριν την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για να αποθηκεύσετε μόνο μία έκδοση, ορίστε τη λειτουργία που επιθυμείτε και αποθηκεύστε την παρουσίαση μία φορά αντί για επανάληψη στις λειτουργίες.

Η σύγκριση παρακάτω δείχνει τα ίδια δεδομένα και στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο εργασίας σε κάθε περίπτωση:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Το ορατό αποτέλεσμα εξαρτάται από τον τύπο διαγράμματος. Ένα διάγραμμα γραμμής κάνει εύκολη τη σύγκριση των τριών λειτουργιών. Τα διαγράμματα μπάρων και στηλών δεν έχουν γραμμή για σύνδεση μέσω μιας χαμένης κατηγορίας, οπότε το `SPAN` δεν μπορεί να παράγει το συνδετικό τμήμα που φαίνεται παραπάνω· μια χαμένη στήλη και μια στήλη μηδενικού ύψους μπορεί επίσης να φαίνονται παρόμοια. Παρομοίως, ένα διάγραμμα scatter με μόνο δείκτες δεν έχει γραμμή σύνδεσης. Μην περιμένετε τρία διακριτά αποτελέσματα για κάθε τύπο διαγράμματος· ελέγξτε την έξοδο για τον τύπο που χρησιμοποιείτε.

## **Ορισμός Πλάτους Κενού Σειράς**

Το πλάτος κενού είναι το διάστημα μεταξύ γειτονικών ομάδων μπάρων ή στηλών, εκφρασμένο ως ποσοστό του πλάτους της μπάρας ή της στήλης. Όπως η επικάλυψη, ανήκει στην γονική ομάδα σειρών παρά σε μία σειρά. Ορίστε το [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) μία φορά για την ομάδα. Μία μεγαλύτερη τιμή δημιουργεί περισσότερο χώρο μεταξύ των ομάδων· μια μικρότερη τιμή τις κάνει πιο πυκνές.

Το παρακάτω παράδειγμα αλλάζει το πλάτος κενού και αποθηκεύει μόνο την τελική παρουσίαση:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The gap width](gap_width.png)

## **Συχνές Ερωτήσεις**

**Ποιους τύπους διαγραμμάτων υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι διαγραμμάτων που αντιπροσωπεύονται από την κλάση [ChartType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/charttype/) χρησιμοποιούν δεδομένα διαγράμματος, αλλά οι σειρές τους δεν έχουν όλοι την ίδια δομή ή ρυθμίσεις. Για παράδειγμα, τα διαγράμματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα διαγράμματα scatter χρησιμοποιούν τιμές X και Y, και τα διαγράμματα φυσαλίδων προσθέτουν μεγέθη φυσαλίδων. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει με τον τύπο σειράς. Οι επιλογές όπως επικάλυψη και πλάτος κενού ισχύουν μόνο για συμβατές ομάδες μπάρων ή στηλών.

**Τι είναι μια ομάδα σειρών διαγράμματος;**

Μια [ChartSeriesGroup](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις σχεδίασης επιπέδου ομάδας. Ένα σύνθετο διάγραμμα μπορεί να περιέχει περισσότερες από μία ομάδες, επομένως η αλλαγή της ομάδας μέσω μιας σειράς δεν αλλάζει απαραίτητα όλες τις σειρές στο διάγραμμα.

**Δημιουργεί ένα νέο διάγραμμα προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, η μέθοδος [ShapeCollection.add_chart](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_chart/) δημιουργεί δείγματα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να καθαρίσετε τις συλλογές σειρών και κατηγοριών πριν προσθέσετε ένα εντελώς προσαρμοσμένο σύνολο δεδομένων. Υπάρχει επίσης υπερφόρτωση που μπορεί να δημιουργήσει διάγραμμα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα διαγράμματος με τα κελιά του βιβλίου εργασίας;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων αναφέρονται σε κελιά ενός [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/). Η αλλαγή ενός κελιού που αναφέρεται ενημερώνει το αντίστοιχο στοιχείο του διαγράμματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, διατηρήστε τις γραμμές κατηγοριών και τις γραμμές τιμών σειρών ευθυγραμμισμένες ώστε κάθε σημείο να σχεδιάζεται κάτω από την επιθυμητή κατηγορία.

**Πώς να καθαρίσω ένα σημείο αντί ολόκληρης σειράς;**

Ορίστε το αντίστοιχο κελί τιμής σε `None` για να διατηρήσετε τη θέση της κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε το [ChartDataPointCollection.clear](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapointcollection/clear/) μόνο όταν θέλετε να αφαιρέσετε όλα τα σημεία από εκείνη τη σειρά. Εάν αφαιρείτε επίσης κατηγορίες, ενημερώστε κάθε σειρά ώστε οι τιμές τους να παραμείνουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο διαγράμματος και το [Chart.display_blanks_as](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/display_blanks_as/). Τα υποστηριζόμενα διαγράμματα μπορούν να εμφανίζουν κενά ως κενά, ως μηδενικές τιμές ή συνδέοντας τα γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει με το νόημα των ελλειπουσών δεδομένων στην παρουσίασή σας. Δείτε το [Control the Display of Empty Cells](#control-the-display-of-empty-cells) για ένα πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για τις υποστηριζόμενες σειρές μπάρων, στηλών και φυσαλίδων, ενεργοποιήστε το [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/invert_if_negative/) και ορίστε το [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Μπορείτε να παρακάμψετε τη συμπεριφορά για ένα μεμονωμένο σημείο μέσω του [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Αυτές οι ιδιότητες επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση κυριαρχεί όταν τόσο η σειρά όσο και το σημείο είναι μορφοποιημένα;**

Η ρητή μορφοποίηση σημείου δεδομένων έχει προτεραιότητα για εκείνο το σημείο. Τα άλλα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφοποίηση σειράς ή, όταν η μορφοποίηση σειράς δεν είναι ορισμένη, το αυτόματο στυλ και θέμα του διαγράμματος. Οι ιδιότητες ομάδας όπως επικάλυψη και πλάτος κενού ελέγχουν τη διάταξη και δεν αποτελούν παρακάμψεις μορφοποίησης επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα διάγραμμα;**

Το Aspose.Slides δεν επιβάλλει ξεχωριστό όριο αριθμού σειρών. Στην πράξη, οι περιορισμοί του αρχείου παρουσίασης, η διαθέσιμη μνήμη, ο χρόνος απόδοσης και η αναγνωσιμότητα του διαγράμματος καθορίζουν ένα χρήσιμο όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά;**

Ορίστε το [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) στην κατάλληλη γονική ομάδα σειρών. Αυξήστε την τιμή για να μεγεθύνετε το κενό μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά μεταξύ τους.