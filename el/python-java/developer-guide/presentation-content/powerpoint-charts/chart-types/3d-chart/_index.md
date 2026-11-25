---
title: "Προσαρμογή 3Δ γραφημάτων σε παρουσιάσεις με Python"
linktitle: "3Δ γράφημα"
type: docs
url: /el/python-java/3d-chart/
keywords:
- 3Δ γράφημα
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε 3Δ γραφήματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για Python μέσω Java. Ρυθμίστε την περιστροφή, τις αναλογίες ύψους, το βάθος του γραφήματος και το διάστημα μεταξύ σειρών με παραδείγματα Python."
---
## **Επισκόπηση**

Aspose.Slides for Python via Java σάς επιτρέπει να προσαρμόσετε την προβολή ενός 3Δ γραφήματος μέσω της μεθόδου [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). Αυτό το άρθρο δείχνει πώς να ρυθμίσετε την περιστροφή, τις αναλογίες ύψους, το βάθος, τους άξονες ορθής γωνίας και το διάστημα μεταξύ σειρών, και στη συνέχεια να αποθηκεύσετε την παρουσίαση σε μορφή PPTX.

## **Ορισμός Περιστροφής και Βάθους 3Δ Γραφήματος**

Το παρακάτω παράδειγμα δημιουργεί μια [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) και χρησιμοποιεί το [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) για να προσθέσει ένα στοίβαγμα 3Δ στήλης στο πρώτο του διαφάνειο. Αντικαθιστά τις προεπιλεγμένες σειρές και κατηγορίες με δύο σειρές που περιέχουν τρία τιμές η κάθε μία. Ο δείκτης φύλλου εργασίας `0` προσδιορίζει το πρώτο φύλλο δεδομένων του γραφήματος· η σειρά `0` περιέχει τα ονόματα των σειρών, και η στήλη `0` περιέχει τις ετικέτες των κατηγοριών.

Οι μέθοδοι [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) και [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) ορίζουν την περιστροφή του γραφήματος σε 40 και 270 μοίρες αντίστοιχα. Η [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) ορίζει το βάθος του στο 150 % του πλάτους του, ενώ η [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) ενεργοποιεί άξονες ορθής γωνίας αντί για προοπτική. Η προκύπτουσα παρουσίαση περιέχει το γεμισμένο γράφημα με αυτές τις ρυθμίσεις 3Δ προβολής.

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

## **Εφαρμογή Γέμισης Εικόνας στην Επιφάνεια 3Δ Γραφήματος**

Ένα 3Δ γράφημα διαθέτει τρεις επιφάνειες που μπορείτε να γεμίσετε ανεξάρτητα: τον [side wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getSideWall), τον [back wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) και το [floor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor). Ορίστε το [fill type](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) της επιφάνειας σε `Picture` και αναθέστε μια εικόνα. Ορίστε τόσο τη [picture fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) όσο και τον [picture type](https://reference.aspose.com/slides/python-java/aspose.slides/chartwall/#setPictureType) της επιφάνειας σε `Stretch` για να ταιριάζει ένα αντίγραφο της εικόνας σε όλη την επιφάνεια.

Αποθηκεύστε το αρχείο [arrow.png](arrow.png) στον τρέχοντα κατάλογο. Το παράδειγμα περιστρέφει το γράφημα και αυξάνει τη μέγιστη τιμή του κατακόρυφου άξονα ώστε το πάτωμα να είναι ορατό μεταξύ των στηλών. Στη συνέχεια κλωνοποιεί τη διαφάνεια δύο φορές και εφαρμόζει το βέλος σε διαφορετική επιφάνεια σε κάθε διαφάνεια. Και τα τρία γραφήματα διατηρούν τα ίδια δεδομένα, γωνία θέασης και φόντο.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, PictureFillMode, PictureType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(30)
    
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(24)

    back_slide = presentation.getSlides().addClone(slide)
    floor_slide = presentation.getSlides().addClone(slide)
    back_chart = back_slide.getShapes().get_Item(0)
    floor_chart = floor_slide.getShapes().get_Item(0)

    image_bytes = Path("arrow.png").read_bytes()
    arrow = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_bytes))

    surfaces = (chart.getSideWall(), back_chart.getBackWall(), floor_chart.getFloor())
    for surface in surfaces:
        fill = surface.getFormat().getFill()
        fill.setFillType(FillType.Picture)
        picture_fill = fill.getPictureFillFormat()
        picture_fill.getPicture().setImage(arrow)
        picture_fill.setPictureFillMode(PictureFillMode.Stretch)
        surface.setPictureType(PictureType.Stretch)

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το Microsoft PowerPoint εμφανίζει τις τρεις διαφάνειες ως εξής.

| Πλευρικός τοίχος | Πίσω τοίχος | Πάτωμα |
| --- | --- | --- |
| ![Βέλος που δείχνει στο γράφημα κατά μήκος του πλευρικού τοίχου](side-wall.png) | ![Βέλος που δείχνει δεξιά κατά μήκος του πίσω τοίχου](back-wall.png) | ![Βέλος που δείχνει δεξιά κατά μήκος του πατώματος μεταξύ των στηλών](floor.png) |

## **Ρύθμιση Αναλογιών Ύψους 3Δ Γραφήματος**

Χρησιμοποιήστε το [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) για να ορίσετε το ύψος ενός 3Δ γραφήματος ως ποσοστό του πλάτους του. Αυτό αλλάζει τις αναλογίες της 3Δ σκηνής χωρίς να αλλάζει το μέγεθος του αντικειμένου γραφήματος στη διαφάνεια.

Το παρακάτω παράδειγμα δημιουργεί ένα γράφημα [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) με τα προεπιλεγμένα δεδομένα: τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει τρεις παρουσιάσεις με αναλογίες ύψους 50 %, 100 % και 200 %. Η θέση, το πλάτος και το ύψος του γραφήματος παραμένουν σταθερά. Τα δεδομένα, η περιστροφή, το βάθος, το κενό μεταξύ σειρών και η μορφοποίηση είναι τα ίδια σε όλα τα αρχεία· μόνο το ποσοστό ύψους αλλάζει.

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

Οι παρακάτω εικόνες απεικονίζουν τις ίδιες ρυθμίσεις ύψους στο ισοδύναμο παράδειγμα .NET και εξήχθησαν χρησιμοποιώντας το Microsoft PowerPoint. Ένα μικρότερο ποσοστό δημιουργεί μια πιο επίπεδη σκηνή, ενώ ένα μεγαλύτερο ποσοστό παράγει μια ψηλότερη σκηνή εντός του ίδιου αντικειμένου γραφήματος. Το PowerPoint μπορεί επίσης να προσαρμόσει τα διαστήματα των σημάνσεων των αξόνων και τη θέση των ετικετών για να ταιριάζει στη σκηνή.

| Ύψος: 50% | Ύψος: 100% | Ύψος: 200% |
| --- | --- | --- |
| ![3Δ στήλης γράφημα με ύψος 50 % του πλάτους του](height_percent_50.png) | ![3Δ στήλης γράφημα με ύψος 100 % του πλάτους του](height_percent_100.png) | ![3Δ στήλης γράφημα με ύψος 200 % του πλάτους του](height_percent_200.png) |

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του γραφήματος:

| Μέθοδος | Επίδραση |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Ύψος της 3Δ σκηνής ως ποσοστό του πλάτους της. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Ύψος του αντικειμένου γραφήματος στη διαφάνεια, σε σημεία. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Βάθος της 3Δ σκηνής ως ποσοστό του πλάτους της. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |

Η ρύθμιση του ύψους επηρεάζει γραφήματα 3Δ στήλης και ράβδου, συμπεριλαμβανομένων των κυλινδρικών, κωνικών και πυραμιδικών παραλλαγών, καθώς και γραφήματα 3Δ γραμμής, περιοχής, πίτας και επιφάνειας. Η σύγκριση παραπάνω χρησιμοποιεί τον επαληθευμένο τύπο `Column3D`. Η ρύθμιση δεν αλλάζει την εμφάνιση ενός 2Δ γραφήματος `ClusteredColumn` ή ενός γραφήματος `BubbleWith3D`; αυτά τα ονόματα είναι μέλη της κλάσης [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Για άλλες ρυθμίσεις εμφάνισης γραφήματος, δείτε [Chart Formatting](/slides/el/python-java/chart-formatting/).

## **Ρύθμιση Κενού Μεταξύ Σειρών**

Χρησιμοποιήστε το [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) για να ελέγξετε την απόσταση μεταξύ σειρών δεδομένων κατά τον άξονα βάθους ενός 3Δ γραφήματος, εκφρασμένη ως ποσοστό του πλάτους του δείκτη. Χρησιμοποιήστε τιμές από **0 έως 500**, συμπεριλαμβανομένου: `0` αφαιρεί το κενό, ενώ μεγαλύτερες τιμές αυξάνουν το διάστημα. Με σταθερό βάθος γραφήματος, η αύξηση του κενού κάνει τα δείκτες πιο λεπτά κατά τον άξονα βάθους.

Πρόσβαση στην ομάδα μέσω του [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). Η ρύθμιση εφαρμόζεται σε κάθε σειρά σε αυτήν την ομάδα, όχι μόνο στη σειρά που χρησιμοποιείται για την πρόσβαση σε αυτήν. Το [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) επιστρέφει το κενό βάθους και αντικατοπτρίζει τη ρύθμιση της γονικής ομάδας.

Αυτή η ρύθμιση επηρεάζει γραφήματα 3Δ στήλης και ράβδου, συμπεριλαμβανομένων των κυλινδρικών, κωνικών και πυραμιδικών παραλλαγών, καθώς και γραφήματα 3Δ γραμμής και περιοχής. Η εμφάνιση εξαρτάται από το αν οι σειρές είναι διατεταγμένες σε βάθος, ομαδοποιημένες ή στοίβαγμενες. Για σαφή σύγκριση των κενών μεταξύ ξεχωριστών σειρών, χρησιμοποιήστε το `ChartType.Column3D` από την κλάση [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του γραφήματος:

| Μέθοδος | Επίδραση |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Απόσταση μεταξύ γειτονικών ομάδων ράβδων ή στηλών, ως ποσοστό του πλάτους της ράβδου ή της στήλης. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Συνολικό βάθος γραφήματος, ως ποσοστό του πλάτους του γραφήματος. |

Το παρακάτω αυτόνομα παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα γραφήματος, τα οποία περιέχουν τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει δύο παρουσιάσεις με ταυτόσυχα δεδομένα, περιστροφή, πλάτος κενών και βάθος γραφήματος· μόνο το κενό βάθους αλλάζει.

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

| Κενό βάθους: 0% | Κενό βάθους: 500% |
| --- | --- |
| ![3Δ στήλης γράφημα χωρίς κενό μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_0.png) | ![3Δ στήλης γράφημα με κενό 500 % μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_500.png) |

## **Αλλαγή Τύπου Σειράς 3Δ και Σχήματος Ράβδου**

Σε ένα γράφημα στοίβαξης κυλίνδρων, η πρώτη σειρά ξεκινά με σχήμα κυλινδρικής ράβδου. Το παράδειγμα εμφανίζει τις ακέραιες τιμές που επιστρέφει το [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) και το [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) πριν και αφού γίνει κάθε αλλαγή. Ο πίνακας δίνει τα αντίστοιχα ονόματα σταθερών.

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
| Δημιουργία γραφήματος | `ClusteredCylinder` | `Cylinder` |
| Ορισμός τύπου σειράς σε `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ορισμός σχήματος ράβδου σε `Box` | `ClusteredColumn3D` | `Box` |

Ο ορισμός του σχήματος σε `Box` αλλάζει επίσης τον τύπο σειράς σε `ClusteredColumn3D`. Εάν ο κώδικάς σας ελέγχει τον τύπο σειράς, καλέστε `series.getType()` μετά την αλλαγή του σχήματος. Μια τιμή που είχε αποθηκευτεί πριν την ανάθεση θα επέλεγε ακόμη τον κλάδο `ClusteredCone`.

![Σύγκριση PowerPoint που δείχνει την πρώτη σειρά ως κυλίνδρους, κώνους και ορθογώνιες στήλες από αριστερά προς δεξιά](series-shapes.png)

## **Συχνές Ερωτήσεις**

**Ποιους τύπους γραφημάτων υποστηρίζει η λειτουργία 3Δ στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει 3Δ παραλλαγές γραφημάτων στήλης, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100 % Stacked Column 3D, καθώς και σχετικούς 3Δ τύπους που εκτίθενται μέσω της κλάσης [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Για ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη του [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) στην τεκμηρίωση της API της εγκατεστημένης έκδοσής σας.

**Μπορώ να λάβω μια raster εικόνα ενός 3Δ γραφήματος για αναφορά ή το διαδίκτυο;**

Ναι. Μπορείτε να εξάγετε ένα γράφημα σε εικόνα με τη [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) ή να [αποδώσετε ολόκληρη τη διαφάνεια](/slides/el/python-java/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια raster προεπισκόπηση ή θέλετε να ενσωματώσετε το γράφημα σε έγγραφα, πίνακες ελέγχου ή ιστοσελίδες χωρίς να απαιτείται το PowerPoint.

**Πόσο αποδοτική είναι η δημιουργία και η απόδοση μεγάλων 3Δ γραφημάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και την οπτική πολυπλοκότητα. Για βέλτιστα αποτελέσματα, κρατήστε τα 3Δ εφέ ελάχιστα, αποφύγετε βαριές υφές σε τοίχους και περιοχές σχεδίασης, περιορίστε τον αριθμό των σημείων δεδομένων ανά σειρά όταν είναι δυνατόν, και αποδώστε σε κατάλληλο μέγεθος εξόδου (ανάλυση και διαστάσεις) ώστε να ταιριάζει στην επιθυμητή οθόνη ή εκτύπωση.