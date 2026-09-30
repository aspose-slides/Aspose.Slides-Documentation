---
title: Προσαρμογή Υπομνημάτων Διαγραμμάτων σε Παρουσιάσεις με Python
linktitle: Υπόμνημα Διαγράμματος
type: docs
url: /el/python-net/chart-legend/
keywords:
- υπόμνημα διαγράμματος
- θέση υπομνήματος
- μέγεθος γραμματοσειράς
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Προσαρμόστε τα υπόμνηματα διαγραμμάτων με το Aspose.Slides για Python μέσω .NET ώστε να βελτιστοποιήσετε τις παρουσιάσεις PowerPoint με προσαρμοσμένη μορφοποίηση υπομνήματος."
---
## **Επισκόπηση**

Το Aspose.Slides για Python μέσω .NET παρέχει επιλογές για προσαρμογή των υπομνημάτων των διαγραμμάτων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο δείχνει πώς να τοποθετήσετε και να διατάξετε ένα υπόμνημα, να ορίσετε το μέγεθος γραμματοσειράς για ολόκληρο το υπόμνημα, να μορφοποιήσετε μια μεμονωμένη καταχώρηση υπομνήματος και να κρύψετε ή να επαναφέρετε επιλεγμένες καταχωρήσεις.

Η Συχνές Ερωτήσεις καλύπτει σχετικές συμπεριφορές, όπως η δεσμεύση χώρου για το υπόμνημα, η εμφάνιση ετικετών πολλαπλών γραμμών και η κληρονόμηση μορφοποίησης από το θέμα της παρουσίασης.

## **Τοποθέτηση Υπομνήματος**

Χρησιμοποιήστε τις ιδιότητες [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/) και [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) του υπομνήματος για να καθορίσετε τη θέση και το μέγεθός του ως κλάσματα των διαστάσεων του διαγράμματος.

Αυτό το παράδειγμα δημιουργεί μια παρουσίαση και προσθέτει ένα ενωματοποιημένο γράφημα στηλών με προεπιλεγμένα δεδομένα στην πρώτη διαφάνεια. Διαιρώντας τις επιθυμητές αποστάσεις και διαστάσεις του υπομνήματος με το πλάτος και το ύψος του διαγράμματος, μετατρέπονται σε σχετικές τιμές: το υπόμνημα μετατοπίζεται κατά 50 σημεία από την κορυφή-αριστερή γωνία του διαγράμματος και έχει μέγεθος 100 x 100 σημεία.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Δηλώστε τη θέση και το μέγεθος του υπομνήματος σε σχέση με το διάγραμμα.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Μεγέθους Γραμματοσειράς Υπομνήματος**

Χρησιμοποιήστε το [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) του υπομνήματος για πρόσβαση στη μορφοποίηση κειμένου και ορίστε το [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) σε σημεία.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα με προεπιλεγμένα δεδομένα και ορίζει το κείμενο του υπομνήματος σε 20 σημεία. Επίσης, απενεργοποιεί τα αυτόματα όρια για τον κατακόρυφο άξονα και θέτει το εύρος του από -5 έως 10.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Μεγέθους Γραμματοσειράς Μίας Μεμονωμένης Καταχώρησης Υπομνήματος**

Χρησιμοποιήστε τη συλλογή [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) του υπομνήματος για πρόσβαση στη μορφοποίηση μιας συγκεκριμένης καταχώρησης. Οι δείκτες των καταχωρήσεων αρχίζουν από το μηδέν, επομένως ο δείκτης `1` αναφέρεται στη δεύτερη καταχώρηση.

Αυτό το παράδειγμα δημιουργεί ένα ενωματοποιημένο γράφημα στηλών το οποίο περιλαμβάνει τουλάχιστον δύο σειρές με προεπιλεγμένα δεδομένα. Μορφοποιεί τη δεύτερη καταχώρηση υπομνήματος με έντονη, πλάγια και κείμενο 20 σημείων μπλε.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Απόκρυψη Μεμονωμένων Καταχωρήσεων Υπομνήματος**

Για να αποκλείσετε μια βοηθητική σειρά από το υπόμνημα διατηρώντας τα δεδομένα της ορατά, ορίστε το [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) σε `True` μέσω του [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/). Αυτό κρύβει μόνο την επιλεγμένη καταχώρηση του υπομνήματος· δεν αφαιρεί τη σειρά ή τα σημεία δεδομένων της. Σε αντίθεση, ορίζοντας το [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) σε `False` κρύβει ολόκληρο το υπόμνημα.

Το παρακάτω παράδειγμα δημιουργεί ένα ενωματοποιημένο γράφημα στηλών με πολλαπλές σειρές χρησιμοποιώντας προεπιλεγμένα δεδομένα. Κρύβει τη καταχώρηση υπομνήματος της δεύτερης σειράς (δείκτης `1`) και αποθηκεύει την παρουσίαση. Στη συνέχεια επαναφέρει τη καταχώρηση ορίζοντας το [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) σε `False` και αποθηκεύει ένα δεύτερο αντίγραφο. Οι στήλες παραμένουν ορατές και στα δύο αρχεία.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Επαναφέρετε την ίδια καταχώρηση χωρίς να αλλάξετε τα δεδομένα του διαγράμματος.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

Η παρακάτω σύγκριση δείχνει το ίδιο γράφημα με όλες τις καταχωρήσεις ορατές και με τη δεύτερη καταχώρηση κρυμμένη. Οι στήλες της δεύτερης σειράς παραμένουν αμετάβλητες.

![Σύγκριση ενός γραφήματος με όλες τις καταχωρήσεις υπομνήματος ορατές και με τη Σειρά 2 κρυμμένη από το υπόμνημα· όλες οι στήλες παραμένουν ορατές.](hide-legend-entry.png)

Σε γραφήματα στήλης, ράβδου και γραμμής, οι καταχωρήσεις υπομνήματος προσδιορίζουν τις σειρές. Για γραφήματα πίτας, προσδιορίζουν τα μεμονωμένα σημεία δεδομένων (κομμάτια), οπότε χρησιμοποιήστε το [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) στο επιλεγμένο κομμάτι. Το API τεκμηριώνει αυτή τη ιδιότητα σημείου δεδομένων για τους τύπους γραφημάτων `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE` και `BAR_OF_PIE`. Μην υποθέτετε ότι ισχύει για γραφήματα ντόνατ, τα οποία δεν περιλαμβάνονται σε αυτή τη λίστα.

## **FAQ**

**Μπορώ να κάνω το γράφημα να δεσμεύει χώρο για το υπόμνημα αντί να το επικάλυπται;**

Ναι. Ορίστε το [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) σε `False` για να δεσμεύσετε χώρο για το υπόμνημα αντί να επιτρέψετε την επικάλυψη της περιοχής σχεδίασης.

**Μπορώ να δημιουργήσω ετικέτες υπομνήματος πολλαπλών γραμμών;**

Ναι. Οι μεγάλες ετικέτες μπορούν να αναδίνονται όταν το διαθέσιμο πλάτος είναι ανεπαρκές. Μπορείτε επίσης να χρησιμοποιήσετε χαρακτήρες νέας γραμμής στα ονόματα σειρών για να ζητήσετε αλλαγές γραμμής.

**Πώς μπορώ να κάνω το υπόμνημα να ακολουθεί το χρωματικό σχήμα του θέματος της παρουσίασης;**

Αφήστε τα χρώματα, τα γέμισματα και τις γραμματοσειρές του υπομνήματος ακαθορισμένα ώστε να μπορεί να κληρονομήσει τη μορφοποίηση του θέματος. Η ρητή μορφοποίηση παρακάμπτει τις αντίστοιχες ρυθμίσεις του θέματος.