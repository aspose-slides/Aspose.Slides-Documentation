---
title: Προσαρμογή 3D διαγραμμάτων σε παρουσιάσεις με χρήση Python
linktitle: Διάγραμμα 3D
type: docs
url: /el/python-java/3d-chart/
keywords:
- Διάγραμμα 3D
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα 3D στο Aspose.Slides για Python μέσω Java, με υποστήριξη αρχείων PPT και PPTX—βελτιώστε τις παρουσιάσεις σας σήμερα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε ένα 3D γράφημα στο Aspose.Slides διαμορφώνοντας τις ρυθμίσεις [Rotation3D](https://reference.aspose.com/slides/el/python-java/aspose.slides/rotation3d/) όπως [setRotationX](https://reference.aspose.com/slides/el/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/el/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/el/python-java/aspose.slides/rotation3d/#setDepthPercents) και [setRightAngleAxes](https://reference.aspose.com/slides/el/python-java/aspose.slides/rotation3d/#setRightAngleAxes). Περιγράφεται η δημιουργία μιας παρουσίασης, η προσθήκη 3D γραφήματος με προεπιλεγμένα δεδομένα, η εφαρμογή των απαιτούμενων ρυθμίσεων 3D προβολής και η αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

## **Ορισμός περιστροφής X, περιστροφής Y και βάθους ενός 3D γραφήματος**
Το Aspose.Slides for Python via Java παρέχει ένα απλό API για τον ορισμό αυτών των ιδιοτήτων. Το παρακάτω παράδειγμα δείχνει πώς να ορίσετε την περιστροφή X, την περιστροφή Y και το βάθος ενός 3D γραφήματος.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε ένα γράφημα με προεπιλεγμένα δεδομένα.
1. Ορίστε τις ιδιότητες περιστροφής 3D.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη διαγράμματος με προεπιλεγμένα δεδομένα.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # Ορισμός δείκτη φύλλου εργασίας δεδομένων διαγράμματος.
    default_worksheet_index = 0

    # Λήψη βιβλίου εργασίας δεδομένων διαγράμματος.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Προσθήκη σειρών.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Προσθήκη κατηγοριών.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # Ορισμός ιδιοτήτων περιστροφής 3D.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # Πρόσβαση στη δεύτερη σειρά διαγράμματος.
    series = chart.getChartData().getSeries().get_Item(1)

    # Συμπλήρωση δεδομένων σειράς.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # Αποθήκευση παρουσίασης.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Ποιοι τύποι γραφημάτων υποστηρίζουν τη λειτουργία 3D στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει 3D παραλλαγές των στηλών, όπως Column 3D, Clustered Column 3D, Stacked Column 3D και 100% Stacked Column 3D, μαζί με σχετικούς 3D τύπους που εκτίθενται μέσω της κλάσης [ChartType](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/). Για μια ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη του [ChartType](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/) στην αναφορά API της εγκατεστημένης έκδοσής σας.

**Μπορώ να λάβω μια ραστερ εικόνα ενός 3D γραφήματος για μια αναφορά ή το διαδίκτυο;**

Ναι. Μπορείτε να εξάγετε ένα γράφημα σε εικόνα μέσω του [chart API](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getImage) ή να [εξάγετε ολόκληρη τη διαφάνεια](/slides/el/python-java/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια ακριβή προεπισκόπηση ή θέλετε να ενσωματώσετε το γράφημα σε έγγραφα, πίνακες ελέγχου ή ιστοσελίδες χωρίς να απαιτείται PowerPoint.

**Πόσο αποδοτικό είναι το κτίσιμο και η απόδοση μεγάλων 3D γραφημάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και τη σύνθετη οπτική παρουσίαση. Για καλύτερα αποτελέσματα, περιορίστε τις 3D επιδράσεις, αποφύγετε βαριές υφές σε τοίχους και περιοχές σχεδίασης, περιορίστε τον αριθμό σημείων δεδομένων ανά σειρά όταν είναι δυνατόν, και αποδώστε σε κατάλληλο μέγεθος εξόδου (ανάλυση και διαστάσεις) ώστε να ταιριάζει με την προβλεπόμενη οθόνη ή εκτύπωση.