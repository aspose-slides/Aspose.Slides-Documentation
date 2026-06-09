---
title: Διαχείριση ετικετών δεδομένων γραφήματος σε παρουσιάσεις με Python
linktitle: Ετικέτα δεδομένων
type: docs
url: /el/python-net/chart-data-label/
keywords:
- διάγραμμα
- ετικέτα δεδομένων
- ακρίβεια δεδομένων
- ποσοστό
- απόσταση ετικέτας
- θέση ετικέτας
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να μορφοποιείτε ετικέτες δεδομένων διαγράμματος σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET για πιο ελκυστικές διαφάνειες."
---
## **Επισκόπηση**

Οι ετικέτες δεδομένων σε ένα γράφημα εμφανίζουν λεπτομέρειες σχετικά με τις σειρές δεδομένων του γραφήματος ή μεμονωμένα σημεία δεδομένων. Επιτρέπουν στους αναγνώστες να αναγνωρίζουν γρήγορα τις σειρές δεδομένων και καθιστούν τα γραφήματα πιο εύκολα στην κατανόηση. Στο Aspose.Slides for Python, μπορείτε να ενεργοποιήσετε, να προσαρμόσετε και να μορφοποιήσετε τις ετικέτες δεδομένων για οποιοδήποτε γράφημα—επιλέγοντας τι θα εμφανίζεται (τιμές, ποσοστά, ονόματα σειρών ή κατηγοριών), πού θα τοποθετηθούν οι ετικέτες και πώς θα φαίνονται (γραμματοσειρά, μορφή αριθμού, διαχωριστικά, γραμμές οδηγού και άλλα). Αυτό το άρθρο περιγράφει τα βασικά API και παραδείγματα που χρειάζεστε για να προσθέσετε σαφείς, πληροφοριακές ετικέτες στα γραφήματά σας.

## **Ορισμός Ακρίβειας Ετικέτας Δεδομένων**

Οι ετικέτες δεδομένων γραφήματος συχνά εμφανίζουν αριθμητικές τιμές που απαιτούν συνεπή ακρίβεια. Αυτή η ενότητα δείχνει πώς να ελέγξετε τον αριθμό των δεκαδικών θέσεων για τις ετικέτες δεδομένων στο Aspose.Slides εφαρμόζοντας μια κατάλληλη μορφή αριθμού.

Το παρακάτω παράδειγμα Python δείχνει πώς να ορίσετε την αριθμητική ακρίβεια για τις ετικέτες δεδομένων του γραφήματος:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **Εμφάνιση Ποσοστών ως Ετικέτες**

Με το Aspose.Slides, μπορείτε να εμφανίζετε τα ποσοστά ως ετικέτες δεδομένων στα γραφήματα. Το παρακάτω παράδειγμα υπολογίζει το μερίδιο κάθε σημείου μέσα στην κατηγορία του και μορφοποιεί την ετικέτα ώστε να εμφανίζει το ποσοστό.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Δημιουργία ενός αντικειμένου της κλάσης Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # Αποθήκευση της παρουσίασης που περιλαμβάνει το γράφημα.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Εμφάνιση Σημαδιού Ποσοστού με τις Ετικέτες Δεδομένων του Γραφήματος**

Αυτή η ενότητα δείχνει πώς να εμφανίζετε ποσοστά στις ετικέτες δεδομένων του γραφήματος και να προσθέτετε το σύμβολο του ποσοστού χρησιμοποιώντας το Aspose.Slides. Θα μάθετε πώς να ενεργοποιείτε τις τιμές ποσοστών για ολόκληρες σειρές ή συγκεκριμένα σημεία (ιδανικό για πίτες, δακτυλίους και 100% στοιβαζόμενα γραφήματα) και πώς να ελέγχετε τη μορφοποίηση μέσω των επιλογών ετικέτας ή μιας προσαρμοσμένης μορφής αριθμού.

Το παρακάτω παράδειγμα Python δείχνει πώς να προσθέσετε το σημάδι του ποσοστού σε μια ετικέτα δεδομένων γραφήματος:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Δημιουργία ενός αντικειμένου της κλάσης Presentation.
with slides.Presentation() as presentation:

    # Λήψη αναφοράς σε διαφάνεια με βάση τον δείκτη.
    slide = presentation.slides[0]

    # Δημιουργία διαγράμματος Ποσοστιαίας Στοίβας Στήλης στη διαφάνεια.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Λήψη του βιβλίου εργασίας δεδομένων του διαγράμματος.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Προσθήκη νέας σειράς.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Ορισμός χρώματος γέμισης για τη σειρά.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Ορισμός ιδιοτήτων μορφοποίησης ετικετών.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Προσθήκη νέας σειράς.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Ορισμός τύπου γέμισης και χρώματος.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Αποθήκευση της παρουσίασης.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Απόστασης Ετικέτας από τον Άξονα**

Αυτή η ενότητα δείχνει πώς να ελέγξετε την απόσταση μεταξύ των ετικετών δεδομένων και του άξονα του γραφήματος στο Aspose.Slides. Η ρύθμιση αυτής της μετατόπισης βοηθά στην αποφυγή επικάλυψης και βελτιώνει την αναγνωσιμότητα σε πυκνά οπτικά στοιχεία.

Το παρακάτω κώδικα Python δείχνει πώς να ορίσετε την απόσταση της ετικέτας από τον άξονα κατηγορίας όταν εργάζεστε με γράφημα βασισμένο σε άξονες:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Δημιουργία ενός αντικειμένου της κλάσης Presentation.
with slides.Presentation() as presentation:
    # Λήψη αναφοράς σε διαφάνεια.
    slide = presentation.slides[0]

    # Δημιουργία διαγράμματος ομαδοποιημένων στηλών στη διαφάνεια.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Ορισμός απόστασης ετικέτας από τον (οριζόντιο) άξονα κατηγορίας.
    chart.axes.horizontal_axis.label_offset = 500

    # Αποθήκευση της παρουσίασης.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσαρμογή Θέσης Ετικέτας**

Όταν δημιουργείτε ένα γράφημα που δεν χρησιμοποιεί άξονες, όπως ένα διάγραμμα πίτας, οι ετικέτες δεδομένων μπορεί να είναι πολύ κοντά στο άκρο. Σε αυτήν την περίπτωση, προσαρμόστε τη θέση της ετικέτας ώστε οι γραμμές οδηγού να εμφανίζονται καθαρά.

Το παρακάτω κώδικα Python δείχνει πώς να προσαρμόσετε τη θέση της ετικέτας σε ένα διάγραμμα πίτας:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Changed label position](changed_label_position.png)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αποτρέψω την επικάλυψη των ετικετών δεδομένων σε πυκνά γραφήματα;**

Συνδυάστε αυτόματη τοποθέτηση ετικετών, γραμμές οδηγού και μειωμένο μέγεθος γραμματοσειράς· εάν χρειαστεί, αποκρύψτε ορισμένα πεδία (π.χ. την κατηγορία) ή εμφανίστε ετικέτες μόνο για ακραία/βασικά σημεία.

**Πώς μπορώ να απενεργοποιήσω τις ετικέτες μόνο για τιμές μηδέν, αρνητικές ή κενές;**

Φιλτράρετε τα σημεία δεδομένων πριν ενεργοποιήσετε τις ετικέτες και απενεργοποιήστε την εμφάνιση για τιμές 0, αρνητικές τιμές ή ελλιπείς τιμές σύμφωνα με έναν καθορισμένο κανόνα.

**Πώς μπορώ να εξασφαλίσω συνεπή στυλ ετικέτας κατά την εξαγωγή σε PDF/εικόνες;**

Ορίστε ρητά τις γραμματοσειρές (οικογένεια, μέγεθος) και βεβαιωθείτε ότι η γραμματοσειρά είναι διαθέσιμη στο περιβάλλον απόδοσης για να αποφύγετε την εναλλακτική χρήση.