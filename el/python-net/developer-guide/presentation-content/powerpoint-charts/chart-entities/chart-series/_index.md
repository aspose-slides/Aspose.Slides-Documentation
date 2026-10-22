---
title: Διαχείριση Σειρών Δεδομένων Διαγράμματος σε Παρουσιάσεις σε Python
linktitle: Σειρές Δεδομένων
type: docs
url: /el/python-net/chart-series/
keywords:
- σειρά διαγράμματος
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
description: "Μάθετε πώς να διαχειριστείτε σειρές διαγράμματος, σημεία δεδομένων, κελιά βιβλίου εργασίας, μορφοποίηση, επικάλυψη, πλάτος κενών και αρνητικές τιμές σε παρουσιάσεις με Python."
---
## **Επισκόπηση**

Ένα διάγραμμα μπορεί να αποθηκεύει τις αποτυπωμένες τιμές του σε κελιά βιβλίου εργασίας ή απευθείας ως αριθμητικά λυτράλ. Ένα [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) αντιπροσωπεύει ένα σύνολο σχετικών τιμών, και κάθε [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) αντιπροσωπεύει ένα σημείο σε αυτή τη σειρά. Τα αντικείμενα [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται από τις σειρές. Σε διαγράμματα που δημιουργούνται με προεπιλεγμένα δεδομένα, τα ονόματα σειρών, οι κατηγορίες και οι τιμές σημείων χρησιμοποιούν αντικείμενα [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) από το βιβλίο εργασίας του διαγράμματος.

Για ένα τυπικό διάγραμμα κατηγοριών, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη γραμμή 0 για τα ονόματα σειρών, τη στήλη 0 για τα ονόματα κατηγοριών και τα υπόλοιπα κελιά για τις τιμές σειρών. Οι δείκτες φύλλου εργασίας, γραμμής και στήλης που περνιούνται στο [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) είναι μηδενικής βάσης. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα διάγραμμα με προεπιλεγμένα δεδομένα, αλλά μην υποθέτετε ότι κάθε υπάρχον διάγραμμα τη χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, εξετάστε τα κελιά στα οποία αναφέρονται οι σειρές, οι κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου εργασίας.

Οι ρυθμίσεις διαγράμματος έχουν τρία διαφορετικά πεδία εφαρμογής:

- Ρυθμίσεις επιπέδου σειράς, όπως η [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία μιας σειράς.
- Ρυθμίσεις σημείου δεδομένων, όπως η [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), παρακάμπτουν την εμφάνιση της σειράς για ένα σημείο.
- Ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στο ίδιο [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/). Πρόσβαση στην ομάδα μέσω του [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) όταν χρειάζεται να ορίσετε επιλογές όπως η επικάλυψη ή το πλάτος κενών.

Όταν δεν έχει οριστεί ρητή γεμίσματος σημείου ή σειράς, το στυλ και το θέμα του διαγράμματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχουν μορφοποιήσεις τόσο για τη σειρά όσο και για το σημείο, η μορφοποίηση του σημείου προτεραιότητα για εκείνο το σημείο.

![Διάγραμμα σειράς PowerPoint](chart-series-powerpoint.png)

## **Ορισμός Τιμών Σειρών Χρησιμοποιώντας Αριθμητικά Λυτράλ**

Χρησιμοποιήστε αριθμητικά λυτράλ όταν οι τιμές της σειράς προέρχονται από δεδομένα ή υπολογισμούς της εφαρμογής και δεν χρειάζονται αναφορές σε κελιά φύλλου εργασίας. Ορίστε το [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) σε [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) πριν αντιστοιχίσετε το [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) κάθε σημείου μέσω του [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/).

Η ρύθμιση της συλλογής ελέγχει τον τύπο προέλευσης όλων των τιμών σημείων σε αυτή τη σειρά. Ο τύπος [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) κάθε σημείου αναφέρει τον επιλεγμένο τύπο· αλλάξτε τον μέσω της ρύθμισης της συλλογής. Με `WORKSHEET`, χρησιμοποιήστε το [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) για πρόσβαση στο αναφερόμενο κελί. Με `DOUBLE_LITERALS`, χρησιμοποιήστε το `as_literal_double` για ανάγνωση ή εγγραφή του αριθμού απευθείας.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα στήλης με προεπιλεγμένες σειρές και κατηγορίες, στη συνέχεια αντιστοιχίζει υπολογισμένες τιμές 10, 20 κ.ο.κ. στα υπάρχοντα σημεία της πρώτης σειράς. Αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει τις αποθηκευμένες τιμές.

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

Ο τύπος προέλευσης της τιμής σημείου είναι ξεχωριστός από το [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/), το οποίο προσδιορίζει τη διαμόρφωση εσωτερικού ή εξωτερικού βιβλίου εργασίας του διαγράμματος. Η χρήση αριθμητικών λυτράλ δεν αφαιρεί από μόνη της το ενσωματωμένο βιβλίο εργασίας. Σε αυτό το παράδειγμα, το βιβλίο εργασίας παραμένει διαθέσιμο για ετικέτες κατηγοριών, ονόματα σειρών και τις άλλες σειρές. Δείτε το [Chart Workbook](/slides/el/python-net/chart-workbook/) για διαχείριση βιβλίου εργασίας.

Για διαγράμματα διασποράς και φυσαλίδων, ορίστε το [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) και το [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) για επιλογή των πηγών για το [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) και το [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/). Τα διαγράμματα φυσαλίδων επίσης χρησιμοποιούν το [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) για το [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/). Ορίστε κάθε σχετική πηγή σε `DOUBLE_LITERALS` πριν αντιστοιχίσετε αριθμούς μέσω της ιδιότητας `as_literal_double` της τιμής.

## **Ορισμός Επικάλυψης Σειρών Διαγράμματος**

Η [ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) αναφέρει πόσο επωλύονται ράβδοι ή στήλες σε 2Δ διάγραμμα, από -100 έως 100 τοις εκατό. Είναι μια ανάγνωση‑μόνο προβολή της ρύθμισης στην γονική ομάδα σειράς. Ορίστε το [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) για ενημέρωση όλων των συμβατών σειρών στην ομάδα. Αυτή η επιλογή ισχύει για τύπους διαγραμμάτων που εμφανίζουν ομαδοποιημένους ράβδους ή στήλες· δεν επηρεάζει ανεξάρτητες ομάδες σειρών σε συνδυαστικό διάγραμμα.

Το παρακάτω παράδειγμα ορίζει την επικάλυψη για την ομάδα που περιέχει την πρώτη σειρά:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Το νέο διάγραμμα περιέχει δείγματικές σειρές, κατηγορίες και τιμές.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η επικάλυψη των σειρών](series_overlap.png)

## **Αλλαγή Χρώματος Γέμισης Σειράς**

Χρησιμοποιήστε το [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) για ορισμό της προεπιλεγμένης γέμισης ολόκληρης της σειράς. Εάν ένα σημείο έχει ρητή γέμιση, η ρύθμιση του [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) παρακάμπτει τη γέμιση της σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει συμπαγή μπλε γέμιση στην πρώτη σειρά:

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

Το όνομα μιας σειράς αποθηκεύεται στο βιβλίο δεδομένων του διαγράμματος και συνήθως εμφανίζεται στο υπόμυχο. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα ομαδοποιημένο διάγραμμα στήλης, το κελί B1 βρίσκεται στη γραμμή 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι σταθερές ονομασίας στο παρακάτω παράδειγμα καθιστούν αυτή τη δομή ρητή:

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

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη αναφέρεται από το [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης γραμμής και στήλης σε υπάρχον διάγραμμα:

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

### **Δημιουργία Σειράς με Όνομα από Πολλαπλά Κελιά**

Ένα σύνθετο όνομα σειράς είναι χρήσιμο όταν το όνομα προϊόντος και η περίοδος αναφοράς αποθηκεύονται σε ξεχωριστά κελιά του βιβλίου εργασίας. Για παράδειγμα, μπορείτε να συνδυάσετε το `Product A` στο B1 και το `2026` στο C1 σε ένα ενιαίο όνομα σειράς διατηρώντας και τα δύο μέρη συνδεδεμένα με τα πηγαία κελιά.

Χρησιμοποιήστε το [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) για ανάκτηση της περιοχής ονομάτων, έπειτα περάστε τη συλλογή στο [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). Το όρισμα `skip_hidden_cells` ελέγχει εάν τα κρυφά κελιά συμπεριλαμβάνονται: `True` τα εξαιρεί, ενώ `False` τα περιλαμβάνει. Το παράδειγμα αυτό χρησιμοποιεί `False` για να συμπεριλάβει όλα τα κελιά στην περιοχή ονομάτων.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με μια σειρά και δύο σημεία δεδομένων. Τα κελιά B1:C1 παρέχουν μόνο το όνομα της σειράς· τα A2:A3 παρέχουν τις ετικέτες κατηγοριών, και τα B2:B3 παρέχουν τις αριθμητικές τιμές.

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

    # Ξεχωριστά κελιά παρέχουν τις κατηγορίες και τις αριθμητικές τιμές σημείων δεδομένων.
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

Το προκύπτον όνομα σειράς είναι `Product A 2026`, με κενό μεταξύ των δύο τιμών κελιών. Το υπόμυχο το εμφανίζει ως μία καταχώρηση και για τις δύο στήλες. Η εικόνα παρακάτω προέρχεται από την αποθηκευμένη παρουσίαση:

![Διάγραμμα στήλης με τιμές Βορρά και Νότου και το σύνθετο όνομα σειράς Product A 2026 στο υπόμυχο](composite_series_name.png)

## **Λήψη Αυτόματου Χρώματος Γέμισης Σειράς**

Η μέθοδος [ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) επιστρέφει το χρώμα που υπολογίζεται από τον δείκτη της σειράς και το στυλ του διαγράμματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν η γέμιση της σειράς δεν έχει οριστεί ρητά. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν ορίζει νέα γέμιση.

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

Αποτέλεσμα παραδείγματος για το προεπιλεγμένο στυλ διαγράμματος:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Τα ακριβή χρώματα εξαρτώνται από το στυλ και το θέμα του διαγράμματος.

## **Ορισμός Αντίστροφης Γέμισης για Σειρά Διαγράμματος**

Για σειρές ράβδων, στηλών και φυσαλίδων, η [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) μπορεί να εμφανίζει αρνητικές τιμές με διαφορετική γέμιση. Ορίστε τη συνήθη γέμιση σειράς σε συμπαγή, ενεργοποιήστε την αντιστροφή και ορίστε το χρώμα για αρνητικές τιμές μέσω του [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· μόνο το χρώμα εμφάνισής τους αλλάζει.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα διαγράμματος με μία σειρά. Η γραμμή 0 του φύλλου περιέχει το όνομα της σειράς, η στήλη 0 περιέχει τα ονόματα κατηγοριών, και η στήλη 1 περιέχει τις τιμές:

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

![Η αντίστροφη συμπαγής γέμιση χρώματος](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω του [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Στο παρακάτω παράδειγμα, η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιημένη μόνο για το επιλεγμένο σημείο. Στο σημείο έχει επίσης οριστεί αρνητική τιμή ώστε το εφέ να είναι ορατό:

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

Για να αδειάσετε ένα σημείο χωρίς να αφαιρέσετε τα υπόλοιπα, ορίστε το σχετικό κελί βιβλίου εργασίας σε `None`. Σε διάγραμμα στήλης, η αποτυπωμένη τιμή είναι διαθέσιμη μέσω του [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). Το σημείο παραμένει στην ίδια θέση κατηγορίας, αλλά το διάγραμμα θεωρεί την τιμή του κενή σύμφωνα με τις ρυθμίσεις κενών τιμών του διαγράμματος.

Το παρακάτω παράδειγμα αφαιρεί μόνο το δεύτερο σημείο στην πρώτη σειρά:

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

Τα διαγράμματα διασποράς χρησιμοποιούν ξεχωριστά κελιά X και Y, ενώ τα διαγράμματα φυσαλίδων χρησιμοποιούν επίσης κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει την τιμή που θέλετε να αφαιρέσετε. Μην καλέσετε το [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) όταν θέλετε να διατηρήσετε τα υπόλοιπα σημεία, επειδή αυτή η μέθοδος αφαιρεί όλα τα σημεία δεδομένων από τη συλλογή.

## **Έλεγχος Εμφάνισης Κενών Κελιών**

Κρυφά κελιά που περιέχουν τιμές αποτελούν ξεχωριστή περίπτωση από τα κενά κελιά. Για να συμπεριλάβετε ή να εξαιρέσετε δεδομένα από κρυφές γραμμές και στήλες φύλλου εργασίας, δείτε την ενότητα [Include Data from Hidden Rows and Columns](/slides/el/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Ένα κενό κελί βιβλίου εργασίας αντιπροσωπεύει ελλιπή δεδομένα· ένα κελί που περιέχει `0` αντιπροσωπεύει μια γνωστή αριθμητική τιμή. Ορίστε το [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) σε `None` για να κάνετε το κελί κενό. Ένας αριθμητικός μηδενικός παραμένει μηδενικός ανεξαρτήτως της ρύθμισης κενών κελιών.

Χρησιμοποιήστε το [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) για επιλογή του τρόπου εμφάνισης των κενών κελιών από το διάγραμμα. Αυτή η ρύθμιση ισχύει για ολόκληρο το διάγραμμα. Αλλάζει τον τρόπο απεικόνισης των κενών, χωρίς να γεμίζει το κενό κελί με μηδέν ή παρεμβαλλόμενη τιμή.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με μία σειρά, αφαιρεί την τιμή για την Ημέρα 3 και αποθηκεύει το ίδιο διάγραμμα με κάθε λειτουργία. Δεν απαιτείται αρχείο εισόδου. Το [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) χρησιμοποιεί το φύλλο 0, στήλη 0 για ετικέτες κατηγοριών και στήλη 1 για τιμές· η γραμμή 0 περιέχει το όνομα της σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

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

Κάθε αρχείο εξόδου αποθηκεύει τη λειτουργία που είχε οριστεί πριν την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για αποθήκευση μόνο μιας έκδοσης, ορίστε την επιθυμητή λειτουργία και αποθηκεύστε την παρουσίαση μία φορά αντί για επανάληψη των λειτουργιών.

Η παρακάτω σύγκριση δείχνει τα ίδια δεδομένα και στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο εργασίας σε κάθε περίπτωση:

![Γραφήματα γραμμής με ταυτόσημα δεδομένα: Το Gap κόβει τη γραμμή στην Ημέρα 3, το Zero κατεβάζει τη γραμμή στο μηδέν, και το Span συνδέει την Ημέρα 2 με την Ημέρα 4.](display_blanks_as.png)

Το οπτικό αποτέλεσμα εξαρτάται από τον τύπο διαγράμματος. Ένα διάγραμμα γραμμής καθιστά εύκολη τη σύγκριση των τριών λειτουργιών. Τα διαγράμματα ράβδων και στηλών δεν έχουν γραμμή για σύνδεση μέσω ελλιπούς κατηγορίας, έτσι το `SPAN` δεν μπορεί να δημιουργήσει το συνδετικό τμήμα που εμφανίζεται παραπάνω· μια ελλιπής στήλη και μια στήλη μηδενικού ύψους μπορούν επίσης να φαίνονται όμοια. Ομοίως, ένα διάγραμμα διασποράς μόνο με δείκτες δεν έχει γραμμή σύνδεσης. Μην αναμένετε τρία διαφορετικά αποτελέσματα για κάθε τύπο διαγράμματος· ελέγξτε την έξοδο για τον τύπο που χρησιμοποιείτε.

## **Ορισμός Πλάτους Κενών Μεταξύ Σειρών**

Το πλάτος κενών είναι το διάστημα μεταξύ γειτονικών ομάδων ράβδων ή στηλών, εκφρασμένο ως ποσοστό του πλάτους της ράβδου ή στήλης. Όπως και η επικάλυψη, ανήκει στην γονική ομάδα σειρών αντί σε μία σειρά. Ορίστε το [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) μία φορά για την ομάδα. Μία μεγαλύτερη τιμή δημιουργεί περισσότερο χώρο μεταξύ των ομάδων· μία μικρότερη τιμή τους κάνει πιο πυκνές.

Το παρακάτω παράδειγμα αλλάζει το πλάτος κενών και αποθηκεύει μόνο η τελική παρουσίαση:

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

![Το πλάτος κενών](gap_width.png)

## **ΣΥΝΕΧΕΣ ΕΡΩΤΗΜΑΤΑ**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι διαγραμμάτων που αντιπροσωπεύονται από την απαρίθμηση [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) χρησιμοποιούν δεδομένα διαγράμματος, αλλά οι σειρές τους δεν έχουν όλα την ίδια δομή τιμών ή ρυθμίσεις. Για παράδειγμα, τα διαγράμματα κατηγοριών χρησιμοποιούν κατηγορίες και τιμές, τα διαγράμματα διασποράς χρησιμοποιούν τιμές X και Y, και τα διαγράμματα φυσαλίδων προσθέτουν μεγέθη φυσαλίδων. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει με τον τύπο σειράς. Επιλογές όπως η επικάλυψη και το πλάτος κενών ισχύουν μόνο για συμβατές ομάδες ράβδων ή στηλών.

**Τι είναι μια ομάδα σειρών διαγράμματος;**

Μία [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις σχεδίασης επιπέδου ομάδας. Ένα συνδυαστικό διάγραμμα μπορεί να περιέχει περισσότερες από μία ομάδες, έτσι η αλλαγή της ομάδας μέσω μιας σειράς δεν αλλάζει απαραίτητα όλες τις σειρές στο διάγραμμα.

**Δημιουργεί το νέο διάγραμμα προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, η μέθοδος [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) δημιουργεί δείγματες σειρές, κατηγορίες και τιμές. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να καθαρίσετε τόσο τις συλλογές σειρών όσο και τις κατηγορίες πριν προσθέσετε ένα προσαρμοσμένο σύνολο δεδομένων. Υπάρχει υπερφόρτωση που μπορεί επίσης να δημιουργήσει διάγραμμα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα διαγράμματος με κελιά βιβλίου εργασίας;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων αναφέρονται σε κελιά ενός [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). Η αλλαγή ενός αναφερόμενου κελιού ενημερώνει το αντίστοιχο στοιχείο του διαγράμματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, διατηρήστε ευθυγραμμισμένες τις γραμμές κατηγοριών και τις γραμμές τιμών σειρών ώστε κάθε σημείο να αποτυπώνεται κάτω από την επιθυμητή κατηγορία.

**Πώς να καθαρίσω ένα σημείο αντί για όλη τη σειρά;**

Ορίστε το σχετικό κελί τιμής σε `None` για να διατηρήσετε τη θέση της κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε το [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) μόνο όταν θέλετε να αφαιρέσετε όλα τα σημεία από τη σειρά. Εάν αφαιρείτε και τις κατηγορίες, ενημερώστε όλες τις σειρές ώστε οι τιμές τους να παραμείνουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο διαγράμματος και το [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). Τα υποστηριζόμενα διαγράμματα μπορούν να εμφανίζουν κενά ως κενά, ως μηδενικές τιμές ή συνδέοντας τα γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει στη σημασία των ελλιπών δεδομένων στην παρουσίασή σας. Δείτε το τμήμα [Control the Display of Empty Cells](#control-the-display-of-empty-cells) για πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για τις υποστηριζόμενες σειρές ράβδων, στηλών και φυσαλίδων, ενεργοποιήστε το [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) και ορίστε το [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Μπορείτε να παρακάμψετε τη συμπεριφορά για ένα επιμέρους σημείο με το [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Αυτές οι ιδιότητες επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση υπερισχύει όταν τόσο η σειρά όσο και το σημείο έχουν μορφοποίηση;**

Η ρητή μορφοποίηση σημείου δεδομένων έχει προτεραιότητα για εκείνο το σημείο. Τα υπόλοιπα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφοποίηση της σειράς ή, όταν δεν έχει οριστεί η μορφοποίηση σειράς, το αυτόματο στυλ και θέμα του διαγράμματος. Οι ιδιότητες ομάδας όπως η επικάλυψη και το πλάτος κενών ελέγχουν τη διάταξη και δεν είναι παρακάμψεις μορφοποίησης επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα διάγραμμα;**

Η Aspose.Slides δεν επιβάλλει ξεχωριστό σταθερό όριο αριθμού σειρών. Στην πράξη, περιορισμοί του αρχείου παρουσίασης, διαθέσιμη μνήμη, χρόνος απόδοσης και αναγνωσιμότητα του διαγράμματος καθορίζουν ένα πρακτικό όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά;**

Ορίστε το [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) στην κατάλληλη γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το διάστημα μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά μεταξύ τους.