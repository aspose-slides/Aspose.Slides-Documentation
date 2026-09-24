---
title: Διαχείριση Σειρών Δεδομένων Γραφήματος σε Παρουσιάσεις με Python
linktitle: Σειρές Δεδομένων
type: docs
url: /el/python-net/chart-series/
keywords:
- σειρά γραφήματος
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
description: "Μάθετε πώς να διαχειρίζεστε σειρές γραφήματος, σημεία δεδομένων, κελιά βιβλίου εργασίας, μορφοποίηση, επικάλυψη, πλάτος κενότητας και αρνητικές τιμές σε παρουσιάσεις με Python."
---
## **Επισκόπηση**

Ένα γράφημα αποθηκεύει τα δεδομένα του σε ένα βιβλίο εργασίας δεδομένων γραφήματος. Μια [ChartSeries](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/) αναπαριστά ένα σύνολο σχετικών τιμών και κάθε [ChartDataPoint](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/) στη σειρά αναφέρεται σε ένα ή περισσότερα κελιά του βιβλίου εργασίας. Τα αντικείμενα [ChartCategory](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται οι σειρές. Έτσι, το όνομα της σειράς, οι κατηγορίες και οι τιμές των σημείων συνδέονται με αντικείμενα [ChartDataCell](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatacell/) αντί να αποθηκεύονται μόνο ως κείμενο εμφάνισης.

Για ένα τυπικό γράφημα κατηγορίας, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη γραμμή 0 για τα ονόματα των σειρών, τη στήλη 0 για τα ονόματα των κατηγοριών και τα υπόλοιπα κελιά για τις τιμές των σειρών. Οι δείκτες φύλλου εργασίας, γραμμής και στήλης που περνούν στη μέθοδο [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) είναι μηδενισμένες. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα γράφημα με προεπιλεγμένα δεδομένα, αλλά μην υποθέτετε ότι κάθε υπάρχον γράφημα τη χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, ελέγξτε τα κελιά στα οποία αναφέρονται οι σειρές, οι κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου εργασίας.

Οι ρυθμίσεις του γραφήματος έχουν τρία διαφορετικά επίπεδα:

- Ρυθμίσεις επιπέδου σειράς, όπως η [ChartSeries.format](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/format/), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία μιας σειράς.
- Ρυθμίσεις σημείου δεδομένων, όπως η [ChartDataPoint.format](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/format/), υπερκαλύπτουν την εμφάνιση της σειράς για ένα σημείο.
- Ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στην ίδια [ChartSeriesGroup](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseriesgroup/). Πρόσβαση στην ομάδα μέσω της [ChartSeries.parent_series_group](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/parent_series_group/) όταν χρειάζεται να ορίσετε επιλογές όπως η επικάλυψη ή το πλάτος κενότητας.

Όταν δεν έχει οριστεί ρητό γέμισμα σημείου ή σειράς, το στυλ και το θέμα του γραφήματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχουν τόσο μορφοποίηση σειράς όσο και σημείου, η μορφοποίηση σημείου έχει προτεραιότητα για εκείνο το σημείο.

![σειρά-γράφημα-powerpoint](chart-series-powerpoint.png)

## **Ορισμός Επικάλυψης Σειρών Γραφήματος**

Η [ChartSeries.overlap](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/overlap/) αναφέρει πόσο τα μπάρες ή οι στήλες επικαλύπτονται σε ένα 2D γράφημα, από -100 έως 100 %. Είναι μια μόνο για ανάγνωση προβολή της ρύθμισης στην γονική ομάδα σειρών. Ορίστε την [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseriesgroup/overlap/) για να ενημερώσετε όλες τις συμβατές σειρές σε αυτήν την ομάδα. Αυτή η επιλογή ισχύει για τύπους γραφήματος που εμφανίζουν ομαδοποιημένες μπάρες ή στήλες· δεν επηρεάζει ανεξάρτητες ομάδες σειρών σε ένα σύνθετο γράφημα.

Το ακόλουθο παράδειγμα ορίζει την επικάλυψη για την ομάδα που περιέχει την πρώτη σειρά:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Το νέο γράφημα περιέχει δείγματα σειρών, κατηγοριών και τιμών.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η επικάλυψη της σειράς](series_overlap.png)

## **Αλλαγή Χρώματος Γεμίσματος Σειράς**

Χρησιμοποιήστε την [ChartSeries.format](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/format/) για να ορίσετε το προεπιλεγμένο γέμισμα ολόκληρης μιας σειράς. Εάν ένα σημείο έχει ήδη ρητό γέμισμα, η ρύθμιση της [ChartDataPoint.format](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/format/) υπερισχύει του γεμίσματος της σειράς για εκείνο το σημείο.

Το ακόλουθο παράδειγμα εφαρμόζει συμπαγές μπλε γέμισμα στην πρώτη σειρά:

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

![Το χρώμα της σειράς](series_color.png)

## **Αλλαγή Ονόματος Σειράς**

Το όνομα μιας σειράς αποθηκεύεται στο βιβλίο εργασίας δεδομένων γραφήματος και συνήθως εμφανίζεται στο υπόμνημα. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα γράφημα στήλης ομαδοποίησης, το κελί B1 βρίσκεται στη γραμμή 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι σταθερές ονομασίας στο ακόλουθο παράδειγμα κάνουν αυτή τη δομή ρητή:

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

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη αναφέρεται από την [ChartSeries.name](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/name/). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης γραμμής και στήλης σε ένα υπάρχον γράφημα:

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

![Το όνομα της σειράς](series_name.png)

## **Λήψη Αυτόματου Χρώματος Γεμίσματος Σειράς**

Η [ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) επιστρέφει το χρώμα που υπολογίζεται από τον δείκτη της σειράς και το στυλ του γραφήματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν το γέμισμα της σειράς δεν έχει οριστεί ρητώς. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν αναθέτει νέο γέμισμα.

Το ακόλουθο παράδειγμα εκτυπώνει το αυτόματο χρώμα κάθε προεπιλεγμένης σειράς:

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

Παράδειγμα εξόδου για το προεπιλεγμένο στυλ γραφήματος:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Τα ακριβή χρώματα εξαρτώνται από το στυλ και το θέμα του γραφήματος.

## **Ορισμός Αντιστροφής Χρώματος Γεμίσματος για Σειρά Γραφήματος**

Για σειρές μπάρες, στήλες και φυσαλίδες, η [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/invert_if_negative/) μπορεί να εμφανίσει αρνητικές τιμές με διαφορετικό γέμισμα. Ορίστε το κανονικό γέμισμα της σειράς σε συμπαγές, ενεργοποιήστε την αντιστροφή και ορίστε το χρώμα για αρνητικές τιμές μέσω της [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· αλλάζει μόνο το χρώμα εμφάνισης.

Το ακόλουθο παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα γραφήματος με μία σειρά. Η γραμμή 0 του φύλλου εργασίας περιέχει το όνομα της σειράς, η στήλη 0 τα ονόματα των κατηγοριών και η στήλη 1 τις τιμές:

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

![Το αντιστροφόμενο συμπαγές χρώμα γεμίσματος](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω της [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Στο παρακάτω παράδειγμα η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιείται μόνο για το επιλεγμένο σημείο. Το σημείο επίσης λαμβάνει αρνητική τιμή ώστε το αποτέλεσμα να είναι εμφανές:

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

Για να κάνετε ένα σημείο κενό χωρίς να αφαιρέσετε τα άλλα σημεία, ορίστε το αντίστοιχο κελί του βιβλίου εργασίας σε `None`. Για ένα γράφημα στήλης, η σχεδιασμένη τιμή είναι προσβάσιμη μέσω της [ChartDataPoint.value](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/value/). Το σημείο παραμένει στην ίδια θέση κατηγορίας, αλλά το γράφημα το θεωρεί κενό σύμφωνα με τις ρυθμίσεις κενών τιμών του γραφήματος.

Το ακόλουθο παράδειγμα καθαρίζει μόνο το δεύτερο σημείο στην πρώτη σειρά:

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

Τα γραφήματα scatter χρησιμοποιούν ξεχωριστά κελιά X και Y, και τα γραφήματα φυσαλίδων χρησιμοποιούν επίσης κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει τη τιμή που θέλετε να αφαιρέσετε. Μην καλέσετε την [ChartDataPointCollection.clear](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapointcollection/clear/) όταν θέλετε να διατηρήσετε τα άλλα σημεία, επειδή αυτή η μέθοδος αφαιρεί όλα τα σημεία δεδομένων από τη συλλογή.

## **Έλεγχος Εμφάνισης Κελιών χωρίς Δεδομένα**

Ένα κενό κελί βιβλίου εργασίας αντιπροσωπεύει ελλιπή δεδομένα· ένα κελί που περιέχει `0` αντιπροσωπεύει μια γνωστή αριθμητική τιμή. Ορίστε την [ChartDataCell.value](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatacell/value/) σε `None` για να κάνετε ένα κελί κενό. Ένας αριθμητικός μηδενικός παραμένει μηδενικός ανεξάρτητα από τη ρύθμιση κενών κελιών.

Χρησιμοποιήστε την [Chart.display_blanks_as](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/display_blanks_as/) για να επιλέξετε πώς το γράφημα εμφανίζει τα κενά κελιά. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρο το γράφημα. Αλλάζει τον τρόπο με τον οποίο σχεδιάζονται τα κενά, χωρίς να γεμίζει το κενό κελί με μηδέν ή με παρεμβαλλόμενη τιμή.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα γράφημα γραμμής με μία σειρά, καθαρίζει την τιμή για την Ημέρα 3 και αποθηκεύει το ίδιο γράφημα με κάθε λειτουργία. Δεν απαιτείται αρχείο εισόδου. Το [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/) χρησιμοποιεί φύλλο εργασίας 0, στήλη 0 για τις ετικέτες κατηγορίας και στήλη 1 για τις τιμές· η γραμμή 0 περιέχει το όνομα της σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

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

    # Αφήστε την Ημέρα 3 πραγματικά κενή, διατηρώντας την κατηγορία και το σημείο δεδομένων της.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Κάθε αρχείο εξόδου αποθηκεύει τη λειτουργία που είχε επιλεγεί πριν από την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για να αποθηκεύσετε μόνο μία έκδοση, ορίστε την επιθυμητή λειτουργία και αποθηκεύστε την παρουσίαση μία φορά αντί να επαναλάβετε τις λειτουργίες.

Η σύγκριση παρακάτω δείχνει τα ίδια δεδομένα και στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο εργασίας σε κάθε περίπτωση:

![Γραφήματα γραμμής με ίδια δεδομένα: Το Gap διακόπτει τη γραμμή στην Ημέρα 3, το Zero μειώνει τη γραμμή στο μηδέν, και το Span συνδέει τη Ημέρα 2 με τη Ημέρα 4.](display_blanks_as.png)

Το οπτικό αποτέλεσμα εξαρτάται από τον τύπο γραφήματος. Ένα γράφημα γραμμής κάνει εύκολη τη σύγκριση και των τριών λειτουργιών. Τα γραφήματα μπάρες και στήλες δεν έχουν γραμμή για να συνδέσουν μια εναλλαξιακή κατηγορία, οπότε το `SPAN` δεν μπορεί να δημιουργήσει το συνδετικό τμήμα που φαίνεται παραπάνω· ένα κενό κελί και μια στήλη μηδενικού ύψους μπορούν επίσης να φαίνονται παρόμοια. Παρόμοια, ένα γράφημα scatter με μόνο δείκτες δεν έχει γραμμή σύνδεσης. Μην περιμένετε τρία διαφορετικά αποτελέσματα για κάθε τύπο γραφήματος· ελέγξτε την έξοδο για τον τύπο που χρησιμοποιείτε.

## **Ορισμός Πλάτους Κενότητας Σειράς**

Το πλάτος κενότητας είναι το διάστημα μεταξύ προσεγγιστικών ομάδων μπάρες ή στήλες, εκφρασμένο ως ποσοστό του πλάτους της μπάρας ή στήλης. Όπως και η επικάλυψη, ανήκει στην γονική ομάδα σειρών παρά σε μία σειρά. Ορίστε την [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) μία φορά για την ομάδα. Μία μεγαλύτερη τιμή δημιουργεί περισσότερο χώρο μεταξύ των ομάδων· μια μικρότερη τιμή τις κάνει πιο πυκνές.

Το ακόλουθο παράδειγμα αλλάζει το πλάτος κενότητας και αποθηκεύει μόνο την τελική παρουσίαση:

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

![Το πλάτος κενότητας](gap_width.png)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποιοι τύποι γραφήματος υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι γραφήματος που αντιπροσωπεύονται από την απαρίθμηση [ChartType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/charttype/) χρησιμοποιούν δεδομένα γραφήματος, αλλά οι σειρές τους δεν έχουν όλες την ίδια δομή τιμών ή τις ίδιες ρυθμίσεις. Για παράδειγμα, τα γραφήματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα scatter χρησιμοποιούν τιμές X και Y, και τα bubble προσθέτουν μεγέθη φυσαλίδων. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει στον τύπο σειράς. Επιλογές όπως η επικάλυψη και το πλάτος κενότητας ισχύουν μόνο για συμβατές ομάδες μπάρες ή στήλες.

**Τι είναι μια ομάδα σειρών γραφήματος;**

Μια [ChartSeriesGroup](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseriesgroup/) περιλαμβάνει συμβατές σειρές που μοιράζονται ρυθμίσεις σχεδίασης επιπέδου ομάδας. Ένα συνδυαστικό γράφημα μπορεί να περιέχει περισσότερες από μία ομάδες, επομένως η αλλαγή της ομάδας μέσω μιας σειράς δεν αλλάζει κατ' ανάγκη όλες τις σειρές του γραφήματος.

**Δημιουργεί ένα νεοσυσταθέν γράφημα προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, η μέθοδος [ShapeCollection.add_chart](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_chart/) δημιουργεί δείγματα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να καθαρίσετε τόσο τις συλλογές σειρών όσο και κατηγοριών πριν προσθέσετε ένα πλήρως προσαρμοσμένο σύνολο δεδομένων. Μια υπερφόρτωση μπορεί επίσης να δημιουργήσει ένα γράφημα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα γραφήματος με κελιά βιβλίου εργασίας;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων παραπέμπουν σε κελιά ενός [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/). Η αλλαγή ενός κελιού που παραπέμπεται ενημερώνει το αντίστοιχο στοιχείο του γραφήματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, διατηρήστε τις γραμμές κατηγοριών και τις γραμμές τιμών σειρών ευθυγραμμισμένες ώστε κάθε σημείο να σχεδιάζεται κάτω από τη σωστή κατηγορία.

**Πώς μπορώ να αφαιρέσω ένα σημείο αντί ολόκληρης σειράς;**

Ορίστε το αντίστοιχο κελί τιμής σε `None` ώστε να διατηρηθεί η θέση κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε την [ChartDataPointCollection.clear](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapointcollection/clear/) μόνο όταν θέλετε να αφαιρέσετε όλα τα σημεία από τη σειρά. Εάν αφαιρείτε επίσης κατηγορίες, ενημερώστε όλες τις σειρές ώστε οι τιμές τους να παραμείνουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο του γραφήματος και την [Chart.display_blanks_as](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/display_blanks_as/). Τα υποστηριζόμενα γραφήματα μπορούν να εμφανίζουν κενά ως κενά, ως μηδενικές τιμές ή συνδέοντας τα γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει με το νόημα των ελλιπών δεδομένων στην παρουσίασή σας. Δείτε την ενότητα [Έλεγχος Εμφάνισης Κελιών χωρίς Δεδομένα](#control-the-display-of-empty-cells) για πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για υποστηριζόμενες σειρές μπάρες, στήλες και φυσαλίδες, ενεργοποιήστε την [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/invert_if_negative/) και ορίστε το [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Μπορείτε να υπερκαλύψετε τη συμπεριφορά για ένα μεμονωμένο σημείο με την [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Αυτές οι ιδιότητες επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση κυριαρχεί όταν τόσο η σειρά όσο και το σημείο μορφοποιούνται;**

Η ρητή μορφοποίηση σημείου δεδομένων έχει προτεραιότητα για εκείνο το σημείο. Τα υπόλοιπα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφοποίηση σειράς ή, όταν δεν ορίζεται, το αυτόματο στυλ και θέμα του γραφήματος. Οι ιδιότητες ομάδας όπως η επικάλυψη και το πλάτος κενότητας ελέγχουν τη διάταξη και δεν υπερκαλύπτουν τη μορφοποίηση επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα γράφημα;**

Το Aspose.Slides δεν επιβάλλει ξεχωριστό σταθερό όριο αριθμού σειρών. Στην πράξη, περιορισμοί του αρχείου παρουσίασης, διαθέσιμη μνήμη, χρόνος απόδοσης και αναγνωσιμότητα του γραφήματος καθορίζουν ένα πρακτικό όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά μεταξύ τους;**

Ορίστε την [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) στην κατάλληλη γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το διάστημα μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά.