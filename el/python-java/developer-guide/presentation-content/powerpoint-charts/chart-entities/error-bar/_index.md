---
title: Προσαρμογή Μπαρών Σφάλματος σε Διαγράμματα Παρουσίασης με Python
linktitle: Μπάρα Σφάλματος
type: docs
url: /el/python-java/error-bar/
keywords:
- μπάρα σφάλματος
- προσαρμοσμένη τιμή
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να προσαρμόζετε τις μπάρες σφάλματος σε διαγράμματα με το Aspose.Slides for Python via Java—βελτιώστε τις οπτικοποιήσεις δεδομένων σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με μπάρες σφάλματος σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να προσθέσετε μπάρες σφάλματος σε σειρά διαγράμματος, να ρυθμίσετε τις ρυθμίσεις των μπαρών σφάλματος X και Y, και να εφαρμόσετε διαφορετικούς τύπους τιμών όπως σταθερές, ποσοστιαίες και προσαρμοσμένες τιμές.

Επίσης, παρουσιάζει πώς να ορίσετε προσαρμοσμένες τιμές μπαρών σφάλματος για μεμονωμένα σημεία δεδομένων σε μια σειρά χρησιμοποιώντας τη σχετική συλλογή σημείων δεδομένων. Επιπλέον, το άρθρο περιλαμβάνει σύντομες σημειώσεις σχετικά με τη συμπεριφορά των μπαρών σφάλματος κατά την εξαγωγή, τη συμβατότητά τους με σημεία σήμανσης και ετικέτες δεδομένων, και πού να βρείτε τις σχετικές κλάσεις και τα enum αναφοράς του API.

## **Προσθήκη Μπάρων Σφάλματος**

Το Aspose.Slides for Python via Java παρέχει ένα απλό API για τη διαχείριση τιμών μπαρών σφάλματος. Ο παρακάτω κώδικας παραδείγματος χρησιμοποιεί σταθερούς και ποσοστιαίους τύπους τιμών.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Προσθέστε ένα διάγραμμα φυσαλίδων στη ζητούμενη διαφάνεια.
3. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή X των μπαρών σφάλματος.
4. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή Y των μπαρών σφάλματος.
5. Ορίστε τις τιμές και τη μορφοποίηση των μπαρών σφάλματος.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Δημιουργήστε ένα αντίγραφο της κλάσης Presentation.
presentation = Presentation()
try:
    # Δημιουργήστε ένα διάγραμμα φυσαλίδων.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Προσθέστε μπάρες σφάλματος και ορίστε τη μορφοποίηση τους.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # Αποθηκεύστε την παρουσίαση.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Προσθήκη Προσαρμοσμένων Τιμών Μπάρων Σφάλματος**

Το Aspose.Slides for Python via Java παρέχει ένα απλό API για τη διαχείριση προσαρμοσμένων τιμών μπαρών σφάλματος. Ο παρακάτω κώδικας παραδείγματος εφαρμόζεται όταν η μέθοδος [getValueType](https://reference.aspose.com/slides/el/python-java/aspose.slides/errorbarsformat/#getValueType) επιστρέφει το [ErrorBarValueType.Custom](https://reference.aspose.com/slides/el/python-java/aspose.slides/errorbarvaluetype/#Custom). Για να καθορίσετε μια τιμή, χρησιμοποιήστε τη μέθοδο [getErrorBarsCustomValues](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) για ένα συγκεκριμένο σημείο δεδομένων στη συλλογή που επιστρέφεται από τη μέθοδο σειράς [getDataPoints](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getDataPoints).

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Προσθέστε ένα διάγραμμα φυσαλίδων στη ζητούμενη διαφάνεια.
3. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή X των μπαρών σφάλματος.
4. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή Y των μπαρών σφάλματος.
5. Προσπελάστε τα μεμονωμένα σημεία δεδομένων στη σειρά διαγράμματος και ορίστε τις τιμές των μπαρών σφάλματος.
6. Ορίστε τις τιμές και τη μορφοποίηση των μπαρών σφάλματος.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```python
import jpade
import asposeslides

if not jpape.isJVMStarted():
    jpape.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Δημιουργήστε ένα αντίγραφο της κλάσης Presentation.
presentation = Presentation()
try:
    # Δημιουργήστε ένα διάγραμμα φυσαλίδων.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Προσθέστε προσαρμοσμένες μπάρες σφάλματος και ορίστε τη μορφοποίησή τους.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Προσπελάστε τα σημεία δεδομένων της σειράς διαγράμματος και ρυθμίστε τις πηγές τιμών των μπαρών σφάλματος.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Ορίστε τις τιμές μπαρών σφάλματος για τα σημεία δεδομένων της σειράς διαγράμματος.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Αποθηκεύστε την παρουσίαση.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Τι συμβαίνει με τις μπάρες σφάλματος όταν εξάγετε μια παρουσίαση σε PDF ή εικόνες;**

Αποδίδονται ως μέρος του διαγράμματος και διατηρούνται κατά τη μετατροπή μαζί με την υπόλοιπη μορφοποίηση του διαγράμματος, εφόσον χρησιμοποιείται συμβατή έκδοση ή μηχανή απόδοσης.

**Μπορούν οι μπάρες σφάλματος να συνδυαστούν με σημεία σήμανσης και ετικέτες δεδομένων;**

Ναι. Οι μπάρες σφάλματος είναι ξεχωριστό στοιχείο και είναι συμβατές με σημεία σήμανσης και ετικέτες δεδομένων· εάν τα στοιχεία επικαλύπτονται, ίσως χρειαστεί να προσαρμόσετε τη μορφοποίηση.

**Πού μπορώ να βρω τη λίστα των ιδιοτήτων και κλάσεων για εργασία με μπάρες σφάλματος στο API;**

Στην αναφορά του API: η κλάση [ErrorBarsFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/errorbarsformat/) και οι σχετικές κλάσεις [ErrorBarType](https://reference.aspose.com/slides/el/python-java/aspose.slides/errorbartype/) και [ErrorBarValueType](https://reference.aspose.com/slides/el/python-java/aspose.slides/errorbarvaluetype/).