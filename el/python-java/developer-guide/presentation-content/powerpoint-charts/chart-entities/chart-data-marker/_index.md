---
title: Διαχείριση Δεικτών Δεδομένων Γραφημάτων σε Παρουσιάσεις με Python
linktitle: Δείκτης Δεδομένων
type: docs
url: /el/python-java/chart-data-marker/
keywords:
- γράφημα
- σημείο δεδομένων
- δείκτης
- επιλογές δεικτών
- μέγεθος δείκτη
- τύπος γεμίσματος
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσαρμόζετε τους δείκτες δεδομένων γραφημάτων στο Aspose.Slides για Python μέσω Java, ενισχύοντας την επίδραση των παρουσιάσεων σε μορφές PPT και PPTX με ξεκάθαρα παραδείγματα κώδικα Python."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με δείκτες δεδομένων γραφημάτων στο Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα γράφημα, να προσπελάσετε μια σειρά και τα σημεία δεδομένων της, να εφαρμόσετε γεμίσματα εικόνας στους δείκτες στο επίπεδο των σημείων δεδομένων, να προσαρμόσετε το μέγεθος του δείκτη και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Επισημαίνει επίσης ότι τα τυπικά σχήματα δεικτών είναι διαθέσιμα μέσω της απαρίθμησης [MarkerStyleType](https://reference.aspose.com/slides/el/python-java/aspose.slides/markerstyletype/) και ότι η εμφάνιση του δείκτη διατηρείται κατά την εξαγωγή γραφημάτων σε μορφές raster ή SVG.

## **Ορισμός Επιλογών Δείκτη Γραφήματος**
Μπορείτε να ορίσετε δείκτες στα σημεία δεδομένων του γραφήματος εντός μιας συγκεκριμένης σειράς. Για να ορίσετε επιλογές δείκτη γραφήματος, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
- Δημιουργήστε το προεπιλεγμένο γράφημα.
- Ορίστε τις εικόνες.
- Προσπελάστε την πρώτη σειρά του γραφήματος.
- Προσθέστε νέα σημεία δεδομένων.
- Αποθηκεύστε την παρουσίαση στο δίσκο.

Το παρακάτω παράδειγμα ορίζει επιλογές δείκτη γραφήματος σε επίπεδο σημείου δεδομένων.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Δημιουργήστε μια κενή παρουσίαση.
presentation = Presentation()
try:
    # Προσπελάστε την πρώτη διαφάνεια
    slide = presentation.getSlides().get_Item(0)

    # Δημιουργία του προεπιλεγμένου γραφήματος
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Ανάκτηση του προεπιλεγμένου δείκτη φύλλου εργασίας δεδομένων γραφήματος.
    default_worksheet_index = 0

    # Ανάκτηση του βιβλίου εργασίας δεδομένων γραφήματος.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Διαγραφή δοκιμαστικών σειρών
    chart.getChartData().getSeries().clear()

    # Προσθήκη νέας σειράς
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # Φόρτωση της πρώτης εικόνας.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # Φόρτωση της δεύτερης εικόνας.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # Προσπελάστε την πρώτη σειρά γραφήματος.
    series = chart.getChartData().getSeries().get_Item(0)

    # Προσθήκη σημείων δεδομένων.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # Αλλαγή του μεγέθους δεικτη της σειράς γραφήματος.
    series.getMarker().setSize(15)

    # Αποθήκευση παρουσίασης με γράφημα
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Ποια σχήματα δεικτών είναι διαθέσιμα κατ' εξοχήν;**

Διατίθενται τυπικά σχήματα (κύκλος, τετράγωνο, ρόμβος, τρίγωνο κ.ά.); η λίστα ορίζεται από την κλάση [MarkerStyleType](https://reference.aspose.com/slides/el/python-java/aspose.slides/markerstyletype/). Εάν χρειάζεστε μη τυπικό σχήμα, χρησιμοποιήστε έναν δείκτη με γεμιστό εικόνας για να προσομοιώσετε προσαρμοστικά οπτικά στοιχεία.

**Διατηρούνται οι δείκτες κατά την εξαγωγή ενός γραφήματος σε εικόνα ή SVG;**

Ναι. Κατά τη δημιουργία γραφημάτων σε [μορφές raster](/slides/el/python-java/convert-powerpoint-to-png/) ή αποθήκευση [σχημάτων ως SVG](/slides/el/python-java/render-a-slide-as-an-svg-image/), οι δείκτες διατηρούν την εμφάνιση και τις ρυθμίσεις τους, συμπεριλαμβανομένων του μεγέθους, του γεμίσματος και του περιγράμματος.