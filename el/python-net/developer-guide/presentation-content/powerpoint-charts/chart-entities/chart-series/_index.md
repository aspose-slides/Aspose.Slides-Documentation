---
title: Διαχείριση Σειρών Δεδομένων Διαγράμματος σε Παρουσιάσεις με Python
linktitle: Σειρές Δεδομένων
type: docs
url: /el/python-net/chart-series/
keywords:
- σειρά διαγράμματος
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

Ένα διάγραμμα αποθηκεύει τα σχεδιασμένα δεδομένα του σε ένα βιβλίο εργασίας δεδομένων διαγράμματος. Ένα [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) αντιπροσωπεύει ένα σύνολο σχετικών τιμών, και κάθε [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) στη σειρά παραπέμπει σε ένα ή περισσότερα κελιά του βιβλίου εργασίας. Τα αντικείμενα [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται από τις σειρές. Το όνομα της σειράς, οι κατηγορίες και οι τιμές των σημείων συνδέονται επομένως με αντικείμενα [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) αντί να αποθηκεύονται μόνο ως κείμενο εμφάνισης.

Για ένα τυπικό διάγραμμα κατηγορίας, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη γραμμή 0 για τα ονόματα σειρών, τη στήλη 0 για τα ονόματα κατηγοριών και τα υπόλοιπα κελιά για τις τιμές σειρών. Οι δείκτες φύλλου, γραμμής και στήλης που περνιούνται στο [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) είναι μηδενικής βάσης. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα διάγραμμα με προεπιλεγμένα δεδομένα, αλλά μην υποθέτετε ότι κάθε υπάρχον διάγραμμα το χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, επιθεωρήστε τα κελιά που παραπέμπουν στις σειρές, τις κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου εργασίας.

Οι ρυθμίσεις διαγράμματος έχουν τρεις διαφορετικές εμβέλειες:

- Ρυθμίσεις επιπέδου σειράς, όπως [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία μιας σειράς.
- Ρυθμίσεις σημείου δεδομένων, όπως [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), παρακάμπτουν την εμφάνιση της σειράς για ένα σημείο.
- Ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στο ίδιο [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/). Πρόσβαση στην ομάδα μέσω [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) όταν χρειάζεται να ορίσετε επιλογές όπως η επικάλυψη ή το εύρος κενών.

Όταν δεν έχει οριστεί ρητός γεμισμός σημείου ή σειράς, το στυλ και το θέμα του διαγράμματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχουν τόσο μορφοποίηση σειράς όσο και σημείου, η μορφοποίηση σημείου έχει προτεραιότητα για εκείνο το σημείο.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ορισμός επικάλυψης σειράς διαγράμματος**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) αναφέρει πόσο πολλά μπαρ ή στήλες επικαλύπτονται σε διάγραμμα 2D, από -100 έως 100 τοις εκατό. Είναι μια μόνο προς ανάγνωση προβολή της ρύθμισης στην γονική ομάδα σειράς. Ορίστε [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) για να ενημερώσετε κάθε συμβατή σειρά σε εκείνη την ομάδα. Αυτή η επιλογή εφαρμόζεται σε τύπους διαγράμματος που εμφανίζουν ομαδοποιημένα μπαρ ή στήλες· δεν επηρεάζει μη σχετικές ομάδες σειρών σε συνδυαστικό διάγραμμα.

Το παρακάτω παράδειγμα ορίζει την επικάλυψη για την ομάδα που περιέχει την πρώτη σειρά:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Η νέα γραφική παράσταση περιέχει δείγμα σειρών, κατηγορίες και τιμές.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The series overlap](series_overlap.png)

## **Αλλαγή χρώματος γεμίσματος σειράς**

Χρησιμοποιήστε [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) για να ορίσετε το προεπιλεγμένο γέμισμα μιας ολόκληρης σειράς. Εάν ένα σημείο διαθέτει ήδη ρητό γέμισμα, η ρύθμιση [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) παρακάμπτει το γέμισμα σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει γεμισμό στερεό μπλε στην πρώτη σειρά:

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

## **Αλλαγή ονόματος σειράς**

Το όνομα μιας σειράς αποθηκεύεται στο βιβλίο εργασίας δεδομένων διαγράμματος και συνήθως εμφανίζεται στο υπόμνημα. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα συγκεντρωτικό διάγραμμα στήλης, το κελί B1 βρίσκεται στη γραμμή 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι ονομαστικές σταθερές στο παρακάτω παράδειγμα κάνουν αυτή τη δομή σαφή:

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

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη παραπέμπει στο [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης γραμμής ή στήλης σε υπάρχον διάγραμμα:

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

### **Δημιουργία σειράς με όνομα από πολλαπλά κελιά**

Ένα σύνθετο όνομα σειράς είναι χρήσιμο όταν το όνομα προϊόντος και η περίοδος αναφοράς αποθηκεύονται σε ξεχωριστά κελιά του βιβλίου εργασίας. Για παράδειγμα, μπορείτε να συνδυάσετε `Product A` στο B1 και `2026` στο C1 σε ένα ενιαίο όνομα σειράς διατηρώντας και τα δύο τμήματα συνδεδεμένα με τα κελιά προέλευσής τους.

Χρησιμοποιήστε [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) για να ανακτήσετε την περιοχή ονομάτων, έπειτα περάστε αυτή τη συλλογή στο [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). Το όρισμα `skip_hidden_cells` ελέγχει εάν τα κρυφά κελιά περιλαμβάνονται: `True` τα εξαιρεί, ενώ `False` τα περιλαμβάνει. Αυτό το παράδειγμα χρησιμοποιεί `False` για να συμπεριλάβει κάθε κελί στην περιοχή ονομάτων.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με μία σειρά και δύο σημεία δεδομένων. Τα κελιά B1:C1 παρέχουν μόνο το όνομα σειράς· τα A2:A3 παρέχουν τις ετικέτες κατηγοριών, και τα B2:B3 παρέχουν τις αριθμητικές τιμές.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Αυτά τα δύο κελιά παρέχουν το όνομα της σειράς.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # Ξεχωριστά κελιά παρέχουν τις κατηγορίες και τα αριθμητικά σημεία δεδομένων.
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

Το παραγόμενο όνομα σειράς είναι `Product A 2026`, με κενό μεταξύ των δύο τιμών κελιών. Το υπόμνημα το εμφανίζει ως μία καταχώρηση για και τις δύο στήλες. Η εικόνα παρακάτω προέρχεται από την αποθηκευμένη παρουσίαση:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Λήψη αυτόματου χρώματος γεμίσματος σειράς**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) επιστρέ φει το χρώμα που υπολογίζεται από τον δείκτη σειράς και το στυλ διαγράμματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν το γέμισμα της σειράς δεν ορίζεται ρητά. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν εκχωρεί νέο γέμισμα.

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

## **Ορισμός αντιστροφής χρώματος γεμίσματος για σειρά διαγράμματος**

Για σειρές μπαρ, στήλης και φυσαλίδας, το [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) μπορεί να εμφανίζει τις αρνητικές τιμές με διαφορετικό γέμισμα. Ορίστε το κανονικό γέμισμα σειράς σε στερεό, ενεργοποιήστε την αντιστροφή και ορίστε το χρώμα αρνητικής τιμής μέσω [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· αλλάζει μόνο το χρώμα εμφάνισής τους.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα διαγράμματος με μία σειρά. Η γραμμή 0 του φύλλου περιέχει το όνομα σειράς, η στήλη 0 περιέχει τα ονόματα κατηγοριών, και η στήλη 1 περιέχει τις τιμές:

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

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Στο παρακάτω παράδειγμα, η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιείται μόνο για το επιλεγμένο σημείο. Στο σημείο έχει επίσης ανατεθεί αρνητική τιμή ώστε το εφέ να είναι ορατό:

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

## **Καθαρισμός συγκεκριμένης τιμής σημείου δεδομένων**

Για να κάνετε ένα σημείο κενό χωρίς να αφαιρέσετε τα άλλα σημεία, ορίστε το κελί του βιβλίου εργασίας σε `None`. Σε διάγραμμα στήλης, η σχεδιασμένη τιμή είναι διαθέσιμη μέσω [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). Το σημείο δεδομένων παραμένει στην ίδια θέση κατηγορίας, αλλά το διάγραμμα αντιμετωπίζει την τιμή του ως κενή σύμφωνα με τις ρυθμίσεις κενών τιμών του διαγράμματος.

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

Τα διαγράμματα διασποράς χρησιμοποιούν ξεχωριστά κελιά X και Y, και τα διαγράμματα φυσαλίδας επίσης χρησιμοποιούν κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει τη τιμή που θέλετε να αφαιρέσετε. Μην καλείτε το [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) όταν θέλετε να διατηρήσετε τα άλλα σημεία, επειδή αυτή η μέθοδος αφαιρεί όλα τα σημεία δεδομένων από τη συλλογή.

## **Έλεγχος εμφάνισης κελιών κενών**

Τα κρυφά κελιά που περιέχουν τιμές αποτελούν ξεχωριστή περίπτωση από τα κενά κελιά. Για να συμπεριλάβετε ή να εξαιρέσετε δεδομένα από κρυφές γραμμές και στήλες φύλλου, δείτε [Include Data from Hidden Rows and Columns](/slides/el/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Ένα κενό κελί βιβλίου εργασίας αντιπροσωπεύει δεδομένα που λείπουν· ένα κελί που περιέχει `0` αντιπροσωπεύει μια γνωστή αριθμητική τιμή. Ορίστε [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) σε `None` για να κάνετε το κελί κενό. Ένας αριθμητικός μηδενικός παραμένει μηδέν ανεξάρτητα από τη ρύθμιση κενών κυττάρων.

Χρησιμοποιήστε [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) για να επιλέξετε πώς το διάγραμμα εμφανίζει κενά κελιά. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρο το διάγραμμα. Αλλάζει τον τρόπο που τα κενά σχεδιάζονται, χωρίς να γεμίζει το κενό κελί του βιβλίου εργασίας με μηδέν ή με παρεμβαλλόμενη τιμή.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με μία σειρά, καθαρίζει την τιμή για την Ημέρα 3 και αποθηκεύει το ίδιο διάγραμμα με κάθε λειτουργία. Δεν απαιτείται αρχείο εισόδου. Το [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) χρησιμοποιεί το φύλλο 0, στήλη 0 για ετικέτες κατηγοριών και στήλη 1 για τιμές· η γραμμή 0 περιέχει το όνομα σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

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

    # Αφήστε την Ημέρα 3 πραγματικά κενή, ενώ διατηρείτε την κατηγορία και το σημείο δεδομένων.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Κάθε αρχείο εξόδου αποθηκεύει τη λειτουργία που εκχωρήθηκε πριν την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για να αποθηκεύσετε μόνο μία έκδοση, ορίστε τη ζητούμενη λειτουργία και αποθηκεύστε την παρουσίαση μία φορά αντί για επανάληψη σε όλες τις λειτουργίες.

Η σύγκριση παρακάτω δείχνει τα ίδια δεδομένα και στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο εργασίας σε κάθε περίπτωση:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Το οπτικό αποτέλεσμα εξαρτάται από τον τύπο διαγράμματος. Ένα διάγραμμα γραμμής καθιστά όλους τους τρεις τρόπους εύκολα συγκρίσιμους. Τα διαγράμματα μπαρ και στήλης δεν έχουν γραμμή για σύνδεση μεταξύ μιας χαμένης κατηγορίας, έτσι το `SPAN` δεν μπορεί να δημιουργήσει το συνδετικό τμήμα που φαίνεται πιο πάνω· μια χαμένη στήλη και μια στήλη μηδενικού ύψους μπορεί επίσης να φαίνονται παρόμοια. Ομοίως, ένα διάγραμμα διασποράς με μόνο δείκτες δεν έχει γραμμή σύνδεσης. Μην περιμένετε τρία διακριτά αποτελέσματα για κάθε τύπο διαγράμματος· ελέγξτε την έξοδο για τον τύπο που χρησιμοποιείτε.

## **Ορισμός πλάτους κενού μεταξύ σειρών**

Το πλάτος κενού είναι το κενό μεταξύ γειτονικών ομάδων μπαρ ή στήλης, εκφρασμένο ως ποσοστό του πλάτους του μπαρ ή της στήλης. Όπως και η επικάλυψη, ανήκει στην γονική ομάδα σειρών αντί σε μία σειρά. Ορίστε [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) μία φορά για την ομάδα. Μια μεγαλύτερη τιμή δημιουργεί περισσότερο χώρο μεταξύ των ομάδων· μια μικρότερη τιμή τις κάνει πιο πυκνές.

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

## **Συχνές ερωτήσεις**

**Ποιους τύπους διαγραμμάτων υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι διαγραμμάτων που αντιπροσωπεύονται από την απαρίθμηση [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) χρησιμοποιούν δεδομένα διαγράμματος, αλλά οι σειρές τους δεν έχουν όλες την ίδια δομή τιμών ή ρυθμίσεις. Για παράδειγμα, τα διαγράμματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα διαγράμματα διασποράς χρησιμοποιούν τιμές X και Y, και τα διαγράμματα φυσαλίδας προσθέτουν μεγέθη φυσαλίδας. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει με τον τύπο σειράς. Ρυθμίσεις όπως η επικάλυψη και το πλάτος κενού εφαρμόζονται μόνο σε συμβατές ομάδες μπαρ ή στήλης.

**Τι είναι μια ομάδα σειρών διαγράμματος;**

Μια [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις σχεδίασης επιπέδου ομάδας. Ένα συνδυαστικό διάγραμμα μπορεί να περιέχει περισσότερες από μία ομάδες, έτσι η αλλαγή της ομάδας που προέρχεται από μια σειρά δεν αλλάζει απαραίτητα κάθε σειρά στο διάγραμμα.

**Το νεοδημιουργημένο διάγραμμα περιέχει προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, το [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) δημιουργεί δείγματα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να καθαρίσετε τόσο τις συλλογές σειρών όσο και κατηγοριών πριν προσθέσετε ένα εντελώς προσαρμοσμένο σύνολο δεδομένων. Υπάρχει επίσης υπερφόρτωση που μπορεί να δημιουργήσει διάγραμμα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα διαγράμματος με κελιά βιβλίου εργασίας;**

Τα ονόματα σειρών, ετικέτες κατηγοριών και τιμές σημείων δεδομένων παραπέμπουν σε κελιά ενός [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). Η αλλαγή ενός κελιού που παραπέμπεται ενημερώνει το αντίστοιχο στοιχείο του διαγράμματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, διατηρήστε τις γραμμές κατηγοριών και τις γραμμές τιμών σειρών ευθυγραμμισμένες ώστε κάθε σημείο να σχεδιάζεται κάτω από την επιθυμητή κατηγορία.

**Πώς μπορώ να καθαρίσω ένα σημείο αντί ολόκληρης σειράς;**

Ορίστε το σχετικό κελί τιμής σε `None` για να διατηρήσετε τη θέση κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε το [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) μόνο όταν σκοπεύετε να αφαιρέσετε όλα τα σημεία από τη συγκεκριμένη σειρά. Εάν αφαιρείτε επίσης κατηγορίες, ενημερώστε όλες τις σειρές ώστε οι τιμές τους να παραμείνουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο διαγράμματος και το [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). Τα υποστηριζόμενα διαγράμματα μπορούν να εμφανίζουν κενά ως κενά, ως μηδενικές τιμές ή συνδέοντας γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει με τη σημασία των ελλειπόντων δεδομένων στην παρουσίασή σας. Δείτε την ενότητα [Control the Display of Empty Cells](#control-the-display-of-empty-cells) για πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για υποστηριζόμενες σειρές μπαρ, στήλης και φυσαλίδας, ενεργοποιήστε το [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) και ορίστε το [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Μπορείτε να παρακάμψετε τη συμπεριφορά για ένα μεμονωμένο σημείο με το [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Οι ιδιότητες αυτές επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση κυριαρχεί όταν τόσο η σειρά όσο και το σημείο μορφοποιούνται;**

Η ρητή μορφοποίηση σημείου δεδομένων έχει προτεραιότητα για εκείνο το σημείο. Τα άλλα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφοποίηση σειράς ή, όταν η μορφοποίηση σειράς δεν ορίζεται, το αυτόματο στυλ και θέμα του διαγράμματος. Οι ιδιότητες ομάδας όπως η επικάλυψη και το πλάτος κενού ελέγχουν τη διάταξη και δεν είναι παρακάμψεις μορφοποίησης επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα διάγραμμα;**

Το Aspose.Slides δεν επιβάλλει ξεχωριστό σταθερό όριο αριθμού σειρών. Στην πράξη, περιορισμοί του αρχείου παρουσίασης, διαθέσιμη μνήμη, χρόνος απόδοσης και η αναγνωσιμότητα του διαγράμματος καθορίζουν ένα πρακτικό όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά;**

Ορίστε το [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) στην αντίστοιχη γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το διάστημα μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά.