---
title: Προσθήκη Γραμμών Τάσης σε Διαγράμματα Παρουσίασης σε Python
linktitle: Γραμμή Τάσης
type: docs
url: /el/python-java/trend-line/
keywords:
- διάγραμμα
- γραμμή τάσης
- εκθετική γραμμή τάσης
- γραμμική γραμμή τάσης
- λογαριθμική γραμμή τάσης
- γραμμή τάσης κινητής μέσης τιμής
- πολυωνυμική γραμμή τάσης
- γραμμή τάσης δύναμης
- προσαρμοσμένη γραμμή τάσης
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Προσθέστε και προσαρμόστε γρήγορα γραμμές τάσης σε διαγράμματα PowerPoint με το Aspose.Slides for Python via Java — ένας πρακτικός οδηγός για να εντυπωσιάσετε το ακροατήριό σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε γραμμές τάσης σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να προσθέσετε γραμμές τάσης σε σειρές διαγράμματος και να εργαστείτε με διάφορους τύπους γραμμών τάσης, όπως εκθετική, γραμμική, λογαριθμική, κινητός μέσος όρος, πολυωνυμική και δύναμη.

Περιγράφει επίσης πώς να προσθέσετε μια προσαρμοσμένη γραμμή σε ένα διάγραμμα εισάγοντας ένα σχήμα γραμμής και περιλαμβάνει μια σύντομη FAQ σχετικά με τις τιμές προοπτικής «forward» και «backward» των γραμμών τάσης και αν οι γραμμές τάσης διατηρούνται κατά την εξαγωγή σε PDF ή SVG και κατά τη δημιουργία εικόνων από διαγράμματα.

## **Προσθήκη Γραμμής Τάσης**

Aspose.Slides for Python via Java παρέχει ένα απλό API για τη διαχείριση διαφορετικών γραμμών τάσης σε διαγράμματα:

1. Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με το δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και τον επιθυμητό τύπο (αυτό το παράδειγμα χρησιμοποιεί [ChartType.ClusteredColumn](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#ClusteredColumn)).
4. Προσθέστε μια εκθετική γραμμή τάσης στη σειρά διαγράμματος 1.
5. Προσθέστε μια γραμμική γραμμή τάσης στη σειρά διαγράμματος 1.
6. Προσθέστε μια λογαριθμική γραμμή τάσης στη σειρά διαγράμματος 2.
7. Προσθέστε μια γραμμή τάσης κινητής μέσης τιμής στη σειρά διαγράμματος 2.
8. Προσθέστε μια πολυωνυμική γραμμή τάσης στη σειρά διαγράμματος 3.
9. Προσθέστε μια γραμμή τάσης δύναμης στη σειρά διαγράμματος 3.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Ο παρακάτω κώδικας δημιουργεί ένα διάγραμμα με γραμμές τάσης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Δημιουργία ενός αντικειμένου της κλάσης Presentation.
presentation = Presentation()
try:
    # Δημιουργία ενός συγκεντρωμένου διαγράμματος στηλών.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # Προσθήκη μιας εκθετικής γραμμής τάσης στη σειρά διαγράμματος 1.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # Προσθήκη μιας γραμμικής γραμμής τάσης στη σειρά διαγράμματος 1.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Προσθήκη μιας λογαριθμικής γραμμής τάσης στη σειρά διαγράμματος 2.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # Προσθήκη μιας γραμμής τάσης κινητής μέσης τιμής στη σειρά διαγράμματος 2.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # Προσθήκη μιας πολυωνυμικής γραμμής τάσης στη σειρά διαγράμματος 3.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # Προσθήκη μιας γραμμής τάσης δύναμης στη σειρά διαγράμματος 3.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # Αποθήκευση της παρουσίασης.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Προσθήκη Προσαρμοσμένης Γραμμής**

Aspose.Slides for Python via Java παρέχει ένα απλό API για την προσθήκη προσαρμοσμένων γραμμών σε ένα διάγραμμα. Για να προσθέσετε μια απλή γραμμή σε ένα διάγραμμα σε μια επιλεγμένη διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
- Αποκτήστε μια αναφορά σε μια διαφάνεια με το δείκτη της.
- Δημιουργήστε ένα νέο διάγραμμα χρησιμοποιώντας τη μέθοδο [addChart](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addChart) της κλάσης [ShapeCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/).
- Προσθέστε ένα σχήμα γραμμής χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addAutoShape) με το [ShapeType.Line](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#Line).
- Ορίστε το χρώμα της γραμμής του σχήματος.
- Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Ο παρακάτω κώδικας δημιουργεί ένα διάγραμμα με προσαρμοσμένη γραμμή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Δημιουργία ενός αντικειμένου της κλάσης Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Τι σημαίνουν τα 'forward' και 'backward' για μια γραμμή τάσης;**

Αυτά είναι τα μήκη της γραμμής τάσης που προβλέπονται προς τα εμπρός ή προς τα πίσω: για διαγράμματα διασποράς (XY) μετρώνται σε μονάδες άξονα· για μη‑διασπορικά διαγράμματα μετρώνται σε αριθμό κατηγοριών. Επιτρέπονται μόνο μη‑αρνητικές τιμές.

**Θα διατηρηθεί η γραμμή τάσης κατά την εξαγωγή της παρουσίασης σε PDF ή SVG ή κατά τη δημιουργία εικόνας από μια διαφάνεια;**

Ναι. Το Aspose.Slides μετατρέπει τις παρουσιάσεις σε [PDF](/slides/el/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/el/python-java/render-a-slide-as-an-svg-image/) και αποδίδει διαγράμματα σε εικόνες· οι γραμμές τάσης, ως μέρος του διαγράμματος, διατηρούνται κατά αυτές τις λειτουργίες. Υπάρχει επίσης μέθοδος για [εξαγωγή εικόνας του διαγράμματος](/slides/el/python-java/create-shape-thumbnails/).