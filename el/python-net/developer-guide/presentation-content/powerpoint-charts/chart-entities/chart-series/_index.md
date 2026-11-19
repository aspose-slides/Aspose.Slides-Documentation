---
title: Διαχείριση σειρών δεδομένων διαγράμματος σε παρουσιάσεις με Python
linktitle: Σειρές δεδομένων
type: docs
url: /el/python-net/chart-series/
keywords:
- σειρές διαγράμματος
- επικάλυψη σειρών
- χρώμα σειράς
- χρώμα κατηγορίας
- όνομα σειράς
- σημείο δεδομένων
- κενό σειράς
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε σειρές διαγράμματος, σημεία δεδομένων, κελιά βιβλίου εργασίας, μορφοποίηση, επικάλυψη, πλάτος κενών και αρνητικές τιμές σε παρουσιάσεις με Python."
---
## **Επισκόπηση**

Ένα διάγραμμα μπορεί να αποθηκεύσει τις σχεδιασμένες τιμές του σε κελιά βιβλίου εργασίας ή απευθείας ως αριθμητικούς λεκτικούς. Ένα [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) αντιπροσωπεύει ένα σύνολο σχετικών τιμών και κάθε [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) αντιπροσωπεύει ένα σημείο σε αυτή τη σειρά. Τα αντικείμενα [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται οι σειρές. Σε διαγράμματα που δημιουργούνται με προεπιλεγμένα δεδομένα, τα ονόματα των σειρών, οι κατηγορίες και οι τιμές σημείων χρησιμοποιούν αντικείμενα [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) από το βιβλίο εργασίας του διαγράμματος.

Για ένα τυπικό διάγραμμα κατηγορίας, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη γραμμή 0 για τα ονόματα σειρών, τη στήλη 0 για τα ονόματα κατηγοριών και τα υπόλοιπα κελιά για τις τιμές των σειρών. Οι δείκτες φύλλου, γραμμής και στήλης που περνούν στη μέθοδο [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) είναι μηδενικής βάσης. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα διάγραμμα με προεπιλεγμένα δεδομένα, αλλά μην υποθέτετε ότι κάθε υπάρχον διάγραμμα το χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, ελέγξτε τα κελιά που αναφέρονται από τις σειρές, τις κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου εργασίας.

Οι ρυθμίσεις του διαγράμματος έχουν τρία διαφορετικά πεδία εφαρμογής:

- Ρυθμίσεις σε επίπεδο σειράς, όπως η [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), καθορίζουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία μιας σειράς.
- Ρυθμίσεις σημείου δεδομένων, όπως η [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), παρακάμπτουν την εμφάνιση της σειράς για ένα σημείο.
- Ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στην ίδια [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/). Προσπελάστε την ομάδα μέσω της ιδιότητας [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) όταν χρειάζεται να ορίσετε επιλογές όπως η επικάλυψη ή το πλάτος κενών.

Όταν δεν οριστεί ρητά γέμιση σημείου ή σειράς, το στυλ και το θέμα του διαγράμματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχουν τόσο μορφοποίηση σειράς όσο και σημείου, η μορφοποίηση του σημείου έχει προτεραιότητα για εκείνο το σημείο.

![chart-series-powerpoint](chart-series-powerpoint.png)

Για ένα συγχωνευμένο κυλινδρικό διάγραμμα, δείτε πώς η [changing the 3D series type or bar shape](/slides/el/python-net/3d-chart/#change-the-3d-series-type-and-bar-shape) επηρεάζει την πρώτη σειρά.

## **Ορισμός τιμών σειράς χρησιμοποιώντας αριθμητικούς λεκτικούς**

Χρησιμοποιήστε αριθμητικούς λεκτικούς όταν οι τιμές των σειρών προέρχονται από δεδομένα ή υπολογισμούς της εφαρμογής και δεν χρειάζονται αναφορές σε κελιά φύλλου. Ορίστε το [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) σε [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) πριν αναθέσετε την [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) κάθε σημείου μέσω της μεθόδου [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/).

Η ρύθμιση της συλλογής ελέγχει τον τύπο πηγής όλων των τιμών σημείων σε αυτή τη σειρά. Η ιδιότητα [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) κάθε σημείου αναφέρει τον επιλεγμένο τύπο· αλλάξτε τον μέσω της ρύθμισης της συλλογής. Με το `WORKSHEET`, χρησιμοποιήστε το [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) για πρόσβαση στο αναφερόμενο κελί. Με το `DOUBLE_LITERALS`, χρησιμοποιήστε το `as_literal_double` για ανάγνωση ή εγγραφή του αριθμού απευθείας.

Το παρακάτω παράδειγμα δημιουργεί ένα γράφημα στήλης με προεπιλεγμένες σειρές και κατηγορίες, στη συνέχεια αναθέτει υπολογιζόμενες τιμές 10, 20, κ.λπ. στα υπάρχοντα σημεία της πρώτης σειράς. Αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει τις αποθηκευμένες τιμές.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

Ο τύπος πηγής τιμής σημείου είναι ξεχωριστός από το [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/), το οποίο προσδιορίζει τη διαμόρφωση του εσωτερικού ή εξωτερικού βιβλίου εργασίας του διαγράμματος. Η χρήση αριθμητικών λεκτικών δεν αφαιρεί αυτόματα το ενσωματωμένο βιβλίο εργασίας. Σε αυτό το παράδειγμα, το βιβλίο εργασίας παραμένει διαθέσιμο για τις ετικέτες κατηγοριών, τα ονόματα σειρών και τις άλλες σειρές. Δείτε το [Chart Workbook](/slides/el/python-net/chart-workbook/) για διαχείριση βιβλίου εργασίας.

Για διαγράμματα διασποράς και φυσαλίδων, ορίστε τα [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) και [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) ώστε να επιλέξετε τις πηγές για το [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) και το [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/). Τα διαγράμματα φυσαλίδων χρησιμοποιούν επίσης το [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) για το [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/). Ορίστε κάθε σχετική πηγή σε `DOUBLE_LITERALS` πριν αναθέσετε αριθμούς μέσω της ιδιότητας `as_literal_double` της τιμής.

## **Ορισμός επικάλυψης σειράς διαγράμματος**

Η [ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) αναφέρει πόσο οι μπάρες ή οι στήλες επικαλύπτονται σε ένα 2Δ διάγραμμα, από -100 έως 100 τοις εκατό. Είναι μια μόνο για ανάγνωση προβολή της ρύθμισης στην γονική ομάδα σειρών. Ορίστε το [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) για να ενημερώσετε κάθε συμβατή σειρά στην ομάδα. Αυτή η επιλογή εφαρμόζεται σε τύπους διαγραμμάτων που εμφανίζουν ομαδοποιημένες μπάρες ή στήλες· δεν επηρεάζει άσχετες ομάδες σειρών σε ένα συνδυαστικό διάγραμμα.

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

## **Αλλαγή χρώματος γεμίσματος σειράς**

Χρησιμοποιήστε την [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) για να ορίσετε το προεπιλεγμένο γέμισμα ολόκληρης μιας σειράς. Εάν ένα σημείο έχει ήδη ρητό γέμισμα, η ρύθμιση του [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) παρακάμπτει το γέμισμα της σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει ένα συμπαγές μπλε γέμισμα στην πρώτη σειρά:

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

Το όνομα μιας σειράς αποθηκεύεται στο βιβλίο δεδομένων του διαγράμματος και συνήθως εμφανίζεται στο υπόμνημα. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα συγκεντρωτικό διάγραμμα στήλης, το κελί B1 είναι στη γραμμή 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι ονομαστικές σταθερές στο παρακάτω παράδειγμα κάνουν αυτή τη δομή ρητή:

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

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη αναφέρεται από την ιδιότητα [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης γραμμής και στήλης σε υπάρχον διάγραμμα:

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

Ένα σύνθετο όνομα σειράς είναι χρήσιμο όταν το όνομα ενός προϊόντος και η περίοδος αναφοράς αποθηκεύονται σε ξεχωριστά κελιά βιβλίου εργασίας. Για παράδειγμα, μπορείτε να συνδυάσετε το `Product A` στο B1 και το `2026` στο C1 σε ένα ενιαίο όνομα σειράς ενώ διατηρείτε και τα δύο τμήματα συνδεδεμένα στα κελιά προέλευσής τους.

Χρησιμοποιήστε τη μέθοδο [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) για να ανακτήσετε την περιοχή ονομάτων, στη συνέχεια περάστε αυτή τη συλλογή στη [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). Το όρισμα `skip_hidden_cells` ελέγχει αν τα κρυφά κελιά συμπεριλαμβάνονται: το `True` τα εξαιρεί, ενώ το `False` τα περιλαμβάνει. Αυτό το παράδειγμα χρησιμοποιεί `False` για να συμπεριλάβει κάθε κελί στην περιοχή ονομάτων.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με μία σειρά και δύο σημεία δεδομένων. Τα κελιά B1:C1 παρέχουν μόνο το όνομα της σειράς· τα A2:A3 παρέχουν τις ετικέτες κατηγοριών, και τα B2:B3 παρέχουν τις αριθμητικές τιμές.

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

Το προκύπτον όνομα σειράς είναι `Product A 2026`, με κενό μεταξύ των δύο τιμών κελιών. Το υπόμνημα το εμφανίζει ως μία καταχώρηση για και τις δύο στήλες. Η εικόνα παρακάτω προέρχεται από την αποθηκευμένη παρουσίαση:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Λήψη αυτόματου χρώματος γεμίσματος σειράς**

Η μέθοδος [ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) επιστρέφει το χρώμα που υπολογίζεται από τον δείκτη σειράς και το στυλ του διαγράμματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν το γέμισμα της σειράς δεν έχει οριστεί ρητά. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν αναθέτει νέο γέμισμα.

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

## **Ορισμός αντίστροφου χρώματος γεμίσματος για σειρά διαγράμματος**

Για σειρές μπάρων, στηλών και φυσαλίδων, η [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) μπορεί να εμφανίζει αρνητικές τιμές με διαφορετικό γέμισμα. Ορίστε το κανονικό γέμισμα σειράς σε συμπαγές, ενεργοποιήστε την αντιστροφή και αναθέστε το χρώμα αρνητικής τιμής μέσω της ιδιότητας [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· μόνο το χρώμα εμφάνισής τους αλλάζει.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα διαγράμματος με μία σειρά. Η γραμμή 0 του φύλλου περιέχει το όνομα της σειράς, η στήλη 0 περιέχει τα ονόματα κατηγοριών και η στήλη 1 περιέχει τις τιμές:

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

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω της ιδιότητας [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Στο παρακάτω παράδειγμα, η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιημένη μόνο για το επιλεγμένο σημείο. Το σημείο επίσης ανατίθεται με αρνητική τιμή ώστε το εφέ να είναι ορατό:

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

Για να κάνετε ένα σημείο κενό χωρίς να αφαιρέσετε τα άλλα σημεία, ορίστε το υποκείμενο κελί του βιβλίου εργασίας σε `None`. Για ένα διάγραμμα στήλης, η σχεδιασμένη τιμή είναι διαθέσιμη μέσω της ιδιότητας [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). Το σημείο παραμένει στην ίδια θέση κατηγορίας, αλλά το διάγραμμα το θεωρεί κενό σύμφωνα με τις ρυθμίσεις κενών τιμών του διαγράμματος.

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

Τα διαγράμματα διασποράς χρησιμοποιούν ξεχωριστά κελιά X και Y, και τα διαγράμματα φυσαλίδων επίσης χρησιμοποιούν κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει την τιμή που θέλετε να αφαιρέσετε. Μην καλέσετε τη μέθοδο [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) όταν θέλετε να διατηρήσετε τα άλλα σημεία, επειδή αυτή η μέθοδος αφαιρεί όλα τα σημεία δεδομένων από τη συλλογή.

## **Έλεγχος εμφάνισης κενών κελιών**

Τα κρυφά κελιά που περιέχουν τιμές είναι ξεχωριστή κατάσταση από τα κενά κελιά. Για να συμπεριλάβετε ή να εξαιρέσετε δεδομένα από κρυφές γραμμές και στήλες φύλλου, δείτε την ενότητα [Include Data from Hidden Rows and Columns](/slides/el/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Κενό κελί βιβλίου εργασίας αντιπροσωπεύει δεδομένα που λείπουν· ένα κελί που περιέχει `0` αντιπροσωπεύει μια γνωστή αριθμητική τιμή. Ορίστε την ιδιότητα [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) σε `None` για να κάνετε το κελί κενό. Ένας αριθμητικός μηδενισμός παραμένει μηδέν ανεξάρτητα από τη ρύθμιση κενών κελιών.

Χρησιμοποιήστε τη μέθοδο [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) για να επιλέξετε πώς το διάγραμμα εμφανίζει τα κενά κελιά. Αυτή η ρύθμιση ισχύει για ολόκληρο το διάγραμμα. Αλλάζει τον τρόπο που τα κενά σχεδιάζονται, χωρίς να γεμίζει το κενό κελί του βιβλίου εργασίας με μηδέν ή με παρεμβαλλόμενη τιμή.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με μία σειρά, καθαρίζει την τιμή για την Ημέρα 3 και αποθηκεύει το ίδιο διάγραμμα με κάθε λειτουργία. Δεν απαιτείται αρχείο εισόδου. Το [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) χρησιμοποιεί φύλλο 0, στήλη 0 για ετικέτες κατηγοριών και στήλη 1 για τιμές· η γραμμή 0 περιέχει το όνομα της σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

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

Κάθε αρχείο εξόδου αποθηκεύει τη λειτουργία που είχε καθοριστεί πριν από την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για να αποθηκεύσετε μόνο μία έκδοση, ορίστε την επιθυμητή λειτουργία και αποθηκεύστε την παρουσίαση μία φορά αντί για επανάληψη στις λειτουργίες.

Η σύγκριση παρακάτω δείχνει τα ίδια δεδομένα και στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο εργασίας σε κάθε περίπτωση:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Το οπτικό αποτέλεσμα εξαρτάται από τον τύπο του διαγράμματος. Ένα διάγραμμα γραμμής κάνει όλες τις τρεις λειτουργίες εύκολα συγκρίσιμες. Τα διαγράμματα μπάρες και στήλες δεν έχουν γραμμή για σύνδεση μέσω μιας ελλιπούς κατηγορίας, οπότε το `SPAN` δεν μπορεί να παράγει το συνδετικό τμήμα που φαίνεται παραπάνω· μια ελλιπής στήλη και μια στήλη μηδενικού ύψους μπορεί επίσης να φαίνεται παρόμοια. Αντίστοιχα, ένα διάγραμμα διασποράς με μόνο δείκτες δεν έχει γραμμή σύνδεσης. Μην περιμένετε τρία ξεχωριστά αποτελέσματα για κάθε τύπο διαγράμματος· ελέγξτε το αποτέλεσμα για τον τύπο που χρησιμοποιείτε.

## **Ορισμός πλάτους κενών μεταξύ σειρών**

Το πλάτος κενών είναι ο χώρος μεταξύ παρακείμενων ομάδων μπάρων ή στηλών, εκφρασμένος ως ποσοστό του πλάτους της μπάρας ή της στήλης. Όπως και η επικάλυψη, ανήκει στην γονική ομάδα σειρών και όχι σε μία σειρά. Ορίστε το [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) μία φορά για την ομάδα. Μια μεγαλύτερη τιμή δημιουργεί περισσότερο χώρο μεταξύ των ομάδων· μια μικρότερη τιμή τις κάνει πιο πυκνές.

Το παρακάτω παράδειγμα αλλάζει το πλάτος κενών και αποθηκεύει μόνο την τελική παρουσίαση:

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

## **Εμφάνιση ή απόκρυψη γραμμών σειράς**

Οι γραμμές σειράς συνδέουν οπτικά σχετιζόμενα μέρη ενός διαγράμματος. Χρησιμοποιήστε την ιδιότητα [ChartSeriesGroup.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/has_series_lines/) για να τις εμφανίσετε ή να τις κρύψετε σε υποστηριζόμενα διαγράμματα στοίβαξης μπάρες και OfPie. Σε διαγράμματα στοίβαξης μπάρες και στήλες δύο διαστάσεων, συνδέουν τα αντίστοιχα όρια στοίβας μεταξύ κατηγοριών. Σε διαγράμματα Πίτας Πίτας και Μπάρες Πίτας, συνδέουν το κύριο γράφημα με το δευτερεύον. Αυτή η ρύθμιση δεν είναι γενικός σύνδεσμος για άλλους τύπους διαγραμμάτων.

Πρόσβαση στην ομάδα μέσω της ιδιότητας [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). Η ρύθμιση ισχύει για κάθε σειρά στην ομάδα. Η ιδιότητα [ChartSeries.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/has_series_lines/) είναι μόνο για ανάγνωση και αντανακλά τη ρύθμιση της γονικής ομάδας· αλλάξτε την ιδιότητα της ομάδας για να την ενημερώσετε.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα [ChartType.PIE_OF_PIE](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) με προεπιλεγμένα δεδομένα. Αποθηκεύει το ίδιο διάγραμμα με τις γραμμές σειράς ενεργοποιημένες και στη συνέχεια απενεργοποιημένες, παράγοντας δύο παρουσιάσεις για σύγκριση.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 400)
    series = chart.chart_data.series[0]
    series_group = series.parent_series_group

    series_group.has_series_lines = True
    presentation.save("series_lines_enabled.pptx", slides.export.SaveFormat.PPTX)

    series_group.has_series_lines = False
    presentation.save("series_lines_disabled.pptx", slides.export.SaveFormat.PPTX)
```

| Ενεργές γραμμές σειράς | Απενεργοποιημένες γραμμές σειράς |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| Οι δύο γραμμές συνδέουν την κύρια πίτα με τη δευτερεύουσα πίτα. | Και οι δύο πίτες παραμένουν ορατές, αλλά οι συνδετικές γραμμές είναι κρυμμένες. |

Οι γραμμές σειράς διαφέρουν από τις γραμμές οδηγού ετικετών δεδομένων, οι οποίες συνδέουν ετικέτες με τα σημεία δεδομένων· από τις γραμμές πλέγματος, που σημειώνουν διαστήματα κατά μήκος των αξόνων· και από τις γραμμές σε ένα διάγραμμα γραμμής, που αντιπροσωπεύουν τιμές δεδομένων. Αυτή η ρύθμιση δεν ελέγχει αυτά τα στοιχεία.

## **Συχνές ερωτήσεις**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι διαγραμμάτων που αντιπροσωπεύονται από την απαρίθμηση [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) χρησιμοποιούν δεδομένα διαγράμματος, αλλά οι σειρές τους δεν έχουν όλοι την ίδια δομή τιμών ή τις ίδιες ρυθμίσεις. Για παράδειγμα, τα διαγράμματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα διαγράμματα διασποράς χρησιμοποιούν τιμές X και Y, και τα διαγράμματα φυσαλίδων προσθέτουν μεγέθη φυσαλίδων. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που αντιστοιχεί στον τύπο της σειράς. Οι επιλογές όπως η επικάλυψη και το πλάτος κενών ισχύουν μόνο σε συμβατές ομάδες μπάρες ή στήλες.

**Τι είναι μια ομάδα σειρών διαγράμματος;**

Μια [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις ομαδοποιήσης. Ένα συνδυαστικό διάγραμμα μπορεί να περιέχει περισσότερες από μία ομάδες, οπότε η αλλαγή της ομάδας μέσω μιας σειράς δεν αλλάζει απαραίτητα όλες τις σειρές στο διάγραμμα.

**Μήπως ένα νεοδημιουργημένο διάγραμμα περιέχει προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, η μέθοδος [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) δημιουργεί δείγματα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να καθαρίσετε τόσο τις σειρές όσο και τις συλλογές κατηγοριών πριν προσθέσετε ένα πλήρως προσαρμοσμένο σύνολο δεδομένων. Υπάρχει επίσης υπερφόρτωση που μπορεί να δημιουργήσει διάγραμμα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα διαγράμματος με τα κελιά του βιβλίου εργασίας;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων αναφέρονται σε κελιά ενός [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). Η αλλαγή ενός αναφερθέντος κελιού ενημερώνει το αντίστοιχο στοιχείο του διαγράμματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, διατηρήστε τις γραμμές κατηγοριών και τις γραμμές τιμών σειρών ευθυγραμμισμένες ώστε κάθε σημείο να σχεδιάζεται κάτω από τη σωστή κατηγορία.

**Πώς μπορώ να καθαρίσω ένα σημείο αντί ολόκληρης σειράς;**

Ορίστε το σχετικό κελί τιμής σε `None` ώστε να διατηρηθεί η θέση της κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε τη μέθοδο [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) μόνο όταν θέλετε να αφαιρέσετε όλα τα σημεία από αυτή τη σειρά. Εάν αφαιρέσετε επίσης τις κατηγορίες, ενημερώστε όλες τις σειρές ώστε οι τιμές τους να παραμένουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο διαγράμματος και τη μέθοδο [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). Τα υποστηριζόμενα διαγράμματα μπορούν να εμφανίζουν κενά ως κενά, ως μηδενικές τιμές ή συνδέοντας τα γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει με το νόημα των ελλιπών δεδομένων στην παρουσίασή σας. Δείτε την ενότητα [Control the Display of Empty Cells](#control-the-display-of-empty-cells) για πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για υποστηριζόμενες σειρές μπάρες, στήλες και φυσαλίδες, ενεργοποιήστε την ιδιότητα [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) και ορίστε το [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Μπορείτε να παρακάμψετε τη συμπεριφορά για ένα μεμονωμένο σημείο με τη μέθοδο [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Αυτές οι ιδιότητες επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση νικά όταν τόσο η σειρά όσο και το σημείο έχουν μορφοποιηθεί;**

Η ρητή μορφοποίηση σημείου δεδομένων έχει προτεραιότητα για εκείνο το σημείο. Τα άλλα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφοποίηση σειράς ή, όταν η μορφοποίηση σειράς δεν ορίζεται, το αυτόματο στυλ και το θέμα του διαγράμματος. Οι ιδιότητες ομάδας όπως η επικάλυψη και το πλάτος κενών ελέγχουν τη διάταξη και δεν παρακάμπτουν τη μορφοποίηση επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα διάγραμμα;**

Το Aspose.Slides δεν επιβάλλει ξεχωριστό σταθερό όριο αριθμού σειρών. Στην πράξη, περιορισμοί του αρχείου παρουσίασης, η διαθέσιμη μνήμη, ο χρόνος απόδοσης και η αναγνωσιμότητα του διαγράμματος καθορίζουν ένα πρακτικό όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά;**

Ορίστε το [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) στην κατάλληλη γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το κενό μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά.