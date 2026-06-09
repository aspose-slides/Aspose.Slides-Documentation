---
title: Προσαρμογή 3D διαγραμμάτων σε παρουσιάσεις με Python
linktitle: 3D Διάγραμμα
type: docs
url: /el/python-net/3d-chart/
keywords:
- 3D διάγραμμα
- περιστροφή
- βάθος
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε 3‑Δ διαγράμματα στο Aspose.Slides for Python via .NET, με υποστήριξη αρχείων PPT, PPTX και ODP — ενισχύστε τις παρουσιάσεις σας σήμερα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε ένα 3D γράφημα στο Aspose.Slides με τη διαμόρφωση των ρυθμίσεων `rotation_3d` όπως `rotation_x`, `rotation_y`, `depth_percents` και `right_angle_axes`. Περιγράφει τη δημιουργία μιας παρουσίασης, την προσθήκη ενός 3D γραφήματος με προεπιλεγμένα δεδομένα, την εφαρμογή των απαιτούμενων ρυθμίσεων 3D προβολής και την αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

## **Ορισμός ιδιοτήτων RotationX, RotationY και DepthPercents του 3D γραφήματος**
Το Aspose.Slides for Python via .NET παρέχει ένα απλό API για τον ορισμό αυτών των ιδιοτήτων. Το παρακάτω άρθρο θα σας βοηθήσει να ορίσετε διαφορετικές ιδιότητες όπως η περιστροφή X, Y, **DepthPercents** κ.λπ. Ο κώδικας δείγματος εφαρμόζει τη ρύθμιση των παραπάνω ιδιοτήτων.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθήκη γραφήματος με προεπιλεγμένα δεδομένα.
1. Ορισμός ιδιοτήτων Rotation3D.
1. Εγγραφή της τροποποιημένης παρουσίασης σε αρχείο PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
with slides.Presentation() as presentation:
            
    # Πρόσβαση στην πρώτη διαφάνεια
    slide = presentation.slides[0]

    # Προσθήκη γραφήματος με προεπιλεγμένα δεδομένα
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Ορισμός του δείκτη του φύλλου δεδομένων του γραφήματος
    defaultWorksheetIndex = 0

    # Λήψη του φύλλου εργασίας δεδομένων του γραφήματος
    fact = chart.chart_data.chart_data_workbook

    # Προσθήκη σειράς
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Προσθήκη κατηγοριών
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Ορισμός ιδιοτήτων Rotation3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Λήψη της δεύτερης σειράς του γραφήματος
    series = chart.chart_data.series[1]

    # Τώρα γεμίζουμε τα δεδομένα της σειράς
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Ορισμός τιμής OverLap
    series.parent_series_group.overlap = 100         

    # Αποθήκευση της παρουσίασης στον δίσκο
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές ερωτήσεις**

**Ποιους τύπους γραφημάτων υποστηρίζει το Aspose.Slides σε λειτουργία 3D;**

Το Aspose.Slides υποστηρίζει 3D παραλλαγές των ραβδογραφικών, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100% Stacked Column 3D, καθώς και σχετικούς 3D τύπους που εκτίθενται μέσω της αρίθμησης [ChartType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/charttype/). Για μια ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη του [ChartType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/charttype/) στην αναφορά API της εγκατεστημένης έκδοσής σας.

**Μπορώ να λάβω ένα raster εικόνα ενός 3D γραφήματος για αναφορά ή το web;**

Ναι. Μπορείτε να εξάγετε ένα γράφημα σε εικόνα μέσω του [chart API](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/get_image/) ή να [αποδώσετε ολόκληρη τη διαφάνεια](/slides/el/python-net/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια ακριβή εικόνα pixel‑perfect ή θέλετε να ενσωματώσετε το γράφημα σε έγγραφα, πίνακες ελέγχου ή ιστοσελίδες χωρίς να απαιτείται το PowerPoint.

**Ποια είναι η απόδοση της δημιουργίας και απόδοσης μεγάλων 3D γραφημάτων;**

Η απόδοση εξαρτάται από τον όγκο δεδομένων και την οπτική πολυπλοκότητα. Για καλύτερα αποτελέσματα, κρατήστε τα 3D εφέ στο ελάχιστο, αποφύγετε βαριές υφές στους τοίχους και στις περιοχές σχεδίασης, περιορίστε τον αριθμό σημείων δεδομένων ανά σειρά όταν είναι δυνατόν, και αποδώστε σε εξαγόμενο με κατάλληλο μέγεθος (ανάλυση και διαστάσεις) ώστε να ταιριάζει με την προβλεπόμενη οθόνη ή τις ανάγκες εκτύπωσης.