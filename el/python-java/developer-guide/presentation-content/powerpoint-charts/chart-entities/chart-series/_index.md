---
title: Διαχείριση Σειρών Δεδομένων Γραφήματος σε Παρουσιάσεις με Python
linktitle: Σειρές Δεδομένων
type: docs
url: /el/python-java/chart-series/
keywords:
- σειρές γραφήματος
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
description: "Μάθετε πώς να διαχειρίζεστε σειρές γραφήματος, σημεία δεδομένων, κελιά βιβλίου εργασίας, μορφοποίηση, επικάλυψη, πλάτος κενών και αρνητικές τιμές σε παρουσιάσεις με το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Ένα γράφημα αποθηκεύει τα σχεδιασμένα του δεδομένα σε ένα βιβλίο εργασίας δεδομένων γραφήματος. Ένα [ChartSeries](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/) αντιπροσωπεύει ένα σύνολο σχετικών τιμών, και κάθε [ChartDataPoint](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapoint/) στη σειρά αναφέρεται σε ένα ή περισσότερα κελιά του βιβλίου εργασίας. Τα αντικείμενα [ChartCategory](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται από τις σειρές. Το όνομα της σειράς, οι κατηγορίες και οι τιμές των σημείων συνδέονται επομένως με αντικείμενα [ChartDataCell](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/) αντί να αποθηκεύονται μόνο ως κείμενο εμφάνισης.

Για ένα τυπικό γράφημα κατηγορίας, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη σειρά 0 για ονόματα σειρών, τη στήλη 0 για ονόματα κατηγοριών και τα υπόλοιπα κελιά για τιμές σειρών. Οι δείκτες φύλλου, σειράς και στήλης που περνούν στο [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/#getCell) είναι μηδενικών βάσεων. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα γράφημα με προεπιλεγμένα δεδομένα, αλλά μην υποθέτετε ότι κάθε υπάρχον γράφημα τη χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, ελέγξτε τα κελιά που αναφέρονται από τις σειρές, τις κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου εργασίας.

Οι ρυθμίσεις γραφήματος έχουν τρία διαφορετικά πεδία εφαρμογής:

- Ρυθμίσεις σε επίπεδο σειράς, όπως [ChartSeries.getFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getFormat), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία σε μία σειρά.
- Ρυθμίσεις σημείου δεδομένων, όπως [ChartDataPoint.getFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapoint/#getFormat), παρακάμπτουν την εμφάνιση της σειράς για ένα σημείο.
- Ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στο ίδιο [ChartSeriesGroup](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/). Πρόσβαση στην ομάδα μέσω [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getParentSeriesGroup) όταν χρειάζεται να ορίσετε επιλογές όπως η επικάλυψη ή το πλάτος κενού.

Όταν δεν έχει οριστεί ρητό γέμισμα σημείου ή σειράς, το στυλ και το θέμα του γραφήματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχουν τόσο μορφοποίηση σειράς όσο και σημείου, η μορφοποίηση του σημείου έχει προτεραιότητα για εκείνο το σημείο.

![Γραφήματα σειράς σε PowerPoint](chart-series-powerpoint.png)

## **Ορισμός Επικάλυψης Σειράς Γραφήματος**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getOverlap) αναφέρει πόσο επικάλυπται μια μπάρα ή στήλη σε 2Δ γράφημα, από -100 έως 100 τοις εκατό. Είναι μια μόνο-ανάγνωση προβολή της ρύθμισης στην γονική ομάδα σειράς. Χρησιμοποιήστε [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/#setOverlap) για να ενημερώσετε κάθε συμβατή σειρά σε εκείνη την ομάδα. Αυτή η επιλογή ισχύει για τύπους γραφημάτων που εμφανίζουν ομαδοποιημένες μπάρες ή στήλες· δεν επηρεάζει ανεξάρτητες ομάδες σειρών σε συνδυαστικό γράφημα.

Το ακόλουθο παράδειγμα ορίζει την επικάλυψη για την ομάδα που περιέχει την πρώτη σειρά:

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

    # Το νέο γράφημα περιέχει δείγμα σειρών, κατηγοριών και τιμών.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Η επικάλυψη της σειράς](series_overlap.png)

## **Αλλαγή Χρώματος Γεμίσματος Σειράς**

Χρησιμοποιήστε [ChartSeries.getFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getFormat) για να ορίσετε το προεπιλεγμένο γέμισμα για ολόκληρη τη σειρά. Εάν ένα σημείο έχει ήδη ρητό γέμισμα, η ρύθμιση [ChartDataPoint.getFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapoint/#getFormat) παρακάμπτει το γέμισμα της σειράς για εκείνο το σημείο.

Το ακόλουθο παράδειγμα εφαρμόζει συμπαγές μπλε γέμισμα στην πρώτη σειρά:

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

![Το χρώμα της σειράς](series_color.png)

## **Αλλαγή Ονόματος Σειράς**

Ένα όνομα σειράς αποθηκεύεται στο βιβλίο εργασίας δεδομένων του γραφήματος και συνήθως εμφανίζεται στον υπόμνημα. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα γράφημα ομαδικών στηλών, το κελί B1 είναι στη σειρά 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι ονομαστικές μεταβλητές στο παρακάτω παράδειγμα κάνουν αυτή τη δομή σαφή:

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

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη αναφέρεται από το [ChartSeries.getName](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getName). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης σειράς και στήλης σε υπάρχον γράφημα:

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

![Το όνομα της σειράς](series_name.png)

## **Λήψη Αυτόματου Χρώματος Γεμίσματος Σειράς**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) επιστρέφει το χρώμα που υπολογίζεται από τον δείκτη της σειράς και το στυλ του γραφήματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν το γέμισμα της σειράς δεν είναι ρητά ορισμένο. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν ορίζει νέο γέμισμα.

Το παρακάτω παράδειγμα εκτυπώνει το αυτόματο χρώμα κάθε προεπιλεγμένης σειράς:

```python
import jpype
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

Παράδειγμα εξόδου για το προεπιλεγμένο στυλ γραφήματος:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Τα ακριβή χρώματα εξαρτώνται από το στυλ και το θέμα του γραφήματος.

## **Ορισμός Αντίστροφης Χρώματος Γεμίσματος για Σειρά Γραφήματος**

Για σειρές μπάρας, στήλης και φυσαλίδας, το [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#setInvertIfNegative) μπορεί να εμφανίσει αρνητικές τιμές με διαφορετικό γέμισμα. Ορίστε το κανονικό γέμισμα σειράς ως συμπαγές, ενεργοποιήστε την αντιστροφή και ορίστε το χρώμα αρνητικής τιμής μέσω του [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· αλλάζει μόνο το χρώμα εμφάνισης.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα γραφήματος με μία σειρά. Η σειρά 0 του φύλλου περιέχει το όνομα της σειράς, η στήλη 0 περιέχει τα ονόματα κατηγοριών, και η στήλη 1 περιέχει τις τιμές:

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

![Το αντίστροφο συμπαγές χρώμα γεμίσματος](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω του [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Στο παρακάτω παράδειγμα, η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιείται μόνο για το επιλεγμένο σημείο. Το σημείο έχει επίσης ανατεθεί σε αρνητική τιμή ώστε το εφέ να είναι ορατό:

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

## **Καθάρισμα Συγκεκριμένης Τιμής Σημείου Δεδομένων**

Για να κάνετε ένα σημείο κενό χωρίς να αφαιρέσετε τα άλλα σημεία, ορίστε το σχετικό κελί του βιβλίου εργασίας σε `None`. Για ένα γράφημα στήλης, η σχεδιασμένη τιμή είναι προσβάσιμη μέσω του [ChartDataPoint.getValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapoint/#getValue). Το σημείο δεδομένων παραμένει στην ίδια θέση κατηγορίας, αλλά το γράφημα το θεωρεί κενό σύμφωνα με τις ρυθμίσεις κενών τιμών του γραφήματος.

Το ακόλουθο παράδειγμα καθαρίζει μόνο το δεύτερο σημείο στην πρώτη σειρά:

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

Τα διασκορπισμένα γραφήματα χρησιμοποιούν ξεχωριστά κελιά X και Y, και τα γραφήματα φυσαλίδας επίσης χρησιμοποιούν κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει τη τιμή που θέλετε να αφαιρέσετε. Μην καλείτε το [ChartDataPointCollection.clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapointcollection/#clear) όταν θέλετε να διατηρήσετε τα υπόλοιπα σημεία, διότι αυτή η μέθοδος αφαιρεί όλα τα σημεία δεδομένων από τη συλλογή.

## **Έλεγχος Εμφάνισης Κελιών χωρίς Δεδομένα**

Κυρίως κρυμμένα κελιά που περιέχουν τιμές αποτελούν ξεχωριστή περίπτωση από τα κενά κελιά. Για να συμπεριλάβετε ή να εξαιρέσετε δεδομένα από κρυμμένες γραμμές και στήλες του φύλλου, δείτε την ενότητα [Συμπερίληψη Δεδομένων από Κρυμμένες Γραμμές και Στήλες](/slides/el/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Ένα κενό κελί του βιβλίου εργασίας αντιπροσωπεύει ελλιπή δεδομένα· ένα κελί που περιέχει `0` αντιπροσωπεύει μια γνωστή αριθμητική τιμή. Καλέστε το [ChartDataCell.setValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/#setValue) με `None` για να κάνετε ένα κελί κενό. Ένας αριθμητικός μηδέν παραμένει μηδέν ανεξαρτήτως της ρύθμισης κενών κελιών.

Χρησιμοποιήστε το [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#setDisplayBlanksAs) για να επιλέξετε πώς το γράφημα εμφανίζει τα κενά κελιά. Αυτή η ρύθμιση ισχύει για ολόκληρο το γράφημα. Αλλάζει τον τρόπο απεικόνισης των κενών, χωρίς να γεμίζει το κενό κελί με μηδέν ή παρεμβαλλόμενη τιμή.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα γράφημα γραμμής με μία σειρά, αφαιρεί την τιμή για την Ημέρα 3 και αποθηκεύει το ίδιο γράφημα με κάθε λειτουργία. Δεν απαιτείται αρχείο εισόδου. Το [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/) χρησιμοποιεί το φύλλο 0, στήλη 0 για ετικέτες κατηγοριών και στήλη 1 για τιμές· η σειρά 0 περιέχει το όνομα της σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Αφήστε την Ημέρα 3 πραγματικά κενή, ενώ διατηρείτε την κατηγορία και το σημείο δεδομένων.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Κάθε αρχείο εξόδου αποθηκεύει τη λειτουργία που είχε οριστεί πριν την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για να αποθηκεύσετε μόνο μία έκδοση, ορίστε τη ζητούμενη λειτουργία και αποθηκεύστε την παρουσίαση μία φορά αντί για επανάληψη σε όλες τις λειτουργίες.

Η σύγκριση παρακάτω δείχνει τα ίδια δεδομένα και στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο εργασίας σε κάθε περίπτωση:

![Γραφήματα γραμμής με πανομοιότυπα δεδομένα: Το Gap διακόπτει τη γραμμή στην Ημέρα 3, το Zero κατεβάζει τη γραμμή στο μηδέν, και το Span συνδέει την Ημέρα 2 με την Ημέρα 4.](display_blanks_as.png)

Το οπτικό αποτέλεσμα εξαρτάται από τον τύπο γραφήματος. Ένα γράφημα γραμμής κάνει εύκολη τη σύγκριση και των τριών λειτουργιών. Τα γραφήματα μπάρας και στήλης δεν έχουν γραμμή για σύνδεση μέσω ελλιπής κατηγορίας, έτσι το `Span` δεν μπορεί να δημιουργήσει το συνδετικό τμήμα που φαίνεται παραπάνω· μια ελλιπής στήλη και μια στήλη μηδενικού ύψους μπορούν επίσης να μοιάζουν. Ομοίως, ένα γράφημα διασποράς με δείκτες μόνο δεν έχει γραμμή σύνδεσης. Μην αναμένετε τρία διαφορετικά αποτελέσματα για κάθε τύπο γραφήματος· ελέγξτε την έξοδο για τον τύπο που χρησιμοποιείτε.

## **Ορισμός Πλάτους Κενού Μεταξύ Σειρών**

Το πλάτος κενού είναι ο χώρος μεταξύ γειτονικών ομάδων μπάρες ή στηλών, εκφρασμένο ως ποσοστό του πλάτους της μπάρας ή στήλης. Όπως και η επικάλυψη, ανήκει στην γονική ομάδα σειρών και όχι σε μεμονωμένη σειρά. Καλέστε το [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/#setGapWidth) μία φορά για την ομάδα. Μία μεγαλύτερη τιμή δημιουργεί περισσότερο χώρο μεταξύ των ομάδων· μία μικρότερη τιμή τους κάνει πιο πυκνά.

Το παρακάτω παράδειγμα αλλάζει το πλάτος κενού και αποθηκεύει μόνο την τελική παρουσίαση:

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

![Το πλάτος κενού](gap_width.png)

## **ΣΥΝΗΡΩΤΙΚΑ ΕΡΩΤΗΜΑΤΑ**

**Ποιους τύπους γραφημάτων υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι γραφημάτων που αντιπροσωπεύονται από την αρίθμηση [ChartType](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/) χρησιμοποιούν δεδομένα γραφήματος, αλλά οι σειρές τους δεν έχουν πάντα την ίδια δομή τιμών ή ρυθμίσεων. Για παράδειγμα, τα διαγράμματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα διαγράμματα διασποράς χρησιμοποιούν τιμές X και Y, και τα διαγράμματα φυσαλίδας προσθέτουν μεγέθη φυσαλίδων. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει με τον τύπο σειράς. Επιλογές όπως η επικάλυψη και το πλάτος κενού ισχύουν μόνο για συμβατές ομάδες μπάρας ή στήλης.

**Τι είναι μια ομάδα σειρών γραφήματος;**

Μια [ChartSeriesGroup](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις σχεδίασης σε επίπεδο ομάδας. Ένα συνδυαστικό γράφημα μπορεί να περιέχει περισσότερες από μία ομάδες, έτσι η αλλαγή της ομάδας μέσω μιας σειράς δεν αλλάζει απαραίτητα όλες τις σειρές του γραφήματος.

**Το νεοδημιούργητο γράφημα περιέχει προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, το [ShapeCollection.addChart](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addChart) δημιουργεί δείγμα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να καθαρίσετε τόσο τις συλλογές σειρών όσο και κατηγοριών πριν προσθέσετε ένα πλήρως προσαρμοσμένο σύνολο δεδομένων. Υπάρχει και υπερφόρτωση που μπορεί να δημιουργήσει γράφημα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα γραφήματος με κελιά βιβλίου εργασίας;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων αναφέρονται σε κελιά ενός [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/). Η αλλαγή ενός αναφερόμενου κελιού ενημερώνει το αντίστοιχο στοιχείο του γραφήματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, διατηρήστε τις γραμμές κατηγοριών και τις γραμμές τιμών σειρών ευθυγραμμισμένες ώστε κάθε σημείο να σχεδιάζεται κάτω από τη σωστή κατηγορία.

**Πώς καθαρίζω ένα σημείο αντί ολόκληρης σειράς;**

Ορίστε το σχετικό κελί τιμής σε `None` ώστε να διατηρηθεί η θέση κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε το [ChartDataPointCollection.clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapointcollection/#clear) μόνο όταν θέλετε να αφαιρέσετε όλα τα σημεία από τη σειρά. Εάν αφαιρείτε επίσης κατηγορίες, ενημερώστε κάθε σειρά ώστε οι τιμές τους παραμείνουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο γραφήματος και τη ρύθμιση που έχει καθοριστεί μέσω του [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#setDisplayBlanksAs). Τα υποστηριζόμενα γραφήματα μπορούν να εμφανίζουν κενά ως διαλείμματα, ως μηδενικές τιμές ή συνδέοντας τα γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει στο νόημα των ελλιπών δεδομένων στην παρουσίασή σας. Δείτε την ενότητα [Έλεγχος Εμφάνισης Κελιών χωρίς Δεδομένα](#control-the-display-of-empty-cells) για πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για τις υποστηριζόμενες σειρές μπάρας, στήλης και φυσαλίδας, καλέστε το [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#setInvertIfNegative) και ορίστε το χρώμα που επιστρέφει το [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Μπορείτε να παρακάμψετε τη συμπεριφορά για ένα επιμέρους σημείο με το [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Αυτές οι μέθοδοι επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση προτεραιότητας όταν τόσο η σειρά όσο και το σημείο είναι μορφοποιημένα;**

Η ρητή μορφοποίηση του σημείου δεδομένων έχει προτεραιότητα για εκείνο το σημείο. Τα υπόλοιπα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφοποίηση της σειράς ή, όταν η μορφοποίηση σειράς δεν είναι ορισμένη, το αυτόματο στυλ και θέμα του γραφήματος. Οι ρυθμίσεις ομάδας όπως η επικάλυψη και το πλάτος κενού ελέγχουν τη διάταξη και δεν αποτελούν παρακάμψεις μορφοποίησης σε επίπεδο σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα γράφημα;**

Το Aspose.Slides δεν επιβάλλει ξεχωριστό περιορισμό στον αριθμό σειρών. Στην πράξη, το περιοριστικό παράγοντα είναι το μέγεθος του αρχείου παρουσίασης, η διαθέσιμη μνήμη, ο χρόνος απόδοσης και η αναγνωσιμότητα του γραφήματος.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά μεταξύ τους;**

Καλέστε το [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/#setGapWidth) στη σχετική γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το κενό μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά.