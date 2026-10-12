---
title: Διαχείριση ετικετών δεδομένων διαγράμματος σε παρουσιάσεις με Python
linktitle: Ετικέτα Δεδομένων
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
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να μορφοποιείτε ετικέτες δεδομένων διαγράμματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET για πιο εντυπωσιακές διαφάνειες."
---
## **Εισαγωγή**

Οι ετικέτες δεδομένων εμφανίζουν πληροφορίες σχετικά με τις σειρές του διαγράμματος και τα μεμονωμένα σημεία δεδομένων, βοηθώντας τους αναγνώστες να ταυτοποιήσουν τις τιμές και να κατανοήσουν το διάγραμμα. Αυτό το άρθρο εξηγεί πώς να μορφοποιήσετε τις τιμές, να εμφανίσετε ποσοστά, να διαβάσετε το κείμενο της ετικέτας, να ελέγξετε τις ετικέτες πέραν του μέγιστου άξονα, να προσαρμόσετε το διάστημα ετικετών του άξονα κατηγορίας και να τοποθετήσετε ετικέτες σε διάγραμμα πίτας.

## **Ορισμός Ακρίβειας Δεδομένων στις Ετικέτες Δεδομένων του Διαγράμματος**

Χρησιμοποιήστε [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) για να μορφοποιήσετε τις τιμές των σειρών. Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα, εμφανίζει τον πίνακα δεδομένων του και ενεργοποιεί ετικέτες τιμών για την πρώτη σειρά. Η μορφή `#,##0.00` εμφανίζει διαχωριστικό χιλιάδων και δύο δεκαδικά ψηφία χωρίς να αλλάζει τις υποκείμενες τιμές.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Προβολή Ποσοστού ως Ετικέτες**

Για ένα στοίβαγμα στήλης, υπολογίστε κάθε τιμή ως ποσοστό του συνολικού της κατηγορίας και αντιστοιχίστε το κείμενο στο [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Αυτό το παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα διαγράμματος και εμφανίζει ποσοστά με δύο δεκαδικά ψηφία σε γραμματοσειρά 8 σημείων. Οι κατηγορίες με συνολικό μηδέν παραλείπονται για να αποφευχθεί διαίρεση με το μηδέν. Επαναϋπολογίστε το προσαρμοσμένο κείμενο ετικέτας εάν τα δεδομένα του διαγράμματος αλλάξουν.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Συμβόλου Ποσοστού με Ετικέτες Δεδομένων του Διαγράμματος**

Όταν οι τιμές αποθηκεύονται ως κλάσματα, χρησιμοποιήστε το [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) για να εμφανίσετε ποσοστά. Ορίστε [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) σε `False` ώστε η μορφή της ετικέτας να εφαρμοστεί ανεξάρτητα από τα κελιά προέλευσης.

Αυτό το παράδειγμα δημιουργεί ένα στοίβαγμα στήλης 100% με κόκκινες και μπλε σειρές σε τέσσερις κατηγορίες. Κάθε ζεύγος τιμών αθροίζει σε 1. Η μορφή ετικέτας `0.0%` εμφανίζει το 0.30 ως 30.0%, ενώ ο κατακόρυφος άξονας χρησιμοποιεί δύο δεκαδικά ψηφία. Και οι δύο σειρές χρησιμοποιούν λευκό κείμενο ετικέτας 10 σημείων.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ανάγνωση του Πραγματικού Κειμένου των Ετικετών Δεδομένων**

Χρησιμοποιήστε το [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) για να ανακτήσετε το κείμενο που παράγεται από τις ρυθμίσεις μιας ετικέτας δεδομένων. Αυτό είναι χρήσιμο όταν εξάγετε ετικέτες για αναφορές, αναζητάτε περιεχόμενο παρουσίασης ή επαληθεύετε τα δημιουργημένα διαγράμματα. Στο παρακάτω παράδειγμα, η προεπιλεγμένη [μορφή ετικέτας δεδομένων](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) συνδυάζει το όνομα κάθε κατηγορίας, το όνομα της σειράς και την τιμή. Ένα σημείο μορφοποιεί την τιμή του ως ποσοστό, ενώ ένα άλλο χρησιμοποιεί προσαρμοσμένο κείμενο από το [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

Ο αριθμός που αποθηκεύεται σε ένα σημείο δεδομένων παραμένει `0.75`, ακόμη όταν η ετικέτα του εμφανίζει `75%` μαζί με τα ονόματα κατηγορίας και σειράς. Το προσαρμοσμένο κείμενο αντικαθιστά το παραγόμενο κείμενο ετικέτας. Το [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) επιστρέφει τη συμβολοσειρά ετικέτας σε οποιαδήποτε περίπτωση. Ελέγξτε το [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) ξεχωριστά, όπως φαίνεται παραπάνω, όταν θέλετε να εξάγετε μόνο τις ορατές ετικέτες.

## **Έλεγχος Ετικετών Δεδομένων Πέραν του Μέγιστου Άξονα**

Όταν περιορίζετε το εύρος ενός άξονα χειροκίνητα, ορισμένα σημεία δεδομένων μπορεί να υπερβαίνουν το μέγιστό του. Χρησιμοποιήστε το [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) για να ελέγξετε αν τις ετικέτες δεδομένων τους θα εμφανίζονται. Αυτή η ρύθμιση αλλάζει την ορατότητα της ετικέτας· δεν αλλάζει το εύρος του άξονα ή τις υποκείμενες τιμές των δεδομένων.

Το παρακάτω παράδειγμα δημιουργεί ένα 2D συγκεντρωτικό διάγραμμα στήλης με τιμές 60 και 120. Ορίζει το [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) σε `False` και το [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) σε 100 στον κατακόρυφο άξονα. Η πρώτη διαφάνεια επιτρέπει ετικέτες πέραν του μέγιστου· ένα αντίγραφο αυτής της διαφάνειας τις απενεργοποιεί. Και οι δύο διαφάνειες αποθηκεύονται στο `DataLabelsOverMaximum.pptx`.

Ενεργοποιήστε τις ετικέτες τιμών με το [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Η ρύθμιση σε επίπεδο διαγράμματος δεν ενεργοποιεί την εμφάνιση τιμών από μόνη της ούτε υπερκαλύπτει την απενεργοποιημένη εμφάνιση τιμών μιας μεμονωμένης ετικέτας. Αυτό το παράδειγμα ενεργοποιεί τις τιμές για ολόκληρη τη σειρά και χρησιμοποιεί το [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) για να τοποθετήσει τις ετικέτες στο εξωτερικό άκρο κάθε στήλης.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

Οι παρακάτω εικόνες δείχνουν τις αποθηκευμένες διαφάνειες όπως αποδίδονται από το Microsoft PowerPoint. Με `True`, η ετικέτα **120** είναι ορατή στο ανώτερο όριο· με `False`, είναι κρυφή. Η ετικέτα **60** παραμένει ορατή, το μέγιστο του άξονα παραμένει **100**, και το δεύτερο σημείο δεδομένων παραμένει **120** και στις δύο περιπτώσεις.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![Διάγραμμα PowerPoint που εμφανίζει την ετικέτα τιμής 120 με μέγιστο άξονα 100](data-labels-over-maximum-true.png) | ![Διάγραμμα PowerPoint που κρύβει την ετικέτα τιμής 120 με μέγιστο άξονα 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Αυτό το παράδειγμα χρησιμοποιεί ένα 2D διάγραμμα στήλης με αξονική τιμή. Τα διαγράμματα χωρίς αξονική τιμή, όπως τα διαγράμματα πίτας και δακτυλίου, δεν διαθέτουν μέγιστο άξονα που να μπορεί να περιοριστεί με αυτόν τον τρόπο.
{{% /alert %}}

## **Ορισμός Απόστασης Ετικέτας από Άξονα**

Χρησιμοποιήστε το [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) για να ελέγξετε την απόσταση μεταξύ των ετικετών του άξονα κατηγορίας και του άξονα. Η τιμή είναι ποσοστό του μέγιστου μεγέθους γραμματοσειράς των ετικετών άξονα. Αυτό το παράδειγμα δημιουργεί ένα συγκεντρωτικό διάγραμμα στήλης και ορίζει το οριζόντιο offset ετικέτας άξονα σε 500. Η ρύθμιση αυτή επηρεάζει τις ετικέτες του άξονα κατηγορίας και όχι τις ετικέτες που είναι συνδεδεμένες με μεμονωμένα σημεία δεδομένων.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσαρμογή Θέσης Ετικέτας**

Σε ένα διάγραμμα πίτας, προσαρμόστε τη θέση των ετικετών δεδομένων για να βελτιώσετε το διάστημα και να δημιουργήσετε χώρο για τις γραμμές καθοδήγησης.

Αυτό το παράδειγμα εμφανίζει την τιμή του πρώτου σημείου δεδομένων, τοποθετεί την ετικέτα του εκτός του τμήματος και προσαρμόζει τις μετατοπίσεις του [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) και του [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/). Οι μετατοπίσεις αυτές είναι σχετικές με το πλάτος και το ύψος του διαγράμματος αντίστοιχα.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Διάγραμμα πίτας με προσαρμοσμένη θέση ετικέτας δεδομένων](pie-chart-adjusted-label.png)

## **Προσθήκη Πολλαπλών Σειρών Ετικετών Δεδομένων Πάνω από Διάγραμμα Στήλης**

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα στήλης με δύο σειρές ετικετών δεδομένων πάνω από την περιοχή σχεδίασης. Η Σειρά A εμφανίζει τις ορατές στήλες, ενώ οι Σειρές B και C παρέχουν τις πρόσθετες ετικέτες. Οι στήλες τους κρύβονται αφαιρώντας το γέμισμα και το περίγραμμα. Η ιδιότητα [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) ευθυγραμμίζει και τις τρεις σειρές με τα ίδια κέντρα κατηγορίας.

Οι ρυθμίσεις του [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) διατηρούν χώρο για τις σειρές ετικετών. Μετά τον υπολογισμό των προεπιλεγμένων θέσεων από το [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/), τα [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) και [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) διατηρούν την οριζόντια ευθυγράμμιση και εφαρμόζουν κάθετες μετατοπίσεις για τη διάταξη των ετικετών σε δύο σειρές. Οι αριθμοί παραμένουν ετικέτες δεδομένων συνδεδεμένες με τις τιμές των σειρών· μόνο οι επικεφαλίδες των σειρών είναι ξεχωριστά σχήματα κειμένου.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # Απόκρυψη των στηλών B και C, αλλά διατήρηση των ετικετών δεδομένων τους.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # Στοίχιση και των τριών σειρών στα ίδια κέντρα κατηγορίας.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # Χρήση λιγότερων γραμμών πλέγματος για αυτό το συμπαγές παράδειγμα.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # Δέσμευση χώρου πάνω από το χώρο σχεδίασης για δύο σειρές ετικετών δεδομένων.
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # Διατήρηση της προεπιλεγμένης οριζόντιας θέσης. Το Y είναι μια μετατόπιση από
            # την προεπιλεγμένη θέση ετικέτας, που εκφράζεται ως κλάσμα του ύψους του διαγράμματος.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # Μόνο η επικεφαλίδα της σειράς είναι ξεχωριστό σχήμα κειμένου.
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![Διάγραμμα στήλης με δύο σειρές ετικετών δεδομένων πάνω από την περιοχή σχεδίασης](multiple-rows-of-labels.png)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αποτρέψω την επικάλυψη ετικετών δεδομένων σε πυκνά διαγράμματα;**

Συνδυάστε αυτόματη τοποθέτηση ετικετών, γραμμές καθοδήγησης και μείωση του μεγέθους γραμματοσειράς· εάν χρειάζεται, κρύψτε ορισμένα πεδία (για παράδειγμα, την κατηγορία) ή εμφανίστε ετικέτες μόνο για ακραίες τιμές ή βασικά σημεία.

**Πώς μπορώ να απενεργοποιήσω ετικέτες μόνο για μηδενικές, αρνητικές ή κενές τιμές;**

Φιλτράρετε τα σημεία δεδομένων πριν ενεργοποιήσετε τις ετικέτες και απενεργοποιήστε την εμφάνιση για τιμές ίσες με 0, αρνητικές τιμές ή ελλιπείς τιμές σύμφωνα με έναν ορισμένο κανόνα.

**Πώς μπορώ να εξασφαλίσω συνεπές στυλ ετικετών κατά την εξαγωγή σε PDF/εικόνες;**

Ορίστε ρητά την οικογένεια γραμματοσειράς και το μέγεθος και επαληθεύστε ότι η γραμματοσειρά είναι διαθέσιμη στο περιβάλλον απόδοσης για να αποφύγετε την εναλλακτική εμφάνιση.