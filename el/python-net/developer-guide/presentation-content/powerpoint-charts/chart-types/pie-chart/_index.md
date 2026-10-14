---
title: Προσαρμογή διαγραμμάτων πίτας σε παρουσιάσεις με Python
linktitle: Διάγραμμα Πίτας
type: docs
url: /el/python-net/pie-chart/
keywords:
- διάγραμμα πίτας
- διαχείριση διαγράμματος
- προσαρμογή διαγράμματος
- επιλογές διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές απεικόνισης
- χρώμα φέτας
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα πίτας σε Python με το Aspose.Slides. Διαμορφώστε δευτερεύοντα διαγράμματα, εμφανίστε ετικέτες δεδομένων και εφαρμόστε αυτόματα χρώματα φετών σε PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με διαγράμματα πίτας στο Aspose.Slides. Δείχνει πώς να ρυθμίσετε τις επιλογές δευτερεύοντος διαγράμματος για τα διαγράμματα Pie of Pie και Bar of Pie, και πώς να ενεργοποιήσετε την αυτόματη χρωματική απόδοση των φετών για ένα τυπικό διάγραμμα πίτας.

Τα παραδείγματα εστιάζουν σε εργασίες προσαρμογής διαγράμματος όπως η προσθήκη διαγράμματος σε μια διαφάνεια, η προσαρμογή ρυθμίσεων σειρών και ετικετών, η αντικατάσταση των προεπιλεγμένων δεδομένων διαγράμματος με προσαρμοσμένες κατηγορίες και τιμές, και η αποθήκευση της ενημερωμένης παρουσίασης.

## **Δεύτερες Επιλογές Διαγράμματος για τα διαγράμματα Pie of Pie και Bar of Pie**

Το Aspose.Slides for Python μέσω .NET υποστηρίζει επιλογές δευτερεύοντος διαγράμματος για τα διαγράμματα Pie of Pie και Bar of Pie. Αυτές οι επιλογές ελέγχουν το μέγεθος του δευτερεύοντος διαγράμματος και το πώς τα σημεία δεδομένων διαιρούνται μεταξύ των δύο διαγραμμάτων.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα Pie of Pie σε μια νέα παρουσίαση και εμφανίζει τις τιμές των σημείων δεδομένων ως ετικέτες. Η ιδιότητα [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) ορίζει το μέγεθος του δευτερεύοντος διαγράμματος στο 149% του κύριου διαγράμματος. Η [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) επιλέγει διαίρεση βάσει ποσοστών, και η [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) ορίζει το κατώφλι στο 53%.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Εμφάνιση τιμών και διαμόρφωση του δευτερεύοντος διαγράμματος.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **Επιλογή Κατηγοριών για το Δευτερεύον Διάγραμμα**

Χρησιμοποιήστε προσαρμοσμένη κατανομή όταν θέλετε να ομαδοποιήσετε συγκεκριμένες κατηγορίες στο δευτερεύον διάγραμμα ανεξαρτήτως των ποσοστών τους. Για παράδειγμα, μια αναφορά πωλήσεων μπορεί να εμφανίζει τα Online και Events μαζί ώστε οι αναγνώστες να μπορούν να συγκρίνουν αυτά τα δύο κανάλια, ακόμη και αν αντιπροσωπεύουν το 35% και το 10% των συνολικών πωλήσεων.

Ορίστε την [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) σε [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) και επιλέξτε τα σημεία μέσω της [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/). Η μέθοδος [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) της συλλογής δέχεται είτε έναν μηδενικό δείκτη στη σειρά είτε ένα αντικείμενο σημείου δεδομένων. Σε αυτό το παράδειγμα, ο δείκτης 1 επιλέγει το Online, και το σημείο με δείκτη 3 επιλέγει το Events. Το Partners προστίθεται επίσης προσωρινά, και στη συνέχεια εξαιρείται χρησιμοποιώντας την [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Αντικατάσταση των προεπιλεγμένων δεδομένων με πωλήσεις ανά κανάλι.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Επιλογή του Online με τον μηδενικό δείκτη του και του Events με το αντικείμενο σημείου δεδομένων.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Εξαίρεση του Partners από την επιλογή χωρίς διαγραφή των πηγαίων δεδομένων.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Το Online (35) και το Events (10) εμφανίζονται ως ξεχωριστά φέτες στο δευτερεύον διάγραμμα. Στο κύριο διάγραμμα, αντιπροσωπεύονται από μια ενωμένη φέτα με τιμή 45, μαζί με το Retail (40) και το Partners (15). Η αφαίρεση του Partners από την προσαρμοσμένη επιλογή το διατηρεί στο κύριο διάγραμμα· δεν αφαιρεί την κατηγορία ή την τιμή της από τα πηγαία δεδομένα του διαγράμματος.

Η παρακάτω εικόνα δείχνει την αποθηκευμένη παρουσίαση στο PowerPoint:

![Διάγραμμα Pie of Pie με Online και Events στο δευτερεύον διάγραμμα και τη συνδυασμένη τιμή τους 45 στο κύριο διάγραμμα](pie_of_pie_custom.png)

## **Ορισμός Αυτόματων Χρωμάτων Φετών του Διαγράμματος Πίτας**

Το Aspose.Slides for Python μέσω .NET μπορεί να αντιστοιχίσει αυτόματα διαφορετικά χρώματα στις φέτες του διαγράμματος πίτας. Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα πίτας με κεντρικό τίτλο και αντικαθιστά τα προεπιλεγμένα δεδομένα με τρεις τριμηνιαίες κατηγορίες και τις τιμές τους. Η ιδιότητα [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) εμφανίζει τις τιμές 20, 50 και 30 ως ετικέτες, ενώ η [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) ενεργοποιεί διαφορετικό χρώμα για κάθε φέτα.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Προσθήκη κεντραρισμένου τίτλου διαγράμματος.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Αντικατάσταση των προεπιλεγμένων δεδομένων χρησιμοποιώντας το πρώτο φύλλο εργασίας.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # Εμφάνιση τιμών και ανάθεση διαφορετικών χρωμάτων στις φέτες.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Υποστηρίζονται οι παραλλαγές Pie of Pie και Bar of Pie;**

Ναι, η βιβλιοθήκη [supports](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ένα δευτερεύον διάγραμμα για διαγράμματα πίτας, συμπεριλαμβανομένων των τύπων Pie of Pie και Bar of Pie.

**Μπορώ να εξάγω μόνο το διάγραμμα ως εικόνα (π.χ., PNG);**

Ναι, μπορείτε να [εξάγετε το ίδιο το διάγραμμα ως εικόνα](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (such as PNG) without exporting the entire presentation.