---
title: Προσαρμογή 3D γραφημάτων σε παρουσιάσεις χρησιμοποιώντας Python
linktitle: 3D γράφημα
type: docs
url: /el/python-java/3d-chart/
keywords:
- 3D γράφημα
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε 3D γραφήματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για Python μέσω Java. Προσαρμόστε την περιστροφή, τις αναλογίες ύψους, το βάθος του διαγράμματος και την απόσταση μεταξύ σειρών με παραδείγματα Python."
---
## **Επισκόπηση**

Το Aspose.Slides for Python μέσω Java σάς επιτρέπει να προσαρμόσετε την προβολή ενός 3D διαγράμματος μέσω της μεθόδου [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). Αυτό το άρθρο δείχνει πώς να ρυθμίσετε την περιστροφή, τις αναλογίες ύψους, το βάθος, τους άξονες ορθής γωνίας και την απόσταση μεταξύ σειρών, και στη συνέχεια να αποθηκεύσετε την παρουσίαση σε μορφή PPTX.

## **Ορίστε την Περιστροφή και το Βάθος ενός 3D Διαγράμματος**

Το παρακάτω παράδειγμα δημιουργεί μια [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) και χρησιμοποιεί τη [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) για να προσθέσει ένα στοίβαγμα 3D διαγράμματος στήλης στη πρώτη του διαφάνεια. Αντικαθιστά τις προεπιλεγμένες σειρές και κατηγορίες με δύο σειρές που περιέχουν τρεις τιμές η κάθε μία. Ο δείκτης φύλλου εργασίας `0` προσδιορίζει το πρώτο φύλλο δεδομένων του διαγράμματος· η γραμμή `0` περιέχει τα ονόματα των σειρών, και η στήλη `0` περιέχει τις ετικέτες κατηγοριών.

Οι μέθοδοι [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) και [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) ορίζουν την περιστροφή του διαγράμματος στα 40 και 270 μοίρες, αντίστοιχα. Η [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) ορίζει το βάθος του στο 150 % του πλάτους του, ενώ η [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) ενεργοποιεί άξονες ορθής γωνίας αντί για προοπτική. Η προκύπτουσα παρουσίαση περιέχει το γεμάτο διάγραμμα με αυτές τις ρυθμίσεις προβολής 3D.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Προσαρμόστε τις Αναλογίες Ύψους ενός 3D Διαγράμματος**

Χρησιμοποιήστε τη [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) για να ορίσετε το ύψος ενός 3D διαγράμματος ως ποσοστό του πλάτους του. Αυτό αλλάζει τις αναλογίες της 3D σκηνής χωρίς να αλλάζει το μέγεθος του αντικειμένου διαγράμματος στη διαφάνεια.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) με τα προεπιλεγμένα δεδομένα: τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει τρεις παρουσιάσεις με αναλογίες ύψους 50 %, 100 % και 200 %. Η θέση, το πλάτος και το ύψος του διαγράμματος παραμένουν σταθερά. Τα δεδομένα, η περιστροφή, το βάθος, η απόσταση μεταξύ σειρών και η μορφοποίηση είναι πανομοιότυπα σε όλα τα τρία αρχεία· μόνο το ποσοστό ύψους αλλάζει.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Οι παρακάτω εικόνες απεικονίζουν τις ίδιες ρυθμίσεις ύψους στο ισοδύναμο παράδειγμα .NET και εξήχθησαν χρησιμοποιώντας το Microsoft PowerPoint. Ένα μικρότερο ποσοστό δημιουργεί μια πιο επίπεδη σκηνή, ενώ ένα μεγαλύτερο ποσοστό δημιουργεί μια πιο ψηλή σκηνή μέσα στο ίδιο αντικείμενο διαγράμματος. Το PowerPoint μπορεί επίσης να προσαρμόσει τα διαστήματα των σημείων του άξονα και τη θέση των ετικετών ώστε να ταιριάζουν στη σκηνή.

| Height: 50% | Height: 100% | Height: 200% |
| --- | --- | --- |
| ![3D διάγραμμα στήλης με ύψος ορισμένο στο 50 % του πλάτους του](height_percent_50.png) | ![3D διάγραμμα στήλης με ύψος ορισμένο στο 100 % του πλάτους του](height_percent_100.png) | ![3D διάγραμμα στήλης με ύψος ορισμένο στο 200 % του πλάτους του](height_percent_200.png) |

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Ύψος της 3D σκηνής ως ποσοστό του πλάτους της. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Ύψος του αντικειμένου διαγράμματος στη διαφάνεια, σε points. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Βάθος της 3D σκηνής ως ποσοστό του πλάτους της. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |

Η ρύθμιση του ύψους επηρεάζει τα 3D διαγράμματα στήλης και ράβδου, συμπεριλαμβανομένων των κυλίνδρων, κώνων και πυραμίδων, καθώς και τα 3D γραμμικά, περιοχής, πίτας και επιφάνειας. Η παραπάνω σύγκριση χρησιμοποιεί τον επαληθευμένο τύπο `Column3D`. Η ρύθμιση δεν αλλάζει την εμφάνιση ενός 2D διαγράμματος `ClusteredColumn` ή ενός διαγράμματος `BubbleWith3D`; αυτά τα ονόματα είναι μέλη της κλάσης [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Για άλλες ρυθμίσεις εμφάνισης διαγράμματος, δείτε [Μορφοποίηση Διαγράμματος](/slides/el/python-java/chart-formatting/).

## **Προσαρμόστε το Κενό Μεταξύ Σειρών**

Χρησιμοποιήστε τη [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) για να ελέγξετε την απόσταση μεταξύ σειρών δεδομένων κατά τον άξονα βάθους ενός 3D διαγράμματος, εκφρασμένη ως ποσοστό του πλάτους του δείκτη. Χρησιμοποιήστε τιμές από **0 έως 500**, συμπεριλαμβανομένου: `0` αφαιρεί το κενό, ενώ μεγαλύτερες τιμές αυξάνουν την απόσταση. Με σταθερό βάθος διαγράμματος, η αύξηση του κενού κάνει τα δείκτες πιο λεπτά κατά τον άξονα βάθους.

Πρόσβαση στην ομάδα μέσω της [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). Η ρύθμιση εφαρμόζεται σε κάθε σειρά στην ομάδα, όχι μόνο στη σειρά που χρησιμοποιήθηκε για την πρόσβαση. Η [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) επιστρέφει το κενό βάθους και αντικατοπτρίζει τη ρύθμιση της γονικής ομάδας.

Αυτή η ρύθμιση επηρεάζει τα 3D διαγράμματα στήλης και ράβδου, συμπεριλαμβανομένων των κυλίνδρων, κώνων και πυραμίδων, καθώς και τα 3D διαγράμματα γραμμής και περιοχής. Η εμφάνιση εξαρτάται από το αν οι σειρές είναι διατεταγμένες σε βάθος, ομαδοποιημένες ή στοίβαγμενες. Για σαφή σύγκριση των κενών μεταξύ ξεχωριστών σειρών, χρησιμοποιήστε το `ChartType.Column3D` από την κλάση [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Απόσταση μεταξύ διαδοχικών ομάδων ραβδών ή στηλών, ως ποσοστό του πλάτους της ράβδου ή της στήλης. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Συνολικό βάθος διαγράμματος, ως ποσοστό του πλάτους του διαγράμματος. |

Το παρακάτω αυτόνομο παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα διαγράμματος, τα οποία περιέχουν τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει δύο παρουσιάσεις με ταυτόσπαθια δεδομένα, περιστροφή, πλάτος κενού και βάθος διαγράμματος· μόνο το κενό βάθους αλλάζει.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Οι παρακάτω εικόνες απεικονίζουν τις ίδιες ρυθμίσεις κενού βάθους στο ισοδύναμο παράδειγμα .NET και εξήχθησαν χρησιμοποιώντας το Microsoft PowerPoint.

| Gap depth: 0% | Gap depth: 500% |
| --- | --- |
| ![3D διάγραμμα στήλης χωρίς κενό μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_0.png) | ![3D διάγραμμα στήλης με κενό 500 % μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_500.png) |

## **Αλλάξτε τον Τύπο Σειράς 3D και το Σχήμα Ράβδου**

Σε ένα ομαδοποιημένο διάγραμμα κυλίνδρου, η πρώτη σειρά ξεκινά με σχήμα κυλινδρικής ράβδου. Το παράδειγμα εκτυπώνει τις ακέραιες τιμές που επιστρέφουν οι [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) και [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) πριν και μετά από κάθε αλλαγή. Ο πίνακας παρέχει τα αντίστοιχα ονόματα σταθερών.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Αλλαγή στην πρώτη σειρά | Τύπος σειράς | Σχήμα ράβδου |
| --- | --- | --- |
| Δημιουργία διαγράμματος | `ClusteredCylinder` | `Cylinder` |
| Ορισμός του τύπου σειράς σε `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ορισμός του σχήματος ράβδου σε `Box` | `ClusteredColumn3D` | `Box` |

Ο ορισμός του σχήματος σε `Box` αλλάζει επίσης τον τύπο σειράς σε `ClusteredColumn3D`. Εάν ο κώδικάς σας κάνει διακλαδώσεις βάσει του τύπου σειράς, καλέστε το `series.getType()` μετά την αλλαγή του σχήματος. Μια τιμή που έχει αποθηκευτεί στη μνήμη πριν την εκχώρηση θα εξακολουθούσε να επιλέγει το κλαδί `ClusteredCone`.

![Σύγκριση PowerPoint που δείχνει την πρώτη σειρά ως κυλινδρικές, κωνικές και ορθογώνιες στήλες από αριστερά προς τα δεξιά](series-shapes.png)

## **FAQ**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν λειτουργία 3D στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει τις 3D παραλλαγές των διαγραμμάτων στήλης, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100 % Stacked Column 3D, μαζί με σχετικούς 3D τύπους που εκτίθενται μέσω της κλάσης [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Για μια ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη του [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) στην αναφορά API της εγκατεστημένης έκδοσής σας.

**Μπορώ να λάβω ένα ραστερικό εικόνα ενός 3D διαγράμματος για αναφορά ή το web;**

Ναι. Μπορείτε να εξάγετε ένα διάγραμμα σε εικόνα με τη [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) ή να [render the entire slide](/slides/el/python-java/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια ραστερική προεπισκόπηση ή θέλετε να ενσωματώσετε το διάγραμμα σε έγγραφα, πίνακες ελέγχου ή ιστοσελίδες χωρίς να απαιτείται το PowerPoint.

**Πόσο αποδοτική είναι η δημιουργία και η απόδοση μεγάλων 3D διαγραμμάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και την οπτική πολυπλοκότητα. Για βέλτιστα αποτελέσματα, διατηρήστε τα εφέ 3D στο ελάχιστο, αποφύγετε βαριές υφές σε τοίχους και περιοχές γραφήματος, περιορίστε τον αριθμό των σημείων δεδομένων ανά σειρά όταν είναι δυνατόν, και αποδώστε σε έξοδο κατάλληλου μεγέθους (ανάλυση και διαστάσεις) ώστε να ταιριάζει στην προβολή ή τις ανάγκες εκτύπωσης.