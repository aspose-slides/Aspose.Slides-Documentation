---
title: "Προσαρμογή υπομνημάτων διαγράμματος σε παρουσιάσεις με χρήση Python"
linktitle: "Υπόμνημα Γραφήματος"
type: docs
url: /el/python-java/chart-legend/
keywords:
- υπόμνημα διαγράμματος
- θέση υπομνήματος
- μέγεθος γραμματοσειράς
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Προσαρμόστε τα υπομνήματα διαγράμματος με Aspose.Slides για Python μέσω Java για να βελτιστοποιήσετε τις παρουσιάσεις PowerPoint με προσαρμοσμένη μορφοποίηση υπομνήματος."
---
## **Επισκόπηση**

Aspose.Slides for Python via Java παρέχει επιλογές για προσαρμογή των υπομνημάτων διαγραμμάτων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο δείχνει πώς να τοποθετήσετε και να ορίσετε το μέγεθος ενός υπομνήματος, να ορίσετε το μέγεθος γραμματοσειράς για ολόκληρο το υπόμνημα, να μορφοποιήσετε μια μεμονωμένη εισαγωγή υπομνήματος και να κρύψετε ή να αποκαταστήσετε επιλεγμένες εισαγωγές.

Το FAQ καλύπτει σχετικές συμπεριφορές, συμπεριλαμβανομένης της κράτησης χώρου για το υπόμνημα, της εμφάνισης ετικετών πολλαπλών γραμμών και της κληρονομίας μορφοποίησης από το θέμα της παρουσίασης.

## **Θέση Υπομνήματος**

Χρησιμοποιήστε τις μεθόδους [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth), και [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) του υπομνήματος για να καθορίσετε τη θέση και το μέγεθός του ως κλάσματα των διαστάσεων του διαγράμματος.

Αυτό το παράδειγμα δημιουργεί μια παρουσίαση και προσθέτει ένα σύμπλεγμα στηλών (clustered column chart) με προεπιλεγμένα δεδομένα στην πρώτη διαφάνεια. Η διαίρεση των επιθυμητών αποσβών και διαστάσεων του υπομνήματος με το πλάτος και το ύψος του διαγράμματος τα μετατρέπει σε σχετικές τιμές: το υπόμνημα είναι μετατοπισμένο κατά 50 σημεία από την επάνω αριστερή γωνία του διαγράμματος και έχει μέγεθος 100 επί 100 σημεία.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Εκφράστε τη θέση και το μέγεθος του υπομνήματος σε σχέση με το γράφημα.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Μεγέθους Γραμματοσειράς Υπομνήματος**

Χρησιμοποιήστε το [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) του υπομνήματος για να αποκτήσετε πρόσβαση στη διαμόρφωση κειμένου και χρησιμοποιήστε το [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) για να ορίσετε το μέγεθος γραμματοσειράς σε σημεία.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα με προεπιλεγμένα δεδομένα και ορίζει το κείμενο του υπομνήματος σε 20 σημεία. Επίσης απενεργοποιεί τα αυτόματα όρια για τον κατακόρυφο άξονα και ορίζει την περιοχή του από -5 έως 10.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Μεγέθους Γραμματοσειράς Μεμονωμένης Εγγραφής Υπομνήματος**

Χρησιμοποιήστε τη συλλογή που επιστρέφει η μέθοδος [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) του υπομνήματος για να αποκτήσετε πρόσβαση στη μορφοποίηση μιας συγκεκριμένης εγγραφής. Οι δείκτες των εγγραφών αρχίζουν από το μηδέν, επομένως ο δείκτης `1` αναφέρεται στη δεύτερη εγγραφή.

Αυτό το παράδειγμα δημιουργεί ένα σύμπλεγμα στηλών με προεπιλεγμένα δεδομένα που περιλαμβάνει τουλάχιστον δύο σειρές. Μορφοποιεί τη δεύτερη εγγραφή του υπομνήματος με έντονη, πλάγια και κείμενο μπλε 20 σημείων.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Απόκρυψη Μεμονωμένων Εγγραφών Υπομνήματος**

Για να εξαιρέσετε μια βοηθητική σειρά από το υπόμνημα ενώ διατηρείτε τα δεδομένα της ορατά, καλέστε το [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) με `True` μέσω του [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry). Αυτό κρύβει μόνο την επιλεγμένη εγγραφή του υπομνήματος· δεν αφαιρεί τη σειρά ή τα σημεία δεδομένων της. Αντιθέτως, καλώντας το [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) με `False` κρύβει ολόκληρο το υπόμνημα.

Το παρακάτω παράδειγμα δημιουργεί ένα σύμπλεγμα στηλών με πολλαπλές σειρές χρησιμοποιώντας προεπιλεγμένα δεδομένα. Κρύβει την εγγραφή υπομνήματος της δεύτερης σειράς (δείκτης `1`) και αποθηκεύει την παρουσίαση. Στη συνέχεια αποκαθιστά την εγγραφή καλώντας το [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) με `False` και αποθηκεύει ένα δεύτερο αντίγραφο. Οι στήλες παραμένουν ορατές και στα δύο αρχεία.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # Αποκαταστήστε την ίδια εγγραφή χωρίς να αλλάξετε τα δεδομένα του διαγράμματος.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η παρακάτω σύγκριση δείχνει το ίδιο γράφημα με όλες τις εγγραφές ορατές και με τη δεύτερη εγγραφή κρυφή. Οι στήλες της δεύτερης σειράς παραμένουν αμετάβλητες.

![Σύγκριση ενός γραφήματος με όλες τις εγγραφές υπομνήματος ορατές και με τη Σειρά 2 κρυμμένη από το υπόμνημα· όλες οι στήλες παραμένουν ορατές.](hide-legend-entry.png)

Σε γραφήματα στήλης, μπάρας και γραμμής, οι εγγραφές του υπομνήματος αναγνωρίζουν σειρές. Για γραφήματα πίτας, αναγνωρίζουν μεμονωμένα σημεία δεδομένων (κομμάτια), επομένως χρησιμοποιήστε το [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) στο επιλεγμένο κομμάτι. Το API καταγράφει αυτή τη μέθοδο σημείου δεδομένων για τους τύπους γραφημάτων `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` και `BarOfPie`. Μην υποθέτετε ότι ισχύει για γραφήματα δακτυλίου, που δεν περιλαμβάνονται σε αυτή τη λίστα.

## **FAQ**

**Μπορώ να κάνω το γράφημα να δεσμεύει χώρο για το υπόμνημα αντί να το επικαλύπτει;**

Ναι. Καλέστε το [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) με `False` για να δεσμεύσετε χώρο για το υπόμνημα αντί να επιτρέψετε να επικαλύπτει την περιοχή σχεδίασης.

**Μπορώ να δημιουργήσω ετικέτες υπομνήματος πολλαπλών γραμμών;**

Ναι. Οι μεγάλες ετικέτες μπορούν να αναδιπλώνονται όταν το διαθέσιμο πλάτος είναι ανεπαρκές. Μπορείτε επίσης να χρησιμοποιήσετε χαρακτήρες νέας γραμμής στα ονόματα των σειρών για να ζητήσετε αλλαγές γραμμής.

**Πώς μπορώ να κάνω το υπόμνημα να ακολουθεί το χρωματικό σχήμα του θέματος της παρουσίασης;**

Αφήστε τα χρώματα, γεμίσματα και γραμματοσειρές του υπομνήματος ακαθορισμένα ώστε να κληρονομεί τη μορφοποίηση του θέματος. Η ρητή μορφοποίηση αντικαθιστά τις αντίστοιχες ρυθμίσεις του θέματος.