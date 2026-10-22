---
title: Διαχείριση Σειρών Δεδομένων Γραφήματος σε Παρουσιάσεις με Python
linktitle: Σειρές Δεδομένων
type: docs
url: /el/python-java/chart-series/
keywords:
- σειρές γραφήματος
- επικάλυψη σειρών
- χρώμα σειράς
- όνομα σειράς
- σημείο δεδομένων
- κελί βιβλίου εργασίας
- διάστημα σειράς
- αρνητική τιμή
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις σειρές γραφήματος, τα σημεία δεδομένων, τα κελιά βιβλίου εργασίας, τη μορφοποίηση, την επικάλυψη, το πλάτος κενών και τις αρνητικές τιμές σε παρουσιάσεις με Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Ένα γράφημα μπορεί να αποθηκεύει τις σχεδιασμένες τιμές του σε κελιά βιβλίου εργασίας ή απευθείας ως αριθμητικά λήμματα. Ένα [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) αντιπροσωπεύει ένα σύνολο σχετικών τιμών, και κάθε [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) αντιπροσωπεύει ένα σημείο σε αυτή τη σειρά. Τα αντικείμενα [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται οι σειρές. Σε γραφήματα που δημιουργούνται με προεπιλεγμένα δεδομένα, τα ονόματα σειρών, οι κατηγορίες και οι τιμές σημείων χρησιμοποιούν αντικείμενα [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) από το βιβλίο εργασίας του γραφήματος.

Για ένα τυπικό γράφημα κατηγορίας, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη γραμμή 0 για τα ονόματα σειρών, τη στήλη 0 για τα ονόματα κατηγοριών και τα υπόλοιπα κελιά για τις τιμές σειρών. Οι δείκτες Worksheet, γραμμής και στήλης που περνούν στο [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) είναι μηδενικής βάσης. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα γράφημα με προεπιλεγμένα δεδομένα, αλλά μην υποθέτετε ότι κάθε υπάρχον γράφημα το χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, ελέγξτε τα κελιά στα οποία αναφέρονται οι σειρές, οι κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου εργασίας.

Οι ρυθμίσεις του γραφήματος έχουν τρία διαφορετικά πεδία:

- Ρυθμίσεις επιπέδου σειράς, όπως [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία σε μια σειρά.
- Ρυθμίσεις σημείου δεδομένων, όπως [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat), παρακάμπτουν την εμφάνιση της σειράς για ένα σημείο.
- Ρυθμίσεις ομάδας ισχύουν για συμβατές σειρές που ανήκουν στην ίδια [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/). Πρόσβαση στην ομάδα μέσω του [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) όταν χρειάζεται να ορίσετε επιλογές όπως η επικάλυψη ή το πλάτος κενών.

Όταν δεν έχει οριστεί ρητό γέμισμα σημείου ή σειράς, το στυλ και το θέμα του γραφήματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχουν τόσο μορφοποίηση σειράς όσο και σημείου, η μορφοποίηση του σημείου έχει προτεραιότητα για εκείνο το σημείο.

![διάγραμμα-σειράς-powerpoint](chart-series-powerpoint.png)

## **Ορισμός Τιμών Σειράς Χρησιμοποιώντας Αριθμητικά Λήμματα**

Χρησιμοποιήστε αριθμητικά λήμματα όταν οι τιμές της σειράς προέρχονται από δεδομένα ή υπολογισμούς της εφαρμογής και δεν χρειάζονται αναφορές κελιών του φύλλου εργασίας. Καλείτε το [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) με το [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) πριν αναθέσετε το αποτέλεσμα του [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) κάθε σημείου μέσω του [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble).

Η ρύθμιση της συλλογής ελέγχει τον τύπο προέλευσης όλων των τιμών σημείων σε αυτή τη σειρά. Η μέθοδος [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) κάθε τιμής σημείου αναφέρει τον επιλεγμένο τύπο· αλλάξτε τον μέσω της ρύθμισης της συλλογής. Με `Worksheet`, χρησιμοποιήστε το [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) για να προσπελάσετε το κελί στο οποίο αναφέρεται. Με `DoubleLiterals`, χρησιμοποιήστε το [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) ή `setAsLiteralDouble` για να διαβάσετε ή να γράψετε τον αριθμό άμεσα.

Το παρακάτω παράδειγμα δημιουργεί ένα γράφημα στήλης με προεπιλεγμένες σειρές και κατηγορίες, στη συνέχεια αναθέτει υπολογισμένες τιμές 10, 20 κ.λπ. στα υπάρχοντα σημεία της πρώτης σειράς. Αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει τις αποθηκευμένες τιμές.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

Ο τύπος προέλευσης τιμής σημείου είναι ξεχωριστός από το [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType), το οποίο προσδιορίζει τη διαμόρφωση του εσωτερικού ή εξωτερικού βιβλίου εργασίας του γραφήματος. Η χρήση αριθμητικών λημμάτων δεν αφαιρεί από μόνη της το ενσωματωμένο βιβλίο εργασίας. Σε αυτό το παράδειγμα, το βιβλίο εργασίας παραμένει διαθέσιμο για τις ετικέτες κατηγοριών, τα ονόματα σειρών και τις άλλες σειρές. Δείτε το [Chart Workbook](/slides/el/python-java/chart-workbook/) για διαχείριση βιβλίου εργασίας.

Για διασκορπισμένα και φυσαλίδα γραφήματα, χρησιμοποιήστε το [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) και το [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) για να επιλέξετε τις προελεύσεις για το [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) και το [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue). Τα γραφήματα φυσαλίδων χρησιμοποιούν επίσης το [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) για το [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize). Ορίστε κάθε κατάλληλη προέλευση σε `DoubleLiterals` πριν αναθέσετε αριθμούς μέσω της μεθόδου `setAsLiteralDouble` της τιμής.

## **Ορισμός Επικάλυψης Σειράς Γραφήματος**

Το [ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) αναφέρει το πόσο επικάλυψη έχουν οι μπάρες ή οι στήλες σε ένα 2Δ γράφημα, από -100 μέχρι 100 τοις εκατό. Είναι μια μόνο για ανάγνωση προβολή της ρύθμισης στην γονική ομάδα σειράς. Χρησιμοποιήστε το [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) για να ενημερώσετε κάθε συμβατή σειρά σε εκείνη την ομάδα. Αυτή η επιλογή ισχύει για τύπους γραφήματος που εμφανίζουν ομαδοποιημένες μπάρες ή στήλες· δεν επηρεάζει ανεξάρτητες ομάδες σειρών σε συνδυαστικό γράφημα.

Το παρακάτω παράδειγμα ορίζει την επικάλυψη για την ομάδα που περιέχει την πρώτη σειρά:

```python
import jpype
import asposeslides

if not jpway.isJVMStarted():
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

![Η επικάλυψη των σειρών](series_overlap.png)

## **Αλλαγή Χρώματος Γέμισης Σειράς**

Χρησιμοποιήστε το [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) για να ορίσετε το προεπιλεγμένο γέμισμα ολόκληρης μιας σειράς. Εάν ένα σημείο έχει ήδη ρητή γέμιση, η ρύθμιση του [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) παρακάμπτει το γέμισμα της σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει στερεό γαλάζιο γέμισμα στην πρώτη σειρά:

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

Το όνομα μιας σειράς αποθηκεύεται στο βιβλίο εργασίας δεδομένων του γραφήματος και συνήθως εμφανίζεται στο υπόμνημα. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα γράφημα στήλης συγκεντρωτικών τιμών, το κελί B1 βρίσκεται στη γραμμή 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι ονομαστικές μεταβλητές στο παρακάτω παράδειγμα κάνουν αυτή τη δομή σαφή:

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

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη αναφέρεται από το [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης γραμμής και στήλης σε υπάρχον γράφημα:

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

### **Δημιουργία Σειράς με Όνομα από Πολλαπλά Κελιά**

Ένα σύνθετο όνομα σειράς είναι χρήσιμο όταν το όνομα προϊόντος και η περίοδος αναφοράς αποθηκεύονται σε διαφορετικά κελιά του βιβλίου εργασίας. Για παράδειγμα, μπορείτε να συνδυάσετε το `Product A` στο B1 και το `2026` στο C1 σε ένα ενιαίο όνομα σειράς διατηρώντας και τα δύο μέρη συνδεδεμένα με τα πηγαία κελιά τους.

Χρησιμοποιήστε το [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) για να ανακτήσετε το εύρος ονομάτων, έπειτα περάστε αυτή τη συλλογή στο [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add). Το όρισμα `skipHiddenCells` ελέγχει εάν οι κρυφά κελιά θα συμπεριληφθούν: `True` τα εξαιρεί, ενώ `False` τα περιλαμβάνει. Αυτό το παράδειγμα χρησιμοποιεί `False` για να συμπεριλάβει κάθε κελί στο εύρος ονομάτων.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με μία σειρά και δύο σημεία δεδομένων. Τα κελιά B1:C1 παρέχουν μόνο το όνομα της σειράς· τα A2:A3 παρέχουν τις ετικέτες κατηγοριών, και τα B2:B3 παρέχουν τις αριθμητικές τιμές.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Αυτά τα δύο κελιά παρέχουν το όνομα της σειράς.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # Ξεχωριστά κελιά παρέχουν τις κατηγορίες και τα αριθμητικά σημεία δεδομένων.
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το προκύπτον όνομα σειράς είναι `Product A 2026`, με ένα κενό μεταξύ των δύο τιμών κελιών. Το υπόμνημα το εμφανίζει ως μία καταχώρηση και για τις δύο στήλες. Η εικόνα παρακάτω απεικονίζει το αποτέλεσμα:

![Γράφημα στήλης με τιμές Βόρεια και Νότια και το σύνθετο όνομα σειράς Product A 2026 στο υπόμνημα](composite_series_name.png)

## **Ανάκτηση Αυτόματου Χρώματος Γέμισης Σειράς**

Το [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) επιστρέφει το χρώμα που υπολογίζεται από τον δείκτη της σειράς και το στυλ του γραφήματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν το γέμισμα της σειράς δεν ορίζεται ρητά. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν εκχωρεί νέο γέμισμα.

Το παρακάτω παράδειγμα τυπώνει το αυτόματο χρώμα κάθε προεπιλεγμένης σειράς:

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

## **Ορισμός Αντεστραμμένου Χρώματος Γέμισης για Σειρά Γραφήματος**

Για σειρές μπάρες, στήλες και φυσαλίδας, το [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) μπορεί να εμφανίζει τις αρνητικές τιμές με διαφορετικό γέμισμα. Ορίστε το κανονικό γέμισμα σειράς σε στερεό, ενεργοποιήστε την αντιστροφή και αναθέστε το χρώμα αρνητικής τιμής μέσω του [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· μόνο το χρώμα προβολής τους αλλάζει.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα γραφήματος με μία σειρά. Η γραμμή 0 του φύλλου εργασίας περιέχει το όνομα της σειράς, η στήλη 0 περιέχει τα ονόματα κατηγοριών, και η στήλη 1 περιέχει τις τιμές:

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

![Το αντεστραμμένο στερεό χρώμα γέμισης](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω του [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Στο παρακάτω παράδειγμα, η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιείται μόνο για το επιλεγμένο σημείο. Το σημείο επίσης λαμβάνει μια αρνητική τιμή ώστε το αποτέλεσμα να είναι ορατό:

```python
import jpime
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

Για να κάνετε ένα σημείο κενό χωρίς να αφαιρέσετε τα άλλα σημεία, ορίστε το υποκείμενο κελί του βιβλίου εργασίας σε `None`. Για ένα γράφημα στήλης, η σχεδιασμένη τιμή είναι διαθέσιμη μέσω του [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue). Το σημείο παραμένει στην ίδια θέση κατηγορίας, αλλά το γράφημα το θεωρεί κενό σύμφωνα με τις ρυθμίσεις κενών τιμών του γραφήματος.

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

Τα διασκορπισμένα γραφήματα χρησιμοποιούν χωριστά κελιά X και Y, και τα γραφήματα φυσαλίδων επίσης χρησιμοποιούν κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει την τιμή που θέλετε να αφαιρέσετε. Μην καλέσετε το [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) όταν θέλετε να διατηρήσετε τα άλλα σημεία, επειδή αυτή η μέθοδος αφαιρεί όλα τα σημεία δεδομένων από τη συλλογή.

## **Έλεγχος Εμφάνισης Κενών Κυψελών**

Οι κρυφές κυψέλες που περιέχουν τιμές αποτελούν ξεχωριστή περίπτωση από τις κενές κυψέλες. Για να συμπεριλάβετε ή να εξαιρέσετε δεδομένα από κρυφές γραμμές και στήλες φύλλου εργασίας, δείτε την ενότητα [Include Data from Hidden Rows and Columns](/slides/el/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Μια κενή κυψέλη βιβλίου εργασίας αντιπροσωπεύει ελλιπή δεδομένα· μια κυψέλη που περιέχει `0` αντιπροσωπεύει γνωστή αριθμητική τιμή. Καλέστε το [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) με `None` για να κάνετε μια κυψέλη κενή. Ένα αριθμητικό μηδέν παραμένει μηδέν ανεξάρτητα από τη ρύθμιση κενής κυψέλης.

Χρησιμοποιήστε το [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) για να επιλέξετε πώς το γράφημα εμφανίζει τις κενές κυψέλες. Αυτή η ρύθμιση ισχύει για ολόκληρο το γράφημα. Αλλάζει τον τρόπο που τα κενά σχεδιάζονται, χωρίς να γεμίζει την κενή κυψέλη του βιβλίου εργασίας με μηδέν ή με διαμερισμένη τιμή.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα γράφημα γραμμής με μία σειρά, καθαρίζει την τιμή για την Ημέρα 3, και αποθηκεύει το ίδιο γράφημα με κάθε λειτουργία. Δεν απαιτείται αρχείο εισόδου. Το [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) χρησιμοποιεί το φύλλο 0, στήλη 0 για ετικέτες κατηγοριών, και στήλη 1 για τιμές· η γραμμή 0 κρατά το όνομα της σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

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

Κάθε αρχείο εξόδου αποθηκεύει τη λειτουργία που είχε οριστεί πριν από την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για να αποθηκεύσετε μόνο μία έκδοση, ορίστε τη λειτουργία που επιθυμείτε και αποθηκεύστε την παρουσίαση μία φορά αντί για επαναλήψεις.

Η σύγκριση παρακάτω δείχνει τα ίδια δεδομένα και στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο εργασίας σε κάθε περίπτωση:

![Γραφήματα γραμμής με ίσο περιεχόμενο: Το Gap διακόπτει τη γραμμή στην Ημέρα 3, το Zero κατεβάζει τη γραμμή στο μηδέν, και το Span συνδέει την Ημέρα 2 με την Ημέρα 4.](display_blanks_as.png)

Το οπτικό αποτέλεσμα εξαρτάται από τον τύπο γραφήματος. Ένα γράφημα γραμμής κάνει εύκολη τη σύγκριση των τριών λειτουργιών. Τα γραφήματα μπάρες και στήλες δεν έχουν γραμμή σύνδεσης μεταξύ ελλιπών κατηγοριών, επομένως το `Span` δεν μπορεί να δημιουργήσει το συνδετικό τμήμα που φαίνεται παραπάνω· μια κενή στήλη και μια στήλη μηδενικού ύψους μπορεί επίσης να φαίνονται παρόμοια. Ομοίως, ένα διασκορπισμένο γράφημα με μόνο δείκτες δεν έχει γραμμή σύνδεσης. Μη περιμένετε τρία διακριτά αποτελέσματα για κάθε τύπο γραφήματος· ελέγξτε το αποτέλεσμα για τον τύπο που χρησιμοποιείτε.

## **Ορισμός Πλάτους Κενών Μεταξύ Σειρών**

Το πλάτος κενών είναι ο χώρος μεταξύ γειτονικών ομάδων μπάρες ή στήλες, εκφρασμένο ως ποσοστό του πλάτους της μπάρας ή της στήλης. Όπως και η επικάλυψη, ανήκει στη γονική ομάδα σειρών αντί σε μία σειρά. Καλέστε το [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) μία φορά για την ομάδα. Μια μεγαλύτερη τιμή δημιουργεί περισσότερος χώρος μεταξύ των ομάδων· μια μικρότερη τιμή τις κάνει πιο πυκνές.

Το παρακάτω παράδειγμα αλλάζει το πλάτος κενών και αποθηκεύει μόνο την τελική παρουσίαση:

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

![Το πλάτος των κενών](gap_width.png)

## **Συχνές Ερωτήσεις**

**Ποιοί τύποι γραφήματος υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι γραφήματος που αντιπροσωπεύει η απαρίθμηση [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) χρησιμοποιούν δεδομένα γραφήματος, αλλά οι σειρές τους δεν έχουν όλοι την ίδια δομή τιμών ή ρυθμίσεις. Για παράδειγμα, τα γραφήματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα διασκορπισμένα χρησιμοποιούν τιμές X και Y, και τα γραφήματα φυσαλίδας προσθέτουν μεγέθη φυσαλίδας. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει στον τύπο σειράς. Οι επιλογές όπως επικάλυψη και πλάτος κενών ισχύουν μόνο για συμβατές ομάδες μπάρες ή στήλες.

**Τι είναι μια ομάδα σειρών γραφήματος;**

Μια [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις σχεδίασης επιπέδου ομάδας. Ένα συνδυαστικό γράφημα μπορεί να περιέχει περισσότερες από μία ομάδες, οπότε η αλλαγή της ομάδας μέσω μιας σειράς δεν αλλάζει αναγκαστικά όλες τις σειρές στο γράφημα.

**Το νεοδημιουργηθέν γράφημα περιέχει προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, το [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) δημιουργεί δείγματα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να καθαρίσετε τόσο τις συλλογές σειρών όσο και κατηγοριών πριν προσθέσετε ένα εντελώς προσαρμοσμένο σύνολο δεδομένων. Υπάρχει επίσης υπερφόρτωση που μπορεί να δημιουργήσει ένα γράφημα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα γραφήματος με τα κελιά του βιβλίου εργασίας;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων αναφέρονται σε κελιά ενός [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/). Η αλλαγή ενός κελιού αναφοράς ενημερώνει το αντίστοιχο στοιχείο του γραφήματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, διατηρήστε τις γραμμές κατηγοριών και τις γραμμές τιμών σειράς ευθυγραμμισμένες έτσι ώστε κάθε σημείο να σχεδιάζεται κάτω από την προβλεπόμενη κατηγορία.

**Πώς να καθαρίσω ένα σημείο αντί ολόκληρης σειράς;**

Ορίστε το σχετικό κελί τιμής σε `None` για να διατηρήσετε τη θέση κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε το [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) μόνο όταν θέλετε να αφαιρέσετε όλα τα σημεία από εκείνη τη σειρά. Εάν αφαιρέσετε επίσης τις κατηγορίες, ενημερώστε κάθε σειρά ώστε οι τιμές τους να παραμείνουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο γραφήματος και τη τιμή που έχει διαμορφωθεί μέσω του [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs). Τα υποστηριζόμενα γραφήματα μπορούν να εμφανίζουν κενά ως κενά, ως μηδενικές τιμές ή συνδέοντας γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει στο νόημα των ελλιπών δεδομένων στην παρουσίασή σας. Δείτε την ενότητα [Control the Display of Empty Cells](#control-the-display-of-empty-cells) για ένα πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για υποστηριζόμενες σειρές μπάρες, στήλες και φυσαλίδες, καλέστε το [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) και ορίστε το χρώμα που επιστρέφεται από το [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Μπορείτε να παρακάμψετε τη συμπεριφορά για ένα μεμονωμένο σημείο με το [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Αυτές οι μέθοδοι επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση κερδίζει όταν τόσο μια σειρά όσο και ένα σημείο μορφοποιούνται;**

Η ρητή μορφοποίηση σημείου δεδομένων έχει προτεραιότητα για εκείνο το σημείο. Τα άλλα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφή σειράς ή, όταν δεν ορίζεται μορφή σειράς, το αυτόματο στυλ και θέμα του γραφήματος. Οι ρυθμίσεις ομάδας όπως επικάλυψη και πλάτος κενών ελέγχουν τη διάταξη και δεν είναι παρακάμψεις μορφοποίησης επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα γράφημα;**

Το Aspose.Slides δεν επιβάλλει ξεχωριστό σταθερό όριο αριθμού σειρών. Στην πράξη, περιορισμοί του αρχείου παρουσίασης, διαθέσιμη μνήμη, χρόνος απόδοσης και η αναγνωσιμότητα του γραφήματος καθορίζουν ένα βολικό όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά;**

Καλέστε το [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) στην κατάλληλη γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το διάστημα μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά.