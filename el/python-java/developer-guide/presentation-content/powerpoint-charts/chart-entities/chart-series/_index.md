---
title: Διαχείριση Σειρών Δεδομένων Διαγράμματος σε Παρουσιάσεις σε Python
linktitle: Σειρές Δεδομένων
type: docs
url: /el/python-java/chart-series/
keywords:
- σειρά διαγράμματος
- επικάλυψη σειράς
- χρώμα σειράς
- όνομα σειράς
- σημείο δεδομένων
- κελί βιβλίου εργασίας
- κενό σειράς
- αρνητική τιμή
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε σειρές διαγράμματος, σημεία δεδομένων, κελιά βιβλίου εργασίας, μορφοποίηση, επικάλυψη, πλάτος κενού και αρνητικές τιμές σε παρουσιάσεις με το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Ένα διάγραμμα αποθηκεύει τα δεδομένα που σχεδιάζει σε ένα βιβλίο δεδομένων διαγράμματος. Ένα [ChartSeries](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/) αντιπροσωπεύει ένα σύνολο συναφών τιμών, και κάθε [ChartDataPoint](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapoint/) στη σειρά αναφέρεται σε ένα ή περισσότερα κελιά του βιβλίου εργασίας. Τα αντικείμενα [ChartCategory](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται από τις σειρές. Το όνομα της σειράς, οι κατηγορίες και οι τιμές των σημείων συνδέονται επομένως με αντικείμενα [ChartDataCell](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/), αντί να αποθηκεύονται μόνο ως κείμενο εμφάνισης.

Για ένα τυπικό διάγραμμα κατηγορίας, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη σειρά 0 για τα ονόματα των σειρών, τη στήλη 0 για τα ονόματα των κατηγοριών και τα υπόλοιπα κελιά για τις τιμές των σειρών. Οι δείκτες φύλλου εργασίας, σειράς και στήλης που περνούν στο [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/#getCell) είναι μηδενικής βάσης. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα διάγραμμα με προεπιλεγμένα δεδομένα, αλλά μην υποθέτετε ότι κάθε υπάρχον διάγραμμα τη χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, επιθεωρήστε τα κελιά που αναφέρονται από τις σειρές, τις κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου εργασίας.

Οι ρυθμίσεις του διαγράμματος έχουν τρία διαφορετικά επίπεδα:

- Ρυθμίσεις επιπέδου σειράς, όπως το [ChartSeries.getFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getFormat), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία σε μία σειρά.
- Ρυθμίσεις σημείου δεδομένων, όπως το [ChartDataPoint.getFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapoint/#getFormat), αντικαθιστούν την εμφάνιση της σειράς για ένα σημείο.
- Ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στην ίδια [ChartSeriesGroup](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/). Πρόσβαση στην ομάδα μέσω του [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getParentSeriesGroup) όταν χρειάζεται να ορίσετε επιλογές όπως η επικάλυψη ή το πλάτος του κενού.

Όταν δεν έχει οριστεί ρητή γεμίσματος σημείου ή σειράς, το στυλ και το θέμα του διαγράμματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχουν τόσο μορφοποίηση σειράς όσο και σημείου, η μορφοποίηση του σημείου έχει προτεραιότητα για εκείνο το σημείο.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ορισμός Επικάλυψης Σειράς Διαγράμματος**

Το [ChartSeries.getOverlap](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getOverlap) αναφέρει πόσο επικαλύπτονται οι ράβδοι ή οι στήλες σε ένα 2Δ διάγραμμα, από -100 έως 100 τοις εκατό. Είναι μια μόνο για ανάγνωση προβολή της ρύθμισης στην γονική ομάδα σειρών. Χρησιμοποιήστε το [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/#setOverlap) για να ενημερώσετε κάθε συμβατή σειρά σε αυτήν την ομάδα. Αυτή η επιλογή εφαρμόζεται σε τύπους διαγραμμάτων που εμφανίζουν ομαδοποιημένους ράβδους ή στήλες· δεν επηρεάζει μη σχετικές ομάδες σειρών σε συνδυαστικό διάγραμμα.

Το παρακάτω παράδειγμα ορίζει την επικάλυψη για την ομάδα που περιέχει την πρώτη σειρά:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # Το νέο διάγραμμα περιέχει δείγματα σειρών, κατηγοριών και τιμών.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![The series overlap](series_overlap.png)

## **Αλλαγή Χρώματος Γεμίσματος Σειράς**

Χρησιμοποιήστε το [ChartSeries.getFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getFormat) για να ορίσετε το προεπιλεγμένο γέμισμα για ολόκληρη μια σειρά. Εάν ένα σημείο έχει ήδη ρητό γέμισμα, η ρύθμιση του [ChartDataPoint.getFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapoint/#getFormat) αντικαθιστά το γέμισμα της σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει ένα συμπαγές μπλε γέμισμα στην πρώτη σειρά:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![The color of the series](series_color.png)

## **Αλλαγή Ονόματος Σειράς**

Το όνομα μιας σειράς αποθηκεύεται στο βιβλίο δεδομένων του διαγράμματος και εμφανίζεται κανονικά στο υπόμνημα. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα σύμπλεγμα στηλών, το κελί B1 βρίσκεται στη σειρά 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι ονομαστικές μεταβλητές στο παρακάτω παράδειγμα κάνουν αυτήν τη δομή σαφή:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη αναφέρεται από το [ChartSeries.getName](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getName). Αυτή η προσέγγιση αποφεύγει την υπόθεση μιας συγκεκριμένης γραμμής και στήλης σε ένα υπάρχον διάγραμμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![The series name](series_name.png)

## **Λήψη Αυτόματο Χρώματος Γεμίσματος Σειράς**

Το [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) επιστρέφει το χρώμα που υπολογίζεται από το δείκτη της σειράς και το στυλ του διαγράμματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν το γέμισμα της σειράς δεν έχει οριστεί ρητά. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν αναθέτει νέο γέμισμα.

Το παρακάτω παράδειγμα εκτυπώνει το αυτόματο χρώμα κάθε προεπιλεγμένης σειράς:

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

Παράδειγμα εξόδου για το προεπιλεγμένο στυλ διαγράμματος:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Τα ακριβή χρώματα εξαρτώνται από το στυλ και το θέμα του διαγράμματος.

## **Ορισμός Αντιστροφικού Χρώματος Γεμίσματος για Σειρά Διαγράμματος**

Για σειρές ράβδων, στηλών και φυσαλίδων, το [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#setInvertIfNegative) μπορεί να εμφανίζει αρνητικές τιμές με διαφορετικό γέμισμα. Ορίστε το κανονικό γέμισμα της σειράς σε συμπαγές, ενεργοποιήστε την αντιστροφή και αναθέστε το χρώμα για τις αρνητικές τιμές μέσω του [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· μόνο το χρώμα εμφάνισής τους αλλάζει.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα διαγράμματος με μία σειρά. Η γραμμή 0 του φύλλου εργασίας περιέχει το όνομα της σειράς, η στήλη 0 περιέχει τα ονόματα των κατηγοριών και η στήλη 1 περιέχει τις τιμές:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![The inverted solid fill color](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω του [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Στο παρακάτω παράδειγμα, η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιείται μόνο για το επιλεγμένο σημείο. Στο σημείο έχει επίσης ανατεθεί μια αρνητική τιμή ώστε το αποτέλεσμα να είναι ορατό:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Καθαρισμός Συγκεκριμένης Τιμής Σημείου Δεδομένων**

Για να κάνετε ένα σημείο κενό χωρίς να αφαιρέσετε τα υπόλοιπα σημεία, ορίστε το αντίστοιχο κελί του βιβλίου εργασίας σε `None`. Για ένα διάγραμμα στήλης, η σχεδιασμένη τιμή είναι διαθέσιμη μέσω του [ChartDataPoint.getValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapoint/#getValue). Το σημείο παραμένει στην ίδια θέση κατηγορίας, αλλά το διάγραμμα θεωρεί την τιμή του ως κενή σύμφωνα με τις ρυθμίσεις κενών τιμών του διαγράμματος.

Το παρακάτω παράδειγμα καθαρίζει μόνο το δεύτερο σημείο στην πρώτη σειρά:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Τα διάγραμμα scatter χρησιμοποιούν ξεχωριστά κελιά X και Y, και τα διάγραμμα bubble χρησιμοποιούν επίσης κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει την τιμή που θέλετε να αφαιρέσετε. Μην καλέσετε το [ChartDataPointCollection.clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapointcollection/#clear) όταν θέλετε να διατηρήσετε τα άλλα σημεία, επειδή αυτή η μέθοδος αφαιρεί κάθε σημείο δεδομένων από τη συλλογή.

## **Έλεγχος Εμφάνισης Κελιών Κενών**

Ένα κενό κελί του βιβλίου εργασίας αντιπροσωπεύει ελλιπή δεδομένα· ένα κελί που περιέχει `0` αντιπροσωπεύει μια γνωστή αριθμητική τιμή. Καλέστε το [ChartDataCell.setValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/#setValue) με `None` για να κάνετε ένα κελί κενό. Ένα αριθμητικό μηδέν παραμένει μηδέν ανεξάρτητα από τη ρύθμιση κελιού κενής τιμής.

Χρησιμοποιήστε το [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#setDisplayBlanksAs) για να επιλέξετε πώς το διάγραμμα εμφανίζει κενά κελιά. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρο το διάγραμμα. Αλλάζει τον τρόπο που τα κενά σχεδιάζονται, χωρίς να γεμίζει το κενό κελί του βιβλίου εργασίας με μηδέν ή με παρεμβαλλόμενη τιμή.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με μία σειρά, καθαρίζει την τιμή για την Ημέρα 3 και αποθηκεύει το ίδιο διάγραμμα με κάθε λειτουργία. Δεν απαιτείται αρχείο εισόδου. Το [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/) χρησιμοποιεί το φύλλο εργασίας 0, τη στήλη 0 για ετικέτες κατηγοριών και τη στήλη 1 για τιμές· η σειρά 0 περιέχει το όνομα της σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpade.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Αφήστε την Ημέρα 3 πραγματικά κενή, διατηρώντας την κατηγορία και το σημείο δεδομένων.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Κάθε αρχείο εξόδου αποθηκεύει τη λειτουργία που ορίστηκε πριν την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για να αποθηκεύσετε μόνο μία έκδοση, ορίστε τη ζητούμενη λειτουργία και αποθηκεύστε την παρουσίαση μία φορά αντί να επαναλάβετε τις λειτουργίες.

Η σύγκριση παρακάτω εμφανίζει τα ίδια δεδομένα και στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο εργασίας σε κάθε περίπτωση:

![Διαγράμματα γραμμής με ίδια δεδομένα: το Gap διακόπτει τη γραμμή στην Ημέρα 3, το Zero κατεβάζει τη γραμμή στο μηδέν, και το Span συνδέει την Ημέρα 2 με την Ημέρα 4.](display_blanks_as.png)

Το οπτικό αποτέλεσμα εξαρτάται από τον τύπο του διαγράμματος. Ένα διάγραμμα γραμμής κάνει εύκολη τη σύγκριση και των τριών λειτουργιών. Τα διαγράμματα ράβδων και στηλών δεν έχουν γραμμή για σύνδεση μέσω μιας ελλιπής κατηγορίας, έτσι το `Span` δεν μπορεί να παράγει το τμήμα σύνδεσης που φαίνεται παραπάνω· μια ελλιπής στήλη και μια στήλη μηδενικού ύψους μπορούν επίσης να φαίνονται παρόμοια. Ομοίως, ένα διάγραμμα scatter με μόνο σημεία δεν έχει γραμμή σύνδεσης. Μην περιμένετε τρία διαφορετικά αποτελέσματα για κάθε τύπο διαγράμματος· ελέγξτε την έξοδο για τον τύπο που χρησιμοποιείτε.

## **Ορισμός Πλάτους Κενού Σειράς**

Το πλάτος κενού είναι η απόσταση μεταξύ γειτονικών ομάδων ράβδων ή στηλών, εκφρασμένη ως ποσοστό του πλάτους της ράβδου ή της στήλης. Όπως η επικάλυψη, ανήκει στην γονική ομάδα σειρών και όχι σε μία σειρά. Καλέστε το [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/#setGapWidth) μία φορά για την ομάδα. Μία μεγαλύτερη τιμή δημιουργεί περισσότερο χώρο μεταξύ των ομάδων· μία μικρότερη τιμή τις κάνει πιο πυκνές.

Το παρακάτω παράδειγμα αλλάζει το πλάτος του κενού και αποθηκεύει μόνο την τελική παρουσίαση:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![The gap width](gap_width.png)

## **Συχνές Ερωτήσεις**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι διαγραμμάτων που αντιπροσωπεύονται από την απαρίθμηση [ChartType](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/) χρησιμοποιούν δεδομένα διαγράμματος, αλλά οι σειρές τους δεν έχουν όλοι την ίδια δομή τιμών ή τις ίδιες ρυθμίσεις. Για παράδειγμα, τα διαγράμματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα διαγράμματα scatter χρησιμοποιούν τιμές X και Y, και τα διαγράμματα bubble προσθέτουν μεγέθη φυσαλίδων. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει με τον τύπο της σειράς. Επιλογές όπως η επικάλυψη και το πλάτος κενού ισχύουν μόνο για συμβατές ομάδες ράβδων ή στηλών.

**Τι είναι μια ομάδα σειρών διαγράμματος;**

Μια [ChartSeriesGroup](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις σχεδίασης επιπέδου ομάδας. Ένα συνδυαστικό διάγραμμα μπορεί να περιέχει περισσότερες από μία ομάδες, έτσι η αλλαγή της ομάδας που προσπερνάται μέσω μιας σειράς δεν αλλάζει απαραίτητα όλες τις σειρές στο διάγραμμα.

**Περιέχει ένα νέος δημιουργημένος διάγραμμα προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, το [ShapeCollection.addChart](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addChart) δημιουργεί δείγμα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να διαγράψετε και τις συλλογές σειρών και κατηγοριών πριν προσθέσετε ένα εντελώς προσαρμοσμένο σύνολο δεδομένων. Μια υπερφόρτωση μπορεί επίσης να δημιουργήσει διάγραμμα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα διαγράμματος με τα κελιά του βιβλίου εργασίας;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων αναφέρονται σε κελιά ενός [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/). Η αλλαγή ενός αναφερόμενου κελιού ενημερώνει το αντίστοιχο στοιχείο του διαγράμματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, διατηρήστε τις γραμμές κατηγοριών και τις γραμμές τιμών σειρών ευθυγραμμισμένες ώστε κάθε σημείο να σχεδιάζεται κάτω από την επιθυμητή κατηγορία.

**Πώς να καθαρίσω ένα σημείο αντί ολόκληρης της σειράς;**

Ορίστε το αντίστοιχο κελί τιμής σε `None` για να διατηρήσετε τη θέση κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε το [ChartDataPointCollection.clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapointcollection/#clear) μόνο όταν σκοπεύετε να αφαιρέσετε όλα τα σημεία από αυτήν τη σειρά. Εάν αφαιρέσετε και τις κατηγορίες, ενημερώστε κάθε σειρά ώστε οι τιμές τους να παραμένουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο του διαγράμματος και την τιμή που έχει ρυθμιστεί μέσω του [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#setDisplayBlanksAs). Τα υποστηριζόμενα διαγράμματα μπορούν να εμφανίζουν κενά ως κενά, ως μηδενικές τιμές ή συνδέοντας τα γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει με το νόημα των ελλιπών δεδομένων στην παρουσίασή σας. Δείτε το [Control the Display of Empty Cells](#control-the-display-of-empty-cells) για ένα πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για τις υποστηριζόμενες σειρές ράβδων, στηλών και φυσαλίδων, καλέστε το [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#setInvertIfNegative) και ορίστε το χρώμα που επιστρέφει το [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Μπορείτε να αντικαταστήσετε τη συμπεριφορά για ένα μεμονωμένο σημείο με το [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Αυτές οι μέθοδοι επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση προτεραιότητα όταν τόσο μια σειρά όσο και ένα σημείο μορφοποιούνται;**

Η ρητή μορφοποίηση σημείου δεδομένων έχει προτεραιότητα για αυτό το σημείο. Τα άλλα σημεία συνεχίζουν να χρησιμοποιούν την ρητή μορφοποίηση σειράς ή, όταν η μορφοποίηση σειράς δεν είναι ορισμένη, το αυτόματο στυλ και θέμα του διαγράμματος. Οι ρυθμίσεις ομάδας όπως η επικάλυψη και το πλάτος κενού ελέγχουν τη διάταξη και δεν είναι αντικαταστάσεις μορφοποίησης επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα διάγραμμα;**

Το Aspose.Slides δεν επιβάλλει ξεχωριστό σταθερό όριο αριθμού σειρών. Στην πράξη, οι περιορισμοί του αρχείου παρουσίασης, η διαθέσιμη μνήμη, ο χρόνος απόδοσης και η αναγνωσιμότητα του διαγράμματος καθορίζουν ένα πρακτικό όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά μεταξύ τους ή πολύ μακριά;**

Καλέστε το [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/#setGapWidth) στην κατάλληλη γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το χώρο μεταξύ των ομάδων, ή μειώστε τη για να φέρετε τις ομάδες πιο κοντά.