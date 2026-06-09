---
title: Διαχείριση Δεικτών Δεδομένων Γραφήματος σε Παρουσιάσεις με Python
linktitle: Δείκτης Δεδομένων
type: docs
url: /el/python-net/chart-data-marker/
keywords:
- γράφημα
- σημείο δεδομένων
- δείκτης
- επιλογές δεικτών
- μέγεθος δείκτη
- τύπος γεμίσματος
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να προσαρμόζετε τους δείκτες δεδομένων γραφήματος στο Aspose.Slides, ενισχύοντας την επίδραση της παρουσίασης σε μορφές PPT, PPTX και ODP με σαφή παραδείγματα κώδικα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με δείκτες δεδομένων γραφήματος στο Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα γράφημα, να αποκτήσετε πρόσβαση σε μια σειρά και τα σημεία δεδομένων της, να εφαρμόσετε γεμίσεις εικόνας στους δείκτες σε επίπεδο σημείου δεδομένων, να ρυθμίσετε το μέγεθος του δείκτη και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Αναφέρει επίσης ότι τα τυπικά σχήματα δεικτών διατίθενται μέσω της απαρίθμησης `MarkerStyleType` και ότι η εμφάνιση του δείκτη διατηρείται κατά την εξαγωγή γραφημάτων σε μορφές raster ή SVG.

## **Ορισμός Επιλογών Δείκτη Γραφήματος**
Οι δείκτες μπορούν να οριστούν στα σημεία δεδομένων του γραφήματος μέσα σε συγκεκριμένες σειρές. Για να ορίσετε τις επιλογές δείκτη γραφήματος, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε την κλάση [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
- Δημιουργία προεπιλεγμένου γραφήματος.
- Ορίστε την εικόνα.
- Αποκτήστε την πρώτη σειρά του γραφήματος.
- Προσθέστε νέο σημείο δεδομένων.
- Αποθηκεύστε την παρουσίαση στο δίσκο.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε ένα αντίτυπο της κλάσης Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Δημιουργία του προεπιλεγμένου γραφήματος
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Λήψη του δείκτη του προεπιλεγμένου φύλλου δεδομένων γραφήματος
    defaultWorksheetIndex = 0

    # Λήψη του φύλλου δεδομένων γραφήματος
    fact = chart.chart_data.chart_data_workbook

    # Διαγραφή της δοκιμαστικής σειράς
    chart.chart_data.series.clear()

    # Προσθήκη νέας σειράς
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Ορισμός εικόνας
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Ορισμός εικόνας
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Πάρε την πρώτη σειρά του γραφήματος
    series = chart.chart_data.series[0]

    # Προσθήκη νέου σημείου (1:3) εκεί.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # Αλλαγή του δείκτη της σειράς γραφήματος
    series.marker.size = 15

    # Αποθήκευση παρουσίασης στον δίσκο
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Ποια σχήματα δεικτών είναι διαθέσιμα εξ' αρχής;**

Διατίθενται τυπικά σχήματα (κύκλος, τετράγωνο, διαμάντι, τρίγωνο κ.λπ.)· η λίστα ορίζεται από την απαρίθμηση [MarkerStyleType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/markerstyletype/). Εάν χρειάζεστε μη τυπικό σχήμα, χρησιμοποιήστε έναν δείκτη με γέμιση εικόνας για να προσομοιώσετε προσαρμοστικά γραφικά.

**Διατηρούνται οι δείκτες κατά την εξαγωγή ενός γραφήματος σε εικόνα ή SVG;**

Ναι. Κατά τη μετατροπή γραφημάτων σε [μορφές raster](/slides/el/python-net/convert-powerpoint-to-png/) ή την αποθήκευση [σχεδίων ως SVG](/slides/el/python-net/render-a-slide-as-an-svg-image/), οι δείκτες διατηρούν την εμφάνιση και τις ρυθμίσεις τους, συμπεριλαμβανομένου του μεγέθους, της γέμισης και του περιγράμματος.