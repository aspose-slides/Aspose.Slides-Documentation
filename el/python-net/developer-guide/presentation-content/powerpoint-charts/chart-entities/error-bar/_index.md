---
title: Προσαρμογή γραμμών σφάλματος σε διαγράµματα παρουσίασης με Python
linktitle: Γραμμή σφάλματος
type: docs
url: /el/python-net/error-bar/
keywords:
- γραμμή σφάλματος
- προσαρμοσμένη τιμή
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να προσαρμόζετε γραμμές σφάλματος σε διαγράµματα με το Aspose.Slides για Python μέσω .NET—βελτιώστε τις οπτικές παρουσίασης δεδομένων σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλέψετε με γραμμές σφάλματος σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να προσθέσετε γραμμές σφάλματος σε σειρά διαγράμματος, να ρυθμίσετε τις ρυθμίσεις γραμμών σφάλματος X και Y, και να εφαρμόσετε διαφορετικούς τύπους τιμών όπως σταθερές, ποσοστιαίες και προσαρμοσμένες τιμές.

Επίσης, δείχνει πώς να ορίσετε προσαρμοσμένες τιμές γραμμής σφάλματος για μεμονωμένα σημεία δεδομένων σε μια σειρά χρησιμοποιώντας τη συναφή συλλογή σημείων δεδομένων. Επιπλέον, το άρθρο περιλαμβάνει σύντομες σημειώσεις σχετικά με τη συμπεριφορά των γραμμών σφάλματος κατά την εξαγωγή, τη συμβατότητά τους με δείκτες και ετικέτες δεδομένων, και πού να βρείτε τις σχετικές κλάσεις και enum της αναφοράς API.

## **Προσθήκη Γραμμής Σφάλματος**
Το Aspose.Slides για Python μέσω .NET παρέχει ένα απλό API για τη διαχείριση τιμών γραμμής σφάλματος. Ο κώδικας δείγματος ισχύει όταν χρησιμοποιείται προσαρμοσμένος τύπος τιμής. Για να καθορίσετε μία τιμή, χρησιμοποιήστε την ιδιότητα **ErrorBarCustomValues** ενός συγκεκριμένου σημείου δεδομένων στη συλλογή **DataPoints** της σειράς:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Προσθέστε ένα διάγραμμα φυσαλίδων στη ζητούμενη διαφάνεια.
1. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή X της γραμμής σφάλματος.
1. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή Y της γραμμής σφάλματος.
1. Ορισμός τιμών γραμμών και μορφοποίησης.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Δημιουργία κενής παρουσίασης
with slides.Presentation() as presentation:
    # Δημιουργία διαγράμματος φυσαλίδων
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Προσθήκη γραμμών σφάλματος και ορισμός μορφής τους
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # Αποθήκευση παρουσίασης
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσθήκη Προσαρμοσμένης Τιμής Γραμμής Σφάλματος**
Το Aspose.Slides για Python μέσω .NET παρέχει ένα απλό API για τη διαχείριση προσαρμοσμένων τιμών γραμμής σφάλματος. Ο κώδικας δείγματος ισχύει όταν η ιδιότητα **IErrorBarsFormat.ValueType** είναι ίση με **Custom**. Για να καθορίσετε μία τιμή, χρησιμοποιήστε την ιδιότητα **ErrorBarCustomValues** ενός συγκεκριμένου σημείου δεδομένων στη συλλογή **DataPoints** της σειράς:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Προσθέστε ένα διάγραμμα φυσαλίδων στη ζητούμενη διαφάνεια.
1. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή X της γραμμής σφάλματος.
1. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή Y της γραμμής σφάλματος.
1. Προσπελάστε τα μεμονωμένα σημεία δεδομένων της σειράς διαγράμματος και ορίστε τις τιμές της γραμμής σφάλματος για κάθε σημείο δεδομένων.
1. Ορισμός τιμών γραμμών και μορφοποίησης.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Δημιουργία κενής παρουσίασης
with slides.Presentation() as presentation:
    # Δημιουργία διαγράμματος φυσαλίδων
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Προσθήκη προσαρμοσμένων γραμμών σφάλματος και ορισμός μορφής τους
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Πρόσβαση σε σημείο δεδομένων σειράς διαγράμματος και ορισμός τιμών γραμμής σφάλματος για μεμονωμένο σημείο
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Ορισμός γραμμών σφάλματος για σημεία σειράς διαγράμματος
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Αποθήκευση παρουσίασης
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Τι συμβαίνει με τις γραμμές σφάλματος κατά την εξαγωγή μιας παρουσίασης σε PDF ή εικόνες;**

Αυτές αποδίδονται ως μέρος του διαγράμματος και διατηρούνται κατά τη μετατροπή μαζί με τη μορφοποίηση του διαγράμματος, εφόσον χρησιμοποιείται συμβατή έκδοση ή μηχανή rendering.

**Μπορούν οι γραμμές σφάλματος να συνδυαστούν με δείκτες και ετικέτες δεδομένων;**

Ναι. Οι γραμμές σφάλματος είναι ξεχωριστό στοιχείο και είναι συμβατές με δείκτες και ετικέτες δεδομένων· εάν τα στοιχεία επικαλύπτονται, ίσως χρειαστεί να προσαρμόσετε τη μορφοποίηση.

**Πού μπορώ να βρω τη λίστα των ιδιοτήτων και των enum για εργασία με γραμμές σφάλματος στο API;**

Στην αναφορά API: η κλάση [ErrorBarsFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/errorbarsformat/) και τα σχετικά enum [ErrorBarType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/errorbartype/) και [ErrorBarValueType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/errorbarvaluetype/).