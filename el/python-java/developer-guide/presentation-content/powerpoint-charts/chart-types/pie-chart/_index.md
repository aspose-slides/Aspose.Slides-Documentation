---
title: Προσαρμογή Διαγραμμάτων Πίτας σε Παρουσιάσεις χρησιμοποιώντας Python μέσω Java
linktitle: Διάγραμμα Πίτας
type: docs
url: /el/python-java/pie-chart/
keywords:
- διάγραμμα πίτας
- διαχείριση διαγράμματος
- προσαρμογή διαγράμματος
- επιλογές διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές γραφήματος
- χρώμα φέτας
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα πίτας σε Python μέσω Java με Aspose.Slides. Διαμορφώστε δευτερεύοντα γραφήματα, εμφανίστε ετικέτες δεδομένων και εφαρμόστε αυτόματο χρώμα φετών στο PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με διαγράμματα πίτας στο Aspose.Slides. Δείχνει πώς να διαμορφώσετε τις επιλογές δευτείου διαγράμματος για διαγράμματα Pie of Pie και Bar of Pie, καθώς και πώς να ενεργοποιήσετε την αυτόματη χρωματική απόδοση των φετών για ένα τυπικό διάγραμμα πίτας.

Τα παραδείγματα εστιάζουν σε εργασίες προσαρμογής διαγράμματος όπως η προσθήκη ενός διαγράμματος σε μια διαφάνεια, η ρύθμιση των σειρών και των ετικετών, η αντικατάσταση των προεπιλεγμένων δεδομένων διαγράμματος με προσαρμοσμένες κατηγορίες και τιμές, και η αποθήκευση της ενημερωμένης παρουσίασης.

## **Επιλογές Δευτερεύοντος Διαγράμματος για Διαγράμματα Pie of Pie και Bar of Pie**

Το Aspose.Slides for Python μέσω Java υποστηρίζει επιλογές δευτερεύοντος διαγράμματος για διαγράμματα Pie of Pie και Bar of Pie. Αυτές οι επιλογές ελέγχουν το μέγεθος του δευτερεύοντος διαγράμματος και τον τρόπο με τον οποίο τα σημεία δεδομένων διαχωρίζονται μεταξύ των δύο διαγραμμάτων.

Το ακόλουθο παράδειγμα δημιουργεί ένα διάγραμμα Pie of Pie σε μια νέα παρουσίαση και εμφανίζει τις τιμές των σημείων δεδομένων ως ετικέτες. Η μέθοδος [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) ορίζει το μέγεθος του δευτερεύοντος διαγράμματος στο 149 % του κύριου διαγράμματος. Η [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) επιλέγει διαίρεση βάσει ποσοστού, και η [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) ορίζει το όριο στο 53 %.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # Εμφάνιση τιμών και ρύθμιση του δευτερεύοντος διαγράμματος.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Επιλογή Κατηγοριών για το Δευτερεύον Διάγραμμα**

Χρησιμοποιήστε προσαρμοσμένη διαίρεση όταν θέλετε να ομαδοποιήσετε συγκεκριμένες κατηγορίες στο δευτερεύον διάγραμμα ανεξάρτητα από τις τιμές ποσοστών τους. Για παράδειγμα, μια έκθεση πωλήσεων μπορεί να εμφανίζει το Online και τα Events μαζί ώστε οι αναγνώστες να μπορούν να συγκρίνουν αυτά τα δύο κανάλια, ακόμη και αν αποτελούν το 35 % και το 10 % των συνολικών πωλήσεων.

Καλέστε τη [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) με το [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) και επιλέξτε τα σημεία μέσω της [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Η μέθοδος [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) της συλλογής δέχεται έναν δείκτη μηδενικής βάσης στη σειρά· χρησιμοποιήστε την [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) για να προσθέσετε ένα αντικείμενο σημείου δεδομένων. Σε αυτό το παράδειγμα, ο δείκτης 1 επιλέγει το Online, και το σημείο με δείκτη 3 επιλέγει τα Events. Το Partners προστίθεται προσωρινά, έπειτα αποκλείεται χρησιμοποιώντας την [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # Αντικατάσταση των προεπιλεγμένων δεδομένων με πωλήσεις ανά κανάλι.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Επιλογή του Online βάσει του μηδενικού ευρετηρίου του και των Events βάσει του αντικειμένου σημείου δεδομένων.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Αποκλεισμός του Partners από την επιλογή χωρίς διαγραφή των δεδομένων προέλευσης.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το Online (35) και τα Events (10) εμφανίζονται ως ξεχωριστές φέτες στο δευτερεύον διάγραμμα. Στο κύριο διάγραμμα, αντιπροσωπεύονται από μία συνδυασμένη φέτα με τιμή 45, μαζί με το Retail (40) και το Partners (15). Η αφαίρεση του Partners από την προσαρμοσμένη επιλογή το διατηρεί στο κύριο διάγραμμα· δεν αφαιρεί την κατηγορία ή την τιμή της από τα δεδομένα πηγής του διαγράμματος.

Η παρακάτω εικόνα δείχνει την αποθηκευμένη παρουσίαση στο PowerPoint:

![Διάγραμμα Pie of Pie με Online και Events στο δευτερεύον διάγραμμα και την συνδυασμένη τους τιμή 45 στο κύριο διάγραμμα](pie_of_pie_custom.png)

## **Ορισμός Αυτόματων Χρωμάτων Φετών σε Διάγραμμα Πίτας**

Το Aspose.Slides for Python μέσω Java μπορεί αυτόματα να αναθέτει διαφορετικά χρώματα στις φέτες ενός διαγράμματος πίτας. Το ακόλουθο παράδειγμα δημιουργεί ένα διάγραμμα πίτας με τίτλο στο κέντρο και αντικαθιστά τα προεπιλεγμένα δεδομένα με τρεις τριμηνιαίες κατηγορίες και τις τιμές τους. Η μέθοδος [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) εμφανίζει τις τιμές 20, 50 και 30 ως ετικέτες, ενώ η [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) ενεργοποιεί διαφορετικό χρώμα για κάθε φέτα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Προσθήκη κεντραρισμένου τίτλου διαγράμματος.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Αντικατάσταση των προεπιλεγμένων δεδομένων χρησιμοποιώντας το πρώτο φύλλο εργασίας.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # Εμφάνιση τιμών και ανάθεση διαφορετικών χρωμάτων στις φέτες.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζονται οι παραλλαγές Pie of Pie και Bar of Pie;**

Ναι, η βιβλιοθήκη [υποστηρίζει](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) ένα δευτερεύον διάγραμμα για διαγράμματα πίτας, συμπεριλαμβανομένων των τύπων Pie of Pie και Bar of Pie.

**Μπορώ να εξάγω μόνο το διάγραμμα ως εικόνα (π.χ., PNG);**

Ναι, μπορείτε να [εξάγετε το ίδιο το διάγραμμα ως εικόνα](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (όπως PNG) χωρίς να εξάγετε ολόκληρη την παρουσίαση.