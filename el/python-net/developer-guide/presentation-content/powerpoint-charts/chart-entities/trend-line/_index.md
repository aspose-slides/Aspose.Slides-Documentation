---
title: Προσθήκη Γραμμών Τάσης σε Διαγράμματα Παρουσίασης με Python
linktitle: Γραμμή Τάσης
type: docs
url: /el/python-net/trend-line/
keywords:
- διάγραμμα
- γραμμή τάσης
- εκθετική γραμμή τάσης
- γραμμή τάσης γραμμική
- λογαριθμική γραμμή τάσης
- γραμμή τάσης κινητού μέσου
- πολυωνυμική γραμμή τάσης
- γραμμή τάσης δύναμης
- προσαρμοσμένη γραμμή τάσης
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Προσθέστε και προσαρμόστε γρήγορα γραμμές τάσης σε διαγράμματα PowerPoint και OpenDocument με Aspose.Slides για Python μέσω .NET — ένας πρακτικός οδηγός και παραδείγματα κώδικα για τη βελτίωση της ακρίβειας των προβλέψεων και την ενίσχυση της δέσμευσης του κοινού σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε γραμμές τάσης σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να προσθέσετε γραμμές τάσης σε σειρές διαγράμματος και να εργαστείτε με διάφορους τύπους γραμμών τάσης, όπως εκθετική, γραμμική, λογαρρυθμική, κινητός μέσος, πολυωνυμική και δύναμη.

Επιπλέον, περιγράφει πώς να προσθέσετε μια προσαρμοσμένη γραμμή σε ένα διάγραμμα εισάγοντας ένα σχήμα γραμμής, και περιλαμβάνει μια σύντομη Συχνές Ερωτήσεις σχετικά με τις τιμές πρόβλεψης της γραμμής τάσης προς μπροστά και προς τα πίσω, καθώς και εάν οι γραμμές τάσης διατηρούνται κατά την εξαγωγή σε PDF ή SVG και κατά τη δημιουργία εικόνων από διαγράμματα.

## **Προσθήκη Γραμμής Τάσης**
Aspose.Slides for Python via .NET παρέχει ένα απλό API για τη διαχείριση διαφορετικών γραμμών τάσης σε διαγράμματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Αποκτήστε την αναφορά μιας διαφάνειας με βάση τον δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με κάποιον από τους επιθυμητούς τύπους (αυτό το παράδειγμα χρησιμοποιεί ChartType.CLUSTERED_COLUMN).
1. Προσθήκη εκθετικής γραμμής τάσης για τη σειρά διαγράμματος 1.
1. Προσθήκη γραμμικής γραμμής τάσης για τη σειρά διαγράμματος 1.
1. Προσθήκη λογαρρυθμικής γραμμής τάσης για τη σειρά διαγράμματος 2.
1. Προσθήκη γραμμής τάσης κινητού μέσου για τη σειρά διαγράμματος 2.
1. Προσθήκη πολυωνυμικής γραμμής τάσης για τη σειρά διαγράμματος 3.
1. Προσθήκη γραμμής τάσης δύναμης για τη σειρά διαγράμματος 3.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Ο παρακάτω κώδικας χρησιμοποιείται για τη δημιουργία διαγράμματος με γραμμές τάσης.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργία κενής παρουσίασης
with slides.Presentation() as pres:

    # Δημιουργία διαγράμματος στήλης σε ομάδες
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Προσθήκη εκθετικής γραμμής τάσης για τη σειρά διαγράμματος 1
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Προσθήκη γραμμικής γραμμής τάσης για τη σειρά διαγράμματος 1
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Προσθήκη λογαριθμικής γραμμής τάσης για τη σειρά διαγράμματος 2
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Προσθήκη γραμμής τάσης κινητού μέσου για τη σειρά διαγράμματος 2
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Προσθήκη πολυωνυμικής γραμμής τάσης για τη σειρά διαγράμματος 3
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Προσθήκη γραμμής τάσης δύναμης για τη σειρά διαγράμματος 3
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Αποθήκευση παρουσίασης
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσθήκη Προσαρμοσμένης Γραμμής**
Aspose.Slides for Python via .NET παρέχει ένα απλό API για την προσθήκη προσαρμοσμένων γραμμών σε ένα διάγραμμα. Για να προσθέσετε μια απλή επίπεδη γραμμή σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης Presentation
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας τον Δείκτη της
- Δημιουργήστε ένα νέο διάγραμμα χρησιμοποιώντας τη μέθοδο AddChart που εκτίθεται από το αντικείμενο Shapes
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο AddAutoShape που εκτίθεται από το αντικείμενο Shapes
- Ορίστε το χρώμα των γραμμών του σχήματος.
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX

Ο παρακάτω κώδικας χρησιμοποιείται για τη δημιουργία διαγράμματος με προσαρμοσμένες γραμμές.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Τι σημαίνουν τα 'forward' και 'backward' για μια γραμμή τάσης;**

Αυτά είναι τα μήκη της γραμμής τάσης που προβλέπεται προς τα εμπρός/πίσω: για διαγράμματα διασποράς (XY) — σε μονάδες άξονα· για μη‑διαγράμματα διασποράς — σε αριθμό κατηγοριών. Επιτρέπονται μόνο μη‑αρνητικές τιμές.

**Θα διατηρηθεί η γραμμή τάσης κατά την εξαγωγή της παρουσίασης σε PDF ή SVG, ή κατά τη δημιουργία εικόνας από μια διαφάνεια;**

Ναι. Το Aspose.Slides μετατρέπει τις παρουσιάσεις σε [PDF](/slides/el/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/el/python-net/render-a-slide-as-an-svg-image/) και αποδίδει τα διαγράμματα σε εικόνες· οι γραμμές τάσης, ως μέρος του διαγράμματος, διατηρούνται κατά τη διάρκεια αυτών των λειτουργιών. Διατίθεται επίσης μια μέθοδος για [εξαγωγή εικόνας του διαγράμματος](/slides/el/python-net/create-shape-thumbnails/).