---
title: Προσθήκη γραμμών τάσης σε διαγράμματα παρουσίασης με Python
linktitle: Γραμμή τάσης
type: docs
url: /el/python-java/trend-line/
keywords:
- διάγραμμα
- γραμμή τάσης
- εκθετική γραμμή τάσης
- γραμμική γραμμή τάσης
- λογαριθμική γραμμή τάσης
- γραμμή τάσης κινητής μέσης
- πολυωνυμική γραμμή τάσης
- γραμμή τάσης με δύναμη
- προσαρμοσμένη γραμμή τάσης
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Προσθέστε και προσαρμόστε γρήγορα γραμμές τάσης σε διαγράμματα PowerPoint με Aspose.Slides για Python μέσω Java — έναν πρακτικό οδηγό για να προσελκύσετε το κοινό σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε γραμμές τάσεων σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να προσθέσετε γραμμές τάσεων σε σειρές διαγράμματος και να εργαστείτε με διάφορους τύπους γραμμών τάσεων, συμπεριλαμβανομένων των εκθετικών, γραμμικών, λογαριθμικών, κινητής μέσης, πολυωνυμικών και με δύναμη.

Επιπλέον περιγράφει πώς να προσθέσετε μια προσαρμοσμένη γραμμή σε ένα διάγραμμα εισάγοντας ένα σχήμα γραμμής και περιλαμβάνει μια σύντομη Συχνή ερώτηση σχετικά με τις τιμές πρόβλεψης της γραμμής τάσης προς τα εμπρός και προς τα πίσω και αν οι γραμμές τάσης διατηρούνται κατά την εξαγωγή σε PDF ή SVG και κατά την απόδοση των διαγραμμάτων ως εικόνες.

## **Προσθήκη γραμμής τάσης**

Χρησιμοποιήστε [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) για να προσθέσετε μια γραμμή τάσης σε μια σειρά διαγράμματος, επιλέγοντας τον τύπου της με το [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/). Το παράδειγμα δημιουργεί ένα συγκεντρωτικό γράφημα στήλης με προεπιλεγμένα δεδομένα και προσθέτει δύο γραμμές τάσης σε καθεμία από τις τρεις σειρές του.

Η εκθετική γραμμή τάσης κρύβει την εξίσωση και την τιμή R‑τετράγωνου μέσω των [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) και [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue), ενώ η γραμμική γραμμή τάσης είναι κόκκινη. Η λογαριθμική γραμμή τάσης χρησιμοποιεί το [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) για προσαρμοσμένη ετικέτα. Η κινητή μέση χρησιμοποιεί ένα [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) τριών σημείων δεδομένων και ένα προσαρμοσμένο [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName).

Η πολυωνυμική γραμμή τάσης έχει τάξη τρία, που ορίζεται μέσω του [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) και επεκτείνεται μία κατηγορία προς τα εμπρός μέσω του [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward). Η γραμμή τάσης δύναμης επεκτείνεται μία κατηγορία προς τα πίσω μέσω του [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός σημείου τομής γραμμής τάσης**

Χρησιμοποιήστε το [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) για να καθορίσετε την τιμή Y μιας γραμμής τάσης στο X = 0. Αυτή η ρύθμιση υποστηρίζεται για γραμμικές, εκθετικές και πολυωνυμικές γραμμές τάσης.

Για παράδειγμα, ένα μοντέλο κόστους παραγωγής ίσως χρειάζεται να ξεκινά από γνωστές σταθερές δαπάνες της τάξης των 100, ακόμη και όταν μετρήσεις σε μη μηδενικούς όγκους παραγωγής υποδεικνύουν διαφορετική βάση. Για μια γραμμική γραμμή τάσης, η σταθεροποίηση του σημείου τομής περιορίζει την εξίσωση `y = ax + b` σε `b = 100`; η κλίση προσαρμόζεται στα δεδομένα υπό αυτήν την περιοριστική συνθήκη. Δεν μετακινεί απλώς μια ήδη προσαρμοσμένη γραμμή. Οι ρυθμίσεις διασταυρώσεων αξόνων ελέγχουν πού συναντώνται οι άξονες του διαγράμματος, όχι τους συντελεστές της προσαρμοσμένης γραμμής τάσης.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα διασποράς (XY) με όγκους παραγωγής από 1 έως 4 και κόστη 170, 200, 230 και 260. Αποθηκεύει το διάγραμμα με το προεπιλεγμένο αυτόματο σημείο τομής, ορίζει το σημείο τομής στο 100 και αποθηκεύει ένα δεύτερο αρχείο PPTX. Τα δύο αρχεία διαφέρουν μόνο στη ρύθμιση του σημείου τομής. Η γραμμή τάσης εμφανίζει την εξίσωσή της και επεκτείνεται πίσω στο X = 0.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Με αυτόματο υπολογισμό, αυτά τα δεδομένα παράγουν το `y = 30x + 140`. Ορίζοντας το σημείο τομής στο 100 παράγει περίπου το `y = 43.33x + 100`: η προσαρμοσμένη τιμή στο μηδέν ταιριάζει με τη γνωστή βάση, ενώ η γραμμή δεν διέρχεται πλέον από κάθε σημείο δεδομένων.

| Αυτόματο σημείο τομής | Σταθερό σημείο τομής 100 |
| --- | --- |
| ![Γραμμική γραμμή τάσης με αυτόματα υπολογισμένο σημείο τομής 140](intercept-automatic.png) | ![Γραμμική γραμμή τάσης με σταθερό σημείο τομής 100](intercept-fixed.png) |

Και οι δύο εικόνες χρησιμοποιούν τα ίδια δεδομένα και κλίμακες αξόνων. Οι γραμμές τάσης επεκτείνονται πίσω στο X = 0 για να εμφανίσουν τα σημεία τομής τους.

Από προεπιλογή, το [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) επιστρέφει `NaN`, που αντιπροσωπεύει ένα ακαθόριστο σημείο τομής αντί για μηδέν. Στη συνέχεια, το σημείο τομής υπολογίζεται αυτόματα από τα δεδομένα.

## **Προσθήκη προσαρμοσμένης γραμμής**

Μια προσαρμοσμένη γραμμή είναι ένα σχήμα σχεδιασμένο πάνω από το διάγραμμα αντί για γραμμή τάσης που υπολογίζεται από τα δεδομένα των σειρών. Αυτό το παράδειγμα χρησιμοποιεί το [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) για να προσθέσει μια οριζόντια γραμμή στη διαφάνεια πάνω από το διάγραμμα. Η θέση της γραμμής καθορίζεται σε συντεταγμένες διαφάνειας, μετρημένες σε σημεία, έτσι ώστε να ξεκινά στο αριστερό άκρο του διαγράμματος και να βρίσκεται στη μέση του ύψους του διαγράμματος. Το πλάτος της ταιριάζει με το πλάτος του διαγράμματος. Η μέθοδος [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) παρέχει πρόσβαση στη μορφοποίηση της γραμμής που χρησιμοποιείται για την εφαρμογή ενός στερεού κόκκινου χρώματος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές ερωτήσεις**

**Τι σημαίνουν οι όροι 'forward' και 'backward' για μια γραμμή τάσης;**

Αυτά είναι τα μήκη της γραμμής τάσης που προβάλλονται προς το εμπρός/πίσω: για διαγράμματα διασποράς (XY) — σε μονάδες άξονων· για μη διαγράμματα διασποράς — σε αριθμό κατηγοριών. Επιτρέπονται μόνο μη‑αρνητικές τιμές.

**Θα διατηρηθεί η γραμμή τάσης κατά την εξαγωγή της παρουσίασης σε PDF ή SVG, ή κατά την απόδοση μιας διαφάνειας σε εικόνα;**

Ναι. Το Aspose.Slides μετατρέπει τις παρουσιάσεις σε [PDF](/slides/el/python-java/convert-powerpoint-to-pdf/) ή [SVG](/slides/el/python-java/render-a-slide-as-an-svg-image/) και αποδίδει τα διαγράμματα σε εικόνες· οι γραμμές τάσης, ως μέρος του διαγράμματος, διατηρούνται κατά τη διάρκεια αυτών των λειτουργιών. Διατίθεται επίσης μια μέθοδος για [εξαγωγή εικόνας του διαγράμματος](/slides/el/python-java/create-shape-thumbnails/) από μόνο του.